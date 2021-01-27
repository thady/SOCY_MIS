namespace SOCY_MIS
{
    partial class frmHouseholdTransferIssuesRegister
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHouseholdTransferIssuesRegister));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.txtissuename = new System.Windows.Forms.RichTextBox();
            this.txtissueaction = new System.Windows.Forms.RichTextBox();
            this.txtissuefollowup = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gdvList = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.lblid = new System.Windows.Forms.Label();
            this.btnNewRecord = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtissuefollowup);
            this.panel1.Controls.Add(this.txtissueaction);
            this.panel1.Controls.Add(this.txtissuename);
            this.panel1.Location = new System.Drawing.Point(12, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 266);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gdvList);
            this.panel2.Location = new System.Drawing.Point(1, 338);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(632, 238);
            this.panel2.TabIndex = 1;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.BackColor = System.Drawing.Color.Yellow;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(11, 0);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(413, 13);
            this.lblHeader.TabIndex = 129;
            this.lblHeader.Text = "Summary Of Issues In The Household That Require Immediate Attention";
            // 
            // txtissuename
            // 
            this.txtissuename.Location = new System.Drawing.Point(5, 16);
            this.txtissuename.Name = "txtissuename";
            this.txtissuename.Size = new System.Drawing.Size(613, 47);
            this.txtissuename.TabIndex = 0;
            this.txtissuename.Text = "";
            // 
            // txtissueaction
            // 
            this.txtissueaction.Location = new System.Drawing.Point(3, 82);
            this.txtissueaction.Name = "txtissueaction";
            this.txtissueaction.Size = new System.Drawing.Size(618, 77);
            this.txtissueaction.TabIndex = 1;
            this.txtissueaction.Text = "";
            // 
            // txtissuefollowup
            // 
            this.txtissuefollowup.Location = new System.Drawing.Point(3, 176);
            this.txtissuefollowup.Name = "txtissuefollowup";
            this.txtissuefollowup.Size = new System.Drawing.Size(618, 87);
            this.txtissuefollowup.TabIndex = 2;
            this.txtissuefollowup.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 130;
            this.label1.Text = "Issue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 13);
            this.label2.TabIndex = 131;
            this.label2.Text = "Action To Be Taken/in Process";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 13);
            this.label3.TabIndex = 132;
            this.label3.Text = "Any Other Information For Follow Up";
            // 
            // gdvList
            // 
            this.gdvList.AllowUserToAddRows = false;
            this.gdvList.AllowUserToDeleteRows = false;
            this.gdvList.AllowUserToResizeColumns = false;
            this.gdvList.AllowUserToResizeRows = false;
            this.gdvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvList.Location = new System.Drawing.Point(5, 2);
            this.gdvList.Margin = new System.Windows.Forms.Padding(2);
            this.gdvList.Name = "gdvList";
            this.gdvList.ReadOnly = true;
            this.gdvList.RowTemplate.Height = 24;
            this.gdvList.Size = new System.Drawing.Size(625, 234);
            this.gdvList.TabIndex = 107;
            this.gdvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvList_CellDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 322);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 13);
            this.label4.TabIndex = 130;
            this.label4.Text = "List of recorded houshold issues";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(197, 322);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 13);
            this.label5.TabIndex = 133;
            this.label5.Text = "Double Click to view details ";
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(532, 285);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(112, 28);
            this.btnsave.TabIndex = 134;
            this.btnsave.Text = "save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(9, 293);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(13, 13);
            this.lblid.TabIndex = 133;
            this.lblid.Text = "--";
            // 
            // btnNewRecord
            // 
            this.btnNewRecord.Location = new System.Drawing.Point(414, 285);
            this.btnNewRecord.Name = "btnNewRecord";
            this.btnNewRecord.Size = new System.Drawing.Size(112, 28);
            this.btnNewRecord.TabIndex = 135;
            this.btnNewRecord.Text = "New Record";
            this.btnNewRecord.UseVisualStyleBackColor = true;
            this.btnNewRecord.Click += new System.EventHandler(this.btnNewRecord_Click);
            // 
            // frmHouseholdTransferIssuesRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 579);
            this.Controls.Add(this.btnNewRecord);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHouseholdTransferIssuesRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHouseholdTransferIssuesRegister";
            this.Load += new System.EventHandler(this.frmHouseholdTransferIssuesRegister_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.RichTextBox txtissuefollowup;
        private System.Windows.Forms.RichTextBox txtissueaction;
        private System.Windows.Forms.RichTextBox txtissuename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gdvList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.Button btnNewRecord;
    }
}