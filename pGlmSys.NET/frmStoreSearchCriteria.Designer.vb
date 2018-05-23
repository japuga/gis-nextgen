<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStoreSearchCriteria
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
	Public WithEvents txtStoreNo As System.Windows.Forms.TextBox
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdSearch As System.Windows.Forms.Button
	Public WithEvents cbState As System.Windows.Forms.ComboBox
	Public WithEvents txtStoreCity As System.Windows.Forms.TextBox
	Public WithEvents txtStoreAddress As System.Windows.Forms.TextBox
	Public WithEvents txtStoreName As System.Windows.Forms.TextBox
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStoreSearchCriteria))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.txtStoreNo = New System.Windows.Forms.TextBox
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdSearch = New System.Windows.Forms.Button
		Me.cbState = New System.Windows.Forms.ComboBox
		Me.txtStoreCity = New System.Windows.Forms.TextBox
		Me.txtStoreAddress = New System.Windows.Forms.TextBox
		Me.txtStoreName = New System.Windows.Forms.TextBox
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Search Criteria"
		Me.ClientSize = New System.Drawing.Size(298, 296)
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
		Me.Name = "frmStoreSearchCriteria"
		Me.txtStoreNo.AutoSize = False
		Me.txtStoreNo.Size = New System.Drawing.Size(109, 21)
		Me.txtStoreNo.Location = New System.Drawing.Point(96, 64)
		Me.txtStoreNo.TabIndex = 4
		Me.txtStoreNo.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtStoreNo.AcceptsReturn = True
		Me.txtStoreNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtStoreNo.BackColor = System.Drawing.SystemColors.Window
		Me.txtStoreNo.CausesValidation = True
		Me.txtStoreNo.Enabled = True
		Me.txtStoreNo.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtStoreNo.HideSelection = True
		Me.txtStoreNo.ReadOnly = False
		Me.txtStoreNo.Maxlength = 0
		Me.txtStoreNo.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtStoreNo.MultiLine = False
		Me.txtStoreNo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtStoreNo.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtStoreNo.TabStop = True
		Me.txtStoreNo.Visible = True
		Me.txtStoreNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtStoreNo.Name = "txtStoreNo"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "Close"
		Me.cmdClose.Size = New System.Drawing.Size(65, 33)
		Me.cmdClose.Location = New System.Drawing.Point(160, 240)
		Me.cmdClose.TabIndex = 11
		Me.cmdClose.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Me.cmdSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSearch.Text = "Search"
		Me.cmdSearch.Size = New System.Drawing.Size(65, 33)
		Me.cmdSearch.Location = New System.Drawing.Point(64, 240)
		Me.cmdSearch.TabIndex = 10
		Me.cmdSearch.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSearch.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSearch.CausesValidation = True
		Me.cmdSearch.Enabled = True
		Me.cmdSearch.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSearch.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSearch.TabStop = True
		Me.cmdSearch.Name = "cmdSearch"
		Me.cbState.Size = New System.Drawing.Size(65, 21)
		Me.cbState.Location = New System.Drawing.Point(96, 192)
		Me.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbState.TabIndex = 9
		Me.cbState.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbState.BackColor = System.Drawing.SystemColors.Window
		Me.cbState.CausesValidation = True
		Me.cbState.Enabled = True
		Me.cbState.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbState.IntegralHeight = True
		Me.cbState.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbState.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbState.Sorted = False
		Me.cbState.TabStop = True
		Me.cbState.Visible = True
		Me.cbState.Name = "cbState"
		Me.txtStoreCity.AutoSize = False
		Me.txtStoreCity.Size = New System.Drawing.Size(105, 21)
		Me.txtStoreCity.Location = New System.Drawing.Point(96, 160)
		Me.txtStoreCity.TabIndex = 8
		Me.txtStoreCity.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtStoreCity.AcceptsReturn = True
		Me.txtStoreCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtStoreCity.BackColor = System.Drawing.SystemColors.Window
		Me.txtStoreCity.CausesValidation = True
		Me.txtStoreCity.Enabled = True
		Me.txtStoreCity.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtStoreCity.HideSelection = True
		Me.txtStoreCity.ReadOnly = False
		Me.txtStoreCity.Maxlength = 0
		Me.txtStoreCity.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtStoreCity.MultiLine = False
		Me.txtStoreCity.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtStoreCity.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtStoreCity.TabStop = True
		Me.txtStoreCity.Visible = True
		Me.txtStoreCity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtStoreCity.Name = "txtStoreCity"
		Me.txtStoreAddress.AutoSize = False
		Me.txtStoreAddress.Size = New System.Drawing.Size(161, 21)
		Me.txtStoreAddress.Location = New System.Drawing.Point(96, 128)
		Me.txtStoreAddress.TabIndex = 7
		Me.txtStoreAddress.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtStoreAddress.AcceptsReturn = True
		Me.txtStoreAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtStoreAddress.BackColor = System.Drawing.SystemColors.Window
		Me.txtStoreAddress.CausesValidation = True
		Me.txtStoreAddress.Enabled = True
		Me.txtStoreAddress.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtStoreAddress.HideSelection = True
		Me.txtStoreAddress.ReadOnly = False
		Me.txtStoreAddress.Maxlength = 0
		Me.txtStoreAddress.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtStoreAddress.MultiLine = False
		Me.txtStoreAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtStoreAddress.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtStoreAddress.TabStop = True
		Me.txtStoreAddress.Visible = True
		Me.txtStoreAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtStoreAddress.Name = "txtStoreAddress"
		Me.txtStoreName.AutoSize = False
		Me.txtStoreName.Size = New System.Drawing.Size(105, 21)
		Me.txtStoreName.Location = New System.Drawing.Point(96, 96)
		Me.txtStoreName.TabIndex = 6
		Me.txtStoreName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtStoreName.AcceptsReturn = True
		Me.txtStoreName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtStoreName.BackColor = System.Drawing.SystemColors.Window
		Me.txtStoreName.CausesValidation = True
		Me.txtStoreName.Enabled = True
		Me.txtStoreName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtStoreName.HideSelection = True
		Me.txtStoreName.ReadOnly = False
		Me.txtStoreName.Maxlength = 0
		Me.txtStoreName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtStoreName.MultiLine = False
		Me.txtStoreName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtStoreName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtStoreName.TabStop = True
		Me.txtStoreName.Visible = True
		Me.txtStoreName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtStoreName.Name = "txtStoreName"
		Me.Label6.Text = "Store No"
		Me.Label6.Size = New System.Drawing.Size(57, 17)
		Me.Label6.Location = New System.Drawing.Point(16, 64)
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
		Me.Label5.Text = "Please fill in the fields that will help your search"
		Me.Label5.Size = New System.Drawing.Size(233, 33)
		Me.Label5.Location = New System.Drawing.Point(16, 8)
		Me.Label5.TabIndex = 5
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
		Me.Label4.Text = "Store City"
		Me.Label4.Size = New System.Drawing.Size(73, 17)
		Me.Label4.Location = New System.Drawing.Point(16, 160)
		Me.Label4.TabIndex = 3
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
		Me.Label3.Text = "Store Address"
		Me.Label3.Size = New System.Drawing.Size(73, 17)
		Me.Label3.Location = New System.Drawing.Point(16, 128)
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
		Me.Label2.Text = "State"
		Me.Label2.Size = New System.Drawing.Size(65, 17)
		Me.Label2.Location = New System.Drawing.Point(16, 192)
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
		Me.Label1.Text = "Store Name"
		Me.Label1.Size = New System.Drawing.Size(65, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 96)
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
		Me.Controls.Add(txtStoreNo)
		Me.Controls.Add(cmdClose)
		Me.Controls.Add(cmdSearch)
		Me.Controls.Add(cbState)
		Me.Controls.Add(txtStoreCity)
		Me.Controls.Add(txtStoreAddress)
		Me.Controls.Add(txtStoreName)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class