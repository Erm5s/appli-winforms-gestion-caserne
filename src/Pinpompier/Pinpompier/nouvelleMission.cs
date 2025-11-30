using Pinpon;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pinpompier
{
    internal class nouvelleMission
    {
        private TextBox txtVille;
        private TextBox txtRue;
        private TextBox txtMotif;
        private TextBox txtCP;
        private ComboBox cboSinistre;
        private ComboBox cboCaserne;
        private Button btnValider;
        private Button btnRAZ;
        private Button btnRAZSinistre;
        private Button btnValiderEquipe;
        private Panel pnlGestionMission;

        DataTable tabCaserne;
        DataTable tabNatureSinistre;
        DataTable tabEngin;
        DataTable tabPompier;
        DataTable tabTypeEngin;
        DataTable tabNecessiter;
        DataTable tabMission;
        DataTable tabEmbarquer;
        DataTable tabAffectation;
        DataTable tabPasser;
        DataTable tabPartirAvec;
        FlowLayoutPanel flpPompiers;
        FlowLayoutPanel flpEngins;


        List<DataRow> pompiersMission = new List<DataRow>();
        List<DataRow> enginsMission = new List<DataRow>();
        bool infosValides = false;

        public nouvelleMission()
        {

        }

        public void majTableauVariable()
        {
            tabCaserne = MesDatas.DsGlobal.Tables["Caserne"];
            tabNatureSinistre = MesDatas.DsGlobal.Tables["NatureSinistre"];
            tabEngin = MesDatas.DsGlobal.Tables["Engin"];
            tabPompier = MesDatas.DsGlobal.Tables["Pompier"];
            tabTypeEngin = MesDatas.DsGlobal.Tables["TypeEngin"];
            tabNecessiter = MesDatas.DsGlobal.Tables["Necessiter"];
            tabMission = MesDatas.DsGlobal.Tables["Mission"];
            tabEmbarquer = MesDatas.DsGlobal.Tables["Embarquer"];
            tabAffectation = MesDatas.DsGlobal.Tables["Affectation"];
            tabPasser = MesDatas.DsGlobal.Tables["Passer"];
            tabPartirAvec = MesDatas.DsGlobal.Tables["PartirAvec"];
        }

        public void genererNouvelleMission(Panel cible)
        {
            pnlGestionMission = new Panel();
            pnlGestionMission.Size = new Size(1080, 700);
            pnlGestionMission.BackColor = Color.DarkRed;

            // GroupBox Informations Mission
            GroupBox grpInfos = new GroupBox();
            grpInfos.Text = "Informations mission";
            grpInfos.ForeColor = Color.White;
            grpInfos.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grpInfos.Location = new Point(10, 60);
            grpInfos.Size = new Size(1040, 250);

            // Motif
            Label lblMotif = new Label { Text = "Motif", ForeColor = Color.White, Location = new Point(20, 30) };
            txtMotif = new TextBox { Location = new Point(20, 60), Size = new Size(400, 80), Multiline = true };

            // Rue
            Label lblRue = new Label { Text = "Rue", ForeColor = Color.White, Location = new Point(595, 30) };
            txtRue = new TextBox { Location = new Point(600, 60), Size = new Size(250, 25) };

            // Code postal
            Label lblCP = new Label { Text = "Code Postal", ForeColor = Color.White, Location = new Point(595, 100) };
            txtCP = new TextBox { Location = new Point(600, 130), Size = new Size(60, 25) };
            txtCP.KeyPress += txtCP_KeyPress;

            // Ville
            Label lblVille = new Label { Text = "Ville", ForeColor = Color.White, Location = new Point(595, 170) };
            txtVille = new TextBox { Location = new Point(600, 200), Size = new Size(250, 25) };

            // Nature du sinistre
            Label lblSinistre = new Label { Text = "Nature du sinistre", ForeColor = Color.White, Location = new Point(20, 150), Size = new Size(200, 30) };
            cboSinistre = new ComboBox { Location = new Point(20, 180), Size = new Size(250, 25) };

            // Bouton RAZ
            btnRAZSinistre = new Button { Text = "RAZ sinistre", Location = new Point(900, 120), Size = new Size(100, 30), BackColor = Color.LightCoral };
            btnRAZSinistre.Click += btnRAZSinistre_Click;

            // Bouton RAZ
            btnRAZ = new Button { Text = "RAZ", Location = new Point(900, 160), Size = new Size(100, 30), BackColor = Color.LightCoral };
            btnRAZ.Click += btnRAZ_Click;

            // Bouton valider
            btnValider = new Button { Text = "Valider", Location = new Point(900, 200), Size = new Size(100, 30), BackColor = Color.LightCoral };
            btnValider.Click += btnValider_Click;

            grpInfos.Controls.AddRange(new Control[] {
                           lblMotif, txtMotif, lblRue, txtRue, lblVille, txtVille,
                           lblSinistre, cboSinistre, lblCP, txtCP, btnRAZSinistre, btnRAZ, btnValider});

            // GroupBox Equipe mission
            GroupBox grpEquipe = new GroupBox();
            grpEquipe.Text = "Equipe mission";
            grpEquipe.ForeColor = Color.White;
            grpEquipe.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grpEquipe.Location = new Point(10, 330); 
            grpEquipe.Size = new Size(1040, 340);

            // Caserne sélectionné
            Label lblCaserne = new Label { Text = "Caserne à mobiliser", ForeColor = Color.White, Location = new Point(20, 40), Size = new Size(150, 30) };
            cboCaserne = new ComboBox { Location = new Point(170, 38), Size = new Size(200, 25) };
            cboCaserne.Enabled = false;
            cboCaserne.SelectedIndexChanged += cboCaserne_SelectedIndexChanged;

            // Bouton valider équipe
            btnValiderEquipe = new Button { Text = "Valider équipe", Location = new Point(850, 38), Size = new Size(150, 30), BackColor = Color.LightCoral };
            btnValiderEquipe.Click += btnValiderEquipe_Click;

            flpPompiers = new FlowLayoutPanel
            {
                Location = new Point(20, 90),
                Size = new Size(480, 230),
                AutoScroll = true,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown,
                BackColor = Color.LightCoral,
            };

            flpEngins = new FlowLayoutPanel
            {
                Location = new Point(540, 90),
                Size = new Size(480, 230),
                AutoScroll = true,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown,
                BackColor = Color.LightCoral,
            };

            grpEquipe.Controls.Add(flpEngins);
            grpEquipe.Controls.Add(flpPompiers);
            grpEquipe.Controls.Add(lblCaserne);
            grpEquipe.Controls.Add(cboCaserne);
            grpEquipe.Controls.Add(btnValiderEquipe);

            // Ajout au panel principal
            pnlGestionMission.Controls.Add(grpInfos);
            pnlGestionMission.Controls.Add(grpEquipe);

            cible.Controls.Clear();
            cible.Controls.Add(pnlGestionMission);

            majTableauVariable();
            chargementComboBox();
        }


        private void chargementComboBox()
        {
            cboSinistre.DataSource = tabNatureSinistre;
            cboSinistre.DisplayMember = "libelle";
            cboSinistre.ValueMember = "id";
            cboSinistre.Text = "";

            cboCaserne.DataSource = tabCaserne;
            cboCaserne.DisplayMember = "nom";
            cboCaserne.ValueMember = "id";
            cboCaserne.Text = "";
        }

        private void cboCaserne_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(infosValides)
            {
                flpEngins.Controls.Clear();
                flpPompiers.Controls.Clear();
                int idSinistre = Convert.ToInt32(((DataRowView)cboSinistre.SelectedItem)["id"]);
                int idCaserneInitiale = Convert.ToInt32(cboCaserne.SelectedValue);
                List<DataRow> enginsRequis = getEnginsRequis(idSinistre);

                // Obtenir une liste de toutes les casernes
                List<int> listeCasernes = new List<int>();
                foreach (DataRow dr in tabCaserne.Rows)
                    listeCasernes.Add(Convert.ToInt32(dr["id"]));

                // trouver la caserne qui peut faire la mission

                List<DataRow> enginsDisponibles = getEnginsDispo(idCaserneInitiale);
                List<DataRow> pompiersDispo = getPompiersDispo(idCaserneInitiale);

                if (!assezEnginsPourMission(enginsRequis, enginsDisponibles) && !assezPompiersMission(pompiersDispo, getHabilitationsRequises()))
                {
                    MessageBox.Show("Pas assez de POMPIERS ni assez d'ENGINS dans la caserne sélectionnée");
                }
                else if (!assezPompiersMission(pompiersDispo, getHabilitationsRequises()))
                {
                    MessageBox.Show("Pas assez de POMPIERS dans la caserne sélectionnée");
                }
                else if (!assezEnginsPourMission(enginsRequis, enginsDisponibles))
                {
                    MessageBox.Show("Pas assez d'ENGINS dans la caserne sélectionnée");
                }
                else if (assezEnginsPourMission(enginsRequis, enginsDisponibles) && assezPompiersMission(pompiersDispo, getHabilitationsRequises()))
                {
                    foreach (DataRow p in pompiersMission)
                    {

                        photoNom.photoNom phnPompier = new photoNom.photoNom();
                        phnPompier.Texte = p["matricule"] + " - " + p["prenom"] + " " + p["nom"]; ;
                        phnPompier.SizeMode = PictureBoxSizeMode.StretchImage;
                        phnPompier.Image = Image.FromFile("./ImagesGrades/" + p["codeGrade"].ToString() + ".png"); 
                        flpPompiers.Controls.Add(phnPompier);
                        /*
                        PictureBox pictureBox = new PictureBox{ Size = new Size(55, 55) };
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox.Image = Image.FromFile("./ImagesGrades/" + p["codeGrade"].ToString() + ".png");
                        flpPompiers.Controls.Add(pictureBox);
                        */
                    }

                    foreach (DataRow v in enginsMission)
                    {

                        photoNom.photoNom phnEngin = new photoNom.photoNom();
                        phnEngin.Texte = v["codeTypeEngin"] + " " + v["numero"] + " - " + getTypeEnginAvecCode(v["codeTypeEngin"].ToString());
                        phnEngin.SizeMode = PictureBoxSizeMode.StretchImage;
                        phnEngin.Image = Image.FromFile("./Engins/" + v["codeTypeEngin"].ToString() + ".png"); 
                        flpEngins.Controls.Add(phnEngin);
                    }
                }
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (txtMotif.Text != String.Empty && txtRue.Text != String.Empty && txtVille.Text != String.Empty && cboSinistre.Text != String.Empty && txtCP.Text.Length == 5)
            {
                cboCaserne.Enabled = true;
                txtMotif.Enabled = false;
                txtRue.Enabled = false;
                txtVille.Enabled = false;
                txtCP.Enabled = false;
                cboSinistre.Enabled = false;
                infosValides = true;
            }
            else
            {
                infosValides = false;
                MessageBox.Show("Remplissez correctement tous les champs !");
            }
        }

        private void btnRAZ_Click(object sender, EventArgs e)
        {
            cboCaserne.Enabled = false;
            txtMotif.Enabled = true;
            txtRue.Enabled = true;
            txtVille.Enabled = true;
            txtCP.Enabled = true;
            cboSinistre.Enabled = true;
            infosValides = false;

            txtMotif.Text = String.Empty;
            txtVille.Text = String.Empty;
            txtCP.Text = String.Empty;
            txtRue.Text = String.Empty;
            cboSinistre.SelectedIndex = -1;
            cboSinistre.Text = String.Empty;
            cboCaserne.SelectedIndex = -1;
            cboCaserne.Text = String.Empty;
            flpEngins.Controls.Clear();
            flpPompiers.Controls.Clear();
            enginsMission.Clear();
            pompiersMission.Clear();
        }

        private void btnRAZSinistre_Click(object sender, EventArgs e)
        {
            cboCaserne.Enabled = false;
            txtMotif.Enabled = true;
            txtRue.Enabled = true;
            txtVille.Enabled = true;
            txtCP.Enabled = true;
            cboSinistre.Enabled = true;
            infosValides = false;

            cboSinistre.SelectedIndex = -1;
            cboSinistre.Text = String.Empty;
            cboCaserne.SelectedIndex = -1;
            cboCaserne.Text = String.Empty;
            flpEngins.Controls.Clear();
            flpPompiers.Controls.Clear();
            enginsMission.Clear();
            pompiersMission.Clear();
        }

        private void btnValiderEquipe_Click(object sender, EventArgs e)
        {
            if (cboCaserne.Text == String.Empty)
                MessageBox.Show("Choisissez une caserne");
            else
            {
                creerMission();
                majTableauVariable();
                btnRAZ_Click(sender, e);
            }
        }


        // Retourne les lignes du tableau Necessiter contenant les engins nécessaires au sinistre sélectionné de la cboSinistre
        private List<DataRow> getEnginsRequis(int idSinistre)
        {
            List<DataRow> enginsRequis = new List<DataRow>();
            DataRow[] drNecessiter = tabNecessiter.Select("idNatureSinistre = " + idSinistre);
            foreach (DataRow row in drNecessiter)
            {
                enginsRequis.Add(row);
            }

            return enginsRequis;
        }

        // Retourne les lignes du tableau Engins contenant les engins qui ne sont ni en mission, ni en panne, dans la caserne sélectionnée de la cboCaserne
        private List<DataRow> getEnginsDispo(int idCaserne)
        {
            List<DataRow> engins = new List<DataRow>();
            foreach (DataRow row in tabEngin.Rows)
            {
                if (!Convert.ToBoolean(row["enMission"]) && !Convert.ToBoolean(row["enPanne"]) && Convert.ToInt32(row["idCaserne"]) == idCaserne)
                {
                    engins.Add(row);
                }
            }
            return engins;
        }



        // Retourne les lignes du tableau Pompier contenant les pompiers qui ne sont ni en mission, ni en congé, dans la caserne sélectionnée de la cboCaserne
        private List<DataRow> getPompiersDispo(int idCaserne)
        {
            List<DataRow> pompiers = new List<DataRow>();
            int matricule;

            foreach (DataRow row in tabPompier.Rows)
            {
                matricule = Convert.ToInt32(row["matricule"]);
                if (!Convert.ToBoolean(row["enMission"]) && !Convert.ToBoolean(row["enConge"]) && estAffecteACaserne(matricule, idCaserne))
                {
                    {
                        pompiers.Add(row);
                    }
                }
            }
            return pompiers;
        }

        private bool estAffecteACaserne(int matriculeVoulu, int idCaserneVoulu)
        {
            bool estAffecte = false;
            foreach (DataRow row in tabAffectation.Rows)
            {
                int matricule = Convert.ToInt32(row["matriculePompier"]);
                int idCaserne = Convert.ToInt32(row["idCaserne"]);

                if (matricule == matriculeVoulu && idCaserne == idCaserneVoulu)
                {
                    return true; // le pompier est bien affecté à cette caserne
                }
            }

            return estAffecte;
        }



        private bool assezEnginsPourMission(List<DataRow> enginsRequis, List<DataRow> enginsDisponible)
        {
            // Vérifie si il y a assez d'engins disponible pour lancer la mission
            enginsMission.Clear();

            foreach (DataRow besoin in enginsRequis)
            {
                string codeType = besoin["codeTypeEngin"].ToString();
                int nombreRequis = Convert.ToInt32(besoin["nombre"]);

                int nombreAjoutes = 0;

                foreach (DataRow engin in enginsDisponible)
                {
                    if (engin["codeTypeEngin"].ToString() == codeType)
                    {
                        enginsMission.Add(engin);
                        nombreAjoutes++;

                        if (nombreAjoutes == nombreRequis)
                        {
                            break;
                        }
                    }
                }

                if (nombreAjoutes < nombreRequis)
                {
                    return false; // pas assez d'engins pour ce type
                }
            }
            return true;
        }

        private List<(int idHab, int nombre)> getHabilitationsRequises()
        {
            List<(int, int)> habilitations = new List<(int, int)>();

            foreach (DataRow engin in enginsMission)
            {
                string codeTypeEngin = engin["codeTypeEngin"].ToString();

                foreach (DataRow row in tabEmbarquer.Rows)
                {
                    if (row["codeTypeEngin"].ToString() == codeTypeEngin)
                    {
                        int idHab = Convert.ToInt32(row["idHabilitation"]);
                        int nb = Convert.ToInt32(row["nombre"]);
                        habilitations.Add((idHab, nb));
                    }
                }
            }

            return habilitations;
        }

        private List<DataRow> getPompierHabilite(List<DataRow> pompiers, int idHab, int nbMax)
        {
            List<DataRow> candidats = new List<DataRow>();

            foreach (DataRow p in pompiers)
            {
                int matricule = Convert.ToInt32(p["Matricule"]);

                foreach (DataRow h in tabPasser.Rows)
                {
                    int mat = Convert.ToInt32(h["matriculePompier"]);
                    int hab = Convert.ToInt32(h["idHabilitation"]);

                    if (mat == matricule && hab == idHab)
                    {
                        candidats.Add(p);
                        break; // on arrête de chercher pour ce pompier
                    }
                }

                if (candidats.Count == nbMax)
                    break; // on a trouvé assez de pompiers
            }

            return candidats;
        }


        private bool assezPompiersMission(List<DataRow> pompiersDispo, List<(int, int)> habilitationsRequises)
        {
            pompiersMission.Clear();
            // On fait une copie de la liste pour retirer les pompiers trouvés et éviter les doublons
            List<DataRow> pompiersRestants = new List<DataRow>(pompiersDispo);

            foreach ((int idHab, int nbRequis) in habilitationsRequises)
            {
                List<DataRow> candidats = getPompierHabilite(pompiersRestants, idHab, nbRequis);

                if (candidats.Count < nbRequis)
                {
                    return false; // pas assez de pompiers pour cette habilitation
                }

                // Retirer les pompiers sélectionnés pour ne pas les réutiliser
                foreach (DataRow p in candidats)
                {
                    pompiersMission.Add(p);
                    pompiersRestants.Remove(p);
                }
            }

            return true; // tous les besoins sont couverts
        }

        private string getTypeEnginAvecCode(string code)
        {
            DataRow[] lignes = tabTypeEngin.Select("code = '" + code + "'");
            if (lignes.Length > 0)
            {
                return lignes[0]["nom"].ToString();
            }
            return "Code inconnu";
        }

        private void creerMission()
        {
            DataRow nouvelleMission = tabMission.NewRow();

            // +1 au dernier id existant
            int idMax = 0;

            foreach (DataRow r in tabMission.Rows)
            {
                int id = Convert.ToInt32(r["id"]);
                if (id > idMax)
                    idMax = id;
            }
            idMax++;

            nouvelleMission["id"] = idMax;
            nouvelleMission["dateHeureDepart"] = DateTime.Now;
            nouvelleMission["dateHeureRetour"] = DateTime.Now;
            nouvelleMission["motifAppel"] = txtMotif.Text;
            nouvelleMission["adresse"] = txtRue.Text;
            nouvelleMission["cp"] = txtCP.Text;
            nouvelleMission["ville"] = txtVille.Text;
            nouvelleMission["terminee"] = 0;
            nouvelleMission["compteRendu"] = null;
            nouvelleMission["idNatureSinistre"] = cboSinistre.SelectedValue;
            nouvelleMission["idCaserne"] = cboCaserne.SelectedValue;

            // ajout de la mission à la table
            tabMission.Rows.Add(nouvelleMission);
            // mettre engin en mission
            foreach (DataRow engin in enginsMission)
            {
                engin["EnMission"] = true;
                DataRow nvMission = tabPartirAvec.NewRow();
                nvMission["idCaserne"] = cboCaserne.SelectedValue;
                nvMission["codeTypeEngin"] = engin["codeTypeEngin"];
                nvMission["numeroEngin"] = engin["numero"];
                nvMission["idMission"] = idMax;

            }

            // mettre pompier en mission
            foreach (DataRow pompier in pompiersMission)
            {
                pompier["EnMission"] = true;

            }
            majTableauVariable();
            MessageBox.Show("Mission attribuée à la caserne " + cboCaserne.SelectedValue + " avec " + enginsMission.Count + " engin(s) et " + pompiersMission.Count + " pompier(s) affecté(s)");
        }
        private void txtCP_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
    }
}
