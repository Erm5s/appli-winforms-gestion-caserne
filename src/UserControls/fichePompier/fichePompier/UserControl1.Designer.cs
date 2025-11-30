namespace fichePompier
{
    partial class fichePompier
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
            this.tct_fichePompier = new System.Windows.Forms.TabControl();
            this.pag_info = new System.Windows.Forms.TabPage();
            this.pnl_infoSup = new System.Windows.Forms.Panel();
            this.grp_affectationPasse = new System.Windows.Forms.GroupBox();
            this.lsb_affectation = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsb_habillitation = new System.Windows.Forms.ListBox();
            this.btn_infoSup = new System.Windows.Forms.Button();
            this.pnl_apercu = new System.Windows.Forms.Panel();
            this.pnl_conge = new System.Windows.Forms.Panel();
            this.rdb_conge = new System.Windows.Forms.RadioButton();
            this.grb_carrière = new System.Windows.Forms.GroupBox();
            this.btn_valider = new System.Windows.Forms.Button();
            this.lbl_bip = new System.Windows.Forms.Label();
            this.lbl_tel = new System.Windows.Forms.Label();
            this.cbo_grade = new System.Windows.Forms.ComboBox();
            this.lbl_grade = new System.Windows.Forms.Label();
            this.pcb_grade = new System.Windows.Forms.PictureBox();
            this.rdb_volontaire = new System.Windows.Forms.RadioButton();
            this.rdb_pro = new System.Windows.Forms.RadioButton();
            this.lbl_dateEmbauche = new System.Windows.Forms.Label();
            this.lbl_sexe = new System.Windows.Forms.Label();
            this.lbl_dateNaissance = new System.Windows.Forms.Label();
            this.lbl_prenom = new System.Windows.Forms.Label();
            this.lbl_nom = new System.Windows.Forms.Label();
            this.lbl_matricule = new System.Windows.Forms.Label();
            this.pag_modif = new System.Windows.Forms.TabPage();
            this.lbl_habillitation = new System.Windows.Forms.Label();
            this.chb_conge = new System.Windows.Forms.CheckBox();
            this.btn_maj = new System.Windows.Forms.Button();
            this.clb_habillitation = new System.Windows.Forms.CheckedListBox();
            this.cbo_affectation = new System.Windows.Forms.ComboBox();
            this.lbl_caserneRattachement = new System.Windows.Forms.Label();
            this.pag_vide = new System.Windows.Forms.TabPage();
            this.pag_Nouveau = new System.Windows.Forms.TabPage();
            this.cbo_nouvCaserne = new System.Windows.Forms.ComboBox();
            this.cbo_nouvGrade = new System.Windows.Forms.ComboBox();
            this.txt_nouvTel = new System.Windows.Forms.TextBox();
            this.txt_nouvPrenom = new System.Windows.Forms.TextBox();
            this.txt_nouvNom = new System.Windows.Forms.TextBox();
            this.btn_nouvCreer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.clb_nouvHabillitation = new System.Windows.Forms.CheckedListBox();
            this.lbl_nouvCaserne = new System.Windows.Forms.Label();
            this.lbl_nouvGrade = new System.Windows.Forms.Label();
            this.lbl_nouvTel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdb_nouvVolontaire = new System.Windows.Forms.RadioButton();
            this.rdb_nouvPro = new System.Windows.Forms.RadioButton();
            this.dtp_dateNaissance = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_sexe = new System.Windows.Forms.Panel();
            this.rdb_femme = new System.Windows.Forms.RadioButton();
            this.rdb_homme = new System.Windows.Forms.RadioButton();
            this.lbl_nouvSexe = new System.Windows.Forms.Label();
            this.lbl_nouvPrenom = new System.Windows.Forms.Label();
            this.lbl_nouvNom = new System.Windows.Forms.Label();
            this.tct_fichePompier.SuspendLayout();
            this.pag_info.SuspendLayout();
            this.pnl_infoSup.SuspendLayout();
            this.grp_affectationPasse.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnl_apercu.SuspendLayout();
            this.pnl_conge.SuspendLayout();
            this.grb_carrière.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_grade)).BeginInit();
            this.pag_modif.SuspendLayout();
            this.pag_Nouveau.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_sexe.SuspendLayout();
            this.SuspendLayout();
            // 
            // tct_fichePompier
            // 
            this.tct_fichePompier.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tct_fichePompier.Controls.Add(this.pag_info);
            this.tct_fichePompier.Controls.Add(this.pag_modif);
            this.tct_fichePompier.Controls.Add(this.pag_vide);
            this.tct_fichePompier.Controls.Add(this.pag_Nouveau);
            this.tct_fichePompier.Location = new System.Drawing.Point(0, 0);
            this.tct_fichePompier.MaximumSize = new System.Drawing.Size(720, 700);
            this.tct_fichePompier.Name = "tct_fichePompier";
            this.tct_fichePompier.SelectedIndex = 0;
            this.tct_fichePompier.Size = new System.Drawing.Size(720, 700);
            this.tct_fichePompier.TabIndex = 1;
            this.tct_fichePompier.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tct_fichePompier_Selecting);
            // 
            // pag_info
            // 
            this.pag_info.Controls.Add(this.pnl_infoSup);
            this.pag_info.Controls.Add(this.btn_infoSup);
            this.pag_info.Controls.Add(this.pnl_apercu);
            this.pag_info.Location = new System.Drawing.Point(4, 40);
            this.pag_info.Name = "pag_info";
            this.pag_info.Padding = new System.Windows.Forms.Padding(3);
            this.pag_info.Size = new System.Drawing.Size(712, 656);
            this.pag_info.TabIndex = 0;
            this.pag_info.Text = "Information";
            this.pag_info.UseVisualStyleBackColor = true;
            // 
            // pnl_infoSup
            // 
            this.pnl_infoSup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_infoSup.Controls.Add(this.grp_affectationPasse);
            this.pnl_infoSup.Controls.Add(this.groupBox1);
            this.pnl_infoSup.Location = new System.Drawing.Point(0, 417);
            this.pnl_infoSup.Name = "pnl_infoSup";
            this.pnl_infoSup.Size = new System.Drawing.Size(710, 238);
            this.pnl_infoSup.TabIndex = 3;
            this.pnl_infoSup.Visible = false;
            // 
            // grp_affectationPasse
            // 
            this.grp_affectationPasse.Controls.Add(this.lsb_affectation);
            this.grp_affectationPasse.Location = new System.Drawing.Point(21, 113);
            this.grp_affectationPasse.Name = "grp_affectationPasse";
            this.grp_affectationPasse.Size = new System.Drawing.Size(652, 111);
            this.grp_affectationPasse.TabIndex = 1;
            this.grp_affectationPasse.TabStop = false;
            this.grp_affectationPasse.Text = "Affectations passées";
            // 
            // lsb_affectation
            // 
            this.lsb_affectation.FormattingEnabled = true;
            this.lsb_affectation.ItemHeight = 28;
            this.lsb_affectation.Location = new System.Drawing.Point(7, 34);
            this.lsb_affectation.Name = "lsb_affectation";
            this.lsb_affectation.Size = new System.Drawing.Size(639, 60);
            this.lsb_affectation.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsb_habillitation);
            this.groupBox1.Location = new System.Drawing.Point(21, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Habillitation";
            // 
            // lsb_habillitation
            // 
            this.lsb_habillitation.FormattingEnabled = true;
            this.lsb_habillitation.ItemHeight = 28;
            this.lsb_habillitation.Location = new System.Drawing.Point(7, 34);
            this.lsb_habillitation.Name = "lsb_habillitation";
            this.lsb_habillitation.Size = new System.Drawing.Size(639, 60);
            this.lsb_habillitation.TabIndex = 0;
            // 
            // btn_infoSup
            // 
            this.btn_infoSup.Location = new System.Drawing.Point(464, 417);
            this.btn_infoSup.Name = "btn_infoSup";
            this.btn_infoSup.Size = new System.Drawing.Size(196, 36);
            this.btn_infoSup.TabIndex = 2;
            this.btn_infoSup.Text = "Plus d\'informations";
            this.btn_infoSup.UseVisualStyleBackColor = true;
            this.btn_infoSup.Click += new System.EventHandler(this.btn_infoSup_Click);
            // 
            // pnl_apercu
            // 
            this.pnl_apercu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_apercu.Controls.Add(this.pnl_conge);
            this.pnl_apercu.Controls.Add(this.grb_carrière);
            this.pnl_apercu.Controls.Add(this.pcb_grade);
            this.pnl_apercu.Controls.Add(this.rdb_volontaire);
            this.pnl_apercu.Controls.Add(this.rdb_pro);
            this.pnl_apercu.Controls.Add(this.lbl_dateEmbauche);
            this.pnl_apercu.Controls.Add(this.lbl_sexe);
            this.pnl_apercu.Controls.Add(this.lbl_dateNaissance);
            this.pnl_apercu.Controls.Add(this.lbl_prenom);
            this.pnl_apercu.Controls.Add(this.lbl_nom);
            this.pnl_apercu.Controls.Add(this.lbl_matricule);
            this.pnl_apercu.Location = new System.Drawing.Point(0, 0);
            this.pnl_apercu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl_apercu.Name = "pnl_apercu";
            this.pnl_apercu.Size = new System.Drawing.Size(710, 409);
            this.pnl_apercu.TabIndex = 1;
            // 
            // pnl_conge
            // 
            this.pnl_conge.Controls.Add(this.rdb_conge);
            this.pnl_conge.Location = new System.Drawing.Point(21, 251);
            this.pnl_conge.Name = "pnl_conge";
            this.pnl_conge.Size = new System.Drawing.Size(116, 34);
            this.pnl_conge.TabIndex = 10;
            // 
            // rdb_conge
            // 
            this.rdb_conge.AutoSize = true;
            this.rdb_conge.Enabled = false;
            this.rdb_conge.Location = new System.Drawing.Point(3, -1);
            this.rdb_conge.Name = "rdb_conge";
            this.rdb_conge.Size = new System.Drawing.Size(113, 32);
            this.rdb_conge.TabIndex = 0;
            this.rdb_conge.TabStop = true;
            this.rdb_conge.Text = "En congé";
            this.rdb_conge.UseVisualStyleBackColor = true;
            // 
            // grb_carrière
            // 
            this.grb_carrière.Controls.Add(this.btn_valider);
            this.grb_carrière.Controls.Add(this.lbl_bip);
            this.grb_carrière.Controls.Add(this.lbl_tel);
            this.grb_carrière.Controls.Add(this.cbo_grade);
            this.grb_carrière.Controls.Add(this.lbl_grade);
            this.grb_carrière.Location = new System.Drawing.Point(131, 281);
            this.grb_carrière.Name = "grb_carrière";
            this.grb_carrière.Size = new System.Drawing.Size(437, 114);
            this.grb_carrière.TabIndex = 9;
            this.grb_carrière.TabStop = false;
            this.grb_carrière.Text = "Carrière";
            // 
            // btn_valider
            // 
            this.btn_valider.Location = new System.Drawing.Point(316, 38);
            this.btn_valider.Name = "btn_valider";
            this.btn_valider.Size = new System.Drawing.Size(104, 33);
            this.btn_valider.TabIndex = 4;
            this.btn_valider.Text = "Valider";
            this.btn_valider.UseVisualStyleBackColor = true;
            this.btn_valider.Visible = false;
            this.btn_valider.Click += new System.EventHandler(this.btn_valider_Click);
            // 
            // lbl_bip
            // 
            this.lbl_bip.AutoSize = true;
            this.lbl_bip.Location = new System.Drawing.Point(221, 74);
            this.lbl_bip.Name = "lbl_bip";
            this.lbl_bip.Size = new System.Drawing.Size(54, 28);
            this.lbl_bip.TabIndex = 3;
            this.lbl_bip.Text = "Bip : ";
            // 
            // lbl_tel
            // 
            this.lbl_tel.AutoSize = true;
            this.lbl_tel.Location = new System.Drawing.Point(16, 74);
            this.lbl_tel.Name = "lbl_tel";
            this.lbl_tel.Size = new System.Drawing.Size(115, 28);
            this.lbl_tel.TabIndex = 2;
            this.lbl_tel.Text = "Téléphone : ";
            // 
            // cbo_grade
            // 
            this.cbo_grade.FormattingEnabled = true;
            this.cbo_grade.Location = new System.Drawing.Point(97, 37);
            this.cbo_grade.Name = "cbo_grade";
            this.cbo_grade.Size = new System.Drawing.Size(149, 36);
            this.cbo_grade.TabIndex = 1;
            this.cbo_grade.Click += new System.EventHandler(this.cbo_grade_Click);
            // 
            // lbl_grade
            // 
            this.lbl_grade.AutoSize = true;
            this.lbl_grade.Location = new System.Drawing.Point(16, 34);
            this.lbl_grade.Name = "lbl_grade";
            this.lbl_grade.Size = new System.Drawing.Size(74, 28);
            this.lbl_grade.TabIndex = 0;
            this.lbl_grade.Text = "Grade :";
            // 
            // pcb_grade
            // 
            this.pcb_grade.Location = new System.Drawing.Point(511, 14);
            this.pcb_grade.Name = "pcb_grade";
            this.pcb_grade.Size = new System.Drawing.Size(181, 169);
            this.pcb_grade.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcb_grade.TabIndex = 8;
            this.pcb_grade.TabStop = false;
            // 
            // rdb_volontaire
            // 
            this.rdb_volontaire.AutoSize = true;
            this.rdb_volontaire.Enabled = false;
            this.rdb_volontaire.Location = new System.Drawing.Point(336, 176);
            this.rdb_volontaire.Name = "rdb_volontaire";
            this.rdb_volontaire.Size = new System.Drawing.Size(123, 32);
            this.rdb_volontaire.TabIndex = 7;
            this.rdb_volontaire.TabStop = true;
            this.rdb_volontaire.Text = "Volontaire";
            this.rdb_volontaire.UseVisualStyleBackColor = true;
            // 
            // rdb_pro
            // 
            this.rdb_pro.AutoSize = true;
            this.rdb_pro.Enabled = false;
            this.rdb_pro.Location = new System.Drawing.Point(133, 176);
            this.rdb_pro.Name = "rdb_pro";
            this.rdb_pro.Size = new System.Drawing.Size(149, 32);
            this.rdb_pro.TabIndex = 6;
            this.rdb_pro.TabStop = true;
            this.rdb_pro.Text = "Professionnel";
            this.rdb_pro.UseVisualStyleBackColor = true;
            // 
            // lbl_dateEmbauche
            // 
            this.lbl_dateEmbauche.AutoSize = true;
            this.lbl_dateEmbauche.Location = new System.Drawing.Point(21, 219);
            this.lbl_dateEmbauche.Name = "lbl_dateEmbauche";
            this.lbl_dateEmbauche.Size = new System.Drawing.Size(179, 28);
            this.lbl_dateEmbauche.TabIndex = 5;
            this.lbl_dateEmbauche.Text = "Date d\'embauche : ";
            // 
            // lbl_sexe
            // 
            this.lbl_sexe.AutoSize = true;
            this.lbl_sexe.Location = new System.Drawing.Point(21, 112);
            this.lbl_sexe.Name = "lbl_sexe";
            this.lbl_sexe.Size = new System.Drawing.Size(66, 28);
            this.lbl_sexe.TabIndex = 4;
            this.lbl_sexe.Text = "Sexe : ";
            // 
            // lbl_dateNaissance
            // 
            this.lbl_dateNaissance.AutoSize = true;
            this.lbl_dateNaissance.Location = new System.Drawing.Point(21, 139);
            this.lbl_dateNaissance.Name = "lbl_dateNaissance";
            this.lbl_dateNaissance.Size = new System.Drawing.Size(184, 28);
            this.lbl_dateNaissance.TabIndex = 3;
            this.lbl_dateNaissance.Text = "Date de naisssance :";
            // 
            // lbl_prenom
            // 
            this.lbl_prenom.AutoSize = true;
            this.lbl_prenom.Location = new System.Drawing.Point(21, 84);
            this.lbl_prenom.Name = "lbl_prenom";
            this.lbl_prenom.Size = new System.Drawing.Size(94, 28);
            this.lbl_prenom.TabIndex = 2;
            this.lbl_prenom.Text = "Prénom : ";
            // 
            // lbl_nom
            // 
            this.lbl_nom.AutoSize = true;
            this.lbl_nom.Location = new System.Drawing.Point(21, 56);
            this.lbl_nom.Name = "lbl_nom";
            this.lbl_nom.Size = new System.Drawing.Size(70, 28);
            this.lbl_nom.TabIndex = 1;
            this.lbl_nom.Text = "Nom : ";
            // 
            // lbl_matricule
            // 
            this.lbl_matricule.AutoSize = true;
            this.lbl_matricule.Location = new System.Drawing.Point(199, 14);
            this.lbl_matricule.Name = "lbl_matricule";
            this.lbl_matricule.Size = new System.Drawing.Size(108, 28);
            this.lbl_matricule.TabIndex = 0;
            this.lbl_matricule.Text = "Matricule : ";
            // 
            // pag_modif
            // 
            this.pag_modif.Controls.Add(this.lbl_habillitation);
            this.pag_modif.Controls.Add(this.chb_conge);
            this.pag_modif.Controls.Add(this.btn_maj);
            this.pag_modif.Controls.Add(this.clb_habillitation);
            this.pag_modif.Controls.Add(this.cbo_affectation);
            this.pag_modif.Controls.Add(this.lbl_caserneRattachement);
            this.pag_modif.Location = new System.Drawing.Point(4, 40);
            this.pag_modif.Name = "pag_modif";
            this.pag_modif.Padding = new System.Windows.Forms.Padding(3);
            this.pag_modif.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pag_modif.Size = new System.Drawing.Size(712, 656);
            this.pag_modif.TabIndex = 1;
            this.pag_modif.Text = "Modifier";
            this.pag_modif.UseVisualStyleBackColor = true;
            // 
            // lbl_habillitation
            // 
            this.lbl_habillitation.AutoSize = true;
            this.lbl_habillitation.Location = new System.Drawing.Point(11, 156);
            this.lbl_habillitation.Name = "lbl_habillitation";
            this.lbl_habillitation.Size = new System.Drawing.Size(196, 28);
            this.lbl_habillitation.TabIndex = 5;
            this.lbl_habillitation.Text = "Ajouter habillitation :";
            // 
            // chb_conge
            // 
            this.chb_conge.AutoSize = true;
            this.chb_conge.Location = new System.Drawing.Point(11, 479);
            this.chb_conge.Name = "chb_conge";
            this.chb_conge.Size = new System.Drawing.Size(114, 32);
            this.chb_conge.TabIndex = 4;
            this.chb_conge.Text = "En congé";
            this.chb_conge.UseVisualStyleBackColor = true;
            this.chb_conge.CheckedChanged += new System.EventHandler(this.chb_conge_CheckedChanged);
            // 
            // btn_maj
            // 
            this.btn_maj.Location = new System.Drawing.Point(439, 566);
            this.btn_maj.Name = "btn_maj";
            this.btn_maj.Size = new System.Drawing.Size(236, 57);
            this.btn_maj.TabIndex = 3;
            this.btn_maj.Text = "Mettre a jour";
            this.btn_maj.UseVisualStyleBackColor = true;
            this.btn_maj.Visible = false;
            this.btn_maj.Click += new System.EventHandler(this.btn_maj_Click);
            // 
            // clb_habillitation
            // 
            this.clb_habillitation.FormattingEnabled = true;
            this.clb_habillitation.Location = new System.Drawing.Point(128, 190);
            this.clb_habillitation.Name = "clb_habillitation";
            this.clb_habillitation.Size = new System.Drawing.Size(419, 265);
            this.clb_habillitation.TabIndex = 2;
            this.clb_habillitation.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clb_habillitation_ItemCheck);
            // 
            // cbo_affectation
            // 
            this.cbo_affectation.FormattingEnabled = true;
            this.cbo_affectation.Location = new System.Drawing.Point(262, 83);
            this.cbo_affectation.Name = "cbo_affectation";
            this.cbo_affectation.Size = new System.Drawing.Size(222, 36);
            this.cbo_affectation.TabIndex = 1;
            this.cbo_affectation.SelectionChangeCommitted += new System.EventHandler(this.cbo_affectation_SelectionChangeCommitted);
            // 
            // lbl_caserneRattachement
            // 
            this.lbl_caserneRattachement.AutoSize = true;
            this.lbl_caserneRattachement.Location = new System.Drawing.Point(6, 83);
            this.lbl_caserneRattachement.Name = "lbl_caserneRattachement";
            this.lbl_caserneRattachement.Size = new System.Drawing.Size(237, 28);
            this.lbl_caserneRattachement.TabIndex = 0;
            this.lbl_caserneRattachement.Text = "Caserne de rattachement :";
            // 
            // pag_vide
            // 
            this.pag_vide.Location = new System.Drawing.Point(4, 40);
            this.pag_vide.Name = "pag_vide";
            this.pag_vide.Size = new System.Drawing.Size(712, 656);
            this.pag_vide.TabIndex = 3;
            this.pag_vide.Text = " ";
            this.pag_vide.UseVisualStyleBackColor = true;
            // 
            // pag_Nouveau
            // 
            this.pag_Nouveau.Controls.Add(this.cbo_nouvCaserne);
            this.pag_Nouveau.Controls.Add(this.cbo_nouvGrade);
            this.pag_Nouveau.Controls.Add(this.txt_nouvTel);
            this.pag_Nouveau.Controls.Add(this.txt_nouvPrenom);
            this.pag_Nouveau.Controls.Add(this.txt_nouvNom);
            this.pag_Nouveau.Controls.Add(this.btn_nouvCreer);
            this.pag_Nouveau.Controls.Add(this.label2);
            this.pag_Nouveau.Controls.Add(this.clb_nouvHabillitation);
            this.pag_Nouveau.Controls.Add(this.lbl_nouvCaserne);
            this.pag_Nouveau.Controls.Add(this.lbl_nouvGrade);
            this.pag_Nouveau.Controls.Add(this.lbl_nouvTel);
            this.pag_Nouveau.Controls.Add(this.panel1);
            this.pag_Nouveau.Controls.Add(this.dtp_dateNaissance);
            this.pag_Nouveau.Controls.Add(this.label1);
            this.pag_Nouveau.Controls.Add(this.pnl_sexe);
            this.pag_Nouveau.Controls.Add(this.lbl_nouvSexe);
            this.pag_Nouveau.Controls.Add(this.lbl_nouvPrenom);
            this.pag_Nouveau.Controls.Add(this.lbl_nouvNom);
            this.pag_Nouveau.Location = new System.Drawing.Point(4, 40);
            this.pag_Nouveau.Name = "pag_Nouveau";
            this.pag_Nouveau.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pag_Nouveau.Size = new System.Drawing.Size(712, 656);
            this.pag_Nouveau.TabIndex = 2;
            this.pag_Nouveau.Text = "Nouveau";
            this.pag_Nouveau.UseVisualStyleBackColor = true;
            // 
            // cbo_nouvCaserne
            // 
            this.cbo_nouvCaserne.FormattingEnabled = true;
            this.cbo_nouvCaserne.Location = new System.Drawing.Point(133, 368);
            this.cbo_nouvCaserne.Name = "cbo_nouvCaserne";
            this.cbo_nouvCaserne.Size = new System.Drawing.Size(260, 36);
            this.cbo_nouvCaserne.TabIndex = 18;
            // 
            // cbo_nouvGrade
            // 
            this.cbo_nouvGrade.FormattingEnabled = true;
            this.cbo_nouvGrade.Location = new System.Drawing.Point(133, 323);
            this.cbo_nouvGrade.Name = "cbo_nouvGrade";
            this.cbo_nouvGrade.Size = new System.Drawing.Size(260, 36);
            this.cbo_nouvGrade.TabIndex = 17;
            // 
            // txt_nouvTel
            // 
            this.txt_nouvTel.Location = new System.Drawing.Point(140, 276);
            this.txt_nouvTel.MaxLength = 10;
            this.txt_nouvTel.Name = "txt_nouvTel";
            this.txt_nouvTel.Size = new System.Drawing.Size(234, 34);
            this.txt_nouvTel.TabIndex = 16;
            this.txt_nouvTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_nouvTel_KeyPress);
            // 
            // txt_nouvPrenom
            // 
            this.txt_nouvPrenom.Location = new System.Drawing.Point(133, 55);
            this.txt_nouvPrenom.Name = "txt_nouvPrenom";
            this.txt_nouvPrenom.Size = new System.Drawing.Size(241, 34);
            this.txt_nouvPrenom.TabIndex = 15;
            // 
            // txt_nouvNom
            // 
            this.txt_nouvNom.Location = new System.Drawing.Point(135, 9);
            this.txt_nouvNom.Name = "txt_nouvNom";
            this.txt_nouvNom.Size = new System.Drawing.Size(239, 34);
            this.txt_nouvNom.TabIndex = 14;
            // 
            // btn_nouvCreer
            // 
            this.btn_nouvCreer.Location = new System.Drawing.Point(550, 601);
            this.btn_nouvCreer.Name = "btn_nouvCreer";
            this.btn_nouvCreer.Size = new System.Drawing.Size(149, 42);
            this.btn_nouvCreer.TabIndex = 13;
            this.btn_nouvCreer.Text = "Créer";
            this.btn_nouvCreer.UseVisualStyleBackColor = true;
            this.btn_nouvCreer.Click += new System.EventHandler(this.btn_nouvCreer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 28);
            this.label2.TabIndex = 12;
            this.label2.Text = "Habillitations :";
            // 
            // clb_nouvHabillitation
            // 
            this.clb_nouvHabillitation.FormattingEnabled = true;
            this.clb_nouvHabillitation.Location = new System.Drawing.Point(116, 442);
            this.clb_nouvHabillitation.Name = "clb_nouvHabillitation";
            this.clb_nouvHabillitation.Size = new System.Drawing.Size(395, 149);
            this.clb_nouvHabillitation.TabIndex = 11;
            // 
            // lbl_nouvCaserne
            // 
            this.lbl_nouvCaserne.AutoSize = true;
            this.lbl_nouvCaserne.Location = new System.Drawing.Point(24, 371);
            this.lbl_nouvCaserne.Name = "lbl_nouvCaserne";
            this.lbl_nouvCaserne.Size = new System.Drawing.Size(89, 28);
            this.lbl_nouvCaserne.TabIndex = 10;
            this.lbl_nouvCaserne.Text = "Caserne :";
            // 
            // lbl_nouvGrade
            // 
            this.lbl_nouvGrade.AutoSize = true;
            this.lbl_nouvGrade.Location = new System.Drawing.Point(24, 326);
            this.lbl_nouvGrade.Name = "lbl_nouvGrade";
            this.lbl_nouvGrade.Size = new System.Drawing.Size(74, 28);
            this.lbl_nouvGrade.TabIndex = 9;
            this.lbl_nouvGrade.Text = "Grade :";
            // 
            // lbl_nouvTel
            // 
            this.lbl_nouvTel.AutoSize = true;
            this.lbl_nouvTel.Location = new System.Drawing.Point(24, 279);
            this.lbl_nouvTel.Name = "lbl_nouvTel";
            this.lbl_nouvTel.Size = new System.Drawing.Size(110, 28);
            this.lbl_nouvTel.TabIndex = 8;
            this.lbl_nouvTel.Text = "Télephone :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdb_nouvVolontaire);
            this.panel1.Controls.Add(this.rdb_nouvPro);
            this.panel1.Location = new System.Drawing.Point(116, 207);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 41);
            this.panel1.TabIndex = 7;
            // 
            // rdb_nouvVolontaire
            // 
            this.rdb_nouvVolontaire.AutoSize = true;
            this.rdb_nouvVolontaire.Location = new System.Drawing.Point(197, 3);
            this.rdb_nouvVolontaire.Name = "rdb_nouvVolontaire";
            this.rdb_nouvVolontaire.Size = new System.Drawing.Size(123, 32);
            this.rdb_nouvVolontaire.TabIndex = 1;
            this.rdb_nouvVolontaire.TabStop = true;
            this.rdb_nouvVolontaire.Text = "Volontaire";
            this.rdb_nouvVolontaire.UseVisualStyleBackColor = true;
            // 
            // rdb_nouvPro
            // 
            this.rdb_nouvPro.AutoSize = true;
            this.rdb_nouvPro.Location = new System.Drawing.Point(19, 3);
            this.rdb_nouvPro.Name = "rdb_nouvPro";
            this.rdb_nouvPro.Size = new System.Drawing.Size(149, 32);
            this.rdb_nouvPro.TabIndex = 0;
            this.rdb_nouvPro.TabStop = true;
            this.rdb_nouvPro.Text = "Professionnel";
            this.rdb_nouvPro.UseVisualStyleBackColor = true;
            // 
            // dtp_dateNaissance
            // 
            this.dtp_dateNaissance.Location = new System.Drawing.Point(210, 148);
            this.dtp_dateNaissance.Name = "dtp_dateNaissance";
            this.dtp_dateNaissance.Size = new System.Drawing.Size(291, 34);
            this.dtp_dateNaissance.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "Date de naissance :";
            // 
            // pnl_sexe
            // 
            this.pnl_sexe.Controls.Add(this.rdb_femme);
            this.pnl_sexe.Controls.Add(this.rdb_homme);
            this.pnl_sexe.Location = new System.Drawing.Point(116, 102);
            this.pnl_sexe.Name = "pnl_sexe";
            this.pnl_sexe.Size = new System.Drawing.Size(385, 27);
            this.pnl_sexe.TabIndex = 3;
            // 
            // rdb_femme
            // 
            this.rdb_femme.AutoSize = true;
            this.rdb_femme.Location = new System.Drawing.Point(197, -1);
            this.rdb_femme.Name = "rdb_femme";
            this.rdb_femme.Size = new System.Drawing.Size(97, 32);
            this.rdb_femme.TabIndex = 1;
            this.rdb_femme.TabStop = true;
            this.rdb_femme.Text = "Femme";
            this.rdb_femme.UseVisualStyleBackColor = true;
            // 
            // rdb_homme
            // 
            this.rdb_homme.AutoSize = true;
            this.rdb_homme.Location = new System.Drawing.Point(19, -1);
            this.rdb_homme.Name = "rdb_homme";
            this.rdb_homme.Size = new System.Drawing.Size(103, 32);
            this.rdb_homme.TabIndex = 0;
            this.rdb_homme.TabStop = true;
            this.rdb_homme.Text = "Homme";
            this.rdb_homme.UseVisualStyleBackColor = true;
            // 
            // lbl_nouvSexe
            // 
            this.lbl_nouvSexe.AutoSize = true;
            this.lbl_nouvSexe.Location = new System.Drawing.Point(24, 101);
            this.lbl_nouvSexe.Name = "lbl_nouvSexe";
            this.lbl_nouvSexe.Size = new System.Drawing.Size(61, 28);
            this.lbl_nouvSexe.TabIndex = 2;
            this.lbl_nouvSexe.Text = "Sexe :";
            // 
            // lbl_nouvPrenom
            // 
            this.lbl_nouvPrenom.AutoSize = true;
            this.lbl_nouvPrenom.Location = new System.Drawing.Point(24, 58);
            this.lbl_nouvPrenom.Name = "lbl_nouvPrenom";
            this.lbl_nouvPrenom.Size = new System.Drawing.Size(89, 28);
            this.lbl_nouvPrenom.TabIndex = 1;
            this.lbl_nouvPrenom.Text = "Prenom :";
            // 
            // lbl_nouvNom
            // 
            this.lbl_nouvNom.AutoSize = true;
            this.lbl_nouvNom.Location = new System.Drawing.Point(24, 12);
            this.lbl_nouvNom.Name = "lbl_nouvNom";
            this.lbl_nouvNom.Size = new System.Drawing.Size(65, 28);
            this.lbl_nouvNom.TabIndex = 0;
            this.lbl_nouvNom.Text = "Nom :";
            // 
            // fichePompier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tct_fichePompier);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fichePompier";
            this.Size = new System.Drawing.Size(720, 700);
            this.tct_fichePompier.ResumeLayout(false);
            this.pag_info.ResumeLayout(false);
            this.pnl_infoSup.ResumeLayout(false);
            this.grp_affectationPasse.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.pnl_apercu.ResumeLayout(false);
            this.pnl_apercu.PerformLayout();
            this.pnl_conge.ResumeLayout(false);
            this.pnl_conge.PerformLayout();
            this.grb_carrière.ResumeLayout(false);
            this.grb_carrière.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_grade)).EndInit();
            this.pag_modif.ResumeLayout(false);
            this.pag_modif.PerformLayout();
            this.pag_Nouveau.ResumeLayout(false);
            this.pag_Nouveau.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_sexe.ResumeLayout(false);
            this.pnl_sexe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tct_fichePompier;
        private System.Windows.Forms.TabPage pag_modif;
        private System.Windows.Forms.TabPage pag_info;
        private System.Windows.Forms.Panel pnl_apercu;
        private System.Windows.Forms.GroupBox grb_carrière;
        private System.Windows.Forms.Button btn_valider;
        private System.Windows.Forms.Label lbl_bip;
        private System.Windows.Forms.Label lbl_tel;
        private System.Windows.Forms.ComboBox cbo_grade;
        private System.Windows.Forms.Label lbl_grade;
        private System.Windows.Forms.PictureBox pcb_grade;
        private System.Windows.Forms.RadioButton rdb_volontaire;
        private System.Windows.Forms.RadioButton rdb_pro;
        private System.Windows.Forms.Label lbl_dateEmbauche;
        private System.Windows.Forms.Label lbl_sexe;
        private System.Windows.Forms.Label lbl_dateNaissance;
        private System.Windows.Forms.Label lbl_prenom;
        private System.Windows.Forms.Label lbl_nom;
        private System.Windows.Forms.Label lbl_matricule;
        private System.Windows.Forms.Panel pnl_infoSup;
        private System.Windows.Forms.Button btn_infoSup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grp_affectationPasse;
        private System.Windows.Forms.ListBox lsb_affectation;
        private System.Windows.Forms.ListBox lsb_habillitation;
        private System.Windows.Forms.Button btn_maj;
        private System.Windows.Forms.CheckedListBox clb_habillitation;
        private System.Windows.Forms.ComboBox cbo_affectation;
        private System.Windows.Forms.Label lbl_caserneRattachement;
        private System.Windows.Forms.CheckBox chb_conge;
        private System.Windows.Forms.Panel pnl_conge;
        private System.Windows.Forms.RadioButton rdb_conge;
        private System.Windows.Forms.Label lbl_habillitation;
        private System.Windows.Forms.TabPage pag_Nouveau;
        private System.Windows.Forms.TabPage pag_vide;
        private System.Windows.Forms.Label lbl_nouvNom;
        private System.Windows.Forms.DateTimePicker dtp_dateNaissance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_sexe;
        private System.Windows.Forms.RadioButton rdb_femme;
        private System.Windows.Forms.RadioButton rdb_homme;
        private System.Windows.Forms.Label lbl_nouvSexe;
        private System.Windows.Forms.Label lbl_nouvPrenom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdb_nouvVolontaire;
        private System.Windows.Forms.RadioButton rdb_nouvPro;
        private System.Windows.Forms.Label lbl_nouvCaserne;
        private System.Windows.Forms.Label lbl_nouvGrade;
        private System.Windows.Forms.Label lbl_nouvTel;
        private System.Windows.Forms.CheckedListBox clb_nouvHabillitation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_nouvCreer;
        private System.Windows.Forms.TextBox txt_nouvNom;
        private System.Windows.Forms.ComboBox cbo_nouvCaserne;
        private System.Windows.Forms.ComboBox cbo_nouvGrade;
        private System.Windows.Forms.TextBox txt_nouvTel;
        private System.Windows.Forms.TextBox txt_nouvPrenom;
    }
}
