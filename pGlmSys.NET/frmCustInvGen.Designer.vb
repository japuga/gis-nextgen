<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCustInvGen
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
	Public WithEvents cmdSelectedValues As System.Windows.Forms.Button
	Public WithEvents ckTotalByStoreGroup As System.Windows.Forms.CheckBox
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents VScroll1 As System.Windows.Forms.VScrollBar
	Public WithEvents cbTemplate As System.Windows.Forms.ComboBox
	Public WithEvents cbGroupStore As System.Windows.Forms.ComboBox
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdDisplayAmounts As System.Windows.Forms.Button
	Public WithEvents cmdBuildDoc As System.Windows.Forms.Button
	Public WithEvents cbPeriod As System.Windows.Forms.ComboBox
	Public WithEvents txtLocation As System.Windows.Forms.TextBox
	Public WithEvents ckLocation As System.Windows.Forms.CheckBox
	Public WithEvents ckGrandTotal As System.Windows.Forms.CheckBox
	Public WithEvents ckTax As System.Windows.Forms.CheckBox
	Public WithEvents ckInvoiceFee As System.Windows.Forms.CheckBox
	Public WithEvents ckStoreFlatFee As System.Windows.Forms.CheckBox
	Public WithEvents ckSavingsPercent As System.Windows.Forms.CheckBox
	Public WithEvents txtGrandTotal As System.Windows.Forms.MaskedTextBox
	Public WithEvents txtTax As System.Windows.Forms.MaskedTextBox
	Public WithEvents txtInvoiceFee As System.Windows.Forms.MaskedTextBox
	Public WithEvents txtStoreFlatFee As System.Windows.Forms.MaskedTextBox
	Public WithEvents txtSavingsPercent As System.Windows.Forms.MaskedTextBox
	Public WithEvents txtSavings As System.Windows.Forms.MaskedTextBox
	Public WithEvents txtInvoiceTotal As System.Windows.Forms.MaskedTextBox
	Public WithEvents txtGreeting As System.Windows.Forms.TextBox
	Public WithEvents txtDescription As System.Windows.Forms.TextBox
	Public WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
	Public WithEvents txtAccountNo As System.Windows.Forms.TextBox
	Public WithEvents txBillingPeriod As System.Windows.Forms.TextBox
	Public WithEvents txtInvoiceDate As System.Windows.Forms.TextBox
	Public WithEvents txtAddress As System.Windows.Forms.TextBox
	Public WithEvents Label19 As System.Windows.Forms.Label
	Public WithEvents Label16 As System.Windows.Forms.Label
	Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
    Public WithEvents Label18 As System.Windows.Forms.Label
	Public WithEvents Label17 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtGreeting = New System.Windows.Forms.TextBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.cmdSelectedValues = New System.Windows.Forms.Button
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.ckTotalByStoreGroup = New System.Windows.Forms.CheckBox
        Me.VScroll1 = New System.Windows.Forms.VScrollBar
        Me.cbTemplate = New System.Windows.Forms.ComboBox
        Me.cbGroupStore = New System.Windows.Forms.ComboBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdDisplayAmounts = New System.Windows.Forms.Button
        Me.cmdBuildDoc = New System.Windows.Forms.Button
        Me.cbPeriod = New System.Windows.Forms.ComboBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.ckLocation = New System.Windows.Forms.CheckBox
        Me.ckGrandTotal = New System.Windows.Forms.CheckBox
        Me.ckTax = New System.Windows.Forms.CheckBox
        Me.ckInvoiceFee = New System.Windows.Forms.CheckBox
        Me.ckStoreFlatFee = New System.Windows.Forms.CheckBox
        Me.ckSavingsPercent = New System.Windows.Forms.CheckBox
        Me.txtGrandTotal = New System.Windows.Forms.MaskedTextBox
        Me.txtTax = New System.Windows.Forms.MaskedTextBox
        Me.txtInvoiceFee = New System.Windows.Forms.MaskedTextBox
        Me.txtStoreFlatFee = New System.Windows.Forms.MaskedTextBox
        Me.txtSavingsPercent = New System.Windows.Forms.MaskedTextBox
        Me.txtSavings = New System.Windows.Forms.MaskedTextBox
        Me.txtInvoiceTotal = New System.Windows.Forms.MaskedTextBox
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox
        Me.txtAccountNo = New System.Windows.Forms.TextBox
        Me.txBillingPeriod = New System.Windows.Forms.TextBox
        Me.txtInvoiceDate = New System.Windows.Forms.TextBox
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbCustId = New System.Windows.Forms.ComboBox
        Me.cbCustName = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtInvoiceDate = New System.Windows.Forms.DateTimePicker
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtGreeting
        '
        Me.txtGreeting.AcceptsReturn = True
        Me.txtGreeting.BackColor = System.Drawing.SystemColors.Window
        Me.txtGreeting.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGreeting.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGreeting.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGreeting.Location = New System.Drawing.Point(16, 536)
        Me.txtGreeting.MaxLength = 0
        Me.txtGreeting.Multiline = True
        Me.txtGreeting.Name = "txtGreeting"
        Me.txtGreeting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGreeting.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGreeting.Size = New System.Drawing.Size(393, 49)
        Me.txtGreeting.TabIndex = 29
        Me.ToolTip1.SetToolTip(Me.txtGreeting, "Footer")
        '
        'txtDescription
        '
        Me.txtDescription.AcceptsReturn = True
        Me.txtDescription.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescription.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDescription.Location = New System.Drawing.Point(16, 256)
        Me.txtDescription.MaxLength = 0
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(393, 73)
        Me.txtDescription.TabIndex = 18
        Me.ToolTip1.SetToolTip(Me.txtDescription, "Body")
        '
        'cmdSelectedValues
        '
        Me.cmdSelectedValues.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelectedValues.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelectedValues.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSelectedValues.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelectedValues.Location = New System.Drawing.Point(312, 168)
        Me.cmdSelectedValues.Name = "cmdSelectedValues"
        Me.cmdSelectedValues.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelectedValues.Size = New System.Drawing.Size(33, 21)
        Me.cmdSelectedValues.TabIndex = 53
        Me.cmdSelectedValues.Text = "..."
        Me.cmdSelectedValues.UseVisualStyleBackColor = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.ckTotalByStoreGroup)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(16, 256)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(313, 129)
        Me.Frame2.TabIndex = 51
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Options"
        '
        'ckTotalByStoreGroup
        '
        Me.ckTotalByStoreGroup.BackColor = System.Drawing.SystemColors.Control
        Me.ckTotalByStoreGroup.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckTotalByStoreGroup.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckTotalByStoreGroup.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckTotalByStoreGroup.Location = New System.Drawing.Point(48, 24)
        Me.ckTotalByStoreGroup.Name = "ckTotalByStoreGroup"
        Me.ckTotalByStoreGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckTotalByStoreGroup.Size = New System.Drawing.Size(217, 17)
        Me.ckTotalByStoreGroup.TabIndex = 52
        Me.ckTotalByStoreGroup.Text = "Show Total by Store Group"
        Me.ckTotalByStoreGroup.UseVisualStyleBackColor = False
        '
        'VScroll1
        '
        Me.VScroll1.Cursor = System.Windows.Forms.Cursors.Default
        Me.VScroll1.LargeChange = 1
        Me.VScroll1.Location = New System.Drawing.Point(864, 0)
        Me.VScroll1.Maximum = 32767
        Me.VScroll1.Name = "VScroll1"
        Me.VScroll1.Size = New System.Drawing.Size(25, 465)
        Me.VScroll1.TabIndex = 48
        Me.VScroll1.TabStop = True
        '
        'cbTemplate
        '
        Me.cbTemplate.BackColor = System.Drawing.SystemColors.Window
        Me.cbTemplate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTemplate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTemplate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbTemplate.Location = New System.Drawing.Point(104, 208)
        Me.cbTemplate.Name = "cbTemplate"
        Me.cbTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbTemplate.Size = New System.Drawing.Size(201, 22)
        Me.cbTemplate.TabIndex = 34
        '
        'cbGroupStore
        '
        Me.cbGroupStore.BackColor = System.Drawing.SystemColors.Window
        Me.cbGroupStore.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbGroupStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGroupStore.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGroupStore.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbGroupStore.Location = New System.Drawing.Point(104, 168)
        Me.cbGroupStore.Name = "cbGroupStore"
        Me.cbGroupStore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbGroupStore.Size = New System.Drawing.Size(201, 22)
        Me.cbGroupStore.TabIndex = 32
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(232, 408)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(89, 41)
        Me.cmdClose.TabIndex = 30
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdDisplayAmounts
        '
        Me.cmdDisplayAmounts.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDisplayAmounts.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDisplayAmounts.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDisplayAmounts.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDisplayAmounts.Location = New System.Drawing.Point(32, 408)
        Me.cmdDisplayAmounts.Name = "cmdDisplayAmounts"
        Me.cmdDisplayAmounts.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDisplayAmounts.Size = New System.Drawing.Size(89, 41)
        Me.cmdDisplayAmounts.TabIndex = 26
        Me.cmdDisplayAmounts.Text = "Display Amounts"
        Me.cmdDisplayAmounts.UseVisualStyleBackColor = False
        '
        'cmdBuildDoc
        '
        Me.cmdBuildDoc.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBuildDoc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBuildDoc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBuildDoc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBuildDoc.Location = New System.Drawing.Point(136, 408)
        Me.cmdBuildDoc.Name = "cmdBuildDoc"
        Me.cmdBuildDoc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBuildDoc.Size = New System.Drawing.Size(89, 41)
        Me.cmdBuildDoc.TabIndex = 25
        Me.cmdBuildDoc.Text = "Build Document"
        Me.cmdBuildDoc.UseVisualStyleBackColor = False
        '
        'cbPeriod
        '
        Me.cbPeriod.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbPeriod.Location = New System.Drawing.Point(104, 128)
        Me.cbPeriod.Name = "cbPeriod"
        Me.cbPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbPeriod.Size = New System.Drawing.Size(201, 22)
        Me.cbPeriod.TabIndex = 8
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.txtLocation)
        Me.Frame1.Controls.Add(Me.ckLocation)
        Me.Frame1.Controls.Add(Me.ckGrandTotal)
        Me.Frame1.Controls.Add(Me.ckTax)
        Me.Frame1.Controls.Add(Me.ckInvoiceFee)
        Me.Frame1.Controls.Add(Me.ckStoreFlatFee)
        Me.Frame1.Controls.Add(Me.ckSavingsPercent)
        Me.Frame1.Controls.Add(Me.txtGrandTotal)
        Me.Frame1.Controls.Add(Me.txtTax)
        Me.Frame1.Controls.Add(Me.txtInvoiceFee)
        Me.Frame1.Controls.Add(Me.txtStoreFlatFee)
        Me.Frame1.Controls.Add(Me.txtSavingsPercent)
        Me.Frame1.Controls.Add(Me.txtSavings)
        Me.Frame1.Controls.Add(Me.txtInvoiceTotal)
        Me.Frame1.Controls.Add(Me.txtGreeting)
        Me.Frame1.Controls.Add(Me.txtDescription)
        Me.Frame1.Controls.Add(Me.txtInvoiceNo)
        Me.Frame1.Controls.Add(Me.txtAccountNo)
        Me.Frame1.Controls.Add(Me.txBillingPeriod)
        Me.Frame1.Controls.Add(Me.txtInvoiceDate)
        Me.Frame1.Controls.Add(Me.txtAddress)
        Me.Frame1.Controls.Add(Me.Label19)
        Me.Frame1.Controls.Add(Me.Label16)
        Me.Frame1.Controls.Add(Me.Label15)
        Me.Frame1.Controls.Add(Me.Label14)
        Me.Frame1.Controls.Add(Me.Label13)
        Me.Frame1.Controls.Add(Me.Label12)
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
        Me.Frame1.Location = New System.Drawing.Point(352, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(497, 601)
        Me.Frame1.TabIndex = 5
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Invoice Data"
        '
        'txtLocation
        '
        Me.txtLocation.AcceptsReturn = True
        Me.txtLocation.BackColor = System.Drawing.SystemColors.Window
        Me.txtLocation.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLocation.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocation.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLocation.Location = New System.Drawing.Point(104, 224)
        Me.txtLocation.MaxLength = 0
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLocation.Size = New System.Drawing.Size(305, 20)
        Me.txtLocation.TabIndex = 50
        '
        'ckLocation
        '
        Me.ckLocation.BackColor = System.Drawing.SystemColors.Control
        Me.ckLocation.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckLocation.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckLocation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckLocation.Location = New System.Drawing.Point(16, 224)
        Me.ckLocation.Name = "ckLocation"
        Me.ckLocation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckLocation.Size = New System.Drawing.Size(73, 17)
        Me.ckLocation.TabIndex = 49
        Me.ckLocation.Text = "Location"
        Me.ckLocation.UseVisualStyleBackColor = False
        '
        'ckGrandTotal
        '
        Me.ckGrandTotal.BackColor = System.Drawing.SystemColors.Control
        Me.ckGrandTotal.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckGrandTotal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckGrandTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckGrandTotal.Location = New System.Drawing.Point(224, 496)
        Me.ckGrandTotal.Name = "ckGrandTotal"
        Me.ckGrandTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckGrandTotal.Size = New System.Drawing.Size(17, 17)
        Me.ckGrandTotal.TabIndex = 47
        Me.ckGrandTotal.Text = "Check1"
        Me.ckGrandTotal.UseVisualStyleBackColor = False
        '
        'ckTax
        '
        Me.ckTax.BackColor = System.Drawing.SystemColors.Control
        Me.ckTax.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckTax.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckTax.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckTax.Location = New System.Drawing.Point(224, 472)
        Me.ckTax.Name = "ckTax"
        Me.ckTax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckTax.Size = New System.Drawing.Size(17, 17)
        Me.ckTax.TabIndex = 46
        Me.ckTax.Text = "Check1"
        Me.ckTax.UseVisualStyleBackColor = False
        '
        'ckInvoiceFee
        '
        Me.ckInvoiceFee.BackColor = System.Drawing.SystemColors.Control
        Me.ckInvoiceFee.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckInvoiceFee.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckInvoiceFee.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckInvoiceFee.Location = New System.Drawing.Point(224, 448)
        Me.ckInvoiceFee.Name = "ckInvoiceFee"
        Me.ckInvoiceFee.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckInvoiceFee.Size = New System.Drawing.Size(17, 25)
        Me.ckInvoiceFee.TabIndex = 45
        Me.ckInvoiceFee.Text = "Check1"
        Me.ckInvoiceFee.UseVisualStyleBackColor = False
        '
        'ckStoreFlatFee
        '
        Me.ckStoreFlatFee.BackColor = System.Drawing.SystemColors.Control
        Me.ckStoreFlatFee.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckStoreFlatFee.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckStoreFlatFee.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckStoreFlatFee.Location = New System.Drawing.Point(224, 424)
        Me.ckStoreFlatFee.Name = "ckStoreFlatFee"
        Me.ckStoreFlatFee.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckStoreFlatFee.Size = New System.Drawing.Size(17, 17)
        Me.ckStoreFlatFee.TabIndex = 44
        Me.ckStoreFlatFee.Text = "Check1"
        Me.ckStoreFlatFee.UseVisualStyleBackColor = False
        '
        'ckSavingsPercent
        '
        Me.ckSavingsPercent.BackColor = System.Drawing.SystemColors.Control
        Me.ckSavingsPercent.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckSavingsPercent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckSavingsPercent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckSavingsPercent.Location = New System.Drawing.Point(224, 400)
        Me.ckSavingsPercent.Name = "ckSavingsPercent"
        Me.ckSavingsPercent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckSavingsPercent.Size = New System.Drawing.Size(17, 17)
        Me.ckSavingsPercent.TabIndex = 43
        Me.ckSavingsPercent.Text = "Check1"
        Me.ckSavingsPercent.UseVisualStyleBackColor = False
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.AllowPromptAsInput = False
        Me.txtGrandTotal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotal.Location = New System.Drawing.Point(288, 496)
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.Size = New System.Drawing.Size(113, 20)
        Me.txtGrandTotal.TabIndex = 41
        '
        'txtTax
        '
        Me.txtTax.AllowPromptAsInput = False
        Me.txtTax.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTax.Location = New System.Drawing.Point(288, 472)
        Me.txtTax.Name = "txtTax"
        Me.txtTax.Size = New System.Drawing.Size(113, 20)
        Me.txtTax.TabIndex = 40
        '
        'txtInvoiceFee
        '
        Me.txtInvoiceFee.AllowPromptAsInput = False
        Me.txtInvoiceFee.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceFee.Location = New System.Drawing.Point(288, 448)
        Me.txtInvoiceFee.Name = "txtInvoiceFee"
        Me.txtInvoiceFee.Size = New System.Drawing.Size(113, 20)
        Me.txtInvoiceFee.TabIndex = 39
        '
        'txtStoreFlatFee
        '
        Me.txtStoreFlatFee.AllowPromptAsInput = False
        Me.txtStoreFlatFee.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreFlatFee.Location = New System.Drawing.Point(288, 424)
        Me.txtStoreFlatFee.Name = "txtStoreFlatFee"
        Me.txtStoreFlatFee.Size = New System.Drawing.Size(113, 20)
        Me.txtStoreFlatFee.TabIndex = 38
        '
        'txtSavingsPercent
        '
        Me.txtSavingsPercent.AllowPromptAsInput = False
        Me.txtSavingsPercent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSavingsPercent.Location = New System.Drawing.Point(288, 400)
        Me.txtSavingsPercent.Name = "txtSavingsPercent"
        Me.txtSavingsPercent.Size = New System.Drawing.Size(113, 20)
        Me.txtSavingsPercent.TabIndex = 37
        '
        'txtSavings
        '
        Me.txtSavings.AllowPromptAsInput = False
        Me.txtSavings.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSavings.Location = New System.Drawing.Point(288, 376)
        Me.txtSavings.Name = "txtSavings"
        Me.txtSavings.Size = New System.Drawing.Size(113, 20)
        Me.txtSavings.TabIndex = 36
        '
        'txtInvoiceTotal
        '
        Me.txtInvoiceTotal.AllowPromptAsInput = False
        Me.txtInvoiceTotal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceTotal.Location = New System.Drawing.Point(288, 352)
        Me.txtInvoiceTotal.Name = "txtInvoiceTotal"
        Me.txtInvoiceTotal.Size = New System.Drawing.Size(113, 20)
        Me.txtInvoiceTotal.TabIndex = 35
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.AcceptsReturn = True
        Me.txtInvoiceNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtInvoiceNo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInvoiceNo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInvoiceNo.Location = New System.Drawing.Point(296, 184)
        Me.txtInvoiceNo.MaxLength = 0
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInvoiceNo.Size = New System.Drawing.Size(113, 20)
        Me.txtInvoiceNo.TabIndex = 17
        '
        'txtAccountNo
        '
        Me.txtAccountNo.AcceptsReturn = True
        Me.txtAccountNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtAccountNo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAccountNo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAccountNo.Location = New System.Drawing.Point(104, 184)
        Me.txtAccountNo.MaxLength = 0
        Me.txtAccountNo.Name = "txtAccountNo"
        Me.txtAccountNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAccountNo.Size = New System.Drawing.Size(113, 20)
        Me.txtAccountNo.TabIndex = 16
        '
        'txBillingPeriod
        '
        Me.txBillingPeriod.AcceptsReturn = True
        Me.txBillingPeriod.BackColor = System.Drawing.SystemColors.Window
        Me.txBillingPeriod.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txBillingPeriod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txBillingPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txBillingPeriod.Location = New System.Drawing.Point(104, 152)
        Me.txBillingPeriod.MaxLength = 0
        Me.txBillingPeriod.Name = "txBillingPeriod"
        Me.txBillingPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txBillingPeriod.Size = New System.Drawing.Size(225, 20)
        Me.txBillingPeriod.TabIndex = 13
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
        Me.txtInvoiceDate.TabIndex = 9
        '
        'txtAddress
        '
        Me.txtAddress.AcceptsReturn = True
        Me.txtAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAddress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAddress.Location = New System.Drawing.Point(104, 64)
        Me.txtAddress.MaxLength = 0
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAddress.Size = New System.Drawing.Size(297, 73)
        Me.txtAddress.TabIndex = 6
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(200, 336)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(73, 17)
        Me.Label19.TabIndex = 42
        Me.Label19.Text = "Show in Doc"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(6, 496)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(209, 20)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Grand Total..............................................."
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(6, 472)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(201, 17)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Tax............................................................"
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
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Label14"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(6, 448)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(212, 20)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Invoice Fee..............................................."
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(6, 424)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(209, 17)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Store Flat Fee............................................"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(6, 400)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(219, 24)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "GLM Charges(Savings Percent) ................"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(6, 376)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(209, 17)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Savings......................................................"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(6, 352)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(225, 17)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Bill Payment................................................"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(224, 184)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(73, 17)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "INVOICE NO:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(6, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(97, 17)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "ACCOUNT NO:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(2, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(96, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "For the month of"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(81, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Address"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(9, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(88, 30)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Invoice Date"
        '
        'cbCustId
        '
        Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustId.Location = New System.Drawing.Point(232, 48)
        Me.cbCustId.Name = "cbCustId"
        Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustId.Size = New System.Drawing.Size(73, 22)
        Me.cbCustId.TabIndex = 4
        Me.cbCustId.Visible = False
        '
        'cbCustName
        '
        Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustName.Location = New System.Drawing.Point(104, 88)
        Me.cbCustName.Name = "cbCustName"
        Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustName.Size = New System.Drawing.Size(201, 22)
        Me.cbCustName.TabIndex = 3
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(16, 208)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(57, 41)
        Me.Label18.TabIndex = 33
        Me.Label18.Text = "Template"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(16, 168)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(65, 40)
        Me.Label17.TabIndex = 31
        Me.Label17.Text = "Store Group"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(81, 40)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Invoicing Period"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(65, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Customer"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(65, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Invoice Date"
        '
        'dtInvoiceDate
        '
        Me.dtInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtInvoiceDate.Location = New System.Drawing.Point(104, 50)
        Me.dtInvoiceDate.Name = "dtInvoiceDate"
        Me.dtInvoiceDate.Size = New System.Drawing.Size(113, 20)
        Me.dtInvoiceDate.TabIndex = 54
        '
        'frmCustInvGen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(902, 590)
        Me.Controls.Add(Me.dtInvoiceDate)
        Me.Controls.Add(Me.cmdSelectedValues)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.VScroll1)
        Me.Controls.Add(Me.cbTemplate)
        Me.Controls.Add(Me.cbGroupStore)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdDisplayAmounts)
        Me.Controls.Add(Me.cmdBuildDoc)
        Me.Controls.Add(Me.cbPeriod)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cbCustId)
        Me.Controls.Add(Me.cbCustName)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(343, 208)
        Me.Name = "frmCustInvGen"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Customer Invoice Generation"
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtInvoiceDate As System.Windows.Forms.DateTimePicker
#End Region 
End Class