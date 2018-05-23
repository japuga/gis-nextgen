<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRepDefTemplateEntry
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
	Public WithEvents cmdBrowse As System.Windows.Forms.Button
    Public cdFileOpen As System.Windows.Forms.OpenFileDialog
    Public WithEvents txtRepTemplateFile As System.Windows.Forms.TextBox
	Public WithEvents txtRepTemplateDesc As System.Windows.Forms.TextBox
	Public WithEvents txtRepTemplateName As System.Windows.Forms.TextBox
	Public WithEvents _Toolbar1_Button5 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepDefTemplateEntry))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.cdFileOpen = New System.Windows.Forms.OpenFileDialog
        Me.txtRepTemplateFile = New System.Windows.Forms.TextBox
        Me.txtRepTemplateDesc = New System.Windows.Forms.TextBox
        Me.txtRepTemplateName = New System.Windows.Forms.TextBox
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip
        Me.btSave = New System.Windows.Forms.ToolStripButton
        Me._Toolbar1_Button5 = New System.Windows.Forms.ToolStripSeparator
        Me.btExit = New System.Windows.Forms.ToolStripButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtColOrder = New System.Windows.Forms.NumericUpDown
        Me.Toolbar1.SuspendLayout()
        CType(Me.txtColOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdBrowse
        '
        Me.cmdBrowse.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBrowse.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBrowse.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBrowse.Location = New System.Drawing.Point(456, 144)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBrowse.Size = New System.Drawing.Size(73, 25)
        Me.cmdBrowse.TabIndex = 10
        Me.cmdBrowse.Text = "Browse"
        Me.cmdBrowse.UseVisualStyleBackColor = False
        '
        'txtRepTemplateFile
        '
        Me.txtRepTemplateFile.AcceptsReturn = True
        Me.txtRepTemplateFile.BackColor = System.Drawing.SystemColors.Window
        Me.txtRepTemplateFile.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRepTemplateFile.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRepTemplateFile.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRepTemplateFile.Location = New System.Drawing.Point(120, 144)
        Me.txtRepTemplateFile.MaxLength = 0
        Me.txtRepTemplateFile.Name = "txtRepTemplateFile"
        Me.txtRepTemplateFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRepTemplateFile.Size = New System.Drawing.Size(321, 20)
        Me.txtRepTemplateFile.TabIndex = 7
        '
        'txtRepTemplateDesc
        '
        Me.txtRepTemplateDesc.AcceptsReturn = True
        Me.txtRepTemplateDesc.BackColor = System.Drawing.SystemColors.Window
        Me.txtRepTemplateDesc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRepTemplateDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRepTemplateDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRepTemplateDesc.Location = New System.Drawing.Point(120, 112)
        Me.txtRepTemplateDesc.MaxLength = 0
        Me.txtRepTemplateDesc.Name = "txtRepTemplateDesc"
        Me.txtRepTemplateDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRepTemplateDesc.Size = New System.Drawing.Size(321, 20)
        Me.txtRepTemplateDesc.TabIndex = 6
        '
        'txtRepTemplateName
        '
        Me.txtRepTemplateName.AcceptsReturn = True
        Me.txtRepTemplateName.BackColor = System.Drawing.SystemColors.Window
        Me.txtRepTemplateName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRepTemplateName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRepTemplateName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRepTemplateName.Location = New System.Drawing.Point(120, 80)
        Me.txtRepTemplateName.MaxLength = 0
        Me.txtRepTemplateName.Name = "txtRepTemplateName"
        Me.txtRepTemplateName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRepTemplateName.Size = New System.Drawing.Size(161, 20)
        Me.txtRepTemplateName.TabIndex = 5
        '
        'Toolbar1
        '
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btSave, Me._Toolbar1_Button5, Me.btExit})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(565, 39)
        Me.Toolbar1.TabIndex = 0
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
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(24, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Order"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(81, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Template File"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(81, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Description"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(89, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Template Name"
        '
        'txtColOrder
        '
        Me.txtColOrder.Location = New System.Drawing.Point(120, 184)
        Me.txtColOrder.Name = "txtColOrder"
        Me.txtColOrder.Size = New System.Drawing.Size(50, 20)
        Me.txtColOrder.TabIndex = 11
        '
        'frmRepDefTemplateEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(565, 250)
        Me.Controls.Add(Me.txtColOrder)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.txtRepTemplateFile)
        Me.Controls.Add(Me.txtRepTemplateDesc)
        Me.Controls.Add(Me.txtRepTemplateName)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmRepDefTemplateEntry"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Report Template Maintenance"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.txtColOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtColOrder As System.Windows.Forms.NumericUpDown
    Friend WithEvents btSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btExit As System.Windows.Forms.ToolStripButton
#End Region 
End Class