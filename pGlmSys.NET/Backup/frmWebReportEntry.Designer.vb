<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmWebReportEntry
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
	Public WithEvents cbEnabledFlag As System.Windows.Forms.ComboBox
	Public WithEvents txtReportDesc As System.Windows.Forms.TextBox
	Public WithEvents txtTableName As System.Windows.Forms.TextBox
	Public WithEvents _Toolbar1_Button4 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWebReportEntry))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbEnabledFlag = New System.Windows.Forms.ComboBox
        Me.txtReportDesc = New System.Windows.Forms.TextBox
        Me.txtTableName = New System.Windows.Forms.TextBox
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip
        Me.btSave = New System.Windows.Forms.ToolStripButton
        Me._Toolbar1_Button4 = New System.Windows.Forms.ToolStripSeparator
        Me.btExit = New System.Windows.Forms.ToolStripButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Toolbar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbEnabledFlag
        '
        Me.cbEnabledFlag.BackColor = System.Drawing.SystemColors.Window
        Me.cbEnabledFlag.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbEnabledFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEnabledFlag.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEnabledFlag.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbEnabledFlag.Location = New System.Drawing.Point(120, 136)
        Me.cbEnabledFlag.Name = "cbEnabledFlag"
        Me.cbEnabledFlag.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbEnabledFlag.Size = New System.Drawing.Size(137, 22)
        Me.cbEnabledFlag.TabIndex = 6
        '
        'txtReportDesc
        '
        Me.txtReportDesc.AcceptsReturn = True
        Me.txtReportDesc.BackColor = System.Drawing.SystemColors.Window
        Me.txtReportDesc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReportDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReportDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReportDesc.Location = New System.Drawing.Point(120, 104)
        Me.txtReportDesc.MaxLength = 0
        Me.txtReportDesc.Name = "txtReportDesc"
        Me.txtReportDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReportDesc.Size = New System.Drawing.Size(305, 20)
        Me.txtReportDesc.TabIndex = 4
        '
        'txtTableName
        '
        Me.txtTableName.AcceptsReturn = True
        Me.txtTableName.BackColor = System.Drawing.SystemColors.Window
        Me.txtTableName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTableName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTableName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTableName.Location = New System.Drawing.Point(120, 64)
        Me.txtTableName.MaxLength = 0
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTableName.Size = New System.Drawing.Size(129, 20)
        Me.txtTableName.TabIndex = 2
        '
        'Toolbar1
        '
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btSave, Me._Toolbar1_Button4, Me.btExit})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(499, 39)
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
        '_Toolbar1_Button4
        '
        Me._Toolbar1_Button4.AutoSize = False
        Me._Toolbar1_Button4.Name = "_Toolbar1_Button4"
        Me._Toolbar1_Button4.Size = New System.Drawing.Size(10, 39)
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
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(32, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Publish"
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
        Me.Label2.Size = New System.Drawing.Size(81, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Report Name"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(32, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(73, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Report Type"
        '
        'frmWebReportEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(499, 302)
        Me.Controls.Add(Me.cbEnabledFlag)
        Me.Controls.Add(Me.txtReportDesc)
        Me.Controls.Add(Me.txtTableName)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "frmWebReportEntry"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Web Report"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btExit As System.Windows.Forms.ToolStripButton
#End Region 
End Class