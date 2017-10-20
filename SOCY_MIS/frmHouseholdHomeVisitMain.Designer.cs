namespace SOCY_MIS
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
            this.tcHomeVisit.Location = new System.Drawing.Point(0, 3);
            this.tcHomeVisit.Name = "tcHomeVisit";
            this.tcHomeVisit.SelectedIndex = 0;
            this.tcHomeVisit.Size = new System.Drawing.Size(907, 494);
            this.tcHomeVisit.TabIndex = 1;
            // 
            // tpHomeVisit
            // 
            this.tpHomeVisit.AutoScroll = true;
            this.tpHomeVisit.Location = new System.Drawing.Point(4, 22);
            this.tpHomeVisit.Name = "tpHomeVisit";
            this.tpHomeVisit.Padding = new System.Windows.Forms.Padding(3);
            this.tpHomeVisit.Size = new System.Drawing.Size(899, 468);
            this.tpHomeVisit.TabIndex = 0;
            this.tpHomeVisit.Text = "Home Visit";
            this.tpHomeVisit.UseVisualStyleBackColor = true;
            // 
            // tpMember
            // 
            this.tpMember.AutoScroll = true;
            this.tpMember.Location = new System.Drawing.Point(4, 22);
            this.tpMember.Name = "tpMember";
            this.tpMember.Padding = new System.Windows.Forms.Padding(3);
            this.tpMember.Size = new System.Drawing.Size(899, 468);
            this.tpMember.TabIndex = 1;
            this.tpMember.Text = "Household Members";
            this.tpMember.UseVisualStyleBackColor = true;
            // 
            // frmHouseholdHomeVisitMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tcHomeVisit);
            this.Name = "frmHouseholdHomeVisitMain";
            this.Size = new System.Drawing.Size(910, 500);
            this.Load += new System.EventHandler(this.frmHouseholdHomeVisitMain_Load);
            this.tcHomeVisit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcHomeVisit;
        private System.Windows.Forms.TabPage tpHomeVisit;
        private System.Windows.Forms.TabPage tpMember;
    }
}
