<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSetting
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
	Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
	Public WithEvents txtWordTemplate As System.Windows.Forms.TextBox
	Public WithEvents cbDebugFlag As System.Windows.Forms.ComboBox
	Public WithEvents txtMaxBatchCheckDetails As System.Windows.Forms.TextBox
	Public WithEvents cbCheckPaperSource As System.Windows.Forms.ComboBox
	Public WithEvents txtCheckLogoFile As System.Windows.Forms.TextBox
	Public WithEvents txtReportDir As System.Windows.Forms.TextBox
	Public WithEvents cbFieldsFromDb As System.Windows.Forms.ComboBox
	Public cdFileOpen As System.Windows.Forms.OpenFileDialog
	Public cdFileSave As System.Windows.Forms.SaveFileDialog
	Public cdFileFont As System.Windows.Forms.FontDialog
	Public cdFileColor As System.Windows.Forms.ColorDialog
	Public cdFilePrint As System.Windows.Forms.PrintDialog
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetting))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip
        Me.btSave = New System.Windows.Forms.ToolStripButton
        Me.btExit = New System.Windows.Forms.ToolStripButton
        Me.txtWordTemplate = New System.Windows.Forms.TextBox
        Me.cbDebugFlag = New System.Windows.Forms.ComboBox
        Me.txtMaxBatchCheckDetails = New System.Windows.Forms.TextBox
        Me.cbCheckPaperSource = New System.Windows.Forms.ComboBox
        Me.txtCheckLogoFile = New System.Windows.Forms.TextBox
        Me.txtReportDir = New System.Windows.Forms.TextBox
        Me.cbFieldsFromDb = New System.Windows.Forms.ComboBox
        Me.cdFileOpen = New System.Windows.Forms.OpenFileDialog
        Me.cdFileSave = New System.Windows.Forms.SaveFileDialog
        Me.cdFileFont = New System.Windows.Forms.FontDialog
        Me.cdFileColor = New System.Windows.Forms.ColorDialog
        Me.cdFilePrint = New System.Windows.Forms.PrintDialog
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.Toolbar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(32, 336)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(97, 17)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Debug Application"
        Me.ToolTip1.SetToolTip(Me.Label6, "Additional information is written to the logifle")
        '
        'Toolbar1
        '
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btSave, Me.btExit})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(536, 39)
        Me.Toolbar1.Stretch = True
        Me.Toolbar1.TabIndex = 5
        '
        'btSave
        '
        Me.btSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btSave.Image = CType(resources.GetObject("btSave.Image"), System.Drawing.Image)
        Me.btSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(36, 36)
        Me.btSave.Text = "Save"
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
        'txtWordTemplate
        '
        Me.txtWordTemplate.AcceptsReturn = True
        Me.txtWordTemplate.BackColor = System.Drawing.SystemColors.Window
        Me.txtWordTemplate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtWordTemplate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWordTemplate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtWordTemplate.Location = New System.Drawing.Point(192, 144)
        Me.txtWordTemplate.MaxLength = 0
        Me.txtWordTemplate.Name = "txtWordTemplate"
        Me.txtWordTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWordTemplate.Size = New System.Drawing.Size(305, 20)
        Me.txtWordTemplate.TabIndex = 14
        '
        'cbDebugFlag
        '
        Me.cbDebugFlag.BackColor = System.Drawing.SystemColors.Window
        Me.cbDebugFlag.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbDebugFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDebugFlag.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDebugFlag.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbDebugFlag.Location = New System.Drawing.Point(192, 328)
        Me.cbDebugFlag.Name = "cbDebugFlag"
        Me.cbDebugFlag.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbDebugFlag.Size = New System.Drawing.Size(65, 22)
        Me.cbDebugFlag.TabIndex = 12
        '
        'txtMaxBatchCheckDetails
        '
        Me.txtMaxBatchCheckDetails.AcceptsReturn = True
        Me.txtMaxBatchCheckDetails.BackColor = System.Drawing.SystemColors.Window
        Me.txtMaxBatchCheckDetails.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMaxBatchCheckDetails.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxBatchCheckDetails.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMaxBatchCheckDetails.Location = New System.Drawing.Point(192, 280)
        Me.txtMaxBatchCheckDetails.MaxLength = 0
        Me.txtMaxBatchCheckDetails.Name = "txtMaxBatchCheckDetails"
        Me.txtMaxBatchCheckDetails.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMaxBatchCheckDetails.Size = New System.Drawing.Size(65, 20)
        Me.txtMaxBatchCheckDetails.TabIndex = 10
        '
        'cbCheckPaperSource
        '
        Me.cbCheckPaperSource.BackColor = System.Drawing.SystemColors.Window
        Me.cbCheckPaperSource.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCheckPaperSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCheckPaperSource.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCheckPaperSource.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCheckPaperSource.Location = New System.Drawing.Point(192, 232)
        Me.cbCheckPaperSource.Name = "cbCheckPaperSource"
        Me.cbCheckPaperSource.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCheckPaperSource.Size = New System.Drawing.Size(145, 22)
        Me.cbCheckPaperSource.TabIndex = 9
        '
        'txtCheckLogoFile
        '
        Me.txtCheckLogoFile.AcceptsReturn = True
        Me.txtCheckLogoFile.BackColor = System.Drawing.SystemColors.Window
        Me.txtCheckLogoFile.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCheckLogoFile.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheckLogoFile.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCheckLogoFile.Location = New System.Drawing.Point(192, 184)
        Me.txtCheckLogoFile.MaxLength = 0
        Me.txtCheckLogoFile.Name = "txtCheckLogoFile"
        Me.txtCheckLogoFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCheckLogoFile.Size = New System.Drawing.Size(305, 20)
        Me.txtCheckLogoFile.TabIndex = 8
        '
        'txtReportDir
        '
        Me.txtReportDir.AcceptsReturn = True
        Me.txtReportDir.BackColor = System.Drawing.SystemColors.Window
        Me.txtReportDir.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReportDir.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReportDir.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReportDir.Location = New System.Drawing.Point(192, 104)
        Me.txtReportDir.MaxLength = 0
        Me.txtReportDir.Name = "txtReportDir"
        Me.txtReportDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReportDir.Size = New System.Drawing.Size(305, 20)
        Me.txtReportDir.TabIndex = 7
        '
        'cbFieldsFromDb
        '
        Me.cbFieldsFromDb.BackColor = System.Drawing.SystemColors.Window
        Me.cbFieldsFromDb.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbFieldsFromDb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFieldsFromDb.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFieldsFromDb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbFieldsFromDb.Location = New System.Drawing.Point(192, 64)
        Me.cbFieldsFromDb.Name = "cbFieldsFromDb"
        Me.cbFieldsFromDb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbFieldsFromDb.Size = New System.Drawing.Size(65, 22)
        Me.cbFieldsFromDb.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(32, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(137, 17)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "MS-Word InvoiceTemplate"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(32, 232)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(97, 25)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Check Paper Source"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(32, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(129, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Check Logo File"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(32, 280)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(137, 33)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Maximun number of Details per Batch Check"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(32, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(129, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Report Default Folder"
        '
        'label1
        '
        Me.label1.BackColor = System.Drawing.SystemColors.Control
        Me.label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label1.Location = New System.Drawing.Point(32, 64)
        Me.label1.Name = "label1"
        Me.label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label1.Size = New System.Drawing.Size(113, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Verify Fields from DB"
        '
        'frmSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(536, 396)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.txtWordTemplate)
        Me.Controls.Add(Me.cbDebugFlag)
        Me.Controls.Add(Me.txtMaxBatchCheckDetails)
        Me.Controls.Add(Me.cbCheckPaperSource)
        Me.Controls.Add(Me.txtCheckLogoFile)
        Me.Controls.Add(Me.txtReportDir)
        Me.Controls.Add(Me.cbFieldsFromDb)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmSetting"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "System Parameters"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btExit As System.Windows.Forms.ToolStripButton
#End Region 
End Class