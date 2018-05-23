<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStoreEqpt
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
    Public WithEvents lbEquipment As System.Windows.Forms.Label
	Public WithEvents lbCustomer As System.Windows.Forms.Label
	Public WithEvents lbState As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStoreEqpt))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip
        Me.btNew = New System.Windows.Forms.ToolStripButton
        Me.btSave = New System.Windows.Forms.ToolStripButton
        Me.btSearch = New System.Windows.Forms.ToolStripButton
        Me._Toolbar1_Button4 = New System.Windows.Forms.ToolStripSeparator
        Me.btExit = New System.Windows.Forms.ToolStripButton
        Me.lbEquipment = New System.Windows.Forms.Label
        Me.lbCustomer = New System.Windows.Forms.Label
        Me.lbState = New System.Windows.Forms.Label
        Me.dgStore = New System.Windows.Forms.DataGridView
        Me.dgStoreEqpt = New System.Windows.Forms.DataGridView
        Me.Toolbar1.SuspendLayout()
        CType(Me.dgStore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgStoreEqpt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNew, Me.btSave, Me.btSearch, Me._Toolbar1_Button4, Me.btExit})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(549, 39)
        Me.Toolbar1.TabIndex = 0
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
        'btSearch
        '
        Me.btSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btSearch.Image = CType(resources.GetObject("btSearch.Image"), System.Drawing.Image)
        Me.btSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btSearch.Name = "btSearch"
        Me.btSearch.Size = New System.Drawing.Size(36, 36)
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
        Me.btExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btExit.Image = CType(resources.GetObject("btExit.Image"), System.Drawing.Image)
        Me.btExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btExit.Name = "btExit"
        Me.btExit.Size = New System.Drawing.Size(36, 36)
        Me.btExit.Text = "Exit"
        '
        'lbEquipment
        '
        Me.lbEquipment.BackColor = System.Drawing.SystemColors.Control
        Me.lbEquipment.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbEquipment.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEquipment.ForeColor = System.Drawing.Color.Red
        Me.lbEquipment.Location = New System.Drawing.Point(24, 296)
        Me.lbEquipment.Name = "lbEquipment"
        Me.lbEquipment.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbEquipment.Size = New System.Drawing.Size(465, 17)
        Me.lbEquipment.TabIndex = 4
        Me.lbEquipment.Text = "Equipment"
        '
        'lbCustomer
        '
        Me.lbCustomer.BackColor = System.Drawing.SystemColors.Control
        Me.lbCustomer.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbCustomer.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCustomer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbCustomer.Location = New System.Drawing.Point(16, 64)
        Me.lbCustomer.Name = "lbCustomer"
        Me.lbCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbCustomer.Size = New System.Drawing.Size(241, 17)
        Me.lbCustomer.TabIndex = 3
        Me.lbCustomer.Text = "Customer"
        '
        'lbState
        '
        Me.lbState.BackColor = System.Drawing.SystemColors.Control
        Me.lbState.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbState.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbState.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbState.Location = New System.Drawing.Point(272, 64)
        Me.lbState.Name = "lbState"
        Me.lbState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbState.Size = New System.Drawing.Size(137, 17)
        Me.lbState.TabIndex = 2
        Me.lbState.Text = "State"
        '
        'dgStore
        '
        Me.dgStore.AllowUserToAddRows = False
        Me.dgStore.AllowUserToDeleteRows = False
        Me.dgStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgStore.Location = New System.Drawing.Point(16, 84)
        Me.dgStore.MultiSelect = False
        Me.dgStore.Name = "dgStore"
        Me.dgStore.Size = New System.Drawing.Size(505, 169)
        Me.dgStore.TabIndex = 6
        '
        'dgStoreEqpt
        '
        Me.dgStoreEqpt.AllowUserToAddRows = False
        Me.dgStoreEqpt.AllowUserToDeleteRows = False
        Me.dgStoreEqpt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgStoreEqpt.Location = New System.Drawing.Point(16, 316)
        Me.dgStoreEqpt.MultiSelect = False
        Me.dgStoreEqpt.Name = "dgStoreEqpt"
        Me.dgStoreEqpt.Size = New System.Drawing.Size(505, 193)
        Me.dgStoreEqpt.TabIndex = 7
        '
        'frmStoreEqpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(549, 550)
        Me.Controls.Add(Me.dgStoreEqpt)
        Me.Controls.Add(Me.dgStore)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.lbEquipment)
        Me.Controls.Add(Me.lbCustomer)
        Me.Controls.Add(Me.lbState)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStoreEqpt"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Equipment Assigned to Store"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dgStore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgStoreEqpt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgStore As System.Windows.Forms.DataGridView
    Friend WithEvents dgStoreEqpt As System.Windows.Forms.DataGridView
    Friend WithEvents btNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents btExit As System.Windows.Forms.ToolStripButton
#End Region 
End Class