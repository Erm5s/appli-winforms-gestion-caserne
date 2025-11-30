using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Pinpon;

namespace tempUtilisation
{
    public partial class tempUtilisationEngin: UserControl
    {
        int idCaserne;
        public tempUtilisationEngin()
        {
            InitializeComponent();
            idCaserne = 3;
        }
        public tempUtilisationEngin(int caserne)
        {
            InitializeComponent();
            idCaserne = caserne;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            SQLiteConnection cx = Connexion.Connec;
            string sql = @"SELECT 
                            t.code || ' ' || e.numero AS engin,
                            ROUND(SUM((JULIANDAY(m.dateHeureRetour) - JULIANDAY(m.dateHeureDepart)) * 24), 2) AS heureUtilisation
                        FROM Engin e
                        LEFT JOIN PartirAvec pa 
                            ON pa.numeroEngin = e.numero 
                            AND pa.codeTypeEngin = e.codeTypeEngin 
                            AND pa.idCaserne = e.idCaserne
                        LEFT JOIN Mission m 
                            ON m.id = pa.idMission
                        JOIN TypeEngin t 
                            ON e.codeTypeEngin = t.code
                        WHERE e.idCaserne = "+idCaserne+@"
                        GROUP BY e.idCaserne, e.codeTypeEngin, e.numero
                        ORDER BY heureUtilisation DESC";

            SQLiteCommand cmd = new SQLiteCommand(sql, cx);
            cmd.Parameters.AddWithValue("@idCaserne", idCaserne);
            int left = 50;
            int i = 0;
            int hauteurMaxPx = 140;
            int maxHeures = 170;
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string nom = reader.IsDBNull(0) ? "" : reader.GetString(0);
                    int heures = reader.IsDBNull(1) ? 0 : (int)reader.GetDouble(1);
                    int panelHeight = (int)(hauteurMaxPx * ((double)heures / maxHeures));// hauteur proportionnelle au temps

                    Panel panel = new Panel();
                    panel.BackColor = Color.Blue;
                    panel.Top = 140;
                    panel.Left = left;
                    panel.Size = new Size(20, 10);
                    panel.Tag ="0;"+ i+";"+ panelHeight; 

                    Label labelNom = new Label();
                    labelNom.Text = nom;
                    labelNom.Tag = "1;"+i;
                    labelNom.Top = panel.Top + panel.Height + 5;
                    labelNom.Left = panel.Left - 15;
                    labelNom.AutoSize = true;
                    labelNom.Visible = false;

                    Label labelTemps = new Label();
                    labelTemps.Text = heures.ToString("0.0") + " heures";
                    labelTemps.Tag = "1;"+i;
                    labelTemps.Top = panel.Top - 20;
                    labelTemps.Left = panel.Left - 25;
                    labelTemps.AutoSize = true;
                    labelTemps.Visible = false;

                    // Ajout à l'interface
                    pnl_global.Controls.Add(panel);
                    pnl_global.Controls.Add(labelTemps);
                    pnl_global.Controls.Add(labelNom);

                    left += 100;
                    i++;
                }
            }
        }

        private void UserControl1_MouseEnter(object sender, EventArgs e)
        {
            for(int i = 0; i<pnl_global.Controls.Count; i++)
            {
                string[] tagComplet = pnl_global.Controls[i].Tag.ToString().Split(';');

                if (tagComplet[0] == "0")
                {
                    Panel panel = (Panel)pnl_global.Controls[i];
                    int targetHeight = int.Parse(tagComplet[2]);

                    // Trouve les labels correspondants
                    Label labelTemps = null;
                    Label labelNom = null;

                    for(int j = 0; j<pnl_global.Controls.Count; j++)
                    {
                        string[] tagCompletLabel = pnl_global.Controls[j].Tag.ToString().Split(';');
                        if (tagCompletLabel[0] == "1" && tagCompletLabel[1] == tagComplet[1])
                        {
                            Label lbl = (Label)pnl_global.Controls[j]; 
                            if (lbl.Top < panel.Top)
                                labelTemps = lbl;
                            else
                                labelNom = lbl;
                        }
                    }

                    if (labelTemps != null && labelNom != null)
                    {
                        panel_animation(panel, labelTemps, labelNom, targetHeight);
                    }
                }
            }
        }
        private void panel_animation(object sender, Label l1, Label l2, int taille)
        {
            Panel p = (Panel)sender;

            int initialTop = p.Top;
            int initialHeight = p.Height;

            Timer timer = new Timer();
            timer.Interval = 10;

            timer.Tag = new Tuple<Panel, Label, Label, int>(p, l1, l2, taille);

            timer.Tick += (s, args) =>
            {
                var t = (Tuple<Panel, Label, Label, int>)((Timer)s).Tag;
                Panel panel = t.Item1;
                Label labelTemps = t.Item2;
                Label labelNom = t.Item3;
                int target = t.Item4;

                if (panel.Height < target)
                {
                    panel.Top -= 1;
                    panel.Height += 1;

                    // MAJ du label temps pour suivre le haut du panel
                    labelTemps.Top = panel.Top - 20;
                }
                else
                {
                    ((Timer)s).Stop();
                    ((Timer)s).Dispose();
                }
            };

            timer.Start();
            l1.Visible = true;
            l2.Visible = true;
        }
    }
}
