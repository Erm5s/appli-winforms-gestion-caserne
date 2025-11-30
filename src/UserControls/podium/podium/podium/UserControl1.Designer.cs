namespace podium
{
    partial class podium
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_deuxieme = new System.Windows.Forms.Panel();
            this.pnl_premier = new System.Windows.Forms.Panel();
            this.pnl_troisieme = new System.Windows.Forms.Panel();
            this.lbl_premier = new System.Windows.Forms.Label();
            this.lbl_deuxieme = new System.Windows.Forms.Label();
            this.lbl_troisieme = new System.Windows.Forms.Label();
            this.lbl_utilisationDeuxieme = new System.Windows.Forms.Label();
            this.lbl_utilisation_premier = new System.Windows.Forms.Label();
            this.lbl_utilisation_troisieme = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnl_deuxieme
            // 
            this.pnl_deuxieme.BackColor = System.Drawing.Color.Silver;
            this.pnl_deuxieme.Location = new System.Drawing.Point(30, 200);
            this.pnl_deuxieme.Name = "pnl_deuxieme";
            this.pnl_deuxieme.Size = new System.Drawing.Size(110, 10);
            this.pnl_deuxieme.TabIndex = 0;
            this.pnl_deuxieme.Tag = "2";
            this.pnl_deuxieme.MouseHover += new System.EventHandler(this.pnl_troisieme_MouseHover);
            // 
            // pnl_premier
            // 
            this.pnl_premier.BackColor = System.Drawing.Color.Yellow;
            this.pnl_premier.Location = new System.Drawing.Point(140, 200);
            this.pnl_premier.Name = "pnl_premier";
            this.pnl_premier.Size = new System.Drawing.Size(110, 10);
            this.pnl_premier.TabIndex = 1;
            this.pnl_premier.Tag = "1";
            this.pnl_premier.MouseHover += new System.EventHandler(this.pnl_troisieme_MouseHover);
            // 
            // pnl_troisieme
            // 
            this.pnl_troisieme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pnl_troisieme.Location = new System.Drawing.Point(250, 200);
            this.pnl_troisieme.Name = "pnl_troisieme";
            this.pnl_troisieme.Size = new System.Drawing.Size(110, 10);
            this.pnl_troisieme.TabIndex = 2;
            this.pnl_troisieme.Tag = "3";
            this.pnl_troisieme.MouseHover += new System.EventHandler(this.pnl_troisieme_MouseHover);
            // 
            // lbl_premier
            // 
            this.lbl_premier.AutoSize = true;
            this.lbl_premier.Location = new System.Drawing.Point(167, 20);
            this.lbl_premier.Name = "lbl_premier";
            this.lbl_premier.Size = new System.Drawing.Size(65, 28);
            this.lbl_premier.TabIndex = 3;
            this.lbl_premier.Text = "label1";
            this.lbl_premier.Visible = false;
            // 
            // lbl_deuxieme
            // 
            this.lbl_deuxieme.AutoSize = true;
            this.lbl_deuxieme.Location = new System.Drawing.Point(44, 57);
            this.lbl_deuxieme.Name = "lbl_deuxieme";
            this.lbl_deuxieme.Size = new System.Drawing.Size(65, 28);
            this.lbl_deuxieme.TabIndex = 4;
            this.lbl_deuxieme.Text = "label1";
            this.lbl_deuxieme.Visible = false;
            // 
            // lbl_troisieme
            // 
            this.lbl_troisieme.AutoSize = true;
            this.lbl_troisieme.Location = new System.Drawing.Point(271, 79);
            this.lbl_troisieme.Name = "lbl_troisieme";
            this.lbl_troisieme.Size = new System.Drawing.Size(65, 28);
            this.lbl_troisieme.TabIndex = 5;
            this.lbl_troisieme.Text = "label1";
            this.lbl_troisieme.Visible = false;
            // 
            // lbl_utilisationDeuxieme
            // 
            this.lbl_utilisationDeuxieme.AutoSize = true;
            this.lbl_utilisationDeuxieme.Location = new System.Drawing.Point(33, 207);
            this.lbl_utilisationDeuxieme.Name = "lbl_utilisationDeuxieme";
            this.lbl_utilisationDeuxieme.Size = new System.Drawing.Size(65, 28);
            this.lbl_utilisationDeuxieme.TabIndex = 6;
            this.lbl_utilisationDeuxieme.Text = "label1";
            this.lbl_utilisationDeuxieme.Visible = false;
            // 
            // lbl_utilisation_premier
            // 
            this.lbl_utilisation_premier.AutoSize = true;
            this.lbl_utilisation_premier.Location = new System.Drawing.Point(146, 207);
            this.lbl_utilisation_premier.Name = "lbl_utilisation_premier";
            this.lbl_utilisation_premier.Size = new System.Drawing.Size(65, 28);
            this.lbl_utilisation_premier.TabIndex = 7;
            this.lbl_utilisation_premier.Text = "label1";
            this.lbl_utilisation_premier.Visible = false;
            // 
            // lbl_utilisation_troisieme
            // 
            this.lbl_utilisation_troisieme.AutoSize = true;
            this.lbl_utilisation_troisieme.Location = new System.Drawing.Point(256, 207);
            this.lbl_utilisation_troisieme.Name = "lbl_utilisation_troisieme";
            this.lbl_utilisation_troisieme.Size = new System.Drawing.Size(65, 28);
            this.lbl_utilisation_troisieme.TabIndex = 8;
            this.lbl_utilisation_troisieme.Text = "label1";
            this.lbl_utilisation_troisieme.Visible = false;
            // 
            // podium
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_utilisation_troisieme);
            this.Controls.Add(this.lbl_utilisation_premier);
            this.Controls.Add(this.lbl_utilisationDeuxieme);
            this.Controls.Add(this.lbl_troisieme);
            this.Controls.Add(this.lbl_deuxieme);
            this.Controls.Add(this.lbl_premier);
            this.Controls.Add(this.pnl_troisieme);
            this.Controls.Add(this.pnl_premier);
            this.Controls.Add(this.pnl_deuxieme);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "podium";
            this.Size = new System.Drawing.Size(390, 235);
            this.Load += new System.EventHandler(this.podium_Load);
            this.MouseHover += new System.EventHandler(this.podium_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_deuxieme;
        private System.Windows.Forms.Panel pnl_premier;
        private System.Windows.Forms.Panel pnl_troisieme;
        private System.Windows.Forms.Label lbl_premier;
        private System.Windows.Forms.Label lbl_deuxieme;
        private System.Windows.Forms.Label lbl_troisieme;
        private System.Windows.Forms.Label lbl_utilisationDeuxieme;
        private System.Windows.Forms.Label lbl_utilisation_premier;
        private System.Windows.Forms.Label lbl_utilisation_troisieme;
    }
}
