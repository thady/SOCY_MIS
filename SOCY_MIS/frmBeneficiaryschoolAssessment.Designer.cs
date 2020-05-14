namespace SOCY_MIS
{
    partial class frmBeneficiaryschoolAssessment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBeneficiaryschoolAssessment));
            this.lblCSOVal = new System.Windows.Forms.Label();
            this.lblPartnerVal = new System.Windows.Forms.Label();
            this.lblPartner = new System.Windows.Forms.Label();
            this.cboDaysMissed = new System.Windows.Forms.ComboBox();
            this.rbtnschoolYes = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cboChild = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlSuppress = new System.Windows.Forms.Panel();
            this.rbtnschoolNo = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.lblOther = new System.Windows.Forms.Label();
            this.cboCurrentClass = new System.Windows.Forms.ComboBox();
            this.cboMissingSchoolReason = new System.Windows.Forms.ComboBox();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblInofSchoolTitle = new System.Windows.Forms.Label();
            this.txtcurrentschoolname = new System.Windows.Forms.TextBox();
            this.tlpDisplayChild = new System.Windows.Forms.TableLayoutPanel();
            this.lblOutofSchoolTitle = new System.Windows.Forms.Label();
            this.lblid = new System.Windows.Forms.Label();
            this.tlpDisplay16 = new System.Windows.Forms.TableLayoutPanel();
            this.gbOVCIdentificationPrioritizationTitle = new System.Windows.Forms.GroupBox();
            this.tlpDisplayOutOfschool = new System.Windows.Forms.TableLayoutPanel();
            this.txtPrevSchool = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cboPrevClassAttended = new System.Windows.Forms.ComboBox();
            this.cboReasonforDropOut = new System.Windows.Forms.ComboBox();
            this.cboSchoolOption = new System.Windows.Forms.ComboBox();
            this.cboSchoolTerm = new System.Windows.Forms.ComboBox();
            this.lblhhm_id = new System.Windows.Forms.Label();
            this.tlpDisplay13 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpDisplayInschool = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlSuppress.SuspendLayout();
            this.tplButton01.SuspendLayout();
            this.tlpDisplayChild.SuspendLayout();
            this.tlpDisplay16.SuspendLayout();
            this.gbOVCIdentificationPrioritizationTitle.SuspendLayout();
            this.tlpDisplayOutOfschool.SuspendLayout();
            this.tlpDisplay13.SuspendLayout();
            this.tlpDisplayInschool.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCSOVal
            // 
            this.lblCSOVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCSOVal.AutoSize = true;
            this.lblCSOVal.ForeColor = System.Drawing.Color.Red;
            this.lblCSOVal.Location = new System.Drawing.Point(896, 43);
            this.lblCSOVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCSOVal.Name = "lblCSOVal";
            this.lblCSOVal.Size = new System.Drawing.Size(13, 17);
            this.lblCSOVal.TabIndex = 102;
            this.lblCSOVal.Text = "*";
            // 
            // lblPartnerVal
            // 
            this.lblPartnerVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPartnerVal.AutoSize = true;
            this.lblPartnerVal.ForeColor = System.Drawing.Color.Red;
            this.lblPartnerVal.Location = new System.Drawing.Point(896, 9);
            this.lblPartnerVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPartnerVal.Name = "lblPartnerVal";
            this.lblPartnerVal.Size = new System.Drawing.Size(13, 17);
            this.lblPartnerVal.TabIndex = 101;
            this.lblPartnerVal.Text = "*";
            // 
            // lblPartner
            // 
            this.lblPartner.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPartner.AutoSize = true;
            this.lblPartner.Location = new System.Drawing.Point(59, 43);
            this.lblPartner.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPartner.Name = "lblPartner";
            this.lblPartner.Size = new System.Drawing.Size(239, 17);
            this.lblPartner.TabIndex = 103;
            this.lblPartner.Text = "If in school,what is the current class?";
            // 
            // cboDaysMissed
            // 
            this.cboDaysMissed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDaysMissed.FormattingEnabled = true;
            this.cboDaysMissed.Items.AddRange(new object[] {
            "",
            "None ",
            "1-2 days",
            "3- 4 days",
            "5+ days"});
            this.cboDaysMissed.Location = new System.Drawing.Point(394, 73);
            this.cboDaysMissed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboDaysMissed.Name = "cboDaysMissed";
            this.cboDaysMissed.Size = new System.Drawing.Size(493, 25);
            this.cboDaysMissed.TabIndex = 87;
            this.cboDaysMissed.SelectedIndexChanged += new System.EventHandler(this.cboDaysMissed_SelectedIndexChanged);
            // 
            // rbtnschoolYes
            // 
            this.rbtnschoolYes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnschoolYes.AutoSize = true;
            this.rbtnschoolYes.Location = new System.Drawing.Point(4, 5);
            this.rbtnschoolYes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnschoolYes.Name = "rbtnschoolYes";
            this.rbtnschoolYes.Size = new System.Drawing.Size(53, 21);
            this.rbtnschoolYes.TabIndex = 0;
            this.rbtnschoolYes.TabStop = true;
            this.rbtnschoolYes.Text = "Yes";
            this.rbtnschoolYes.UseVisualStyleBackColor = true;
            this.rbtnschoolYes.CheckedChanged += new System.EventHandler(this.rbtnschoolYes_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(59, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 109;
            this.label3.Text = "Name of Child";
            // 
            // cboChild
            // 
            this.cboChild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboChild.FormattingEnabled = true;
            this.cboChild.Location = new System.Drawing.Point(394, 5);
            this.cboChild.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboChild.Name = "cboChild";
            this.cboChild.Size = new System.Drawing.Size(493, 25);
            this.cboChild.TabIndex = 110;
            this.cboChild.SelectedIndexChanged += new System.EventHandler(this.cboChild_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(59, 46);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(214, 17);
            this.label6.TabIndex = 112;
            this.label6.Text = "Is beneficiary enrolled in school?";
            // 
            // pnlSuppress
            // 
            this.pnlSuppress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlSuppress.Controls.Add(this.rbtnschoolNo);
            this.pnlSuppress.Controls.Add(this.rbtnschoolYes);
            this.pnlSuppress.Location = new System.Drawing.Point(394, 40);
            this.pnlSuppress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlSuppress.Name = "pnlSuppress";
            this.pnlSuppress.Size = new System.Drawing.Size(397, 30);
            this.pnlSuppress.TabIndex = 34;
            // 
            // rbtnschoolNo
            // 
            this.rbtnschoolNo.AutoSize = true;
            this.rbtnschoolNo.Location = new System.Drawing.Point(83, 4);
            this.rbtnschoolNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnschoolNo.Name = "rbtnschoolNo";
            this.rbtnschoolNo.Size = new System.Drawing.Size(47, 21);
            this.rbtnschoolNo.TabIndex = 2;
            this.rbtnschoolNo.TabStop = true;
            this.rbtnschoolNo.Text = "No";
            this.rbtnschoolNo.UseVisualStyleBackColor = true;
            this.rbtnschoolNo.CheckedChanged += new System.EventHandler(this.rbtnschoolNo_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 17);
            this.label4.TabIndex = 104;
            this.label4.Text = "Number of days missed school last term";
            // 
            // lblOther
            // 
            this.lblOther.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOther.AutoSize = true;
            this.lblOther.Location = new System.Drawing.Point(59, 112);
            this.lblOther.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(174, 17);
            this.lblOther.TabIndex = 33;
            this.lblOther.Text = "Reason for missing school";
            // 
            // cboCurrentClass
            // 
            this.cboCurrentClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCurrentClass.FormattingEnabled = true;
            this.cboCurrentClass.Items.AddRange(new object[] {
            "",
            "Health Facility",
            "Community",
            "Other"});
            this.cboCurrentClass.Location = new System.Drawing.Point(394, 39);
            this.cboCurrentClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboCurrentClass.Name = "cboCurrentClass";
            this.cboCurrentClass.Size = new System.Drawing.Size(493, 25);
            this.cboCurrentClass.TabIndex = 106;
            // 
            // cboMissingSchoolReason
            // 
            this.cboMissingSchoolReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMissingSchoolReason.FormattingEnabled = true;
            this.cboMissingSchoolReason.Items.AddRange(new object[] {
            " ",
            "Had no fees",
            "Sick",
            " Suspension",
            "Work at home",
            "Others Specify",
            "NA"});
            this.cboMissingSchoolReason.Location = new System.Drawing.Point(394, 108);
            this.cboMissingSchoolReason.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboMissingSchoolReason.Name = "cboMissingSchoolReason";
            this.cboMissingSchoolReason.Size = new System.Drawing.Size(493, 25);
            this.cboMissingSchoolReason.TabIndex = 125;
            // 
            // tplButton01
            // 
            this.tplButton01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplButton01.ColumnCount = 5;
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tplButton01.Controls.Add(this.btnSave, 1, 0);
            this.tplButton01.Controls.Add(this.btnClose, 3, 0);
            this.tplButton01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tplButton01.Location = new System.Drawing.Point(0, 528);
            this.tplButton01.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tplButton01.Name = "tplButton01";
            this.tplButton01.RowCount = 1;
            this.tplButton01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplButton01.Size = new System.Drawing.Size(1056, 49);
            this.tplButton01.TabIndex = 52;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Location = new System.Drawing.Point(360, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 38);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClose.Location = new System.Drawing.Point(560, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 38);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblInofSchoolTitle
            // 
            this.lblInofSchoolTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInofSchoolTitle.AutoSize = true;
            this.lblInofSchoolTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInofSchoolTitle.ForeColor = System.Drawing.Color.White;
            this.lblInofSchoolTitle.Location = new System.Drawing.Point(5, 10);
            this.lblInofSchoolTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInofSchoolTitle.Name = "lblInofSchoolTitle";
            this.lblInofSchoolTitle.Size = new System.Drawing.Size(231, 17);
            this.lblInofSchoolTitle.TabIndex = 1;
            this.lblInofSchoolTitle.Text = "Fill below details if in of school";
            // 
            // txtcurrentschoolname
            // 
            this.txtcurrentschoolname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcurrentschoolname.Location = new System.Drawing.Point(394, 6);
            this.txtcurrentschoolname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtcurrentschoolname.Name = "txtcurrentschoolname";
            this.txtcurrentschoolname.Size = new System.Drawing.Size(493, 23);
            this.txtcurrentschoolname.TabIndex = 125;
            // 
            // tlpDisplayChild
            // 
            this.tlpDisplayChild.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDisplayChild.BackColor = System.Drawing.Color.White;
            this.tlpDisplayChild.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpDisplayChild.ColumnCount = 4;
            this.tlpDisplayChild.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpDisplayChild.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpDisplayChild.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpDisplayChild.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tlpDisplayChild.Controls.Add(this.label3, 1, 0);
            this.tlpDisplayChild.Controls.Add(this.cboChild, 2, 0);
            this.tlpDisplayChild.Controls.Add(this.label6, 1, 1);
            this.tlpDisplayChild.Controls.Add(this.pnlSuppress, 2, 1);
            this.tlpDisplayChild.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpDisplayChild.Location = new System.Drawing.Point(0, 23);
            this.tlpDisplayChild.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpDisplayChild.Name = "tlpDisplayChild";
            this.tlpDisplayChild.RowCount = 2;
            this.tlpDisplayChild.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplayChild.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpDisplayChild.Size = new System.Drawing.Size(1056, 75);
            this.tlpDisplayChild.TabIndex = 85;
            // 
            // lblOutofSchoolTitle
            // 
            this.lblOutofSchoolTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOutofSchoolTitle.AutoSize = true;
            this.lblOutofSchoolTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutofSchoolTitle.ForeColor = System.Drawing.Color.White;
            this.lblOutofSchoolTitle.Location = new System.Drawing.Point(5, 10);
            this.lblOutofSchoolTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutofSchoolTitle.Name = "lblOutofSchoolTitle";
            this.lblOutofSchoolTitle.Size = new System.Drawing.Size(241, 17);
            this.lblOutofSchoolTitle.TabIndex = 1;
            this.lblOutofSchoolTitle.Text = "Fill below details if out of school";
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(341, 5);
            this.lblid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(20, 17);
            this.lblid.TabIndex = 88;
            this.lblid.Text = "--";
            // 
            // tlpDisplay16
            // 
            this.tlpDisplay16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDisplay16.BackColor = System.Drawing.Color.DodgerBlue;
            this.tlpDisplay16.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpDisplay16.ColumnCount = 1;
            this.tlpDisplay16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpDisplay16.Controls.Add(this.lblOutofSchoolTitle, 0, 0);
            this.tlpDisplay16.Location = new System.Drawing.Point(0, 276);
            this.tlpDisplay16.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpDisplay16.Name = "tlpDisplay16";
            this.tlpDisplay16.RowCount = 1;
            this.tlpDisplay16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay16.Size = new System.Drawing.Size(1056, 37);
            this.tlpDisplay16.TabIndex = 86;
            // 
            // gbOVCIdentificationPrioritizationTitle
            // 
            this.gbOVCIdentificationPrioritizationTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOVCIdentificationPrioritizationTitle.BackColor = System.Drawing.Color.AliceBlue;
            this.gbOVCIdentificationPrioritizationTitle.Controls.Add(this.tlpDisplayOutOfschool);
            this.gbOVCIdentificationPrioritizationTitle.Controls.Add(this.lblhhm_id);
            this.gbOVCIdentificationPrioritizationTitle.Controls.Add(this.lblid);
            this.gbOVCIdentificationPrioritizationTitle.Controls.Add(this.tlpDisplay16);
            this.gbOVCIdentificationPrioritizationTitle.Controls.Add(this.tlpDisplayChild);
            this.gbOVCIdentificationPrioritizationTitle.Controls.Add(this.tlpDisplay13);
            this.gbOVCIdentificationPrioritizationTitle.Controls.Add(this.tlpDisplayInschool);
            this.gbOVCIdentificationPrioritizationTitle.Controls.Add(this.tplButton01);
            this.gbOVCIdentificationPrioritizationTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOVCIdentificationPrioritizationTitle.Location = new System.Drawing.Point(3, 4);
            this.gbOVCIdentificationPrioritizationTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOVCIdentificationPrioritizationTitle.Name = "gbOVCIdentificationPrioritizationTitle";
            this.gbOVCIdentificationPrioritizationTitle.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOVCIdentificationPrioritizationTitle.Size = new System.Drawing.Size(1064, 594);
            this.gbOVCIdentificationPrioritizationTitle.TabIndex = 9;
            this.gbOVCIdentificationPrioritizationTitle.TabStop = false;
            this.gbOVCIdentificationPrioritizationTitle.Text = "Assessment for adolescent related services";
            // 
            // tlpDisplayOutOfschool
            // 
            this.tlpDisplayOutOfschool.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDisplayOutOfschool.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpDisplayOutOfschool.ColumnCount = 4;
            this.tlpDisplayOutOfschool.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpDisplayOutOfschool.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpDisplayOutOfschool.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpDisplayOutOfschool.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tlpDisplayOutOfschool.Controls.Add(this.txtPrevSchool, 2, 0);
            this.tlpDisplayOutOfschool.Controls.Add(this.label1, 3, 3);
            this.tlpDisplayOutOfschool.Controls.Add(this.label2, 3, 2);
            this.tlpDisplayOutOfschool.Controls.Add(this.label11, 1, 2);
            this.tlpDisplayOutOfschool.Controls.Add(this.label13, 1, 0);
            this.tlpDisplayOutOfschool.Controls.Add(this.label14, 3, 0);
            this.tlpDisplayOutOfschool.Controls.Add(this.label15, 1, 1);
            this.tlpDisplayOutOfschool.Controls.Add(this.label16, 1, 3);
            this.tlpDisplayOutOfschool.Controls.Add(this.label17, 1, 4);
            this.tlpDisplayOutOfschool.Controls.Add(this.label18, 3, 1);
            this.tlpDisplayOutOfschool.Controls.Add(this.cboPrevClassAttended, 2, 1);
            this.tlpDisplayOutOfschool.Controls.Add(this.cboReasonforDropOut, 2, 2);
            this.tlpDisplayOutOfschool.Controls.Add(this.cboSchoolOption, 2, 3);
            this.tlpDisplayOutOfschool.Controls.Add(this.cboSchoolTerm, 2, 4);
            this.tlpDisplayOutOfschool.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpDisplayOutOfschool.Location = new System.Drawing.Point(0, 313);
            this.tlpDisplayOutOfschool.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpDisplayOutOfschool.Name = "tlpDisplayOutOfschool";
            this.tlpDisplayOutOfschool.RowCount = 5;
            this.tlpDisplayOutOfschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplayOutOfschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplayOutOfschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplayOutOfschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplayOutOfschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplayOutOfschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpDisplayOutOfschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpDisplayOutOfschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpDisplayOutOfschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpDisplayOutOfschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpDisplayOutOfschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpDisplayOutOfschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpDisplayOutOfschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpDisplayOutOfschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpDisplayOutOfschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpDisplayOutOfschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpDisplayOutOfschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpDisplayOutOfschool.Size = new System.Drawing.Size(1056, 208);
            this.tlpDisplayOutOfschool.TabIndex = 90;
            // 
            // txtPrevSchool
            // 
            this.txtPrevSchool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrevSchool.Location = new System.Drawing.Point(394, 9);
            this.txtPrevSchool.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrevSchool.Name = "txtPrevSchool";
            this.txtPrevSchool.Size = new System.Drawing.Size(493, 23);
            this.txtPrevSchool.TabIndex = 127;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(896, 135);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 17);
            this.label1.TabIndex = 102;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(896, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 17);
            this.label2.TabIndex = 101;
            this.label2.Text = "*";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(59, 94);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 17);
            this.label11.TabIndex = 103;
            this.label11.Text = "Reason for dropout";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(59, 12);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(263, 17);
            this.label13.TabIndex = 109;
            this.label13.Text = "If out of school,previous school attended";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(896, 12);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 17);
            this.label14.TabIndex = 111;
            this.label14.Text = "*";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(59, 53);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(171, 17);
            this.label15.TabIndex = 112;
            this.label15.Text = "Class attended at dropout";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(59, 127);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(298, 34);
            this.label16.TabIndex = 104;
            this.label16.Text = "Would beneficiary like to go back to school or vocational training?";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(59, 169);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(325, 34);
            this.label17.TabIndex = 33;
            this.label17.Text = "If school,when would beneficiary like to go back to school?";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(896, 53);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(13, 17);
            this.label18.TabIndex = 124;
            this.label18.Text = "*";
            // 
            // cboPrevClassAttended
            // 
            this.cboPrevClassAttended.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrevClassAttended.FormattingEnabled = true;
            this.cboPrevClassAttended.Items.AddRange(new object[] {
            "",
            "Health Facility",
            "Community",
            "Other"});
            this.cboPrevClassAttended.Location = new System.Drawing.Point(394, 49);
            this.cboPrevClassAttended.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboPrevClassAttended.Name = "cboPrevClassAttended";
            this.cboPrevClassAttended.Size = new System.Drawing.Size(493, 25);
            this.cboPrevClassAttended.TabIndex = 106;
            // 
            // cboReasonforDropOut
            // 
            this.cboReasonforDropOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReasonforDropOut.FormattingEnabled = true;
            this.cboReasonforDropOut.Items.AddRange(new object[] {
            "",
            "Had no fees",
            "Sick",
            " Suspension",
            "Work at home",
            "Others Specify"});
            this.cboReasonforDropOut.Location = new System.Drawing.Point(394, 90);
            this.cboReasonforDropOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboReasonforDropOut.Name = "cboReasonforDropOut";
            this.cboReasonforDropOut.Size = new System.Drawing.Size(493, 25);
            this.cboReasonforDropOut.TabIndex = 87;
            // 
            // cboSchoolOption
            // 
            this.cboSchoolOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSchoolOption.FormattingEnabled = true;
            this.cboSchoolOption.Items.AddRange(new object[] {
            "",
            "School",
            " Vocational"});
            this.cboSchoolOption.Location = new System.Drawing.Point(394, 131);
            this.cboSchoolOption.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboSchoolOption.Name = "cboSchoolOption";
            this.cboSchoolOption.Size = new System.Drawing.Size(493, 25);
            this.cboSchoolOption.TabIndex = 125;
            this.cboSchoolOption.SelectedIndexChanged += new System.EventHandler(this.cboSchoolOption_SelectedIndexChanged);
            // 
            // cboSchoolTerm
            // 
            this.cboSchoolTerm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSchoolTerm.FormattingEnabled = true;
            this.cboSchoolTerm.Items.AddRange(new object[] {
            "",
            "Term – 1",
            "Term – 2",
            "Term - 3"});
            this.cboSchoolTerm.Location = new System.Drawing.Point(394, 173);
            this.cboSchoolTerm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboSchoolTerm.Name = "cboSchoolTerm";
            this.cboSchoolTerm.Size = new System.Drawing.Size(493, 25);
            this.cboSchoolTerm.TabIndex = 128;
            // 
            // lblhhm_id
            // 
            this.lblhhm_id.AutoSize = true;
            this.lblhhm_id.Location = new System.Drawing.Point(709, 5);
            this.lblhhm_id.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblhhm_id.Name = "lblhhm_id";
            this.lblhhm_id.Size = new System.Drawing.Size(20, 17);
            this.lblhhm_id.TabIndex = 89;
            this.lblhhm_id.Text = "--";
            // 
            // tlpDisplay13
            // 
            this.tlpDisplay13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDisplay13.BackColor = System.Drawing.Color.DodgerBlue;
            this.tlpDisplay13.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpDisplay13.ColumnCount = 1;
            this.tlpDisplay13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpDisplay13.Controls.Add(this.lblInofSchoolTitle, 0, 0);
            this.tlpDisplay13.Location = new System.Drawing.Point(0, 100);
            this.tlpDisplay13.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpDisplay13.Name = "tlpDisplay13";
            this.tlpDisplay13.RowCount = 1;
            this.tlpDisplay13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpDisplay13.Size = new System.Drawing.Size(1056, 37);
            this.tlpDisplay13.TabIndex = 73;
            // 
            // tlpDisplayInschool
            // 
            this.tlpDisplayInschool.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDisplayInschool.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpDisplayInschool.ColumnCount = 4;
            this.tlpDisplayInschool.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpDisplayInschool.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpDisplayInschool.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpDisplayInschool.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tlpDisplayInschool.Controls.Add(this.txtcurrentschoolname, 2, 0);
            this.tlpDisplayInschool.Controls.Add(this.lblCSOVal, 3, 1);
            this.tlpDisplayInschool.Controls.Add(this.lblPartnerVal, 3, 0);
            this.tlpDisplayInschool.Controls.Add(this.lblOther, 1, 3);
            this.tlpDisplayInschool.Controls.Add(this.cboMissingSchoolReason, 2, 3);
            this.tlpDisplayInschool.Controls.Add(this.cboDaysMissed, 2, 2);
            this.tlpDisplayInschool.Controls.Add(this.label4, 1, 2);
            this.tlpDisplayInschool.Controls.Add(this.lblPartner, 1, 1);
            this.tlpDisplayInschool.Controls.Add(this.cboCurrentClass, 2, 1);
            this.tlpDisplayInschool.Controls.Add(this.label5, 1, 0);
            this.tlpDisplayInschool.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpDisplayInschool.Location = new System.Drawing.Point(0, 137);
            this.tlpDisplayInschool.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpDisplayInschool.Name = "tlpDisplayInschool";
            this.tlpDisplayInschool.RowCount = 4;
            this.tlpDisplayInschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDisplayInschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDisplayInschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDisplayInschool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDisplayInschool.Size = new System.Drawing.Size(1056, 139);
            this.tlpDisplayInschool.TabIndex = 68;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(254, 17);
            this.label5.TabIndex = 126;
            this.label5.Text = "If in school,what is the name of school?";
            // 
            // frmBeneficiaryschoolAssessment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 601);
            this.Controls.Add(this.gbOVCIdentificationPrioritizationTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBeneficiaryschoolAssessment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBeneficiaryschoolAssessment";
            this.Load += new System.EventHandler(this.frmBeneficiaryschoolAssessment_Load);
            this.pnlSuppress.ResumeLayout(false);
            this.pnlSuppress.PerformLayout();
            this.tplButton01.ResumeLayout(false);
            this.tlpDisplayChild.ResumeLayout(false);
            this.tlpDisplayChild.PerformLayout();
            this.tlpDisplay16.ResumeLayout(false);
            this.tlpDisplay16.PerformLayout();
            this.gbOVCIdentificationPrioritizationTitle.ResumeLayout(false);
            this.gbOVCIdentificationPrioritizationTitle.PerformLayout();
            this.tlpDisplayOutOfschool.ResumeLayout(false);
            this.tlpDisplayOutOfschool.PerformLayout();
            this.tlpDisplay13.ResumeLayout(false);
            this.tlpDisplay13.PerformLayout();
            this.tlpDisplayInschool.ResumeLayout(false);
            this.tlpDisplayInschool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCSOVal;
        private System.Windows.Forms.Label lblPartnerVal;
        private System.Windows.Forms.Label lblPartner;
        private System.Windows.Forms.ComboBox cboDaysMissed;
        private System.Windows.Forms.RadioButton rbtnschoolYes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboChild;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlSuppress;
        private System.Windows.Forms.RadioButton rbtnschoolNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblOther;
        private System.Windows.Forms.ComboBox cboCurrentClass;
        private System.Windows.Forms.ComboBox cboMissingSchoolReason;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblInofSchoolTitle;
        private System.Windows.Forms.TextBox txtcurrentschoolname;
        private System.Windows.Forms.TableLayoutPanel tlpDisplayChild;
        private System.Windows.Forms.Label lblOutofSchoolTitle;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay16;
        private System.Windows.Forms.GroupBox gbOVCIdentificationPrioritizationTitle;
        private System.Windows.Forms.Label lblhhm_id;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay13;
        private System.Windows.Forms.TableLayoutPanel tlpDisplayInschool;
        private System.Windows.Forms.TableLayoutPanel tlpDisplayOutOfschool;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboPrevClassAttended;
        private System.Windows.Forms.ComboBox cboReasonforDropOut;
        private System.Windows.Forms.ComboBox cboSchoolOption;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrevSchool;
        private System.Windows.Forms.ComboBox cboSchoolTerm;
        private System.Windows.Forms.Button btnClose;
    }
}