﻿namespace SOCY_MIS
{
    partial class frmHouseholdAssessmentMain
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
            this.tcHouseholdAssessment = new System.Windows.Forms.TabControl();
            this.tpAssessment = new System.Windows.Forms.TabPage();
            this.tpMember = new System.Windows.Forms.TabPage();
            this.tcHouseholdAssessment.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcHouseholdAssessment
            // 
            this.tcHouseholdAssessment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcHouseholdAssessment.Controls.Add(this.tpAssessment);
            this.tcHouseholdAssessment.Controls.Add(this.tpMember);
            this.tcHouseholdAssessment.Location = new System.Drawing.Point(0, 4);
            this.tcHouseholdAssessment.Margin = new System.Windows.Forms.Padding(4);
            this.tcHouseholdAssessment.Name = "tcHouseholdAssessment";
            this.tcHouseholdAssessment.SelectedIndex = 0;
            this.tcHouseholdAssessment.Size = new System.Drawing.Size(1209, 608);
            this.tcHouseholdAssessment.TabIndex = 0;
            // 
            // tpAssessment
            // 
            this.tpAssessment.AutoScroll = true;
            this.tpAssessment.Location = new System.Drawing.Point(4, 25);
            this.tpAssessment.Margin = new System.Windows.Forms.Padding(4);
            this.tpAssessment.Name = "tpAssessment";
            this.tpAssessment.Padding = new System.Windows.Forms.Padding(4);
            this.tpAssessment.Size = new System.Drawing.Size(1201, 579);
            this.tpAssessment.TabIndex = 0;
            this.tpAssessment.Text = "Household Assessment";
            this.tpAssessment.UseVisualStyleBackColor = true;
            this.tpAssessment.Click += new System.EventHandler(this.tpAssessment_Click);
            // 
            // tpMember
            // 
            this.tpMember.AutoScroll = true;
            this.tpMember.Location = new System.Drawing.Point(4, 25);
            this.tpMember.Margin = new System.Windows.Forms.Padding(4);
            this.tpMember.Name = "tpMember";
            this.tpMember.Padding = new System.Windows.Forms.Padding(4);
            this.tpMember.Size = new System.Drawing.Size(1201, 579);
            this.tpMember.TabIndex = 1;
            this.tpMember.Text = "Household Members";
            this.tpMember.UseVisualStyleBackColor = true;
            // 
            // frmHouseholdAssessmentMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tcHouseholdAssessment);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHouseholdAssessmentMain";
            this.Size = new System.Drawing.Size(1213, 615);
            this.Load += new System.EventHandler(this.frmHouseholdAssessmentMain_Load);
            this.tcHouseholdAssessment.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcHouseholdAssessment;
        private System.Windows.Forms.TabPage tpAssessment;
        private System.Windows.Forms.TabPage tpMember;
    }
}
