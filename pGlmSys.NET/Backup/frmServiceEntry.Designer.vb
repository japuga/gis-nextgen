<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmServiceEntry
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
	Public WithEvents cbServDescConversion As System.Windows.Forms.ComboBox
	Public WithEvents cbServUnitDesc As System.Windows.Forms.ComboBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents cbServFrequency As System.Windows.Forms.ComboBox
	Public WithEvents cbServClass As System.Windows.Forms.ComboBox
	Public WithEvents cbServMeasureUnit As System.Windows.Forms.ComboBox
	Public WithEvents cbServRateContract As System.Windows.Forms.ComboBox
	Public WithEvents txtServDesc As System.Windows.Forms.TextBox
	Public WithEvents cbServCredit As System.Windows.Forms.ComboBox
	Public WithEvents cbServEqpt As System.Windows.Forms.ComboBox
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbServFrequency = New System.Windows.Forms.ComboBox
        Me.cbServRateContract = New System.Windows.Forms.ComboBox
        Me.cbServCredit = New System.Windows.Forms.ComboBox
        Me.cbServEqpt = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbServDescConversion = New System.Windows.Forms.ComboBox
        Me.cbServUnitDesc = New System.Windows.Forms.ComboBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cbServClass = New System.Windows.Forms.ComboBox
        Me.cbServMeasureUnit = New System.Windows.Forms.ComboBox
        Me.txtServDesc = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cbServFrequency
        '
        Me.cbServFrequency.BackColor = System.Drawing.SystemColors.Window
        Me.cbServFrequency.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbServFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbServFrequency.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbServFrequency.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbServFrequency.Location = New System.Drawing.Point(146, 151)
        Me.cbServFrequency.Name = "cbServFrequency"
        Me.cbServFrequency.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbServFrequency.Size = New System.Drawing.Size(73, 22)
        Me.cbServFrequency.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.cbServFrequency, "Must a frequency be set for this service")
        '
        'cbServRateContract
        '
        Me.cbServRateContract.BackColor = System.Drawing.SystemColors.Window
        Me.cbServRateContract.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbServRateContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbServRateContract.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbServRateContract.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbServRateContract.Location = New System.Drawing.Point(146, 263)
        Me.cbServRateContract.Name = "cbServRateContract"
        Me.cbServRateContract.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbServRateContract.Size = New System.Drawing.Size(73, 22)
        Me.cbServRateContract.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.cbServRateContract, "Benchmark Rate must be set on a Contract?")
        Me.cbServRateContract.Visible = False
        '
        'cbServCredit
        '
        Me.cbServCredit.BackColor = System.Drawing.SystemColors.Window
        Me.cbServCredit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbServCredit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbServCredit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbServCredit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbServCredit.Location = New System.Drawing.Point(146, 55)
        Me.cbServCredit.Name = "cbServCredit"
        Me.cbServCredit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbServCredit.Size = New System.Drawing.Size(73, 22)
        Me.cbServCredit.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cbServCredit, "Service is a Credit or Debit")
        '
        'cbServEqpt
        '
        Me.cbServEqpt.BackColor = System.Drawing.SystemColors.Window
        Me.cbServEqpt.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbServEqpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbServEqpt.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbServEqpt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbServEqpt.Location = New System.Drawing.Point(146, 183)
        Me.cbServEqpt.Name = "cbServEqpt"
        Me.cbServEqpt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbServEqpt.Size = New System.Drawing.Size(73, 22)
        Me.cbServEqpt.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.cbServEqpt, "This service just applies to equipments")
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 154)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(124, 17)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Frequency Required"
        Me.ToolTip1.SetToolTip(Me.Label7, "Must a frequency be set for this service")
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 264)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(97, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Contract Rated"
        Me.ToolTip1.SetToolTip(Me.Label4, "Benchmark Rate must be set on a Contract?")
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Invoice Behavior"
        Me.ToolTip1.SetToolTip(Me.Label3, "Service is a Credit or Debit")
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(105, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Equipment Required"
        Me.ToolTip1.SetToolTip(Me.Label2, "This service just applies to equipments")
        '
        'cbServDescConversion
        '
        Me.cbServDescConversion.BackColor = System.Drawing.SystemColors.Window
        Me.cbServDescConversion.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbServDescConversion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbServDescConversion.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbServDescConversion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbServDescConversion.Location = New System.Drawing.Point(146, 223)
        Me.cbServDescConversion.Name = "cbServDescConversion"
        Me.cbServDescConversion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbServDescConversion.Size = New System.Drawing.Size(177, 22)
        Me.cbServDescConversion.TabIndex = 17
        '
        'cbServUnitDesc
        '
        Me.cbServUnitDesc.BackColor = System.Drawing.SystemColors.Window
        Me.cbServUnitDesc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbServUnitDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbServUnitDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbServUnitDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbServUnitDesc.Location = New System.Drawing.Point(146, 87)
        Me.cbServUnitDesc.Name = "cbServUnitDesc"
        Me.cbServUnitDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbServUnitDesc.Size = New System.Drawing.Size(153, 22)
        Me.cbServUnitDesc.TabIndex = 16
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(190, 313)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 33)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(94, 313)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(57, 33)
        Me.cmdOk.TabIndex = 8
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'cbServClass
        '
        Me.cbServClass.BackColor = System.Drawing.SystemColors.Window
        Me.cbServClass.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbServClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbServClass.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbServClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbServClass.Location = New System.Drawing.Point(146, 119)
        Me.cbServClass.Name = "cbServClass"
        Me.cbServClass.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbServClass.Size = New System.Drawing.Size(113, 22)
        Me.cbServClass.TabIndex = 4
        '
        'cbServMeasureUnit
        '
        Me.cbServMeasureUnit.BackColor = System.Drawing.SystemColors.Window
        Me.cbServMeasureUnit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbServMeasureUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbServMeasureUnit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbServMeasureUnit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbServMeasureUnit.Location = New System.Drawing.Point(264, 288)
        Me.cbServMeasureUnit.Name = "cbServMeasureUnit"
        Me.cbServMeasureUnit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbServMeasureUnit.Size = New System.Drawing.Size(57, 22)
        Me.cbServMeasureUnit.TabIndex = 3
        Me.cbServMeasureUnit.Visible = False
        '
        'txtServDesc
        '
        Me.txtServDesc.AcceptsReturn = True
        Me.txtServDesc.BackColor = System.Drawing.SystemColors.Window
        Me.txtServDesc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtServDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtServDesc.Location = New System.Drawing.Point(146, 23)
        Me.txtServDesc.MaxLength = 0
        Me.txtServDesc.Name = "txtServDesc"
        Me.txtServDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtServDesc.Size = New System.Drawing.Size(169, 19)
        Me.txtServDesc.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 224)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(124, 40)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Service for Conversion Units"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(81, 17)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Service Class"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(81, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Measure Unit"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Service Name"
        '
        'frmServiceEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(362, 385)
        Me.Controls.Add(Me.cbServDescConversion)
        Me.Controls.Add(Me.cbServUnitDesc)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cbServFrequency)
        Me.Controls.Add(Me.cbServClass)
        Me.Controls.Add(Me.cbServMeasureUnit)
        Me.Controls.Add(Me.cbServRateContract)
        Me.Controls.Add(Me.txtServDesc)
        Me.Controls.Add(Me.cbServCredit)
        Me.Controls.Add(Me.cbServEqpt)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmServiceEntry"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Service Entry"
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class