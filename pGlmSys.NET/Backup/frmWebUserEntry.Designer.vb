<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmWebUserEntry
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
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
	Public WithEvents txtExtUserDesc As System.Windows.Forms.TextBox
	Public WithEvents txtExtUserPassword As System.Windows.Forms.TextBox
	Public WithEvents txtExtUserName As System.Windows.Forms.TextBox
	Public WithEvents _Toolbar1_Button5 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWebUserEntry))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cbCustId = New System.Windows.Forms.ComboBox
		Me.cbCustName = New System.Windows.Forms.ComboBox
		Me.txtExtUserDesc = New System.Windows.Forms.TextBox
		Me.txtExtUserPassword = New System.Windows.Forms.TextBox
		Me.txtExtUserName = New System.Windows.Forms.TextBox
		Me.Toolbar1 = New System.Windows.Forms.ToolStrip
		Me._Toolbar1_Button5 = New System.Windows.Forms.ToolStripSeparator
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Toolbar1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Form1"
		Me.ClientSize = New System.Drawing.Size(510, 304)
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
		Me.Name = "frmWebUserEntry"
		Me.cbCustId.Size = New System.Drawing.Size(137, 21)
		Me.cbCustId.Location = New System.Drawing.Point(328, 72)
		Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbCustId.TabIndex = 8
		Me.cbCustId.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
		Me.cbCustId.CausesValidation = True
		Me.cbCustId.Enabled = True
		Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbCustId.IntegralHeight = True
		Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbCustId.Sorted = False
		Me.cbCustId.TabStop = True
		Me.cbCustId.Visible = True
		Me.cbCustId.Name = "cbCustId"
		Me.cbCustName.Size = New System.Drawing.Size(201, 21)
		Me.cbCustName.Location = New System.Drawing.Point(80, 72)
		Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbCustName.TabIndex = 7
		Me.cbCustName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
		Me.cbCustName.CausesValidation = True
		Me.cbCustName.Enabled = True
		Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbCustName.IntegralHeight = True
		Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbCustName.Sorted = False
		Me.cbCustName.TabStop = True
		Me.cbCustName.Visible = True
		Me.cbCustName.Name = "cbCustName"
		Me.txtExtUserDesc.AutoSize = False
		Me.txtExtUserDesc.Size = New System.Drawing.Size(201, 21)
		Me.txtExtUserDesc.Location = New System.Drawing.Point(80, 136)
		Me.txtExtUserDesc.TabIndex = 5
		Me.txtExtUserDesc.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtExtUserDesc.AcceptsReturn = True
		Me.txtExtUserDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtExtUserDesc.BackColor = System.Drawing.SystemColors.Window
		Me.txtExtUserDesc.CausesValidation = True
		Me.txtExtUserDesc.Enabled = True
		Me.txtExtUserDesc.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtExtUserDesc.HideSelection = True
		Me.txtExtUserDesc.ReadOnly = False
		Me.txtExtUserDesc.Maxlength = 0
		Me.txtExtUserDesc.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtExtUserDesc.MultiLine = False
		Me.txtExtUserDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtExtUserDesc.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtExtUserDesc.TabStop = True
		Me.txtExtUserDesc.Visible = True
		Me.txtExtUserDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtExtUserDesc.Name = "txtExtUserDesc"
		Me.txtExtUserPassword.AutoSize = False
		Me.txtExtUserPassword.Size = New System.Drawing.Size(105, 21)
		Me.txtExtUserPassword.Location = New System.Drawing.Point(80, 168)
		Me.txtExtUserPassword.TabIndex = 3
		Me.txtExtUserPassword.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtExtUserPassword.AcceptsReturn = True
		Me.txtExtUserPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtExtUserPassword.BackColor = System.Drawing.SystemColors.Window
		Me.txtExtUserPassword.CausesValidation = True
		Me.txtExtUserPassword.Enabled = True
		Me.txtExtUserPassword.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtExtUserPassword.HideSelection = True
		Me.txtExtUserPassword.ReadOnly = False
		Me.txtExtUserPassword.Maxlength = 0
		Me.txtExtUserPassword.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtExtUserPassword.MultiLine = False
		Me.txtExtUserPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtExtUserPassword.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtExtUserPassword.TabStop = True
		Me.txtExtUserPassword.Visible = True
		Me.txtExtUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtExtUserPassword.Name = "txtExtUserPassword"
		Me.txtExtUserName.AutoSize = False
		Me.txtExtUserName.Size = New System.Drawing.Size(105, 21)
		Me.txtExtUserName.Location = New System.Drawing.Point(80, 104)
		Me.txtExtUserName.TabIndex = 1
		Me.txtExtUserName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtExtUserName.AcceptsReturn = True
		Me.txtExtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtExtUserName.BackColor = System.Drawing.SystemColors.Window
		Me.txtExtUserName.CausesValidation = True
		Me.txtExtUserName.Enabled = True
		Me.txtExtUserName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtExtUserName.HideSelection = True
		Me.txtExtUserName.ReadOnly = False
		Me.txtExtUserName.Maxlength = 0
		Me.txtExtUserName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtExtUserName.MultiLine = False
		Me.txtExtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtExtUserName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtExtUserName.TabStop = True
		Me.txtExtUserName.Visible = True
		Me.txtExtUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtExtUserName.Name = "txtExtUserName"
		Me.Toolbar1.ShowItemToolTips = True
		Me.Toolbar1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Toolbar1.Size = New System.Drawing.Size(510, 44)
		Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
		Me.Toolbar1.TabIndex = 9
		Me.Toolbar1.ImageList = ImageList2
		Me.Toolbar1.Name = "Toolbar1"
		Me._Toolbar1_Button5.Size = New System.Drawing.Size(40, 39)
		Me._Toolbar1_Button5.AutoSize = False
		Me._Toolbar1_Button5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._Toolbar1_Button5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._Toolbar1_Button5.ToolTipText = "Print"
		Me._Toolbar1_Button5.Width = 10
		Me._Toolbar1_Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me.Label5.Text = "Customer"
		Me.Label5.Size = New System.Drawing.Size(65, 17)
		Me.Label5.Location = New System.Drawing.Point(0, 72)
		Me.Label5.TabIndex = 6
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
		Me.Label3.Text = "User Name"
		Me.Label3.Size = New System.Drawing.Size(65, 17)
		Me.Label3.Location = New System.Drawing.Point(0, 136)
		Me.Label3.TabIndex = 4
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
		Me.Label2.Text = "Password"
		Me.Label2.Size = New System.Drawing.Size(57, 17)
		Me.Label2.Location = New System.Drawing.Point(0, 168)
		Me.Label2.TabIndex = 2
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
		Me.Label1.Location = New System.Drawing.Point(0, 104)
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
		Me.Controls.Add(cbCustId)
		Me.Controls.Add(cbCustName)
		Me.Controls.Add(txtExtUserDesc)
		Me.Controls.Add(txtExtUserPassword)
		Me.Controls.Add(txtExtUserName)
		Me.Controls.Add(Toolbar1)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Toolbar1.Items.Add(_Toolbar1_Button5)
		Me.Toolbar1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class