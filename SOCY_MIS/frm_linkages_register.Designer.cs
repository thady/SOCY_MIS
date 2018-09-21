namespace SOCY_MIS
{
    partial class frm_linkages_register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_linkages_register));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_guid = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gdv_household_members = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.chk_list_services_required = new System.Windows.Forms.CheckedListBox();
            this.chk_list_services_received = new System.Windows.Forms.CheckedListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbo_service_provider = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_age = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbo_gender = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_hh_member_name = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_hh_member_code = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbo_village = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbo_parish = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_subcouty = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_district = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_ip = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_household_members)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lbl_guid);
            this.panel1.Controls.Add(this.btncancel);
            this.panel1.Controls.Add(this.btnedit);
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1172, 796);
            this.panel1.TabIndex = 0;
            // 
            // lbl_guid
            // 
            this.lbl_guid.AutoSize = true;
            this.lbl_guid.ForeColor = System.Drawing.Color.Blue;
            this.lbl_guid.Location = new System.Drawing.Point(12, 337);
            this.lbl_guid.Name = "lbl_guid";
            this.lbl_guid.Size = new System.Drawing.Size(68, 17);
            this.lbl_guid.TabIndex = 9;
            this.lbl_guid.Text = "record_id";
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(1068, 343);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(95, 35);
            this.btncancel.TabIndex = 8;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            // 
            // btnedit
            // 
            this.btnedit.Location = new System.Drawing.Point(931, 343);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(133, 35);
            this.btnedit.TabIndex = 7;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(792, 343);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(133, 35);
            this.btnsave.TabIndex = 6;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label15.Location = new System.Drawing.Point(9, 146);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(285, 17);
            this.label15.TabIndex = 5;
            this.label15.Text = "Household member Linkages Tracking Data";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label14.Location = new System.Drawing.Point(9, 361);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(442, 17);
            this.label14.TabIndex = 4;
            this.label14.Text = "Select a household member below to create or update linkges details";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.gdv_household_members);
            this.panel4.Location = new System.Drawing.Point(12, 381);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1151, 405);
            this.panel4.TabIndex = 3;
            // 
            // gdv_household_members
            // 
            this.gdv_household_members.AllowUserToAddRows = false;
            this.gdv_household_members.AllowUserToDeleteRows = false;
            this.gdv_household_members.AllowUserToResizeColumns = false;
            this.gdv_household_members.AllowUserToResizeRows = false;
            this.gdv_household_members.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdv_household_members.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdv_household_members.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdv_household_members.Location = new System.Drawing.Point(3, 3);
            this.gdv_household_members.Name = "gdv_household_members";
            this.gdv_household_members.RowTemplate.Height = 24;
            this.gdv_household_members.Size = new System.Drawing.Size(1145, 399);
            this.gdv_household_members.TabIndex = 0;
            this.gdv_household_members.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdv_household_members_CellClick);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Azure;
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.chk_list_services_required);
            this.panel3.Controls.Add(this.chk_list_services_received);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.cbo_service_provider);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txt_age);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.cbo_gender);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txt_hh_member_name);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txt_hh_member_code);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(12, 166);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1151, 168);
            this.panel3.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label13.Location = new System.Drawing.Point(896, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 17);
            this.label13.TabIndex = 21;
            this.label13.Text = "Services Required";
            // 
            // chk_list_services_required
            // 
            this.chk_list_services_required.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chk_list_services_required.FormattingEnabled = true;
            this.chk_list_services_required.Location = new System.Drawing.Point(899, 32);
            this.chk_list_services_required.Name = "chk_list_services_required";
            this.chk_list_services_required.Size = new System.Drawing.Size(243, 123);
            this.chk_list_services_required.TabIndex = 20;
            // 
            // chk_list_services_received
            // 
            this.chk_list_services_received.FormattingEnabled = true;
            this.chk_list_services_received.Location = new System.Drawing.Point(579, 32);
            this.chk_list_services_received.Name = "chk_list_services_received";
            this.chk_list_services_received.Size = new System.Drawing.Size(314, 123);
            this.chk_list_services_received.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label12.Location = new System.Drawing.Point(576, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 17);
            this.label12.TabIndex = 18;
            this.label12.Text = "Services Received";
            // 
            // cbo_service_provider
            // 
            this.cbo_service_provider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_service_provider.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_service_provider.FormattingEnabled = true;
            this.cbo_service_provider.Location = new System.Drawing.Point(14, 128);
            this.cbo_service_provider.Name = "cbo_service_provider";
            this.cbo_service_provider.Size = new System.Drawing.Size(291, 26);
            this.cbo_service_provider.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 17);
            this.label11.TabIndex = 17;
            this.label11.Text = "Service Provider";
            // 
            // txt_age
            // 
            this.txt_age.Enabled = false;
            this.txt_age.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_age.Location = new System.Drawing.Point(199, 81);
            this.txt_age.Name = "txt_age";
            this.txt_age.Size = new System.Drawing.Size(106, 24);
            this.txt_age.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(196, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 17);
            this.label10.TabIndex = 15;
            this.label10.Text = "Age";
            // 
            // cbo_gender
            // 
            this.cbo_gender.Enabled = false;
            this.cbo_gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_gender.FormattingEnabled = true;
            this.cbo_gender.Location = new System.Drawing.Point(14, 79);
            this.cbo_gender.Name = "cbo_gender";
            this.cbo_gender.Size = new System.Drawing.Size(163, 26);
            this.cbo_gender.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "Gender";
            // 
            // txt_hh_member_name
            // 
            this.txt_hh_member_name.Enabled = false;
            this.txt_hh_member_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_hh_member_name.Location = new System.Drawing.Point(199, 32);
            this.txt_hh_member_name.Name = "txt_hh_member_name";
            this.txt_hh_member_name.Size = new System.Drawing.Size(363, 24);
            this.txt_hh_member_name.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(196, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Name";
            // 
            // txt_hh_member_code
            // 
            this.txt_hh_member_code.Enabled = false;
            this.txt_hh_member_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_hh_member_code.Location = new System.Drawing.Point(14, 32);
            this.txt_hh_member_code.Name = "txt_hh_member_code";
            this.txt_hh_member_code.Size = new System.Drawing.Size(163, 24);
            this.txt_hh_member_code.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Household member code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "SOCY Linkages Tracking Tool(LTT)";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Azure;
            this.panel2.Controls.Add(this.cbo_village);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbo_parish);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cbo_subcouty);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cbo_district);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbo_ip);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(9, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1154, 119);
            this.panel2.TabIndex = 0;
            // 
            // cbo_village
            // 
            this.cbo_village.Enabled = false;
            this.cbo_village.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_village.FormattingEnabled = true;
            this.cbo_village.Location = new System.Drawing.Point(297, 81);
            this.cbo_village.Name = "cbo_village";
            this.cbo_village.Size = new System.Drawing.Size(268, 26);
            this.cbo_village.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Village";
            // 
            // cbo_parish
            // 
            this.cbo_parish.Enabled = false;
            this.cbo_parish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_parish.FormattingEnabled = true;
            this.cbo_parish.Location = new System.Drawing.Point(17, 81);
            this.cbo_parish.Name = "cbo_parish";
            this.cbo_parish.Size = new System.Drawing.Size(268, 26);
            this.cbo_parish.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Parish";
            // 
            // cbo_subcouty
            // 
            this.cbo_subcouty.Enabled = false;
            this.cbo_subcouty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_subcouty.FormattingEnabled = true;
            this.cbo_subcouty.Location = new System.Drawing.Point(578, 32);
            this.cbo_subcouty.Name = "cbo_subcouty";
            this.cbo_subcouty.Size = new System.Drawing.Size(347, 26);
            this.cbo_subcouty.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(575, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sub-County";
            // 
            // cbo_district
            // 
            this.cbo_district.Enabled = false;
            this.cbo_district.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_district.FormattingEnabled = true;
            this.cbo_district.Location = new System.Drawing.Point(297, 32);
            this.cbo_district.Name = "cbo_district";
            this.cbo_district.Size = new System.Drawing.Size(268, 26);
            this.cbo_district.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "District";
            // 
            // cbo_ip
            // 
            this.cbo_ip.Enabled = false;
            this.cbo_ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_ip.FormattingEnabled = true;
            this.cbo_ip.Location = new System.Drawing.Point(17, 32);
            this.cbo_ip.Name = "cbo_ip";
            this.cbo_ip.Size = new System.Drawing.Size(268, 26);
            this.cbo_ip.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Implementing Partner";
            // 
            // frm_linkages_register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1178, 799);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_linkages_register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SOCY Linkages Tracking Tool";
            this.Load += new System.EventHandler(this.frm_linkages_register_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdv_household_members)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_ip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_district;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_subcouty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_parish;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbo_village;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_hh_member_code;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_hh_member_name;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbo_gender;
        private System.Windows.Forms.TextBox txt_age;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbo_service_provider;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckedListBox chk_list_services_required;
        private System.Windows.Forms.CheckedListBox chk_list_services_received;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView gdv_household_members;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label lbl_guid;
    }
}