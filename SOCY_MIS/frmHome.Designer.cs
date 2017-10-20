namespace SOCY_MIS
{
    partial class frmHome
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
            this.lblMessageWelcome = new System.Windows.Forms.Label();
            this.gbTitle = new System.Windows.Forms.GroupBox();
            this.tlpDisplay02 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMessageServer = new System.Windows.Forms.Label();
            this.tlpDisplay01 = new System.Windows.Forms.TableLayoutPanel();
            this.gbTitle.SuspendLayout();
            this.tlpDisplay02.SuspendLayout();
            this.tlpDisplay01.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessageWelcome
            // 
            this.lblMessageWelcome.AutoSize = true;
            this.lblMessageWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageWelcome.Location = new System.Drawing.Point(3, 0);
            this.lblMessageWelcome.Name = "lblMessageWelcome";
            this.lblMessageWelcome.Size = new System.Drawing.Size(174, 13);
            this.lblMessageWelcome.TabIndex = 1;
            this.lblMessageWelcome.Text = "Welcome to the SOCY MIS system.";
            // 
            // gbTitle
            // 
            this.gbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTitle.Controls.Add(this.tlpDisplay02);
            this.gbTitle.Controls.Add(this.tlpDisplay01);
            this.gbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTitle.Location = new System.Drawing.Point(3, 6);
            this.gbTitle.Name = "gbTitle";
            this.gbTitle.Size = new System.Drawing.Size(904, 511);
            this.gbTitle.TabIndex = 3;
            this.gbTitle.TabStop = false;
            this.gbTitle.Text = "SOCY MIS";
            // 
            // tlpDisplay02
            // 
            this.tlpDisplay02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDisplay02.ColumnCount = 1;
            this.tlpDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 858F));
            this.tlpDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay02.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay02.Controls.Add(this.lblMessageServer, 0, 0);
            this.tlpDisplay02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpDisplay02.Location = new System.Drawing.Point(24, 265);
            this.tlpDisplay02.Name = "tlpDisplay02";
            this.tlpDisplay02.RowCount = 1;
            this.tlpDisplay02.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay02.Size = new System.Drawing.Size(858, 235);
            this.tlpDisplay02.TabIndex = 3;
            // 
            // lblMessageServer
            // 
            this.lblMessageServer.AutoSize = true;
            this.lblMessageServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageServer.Location = new System.Drawing.Point(3, 0);
            this.lblMessageServer.Name = "lblMessageServer";
            this.lblMessageServer.Size = new System.Drawing.Size(10, 13);
            this.lblMessageServer.TabIndex = 1;
            this.lblMessageServer.Text = "-";
            // 
            // tlpDisplay01
            // 
            this.tlpDisplay01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDisplay01.ColumnCount = 1;
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 858F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDisplay01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay01.Controls.Add(this.lblMessageWelcome, 0, 0);
            this.tlpDisplay01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpDisplay01.Location = new System.Drawing.Point(24, 24);
            this.tlpDisplay01.Name = "tlpDisplay01";
            this.tlpDisplay01.RowCount = 1;
            this.tlpDisplay01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay01.Size = new System.Drawing.Size(858, 235);
            this.tlpDisplay01.TabIndex = 2;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbTitle);
            this.Name = "frmHome";
            this.Size = new System.Drawing.Size(910, 520);
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.gbTitle.ResumeLayout(false);
            this.tlpDisplay02.ResumeLayout(false);
            this.tlpDisplay02.PerformLayout();
            this.tlpDisplay01.ResumeLayout(false);
            this.tlpDisplay01.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessageWelcome;
        private System.Windows.Forms.GroupBox gbTitle;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay01;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay02;
        private System.Windows.Forms.Label lblMessageServer;
    }
}
