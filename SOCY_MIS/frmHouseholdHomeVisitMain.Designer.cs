﻿namespace SOCY_MIS
{
    partial class frmHouseholdHomeVisitMain
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
            this.tcHomeVisit = new System.Windows.Forms.TabControl();
            this.tpHomeVisit = new System.Windows.Forms.TabPage();
            this.tpMember = new System.Windows.Forms.TabPage();
            this.tpHomevisitMember = new System.Windows.Forms.TabPage();
            this.tcHomeVisit.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcHomeVisit
            // 
            this.tcHomeVisit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcHomeVisit.Controls.Add(this.tpHomeVisit);
            this.tcHomeVisit.Controls.Add(this.tpMember);
            this.tcHomeVisit.Controls.Add(this.tpHomevisitMember);
            this.tcHomeVisit.Location = new System.Drawing.Point(0, 4);
            this.tcHomeVisit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tcHomeVisit.Name = "tcHomeVisit";
            this.tcHomeVisit.SelectedIndex = 0;
            this.tcHomeVisit.Size = new System.Drawing.Size(1209, 608);
            this.tcHomeVisit.TabIndex = 1;
            // 
            // tpHomeVisit
            // 
            this.tpHomeVisit.AutoScroll = true;
            this.tpHomeVisit.Location = new System.Drawing.Point(4, 25);
            this.tpHomeVisit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpHomeVisit.Name = "tpHomeVisit";
            this.tpHomeVisit.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpHomeVisit.Size = new System.Drawing.Size(1201, 579);
            this.tpHomeVisit.TabIndex = 0;
            this.tpHomeVisit.Text = "Home Visit";
            this.tpHomeVisit.UseVisualStyleBackColor = true;
            this.tpHomeVisit.Click += new System.EventHandler(this.tpHomeVisit_Click);
            // 
            // tpMember
            // 
            this.tpMember.AutoScroll = true;
            this.tpMember.Location = new System.Drawing.Point(4, 25);
            this.tpMember.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpMember.Name = "tpMember";
            this.tpMember.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpMember.Size = new System.Drawing.Size(1201, 579);
            this.tpMember.TabIndex = 1;
            this.tpMember.Text = "Household Members";
            this.tpMember.UseVisualStyleBackColor = true;
            // 
            // tpHomevisitMember
            // 
            this.tpHomevisitMember.AutoScroll = true;
            this.tpHomevisitMember.Location = new System.Drawing.Point(4, 25);
            this.tpHomevisitMember.Name = "tpHomevisitMember";
            this.tpHomevisitMember.Size = new System.Drawing.Size(1201, 579);
            this.tpHomevisitMember.TabIndex = 2;
            this.tpHomevisitMember.Text = "Home Visit Member Services";
            this.tpHomevisitMember.UseVisualStyleBackColor = true;
            this.tpHomevisitMember.Click += new System.EventHandler(this.tbHomevisitMember_Click);
            // 
            // frmHouseholdHomeVisitMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tcHomeVisit);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmHouseholdHomeVisitMain";
            this.Size = new System.Drawing.Size(1213, 615);
            this.Load += new System.EventHandler(this.frmHouseholdHomeVisitMain_Load);
            this.tcHomeVisit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcHomeVisit;
        private System.Windows.Forms.TabPage tpHomeVisit;
        private System.Windows.Forms.TabPage tpMember;
        private System.Windows.Forms.TabPage tpHomevisitMember;
    }
}
