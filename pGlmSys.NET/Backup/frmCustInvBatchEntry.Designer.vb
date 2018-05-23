<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCustInvBatchEntry
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
	Public WithEvents obStore As System.Windows.Forms.RadioButton
	Public WithEvents obCustomer As System.Windows.Forms.RadioButton
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents cbTemplate As System.Windows.Forms.ComboBox
	Public WithEvents txBatchDesc As System.Windows.Forms.TextBox
	Public WithEvents cbStoreGroup As System.Windows.Forms.ComboBox
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents txtInvoiceDate As System.Windows.Forms.TextBox
	Public WithEvents txBillingPeriod As System.Windows.Forms.TextBox
	Public WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
	Public WithEvents txtDescription As System.Windows.Forms.TextBox
	Public WithEvents txtGreeting As System.Windows.Forms.TextBox
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cbPeriod As System.Windows.Forms.ComboBox
	Public WithEvents cmdBuildDoc As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.obStore = New System.Windows.Forms.RadioButton
        Me.obCustomer = New System.Windows.Forms.RadioButton
        Me.cbTemplate = New System.Windows.Forms.ComboBox
        Me.txBatchDesc = New System.Windows.Forms.TextBox
        Me.cbStoreGroup = New System.Windows.Forms.ComboBox
        Me.cbCustName = New System.Windows.Forms.ComboBox
        Me.cbCustId = New System.Windows.Forms.ComboBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.txtInvoiceDate = New System.Windows.Forms.TextBox
        Me.txBillingPeriod = New System.Windows.Forms.TextBox
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtGreeting = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cbPeriod = New System.Windows.Forms.ComboBox
        Me.cmdBuildDoc = New System.Windows.Forms.Button
        Me.cmdClose = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtInvoiceDate = New System.Windows.Forms.DateTimePicker
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.obStore)
        Me.Frame2.Controls.Add(Me.obCustomer)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(40, 264)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(329, 105)
        Me.Frame2.TabIndex = 27
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Account No"
        '
        'obStore
        '
        Me.obStore.BackColor = System.Drawing.SystemColors.Control
        Me.obStore.Cursor = System.Windows.Forms.Cursors.Default
        Me.obStore.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obStore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obStore.Location = New System.Drawing.Point(16, 64)
        Me.obStore.Name = "obStore"
        Me.obStore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obStore.Size = New System.Drawing.Size(201, 17)
        Me.obStore.TabIndex = 29
        Me.obStore.TabStop = True
        Me.obStore.Text = "Use Account from Store "
        Me.obStore.UseVisualStyleBackColor = False
        '
        'obCustomer
        '
        Me.obCustomer.BackColor = System.Drawing.SystemColors.Control
        Me.obCustomer.Cursor = System.Windows.Forms.Cursors.Default
        Me.obCustomer.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obCustomer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obCustomer.Location = New System.Drawing.Point(16, 24)
        Me.obCustomer.Name = "obCustomer"
        Me.obCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obCustomer.Size = New System.Drawing.Size(273, 25)
        Me.obCustomer.TabIndex = 28
        Me.obCustomer.TabStop = True
        Me.obCustomer.Text = "Use Account from Customer "
        Me.obCustomer.UseVisualStyleBackColor = False
        '
        'cbTemplate
        '
        Me.cbTemplate.BackColor = System.Drawing.SystemColors.Window
        Me.cbTemplate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTemplate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTemplate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbTemplate.Location = New System.Drawing.Point(128, 192)
        Me.cbTemplate.Name = "cbTemplate"
        Me.cbTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbTemplate.Size = New System.Drawing.Size(201, 22)
        Me.cbTemplate.TabIndex = 26
        '
        'txBatchDesc
        '
        Me.txBatchDesc.AcceptsReturn = True
        Me.txBatchDesc.BackColor = System.Drawing.SystemColors.Window
        Me.txBatchDesc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txBatchDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txBatchDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txBatchDesc.Location = New System.Drawing.Point(128, 224)
        Me.txBatchDesc.MaxLength = 100
        Me.txBatchDesc.Name = "txBatchDesc"
        Me.txBatchDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txBatchDesc.Size = New System.Drawing.Size(241, 20)
        Me.txBatchDesc.TabIndex = 24
        '
        'cbStoreGroup
        '
        Me.cbStoreGroup.BackColor = System.Drawing.SystemColors.Window
        Me.cbStoreGroup.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbStoreGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStoreGroup.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbStoreGroup.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbStoreGroup.Location = New System.Drawing.Point(128, 160)
        Me.cbStoreGroup.Name = "cbStoreGroup"
        Me.cbStoreGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbStoreGroup.Size = New System.Drawing.Size(201, 22)
        Me.cbStoreGroup.TabIndex = 22
        '
        'cbCustName
        '
        Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustName.Location = New System.Drawing.Point(128, 88)
        Me.cbCustName.Name = "cbCustName"
        Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustName.Size = New System.Drawing.Size(201, 22)
        Me.cbCustName.TabIndex = 14
        '
        'cbCustId
        '
        Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustId.Location = New System.Drawing.Point(256, 48)
        Me.cbCustId.Name = "cbCustId"
        Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustId.Size = New System.Drawing.Size(73, 22)
        Me.cbCustId.TabIndex = 13
        Me.cbCustId.Visible = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.txtInvoiceDate)
        Me.Frame1.Controls.Add(Me.txBillingPeriod)
        Me.Frame1.Controls.Add(Me.txtInvoiceNo)
        Me.Frame1.Controls.Add(Me.txtDescription)
        Me.Frame1.Controls.Add(Me.txtGreeting)
        Me.Frame1.Controls.Add(Me.Label7)
        Me.Frame1.Controls.Add(Me.Label5)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.Label6)
        Me.Frame1.Controls.Add(Me.Label8)
        Me.Frame1.Controls.Add(Me.Label14)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(384, 0)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(425, 513)
        Me.Frame1.TabIndex = 3
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Invoice Data"
        '
        'txtInvoiceDate
        '
        Me.txtInvoiceDate.AcceptsReturn = True
        Me.txtInvoiceDate.BackColor = System.Drawing.SystemColors.Window
        Me.txtInvoiceDate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInvoiceDate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInvoiceDate.Location = New System.Drawing.Point(104, 32)
        Me.txtInvoiceDate.MaxLength = 0
        Me.txtInvoiceDate.Name = "txtInvoiceDate"
        Me.txtInvoiceDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInvoiceDate.Size = New System.Drawing.Size(249, 20)
        Me.txtInvoiceDate.TabIndex = 8
        '
        'txBillingPeriod
        '
        Me.txBillingPeriod.AcceptsReturn = True
        Me.txBillingPeriod.BackColor = System.Drawing.SystemColors.Window
        Me.txBillingPeriod.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txBillingPeriod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txBillingPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txBillingPeriod.Location = New System.Drawing.Point(104, 64)
        Me.txBillingPeriod.MaxLength = 0
        Me.txBillingPeriod.Name = "txBillingPeriod"
        Me.txBillingPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txBillingPeriod.Size = New System.Drawing.Size(225, 20)
        Me.txBillingPeriod.TabIndex = 7
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.AcceptsReturn = True
        Me.txtInvoiceNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtInvoiceNo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInvoiceNo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInvoiceNo.Location = New System.Drawing.Point(104, 96)
        Me.txtInvoiceNo.MaxLength = 0
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInvoiceNo.Size = New System.Drawing.Size(193, 20)
        Me.txtInvoiceNo.TabIndex = 6
        '
        'txtDescription
        '
        Me.txtDescription.AcceptsReturn = True
        Me.txtDescription.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescription.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDescription.Location = New System.Drawing.Point(16, 152)
        Me.txtDescription.MaxLength = 0
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(393, 113)
        Me.txtDescription.TabIndex = 5
        '
        'txtGreeting
        '
        Me.txtGreeting.AcceptsReturn = True
        Me.txtGreeting.BackColor = System.Drawing.SystemColors.Window
        Me.txtGreeting.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGreeting.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGreeting.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGreeting.Location = New System.Drawing.Point(16, 320)
        Me.txtGreeting.MaxLength = 0
        Me.txtGreeting.Multiline = True
        Me.txtGreeting.Name = "txtGreeting"
        Me.txtGreeting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGreeting.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGreeting.Size = New System.Drawing.Size(393, 97)
        Me.txtGreeting.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 296)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(81, 17)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Letter Footer"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(89, 17)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Letter Body"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(81, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Invoice Date"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(13, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(89, 17)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "For the month of"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(73, 17)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "INVOICE NO:"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(160, 168)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(9, 1)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "Label14"
        '
        'cbPeriod
        '
        Me.cbPeriod.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbPeriod.Location = New System.Drawing.Point(128, 128)
        Me.cbPeriod.Name = "cbPeriod"
        Me.cbPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbPeriod.Size = New System.Drawing.Size(201, 22)
        Me.cbPeriod.TabIndex = 2
        '
        'cmdBuildDoc
        '
        Me.cmdBuildDoc.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBuildDoc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBuildDoc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBuildDoc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBuildDoc.Location = New System.Drawing.Point(24, 464)
        Me.cmdBuildDoc.Name = "cmdBuildDoc"
        Me.cmdBuildDoc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBuildDoc.Size = New System.Drawing.Size(89, 41)
        Me.cmdBuildDoc.TabIndex = 1
        Me.cmdBuildDoc.Text = "Generate Invoices"
        Me.cmdBuildDoc.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(136, 464)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(89, 41)
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(24, 192)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(91, 22)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Template"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(24, 227)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(97, 17)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Batch Desc"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(24, 160)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(78, 22)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Store Group"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(40, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(65, 17)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Invoice Date"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(40, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(65, 17)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Customer"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Invoicing Period"
        '
        'dtInvoiceDate
        '
        Me.dtInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtInvoiceDate.Location = New System.Drawing.Point(128, 48)
        Me.dtInvoiceDate.Name = "dtInvoiceDate"
        Me.dtInvoiceDate.Size = New System.Drawing.Size(113, 20)
        Me.dtInvoiceDate.TabIndex = 28
        '
        'frmCustInvBatchEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(811, 516)
        Me.Controls.Add(Me.dtInvoiceDate)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.cbTemplate)
        Me.Controls.Add(Me.txBatchDesc)
        Me.Controls.Add(Me.cbStoreGroup)
        Me.Controls.Add(Me.cbCustName)
        Me.Controls.Add(Me.cbCustId)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cbPeriod)
        Me.Controls.Add(Me.cmdBuildDoc)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "frmCustInvBatchEntry"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "MS-Word Invoice Batch Generation"
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtInvoiceDate As System.Windows.Forms.DateTimePicker
#End Region 
End Class