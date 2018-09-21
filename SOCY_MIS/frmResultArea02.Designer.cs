namespace SOCY_MIS
{
    partial class frmResultArea02
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
            this.pnlPlaceHolder = new System.Windows.Forms.Panel();
            this.gbArea = new System.Windows.Forms.GroupBox();
            this.tlpDisplay01 = new System.Windows.Forms.TableLayoutPanel();
            this.llblCBSDResourceAllocation = new System.Windows.Forms.LinkLabel();
            this.llblAlternativeCare = new System.Windows.Forms.LinkLabel();
            this.llblCBSDStaffAppraisalTracking = new System.Windows.Forms.LinkLabel();
            this.llblOVCChecklist = new System.Windows.Forms.LinkLabel();
            this.llblInstitutionalCareSummary = new System.Windows.Forms.LinkLabel();
            this.llblSOVCChecklist = new System.Windows.Forms.LinkLabel();
            this.gbArea.SuspendLayout();
            this.tlpDisplay01.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPlaceHolder
            // 
            this.pnlPlaceHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPlaceHolder.AutoScroll = true;
            this.pnlPlaceHolder.BackColor = System.Drawing.Color.White;
            this.pnlPlaceHolder.Location = new System.Drawing.Point(177, 4);
            this.pnlPlaceHolder.Name = "pnlPlaceHolder";
            this.pnlPlaceHolder.Size = new System.Drawing.Size(730, 513);
            this.pnlPlaceHolder.TabIndex = 5;
            // 
            // gbArea
            // 
            this.gbArea.Controls.Add(this.tlpDisplay01);
            this.gbArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbArea.Location = new System.Drawing.Point(3, 6);
            this.gbArea.Name = "gbArea";
            this.gbArea.Size = new System.Drawing.Size(168, 333);
            this.gbArea.TabIndex = 4;
            this.gbArea.TabStop = false;
            this.gbArea.Text = "Areas";
            // 
            // tlpDisplay01
            // 
            this.tlpDisplay01.ColumnCount = 1;
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay01.Controls.Add(this.llblSOVCChecklist, 0, 4);
            this.tlpDisplay01.Controls.Add(this.llblCBSDResourceAllocation, 0, 1);
            this.tlpDisplay01.Controls.Add(this.llblAlternativeCare, 0, 0);
            this.tlpDisplay01.Controls.Add(this.llblCBSDStaffAppraisalTracking, 0, 2);
            this.tlpDisplay01.Controls.Add(this.llblOVCChecklist, 0, 3);
            this.tlpDisplay01.Controls.Add(this.llblInstitutionalCareSummary, 0, 5);
            this.tlpDisplay01.Location = new System.Drawing.Point(6, 19);
            this.tlpDisplay01.Name = "tlpDisplay01";
            this.tlpDisplay01.RowCount = 6;
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay01.Size = new System.Drawing.Size(156, 180);
            this.tlpDisplay01.TabIndex = 3;
            // 
            // llblCBSDResourceAllocation
            // 
            this.llblCBSDResourceAllocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblCBSDResourceAllocation.AutoSize = true;
            this.llblCBSDResourceAllocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblCBSDResourceAllocation.Location = new System.Drawing.Point(3, 37);
            this.llblCBSDResourceAllocation.Name = "llblCBSDResourceAllocation";
            this.llblCBSDResourceAllocation.Size = new System.Drawing.Size(134, 13);
            this.llblCBSDResourceAllocation.TabIndex = 1;
            this.llblCBSDResourceAllocation.TabStop = true;
            this.llblCBSDResourceAllocation.Text = "CBSD Resource Allocation";
            this.llblCBSDResourceAllocation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblCBSDResourceAllocation_LinkClicked);
            // 
            // llblAlternativeCare
            // 
            this.llblAlternativeCare.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblAlternativeCare.AutoSize = true;
            this.llblAlternativeCare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblAlternativeCare.Location = new System.Drawing.Point(3, 1);
            this.llblAlternativeCare.Name = "llblAlternativeCare";
            this.llblAlternativeCare.Size = new System.Drawing.Size(115, 26);
            this.llblAlternativeCare.TabIndex = 0;
            this.llblAlternativeCare.TabStop = true;
            this.llblAlternativeCare.Text = "Alternative Care Panel Summary";
            this.llblAlternativeCare.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblAlternativeCare_LinkClicked);
            // 
            // llblCBSDStaffAppraisalTracking
            // 
            this.llblCBSDStaffAppraisalTracking.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblCBSDStaffAppraisalTracking.AutoSize = true;
            this.llblCBSDStaffAppraisalTracking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblCBSDStaffAppraisalTracking.Location = new System.Drawing.Point(3, 59);
            this.llblCBSDStaffAppraisalTracking.Name = "llblCBSDStaffAppraisalTracking";
            this.llblCBSDStaffAppraisalTracking.Size = new System.Drawing.Size(131, 26);
            this.llblCBSDStaffAppraisalTracking.TabIndex = 2;
            this.llblCBSDStaffAppraisalTracking.TabStop = true;
            this.llblCBSDStaffAppraisalTracking.Text = "CBSD Staff and Appraisal Tracking";
            this.llblCBSDStaffAppraisalTracking.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblCBSDStaffAppraisalTracking_LinkClicked);
            // 
            // llblOVCChecklist
            // 
            this.llblOVCChecklist.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblOVCChecklist.AutoSize = true;
            this.llblOVCChecklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblOVCChecklist.Location = new System.Drawing.Point(3, 88);
            this.llblOVCChecklist.Name = "llblOVCChecklist";
            this.llblOVCChecklist.Size = new System.Drawing.Size(135, 26);
            this.llblOVCChecklist.TabIndex = 3;
            this.llblOVCChecklist.TabStop = true;
            this.llblOVCChecklist.Text = "District OVC Coordination OVC Data Usage Checklist";
            this.llblOVCChecklist.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblOVCChecklist_LinkClicked);
            // 
            // llblInstitutionalCareSummary
            // 
            this.llblInstitutionalCareSummary.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblInstitutionalCareSummary.AutoSize = true;
            this.llblInstitutionalCareSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblInstitutionalCareSummary.Location = new System.Drawing.Point(3, 156);
            this.llblInstitutionalCareSummary.Name = "llblInstitutionalCareSummary";
            this.llblInstitutionalCareSummary.Size = new System.Drawing.Size(147, 13);
            this.llblInstitutionalCareSummary.TabIndex = 4;
            this.llblInstitutionalCareSummary.TabStop = true;
            this.llblInstitutionalCareSummary.Text = "Re-Intergration Summary Tool";
            this.llblInstitutionalCareSummary.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblInstitutionalCareSummary_LinkClicked);
            // 
            // llblSOVCChecklist
            // 
            this.llblSOVCChecklist.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblSOVCChecklist.AutoSize = true;
            this.llblSOVCChecklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblSOVCChecklist.Location = new System.Drawing.Point(3, 117);
            this.llblSOVCChecklist.Name = "llblSOVCChecklist";
            this.llblSOVCChecklist.Size = new System.Drawing.Size(149, 26);
            this.llblSOVCChecklist.TabIndex = 5;
            this.llblSOVCChecklist.TabStop = true;
            this.llblSOVCChecklist.Text = "Sub County OVC Coordination OVC Data Usage Checklist";
            this.llblSOVCChecklist.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblSOVCChecklist_LinkClicked);
            // 
            // frmResultArea02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlPlaceHolder);
            this.Controls.Add(this.gbArea);
            this.Name = "frmResultArea02";
            this.Size = new System.Drawing.Size(910, 520);
            this.Load += new System.EventHandler(this.frmResultArea02_Load);
            this.gbArea.ResumeLayout(false);
            this.tlpDisplay01.ResumeLayout(false);
            this.tlpDisplay01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPlaceHolder;
        private System.Windows.Forms.GroupBox gbArea;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay01;
        private System.Windows.Forms.LinkLabel llblAlternativeCare;
        private System.Windows.Forms.LinkLabel llblCBSDResourceAllocation;
        private System.Windows.Forms.LinkLabel llblCBSDStaffAppraisalTracking;
        private System.Windows.Forms.LinkLabel llblOVCChecklist;
        private System.Windows.Forms.LinkLabel llblInstitutionalCareSummary;
        private System.Windows.Forms.LinkLabel llblSOVCChecklist;
    }
}
