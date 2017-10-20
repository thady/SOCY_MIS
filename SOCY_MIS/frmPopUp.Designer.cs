namespace SOCY_MIS
{
    partial class frmPopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPopUp));
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.lblErrorDisplay = new System.Windows.Forms.Label();
            this.lblErrorVisibility = new System.Windows.Forms.Label();
            this.txtError = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(100, 25);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 13);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Message";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOk.Location = new System.Drawing.Point(166, 79);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pbImage
            // 
            this.pbImage.Image = global::SOCY_MIS.Properties.Resources.Info;
            this.pbImage.Location = new System.Drawing.Point(13, 13);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(70, 70);
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // lblErrorDisplay
            // 
            this.lblErrorDisplay.AutoSize = true;
            this.lblErrorDisplay.Location = new System.Drawing.Point(12, 84);
            this.lblErrorDisplay.Name = "lblErrorDisplay";
            this.lblErrorDisplay.Size = new System.Drawing.Size(66, 13);
            this.lblErrorDisplay.TabIndex = 4;
            this.lblErrorDisplay.Text = "Display Error";
            // 
            // lblErrorVisibility
            // 
            this.lblErrorVisibility.AutoSize = true;
            this.lblErrorVisibility.Location = new System.Drawing.Point(84, 84);
            this.lblErrorVisibility.Name = "lblErrorVisibility";
            this.lblErrorVisibility.Size = new System.Drawing.Size(13, 13);
            this.lblErrorVisibility.TabIndex = 5;
            this.lblErrorVisibility.Text = "+";
            this.lblErrorVisibility.Click += new System.EventHandler(this.lblErrorVisibility_Click);
            // 
            // txtError
            // 
            this.txtError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtError.Location = new System.Drawing.Point(15, 106);
            this.txtError.Name = "txtError";
            this.txtError.ReadOnly = true;
            this.txtError.Size = new System.Drawing.Size(357, 245);
            this.txtError.TabIndex = 6;
            this.txtError.Text = "";
            this.txtError.Visible = false;
            // 
            // frmPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 115);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.lblErrorVisibility);
            this.Controls.Add(this.lblErrorDisplay);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pbImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message";
            this.Load += new System.EventHandler(this.frmPopUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblErrorDisplay;
        private System.Windows.Forms.Label lblErrorVisibility;
        private System.Windows.Forms.RichTextBox txtError;
    }
}