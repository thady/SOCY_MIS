namespace SOCY_MIS
{
    partial class frmSILC
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
            this.pnlPlaceHolder = new System.Windows.Forms.Panel();
            this.gbSection = new System.Windows.Forms.GroupBox();
            this.tlpDisplay01 = new System.Windows.Forms.TableLayoutPanel();
            this.llblSILCGroupRegister = new System.Windows.Forms.LinkLabel();
            this.llblSILCGroup = new System.Windows.Forms.LinkLabel();
            this.gbSection.SuspendLayout();
            this.tlpDisplay01.SuspendLayout();
            this.SuspendLayout();
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
            this.pnlPlaceHolder.TabIndex = 7;
            // 
            // gbSection
            // 
            this.gbSection.Controls.Add(this.tlpDisplay01);
            this.gbSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSection.Location = new System.Drawing.Point(3, 6);
            this.gbSection.Name = "gbSection";
            this.gbSection.Size = new System.Drawing.Size(168, 213);
            this.gbSection.TabIndex = 6;
            this.gbSection.TabStop = false;
            this.gbSection.Text = "Section";
            // 
            // tlpDisplay01
            // 
            this.tlpDisplay01.ColumnCount = 1;
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay01.Controls.Add(this.llblSILCGroupRegister, 0, 1);
            this.tlpDisplay01.Controls.Add(this.llblSILCGroup, 0, 0);
            this.tlpDisplay01.Location = new System.Drawing.Point(6, 19);
            this.tlpDisplay01.Name = "tlpDisplay01";
            this.tlpDisplay01.RowCount = 7;
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay01.Size = new System.Drawing.Size(156, 175);
            this.tlpDisplay01.TabIndex = 3;
            // 
            // llblSILCGroupRegister
            // 
            this.llblSILCGroupRegister.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblSILCGroupRegister.AutoSize = true;
            this.llblSILCGroupRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblSILCGroupRegister.Location = new System.Drawing.Point(3, 29);
            this.llblSILCGroupRegister.Name = "llblSILCGroupRegister";
            this.llblSILCGroupRegister.Size = new System.Drawing.Size(149, 13);
            this.llblSILCGroupRegister.TabIndex = 1;
            this.llblSILCGroupRegister.TabStop = true;
            this.llblSILCGroupRegister.Text = "SILC Group Financial Register";
            this.llblSILCGroupRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblSILCGroupRegister_LinkClicked);
            // 
            // llblSILCGroup
            // 
            this.llblSILCGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llblSILCGroup.AutoSize = true;
            this.llblSILCGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblSILCGroup.Location = new System.Drawing.Point(3, 5);
            this.llblSILCGroup.Name = "llblSILCGroup";
            this.llblSILCGroup.Size = new System.Drawing.Size(67, 13);
            this.llblSILCGroup.TabIndex = 4;
            this.llblSILCGroup.TabStop = true;
            this.llblSILCGroup.Text = "SILC Groups";
            this.llblSILCGroup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblSILCGroup_LinkClicked);
            // 
            // frmSILC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlPlaceHolder);
            this.Controls.Add(this.gbSection);
            this.Name = "frmSILC";
            this.Size = new System.Drawing.Size(910, 520);
            this.Load += new System.EventHandler(this.frmSILC_Load);
            this.gbSection.ResumeLayout(false);
            this.tlpDisplay01.ResumeLayout(false);
            this.tlpDisplay01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPlaceHolder;
        private System.Windows.Forms.GroupBox gbSection;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay01;
        private System.Windows.Forms.LinkLabel llblSILCGroupRegister;
        private System.Windows.Forms.LinkLabel llblSILCGroup;
    }
}
