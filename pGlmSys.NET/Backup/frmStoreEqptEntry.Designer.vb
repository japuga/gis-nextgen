<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStoreEqptEntry
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
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents txtEqptActualQty As System.Windows.Forms.TextBox
	Public WithEvents txtEqptSizeCapacity As System.Windows.Forms.TextBox
	Public WithEvents txtEqptSize As System.Windows.Forms.TextBox
	Public WithEvents txtEqptDesc As System.Windows.Forms.TextBox
	Public WithEvents cbEqptTempDesc As System.Windows.Forms.ComboBox
	Public WithEvents cbEqptTemp As System.Windows.Forms.ComboBox
	Public WithEvents cmdUpdate As System.Windows.Forms.Button
	Public WithEvents ckbAccount As System.Windows.Forms.CheckBox
	Public WithEvents txtStoreNumber As System.Windows.Forms.TextBox
	Public WithEvents txtCustName As System.Windows.Forms.TextBox
	Public WithEvents cbStatus As System.Windows.Forms.ComboBox
	Public WithEvents cbLoadId As System.Windows.Forms.ComboBox
	Public WithEvents cmdAdd As System.Windows.Forms.Button
    Public WithEvents cbLoadDesc As System.Windows.Forms.ComboBox
	Public WithEvents cbContentDesc As System.Windows.Forms.ComboBox
	Public WithEvents cbEqptDesc As System.Windows.Forms.ComboBox
	Public WithEvents txtEqptQty As System.Windows.Forms.TextBox
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.dgAccountEqpt = New System.Windows.Forms.DataGridView
        Me.txtEqptActualQty = New System.Windows.Forms.TextBox
        Me.txtEqptSizeCapacity = New System.Windows.Forms.TextBox
        Me.txtEqptSize = New System.Windows.Forms.TextBox
        Me.txtEqptDesc = New System.Windows.Forms.TextBox
        Me.cbEqptTempDesc = New System.Windows.Forms.ComboBox
        Me.cbEqptTemp = New System.Windows.Forms.ComboBox
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.ckbAccount = New System.Windows.Forms.CheckBox
        Me.txtStoreNumber = New System.Windows.Forms.TextBox
        Me.txtCustName = New System.Windows.Forms.TextBox
        Me.cbStatus = New System.Windows.Forms.ComboBox
        Me.cbLoadId = New System.Windows.Forms.ComboBox
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cbLoadDesc = New System.Windows.Forms.ComboBox
        Me.cbContentDesc = New System.Windows.Forms.ComboBox
        Me.cbEqptDesc = New System.Windows.Forms.ComboBox
        Me.txtEqptQty = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Frame1.SuspendLayout()
        CType(Me.dgAccountEqpt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(248, 528)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(49, 33)
        Me.cmdCancel.TabIndex = 11
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(168, 528)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(49, 33)
        Me.cmdOk.TabIndex = 10
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.dgAccountEqpt)
        Me.Frame1.Controls.Add(Me.txtEqptActualQty)
        Me.Frame1.Controls.Add(Me.txtEqptSizeCapacity)
        Me.Frame1.Controls.Add(Me.txtEqptSize)
        Me.Frame1.Controls.Add(Me.txtEqptDesc)
        Me.Frame1.Controls.Add(Me.cbEqptTempDesc)
        Me.Frame1.Controls.Add(Me.cbEqptTemp)
        Me.Frame1.Controls.Add(Me.cmdUpdate)
        Me.Frame1.Controls.Add(Me.ckbAccount)
        Me.Frame1.Controls.Add(Me.txtStoreNumber)
        Me.Frame1.Controls.Add(Me.txtCustName)
        Me.Frame1.Controls.Add(Me.cbStatus)
        Me.Frame1.Controls.Add(Me.cbLoadId)
        Me.Frame1.Controls.Add(Me.cmdAdd)
        Me.Frame1.Controls.Add(Me.cbLoadDesc)
        Me.Frame1.Controls.Add(Me.cbContentDesc)
        Me.Frame1.Controls.Add(Me.cbEqptDesc)
        Me.Frame1.Controls.Add(Me.txtEqptQty)
        Me.Frame1.Controls.Add(Me.Label12)
        Me.Frame1.Controls.Add(Me.Label11)
        Me.Frame1.Controls.Add(Me.Label10)
        Me.Frame1.Controls.Add(Me.Label9)
        Me.Frame1.Controls.Add(Me.Label8)
        Me.Frame1.Controls.Add(Me.Label7)
        Me.Frame1.Controls.Add(Me.Label6)
        Me.Frame1.Controls.Add(Me.Label5)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.label3)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(16, 16)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(425, 497)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        '
        'dgAccountEqpt
        '
        Me.dgAccountEqpt.AllowUserToAddRows = False
        Me.dgAccountEqpt.AllowUserToDeleteRows = False
        Me.dgAccountEqpt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAccountEqpt.Location = New System.Drawing.Point(19, 311)
        Me.dgAccountEqpt.Name = "dgAccountEqpt"
        Me.dgAccountEqpt.Size = New System.Drawing.Size(385, 121)
        Me.dgAccountEqpt.TabIndex = 33
        '
        'txtEqptActualQty
        '
        Me.txtEqptActualQty.AcceptsReturn = True
        Me.txtEqptActualQty.BackColor = System.Drawing.SystemColors.Window
        Me.txtEqptActualQty.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEqptActualQty.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEqptActualQty.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEqptActualQty.Location = New System.Drawing.Point(272, 184)
        Me.txtEqptActualQty.MaxLength = 0
        Me.txtEqptActualQty.Name = "txtEqptActualQty"
        Me.txtEqptActualQty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEqptActualQty.Size = New System.Drawing.Size(105, 20)
        Me.txtEqptActualQty.TabIndex = 32
        '
        'txtEqptSizeCapacity
        '
        Me.txtEqptSizeCapacity.AcceptsReturn = True
        Me.txtEqptSizeCapacity.BackColor = System.Drawing.SystemColors.Window
        Me.txtEqptSizeCapacity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEqptSizeCapacity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEqptSizeCapacity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEqptSizeCapacity.Location = New System.Drawing.Point(304, 88)
        Me.txtEqptSizeCapacity.MaxLength = 0
        Me.txtEqptSizeCapacity.Name = "txtEqptSizeCapacity"
        Me.txtEqptSizeCapacity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEqptSizeCapacity.Size = New System.Drawing.Size(73, 20)
        Me.txtEqptSizeCapacity.TabIndex = 30
        '
        'txtEqptSize
        '
        Me.txtEqptSize.AcceptsReturn = True
        Me.txtEqptSize.BackColor = System.Drawing.SystemColors.Window
        Me.txtEqptSize.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEqptSize.Enabled = False
        Me.txtEqptSize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEqptSize.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEqptSize.Location = New System.Drawing.Point(304, 56)
        Me.txtEqptSize.MaxLength = 0
        Me.txtEqptSize.Name = "txtEqptSize"
        Me.txtEqptSize.ReadOnly = True
        Me.txtEqptSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEqptSize.Size = New System.Drawing.Size(73, 20)
        Me.txtEqptSize.TabIndex = 29
        '
        'txtEqptDesc
        '
        Me.txtEqptDesc.AcceptsReturn = True
        Me.txtEqptDesc.BackColor = System.Drawing.SystemColors.Window
        Me.txtEqptDesc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEqptDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEqptDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEqptDesc.Location = New System.Drawing.Point(88, 88)
        Me.txtEqptDesc.MaxLength = 0
        Me.txtEqptDesc.Name = "txtEqptDesc"
        Me.txtEqptDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEqptDesc.Size = New System.Drawing.Size(121, 20)
        Me.txtEqptDesc.TabIndex = 28
        '
        'cbEqptTempDesc
        '
        Me.cbEqptTempDesc.BackColor = System.Drawing.SystemColors.Window
        Me.cbEqptTempDesc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbEqptTempDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEqptTempDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEqptTempDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbEqptTempDesc.Location = New System.Drawing.Point(88, 256)
        Me.cbEqptTempDesc.Name = "cbEqptTempDesc"
        Me.cbEqptTempDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbEqptTempDesc.Size = New System.Drawing.Size(105, 22)
        Me.cbEqptTempDesc.TabIndex = 6
        '
        'cbEqptTemp
        '
        Me.cbEqptTemp.BackColor = System.Drawing.SystemColors.Window
        Me.cbEqptTemp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbEqptTemp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEqptTemp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEqptTemp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbEqptTemp.Location = New System.Drawing.Point(208, 256)
        Me.cbEqptTemp.Name = "cbEqptTemp"
        Me.cbEqptTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbEqptTemp.Size = New System.Drawing.Size(105, 22)
        Me.cbEqptTemp.TabIndex = 24
        Me.cbEqptTemp.Visible = False
        '
        'cmdUpdate
        '
        Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUpdate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUpdate.Location = New System.Drawing.Point(112, 456)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUpdate.Size = New System.Drawing.Size(89, 25)
        Me.cmdUpdate.TabIndex = 9
        Me.cmdUpdate.Text = "Update Account"
        Me.cmdUpdate.UseVisualStyleBackColor = False
        '
        'ckbAccount
        '
        Me.ckbAccount.BackColor = System.Drawing.SystemColors.Control
        Me.ckbAccount.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbAccount.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckbAccount.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbAccount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckbAccount.Location = New System.Drawing.Point(16, 288)
        Me.ckbAccount.Name = "ckbAccount"
        Me.ckbAccount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckbAccount.Size = New System.Drawing.Size(169, 17)
        Me.ckbAccount.TabIndex = 22
        Me.ckbAccount.Text = "Show Inactive Accounts"
        Me.ckbAccount.UseVisualStyleBackColor = False
        '
        'txtStoreNumber
        '
        Me.txtStoreNumber.AcceptsReturn = True
        Me.txtStoreNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreNumber.Enabled = False
        Me.txtStoreNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreNumber.Location = New System.Drawing.Point(304, 24)
        Me.txtStoreNumber.MaxLength = 0
        Me.txtStoreNumber.Name = "txtStoreNumber"
        Me.txtStoreNumber.ReadOnly = True
        Me.txtStoreNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreNumber.Size = New System.Drawing.Size(105, 20)
        Me.txtStoreNumber.TabIndex = 21
        '
        'txtCustName
        '
        Me.txtCustName.AcceptsReturn = True
        Me.txtCustName.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustName.Enabled = False
        Me.txtCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustName.Location = New System.Drawing.Point(88, 24)
        Me.txtCustName.MaxLength = 0
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.ReadOnly = True
        Me.txtCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCustName.Size = New System.Drawing.Size(105, 20)
        Me.txtCustName.TabIndex = 19
        '
        'cbStatus
        '
        Me.cbStatus.BackColor = System.Drawing.SystemColors.Window
        Me.cbStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbStatus.Location = New System.Drawing.Point(88, 216)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbStatus.Size = New System.Drawing.Size(105, 22)
        Me.cbStatus.TabIndex = 5
        '
        'cbLoadId
        '
        Me.cbLoadId.BackColor = System.Drawing.SystemColors.Window
        Me.cbLoadId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbLoadId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLoadId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLoadId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbLoadId.Location = New System.Drawing.Point(208, 152)
        Me.cbLoadId.Name = "cbLoadId"
        Me.cbLoadId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbLoadId.Size = New System.Drawing.Size(81, 22)
        Me.cbLoadId.TabIndex = 16
        Me.cbLoadId.Visible = False
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAdd.Location = New System.Drawing.Point(16, 456)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAdd.Size = New System.Drawing.Size(89, 25)
        Me.cmdAdd.TabIndex = 8
        Me.cmdAdd.Text = "Add Account"
        Me.cmdAdd.UseVisualStyleBackColor = False
        '
        'cbLoadDesc
        '
        Me.cbLoadDesc.BackColor = System.Drawing.SystemColors.Window
        Me.cbLoadDesc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbLoadDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLoadDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLoadDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbLoadDesc.Location = New System.Drawing.Point(88, 152)
        Me.cbLoadDesc.Name = "cbLoadDesc"
        Me.cbLoadDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbLoadDesc.Size = New System.Drawing.Size(105, 22)
        Me.cbLoadDesc.TabIndex = 3
        '
        'cbContentDesc
        '
        Me.cbContentDesc.BackColor = System.Drawing.SystemColors.Window
        Me.cbContentDesc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbContentDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbContentDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbContentDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbContentDesc.Location = New System.Drawing.Point(88, 120)
        Me.cbContentDesc.Name = "cbContentDesc"
        Me.cbContentDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbContentDesc.Size = New System.Drawing.Size(289, 22)
        Me.cbContentDesc.TabIndex = 2
        '
        'cbEqptDesc
        '
        Me.cbEqptDesc.BackColor = System.Drawing.SystemColors.Window
        Me.cbEqptDesc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbEqptDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEqptDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEqptDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbEqptDesc.Location = New System.Drawing.Point(88, 56)
        Me.cbEqptDesc.Name = "cbEqptDesc"
        Me.cbEqptDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbEqptDesc.Size = New System.Drawing.Size(105, 22)
        Me.cbEqptDesc.TabIndex = 1
        '
        'txtEqptQty
        '
        Me.txtEqptQty.AcceptsReturn = True
        Me.txtEqptQty.BackColor = System.Drawing.SystemColors.Window
        Me.txtEqptQty.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEqptQty.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEqptQty.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEqptQty.Location = New System.Drawing.Point(88, 184)
        Me.txtEqptQty.MaxLength = 0
        Me.txtEqptQty.Name = "txtEqptQty"
        Me.txtEqptQty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEqptQty.Size = New System.Drawing.Size(105, 20)
        Me.txtEqptQty.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(208, 184)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(57, 17)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Actual Qty"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(224, 90)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(82, 18)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Real Capacity"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(224, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(49, 17)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Capacity"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(16, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(65, 17)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Description"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 258)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(49, 17)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Type"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(224, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(73, 17)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Store"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(15, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(67, 17)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Customer"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 218)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(57, 17)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Status"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 186)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Qty"
        '
        'label3
        '
        Me.label3.BackColor = System.Drawing.SystemColors.Control
        Me.label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label3.Location = New System.Drawing.Point(16, 156)
        Me.label3.Name = "label3"
        Me.label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label3.Size = New System.Drawing.Size(57, 17)
        Me.label3.TabIndex = 14
        Me.label3.Text = "Load"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Equipment"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Content"
        '
        'frmStoreEqptEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(465, 592)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 96)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStoreEqptEntry"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Equipment"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        CType(Me.dgAccountEqpt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgAccountEqpt As System.Windows.Forms.DataGridView
#End Region 
End Class