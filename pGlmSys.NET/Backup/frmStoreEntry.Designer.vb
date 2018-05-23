<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStoreEntry
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
    Public WithEvents txtStoreSold As System.Windows.Forms.TextBox
	Public WithEvents txtStoreMarket As System.Windows.Forms.TextBox
	Public WithEvents txtLfGroup As System.Windows.Forms.TextBox
	Public WithEvents txtStoreZip As System.Windows.Forms.TextBox
	Public WithEvents cbState As System.Windows.Forms.ComboBox
	Public WithEvents txtStoreCity As System.Windows.Forms.TextBox
	Public WithEvents txtStoreAddress As System.Windows.Forms.TextBox
	Public WithEvents mtxtStorePhone1 As System.Windows.Forms.MaskedTextBox
	Public WithEvents mtxtStoreFax1 As System.Windows.Forms.MaskedTextBox
	Public WithEvents mtxtStorePhone2 As System.Windows.Forms.MaskedTextBox
	Public WithEvents mtxtStoreFax2 As System.Windows.Forms.MaskedTextBox
	Public WithEvents Label24 As System.Windows.Forms.Label
	Public WithEvents Label26 As System.Windows.Forms.Label
	Public WithEvents Label25 As System.Windows.Forms.Label
	Public WithEvents Label27 As System.Windows.Forms.Label
	Public WithEvents Label20 As System.Windows.Forms.Label
	Public WithEvents Label21 As System.Windows.Forms.Label
	Public WithEvents Label22 As System.Windows.Forms.Label
	Public WithEvents Label23 As System.Windows.Forms.Label
	Public WithEvents Frame3 As System.Windows.Forms.GroupBox
	Public WithEvents txtBillingAccount As System.Windows.Forms.TextBox
	Public WithEvents ckSame As System.Windows.Forms.CheckBox
	Public WithEvents txtBillingContact As System.Windows.Forms.TextBox
	Public WithEvents cmdAddress As System.Windows.Forms.Button
	Public WithEvents txtStoreBillState As System.Windows.Forms.TextBox
	Public WithEvents txtStoreBillZip As System.Windows.Forms.TextBox
	Public WithEvents txtStoreBillCity As System.Windows.Forms.TextBox
	Public WithEvents txtStoreBillAddress As System.Windows.Forms.TextBox
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents txtOccupants As System.Windows.Forms.TextBox
	Public WithEvents txtCustId As System.Windows.Forms.TextBox
	Public WithEvents txtCustName As System.Windows.Forms.TextBox
	Public WithEvents txtStoreNumber As System.Windows.Forms.TextBox
	Public WithEvents txtStoreName As System.Windows.Forms.TextBox
	Public WithEvents txtStorePhone1 As System.Windows.Forms.TextBox
	Public WithEvents txtStorePhone2 As System.Windows.Forms.TextBox
	Public WithEvents txtStoreContact As System.Windows.Forms.TextBox
	Public WithEvents cbStoreStatus As System.Windows.Forms.ComboBox
	Public WithEvents txtStoreFax1 As System.Windows.Forms.TextBox
	Public WithEvents txtStoreFax2 As System.Windows.Forms.TextBox
	Public WithEvents txtStoreFolder As System.Windows.Forms.TextBox
	Public WithEvents txtStoreCoCode As System.Windows.Forms.TextBox
	Public WithEvents mtxtStoreZip As System.Windows.Forms.MaskedTextBox
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label30 As System.Windows.Forms.Label
	Public WithEvents Label29 As System.Windows.Forms.Label
	Public WithEvents Label28 As System.Windows.Forms.Label
	Public WithEvents Label19 As System.Windows.Forms.Label
	Public WithEvents Label18 As System.Windows.Forms.Label
	Public WithEvents Label17 As System.Windows.Forms.Label
	Public WithEvents Label16 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStoreEntry))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtStoreName = New System.Windows.Forms.TextBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.dtStoreSoldDate = New System.Windows.Forms.DateTimePicker
        Me.txtStoreSold = New System.Windows.Forms.TextBox
        Me.txtStoreMarket = New System.Windows.Forms.TextBox
        Me.txtLfGroup = New System.Windows.Forms.TextBox
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me.txtStoreZip = New System.Windows.Forms.TextBox
        Me.cbState = New System.Windows.Forms.ComboBox
        Me.txtStoreCity = New System.Windows.Forms.TextBox
        Me.txtStoreAddress = New System.Windows.Forms.TextBox
        Me.mtxtStorePhone1 = New System.Windows.Forms.MaskedTextBox
        Me.mtxtStoreFax1 = New System.Windows.Forms.MaskedTextBox
        Me.mtxtStorePhone2 = New System.Windows.Forms.MaskedTextBox
        Me.mtxtStoreFax2 = New System.Windows.Forms.MaskedTextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.txtBillingAccount = New System.Windows.Forms.TextBox
        Me.ckSame = New System.Windows.Forms.CheckBox
        Me.txtBillingContact = New System.Windows.Forms.TextBox
        Me.cmdAddress = New System.Windows.Forms.Button
        Me.txtStoreBillState = New System.Windows.Forms.TextBox
        Me.txtStoreBillZip = New System.Windows.Forms.TextBox
        Me.txtStoreBillCity = New System.Windows.Forms.TextBox
        Me.txtStoreBillAddress = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtOccupants = New System.Windows.Forms.TextBox
        Me.txtCustId = New System.Windows.Forms.TextBox
        Me.txtCustName = New System.Windows.Forms.TextBox
        Me.txtStoreNumber = New System.Windows.Forms.TextBox
        Me.txtStorePhone1 = New System.Windows.Forms.TextBox
        Me.txtStorePhone2 = New System.Windows.Forms.TextBox
        Me.txtStoreContact = New System.Windows.Forms.TextBox
        Me.cbStoreStatus = New System.Windows.Forms.ComboBox
        Me.txtStoreFax1 = New System.Windows.Forms.TextBox
        Me.txtStoreFax2 = New System.Windows.Forms.TextBox
        Me.txtStoreFolder = New System.Windows.Forms.TextBox
        Me.txtStoreCoCode = New System.Windows.Forms.TextBox
        Me.mtxtStoreZip = New System.Windows.Forms.MaskedTextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.Frame1.SuspendLayout()
        Me.Frame3.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtStoreName
        '
        Me.txtStoreName.AcceptsReturn = True
        Me.txtStoreName.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreName.Location = New System.Drawing.Point(64, 104)
        Me.txtStoreName.MaxLength = 0
        Me.txtStoreName.Name = "txtStoreName"
        Me.txtStoreName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreName.Size = New System.Drawing.Size(129, 20)
        Me.txtStoreName.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtStoreName, "Store Name")
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.dtStoreSoldDate)
        Me.Frame1.Controls.Add(Me.txtStoreSold)
        Me.Frame1.Controls.Add(Me.txtStoreMarket)
        Me.Frame1.Controls.Add(Me.txtLfGroup)
        Me.Frame1.Controls.Add(Me.Frame3)
        Me.Frame1.Controls.Add(Me.Frame2)
        Me.Frame1.Controls.Add(Me.txtOccupants)
        Me.Frame1.Controls.Add(Me.txtCustId)
        Me.Frame1.Controls.Add(Me.txtCustName)
        Me.Frame1.Controls.Add(Me.txtStoreNumber)
        Me.Frame1.Controls.Add(Me.txtStoreName)
        Me.Frame1.Controls.Add(Me.txtStorePhone1)
        Me.Frame1.Controls.Add(Me.txtStorePhone2)
        Me.Frame1.Controls.Add(Me.txtStoreContact)
        Me.Frame1.Controls.Add(Me.cbStoreStatus)
        Me.Frame1.Controls.Add(Me.txtStoreFax1)
        Me.Frame1.Controls.Add(Me.txtStoreFax2)
        Me.Frame1.Controls.Add(Me.txtStoreFolder)
        Me.Frame1.Controls.Add(Me.txtStoreCoCode)
        Me.Frame1.Controls.Add(Me.mtxtStoreZip)
        Me.Frame1.Controls.Add(Me.Label11)
        Me.Frame1.Controls.Add(Me.Label10)
        Me.Frame1.Controls.Add(Me.Label9)
        Me.Frame1.Controls.Add(Me.Label8)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Controls.Add(Me.Label30)
        Me.Frame1.Controls.Add(Me.Label29)
        Me.Frame1.Controls.Add(Me.Label28)
        Me.Frame1.Controls.Add(Me.Label19)
        Me.Frame1.Controls.Add(Me.Label18)
        Me.Frame1.Controls.Add(Me.Label17)
        Me.Frame1.Controls.Add(Me.Label16)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(16, 32)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(785, 473)
        Me.Frame1.TabIndex = 13
        Me.Frame1.TabStop = False
        '
        'dtStoreSoldDate
        '
        Me.dtStoreSoldDate.Location = New System.Drawing.Point(64, 416)
        Me.dtStoreSoldDate.Name = "dtStoreSoldDate"
        Me.dtStoreSoldDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtStoreSoldDate.Size = New System.Drawing.Size(200, 20)
        Me.dtStoreSoldDate.TabIndex = 65
        '
        'txtStoreSold
        '
        Me.txtStoreSold.AcceptsReturn = True
        Me.txtStoreSold.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreSold.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreSold.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreSold.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreSold.Location = New System.Drawing.Point(64, 384)
        Me.txtStoreSold.MaxLength = 0
        Me.txtStoreSold.Name = "txtStoreSold"
        Me.txtStoreSold.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreSold.Size = New System.Drawing.Size(249, 20)
        Me.txtStoreSold.TabIndex = 62
        '
        'txtStoreMarket
        '
        Me.txtStoreMarket.AcceptsReturn = True
        Me.txtStoreMarket.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreMarket.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreMarket.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreMarket.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreMarket.Location = New System.Drawing.Point(64, 352)
        Me.txtStoreMarket.MaxLength = 0
        Me.txtStoreMarket.Name = "txtStoreMarket"
        Me.txtStoreMarket.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreMarket.Size = New System.Drawing.Size(249, 20)
        Me.txtStoreMarket.TabIndex = 60
        '
        'txtLfGroup
        '
        Me.txtLfGroup.AcceptsReturn = True
        Me.txtLfGroup.BackColor = System.Drawing.SystemColors.Window
        Me.txtLfGroup.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLfGroup.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLfGroup.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLfGroup.Location = New System.Drawing.Point(64, 320)
        Me.txtLfGroup.MaxLength = 0
        Me.txtLfGroup.Name = "txtLfGroup"
        Me.txtLfGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLfGroup.Size = New System.Drawing.Size(249, 20)
        Me.txtLfGroup.TabIndex = 58
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.txtStoreZip)
        Me.Frame3.Controls.Add(Me.cbState)
        Me.Frame3.Controls.Add(Me.txtStoreCity)
        Me.Frame3.Controls.Add(Me.txtStoreAddress)
        Me.Frame3.Controls.Add(Me.mtxtStorePhone1)
        Me.Frame3.Controls.Add(Me.mtxtStoreFax1)
        Me.Frame3.Controls.Add(Me.mtxtStorePhone2)
        Me.Frame3.Controls.Add(Me.mtxtStoreFax2)
        Me.Frame3.Controls.Add(Me.Label24)
        Me.Frame3.Controls.Add(Me.Label26)
        Me.Frame3.Controls.Add(Me.Label25)
        Me.Frame3.Controls.Add(Me.Label27)
        Me.Frame3.Controls.Add(Me.Label20)
        Me.Frame3.Controls.Add(Me.Label21)
        Me.Frame3.Controls.Add(Me.Label22)
        Me.Frame3.Controls.Add(Me.Label23)
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(416, 16)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(353, 201)
        Me.Frame3.TabIndex = 27
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Physical Address"
        '
        'txtStoreZip
        '
        Me.txtStoreZip.AcceptsReturn = True
        Me.txtStoreZip.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreZip.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreZip.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreZip.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreZip.Location = New System.Drawing.Point(224, 104)
        Me.txtStoreZip.MaxLength = 11
        Me.txtStoreZip.Name = "txtStoreZip"
        Me.txtStoreZip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreZip.Size = New System.Drawing.Size(113, 20)
        Me.txtStoreZip.TabIndex = 35
        '
        'cbState
        '
        Me.cbState.BackColor = System.Drawing.SystemColors.Window
        Me.cbState.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbState.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbState.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbState.Location = New System.Drawing.Point(40, 104)
        Me.cbState.Name = "cbState"
        Me.cbState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbState.Size = New System.Drawing.Size(57, 22)
        Me.cbState.TabIndex = 33
        '
        'txtStoreCity
        '
        Me.txtStoreCity.AcceptsReturn = True
        Me.txtStoreCity.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreCity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreCity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreCity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreCity.Location = New System.Drawing.Point(8, 72)
        Me.txtStoreCity.MaxLength = 20
        Me.txtStoreCity.Name = "txtStoreCity"
        Me.txtStoreCity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreCity.Size = New System.Drawing.Size(273, 20)
        Me.txtStoreCity.TabIndex = 31
        '
        'txtStoreAddress
        '
        Me.txtStoreAddress.AcceptsReturn = True
        Me.txtStoreAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreAddress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreAddress.Location = New System.Drawing.Point(8, 32)
        Me.txtStoreAddress.MaxLength = 80
        Me.txtStoreAddress.Name = "txtStoreAddress"
        Me.txtStoreAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreAddress.Size = New System.Drawing.Size(313, 20)
        Me.txtStoreAddress.TabIndex = 29
        '
        'mtxtStorePhone1
        '
        Me.mtxtStorePhone1.AllowPromptAsInput = False
        Me.mtxtStorePhone1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtStorePhone1.Location = New System.Drawing.Point(56, 136)
        Me.mtxtStorePhone1.Mask = "(###)-###-####"
        Me.mtxtStorePhone1.Name = "mtxtStorePhone1"
        Me.mtxtStorePhone1.Size = New System.Drawing.Size(113, 20)
        Me.mtxtStorePhone1.TabIndex = 37
        '
        'mtxtStoreFax1
        '
        Me.mtxtStoreFax1.AllowPromptAsInput = False
        Me.mtxtStoreFax1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtStoreFax1.Location = New System.Drawing.Point(224, 136)
        Me.mtxtStoreFax1.Mask = "(###)-###-####"
        Me.mtxtStoreFax1.Name = "mtxtStoreFax1"
        Me.mtxtStoreFax1.Size = New System.Drawing.Size(113, 20)
        Me.mtxtStoreFax1.TabIndex = 39
        '
        'mtxtStorePhone2
        '
        Me.mtxtStorePhone2.AllowPromptAsInput = False
        Me.mtxtStorePhone2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtStorePhone2.Location = New System.Drawing.Point(56, 168)
        Me.mtxtStorePhone2.Mask = "(###)-###-####"
        Me.mtxtStorePhone2.Name = "mtxtStorePhone2"
        Me.mtxtStorePhone2.Size = New System.Drawing.Size(113, 20)
        Me.mtxtStorePhone2.TabIndex = 41
        '
        'mtxtStoreFax2
        '
        Me.mtxtStoreFax2.AllowPromptAsInput = False
        Me.mtxtStoreFax2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtStoreFax2.Location = New System.Drawing.Point(224, 168)
        Me.mtxtStoreFax2.Mask = "(###)-###-####"
        Me.mtxtStoreFax2.Name = "mtxtStoreFax2"
        Me.mtxtStoreFax2.Size = New System.Drawing.Size(113, 20)
        Me.mtxtStoreFax2.TabIndex = 43
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(176, 168)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(41, 17)
        Me.Label24.TabIndex = 42
        Me.Label24.Text = "Fax 2"
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.SystemColors.Control
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(8, 168)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(49, 17)
        Me.Label26.TabIndex = 40
        Me.Label26.Text = "Phone2"
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.SystemColors.Control
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(176, 136)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(41, 17)
        Me.Label25.TabIndex = 38
        Me.Label25.Text = "Fax 1"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.Control
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(8, 136)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(49, 17)
        Me.Label27.TabIndex = 36
        Me.Label27.Text = "Phone1"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.Control
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(176, 104)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(49, 17)
        Me.Label20.TabIndex = 34
        Me.Label20.Text = "Zip Code"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(8, 104)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(41, 17)
        Me.Label21.TabIndex = 32
        Me.Label21.Text = "State"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.Control
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(8, 56)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(33, 17)
        Me.Label22.TabIndex = 30
        Me.Label22.Text = "City"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.Control
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(8, 16)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(49, 17)
        Me.Label23.TabIndex = 28
        Me.Label23.Text = "Address"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.txtBillingAccount)
        Me.Frame2.Controls.Add(Me.ckSame)
        Me.Frame2.Controls.Add(Me.txtBillingContact)
        Me.Frame2.Controls.Add(Me.cmdAddress)
        Me.Frame2.Controls.Add(Me.txtStoreBillState)
        Me.Frame2.Controls.Add(Me.txtStoreBillZip)
        Me.Frame2.Controls.Add(Me.txtStoreBillCity)
        Me.Frame2.Controls.Add(Me.txtStoreBillAddress)
        Me.Frame2.Controls.Add(Me.Label7)
        Me.Frame2.Controls.Add(Me.Label6)
        Me.Frame2.Controls.Add(Me.Label5)
        Me.Frame2.Controls.Add(Me.Label4)
        Me.Frame2.Controls.Add(Me.Label3)
        Me.Frame2.Controls.Add(Me.Label2)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(416, 224)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(353, 241)
        Me.Frame2.TabIndex = 25
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Billing Address"
        '
        'txtBillingAccount
        '
        Me.txtBillingAccount.AcceptsReturn = True
        Me.txtBillingAccount.BackColor = System.Drawing.SystemColors.Window
        Me.txtBillingAccount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBillingAccount.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillingAccount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBillingAccount.Location = New System.Drawing.Point(96, 48)
        Me.txtBillingAccount.MaxLength = 0
        Me.txtBillingAccount.Name = "txtBillingAccount"
        Me.txtBillingAccount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBillingAccount.Size = New System.Drawing.Size(241, 20)
        Me.txtBillingAccount.TabIndex = 56
        '
        'ckSame
        '
        Me.ckSame.BackColor = System.Drawing.SystemColors.Control
        Me.ckSame.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckSame.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckSame.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckSame.Location = New System.Drawing.Point(16, 80)
        Me.ckSame.Name = "ckSame"
        Me.ckSame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckSame.Size = New System.Drawing.Size(153, 35)
        Me.ckSame.TabIndex = 54
        Me.ckSame.Text = "Same as Physical Address"
        Me.ckSame.UseVisualStyleBackColor = False
        '
        'txtBillingContact
        '
        Me.txtBillingContact.AcceptsReturn = True
        Me.txtBillingContact.BackColor = System.Drawing.SystemColors.Window
        Me.txtBillingContact.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBillingContact.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillingContact.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBillingContact.Location = New System.Drawing.Point(96, 16)
        Me.txtBillingContact.MaxLength = 0
        Me.txtBillingContact.Name = "txtBillingContact"
        Me.txtBillingContact.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBillingContact.Size = New System.Drawing.Size(241, 20)
        Me.txtBillingContact.TabIndex = 53
        '
        'cmdAddress
        '
        Me.cmdAddress.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAddress.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAddress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddress.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAddress.Image = CType(resources.GetObject("cmdAddress.Image"), System.Drawing.Image)
        Me.cmdAddress.Location = New System.Drawing.Point(192, 80)
        Me.cmdAddress.Name = "cmdAddress"
        Me.cmdAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAddress.Size = New System.Drawing.Size(113, 57)
        Me.cmdAddress.TabIndex = 51
        Me.cmdAddress.Text = "Address Lookup"
        Me.cmdAddress.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdAddress.UseVisualStyleBackColor = False
        '
        'txtStoreBillState
        '
        Me.txtStoreBillState.AcceptsReturn = True
        Me.txtStoreBillState.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreBillState.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreBillState.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreBillState.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreBillState.Location = New System.Drawing.Point(48, 208)
        Me.txtStoreBillState.MaxLength = 0
        Me.txtStoreBillState.Name = "txtStoreBillState"
        Me.txtStoreBillState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreBillState.Size = New System.Drawing.Size(49, 20)
        Me.txtStoreBillState.TabIndex = 50
        '
        'txtStoreBillZip
        '
        Me.txtStoreBillZip.AcceptsReturn = True
        Me.txtStoreBillZip.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreBillZip.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreBillZip.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreBillZip.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreBillZip.Location = New System.Drawing.Point(224, 208)
        Me.txtStoreBillZip.MaxLength = 0
        Me.txtStoreBillZip.Name = "txtStoreBillZip"
        Me.txtStoreBillZip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreBillZip.Size = New System.Drawing.Size(97, 20)
        Me.txtStoreBillZip.TabIndex = 49
        '
        'txtStoreBillCity
        '
        Me.txtStoreBillCity.AcceptsReturn = True
        Me.txtStoreBillCity.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreBillCity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreBillCity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreBillCity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreBillCity.Location = New System.Drawing.Point(8, 184)
        Me.txtStoreBillCity.MaxLength = 0
        Me.txtStoreBillCity.Name = "txtStoreBillCity"
        Me.txtStoreBillCity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreBillCity.Size = New System.Drawing.Size(225, 20)
        Me.txtStoreBillCity.TabIndex = 46
        '
        'txtStoreBillAddress
        '
        Me.txtStoreBillAddress.AcceptsReturn = True
        Me.txtStoreBillAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreBillAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreBillAddress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreBillAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreBillAddress.Location = New System.Drawing.Point(8, 144)
        Me.txtStoreBillAddress.MaxLength = 0
        Me.txtStoreBillAddress.Name = "txtStoreBillAddress"
        Me.txtStoreBillAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreBillAddress.Size = New System.Drawing.Size(313, 20)
        Me.txtStoreBillAddress.TabIndex = 26
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(6, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(91, 28)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Billing Account"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(9, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(88, 29)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Billing Contact"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(168, 208)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(49, 17)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Zip Code"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 208)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(41, 17)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "State"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(49, 17)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "City"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(65, 17)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Address"
        '
        'txtOccupants
        '
        Me.txtOccupants.AcceptsReturn = True
        Me.txtOccupants.BackColor = System.Drawing.SystemColors.Window
        Me.txtOccupants.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOccupants.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOccupants.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOccupants.Location = New System.Drawing.Point(264, 176)
        Me.txtOccupants.MaxLength = 0
        Me.txtOccupants.Name = "txtOccupants"
        Me.txtOccupants.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOccupants.Size = New System.Drawing.Size(113, 20)
        Me.txtOccupants.TabIndex = 23
        '
        'txtCustId
        '
        Me.txtCustId.AcceptsReturn = True
        Me.txtCustId.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustId.Location = New System.Drawing.Point(248, 40)
        Me.txtCustId.MaxLength = 0
        Me.txtCustId.Name = "txtCustId"
        Me.txtCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCustId.Size = New System.Drawing.Size(81, 20)
        Me.txtCustId.TabIndex = 22
        Me.txtCustId.Visible = False
        '
        'txtCustName
        '
        Me.txtCustName.AcceptsReturn = True
        Me.txtCustName.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustName.Enabled = False
        Me.txtCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustName.Location = New System.Drawing.Point(64, 40)
        Me.txtCustName.MaxLength = 0
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.ReadOnly = True
        Me.txtCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCustName.Size = New System.Drawing.Size(129, 20)
        Me.txtCustName.TabIndex = 0
        '
        'txtStoreNumber
        '
        Me.txtStoreNumber.AcceptsReturn = True
        Me.txtStoreNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreNumber.Location = New System.Drawing.Point(64, 72)
        Me.txtStoreNumber.MaxLength = 0
        Me.txtStoreNumber.Name = "txtStoreNumber"
        Me.txtStoreNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreNumber.Size = New System.Drawing.Size(129, 20)
        Me.txtStoreNumber.TabIndex = 1
        '
        'txtStorePhone1
        '
        Me.txtStorePhone1.AcceptsReturn = True
        Me.txtStorePhone1.BackColor = System.Drawing.SystemColors.Window
        Me.txtStorePhone1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStorePhone1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStorePhone1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStorePhone1.Location = New System.Drawing.Point(184, 256)
        Me.txtStorePhone1.MaxLength = 15
        Me.txtStorePhone1.Name = "txtStorePhone1"
        Me.txtStorePhone1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStorePhone1.Size = New System.Drawing.Size(113, 20)
        Me.txtStorePhone1.TabIndex = 4
        Me.txtStorePhone1.Visible = False
        '
        'txtStorePhone2
        '
        Me.txtStorePhone2.AcceptsReturn = True
        Me.txtStorePhone2.BackColor = System.Drawing.SystemColors.Window
        Me.txtStorePhone2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStorePhone2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStorePhone2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStorePhone2.Location = New System.Drawing.Point(184, 280)
        Me.txtStorePhone2.MaxLength = 15
        Me.txtStorePhone2.Name = "txtStorePhone2"
        Me.txtStorePhone2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStorePhone2.Size = New System.Drawing.Size(113, 20)
        Me.txtStorePhone2.TabIndex = 6
        Me.txtStorePhone2.Visible = False
        '
        'txtStoreContact
        '
        Me.txtStoreContact.AcceptsReturn = True
        Me.txtStoreContact.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreContact.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreContact.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreContact.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreContact.Location = New System.Drawing.Point(64, 136)
        Me.txtStoreContact.MaxLength = 60
        Me.txtStoreContact.Name = "txtStoreContact"
        Me.txtStoreContact.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreContact.Size = New System.Drawing.Size(185, 20)
        Me.txtStoreContact.TabIndex = 8
        '
        'cbStoreStatus
        '
        Me.cbStoreStatus.BackColor = System.Drawing.SystemColors.Window
        Me.cbStoreStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbStoreStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStoreStatus.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbStoreStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbStoreStatus.Location = New System.Drawing.Point(64, 176)
        Me.cbStoreStatus.Name = "cbStoreStatus"
        Me.cbStoreStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbStoreStatus.Size = New System.Drawing.Size(97, 22)
        Me.cbStoreStatus.TabIndex = 9
        '
        'txtStoreFax1
        '
        Me.txtStoreFax1.AcceptsReturn = True
        Me.txtStoreFax1.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreFax1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreFax1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreFax1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreFax1.Location = New System.Drawing.Point(304, 256)
        Me.txtStoreFax1.MaxLength = 15
        Me.txtStoreFax1.Name = "txtStoreFax1"
        Me.txtStoreFax1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreFax1.Size = New System.Drawing.Size(106, 20)
        Me.txtStoreFax1.TabIndex = 5
        Me.txtStoreFax1.Visible = False
        '
        'txtStoreFax2
        '
        Me.txtStoreFax2.AcceptsReturn = True
        Me.txtStoreFax2.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreFax2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreFax2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreFax2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreFax2.Location = New System.Drawing.Point(304, 280)
        Me.txtStoreFax2.MaxLength = 15
        Me.txtStoreFax2.Name = "txtStoreFax2"
        Me.txtStoreFax2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreFax2.Size = New System.Drawing.Size(106, 20)
        Me.txtStoreFax2.TabIndex = 7
        Me.txtStoreFax2.Visible = False
        '
        'txtStoreFolder
        '
        Me.txtStoreFolder.AcceptsReturn = True
        Me.txtStoreFolder.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreFolder.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreFolder.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreFolder.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreFolder.Location = New System.Drawing.Point(64, 216)
        Me.txtStoreFolder.MaxLength = 20
        Me.txtStoreFolder.Name = "txtStoreFolder"
        Me.txtStoreFolder.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreFolder.Size = New System.Drawing.Size(97, 20)
        Me.txtStoreFolder.TabIndex = 10
        '
        'txtStoreCoCode
        '
        Me.txtStoreCoCode.AcceptsReturn = True
        Me.txtStoreCoCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreCoCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreCoCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreCoCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreCoCode.Location = New System.Drawing.Point(64, 256)
        Me.txtStoreCoCode.MaxLength = 15
        Me.txtStoreCoCode.Name = "txtStoreCoCode"
        Me.txtStoreCoCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreCoCode.Size = New System.Drawing.Size(97, 20)
        Me.txtStoreCoCode.TabIndex = 11
        '
        'mtxtStoreZip
        '
        Me.mtxtStoreZip.AllowPromptAsInput = False
        Me.mtxtStoreZip.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtStoreZip.Location = New System.Drawing.Point(256, 208)
        Me.mtxtStoreZip.Mask = "#####-CCCCC"
        Me.mtxtStoreZip.Name = "mtxtStoreZip"
        Me.mtxtStoreZip.Size = New System.Drawing.Size(113, 20)
        Me.mtxtStoreZip.TabIndex = 3
        Me.mtxtStoreZip.Visible = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(8, 416)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(49, 33)
        Me.Label11.TabIndex = 63
        Me.Label11.Text = "Date Sold"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(8, 384)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(41, 17)
        Me.Label10.TabIndex = 61
        Me.Label10.Text = "Sold"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(3, 352)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(55, 24)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "Market"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(6, 320)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(60, 19)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "LF Group"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(184, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(73, 22)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Occupancy"
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.SystemColors.Control
        Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(6, 40)
        Me.Label30.Name = "Label30"
        Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label30.Size = New System.Drawing.Size(60, 19)
        Me.Label30.TabIndex = 21
        Me.Label30.Text = "Customer"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.SystemColors.Control
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(3, 72)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(60, 17)
        Me.Label29.TabIndex = 20
        Me.Label29.Text = "Store No"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.SystemColors.Control
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label28.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(8, 104)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(58, 19)
        Me.Label28.TabIndex = 19
        Me.Label28.Text = "Name"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(8, 136)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(55, 33)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "Contact Name"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(8, 184)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(41, 17)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Status"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(6, 216)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(60, 19)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Folder No"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(6, 256)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(60, 33)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Company Code"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(416, 520)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 33)
        Me.cmdCancel.TabIndex = 14
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(328, 520)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(57, 33)
        Me.cmdOk.TabIndex = 12
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'frmStoreEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(814, 565)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 118)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStoreEntry"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Store Information"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Frame3.ResumeLayout(False)
        Me.Frame3.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtStoreSoldDate As System.Windows.Forms.DateTimePicker
#End Region 
End Class