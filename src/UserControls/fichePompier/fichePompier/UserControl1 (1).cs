using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using Pinpon;
using System.Diagnostics;

namespace fichePompier
{
    public partial class fichePompier: UserControl
    {
        private SQLiteConnection cx;
        private int matricule;
        private bool estConnecter;
        private SQLiteTransaction transac;

        public fichePompier()
        {
            InitializeComponent();
            matricule = -1;
            estConnecter = false;
            rdb_homme.Checked = true;
            rdb_nouvPro.Checked = true;
            cx = Connexion.Connec;
            remplirNouvCheckListBox();
            chargerCBONouvaffectation();
            chargerCBONouvGrade();
            Connexion.FermerConnexion();
        }
        public fichePompier(bool connecter)
        {
            InitializeComponent();
            matricule = -1;
            estConnecter = connecter;
            rdb_homme.Checked = true;
            rdb_nouvPro.Checked = true;
            cx = Connexion.Connec;
            remplirNouvCheckListBox();
            chargerCBONouvaffectation();
            chargerCBONouvGrade();
            Connexion.FermerConnexion();
            
        }
        public fichePompier(int pmatricule, bool connecter)
        {
            InitializeComponent();
            matricule = pmatricule;
            estConnecter = connecter;

            cx = Connexion.Connec;

            try
            {
                // ----------- 1. Infos Pompier ----------
                string sql = "SELECT * FROM Pompier WHERE matricule = @matricule";
                SQLiteCommand cmd = new SQLiteCommand(sql, cx);
                cmd.Parameters.AddWithValue("@matricule", matricule);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lbl_matricule.Text += reader["matricule"].ToString();
                        lbl_nom.Text += reader["nom"].ToString();
                        lbl_prenom.Text += reader["prenom"].ToString();

                        char sexe = Convert.ToChar(reader["sexe"]);
                        lbl_sexe.Text += (sexe == 'm') ? "Masculin" : "Féminin";

                        lbl_dateNaissance.Text += Convert.ToDateTime(reader["dateNaissance"]).ToShortDateString();
                        lbl_dateEmbauche.Text += Convert.ToDateTime(reader["dateEmbauche"]).ToShortDateString();

                        lbl_tel.Text += reader["portable"].ToString();
                        lbl_bip.Text += reader["bip"].ToString();

                        char type = Convert.ToChar(reader["type"]);
                        if (type == 'p') rdb_pro.Checked = true;
                        else rdb_volontaire.Checked = true;

                        bool conge = Convert.ToBoolean(reader["enConge"]);
                        rdb_conge.Checked = conge;
                        chb_conge.Checked = conge;
                    }
                    else
                    {
                        MessageBox.Show("Aucun pompier trouvé avec ce matricule.");
                        return;
                    }
                }

                // ----------- 2. Habilitations ----------
                remplirListeHabilitation();

                // ----------- 3. Affectations terminées ----------
                remplirListeAffectation();

                // ----------- 4. Charger les grades ----------
                chargerCBOgrade();

                // ----------- 5. Sélectionner le grade du pompier ----------
                sql = "SELECT codeGrade FROM Pompier WHERE matricule = @matricule";
                cmd = new SQLiteCommand(sql, cx);
                cmd.Parameters.AddWithValue("@matricule", matricule);
                object grade = cmd.ExecuteScalar();

                if (grade != null)
                {
                    cbo_grade.SelectedValue = grade.ToString();
                }
                pcb_grade.ImageLocation = "./ImagesGrades/" + grade.ToString() + ".png";
                // ----------- 6. Charger les casernes ----------
                chargerCBOaffectation();

                // ----------- 7. Sélectionner la caserne du pompier ----------
                sql = "SELECT idCaserne FROM Affectation WHERE matriculePompier = @matricule and dateFin is null";
                cmd = new SQLiteCommand(sql, cx);
                cmd.Parameters.AddWithValue("@matricule", matricule);
                object caserne = cmd.ExecuteScalar();

                if (caserne != null)
                {
                    cbo_affectation.SelectedValue = caserne.ToString();
                }
                // ----------- 8. Afficher habillitation ----------
                remplirCheckListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
            finally
            {
                Connexion.FermerConnexion();
                rdb_homme.Checked = true;
                rdb_nouvPro.Checked = true;
            }
        }
        private void chargerCBOgrade()
        {
            string sql = "SELECT code, libelle FROM Grade";
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, cx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbo_grade.DataSource = dt;
            cbo_grade.ValueMember = "code";
            cbo_grade.DisplayMember = "libelle";

            chargerCBONouvGrade();
        }
        private void chargerCBONouvGrade()
        {
            string sql = "SELECT code, libelle FROM Grade";
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, cx);
            DataTable dt = new DataTable();

