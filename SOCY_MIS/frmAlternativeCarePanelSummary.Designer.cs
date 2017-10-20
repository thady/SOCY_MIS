namespace SOCY_MIS
{
    partial class frmAlternativeCarePanelSummary
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
            this.gbAlternativeCareTitle = new System.Windows.Forms.GroupBox();
            this.llblBackTop = new System.Windows.Forms.LinkLabel();
            this.gbDistrict = new System.Windows.Forms.GroupBox();
            this.btnLineDelete = new System.Windows.Forms.Button();
            this.lblTotalNumber = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvLine = new System.Windows.Forms.DataGridView();
            this.tplButton02 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLineCancel = new System.Windows.Forms.Button();
            this.btnLineSave = new System.Windows.Forms.Button();
            this.llblBackBottom = new System.Windows.Forms.LinkLabel();
            this.tlpDisplay03 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSupportExtended = new System.Windows.Forms.TextBox();
            this.lblSupportExtended = new System.Windows.Forms.Label();
            this.tlpDisplay02 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPanelEstablished = new System.Windows.Forms.Label();
            this.lblDistrictVal = new System.Windows.Forms.Label();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.cbDistrict = new System.Windows.Forms.ComboBox();
            this.lblPanelFunctional = new System.Windows.Forms.Label();
            this.pnlPanelFunctional = new System.Windows.Forms.Panel();
            this.rbtnPanelFunctionalNo = new System.Windows.Forms.RadioButton();
            this.rbtnPanelFunctionalYes = new System.Windows.Forms.RadioButton();
            this.pnlPanelEstablished = new System.Windows.Forms.Panel();
            this.rbtnPanelEstablishedNo = new System.Windows.Forms.RadioButton();
            this.rbtnPanelEstablishedYes = new System.Windows.Forms.RadioButton();
            this.lblId = new System.Windows.Forms.Label();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tlpDisplay01 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDateVal = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblPartner = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.cbPartner = new System.Windows.Forms.ComboBox();
            this.lblPartnerVal = new System.Windows.Forms.Label();
            this.lblFinancialYear = new System.Windows.Forms.Label();
            this.cbFinancialYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRegion = new System.Windows.Forms.ComboBox();
            this.lblRegion = new System.Windows.Forms.Label();
            this.lblRegionVal = new System.Windows.Forms.Label();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDistrict = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gclOfcId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbAlternativeCareTitle.SuspendLayout();
            this.gbDistrict.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLine)).BeginInit();
            this.tplButton02.SuspendLayout();
            this.tlpDisplay03.SuspendLayout();
            this.tlpDisplay02.SuspendLayout();
            this.pnlPanelFunctional.SuspendLayout();
            this.pnlPanelEstablished.SuspendLayout();
            this.tplButton01.SuspendLayout();
            this.tlpDisplay01.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAlternativeCareTitle
            // 
            this.gbAlternativeCareTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAlternativeCareTitle.Controls.Add(this.llblBackTop);
            this.gbAlternativeCareTitle.Controls.Add(this.gbDistrict);
            this.gbAlternativeCareTitle.Controls.Add(this.tplButton01);
            this.gbAlternativeCareTitle.Controls.Add(this.tlpDisplay01);
            this.gbAlternativeCareTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAlternativeCareTitle.Location = new System.Drawing.Point(3, 6);
            this.gbAlternativeCareTitle.Name = "gbAlternativeCareTitle";
            this.gbAlternativeCareTitle.Size = new System.Drawing.Size(714, 494);
            this.gbAlternativeCareTitle.TabIndex = 1;
            this.gbAlternativeCareTitle.TabStop = false;
            this.gbAlternativeCareTitle.Text = "Alternative Care Panel Summary";
            // 
            // llblBackTop
            // 
            this.llblBackTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblBackTop.AutoSize = true;
            this.llblBackTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblBackTop.Location = new System.Drawing.Point(676, 16);
            this.llblBackTop.Name = "llblBackTop";
            this.llblBackTop.Size = new System.Drawing.Size(32, 13);
            this.llblBackTop.TabIndex = 54;
            this.llblBackTop.TabStop = true;
            this.llblBackTop.Text = "Back";
            this.llblBackTop.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblBack_LinkClicked);
            // 
            // gbDistrict
            // 
            this.gbDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDistrict.Controls.Add(this.btnLineDelete);
            this.gbDistrict.Controls.Add(this.lblTotalNumber);
            this.gbDistrict.Controls.Add(this.lblTotal);
            this.gbDistrict.Controls.Add(this.dgvLine);
            this.gbDistrict.Controls.Add(this.tplButton02);
            this.gbDistrict.Controls.Add(this.tlpDisplay03);
            this.gbDistrict.Controls.Add(this.tlpDisplay02);
            this.gbDistrict.Location = new System.Drawing.Point(7, 135);
            this.gbDistrict.Name = "gbDistrict";
            this.gbDistrict.Size = new System.Drawing.Size(701, 353);
            this.gbDistrict.TabIndex = 53;
            this.gbDistrict.TabStop = false;
            this.gbDistrict.Text = "District";
            // 
            // btnLineDelete
            // 
            this.btnLineDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLineDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLineDelete.Location = new System.Drawing.Point(620, 324);
            this.btnLineDelete.Name = "btnLineDelete";
            this.btnLineDelete.Size = new System.Drawing.Size(75, 23);
            this.btnLineDelete.TabIndex = 57;
            this.btnLineDelete.Text = "Delete";
            this.btnLineDelete.UseVisualStyleBackColor = true;
            this.btnLineDelete.Click += new System.EventHandler(this.btnLineDelete_Click);
            // 
            // lblTotalNumber
            // 
            this.lblTotalNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalNumber.AutoSize = true;
            this.lblTotalNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalNumber.Location = new System.Drawing.Point(46, 329);
            this.lblTotalNumber.Name = "lblTotalNumber";
            this.lblTotalNumber.Size = new System.Drawing.Size(10, 13);
            this.lblTotalNumber.TabIndex = 56;
            this.lblTotalNumber.Text = "-";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(6, 329);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 55;
            this.lblTotal.Text = "Total:";
            // 
            // dgvLine
            // 
            this.dgvLine.AllowUserToAddRows = false;
            this.dgvLine.AllowUserToDeleteRows = false;
            this.dgvLine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gclID,
            this.gclDistrict,
            this.gclDelete,
            this.gclOfcId});
            this.dgvLine.Location = new System.Drawing.Point(6, 158);
            this.dgvLine.MultiSelect = false;
            this.dgvLine.Name = "dgvLine";
            this.dgvLine.Size = new System.Drawing.Size(690, 160);
            this.dgvLine.TabIndex = 54;
            this.dgvLine.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLine_CellDoubleClick);
            this.dgvLine.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvLine_RowPostPaint);
            // 
            // tplButton02
            // 
            this.tplButton02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplButton02.ColumnCount = 5;
            this.tplButton02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tplButton02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tplButton02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tplButton02.Controls.Add(this.btnLineCancel, 3, 0);
            this.tplButton02.Controls.Add(this.btnLineSave, 1, 0);
            this.tplButton02.Controls.Add(this.llblBackBottom, 4, 0);
            this.tplButton02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tplButton02.Location = new System.Drawing.Point(23, 112);
            this.tplButton02.Name = "tplButton02";
            this.tplButton02.RowCount = 1;
            this.tplButton02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplButton02.Size = new System.Drawing.Size(654, 40);
            this.tplButton02.TabIndex = 53;
            // 
            // btnLineCancel
            // 
            this.btnLineCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLineCancel.Location = new System.Drawing.Point(360, 8);
            this.btnLineCancel.Name = "btnLineCancel";
            this.btnLineCancel.Size = new System.Drawing.Size(75, 23);
            this.btnLineCancel.TabIndex = 15;
            this.btnLineCancel.Text = "Cancel";
            this.btnLineCancel.UseVisualStyleBackColor = true;
            this.btnLineCancel.Click += new System.EventHandler(this.btnLineCancel_Click);
            // 
            // btnLineSave
            // 
            this.btnLineSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLineSave.Location = new System.Drawing.Point(219, 8);
            this.btnLineSave.Name = "btnLineSave";
            this.btnLineSave.Size = new System.Drawing.Size(75, 23);
            this.btnLineSave.TabIndex = 14;
            this.btnLineSave.Text = "Save";
            this.btnLineSave.UseVisualStyleBackColor = true;
            this.btnLineSave.Click += new System.EventHandler(this.btnLineSave_Click);
            // 
            // llblBackBottom
            // 
            this.llblBackBottom.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.llblBackBottom.AutoSize = true;
            this.llblBackBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblBackBottom.Location = new System.Drawing.Point(619, 13);
            this.llblBackBottom.Name = "llblBackBottom";
            this.llblBackBottom.Size = new System.Drawing.Size(32, 13);
            this.llblBackBottom.TabIndex = 24;
            this.llblBackBottom.TabStop = true;
            this.llblBackBottom.Text = "Back";
            this.llblBackBottom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblBack_LinkClicked);
            // 
            // tlpDisplay03
            // 
            this.tlpDisplay03.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDisplay03.ColumnCount = 3;
            this.tlpDisplay03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDisplay03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay03.Controls.Add(this.txtSupportExtended, 1, 0);
            this.tlpDisplay03.Controls.Add(this.lblSupportExtended, 0, 0);
            this.tlpDisplay03.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpDisplay03.Location = new System.Drawing.Point(23, 83);
            this.tlpDisplay03.Name = "tlpDisplay03";
            this.tlpDisplay03.RowCount = 1;
            this.tlpDisplay03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay03.Size = new System.Drawing.Size(654, 30);
            this.tlpDisplay03.TabIndex = 35;
            // 
            // txtSupportExtended
            // 
            this.txtSupportExtended.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSupportExtended.Enabled = false;
            this.txtSupportExtended.Location = new System.Drawing.Point(153, 3);
            this.txtSupportExtended.Name = "txtSupportExtended";
            this.txtSupportExtended.Size = new System.Drawing.Size(478, 20);
            this.txtSupportExtended.TabIndex = 13;
            // 
            // lblSupportExtended
            // 
            this.lblSupportExtended.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSupportExtended.AutoSize = true;
            this.lblSupportExtended.Location = new System.Drawing.Point(3, 2);
            this.lblSupportExtended.Name = "lblSupportExtended";
            this.lblSupportExtended.Size = new System.Drawing.Size(143, 26);
            this.lblSupportExtended.TabIndex = 12;
            this.lblSupportExtended.Text = "Type of support extended to alternative care panel:";
            // 
            // tlpDisplay02
            // 
            this.tlpDisplay02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDisplay02.ColumnCount = 6;
            this.tlpDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay02.Controls.Add(this.lblPanelEstablished, 0, 1);
            this.tlpDisplay02.Controls.Add(this.lblDistrictVal, 2, 0);
            this.tlpDisplay02.Controls.Add(this.lblDistrict, 0, 0);
            this.tlpDisplay02.Controls.Add(this.cbDistrict, 1, 0);
            this.tlpDisplay02.Controls.Add(this.lblPanelFunctional, 3, 1);
            this.tlpDisplay02.Controls.Add(this.pnlPanelFunctional, 4, 1);
            this.tlpDisplay02.Controls.Add(this.pnlPanelEstablished, 1, 1);
            this.tlpDisplay02.Controls.Add(this.lblId, 3, 0);
            this.tlpDisplay02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpDisplay02.Location = new System.Drawing.Point(23, 24);
            this.tlpDisplay02.Name = "tlpDisplay02";
            this.tlpDisplay02.RowCount = 2;
            this.tlpDisplay02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay02.Size = new System.Drawing.Size(654, 60);
            this.tlpDisplay02.TabIndex = 4;
            // 
            // lblPanelEstablished
            // 
            this.lblPanelEstablished.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPanelEstablished.AutoSize = true;
            this.lblPanelEstablished.Location = new System.Drawing.Point(3, 32);
            this.lblPanelEstablished.Name = "lblPanelEstablished";
            this.lblPanelEstablished.Size = new System.Drawing.Size(113, 26);
            this.lblPanelEstablished.TabIndex = 55;
            this.lblPanelEstablished.Text = "Alternative care panel established?";
            // 
            // lblDistrictVal
            // 
            this.lblDistrictVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistrictVal.AutoSize = true;
            this.lblDistrictVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistrictVal.ForeColor = System.Drawing.Color.Red;
            this.lblDistrictVal.Location = new System.Drawing.Point(310, 8);
            this.lblDistrictVal.Name = "lblDistrictVal";
            this.lblDistrictVal.Size = new System.Drawing.Size(11, 13);
            this.lblDistrictVal.TabIndex = 53;
            this.lblDistrictVal.Text = "*";
            // 
            // lblDistrict
            // 
            this.lblDistrict.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Location = new System.Drawing.Point(3, 8);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(42, 13);
            this.lblDistrict.TabIndex = 10;
            this.lblDistrict.Text = "District:";
            // 
            // cbDistrict
            // 
            this.cbDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDistrict.FormattingEnabled = true;
            this.cbDistrict.Location = new System.Drawing.Point(153, 3);
            this.cbDistrict.Name = "cbDistrict";
            this.cbDistrict.Size = new System.Drawing.Size(151, 21);
            this.cbDistrict.TabIndex = 14;
            // 
            // lblPanelFunctional
            // 
            this.lblPanelFunctional.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPanelFunctional.AutoSize = true;
            this.lblPanelFunctional.Location = new System.Drawing.Point(330, 32);
            this.lblPanelFunctional.Name = "lblPanelFunctional";
            this.lblPanelFunctional.Size = new System.Drawing.Size(144, 26);
            this.lblPanelFunctional.TabIndex = 54;
            this.lblPanelFunctional.Text = "Is the  alternative care panel functional?";
            // 
            // pnlPanelFunctional
            // 
            this.pnlPanelFunctional.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlPanelFunctional.Controls.Add(this.rbtnPanelFunctionalNo);
            this.pnlPanelFunctional.Controls.Add(this.rbtnPanelFunctionalYes);
            this.pnlPanelFunctional.Location = new System.Drawing.Point(480, 35);
            this.pnlPanelFunctional.Name = "pnlPanelFunctional";
            this.pnlPanelFunctional.Size = new System.Drawing.Size(151, 19);
            this.pnlPanelFunctional.TabIndex = 57;
            // 
            // rbtnPanelFunctionalNo
            // 
            this.rbtnPanelFunctionalNo.AutoSize = true;
            this.rbtnPanelFunctionalNo.Enabled = false;
            this.rbtnPanelFunctionalNo.Location = new System.Drawing.Point(52, 1);
            this.rbtnPanelFunctionalNo.Name = "rbtnPanelFunctionalNo";
            this.rbtnPanelFunctionalNo.Size = new System.Drawing.Size(39, 17);
            this.rbtnPanelFunctionalNo.TabIndex = 2;
            this.rbtnPanelFunctionalNo.TabStop = true;
            this.rbtnPanelFunctionalNo.Text = "No";
            this.rbtnPanelFunctionalNo.UseVisualStyleBackColor = true;
            // 
            // rbtnPanelFunctionalYes
            // 
            this.rbtnPanelFunctionalYes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnPanelFunctionalYes.AutoSize = true;
            this.rbtnPanelFunctionalYes.Enabled = false;
            this.rbtnPanelFunctionalYes.Location = new System.Drawing.Point(3, 1);
            this.rbtnPanelFunctionalYes.Name = "rbtnPanelFunctionalYes";
            this.rbtnPanelFunctionalYes.Size = new System.Drawing.Size(43, 17);
            this.rbtnPanelFunctionalYes.TabIndex = 0;
            this.rbtnPanelFunctionalYes.TabStop = true;
            this.rbtnPanelFunctionalYes.Text = "Yes";
            this.rbtnPanelFunctionalYes.UseVisualStyleBackColor = true;
            this.rbtnPanelFunctionalYes.CheckedChanged += new System.EventHandler(this.rbtnPanelFunctionalYes_CheckedChanged);
            // 
            // pnlPanelEstablished
            // 
            this.pnlPanelEstablished.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlPanelEstablished.Controls.Add(this.rbtnPanelEstablishedNo);
            this.pnlPanelEstablished.Controls.Add(this.rbtnPanelEstablishedYes);
            this.pnlPanelEstablished.Location = new System.Drawing.Point(153, 35);
            this.pnlPanelEstablished.Name = "pnlPanelEstablished";
            this.pnlPanelEstablished.Size = new System.Drawing.Size(151, 19);
            this.pnlPanelEstablished.TabIndex = 56;
            // 
            // rbtnPanelEstablishedNo
            // 
            this.rbtnPanelEstablishedNo.AutoSize = true;
            this.rbtnPanelEstablishedNo.Location = new System.Drawing.Point(52, 1);
            this.rbtnPanelEstablishedNo.Name = "rbtnPanelEstablishedNo";
            this.rbtnPanelEstablishedNo.Size = new System.Drawing.Size(39, 17);
            this.rbtnPanelEstablishedNo.TabIndex = 2;
            this.rbtnPanelEstablishedNo.TabStop = true;
            this.rbtnPanelEstablishedNo.Text = "No";
            this.rbtnPanelEstablishedNo.UseVisualStyleBackColor = true;
            // 
            // rbtnPanelEstablishedYes
            // 
            this.rbtnPanelEstablishedYes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnPanelEstablishedYes.AutoSize = true;
            this.rbtnPanelEstablishedYes.Location = new System.Drawing.Point(3, 1);
            this.rbtnPanelEstablishedYes.Name = "rbtnPanelEstablishedYes";
            this.rbtnPanelEstablishedYes.Size = new System.Drawing.Size(43, 17);
            this.rbtnPanelEstablishedYes.TabIndex = 0;
            this.rbtnPanelEstablishedYes.TabStop = true;
            this.rbtnPanelEstablishedYes.Text = "Yes";
            this.rbtnPanelEstablishedYes.UseVisualStyleBackColor = true;
            this.rbtnPanelEstablishedYes.CheckedChanged += new System.EventHandler(this.rbtnPanelEstablishedYes_CheckedChanged);
            // 
            // lblId
            // 
            this.lblId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(330, 8);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(10, 13);
            this.lblId.TabIndex = 58;
            this.lblId.Text = "-";
            this.lblId.Visible = false;
            // 
            // tplButton01
            // 
            this.tplButton01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplButton01.ColumnCount = 3;
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.Controls.Add(this.btnCancel, 2, 0);
            this.tplButton01.Controls.Add(this.btnSave, 0, 0);
            this.tplButton01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tplButton01.Location = new System.Drawing.Point(30, 89);
            this.tplButton01.Name = "tplButton01";
            this.tplButton01.RowCount = 1;
            this.tplButton01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplButton01.Size = new System.Drawing.Size(654, 40);
            this.tplButton01.TabIndex = 52;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Location = new System.Drawing.Point(350, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Location = new System.Drawing.Point(229, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.tlpDisplay01.Controls.Add(this.lblDateVal, 2, 0);
            this.tlpDisplay01.Controls.Add(this.dtpDate, 1, 0);
            this.tlpDisplay01.Controls.Add(this.lblPartner, 0, 1);
            this.tlpDisplay01.Controls.Add(this.lblDate, 0, 0);
            this.tlpDisplay01.Controls.Add(this.cbPartner, 1, 1);
            this.tlpDisplay01.Controls.Add(this.lblPartnerVal, 2, 1);
            this.tlpDisplay01.Controls.Add(this.lblFinancialYear, 3, 0);
            this.tlpDisplay01.Controls.Add(this.cbFinancialYear, 4, 0);
            this.tlpDisplay01.Controls.Add(this.label1, 5, 0);
            this.tlpDisplay01.Controls.Add(this.cbRegion, 4, 1);
            this.tlpDisplay01.Controls.Add(this.lblRegion, 3, 1);
            this.tlpDisplay01.Controls.Add(this.lblRegionVal, 5, 1);
            this.tlpDisplay01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpDisplay01.Location = new System.Drawing.Point(30, 30);
            this.tlpDisplay01.Name = "tlpDisplay01";
            this.tlpDisplay01.RowCount = 2;
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay01.Size = new System.Drawing.Size(654, 60);
            this.tlpDisplay01.TabIndex = 3;
            // 
            // lblDateVal
            // 
            this.lblDateVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDateVal.AutoSize = true;
            this.lblDateVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateVal.ForeColor = System.Drawing.Color.Red;
            this.lblDateVal.Location = new System.Drawing.Point(310, 8);
            this.lblDateVal.Name = "lblDateVal";
            this.lblDateVal.Size = new System.Drawing.Size(11, 13);
            this.lblDateVal.TabIndex = 53;
            this.lblDateVal.Text = "*";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(153, 3);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(124, 20);
            this.dtpDate.TabIndex = 53;
            // 
            // lblPartner
            // 
            this.lblPartner.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPartner.AutoSize = true;
            this.lblPartner.Location = new System.Drawing.Point(3, 38);
            this.lblPartner.Name = "lblPartner";
            this.lblPartner.Size = new System.Drawing.Size(44, 13);
            this.lblPartner.TabIndex = 12;
            this.lblPartner.Text = "Partner:";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(3, 8);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 10;
            this.lblDate.Text = "Date:";
            // 
            // cbPartner
            // 
            this.cbPartner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPartner.FormattingEnabled = true;
            this.cbPartner.Location = new System.Drawing.Point(153, 33);
            this.cbPartner.Name = "cbPartner";
            this.cbPartner.Size = new System.Drawing.Size(151, 21);
            this.cbPartner.TabIndex = 14;
            // 
            // lblPartnerVal
            // 
            this.lblPartnerVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPartnerVal.AutoSize = true;
            this.lblPartnerVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartnerVal.ForeColor = System.Drawing.Color.Red;
            this.lblPartnerVal.Location = new System.Drawing.Point(310, 38);
            this.lblPartnerVal.Name = "lblPartnerVal";
            this.lblPartnerVal.Size = new System.Drawing.Size(11, 13);
            this.lblPartnerVal.TabIndex = 23;
            this.lblPartnerVal.Text = "*";
            // 
            // lblFinancialYear
            // 
            this.lblFinancialYear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFinancialYear.AutoSize = true;
            this.lblFinancialYear.Location = new System.Drawing.Point(330, 8);
            this.lblFinancialYear.Name = "lblFinancialYear";
            this.lblFinancialYear.Size = new System.Drawing.Size(23, 13);
            this.lblFinancialYear.TabIndex = 11;
            this.lblFinancialYear.Text = "FY:";
            // 
            // cbFinancialYear
            // 
            this.cbFinancialYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFinancialYear.FormattingEnabled = true;
            this.cbFinancialYear.Location = new System.Drawing.Point(480, 3);
            this.cbFinancialYear.Name = "cbFinancialYear";
            this.cbFinancialYear.Size = new System.Drawing.Size(151, 21);
            this.cbFinancialYear.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(637, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "*";
            // 
            // cbRegion
            // 
            this.cbRegion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRegion.FormattingEnabled = true;
            this.cbRegion.Location = new System.Drawing.Point(480, 33);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(151, 21);
            this.cbRegion.TabIndex = 54;
            this.cbRegion.SelectionChangeCommitted += new System.EventHandler(this.cbRegion_SelectionChangeCommitted);
            // 
            // lblRegion
            // 
            this.lblRegion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(330, 38);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(44, 13);
            this.lblRegion.TabIndex = 55;
            this.lblRegion.Text = "Region:";
            // 
            // lblRegionVal
            // 
            this.lblRegionVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRegionVal.AutoSize = true;
            this.lblRegionVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegionVal.ForeColor = System.Drawing.Color.Red;
            this.lblRegionVal.Location = new System.Drawing.Point(637, 38);
            this.lblRegionVal.Name = "lblRegionVal";
            this.lblRegionVal.Size = new System.Drawing.Size(11, 13);
            this.lblRegionVal.TabIndex = 56;
            this.lblRegionVal.Text = "*";
            // 
            // gclID
            // 
            this.gclID.DataPropertyName = "acpd_id";
            this.gclID.HeaderText = "ID";
            this.gclID.Name = "gclID";
            this.gclID.Visible = false;
            // 
            // gclDistrict
            // 
            this.gclDistrict.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclDistrict.DataPropertyName = "dst_name";
            this.gclDistrict.HeaderText = "District";
            this.gclDistrict.Name = "gclDistrict";
            this.gclDistrict.ReadOnly = true;
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
            // frmAlternativeCarePanelSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbAlternativeCareTitle);
            this.Name = "frmAlternativeCarePanelSummary";
            this.Size = new System.Drawing.Size(720, 503);
            this.Load += new System.EventHandler(this.frmAlternativeCarePanelSummary_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmAlternativeCarePanelSummary_Paint);
            this.gbAlternativeCareTitle.ResumeLayout(false);
            this.gbAlternativeCareTitle.PerformLayout();
            this.gbDistrict.ResumeLayout(false);
            this.gbDistrict.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLine)).EndInit();
            this.tplButton02.ResumeLayout(false);
            this.tplButton02.PerformLayout();
            this.tlpDisplay03.ResumeLayout(false);
            this.tlpDisplay03.PerformLayout();
            this.tlpDisplay02.ResumeLayout(false);
            this.tlpDisplay02.PerformLayout();
            this.pnlPanelFunctional.ResumeLayout(false);
            this.pnlPanelFunctional.PerformLayout();
            this.pnlPanelEstablished.ResumeLayout(false);
            this.pnlPanelEstablished.PerformLayout();
            this.tplButton01.ResumeLayout(false);
            this.tlpDisplay01.ResumeLayout(false);
            this.tlpDisplay01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAlternativeCareTitle;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay01;
        private System.Windows.Forms.Label lblPartner;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblFinancialYear;
        private System.Windows.Forms.ComboBox cbFinancialYear;
        private System.Windows.Forms.ComboBox cbPartner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPartnerVal;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDateVal;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.GroupBox gbDistrict;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay02;
        private System.Windows.Forms.Label lblDistrictVal;
        private System.Windows.Forms.Label lblSupportExtended;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.ComboBox cbDistrict;
        private System.Windows.Forms.TableLayoutPanel tplButton02;
        private System.Windows.Forms.Button btnLineCancel;
        private System.Windows.Forms.Button btnLineSave;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay03;
        private System.Windows.Forms.DataGridView dgvLine;
        private System.Windows.Forms.Label lblTotalNumber;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnLineDelete;
        private System.Windows.Forms.Label lblPanelFunctional;
        private System.Windows.Forms.Label lblPanelEstablished;
        private System.Windows.Forms.Panel pnlPanelFunctional;
        private System.Windows.Forms.RadioButton rbtnPanelFunctionalNo;
        private System.Windows.Forms.RadioButton rbtnPanelFunctionalYes;
        private System.Windows.Forms.Panel pnlPanelEstablished;
        private System.Windows.Forms.RadioButton rbtnPanelEstablishedNo;
        private System.Windows.Forms.RadioButton rbtnPanelEstablishedYes;
        private System.Windows.Forms.TextBox txtSupportExtended;
        private System.Windows.Forms.LinkLabel llblBackTop;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.LinkLabel llblBackBottom;
        private System.Windows.Forms.ComboBox cbRegion;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Label lblRegionVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclDistrict;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gclDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclOfcId;
    }
}
