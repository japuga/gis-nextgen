<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmBankMntEntry
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
	Public WithEvents cbBankStatus As System.Windows.Forms.ComboBox
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents txtCheckInfo4 As System.Windows.Forms.TextBox
	Public WithEvents txtCheckInfo3 As System.Windows.Forms.TextBox
	Public WithEvents txtCheckInfo2 As System.Windows.Forms.TextBox
	Public WithEvents txtCheckInfo1 As System.Windows.Forms.TextBox
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents txtBankAba As System.Windows.Forms.TextBox
	Public WithEvents txtBankName As System.Windows.Forms.TextBox
	Public WithEvents label7 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBankMntEntry))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cbBankStatus = New System.Windows.Forms.ComboBox
		Me.cmdOk = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.txtCheckInfo4 = New System.Windows.Forms.TextBox
		Me.txtCheckInfo3 = New System.Windows.Forms.TextBox
		Me.txtCheckInfo2 = New System.Windows.Forms.TextBox
		Me.txtCheckInfo1 = New System.Windows.Forms.TextBox
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.txtBankAba = New System.Windows.Forms.TextBox
		Me.txtBankName = New System.Windows.Forms.TextBox
		Me.label7 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Bank Information"
		Me.ClientSize = New System.Drawing.Size(365, 379)
		Me.Location = New System.Drawing.Point(4, 30)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmBankMntEntry"
		Me.cbBankStatus.Size = New System.Drawing.Size(209, 21)
		Me.cbBankStatus.Location = New System.Drawing.Point(136, 112)
		Me.cbBankStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbBankStatus.TabIndex = 16
		Me.cbBankStatus.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbBankStatus.BackColor = System.Drawing.SystemColors.Window
		Me.cbBankStatus.CausesValidation = True
		Me.cbBankStatus.Enabled = True
		Me.cbBankStatus.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbBankStatus.IntegralHeight = True
		Me.cbBankStatus.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbBankStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbBankStatus.Sorted = False
		Me.cbBankStatus.TabStop = True
		Me.cbBankStatus.Visible = True
		Me.cbBankStatus.Name = "cbBankStatus"
		Me.cmdOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOk.Text = "OK"
		Me.cmdOk.Size = New System.Drawing.Size(73, 41)
		Me.cmdOk.Location = New System.Drawing.Point(88, 328)
		Me.cmdOk.TabIndex = 14
		Me.cmdOk.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOk.CausesValidation = True
		Me.cmdOk.Enabled = True
		Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOk.TabStop = True
		Me.cmdOk.Name = "cmdOk"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(73, 41)
		Me.cmdCancel.Location = New System.Drawing.Point(206, 328)
		Me.cmdCancel.TabIndex = 13
		Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.Frame1.Text = "Check Print-out Settings"
		Me.Frame1.Size = New System.Drawing.Size(329, 169)
		Me.Frame1.Location = New System.Drawing.Point(16, 152)
		Me.Frame1.TabIndex = 8
		Me.Frame1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Name = "Frame1"
		Me.txtCheckInfo4.AutoSize = False
		Me.txtCheckInfo4.Size = New System.Drawing.Size(249, 19)
		Me.txtCheckInfo4.Location = New System.Drawing.Point(56, 128)
		Me.txtCheckInfo4.TabIndex = 7
		Me.txtCheckInfo4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtCheckInfo4.AcceptsReturn = True
		Me.txtCheckInfo4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCheckInfo4.BackColor = System.Drawing.SystemColors.Window
		Me.txtCheckInfo4.CausesValidation = True
		Me.txtCheckInfo4.Enabled = True
		Me.txtCheckInfo4.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCheckInfo4.HideSelection = True
		Me.txtCheckInfo4.ReadOnly = False
		Me.txtCheckInfo4.Maxlength = 0
		Me.txtCheckInfo4.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCheckInfo4.MultiLine = False
		Me.txtCheckInfo4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCheckInfo4.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCheckInfo4.TabStop = True
		Me.txtCheckInfo4.Visible = True
		Me.txtCheckInfo4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCheckInfo4.Name = "txtCheckInfo4"
		Me.txtCheckInfo3.AutoSize = False
		Me.txtCheckInfo3.Size = New System.Drawing.Size(249, 19)
		Me.txtCheckInfo3.Location = New System.Drawing.Point(56, 96)
		Me.txtCheckInfo3.TabIndex = 6
		Me.txtCheckInfo3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtCheckInfo3.AcceptsReturn = True
		Me.txtCheckInfo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCheckInfo3.BackColor = System.Drawing.SystemColors.Window
		Me.txtCheckInfo3.CausesValidation = True
		Me.txtCheckInfo3.Enabled = True
		Me.txtCheckInfo3.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCheckInfo3.HideSelection = True
		Me.txtCheckInfo3.ReadOnly = False
		Me.txtCheckInfo3.Maxlength = 0
		Me.txtCheckInfo3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCheckInfo3.MultiLine = False
		Me.txtCheckInfo3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCheckInfo3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCheckInfo3.TabStop = True
		Me.txtCheckInfo3.Visible = True
		Me.txtCheckInfo3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCheckInfo3.Name = "txtCheckInfo3"
		Me.txtCheckInfo2.AutoSize = False
		Me.txtCheckInfo2.Size = New System.Drawing.Size(249, 19)
		Me.txtCheckInfo2.Location = New System.Drawing.Point(56, 64)
		Me.txtCheckInfo2.TabIndex = 5
		Me.txtCheckInfo2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtCheckInfo2.AcceptsReturn = True
		Me.txtCheckInfo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCheckInfo2.BackColor = System.Drawing.SystemColors.Window
		Me.txtCheckInfo2.CausesValidation = True
		Me.txtCheckInfo2.Enabled = True
		Me.txtCheckInfo2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCheckInfo2.HideSelection = True
		Me.txtCheckInfo2.ReadOnly = False
		Me.txtCheckInfo2.Maxlength = 0
		Me.txtCheckInfo2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCheckInfo2.MultiLine = False
		Me.txtCheckInfo2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCheckInfo2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCheckInfo2.TabStop = True
		Me.txtCheckInfo2.Visible = True
		Me.txtCheckInfo2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCheckInfo2.Name = "txtCheckInfo2"
		Me.txtCheckInfo1.AutoSize = False
		Me.txtCheckInfo1.Size = New System.Drawing.Size(249, 19)
		Me.txtCheckInfo1.Location = New System.Drawing.Point(56, 32)
		Me.txtCheckInfo1.TabIndex = 4
		Me.txtCheckInfo1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtCheckInfo1.AcceptsReturn = True
		Me.txtCheckInfo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCheckInfo1.BackColor = System.Drawing.SystemColors.Window
		Me.txtCheckInfo1.CausesValidation = True
		Me.txtCheckInfo1.Enabled = True
		Me.txtCheckInfo1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCheckInfo1.HideSelection = True
		Me.txtCheckInfo1.ReadOnly = False
		Me.txtCheckInfo1.Maxlength = 0
		Me.txtCheckInfo1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCheckInfo1.MultiLine = False
		Me.txtCheckInfo1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCheckInfo1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCheckInfo1.TabStop = True
		Me.txtCheckInfo1.Visible = True
		Me.txtCheckInfo1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCheckInfo1.Name = "txtCheckInfo1"
		Me.Label6.Text = "Line 4"
		Me.Label6.Size = New System.Drawing.Size(41, 17)
		Me.Label6.Location = New System.Drawing.Point(16, 128)
		Me.Label6.TabIndex = 12
		Me.Label6.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.BackColor = System.Drawing.SystemColors.Control
		Me.Label6.Enabled = True
		Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = False
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.Label5.Text = "Line 3"
		Me.Label5.Size = New System.Drawing.Size(41, 17)
		Me.Label5.Location = New System.Drawing.Point(16, 96)
		Me.Label5.TabIndex = 11
		Me.Label5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.SystemColors.Control
		Me.Label5.Enabled = True
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.Text = "Line 2"
		Me.Label4.Size = New System.Drawing.Size(41, 17)
		Me.Label4.Location = New System.Drawing.Point(16, 64)
		Me.Label4.TabIndex = 10
		Me.Label4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.Text = "Line 1"
		Me.Label3.Size = New System.Drawing.Size(41, 17)
		Me.Label3.Location = New System.Drawing.Point(16, 32)
		Me.Label3.TabIndex = 9
		Me.Label3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.txtBankAba.AutoSize = False
		Me.txtBankAba.Size = New System.Drawing.Size(209, 21)
		Me.txtBankAba.Location = New System.Drawing.Point(136, 72)
		Me.txtBankAba.TabIndex = 3
		Me.txtBankAba.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtBankAba.AcceptsReturn = True
		Me.txtBankAba.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtBankAba.BackColor = System.Drawing.SystemColors.Window
		Me.txtBankAba.CausesValidation = True
		Me.txtBankAba.Enabled = True
		Me.txtBankAba.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtBankAba.HideSelection = True
		Me.txtBankAba.ReadOnly = False
		Me.txtBankAba.Maxlength = 0
		Me.txtBankAba.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtBankAba.MultiLine = False
		Me.txtBankAba.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtBankAba.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtBankAba.TabStop = True
		Me.txtBankAba.Visible = True
		Me.txtBankAba.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtBankAba.Name = "txtBankAba"
		Me.txtBankName.AutoSize = False
		Me.txtBankName.Size = New System.Drawing.Size(209, 21)
		Me.txtBankName.Location = New System.Drawing.Point(136, 32)
		Me.txtBankName.TabIndex = 2
		Me.txtBankName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtBankName.AcceptsReturn = True
		Me.txtBankName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtBankName.BackColor = System.Drawing.SystemColors.Window
		Me.txtBankName.CausesValidation = True
		Me.txtBankName.Enabled = True
		Me.txtBankName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtBankName.HideSelection = True
		Me.txtBankName.ReadOnly = False
		Me.txtBankName.Maxlength = 0
		Me.txtBankName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtBankName.MultiLine = False
		Me.txtBankName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtBankName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtBankName.TabStop = True
		Me.txtBankName.Visible = True
		Me.txtBankName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtBankName.Name = "txtBankName"
		Me.label7.Text = "Status"
		Me.label7.Size = New System.Drawing.Size(57, 17)
		Me.label7.Location = New System.Drawing.Point(16, 112)
		Me.label7.TabIndex = 15
		Me.label7.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.label7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.label7.BackColor = System.Drawing.SystemColors.Control
		Me.label7.Enabled = True
		Me.label7.ForeColor = System.Drawing.SystemColors.ControlText
		Me.label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label7.UseMnemonic = True
		Me.label7.Visible = True
		Me.label7.AutoSize = False
		Me.label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.label7.Name = "label7"
		Me.Label2.Text = "Routing Number"
		Me.Label2.Size = New System.Drawing.Size(97, 17)
		Me.Label2.Location = New System.Drawing.Point(16, 72)
		Me.Label2.TabIndex = 1
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "Bank Name"
		Me.Label1.Size = New System.Drawing.Size(89, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 32)
		Me.Label1.TabIndex = 0
		Me.Label1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(cbBankStatus)
		Me.Controls.Add(cmdOk)
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(Frame1)
		Me.Controls.Add(txtBankAba)
		Me.Controls.Add(txtBankName)
		Me.Controls.Add(label7)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Frame1.Controls.Add(txtCheckInfo4)
		Me.Frame1.Controls.Add(txtCheckInfo3)
		Me.Frame1.Controls.Add(txtCheckInfo2)
		Me.Frame1.Controls.Add(txtCheckInfo1)
		Me.Frame1.Controls.Add(Label6)
		Me.Frame1.Controls.Add(Label5)
		Me.Frame1.Controls.Add(Label4)
		Me.Frame1.Controls.Add(Label3)
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class