<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPeriodEntry
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
	Public WithEvents cbPeriodStatusId As System.Windows.Forms.ComboBox
	Public WithEvents cbPeriodStatusDesc As System.Windows.Forms.ComboBox
	Public WithEvents txtCustName As System.Windows.Forms.TextBox
	Public WithEvents txtPeriodName As System.Windows.Forms.TextBox
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbPeriodStatusId = New System.Windows.Forms.ComboBox
        Me.cbPeriodStatusDesc = New System.Windows.Forms.ComboBox
        Me.txtCustName = New System.Windows.Forms.TextBox
        Me.txtPeriodName = New System.Windows.Forms.TextBox
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtStartDate = New System.Windows.Forms.DateTimePicker
        Me.dtEndDate = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'cbPeriodStatusId
        '
        Me.cbPeriodStatusId.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriodStatusId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbPeriodStatusId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodStatusId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriodStatusId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbPeriodStatusId.Location = New System.Drawing.Point(264, 136)
        Me.cbPeriodStatusId.Name = "cbPeriodStatusId"
        Me.cbPeriodStatusId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbPeriodStatusId.Size = New System.Drawing.Size(121, 22)
        Me.cbPeriodStatusId.TabIndex = 13
        '
        'cbPeriodStatusDesc
        '
        Me.cbPeriodStatusDesc.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriodStatusDesc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbPeriodStatusDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodStatusDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriodStatusDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbPeriodStatusDesc.Location = New System.Drawing.Point(104, 136)
        Me.cbPeriodStatusDesc.Name = "cbPeriodStatusDesc"
        Me.cbPeriodStatusDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbPeriodStatusDesc.Size = New System.Drawing.Size(137, 22)
        Me.cbPeriodStatusDesc.TabIndex = 12
        '
        'txtCustName
        '
        Me.txtCustName.AcceptsReturn = True
        Me.txtCustName.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustName.Location = New System.Drawing.Point(104, 8)
        Me.txtCustName.MaxLength = 0
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCustName.Size = New System.Drawing.Size(121, 20)
        Me.txtCustName.TabIndex = 10
        Me.txtCustName.Text = "Text1"
        '
        'txtPeriodName
        '
        Me.txtPeriodName.AcceptsReturn = True
        Me.txtPeriodName.BackColor = System.Drawing.SystemColors.Window
        Me.txtPeriodName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPeriodName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPeriodName.Location = New System.Drawing.Point(104, 48)
        Me.txtPeriodName.MaxLength = 0
        Me.txtPeriodName.Name = "txtPeriodName"
        Me.txtPeriodName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPeriodName.Size = New System.Drawing.Size(185, 20)
        Me.txtPeriodName.TabIndex = 3
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(136, 184)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(49, 33)
        Me.cmdOk.TabIndex = 1
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(216, 184)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(49, 33)
        Me.cmdCancel.TabIndex = 0
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(15, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(74, 14)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Period Status"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(86, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Customer"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(32, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(25, 1)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(12, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(86, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Period Name"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(12, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(69, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Start Date"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(224, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(57, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "End Date"
        '
        'dtStartDate
        '
        Me.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStartDate.Location = New System.Drawing.Point(104, 96)
        Me.dtStartDate.Name = "dtStartDate"
        Me.dtStartDate.Size = New System.Drawing.Size(94, 20)
        Me.dtStartDate.TabIndex = 14
        '
        'dtEndDate
        '
        Me.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEndDate.Location = New System.Drawing.Point(288, 96)
        Me.dtEndDate.Name = "dtEndDate"
        Me.dtEndDate.Size = New System.Drawing.Size(97, 20)
        Me.dtEndDate.TabIndex = 15
        '
        'frmPeriodEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(427, 233)
        Me.Controls.Add(Me.dtEndDate)
        Me.Controls.Add(Me.dtStartDate)
        Me.Controls.Add(Me.cbPeriodStatusId)
        Me.Controls.Add(Me.cbPeriodStatusDesc)
        Me.Controls.Add(Me.txtCustName)
        Me.Controls.Add(Me.txtPeriodName)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmPeriodEntry"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Period Data Entry"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtEndDate As System.Windows.Forms.DateTimePicker
#End Region 
End Class