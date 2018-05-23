<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCheckBatch
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
	Public WithEvents cmdShowVBranch As System.Windows.Forms.Button
	Public WithEvents obSelectedBranches As System.Windows.Forms.RadioButton
	Public WithEvents obAllBranches As System.Windows.Forms.RadioButton
	Public WithEvents cbVendor As System.Windows.Forms.ComboBox
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents ckZeroedInvoice As System.Windows.Forms.CheckBox
	Public WithEvents ckPeriod As System.Windows.Forms.CheckBox
	Public WithEvents cbPeriodStart As System.Windows.Forms.ComboBox
	Public WithEvents cbPeriodEnd As System.Windows.Forms.ComboBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents lbPeriodStartDate As System.Windows.Forms.Label
	Public WithEvents lbPeriodEndDate As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents txtCheckNo As System.Windows.Forms.TextBox
	Public WithEvents cbBankName As System.Windows.Forms.ComboBox
	Public WithEvents cbBankAccount As System.Windows.Forms.ComboBox
	Public WithEvents txtDetail1 As System.Windows.Forms.TextBox
	Public WithEvents txtDetail2 As System.Windows.Forms.TextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents label5 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents label9 As System.Windows.Forms.Label
	Public WithEvents frBatch As System.Windows.Forms.GroupBox
	Public WithEvents cmdAbort As System.Windows.Forms.Button
	Public WithEvents cmdSavePrint As System.Windows.Forms.Button
	Public WithEvents cmdSave As System.Windows.Forms.Button
	Public WithEvents picLogo As System.Windows.Forms.PictureBox
	Public WithEvents _sbBatch_Panel1 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents sbBatch As System.Windows.Forms.StatusStrip
	Public WithEvents cmdBatch As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheckBatch))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.frBatch = New System.Windows.Forms.GroupBox
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.cmdShowVBranch = New System.Windows.Forms.Button
        Me.obSelectedBranches = New System.Windows.Forms.RadioButton
        Me.obAllBranches = New System.Windows.Forms.RadioButton
        Me.cbVendor = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.ckZeroedInvoice = New System.Windows.Forms.CheckBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.ckPeriod = New System.Windows.Forms.CheckBox
        Me.cbPeriodStart = New System.Windows.Forms.ComboBox
        Me.cbPeriodEnd = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbPeriodStartDate = New System.Windows.Forms.Label
        Me.lbPeriodEndDate = New System.Windows.Forms.Label
        Me.cbCustName = New System.Windows.Forms.ComboBox
        Me.cbCustId = New System.Windows.Forms.ComboBox
        Me.txtCheckNo = New System.Windows.Forms.TextBox
        Me.cbBankName = New System.Windows.Forms.ComboBox
        Me.cbBankAccount = New System.Windows.Forms.ComboBox
        Me.txtDetail1 = New System.Windows.Forms.TextBox
        Me.txtDetail2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.cmdAbort = New System.Windows.Forms.Button
        Me.cmdSavePrint = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.picLogo = New System.Windows.Forms.PictureBox
        Me.sbBatch = New System.Windows.Forms.StatusStrip
        Me._sbBatch_Panel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.cmdBatch = New System.Windows.Forms.Button
        Me.cmdClose = New System.Windows.Forms.Button
        Me.frBatch.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sbBatch.SuspendLayout()
        Me.SuspendLayout()
        '
        'frBatch
        '
        Me.frBatch.BackColor = System.Drawing.SystemColors.Control
        Me.frBatch.Controls.Add(Me.Frame2)
        Me.frBatch.Controls.Add(Me.ckZeroedInvoice)
        Me.frBatch.Controls.Add(Me.Frame1)
        Me.frBatch.Controls.Add(Me.cbCustName)
        Me.frBatch.Controls.Add(Me.cbCustId)
        Me.frBatch.Controls.Add(Me.txtCheckNo)
        Me.frBatch.Controls.Add(Me.cbBankName)
        Me.frBatch.Controls.Add(Me.cbBankAccount)
        Me.frBatch.Controls.Add(Me.txtDetail1)
        Me.frBatch.Controls.Add(Me.txtDetail2)
        Me.frBatch.Controls.Add(Me.Label1)
        Me.frBatch.Controls.Add(Me.Label2)
        Me.frBatch.Controls.Add(Me.label5)
        Me.frBatch.Controls.Add(Me.Label6)
        Me.frBatch.Controls.Add(Me.label9)
        Me.frBatch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frBatch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frBatch.Location = New System.Drawing.Point(16, 8)
        Me.frBatch.Name = "frBatch"
        Me.frBatch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frBatch.Size = New System.Drawing.Size(649, 361)
        Me.frBatch.TabIndex = 8
        Me.frBatch.TabStop = False
        Me.frBatch.Text = "Select Options"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.cmdShowVBranch)
        Me.Frame2.Controls.Add(Me.obSelectedBranches)
        Me.Frame2.Controls.Add(Me.obAllBranches)
        Me.Frame2.Controls.Add(Me.cbVendor)
        Me.Frame2.Controls.Add(Me.Label7)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(344, 128)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(281, 121)
        Me.Frame2.TabIndex = 29
        Me.Frame2.TabStop = False
        '
        'cmdShowVBranch
        '
        Me.cmdShowVBranch.BackColor = System.Drawing.SystemColors.Control
        Me.cmdShowVBranch.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdShowVBranch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShowVBranch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdShowVBranch.Location = New System.Drawing.Point(160, 84)
        Me.cmdShowVBranch.Name = "cmdShowVBranch"
        Me.cmdShowVBranch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdShowVBranch.Size = New System.Drawing.Size(73, 25)
        Me.cmdShowVBranch.TabIndex = 34
        Me.cmdShowVBranch.Text = "List"
        Me.cmdShowVBranch.UseVisualStyleBackColor = False
        '
        'obSelectedBranches
        '
        Me.obSelectedBranches.BackColor = System.Drawing.SystemColors.Control
        Me.obSelectedBranches.Cursor = System.Windows.Forms.Cursors.Default
        Me.obSelectedBranches.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obSelectedBranches.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obSelectedBranches.Location = New System.Drawing.Point(48, 88)
        Me.obSelectedBranches.Name = "obSelectedBranches"
        Me.obSelectedBranches.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obSelectedBranches.Size = New System.Drawing.Size(169, 17)
        Me.obSelectedBranches.TabIndex = 32
        Me.obSelectedBranches.TabStop = True
        Me.obSelectedBranches.Text = "Select  Branches"
        Me.obSelectedBranches.UseVisualStyleBackColor = False
        '
        'obAllBranches
        '
        Me.obAllBranches.BackColor = System.Drawing.SystemColors.Control
        Me.obAllBranches.Cursor = System.Windows.Forms.Cursors.Default
        Me.obAllBranches.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obAllBranches.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obAllBranches.Location = New System.Drawing.Point(48, 64)
        Me.obAllBranches.Name = "obAllBranches"
        Me.obAllBranches.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obAllBranches.Size = New System.Drawing.Size(185, 17)
        Me.obAllBranches.TabIndex = 31
        Me.obAllBranches.TabStop = True
        Me.obAllBranches.Text = "All Vendor Branches"
        Me.obAllBranches.UseVisualStyleBackColor = False
        '
        'cbVendor
        '
        Me.cbVendor.BackColor = System.Drawing.SystemColors.Window
        Me.cbVendor.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVendor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVendor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbVendor.Location = New System.Drawing.Point(16, 32)
        Me.cbVendor.Name = "cbVendor"
        Me.cbVendor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbVendor.Size = New System.Drawing.Size(257, 22)
        Me.cbVendor.TabIndex = 30
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
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Vendor"
        '
        'ckZeroedInvoice
        '
        Me.ckZeroedInvoice.BackColor = System.Drawing.SystemColors.Control
        Me.ckZeroedInvoice.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckZeroedInvoice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckZeroedInvoice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckZeroedInvoice.Location = New System.Drawing.Point(16, 64)
        Me.ckZeroedInvoice.Name = "ckZeroedInvoice"
        Me.ckZeroedInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckZeroedInvoice.Size = New System.Drawing.Size(281, 17)
        Me.ckZeroedInvoice.TabIndex = 28
        Me.ckZeroedInvoice.Text = "Update status in Invoices with Zero balance"
        Me.ckZeroedInvoice.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.ckPeriod)
        Me.Frame1.Controls.Add(Me.cbPeriodStart)
        Me.Frame1.Controls.Add(Me.cbPeriodEnd)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.lbPeriodStartDate)
        Me.Frame1.Controls.Add(Me.lbPeriodEndDate)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(16, 88)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(289, 145)
        Me.Frame1.TabIndex = 15
        Me.Frame1.TabStop = False
        '
        'ckPeriod
        '
        Me.ckPeriod.BackColor = System.Drawing.SystemColors.Control
        Me.ckPeriod.Checked = True
        Me.ckPeriod.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckPeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckPeriod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPeriod.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckPeriod.Location = New System.Drawing.Point(16, 16)
        Me.ckPeriod.Name = "ckPeriod"
        Me.ckPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckPeriod.Size = New System.Drawing.Size(129, 17)
        Me.ckPeriod.TabIndex = 18
        Me.ckPeriod.Text = "Apply Invoice Period"
        Me.ckPeriod.UseVisualStyleBackColor = False
        '
        'cbPeriodStart
        '
        Me.cbPeriodStart.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriodStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbPeriodStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodStart.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriodStart.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbPeriodStart.Location = New System.Drawing.Point(104, 40)
        Me.cbPeriodStart.Name = "cbPeriodStart"
        Me.cbPeriodStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbPeriodStart.Size = New System.Drawing.Size(161, 22)
        Me.cbPeriodStart.TabIndex = 17
        '
        'cbPeriodEnd
        '
        Me.cbPeriodEnd.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriodEnd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbPeriodEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodEnd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriodEnd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbPeriodEnd.Location = New System.Drawing.Point(104, 72)
        Me.cbPeriodEnd.Name = "cbPeriodEnd"
        Me.cbPeriodEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbPeriodEnd.Size = New System.Drawing.Size(161, 22)
        Me.cbPeriodEnd.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(81, 22)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Start Period"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(19, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(70, 22)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "End Period"
        '
        'lbPeriodStartDate
        '
        Me.lbPeriodStartDate.BackColor = System.Drawing.SystemColors.Control
        Me.lbPeriodStartDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbPeriodStartDate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPeriodStartDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbPeriodStartDate.Location = New System.Drawing.Point(22, 112)
        Me.lbPeriodStartDate.Name = "lbPeriodStartDate"
        Me.lbPeriodStartDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbPeriodStartDate.Size = New System.Drawing.Size(83, 17)
        Me.lbPeriodStartDate.TabIndex = 20
        Me.lbPeriodStartDate.Text = "Start"
        '
        'lbPeriodEndDate
        '
        Me.lbPeriodEndDate.BackColor = System.Drawing.SystemColors.Control
        Me.lbPeriodEndDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbPeriodEndDate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPeriodEndDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbPeriodEndDate.Location = New System.Drawing.Point(136, 112)
        Me.lbPeriodEndDate.Name = "lbPeriodEndDate"
        Me.lbPeriodEndDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbPeriodEndDate.Size = New System.Drawing.Size(73, 17)
        Me.lbPeriodEndDate.TabIndex = 19
        Me.lbPeriodEndDate.Text = "End"
        '
        'cbCustName
        '
        Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustName.Location = New System.Drawing.Point(72, 24)
        Me.cbCustName.Name = "cbCustName"
        Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustName.Size = New System.Drawing.Size(225, 22)
        Me.cbCustName.TabIndex = 1
        '
        'cbCustId
        '
        Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustId.Location = New System.Drawing.Point(296, 24)
        Me.cbCustId.Name = "cbCustId"
        Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustId.Size = New System.Drawing.Size(49, 22)
        Me.cbCustId.TabIndex = 14
        Me.cbCustId.Visible = False
        '
        'txtCheckNo
        '
        Me.txtCheckNo.AcceptsReturn = True
        Me.txtCheckNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtCheckNo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCheckNo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheckNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCheckNo.Location = New System.Drawing.Point(472, 104)
        Me.txtCheckNo.MaxLength = 0
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCheckNo.Size = New System.Drawing.Size(145, 20)
        Me.txtCheckNo.TabIndex = 13
        '
        'cbBankName
        '
        Me.cbBankName.BackColor = System.Drawing.SystemColors.Window
        Me.cbBankName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBankName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBankName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbBankName.Location = New System.Drawing.Point(472, 24)
        Me.cbBankName.Name = "cbBankName"
        Me.cbBankName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbBankName.Size = New System.Drawing.Size(145, 22)
        Me.cbBankName.TabIndex = 12
        '
        'cbBankAccount
        '
        Me.cbBankAccount.BackColor = System.Drawing.SystemColors.Window
        Me.cbBankAccount.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbBankAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBankAccount.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBankAccount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbBankAccount.Location = New System.Drawing.Point(472, 64)
        Me.cbBankAccount.Name = "cbBankAccount"
        Me.cbBankAccount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbBankAccount.Size = New System.Drawing.Size(145, 22)
        Me.cbBankAccount.TabIndex = 11
        '
        'txtDetail1
        '
        Me.txtDetail1.AcceptsReturn = True
        Me.txtDetail1.BackColor = System.Drawing.SystemColors.Window
        Me.txtDetail1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDetail1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDetail1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDetail1.Location = New System.Drawing.Point(16, 264)
        Me.txtDetail1.MaxLength = 0
        Me.txtDetail1.Name = "txtDetail1"
        Me.txtDetail1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDetail1.Size = New System.Drawing.Size(505, 20)
        Me.txtDetail1.TabIndex = 10
        '
        'txtDetail2
        '
        Me.txtDetail2.AcceptsReturn = True
        Me.txtDetail2.BackColor = System.Drawing.SystemColors.Window
        Me.txtDetail2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDetail2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDetail2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDetail2.Location = New System.Drawing.Point(16, 304)
        Me.txtDetail2.MaxLength = 0
        Me.txtDetail2.Name = "txtDetail2"
        Me.txtDetail2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDetail2.Size = New System.Drawing.Size(505, 20)
        Me.txtDetail2.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(66, 17)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Customer"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(360, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(41, 17)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Bank"
        '
        'label5
        '
        Me.label5.BackColor = System.Drawing.SystemColors.Control
        Me.label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label5.Location = New System.Drawing.Point(360, 64)
        Me.label5.Name = "label5"
        Me.label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label5.Size = New System.Drawing.Size(49, 17)
        Me.label5.TabIndex = 25
        Me.label5.Text = "Account"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(360, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(106, 21)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Begining Check No"
        '
        'label9
        '
        Me.label9.BackColor = System.Drawing.SystemColors.Control
        Me.label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label9.Location = New System.Drawing.Point(16, 248)
        Me.label9.Name = "label9"
        Me.label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label9.Size = New System.Drawing.Size(89, 17)
        Me.label9.TabIndex = 23
        Me.label9.Text = "Check Foot Note"
        '
        'cmdAbort
        '
        Me.cmdAbort.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAbort.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAbort.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAbort.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAbort.Location = New System.Drawing.Point(312, 384)
        Me.cmdAbort.Name = "cmdAbort"
        Me.cmdAbort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAbort.Size = New System.Drawing.Size(73, 41)
        Me.cmdAbort.TabIndex = 7
        Me.cmdAbort.Text = "Abort"
        Me.cmdAbort.UseVisualStyleBackColor = False
        '
        'cmdSavePrint
        '
        Me.cmdSavePrint.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSavePrint.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSavePrint.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSavePrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSavePrint.Location = New System.Drawing.Point(216, 384)
        Me.cmdSavePrint.Name = "cmdSavePrint"
        Me.cmdSavePrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSavePrint.Size = New System.Drawing.Size(73, 41)
        Me.cmdSavePrint.TabIndex = 6
        Me.cmdSavePrint.Text = "Save and Print"
        Me.cmdSavePrint.UseVisualStyleBackColor = False
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.Location = New System.Drawing.Point(120, 384)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSave.Size = New System.Drawing.Size(73, 41)
        Me.cmdSave.TabIndex = 5
        Me.cmdSave.Text = "Save Only"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'picLogo
        '
        Me.picLogo.BackColor = System.Drawing.SystemColors.Control
        Me.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLogo.Cursor = System.Windows.Forms.Cursors.Default
        Me.picLogo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.picLogo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.Location = New System.Drawing.Point(528, 360)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picLogo.Size = New System.Drawing.Size(100, 89)
        Me.picLogo.TabIndex = 2
        Me.picLogo.TabStop = False
        '
        'sbBatch
        '
        Me.sbBatch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sbBatch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._sbBatch_Panel1})
        Me.sbBatch.Location = New System.Drawing.Point(0, 447)
        Me.sbBatch.Name = "sbBatch"
        Me.sbBatch.Size = New System.Drawing.Size(671, 25)
        Me.sbBatch.TabIndex = 0
        '
        '_sbBatch_Panel1
        '
        Me._sbBatch_Panel1.AutoSize = False
        Me._sbBatch_Panel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._sbBatch_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._sbBatch_Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me._sbBatch_Panel1.Name = "_sbBatch_Panel1"
        Me._sbBatch_Panel1.Size = New System.Drawing.Size(96, 25)
        Me._sbBatch_Panel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdBatch
        '
        Me.cmdBatch.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBatch.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBatch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBatch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBatch.Location = New System.Drawing.Point(24, 384)
        Me.cmdBatch.Name = "cmdBatch"
        Me.cmdBatch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBatch.Size = New System.Drawing.Size(73, 41)
        Me.cmdBatch.TabIndex = 4
        Me.cmdBatch.Text = "Run Batch"
        Me.cmdBatch.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(408, 384)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(73, 41)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'frmCheckBatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(671, 472)
        Me.Controls.Add(Me.frBatch)
        Me.Controls.Add(Me.cmdAbort)
        Me.Controls.Add(Me.cmdSavePrint)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.sbBatch)
        Me.Controls.Add(Me.cmdBatch)
        Me.Controls.Add(Me.cmdClose)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmCheckBatch"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Batch Check Generation"
        Me.frBatch.ResumeLayout(False)
        Me.frBatch.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sbBatch.ResumeLayout(False)
        Me.sbBatch.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class