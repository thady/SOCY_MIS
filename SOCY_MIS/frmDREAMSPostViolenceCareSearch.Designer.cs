namespace SOCY_MIS
{
    partial class frmDREAMSPostViolenceCareSearch
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
            this.gbPostViolenceCareRegisterSearch = new System.Windows.Forms.GroupBox();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpSearch01 = new System.Windows.Forms.TableLayoutPanel();
            this.cbFacility = new System.Windows.Forms.ComboBox();
            this.lblFacility = new System.Windows.Forms.Label();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.cbDistrict = new System.Windows.Forms.ComboBox();
            this.lblCaptureDateFrom = new System.Windows.Forms.Label();
            this.lblSubCounty = new System.Windows.Forms.Label();
            this.cbSubCounty = new System.Windows.Forms.ComboBox();
            this.lblCaptureDateTo = new System.Windows.Forms.Label();
            this.dtpCaptureDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpCaptureDateTo = new System.Windows.Forms.DateTimePicker();
            this.dgvRegister = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.llblNewRegister = new System.Windows.Forms.LinkLabel();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclFacility = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDistrict = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclSubCounty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclCaptureDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gclOfcId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbPostViolenceCareRegisterSearch.SuspendLayout();
            this.tplButton01.SuspendLayout();
            this.tlpSearch01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPostViolenceCareRegisterSearch
            // 
            this.gbPostViolenceCareRegisterSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPostViolenceCareRegisterSearch.Controls.Add(this.tplButton01);
            this.gbPostViolenceCareRegisterSearch.Controls.Add(this.tlpSearch01);
            this.gbPostViolenceCareRegisterSearch.Controls.Add(this.dgvRegister);
            this.gbPostViolenceCareRegisterSearch.Controls.Add(this.btnDelete);
            this.gbPostViolenceCareRegisterSearch.Controls.Add(this.llblNewRegister);
            this.gbPostViolenceCareRegisterSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPostViolenceCareRegisterSearch.Location = new System.Drawing.Point(3, 6);
            this.gbPostViolenceCareRegisterSearch.Name = "gbPostViolenceCareRegisterSearch";
            this.gbPostViolenceCareRegisterSearch.Size = new System.Drawing.Size(714, 494);
            this.gbPostViolenceCareRegisterSearch.TabIndex = 3;
            this.gbPostViolenceCareRegisterSearch.TabStop = false;
            this.gbPostViolenceCareRegisterSearch.Text = "Post Violence Care Register Search";
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
            this.tplButton01.TabIndex = 25;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(229, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
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
            this.btnCancel.TabIndex = 7;
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
            this.tlpSearch01.Controls.Add(this.cbFacility, 1, 0);
            this.tlpSearch01.Controls.Add(this.lblFacility, 0, 0);
            this.tlpSearch01.Controls.Add(this.lblDistrict, 0, 1);
            this.tlpSearch01.Controls.Add(this.cbDistrict, 1, 1);
            this.tlpSearch01.Controls.Add(this.lblCaptureDateFrom, 0, 2);
            this.tlpSearch01.Controls.Add(this.lblSubCounty, 3, 1);
            this.tlpSearch01.Controls.Add(this.cbSubCounty, 4, 1);
            this.tlpSearch01.Controls.Add(this.lblCaptureDateTo, 3, 2);
            this.tlpSearch01.Controls.Add(this.dtpCaptureDateFrom, 1, 2);
            this.tlpSearch01.Controls.Add(this.dtpCaptureDateTo, 4, 2);
            this.tlpSearch01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpSearch01.Location = new System.Drawing.Point(30, 40);
            this.tlpSearch01.Name = "tlpSearch01";
            this.tlpSearch01.RowCount = 3;
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSearch01.Size = new System.Drawing.Size(654, 90);
            this.tlpSearch01.TabIndex = 24;
            // 
            // cbFacility
            // 
            this.cbFacility.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFacility.FormattingEnabled = true;
            this.cbFacility.Location = new System.Drawing.Point(133, 4);
            this.cbFacility.Name = "cbFacility";
            this.cbFacility.Size = new System.Drawing.Size(171, 21);
            this.cbFacility.TabIndex = 1;
            // 
            // lblFacility
            // 
            this.lblFacility.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFacility.AutoSize = true;
            this.lblFacility.Location = new System.Drawing.Point(3, 8);
            this.lblFacility.Name = "lblFacility";
            this.lblFacility.Size = new System.Drawing.Size(42, 13);
            this.lblFacility.TabIndex = 0;
            this.lblFacility.Text = "Facility:";
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
            this.cbDistrict.TabIndex = 2;
            this.cbDistrict.SelectionChangeCommitted += new System.EventHandler(this.cbDistrict_SelectionChangeCommitted);
            // 
            // lblCaptureDateFrom
            // 
            this.lblCaptureDateFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCaptureDateFrom.AutoSize = true;
            this.lblCaptureDateFrom.Location = new System.Drawing.Point(3, 68);
            this.lblCaptureDateFrom.Name = "lblCaptureDateFrom";
            this.lblCaptureDateFrom.Size = new System.Drawing.Size(99, 13);
            this.lblCaptureDateFrom.TabIndex = 14;
            this.lblCaptureDateFrom.Text = "Capture Date From:";
            // 
            // lblSubCounty
            // 
            this.lblSubCounty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubCounty.AutoSize = true;
            this.lblSubCounty.Location = new System.Drawing.Point(330, 38);
            this.lblSubCounty.Name = "lblSubCounty";
            this.lblSubCounty.Size = new System.Drawing.Size(65, 13);
            this.lblSubCounty.TabIndex = 15;
            this.lblSubCounty.Text = "Sub County:";
            // 
            // cbSubCounty
            // 
            this.cbSubCounty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSubCounty.FormattingEnabled = true;
            this.cbSubCounty.Location = new System.Drawing.Point(460, 34);
            this.cbSubCounty.Name = "cbSubCounty";
            this.cbSubCounty.Size = new System.Drawing.Size(171, 21);
            this.cbSubCounty.TabIndex = 3;
            this.cbSubCounty.SelectionChangeCommitted += new System.EventHandler(this.cbSubCounty_SelectionChangeCommitted);
            // 
            // lblCaptureDateTo
            // 
            this.lblCaptureDateTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCaptureDateTo.AutoSize = true;
            this.lblCaptureDateTo.Location = new System.Drawing.Point(330, 68);
            this.lblCaptureDateTo.Name = "lblCaptureDateTo";
            this.lblCaptureDateTo.Size = new System.Drawing.Size(23, 13);
            this.lblCaptureDateTo.TabIndex = 21;
            this.lblCaptureDateTo.Text = "To:";
            // 
            // dtpCaptureDateFrom
            // 
            this.dtpCaptureDateFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpCaptureDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCaptureDateFrom.Location = new System.Drawing.Point(133, 65);
            this.dtpCaptureDateFrom.Name = "dtpCaptureDateFrom";
            this.dtpCaptureDateFrom.Size = new System.Drawing.Size(115, 20);
            this.dtpCaptureDateFrom.TabIndex = 4;
            // 
            // dtpCaptureDateTo
            // 
            this.dtpCaptureDateTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpCaptureDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCaptureDateTo.Location = new System.Drawing.Point(460, 65);
            this.dtpCaptureDateTo.Name = "dtpCaptureDateTo";
            this.dtpCaptureDateTo.Size = new System.Drawing.Size(115, 20);
            this.dtpCaptureDateTo.TabIndex = 5;
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
            this.gclFacility,
            this.gclDistrict,
            this.gclSubCounty,
            this.gclCaptureDate,
            this.gclDelete,
            this.gclOfcId});
            this.dgvRegister.Location = new System.Drawing.Point(6, 175);
            this.dgvRegister.MultiSelect = false;
            this.dgvRegister.Name = "dgvRegister";
            this.dgvRegister.Size = new System.Drawing.Size(702, 284);
            this.dgvRegister.TabIndex = 10;
            this.dgvRegister.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegister_CellDoubleClick);
            this.dgvRegister.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvRegister_RowPostPaint);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(633, 465);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
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
            this.llblNewRegister.TabIndex = 9;
            this.llblNewRegister.TabStop = true;
            this.llblNewRegister.Text = "New Register";
            this.llblNewRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblNewRegister_LinkClicked);
            // 
            // gclID
            // 
            this.gclID.DataPropertyName = "dpvc_id";
            this.gclID.HeaderText = "ID";
            this.gclID.Name = "gclID";
            this.gclID.ReadOnly = true;
            this.gclID.Visible = false;
            // 
            // gclFacility
            // 
            this.gclFacility.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclFacility.DataPropertyName = "flt_name";
            this.gclFacility.HeaderText = "Facility";
            this.gclFacility.Name = "gclFacility";
            this.gclFacility.ReadOnly = true;
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
            // gclCaptureDate
            // 
            this.gclCaptureDate.DataPropertyName = "usr_date_create";
            this.gclCaptureDate.HeaderText = "Capture Date";
            this.gclCaptureDate.Name = "gclCaptureDate";
            this.gclCaptureDate.ReadOnly = true;
            this.gclCaptureDate.Width = 120;
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
            this.gclOfcId.HeaderText = "gclOfcId";
            this.gclOfcId.Name = "gclOfcId";
            this.gclOfcId.ReadOnly = true;
            this.gclOfcId.Visible = false;
            // 
            // frmDREAMSPostViolenceCareSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbPostViolenceCareRegisterSearch);
            this.Name = "frmDREAMSPostViolenceCareSearch";
            this.Size = new System.Drawing.Size(720, 503);
            this.Load += new System.EventHandler(this.frmDREAMSPostViolenceCareSearch_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmDREAMSPostViolenceCareSearch_Paint);
            this.gbPostViolenceCareRegisterSearch.ResumeLayout(false);
            this.gbPostViolenceCareRegisterSearch.PerformLayout();
            this.tplButton01.ResumeLayout(false);
            this.tlpSearch01.ResumeLayout(false);
            this.tlpSearch01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPostViolenceCareRegisterSearch;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlpSearch01;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.ComboBox cbFacility;
        private System.Windows.Forms.Label lblFacility;
        private System.Windows.Forms.Label lblSubCounty;
        private System.Windows.Forms.ComboBox cbSubCounty;
        private System.Windows.Forms.ComboBox cbDistrict;
        private System.Windows.Forms.Label lblCaptureDateTo;
        private System.Windows.Forms.DataGridView dgvRegister;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.LinkLabel llblNewRegister;
        private System.Windows.Forms.Label lblCaptureDateFrom;
        private System.Windows.Forms.DateTimePicker dtpCaptureDateFrom;
        private System.Windows.Forms.DateTimePicker dtpCaptureDateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclFacility;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclDistrict;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclSubCounty;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclCaptureDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gclDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclOfcId;
    }
}
