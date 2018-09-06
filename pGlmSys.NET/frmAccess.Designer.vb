<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmAccess
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents picLogo As System.Windows.Forms.PictureBox
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents txtPassword As System.Windows.Forms.TextBox
	Public WithEvents txtUser As System.Windows.Forms.TextBox
	Public WithEvents cbServername As System.Windows.Forms.ComboBox
	Public WithEvents cmdOptions As System.Windows.Forms.Button
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents _imgKey_3 As System.Windows.Forms.PictureBox
	Public WithEvents _imgKey_2 As System.Windows.Forms.PictureBox
	Public WithEvents _imgKey_1 As System.Windows.Forms.PictureBox
	Public WithEvents imgUnlock As System.Windows.Forms.PictureBox
	Public WithEvents imgLock As System.Windows.Forms.PictureBox
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.Panel
	Public WithEvents lVersion As System.Windows.Forms.Label
	Public WithEvents lblGlm As System.Windows.Forms.Label
	Public WithEvents imgKey As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccess))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.Frame1 = New System.Windows.Forms.Panel()
        Me.cbServername = New System.Windows.Forms.ComboBox()
        Me.cmdOptions = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me._imgKey_3 = New System.Windows.Forms.PictureBox()
        Me._imgKey_2 = New System.Windows.Forms.PictureBox()
        Me._imgKey_1 = New System.Windows.Forms.PictureBox()
        Me.imgUnlock = New System.Windows.Forms.PictureBox()
        Me.imgLock = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lVersion = New System.Windows.Forms.Label()
        Me.lblGlm = New System.Windows.Forms.Label()
        Me.imgKey = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame1.SuspendLayout()
        CType(Me._imgKey_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._imgKey_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._imgKey_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgUnlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgKey, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picLogo
        '
        Me.picLogo.BackColor = System.Drawing.SystemColors.Info
        Me.picLogo.Cursor = System.Windows.Forms.Cursors.Default
        Me.picLogo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.picLogo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.Location = New System.Drawing.Point(16, 88)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picLogo.Size = New System.Drawing.Size(172, 161)
        Me.picLogo.TabIndex = 9
        Me.picLogo.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 300
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(73, 152)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 25)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(9, 152)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(57, 25)
        Me.cmdOk.TabIndex = 4
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.AcceptsReturn = True
        Me.txtPassword.BackColor = System.Drawing.SystemColors.Window
        Me.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPassword.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPassword.Location = New System.Drawing.Point(272, 152)
        Me.txtPassword.MaxLength = 14
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPassword.Size = New System.Drawing.Size(145, 26)
        Me.txtPassword.TabIndex = 1
        '
        'txtUser
        '
        Me.txtUser.AcceptsReturn = True
        Me.txtUser.BackColor = System.Drawing.SystemColors.Window
        Me.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUser.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUser.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUser.Location = New System.Drawing.Point(272, 112)
        Me.txtUser.MaxLength = 14
        Me.txtUser.Name = "txtUser"
        Me.txtUser.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUser.Size = New System.Drawing.Size(145, 26)
        Me.txtUser.TabIndex = 0
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Desktop
        Me.Frame1.Controls.Add(Me.cbServername)
        Me.Frame1.Controls.Add(Me.cmdCancel)
        Me.Frame1.Controls.Add(Me.cmdOk)
        Me.Frame1.Controls.Add(Me.cmdOptions)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Controls.Add(Me._imgKey_3)
        Me.Frame1.Controls.Add(Me._imgKey_2)
        Me.Frame1.Controls.Add(Me._imgKey_1)
        Me.Frame1.Controls.Add(Me.imgUnlock)
        Me.Frame1.Controls.Add(Me.imgLock)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Frame1.Location = New System.Drawing.Point(194, 88)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(306, 201)
        Me.Frame1.TabIndex = 1
        Me.Frame1.Text = "Security Access"
        '
        'cbServername
        '
        Me.cbServername.BackColor = System.Drawing.SystemColors.Window
        Me.cbServername.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbServername.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbServername.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbServername.Location = New System.Drawing.Point(78, 109)
        Me.cbServername.Name = "cbServername"
        Me.cbServername.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbServername.Size = New System.Drawing.Size(145, 29)
        Me.cbServername.TabIndex = 3
        '
        'cmdOptions
        '
        Me.cmdOptions.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOptions.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOptions.Enabled = False
        Me.cmdOptions.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOptions.Location = New System.Drawing.Point(136, 152)
        Me.cmdOptions.Name = "cmdOptions"
        Me.cmdOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOptions.Size = New System.Drawing.Size(73, 25)
        Me.cmdOptions.TabIndex = 6
        Me.cmdOptions.Text = "Options>"
        Me.cmdOptions.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label3.Location = New System.Drawing.Point(8, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(73, 25)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Server"
        '
        '_imgKey_3
        '
        Me._imgKey_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._imgKey_3.Image = CType(resources.GetObject("_imgKey_3.Image"), System.Drawing.Image)
        Me.imgKey.SetIndex(Me._imgKey_3, CType(3, Short))
        Me._imgKey_3.Location = New System.Drawing.Point(224, 160)
        Me._imgKey_3.Name = "_imgKey_3"
        Me._imgKey_3.Size = New System.Drawing.Size(32, 32)
        Me._imgKey_3.TabIndex = 12
        Me._imgKey_3.TabStop = False
        '
        '_imgKey_2
        '
        Me._imgKey_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._imgKey_2.Image = CType(resources.GetObject("_imgKey_2.Image"), System.Drawing.Image)
        Me.imgKey.SetIndex(Me._imgKey_2, CType(2, Short))
        Me._imgKey_2.Location = New System.Drawing.Point(240, 160)
        Me._imgKey_2.Name = "_imgKey_2"
        Me._imgKey_2.Size = New System.Drawing.Size(32, 32)
        Me._imgKey_2.TabIndex = 13
        Me._imgKey_2.TabStop = False
        '
        '_imgKey_1
        '
        Me._imgKey_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._imgKey_1.Image = CType(resources.GetObject("_imgKey_1.Image"), System.Drawing.Image)
        Me.imgKey.SetIndex(Me._imgKey_1, CType(1, Short))
        Me._imgKey_1.Location = New System.Drawing.Point(256, 160)
        Me._imgKey_1.Name = "_imgKey_1"
        Me._imgKey_1.Size = New System.Drawing.Size(32, 32)
        Me._imgKey_1.TabIndex = 14
        Me._imgKey_1.TabStop = False
        '
        'imgUnlock
        '
        Me.imgUnlock.Cursor = System.Windows.Forms.Cursors.Default
        Me.imgUnlock.Image = CType(resources.GetObject("imgUnlock.Image"), System.Drawing.Image)
        Me.imgUnlock.Location = New System.Drawing.Point(208, 152)
        Me.imgUnlock.Name = "imgUnlock"
        Me.imgUnlock.Size = New System.Drawing.Size(32, 32)
        Me.imgUnlock.TabIndex = 15
        Me.imgUnlock.TabStop = False
        '
        'imgLock
        '
        Me.imgLock.Cursor = System.Windows.Forms.Cursors.Default
        Me.imgLock.Image = CType(resources.GetObject("imgLock.Image"), System.Drawing.Image)
        Me.imgLock.Location = New System.Drawing.Point(208, 152)
        Me.imgLock.Name = "imgLock"
        Me.imgLock.Size = New System.Drawing.Size(32, 32)
        Me.imgLock.TabIndex = 16
        Me.imgLock.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label2.Location = New System.Drawing.Point(8, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(73, 25)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Password"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(41, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "User"
        '
        'lVersion
        '
        Me.lVersion.BackColor = System.Drawing.SystemColors.Info
        Me.lVersion.Cursor = System.Windows.Forms.Cursors.Default
        Me.lVersion.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lVersion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lVersion.Location = New System.Drawing.Point(16, 264)
        Me.lVersion.Name = "lVersion"
        Me.lVersion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lVersion.Size = New System.Drawing.Size(137, 25)
        Me.lVersion.TabIndex = 12
        Me.lVersion.Text = "Release"
        Me.lVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGlm
        '
        Me.lblGlm.BackColor = System.Drawing.Color.LightYellow
        Me.lblGlm.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGlm.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGlm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblGlm.Location = New System.Drawing.Point(8, 24)
        Me.lblGlm.Name = "lblGlm"
        Me.lblGlm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGlm.Size = New System.Drawing.Size(479, 45)
        Me.lblGlm.TabIndex = 10
        Me.lblGlm.Text = "GLM  Inc."
        Me.lblGlm.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmAccess
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(26.0!, 49.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.ClientSize = New System.Drawing.Size(512, 307)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.lVersion)
        Me.Controls.Add(Me.lblGlm)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(259, 184)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAccess"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Access Window"
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame1.ResumeLayout(False)
        CType(Me._imgKey_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._imgKey_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._imgKey_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgUnlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgKey, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class