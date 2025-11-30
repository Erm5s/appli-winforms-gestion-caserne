namespace fichePompier
{
    partial class login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_login = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.lbl_mdp = new System.Windows.Forms.Label();
            this.btn_annuler = new System.Windows.Forms.Button();
            this.btn_valider = new System.Windows.Forms.Button();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_mdp = new System.Windows.Forms.TextBox();
            this.btn_afficherMdp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_login.Location = new System.Drawing.Point(83, 19);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(220, 45);
            this.lbl_login.TabIndex = 0;
            this.lbl_login.Text = "Se connecter";
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(3, 102);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(173, 28);
            this.lbl_username.TabIndex = 1;
            this.lbl_username.Text = "Nom d\'utilisateur :";
            // 
            // lbl_mdp
            // 
            this.lbl_mdp.AutoSize = true;
            this.lbl_mdp.Location = new System.Drawing.Point(8, 166);
            this.lbl_mdp.Name = "lbl_mdp";
            this.lbl_mdp.Size = new System.Drawing.Size(138, 28);
            this.lbl_mdp.TabIndex = 2;
            this.lbl_mdp.Text = "Mot de passe :";
            // 
            // btn_annuler
            // 
            this.btn_annuler.Location = new System.Drawing.Point(131, 255);
            this.btn_annuler.Name = "btn_annuler";
            this.btn_annuler.Size = new System.Drawing.Size(114, 39);
            this.btn_annuler.TabIndex = 3;
            this.btn_annuler.Text = "Annuler";
            this.btn_annuler.UseVisualStyleBackColor = true;
            this.btn_annuler.Click += new System.EventHandler(this.btn_annuler_Click);
            // 
            // btn_valider
            // 
            this.btn_valider.Location = new System.Drawing.Point(256, 255);
            this.btn_valider.Name = "btn_valider";
            this.btn_valider.Size = new System.Drawing.Size(114, 39);
            this.btn_valider.TabIndex = 4;
            this.btn_valider.Text = "Valider";
            this.btn_valider.UseVisualStyleBackColor = true;
            this.btn_valider.Click += new System.EventHandler(this.btn_valider_Click);
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(184, 102);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(185, 34);
            this.txt_username.TabIndex = 5;
            this.txt_username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_username_KeyPress);
            // 
            // txt_mdp
            // 
            this.txt_mdp.Location = new System.Drawing.Point(184, 163);
            this.txt_mdp.Name = "txt_mdp";
            this.txt_mdp.PasswordChar = '*';
            this.txt_mdp.Size = new System.Drawing.Size(185, 34);
            this.txt_mdp.TabIndex = 6;
            this.txt_mdp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_mdp_KeyPress);
            // 
            // btn_afficherMdp
            // 
            this.btn_afficherMdp.Image = global::fichePompier.Properties.Resources.oeil;
            this.btn_afficherMdp.Location = new System.Drawing.Point(376, 163);
            this.btn_afficherMdp.Name = "btn_afficherMdp";
            this.btn_afficherMdp.Size = new System.Drawing.Size(58, 34);
            this.btn_afficherMdp.TabIndex = 7;
            this.btn_afficherMdp.Text = "\r\n";
            this.btn_afficherMdp.UseVisualStyleBackColor = true;
            this.btn_afficherMdp.Click += new System.EventHandler(this.btn_afficherMdp_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 307);
            this.Controls.Add(this.btn_afficherMdp);
            this.Controls.Add(this.txt_mdp);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.btn_valider);
            this.Controls.Add(this.btn_annuler);
            this.Controls.Add(this.lbl_mdp);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.lbl_login);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "se connecter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Label lbl_mdp;
        private System.Windows.Forms.Button btn_annuler;
        private System.Windows.Forms.Button btn_valider;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_mdp;
        #endregion

        private System.Windows.Forms.Button btn_afficherMdp;
    }
}