Public Class Form2
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private components As System.ComponentModel.IContainer

    'Required by the Windows Form Designer
    
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ReSize1 As LarcomAndYoung.Windows.Forms.ReSize
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ReSize1 = New LarcomAndYoung.Windows.Forms.ReSize(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(384, 120)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "This sample application contains no code to resize the forms. The ReSize .NET com" & _
        "ponent (invisible at runtime) handles all of the resizing.  ReSize will even han" & _
        "dle resizing of the fonts in each control.  Just  place the ReSize component on " & _
        "a new or existing form.  It can't get much easier than that."
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Location = New System.Drawing.Point(160, 232)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 24)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Exit"
        '
        'ReSize1
        '
        Me.ReSize1.About = Nothing
        Me.ReSize1.AutoCenterFormOnLoad = False
        Me.ReSize1.Enabled = True
        Me.ReSize1.HostContainer = Me
        Me.ReSize1.InitialHostContainerHeight = 294
        Me.ReSize1.InitialHostContainerWidth = 416
        Me.ReSize1.Tag = Nothing
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(416, 294)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.Button1})
        Me.Name = "Form2"
        Me.Text = "ReSize - Help"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
