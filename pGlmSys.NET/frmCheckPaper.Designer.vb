<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCheckPaper
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
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents obBlank As System.Windows.Forms.RadioButton
	Public WithEvents obImprinted As System.Windows.Forms.RadioButton
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCheckPaper))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdOk = New System.Windows.Forms.Button
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.obBlank = New System.Windows.Forms.RadioButton
		Me.obImprinted = New System.Windows.Forms.RadioButton
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Paper Source"
		Me.ClientSize = New System.Drawing.Size(312, 198)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmCheckPaper"
		Me.cmdOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOk.Text = "OK"
		Me.cmdOk.Size = New System.Drawing.Size(81, 33)
		Me.cmdOk.Location = New System.Drawing.Point(112, 144)
		Me.cmdOk.TabIndex = 3
		Me.cmdOk.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOk.CausesValidation = True
		Me.cmdOk.Enabled = True
		Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOk.TabStop = True
		Me.cmdOk.Name = "cmdOk"
		Me.Frame1.Text = "Select Paper Source for Check"
		Me.Frame1.Size = New System.Drawing.Size(281, 97)
		Me.Frame1.Location = New System.Drawing.Point(16, 24)
		Me.Frame1.TabIndex = 0
		Me.Frame1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Name = "Frame1"
		Me.obBlank.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.obBlank.Text = "Blank Check"
		Me.obBlank.Size = New System.Drawing.Size(113, 25)
		Me.obBlank.Location = New System.Drawing.Point(8, 64)
		Me.obBlank.TabIndex = 2
		Me.obBlank.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.obBlank.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.obBlank.BackColor = System.Drawing.SystemColors.Control
		Me.obBlank.CausesValidation = True
		Me.obBlank.Enabled = True
		Me.obBlank.ForeColor = System.Drawing.SystemColors.ControlText
		Me.obBlank.Cursor = System.Windows.Forms.Cursors.Default
		Me.obBlank.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.obBlank.Appearance = System.Windows.Forms.Appearance.Normal
		Me.obBlank.TabStop = True
		Me.obBlank.Checked = False
		Me.obBlank.Visible = True
		Me.obBlank.Name = "obBlank"
		Me.obImprinted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.obImprinted.Text = "Imprinted Check"
		Me.obImprinted.Size = New System.Drawing.Size(121, 25)
		Me.obImprinted.Location = New System.Drawing.Point(8, 24)
		Me.obImprinted.TabIndex = 1
		Me.obImprinted.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.obImprinted.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.obImprinted.BackColor = System.Drawing.SystemColors.Control
		Me.obImprinted.CausesValidation = True
		Me.obImprinted.Enabled = True
		Me.obImprinted.ForeColor = System.Drawing.SystemColors.ControlText
		Me.obImprinted.Cursor = System.Windows.Forms.Cursors.Default
		Me.obImprinted.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.obImprinted.Appearance = System.Windows.Forms.Appearance.Normal
		Me.obImprinted.TabStop = True
		Me.obImprinted.Checked = False
		Me.obImprinted.Visible = True
		Me.obImprinted.Name = "obImprinted"
		Me.Controls.Add(cmdOk)
		Me.Controls.Add(Frame1)
		Me.Frame1.Controls.Add(obBlank)
		Me.Frame1.Controls.Add(obImprinted)
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class