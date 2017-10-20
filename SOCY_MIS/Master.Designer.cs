namespace SOCY_MIS
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
            this.pnlPlaceHolder = new System.Windows.Forms.Panel();
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
            this.miReports = new System.Windows.Forms.ToolStripMenuItem();
            this.miAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlLinks = new System.Windows.Forms.Panel();
            this.llblLogOut = new System.Windows.Forms.LinkLabel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.miDREAMS = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMenu.SuspendLayout();
            this.mnMain.SuspendLayout();
            this.pnlLinks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPlaceHolder
            // 
            this.pnlPlaceHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPlaceHolder.AutoScroll = true;
            this.pnlPlaceHolder.Location = new System.Drawing.Point(7, 123);
            this.pnlPlaceHolder.Name = "pnlPlaceHolder";
            this.pnlPlaceHolder.Size = new System.Drawing.Size(920, 530);
            this.pnlPlaceHolder.TabIndex = 2;
            // 
            // lblVersionNumber
            // 
            this.lblVersionNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersionNumber.AutoSize = true;
            this.lblVersionNumber.Location = new System.Drawing.Point(895, 7);
            this.lblVersionNumber.Name = "lblVersionNumber";
            this.lblVersionNumber.Size = new System.Drawing.Size(22, 13);
            this.lblVersionNumber.TabIndex = 22;
            this.lblVersionNumber.Text = "1.0";
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(854, 7);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(45, 13);
            this.lblVersion.TabIndex = 21;
            this.lblVersion.Text = "Version:";
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMenu.Controls.Add(this.mnMain);
            this.pnlMenu.Location = new System.Drawing.Point(7, 92);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(920, 30);
            this.pnlMenu.TabIndex = 25;
            // 
            // mnMain
            // 
            this.mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHome,
            this.miSocialWorker,
            this.miHousehold,
            this.miResultArea01,
            this.miResultArea02,
            this.miResultArea03,
            this.miSILC,
            this.miDREAMS,
            this.miReports,
            this.miAdmin});
            this.mnMain.Location = new System.Drawing.Point(0, 0);
            this.mnMain.Name = "mnMain";
            this.mnMain.Size = new System.Drawing.Size(920, 24);
            this.mnMain.TabIndex = 2;
            this.mnMain.Text = "menuStrip1";
            // 
            // miHome
            // 
            this.miHome.Name = "miHome";
            this.miHome.Size = new System.Drawing.Size(52, 20);
            this.miHome.Text = "Home";
            this.miHome.Click += new System.EventHandler(this.miHome_Click);
            // 
            // miSocialWorker
            // 
            this.miSocialWorker.Name = "miSocialWorker";
            this.miSocialWorker.Size = new System.Drawing.Size(96, 20);
            this.miSocialWorker.Text = "Social Workers";
            this.miSocialWorker.Click += new System.EventHandler(this.miSocialWorker_Click);
            // 
            // miHousehold
            // 
            this.miHousehold.Name = "miHousehold";
            this.miHousehold.Size = new System.Drawing.Size(82, 20);
            this.miHousehold.Text = "Households";
            this.miHousehold.Click += new System.EventHandler(this.miHousehold_Click);
            // 
            // miResultArea01
            // 
            this.miResultArea01.Name = "miResultArea01";
            this.miResultArea01.Size = new System.Drawing.Size(93, 20);
            this.miResultArea01.Text = "Result Area 01";
            this.miResultArea01.Click += new System.EventHandler(this.miResultArea01_Click);
            // 
            // miResultArea02
            // 
            this.miResultArea02.Name = "miResultArea02";
            this.miResultArea02.Size = new System.Drawing.Size(93, 20);
            this.miResultArea02.Text = "Result Area 02";
            this.miResultArea02.Click += new System.EventHandler(this.miResultArea02_Click);
            // 
            // miResultArea03
            // 
            this.miResultArea03.Name = "miResultArea03";
            this.miResultArea03.Size = new System.Drawing.Size(93, 20);
            this.miResultArea03.Text = "Result Area 03";
            this.miResultArea03.Visible = false;
            this.miResultArea03.Click += new System.EventHandler(this.miResultArea03_Click);
            // 
            // miSILC
            // 
            this.miSILC.Name = "miSILC";
            this.miSILC.Size = new System.Drawing.Size(116, 20);
            this.miSILC.Text = "SILC Management";
            this.miSILC.Click += new System.EventHandler(this.miSILC_Click);
            // 
            // miReports
            // 
            this.miReports.Enabled = false;
            this.miReports.Name = "miReports";
            this.miReports.Size = new System.Drawing.Size(59, 20);
            this.miReports.Text = "Reports";
            this.miReports.Visible = false;
            // 
            // miAdmin
            // 
            this.miAdmin.Name = "miAdmin";
            this.miAdmin.Size = new System.Drawing.Size(55, 20);
            this.miAdmin.Text = "Admin";
            this.miAdmin.Click += new System.EventHandler(this.miAdmin_Click);
            // 
            // pnlLinks
            // 
            this.pnlLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLinks.Controls.Add(this.llblLogOut);
            this.pnlLinks.Location = new System.Drawing.Point(550, 23);
            this.pnlLinks.Name = "pnlLinks";
            this.pnlLinks.Size = new System.Drawing.Size(374, 28);
            this.pnlLinks.TabIndex = 26;
            // 
            // llblLogOut
            // 
            this.llblLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblLogOut.AutoSize = true;
            this.llblLogOut.Location = new System.Drawing.Point(326, 10);
            this.llblLogOut.Name = "llblLogOut";
            this.llblLogOut.Size = new System.Drawing.Size(43, 13);
            this.llblLogOut.TabIndex = 0;
            this.llblLogOut.TabStop = true;
            this.llblLogOut.Text = "Log out";
            this.llblLogOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblLogOut_LinkClicked);
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::SOCY_MIS.Properties.Resources.Logo;
            this.pbLogo.Location = new System.Drawing.Point(35, 7);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(250, 80);
            this.pbLogo.TabIndex = 27;
            this.pbLogo.TabStop = false;
            // 
            // miDREAMS
            // 
            this.miDREAMS.Name = "miDREAMS";
            this.miDREAMS.Size = new System.Drawing.Size(65, 20);
            this.miDREAMS.Text = "DREAMS";
            this.miDREAMS.Click += new System.EventHandler(this.miDREAMS_Click);
            // 
            // Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 661);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.pnlLinks);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.lblVersionNumber);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.pnlPlaceHolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
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

        private System.Windows.Forms.Panel pnlPlaceHolder;
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

    }
}

