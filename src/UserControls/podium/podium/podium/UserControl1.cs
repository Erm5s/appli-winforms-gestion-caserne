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

namespace podium
{
    public partial class podium : UserControl
    {
        string sql;
        SQLiteConnection cx;
        public podium()
        {
            InitializeComponent();
            sql = @"SELECT e.codeTypeEngin || ' ' || e.numero AS engin, 
                    (SELECT COUNT(*) FROM PartirAvec 
                    WHERE idCaserne = 4
                        AND codeTypeEngin = e.codeTypeEngin 
                        AND numeroEngin = e.numero) AS nbUtil 
                    FROM engin e 
                    GROUP BY engin
                    ORDER BY nbUtil DESC
                    LIMIT 3";
        }
        public podium(int idCaserne)
        {
            InitializeComponent();
            sql = string.Format(@"
                                SELECT 
                                    e.codeTypeEngin || ' ' || e.numero AS engin, 
                                    (
                                        SELECT COUNT(*) 
                                        FROM PartirAvec 
                                        WHERE idCaserne = {0}
                                          AND codeTypeEngin = e.codeTypeEngin 
                                          AND numeroEngin = e.numero
                                    ) AS nbUtil 
                                FROM engin e 
                                GROUP BY engin
                                ORDER BY nbUtil DESC
                                LIMIT 3", idCaserne);
        }
        public podium(string sql_)
        {
            InitializeComponent();
            sql = sql_;
        }

        private void podium_Load(object sender, EventArgs e)
        {
            
            cx = Connexion.Connec;
            SQLiteCommand cmd = new SQLiteCommand(sql, cx);
            int i = 0;
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read() && i<3)
                {
                    string nom = reader.IsDBNull(0) ? "" : reader.GetString(0);
                    int utilisation = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                    switch (i)
                    {
                        case 0:
                            lbl_premier.Text = nom;
                            lbl_utilisation_premier.Text= utilisation+" utilisations";
                            break;
                        case 1:
                            lbl_deuxieme.Text = nom;
                            lbl_utilisationDeuxieme.Text = utilisation + " utilisations";
                            break;
                        case 2:
                            lbl_troisieme.Text = nom;
                            lbl_utilisation_troisieme.Text = utilisation + " utilisations";
                            break;
                    }
                    i++;
                }
            }
            Connexion.FermerConnexion();
        }

        private void pnl_troisieme_MouseHover(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            int tag = int.Parse(p.Tag.ToString());

            int targetHeight = p.Height;
            switch (tag)
            {
                case 1: targetHeight = 150;lbl_premier.Visible = true; lbl_utilisation_premier.Visible = true; break;
                case 2: targetHeight = 120;lbl_deuxieme.Visible = true; lbl_utilisationDeuxieme.Visible = true; break;
                case 3: targetHeight = 100;lbl_troisieme.Visible = true; lbl_utilisation_troisieme.Visible = true; break;
                default: targetHeight = p.Height; break;
            }

            int initialTop = p.Top;
            int initialHeight = p.Height;

            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tag = new Tuple<Panel, int, int, int>(p, initialTop, initialHeight, targetHeight);

            timer.Tick += (s, args) =>
            {
                var t = (Tuple<Panel, int, int, int>)((Timer)s).Tag;
                Panel panel = t.Item1;
                int top = panel.Top;
                int height = panel.Height;
                int target = t.Item4;

                if (height < target)
                {
                    panel.Top -= 1;    // monter le panel
                    panel.Height += 1; // augmenter la hauteur
                }
                else
                {
                    ((Timer)s).Stop();
                    ((Timer)s).Dispose();
                }
            };

            timer.Start();
        }
        private void podium_MouseHover(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                switch(i)
                {
                    case 0:
                        pnl_troisieme_MouseHover(pnl_premier, e);
                        break;
                    case 1:
                        pnl_troisieme_MouseHover(pnl_deuxieme, e);
                        break;
                    case 2:
                        pnl_troisieme_MouseHover(pnl_troisieme, e);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
