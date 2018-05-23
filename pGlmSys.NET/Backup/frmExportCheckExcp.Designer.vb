<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmExportCheckExcp
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
    Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdClose = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgException = New System.Windows.Forms.DataGridView
        Me.lblCheckDetails = New System.Windows.Forms.Label
        Me.dgCheckDetail = New System.Windows.Forms.DataGridView
        CType(Me.dgException, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCheckDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(290, 448)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(73, 33)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(32, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(361, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Export process failed due to duplicate Checks found:"
        '
        'dgException
        '
        Me.dgException.AllowUserToAddRows = False
        Me.dgException.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgException.Location = New System.Drawing.Point(32, 28)
        Me.dgException.Name = "dgException"
        Me.dgException.Size = New System.Drawing.Size(601, 177)
        Me.dgException.TabIndex = 4
        '
        'lblCheckDetails
        '
        Me.lblCheckDetails.AutoSize = True
        Me.lblCheckDetails.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckDetails.Location = New System.Drawing.Point(291, 238)
        Me.lblCheckDetails.Name = "lblCheckDetails"
        Me.lblCheckDetails.Size = New System.Drawing.Size(89, 16)
        Me.lblCheckDetails.TabIndex = 5
        Me.lblCheckDetails.Text = "Check Details"
        '
        'dgCheckDetail
        '
        Me.dgCheckDetail.AllowUserToAddRows = False
        Me.dgCheckDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCheckDetail.Location = New System.Drawing.Point(32, 257)
        Me.dgCheckDetail.Name = "dgCheckDetail"
        Me.dgCheckDetail.Size = New System.Drawing.Size(601, 168)
        Me.dgCheckDetail.TabIndex = 6
        '
        'frmExportCheckExcp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(677, 505)
        Me.Controls.Add(Me.dgCheckDetail)
        Me.Controls.Add(Me.lblCheckDetails)
        Me.Controls.Add(Me.dgException)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmExportCheckExcp"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Exception Check List"
        CType(Me.dgException, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCheckDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgException As System.Windows.Forms.DataGridView
    Friend WithEvents lblCheckDetails As System.Windows.Forms.Label
    Friend WithEvents dgCheckDetail As System.Windows.Forms.DataGridView
#End Region 
End Class