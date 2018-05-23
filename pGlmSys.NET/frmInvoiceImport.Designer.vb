<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmInvoiceImport
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
	Public WithEvents cbState As System.Windows.Forms.ComboBox
	Public WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
	Public WithEvents txtAccount As System.Windows.Forms.TextBox
	Public WithEvents txtStoreNumber As System.Windows.Forms.TextBox
	Public WithEvents cbVendor As System.Windows.Forms.ComboBox
	Public WithEvents cbStatusDesc As System.Windows.Forms.ComboBox
	Public WithEvents cbStatusFlag As System.Windows.Forms.ComboBox
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
    Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents lbRecordCount As System.Windows.Forms.Label
    Public WithEvents lbStatusFlag As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvoiceImport))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbState = New System.Windows.Forms.ComboBox
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox
        Me.txtAccount = New System.Windows.Forms.TextBox
        Me.txtStoreNumber = New System.Windows.Forms.TextBox
        Me.cbVendor = New System.Windows.Forms.ComboBox
        Me.cbStatusDesc = New System.Windows.Forms.ComboBox
        Me.cbStatusFlag = New System.Windows.Forms.ComboBox
        Me.cbCustId = New System.Windows.Forms.ComboBox
        Me.cbCustName = New System.Windows.Forms.ComboBox
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip
        Me.btUpload = New System.Windows.Forms.ToolStripButton
        Me.btSearch = New System.Windows.Forms.ToolStripButton
        Me.btExit = New System.Windows.Forms.ToolStripButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbRecordCount = New System.Windows.Forms.Label
        Me.lbStatusFlag = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgPendingInvoices = New System.Windows.Forms.DataGridView
        Me.Toolbar1.SuspendLayout()
        CType(Me.dgPendingInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbState
        '
        Me.cbState.BackColor = System.Drawing.SystemColors.Window
        Me.cbState.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbState.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbState.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbState.Location = New System.Drawing.Point(424, 144)
        Me.cbState.Name = "cbState"
        Me.cbState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbState.Size = New System.Drawing.Size(57, 22)
        Me.cbState.TabIndex = 18
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.AcceptsReturn = True
        Me.txtInvoiceNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtInvoiceNo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInvoiceNo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInvoiceNo.Location = New System.Drawing.Point(424, 176)
        Me.txtInvoiceNo.MaxLength = 0
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInvoiceNo.Size = New System.Drawing.Size(185, 20)
        Me.txtInvoiceNo.TabIndex = 16
        '
        'txtAccount
        '
        Me.txtAccount.AcceptsReturn = True
        Me.txtAccount.BackColor = System.Drawing.SystemColors.Window
        Me.txtAccount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAccount.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAccount.Location = New System.Drawing.Point(80, 176)
        Me.txtAccount.MaxLength = 0
        Me.txtAccount.Name = "txtAccount"
        Me.txtAccount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAccount.Size = New System.Drawing.Size(273, 20)
        Me.txtAccount.TabIndex = 15
        '
        'txtStoreNumber
        '
        Me.txtStoreNumber.AcceptsReturn = True
        Me.txtStoreNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtStoreNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStoreNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStoreNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStoreNumber.Location = New System.Drawing.Point(80, 144)
        Me.txtStoreNumber.MaxLength = 0
        Me.txtStoreNumber.Name = "txtStoreNumber"
        Me.txtStoreNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStoreNumber.Size = New System.Drawing.Size(273, 20)
        Me.txtStoreNumber.TabIndex = 12
        '
        'cbVendor
        '
        Me.cbVendor.BackColor = System.Drawing.SystemColors.Window
        Me.cbVendor.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVendor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVendor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbVendor.Location = New System.Drawing.Point(80, 104)
        Me.cbVendor.Name = "cbVendor"
        Me.cbVendor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbVendor.Size = New System.Drawing.Size(449, 22)
        Me.cbVendor.TabIndex = 10
        '
        'cbStatusDesc
        '
        Me.cbStatusDesc.BackColor = System.Drawing.SystemColors.Window
        Me.cbStatusDesc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbStatusDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatusDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbStatusDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbStatusDesc.Location = New System.Drawing.Point(424, 72)
        Me.cbStatusDesc.Name = "cbStatusDesc"
        Me.cbStatusDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbStatusDesc.Size = New System.Drawing.Size(225, 22)
        Me.cbStatusDesc.TabIndex = 7
        Me.cbStatusDesc.Visible = False
        '
        'cbStatusFlag
        '
        Me.cbStatusFlag.BackColor = System.Drawing.SystemColors.Window
        Me.cbStatusFlag.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbStatusFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatusFlag.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbStatusFlag.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbStatusFlag.Location = New System.Drawing.Point(424, 48)
        Me.cbStatusFlag.Name = "cbStatusFlag"
        Me.cbStatusFlag.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbStatusFlag.Size = New System.Drawing.Size(225, 22)
        Me.cbStatusFlag.TabIndex = 6
        Me.cbStatusFlag.Visible = False
        '
        'cbCustId
        '
        Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustId.Location = New System.Drawing.Point(80, 48)
        Me.cbCustId.Name = "cbCustId"
        Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustId.Size = New System.Drawing.Size(177, 22)
        Me.cbCustId.TabIndex = 4
        Me.cbCustId.Visible = False
        '
        'cbCustName
        '
        Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustName.Location = New System.Drawing.Point(80, 72)
        Me.cbCustName.Name = "cbCustName"
        Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustName.Size = New System.Drawing.Size(273, 22)
        Me.cbCustName.TabIndex = 3
        '
        'Toolbar1
        '
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btUpload, Me.btSearch, Me.btExit})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(741, 39)
        Me.Toolbar1.TabIndex = 0
        '
        'btUpload
        '
        Me.btUpload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btUpload.Image = CType(resources.GetObject("btUpload.Image"), System.Drawing.Image)
        Me.btUpload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btUpload.Name = "btUpload"
        Me.btUpload.Size = New System.Drawing.Size(36, 36)
        Me.btUpload.Text = "Upload"
        '
        'btSearch
        '
        Me.btSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btSearch.Image = CType(resources.GetObject("btSearch.Image"), System.Drawing.Image)
        Me.btSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btSearch.Name = "btSearch"
        Me.btSearch.Size = New System.Drawing.Size(36, 36)
        Me.btSearch.Text = "Search"
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
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(365, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(41, 17)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "State"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(365, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(58, 33)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Invoice Number"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(12, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(55, 21)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Account"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(12, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(69, 32)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Store Number"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(15, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(50, 22)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Vendor"
        '
        'lbRecordCount
        '
        Me.lbRecordCount.BackColor = System.Drawing.SystemColors.Control
        Me.lbRecordCount.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRecordCount.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRecordCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbRecordCount.Location = New System.Drawing.Point(616, 184)
        Me.lbRecordCount.Name = "lbRecordCount"
        Me.lbRecordCount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRecordCount.Size = New System.Drawing.Size(105, 25)
        Me.lbRecordCount.TabIndex = 8
        Me.lbRecordCount.Text = "Total Records:"
        Me.lbRecordCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbStatusFlag
        '
        Me.lbStatusFlag.BackColor = System.Drawing.SystemColors.Control
        Me.lbStatusFlag.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbStatusFlag.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStatusFlag.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbStatusFlag.Location = New System.Drawing.Point(376, 72)
        Me.lbStatusFlag.Name = "lbStatusFlag"
        Me.lbStatusFlag.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbStatusFlag.Size = New System.Drawing.Size(41, 17)
        Me.lbStatusFlag.TabIndex = 5
        Me.lbStatusFlag.Text = "Status"
        Me.lbStatusFlag.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(12, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(61, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Customer"
        '
        'dgPendingInvoices
        '
        Me.dgPendingInvoices.AllowUserToAddRows = False
        Me.dgPendingInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPendingInvoices.Location = New System.Drawing.Point(24, 212)
        Me.dgPendingInvoices.Name = "dgPendingInvoices"
        Me.dgPendingInvoices.Size = New System.Drawing.Size(697, 309)
        Me.dgPendingInvoices.TabIndex = 19
        '
        'frmInvoiceImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(741, 533)
        Me.Controls.Add(Me.dgPendingInvoices)
        Me.Controls.Add(Me.cbState)
        Me.Controls.Add(Me.txtInvoiceNo)
        Me.Controls.Add(Me.txtAccount)
        Me.Controls.Add(Me.txtStoreNumber)
        Me.Controls.Add(Me.cbVendor)
        Me.Controls.Add(Me.cbStatusDesc)
        Me.Controls.Add(Me.cbStatusFlag)
        Me.Controls.Add(Me.cbCustId)
        Me.Controls.Add(Me.cbCustName)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbRecordCount)
        Me.Controls.Add(Me.lbStatusFlag)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "frmInvoiceImport"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Invoice Import"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dgPendingInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgPendingInvoices As System.Windows.Forms.DataGridView
    Friend WithEvents btUpload As System.Windows.Forms.ToolStripButton
    Friend WithEvents btSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents btExit As System.Windows.Forms.ToolStripButton
#End Region 
End Class