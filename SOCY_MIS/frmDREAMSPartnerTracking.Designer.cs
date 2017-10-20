namespace SOCY_MIS
{
    partial class frmDREAMSPartnerTracking
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
            this.gbDreamsPartnerTitle = new System.Windows.Forms.GroupBox();
            this.gbPartner = new System.Windows.Forms.GroupBox();
            this.dgvPartner = new System.Windows.Forms.DataGridView();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDpId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDptDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gclOfcId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblTotalNumber = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.llblBackTop = new System.Windows.Forms.LinkLabel();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.llblbackBottom = new System.Windows.Forms.LinkLabel();
            this.tlpDisplay01 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDreamsId = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblDreamsIdDisplay = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.dtpAsAtDate = new System.Windows.Forms.DateTimePicker();
            this.lblAsAtDate = new System.Windows.Forms.Label();
            this.lblDreamsMember = new System.Windows.Forms.Label();
            this.lblDreamsMemberDisplay = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblDreamsPartner = new System.Windows.Forms.Label();
            this.cbDreamsPartner = new System.Windows.Forms.ComboBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblFirstNameVal = new System.Windows.Forms.Label();
            this.lblLastNameVal = new System.Windows.Forms.Label();
            this.lblPartnerType = new System.Windows.Forms.Label();
            this.cbPartnerType = new System.Windows.Forms.ComboBox();
            this.lblPartnerTypeOther = new System.Windows.Forms.Label();
            this.txtPartnerTypeOther = new System.Windows.Forms.TextBox();
            this.txtServicesReceived = new System.Windows.Forms.RichTextBox();
            this.lblHIVStatus = new System.Windows.Forms.Label();
            this.lblVMMCStatus = new System.Windows.Forms.Label();
            this.lblTraced = new System.Windows.Forms.Label();
            this.cbTraced = new System.Windows.Forms.ComboBox();
            this.cbHIVStatus = new System.Windows.Forms.ComboBox();
            this.cbVMMCStatus = new System.Windows.Forms.ComboBox();
            this.lblServicesReceived = new System.Windows.Forms.Label();
            this.clbServices = new System.Windows.Forms.CheckedListBox();
            this.lblServices = new System.Windows.Forms.Label();
            this.lblDptId = new System.Windows.Forms.Label();
            this.lblDpId = new System.Windows.Forms.Label();
            this.gbDreamsPartnerTitle.SuspendLayout();
            this.gbPartner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartner)).BeginInit();
            this.tplButton01.SuspendLayout();
            this.tlpDisplay01.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDreamsPartnerTitle
            // 
            this.gbDreamsPartnerTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDreamsPartnerTitle.Controls.Add(this.gbPartner);
            this.gbDreamsPartnerTitle.Controls.Add(this.llblBackTop);
            this.gbDreamsPartnerTitle.Controls.Add(this.tplButton01);
            this.gbDreamsPartnerTitle.Controls.Add(this.tlpDisplay01);
            this.gbDreamsPartnerTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDreamsPartnerTitle.Location = new System.Drawing.Point(4, 5);
            this.gbDreamsPartnerTitle.Margin = new System.Windows.Forms.Padding(4);
            this.gbDreamsPartnerTitle.Name = "gbDreamsPartnerTitle";
            this.gbDreamsPartnerTitle.Padding = new System.Windows.Forms.Padding(4);
            this.gbDreamsPartnerTitle.Size = new System.Drawing.Size(952, 791);
            this.gbDreamsPartnerTitle.TabIndex = 67;
            this.gbDreamsPartnerTitle.TabStop = false;
            this.gbDreamsPartnerTitle.Text = "DREAMS Partner Register";
            // 
            // gbPartner
            // 
            this.gbPartner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPartner.Controls.Add(this.dgvPartner);
            this.gbPartner.Controls.Add(this.btnDelete);
            this.gbPartner.Controls.Add(this.lblTotalNumber);
            this.gbPartner.Controls.Add(this.lblTotal);
            this.gbPartner.Location = new System.Drawing.Point(8, 535);
            this.gbPartner.Margin = new System.Windows.Forms.Padding(4);
            this.gbPartner.Name = "gbPartner";
            this.gbPartner.Padding = new System.Windows.Forms.Padding(4);
            this.gbPartner.Size = new System.Drawing.Size(936, 249);
            this.gbPartner.TabIndex = 62;
            this.gbPartner.TabStop = false;
            this.gbPartner.Text = "Partner Records";
            // 
            // dgvPartner
            // 
            this.dgvPartner.AllowUserToAddRows = false;
            this.dgvPartner.AllowUserToDeleteRows = false;
            this.dgvPartner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPartner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartner.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gclID,
            this.gclDpId,
            this.gclDPName,
            this.gclDptDate,
            this.gclDelete,
            this.gclOfcId});
            this.dgvPartner.Location = new System.Drawing.Point(8, 23);
            this.dgvPartner.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPartner.MultiSelect = false;
            this.dgvPartner.Name = "dgvPartner";
            this.dgvPartner.Size = new System.Drawing.Size(920, 182);
            this.dgvPartner.TabIndex = 32;
            this.dgvPartner.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartner_CellDoubleClick);
            this.dgvPartner.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPartner_RowPostPaint);
            // 
            // gclID
            // 
            this.gclID.DataPropertyName = "dpt_id";
            this.gclID.HeaderText = "ID";
            this.gclID.Name = "gclID";
            this.gclID.Visible = false;
            // 
            // gclDpId
            // 
            this.gclDpId.DataPropertyName = "dp_id";
            this.gclDpId.HeaderText = "DpId";
            this.gclDpId.Name = "gclDpId";
            this.gclDpId.ReadOnly = true;
            this.gclDpId.Visible = false;
            // 
            // gclDPName
            // 
            this.gclDPName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclDPName.DataPropertyName = "dp_name";
            this.gclDPName.HeaderText = "Partner Name";
            this.gclDPName.Name = "gclDPName";
            this.gclDPName.ReadOnly = true;
            // 
            // gclDptDate
            // 
            this.gclDptDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclDptDate.DataPropertyName = "dpt_date";
            this.gclDptDate.HeaderText = "As At Date";
            this.gclDptDate.Name = "gclDptDate";
            this.gclDptDate.ReadOnly = true;
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
            this.btnDelete.Location = new System.Drawing.Point(828, 213);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblTotalNumber
            // 
            this.lblTotalNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalNumber.AutoSize = true;
            this.lblTotalNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalNumber.Location = new System.Drawing.Point(61, 218);
            this.lblTotalNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalNumber.Name = "lblTotalNumber";
            this.lblTotalNumber.Size = new System.Drawing.Size(13, 17);
            this.lblTotalNumber.TabIndex = 31;
            this.lblTotalNumber.Text = "-";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(8, 218);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 17);
            this.lblTotal.TabIndex = 30;
            this.lblTotal.Text = "Total:";
            // 
            // llblBackTop
            // 
            this.llblBackTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblBackTop.AutoSize = true;
            this.llblBackTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblBackTop.Location = new System.Drawing.Point(901, 20);
            this.llblBackTop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblBackTop.Name = "llblBackTop";
            this.llblBackTop.Size = new System.Drawing.Size(39, 17);
            this.llblBackTop.TabIndex = 19;
            this.llblBackTop.TabStop = true;
            this.llblBackTop.Text = "Back";
            this.llblBackTop.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblBackTop_LinkClicked);
            // 
            // tplButton01
            // 
            this.tplButton01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplButton01.ColumnCount = 4;
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tplButton01.Controls.Add(this.btnCancel, 2, 0);
            this.tplButton01.Controls.Add(this.btnSave, 0, 0);
            this.tplButton01.Controls.Add(this.llblbackBottom, 3, 0);
            this.tplButton01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tplButton01.Location = new System.Drawing.Point(40, 479);
            this.tplButton01.Margin = new System.Windows.Forms.Padding(4);
            this.tplButton01.Name = "tplButton01";
            this.tplButton01.RowCount = 1;
            this.tplButton01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplButton01.Size = new System.Drawing.Size(872, 49);
            this.tplButton01.TabIndex = 52;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Location = new System.Drawing.Point(440, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Location = new System.Drawing.Point(279, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // llblbackBottom
            // 
            this.llblbackBottom.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.llblbackBottom.AutoSize = true;
            this.llblbackBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblbackBottom.Location = new System.Drawing.Point(829, 16);
            this.llblbackBottom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblbackBottom.Name = "llblbackBottom";
            this.llblbackBottom.Size = new System.Drawing.Size(39, 17);
            this.llblbackBottom.TabIndex = 18;
            this.llblbackBottom.TabStop = true;
            this.llblbackBottom.Text = "Back";
            this.llblbackBottom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblbackBottom_LinkClicked);
            // 
            // tlpDisplay01
            // 
            this.tlpDisplay01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDisplay01.ColumnCount = 6;
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpDisplay01.Controls.Add(this.lblDreamsId, 0, 0);
            this.tlpDisplay01.Controls.Add(this.lblLastName, 3, 2);
            this.tlpDisplay01.Controls.Add(this.lblFirstName, 0, 2);
            this.tlpDisplay01.Controls.Add(this.txtAddress, 4, 5);
            this.tlpDisplay01.Controls.Add(this.lblAddress, 3, 5);
            this.tlpDisplay01.Controls.Add(this.lblDreamsIdDisplay, 1, 0);
            this.tlpDisplay01.Controls.Add(this.txtFirstName, 1, 2);
            this.tlpDisplay01.Controls.Add(this.dtpAsAtDate, 4, 1);
            this.tlpDisplay01.Controls.Add(this.lblAsAtDate, 3, 1);
            this.tlpDisplay01.Controls.Add(this.lblDreamsMember, 3, 0);
            this.tlpDisplay01.Controls.Add(this.lblDreamsMemberDisplay, 4, 0);
            this.tlpDisplay01.Controls.Add(this.txtLastName, 4, 2);
            this.tlpDisplay01.Controls.Add(this.lblDreamsPartner, 0, 1);
            this.tlpDisplay01.Controls.Add(this.cbDreamsPartner, 1, 1);
            this.tlpDisplay01.Controls.Add(this.lblPhone, 0, 5);
            this.tlpDisplay01.Controls.Add(this.txtPhone, 1, 5);
            this.tlpDisplay01.Controls.Add(this.lblFirstNameVal, 2, 2);
            this.tlpDisplay01.Controls.Add(this.lblLastNameVal, 5, 2);
            this.tlpDisplay01.Controls.Add(this.lblPartnerType, 0, 3);
            this.tlpDisplay01.Controls.Add(this.cbPartnerType, 1, 3);
            this.tlpDisplay01.Controls.Add(this.lblPartnerTypeOther, 3, 3);
            this.tlpDisplay01.Controls.Add(this.txtPartnerTypeOther, 4, 3);
            this.tlpDisplay01.Controls.Add(this.txtServicesReceived, 4, 7);
            this.tlpDisplay01.Controls.Add(this.lblHIVStatus, 0, 4);
            this.tlpDisplay01.Controls.Add(this.lblVMMCStatus, 3, 4);
            this.tlpDisplay01.Controls.Add(this.lblTraced, 0, 6);
            this.tlpDisplay01.Controls.Add(this.cbTraced, 1, 6);
            this.tlpDisplay01.Controls.Add(this.cbHIVStatus, 1, 4);
            this.tlpDisplay01.Controls.Add(this.cbVMMCStatus, 4, 4);
            this.tlpDisplay01.Controls.Add(this.lblServicesReceived, 3, 7);
            this.tlpDisplay01.Controls.Add(this.clbServices, 1, 7);
            this.tlpDisplay01.Controls.Add(this.lblServices, 0, 7);
            this.tlpDisplay01.Controls.Add(this.lblDptId, 2, 0);
            this.tlpDisplay01.Controls.Add(this.lblDpId, 2, 1);
            this.tlpDisplay01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpDisplay01.Location = new System.Drawing.Point(40, 37);
            this.tlpDisplay01.Margin = new System.Windows.Forms.Padding(4);
            this.tlpDisplay01.Name = "tlpDisplay01";
            this.tlpDisplay01.RowCount = 8;
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDisplay01.Size = new System.Drawing.Size(872, 443);
            this.tlpDisplay01.TabIndex = 61;
            // 
            // lblDreamsId
            // 
            this.lblDreamsId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDreamsId.AutoSize = true;
            this.lblDreamsId.Location = new System.Drawing.Point(4, 9);
            this.lblDreamsId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDreamsId.Name = "lblDreamsId";
            this.lblDreamsId.Size = new System.Drawing.Size(109, 17);
            this.lblDreamsId.TabIndex = 21;
            this.lblDreamsId.Text = "DREAMS ID No:";
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(440, 81);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(80, 17);
            this.lblLastName.TabIndex = 24;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(4, 81);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(80, 17);
            this.lblFirstName.TabIndex = 65;
            this.lblFirstName.Text = "First Name:";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(600, 184);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(241, 102);
            this.txtAddress.TabIndex = 10;
            this.txtAddress.Text = "";
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(440, 226);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(149, 17);
            this.lblAddress.TabIndex = 70;
            this.lblAddress.Text = "Location and address:";
            // 
            // lblDreamsIdDisplay
            // 
            this.lblDreamsIdDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDreamsIdDisplay.AutoSize = true;
            this.lblDreamsIdDisplay.Location = new System.Drawing.Point(164, 9);
            this.lblDreamsIdDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDreamsIdDisplay.Name = "lblDreamsIdDisplay";
            this.lblDreamsIdDisplay.Size = new System.Drawing.Size(13, 17);
            this.lblDreamsIdDisplay.TabIndex = 72;
            this.lblDreamsIdDisplay.Text = "-";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(164, 78);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(241, 23);
            this.txtFirstName.TabIndex = 3;
            // 
            // dtpAsAtDate
            // 
            this.dtpAsAtDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpAsAtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAsAtDate.Location = new System.Drawing.Point(600, 42);
            this.dtpAsAtDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpAsAtDate.Name = "dtpAsAtDate";
            this.dtpAsAtDate.Size = new System.Drawing.Size(159, 23);
            this.dtpAsAtDate.TabIndex = 2;
            // 
            // lblAsAtDate
            // 
            this.lblAsAtDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAsAtDate.AutoSize = true;
            this.lblAsAtDate.Location = new System.Drawing.Point(440, 45);
            this.lblAsAtDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAsAtDate.Name = "lblAsAtDate";
            this.lblAsAtDate.Size = new System.Drawing.Size(78, 17);
            this.lblAsAtDate.TabIndex = 23;
            this.lblAsAtDate.Text = "As at Date:";
            // 
            // lblDreamsMember
            // 
            this.lblDreamsMember.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDreamsMember.AutoSize = true;
            this.lblDreamsMember.Location = new System.Drawing.Point(440, 9);
            this.lblDreamsMember.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDreamsMember.Name = "lblDreamsMember";
            this.lblDreamsMember.Size = new System.Drawing.Size(116, 17);
            this.lblDreamsMember.TabIndex = 22;
            this.lblDreamsMember.Text = "Dreams Member:";
            // 
            // lblDreamsMemberDisplay
            // 
            this.lblDreamsMemberDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDreamsMemberDisplay.AutoSize = true;
            this.lblDreamsMemberDisplay.Location = new System.Drawing.Point(600, 9);
            this.lblDreamsMemberDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDreamsMemberDisplay.Name = "lblDreamsMemberDisplay";
            this.lblDreamsMemberDisplay.Size = new System.Drawing.Size(13, 17);
            this.lblDreamsMemberDisplay.TabIndex = 66;
            this.lblDreamsMemberDisplay.Text = "-";
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(600, 78);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(241, 23);
            this.txtLastName.TabIndex = 4;
            // 
            // lblDreamsPartner
            // 
            this.lblDreamsPartner.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDreamsPartner.AutoSize = true;
            this.lblDreamsPartner.Location = new System.Drawing.Point(4, 45);
            this.lblDreamsPartner.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDreamsPartner.Name = "lblDreamsPartner";
            this.lblDreamsPartner.Size = new System.Drawing.Size(111, 17);
            this.lblDreamsPartner.TabIndex = 26;
            this.lblDreamsPartner.Text = "Existing Partner:";
            // 
            // cbDreamsPartner
            // 
            this.cbDreamsPartner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDreamsPartner.FormattingEnabled = true;
            this.cbDreamsPartner.Location = new System.Drawing.Point(164, 41);
            this.cbDreamsPartner.Margin = new System.Windows.Forms.Padding(4);
            this.cbDreamsPartner.Name = "cbDreamsPartner";
            this.cbDreamsPartner.Size = new System.Drawing.Size(241, 25);
            this.cbDreamsPartner.TabIndex = 1;
            this.cbDreamsPartner.SelectionChangeCommitted += new System.EventHandler(this.cbDreamsPartner_SelectionChangeCommitted);
            // 
            // lblPhone
            // 
            this.lblPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(4, 226);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(107, 17);
            this.lblPhone.TabIndex = 28;
            this.lblPhone.Text = "Phone Number:";
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(164, 223);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(159, 23);
            this.txtPhone.TabIndex = 9;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // lblFirstNameVal
            // 
            this.lblFirstNameVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFirstNameVal.AutoSize = true;
            this.lblFirstNameVal.ForeColor = System.Drawing.Color.Red;
            this.lblFirstNameVal.Location = new System.Drawing.Point(413, 81);
            this.lblFirstNameVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstNameVal.Name = "lblFirstNameVal";
            this.lblFirstNameVal.Size = new System.Drawing.Size(13, 17);
            this.lblFirstNameVal.TabIndex = 63;
            this.lblFirstNameVal.Text = "*";
            // 
            // lblLastNameVal
            // 
            this.lblLastNameVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLastNameVal.AutoSize = true;
            this.lblLastNameVal.ForeColor = System.Drawing.Color.Red;
            this.lblLastNameVal.Location = new System.Drawing.Point(849, 81);
            this.lblLastNameVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastNameVal.Name = "lblLastNameVal";
            this.lblLastNameVal.Size = new System.Drawing.Size(13, 17);
            this.lblLastNameVal.TabIndex = 73;
            this.lblLastNameVal.Text = "*";
            // 
            // lblPartnerType
            // 
            this.lblPartnerType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPartnerType.AutoSize = true;
            this.lblPartnerType.Location = new System.Drawing.Point(4, 117);
            this.lblPartnerType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPartnerType.Name = "lblPartnerType";
            this.lblPartnerType.Size = new System.Drawing.Size(95, 17);
            this.lblPartnerType.TabIndex = 27;
            this.lblPartnerType.Text = "Partner Type:";
            // 
            // cbPartnerType
            // 
            this.cbPartnerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPartnerType.FormattingEnabled = true;
            this.cbPartnerType.Location = new System.Drawing.Point(164, 113);
            this.cbPartnerType.Margin = new System.Windows.Forms.Padding(4);
            this.cbPartnerType.Name = "cbPartnerType";
            this.cbPartnerType.Size = new System.Drawing.Size(241, 25);
            this.cbPartnerType.TabIndex = 5;
            this.cbPartnerType.SelectionChangeCommitted += new System.EventHandler(this.cbPartnerType_SelectionChangeCommitted);
            // 
            // lblPartnerTypeOther
            // 
            this.lblPartnerTypeOther.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPartnerTypeOther.AutoSize = true;
            this.lblPartnerTypeOther.Location = new System.Drawing.Point(440, 117);
            this.lblPartnerTypeOther.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPartnerTypeOther.Name = "lblPartnerTypeOther";
            this.lblPartnerTypeOther.Size = new System.Drawing.Size(48, 17);
            this.lblPartnerTypeOther.TabIndex = 74;
            this.lblPartnerTypeOther.Text = "Other:";
            this.lblPartnerTypeOther.Visible = false;
            // 
            // txtPartnerTypeOther
            // 
            this.txtPartnerTypeOther.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPartnerTypeOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartnerTypeOther.Location = new System.Drawing.Point(600, 114);
            this.txtPartnerTypeOther.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartnerTypeOther.Name = "txtPartnerTypeOther";
            this.txtPartnerTypeOther.Size = new System.Drawing.Size(240, 23);
            this.txtPartnerTypeOther.TabIndex = 6;
            this.txtPartnerTypeOther.Visible = false;
            // 
            // txtServicesReceived
            // 
            this.txtServicesReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServicesReceived.Location = new System.Drawing.Point(600, 330);
            this.txtServicesReceived.Margin = new System.Windows.Forms.Padding(4);
            this.txtServicesReceived.Name = "txtServicesReceived";
            this.txtServicesReceived.Size = new System.Drawing.Size(241, 109);
            this.txtServicesReceived.TabIndex = 13;
            this.txtServicesReceived.Text = "";
            // 
            // lblHIVStatus
            // 
            this.lblHIVStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHIVStatus.AutoSize = true;
            this.lblHIVStatus.Location = new System.Drawing.Point(4, 153);
            this.lblHIVStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHIVStatus.Name = "lblHIVStatus";
            this.lblHIVStatus.Size = new System.Drawing.Size(78, 17);
            this.lblHIVStatus.TabIndex = 77;
            this.lblHIVStatus.Text = "HIV Status:";
            // 
            // lblVMMCStatus
            // 
            this.lblVMMCStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVMMCStatus.AutoSize = true;
            this.lblVMMCStatus.Location = new System.Drawing.Point(440, 153);
            this.lblVMMCStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVMMCStatus.Name = "lblVMMCStatus";
            this.lblVMMCStatus.Size = new System.Drawing.Size(96, 17);
            this.lblVMMCStatus.TabIndex = 78;
            this.lblVMMCStatus.Text = "VMMC Status:";
            // 
            // lblTraced
            // 
            this.lblTraced.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTraced.AutoSize = true;
            this.lblTraced.Location = new System.Drawing.Point(4, 299);
            this.lblTraced.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTraced.Name = "lblTraced";
            this.lblTraced.Size = new System.Drawing.Size(134, 17);
            this.lblTraced.TabIndex = 79;
            this.lblTraced.Text = "Was partner traced:";
            // 
            // cbTraced
            // 
            this.cbTraced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTraced.FormattingEnabled = true;
            this.cbTraced.Location = new System.Drawing.Point(164, 295);
            this.cbTraced.Margin = new System.Windows.Forms.Padding(4);
            this.cbTraced.Name = "cbTraced";
            this.cbTraced.Size = new System.Drawing.Size(241, 25);
            this.cbTraced.TabIndex = 11;
            this.cbTraced.SelectionChangeCommitted += new System.EventHandler(this.cbTraced_SelectionChangeCommitted);
            // 
            // cbHIVStatus
            // 
            this.cbHIVStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHIVStatus.FormattingEnabled = true;
            this.cbHIVStatus.Location = new System.Drawing.Point(164, 149);
            this.cbHIVStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cbHIVStatus.Name = "cbHIVStatus";
            this.cbHIVStatus.Size = new System.Drawing.Size(241, 25);
            this.cbHIVStatus.TabIndex = 7;
            // 
            // cbVMMCStatus
            // 
            this.cbVMMCStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVMMCStatus.FormattingEnabled = true;
            this.cbVMMCStatus.Location = new System.Drawing.Point(600, 149);
            this.cbVMMCStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cbVMMCStatus.Name = "cbVMMCStatus";
            this.cbVMMCStatus.Size = new System.Drawing.Size(241, 25);
            this.cbVMMCStatus.TabIndex = 8;
            // 
            // lblServicesReceived
            // 
            this.lblServicesReceived.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblServicesReceived.AutoSize = true;
            this.lblServicesReceived.Location = new System.Drawing.Point(440, 367);
            this.lblServicesReceived.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServicesReceived.Name = "lblServicesReceived";
            this.lblServicesReceived.Size = new System.Drawing.Size(135, 34);
            this.lblServicesReceived.TabIndex = 80;
            this.lblServicesReceived.Text = "What services were received:";
            // 
            // clbServices
            // 
            this.clbServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbServices.Enabled = false;
            this.clbServices.FormattingEnabled = true;
            this.clbServices.Location = new System.Drawing.Point(164, 330);
            this.clbServices.Margin = new System.Windows.Forms.Padding(4);
            this.clbServices.Name = "clbServices";
            this.clbServices.Size = new System.Drawing.Size(241, 94);
            this.clbServices.TabIndex = 12;
            // 
            // lblServices
            // 
            this.lblServices.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblServices.AutoSize = true;
            this.lblServices.Location = new System.Drawing.Point(4, 367);
            this.lblServices.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServices.Name = "lblServices";
            this.lblServices.Size = new System.Drawing.Size(152, 34);
            this.lblServices.TabIndex = 81;
            this.lblServices.Text = "If traced, what services were they linked to? ";
            // 
            // lblDptId
            // 
            this.lblDptId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDptId.AutoSize = true;
            this.lblDptId.Location = new System.Drawing.Point(413, 9);
            this.lblDptId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDptId.Name = "lblDptId";
            this.lblDptId.Size = new System.Drawing.Size(13, 17);
            this.lblDptId.TabIndex = 82;
            this.lblDptId.Text = "-";
            this.lblDptId.Visible = false;
            // 
            // lblDpId
            // 
            this.lblDpId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDpId.AutoSize = true;
            this.lblDpId.Location = new System.Drawing.Point(413, 45);
            this.lblDpId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDpId.Name = "lblDpId";
            this.lblDpId.Size = new System.Drawing.Size(13, 17);
            this.lblDpId.TabIndex = 83;
            this.lblDpId.Text = "-";
            this.lblDpId.Visible = false;
            // 
            // frmDREAMSPartnerTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbDreamsPartnerTitle);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDREAMSPartnerTracking";
            this.Size = new System.Drawing.Size(960, 800);
            this.Load += new System.EventHandler(this.frmValueChainActorRegister_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmValueChainActorRegister_Paint);
            this.gbDreamsPartnerTitle.ResumeLayout(false);
            this.gbDreamsPartnerTitle.PerformLayout();
            this.gbPartner.ResumeLayout(false);
            this.gbPartner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartner)).EndInit();
            this.tplButton01.ResumeLayout(false);
            this.tplButton01.PerformLayout();
            this.tlpDisplay01.ResumeLayout(false);
            this.tlpDisplay01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDreamsPartnerTitle;
        private System.Windows.Forms.LinkLabel llblBackTop;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay01;
        private System.Windows.Forms.Label lblDreamsId;
        private System.Windows.Forms.Label lblDreamsMember;
        private System.Windows.Forms.Label lblAsAtDate;
        private System.Windows.Forms.DateTimePicker dtpAsAtDate;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblPartnerType;
        private System.Windows.Forms.Label lblDreamsPartner;
        private System.Windows.Forms.ComboBox cbDreamsPartner;
        private System.Windows.Forms.Label lblFirstNameVal;
        private System.Windows.Forms.ComboBox cbPartnerType;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblDreamsMemberDisplay;
        private System.Windows.Forms.RichTextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.LinkLabel llblbackBottom;
        private System.Windows.Forms.GroupBox gbPartner;
        private System.Windows.Forms.Label lblTotalNumber;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblServicesReceived;
        private System.Windows.Forms.Label lblDreamsIdDisplay;
        private System.Windows.Forms.Label lblLastNameVal;
        private System.Windows.Forms.Label lblPartnerTypeOther;
        private System.Windows.Forms.TextBox txtPartnerTypeOther;
        private System.Windows.Forms.RichTextBox txtServicesReceived;
        private System.Windows.Forms.Label lblHIVStatus;
        private System.Windows.Forms.Label lblVMMCStatus;
        private System.Windows.Forms.Label lblTraced;
        private System.Windows.Forms.ComboBox cbTraced;
        private System.Windows.Forms.ComboBox cbHIVStatus;
        private System.Windows.Forms.ComboBox cbVMMCStatus;
        private System.Windows.Forms.CheckedListBox clbServices;
        private System.Windows.Forms.Label lblServices;
        private System.Windows.Forms.DataGridView dgvPartner;
        private System.Windows.Forms.Label lblDptId;
        private System.Windows.Forms.Label lblDpId;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclDpId;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclDPName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclDptDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gclDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclOfcId;
    }
}
