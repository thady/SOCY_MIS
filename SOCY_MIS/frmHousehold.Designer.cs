namespace SOCY_MIS
{
    partial class frmHousehold
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
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.tlpDisplay03 = new System.Windows.Forms.TableLayoutPanel();
            this.lblWardDisplay = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblCodeDisplay = new System.Windows.Forms.Label();
            this.lblStatusDisplay = new System.Windows.Forms.Label();
            this.lblSocialWorker = new System.Windows.Forms.Label();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.lblSocialWorkerDisplay = new System.Windows.Forms.Label();
            this.lblDistrictDisplay = new System.Windows.Forms.Label();
            this.lblSubCounty = new System.Windows.Forms.Label();
            this.lblSubCountyDisplay = new System.Windows.Forms.Label();
            this.lblVillageDisplay = new System.Windows.Forms.Label();
            this.lblVillage = new System.Windows.Forms.Label();
            this.llblBack = new System.Windows.Forms.LinkLabel();
            this.gbRecords = new System.Windows.Forms.GroupBox();
            this.tlpDisplay04 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRecordType = new System.Windows.Forms.Label();
            this.cbRecordType = new System.Windows.Forms.ComboBox();
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclRtpId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclRtpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbNew = new System.Windows.Forms.GroupBox();
            this.tlpDisplay01 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHomevisitNew = new System.Windows.Forms.LinkLabel();
            this.llblHouseholdAssessment = new System.Windows.Forms.LinkLabel();
            this.llblHip = new System.Windows.Forms.LinkLabel();
            this.lblGBV = new System.Windows.Forms.LinkLabel();
            this.lblAdherence = new System.Windows.Forms.LinkLabel();
            this.llblHomeVisitArchive = new System.Windows.Forms.LinkLabel();
            this.llblViralLoad = new System.Windows.Forms.LinkLabel();
            this.llblReferral = new System.Windows.Forms.LinkLabel();
            this.llblHomeVisit = new System.Windows.Forms.LinkLabel();
            this.llblLinkages_register = new System.Windows.Forms.LinkLabel();
            this.llblOVCIdentificationPrioritization = new System.Windows.Forms.LinkLabel();
            this.llblHouseholdDetails = new System.Windows.Forms.LinkLabel();
            this.llblHouseholdMembers = new System.Windows.Forms.LinkLabel();
            this.gbMembers = new System.Windows.Forms.GroupBox();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.gclHhmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclYearOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbManage = new System.Windows.Forms.GroupBox();
            this.tlpDisplay02 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_risk_assessment = new System.Windows.Forms.LinkLabel();
            this.llblHip_v2 = new System.Windows.Forms.LinkLabel();
            this.gbDetails.SuspendLayout();
            this.tlpDisplay03.SuspendLayout();
            this.gbRecords.SuspendLayout();
            this.tlpDisplay04.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.gbNew.SuspendLayout();
            this.tlpDisplay01.SuspendLayout();
            this.gbMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.gbManage.SuspendLayout();
            this.tlpDisplay02.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDetails
            // 
            this.gbDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetails.Controls.Add(this.tlpDisplay03);
            this.gbDetails.Controls.Add(this.llblBack);
            this.gbDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetails.Location = new System.Drawing.Point(236, 7);
            this.gbDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbDetails.Size = new System.Drawing.Size(973, 215);
            this.gbDetails.TabIndex = 0;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Household Details";
            this.gbDetails.Enter += new System.EventHandler(this.gbDetails_Enter);
            // 
            // tlpDisplay03
            // 
            this.tlpDisplay03.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDisplay03.ColumnCount = 6;
            this.tlpDisplay03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpDisplay03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpDisplay03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpDisplay03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tlpDisplay03.Controls.Add(this.lblWardDisplay, 0, 3);
            this.tlpDisplay03.Controls.Add(this.label8, 0, 3);
            this.tlpDisplay03.Controls.Add(this.lblStatus, 3, 0);
            this.tlpDisplay03.Controls.Add(this.lblCode, 0, 0);
            this.tlpDisplay03.Controls.Add(this.lblCodeDisplay, 1, 0);
            this.tlpDisplay03.Controls.Add(this.lblStatusDisplay, 4, 0);
            this.tlpDisplay03.Controls.Add(this.lblSocialWorker, 0, 1);
            this.tlpDisplay03.Controls.Add(this.lblDistrict, 0, 2);
            this.tlpDisplay03.Controls.Add(this.lblSocialWorkerDisplay, 1, 1);
            this.tlpDisplay03.Controls.Add(this.lblDistrictDisplay, 1, 2);
            this.tlpDisplay03.Controls.Add(this.lblSubCounty, 3, 2);
            this.tlpDisplay03.Controls.Add(this.lblSubCountyDisplay, 4, 2);
            this.tlpDisplay03.Controls.Add(this.lblVillageDisplay, 4, 3);
            this.tlpDisplay03.Controls.Add(this.lblVillage, 3, 3);
            this.tlpDisplay03.Location = new System.Drawing.Point(40, 37);
            this.tlpDisplay03.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpDisplay03.Name = "tlpDisplay03";
            this.tlpDisplay03.RowCount = 4;
            this.tlpDisplay03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDisplay03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDisplay03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDisplay03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDisplay03.Size = new System.Drawing.Size(925, 148);
            this.tlpDisplay03.TabIndex = 31;
            // 
            // lblWardDisplay
            // 
            this.lblWardDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblWardDisplay.AutoSize = true;
            this.lblWardDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWardDisplay.Location = new System.Drawing.Point(204, 121);
            this.lblWardDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWardDisplay.Name = "lblWardDisplay";
            this.lblWardDisplay.Size = new System.Drawing.Size(94, 17);
            this.lblWardDisplay.TabIndex = 12;
            this.lblWardDisplay.Text = "Parich/Ward: ";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 121);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Parich/Ward:";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(441, 10);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 17);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status: ";
            // 
            // lblCode
            // 
            this.lblCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(4, 10);
            this.lblCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(121, 17);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Household Code: ";
            // 
            // lblCodeDisplay
            // 
            this.lblCodeDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCodeDisplay.AutoSize = true;
            this.lblCodeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodeDisplay.Location = new System.Drawing.Point(204, 10);
            this.lblCodeDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodeDisplay.Name = "lblCodeDisplay";
            this.lblCodeDisplay.Size = new System.Drawing.Size(114, 17);
            this.lblCodeDisplay.TabIndex = 1;
            this.lblCodeDisplay.Text = "0000-0000-0000";
            // 
            // lblStatusDisplay
            // 
            this.lblStatusDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatusDisplay.AutoSize = true;
            this.lblStatusDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusDisplay.Location = new System.Drawing.Point(641, 6);
            this.lblStatusDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusDisplay.Name = "lblStatusDisplay";
            this.lblStatusDisplay.Size = new System.Drawing.Size(74, 25);
            this.lblStatusDisplay.TabIndex = 2;
            this.lblStatusDisplay.Text = "Status";
            // 
            // lblSocialWorker
            // 
            this.lblSocialWorker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSocialWorker.AutoSize = true;
            this.lblSocialWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSocialWorker.Location = new System.Drawing.Point(4, 47);
            this.lblSocialWorker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSocialWorker.Name = "lblSocialWorker";
            this.lblSocialWorker.Size = new System.Drawing.Size(104, 17);
            this.lblSocialWorker.TabIndex = 4;
            this.lblSocialWorker.Text = "Social Worker: ";
            // 
            // lblDistrict
            // 
            this.lblDistrict.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistrict.Location = new System.Drawing.Point(4, 84);
            this.lblDistrict.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(51, 17);
            this.lblDistrict.TabIndex = 5;
            this.lblDistrict.Text = "District";
            // 
            // lblSocialWorkerDisplay
            // 
            this.lblSocialWorkerDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSocialWorkerDisplay.AutoSize = true;
            this.lblSocialWorkerDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSocialWorkerDisplay.Location = new System.Drawing.Point(204, 47);
            this.lblSocialWorkerDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSocialWorkerDisplay.Name = "lblSocialWorkerDisplay";
            this.lblSocialWorkerDisplay.Size = new System.Drawing.Size(96, 17);
            this.lblSocialWorkerDisplay.TabIndex = 6;
            this.lblSocialWorkerDisplay.Text = "Social Worker";
            // 
            // lblDistrictDisplay
            // 
            this.lblDistrictDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistrictDisplay.AutoSize = true;
            this.lblDistrictDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistrictDisplay.Location = new System.Drawing.Point(204, 84);
            this.lblDistrictDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDistrictDisplay.Name = "lblDistrictDisplay";
            this.lblDistrictDisplay.Size = new System.Drawing.Size(55, 17);
            this.lblDistrictDisplay.TabIndex = 7;
            this.lblDistrictDisplay.Text = "District ";
            // 
            // lblSubCounty
            // 
            this.lblSubCounty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubCounty.AutoSize = true;
            this.lblSubCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCounty.Location = new System.Drawing.Point(441, 84);
            this.lblSubCounty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubCounty.Name = "lblSubCounty";
            this.lblSubCounty.Size = new System.Drawing.Size(81, 17);
            this.lblSubCounty.TabIndex = 9;
            this.lblSubCounty.Text = "Sub County";
            // 
            // lblSubCountyDisplay
            // 
            this.lblSubCountyDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubCountyDisplay.AutoSize = true;
            this.lblSubCountyDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCountyDisplay.Location = new System.Drawing.Point(641, 84);
            this.lblSubCountyDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubCountyDisplay.Name = "lblSubCountyDisplay";
            this.lblSubCountyDisplay.Size = new System.Drawing.Size(81, 17);
            this.lblSubCountyDisplay.TabIndex = 8;
            this.lblSubCountyDisplay.Text = "Sub County";
            // 
            // lblVillageDisplay
            // 
            this.lblVillageDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVillageDisplay.AutoSize = true;
            this.lblVillageDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVillageDisplay.Location = new System.Drawing.Point(641, 121);
            this.lblVillageDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVillageDisplay.Name = "lblVillageDisplay";
            this.lblVillageDisplay.Size = new System.Drawing.Size(77, 17);
            this.lblVillageDisplay.TabIndex = 10;
            this.lblVillageDisplay.Text = "Village/Cell";
            // 
            // lblVillage
            // 
            this.lblVillage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVillage.AutoSize = true;
            this.lblVillage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVillage.Location = new System.Drawing.Point(441, 121);
            this.lblVillage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVillage.Name = "lblVillage";
            this.lblVillage.Size = new System.Drawing.Size(81, 17);
            this.lblVillage.TabIndex = 13;
            this.lblVillage.Text = "Village/Cell:";
            // 
            // llblBack
            // 
            this.llblBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblBack.AutoSize = true;
            this.llblBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblBack.Location = new System.Drawing.Point(923, 20);
            this.llblBack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblBack.Name = "llblBack";
            this.llblBack.Size = new System.Drawing.Size(39, 17);
            this.llblBack.TabIndex = 30;
            this.llblBack.TabStop = true;
            this.llblBack.Text = "Back";
            this.llblBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblBack_LinkClicked);
            // 
            // gbRecords
            // 
            this.gbRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRecords.Controls.Add(this.tlpDisplay04);
            this.gbRecords.Controls.Add(this.dgvRecords);
            this.gbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRecords.Location = new System.Drawing.Point(4, 580);
            this.gbRecords.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbRecords.Name = "gbRecords";
            this.gbRecords.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbRecords.Size = new System.Drawing.Size(1205, 348);
            this.gbRecords.TabIndex = 1;
            this.gbRecords.TabStop = false;
            this.gbRecords.Text = "Household Records";
            // 
            // tlpDisplay04
            // 
            this.tlpDisplay04.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDisplay04.ColumnCount = 6;
            this.tlpDisplay04.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpDisplay04.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay04.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpDisplay04.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpDisplay04.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay04.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpDisplay04.Controls.Add(this.lblRecordType, 0, 0);
            this.tlpDisplay04.Controls.Add(this.cbRecordType, 1, 0);
            this.tlpDisplay04.Location = new System.Drawing.Point(43, 82);
            this.tlpDisplay04.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpDisplay04.Name = "tlpDisplay04";
            this.tlpDisplay04.RowCount = 1;
            this.tlpDisplay04.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay04.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpDisplay04.Size = new System.Drawing.Size(1139, 37);
            this.tlpDisplay04.TabIndex = 4;
            // 
            // lblRecordType
            // 
            this.lblRecordType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRecordType.AutoSize = true;
            this.lblRecordType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordType.Location = new System.Drawing.Point(4, 10);
            this.lblRecordType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecordType.Name = "lblRecordType";
            this.lblRecordType.Size = new System.Drawing.Size(98, 17);
            this.lblRecordType.TabIndex = 1;
            this.lblRecordType.Text = "Record Type: ";
            // 
            // cbRecordType
            // 
            this.cbRecordType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRecordType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRecordType.FormattingEnabled = true;
            this.cbRecordType.Location = new System.Drawing.Point(204, 6);
            this.cbRecordType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbRecordType.Name = "cbRecordType";
            this.cbRecordType.Size = new System.Drawing.Size(308, 25);
            this.cbRecordType.TabIndex = 3;
            this.cbRecordType.SelectedIndexChanged += new System.EventHandler(this.cbRecordType_SelectedIndexChanged);
            // 
            // dgvRecords
            // 
            this.dgvRecords.AllowUserToAddRows = false;
            this.dgvRecords.AllowUserToDeleteRows = false;
            this.dgvRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gclID,
            this.gclRtpId,
            this.gclRtpName,
            this.gclDate});
            this.dgvRecords.Location = new System.Drawing.Point(8, 128);
            this.dgvRecords.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvRecords.MultiSelect = false;
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.Size = new System.Drawing.Size(1189, 213);
            this.dgvRecords.TabIndex = 1;
            this.dgvRecords.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecords_CellDoubleClick);
            // 
            // gclID
            // 
            this.gclID.DataPropertyName = "rcd_id";
            this.gclID.HeaderText = "ID";
            this.gclID.Name = "gclID";
            this.gclID.ReadOnly = true;
            this.gclID.Visible = false;
            // 
            // gclRtpId
            // 
            this.gclRtpId.DataPropertyName = "rtp_id";
            this.gclRtpId.HeaderText = "RtpId";
            this.gclRtpId.Name = "gclRtpId";
            this.gclRtpId.Visible = false;
            // 
            // gclRtpName
            // 
            this.gclRtpName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclRtpName.DataPropertyName = "rtp_name";
            this.gclRtpName.HeaderText = "Record Type";
            this.gclRtpName.Name = "gclRtpName";
            this.gclRtpName.ReadOnly = true;
            // 
            // gclDate
            // 
            this.gclDate.DataPropertyName = "the_date_display";
            this.gclDate.HeaderText = "Date";
            this.gclDate.Name = "gclDate";
            this.gclDate.ReadOnly = true;
            this.gclDate.Width = 200;
            // 
            // gbNew
            // 
            this.gbNew.Controls.Add(this.tlpDisplay01);
            this.gbNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNew.Location = new System.Drawing.Point(4, 7);
            this.gbNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbNew.Name = "gbNew";
            this.gbNew.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbNew.Size = new System.Drawing.Size(224, 342);
            this.gbNew.TabIndex = 2;
            this.gbNew.TabStop = false;
            this.gbNew.Text = "New Records";
            // 
            // tlpDisplay01
            // 
            this.tlpDisplay01.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpDisplay01.ColumnCount = 1;
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay01.Controls.Add(this.lblHomevisitNew, 0, 2);
            this.tlpDisplay01.Controls.Add(this.llblHouseholdAssessment, 0, 0);
            this.tlpDisplay01.Controls.Add(this.llblViralLoad, 0, 5);
            this.tlpDisplay01.Controls.Add(this.llblReferral, 0, 4);
            this.tlpDisplay01.Controls.Add(this.llblHomeVisit, 0, 3);
            this.tlpDisplay01.Controls.Add(this.llblHip_v2, 0, 1);
            this.tlpDisplay01.Controls.Add(this.lblAdherence, 0, 6);
            this.tlpDisplay01.Controls.Add(this.lblGBV, 0, 7);
            this.tlpDisplay01.Controls.Add(this.llblHomeVisitArchive, 0, 8);
            this.tlpDisplay01.Controls.Add(this.llblHip, 0, 9);
            this.tlpDisplay01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpDisplay01.Location = new System.Drawing.Point(8, 23);
            this.tlpDisplay01.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpDisplay01.Name = "tlpDisplay01";
            this.tlpDisplay01.RowCount = 12;
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.226686F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.25212F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.25212F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.25212F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.25212F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.25212F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.25212F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.25212F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.25212F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.25212F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.25212F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.25212F));
            this.tlpDisplay01.Size = new System.Drawing.Size(208, 319);
            this.tlpDisplay01.TabIndex = 3;
            // 
            // lblHomevisitNew
            // 
            this.lblHomevisitNew.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHomevisitNew.AutoSize = true;
            this.lblHomevisitNew.Location = new System.Drawing.Point(5, 60);
            this.lblHomevisitNew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHomevisitNew.Name = "lblHomevisitNew";
            this.lblHomevisitNew.Size = new System.Drawing.Size(75, 17);
            this.lblHomevisitNew.TabIndex = 35;
            this.lblHomevisitNew.TabStop = true;
            this.lblHomevisitNew.Text = "Home Visit";
            this.lblHomevisitNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblHomevisitNew_LinkClicked);
            // 
            // llblHouseholdAssessment
            // 
            this.llblHouseholdAssessment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblHouseholdAssessment.AutoSize = true;
            this.llblHouseholdAssessment.Location = new System.Drawing.Point(5, 6);
            this.llblHouseholdAssessment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblHouseholdAssessment.Name = "llblHouseholdAssessment";
            this.llblHouseholdAssessment.Size = new System.Drawing.Size(156, 17);
            this.llblHouseholdAssessment.TabIndex = 0;
            this.llblHouseholdAssessment.TabStop = true;
            this.llblHouseholdAssessment.Text = "Household Assessment";
            this.llblHouseholdAssessment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblHouseholdAssessment_LinkClicked);
            // 
            // llblHip
            // 
            this.llblHip.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblHip.AutoSize = true;
            this.llblHip.Location = new System.Drawing.Point(4, 242);
            this.llblHip.Name = "llblHip";
            this.llblHip.Size = new System.Drawing.Size(81, 17);
            this.llblHip.TabIndex = 32;
            this.llblHip.TabStop = true;
            this.llblHip.Text = "HIP Archive";
            this.llblHip.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblHip_LinkClicked);
            // 
            // lblGBV
            // 
            this.lblGBV.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGBV.AutoSize = true;
            this.lblGBV.Location = new System.Drawing.Point(5, 190);
            this.lblGBV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGBV.Name = "lblGBV";
            this.lblGBV.Size = new System.Drawing.Size(137, 17);
            this.lblGBV.TabIndex = 34;
            this.lblGBV.TabStop = true;
            this.lblGBV.Text = "GBV Screening Tool";
            this.lblGBV.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblGBV_LinkClicked);
            // 
            // lblAdherence
            // 
            this.lblAdherence.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAdherence.AutoSize = true;
            this.lblAdherence.Location = new System.Drawing.Point(5, 164);
            this.lblAdherence.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdherence.Name = "lblAdherence";
            this.lblAdherence.Size = new System.Drawing.Size(174, 17);
            this.lblAdherence.TabIndex = 33;
            this.lblAdherence.TabStop = true;
            this.lblAdherence.Text = "Adherence Monitoring tool";
            this.lblAdherence.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAdherence_LinkClicked);
            // 
            // llblHomeVisitArchive
            // 
            this.llblHomeVisitArchive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblHomeVisitArchive.AutoSize = true;
            this.llblHomeVisitArchive.Location = new System.Drawing.Point(5, 216);
            this.llblHomeVisitArchive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblHomeVisitArchive.Name = "llblHomeVisitArchive";
            this.llblHomeVisitArchive.Size = new System.Drawing.Size(136, 17);
            this.llblHomeVisitArchive.TabIndex = 4;
            this.llblHomeVisitArchive.TabStop = true;
            this.llblHomeVisitArchive.Text = "Home Visit (Archive)";
            this.llblHomeVisitArchive.Visible = false;
            this.llblHomeVisitArchive.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblHomeVisitArchive_LinkClicked);
            // 
            // llblViralLoad
            // 
            this.llblViralLoad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblViralLoad.AutoSize = true;
            this.llblViralLoad.Location = new System.Drawing.Point(4, 138);
            this.llblViralLoad.Name = "llblViralLoad";
            this.llblViralLoad.Size = new System.Drawing.Size(174, 17);
            this.llblViralLoad.TabIndex = 32;
            this.llblViralLoad.TabStop = true;
            this.llblViralLoad.Text = "Viral Load Monitoring Tool";
            this.llblViralLoad.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblViralLoad_LinkClicked);
            // 
            // llblReferral
            // 
            this.llblReferral.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblReferral.AutoSize = true;
            this.llblReferral.Location = new System.Drawing.Point(5, 112);
            this.llblReferral.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblReferral.Name = "llblReferral";
            this.llblReferral.Size = new System.Drawing.Size(59, 17);
            this.llblReferral.TabIndex = 3;
            this.llblReferral.TabStop = true;
            this.llblReferral.Text = "Referral";
            this.llblReferral.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblReferral_LinkClicked);
            // 
            // llblHomeVisit
            // 
            this.llblHomeVisit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblHomeVisit.AutoSize = true;
            this.llblHomeVisit.Location = new System.Drawing.Point(5, 86);
            this.llblHomeVisit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblHomeVisit.Name = "llblHomeVisit";
            this.llblHomeVisit.Size = new System.Drawing.Size(126, 17);
            this.llblHomeVisit.TabIndex = 2;
            this.llblHomeVisit.TabStop = true;
            this.llblHomeVisit.Text = "Home Visit Archive";
            this.llblHomeVisit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblHomeVisit_LinkClicked);
            // 
            // llblLinkages_register
            // 
            this.llblLinkages_register.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblLinkages_register.AutoSize = true;
            this.llblLinkages_register.Location = new System.Drawing.Point(5, 68);
            this.llblLinkages_register.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblLinkages_register.Name = "llblLinkages_register";
            this.llblLinkages_register.Size = new System.Drawing.Size(124, 17);
            this.llblLinkages_register.TabIndex = 14;
            this.llblLinkages_register.TabStop = true;
            this.llblLinkages_register.Text = "Linkages Tracking";
            this.llblLinkages_register.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblLinkages_register_LinkClicked);
            // 
            // llblOVCIdentificationPrioritization
            // 
            this.llblOVCIdentificationPrioritization.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblOVCIdentificationPrioritization.AutoSize = true;
            this.llblOVCIdentificationPrioritization.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblOVCIdentificationPrioritization.Location = new System.Drawing.Point(5, 121);
            this.llblOVCIdentificationPrioritization.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblOVCIdentificationPrioritization.Name = "llblOVCIdentificationPrioritization";
            this.llblOVCIdentificationPrioritization.Size = new System.Drawing.Size(178, 34);
            this.llblOVCIdentificationPrioritization.TabIndex = 6;
            this.llblOVCIdentificationPrioritization.TabStop = true;
            this.llblOVCIdentificationPrioritization.Text = "Uganda OVC Identification and Prioritization";
            this.llblOVCIdentificationPrioritization.Visible = false;
            this.llblOVCIdentificationPrioritization.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblOVCIdentificationPrioritization_LinkClicked);
            // 
            // llblHouseholdDetails
            // 
            this.llblHouseholdDetails.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblHouseholdDetails.AutoSize = true;
            this.llblHouseholdDetails.Location = new System.Drawing.Point(5, 8);
            this.llblHouseholdDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblHouseholdDetails.Name = "llblHouseholdDetails";
            this.llblHouseholdDetails.Size = new System.Drawing.Size(123, 17);
            this.llblHouseholdDetails.TabIndex = 5;
            this.llblHouseholdDetails.TabStop = true;
            this.llblHouseholdDetails.Text = "Household Details";
            this.llblHouseholdDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblHouseholdDetails_LinkClicked);
            // 
            // llblHouseholdMembers
            // 
            this.llblHouseholdMembers.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblHouseholdMembers.AutoSize = true;
            this.llblHouseholdMembers.Location = new System.Drawing.Point(5, 40);
            this.llblHouseholdMembers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblHouseholdMembers.Name = "llblHouseholdMembers";
            this.llblHouseholdMembers.Size = new System.Drawing.Size(138, 17);
            this.llblHouseholdMembers.TabIndex = 1;
            this.llblHouseholdMembers.TabStop = true;
            this.llblHouseholdMembers.Text = "Household Members";
            this.llblHouseholdMembers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblHouseholdMembers_LinkClicked);
            // 
            // gbMembers
            // 
            this.gbMembers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMembers.Controls.Add(this.dgvMembers);
            this.gbMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMembers.Location = new System.Drawing.Point(228, 272);
            this.gbMembers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbMembers.Name = "gbMembers";
            this.gbMembers.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbMembers.Size = new System.Drawing.Size(973, 272);
            this.gbMembers.TabIndex = 3;
            this.gbMembers.TabStop = false;
            this.gbMembers.Text = "Household Members";
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
            this.gclHhmId,
            this.gclNumber,
            this.gclFirstName,
            this.gclLastName,
            this.gclGender,
            this.gclYearOfBirth});
            this.dgvMembers.Location = new System.Drawing.Point(8, 23);
            this.dgvMembers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvMembers.MultiSelect = false;
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.Size = new System.Drawing.Size(957, 242);
            this.dgvMembers.TabIndex = 22;
            this.dgvMembers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMembers_CellDoubleClick);
            // 
            // gclHhmId
            // 
            this.gclHhmId.DataPropertyName = "hhm_id";
            this.gclHhmId.HeaderText = "ID";
            this.gclHhmId.Name = "gclHhmId";
            this.gclHhmId.ReadOnly = true;
            this.gclHhmId.Visible = false;
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
            this.gclFirstName.DataPropertyName = "hhm_first_name";
            this.gclFirstName.HeaderText = "First Name";
            this.gclFirstName.Name = "gclFirstName";
            this.gclFirstName.ReadOnly = true;
            // 
            // gclLastName
            // 
            this.gclLastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclLastName.DataPropertyName = "hhm_last_name";
            this.gclLastName.HeaderText = "Last Name";
            this.gclLastName.Name = "gclLastName";
            this.gclLastName.ReadOnly = true;
            // 
            // gclGender
            // 
            this.gclGender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclGender.DataPropertyName = "gnd_name";
            this.gclGender.HeaderText = "Sex";
            this.gclGender.Name = "gclGender";
            this.gclGender.ReadOnly = true;
            // 
            // gclYearOfBirth
            // 
            this.gclYearOfBirth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclYearOfBirth.DataPropertyName = "year_of_birth";
            this.gclYearOfBirth.HeaderText = "Year Of Birth";
            this.gclYearOfBirth.Name = "gclYearOfBirth";
            this.gclYearOfBirth.ReadOnly = true;
            // 
            // gbManage
            // 
            this.gbManage.Controls.Add(this.tlpDisplay02);
            this.gbManage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbManage.Location = new System.Drawing.Point(4, 357);
            this.gbManage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbManage.Name = "gbManage";
            this.gbManage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbManage.Size = new System.Drawing.Size(224, 215);
            this.gbManage.TabIndex = 4;
            this.gbManage.TabStop = false;
            this.gbManage.Text = "Manage Records";
            // 
            // tlpDisplay02
            // 
            this.tlpDisplay02.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpDisplay02.ColumnCount = 1;
            this.tlpDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay02.Controls.Add(this.llblLinkages_register, 0, 2);
            this.tlpDisplay02.Controls.Add(this.llblHouseholdMembers, 0, 1);
            this.tlpDisplay02.Controls.Add(this.llblHouseholdDetails, 0, 0);
            this.tlpDisplay02.Controls.Add(this.llblOVCIdentificationPrioritization, 0, 4);
            this.tlpDisplay02.Controls.Add(this.lbl_risk_assessment, 0, 3);
            this.tlpDisplay02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpDisplay02.Location = new System.Drawing.Point(8, 23);
            this.tlpDisplay02.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpDisplay02.Name = "tlpDisplay02";
            this.tlpDisplay02.RowCount = 6;
            this.tlpDisplay02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplay02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplay02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.4321F));
            this.tlpDisplay02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.04938F));
            this.tlpDisplay02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.22078F));
            this.tlpDisplay02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay02.Size = new System.Drawing.Size(208, 185);
            this.tlpDisplay02.TabIndex = 3;
            // 
            // lbl_risk_assessment
            // 
            this.lbl_risk_assessment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_risk_assessment.AutoSize = true;
            this.lbl_risk_assessment.Location = new System.Drawing.Point(5, 94);
            this.lbl_risk_assessment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_risk_assessment.Name = "lbl_risk_assessment";
            this.lbl_risk_assessment.Size = new System.Drawing.Size(162, 17);
            this.lbl_risk_assessment.TabIndex = 15;
            this.lbl_risk_assessment.TabStop = true;
            this.lbl_risk_assessment.Text = "Risk Assessment Details";
            this.lbl_risk_assessment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_risk_assessment_LinkClicked);
            // 
            // llblHip_v2
            // 
            this.llblHip_v2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblHip_v2.AutoSize = true;
            this.llblHip_v2.Location = new System.Drawing.Point(5, 34);
            this.llblHip_v2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblHip_v2.Name = "llblHip_v2";
            this.llblHip_v2.Size = new System.Drawing.Size(193, 17);
            this.llblHip_v2.TabIndex = 36;
            this.llblHip_v2.TabStop = true;
            this.llblHip_v2.Text = "Household Improvement Plan";
            this.llblHip_v2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblHip_v2_LinkClicked);
            // 
            // frmHousehold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbManage);
            this.Controls.Add(this.gbMembers);
            this.Controls.Add(this.gbNew);
            this.Controls.Add(this.gbRecords);
            this.Controls.Add(this.gbDetails);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmHousehold";
            this.Size = new System.Drawing.Size(1213, 930);
            this.Load += new System.EventHandler(this.frmHousehold_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmHousehold_Paint);
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            this.tlpDisplay03.ResumeLayout(false);
            this.tlpDisplay03.PerformLayout();
            this.gbRecords.ResumeLayout(false);
            this.tlpDisplay04.ResumeLayout(false);
            this.tlpDisplay04.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.gbNew.ResumeLayout(false);
            this.tlpDisplay01.ResumeLayout(false);
            this.tlpDisplay01.PerformLayout();
            this.gbMembers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.gbManage.ResumeLayout(false);
            this.tlpDisplay02.ResumeLayout(false);
            this.tlpDisplay02.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.GroupBox gbRecords;
        private System.Windows.Forms.GroupBox gbNew;
        private System.Windows.Forms.LinkLabel llblHouseholdAssessment;
        private System.Windows.Forms.DataGridView dgvRecords;
        private System.Windows.Forms.Label lblCodeDisplay;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.LinkLabel llblHomeVisit;
        private System.Windows.Forms.GroupBox gbMembers;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay01;
        private System.Windows.Forms.LinkLabel llblBack;
        private System.Windows.Forms.LinkLabel llblReferral;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay03;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusDisplay;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay04;
        private System.Windows.Forms.ComboBox cbRecordType;
        private System.Windows.Forms.Label lblRecordType;
        private System.Windows.Forms.GroupBox gbManage;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay02;
        private System.Windows.Forms.LinkLabel llblHouseholdMembers;
        private System.Windows.Forms.LinkLabel llblHouseholdDetails;
        private System.Windows.Forms.Label lblWardDisplay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSocialWorker;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.Label lblSocialWorkerDisplay;
        private System.Windows.Forms.Label lblDistrictDisplay;
        private System.Windows.Forms.Label lblSubCounty;
        private System.Windows.Forms.Label lblSubCountyDisplay;
        private System.Windows.Forms.Label lblVillageDisplay;
        private System.Windows.Forms.Label lblVillage;
        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.LinkLabel llblOVCIdentificationPrioritization;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclRtpId;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclRtpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclHhmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclYearOfBirth;
        private System.Windows.Forms.LinkLabel llblHomeVisitArchive;
        private System.Windows.Forms.LinkLabel llblLinkages_register;
        private System.Windows.Forms.LinkLabel lbl_risk_assessment;
        private System.Windows.Forms.LinkLabel llblHip;
        private System.Windows.Forms.LinkLabel llblViralLoad;
        private System.Windows.Forms.LinkLabel lblAdherence;
        private System.Windows.Forms.LinkLabel lblGBV;
        private System.Windows.Forms.LinkLabel lblHomevisitNew;
        private System.Windows.Forms.LinkLabel llblHip_v2;
    }
}
