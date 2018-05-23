<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmInvoiceBookingDet
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
	Public WithEvents txtGlmRateDet As System.Windows.Forms.TextBox
	Public WithEvents cmdDetail As System.Windows.Forms.Button
	Public WithEvents cbBillSavingFlag As System.Windows.Forms.ComboBox
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdSave As System.Windows.Forms.Button
	Public WithEvents ImageList1 As System.Windows.Forms.ImageList
	Public WithEvents txtCommentsDet As System.Windows.Forms.TextBox
	Public WithEvents txtRateDet As System.Windows.Forms.TextBox
	Public WithEvents txtOldRateDet As System.Windows.Forms.TextBox
	Public WithEvents txtUnitsDet As System.Windows.Forms.TextBox
	Public WithEvents txtUsageDet As System.Windows.Forms.TextBox
	Public WithEvents cbServDet As System.Windows.Forms.ComboBox
	Public WithEvents cbEquipDet As System.Windows.Forms.ComboBox
    Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents lbContent As System.Windows.Forms.Label
	Public WithEvents lbServTypeDet As System.Windows.Forms.Label
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvoiceBookingDet))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtGlmRateDet = New System.Windows.Forms.TextBox
        Me.cmdDetail = New System.Windows.Forms.Button
        Me.cbBillSavingFlag = New System.Windows.Forms.ComboBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtCommentsDet = New System.Windows.Forms.TextBox
        Me.txtRateDet = New System.Windows.Forms.TextBox
        Me.txtOldRateDet = New System.Windows.Forms.TextBox
        Me.txtUnitsDet = New System.Windows.Forms.TextBox
        Me.txtUsageDet = New System.Windows.Forms.TextBox
        Me.cbServDet = New System.Windows.Forms.ComboBox
        Me.cbEquipDet = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lbContent = New System.Windows.Forms.Label
        Me.lbServTypeDet = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtServDate = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'txtGlmRateDet
        '
        Me.txtGlmRateDet.AcceptsReturn = True
        Me.txtGlmRateDet.BackColor = System.Drawing.SystemColors.Window
        Me.txtGlmRateDet.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGlmRateDet.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGlmRateDet.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGlmRateDet.Location = New System.Drawing.Point(88, 256)
        Me.txtGlmRateDet.MaxLength = 0
        Me.txtGlmRateDet.Name = "txtGlmRateDet"
        Me.txtGlmRateDet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGlmRateDet.Size = New System.Drawing.Size(81, 21)
        Me.txtGlmRateDet.TabIndex = 15
        '
        'cmdDetail
        '
        Me.cmdDetail.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDetail.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDetail.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDetail.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDetail.Location = New System.Drawing.Point(224, 376)
        Me.cmdDetail.Name = "cmdDetail"
        Me.cmdDetail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDetail.Size = New System.Drawing.Size(65, 33)
        Me.cmdDetail.TabIndex = 23
        Me.cmdDetail.Text = "Weights"
        Me.cmdDetail.UseVisualStyleBackColor = False
        '
        'cbBillSavingFlag
        '
        Me.cbBillSavingFlag.BackColor = System.Drawing.SystemColors.Window
        Me.cbBillSavingFlag.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbBillSavingFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBillSavingFlag.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBillSavingFlag.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbBillSavingFlag.Location = New System.Drawing.Point(88, 336)
        Me.cbBillSavingFlag.Name = "cbBillSavingFlag"
        Me.cbBillSavingFlag.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbBillSavingFlag.Size = New System.Drawing.Size(81, 22)
        Me.cbBillSavingFlag.TabIndex = 17
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(136, 377)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(65, 33)
        Me.cmdClose.TabIndex = 20
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.Location = New System.Drawing.Point(48, 377)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSave.Size = New System.Drawing.Size(65, 33)
        Me.cmdSave.TabIndex = 19
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        '
        'txtCommentsDet
        '
        Me.txtCommentsDet.AcceptsReturn = True
        Me.txtCommentsDet.BackColor = System.Drawing.SystemColors.Window
        Me.txtCommentsDet.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCommentsDet.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCommentsDet.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCommentsDet.Location = New System.Drawing.Point(88, 296)
        Me.txtCommentsDet.MaxLength = 30
        Me.txtCommentsDet.Name = "txtCommentsDet"
        Me.txtCommentsDet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCommentsDet.Size = New System.Drawing.Size(209, 21)
        Me.txtCommentsDet.TabIndex = 16
        '
        'txtRateDet
        '
        Me.txtRateDet.AcceptsReturn = True
        Me.txtRateDet.BackColor = System.Drawing.SystemColors.Window
        Me.txtRateDet.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRateDet.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRateDet.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRateDet.Location = New System.Drawing.Point(88, 216)
        Me.txtRateDet.MaxLength = 0
        Me.txtRateDet.Name = "txtRateDet"
        Me.txtRateDet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRateDet.Size = New System.Drawing.Size(81, 21)
        Me.txtRateDet.TabIndex = 14
        '
        'txtOldRateDet
        '
        Me.txtOldRateDet.AcceptsReturn = True
        Me.txtOldRateDet.BackColor = System.Drawing.SystemColors.Window
        Me.txtOldRateDet.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOldRateDet.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldRateDet.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOldRateDet.Location = New System.Drawing.Point(88, 184)
        Me.txtOldRateDet.MaxLength = 0
        Me.txtOldRateDet.Name = "txtOldRateDet"
        Me.txtOldRateDet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOldRateDet.Size = New System.Drawing.Size(81, 21)
        Me.txtOldRateDet.TabIndex = 13
        '
        'txtUnitsDet
        '
        Me.txtUnitsDet.AcceptsReturn = True
        Me.txtUnitsDet.BackColor = System.Drawing.SystemColors.Window
        Me.txtUnitsDet.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUnitsDet.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnitsDet.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUnitsDet.Location = New System.Drawing.Point(88, 152)
        Me.txtUnitsDet.MaxLength = 0
        Me.txtUnitsDet.Name = "txtUnitsDet"
        Me.txtUnitsDet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUnitsDet.Size = New System.Drawing.Size(81, 21)
        Me.txtUnitsDet.TabIndex = 12
        '
        'txtUsageDet
        '
        Me.txtUsageDet.AcceptsReturn = True
        Me.txtUsageDet.BackColor = System.Drawing.SystemColors.Window
        Me.txtUsageDet.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUsageDet.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsageDet.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUsageDet.Location = New System.Drawing.Point(88, 120)
        Me.txtUsageDet.MaxLength = 0
        Me.txtUsageDet.Name = "txtUsageDet"
        Me.txtUsageDet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUsageDet.Size = New System.Drawing.Size(81, 21)
        Me.txtUsageDet.TabIndex = 11
        '
        'cbServDet
        '
        Me.cbServDet.BackColor = System.Drawing.SystemColors.Window
        Me.cbServDet.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbServDet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbServDet.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbServDet.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbServDet.Location = New System.Drawing.Point(88, 88)
        Me.cbServDet.Name = "cbServDet"
        Me.cbServDet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbServDet.Size = New System.Drawing.Size(209, 22)
        Me.cbServDet.TabIndex = 10
        '
        'cbEquipDet
        '
        Me.cbEquipDet.BackColor = System.Drawing.SystemColors.Window
        Me.cbEquipDet.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbEquipDet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEquipDet.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEquipDet.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbEquipDet.Location = New System.Drawing.Point(88, 56)
        Me.cbEquipDet.Name = "cbEquipDet"
        Me.cbEquipDet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbEquipDet.Size = New System.Drawing.Size(153, 22)
        Me.cbEquipDet.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(24, 256)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(57, 25)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "GLM Rate"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(24, 336)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(49, 33)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Billable Saving"
        '
        'lbContent
        '
        Me.lbContent.BackColor = System.Drawing.SystemColors.Control
        Me.lbContent.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbContent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbContent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbContent.Location = New System.Drawing.Point(248, 56)
        Me.lbContent.Name = "lbContent"
        Me.lbContent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbContent.Size = New System.Drawing.Size(81, 17)
        Me.lbContent.TabIndex = 21
        Me.lbContent.Text = "Content"
        '
        'lbServTypeDet
        '
        Me.lbServTypeDet.BackColor = System.Drawing.SystemColors.Control
        Me.lbServTypeDet.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbServTypeDet.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbServTypeDet.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbServTypeDet.Location = New System.Drawing.Point(176, 152)
        Me.lbServTypeDet.Name = "lbServTypeDet"
        Me.lbServTypeDet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbServTypeDet.Size = New System.Drawing.Size(89, 21)
        Me.lbServTypeDet.TabIndex = 18
        Me.lbServTypeDet.Text = " "
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(24, 296)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(57, 17)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Comments"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(24, 216)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(49, 25)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Current Rate"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(24, 184)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(57, 25)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Benchmark Rate"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(24, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(33, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Units"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(24, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(41, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Usage"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(49, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Service"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Equipment"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(41, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'dtServDate
        '
        Me.dtServDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtServDate.Location = New System.Drawing.Point(88, 19)
        Me.dtServDate.Name = "dtServDate"
        Me.dtServDate.Size = New System.Drawing.Size(89, 20)
        Me.dtServDate.TabIndex = 25
        '
        'frmInvoiceBookingDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(344, 425)
        Me.Controls.Add(Me.dtServDate)
        Me.Controls.Add(Me.txtGlmRateDet)
        Me.Controls.Add(Me.cmdDetail)
        Me.Controls.Add(Me.cbBillSavingFlag)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.txtCommentsDet)
        Me.Controls.Add(Me.txtRateDet)
        Me.Controls.Add(Me.txtOldRateDet)
        Me.Controls.Add(Me.txtUnitsDet)
        Me.Controls.Add(Me.txtUsageDet)
        Me.Controls.Add(Me.cbServDet)
        Me.Controls.Add(Me.cbEquipDet)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lbContent)
        Me.Controls.Add(Me.lbServTypeDet)
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
        Me.Name = "frmInvoiceBookingDet"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Invoice Detail"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtServDate As System.Windows.Forms.DateTimePicker
#End Region 
End Class