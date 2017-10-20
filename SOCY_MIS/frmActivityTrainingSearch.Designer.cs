namespace SOCY_MIS
{
    partial class frmActivityTrainingSearch
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
            this.gbActivityTrainingSearch = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvRegister = new System.Windows.Forms.DataGridView();
            this.gclID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclCSO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclTrainingFor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclTraingDateBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclTraingDateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gclOfcId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.llblNewActivityTraining = new System.Windows.Forms.LinkLabel();
            this.tlpSearch01 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpTrainingTo = new System.Windows.Forms.DateTimePicker();
            this.dtpTrainingFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTrainingDateFrom = new System.Windows.Forms.Label();
            this.lblTrainingDateTo = new System.Windows.Forms.Label();
            this.lblCSO = new System.Windows.Forms.Label();
            this.cbCSO = new System.Windows.Forms.ComboBox();
            this.gbActivityTrainingSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).BeginInit();
            this.tplButton01.SuspendLayout();
            this.tlpSearch01.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbActivityTrainingSearch
            // 
            this.gbActivityTrainingSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbActivityTrainingSearch.Controls.Add(this.btnDelete);
            this.gbActivityTrainingSearch.Controls.Add(this.dgvRegister);
            this.gbActivityTrainingSearch.Controls.Add(this.tplButton01);
            this.gbActivityTrainingSearch.Controls.Add(this.llblNewActivityTraining);
            this.gbActivityTrainingSearch.Controls.Add(this.tlpSearch01);
            this.gbActivityTrainingSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbActivityTrainingSearch.Location = new System.Drawing.Point(3, 6);
            this.gbActivityTrainingSearch.Name = "gbActivityTrainingSearch";
            this.gbActivityTrainingSearch.Size = new System.Drawing.Size(714, 497);
            this.gbActivityTrainingSearch.TabIndex = 0;
            this.gbActivityTrainingSearch.TabStop = false;
            this.gbActivityTrainingSearch.Text = "Activity Training Search";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(633, 468);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvRegister
            // 
            this.dgvRegister.AllowUserToAddRows = false;
            this.dgvRegister.AllowUserToDeleteRows = false;
            this.dgvRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegister.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gclID,
            this.gclCSO,
            this.gclTrainingFor,
            this.gclTraingDateBegin,
            this.gclTraingDateEnd,
            this.gclDelete,
            this.gclOfcId});
            this.dgvRegister.Location = new System.Drawing.Point(6, 145);
            this.dgvRegister.MultiSelect = false;
            this.dgvRegister.Name = "dgvRegister";
            this.dgvRegister.Size = new System.Drawing.Size(702, 314);
            this.dgvRegister.TabIndex = 20;
            this.dgvRegister.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegister_CellDoubleClick);
            this.dgvRegister.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvRegister_RowPostPaint);
            // 
            // gclID
            // 
            this.gclID.DataPropertyName = "at_id";
            this.gclID.HeaderText = "ID";
            this.gclID.Name = "gclID";
            this.gclID.ReadOnly = true;
            this.gclID.Visible = false;
            // 
            // gclCSO
            // 
            this.gclCSO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclCSO.DataPropertyName = "cso_name";
            this.gclCSO.HeaderText = "CSO";
            this.gclCSO.Name = "gclCSO";
            this.gclCSO.ReadOnly = true;
            // 
            // gclTrainingFor
            // 
            this.gclTrainingFor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclTrainingFor.DataPropertyName = "at_training_for";
            this.gclTrainingFor.HeaderText = "Training For";
            this.gclTrainingFor.Name = "gclTrainingFor";
            this.gclTrainingFor.ReadOnly = true;
            // 
            // gclTraingDateBegin
            // 
            this.gclTraingDateBegin.DataPropertyName = "at_date_begin";
            this.gclTraingDateBegin.HeaderText = "Start Date";
            this.gclTraingDateBegin.Name = "gclTraingDateBegin";
            this.gclTraingDateBegin.ReadOnly = true;
            this.gclTraingDateBegin.Width = 150;
            // 
            // gclTraingDateEnd
            // 
            this.gclTraingDateEnd.DataPropertyName = "at_date_end";
            this.gclTraingDateEnd.HeaderText = "End Date";
            this.gclTraingDateEnd.Name = "gclTraingDateEnd";
            this.gclTraingDateEnd.ReadOnly = true;
            this.gclTraingDateEnd.Width = 150;
            // 
            // gclDelete
            // 
            this.gclDelete.HeaderText = "Delete";
            this.gclDelete.Name = "gclDelete";
            // 
            // gclOfcId
            // 
            this.gclOfcId.DataPropertyName = "ofc_id";
            this.gclOfcId.HeaderText = "OfficeId";
            this.gclOfcId.Name = "gclOfcId";
            this.gclOfcId.ReadOnly = true;
            this.gclOfcId.Visible = false;
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
            this.tplButton01.Location = new System.Drawing.Point(30, 99);
            this.tplButton01.Name = "tplButton01";
            this.tplButton01.RowCount = 1;
            this.tplButton01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplButton01.Size = new System.Drawing.Size(654, 40);
            this.tplButton01.TabIndex = 19;
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
            // llblNewActivityTraining
            // 
            this.llblNewActivityTraining.AutoSize = true;
            this.llblNewActivityTraining.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblNewActivityTraining.Location = new System.Drawing.Point(16, 20);
            this.llblNewActivityTraining.Name = "llblNewActivityTraining";
            this.llblNewActivityTraining.Size = new System.Drawing.Size(107, 13);
            this.llblNewActivityTraining.TabIndex = 18;
            this.llblNewActivityTraining.TabStop = true;
            this.llblNewActivityTraining.Text = "New Activity Training";
            this.llblNewActivityTraining.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblNewActivityTraining_LinkClicked);
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
            this.tlpSearch01.Controls.Add(this.dtpTrainingTo, 4, 1);
            this.tlpSearch01.Controls.Add(this.dtpTrainingFrom, 1, 1);
            this.tlpSearch01.Controls.Add(this.lblTrainingDateFrom, 0, 1);
            this.tlpSearch01.Controls.Add(this.lblTrainingDateTo, 3, 1);
            this.tlpSearch01.Controls.Add(this.lblCSO, 0, 0);
            this.tlpSearch01.Controls.Add(this.cbCSO, 1, 0);
            this.tlpSearch01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpSearch01.Location = new System.Drawing.Point(30, 40);
            this.tlpSearch01.Name = "tlpSearch01";
            this.tlpSearch01.RowCount = 2;
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearch01.Size = new System.Drawing.Size(654, 60);
            this.tlpSearch01.TabIndex = 0;
            // 
            // dtpTrainingTo
            // 
            this.dtpTrainingTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpTrainingTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTrainingTo.Location = new System.Drawing.Point(460, 35);
            this.dtpTrainingTo.Name = "dtpTrainingTo";
            this.dtpTrainingTo.Size = new System.Drawing.Size(115, 20);
            this.dtpTrainingTo.TabIndex = 13;
            // 
            // dtpTrainingFrom
            // 
            this.dtpTrainingFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpTrainingFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTrainingFrom.Location = new System.Drawing.Point(133, 35);
            this.dtpTrainingFrom.Name = "dtpTrainingFrom";
            this.dtpTrainingFrom.Size = new System.Drawing.Size(115, 20);
            this.dtpTrainingFrom.TabIndex = 15;
            // 
            // lblTrainingDateFrom
            // 
            this.lblTrainingDateFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTrainingDateFrom.AutoSize = true;
            this.lblTrainingDateFrom.Location = new System.Drawing.Point(3, 38);
            this.lblTrainingDateFrom.Name = "lblTrainingDateFrom";
            this.lblTrainingDateFrom.Size = new System.Drawing.Size(124, 13);
            this.lblTrainingDateFrom.TabIndex = 14;
            this.lblTrainingDateFrom.Text = "Training Between Dates:";
            // 
            // lblTrainingDateTo
            // 
            this.lblTrainingDateTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTrainingDateTo.AutoSize = true;
            this.lblTrainingDateTo.Location = new System.Drawing.Point(330, 38);
            this.lblTrainingDateTo.Name = "lblTrainingDateTo";
            this.lblTrainingDateTo.Size = new System.Drawing.Size(25, 13);
            this.lblTrainingDateTo.TabIndex = 16;
            this.lblTrainingDateTo.Text = "and";
            // 
            // lblCSO
            // 
            this.lblCSO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCSO.AutoSize = true;
            this.lblCSO.Location = new System.Drawing.Point(3, 8);
            this.lblCSO.Name = "lblCSO";
            this.lblCSO.Size = new System.Drawing.Size(60, 13);
            this.lblCSO.TabIndex = 17;
            this.lblCSO.Text = "CSO Code:";
            // 
            // cbCSO
            // 
            this.cbCSO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCSO.FormattingEnabled = true;
            this.cbCSO.Location = new System.Drawing.Point(133, 4);
            this.cbCSO.Name = "cbCSO";
            this.cbCSO.Size = new System.Drawing.Size(171, 21);
            this.cbCSO.TabIndex = 18;
            // 
            // frmActivityTrainingSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbActivityTrainingSearch);
            this.Name = "frmActivityTrainingSearch";
            this.Size = new System.Drawing.Size(720, 503);
            this.Load += new System.EventHandler(this.frmActivityTrainingSearch_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmActivityTrainingSearch_Paint);
            this.gbActivityTrainingSearch.ResumeLayout(false);
            this.gbActivityTrainingSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).EndInit();
            this.tplButton01.ResumeLayout(false);
            this.tlpSearch01.ResumeLayout(false);
            this.tlpSearch01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbActivityTrainingSearch;
        private System.Windows.Forms.TableLayoutPanel tlpSearch01;
        private System.Windows.Forms.LinkLabel llblNewActivityTraining;
        private System.Windows.Forms.DateTimePicker dtpTrainingTo;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvRegister;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblTrainingDateFrom;
        private System.Windows.Forms.DateTimePicker dtpTrainingFrom;
        private System.Windows.Forms.Label lblTrainingDateTo;
        private System.Windows.Forms.Label lblCSO;
        private System.Windows.Forms.ComboBox cbCSO;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclCSO;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclTrainingFor;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclTraingDateBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclTraingDateEnd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gclDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclOfcId;
    }
}
