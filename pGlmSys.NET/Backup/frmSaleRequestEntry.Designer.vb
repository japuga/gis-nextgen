<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSaleRequestEntry
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
	Public WithEvents dgRequestItems As AxMSDataGridLib.AxDataGrid
	Public WithEvents tbSaleItem As System.Windows.Forms.ToolStrip
	Public WithEvents _SSTab1_TabPage0 As System.Windows.Forms.TabPage
	Public WithEvents dgSaleTickets As AxMSDataGridLib.AxDataGrid
	Public WithEvents tbSaleTicket As System.Windows.Forms.ToolStrip
	Public WithEvents _SSTab1_TabPage1 As System.Windows.Forms.TabPage
	Public WithEvents SSTab1 As System.Windows.Forms.TabControl
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents txtNotes As System.Windows.Forms.TextBox
	Public WithEvents cbStoreNo As System.Windows.Forms.ComboBox
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
	Public WithEvents txtStoreName As System.Windows.Forms.TextBox
	Public WithEvents txtTrackingNo As System.Windows.Forms.TextBox
	Public WithEvents dtResponseDate As AxMSComCtl2.AxDTPicker
	Public WithEvents dtRequestDate As AxMSComCtl2.AxDTPicker
	Public WithEvents txtSaleRequest As System.Windows.Forms.TextBox
	Public WithEvents _Toolbar1_Button5 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
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
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSaleRequestEntry))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.SSTab1 = New System.Windows.Forms.TabControl
		Me._SSTab1_TabPage0 = New System.Windows.Forms.TabPage
		Me.dgRequestItems = New AxMSDataGridLib.AxDataGrid
		Me.tbSaleItem = New System.Windows.Forms.ToolStrip
		Me._SSTab1_TabPage1 = New System.Windows.Forms.TabPage
		Me.dgSaleTickets = New AxMSDataGridLib.AxDataGrid
		Me.tbSaleTicket = New System.Windows.Forms.ToolStrip
		Me.cbCustId = New System.Windows.Forms.ComboBox
		Me.txtNotes = New System.Windows.Forms.TextBox
		Me.cbStoreNo = New System.Windows.Forms.ComboBox
		Me.cbCustName = New System.Windows.Forms.ComboBox
		Me.txtStoreName = New System.Windows.Forms.TextBox
		Me.txtTrackingNo = New System.Windows.Forms.TextBox
		Me.dtResponseDate = New AxMSComCtl2.AxDTPicker
		Me.dtRequestDate = New AxMSComCtl2.AxDTPicker
		Me.txtSaleRequest = New System.Windows.Forms.TextBox
		Me.Toolbar1 = New System.Windows.Forms.ToolStrip
		Me._Toolbar1_Button5 = New System.Windows.Forms.ToolStripSeparator
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SSTab1.SuspendLayout()
		Me._SSTab1_TabPage0.SuspendLayout()
		Me.tbSaleItem.SuspendLayout()
		Me._SSTab1_TabPage1.SuspendLayout()
		Me.tbSaleTicket.SuspendLayout()
		Me.Toolbar1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.dgRequestItems, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dgSaleTickets, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dtResponseDate, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dtRequestDate, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Sale Request"
		Me.ClientSize = New System.Drawing.Size(719, 562)
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
		Me.Name = "frmSaleRequestEntry"
		Me.SSTab1.Size = New System.Drawing.Size(681, 305)
		Me.SSTab1.Location = New System.Drawing.Point(16, 248)
		Me.SSTab1.TabIndex = 18
		Me.SSTab1.SelectedIndex = 1
		Me.SSTab1.ItemSize = New System.Drawing.Size(42, 18)
		Me.SSTab1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.SSTab1.Name = "SSTab1"
		Me._SSTab1_TabPage0.Text = "Items for Sale"
		dgRequestItems.OcxState = CType(resources.GetObject("dgRequestItems.OcxState"), System.Windows.Forms.AxHost.State)
		Me.dgRequestItems.Size = New System.Drawing.Size(649, 201)
		Me.dgRequestItems.Location = New System.Drawing.Point(16, 80)
		Me.dgRequestItems.TabIndex = 20
		Me.dgRequestItems.Name = "dgRequestItems"
		Me.tbSaleItem.ShowItemToolTips = True
		Me.tbSaleItem.Size = New System.Drawing.Size(665, 42)
		Me.tbSaleItem.Location = New System.Drawing.Point(8, 24)
		Me.tbSaleItem.TabIndex = 19
		Me.tbSaleItem.ImageList = ImageList2
		Me.tbSaleItem.Name = "tbSaleItem"
		Me._SSTab1_TabPage1.Text = "Sale Tickets"
		dgSaleTickets.OcxState = CType(resources.GetObject("dgSaleTickets.OcxState"), System.Windows.Forms.AxHost.State)
		Me.dgSaleTickets.Size = New System.Drawing.Size(649, 209)
		Me.dgSaleTickets.Location = New System.Drawing.Point(16, 80)
		Me.dgSaleTickets.TabIndex = 21
		Me.dgSaleTickets.Name = "dgSaleTickets"
		Me.tbSaleTicket.ShowItemToolTips = True
		Me.tbSaleTicket.Size = New System.Drawing.Size(665, 42)
		Me.tbSaleTicket.Location = New System.Drawing.Point(8, 24)
		Me.tbSaleTicket.TabIndex = 22
		Me.tbSaleTicket.ImageList = ImageList2
		Me.tbSaleTicket.Name = "tbSaleTicket"
		Me.cbCustId.Size = New System.Drawing.Size(65, 21)
		Me.cbCustId.Location = New System.Drawing.Point(304, 48)
		Me.cbCustId.TabIndex = 17
		Me.cbCustId.Text = "Combo1"
		Me.cbCustId.Visible = False
		Me.cbCustId.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
		Me.cbCustId.CausesValidation = True
		Me.cbCustId.Enabled = True
		Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbCustId.IntegralHeight = True
		Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbCustId.Sorted = False
		Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cbCustId.TabStop = True
		Me.cbCustId.Name = "cbCustId"
		Me.txtNotes.AutoSize = False
		Me.txtNotes.Size = New System.Drawing.Size(345, 97)
		Me.txtNotes.Location = New System.Drawing.Point(352, 144)
		Me.txtNotes.MultiLine = True
		Me.txtNotes.TabIndex = 16
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
		Me.cbStoreNo.Size = New System.Drawing.Size(233, 21)
		Me.cbStoreNo.Location = New System.Drawing.Point(96, 104)
		Me.cbStoreNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbStoreNo.TabIndex = 14
		Me.cbStoreNo.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbStoreNo.BackColor = System.Drawing.SystemColors.Window
		Me.cbStoreNo.CausesValidation = True
		Me.cbStoreNo.Enabled = True
		Me.cbStoreNo.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbStoreNo.IntegralHeight = True
		Me.cbStoreNo.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbStoreNo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbStoreNo.Sorted = False
		Me.cbStoreNo.TabStop = True
		Me.cbStoreNo.Visible = True
		Me.cbStoreNo.Name = "cbStoreNo"
		Me.cbCustName.Size = New System.Drawing.Size(233, 21)
		Me.cbCustName.Location = New System.Drawing.Point(96, 72)
		Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbCustName.TabIndex = 13
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
		Me.txtStoreName.AutoSize = False
		Me.txtStoreName.Size = New System.Drawing.Size(233, 21)
		Me.txtStoreName.Location = New System.Drawing.Point(96, 136)
		Me.txtStoreName.TabIndex = 11
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
		Me.txtTrackingNo.AutoSize = False
		Me.txtTrackingNo.Size = New System.Drawing.Size(233, 21)
		Me.txtTrackingNo.Location = New System.Drawing.Point(96, 200)
		Me.txtTrackingNo.TabIndex = 8
		Me.txtTrackingNo.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtTrackingNo.AcceptsReturn = True
		Me.txtTrackingNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTrackingNo.BackColor = System.Drawing.SystemColors.Window
		Me.txtTrackingNo.CausesValidation = True
		Me.txtTrackingNo.Enabled = True
		Me.txtTrackingNo.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTrackingNo.HideSelection = True
		Me.txtTrackingNo.ReadOnly = False
		Me.txtTrackingNo.Maxlength = 0
		Me.txtTrackingNo.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTrackingNo.MultiLine = False
		Me.txtTrackingNo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTrackingNo.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTrackingNo.TabStop = True
		Me.txtTrackingNo.Visible = True
		Me.txtTrackingNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTrackingNo.Name = "txtTrackingNo"
		dtResponseDate.OcxState = CType(resources.GetObject("dtResponseDate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.dtResponseDate.Size = New System.Drawing.Size(105, 21)
		Me.dtResponseDate.Location = New System.Drawing.Point(440, 104)
		Me.dtResponseDate.TabIndex = 6
		Me.dtResponseDate.Name = "dtResponseDate"
		dtRequestDate.OcxState = CType(resources.GetObject("dtRequestDate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.dtRequestDate.Size = New System.Drawing.Size(105, 21)
		Me.dtRequestDate.Location = New System.Drawing.Point(440, 72)
		Me.dtRequestDate.TabIndex = 4
		Me.dtRequestDate.Name = "dtRequestDate"
		Me.txtSaleRequest.AutoSize = False
		Me.txtSaleRequest.Size = New System.Drawing.Size(233, 21)
		Me.txtSaleRequest.Location = New System.Drawing.Point(96, 168)
		Me.txtSaleRequest.TabIndex = 2
		Me.txtSaleRequest.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSaleRequest.AcceptsReturn = True
		Me.txtSaleRequest.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtSaleRequest.BackColor = System.Drawing.SystemColors.Window
		Me.txtSaleRequest.CausesValidation = True
		Me.txtSaleRequest.Enabled = True
		Me.txtSaleRequest.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSaleRequest.HideSelection = True
		Me.txtSaleRequest.ReadOnly = False
		Me.txtSaleRequest.Maxlength = 0
		Me.txtSaleRequest.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSaleRequest.MultiLine = False
		Me.txtSaleRequest.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSaleRequest.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtSaleRequest.TabStop = True
		Me.txtSaleRequest.Visible = True
		Me.txtSaleRequest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtSaleRequest.Name = "txtSaleRequest"
		Me.Toolbar1.ShowItemToolTips = True
		Me.Toolbar1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Toolbar1.Size = New System.Drawing.Size(719, 44)
		Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
		Me.Toolbar1.TabIndex = 0
		Me.Toolbar1.ImageList = ImageList2
		Me.Toolbar1.Name = "Toolbar1"
		Me._Toolbar1_Button5.Size = New System.Drawing.Size(40, 39)
		Me._Toolbar1_Button5.AutoSize = False
		Me._Toolbar1_Button5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
		Me._Toolbar1_Button5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me._Toolbar1_Button5.ToolTipText = "Print"
		Me._Toolbar1_Button5.Width = 10
		Me._Toolbar1_Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me.Label8.Text = "Notes"
		Me.Label8.Size = New System.Drawing.Size(49, 17)
		Me.Label8.Location = New System.Drawing.Point(352, 128)
		Me.Label8.TabIndex = 15
		Me.Label8.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label8.BackColor = System.Drawing.SystemColors.Control
		Me.Label8.Enabled = True
		Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label8.UseMnemonic = True
		Me.Label8.Visible = True
		Me.Label8.AutoSize = False
		Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label8.Name = "Label8"
		Me.Label7.Text = "Customer"
		Me.Label7.Size = New System.Drawing.Size(57, 17)
		Me.Label7.Location = New System.Drawing.Point(32, 72)
		Me.Label7.TabIndex = 12
		Me.Label7.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label7.BackColor = System.Drawing.SystemColors.Control
		Me.Label7.Enabled = True
		Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = False
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Label6.Text = "Store Name"
		Me.Label6.Size = New System.Drawing.Size(65, 17)
		Me.Label6.Location = New System.Drawing.Point(32, 136)
		Me.Label6.TabIndex = 10
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
		Me.Label5.Text = "Store No"
		Me.Label5.Size = New System.Drawing.Size(57, 17)
		Me.Label5.Location = New System.Drawing.Point(32, 104)
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
		Me.Label4.Text = "Tracking #"
		Me.Label4.Size = New System.Drawing.Size(65, 17)
		Me.Label4.Location = New System.Drawing.Point(32, 200)
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
		Me.Label3.Text = "Response Date"
		Me.Label3.Size = New System.Drawing.Size(81, 17)
		Me.Label3.Location = New System.Drawing.Point(352, 104)
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
		Me.Label2.Text = "Received Date"
		Me.Label2.Size = New System.Drawing.Size(73, 17)
		Me.Label2.Location = New System.Drawing.Point(352, 72)
		Me.Label2.TabIndex = 3
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
		Me.Label1.Text = "Request"
		Me.Label1.Size = New System.Drawing.Size(49, 17)
		Me.Label1.Location = New System.Drawing.Point(32, 168)
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
		Me.Controls.Add(SSTab1)
		Me.Controls.Add(cbCustId)
		Me.Controls.Add(txtNotes)
		Me.Controls.Add(cbStoreNo)
		Me.Controls.Add(cbCustName)
		Me.Controls.Add(txtStoreName)
		Me.Controls.Add(txtTrackingNo)
		Me.Controls.Add(dtResponseDate)
		Me.Controls.Add(dtRequestDate)
		Me.Controls.Add(txtSaleRequest)
		Me.Controls.Add(Toolbar1)
		Me.Controls.Add(Label8)
		Me.Controls.Add(Label7)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.SSTab1.Controls.Add(_SSTab1_TabPage0)
		Me.SSTab1.Controls.Add(_SSTab1_TabPage1)
		Me._SSTab1_TabPage0.Controls.Add(dgRequestItems)
		Me._SSTab1_TabPage0.Controls.Add(tbSaleItem)
		Me._SSTab1_TabPage1.Controls.Add(dgSaleTickets)
		Me._SSTab1_TabPage1.Controls.Add(tbSaleTicket)
		Me.Toolbar1.Items.Add(_Toolbar1_Button5)
		CType(Me.dtRequestDate, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dtResponseDate, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dgSaleTickets, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dgRequestItems, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SSTab1.ResumeLayout(False)
		Me._SSTab1_TabPage0.ResumeLayout(False)
		Me.tbSaleItem.ResumeLayout(False)
		Me._SSTab1_TabPage1.ResumeLayout(False)
		Me.tbSaleTicket.ResumeLayout(False)
		Me.Toolbar1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class