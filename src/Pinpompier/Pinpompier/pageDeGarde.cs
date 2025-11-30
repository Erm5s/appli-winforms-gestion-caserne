using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pinpompier
{
    internal class pageDeGarde
    {
        public void genererPageDeGarde(Panel panel)
        {
            
            Panel pnl_Accueil = new Panel
            {
                Size = new Size(1080, 760),
                Dock = DockStyle.Fill,
                BackgroundImage = Image.FromFile("./Divers/caserne.jpg"),
                BackgroundImageLayout = ImageLayout.Stretch,
                BackColor = Color.White
            };
            panel.Controls.Add(pnl_Accueil);

            Label lblTitre = new Label
            {
                Text = "Bienvenue dans l'application de gestion des pompiers ",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.DarkRed,
                Location = new Point((pnl_Accueil.Width - 1000) / 2, 200) // centré environ
            };
            pnl_Accueil.Controls.Add(lblTitre);
        }
    }
}
