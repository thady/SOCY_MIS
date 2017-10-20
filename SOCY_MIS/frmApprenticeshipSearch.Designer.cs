namespace SOCY_MIS
{
    partial class frmApprenticeshipSearch
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
            this.gbApprenticeshipSearch = new System.Windows.Forms.GroupBox();
            this.dgvRegister = new System.Windows.Forms.DataGridView();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.llblNewRegister = new System.Windows.Forms.LinkLabel();
            this.tlpSearch01 = new System.Windows.Forms.TableLayoutPanel();
            this.cbCSO = new System.Windows.Forms.ComboBox();
            this.lblCSO = new System.Windows.Forms.Label();
            this.lblHHCode = new System.Windows.Forms.Label();
            this.cbHHCode = new System.Windows.Forms.ComboBox();
            this.lblHHMember = new System.Windows.Forms.Label();
            this.cbHHMember = new System.Windows.Forms.ComboBox();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.dtpCreateDateBegin = new System.Windows.Forms.DateTimePicker();
            this.dtpCreateDateEnd = new System.Windows.Forms.DateTimePicker();
            this.lblCreateDateAnd = new System.Windows.Forms.Label();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.cbDistrict = new System.Windows.Forms.ComboBox();
            this.lblSubCounty = new System.Windows.Forms.Label();
            this.cbSubCounty = new System.Windows.Forms.ComboBox();
            this.gbApprenticeshipSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).BeginInit();
            this.tplButton01.SuspendLayout();
            this.tlpSearch01.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbApprenticeshipSearch
            // 
            this.gbApprenticeshipSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbApprenticeshipSearch.Controls.Add(this.dgvRegister);
            this.gbApprenticeshipSearch.Controls.Add(this.tplButton01);
            this.gbApprenticeshipSearch.Controls.Add(this.llblNewRegister);
            this.gbApprenticeshipSearch.Controls.Add(this.tlpSearch01);
            this.gbApprenticeshipSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbApprenticeshipSearch.Location = new System.Drawing.Point(3, 6);
            this.gbApprenticeshipSearch.Name = "gbApprenticeshipSearch";
            this.gbApprenticeshipSearch.Size = new System.Drawing.Size(714, 494);
            this.gbApprenticeshipSearch.TabIndex = 1;
            this.gbApprenticeshipSearch.TabStop = false;
            this.gbApprenticeshipSearch.Text = "Apprenticeship Register Search";
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
            this.gclDate,
            this.gclNumber});
            this.dgvRegister.Location = new System.Drawing.Point(6, 205);
            this.dgvRegister.MultiSelect = false;
            this.dgvRegister.Name = "dgvRegister";
            this.dgvRegister.Size = new System.Drawing.Size(702, 283);
            this.dgvRegister.TabIndex = 23;
            this.dgvRegister.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegister_CellDoubleClick);
            // 
            // gclID
            // 
            this.gclID.DataPropertyName = "apr_id";
            this.gclID.HeaderText = "ID";
            this.gclID.Name = "gclID";
            this.gclID.ReadOnly = true;
            this.gclID.Visible = false;
            // 
            // gclDate
            // 
            this.gclDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclDate.DataPropertyName = "the_date_display";
            this.gclDate.HeaderText = "Create Date";
            this.gclDate.Name = "gclDate";
            this.gclDate.ReadOnly = true;
            // 
            // gclNumber
            // 
            this.gclNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclNumber.DataPropertyName = "num_records";
            this.gclNumber.HeaderText = "Number of Records";
            this.gclNumber.Name = "gclNumber";
            this.gclNumber.ReadOnly = true;
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
            this.tlpSearch01.Controls.Add(this.cbCSO, 1, 0);
            this.tlpSearch01.Controls.Add(this.lblCSO, 0, 0);
            this.tlpSearch01.Controls.Add(this.lblCreateDate, 0, 1);
            this.tlpSearch01.Controls.Add(this.dtpCreateDateBegin, 1, 1);
            this.tlpSearch01.Controls.Add(this.dtpCreateDateEnd, 4, 1);
            this.tlpSearch01.Controls.Add(this.lblCreateDateAnd, 3, 1);
            this.tlpSearch01.Controls.Add(this.cbHHCode, 1, 3);
            this.tlpSearch01.Controls.Add(this.cbDistrict, 1, 2);
            this.tlpSearch01.Controls.Add(this.lblHHCode, 0, 3);
            this.tlpSearch01.Controls.Add(this.lblDistrict, 0, 2);
            this.tlpSearch01.Controls.Add(this.lblHHMember, 3, 3);
            this.tlpSearch01.Controls.Add(this.lblSubCounty, 3, 2);
            this.tlpSearch01.Controls.Add(this.cbHHMember, 4, 3);
            this.tlpSearch01.Controls.Add(this.cbSubCounty, 4, 2);
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
            // cbCSO
            // 
            this.cbCSO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCSO.FormattingEnabled = true;
            this.cbCSO.Location = new System.Drawing.Point(133, 4);
            this.cbCSO.Name = "cbCSO";
            this.cbCSO.Size = new System.Drawing.Size(171, 21);
            this.cbCSO.TabIndex = 11;
            // 
            // lblCSO
            // 
            this.lblCSO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCSO.AutoSize = true;
            this.lblCSO.Location = new System.Drawing.Point(3, 8);
            this.lblCSO.Name = "lblCSO";
            this.lblCSO.Size = new System.Drawing.Size(63, 13);
            this.lblCSO.TabIndex = 0;
            this.lblCSO.Text = "CSO Name:";
            // 
            // lblHHCode
            // 
            this.lblHHCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHHCode.AutoSize = true;
            this.lblHHCode.Location = new System.Drawing.Point(3, 98);
            this.lblHHCode.Name = "lblHHCode";
            this.lblHHCode.Size = new System.Drawing.Size(89, 13);
            this.lblHHCode.TabIndex = 0;
            this.lblHHCode.Text = "Household Code:";
            // 
            // cbHHCode
            // 
            this.cbHHCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHHCode.FormattingEnabled = true;
            this.cbHHCode.Location = new System.Drawing.Point(133, 94);
            this.cbHHCode.Name = "cbHHCode";
            this.cbHHCode.Size = new System.Drawing.Size(171, 21);
            this.cbHHCode.TabIndex = 14;
            this.cbHHCode.SelectionChangeCommitted += new System.EventHandler(this.cbHHCode_SelectionChangeCommitted);
            // 
            // lblHHMember
            // 
            this.lblHHMember.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHHMember.AutoSize = true;
            this.lblHHMember.Location = new System.Drawing.Point(330, 98);
            this.lblHHMember.Name = "lblHHMember";
            this.lblHHMember.Size = new System.Drawing.Size(102, 13);
            this.lblHHMember.TabIndex = 12;
            this.lblHHMember.Text = "Household Member:";
            // 
            // cbHHMember
            // 
            this.cbHHMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHHMember.FormattingEnabled = true;
            this.cbHHMember.Location = new System.Drawing.Point(460, 94);
            this.cbHHMember.Name = "cbHHMember";
            this.cbHHMember.Size = new System.Drawing.Size(171, 21);
            this.cbHHMember.TabIndex = 11;
            this.cbHHMember.SelectionChangeCommitted += new System.EventHandler(this.cbHHMember_SelectionChangeCommitted);
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCreateDate.AutoSize = true;
            this.lblCreateDate.Location = new System.Drawing.Point(3, 38);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(112, 13);
            this.lblCreateDate.TabIndex = 12;
            this.lblCreateDate.Text = "Create Date Between:";
            // 
            // dtpCreateDateBegin
            // 
            this.dtpCreateDateBegin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpCreateDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreateDateBegin.Location = new System.Drawing.Point(133, 35);
            this.dtpCreateDateBegin.Name = "dtpCreateDateBegin";
            this.dtpCreateDateBegin.Size = new System.Drawing.Size(115, 20);
            this.dtpCreateDateBegin.TabIndex = 13;
            // 
            // dtpCreateDateEnd
            // 
            this.dtpCreateDateEnd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpCreateDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreateDateEnd.Location = new System.Drawing.Point(460, 35);
            this.dtpCreateDateEnd.Name = "dtpCreateDateEnd";
            this.dtpCreateDateEnd.Size = new System.Drawing.Size(115, 20);
            this.dtpCreateDateEnd.TabIndex = 15;
            // 
            // lblCreateDateAnd
            // 
            this.lblCreateDateAnd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCreateDateAnd.AutoSize = true;
            this.lblCreateDateAnd.Location = new System.Drawing.Point(330, 38);
            this.lblCreateDateAnd.Name = "lblCreateDateAnd";
            this.lblCreateDateAnd.Size = new System.Drawing.Size(25, 13);
            this.lblCreateDateAnd.TabIndex = 16;
            this.lblCreateDateAnd.Text = "and";
            // 
            // lblDistrict
            // 
            this.lblDistrict.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistrict.Location = new System.Drawing.Point(3, 68);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(42, 13);
            this.lblDistrict.TabIndex = 36;
            this.lblDistrict.Text = "District:";
            // 
            // cbDistrict
            // 
            this.cbDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDistrict.FormattingEnabled = true;
            this.cbDistrict.Location = new System.Drawing.Point(133, 64);
            this.cbDistrict.Name = "cbDistrict";
            this.cbDistrict.Size = new System.Drawing.Size(171, 21);
            this.cbDistrict.TabIndex = 37;
            this.cbDistrict.SelectionChangeCommitted += new System.EventHandler(this.cbDistrict_SelectionChangeCommitted);
            // 
            // lblSubCounty
            // 
            this.lblSubCounty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubCounty.AutoSize = true;
            this.lblSubCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCounty.Location = new System.Drawing.Point(330, 68);
            this.lblSubCounty.Name = "lblSubCounty";
            this.lblSubCounty.Size = new System.Drawing.Size(65, 13);
            this.lblSubCounty.TabIndex = 38;
            this.lblSubCounty.Text = "Sub County:";
            // 
            // cbSubCounty
            // 
            this.cbSubCounty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSubCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubCounty.FormattingEnabled = true;
            this.cbSubCounty.Location = new System.Drawing.Point(460, 64);
            this.cbSubCounty.Name = "cbSubCounty";
            this.cbSubCounty.Size = new System.Drawing.Size(171, 21);
            this.cbSubCounty.TabIndex = 39;
            this.cbSubCounty.SelectionChangeCommitted += new System.EventHandler(this.cbSubCounty_SelectionChangeCommitted);
            // 
            // frmApprenticeshipSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbApprenticeshipSearch);
            this.Name = "frmApprenticeshipSearch";
            this.Size = new System.Drawing.Size(720, 503);
            this.Load += new System.EventHandler(this.frmApprenticeshipSearch_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmApprenticeshipSearch_Paint);
            this.gbApprenticeshipSearch.ResumeLayout(false);
            this.gbApprenticeshipSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).EndInit();
            this.tplButton01.ResumeLayout(false);
            this.tlpSearch01.ResumeLayout(false);
            this.tlpSearch01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbApprenticeshipSearch;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel llblNewRegister;
        private System.Windows.Forms.TableLayoutPanel tlpSearch01;
        private System.Windows.Forms.DateTimePicker dtpCreateDateBegin;
        private System.Windows.Forms.Label lblCreateDate;
        private System.Windows.Forms.ComboBox cbCSO;
        private System.Windows.Forms.Label lblCSO;
        private System.Windows.Forms.Label lblHHMember;
        private System.Windows.Forms.Label lblHHCode;
        private System.Windows.Forms.ComboBox cbHHMember;
        private System.Windows.Forms.DataGridView dgvRegister;
        private System.Windows.Forms.ComboBox cbHHCode;
        private System.Windows.Forms.DateTimePicker dtpCreateDateEnd;
        private System.Windows.Forms.Label lblCreateDateAnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclNumber;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.ComboBox cbDistrict;
        private System.Windows.Forms.Label lblSubCounty;
        private System.Windows.Forms.ComboBox cbSubCounty;
    }
}
