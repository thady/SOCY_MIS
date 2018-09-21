namespace SOCY_MIS
{
    partial class frmHouseholdAssessmentMember
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
            this.gbMembers = new System.Windows.Forms.GroupBox();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclYearOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclOfcId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.llblBackBottom = new System.Windows.Forms.LinkLabel();
            this.llblBackTop = new System.Windows.Forms.LinkLabel();
            this.tlpDisplay01 = new System.Windows.Forms.TableLayoutPanel();
            this.chkCaregiver = new System.Windows.Forms.CheckBox();
            this.lblHouseholdCodeDisplay = new System.Windows.Forms.Label();
            this.chkHeadOfHousehold = new System.Windows.Forms.CheckBox();
            this.lblHouseholdCode = new System.Windows.Forms.Label();
            this.lblMemberNumber = new System.Windows.Forms.Label();
            this.lblMemberNumberDisplay = new System.Windows.Forms.Label();
            this.lblMemberType = new System.Windows.Forms.Label();
            this.lblHHMember = new System.Windows.Forms.Label();
            this.cbHHMember = new System.Windows.Forms.ComboBox();
            this.pnlMemberType = new System.Windows.Forms.Panel();
            this.rbtnMemberTypeExisting = new System.Windows.Forms.RadioButton();
            this.rbtnMemberTypeNew = new System.Windows.Forms.RadioButton();
            this.lblHHMemberVal = new System.Windows.Forms.Label();
            this.lblMaritalStatus = new System.Windows.Forms.Label();
            this.lblPregnant = new System.Windows.Forms.Label();
            this.lblSchool = new System.Windows.Forms.Label();
            this.lblProfession = new System.Windows.Forms.Label();
            this.lblHIVStatus = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblBirthRegistration = new System.Windows.Forms.Label();
            this.lblYearOfBirth = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.cbMaritalStatus = new System.Windows.Forms.ComboBox();
            this.cbPregnant = new System.Windows.Forms.ComboBox();
            this.cbSchool = new System.Windows.Forms.ComboBox();
            this.cbProfession = new System.Windows.Forms.ComboBox();
            this.cbHIVStatus = new System.Windows.Forms.ComboBox();
            this.cbDisability = new System.Windows.Forms.ComboBox();
            this.cbBirthRegistration = new System.Windows.Forms.ComboBox();
            this.cbYearOfBirth = new System.Windows.Forms.ComboBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFirstNameVal = new System.Windows.Forms.Label();
            this.lblGivenBirth = new System.Windows.Forms.Label();
            this.lblEducation = new System.Windows.Forms.Label();
            this.lblART = new System.Windows.Forms.Label();
            this.lblDisabilityType = new System.Windows.Forms.Label();
            this.lblImmunize = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.cbGivenBirth = new System.Windows.Forms.ComboBox();
            this.cbEducation = new System.Windows.Forms.ComboBox();
            this.cbART = new System.Windows.Forms.ComboBox();
            this.cbDisabilityType = new System.Windows.Forms.ComboBox();
            this.cbImmunize = new System.Windows.Forms.ComboBox();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLastNameVal = new System.Windows.Forms.Label();
            this.lblHAMId = new System.Windows.Forms.Label();
            this.cbProtection = new System.Windows.Forms.ComboBox();
            this.lblProtection = new System.Windows.Forms.Label();
            this.cbAttainedVocationalSkill = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.tplButton01.SuspendLayout();
            this.tlpDisplay01.SuspendLayout();
            this.pnlMemberType.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMembers
            // 
            this.gbMembers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMembers.Controls.Add(this.dgvMembers);
            this.gbMembers.Location = new System.Drawing.Point(4, 558);
            this.gbMembers.Margin = new System.Windows.Forms.Padding(4);
            this.gbMembers.Name = "gbMembers";
            this.gbMembers.Padding = new System.Windows.Forms.Padding(4);
            this.gbMembers.Size = new System.Drawing.Size(1205, 242);
            this.gbMembers.TabIndex = 21;
            this.gbMembers.TabStop = false;
            this.gbMembers.Text = "Members";
            // 
            // dgvMembers
            // 
            this.dgvMembers.AllowUserToAddRows = false;
            this.dgvMembers.AllowUserToDeleteRows = false;
            this.dgvMembers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gclID,
            this.gclNumber,
            this.gclFirstName,
            this.gclLastName,
            this.gclGender,
            this.gclYearOfBirth,
            this.gclOfcId});
            this.dgvMembers.Location = new System.Drawing.Point(8, 23);
            this.dgvMembers.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMembers.MultiSelect = false;
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.Size = new System.Drawing.Size(1189, 212);
            this.dgvMembers.TabIndex = 21;
            this.dgvMembers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMembers_CellDoubleClick);
            // 
            // gclID
            // 
            this.gclID.DataPropertyName = "ham_id";
            this.gclID.HeaderText = "ID";
            this.gclID.Name = "gclID";
            this.gclID.ReadOnly = true;
            this.gclID.Visible = false;
            // 
            // gclNumber
            // 
            this.gclNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclNumber.DataPropertyName = "hhm_number";
            this.gclNumber.HeaderText = "Member Number";
            this.gclNumber.Name = "gclNumber";
            this.gclNumber.ReadOnly = true;
            // 
            // gclFirstName
            // 
            this.gclFirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclFirstName.DataPropertyName = "ham_first_name";
            this.gclFirstName.HeaderText = "First Name";
            this.gclFirstName.Name = "gclFirstName";
            this.gclFirstName.ReadOnly = true;
            // 
            // gclLastName
            // 
            this.gclLastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclLastName.DataPropertyName = "ham_last_name";
            this.gclLastName.HeaderText = "Last Name";
            this.gclLastName.Name = "gclLastName";
            this.gclLastName.ReadOnly = true;
            // 
            // gclGender
            // 
            this.gclGender.DataPropertyName = "gnd_name";
            this.gclGender.HeaderText = "Sex";
            this.gclGender.Name = "gclGender";
            this.gclGender.ReadOnly = true;
            this.gclGender.Width = 150;
            // 
            // gclYearOfBirth
            // 
            this.gclYearOfBirth.DataPropertyName = "year_of_birth";
            this.gclYearOfBirth.HeaderText = "Year Of Birth";
            this.gclYearOfBirth.Name = "gclYearOfBirth";
            this.gclYearOfBirth.ReadOnly = true;
            this.gclYearOfBirth.Width = 150;
            // 
            // gclOfcId
            // 
            this.gclOfcId.DataPropertyName = "ofc_id";
            this.gclOfcId.HeaderText = "OfficeId";
            this.gclOfcId.Name = "gclOfcId";
            this.gclOfcId.ReadOnly = true;
            this.gclOfcId.Visible = false;
            // 
            // tplButton01
            // 
            this.tplButton01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplButton01.ColumnCount = 4;
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tplButton01.Controls.Add(this.btnSave, 0, 0);
            this.tplButton01.Controls.Add(this.btnCancel, 2, 0);
            this.tplButton01.Controls.Add(this.llblBackBottom, 3, 0);
            this.tplButton01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tplButton01.Location = new System.Drawing.Point(4, 501);
            this.tplButton01.Margin = new System.Windows.Forms.Padding(4);
            this.tplButton01.Name = "tplButton01";
            this.tplButton01.RowCount = 1;
            this.tplButton01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplButton01.Size = new System.Drawing.Size(1205, 49);
            this.tplButton01.TabIndex = 20;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(445, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(606, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // llblBackBottom
            // 
            this.llblBackBottom.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.llblBackBottom.AutoSize = true;
            this.llblBackBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblBackBottom.Location = new System.Drawing.Point(1162, 16);
            this.llblBackBottom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblBackBottom.Name = "llblBackBottom";
            this.llblBackBottom.Size = new System.Drawing.Size(39, 17);
            this.llblBackBottom.TabIndex = 46;
            this.llblBackBottom.TabStop = true;
            this.llblBackBottom.Text = "Back";
            this.llblBackBottom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblBack_LinkClicked);
            // 
            // llblBackTop
            // 
            this.llblBackTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblBackTop.AutoSize = true;
            this.llblBackTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblBackTop.Location = new System.Drawing.Point(1159, 1);
            this.llblBackTop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblBackTop.Name = "llblBackTop";
            this.llblBackTop.Size = new System.Drawing.Size(39, 17);
            this.llblBackTop.TabIndex = 45;
            this.llblBackTop.TabStop = true;
            this.llblBackTop.Text = "Back";
            this.llblBackTop.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblBack_LinkClicked);
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
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDisplay01.Controls.Add(this.chkCaregiver, 4, 2);
            this.tlpDisplay01.Controls.Add(this.lblHouseholdCodeDisplay, 1, 0);
            this.tlpDisplay01.Controls.Add(this.chkHeadOfHousehold, 1, 2);
            this.tlpDisplay01.Controls.Add(this.lblHouseholdCode, 0, 0);
            this.tlpDisplay01.Controls.Add(this.lblMemberNumber, 3, 0);
            this.tlpDisplay01.Controls.Add(this.lblMemberNumberDisplay, 4, 0);
            this.tlpDisplay01.Controls.Add(this.lblMemberType, 3, 1);
            this.tlpDisplay01.Controls.Add(this.lblHHMember, 0, 1);
            this.tlpDisplay01.Controls.Add(this.cbHHMember, 1, 1);
            this.tlpDisplay01.Controls.Add(this.pnlMemberType, 4, 1);
            this.tlpDisplay01.Controls.Add(this.lblHHMemberVal, 2, 1);
            this.tlpDisplay01.Controls.Add(this.lblMaritalStatus, 0, 12);
            this.tlpDisplay01.Controls.Add(this.lblPregnant, 0, 11);
            this.tlpDisplay01.Controls.Add(this.lblSchool, 0, 9);
            this.tlpDisplay01.Controls.Add(this.lblProfession, 0, 8);
            this.tlpDisplay01.Controls.Add(this.lblHIVStatus, 0, 7);
            this.tlpDisplay01.Controls.Add(this.label14, 0, 6);
            this.tlpDisplay01.Controls.Add(this.lblBirthRegistration, 0, 5);
            this.tlpDisplay01.Controls.Add(this.lblYearOfBirth, 0, 4);
            this.tlpDisplay01.Controls.Add(this.lblFirstName, 0, 3);
            this.tlpDisplay01.Controls.Add(this.cbMaritalStatus, 1, 12);
            this.tlpDisplay01.Controls.Add(this.cbPregnant, 1, 11);
            this.tlpDisplay01.Controls.Add(this.cbSchool, 1, 9);
            this.tlpDisplay01.Controls.Add(this.cbProfession, 1, 8);
            this.tlpDisplay01.Controls.Add(this.cbHIVStatus, 1, 7);
            this.tlpDisplay01.Controls.Add(this.cbDisability, 1, 6);
            this.tlpDisplay01.Controls.Add(this.cbBirthRegistration, 1, 5);
            this.tlpDisplay01.Controls.Add(this.cbYearOfBirth, 1, 4);
            this.tlpDisplay01.Controls.Add(this.txtFirstName, 1, 3);
            this.tlpDisplay01.Controls.Add(this.label2, 2, 4);
            this.tlpDisplay01.Controls.Add(this.lblFirstNameVal, 2, 3);
            this.tlpDisplay01.Controls.Add(this.lblGivenBirth, 3, 11);
            this.tlpDisplay01.Controls.Add(this.lblEducation, 3, 9);
            this.tlpDisplay01.Controls.Add(this.lblART, 3, 7);
            this.tlpDisplay01.Controls.Add(this.lblDisabilityType, 3, 6);
            this.tlpDisplay01.Controls.Add(this.lblImmunize, 3, 5);
            this.tlpDisplay01.Controls.Add(this.lblGender, 3, 4);
            this.tlpDisplay01.Controls.Add(this.lblLastName, 3, 3);
            this.tlpDisplay01.Controls.Add(this.cbGivenBirth, 4, 11);
            this.tlpDisplay01.Controls.Add(this.cbEducation, 4, 9);
            this.tlpDisplay01.Controls.Add(this.cbART, 4, 7);
            this.tlpDisplay01.Controls.Add(this.cbDisabilityType, 4, 6);
            this.tlpDisplay01.Controls.Add(this.cbImmunize, 4, 5);
            this.tlpDisplay01.Controls.Add(this.cbGender, 4, 4);
            this.tlpDisplay01.Controls.Add(this.txtLastName, 4, 3);
            this.tlpDisplay01.Controls.Add(this.label1, 5, 4);
            this.tlpDisplay01.Controls.Add(this.lblLastNameVal, 5, 3);
            this.tlpDisplay01.Controls.Add(this.lblHAMId, 0, 2);
            this.tlpDisplay01.Controls.Add(this.cbProtection, 4, 10);
            this.tlpDisplay01.Controls.Add(this.lblProtection, 3, 10);
            this.tlpDisplay01.Controls.Add(this.cbAttainedVocationalSkill, 1, 10);
            this.tlpDisplay01.Controls.Add(this.label3, 0, 10);
            this.tlpDisplay01.Controls.Add(this.label4, 2, 6);
            this.tlpDisplay01.Controls.Add(this.label5, 2, 7);
            this.tlpDisplay01.Controls.Add(this.label6, 2, 8);
            this.tlpDisplay01.Controls.Add(this.label7, 2, 9);
            this.tlpDisplay01.Controls.Add(this.label8, 5, 9);
            this.tlpDisplay01.Controls.Add(this.label9, 5, 10);
            this.tlpDisplay01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpDisplay01.Location = new System.Drawing.Point(4, 22);
            this.tlpDisplay01.Margin = new System.Windows.Forms.Padding(4);
            this.tlpDisplay01.Name = "tlpDisplay01";
            this.tlpDisplay01.RowCount = 13;
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692503F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692503F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692503F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692503F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692503F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692503F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692503F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692503F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692503F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692503F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692503F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692503F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.68996F));
            this.tlpDisplay01.Size = new System.Drawing.Size(1205, 480);
            this.tlpDisplay01.TabIndex = 46;
            // 
            // chkCaregiver
            // 
            this.chkCaregiver.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkCaregiver.AutoSize = true;
            this.chkCaregiver.Enabled = false;
            this.chkCaregiver.Location = new System.Drawing.Point(806, 79);
            this.chkCaregiver.Margin = new System.Windows.Forms.Padding(4);
            this.chkCaregiver.Name = "chkCaregiver";
            this.chkCaregiver.Size = new System.Drawing.Size(91, 21);
            this.chkCaregiver.TabIndex = 51;
            this.chkCaregiver.Text = "Caregiver";
            this.chkCaregiver.UseVisualStyleBackColor = true;
            // 
            // lblHouseholdCodeDisplay
            // 
            this.lblHouseholdCodeDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHouseholdCodeDisplay.AutoSize = true;
            this.lblHouseholdCodeDisplay.Location = new System.Drawing.Point(204, 9);
            this.lblHouseholdCodeDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHouseholdCodeDisplay.Name = "lblHouseholdCodeDisplay";
            this.lblHouseholdCodeDisplay.Size = new System.Drawing.Size(76, 17);
            this.lblHouseholdCodeDisplay.TabIndex = 16;
            this.lblHouseholdCodeDisplay.Text = "HH000000";
            // 
            // chkHeadOfHousehold
            // 
            this.chkHeadOfHousehold.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkHeadOfHousehold.AutoSize = true;
            this.chkHeadOfHousehold.Enabled = false;
            this.chkHeadOfHousehold.Location = new System.Drawing.Point(204, 79);
            this.chkHeadOfHousehold.Margin = new System.Windows.Forms.Padding(4);
            this.chkHeadOfHousehold.Name = "chkHeadOfHousehold";
            this.chkHeadOfHousehold.Size = new System.Drawing.Size(152, 21);
            this.chkHeadOfHousehold.TabIndex = 50;
            this.chkHeadOfHousehold.Text = "Head of Household";
            this.chkHeadOfHousehold.UseVisualStyleBackColor = true;
            // 
            // lblHouseholdCode
            // 
            this.lblHouseholdCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHouseholdCode.AutoSize = true;
            this.lblHouseholdCode.Location = new System.Drawing.Point(4, 9);
            this.lblHouseholdCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHouseholdCode.Name = "lblHouseholdCode";
            this.lblHouseholdCode.Size = new System.Drawing.Size(117, 17);
            this.lblHouseholdCode.TabIndex = 0;
            this.lblHouseholdCode.Text = "Household Code:";
            // 
            // lblMemberNumber
            // 
            this.lblMemberNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMemberNumber.AutoSize = true;
            this.lblMemberNumber.Location = new System.Drawing.Point(606, 9);
            this.lblMemberNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMemberNumber.Name = "lblMemberNumber";
            this.lblMemberNumber.Size = new System.Drawing.Size(117, 17);
            this.lblMemberNumber.TabIndex = 4;
            this.lblMemberNumber.Text = "Member Number:";
            // 
            // lblMemberNumberDisplay
            // 
            this.lblMemberNumberDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMemberNumberDisplay.AutoSize = true;
            this.lblMemberNumberDisplay.Location = new System.Drawing.Point(806, 9);
            this.lblMemberNumberDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMemberNumberDisplay.Name = "lblMemberNumberDisplay";
            this.lblMemberNumberDisplay.Size = new System.Drawing.Size(16, 17);
            this.lblMemberNumberDisplay.TabIndex = 1;
            this.lblMemberNumberDisplay.Text = "1";
            // 
            // lblMemberType
            // 
            this.lblMemberType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMemberType.AutoSize = true;
            this.lblMemberType.Location = new System.Drawing.Point(606, 45);
            this.lblMemberType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMemberType.Name = "lblMemberType";
            this.lblMemberType.Size = new System.Drawing.Size(99, 17);
            this.lblMemberType.TabIndex = 45;
            this.lblMemberType.Text = "Member Type:";
            // 
            // lblHHMember
            // 
            this.lblHHMember.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHHMember.AutoSize = true;
            this.lblHHMember.Location = new System.Drawing.Point(4, 45);
            this.lblHHMember.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHHMember.Name = "lblHHMember";
            this.lblHHMember.Size = new System.Drawing.Size(135, 17);
            this.lblHHMember.TabIndex = 46;
            this.lblHHMember.Text = "Household Member:";
            // 
            // cbHHMember
            // 
            this.cbHHMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHHMember.FormattingEnabled = true;
            this.cbHHMember.Location = new System.Drawing.Point(204, 41);
            this.cbHHMember.Margin = new System.Windows.Forms.Padding(4);
            this.cbHHMember.Name = "cbHHMember";
            this.cbHHMember.Size = new System.Drawing.Size(341, 25);
            this.cbHHMember.TabIndex = 47;
            this.cbHHMember.SelectionChangeCommitted += new System.EventHandler(this.cbHHMember_SelectionChangeCommitted);
            // 
            // pnlMemberType
            // 
            this.pnlMemberType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlMemberType.Controls.Add(this.rbtnMemberTypeExisting);
            this.pnlMemberType.Controls.Add(this.rbtnMemberTypeNew);
            this.pnlMemberType.Location = new System.Drawing.Point(806, 42);
            this.pnlMemberType.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMemberType.Name = "pnlMemberType";
            this.pnlMemberType.Size = new System.Drawing.Size(267, 23);
            this.pnlMemberType.TabIndex = 49;
            // 
            // rbtnMemberTypeExisting
            // 
            this.rbtnMemberTypeExisting.AutoSize = true;
            this.rbtnMemberTypeExisting.Checked = true;
            this.rbtnMemberTypeExisting.Location = new System.Drawing.Point(4, 1);
            this.rbtnMemberTypeExisting.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnMemberTypeExisting.Name = "rbtnMemberTypeExisting";
            this.rbtnMemberTypeExisting.Size = new System.Drawing.Size(77, 21);
            this.rbtnMemberTypeExisting.TabIndex = 2;
            this.rbtnMemberTypeExisting.TabStop = true;
            this.rbtnMemberTypeExisting.Text = "Existing";
            this.rbtnMemberTypeExisting.UseVisualStyleBackColor = true;
            this.rbtnMemberTypeExisting.CheckedChanged += new System.EventHandler(this.rbtnMemberTypeExisting_CheckedChanged);
            // 
            // rbtnMemberTypeNew
            // 
            this.rbtnMemberTypeNew.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnMemberTypeNew.AutoSize = true;
            this.rbtnMemberTypeNew.Location = new System.Drawing.Point(93, 1);
            this.rbtnMemberTypeNew.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnMemberTypeNew.Name = "rbtnMemberTypeNew";
            this.rbtnMemberTypeNew.Size = new System.Drawing.Size(56, 21);
            this.rbtnMemberTypeNew.TabIndex = 0;
            this.rbtnMemberTypeNew.Text = "New";
            this.rbtnMemberTypeNew.UseVisualStyleBackColor = true;
            // 
            // lblHHMemberVal
            // 
            this.lblHHMemberVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHHMemberVal.AutoSize = true;
            this.lblHHMemberVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHHMemberVal.ForeColor = System.Drawing.Color.Red;
            this.lblHHMemberVal.Location = new System.Drawing.Point(553, 45);
            this.lblHHMemberVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHHMemberVal.Name = "lblHHMemberVal";
            this.lblHHMemberVal.Size = new System.Drawing.Size(13, 17);
            this.lblHHMemberVal.TabIndex = 48;
            this.lblHHMemberVal.Text = "*";
            // 
            // lblMaritalStatus
            // 
            this.lblMaritalStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMaritalStatus.AutoSize = true;
            this.lblMaritalStatus.Location = new System.Drawing.Point(4, 447);
            this.lblMaritalStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaritalStatus.Name = "lblMaritalStatus";
            this.lblMaritalStatus.Size = new System.Drawing.Size(98, 17);
            this.lblMaritalStatus.TabIndex = 35;
            this.lblMaritalStatus.Text = "Marital Status:";
            // 
            // lblPregnant
            // 
            this.lblPregnant.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPregnant.AutoSize = true;
            this.lblPregnant.Location = new System.Drawing.Point(4, 405);
            this.lblPregnant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPregnant.Name = "lblPregnant";
            this.lblPregnant.Size = new System.Drawing.Size(131, 17);
            this.lblPregnant.TabIndex = 34;
            this.lblPregnant.Text = "Currently Pregnant:";
            // 
            // lblSchool
            // 
            this.lblSchool.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSchool.AutoSize = true;
            this.lblSchool.Location = new System.Drawing.Point(4, 333);
            this.lblSchool.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSchool.Name = "lblSchool";
            this.lblSchool.Size = new System.Drawing.Size(107, 17);
            this.lblSchool.TabIndex = 11;
            this.lblSchool.Text = "Attends School:";
            // 
            // lblProfession
            // 
            this.lblProfession.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblProfession.AutoSize = true;
            this.lblProfession.Location = new System.Drawing.Point(4, 297);
            this.lblProfession.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProfession.Name = "lblProfession";
            this.lblProfession.Size = new System.Drawing.Size(79, 17);
            this.lblProfession.TabIndex = 5;
            this.lblProfession.Text = "Profession:";
            // 
            // lblHIVStatus
            // 
            this.lblHIVStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHIVStatus.AutoSize = true;
            this.lblHIVStatus.Location = new System.Drawing.Point(4, 261);
            this.lblHIVStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHIVStatus.Name = "lblHIVStatus";
            this.lblHIVStatus.Size = new System.Drawing.Size(78, 17);
            this.lblHIVStatus.TabIndex = 9;
            this.lblHIVStatus.Text = "HIV Status:";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 225);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 17);
            this.label14.TabIndex = 13;
            this.label14.Text = "Disability:";
            // 
            // lblBirthRegistration
            // 
            this.lblBirthRegistration.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBirthRegistration.AutoSize = true;
            this.lblBirthRegistration.Location = new System.Drawing.Point(4, 189);
            this.lblBirthRegistration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBirthRegistration.Name = "lblBirthRegistration";
            this.lblBirthRegistration.Size = new System.Drawing.Size(121, 17);
            this.lblBirthRegistration.TabIndex = 14;
            this.lblBirthRegistration.Text = "Birth Registration:";
            // 
            // lblYearOfBirth
            // 
            this.lblYearOfBirth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblYearOfBirth.AutoSize = true;
            this.lblYearOfBirth.Location = new System.Drawing.Point(4, 153);
            this.lblYearOfBirth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYearOfBirth.Name = "lblYearOfBirth";
            this.lblYearOfBirth.Size = new System.Drawing.Size(91, 17);
            this.lblYearOfBirth.TabIndex = 10;
            this.lblYearOfBirth.Text = "Year of Birth:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(4, 117);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(80, 17);
            this.lblFirstName.TabIndex = 8;
            this.lblFirstName.Text = "First Name:";
            // 
            // cbMaritalStatus
            // 
            this.cbMaritalStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMaritalStatus.FormattingEnabled = true;
            this.cbMaritalStatus.Location = new System.Drawing.Point(204, 443);
            this.cbMaritalStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cbMaritalStatus.Name = "cbMaritalStatus";
            this.cbMaritalStatus.Size = new System.Drawing.Size(341, 25);
            this.cbMaritalStatus.TabIndex = 39;
            // 
            // cbPregnant
            // 
            this.cbPregnant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPregnant.FormattingEnabled = true;
            this.cbPregnant.Location = new System.Drawing.Point(204, 401);
            this.cbPregnant.Margin = new System.Windows.Forms.Padding(4);
            this.cbPregnant.Name = "cbPregnant";
            this.cbPregnant.Size = new System.Drawing.Size(341, 25);
            this.cbPregnant.TabIndex = 37;
            // 
            // cbSchool
            // 
            this.cbSchool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSchool.FormattingEnabled = true;
            this.cbSchool.Location = new System.Drawing.Point(204, 329);
            this.cbSchool.Margin = new System.Windows.Forms.Padding(4);
            this.cbSchool.Name = "cbSchool";
            this.cbSchool.Size = new System.Drawing.Size(341, 25);
            this.cbSchool.TabIndex = 33;
            // 
            // cbProfession
            // 
            this.cbProfession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProfession.FormattingEnabled = true;
            this.cbProfession.Location = new System.Drawing.Point(204, 293);
            this.cbProfession.Margin = new System.Windows.Forms.Padding(4);
            this.cbProfession.Name = "cbProfession";
            this.cbProfession.Size = new System.Drawing.Size(341, 25);
            this.cbProfession.TabIndex = 22;
            // 
            // cbHIVStatus
            // 
            this.cbHIVStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHIVStatus.FormattingEnabled = true;
            this.cbHIVStatus.Location = new System.Drawing.Point(204, 257);
            this.cbHIVStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cbHIVStatus.Name = "cbHIVStatus";
            this.cbHIVStatus.Size = new System.Drawing.Size(341, 25);
            this.cbHIVStatus.TabIndex = 23;
            this.cbHIVStatus.SelectedIndexChanged += new System.EventHandler(this.cbHIVStatus_SelectedIndexChanged);
            this.cbHIVStatus.SelectionChangeCommitted += new System.EventHandler(this.cbHIVStatus_SelectionChangeCommitted);
            // 
            // cbDisability
            // 
            this.cbDisability.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDisability.FormattingEnabled = true;
            this.cbDisability.Location = new System.Drawing.Point(204, 221);
            this.cbDisability.Margin = new System.Windows.Forms.Padding(4);
            this.cbDisability.Name = "cbDisability";
            this.cbDisability.Size = new System.Drawing.Size(341, 25);
            this.cbDisability.TabIndex = 22;
            this.cbDisability.SelectedIndexChanged += new System.EventHandler(this.cbDisability_SelectedIndexChanged);
            this.cbDisability.SelectionChangeCommitted += new System.EventHandler(this.cbDisability_SelectionChangeCommitted);
            // 
            // cbBirthRegistration
            // 
            this.cbBirthRegistration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBirthRegistration.FormattingEnabled = true;
            this.cbBirthRegistration.Location = new System.Drawing.Point(204, 185);
            this.cbBirthRegistration.Margin = new System.Windows.Forms.Padding(4);
            this.cbBirthRegistration.Name = "cbBirthRegistration";
            this.cbBirthRegistration.Size = new System.Drawing.Size(341, 25);
            this.cbBirthRegistration.TabIndex = 22;
            // 
            // cbYearOfBirth
            // 
            this.cbYearOfBirth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbYearOfBirth.FormattingEnabled = true;
            this.cbYearOfBirth.Location = new System.Drawing.Point(204, 149);
            this.cbYearOfBirth.Margin = new System.Windows.Forms.Padding(4);
            this.cbYearOfBirth.Name = "cbYearOfBirth";
            this.cbYearOfBirth.Size = new System.Drawing.Size(113, 25);
            this.cbYearOfBirth.TabIndex = 26;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Location = new System.Drawing.Point(204, 114);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(341, 23);
            this.txtFirstName.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(553, 153);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "*";
            // 
            // lblFirstNameVal
            // 
            this.lblFirstNameVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFirstNameVal.AutoSize = true;
            this.lblFirstNameVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstNameVal.ForeColor = System.Drawing.Color.Red;
            this.lblFirstNameVal.Location = new System.Drawing.Point(553, 117);
            this.lblFirstNameVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstNameVal.Name = "lblFirstNameVal";
            this.lblFirstNameVal.Size = new System.Drawing.Size(13, 17);
            this.lblFirstNameVal.TabIndex = 29;
            this.lblFirstNameVal.Text = "*";
            // 
            // lblGivenBirth
            // 
            this.lblGivenBirth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGivenBirth.AutoSize = true;
            this.lblGivenBirth.Location = new System.Drawing.Point(606, 405);
            this.lblGivenBirth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGivenBirth.Name = "lblGivenBirth";
            this.lblGivenBirth.Size = new System.Drawing.Size(111, 17);
            this.lblGivenBirth.TabIndex = 36;
            this.lblGivenBirth.Text = "Ever given birth:";
            // 
            // lblEducation
            // 
            this.lblEducation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEducation.AutoSize = true;
            this.lblEducation.Location = new System.Drawing.Point(606, 333);
            this.lblEducation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEducation.Name = "lblEducation";
            this.lblEducation.Size = new System.Drawing.Size(184, 17);
            this.lblEducation.TabIndex = 18;
            this.lblEducation.Text = "Education Level Completed:";
            // 
            // lblART
            // 
            this.lblART.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblART.AutoSize = true;
            this.lblART.Location = new System.Drawing.Point(606, 261);
            this.lblART.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblART.Name = "lblART";
            this.lblART.Size = new System.Drawing.Size(40, 17);
            this.lblART.TabIndex = 7;
            this.lblART.Text = "ART:";
            // 
            // lblDisabilityType
            // 
            this.lblDisabilityType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisabilityType.AutoSize = true;
            this.lblDisabilityType.Location = new System.Drawing.Point(606, 225);
            this.lblDisabilityType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDisabilityType.Name = "lblDisabilityType";
            this.lblDisabilityType.Size = new System.Drawing.Size(104, 17);
            this.lblDisabilityType.TabIndex = 24;
            this.lblDisabilityType.Text = "Disability Type:";
            // 
            // lblImmunize
            // 
            this.lblImmunize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImmunize.AutoSize = true;
            this.lblImmunize.Location = new System.Drawing.Point(606, 189);
            this.lblImmunize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImmunize.Name = "lblImmunize";
            this.lblImmunize.Size = new System.Drawing.Size(71, 17);
            this.lblImmunize.TabIndex = 3;
            this.lblImmunize.Text = "Immunize:";
            // 
            // lblGender
            // 
            this.lblGender.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(606, 153);
            this.lblGender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(35, 17);
            this.lblGender.TabIndex = 12;
            this.lblGender.Text = "Sex:";
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(606, 117);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(80, 17);
            this.lblLastName.TabIndex = 44;
            this.lblLastName.Text = "Last Name:";
            // 
            // cbGivenBirth
            // 
            this.cbGivenBirth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGivenBirth.FormattingEnabled = true;
            this.cbGivenBirth.Location = new System.Drawing.Point(806, 401);
            this.cbGivenBirth.Margin = new System.Windows.Forms.Padding(4);
            this.cbGivenBirth.Name = "cbGivenBirth";
            this.cbGivenBirth.Size = new System.Drawing.Size(341, 25);
            this.cbGivenBirth.TabIndex = 38;
            // 
            // cbEducation
            // 
            this.cbEducation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEducation.FormattingEnabled = true;
            this.cbEducation.Location = new System.Drawing.Point(806, 329);
            this.cbEducation.Margin = new System.Windows.Forms.Padding(4);
            this.cbEducation.Name = "cbEducation";
            this.cbEducation.Size = new System.Drawing.Size(341, 25);
            this.cbEducation.TabIndex = 32;
            // 
            // cbART
            // 
            this.cbART.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbART.FormattingEnabled = true;
            this.cbART.Location = new System.Drawing.Point(806, 257);
            this.cbART.Margin = new System.Windows.Forms.Padding(4);
            this.cbART.Name = "cbART";
            this.cbART.Size = new System.Drawing.Size(341, 25);
            this.cbART.TabIndex = 22;
            // 
            // cbDisabilityType
            // 
            this.cbDisabilityType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDisabilityType.Enabled = false;
            this.cbDisabilityType.FormattingEnabled = true;
            this.cbDisabilityType.Location = new System.Drawing.Point(806, 221);
            this.cbDisabilityType.Margin = new System.Windows.Forms.Padding(4);
            this.cbDisabilityType.Name = "cbDisabilityType";
            this.cbDisabilityType.Size = new System.Drawing.Size(341, 25);
            this.cbDisabilityType.TabIndex = 25;
            // 
            // cbImmunize
            // 
            this.cbImmunize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbImmunize.FormattingEnabled = true;
            this.cbImmunize.Location = new System.Drawing.Point(806, 185);
            this.cbImmunize.Margin = new System.Windows.Forms.Padding(4);
            this.cbImmunize.Name = "cbImmunize";
            this.cbImmunize.Size = new System.Drawing.Size(341, 25);
            this.cbImmunize.TabIndex = 22;
            // 
            // cbGender
            // 
            this.cbGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Location = new System.Drawing.Point(806, 149);
            this.cbGender.Margin = new System.Windows.Forms.Padding(4);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(341, 25);
            this.cbGender.TabIndex = 21;
            this.cbGender.SelectedIndexChanged += new System.EventHandler(this.cbGender_SelectedIndexChanged);
            this.cbGender.SelectionChangeCommitted += new System.EventHandler(this.cbGender_SelectionChangeCommitted);
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Location = new System.Drawing.Point(806, 114);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(341, 23);
            this.txtLastName.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(1155, 153);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "*";
            // 
            // lblLastNameVal
            // 
            this.lblLastNameVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLastNameVal.AutoSize = true;
            this.lblLastNameVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastNameVal.ForeColor = System.Drawing.Color.Red;
            this.lblLastNameVal.Location = new System.Drawing.Point(1155, 117);
            this.lblLastNameVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastNameVal.Name = "lblLastNameVal";
            this.lblLastNameVal.Size = new System.Drawing.Size(13, 17);
            this.lblLastNameVal.TabIndex = 43;
            this.lblLastNameVal.Text = "*";
            // 
            // lblHAMId
            // 
            this.lblHAMId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHAMId.AutoSize = true;
            this.lblHAMId.Location = new System.Drawing.Point(4, 81);
            this.lblHAMId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHAMId.Name = "lblHAMId";
            this.lblHAMId.Size = new System.Drawing.Size(13, 17);
            this.lblHAMId.TabIndex = 52;
            this.lblHAMId.Text = "-";
            this.lblHAMId.Visible = false;
            // 
            // cbProtection
            // 
            this.cbProtection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProtection.FormattingEnabled = true;
            this.cbProtection.Location = new System.Drawing.Point(806, 365);
            this.cbProtection.Margin = new System.Windows.Forms.Padding(4);
            this.cbProtection.Name = "cbProtection";
            this.cbProtection.Size = new System.Drawing.Size(341, 25);
            this.cbProtection.TabIndex = 22;
            // 
            // lblProtection
            // 
            this.lblProtection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblProtection.AutoSize = true;
            this.lblProtection.Location = new System.Drawing.Point(606, 369);
            this.lblProtection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProtection.Name = "lblProtection";
            this.lblProtection.Size = new System.Drawing.Size(76, 17);
            this.lblProtection.TabIndex = 20;
            this.lblProtection.Text = "Protection:";
            // 
            // cbAttainedVocationalSkill
            // 
            this.cbAttainedVocationalSkill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAttainedVocationalSkill.FormattingEnabled = true;
            this.cbAttainedVocationalSkill.Location = new System.Drawing.Point(204, 365);
            this.cbAttainedVocationalSkill.Margin = new System.Windows.Forms.Padding(4);
            this.cbAttainedVocationalSkill.Name = "cbAttainedVocationalSkill";
            this.cbAttainedVocationalSkill.Size = new System.Drawing.Size(341, 25);
            this.cbAttainedVocationalSkill.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 369);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "Attained a Vocational Skill:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(553, 225);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 17);
            this.label4.TabIndex = 55;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(553, 261);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 17);
            this.label5.TabIndex = 56;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(553, 297);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 17);
            this.label6.TabIndex = 57;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(553, 333);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 17);
            this.label7.TabIndex = 58;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(1155, 333);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 17);
            this.label8.TabIndex = 59;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(1155, 369);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 17);
            this.label9.TabIndex = 60;
            this.label9.Text = "*";
            // 
            // frmHouseholdAssessmentMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tlpDisplay01);
            this.Controls.Add(this.gbMembers);
            this.Controls.Add(this.tplButton01);
            this.Controls.Add(this.llblBackTop);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHouseholdAssessmentMember";
            this.Size = new System.Drawing.Size(1213, 800);
            this.Load += new System.EventHandler(this.frmHouseholdAssessmentMember_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmHouseholdAssessmentMember_Paint);
            this.gbMembers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.tplButton01.ResumeLayout(false);
            this.tplButton01.PerformLayout();
            this.tlpDisplay01.ResumeLayout(false);
            this.tlpDisplay01.PerformLayout();
            this.pnlMemberType.ResumeLayout(false);
            this.pnlMemberType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMembers;
        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel llblBackTop;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay01;
        private System.Windows.Forms.Label lblHouseholdCodeDisplay;
        private System.Windows.Forms.Label lblHouseholdCode;
        private System.Windows.Forms.Label lblMemberNumber;
        private System.Windows.Forms.Label lblMemberNumberDisplay;
        private System.Windows.Forms.Label lblFirstNameVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLastNameVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.ComboBox cbYearOfBirth;
        private System.Windows.Forms.ComboBox cbBirthRegistration;
        private System.Windows.Forms.ComboBox cbDisability;
        private System.Windows.Forms.ComboBox cbHIVStatus;
        private System.Windows.Forms.ComboBox cbProfession;
        private System.Windows.Forms.ComboBox cbSchool;
        private System.Windows.Forms.ComboBox cbProtection;
        private System.Windows.Forms.ComboBox cbPregnant;
        private System.Windows.Forms.ComboBox cbMaritalStatus;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.ComboBox cbImmunize;
        private System.Windows.Forms.ComboBox cbDisabilityType;
        private System.Windows.Forms.ComboBox cbART;
        private System.Windows.Forms.ComboBox cbEducation;
        private System.Windows.Forms.ComboBox cbGivenBirth;
        private System.Windows.Forms.Label lblGivenBirth;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblImmunize;
        private System.Windows.Forms.Label lblDisabilityType;
        private System.Windows.Forms.Label lblART;
        private System.Windows.Forms.Label lblEducation;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblYearOfBirth;
        private System.Windows.Forms.Label lblBirthRegistration;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblHIVStatus;
        private System.Windows.Forms.Label lblProfession;
        private System.Windows.Forms.Label lblSchool;
        private System.Windows.Forms.Label lblProtection;
        private System.Windows.Forms.Label lblPregnant;
        private System.Windows.Forms.Label lblMaritalStatus;
        private System.Windows.Forms.Label lblMemberType;
        private System.Windows.Forms.Label lblHHMember;
        private System.Windows.Forms.ComboBox cbHHMember;
        private System.Windows.Forms.Label lblHHMemberVal;
        private System.Windows.Forms.Panel pnlMemberType;
        private System.Windows.Forms.RadioButton rbtnMemberTypeExisting;
        private System.Windows.Forms.RadioButton rbtnMemberTypeNew;
        private System.Windows.Forms.CheckBox chkHeadOfHousehold;
        private System.Windows.Forms.CheckBox chkCaregiver;
        private System.Windows.Forms.Label lblHAMId;
        private System.Windows.Forms.LinkLabel llblBackBottom;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclYearOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclOfcId;
        private System.Windows.Forms.ComboBox cbAttainedVocationalSkill;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}
