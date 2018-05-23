<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmVBranchSelection
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
    Public WithEvents txtVendName As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
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
        Me.txtVendName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgVBranch = New System.Windows.Forms.DataGridView
        Me.lblAvailBranches = New System.Windows.Forms.Label
        Me.dgSelVBranch = New System.Windows.Forms.DataGridView
        Me.lbSelBranch = New System.Windows.Forms.Label
        CType(Me.dgVBranch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSelVBranch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(320, 352)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 33)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(232, 352)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(57, 33)
        Me.cmdOk.TabIndex = 6
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'cmdLeft
        '
        Me.cmdLeft.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLeft.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLeft.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLeft.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLeft.Location = New System.Drawing.Point(280, 192)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLeft.Size = New System.Drawing.Size(57, 33)
        Me.cmdLeft.TabIndex = 5
        Me.cmdLeft.Text = "<"
        Me.cmdLeft.UseVisualStyleBackColor = False
        '
        'cmdRight
        '
        Me.cmdRight.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRight.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRight.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRight.Location = New System.Drawing.Point(280, 136)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRight.Size = New System.Drawing.Size(57, 33)
        Me.cmdRight.TabIndex = 4
        Me.cmdRight.Text = ">"
        Me.cmdRight.UseVisualStyleBackColor = False
        '
        'txtVendName
        '
        Me.txtVendName.AcceptsReturn = True
        Me.txtVendName.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendName.Location = New System.Drawing.Point(96, 24)
        Me.txtVendName.MaxLength = 0
        Me.txtVendName.Name = "txtVendName"
        Me.txtVendName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendName.Size = New System.Drawing.Size(473, 20)
        Me.txtVendName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(40, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vendor"
        '
        'dgVBranch
        '
        Me.dgVBranch.AllowUserToAddRows = False
        Me.dgVBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgVBranch.Location = New System.Drawing.Point(32, 86)
        Me.dgVBranch.Name = "dgVBranch"
        Me.dgVBranch.Size = New System.Drawing.Size(217, 233)
        Me.dgVBranch.TabIndex = 8
        '
        'lblAvailBranches
        '
        Me.lblAvailBranches.AutoSize = True
        Me.lblAvailBranches.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblAvailBranches.Location = New System.Drawing.Point(83, 68)
        Me.lblAvailBranches.Name = "lblAvailBranches"
        Me.lblAvailBranches.Size = New System.Drawing.Size(112, 15)
        Me.lblAvailBranches.TabIndex = 9
        Me.lblAvailBranches.Text = "Available Branches"
        '
        'dgSelVBranch
        '
        Me.dgSelVBranch.AllowUserToAddRows = False
        Me.dgSelVBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSelVBranch.Location = New System.Drawing.Point(372, 86)
        Me.dgSelVBranch.Name = "dgSelVBranch"
        Me.dgSelVBranch.Size = New System.Drawing.Size(217, 233)
        Me.dgSelVBranch.TabIndex = 10
        '
        'lbSelBranch
        '
        Me.lbSelBranch.AutoSize = True
        Me.lbSelBranch.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lbSelBranch.Location = New System.Drawing.Point(424, 68)
        Me.lbSelBranch.Name = "lbSelBranch"
        Me.lbSelBranch.Size = New System.Drawing.Size(111, 15)
        Me.lbSelBranch.TabIndex = 11
        Me.lbSelBranch.Text = "Selected Branches"
        '
        'frmVBranchSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(610, 409)
        Me.Controls.Add(Me.lbSelBranch)
        Me.Controls.Add(Me.dgSelVBranch)
        Me.Controls.Add(Me.lblAvailBranches)
        Me.Controls.Add(Me.dgVBranch)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdLeft)
        Me.Controls.Add(Me.cmdRight)
        Me.Controls.Add(Me.txtVendName)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmVBranchSelection"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Vendor Branch Selection"
        CType(Me.dgVBranch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSelVBranch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgVBranch As System.Windows.Forms.DataGridView
    Friend WithEvents lblAvailBranches As System.Windows.Forms.Label
    Friend WithEvents dgSelVBranch As System.Windows.Forms.DataGridView
    Friend WithEvents lbSelBranch As System.Windows.Forms.Label
#End Region 
End Class