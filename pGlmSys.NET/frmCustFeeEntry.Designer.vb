<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCustFeeEntry
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
	Public WithEvents cmdOptions As System.Windows.Forms.Button
	Public WithEvents ckActive As System.Windows.Forms.CheckBox
	Public WithEvents cbFeeDesc As System.Windows.Forms.ComboBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents txtFeeValue As System.Windows.Forms.TextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lbFeeDesc As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCustFeeEntry))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdOptions = New System.Windows.Forms.Button
		Me.ckActive = New System.Windows.Forms.CheckBox
		Me.cbFeeDesc = New System.Windows.Forms.ComboBox
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdOk = New System.Windows.Forms.Button
		Me.txtFeeValue = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.lbFeeDesc = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Fee Data Entry"
		Me.ClientSize = New System.Drawing.Size(280, 203)
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
		Me.Name = "frmCustFeeEntry"
		Me.cmdOptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOptions.Text = "Options"
		Me.cmdOptions.Size = New System.Drawing.Size(73, 33)
		Me.cmdOptions.Location = New System.Drawing.Point(176, 96)
		Me.cmdOptions.TabIndex = 7
		Me.cmdOptions.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdOptions.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOptions.CausesValidation = True
		Me.cmdOptions.Enabled = True
		Me.cmdOptions.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOptions.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOptions.TabStop = True
		Me.cmdOptions.Name = "cmdOptions"
		Me.ckActive.Text = "Active"
		Me.ckActive.Size = New System.Drawing.Size(57, 25)
		Me.ckActive.Location = New System.Drawing.Point(104, 104)
		Me.ckActive.TabIndex = 6
		Me.ckActive.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ckActive.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ckActive.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.ckActive.BackColor = System.Drawing.SystemColors.Control
		Me.ckActive.CausesValidation = True
		Me.ckActive.Enabled = True
		Me.ckActive.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ckActive.Cursor = System.Windows.Forms.Cursors.Default
		Me.ckActive.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ckActive.Appearance = System.Windows.Forms.Appearance.Normal
		Me.ckActive.TabStop = True
		Me.ckActive.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.ckActive.Visible = True
		Me.ckActive.Name = "ckActive"
		Me.cbFeeDesc.Size = New System.Drawing.Size(153, 21)
		Me.cbFeeDesc.Location = New System.Drawing.Point(104, 32)
		Me.cbFeeDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbFeeDesc.TabIndex = 4
		Me.cbFeeDesc.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbFeeDesc.BackColor = System.Drawing.SystemColors.Window
		Me.cbFeeDesc.CausesValidation = True
		Me.cbFeeDesc.Enabled = True
		Me.cbFeeDesc.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbFeeDesc.IntegralHeight = True
		Me.cbFeeDesc.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbFeeDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbFeeDesc.Sorted = False
		Me.cbFeeDesc.TabStop = True
		Me.cbFeeDesc.Visible = True
		Me.cbFeeDesc.Name = "cbFeeDesc"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(49, 33)
		Me.cmdCancel.Location = New System.Drawing.Point(144, 144)
		Me.cmdCancel.TabIndex = 3
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
		Me.cmdOk.Size = New System.Drawing.Size(49, 33)
		Me.cmdOk.Location = New System.Drawing.Point(80, 144)
		Me.cmdOk.TabIndex = 2
		Me.cmdOk.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOk.CausesValidation = True
		Me.cmdOk.Enabled = True
		Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOk.TabStop = True
		Me.cmdOk.Name = "cmdOk"
		Me.txtFeeValue.AutoSize = False
		Me.txtFeeValue.Size = New System.Drawing.Size(97, 21)
		Me.txtFeeValue.Location = New System.Drawing.Point(104, 64)
		Me.txtFeeValue.TabIndex = 1
		Me.txtFeeValue.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtFeeValue.AcceptsReturn = True
		Me.txtFeeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtFeeValue.BackColor = System.Drawing.SystemColors.Window
		Me.txtFeeValue.CausesValidation = True
		Me.txtFeeValue.Enabled = True
		Me.txtFeeValue.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtFeeValue.HideSelection = True
		Me.txtFeeValue.ReadOnly = False
		Me.txtFeeValue.Maxlength = 0
		Me.txtFeeValue.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtFeeValue.MultiLine = False
		Me.txtFeeValue.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtFeeValue.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtFeeValue.TabStop = True
		Me.txtFeeValue.Visible = True
		Me.txtFeeValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtFeeValue.Name = "txtFeeValue"
		Me.Label1.Text = "Value"
		Me.Label1.Size = New System.Drawing.Size(49, 25)
		Me.Label1.Location = New System.Drawing.Point(32, 64)
		Me.Label1.TabIndex = 5
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
		Me.lbFeeDesc.Text = "Fee"
		Me.lbFeeDesc.Size = New System.Drawing.Size(57, 17)
		Me.lbFeeDesc.Location = New System.Drawing.Point(32, 32)
		Me.lbFeeDesc.TabIndex = 0
		Me.lbFeeDesc.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lbFeeDesc.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbFeeDesc.BackColor = System.Drawing.SystemColors.Control
		Me.lbFeeDesc.Enabled = True
		Me.lbFeeDesc.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lbFeeDesc.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbFeeDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbFeeDesc.UseMnemonic = True
		Me.lbFeeDesc.Visible = True
		Me.lbFeeDesc.AutoSize = False
		Me.lbFeeDesc.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbFeeDesc.Name = "lbFeeDesc"
		Me.Controls.Add(cmdOptions)
		Me.Controls.Add(ckActive)
		Me.Controls.Add(cbFeeDesc)
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(cmdOk)
		Me.Controls.Add(txtFeeValue)
		Me.Controls.Add(Label1)
		Me.Controls.Add(lbFeeDesc)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class