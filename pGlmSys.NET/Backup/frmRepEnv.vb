Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Friend Class frmRepEnv
	Inherits System.Windows.Forms.Form
	Private sLocalVersion As String
	Private sLocalReport As String
	Private Structure rptEnvParamUDT
		Dim sCustId As String
		Dim sStateId As String
		Dim nGroupSeq As Short
		Dim nPeriodSeq As Short
		Dim bPeriodSeq As Boolean
		Dim sStartDate As String
		Dim sEndDate As String
		Dim sReportCaption As String
		Dim nError As Short
	End Structure
	Private rptEnvParam As rptEnvParamUDT
    Private rsLocal As DataTable
	'--------Crystal Reports-----------------
    Private rsReport As DataTable
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		If cbCustName.SelectedIndex >= 0 Then
			cbCustId.SelectedIndex = cbCustName.SelectedIndex
			load_groups(cbCustId.Text)
			load_period(cbCustId.Text)
		End If
		
	End Sub
	'Carga el combo de grupos
	Private Sub load_groups(ByRef sCustId As String)
		
		On Error GoTo ErrorHandler
		If Len(sCustId) <= 0 Then
			cbGroupName.Items.Clear()
			Exit Sub
		End If
		
		
		sStmt = "SELECT group_name,group_seq FROM groups " & " WHERE cust_id ='" & Trim(cbCustId.Text) & "'" & " AND type_id = '" & GROUP_LOCAL & "' " & " ORDER BY group_name"
		load_cb_query2(cbGroupName, sStmt, 2, True)
		
		If cbGroupName.Items.Count > 0 Then
			cbGroupName.SelectedIndex = 0
		End If
		
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_groups")
	End Sub
	
	Private Sub load_period(ByRef sCustId As String)
		On Error GoTo ErrorHandler
		If Len(sCustId) <= 0 Then
			cbPeriodName.Items.Clear()
			Exit Sub
		End If
		
		
		sStmt = "SELECT period_name, period_seq, period_start_date FROM period " & " WHERE cust_id ='" & Trim(cbCustId.Text) & "'" & " ORDER BY period_start_date DESC "
		load_cb_query2(cbPeriodName, sStmt, 2, True)
		
		If cbPeriodName.Items.Count > 0 Then
			cbPeriodName.SelectedIndex = 0
		End If
		
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_period")
		
	End Sub
	

	Private Sub cbPeriodName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriodName.SelectedIndexChanged
		
		On Error GoTo ErrorHandler
		lbStartDate.Text = ""
		lbEndDate.Text = ""
		
        sStmt = "SELECT period_start_date, period_end_date " & " FROM period " & " WHERE cust_id ='" & Trim(cbCustId.Text) & "'" & _
                " AND period_seq =" & Str(VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex))
		
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count > 0 Then
            lbStartDate.Text = rsLocal.Rows(0).Item("period_start_date")
            lbEndDate.Text = rsLocal.Rows(0).Item("period_end_date")
        End If

        Exit Sub

