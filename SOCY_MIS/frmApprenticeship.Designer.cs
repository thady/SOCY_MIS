namespace SOCY_MIS
{
    partial class frmApprenticeship
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
            this.gbApprenticeRegisterTitle = new System.Windows.Forms.GroupBox();
            this.llblBack = new System.Windows.Forms.LinkLabel();
            this.gbApprenticeTitle = new System.Windows.Forms.GroupBox();
            this.lblTotalNumber = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvApprentice = new System.Windows.Forms.DataGridView();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclHHCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclHHMNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclHHMName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gclOfcId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpDisplay02 = new System.Windows.Forms.TableLayoutPanel();
            this.lblEnterprise = new System.Windows.Forms.Label();
            this.txtEnterprise = new System.Windows.Forms.RichTextBox();
            this.tlpDisplay01 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDateBegin = new System.Windows.Forms.Label();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.lblDateComplete = new System.Windows.Forms.Label();
            this.dtpDateComplete = new System.Windows.Forms.DateTimePicker();
            this.cbApprenticeshipPartner = new System.Windows.Forms.ComboBox();
            this.lblApprenticeshipPartner = new System.Windows.Forms.Label();
            this.lblYearOfBirth = new System.Windows.Forms.Label();
            this.lblYearOfBirthDisplay = new System.Windows.Forms.Label();
            this.lblGenderDisplay = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblHouseholdCode = new System.Windows.Forms.Label();
            this.cbHHCode = new System.Windows.Forms.ComboBox();
            this.lblHouseholdCodeVal = new System.Windows.Forms.Label();
            this.lblHouseholdMember = new System.Windows.Forms.Label();
            this.cbHHMember = new System.Windows.Forms.ComboBox();
            this.lblHouseholdMemberVal = new System.Windows.Forms.Label();
            this.lblCSO = new System.Windows.Forms.Label();
            this.cbCSO = new System.Windows.Forms.ComboBox();
            this.lblAprlId = new System.Windows.Forms.Label();
            this.lblHhmId = new System.Windows.Forms.Label();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.cbDistrict = new System.Windows.Forms.ComboBox();
            this.lblSubCounty = new System.Windows.Forms.Label();
            this.cbSubCounty = new System.Windows.Forms.ComboBox();
            this.gbApprenticeRegisterTitle.SuspendLayout();
            this.gbApprenticeTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprentice)).BeginInit();
            this.tplButton01.SuspendLayout();
            this.tlpDisplay02.SuspendLayout();
            this.tlpDisplay01.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbApprenticeRegisterTitle
            // 
            this.gbApprenticeRegisterTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbApprenticeRegisterTitle.Controls.Add(this.llblBack);
            this.gbApprenticeRegisterTitle.Controls.Add(this.gbApprenticeTitle);
            this.gbApprenticeRegisterTitle.Controls.Add(this.tplButton01);
            this.gbApprenticeRegisterTitle.Controls.Add(this.tlpDisplay02);
            this.gbApprenticeRegisterTitle.Controls.Add(this.tlpDisplay01);
            this.gbApprenticeRegisterTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbApprenticeRegisterTitle.Location = new System.Drawing.Point(3, 6);
            this.gbApprenticeRegisterTitle.Name = "gbApprenticeRegisterTitle";
            this.gbApprenticeRegisterTitle.Size = new System.Drawing.Size(714, 527);
            this.gbApprenticeRegisterTitle.TabIndex = 0;
            this.gbApprenticeRegisterTitle.TabStop = false;
            this.gbApprenticeRegisterTitle.Text = "Apprenticeship Register";
            // 
            // llblBack
            // 
            this.llblBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblBack.AutoSize = true;
            this.llblBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblBack.Location = new System.Drawing.Point(676, 16);
            this.llblBack.Name = "llblBack";
            this.llblBack.Size = new System.Drawing.Size(32, 13);
            this.llblBack.TabIndex = 23;
            this.llblBack.TabStop = true;
            this.llblBack.Text = "Back";
            this.llblBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblBack_LinkClicked);
            // 
            // gbApprenticeTitle
            // 
            this.gbApprenticeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbApprenticeTitle.Controls.Add(this.lblTotalNumber);
            this.gbApprenticeTitle.Controls.Add(this.lblTotal);
            this.gbApprenticeTitle.Controls.Add(this.dgvApprentice);
            this.gbApprenticeTitle.Controls.Add(this.btnDelete);
            this.gbApprenticeTitle.Location = new System.Drawing.Point(6, 318);
            this.gbApprenticeTitle.Name = "gbApprenticeTitle";
            this.gbApprenticeTitle.Size = new System.Drawing.Size(702, 203);
            this.gbApprenticeTitle.TabIndex = 22;
            this.gbApprenticeTitle.TabStop = false;
            this.gbApprenticeTitle.Text = "Apprentices";
            // 
            // lblTotalNumber
            // 
            this.lblTotalNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalNumber.AutoSize = true;
            this.lblTotalNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalNumber.Location = new System.Drawing.Point(46, 179);
            this.lblTotalNumber.Name = "lblTotalNumber";
            this.lblTotalNumber.Size = new System.Drawing.Size(10, 13);
            this.lblTotalNumber.TabIndex = 31;
            this.lblTotalNumber.Text = "-";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(6, 179);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 30;
            this.lblTotal.Text = "Total:";
            // 
            // dgvApprentice
            // 
            this.dgvApprentice.AllowUserToAddRows = false;
            this.dgvApprentice.AllowUserToDeleteRows = false;
            this.dgvApprentice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvApprentice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApprentice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gclID,
            this.gclHHCode,
            this.gclHHMNumber,
            this.gclHHMName,
            this.gclDelete,
            this.gclOfcId});
            this.dgvApprentice.Location = new System.Drawing.Point(6, 19);
            this.dgvApprentice.MultiSelect = false;
            this.dgvApprentice.Name = "dgvApprentice";
            this.dgvApprentice.Size = new System.Drawing.Size(690, 151);
            this.dgvApprentice.TabIndex = 24;
            this.dgvApprentice.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApprentice_CellDoubleClick);
            this.dgvApprentice.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvApprentice_RowPostPaint);
            // 
            // gclID
            // 
            this.gclID.DataPropertyName = "aprl_id";
            this.gclID.HeaderText = "ID";
            this.gclID.Name = "gclID";
            this.gclID.Visible = false;
            // 
            // gclHHCode
            // 
            this.gclHHCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclHHCode.DataPropertyName = "hh_code";
            this.gclHHCode.HeaderText = "Household Code";
            this.gclHHCode.Name = "gclHHCode";
            this.gclHHCode.ReadOnly = true;
            // 
            // gclHHMNumber
            // 
            this.gclHHMNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclHHMNumber.DataPropertyName = "hhm_number";
            this.gclHHMNumber.HeaderText = "Member Number";
            this.gclHHMNumber.Name = "gclHHMNumber";
            this.gclHHMNumber.ReadOnly = true;
            // 
            // gclHHMName
            // 
            this.gclHHMName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclHHMName.DataPropertyName = "hhm_name";
            this.gclHHMName.HeaderText = "Member Name";
            this.gclHHMName.Name = "gclHHMName";
            this.gclHHMName.ReadOnly = true;
            // 
            // gclDelete
            // 
            this.gclDelete.HeaderText = "Delete";
            this.gclDelete.Name = "gclDelete";
            // 
            // gclOfcId
            // 
            this.gclOfcId.DataPropertyName = "ofc_id";
            this.gclOfcId.HeaderText = "OfficeId";
            this.gclOfcId.Name = "gclOfcId";
            this.gclOfcId.ReadOnly = true;
            this.gclOfcId.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(621, 174);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tplButton01
            // 
            this.tplButton01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplButton01.ColumnCount = 3;
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.Controls.Add(this.btnSave, 0, 0);
            this.tplButton01.Controls.Add(this.btnCancel, 2, 0);
            this.tplButton01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tplButton01.Location = new System.Drawing.Point(30, 268);
            this.tplButton01.Name = "tplButton01";
            this.tplButton01.RowCount = 1;
            this.tplButton01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplButton01.Size = new System.Drawing.Size(654, 40);
            this.tplButton01.TabIndex = 21;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(229, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(350, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tlpDisplay02
            // 
            this.tlpDisplay02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDisplay02.ColumnCount = 3;
            this.tlpDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay02.Controls.Add(this.lblEnterprise, 0, 0);
            this.tlpDisplay02.Controls.Add(this.txtEnterprise, 1, 0);
            this.tlpDisplay02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpDisplay02.Location = new System.Drawing.Point(30, 209);
            this.tlpDisplay02.Name = "tlpDisplay02";
            this.tlpDisplay02.RowCount = 1;
            this.tlpDisplay02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay02.Size = new System.Drawing.Size(654, 60);
            this.tlpDisplay02.TabIndex = 1;
            // 
            // lblEnterprise
            // 
            this.lblEnterprise.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEnterprise.AutoSize = true;
            this.lblEnterprise.Location = new System.Drawing.Point(3, 23);
            this.lblEnterprise.Name = "lblEnterprise";
            this.lblEnterprise.Size = new System.Drawing.Size(57, 13);
            this.lblEnterprise.TabIndex = 7;
            this.lblEnterprise.Text = "Enterprise:";
            // 
            // txtEnterprise
            // 
            this.txtEnterprise.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnterprise.Location = new System.Drawing.Point(153, 3);
            this.txtEnterprise.Name = "txtEnterprise";
            this.txtEnterprise.Size = new System.Drawing.Size(478, 54);
            this.txtEnterprise.TabIndex = 8;
            this.txtEnterprise.Text = "";
            // 
            // tlpDisplay01
            // 
            this.tlpDisplay01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDisplay01.ColumnCount = 6;
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay01.Controls.Add(this.lblCSO, 0, 0);
            this.tlpDisplay01.Controls.Add(this.cbCSO, 1, 0);
            this.tlpDisplay01.Controls.Add(this.lblDateBegin, 0, 5);
            this.tlpDisplay01.Controls.Add(this.lblApprenticeshipPartner, 0, 4);
            this.tlpDisplay01.Controls.Add(this.lblYearOfBirth, 0, 3);
            this.tlpDisplay01.Controls.Add(this.lblHouseholdCode, 0, 2);
            this.tlpDisplay01.Controls.Add(this.dtpDateBegin, 1, 5);
            this.tlpDisplay01.Controls.Add(this.cbApprenticeshipPartner, 1, 4);
            this.tlpDisplay01.Controls.Add(this.lblYearOfBirthDisplay, 1, 3);
            this.tlpDisplay01.Controls.Add(this.cbHHCode, 1, 2);
            this.tlpDisplay01.Controls.Add(this.lblHouseholdCodeVal, 2, 2);
            this.tlpDisplay01.Controls.Add(this.lblDateComplete, 3, 5);
            this.tlpDisplay01.Controls.Add(this.lblAprlId, 3, 4);
            this.tlpDisplay01.Controls.Add(this.lblGender, 3, 3);
            this.tlpDisplay01.Controls.Add(this.dtpDateComplete, 4, 5);
            this.tlpDisplay01.Controls.Add(this.lblHhmId, 4, 4);
            this.tlpDisplay01.Controls.Add(this.lblGenderDisplay, 4, 3);
            this.tlpDisplay01.Controls.Add(this.lblHouseholdMember, 3, 2);
            this.tlpDisplay01.Controls.Add(this.cbHHMember, 4, 2);
            this.tlpDisplay01.Controls.Add(this.lblHouseholdMemberVal, 5, 2);
            this.tlpDisplay01.Controls.Add(this.lblDistrict, 0, 1);
            this.tlpDisplay01.Controls.Add(this.cbDistrict, 1, 1);
            this.tlpDisplay01.Controls.Add(this.lblSubCounty, 3, 1);
            this.tlpDisplay01.Controls.Add(this.cbSubCounty, 4, 1);
            this.tlpDisplay01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpDisplay01.Location = new System.Drawing.Point(30, 30);
            this.tlpDisplay01.Name = "tlpDisplay01";
            this.tlpDisplay01.RowCount = 6;
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDisplay01.Size = new System.Drawing.Size(654, 180);
            this.tlpDisplay01.TabIndex = 0;
            // 
            // lblDateBegin
            // 
            this.lblDateBegin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDateBegin.AutoSize = true;
            this.lblDateBegin.Location = new System.Drawing.Point(3, 158);
            this.lblDateBegin.Name = "lblDateBegin";
            this.lblDateBegin.Size = new System.Drawing.Size(94, 13);
            this.lblDateBegin.TabIndex = 8;
            this.lblDateBegin.Text = "Date of beginning:";
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateBegin.Location = new System.Drawing.Point(153, 155);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(144, 20);
            this.dtpDateBegin.TabIndex = 18;
            // 
            // lblDateComplete
            // 
            this.lblDateComplete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDateComplete.AutoSize = true;
            this.lblDateComplete.Location = new System.Drawing.Point(330, 158);
            this.lblDateComplete.Name = "lblDateComplete";
            this.lblDateComplete.Size = new System.Drawing.Size(99, 13);
            this.lblDateComplete.TabIndex = 6;
            this.lblDateComplete.Text = "Date of completion:";
            // 
            // dtpDateComplete
            // 
            this.dtpDateComplete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDateComplete.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateComplete.Location = new System.Drawing.Point(480, 155);
            this.dtpDateComplete.Name = "dtpDateComplete";
            this.dtpDateComplete.Size = new System.Drawing.Size(151, 20);
            this.dtpDateComplete.TabIndex = 19;
            // 
            // cbApprenticeshipPartner
            // 
            this.cbApprenticeshipPartner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbApprenticeshipPartner.FormattingEnabled = true;
            this.cbApprenticeshipPartner.Location = new System.Drawing.Point(153, 124);
            this.cbApprenticeshipPartner.Name = "cbApprenticeshipPartner";
            this.cbApprenticeshipPartner.Size = new System.Drawing.Size(151, 21);
            this.cbApprenticeshipPartner.TabIndex = 22;
            // 
            // lblApprenticeshipPartner
            // 
            this.lblApprenticeshipPartner.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblApprenticeshipPartner.AutoSize = true;
            this.lblApprenticeshipPartner.Location = new System.Drawing.Point(3, 128);
            this.lblApprenticeshipPartner.Name = "lblApprenticeshipPartner";
            this.lblApprenticeshipPartner.Size = new System.Drawing.Size(117, 13);
            this.lblApprenticeshipPartner.TabIndex = 4;
            this.lblApprenticeshipPartner.Text = "Apprenticeship Partner:";
            // 
            // lblYearOfBirth
            // 
            this.lblYearOfBirth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblYearOfBirth.AutoSize = true;
            this.lblYearOfBirth.Location = new System.Drawing.Point(3, 98);
            this.lblYearOfBirth.Name = "lblYearOfBirth";
            this.lblYearOfBirth.Size = new System.Drawing.Size(67, 13);
            this.lblYearOfBirth.TabIndex = 5;
            this.lblYearOfBirth.Text = "Year of birth:";
            // 
            // lblYearOfBirthDisplay
            // 
            this.lblYearOfBirthDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblYearOfBirthDisplay.AutoSize = true;
            this.lblYearOfBirthDisplay.Location = new System.Drawing.Point(153, 98);
            this.lblYearOfBirthDisplay.Name = "lblYearOfBirthDisplay";
            this.lblYearOfBirthDisplay.Size = new System.Drawing.Size(10, 13);
            this.lblYearOfBirthDisplay.TabIndex = 11;
            this.lblYearOfBirthDisplay.Text = "-";
            // 
            // lblGenderDisplay
            // 
            this.lblGenderDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGenderDisplay.AutoSize = true;
            this.lblGenderDisplay.Location = new System.Drawing.Point(480, 98);
            this.lblGenderDisplay.Name = "lblGenderDisplay";
            this.lblGenderDisplay.Size = new System.Drawing.Size(10, 13);
            this.lblGenderDisplay.TabIndex = 10;
            this.lblGenderDisplay.Text = "-";
            // 
            // lblGender
            // 
            this.lblGender.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(330, 98);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(28, 13);
            this.lblGender.TabIndex = 3;
            this.lblGender.Text = "Sex:";
            // 
            // lblHouseholdCode
            // 
            this.lblHouseholdCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHouseholdCode.AutoSize = true;
            this.lblHouseholdCode.Location = new System.Drawing.Point(3, 68);
            this.lblHouseholdCode.Name = "lblHouseholdCode";
            this.lblHouseholdCode.Size = new System.Drawing.Size(89, 13);
            this.lblHouseholdCode.TabIndex = 1;
            this.lblHouseholdCode.Text = "Household Code:";
            // 
            // cbHHCode
            // 
            this.cbHHCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHHCode.FormattingEnabled = true;
            this.cbHHCode.Location = new System.Drawing.Point(153, 64);
            this.cbHHCode.Name = "cbHHCode";
            this.cbHHCode.Size = new System.Drawing.Size(151, 21);
            this.cbHHCode.TabIndex = 23;
            this.cbHHCode.SelectionChangeCommitted += new System.EventHandler(this.cbHHCode_SelectionChangeCommitted);
            // 
            // lblHouseholdCodeVal
            // 
            this.lblHouseholdCodeVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHouseholdCodeVal.AutoSize = true;
            this.lblHouseholdCodeVal.ForeColor = System.Drawing.Color.Red;
            this.lblHouseholdCodeVal.Location = new System.Drawing.Point(310, 68);
            this.lblHouseholdCodeVal.Name = "lblHouseholdCodeVal";
            this.lblHouseholdCodeVal.Size = new System.Drawing.Size(11, 13);
            this.lblHouseholdCodeVal.TabIndex = 30;
            this.lblHouseholdCodeVal.Text = "*";
            // 
            // lblHouseholdMember
            // 
            this.lblHouseholdMember.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHouseholdMember.AutoSize = true;
            this.lblHouseholdMember.Location = new System.Drawing.Point(330, 68);
            this.lblHouseholdMember.Name = "lblHouseholdMember";
            this.lblHouseholdMember.Size = new System.Drawing.Size(102, 13);
            this.lblHouseholdMember.TabIndex = 2;
            this.lblHouseholdMember.Text = "Household Member:";
            // 
            // cbHHMember
            // 
            this.cbHHMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHHMember.FormattingEnabled = true;
            this.cbHHMember.Location = new System.Drawing.Point(480, 64);
            this.cbHHMember.Name = "cbHHMember";
            this.cbHHMember.Size = new System.Drawing.Size(151, 21);
            this.cbHHMember.TabIndex = 24;
            this.cbHHMember.SelectionChangeCommitted += new System.EventHandler(this.cbHHMember_SelectionChangeCommitted);
            // 
            // lblHouseholdMemberVal
            // 
            this.lblHouseholdMemberVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHouseholdMemberVal.AutoSize = true;
            this.lblHouseholdMemberVal.ForeColor = System.Drawing.Color.Red;
            this.lblHouseholdMemberVal.Location = new System.Drawing.Point(637, 68);
            this.lblHouseholdMemberVal.Name = "lblHouseholdMemberVal";
            this.lblHouseholdMemberVal.Size = new System.Drawing.Size(11, 13);
            this.lblHouseholdMemberVal.TabIndex = 31;
            this.lblHouseholdMemberVal.Text = "*";
            // 
            // lblCSO
            // 
            this.lblCSO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCSO.AutoSize = true;
            this.lblCSO.Location = new System.Drawing.Point(3, 8);
            this.lblCSO.Name = "lblCSO";
            this.lblCSO.Size = new System.Drawing.Size(63, 13);
            this.lblCSO.TabIndex = 32;
            this.lblCSO.Text = "CSO Name:";
            // 
            // cbCSO
            // 
            this.cbCSO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCSO.FormattingEnabled = true;
            this.cbCSO.Location = new System.Drawing.Point(153, 4);
            this.cbCSO.Name = "cbCSO";
            this.cbCSO.Size = new System.Drawing.Size(151, 21);
            this.cbCSO.TabIndex = 33;
            // 
            // lblAprlId
            // 
            this.lblAprlId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAprlId.AutoSize = true;
            this.lblAprlId.Location = new System.Drawing.Point(330, 128);
            this.lblAprlId.Name = "lblAprlId";
            this.lblAprlId.Size = new System.Drawing.Size(10, 13);
            this.lblAprlId.TabIndex = 25;
            this.lblAprlId.Text = "-";
            this.lblAprlId.Visible = false;
            // 
            // lblHhmId
            // 
            this.lblHhmId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHhmId.AutoSize = true;
            this.lblHhmId.Location = new System.Drawing.Point(480, 128);
            this.lblHhmId.Name = "lblHhmId";
            this.lblHhmId.Size = new System.Drawing.Size(10, 13);
            this.lblHhmId.TabIndex = 34;
            this.lblHhmId.Text = "-";
            this.lblHhmId.Visible = false;
            // 
            // lblDistrict
            // 
            this.lblDistrict.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistrict.Location = new System.Drawing.Point(3, 38);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(42, 13);
            this.lblDistrict.TabIndex = 35;
            this.lblDistrict.Text = "District:";
            // 
            // cbDistrict
            // 
            this.cbDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDistrict.FormattingEnabled = true;
            this.cbDistrict.Location = new System.Drawing.Point(153, 34);
            this.cbDistrict.Name = "cbDistrict";
            this.cbDistrict.Size = new System.Drawing.Size(151, 21);
            this.cbDistrict.TabIndex = 36;
            this.cbDistrict.SelectionChangeCommitted += new System.EventHandler(this.cbDistrict_SelectionChangeCommitted);
            // 
            // lblSubCounty
            // 
            this.lblSubCounty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubCounty.AutoSize = true;
            this.lblSubCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCounty.Location = new System.Drawing.Point(330, 38);
            this.lblSubCounty.Name = "lblSubCounty";
            this.lblSubCounty.Size = new System.Drawing.Size(65, 13);
            this.lblSubCounty.TabIndex = 37;
            this.lblSubCounty.Text = "Sub County:";
            // 
            // cbSubCounty
            // 
            this.cbSubCounty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSubCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubCounty.FormattingEnabled = true;
            this.cbSubCounty.Location = new System.Drawing.Point(480, 34);
            this.cbSubCounty.Name = "cbSubCounty";
            this.cbSubCounty.Size = new System.Drawing.Size(151, 21);
            this.cbSubCounty.TabIndex = 38;
            this.cbSubCounty.SelectionChangeCommitted += new System.EventHandler(this.cbSubCounty_SelectionChangeCommitted);
            // 
            // frmApprenticeship
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbApprenticeRegisterTitle);
            this.Name = "frmApprenticeship";
            this.Size = new System.Drawing.Size(720, 533);
            this.Load += new System.EventHandler(this.frmApprenticeship_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmApprenticeship_Paint);
            this.gbApprenticeRegisterTitle.ResumeLayout(false);
            this.gbApprenticeRegisterTitle.PerformLayout();
            this.gbApprenticeTitle.ResumeLayout(false);
            this.gbApprenticeTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprentice)).EndInit();
            this.tplButton01.ResumeLayout(false);
            this.tlpDisplay02.ResumeLayout(false);
            this.tlpDisplay02.PerformLayout();
            this.tlpDisplay01.ResumeLayout(false);
            this.tlpDisplay01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbApprenticeRegisterTitle;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay01;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay02;
        private System.Windows.Forms.Label lblEnterprise;
        private System.Windows.Forms.Label lblHouseholdCode;
        private System.Windows.Forms.Label lblHouseholdMember;
        private System.Windows.Forms.Label lblYearOfBirth;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblApprenticeshipPartner;
        private System.Windows.Forms.Label lblDateComplete;
        private System.Windows.Forms.Label lblGenderDisplay;
        private System.Windows.Forms.Label lblYearOfBirthDisplay;
        private System.Windows.Forms.Label lblDateBegin;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.DateTimePicker dtpDateComplete;
        private System.Windows.Forms.ComboBox cbApprenticeshipPartner;
        private System.Windows.Forms.RichTextBox txtEnterprise;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbApprenticeTitle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbHHCode;
        private System.Windows.Forms.LinkLabel llblBack;
        private System.Windows.Forms.ComboBox cbHHMember;
        private System.Windows.Forms.DataGridView dgvApprentice;
        private System.Windows.Forms.Label lblAprlId;
        private System.Windows.Forms.Label lblTotalNumber;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblHouseholdCodeVal;
        private System.Windows.Forms.Label lblHouseholdMemberVal;
        private System.Windows.Forms.Label lblCSO;
        private System.Windows.Forms.ComboBox cbCSO;
        private System.Windows.Forms.Label lblHhmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclHHCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclHHMNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclHHMName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gclDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclOfcId;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.ComboBox cbDistrict;
        private System.Windows.Forms.Label lblSubCounty;
        private System.Windows.Forms.ComboBox cbSubCounty;
    }
}
