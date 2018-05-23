<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class tplGridSelector2
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
	Public WithEvents cbHeader As System.Windows.Forms.ComboBox
	Public WithEvents txtHeader As System.Windows.Forms.TextBox
	Public WithEvents cmdRight As System.Windows.Forms.Button
	Public WithEvents cmdLeft As System.Windows.Forms.Button
    Public WithEvents _Toolbar1_Button5 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
	Public WithEvents lbHeader As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(tplGridSelector2))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbHeader = New System.Windows.Forms.ComboBox
        Me.txtHeader = New System.Windows.Forms.TextBox
        Me.cmdRight = New System.Windows.Forms.Button
        Me.cmdLeft = New System.Windows.Forms.Button
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip
        Me.btNew = New System.Windows.Forms.ToolStripButton
        Me.btSave = New System.Windows.Forms.ToolStripButton
        Me.btDelete = New System.Windows.Forms.ToolStripButton
        Me._Toolbar1_Button5 = New System.Windows.Forms.ToolStripSeparator
        Me.btExit = New System.Windows.Forms.ToolStripButton
        Me.lbHeader = New System.Windows.Forms.Label
        Me.dgLeft = New System.Windows.Forms.DataGridView
        Me.dgRight = New System.Windows.Forms.DataGridView
        Me.Toolbar1.SuspendLayout()
        CType(Me.dgLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbHeader
        '
        Me.cbHeader.BackColor = System.Drawing.SystemColors.Window
        Me.cbHeader.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbHeader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbHeader.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbHeader.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbHeader.Location = New System.Drawing.Point(368, 56)
        Me.cbHeader.Name = "cbHeader"
        Me.cbHeader.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbHeader.Size = New System.Drawing.Size(113, 22)
        Me.cbHeader.TabIndex = 6
        '
        'txtHeader
        '
        Me.txtHeader.AcceptsReturn = True
        Me.txtHeader.BackColor = System.Drawing.SystemColors.Window
        Me.txtHeader.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHeader.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeader.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHeader.Location = New System.Drawing.Point(176, 56)
        Me.txtHeader.MaxLength = 0
        Me.txtHeader.Name = "txtHeader"
        Me.txtHeader.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHeader.Size = New System.Drawing.Size(153, 20)
        Me.txtHeader.TabIndex = 5
        Me.txtHeader.Text = "txtHeader"
        '
        'cmdRight
        '
        Me.cmdRight.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRight.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRight.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRight.Location = New System.Drawing.Point(288, 200)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRight.Size = New System.Drawing.Size(33, 33)
        Me.cmdRight.TabIndex = 1
        Me.cmdRight.Text = ">"
        Me.cmdRight.UseVisualStyleBackColor = False
        '
        'cmdLeft
        '
        Me.cmdLeft.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLeft.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLeft.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLeft.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLeft.Location = New System.Drawing.Point(288, 264)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLeft.Size = New System.Drawing.Size(33, 33)
        Me.cmdLeft.TabIndex = 0
        Me.cmdLeft.Text = "<"
        Me.cmdLeft.UseVisualStyleBackColor = False
        '
        'Toolbar1
        '
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNew, Me.btSave, Me.btDelete, Me._Toolbar1_Button5, Me.btExit})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(619, 39)
        Me.Toolbar1.TabIndex = 7
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
        'btSave
        '
        Me.btSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btSave.Image = CType(resources.GetObject("btSave.Image"), System.Drawing.Image)
        Me.btSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(36, 36)
        Me.btSave.Text = "Save"
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
        'lbHeader
        '
        Me.lbHeader.BackColor = System.Drawing.SystemColors.Control
        Me.lbHeader.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbHeader.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHeader.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbHeader.Location = New System.Drawing.Point(40, 56)
        Me.lbHeader.Name = "lbHeader"
        Me.lbHeader.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbHeader.Size = New System.Drawing.Size(113, 17)
        Me.lbHeader.TabIndex = 4
        Me.lbHeader.Text = "lbHeader"
        '
        'dgLeft
        '
        Me.dgLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLeft.Location = New System.Drawing.Point(12, 96)
        Me.dgLeft.Name = "dgLeft"
        Me.dgLeft.Size = New System.Drawing.Size(261, 305)
        Me.dgLeft.TabIndex = 8
        '
        'dgRight
        '
        Me.dgRight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRight.Location = New System.Drawing.Point(336, 96)
        Me.dgRight.Name = "dgRight"
        Me.dgRight.Size = New System.Drawing.Size(257, 305)
        Me.dgRight.TabIndex = 9
        '
        'tplGridSelector2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(619, 429)
        Me.Controls.Add(Me.dgRight)
        Me.Controls.Add(Me.dgLeft)
        Me.Controls.Add(Me.cbHeader)
        Me.Controls.Add(Me.txtHeader)
        Me.Controls.Add(Me.cmdRight)
        Me.Controls.Add(Me.cmdLeft)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.lbHeader)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "tplGridSelector2"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Form1"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dgLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgLeft As System.Windows.Forms.DataGridView
    Friend WithEvents dgRight As System.Windows.Forms.DataGridView
    Friend WithEvents btNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btExit As System.Windows.Forms.ToolStripButton
#End Region 
End Class