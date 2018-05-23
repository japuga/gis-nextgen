<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmServiceGroupEntry
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
	Public WithEvents dgServices As AxMSDataGridLib.AxDataGrid
	Public WithEvents cbSystemGenerated As System.Windows.Forms.ComboBox
	Public WithEvents cmdDetails As System.Windows.Forms.Button
	Public WithEvents txtServGroupDesc As System.Windows.Forms.TextBox
	Public WithEvents txtServGroupName As System.Windows.Forms.TextBox
	Public WithEvents _Toolbar1_Button5 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmServiceGroupEntry))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.dgServices = New AxMSDataGridLib.AxDataGrid
		Me.cbSystemGenerated = New System.Windows.Forms.ComboBox
		Me.cmdDetails = New System.Windows.Forms.Button
		Me.txtServGroupDesc = New System.Windows.Forms.TextBox
		Me.txtServGroupName = New System.Windows.Forms.TextBox
		Me.Toolbar1 = New System.Windows.Forms.ToolStrip
		Me._Toolbar1_Button5 = New System.Windows.Forms.ToolStripSeparator
		Me.Label3 = New System.Windows.Forms.Label
		Me.label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Toolbar1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.dgServices, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Service Group Entry"
		Me.ClientSize = New System.Drawing.Size(574, 406)
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
		Me.Name = "frmServiceGroupEntry"
		dgServices.OcxState = CType(resources.GetObject("dgServices.OcxState"), System.Windows.Forms.AxHost.State)
		Me.dgServices.Size = New System.Drawing.Size(537, 185)
		Me.dgServices.Location = New System.Drawing.Point(8, 160)
		Me.dgServices.TabIndex = 7
		Me.dgServices.Name = "dgServices"
		Me.cbSystemGenerated.Size = New System.Drawing.Size(73, 21)
		Me.cbSystemGenerated.Location = New System.Drawing.Point(120, 120)
		Me.cbSystemGenerated.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbSystemGenerated.TabIndex = 6
		Me.cbSystemGenerated.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbSystemGenerated.BackColor = System.Drawing.SystemColors.Window
		Me.cbSystemGenerated.CausesValidation = True
		Me.cbSystemGenerated.Enabled = True
		Me.cbSystemGenerated.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbSystemGenerated.IntegralHeight = True
		Me.cbSystemGenerated.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbSystemGenerated.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbSystemGenerated.Sorted = False
		Me.cbSystemGenerated.TabStop = True
		Me.cbSystemGenerated.Visible = True
		Me.cbSystemGenerated.Name = "cbSystemGenerated"
		Me.cmdDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDetails.Text = "Details"
		Me.cmdDetails.Size = New System.Drawing.Size(57, 33)
		Me.cmdDetails.Location = New System.Drawing.Point(16, 360)
		Me.cmdDetails.TabIndex = 4
		Me.cmdDetails.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdDetails.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDetails.CausesValidation = True
		Me.cmdDetails.Enabled = True
		Me.cmdDetails.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDetails.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDetails.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDetails.TabStop = True
		Me.cmdDetails.Name = "cmdDetails"
		Me.txtServGroupDesc.AutoSize = False
		Me.txtServGroupDesc.Size = New System.Drawing.Size(257, 19)
		Me.txtServGroupDesc.Location = New System.Drawing.Point(120, 88)
		Me.txtServGroupDesc.TabIndex = 3
		Me.txtServGroupDesc.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtServGroupDesc.AcceptsReturn = True
		Me.txtServGroupDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtServGroupDesc.BackColor = System.Drawing.SystemColors.Window
		Me.txtServGroupDesc.CausesValidation = True
		Me.txtServGroupDesc.Enabled = True
		Me.txtServGroupDesc.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtServGroupDesc.HideSelection = True
		Me.txtServGroupDesc.ReadOnly = False
		Me.txtServGroupDesc.Maxlength = 0
		Me.txtServGroupDesc.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtServGroupDesc.MultiLine = False
		Me.txtServGroupDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtServGroupDesc.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtServGroupDesc.TabStop = True
		Me.txtServGroupDesc.Visible = True
		Me.txtServGroupDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtServGroupDesc.Name = "txtServGroupDesc"
		Me.txtServGroupName.AutoSize = False
		Me.txtServGroupName.Size = New System.Drawing.Size(137, 19)
		Me.txtServGroupName.Location = New System.Drawing.Point(120, 56)
		Me.txtServGroupName.TabIndex = 1
		Me.txtServGroupName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtServGroupName.AcceptsReturn = True
		Me.txtServGroupName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtServGroupName.BackColor = System.Drawing.SystemColors.Window
		Me.txtServGroupName.CausesValidation = True
		Me.txtServGroupName.Enabled = True
		Me.txtServGroupName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtServGroupName.HideSelection = True
		Me.txtServGroupName.ReadOnly = False
		Me.txtServGroupName.Maxlength = 0
		Me.txtServGroupName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtServGroupName.MultiLine = False
		Me.txtServGroupName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtServGroupName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtServGroupName.TabStop = True
		Me.txtServGroupName.Visible = True
		Me.txtServGroupName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtServGroupName.Name = "txtServGroupName"
		Me.Toolbar1.ShowItemToolTips = True
		Me.Toolbar1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Toolbar1.Size = New System.Drawing.Size(574, 44)
		Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
		Me.Toolbar1.TabIndex = 8
		Me.Toolbar1.ImageList = ImageList2
		Me.Toolbar1.Name = "Toolbar1"
		Me._Toolbar1_Button5.Size = New System.Drawing.Size(40, 39)
		Me._Toolbar1_Button5.AutoSize = False
		Me._Toolbar1_Button5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._Toolbar1_Button5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._Toolbar1_Button5.ToolTipText = "Print"
		Me._Toolbar1_Button5.Width = 10
		Me._Toolbar1_Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me.Label3.Text = "System Generated"
		Me.Label3.Size = New System.Drawing.Size(89, 17)
		Me.Label3.Location = New System.Drawing.Point(16, 120)
		Me.Label3.TabIndex = 5
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
		Me.label2.Text = "Description"
		Me.label2.Size = New System.Drawing.Size(65, 17)
		Me.label2.Location = New System.Drawing.Point(16, 88)
		Me.label2.TabIndex = 2
		Me.label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.label2.BackColor = System.Drawing.SystemColors.Control
		Me.label2.Enabled = True
		Me.label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label2.UseMnemonic = True
		Me.label2.Visible = True
		Me.label2.AutoSize = False
		Me.label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.label2.Name = "label2"
		Me.Label1.Text = "Group Name"
		Me.Label1.Size = New System.Drawing.Size(81, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 56)
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
		Me.Controls.Add(dgServices)
		Me.Controls.Add(cbSystemGenerated)
		Me.Controls.Add(cmdDetails)
		Me.Controls.Add(txtServGroupDesc)
		Me.Controls.Add(txtServGroupName)
		Me.Controls.Add(Toolbar1)
		Me.Controls.Add(Label3)
		Me.Controls.Add(label2)
		Me.Controls.Add(Label1)
		Me.Toolbar1.Items.Add(_Toolbar1_Button5)
		CType(Me.dgServices, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Toolbar1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class