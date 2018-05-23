<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmReport
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
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents txtReport As System.Windows.Forms.TextBox
	Public WithEvents cbVersion As System.Windows.Forms.ComboBox
	Public WithEvents dtEnd As AxMSComCtl2.AxDTPicker
	Public WithEvents dtStart As AxMSComCtl2.AxDTPicker
	Public WithEvents cbState As System.Windows.Forms.ComboBox
	Public WithEvents cbReport As System.Windows.Forms.ComboBox
	Public WithEvents cbCustomer As System.Windows.Forms.ComboBox
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmReport))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Command1 = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdOk = New System.Windows.Forms.Button
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.txtReport = New System.Windows.Forms.TextBox
		Me.cbVersion = New System.Windows.Forms.ComboBox
		Me.dtEnd = New AxMSComCtl2.AxDTPicker
		Me.dtStart = New AxMSComCtl2.AxDTPicker
		Me.cbState = New System.Windows.Forms.ComboBox
		Me.cbReport = New System.Windows.Forms.ComboBox
		Me.cbCustomer = New System.Windows.Forms.ComboBox
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.dtEnd, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dtStart, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.SystemColors.Info
		Me.Text = "Report Criteria"
		Me.ClientSize = New System.Drawing.Size(316, 328)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
		Me.Name = "frmReport"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Command1"
		Me.Command1.Size = New System.Drawing.Size(49, 41)
		Me.Command1.Location = New System.Drawing.Point(240, 272)
		Me.Command1.TabIndex = 15
		Me.Command1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(49, 33)
		Me.cmdCancel.Location = New System.Drawing.Point(168, 272)
		Me.cmdCancel.TabIndex = 14
		Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOk.Text = "OK"
		Me.cmdOk.Size = New System.Drawing.Size(49, 33)
		Me.cmdOk.Location = New System.Drawing.Point(104, 272)
		Me.cmdOk.TabIndex = 13
		Me.cmdOk.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOk.CausesValidation = True
		Me.cmdOk.Enabled = True
		Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOk.TabStop = True
		Me.cmdOk.Name = "cmdOk"
		Me.Frame1.BackColor = System.Drawing.Color.White
		Me.Frame1.Text = "Criteria"
		Me.Frame1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Frame1.Size = New System.Drawing.Size(281, 233)
		Me.Frame1.Location = New System.Drawing.Point(16, 24)
		Me.Frame1.TabIndex = 0
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Name = "Frame1"
		Me.txtReport.AutoSize = False
		Me.txtReport.Size = New System.Drawing.Size(169, 21)
		Me.txtReport.Location = New System.Drawing.Point(80, 16)
		Me.txtReport.ReadOnly = True
		Me.txtReport.TabIndex = 4
		Me.txtReport.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtReport.AcceptsReturn = True
		Me.txtReport.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtReport.BackColor = System.Drawing.SystemColors.Window
		Me.txtReport.CausesValidation = True
		Me.txtReport.Enabled = True
		Me.txtReport.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtReport.HideSelection = True
		Me.txtReport.Maxlength = 0
		Me.txtReport.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtReport.MultiLine = False
		Me.txtReport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtReport.TabStop = True
		Me.txtReport.Visible = True
		Me.txtReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtReport.Name = "txtReport"
		Me.cbVersion.Size = New System.Drawing.Size(81, 21)
		Me.cbVersion.Location = New System.Drawing.Point(80, 104)
		Me.cbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbVersion.TabIndex = 8
		Me.cbVersion.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbVersion.BackColor = System.Drawing.SystemColors.Window
		Me.cbVersion.CausesValidation = True
		Me.cbVersion.Enabled = True
		Me.cbVersion.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbVersion.IntegralHeight = True
		Me.cbVersion.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbVersion.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbVersion.Sorted = False
		Me.cbVersion.TabStop = True
		Me.cbVersion.Visible = True
		Me.cbVersion.Name = "cbVersion"
		dtEnd.OcxState = CType(resources.GetObject("dtEnd.OcxState"), System.Windows.Forms.AxHost.State)
		Me.dtEnd.Size = New System.Drawing.Size(81, 21)
		Me.dtEnd.Location = New System.Drawing.Point(80, 168)
		Me.dtEnd.TabIndex = 11
		Me.dtEnd.Name = "dtEnd"
		dtStart.OcxState = CType(resources.GetObject("dtStart.OcxState"), System.Windows.Forms.AxHost.State)
		Me.dtStart.Size = New System.Drawing.Size(81, 21)
		Me.dtStart.Location = New System.Drawing.Point(80, 136)
		Me.dtStart.TabIndex = 10
		Me.dtStart.Name = "dtStart"
		Me.cbState.Size = New System.Drawing.Size(49, 21)
		Me.cbState.Location = New System.Drawing.Point(200, 72)
		Me.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbState.TabIndex = 7
		Me.cbState.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbState.BackColor = System.Drawing.SystemColors.Window
		Me.cbState.CausesValidation = True
		Me.cbState.Enabled = True
		Me.cbState.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbState.IntegralHeight = True
		Me.cbState.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbState.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbState.Sorted = False
		Me.cbState.TabStop = True
		Me.cbState.Visible = True
		Me.cbState.Name = "cbState"
		Me.cbReport.Size = New System.Drawing.Size(169, 21)
		Me.cbReport.Location = New System.Drawing.Point(80, 40)
		Me.cbReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbReport.TabIndex = 5
		Me.cbReport.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbReport.BackColor = System.Drawing.SystemColors.Window
		Me.cbReport.CausesValidation = True
		Me.cbReport.Enabled = True
		Me.cbReport.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbReport.IntegralHeight = True
		Me.cbReport.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbReport.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbReport.Sorted = False
		Me.cbReport.TabStop = True
		Me.cbReport.Visible = True
		Me.cbReport.Name = "cbReport"
		Me.cbCustomer.Size = New System.Drawing.Size(81, 21)
		Me.cbCustomer.Location = New System.Drawing.Point(80, 72)
		Me.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbCustomer.TabIndex = 6
		Me.cbCustomer.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbCustomer.BackColor = System.Drawing.SystemColors.Window
		Me.cbCustomer.CausesValidation = True
		Me.cbCustomer.Enabled = True
		Me.cbCustomer.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cbCustomer.IntegralHeight = True
		Me.cbCustomer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbCustomer.Sorted = False
		Me.cbCustomer.TabStop = True
		Me.cbCustomer.Visible = True
		Me.cbCustomer.Name = "cbCustomer"
		Me.Label5.Text = "Version"
		Me.Label5.Size = New System.Drawing.Size(41, 17)
		Me.Label5.Location = New System.Drawing.Point(24, 104)
		Me.Label5.TabIndex = 12
		Me.Label5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.Color.Transparent
		Me.Label5.Enabled = True
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.Text = "Dates"
		Me.Label4.Size = New System.Drawing.Size(41, 17)
		Me.Label4.Location = New System.Drawing.Point(24, 136)
		Me.Label4.TabIndex = 9
		Me.Label4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.Color.Transparent
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.Text = "State"
		Me.Label3.Size = New System.Drawing.Size(33, 17)
		Me.Label3.Location = New System.Drawing.Point(168, 72)
		Me.Label3.TabIndex = 3
		Me.Label3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "Report"
		Me.Label2.Size = New System.Drawing.Size(41, 17)
		Me.Label2.Location = New System.Drawing.Point(24, 40)
		Me.Label2.TabIndex = 2
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "Customer"
		Me.Label1.Size = New System.Drawing.Size(49, 17)
		Me.Label1.Location = New System.Drawing.Point(24, 72)
		Me.Label1.TabIndex = 1
		Me.Label1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(Command1)
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(cmdOk)
		Me.Controls.Add(Frame1)
		Me.Frame1.Controls.Add(txtReport)
		Me.Frame1.Controls.Add(cbVersion)
		Me.Frame1.Controls.Add(dtEnd)
		Me.Frame1.Controls.Add(dtStart)
		Me.Frame1.Controls.Add(cbState)
		Me.Frame1.Controls.Add(cbReport)
		Me.Frame1.Controls.Add(cbCustomer)
		Me.Frame1.Controls.Add(Label5)
		Me.Frame1.Controls.Add(Label4)
		Me.Frame1.Controls.Add(Label3)
		Me.Frame1.Controls.Add(Label2)
		Me.Frame1.Controls.Add(Label1)
		CType(Me.dtStart, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dtEnd, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class