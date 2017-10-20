namespace SOCY_MIS
{
    partial class frmValueChainActorRegisterSearch
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
            this.gbValueChainSearch = new System.Windows.Forms.GroupBox();
            this.dgvRegister = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.llblNewRegister = new System.Windows.Forms.LinkLabel();
            this.tlpSearch01 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.cbPartner = new System.Windows.Forms.ComboBox();
            this.lblPartner = new System.Windows.Forms.Label();
            this.lblSubCounty = new System.Windows.Forms.Label();
            this.lblQuarter = new System.Windows.Forms.Label();
            this.lblCSO = new System.Windows.Forms.Label();
            this.cbQuarter = new System.Windows.Forms.ComboBox();
            this.cbCSO = new System.Windows.Forms.ComboBox();
            this.cbSubCounty = new System.Windows.Forms.ComboBox();
            this.cbDistrict = new System.Windows.Forms.ComboBox();
            this.cbFinancialYear = new System.Windows.Forms.ComboBox();
            this.lblFinancialYear = new System.Windows.Forms.Label();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclPartner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclCSO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclQuarter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclFinancialYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDistrict = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclSubCounty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gclOfcId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbValueChainSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).BeginInit();
            this.tplButton01.SuspendLayout();
            this.tlpSearch01.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbValueChainSearch
            // 
            this.gbValueChainSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbValueChainSearch.Controls.Add(this.dgvRegister);
            this.gbValueChainSearch.Controls.Add(this.btnDelete);
            this.gbValueChainSearch.Controls.Add(this.tplButton01);
            this.gbValueChainSearch.Controls.Add(this.llblNewRegister);
            this.gbValueChainSearch.Controls.Add(this.tlpSearch01);
            this.gbValueChainSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbValueChainSearch.Location = new System.Drawing.Point(3, 6);
            this.gbValueChainSearch.Name = "gbValueChainSearch";
            this.gbValueChainSearch.Size = new System.Drawing.Size(714, 497);
            this.gbValueChainSearch.TabIndex = 2;
            this.gbValueChainSearch.TabStop = false;
            this.gbValueChainSearch.Text = "Value Chain Actor Register Search";
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
            this.gclPartner,
            this.gclCSO,
            this.gclQuarter,
            this.gclFinancialYear,
            this.gclDistrict,
            this.gclSubCounty,
            this.gclDelete,
            this.gclOfcId});
            this.dgvRegister.Location = new System.Drawing.Point(6, 175);
            this.dgvRegister.MultiSelect = false;
            this.dgvRegister.Name = "dgvRegister";
            this.dgvRegister.Size = new System.Drawing.Size(702, 287);
            this.dgvRegister.TabIndex = 22;
            this.dgvRegister.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegister_CellDoubleClick);
            this.dgvRegister.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvRegister_RowPostPaint);
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
            this.tplButton01.Location = new System.Drawing.Point(30, 129);
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
            this.tlpSearch01.Controls.Add(this.lblDistrict, 0, 2);
            this.tlpSearch01.Controls.Add(this.cbPartner, 1, 0);
            this.tlpSearch01.Controls.Add(this.lblPartner, 0, 0);
            this.tlpSearch01.Controls.Add(this.lblSubCounty, 3, 2);
            this.tlpSearch01.Controls.Add(this.lblQuarter, 0, 1);
            this.tlpSearch01.Controls.Add(this.lblCSO, 3, 0);
            this.tlpSearch01.Controls.Add(this.cbQuarter, 1, 1);
            this.tlpSearch01.Controls.Add(this.cbCSO, 4, 0);
            this.tlpSearch01.Controls.Add(this.cbSubCounty, 4, 2);
            this.tlpSearch01.Controls.Add(this.cbDistrict, 1, 2);
            this.tlpSearch01.Controls.Add(this.cbFinancialYear, 4, 1);
            this.tlpSearch01.Controls.Add(this.lblFinancialYear, 3, 1);
            this.tlpSearch01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpSearch01.Location = new System.Drawing.Point(30, 40);
            this.tlpSearch01.Name = "tlpSearch01";
            this.tlpSearch01.RowCount = 3;
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSearch01.Size = new System.Drawing.Size(654, 90);
            this.tlpSearch01.TabIndex = 0;
            // 
            // lblDistrict
            // 
            this.lblDistrict.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Location = new System.Drawing.Point(3, 68);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(42, 13);
            this.lblDistrict.TabIndex = 16;
            this.lblDistrict.Text = "District:";
            // 
            // cbPartner
            // 
            this.cbPartner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPartner.FormattingEnabled = true;
            this.cbPartner.Location = new System.Drawing.Point(133, 4);
            this.cbPartner.Name = "cbPartner";
            this.cbPartner.Size = new System.Drawing.Size(171, 21);
            this.cbPartner.TabIndex = 11;
            this.cbPartner.SelectionChangeCommitted += new System.EventHandler(this.cbPartner_SelectionChangeCommitted);
            // 
            // lblPartner
            // 
            this.lblPartner.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPartner.AutoSize = true;
            this.lblPartner.Location = new System.Drawing.Point(3, 8);
            this.lblPartner.Name = "lblPartner";
            this.lblPartner.Size = new System.Drawing.Size(44, 13);
            this.lblPartner.TabIndex = 0;
            this.lblPartner.Text = "Partner:";
            // 
            // lblSubCounty
            // 
            this.lblSubCounty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubCounty.AutoSize = true;
            this.lblSubCounty.Location = new System.Drawing.Point(330, 68);
            this.lblSubCounty.Name = "lblSubCounty";
            this.lblSubCounty.Size = new System.Drawing.Size(65, 13);
            this.lblSubCounty.TabIndex = 15;
            this.lblSubCounty.Text = "Sub County:";
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
            // lblCSO
            // 
            this.lblCSO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCSO.AutoSize = true;
            this.lblCSO.Location = new System.Drawing.Point(330, 8);
            this.lblCSO.Name = "lblCSO";
            this.lblCSO.Size = new System.Drawing.Size(32, 13);
            this.lblCSO.TabIndex = 14;
            this.lblCSO.Text = "CSO:";
            // 
            // cbQuarter
            // 
            this.cbQuarter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbQuarter.FormattingEnabled = true;
            this.cbQuarter.Location = new System.Drawing.Point(133, 34);
            this.cbQuarter.Name = "cbQuarter";
            this.cbQuarter.Size = new System.Drawing.Size(171, 21);
            this.cbQuarter.TabIndex = 20;
            // 
            // cbCSO
            // 
            this.cbCSO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCSO.FormattingEnabled = true;
            this.cbCSO.Location = new System.Drawing.Point(460, 4);
            this.cbCSO.Name = "cbCSO";
            this.cbCSO.Size = new System.Drawing.Size(171, 21);
            this.cbCSO.TabIndex = 19;
            this.cbCSO.SelectionChangeCommitted += new System.EventHandler(this.cbCSO_SelectionChangeCommitted);
            // 
            // cbSubCounty
            // 
            this.cbSubCounty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSubCounty.FormattingEnabled = true;
            this.cbSubCounty.Location = new System.Drawing.Point(460, 64);
            this.cbSubCounty.Name = "cbSubCounty";
            this.cbSubCounty.Size = new System.Drawing.Size(171, 21);
            this.cbSubCounty.TabIndex = 17;
            this.cbSubCounty.SelectionChangeCommitted += new System.EventHandler(this.cbSubCounty_SelectionChangeCommitted);
            // 
            // cbDistrict
            // 
            this.cbDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDistrict.FormattingEnabled = true;
            this.cbDistrict.Location = new System.Drawing.Point(133, 64);
            this.cbDistrict.Name = "cbDistrict";
            this.cbDistrict.Size = new System.Drawing.Size(171, 21);
            this.cbDistrict.TabIndex = 18;
            this.cbDistrict.SelectionChangeCommitted += new System.EventHandler(this.cbDistrict_SelectionChangeCommitted);
            // 
            // cbFinancialYear
            // 
            this.cbFinancialYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFinancialYear.FormattingEnabled = true;
            this.cbFinancialYear.Location = new System.Drawing.Point(460, 34);
            this.cbFinancialYear.Name = "cbFinancialYear";
            this.cbFinancialYear.Size = new System.Drawing.Size(171, 21);
            this.cbFinancialYear.TabIndex = 21;
            // 
            // lblFinancialYear
            // 
            this.lblFinancialYear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFinancialYear.AutoSize = true;
            this.lblFinancialYear.Location = new System.Drawing.Point(330, 38);
            this.lblFinancialYear.Name = "lblFinancialYear";
            this.lblFinancialYear.Size = new System.Drawing.Size(77, 13);
            this.lblFinancialYear.TabIndex = 22;
            this.lblFinancialYear.Text = "Financial Year:";
            // 
            // gclID
            // 
            this.gclID.DataPropertyName = "vcr_id";
            this.gclID.HeaderText = "ID";
            this.gclID.Name = "gclID";
            this.gclID.ReadOnly = true;
            this.gclID.Visible = false;
            // 
            // gclPartner
            // 
            this.gclPartner.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclPartner.DataPropertyName = "prt_name";
            this.gclPartner.HeaderText = "Partner";
            this.gclPartner.Name = "gclPartner";
            this.gclPartner.ReadOnly = true;
            // 
            // gclCSO
            // 
            this.gclCSO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclCSO.DataPropertyName = "cso_name";
            this.gclCSO.HeaderText = "CSO";
            this.gclCSO.Name = "gclCSO";
            this.gclCSO.ReadOnly = true;
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
            this.gclFinancialYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclFinancialYear.DataPropertyName = "fy_name";
            this.gclFinancialYear.HeaderText = "Financial Year";
            this.gclFinancialYear.Name = "gclFinancialYear";
            this.gclFinancialYear.ReadOnly = true;
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
            // frmValueChainActorRegisterSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbValueChainSearch);
            this.Name = "frmValueChainActorRegisterSearch";
            this.Size = new System.Drawing.Size(720, 503);
            this.Load += new System.EventHandler(this.frmValueChainActorRegisterSearch_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmValueChainActorRegisterSearch_Paint);
            this.gbValueChainSearch.ResumeLayout(false);
            this.gbValueChainSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).EndInit();
            this.tplButton01.ResumeLayout(false);
            this.tlpSearch01.ResumeLayout(false);
            this.tlpSearch01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbValueChainSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel llblNewRegister;
        private System.Windows.Forms.TableLayoutPanel tlpSearch01;
        private System.Windows.Forms.Label lblQuarter;
        private System.Windows.Forms.ComboBox cbPartner;
        private System.Windows.Forms.Label lblPartner;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.Label lblSubCounty;
        private System.Windows.Forms.Label lblCSO;
        private System.Windows.Forms.ComboBox cbQuarter;
        private System.Windows.Forms.ComboBox cbCSO;
        private System.Windows.Forms.ComboBox cbSubCounty;
        private System.Windows.Forms.ComboBox cbDistrict;
        private System.Windows.Forms.DataGridView dgvRegister;
        private System.Windows.Forms.ComboBox cbFinancialYear;
        private System.Windows.Forms.Label lblFinancialYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclPartner;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclCSO;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclQuarter;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclFinancialYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclDistrict;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclSubCounty;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gclDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclOfcId;
    }
}
