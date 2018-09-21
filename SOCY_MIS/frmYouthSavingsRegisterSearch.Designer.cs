namespace SOCY_MIS
{
    partial class frmYouthSavingsRegisterSearch
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
            this.label37 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cboIPSearch = new System.Windows.Forms.ComboBox();
            this.cboSubcountySearch = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cboDistrictSearch = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.cboCSOSearch = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.cboParishSearch = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.txtgroupnamesearch = new System.Windows.Forms.TextBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.gdvGroupsList = new System.Windows.Forms.DataGridView();
            this.lnkNewRegister = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvGroupsList)).BeginInit();
            this.SuspendLayout();
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Yellow;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(7, 5);
            this.label37.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(140, 13);
            this.label37.TabIndex = 119;
            this.label37.Text = "Youth Savings Register";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Azure;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel2.Controls.Add(this.cboIPSearch, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboSubcountySearch, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.label27, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.cboDistrictSearch, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label30, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label31, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboCSOSearch, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label32, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cboParishSearch, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label36, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtgroupnamesearch, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnsearch, 3, 3);
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(7, 22);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.91304F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.10638F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.91489F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(708, 115);
            this.tableLayoutPanel2.TabIndex = 118;
            // 
            // cboIPSearch
            // 
            this.cboIPSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIPSearch.FormattingEnabled = true;
            this.cboIPSearch.Location = new System.Drawing.Point(203, 3);
            this.cboIPSearch.Name = "cboIPSearch";
            this.cboIPSearch.Size = new System.Drawing.Size(100, 21);
            this.cboIPSearch.TabIndex = 79;
            this.cboIPSearch.SelectedIndexChanged += new System.EventHandler(this.cboIPSearch_SelectedIndexChanged);
            // 
            // cboSubcountySearch
            // 
            this.cboSubcountySearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSubcountySearch.FormattingEnabled = true;
            this.cboSubcountySearch.Location = new System.Drawing.Point(549, 32);
            this.cboSubcountySearch.Name = "cboSubcountySearch";
            this.cboSubcountySearch.Size = new System.Drawing.Size(100, 21);
            this.cboSubcountySearch.TabIndex = 61;
            this.cboSubcountySearch.SelectedIndexChanged += new System.EventHandler(this.cboSubcountySearch_SelectedIndexChanged);
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(349, 36);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(65, 13);
            this.label27.TabIndex = 60;
            this.label27.Text = "Sub County:";
            // 
            // cboDistrictSearch
            // 
            this.cboDistrictSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDistrictSearch.FormattingEnabled = true;
            this.cboDistrictSearch.Location = new System.Drawing.Point(203, 32);
            this.cboDistrictSearch.Name = "cboDistrictSearch";
            this.cboDistrictSearch.Size = new System.Drawing.Size(100, 21);
            this.cboDistrictSearch.TabIndex = 59;
            this.cboDistrictSearch.SelectedIndexChanged += new System.EventHandler(this.cboDistrictSearch_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 55;
            this.label12.Text = "District:";
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(3, 7);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(109, 13);
            this.label30.TabIndex = 80;
            this.label30.Text = "Implementing Partner:";
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(349, 7);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(32, 13);
            this.label31.TabIndex = 82;
            this.label31.Text = "CSO:";
            // 
            // cboCSOSearch
            // 
            this.cboCSOSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCSOSearch.FormattingEnabled = true;
            this.cboCSOSearch.Location = new System.Drawing.Point(549, 3);
            this.cboCSOSearch.Name = "cboCSOSearch";
            this.cboCSOSearch.Size = new System.Drawing.Size(100, 21);
            this.cboCSOSearch.TabIndex = 65;
            // 
            // label32
            // 
            this.label32.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(3, 64);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(39, 13);
            this.label32.TabIndex = 83;
            this.label32.Text = "Parish:";
            // 
            // cboParishSearch
            // 
            this.cboParishSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboParishSearch.FormattingEnabled = true;
            this.cboParishSearch.Location = new System.Drawing.Point(203, 60);
            this.cboParishSearch.Name = "cboParishSearch";
            this.cboParishSearch.Size = new System.Drawing.Size(100, 21);
            this.cboParishSearch.TabIndex = 100;
            // 
            // label36
            // 
            this.label36.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(349, 64);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(142, 13);
            this.label36.TabIndex = 103;
            this.label36.Text = "Youth Savings Group Name:";
            // 
            // txtgroupnamesearch
            // 
            this.txtgroupnamesearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtgroupnamesearch.Location = new System.Drawing.Point(548, 59);
            this.txtgroupnamesearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtgroupnamesearch.Name = "txtgroupnamesearch";
            this.txtgroupnamesearch.Size = new System.Drawing.Size(102, 20);
            this.txtgroupnamesearch.TabIndex = 120;
            // 
            // btnsearch
            // 
            this.btnsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.ForeColor = System.Drawing.Color.Blue;
            this.btnsearch.Location = new System.Drawing.Point(348, 86);
            this.btnsearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(143, 25);
            this.btnsearch.TabIndex = 101;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // gdvGroupsList
            // 
            this.gdvGroupsList.AllowUserToAddRows = false;
            this.gdvGroupsList.AllowUserToDeleteRows = false;
            this.gdvGroupsList.AllowUserToResizeColumns = false;
            this.gdvGroupsList.AllowUserToResizeRows = false;
            this.gdvGroupsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdvGroupsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvGroupsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvGroupsList.Location = new System.Drawing.Point(7, 142);
            this.gdvGroupsList.Margin = new System.Windows.Forms.Padding(2);
            this.gdvGroupsList.Name = "gdvGroupsList";
            this.gdvGroupsList.ReadOnly = true;
            this.gdvGroupsList.RowTemplate.Height = 24;
            this.gdvGroupsList.Size = new System.Drawing.Size(706, 339);
            this.gdvGroupsList.TabIndex = 120;
            this.gdvGroupsList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvGroupsList_CellDoubleClick);
            // 
            // lnkNewRegister
            // 
            this.lnkNewRegister.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lnkNewRegister.AutoSize = true;
            this.lnkNewRegister.Location = new System.Drawing.Point(644, 6);
            this.lnkNewRegister.Name = "lnkNewRegister";
            this.lnkNewRegister.Size = new System.Drawing.Size(71, 13);
            this.lnkNewRegister.TabIndex = 121;
            this.lnkNewRegister.TabStop = true;
            this.lnkNewRegister.Text = "New Register";
            this.lnkNewRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNewRegister_LinkClicked);
            // 
            // frmYouthSavingsRegisterSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lnkNewRegister);
            this.Controls.Add(this.gdvGroupsList);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "frmYouthSavingsRegisterSearch";
            this.Size = new System.Drawing.Size(720, 503);
            this.Load += new System.EventHandler(this.frmYouthSavingsRegisterSearch_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvGroupsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cboIPSearch;
        private System.Windows.Forms.ComboBox cboSubcountySearch;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cboDistrictSearch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox cboCSOSearch;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox cboParishSearch;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtgroupnamesearch;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.DataGridView gdvGroupsList;
        private System.Windows.Forms.LinkLabel lnkNewRegister;
    }
}
