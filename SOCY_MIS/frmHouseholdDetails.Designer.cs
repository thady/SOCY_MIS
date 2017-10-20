namespace SOCY_MIS
{
    partial class frmHouseholdDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbTitle = new System.Windows.Forms.GroupBox();
            this.llblBack = new System.Windows.Forms.LinkLabel();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpDisplay01 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.lblSubCounty = new System.Windows.Forms.Label();
            this.lblWard = new System.Windows.Forms.Label();
            this.lblSocialWorker = new System.Windows.Forms.Label();
            this.lblHouseholdCode = new System.Windows.Forms.Label();
            this.lblVillage = new System.Windows.Forms.Label();
            this.cbSocialWorker = new System.Windows.Forms.ComboBox();
            this.cbDistrict = new System.Windows.Forms.ComboBox();
            this.cbSubCounty = new System.Windows.Forms.ComboBox();
            this.cbWard = new System.Windows.Forms.ComboBox();
            this.txtVillage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWardVal = new System.Windows.Forms.Label();
            this.lblVillageVal = new System.Windows.Forms.Label();
            this.lblSubCountyVal = new System.Windows.Forms.Label();
            this.txtHoueholdCode = new System.Windows.Forms.TextBox();
            this.txtStatusReasonOther = new System.Windows.Forms.RichTextBox();
            this.lblStatusReasonOther = new System.Windows.Forms.Label();
            this.lblStatusReason = new System.Windows.Forms.Label();
            this.cbStatusReason = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.gbTitle.SuspendLayout();
            this.tplButton01.SuspendLayout();
            this.tlpDisplay01.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTitle
            // 
            this.gbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTitle.Controls.Add(this.llblBack);
            this.gbTitle.Controls.Add(this.tplButton01);
            this.gbTitle.Controls.Add(this.tlpDisplay01);
            this.gbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTitle.Location = new System.Drawing.Point(4, 7);
            this.gbTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbTitle.Name = "gbTitle";
            this.gbTitle.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbTitle.Size = new System.Drawing.Size(1205, 629);
            this.gbTitle.TabIndex = 5;
            this.gbTitle.TabStop = false;
            this.gbTitle.Text = "Household Details";
            this.gbTitle.Enter += new System.EventHandler(this.gbTitle_Enter);
            // 
            // llblBack
            // 
            this.llblBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblBack.AutoSize = true;
            this.llblBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblBack.Location = new System.Drawing.Point(1155, 20);
            this.llblBack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblBack.Name = "llblBack";
            this.llblBack.Size = new System.Drawing.Size(39, 17);
            this.llblBack.TabIndex = 34;
            this.llblBack.TabStop = true;
            this.llblBack.Text = "Back";
            this.llblBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblBack_LinkClicked);
            // 
            // tplButton01
            // 
            this.tplButton01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplButton01.ColumnCount = 3;
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.Controls.Add(this.btnSave, 0, 0);
            this.tplButton01.Controls.Add(this.btnCancel, 2, 0);
            this.tplButton01.Location = new System.Drawing.Point(40, 331);
            this.tplButton01.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tplButton01.Name = "tplButton01";
            this.tplButton01.RowCount = 1;
            this.tplButton01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplButton01.Size = new System.Drawing.Size(1139, 49);
            this.tplButton01.TabIndex = 33;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(439, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(600, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tlpDisplay01
            // 
            this.tlpDisplay01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDisplay01.ColumnCount = 6;
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpDisplay01.Controls.Add(this.lblDistrict, 0, 1);
            this.tlpDisplay01.Controls.Add(this.lblSubCounty, 3, 1);
            this.tlpDisplay01.Controls.Add(this.lblWard, 0, 2);
            this.tlpDisplay01.Controls.Add(this.lblSocialWorker, 3, 0);
            this.tlpDisplay01.Controls.Add(this.lblHouseholdCode, 0, 0);
            this.tlpDisplay01.Controls.Add(this.lblVillage, 3, 2);
            this.tlpDisplay01.Controls.Add(this.cbSocialWorker, 4, 0);
            this.tlpDisplay01.Controls.Add(this.cbDistrict, 1, 1);
            this.tlpDisplay01.Controls.Add(this.cbSubCounty, 4, 1);
            this.tlpDisplay01.Controls.Add(this.cbWard, 1, 2);
            this.tlpDisplay01.Controls.Add(this.txtVillage, 4, 2);
            this.tlpDisplay01.Controls.Add(this.label2, 2, 0);
            this.tlpDisplay01.Controls.Add(this.label1, 2, 1);
            this.tlpDisplay01.Controls.Add(this.lblWardVal, 2, 2);
            this.tlpDisplay01.Controls.Add(this.lblVillageVal, 5, 2);
            this.tlpDisplay01.Controls.Add(this.lblSubCountyVal, 5, 1);
            this.tlpDisplay01.Controls.Add(this.txtHoueholdCode, 1, 0);
            this.tlpDisplay01.Controls.Add(this.txtStatusReasonOther, 4, 5);
            this.tlpDisplay01.Controls.Add(this.lblStatusReasonOther, 3, 5);
            this.tlpDisplay01.Controls.Add(this.lblStatusReason, 3, 4);
            this.tlpDisplay01.Controls.Add(this.cbStatusReason, 4, 4);
            this.tlpDisplay01.Controls.Add(this.cbStatus, 1, 4);
            this.tlpDisplay01.Controls.Add(this.lblStatus, 0, 4);
            this.tlpDisplay01.Controls.Add(this.lblPhone, 0, 3);
            this.tlpDisplay01.Controls.Add(this.txtPhone, 1, 3);
            this.tlpDisplay01.Location = new System.Drawing.Point(40, 37);
            this.tlpDisplay01.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpDisplay01.Name = "tlpDisplay01";
            this.tlpDisplay01.RowCount = 6;
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49922F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49922F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49922F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49922F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50297F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.50016F));
            this.tlpDisplay01.Size = new System.Drawing.Size(1139, 295);
            this.tlpDisplay01.TabIndex = 3;
            // 
            // lblDistrict
            // 
            this.lblDistrict.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistrict.Location = new System.Drawing.Point(4, 45);
            this.lblDistrict.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(55, 17);
            this.lblDistrict.TabIndex = 9;
            this.lblDistrict.Text = "District:";
            // 
            // lblSubCounty
            // 
            this.lblSubCounty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubCounty.AutoSize = true;
            this.lblSubCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCounty.Location = new System.Drawing.Point(573, 45);
            this.lblSubCounty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubCounty.Name = "lblSubCounty";
            this.lblSubCounty.Size = new System.Drawing.Size(85, 17);
            this.lblSubCounty.TabIndex = 12;
            this.lblSubCounty.Text = "Sub County:";
            // 
            // lblWard
            // 
            this.lblWard.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblWard.AutoSize = true;
            this.lblWard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWard.Location = new System.Drawing.Point(4, 81);
            this.lblWard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(90, 17);
            this.lblWard.TabIndex = 11;
            this.lblWard.Text = "Parich/Ward:";
            // 
            // lblSocialWorker
            // 
            this.lblSocialWorker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSocialWorker.AutoSize = true;
            this.lblSocialWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSocialWorker.Location = new System.Drawing.Point(573, 9);
            this.lblSocialWorker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSocialWorker.Name = "lblSocialWorker";
            this.lblSocialWorker.Size = new System.Drawing.Size(100, 17);
            this.lblSocialWorker.TabIndex = 14;
            this.lblSocialWorker.Text = "Social Worker:";
            // 
            // lblHouseholdCode
            // 
            this.lblHouseholdCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHouseholdCode.AutoSize = true;
            this.lblHouseholdCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHouseholdCode.Location = new System.Drawing.Point(4, 9);
            this.lblHouseholdCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHouseholdCode.Name = "lblHouseholdCode";
            this.lblHouseholdCode.Size = new System.Drawing.Size(117, 17);
            this.lblHouseholdCode.TabIndex = 15;
            this.lblHouseholdCode.Text = "Household Code:";
            // 
            // lblVillage
            // 
            this.lblVillage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVillage.AutoSize = true;
            this.lblVillage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVillage.Location = new System.Drawing.Point(573, 81);
            this.lblVillage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVillage.Name = "lblVillage";
            this.lblVillage.Size = new System.Drawing.Size(81, 17);
            this.lblVillage.TabIndex = 16;
            this.lblVillage.Text = "Village/Cell:";
            // 
            // cbSocialWorker
            // 
            this.cbSocialWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSocialWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSocialWorker.FormattingEnabled = true;
            this.cbSocialWorker.Location = new System.Drawing.Point(773, 5);
            this.cbSocialWorker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSocialWorker.Name = "cbSocialWorker";
            this.cbSocialWorker.Size = new System.Drawing.Size(308, 25);
            this.cbSocialWorker.TabIndex = 21;
            // 
            // cbDistrict
            // 
            this.cbDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDistrict.FormattingEnabled = true;
            this.cbDistrict.Location = new System.Drawing.Point(204, 41);
            this.cbDistrict.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbDistrict.Name = "cbDistrict";
            this.cbDistrict.Size = new System.Drawing.Size(308, 25);
            this.cbDistrict.TabIndex = 22;
            this.cbDistrict.SelectionChangeCommitted += new System.EventHandler(this.cbDistrict_SelectionChangeCommitted);
            // 
            // cbSubCounty
            // 
            this.cbSubCounty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSubCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubCounty.FormattingEnabled = true;
            this.cbSubCounty.Location = new System.Drawing.Point(773, 41);
            this.cbSubCounty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSubCounty.Name = "cbSubCounty";
            this.cbSubCounty.Size = new System.Drawing.Size(308, 25);
            this.cbSubCounty.TabIndex = 24;
            this.cbSubCounty.SelectionChangeCommitted += new System.EventHandler(this.cbSubCounty_SelectionChangeCommitted);
            // 
            // cbWard
            // 
            this.cbWard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbWard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWard.FormattingEnabled = true;
            this.cbWard.Location = new System.Drawing.Point(204, 77);
            this.cbWard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbWard.Name = "cbWard";
            this.cbWard.Size = new System.Drawing.Size(308, 25);
            this.cbWard.TabIndex = 25;
            this.cbWard.SelectionChangeCommitted += new System.EventHandler(this.cbWard_SelectionChangeCommitted);
            // 
            // txtVillage
            // 
            this.txtVillage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVillage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVillage.Location = new System.Drawing.Point(773, 76);
            this.txtVillage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVillage.Name = "txtVillage";
            this.txtVillage.Size = new System.Drawing.Size(308, 23);
            this.txtVillage.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(520, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(520, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "*";
            // 
            // lblWardVal
            // 
            this.lblWardVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblWardVal.AutoSize = true;
            this.lblWardVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWardVal.ForeColor = System.Drawing.Color.Red;
            this.lblWardVal.Location = new System.Drawing.Point(520, 81);
            this.lblWardVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWardVal.Name = "lblWardVal";
            this.lblWardVal.Size = new System.Drawing.Size(13, 17);
            this.lblWardVal.TabIndex = 28;
            this.lblWardVal.Text = "*";
            // 
            // lblVillageVal
            // 
            this.lblVillageVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVillageVal.AutoSize = true;
            this.lblVillageVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVillageVal.ForeColor = System.Drawing.Color.Red;
            this.lblVillageVal.Location = new System.Drawing.Point(1089, 81);
            this.lblVillageVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVillageVal.Name = "lblVillageVal";
            this.lblVillageVal.Size = new System.Drawing.Size(13, 17);
            this.lblVillageVal.TabIndex = 32;
            this.lblVillageVal.Text = "*";
            // 
            // lblSubCountyVal
            // 
            this.lblSubCountyVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubCountyVal.AutoSize = true;
            this.lblSubCountyVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCountyVal.ForeColor = System.Drawing.Color.Red;
            this.lblSubCountyVal.Location = new System.Drawing.Point(1089, 45);
            this.lblSubCountyVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubCountyVal.Name = "lblSubCountyVal";
            this.lblSubCountyVal.Size = new System.Drawing.Size(13, 17);
            this.lblSubCountyVal.TabIndex = 31;
            this.lblSubCountyVal.Text = "*";
            // 
            // txtHoueholdCode
            // 
            this.txtHoueholdCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHoueholdCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoueholdCode.Location = new System.Drawing.Point(204, 4);
            this.txtHoueholdCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHoueholdCode.Name = "txtHoueholdCode";
            this.txtHoueholdCode.Size = new System.Drawing.Size(308, 23);
            this.txtHoueholdCode.TabIndex = 35;
            // 
            // txtStatusReasonOther
            // 
            this.txtStatusReasonOther.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatusReasonOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatusReasonOther.Location = new System.Drawing.Point(773, 184);
            this.txtStatusReasonOther.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStatusReasonOther.Name = "txtStatusReasonOther";
            this.txtStatusReasonOther.Size = new System.Drawing.Size(308, 107);
            this.txtStatusReasonOther.TabIndex = 20;
            this.txtStatusReasonOther.Text = "";
            // 
            // lblStatusReasonOther
            // 
            this.lblStatusReasonOther.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatusReasonOther.AutoSize = true;
            this.lblStatusReasonOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusReasonOther.Location = new System.Drawing.Point(573, 229);
            this.lblStatusReasonOther.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusReasonOther.Name = "lblStatusReasonOther";
            this.lblStatusReasonOther.Size = new System.Drawing.Size(48, 17);
            this.lblStatusReasonOther.TabIndex = 19;
            this.lblStatusReasonOther.Text = "Other:";
            // 
            // lblStatusReason
            // 
            this.lblStatusReason.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatusReason.AutoSize = true;
            this.lblStatusReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusReason.Location = new System.Drawing.Point(573, 153);
            this.lblStatusReason.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusReason.Name = "lblStatusReason";
            this.lblStatusReason.Size = new System.Drawing.Size(133, 17);
            this.lblStatusReason.TabIndex = 18;
            this.lblStatusReason.Text = "Reason for change:";
            // 
            // cbStatusReason
            // 
            this.cbStatusReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStatusReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatusReason.FormattingEnabled = true;
            this.cbStatusReason.Location = new System.Drawing.Point(773, 149);
            this.cbStatusReason.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbStatusReason.Name = "cbStatusReason";
            this.cbStatusReason.Size = new System.Drawing.Size(308, 25);
            this.cbStatusReason.TabIndex = 26;
            // 
            // cbStatus
            // 
            this.cbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(204, 149);
            this.cbStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(308, 25);
            this.cbStatus.TabIndex = 23;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(4, 153);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 17);
            this.lblStatus.TabIndex = 17;
            this.lblStatus.Text = "Status: ";
            // 
            // lblPhone
            // 
            this.lblPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(4, 117);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(53, 17);
            this.lblPhone.TabIndex = 36;
            this.lblPhone.Text = "Phone:";
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(204, 112);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(308, 23);
            this.txtPhone.TabIndex = 37;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // frmHouseholdDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbTitle);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmHouseholdDetails";
            this.Size = new System.Drawing.Size(1213, 640);
            this.Load += new System.EventHandler(this.frmHouseholdDetails_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmHouseholdDetails_Paint);
            this.gbTitle.ResumeLayout(false);
            this.gbTitle.PerformLayout();
            this.tplButton01.ResumeLayout(false);
            this.tlpDisplay01.ResumeLayout(false);
            this.tlpDisplay01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTitle;
        private System.Windows.Forms.LinkLabel llblBack;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay01;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.Label lblWard;
        private System.Windows.Forms.Label lblSubCounty;
        private System.Windows.Forms.Label lblSocialWorker;
        private System.Windows.Forms.Label lblHouseholdCode;
        private System.Windows.Forms.Label lblVillage;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusReason;
        private System.Windows.Forms.Label lblStatusReasonOther;
        private System.Windows.Forms.RichTextBox txtStatusReasonOther;
        private System.Windows.Forms.ComboBox cbSocialWorker;
        private System.Windows.Forms.ComboBox cbDistrict;
        private System.Windows.Forms.ComboBox cbSubCounty;
        private System.Windows.Forms.ComboBox cbWard;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ComboBox cbStatusReason;
        private System.Windows.Forms.TextBox txtVillage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWardVal;
        private System.Windows.Forms.Label lblVillageVal;
        private System.Windows.Forms.Label lblSubCountyVal;
        private System.Windows.Forms.TextBox txtHoueholdCode;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
    }
}
