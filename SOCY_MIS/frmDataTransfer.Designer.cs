﻿namespace SOCY_MIS
{
    partial class frmDataTransfer
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
            this.btnDataTransfer = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.tlpDisplay01 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNameDisplay = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.lblPhoneDisplay = new System.Windows.Forms.Label();
            this.lblEmailDisplay = new System.Windows.Forms.Label();
            this.lblLastNameDisplay = new System.Windows.Forms.Label();
            this.lblFirstNameDisplay = new System.Windows.Forms.Label();
            this.lblOfficeStatus = new System.Windows.Forms.Label();
            this.lblOfficeStatusDisplay = new System.Windows.Forms.Label();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.lblConnectionStatusDisplay = new System.Windows.Forms.Label();
            this.gbOfficeTitle = new System.Windows.Forms.GroupBox();
            this.tlpProcess = new System.Windows.Forms.TableLayoutPanel();
            this.lblProcessing = new System.Windows.Forms.Label();
            this.lblConnectionRestart = new System.Windows.Forms.Label();
            this.tlpMessage = new System.Windows.Forms.TableLayoutPanel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.tlpDisplay01.SuspendLayout();
            this.gbOfficeTitle.SuspendLayout();
            this.tlpProcess.SuspendLayout();
            this.tlpMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDataTransfer
            // 
            this.btnDataTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataTransfer.Location = new System.Drawing.Point(415, 289);
            this.btnDataTransfer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDataTransfer.Name = "btnDataTransfer";
            this.btnDataTransfer.Size = new System.Drawing.Size(100, 28);
            this.btnDataTransfer.TabIndex = 1;
            this.btnDataTransfer.Text = "Transfer Data";
            this.btnDataTransfer.UseVisualStyleBackColor = true;
            this.btnDataTransfer.Click += new System.EventHandler(this.btnDataTransfer_Click);
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(4, 9);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(90, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Office Name:";
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(4, 154);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(64, 17);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Address:";
            // 
            // lblPhone
            // 
            this.lblPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(4, 45);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(107, 17);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "Phone Number:";
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(472, 45);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 17);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(4, 81);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(132, 17);
            this.lblFirstName.TabIndex = 8;
            this.lblFirstName.Text = "Contact First Name:";
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(472, 81);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(132, 17);
            this.lblLastName.TabIndex = 10;
            this.lblLastName.Text = "Contact Last Name:";
            // 
            // tlpDisplay01
            // 
            this.tlpDisplay01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDisplay01.ColumnCount = 6;
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpDisplay01.Controls.Add(this.lblNameDisplay, 1, 0);
            this.tlpDisplay01.Controls.Add(this.lblName, 0, 0);
            this.tlpDisplay01.Controls.Add(this.lblFirstName, 0, 2);
            this.tlpDisplay01.Controls.Add(this.lblPhone, 0, 1);
            this.tlpDisplay01.Controls.Add(this.lblEmail, 3, 1);
            this.tlpDisplay01.Controls.Add(this.lblLastName, 3, 2);
            this.tlpDisplay01.Controls.Add(this.lblAddress, 0, 3);
            this.tlpDisplay01.Controls.Add(this.txtAddress, 1, 3);
            this.tlpDisplay01.Controls.Add(this.lblPhoneDisplay, 1, 1);
            this.tlpDisplay01.Controls.Add(this.lblEmailDisplay, 4, 1);
            this.tlpDisplay01.Controls.Add(this.lblLastNameDisplay, 4, 2);
            this.tlpDisplay01.Controls.Add(this.lblFirstNameDisplay, 1, 2);
            this.tlpDisplay01.Controls.Add(this.lblOfficeStatus, 3, 0);
            this.tlpDisplay01.Controls.Add(this.lblOfficeStatusDisplay, 4, 0);
            this.tlpDisplay01.Controls.Add(this.lblConnectionStatus, 0, 4);
            this.tlpDisplay01.Controls.Add(this.lblConnectionStatusDisplay, 1, 4);
            this.tlpDisplay01.Location = new System.Drawing.Point(8, 23);
            this.tlpDisplay01.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpDisplay01.Name = "tlpDisplay01";
            this.tlpDisplay01.RowCount = 5;
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.85592F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28816F));
            this.tlpDisplay01.Size = new System.Drawing.Size(936, 258);
            this.tlpDisplay01.TabIndex = 59;
            // 
            // lblNameDisplay
            // 
            this.lblNameDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNameDisplay.AutoSize = true;
            this.lblNameDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameDisplay.Location = new System.Drawing.Point(204, 9);
            this.lblNameDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNameDisplay.Name = "lblNameDisplay";
            this.lblNameDisplay.Size = new System.Drawing.Size(13, 17);
            this.lblNameDisplay.TabIndex = 12;
            this.lblNameDisplay.Text = "-";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(204, 112);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(233, 102);
            this.txtAddress.TabIndex = 11;
            this.txtAddress.Text = "-";
            // 
            // lblPhoneDisplay
            // 
            this.lblPhoneDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPhoneDisplay.AutoSize = true;
            this.lblPhoneDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneDisplay.Location = new System.Drawing.Point(204, 45);
            this.lblPhoneDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhoneDisplay.Name = "lblPhoneDisplay";
            this.lblPhoneDisplay.Size = new System.Drawing.Size(13, 17);
            this.lblPhoneDisplay.TabIndex = 13;
            this.lblPhoneDisplay.Text = "-";
            // 
            // lblEmailDisplay
            // 
            this.lblEmailDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEmailDisplay.AutoSize = true;
            this.lblEmailDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailDisplay.Location = new System.Drawing.Point(672, 45);
            this.lblEmailDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmailDisplay.Name = "lblEmailDisplay";
            this.lblEmailDisplay.Size = new System.Drawing.Size(13, 17);
            this.lblEmailDisplay.TabIndex = 14;
            this.lblEmailDisplay.Text = "-";
            // 
            // lblLastNameDisplay
            // 
            this.lblLastNameDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLastNameDisplay.AutoSize = true;
            this.lblLastNameDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastNameDisplay.Location = new System.Drawing.Point(672, 81);
            this.lblLastNameDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastNameDisplay.Name = "lblLastNameDisplay";
            this.lblLastNameDisplay.Size = new System.Drawing.Size(13, 17);
            this.lblLastNameDisplay.TabIndex = 15;
            this.lblLastNameDisplay.Text = "-";
            // 
            // lblFirstNameDisplay
            // 
            this.lblFirstNameDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFirstNameDisplay.AutoSize = true;
            this.lblFirstNameDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstNameDisplay.Location = new System.Drawing.Point(204, 81);
            this.lblFirstNameDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstNameDisplay.Name = "lblFirstNameDisplay";
            this.lblFirstNameDisplay.Size = new System.Drawing.Size(13, 17);
            this.lblFirstNameDisplay.TabIndex = 16;
            this.lblFirstNameDisplay.Text = "-";
            // 
            // lblOfficeStatus
            // 
            this.lblOfficeStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOfficeStatus.AutoSize = true;
            this.lblOfficeStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOfficeStatus.Location = new System.Drawing.Point(472, 9);
            this.lblOfficeStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOfficeStatus.Name = "lblOfficeStatus";
            this.lblOfficeStatus.Size = new System.Drawing.Size(132, 17);
            this.lblOfficeStatus.TabIndex = 17;
            this.lblOfficeStatus.Text = "Registration Status:";
            // 
            // lblOfficeStatusDisplay
            // 
            this.lblOfficeStatusDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOfficeStatusDisplay.AutoSize = true;
            this.lblOfficeStatusDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOfficeStatusDisplay.Location = new System.Drawing.Point(672, 9);
            this.lblOfficeStatusDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOfficeStatusDisplay.Name = "lblOfficeStatusDisplay";
            this.lblOfficeStatusDisplay.Size = new System.Drawing.Size(13, 17);
            this.lblOfficeStatusDisplay.TabIndex = 18;
            this.lblOfficeStatusDisplay.Text = "-";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionStatus.Location = new System.Drawing.Point(4, 229);
            this.lblConnectionStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(127, 17);
            this.lblConnectionStatus.TabIndex = 19;
            this.lblConnectionStatus.Text = "Connection Status:";
            // 
            // lblConnectionStatusDisplay
            // 
            this.lblConnectionStatusDisplay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblConnectionStatusDisplay.AutoSize = true;
            this.lblConnectionStatusDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionStatusDisplay.Location = new System.Drawing.Point(204, 229);
            this.lblConnectionStatusDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnectionStatusDisplay.Name = "lblConnectionStatusDisplay";
            this.lblConnectionStatusDisplay.Size = new System.Drawing.Size(13, 17);
            this.lblConnectionStatusDisplay.TabIndex = 20;
            this.lblConnectionStatusDisplay.Text = "-";
            // 
            // gbOfficeTitle
            // 
            this.gbOfficeTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbOfficeTitle.Controls.Add(this.tlpProcess);
            this.gbOfficeTitle.Controls.Add(this.tlpMessage);
            this.gbOfficeTitle.Controls.Add(this.tlpDisplay01);
            this.gbOfficeTitle.Controls.Add(this.btnDataTransfer);
            this.gbOfficeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOfficeTitle.Location = new System.Drawing.Point(4, 7);
            this.gbOfficeTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOfficeTitle.Name = "gbOfficeTitle";
            this.gbOfficeTitle.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOfficeTitle.Size = new System.Drawing.Size(952, 608);
            this.gbOfficeTitle.TabIndex = 29;
            this.gbOfficeTitle.TabStop = false;
            this.gbOfficeTitle.Text = "Office Details";
            // 
            // tlpProcess
            // 
            this.tlpProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpProcess.ColumnCount = 1;
            this.tlpProcess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 936F));
            this.tlpProcess.Controls.Add(this.lblProcessing, 0, 0);
            this.tlpProcess.Controls.Add(this.lblConnectionRestart, 0, 1);
            this.tlpProcess.Location = new System.Drawing.Point(8, 319);
            this.tlpProcess.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpProcess.Name = "tlpProcess";
            this.tlpProcess.RowCount = 2;
            this.tlpProcess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpProcess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpProcess.Size = new System.Drawing.Size(936, 54);
            this.tlpProcess.TabIndex = 63;
            // 
            // lblProcessing
            // 
            this.lblProcessing.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessing.Location = new System.Drawing.Point(429, 5);
            this.lblProcessing.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(78, 17);
            this.lblProcessing.TabIndex = 61;
            this.lblProcessing.Text = "Processing";
            this.lblProcessing.Visible = false;
            // 
            // lblConnectionRestart
            // 
            this.lblConnectionRestart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConnectionRestart.AutoSize = true;
            this.lblConnectionRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionRestart.Location = new System.Drawing.Point(403, 32);
            this.lblConnectionRestart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnectionRestart.Name = "lblConnectionRestart";
            this.lblConnectionRestart.Size = new System.Drawing.Size(129, 17);
            this.lblConnectionRestart.TabIndex = 62;
            this.lblConnectionRestart.Text = "Connection Restart";
            this.lblConnectionRestart.Visible = false;
            // 
            // tlpMessage
            // 
            this.tlpMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMessage.ColumnCount = 1;
            this.tlpMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 936F));
            this.tlpMessage.Controls.Add(this.lblMessage, 0, 0);
            this.tlpMessage.Controls.Add(this.txtMessage, 0, 1);
            this.tlpMessage.Location = new System.Drawing.Point(8, 372);
            this.tlpMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpMessage.Name = "tlpMessage";
            this.tlpMessage.RowCount = 2;
            this.tlpMessage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpMessage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.71429F));
            this.tlpMessage.Size = new System.Drawing.Size(936, 228);
            this.tlpMessage.TabIndex = 60;
            this.tlpMessage.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(412, 7);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(111, 17);
            this.lblMessage.TabIndex = 17;
            this.lblMessage.Text = "Server Message";
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(4, 36);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(928, 188);
            this.txtMessage.TabIndex = 11;
            this.txtMessage.Text = "-";
            // 
            // frmDataTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbOfficeTitle);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmDataTransfer";
            this.Size = new System.Drawing.Size(960, 619);
            this.Load += new System.EventHandler(this.frmDataTransfer_Load);
            this.tlpDisplay01.ResumeLayout(false);
            this.tlpDisplay01.PerformLayout();
            this.gbOfficeTitle.ResumeLayout(false);
            this.tlpProcess.ResumeLayout(false);
            this.tlpProcess.PerformLayout();
            this.tlpMessage.ResumeLayout(false);
            this.tlpMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDataTransfer;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay01;
        private System.Windows.Forms.GroupBox gbOfficeTitle;
        private System.Windows.Forms.Label lblNameDisplay;
        private System.Windows.Forms.RichTextBox txtAddress;
        private System.Windows.Forms.Label lblPhoneDisplay;
        private System.Windows.Forms.Label lblEmailDisplay;
        private System.Windows.Forms.Label lblLastNameDisplay;
        private System.Windows.Forms.Label lblFirstNameDisplay;
        private System.Windows.Forms.Label lblOfficeStatus;
        private System.Windows.Forms.Label lblOfficeStatusDisplay;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Label lblConnectionStatusDisplay;
        private System.Windows.Forms.TableLayoutPanel tlpMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.Label lblProcessing;
        private System.Windows.Forms.Label lblConnectionRestart;
        private System.Windows.Forms.TableLayoutPanel tlpProcess;
    }
}
