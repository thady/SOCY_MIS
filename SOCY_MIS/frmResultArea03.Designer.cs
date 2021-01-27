namespace SOCY_MIS
{
    partial class frmResultArea03
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
            this.llblCovid19DataCollection = new System.Windows.Forms.LinkLabel();
            this.llblArtRefill = new System.Windows.Forms.LinkLabel();
            this.llblServiceRegistration = new System.Windows.Forms.LinkLabel();
            this.llblReferrals = new System.Windows.Forms.LinkLabel();
            this.llblHomeVisits = new System.Windows.Forms.LinkLabel();
            this.llblHoseholdTransfer = new System.Windows.Forms.LinkLabel();
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
            this.gbArea.Size = new System.Drawing.Size(168, 213);
            this.gbArea.TabIndex = 4;
            this.gbArea.TabStop = false;
            this.gbArea.Text = "Areas";
            // 
            // tlpDisplay01
            // 
            this.tlpDisplay01.ColumnCount = 1;
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay01.Controls.Add(this.llblHoseholdTransfer, 0, 2);
            this.tlpDisplay01.Controls.Add(this.llblCovid19DataCollection, 0, 1);
            this.tlpDisplay01.Controls.Add(this.llblArtRefill, 0, 0);
            this.tlpDisplay01.Controls.Add(this.llblServiceRegistration, 0, 6);
            this.tlpDisplay01.Controls.Add(this.llblReferrals, 0, 5);
            this.tlpDisplay01.Controls.Add(this.llblHomeVisits, 0, 4);
            this.tlpDisplay01.Location = new System.Drawing.Point(6, 19);
            this.tlpDisplay01.Name = "tlpDisplay01";
            this.tlpDisplay01.RowCount = 7;
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.14286F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.71429F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.857143F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay01.Size = new System.Drawing.Size(156, 175);
            this.tlpDisplay01.TabIndex = 3;
            // 
            // llblCovid19DataCollection
            // 
            this.llblCovid19DataCollection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblCovid19DataCollection.AutoSize = true;
            this.llblCovid19DataCollection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblCovid19DataCollection.Location = new System.Drawing.Point(3, 30);
            this.llblCovid19DataCollection.Name = "llblCovid19DataCollection";
            this.llblCovid19DataCollection.Size = new System.Drawing.Size(146, 26);
            this.llblCovid19DataCollection.TabIndex = 6;
            this.llblCovid19DataCollection.TabStop = true;
            this.llblCovid19DataCollection.Text = "SOCY-Data Collection during Covid19";
            this.llblCovid19DataCollection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblCovid19DataCollection_LinkClicked);
            // 
            // llblArtRefill
            // 
            this.llblArtRefill.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblArtRefill.AutoSize = true;
            this.llblArtRefill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblArtRefill.Location = new System.Drawing.Point(3, 6);
            this.llblArtRefill.Name = "llblArtRefill";
            this.llblArtRefill.Size = new System.Drawing.Size(100, 13);
            this.llblArtRefill.TabIndex = 5;
            this.llblArtRefill.TabStop = true;
            this.llblArtRefill.Text = "ART Refill Tracking";
            this.llblArtRefill.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblArtRefill_LinkClicked);
            // 
            // llblServiceRegistration
            // 
            this.llblServiceRegistration.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblServiceRegistration.AutoSize = true;
            this.llblServiceRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblServiceRegistration.Location = new System.Drawing.Point(3, 155);
            this.llblServiceRegistration.Name = "llblServiceRegistration";
            this.llblServiceRegistration.Size = new System.Drawing.Size(102, 13);
            this.llblServiceRegistration.TabIndex = 3;
            this.llblServiceRegistration.TabStop = true;
            this.llblServiceRegistration.Text = "Service Registration";
            this.llblServiceRegistration.Visible = false;
            this.llblServiceRegistration.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblServiceRegistration_LinkClicked);
            // 
            // llblReferrals
            // 
            this.llblReferrals.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblReferrals.AutoSize = true;
            this.llblReferrals.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblReferrals.Location = new System.Drawing.Point(3, 129);
            this.llblReferrals.Name = "llblReferrals";
            this.llblReferrals.Size = new System.Drawing.Size(49, 13);
            this.llblReferrals.TabIndex = 1;
            this.llblReferrals.TabStop = true;
            this.llblReferrals.Text = "Referrals";
            this.llblReferrals.Visible = false;
            this.llblReferrals.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblReferrals_LinkClicked);
            // 
            // llblHomeVisits
            // 
            this.llblHomeVisits.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblHomeVisits.AutoSize = true;
            this.llblHomeVisits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblHomeVisits.Location = new System.Drawing.Point(3, 104);
            this.llblHomeVisits.Name = "llblHomeVisits";
            this.llblHomeVisits.Size = new System.Drawing.Size(62, 13);
            this.llblHomeVisits.TabIndex = 4;
            this.llblHomeVisits.TabStop = true;
            this.llblHomeVisits.Text = "Home Visits";
            this.llblHomeVisits.Visible = false;
            this.llblHomeVisits.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblHomeVisits_LinkClicked);
            // 
            // llblHoseholdTransfer
            // 
            this.llblHoseholdTransfer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblHoseholdTransfer.AutoSize = true;
            this.llblHoseholdTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblHoseholdTransfer.Location = new System.Drawing.Point(3, 67);
            this.llblHoseholdTransfer.Name = "llblHoseholdTransfer";
            this.llblHoseholdTransfer.Size = new System.Drawing.Size(124, 13);
            this.llblHoseholdTransfer.TabIndex = 7;
            this.llblHoseholdTransfer.TabStop = true;
            this.llblHoseholdTransfer.Text = "Household Transfer Tool";
            this.llblHoseholdTransfer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblHoseholdTransfer_LinkClicked);
            // 
            // frmResultArea03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlPlaceHolder);
            this.Controls.Add(this.gbArea);
            this.Name = "frmResultArea03";
            this.Size = new System.Drawing.Size(910, 520);
            this.gbArea.ResumeLayout(false);
            this.tlpDisplay01.ResumeLayout(false);
            this.tlpDisplay01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPlaceHolder;
        private System.Windows.Forms.GroupBox gbArea;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay01;
        private System.Windows.Forms.LinkLabel llblReferrals;
        private System.Windows.Forms.LinkLabel llblServiceRegistration;
        private System.Windows.Forms.LinkLabel llblHomeVisits;
        private System.Windows.Forms.LinkLabel llblArtRefill;
        private System.Windows.Forms.LinkLabel llblCovid19DataCollection;
        private System.Windows.Forms.LinkLabel llblHoseholdTransfer;
    }
}
