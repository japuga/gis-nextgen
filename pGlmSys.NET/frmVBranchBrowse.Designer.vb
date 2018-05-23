<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmVBranchBrowse
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
	Public WithEvents txtVendPayAddress As System.Windows.Forms.TextBox
	Public WithEvents txtVendName As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtVendPayAddress = New System.Windows.Forms.TextBox
        Me.txtVendName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.dgVBranch = New System.Windows.Forms.DataGridView
        CType(Me.dgVBranch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtVendPayAddress
        '
        Me.txtVendPayAddress.AcceptsReturn = True
        Me.txtVendPayAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendPayAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendPayAddress.Enabled = False
        Me.txtVendPayAddress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendPayAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendPayAddress.Location = New System.Drawing.Point(120, 48)
        Me.txtVendPayAddress.MaxLength = 0
        Me.txtVendPayAddress.Name = "txtVendPayAddress"
        Me.txtVendPayAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendPayAddress.Size = New System.Drawing.Size(297, 20)
        Me.txtVendPayAddress.TabIndex = 4
        '
        'txtVendName
        '
        Me.txtVendName.AcceptsReturn = True
        Me.txtVendName.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVendName.Enabled = False
        Me.txtVendName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVendName.Location = New System.Drawing.Point(80, 16)
        Me.txtVendName.MaxLength = 0
        Me.txtVendName.Name = "txtVendName"
        Me.txtVendName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVendName.Size = New System.Drawing.Size(337, 20)
        Me.txtVendName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(12, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(102, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Payment Address"
        '
        'label1
        '
        Me.label1.BackColor = System.Drawing.SystemColors.Control
        Me.label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label1.Location = New System.Drawing.Point(16, 16)
        Me.label1.Name = "label1"
        Me.label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label1.Size = New System.Drawing.Size(49, 17)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Vendor"
        '
        'dgVBranch
        '
        Me.dgVBranch.AllowUserToAddRows = False
        Me.dgVBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgVBranch.Location = New System.Drawing.Point(12, 84)
        Me.dgVBranch.Name = "dgVBranch"
        Me.dgVBranch.Size = New System.Drawing.Size(405, 206)
        Me.dgVBranch.TabIndex = 5
        '
        'frmVBranchBrowse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(453, 302)
        Me.Controls.Add(Me.dgVBranch)
        Me.Controls.Add(Me.txtVendPayAddress)
        Me.Controls.Add(Me.txtVendName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmVBranchBrowse"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "List of Vendor Branches"
        CType(Me.dgVBranch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgVBranch As System.Windows.Forms.DataGridView
#End Region 
End Class