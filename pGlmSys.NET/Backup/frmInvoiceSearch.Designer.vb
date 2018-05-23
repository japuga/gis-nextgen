<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmInvoiceSearch
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
    Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents frDates As System.Windows.Forms.GroupBox
	Public WithEvents ckDates As System.Windows.Forms.CheckBox
	Public WithEvents txtInvoice As System.Windows.Forms.TextBox
	Public WithEvents cbVendor As System.Windows.Forms.ComboBox
	Public WithEvents cbState As System.Windows.Forms.ComboBox
	Public WithEvents txtStore As System.Windows.Forms.TextBox
	Public WithEvents cbCustomer As System.Windows.Forms.ComboBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblInvoice As System.Windows.Forms.Label
	Public WithEvents lblVendor As System.Windows.Forms.Label
	Public WithEvents lblState As System.Windows.Forms.Label
	Public WithEvents lblCustomer As System.Windows.Forms.Label
	Public WithEvents FrmCriteria As System.Windows.Forms.GroupBox
	Public WithEvents FrmSearch As System.Windows.Forms.Panel
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvoiceSearch))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.FrmSearch = New System.Windows.Forms.Panel
        Me.frDates = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.FrmCriteria = New System.Windows.Forms.GroupBox
        Me.ckDates = New System.Windows.Forms.CheckBox
        Me.txtInvoice = New System.Windows.Forms.TextBox
        Me.cbVendor = New System.Windows.Forms.ComboBox
        Me.cbState = New System.Windows.Forms.ComboBox
        Me.txtStore = New System.Windows.Forms.TextBox
        Me.cbCustomer = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblInvoice = New System.Windows.Forms.Label
        Me.lblVendor = New System.Windows.Forms.Label
        Me.lblState = New System.Windows.Forms.Label
        Me.lblCustomer = New System.Windows.Forms.Label
        Me.dtStart = New System.Windows.Forms.DateTimePicker
        Me.dtEnd = New System.Windows.Forms.DateTimePicker
        Me.FrmSearch.SuspendLayout()
        Me.frDates.SuspendLayout()
        Me.FrmCriteria.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.Location = New System.Drawing.Point(144, 312)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(65, 49)
        Me.cmdCancel.TabIndex = 10
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Image = CType(resources.GetObject("cmdOk.Image"), System.Drawing.Image)
        Me.cmdOk.Location = New System.Drawing.Point(72, 312)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(57, 49)
        Me.cmdOk.TabIndex = 9
        Me.cmdOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'FrmSearch
        '
        Me.FrmSearch.BackColor = System.Drawing.SystemColors.Info
        Me.FrmSearch.Controls.Add(Me.frDates)
        Me.FrmSearch.Controls.Add(Me.FrmCriteria)
        Me.FrmSearch.Cursor = System.Windows.Forms.Cursors.Default
        Me.FrmSearch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FrmSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FrmSearch.Location = New System.Drawing.Point(-8, 0)
        Me.FrmSearch.Name = "FrmSearch"
        Me.FrmSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FrmSearch.Size = New System.Drawing.Size(305, 385)
        Me.FrmSearch.TabIndex = 8
        Me.FrmSearch.Text = "Frame1"
        '
        'frDates
        '
        Me.frDates.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.frDates.Controls.Add(Me.dtEnd)
        Me.frDates.Controls.Add(Me.dtStart)
        Me.frDates.Controls.Add(Me.Label3)
        Me.frDates.Controls.Add(Me.Label2)
        Me.frDates.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frDates.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frDates.Location = New System.Drawing.Point(88, 208)
        Me.frDates.Name = "frDates"
        Me.frDates.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frDates.Size = New System.Drawing.Size(137, 73)
        Me.frDates.TabIndex = 17
        Me.frDates.TabStop = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(8, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(25, 17)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "To:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(8, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(25, 17)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "From:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'FrmCriteria
        '
        Me.FrmCriteria.BackColor = System.Drawing.SystemColors.Window
        Me.FrmCriteria.Controls.Add(Me.ckDates)
        Me.FrmCriteria.Controls.Add(Me.txtInvoice)
        Me.FrmCriteria.Controls.Add(Me.cbVendor)
        Me.FrmCriteria.Controls.Add(Me.cbState)
        Me.FrmCriteria.Controls.Add(Me.txtStore)
        Me.FrmCriteria.Controls.Add(Me.cbCustomer)
        Me.FrmCriteria.Controls.Add(Me.Label1)
        Me.FrmCriteria.Controls.Add(Me.lblInvoice)
        Me.FrmCriteria.Controls.Add(Me.lblVendor)
        Me.FrmCriteria.Controls.Add(Me.lblState)
        Me.FrmCriteria.Controls.Add(Me.lblCustomer)
        Me.FrmCriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FrmCriteria.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FrmCriteria.Location = New System.Drawing.Point(24, 16)
        Me.FrmCriteria.Name = "FrmCriteria"
        Me.FrmCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FrmCriteria.Size = New System.Drawing.Size(268, 290)
        Me.FrmCriteria.TabIndex = 11
        Me.FrmCriteria.TabStop = False
        Me.FrmCriteria.Text = "Criteria"
        '
        'ckDates
        '
        Me.ckDates.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ckDates.Checked = True
        Me.ckDates.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckDates.Cursor = System.Windows.Forms.Cursors.Default
        Me.ckDates.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckDates.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ckDates.Location = New System.Drawing.Point(8, 200)
        Me.ckDates.Name = "ckDates"
        Me.ckDates.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckDates.Size = New System.Drawing.Size(57, 17)
        Me.ckDates.TabIndex = 5
        Me.ckDates.Text = "Dates"
        Me.ckDates.UseVisualStyleBackColor = False
        '
        'txtInvoice
        '
        Me.txtInvoice.AcceptsReturn = True
        Me.txtInvoice.BackColor = System.Drawing.SystemColors.Window
        Me.txtInvoice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInvoice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInvoice.Location = New System.Drawing.Point(75, 160)
        Me.txtInvoice.MaxLength = 0
        Me.txtInvoice.Name = "txtInvoice"
        Me.txtInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInvoice.Size = New System.Drawing.Size(81, 21)
        Me.txtInvoice.TabIndex = 4
        '
        'cbVendor
        '
        Me.cbVendor.BackColor = System.Drawing.SystemColors.Window
        Me.cbVendor.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVendor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVendor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbVendor.Location = New System.Drawing.Point(75, 128)
        Me.cbVendor.Name = "cbVendor"
        Me.cbVendor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbVendor.Size = New System.Drawing.Size(182, 22)
        Me.cbVendor.TabIndex = 3
        '
        'cbState
        '
        Me.cbState.BackColor = System.Drawing.SystemColors.Window
        Me.cbState.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbState.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbState.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbState.Location = New System.Drawing.Point(75, 64)
        Me.cbState.Name = "cbState"
        Me.cbState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbState.Size = New System.Drawing.Size(81, 22)
        Me.cbState.TabIndex = 1
        '
        'txtStore
        '
        Me.txtStore.AcceptsReturn = True
        Me.txtStore.BackColor = System.Drawing.SystemColors.Window
        Me.txtStore.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStore.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStore.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStore.Location = New System.Drawing.Point(75, 96)
        Me.txtStore.MaxLength = 0
        Me.txtStore.Name = "txtStore"
        Me.txtStore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStore.Size = New System.Drawing.Size(81, 21)
        Me.txtStore.TabIndex = 2
        '
        'cbCustomer
        '
        Me.cbCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustomer.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustomer.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustomer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustomer.Location = New System.Drawing.Point(75, 32)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustomer.Size = New System.Drawing.Size(81, 22)
        Me.cbCustomer.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(27, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(38, 21)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Store:"
        '
        'lblInvoice
        '
        Me.lblInvoice.BackColor = System.Drawing.SystemColors.Window
        Me.lblInvoice.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInvoice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvoice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblInvoice.Location = New System.Drawing.Point(8, 160)
        Me.lblInvoice.Name = "lblInvoice"
        Me.lblInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInvoice.Size = New System.Drawing.Size(57, 21)
        Me.lblInvoice.TabIndex = 15
        Me.lblInvoice.Text = "Invoice #:"
        Me.lblInvoice.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVendor
        '
        Me.lblVendor.BackColor = System.Drawing.SystemColors.Window
        Me.lblVendor.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVendor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblVendor.Location = New System.Drawing.Point(19, 128)
        Me.lblVendor.Name = "lblVendor"
        Me.lblVendor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVendor.Size = New System.Drawing.Size(46, 22)
        Me.lblVendor.TabIndex = 14
        Me.lblVendor.Text = "Vendor:"
        Me.lblVendor.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblState
        '
        Me.lblState.BackColor = System.Drawing.SystemColors.Window
        Me.lblState.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblState.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblState.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblState.Location = New System.Drawing.Point(24, 64)
        Me.lblState.Name = "lblState"
        Me.lblState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblState.Size = New System.Drawing.Size(41, 17)
        Me.lblState.TabIndex = 13
        Me.lblState.Text = "State:"
        Me.lblState.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCustomer
        '
        Me.lblCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.lblCustomer.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCustomer.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCustomer.Location = New System.Drawing.Point(6, 32)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCustomer.Size = New System.Drawing.Size(59, 22)
        Me.lblCustomer.TabIndex = 12
        Me.lblCustomer.Text = "Customer:"
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dtStart
        '
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStart.Location = New System.Drawing.Point(39, 13)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(81, 20)
        Me.dtStart.TabIndex = 17
        '
        'dtEnd
        '
        Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEnd.Location = New System.Drawing.Point(39, 39)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(81, 20)
        Me.dtEnd.TabIndex = 18
        '
        'frmInvoiceSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(296, 381)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.FrmSearch)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(260, 127)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInvoiceSearch"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Invoice Search Crteria"
        Me.FrmSearch.ResumeLayout(False)
        Me.frDates.ResumeLayout(False)
        Me.FrmCriteria.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
#End Region 
End Class