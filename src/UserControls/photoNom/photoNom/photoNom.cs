using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace photoNom
{
    public partial class photoNom: UserControl
    {
        public photoNom()
        {
            InitializeComponent();
            pcbImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public Image Image
        {
            get { return pcbImage.Image; }
            set { pcbImage.Image = value; }
        }

        public PictureBoxSizeMode SizeMode
        {
            get { return pcbImage.SizeMode; }
            set { pcbImage.SizeMode = value; }
        }

        public string Texte
        {
            get { return lblTexte.Text; }
            set { lblTexte.Text = value; }
        }
    }
}
