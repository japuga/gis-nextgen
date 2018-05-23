<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmUserPriv
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
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
	Public WithEvents cbUserDesc As System.Windows.Forms.ComboBox
	Public WithEvents cmdAddMember As System.Windows.Forms.Button
	Public WithEvents cmdRemoveMember As System.Windows.Forms.Button
    Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents cbUserName As System.Windows.Forms.ComboBox
	Public WithEvents _Toolbar1_Button2 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserPriv))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbCustName = New System.Windows.Forms.ComboBox
        Me.cbUserDesc = New System.Windows.Forms.ComboBox
        Me.cmdAddMember = New System.Windows.Forms.Button
        Me.cmdRemoveMember = New System.Windows.Forms.Button
        Me.cbCustId = New System.Windows.Forms.ComboBox
        Me.cbUserName = New System.Windows.Forms.ComboBox
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip
        Me.btSave = New System.Windows.Forms.ToolStripButton
        Me._Toolbar1_Button2 = New System.Windows.Forms.ToolStripSeparator
        Me.btExit = New System.Windows.Forms.ToolStripButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgAssgState = New System.Windows.Forms.DataGridView
        Me.dgState = New System.Windows.Forms.DataGridView
        Me.Toolbar1.SuspendLayout()
        CType(Me.dgAssgState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgState, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbCustName
        '
        Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cbCustName.Enabled = False
        Me.cbCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustName.Location = New System.Drawing.Point(160, 128)
        Me.cbCustName.Name = "cbCustName"
        Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustName.Size = New System.Drawing.Size(217, 21)
        Me.cbCustName.TabIndex = 10
        Me.cbCustName.Text = "cbCustName"
        '
        'cbUserDesc
        '
        Me.cbUserDesc.BackColor = System.Drawing.SystemColors.Window
        Me.cbUserDesc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbUserDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cbUserDesc.Enabled = False
        Me.cbUserDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUserDesc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbUserDesc.Location = New System.Drawing.Point(200, 80)
        Me.cbUserDesc.Name = "cbUserDesc"
        Me.cbUserDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbUserDesc.Size = New System.Drawing.Size(177, 21)
        Me.cbUserDesc.TabIndex = 8
        Me.cbUserDesc.Text = "cbUserDesc"
        '
        'cmdAddMember
        '
        Me.cmdAddMember.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAddMember.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAddMember.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddMember.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAddMember.Location = New System.Drawing.Point(288, 264)
        Me.cmdAddMember.Name = "cmdAddMember"
        Me.cmdAddMember.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAddMember.Size = New System.Drawing.Size(41, 25)
        Me.cmdAddMember.TabIndex = 7
        Me.cmdAddMember.Text = "<"
        Me.cmdAddMember.UseVisualStyleBackColor = False
        '
        'cmdRemoveMember
        '
        Me.cmdRemoveMember.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRemoveMember.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRemoveMember.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemoveMember.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRemoveMember.Location = New System.Drawing.Point(288, 208)
        Me.cmdRemoveMember.Name = "cmdRemoveMember"
        Me.cmdRemoveMember.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRemoveMember.Size = New System.Drawing.Size(41, 25)
        Me.cmdRemoveMember.TabIndex = 6
        Me.cmdRemoveMember.Text = ">"
        Me.cmdRemoveMember.UseVisualStyleBackColor = False
        '
        'cbCustId
        '
        Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustId.Location = New System.Drawing.Point(80, 128)
        Me.cbCustId.Name = "cbCustId"
        Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustId.Size = New System.Drawing.Size(65, 22)
        Me.cbCustId.TabIndex = 3
        '
        'cbUserName
        '
        Me.cbUserName.BackColor = System.Drawing.SystemColors.Window
        Me.cbUserName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUserName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUserName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbUserName.Location = New System.Drawing.Point(80, 80)
        Me.cbUserName.Name = "cbUserName"
        Me.cbUserName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbUserName.Size = New System.Drawing.Size(97, 22)
        Me.cbUserName.TabIndex = 1
        '
        'Toolbar1
        '
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btSave, Me._Toolbar1_Button2, Me.btExit})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(603, 39)
        Me.Toolbar1.TabIndex = 9
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
        '_Toolbar1_Button2
        '
        Me._Toolbar1_Button2.AutoSize = False
        Me._Toolbar1_Button2.Name = "_Toolbar1_Button2"
        Me._Toolbar1_Button2.Size = New System.Drawing.Size(10, 39)
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
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Customer"
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
        Me.Label1.Size = New System.Drawing.Size(41, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User"
        '
        'dgAssgState
        '
        Me.dgAssgState.AllowUserToAddRows = False
        Me.dgAssgState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAssgState.Location = New System.Drawing.Point(27, 184)
        Me.dgAssgState.Name = "dgAssgState"
        Me.dgAssgState.Size = New System.Drawing.Size(217, 145)
        Me.dgAssgState.TabIndex = 11
        '
        'dgState
        '
        Me.dgState.AllowUserToAddRows = False
        Me.dgState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgState.Location = New System.Drawing.Point(359, 184)
        Me.dgState.Name = "dgState"
        Me.dgState.Size = New System.Drawing.Size(217, 145)
        Me.dgState.TabIndex = 12
        '
        'frmUserPriv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(603, 363)
        Me.Controls.Add(Me.dgState)
        Me.Controls.Add(Me.dgAssgState)
        Me.Controls.Add(Me.cbCustName)
        Me.Controls.Add(Me.cbUserDesc)
        Me.Controls.Add(Me.cmdAddMember)
        Me.Controls.Add(Me.cmdRemoveMember)
        Me.Controls.Add(Me.cbCustId)
        Me.Controls.Add(Me.cbUserName)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmUserPriv"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "User Privileges"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dgAssgState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgState, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgAssgState As System.Windows.Forms.DataGridView
    Friend WithEvents dgState As System.Windows.Forms.DataGridView
#End Region 
End Class