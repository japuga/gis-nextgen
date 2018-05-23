<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSaleRequestItem
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
	Public WithEvents cbRequestItemStatus As System.Windows.Forms.ComboBox
	Public WithEvents txtNotes As System.Windows.Forms.TextBox
	Public WithEvents cbStatus As System.Windows.Forms.ComboBox
	Public WithEvents txtAvailableQty As System.Windows.Forms.TextBox
	Public WithEvents txtAccountNo As System.Windows.Forms.TextBox
	Public WithEvents txtQty As System.Windows.Forms.TextBox
	Public WithEvents txtItemDesc As System.Windows.Forms.TextBox
	Public WithEvents _Toolbar1_Button4 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
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
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSaleRequestItem))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cbRequestItemStatus = New System.Windows.Forms.ComboBox
		Me.txtNotes = New System.Windows.Forms.TextBox
		Me.cbStatus = New System.Windows.Forms.ComboBox
		Me.txtAvailableQty = New System.Windows.Forms.TextBox
		Me.txtAccountNo = New System.Windows.Forms.TextBox
		Me.txtQty = New System.Windows.Forms.TextBox
		Me.txtItemDesc = New System.Windows.Forms.TextBox
		Me.Toolbar1 = New System.Windows.Forms.ToolStrip
		Me._Toolbar1_Button4 = New System.Windows.Forms.ToolStripSeparator
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Toolbar1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Request Item"
		Me.ClientSize = New System.Drawing.Size(641, 358)
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
		Me.Name = "frmSaleRequestItem"
		Me.cbRequestItemStatus.Size = New System.Drawing.Size(129, 21)
		Me.cbRequestItemStatus.Location = New System.Drawing.Point(320, 216)
		Me.cbRequestItemStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbRequestItemStatus.TabIndex = 13
		Me.cbRequestItemStatus.Visible = False
		Me.cbRequestItemStatus.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbRequestItemStatus.BackColor = System.Drawing.SystemColors.Window
		Me.cbRequestItemStatus.CausesValidation = True
		Me.cbRequestItemStatus.Enabled = True
		Me.cbRequestItemStatus.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbRequestItemStatus.IntegralHeight = True
		Me.cbRequestItemStatus.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbRequestItemStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbRequestItemStatus.Sorted = False
		Me.cbRequestItemStatus.TabStop = True
		Me.cbRequestItemStatus.Name = "cbRequestItemStatus"
		Me.txtNotes.AutoSize = False
		Me.txtNotes.Size = New System.Drawing.Size(505, 57)
		Me.txtNotes.Location = New System.Drawing.Point(104, 256)
		Me.txtNotes.MultiLine = True
		Me.txtNotes.TabIndex = 12
		Me.txtNotes.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtNotes.AcceptsReturn = True
		Me.txtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNotes.BackColor = System.Drawing.SystemColors.Window
		Me.txtNotes.CausesValidation = True
		Me.txtNotes.Enabled = True
		Me.txtNotes.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNotes.HideSelection = True
		Me.txtNotes.ReadOnly = False
		Me.txtNotes.Maxlength = 0
		Me.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNotes.TabStop = True
		Me.txtNotes.Visible = True
		Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNotes.Name = "txtNotes"
		Me.cbStatus.Size = New System.Drawing.Size(161, 21)
		Me.cbStatus.Location = New System.Drawing.Point(104, 216)
		Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbStatus.TabIndex = 10
		Me.cbStatus.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbStatus.BackColor = System.Drawing.SystemColors.Window
		Me.cbStatus.CausesValidation = True
		Me.cbStatus.Enabled = True
		Me.cbStatus.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbStatus.IntegralHeight = True
		Me.cbStatus.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbStatus.Sorted = False
		Me.cbStatus.TabStop = True
		Me.cbStatus.Visible = True
		Me.cbStatus.Name = "cbStatus"
		Me.txtAvailableQty.AutoSize = False
		Me.txtAvailableQty.BackColor = System.Drawing.SystemColors.ScrollBar
		Me.txtAvailableQty.Size = New System.Drawing.Size(137, 21)
		Me.txtAvailableQty.Location = New System.Drawing.Point(104, 184)
		Me.txtAvailableQty.TabIndex = 8
		Me.txtAvailableQty.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtAvailableQty.AcceptsReturn = True
		Me.txtAvailableQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtAvailableQty.CausesValidation = True
		Me.txtAvailableQty.Enabled = True
		Me.txtAvailableQty.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAvailableQty.HideSelection = True
		Me.txtAvailableQty.ReadOnly = False
		Me.txtAvailableQty.Maxlength = 0
		Me.txtAvailableQty.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAvailableQty.MultiLine = False
		Me.txtAvailableQty.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAvailableQty.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtAvailableQty.TabStop = True
		Me.txtAvailableQty.Visible = True
		Me.txtAvailableQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAvailableQty.Name = "txtAvailableQty"
		Me.txtAccountNo.AutoSize = False
		Me.txtAccountNo.Size = New System.Drawing.Size(225, 21)
		Me.txtAccountNo.Location = New System.Drawing.Point(104, 104)
		Me.txtAccountNo.TabIndex = 3
		Me.txtAccountNo.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtAccountNo.AcceptsReturn = True
		Me.txtAccountNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtAccountNo.BackColor = System.Drawing.SystemColors.Window
		Me.txtAccountNo.CausesValidation = True
		Me.txtAccountNo.Enabled = True
		Me.txtAccountNo.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAccountNo.HideSelection = True
		Me.txtAccountNo.ReadOnly = False
		Me.txtAccountNo.Maxlength = 0
		Me.txtAccountNo.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAccountNo.MultiLine = False
		Me.txtAccountNo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAccountNo.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtAccountNo.TabStop = True
		Me.txtAccountNo.Visible = True
		Me.txtAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAccountNo.Name = "txtAccountNo"
		Me.txtQty.AutoSize = False
		Me.txtQty.Size = New System.Drawing.Size(137, 21)
		Me.txtQty.Location = New System.Drawing.Point(104, 144)
		Me.txtQty.TabIndex = 5
		Me.txtQty.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtQty.AcceptsReturn = True
		Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtQty.BackColor = System.Drawing.SystemColors.Window
		Me.txtQty.CausesValidation = True
		Me.txtQty.Enabled = True
		Me.txtQty.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtQty.HideSelection = True
		Me.txtQty.ReadOnly = False
		Me.txtQty.Maxlength = 0
		Me.txtQty.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtQty.MultiLine = False
		Me.txtQty.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtQty.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtQty.TabStop = True
		Me.txtQty.Visible = True
		Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtQty.Name = "txtQty"
		Me.txtItemDesc.AutoSize = False
		Me.txtItemDesc.Size = New System.Drawing.Size(513, 21)
		Me.txtItemDesc.Location = New System.Drawing.Point(104, 64)
		Me.txtItemDesc.TabIndex = 2
		Me.txtItemDesc.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtItemDesc.AcceptsReturn = True
		Me.txtItemDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtItemDesc.BackColor = System.Drawing.SystemColors.Window
		Me.txtItemDesc.CausesValidation = True
		Me.txtItemDesc.Enabled = True
		Me.txtItemDesc.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtItemDesc.HideSelection = True
		Me.txtItemDesc.ReadOnly = False
		Me.txtItemDesc.Maxlength = 0
		Me.txtItemDesc.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtItemDesc.MultiLine = False
		Me.txtItemDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtItemDesc.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtItemDesc.TabStop = True
		Me.txtItemDesc.Visible = True
		Me.txtItemDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtItemDesc.Name = "txtItemDesc"
		Me.Toolbar1.ShowItemToolTips = True
		Me.Toolbar1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Toolbar1.Size = New System.Drawing.Size(641, 44)
		Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
		Me.Toolbar1.TabIndex = 0
		Me.Toolbar1.ImageList = ImageList2
		Me.Toolbar1.Name = "Toolbar1"
		Me._Toolbar1_Button4.Size = New System.Drawing.Size(40, 39)
		Me._Toolbar1_Button4.AutoSize = False
		Me._Toolbar1_Button4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._Toolbar1_Button4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._Toolbar1_Button4.ToolTipText = "Print"
		Me._Toolbar1_Button4.Width = 10
		Me._Toolbar1_Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me.Label6.Text = "Notes"
		Me.Label6.Size = New System.Drawing.Size(57, 17)
		Me.Label6.Location = New System.Drawing.Point(24, 256)
		Me.Label6.TabIndex = 11
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
		Me.Label5.Text = "Status"
		Me.Label5.Size = New System.Drawing.Size(57, 17)
		Me.Label5.Location = New System.Drawing.Point(24, 224)
		Me.Label5.TabIndex = 9
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
		Me.Label4.Text = "Available"
		Me.Label4.Size = New System.Drawing.Size(65, 17)
		Me.Label4.Location = New System.Drawing.Point(24, 192)
		Me.Label4.TabIndex = 7
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
		Me.Label3.Text = "Account No"
		Me.Label3.Size = New System.Drawing.Size(73, 17)
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
		Me.Label2.Text = "Quantity"
		Me.Label2.Size = New System.Drawing.Size(57, 25)
		Me.Label2.Location = New System.Drawing.Point(24, 152)
		Me.Label2.TabIndex = 4
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
		Me.Label1.Text = "Description"
		Me.Label1.Size = New System.Drawing.Size(65, 17)
		Me.Label1.Location = New System.Drawing.Point(24, 64)
		Me.Label1.TabIndex = 1
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
		Me.Controls.Add(cbRequestItemStatus)
		Me.Controls.Add(txtNotes)
		Me.Controls.Add(cbStatus)
		Me.Controls.Add(txtAvailableQty)
		Me.Controls.Add(txtAccountNo)
		Me.Controls.Add(txtQty)
		Me.Controls.Add(txtItemDesc)
		Me.Controls.Add(Toolbar1)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Toolbar1.Items.Add(_Toolbar1_Button4)
		Me.Toolbar1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class