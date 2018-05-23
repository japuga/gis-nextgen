<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRepScrapMetal3
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
	Public WithEvents txtReportCaption As System.Windows.Forms.TextBox
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents obRange As System.Windows.Forms.RadioButton
	Public WithEvents cbPeriodEnd As System.Windows.Forms.ComboBox
	Public WithEvents cbPeriodStart As System.Windows.Forms.ComboBox
	Public WithEvents obRangePeriod As System.Windows.Forms.RadioButton
	Public WithEvents obSinglePeriod As System.Windows.Forms.RadioButton
	Public WithEvents cbPeriodName As System.Windows.Forms.ComboBox
    Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents lbStartDate As System.Windows.Forms.Label
	Public WithEvents lbEndDate As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents lbPeriodStartDate As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents lbPeriodEndDate As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cbGroupName As System.Windows.Forms.ComboBox
	Public WithEvents cbStateId As System.Windows.Forms.ComboBox
	Public WithEvents cbReportTemplate As System.Windows.Forms.ComboBox
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtReportCaption = New System.Windows.Forms.TextBox
        Me.cbCustName = New System.Windows.Forms.ComboBox
        Me.cbCustId = New System.Windows.Forms.ComboBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.DataGrid1 = New System.Windows.Forms.DataGridView
        Me.dtEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtStartDate = New System.Windows.Forms.DateTimePicker
        Me.obRange = New System.Windows.Forms.RadioButton
        Me.cbPeriodEnd = New System.Windows.Forms.ComboBox
        Me.cbPeriodStart = New System.Windows.Forms.ComboBox
        Me.obRangePeriod = New System.Windows.Forms.RadioButton
        Me.obSinglePeriod = New System.Windows.Forms.RadioButton
        Me.cbPeriodName = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lbStartDate = New System.Windows.Forms.Label
        Me.lbEndDate = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lbPeriodStartDate = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lbPeriodEndDate = New System.Windows.Forms.Label
        Me.cbGroupName = New System.Windows.Forms.ComboBox
        Me.cbStateId = New System.Windows.Forms.ComboBox
        Me.cbReportTemplate = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Frame1.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtReportCaption
        '
        Me.txtReportCaption.AcceptsReturn = True
        Me.txtReportCaption.BackColor = System.Drawing.SystemColors.Window
        Me.txtReportCaption.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReportCaption.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReportCaption.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReportCaption.Location = New System.Drawing.Point(152, 112)
        Me.txtReportCaption.MaxLength = 0
        Me.txtReportCaption.Name = "txtReportCaption"
        Me.txtReportCaption.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReportCaption.Size = New System.Drawing.Size(249, 20)
        Me.txtReportCaption.TabIndex = 29
        '
        'cbCustName
        '
        Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustName.CausesValidation = False
        Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustName.Location = New System.Drawing.Point(112, 48)
        Me.cbCustName.Name = "cbCustName"
        Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustName.Size = New System.Drawing.Size(161, 22)
        Me.cbCustName.TabIndex = 28
        '
        'cbCustId
        '
        Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustId.Location = New System.Drawing.Point(456, 48)
        Me.cbCustId.Name = "cbCustId"
        Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustId.Size = New System.Drawing.Size(65, 22)
        Me.cbCustId.TabIndex = 27
        Me.cbCustId.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(321, 461)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 41)
        Me.cmdCancel.TabIndex = 26
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(233, 461)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(57, 41)
        Me.cmdOk.TabIndex = 25
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.DataGrid1)
        Me.Frame1.Controls.Add(Me.dtEndDate)
        Me.Frame1.Controls.Add(Me.dtStartDate)
        Me.Frame1.Controls.Add(Me.obRange)
        Me.Frame1.Controls.Add(Me.cbPeriodEnd)
        Me.Frame1.Controls.Add(Me.cbPeriodStart)
        Me.Frame1.Controls.Add(Me.obRangePeriod)
        Me.Frame1.Controls.Add(Me.obSinglePeriod)
        Me.Frame1.Controls.Add(Me.cbPeriodName)
        Me.Frame1.Controls.Add(Me.Label5)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.Label10)
        Me.Frame1.Controls.Add(Me.Label9)
        Me.Frame1.Controls.Add(Me.Label6)
        Me.Frame1.Controls.Add(Me.Label7)
        Me.Frame1.Controls.Add(Me.lbStartDate)
        Me.Frame1.Controls.Add(Me.lbEndDate)
        Me.Frame1.Controls.Add(Me.Label11)
        Me.Frame1.Controls.Add(Me.lbPeriodStartDate)
        Me.Frame1.Controls.Add(Me.Label13)
        Me.Frame1.Controls.Add(Me.lbPeriodEndDate)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(48, 144)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(505, 297)
        Me.Frame1.TabIndex = 3
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Period/Date Range"
        '
        'DataGrid1
        '
        Me.DataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGrid1.Location = New System.Drawing.Point(328, 34)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(169, 257)
        Me.DataGrid1.TabIndex = 27
        '
        'dtEndDate
        '
        Me.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEndDate.Location = New System.Drawing.Point(115, 256)
        Me.dtEndDate.Name = "dtEndDate"
        Me.dtEndDate.Size = New System.Drawing.Size(95, 20)
        Me.dtEndDate.TabIndex = 26
        '
        'dtStartDate
        '
        Me.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStartDate.Location = New System.Drawing.Point(115, 232)
        Me.dtStartDate.Name = "dtStartDate"
        Me.dtStartDate.Size = New System.Drawing.Size(95, 20)
        Me.dtStartDate.TabIndex = 25
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
        Me.obRange.TabIndex = 9
        Me.obRange.TabStop = True
        Me.obRange.Text = "Invoices in Date Range"
        Me.obRange.UseVisualStyleBackColor = False
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
        Me.cbPeriodEnd.TabIndex = 8
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
        Me.cbPeriodStart.TabIndex = 7
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
        Me.obRangePeriod.TabIndex = 6
        Me.obRangePeriod.TabStop = True
        Me.obRangePeriod.Text = "Period Range - Accumulated"
        Me.obRangePeriod.UseVisualStyleBackColor = False
        '
        'obSinglePeriod
        '
        Me.obSinglePeriod.BackColor = System.Drawing.SystemColors.Control
        Me.obSinglePeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.obSinglePeriod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obSinglePeriod.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obSinglePeriod.Location = New System.Drawing.Point(16, 19)
        Me.obSinglePeriod.Name = "obSinglePeriod"
        Me.obSinglePeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obSinglePeriod.Size = New System.Drawing.Size(106, 22)
        Me.obSinglePeriod.TabIndex = 5
        Me.obSinglePeriod.TabStop = True
        Me.obSinglePeriod.Text = "Single Period"
        Me.obSinglePeriod.UseVisualStyleBackColor = False
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
        Me.cbPeriodName.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(49, 255)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(60, 21)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "End Date"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(50, 232)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(63, 21)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Start Date"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(61, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(65, 22)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "To Period"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(61, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(65, 17)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "From Period"
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
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "From"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(185, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(32, 17)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "To"
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
        Me.lbStartDate.Size = New System.Drawing.Size(89, 17)
        Me.lbStartDate.TabIndex = 18
        Me.lbStartDate.Text = "Start"
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
        Me.lbEndDate.TabIndex = 17
        Me.lbEndDate.Text = "End"
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
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "From"
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
        Me.lbPeriodStartDate.TabIndex = 15
        Me.lbPeriodStartDate.Text = "Start"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(185, 176)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(25, 17)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "To"
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
        Me.lbPeriodEndDate.TabIndex = 13
        Me.lbPeriodEndDate.Text = "End"
        '
        'cbGroupName
        '
        Me.cbGroupName.BackColor = System.Drawing.SystemColors.Window
        Me.cbGroupName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGroupName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGroupName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbGroupName.Location = New System.Drawing.Point(112, 80)
        Me.cbGroupName.Name = "cbGroupName"
        Me.cbGroupName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbGroupName.Size = New System.Drawing.Size(137, 22)
        Me.cbGroupName.TabIndex = 2
        '
        'cbStateId
        '
        Me.cbStateId.BackColor = System.Drawing.SystemColors.Window
        Me.cbStateId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbStateId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStateId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbStateId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbStateId.Location = New System.Drawing.Point(376, 48)
        Me.cbStateId.Name = "cbStateId"
        Me.cbStateId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbStateId.Size = New System.Drawing.Size(73, 22)
        Me.cbStateId.TabIndex = 1
        '
        'cbReportTemplate
        '
        Me.cbReportTemplate.BackColor = System.Drawing.SystemColors.Window
        Me.cbReportTemplate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbReportTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbReportTemplate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbReportTemplate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbReportTemplate.Location = New System.Drawing.Point(376, 80)
        Me.cbReportTemplate.Name = "cbReportTemplate"
        Me.cbReportTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbReportTemplate.Size = New System.Drawing.Size(177, 22)
        Me.cbReportTemplate.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(56, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(81, 17)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Report Caption"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(48, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(57, 22)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Customer"
        '
        'label3
        '
        Me.label3.BackColor = System.Drawing.SystemColors.Control
        Me.label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label3.Location = New System.Drawing.Point(48, 80)
        Me.label3.Name = "label3"
        Me.label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label3.Size = New System.Drawing.Size(46, 22)
        Me.label3.TabIndex = 32
        Me.label3.Text = "Store Group"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(307, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(33, 17)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "State"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(307, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(62, 22)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Template"
        '
        'frmRepScrapMetal3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(601, 531)
        Me.Controls.Add(Me.txtReportCaption)
        Me.Controls.Add(Me.cbCustName)
        Me.Controls.Add(Me.cbCustId)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cbGroupName)
        Me.Controls.Add(Me.cbStateId)
        Me.Controls.Add(Me.cbReportTemplate)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label12)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmRepScrapMetal3"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Form1"
        Me.Frame1.ResumeLayout(False)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGridView
#End Region 
End Class