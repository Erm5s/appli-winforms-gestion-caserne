using Pinpon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pinpompier
{
    public partial class Pinpompier : Form
    {
        private Panel pnlNav;
        private Panel pnlContainer;
        private Button activeButton = null;
        public Pinpompier()
        {
            InitializeComponent();
            this.Size = new Size(1080, 780); 
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pinpompier";
            InitUI();
        }

        private void InitUI()
        {
            pnlNav = new Panel();
            pnlNav.Dock = DockStyle.Top;
            pnlNav.Height = 50;
            pnlNav.BackColor = Color.LightGray;
            this.Controls.Add(pnlNav);

            pnlContainer = new Panel();
            pnlContainer.Dock = DockStyle.Fill;
            this.Controls.Add(pnlContainer);

            AddNavButton("Statistiques", (s, e) =>
            {
                pnlContainer.Controls.Clear();
                var st = new statistiques();
                st.genererStatistiques(pnlContainer); 
            });

            AddNavButton("Gestion du personnel", (s, e) =>
            {
                pnlContainer.Controls.Clear();
                var gp = new gestionPompier();
                gp.genererGestionPompier(pnlContainer);
            });

            AddNavButton("Gestion des engins", (s, e) =>
            {
                pnlContainer.Controls.Clear();
                var ge = new gestionEngin();
                ge.genererGestionEngin(pnlContainer);
            });

            AddNavButton("Nouvelle mission", (s, e) =>
            {
                pnlContainer.Controls.Clear();
                var gm = new nouvelleMission();
                gm.genererNouvelleMission(pnlContainer);
            });

            AddNavButton("Tableau de bord", (s, e) =>
            {
                pnlContainer.Controls.Clear();
                var pa = new tableauDeBord();
                pa.genererTableauDeBord(pnlContainer);

            });
            

            var defaultPage = new pageDeGarde();
            defaultPage.genererPageDeGarde(pnlContainer);
        }

        private void AddNavButton(string text, EventHandler onClick)
        {
            var btn = new Button
            {
                Text = text,
                Width = 213,
                Height = 60,
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Left,
                BackColor = Color.LightCoral,
            };

            btn.Click += (sender, e) =>
            {
                SetActiveButton(btn);
                onClick(sender, e);
            };

            pnlNav.Controls.Add(btn);
        }

        private void SetActiveButton(Button btn)
        {
            if (activeButton != null)
                activeButton.BackColor = Color.LightCoral;

            activeButton = btn;
            activeButton.BackColor = Color.Red;
        }

        private Control CreatePlaceholder(string title)
        {
            return new Label
            {
                Text = title,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 20, FontStyle.Bold)
            };
        }

        private void Pinpompier_Load(object sender, EventArgs e)
        {
            chargementDs();   
        }


        private void chargementDs()
        {
            SQLiteConnection connec = Connexion.Connec;

            DataTable schemaTable = connec.GetSchema("Tables");
            string requete;

            foreach (DataRow ligne in schemaTable.Rows)
            {
                string nomTable = ligne["TABLE_NAME"].ToString();

                requete = "SELECT * FROM " + nomTable;
                SQLiteDataAdapter da = new SQLiteDataAdapter(requete, connec);

                DataTable dtBase = new DataTable();
                dtBase.TableName = nomTable;

                da.Fill(dtBase);
                MesDatas.DsGlobal.Tables.Add(dtBase);
            }
            connec.Close();
        }
    }
}
