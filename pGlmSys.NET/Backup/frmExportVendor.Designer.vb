<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmExportVendor
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
	Public WithEvents prbLoad As System.Windows.Forms.ProgressBar
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdExport As System.Windows.Forms.Button
	Public WithEvents txtSql As System.Windows.Forms.TextBox
	Public WithEvents obSql As System.Windows.Forms.RadioButton
	Public WithEvents obCriteria As System.Windows.Forms.RadioButton
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents txtQBGroupDesc As System.Windows.Forms.TextBox
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public cdFileSave As System.Windows.Forms.SaveFileDialog
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.prbLoad = New System.Windows.Forms.ProgressBar
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdExport = New System.Windows.Forms.Button
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.txtSql = New System.Windows.Forms.TextBox
        Me.obSql = New System.Windows.Forms.RadioButton
        Me.obCriteria = New System.Windows.Forms.RadioButton
        Me.cbCustName = New System.Windows.Forms.ComboBox
        Me.cbCustId = New System.Windows.Forms.ComboBox
        Me.txtQBGroupDesc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cdFileSave = New System.Windows.Forms.SaveFileDialog
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'prbLoad
        '
        Me.prbLoad.Location = New System.Drawing.Point(80, 360)
        Me.prbLoad.Name = "prbLoad"
        Me.prbLoad.Size = New System.Drawing.Size(305, 33)
        Me.prbLoad.TabIndex = 11
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(256, 416)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 33)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdExport
        '
        Me.cmdExport.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExport.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExport.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExport.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExport.Location = New System.Drawing.Point(160, 416)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExport.Size = New System.Drawing.Size(57, 33)
        Me.cmdExport.TabIndex = 6
        Me.cmdExport.Text = "Export"
        Me.cmdExport.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.txtSql)
        Me.Frame1.Controls.Add(Me.obSql)
        Me.Frame1.Controls.Add(Me.obCriteria)
        Me.Frame1.Controls.Add(Me.cbCustName)
        Me.Frame1.Controls.Add(Me.cbCustId)
        Me.Frame1.Controls.Add(Me.txtQBGroupDesc)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(32, 16)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(393, 329)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        '
        'txtSql
        '
        Me.txtSql.AcceptsReturn = True
        Me.txtSql.BackColor = System.Drawing.SystemColors.Window
        Me.txtSql.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSql.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSql.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSql.Location = New System.Drawing.Point(40, 168)
        Me.txtSql.MaxLength = 0
        Me.txtSql.Multiline = True
        Me.txtSql.Name = "txtSql"
        Me.txtSql.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSql.Size = New System.Drawing.Size(329, 137)
        Me.txtSql.TabIndex = 10
        '
        'obSql
        '
        Me.obSql.BackColor = System.Drawing.SystemColors.Control
        Me.obSql.Cursor = System.Windows.Forms.Cursors.Default
        Me.obSql.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obSql.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obSql.Location = New System.Drawing.Point(8, 136)
        Me.obSql.Name = "obSql"
        Me.obSql.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obSql.Size = New System.Drawing.Size(212, 26)
        Me.obSql.TabIndex = 9
        Me.obSql.TabStop = True
        Me.obSql.Text = "SQL"
        Me.obSql.UseVisualStyleBackColor = False
        '
        'obCriteria
        '
        Me.obCriteria.BackColor = System.Drawing.SystemColors.Control
        Me.obCriteria.Cursor = System.Windows.Forms.Cursors.Default
        Me.obCriteria.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obCriteria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obCriteria.Location = New System.Drawing.Point(8, 16)
        Me.obCriteria.Name = "obCriteria"
        Me.obCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obCriteria.Size = New System.Drawing.Size(142, 21)
        Me.obCriteria.TabIndex = 8
        Me.obCriteria.TabStop = True
        Me.obCriteria.Text = "Criteria"
        Me.obCriteria.UseVisualStyleBackColor = False
        '
        'cbCustName
        '
        Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustName.Location = New System.Drawing.Point(48, 56)
        Me.cbCustName.Name = "cbCustName"
        Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustName.Size = New System.Drawing.Size(145, 22)
        Me.cbCustName.TabIndex = 3
        '
        'cbCustId
        '
        Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustId.Location = New System.Drawing.Point(48, 88)
        Me.cbCustId.Name = "cbCustId"
        Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustId.Size = New System.Drawing.Size(137, 22)
        Me.cbCustId.TabIndex = 2
        Me.cbCustId.Visible = False
        '
        'txtQBGroupDesc
        '
        Me.txtQBGroupDesc.AcceptsReturn = True
        Me.txtQBGroupDesc.BackColor = System.Drawing.SystemColors.Window
        Me.txtQBGroupDesc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQBGroupDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQBGroupDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQBGroupDesc.Location = New System.Drawing.Point(224, 56)
        Me.txtQBGroupDesc.MaxLength = 0
        Me.txtQBGroupDesc.Name = "txtQBGroupDesc"
        Me.txtQBGroupDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtQBGroupDesc.Size = New System.Drawing.Size(161, 21)
        Me.txtQBGroupDesc.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(48, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(67, 17)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Customer"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(224, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(81, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "QBooks Group"
        '
        'frmExportVendor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(482, 462)
        Me.Controls.Add(Me.prbLoad)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdExport)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmExportVendor"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Export Vendors"
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class