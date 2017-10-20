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
            this.lblProtection = new System.Windows.Forms.Label();
            this.lblSchool = new System.Windows.Forms.Label();
            this.lblProfession = new System.Windows.Forms.Label();
            this.lblHIVStatus = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblBirthRegistration = new System.Windows.Forms.Label();
            this.lblYearOfBirth = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.cbMaritalStatus = new System.Windows.Forms.ComboBox();
            this.cbPregnant = new System.Windows.Forms.ComboBox();
            this.cbProtection = new System.Windows.Forms.ComboBox();
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
            this.gbMembers.Location = new System.Drawing.Point(3, 453);
            this.gbMembers.Name = "gbMembers";
            this.gbMembers.Size = new System.Drawing.Size(904, 197);
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
            this.dgvMembers.Location = new System.Drawing.Point(6, 19);
            this.dgvMembers.MultiSelect = false;
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.Size = new System.Drawing.Size(892, 172);
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
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplButton01.Controls.Add(this.btnSave, 0, 0);
            this.tplButton01.Controls.Add(this.btnCancel, 2, 0);
            this.tplButton01.Controls.Add(this.llblBackBottom, 3, 0);
            this.tplButton01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tplButton01.Location = new System.Drawing.Point(3, 407);
            this.tplButton01.Name = "tplButton01";
            this.tplButton01.RowCount = 1;
            this.tplButton01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplButton01.Size = new System.Drawing.Size(904, 40);
            this.tplButton01.TabIndex = 20;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(334, 8);
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
            this.btnCancel.Location = new System.Drawing.Point(455, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
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
            this.llblBackBottom.Location = new System.Drawing.Point(869, 13);
            this.llblBackBottom.Name = "llblBackBottom";
            this.llblBackBottom.Size = new System.Drawing.Size(32, 13);
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
            this.llblBackTop.Location = new System.Drawing.Point(869, 1);
            this.llblBackTop.Name = "llblBackTop";
            this.llblBackTop.Size = new System.Drawing.Size(32, 13);
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
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
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
            this.tlpDisplay01.Controls.Add(this.lblProtection, 0, 10);
            this.tlpDisplay01.Controls.Add(this.lblSchool, 0, 9);
            this.tlpDisplay01.Controls.Add(this.lblProfession, 0, 8);
            this.tlpDisplay01.Controls.Add(this.lblHIVStatus, 0, 7);
            this.tlpDisplay01.Controls.Add(this.label14, 0, 6);
            this.tlpDisplay01.Controls.Add(this.lblBirthRegistration, 0, 5);
            this.tlpDisplay01.Controls.Add(this.lblYearOfBirth, 0, 4);
            this.tlpDisplay01.Controls.Add(this.lblFirstName, 0, 3);
            this.tlpDisplay01.Controls.Add(this.cbMaritalStatus, 1, 12);
            this.tlpDisplay01.Controls.Add(this.cbPregnant, 1, 11);
            this.tlpDisplay01.Controls.Add(this.cbProtection, 1, 10);
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
            this.tlpDisplay01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpDisplay01.Location = new System.Drawing.Point(3, 18);
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
            this.tlpDisplay01.Size = new System.Drawing.Size(904, 390);
            this.tlpDisplay01.TabIndex = 46;
            // 
            // chkCaregiver
            // 
            this.chkCaregiver.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkCaregiver.AutoSize = true;
            this.chkCaregiver.Enabled = false;
            this.chkCaregiver.Location = new System.Drawing.Point(605, 66);
            this.chkCaregiver.Name = "chkCaregiver";
            this.chkCaregiver.Size = new System.Drawing.Size(71, 17);
            this.chkCaregiver.TabIndex = 51;
            this.chkCaregiver.Text = "Caregiver";
            this.chkCaregiver.UseVisualStyleBackColor = true;
            // 
            // lblHouseholdCodeDisplay
            // 
            this.lblHouseholdCodeDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHouseholdCodeDisplay.AutoSize = true;
            this.lblHouseholdCodeDisplay.Location = new System.Drawing.Point(153, 8);
            this.lblHouseholdCodeDisplay.Name = "lblHouseholdCodeDisplay";
            this.lblHouseholdCodeDisplay.Size = new System.Drawing.Size(59, 13);
            this.lblHouseholdCodeDisplay.TabIndex = 16;
            this.lblHouseholdCodeDisplay.Text = "HH000000";
            // 
            // chkHeadOfHousehold
            // 
            this.chkHeadOfHousehold.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkHeadOfHousehold.AutoSize = true;
            this.chkHeadOfHousehold.Enabled = false;
            this.chkHeadOfHousehold.Location = new System.Drawing.Point(153, 66);
            this.chkHeadOfHousehold.Name = "chkHeadOfHousehold";
            this.chkHeadOfHousehold.Size = new System.Drawing.Size(118, 17);
            this.chkHeadOfHousehold.TabIndex = 50;
            this.chkHeadOfHousehold.Text = "Head of Household";
            this.chkHeadOfHousehold.UseVisualStyleBackColor = true;
            // 
            // lblHouseholdCode
            // 
            this.lblHouseholdCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHouseholdCode.AutoSize = true;
            this.lblHouseholdCode.Location = new System.Drawing.Point(3, 8);
            this.lblHouseholdCode.Name = "lblHouseholdCode";
            this.lblHouseholdCode.Size = new System.Drawing.Size(89, 13);
            this.lblHouseholdCode.TabIndex = 0;
            this.lblHouseholdCode.Text = "Household Code:";
            // 
            // lblMemberNumber
            // 
            this.lblMemberNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMemberNumber.AutoSize = true;
            this.lblMemberNumber.Location = new System.Drawing.Point(455, 8);
            this.lblMemberNumber.Name = "lblMemberNumber";
            this.lblMemberNumber.Size = new System.Drawing.Size(88, 13);
            this.lblMemberNumber.TabIndex = 4;
            this.lblMemberNumber.Text = "Member Number:";
            // 
            // lblMemberNumberDisplay
            // 
            this.lblMemberNumberDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMemberNumberDisplay.AutoSize = true;
            this.lblMemberNumberDisplay.Location = new System.Drawing.Point(605, 8);
            this.lblMemberNumberDisplay.Name = "lblMemberNumberDisplay";
            this.lblMemberNumberDisplay.Size = new System.Drawing.Size(13, 13);
            this.lblMemberNumberDisplay.TabIndex = 1;
            this.lblMemberNumberDisplay.Text = "1";
            // 
            // lblMemberType
            // 
            this.lblMemberType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMemberType.AutoSize = true;
            this.lblMemberType.Location = new System.Drawing.Point(455, 38);
            this.lblMemberType.Name = "lblMemberType";
            this.lblMemberType.Size = new System.Drawing.Size(75, 13);
            this.lblMemberType.TabIndex = 45;
            this.lblMemberType.Text = "Member Type:";
            // 
            // lblHHMember
            // 
            this.lblHHMember.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHHMember.AutoSize = true;
            this.lblHHMember.Location = new System.Drawing.Point(3, 38);
            this.lblHHMember.Name = "lblHHMember";
            this.lblHHMember.Size = new System.Drawing.Size(102, 13);
            this.lblHHMember.TabIndex = 46;
            this.lblHHMember.Text = "Household Member:";
            // 
            // cbHHMember
            // 
            this.cbHHMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHHMember.FormattingEnabled = true;
            this.cbHHMember.Location = new System.Drawing.Point(153, 34);
            this.cbHHMember.Name = "cbHHMember";
            this.cbHHMember.Size = new System.Drawing.Size(256, 21);
            this.cbHHMember.TabIndex = 47;
            this.cbHHMember.SelectionChangeCommitted += new System.EventHandler(this.cbHHMember_SelectionChangeCommitted);
            // 
            // pnlMemberType
            // 
            this.pnlMemberType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlMemberType.Controls.Add(this.rbtnMemberTypeExisting);
            this.pnlMemberType.Controls.Add(this.rbtnMemberTypeNew);
            this.pnlMemberType.Location = new System.Drawing.Point(605, 35);
            this.pnlMemberType.Name = "pnlMemberType";
            this.pnlMemberType.Size = new System.Drawing.Size(200, 19);
            this.pnlMemberType.TabIndex = 49;
            // 
            // rbtnMemberTypeExisting
            // 
            this.rbtnMemberTypeExisting.AutoSize = true;
            this.rbtnMemberTypeExisting.Checked = true;
            this.rbtnMemberTypeExisting.Location = new System.Drawing.Point(3, 1);
            this.rbtnMemberTypeExisting.Name = "rbtnMemberTypeExisting";
            this.rbtnMemberTypeExisting.Size = new System.Drawing.Size(61, 17);
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
            this.rbtnMemberTypeNew.Location = new System.Drawing.Point(70, 1);
            this.rbtnMemberTypeNew.Name = "rbtnMemberTypeNew";
            this.rbtnMemberTypeNew.Size = new System.Drawing.Size(47, 17);
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
            this.lblHHMemberVal.Location = new System.Drawing.Point(415, 38);
            this.lblHHMemberVal.Name = "lblHHMemberVal";
            this.lblHHMemberVal.Size = new System.Drawing.Size(11, 13);
            this.lblHHMemberVal.TabIndex = 48;
            this.lblHHMemberVal.Text = "*";
            // 
            // lblMaritalStatus
            // 
            this.lblMaritalStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMaritalStatus.AutoSize = true;
            this.lblMaritalStatus.Location = new System.Drawing.Point(3, 368);
            this.lblMaritalStatus.Name = "lblMaritalStatus";
            this.lblMaritalStatus.Size = new System.Drawing.Size(74, 13);
            this.lblMaritalStatus.TabIndex = 35;
            this.lblMaritalStatus.Text = "Marital Status:";
            // 
            // lblPregnant
            // 
            this.lblPregnant.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPregnant.AutoSize = true;
            this.lblPregnant.Location = new System.Drawing.Point(3, 338);
            this.lblPregnant.Name = "lblPregnant";
            this.lblPregnant.Size = new System.Drawing.Size(97, 13);
            this.lblPregnant.TabIndex = 34;
            this.lblPregnant.Text = "Currently Pregnant:";
            // 
            // lblProtection
            // 
            this.lblProtection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblProtection.AutoSize = true;
            this.lblProtection.Location = new System.Drawing.Point(3, 308);
            this.lblProtection.Name = "lblProtection";
            this.lblProtection.Size = new System.Drawing.Size(58, 13);
            this.lblProtection.TabIndex = 20;
            this.lblProtection.Text = "Protection:";
            // 
            // lblSchool
            // 
            this.lblSchool.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSchool.AutoSize = true;
            this.lblSchool.Location = new System.Drawing.Point(3, 278);
            this.lblSchool.Name = "lblSchool";
            this.lblSchool.Size = new System.Drawing.Size(82, 13);
            this.lblSchool.TabIndex = 11;
            this.lblSchool.Text = "Attends School:";
            // 
            // lblProfession
            // 
            this.lblProfession.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblProfession.AutoSize = true;
            this.lblProfession.Location = new System.Drawing.Point(3, 248);
            this.lblProfession.Name = "lblProfession";
            this.lblProfession.Size = new System.Drawing.Size(59, 13);
            this.lblProfession.TabIndex = 5;
            this.lblProfession.Text = "Profession:";
            // 
            // lblHIVStatus
            // 
            this.lblHIVStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHIVStatus.AutoSize = true;
            this.lblHIVStatus.Location = new System.Drawing.Point(3, 218);
            this.lblHIVStatus.Name = "lblHIVStatus";
            this.lblHIVStatus.Size = new System.Drawing.Size(61, 13);
            this.lblHIVStatus.TabIndex = 9;
            this.lblHIVStatus.Text = "HIV Status:";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 188);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Disability:";
            // 
            // lblBirthRegistration
            // 
            this.lblBirthRegistration.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBirthRegistration.AutoSize = true;
            this.lblBirthRegistration.Location = new System.Drawing.Point(3, 158);
            this.lblBirthRegistration.Name = "lblBirthRegistration";
            this.lblBirthRegistration.Size = new System.Drawing.Size(90, 13);
            this.lblBirthRegistration.TabIndex = 14;
            this.lblBirthRegistration.Text = "Birth Registration:";
            // 
            // lblYearOfBirth
            // 
            this.lblYearOfBirth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblYearOfBirth.AutoSize = true;
            this.lblYearOfBirth.Location = new System.Drawing.Point(3, 128);
            this.lblYearOfBirth.Name = "lblYearOfBirth";
            this.lblYearOfBirth.Size = new System.Drawing.Size(68, 13);
            this.lblYearOfBirth.TabIndex = 10;
            this.lblYearOfBirth.Text = "Year of Birth:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(3, 98);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 8;
            this.lblFirstName.Text = "First Name:";
            // 
            // cbMaritalStatus
            // 
            this.cbMaritalStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMaritalStatus.FormattingEnabled = true;
            this.cbMaritalStatus.Location = new System.Drawing.Point(153, 364);
            this.cbMaritalStatus.Name = "cbMaritalStatus";
            this.cbMaritalStatus.Size = new System.Drawing.Size(256, 21);
            this.cbMaritalStatus.TabIndex = 39;
            // 
            // cbPregnant
            // 
            this.cbPregnant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPregnant.FormattingEnabled = true;
            this.cbPregnant.Location = new System.Drawing.Point(153, 334);
            this.cbPregnant.Name = "cbPregnant";
            this.cbPregnant.Size = new System.Drawing.Size(256, 21);
            this.cbPregnant.TabIndex = 37;
            // 
            // cbProtection
            // 
            this.cbProtection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProtection.FormattingEnabled = true;
            this.cbProtection.Location = new System.Drawing.Point(153, 304);
            this.cbProtection.Name = "cbProtection";
            this.cbProtection.Size = new System.Drawing.Size(256, 21);
            this.cbProtection.TabIndex = 22;
            // 
            // cbSchool
            // 
            this.cbSchool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSchool.FormattingEnabled = true;
            this.cbSchool.Location = new System.Drawing.Point(153, 274);
            this.cbSchool.Name = "cbSchool";
            this.cbSchool.Size = new System.Drawing.Size(256, 21);
            this.cbSchool.TabIndex = 33;
            // 
            // cbProfession
            // 
            this.cbProfession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProfession.FormattingEnabled = true;
            this.cbProfession.Location = new System.Drawing.Point(153, 244);
            this.cbProfession.Name = "cbProfession";
            this.cbProfession.Size = new System.Drawing.Size(256, 21);
            this.cbProfession.TabIndex = 22;
            // 
            // cbHIVStatus
            // 
            this.cbHIVStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHIVStatus.FormattingEnabled = true;
            this.cbHIVStatus.Location = new System.Drawing.Point(153, 214);
            this.cbHIVStatus.Name = "cbHIVStatus";
            this.cbHIVStatus.Size = new System.Drawing.Size(256, 21);
            this.cbHIVStatus.TabIndex = 23;
            this.cbHIVStatus.SelectionChangeCommitted += new System.EventHandler(this.cbHIVStatus_SelectionChangeCommitted);
            // 
            // cbDisability
            // 
            this.cbDisability.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDisability.FormattingEnabled = true;
            this.cbDisability.Location = new System.Drawing.Point(153, 184);
            this.cbDisability.Name = "cbDisability";
            this.cbDisability.Size = new System.Drawing.Size(256, 21);
            this.cbDisability.TabIndex = 22;
            this.cbDisability.SelectionChangeCommitted += new System.EventHandler(this.cbDisability_SelectionChangeCommitted);
            // 
            // cbBirthRegistration
            // 
            this.cbBirthRegistration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBirthRegistration.FormattingEnabled = true;
            this.cbBirthRegistration.Location = new System.Drawing.Point(153, 154);
            this.cbBirthRegistration.Name = "cbBirthRegistration";
            this.cbBirthRegistration.Size = new System.Drawing.Size(256, 21);
            this.cbBirthRegistration.TabIndex = 22;
            // 
            // cbYearOfBirth
            // 
            this.cbYearOfBirth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbYearOfBirth.FormattingEnabled = true;
            this.cbYearOfBirth.Location = new System.Drawing.Point(153, 124);
            this.cbYearOfBirth.Name = "cbYearOfBirth";
            this.cbYearOfBirth.Size = new System.Drawing.Size(86, 21);
            this.cbYearOfBirth.TabIndex = 26;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Location = new System.Drawing.Point(153, 95);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(256, 20);
            this.txtFirstName.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(415, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "*";
            // 
            // lblFirstNameVal
            // 
            this.lblFirstNameVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFirstNameVal.AutoSize = true;
            this.lblFirstNameVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstNameVal.ForeColor = System.Drawing.Color.Red;
            this.lblFirstNameVal.Location = new System.Drawing.Point(415, 98);
            this.lblFirstNameVal.Name = "lblFirstNameVal";
            this.lblFirstNameVal.Size = new System.Drawing.Size(11, 13);
            this.lblFirstNameVal.TabIndex = 29;
            this.lblFirstNameVal.Text = "*";
            // 
            // lblGivenBirth
            // 
            this.lblGivenBirth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGivenBirth.AutoSize = true;
            this.lblGivenBirth.Location = new System.Drawing.Point(455, 338);
            this.lblGivenBirth.Name = "lblGivenBirth";
            this.lblGivenBirth.Size = new System.Drawing.Size(84, 13);
            this.lblGivenBirth.TabIndex = 36;
            this.lblGivenBirth.Text = "Ever given birth:";
            // 
            // lblEducation
            // 
            this.lblEducation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEducation.AutoSize = true;
            this.lblEducation.Location = new System.Drawing.Point(455, 278);
            this.lblEducation.Name = "lblEducation";
            this.lblEducation.Size = new System.Drawing.Size(140, 13);
            this.lblEducation.TabIndex = 18;
            this.lblEducation.Text = "Education Level Completed:";
            // 
            // lblART
            // 
            this.lblART.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblART.AutoSize = true;
            this.lblART.Location = new System.Drawing.Point(455, 218);
            this.lblART.Name = "lblART";
            this.lblART.Size = new System.Drawing.Size(32, 13);
            this.lblART.TabIndex = 7;
            this.lblART.Text = "ART:";
            // 
            // lblDisabilityType
            // 
            this.lblDisabilityType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisabilityType.AutoSize = true;
            this.lblDisabilityType.Location = new System.Drawing.Point(455, 188);
            this.lblDisabilityType.Name = "lblDisabilityType";
            this.lblDisabilityType.Size = new System.Drawing.Size(78, 13);
            this.lblDisabilityType.TabIndex = 24;
            this.lblDisabilityType.Text = "Disability Type:";
            // 
            // lblImmunize
            // 
            this.lblImmunize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImmunize.AutoSize = true;
            this.lblImmunize.Location = new System.Drawing.Point(455, 158);
            this.lblImmunize.Name = "lblImmunize";
            this.lblImmunize.Size = new System.Drawing.Size(54, 13);
            this.lblImmunize.TabIndex = 3;
            this.lblImmunize.Text = "Immunize:";
            // 
            // lblGender
            // 
            this.lblGender.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(455, 128);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(28, 13);
            this.lblGender.TabIndex = 12;
            this.lblGender.Text = "Sex:";
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(455, 98);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 44;
            this.lblLastName.Text = "Last Name:";
            // 
            // cbGivenBirth
            // 
            this.cbGivenBirth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGivenBirth.FormattingEnabled = true;
            this.cbGivenBirth.Location = new System.Drawing.Point(605, 334);
            this.cbGivenBirth.Name = "cbGivenBirth";
            this.cbGivenBirth.Size = new System.Drawing.Size(256, 21);
            this.cbGivenBirth.TabIndex = 38;
            // 
            // cbEducation
            // 
            this.cbEducation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEducation.FormattingEnabled = true;
            this.cbEducation.Location = new System.Drawing.Point(605, 274);
            this.cbEducation.Name = "cbEducation";
            this.cbEducation.Size = new System.Drawing.Size(256, 21);
            this.cbEducation.TabIndex = 32;
            // 
            // cbART
            // 
            this.cbART.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbART.FormattingEnabled = true;
            this.cbART.Location = new System.Drawing.Point(605, 214);
            this.cbART.Name = "cbART";
            this.cbART.Size = new System.Drawing.Size(256, 21);
            this.cbART.TabIndex = 22;
            // 
            // cbDisabilityType
            // 
            this.cbDisabilityType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDisabilityType.Enabled = false;
            this.cbDisabilityType.FormattingEnabled = true;
            this.cbDisabilityType.Location = new System.Drawing.Point(605, 184);
            this.cbDisabilityType.Name = "cbDisabilityType";
            this.cbDisabilityType.Size = new System.Drawing.Size(256, 21);
            this.cbDisabilityType.TabIndex = 25;
            // 
            // cbImmunize
            // 
            this.cbImmunize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbImmunize.FormattingEnabled = true;
            this.cbImmunize.Location = new System.Drawing.Point(605, 154);
            this.cbImmunize.Name = "cbImmunize";
            this.cbImmunize.Size = new System.Drawing.Size(256, 21);
            this.cbImmunize.TabIndex = 22;
            // 
            // cbGender
            // 
            this.cbGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Location = new System.Drawing.Point(605, 124);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(256, 21);
            this.cbGender.TabIndex = 21;
            this.cbGender.SelectionChangeCommitted += new System.EventHandler(this.cbGender_SelectionChangeCommitted);
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Location = new System.Drawing.Point(605, 95);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(256, 20);
            this.txtLastName.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(867, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "*";
            // 
            // lblLastNameVal
            // 
            this.lblLastNameVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLastNameVal.AutoSize = true;
            this.lblLastNameVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastNameVal.ForeColor = System.Drawing.Color.Red;
            this.lblLastNameVal.Location = new System.Drawing.Point(867, 98);
            this.lblLastNameVal.Name = "lblLastNameVal";
            this.lblLastNameVal.Size = new System.Drawing.Size(11, 13);
            this.lblLastNameVal.TabIndex = 43;
            this.lblLastNameVal.Text = "*";
            // 
            // lblHAMId
            // 
            this.lblHAMId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHAMId.AutoSize = true;
            this.lblHAMId.Location = new System.Drawing.Point(3, 68);
            this.lblHAMId.Name = "lblHAMId";
            this.lblHAMId.Size = new System.Drawing.Size(10, 13);
            this.lblHAMId.TabIndex = 52;
            this.lblHAMId.Text = "-";
            this.lblHAMId.Visible = false;
            // 
            // frmHouseholdAssessmentMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tlpDisplay01);
            this.Controls.Add(this.gbMembers);
            this.Controls.Add(this.tplButton01);
            this.Controls.Add(this.llblBackTop);
            this.Name = "frmHouseholdAssessmentMember";
            this.Size = new System.Drawing.Size(910, 650);
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
    }
}
