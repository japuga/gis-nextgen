<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRepUniversal
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
	Public WithEvents cmdAllRightContent As System.Windows.Forms.Button
	Public WithEvents cmdRightContent As System.Windows.Forms.Button
	Public WithEvents cmdLeftContent As System.Windows.Forms.Button
	Public WithEvents cmdAllLeftContent As System.Windows.Forms.Button
    Public WithEvents _lbTitle_3 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents _frCriteria_3 As System.Windows.Forms.GroupBox
	Public WithEvents _obEquipment_2 As System.Windows.Forms.RadioButton
	Public WithEvents _obEquipment_1 As System.Windows.Forms.RadioButton
	Public WithEvents _obEquipment_0 As System.Windows.Forms.RadioButton
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents cmdAllLeftEquipment As System.Windows.Forms.Button
	Public WithEvents cmdLeftEquipment As System.Windows.Forms.Button
	Public WithEvents cmdRightEquipment As System.Windows.Forms.Button
	Public WithEvents cmdAllRightEquipment As System.Windows.Forms.Button
    Public WithEvents _lbTitle_2 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents _frCriteria_2 As System.Windows.Forms.GroupBox
	Public WithEvents cbInvoiceEqpt As System.Windows.Forms.CheckBox
	Public WithEvents cbWithoutEqpt As System.Windows.Forms.CheckBox
	Public WithEvents cbReportTemplate As System.Windows.Forms.ComboBox
	Public WithEvents txtReportTitle As System.Windows.Forms.TextBox
	Public WithEvents cbCustId As System.Windows.Forms.ComboBox
	Public WithEvents txtReportCaption As System.Windows.Forms.TextBox
	Public WithEvents cbCustName As System.Windows.Forms.ComboBox
	Public WithEvents cbGroupName As System.Windows.Forms.ComboBox
	Public WithEvents cbStateId As System.Windows.Forms.ComboBox
	Public WithEvents Label19 As System.Windows.Forms.Label
	Public WithEvents Label18 As System.Windows.Forms.Label
	Public WithEvents _lbTitle_0 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _frCriteria_0 As System.Windows.Forms.GroupBox
	Public WithEvents cmdFinish As System.Windows.Forms.Button
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents cmdPrev As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents _sb_Panel1 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents sb As System.Windows.Forms.StatusStrip
	Public WithEvents cbPeriodName As System.Windows.Forms.ComboBox
	Public WithEvents obSinglePeriod As System.Windows.Forms.RadioButton
	Public WithEvents obRangePeriod As System.Windows.Forms.RadioButton
	Public WithEvents cbPeriodStart As System.Windows.Forms.ComboBox
	Public WithEvents cbPeriodEnd As System.Windows.Forms.ComboBox
	Public WithEvents obRange As System.Windows.Forms.RadioButton
	Public WithEvents obPeriodNameSingle As System.Windows.Forms.RadioButton
	Public WithEvents obPeriodDateSingle As System.Windows.Forms.RadioButton
	Public WithEvents Frame3 As System.Windows.Forms.GroupBox
	Public WithEvents obPeriodDateRange As System.Windows.Forms.RadioButton
	Public WithEvents obPeriodNameRange As System.Windows.Forms.RadioButton
	Public WithEvents Frame4 As System.Windows.Forms.GroupBox
    Public WithEvents lbPeriodEndDate As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents lbPeriodStartDate As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents lbEndDate As System.Windows.Forms.Label
	Public WithEvents lbStartDate As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents _lbTitle_1 As System.Windows.Forms.Label
	Public WithEvents _frCriteria_1 As System.Windows.Forms.GroupBox
    Public WithEvents cmdAllLeftVendor As System.Windows.Forms.Button
	Public WithEvents cmdLeftVendor As System.Windows.Forms.Button
	Public WithEvents cmdRightVendor As System.Windows.Forms.Button
	Public WithEvents cmdAllRightVendor As System.Windows.Forms.Button
    Public WithEvents Label17 As System.Windows.Forms.Label
	Public WithEvents _lbTitle_6 As System.Windows.Forms.Label
	Public WithEvents _frCriteria_6 As System.Windows.Forms.GroupBox
	Public WithEvents cmdAllLeftServ As System.Windows.Forms.Button
	Public WithEvents cmdLeftServ As System.Windows.Forms.Button
	Public WithEvents cmdRightServ As System.Windows.Forms.Button
	Public WithEvents cmdAllRightServ As System.Windows.Forms.Button
    Public WithEvents Label16 As System.Windows.Forms.Label
	Public WithEvents _lbTitle_5 As System.Windows.Forms.Label
	Public WithEvents _frCriteria_5 As System.Windows.Forms.GroupBox
	Public WithEvents cmdAllLeftLoad As System.Windows.Forms.Button
	Public WithEvents cmdLeftLoad As System.Windows.Forms.Button
	Public WithEvents cmdRightLoad As System.Windows.Forms.Button
	Public WithEvents cmdAllRightLoad As System.Windows.Forms.Button
    Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents _lbTitle_4 As System.Windows.Forms.Label
	Public WithEvents _frCriteria_4 As System.Windows.Forms.GroupBox
	Public WithEvents frCriteria As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
	Public WithEvents lbTitle As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents obEquipment As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._frCriteria_3 = New System.Windows.Forms.GroupBox()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgSelContent = New System.Windows.Forms.DataGridView()
        Me.dgContent = New System.Windows.Forms.DataGridView()
        Me.cmdAllRightContent = New System.Windows.Forms.Button()
        Me.cmdRightContent = New System.Windows.Forms.Button()
        Me.cmdLeftContent = New System.Windows.Forms.Button()
        Me.cmdAllLeftContent = New System.Windows.Forms.Button()
        Me._lbTitle_3 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me._frCriteria_2 = New System.Windows.Forms.GroupBox()
        Me.dgSelEquipment = New System.Windows.Forms.DataGridView()
        Me.dgEquipment = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me._obEquipment_2 = New System.Windows.Forms.RadioButton()
        Me._obEquipment_1 = New System.Windows.Forms.RadioButton()
        Me._obEquipment_0 = New System.Windows.Forms.RadioButton()
        Me.cmdAllLeftEquipment = New System.Windows.Forms.Button()
        Me.cmdLeftEquipment = New System.Windows.Forms.Button()
        Me.cmdRightEquipment = New System.Windows.Forms.Button()
        Me.cmdAllRightEquipment = New System.Windows.Forms.Button()
        Me._lbTitle_2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me._frCriteria_0 = New System.Windows.Forms.GroupBox()
        Me.cbInvoiceEqpt = New System.Windows.Forms.CheckBox()
        Me.cbWithoutEqpt = New System.Windows.Forms.CheckBox()
        Me.cbReportTemplate = New System.Windows.Forms.ComboBox()
        Me.txtReportTitle = New System.Windows.Forms.TextBox()
        Me.cbCustId = New System.Windows.Forms.ComboBox()
        Me.txtReportCaption = New System.Windows.Forms.TextBox()
        Me.cbCustName = New System.Windows.Forms.ComboBox()
        Me.cbGroupName = New System.Windows.Forms.ComboBox()
        Me.cbStateId = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me._lbTitle_0 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdFinish = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdPrev = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.sb = New System.Windows.Forms.StatusStrip()
        Me._sb_Panel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._frCriteria_1 = New System.Windows.Forms.GroupBox()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.dtEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtStartDate = New System.Windows.Forms.DateTimePicker()
        Me.cbPeriodName = New System.Windows.Forms.ComboBox()
        Me.obSinglePeriod = New System.Windows.Forms.RadioButton()
        Me.obRangePeriod = New System.Windows.Forms.RadioButton()
        Me.cbPeriodStart = New System.Windows.Forms.ComboBox()
        Me.cbPeriodEnd = New System.Windows.Forms.ComboBox()
        Me.obRange = New System.Windows.Forms.RadioButton()
        Me.Frame3 = New System.Windows.Forms.GroupBox()
        Me.obPeriodNameSingle = New System.Windows.Forms.RadioButton()
        Me.obPeriodDateSingle = New System.Windows.Forms.RadioButton()
        Me.Frame4 = New System.Windows.Forms.GroupBox()
        Me.obPeriodDateRange = New System.Windows.Forms.RadioButton()
        Me.obPeriodNameRange = New System.Windows.Forms.RadioButton()
        Me.lbPeriodEndDate = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbPeriodStartDate = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbEndDate = New System.Windows.Forms.Label()
        Me.lbStartDate = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me._lbTitle_1 = New System.Windows.Forms.Label()
        Me._frCriteria_6 = New System.Windows.Forms.GroupBox()
        Me.DataGridView10 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView9 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgSelVendor = New System.Windows.Forms.DataGridView()
        Me.dgVendor = New System.Windows.Forms.DataGridView()
        Me.cmdAllLeftVendor = New System.Windows.Forms.Button()
        Me.cmdLeftVendor = New System.Windows.Forms.Button()
        Me.cmdRightVendor = New System.Windows.Forms.Button()
        Me.cmdAllRightVendor = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me._lbTitle_6 = New System.Windows.Forms.Label()
        Me._frCriteria_5 = New System.Windows.Forms.GroupBox()
        Me.DataGridView8 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView7 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgSelService = New System.Windows.Forms.DataGridView()
        Me.dgService = New System.Windows.Forms.DataGridView()
        Me.cmdAllLeftServ = New System.Windows.Forms.Button()
        Me.cmdLeftServ = New System.Windows.Forms.Button()
        Me.cmdRightServ = New System.Windows.Forms.Button()
        Me.cmdAllRightServ = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me._lbTitle_5 = New System.Windows.Forms.Label()
        Me._frCriteria_4 = New System.Windows.Forms.GroupBox()
        Me.DataGridView6 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView5 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgSelLoad = New System.Windows.Forms.DataGridView()
        Me.dgLoad = New System.Windows.Forms.DataGridView()
        Me.cmdAllLeftLoad = New System.Windows.Forms.Button()
        Me.cmdLeftLoad = New System.Windows.Forms.Button()
        Me.cmdRightLoad = New System.Windows.Forms.Button()
        Me.cmdAllRightLoad = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me._lbTitle_4 = New System.Windows.Forms.Label()
        Me.frCriteria = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(Me.components)
        Me.lbTitle = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.obEquipment = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(Me.components)
        Me.dgDebug = New System.Windows.Forms.DataGridView()
        Me._frCriteria_3.SuspendLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSelContent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgContent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._frCriteria_2.SuspendLayout()
        CType(Me.dgSelEquipment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgEquipment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame2.SuspendLayout()
        Me._frCriteria_0.SuspendLayout()
        Me.sb.SuspendLayout()
        Me._frCriteria_1.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Frame3.SuspendLayout()
        Me.Frame4.SuspendLayout()
        Me._frCriteria_6.SuspendLayout()
        CType(Me.DataGridView10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSelVendor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgVendor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._frCriteria_5.SuspendLayout()
        CType(Me.DataGridView8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSelService, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgService, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._frCriteria_4.SuspendLayout()
        CType(Me.DataGridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSelLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.frCriteria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obEquipment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDebug, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_frCriteria_3
        '
        Me._frCriteria_3.BackColor = System.Drawing.SystemColors.Control
        Me._frCriteria_3.Controls.Add(Me.DataGridView3)
        Me._frCriteria_3.Controls.Add(Me.DataGridView4)
        Me._frCriteria_3.Controls.Add(Me.dgSelContent)
        Me._frCriteria_3.Controls.Add(Me.dgContent)
        Me._frCriteria_3.Controls.Add(Me.cmdAllRightContent)
        Me._frCriteria_3.Controls.Add(Me.cmdRightContent)
        Me._frCriteria_3.Controls.Add(Me.cmdLeftContent)
        Me._frCriteria_3.Controls.Add(Me.cmdAllLeftContent)
        Me._frCriteria_3.Controls.Add(Me._lbTitle_3)
        Me._frCriteria_3.Controls.Add(Me.Label14)
        Me._frCriteria_3.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frCriteria_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frCriteria.SetIndex(Me._frCriteria_3, CType(3, Short))
        Me._frCriteria_3.Location = New System.Drawing.Point(470, 520)
        Me._frCriteria_3.Name = "_frCriteria_3"
        Me._frCriteria_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frCriteria_3.Size = New System.Drawing.Size(465, 505)
        Me._frCriteria_3.TabIndex = 17
        Me._frCriteria_3.TabStop = False
        Me._frCriteria_3.Text = "Content"
        '
        'DataGridView3
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView3.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView3.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView3.Enabled = False
        Me.DataGridView3.Location = New System.Drawing.Point(13, 102)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.RowHeadersVisible = False
        Me.DataGridView3.Size = New System.Drawing.Size(169, 19)
        Me.DataGridView3.TabIndex = 40
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Contents"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridView4
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView4.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView4.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView4.Enabled = False
        Me.DataGridView4.Location = New System.Drawing.Point(280, 99)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.RowHeadersVisible = False
        Me.DataGridView4.Size = New System.Drawing.Size(169, 22)
        Me.DataGridView4.TabIndex = 39
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn3.HeaderText = "Selected Contents"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'dgSelContent
        '
        Me.dgSelContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSelContent.Location = New System.Drawing.Point(280, 120)
        Me.dgSelContent.Name = "dgSelContent"
        Me.dgSelContent.Size = New System.Drawing.Size(169, 199)
        Me.dgSelContent.TabIndex = 34
        '
        'dgContent
        '
        Me.dgContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgContent.Location = New System.Drawing.Point(13, 120)
        Me.dgContent.Name = "dgContent"
        Me.dgContent.Size = New System.Drawing.Size(169, 201)
        Me.dgContent.TabIndex = 33
        '
        'cmdAllRightContent
        '
        Me.cmdAllRightContent.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAllRightContent.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAllRightContent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAllRightContent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAllRightContent.Location = New System.Drawing.Point(208, 120)
        Me.cmdAllRightContent.Name = "cmdAllRightContent"
        Me.cmdAllRightContent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAllRightContent.Size = New System.Drawing.Size(49, 33)
        Me.cmdAllRightContent.TabIndex = 29
        Me.cmdAllRightContent.Text = ">>"
        Me.cmdAllRightContent.UseVisualStyleBackColor = False
        '
        'cmdRightContent
        '
        Me.cmdRightContent.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRightContent.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRightContent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRightContent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRightContent.Location = New System.Drawing.Point(208, 176)
        Me.cmdRightContent.Name = "cmdRightContent"
        Me.cmdRightContent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRightContent.Size = New System.Drawing.Size(49, 33)
        Me.cmdRightContent.TabIndex = 28
        Me.cmdRightContent.Text = ">"
        Me.cmdRightContent.UseVisualStyleBackColor = False
        '
        'cmdLeftContent
        '
        Me.cmdLeftContent.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLeftContent.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLeftContent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLeftContent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLeftContent.Location = New System.Drawing.Point(208, 232)
        Me.cmdLeftContent.Name = "cmdLeftContent"
        Me.cmdLeftContent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLeftContent.Size = New System.Drawing.Size(49, 33)
        Me.cmdLeftContent.TabIndex = 27
        Me.cmdLeftContent.Text = "<"
        Me.cmdLeftContent.UseVisualStyleBackColor = False
        '
        'cmdAllLeftContent
        '
        Me.cmdAllLeftContent.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAllLeftContent.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAllLeftContent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAllLeftContent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAllLeftContent.Location = New System.Drawing.Point(208, 288)
        Me.cmdAllLeftContent.Name = "cmdAllLeftContent"
        Me.cmdAllLeftContent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAllLeftContent.Size = New System.Drawing.Size(49, 33)
        Me.cmdAllLeftContent.TabIndex = 26
        Me.cmdAllLeftContent.Text = "<<"
        Me.cmdAllLeftContent.UseVisualStyleBackColor = False
        '
        '_lbTitle_3
        '
        Me._lbTitle_3.BackColor = System.Drawing.Color.Yellow
        Me._lbTitle_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbTitle_3.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbTitle_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbTitle.SetIndex(Me._lbTitle_3, CType(3, Short))
        Me._lbTitle_3.Location = New System.Drawing.Point(24, 16)
        Me._lbTitle_3.Name = "_lbTitle_3"
        Me._lbTitle_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbTitle_3.Size = New System.Drawing.Size(201, 17)
        Me._lbTitle_3.TabIndex = 32
        Me._lbTitle_3.Text = " Step 4.  Contents>>"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(32, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(209, 17)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Select Equipment Contents"
        '
        '_frCriteria_2
        '
        Me._frCriteria_2.BackColor = System.Drawing.SystemColors.Control
        Me._frCriteria_2.Controls.Add(Me.dgSelEquipment)
        Me._frCriteria_2.Controls.Add(Me.dgEquipment)
        Me._frCriteria_2.Controls.Add(Me.DataGridView2)
        Me._frCriteria_2.Controls.Add(Me.DataGridView1)
        Me._frCriteria_2.Controls.Add(Me.Frame2)
        Me._frCriteria_2.Controls.Add(Me.cmdAllLeftEquipment)
        Me._frCriteria_2.Controls.Add(Me.cmdLeftEquipment)
        Me._frCriteria_2.Controls.Add(Me.cmdRightEquipment)
        Me._frCriteria_2.Controls.Add(Me.cmdAllRightEquipment)
        Me._frCriteria_2.Controls.Add(Me._lbTitle_2)
        Me._frCriteria_2.Controls.Add(Me.Label12)
        Me._frCriteria_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frCriteria_2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.frCriteria.SetIndex(Me._frCriteria_2, CType(2, Short))
        Me._frCriteria_2.Location = New System.Drawing.Point(470, 12)
        Me._frCriteria_2.Name = "_frCriteria_2"
        Me._frCriteria_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frCriteria_2.Size = New System.Drawing.Size(449, 481)
        Me._frCriteria_2.TabIndex = 13
        Me._frCriteria_2.TabStop = False
        Me._frCriteria_2.Text = "Equipment"
        '
        'dgSelEquipment
        '
        Me.dgSelEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSelEquipment.Location = New System.Drawing.Point(274, 193)
        Me.dgSelEquipment.Name = "dgSelEquipment"
        Me.dgSelEquipment.Size = New System.Drawing.Size(169, 269)
        Me.dgSelEquipment.TabIndex = 36
        '
        'dgEquipment
        '
        Me.dgEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgEquipment.Location = New System.Drawing.Point(11, 193)
        Me.dgEquipment.Name = "dgEquipment"
        Me.dgEquipment.Size = New System.Drawing.Size(171, 264)
        Me.dgEquipment.TabIndex = 35
        Me.dgEquipment.Tag = ""
        '
        'DataGridView2
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView2.Enabled = False
        Me.DataGridView2.Location = New System.Drawing.Point(274, 175)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(169, 19)
        Me.DataGridView2.TabIndex = 38
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn1.HeaderText = "Selected Equipment"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridView1
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridView1.Enabled = False
        Me.DataGridView1.Location = New System.Drawing.Point(11, 175)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(171, 19)
        Me.DataGridView1.TabIndex = 37
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Equipment Types"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me._obEquipment_2)
        Me.Frame2.Controls.Add(Me._obEquipment_1)
        Me.Frame2.Controls.Add(Me._obEquipment_0)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(24, 56)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(385, 105)
        Me.Frame2.TabIndex = 34
        Me.Frame2.TabStop = False
        '
        '_obEquipment_2
        '
        Me._obEquipment_2.BackColor = System.Drawing.SystemColors.Control
        Me._obEquipment_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._obEquipment_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._obEquipment_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obEquipment.SetIndex(Me._obEquipment_2, CType(2, Short))
        Me._obEquipment_2.Location = New System.Drawing.Point(16, 72)
        Me._obEquipment_2.Name = "_obEquipment_2"
        Me._obEquipment_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._obEquipment_2.Size = New System.Drawing.Size(97, 17)
        Me._obEquipment_2.TabIndex = 37
        Me._obEquipment_2.TabStop = True
        Me._obEquipment_2.Text = "All"
        Me._obEquipment_2.UseVisualStyleBackColor = False
        '
        '_obEquipment_1
        '
        Me._obEquipment_1.BackColor = System.Drawing.SystemColors.Control
        Me._obEquipment_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._obEquipment_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._obEquipment_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obEquipment.SetIndex(Me._obEquipment_1, CType(1, Short))
        Me._obEquipment_1.Location = New System.Drawing.Point(16, 48)
        Me._obEquipment_1.Name = "_obEquipment_1"
        Me._obEquipment_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._obEquipment_1.Size = New System.Drawing.Size(113, 17)
        Me._obEquipment_1.TabIndex = 36
        Me._obEquipment_1.TabStop = True
        Me._obEquipment_1.Text = "Temporary"
        Me._obEquipment_1.UseVisualStyleBackColor = False
        '
        '_obEquipment_0
        '
        Me._obEquipment_0.BackColor = System.Drawing.SystemColors.Control
        Me._obEquipment_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._obEquipment_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._obEquipment_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obEquipment.SetIndex(Me._obEquipment_0, CType(0, Short))
        Me._obEquipment_0.Location = New System.Drawing.Point(16, 24)
        Me._obEquipment_0.Name = "_obEquipment_0"
        Me._obEquipment_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._obEquipment_0.Size = New System.Drawing.Size(97, 17)
        Me._obEquipment_0.TabIndex = 35
        Me._obEquipment_0.TabStop = True
        Me._obEquipment_0.Text = "Permanent"
        Me._obEquipment_0.UseVisualStyleBackColor = False
        '
        'cmdAllLeftEquipment
        '
        Me.cmdAllLeftEquipment.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAllLeftEquipment.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAllLeftEquipment.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAllLeftEquipment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAllLeftEquipment.Location = New System.Drawing.Point(208, 376)
        Me.cmdAllLeftEquipment.Name = "cmdAllLeftEquipment"
        Me.cmdAllLeftEquipment.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAllLeftEquipment.Size = New System.Drawing.Size(41, 33)
        Me.cmdAllLeftEquipment.TabIndex = 24
        Me.cmdAllLeftEquipment.Text = "<<"
        Me.cmdAllLeftEquipment.UseVisualStyleBackColor = False
        '
        'cmdLeftEquipment
        '
        Me.cmdLeftEquipment.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLeftEquipment.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLeftEquipment.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLeftEquipment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLeftEquipment.Location = New System.Drawing.Point(208, 320)
        Me.cmdLeftEquipment.Name = "cmdLeftEquipment"
        Me.cmdLeftEquipment.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLeftEquipment.Size = New System.Drawing.Size(41, 33)
        Me.cmdLeftEquipment.TabIndex = 23
        Me.cmdLeftEquipment.Text = "<"
        Me.cmdLeftEquipment.UseVisualStyleBackColor = False
        '
        'cmdRightEquipment
        '
        Me.cmdRightEquipment.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRightEquipment.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRightEquipment.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRightEquipment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRightEquipment.Location = New System.Drawing.Point(208, 264)
        Me.cmdRightEquipment.Name = "cmdRightEquipment"
        Me.cmdRightEquipment.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRightEquipment.Size = New System.Drawing.Size(41, 33)
        Me.cmdRightEquipment.TabIndex = 22
        Me.cmdRightEquipment.Text = ">"
        Me.cmdRightEquipment.UseVisualStyleBackColor = False
        '
        'cmdAllRightEquipment
        '
        Me.cmdAllRightEquipment.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAllRightEquipment.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAllRightEquipment.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAllRightEquipment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAllRightEquipment.Location = New System.Drawing.Point(208, 216)
        Me.cmdAllRightEquipment.Name = "cmdAllRightEquipment"
        Me.cmdAllRightEquipment.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAllRightEquipment.Size = New System.Drawing.Size(41, 33)
        Me.cmdAllRightEquipment.TabIndex = 21
        Me.cmdAllRightEquipment.Text = ">>"
        Me.cmdAllRightEquipment.UseVisualStyleBackColor = False
        '
        '_lbTitle_2
        '
        Me._lbTitle_2.BackColor = System.Drawing.Color.Yellow
        Me._lbTitle_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbTitle_2.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbTitle_2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTitle.SetIndex(Me._lbTitle_2, CType(2, Short))
        Me._lbTitle_2.Location = New System.Drawing.Point(8, 16)
        Me._lbTitle_2.Name = "_lbTitle_2"
        Me._lbTitle_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbTitle_2.Size = New System.Drawing.Size(329, 17)
        Me._lbTitle_2.TabIndex = 31
        Me._lbTitle_2.Text = " Step 3. Equipment Types>>"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(24, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(145, 17)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Select Equipment Types"
        '
        '_frCriteria_0
        '
        Me._frCriteria_0.BackColor = System.Drawing.SystemColors.Control
        Me._frCriteria_0.Controls.Add(Me.cbInvoiceEqpt)
        Me._frCriteria_0.Controls.Add(Me.cbWithoutEqpt)
        Me._frCriteria_0.Controls.Add(Me.cbReportTemplate)
        Me._frCriteria_0.Controls.Add(Me.txtReportTitle)
        Me._frCriteria_0.Controls.Add(Me.cbCustId)
        Me._frCriteria_0.Controls.Add(Me.txtReportCaption)
        Me._frCriteria_0.Controls.Add(Me.cbCustName)
        Me._frCriteria_0.Controls.Add(Me.cbGroupName)
        Me._frCriteria_0.Controls.Add(Me.cbStateId)
        Me._frCriteria_0.Controls.Add(Me.Label19)
        Me._frCriteria_0.Controls.Add(Me.Label18)
        Me._frCriteria_0.Controls.Add(Me._lbTitle_0)
        Me._frCriteria_0.Controls.Add(Me.Label8)
        Me._frCriteria_0.Controls.Add(Me.label3)
        Me._frCriteria_0.Controls.Add(Me.Label2)
        Me._frCriteria_0.Controls.Add(Me.Label1)
        Me._frCriteria_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frCriteria_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frCriteria.SetIndex(Me._frCriteria_0, CType(0, Short))
        Me._frCriteria_0.Location = New System.Drawing.Point(0, 0)
        Me._frCriteria_0.Name = "_frCriteria_0"
        Me._frCriteria_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frCriteria_0.Size = New System.Drawing.Size(449, 497)
        Me._frCriteria_0.TabIndex = 3
        Me._frCriteria_0.TabStop = False
        Me._frCriteria_0.Text = "General"
        '
        'cbInvoiceEqpt
        '
        Me.cbInvoiceEqpt.BackColor = System.Drawing.SystemColors.Control
        Me.cbInvoiceEqpt.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbInvoiceEqpt.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbInvoiceEqpt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbInvoiceEqpt.Location = New System.Drawing.Point(48, 328)
        Me.cbInvoiceEqpt.Name = "cbInvoiceEqpt"
        Me.cbInvoiceEqpt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbInvoiceEqpt.Size = New System.Drawing.Size(257, 17)
        Me.cbInvoiceEqpt.TabIndex = 100
        Me.cbInvoiceEqpt.Text = "Just Invoices with Equipment"
        Me.cbInvoiceEqpt.UseVisualStyleBackColor = False
        '
        'cbWithoutEqpt
        '
        Me.cbWithoutEqpt.BackColor = System.Drawing.SystemColors.Control
        Me.cbWithoutEqpt.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbWithoutEqpt.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbWithoutEqpt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbWithoutEqpt.Location = New System.Drawing.Point(24, 304)
        Me.cbWithoutEqpt.Name = "cbWithoutEqpt"
        Me.cbWithoutEqpt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbWithoutEqpt.Size = New System.Drawing.Size(337, 17)
        Me.cbWithoutEqpt.TabIndex = 98
        Me.cbWithoutEqpt.Text = "Include service charges without contract"
        Me.cbWithoutEqpt.UseVisualStyleBackColor = False
        '
        'cbReportTemplate
        '
        Me.cbReportTemplate.BackColor = System.Drawing.SystemColors.Window
        Me.cbReportTemplate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbReportTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbReportTemplate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbReportTemplate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbReportTemplate.Location = New System.Drawing.Point(112, 181)
        Me.cbReportTemplate.Name = "cbReportTemplate"
        Me.cbReportTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbReportTemplate.Size = New System.Drawing.Size(145, 26)
        Me.cbReportTemplate.TabIndex = 68
        '
        'txtReportTitle
        '
        Me.txtReportTitle.AcceptsReturn = True
        Me.txtReportTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txtReportTitle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReportTitle.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReportTitle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReportTitle.Location = New System.Drawing.Point(112, 248)
        Me.txtReportTitle.MaxLength = 0
        Me.txtReportTitle.Name = "txtReportTitle"
        Me.txtReportTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReportTitle.Size = New System.Drawing.Size(249, 26)
        Me.txtReportTitle.TabIndex = 65
        '
        'cbCustId
        '
        Me.cbCustId.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustId.Location = New System.Drawing.Point(296, 80)
        Me.cbCustId.Name = "cbCustId"
        Me.cbCustId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustId.Size = New System.Drawing.Size(65, 26)
        Me.cbCustId.TabIndex = 12
        Me.cbCustId.Visible = False
        '
        'txtReportCaption
        '
        Me.txtReportCaption.AcceptsReturn = True
        Me.txtReportCaption.BackColor = System.Drawing.SystemColors.Window
        Me.txtReportCaption.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReportCaption.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReportCaption.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReportCaption.Location = New System.Drawing.Point(112, 212)
        Me.txtReportCaption.MaxLength = 0
        Me.txtReportCaption.Name = "txtReportCaption"
        Me.txtReportCaption.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReportCaption.Size = New System.Drawing.Size(249, 26)
        Me.txtReportCaption.TabIndex = 8
        '
        'cbCustName
        '
        Me.cbCustName.BackColor = System.Drawing.SystemColors.Window
        Me.cbCustName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbCustName.Location = New System.Drawing.Point(112, 80)
        Me.cbCustName.Name = "cbCustName"
        Me.cbCustName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbCustName.Size = New System.Drawing.Size(161, 26)
        Me.cbCustName.TabIndex = 7
        '
        'cbGroupName
        '
        Me.cbGroupName.BackColor = System.Drawing.SystemColors.Window
        Me.cbGroupName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGroupName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGroupName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbGroupName.Location = New System.Drawing.Point(112, 147)
        Me.cbGroupName.Name = "cbGroupName"
        Me.cbGroupName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbGroupName.Size = New System.Drawing.Size(137, 26)
        Me.cbGroupName.TabIndex = 6
        '
        'cbStateId
        '
        Me.cbStateId.BackColor = System.Drawing.SystemColors.Window
        Me.cbStateId.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbStateId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStateId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbStateId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbStateId.Location = New System.Drawing.Point(112, 114)
        Me.cbStateId.Name = "cbStateId"
        Me.cbStateId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbStateId.Size = New System.Drawing.Size(73, 26)
        Me.cbStateId.TabIndex = 5
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(16, 181)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(71, 20)
        Me.Label19.TabIndex = 67
        Me.Label19.Text = "Template"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(16, 245)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(79, 36)
        Me.Label18.TabIndex = 64
        Me.Label18.Text = "Report Title"
        '
        '_lbTitle_0
        '
        Me._lbTitle_0.BackColor = System.Drawing.Color.Yellow
        Me._lbTitle_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbTitle_0.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbTitle_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTitle.SetIndex(Me._lbTitle_0, CType(0, Short))
        Me._lbTitle_0.Location = New System.Drawing.Point(8, 24)
        Me._lbTitle_0.Name = "_lbTitle_0"
        Me._lbTitle_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbTitle_0.Size = New System.Drawing.Size(409, 17)
        Me._lbTitle_0.TabIndex = 30
        Me._lbTitle_0.Text = " Step 1. General >>"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 205)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(71, 36)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Customer Caption"
        '
        'label3
        '
        Me.label3.BackColor = System.Drawing.SystemColors.Control
        Me.label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label3.Location = New System.Drawing.Point(16, 149)
        Me.label3.Name = "label3"
        Me.label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label3.Size = New System.Drawing.Size(79, 20)
        Me.label3.TabIndex = 10
        Me.label3.Text = "Store Group"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(55, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "State"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(71, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Customer"
        '
        'cmdFinish
        '
        Me.cmdFinish.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFinish.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFinish.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFinish.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFinish.Location = New System.Drawing.Point(379, 534)
        Me.cmdFinish.Name = "cmdFinish"
        Me.cmdFinish.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFinish.Size = New System.Drawing.Size(73, 33)
        Me.cmdFinish.TabIndex = 2
        Me.cmdFinish.Text = "Finish"
        Me.cmdFinish.UseVisualStyleBackColor = False
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdNext.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNext.Location = New System.Drawing.Point(291, 534)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdNext.Size = New System.Drawing.Size(73, 33)
        Me.cmdNext.TabIndex = 1
        Me.cmdNext.Text = "Next >>"
        Me.cmdNext.UseVisualStyleBackColor = False
        '
        'cmdPrev
        '
        Me.cmdPrev.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPrev.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPrev.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrev.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPrev.Location = New System.Drawing.Point(203, 534)
        Me.cmdPrev.Name = "cmdPrev"
        Me.cmdPrev.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPrev.Size = New System.Drawing.Size(73, 33)
        Me.cmdPrev.TabIndex = 0
        Me.cmdPrev.Text = "<< Previous"
        Me.cmdPrev.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(115, 534)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(73, 33)
        Me.cmdClose.TabIndex = 54
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'sb
        '
        Me.sb.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sb.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.sb.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._sb_Panel1})
        Me.sb.Location = New System.Drawing.Point(0, 1029)
        Me.sb.Name = "sb"
        Me.sb.Size = New System.Drawing.Size(2063, 25)
        Me.sb.TabIndex = 99
        '
        '_sb_Panel1
        '
        Me._sb_Panel1.AutoSize = False
        Me._sb_Panel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._sb_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._sb_Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me._sb_Panel1.Name = "_sb_Panel1"
        Me._sb_Panel1.Size = New System.Drawing.Size(96, 25)
        Me._sb_Panel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_frCriteria_1
        '
        Me._frCriteria_1.BackColor = System.Drawing.SystemColors.Control
        Me._frCriteria_1.Controls.Add(Me.Frame1)
        Me._frCriteria_1.Controls.Add(Me._lbTitle_1)
        Me._frCriteria_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frCriteria_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frCriteria.SetIndex(Me._frCriteria_1, CType(1, Short))
        Me._frCriteria_1.Location = New System.Drawing.Point(19, 575)
        Me._frCriteria_1.Name = "_frCriteria_1"
        Me._frCriteria_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frCriteria_1.Size = New System.Drawing.Size(441, 497)
        Me._frCriteria_1.TabIndex = 69
        Me._frCriteria_1.TabStop = False
        Me._frCriteria_1.Text = "Period"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.dtEndDate)
        Me.Frame1.Controls.Add(Me.dtStartDate)
        Me.Frame1.Controls.Add(Me.cbPeriodName)
        Me.Frame1.Controls.Add(Me.obSinglePeriod)
        Me.Frame1.Controls.Add(Me.obRangePeriod)
        Me.Frame1.Controls.Add(Me.cbPeriodStart)
        Me.Frame1.Controls.Add(Me.cbPeriodEnd)
        Me.Frame1.Controls.Add(Me.obRange)
        Me.Frame1.Controls.Add(Me.Frame3)
        Me.Frame1.Controls.Add(Me.Frame4)
        Me.Frame1.Controls.Add(Me.lbPeriodEndDate)
        Me.Frame1.Controls.Add(Me.Label13)
        Me.Frame1.Controls.Add(Me.lbPeriodStartDate)
        Me.Frame1.Controls.Add(Me.Label11)
        Me.Frame1.Controls.Add(Me.lbEndDate)
        Me.Frame1.Controls.Add(Me.lbStartDate)
        Me.Frame1.Controls.Add(Me.Label7)
        Me.Frame1.Controls.Add(Me.Label6)
        Me.Frame1.Controls.Add(Me.Label9)
        Me.Frame1.Controls.Add(Me.Label10)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.Label5)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(16, 72)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(417, 350)
        Me.Frame1.TabIndex = 70
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Period/Date Range"
        '
        'dtEndDate
        '
        Me.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEndDate.Location = New System.Drawing.Point(187, 307)
        Me.dtEndDate.Name = "dtEndDate"
        Me.dtEndDate.Size = New System.Drawing.Size(106, 26)
        Me.dtEndDate.TabIndex = 98
        '
        'dtStartDate
        '
        Me.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStartDate.Location = New System.Drawing.Point(187, 282)
        Me.dtStartDate.Name = "dtStartDate"
        Me.dtStartDate.Size = New System.Drawing.Size(105, 26)
        Me.dtStartDate.TabIndex = 97
        '
        'cbPeriodName
        '
        Me.cbPeriodName.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriodName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbPeriodName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriodName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbPeriodName.Location = New System.Drawing.Point(128, 32)
        Me.cbPeriodName.Name = "cbPeriodName"
        Me.cbPeriodName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbPeriodName.Size = New System.Drawing.Size(177, 26)
        Me.cbPeriodName.TabIndex = 82
        '
        'obSinglePeriod
        '
        Me.obSinglePeriod.BackColor = System.Drawing.SystemColors.Control
        Me.obSinglePeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.obSinglePeriod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obSinglePeriod.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obSinglePeriod.Location = New System.Drawing.Point(16, 32)
        Me.obSinglePeriod.Name = "obSinglePeriod"
        Me.obSinglePeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obSinglePeriod.Size = New System.Drawing.Size(105, 17)
        Me.obSinglePeriod.TabIndex = 81
        Me.obSinglePeriod.TabStop = True
        Me.obSinglePeriod.Text = "Single Period"
        Me.obSinglePeriod.UseVisualStyleBackColor = False
        '
        'obRangePeriod
        '
        Me.obRangePeriod.BackColor = System.Drawing.SystemColors.Control
        Me.obRangePeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.obRangePeriod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obRangePeriod.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obRangePeriod.Location = New System.Drawing.Point(16, 128)
        Me.obRangePeriod.Name = "obRangePeriod"
        Me.obRangePeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obRangePeriod.Size = New System.Drawing.Size(289, 17)
        Me.obRangePeriod.TabIndex = 80
        Me.obRangePeriod.TabStop = True
        Me.obRangePeriod.Text = "Period Range - Accumulated"
        Me.obRangePeriod.UseVisualStyleBackColor = False
        '
        'cbPeriodStart
        '
        Me.cbPeriodStart.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriodStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbPeriodStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodStart.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriodStart.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbPeriodStart.Location = New System.Drawing.Point(88, 152)
        Me.cbPeriodStart.Name = "cbPeriodStart"
        Me.cbPeriodStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbPeriodStart.Size = New System.Drawing.Size(129, 26)
        Me.cbPeriodStart.TabIndex = 79
        '
        'cbPeriodEnd
        '
        Me.cbPeriodEnd.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriodEnd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbPeriodEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodEnd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriodEnd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbPeriodEnd.Location = New System.Drawing.Point(280, 152)
        Me.cbPeriodEnd.Name = "cbPeriodEnd"
        Me.cbPeriodEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbPeriodEnd.Size = New System.Drawing.Size(129, 26)
        Me.cbPeriodEnd.TabIndex = 78
        '
        'obRange
        '
        Me.obRange.BackColor = System.Drawing.SystemColors.Control
        Me.obRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.obRange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obRange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obRange.Location = New System.Drawing.Point(16, 264)
        Me.obRange.Name = "obRange"
        Me.obRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obRange.Size = New System.Drawing.Size(161, 17)
        Me.obRange.TabIndex = 77
        Me.obRange.TabStop = True
        Me.obRange.Text = "Invoices in Date Range"
        Me.obRange.UseVisualStyleBackColor = False
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.obPeriodNameSingle)
        Me.Frame3.Controls.Add(Me.obPeriodDateSingle)
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(48, 80)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(297, 41)
        Me.Frame3.TabIndex = 74
        Me.Frame3.TabStop = False
        '
        'obPeriodNameSingle
        '
        Me.obPeriodNameSingle.BackColor = System.Drawing.SystemColors.Control
        Me.obPeriodNameSingle.Cursor = System.Windows.Forms.Cursors.Default
        Me.obPeriodNameSingle.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obPeriodNameSingle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obPeriodNameSingle.Location = New System.Drawing.Point(8, 16)
        Me.obPeriodNameSingle.Name = "obPeriodNameSingle"
        Me.obPeriodNameSingle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obPeriodNameSingle.Size = New System.Drawing.Size(121, 13)
        Me.obPeriodNameSingle.TabIndex = 76
        Me.obPeriodNameSingle.TabStop = True
        Me.obPeriodNameSingle.Text = "Show Period Name"
        Me.obPeriodNameSingle.UseVisualStyleBackColor = False
        '
        'obPeriodDateSingle
        '
        Me.obPeriodDateSingle.BackColor = System.Drawing.SystemColors.Control
        Me.obPeriodDateSingle.Cursor = System.Windows.Forms.Cursors.Default
        Me.obPeriodDateSingle.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obPeriodDateSingle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obPeriodDateSingle.Location = New System.Drawing.Point(200, 16)
        Me.obPeriodDateSingle.Name = "obPeriodDateSingle"
        Me.obPeriodDateSingle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obPeriodDateSingle.Size = New System.Drawing.Size(89, 17)
        Me.obPeriodDateSingle.TabIndex = 75
        Me.obPeriodDateSingle.TabStop = True
        Me.obPeriodDateSingle.Text = "Show Dates"
        Me.obPeriodDateSingle.UseVisualStyleBackColor = False
        '
        'Frame4
        '
        Me.Frame4.BackColor = System.Drawing.SystemColors.Control
        Me.Frame4.Controls.Add(Me.obPeriodDateRange)
        Me.Frame4.Controls.Add(Me.obPeriodNameRange)
        Me.Frame4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame4.Location = New System.Drawing.Point(48, 208)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame4.Size = New System.Drawing.Size(297, 41)
        Me.Frame4.TabIndex = 71
        Me.Frame4.TabStop = False
        '
        'obPeriodDateRange
        '
        Me.obPeriodDateRange.BackColor = System.Drawing.SystemColors.Control
        Me.obPeriodDateRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.obPeriodDateRange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obPeriodDateRange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obPeriodDateRange.Location = New System.Drawing.Point(200, 16)
        Me.obPeriodDateRange.Name = "obPeriodDateRange"
        Me.obPeriodDateRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obPeriodDateRange.Size = New System.Drawing.Size(89, 17)
        Me.obPeriodDateRange.TabIndex = 73
        Me.obPeriodDateRange.TabStop = True
        Me.obPeriodDateRange.Text = "Show Dates"
        Me.obPeriodDateRange.UseVisualStyleBackColor = False
        '
        'obPeriodNameRange
        '
        Me.obPeriodNameRange.BackColor = System.Drawing.SystemColors.Control
        Me.obPeriodNameRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.obPeriodNameRange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obPeriodNameRange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obPeriodNameRange.Location = New System.Drawing.Point(8, 8)
        Me.obPeriodNameRange.Name = "obPeriodNameRange"
        Me.obPeriodNameRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.obPeriodNameRange.Size = New System.Drawing.Size(121, 25)
        Me.obPeriodNameRange.TabIndex = 72
        Me.obPeriodNameRange.TabStop = True
        Me.obPeriodNameRange.Text = "Show Period Name"
        Me.obPeriodNameRange.UseVisualStyleBackColor = False
        '
        'lbPeriodEndDate
        '
        Me.lbPeriodEndDate.BackColor = System.Drawing.SystemColors.Control
        Me.lbPeriodEndDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbPeriodEndDate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPeriodEndDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbPeriodEndDate.Location = New System.Drawing.Point(216, 192)
        Me.lbPeriodEndDate.Name = "lbPeriodEndDate"
        Me.lbPeriodEndDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbPeriodEndDate.Size = New System.Drawing.Size(81, 17)
        Me.lbPeriodEndDate.TabIndex = 96
        Me.lbPeriodEndDate.Text = "End"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(184, 192)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(25, 17)
        Me.Label13.TabIndex = 95
        Me.Label13.Text = "To"
        '
        'lbPeriodStartDate
        '
        Me.lbPeriodStartDate.BackColor = System.Drawing.SystemColors.Control
        Me.lbPeriodStartDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbPeriodStartDate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPeriodStartDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbPeriodStartDate.Location = New System.Drawing.Point(96, 192)
        Me.lbPeriodStartDate.Name = "lbPeriodStartDate"
        Me.lbPeriodStartDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbPeriodStartDate.Size = New System.Drawing.Size(73, 17)
        Me.lbPeriodStartDate.TabIndex = 94
        Me.lbPeriodStartDate.Text = "Start"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(48, 192)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(33, 17)
        Me.Label11.TabIndex = 93
        Me.Label11.Text = "From"
        '
        'lbEndDate
        '
        Me.lbEndDate.BackColor = System.Drawing.SystemColors.Control
        Me.lbEndDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbEndDate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEndDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbEndDate.Location = New System.Drawing.Point(216, 64)
        Me.lbEndDate.Name = "lbEndDate"
        Me.lbEndDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbEndDate.Size = New System.Drawing.Size(113, 17)
        Me.lbEndDate.TabIndex = 92
        Me.lbEndDate.Text = "End"
        '
        'lbStartDate
        '
        Me.lbStartDate.BackColor = System.Drawing.SystemColors.Control
        Me.lbStartDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbStartDate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStartDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbStartDate.Location = New System.Drawing.Point(88, 64)
        Me.lbStartDate.Name = "lbStartDate"
        Me.lbStartDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbStartDate.Size = New System.Drawing.Size(89, 17)
        Me.lbStartDate.TabIndex = 91
        Me.lbStartDate.Text = "Start"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(184, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(25, 17)
        Me.Label7.TabIndex = 90
        Me.Label7.Text = "To"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(48, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(33, 17)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "From"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(48, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(41, 25)
        Me.Label9.TabIndex = 88
        Me.Label9.Text = "From Period"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(240, 152)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(33, 25)
        Me.Label10.TabIndex = 87
        Me.Label10.Text = "To Period"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(48, 288)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(82, 21)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "Start Date"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(48, 312)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(82, 21)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "End Date"
        '
        '_lbTitle_1
        '
        Me._lbTitle_1.BackColor = System.Drawing.Color.Yellow
        Me._lbTitle_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbTitle_1.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbTitle_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTitle.SetIndex(Me._lbTitle_1, CType(1, Short))
        Me._lbTitle_1.Location = New System.Drawing.Point(8, 24)
        Me._lbTitle_1.Name = "_lbTitle_1"
        Me._lbTitle_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbTitle_1.Size = New System.Drawing.Size(409, 17)
        Me._lbTitle_1.TabIndex = 97
        Me._lbTitle_1.Text = " Step 2. Periods and Dates>>"
        '
        '_frCriteria_6
        '
        Me._frCriteria_6.BackColor = System.Drawing.SystemColors.Control
        Me._frCriteria_6.Controls.Add(Me.DataGridView10)
        Me._frCriteria_6.Controls.Add(Me.DataGridView9)
        Me._frCriteria_6.Controls.Add(Me.dgSelVendor)
        Me._frCriteria_6.Controls.Add(Me.dgVendor)
        Me._frCriteria_6.Controls.Add(Me.cmdAllLeftVendor)
        Me._frCriteria_6.Controls.Add(Me.cmdLeftVendor)
        Me._frCriteria_6.Controls.Add(Me.cmdRightVendor)
        Me._frCriteria_6.Controls.Add(Me.cmdAllRightVendor)
        Me._frCriteria_6.Controls.Add(Me.Label17)
        Me._frCriteria_6.Controls.Add(Me._lbTitle_6)
        Me._frCriteria_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frCriteria_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frCriteria.SetIndex(Me._frCriteria_6, CType(6, Short))
        Me._frCriteria_6.Location = New System.Drawing.Point(1494, 80)
        Me._frCriteria_6.Name = "_frCriteria_6"
        Me._frCriteria_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frCriteria_6.Size = New System.Drawing.Size(465, 457)
        Me._frCriteria_6.TabIndex = 55
        Me._frCriteria_6.TabStop = False
        Me._frCriteria_6.Text = "Vendor"
        '
        'DataGridView10
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView10.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridView10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView10.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn9})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView10.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridView10.Enabled = False
        Me.DataGridView10.Location = New System.Drawing.Point(279, 102)
        Me.DataGridView10.Name = "DataGridView10"
        Me.DataGridView10.RowHeadersVisible = False
        Me.DataGridView10.Size = New System.Drawing.Size(169, 19)
        Me.DataGridView10.TabIndex = 70
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn9.HeaderText = "Selected Vendors"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridView9
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView9.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridView9.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView9.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn8})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView9.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridView9.Enabled = False
        Me.DataGridView9.Location = New System.Drawing.Point(24, 102)
        Me.DataGridView9.Name = "DataGridView9"
        Me.DataGridView9.RowHeadersVisible = False
        Me.DataGridView9.Size = New System.Drawing.Size(169, 19)
        Me.DataGridView9.TabIndex = 69
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn8.HeaderText = "Vendors"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'dgSelVendor
        '
        Me.dgSelVendor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSelVendor.Location = New System.Drawing.Point(279, 120)
        Me.dgSelVendor.Name = "dgSelVendor"
        Me.dgSelVendor.Size = New System.Drawing.Size(169, 201)
        Me.dgSelVendor.TabIndex = 68
        '
        'dgVendor
        '
        Me.dgVendor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgVendor.Location = New System.Drawing.Point(24, 120)
        Me.dgVendor.Name = "dgVendor"
        Me.dgVendor.Size = New System.Drawing.Size(169, 201)
        Me.dgVendor.TabIndex = 67
        '
        'cmdAllLeftVendor
        '
        Me.cmdAllLeftVendor.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAllLeftVendor.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAllLeftVendor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAllLeftVendor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAllLeftVendor.Location = New System.Drawing.Point(208, 288)
        Me.cmdAllLeftVendor.Name = "cmdAllLeftVendor"
        Me.cmdAllLeftVendor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAllLeftVendor.Size = New System.Drawing.Size(49, 33)
        Me.cmdAllLeftVendor.TabIndex = 63
        Me.cmdAllLeftVendor.Text = "<<"
        Me.cmdAllLeftVendor.UseVisualStyleBackColor = False
        '
        'cmdLeftVendor
        '
        Me.cmdLeftVendor.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLeftVendor.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLeftVendor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLeftVendor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLeftVendor.Location = New System.Drawing.Point(208, 232)
        Me.cmdLeftVendor.Name = "cmdLeftVendor"
        Me.cmdLeftVendor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLeftVendor.Size = New System.Drawing.Size(49, 33)
        Me.cmdLeftVendor.TabIndex = 62
        Me.cmdLeftVendor.Text = "<"
        Me.cmdLeftVendor.UseVisualStyleBackColor = False
        '
        'cmdRightVendor
        '
        Me.cmdRightVendor.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRightVendor.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRightVendor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRightVendor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRightVendor.Location = New System.Drawing.Point(208, 176)
        Me.cmdRightVendor.Name = "cmdRightVendor"
        Me.cmdRightVendor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRightVendor.Size = New System.Drawing.Size(49, 33)
        Me.cmdRightVendor.TabIndex = 61
        Me.cmdRightVendor.Text = ">"
        Me.cmdRightVendor.UseVisualStyleBackColor = False
        '
        'cmdAllRightVendor
        '
        Me.cmdAllRightVendor.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAllRightVendor.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAllRightVendor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAllRightVendor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAllRightVendor.Location = New System.Drawing.Point(208, 120)
        Me.cmdAllRightVendor.Name = "cmdAllRightVendor"
        Me.cmdAllRightVendor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAllRightVendor.Size = New System.Drawing.Size(49, 33)
        Me.cmdAllRightVendor.TabIndex = 60
        Me.cmdAllRightVendor.Text = ">>"
        Me.cmdAllRightVendor.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(32, 72)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(137, 25)
        Me.Label17.TabIndex = 57
        Me.Label17.Text = "Select Vendors"
        '
        '_lbTitle_6
        '
        Me._lbTitle_6.BackColor = System.Drawing.Color.Yellow
        Me._lbTitle_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbTitle_6.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbTitle_6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTitle.SetIndex(Me._lbTitle_6, CType(6, Short))
        Me._lbTitle_6.Location = New System.Drawing.Point(16, 24)
        Me._lbTitle_6.Name = "_lbTitle_6"
        Me._lbTitle_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbTitle_6.Size = New System.Drawing.Size(417, 25)
        Me._lbTitle_6.TabIndex = 56
        Me._lbTitle_6.Text = "Step 7. Vendors"
        '
        '_frCriteria_5
        '
        Me._frCriteria_5.BackColor = System.Drawing.SystemColors.Control
        Me._frCriteria_5.Controls.Add(Me.DataGridView8)
        Me._frCriteria_5.Controls.Add(Me.DataGridView7)
        Me._frCriteria_5.Controls.Add(Me.dgSelService)
        Me._frCriteria_5.Controls.Add(Me.dgService)
        Me._frCriteria_5.Controls.Add(Me.cmdAllLeftServ)
        Me._frCriteria_5.Controls.Add(Me.cmdLeftServ)
        Me._frCriteria_5.Controls.Add(Me.cmdRightServ)
        Me._frCriteria_5.Controls.Add(Me.cmdAllRightServ)
        Me._frCriteria_5.Controls.Add(Me.Label16)
        Me._frCriteria_5.Controls.Add(Me._lbTitle_5)
        Me._frCriteria_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frCriteria_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frCriteria.SetIndex(Me._frCriteria_5, CType(5, Short))
        Me._frCriteria_5.Location = New System.Drawing.Point(1023, 494)
        Me._frCriteria_5.Name = "_frCriteria_5"
        Me._frCriteria_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frCriteria_5.Size = New System.Drawing.Size(465, 489)
        Me._frCriteria_5.TabIndex = 45
        Me._frCriteria_5.TabStop = False
        Me._frCriteria_5.Text = "Service"
        '
        'DataGridView8
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView8.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridView8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView8.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView8.DefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridView8.Enabled = False
        Me.DataGridView8.Location = New System.Drawing.Point(272, 105)
        Me.DataGridView8.Name = "DataGridView8"
        Me.DataGridView8.RowHeadersVisible = False
        Me.DataGridView8.Size = New System.Drawing.Size(177, 19)
        Me.DataGridView8.TabIndex = 57
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn7.HeaderText = "Selected Services"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridView7
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView7.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.DataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView7.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn6})
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView7.DefaultCellStyle = DataGridViewCellStyle18
        Me.DataGridView7.Enabled = False
        Me.DataGridView7.Location = New System.Drawing.Point(11, 103)
        Me.DataGridView7.Name = "DataGridView7"
        Me.DataGridView7.RowHeadersVisible = False
        Me.DataGridView7.Size = New System.Drawing.Size(177, 19)
        Me.DataGridView7.TabIndex = 56
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.HeaderText = "Services"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'dgSelService
        '
        Me.dgSelService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSelService.Location = New System.Drawing.Point(272, 120)
        Me.dgSelService.Name = "dgSelService"
        Me.dgSelService.Size = New System.Drawing.Size(177, 265)
        Me.dgSelService.TabIndex = 55
        '
        'dgService
        '
        Me.dgService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgService.Location = New System.Drawing.Point(11, 120)
        Me.dgService.Name = "dgService"
        Me.dgService.Size = New System.Drawing.Size(177, 265)
        Me.dgService.TabIndex = 54
        '
        'cmdAllLeftServ
        '
        Me.cmdAllLeftServ.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAllLeftServ.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAllLeftServ.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAllLeftServ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAllLeftServ.Location = New System.Drawing.Point(208, 320)
        Me.cmdAllLeftServ.Name = "cmdAllLeftServ"
        Me.cmdAllLeftServ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAllLeftServ.Size = New System.Drawing.Size(41, 33)
        Me.cmdAllLeftServ.TabIndex = 53
        Me.cmdAllLeftServ.Text = "<<"
        Me.cmdAllLeftServ.UseVisualStyleBackColor = False
        '
        'cmdLeftServ
        '
        Me.cmdLeftServ.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLeftServ.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLeftServ.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLeftServ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLeftServ.Location = New System.Drawing.Point(208, 264)
        Me.cmdLeftServ.Name = "cmdLeftServ"
        Me.cmdLeftServ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLeftServ.Size = New System.Drawing.Size(41, 33)
        Me.cmdLeftServ.TabIndex = 52
        Me.cmdLeftServ.Text = "<"
        Me.cmdLeftServ.UseVisualStyleBackColor = False
        '
        'cmdRightServ
        '
        Me.cmdRightServ.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRightServ.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRightServ.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRightServ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRightServ.Location = New System.Drawing.Point(208, 208)
        Me.cmdRightServ.Name = "cmdRightServ"
        Me.cmdRightServ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRightServ.Size = New System.Drawing.Size(41, 33)
        Me.cmdRightServ.TabIndex = 51
        Me.cmdRightServ.Text = ">"
        Me.cmdRightServ.UseVisualStyleBackColor = False
        '
        'cmdAllRightServ
        '
        Me.cmdAllRightServ.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAllRightServ.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAllRightServ.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAllRightServ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAllRightServ.Location = New System.Drawing.Point(208, 160)
        Me.cmdAllRightServ.Name = "cmdAllRightServ"
        Me.cmdAllRightServ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAllRightServ.Size = New System.Drawing.Size(41, 33)
        Me.cmdAllRightServ.TabIndex = 50
        Me.cmdAllRightServ.Text = ">>"
        Me.cmdAllRightServ.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(48, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(137, 25)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "Select service charges:"
        '
        '_lbTitle_5
        '
        Me._lbTitle_5.BackColor = System.Drawing.Color.Yellow
        Me._lbTitle_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbTitle_5.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbTitle_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbTitle.SetIndex(Me._lbTitle_5, CType(5, Short))
        Me._lbTitle_5.Location = New System.Drawing.Point(8, 16)
        Me._lbTitle_5.Name = "_lbTitle_5"
        Me._lbTitle_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbTitle_5.Size = New System.Drawing.Size(201, 24)
        Me._lbTitle_5.TabIndex = 46
        Me._lbTitle_5.Text = "Step 6. Services >>"
        '
        '_frCriteria_4
        '
        Me._frCriteria_4.BackColor = System.Drawing.SystemColors.Control
        Me._frCriteria_4.Controls.Add(Me.DataGridView6)
        Me._frCriteria_4.Controls.Add(Me.DataGridView5)
        Me._frCriteria_4.Controls.Add(Me.dgSelLoad)
        Me._frCriteria_4.Controls.Add(Me.dgLoad)
        Me._frCriteria_4.Controls.Add(Me.cmdAllLeftLoad)
        Me._frCriteria_4.Controls.Add(Me.cmdLeftLoad)
        Me._frCriteria_4.Controls.Add(Me.cmdRightLoad)
        Me._frCriteria_4.Controls.Add(Me.cmdAllRightLoad)
        Me._frCriteria_4.Controls.Add(Me.Label15)
        Me._frCriteria_4.Controls.Add(Me._lbTitle_4)
        Me._frCriteria_4.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._frCriteria_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frCriteria.SetIndex(Me._frCriteria_4, CType(4, Short))
        Me._frCriteria_4.Location = New System.Drawing.Point(1012, 24)
        Me._frCriteria_4.Name = "_frCriteria_4"
        Me._frCriteria_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._frCriteria_4.Size = New System.Drawing.Size(465, 457)
        Me._frCriteria_4.TabIndex = 25
        Me._frCriteria_4.TabStop = False
        Me._frCriteria_4.Text = "Load"
        '
        'DataGridView6
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView6.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.DataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView6.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5})
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView6.DefaultCellStyle = DataGridViewCellStyle20
        Me.DataGridView6.Enabled = False
        Me.DataGridView6.Location = New System.Drawing.Point(283, 102)
        Me.DataGridView6.Name = "DataGridView6"
        Me.DataGridView6.RowHeadersVisible = False
        Me.DataGridView6.Size = New System.Drawing.Size(169, 19)
        Me.DataGridView6.TabIndex = 48
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.HeaderText = "Selected Load Types"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridView5
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView5.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView5.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4})
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView5.DefaultCellStyle = DataGridViewCellStyle22
        Me.DataGridView5.Enabled = False
        Me.DataGridView5.Location = New System.Drawing.Point(19, 102)
        Me.DataGridView5.Name = "DataGridView5"
        Me.DataGridView5.RowHeadersVisible = False
        Me.DataGridView5.Size = New System.Drawing.Size(169, 19)
        Me.DataGridView5.TabIndex = 47
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.HeaderText = "Load"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'dgSelLoad
        '
        Me.dgSelLoad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSelLoad.Location = New System.Drawing.Point(283, 120)
        Me.dgSelLoad.Name = "dgSelLoad"
        Me.dgSelLoad.Size = New System.Drawing.Size(169, 201)
        Me.dgSelLoad.TabIndex = 46
        '
        'dgLoad
        '
        Me.dgLoad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLoad.Location = New System.Drawing.Point(19, 120)
        Me.dgLoad.Name = "dgLoad"
        Me.dgLoad.Size = New System.Drawing.Size(169, 201)
        Me.dgLoad.TabIndex = 45
        '
        'cmdAllLeftLoad
        '
        Me.cmdAllLeftLoad.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAllLeftLoad.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAllLeftLoad.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAllLeftLoad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAllLeftLoad.Location = New System.Drawing.Point(208, 288)
        Me.cmdAllLeftLoad.Name = "cmdAllLeftLoad"
        Me.cmdAllLeftLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAllLeftLoad.Size = New System.Drawing.Size(49, 33)
        Me.cmdAllLeftLoad.TabIndex = 43
        Me.cmdAllLeftLoad.Text = "<<"
        Me.cmdAllLeftLoad.UseVisualStyleBackColor = False
        '
        'cmdLeftLoad
        '
        Me.cmdLeftLoad.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLeftLoad.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLeftLoad.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLeftLoad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLeftLoad.Location = New System.Drawing.Point(208, 232)
        Me.cmdLeftLoad.Name = "cmdLeftLoad"
        Me.cmdLeftLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLeftLoad.Size = New System.Drawing.Size(49, 33)
        Me.cmdLeftLoad.TabIndex = 42
        Me.cmdLeftLoad.Text = "<"
        Me.cmdLeftLoad.UseVisualStyleBackColor = False
        '
        'cmdRightLoad
        '
        Me.cmdRightLoad.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRightLoad.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRightLoad.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRightLoad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRightLoad.Location = New System.Drawing.Point(208, 176)
        Me.cmdRightLoad.Name = "cmdRightLoad"
        Me.cmdRightLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRightLoad.Size = New System.Drawing.Size(49, 33)
        Me.cmdRightLoad.TabIndex = 41
        Me.cmdRightLoad.Text = ">"
        Me.cmdRightLoad.UseVisualStyleBackColor = False
        '
        'cmdAllRightLoad
        '
        Me.cmdAllRightLoad.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAllRightLoad.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAllRightLoad.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAllRightLoad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAllRightLoad.Location = New System.Drawing.Point(208, 120)
        Me.cmdAllRightLoad.Name = "cmdAllRightLoad"
        Me.cmdAllRightLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAllRightLoad.Size = New System.Drawing.Size(49, 33)
        Me.cmdAllRightLoad.TabIndex = 40
        Me.cmdAllRightLoad.Text = ">>"
        Me.cmdAllRightLoad.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(32, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(201, 17)
        Me.Label15.TabIndex = 44
        Me.Label15.Text = "Select Load Type"
        '
        '_lbTitle_4
        '
        Me._lbTitle_4.BackColor = System.Drawing.Color.Yellow
        Me._lbTitle_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbTitle_4.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lbTitle_4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTitle.SetIndex(Me._lbTitle_4, CType(4, Short))
        Me._lbTitle_4.Location = New System.Drawing.Point(8, 24)
        Me._lbTitle_4.Name = "_lbTitle_4"
        Me._lbTitle_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbTitle_4.Size = New System.Drawing.Size(217, 17)
        Me._lbTitle_4.TabIndex = 33
        Me._lbTitle_4.Text = "  Step 5. Load Types>>"
        '
        'dgDebug
        '
        Me.dgDebug.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDebug.Location = New System.Drawing.Point(1518, 431)
        Me.dgDebug.Name = "dgDebug"
        Me.dgDebug.Size = New System.Drawing.Size(424, 86)
        Me.dgDebug.TabIndex = 100
        '
        'frmRepUniversal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(2063, 1054)
        Me.Controls.Add(Me.dgDebug)
        Me.Controls.Add(Me._frCriteria_3)
        Me.Controls.Add(Me._frCriteria_2)
        Me.Controls.Add(Me._frCriteria_0)
        Me.Controls.Add(Me.cmdFinish)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdPrev)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.sb)
        Me.Controls.Add(Me._frCriteria_6)
        Me.Controls.Add(Me._frCriteria_1)
        Me.Controls.Add(Me._frCriteria_5)
        Me.Controls.Add(Me._frCriteria_4)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(130, 41)
        Me.Name = "frmRepUniversal"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Universal Report"
        Me._frCriteria_3.ResumeLayout(False)
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSelContent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgContent, System.ComponentModel.ISupportInitialize).EndInit()
        Me._frCriteria_2.ResumeLayout(False)
        CType(Me.dgSelEquipment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgEquipment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame2.ResumeLayout(False)
        Me._frCriteria_0.ResumeLayout(False)
        Me._frCriteria_0.PerformLayout()
        Me.sb.ResumeLayout(False)
        Me.sb.PerformLayout()
        Me._frCriteria_1.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame3.ResumeLayout(False)
        Me.Frame4.ResumeLayout(False)
        Me._frCriteria_6.ResumeLayout(False)
        CType(Me.DataGridView10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSelVendor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgVendor, System.ComponentModel.ISupportInitialize).EndInit()
        Me._frCriteria_5.ResumeLayout(False)
        CType(Me.DataGridView8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSelService, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgService, System.ComponentModel.ISupportInitialize).EndInit()
        Me._frCriteria_4.ResumeLayout(False)
        CType(Me.DataGridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSelLoad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgLoad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.frCriteria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obEquipment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDebug, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgSelEquipment As System.Windows.Forms.DataGridView
    Friend WithEvents dgEquipment As System.Windows.Forms.DataGridView
    Friend WithEvents dgSelContent As System.Windows.Forms.DataGridView
    Friend WithEvents dgContent As System.Windows.Forms.DataGridView
    Friend WithEvents dgSelLoad As System.Windows.Forms.DataGridView
    Friend WithEvents dgLoad As System.Windows.Forms.DataGridView
    Friend WithEvents dgSelVendor As System.Windows.Forms.DataGridView
    Friend WithEvents dgVendor As System.Windows.Forms.DataGridView
    Friend WithEvents dgSelService As System.Windows.Forms.DataGridView
    Friend WithEvents dgService As System.Windows.Forms.DataGridView
    Friend WithEvents dgDebug As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView4 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView7 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView6 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView5 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView10 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView9 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView8 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class