<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmInvoiceBillSummary
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
	Public WithEvents cbGroupName As System.Windows.Forms.ComboBox
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
	Public WithEvents txtExcelFile As System.Windows.Forms.TextBox
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents cmdUnloadData As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents _sbLoad_Panel1 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents sbLoad As System.Windows.Forms.StatusStrip
	Public WithEvents prbLoad As System.Windows.Forms.ProgressBar
	Public cdFileSave As System.Windows.Forms.SaveFileDialog
	Public WithEvents label3 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmInvoiceBillSummary))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cbGroupName = New System.Windows.Forms.ComboBox
		Me.cbCustName = New System.Windows.Forms.ComboBox
		Me.txtExcelFile = New System.Windows.Forms.TextBox
		Me.cbCustId = New System.Windows.Forms.ComboBox
		Me.cmdUnloadData = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.sbLoad = New System.Windows.Forms.StatusStrip
		Me._sbLoad_Panel1 = New System.Windows.Forms.ToolStripStatusLabel
		Me.prbLoad = New System.Windows.Forms.ProgressBar
		Me.cdFileSave = New System.Windows.Forms.SaveFileDialog
		Me.label3 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.sbLoad.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Invoice Billing Summary"
		Me.ClientSize = New System.Drawing.Size(473, 304)
		Me.Location = New System.Drawing.Point(4, 23)
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
		Me.Name = "frmInvoiceBillSummary"
		Me.cbGroupName.Size = New System.Drawing.Size(217, 21)
		Me.cbGroupName.Location = New System.Drawing.Point(80, 56)
		Me.cbGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbGroupName.TabIndex = 10
		Me.cbGroupName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbGroupName.BackColor = System.Drawing.SystemColors.Window
		Me.cbGroupName.CausesValidation = True
		Me.cbGroupName.Enabled = True
		Me.cbGroupName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbGroupName.IntegralHeight = True
		Me.cbGroupName.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbGroupName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbGroupName.Sorted = False
		Me.cbGroupName.TabStop = True
		Me.cbGroupName.Visible = True
		Me.cbGroupName.Name = "cbGroupName"
		Me.cbCustName.Size = New System.Drawing.Size(145, 21)
		Me.cbCustName.Location = New System.Drawing.Point(80, 16)
		Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbCustName.TabIndex = 6
		Me.cbCustName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
		Me.cbCustName.CausesValidation = True
		Me.cbCustName.Enabled = True
		Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbCustName.IntegralHeight = True
		Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbCustName.Sorted = False
		Me.cbCustName.TabStop = True
		Me.cbCustName.Visible = True
		Me.cbCustName.Name = "cbCustName"
		Me.txtExcelFile.AutoSize = False
		Me.txtExcelFile.Enabled = False
		Me.txtExcelFile.Size = New System.Drawing.Size(289, 21)
		Me.txtExcelFile.Location = New System.Drawing.Point(16, 120)
		Me.txtExcelFile.TabIndex = 5
		Me.txtExcelFile.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtExcelFile.AcceptsReturn = True
		Me.txtExcelFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtExcelFile.BackColor = System.Drawing.SystemColors.Window
		Me.txtExcelFile.CausesValidation = True
		Me.txtExcelFile.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtExcelFile.HideSelection = True
		Me.txtExcelFile.ReadOnly = False
		Me.txtExcelFile.Maxlength = 0
		Me.txtExcelFile.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtExcelFile.MultiLine = False
		Me.txtExcelFile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtExcelFile.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtExcelFile.TabStop = True
		Me.txtExcelFile.Visible = True
		Me.txtExcelFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtExcelFile.Name = "txtExcelFile"
		Me.cbCustId.Size = New System.Drawing.Size(113, 21)
		Me.cbCustId.Location = New System.Drawing.Point(248, 16)
		Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbCustId.TabIndex = 4
		Me.cbCustId.Visible = False
		Me.cbCustId.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
		Me.cbCustId.CausesValidation = True
		Me.cbCustId.Enabled = True
		Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbCustId.IntegralHeight = True
		Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbCustId.Sorted = False
		Me.cbCustId.TabStop = True
		Me.cbCustId.Name = "cbCustId"
		Me.cmdUnloadData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdUnloadData.Text = "Unload Data"
		Me.cmdUnloadData.Size = New System.Drawing.Size(73, 25)
		Me.cmdUnloadData.Location = New System.Drawing.Point(120, 152)
		Me.cmdUnloadData.TabIndex = 3
		Me.cmdUnloadData.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdUnloadData.BackColor = System.Drawing.SystemColors.Control
		Me.cmdUnloadData.CausesValidation = True
		Me.cmdUnloadData.Enabled = True
		Me.cmdUnloadData.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdUnloadData.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdUnloadData.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdUnloadData.TabStop = True
		Me.cmdUnloadData.Name = "cmdUnloadData"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "Close"
		Me.cmdClose.Size = New System.Drawing.Size(73, 25)
		Me.cmdClose.Location = New System.Drawing.Point(224, 152)
		Me.cmdClose.TabIndex = 2
		Me.cmdClose.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Me.sbLoad.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.sbLoad.Size = New System.Drawing.Size(473, 17)
		Me.sbLoad.Location = New System.Drawing.Point(0, 287)
		Me.sbLoad.TabIndex = 0
		Me.sbLoad.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.sbLoad.Name = "sbLoad"
		Me._sbLoad_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._sbLoad_Panel1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._sbLoad_Panel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._sbLoad_Panel1.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._sbLoad_Panel1.Margin = New System.Windows.Forms.Padding(0)
		Me._sbLoad_Panel1.Size = New System.Drawing.Size(96, 17)
		Me._sbLoad_Panel1.AutoSize = False
		Me.prbLoad.Size = New System.Drawing.Size(305, 33)
		Me.prbLoad.Location = New System.Drawing.Point(40, 192)
		Me.prbLoad.TabIndex = 1
		Me.prbLoad.Name = "prbLoad"
		Me.label3.Text = "Group"
		Me.label3.Size = New System.Drawing.Size(49, 17)
		Me.label3.Location = New System.Drawing.Point(16, 56)
		Me.label3.TabIndex = 9
		Me.label3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.label3.BackColor = System.Drawing.SystemColors.Control
		Me.label3.Enabled = True
		Me.label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label3.UseMnemonic = True
		Me.label3.Visible = True
		Me.label3.AutoSize = False
		Me.label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.label3.Name = "label3"
		Me.Label1.Text = "Customer"
		Me.Label1.Size = New System.Drawing.Size(57, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 16)
		Me.Label1.TabIndex = 8
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
		Me.Label2.Text = "Destination Excel File"
		Me.Label2.Size = New System.Drawing.Size(105, 17)
		Me.Label2.Location = New System.Drawing.Point(16, 104)
		Me.Label2.TabIndex = 7
		Me.Label2.Visible = False
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Controls.Add(cbGroupName)
		Me.Controls.Add(cbCustName)
		Me.Controls.Add(txtExcelFile)
		Me.Controls.Add(cbCustId)
		Me.Controls.Add(cmdUnloadData)
		Me.Controls.Add(cmdClose)
		Me.Controls.Add(sbLoad)
		Me.Controls.Add(prbLoad)
		Me.Controls.Add(label3)
		Me.Controls.Add(Label1)
		Me.Controls.Add(Label2)
		Me.sbLoad.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._sbLoad_Panel1})
		Me.sbLoad.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class