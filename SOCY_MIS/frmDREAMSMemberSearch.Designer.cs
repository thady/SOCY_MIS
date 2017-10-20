namespace SOCY_MIS
{
    partial class frmDREAMSMemberSearch
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
            this.gbMemberSearch = new System.Windows.Forms.GroupBox();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpSearch01 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSubCounty = new System.Windows.Forms.Label();
            this.cbSubCounty = new System.Windows.Forms.ComboBox();
            this.cbDistrict = new System.Windows.Forms.ComboBox();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.lblWard = new System.Windows.Forms.Label();
            this.cbWard = new System.Windows.Forms.ComboBox();
            this.lblMember = new System.Windows.Forms.Label();
            this.cbMember = new System.Windows.Forms.ComboBox();
            this.dgvMember = new System.Windows.Forms.DataGridView();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclIdNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDistrict = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclSubCounty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbMemberSearch.SuspendLayout();
            this.tplButton01.SuspendLayout();
            this.tlpSearch01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMemberSearch
            // 
            this.gbMemberSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMemberSearch.Controls.Add(this.tplButton01);
            this.gbMemberSearch.Controls.Add(this.tlpSearch01);
            this.gbMemberSearch.Controls.Add(this.dgvMember);
            this.gbMemberSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMemberSearch.Location = new System.Drawing.Point(3, 6);
            this.gbMemberSearch.Name = "gbMemberSearch";
            this.gbMemberSearch.Size = new System.Drawing.Size(714, 494);
            this.gbMemberSearch.TabIndex = 3;
            this.gbMemberSearch.TabStop = false;
            this.gbMemberSearch.Text = "Member Search";
            // 
            // tplButton01
            // 
            this.tplButton01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplButton01.ColumnCount = 3;
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.Controls.Add(this.btnSearch, 0, 0);
            this.tplButton01.Controls.Add(this.btnCancel, 2, 0);
            this.tplButton01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tplButton01.Location = new System.Drawing.Point(30, 89);
            this.tplButton01.Name = "tplButton01";
            this.tplButton01.RowCount = 1;
            this.tplButton01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplButton01.Size = new System.Drawing.Size(654, 40);
            this.tplButton01.TabIndex = 25;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(229, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(350, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tlpSearch01
            // 
            this.tlpSearch01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpSearch01.ColumnCount = 6;
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSearch01.Controls.Add(this.lblSubCounty, 0, 1);
            this.tlpSearch01.Controls.Add(this.cbSubCounty, 1, 1);
            this.tlpSearch01.Controls.Add(this.cbDistrict, 4, 0);
            this.tlpSearch01.Controls.Add(this.lblDistrict, 3, 0);
            this.tlpSearch01.Controls.Add(this.lblWard, 3, 1);
            this.tlpSearch01.Controls.Add(this.cbWard, 4, 1);
            this.tlpSearch01.Controls.Add(this.lblMember, 0, 0);
            this.tlpSearch01.Controls.Add(this.cbMember, 1, 0);
            this.tlpSearch01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpSearch01.Location = new System.Drawing.Point(30, 30);
            this.tlpSearch01.Name = "tlpSearch01";
            this.tlpSearch01.RowCount = 2;
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSearch01.Size = new System.Drawing.Size(654, 60);
            this.tlpSearch01.TabIndex = 24;
            // 
            // lblSubCounty
            // 
            this.lblSubCounty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubCounty.AutoSize = true;
            this.lblSubCounty.Location = new System.Drawing.Point(3, 38);
            this.lblSubCounty.Name = "lblSubCounty";
            this.lblSubCounty.Size = new System.Drawing.Size(65, 13);
            this.lblSubCounty.TabIndex = 15;
            this.lblSubCounty.Text = "Sub County:";
            // 
            // cbSubCounty
            // 
            this.cbSubCounty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSubCounty.FormattingEnabled = true;
            this.cbSubCounty.Location = new System.Drawing.Point(133, 34);
            this.cbSubCounty.Name = "cbSubCounty";
            this.cbSubCounty.Size = new System.Drawing.Size(171, 21);
            this.cbSubCounty.TabIndex = 17;
            this.cbSubCounty.SelectionChangeCommitted += new System.EventHandler(this.cbSubCounty_SelectionChangeCommitted);
            // 
            // cbDistrict
            // 
            this.cbDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDistrict.FormattingEnabled = true;
            this.cbDistrict.Location = new System.Drawing.Point(460, 4);
            this.cbDistrict.Name = "cbDistrict";
            this.cbDistrict.Size = new System.Drawing.Size(171, 21);
            this.cbDistrict.TabIndex = 18;
            this.cbDistrict.SelectionChangeCommitted += new System.EventHandler(this.cbDistrict_SelectionChangeCommitted);
            // 
            // lblDistrict
            // 
            this.lblDistrict.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Location = new System.Drawing.Point(330, 8);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(42, 13);
            this.lblDistrict.TabIndex = 16;
            this.lblDistrict.Text = "District:";
            // 
            // lblWard
            // 
            this.lblWard.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblWard.AutoSize = true;
            this.lblWard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWard.Location = new System.Drawing.Point(330, 38);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(70, 13);
            this.lblWard.TabIndex = 19;
            this.lblWard.Text = "Parish/Ward:";
            // 
            // cbWard
            // 
            this.cbWard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbWard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWard.FormattingEnabled = true;
            this.cbWard.Location = new System.Drawing.Point(460, 34);
            this.cbWard.Name = "cbWard";
            this.cbWard.Size = new System.Drawing.Size(171, 21);
            this.cbWard.TabIndex = 20;
            this.cbWard.SelectionChangeCommitted += new System.EventHandler(this.cbWard_SelectionChangeCommitted);
            // 
            // lblMember
            // 
            this.lblMember.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMember.AutoSize = true;
            this.lblMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMember.Location = new System.Drawing.Point(3, 8);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(48, 13);
            this.lblMember.TabIndex = 21;
            this.lblMember.Text = "Member:";
            // 
            // cbMember
            // 
            this.cbMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMember.FormattingEnabled = true;
            this.cbMember.Location = new System.Drawing.Point(133, 4);
            this.cbMember.Name = "cbMember";
            this.cbMember.Size = new System.Drawing.Size(171, 21);
            this.cbMember.TabIndex = 22;
            // 
            // dgvMember
            // 
            this.dgvMember.AllowUserToAddRows = false;
            this.dgvMember.AllowUserToDeleteRows = false;
            this.dgvMember.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMember.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gclID,
            this.gclIdNo,
            this.gclName,
            this.gclDistrict,
            this.gclSubCounty});
            this.dgvMember.Location = new System.Drawing.Point(6, 135);
            this.dgvMember.MultiSelect = false;
            this.dgvMember.Name = "dgvMember";
            this.dgvMember.Size = new System.Drawing.Size(702, 353);
            this.dgvMember.TabIndex = 23;
            this.dgvMember.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMember_CellDoubleClick);
            // 
            // gclID
            // 
            this.gclID.DataPropertyName = "dm_id";
            this.gclID.HeaderText = "ID";
            this.gclID.Name = "gclID";
            this.gclID.ReadOnly = true;
            this.gclID.Visible = false;
            // 
            // gclIdNo
            // 
            this.gclIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclIdNo.DataPropertyName = "dm_id_no";
            this.gclIdNo.HeaderText = "Member ID";
            this.gclIdNo.Name = "gclIdNo";
            this.gclIdNo.ReadOnly = true;
            // 
            // gclName
            // 
            this.gclName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclName.DataPropertyName = "member_name";
            this.gclName.HeaderText = "Member Name";
            this.gclName.Name = "gclName";
            this.gclName.ReadOnly = true;
            // 
            // gclDistrict
            // 
            this.gclDistrict.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclDistrict.DataPropertyName = "dst_name";
            this.gclDistrict.HeaderText = "District";
            this.gclDistrict.Name = "gclDistrict";
            this.gclDistrict.ReadOnly = true;
            // 
            // gclSubCounty
            // 
            this.gclSubCounty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclSubCounty.DataPropertyName = "sct_name";
            this.gclSubCounty.HeaderText = "Sub County";
            this.gclSubCounty.Name = "gclSubCounty";
            this.gclSubCounty.ReadOnly = true;
            // 
            // frmDREAMSMemberSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbMemberSearch);
            this.Name = "frmDREAMSMemberSearch";
            this.Size = new System.Drawing.Size(720, 503);
            this.Load += new System.EventHandler(this.frmDREAMSMemberSearch_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmDREAMSMemberSearch_Paint);
            this.gbMemberSearch.ResumeLayout(false);
            this.tplButton01.ResumeLayout(false);
            this.tlpSearch01.ResumeLayout(false);
            this.tlpSearch01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMemberSearch;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlpSearch01;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.ComboBox cbDistrict;
        private System.Windows.Forms.Label lblSubCounty;
        private System.Windows.Forms.ComboBox cbSubCounty;
        private System.Windows.Forms.DataGridView dgvMember;
        private System.Windows.Forms.Label lblWard;
        private System.Windows.Forms.ComboBox cbWard;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.ComboBox cbMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclIdNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclDistrict;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclSubCounty;
    }
}
