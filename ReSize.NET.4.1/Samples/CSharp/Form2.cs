using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace C_Sharp_Sample1
{
	/// <summary>
	/// Summary description for Form2.
	/// </summary>
	public class Form2 : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button Button1;
		private LarcomAndYoung.Windows.Forms.ReSize ReSize1;
		private System.ComponentModel.IContainer components;

		public Form2()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Label1 = new System.Windows.Forms.Label();
			this.Button1 = new System.Windows.Forms.Button();
			this.ReSize1 = new LarcomAndYoung.Windows.Forms.ReSize(this.components);
			this.SuspendLayout();
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(24, 32);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(384, 120);
			this.Label1.TabIndex = 3;
			this.Label1.Text = @"This sample application contains no code to ReSize the forms. The ReSize .NET component (invisible at runtime) handles all of the resizing.  ReSize will even handle resizing of the fonts in each control.  Just  place the ReSize component on a new or existing form.  It can't get much easier than that.";
			// 
			// Button1
			// 
			this.Button1.BackColor = System.Drawing.SystemColors.Control;
			this.Button1.Location = new System.Drawing.Point(160, 232);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(88, 24);
			this.Button1.TabIndex = 2;
			this.Button1.Text = "Exit";
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// ReSize1
			// 
			this.ReSize1.About = null;
			this.ReSize1.AutoCenterFormOnLoad = false;
			this.ReSize1.Enabled = true;
			this.ReSize1.HostContainer = this;
			this.ReSize1.InitialHostContainerHeight = 294;
			this.ReSize1.InitialHostContainerWidth = 416;
			this.ReSize1.Tag = null;
			// 
			// Form2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(416, 294);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Label1,
																		  this.Button1});
			this.Name = "Form2";
			this.Text = "ReSize Help";
			this.Load += new System.EventHandler(this.Form2_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void Form2_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
