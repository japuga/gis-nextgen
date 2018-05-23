Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Friend Class frmRepRecycleTon
	Inherits System.Windows.Forms.Form
	Private sLocalVersion As String
	Private sLocalReport As String
	Private Structure rptRecycleTonParamUDT
		Dim sCustId As String
		Dim sStateId As String
		Dim nGroupSeq As Short
		Dim nPeriodSeq As Short
		Dim sPeriodSeq As String
		Dim nPeriodStartSeq As Short
		Dim nPeriodEndSeq As Short
		Dim sStartDate As String
		Dim sEndDate As String
		Dim sReportCaption As String
		Dim nPeriodSeqFrom As Short
		Dim nPeriodSeqTo As Short
		Dim nError As Short
	End Structure
	Private rptRecycleTonParam As rptRecycleTonParamUDT
    Private rsLocal As DataTable
	'--------Crystal Reports-----------------
    Private rsReport As DataTable
	Private sWhere As String
	
	
    Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
        If cbCustName.SelectedIndex >= 0 Then
            cbCustId.SelectedIndex = cbCustName.SelectedIndex
            load_groups(cbCustId.Text)
            load_period2(cbPeriodName, cbCustId.Text)
            load_period2(cbPeriodStart, cbCustId.Text)
            load_period2(cbPeriodEnd, cbCustId.Text)
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
	
	
	'UPGRADE_WARNING: Event cbPeriodEnd.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbPeriodEnd_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriodEnd.SelectedIndexChanged
		On Error GoTo ErrorHandler
		lbPeriodEndDate.Text = ""
		
		sStmt = "SELECT period_end_date " & " FROM period " & " WHERE cust_id ='" & Trim(cbCustId.Text) & "'" & " AND period_seq =" & Str(VB6.GetItemData(cbPeriodEnd, cbPeriodEnd.SelectedIndex))
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count() > 0 Then
            lbPeriodEndDate.Text = rsLocal.Rows(0).Item("period_end_date")
        End If


        Exit Sub

