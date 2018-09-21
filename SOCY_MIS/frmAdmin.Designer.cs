namespace SOCY_MIS
{
    partial class frmAdmin
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
            this.gbAdminFunctions = new System.Windows.Forms.GroupBox();
            this.tlpDisplay01 = new System.Windows.Forms.TableLayoutPanel();
            this.llblDataTransfer = new System.Windows.Forms.LinkLabel();
            this.llblUserManagement = new System.Windows.Forms.LinkLabel();
            this.llblRoleManagement = new System.Windows.Forms.LinkLabel();
            this.llblOfficeManagement = new System.Windows.Forms.LinkLabel();
            this.llblDCConnect = new System.Windows.Forms.LinkLabel();
            this.llbdistrict_download = new System.Windows.Forms.LinkLabel();
            this.pnlPlaceHolder = new System.Windows.Forms.Panel();
            this.llblDownload = new System.Windows.Forms.LinkLabel();
            this.gbAdminFunctions.SuspendLayout();
            this.tlpDisplay01.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAdminFunctions
            // 
            this.gbAdminFunctions.Controls.Add(this.tlpDisplay01);
            this.gbAdminFunctions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAdminFunctions.Location = new System.Drawing.Point(3, 6);
            this.gbAdminFunctions.Name = "gbAdminFunctions";
            this.gbAdminFunctions.Size = new System.Drawing.Size(168, 237);
            this.gbAdminFunctions.TabIndex = 0;
            this.gbAdminFunctions.TabStop = false;
            this.gbAdminFunctions.Text = "Administrator Functions";
            // 
            // tlpDisplay01
            // 
            this.tlpDisplay01.ColumnCount = 1;
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay01.Controls.Add(this.llblDownload, 0, 6);
            this.tlpDisplay01.Controls.Add(this.llblDataTransfer, 0, 5);
            this.tlpDisplay01.Controls.Add(this.llblUserManagement, 0, 0);
            this.tlpDisplay01.Controls.Add(this.llblRoleManagement, 0, 1);
            this.tlpDisplay01.Controls.Add(this.llblOfficeManagement, 0, 3);
            this.tlpDisplay01.Controls.Add(this.llblDCConnect, 0, 2);
            this.tlpDisplay01.Controls.Add(this.llbdistrict_download, 0, 4);
            this.tlpDisplay01.Location = new System.Drawing.Point(6, 19);
            this.tlpDisplay01.Name = "tlpDisplay01";
            this.tlpDisplay01.RowCount = 7;
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpDisplay01.Size = new System.Drawing.Size(156, 174);
            this.tlpDisplay01.TabIndex = 2;
            // 
            // llblDataTransfer
            // 
            this.llblDataTransfer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblDataTransfer.AutoSize = true;
            this.llblDataTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblDataTransfer.Location = new System.Drawing.Point(3, 127);
            this.llblDataTransfer.Name = "llblDataTransfer";
            this.llblDataTransfer.Size = new System.Drawing.Size(139, 13);
            this.llblDataTransfer.TabIndex = 4;
            this.llblDataTransfer.TabStop = true;
            this.llblDataTransfer.Text = "Data Upload and Download";
            this.llblDataTransfer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblDataTransfer_LinkClicked);
            // 
            // llblUserManagement
            // 
            this.llblUserManagement.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblUserManagement.AutoSize = true;
            this.llblUserManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblUserManagement.Location = new System.Drawing.Point(3, 5);
            this.llblUserManagement.Name = "llblUserManagement";
            this.llblUserManagement.Size = new System.Drawing.Size(94, 13);
            this.llblUserManagement.TabIndex = 1;
            this.llblUserManagement.TabStop = true;
            this.llblUserManagement.Text = "User Management";
            this.llblUserManagement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblUserManagement_LinkClicked);
            // 
            // llblRoleManagement
            // 
            this.llblRoleManagement.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblRoleManagement.AutoSize = true;
            this.llblRoleManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblRoleManagement.Location = new System.Drawing.Point(3, 29);
            this.llblRoleManagement.Name = "llblRoleManagement";
            this.llblRoleManagement.Size = new System.Drawing.Size(94, 13);
            this.llblRoleManagement.TabIndex = 2;
            this.llblRoleManagement.TabStop = true;
            this.llblRoleManagement.Text = "Role Management";
            this.llblRoleManagement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRoleManagement_LinkClicked);
            // 
            // llblOfficeManagement
            // 
            this.llblOfficeManagement.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblOfficeManagement.AutoSize = true;
            this.llblOfficeManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblOfficeManagement.Location = new System.Drawing.Point(3, 77);
            this.llblOfficeManagement.Name = "llblOfficeManagement";
            this.llblOfficeManagement.Size = new System.Drawing.Size(90, 13);
            this.llblOfficeManagement.TabIndex = 0;
            this.llblOfficeManagement.TabStop = true;
            this.llblOfficeManagement.Text = "Office Information";
            this.llblOfficeManagement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblOfficeManagement_LinkClicked);
            // 
            // llblDCConnect
            // 
            this.llblDCConnect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblDCConnect.AutoSize = true;
            this.llblDCConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblDCConnect.Location = new System.Drawing.Point(3, 53);
            this.llblDCConnect.Name = "llblDCConnect";
            this.llblDCConnect.Size = new System.Drawing.Size(110, 13);
            this.llblDCConnect.TabIndex = 3;
            this.llblDCConnect.TabStop = true;
            this.llblDCConnect.Text = "Database Connection";
            this.llblDCConnect.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblDCConnect_LinkClicked);
            // 
            // llbdistrict_download
            // 
            this.llbdistrict_download.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llbdistrict_download.AutoSize = true;
            this.llbdistrict_download.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbdistrict_download.Location = new System.Drawing.Point(3, 101);
            this.llbdistrict_download.Name = "llbdistrict_download";
            this.llbdistrict_download.Size = new System.Drawing.Size(103, 13);
            this.llbdistrict_download.TabIndex = 5;
            this.llbdistrict_download.TabStop = true;
            this.llbdistrict_download.Text = "District download list";
            this.llbdistrict_download.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbdistrict_download_LinkClicked);
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
            this.pnlPlaceHolder.TabIndex = 1;
            // 
            // llblDownload
            // 
            this.llblDownload.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblDownload.AutoSize = true;
            this.llblDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblDownload.Location = new System.Drawing.Point(3, 154);
            this.llblDownload.Name = "llblDownload";
            this.llblDownload.Size = new System.Drawing.Size(85, 13);
            this.llblDownload.TabIndex = 6;
            this.llblDownload.TabStop = true;
            this.llblDownload.Text = "DownLoad Data";
            this.llblDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblDownload_LinkClicked);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlPlaceHolder);
            this.Controls.Add(this.gbAdminFunctions);
            this.Name = "frmAdmin";
            this.Size = new System.Drawing.Size(910, 520);
            this.gbAdminFunctions.ResumeLayout(false);
            this.tlpDisplay01.ResumeLayout(false);
            this.tlpDisplay01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAdminFunctions;
        private System.Windows.Forms.LinkLabel llblDCConnect;
        private System.Windows.Forms.LinkLabel llblRoleManagement;
        private System.Windows.Forms.LinkLabel llblUserManagement;
        private System.Windows.Forms.LinkLabel llblOfficeManagement;
        private System.Windows.Forms.Panel pnlPlaceHolder;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay01;
        private System.Windows.Forms.LinkLabel llblDataTransfer;
        private System.Windows.Forms.LinkLabel llbdistrict_download;
        private System.Windows.Forms.LinkLabel llblDownload;
    }
}
