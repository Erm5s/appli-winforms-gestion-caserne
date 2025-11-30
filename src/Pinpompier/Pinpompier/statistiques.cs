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
    internal class statistiques
    {
        private Panel pnl_stats;
        private Panel pnlStatistiques;
        private SQLiteConnection cx;
        public void genererStatistiques(Panel cible)
        {
            pnlStatistiques = new Panel();
            pnlStatistiques.Size = new Size(1080, 700);
            pnlStatistiques.BackColor = Color.DarkRed;
            pnlStatistiques.Top = 50;

            pnl_stats = new Panel();
            Panel pnl_stats_caserne = new Panel();
            //Panel pnl_stats_autre = new Panel();
            ComboBox cbo_stats_caserne = new ComboBox();
            TabControl tab_stats_autre = new TabControl();
            TabPage tpg_Info_general = new TabPage();
            TabPage tpg_stats_habilitation = new TabPage();



            pnl_stats.Location = new Point(0, -25);
            pnl_stats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnl_stats.Name = "pnl_stats";
            pnl_stats.Size = new System.Drawing.Size(1080, 720);

            pnl_stats_caserne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnl_stats_caserne.Location = new System.Drawing.Point(35, 50);
            pnl_stats_caserne.Name = "pnl_stats_caserne";
            pnl_stats_caserne.Size = new System.Drawing.Size(480, 590);

            tab_stats_autre.Location = new System.Drawing.Point(540, 50);
            tab_stats_autre.Name = "tab_stats_autre";
            tab_stats_autre.Size = new Size(480, 590);
            // 
            // tpg_Info_general
            // 
            tpg_Info_general.Location = new System.Drawing.Point(540, 50);
            tpg_Info_general.Name = "tpg_Info_general";
            tpg_Info_general.Padding = new System.Windows.Forms.Padding(3);
            tpg_Info_general.Size = new System.Drawing.Size(480, 590);
            tpg_Info_general.TabIndex = 0;
            tpg_Info_general.Text = "Statistiques global";
            tpg_Info_general.UseVisualStyleBackColor = true;
            remplirTpgInfoGlobal(tpg_Info_general);
            // 
            // tpg_stats_habilitation
            // 
            tpg_stats_habilitation.Location = new System.Drawing.Point(540, 50);
            tpg_stats_habilitation.Name = "tpg_stats_habilitation";
            tpg_stats_habilitation.Padding = new System.Windows.Forms.Padding(3);
            tpg_stats_habilitation.Size = new System.Drawing.Size(480, 590);
            tpg_stats_habilitation.TabIndex = 1;
            tpg_stats_habilitation.Text = "Habilitations";
            tpg_stats_habilitation.UseVisualStyleBackColor = true;
            remplirTpgHabilitation(tpg_stats_habilitation);

            cbo_stats_caserne.FormattingEnabled = true;
            cbo_stats_caserne.Location = new System.Drawing.Point(20, 21);
            cbo_stats_caserne.Name = "cbo_caserne";
            cbo_stats_caserne.Size = new System.Drawing.Size(269, 36);
            chargerCBOCaserne(cbo_stats_caserne);
            cbo_stats_caserne.SelectedIndexChanged += new System.EventHandler(cbo_stats_caserne_SelectedIndexChanged);

            tab_stats_autre.Controls.Add(tpg_Info_general);
            tab_stats_autre.Controls.Add(tpg_stats_habilitation);
            pnl_stats.Controls.Add(pnl_stats_caserne);
            pnl_stats.Controls.Add(tab_stats_autre);
            pnl_stats_caserne.Controls.Add(cbo_stats_caserne);
            pnlStatistiques.Controls.Add(pnl_stats);

            if (cbo_stats_caserne.Items.Count > 0)
            {
                cbo_stats_caserne.SelectedIndex = 0; // Déclenche SelectedIndexChanged
                cbo_stats_caserne_SelectedIndexChanged(cbo_stats_caserne, EventArgs.Empty);
            }


            cible.Controls.Clear();
            cible.Controls.Add(pnlStatistiques);
        }
        public void chargerCBOCaserne(ComboBox cbo_caserne)
        {
            cx = Connexion.Connec;
            string sql = "SELECT id, nom FROM Caserne";
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, cx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbo_caserne.DataSource = dt;
            cbo_caserne.ValueMember = "id";
            cbo_caserne.DisplayMember = "nom";
            Connexion.FermerConnexion();
        }
        public void remplirTpgInfoGlobal(TabPage tpg)
        {
            // Nettoyage de la page
            tpg.Controls.Clear();

            Label lbl = new Label();
            lbl.Text = "Classement du nombre d’interventions par type de sinistre :";
            lbl.AutoSize = true;
            lbl.Top = 5;
            lbl.Left = 10;

            // Création du ListView
            ListView lv = new ListView
            {
                Top = lbl.Top + 25,
                Left = 10,
                Size = new Size(460, 240),
                View = View.Details,
                FullRowSelect = true
            };

            // Définir les colonnes
            lv.Columns.Add("Rang", 50);
            lv.Columns.Add("Type de sinistre", 300);
            lv.Columns.Add("Interventions", 110);

            // Requête SQL
            string sql = @"SELECT s.libelle AS ""Type de sinistre"", COUNT(m.id) AS ""Nombre d'interventions""
                                        FROM NatureSinistre s
                                        LEFT JOIN Mission m ON m.idNatureSinistre = s.id
                                        GROUP BY s.libelle
                                        ORDER BY COUNT(m.id) DESC;";

            cx = Connexion.Connec;
            SQLiteCommand cmd = new SQLiteCommand(sql, cx);

            try
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    int i = 1;
                    while (reader.Read())
                    {
                        string type = reader.IsDBNull(0) ? "Inconnu" : reader.GetString(0);
                        string nb = reader.IsDBNull(1) ? "0" : reader.GetInt32(1).ToString();

                        ListViewItem item = new ListViewItem(i.ToString());
                        item.SubItems.Add(type);
                        item.SubItems.Add(nb);

                        lv.Items.Add(item);
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la lecture des données : " + ex.Message);
            }

            Label lbl2 = new Label();
            lbl2.Text = "Habilitations les plus sollicité : ";
            lbl2.AutoSize = true;
            lbl2.Top = lv.Top + lv.Height + 10;
            lbl2.Left = 10;
            lbl2.Visible = true;

            sql = @"SELECT h.libelle, COUNT(m.id) AS 'nombre de sollicitations'
                                        FROM Habilitation h
                                        LEFT JOIN Embarquer e ON h.id = e.idHabilitation
                                        LEFT JOIN Necessiter n ON e.codeTypeEngin = n.codeTypeEngin
                                        LEFT JOIN Mission m ON n.idNatureSinistre = m.idNatureSinistre
                                        GROUP BY h.id
                                        ORDER BY COUNT(m.id) DESC;";
            podium.podium po = new podium.podium(sql);
            po.Left = 30;
            po.Top = lbl2.Bottom + 10;

            Connexion.FermerConnexion();
            // Affichage
            lv.Visible = true;
            tpg.Controls.Add(lbl);
            tpg.Controls.Add(lv);
            tpg.Controls.Add(lbl2);
            tpg.Controls.Add(po);
        }
        public void remplirTpgHabilitation(TabPage tpg)
        {
            ComboBox cbo_stats_habilitation = new ComboBox();
            ListView lv = new ListView
            {
                Top = 60,
                Left = 10,
                Size = new Size(460, 400),
                View = View.List,
                FullRowSelect = true
            };
            lv.Visible = true;
            chargerCBOStats_Habilitation(cbo_stats_habilitation);
            cbo_stats_habilitation.Top = 10;
            cbo_stats_habilitation.Left = 10;
            cbo_stats_habilitation.Size = new Size(300, 36);
            cbo_stats_habilitation.Visible = true;

            cbo_stats_habilitation.SelectedIndexChanged += new System.EventHandler(cbo_stats_habilitation_SelectedIndexChanged);
            tpg.Controls.Add(lv);
            tpg.Controls.Add(cbo_stats_habilitation);

            if (cbo_stats_habilitation.Items.Count > 0)
            {
                cbo_stats_habilitation.SelectedIndex = 0; // Déclenche SelectedIndexChanged
                cbo_stats_caserne_SelectedIndexChanged(cbo_stats_habilitation, EventArgs.Empty);
            }
        }
        public void chargerCBOStats_Habilitation(ComboBox cbo)
        {
            cx = Connexion.Connec;
            string sql = "SELECT id, libelle FROM Habilitation";
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, cx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbo.DataSource = dt;
            cbo.ValueMember = "id";
            cbo.DisplayMember = "libelle";
            Connexion.FermerConnexion();
        }
        private void cbo_stats_caserne_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;

            Label lbl_stats_caserne = new Label();
            lbl_stats_caserne.Top = lbl_stats_caserne.Top + 50;
            lbl_stats_caserne.Left = 10;
            lbl_stats_caserne.Text = "Vehicules les plus utilisé : ";
            lbl_stats_caserne.AutoSize = true;
            lbl_stats_caserne.Visible = true;

            Panel panel = (Panel)pnl_stats.Controls[0];
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                if (panel.Controls[i] != cbo)
                {
                    panel.Controls.Remove(panel.Controls[i]);
                }
            }
            int idCaserne = Convert.ToInt32(cbo.SelectedValue);
            string sql = @"SELECT 
                                t.code || ' ' || e.numero AS engin,
                                COUNT(pa.idMission) AS nombre_interventions
                            FROM Engin e
                            JOIN TypeEngin t ON e.codeTypeEngin = t.code
                            JOIN PartirAvec pa ON pa.numeroEngin = e.numero AND pa.codeTypeEngin = e.codeTypeEngin AND pa.idCaserne = e.idCaserne
                            WHERE e.idCaserne = " + idCaserne + @"
                            GROUP BY engin
                            ORDER BY nombre_interventions DESC
                            LIMIT 3;";
            podium.podium po = new podium.podium(sql);
            po.Top = lbl_stats_caserne.Bottom + 20;
            po.Left = cbo.Left;

            tempUtilisation.tempUtilisationEngin tu = new tempUtilisation.tempUtilisationEngin(idCaserne);
            tu.Top = po.Bottom + 20;
            tu.Left = po.Left;
            
            panel.Controls.Add(po);
            panel.Controls.Add(tu);
            panel.Controls.Add(lbl_stats_caserne);
        }
        private void cbo_stats_habilitation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            TabPage pag = (TabPage)pnl_stats.Controls[1].Controls[1];
            remplirListViewHabilitation((ListView)pag.Controls[0], Convert.ToInt32(cbo.SelectedValue));
        }
        public void remplirListViewHabilitation(ListView l, int habilitation)
        {
            l.Items.Clear();

            string sql = @"
                            SELECT p.nom || ' ' || p.prenom AS Pompier
                                        FROM Habilitation h
                                        LEFT JOIN Passer a ON a.idHabilitation = h.id
                                        LEFT JOIN Pompier p ON p.matricule = a.matriculePompier
                                        WHERE h.id = " + habilitation + @" 
                                        ORDER BY h.libelle, p.nom;";

            cx = Connexion.Connec;
            SQLiteCommand cmd = new SQLiteCommand(sql, cx);
            cmd.Parameters.AddWithValue("@habilitation", habilitation); // sécurisation

            try
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        l.Items.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la lecture des données : " + ex.Message);
            }
        }
    }
}
