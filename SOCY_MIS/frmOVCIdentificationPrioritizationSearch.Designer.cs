namespace SOCY_MIS
{
    partial class frmOVCIdentificationPrioritizationSearch
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
            this.gbSearchTitle = new System.Windows.Forms.GroupBox();
            this.dgvRegister = new System.Windows.Forms.DataGridView();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclHHCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDistrict = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclSubCounty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclWard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.llblNewRegister = new System.Windows.Forms.LinkLabel();
            this.tlpSearch01 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSubCounty = new System.Windows.Forms.Label();
            this.lblHHCode = new System.Windows.Forms.Label();
            this.lblWard = new System.Windows.Forms.Label();
            this.cbDistrict = new System.Windows.Forms.ComboBox();
            this.cbWard = new System.Windows.Forms.ComboBox();
            this.cbSubCounty = new System.Windows.Forms.ComboBox();
            this.lblDateBetween = new System.Windows.Forms.Label();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.lblDateAnd = new System.Windows.Forms.Label();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.cbHHCode = new System.Windows.Forms.ComboBox();
            this.gbSearchTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).BeginInit();
            this.tplButton01.SuspendLayout();
            this.tlpSearch01.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSearchTitle
            // 
            this.gbSearchTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSearchTitle.Controls.Add(this.dgvRegister);
            this.gbSearchTitle.Controls.Add(this.tplButton01);
            this.gbSearchTitle.Controls.Add(this.llblNewRegister);
            this.gbSearchTitle.Controls.Add(this.tlpSearch01);
            this.gbSearchTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSearchTitle.Location = new System.Drawing.Point(4, 7);
            this.gbSearchTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbSearchTitle.Name = "gbSearchTitle";
            this.gbSearchTitle.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbSearchTitle.Size = new System.Drawing.Size(952, 608);
            this.gbSearchTitle.TabIndex = 8;
            this.gbSearchTitle.TabStop = false;
            this.gbSearchTitle.Text = "OVC Identification and Prioritization Search";
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
            this.gclHHCode,
            this.gclDistrict,
            this.gclSubCounty,
            this.gclWard,
            this.gclDate});
            this.dgvRegister.Location = new System.Drawing.Point(8, 215);
            this.dgvRegister.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvRegister.MultiSelect = false;
            this.dgvRegister.Name = "dgvRegister";
            this.dgvRegister.Size = new System.Drawing.Size(936, 385);
            this.dgvRegister.TabIndex = 20;
            this.dgvRegister.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegister_CellDoubleClick);
            // 
            // gclID
            // 
            this.gclID.DataPropertyName = "oip_id";
            this.gclID.HeaderText = "ID";
            this.gclID.Name = "gclID";
            this.gclID.ReadOnly = true;
            this.gclID.Visible = false;
            // 
            // gclHHCode
            // 
            this.gclHHCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclHHCode.DataPropertyName = "hh_code";
            this.gclHHCode.HeaderText = "Household Code";
            this.gclHHCode.Name = "gclHHCode";
            this.gclHHCode.ReadOnly = true;
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
            this.gclWard.HeaderText = "Parish/Ward";
            this.gclWard.Name = "gclWard";
            this.gclWard.ReadOnly = true;
            // 
            // gclDate
            // 
            this.gclDate.DataPropertyName = "the_date_display";
            this.gclDate.HeaderText = "Date";
            this.gclDate.Name = "gclDate";
            this.gclDate.ReadOnly = true;
            // 
            // tplButton01
            // 
            this.tplButton01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplButton01.ColumnCount = 3;
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.Controls.Add(this.btnSearch, 0, 0);
            this.tplButton01.Controls.Add(this.btnCancel, 2, 0);
            this.tplButton01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tplButton01.Location = new System.Drawing.Point(40, 159);
            this.tplButton01.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tplButton01.Name = "tplButton01";
            this.tplButton01.RowCount = 1;
            this.tplButton01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplButton01.Size = new System.Drawing.Size(872, 49);
            this.tplButton01.TabIndex = 19;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(305, 10);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(466, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // llblNewRegister
            // 
            this.llblNewRegister.AutoSize = true;
            this.llblNewRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblNewRegister.Location = new System.Drawing.Point(21, 25);
            this.llblNewRegister.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblNewRegister.Name = "llblNewRegister";
            this.llblNewRegister.Size = new System.Drawing.Size(92, 17);
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
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpSearch01.Controls.Add(this.lblSubCounty, 0, 1);
            this.tlpSearch01.Controls.Add(this.lblHHCode, 0, 0);
            this.tlpSearch01.Controls.Add(this.lblWard, 3, 1);
            this.tlpSearch01.Controls.Add(this.cbDistrict, 4, 0);
            this.tlpSearch01.Controls.Add(this.cbWard, 4, 1);
            this.tlpSearch01.Controls.Add(this.cbSubCounty, 1, 1);
            this.tlpSearch01.Controls.Add(this.lblDateBetween, 0, 2);
            this.tlpSearch01.Controls.Add(this.dtpDateBegin, 1, 2);
            this.tlpSearch01.Controls.Add(this.lblDistrict, 3, 0);
            this.tlpSearch01.Controls.Add(this.lblDateAnd, 3, 2);
            this.tlpSearch01.Controls.Add(this.dtpDateEnd, 4, 2);
            this.tlpSearch01.Controls.Add(this.cbHHCode, 1, 0);
            this.tlpSearch01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpSearch01.Location = new System.Drawing.Point(40, 49);
            this.tlpSearch01.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpSearch01.Name = "tlpSearch01";
            this.tlpSearch01.RowCount = 3;
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSearch01.Size = new System.Drawing.Size(872, 111);
            this.tlpSearch01.TabIndex = 0;
            // 
            // lblSubCounty
            // 
            this.lblSubCounty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubCounty.AutoSize = true;
            this.lblSubCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCounty.Location = new System.Drawing.Point(4, 47);
            this.lblSubCounty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubCounty.Name = "lblSubCounty";
            this.lblSubCounty.Size = new System.Drawing.Size(85, 17);
            this.lblSubCounty.TabIndex = 12;
            this.lblSubCounty.Text = "Sub County:";
            // 
            // lblHHCode
            // 
            this.lblHHCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHHCode.AutoSize = true;
            this.lblHHCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHHCode.Location = new System.Drawing.Point(4, 10);
            this.lblHHCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHHCode.Name = "lblHHCode";
            this.lblHHCode.Size = new System.Drawing.Size(117, 17);
            this.lblHHCode.TabIndex = 2;
            this.lblHHCode.Text = "Household Code:";
            // 
            // lblWard
            // 
            this.lblWard.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblWard.AutoSize = true;
            this.lblWard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWard.Location = new System.Drawing.Point(440, 47);
            this.lblWard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(90, 17);
            this.lblWard.TabIndex = 13;
            this.lblWard.Text = "Parish/Ward:";
            // 
            // cbDistrict
            // 
            this.cbDistrict.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDistrict.FormattingEnabled = true;
            this.cbDistrict.Location = new System.Drawing.Point(613, 6);
            this.cbDistrict.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbDistrict.Name = "cbDistrict";
            this.cbDistrict.Size = new System.Drawing.Size(227, 25);
            this.cbDistrict.TabIndex = 16;
            this.cbDistrict.SelectionChangeCommitted += new System.EventHandler(this.cbDistrict_SelectionChangeCommitted);
            // 
            // cbWard
            // 
            this.cbWard.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbWard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWard.FormattingEnabled = true;
            this.cbWard.Location = new System.Drawing.Point(613, 43);
            this.cbWard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbWard.Name = "cbWard";
            this.cbWard.Size = new System.Drawing.Size(227, 25);
            this.cbWard.TabIndex = 14;
            this.cbWard.SelectionChangeCommitted += new System.EventHandler(this.cbWard_SelectionChangeCommitted);
            // 
            // cbSubCounty
            // 
            this.cbSubCounty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbSubCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubCounty.FormattingEnabled = true;
            this.cbSubCounty.Location = new System.Drawing.Point(177, 43);
            this.cbSubCounty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSubCounty.Name = "cbSubCounty";
            this.cbSubCounty.Size = new System.Drawing.Size(227, 25);
            this.cbSubCounty.TabIndex = 15;
            this.cbSubCounty.SelectionChangeCommitted += new System.EventHandler(this.cbSubCounty_SelectionChangeCommitted);
            // 
            // lblDateBetween
            // 
            this.lblDateBetween.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDateBetween.AutoSize = true;
            this.lblDateBetween.Location = new System.Drawing.Point(4, 84);
            this.lblDateBetween.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateBetween.Name = "lblDateBetween";
            this.lblDateBetween.Size = new System.Drawing.Size(100, 17);
            this.lblDateBetween.TabIndex = 12;
            this.lblDateBetween.Text = "Date Between:";
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateBegin.Location = new System.Drawing.Point(177, 81);
            this.dtpDateBegin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(152, 23);
            this.dtpDateBegin.TabIndex = 13;
            // 
            // lblDistrict
            // 
            this.lblDistrict.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistrict.Location = new System.Drawing.Point(440, 10);
            this.lblDistrict.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(55, 17);
            this.lblDistrict.TabIndex = 11;
            this.lblDistrict.Text = "District:";
            // 
            // lblDateAnd
            // 
            this.lblDateAnd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDateAnd.AutoSize = true;
            this.lblDateAnd.Location = new System.Drawing.Point(440, 84);
            this.lblDateAnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateAnd.Name = "lblDateAnd";
            this.lblDateAnd.Size = new System.Drawing.Size(32, 17);
            this.lblDateAnd.TabIndex = 16;
            this.lblDateAnd.Text = "and";
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateEnd.Location = new System.Drawing.Point(613, 81);
            this.dtpDateEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(152, 23);
            this.dtpDateEnd.TabIndex = 15;
            // 
            // cbHHCode
            // 
            this.cbHHCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbHHCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHHCode.FormattingEnabled = true;
            this.cbHHCode.Location = new System.Drawing.Point(177, 6);
            this.cbHHCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbHHCode.Name = "cbHHCode";
            this.cbHHCode.Size = new System.Drawing.Size(227, 25);
            this.cbHHCode.TabIndex = 10;
            // 
            // frmOVCIdentificationPrioritizationSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbSearchTitle);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmOVCIdentificationPrioritizationSearch";
            this.Size = new System.Drawing.Size(960, 619);
            this.Load += new System.EventHandler(this.frmOVCIdentificationPrioritizationSearch_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmOVCIdentificationPrioritizationSearch_Paint);
            this.gbSearchTitle.ResumeLayout(false);
            this.gbSearchTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).EndInit();
            this.tplButton01.ResumeLayout(false);
            this.tlpSearch01.ResumeLayout(false);
            this.tlpSearch01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearchTitle;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel llblNewRegister;
        private System.Windows.Forms.TableLayoutPanel tlpSearch01;
        private System.Windows.Forms.Label lblDateBetween;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.Label lblDateAnd;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.DataGridView dgvRegister;
        private System.Windows.Forms.Label lblSubCounty;
        private System.Windows.Forms.Label lblHHCode;
        private System.Windows.Forms.Label lblWard;
        private System.Windows.Forms.ComboBox cbDistrict;
        private System.Windows.Forms.ComboBox cbWard;
        private System.Windows.Forms.ComboBox cbSubCounty;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.ComboBox cbHHCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclHHCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclDistrict;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclSubCounty;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclWard;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclDate;
    }
}
