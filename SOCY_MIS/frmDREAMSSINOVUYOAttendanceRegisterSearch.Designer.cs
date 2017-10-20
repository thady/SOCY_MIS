namespace SOCY_MIS
{
    partial class frmDREAMSSINOVUYOAttendanceRegisterSearch
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
            this.gbSINOVUYORegisterSearch = new System.Windows.Forms.GroupBox();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpSearch01 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.cbFacilitator = new System.Windows.Forms.ComboBox();
            this.lblFacilitator = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.cbDistrict = new System.Windows.Forms.ComboBox();
            this.lblSubCounty = new System.Windows.Forms.Label();
            this.cbSubCounty = new System.Windows.Forms.ComboBox();
            this.lblWard = new System.Windows.Forms.Label();
            this.cbWard = new System.Windows.Forms.ComboBox();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dgvRegister = new System.Windows.Forms.DataGridView();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclFacilitator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDistrict = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclSubCounty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclWard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gclOfcId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.llblNewRegister = new System.Windows.Forms.LinkLabel();
            this.gbSINOVUYORegisterSearch.SuspendLayout();
            this.tplButton01.SuspendLayout();
            this.tlpSearch01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSINOVUYORegisterSearch
            // 
            this.gbSINOVUYORegisterSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSINOVUYORegisterSearch.Controls.Add(this.tplButton01);
            this.gbSINOVUYORegisterSearch.Controls.Add(this.tlpSearch01);
            this.gbSINOVUYORegisterSearch.Controls.Add(this.dgvRegister);
            this.gbSINOVUYORegisterSearch.Controls.Add(this.btnDelete);
            this.gbSINOVUYORegisterSearch.Controls.Add(this.llblNewRegister);
            this.gbSINOVUYORegisterSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSINOVUYORegisterSearch.Location = new System.Drawing.Point(3, 6);
            this.gbSINOVUYORegisterSearch.Name = "gbSINOVUYORegisterSearch";
            this.gbSINOVUYORegisterSearch.Size = new System.Drawing.Size(714, 494);
            this.gbSINOVUYORegisterSearch.TabIndex = 4;
            this.gbSINOVUYORegisterSearch.TabStop = false;
            this.gbSINOVUYORegisterSearch.Text = "SINOVUYO Attendance Register Search";
            // 
            // tplButton01
            // 
            this.tplButton01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplButton01.ColumnCount = 3;
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.Controls.Add(this.btnSearch, 0, 0);
            this.tplButton01.Controls.Add(this.btnCancel, 2, 0);
            this.tplButton01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tplButton01.Location = new System.Drawing.Point(30, 159);
            this.tplButton01.Name = "tplButton01";
            this.tplButton01.RowCount = 1;
            this.tplButton01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplButton01.Size = new System.Drawing.Size(654, 40);
            this.tplButton01.TabIndex = 25;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(229, 8);
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
            this.btnCancel.Location = new System.Drawing.Point(350, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tlpSearch01
            // 
            this.tlpSearch01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpSearch01.ColumnCount = 6;
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSearch01.Controls.Add(this.dtpDateFrom, 0, 3);
            this.tlpSearch01.Controls.Add(this.lblDateFrom, 0, 3);
            this.tlpSearch01.Controls.Add(this.cbFacilitator, 1, 0);
            this.tlpSearch01.Controls.Add(this.lblFacilitator, 0, 0);
            this.tlpSearch01.Controls.Add(this.lblGroup, 3, 0);
            this.tlpSearch01.Controls.Add(this.cbGroup, 4, 0);
            this.tlpSearch01.Controls.Add(this.lblDistrict, 0, 1);
            this.tlpSearch01.Controls.Add(this.cbDistrict, 1, 1);
            this.tlpSearch01.Controls.Add(this.lblSubCounty, 0, 2);
            this.tlpSearch01.Controls.Add(this.cbSubCounty, 1, 2);
            this.tlpSearch01.Controls.Add(this.lblWard, 3, 2);
            this.tlpSearch01.Controls.Add(this.cbWard, 4, 2);
            this.tlpSearch01.Controls.Add(this.lblDateTo, 3, 3);
            this.tlpSearch01.Controls.Add(this.dtpDateTo, 4, 3);
            this.tlpSearch01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpSearch01.Location = new System.Drawing.Point(30, 40);
            this.tlpSearch01.Name = "tlpSearch01";
            this.tlpSearch01.RowCount = 4;
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
            this.tlpSearch01.Size = new System.Drawing.Size(654, 120);
            this.tlpSearch01.TabIndex = 24;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(133, 95);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(115, 20);
            this.dtpDateFrom.TabIndex = 6;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(3, 98);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(59, 13);
            this.lblDateFrom.TabIndex = 24;
            this.lblDateFrom.Text = "Date From:";
            // 
            // cbFacilitator
            // 
            this.cbFacilitator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFacilitator.FormattingEnabled = true;
            this.cbFacilitator.Location = new System.Drawing.Point(133, 4);
            this.cbFacilitator.Name = "cbFacilitator";
            this.cbFacilitator.Size = new System.Drawing.Size(171, 21);
            this.cbFacilitator.TabIndex = 1;
            // 
            // lblFacilitator
            // 
            this.lblFacilitator.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFacilitator.AutoSize = true;
            this.lblFacilitator.Location = new System.Drawing.Point(3, 8);
            this.lblFacilitator.Name = "lblFacilitator";
            this.lblFacilitator.Size = new System.Drawing.Size(55, 13);
            this.lblFacilitator.TabIndex = 0;
            this.lblFacilitator.Text = "Facilitator:";
            // 
            // lblGroup
            // 
            this.lblGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(330, 8);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(39, 13);
            this.lblGroup.TabIndex = 14;
            this.lblGroup.Text = "Group:";
            // 
            // cbGroup
            // 
            this.cbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(460, 4);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(171, 21);
            this.cbGroup.TabIndex = 2;
            // 
            // lblDistrict
            // 
            this.lblDistrict.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Location = new System.Drawing.Point(3, 38);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(42, 13);
            this.lblDistrict.TabIndex = 16;
            this.lblDistrict.Text = "District:";
            // 
            // cbDistrict
            // 
            this.cbDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDistrict.FormattingEnabled = true;
            this.cbDistrict.Location = new System.Drawing.Point(133, 34);
            this.cbDistrict.Name = "cbDistrict";
            this.cbDistrict.Size = new System.Drawing.Size(171, 21);
            this.cbDistrict.TabIndex = 3;
            // 
            // lblSubCounty
            // 
            this.lblSubCounty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubCounty.AutoSize = true;
            this.lblSubCounty.Location = new System.Drawing.Point(3, 68);
            this.lblSubCounty.Name = "lblSubCounty";
            this.lblSubCounty.Size = new System.Drawing.Size(65, 13);
            this.lblSubCounty.TabIndex = 15;
            this.lblSubCounty.Text = "Sub County:";
            // 
            // cbSubCounty
            // 
            this.cbSubCounty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSubCounty.FormattingEnabled = true;
            this.cbSubCounty.Location = new System.Drawing.Point(133, 64);
            this.cbSubCounty.Name = "cbSubCounty";
            this.cbSubCounty.Size = new System.Drawing.Size(171, 21);
            this.cbSubCounty.TabIndex = 4;
            // 
            // lblWard
            // 
            this.lblWard.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblWard.AutoSize = true;
            this.lblWard.Location = new System.Drawing.Point(330, 68);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(39, 13);
            this.lblWard.TabIndex = 21;
            this.lblWard.Text = "Parish:";
            // 
            // cbWard
            // 
            this.cbWard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbWard.FormattingEnabled = true;
            this.cbWard.Location = new System.Drawing.Point(460, 64);
            this.cbWard.Name = "cbWard";
            this.cbWard.Size = new System.Drawing.Size(171, 21);
            this.cbWard.TabIndex = 5;
            this.cbWard.SelectionChangeCommitted += new System.EventHandler(this.cbWard_SelectionChangeCommitted);
            // 
            // lblDateTo
            // 
            this.lblDateTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(330, 98);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(65, 13);
            this.lblDateTo.TabIndex = 23;
            this.lblDateTo.Text = "Sub County:";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(460, 95);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(115, 20);
            this.dtpDateTo.TabIndex = 7;
            // 
            // dgvRegister
            // 
            this.dgvRegister.AllowUserToAddRows = false;
            this.dgvRegister.AllowUserToDeleteRows = false;
            this.dgvRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegister.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gclID,
            this.gclFacilitator,
            this.gclGroup,
            this.gclDistrict,
            this.gclSubCounty,
            this.gclWard,
            this.gclDelete,
            this.gclOfcId});
            this.dgvRegister.Location = new System.Drawing.Point(6, 205);
            this.dgvRegister.MultiSelect = false;
            this.dgvRegister.Name = "dgvRegister";
            this.dgvRegister.Size = new System.Drawing.Size(702, 254);
            this.dgvRegister.TabIndex = 23;
            this.dgvRegister.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegister_CellDoubleClick);
            this.dgvRegister.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvRegister_RowPostPaint);
            // 
            // gclID
            // 
            this.gclID.DataPropertyName = "dsr_id";
            this.gclID.HeaderText = "ID";
            this.gclID.Name = "gclID";
            this.gclID.ReadOnly = true;
            this.gclID.Visible = false;
            // 
            // gclFacilitator
            // 
            this.gclFacilitator.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclFacilitator.DataPropertyName = "dsr_facilitator";
            this.gclFacilitator.HeaderText = "Facilitator";
            this.gclFacilitator.Name = "gclFacilitator";
            this.gclFacilitator.ReadOnly = true;
            // 
            // gclGroup
            // 
            this.gclGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclGroup.DataPropertyName = "dsr_group";
            this.gclGroup.HeaderText = "Group";
            this.gclGroup.Name = "gclGroup";
            this.gclGroup.ReadOnly = true;
            // 
            // gclDistrict
            // 
            this.gclDistrict.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclDistrict.DataPropertyName = "dst_name";
            this.gclDistrict.HeaderText = "District";
            this.gclDistrict.Name = "gclDistrict";
            this.gclDistrict.ReadOnly = true;
            // 
            // gclSubCounty
            // 
            this.gclSubCounty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclSubCounty.DataPropertyName = "sct_name";
            this.gclSubCounty.HeaderText = "Sub County";
            this.gclSubCounty.Name = "gclSubCounty";
            this.gclSubCounty.ReadOnly = true;
            // 
            // gclWard
            // 
            this.gclWard.DataPropertyName = "wrd_name";
            this.gclWard.HeaderText = "Parish";
            this.gclWard.Name = "gclWard";
            this.gclWard.ReadOnly = true;
            this.gclWard.Width = 120;
            // 
            // gclDelete
            // 
            this.gclDelete.HeaderText = "Delete";
            this.gclDelete.Name = "gclDelete";
            this.gclDelete.Width = 80;
            // 
            // gclOfcId
            // 
            this.gclOfcId.DataPropertyName = "ofc_id";
            this.gclOfcId.HeaderText = "OfcId";
            this.gclOfcId.Name = "gclOfcId";
            this.gclOfcId.ReadOnly = true;
            this.gclOfcId.Visible = false;
            this.gclOfcId.Width = 80;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(633, 465);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // llblNewRegister
            // 
            this.llblNewRegister.AutoSize = true;
            this.llblNewRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblNewRegister.Location = new System.Drawing.Point(16, 20);
            this.llblNewRegister.Name = "llblNewRegister";
            this.llblNewRegister.Size = new System.Drawing.Size(71, 13);
            this.llblNewRegister.TabIndex = 11;
            this.llblNewRegister.TabStop = true;
            this.llblNewRegister.Text = "New Register";
            this.llblNewRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblNewRegister_LinkClicked);
            // 
            // frmDREAMSSINOVUYOAttendanceRegisterSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbSINOVUYORegisterSearch);
            this.Name = "frmDREAMSSINOVUYOAttendanceRegisterSearch";
            this.Size = new System.Drawing.Size(720, 503);
            this.Load += new System.EventHandler(this.frmDREAMSSINOVUYOAttendanceRegisterSearch_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmDREAMSSINOVUYOAttendanceRegisterSearch_Paint);
            this.gbSINOVUYORegisterSearch.ResumeLayout(false);
            this.gbSINOVUYORegisterSearch.PerformLayout();
            this.tplButton01.ResumeLayout(false);
            this.tlpSearch01.ResumeLayout(false);
            this.tlpSearch01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSINOVUYORegisterSearch;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlpSearch01;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.ComboBox cbFacilitator;
        private System.Windows.Forms.Label lblFacilitator;
        private System.Windows.Forms.Label lblSubCounty;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.ComboBox cbSubCounty;
        private System.Windows.Forms.ComboBox cbDistrict;
        private System.Windows.Forms.Label lblWard;
        private System.Windows.Forms.ComboBox cbWard;
        private System.Windows.Forms.DataGridView dgvRegister;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.LinkLabel llblNewRegister;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclFacilitator;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclDistrict;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclSubCounty;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclWard;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gclDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclOfcId;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
    }
}
