<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmContractEntry
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
	Public WithEvents txtGlmRate As System.Windows.Forms.TextBox
	Public WithEvents ckbOverrideExpFlag As System.Windows.Forms.CheckBox
	Public WithEvents ckbDefaultService As System.Windows.Forms.CheckBox
	Public WithEvents cbRateStatus As System.Windows.Forms.ComboBox
	Public WithEvents cbRateDesc As System.Windows.Forms.ComboBox
	Public WithEvents txtContractComments As System.Windows.Forms.TextBox
	Public WithEvents cbFreqPeriod As System.Windows.Forms.ComboBox
	Public WithEvents cbVendName As System.Windows.Forms.ComboBox
	Public WithEvents txtCurrRate As System.Windows.Forms.TextBox
	Public WithEvents txtOldRate As System.Windows.Forms.TextBox
	Public WithEvents txtFreqComments As System.Windows.Forms.TextBox
    Public WithEvents _ckbFreqDay_6 As System.Windows.Forms.CheckBox
	Public WithEvents _ckbFreqDay_5 As System.Windows.Forms.CheckBox
	Public WithEvents _ckbFreqDay_4 As System.Windows.Forms.CheckBox
	Public WithEvents _ckbFreqDay_3 As System.Windows.Forms.CheckBox
	Public WithEvents _ckbFreqDay_2 As System.Windows.Forms.CheckBox
	Public WithEvents _ckbFreqDay_1 As System.Windows.Forms.CheckBox
	Public WithEvents _ckbFreqDay_0 As System.Windows.Forms.CheckBox
	Public WithEvents Frame3 As System.Windows.Forms.GroupBox
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents lbTimes As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents fmService As System.Windows.Forms.GroupBox
	Public WithEvents cbServDesc As System.Windows.Forms.ComboBox
	Public WithEvents cbEqptDesc As System.Windows.Forms.ComboBox
	Public WithEvents cmdVendorSearch As System.Windows.Forms.Button
	Public WithEvents txtVendName As System.Windows.Forms.TextBox
	Public WithEvents txtStoreNumber As System.Windows.Forms.TextBox
	Public WithEvents txtCustId As System.Windows.Forms.TextBox
    Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents lbExpiration As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents ckbFreqDay As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContractEntry))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.dtExpiration = New System.Windows.Forms.DateTimePicker
        Me.dtOpening = New System.Windows.Forms.DateTimePicker
        Me.txtGlmRate = New System.Windows.Forms.TextBox
        Me.ckbOverrideExpFlag = New System.Windows.Forms.CheckBox
        Me.ckbDefaultService = New System.Windows.Forms.CheckBox
        Me.cbRateStatus = New System.Windows.Forms.ComboBox
        Me.cbRateDesc = New System.Windows.Forms.ComboBox
        Me.txtContractComments = New System.Windows.Forms.TextBox
        Me.cbFreqPeriod = New System.Windows.Forms.ComboBox
        Me.cbVendName = New System.Windows.Forms.ComboBox
        Me.txtCurrRate = New System.Windows.Forms.TextBox
        Me.txtOldRate = New System.Windows.Forms.TextBox
        Me.fmService = New System.Windows.Forms.GroupBox
        Me.txtFreqTimes = New System.Windows.Forms.NumericUpDown
        Me.txtFreqComments = New System.Windows.Forms.TextBox
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me._ckbFreqDay_6 = New System.Windows.Forms.CheckBox
        Me._ckbFreqDay_5 = New System.Windows.Forms.CheckBox
        Me._ckbFreqDay_4 = New System.Windows.Forms.CheckBox
        Me._ckbFreqDay_3 = New System.Windows.Forms.CheckBox
        Me._ckbFreqDay_2 = New System.Windows.Forms.CheckBox
        Me._ckbFreqDay_1 = New System.Windows.Forms.CheckBox
        Me._ckbFreqDay_0 = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.lbTimes = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbServDesc = New System.Windows.Forms.ComboBox
        Me.cbEqptDesc = New System.Windows.Forms.ComboBox
        Me.cmdVendorSearch = New System.Windows.Forms.Button
        Me.txtVendName = New System.Windows.Forms.TextBox
        Me.txtStoreNumber = New System.Windows.Forms.TextBox
        Me.txtCustId = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lbExpiration = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.ckbFreqDay = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
        Me.Frame1.SuspendLayout()
        Me.fmService.SuspendLayout()
        CType(Me.txtFreqTimes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame3.SuspendLayout()
        CType(Me.ckbFreqDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.dtExpiration)
        Me.Frame1.Controls.Add(Me.dtOpening)
        Me.Frame1.Controls.Add(Me.txtGlmRate)
        Me.Frame1.Controls.Add(Me.ckbOverrideExpFlag)
        Me.Frame1.Controls.Add(Me.ckbDefaultService)
        Me.Frame1.Controls.Add(Me.cbRateStatus)
        Me.Frame1.Controls.Add(Me.cbRateDesc)
        Me.Frame1.Controls.Add(Me.txtContractComments)
        Me.Frame1.Controls.Add(Me.cbFreqPeriod)
        Me.Frame1.Controls.Add(Me.cbVendName)
        Me.Frame1.Controls.Add(Me.txtCurrRate)
        Me.Frame1.Controls.Add(Me.txtOldRate)
        Me.Frame1.Controls.Add(Me.fmService)
        Me.Frame1.Controls.Add(Me.cbServDesc)
        Me.Frame1.Controls.Add(Me.cbEqptDesc)
        Me.Frame1.Controls.Add(Me.cmdVendorSearch)
        Me.Frame1.Controls.Add(Me.txtVendName)
        Me.Frame1.Controls.Add(Me.txtStoreNumber)
        Me.Frame1.Controls.Add(Me.txtCustId)
        Me.Frame1.Controls.Add(Me.Label15)
        Me.Frame1.Controls.Add(Me.Label14)
        Me.Frame1.Controls.Add(Me.Label13)
        Me.Frame1.Controls.Add(Me.Label12)
        Me.Frame1.Controls.Add(Me.Label11)
        Me.Frame1.Controls.Add(Me.Label10)
        Me.Frame1.Controls.Add(Me.Label9)
        Me.Frame1.Controls.Add(Me.lbExpiration)
        Me.Frame1.Controls.Add(Me.Label6)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.Label5)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(16, 0)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(393, 521)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        '
        'dtExpiration
        '
        Me.dtExpiration.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtExpiration.Location = New System.Drawing.Point(24, 208)
        Me.dtExpiration.Name = "dtExpiration"
        Me.dtExpiration.Size = New System.Drawing.Size(129, 20)
        Me.dtExpiration.TabIndex = 51
        '
        'dtOpening
        '
        Me.dtOpening.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtOpening.Location = New System.Drawing.Point(24, 168)
        Me.dtOpening.Name = "dtOpening"
        Me.dtOpening.Size = New System.Drawing.Size(129, 20)
        Me.dtOpening.TabIndex = 50
        '
        'txtGlmRate
        '
        Me.txtGlmRate.AcceptsReturn = True
        Me.txtGlmRate.BackColor = System.Drawing.SystemColors.Window
        Me.txtGlmRate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGlmRate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGlmRate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGlmRate.Location = New System.Drawing.Point(24, 328)
        Me.txtGlmRate.MaxLength = 0
        Me.txtGlmRate.Name = "txtGlmRate"
        Me.txtGlmRate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGlmRate.Size = New System.Drawing.Size(89, 20)
        Me.txtGlmRate.TabIndex = 49
        '
        'ckbOverrideExpFlag
        '
        Me.ckbOverrideExpFlag.BackColor = System.Drawing.SystemColors.Control
        Me.ckbOverrideExpFlag.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckbOverrideExpFlag.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbOverrideExpFlag.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckbOverrideExpFlag.Location = New System.Drawing.Point(24, 424)
        Me.ckbOverrideExpFlag.Name = "ckbOverrideExpFlag"
        Me.ckbOverrideExpFlag.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckbOverrideExpFlag.Size = New System.Drawing.Size(137, 17)
        Me.ckbOverrideExpFlag.TabIndex = 46
        Me.ckbOverrideExpFlag.Text = "Override Expiration Date"
        Me.ckbOverrideExpFlag.UseVisualStyleBackColor = False
        '
        'ckbDefaultService
        '
        Me.ckbDefaultService.BackColor = System.Drawing.SystemColors.Control
        Me.ckbDefaultService.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckbDefaultService.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbDefaultService.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckbDefaultService.Location = New System.Drawing.Point(24, 400)
        Me.ckbDefaultService.Name = "ckbDefaultService"
        Me.ckbDefaultService.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckbDefaultService.Size = New System.Drawing.Size(113, 17)
        Me.ckbDefaultService.TabIndex = 45
        Me.ckbDefaultService.Text = "Default Frequency"
        Me.ckbDefaultService.UseVisualStyleBackColor = False
        '
        'cbRateStatus
        '
        Me.cbRateStatus.BackColor = System.Drawing.SystemColors.Window
        Me.cbRateStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbRateStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRateStatus.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRateStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbRateStatus.Location = New System.Drawing.Point(160, 368)
        Me.cbRateStatus.Name = "cbRateStatus"
        Me.cbRateStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbRateStatus.Size = New System.Drawing.Size(41, 22)
        Me.cbRateStatus.TabIndex = 44
        Me.cbRateStatus.Visible = False
        '
        'cbRateDesc
        '
        Me.cbRateDesc.BackColor = System.Drawing.SystemColors.Window
        Me.cbRateDesc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbRateDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRateDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRateDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbRateDesc.Location = New System.Drawing.Point(24, 368)
        Me.cbRateDesc.Name = "cbRateDesc"
        Me.cbRateDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbRateDesc.Size = New System.Drawing.Size(137, 22)
        Me.cbRateDesc.TabIndex = 22
        '
        'txtContractComments
        '
        Me.txtContractComments.AcceptsReturn = True
        Me.txtContractComments.BackColor = System.Drawing.SystemColors.Window
        Me.txtContractComments.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtContractComments.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContractComments.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtContractComments.Location = New System.Drawing.Point(24, 464)
        Me.txtContractComments.MaxLength = 60
        Me.txtContractComments.Multiline = True
        Me.txtContractComments.Name = "txtContractComments"
        Me.txtContractComments.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtContractComments.Size = New System.Drawing.Size(145, 41)
        Me.txtContractComments.TabIndex = 23
        '
        'cbFreqPeriod
        '
        Me.cbFreqPeriod.BackColor = System.Drawing.SystemColors.Window
        Me.cbFreqPeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbFreqPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFreqPeriod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFreqPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbFreqPeriod.Location = New System.Drawing.Point(184, 168)
        Me.cbFreqPeriod.Name = "cbFreqPeriod"
        Me.cbFreqPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbFreqPeriod.Size = New System.Drawing.Size(145, 22)
        Me.cbFreqPeriod.TabIndex = 25
        '
        'cbVendName
        '
        Me.cbVendName.BackColor = System.Drawing.SystemColors.Window
        Me.cbVendName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbVendName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVendName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVendName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbVendName.Location = New System.Drawing.Point(24, 80)
        Me.cbVendName.Name = "cbVendName"
        Me.cbVendName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbVendName.Size = New System.Drawing.Size(289, 22)
        Me.cbVendName.TabIndex = 8
        '
        'txtCurrRate
        '
        Me.txtCurrRate.AcceptsReturn = True
        Me.txtCurrRate.BackColor = System.Drawing.SystemColors.Window
        Me.txtCurrRate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCurrRate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrRate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCurrRate.Location = New System.Drawing.Point(24, 288)
        Me.txtCurrRate.MaxLength = 0
        Me.txtCurrRate.Name = "txtCurrRate"
        Me.txtCurrRate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCurrRate.Size = New System.Drawing.Size(89, 20)
        Me.txtCurrRate.TabIndex = 21
        '
        'txtOldRate
        '
        Me.txtOldRate.AcceptsReturn = True
        Me.txtOldRate.BackColor = System.Drawing.SystemColors.Window
        Me.txtOldRate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOldRate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldRate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOldRate.Location = New System.Drawing.Point(24, 248)
        Me.txtOldRate.MaxLength = 0
        Me.txtOldRate.Name = "txtOldRate"
        Me.txtOldRate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOldRate.Size = New System.Drawing.Size(89, 20)
        Me.txtOldRate.TabIndex = 20
        '
        'fmService
        '
        Me.fmService.BackColor = System.Drawing.SystemColors.Control
        Me.fmService.Controls.Add(Me.txtFreqTimes)
        Me.fmService.Controls.Add(Me.txtFreqComments)
        Me.fmService.Controls.Add(Me.Frame3)
        Me.fmService.Controls.Add(Me.Label8)
        Me.fmService.Controls.Add(Me.lbTimes)
        Me.fmService.Controls.Add(Me.Label7)
        Me.fmService.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fmService.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fmService.Location = New System.Drawing.Point(184, 208)
        Me.fmService.Name = "fmService"
        Me.fmService.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fmService.Size = New System.Drawing.Size(185, 305)
        Me.fmService.TabIndex = 17
        Me.fmService.TabStop = False
        '
        'txtFreqTimes
        '
        Me.txtFreqTimes.Location = New System.Drawing.Point(26, 38)
        Me.txtFreqTimes.Name = "txtFreqTimes"
        Me.txtFreqTimes.Size = New System.Drawing.Size(40, 20)
        Me.txtFreqTimes.TabIndex = 42
        '
        'txtFreqComments
        '
        Me.txtFreqComments.AcceptsReturn = True
        Me.txtFreqComments.BackColor = System.Drawing.SystemColors.Window
        Me.txtFreqComments.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFreqComments.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFreqComments.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFreqComments.Location = New System.Drawing.Point(16, 279)
        Me.txtFreqComments.MaxLength = 40
        Me.txtFreqComments.Name = "txtFreqComments"
        Me.txtFreqComments.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFreqComments.Size = New System.Drawing.Size(153, 20)
        Me.txtFreqComments.TabIndex = 32
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me._ckbFreqDay_6)
        Me.Frame3.Controls.Add(Me._ckbFreqDay_5)
        Me.Frame3.Controls.Add(Me._ckbFreqDay_4)
        Me.Frame3.Controls.Add(Me._ckbFreqDay_3)
        Me.Frame3.Controls.Add(Me._ckbFreqDay_2)
        Me.Frame3.Controls.Add(Me._ckbFreqDay_1)
        Me.Frame3.Controls.Add(Me._ckbFreqDay_0)
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(16, 68)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(113, 185)
        Me.Frame3.TabIndex = 24
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Service Days"
        '
        '_ckbFreqDay_6
        '
        Me._ckbFreqDay_6.BackColor = System.Drawing.SystemColors.Control
        Me._ckbFreqDay_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._ckbFreqDay_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ckbFreqDay_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckbFreqDay.SetIndex(Me._ckbFreqDay_6, CType(6, Short))
        Me._ckbFreqDay_6.Location = New System.Drawing.Point(16, 160)
        Me._ckbFreqDay_6.Name = "_ckbFreqDay_6"
        Me._ckbFreqDay_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ckbFreqDay_6.Size = New System.Drawing.Size(73, 17)
        Me._ckbFreqDay_6.TabIndex = 40
        Me._ckbFreqDay_6.Tag = "D"
        Me._ckbFreqDay_6.Text = "Sun&day"
        Me._ckbFreqDay_6.UseVisualStyleBackColor = False
        '
        '_ckbFreqDay_5
        '
        Me._ckbFreqDay_5.BackColor = System.Drawing.SystemColors.Control
        Me._ckbFreqDay_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._ckbFreqDay_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ckbFreqDay_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckbFreqDay.SetIndex(Me._ckbFreqDay_5, CType(5, Short))
        Me._ckbFreqDay_5.Location = New System.Drawing.Point(16, 137)
        Me._ckbFreqDay_5.Name = "_ckbFreqDay_5"
        Me._ckbFreqDay_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ckbFreqDay_5.Size = New System.Drawing.Size(73, 17)
        Me._ckbFreqDay_5.TabIndex = 39
        Me._ckbFreqDay_5.Tag = "S"
        Me._ckbFreqDay_5.Text = "&Saturday"
        Me._ckbFreqDay_5.UseVisualStyleBackColor = False
        '
        '_ckbFreqDay_4
        '
        Me._ckbFreqDay_4.BackColor = System.Drawing.SystemColors.Control
        Me._ckbFreqDay_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._ckbFreqDay_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ckbFreqDay_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckbFreqDay.SetIndex(Me._ckbFreqDay_4, CType(4, Short))
        Me._ckbFreqDay_4.Location = New System.Drawing.Point(16, 115)
        Me._ckbFreqDay_4.Name = "_ckbFreqDay_4"
        Me._ckbFreqDay_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ckbFreqDay_4.Size = New System.Drawing.Size(73, 17)
        Me._ckbFreqDay_4.TabIndex = 38
        Me._ckbFreqDay_4.Tag = "F"
        Me._ckbFreqDay_4.Text = "&Friday"
        Me._ckbFreqDay_4.UseVisualStyleBackColor = False
        '
        '_ckbFreqDay_3
        '
        Me._ckbFreqDay_3.BackColor = System.Drawing.SystemColors.Control
        Me._ckbFreqDay_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._ckbFreqDay_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ckbFreqDay_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckbFreqDay.SetIndex(Me._ckbFreqDay_3, CType(3, Short))
        Me._ckbFreqDay_3.Location = New System.Drawing.Point(16, 96)
        Me._ckbFreqDay_3.Name = "_ckbFreqDay_3"
        Me._ckbFreqDay_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ckbFreqDay_3.Size = New System.Drawing.Size(73, 17)
        Me._ckbFreqDay_3.TabIndex = 37
        Me._ckbFreqDay_3.Tag = "R"
        Me._ckbFreqDay_3.Text = "Thu&rsday"
        Me._ckbFreqDay_3.UseVisualStyleBackColor = False
        '
        '_ckbFreqDay_2
        '
        Me._ckbFreqDay_2.BackColor = System.Drawing.SystemColors.Control
        Me._ckbFreqDay_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._ckbFreqDay_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ckbFreqDay_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckbFreqDay.SetIndex(Me._ckbFreqDay_2, CType(2, Short))
        Me._ckbFreqDay_2.Location = New System.Drawing.Point(16, 72)
        Me._ckbFreqDay_2.Name = "_ckbFreqDay_2"
        Me._ckbFreqDay_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ckbFreqDay_2.Size = New System.Drawing.Size(89, 17)
        Me._ckbFreqDay_2.TabIndex = 35
        Me._ckbFreqDay_2.Tag = "W"
        Me._ckbFreqDay_2.Text = "&Wednesday"
        Me._ckbFreqDay_2.UseVisualStyleBackColor = False
        '
        '_ckbFreqDay_1
        '
        Me._ckbFreqDay_1.BackColor = System.Drawing.SystemColors.Control
        Me._ckbFreqDay_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._ckbFreqDay_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ckbFreqDay_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckbFreqDay.SetIndex(Me._ckbFreqDay_1, CType(1, Short))
        Me._ckbFreqDay_1.Location = New System.Drawing.Point(16, 48)
        Me._ckbFreqDay_1.Name = "_ckbFreqDay_1"
        Me._ckbFreqDay_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ckbFreqDay_1.Size = New System.Drawing.Size(73, 17)
        Me._ckbFreqDay_1.TabIndex = 33
        Me._ckbFreqDay_1.Tag = "T"
        Me._ckbFreqDay_1.Text = "&Tuesday"
        Me._ckbFreqDay_1.UseVisualStyleBackColor = False
        '
        '_ckbFreqDay_0
        '
        Me._ckbFreqDay_0.BackColor = System.Drawing.SystemColors.Control
        Me._ckbFreqDay_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._ckbFreqDay_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ckbFreqDay_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckbFreqDay.SetIndex(Me._ckbFreqDay_0, CType(0, Short))
        Me._ckbFreqDay_0.Location = New System.Drawing.Point(16, 24)
        Me._ckbFreqDay_0.Name = "_ckbFreqDay_0"
        Me._ckbFreqDay_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ckbFreqDay_0.Size = New System.Drawing.Size(73, 17)
        Me._ckbFreqDay_0.TabIndex = 31
        Me._ckbFreqDay_0.Tag = "M"
        Me._ckbFreqDay_0.Text = "&Monday"
        Me._ckbFreqDay_0.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 256)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(113, 17)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "Frequency Comments"
        '
        'lbTimes
        '
        Me.lbTimes.BackColor = System.Drawing.SystemColors.Control
        Me.lbTimes.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbTimes.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTimes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbTimes.Location = New System.Drawing.Point(72, 30)
        Me.lbTimes.Name = "lbTimes"
        Me.lbTimes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbTimes.Size = New System.Drawing.Size(97, 35)
        Me.lbTimes.TabIndex = 30
        Me.lbTimes.Text = "times"
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
        Me.Label7.Size = New System.Drawing.Size(97, 14)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Times of Service"
        '
        'cbServDesc
        '
        Me.cbServDesc.BackColor = System.Drawing.SystemColors.Window
        Me.cbServDesc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbServDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbServDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbServDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbServDesc.Location = New System.Drawing.Point(184, 128)
        Me.cbServDesc.Name = "cbServDesc"
        Me.cbServDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbServDesc.Size = New System.Drawing.Size(185, 22)
        Me.cbServDesc.TabIndex = 12
        '
        'cbEqptDesc
        '
        Me.cbEqptDesc.BackColor = System.Drawing.SystemColors.Window
        Me.cbEqptDesc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbEqptDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEqptDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEqptDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbEqptDesc.Location = New System.Drawing.Point(24, 128)
        Me.cbEqptDesc.Name = "cbEqptDesc"
        Me.cbEqptDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbEqptDesc.Size = New System.Drawing.Size(129, 22)
        Me.cbEqptDesc.TabIndex = 11
        '
        'cmdVendorSearch
        '
        Me.cmdVendorSearch.BackColor = System.Drawing.SystemColors.Control
        Me.cmdVendorSearch.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdVendorSearch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVendorSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdVendorSearch.Image = CType(resources.GetObject("cmdVendorSearch.Image"), System.Drawing.Image)
        Me.cmdVendorSearch.Location = New System.Drawing.Point(296, 56)
        Me.cmdVendorSearch.Name = "cmdVendorSearch"
        Me.cmdVendorSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVendorSearch.Size = New System.Drawing.Size(41, 21)
        Me.cmdVendorSearch.TabIndex = 10
        Me.cmdVendorSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdVendorSearch.UseVisualStyleBackColor = False
        Me.cmdVendorSearch.Visible = False
        '
        'txtVendName
        '
        Me.txtVendName.AcceptsReturn = True
        Me.txtVendName.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendName.Location = New System.Drawing.Point(80, 56)
        Me.txtVendName.MaxLength = 0
        Me.txtVendName.Name = "txtVendName"
        Me.txtVendName.ReadOnly = True
        Me.txtVendName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendName.Size = New System.Drawing.Size(217, 20)
        Me.txtVendName.TabIndex = 9
        Me.txtVendName.Visible = False
        '
        'txtStoreNumber
        '
        Me.txtStoreNumber.AcceptsReturn = True
        Me.txtStoreNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreNumber.Enabled = False
        Me.txtStoreNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreNumber.Location = New System.Drawing.Point(184, 32)
        Me.txtStoreNumber.MaxLength = 0
        Me.txtStoreNumber.Name = "txtStoreNumber"
        Me.txtStoreNumber.ReadOnly = True
        Me.txtStoreNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreNumber.Size = New System.Drawing.Size(129, 20)
        Me.txtStoreNumber.TabIndex = 5
        '
        'txtCustId
        '
        Me.txtCustId.AcceptsReturn = True
        Me.txtCustId.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustId.Enabled = False
        Me.txtCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustId.Location = New System.Drawing.Point(24, 32)
        Me.txtCustId.MaxLength = 0
        Me.txtCustId.Name = "txtCustId"
        Me.txtCustId.ReadOnly = True
        Me.txtCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCustId.Size = New System.Drawing.Size(129, 20)
        Me.txtCustId.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(24, 312)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(81, 17)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "GLM Rate"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(16, 320)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(25, 1)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "Label14"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(24, 352)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(57, 17)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Rate Status"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(24, 448)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(81, 17)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "Comments"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(184, 152)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(81, 17)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Service Period"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(24, 272)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(81, 17)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Current Rate"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(24, 232)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(81, 17)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Previous Rate"
        '
        'lbExpiration
        '
        Me.lbExpiration.BackColor = System.Drawing.SystemColors.Control
        Me.lbExpiration.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbExpiration.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbExpiration.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbExpiration.Location = New System.Drawing.Point(24, 192)
        Me.lbExpiration.Name = "lbExpiration"
        Me.lbExpiration.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbExpiration.Size = New System.Drawing.Size(89, 17)
        Me.lbExpiration.TabIndex = 14
        Me.lbExpiration.Text = "Expiration Date"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(24, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(89, 17)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Opening Date"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Customer"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(184, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(41, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Store"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Vendor"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(24, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Equipment"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(184, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(66, 17)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Service"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(224, 528)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(49, 33)
        Me.cmdCancel.TabIndex = 43
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(144, 528)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(49, 33)
        Me.cmdOk.TabIndex = 42
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'frmContractEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(422, 574)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmContractEntry"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Contract Info"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.fmService.ResumeLayout(False)
        Me.fmService.PerformLayout()
        CType(Me.txtFreqTimes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame3.ResumeLayout(False)
        CType(Me.ckbFreqDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtFreqTimes As System.Windows.Forms.NumericUpDown
    Friend WithEvents dtExpiration As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtOpening As System.Windows.Forms.DateTimePicker
#End Region 
End Class