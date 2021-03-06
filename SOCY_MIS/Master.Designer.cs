﻿namespace SOCY_MIS
{
    partial class Master
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Master));
            this.lblVersionNumber = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.mnMain = new System.Windows.Forms.MenuStrip();
            this.miHome = new System.Windows.Forms.ToolStripMenuItem();
            this.miSocialWorker = new System.Windows.Forms.ToolStripMenuItem();
            this.miHousehold = new System.Windows.Forms.ToolStripMenuItem();
            this.miResultArea01 = new System.Windows.Forms.ToolStripMenuItem();
            this.miResultArea02 = new System.Windows.Forms.ToolStripMenuItem();
            this.miResultArea03 = new System.Windows.Forms.ToolStripMenuItem();
            this.miSILC = new System.Windows.Forms.ToolStripMenuItem();
            this.miDREAMS = new System.Windows.Forms.ToolStripMenuItem();
            this.miEducationSubsidy = new System.Windows.Forms.ToolStripMenuItem();
            this.miReports = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlLinks = new System.Windows.Forms.Panel();
            this.llblLogOut = new System.Windows.Forms.LinkLabel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlPlaceHolder = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.mnMain.SuspendLayout();
            this.pnlLinks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVersionNumber
            // 
            this.lblVersionNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersionNumber.AutoSize = true;
            this.lblVersionNumber.Location = new System.Drawing.Point(1193, 9);
            this.lblVersionNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersionNumber.Name = "lblVersionNumber";
            this.lblVersionNumber.Size = new System.Drawing.Size(28, 17);
            this.lblVersionNumber.TabIndex = 22;
            this.lblVersionNumber.Text = "1.0";
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(1139, 9);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(60, 17);
            this.lblVersion.TabIndex = 21;
            this.lblVersion.Text = "Version:";
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMenu.Controls.Add(this.mnMain);
            this.pnlMenu.Location = new System.Drawing.Point(9, 113);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1227, 37);
            this.pnlMenu.TabIndex = 25;
            // 
            // mnMain
            // 
            this.mnMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHome,
            this.miSocialWorker,
            this.miHousehold,
            this.miResultArea01,
            this.miResultArea02,
            this.miResultArea03,
            this.miSILC,
            this.miDREAMS,
            this.miEducationSubsidy,
            this.miReports,
            this.miAdmin});
            this.mnMain.Location = new System.Drawing.Point(0, 0);
            this.mnMain.Name = "mnMain";
            this.mnMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mnMain.Size = new System.Drawing.Size(1227, 28);
            this.mnMain.TabIndex = 2;
            this.mnMain.Text = "menuStrip1";
            // 
            // miHome
            // 
            this.miHome.Name = "miHome";
            this.miHome.Size = new System.Drawing.Size(62, 24);
            this.miHome.Text = "Home";
            this.miHome.Click += new System.EventHandler(this.miHome_Click);
            // 
            // miSocialWorker
            // 
            this.miSocialWorker.Name = "miSocialWorker";
            this.miSocialWorker.Size = new System.Drawing.Size(118, 24);
            this.miSocialWorker.Text = "Social Workers";
            this.miSocialWorker.Click += new System.EventHandler(this.miSocialWorker_Click);
            // 
            // miHousehold
            // 
            this.miHousehold.Name = "miHousehold";
            this.miHousehold.Size = new System.Drawing.Size(99, 24);
            this.miHousehold.Text = "Households";
            this.miHousehold.Click += new System.EventHandler(this.miHousehold_Click);
            // 
            // miResultArea01
            // 
            this.miResultArea01.Name = "miResultArea01";
            this.miResultArea01.Size = new System.Drawing.Size(116, 24);
            this.miResultArea01.Text = "Result Area 01";
            this.miResultArea01.Click += new System.EventHandler(this.miResultArea01_Click);
            // 
            // miResultArea02
            // 
            this.miResultArea02.Name = "miResultArea02";
            this.miResultArea02.Size = new System.Drawing.Size(116, 24);
            this.miResultArea02.Text = "Result Area 02";
            this.miResultArea02.Click += new System.EventHandler(this.miResultArea02_Click);
            // 
            // miResultArea03
            // 
            this.miResultArea03.Name = "miResultArea03";
            this.miResultArea03.Size = new System.Drawing.Size(116, 24);
            this.miResultArea03.Text = "Result Area 03";
            this.miResultArea03.Click += new System.EventHandler(this.miResultArea03_Click);
            // 
            // miSILC
            // 
            this.miSILC.Name = "miSILC";
            this.miSILC.Size = new System.Drawing.Size(140, 24);
            this.miSILC.Text = "SILC Management";
            this.miSILC.Click += new System.EventHandler(this.miSILC_Click);
            // 
            // miDREAMS
            // 
            this.miDREAMS.Name = "miDREAMS";
            this.miDREAMS.Size = new System.Drawing.Size(80, 24);
            this.miDREAMS.Text = "DREAMS";
            this.miDREAMS.Click += new System.EventHandler(this.miDREAMS_Click);
            // 
            // miEducationSubsidy
            // 
            this.miEducationSubsidy.Name = "miEducationSubsidy";
            this.miEducationSubsidy.Size = new System.Drawing.Size(142, 24);
            this.miEducationSubsidy.Text = "Education Subsidy";
            this.miEducationSubsidy.Click += new System.EventHandler(this.miEducationSubsidy_Click);
            // 
            // miReports
            // 
            this.miReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1});
            this.miReports.Name = "miReports";
            this.miReports.Size = new System.Drawing.Size(112, 24);
            this.miReports.Text = "No Means No";
            this.miReports.Click += new System.EventHandler(this.miReports_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(63, 6);
            // 
            // miAdmin
            // 
            this.miAdmin.Name = "miAdmin";
            this.miAdmin.Size = new System.Drawing.Size(65, 24);
            this.miAdmin.Text = "Admin";
            this.miAdmin.Click += new System.EventHandler(this.miAdmin_Click);
            // 
            // pnlLinks
            // 
            this.pnlLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLinks.Controls.Add(this.llblLogOut);
            this.pnlLinks.Location = new System.Drawing.Point(733, 28);
            this.pnlLinks.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLinks.Name = "pnlLinks";
            this.pnlLinks.Size = new System.Drawing.Size(499, 34);
            this.pnlLinks.TabIndex = 26;
            // 
            // llblLogOut
            // 
            this.llblLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblLogOut.AutoSize = true;
            this.llblLogOut.Location = new System.Drawing.Point(435, 12);
            this.llblLogOut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblLogOut.Name = "llblLogOut";
            this.llblLogOut.Size = new System.Drawing.Size(56, 17);
            this.llblLogOut.TabIndex = 0;
            this.llblLogOut.TabStop = true;
            this.llblLogOut.Text = "Log out";
            this.llblLogOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblLogOut_LinkClicked);
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::SOCY_MIS.Properties.Resources.Logo;
            this.pbLogo.Location = new System.Drawing.Point(47, 9);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(333, 98);
            this.pbLogo.TabIndex = 27;
            this.pbLogo.TabStop = false;
            // 
            // pnlPlaceHolder
            // 
            this.pnlPlaceHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPlaceHolder.AutoScroll = true;
            this.pnlPlaceHolder.Location = new System.Drawing.Point(9, 151);
            this.pnlPlaceHolder.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPlaceHolder.Name = "pnlPlaceHolder";
            this.pnlPlaceHolder.Size = new System.Drawing.Size(1227, 569);
            this.pnlPlaceHolder.TabIndex = 2;
            // 
            // Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1245, 721);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.pnlLinks);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.lblVersionNumber);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.pnlPlaceHolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1061, 728);
            this.Name = "Master";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SOCY MIS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Master_FormClosed);
            this.Load += new System.EventHandler(this.Master_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.mnMain.ResumeLayout(false);
            this.mnMain.PerformLayout();
            this.pnlLinks.ResumeLayout(false);
            this.pnlLinks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblVersionNumber;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlLinks;
        private System.Windows.Forms.LinkLabel llblLogOut;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.MenuStrip mnMain;
        private System.Windows.Forms.ToolStripMenuItem miHome;
        private System.Windows.Forms.ToolStripMenuItem miSocialWorker;
        private System.Windows.Forms.ToolStripMenuItem miHousehold;
        private System.Windows.Forms.ToolStripMenuItem miResultArea01;
        private System.Windows.Forms.ToolStripMenuItem miResultArea02;
        private System.Windows.Forms.ToolStripMenuItem miResultArea03;
        private System.Windows.Forms.ToolStripMenuItem miReports;
        private System.Windows.Forms.ToolStripMenuItem miAdmin;
        private System.Windows.Forms.ToolStripMenuItem miSILC;
        private System.Windows.Forms.ToolStripMenuItem miDREAMS;
        private System.Windows.Forms.ToolStripMenuItem miEducationSubsidy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel pnlPlaceHolder;
    }
}

