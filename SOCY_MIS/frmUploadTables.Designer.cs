namespace SOCY_MIS
{
    partial class frmUploadTables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUploadTables));
            this.lblCount = new System.Windows.Forms.Label();
            this.btnSync = new System.Windows.Forms.Button();
            this.bgWorkerImport = new System.ComponentModel.BackgroundWorker();
            this.PBarDownload = new System.Windows.Forms.ProgressBar();
            this.lblstatus = new System.Windows.Forms.Label();
            this.gpboxDownload = new System.Windows.Forms.GroupBox();
            this.panelDates = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtdatefrom = new System.Windows.Forms.DateTimePicker();
            this.dtdateTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDistrict = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDownloadList = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblofficestatus = new System.Windows.Forms.Label();
            this.gdvTest = new System.Windows.Forms.DataGridView();
            this.gpboxDownload.SuspendLayout();
            this.panelDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvTest)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(683, 279);
            this.lblCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(17, 18);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "0";
            // 
            // btnSync
            // 
            this.btnSync.ForeColor = System.Drawing.Color.Blue;
            this.btnSync.Location = new System.Drawing.Point(16, 196);
            this.btnSync.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(129, 39);
            this.btnSync.TabIndex = 2;
            this.btnSync.Text = "Download Data";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // bgWorkerImport
            // 
            this.bgWorkerImport.WorkerReportsProgress = true;
            this.bgWorkerImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerImport_DoWork);
            this.bgWorkerImport.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerImport_ProgressChanged);
            this.bgWorkerImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerImport_RunWorkerCompleted);
            // 
            // PBarDownload
            // 
            this.PBarDownload.Location = new System.Drawing.Point(16, 258);
            this.PBarDownload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PBarDownload.Name = "PBarDownload";
            this.PBarDownload.Size = new System.Drawing.Size(659, 39);
            this.PBarDownload.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PBarDownload.TabIndex = 3;
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.ForeColor = System.Drawing.Color.Red;
            this.lblstatus.Location = new System.Drawing.Point(16, 239);
            this.lblstatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(177, 17);
            this.lblstatus.TabIndex = 4;
            this.lblstatus.Text = "Download Waiting..............";
            // 
            // gpboxDownload
            // 
            this.gpboxDownload.Controls.Add(this.panelDates);
            this.gpboxDownload.Controls.Add(this.label5);
            this.gpboxDownload.Controls.Add(this.cboDistrict);
            this.gpboxDownload.Controls.Add(this.label2);
            this.gpboxDownload.Controls.Add(this.cboDownloadList);
            this.gpboxDownload.Location = new System.Drawing.Point(16, 15);
            this.gpboxDownload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpboxDownload.Name = "gpboxDownload";
            this.gpboxDownload.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpboxDownload.Size = new System.Drawing.Size(773, 174);
            this.gpboxDownload.TabIndex = 5;
            this.gpboxDownload.TabStop = false;
            this.gpboxDownload.Text = "Click on a dataset to start download";
            // 
            // panelDates
            // 
            this.panelDates.BackColor = System.Drawing.Color.LightCyan;
            this.panelDates.Controls.Add(this.label7);
            this.panelDates.Controls.Add(this.label6);
            this.panelDates.Controls.Add(this.dtdatefrom);
            this.panelDates.Controls.Add(this.dtdateTo);
            this.panelDates.Location = new System.Drawing.Point(11, 79);
            this.panelDates.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDates.Name = "panelDates";
            this.panelDates.Size = new System.Drawing.Size(755, 87);
            this.panelDates.TabIndex = 13;
            this.panelDates.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "End Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Start Date:";
            // 
            // dtdatefrom
            // 
            this.dtdatefrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtdatefrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtdatefrom.Location = new System.Drawing.Point(3, 36);
            this.dtdatefrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtdatefrom.Name = "dtdatefrom";
            this.dtdatefrom.ShowCheckBox = true;
            this.dtdatefrom.Size = new System.Drawing.Size(200, 27);
            this.dtdatefrom.TabIndex = 11;
            // 
            // dtdateTo
            // 
            this.dtdateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtdateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtdateTo.Location = new System.Drawing.Point(209, 36);
            this.dtdateTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtdateTo.Name = "dtdateTo";
            this.dtdateTo.ShowCheckBox = true;
            this.dtdateTo.Size = new System.Drawing.Size(200, 27);
            this.dtdateTo.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(476, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "District";
            // 
            // cboDistrict
            // 
            this.cboDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrict.Enabled = false;
            this.cboDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDistrict.FormattingEnabled = true;
            this.cboDistrict.Location = new System.Drawing.Point(480, 39);
            this.cboDistrict.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboDistrict.Name = "cboDistrict";
            this.cboDistrict.Size = new System.Drawing.Size(284, 33);
            this.cboDistrict.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select a dataset";
            // 
            // cboDownloadList
            // 
            this.cboDownloadList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDownloadList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDownloadList.FormattingEnabled = true;
            this.cboDownloadList.Location = new System.Drawing.Point(8, 39);
            this.cboDownloadList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboDownloadList.Name = "cboDownloadList";
            this.cboDownloadList.Size = new System.Drawing.Size(468, 33);
            this.cboDownloadList.TabIndex = 0;
            this.cboDownloadList.SelectedIndexChanged += new System.EventHandler(this.cboDownloadList_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.ForeColor = System.Drawing.Color.Blue;
            this.btnCancel.Location = new System.Drawing.Point(155, 196);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(139, 39);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel Download";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(673, 239);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Download Timer ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(1, 375);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Note: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(49, 375);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(618, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "You can minimise this form and continue using other system modules as the downloa" +
    "d processes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(324, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Office Status:";
            // 
            // lblofficestatus
            // 
            this.lblofficestatus.AutoSize = true;
            this.lblofficestatus.ForeColor = System.Drawing.Color.Blue;
            this.lblofficestatus.Location = new System.Drawing.Point(423, 207);
            this.lblofficestatus.Name = "lblofficestatus";
            this.lblofficestatus.Size = new System.Drawing.Size(36, 17);
            this.lblofficestatus.TabIndex = 12;
            this.lblofficestatus.Text = ".......";
            // 
            // gdvTest
            // 
            this.gdvTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvTest.Location = new System.Drawing.Point(19, 304);
            this.gdvTest.Name = "gdvTest";
            this.gdvTest.RowTemplate.Height = 24;
            this.gdvTest.Size = new System.Drawing.Size(656, 55);
            this.gdvTest.TabIndex = 13;
            // 
            // frmUploadTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 407);
            this.Controls.Add(this.gdvTest);
            this.Controls.Add(this.lblofficestatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gpboxDownload);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.PBarDownload);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.lblCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmUploadTables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SOCY MIS Data Import Wizard";
            this.Load += new System.EventHandler(this.frmUploadTables_Load);
            this.gpboxDownload.ResumeLayout(false);
            this.gpboxDownload.PerformLayout();
            this.panelDates.ResumeLayout(false);
            this.panelDates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnSync;
        private System.ComponentModel.BackgroundWorker bgWorkerImport;
        private System.Windows.Forms.ProgressBar PBarDownload;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.GroupBox gpboxDownload;
        private System.Windows.Forms.ComboBox cboDownloadList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDistrict;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtdateTo;
        private System.Windows.Forms.DateTimePicker dtdatefrom;
        private System.Windows.Forms.Panel panelDates;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblofficestatus;
        private System.Windows.Forms.DataGridView gdvTest;
    }
}