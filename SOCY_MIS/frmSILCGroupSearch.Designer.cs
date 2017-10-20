namespace SOCY_MIS
{
    partial class frmSILCGroupSearch
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
            this.gbSILCGroupSearch = new System.Windows.Forms.GroupBox();
            this.llblNewGroup = new System.Windows.Forms.LinkLabel();
            this.dgvGroup = new System.Windows.Forms.DataGridView();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpSearch01 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSILCGroup = new System.Windows.Forms.Label();
            this.txtSILCGroup = new System.Windows.Forms.TextBox();
            this.gbSILCGroupSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
            this.tplButton01.SuspendLayout();
            this.tlpSearch01.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSILCGroupSearch
            // 
            this.gbSILCGroupSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSILCGroupSearch.Controls.Add(this.llblNewGroup);
            this.gbSILCGroupSearch.Controls.Add(this.dgvGroup);
            this.gbSILCGroupSearch.Controls.Add(this.tplButton01);
            this.gbSILCGroupSearch.Controls.Add(this.tlpSearch01);
            this.gbSILCGroupSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSILCGroupSearch.Location = new System.Drawing.Point(3, 6);
            this.gbSILCGroupSearch.Name = "gbSILCGroupSearch";
            this.gbSILCGroupSearch.Size = new System.Drawing.Size(904, 494);
            this.gbSILCGroupSearch.TabIndex = 2;
            this.gbSILCGroupSearch.TabStop = false;
            this.gbSILCGroupSearch.Text = "SILC Group Search";
            // 
            // llblNewGroup
            // 
            this.llblNewGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblNewGroup.AutoSize = true;
            this.llblNewGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblNewGroup.Location = new System.Drawing.Point(16, 20);
            this.llblNewGroup.Name = "llblNewGroup";
            this.llblNewGroup.Size = new System.Drawing.Size(87, 13);
            this.llblNewGroup.TabIndex = 18;
            this.llblNewGroup.TabStop = true;
            this.llblNewGroup.Text = "New SILC Group";
            this.llblNewGroup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblNewGroup_LinkClicked);
            // 
            // dgvGroup
            // 
            this.dgvGroup.AllowUserToAddRows = false;
            this.dgvGroup.AllowUserToDeleteRows = false;
            this.dgvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gclID,
            this.gclName});
            this.dgvGroup.Location = new System.Drawing.Point(6, 138);
            this.dgvGroup.MultiSelect = false;
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.Size = new System.Drawing.Size(892, 350);
            this.dgvGroup.TabIndex = 23;
            this.dgvGroup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroup_CellDoubleClick);
            // 
            // gclID
            // 
            this.gclID.DataPropertyName = "sg_id";
            this.gclID.HeaderText = "ID";
            this.gclID.Name = "gclID";
            this.gclID.ReadOnly = true;
            this.gclID.Visible = false;
            // 
            // gclName
            // 
            this.gclName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclName.DataPropertyName = "sg_name";
            this.gclName.HeaderText = "Group Name";
            this.gclName.Name = "gclName";
            this.gclName.ReadOnly = true;
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
            this.tplButton01.Location = new System.Drawing.Point(30, 72);
            this.tplButton01.Name = "tplButton01";
            this.tplButton01.RowCount = 1;
            this.tplButton01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplButton01.Size = new System.Drawing.Size(844, 40);
            this.tplButton01.TabIndex = 19;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(324, 8);
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
            this.btnCancel.Location = new System.Drawing.Point(445, 8);
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
            this.tlpSearch01.ColumnCount = 3;
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSearch01.Controls.Add(this.lblSILCGroup, 0, 0);
            this.tlpSearch01.Controls.Add(this.txtSILCGroup, 1, 0);
            this.tlpSearch01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpSearch01.Location = new System.Drawing.Point(30, 43);
            this.tlpSearch01.Name = "tlpSearch01";
            this.tlpSearch01.RowCount = 1;
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch01.Size = new System.Drawing.Size(844, 30);
            this.tlpSearch01.TabIndex = 0;
            // 
            // lblSILCGroup
            // 
            this.lblSILCGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSILCGroup.AutoSize = true;
            this.lblSILCGroup.Location = new System.Drawing.Point(3, 8);
            this.lblSILCGroup.Name = "lblSILCGroup";
            this.lblSILCGroup.Size = new System.Drawing.Size(96, 13);
            this.lblSILCGroup.TabIndex = 0;
            this.lblSILCGroup.Text = "SILC Group Name:";
            // 
            // txtSILCGroup
            // 
            this.txtSILCGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSILCGroup.Location = new System.Drawing.Point(133, 5);
            this.txtSILCGroup.Name = "txtSILCGroup";
            this.txtSILCGroup.Size = new System.Drawing.Size(688, 20);
            this.txtSILCGroup.TabIndex = 20;
            // 
            // frmSILCGroupSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbSILCGroupSearch);
            this.Name = "frmSILCGroupSearch";
            this.Size = new System.Drawing.Size(910, 503);
            this.Load += new System.EventHandler(this.frmSILCGroupSearch_Load);
            this.gbSILCGroupSearch.ResumeLayout(false);
            this.gbSILCGroupSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            this.tplButton01.ResumeLayout(false);
            this.tlpSearch01.ResumeLayout(false);
            this.tlpSearch01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSILCGroupSearch;
        private System.Windows.Forms.DataGridView dgvGroup;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel llblNewGroup;
        private System.Windows.Forms.TableLayoutPanel tlpSearch01;
        private System.Windows.Forms.Label lblSILCGroup;
        private System.Windows.Forms.TextBox txtSILCGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclName;
    }
}
