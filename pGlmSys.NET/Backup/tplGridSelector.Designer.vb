<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class tplGridSelector
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
	Public WithEvents cmdLeft As System.Windows.Forms.Button
	Public WithEvents cmdRight As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdLeft = New System.Windows.Forms.Button
        Me.cmdRight = New System.Windows.Forms.Button
        Me.dgLeft = New System.Windows.Forms.DataGridView
        Me.dgRight = New System.Windows.Forms.DataGridView
        CType(Me.dgLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(136, 368)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(73, 33)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(24, 368)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(73, 33)
        Me.cmdOk.TabIndex = 4
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'cmdLeft
        '
        Me.cmdLeft.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLeft.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLeft.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLeft.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLeft.Location = New System.Drawing.Point(296, 200)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLeft.Size = New System.Drawing.Size(33, 33)
        Me.cmdLeft.TabIndex = 3
        Me.cmdLeft.Text = "<"
        Me.cmdLeft.UseVisualStyleBackColor = False
        '
        'cmdRight
        '
        Me.cmdRight.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRight.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRight.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRight.Location = New System.Drawing.Point(296, 136)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRight.Size = New System.Drawing.Size(33, 33)
        Me.cmdRight.TabIndex = 2
        Me.cmdRight.Text = ">"
        Me.cmdRight.UseVisualStyleBackColor = False
        '
        'dgLeft
        '
        Me.dgLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLeft.Location = New System.Drawing.Point(24, 32)
        Me.dgLeft.Name = "dgLeft"
        Me.dgLeft.Size = New System.Drawing.Size(257, 305)
        Me.dgLeft.TabIndex = 6
        '
        'dgRight
        '
        Me.dgRight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRight.Location = New System.Drawing.Point(348, 32)
        Me.dgRight.Name = "dgRight"
        Me.dgRight.Size = New System.Drawing.Size(240, 305)
        Me.dgRight.TabIndex = 7
        '
        'tplGridSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(638, 432)
        Me.Controls.Add(Me.dgRight)
        Me.Controls.Add(Me.dgLeft)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdLeft)
        Me.Controls.Add(Me.cmdRight)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "tplGridSelector"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Member Selector"
        CType(Me.dgLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgLeft As System.Windows.Forms.DataGridView
    Friend WithEvents dgRight As System.Windows.Forms.DataGridView
#End Region 
End Class