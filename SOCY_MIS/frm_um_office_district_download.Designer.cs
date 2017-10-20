namespace SOCY_MIS
{
    partial class frm_um_office_district_download
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gdv_districts = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnsave = new System.Windows.Forms.Button();
            this.chk_active = new System.Windows.Forms.CheckBox();
            this.cbo_district = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_districts)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 485);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.gdv_districts);
            this.panel3.Location = new System.Drawing.Point(6, 89);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(692, 372);
            this.panel3.TabIndex = 1;
            // 
            // gdv_districts
            // 
            this.gdv_districts.AllowUserToAddRows = false;
            this.gdv_districts.AllowUserToDeleteRows = false;
            this.gdv_districts.AllowUserToResizeColumns = false;
            this.gdv_districts.AllowUserToResizeRows = false;
            this.gdv_districts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdv_districts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdv_districts.Location = new System.Drawing.Point(3, 3);
            this.gdv_districts.Name = "gdv_districts";
            this.gdv_districts.RowTemplate.Height = 24;
            this.gdv_districts.Size = new System.Drawing.Size(686, 366);
            this.gdv_districts.TabIndex = 0;
            this.gdv_districts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdv_districts_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.btnsave);
            this.panel2.Controls.Add(this.chk_active);
            this.panel2.Controls.Add(this.cbo_district);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(6, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(692, 80);
            this.panel2.TabIndex = 0;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Cyan;
            this.btnsave.Location = new System.Drawing.Point(360, 25);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(101, 32);
            this.btnsave.TabIndex = 3;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // chk_active
            // 
            this.chk_active.AutoSize = true;
            this.chk_active.Location = new System.Drawing.Point(295, 32);
            this.chk_active.Name = "chk_active";
            this.chk_active.Size = new System.Drawing.Size(68, 21);
            this.chk_active.TabIndex = 2;
            this.chk_active.Text = "Active";
            this.chk_active.UseVisualStyleBackColor = true;
            // 
            // cbo_district
            // 
            this.cbo_district.FormattingEnabled = true;
            this.cbo_district.Location = new System.Drawing.Point(8, 29);
            this.cbo_district.Name = "cbo_district";
            this.cbo_district.Size = new System.Drawing.Size(269, 24);
            this.cbo_district.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "District Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a district and save to add to download list";
            // 
            // frm_um_office_district_download
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(705, 516);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_um_office_district_download";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "District Download setup";
            this.Load += new System.EventHandler(this.frm_um_office_district_download_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdv_districts)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_district;
        private System.Windows.Forms.CheckBox chk_active;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView gdv_districts;
    }
}