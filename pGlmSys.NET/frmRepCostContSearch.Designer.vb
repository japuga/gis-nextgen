<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRepCostContSearch
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
	Public WithEvents ckPrintFinal As System.Windows.Forms.CheckBox
	Public WithEvents ckGlmVendor As System.Windows.Forms.CheckBox
	Public WithEvents cbReportTemplateDesc As System.Windows.Forms.ComboBox
	Public WithEvents ckUseGlmRate As System.Windows.Forms.CheckBox
	Public WithEvents ckShowSavingsPercent As System.Windows.Forms.CheckBox
	Public WithEvents ckContractRange As System.Windows.Forms.CheckBox
	Public WithEvents ckDetailedCharges As System.Windows.Forms.CheckBox
	Public WithEvents txtReportName As System.Windows.Forms.TextBox
	Public WithEvents ckPublish As System.Windows.Forms.CheckBox
	Public WithEvents cbReportTemplate As System.Windows.Forms.ComboBox
	Public WithEvents txtReportCaption As System.Windows.Forms.TextBox
	Public WithEvents ckPrintStatus As System.Windows.Forms.CheckBox
	Public cdOpen As System.Windows.Forms.OpenFileDialog
	Public cdSave As System.Windows.Forms.SaveFileDialog
	Public cdFont As System.Windows.Forms.FontDialog
	Public cdColor As System.Windows.Forms.ColorDialog
	Public cdPrint As System.Windows.Forms.PrintDialog
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdOk As System.Windows.Forms.Button
    Public WithEvents cbPeriodName As System.Windows.Forms.ComboBox
    Public WithEvents obRange As System.Windows.Forms.RadioButton
    Public WithEvents obPeriod As System.Windows.Forms.RadioButton
    Public WithEvents lbEndDate As System.Windows.Forms.Label
    Public WithEvents lbStartDate As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents cbGroupName As System.Windows.Forms.ComboBox
    Public WithEvents cbStateId As System.Windows.Forms.ComboBox
    Public WithEvents cbCustId As System.Windows.Forms.ComboBox
    Public WithEvents cbCustName As System.Windows.Forms.ComboBox
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ckPrintFinal = New System.Windows.Forms.CheckBox()
        Me.ckGlmVendor = New System.Windows.Forms.CheckBox()
        Me.cbReportTemplateDesc = New System.Windows.Forms.ComboBox()
        Me.ckUseGlmRate = New System.Windows.Forms.CheckBox()
        Me.ckShowSavingsPercent = New System.Windows.Forms.CheckBox()
        Me.ckContractRange = New System.Windows.Forms.CheckBox()
        Me.ckDetailedCharges = New System.Windows.Forms.CheckBox()
        Me.txtReportName = New System.Windows.Forms.TextBox()
        Me.ckPublish = New System.Windows.Forms.CheckBox()
        Me.cbReportTemplate = New System.Windows.Forms.ComboBox()
        Me.txtReportCaption = New System.Windows.Forms.TextBox()
        Me.ckPrintStatus = New System.Windows.Forms.CheckBox()
        Me.cdOpen = New System.Windows.Forms.OpenFileDialog()
        Me.cdSave = New System.Windows.Forms.SaveFileDialog()
        Me.cdFont = New System.Windows.Forms.FontDialog()
        Me.cdColor = New System.Windows.Forms.ColorDialog()
        Me.cdPrint = New System.Windows.Forms.PrintDialog()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.dtEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtStartDate = New System.Windows.Forms.DateTimePicker()
        Me.cbPeriodName = New System.Windows.Forms.ComboBox()
        Me.obRange = New System.Windows.Forms.RadioButton()
        Me.obPeriod = New System.Windows.Forms.RadioButton()
        Me.lbEndDate = New System.Windows.Forms.Label()
        Me.lbStartDate = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbGroupName = New System.Windows.Forms.ComboBox()
        Me.cbStateId = New System.Windows.Forms.ComboBox()
        Me.cbCustId = New System.Windows.Forms.ComboBox()
        Me.cbCustName = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ckPeriodAsInvoice = New System.Windows.Forms.CheckBox()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ckPrintFinal
        '
        Me.ckPrintFinal.BackColor = System.Drawing.SystemColors.Control
        Me.ckPrintFinal.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckPrintFinal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPrintFinal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckPrintFinal.Location = New System.Drawing.Point(259, 391)
        Me.ckPrintFinal.Name = "ckPrintFinal"
        Me.ckPrintFinal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckPrintFinal.Size = New System.Drawing.Size(161, 25)
        Me.ckPrintFinal.TabIndex = 36
        Me.ckPrintFinal.Text = "Print Final Version"
        Me.ckPrintFinal.UseVisualStyleBackColor = False
        '
        'ckGlmVendor
        '
        Me.ckGlmVendor.BackColor = System.Drawing.SystemColors.Control
        Me.ckGlmVendor.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckGlmVendor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckGlmVendor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckGlmVendor.Location = New System.Drawing.Point(16, 483)
        Me.ckGlmVendor.Name = "ckGlmVendor"
        Me.ckGlmVendor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckGlmVendor.Size = New System.Drawing.Size(199, 25)
        Me.ckGlmVendor.TabIndex = 35
        Me.ckGlmVendor.Text = "Display GLM as vendor"
        Me.ckGlmVendor.UseVisualStyleBackColor = False
        '
        'cbReportTemplateDesc
        '
        Me.cbReportTemplateDesc.BackColor = System.Drawing.SystemColors.Window
        Me.cbReportTemplateDesc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbReportTemplateDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbReportTemplateDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbReportTemplateDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbReportTemplateDesc.Location = New System.Drawing.Point(303, 48)
        Me.cbReportTemplateDesc.Name = "cbReportTemplateDesc"
        Me.cbReportTemplateDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbReportTemplateDesc.Size = New System.Drawing.Size(257, 26)
        Me.cbReportTemplateDesc.TabIndex = 34
        '
        'ckUseGlmRate
        '
        Me.ckUseGlmRate.BackColor = System.Drawing.SystemColors.Control
        Me.ckUseGlmRate.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckUseGlmRate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckUseGlmRate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckUseGlmRate.Location = New System.Drawing.Point(16, 452)
        Me.ckUseGlmRate.Name = "ckUseGlmRate"
        Me.ckUseGlmRate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckUseGlmRate.Size = New System.Drawing.Size(145, 25)
        Me.ckUseGlmRate.TabIndex = 33
        Me.ckUseGlmRate.Text = "Use GLM Rate"
        Me.ckUseGlmRate.UseVisualStyleBackColor = False
        '
        'ckShowSavingsPercent
        '
        Me.ckShowSavingsPercent.BackColor = System.Drawing.SystemColors.Control
        Me.ckShowSavingsPercent.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckShowSavingsPercent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckShowSavingsPercent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckShowSavingsPercent.Location = New System.Drawing.Point(259, 360)
        Me.ckShowSavingsPercent.Name = "ckShowSavingsPercent"
        Me.ckShowSavingsPercent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckShowSavingsPercent.Size = New System.Drawing.Size(235, 25)
        Me.ckShowSavingsPercent.TabIndex = 32
        Me.ckShowSavingsPercent.Text = "Show Savings Percent Total"
        Me.ckShowSavingsPercent.UseVisualStyleBackColor = False
        '
        'ckContractRange
        '
        Me.ckContractRange.BackColor = System.Drawing.SystemColors.Control
        Me.ckContractRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckContractRange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckContractRange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckContractRange.Location = New System.Drawing.Point(16, 421)
        Me.ckContractRange.Name = "ckContractRange"
        Me.ckContractRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckContractRange.Size = New System.Drawing.Size(188, 25)
        Me.ckContractRange.TabIndex = 31
        Me.ckContractRange.Text = "Show Contract dates"
        Me.ckContractRange.UseVisualStyleBackColor = False
        '
        'ckDetailedCharges
        '
        Me.ckDetailedCharges.BackColor = System.Drawing.SystemColors.Control
        Me.ckDetailedCharges.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckDetailedCharges.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckDetailedCharges.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckDetailedCharges.Location = New System.Drawing.Point(16, 390)
        Me.ckDetailedCharges.Name = "ckDetailedCharges"
        Me.ckDetailedCharges.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckDetailedCharges.Size = New System.Drawing.Size(209, 25)
        Me.ckDetailedCharges.TabIndex = 30
        Me.ckDetailedCharges.Text = "Show Detailed Charges"
        Me.ckDetailedCharges.UseVisualStyleBackColor = False
        '
        'txtReportName
        '
        Me.txtReportName.AcceptsReturn = True
        Me.txtReportName.BackColor = System.Drawing.SystemColors.Window
        Me.txtReportName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReportName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReportName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReportName.Location = New System.Drawing.Point(331, 449)
        Me.txtReportName.MaxLength = 0
        Me.txtReportName.Name = "txtReportName"
        Me.txtReportName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReportName.Size = New System.Drawing.Size(201, 26)
        Me.txtReportName.TabIndex = 29
        '
        'ckPublish
        '
        Me.ckPublish.BackColor = System.Drawing.SystemColors.Control
        Me.ckPublish.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckPublish.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPublish.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckPublish.Location = New System.Drawing.Point(259, 418)
        Me.ckPublish.Name = "ckPublish"
        Me.ckPublish.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckPublish.Size = New System.Drawing.Size(161, 25)
        Me.ckPublish.TabIndex = 27
        Me.ckPublish.Text = "Publish to Web"
        Me.ckPublish.UseVisualStyleBackColor = False
        '
        'cbReportTemplate
        '
        Me.cbReportTemplate.BackColor = System.Drawing.SystemColors.Window
        Me.cbReportTemplate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbReportTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cbReportTemplate.Enabled = False
        Me.cbReportTemplate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbReportTemplate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbReportTemplate.Location = New System.Drawing.Point(296, 80)
        Me.cbReportTemplate.Name = "cbReportTemplate"
        Me.cbReportTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbReportTemplate.Size = New System.Drawing.Size(273, 21)
        Me.cbReportTemplate.TabIndex = 26
        Me.cbReportTemplate.Text = "cbReportTemplate"
        '
        'txtReportCaption
        '
        Me.txtReportCaption.AcceptsReturn = True
        Me.txtReportCaption.BackColor = System.Drawing.SystemColors.Window
        Me.txtReportCaption.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReportCaption.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReportCaption.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReportCaption.Location = New System.Drawing.Point(80, 80)
        Me.txtReportCaption.MaxLength = 0
        Me.txtReportCaption.Name = "txtReportCaption"
        Me.txtReportCaption.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReportCaption.Size = New System.Drawing.Size(209, 26)
        Me.txtReportCaption.TabIndex = 7
        '
        'ckPrintStatus
        '
        Me.ckPrintStatus.BackColor = System.Drawing.SystemColors.Control
        Me.ckPrintStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckPrintStatus.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPrintStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckPrintStatus.Location = New System.Drawing.Point(16, 360)
        Me.ckPrintStatus.Name = "ckPrintStatus"
        Me.ckPrintStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckPrintStatus.Size = New System.Drawing.Size(209, 25)
        Me.ckPrintStatus.TabIndex = 13
        Me.ckPrintStatus.Text = "Print Equipment Status"
        Me.ckPrintStatus.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(393, 505)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(101, 41)
        Me.cmdCancel.TabIndex = 18
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(262, 505)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(93, 41)
        Me.cmdOk.TabIndex = 17
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.ListView1)
        Me.Frame1.Controls.Add(Me.dtEndDate)
        Me.Frame1.Controls.Add(Me.dtStartDate)
        Me.Frame1.Controls.Add(Me.cbPeriodName)
        Me.Frame1.Controls.Add(Me.obRange)
        Me.Frame1.Controls.Add(Me.obPeriod)
        Me.Frame1.Controls.Add(Me.lbEndDate)
        Me.Frame1.Controls.Add(Me.lbStartDate)
        Me.Frame1.Controls.Add(Me.Label7)
        Me.Frame1.Controls.Add(Me.Label6)
        Me.Frame1.Controls.Add(Me.Label5)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(16, 152)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(728, 201)
        Me.Frame1.TabIndex = 8
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Period/Date"
        '
        'dtEndDate
        '
        Me.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEndDate.Location = New System.Drawing.Point(120, 159)
        Me.dtEndDate.Name = "dtEndDate"
        Me.dtEndDate.Size = New System.Drawing.Size(89, 26)
        Me.dtEndDate.TabIndex = 25
        '
        'dtStartDate
        '
        Me.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStartDate.Location = New System.Drawing.Point(120, 136)
        Me.dtStartDate.Name = "dtStartDate"
        Me.dtStartDate.Size = New System.Drawing.Size(89, 26)
        Me.dtStartDate.TabIndex = 24
        '
        'cbPeriodName
        '
        Me.cbPeriodName.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriodName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbPeriodName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriodName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbPeriodName.Location = New System.Drawing.Point(120, 32)
        Me.cbPeriodName.Name = "cbPeriodName"
        Me.cbPeriodName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbPeriodName.Size = New System.Drawing.Size(129, 26)
        Me.cbPeriodName.TabIndex = 11
        '
        'obRange
        '
        Me.obRange.BackColor = System.Drawing.SystemColors.Control
        Me.obRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.obRange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obRange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obRange.Location = New System.Drawing.Point(16, 112)
        Me.obRange.Name = "obRange"
        Me.obRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obRange.Size = New System.Drawing.Size(161, 17)
        Me.obRange.TabIndex = 10
        Me.obRange.TabStop = True
        Me.obRange.Text = "Invoices in Date Range"
        Me.obRange.UseVisualStyleBackColor = False
        '
        'obPeriod
        '
        Me.obPeriod.BackColor = System.Drawing.SystemColors.Control
        Me.obPeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.obPeriod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obPeriod.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obPeriod.Location = New System.Drawing.Point(16, 23)
        Me.obPeriod.Name = "obPeriod"
        Me.obPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obPeriod.Size = New System.Drawing.Size(98, 39)
        Me.obPeriod.TabIndex = 9
        Me.obPeriod.TabStop = True
        Me.obPeriod.Text = "Invoicing Period"
        Me.obPeriod.UseVisualStyleBackColor = False
        '
        'lbEndDate
        '
        Me.lbEndDate.BackColor = System.Drawing.SystemColors.Control
        Me.lbEndDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbEndDate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEndDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbEndDate.Location = New System.Drawing.Point(120, 88)
        Me.lbEndDate.Name = "lbEndDate"
        Me.lbEndDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbEndDate.Size = New System.Drawing.Size(113, 17)
        Me.lbEndDate.TabIndex = 23
        Me.lbEndDate.Text = "End"
        '
        'lbStartDate
        '
        Me.lbStartDate.BackColor = System.Drawing.SystemColors.Control
        Me.lbStartDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbStartDate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStartDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbStartDate.Location = New System.Drawing.Point(120, 64)
        Me.lbStartDate.Name = "lbStartDate"
        Me.lbStartDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbStartDate.Size = New System.Drawing.Size(89, 17)
        Me.lbStartDate.TabIndex = 22
        Me.lbStartDate.Text = "Start"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(80, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(33, 21)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "To"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(80, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(33, 17)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "From"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(54, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(59, 21)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "End Date"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(51, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(62, 21)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Start Date"
        '
        'cbGroupName
        '
        Me.cbGroupName.BackColor = System.Drawing.SystemColors.Window
        Me.cbGroupName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGroupName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGroupName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbGroupName.Location = New System.Drawing.Point(80, 48)
        Me.cbGroupName.Name = "cbGroupName"
        Me.cbGroupName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbGroupName.Size = New System.Drawing.Size(137, 26)
        Me.cbGroupName.TabIndex = 6
        '
        'cbStateId
        '
        Me.cbStateId.BackColor = System.Drawing.SystemColors.Window
        Me.cbStateId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbStateId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStateId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbStateId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbStateId.Location = New System.Drawing.Point(303, 15)
        Me.cbStateId.Name = "cbStateId"
        Me.cbStateId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbStateId.Size = New System.Drawing.Size(73, 26)
        Me.cbStateId.TabIndex = 4
        '
        'cbCustId
        '
        Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustId.Location = New System.Drawing.Point(176, 0)
        Me.cbCustId.Name = "cbCustId"
        Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustId.Size = New System.Drawing.Size(49, 26)
        Me.cbCustId.TabIndex = 2
        Me.cbCustId.Text = "Combo2"
        Me.cbCustId.Visible = False
        '
        'cbCustName
        '
        Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustName.Location = New System.Drawing.Point(78, 16)
        Me.cbCustName.Name = "cbCustName"
        Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustName.Size = New System.Drawing.Size(137, 26)
        Me.cbCustName.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(259, 449)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(65, 25)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Report Name"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(240, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(57, 17)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Template"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(49, 41)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Report Caption"
        '
        'label3
        '
        Me.label3.BackColor = System.Drawing.SystemColors.Control
        Me.label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label3.Location = New System.Drawing.Point(16, 48)
        Me.label3.Name = "label3"
        Me.label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label3.Size = New System.Drawing.Size(57, 32)
        Me.label3.TabIndex = 5
        Me.label3.Text = "Store Group"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(240, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(41, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "State"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer"
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(569, -39)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(121, 97)
        Me.ListView1.TabIndex = 37
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.Visible = False
        '
        'ckPeriodAsInvoice
        '
        Me.ckPeriodAsInvoice.BackColor = System.Drawing.SystemColors.Control
        Me.ckPeriodAsInvoice.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckPeriodAsInvoice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPeriodAsInvoice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckPeriodAsInvoice.Location = New System.Drawing.Point(533, 360)
        Me.ckPeriodAsInvoice.Name = "ckPeriodAsInvoice"
        Me.ckPeriodAsInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckPeriodAsInvoice.Size = New System.Drawing.Size(161, 25)
        Me.ckPeriodAsInvoice.TabIndex = 37
        Me.ckPeriodAsInvoice.Text = "Print Final Version"
        Me.ckPeriodAsInvoice.UseVisualStyleBackColor = False
        '
        'frmRepCostContSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(770, 575)
        Me.Controls.Add(Me.ckPeriodAsInvoice)
        Me.Controls.Add(Me.ckPrintFinal)
        Me.Controls.Add(Me.ckGlmVendor)
        Me.Controls.Add(Me.cbReportTemplateDesc)
        Me.Controls.Add(Me.ckUseGlmRate)
        Me.Controls.Add(Me.ckShowSavingsPercent)
        Me.Controls.Add(Me.ckContractRange)
        Me.Controls.Add(Me.ckDetailedCharges)
        Me.Controls.Add(Me.txtReportName)
        Me.Controls.Add(Me.ckPublish)
        Me.Controls.Add(Me.cbReportTemplate)
        Me.Controls.Add(Me.txtReportCaption)
        Me.Controls.Add(Me.ckPrintStatus)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cbGroupName)
        Me.Controls.Add(Me.cbStateId)
        Me.Controls.Add(Me.cbCustId)
        Me.Controls.Add(Me.cbCustName)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmRepCostContSearch"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cost Cont Report Selection Criteria"
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private Sub cbCustName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCustName.Click

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents dtEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStartDate As System.Windows.Forms.DateTimePicker
    Public WithEvents ckPeriodAsInvoice As System.Windows.Forms.CheckBox
End Class