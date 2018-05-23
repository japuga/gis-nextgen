<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmExportCheck
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
	Public WithEvents chExported As System.Windows.Forms.CheckBox
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents cbVendor As System.Windows.Forms.ComboBox
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents frVendor As System.Windows.Forms.GroupBox
	Public WithEvents cbBankAccount As System.Windows.Forms.ComboBox
	Public WithEvents cbBankName As System.Windows.Forms.ComboBox
	Public WithEvents txtCheckTo As System.Windows.Forms.TextBox
	Public WithEvents txtCheckFrom As System.Windows.Forms.TextBox
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents frCheckRange As System.Windows.Forms.GroupBox
    Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents frDateRange As System.Windows.Forms.GroupBox
	Public WithEvents radioVendor As System.Windows.Forms.RadioButton
	Public WithEvents radioCheckRange As System.Windows.Forms.RadioButton
	Public WithEvents radioDateRange As System.Windows.Forms.RadioButton
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents Label6 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chExported = New System.Windows.Forms.CheckBox
        Me.cbCustId = New System.Windows.Forms.ComboBox
        Me.cbCustName = New System.Windows.Forms.ComboBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.frVendor = New System.Windows.Forms.GroupBox
        Me.cbVendor = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.frCheckRange = New System.Windows.Forms.GroupBox
        Me.cbBankAccount = New System.Windows.Forms.ComboBox
        Me.cbBankName = New System.Windows.Forms.ComboBox
        Me.txtCheckTo = New System.Windows.Forms.TextBox
        Me.txtCheckFrom = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.frDateRange = New System.Windows.Forms.GroupBox
        Me.dtTo = New System.Windows.Forms.DateTimePicker
        Me.dtFrom = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.radioVendor = New System.Windows.Forms.RadioButton
        Me.radioCheckRange = New System.Windows.Forms.RadioButton
        Me.radioDateRange = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.Frame1.SuspendLayout()
        Me.frVendor.SuspendLayout()
        Me.frCheckRange.SuspendLayout()
        Me.frDateRange.SuspendLayout()
        Me.SuspendLayout()
        '
        'chExported
        '
        Me.chExported.BackColor = System.Drawing.SystemColors.Control
        Me.chExported.Cursor = System.Windows.Forms.Cursors.Default
        Me.chExported.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chExported.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chExported.Location = New System.Drawing.Point(136, 48)
        Me.chExported.Name = "chExported"
        Me.chExported.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chExported.Size = New System.Drawing.Size(233, 17)
        Me.chExported.TabIndex = 22
        Me.chExported.Text = "Show already extracted Checks"
        Me.chExported.UseVisualStyleBackColor = False
        '
        'cbCustId
        '
        Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustId.Location = New System.Drawing.Point(336, 16)
        Me.cbCustId.Name = "cbCustId"
        Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustId.Size = New System.Drawing.Size(57, 22)
        Me.cbCustId.TabIndex = 21
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
        Me.cbCustName.Location = New System.Drawing.Point(136, 16)
        Me.cbCustName.Name = "cbCustName"
        Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustName.Size = New System.Drawing.Size(193, 22)
        Me.cbCustName.TabIndex = 20
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.cmdCancel)
        Me.Frame1.Controls.Add(Me.cmdOk)
        Me.Frame1.Controls.Add(Me.frVendor)
        Me.Frame1.Controls.Add(Me.frCheckRange)
        Me.Frame1.Controls.Add(Me.frDateRange)
        Me.Frame1.Controls.Add(Me.radioVendor)
        Me.Frame1.Controls.Add(Me.radioCheckRange)
        Me.Frame1.Controls.Add(Me.radioDateRange)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(24, 72)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(369, 457)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Choose Criteria"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(200, 416)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 33)
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
        Me.cmdOk.Location = New System.Drawing.Point(104, 416)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(57, 33)
        Me.cmdOk.TabIndex = 7
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'frVendor
        '
        Me.frVendor.BackColor = System.Drawing.SystemColors.Control
        Me.frVendor.Controls.Add(Me.cbVendor)
        Me.frVendor.Controls.Add(Me.Label5)
        Me.frVendor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frVendor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frVendor.Location = New System.Drawing.Point(32, 360)
        Me.frVendor.Name = "frVendor"
        Me.frVendor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frVendor.Size = New System.Drawing.Size(297, 49)
        Me.frVendor.TabIndex = 6
        Me.frVendor.TabStop = False
        '
        'cbVendor
        '
        Me.cbVendor.BackColor = System.Drawing.SystemColors.Window
        Me.cbVendor.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVendor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVendor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbVendor.Location = New System.Drawing.Point(56, 16)
        Me.cbVendor.Name = "cbVendor"
        Me.cbVendor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbVendor.Size = New System.Drawing.Size(233, 22)
        Me.cbVendor.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(43, 22)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Name"
        '
        'frCheckRange
        '
        Me.frCheckRange.BackColor = System.Drawing.SystemColors.Control
        Me.frCheckRange.Controls.Add(Me.cbBankAccount)
        Me.frCheckRange.Controls.Add(Me.cbBankName)
        Me.frCheckRange.Controls.Add(Me.txtCheckTo)
        Me.frCheckRange.Controls.Add(Me.txtCheckFrom)
        Me.frCheckRange.Controls.Add(Me.Label8)
        Me.frCheckRange.Controls.Add(Me.Label7)
        Me.frCheckRange.Controls.Add(Me.Label4)
        Me.frCheckRange.Controls.Add(Me.Label3)
        Me.frCheckRange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frCheckRange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frCheckRange.Location = New System.Drawing.Point(32, 176)
        Me.frCheckRange.Name = "frCheckRange"
        Me.frCheckRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frCheckRange.Size = New System.Drawing.Size(297, 153)
        Me.frCheckRange.TabIndex = 5
        Me.frCheckRange.TabStop = False
        '
        'cbBankAccount
        '
        Me.cbBankAccount.BackColor = System.Drawing.SystemColors.Window
        Me.cbBankAccount.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbBankAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBankAccount.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBankAccount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbBankAccount.Location = New System.Drawing.Point(80, 48)
        Me.cbBankAccount.Name = "cbBankAccount"
        Me.cbBankAccount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbBankAccount.Size = New System.Drawing.Size(145, 22)
        Me.cbBankAccount.TabIndex = 26
        '
        'cbBankName
        '
        Me.cbBankName.BackColor = System.Drawing.SystemColors.Window
        Me.cbBankName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBankName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBankName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbBankName.Location = New System.Drawing.Point(80, 16)
        Me.cbBankName.Name = "cbBankName"
        Me.cbBankName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbBankName.Size = New System.Drawing.Size(121, 22)
        Me.cbBankName.TabIndex = 25
        '
        'txtCheckTo
        '
        Me.txtCheckTo.AcceptsReturn = True
        Me.txtCheckTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtCheckTo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCheckTo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheckTo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCheckTo.Location = New System.Drawing.Point(144, 120)
        Me.txtCheckTo.MaxLength = 10
        Me.txtCheckTo.Name = "txtCheckTo"
        Me.txtCheckTo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCheckTo.Size = New System.Drawing.Size(73, 20)
        Me.txtCheckTo.TabIndex = 16
        '
        'txtCheckFrom
        '
        Me.txtCheckFrom.AcceptsReturn = True
        Me.txtCheckFrom.BackColor = System.Drawing.SystemColors.Window
        Me.txtCheckFrom.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCheckFrom.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheckFrom.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCheckFrom.Location = New System.Drawing.Point(144, 88)
        Me.txtCheckFrom.MaxLength = 10
        Me.txtCheckFrom.Name = "txtCheckFrom"
        Me.txtCheckFrom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCheckFrom.Size = New System.Drawing.Size(73, 20)
        Me.txtCheckFrom.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(49, 17)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Account"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(49, 17)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Bank"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(80, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "To Check"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(80, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "From Check"
        '
        'frDateRange
        '
        Me.frDateRange.BackColor = System.Drawing.SystemColors.Control
        Me.frDateRange.Controls.Add(Me.dtTo)
        Me.frDateRange.Controls.Add(Me.dtFrom)
        Me.frDateRange.Controls.Add(Me.Label2)
        Me.frDateRange.Controls.Add(Me.Label1)
        Me.frDateRange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frDateRange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frDateRange.Location = New System.Drawing.Point(32, 48)
        Me.frDateRange.Name = "frDateRange"
        Me.frDateRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frDateRange.Size = New System.Drawing.Size(297, 97)
        Me.frDateRange.TabIndex = 4
        Me.frDateRange.TabStop = False
        '
        'dtTo
        '
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(56, 56)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(94, 20)
        Me.dtTo.TabIndex = 14
        '
        'dtFrom
        '
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.Location = New System.Drawing.Point(56, 19)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(94, 20)
        Me.dtFrom.TabIndex = 13
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
        Me.Label2.Size = New System.Drawing.Size(25, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "To"
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
        Me.Label1.Size = New System.Drawing.Size(33, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "From"
        '
        'radioVendor
        '
        Me.radioVendor.BackColor = System.Drawing.SystemColors.Control
        Me.radioVendor.Cursor = System.Windows.Forms.Cursors.Default
        Me.radioVendor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radioVendor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radioVendor.Location = New System.Drawing.Point(16, 336)
        Me.radioVendor.Name = "radioVendor"
        Me.radioVendor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radioVendor.Size = New System.Drawing.Size(65, 25)
        Me.radioVendor.TabIndex = 3
        Me.radioVendor.TabStop = True
        Me.radioVendor.Text = "Vendor"
        Me.radioVendor.UseVisualStyleBackColor = False
        '
        'radioCheckRange
        '
        Me.radioCheckRange.BackColor = System.Drawing.SystemColors.Control
        Me.radioCheckRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.radioCheckRange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radioCheckRange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radioCheckRange.Location = New System.Drawing.Point(16, 152)
        Me.radioCheckRange.Name = "radioCheckRange"
        Me.radioCheckRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radioCheckRange.Size = New System.Drawing.Size(134, 33)
        Me.radioCheckRange.TabIndex = 2
        Me.radioCheckRange.TabStop = True
        Me.radioCheckRange.Text = "Check Number Range"
        Me.radioCheckRange.UseVisualStyleBackColor = False
        '
        'radioDateRange
        '
        Me.radioDateRange.BackColor = System.Drawing.SystemColors.Control
        Me.radioDateRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.radioDateRange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radioDateRange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radioDateRange.Location = New System.Drawing.Point(16, 24)
        Me.radioDateRange.Name = "radioDateRange"
        Me.radioDateRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radioDateRange.Size = New System.Drawing.Size(289, 25)
        Me.radioDateRange.TabIndex = 1
        Me.radioDateRange.TabStop = True
        Me.radioDateRange.Text = "Checks Date Range"
        Me.radioDateRange.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(32, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(81, 17)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Customer"
        '
        'frmExportCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(430, 543)
        Me.Controls.Add(Me.chExported)
        Me.Controls.Add(Me.cbCustId)
        Me.Controls.Add(Me.cbCustName)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Label6)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmExportCheck"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Check Selection Criteria"
        Me.Frame1.ResumeLayout(False)
        Me.frVendor.ResumeLayout(False)
        Me.frCheckRange.ResumeLayout(False)
        Me.frCheckRange.PerformLayout()
        Me.frDateRange.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
#End Region 
End Class