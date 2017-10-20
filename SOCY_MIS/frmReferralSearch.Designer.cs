namespace SOCY_MIS
{
    partial class frmReferralSearch
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
            this.gbActivityTrainingSearch = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvRegister = new System.Windows.Forms.DataGridView();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.llblNewRegister = new System.Windows.Forms.LinkLabel();
            this.tlpSearch01 = new System.Windows.Forms.TableLayoutPanel();
            this.cbHHCode = new System.Windows.Forms.ComboBox();
            this.lblHHCode = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblHHMember = new System.Windows.Forms.Label();
            this.cbHHMember = new System.Windows.Forms.ComboBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateAnd = new System.Windows.Forms.Label();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclHHCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclHHMNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclHHMName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gclOfcId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbActivityTrainingSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).BeginInit();
            this.tplButton01.SuspendLayout();
            this.tlpSearch01.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbActivityTrainingSearch
            // 
            this.gbActivityTrainingSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbActivityTrainingSearch.Controls.Add(this.btnDelete);
            this.gbActivityTrainingSearch.Controls.Add(this.dgvRegister);
            this.gbActivityTrainingSearch.Controls.Add(this.tplButton01);
            this.gbActivityTrainingSearch.Controls.Add(this.llblNewRegister);
            this.gbActivityTrainingSearch.Controls.Add(this.tlpSearch01);
            this.gbActivityTrainingSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbActivityTrainingSearch.Location = new System.Drawing.Point(3, 6);
            this.gbActivityTrainingSearch.Name = "gbActivityTrainingSearch";
            this.gbActivityTrainingSearch.Size = new System.Drawing.Size(714, 497);
            this.gbActivityTrainingSearch.TabIndex = 1;
            this.gbActivityTrainingSearch.TabStop = false;
            this.gbActivityTrainingSearch.Text = "Referral Search";
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
            this.gclHHCode,
            this.gclHHMNumber,
            this.gclHHMName,
            this.gclDate,
            this.gclDelete,
            this.gclOfcId});
            this.dgvRegister.Location = new System.Drawing.Point(6, 145);
            this.dgvRegister.MultiSelect = false;
            this.dgvRegister.Name = "dgvRegister";
            this.dgvRegister.Size = new System.Drawing.Size(702, 314);
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
            this.llblNewRegister.Size = new System.Drawing.Size(69, 13);
            this.llblNewRegister.TabIndex = 18;
            this.llblNewRegister.TabStop = true;
            this.llblNewRegister.Text = "New Referral";
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
            this.tlpSearch01.Controls.Add(this.lblHHMember, 3, 0);
            this.tlpSearch01.Controls.Add(this.cbHHMember, 4, 0);
            this.tlpSearch01.Controls.Add(this.dtpDateTo, 4, 1);
            this.tlpSearch01.Controls.Add(this.lblDateAnd, 3, 1);
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
            this.cbHHCode.SelectionChangeCommitted += new System.EventHandler(this.cbHHCode_SelectionChangeCommitted);
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
            this.lblDateFrom.Size = new System.Drawing.Size(117, 13);
            this.lblDateFrom.TabIndex = 12;
            this.lblDateFrom.Text = "Referral Date between:";
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
            // lblHHMember
            // 
            this.lblHHMember.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHHMember.AutoSize = true;
            this.lblHHMember.Location = new System.Drawing.Point(330, 8);
            this.lblHHMember.Name = "lblHHMember";
            this.lblHHMember.Size = new System.Drawing.Size(102, 13);
            this.lblHHMember.TabIndex = 14;
            this.lblHHMember.Text = "Household Member:";
            // 
            // cbHHMember
            // 
            this.cbHHMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHHMember.FormattingEnabled = true;
            this.cbHHMember.Location = new System.Drawing.Point(460, 4);
            this.cbHHMember.Name = "cbHHMember";
            this.cbHHMember.Size = new System.Drawing.Size(171, 21);
            this.cbHHMember.TabIndex = 15;
            this.cbHHMember.SelectionChangeCommitted += new System.EventHandler(this.cbHHMember_SelectionChangeCommitted);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(460, 35);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(115, 20);
            this.dtpDateTo.TabIndex = 16;
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
            // gclID
            // 
            this.gclID.DataPropertyName = "rfr_id";
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
            // gclHHMNumber
            // 
            this.gclHHMNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclHHMNumber.DataPropertyName = "hhm_number";
            this.gclHHMNumber.HeaderText = "Member Number";
            this.gclHHMNumber.Name = "gclHHMNumber";
            this.gclHHMNumber.ReadOnly = true;
            // 
            // gclHHMName
            // 
            this.gclHHMName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclHHMName.DataPropertyName = "hhm_name";
            this.gclHHMName.HeaderText = "Member Name";
            this.gclHHMName.Name = "gclHHMName";
            this.gclHHMName.ReadOnly = true;
            // 
            // gclDate
            // 
            this.gclDate.DataPropertyName = "the_date_display";
            this.gclDate.HeaderText = "Referral Date";
            this.gclDate.Name = "gclDate";
            this.gclDate.ReadOnly = true;
            this.gclDate.Width = 120;
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
            // frmReferralSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbActivityTrainingSearch);
            this.Name = "frmReferralSearch";
            this.Size = new System.Drawing.Size(720, 503);
            this.Load += new System.EventHandler(this.frmReferralSearch_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmReferralSearch_Paint);
            this.gbActivityTrainingSearch.ResumeLayout(false);
            this.gbActivityTrainingSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).EndInit();
            this.tplButton01.ResumeLayout(false);
            this.tlpSearch01.ResumeLayout(false);
            this.tlpSearch01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbActivityTrainingSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvRegister;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel llblNewRegister;
        private System.Windows.Forms.TableLayoutPanel tlpSearch01;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.ComboBox cbHHCode;
        private System.Windows.Forms.Label lblHHCode;
        private System.Windows.Forms.Label lblHHMember;
        private System.Windows.Forms.ComboBox cbHHMember;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblDateAnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclHHCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclHHMNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclHHMName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gclDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclOfcId;
    }
}
