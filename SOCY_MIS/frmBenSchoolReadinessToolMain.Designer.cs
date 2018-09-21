namespace SOCY_MIS
{
    partial class frmBenSchoolReadinessToolMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnsearch = new System.Windows.Forms.Button();
            this.gdvTrainingList = new System.Windows.Forms.DataGridView();
            this.tlpDisplay01 = new System.Windows.Forms.TableLayoutPanel();
            this.cboParish = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboIP = new System.Windows.Forms.ComboBox();
            this.cboSubCounty = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDistrict = new System.Windows.Forms.ComboBox();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCso = new System.Windows.Forms.ComboBox();
            this.txtHHCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lnlAssessment = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvTrainingList)).BeginInit();
            this.tlpDisplay01.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.gdvTrainingList);
            this.panel1.Controls.Add(this.tlpDisplay01);
            this.panel1.Location = new System.Drawing.Point(5, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 557);
            this.panel1.TabIndex = 121;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Azure;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 226F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.Controls.Add(this.btnsearch, 2, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 117);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.64486F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(707, 32);
            this.tableLayoutPanel1.TabIndex = 85;
            // 
            // btnsearch
            // 
            this.btnsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsearch.Location = new System.Drawing.Point(254, 2);
            this.btnsearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(115, 28);
            this.btnsearch.TabIndex = 0;
            this.btnsearch.Text = "SEARCH";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // gdvTrainingList
            // 
            this.gdvTrainingList.AllowUserToAddRows = false;
            this.gdvTrainingList.AllowUserToDeleteRows = false;
            this.gdvTrainingList.AllowUserToResizeColumns = false;
            this.gdvTrainingList.AllowUserToResizeRows = false;
            this.gdvTrainingList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdvTrainingList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvTrainingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvTrainingList.Location = new System.Drawing.Point(0, 152);
            this.gdvTrainingList.Margin = new System.Windows.Forms.Padding(2);
            this.gdvTrainingList.Name = "gdvTrainingList";
            this.gdvTrainingList.ReadOnly = true;
            this.gdvTrainingList.RowTemplate.Height = 24;
            this.gdvTrainingList.Size = new System.Drawing.Size(712, 403);
            this.gdvTrainingList.TabIndex = 106;
            this.gdvTrainingList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvTrainingList_CellDoubleClick);
            // 
            // tlpDisplay01
            // 
            this.tlpDisplay01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDisplay01.BackColor = System.Drawing.Color.Azure;
            this.tlpDisplay01.ColumnCount = 6;
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tlpDisplay01.Controls.Add(this.cboParish, 0, 2);
            this.tlpDisplay01.Controls.Add(this.label1, 0, 2);
            this.tlpDisplay01.Controls.Add(this.cboIP, 1, 0);
            this.tlpDisplay01.Controls.Add(this.cboSubCounty, 4, 1);
            this.tlpDisplay01.Controls.Add(this.label4, 3, 1);
            this.tlpDisplay01.Controls.Add(this.cboDistrict, 1, 1);
            this.tlpDisplay01.Controls.Add(this.lblDistrict, 0, 1);
            this.tlpDisplay01.Controls.Add(this.label7, 0, 0);
            this.tlpDisplay01.Controls.Add(this.label8, 3, 0);
            this.tlpDisplay01.Controls.Add(this.cboCso, 4, 0);
            this.tlpDisplay01.Controls.Add(this.txtHHCode, 4, 2);
            this.tlpDisplay01.Controls.Add(this.label9, 3, 2);
            this.tlpDisplay01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpDisplay01.Location = new System.Drawing.Point(3, 3);
            this.tlpDisplay01.Name = "tlpDisplay01";
            this.tlpDisplay01.RowCount = 3;
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.64486F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.95604F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
            this.tlpDisplay01.Size = new System.Drawing.Size(707, 107);
            this.tlpDisplay01.TabIndex = 52;
            // 
            // cboParish
            // 
            this.cboParish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboParish.FormattingEnabled = true;
            this.cboParish.Location = new System.Drawing.Point(203, 84);
            this.cboParish.Name = "cboParish";
            this.cboParish.Size = new System.Drawing.Size(99, 21);
            this.cboParish.TabIndex = 86;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 85;
            this.label1.Text = "Parish:";
            // 
            // cboIP
            // 
            this.cboIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIP.FormattingEnabled = true;
            this.cboIP.Location = new System.Drawing.Point(203, 7);
            this.cboIP.Name = "cboIP";
            this.cboIP.Size = new System.Drawing.Size(99, 21);
            this.cboIP.TabIndex = 79;
            this.cboIP.SelectedIndexChanged += new System.EventHandler(this.cboIP_SelectedIndexChanged);
            // 
            // cboSubCounty
            // 
            this.cboSubCounty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSubCounty.FormattingEnabled = true;
            this.cboSubCounty.Location = new System.Drawing.Point(548, 47);
            this.cboSubCounty.Name = "cboSubCounty";
            this.cboSubCounty.Size = new System.Drawing.Size(99, 21);
            this.cboSubCounty.TabIndex = 61;
            this.cboSubCounty.SelectedIndexChanged += new System.EventHandler(this.cboSubCounty_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Sub County:";
            // 
            // cboDistrict
            // 
            this.cboDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDistrict.FormattingEnabled = true;
            this.cboDistrict.Location = new System.Drawing.Point(203, 47);
            this.cboDistrict.Name = "cboDistrict";
            this.cboDistrict.Size = new System.Drawing.Size(99, 21);
            this.cboDistrict.TabIndex = 59;
            this.cboDistrict.SelectedIndexChanged += new System.EventHandler(this.cboDistrict_SelectedIndexChanged);
            // 
            // lblDistrict
            // 
            this.lblDistrict.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Location = new System.Drawing.Point(3, 51);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(42, 13);
            this.lblDistrict.TabIndex = 55;
            this.lblDistrict.Text = "District:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 80;
            this.label7.Text = "Implementing Partner:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(348, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 82;
            this.label8.Text = "CSO:";
            // 
            // cboCso
            // 
            this.cboCso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCso.FormattingEnabled = true;
            this.cboCso.Location = new System.Drawing.Point(548, 7);
            this.cboCso.Name = "cboCso";
            this.cboCso.Size = new System.Drawing.Size(99, 21);
            this.cboCso.TabIndex = 65;
            // 
            // txtHHCode
            // 
            this.txtHHCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHHCode.Location = new System.Drawing.Point(547, 84);
            this.txtHHCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtHHCode.Name = "txtHHCode";
            this.txtHHCode.Size = new System.Drawing.Size(101, 20);
            this.txtHHCode.TabIndex = 84;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(348, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 83;
            this.label9.Text = "Household Code:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Yellow;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(3, 2);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(338, 13);
            this.label29.TabIndex = 120;
            this.label29.Text = "SOCY OVC Beneficiary School readiness Assessment Form";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(164, 2);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 122;
            // 
            // lnlAssessment
            // 
            this.lnlAssessment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnlAssessment.AutoSize = true;
            this.lnlAssessment.Location = new System.Drawing.Point(631, 1);
            this.lnlAssessment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnlAssessment.Name = "lnlAssessment";
            this.lnlAssessment.Size = new System.Drawing.Size(88, 13);
            this.lnlAssessment.TabIndex = 123;
            this.lnlAssessment.TabStop = true;
            this.lnlAssessment.Text = "New Assessment";
            this.lnlAssessment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnlAssessment_LinkClicked);
            // 
            // frmBenSchoolReadinessToolMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lnlAssessment);
            this.Name = "frmBenSchoolReadinessToolMain";
            this.Size = new System.Drawing.Size(720, 576);
            this.Load += new System.EventHandler(this.frmBenSchoolReadinessToolMain_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdvTrainingList)).EndInit();
            this.tlpDisplay01.ResumeLayout(false);
            this.tlpDisplay01.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.DataGridView gdvTrainingList;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay01;
        private System.Windows.Forms.ComboBox cboParish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboIP;
        private System.Windows.Forms.ComboBox cboSubCounty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDistrict;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboCso;
        private System.Windows.Forms.TextBox txtHHCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.LinkLabel lnlAssessment;
    }
}