ErrorHandler:
        save_error(Me.Name, "cbPeriodName.click")
        MsgBox("An error occurred while loading  Period Info. Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
		
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
        'Dim sReportTemplate As String
		If val_fields = False Then
			Exit Sub
		End If
		
		'Se asigna parametros del reporte
		With rptEnvParam
			.sCustId = cbCustId.Text
			.sStateId = cbStateId.Text '"TX"
			.nPeriodSeq = VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex) '16
			.nGroupSeq = VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex) '3
			.bPeriodSeq = obPeriod.Checked 'True
			.sStartDate = CStr(Today)
			.sEndDate = CStr(Today)
		End With
		If cbStateId.Text = "<All>" Then
			rptEnvParam.sStateId = "All"
		End If
		
		If Len(txtReportCaption.Text) = 0 Then
			rptEnvParam.sReportCaption = ""
		Else
			rptEnvParam.sReportCaption = Trim(txtReportCaption.Text)
		End If
		
		
		ReportHandler2()
		
	End Sub
	
	'Verifies parameters are correct
	Private Function val_fields() As Boolean
		'Cust
		If cbCustName.SelectedIndex < 0 Then
			MsgBox("You must choose a customer", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
			cbCustName.Focus()
			val_fields = False
			Exit Function
		End If
		
		'State
		If cbStateId.SelectedIndex < 0 Then
			MsgBox("You must select an State or All States option.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
			cbStateId.Focus()
			val_fields = False
			Exit Function
		End If
		
		'Store GRoup Name
		If cbGroupName.SelectedIndex < 0 Then
			MsgBox("You must select an store group.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
			cbGroupName.Focus()
			val_fields = False
			Exit Function
		Else
			'group_seq
			If VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex) > 0 Then
				'Ok
			Else
				MsgBox("Unable to get Store Group info", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
				cbGroupName.Focus()
				val_fields = False
				Exit Function
			End If
		End If
		
		'Report Template
		If cbReportTemplate.SelectedIndex < 0 Then
			val_fields = False
			MsgBox("Please select a Report Template.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Warning")
			cbReportTemplate.Focus()
			Exit Function
		End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(cbReportTemplate.Text) Then
			val_fields = False
			MsgBox("Please select a Report Template.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Warning")
			cbReportTemplate.Focus()
			Exit Function
		End If
		
		'obPeriod
		If obPeriod.Checked = False Then
			MsgBox(" You must select and Invoicing Period ")
			val_fields = False
			Exit Function
		End If
		
		If obPeriod.Checked = True Then
			If cbPeriodName.SelectedIndex < 0 Then
				MsgBox("You must select an Invoicing period.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
				cbPeriodName.Focus()
				val_fields = False
				Exit Function
			Else
				If IsDate(lbStartDate.Text) And IsDate(lbEndDate.Text) Then
					'fechas ok
				Else
					MsgBox("Invoicing period must be corrected, you can change this" & vbCrLf & "on Inputs- Invoicing Period menu option", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
					val_fields = False
					Exit Function
					
				End If
			End If
		End If
		
		
		val_fields = True
		
		
		
	End Function
	
    Private Function ReportHandler2() As Boolean
        ReportHandler2 = False
        'Seleccionar impresora
        If find_printer() Then
            'Version para soporte a Crystal Reports
            show_report2()
        End If

    End Function
	'Permite seleccionar una impresora para imprimir
	Private Function find_printer() As Boolean
		'No existen impresora definidas en esta maquina
		'UPGRADE_ISSUE: Printers method Printers.Count was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count <= 0 Then
            MsgBox("There are not printers defined in this computer." & vbCrLf & "Please set up a default printer before proceeding.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message")

            find_printer = False
            Exit Function
        End If
		
        'VB6.ShowForm(frmPrinter, VB6.FormShowConstants.Modal, Me)
        find_printer = True
        'If gbPrinter Then
        '	find_printer = True
        'Else
        '	find_printer = False
        'End If
	End Function
	'Rel1.3.2 Extension de show_report para manejar reportes
	'en Crystal Reports.
	'1.-Obtiene la semilla para el reporte (get_seed)
	'2.-Ejecuta el store procedure para cargar RepData
	'3.-Verifica que se haya ejecutado, que hayan datos en RepData
	'4.-Mapea campos de RepData con los definidos en RepCust
	'5.-Muestra el reporte
	Private Sub show_report2()

        'Dim c, sec As Object
        'Dim sOrder As String
		
		'On Error GoTo ErrorHandler
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		cmReport.CommandTimeout = gnTimeout
		
        cmReport = cn.CreateCommand '.let_ActiveConnection(cn)
        cmReport.CommandType = CommandType.StoredProcedure

		'Obengo el identificador del reporte
		nReport = 0
		nReport = get_seed("repdata")
		If nReport <= 0 Then
			MsgBox("Unable to get Report Number." & vbCrLf & "Report has not been generated.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Sub
		End If
		
		
		cmReport.CommandText = "usp_rep_env_main"
        SqlCommandBuilder.DeriveParameters(cmReport)
		cmReport.Parameters("@nReportId").Value = nReport
		cmReport.Parameters("@sCustId").Value = rptEnvParam.sCustId
		cmReport.Parameters("@sStateId").Value = rptEnvParam.sStateId
		cmReport.Parameters("@nGroupSeq").Value = rptEnvParam.nGroupSeq
		cmReport.Parameters("@nPeriodSeq").Value = rptEnvParam.nPeriodSeq
		If rptEnvParam.bPeriodSeq Then
			cmReport.Parameters("@sPeriodSeq").Value = "T"
			cmReport.Parameters("@sStartDate").Value = Today
			cmReport.Parameters("@sEndDate").Value = Today
		Else
			cmReport.Parameters("@sPeriodSeq").Value = "F"
			cmReport.Parameters("@sStartDate").Value = rptEnvParam.sStartDate
			cmReport.Parameters("@sEndDate").Value = rptEnvParam.sEndDate
		End If
		cmReport.Parameters("@sReportCaption").Value = rptEnvParam.sReportCaption
		cmReport.Parameters("@nPeriodSeqFrom").Value = rptEnvParam.nPeriodSeq
		cmReport.Parameters("@nPeriodSeqTo").Value = rptEnvParam.nPeriodSeq
		
		If ckShowContract.CheckState = System.Windows.Forms.CheckState.Checked Then
			cmReport.Parameters("@sShowContractRange").Value = "T"
		Else
			cmReport.Parameters("@sShowContractRange").Value = "F"
		End If
		cmReport.Parameters("@sYTD").Value = "T"
		cmReport.Parameters("@nDebug").Value = 0
		
		
        'Execute procedure and check for errors
        cmReport.Parameters("@nError").Direction = ParameterDirection.Output
        cmReport.ExecuteNonQuery()
		
		rptEnvParam.nError = cmReport.Parameters("@nError").Value
		If rptEnvParam.nError <> 0 Then
			MsgBox("An error ocurred while generating report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Sub
		End If
		
		'Verifico que se hayan cargado datos en RepData para este reporte
		sStmt = "SELECT count(*) FROM rptEnv WHERE report_id = " & Str(nReport)
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsLocal.Rows.Count > 0 Then
            If rsLocal.Rows(0).Item(0) > 0 Then
                'Encontro registros
            Else
                MsgBox("No data was generated for: " & gReport.name & " report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")

                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If
        Else
            MsgBox("There was an error while verifying report data for:" & gReport.name, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
		
		
		
		
		
		
		sStmt = "SELECT * " & "FROM rptEnv " & "WHERE report_id = " & Str(nReport) & " ORDER BY store_no "
		
		
		
		'sStmt = sStmt + sOrder
        rsReport = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		
        'MsgBox Str(rsReport.item("total_units_pounds"))
		
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		'Cargo la plantilla de Crystal Reports con los datos
		load_report()
		Exit Sub
		
ErrorHandler: 
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		save_error(Me.Name, "show_report2")
		
	End Sub
	
	Private Function load_report() As Boolean
        Dim sFile As String 'Path de la plantilla del reporte
        'Dim sReportTemplate As String 'Nombre de plantilla de reporte
        Dim fileTmp As Scripting.FileSystemObject
        fileTmp = New Scripting.FileSystemObject

        'On Error GoTo ErrorHandler

        'Abro el archivo con el reporte
        sFile = get_template(sLocalReport, cbReportTemplate.Text)
        If fileTmp.FileExists(sFile) Then

        Else
            sFile = get_local_template(sLocalReport)
            If fileTmp.FileExists(sFile) Then
            Else
                MsgBox("Report template not found." & vbCrLf & "Please install: " & sFile, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                Exit Function
            End If

        End If

        'Asignar impresora seleccionada por usuario.
        'report.SelectPrinter "HP DeskJet 550C","remota", "LPT1"
        'UPGRADE_ISSUE: Printer property Printer.Port was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'UPGRADE_ISSUE: Printer property Printer.DeviceName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'UPGRADE_ISSUE: Printer property Printer.DriverName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'crysRepEnv.SelectPrinter(Printer.DriverName, Printer.DeviceName, Printer.Port)

        'cd.CancelError = True
        'cd.ShowPrinter

        'ErrorHandler:
        'If Err.Number = cdlCancel Then
        '    MsgBox "usuario aborto"
        'End If
    End Function
	
	
	Private Sub frmRepEnv_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	Private Sub init_vars()
		sLocalVersion = "DEFAULT"
		sLocalReport = "Environmental Report"
		
		lbStartDate.Text = ""
		lbEndDate.Text = ""
		'UPGRADE_WARNING: TextBox property txtReportCaption.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtReportCaption.Maxlength = 30 'customer.cust_report_name CHAR(30)
		
		obPeriod.Checked = False
		period_enable(False)
		
		
		
		'Combo Customer
		sStmt = "SELECT cust_name, cust_id FROM customer  ORDER BY cust_name"
		load_cb_query2(cbCustName, sStmt, 1, True)
		
		sStmt = "SELECT cust_id FROM customer  ORDER BY cust_name"
		load_cb_query2(cbCustId, sStmt, 1, True)
		
		If cbCustName.Items.Count > 0 Then
			cbCustName.SelectedIndex = 0
		End If
		
		'Combo State
		cbStateId.Items.Insert(0, "<All>")
		
		sStmt = "SELECT state_id FROM state"
		load_cb_query2(cbStateId, sStmt, 1, False)
		
		If cbStateId.SelectedIndex Then
			cbStateId.SelectedIndex = 0
		End If
		
		'Combo Report Template
		sStmt = "SELECT rep_template_name, col_order " & "FROM RepDef a, RepDefTemplate b " & " WHERE a.rep_no = b.rep_no " & " AND a.rep_caption ='" & sLocalReport & "' " & " ORDER BY col_order "
		load_cb_query2(cbReportTemplate, sStmt, 1, True)
		
		If cbReportTemplate.Items.Count > 0 Then
			cbReportTemplate.SelectedIndex = 0
		End If
		
	End Sub
	
	Private Sub period_enable(ByRef bOption As Boolean)
		cbPeriodName.Enabled = bOption
	End Sub
	
	'UPGRADE_WARNING: Event obPeriod.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub obPeriod_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles obPeriod.CheckedChanged
		If eventSender.Checked Then
			If obPeriod.Checked = True Then
				period_enable(True)
			End If
		End If
	End Sub
End Class