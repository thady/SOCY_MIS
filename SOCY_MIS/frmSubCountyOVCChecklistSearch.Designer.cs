namespace SOCY_MIS
{
    partial class frmSubCountyOVCChecklistSearch
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
            this.lblDateBetween = new System.Windows.Forms.Label();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.lblDateAnd = new System.Windows.Forms.Label();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.cbFinancialYear = new System.Windows.Forms.ComboBox();
            this.lblFinancialYear = new System.Windows.Forms.Label();
            this.lblQuarter = new System.Windows.Forms.Label();
            this.cbQuarter = new System.Windows.Forms.ComboBox();
            this.cbDistrict = new System.Windows.Forms.ComboBox();
            this.llblNewRegister = new System.Windows.Forms.LinkLabel();
            this.tlpSearch01 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvRegister = new System.Windows.Forms.DataGridView();
            this.gbSearchTitle = new System.Windows.Forms.GroupBox();
            this.tlpSearch01.SuspendLayout();
            this.tplButton01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).BeginInit();
            this.gbSearchTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDateBetween
            // 
            this.lblDateBetween.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDateBetween.AutoSize = true;
            this.lblDateBetween.Location = new System.Drawing.Point(3, 68);
            this.lblDateBetween.Name = "lblDateBetween";
            this.lblDateBetween.Size = new System.Drawing.Size(78, 13);
            this.lblDateBetween.TabIndex = 12;
            this.lblDateBetween.Text = "Date Between:";
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateBegin.Location = new System.Drawing.Point(133, 65);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(115, 20);
            this.dtpDateBegin.TabIndex = 13;
            // 
            // lblDateAnd
            // 
            this.lblDateAnd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDateAnd.AutoSize = true;
            this.lblDateAnd.Location = new System.Drawing.Point(330, 68);
            this.lblDateAnd.Name = "lblDateAnd";
            this.lblDateAnd.Size = new System.Drawing.Size(25, 13);
            this.lblDateAnd.TabIndex = 16;
            this.lblDateAnd.Text = "and";
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateEnd.Location = new System.Drawing.Point(460, 65);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(115, 20);
            this.dtpDateEnd.TabIndex = 15;
            // 
            // cbFinancialYear
            // 
            this.cbFinancialYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFinancialYear.FormattingEnabled = true;
            this.cbFinancialYear.Location = new System.Drawing.Point(460, 34);
            this.cbFinancialYear.Name = "cbFinancialYear";
            this.cbFinancialYear.Size = new System.Drawing.Size(171, 21);
            this.cbFinancialYear.TabIndex = 14;
            // 
            // lblFinancialYear
            // 
            this.lblFinancialYear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFinancialYear.AutoSize = true;
            this.lblFinancialYear.Location = new System.Drawing.Point(330, 38);
            this.lblFinancialYear.Name = "lblFinancialYear";
            this.lblFinancialYear.Size = new System.Drawing.Size(23, 13);
            this.lblFinancialYear.TabIndex = 19;
            this.lblFinancialYear.Text = "FY:";
            // 
            // lblQuarter
            // 
            this.lblQuarter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblQuarter.AutoSize = true;
            this.lblQuarter.Location = new System.Drawing.Point(3, 38);
            this.lblQuarter.Name = "lblQuarter";
            this.lblQuarter.Size = new System.Drawing.Size(45, 13);
            this.lblQuarter.TabIndex = 17;
            this.lblQuarter.Text = "Quarter:";
            // 
            // cbQuarter
            // 
            this.cbQuarter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbQuarter.FormattingEnabled = true;
            this.cbQuarter.Location = new System.Drawing.Point(133, 34);
            this.cbQuarter.Name = "cbQuarter";
            this.cbQuarter.Size = new System.Drawing.Size(171, 21);
            this.cbQuarter.TabIndex = 18;
            // 
            // cbDistrict
            // 
            this.cbDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDistrict.FormattingEnabled = true;
            this.cbDistrict.Location = new System.Drawing.Point(133, 4);
            this.cbDistrict.Name = "cbDistrict";
            this.cbDistrict.Size = new System.Drawing.Size(171, 21);
            this.cbDistrict.TabIndex = 20;
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
            this.tlpSearch01.Controls.Add(this.lblDateBetween, 0, 2);
            this.tlpSearch01.Controls.Add(this.dtpDateBegin, 1, 2);
            this.tlpSearch01.Controls.Add(this.lblDateAnd, 3, 2);
            this.tlpSearch01.Controls.Add(this.dtpDateEnd, 4, 2);
            this.tlpSearch01.Controls.Add(this.cbFinancialYear, 4, 1);
            this.tlpSearch01.Controls.Add(this.lblFinancialYear, 3, 1);
            this.tlpSearch01.Controls.Add(this.lblQuarter, 0, 1);
            this.tlpSearch01.Controls.Add(this.cbQuarter, 1, 1);
            this.tlpSearch01.Controls.Add(this.lblDistrict, 0, 0);
            this.tlpSearch01.Controls.Add(this.cbDistrict, 1, 0);
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
            this.lblDistrict.Location = new System.Drawing.Point(3, 8);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(42, 13);
            this.lblDistrict.TabIndex = 21;
            this.lblDistrict.Text = "District:";
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
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(633, 465);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
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
            // dgvRegister
            // 
            this.dgvRegister.AllowUserToAddRows = false;
            this.dgvRegister.AllowUserToDeleteRows = false;
            this.dgvRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegister.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegister.Location = new System.Drawing.Point(6, 175);
            this.dgvRegister.MultiSelect = false;
            this.dgvRegister.Name = "dgvRegister";
            this.dgvRegister.Size = new System.Drawing.Size(702, 284);
            this.dgvRegister.TabIndex = 24;
            this.dgvRegister.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegister_CellDoubleClick);
            // 
            // gbSearchTitle
            // 
            this.gbSearchTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSearchTitle.Controls.Add(this.dgvRegister);
            this.gbSearchTitle.Controls.Add(this.btnDelete);
            this.gbSearchTitle.Controls.Add(this.tplButton01);
            this.gbSearchTitle.Controls.Add(this.llblNewRegister);
            this.gbSearchTitle.Controls.Add(this.tlpSearch01);
            this.gbSearchTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSearchTitle.Location = new System.Drawing.Point(3, 4);
            this.gbSearchTitle.Name = "gbSearchTitle";
            this.gbSearchTitle.Size = new System.Drawing.Size(714, 494);
            this.gbSearchTitle.TabIndex = 7;
            this.gbSearchTitle.TabStop = false;
            this.gbSearchTitle.Text = "Sub County OVC coordination OVC and Data Usage checklist Search";
            // 
            // frmSubCountyOVCChecklistSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbSearchTitle);
            this.Name = "frmSubCountyOVCChecklistSearch";
            this.Size = new System.Drawing.Size(720, 503);
            this.Load += new System.EventHandler(this.frmSubCountyOVCChecklistSearch_Load);
            this.tlpSearch01.ResumeLayout(false);
            this.tlpSearch01.PerformLayout();
            this.tplButton01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).EndInit();
            this.gbSearchTitle.ResumeLayout(false);
            this.gbSearchTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDateBetween;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.Label lblDateAnd;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.ComboBox cbFinancialYear;
        private System.Windows.Forms.Label lblFinancialYear;
        private System.Windows.Forms.Label lblQuarter;
        private System.Windows.Forms.ComboBox cbQuarter;
        private System.Windows.Forms.ComboBox cbDistrict;
        private System.Windows.Forms.LinkLabel llblNewRegister;
        private System.Windows.Forms.TableLayoutPanel tlpSearch01;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.DataGridView dgvRegister;
        private System.Windows.Forms.GroupBox gbSearchTitle;
    }
}
