namespace SOCY_MIS
{
    partial class frmSocialWorkerSearch
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
            this.gbSocialWorkerSearch = new System.Windows.Forms.GroupBox();
            this.llblNewParaSocialWorker = new System.Windows.Forms.LinkLabel();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.cbDistrict = new System.Windows.Forms.ComboBox();
            this.lblSubCounty = new System.Windows.Forms.Label();
            this.cbSubCounty = new System.Windows.Forms.ComboBox();
            this.cbWard = new System.Windows.Forms.ComboBox();
            this.lblWard = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSocialWorker = new System.Windows.Forms.Label();
            this.cbSocialWorker = new System.Windows.Forms.ComboBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.llblNewSocialWorker = new System.Windows.Forms.LinkLabel();
            this.dgvSocialWorker = new System.Windows.Forms.DataGridView();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSocialWorkerType = new System.Windows.Forms.Label();
            this.cbSocialWorkerType = new System.Windows.Forms.ComboBox();
            this.gbSocialWorkerSearch.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocialWorker)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSocialWorkerSearch
            // 
            this.gbSocialWorkerSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSocialWorkerSearch.Controls.Add(this.llblNewParaSocialWorker);
            this.gbSocialWorkerSearch.Controls.Add(this.tableLayoutPanel2);
            this.gbSocialWorkerSearch.Controls.Add(this.tableLayoutPanel3);
            this.gbSocialWorkerSearch.Controls.Add(this.llblNewSocialWorker);
            this.gbSocialWorkerSearch.Controls.Add(this.dgvSocialWorker);
            this.gbSocialWorkerSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSocialWorkerSearch.Location = new System.Drawing.Point(3, 6);
            this.gbSocialWorkerSearch.Name = "gbSocialWorkerSearch";
            this.gbSocialWorkerSearch.Size = new System.Drawing.Size(904, 511);
            this.gbSocialWorkerSearch.TabIndex = 3;
            this.gbSocialWorkerSearch.TabStop = false;
            this.gbSocialWorkerSearch.Text = "Social Worker Search";
            // 
            // llblNewParaSocialWorker
            // 
            this.llblNewParaSocialWorker.AutoSize = true;
            this.llblNewParaSocialWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblNewParaSocialWorker.Location = new System.Drawing.Point(134, 20);
            this.llblNewParaSocialWorker.Name = "llblNewParaSocialWorker";
            this.llblNewParaSocialWorker.Size = new System.Drawing.Size(124, 13);
            this.llblNewParaSocialWorker.TabIndex = 37;
            this.llblNewParaSocialWorker.TabStop = true;
            this.llblNewParaSocialWorker.Text = "New Para Social Worker";
            this.llblNewParaSocialWorker.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblNewParaSocialWorker_LinkClicked);
            // 
            // lblDistrict
            // 
            this.lblDistrict.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistrict.Location = new System.Drawing.Point(3, 68);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(42, 13);
            this.lblDistrict.TabIndex = 11;
            this.lblDistrict.Text = "District:";
            // 
            // cbDistrict
            // 
            this.cbDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDistrict.FormattingEnabled = true;
            this.cbDistrict.Location = new System.Drawing.Point(153, 64);
            this.cbDistrict.Name = "cbDistrict";
            this.cbDistrict.Size = new System.Drawing.Size(231, 21);
            this.cbDistrict.TabIndex = 5;
            this.cbDistrict.SelectionChangeCommitted += new System.EventHandler(this.cbDistrict_SelectionChangeCommitted);
            // 
            // lblSubCounty
            // 
            this.lblSubCounty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubCounty.AutoSize = true;
            this.lblSubCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCounty.Location = new System.Drawing.Point(430, 68);
            this.lblSubCounty.Name = "lblSubCounty";
            this.lblSubCounty.Size = new System.Drawing.Size(65, 13);
            this.lblSubCounty.TabIndex = 12;
            this.lblSubCounty.Text = "Sub County:";
            // 
            // cbSubCounty
            // 
            this.cbSubCounty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSubCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubCounty.FormattingEnabled = true;
            this.cbSubCounty.Location = new System.Drawing.Point(580, 64);
            this.cbSubCounty.Name = "cbSubCounty";
            this.cbSubCounty.Size = new System.Drawing.Size(231, 21);
            this.cbSubCounty.TabIndex = 6;
            this.cbSubCounty.SelectionChangeCommitted += new System.EventHandler(this.cbSubCounty_SelectionChangeCommitted);
            // 
            // cbWard
            // 
            this.cbWard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbWard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWard.FormattingEnabled = true;
            this.cbWard.Location = new System.Drawing.Point(153, 94);
            this.cbWard.Name = "cbWard";
            this.cbWard.Size = new System.Drawing.Size(231, 21);
            this.cbWard.TabIndex = 7;
            this.cbWard.SelectionChangeCommitted += new System.EventHandler(this.cbWard_SelectionChangeCommitted);
            // 
            // lblWard
            // 
            this.lblWard.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblWard.AutoSize = true;
            this.lblWard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWard.Location = new System.Drawing.Point(3, 98);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(36, 13);
            this.lblWard.TabIndex = 13;
            this.lblWard.Text = "Ward:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Controls.Add(this.cbWard, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.cbSubCounty, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblWard, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblSubCounty, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbDistrict, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblDistrict, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblSocialWorker, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbSocialWorker, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPhone, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPhone, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtLastName, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblLastName, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtFirstName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblFirstName, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblSocialWorkerType, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.cbSocialWorkerType, 4, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(30, 40);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(854, 120);
            this.tableLayoutPanel2.TabIndex = 35;
            // 
            // lblSocialWorker
            // 
            this.lblSocialWorker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSocialWorker.AutoSize = true;
            this.lblSocialWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSocialWorker.Location = new System.Drawing.Point(3, 8);
            this.lblSocialWorker.Name = "lblSocialWorker";
            this.lblSocialWorker.Size = new System.Drawing.Size(77, 13);
            this.lblSocialWorker.TabIndex = 2;
            this.lblSocialWorker.Text = "Social Worker:";
            // 
            // cbSocialWorker
            // 
            this.cbSocialWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSocialWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSocialWorker.FormattingEnabled = true;
            this.cbSocialWorker.Location = new System.Drawing.Point(153, 4);
            this.cbSocialWorker.Name = "cbSocialWorker";
            this.cbSocialWorker.Size = new System.Drawing.Size(231, 21);
            this.cbSocialWorker.TabIndex = 1;
            // 
            // lblPhone
            // 
            this.lblPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(430, 8);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(81, 13);
            this.lblPhone.TabIndex = 5;
            this.lblPhone.Text = "Phone Number:";
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(580, 5);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(231, 20);
            this.txtPhone.TabIndex = 2;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(580, 35);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(231, 20);
            this.txtLastName.TabIndex = 4;
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(430, 38);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(153, 35);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(231, 20);
            this.txtFirstName.TabIndex = 3;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(3, 38);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 4;
            this.lblFirstName.Text = "First Name:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnSearch, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCancel, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(30, 158);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(854, 40);
            this.tableLayoutPanel3.TabIndex = 34;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(329, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(450, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // llblNewSocialWorker
            // 
            this.llblNewSocialWorker.AutoSize = true;
            this.llblNewSocialWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblNewSocialWorker.Location = new System.Drawing.Point(16, 20);
            this.llblNewSocialWorker.Name = "llblNewSocialWorker";
            this.llblNewSocialWorker.Size = new System.Drawing.Size(99, 13);
            this.llblNewSocialWorker.TabIndex = 17;
            this.llblNewSocialWorker.TabStop = true;
            this.llblNewSocialWorker.Text = "New Social Worker";
            this.llblNewSocialWorker.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblNewSocialWorker_LinkClicked);
            // 
            // dgvSocialWorker
            // 
            this.dgvSocialWorker.AllowUserToAddRows = false;
            this.dgvSocialWorker.AllowUserToDeleteRows = false;
            this.dgvSocialWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSocialWorker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSocialWorker.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gclID,
            this.gclFirstName,
            this.gclLastName,
            this.gclEmail,
            this.gclPhone,
            this.gclType});
            this.dgvSocialWorker.Location = new System.Drawing.Point(6, 204);
            this.dgvSocialWorker.MultiSelect = false;
            this.dgvSocialWorker.Name = "dgvSocialWorker";
            this.dgvSocialWorker.Size = new System.Drawing.Size(892, 301);
            this.dgvSocialWorker.TabIndex = 0;
            this.dgvSocialWorker.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSocialWorker_CellDoubleClick);
            // 
            // gclID
            // 
            this.gclID.DataPropertyName = "swk_id";
            this.gclID.HeaderText = "ID";
            this.gclID.Name = "gclID";
            this.gclID.ReadOnly = true;
            this.gclID.Visible = false;
            // 
            // gclFirstName
            // 
            this.gclFirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclFirstName.DataPropertyName = "swk_first_name";
            this.gclFirstName.HeaderText = "First Name";
            this.gclFirstName.Name = "gclFirstName";
            this.gclFirstName.ReadOnly = true;
            // 
            // gclLastName
            // 
            this.gclLastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclLastName.DataPropertyName = "swk_last_name";
            this.gclLastName.HeaderText = "Last Name";
            this.gclLastName.Name = "gclLastName";
            this.gclLastName.ReadOnly = true;
            // 
            // gclEmail
            // 
            this.gclEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclEmail.DataPropertyName = "swk_email";
            this.gclEmail.HeaderText = "Email";
            this.gclEmail.Name = "gclEmail";
            this.gclEmail.ReadOnly = true;
            // 
            // gclPhone
            // 
            this.gclPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclPhone.DataPropertyName = "swk_phone";
            this.gclPhone.HeaderText = "Phone Number";
            this.gclPhone.Name = "gclPhone";
            this.gclPhone.ReadOnly = true;
            // 
            // gclType
            // 
            this.gclType.DataPropertyName = "swt_id";
            this.gclType.HeaderText = "Type";
            this.gclType.Name = "gclType";
            this.gclType.ReadOnly = true;
            this.gclType.Visible = false;
            // 
            // lblSocialWorkerType
            // 
            this.lblSocialWorkerType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSocialWorkerType.AutoSize = true;
            this.lblSocialWorkerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSocialWorkerType.Location = new System.Drawing.Point(430, 98);
            this.lblSocialWorkerType.Name = "lblSocialWorkerType";
            this.lblSocialWorkerType.Size = new System.Drawing.Size(104, 13);
            this.lblSocialWorkerType.TabIndex = 14;
            this.lblSocialWorkerType.Text = "Social Worker Type:";
            // 
            // cbSocialWorkerType
            // 
            this.cbSocialWorkerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSocialWorkerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSocialWorkerType.FormattingEnabled = true;
            this.cbSocialWorkerType.Location = new System.Drawing.Point(580, 94);
            this.cbSocialWorkerType.Name = "cbSocialWorkerType";
            this.cbSocialWorkerType.Size = new System.Drawing.Size(231, 21);
            this.cbSocialWorkerType.TabIndex = 15;
            // 
            // frmSocialWorkerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbSocialWorkerSearch);
            this.Name = "frmSocialWorkerSearch";
            this.Size = new System.Drawing.Size(910, 520);
            this.Load += new System.EventHandler(this.frmSocialWorkerSearch_Load);
            this.gbSocialWorkerSearch.ResumeLayout(false);
            this.gbSocialWorkerSearch.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocialWorker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSocialWorkerSearch;
        private System.Windows.Forms.ComboBox cbSocialWorker;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblSocialWorker;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvSocialWorker;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.Label lblWard;
        private System.Windows.Forms.Label lblSubCounty;
        private System.Windows.Forms.ComboBox cbDistrict;
        private System.Windows.Forms.ComboBox cbSubCounty;
        private System.Windows.Forms.ComboBox cbWard;
        private System.Windows.Forms.LinkLabel llblNewSocialWorker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.LinkLabel llblNewParaSocialWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclType;
        private System.Windows.Forms.Label lblSocialWorkerType;
        private System.Windows.Forms.ComboBox cbSocialWorkerType;
    }
}
