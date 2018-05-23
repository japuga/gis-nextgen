<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCheckBrowse
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
	Public WithEvents txtToCheck As System.Windows.Forms.TextBox
	Public WithEvents txtFromCheck As System.Windows.Forms.TextBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents frChecks As System.Windows.Forms.GroupBox
	Public WithEvents chCheckRange As System.Windows.Forms.CheckBox
	Public WithEvents chDates As System.Windows.Forms.CheckBox
    Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents frDates As System.Windows.Forms.GroupBox
	Public WithEvents cbBankAccount As System.Windows.Forms.ComboBox
	Public WithEvents cbBank As System.Windows.Forms.ComboBox
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdSearch As System.Windows.Forms.Button
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
	Public WithEvents cbVendor As System.Windows.Forms.ComboBox
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents label2 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.frChecks = New System.Windows.Forms.GroupBox
        Me.txtToCheck = New System.Windows.Forms.TextBox
        Me.txtFromCheck = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.chCheckRange = New System.Windows.Forms.CheckBox
        Me.chDates = New System.Windows.Forms.CheckBox
        Me.frDates = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbBankAccount = New System.Windows.Forms.ComboBox
        Me.cbBank = New System.Windows.Forms.ComboBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.cbCustName = New System.Windows.Forms.ComboBox
        Me.cbVendor = New System.Windows.Forms.ComboBox
        Me.cbCustId = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtStart = New System.Windows.Forms.DateTimePicker
        Me.dtEnd = New System.Windows.Forms.DateTimePicker
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.frChecks.SuspendLayout()
        Me.frDates.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Info
        Me.Frame1.Controls.Add(Me.Frame2)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(24, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(385, 457)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Search Criteria"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Window
        Me.Frame2.Controls.Add(Me.frChecks)
        Me.Frame2.Controls.Add(Me.chCheckRange)
        Me.Frame2.Controls.Add(Me.chDates)
        Me.Frame2.Controls.Add(Me.frDates)
        Me.Frame2.Controls.Add(Me.cbBankAccount)
        Me.Frame2.Controls.Add(Me.cbBank)
        Me.Frame2.Controls.Add(Me.cmdClose)
        Me.Frame2.Controls.Add(Me.cmdSearch)
        Me.Frame2.Controls.Add(Me.cbCustName)
        Me.Frame2.Controls.Add(Me.cbVendor)
        Me.Frame2.Controls.Add(Me.cbCustId)
        Me.Frame2.Controls.Add(Me.Label4)
        Me.Frame2.Controls.Add(Me.label2)
        Me.Frame2.Controls.Add(Me.Label6)
        Me.Frame2.Controls.Add(Me.Label5)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Frame2.Location = New System.Drawing.Point(16, 16)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(353, 425)
        Me.Frame2.TabIndex = 1
        Me.Frame2.TabStop = False
        '
        'frChecks
        '
        Me.frChecks.BackColor = System.Drawing.Color.White
        Me.frChecks.Controls.Add(Me.txtToCheck)
        Me.frChecks.Controls.Add(Me.txtFromCheck)
        Me.frChecks.Controls.Add(Me.Label3)
        Me.frChecks.Controls.Add(Me.Label1)
        Me.frChecks.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frChecks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frChecks.Location = New System.Drawing.Point(80, 184)
        Me.frChecks.Name = "frChecks"
        Me.frChecks.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frChecks.Size = New System.Drawing.Size(225, 81)
        Me.frChecks.TabIndex = 20
        Me.frChecks.TabStop = False
        '
        'txtToCheck
        '
        Me.txtToCheck.AcceptsReturn = True
        Me.txtToCheck.BackColor = System.Drawing.SystemColors.Window
        Me.txtToCheck.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtToCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToCheck.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtToCheck.Location = New System.Drawing.Point(56, 48)
        Me.txtToCheck.MaxLength = 0
        Me.txtToCheck.Name = "txtToCheck"
        Me.txtToCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtToCheck.Size = New System.Drawing.Size(89, 21)
        Me.txtToCheck.TabIndex = 24
        '
        'txtFromCheck
        '
        Me.txtFromCheck.AcceptsReturn = True
        Me.txtFromCheck.BackColor = System.Drawing.SystemColors.Window
        Me.txtFromCheck.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFromCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFromCheck.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFromCheck.Location = New System.Drawing.Point(56, 16)
        Me.txtFromCheck.MaxLength = 0
        Me.txtFromCheck.Name = "txtFromCheck"
        Me.txtFromCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFromCheck.Size = New System.Drawing.Size(89, 21)
        Me.txtFromCheck.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(33, 17)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "To #"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(49, 21)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "From #"
        '
        'chCheckRange
        '
        Me.chCheckRange.BackColor = System.Drawing.Color.White
        Me.chCheckRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.chCheckRange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chCheckRange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chCheckRange.Location = New System.Drawing.Point(32, 168)
        Me.chCheckRange.Name = "chCheckRange"
        Me.chCheckRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chCheckRange.Size = New System.Drawing.Size(105, 17)
        Me.chCheckRange.TabIndex = 19
        Me.chCheckRange.Text = "Checks Range"
        Me.chCheckRange.UseVisualStyleBackColor = False
        '
        'chDates
        '
        Me.chDates.BackColor = System.Drawing.Color.White
        Me.chDates.Checked = True
        Me.chDates.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chDates.Cursor = System.Windows.Forms.Cursors.Default
        Me.chDates.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chDates.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chDates.Location = New System.Drawing.Point(32, 272)
        Me.chDates.Name = "chDates"
        Me.chDates.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chDates.Size = New System.Drawing.Size(129, 17)
        Me.chDates.TabIndex = 14
        Me.chDates.Text = "Checks Printed on"
        Me.chDates.UseVisualStyleBackColor = False
        '
        'frDates
        '
        Me.frDates.BackColor = System.Drawing.Color.White
        Me.frDates.Controls.Add(Me.dtEnd)
        Me.frDates.Controls.Add(Me.dtStart)
        Me.frDates.Controls.Add(Me.Label8)
        Me.frDates.Controls.Add(Me.Label7)
        Me.frDates.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frDates.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frDates.Location = New System.Drawing.Point(80, 288)
        Me.frDates.Name = "frDates"
        Me.frDates.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frDates.Size = New System.Drawing.Size(225, 73)
        Me.frDates.TabIndex = 13
        Me.frDates.TabStop = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(33, 17)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "To"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(8, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(34, 24)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "From"
        '
        'cbBankAccount
        '
        Me.cbBankAccount.BackColor = System.Drawing.SystemColors.Window
        Me.cbBankAccount.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbBankAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBankAccount.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBankAccount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbBankAccount.Location = New System.Drawing.Point(160, 128)
        Me.cbBankAccount.Name = "cbBankAccount"
        Me.cbBankAccount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbBankAccount.Size = New System.Drawing.Size(153, 22)
        Me.cbBankAccount.TabIndex = 11
        '
        'cbBank
        '
        Me.cbBank.BackColor = System.Drawing.SystemColors.Window
        Me.cbBank.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBank.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBank.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbBank.Location = New System.Drawing.Point(80, 96)
        Me.cbBank.Name = "cbBank"
        Me.cbBank.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbBank.Size = New System.Drawing.Size(233, 22)
        Me.cbBank.TabIndex = 10
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(192, 376)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(57, 33)
        Me.cmdClose.TabIndex = 9
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdSearch
        '
        Me.cmdSearch.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSearch.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSearch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSearch.Location = New System.Drawing.Point(112, 376)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSearch.Size = New System.Drawing.Size(57, 33)
        Me.cmdSearch.TabIndex = 8
        Me.cmdSearch.Text = "Search"
        Me.cmdSearch.UseVisualStyleBackColor = False
        '
        'cbCustName
        '
        Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cbCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustName.Location = New System.Drawing.Point(152, 32)
        Me.cbCustName.Name = "cbCustName"
        Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustName.Size = New System.Drawing.Size(161, 21)
        Me.cbCustName.TabIndex = 4
        '
        'cbVendor
        '
        Me.cbVendor.BackColor = System.Drawing.SystemColors.Window
        Me.cbVendor.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVendor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVendor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbVendor.Location = New System.Drawing.Point(80, 64)
        Me.cbVendor.Name = "cbVendor"
        Me.cbVendor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbVendor.Size = New System.Drawing.Size(233, 22)
        Me.cbVendor.TabIndex = 3
        '
        'cbCustId
        '
        Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustId.Location = New System.Drawing.Point(80, 32)
        Me.cbCustId.Name = "cbCustId"
        Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustId.Size = New System.Drawing.Size(65, 22)
        Me.cbCustId.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(80, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(81, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Bank Account"
        '
        'label2
        '
        Me.label2.BackColor = System.Drawing.SystemColors.Window
        Me.label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.label2.Location = New System.Drawing.Point(17, 96)
        Me.label2.Name = "label2"
        Me.label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label2.Size = New System.Drawing.Size(41, 17)
        Me.label2.TabIndex = 7
        Me.label2.Text = "Bank"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label6.Location = New System.Drawing.Point(17, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(49, 17)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Vendor"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label5.Location = New System.Drawing.Point(17, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(64, 19)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Customer"
        '
        'dtStart
        '
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStart.Location = New System.Drawing.Point(48, 16)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(106, 20)
        Me.dtStart.TabIndex = 19
        '
        'dtEnd
        '
        Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEnd.Location = New System.Drawing.Point(48, 40)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(106, 20)
        Me.dtEnd.TabIndex = 20
        '
        'frmCheckBrowse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.ClientSize = New System.Drawing.Size(434, 475)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmCheckBrowse"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Check Query"
        Me.Frame1.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        Me.frChecks.ResumeLayout(False)
        Me.frDates.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
#End Region 
End Class