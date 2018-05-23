<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmInvoiceBooking
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
	Public WithEvents cmdEdit As System.Windows.Forms.Button
	Public WithEvents _Toolbar1_Button5 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
	Public WithEvents txtExtc As System.Windows.Forms.TextBox
	Public WithEvents txtSc As System.Windows.Forms.TextBox
	Public WithEvents cbGroupName As System.Windows.Forms.ComboBox
	Public WithEvents txtWorkOrderNo As System.Windows.Forms.TextBox
	Public WithEvents cbPeriod As System.Windows.Forms.ComboBox
	Public WithEvents txtYearPeriod As System.Windows.Forms.TextBox
	Public WithEvents cbMonthPeriod As System.Windows.Forms.ComboBox
	Public WithEvents txtStoreId As System.Windows.Forms.TextBox
	Public WithEvents cbAccount As System.Windows.Forms.ComboBox
	Public WithEvents txtInvoice As System.Windows.Forms.TextBox
	Public WithEvents txtStore As System.Windows.Forms.TextBox
    Public WithEvents cbState As System.Windows.Forms.ComboBox
	Public WithEvents cbVendor As System.Windows.Forms.ComboBox
	Public WithEvents cmdHelpCustomer As System.Windows.Forms.Button
	Public WithEvents cbCustomer As System.Windows.Forms.ComboBox
	Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents lbEndDate As System.Windows.Forms.Label
	Public WithEvents lbStartDate As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents label5 As System.Windows.Forms.Label
	Public WithEvents lVendorName As System.Windows.Forms.Label
	Public WithEvents lVendorAddress As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents frHeader As System.Windows.Forms.GroupBox
	Public WithEvents txtGlmTotal As System.Windows.Forms.MaskedTextBox
	Public WithEvents Text1 As System.Windows.Forms.TextBox
	Public WithEvents cmdNotes As System.Windows.Forms.Button
	Public WithEvents cmdDrop As System.Windows.Forms.Button
    Public WithEvents cbEquipment As System.Windows.Forms.ComboBox
	Public WithEvents cbService As System.Windows.Forms.ComboBox
	Public WithEvents cmdAdd As System.Windows.Forms.Button
	Public WithEvents txtTotal As System.Windows.Forms.MaskedTextBox
    Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents lblTotal As System.Windows.Forms.Label
	Public WithEvents frDetail As System.Windows.Forms.Panel
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvoiceBooking))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.cmdHelpCustomer = New System.Windows.Forms.Button
        Me.cmdNotes = New System.Windows.Forms.Button
        Me.cmdDrop = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip
        Me.btNew = New System.Windows.Forms.ToolStripButton
        Me.btSave = New System.Windows.Forms.ToolStripButton
        Me.btSearch = New System.Windows.Forms.ToolStripButton
        Me.btDelete = New System.Windows.Forms.ToolStripButton
        Me._Toolbar1_Button5 = New System.Windows.Forms.ToolStripSeparator
        Me.btExit = New System.Windows.Forms.ToolStripButton
        Me.frHeader = New System.Windows.Forms.GroupBox
        Me.dtDate = New System.Windows.Forms.DateTimePicker
        Me.txtExtc = New System.Windows.Forms.TextBox
        Me.txtSc = New System.Windows.Forms.TextBox
        Me.cbGroupName = New System.Windows.Forms.ComboBox
        Me.txtWorkOrderNo = New System.Windows.Forms.TextBox
        Me.cbPeriod = New System.Windows.Forms.ComboBox
        Me.txtYearPeriod = New System.Windows.Forms.TextBox
        Me.cbMonthPeriod = New System.Windows.Forms.ComboBox
        Me.txtStoreId = New System.Windows.Forms.TextBox
        Me.cbAccount = New System.Windows.Forms.ComboBox
        Me.txtInvoice = New System.Windows.Forms.TextBox
        Me.txtStore = New System.Windows.Forms.TextBox
        Me.cbState = New System.Windows.Forms.ComboBox
        Me.cbVendor = New System.Windows.Forms.ComboBox
        Me.cbCustomer = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbEndDate = New System.Windows.Forms.Label
        Me.lbStartDate = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.lVendorName = New System.Windows.Forms.Label
        Me.lVendorAddress = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.frDetail = New System.Windows.Forms.Panel
        Me.DataGrid1 = New System.Windows.Forms.DataGridView
        Me.txtGlmTotal = New System.Windows.Forms.MaskedTextBox
        Me.Text1 = New System.Windows.Forms.TextBox
        Me.cbEquipment = New System.Windows.Forms.ComboBox
        Me.cbService = New System.Windows.Forms.ComboBox
        Me.txtTotal = New System.Windows.Forms.MaskedTextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.dgDetail = New System.Windows.Forms.DataGridView
        Me.Toolbar1.SuspendLayout()
        Me.frHeader.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.frDetail.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdEdit
        '
        Me.cmdEdit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEdit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEdit.Location = New System.Drawing.Point(74, 222)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEdit.Size = New System.Drawing.Size(57, 25)
        Me.cmdEdit.TabIndex = 34
        Me.cmdEdit.Text = "Edit"
        Me.ToolTip1.SetToolTip(Me.cmdEdit, "Enter invoice comments")
        Me.cmdEdit.UseVisualStyleBackColor = False
        '
        'cmdHelpCustomer
        '
        Me.cmdHelpCustomer.BackColor = System.Drawing.SystemColors.Control
        Me.cmdHelpCustomer.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdHelpCustomer.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdHelpCustomer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdHelpCustomer.Image = CType(resources.GetObject("cmdHelpCustomer.Image"), System.Drawing.Image)
        Me.cmdHelpCustomer.Location = New System.Drawing.Point(320, 24)
        Me.cmdHelpCustomer.Name = "cmdHelpCustomer"
        Me.cmdHelpCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdHelpCustomer.Size = New System.Drawing.Size(33, 21)
        Me.cmdHelpCustomer.TabIndex = 4
        Me.cmdHelpCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdHelpCustomer, "List of Stores")
        Me.cmdHelpCustomer.UseVisualStyleBackColor = False
        '
        'cmdNotes
        '
        Me.cmdNotes.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNotes.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdNotes.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNotes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNotes.Location = New System.Drawing.Point(200, 222)
        Me.cmdNotes.Name = "cmdNotes"
        Me.cmdNotes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdNotes.Size = New System.Drawing.Size(57, 25)
        Me.cmdNotes.TabIndex = 30
        Me.cmdNotes.Text = "Notes"
        Me.ToolTip1.SetToolTip(Me.cmdNotes, "Enter invoice comments")
        Me.cmdNotes.UseVisualStyleBackColor = False
        '
        'cmdDrop
        '
        Me.cmdDrop.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDrop.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDrop.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDrop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDrop.Location = New System.Drawing.Point(137, 222)
        Me.cmdDrop.Name = "cmdDrop"
        Me.cmdDrop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDrop.Size = New System.Drawing.Size(57, 25)
        Me.cmdDrop.TabIndex = 11
        Me.cmdDrop.Text = "Delete"
        Me.ToolTip1.SetToolTip(Me.cmdDrop, "Delete a detail from the invoice")
        Me.cmdDrop.UseVisualStyleBackColor = False
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAdd.Location = New System.Drawing.Point(11, 222)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAdd.Size = New System.Drawing.Size(57, 25)
        Me.cmdAdd.TabIndex = 10
        Me.cmdAdd.Text = "Add"
        Me.ToolTip1.SetToolTip(Me.cmdAdd, "Add a detail to the invoice")
        Me.cmdAdd.UseVisualStyleBackColor = False
        '
        'Toolbar1
        '
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNew, Me.btSave, Me.btSearch, Me.btDelete, Me._Toolbar1_Button5, Me.btExit})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(698, 39)
        Me.Toolbar1.TabIndex = 22
        '
        'btNew
        '
        Me.btNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btNew.Image = CType(resources.GetObject("btNew.Image"), System.Drawing.Image)
        Me.btNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btNew.Name = "btNew"
        Me.btNew.Size = New System.Drawing.Size(36, 36)
        Me.btNew.Text = "New"
        '
        'btSave
        '
        Me.btSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btSave.Image = CType(resources.GetObject("btSave.Image"), System.Drawing.Image)
        Me.btSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(36, 36)
        Me.btSave.Text = "Save"
        '
        'btSearch
        '
        Me.btSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btSearch.Image = CType(resources.GetObject("btSearch.Image"), System.Drawing.Image)
        Me.btSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btSearch.Name = "btSearch"
        Me.btSearch.Size = New System.Drawing.Size(36, 36)
        Me.btSearch.Text = "Search"
        '
        'btDelete
        '
        Me.btDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btDelete.Image = CType(resources.GetObject("btDelete.Image"), System.Drawing.Image)
        Me.btDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btDelete.Name = "btDelete"
        Me.btDelete.Size = New System.Drawing.Size(36, 36)
        Me.btDelete.Text = "Delete"
        '
        '_Toolbar1_Button5
        '
        Me._Toolbar1_Button5.AutoSize = False
        Me._Toolbar1_Button5.Name = "_Toolbar1_Button5"
        Me._Toolbar1_Button5.Size = New System.Drawing.Size(10, 39)
        '
        'btExit
        '
        Me.btExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btExit.Image = CType(resources.GetObject("btExit.Image"), System.Drawing.Image)
        Me.btExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btExit.Name = "btExit"
        Me.btExit.Size = New System.Drawing.Size(36, 36)
        Me.btExit.Text = "Exit"
        '
        'frHeader
        '
        Me.frHeader.BackColor = System.Drawing.SystemColors.Control
        Me.frHeader.Controls.Add(Me.dtDate)
        Me.frHeader.Controls.Add(Me.txtExtc)
        Me.frHeader.Controls.Add(Me.txtSc)
        Me.frHeader.Controls.Add(Me.cbGroupName)
        Me.frHeader.Controls.Add(Me.txtWorkOrderNo)
        Me.frHeader.Controls.Add(Me.cbPeriod)
        Me.frHeader.Controls.Add(Me.txtYearPeriod)
        Me.frHeader.Controls.Add(Me.cbMonthPeriod)
        Me.frHeader.Controls.Add(Me.txtStoreId)
        Me.frHeader.Controls.Add(Me.cbAccount)
        Me.frHeader.Controls.Add(Me.txtInvoice)
        Me.frHeader.Controls.Add(Me.txtStore)
        Me.frHeader.Controls.Add(Me.cbState)
        Me.frHeader.Controls.Add(Me.cbVendor)
        Me.frHeader.Controls.Add(Me.cmdHelpCustomer)
        Me.frHeader.Controls.Add(Me.cbCustomer)
        Me.frHeader.Controls.Add(Me.Label15)
        Me.frHeader.Controls.Add(Me.Label14)
        Me.frHeader.Controls.Add(Me.Label11)
        Me.frHeader.Controls.Add(Me.Label10)
        Me.frHeader.Controls.Add(Me.Label9)
        Me.frHeader.Controls.Add(Me.Label6)
        Me.frHeader.Controls.Add(Me.lbEndDate)
        Me.frHeader.Controls.Add(Me.lbStartDate)
        Me.frHeader.Controls.Add(Me.Label8)
        Me.frHeader.Controls.Add(Me.Label7)
        Me.frHeader.Controls.Add(Me.Label3)
        Me.frHeader.Controls.Add(Me.Label1)
        Me.frHeader.Controls.Add(Me.label5)
        Me.frHeader.Controls.Add(Me.lVendorName)
        Me.frHeader.Controls.Add(Me.lVendorAddress)
        Me.frHeader.Controls.Add(Me.Label4)
        Me.frHeader.Controls.Add(Me.Label2)
        Me.frHeader.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frHeader.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frHeader.Location = New System.Drawing.Point(8, 64)
        Me.frHeader.Name = "frHeader"
        Me.frHeader.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frHeader.Size = New System.Drawing.Size(665, 177)
        Me.frHeader.TabIndex = 0
        Me.frHeader.TabStop = False
        Me.frHeader.Text = "General Information"
        '
        'dtDate
        '
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDate.Location = New System.Drawing.Point(248, 119)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(97, 20)
        Me.dtDate.TabIndex = 51
        '
        'txtExtc
        '
        Me.txtExtc.AcceptsReturn = True
        Me.txtExtc.BackColor = System.Drawing.SystemColors.Window
        Me.txtExtc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExtc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExtc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExtc.Location = New System.Drawing.Point(520, 152)
        Me.txtExtc.MaxLength = 0
        Me.txtExtc.Name = "txtExtc"
        Me.txtExtc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExtc.Size = New System.Drawing.Size(49, 20)
        Me.txtExtc.TabIndex = 50
        '
        'txtSc
        '
        Me.txtSc.AcceptsReturn = True
        Me.txtSc.BackColor = System.Drawing.SystemColors.Window
        Me.txtSc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSc.Location = New System.Drawing.Point(400, 152)
        Me.txtSc.MaxLength = 0
        Me.txtSc.Name = "txtSc"
        Me.txtSc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSc.Size = New System.Drawing.Size(57, 20)
        Me.txtSc.TabIndex = 48
        '
        'cbGroupName
        '
        Me.cbGroupName.BackColor = System.Drawing.SystemColors.Window
        Me.cbGroupName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGroupName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGroupName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbGroupName.Location = New System.Drawing.Point(248, 152)
        Me.cbGroupName.Name = "cbGroupName"
        Me.cbGroupName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbGroupName.Size = New System.Drawing.Size(113, 22)
        Me.cbGroupName.TabIndex = 43
        '
        'txtWorkOrderNo
        '
        Me.txtWorkOrderNo.AcceptsReturn = True
        Me.txtWorkOrderNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtWorkOrderNo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtWorkOrderNo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWorkOrderNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtWorkOrderNo.Location = New System.Drawing.Point(56, 152)
        Me.txtWorkOrderNo.MaxLength = 0
        Me.txtWorkOrderNo.Name = "txtWorkOrderNo"
        Me.txtWorkOrderNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWorkOrderNo.Size = New System.Drawing.Size(145, 20)
        Me.txtWorkOrderNo.TabIndex = 41
        '
        'cbPeriod
        '
        Me.cbPeriod.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbPeriod.Location = New System.Drawing.Point(440, 88)
        Me.cbPeriod.Name = "cbPeriod"
        Me.cbPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbPeriod.Size = New System.Drawing.Size(201, 22)
        Me.cbPeriod.TabIndex = 35
        '
        'txtYearPeriod
        '
        Me.txtYearPeriod.AcceptsReturn = True
        Me.txtYearPeriod.BackColor = System.Drawing.SystemColors.Window
        Me.txtYearPeriod.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtYearPeriod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYearPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtYearPeriod.Location = New System.Drawing.Point(504, 176)
        Me.txtYearPeriod.MaxLength = 0
        Me.txtYearPeriod.Name = "txtYearPeriod"
        Me.txtYearPeriod.ReadOnly = True
        Me.txtYearPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtYearPeriod.Size = New System.Drawing.Size(57, 20)
        Me.txtYearPeriod.TabIndex = 32
        Me.txtYearPeriod.Visible = False
        '
        'cbMonthPeriod
        '
        Me.cbMonthPeriod.BackColor = System.Drawing.SystemColors.Window
        Me.cbMonthPeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbMonthPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMonthPeriod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMonthPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbMonthPeriod.Location = New System.Drawing.Point(584, 40)
        Me.cbMonthPeriod.Name = "cbMonthPeriod"
        Me.cbMonthPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbMonthPeriod.Size = New System.Drawing.Size(81, 22)
        Me.cbMonthPeriod.TabIndex = 31
        Me.cbMonthPeriod.Visible = False
        '
        'txtStoreId
        '
        Me.txtStoreId.AcceptsReturn = True
        Me.txtStoreId.BackColor = System.Drawing.SystemColors.Menu
        Me.txtStoreId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreId.Location = New System.Drawing.Point(600, 16)
        Me.txtStoreId.MaxLength = 0
        Me.txtStoreId.Name = "txtStoreId"
        Me.txtStoreId.ReadOnly = True
        Me.txtStoreId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreId.Size = New System.Drawing.Size(57, 20)
        Me.txtStoreId.TabIndex = 24
        Me.txtStoreId.TabStop = False
        Me.txtStoreId.Visible = False
        '
        'cbAccount
        '
        Me.cbAccount.BackColor = System.Drawing.SystemColors.Window
        Me.cbAccount.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAccount.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAccount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbAccount.Location = New System.Drawing.Point(56, 88)
        Me.cbAccount.Name = "cbAccount"
        Me.cbAccount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbAccount.Size = New System.Drawing.Size(289, 22)
        Me.cbAccount.TabIndex = 6
        '
        'txtInvoice
        '
        Me.txtInvoice.AcceptsReturn = True
        Me.txtInvoice.BackColor = System.Drawing.SystemColors.Window
        Me.txtInvoice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInvoice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInvoice.Location = New System.Drawing.Point(56, 120)
        Me.txtInvoice.MaxLength = 20
        Me.txtInvoice.Name = "txtInvoice"
        Me.txtInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInvoice.Size = New System.Drawing.Size(145, 20)
        Me.txtInvoice.TabIndex = 7
        '
        'txtStore
        '
        Me.txtStore.AcceptsReturn = True
        Me.txtStore.BackColor = System.Drawing.SystemColors.Window
        Me.txtStore.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStore.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStore.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStore.Location = New System.Drawing.Point(240, 24)
        Me.txtStore.MaxLength = 0
        Me.txtStore.Name = "txtStore"
        Me.txtStore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStore.Size = New System.Drawing.Size(73, 20)
        Me.txtStore.TabIndex = 3
        Me.txtStore.Text = "Store#"
        '
        'cbState
        '
        Me.cbState.BackColor = System.Drawing.SystemColors.Window
        Me.cbState.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbState.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbState.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbState.Location = New System.Drawing.Point(152, 24)
        Me.cbState.Name = "cbState"
        Me.cbState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbState.Size = New System.Drawing.Size(49, 22)
        Me.cbState.TabIndex = 2
        Me.cbState.Text = "State"
        '
        'cbVendor
        '
        Me.cbVendor.BackColor = System.Drawing.SystemColors.Window
        Me.cbVendor.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVendor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVendor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbVendor.Items.AddRange(New Object() {"cbVendor"})
        Me.cbVendor.Location = New System.Drawing.Point(56, 56)
        Me.cbVendor.Name = "cbVendor"
        Me.cbVendor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbVendor.Size = New System.Drawing.Size(289, 22)
        Me.cbVendor.TabIndex = 5
        '
        'cbCustomer
        '
        Me.cbCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustomer.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustomer.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustomer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustomer.Location = New System.Drawing.Point(56, 24)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustomer.Size = New System.Drawing.Size(89, 22)
        Me.cbCustomer.TabIndex = 1
        Me.cbCustomer.Text = "Customer"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(475, 152)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(38, 17)
        Me.Label15.TabIndex = 49
        Me.Label15.Text = "EXTC"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(367, 152)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(23, 17)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "SC"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(207, 152)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(50, 20)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "Group"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(8, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(41, 30)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Work Order #"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(512, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(18, 19)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "To"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(391, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(34, 17)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "From"
        '
        'lbEndDate
        '
        Me.lbEndDate.BackColor = System.Drawing.SystemColors.Control
        Me.lbEndDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbEndDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEndDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbEndDate.Location = New System.Drawing.Point(536, 120)
        Me.lbEndDate.Name = "lbEndDate"
        Me.lbEndDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbEndDate.Size = New System.Drawing.Size(81, 17)
        Me.lbEndDate.TabIndex = 37
        Me.lbEndDate.Text = "lbEndDate"
        '
        'lbStartDate
        '
        Me.lbStartDate.BackColor = System.Drawing.SystemColors.Control
        Me.lbStartDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbStartDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStartDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbStartDate.Location = New System.Drawing.Point(432, 120)
        Me.lbStartDate.Name = "lbStartDate"
        Me.lbStartDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbStartDate.Size = New System.Drawing.Size(81, 17)
        Me.lbStartDate.TabIndex = 36
        Me.lbStartDate.Text = "lbStartDate"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(207, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(42, 19)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Store"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(8, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(42, 18)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Cust"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(42, 19)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Vendor"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Invoice #"
        '
        'label5
        '
        Me.label5.BackColor = System.Drawing.SystemColors.Control
        Me.label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label5.Location = New System.Drawing.Point(357, 88)
        Me.label5.Name = "label5"
        Me.label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label5.Size = New System.Drawing.Size(84, 17)
        Me.label5.TabIndex = 20
        Me.label5.Text = "Service Period"
        '
        'lVendorName
        '
        Me.lVendorName.BackColor = System.Drawing.SystemColors.Control
        Me.lVendorName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lVendorName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lVendorName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lVendorName.Location = New System.Drawing.Point(320, 176)
        Me.lVendorName.Name = "lVendorName"
        Me.lVendorName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lVendorName.Size = New System.Drawing.Size(161, 17)
        Me.lVendorName.TabIndex = 19
        Me.lVendorName.Text = "Vendor Name Xxxxxx Xxxxxxxxxxx"
        '
        'lVendorAddress
        '
        Me.lVendorAddress.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lVendorAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lVendorAddress.Cursor = System.Windows.Forms.Cursors.Default
        Me.lVendorAddress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lVendorAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lVendorAddress.Location = New System.Drawing.Point(360, 24)
        Me.lVendorAddress.Name = "lVendorAddress"
        Me.lVendorAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lVendorAddress.Size = New System.Drawing.Size(281, 53)
        Me.lVendorAddress.TabIndex = 18
        Me.lVendorAddress.Text = "Store Address Xxxxxxxxxxxxxxxxxxxxxxxxxx"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(208, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(34, 17)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Date"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(33, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Acc#"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.frDetail)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 56)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(681, 433)
        Me.Frame1.TabIndex = 12
        Me.Frame1.TabStop = False
        '
        'frDetail
        '
        Me.frDetail.BackColor = System.Drawing.SystemColors.Control
        Me.frDetail.Controls.Add(Me.cmdEdit)
        Me.frDetail.Controls.Add(Me.DataGrid1)
        Me.frDetail.Controls.Add(Me.txtGlmTotal)
        Me.frDetail.Controls.Add(Me.Text1)
        Me.frDetail.Controls.Add(Me.cmdNotes)
        Me.frDetail.Controls.Add(Me.cmdDrop)
        Me.frDetail.Controls.Add(Me.cbEquipment)
        Me.frDetail.Controls.Add(Me.cbService)
        Me.frDetail.Controls.Add(Me.cmdAdd)
        Me.frDetail.Controls.Add(Me.txtTotal)
        Me.frDetail.Controls.Add(Me.Label13)
        Me.frDetail.Controls.Add(Me.Label12)
        Me.frDetail.Controls.Add(Me.lblTotal)
        Me.frDetail.Controls.Add(Me.dgDetail)
        Me.frDetail.Cursor = System.Windows.Forms.Cursors.Default
        Me.frDetail.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frDetail.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frDetail.Location = New System.Drawing.Point(0, 152)
        Me.frDetail.Name = "frDetail"
        Me.frDetail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frDetail.Size = New System.Drawing.Size(673, 261)
        Me.frDetail.TabIndex = 14
        Me.frDetail.Text = "Detail"
        '
        'DataGrid1
        '
        Me.DataGrid1.AllowUserToAddRows = False
        Me.DataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGrid1.Location = New System.Drawing.Point(417, 112)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(240, 81)
        Me.DataGrid1.TabIndex = 36
        Me.DataGrid1.Visible = False
        '
        'txtGlmTotal
        '
        Me.txtGlmTotal.AllowPromptAsInput = False
        Me.txtGlmTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtGlmTotal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGlmTotal.Location = New System.Drawing.Point(336, 224)
        Me.txtGlmTotal.Name = "txtGlmTotal"
        Me.txtGlmTotal.Size = New System.Drawing.Size(113, 20)
        Me.txtGlmTotal.TabIndex = 46
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(528, 24)
        Me.Text1.MaxLength = 0
        Me.Text1.Multiline = True
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(97, 169)
        Me.Text1.TabIndex = 33
        Me.Text1.Visible = False
        '
        'cbEquipment
        '
        Me.cbEquipment.BackColor = System.Drawing.SystemColors.Window
        Me.cbEquipment.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEquipment.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEquipment.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbEquipment.Location = New System.Drawing.Point(16, 128)
        Me.cbEquipment.Name = "cbEquipment"
        Me.cbEquipment.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbEquipment.Size = New System.Drawing.Size(81, 22)
        Me.cbEquipment.TabIndex = 26
        Me.cbEquipment.TabStop = False
        Me.cbEquipment.Visible = False
        '
        'cbService
        '
        Me.cbService.BackColor = System.Drawing.SystemColors.Window
        Me.cbService.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbService.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbService.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbService.Location = New System.Drawing.Point(24, 160)
        Me.cbService.Name = "cbService"
        Me.cbService.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbService.Size = New System.Drawing.Size(81, 22)
        Me.cbService.TabIndex = 25
        Me.cbService.TabStop = False
        Me.cbService.Visible = False
        '
        'txtTotal
        '
        Me.txtTotal.AllowPromptAsInput = False
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTotal.Enabled = False
        Me.txtTotal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(544, 224)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(113, 20)
        Me.txtTotal.TabIndex = 16
        Me.txtTotal.TabStop = False
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(464, 232)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(81, 25)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "Actual Subtotal"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(264, 232)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(73, 25)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "GLM Subtotal"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotal.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotal.Location = New System.Drawing.Point(489, 92)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTotal.Size = New System.Drawing.Size(33, 17)
        Me.lblTotal.TabIndex = 17
        Me.lblTotal.Text = "Total:"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblTotal.Visible = False
        '
        'dgDetail
        '
        Me.dgDetail.AllowUserToAddRows = False
        Me.dgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetail.Location = New System.Drawing.Point(6, 39)
        Me.dgDetail.Name = "dgDetail"
        Me.dgDetail.Size = New System.Drawing.Size(659, 166)
        Me.dgDetail.TabIndex = 35
        '
        'frmInvoiceBooking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(698, 498)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.frHeader)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Location = New System.Drawing.Point(66, 83)
        Me.Name = "frmInvoiceBooking"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Invoice Booking"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.frHeader.ResumeLayout(False)
        Me.frHeader.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.frDetail.ResumeLayout(False)
        Me.frDetail.PerformLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgDetail As System.Windows.Forms.DataGridView
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGridView
    Friend WithEvents btNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents btDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btExit As System.Windows.Forms.ToolStripButton
#End Region 
End Class