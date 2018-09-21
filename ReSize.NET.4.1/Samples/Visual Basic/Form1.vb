Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Private components As System.ComponentModel.IContainer

    'Required by the Windows Form Designer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ReSize1 As LarcomAndYoung.Windows.Forms.ReSize
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ReSize1 = New LarcomAndYoung.Windows.Forms.ReSize(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(264, 96)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(32, 20)
        Me.TextBox4.TabIndex = 4
        Me.TextBox4.Text = ""
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(352, 96)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(56, 20)
        Me.TextBox5.TabIndex = 5
        Me.TextBox5.Text = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(224, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "State:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(320, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Zip:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(320, 256)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(88, 24)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "Center Form"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(152, 256)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(128, 24)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "Move things around"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Address:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(56, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "City:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(320, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 24)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Exit"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(320, 56)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 24)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Help"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(24, 256)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(88, 24)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Change Fonts"
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(160, 16)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(120, 16)
        Me.RadioButton1.TabIndex = 7
        Me.RadioButton1.Text = "Male"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(160, 40)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(120, 16)
        Me.RadioButton2.TabIndex = 8
        Me.RadioButton2.Text = "Female"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.RadioButton2, Me.RadioButton1, Me.CheckBox1})
        Me.GroupBox1.Location = New System.Drawing.Point(72, 160)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(296, 72)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Misc. Info"
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(24, 24)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(120, 24)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "Current Client?"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(88, 64)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(192, 20)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = ""
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(88, 96)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(128, 20)
        Me.TextBox3.TabIndex = 3
        Me.TextBox3.Text = ""
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(88, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(192, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = ""
        '
        'ReSize1
        '
        Me.ReSize1.About = Nothing
        Me.ReSize1.AutoCenterFormOnLoad = False
        Me.ReSize1.Enabled = True
        Me.ReSize1.HostContainer = Me
        Me.ReSize1.InitialHostContainerHeight = 310
        Me.ReSize1.InitialHostContainerWidth = 432
        Me.ReSize1.Tag = Nothing
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(432, 310)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button5, Me.Button4, Me.Button3, Me.GroupBox1, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.TextBox5, Me.TextBox4, Me.TextBox3, Me.TextBox2, Me.TextBox1, Me.Button2, Me.Button1})
        Me.Name = "Form1"
        Me.Text = "ReSize .NET Sample Application (VB)"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim f As New Form2()
        f.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ReSize1.CenterForm()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        RadioButton1.Left = CheckBox1.Left
        CheckBox1.Left = RadioButton2.Left
        RadioButton2.Left = RadioButton1.Left
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim myNewFontFamily As New FontFamily("Times New Roman")

        Label1.Font = New Font(myNewFontFamily, Label1.Font.SizeInPoints, Label1.Font.Style)
        Label2.Font = New Font(myNewFontFamily, Label1.Font.SizeInPoints, Label2.Font.Style)
        Label3.Font = New Font(myNewFontFamily, Label1.Font.SizeInPoints, Label3.Font.Style)
        Label4.Font = New Font(myNewFontFamily, Label1.Font.SizeInPoints, Label4.Font.Style)
        Label5.Font = New Font(myNewFontFamily, Label1.Font.SizeInPoints, Label5.Font.Style)
    End Sub


End Class
