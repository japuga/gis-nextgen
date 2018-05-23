<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmLoadExcel
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
	Public WithEvents _sbLoad_Panel1 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents sbLoad As System.Windows.Forms.StatusStrip
	Public WithEvents dg1 As AxMSDataGridLib.AxDataGrid
	Public WithEvents prbLoad As System.Windows.Forms.ProgressBar
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdLoadData As System.Windows.Forms.Button
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents cmdOpen As System.Windows.Forms.Button
	Public WithEvents txtExcelFile As System.Windows.Forms.TextBox
	Public cdFileOpen As System.Windows.Forms.OpenFileDialog
	Public WithEvents obEquipment As System.Windows.Forms.RadioButton
	Public WithEvents obStore As System.Windows.Forms.RadioButton
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoadExcel))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.sbLoad = New System.Windows.Forms.StatusStrip
        Me._sbLoad_Panel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.dg1 = New AxMSDataGridLib.AxDataGrid
        Me.prbLoad = New System.Windows.Forms.ProgressBar
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdLoadData = New System.Windows.Forms.Button
        Me.cbCustId = New System.Windows.Forms.ComboBox
        Me.cmdOpen = New System.Windows.Forms.Button
        Me.txtExcelFile = New System.Windows.Forms.TextBox
        Me.cdFileOpen = New System.Windows.Forms.OpenFileDialog
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.obEquipment = New System.Windows.Forms.RadioButton
        Me.obStore = New System.Windows.Forms.RadioButton
        Me.cbCustName = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.sbLoad.SuspendLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'sbLoad
        '
        Me.sbLoad.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sbLoad.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._sbLoad_Panel1})
        Me.sbLoad.Location = New System.Drawing.Point(0, 327)
        Me.sbLoad.Name = "sbLoad"
        Me.sbLoad.Size = New System.Drawing.Size(412, 22)
        Me.sbLoad.TabIndex = 13
        '
        '_sbLoad_Panel1
        '
        Me._sbLoad_Panel1.AutoSize = False
        Me._sbLoad_Panel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._sbLoad_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._sbLoad_Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me._sbLoad_Panel1.Name = "_sbLoad_Panel1"
        Me._sbLoad_Panel1.Size = New System.Drawing.Size(96, 22)
        Me._sbLoad_Panel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dg1
        '
        Me.dg1.DataSource = Nothing
        Me.dg1.Location = New System.Drawing.Point(56, 336)
        Me.dg1.Name = "dg1"
        Me.dg1.OcxState = CType(resources.GetObject("dg1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.dg1.Size = New System.Drawing.Size(361, 113)
        Me.dg1.TabIndex = 12
        '
        'prbLoad
        '
        Me.prbLoad.Location = New System.Drawing.Point(32, 280)
        Me.prbLoad.Name = "prbLoad"
        Me.prbLoad.Size = New System.Drawing.Size(305, 33)
        Me.prbLoad.TabIndex = 11
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(224, 224)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(65, 25)
        Me.cmdClose.TabIndex = 10
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdLoadData
        '
        Me.cmdLoadData.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLoadData.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLoadData.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLoadData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLoadData.Location = New System.Drawing.Point(128, 224)
        Me.cmdLoadData.Name = "cmdLoadData"
        Me.cmdLoadData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLoadData.Size = New System.Drawing.Size(65, 25)
        Me.cmdLoadData.TabIndex = 9
        Me.cmdLoadData.Text = "Load Data"
        Me.cmdLoadData.UseVisualStyleBackColor = False
        '
        'cbCustId
        '
        Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustId.Location = New System.Drawing.Point(248, 24)
        Me.cbCustId.Name = "cbCustId"
        Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustId.Size = New System.Drawing.Size(113, 22)
        Me.cbCustId.TabIndex = 8
        Me.cbCustId.Visible = False
        '
        'cmdOpen
        '
        Me.cmdOpen.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOpen.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOpen.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOpen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOpen.Location = New System.Drawing.Point(320, 88)
        Me.cmdOpen.Name = "cmdOpen"
        Me.cmdOpen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOpen.Size = New System.Drawing.Size(73, 25)
        Me.cmdOpen.TabIndex = 7
        Me.cmdOpen.Text = "Open"
        Me.cmdOpen.UseVisualStyleBackColor = False
        '
        'txtExcelFile
        '
        Me.txtExcelFile.AcceptsReturn = True
        Me.txtExcelFile.BackColor = System.Drawing.SystemColors.Window
        Me.txtExcelFile.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExcelFile.Enabled = False
        Me.txtExcelFile.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExcelFile.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExcelFile.Location = New System.Drawing.Point(16, 88)
        Me.txtExcelFile.MaxLength = 0
        Me.txtExcelFile.Name = "txtExcelFile"
        Me.txtExcelFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExcelFile.Size = New System.Drawing.Size(289, 21)
        Me.txtExcelFile.TabIndex = 6
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.obEquipment)
        Me.Frame1.Controls.Add(Me.obStore)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(16, 128)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(377, 73)
        Me.Frame1.TabIndex = 2
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Destination Table"
        '
        'obEquipment
        '
        Me.obEquipment.BackColor = System.Drawing.SystemColors.Control
        Me.obEquipment.Cursor = System.Windows.Forms.Cursors.Default
        Me.obEquipment.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obEquipment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obEquipment.Location = New System.Drawing.Point(56, 40)
        Me.obEquipment.Name = "obEquipment"
        Me.obEquipment.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obEquipment.Size = New System.Drawing.Size(233, 27)
        Me.obEquipment.TabIndex = 4
        Me.obEquipment.TabStop = True
        Me.obEquipment.Text = "Equipment    (StoreEqpt)"
        Me.obEquipment.UseVisualStyleBackColor = False
        '
        'obStore
        '
        Me.obStore.BackColor = System.Drawing.SystemColors.Control
        Me.obStore.Checked = True
        Me.obStore.Cursor = System.Windows.Forms.Cursors.Default
        Me.obStore.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obStore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obStore.Location = New System.Drawing.Point(56, 16)
        Me.obStore.Name = "obStore"
        Me.obStore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obStore.Size = New System.Drawing.Size(121, 25)
        Me.obStore.TabIndex = 3
        Me.obStore.TabStop = True
        Me.obStore.Text = "Store"
        Me.obStore.UseVisualStyleBackColor = False
        '
        'cbCustName
        '
        Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustName.Location = New System.Drawing.Point(80, 24)
        Me.cbCustName.Name = "cbCustName"
        Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustName.Size = New System.Drawing.Size(145, 22)
        Me.cbCustName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(105, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Source Excel File"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer"
        '
        'frmLoadExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(412, 349)
        Me.Controls.Add(Me.sbLoad)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.prbLoad)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdLoadData)
        Me.Controls.Add(Me.cbCustId)
        Me.Controls.Add(Me.cmdOpen)
        Me.Controls.Add(Me.txtExcelFile)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cbCustName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmLoadExcel"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Migration Tool"
        Me.sbLoad.ResumeLayout(False)
        Me.sbLoad.PerformLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class