<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmVendorEntry
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
	Public WithEvents cbVendPayState As System.Windows.Forms.ComboBox
	Public WithEvents mtxtVendPayPhone1 As System.Windows.Forms.MaskedTextBox
	Public WithEvents txtVendPayZip As System.Windows.Forms.TextBox
	Public WithEvents txtVendPayCity As System.Windows.Forms.TextBox
	Public WithEvents txtVendPayAddress As System.Windows.Forms.TextBox
	Public WithEvents Label18 As System.Windows.Forms.Label
	Public WithEvents Label17 As System.Windows.Forms.Label
	Public WithEvents Label16 As System.Windows.Forms.Label
	Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents mtxtVendPhone1 As System.Windows.Forms.MaskedTextBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents cbState As System.Windows.Forms.ComboBox
	Public WithEvents cmdSearch As System.Windows.Forms.Button
	Public WithEvents txtQBName As System.Windows.Forms.TextBox
	Public WithEvents cbQBGroupId As System.Windows.Forms.ComboBox
	Public WithEvents cbQBGroupDesc As System.Windows.Forms.ComboBox
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents frQuickBooks As System.Windows.Forms.GroupBox
	Public WithEvents txtVendFax2 As System.Windows.Forms.TextBox
	Public WithEvents txtVendFax1 As System.Windows.Forms.TextBox
	Public WithEvents txtVendPhone2 As System.Windows.Forms.TextBox
	Public WithEvents txtVendPhone1 As System.Windows.Forms.TextBox
	Public WithEvents txtVendZip As System.Windows.Forms.TextBox
	Public WithEvents txtVendCity As System.Windows.Forms.TextBox
	Public WithEvents txtVendAddress As System.Windows.Forms.TextBox
	Public WithEvents txtVendRepre As System.Windows.Forms.TextBox
	Public WithEvents txtVendArea As System.Windows.Forms.TextBox
	Public WithEvents txtVendName As System.Windows.Forms.TextBox
	Public WithEvents mtxtVendFax1 As System.Windows.Forms.MaskedTextBox
	Public WithEvents mtxtVendPhone2 As System.Windows.Forms.MaskedTextBox
	Public WithEvents mtxtVendFax2 As System.Windows.Forms.MaskedTextBox
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVendorEntry))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.cbVendPayState = New System.Windows.Forms.ComboBox
        Me.mtxtVendPayPhone1 = New System.Windows.Forms.MaskedTextBox
        Me.txtVendPayZip = New System.Windows.Forms.TextBox
        Me.txtVendPayCity = New System.Windows.Forms.TextBox
        Me.txtVendPayAddress = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.mtxtVendPhone1 = New System.Windows.Forms.MaskedTextBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cbState = New System.Windows.Forms.ComboBox
        Me.frQuickBooks = New System.Windows.Forms.GroupBox
        Me.txtQBName = New System.Windows.Forms.TextBox
        Me.cbQBGroupId = New System.Windows.Forms.ComboBox
        Me.cbQBGroupDesc = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtVendFax2 = New System.Windows.Forms.TextBox
        Me.txtVendFax1 = New System.Windows.Forms.TextBox
        Me.txtVendPhone2 = New System.Windows.Forms.TextBox
        Me.txtVendPhone1 = New System.Windows.Forms.TextBox
        Me.txtVendZip = New System.Windows.Forms.TextBox
        Me.txtVendCity = New System.Windows.Forms.TextBox
        Me.txtVendAddress = New System.Windows.Forms.TextBox
        Me.txtVendRepre = New System.Windows.Forms.TextBox
        Me.txtVendArea = New System.Windows.Forms.TextBox
        Me.txtVendName = New System.Windows.Forms.TextBox
        Me.mtxtVendFax1 = New System.Windows.Forms.MaskedTextBox
        Me.mtxtVendPhone2 = New System.Windows.Forms.MaskedTextBox
        Me.mtxtVendFax2 = New System.Windows.Forms.MaskedTextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.Frame2.SuspendLayout()
        Me.frQuickBooks.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSearch
        '
        Me.cmdSearch.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSearch.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSearch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSearch.Image = CType(resources.GetObject("cmdSearch.Image"), System.Drawing.Image)
        Me.cmdSearch.Location = New System.Drawing.Point(360, 56)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSearch.Size = New System.Drawing.Size(41, 25)
        Me.cmdSearch.TabIndex = 20
        Me.cmdSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdSearch, "Search")
        Me.cmdSearch.UseVisualStyleBackColor = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.cbVendPayState)
        Me.Frame2.Controls.Add(Me.mtxtVendPayPhone1)
        Me.Frame2.Controls.Add(Me.txtVendPayZip)
        Me.Frame2.Controls.Add(Me.txtVendPayCity)
        Me.Frame2.Controls.Add(Me.txtVendPayAddress)
        Me.Frame2.Controls.Add(Me.Label18)
        Me.Frame2.Controls.Add(Me.Label17)
        Me.Frame2.Controls.Add(Me.Label16)
        Me.Frame2.Controls.Add(Me.Label15)
        Me.Frame2.Controls.Add(Me.Label14)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(16, 256)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(433, 137)
        Me.Frame2.TabIndex = 40
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Payment Info"
        '
        'cbVendPayState
        '
        Me.cbVendPayState.BackColor = System.Drawing.SystemColors.Window
        Me.cbVendPayState.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbVendPayState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVendPayState.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVendPayState.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbVendPayState.Location = New System.Drawing.Point(288, 64)
        Me.cbVendPayState.Name = "cbVendPayState"
        Me.cbVendPayState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbVendPayState.Size = New System.Drawing.Size(73, 22)
        Me.cbVendPayState.TabIndex = 14
        '
        'mtxtVendPayPhone1
        '
        Me.mtxtVendPayPhone1.AllowPromptAsInput = False
        Me.mtxtVendPayPhone1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtVendPayPhone1.Location = New System.Drawing.Point(88, 96)
        Me.mtxtVendPayPhone1.Mask = "(###)-###-####"
        Me.mtxtVendPayPhone1.Name = "mtxtVendPayPhone1"
        Me.mtxtVendPayPhone1.Size = New System.Drawing.Size(137, 20)
        Me.mtxtVendPayPhone1.TabIndex = 15
        '
        'txtVendPayZip
        '
        Me.txtVendPayZip.AcceptsReturn = True
        Me.txtVendPayZip.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendPayZip.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendPayZip.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendPayZip.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendPayZip.Location = New System.Drawing.Point(288, 96)
        Me.txtVendPayZip.MaxLength = 11
        Me.txtVendPayZip.Name = "txtVendPayZip"
        Me.txtVendPayZip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendPayZip.Size = New System.Drawing.Size(89, 20)
        Me.txtVendPayZip.TabIndex = 16
        '
        'txtVendPayCity
        '
        Me.txtVendPayCity.AcceptsReturn = True
        Me.txtVendPayCity.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendPayCity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendPayCity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendPayCity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendPayCity.Location = New System.Drawing.Point(88, 64)
        Me.txtVendPayCity.MaxLength = 0
        Me.txtVendPayCity.Name = "txtVendPayCity"
        Me.txtVendPayCity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendPayCity.Size = New System.Drawing.Size(137, 20)
        Me.txtVendPayCity.TabIndex = 13
        '
        'txtVendPayAddress
        '
        Me.txtVendPayAddress.AcceptsReturn = True
        Me.txtVendPayAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendPayAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendPayAddress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendPayAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendPayAddress.Location = New System.Drawing.Point(88, 32)
        Me.txtVendPayAddress.MaxLength = 0
        Me.txtVendPayAddress.Name = "txtVendPayAddress"
        Me.txtVendPayAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendPayAddress.Size = New System.Drawing.Size(297, 20)
        Me.txtVendPayAddress.TabIndex = 12
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(248, 64)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(33, 17)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "State"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(16, 96)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(41, 21)
        Me.Label17.TabIndex = 44
        Me.Label17.Text = "Phone"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(248, 98)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(25, 17)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = "Zip"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(16, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(41, 17)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "City"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(16, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(49, 25)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "Payment Address"
        '
        'mtxtVendPhone1
        '
        Me.mtxtVendPhone1.AllowPromptAsInput = False
        Me.mtxtVendPhone1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtVendPhone1.Location = New System.Drawing.Point(104, 184)
        Me.mtxtVendPhone1.Mask = "(###)-###-####"
        Me.mtxtVendPhone1.Name = "mtxtVendPhone1"
        Me.mtxtVendPhone1.Size = New System.Drawing.Size(145, 20)
        Me.mtxtVendPhone1.TabIndex = 8
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(232, 536)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 33)
        Me.cmdCancel.TabIndex = 23
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(160, 536)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(57, 33)
        Me.cmdOk.TabIndex = 22
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'cbState
        '
        Me.cbState.BackColor = System.Drawing.SystemColors.Window
        Me.cbState.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbState.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbState.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbState.Location = New System.Drawing.Point(376, 56)
        Me.cbState.Name = "cbState"
        Me.cbState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbState.Size = New System.Drawing.Size(73, 22)
        Me.cbState.TabIndex = 3
        '
        'frQuickBooks
        '
        Me.frQuickBooks.BackColor = System.Drawing.SystemColors.Control
        Me.frQuickBooks.Controls.Add(Me.cmdSearch)
        Me.frQuickBooks.Controls.Add(Me.txtQBName)
        Me.frQuickBooks.Controls.Add(Me.cbQBGroupId)
        Me.frQuickBooks.Controls.Add(Me.cbQBGroupDesc)
        Me.frQuickBooks.Controls.Add(Me.Label13)
        Me.frQuickBooks.Controls.Add(Me.Label12)
        Me.frQuickBooks.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frQuickBooks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frQuickBooks.Location = New System.Drawing.Point(16, 408)
        Me.frQuickBooks.Name = "frQuickBooks"
        Me.frQuickBooks.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frQuickBooks.Size = New System.Drawing.Size(433, 113)
        Me.frQuickBooks.TabIndex = 37
        Me.frQuickBooks.TabStop = False
        Me.frQuickBooks.Text = "Quick Books  Info"
        '
        'txtQBName
        '
        Me.txtQBName.AcceptsReturn = True
        Me.txtQBName.BackColor = System.Drawing.SystemColors.Window
        Me.txtQBName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQBName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQBName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQBName.Location = New System.Drawing.Point(112, 56)
        Me.txtQBName.MaxLength = 255
        Me.txtQBName.Name = "txtQBName"
        Me.txtQBName.ReadOnly = True
        Me.txtQBName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtQBName.Size = New System.Drawing.Size(241, 20)
        Me.txtQBName.TabIndex = 19
        '
        'cbQBGroupId
        '
        Me.cbQBGroupId.BackColor = System.Drawing.SystemColors.Window
        Me.cbQBGroupId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbQBGroupId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbQBGroupId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbQBGroupId.Location = New System.Drawing.Point(296, 24)
        Me.cbQBGroupId.Name = "cbQBGroupId"
        Me.cbQBGroupId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbQBGroupId.Size = New System.Drawing.Size(41, 22)
        Me.cbQBGroupId.TabIndex = 18
        Me.cbQBGroupId.Text = "Combo1"
        Me.cbQBGroupId.Visible = False
        '
        'cbQBGroupDesc
        '
        Me.cbQBGroupDesc.BackColor = System.Drawing.SystemColors.Window
        Me.cbQBGroupDesc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbQBGroupDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbQBGroupDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbQBGroupDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbQBGroupDesc.Location = New System.Drawing.Point(112, 24)
        Me.cbQBGroupDesc.Name = "cbQBGroupDesc"
        Me.cbQBGroupDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbQBGroupDesc.Size = New System.Drawing.Size(169, 22)
        Me.cbQBGroupDesc.TabIndex = 17
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(6, 51)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(94, 35)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Quick Books Vendor Name"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(6, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(97, 22)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "Company Group"
        '
        'txtVendFax2
        '
        Me.txtVendFax2.AcceptsReturn = True
        Me.txtVendFax2.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendFax2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendFax2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendFax2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendFax2.Location = New System.Drawing.Point(360, 544)
        Me.txtVendFax2.MaxLength = 15
        Me.txtVendFax2.Name = "txtVendFax2"
        Me.txtVendFax2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendFax2.Size = New System.Drawing.Size(121, 20)
        Me.txtVendFax2.TabIndex = 26
        Me.txtVendFax2.Visible = False
        '
        'txtVendFax1
        '
        Me.txtVendFax1.AcceptsReturn = True
        Me.txtVendFax1.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendFax1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendFax1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendFax1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendFax1.Location = New System.Drawing.Point(360, 512)
        Me.txtVendFax1.MaxLength = 15
        Me.txtVendFax1.Name = "txtVendFax1"
        Me.txtVendFax1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendFax1.Size = New System.Drawing.Size(121, 20)
        Me.txtVendFax1.TabIndex = 24
        Me.txtVendFax1.Visible = False
        '
        'txtVendPhone2
        '
        Me.txtVendPhone2.AcceptsReturn = True
        Me.txtVendPhone2.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendPhone2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendPhone2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendPhone2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendPhone2.Location = New System.Drawing.Point(360, 488)
        Me.txtVendPhone2.MaxLength = 15
        Me.txtVendPhone2.Name = "txtVendPhone2"
        Me.txtVendPhone2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendPhone2.Size = New System.Drawing.Size(121, 20)
        Me.txtVendPhone2.TabIndex = 25
        Me.txtVendPhone2.Visible = False
        '
        'txtVendPhone1
        '
        Me.txtVendPhone1.AcceptsReturn = True
        Me.txtVendPhone1.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendPhone1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendPhone1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendPhone1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendPhone1.Location = New System.Drawing.Point(360, 456)
        Me.txtVendPhone1.MaxLength = 15
        Me.txtVendPhone1.Name = "txtVendPhone1"
        Me.txtVendPhone1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendPhone1.Size = New System.Drawing.Size(121, 20)
        Me.txtVendPhone1.TabIndex = 21
        Me.txtVendPhone1.Visible = False
        '
        'txtVendZip
        '
        Me.txtVendZip.AcceptsReturn = True
        Me.txtVendZip.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendZip.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendZip.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendZip.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendZip.Location = New System.Drawing.Point(304, 152)
        Me.txtVendZip.MaxLength = 11
        Me.txtVendZip.Name = "txtVendZip"
        Me.txtVendZip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendZip.Size = New System.Drawing.Size(89, 20)
        Me.txtVendZip.TabIndex = 7
        '
        'txtVendCity
        '
        Me.txtVendCity.AcceptsReturn = True
        Me.txtVendCity.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendCity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendCity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendCity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendCity.Location = New System.Drawing.Point(104, 152)
        Me.txtVendCity.MaxLength = 30
        Me.txtVendCity.Name = "txtVendCity"
        Me.txtVendCity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendCity.Size = New System.Drawing.Size(145, 20)
        Me.txtVendCity.TabIndex = 6
        '
        'txtVendAddress
        '
        Me.txtVendAddress.AcceptsReturn = True
        Me.txtVendAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendAddress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendAddress.Location = New System.Drawing.Point(104, 120)
        Me.txtVendAddress.MaxLength = 80
        Me.txtVendAddress.Name = "txtVendAddress"
        Me.txtVendAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendAddress.Size = New System.Drawing.Size(289, 20)
        Me.txtVendAddress.TabIndex = 5
        '
        'txtVendRepre
        '
        Me.txtVendRepre.AcceptsReturn = True
        Me.txtVendRepre.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendRepre.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendRepre.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendRepre.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendRepre.Location = New System.Drawing.Point(104, 88)
        Me.txtVendRepre.MaxLength = 20
        Me.txtVendRepre.Name = "txtVendRepre"
        Me.txtVendRepre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendRepre.Size = New System.Drawing.Size(193, 20)
        Me.txtVendRepre.TabIndex = 4
        '
        'txtVendArea
        '
        Me.txtVendArea.AcceptsReturn = True
        Me.txtVendArea.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendArea.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendArea.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendArea.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendArea.Location = New System.Drawing.Point(104, 56)
        Me.txtVendArea.MaxLength = 40
        Me.txtVendArea.Name = "txtVendArea"
        Me.txtVendArea.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendArea.Size = New System.Drawing.Size(193, 20)
        Me.txtVendArea.TabIndex = 2
        '
        'txtVendName
        '
        Me.txtVendName.AcceptsReturn = True
        Me.txtVendName.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendName.Enabled = False
        Me.txtVendName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendName.Location = New System.Drawing.Point(104, 24)
        Me.txtVendName.MaxLength = 0
        Me.txtVendName.Name = "txtVendName"
        Me.txtVendName.ReadOnly = True
        Me.txtVendName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendName.Size = New System.Drawing.Size(193, 20)
        Me.txtVendName.TabIndex = 1
        '
        'mtxtVendFax1
        '
        Me.mtxtVendFax1.AllowPromptAsInput = False
        Me.mtxtVendFax1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtVendFax1.Location = New System.Drawing.Point(304, 184)
        Me.mtxtVendFax1.Mask = "(###)-###-####"
        Me.mtxtVendFax1.Name = "mtxtVendFax1"
        Me.mtxtVendFax1.Size = New System.Drawing.Size(145, 20)
        Me.mtxtVendFax1.TabIndex = 9
        '
        'mtxtVendPhone2
        '
        Me.mtxtVendPhone2.AllowPromptAsInput = False
        Me.mtxtVendPhone2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtVendPhone2.Location = New System.Drawing.Point(104, 216)
        Me.mtxtVendPhone2.Mask = "(###)-###-####"
        Me.mtxtVendPhone2.Name = "mtxtVendPhone2"
        Me.mtxtVendPhone2.Size = New System.Drawing.Size(145, 20)
        Me.mtxtVendPhone2.TabIndex = 10
        '
        'mtxtVendFax2
        '
        Me.mtxtVendFax2.AllowPromptAsInput = False
        Me.mtxtVendFax2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtVendFax2.Location = New System.Drawing.Point(304, 208)
        Me.mtxtVendFax2.Mask = "(###)-###-####"
        Me.mtxtVendFax2.Name = "mtxtVendFax2"
        Me.mtxtVendFax2.Size = New System.Drawing.Size(145, 20)
        Me.mtxtVendFax2.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(264, 216)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(33, 17)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Fax 2"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(264, 184)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(33, 17)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Fax 1"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(16, 216)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(49, 17)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Phone 2"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 184)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(49, 17)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Phone 1"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(264, 152)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(25, 17)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Zip"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(33, 17)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "City"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(49, 17)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Address"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(89, 17)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Representative"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(336, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(33, 17)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "State"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(41, 17)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Area"
        '
        'label1
        '
        Me.label1.BackColor = System.Drawing.SystemColors.Control
        Me.label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label1.Location = New System.Drawing.Point(16, 24)
        Me.label1.Name = "label1"
        Me.label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label1.Size = New System.Drawing.Size(57, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Vendor"
        '
        'frmVendorEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(481, 575)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.mtxtVendPhone1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cbState)
        Me.Controls.Add(Me.frQuickBooks)
        Me.Controls.Add(Me.txtVendFax2)
        Me.Controls.Add(Me.txtVendFax1)
        Me.Controls.Add(Me.txtVendPhone2)
        Me.Controls.Add(Me.txtVendPhone1)
        Me.Controls.Add(Me.txtVendZip)
        Me.Controls.Add(Me.txtVendCity)
        Me.Controls.Add(Me.txtVendAddress)
        Me.Controls.Add(Me.txtVendRepre)
        Me.Controls.Add(Me.txtVendArea)
        Me.Controls.Add(Me.txtVendName)
        Me.Controls.Add(Me.mtxtVendFax1)
        Me.Controls.Add(Me.mtxtVendPhone2)
        Me.Controls.Add(Me.mtxtVendFax2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmVendorEntry"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Vendor Data"
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.frQuickBooks.ResumeLayout(False)
        Me.frQuickBooks.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class