ErrorHandler:
        save_error(Me.Name, "cbPeriodEnd.click")
        MsgBox("An error occurred while loading  Period Info. Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
		
	End Sub
	
	'UPGRADE_WARNING: Event cbPeriodName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbPeriodName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriodName.SelectedIndexChanged
		
		On Error GoTo ErrorHandler
		lbStartDate.Text = ""
		lbEndDate.Text = ""
		
        sStmt = "SELECT period_start_date, period_end_date " & " FROM period " & _
                " WHERE cust_id ='" & Trim(cbCustId.Text) & "'" & _
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
	
	'UPGRADE_WARNING: Event cbPeriodStart.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbPeriodStart_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriodStart.SelectedIndexChanged
		On Error GoTo ErrorHandler
		lbPeriodStartDate.Text = ""
		
		sStmt = "SELECT period_start_date " & " FROM period " & " WHERE cust_id ='" & Trim(cbCustId.Text) & "'" & " AND period_seq =" & Str(VB6.GetItemData(cbPeriodStart, cbPeriodStart.SelectedIndex))
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count > 0 Then
            lbPeriodStartDate.Text = rsLocal.Rows(0).Item("period_start_date")
        End If



        Exit Sub

ErrorHandler:
        save_error(Me.Name, "cbPeriodStart.click")
        MsgBox("An error occurred while loading  Period Info. Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
		
		
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		
		If val_fields Then
			If get_criteria Then
				If build_query Then
					set_params()
					ReportHandler2()
				End If
			End If
		End If
		
		
	End Sub
	Private Sub set_params()
		
		'Se asigna parametros del reporte
		With rptRecycleTonParam
			.sCustId = cbCustId.Text
			.sStateId = cbStateId.Text '"TX"
			.nPeriodSeq = VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex) '16
			.nGroupSeq = VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex) '3
			.nPeriodStartSeq = VB6.GetItemData(cbPeriodStart, cbPeriodStart.SelectedIndex)
			.nPeriodEndSeq = VB6.GetItemData(cbPeriodEnd, cbPeriodEnd.SelectedIndex)
		End With
		If cbStateId.Text = "<All>" Then
			rptRecycleTonParam.sStateId = "All"
		End If
		
		'Period/Date Flag
		If obSinglePeriod.Checked = True Then
			rptRecycleTonParam.sPeriodSeq = "P"
			rptRecycleTonParam.nPeriodSeqFrom = 0
			rptRecycleTonParam.nPeriodSeqTo = 0
			rptRecycleTonParam.sStartDate = lbStartDate.Text
			rptRecycleTonParam.sEndDate = lbEndDate.Text
		End If
		If obRangePeriod.Checked = True Then
			rptRecycleTonParam.sPeriodSeq = "R"
			rptRecycleTonParam.nPeriodSeqFrom = VB6.GetItemData(cbPeriodStart, cbPeriodStart.SelectedIndex)
			rptRecycleTonParam.nPeriodSeqTo = VB6.GetItemData(cbPeriodEnd, cbPeriodEnd.SelectedIndex)
			rptRecycleTonParam.sStartDate = lbPeriodStartDate.Text
			rptRecycleTonParam.sEndDate = lbPeriodEndDate.Text
		End If
		If obRange.Checked = True Then
			rptRecycleTonParam.sPeriodSeq = "D"
			rptRecycleTonParam.nPeriodSeqFrom = 0
			rptRecycleTonParam.nPeriodSeqTo = 0
            'UPGRADE_WARNING: Couldn't resolve default property of object dtStartDate. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            rptRecycleTonParam.sStartDate = dtStartDate.Value
            'UPGRADE_WARNING: Couldn't resolve default property of object dtEndDate. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            rptRecycleTonParam.sEndDate = dtEndDate.Value
		End If
		
		'Caption
		If Len(txtReportCaption.Text) = 0 Then
			rptRecycleTonParam.sReportCaption = ""
		Else
			rptRecycleTonParam.sReportCaption = Trim(txtReportCaption.Text)
		End If
		
		
	End Sub
	'Verifica que los parametros sean correctos
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
		
		'Store Group Name
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
		
		'obSinglePeriod
		If obSinglePeriod.Checked = False And obRange.Checked = False And obRangePeriod.Checked = False Then
			MsgBox(" You must select and Invoicing Period or Date Range")
			val_fields = False
			Exit Function
		End If
		
		If obSinglePeriod.Checked = True Then
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
		
		'obRangePeriod
		If obRangePeriod.Checked = True Then
			If cbPeriodStart.SelectedIndex < 0 Or cbPeriodEnd.SelectedIndex < 0 Then
				MsgBox("You must select an Invoicing Start and End period.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
				cbPeriodStart.Focus()
				val_fields = False
				Exit Function
			Else
				If IsDate(lbPeriodStartDate.Text) And IsDate(lbPeriodEndDate.Text) Then
					
					If CDate(lbPeriodStartDate.Text) > CDate(lbPeriodEndDate.Text) Then
						MsgBox("Invoicing Start Period must be less than End Period Date", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
						cbPeriodStart.Focus()
						val_fields = False
						Exit Function
					End If
				Else
					MsgBox("Start-End Invoicing periods must be corrected, you can change this" & vbCrLf & "on Inputs- Invoicing Period menu option", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
					val_fields = False
					Exit Function
				End If
			End If
		End If
		
		'obRange
		If obRange.Checked = True Then
            'UPGRADE_WARNING: Couldn't resolve default property of object dtEndDate. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object dtStartDate. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If dtStartDate.Value > dtEndDate.Value Then
                MsgBox("Start Date must be less than End Date.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
                val_fields = False
                Exit Function
            End If
		End If
		
		'obDetail - obSummary
		If obDetail.Checked = False And obSummary.Checked = False Then
			MsgBox("Please select report type.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Warning")
			obDetail.Focus()
			val_fields = False
			Exit Function
		End If
		
		val_fields = True
	End Function
	'Construye condicion del query en base
	'a parametros proporcionados por usuario
	Private Function get_criteria() As Boolean
        Dim sPeriod As String = ""
		
		On Error GoTo ErrorHandler
		
		'Customer
		sWhere = " AND vInvoice.cust_id ='" & cbCustId.Text & "'"
		
		
		'State
		If cbStateId.SelectedIndex = 0 Then
			'All States
		Else
			sWhere = sWhere & " AND store.state_id ='" & cbStateId.Text & "'"
		End If
		
		
		'GroupStore
		If cbGroupName.Text = "All" Then
			'All
		Else
			sWhere = sWhere & " AND Store.store_id IN ( SELECT store_id FROM groupStore " & " WHERE groupStore.cust_id = Store.cust_id  " & " AND groupStore.group_seq =" & Str(VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex)) & ")"
			
		End If
		
		If obSinglePeriod.Checked = True Then
			sWhere = sWhere & " AND vInvoice.period_seq =" & Str(VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex))
			
		ElseIf obRangePeriod.Checked Then 
			
			sStmt = "SELECT period_seq FROM period a " & " WHERE cust_id='" & Trim(cbCustId.Text) & "' " & " AND period_start_date >=(SELECT period_start_date FROM period b " & " WHERE b.cust_id = a.cust_id " & " AND b.period_seq=" & Str(VB6.GetItemData(cbPeriodStart, cbPeriodStart.SelectedIndex)) & ")" & " AND period_end_date <=(SELECT period_end_date FROM period c " & " WHERE c.cust_id = a.cust_id " & " AND c.period_seq=" & Str(VB6.GetItemData(cbPeriodEnd, cbPeriodEnd.SelectedIndex)) & ")"
			
            rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rs.Rows.Count > 0 Then
                For row As Integer = 0 To rs.Rows.Count - 1
                    sPeriod = sPeriod & Str(rs.Rows(row).Item("period_seq")) & ","
                Next row
                
                sPeriod = VB.Left(sPeriod, Len(sPeriod) - 1)
            End If


            sWhere = sWhere & " AND vInvoice.period_seq IN (" & sPeriod & ")"
        ElseIf obRange.Checked Then
            sWhere = sWhere & "AND vInvoice.vinvoice_date BETWEEN " & "'" & Str(dtStartDate.Value) & "' " & " AND '" & Str(dtEndDate.Value) & "'"
        End If

        get_criteria = True
        Exit Function

ErrorHandler:
        get_criteria = False
        save_error(Me.Name, "get_criteria")
        MsgBox("Unexpected error found. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
	End Function
	Private Function build_query() As Boolean
		Dim nRecords As Short
		
		'Obengo el identificador del reporte
		build_query = False
		
		nReport = 0
		nReport = get_seed("repdata")
		If nReport <= 0 Then
			MsgBox("Unable to get Report Number." & vbCrLf & "Report has not been generated.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Function
		End If
		
		sStmt = "INSERT INTO RptRecycleTonTmp ( " & " report_id, cust_id,  cust_name,  state_id, state_name, store_id," & " eqpt_id, load_id, eqpt_desc, eqpt_qty, " & " eqpt_size_capacity, invoice_no, period_seq,  vinvoice_date," & " vend_seq, content_desc, content_type, pound_factor, " & " eqpt_seq, serv_id, serv_desc, freq_period," & " freq_times, week_factor, serv_usage, frequency_mask, " & " report_start, report_end ) "
		
		sStmt = sStmt & "SELECT " & Str(nReport) & ",Customer.cust_id, " & "Customer.cust_name, Store.state_id, State.state_name, " & "Store.store_id," & "StoreEqpt.eqpt_id, StoreEqpt.load_id," & "StoreEqpt.eqpt_desc, StoreEqpt.eqpt_qty," & "StoreEqpt.eqpt_size_capacity," & "vInvoice.invoice_no, vInvoice.period_seq," & "vInvoice.vinvoice_date," & "vInvoice.vend_seq," & "Content.content_desc, Content.content_type, Content.pound_factor," & "vInvoiceDet.eqpt_seq, vInvoiceDet.serv_id, Service.serv_desc," & "vContract.freq_period, vContract.freq_times," & "Frequency.week_factor," & "vInvoiceDet.serv_usage," & "CAST(dbo.format_freq2 (Frequency.freq_sched_flag," & "Frequency.freq_times_flag, VContract.freq_times," & "ISNULL(VContract.freq_period,''), ISNULL(VContract.freq_day1,'')," & "ISNULL(VContract.freq_day2,''), ISNULL(VContract.freq_day3,'')," & "ISNULL(VContract.freq_day4,''), ISNULL(VContract.freq_day5,'')," & "ISNULL(VContract.freq_day6,''), ISNULL(VContract.freq_day7,''))  AS CHAR(60))AS frequency_mask," & "CONVERT(CHAR(10),getdate(),101) as report_start," & "CONVERT(Char(10), getdate(), 101) As report_end"
		
		sStmt = sStmt & " FROM vInvoice , vInvoiceDet , Customer , Store , StoreEqpt ," & " Content , vContract, Service, Frequency, State "
		
		sStmt = sStmt & " WHERE vInvoice.invoice_no = vInvoiceDet.invoice_no " & "AND vInvoice.cust_id = vInvoiceDet.cust_id " & "AND vInvoice.store_id = vInvoiceDet.store_id " & "AND vInvoice.account_no = vInvoiceDet.account_no " & "AND vInvoice.vend_seq = vInvoiceDet.vend_seq " & "AND vInvoice.cust_id = Customer.cust_id " & "AND vInvoice.cust_id = Store.cust_id " & "AND vInvoice.store_id = Store.store_id " & "AND Store.cust_id = StoreEqpt.cust_id " & "AND Store.store_id = StoreEqpt.store_Id " & "AND StoreEqpt.content_id = Content.content_id " & "AND StoreEqpt.eqpt_seq = vInvoiceDet.eqpt_seq  " & "AND vInvoiceDet.cust_id = VContract.cust_id " & "AND vInvoiceDet.vend_seq = vContract.vend_seq " & "AND vInvoiceDet.store_id = vContract.store_id " & "AND vInvoiceDet.eqpt_seq = vContract.eqpt_seq " & "AND vInvoiceDet.serv_id = vContract.serv_id " & "AND Service.serv_id = vInvoiceDet.serv_id " & "AND vContract.freq_id = Frequency.freq_id " & "AND Store.state_id = State.state_id " & "AND vContract.default_service ='T'  " & "AND Content.content_type = 'RECYCLE' " & "AND StoreEqpt.eqpt_status = 'A' "
		
		sStmt = sStmt & sWhere & " ORDER BY store_name"
		
        cm = cn.CreateCommand() '.let_ActiveConnection(cn)

		cm.CommandText = sStmt
        nRecords = cm.ExecuteNonQuery()
		
		If nRecords > 0 Then
			'MsgBox "Found " + Str(nRecords) + " records."
		Else
			MsgBox("No records were found for such criteria.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Title")
			build_query = False
			Exit Function
		End If
		
		build_query = True
		Exit Function
		
ErrorHandler: 
		build_query = False
		save_error(Me.Name, "build_query")
		MsgBox("Unexpected error was found. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
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
		
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            cmReport.CommandTimeout = gnTimeout
            cmReport = cn.CreateCommand()
            cmReport.CommandType = CommandType.StoredProcedure
            '		cmReport.Parameters.Refresh()

            'get_seed se cambio a build_query


            'Se cargan los parametros dependiendo del tipo de reporte
            cmReport.CommandText = "usp_rep_recycle_ton25"
            SqlCommandBuilder.DeriveParameters(cmReport)
            cmReport.Parameters("@nReportId").Value = nReport
            cmReport.Parameters("@sCustId").Value = rptRecycleTonParam.sCustId
            cmReport.Parameters("@sStateId").Value = rptRecycleTonParam.sStateId
            cmReport.Parameters("@nGroupSeq").Value = rptRecycleTonParam.nGroupSeq
            cmReport.Parameters("@nPeriodSeq").Value = rptRecycleTonParam.nPeriodSeq
            cmReport.Parameters("@sPeriodSeq").Value = rptRecycleTonParam.sPeriodSeq
            cmReport.Parameters("@sStartDate").Value = rptRecycleTonParam.sStartDate
            cmReport.Parameters("@sEndDate").Value = rptRecycleTonParam.sEndDate
            cmReport.Parameters("@sReportCaption").Value = rptRecycleTonParam.sReportCaption
            cmReport.Parameters("@nPeriodSeqFrom").Value = rptRecycleTonParam.nPeriodSeqFrom
            cmReport.Parameters("@nPeriodSeqTo").Value = rptRecycleTonParam.nPeriodSeqTo
            cmReport.Parameters("@nError").Direction = ParameterDirection.Output

            log_report_parameters(sLocalReport, cmReport)

            'Ejecuto el procedure y verifico por errores
            cmReport.ExecuteNonQuery()

            rptRecycleTonParam.nError = cmReport.Parameters("@nError").Value
            If rptRecycleTonParam.nError <> 0 Then
                MsgBox("An error ocurred while generating report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                Exit Sub
            End If

            'Verifico que se hayan cargado datos en RptRecyleTon para este reporte
            sStmt = "SELECT count(*) FROM rptRecycleTon WHERE report_no = " & Str(nReport)

            Try
                rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                If rsLocal.Rows(0).Item(0) > 0 Then
                    'Encontro registros
                Else
                    MsgBox("No data was generated for :" & gReport.name & " report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("There was an error while verifying report data for:" & gReport.name, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End Try

            If obDetail.Checked Then
                sStmt = " SELECT report_no, cust_id, LTRIM(RTRIM(cust_name))," & "report_start, report_end," & "date_range," & "store_no," & "store_address," & "vendor_name," & "eqpt_desc," & "eqpt_freq," & "calc_serv_usage, calc_yard, calc_weight_yard, calc_weight_ton, " & "tot_serv_usage , tot_yard, tot_weight_yard, tot_weight_ton " & " FROM rptRecycleTon " & " WHERE report_no = " & Str(nReport)
            Else
                'SUMMARY
                sStmt = "SELECT report_no, state_id, state_name, " & " cust_id, LTRIM(RTRIM(cust_name))AS cust_name, date_range, " & " SUM(calc_serv_usage)AS calc_serv_usage, SUM(calc_yard) AS calc_yard," & " SUM(calc_weight_yard) AS calc_weight_yard, SUM(calc_weight_ton) AS calc_weight_ton, " & " tot_serv_usage , tot_yard, tot_weight_yard, tot_weight_ton " & " FROM rptRecycleTon " & " WHERE report_no = " & Str(nReport) & " GROUP BY report_no, state_id, state_name, " & " cust_id, cust_name, date_range, " & " tot_serv_usage , tot_yard, tot_weight_yard, tot_weight_ton "


            End If

            'If rsReport.State = ADODB.ObjectStateEnum.adStateOpen Then
            '    rsReport.Close()
            'End If
            rsReport = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If gbDebug Then
                'DataGrid1.Visible = True
                DataGrid1.DataSource = rsReport
            End If

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            'Cargo la plantilla de Crystal Reports con los datos
            load_report()

            Exit Sub

        Catch ex As Exception
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            save_error(Me.Name, "show_report2")
        End Try
        'For Each e In cn.Errors
        '    MsgBox(e.Description)
        'Next e
    End Sub
	
	Private Function load_report() As Boolean

		Dim sFile As String 'Path de la plantilla del reporte
        'Dim sReportTemplate As String 'Nombre de plantilla de reporte
		Dim fileTmp As Scripting.FileSystemObject
		fileTmp = New Scripting.FileSystemObject
		
		'On Error GoTo ErrorHandler
		
		'Abro el archivo con el reporte
        'crysApp = CreateObject("Crystal.CRPE.Application")
		
		'sFile = "c:\glm\Visual Basic\Glm-System\Reports\rptRecycleTon.rpt"
		sFile = get_template(sLocalReport, cbReportTemplate.Text)

        Dim rptDoc As ReportDocument = New ReportDocument()
        If fileTmp.FileExists(sFile) Then
            rptDoc.Load(sFile)
        Else
            MsgBox("Report template not found." & vbCrLf & "Please install: " & sFile, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
            Exit Function
        End If

        rptDoc.SetDataSource(rsReport)

        frmRepRecycleTonViewer.CrystalReportViewer1.ReportSource = rptDoc
        frmRepRecycleTonViewer.CrystalReportViewer1.Visible = True
        frmRepRecycleTonViewer.CrystalReportViewer1.Show()
        frmRepRecycleTonViewer.Show()
		
		'Asignar impresora seleccionada por usuario.
		'report.SelectPrinter "HP DeskJet 550C","remota", "LPT1"
        'crysRepRecycleTon.SelectPrinter(Printer.DriverName, Printer.DeviceName, Printer.Port)
		
		If obDetail.Checked Then

		ElseIf obSummary.Checked Then 

		End If
		
		'reportTable.SetPrivateData 3, AdoRs
        'reportTable.SetPrivateData(3, rsReport)
		
		'cd.CancelError = True
		'cd.ShowPrinter
		'crysRepRecycleTon.DialogParentWindow = Me
        'crysRepRecycleTon.ProgressDialogEnabled = True
        'crysRepRecycleTon.Preview()
		
		'ErrorHandler:
		'If Err.Number = cdlCancel Then
		'    MsgBox "usuario aborto"
		'End If
	End Function
	
	
	Private Sub frmRepRecycleTon_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	Private Sub init_vars()
		sLocalVersion = "DEFAULT"
		sLocalReport = gReport.name
		
        rsLocal = Nothing
        rsReport = Nothing
		
		lbStartDate.Text = ""
		lbEndDate.Text = ""
		'UPGRADE_WARNING: TextBox property txtReportCaption.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtReportCaption.Maxlength = 30 'customer.cust_report_name CHAR(30)
		DataGrid1.Visible = False
		
		obSinglePeriod.Checked = False
		obRangePeriod.Checked = False
		obRange.Checked = False
		
		period_enable(True)
		period_range_enable(True)
		range_enable(True)
		
		
        dtStartDate.Value = Today
		dtEndDate.value = Today
		
		'Report Type
		obDetail.Checked = True
		obSummary.Checked = False
		
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
		
		'load_template cbReportTemplate, sLocalReport
		
	End Sub
	Private Sub load_template(ByRef cb As System.Windows.Forms.ComboBox, ByRef sReportName As String)
		'Combo Report Template
		sStmt = "SELECT rep_template_name, col_order " & "FROM RepDef a, RepDefTemplate b " & " WHERE a.rep_no = b.rep_no " & " AND a.rep_caption ='" & sReportName & "' " & " ORDER BY col_order "
		load_cb_query2(cbReportTemplate, sStmt, 1, True)
		
		If cbReportTemplate.Items.Count > 0 Then
			cbReportTemplate.SelectedIndex = 0
		End If
		
	End Sub
	Private Sub period_enable(ByRef bOption As Boolean)
		cbPeriodName.Enabled = bOption
	End Sub
	Private Sub period_range_enable(ByRef bOption As Boolean)
		cbPeriodStart.Enabled = bOption
		cbPeriodEnd.Enabled = bOption
	End Sub
	Private Sub range_enable(ByRef bOption As Boolean)
		dtStartDate.Enabled = bOption
		dtEndDate.Enabled = bOption
	End Sub
	
	'UPGRADE_WARNING: Event obDetail.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub obDetail_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles obDetail.CheckedChanged
		If eventSender.Checked Then
			If obDetail.Checked = True Then
				cbStateId.Enabled = True
				sLocalReport = "Recycle Tonnage Report"
				load_template(cbReportTemplate, sLocalReport)
			End If
			
		End If
	End Sub
	
	'UPGRADE_WARNING: Event obSinglePeriod.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub obSinglePeriod_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles obSinglePeriod.CheckedChanged
		If eventSender.Checked Then
			If obSinglePeriod.Checked = True Then
				period_enable(True)
				period_range_enable(False)
				range_enable(False)
			End If
		End If
	End Sub
	
	'UPGRADE_WARNING: Event obRange.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub obRange_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles obRange.CheckedChanged
		If eventSender.Checked Then
			If obRange.Checked = True Then
				period_enable(False)
				period_range_enable(False)
				range_enable(True)
			End If
			
		End If
	End Sub
	
	
	'UPGRADE_WARNING: Event obRangePeriod.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub obRangePeriod_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles obRangePeriod.CheckedChanged
		If eventSender.Checked Then
			If obRangePeriod.Checked = True Then
				period_enable(False)
				period_range_enable(True)
				range_enable(False)
				
			End If
		End If
	End Sub
	
	'UPGRADE_WARNING: Event obSummary.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub obSummary_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles obSummary.CheckedChanged
		If eventSender.Checked Then
			If obSummary.Checked = True Then
				cbStateId.Enabled = False
				cbStateId.SelectedIndex = 0 'ALL
				sLocalReport = "Recycle Tonnage Report Summary"
				load_template(cbReportTemplate, sLocalReport)
			End If
			
		End If
	End Sub
End Class