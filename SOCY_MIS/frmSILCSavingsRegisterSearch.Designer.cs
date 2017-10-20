namespace SOCY_MIS
{
    partial class frmSILCSavingsRegisterSearch
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
            this.gbSavingsRegisterSearch = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvRegister = new System.Windows.Forms.DataGridView();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.llblNewRegister = new System.Windows.Forms.LinkLabel();
            this.tlpSearch01 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSILCGroup = new System.Windows.Forms.Label();
            this.cbSILCGroup = new System.Windows.Forms.ComboBox();
            this.lblSubCounty = new System.Windows.Forms.Label();
            this.cbSubCounty = new System.Windows.Forms.ComboBox();
            this.lblWard = new System.Windows.Forms.Label();
            this.cbWard = new System.Windows.Forms.ComboBox();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.cbDistrict = new System.Windows.Forms.ComboBox();
            this.lblCSO = new System.Windows.Forms.Label();
            this.cbCSO = new System.Windows.Forms.ComboBox();
            this.lblQuarter = new System.Windows.Forms.Label();
            this.cbQuarter = new System.Windows.Forms.ComboBox();
            this.lblFinancialYear = new System.Windows.Forms.Label();
            this.cbFinancialYear = new System.Windows.Forms.ComboBox();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclSilcGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclQuarter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclFinancialYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclCSO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDistrict = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclSubCounty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclWard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gclOfcId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbSavingsRegisterSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).BeginInit();
            this.tplButton01.SuspendLayout();
            this.tlpSearch01.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSavingsRegisterSearch
            // 
            this.gbSavingsRegisterSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSavingsRegisterSearch.Controls.Add(this.btnDelete);
            this.gbSavingsRegisterSearch.Controls.Add(this.dgvRegister);
            this.gbSavingsRegisterSearch.Controls.Add(this.tplButton01);
            this.gbSavingsRegisterSearch.Controls.Add(this.llblNewRegister);
            this.gbSavingsRegisterSearch.Controls.Add(this.tlpSearch01);
            this.gbSavingsRegisterSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSavingsRegisterSearch.Location = new System.Drawing.Point(3, 6);
            this.gbSavingsRegisterSearch.Name = "gbSavingsRegisterSearch";
            this.gbSavingsRegisterSearch.Size = new System.Drawing.Size(714, 497);
            this.gbSavingsRegisterSearch.TabIndex = 2;
            this.gbSavingsRegisterSearch.TabStop = false;
            this.gbSavingsRegisterSearch.Text = "SILC Savings Register Search";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(633, 468);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.gclSilcGroup,
            this.gclQuarter,
            this.gclFinancialYear,
            this.gclCSO,
            this.gclDistrict,
            this.gclSubCounty,
            this.gclWard,
            this.gclDelete,
            this.gclOfcId});
            this.dgvRegister.Location = new System.Drawing.Point(6, 212);
            this.dgvRegister.MultiSelect = false;
            this.dgvRegister.Name = "dgvRegister";
            this.dgvRegister.Size = new System.Drawing.Size(702, 247);
            this.dgvRegister.TabIndex = 20;
            this.dgvRegister.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegister_CellDoubleClick);
            this.dgvRegister.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvRegister_RowPostPaint);
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
            this.tplButton01.TabIndex = 19;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(229, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
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
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // llblNewRegister
            // 
            this.llblNewRegister.AutoSize = true;
            this.llblNewRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblNewRegister.Location = new System.Drawing.Point(16, 20);
            this.llblNewRegister.Name = "llblNewRegister";
            this.llblNewRegister.Size = new System.Drawing.Size(71, 13);
            this.llblNewRegister.TabIndex = 18;
            this.llblNewRegister.TabStop = true;
            this.llblNewRegister.Text = "New Register";
            this.llblNewRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblNewRegister_LinkClicked);
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
            this.tlpSearch01.Controls.Add(this.lblSILCGroup, 0, 0);
            this.tlpSearch01.Controls.Add(this.cbSILCGroup, 1, 0);
            this.tlpSearch01.Controls.Add(this.lblSubCounty, 0, 3);
            this.tlpSearch01.Controls.Add(this.cbSubCounty, 1, 3);
            this.tlpSearch01.Controls.Add(this.lblWard, 3, 3);
            this.tlpSearch01.Controls.Add(this.cbWard, 4, 3);
            this.tlpSearch01.Controls.Add(this.lblDistrict, 0, 2);
            this.tlpSearch01.Controls.Add(this.cbDistrict, 1, 2);
            this.tlpSearch01.Controls.Add(this.lblCSO, 3, 0);
            this.tlpSearch01.Controls.Add(this.cbCSO, 4, 0);
            this.tlpSearch01.Controls.Add(this.lblQuarter, 0, 1);
            this.tlpSearch01.Controls.Add(this.cbQuarter, 1, 1);
            this.tlpSearch01.Controls.Add(this.lblFinancialYear, 3, 1);
            this.tlpSearch01.Controls.Add(this.cbFinancialYear, 4, 1);
            this.tlpSearch01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpSearch01.Location = new System.Drawing.Point(30, 40);
            this.tlpSearch01.Name = "tlpSearch01";
            this.tlpSearch01.RowCount = 4;
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSearch01.Size = new System.Drawing.Size(654, 120);
            this.tlpSearch01.TabIndex = 0;
            // 
            // lblSILCGroup
            // 
            this.lblSILCGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSILCGroup.AutoSize = true;
            this.lblSILCGroup.Location = new System.Drawing.Point(3, 8);
            this.lblSILCGroup.Name = "lblSILCGroup";
            this.lblSILCGroup.Size = new System.Drawing.Size(65, 13);
            this.lblSILCGroup.TabIndex = 18;
            this.lblSILCGroup.Text = "SILC Group:";
            // 
            // cbSILCGroup
            // 
            this.cbSILCGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSILCGroup.FormattingEnabled = true;
            this.cbSILCGroup.Location = new System.Drawing.Point(133, 4);
            this.cbSILCGroup.Name = "cbSILCGroup";
            this.cbSILCGroup.Size = new System.Drawing.Size(171, 21);
            this.cbSILCGroup.TabIndex = 21;
            // 
            // lblSubCounty
            // 
            this.lblSubCounty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubCounty.AutoSize = true;
            this.lblSubCounty.Location = new System.Drawing.Point(3, 98);
            this.lblSubCounty.Name = "lblSubCounty";
            this.lblSubCounty.Size = new System.Drawing.Size(64, 13);
            this.lblSubCounty.TabIndex = 15;
            this.lblSubCounty.Text = "Sub county:";
            // 
            // cbSubCounty
            // 
            this.cbSubCounty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSubCounty.FormattingEnabled = true;
            this.cbSubCounty.Location = new System.Drawing.Point(133, 94);
            this.cbSubCounty.Name = "cbSubCounty";
            this.cbSubCounty.Size = new System.Drawing.Size(171, 21);
            this.cbSubCounty.TabIndex = 17;
            this.cbSubCounty.SelectionChangeCommitted += new System.EventHandler(this.cbSubCounty_SelectionChangeCommitted);
            // 
            // lblWard
            // 
            this.lblWard.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblWard.AutoSize = true;
            this.lblWard.Location = new System.Drawing.Point(330, 98);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(39, 13);
            this.lblWard.TabIndex = 14;
            this.lblWard.Text = "Parish:";
            // 
            // cbWard
            // 
            this.cbWard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbWard.FormattingEnabled = true;
            this.cbWard.Location = new System.Drawing.Point(460, 94);
            this.cbWard.Name = "cbWard";
            this.cbWard.Size = new System.Drawing.Size(171, 21);
            this.cbWard.TabIndex = 16;
            this.cbWard.SelectionChangeCommitted += new System.EventHandler(this.cbWard_SelectionChangeCommitted);
            // 
            // lblDistrict
            // 
            this.lblDistrict.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Location = new System.Drawing.Point(3, 68);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(42, 13);
            this.lblDistrict.TabIndex = 0;
            this.lblDistrict.Text = "District:";
            // 
            // cbDistrict
            // 
            this.cbDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDistrict.FormattingEnabled = true;
            this.cbDistrict.Location = new System.Drawing.Point(133, 64);
            this.cbDistrict.Name = "cbDistrict";
            this.cbDistrict.Size = new System.Drawing.Size(171, 21);
            this.cbDistrict.TabIndex = 11;
            this.cbDistrict.SelectionChangeCommitted += new System.EventHandler(this.cbDistrict_SelectionChangeCommitted);
            // 
            // lblCSO
            // 
            this.lblCSO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCSO.AutoSize = true;
            this.lblCSO.Location = new System.Drawing.Point(330, 8);
            this.lblCSO.Name = "lblCSO";
            this.lblCSO.Size = new System.Drawing.Size(32, 13);
            this.lblCSO.TabIndex = 19;
            this.lblCSO.Text = "CSO:";
            // 
            // cbCSO
            // 
            this.cbCSO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCSO.FormattingEnabled = true;
            this.cbCSO.Location = new System.Drawing.Point(460, 4);
            this.cbCSO.Name = "cbCSO";
            this.cbCSO.Size = new System.Drawing.Size(171, 21);
            this.cbCSO.TabIndex = 20;
            // 
            // lblQuarter
            // 
            this.lblQuarter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblQuarter.AutoSize = true;
            this.lblQuarter.Location = new System.Drawing.Point(3, 38);
            this.lblQuarter.Name = "lblQuarter";
            this.lblQuarter.Size = new System.Drawing.Size(45, 13);
            this.lblQuarter.TabIndex = 12;
            this.lblQuarter.Text = "Quarter:";
            // 
            // cbQuarter
            // 
            this.cbQuarter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbQuarter.FormattingEnabled = true;
            this.cbQuarter.Location = new System.Drawing.Point(133, 34);
            this.cbQuarter.Name = "cbQuarter";
            this.cbQuarter.Size = new System.Drawing.Size(171, 21);
            this.cbQuarter.TabIndex = 22;
            // 
            // lblFinancialYear
            // 
            this.lblFinancialYear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFinancialYear.AutoSize = true;
            this.lblFinancialYear.Location = new System.Drawing.Point(330, 38);
            this.lblFinancialYear.Name = "lblFinancialYear";
            this.lblFinancialYear.Size = new System.Drawing.Size(77, 13);
            this.lblFinancialYear.TabIndex = 23;
            this.lblFinancialYear.Text = "Financial Year:";
            // 
            // cbFinancialYear
            // 
            this.cbFinancialYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFinancialYear.FormattingEnabled = true;
            this.cbFinancialYear.Location = new System.Drawing.Point(460, 34);
            this.cbFinancialYear.Name = "cbFinancialYear";
            this.cbFinancialYear.Size = new System.Drawing.Size(171, 21);
            this.cbFinancialYear.TabIndex = 24;
            // 
            // gclID
            // 
            this.gclID.DataPropertyName = "ssr_id";
            this.gclID.HeaderText = "ID";
            this.gclID.Name = "gclID";
            this.gclID.ReadOnly = true;
            this.gclID.Visible = false;
            // 
            // gclSilcGroup
            // 
            this.gclSilcGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclSilcGroup.DataPropertyName = "sg_name";
            this.gclSilcGroup.HeaderText = "SILC Group";
            this.gclSilcGroup.Name = "gclSilcGroup";
            this.gclSilcGroup.ReadOnly = true;
            // 
            // gclQuarter
            // 
            this.gclQuarter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclQuarter.DataPropertyName = "qy_name";
            this.gclQuarter.HeaderText = "Quarter";
            this.gclQuarter.Name = "gclQuarter";
            this.gclQuarter.ReadOnly = true;
            // 
            // gclFinancialYear
            // 
            this.gclFinancialYear.DataPropertyName = "fy_name";
            this.gclFinancialYear.HeaderText = "Financial Year";
            this.gclFinancialYear.Name = "gclFinancialYear";
            this.gclFinancialYear.ReadOnly = true;
            // 
            // gclCSO
            // 
            this.gclCSO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclCSO.DataPropertyName = "cso_name";
            this.gclCSO.HeaderText = "CSO";
            this.gclCSO.Name = "gclCSO";
            this.gclCSO.ReadOnly = true;
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
            this.gclWard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclWard.DataPropertyName = "wrd_name";
            this.gclWard.HeaderText = "Parish";
            this.gclWard.Name = "gclWard";
            this.gclWard.ReadOnly = true;
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
            // frmSILCSavingsRegisterSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbSavingsRegisterSearch);
            this.Name = "frmSILCSavingsRegisterSearch";
            this.Size = new System.Drawing.Size(720, 503);
            this.Load += new System.EventHandler(this.frmSILCSavingsRegisterSearch_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSILCSavingsRegisterSearch_Paint);
            this.gbSavingsRegisterSearch.ResumeLayout(false);
            this.gbSavingsRegisterSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).EndInit();
            this.tplButton01.ResumeLayout(false);
            this.tlpSearch01.ResumeLayout(false);
            this.tlpSearch01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSavingsRegisterSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvRegister;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel llblNewRegister;
        private System.Windows.Forms.TableLayoutPanel tlpSearch01;
        private System.Windows.Forms.Label lblQuarter;
        private System.Windows.Forms.ComboBox cbDistrict;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.ComboBox cbSubCounty;
        private System.Windows.Forms.Label lblSubCounty;
        private System.Windows.Forms.Label lblWard;
        private System.Windows.Forms.ComboBox cbWard;
        private System.Windows.Forms.Label lblSILCGroup;
        private System.Windows.Forms.Label lblCSO;
        private System.Windows.Forms.ComboBox cbCSO;
        private System.Windows.Forms.ComboBox cbSILCGroup;
        private System.Windows.Forms.ComboBox cbQuarter;
        private System.Windows.Forms.Label lblFinancialYear;
        private System.Windows.Forms.ComboBox cbFinancialYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclSilcGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclQuarter;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclFinancialYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclCSO;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclDistrict;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclSubCounty;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclWard;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gclDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclOfcId;
    }
}
