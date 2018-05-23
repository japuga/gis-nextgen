<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGroupStoreEntry
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
	Public WithEvents txtText As System.Windows.Forms.TextBox
	Public WithEvents txtContractNo As System.Windows.Forms.TextBox
	Public WithEvents txtAttention As System.Windows.Forms.TextBox
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cbTypeId As System.Windows.Forms.ComboBox
	Public WithEvents cmdAdd As System.Windows.Forms.Button
	Public WithEvents cmdRemove As System.Windows.Forms.Button
	Public WithEvents txtGroupName As System.Windows.Forms.TextBox
	Public WithEvents txtCustName As System.Windows.Forms.TextBox
	Public WithEvents cmdFilter As System.Windows.Forms.Button
	Public WithEvents cmdShowAll As System.Windows.Forms.Button
    Public WithEvents _Toolbar1_Button2 As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents lbMessage As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGroupStoreEntry))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.txtText = New System.Windows.Forms.TextBox
        Me.txtContractNo = New System.Windows.Forms.TextBox
        Me.txtAttention = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbTypeId = New System.Windows.Forms.ComboBox
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdRemove = New System.Windows.Forms.Button
        Me.txtGroupName = New System.Windows.Forms.TextBox
        Me.txtCustName = New System.Windows.Forms.TextBox
        Me.cmdFilter = New System.Windows.Forms.Button
        Me.cmdShowAll = New System.Windows.Forms.Button
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip
        Me.btNew = New System.Windows.Forms.ToolStripButton
        Me._Toolbar1_Button2 = New System.Windows.Forms.ToolStripSeparator
        Me.btExit = New System.Windows.Forms.ToolStripButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbMessage = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgGroupStore = New System.Windows.Forms.DataGridView
        Me.dgStores = New System.Windows.Forms.DataGridView
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Frame1.SuspendLayout()
        Me.Toolbar1.SuspendLayout()
        CType(Me.dgGroupStore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgStores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.txtText)
        Me.Frame1.Controls.Add(Me.txtContractNo)
        Me.Frame1.Controls.Add(Me.txtAttention)
        Me.Frame1.Controls.Add(Me.Label6)
        Me.Frame1.Controls.Add(Me.Label5)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(368, 56)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(321, 137)
        Me.Frame1.TabIndex = 14
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Customer Invoice Settings"
        '
        'txtText
        '
        Me.txtText.AcceptsReturn = True
        Me.txtText.BackColor = System.Drawing.SystemColors.Window
        Me.txtText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtText.Location = New System.Drawing.Point(64, 88)
        Me.txtText.MaxLength = 0
        Me.txtText.Multiline = True
        Me.txtText.Name = "txtText"
        Me.txtText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtText.Size = New System.Drawing.Size(249, 41)
        Me.txtText.TabIndex = 20
        '
        'txtContractNo
        '
        Me.txtContractNo.AcceptsReturn = True
        Me.txtContractNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtContractNo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtContractNo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContractNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtContractNo.Location = New System.Drawing.Point(64, 56)
        Me.txtContractNo.MaxLength = 0
        Me.txtContractNo.Name = "txtContractNo"
        Me.txtContractNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtContractNo.Size = New System.Drawing.Size(249, 20)
        Me.txtContractNo.TabIndex = 19
        '
        'txtAttention
        '
        Me.txtAttention.AcceptsReturn = True
        Me.txtAttention.BackColor = System.Drawing.SystemColors.Window
        Me.txtAttention.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAttention.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAttention.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAttention.Location = New System.Drawing.Point(64, 24)
        Me.txtAttention.MaxLength = 0
        Me.txtAttention.Name = "txtAttention"
        Me.txtAttention.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAttention.Size = New System.Drawing.Size(249, 20)
        Me.txtAttention.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(65, 17)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Contract #"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(57, 17)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Body Text"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(49, 17)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Attention"
        '
        'cbTypeId
        '
        Me.cbTypeId.BackColor = System.Drawing.SystemColors.Window
        Me.cbTypeId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTypeId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTypeId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbTypeId.Location = New System.Drawing.Point(64, 104)
        Me.cbTypeId.Name = "cbTypeId"
        Me.cbTypeId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbTypeId.Size = New System.Drawing.Size(249, 22)
        Me.cbTypeId.TabIndex = 13
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAdd.Location = New System.Drawing.Point(336, 368)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAdd.Size = New System.Drawing.Size(25, 25)
        Me.cmdAdd.TabIndex = 9
        Me.cmdAdd.Text = "<"
        Me.cmdAdd.UseVisualStyleBackColor = False
        '
        'cmdRemove
        '
        Me.cmdRemove.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRemove.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRemove.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRemove.Location = New System.Drawing.Point(336, 328)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRemove.Size = New System.Drawing.Size(25, 25)
        Me.cmdRemove.TabIndex = 8
        Me.cmdRemove.Text = ">"
        Me.cmdRemove.UseVisualStyleBackColor = False
        '
        'txtGroupName
        '
        Me.txtGroupName.AcceptsReturn = True
        Me.txtGroupName.BackColor = System.Drawing.SystemColors.Window
        Me.txtGroupName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGroupName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGroupName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGroupName.Location = New System.Drawing.Point(64, 144)
        Me.txtGroupName.MaxLength = 0
        Me.txtGroupName.Name = "txtGroupName"
        Me.txtGroupName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGroupName.Size = New System.Drawing.Size(249, 20)
        Me.txtGroupName.TabIndex = 5
        '
        'txtCustName
        '
        Me.txtCustName.AcceptsReturn = True
        Me.txtCustName.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCustName.Location = New System.Drawing.Point(64, 72)
        Me.txtCustName.MaxLength = 0
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCustName.Size = New System.Drawing.Size(249, 20)
        Me.txtCustName.TabIndex = 7
        '
        'cmdFilter
        '
        Me.cmdFilter.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFilter.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFilter.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFilter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFilter.Location = New System.Drawing.Point(456, 200)
        Me.cmdFilter.Name = "cmdFilter"
        Me.cmdFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFilter.Size = New System.Drawing.Size(57, 25)
        Me.cmdFilter.TabIndex = 6
        Me.cmdFilter.Text = "Filter"
        Me.cmdFilter.UseVisualStyleBackColor = False
        '
        'cmdShowAll
        '
        Me.cmdShowAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdShowAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdShowAll.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShowAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdShowAll.Location = New System.Drawing.Point(384, 200)
        Me.cmdShowAll.Name = "cmdShowAll"
        Me.cmdShowAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdShowAll.Size = New System.Drawing.Size(57, 25)
        Me.cmdShowAll.TabIndex = 4
        Me.cmdShowAll.Text = "Show All"
        Me.cmdShowAll.UseVisualStyleBackColor = False
        '
        'Toolbar1
        '
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNew, Me._Toolbar1_Button2, Me.btExit})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(702, 39)
        Me.Toolbar1.TabIndex = 10
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
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(41, 17)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Type"
        '
        'lbMessage
        '
        Me.lbMessage.BackColor = System.Drawing.SystemColors.Control
        Me.lbMessage.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbMessage.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMessage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbMessage.Location = New System.Drawing.Point(328, 488)
        Me.lbMessage.Name = "lbMessage"
        Me.lbMessage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbMessage.Size = New System.Drawing.Size(297, 41)
        Me.lbMessage.TabIndex = 11
        Me.lbMessage.Text = "All Records"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(12, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(37, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Group"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(12, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(61, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer"
        '
        'dgGroupStore
        '
        Me.dgGroupStore.AllowUserToAddRows = False
        Me.dgGroupStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgGroupStore.Location = New System.Drawing.Point(16, 256)
        Me.dgGroupStore.Name = "dgGroupStore"
        Me.dgGroupStore.Size = New System.Drawing.Size(297, 225)
        Me.dgGroupStore.TabIndex = 15
        '
        'dgStores
        '
        Me.dgStores.AllowUserToAddRows = False
        Me.dgStores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgStores.Location = New System.Drawing.Point(385, 256)
        Me.dgStores.Name = "dgStores"
        Me.dgStores.Size = New System.Drawing.Size(296, 225)
        Me.dgStores.TabIndex = 16
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.DataGridView1.Enabled = False
        Me.DataGridView1.Location = New System.Drawing.Point(16, 239)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(297, 21)
        Me.DataGridView1.TabIndex = 17
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Group Members"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        Me.DataGridView2.Enabled = False
        Me.DataGridView2.Location = New System.Drawing.Point(385, 239)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(296, 21)
        Me.DataGridView2.TabIndex = 18
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = "Available"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'frmGroupStoreEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(702, 536)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.dgStores)
        Me.Controls.Add(Me.dgGroupStore)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cbTypeId)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.txtGroupName)
        Me.Controls.Add(Me.txtCustName)
        Me.Controls.Add(Me.cmdFilter)
        Me.Controls.Add(Me.cmdShowAll)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbMessage)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmGroupStoreEntry"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Group Store Data Entry"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dgGroupStore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgStores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgGroupStore As System.Windows.Forms.DataGridView
    Friend WithEvents dgStores As System.Windows.Forms.DataGridView
    Friend WithEvents btNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region 
End Class