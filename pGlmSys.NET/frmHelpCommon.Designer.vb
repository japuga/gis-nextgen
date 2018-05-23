<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmHelpCommon
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
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
	Public WithEvents txtStoreZip As System.Windows.Forms.TextBox
	Public WithEvents cbState As System.Windows.Forms.ComboBox
	Public WithEvents txtStoreCity As System.Windows.Forms.TextBox
	Public WithEvents txtStoreNumber As System.Windows.Forms.TextBox
	Public WithEvents txtStoreName As System.Windows.Forms.TextBox
	Public WithEvents txtStoreAddress As System.Windows.Forms.TextBox
	Public WithEvents cmdFilter As System.Windows.Forms.Button
	Public WithEvents cmdShowAll As System.Windows.Forms.Button
	Public WithEvents txtAccountMask As System.Windows.Forms.TextBox
	Public WithEvents txtVendName As System.Windows.Forms.TextBox
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents frStoreFilter As System.Windows.Forms.GroupBox
    Public WithEvents lRecords As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.frStoreFilter = New System.Windows.Forms.GroupBox
        Me.cbCustId = New System.Windows.Forms.ComboBox
        Me.cbCustName = New System.Windows.Forms.ComboBox
        Me.txtStoreZip = New System.Windows.Forms.TextBox
        Me.cbState = New System.Windows.Forms.ComboBox
        Me.txtStoreCity = New System.Windows.Forms.TextBox
        Me.txtStoreNumber = New System.Windows.Forms.TextBox
        Me.txtStoreName = New System.Windows.Forms.TextBox
        Me.txtStoreAddress = New System.Windows.Forms.TextBox
        Me.cmdFilter = New System.Windows.Forms.Button
        Me.cmdShowAll = New System.Windows.Forms.Button
        Me.txtAccountMask = New System.Windows.Forms.TextBox
        Me.txtVendName = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lRecords = New System.Windows.Forms.Label
        Me.dgStore = New System.Windows.Forms.DataGridView
        Me.frStoreFilter.SuspendLayout()
        CType(Me.dgStore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(296, 496)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(89, 33)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "Close"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'frStoreFilter
        '
        Me.frStoreFilter.BackColor = System.Drawing.SystemColors.Control
        Me.frStoreFilter.Controls.Add(Me.cbCustId)
        Me.frStoreFilter.Controls.Add(Me.cbCustName)
        Me.frStoreFilter.Controls.Add(Me.txtStoreZip)
        Me.frStoreFilter.Controls.Add(Me.cbState)
        Me.frStoreFilter.Controls.Add(Me.txtStoreCity)
        Me.frStoreFilter.Controls.Add(Me.txtStoreNumber)
        Me.frStoreFilter.Controls.Add(Me.txtStoreName)
        Me.frStoreFilter.Controls.Add(Me.txtStoreAddress)
        Me.frStoreFilter.Controls.Add(Me.cmdFilter)
        Me.frStoreFilter.Controls.Add(Me.cmdShowAll)
        Me.frStoreFilter.Controls.Add(Me.txtAccountMask)
        Me.frStoreFilter.Controls.Add(Me.txtVendName)
        Me.frStoreFilter.Controls.Add(Me.Label9)
        Me.frStoreFilter.Controls.Add(Me.Label8)
        Me.frStoreFilter.Controls.Add(Me.Label7)
        Me.frStoreFilter.Controls.Add(Me.Label6)
        Me.frStoreFilter.Controls.Add(Me.Label2)
        Me.frStoreFilter.Controls.Add(Me.Label3)
        Me.frStoreFilter.Controls.Add(Me.Label4)
        Me.frStoreFilter.Controls.Add(Me.Label1)
        Me.frStoreFilter.Controls.Add(Me.Label5)
        Me.frStoreFilter.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frStoreFilter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frStoreFilter.Location = New System.Drawing.Point(24, 16)
        Me.frStoreFilter.Name = "frStoreFilter"
        Me.frStoreFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frStoreFilter.Size = New System.Drawing.Size(617, 185)
        Me.frStoreFilter.TabIndex = 0
        Me.frStoreFilter.TabStop = False
        Me.frStoreFilter.Text = "Criteria"
        '
        'cbCustId
        '
        Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustId.Location = New System.Drawing.Point(272, 16)
        Me.cbCustId.Name = "cbCustId"
        Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustId.Size = New System.Drawing.Size(185, 22)
        Me.cbCustId.TabIndex = 24
        Me.cbCustId.Visible = False
        '
        'cbCustName
        '
        Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustName.Location = New System.Drawing.Point(72, 16)
        Me.cbCustName.Name = "cbCustName"
        Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustName.Size = New System.Drawing.Size(169, 22)
        Me.cbCustName.TabIndex = 23
        '
        'txtStoreZip
        '
        Me.txtStoreZip.AcceptsReturn = True
        Me.txtStoreZip.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreZip.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreZip.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreZip.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreZip.Location = New System.Drawing.Point(312, 144)
        Me.txtStoreZip.MaxLength = 0
        Me.txtStoreZip.Name = "txtStoreZip"
        Me.txtStoreZip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreZip.Size = New System.Drawing.Size(129, 20)
        Me.txtStoreZip.TabIndex = 21
        '
        'cbState
        '
        Me.cbState.BackColor = System.Drawing.SystemColors.Window
        Me.cbState.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbState.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbState.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbState.Location = New System.Drawing.Point(312, 112)
        Me.cbState.Name = "cbState"
        Me.cbState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbState.Size = New System.Drawing.Size(137, 22)
        Me.cbState.TabIndex = 19
        '
        'txtStoreCity
        '
        Me.txtStoreCity.AcceptsReturn = True
        Me.txtStoreCity.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreCity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreCity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreCity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreCity.Location = New System.Drawing.Point(72, 144)
        Me.txtStoreCity.MaxLength = 0
        Me.txtStoreCity.Name = "txtStoreCity"
        Me.txtStoreCity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreCity.Size = New System.Drawing.Size(161, 20)
        Me.txtStoreCity.TabIndex = 17
        '
        'txtStoreNumber
        '
        Me.txtStoreNumber.AcceptsReturn = True
        Me.txtStoreNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreNumber.Location = New System.Drawing.Point(72, 48)
        Me.txtStoreNumber.MaxLength = 0
        Me.txtStoreNumber.Name = "txtStoreNumber"
        Me.txtStoreNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreNumber.Size = New System.Drawing.Size(89, 20)
        Me.txtStoreNumber.TabIndex = 7
        '
        'txtStoreName
        '
        Me.txtStoreName.AcceptsReturn = True
        Me.txtStoreName.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreName.Location = New System.Drawing.Point(72, 80)
        Me.txtStoreName.MaxLength = 0
        Me.txtStoreName.Name = "txtStoreName"
        Me.txtStoreName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreName.Size = New System.Drawing.Size(113, 20)
        Me.txtStoreName.TabIndex = 6
        '
        'txtStoreAddress
        '
        Me.txtStoreAddress.AcceptsReturn = True
        Me.txtStoreAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreAddress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreAddress.Location = New System.Drawing.Point(72, 112)
        Me.txtStoreAddress.MaxLength = 0
        Me.txtStoreAddress.Name = "txtStoreAddress"
        Me.txtStoreAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreAddress.Size = New System.Drawing.Size(177, 20)
        Me.txtStoreAddress.TabIndex = 5
        '
        'cmdFilter
        '
        Me.cmdFilter.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFilter.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFilter.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFilter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFilter.Location = New System.Drawing.Point(536, 19)
        Me.cmdFilter.Name = "cmdFilter"
        Me.cmdFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFilter.Size = New System.Drawing.Size(65, 46)
        Me.cmdFilter.TabIndex = 4
        Me.cmdFilter.Text = "Apply Filter"
        Me.cmdFilter.UseVisualStyleBackColor = False
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
        Me.cmdShowAll.TabIndex = 3
        Me.cmdShowAll.Text = "Show All"
        Me.cmdShowAll.UseVisualStyleBackColor = False
        '
        'txtAccountMask
        '
        Me.txtAccountMask.AcceptsReturn = True
        Me.txtAccountMask.BackColor = System.Drawing.SystemColors.Window
        Me.txtAccountMask.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAccountMask.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountMask.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAccountMask.Location = New System.Drawing.Point(312, 48)
        Me.txtAccountMask.MaxLength = 0
        Me.txtAccountMask.Name = "txtAccountMask"
        Me.txtAccountMask.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAccountMask.Size = New System.Drawing.Size(129, 20)
        Me.txtAccountMask.TabIndex = 2
        '
        'txtVendName
        '
        Me.txtVendName.AcceptsReturn = True
        Me.txtVendName.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendName.Location = New System.Drawing.Point(312, 80)
        Me.txtVendName.MaxLength = 0
        Me.txtVendName.Name = "txtVendName"
        Me.txtVendName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendName.Size = New System.Drawing.Size(129, 20)
        Me.txtVendName.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(16, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(57, 17)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Customer"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(256, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(33, 17)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Zip"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(256, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(49, 17)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "State"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(33, 17)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "City"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(65, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Number"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Name"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(49, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Address"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(256, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Account"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(256, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(41, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Vendor"
        '
        'lRecords
        '
        Me.lRecords.BackColor = System.Drawing.SystemColors.Control
        Me.lRecords.Cursor = System.Windows.Forms.Cursors.Default
        Me.lRecords.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lRecords.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lRecords.Location = New System.Drawing.Point(16, 480)
        Me.lRecords.Name = "lRecords"
        Me.lRecords.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lRecords.Size = New System.Drawing.Size(121, 17)
        Me.lRecords.TabIndex = 15
        Me.lRecords.Text = "Total Records"
        '
        'dgStore
        '
        Me.dgStore.AllowUserToAddRows = False
        Me.dgStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgStore.Location = New System.Drawing.Point(24, 233)
        Me.dgStore.Name = "dgStore"
        Me.dgStore.Size = New System.Drawing.Size(617, 244)
        Me.dgStore.TabIndex = 16
        '
        'frmHelpCommon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(672, 548)
        Me.Controls.Add(Me.dgStore)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.frStoreFilter)
        Me.Controls.Add(Me.lRecords)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "frmHelpCommon"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Store Lookup"
        Me.frStoreFilter.ResumeLayout(False)
        Me.frStoreFilter.PerformLayout()
        CType(Me.dgStore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgStore As System.Windows.Forms.DataGridView
#End Region 
End Class