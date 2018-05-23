<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmBankEntry
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
	Public WithEvents cbQBBankName As System.Windows.Forms.ComboBox
	Public WithEvents cbQBGroupId As System.Windows.Forms.ComboBox
	Public WithEvents cbQBGroupDesc As System.Windows.Forms.ComboBox
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents txtLastCheckNo As System.Windows.Forms.TextBox
	Public WithEvents txtBankAccountBalance As System.Windows.Forms.TextBox
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
	Public WithEvents txtBankAccount As System.Windows.Forms.TextBox
	Public WithEvents cbBankName As System.Windows.Forms.ComboBox
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.cbQBBankName = New System.Windows.Forms.ComboBox
        Me.cbQBGroupId = New System.Windows.Forms.ComboBox
        Me.cbQBGroupDesc = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.txtLastCheckNo = New System.Windows.Forms.TextBox
        Me.txtBankAccountBalance = New System.Windows.Forms.TextBox
        Me.cbCustId = New System.Windows.Forms.ComboBox
        Me.cbCustName = New System.Windows.Forms.ComboBox
        Me.txtBankAccount = New System.Windows.Forms.TextBox
        Me.cbBankName = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.cbQBBankName)
        Me.Frame1.Controls.Add(Me.cbQBGroupId)
        Me.Frame1.Controls.Add(Me.cbQBGroupDesc)
        Me.Frame1.Controls.Add(Me.Label7)
        Me.Frame1.Controls.Add(Me.Label6)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(24, 224)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(313, 105)
        Me.Frame1.TabIndex = 13
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "QuickBooks Info"
        '
        'cbQBBankName
        '
        Me.cbQBBankName.BackColor = System.Drawing.SystemColors.Window
        Me.cbQBBankName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbQBBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbQBBankName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbQBBankName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbQBBankName.Location = New System.Drawing.Point(104, 64)
        Me.cbQBBankName.Name = "cbQBBankName"
        Me.cbQBBankName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbQBBankName.Size = New System.Drawing.Size(153, 22)
        Me.cbQBBankName.TabIndex = 18
        '
        'cbQBGroupId
        '
        Me.cbQBGroupId.BackColor = System.Drawing.SystemColors.Window
        Me.cbQBGroupId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbQBGroupId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbQBGroupId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbQBGroupId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbQBGroupId.Location = New System.Drawing.Point(272, 24)
        Me.cbQBGroupId.Name = "cbQBGroupId"
        Me.cbQBGroupId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbQBGroupId.Size = New System.Drawing.Size(41, 22)
        Me.cbQBGroupId.TabIndex = 17
        Me.cbQBGroupId.Visible = False
        '
        'cbQBGroupDesc
        '
        Me.cbQBGroupDesc.BackColor = System.Drawing.SystemColors.Window
        Me.cbQBGroupDesc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbQBGroupDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbQBGroupDesc.Enabled = False
        Me.cbQBGroupDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbQBGroupDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbQBGroupDesc.Location = New System.Drawing.Point(104, 24)
        Me.cbQBGroupDesc.Name = "cbQBGroupDesc"
        Me.cbQBGroupDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbQBGroupDesc.Size = New System.Drawing.Size(153, 22)
        Me.cbQBGroupDesc.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(81, 33)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Quick Books Bank"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(81, 40)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Company Group"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(192, 336)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 33)
        Me.cmdCancel.TabIndex = 12
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(104, 336)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(57, 33)
        Me.cmdOk.TabIndex = 11
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'txtLastCheckNo
        '
        Me.txtLastCheckNo.AcceptsReturn = True
        Me.txtLastCheckNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtLastCheckNo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLastCheckNo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastCheckNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLastCheckNo.Location = New System.Drawing.Point(96, 184)
        Me.txtLastCheckNo.MaxLength = 0
        Me.txtLastCheckNo.Name = "txtLastCheckNo"
        Me.txtLastCheckNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLastCheckNo.Size = New System.Drawing.Size(97, 21)
        Me.txtLastCheckNo.TabIndex = 8
        '
        'txtBankAccountBalance
        '
        Me.txtBankAccountBalance.AcceptsReturn = True
        Me.txtBankAccountBalance.BackColor = System.Drawing.SystemColors.Window
        Me.txtBankAccountBalance.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBankAccountBalance.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankAccountBalance.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBankAccountBalance.Location = New System.Drawing.Point(96, 144)
        Me.txtBankAccountBalance.MaxLength = 0
        Me.txtBankAccountBalance.Name = "txtBankAccountBalance"
        Me.txtBankAccountBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBankAccountBalance.Size = New System.Drawing.Size(97, 21)
        Me.txtBankAccountBalance.TabIndex = 9
        '
        'cbCustId
        '
        Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustId.Location = New System.Drawing.Point(248, 24)
        Me.cbCustId.Name = "cbCustId"
        Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustId.Size = New System.Drawing.Size(89, 22)
        Me.cbCustId.TabIndex = 10
        Me.cbCustId.Visible = False
        '
        'cbCustName
        '
        Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustName.Location = New System.Drawing.Point(96, 24)
        Me.cbCustName.Name = "cbCustName"
        Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustName.Size = New System.Drawing.Size(137, 22)
        Me.cbCustName.TabIndex = 3
        '
        'txtBankAccount
        '
        Me.txtBankAccount.AcceptsReturn = True
        Me.txtBankAccount.BackColor = System.Drawing.SystemColors.Window
        Me.txtBankAccount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBankAccount.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankAccount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBankAccount.Location = New System.Drawing.Point(96, 104)
        Me.txtBankAccount.MaxLength = 0
        Me.txtBankAccount.Name = "txtBankAccount"
        Me.txtBankAccount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBankAccount.Size = New System.Drawing.Size(153, 21)
        Me.txtBankAccount.TabIndex = 7
        '
        'cbBankName
        '
        Me.cbBankName.BackColor = System.Drawing.SystemColors.Window
        Me.cbBankName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBankName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBankName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbBankName.Location = New System.Drawing.Point(96, 64)
        Me.cbBankName.Name = "cbBankName"
        Me.cbBankName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbBankName.Size = New System.Drawing.Size(137, 22)
        Me.cbBankName.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(24, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(57, 37)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Last Check"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(24, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Balance"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(66, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Customer"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(41, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Bank"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(66, 28)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Bank Account"
        '
        'frmBankEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(363, 383)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtLastCheckNo)
        Me.Controls.Add(Me.txtBankAccountBalance)
        Me.Controls.Add(Me.cbCustId)
        Me.Controls.Add(Me.cbCustName)
        Me.Controls.Add(Me.txtBankAccount)
        Me.Controls.Add(Me.cbBankName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmBankEntry"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Bank Data Entry"
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class