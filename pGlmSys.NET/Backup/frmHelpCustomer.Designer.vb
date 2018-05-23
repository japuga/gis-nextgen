<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmHelpCustomer
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
	Public WithEvents txtStore As System.Windows.Forms.TextBox
	Public WithEvents txtVendName As System.Windows.Forms.TextBox
	Public WithEvents txtAccountMask As System.Windows.Forms.TextBox
	Public WithEvents cmdShowAll As System.Windows.Forms.Button
	Public WithEvents cmdFilter As System.Windows.Forms.Button
	Public WithEvents txtStoreAddress As System.Windows.Forms.TextBox
	Public WithEvents txtStoreName As System.Windows.Forms.TextBox
	Public WithEvents txtStoreNumber As System.Windows.Forms.TextBox
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents frStoreFilter As System.Windows.Forms.GroupBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
    Public WithEvents lRecords As System.Windows.Forms.Label
	Public WithEvents lbMessage As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtStore = New System.Windows.Forms.TextBox
        Me.frStoreFilter = New System.Windows.Forms.GroupBox
        Me.txtVendName = New System.Windows.Forms.TextBox
        Me.txtAccountMask = New System.Windows.Forms.TextBox
        Me.cmdShowAll = New System.Windows.Forms.Button
        Me.cmdFilter = New System.Windows.Forms.Button
        Me.txtStoreAddress = New System.Windows.Forms.TextBox
        Me.txtStoreName = New System.Windows.Forms.TextBox
        Me.txtStoreNumber = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.lRecords = New System.Windows.Forms.Label
        Me.lbMessage = New System.Windows.Forms.Label
        Me.dgStore = New System.Windows.Forms.DataGridView
        Me.frStoreFilter.SuspendLayout()
        CType(Me.dgStore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtStore
        '
        Me.txtStore.AcceptsReturn = True
        Me.txtStore.BackColor = System.Drawing.SystemColors.Window
        Me.txtStore.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStore.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStore.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStore.Location = New System.Drawing.Point(224, 128)
        Me.txtStore.MaxLength = 0
        Me.txtStore.Name = "txtStore"
        Me.txtStore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStore.Size = New System.Drawing.Size(233, 20)
        Me.txtStore.TabIndex = 13
        '
        'frStoreFilter
        '
        Me.frStoreFilter.BackColor = System.Drawing.SystemColors.Control
        Me.frStoreFilter.Controls.Add(Me.txtVendName)
        Me.frStoreFilter.Controls.Add(Me.txtAccountMask)
        Me.frStoreFilter.Controls.Add(Me.cmdShowAll)
        Me.frStoreFilter.Controls.Add(Me.cmdFilter)
        Me.frStoreFilter.Controls.Add(Me.txtStoreAddress)
        Me.frStoreFilter.Controls.Add(Me.txtStoreName)
        Me.frStoreFilter.Controls.Add(Me.txtStoreNumber)
        Me.frStoreFilter.Controls.Add(Me.Label5)
        Me.frStoreFilter.Controls.Add(Me.Label1)
        Me.frStoreFilter.Controls.Add(Me.Label4)
        Me.frStoreFilter.Controls.Add(Me.Label3)
        Me.frStoreFilter.Controls.Add(Me.Label2)
        Me.frStoreFilter.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frStoreFilter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frStoreFilter.Location = New System.Drawing.Point(16, 8)
        Me.frStoreFilter.Name = "frStoreFilter"
        Me.frStoreFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frStoreFilter.Size = New System.Drawing.Size(617, 121)
        Me.frStoreFilter.TabIndex = 4
        Me.frStoreFilter.TabStop = False
        Me.frStoreFilter.Text = "Store Filters"
        '
        'txtVendName
        '
        Me.txtVendName.AcceptsReturn = True
        Me.txtVendName.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendName.Location = New System.Drawing.Point(312, 56)
        Me.txtVendName.MaxLength = 0
        Me.txtVendName.Name = "txtVendName"
        Me.txtVendName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendName.Size = New System.Drawing.Size(129, 20)
        Me.txtVendName.TabIndex = 18
        '
        'txtAccountMask
        '
        Me.txtAccountMask.AcceptsReturn = True
        Me.txtAccountMask.BackColor = System.Drawing.SystemColors.Window
        Me.txtAccountMask.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAccountMask.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountMask.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAccountMask.Location = New System.Drawing.Point(312, 24)
        Me.txtAccountMask.MaxLength = 0
        Me.txtAccountMask.Name = "txtAccountMask"
        Me.txtAccountMask.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAccountMask.Size = New System.Drawing.Size(129, 20)
        Me.txtAccountMask.TabIndex = 17
        '
        'cmdShowAll
        '
        Me.cmdShowAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdShowAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdShowAll.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShowAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdShowAll.Location = New System.Drawing.Point(536, 80)
        Me.cmdShowAll.Name = "cmdShowAll"
        Me.cmdShowAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdShowAll.Size = New System.Drawing.Size(65, 25)
        Me.cmdShowAll.TabIndex = 12
        Me.cmdShowAll.Text = "Show All"
        Me.cmdShowAll.UseVisualStyleBackColor = False
        '
        'cmdFilter
        '
        Me.cmdFilter.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFilter.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFilter.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFilter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFilter.Location = New System.Drawing.Point(536, 32)
        Me.cmdFilter.Name = "cmdFilter"
        Me.cmdFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFilter.Size = New System.Drawing.Size(65, 41)
        Me.cmdFilter.TabIndex = 11
        Me.cmdFilter.Text = "Apply Filter"
        Me.cmdFilter.UseVisualStyleBackColor = False
        '
        'txtStoreAddress
        '
        Me.txtStoreAddress.AcceptsReturn = True
        Me.txtStoreAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreAddress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreAddress.Location = New System.Drawing.Point(64, 88)
        Me.txtStoreAddress.MaxLength = 0
        Me.txtStoreAddress.Name = "txtStoreAddress"
        Me.txtStoreAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreAddress.Size = New System.Drawing.Size(177, 20)
        Me.txtStoreAddress.TabIndex = 10
        '
        'txtStoreName
        '
        Me.txtStoreName.AcceptsReturn = True
        Me.txtStoreName.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreName.Location = New System.Drawing.Point(64, 56)
        Me.txtStoreName.MaxLength = 0
        Me.txtStoreName.Name = "txtStoreName"
        Me.txtStoreName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreName.Size = New System.Drawing.Size(113, 20)
        Me.txtStoreName.TabIndex = 9
        '
        'txtStoreNumber
        '
        Me.txtStoreNumber.AcceptsReturn = True
        Me.txtStoreNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreNumber.Location = New System.Drawing.Point(64, 24)
        Me.txtStoreNumber.MaxLength = 0
        Me.txtStoreNumber.Name = "txtStoreNumber"
        Me.txtStoreNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreNumber.Size = New System.Drawing.Size(89, 20)
        Me.txtStoreNumber.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(249, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(48, 20)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Vendor"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(248, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Account"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(6, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(49, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Address"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(6, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Name"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(6, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(75, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Number"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(336, 440)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 33)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(256, 440)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(57, 33)
        Me.cmdOk.TabIndex = 1
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'lRecords
        '
        Me.lRecords.BackColor = System.Drawing.SystemColors.Control
        Me.lRecords.Cursor = System.Windows.Forms.Cursors.Default
        Me.lRecords.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lRecords.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lRecords.Location = New System.Drawing.Point(16, 424)
        Me.lRecords.Name = "lRecords"
        Me.lRecords.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lRecords.Size = New System.Drawing.Size(121, 17)
        Me.lRecords.TabIndex = 14
        Me.lRecords.Text = "Total Records"
        '
        'lbMessage
        '
        Me.lbMessage.BackColor = System.Drawing.SystemColors.Control
        Me.lbMessage.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbMessage.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMessage.ForeColor = System.Drawing.Color.Red
        Me.lbMessage.Location = New System.Drawing.Point(16, 136)
        Me.lbMessage.Name = "lbMessage"
        Me.lbMessage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbMessage.Size = New System.Drawing.Size(169, 17)
        Me.lbMessage.TabIndex = 3
        Me.lbMessage.Text = "Please Choose a Store:"
        '
        'dgStore
        '
        Me.dgStore.AllowUserToAddRows = False
        Me.dgStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgStore.Location = New System.Drawing.Point(12, 180)
        Me.dgStore.Name = "dgStore"
        Me.dgStore.Size = New System.Drawing.Size(616, 241)
        Me.dgStore.TabIndex = 15
        '
        'frmHelpCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(656, 488)
        Me.Controls.Add(Me.dgStore)
        Me.Controls.Add(Me.txtStore)
        Me.Controls.Add(Me.frStoreFilter)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.lRecords)
        Me.Controls.Add(Me.lbMessage)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(326, 185)
        Me.Name = "frmHelpCustomer"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Customer Information"
        Me.frStoreFilter.ResumeLayout(False)
        Me.frStoreFilter.PerformLayout()
        CType(Me.dgStore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgStore As System.Windows.Forms.DataGridView
#End Region 
End Class