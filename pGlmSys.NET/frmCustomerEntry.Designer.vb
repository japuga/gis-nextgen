<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCustomerEntry
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
	Public WithEvents txtBillingAccountNo As System.Windows.Forms.TextBox
	Public WithEvents txtContractNumber As System.Windows.Forms.TextBox
	Public WithEvents cbNegativeSavingsFlag As System.Windows.Forms.ComboBox
	Public WithEvents chkPayInvoices As System.Windows.Forms.CheckBox
	Public WithEvents cbQBGroupId As System.Windows.Forms.ComboBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents cbQBAccountName As System.Windows.Forms.ComboBox
	Public WithEvents cbQBCustName As System.Windows.Forms.ComboBox
	Public WithEvents cbQBGroupDesc As System.Windows.Forms.ComboBox
	Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents frQuickBooks As System.Windows.Forms.GroupBox
	Public WithEvents txtCustReportName As System.Windows.Forms.TextBox
	Public WithEvents mtxtCustPhone3 As System.Windows.Forms.MaskedTextBox
	Public WithEvents mtxtCustPhone2 As System.Windows.Forms.MaskedTextBox
	Public WithEvents mtxtCustPhone1 As System.Windows.Forms.MaskedTextBox
	Public WithEvents cbState As System.Windows.Forms.ComboBox
	Public WithEvents txtCustZip As System.Windows.Forms.TextBox
	Public WithEvents txtCustCity As System.Windows.Forms.TextBox
	Public WithEvents txtCustEmail As System.Windows.Forms.TextBox
	Public WithEvents txtCustAddress As System.Windows.Forms.TextBox
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents txtContactTitle As System.Windows.Forms.TextBox
	Public WithEvents txtCustContact As System.Windows.Forms.TextBox
	Public WithEvents txtCustName As System.Windows.Forms.TextBox
	Public WithEvents txtCustId As System.Windows.Forms.TextBox
	Public WithEvents Label19 As System.Windows.Forms.Label
	Public WithEvents Label18 As System.Windows.Forms.Label
	Public WithEvents label17 As System.Windows.Forms.Label
	Public WithEvents Label16 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtBillingAccountNo = New System.Windows.Forms.TextBox
        Me.txtContractNumber = New System.Windows.Forms.TextBox
        Me.cbNegativeSavingsFlag = New System.Windows.Forms.ComboBox
        Me.chkPayInvoices = New System.Windows.Forms.CheckBox
        Me.cbQBGroupId = New System.Windows.Forms.ComboBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.frQuickBooks = New System.Windows.Forms.GroupBox
        Me.cbQBAccountName = New System.Windows.Forms.ComboBox
        Me.cbQBCustName = New System.Windows.Forms.ComboBox
        Me.cbQBGroupDesc = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtCustReportName = New System.Windows.Forms.TextBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.mtxtCustPhone3 = New System.Windows.Forms.MaskedTextBox
        Me.mtxtCustPhone2 = New System.Windows.Forms.MaskedTextBox
        Me.mtxtCustPhone1 = New System.Windows.Forms.MaskedTextBox
        Me.cbState = New System.Windows.Forms.ComboBox
        Me.txtCustZip = New System.Windows.Forms.TextBox
        Me.txtCustCity = New System.Windows.Forms.TextBox
        Me.txtCustEmail = New System.Windows.Forms.TextBox
        Me.txtCustAddress = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtContactTitle = New System.Windows.Forms.TextBox
        Me.txtCustContact = New System.Windows.Forms.TextBox
        Me.txtCustName = New System.Windows.Forms.TextBox
        Me.txtCustId = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.frQuickBooks.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBillingAccountNo
        '
        Me.txtBillingAccountNo.AcceptsReturn = True
        Me.txtBillingAccountNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtBillingAccountNo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBillingAccountNo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillingAccountNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBillingAccountNo.Location = New System.Drawing.Point(296, 152)
        Me.txtBillingAccountNo.MaxLength = 0
        Me.txtBillingAccountNo.Name = "txtBillingAccountNo"
        Me.txtBillingAccountNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBillingAccountNo.Size = New System.Drawing.Size(161, 19)
        Me.txtBillingAccountNo.TabIndex = 43
        '
        'txtContractNumber
        '
        Me.txtContractNumber.AcceptsReturn = True
        Me.txtContractNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtContractNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtContractNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContractNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtContractNumber.Location = New System.Drawing.Point(296, 120)
        Me.txtContractNumber.MaxLength = 0
        Me.txtContractNumber.Name = "txtContractNumber"
        Me.txtContractNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtContractNumber.Size = New System.Drawing.Size(161, 19)
        Me.txtContractNumber.TabIndex = 41
        '
        'cbNegativeSavingsFlag
        '
        Me.cbNegativeSavingsFlag.BackColor = System.Drawing.SystemColors.Window
        Me.cbNegativeSavingsFlag.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbNegativeSavingsFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNegativeSavingsFlag.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNegativeSavingsFlag.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbNegativeSavingsFlag.Location = New System.Drawing.Point(144, 120)
        Me.cbNegativeSavingsFlag.Name = "cbNegativeSavingsFlag"
        Me.cbNegativeSavingsFlag.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbNegativeSavingsFlag.Size = New System.Drawing.Size(57, 22)
        Me.cbNegativeSavingsFlag.TabIndex = 20
        '
        'chkPayInvoices
        '
        Me.chkPayInvoices.BackColor = System.Drawing.SystemColors.Control
        Me.chkPayInvoices.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPayInvoices.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPayInvoices.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPayInvoices.Location = New System.Drawing.Point(16, 152)
        Me.chkPayInvoices.Name = "chkPayInvoices"
        Me.chkPayInvoices.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPayInvoices.Size = New System.Drawing.Size(137, 17)
        Me.chkPayInvoices.TabIndex = 19
        Me.chkPayInvoices.Text = "Do NOT pay Invoices"
        Me.chkPayInvoices.UseVisualStyleBackColor = False
        '
        'cbQBGroupId
        '
        Me.cbQBGroupId.BackColor = System.Drawing.SystemColors.Window
        Me.cbQBGroupId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbQBGroupId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbQBGroupId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbQBGroupId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbQBGroupId.Location = New System.Drawing.Point(40, 512)
        Me.cbQBGroupId.Name = "cbQBGroupId"
        Me.cbQBGroupId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbQBGroupId.Size = New System.Drawing.Size(89, 22)
        Me.cbQBGroupId.TabIndex = 38
        Me.cbQBGroupId.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(264, 512)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 33)
        Me.cmdCancel.TabIndex = 37
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(160, 512)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(57, 33)
        Me.cmdOk.TabIndex = 36
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'frQuickBooks
        '
        Me.frQuickBooks.BackColor = System.Drawing.SystemColors.Control
        Me.frQuickBooks.Controls.Add(Me.cbQBAccountName)
        Me.frQuickBooks.Controls.Add(Me.cbQBCustName)
        Me.frQuickBooks.Controls.Add(Me.cbQBGroupDesc)
        Me.frQuickBooks.Controls.Add(Me.Label15)
        Me.frQuickBooks.Controls.Add(Me.Label14)
        Me.frQuickBooks.Controls.Add(Me.Label13)
        Me.frQuickBooks.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frQuickBooks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frQuickBooks.Location = New System.Drawing.Point(16, 360)
        Me.frQuickBooks.Name = "frQuickBooks"
        Me.frQuickBooks.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frQuickBooks.Size = New System.Drawing.Size(337, 137)
        Me.frQuickBooks.TabIndex = 25
        Me.frQuickBooks.TabStop = False
        Me.frQuickBooks.Text = "Quick Books Settings"
        '
        'cbQBAccountName
        '
        Me.cbQBAccountName.BackColor = System.Drawing.SystemColors.Window
        Me.cbQBAccountName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbQBAccountName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbQBAccountName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbQBAccountName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbQBAccountName.Location = New System.Drawing.Point(112, 88)
        Me.cbQBAccountName.Name = "cbQBAccountName"
        Me.cbQBAccountName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbQBAccountName.Size = New System.Drawing.Size(177, 22)
        Me.cbQBAccountName.TabIndex = 35
        '
        'cbQBCustName
        '
        Me.cbQBCustName.BackColor = System.Drawing.SystemColors.Window
        Me.cbQBCustName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbQBCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbQBCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbQBCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbQBCustName.Location = New System.Drawing.Point(112, 56)
        Me.cbQBCustName.Name = "cbQBCustName"
        Me.cbQBCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbQBCustName.Size = New System.Drawing.Size(177, 22)
        Me.cbQBCustName.TabIndex = 34
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
        Me.cbQBGroupDesc.Size = New System.Drawing.Size(177, 22)
        Me.cbQBGroupDesc.TabIndex = 33
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(12, 88)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(85, 22)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "Account Name"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(12, 56)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(85, 22)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "Customer Name"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(12, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(93, 22)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Company Group"
        '
        'txtCustReportName
        '
        Me.txtCustReportName.AcceptsReturn = True
        Me.txtCustReportName.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustReportName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustReportName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustReportName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustReportName.Location = New System.Drawing.Point(96, 88)
        Me.txtCustReportName.MaxLength = 0
        Me.txtCustReportName.Name = "txtCustReportName"
        Me.txtCustReportName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCustReportName.Size = New System.Drawing.Size(361, 19)
        Me.txtCustReportName.TabIndex = 18
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.mtxtCustPhone3)
        Me.Frame1.Controls.Add(Me.mtxtCustPhone2)
        Me.Frame1.Controls.Add(Me.mtxtCustPhone1)
        Me.Frame1.Controls.Add(Me.cbState)
        Me.Frame1.Controls.Add(Me.txtCustZip)
        Me.Frame1.Controls.Add(Me.txtCustCity)
        Me.Frame1.Controls.Add(Me.txtCustEmail)
        Me.Frame1.Controls.Add(Me.txtCustAddress)
        Me.Frame1.Controls.Add(Me.Label11)
        Me.Frame1.Controls.Add(Me.Label10)
        Me.Frame1.Controls.Add(Me.Label9)
        Me.Frame1.Controls.Add(Me.Label8)
        Me.Frame1.Controls.Add(Me.Label7)
        Me.Frame1.Controls.Add(Me.Label6)
        Me.Frame1.Controls.Add(Me.Label5)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(16, 184)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(449, 161)
        Me.Frame1.TabIndex = 9
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Main Address"
        '
        'mtxtCustPhone3
        '
        Me.mtxtCustPhone3.AllowPromptAsInput = False
        Me.mtxtCustPhone3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtCustPhone3.Location = New System.Drawing.Point(296, 120)
        Me.mtxtCustPhone3.Mask = "(###)-###-####"
        Me.mtxtCustPhone3.Name = "mtxtCustPhone3"
        Me.mtxtCustPhone3.Size = New System.Drawing.Size(105, 20)
        Me.mtxtCustPhone3.TabIndex = 29
        '
        'mtxtCustPhone2
        '
        Me.mtxtCustPhone2.AllowPromptAsInput = False
        Me.mtxtCustPhone2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtCustPhone2.Location = New System.Drawing.Point(296, 88)
        Me.mtxtCustPhone2.Mask = "(###)-###-####"
        Me.mtxtCustPhone2.Name = "mtxtCustPhone2"
        Me.mtxtCustPhone2.Size = New System.Drawing.Size(105, 20)
        Me.mtxtCustPhone2.TabIndex = 28
        '
        'mtxtCustPhone1
        '
        Me.mtxtCustPhone1.AllowPromptAsInput = False
        Me.mtxtCustPhone1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtCustPhone1.Location = New System.Drawing.Point(296, 56)
        Me.mtxtCustPhone1.Mask = "(###)-###-####"
        Me.mtxtCustPhone1.Name = "mtxtCustPhone1"
        Me.mtxtCustPhone1.Size = New System.Drawing.Size(105, 20)
        Me.mtxtCustPhone1.TabIndex = 27
        '
        'cbState
        '
        Me.cbState.BackColor = System.Drawing.SystemColors.Window
        Me.cbState.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbState.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbState.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbState.Location = New System.Drawing.Point(64, 88)
        Me.cbState.Name = "cbState"
        Me.cbState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbState.Size = New System.Drawing.Size(81, 22)
        Me.cbState.TabIndex = 23
        '
        'txtCustZip
        '
        Me.txtCustZip.AcceptsReturn = True
        Me.txtCustZip.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustZip.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustZip.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustZip.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustZip.Location = New System.Drawing.Point(64, 121)
        Me.txtCustZip.MaxLength = 0
        Me.txtCustZip.Name = "txtCustZip"
        Me.txtCustZip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCustZip.Size = New System.Drawing.Size(65, 19)
        Me.txtCustZip.TabIndex = 24
        '
        'txtCustCity
        '
        Me.txtCustCity.AcceptsReturn = True
        Me.txtCustCity.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustCity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustCity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustCity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustCity.Location = New System.Drawing.Point(64, 57)
        Me.txtCustCity.MaxLength = 0
        Me.txtCustCity.Name = "txtCustCity"
        Me.txtCustCity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCustCity.Size = New System.Drawing.Size(121, 19)
        Me.txtCustCity.TabIndex = 22
        '
        'txtCustEmail
        '
        Me.txtCustEmail.AcceptsReturn = True
        Me.txtCustEmail.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustEmail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustEmail.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustEmail.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustEmail.Location = New System.Drawing.Point(296, 24)
        Me.txtCustEmail.MaxLength = 0
        Me.txtCustEmail.Name = "txtCustEmail"
        Me.txtCustEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCustEmail.Size = New System.Drawing.Size(137, 19)
        Me.txtCustEmail.TabIndex = 26
        '
        'txtCustAddress
        '
        Me.txtCustAddress.AcceptsReturn = True
        Me.txtCustAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustAddress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustAddress.Location = New System.Drawing.Point(65, 24)
        Me.txtCustAddress.MaxLength = 0
        Me.txtCustAddress.Name = "txtCustAddress"
        Me.txtCustAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCustAddress.Size = New System.Drawing.Size(137, 19)
        Me.txtCustAddress.TabIndex = 21
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(241, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(41, 17)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "E-mail"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(9, 122)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(40, 17)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Zip"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(9, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(48, 17)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "State"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(6, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(43, 17)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "City"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(3, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(55, 17)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Address"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(240, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(49, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Phone 3"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(240, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(49, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Phone 2"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(240, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(49, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Phone 1"
        '
        'txtContactTitle
        '
        Me.txtContactTitle.AcceptsReturn = True
        Me.txtContactTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txtContactTitle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtContactTitle.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactTitle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtContactTitle.Location = New System.Drawing.Point(296, 56)
        Me.txtContactTitle.MaxLength = 0
        Me.txtContactTitle.Name = "txtContactTitle"
        Me.txtContactTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtContactTitle.Size = New System.Drawing.Size(161, 19)
        Me.txtContactTitle.TabIndex = 8
        '
        'txtCustContact
        '
        Me.txtCustContact.AcceptsReturn = True
        Me.txtCustContact.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustContact.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustContact.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustContact.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustContact.Location = New System.Drawing.Point(96, 56)
        Me.txtCustContact.MaxLength = 0
        Me.txtCustContact.Name = "txtCustContact"
        Me.txtCustContact.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCustContact.Size = New System.Drawing.Size(121, 19)
        Me.txtCustContact.TabIndex = 7
        '
        'txtCustName
        '
        Me.txtCustName.AcceptsReturn = True
        Me.txtCustName.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustName.Location = New System.Drawing.Point(296, 16)
        Me.txtCustName.MaxLength = 0
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCustName.Size = New System.Drawing.Size(161, 19)
        Me.txtCustName.TabIndex = 3
        '
        'txtCustId
        '
        Me.txtCustId.AcceptsReturn = True
        Me.txtCustId.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustId.Location = New System.Drawing.Point(96, 16)
        Me.txtCustId.MaxLength = 0
        Me.txtCustId.Name = "txtCustId"
        Me.txtCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCustId.Size = New System.Drawing.Size(41, 19)
        Me.txtCustId.TabIndex = 1
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(210, 152)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(79, 25)
        Me.Label19.TabIndex = 42
        Me.Label19.Text = "Billing Account"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(216, 120)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(73, 29)
        Me.Label18.TabIndex = 40
        Me.Label18.Text = "Contract No."
        '
        'label17
        '
        Me.label17.BackColor = System.Drawing.SystemColors.Control
        Me.label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.label17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label17.Location = New System.Drawing.Point(9, 120)
        Me.label17.Name = "label17"
        Me.label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label17.Size = New System.Drawing.Size(129, 19)
        Me.label17.TabIndex = 39
        Me.label17.Text = "Show Negative Savings"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(12, 88)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(87, 19)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Report Caption"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(223, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(67, 17)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Title"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(12, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(78, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Contact Name"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(219, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(54, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Name"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID"
        '
        'frmCustomerEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(483, 563)
        Me.Controls.Add(Me.txtBillingAccountNo)
        Me.Controls.Add(Me.txtContractNumber)
        Me.Controls.Add(Me.cbNegativeSavingsFlag)
        Me.Controls.Add(Me.chkPayInvoices)
        Me.Controls.Add(Me.cbQBGroupId)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.frQuickBooks)
        Me.Controls.Add(Me.txtCustReportName)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.txtContactTitle)
        Me.Controls.Add(Me.txtCustContact)
        Me.Controls.Add(Me.txtCustName)
        Me.Controls.Add(Me.txtCustId)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmCustomerEntry"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Customer Entry"
        Me.frQuickBooks.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class