            da.Fill(dt);
            cbo_nouvGrade.DataSource = dt;
            cbo_nouvGrade.ValueMember = "code";
            cbo_nouvGrade.DisplayMember = "libelle";
        }
        private void chargerCBOaffectation()
        {
            string sql = "SELECT id, nom FROM Caserne";
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, cx);
            DataTable dt = new DataTable();

            da.Fill(dt);
            cbo_affectation.DataSource = dt;
            cbo_affectation.ValueMember = "id";
            cbo_affectation.DisplayMember = "nom";
            chargerCBONouvaffectation();
        }
        private void chargerCBONouvaffectation()
        {
            string sql = "SELECT id, nom FROM Caserne";
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, cx);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbo_nouvCaserne.DataSource = dt;
            cbo_nouvCaserne.ValueMember = "id";
            cbo_nouvCaserne.DisplayMember = "nom";
        }
        private void remplirCheckListBox()
        {
            clb_habillitation.Items.Clear();
            string sql = @"SELECT id, libelle 
                    FROM Habilitation 
                    WHERE id not in(Select h.id from Habilitation h JOIN Passer p ON h.id = p.idHabilitation Where p.matriculePompier = @matricule)";
            SQLiteCommand cmd = new SQLiteCommand(sql, cx);
            cmd.Parameters.AddWithValue("@matricule", matricule);

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    clb_habillitation.Items.Add(reader["libelle"].ToString());
                }
            }
            remplirNouvCheckListBox();
        }
        private void remplirNouvCheckListBox()
        {
            string sql = @"SELECT libelle 
                    FROM Habilitation ";
            SQLiteCommand cmd = new SQLiteCommand(sql, cx);
            cmd.Parameters.AddWithValue("@matricule", matricule);

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    clb_nouvHabillitation.Items.Add(reader["libelle"].ToString());
                }
            }
        }
        private void remplirListeAffectation()
        {
            lsb_affectation.Items.Clear();
            String sql = @"SELECT c.nom, a.dateA, a.dateFin 
                    FROM Caserne c 
                    JOIN Affectation a ON c.id = a.idCaserne 
                    WHERE a.matriculePompier = @matricule AND a.dateFin IS NOT NULL";
            SQLiteCommand cmd = new SQLiteCommand(sql, cx);
            cmd.Parameters.AddWithValue("@matricule", matricule);

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lsb_affectation.Items.Add(
                        $"{Convert.ToDateTime(reader["dateA"]).ToShortDateString()} - {Convert.ToDateTime(reader["dateFin"]).ToShortDateString()} - {reader["nom"]}"
                    );
                }
            }
        }
        private void remplirListeHabilitation()
        {
            lsb_habillitation.Items.Clear();
            string sql = @"SELECT h.libelle 
                    FROM Habilitation h 
                    JOIN Passer p ON h.id = p.idHabilitation 
                    WHERE p.matriculePompier = @matricule";
            SQLiteCommand cmd = new SQLiteCommand(sql, cx);
            cmd.Parameters.AddWithValue("@matricule", matricule);

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lsb_habillitation.Items.Add(reader["libelle"].ToString());
                }
            }
        }
        private void btn_infoSup_Click(object sender, EventArgs e)
        {
            if (estConnecter)
            {
                pnl_infoSup.Visible = true;
            }
            else
            {
                login l = new login();
                if (l.ShowDialog() == DialogResult.OK)
                {
                    estConnecter = true;
                    pnl_infoSup.Visible = true;
                }
                else
                {
                    MessageBox.Show("Il faut etre admin pour accedé a ces informations");
                }
            }
        }

        private void cbo_grade_Click(object sender, EventArgs e)
        {
            if (estConnecter)
            {
                btn_valider.Visible = true;
            }
            else
            {
                login l = new login();
                if (l.ShowDialog() == DialogResult.OK)
                {
                    estConnecter = true;
                    btn_valider.Visible = true;
                }
                else
                {
                    MessageBox.Show("Il faut etre admin pour modifier le grade d'un pompier");
                }
            }
        }

        private void btn_valider_Click(object sender, EventArgs e)
        {
            cx = Connexion.Connec;
            transac = cx.BeginTransaction();

            string sql = "UPDATE Pompier SET codeGrade = '"+cbo_grade.SelectedValue+"' WHERE matricule = @matricule";
            SQLiteCommand cmd = new SQLiteCommand(sql, cx);
            cmd.Parameters.AddWithValue("@matricule", matricule);
            cmd.Transaction = transac;
            cmd.ExecuteNonQuery();

            transac.Commit();
            Connexion.FermerConnexion();
            pcb_grade.ImageLocation = "./ImagesGrades/" + cbo_grade.DisplayMember.ToString() + ".png";
            btn_valider.Visible =false;
        }

        private void btn_maj_Click(object sender, EventArgs e)
        {
            try
            {
                cx = Connexion.Connec;
                SQLiteTransaction transac = cx.BeginTransaction();

                string sql = "SELECT idCaserne FROM Affectation WHERE matriculePompier = @matricule AND dateFin IS NULL";
                SQLiteCommand cmd = new SQLiteCommand(sql, cx);
                cmd.Parameters.AddWithValue("@matricule", matricule);
                object caserne = cmd.ExecuteScalar();

                // Nouvelle affectation
                if (caserne == null)
                {
                    sql = "INSERT INTO Affectation (matriculePompier, dateA, idCaserne) VALUES (@matricule, @dateA, @idCaserne)";
                    cmd = new SQLiteCommand(sql, cx, transac);
                    cmd.Parameters.AddWithValue("@matricule", matricule);
                    cmd.Parameters.AddWithValue("@dateA", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@idCaserne", cbo_affectation.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
                else if (caserne.ToString() != cbo_affectation.SelectedValue.ToString())
                {
                    // Fin de l'affectation actuelle
                    sql = "UPDATE Affectation SET dateFin = @dateFin WHERE matriculePompier = @matricule AND dateFin IS NULL AND idCaserne = @idCaserne";
                    cmd = new SQLiteCommand(sql, cx, transac);
                    cmd.Parameters.AddWithValue("@dateFin", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@matricule", matricule);
                    cmd.Parameters.AddWithValue("@idCaserne", caserne);
                    cmd.ExecuteNonQuery();

                    // Nouvelle affectation
                    sql = "INSERT INTO Affectation (matriculePompier, dateA, idCaserne) VALUES (@matricule, @dateA, @idCaserne)";
                    cmd = new SQLiteCommand(sql, cx, transac);
                    cmd.Parameters.AddWithValue("@matricule", matricule);
                    cmd.Parameters.AddWithValue("@dateA", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@idCaserne", cbo_affectation.SelectedValue.ToString());
                    cmd.ExecuteNonQuery();
                }

                // Habilitations cochées
                for (int i = 0; i < clb_habillitation.CheckedItems.Count; i++)
                {
                    string libelle = clb_habillitation.CheckedItems[i].ToString();

                    sql = "SELECT id FROM Habilitation WHERE libelle = @libelle";
                    cmd = new SQLiteCommand(sql, cx, transac);
                    cmd.Parameters.AddWithValue("@libelle", libelle);
                    object idHabillitation = cmd.ExecuteScalar();

                    if (idHabillitation != null)
                    {
                        sql = "INSERT INTO Passer (matriculePompier, idHabilitation, dateObtention) VALUES (@matricule, @idHabilitation, @dateObtention)";
                        cmd = new SQLiteCommand(sql, cx, transac);
                        cmd.Parameters.AddWithValue("@matricule", matricule);
                        cmd.Parameters.AddWithValue("@idHabilitation", idHabillitation);
                        cmd.Parameters.AddWithValue("@dateObtention", DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd.ExecuteNonQuery();
                    }
                }

                // Maj congé
                sql = "UPDATE Pompier SET enConge = @enConge WHERE matricule = @matricule";
                cmd = new SQLiteCommand(sql, cx, transac);
                cmd.Parameters.AddWithValue("@enConge", chb_conge.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@matricule", matricule);
                cmd.ExecuteNonQuery();

                transac.Commit();
                for (int i = 0; i < clb_habillitation.CheckedIndices.Count; i++)
                {
                    clb_habillitation.Items.Remove(clb_habillitation.CheckedIndices[i]);
                    string libelle = clb_habillitation.CheckedItems[i].ToString();

                }
                MessageBox.Show("Mise à jour effectuée.");
                remplirCheckListBox();
                remplirListeAffectation();
                remplirListeHabilitation();
                rdb_conge.Checked = chb_conge.Checked;
                btn_maj.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message +"\n" + ex);
            }
            finally
            {
                Connexion.FermerConnexion();
            }
        }

        private void cbo_affectation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btn_maj.Visible=true;
        }

        private void clb_habillitation_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btn_maj.Visible = true;
        }

        private void chb_conge_CheckedChanged(object sender, EventArgs e)
        {
            if (matricule != -1)
            {
                btn_maj.Visible = true;
            }
        }

        private void tct_fichePompier_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.TabPage.Text))
                e.Cancel = true; // Empêche de sélectionner l’onglet vide
            else if (!estConnecter)
            {
                login l = new login();
                if (l.ShowDialog() != DialogResult.OK)
                {
                    e.Cancel = true;
                    MessageBox.Show("Il faut etre admin pour modifier a des informations");
                }
                else
                {
                    estConnecter = true;
                }
            }
        }

        private void btn_nouvCreer_Click(object sender, EventArgs e)
        {
            cx = Connexion.Connec;
            SQLiteTransaction transac = cx.BeginTransaction();

            try
            {
                // Récupérer le nouveau matricule
                string sql = "SELECT MAX(matricule) FROM Pompier";
                SQLiteCommand cmd = new SQLiteCommand(sql, cx, transac);
                object result = cmd.ExecuteScalar();
                int newMatricule = (result != DBNull.Value) ? Convert.ToInt32(result) + 1 : 1;

                // Récupérer le nouveau bip
                sql = "SELECT MAX(bip) FROM Pompier";
                cmd = new SQLiteCommand(sql, cx, transac);
                result = cmd.ExecuteScalar();
                int newBip = (result != DBNull.Value) ? Convert.ToInt32(result) + 1 : 1;

                // Déterminer sexe et type
                string sexe = rdb_homme.Checked ? "h" : "f";
                string type = rdb_nouvPro.Checked ? "p" : "v";

                // Insertion du pompier
                sql = @"INSERT INTO Pompier 
                (matricule, nom, prenom, sexe, dateNaissance, type, portable, bip, enMission, enConge, codeGrade, dateEmbauche) 
                VALUES 
                (@matricule, @nom, @prenom, @sexe, @dateNaissance, @type, @portable, @bip, 0, 0, @codeGrade, @dateEmbauche)";
                cmd = new SQLiteCommand(sql, cx, transac);
                cmd.Parameters.AddWithValue("@matricule", newMatricule);
                cmd.Parameters.AddWithValue("@nom", txt_nouvNom.Text);
                cmd.Parameters.AddWithValue("@prenom", txt_nouvPrenom.Text);
                cmd.Parameters.AddWithValue("@sexe", sexe);
                cmd.Parameters.AddWithValue("@dateNaissance", dtp_dateNaissance.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@portable", txt_nouvTel.Text);
                cmd.Parameters.AddWithValue("@bip", newBip);
                cmd.Parameters.AddWithValue("@codeGrade", cbo_nouvGrade.SelectedValue);
                cmd.Parameters.AddWithValue("@dateEmbauche", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();

                // Affectation à une caserne
                sql = @"INSERT INTO Affectation (matriculePompier, dateA, idCaserne) 
                VALUES (@matricule, @dateA, @idCaserne)";
                cmd = new SQLiteCommand(sql, cx, transac);
                cmd.Parameters.AddWithValue("@matricule", newMatricule);
                cmd.Parameters.AddWithValue("@dateA", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@idCaserne", cbo_affectation.SelectedValue);
                cmd.ExecuteNonQuery();

                // Habilitations cochées
                foreach (var item in clb_nouvHabillitation.CheckedItems)
                {
                    string libelle = item.ToString();

                    sql = "SELECT id FROM Habilitation WHERE libelle = @libelle";
                    cmd = new SQLiteCommand(sql, cx, transac);
                    cmd.Parameters.AddWithValue("@libelle", libelle);
                    object idHab = cmd.ExecuteScalar();

                    if (idHab != null)
                    {
                        sql = @"INSERT INTO Passer (matriculePompier, idHabilitation, dateObtention) 
                        VALUES (@matricule, @idHabilitation, @dateObtention)";
                        cmd = new SQLiteCommand(sql, cx, transac);
                        cmd.Parameters.AddWithValue("@matricule", newMatricule);
                        cmd.Parameters.AddWithValue("@idHabilitation", idHab);
                        cmd.Parameters.AddWithValue("@dateObtention", DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd.ExecuteNonQuery();
                    }
                }

                // Commit si tout est bon
                transac.Commit();
                MessageBox.Show("Nouveau pompier ajouté avec succès !");
            }
            catch (Exception ex)
            {
                try { transac.Rollback(); } catch { /* Ignore rollback failure */ }
                MessageBox.Show("Une erreur est survenue : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connexion.FermerConnexion();
                txt_nouvNom.Clear();
                txt_nouvPrenom.Clear();
                txt_nouvTel.Clear();
                for (int i = 0; i < clb_habillitation.Items.Count; i++)
                {
                    clb_nouvHabillitation.SetItemChecked(i, false);
                }
            }
        }

        private void txt_nouvTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        public bool EstConnecter
        {
            get { return estConnecter; }
            set { estConnecter = value; }
        }
    }
}
