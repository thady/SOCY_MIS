namespace SOCY_MIS
{
    partial class frmSILCGroup
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
            this.gbSILCGroup = new System.Windows.Forms.GroupBox();
            this.gbRegister = new System.Windows.Forms.GroupBox();
            this.dgvRegister = new System.Windows.Forms.DataGridView();
            this.gclRegId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclCSO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclQuarter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclFinancialYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclCycleNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbMember = new System.Windows.Forms.GroupBox();
            this.tplMemberExternal = new System.Windows.Forms.TableLayoutPanel();
            this.lblHHCodeVal = new System.Windows.Forms.Label();
            this.txtExternalMemberName = new System.Windows.Forms.TextBox();
            this.lblExternalMemberName = new System.Windows.Forms.Label();
            this.tplDisplay03 = new System.Windows.Forms.TableLayoutPanel();
            this.lblStatusReason = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatusReason = new System.Windows.Forms.RichTextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.tplMemberHousehold = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHHCode = new System.Windows.Forms.Label();
            this.cbHHCode = new System.Windows.Forms.ComboBox();
            this.lblHHMemberName = new System.Windows.Forms.Label();
            this.cbHHMember = new System.Windows.Forms.ComboBox();
            this.tplDisplay02 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSgmId = new System.Windows.Forms.Label();
            this.pnlMemberType = new System.Windows.Forms.Panel();
            this.rbtnGroupMemberExternal = new System.Windows.Forms.RadioButton();
            this.rbtnGroupMemberHousehold = new System.Windows.Forms.RadioButton();
            this.tplButton02 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMemberCancel = new System.Windows.Forms.Button();
            this.btnMemberSave = new System.Windows.Forms.Button();
            this.llblBackBottom = new System.Windows.Forms.LinkLabel();
            this.dgvMember = new System.Windows.Forms.DataGridView();
            this.gclMemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclMTPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclMTPId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.llblBackTop = new System.Windows.Forms.LinkLabel();
            this.gbNew = new System.Windows.Forms.GroupBox();
            this.tlpDisplay01 = new System.Windows.Forms.TableLayoutPanel();
            this.llblSILCSavingsRegister = new System.Windows.Forms.LinkLabel();
            this.tplButton01 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpSearch01 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSILCGroup = new System.Windows.Forms.Label();
            this.txtSILCGroup = new System.Windows.Forms.TextBox();
            this.gbSILCGroup.SuspendLayout();
            this.gbRegister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).BeginInit();
            this.gbMember.SuspendLayout();
            this.tplMemberExternal.SuspendLayout();
            this.tplDisplay03.SuspendLayout();
            this.tplMemberHousehold.SuspendLayout();
            this.tplDisplay02.SuspendLayout();
            this.pnlMemberType.SuspendLayout();
            this.tplButton02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).BeginInit();
            this.gbNew.SuspendLayout();
            this.tlpDisplay01.SuspendLayout();
            this.tplButton01.SuspendLayout();
            this.tlpSearch01.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSILCGroup
            // 
            this.gbSILCGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSILCGroup.Controls.Add(this.gbRegister);
            this.gbSILCGroup.Controls.Add(this.gbMember);
            this.gbSILCGroup.Controls.Add(this.llblBackTop);
            this.gbSILCGroup.Controls.Add(this.gbNew);
            this.gbSILCGroup.Controls.Add(this.tplButton01);
            this.gbSILCGroup.Controls.Add(this.tlpSearch01);
            this.gbSILCGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSILCGroup.Location = new System.Drawing.Point(3, 6);
            this.gbSILCGroup.Name = "gbSILCGroup";
            this.gbSILCGroup.Size = new System.Drawing.Size(904, 691);
            this.gbSILCGroup.TabIndex = 3;
            this.gbSILCGroup.TabStop = false;
            this.gbSILCGroup.Text = "SILC Group";
            // 
            // gbRegister
            // 
            this.gbRegister.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRegister.Controls.Add(this.dgvRegister);
            this.gbRegister.Location = new System.Drawing.Point(6, 486);
            this.gbRegister.Name = "gbRegister";
            this.gbRegister.Size = new System.Drawing.Size(892, 199);
            this.gbRegister.TabIndex = 27;
            this.gbRegister.TabStop = false;
            this.gbRegister.Text = "Savings Registers";
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
            this.gclRegId,
            this.gclCSO,
            this.gclQuarter,
            this.gclFinancialYear,
            this.gclCycleNumber});
            this.dgvRegister.Location = new System.Drawing.Point(6, 19);
            this.dgvRegister.MultiSelect = false;
            this.dgvRegister.Name = "dgvRegister";
            this.dgvRegister.Size = new System.Drawing.Size(880, 174);
            this.dgvRegister.TabIndex = 23;
            this.dgvRegister.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegister_CellDoubleClick);
            // 
            // gclRegId
            // 
            this.gclRegId.DataPropertyName = "ssr_id";
            this.gclRegId.HeaderText = "ID";
            this.gclRegId.Name = "gclRegId";
            this.gclRegId.ReadOnly = true;
            this.gclRegId.Visible = false;
            // 
            // gclCSO
            // 
            this.gclCSO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclCSO.DataPropertyName = "cso_name";
            this.gclCSO.HeaderText = "CSO Name";
            this.gclCSO.Name = "gclCSO";
            this.gclCSO.ReadOnly = true;
            // 
            // gclQuarter
            // 
            this.gclQuarter.DataPropertyName = "qy_name";
            this.gclQuarter.HeaderText = "Reporting Period";
            this.gclQuarter.Name = "gclQuarter";
            this.gclQuarter.ReadOnly = true;
            // 
            // gclFinancialYear
            // 
            this.gclFinancialYear.DataPropertyName = "fy_name";
            this.gclFinancialYear.HeaderText = "Financial Year";
            this.gclFinancialYear.Name = "gclFinancialYear";
            this.gclFinancialYear.ReadOnly = true;
            // 
            // gclCycleNumber
            // 
            this.gclCycleNumber.DataPropertyName = "ssr_cycle_number";
            this.gclCycleNumber.HeaderText = "Cycle Number";
            this.gclCycleNumber.Name = "gclCycleNumber";
            this.gclCycleNumber.ReadOnly = true;
            // 
            // gbMember
            // 
            this.gbMember.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMember.Controls.Add(this.tplMemberExternal);
            this.gbMember.Controls.Add(this.tplDisplay03);
            this.gbMember.Controls.Add(this.tplMemberHousehold);
            this.gbMember.Controls.Add(this.tplDisplay02);
            this.gbMember.Controls.Add(this.tplButton02);
            this.gbMember.Controls.Add(this.dgvMember);
            this.gbMember.Location = new System.Drawing.Point(6, 128);
            this.gbMember.Name = "gbMember";
            this.gbMember.Size = new System.Drawing.Size(892, 352);
            this.gbMember.TabIndex = 26;
            this.gbMember.TabStop = false;
            this.gbMember.Text = "Members";
            // 
            // tplMemberExternal
            // 
            this.tplMemberExternal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplMemberExternal.ColumnCount = 6;
            this.tplMemberExternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tplMemberExternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplMemberExternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplMemberExternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tplMemberExternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplMemberExternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplMemberExternal.Controls.Add(this.lblHHCodeVal, 2, 0);
            this.tplMemberExternal.Controls.Add(this.txtExternalMemberName, 0, 0);
            this.tplMemberExternal.Controls.Add(this.lblExternalMemberName, 0, 0);
            this.tplMemberExternal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tplMemberExternal.Location = new System.Drawing.Point(490, 19);
            this.tplMemberExternal.Name = "tplMemberExternal";
            this.tplMemberExternal.RowCount = 1;
            this.tplMemberExternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplMemberExternal.Size = new System.Drawing.Size(880, 30);
            this.tplMemberExternal.TabIndex = 54;
            this.tplMemberExternal.Visible = false;
            // 
            // lblHHCodeVal
            // 
            this.lblHHCodeVal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHHCodeVal.AutoSize = true;
            this.lblHHCodeVal.BackColor = System.Drawing.Color.White;
            this.lblHHCodeVal.ForeColor = System.Drawing.Color.Red;
            this.lblHHCodeVal.Location = new System.Drawing.Point(403, 8);
            this.lblHHCodeVal.Name = "lblHHCodeVal";
            this.lblHHCodeVal.Size = new System.Drawing.Size(11, 13);
            this.lblHHCodeVal.TabIndex = 32;
            this.lblHHCodeVal.Text = "*";
            // 
            // txtExternalMemberName
            // 
            this.txtExternalMemberName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExternalMemberName.Location = new System.Drawing.Point(153, 5);
            this.txtExternalMemberName.Name = "txtExternalMemberName";
            this.txtExternalMemberName.Size = new System.Drawing.Size(244, 20);
            this.txtExternalMemberName.TabIndex = 21;
            // 
            // lblExternalMemberName
            // 
            this.lblExternalMemberName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblExternalMemberName.AutoSize = true;
            this.lblExternalMemberName.Location = new System.Drawing.Point(3, 8);
            this.lblExternalMemberName.Name = "lblExternalMemberName";
            this.lblExternalMemberName.Size = new System.Drawing.Size(87, 13);
            this.lblExternalMemberName.TabIndex = 16;
            this.lblExternalMemberName.Text = "Member’s Name:";
            // 
            // tplDisplay03
            // 
            this.tplDisplay03.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplDisplay03.ColumnCount = 6;
            this.tplDisplay03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tplDisplay03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplDisplay03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplDisplay03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tplDisplay03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplDisplay03.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplDisplay03.Controls.Add(this.lblStatusReason, 3, 0);
            this.tplDisplay03.Controls.Add(this.lblStatus, 0, 0);
            this.tplDisplay03.Controls.Add(this.txtStatusReason, 4, 0);
            this.tplDisplay03.Controls.Add(this.chkActive, 1, 0);
            this.tplDisplay03.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tplDisplay03.Location = new System.Drawing.Point(6, 88);
            this.tplDisplay03.Name = "tplDisplay03";
            this.tplDisplay03.RowCount = 1;
            this.tplDisplay03.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplDisplay03.Size = new System.Drawing.Size(880, 60);
            this.tplDisplay03.TabIndex = 53;
            // 
            // lblStatusReason
            // 
            this.lblStatusReason.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatusReason.AutoSize = true;
            this.lblStatusReason.Location = new System.Drawing.Point(443, 23);
            this.lblStatusReason.Name = "lblStatusReason";
            this.lblStatusReason.Size = new System.Drawing.Size(80, 13);
            this.lblStatusReason.TabIndex = 22;
            this.lblStatusReason.Text = "Status Reason:";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 23);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 21;
            this.lblStatus.Text = "Status:";
            // 
            // txtStatusReason
            // 
            this.txtStatusReason.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatusReason.Location = new System.Drawing.Point(593, 3);
            this.txtStatusReason.Name = "txtStatusReason";
            this.txtStatusReason.Size = new System.Drawing.Size(244, 54);
            this.txtStatusReason.TabIndex = 23;
            this.txtStatusReason.Text = "";
            // 
            // chkActive
            // 
            this.chkActive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(153, 21);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 24;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // tplMemberHousehold
            // 
            this.tplMemberHousehold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplMemberHousehold.ColumnCount = 6;
            this.tplMemberHousehold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tplMemberHousehold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplMemberHousehold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplMemberHousehold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tplMemberHousehold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplMemberHousehold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplMemberHousehold.Controls.Add(this.label2, 2, 0);
            this.tplMemberHousehold.Controls.Add(this.label1, 5, 0);
            this.tplMemberHousehold.Controls.Add(this.lblHHCode, 0, 0);
            this.tplMemberHousehold.Controls.Add(this.cbHHCode, 1, 0);
            this.tplMemberHousehold.Controls.Add(this.lblHHMemberName, 3, 0);
            this.tplMemberHousehold.Controls.Add(this.cbHHMember, 4, 0);
            this.tplMemberHousehold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tplMemberHousehold.Location = new System.Drawing.Point(6, 59);
            this.tplMemberHousehold.Name = "tplMemberHousehold";
            this.tplMemberHousehold.RowCount = 1;
            this.tplMemberHousehold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplMemberHousehold.Size = new System.Drawing.Size(880, 30);
            this.tplMemberHousehold.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(403, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(843, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "*";
            // 
            // lblHHCode
            // 
            this.lblHHCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHHCode.AutoSize = true;
            this.lblHHCode.Location = new System.Drawing.Point(3, 8);
            this.lblHHCode.Name = "lblHHCode";
            this.lblHHCode.Size = new System.Drawing.Size(88, 13);
            this.lblHHCode.TabIndex = 14;
            this.lblHHCode.Text = "Household code:";
            // 
            // cbHHCode
            // 
            this.cbHHCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHHCode.FormattingEnabled = true;
            this.cbHHCode.Location = new System.Drawing.Point(153, 4);
            this.cbHHCode.Name = "cbHHCode";
            this.cbHHCode.Size = new System.Drawing.Size(244, 21);
            this.cbHHCode.TabIndex = 13;
            this.cbHHCode.SelectionChangeCommitted += new System.EventHandler(this.cbHHCode_SelectionChangeCommitted);
            // 
            // lblHHMemberName
            // 
            this.lblHHMemberName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHHMemberName.AutoSize = true;
            this.lblHHMemberName.Location = new System.Drawing.Point(443, 8);
            this.lblHHMemberName.Name = "lblHHMemberName";
            this.lblHHMemberName.Size = new System.Drawing.Size(87, 13);
            this.lblHHMemberName.TabIndex = 16;
            this.lblHHMemberName.Text = "Member’s Name:";
            // 
            // cbHHMember
            // 
            this.cbHHMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHHMember.FormattingEnabled = true;
            this.cbHHMember.Location = new System.Drawing.Point(593, 4);
            this.cbHHMember.Name = "cbHHMember";
            this.cbHHMember.Size = new System.Drawing.Size(244, 21);
            this.cbHHMember.TabIndex = 17;
            this.cbHHMember.SelectionChangeCommitted += new System.EventHandler(this.cbHHMember_SelectionChangeCommitted);
            // 
            // tplDisplay02
            // 
            this.tplDisplay02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplDisplay02.ColumnCount = 4;
            this.tplDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplDisplay02.Controls.Add(this.lblSgmId, 0, 0);
            this.tplDisplay02.Controls.Add(this.pnlMemberType, 0, 0);
            this.tplDisplay02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tplDisplay02.Location = new System.Drawing.Point(6, 30);
            this.tplDisplay02.Name = "tplDisplay02";
            this.tplDisplay02.RowCount = 1;
            this.tplDisplay02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplDisplay02.Size = new System.Drawing.Size(880, 30);
            this.tplDisplay02.TabIndex = 51;
            // 
            // lblSgmId
            // 
            this.lblSgmId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSgmId.AutoSize = true;
            this.lblSgmId.Location = new System.Drawing.Point(403, 8);
            this.lblSgmId.Name = "lblSgmId";
            this.lblSgmId.Size = new System.Drawing.Size(10, 13);
            this.lblSgmId.TabIndex = 22;
            this.lblSgmId.Text = "-";
            this.lblSgmId.Visible = false;
            // 
            // pnlMemberType
            // 
            this.pnlMemberType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMemberType.BackColor = System.Drawing.Color.White;
            this.pnlMemberType.Controls.Add(this.rbtnGroupMemberExternal);
            this.pnlMemberType.Controls.Add(this.rbtnGroupMemberHousehold);
            this.pnlMemberType.Location = new System.Drawing.Point(3, 5);
            this.pnlMemberType.Name = "pnlMemberType";
            this.pnlMemberType.Size = new System.Drawing.Size(394, 19);
            this.pnlMemberType.TabIndex = 21;
            // 
            // rbtnGroupMemberExternal
            // 
            this.rbtnGroupMemberExternal.AutoSize = true;
            this.rbtnGroupMemberExternal.BackColor = System.Drawing.Color.White;
            this.rbtnGroupMemberExternal.Location = new System.Drawing.Point(153, 1);
            this.rbtnGroupMemberExternal.Name = "rbtnGroupMemberExternal";
            this.rbtnGroupMemberExternal.Size = new System.Drawing.Size(104, 17);
            this.rbtnGroupMemberExternal.TabIndex = 3;
            this.rbtnGroupMemberExternal.Text = "External Member";
            this.rbtnGroupMemberExternal.UseVisualStyleBackColor = false;
            // 
            // rbtnGroupMemberHousehold
            // 
            this.rbtnGroupMemberHousehold.AutoSize = true;
            this.rbtnGroupMemberHousehold.Checked = true;
            this.rbtnGroupMemberHousehold.Location = new System.Drawing.Point(3, 1);
            this.rbtnGroupMemberHousehold.Name = "rbtnGroupMemberHousehold";
            this.rbtnGroupMemberHousehold.Size = new System.Drawing.Size(117, 17);
            this.rbtnGroupMemberHousehold.TabIndex = 2;
            this.rbtnGroupMemberHousehold.TabStop = true;
            this.rbtnGroupMemberHousehold.Text = "Household Member";
            this.rbtnGroupMemberHousehold.UseVisualStyleBackColor = true;
            this.rbtnGroupMemberHousehold.CheckedChanged += new System.EventHandler(this.rbtnGroupMemberHousehold_CheckedChanged);
            // 
            // tplButton02
            // 
            this.tplButton02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplButton02.ColumnCount = 5;
            this.tplButton02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tplButton02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tplButton02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tplButton02.Controls.Add(this.btnMemberCancel, 3, 0);
            this.tplButton02.Controls.Add(this.btnMemberSave, 1, 0);
            this.tplButton02.Controls.Add(this.llblBackBottom, 4, 0);
            this.tplButton02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tplButton02.Location = new System.Drawing.Point(6, 147);
            this.tplButton02.Name = "tplButton02";
            this.tplButton02.RowCount = 1;
            this.tplButton02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplButton02.Size = new System.Drawing.Size(880, 40);
            this.tplButton02.TabIndex = 24;
            // 
            // btnMemberCancel
            // 
            this.btnMemberCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnMemberCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberCancel.Location = new System.Drawing.Point(473, 8);
            this.btnMemberCancel.Name = "btnMemberCancel";
            this.btnMemberCancel.Size = new System.Drawing.Size(75, 23);
            this.btnMemberCancel.TabIndex = 10;
            this.btnMemberCancel.Text = "Cancel";
            this.btnMemberCancel.UseVisualStyleBackColor = true;
            this.btnMemberCancel.Click += new System.EventHandler(this.btnMemberCancel_Click);
            // 
            // btnMemberSave
            // 
            this.btnMemberSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMemberSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberSave.Location = new System.Drawing.Point(332, 8);
            this.btnMemberSave.Name = "btnMemberSave";
            this.btnMemberSave.Size = new System.Drawing.Size(75, 23);
            this.btnMemberSave.TabIndex = 2;
            this.btnMemberSave.Text = "Save";
            this.btnMemberSave.UseVisualStyleBackColor = true;
            this.btnMemberSave.Click += new System.EventHandler(this.btnMemberSave_Click);
            // 
            // llblBackBottom
            // 
            this.llblBackBottom.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.llblBackBottom.AutoSize = true;
            this.llblBackBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblBackBottom.Location = new System.Drawing.Point(845, 13);
            this.llblBackBottom.Name = "llblBackBottom";
            this.llblBackBottom.Size = new System.Drawing.Size(32, 13);
            this.llblBackBottom.TabIndex = 24;
            this.llblBackBottom.TabStop = true;
            this.llblBackBottom.Text = "Back";
            this.llblBackBottom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblBack_LinkClicked);
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
            this.gclMemID,
            this.gclName,
            this.gclMTPName,
            this.gclMTPId});
            this.dgvMember.Location = new System.Drawing.Point(6, 193);
            this.dgvMember.MultiSelect = false;
            this.dgvMember.Name = "dgvMember";
            this.dgvMember.Size = new System.Drawing.Size(880, 153);
            this.dgvMember.TabIndex = 23;
            this.dgvMember.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMember_CellDoubleClick);
            // 
            // gclMemID
            // 
            this.gclMemID.DataPropertyName = "sgm_id";
            this.gclMemID.HeaderText = "ID";
            this.gclMemID.Name = "gclMemID";
            this.gclMemID.ReadOnly = true;
            this.gclMemID.Visible = false;
            // 
            // gclName
            // 
            this.gclName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gclName.DataPropertyName = "member_name";
            this.gclName.HeaderText = "Member Name";
            this.gclName.Name = "gclName";
            this.gclName.ReadOnly = true;
            // 
            // gclMTPName
            // 
            this.gclMTPName.DataPropertyName = "mtp_name";
            this.gclMTPName.HeaderText = "Member Type";
            this.gclMTPName.Name = "gclMTPName";
            this.gclMTPName.ReadOnly = true;
            this.gclMTPName.Width = 200;
            // 
            // gclMTPId
            // 
            this.gclMTPId.DataPropertyName = "mtp_id";
            this.gclMTPId.HeaderText = "MTPId";
            this.gclMTPId.Name = "gclMTPId";
            this.gclMTPId.ReadOnly = true;
            this.gclMTPId.Visible = false;
            // 
            // llblBackTop
            // 
            this.llblBackTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblBackTop.AutoSize = true;
            this.llblBackTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblBackTop.Location = new System.Drawing.Point(866, 16);
            this.llblBackTop.Name = "llblBackTop";
            this.llblBackTop.Size = new System.Drawing.Size(32, 13);
            this.llblBackTop.TabIndex = 25;
            this.llblBackTop.TabStop = true;
            this.llblBackTop.Text = "Back";
            this.llblBackTop.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblBack_LinkClicked);
            // 
            // gbNew
            // 
            this.gbNew.Controls.Add(this.tlpDisplay01);
            this.gbNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNew.Location = new System.Drawing.Point(6, 19);
            this.gbNew.Name = "gbNew";
            this.gbNew.Size = new System.Drawing.Size(168, 102);
            this.gbNew.TabIndex = 24;
            this.gbNew.TabStop = false;
            this.gbNew.Text = "New Records";
            // 
            // tlpDisplay01
            // 
            this.tlpDisplay01.ColumnCount = 1;
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay01.Controls.Add(this.llblSILCSavingsRegister, 0, 0);
            this.tlpDisplay01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpDisplay01.Location = new System.Drawing.Point(6, 19);
            this.tlpDisplay01.Name = "tlpDisplay01";
            this.tlpDisplay01.RowCount = 2;
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay01.Size = new System.Drawing.Size(156, 75);
            this.tlpDisplay01.TabIndex = 3;
            // 
            // llblSILCSavingsRegister
            // 
            this.llblSILCSavingsRegister.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblSILCSavingsRegister.AutoSize = true;
            this.llblSILCSavingsRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblSILCSavingsRegister.Location = new System.Drawing.Point(3, 12);
            this.llblSILCSavingsRegister.Name = "llblSILCSavingsRegister";
            this.llblSILCSavingsRegister.Size = new System.Drawing.Size(117, 26);
            this.llblSILCSavingsRegister.TabIndex = 6;
            this.llblSILCSavingsRegister.TabStop = true;
            this.llblSILCSavingsRegister.Text = "SILC Savings/Meeting Register";
            this.llblSILCSavingsRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblSILCSavingsRegister_LinkClicked);
            // 
            // tplButton01
            // 
            this.tplButton01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplButton01.ColumnCount = 3;
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplButton01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplButton01.Controls.Add(this.btnSave, 0, 0);
            this.tplButton01.Controls.Add(this.btnCancel, 2, 0);
            this.tplButton01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tplButton01.Location = new System.Drawing.Point(200, 67);
            this.tplButton01.Name = "tplButton01";
            this.tplButton01.RowCount = 1;
            this.tplButton01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplButton01.Size = new System.Drawing.Size(674, 40);
            this.tplButton01.TabIndex = 19;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(239, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(360, 8);
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
            this.tlpSearch01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpSearch01.Controls.Add(this.lblSILCGroup, 0, 0);
            this.tlpSearch01.Controls.Add(this.txtSILCGroup, 1, 0);
            this.tlpSearch01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpSearch01.Location = new System.Drawing.Point(200, 38);
            this.tlpSearch01.Name = "tlpSearch01";
            this.tlpSearch01.RowCount = 1;
            this.tlpSearch01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch01.Size = new System.Drawing.Size(674, 30);
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
            this.txtSILCGroup.Size = new System.Drawing.Size(498, 20);
            this.txtSILCGroup.TabIndex = 20;
            // 
            // frmSILCGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbSILCGroup);
            this.Name = "frmSILCGroup";
            this.Size = new System.Drawing.Size(910, 700);
            this.Load += new System.EventHandler(this.frmSILCGroup_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSILCGroup_Paint);
            this.gbSILCGroup.ResumeLayout(false);
            this.gbSILCGroup.PerformLayout();
            this.gbRegister.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).EndInit();
            this.gbMember.ResumeLayout(false);
            this.tplMemberExternal.ResumeLayout(false);
            this.tplMemberExternal.PerformLayout();
            this.tplDisplay03.ResumeLayout(false);
            this.tplDisplay03.PerformLayout();
            this.tplMemberHousehold.ResumeLayout(false);
            this.tplMemberHousehold.PerformLayout();
            this.tplDisplay02.ResumeLayout(false);
            this.tplDisplay02.PerformLayout();
            this.pnlMemberType.ResumeLayout(false);
            this.pnlMemberType.PerformLayout();
            this.tplButton02.ResumeLayout(false);
            this.tplButton02.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).EndInit();
            this.gbNew.ResumeLayout(false);
            this.tlpDisplay01.ResumeLayout(false);
            this.tlpDisplay01.PerformLayout();
            this.tplButton01.ResumeLayout(false);
            this.tlpSearch01.ResumeLayout(false);
            this.tlpSearch01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSILCGroup;
        private System.Windows.Forms.GroupBox gbNew;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay01;
        private System.Windows.Forms.DataGridView dgvMember;
        private System.Windows.Forms.TableLayoutPanel tplButton01;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlpSearch01;
        private System.Windows.Forms.Label lblSILCGroup;
        private System.Windows.Forms.TextBox txtSILCGroup;
        private System.Windows.Forms.LinkLabel llblSILCSavingsRegister;
        private System.Windows.Forms.LinkLabel llblBackTop;
        private System.Windows.Forms.GroupBox gbRegister;
        private System.Windows.Forms.DataGridView dgvRegister;
        private System.Windows.Forms.GroupBox gbMember;
        private System.Windows.Forms.TableLayoutPanel tplButton02;
        private System.Windows.Forms.Button btnMemberSave;
        private System.Windows.Forms.Button btnMemberCancel;
        private System.Windows.Forms.TableLayoutPanel tplDisplay02;
        private System.Windows.Forms.Panel pnlMemberType;
        private System.Windows.Forms.RadioButton rbtnGroupMemberExternal;
        private System.Windows.Forms.RadioButton rbtnGroupMemberHousehold;
        private System.Windows.Forms.TableLayoutPanel tplDisplay03;
        private System.Windows.Forms.Label lblStatusReason;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.RichTextBox txtStatusReason;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.TableLayoutPanel tplMemberHousehold;
        private System.Windows.Forms.Label lblHHCode;
        private System.Windows.Forms.ComboBox cbHHCode;
        private System.Windows.Forms.Label lblHHMemberName;
        private System.Windows.Forms.ComboBox cbHHMember;
        private System.Windows.Forms.TableLayoutPanel tplMemberExternal;
        private System.Windows.Forms.TextBox txtExternalMemberName;
        private System.Windows.Forms.Label lblExternalMemberName;
        private System.Windows.Forms.Label lblSgmId;
        private System.Windows.Forms.Label lblHHCodeVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel llblBackBottom;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclRegId;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclCSO;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclQuarter;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclFinancialYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclCycleNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclMemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclMTPName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclMTPId;
    }
}
