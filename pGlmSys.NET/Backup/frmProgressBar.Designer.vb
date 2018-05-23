<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmProgressBar
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
	Public WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents lbProgress As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProgressBar))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.lbProgress = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Status"
		Me.ClientSize = New System.Drawing.Size(442, 213)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmProgressBar"
		Me.ProgressBar1.Size = New System.Drawing.Size(409, 33)
		Me.ProgressBar1.Location = New System.Drawing.Point(16, 64)
		Me.ProgressBar1.TabIndex = 1
		Me.ProgressBar1.Name = "ProgressBar1"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(57, 33)
		Me.cmdCancel.Location = New System.Drawing.Point(192, 144)
		Me.cmdCancel.TabIndex = 0
		Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.lbProgress.Text = "Progress"
		Me.lbProgress.Size = New System.Drawing.Size(353, 25)
		Me.lbProgress.Location = New System.Drawing.Point(40, 24)
		Me.lbProgress.TabIndex = 2
		Me.lbProgress.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lbProgress.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbProgress.BackColor = System.Drawing.SystemColors.Control
		Me.lbProgress.Enabled = True
		Me.lbProgress.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lbProgress.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbProgress.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbProgress.UseMnemonic = True
		Me.lbProgress.Visible = True
		Me.lbProgress.AutoSize = False
		Me.lbProgress.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbProgress.Name = "lbProgress"
		Me.Controls.Add(ProgressBar1)
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(lbProgress)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class