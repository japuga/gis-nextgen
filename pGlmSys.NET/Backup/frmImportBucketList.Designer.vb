<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmImportBucketList
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
	Public WithEvents cmdOpen As System.Windows.Forms.Button
	Public WithEvents txtFile As System.Windows.Forms.TextBox
	Public WithEvents cmdImport As System.Windows.Forms.Button
	Public cdFileOpen As System.Windows.Forms.OpenFileDialog
	Public cdFileSave As System.Windows.Forms.SaveFileDialog
	Public cdFileFont As System.Windows.Forms.FontDialog
	Public cdFileColor As System.Windows.Forms.ColorDialog
	Public cdFilePrint As System.Windows.Forms.PrintDialog
	Public WithEvents _sbLoad_Panel1 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents sbLoad As System.Windows.Forms.StatusStrip
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdOpen = New System.Windows.Forms.Button
        Me.txtFile = New System.Windows.Forms.TextBox
        Me.cmdImport = New System.Windows.Forms.Button
        Me.cdFileOpen = New System.Windows.Forms.OpenFileDialog
        Me.cdFileSave = New System.Windows.Forms.SaveFileDialog
        Me.cdFileFont = New System.Windows.Forms.FontDialog
        Me.cdFileColor = New System.Windows.Forms.ColorDialog
        Me.cdFilePrint = New System.Windows.Forms.PrintDialog
        Me.sbLoad = New System.Windows.Forms.StatusStrip
        Me._sbLoad_Panel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Label1 = New System.Windows.Forms.Label
        Me.sbLoad.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOpen
        '
        Me.cmdOpen.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOpen.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOpen.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOpen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOpen.Location = New System.Drawing.Point(592, 56)
        Me.cmdOpen.Name = "cmdOpen"
        Me.cmdOpen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOpen.Size = New System.Drawing.Size(89, 25)
        Me.cmdOpen.TabIndex = 2
        Me.cmdOpen.Text = "Open "
        Me.cmdOpen.UseVisualStyleBackColor = False
        '
        'txtFile
        '
        Me.txtFile.AcceptsReturn = True
        Me.txtFile.BackColor = System.Drawing.SystemColors.Window
        Me.txtFile.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFile.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFile.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFile.Location = New System.Drawing.Point(120, 56)
        Me.txtFile.MaxLength = 0
        Me.txtFile.Name = "txtFile"
        Me.txtFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFile.Size = New System.Drawing.Size(465, 21)
        Me.txtFile.TabIndex = 1
        '
        'cmdImport
        '
        Me.cmdImport.BackColor = System.Drawing.SystemColors.Control
        Me.cmdImport.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdImport.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdImport.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdImport.Location = New System.Drawing.Point(280, 104)
        Me.cmdImport.Name = "cmdImport"
        Me.cmdImport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdImport.Size = New System.Drawing.Size(145, 25)
        Me.cmdImport.TabIndex = 0
        Me.cmdImport.Text = "Import"
        Me.cmdImport.UseVisualStyleBackColor = False
        '
        'sbLoad
        '
        Me.sbLoad.AutoSize = False
        Me.sbLoad.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sbLoad.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._sbLoad_Panel1})
        Me.sbLoad.Location = New System.Drawing.Point(0, 182)
        Me.sbLoad.Name = "sbLoad"
        Me.sbLoad.Size = New System.Drawing.Size(721, 25)
        Me.sbLoad.TabIndex = 4
        '
        '_sbLoad_Panel1
        '
        Me._sbLoad_Panel1.AutoSize = False
        Me._sbLoad_Panel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._sbLoad_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._sbLoad_Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me._sbLoad_Panel1.Name = "_sbLoad_Panel1"
        Me._sbLoad_Panel1.Size = New System.Drawing.Size(300, 25)
        Me._sbLoad_Panel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(89, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Open  Excel File"
        '
        'frmImportBucketList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(721, 207)
        Me.Controls.Add(Me.cmdOpen)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.cmdImport)
        Me.Controls.Add(Me.sbLoad)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "frmImportBucketList"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Import Bucket List data"
        Me.sbLoad.ResumeLayout(False)
        Me.sbLoad.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class