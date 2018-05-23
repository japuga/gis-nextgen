<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGrpDefEntry
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
	Public WithEvents cmdMembers As System.Windows.Forms.Button
	Public WithEvents txtGrpDefId As System.Windows.Forms.TextBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents cbTypeId As System.Windows.Forms.ComboBox
	Public WithEvents txtCustName As System.Windows.Forms.TextBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGrpDefEntry))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdMembers = New System.Windows.Forms.Button
		Me.txtGrpDefId = New System.Windows.Forms.TextBox
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdOk = New System.Windows.Forms.Button
		Me.cbTypeId = New System.Windows.Forms.ComboBox
		Me.txtCustName = New System.Windows.Forms.TextBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Group Access Maintenance"
		Me.ClientSize = New System.Drawing.Size(378, 193)
		Me.Location = New System.Drawing.Point(4, 23)
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
		Me.Name = "frmGrpDefEntry"
		Me.cmdMembers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMembers.Text = "Members"
		Me.cmdMembers.Size = New System.Drawing.Size(65, 25)
		Me.cmdMembers.Location = New System.Drawing.Point(304, 80)
		Me.cmdMembers.TabIndex = 8
		Me.cmdMembers.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdMembers.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMembers.CausesValidation = True
		Me.cmdMembers.Enabled = True
		Me.cmdMembers.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMembers.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMembers.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMembers.TabStop = True
		Me.cmdMembers.Name = "cmdMembers"
		Me.txtGrpDefId.AutoSize = False
		Me.txtGrpDefId.Size = New System.Drawing.Size(193, 19)
		Me.txtGrpDefId.Location = New System.Drawing.Point(104, 80)
		Me.txtGrpDefId.TabIndex = 5
		Me.txtGrpDefId.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtGrpDefId.AcceptsReturn = True
		Me.txtGrpDefId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtGrpDefId.BackColor = System.Drawing.SystemColors.Window
		Me.txtGrpDefId.CausesValidation = True
		Me.txtGrpDefId.Enabled = True
		Me.txtGrpDefId.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtGrpDefId.HideSelection = True
		Me.txtGrpDefId.ReadOnly = False
		Me.txtGrpDefId.Maxlength = 0
		Me.txtGrpDefId.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtGrpDefId.MultiLine = False
		Me.txtGrpDefId.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtGrpDefId.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtGrpDefId.TabStop = True
		Me.txtGrpDefId.Visible = True
		Me.txtGrpDefId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtGrpDefId.Name = "txtGrpDefId"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(65, 33)
		Me.cmdCancel.Location = New System.Drawing.Point(192, 128)
		Me.cmdCancel.TabIndex = 7
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
		Me.cmdOk.Size = New System.Drawing.Size(65, 33)
		Me.cmdOk.Location = New System.Drawing.Point(96, 128)
		Me.cmdOk.TabIndex = 6
		Me.cmdOk.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOk.CausesValidation = True
		Me.cmdOk.Enabled = True
		Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOk.TabStop = True
		Me.cmdOk.Name = "cmdOk"
		Me.cbTypeId.CausesValidation = False
		Me.cbTypeId.Size = New System.Drawing.Size(193, 21)
		Me.cbTypeId.Location = New System.Drawing.Point(104, 48)
		Me.cbTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbTypeId.TabIndex = 4
		Me.cbTypeId.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbTypeId.BackColor = System.Drawing.SystemColors.Window
		Me.cbTypeId.Enabled = True
		Me.cbTypeId.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbTypeId.IntegralHeight = True
		Me.cbTypeId.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbTypeId.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbTypeId.Sorted = False
		Me.cbTypeId.TabStop = True
		Me.cbTypeId.Visible = True
		Me.cbTypeId.Name = "cbTypeId"
		Me.txtCustName.AutoSize = False
		Me.txtCustName.Enabled = False
		Me.txtCustName.Size = New System.Drawing.Size(193, 19)
		Me.txtCustName.Location = New System.Drawing.Point(104, 16)
		Me.txtCustName.ReadOnly = True
		Me.txtCustName.TabIndex = 3
		Me.txtCustName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtCustName.AcceptsReturn = True
		Me.txtCustName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCustName.BackColor = System.Drawing.SystemColors.Window
		Me.txtCustName.CausesValidation = True
		Me.txtCustName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCustName.HideSelection = True
		Me.txtCustName.Maxlength = 0
		Me.txtCustName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCustName.MultiLine = False
		Me.txtCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCustName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCustName.TabStop = True
		Me.txtCustName.Visible = True
		Me.txtCustName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCustName.Name = "txtCustName"
		Me.Label3.Text = "Group Name"
		Me.Label3.Size = New System.Drawing.Size(73, 17)
		Me.Label3.Location = New System.Drawing.Point(24, 80)
		Me.Label3.TabIndex = 2
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
		Me.Label2.Text = "Type"
		Me.Label2.Size = New System.Drawing.Size(57, 17)
		Me.Label2.Location = New System.Drawing.Point(24, 48)
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
		Me.Label1.Text = "Customer"
		Me.Label1.Size = New System.Drawing.Size(57, 17)
		Me.Label1.Location = New System.Drawing.Point(24, 16)
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
		Me.Controls.Add(cmdMembers)
		Me.Controls.Add(txtGrpDefId)
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(cmdOk)
		Me.Controls.Add(cbTypeId)
		Me.Controls.Add(txtCustName)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class