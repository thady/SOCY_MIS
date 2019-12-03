namespace SOCY_MIS
{
    partial class frmHouseholdSearch
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
            this.gbHHSearch = new System.Windows.Forms.GroupBox();
            this.llblINewIndexBeneficiary = new System.Windows.Forms.LinkLabel();
            this.llblNewHousehold = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbHouseholdCode = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHHCode = new System.Windows.Forms.Label();
            this.lblSubCounty = new System.Windows.Forms.Label();
            this.cbSubCounty = new System.Windows.Forms.ComboBox();
            this.cbDistrict = new System.Windows.Forms.ComboBox();
            this.lblWard = new System.Windows.Forms.Label();
            this.cbWard = new System.Windows.Forms.ComboBox();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.txtHHCode = new System.Windows.Forms.TextBox();
            this.dgvHousehold = new System.Windows.Forms.DataGridView();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDistrict = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclSubCounty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclWard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbHHSearch.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHousehold)).BeginInit();
            this.SuspendLayout();
            // 
            // gbHHSearch
            // 
            this.gbHHSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbHHSearch.Controls.Add(this.llblINewIndexBeneficiary);
            this.gbHHSearch.Controls.Add(this.llblNewHousehold);
            this.gbHHSearch.Controls.Add(this.tableLayoutPanel3);
            this.gbHHSearch.Controls.Add(this.tableLayoutPanel2);
            this.gbHHSearch.Controls.Add(this.dgvHousehold);
            this.gbHHSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHHSearch.Location = new System.Drawing.Point(3, 6);
            this.gbHHSearch.Name = "gbHHSearch";
            this.gbHHSearch.Size = new System.Drawing.Size(904, 511);
            this.gbHHSearch.TabIndex = 4;
            this.gbHHSearch.TabStop = false;
            this.gbHHSearch.Text = "Household Search";
            // 
            // llblINewIndexBeneficiary
            // 
            this.llblINewIndexBeneficiary.AutoSize = true;
            this.llblINewIndexBeneficiary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblINewIndexBeneficiary.Location = new System.Drawing.Point(290, 18);
            this.llblINewIndexBeneficiary.Name = "llblINewIndexBeneficiary";
            this.llblINewIndexBeneficiary.Size = new System.Drawing.Size(172, 13);
            this.llblINewIndexBeneficiary.TabIndex = 36;
            this.llblINewIndexBeneficiary.TabStop = true;
            this.llblINewIndexBeneficiary.Text = "New Index Beneficiary Registration";
            this.llblINewIndexBeneficiary.Visible = false;
            this.llblINewIndexBeneficiary.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblINewIndexBeneficiary_LinkClicked);
            // 
            // llblNewHousehold
            // 
            this.llblNewHousehold.AutoSize = true;
            this.llblNewHousehold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblNewHousehold.Location = new System.Drawing.Point(33, 18);
            this.llblNewHousehold.Name = "llblNewHousehold";
            this.llblNewHousehold.Size = new System.Drawing.Size(251, 13);
            this.llblNewHousehold.TabIndex = 35;
            this.llblNewHousehold.TabStop = true;
            this.llblNewHousehold.Text = "New household/OVC Identification and Prioritization";
            this.llblNewHousehold.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblNewHousehold_LinkClicked);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnSearch, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCancel, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbHouseholdCode, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(30, 99);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(854, 40);
            this.tableLayoutPanel3.TabIndex = 34;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(329, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(450, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbHouseholdCode
            // 
            this.cbHouseholdCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbHouseholdCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHouseholdCode.FormattingEnabled = true;
            this.cbHouseholdCode.Location = new System.Drawing.Point(410, 9);
            this.cbHouseholdCode.Name = "cbHouseholdCode";
            this.cbHouseholdCode.Size = new System.Drawing.Size(34, 21);
            this.cbHouseholdCode.TabIndex = 10;
            this.cbHouseholdCode.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Controls.Add(this.lblHHCode, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSubCounty, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbSubCounty, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbDistrict, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblWard, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbWard, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblDistrict, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtHHCode, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(30, 40);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(854, 60);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // lblHHCode
            // 
            this.lblHHCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHHCode.AutoSize = true;
            this.lblHHCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHHCode.Location = new System.Drawing.Point(3, 8);
            this.lblHHCode.Name = "lblHHCode";
            this.lblHHCode.Size = new System.Drawing.Size(89, 13);
            this.lblHHCode.TabIndex = 2;
            this.lblHHCode.Text = "Household Code:";
            // 
            // lblSubCounty
            // 
            this.lblSubCounty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubCounty.AutoSize = true;
            this.lblSubCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCounty.Location = new System.Drawing.Point(3, 38);
            this.lblSubCounty.Name = "lblSubCounty";
            this.lblSubCounty.Size = new System.Drawing.Size(65, 13);
            this.lblSubCounty.TabIndex = 12;
            this.lblSubCounty.Text = "Sub County:";
            // 
            // cbSubCounty
            // 
            this.cbSubCounty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSubCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubCounty.FormattingEnabled = true;
            this.cbSubCounty.Location = new System.Drawing.Point(153, 34);
            this.cbSubCounty.Name = "cbSubCounty";
            this.cbSubCounty.Size = new System.Drawing.Size(231, 21);
            this.cbSubCounty.TabIndex = 15;
            this.cbSubCounty.SelectionChangeCommitted += new System.EventHandler(this.cbSubCounty_SelectionChangeCommitted);
            // 
            // cbDistrict
            // 
            this.cbDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDistrict.FormattingEnabled = true;
            this.cbDistrict.Location = new System.Drawing.Point(580, 4);
            this.cbDistrict.Name = "cbDistrict";
            this.cbDistrict.Size = new System.Drawing.Size(231, 21);
            this.cbDistrict.TabIndex = 16;
            this.cbDistrict.SelectionChangeCommitted += new System.EventHandler(this.cbDistrict_SelectionChangeCommitted);
            // 
            // lblWard
            // 
            this.lblWard.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblWard.AutoSize = true;
            this.lblWard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWard.Location = new System.Drawing.Point(430, 38);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(70, 13);
            this.lblWard.TabIndex = 13;
            this.lblWard.Text = "Parish/Ward:";
            // 
            // cbWard
            // 
            this.cbWard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbWard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWard.FormattingEnabled = true;
            this.cbWard.Location = new System.Drawing.Point(580, 34);
            this.cbWard.Name = "cbWard";
            this.cbWard.Size = new System.Drawing.Size(231, 21);
            this.cbWard.TabIndex = 14;
            this.cbWard.SelectionChangeCommitted += new System.EventHandler(this.cbWard_SelectionChangeCommitted);
            // 
            // lblDistrict
            // 
            this.lblDistrict.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistrict.Location = new System.Drawing.Point(430, 8);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(42, 13);
            this.lblDistrict.TabIndex = 11;
            this.lblDistrict.Text = "District:";
            // 
            // txtHHCode
            // 
            this.txtHHCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHHCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHHCode.Location = new System.Drawing.Point(153, 3);
            this.txtHHCode.Name = "txtHHCode";
            this.txtHHCode.Size = new System.Drawing.Size(231, 20);
            this.txtHHCode.TabIndex = 17;
            // 
            // dgvHousehold
            // 
            this.dgvHousehold.AllowUserToAddRows = false;
            this.dgvHousehold.AllowUserToDeleteRows = false;
            this.dgvHousehold.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHousehold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHousehold.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gclID,
            this.gclFirstName,
            this.gclDistrict,
            this.gclSubCounty,
            this.gclWard});
            this.dgvHousehold.Location = new System.Drawing.Point(6, 150);
            this.dgvHousehold.MultiSelect = false;
            this.dgvHousehold.Name = "dgvHousehold";
            this.dgvHousehold.Size = new System.Drawing.Size(892, 355);
            this.dgvHousehold.TabIndex = 0;
            this.dgvHousehold.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHousehold_CellDoubleClick);
            // 
            // gclID
            // 
            this.gclID.DataPropertyName = "hh_id";
            this.gclID.HeaderText = "ID";
            this.gclID.Name = "gclID";
            this.gclID.ReadOnly = true;
            this.gclID.Visible = false;
            // 
            // gclFirstName
            // 
            this.gclFirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclFirstName.DataPropertyName = "hh_code";
            this.gclFirstName.HeaderText = "Household Code";
            this.gclFirstName.Name = "gclFirstName";
            this.gclFirstName.ReadOnly = true;
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
            // frmHouseholdSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbHHSearch);
            this.Name = "frmHouseholdSearch";
            this.Size = new System.Drawing.Size(910, 520);
            this.Load += new System.EventHandler(this.frmHouseholdSearch_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmHouseholdSearch_Paint);
            this.gbHHSearch.ResumeLayout(false);
            this.gbHHSearch.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHousehold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbHHSearch;
        private System.Windows.Forms.ComboBox cbDistrict;
        private System.Windows.Forms.ComboBox cbSubCounty;
        private System.Windows.Forms.ComboBox cbWard;
        private System.Windows.Forms.Label lblWard;
        private System.Windows.Forms.Label lblSubCounty;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.ComboBox cbHouseholdCode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblHHCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvHousehold;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.LinkLabel llblNewHousehold;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclDistrict;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclSubCounty;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclWard;
        private System.Windows.Forms.TextBox txtHHCode;
        private System.Windows.Forms.LinkLabel llblINewIndexBeneficiary;
    }
}
