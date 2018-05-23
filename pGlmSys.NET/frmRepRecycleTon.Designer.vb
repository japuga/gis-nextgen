<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRepRecycleTon
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
	Public WithEvents cbReportTemplate As System.Windows.Forms.ComboBox
	Public WithEvents obDetail As System.Windows.Forms.RadioButton
	Public WithEvents obSummary As System.Windows.Forms.RadioButton
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents cbStateId As System.Windows.Forms.ComboBox
	Public WithEvents cbGroupName As System.Windows.Forms.ComboBox
    Public WithEvents cbPeriodName As System.Windows.Forms.ComboBox
	Public WithEvents obSinglePeriod As System.Windows.Forms.RadioButton
	Public WithEvents obRangePeriod As System.Windows.Forms.RadioButton
	Public WithEvents cbPeriodStart As System.Windows.Forms.ComboBox
	Public WithEvents cbPeriodEnd As System.Windows.Forms.ComboBox
	Public WithEvents obRange As System.Windows.Forms.RadioButton
    Public WithEvents lbPeriodEndDate As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents lbPeriodStartDate As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents lbEndDate As System.Windows.Forms.Label
	Public WithEvents lbStartDate As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
	Public WithEvents txtReportCaption As System.Windows.Forms.TextBox
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents label3 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbReportTemplate = New System.Windows.Forms.ComboBox
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.obDetail = New System.Windows.Forms.RadioButton
        Me.obSummary = New System.Windows.Forms.RadioButton
        Me.cbStateId = New System.Windows.Forms.ComboBox
        Me.cbGroupName = New System.Windows.Forms.ComboBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.DataGrid1 = New System.Windows.Forms.DataGridView
        Me.dtEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtStartDate = New System.Windows.Forms.DateTimePicker
        Me.cbPeriodName = New System.Windows.Forms.ComboBox
        Me.obSinglePeriod = New System.Windows.Forms.RadioButton
        Me.obRangePeriod = New System.Windows.Forms.RadioButton
        Me.cbPeriodStart = New System.Windows.Forms.ComboBox
        Me.cbPeriodEnd = New System.Windows.Forms.ComboBox
        Me.obRange = New System.Windows.Forms.RadioButton
        Me.lbPeriodEndDate = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lbPeriodStartDate = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lbEndDate = New System.Windows.Forms.Label
        Me.lbStartDate = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cbCustId = New System.Windows.Forms.ComboBox
        Me.cbCustName = New System.Windows.Forms.ComboBox
        Me.txtReportCaption = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbReportTemplate
        '
        Me.cbReportTemplate.BackColor = System.Drawing.SystemColors.Window
        Me.cbReportTemplate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbReportTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbReportTemplate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbReportTemplate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbReportTemplate.Location = New System.Drawing.Point(352, 128)
        Me.cbReportTemplate.Name = "cbReportTemplate"
        Me.cbReportTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbReportTemplate.Size = New System.Drawing.Size(177, 22)
        Me.cbReportTemplate.TabIndex = 37
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.obDetail)
        Me.Frame2.Controls.Add(Me.obSummary)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(32, 8)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(217, 81)
        Me.Frame2.TabIndex = 32
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Report Type"
        '
        'obDetail
        '
        Me.obDetail.BackColor = System.Drawing.SystemColors.Control
        Me.obDetail.Cursor = System.Windows.Forms.Cursors.Default
        Me.obDetail.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obDetail.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obDetail.Location = New System.Drawing.Point(24, 48)
        Me.obDetail.Name = "obDetail"
        Me.obDetail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obDetail.Size = New System.Drawing.Size(105, 17)
        Me.obDetail.TabIndex = 34
        Me.obDetail.TabStop = True
        Me.obDetail.Text = "Detail"
        Me.obDetail.UseVisualStyleBackColor = False
        '
        'obSummary
        '
        Me.obSummary.BackColor = System.Drawing.SystemColors.Control
        Me.obSummary.Cursor = System.Windows.Forms.Cursors.Default
        Me.obSummary.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obSummary.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obSummary.Location = New System.Drawing.Point(24, 24)
        Me.obSummary.Name = "obSummary"
        Me.obSummary.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obSummary.Size = New System.Drawing.Size(97, 17)
        Me.obSummary.TabIndex = 33
        Me.obSummary.TabStop = True
        Me.obSummary.Text = "Summary"
        Me.obSummary.UseVisualStyleBackColor = False
        '
        'cbStateId
        '
        Me.cbStateId.BackColor = System.Drawing.SystemColors.Window
        Me.cbStateId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbStateId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStateId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbStateId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbStateId.Location = New System.Drawing.Point(352, 96)
        Me.cbStateId.Name = "cbStateId"
        Me.cbStateId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbStateId.Size = New System.Drawing.Size(73, 22)
        Me.cbStateId.TabIndex = 12
        '
        'cbGroupName
        '
        Me.cbGroupName.BackColor = System.Drawing.SystemColors.Window
        Me.cbGroupName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGroupName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGroupName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbGroupName.Location = New System.Drawing.Point(88, 128)
        Me.cbGroupName.Name = "cbGroupName"
        Me.cbGroupName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbGroupName.Size = New System.Drawing.Size(137, 22)
        Me.cbGroupName.TabIndex = 11
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.DataGrid1)
        Me.Frame1.Controls.Add(Me.dtEndDate)
        Me.Frame1.Controls.Add(Me.dtStartDate)
        Me.Frame1.Controls.Add(Me.cbPeriodName)
        Me.Frame1.Controls.Add(Me.obSinglePeriod)
        Me.Frame1.Controls.Add(Me.obRangePeriod)
        Me.Frame1.Controls.Add(Me.cbPeriodStart)
        Me.Frame1.Controls.Add(Me.cbPeriodEnd)
        Me.Frame1.Controls.Add(Me.obRange)
        Me.Frame1.Controls.Add(Me.lbPeriodEndDate)
        Me.Frame1.Controls.Add(Me.Label13)
        Me.Frame1.Controls.Add(Me.lbPeriodStartDate)
        Me.Frame1.Controls.Add(Me.Label11)
        Me.Frame1.Controls.Add(Me.lbEndDate)
        Me.Frame1.Controls.Add(Me.lbStartDate)
        Me.Frame1.Controls.Add(Me.Label7)
        Me.Frame1.Controls.Add(Me.Label6)
        Me.Frame1.Controls.Add(Me.Label9)
        Me.Frame1.Controls.Add(Me.Label10)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.Label5)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(24, 192)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(505, 297)
        Me.Frame1.TabIndex = 5
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Period/Date Range"
        '
        'DataGrid1
        '
        Me.DataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGrid1.Location = New System.Drawing.Point(320, 32)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(169, 257)
        Me.DataGrid1.TabIndex = 38
        '
        'dtEndDate
        '
        Me.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEndDate.Location = New System.Drawing.Point(108, 254)
        Me.dtEndDate.Name = "dtEndDate"
        Me.dtEndDate.Size = New System.Drawing.Size(88, 20)
        Me.dtEndDate.TabIndex = 37
        '
        'dtStartDate
        '
        Me.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStartDate.Location = New System.Drawing.Point(107, 231)
        Me.dtStartDate.Name = "dtStartDate"
        Me.dtStartDate.Size = New System.Drawing.Size(89, 20)
        Me.dtStartDate.TabIndex = 36
        '
        'cbPeriodName
        '
        Me.cbPeriodName.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriodName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbPeriodName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriodName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbPeriodName.Location = New System.Drawing.Point(128, 24)
        Me.cbPeriodName.Name = "cbPeriodName"
        Me.cbPeriodName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbPeriodName.Size = New System.Drawing.Size(177, 22)
        Me.cbPeriodName.TabIndex = 21
        '
        'obSinglePeriod
        '
        Me.obSinglePeriod.BackColor = System.Drawing.SystemColors.Control
        Me.obSinglePeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.obSinglePeriod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obSinglePeriod.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obSinglePeriod.Location = New System.Drawing.Point(16, 24)
        Me.obSinglePeriod.Name = "obSinglePeriod"
        Me.obSinglePeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obSinglePeriod.Size = New System.Drawing.Size(113, 17)
        Me.obSinglePeriod.TabIndex = 20
        Me.obSinglePeriod.TabStop = True
        Me.obSinglePeriod.Text = "Single Period"
        Me.obSinglePeriod.UseVisualStyleBackColor = False
        '
        'obRangePeriod
        '
        Me.obRangePeriod.BackColor = System.Drawing.SystemColors.Control
        Me.obRangePeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.obRangePeriod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obRangePeriod.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obRangePeriod.Location = New System.Drawing.Point(16, 88)
        Me.obRangePeriod.Name = "obRangePeriod"
        Me.obRangePeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obRangePeriod.Size = New System.Drawing.Size(289, 17)
        Me.obRangePeriod.TabIndex = 19
        Me.obRangePeriod.TabStop = True
        Me.obRangePeriod.Text = "Period Range - Accumulated"
        Me.obRangePeriod.UseVisualStyleBackColor = False
        '
        'cbPeriodStart
        '
        Me.cbPeriodStart.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriodStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbPeriodStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodStart.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriodStart.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbPeriodStart.Location = New System.Drawing.Point(128, 112)
        Me.cbPeriodStart.Name = "cbPeriodStart"
        Me.cbPeriodStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbPeriodStart.Size = New System.Drawing.Size(145, 22)
        Me.cbPeriodStart.TabIndex = 18
        '
        'cbPeriodEnd
        '
        Me.cbPeriodEnd.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriodEnd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbPeriodEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodEnd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriodEnd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbPeriodEnd.Location = New System.Drawing.Point(128, 144)
        Me.cbPeriodEnd.Name = "cbPeriodEnd"
        Me.cbPeriodEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbPeriodEnd.Size = New System.Drawing.Size(145, 22)
        Me.cbPeriodEnd.TabIndex = 17
        '
        'obRange
        '
        Me.obRange.BackColor = System.Drawing.SystemColors.Control
        Me.obRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.obRange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obRange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obRange.Location = New System.Drawing.Point(16, 208)
        Me.obRange.Name = "obRange"
        Me.obRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obRange.Size = New System.Drawing.Size(161, 17)
        Me.obRange.TabIndex = 6
        Me.obRange.TabStop = True
        Me.obRange.Text = "Invoices in Date Range"
        Me.obRange.UseVisualStyleBackColor = False
        '
        'lbPeriodEndDate
        '
        Me.lbPeriodEndDate.BackColor = System.Drawing.SystemColors.Control
        Me.lbPeriodEndDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbPeriodEndDate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPeriodEndDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbPeriodEndDate.Location = New System.Drawing.Point(224, 176)
        Me.lbPeriodEndDate.Name = "lbPeriodEndDate"
        Me.lbPeriodEndDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbPeriodEndDate.Size = New System.Drawing.Size(81, 17)
        Me.lbPeriodEndDate.TabIndex = 31
        Me.lbPeriodEndDate.Text = "End"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(200, 176)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(25, 17)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "To"
        '
        'lbPeriodStartDate
        '
        Me.lbPeriodStartDate.BackColor = System.Drawing.SystemColors.Control
        Me.lbPeriodStartDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbPeriodStartDate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPeriodStartDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbPeriodStartDate.Location = New System.Drawing.Point(112, 176)
        Me.lbPeriodStartDate.Name = "lbPeriodStartDate"
        Me.lbPeriodStartDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbPeriodStartDate.Size = New System.Drawing.Size(73, 17)
        Me.lbPeriodStartDate.TabIndex = 29
        Me.lbPeriodStartDate.Text = "Start"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(64, 176)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(33, 17)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "From"
        '
        'lbEndDate
        '
        Me.lbEndDate.BackColor = System.Drawing.SystemColors.Control
        Me.lbEndDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbEndDate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEndDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbEndDate.Location = New System.Drawing.Point(232, 56)
        Me.lbEndDate.Name = "lbEndDate"
        Me.lbEndDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbEndDate.Size = New System.Drawing.Size(113, 17)
        Me.lbEndDate.TabIndex = 27
        Me.lbEndDate.Text = "End"
        '
        'lbStartDate
        '
        Me.lbStartDate.BackColor = System.Drawing.SystemColors.Control
        Me.lbStartDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbStartDate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStartDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbStartDate.Location = New System.Drawing.Point(104, 56)
        Me.lbStartDate.Name = "lbStartDate"
        Me.lbStartDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbStartDate.Size = New System.Drawing.Size(89, 29)
        Me.lbStartDate.TabIndex = 26
        Me.lbStartDate.Text = "Start"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(200, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(25, 17)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "To"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(64, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(33, 17)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "From"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(48, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(81, 22)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "From Period"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(51, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(86, 22)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "To Period"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(51, 232)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(62, 21)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Start Date"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(51, 256)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(62, 21)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "End Date"
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(216, 504)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(57, 41)
        Me.cmdOk.TabIndex = 4
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(304, 504)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 41)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cbCustId
        '
        Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustId.Location = New System.Drawing.Point(432, 96)
        Me.cbCustId.Name = "cbCustId"
        Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustId.Size = New System.Drawing.Size(65, 22)
        Me.cbCustId.TabIndex = 2
        Me.cbCustId.Visible = False
        '
        'cbCustName
        '
        Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustName.Location = New System.Drawing.Point(88, 96)
        Me.cbCustName.Name = "cbCustName"
        Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustName.Size = New System.Drawing.Size(161, 22)
        Me.cbCustName.TabIndex = 1
        '
        'txtReportCaption
        '
        Me.txtReportCaption.AcceptsReturn = True
        Me.txtReportCaption.BackColor = System.Drawing.SystemColors.Window
        Me.txtReportCaption.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReportCaption.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReportCaption.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReportCaption.Location = New System.Drawing.Point(128, 160)
        Me.txtReportCaption.MaxLength = 0
        Me.txtReportCaption.Name = "txtReportCaption"
        Me.txtReportCaption.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReportCaption.Size = New System.Drawing.Size(249, 20)
        Me.txtReportCaption.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(296, 128)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(49, 17)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "Template"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(296, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(33, 17)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "State"
        '
        'label3
        '
        Me.label3.BackColor = System.Drawing.SystemColors.Control
        Me.label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label3.Location = New System.Drawing.Point(24, 120)
        Me.label3.Name = "label3"
        Me.label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label3.Size = New System.Drawing.Size(49, 40)
        Me.label3.TabIndex = 15
        Me.label3.Text = "Store Group"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Customer"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(32, 160)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(81, 17)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Report Caption"
        '
        'DirectorySearcher1
        '
        Me.DirectorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01")
        '
        'frmRepRecycleTon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(558, 562)
        Me.Controls.Add(Me.cbReportTemplate)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.cbStateId)
        Me.Controls.Add(Me.cbGroupName)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cbCustId)
        Me.Controls.Add(Me.cbCustName)
        Me.Controls.Add(Me.txtReportCaption)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmRepRecycleTon"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Recycle Tonnage Report Selection Criteria"
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGridView
    Friend WithEvents DirectorySearcher1 As System.DirectoryServices.DirectorySearcher
#End Region 
End Class