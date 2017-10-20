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
            this.pnlPlaceHolder = new System.Windows.Forms.Panel();
            this.llbdistrict_download = new System.Windows.Forms.LinkLabel();
            this.gbAdminFunctions.SuspendLayout();
            this.tlpDisplay01.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAdminFunctions
            // 
            this.gbAdminFunctions.Controls.Add(this.tlpDisplay01);
            this.gbAdminFunctions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAdminFunctions.Location = new System.Drawing.Point(4, 7);
            this.gbAdminFunctions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbAdminFunctions.Name = "gbAdminFunctions";
            this.gbAdminFunctions.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbAdminFunctions.Size = new System.Drawing.Size(224, 219);
            this.gbAdminFunctions.TabIndex = 0;
            this.gbAdminFunctions.TabStop = false;
            this.gbAdminFunctions.Text = "Administrator Functions";
            // 
            // tlpDisplay01
            // 
            this.tlpDisplay01.ColumnCount = 1;
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay01.Controls.Add(this.llblDataTransfer, 0, 5);
            this.tlpDisplay01.Controls.Add(this.llblUserManagement, 0, 0);
            this.tlpDisplay01.Controls.Add(this.llblRoleManagement, 0, 1);
            this.tlpDisplay01.Controls.Add(this.llblOfficeManagement, 0, 3);
            this.tlpDisplay01.Controls.Add(this.llblDCConnect, 0, 2);
            this.tlpDisplay01.Controls.Add(this.llbdistrict_download, 0, 4);
            this.tlpDisplay01.Location = new System.Drawing.Point(8, 23);
            this.tlpDisplay01.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpDisplay01.Name = "tlpDisplay01";
            this.tlpDisplay01.RowCount = 6;
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay01.Size = new System.Drawing.Size(208, 166);
            this.tlpDisplay01.TabIndex = 2;
            // 
            // llblDataTransfer
            // 
            this.llblDataTransfer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblDataTransfer.AutoSize = true;
            this.llblDataTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblDataTransfer.Location = new System.Drawing.Point(4, 147);
            this.llblDataTransfer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblDataTransfer.Name = "llblDataTransfer";
            this.llblDataTransfer.Size = new System.Drawing.Size(181, 17);
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
            this.llblUserManagement.Location = new System.Drawing.Point(4, 6);
            this.llblUserManagement.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblUserManagement.Name = "llblUserManagement";
            this.llblUserManagement.Size = new System.Drawing.Size(124, 17);
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
            this.llblRoleManagement.Location = new System.Drawing.Point(4, 35);
            this.llblRoleManagement.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblRoleManagement.Name = "llblRoleManagement";
            this.llblRoleManagement.Size = new System.Drawing.Size(123, 17);
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
            this.llblOfficeManagement.Location = new System.Drawing.Point(4, 93);
            this.llblOfficeManagement.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblOfficeManagement.Name = "llblOfficeManagement";
            this.llblOfficeManagement.Size = new System.Drawing.Size(119, 17);
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
            this.llblDCConnect.Location = new System.Drawing.Point(4, 64);
            this.llblDCConnect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblDCConnect.Name = "llblDCConnect";
            this.llblDCConnect.Size = new System.Drawing.Size(144, 17);
            this.llblDCConnect.TabIndex = 3;
            this.llblDCConnect.TabStop = true;
            this.llblDCConnect.Text = "Database Connection";
            this.llblDCConnect.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblDCConnect_LinkClicked);
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
            this.pnlPlaceHolder.TabIndex = 1;
            // 
            // llbdistrict_download
            // 
            this.llbdistrict_download.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llbdistrict_download.AutoSize = true;
            this.llbdistrict_download.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbdistrict_download.Location = new System.Drawing.Point(4, 122);
            this.llbdistrict_download.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llbdistrict_download.Name = "llbdistrict_download";
            this.llbdistrict_download.Size = new System.Drawing.Size(136, 17);
            this.llbdistrict_download.TabIndex = 5;
            this.llbdistrict_download.TabStop = true;
            this.llbdistrict_download.Text = "District download list";
            this.llbdistrict_download.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbdistrict_download_LinkClicked);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlPlaceHolder);
            this.Controls.Add(this.gbAdminFunctions);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmAdmin";
            this.Size = new System.Drawing.Size(1213, 640);
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
    }
}
