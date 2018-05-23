<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRepDefEntry
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
	Public WithEvents txtTableName As System.Windows.Forms.TextBox
	Public WithEvents cmdOption As System.Windows.Forms.Button
    Public WithEvents txtRepNo As System.Windows.Forms.TextBox
	Public WithEvents cmdNewTemplate As System.Windows.Forms.Button
	Public cdFileOpen As System.Windows.Forms.OpenFileDialog
	Public WithEvents cmdBrowse As System.Windows.Forms.Button
	Public WithEvents cmdDeleteTemplate As System.Windows.Forms.Button
	Public WithEvents cmdEditTemplate As System.Windows.Forms.Button
	Public WithEvents txtRepTemplateFile As System.Windows.Forms.TextBox
	Public WithEvents txtRepSpName As System.Windows.Forms.TextBox
	Public WithEvents txtRepCaption As System.Windows.Forms.TextBox
	Public WithEvents _Toolbar1_Button5 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
	Public WithEvents label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepDefEntry))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtTableName = New System.Windows.Forms.TextBox
        Me.cmdOption = New System.Windows.Forms.Button
        Me.txtRepNo = New System.Windows.Forms.TextBox
        Me.cmdNewTemplate = New System.Windows.Forms.Button
        Me.cdFileOpen = New System.Windows.Forms.OpenFileDialog
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.cmdDeleteTemplate = New System.Windows.Forms.Button
        Me.cmdEditTemplate = New System.Windows.Forms.Button
        Me.txtRepTemplateFile = New System.Windows.Forms.TextBox
        Me.txtRepSpName = New System.Windows.Forms.TextBox
        Me.txtRepCaption = New System.Windows.Forms.TextBox
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip
        Me.btSave = New System.Windows.Forms.ToolStripButton
        Me._Toolbar1_Button5 = New System.Windows.Forms.ToolStripSeparator
        Me.btExit = New System.Windows.Forms.ToolStripButton
        Me.label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgRepDefTemplate = New System.Windows.Forms.DataGridView
        Me.Toolbar1.SuspendLayout()
        CType(Me.dgRepDefTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTableName
        '
        Me.txtTableName.AcceptsReturn = True
        Me.txtTableName.BackColor = System.Drawing.SystemColors.Window
        Me.txtTableName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTableName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTableName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTableName.Location = New System.Drawing.Point(489, 94)
        Me.txtTableName.MaxLength = 0
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTableName.Size = New System.Drawing.Size(145, 20)
        Me.txtTableName.TabIndex = 15
        '
        'cmdOption
        '
        Me.cmdOption.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOption.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOption.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOption.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOption.Location = New System.Drawing.Point(544, 154)
        Me.cmdOption.Name = "cmdOption"
        Me.cmdOption.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOption.Size = New System.Drawing.Size(89, 39)
        Me.cmdOption.TabIndex = 13
        Me.cmdOption.Text = "Service Options"
        Me.cmdOption.UseVisualStyleBackColor = False
        '
        'txtRepNo
        '
        Me.txtRepNo.AcceptsReturn = True
        Me.txtRepNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtRepNo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRepNo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRepNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRepNo.Location = New System.Drawing.Point(473, 69)
        Me.txtRepNo.MaxLength = 0
        Me.txtRepNo.Name = "txtRepNo"
        Me.txtRepNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRepNo.Size = New System.Drawing.Size(41, 20)
        Me.txtRepNo.TabIndex = 11
        Me.txtRepNo.Visible = False
        '
        'cmdNewTemplate
        '
        Me.cmdNewTemplate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNewTemplate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdNewTemplate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNewTemplate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNewTemplate.Location = New System.Drawing.Point(24, 432)
        Me.cmdNewTemplate.Name = "cmdNewTemplate"
        Me.cmdNewTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdNewTemplate.Size = New System.Drawing.Size(81, 41)
        Me.cmdNewTemplate.TabIndex = 10
        Me.cmdNewTemplate.Text = "New Template"
        Me.cmdNewTemplate.UseVisualStyleBackColor = False
        '
        'cmdBrowse
        '
        Me.cmdBrowse.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBrowse.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBrowse.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBrowse.Location = New System.Drawing.Point(544, 123)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBrowse.Size = New System.Drawing.Size(89, 25)
        Me.cmdBrowse.TabIndex = 9
        Me.cmdBrowse.Text = "Browse"
        Me.cmdBrowse.UseVisualStyleBackColor = False
        '
        'cmdDeleteTemplate
        '
        Me.cmdDeleteTemplate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDeleteTemplate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDeleteTemplate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteTemplate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDeleteTemplate.Location = New System.Drawing.Point(232, 432)
        Me.cmdDeleteTemplate.Name = "cmdDeleteTemplate"
        Me.cmdDeleteTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDeleteTemplate.Size = New System.Drawing.Size(81, 41)
        Me.cmdDeleteTemplate.TabIndex = 8
        Me.cmdDeleteTemplate.Text = "Delete Template"
        Me.cmdDeleteTemplate.UseVisualStyleBackColor = False
        '
        'cmdEditTemplate
        '
        Me.cmdEditTemplate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEditTemplate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEditTemplate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEditTemplate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEditTemplate.Location = New System.Drawing.Point(128, 432)
        Me.cmdEditTemplate.Name = "cmdEditTemplate"
        Me.cmdEditTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEditTemplate.Size = New System.Drawing.Size(81, 41)
        Me.cmdEditTemplate.TabIndex = 7
        Me.cmdEditTemplate.Text = "Edit Template"
        Me.cmdEditTemplate.UseVisualStyleBackColor = False
        '
        'txtRepTemplateFile
        '
        Me.txtRepTemplateFile.AcceptsReturn = True
        Me.txtRepTemplateFile.BackColor = System.Drawing.SystemColors.Window
        Me.txtRepTemplateFile.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRepTemplateFile.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRepTemplateFile.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRepTemplateFile.Location = New System.Drawing.Point(136, 154)
        Me.txtRepTemplateFile.MaxLength = 0
        Me.txtRepTemplateFile.Name = "txtRepTemplateFile"
        Me.txtRepTemplateFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRepTemplateFile.Size = New System.Drawing.Size(401, 20)
        Me.txtRepTemplateFile.TabIndex = 6
        '
        'txtRepSpName
        '
        Me.txtRepSpName.AcceptsReturn = True
        Me.txtRepSpName.BackColor = System.Drawing.SystemColors.Window
        Me.txtRepSpName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRepSpName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRepSpName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRepSpName.Location = New System.Drawing.Point(137, 95)
        Me.txtRepSpName.MaxLength = 0
        Me.txtRepSpName.Name = "txtRepSpName"
        Me.txtRepSpName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRepSpName.Size = New System.Drawing.Size(225, 20)
        Me.txtRepSpName.TabIndex = 5
        '
        'txtRepCaption
        '
        Me.txtRepCaption.AcceptsReturn = True
        Me.txtRepCaption.BackColor = System.Drawing.SystemColors.Window
        Me.txtRepCaption.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRepCaption.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRepCaption.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRepCaption.Location = New System.Drawing.Point(137, 66)
        Me.txtRepCaption.MaxLength = 0
        Me.txtRepCaption.Name = "txtRepCaption"
        Me.txtRepCaption.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRepCaption.Size = New System.Drawing.Size(273, 20)
        Me.txtRepCaption.TabIndex = 4
        '
        'Toolbar1
        '
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btSave, Me._Toolbar1_Button5, Me.btExit})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(648, 39)
        Me.Toolbar1.TabIndex = 1
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
        '_Toolbar1_Button5
        '
        Me._Toolbar1_Button5.AutoSize = False
        Me._Toolbar1_Button5.Name = "_Toolbar1_Button5"
        Me._Toolbar1_Button5.Size = New System.Drawing.Size(10, 39)
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
        'label4
        '
        Me.label4.BackColor = System.Drawing.SystemColors.Control
        Me.label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label4.Location = New System.Drawing.Point(376, 97)
        Me.label4.Name = "label4"
        Me.label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label4.Size = New System.Drawing.Size(107, 20)
        Me.label4.TabIndex = 14
        Me.label4.Text = "Data Table Name"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(12, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(118, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Default Template File"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(13, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(117, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Stored Procedure"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(13, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(106, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Report Name"
        '
        'dgRepDefTemplate
        '
        Me.dgRepDefTemplate.AllowUserToAddRows = False
        Me.dgRepDefTemplate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRepDefTemplate.Location = New System.Drawing.Point(27, 199)
        Me.dgRepDefTemplate.Name = "dgRepDefTemplate"
        Me.dgRepDefTemplate.Size = New System.Drawing.Size(606, 227)
        Me.dgRepDefTemplate.TabIndex = 16
        '
        'frmRepDefEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(648, 492)
        Me.Controls.Add(Me.dgRepDefTemplate)
        Me.Controls.Add(Me.txtTableName)
        Me.Controls.Add(Me.cmdOption)
        Me.Controls.Add(Me.txtRepNo)
        Me.Controls.Add(Me.cmdNewTemplate)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.cmdDeleteTemplate)
        Me.Controls.Add(Me.cmdEditTemplate)
        Me.Controls.Add(Me.txtRepTemplateFile)
        Me.Controls.Add(Me.txtRepSpName)
        Me.Controls.Add(Me.txtRepCaption)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmRepDefEntry"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Report Settings"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dgRepDefTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgRepDefTemplate As System.Windows.Forms.DataGridView
#End Region 
End Class