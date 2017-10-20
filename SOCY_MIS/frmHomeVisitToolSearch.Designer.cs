namespace SOCY_MIS
{
    partial class frmHomeVisitToolSearch
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
            this.gbHomeVisitSearch = new System.Windows.Forms.GroupBox();
            this.dgvRegister = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.llblNewRegister = new System.Windows.Forms.LinkLabel();
            this.tlpSearch01 = new System.Windows.Forms.TableLayoutPanel();
            this.cbHHCode = new System.Windows.Forms.ComboBox();
            this.lblHHCode = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateAnd = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclHHCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gclOfcId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbHomeVisitSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).BeginInit();
            this.tplButton01.SuspendLayout();
            this.tlpSearch01.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbHomeVisitSearch
            // 
            this.gbHomeVisitSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbHomeVisitSearch.Controls.Add(this.dgvRegister);
            this.gbHomeVisitSearch.Controls.Add(this.btnDelete);
            this.gbHomeVisitSearch.Controls.Add(this.tplButton01);
            this.gbHomeVisitSearch.Controls.Add(this.llblNewRegister);
            this.gbHomeVisitSearch.Controls.Add(this.tlpSearch01);
            this.gbHomeVisitSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHomeVisitSearch.Location = new System.Drawing.Point(3, 6);
            this.gbHomeVisitSearch.Name = "gbHomeVisitSearch";
            this.gbHomeVisitSearch.Size = new System.Drawing.Size(714, 497);
            this.gbHomeVisitSearch.TabIndex = 2;
            this.gbHomeVisitSearch.TabStop = false;
            this.gbHomeVisitSearch.Text = "Home Visit Search";
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
            this.gclDate,
            this.gclDelete,
            this.gclOfcId});
            this.dgvRegister.Location = new System.Drawing.Point(6, 148);
            this.dgvRegister.MultiSelect = false;
            this.dgvRegister.Name = "dgvRegister";
            this.dgvRegister.Size = new System.Drawing.Size(702, 314);
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
            this.tplButton01.Location = new System.Drawing.Point(30, 99);
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
            this.llblNewRegister.Size = new System.Drawing.Size(82, 13);
            this.llblNewRegister.TabIndex = 18;
            this.llblNewRegister.TabStop = true;
            this.llblNewRegister.Text = "New Home Visit";
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
            this.tlpSearch01.Controls.Add(this.cbHHCode, 1, 0);
            this.tlpSearch01.Controls.Add(this.lblHHCode, 0, 0);
            this.tlpSearch01.Controls.Add(this.lblDateFrom, 0, 1);
            this.tlpSearch01.Controls.Add(this.dtpDateFrom, 1, 1);
            this.tlpSearch01.Controls.Add(this.lblDateAnd, 3, 1);
            this.tlpSearch01.Controls.Add(this.dtpDateTo, 4, 1);
            this.tlpSearch01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpSearch01.Location = new System.Drawing.Point(30, 40);
            this.tlpSearch01.Name = "tlpSearch01";
            this.tlpSearch01.RowCount = 2;
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearch01.Size = new System.Drawing.Size(654, 60);
            this.tlpSearch01.TabIndex = 0;
            // 
            // cbHHCode
            // 
            this.cbHHCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHHCode.FormattingEnabled = true;
            this.cbHHCode.Location = new System.Drawing.Point(133, 4);
            this.cbHHCode.Name = "cbHHCode";
            this.cbHHCode.Size = new System.Drawing.Size(171, 21);
            this.cbHHCode.TabIndex = 11;
            // 
            // lblHHCode
            // 
            this.lblHHCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHHCode.AutoSize = true;
            this.lblHHCode.Location = new System.Drawing.Point(3, 8);
            this.lblHHCode.Name = "lblHHCode";
            this.lblHHCode.Size = new System.Drawing.Size(89, 13);
            this.lblHHCode.TabIndex = 0;
            this.lblHHCode.Text = "Household Code:";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(3, 38);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(99, 13);
            this.lblDateFrom.TabIndex = 12;
            this.lblDateFrom.Text = "Visit Date between:";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(133, 35);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(115, 20);
            this.dtpDateFrom.TabIndex = 13;
            // 
            // lblDateAnd
            // 
            this.lblDateAnd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDateAnd.AutoSize = true;
            this.lblDateAnd.Location = new System.Drawing.Point(330, 38);
            this.lblDateAnd.Name = "lblDateAnd";
            this.lblDateAnd.Size = new System.Drawing.Size(25, 13);
            this.lblDateAnd.TabIndex = 17;
            this.lblDateAnd.Text = "and";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(460, 35);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(115, 20);
            this.dtpDateTo.TabIndex = 18;
            // 
            // gclID
            // 
            this.gclID.DataPropertyName = "hv_id";
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
            // gclDate
            // 
            this.gclDate.DataPropertyName = "the_date_display";
            this.gclDate.HeaderText = "Visit Date";
            this.gclDate.Name = "gclDate";
            this.gclDate.ReadOnly = true;
            this.gclDate.Width = 150;
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
            // frmHomeVisitToolSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbHomeVisitSearch);
            this.Name = "frmHomeVisitToolSearch";
            this.Size = new System.Drawing.Size(720, 503);
            this.Load += new System.EventHandler(this.frmHomeVisitToolSearch_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmHomeVisitToolSearch_Paint);
            this.gbHomeVisitSearch.ResumeLayout(false);
            this.gbHomeVisitSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).EndInit();
            this.tplButton01.ResumeLayout(false);
            this.tlpSearch01.ResumeLayout(false);
            this.tlpSearch01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbHomeVisitSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel llblNewRegister;
        private System.Windows.Forms.TableLayoutPanel tlpSearch01;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.ComboBox cbHHCode;
        private System.Windows.Forms.Label lblHHCode;
        private System.Windows.Forms.Label lblDateAnd;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DataGridView dgvRegister;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclHHCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gclDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclOfcId;
    }
}
