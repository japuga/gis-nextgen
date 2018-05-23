<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmUserEntry
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
	Public WithEvents cmdPassword As System.Windows.Forms.Button
	Public WithEvents cbTypeId As System.Windows.Forms.ComboBox
	Public WithEvents cbTypeName As System.Windows.Forms.ComboBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents txtUserDesc As System.Windows.Forms.TextBox
	Public WithEvents txtUserName As System.Windows.Forms.TextBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmUserEntry))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdPassword = New System.Windows.Forms.Button
		Me.cbTypeId = New System.Windows.Forms.ComboBox
		Me.cbTypeName = New System.Windows.Forms.ComboBox
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdOk = New System.Windows.Forms.Button
		Me.txtUserDesc = New System.Windows.Forms.TextBox
		Me.txtUserName = New System.Windows.Forms.TextBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "User Data Entry"
		Me.ClientSize = New System.Drawing.Size(369, 227)
		Me.Location = New System.Drawing.Point(299, 112)
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
		Me.Name = "frmUserEntry"
		Me.cmdPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPassword.Text = "Change Password"
		Me.cmdPassword.Size = New System.Drawing.Size(129, 25)
		Me.cmdPassword.Location = New System.Drawing.Point(224, 24)
		Me.cmdPassword.TabIndex = 9
		Me.cmdPassword.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdPassword.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPassword.CausesValidation = True
		Me.cmdPassword.Enabled = True
		Me.cmdPassword.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPassword.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPassword.TabStop = True
		Me.cmdPassword.Name = "cmdPassword"
		Me.cbTypeId.Size = New System.Drawing.Size(65, 21)
		Me.cbTypeId.Location = New System.Drawing.Point(288, 104)
		Me.cbTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbTypeId.TabIndex = 8
		Me.cbTypeId.Visible = False
		Me.cbTypeId.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbTypeId.BackColor = System.Drawing.SystemColors.Window
		Me.cbTypeId.CausesValidation = True
		Me.cbTypeId.Enabled = True
		Me.cbTypeId.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbTypeId.IntegralHeight = True
		Me.cbTypeId.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbTypeId.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbTypeId.Sorted = False
		Me.cbTypeId.TabStop = True
		Me.cbTypeId.Name = "cbTypeId"
		Me.cbTypeName.Size = New System.Drawing.Size(169, 21)
		Me.cbTypeName.Location = New System.Drawing.Point(104, 104)
		Me.cbTypeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbTypeName.TabIndex = 7
		Me.cbTypeName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbTypeName.BackColor = System.Drawing.SystemColors.Window
		Me.cbTypeName.CausesValidation = True
		Me.cbTypeName.Enabled = True
		Me.cbTypeName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbTypeName.IntegralHeight = True
		Me.cbTypeName.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbTypeName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbTypeName.Sorted = False
		Me.cbTypeName.TabStop = True
		Me.cbTypeName.Visible = True
		Me.cbTypeName.Name = "cbTypeName"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(65, 41)
		Me.cmdCancel.Location = New System.Drawing.Point(200, 160)
		Me.cmdCancel.TabIndex = 5
		Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOk.Text = "OK"
		Me.cmdOk.Size = New System.Drawing.Size(65, 41)
		Me.cmdOk.Location = New System.Drawing.Point(104, 160)
		Me.cmdOk.TabIndex = 4
		Me.cmdOk.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOk.CausesValidation = True
		Me.cmdOk.Enabled = True
		Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOk.TabStop = True
		Me.cmdOk.Name = "cmdOk"
		Me.txtUserDesc.AutoSize = False
		Me.txtUserDesc.Size = New System.Drawing.Size(241, 21)
		Me.txtUserDesc.Location = New System.Drawing.Point(104, 64)
		Me.txtUserDesc.TabIndex = 3
		Me.txtUserDesc.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtUserDesc.AcceptsReturn = True
		Me.txtUserDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtUserDesc.BackColor = System.Drawing.SystemColors.Window
		Me.txtUserDesc.CausesValidation = True
		Me.txtUserDesc.Enabled = True
		Me.txtUserDesc.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtUserDesc.HideSelection = True
		Me.txtUserDesc.ReadOnly = False
		Me.txtUserDesc.Maxlength = 0
		Me.txtUserDesc.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtUserDesc.MultiLine = False
		Me.txtUserDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtUserDesc.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtUserDesc.TabStop = True
		Me.txtUserDesc.Visible = True
		Me.txtUserDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtUserDesc.Name = "txtUserDesc"
		Me.txtUserName.AutoSize = False
		Me.txtUserName.Size = New System.Drawing.Size(105, 21)
		Me.txtUserName.Location = New System.Drawing.Point(104, 24)
		Me.txtUserName.TabIndex = 2
		Me.txtUserName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtUserName.AcceptsReturn = True
		Me.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtUserName.BackColor = System.Drawing.SystemColors.Window
		Me.txtUserName.CausesValidation = True
		Me.txtUserName.Enabled = True
		Me.txtUserName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtUserName.HideSelection = True
		Me.txtUserName.ReadOnly = False
		Me.txtUserName.Maxlength = 0
		Me.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtUserName.MultiLine = False
		Me.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtUserName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtUserName.TabStop = True
		Me.txtUserName.Visible = True
		Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtUserName.Name = "txtUserName"
		Me.Label3.Text = "Type"
		Me.Label3.Size = New System.Drawing.Size(65, 17)
		Me.Label3.Location = New System.Drawing.Point(24, 104)
		Me.Label3.TabIndex = 6
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
		Me.Label2.Text = "Description"
		Me.Label2.Size = New System.Drawing.Size(65, 17)
		Me.Label2.Location = New System.Drawing.Point(24, 64)
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
		Me.Label1.Text = "User ID"
		Me.Label1.Size = New System.Drawing.Size(65, 17)
		Me.Label1.Location = New System.Drawing.Point(24, 24)
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
		Me.Controls.Add(cmdPassword)
		Me.Controls.Add(cbTypeId)
		Me.Controls.Add(cbTypeName)
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(cmdOk)
		Me.Controls.Add(txtUserDesc)
		Me.Controls.Add(txtUserName)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class