<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCheck
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
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents Text1 As System.Windows.Forms.TextBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents txtCheckNo As System.Windows.Forms.TextBox
	Public WithEvents cbBankAccount As System.Windows.Forms.ComboBox
	Public WithEvents cbBankName As System.Windows.Forms.ComboBox
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Account As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents frCheck As System.Windows.Forms.GroupBox
	Public WithEvents obCreditCard As System.Windows.Forms.RadioButton
	Public WithEvents obCheck As System.Windows.Forms.RadioButton
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents cbVendPayZip As System.Windows.Forms.ComboBox
	Public WithEvents cbVendPayCity As System.Windows.Forms.ComboBox
	Public WithEvents cbVendPayment As System.Windows.Forms.ComboBox
	Public WithEvents cmdVBranch As System.Windows.Forms.Button
	Public WithEvents cbVendPayAddress As System.Windows.Forms.ComboBox
    Public WithEvents cbCustomerName As System.Windows.Forms.ComboBox
	Public WithEvents cmdDrop As System.Windows.Forms.Button
	Public WithEvents cmdAdd As System.Windows.Forms.Button
	Public WithEvents cbState As System.Windows.Forms.ComboBox
	Public WithEvents cbVendor As System.Windows.Forms.ComboBox
	Public WithEvents cbCustomer As System.Windows.Forms.ComboBox
    Public WithEvents txtAmount As System.Windows.Forms.MaskedTextBox
    Public WithEvents txtAuthorizationCode As System.Windows.Forms.TextBox
	Public WithEvents cbCardNumber As System.Windows.Forms.ComboBox
	Public WithEvents cbCardBankName As System.Windows.Forms.ComboBox
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents frCreditCard As System.Windows.Forms.GroupBox
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheck))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command1 = New System.Windows.Forms.Button
        Me.Text1 = New System.Windows.Forms.TextBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.dgSelected = New System.Windows.Forms.DataGridView
        Me.dgPending = New System.Windows.Forms.DataGridView
        Me.frCheck = New System.Windows.Forms.GroupBox
        Me.txtCheckNo = New System.Windows.Forms.TextBox
        Me.cbBankAccount = New System.Windows.Forms.ComboBox
        Me.cbBankName = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Account = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.obCreditCard = New System.Windows.Forms.RadioButton
        Me.obCheck = New System.Windows.Forms.RadioButton
        Me.cbVendPayZip = New System.Windows.Forms.ComboBox
        Me.frCreditCard = New System.Windows.Forms.GroupBox
        Me.dtTranDate = New System.Windows.Forms.DateTimePicker
        Me.txtAuthorizationCode = New System.Windows.Forms.TextBox
        Me.cbCardNumber = New System.Windows.Forms.ComboBox
        Me.cbCardBankName = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cbVendPayCity = New System.Windows.Forms.ComboBox
        Me.cbVendPayment = New System.Windows.Forms.ComboBox
        Me.cmdVBranch = New System.Windows.Forms.Button
        Me.cbVendPayAddress = New System.Windows.Forms.ComboBox
        Me.cbCustomerName = New System.Windows.Forms.ComboBox
        Me.cmdDrop = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cbState = New System.Windows.Forms.ComboBox
        Me.cbVendor = New System.Windows.Forms.ComboBox
        Me.cbCustomer = New System.Windows.Forms.ComboBox
        Me.txtAmount = New System.Windows.Forms.MaskedTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Frame1.SuspendLayout()
        CType(Me.dgSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPending, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frCheck.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.frCreditCard.SuspendLayout()
        Me.SuspendLayout()
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(448, 480)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(97, 17)
        Me.Command1.TabIndex = 16
        Me.Command1.Text = "Command1"
        Me.Command1.UseVisualStyleBackColor = False
        Me.Command1.Visible = False
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(424, 440)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(169, 20)
        Me.Text1.TabIndex = 15
        Me.Text1.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(328, 456)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 41)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(248, 456)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(57, 41)
        Me.cmdOk.TabIndex = 7
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Window
        Me.Frame1.Controls.Add(Me.dgSelected)
        Me.Frame1.Controls.Add(Me.dgPending)
        Me.Frame1.Controls.Add(Me.frCheck)
        Me.Frame1.Controls.Add(Me.Frame2)
        Me.Frame1.Controls.Add(Me.cbVendPayZip)
        Me.Frame1.Controls.Add(Me.frCreditCard)
        Me.Frame1.Controls.Add(Me.cbVendPayCity)
        Me.Frame1.Controls.Add(Me.cbVendPayment)
        Me.Frame1.Controls.Add(Me.cmdVBranch)
        Me.Frame1.Controls.Add(Me.cbVendPayAddress)
        Me.Frame1.Controls.Add(Me.cbCustomerName)
        Me.Frame1.Controls.Add(Me.cmdDrop)
        Me.Frame1.Controls.Add(Me.cmdAdd)
        Me.Frame1.Controls.Add(Me.cbState)
        Me.Frame1.Controls.Add(Me.cbVendor)
        Me.Frame1.Controls.Add(Me.cbCustomer)
        Me.Frame1.Controls.Add(Me.txtAmount)
        Me.Frame1.Controls.Add(Me.Label6)
        Me.Frame1.Controls.Add(Me.Label10)
        Me.Frame1.Controls.Add(Me.Label9)
        Me.Frame1.Controls.Add(Me.Label5)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Frame1.Location = New System.Drawing.Point(8, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(609, 441)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Invoice Criteria"
        '
        'dgSelected
        '
        Me.dgSelected.AllowUserToAddRows = False
        Me.dgSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSelected.Location = New System.Drawing.Point(344, 216)
        Me.dgSelected.Name = "dgSelected"
        Me.dgSelected.Size = New System.Drawing.Size(249, 217)
        Me.dgSelected.TabIndex = 47
        '
        'dgPending
        '
        Me.dgPending.AllowUserToAddRows = False
        Me.dgPending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPending.Location = New System.Drawing.Point(16, 216)
        Me.dgPending.Name = "dgPending"
        Me.dgPending.Size = New System.Drawing.Size(249, 217)
        Me.dgPending.TabIndex = 46
        '
        'frCheck
        '
        Me.frCheck.BackColor = System.Drawing.SystemColors.HighlightText
        Me.frCheck.Controls.Add(Me.txtCheckNo)
        Me.frCheck.Controls.Add(Me.cbBankAccount)
        Me.frCheck.Controls.Add(Me.cbBankName)
        Me.frCheck.Controls.Add(Me.Label7)
        Me.frCheck.Controls.Add(Me.Account)
        Me.frCheck.Controls.Add(Me.Label8)
        Me.frCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frCheck.Location = New System.Drawing.Point(328, 24)
        Me.frCheck.Name = "frCheck"
        Me.frCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frCheck.Size = New System.Drawing.Size(201, 129)
        Me.frCheck.TabIndex = 29
        Me.frCheck.TabStop = False
        Me.frCheck.Text = "Check"
        '
        'txtCheckNo
        '
        Me.txtCheckNo.AcceptsReturn = True
        Me.txtCheckNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtCheckNo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCheckNo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheckNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCheckNo.Location = New System.Drawing.Point(56, 88)
        Me.txtCheckNo.MaxLength = 0
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCheckNo.Size = New System.Drawing.Size(105, 20)
        Me.txtCheckNo.TabIndex = 32
        '
        'cbBankAccount
        '
        Me.cbBankAccount.BackColor = System.Drawing.SystemColors.Window
        Me.cbBankAccount.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbBankAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBankAccount.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBankAccount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbBankAccount.Location = New System.Drawing.Point(56, 56)
        Me.cbBankAccount.Name = "cbBankAccount"
        Me.cbBankAccount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbBankAccount.Size = New System.Drawing.Size(137, 22)
        Me.cbBankAccount.TabIndex = 31
        '
        'cbBankName
        '
        Me.cbBankName.BackColor = System.Drawing.SystemColors.Window
        Me.cbBankName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBankName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBankName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbBankName.Location = New System.Drawing.Point(56, 24)
        Me.cbBankName.Name = "cbBankName"
        Me.cbBankName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbBankName.Size = New System.Drawing.Size(137, 22)
        Me.cbBankName.TabIndex = 30
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label7.Location = New System.Drawing.Point(1, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(49, 17)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Check #"
        '
        'Account
        '
        Me.Account.BackColor = System.Drawing.Color.White
        Me.Account.Cursor = System.Windows.Forms.Cursors.Default
        Me.Account.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Account.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Account.Location = New System.Drawing.Point(3, 56)
        Me.Account.Name = "Account"
        Me.Account.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Account.Size = New System.Drawing.Size(54, 16)
        Me.Account.TabIndex = 34
        Me.Account.Text = "Account"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(42, 22)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Bank"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Frame2.Controls.Add(Me.obCreditCard)
        Me.Frame2.Controls.Add(Me.obCheck)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.Color.Red
        Me.Frame2.Location = New System.Drawing.Point(8, 144)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(201, 41)
        Me.Frame2.TabIndex = 25
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Payment Type"
        '
        'obCreditCard
        '
        Me.obCreditCard.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obCreditCard.Cursor = System.Windows.Forms.Cursors.Default
        Me.obCreditCard.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obCreditCard.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obCreditCard.Location = New System.Drawing.Point(104, 16)
        Me.obCreditCard.Name = "obCreditCard"
        Me.obCreditCard.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obCreditCard.Size = New System.Drawing.Size(81, 17)
        Me.obCreditCard.TabIndex = 27
        Me.obCreditCard.TabStop = True
        Me.obCreditCard.Text = "Credit Card"
        Me.obCreditCard.UseVisualStyleBackColor = False
        '
        'obCheck
        '
        Me.obCheck.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.obCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obCheck.Location = New System.Drawing.Point(24, 16)
        Me.obCheck.Name = "obCheck"
        Me.obCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obCheck.Size = New System.Drawing.Size(65, 17)
        Me.obCheck.TabIndex = 26
        Me.obCheck.TabStop = True
        Me.obCheck.Text = "Check"
        Me.obCheck.UseVisualStyleBackColor = False
        '
        'cbVendPayZip
        '
        Me.cbVendPayZip.BackColor = System.Drawing.SystemColors.Window
        Me.cbVendPayZip.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbVendPayZip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVendPayZip.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVendPayZip.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbVendPayZip.Location = New System.Drawing.Point(272, 376)
        Me.cbVendPayZip.Name = "cbVendPayZip"
        Me.cbVendPayZip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbVendPayZip.Size = New System.Drawing.Size(97, 22)
        Me.cbVendPayZip.TabIndex = 24
        Me.cbVendPayZip.Visible = False
        '
        'frCreditCard
        '
        Me.frCreditCard.BackColor = System.Drawing.SystemColors.HighlightText
        Me.frCreditCard.Controls.Add(Me.dtTranDate)
        Me.frCreditCard.Controls.Add(Me.txtAuthorizationCode)
        Me.frCreditCard.Controls.Add(Me.cbCardNumber)
        Me.frCreditCard.Controls.Add(Me.cbCardBankName)
        Me.frCreditCard.Controls.Add(Me.Label14)
        Me.frCreditCard.Controls.Add(Me.Label13)
        Me.frCreditCard.Controls.Add(Me.Label12)
        Me.frCreditCard.Controls.Add(Me.Label11)
        Me.frCreditCard.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frCreditCard.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frCreditCard.Location = New System.Drawing.Point(334, 23)
        Me.frCreditCard.Name = "frCreditCard"
        Me.frCreditCard.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frCreditCard.Size = New System.Drawing.Size(217, 144)
        Me.frCreditCard.TabIndex = 28
        Me.frCreditCard.TabStop = False
        Me.frCreditCard.Text = "Credit Card"
        '
        'dtTranDate
        '
        Me.dtTranDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTranDate.Location = New System.Drawing.Point(72, 114)
        Me.dtTranDate.Name = "dtTranDate"
        Me.dtTranDate.Size = New System.Drawing.Size(105, 20)
        Me.dtTranDate.TabIndex = 44
        '
        'txtAuthorizationCode
        '
        Me.txtAuthorizationCode.AcceptsReturn = True
        Me.txtAuthorizationCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtAuthorizationCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAuthorizationCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAuthorizationCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAuthorizationCode.Location = New System.Drawing.Point(72, 88)
        Me.txtAuthorizationCode.MaxLength = 0
        Me.txtAuthorizationCode.Name = "txtAuthorizationCode"
        Me.txtAuthorizationCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAuthorizationCode.Size = New System.Drawing.Size(113, 20)
        Me.txtAuthorizationCode.TabIndex = 42
        '
        'cbCardNumber
        '
        Me.cbCardNumber.BackColor = System.Drawing.SystemColors.Window
        Me.cbCardNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCardNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCardNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCardNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCardNumber.Location = New System.Drawing.Point(72, 56)
        Me.cbCardNumber.Name = "cbCardNumber"
        Me.cbCardNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCardNumber.Size = New System.Drawing.Size(137, 22)
        Me.cbCardNumber.TabIndex = 41
        '
        'cbCardBankName
        '
        Me.cbCardBankName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCardBankName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCardBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCardBankName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCardBankName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCardBankName.Location = New System.Drawing.Point(72, 24)
        Me.cbCardBankName.Name = "cbCardBankName"
        Me.cbCardBankName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCardBankName.Size = New System.Drawing.Size(137, 22)
        Me.cbCardBankName.TabIndex = 40
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.White
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(8, 112)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(41, 17)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "Date"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(8, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(105, 17)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Auth Code"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(8, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(65, 17)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Credit Card"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(8, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(33, 17)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Bank"
        '
        'cbVendPayCity
        '
        Me.cbVendPayCity.BackColor = System.Drawing.SystemColors.Window
        Me.cbVendPayCity.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbVendPayCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVendPayCity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVendPayCity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbVendPayCity.Location = New System.Drawing.Point(272, 360)
        Me.cbVendPayCity.Name = "cbVendPayCity"
        Me.cbVendPayCity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbVendPayCity.Size = New System.Drawing.Size(97, 22)
        Me.cbVendPayCity.TabIndex = 23
        Me.cbVendPayCity.Visible = False
        '
        'cbVendPayment
        '
        Me.cbVendPayment.BackColor = System.Drawing.SystemColors.Window
        Me.cbVendPayment.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbVendPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVendPayment.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVendPayment.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbVendPayment.Location = New System.Drawing.Point(56, 88)
        Me.cbVendPayment.Name = "cbVendPayment"
        Me.cbVendPayment.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbVendPayment.Size = New System.Drawing.Size(249, 22)
        Me.cbVendPayment.TabIndex = 22
        '
        'cmdVBranch
        '
        Me.cmdVBranch.BackColor = System.Drawing.SystemColors.Control
        Me.cmdVBranch.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdVBranch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVBranch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdVBranch.Image = CType(resources.GetObject("cmdVBranch.Image"), System.Drawing.Image)
        Me.cmdVBranch.Location = New System.Drawing.Point(224, 112)
        Me.cmdVBranch.Name = "cmdVBranch"
        Me.cmdVBranch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVBranch.Size = New System.Drawing.Size(41, 40)
        Me.cmdVBranch.TabIndex = 20
        Me.cmdVBranch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdVBranch.UseVisualStyleBackColor = False
        '
        'cbVendPayAddress
        '
        Me.cbVendPayAddress.BackColor = System.Drawing.SystemColors.Window
        Me.cbVendPayAddress.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbVendPayAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVendPayAddress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVendPayAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbVendPayAddress.Location = New System.Drawing.Point(272, 344)
        Me.cbVendPayAddress.Name = "cbVendPayAddress"
        Me.cbVendPayAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbVendPayAddress.Size = New System.Drawing.Size(249, 22)
        Me.cbVendPayAddress.TabIndex = 19
        Me.cbVendPayAddress.Visible = False
        '
        'cbCustomerName
        '
        Me.cbCustomerName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustomerName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cbCustomerName.Enabled = False
        Me.cbCustomerName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustomerName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustomerName.Location = New System.Drawing.Point(160, 24)
        Me.cbCustomerName.Name = "cbCustomerName"
        Me.cbCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustomerName.Size = New System.Drawing.Size(145, 21)
        Me.cbCustomerName.TabIndex = 2
        '
        'cmdDrop
        '
        Me.cmdDrop.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDrop.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDrop.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDrop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDrop.Image = CType(resources.GetObject("cmdDrop.Image"), System.Drawing.Image)
        Me.cmdDrop.Location = New System.Drawing.Point(288, 312)
        Me.cmdDrop.Name = "cmdDrop"
        Me.cmdDrop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDrop.Size = New System.Drawing.Size(33, 32)
        Me.cmdDrop.TabIndex = 6
        Me.cmdDrop.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdDrop.UseVisualStyleBackColor = False
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAdd.Image = CType(resources.GetObject("cmdAdd.Image"), System.Drawing.Image)
        Me.cmdAdd.Location = New System.Drawing.Point(288, 272)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAdd.Size = New System.Drawing.Size(33, 32)
        Me.cmdAdd.TabIndex = 5
        Me.cmdAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdAdd.UseVisualStyleBackColor = False
        '
        'cbState
        '
        Me.cbState.BackColor = System.Drawing.SystemColors.Window
        Me.cbState.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbState.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbState.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbState.Location = New System.Drawing.Point(56, 120)
        Me.cbState.Name = "cbState"
        Me.cbState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbState.Size = New System.Drawing.Size(65, 22)
        Me.cbState.TabIndex = 4
        '
        'cbVendor
        '
        Me.cbVendor.BackColor = System.Drawing.SystemColors.Window
        Me.cbVendor.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVendor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVendor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbVendor.Location = New System.Drawing.Point(56, 56)
        Me.cbVendor.Name = "cbVendor"
        Me.cbVendor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbVendor.Size = New System.Drawing.Size(249, 22)
        Me.cbVendor.TabIndex = 3
        '
        'cbCustomer
        '
        Me.cbCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustomer.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustomer.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustomer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustomer.Location = New System.Drawing.Point(63, 23)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustomer.Size = New System.Drawing.Size(73, 22)
        Me.cbCustomer.TabIndex = 1
        '
        'txtAmount
        '
        Me.txtAmount.AllowPromptAsInput = False
        Me.txtAmount.BackColor = System.Drawing.SystemColors.Info
        Me.txtAmount.Enabled = False
        Me.txtAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(384, 160)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(105, 22)
        Me.txtAmount.TabIndex = 44
        Me.txtAmount.TabStop = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label6.Location = New System.Drawing.Point(325, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(58, 22)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Amount"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(144, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(81, 17)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "View Branches"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(8, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(57, 25)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Payment Address"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label5.Location = New System.Drawing.Point(344, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(249, 25)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Selected Invoices"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Location = New System.Drawing.Point(16, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(249, 25)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Pending Invoices"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(8, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(33, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "State"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(49, 22)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Vendor"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(57, 21)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Customer"
        '
        'frmCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.ClientSize = New System.Drawing.Size(626, 519)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Text1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmCheck"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Check Generation"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        CType(Me.dgSelected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPending, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frCheck.ResumeLayout(False)
        Me.frCheck.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.frCreditCard.ResumeLayout(False)
        Me.frCreditCard.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgSelected As System.Windows.Forms.DataGridView
    Friend WithEvents dgPending As System.Windows.Forms.DataGridView
    Friend WithEvents dtTranDate As System.Windows.Forms.DateTimePicker
#End Region 
End Class