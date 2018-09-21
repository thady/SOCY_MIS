namespace SOCY_MIS
{
    partial class frmEducationSubsidyMain
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
            this.lnlbenreadiness = new System.Windows.Forms.LinkLabel();
            this.llblEducationSubsidy = new System.Windows.Forms.LinkLabel();
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
            this.pnlPlaceHolder.Location = new System.Drawing.Point(236, 5);
            this.pnlPlaceHolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlPlaceHolder.Name = "pnlPlaceHolder";
            this.pnlPlaceHolder.Size = new System.Drawing.Size(973, 631);
            this.pnlPlaceHolder.TabIndex = 6;
            // 
            // gbArea
            // 
            this.gbArea.Controls.Add(this.tlpDisplay01);
            this.gbArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbArea.Location = new System.Drawing.Point(4, 7);
            this.gbArea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbArea.Name = "gbArea";
            this.gbArea.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbArea.Size = new System.Drawing.Size(224, 116);
            this.gbArea.TabIndex = 5;
            this.gbArea.TabStop = false;
            this.gbArea.Text = "Education Subsidy";
            // 
            // tlpDisplay01
            // 
            this.tlpDisplay01.ColumnCount = 1;
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay01.Controls.Add(this.lnlbenreadiness, 0, 0);
            this.tlpDisplay01.Controls.Add(this.llblEducationSubsidy, 0, 1);
            this.tlpDisplay01.Location = new System.Drawing.Point(5, 23);
            this.tlpDisplay01.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpDisplay01.Name = "tlpDisplay01";
            this.tlpDisplay01.RowCount = 2;
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.63636F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.45455F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpDisplay01.Size = new System.Drawing.Size(216, 80);
            this.tlpDisplay01.TabIndex = 3;
            // 
            // lnlbenreadiness
            // 
            this.lnlbenreadiness.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lnlbenreadiness.AutoSize = true;
            this.lnlbenreadiness.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnlbenreadiness.Location = new System.Drawing.Point(4, 2);
            this.lnlbenreadiness.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnlbenreadiness.Name = "lnlbenreadiness";
            this.lnlbenreadiness.Size = new System.Drawing.Size(193, 34);
            this.lnlbenreadiness.TabIndex = 6;
            this.lnlbenreadiness.TabStop = true;
            this.lnlbenreadiness.Text = "Beneficiary school readiness assessment tool";
            this.lnlbenreadiness.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnlbenreadiness_LinkClicked);
            // 
            // llblEducationSubsidy
            // 
            this.llblEducationSubsidy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblEducationSubsidy.AutoSize = true;
            this.llblEducationSubsidy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblEducationSubsidy.Location = new System.Drawing.Point(4, 42);
            this.llblEducationSubsidy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblEducationSubsidy.Name = "llblEducationSubsidy";
            this.llblEducationSubsidy.Size = new System.Drawing.Size(205, 34);
            this.llblEducationSubsidy.TabIndex = 5;
            this.llblEducationSubsidy.TabStop = true;
            this.llblEducationSubsidy.Text = "Education Subsidy Assessment Tool";
            this.llblEducationSubsidy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblEducationSubsidy_LinkClicked);
            // 
            // frmEducationSubsidyMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPlaceHolder);
            this.Controls.Add(this.gbArea);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmEducationSubsidyMain";
            this.Size = new System.Drawing.Size(1213, 640);
            this.Load += new System.EventHandler(this.frmEducationSubsidyMain_Load);
            this.gbArea.ResumeLayout(false);
            this.tlpDisplay01.ResumeLayout(false);
            this.tlpDisplay01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPlaceHolder;
        private System.Windows.Forms.GroupBox gbArea;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay01;
        private System.Windows.Forms.LinkLabel llblEducationSubsidy;
        private System.Windows.Forms.LinkLabel lnlbenreadiness;
    }
}
