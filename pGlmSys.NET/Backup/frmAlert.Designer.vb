<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmAlert
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
	Public WithEvents _Toolbar1_Button3 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents _SSTab1_TabPage0 As System.Windows.Forms.TabPage
    Public WithEvents _SSTab1_TabPage1 As System.Windows.Forms.TabPage
	Public WithEvents txtMessage As System.Windows.Forms.TextBox
    Public WithEvents Toolbar2 As System.Windows.Forms.ToolStrip
    Public WithEvents tmpRitchTxt As System.Windows.Forms.RichTextBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _SSTab1_TabPage2 As System.Windows.Forms.TabPage
	Public WithEvents SSTab1 As System.Windows.Forms.TabControl
	Public WithEvents cbStoreNo As System.Windows.Forms.ComboBox
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
	Public WithEvents cbState As System.Windows.Forms.ComboBox
	Public WithEvents txtStoreCoCode As System.Windows.Forms.TextBox
	Public WithEvents txtStoreFolder As System.Windows.Forms.TextBox
	Public WithEvents txtStoreZip As System.Windows.Forms.TextBox
	Public WithEvents cbStoreStatus As System.Windows.Forms.ComboBox
	Public WithEvents txtStoreContact As System.Windows.Forms.TextBox
	Public WithEvents txtStoreCity As System.Windows.Forms.TextBox
	Public WithEvents txtStoreAddress As System.Windows.Forms.TextBox
	Public WithEvents txtStoreName As System.Windows.Forms.TextBox
	Public WithEvents txtOccupants As System.Windows.Forms.TextBox
	Public WithEvents mtxtStorePhone1 As System.Windows.Forms.MaskedTextBox
	Public WithEvents mtxtStorePhone2 As System.Windows.Forms.MaskedTextBox
	Public WithEvents mtxtStoreFax1 As System.Windows.Forms.MaskedTextBox
	Public WithEvents mtxtStoreFax2 As System.Windows.Forms.MaskedTextBox
	Public WithEvents Label16 As System.Windows.Forms.Label
	Public WithEvents Label17 As System.Windows.Forms.Label
	Public WithEvents Label18 As System.Windows.Forms.Label
	Public WithEvents Label19 As System.Windows.Forms.Label
	Public WithEvents Label20 As System.Windows.Forms.Label
	Public WithEvents Label21 As System.Windows.Forms.Label
	Public WithEvents Label22 As System.Windows.Forms.Label
	Public WithEvents Label23 As System.Windows.Forms.Label
	Public WithEvents Label24 As System.Windows.Forms.Label
	Public WithEvents Label25 As System.Windows.Forms.Label
	Public WithEvents Label26 As System.Windows.Forms.Label
	Public WithEvents Label27 As System.Windows.Forms.Label
	Public WithEvents Label28 As System.Windows.Forms.Label
	Public WithEvents Label29 As System.Windows.Forms.Label
	Public WithEvents Label30 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents imlToolbarIcons As System.Windows.Forms.ImageList
	Public WithEvents ImageList2 As System.Windows.Forms.ImageList
	Public WithEvents lblMessage As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAlert))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtStoreName = New System.Windows.Forms.TextBox
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip
        Me.imlToolbarIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.btFind = New System.Windows.Forms.ToolStripButton
        Me.btClear = New System.Windows.Forms.ToolStripButton
        Me._Toolbar1_Button3 = New System.Windows.Forms.ToolStripSeparator
        Me.btFirst = New System.Windows.Forms.ToolStripButton
        Me.btBack = New System.Windows.Forms.ToolStripButton
        Me.btForward = New System.Windows.Forms.ToolStripButton
        Me.btLast = New System.Windows.Forms.ToolStripButton
        Me.SSTab1 = New System.Windows.Forms.TabControl
        Me._SSTab1_TabPage0 = New System.Windows.Forms.TabPage
        Me.dgEquipment = New System.Windows.Forms.DataGridView
        Me.Command1 = New System.Windows.Forms.Button
        Me._SSTab1_TabPage1 = New System.Windows.Forms.TabPage
        Me.lblServiceFreq = New System.Windows.Forms.Label
        Me.dgService = New System.Windows.Forms.DataGridView
        Me.lblVendorAccounts = New System.Windows.Forms.Label
        Me.dgVendor = New System.Windows.Forms.DataGridView
        Me._SSTab1_TabPage2 = New System.Windows.Forms.TabPage
        Me.dgNotes = New System.Windows.Forms.DataGridView
        Me.dtTo = New System.Windows.Forms.DateTimePicker
        Me.dtFrom = New System.Windows.Forms.DateTimePicker
        Me.txtMessage = New System.Windows.Forms.TextBox
        Me.Toolbar2 = New System.Windows.Forms.ToolStrip
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.btNew = New System.Windows.Forms.ToolStripButton
        Me.btSave = New System.Windows.Forms.ToolStripButton
        Me.btSearch = New System.Windows.Forms.ToolStripButton
        Me.tmpRitchTxt = New System.Windows.Forms.RichTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.cbStoreNo = New System.Windows.Forms.ComboBox
        Me.cbCustId = New System.Windows.Forms.ComboBox
        Me.cbCustName = New System.Windows.Forms.ComboBox
        Me.cbState = New System.Windows.Forms.ComboBox
        Me.txtStoreCoCode = New System.Windows.Forms.TextBox
        Me.txtStoreFolder = New System.Windows.Forms.TextBox
        Me.txtStoreZip = New System.Windows.Forms.TextBox
        Me.cbStoreStatus = New System.Windows.Forms.ComboBox
        Me.txtStoreContact = New System.Windows.Forms.TextBox
        Me.txtStoreCity = New System.Windows.Forms.TextBox
        Me.txtStoreAddress = New System.Windows.Forms.TextBox
        Me.txtOccupants = New System.Windows.Forms.TextBox
        Me.mtxtStorePhone1 = New System.Windows.Forms.MaskedTextBox
        Me.mtxtStorePhone2 = New System.Windows.Forms.MaskedTextBox
        Me.mtxtStoreFax1 = New System.Windows.Forms.MaskedTextBox
        Me.mtxtStoreFax2 = New System.Windows.Forms.MaskedTextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblMessage = New System.Windows.Forms.Label
        Me.Toolbar1.SuspendLayout()
        Me.SSTab1.SuspendLayout()
        Me._SSTab1_TabPage0.SuspendLayout()
        CType(Me.dgEquipment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._SSTab1_TabPage1.SuspendLayout()
        CType(Me.dgService, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgVendor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._SSTab1_TabPage2.SuspendLayout()
        CType(Me.dgNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Toolbar2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtStoreName
        '
        Me.txtStoreName.AcceptsReturn = True
        Me.txtStoreName.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreName.Location = New System.Drawing.Point(96, 64)
        Me.txtStoreName.MaxLength = 0
        Me.txtStoreName.Name = "txtStoreName"
        Me.txtStoreName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreName.Size = New System.Drawing.Size(233, 20)
        Me.txtStoreName.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtStoreName, "Store Name")
        '
        'Toolbar1
        '
        Me.Toolbar1.ImageList = Me.imlToolbarIcons
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btFind, Me.btClear, Me._Toolbar1_Button3, Me.btFirst, Me.btBack, Me.btForward, Me.btLast})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(820, 31)
        Me.Toolbar1.TabIndex = 37
        '
        'imlToolbarIcons
        '
        Me.imlToolbarIcons.ImageStream = CType(resources.GetObject("imlToolbarIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlToolbarIcons.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.imlToolbarIcons.Images.SetKeyName(0, "Find")
        Me.imlToolbarIcons.Images.SetKeyName(1, "Forward")
        Me.imlToolbarIcons.Images.SetKeyName(2, "Back")
        '
        'btFind
        '
        Me.btFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btFind.Image = CType(resources.GetObject("btFind.Image"), System.Drawing.Image)
        Me.btFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btFind.Name = "btFind"
        Me.btFind.Size = New System.Drawing.Size(28, 28)
        Me.btFind.Text = "Find"
        '
        'btClear
        '
        Me.btClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btClear.Image = CType(resources.GetObject("btClear.Image"), System.Drawing.Image)
        Me.btClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(28, 28)
        Me.btClear.Text = "Clear"
        '
        '_Toolbar1_Button3
        '
        Me._Toolbar1_Button3.AutoSize = False
        Me._Toolbar1_Button3.Name = "_Toolbar1_Button3"
        Me._Toolbar1_Button3.Size = New System.Drawing.Size(24, 22)
        '
        'btFirst
        '
        Me.btFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btFirst.Image = CType(resources.GetObject("btFirst.Image"), System.Drawing.Image)
        Me.btFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btFirst.Name = "btFirst"
        Me.btFirst.Size = New System.Drawing.Size(28, 28)
        Me.btFirst.Text = "First"
        '
        'btBack
        '
        Me.btBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btBack.Image = CType(resources.GetObject("btBack.Image"), System.Drawing.Image)
        Me.btBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btBack.Name = "btBack"
        Me.btBack.Size = New System.Drawing.Size(28, 28)
        Me.btBack.Text = "Back"
        '
        'btForward
        '
        Me.btForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btForward.Image = CType(resources.GetObject("btForward.Image"), System.Drawing.Image)
        Me.btForward.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btForward.Name = "btForward"
        Me.btForward.Size = New System.Drawing.Size(28, 28)
        Me.btForward.Text = "Forward"
        '
        'btLast
        '
        Me.btLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btLast.Image = CType(resources.GetObject("btLast.Image"), System.Drawing.Image)
        Me.btLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btLast.Name = "btLast"
        Me.btLast.Size = New System.Drawing.Size(28, 28)
        Me.btLast.Text = "Last"
        '
        'SSTab1
        '
        Me.SSTab1.Controls.Add(Me._SSTab1_TabPage0)
        Me.SSTab1.Controls.Add(Me._SSTab1_TabPage1)
        Me.SSTab1.Controls.Add(Me._SSTab1_TabPage2)
        Me.SSTab1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSTab1.ItemSize = New System.Drawing.Size(42, 18)
        Me.SSTab1.Location = New System.Drawing.Point(16, 280)
        Me.SSTab1.Name = "SSTab1"
        Me.SSTab1.SelectedIndex = 0
        Me.SSTab1.Size = New System.Drawing.Size(777, 297)
        Me.SSTab1.TabIndex = 34
        '
        '_SSTab1_TabPage0
        '
        Me._SSTab1_TabPage0.Controls.Add(Me.dgEquipment)
        Me._SSTab1_TabPage0.Controls.Add(Me.Command1)
        Me._SSTab1_TabPage0.Location = New System.Drawing.Point(4, 22)
        Me._SSTab1_TabPage0.Name = "_SSTab1_TabPage0"
        Me._SSTab1_TabPage0.Size = New System.Drawing.Size(769, 271)
        Me._SSTab1_TabPage0.TabIndex = 0
        Me._SSTab1_TabPage0.Text = "Equipment"
        '
        'dgEquipment
        '
        Me.dgEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgEquipment.Location = New System.Drawing.Point(14, 35)
        Me.dgEquipment.Name = "dgEquipment"
        Me.dgEquipment.Size = New System.Drawing.Size(729, 177)
        Me.dgEquipment.TabIndex = 41
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(24, 232)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(89, 33)
        Me.Command1.TabIndex = 40
        Me.Command1.Text = "Vendor Accounts"
        Me.Command1.UseVisualStyleBackColor = False
        '
        '_SSTab1_TabPage1
        '
        Me._SSTab1_TabPage1.Controls.Add(Me.lblServiceFreq)
        Me._SSTab1_TabPage1.Controls.Add(Me.dgService)
        Me._SSTab1_TabPage1.Controls.Add(Me.lblVendorAccounts)
        Me._SSTab1_TabPage1.Controls.Add(Me.dgVendor)
        Me._SSTab1_TabPage1.Location = New System.Drawing.Point(4, 22)
        Me._SSTab1_TabPage1.Name = "_SSTab1_TabPage1"
        Me._SSTab1_TabPage1.Size = New System.Drawing.Size(769, 271)
        Me._SSTab1_TabPage1.TabIndex = 1
        Me._SSTab1_TabPage1.Text = "Vendor"
        '
        'lblServiceFreq
        '
        Me.lblServiceFreq.AutoSize = True
        Me.lblServiceFreq.Location = New System.Drawing.Point(325, 155)
        Me.lblServiceFreq.Name = "lblServiceFreq"
        Me.lblServiceFreq.Size = New System.Drawing.Size(120, 14)
        Me.lblServiceFreq.TabIndex = 42
        Me.lblServiceFreq.Text = "Service and Frequency"
        '
        'dgService
        '
        Me.dgService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgService.Location = New System.Drawing.Point(16, 172)
        Me.dgService.Name = "dgService"
        Me.dgService.Size = New System.Drawing.Size(745, 87)
        Me.dgService.TabIndex = 41
        '
        'lblVendorAccounts
        '
        Me.lblVendorAccounts.AutoSize = True
        Me.lblVendorAccounts.Location = New System.Drawing.Point(338, 19)
        Me.lblVendorAccounts.Name = "lblVendorAccounts"
        Me.lblVendorAccounts.Size = New System.Drawing.Size(91, 14)
        Me.lblVendorAccounts.TabIndex = 40
        Me.lblVendorAccounts.Text = "Vendor Accounts"
        '
        'dgVendor
        '
        Me.dgVendor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgVendor.Location = New System.Drawing.Point(16, 38)
        Me.dgVendor.Name = "dgVendor"
        Me.dgVendor.Size = New System.Drawing.Size(745, 107)
        Me.dgVendor.TabIndex = 39
        '
        '_SSTab1_TabPage2
        '
        Me._SSTab1_TabPage2.Controls.Add(Me.dgNotes)
        Me._SSTab1_TabPage2.Controls.Add(Me.dtTo)
        Me._SSTab1_TabPage2.Controls.Add(Me.dtFrom)
        Me._SSTab1_TabPage2.Controls.Add(Me.txtMessage)
        Me._SSTab1_TabPage2.Controls.Add(Me.Toolbar2)
        Me._SSTab1_TabPage2.Controls.Add(Me.tmpRitchTxt)
        Me._SSTab1_TabPage2.Controls.Add(Me.Label3)
        Me._SSTab1_TabPage2.Controls.Add(Me.Label2)
        Me._SSTab1_TabPage2.Controls.Add(Me.Label1)
        Me._SSTab1_TabPage2.Location = New System.Drawing.Point(4, 22)
        Me._SSTab1_TabPage2.Name = "_SSTab1_TabPage2"
        Me._SSTab1_TabPage2.Size = New System.Drawing.Size(769, 271)
        Me._SSTab1_TabPage2.TabIndex = 2
        Me._SSTab1_TabPage2.Text = "Notes"
        '
        'dgNotes
        '
        Me.dgNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgNotes.Location = New System.Drawing.Point(3, 90)
        Me.dgNotes.Name = "dgNotes"
        Me.dgNotes.Size = New System.Drawing.Size(758, 178)
        Me.dgNotes.TabIndex = 52
        '
        'dtTo
        '
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(286, 63)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(88, 20)
        Me.dtTo.TabIndex = 51
        '
        'dtFrom
        '
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.Location = New System.Drawing.Point(69, 64)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(95, 20)
        Me.dtFrom.TabIndex = 50
        '
        'txtMessage
        '
        Me.txtMessage.AcceptsReturn = True
        Me.txtMessage.BackColor = System.Drawing.SystemColors.Window
        Me.txtMessage.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMessage.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessage.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMessage.Location = New System.Drawing.Point(69, 42)
        Me.txtMessage.MaxLength = 0
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMessage.Size = New System.Drawing.Size(465, 20)
        Me.txtMessage.TabIndex = 45
        '
        'Toolbar2
        '
        Me.Toolbar2.ImageList = Me.ImageList2
        Me.Toolbar2.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbar2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNew, Me.btSave, Me.btSearch})
        Me.Toolbar2.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar2.Name = "Toolbar2"
        Me.Toolbar2.Size = New System.Drawing.Size(769, 39)
        Me.Toolbar2.TabIndex = 41
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ImageList2.Images.SetKeyName(0, "new")
        Me.ImageList2.Images.SetKeyName(1, "")
        Me.ImageList2.Images.SetKeyName(2, "save")
        Me.ImageList2.Images.SetKeyName(3, "search")
        Me.ImageList2.Images.SetKeyName(4, "print")
        Me.ImageList2.Images.SetKeyName(5, "exit")
        Me.ImageList2.Images.SetKeyName(6, "")
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
        'tmpRitchTxt
        '
        Me.tmpRitchTxt.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tmpRitchTxt.Location = New System.Drawing.Point(672, 136)
        Me.tmpRitchTxt.Name = "tmpRitchTxt"
        Me.tmpRitchTxt.Size = New System.Drawing.Size(33, 25)
        Me.tmpRitchTxt.TabIndex = 49
        Me.tmpRitchTxt.Text = "Rã" & Global.Microsoft.VisualBasic.ChrW(10) & "'Îã"
        Me.tmpRitchTxt.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(253, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(41, 17)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "To"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(13, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Regarding"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(13, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(36, 17)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "From"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.cbStoreNo)
        Me.Frame1.Controls.Add(Me.cbCustId)
        Me.Frame1.Controls.Add(Me.cbCustName)
        Me.Frame1.Controls.Add(Me.cbState)
        Me.Frame1.Controls.Add(Me.txtStoreCoCode)
        Me.Frame1.Controls.Add(Me.txtStoreFolder)
        Me.Frame1.Controls.Add(Me.txtStoreZip)
        Me.Frame1.Controls.Add(Me.cbStoreStatus)
        Me.Frame1.Controls.Add(Me.txtStoreContact)
        Me.Frame1.Controls.Add(Me.txtStoreCity)
        Me.Frame1.Controls.Add(Me.txtStoreAddress)
        Me.Frame1.Controls.Add(Me.txtStoreName)
        Me.Frame1.Controls.Add(Me.txtOccupants)
        Me.Frame1.Controls.Add(Me.mtxtStorePhone1)
        Me.Frame1.Controls.Add(Me.mtxtStorePhone2)
        Me.Frame1.Controls.Add(Me.mtxtStoreFax1)
        Me.Frame1.Controls.Add(Me.mtxtStoreFax2)
        Me.Frame1.Controls.Add(Me.Label16)
        Me.Frame1.Controls.Add(Me.Label17)
        Me.Frame1.Controls.Add(Me.Label18)
        Me.Frame1.Controls.Add(Me.Label19)
        Me.Frame1.Controls.Add(Me.Label20)
        Me.Frame1.Controls.Add(Me.Label21)
        Me.Frame1.Controls.Add(Me.Label22)
        Me.Frame1.Controls.Add(Me.Label23)
        Me.Frame1.Controls.Add(Me.Label24)
        Me.Frame1.Controls.Add(Me.Label25)
        Me.Frame1.Controls.Add(Me.Label26)
        Me.Frame1.Controls.Add(Me.Label27)
        Me.Frame1.Controls.Add(Me.Label28)
        Me.Frame1.Controls.Add(Me.Label29)
        Me.Frame1.Controls.Add(Me.Label30)
        Me.Frame1.Controls.Add(Me.Label7)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(16, 48)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(777, 225)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        '
        'cbStoreNo
        '
        Me.cbStoreNo.BackColor = System.Drawing.SystemColors.Window
        Me.cbStoreNo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbStoreNo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbStoreNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbStoreNo.Location = New System.Drawing.Point(408, 40)
        Me.cbStoreNo.Name = "cbStoreNo"
        Me.cbStoreNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbStoreNo.Size = New System.Drawing.Size(193, 22)
        Me.cbStoreNo.TabIndex = 33
        Me.cbStoreNo.Text = "Combo1"
        '
        'cbCustId
        '
        Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustId.Location = New System.Drawing.Point(96, 16)
        Me.cbCustId.Name = "cbCustId"
        Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustId.Size = New System.Drawing.Size(153, 22)
        Me.cbCustId.TabIndex = 32
        Me.cbCustId.Visible = False
        '
        'cbCustName
        '
        Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustName.Location = New System.Drawing.Point(96, 40)
        Me.cbCustName.Name = "cbCustName"
        Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustName.Size = New System.Drawing.Size(233, 22)
        Me.cbCustName.TabIndex = 31
        '
        'cbState
        '
        Me.cbState.BackColor = System.Drawing.SystemColors.Window
        Me.cbState.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbState.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbState.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbState.Location = New System.Drawing.Point(408, 88)
        Me.cbState.Name = "cbState"
        Me.cbState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbState.Size = New System.Drawing.Size(57, 22)
        Me.cbState.TabIndex = 11
        '
        'txtStoreCoCode
        '
        Me.txtStoreCoCode.AcceptsReturn = True
        Me.txtStoreCoCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreCoCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreCoCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreCoCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreCoCode.Location = New System.Drawing.Point(408, 184)
        Me.txtStoreCoCode.MaxLength = 15
        Me.txtStoreCoCode.Name = "txtStoreCoCode"
        Me.txtStoreCoCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreCoCode.Size = New System.Drawing.Size(97, 20)
        Me.txtStoreCoCode.TabIndex = 10
        '
        'txtStoreFolder
        '
        Me.txtStoreFolder.AcceptsReturn = True
        Me.txtStoreFolder.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreFolder.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreFolder.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreFolder.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreFolder.Location = New System.Drawing.Point(96, 184)
        Me.txtStoreFolder.MaxLength = 20
        Me.txtStoreFolder.Name = "txtStoreFolder"
        Me.txtStoreFolder.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreFolder.Size = New System.Drawing.Size(97, 20)
        Me.txtStoreFolder.TabIndex = 9
        '
        'txtStoreZip
        '
        Me.txtStoreZip.AcceptsReturn = True
        Me.txtStoreZip.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreZip.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreZip.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreZip.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreZip.Location = New System.Drawing.Point(608, 88)
        Me.txtStoreZip.MaxLength = 11
        Me.txtStoreZip.Name = "txtStoreZip"
        Me.txtStoreZip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreZip.Size = New System.Drawing.Size(113, 20)
        Me.txtStoreZip.TabIndex = 8
        '
        'cbStoreStatus
        '
        Me.cbStoreStatus.BackColor = System.Drawing.SystemColors.Window
        Me.cbStoreStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbStoreStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStoreStatus.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbStoreStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbStoreStatus.Location = New System.Drawing.Point(408, 160)
        Me.cbStoreStatus.Name = "cbStoreStatus"
        Me.cbStoreStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbStoreStatus.Size = New System.Drawing.Size(97, 22)
        Me.cbStoreStatus.TabIndex = 7
        '
        'txtStoreContact
        '
        Me.txtStoreContact.AcceptsReturn = True
        Me.txtStoreContact.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreContact.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreContact.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreContact.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreContact.Location = New System.Drawing.Point(96, 160)
        Me.txtStoreContact.MaxLength = 60
        Me.txtStoreContact.Name = "txtStoreContact"
        Me.txtStoreContact.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreContact.Size = New System.Drawing.Size(185, 20)
        Me.txtStoreContact.TabIndex = 6
        '
        'txtStoreCity
        '
        Me.txtStoreCity.AcceptsReturn = True
        Me.txtStoreCity.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreCity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreCity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreCity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreCity.Location = New System.Drawing.Point(96, 88)
        Me.txtStoreCity.MaxLength = 20
        Me.txtStoreCity.Name = "txtStoreCity"
        Me.txtStoreCity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreCity.Size = New System.Drawing.Size(233, 20)
        Me.txtStoreCity.TabIndex = 5
        '
        'txtStoreAddress
        '
        Me.txtStoreAddress.AcceptsReturn = True
        Me.txtStoreAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreAddress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreAddress.Location = New System.Drawing.Point(408, 64)
        Me.txtStoreAddress.MaxLength = 80
        Me.txtStoreAddress.Name = "txtStoreAddress"
        Me.txtStoreAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreAddress.Size = New System.Drawing.Size(313, 20)
        Me.txtStoreAddress.TabIndex = 4
        '
        'txtOccupants
        '
        Me.txtOccupants.AcceptsReturn = True
        Me.txtOccupants.BackColor = System.Drawing.SystemColors.Window
        Me.txtOccupants.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOccupants.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOccupants.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOccupants.Location = New System.Drawing.Point(608, 184)
        Me.txtOccupants.MaxLength = 0
        Me.txtOccupants.Name = "txtOccupants"
        Me.txtOccupants.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOccupants.Size = New System.Drawing.Size(113, 20)
        Me.txtOccupants.TabIndex = 1
        '
        'mtxtStorePhone1
        '
        Me.mtxtStorePhone1.AllowPromptAsInput = False
        Me.mtxtStorePhone1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtStorePhone1.Location = New System.Drawing.Point(96, 112)
        Me.mtxtStorePhone1.Mask = "(###)-###-####"
        Me.mtxtStorePhone1.Name = "mtxtStorePhone1"
        Me.mtxtStorePhone1.Size = New System.Drawing.Size(113, 20)
        Me.mtxtStorePhone1.TabIndex = 2
        '
        'mtxtStorePhone2
        '
        Me.mtxtStorePhone2.AllowPromptAsInput = False
        Me.mtxtStorePhone2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtStorePhone2.Location = New System.Drawing.Point(96, 136)
        Me.mtxtStorePhone2.Mask = "(###)-###-####"
        Me.mtxtStorePhone2.Name = "mtxtStorePhone2"
        Me.mtxtStorePhone2.Size = New System.Drawing.Size(113, 20)
        Me.mtxtStorePhone2.TabIndex = 12
        '
        'mtxtStoreFax1
        '
        Me.mtxtStoreFax1.AllowPromptAsInput = False
        Me.mtxtStoreFax1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtStoreFax1.Location = New System.Drawing.Point(408, 112)
        Me.mtxtStoreFax1.Mask = "(###)-###-####"
        Me.mtxtStoreFax1.Name = "mtxtStoreFax1"
        Me.mtxtStoreFax1.Size = New System.Drawing.Size(113, 20)
        Me.mtxtStoreFax1.TabIndex = 13
        '
        'mtxtStoreFax2
        '
        Me.mtxtStoreFax2.AllowPromptAsInput = False
        Me.mtxtStoreFax2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtStoreFax2.Location = New System.Drawing.Point(408, 136)
        Me.mtxtStoreFax2.Mask = "(###)-###-####"
        Me.mtxtStoreFax2.Name = "mtxtStoreFax2"
        Me.mtxtStoreFax2.Size = New System.Drawing.Size(113, 20)
        Me.mtxtStoreFax2.TabIndex = 14
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(342, 184)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(60, 33)
        Me.Label16.TabIndex = 30
        Me.Label16.Text = "Company Code"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(28, 184)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(49, 17)
        Me.Label17.TabIndex = 29
        Me.Label17.Text = "Folder No"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(352, 160)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(41, 17)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "Status"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(28, 159)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(53, 25)
        Me.Label19.TabIndex = 27
        Me.Label19.Text = "Contact"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.Control
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(552, 88)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(49, 17)
        Me.Label20.TabIndex = 26
        Me.Label20.Text = "Zip Code"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(352, 88)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(41, 17)
        Me.Label21.TabIndex = 25
        Me.Label21.Text = "State"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.Control
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(28, 88)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(33, 17)
        Me.Label22.TabIndex = 24
        Me.Label22.Text = "City"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.Control
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(352, 64)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(49, 17)
        Me.Label23.TabIndex = 23
        Me.Label23.Text = "Address"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(352, 136)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(41, 17)
        Me.Label24.TabIndex = 22
        Me.Label24.Text = "Fax 2"
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.SystemColors.Control
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(352, 112)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(41, 17)
        Me.Label25.TabIndex = 21
        Me.Label25.Text = "Fax 1"
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.SystemColors.Control
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(28, 136)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(49, 17)
        Me.Label26.TabIndex = 20
        Me.Label26.Text = "Phone2"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.Control
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(28, 112)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(49, 17)
        Me.Label27.TabIndex = 19
        Me.Label27.Text = "Phone1"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.SystemColors.Control
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label28.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(28, 64)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(41, 17)
        Me.Label28.TabIndex = 18
        Me.Label28.Text = "Name"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.SystemColors.Control
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(352, 40)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(49, 17)
        Me.Label29.TabIndex = 17
        Me.Label29.Text = "Store No"
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.SystemColors.Control
        Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(28, 40)
        Me.Label30.Name = "Label30"
        Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label30.Size = New System.Drawing.Size(61, 22)
        Me.Label30.TabIndex = 16
        Me.Label30.Text = "Customer"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(531, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(70, 17)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Occupancy"
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.SystemColors.Control
        Me.lblMessage.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Red
        Me.lblMessage.Location = New System.Drawing.Point(16, 32)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMessage.Size = New System.Drawing.Size(489, 17)
        Me.lblMessage.TabIndex = 48
        '
        'frmAlert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(820, 588)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.SSTab1)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.lblMessage)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "frmAlert"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Stores"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.SSTab1.ResumeLayout(False)
        Me._SSTab1_TabPage0.ResumeLayout(False)
        CType(Me.dgEquipment, System.ComponentModel.ISupportInitialize).EndInit()
        Me._SSTab1_TabPage1.ResumeLayout(False)
        Me._SSTab1_TabPage1.PerformLayout()
        CType(Me.dgService, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgVendor, System.ComponentModel.ISupportInitialize).EndInit()
        Me._SSTab1_TabPage2.ResumeLayout(False)
        Me._SSTab1_TabPage2.PerformLayout()
        CType(Me.dgNotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Toolbar2.ResumeLayout(False)
        Me.Toolbar2.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents btClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents btFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents btBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents btForward As System.Windows.Forms.ToolStripButton
    Friend WithEvents btLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgEquipment As System.Windows.Forms.DataGridView
    Friend WithEvents lblVendorAccounts As System.Windows.Forms.Label
    Friend WithEvents dgVendor As System.Windows.Forms.DataGridView
    Friend WithEvents dgService As System.Windows.Forms.DataGridView
    Friend WithEvents lblServiceFreq As System.Windows.Forms.Label
    Friend WithEvents dgNotes As System.Windows.Forms.DataGridView
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btSearch As System.Windows.Forms.ToolStripButton
#End Region 
End Class