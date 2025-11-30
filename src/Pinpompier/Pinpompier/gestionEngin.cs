using fichePompier;
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
    public class Engin
    {
        public string EnginNom { get; set; }
        public string DateReception { get; set; }
        public bool EnMission { get; set; }
        public bool EnPanne { get; set; }
    }

    internal class gestionEngin
    {
        private Panel pnlPageGestionEngin;
        private Panel pnlGestionEngin;
        private ComboBox cbo_EnginCaserne;
        private Label lbl_EnginNom, lbl_DateReception;
        private RadioButton rdb_EnginEnMission;
        private RadioButton rdb_EnginEnPanne;
        private PictureBox pcb_Engin;
        private Button btn_EnginPrecedent, btn_EnginSuivant, btn_EnginStart, btn_EnginEnd;
        private SQLiteConnection cx;
        private BindingSource bs_Engins = new BindingSource();

        public void genererGestionEngin(Panel cible)
        {
            pnlPageGestionEngin = new Panel();
            pnlPageGestionEngin.Size = new Size(1080, 720);
            pnlPageGestionEngin.Dock = DockStyle.Fill;
            pnlPageGestionEngin.BackColor = Color.DarkRed;

            pnlGestionEngin = new Panel();
            pnlGestionEngin.Size = new Size(600, 550);
            pnlGestionEngin.BackColor = Color.LightCoral;

            // Centrer pnlGestionEngin dans pnlPageGestionEngin
            pnlGestionEngin.Location = new Point(
                (pnlPageGestionEngin.Width - pnlGestionEngin.Width) / 2,
                (pnlPageGestionEngin.Height - pnlGestionEngin.Height) / 2 + 35
            ); ;

            // Polices
            Font fontNormal = new Font("Segoe UI", 14, FontStyle.Regular);
            Font fontGras = new Font("Segoe UI", 14, FontStyle.Bold);

            int centerX = pnlGestionEngin.Width / 2;
            int startY = 140;
            int topOffset = 275;
            int spacingY = 50;

            int buttonWidth = 80;
            int spacing = 20;
            int yPos = topOffset + spacingY * 4;

            // ComboBox Caserne
            cbo_EnginCaserne = new ComboBox
            {
                Width = 300,
                Font = fontNormal,
                Location = new Point(centerX - 150, startY - 100)
            };

            chargerCBOCaserne(cbo_EnginCaserne);
            cbo_EnginCaserne.SelectedIndexChanged += comboBoxCaserne_SelectedIndexChanged;
            pnlGestionEngin.Controls.Add(cbo_EnginCaserne);

            // Label Numéro
            Label lblNumero = new Label
            {
                Text = "Numéro :",
                Font = fontGras,
                AutoSize = true,
                Location = new Point(centerX - 150, topOffset)
            };
            pnlGestionEngin.Controls.Add(lblNumero);

            lbl_EnginNom = new Label
            {
                Font = fontNormal,
                AutoSize = true,
                Location = new Point(centerX + 50, topOffset)
            };
            pnlGestionEngin.Controls.Add(lbl_EnginNom);

            // Date de réception
            Label lblDate = new Label
            {
                Text = "Date de réception :",
                Font = fontGras,
                AutoSize = true,
                Location = new Point(centerX - 150, topOffset + spacingY)
            };
            pnlGestionEngin.Controls.Add(lblDate);

            lbl_DateReception = new Label
            {
                Font = fontNormal,
                AutoSize = true,
                Location = new Point(centerX + 50, topOffset + spacingY)
            };
            pnlGestionEngin.Controls.Add(lbl_DateReception);

            // État
            rdb_EnginEnMission = new RadioButton
            {
                Text = "En mission",
                Font = fontNormal,
                AutoSize = true,
                Location = new Point(centerX - 150, topOffset + spacingY * 2)
            };
            rdb_EnginEnMission.Enabled = false;
            pnlGestionEngin.Controls.Add(rdb_EnginEnMission);

            rdb_EnginEnPanne = new RadioButton
            {
                Text = "En panne",
                Font = fontNormal,
                AutoSize = true,
                Location = new Point(centerX + 50, topOffset + spacingY * 2)
            };
            rdb_EnginEnPanne.Enabled = false;
            pnlGestionEngin.Controls.Add(rdb_EnginEnPanne);

            // Boutons navigation
            btn_EnginPrecedent = new Button
            {
                Text = "<",
                Font = fontNormal,
                Size = new Size(80, 40),
                Location = new Point(centerX - 100, topOffset + spacingY * 4)
            };
            btn_EnginPrecedent.Click += btnPrecedent_Click;
            pnlGestionEngin.Controls.Add(btn_EnginPrecedent);

            btn_EnginSuivant = new Button
            {
                Text = ">",
                Font = fontNormal,
                Size = new Size(80, 40),
                Location = new Point(centerX + 20, topOffset + spacingY * 4)
            };
            btn_EnginSuivant.Click += btnSuivant_Click;

            btn_EnginStart = new Button
            {
                Text = "<<",
                Font = fontNormal,
                Size = new Size(80, 40),
                Location = new Point(btn_EnginPrecedent.Left - buttonWidth - spacing, yPos)
            };
            btn_EnginStart.Click += btnStart_Click;
            pnlGestionEngin.Controls.Add(btn_EnginStart);

            btn_EnginEnd = new Button
            {
                Text = ">>",
                Font = fontNormal,
                Size = new Size(80, 40),
                Location = new Point(btn_EnginSuivant.Right + spacing, yPos)
            };
            btn_EnginEnd.Click += btnEnd_Click;
            pnlGestionEngin.Controls.Add(btn_EnginEnd);

            pcb_Engin = new PictureBox
            {
                Location = new Point(centerX - 50, cbo_EnginCaserne.Top + 70),
                Size = new Size(150, 150),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle,
                BackgroundImageLayout = ImageLayout.Stretch
            };
            pnlGestionEngin.Controls.Add(pcb_Engin);

            pnlGestionEngin.Controls.Add(btn_EnginSuivant);
            cbo_EnginCaserne.SelectedValue = -1;
            cbo_EnginCaserne.Text = String.Empty;
            comboBoxCaserne_SelectedIndexChanged(cbo_EnginCaserne, null);

            pnlPageGestionEngin.Controls.Add(pnlGestionEngin);
            cible.Controls.Clear();
            cible.Controls.Add(pnlPageGestionEngin);
        }
        private void btnSuivant_Click(object sender, EventArgs e)
        {
            if (bs_Engins.Position < bs_Engins.Count - 1)
                bs_Engins.Position++;
            LierDonnees();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            bs_Engins.Position = 0;
            LierDonnees();
        }
        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            if (bs_Engins.Position > 0)
                bs_Engins.Position--;
            LierDonnees();
        }
        private void btnEnd_Click(object sender, EventArgs e)
        {
            bs_Engins.Position = bs_Engins.Count - 1;
            LierDonnees();
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

        private void comboBoxCaserne_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_EnginCaserne.SelectedValue is null || cbo_EnginCaserne.SelectedValue == DBNull.Value)
                return;

            int idCaserne = Convert.ToInt32(cbo_EnginCaserne.SelectedValue);

            List<Engin> engins = ChargerEnginsParCaserne(idCaserne);

            bs_Engins.DataSource = engins;
            LierDonnees();

            if (bs_Engins.Count > 0)
                bs_Engins.Position = 0;
        }

        private List<Engin> ChargerEnginsParCaserne(int idCaserne)
        {
            List<Engin> liste = new List<Engin>();
            cx = Connexion.Connec;

            string query = @"SELECT codeTypeEngin|| ' ' ||numero as engin, dateReception, enMission, enPanne FROM Engin WHERE idCaserne = @id";
            using (SQLiteCommand cmd = new SQLiteCommand(query, cx))
            {
                cmd.Parameters.AddWithValue("@id", idCaserne);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(new Engin
                        {
                            EnginNom = reader["engin"].ToString(),
                            DateReception = reader["dateReception"].ToString(),
                            EnMission = Convert.ToBoolean(reader["enMission"]),
                            EnPanne = Convert.ToBoolean(reader["enPanne"])
                        });
                    }
                }
            }

            return liste;
        }

        private void LierDonnees()
        {
            lbl_EnginNom.DataBindings.Clear();
            lbl_DateReception.DataBindings.Clear();
            rdb_EnginEnMission.DataBindings.Clear();
            rdb_EnginEnPanne.DataBindings.Clear();

            lbl_EnginNom.DataBindings.Add("Text", bs_Engins, "EnginNom");
            lbl_DateReception.DataBindings.Add("Text", bs_Engins, "DateReception");
            rdb_EnginEnMission.DataBindings.Add("Checked", bs_Engins, "EnMission");
            rdb_EnginEnPanne.DataBindings.Add("Checked", bs_Engins, "EnPanne");

            string typeEngin = lbl_EnginNom.Text.ToString().Split(' ')[0];
            String chemin = "./Engins/" + typeEngin + ".png";
            pcb_Engin.Image = Image.FromFile(chemin) ;
            
        }
    }
}
