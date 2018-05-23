<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSaleRequestTicket
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
	Public WithEvents txtNotes As System.Windows.Forms.TextBox
	Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
	Public WithEvents txtSaleAmount As System.Windows.Forms.TextBox
	Public WithEvents dtSaleDate As AxMSComCtl2.AxDTPicker
	Public WithEvents txtQty As System.Windows.Forms.TextBox
	Public WithEvents txtBuyer As System.Windows.Forms.TextBox
	Public WithEvents cbItemDesc As System.Windows.Forms.ComboBox
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
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSaleRequestTicket))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.txtNotes = New System.Windows.Forms.TextBox
		Me.Toolbar1 = New System.Windows.Forms.ToolStrip
		Me.txtSaleAmount = New System.Windows.Forms.TextBox
		Me.dtSaleDate = New AxMSComCtl2.AxDTPicker
		Me.txtQty = New System.Windows.Forms.TextBox
		Me.txtBuyer = New System.Windows.Forms.TextBox
		Me.cbItemDesc = New System.Windows.Forms.ComboBox
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Toolbar1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.dtSaleDate, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Sale Tickets"
		Me.ClientSize = New System.Drawing.Size(523, 387)
		Me.Location = New System.Drawing.Point(4, 30)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmSaleRequestTicket"
		Me.txtNotes.AutoSize = False
		Me.txtNotes.Size = New System.Drawing.Size(401, 97)
		Me.txtNotes.Location = New System.Drawing.Point(104, 264)
		Me.txtNotes.MultiLine = True
		Me.txtNotes.TabIndex = 12
		Me.txtNotes.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtNotes.AcceptsReturn = True
		Me.txtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNotes.BackColor = System.Drawing.SystemColors.Window
		Me.txtNotes.CausesValidation = True
		Me.txtNotes.Enabled = True
		Me.txtNotes.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNotes.HideSelection = True
		Me.txtNotes.ReadOnly = False
		Me.txtNotes.Maxlength = 0
		Me.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNotes.TabStop = True
		Me.txtNotes.Visible = True
		Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNotes.Name = "txtNotes"
		Me.Toolbar1.ShowItemToolTips = True
		Me.Toolbar1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Toolbar1.Size = New System.Drawing.Size(523, 44)
		Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
		Me.Toolbar1.TabIndex = 10
		Me.Toolbar1.ImageList = ImageList2
		Me.Toolbar1.Name = "Toolbar1"
		Me.txtSaleAmount.AutoSize = False
		Me.txtSaleAmount.Size = New System.Drawing.Size(185, 21)
		Me.txtSaleAmount.Location = New System.Drawing.Point(104, 224)
		Me.txtSaleAmount.TabIndex = 9
		Me.txtSaleAmount.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSaleAmount.AcceptsReturn = True
		Me.txtSaleAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtSaleAmount.BackColor = System.Drawing.SystemColors.Window
		Me.txtSaleAmount.CausesValidation = True
		Me.txtSaleAmount.Enabled = True
		Me.txtSaleAmount.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSaleAmount.HideSelection = True
		Me.txtSaleAmount.ReadOnly = False
		Me.txtSaleAmount.Maxlength = 0
		Me.txtSaleAmount.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSaleAmount.MultiLine = False
		Me.txtSaleAmount.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSaleAmount.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtSaleAmount.TabStop = True
		Me.txtSaleAmount.Visible = True
		Me.txtSaleAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtSaleAmount.Name = "txtSaleAmount"
		dtSaleDate.OcxState = CType(resources.GetObject("dtSaleDate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.dtSaleDate.Size = New System.Drawing.Size(185, 25)
		Me.dtSaleDate.Location = New System.Drawing.Point(104, 184)
		Me.dtSaleDate.TabIndex = 8
		Me.dtSaleDate.Name = "dtSaleDate"
		Me.txtQty.AutoSize = False
		Me.txtQty.Size = New System.Drawing.Size(185, 21)
		Me.txtQty.Location = New System.Drawing.Point(104, 152)
		Me.txtQty.TabIndex = 7
		Me.txtQty.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtQty.AcceptsReturn = True
		Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtQty.BackColor = System.Drawing.SystemColors.Window
		Me.txtQty.CausesValidation = True
		Me.txtQty.Enabled = True
		Me.txtQty.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtQty.HideSelection = True
		Me.txtQty.ReadOnly = False
		Me.txtQty.Maxlength = 0
		Me.txtQty.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtQty.MultiLine = False
		Me.txtQty.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtQty.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtQty.TabStop = True
		Me.txtQty.Visible = True
		Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtQty.Name = "txtQty"
		Me.txtBuyer.AutoSize = False
		Me.txtBuyer.Size = New System.Drawing.Size(401, 19)
		Me.txtBuyer.Location = New System.Drawing.Point(104, 120)
		Me.txtBuyer.TabIndex = 6
		Me.txtBuyer.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtBuyer.AcceptsReturn = True
		Me.txtBuyer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtBuyer.BackColor = System.Drawing.SystemColors.Window
		Me.txtBuyer.CausesValidation = True
		Me.txtBuyer.Enabled = True
		Me.txtBuyer.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtBuyer.HideSelection = True
		Me.txtBuyer.ReadOnly = False
		Me.txtBuyer.Maxlength = 0
		Me.txtBuyer.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtBuyer.MultiLine = False
		Me.txtBuyer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtBuyer.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtBuyer.TabStop = True
		Me.txtBuyer.Visible = True
		Me.txtBuyer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtBuyer.Name = "txtBuyer"
		Me.cbItemDesc.Size = New System.Drawing.Size(401, 21)
		Me.cbItemDesc.Location = New System.Drawing.Point(104, 88)
		Me.cbItemDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbItemDesc.TabIndex = 5
		Me.cbItemDesc.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbItemDesc.BackColor = System.Drawing.SystemColors.Window
		Me.cbItemDesc.CausesValidation = True
		Me.cbItemDesc.Enabled = True
		Me.cbItemDesc.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbItemDesc.IntegralHeight = True
		Me.cbItemDesc.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbItemDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbItemDesc.Sorted = False
		Me.cbItemDesc.TabStop = True
		Me.cbItemDesc.Visible = True
		Me.cbItemDesc.Name = "cbItemDesc"
		Me.Label6.Text = "Notes"
		Me.Label6.Size = New System.Drawing.Size(57, 17)
		Me.Label6.Location = New System.Drawing.Point(32, 264)
		Me.Label6.TabIndex = 11
		Me.Label6.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.BackColor = System.Drawing.SystemColors.Control
		Me.Label6.Enabled = True
		Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = False
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.Label5.Text = "Buyer"
		Me.Label5.Size = New System.Drawing.Size(65, 25)
		Me.Label5.Location = New System.Drawing.Point(32, 120)
		Me.Label5.TabIndex = 4
		Me.Label5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.SystemColors.Control
		Me.Label5.Enabled = True
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.Text = "Sale Date"
		Me.Label4.Size = New System.Drawing.Size(57, 17)
		Me.Label4.Location = New System.Drawing.Point(32, 176)
		Me.Label4.TabIndex = 3
		Me.Label4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.Text = "Sale Amount"
		Me.Label3.Size = New System.Drawing.Size(73, 17)
		Me.Label3.Location = New System.Drawing.Point(32, 224)
		Me.Label3.TabIndex = 2
		Me.Label3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "Qty Sold"
		Me.Label2.Size = New System.Drawing.Size(41, 17)
		Me.Label2.Location = New System.Drawing.Point(32, 152)
		Me.Label2.TabIndex = 1
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "Item"
		Me.Label1.Size = New System.Drawing.Size(41, 17)
		Me.Label1.Location = New System.Drawing.Point(32, 96)
		Me.Label1.TabIndex = 0
		Me.Label1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(txtNotes)
		Me.Controls.Add(Toolbar1)
		Me.Controls.Add(txtSaleAmount)
		Me.Controls.Add(dtSaleDate)
		Me.Controls.Add(txtQty)
		Me.Controls.Add(txtBuyer)
		Me.Controls.Add(cbItemDesc)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		CType(Me.dtSaleDate, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Toolbar1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class