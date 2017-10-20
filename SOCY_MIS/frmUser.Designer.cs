namespace SOCY_MIS
{
    partial class frmUser
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
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstNameVal = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblLastNameVal = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.cbTitle = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEmailVal = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtSkype = new System.Windows.Forms.TextBox();
            this.lblSkype = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.lblPasswordConfirmVal = new System.Windows.Forms.Label();
            this.txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.lblPasswordConfirm = new System.Windows.Forms.Label();
            this.lblPasswordVal = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.chkPasswordChange = new System.Windows.Forms.CheckBox();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.gbUserManagement = new System.Windows.Forms.GroupBox();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.llblRole = new System.Windows.Forms.LinkLabel();
            this.llblBack = new System.Windows.Forms.LinkLabel();
            this.gbUserManagement.SuspendLayout();
            this.tplButton01.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(4, 45);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(80, 17);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(204, 42);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(201, 23);
            this.txtFirstName.TabIndex = 1;
            // 
            // lblFirstNameVal
            // 
            this.lblFirstNameVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFirstNameVal.AutoSize = true;
            this.lblFirstNameVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstNameVal.ForeColor = System.Drawing.Color.Red;
            this.lblFirstNameVal.Location = new System.Drawing.Point(413, 45);
            this.lblFirstNameVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstNameVal.Name = "lblFirstNameVal";
            this.lblFirstNameVal.Size = new System.Drawing.Size(13, 17);
            this.lblFirstNameVal.TabIndex = 20;
            this.lblFirstNameVal.Text = "*";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(466, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(305, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblLastNameVal
            // 
            this.lblLastNameVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLastNameVal.AutoSize = true;
            this.lblLastNameVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastNameVal.ForeColor = System.Drawing.Color.Red;
            this.lblLastNameVal.Location = new System.Drawing.Point(849, 45);
            this.lblLastNameVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastNameVal.Name = "lblLastNameVal";
            this.lblLastNameVal.Size = new System.Drawing.Size(13, 17);
            this.lblLastNameVal.TabIndex = 25;
            this.lblLastNameVal.Text = "*";
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(640, 42);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(201, 23);
            this.txtLastName.TabIndex = 24;
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(440, 45);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(80, 17);
            this.lblLastName.TabIndex = 23;
            this.lblLastName.Text = "Last Name:";
            // 
            // cbTitle
            // 
            this.cbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTitle.FormattingEnabled = true;
            this.cbTitle.Location = new System.Drawing.Point(204, 5);
            this.cbTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbTitle.Name = "cbTitle";
            this.cbTitle.Size = new System.Drawing.Size(201, 25);
            this.cbTitle.TabIndex = 27;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(4, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(39, 17);
            this.lblTitle.TabIndex = 26;
            this.lblTitle.Text = "Title:";
            // 
            // lblEmailVal
            // 
            this.lblEmailVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEmailVal.AutoSize = true;
            this.lblEmailVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailVal.ForeColor = System.Drawing.Color.Red;
            this.lblEmailVal.Location = new System.Drawing.Point(413, 81);
            this.lblEmailVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmailVal.Name = "lblEmailVal";
            this.lblEmailVal.Size = new System.Drawing.Size(13, 17);
            this.lblEmailVal.TabIndex = 30;
            this.lblEmailVal.Text = "*";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(204, 78);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(201, 23);
            this.txtEmail.TabIndex = 29;
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(4, 81);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 17);
            this.lblEmail.TabIndex = 28;
            this.lblEmail.Text = "Email:";
            // 
            // txtPosition
            // 
            this.txtPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosition.Location = new System.Drawing.Point(640, 114);
            this.txtPosition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(201, 23);
            this.txtPosition.TabIndex = 38;
            // 
            // lblPosition
            // 
            this.lblPosition.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(440, 117);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(62, 17);
            this.lblPosition.TabIndex = 37;
            this.lblPosition.Text = "Position:";
            // 
            // txtSkype
            // 
            this.txtSkype.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSkype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSkype.Location = new System.Drawing.Point(204, 114);
            this.txtSkype.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSkype.Name = "txtSkype";
            this.txtSkype.Size = new System.Drawing.Size(201, 23);
            this.txtSkype.TabIndex = 35;
            // 
            // lblSkype
            // 
            this.lblSkype.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSkype.AutoSize = true;
            this.lblSkype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkype.Location = new System.Drawing.Point(4, 117);
            this.lblSkype.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSkype.Name = "lblSkype";
            this.lblSkype.Size = new System.Drawing.Size(51, 17);
            this.lblSkype.TabIndex = 34;
            this.lblSkype.Text = "Skype:";
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(640, 78);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(201, 23);
            this.txtPhone.TabIndex = 32;
            // 
            // lblPhone
            // 
            this.lblPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(440, 81);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(53, 17);
            this.lblPhone.TabIndex = 31;
            this.lblPhone.Text = "Phone:";
            // 
            // chkActive
            // 
            this.chkActive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.Location = new System.Drawing.Point(204, 151);
            this.chkActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(68, 21);
            this.chkActive.TabIndex = 40;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // lblPasswordConfirmVal
            // 
            this.lblPasswordConfirmVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPasswordConfirmVal.AutoSize = true;
            this.lblPasswordConfirmVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordConfirmVal.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordConfirmVal.Location = new System.Drawing.Point(849, 265);
            this.lblPasswordConfirmVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPasswordConfirmVal.Name = "lblPasswordConfirmVal";
            this.lblPasswordConfirmVal.Size = new System.Drawing.Size(13, 17);
            this.lblPasswordConfirmVal.TabIndex = 46;
            this.lblPasswordConfirmVal.Text = "*";
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPasswordConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordConfirm.Location = new System.Drawing.Point(640, 262);
            this.txtPasswordConfirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.PasswordChar = '*';
            this.txtPasswordConfirm.Size = new System.Drawing.Size(201, 23);
            this.txtPasswordConfirm.TabIndex = 45;
            // 
            // lblPasswordConfirm
            // 
            this.lblPasswordConfirm.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPasswordConfirm.AutoSize = true;
            this.lblPasswordConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordConfirm.Location = new System.Drawing.Point(440, 265);
            this.lblPasswordConfirm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPasswordConfirm.Name = "lblPasswordConfirm";
            this.lblPasswordConfirm.Size = new System.Drawing.Size(125, 17);
            this.lblPasswordConfirm.TabIndex = 44;
            this.lblPasswordConfirm.Text = "Confirm Password:";
            // 
            // lblPasswordVal
            // 
            this.lblPasswordVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPasswordVal.AutoSize = true;
            this.lblPasswordVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordVal.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordVal.Location = new System.Drawing.Point(413, 265);
            this.lblPasswordVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPasswordVal.Name = "lblPasswordVal";
            this.lblPasswordVal.Size = new System.Drawing.Size(13, 17);
            this.lblPasswordVal.TabIndex = 43;
            this.lblPasswordVal.Text = "*";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(204, 262);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(201, 23);
            this.txtPassword.TabIndex = 42;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(4, 265);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 17);
            this.lblPassword.TabIndex = 41;
            this.lblPassword.Text = "Password:";
            // 
            // chkPasswordChange
            // 
            this.chkPasswordChange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkPasswordChange.AutoSize = true;
            this.chkPasswordChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPasswordChange.Location = new System.Drawing.Point(204, 223);
            this.chkPasswordChange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkPasswordChange.Name = "chkPasswordChange";
            this.chkPasswordChange.Size = new System.Drawing.Size(144, 21);
            this.chkPasswordChange.TabIndex = 47;
            this.chkPasswordChange.Text = "Change Password";
            this.chkPasswordChange.UseVisualStyleBackColor = true;
            this.chkPasswordChange.CheckedChanged += new System.EventHandler(this.chkPasswordChange_CheckedChanged);
            // 
            // cbLanguage
            // 
            this.cbLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Location = new System.Drawing.Point(640, 149);
            this.cbLanguage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(201, 25);
            this.cbLanguage.TabIndex = 48;
            // 
            // lblLanguage
            // 
            this.lblLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguage.Location = new System.Drawing.Point(440, 153);
            this.lblLanguage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(125, 17);
            this.lblLanguage.TabIndex = 49;
            this.lblLanguage.Text = "Default Language:";
            // 
            // gbUserManagement
            // 
            this.gbUserManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUserManagement.Controls.Add(this.tplButton01);
            this.gbUserManagement.Controls.Add(this.tableLayoutPanel1);
            this.gbUserManagement.Controls.Add(this.llblRole);
            this.gbUserManagement.Controls.Add(this.llblBack);
            this.gbUserManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUserManagement.Location = new System.Drawing.Point(4, 7);
            this.gbUserManagement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbUserManagement.Name = "gbUserManagement";
            this.gbUserManagement.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbUserManagement.Size = new System.Drawing.Size(952, 612);
            this.gbUserManagement.TabIndex = 50;
            this.gbUserManagement.TabStop = false;
            this.gbUserManagement.Text = "User Management";
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
            this.tplButton01.Size = new System.Drawing.Size(872, 49);
            this.tplButton01.TabIndex = 53;
            this.tplButton01.Paint += new System.Windows.Forms.PaintEventHandler(this.tplButton01_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFirstNameVal, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPasswordConfirmVal, 5, 7);
            this.tableLayoutPanel1.Controls.Add(this.cbLanguage, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPasswordConfirm, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblPasswordConfirm, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblLanguage, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtFirstName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFirstName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLastName, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPasswordVal, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtLastName, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblLastNameVal, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPassword, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtPhone, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblPhone, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblEmailVal, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblEmail, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSkype, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtPosition, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkActive, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblPosition, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtSkype, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkPasswordChange, 1, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(40, 37);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(872, 295);
            this.tableLayoutPanel1.TabIndex = 52;
            // 
            // llblRole
            // 
            this.llblRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblRole.AutoSize = true;
            this.llblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblRole.Location = new System.Drawing.Point(815, 20);
            this.llblRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblRole.Name = "llblRole";
            this.llblRole.Size = new System.Drawing.Size(78, 17);
            this.llblRole.TabIndex = 51;
            this.llblRole.TabStop = true;
            this.llblRole.Text = "User Roles";
            this.llblRole.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRole_LinkClicked);
            // 
            // llblBack
            // 
            this.llblBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblBack.AutoSize = true;
            this.llblBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblBack.Location = new System.Drawing.Point(901, 20);
            this.llblBack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblBack.Name = "llblBack";
            this.llblBack.Size = new System.Drawing.Size(39, 17);
            this.llblBack.TabIndex = 50;
            this.llblBack.TabStop = true;
            this.llblBack.Text = "Back";
            this.llblBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblBack_LinkClicked);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbUserManagement);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmUser";
            this.Size = new System.Drawing.Size(960, 619);
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.gbUserManagement.ResumeLayout(false);
            this.gbUserManagement.PerformLayout();
            this.tplButton01.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstNameVal;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblLastNameVal;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.ComboBox cbTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmailVal;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox txtSkype;
        private System.Windows.Forms.Label lblSkype;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label lblPasswordConfirmVal;
        private System.Windows.Forms.TextBox txtPasswordConfirm;
        private System.Windows.Forms.Label lblPasswordConfirm;
        private System.Windows.Forms.Label lblPasswordVal;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.CheckBox chkPasswordChange;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.GroupBox gbUserManagement;
        private System.Windows.Forms.LinkLabel llblBack;
        private System.Windows.Forms.LinkLabel llblRole;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tplButton01;

    }
}
