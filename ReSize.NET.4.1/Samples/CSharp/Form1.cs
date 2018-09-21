using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace C_Sharp_Sample1
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button Button5;
		internal System.Windows.Forms.Button Button4;
		internal System.Windows.Forms.Button Button3;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.RadioButton RadioButton2;
		internal System.Windows.Forms.RadioButton RadioButton1;
		internal System.Windows.Forms.CheckBox CheckBox1;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox TextBox5;
		internal System.Windows.Forms.TextBox TextBox4;
		internal System.Windows.Forms.TextBox TextBox3;
		internal System.Windows.Forms.TextBox TextBox2;
		internal System.Windows.Forms.TextBox TextBox1;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.Button Button1;
		private LarcomAndYoung.Windows.Forms.ReSize ReSize1;
		private System.ComponentModel.IContainer components;

		public Form1()
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
				if (components != null) 
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
			this.Button5 = new System.Windows.Forms.Button();
			this.Button4 = new System.Windows.Forms.Button();
			this.Button3 = new System.Windows.Forms.Button();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.RadioButton2 = new System.Windows.Forms.RadioButton();
			this.RadioButton1 = new System.Windows.Forms.RadioButton();
			this.CheckBox1 = new System.Windows.Forms.CheckBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.TextBox5 = new System.Windows.Forms.TextBox();
			this.TextBox4 = new System.Windows.Forms.TextBox();
			this.TextBox3 = new System.Windows.Forms.TextBox();
			this.TextBox2 = new System.Windows.Forms.TextBox();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.Button2 = new System.Windows.Forms.Button();
			this.Button1 = new System.Windows.Forms.Button();
			this.ReSize1 = new LarcomAndYoung.Windows.Forms.ReSize(this.components);
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Button5
			// 
			this.Button5.Location = new System.Drawing.Point(152, 256);
			this.Button5.Name = "Button5";
			this.Button5.Size = new System.Drawing.Size(128, 24);
			this.Button5.TabIndex = 26;
			this.Button5.Text = "Move things around";
			this.Button5.Click += new System.EventHandler(this.Button5_Click);
			// 
			// Button4
			// 
			this.Button4.Location = new System.Drawing.Point(320, 256);
			this.Button4.Name = "Button4";
			this.Button4.Size = new System.Drawing.Size(88, 24);
			this.Button4.TabIndex = 27;
			this.Button4.Text = "Center Form";
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			// 
			// Button3
			// 
			this.Button3.Location = new System.Drawing.Point(24, 256);
			this.Button3.Name = "Button3";
			this.Button3.Size = new System.Drawing.Size(88, 24);
			this.Button3.TabIndex = 25;
			this.Button3.Text = "Change Fonts";
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			// 
			// GroupBox1
			// 
			this.GroupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.RadioButton2,
																					this.RadioButton1,
																					this.CheckBox1});
			this.GroupBox1.Location = new System.Drawing.Point(72, 160);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(296, 72);
			this.GroupBox1.TabIndex = 24;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Misc. Info";
			// 
			// RadioButton2
			// 
			this.RadioButton2.Location = new System.Drawing.Point(160, 40);
			this.RadioButton2.Name = "RadioButton2";
			this.RadioButton2.Size = new System.Drawing.Size(120, 16);
			this.RadioButton2.TabIndex = 8;
			this.RadioButton2.Text = "Female";
			// 
			// RadioButton1
			// 
			this.RadioButton1.Location = new System.Drawing.Point(160, 16);
			this.RadioButton1.Name = "RadioButton1";
			this.RadioButton1.Size = new System.Drawing.Size(120, 16);
			this.RadioButton1.TabIndex = 7;
			this.RadioButton1.Text = "Male";
			// 
			// CheckBox1
			// 
			this.CheckBox1.Location = new System.Drawing.Point(24, 24);
			this.CheckBox1.Name = "CheckBox1";
			this.CheckBox1.Size = new System.Drawing.Size(120, 24);
			this.CheckBox1.TabIndex = 6;
			this.CheckBox1.Text = "Current Client?";
			// 
			// Label5
			// 
			this.Label5.Location = new System.Drawing.Point(320, 96);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(32, 16);
			this.Label5.TabIndex = 21;
			this.Label5.Text = "Zip:";
			this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label4
			// 
			this.Label4.Location = new System.Drawing.Point(224, 96);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(40, 16);
			this.Label4.TabIndex = 22;
			this.Label4.Text = "State:";
			this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label3
			// 
			this.Label3.Location = new System.Drawing.Point(56, 96);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(32, 16);
			this.Label3.TabIndex = 23;
			this.Label3.Text = "City:";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label2
			// 
			this.Label2.Location = new System.Drawing.Point(8, 64);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(80, 16);
			this.Label2.TabIndex = 18;
			this.Label2.Text = "Address:";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(16, 32);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(64, 16);
			this.Label1.TabIndex = 19;
			this.Label1.Text = "Name:";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TextBox5
			// 
			this.TextBox5.Location = new System.Drawing.Point(352, 96);
			this.TextBox5.Name = "TextBox5";
			this.TextBox5.Size = new System.Drawing.Size(56, 20);
			this.TextBox5.TabIndex = 20;
			this.TextBox5.Text = "";
			// 
			// TextBox4
			// 
			this.TextBox4.Location = new System.Drawing.Point(264, 96);
			this.TextBox4.Name = "TextBox4";
			this.TextBox4.Size = new System.Drawing.Size(32, 20);
			this.TextBox4.TabIndex = 17;
			this.TextBox4.Text = "";
			// 
			// TextBox3
			// 
			this.TextBox3.Location = new System.Drawing.Point(88, 96);
			this.TextBox3.Name = "TextBox3";
			this.TextBox3.Size = new System.Drawing.Size(128, 20);
			this.TextBox3.TabIndex = 16;
			this.TextBox3.Text = "";
			// 
			// TextBox2
			// 
			this.TextBox2.Location = new System.Drawing.Point(88, 64);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.Size = new System.Drawing.Size(192, 20);
			this.TextBox2.TabIndex = 15;
			this.TextBox2.Text = "";
			// 
			// TextBox1
			// 
			this.TextBox1.Location = new System.Drawing.Point(88, 32);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.Size = new System.Drawing.Size(192, 20);
			this.TextBox1.TabIndex = 14;
			this.TextBox1.Text = "";
			// 
			// Button2
			// 
			this.Button2.Location = new System.Drawing.Point(320, 56);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(88, 24);
			this.Button2.TabIndex = 28;
			this.Button2.Text = "Help";
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			// 
			// Button1
			// 
			this.Button1.Location = new System.Drawing.Point(320, 24);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(88, 24);
			this.Button1.TabIndex = 29;
			this.Button1.Text = "Exit";
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// ReSize1
			// 
			this.ReSize1.About = null;
			this.ReSize1.AutoCenterFormOnLoad = false;
			this.ReSize1.Enabled = true;
			this.ReSize1.HostContainer = this;
			this.ReSize1.InitialHostContainerHeight = 310;
			this.ReSize1.InitialHostContainerWidth = 432;
			this.ReSize1.Tag = null;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 310);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Button5,
																		  this.Button4,
																		  this.Button3,
																		  this.GroupBox1,
																		  this.Label5,
																		  this.Label4,
																		  this.Label3,
																		  this.Label2,
																		  this.Label1,
																		  this.TextBox5,
																		  this.TextBox4,
																		  this.TextBox3,
																		  this.TextBox2,
																		  this.TextBox1,
																		  this.Button2,
																		  this.Button1});
			this.Name = "Form1";
			this.Text = "ReSize .NET Sample Application (C#)";
			this.GroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			Form f = new Form2();
			f.Show();
		}

		private void Button4_Click(object sender, System.EventArgs e)
		{
			ReSize1.CenterForm();
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			FontFamily myNewFontFamily = new FontFamily("Times New Roman");

			Label1.Font = new Font(myNewFontFamily, Label1.Font.SizeInPoints, Label1.Font.Style);
			Label2.Font = new Font(myNewFontFamily, Label1.Font.SizeInPoints, Label2.Font.Style);
			Label3.Font = new Font(myNewFontFamily, Label1.Font.SizeInPoints, Label3.Font.Style);
			Label4.Font = new Font(myNewFontFamily, Label1.Font.SizeInPoints, Label4.Font.Style);
			Label5.Font = new Font(myNewFontFamily, Label1.Font.SizeInPoints, Label5.Font.Style);
		}

		private void Button5_Click(object sender, System.EventArgs e)
		{
			RadioButton1.Left = CheckBox1.Left;
			CheckBox1.Left = RadioButton2.Left;
			RadioButton2.Left = RadioButton1.Left;		
		}
	}
}
