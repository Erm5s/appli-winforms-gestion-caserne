namespace tempUtilisation
{
    partial class tempUtilisationEngin
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
            this.pnl_global = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnl_global
            // 
            this.pnl_global.AutoScroll = true;
            this.pnl_global.Location = new System.Drawing.Point(0, 0);
            this.pnl_global.Name = "pnl_global";
            this.pnl_global.Size = new System.Drawing.Size(445, 200);
            this.pnl_global.TabIndex = 0;
            this.pnl_global.MouseEnter += new System.EventHandler(this.UserControl1_MouseEnter);
            // 
            // tempUtilisationEngin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_global);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "tempUtilisationEngin";
            this.Size = new System.Drawing.Size(445, 200);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.MouseEnter += new System.EventHandler(this.UserControl1_MouseEnter);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_global;
    }
}
