<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCustInvBatch
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
	Public WithEvents cbStoreGroup As System.Windows.Forms.ComboBox
    Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents frInvoiceDates As System.Windows.Forms.GroupBox
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
	Public WithEvents cbPeriod As System.Windows.Forms.ComboBox
	Public WithEvents cbFill As System.Windows.Forms.Button
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents ckInvoiceDates As System.Windows.Forms.CheckBox
    Public WithEvents _Toolbar1_Button4 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustInvBatch))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbStoreGroup = New System.Windows.Forms.ComboBox
        Me.frInvoiceDates = New System.Windows.Forms.GroupBox
        Me.dtTo = New System.Windows.Forms.DateTimePicker
        Me.dtFrom = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbCustName = New System.Windows.Forms.ComboBox
        Me.cbPeriod = New System.Windows.Forms.ComboBox
        Me.cbFill = New System.Windows.Forms.Button
        Me.cbCustId = New System.Windows.Forms.ComboBox
        Me.ckInvoiceDates = New System.Windows.Forms.CheckBox
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip
        Me.btNew = New System.Windows.Forms.ToolStripButton
        Me.btEdit = New System.Windows.Forms.ToolStripButton
        Me.btDelete = New System.Windows.Forms.ToolStripButton
        Me._Toolbar1_Button4 = New System.Windows.Forms.ToolStripSeparator
        Me.btExit = New System.Windows.Forms.ToolStripButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgBatch = New System.Windows.Forms.DataGridView
        Me.frInvoiceDates.SuspendLayout()
        Me.Toolbar1.SuspendLayout()
        CType(Me.dgBatch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbStoreGroup
        '
        Me.cbStoreGroup.BackColor = System.Drawing.SystemColors.Window
        Me.cbStoreGroup.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbStoreGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStoreGroup.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbStoreGroup.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbStoreGroup.Location = New System.Drawing.Point(104, 96)
        Me.cbStoreGroup.Name = "cbStoreGroup"
        Me.cbStoreGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbStoreGroup.Size = New System.Drawing.Size(169, 22)
        Me.cbStoreGroup.TabIndex = 15
        '
        'frInvoiceDates
        '
        Me.frInvoiceDates.BackColor = System.Drawing.SystemColors.Control
        Me.frInvoiceDates.Controls.Add(Me.dtTo)
        Me.frInvoiceDates.Controls.Add(Me.dtFrom)
        Me.frInvoiceDates.Controls.Add(Me.Label2)
        Me.frInvoiceDates.Controls.Add(Me.Label3)
        Me.frInvoiceDates.Enabled = False
        Me.frInvoiceDates.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frInvoiceDates.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frInvoiceDates.Location = New System.Drawing.Point(24, 152)
        Me.frInvoiceDates.Name = "frInvoiceDates"
        Me.frInvoiceDates.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frInvoiceDates.Size = New System.Drawing.Size(425, 89)
        Me.frInvoiceDates.TabIndex = 6
        Me.frInvoiceDates.TabStop = False
        Me.frInvoiceDates.Text = "Search For"
        '
        'dtTo
        '
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(288, 32)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(97, 20)
        Me.dtTo.TabIndex = 12
        '
        'dtFrom
        '
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.Location = New System.Drawing.Point(80, 32)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(97, 20)
        Me.dtFrom.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(89, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "From"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(248, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(33, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "To"
        '
        'cbCustName
        '
        Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustName.Location = New System.Drawing.Point(104, 64)
        Me.cbCustName.Name = "cbCustName"
        Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustName.Size = New System.Drawing.Size(137, 22)
        Me.cbCustName.TabIndex = 5
        '
        'cbPeriod
        '
        Me.cbPeriod.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbPeriod.Location = New System.Drawing.Point(312, 64)
        Me.cbPeriod.Name = "cbPeriod"
        Me.cbPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbPeriod.Size = New System.Drawing.Size(137, 22)
        Me.cbPeriod.TabIndex = 4
        '
        'cbFill
        '
        Me.cbFill.BackColor = System.Drawing.SystemColors.Control
        Me.cbFill.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbFill.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFill.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbFill.Location = New System.Drawing.Point(512, 160)
        Me.cbFill.Name = "cbFill"
        Me.cbFill.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbFill.Size = New System.Drawing.Size(97, 33)
        Me.cbFill.TabIndex = 2
        Me.cbFill.Text = "Apply Filter"
        Me.cbFill.UseVisualStyleBackColor = False
        '
        'cbCustId
        '
        Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustId.Location = New System.Drawing.Point(504, 64)
        Me.cbCustId.Name = "cbCustId"
        Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustId.Size = New System.Drawing.Size(73, 22)
        Me.cbCustId.TabIndex = 1
        Me.cbCustId.Visible = False
        '
        'ckInvoiceDates
        '
        Me.ckInvoiceDates.BackColor = System.Drawing.SystemColors.Control
        Me.ckInvoiceDates.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckInvoiceDates.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckInvoiceDates.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckInvoiceDates.Location = New System.Drawing.Point(24, 128)
        Me.ckInvoiceDates.Name = "ckInvoiceDates"
        Me.ckInvoiceDates.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckInvoiceDates.Size = New System.Drawing.Size(113, 17)
        Me.ckInvoiceDates.TabIndex = 0
        Me.ckInvoiceDates.Text = "Invoice Dates"
        Me.ckInvoiceDates.UseVisualStyleBackColor = False
        '
        'Toolbar1
        '
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNew, Me.btEdit, Me.btDelete, Me._Toolbar1_Button4, Me.btExit})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(752, 39)
        Me.Toolbar1.TabIndex = 13
        '
        'btNew
        '
        Me.btNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btNew.Image = CType(resources.GetObject("btNew.Image"), System.Drawing.Image)
        Me.btNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btNew.Name = "btNew"
        Me.btNew.Size = New System.Drawing.Size(36, 36)
        Me.btNew.Text = "New"
        '
        'btEdit
        '
        Me.btEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btEdit.Image = CType(resources.GetObject("btEdit.Image"), System.Drawing.Image)
        Me.btEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btEdit.Name = "btEdit"
        Me.btEdit.Size = New System.Drawing.Size(36, 36)
        Me.btEdit.Text = "Edit"
        '
        'btDelete
        '
        Me.btDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btDelete.Image = CType(resources.GetObject("btDelete.Image"), System.Drawing.Image)
        Me.btDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btDelete.Name = "btDelete"
        Me.btDelete.Size = New System.Drawing.Size(36, 36)
        Me.btDelete.Text = "Delete"
        '
        '_Toolbar1_Button4
        '
        Me._Toolbar1_Button4.Name = "_Toolbar1_Button4"
        Me._Toolbar1_Button4.Size = New System.Drawing.Size(6, 39)
        '
        'btExit
        '
        Me.btExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btExit.Image = CType(resources.GetObject("btExit.Image"), System.Drawing.Image)
        Me.btExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btExit.Name = "btExit"
        Me.btExit.Size = New System.Drawing.Size(36, 36)
        Me.btExit.Text = "Exit"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(24, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(65, 17)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Store Group"
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
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Customer"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(272, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(41, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Period"
        '
        'dgBatch
        '
        Me.dgBatch.AllowUserToAddRows = False
        Me.dgBatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBatch.Location = New System.Drawing.Point(24, 260)
        Me.dgBatch.Name = "dgBatch"
        Me.dgBatch.Size = New System.Drawing.Size(689, 185)
        Me.dgBatch.TabIndex = 16
        '
        'frmCustInvBatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(752, 457)
        Me.Controls.Add(Me.dgBatch)
        Me.Controls.Add(Me.cbStoreGroup)
        Me.Controls.Add(Me.frInvoiceDates)
        Me.Controls.Add(Me.cbCustName)
        Me.Controls.Add(Me.cbPeriod)
        Me.Controls.Add(Me.cbFill)
        Me.Controls.Add(Me.cbCustId)
        Me.Controls.Add(Me.ckInvoiceDates)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "frmCustInvBatch"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "MS-Word Customer Invoices"
        Me.frInvoiceDates.ResumeLayout(False)
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dgBatch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgBatch As System.Windows.Forms.DataGridView
#End Region 
End Class