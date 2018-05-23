<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCheckBrowseDet
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
	Public WithEvents cmdRenumber As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdCLose As System.Windows.Forms.Button
	Public WithEvents cmdPrint As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdRenumber = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdCLose = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.dgChecks = New System.Windows.Forms.DataGridView
        Me.dgCheckDetail = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.dgChecks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCheckDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdRenumber
        '
        Me.cmdRenumber.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRenumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRenumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRenumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRenumber.Location = New System.Drawing.Point(56, 504)
        Me.cmdRenumber.Name = "cmdRenumber"
        Me.cmdRenumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRenumber.Size = New System.Drawing.Size(65, 33)
        Me.cmdRenumber.TabIndex = 5
        Me.cmdRenumber.Text = "Renumber"
        Me.cmdRenumber.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(144, 504)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(65, 33)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel Check"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdCLose
        '
        Me.cmdCLose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCLose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCLose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCLose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCLose.Location = New System.Drawing.Point(320, 504)
        Me.cmdCLose.Name = "cmdCLose"
        Me.cmdCLose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCLose.Size = New System.Drawing.Size(65, 33)
        Me.cmdCLose.TabIndex = 3
        Me.cmdCLose.Text = "Close"
        Me.cmdCLose.UseVisualStyleBackColor = False
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPrint.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPrint.Location = New System.Drawing.Point(232, 504)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPrint.Size = New System.Drawing.Size(65, 33)
        Me.cmdPrint.TabIndex = 2
        Me.cmdPrint.Text = "Print / Void"
        Me.cmdPrint.UseVisualStyleBackColor = False
        '
        'dgChecks
        '
        Me.dgChecks.AllowUserToAddRows = False
        Me.dgChecks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgChecks.Location = New System.Drawing.Point(24, 38)
        Me.dgChecks.MultiSelect = False
        Me.dgChecks.Name = "dgChecks"
        Me.dgChecks.Size = New System.Drawing.Size(393, 211)
        Me.dgChecks.TabIndex = 6
        '
        'dgCheckDetail
        '
        Me.dgCheckDetail.AllowUserToAddRows = False
        Me.dgCheckDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCheckDetail.Location = New System.Drawing.Point(24, 293)
        Me.dgCheckDetail.MultiSelect = False
        Me.dgCheckDetail.Name = "dgCheckDetail"
        Me.dgCheckDetail.Size = New System.Drawing.Size(401, 188)
        Me.dgCheckDetail.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(179, 274)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Check Details"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(172, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Printed Checks"
        '
        'frmCheckBrowseDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(462, 551)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgCheckDetail)
        Me.Controls.Add(Me.dgChecks)
        Me.Controls.Add(Me.cmdRenumber)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdCLose)
        Me.Controls.Add(Me.cmdPrint)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmCheckBrowseDet"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Check List"
        CType(Me.dgChecks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCheckDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgChecks As System.Windows.Forms.DataGridView
    Friend WithEvents dgCheckDetail As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
#End Region 
End Class