using Pinpon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fichePompier
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        private void btn_annuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_valider_Click(object sender, EventArgs e)
        {
            SQLiteConnection cx = Connexion.Connec;
            string sql = "select count(*) from Admin where login = @log and mdp = @motDePasse";
            SQLiteCommand cmd = new SQLiteCommand(sql, cx);
            cmd.Parameters.AddWithValue("@log", txt_username.Text);
            cmd.Parameters.AddWithValue("@motDePasse", txt_mdp.Text);
            int existe = cmd.ExecuteNonQuery();
            if (existe == 0)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txt_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '\t' || e.KeyChar == '\r')
            {
                txt_mdp.Focus();
            }
        }
        private void txt_mdp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btn_valider_Click(sender, e);
            }
        }

        private void btn_afficherMdp_Click(object sender, EventArgs e)
        {
            if (txt_mdp.PasswordChar == '\0')
                txt_mdp.PasswordChar = '*';
            else
                txt_mdp.PasswordChar = '\0';
        }
    }
}
