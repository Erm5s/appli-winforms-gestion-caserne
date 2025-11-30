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
    internal class gestionPompier
    {
        private bool estConnecter;
        private Panel pnlPageGestionPompier;
        private Panel pnlGestionPompier;

        public void genererGestionPompier(Panel cible)
        {       
            pnlPageGestionPompier = new Panel();
            pnlPageGestionPompier.Size = new Size(1080, 700);
            pnlPageGestionPompier.BackColor = Color.DarkRed;
            pnlPageGestionPompier.Top = 50;

            Label lblGestionChoixCaserne = creationLabel("Veuillez sélectionner une caserne :", 50, 40);
            ComboBox cboGestionCaserne = creationCBO(100, 65, new Size(180, 20));

            SQLiteConnection cx = Pinpon.Connexion.Connec;

            string sql = "SELECT id, nom FROM Caserne";
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, cx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cboGestionCaserne.DataSource = dt;
            cboGestionCaserne.ValueMember = "id";
            cboGestionCaserne.DisplayMember = "nom";
            cboGestionCaserne.SelectedIndexChanged += new EventHandler(cboGestionCaserne_SelectedIndexChanged);

            pnlPageGestionPompier.Controls.Add(lblGestionChoixCaserne);
            pnlPageGestionPompier.Controls.Add(cboGestionCaserne);

            Connexion.FermerConnexion();

            // Affichage initial
            if (cboGestionCaserne.Items.Count > 0)
            {
                cboGestionCaserne.SelectedIndex = 0;
                cboGestionCaserne_SelectedIndexChanged(cboGestionCaserne, EventArgs.Empty);
            }

            cible.Controls.Clear();
            cible.Controls.Add(pnlPageGestionPompier);
        }

        private Label creationLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Top = y,
                Left = x,
                AutoSize = true,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
        }

        private ComboBox creationCBO(int x, int y, Size s)
        {
            return new ComboBox
            {
                Left = x,
                Top = y,
                Size = s,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
        }

        private void cboGestionCaserne_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = pnlPageGestionPompier.Controls.Count - 1; i >= 0; i--)
                {
                    if (pnlPageGestionPompier.Controls[i].Tag?.ToString() == "cboGestionPompier")
                        pnlPageGestionPompier.Controls.RemoveAt(i);
                }

                SQLiteConnection cx = Pinpon.Connexion.Connec;

                Label lblGestionChoixPompier = creationLabel("Veuillez sélectionner un pompier :", 50, 95);
                ComboBox cboGestionPompier = creationCBO(100, 120, new Size(180, 20));
                cboGestionPompier.Tag = "cboGestionPompier";

                int idCaserne = Convert.ToInt32(((ComboBox)sender).SelectedValue);

                string sql = "SELECT p.matricule, p.prenom || ' ' || p.nom as nom FROM Pompier p " +
                                "JOIN Affectation a ON p.matricule = a.matriculePompier " +
                                "WHERE a.idCaserne = @idCaserne";

                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, cx);
                da.SelectCommand.Parameters.AddWithValue("@idCaserne", idCaserne);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cboGestionPompier.DataSource = dt;
                cboGestionPompier.ValueMember = "matricule";
                cboGestionPompier.DisplayMember = "nom";
                cboGestionPompier.SelectedValueChanged += new EventHandler(cboGestionPompier_SelectedIndexChanged);

                pnlPageGestionPompier.Controls.Add(lblGestionChoixPompier);
                pnlPageGestionPompier.Controls.Add(cboGestionPompier);

                Connexion.FermerConnexion();

                if (cboGestionPompier.Items.Count > 0)
                {
                    cboGestionPompier.SelectedIndex = 0;
                    cboGestionPompier_SelectedIndexChanged(cboGestionPompier, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void cboGestionPompier_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = pnlPageGestionPompier.Controls.Count - 1; i >= 0; i--)
            {
                if (pnlPageGestionPompier.Controls[i].Tag?.ToString() == "fip_pompier")
                    pnlPageGestionPompier.Controls.RemoveAt(i);
            }

            ComboBox cbo = (ComboBox)sender;
            int matricule = Convert.ToInt32(cbo.SelectedValue);

            fichePompier.fichePompier fp = new fichePompier.fichePompier(matricule, estConnecter);
            fp.Tag = "fip_pompier";
            fp.Top = 0;
            fp.Left = 320;
            fp.Size = new Size(720, 700);

            pnlPageGestionPompier.Controls.Add(fp);
        }
    }
}
