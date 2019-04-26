namespace SOCY_MIS
{
    partial class frmHouseholdRiskAssessmentMain
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
            this.tcRiskAssessment = new System.Windows.Forms.TabControl();
            this.tpHouseholdRiskAssessment = new System.Windows.Forms.TabPage();
            this.tpMemberChild = new System.Windows.Forms.TabPage();
            this.tpMemberAdult = new System.Windows.Forms.TabPage();
            this.tcRiskAssessment.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcRiskAssessment
            // 
            this.tcRiskAssessment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcRiskAssessment.Controls.Add(this.tpHouseholdRiskAssessment);
            this.tcRiskAssessment.Controls.Add(this.tpMemberChild);
            this.tcRiskAssessment.Controls.Add(this.tpMemberAdult);
            this.tcRiskAssessment.Location = new System.Drawing.Point(8, 8);
            this.tcRiskAssessment.Name = "tcRiskAssessment";
            this.tcRiskAssessment.SelectedIndex = 0;
            this.tcRiskAssessment.Size = new System.Drawing.Size(896, 483);
            this.tcRiskAssessment.TabIndex = 3;
            // 
            // tpHouseholdRiskAssessment
            // 
            this.tpHouseholdRiskAssessment.AutoScroll = true;
            this.tpHouseholdRiskAssessment.Location = new System.Drawing.Point(4, 22);
            this.tpHouseholdRiskAssessment.Name = "tpHouseholdRiskAssessment";
            this.tpHouseholdRiskAssessment.Padding = new System.Windows.Forms.Padding(3);
            this.tpHouseholdRiskAssessment.Size = new System.Drawing.Size(888, 457);
            this.tpHouseholdRiskAssessment.TabIndex = 0;
            this.tpHouseholdRiskAssessment.Text = "Household Risk Assessment";
            this.tpHouseholdRiskAssessment.UseVisualStyleBackColor = true;
            // 
            // tpMemberChild
            // 
            this.tpMemberChild.AutoScroll = true;
            this.tpMemberChild.Location = new System.Drawing.Point(4, 22);
            this.tpMemberChild.Name = "tpMemberChild";
            this.tpMemberChild.Padding = new System.Windows.Forms.Padding(3);
            this.tpMemberChild.Size = new System.Drawing.Size(888, 457);
            this.tpMemberChild.TabIndex = 1;
            this.tpMemberChild.Text = "Risk Assessment for Children";
            this.tpMemberChild.UseVisualStyleBackColor = true;
            // 
            // tpMemberAdult
            // 
            this.tpMemberAdult.AutoScroll = true;
            this.tpMemberAdult.Location = new System.Drawing.Point(4, 22);
            this.tpMemberAdult.Name = "tpMemberAdult";
            this.tpMemberAdult.Size = new System.Drawing.Size(888, 457);
            this.tpMemberAdult.TabIndex = 2;
            this.tpMemberAdult.Text = "Risk Assessment for Adults";
            this.tpMemberAdult.UseVisualStyleBackColor = true;
            // 
            // frmHouseholdRiskAssessmentMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcRiskAssessment);
            this.Name = "frmHouseholdRiskAssessmentMain";
            this.Size = new System.Drawing.Size(907, 494);
            this.Load += new System.EventHandler(this.frmHouseholdRiskAssessmentMain_Load);
            this.tcRiskAssessment.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcRiskAssessment;
        private System.Windows.Forms.TabPage tpHouseholdRiskAssessment;
        private System.Windows.Forms.TabPage tpMemberChild;
        private System.Windows.Forms.TabPage tpMemberAdult;
    }
}
