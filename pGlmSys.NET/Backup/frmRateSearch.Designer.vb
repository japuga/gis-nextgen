<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRateSearch
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
	Public WithEvents cbAccountStatus As System.Windows.Forms.ComboBox
    Public WithEvents cmdFilter As System.Windows.Forms.Button
	Public WithEvents cbZip As System.Windows.Forms.ComboBox
	Public WithEvents txtCity As System.Windows.Forms.TextBox
	Public WithEvents ckZip As System.Windows.Forms.RadioButton
	Public WithEvents ckStateCity As System.Windows.Forms.RadioButton
	Public WithEvents cbState As System.Windows.Forms.ComboBox
	Public WithEvents txtZip As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cbContent As System.Windows.Forms.ComboBox
	Public WithEvents cbEquipment As System.Windows.Forms.ComboBox
	Public WithEvents cbService As System.Windows.Forms.ComboBox
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbAccountStatus = New System.Windows.Forms.ComboBox
        Me.cmdFilter = New System.Windows.Forms.Button
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.cbZip = New System.Windows.Forms.ComboBox
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.ckZip = New System.Windows.Forms.RadioButton
        Me.ckStateCity = New System.Windows.Forms.RadioButton
        Me.cbState = New System.Windows.Forms.ComboBox
        Me.txtZip = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbContent = New System.Windows.Forms.ComboBox
        Me.cbEquipment = New System.Windows.Forms.ComboBox
        Me.cbService = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgRates = New System.Windows.Forms.DataGridView
        Me.Frame1.SuspendLayout()
        CType(Me.dgRates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbAccountStatus
        '
        Me.cbAccountStatus.BackColor = System.Drawing.SystemColors.Window
        Me.cbAccountStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbAccountStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAccountStatus.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAccountStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbAccountStatus.Location = New System.Drawing.Point(111, 144)
        Me.cbAccountStatus.Name = "cbAccountStatus"
        Me.cbAccountStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbAccountStatus.Size = New System.Drawing.Size(265, 22)
        Me.cbAccountStatus.TabIndex = 18
        '
        'cmdFilter
        '
        Me.cmdFilter.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFilter.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFilter.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFilter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFilter.Location = New System.Drawing.Point(96, 184)
        Me.cmdFilter.Name = "cmdFilter"
        Me.cmdFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFilter.Size = New System.Drawing.Size(97, 25)
        Me.cmdFilter.TabIndex = 15
        Me.cmdFilter.Text = "Apply Filter"
        Me.cmdFilter.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.cbZip)
        Me.Frame1.Controls.Add(Me.txtCity)
        Me.Frame1.Controls.Add(Me.ckZip)
        Me.Frame1.Controls.Add(Me.ckStateCity)
        Me.Frame1.Controls.Add(Me.cbState)
        Me.Frame1.Controls.Add(Me.txtZip)
        Me.Frame1.Controls.Add(Me.Label5)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(440, 24)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(377, 185)
        Me.Frame1.TabIndex = 6
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Location"
        '
        'cbZip
        '
        Me.cbZip.BackColor = System.Drawing.SystemColors.Window
        Me.cbZip.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbZip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbZip.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbZip.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbZip.Location = New System.Drawing.Point(104, 144)
        Me.cbZip.Name = "cbZip"
        Me.cbZip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbZip.Size = New System.Drawing.Size(161, 22)
        Me.cbZip.TabIndex = 14
        '
        'txtCity
        '
        Me.txtCity.AcceptsReturn = True
        Me.txtCity.BackColor = System.Drawing.SystemColors.Window
        Me.txtCity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCity.Location = New System.Drawing.Point(104, 72)
        Me.txtCity.MaxLength = 0
        Me.txtCity.Name = "txtCity"
        Me.txtCity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCity.Size = New System.Drawing.Size(241, 20)
        Me.txtCity.TabIndex = 12
        '
        'ckZip
        '
        Me.ckZip.BackColor = System.Drawing.SystemColors.Control
        Me.ckZip.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckZip.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckZip.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckZip.Location = New System.Drawing.Point(24, 128)
        Me.ckZip.Name = "ckZip"
        Me.ckZip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckZip.Size = New System.Drawing.Size(105, 17)
        Me.ckZip.TabIndex = 10
        Me.ckZip.TabStop = True
        Me.ckZip.Text = "By Zip"
        Me.ckZip.UseVisualStyleBackColor = False
        '
        'ckStateCity
        '
        Me.ckStateCity.BackColor = System.Drawing.SystemColors.Control
        Me.ckStateCity.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckStateCity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckStateCity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckStateCity.Location = New System.Drawing.Point(24, 24)
        Me.ckStateCity.Name = "ckStateCity"
        Me.ckStateCity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckStateCity.Size = New System.Drawing.Size(89, 17)
        Me.ckStateCity.TabIndex = 9
        Me.ckStateCity.TabStop = True
        Me.ckStateCity.Text = "By State/City"
        Me.ckStateCity.UseVisualStyleBackColor = False
        '
        'cbState
        '
        Me.cbState.BackColor = System.Drawing.SystemColors.Window
        Me.cbState.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbState.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbState.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbState.Location = New System.Drawing.Point(104, 48)
        Me.cbState.Name = "cbState"
        Me.cbState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbState.Size = New System.Drawing.Size(97, 22)
        Me.cbState.TabIndex = 7
        '
        'txtZip
        '
        Me.txtZip.BackColor = System.Drawing.SystemColors.Control
        Me.txtZip.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtZip.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZip.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtZip.Location = New System.Drawing.Point(64, 152)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtZip.Size = New System.Drawing.Size(41, 17)
        Me.txtZip.TabIndex = 13
        Me.txtZip.Text = "Zip"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(64, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(33, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "City"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(64, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(33, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "State"
        '
        'cbContent
        '
        Me.cbContent.BackColor = System.Drawing.SystemColors.Window
        Me.cbContent.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbContent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbContent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbContent.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbContent.Location = New System.Drawing.Point(111, 104)
        Me.cbContent.Name = "cbContent"
        Me.cbContent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbContent.Size = New System.Drawing.Size(265, 22)
        Me.cbContent.TabIndex = 5
        '
        'cbEquipment
        '
        Me.cbEquipment.BackColor = System.Drawing.SystemColors.Window
        Me.cbEquipment.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEquipment.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEquipment.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbEquipment.Location = New System.Drawing.Point(111, 72)
        Me.cbEquipment.Name = "cbEquipment"
        Me.cbEquipment.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbEquipment.Size = New System.Drawing.Size(265, 22)
        Me.cbEquipment.TabIndex = 3
        '
        'cbService
        '
        Me.cbService.BackColor = System.Drawing.SystemColors.Window
        Me.cbService.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbService.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbService.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbService.Location = New System.Drawing.Point(111, 32)
        Me.cbService.Name = "cbService"
        Me.cbService.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbService.Size = New System.Drawing.Size(265, 22)
        Me.cbService.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(24, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(73, 22)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Account"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(24, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(81, 22)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Content"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(81, 22)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Equipment"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(65, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Service"
        '
        'dgRates
        '
        Me.dgRates.AllowUserToAddRows = False
        Me.dgRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRates.Location = New System.Drawing.Point(8, 215)
        Me.dgRates.Name = "dgRates"
        Me.dgRates.Size = New System.Drawing.Size(857, 314)
        Me.dgRates.TabIndex = 19
        '
        'frmRateSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(881, 545)
        Me.Controls.Add(Me.dgRates)
        Me.Controls.Add(Me.cbAccountStatus)
        Me.Controls.Add(Me.cmdFilter)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cbContent)
        Me.Controls.Add(Me.cbEquipment)
        Me.Controls.Add(Me.cbService)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "frmRateSearch"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Rate Search"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        CType(Me.dgRates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgRates As System.Windows.Forms.DataGridView
#End Region 
End Class