<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmVendor
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
    Public WithEvents _Toolbar1_Button4 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
	Public WithEvents lbState As System.Windows.Forms.Label
	Public WithEvents lbVendor As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVendor))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip
        Me.btNew = New System.Windows.Forms.ToolStripButton
        Me.btSave = New System.Windows.Forms.ToolStripButton
        Me.btSearch = New System.Windows.Forms.ToolStripButton
        Me._Toolbar1_Button4 = New System.Windows.Forms.ToolStripSeparator
        Me.btExit = New System.Windows.Forms.ToolStripButton
        Me.lbState = New System.Windows.Forms.Label
        Me.lbVendor = New System.Windows.Forms.Label
        Me.dgVendor = New System.Windows.Forms.DataGridView
        Me.Toolbar1.SuspendLayout()
        CType(Me.dgVendor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNew, Me.btSave, Me.btSearch, Me._Toolbar1_Button4, Me.btExit})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Padding = New System.Windows.Forms.Padding(3, 1, 3, 0)
        Me.Toolbar1.Size = New System.Drawing.Size(612, 56)
        Me.Toolbar1.TabIndex = 0
        '
        'btNew
        '
        Me.btNew.AutoSize = False
        Me.btNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btNew.Image = CType(resources.GetObject("btNew.Image"), System.Drawing.Image)
        Me.btNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btNew.Name = "btNew"
        Me.btNew.Size = New System.Drawing.Size(38, 32)
        Me.btNew.Text = "New"
        '
        'btSave
        '
        Me.btSave.AutoSize = False
        Me.btSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btSave.Image = CType(resources.GetObject("btSave.Image"), System.Drawing.Image)
        Me.btSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btSave.Name = "btSave"
        Me.btSave.RightToLeftAutoMirrorImage = True
        Me.btSave.Size = New System.Drawing.Size(38, 32)
        Me.btSave.Text = "Save"
        '
        'btSearch
        '
        Me.btSearch.AutoSize = False
        Me.btSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btSearch.Image = CType(resources.GetObject("btSearch.Image"), System.Drawing.Image)
        Me.btSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btSearch.Name = "btSearch"
        Me.btSearch.Size = New System.Drawing.Size(38, 32)
        Me.btSearch.Text = "Search"
        '
        '_Toolbar1_Button4
        '
        Me._Toolbar1_Button4.AutoSize = False
        Me._Toolbar1_Button4.Name = "_Toolbar1_Button4"
        Me._Toolbar1_Button4.Size = New System.Drawing.Size(10, 39)
        '
        'btExit
        '
        Me.btExit.AutoSize = False
        Me.btExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btExit.Image = CType(resources.GetObject("btExit.Image"), System.Drawing.Image)
        Me.btExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btExit.Name = "btExit"
        Me.btExit.Size = New System.Drawing.Size(38, 32)
        Me.btExit.Text = "Exit"
        '
        'lbState
        '
        Me.lbState.BackColor = System.Drawing.SystemColors.Control
        Me.lbState.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbState.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbState.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbState.Location = New System.Drawing.Point(16, 72)
        Me.lbState.Name = "lbState"
        Me.lbState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbState.Size = New System.Drawing.Size(177, 25)
        Me.lbState.TabIndex = 3
        Me.lbState.Text = "State"
        '
        'lbVendor
        '
        Me.lbVendor.BackColor = System.Drawing.SystemColors.Control
        Me.lbVendor.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbVendor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVendor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbVendor.Location = New System.Drawing.Point(16, 56)
        Me.lbVendor.Name = "lbVendor"
        Me.lbVendor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbVendor.Size = New System.Drawing.Size(441, 17)
        Me.lbVendor.TabIndex = 2
        Me.lbVendor.Text = "Vendor"
        '
        'dgVendor
        '
        Me.dgVendor.AllowUserToAddRows = False
        Me.dgVendor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgVendor.Location = New System.Drawing.Point(12, 100)
        Me.dgVendor.Name = "dgVendor"
        Me.dgVendor.Size = New System.Drawing.Size(588, 392)
        Me.dgVendor.TabIndex = 4
        '
        'frmVendor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(612, 504)
        Me.Controls.Add(Me.dgVendor)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.lbState)
        Me.Controls.Add(Me.lbVendor)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmVendor"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Vendor Maintenance"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dgVendor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents btExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgVendor As System.Windows.Forms.DataGridView
#End Region 
End Class