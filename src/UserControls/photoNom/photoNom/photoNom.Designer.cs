namespace photoNom
{
    partial class photoNom
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pcbImage = new System.Windows.Forms.PictureBox();
            this.lblTexte = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(0, 0);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // pcbImage
            // 
            this.pcbImage.Location = new System.Drawing.Point(5, 7);
            this.pcbImage.Name = "pcbImage";
            this.pcbImage.Size = new System.Drawing.Size(55, 53);
            this.pcbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbImage.TabIndex = 1;
            this.pcbImage.TabStop = false;
            // 
            // lblTexte
            // 
            this.lblTexte.AutoSize = true;
            this.lblTexte.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexte.Location = new System.Drawing.Point(83, 24);
            this.lblTexte.Name = "lblTexte";
            this.lblTexte.Size = new System.Drawing.Size(59, 23);
            this.lblTexte.TabIndex = 2;
            this.lblTexte.Text = "label1";
            // 
            // photoNom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTexte);
            this.Controls.Add(this.pcbImage);
            this.Controls.Add(this.groupBox1);
            this.Name = "photoNom";
            this.Size = new System.Drawing.Size(548, 68);
            ((System.ComponentModel.ISupportInitialize)(this.pcbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pcbImage;
        private System.Windows.Forms.Label lblTexte;
    }
}
