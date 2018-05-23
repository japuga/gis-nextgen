Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Friend Class frmRepRecycleTonGen
	Inherits System.Windows.Forms.Form
	Private params As gRptRecycleTonGenParamUDT
	
	Private sLocalVersion As String
	Private sLocalReport As String
    Private rsLocal As DataTable
	'--------Crystal Reports-----------------
    Private rsReport As DataTable
	Private sWhere As String
	
	
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		If cbCustName.SelectedIndex >= 0 Then
			cbCustId.SelectedIndex = cbCustName.SelectedIndex
			
			load_cb_storeGroups(Me.Name, (cbCustId.Text), cbGroupName)
			load_cb_period(Me.Name, (cbCustId.Text), cbPeriodName)
			load_cb_period(Me.Name, (cbCustId.Text), cbPeriodStart)
			load_cb_period(Me.Name, (cbCustId.Text), cbPeriodEnd)
		End If
	End Sub
	
	'UPGRADE_WARNING: Event cbPeriodEnd.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbPeriodEnd_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriodEnd.SelectedIndexChanged
		
		lbPeriodEndDate.Text = getPeriodStartEndDate((cbCustId.Text), VB6.GetItemData(cbPeriodEnd, cbPeriodEnd.SelectedIndex), "END")
		
	End Sub
	
	'UPGRADE_WARNING: Event cbPeriodName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbPeriodName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriodName.SelectedIndexChanged
		
		lbStartDate.Text = ""
		lbEndDate.Text = ""
		
		'UPGRADE_WARNING: Couldn't resolve default property of object gDump. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		gDump = getPeriodDates(VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex))
		
		lbStartDate.Text = gDump.str1
		lbEndDate.Text = gDump.str2
		
		
		
	End Sub
	
	'UPGRADE_WARNING: Event cbPeriodStart.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbPeriodStart_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriodStart.SelectedIndexChanged
		
		lbPeriodStartDate.Text = getPeriodStartEndDate((cbCustId.Text), VB6.GetItemData(cbPeriodStart, cbPeriodStart.SelectedIndex), "START")
		
	End Sub
	
	'UPGRADE_WARNING: Event cbReportTemplate.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbReportTemplate_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbReportTemplate.SelectedIndexChanged
		
		If cbReportTemplate.SelectedIndex >= 0 Then
			cbReportTemplateDesc.SelectedIndex = cbReportTemplate.SelectedIndex
		End If
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
		
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		
		
		If val_fields Then
			nReport = 0
			nReport = get_seed("repdata")
			If nReport <= 0 Then
				MsgBox("Unable to get Report Number." & vbCrLf & "Report has not been generated.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
				Exit Sub
			End If
			
			set_params()
			
			GenerateRepRecycleTonGeneral(params)
			
			ReportHandler()
			
		End If
		
		
		'--------------------
		
		'params.sCustId = "ND"
		
		'params.sPeriodSeqList = "4292"
		
		
		'GenerateRepRecycleTonGeneral params
		
	End Sub
	Private Sub ReportHandler()
		
		If find_printer Then
			show_report()
		End If
		
	End Sub
	Private Sub show_report()
        Dim cmd As SqlCommand = cn.CreateCommand()
		
		On Error GoTo ErrorHandler
		
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		log_parameters(sLocalReport)
		
		
		'Verifico que se hayan cargado datos en RptRecyleTon para este reporte
        sStmt = "SELECT count(*) FROM RptRecycleTonGen WHERE report_id = " & Str(nReport)
        cmd.CommandText = sStmt
		
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsLocal.Rows.Count > 0 Then
            If rsLocal.Rows(0).Item(0) > 0 Then
                'Found records
            Else
                MsgBox("No data was generated for :" & sLocalReport & " report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If
        Else
            MsgBox("There was an error while verifying report data for:" & sLocalReport, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
		
        sStmt = "SELECT report_id, cust_id, cust_name, report_start, report_end, " & _
                      " store_number AS store_no, store_name AS location, trash_tons, " & _
                      " recycle_tons, store_total_tons, store_composting_tons," & _
                      " landfill_percent, recycle_percent " & " FROM RptRecycleTonGen " & _
                      " WHERE report_id = " & Str(nReport) & " ORDER BY store_number "
        cmd.CommandText = sStmt
        rsReport = getDataTable(sStmt) ' cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		
		'If gbDebug Then
		'DataGrid1.Visible = True
		'Set DataGrid1.DataSource = rsReport
		'End If
		
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		'Cargo la plantilla de Crystal Reports con los datos
        load_report(rsReport)
		
		Exit Sub
		
ErrorHandler: 
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		save_error(Me.Name, "show_report")
		'For Each e In cn.Errors
		'    MsgBox e.Description
		'Next
	End Sub
    Private Function load_report(ByVal dstReport As DataTable) As Boolean
        Dim sFile As String 'Path de la plantilla del reporte
        'Dim sReportTemplate As String 'Nombre de plantilla de reporte
        Dim fileTmp As Scripting.FileSystemObject
        fileTmp = New Scripting.FileSystemObject

        Dim rptDoc As ReportDocument = New ReportDocument()
        Try
            sFile = get_template(sLocalReport, cbReportTemplate.SelectedItem)
            rptDoc.Load(sFile)
        Catch ex As Exception
            MsgBox("Report template not found." & vbCrLf & "Please install: " & "rptGlmInvoice.rpt", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
        End Try

        rptDoc.SetDataSource(dstReport)

        frmRepRecycleTonGenViewer.CrystalReportViewer1.ReportSource = rptDoc
        frmRepRecycleTonGenViewer.CrystalReportViewer1.Visible = True
        frmRepRecycleTonGenViewer.CrystalReportViewer1.Show()
        frmRepRecycleTonGenViewer.Show()

        'frmRepCostContSearchViewer.CrystalReportViewer1.ReportSource = rptDoc
        'frmRepCostContSearchViewer.CrystalReportViewer1.Visible = True
        'frmRepCostContSearchViewer.CrystalReportViewer1.Show()
        'frmRepCostContSearchViewer.Show()
        Exit Function

        'On Error GoTo ErrorHandler

        ''Abro el archivo con el reporte
        'crysApp = CreateObject("Crystal.CRPE.Application")

        ''sFile = "c:\glm\Visual Basic\Glm-System\Reports\rptRecycleTon.rpt"
        'sFile = get_template(sLocalReport, cbReportTemplate.Text)

        'If fileTmp.FileExists(sFile) Then
        '    crysRepRecycleTon = crysApp.OpenReport(sFile)
        'Else
        '    sFile = get_local_template(sLocalReport)
        '    If fileTmp.FileExists(sFile) Then
        '        crysRepRecycleTon = crysApp.OpenReport(sFile)
        '    Else
        '        MsgBox("Report template not found." & vbCrLf & "Please install: " & sFile, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
        '        Exit Function
        '    End If

        'End If

        'Asignar impresora seleccionada por usuario.
        'report.SelectPrinter "HP DeskJet 550C","remota", "LPT1"
        'UPGRADE_ISSUE: Printer property Printer.Port was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'UPGRADE_ISSUE: Printer property Printer.DeviceName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'UPGRADE_ISSUE: Printer property Printer.DriverName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''crysRepRecycleTon.SelectPrinter(Printer.DriverName, Printer.DeviceName, Printer.Port)

        'reportDb = crysRepRecycleTon.Database
        'reportTables = reportDb.Tables
        'reportTable = reportTables.Item(1)
        'reportPage = crysRepRecycleTon.PageSetup




        ''reportTable.SetPrivateData 3, AdoRs
        'reportTable.SetPrivateData(3, rsReport)

        ''cd.CancelError = True
        ''cd.ShowPrinter
        ''crysRepRecycleTon.DialogParentWindow = Me
        'crysRepRecycleTon.ProgressDialogEnabled = True
        'crysRepRecycleTon.Preview()

        'ErrorHandler:
        'If Err.Number = cdlCancel Then
        '    MsgBox "usuario aborto"
        'End If
    End Function
	
	
	
	Private Sub log_parameters(ByRef sReportName As String)
		Dim sParams As String
		
		sParams = "Report parameters:" & vbCrLf
		
		sParams = sParams & " custId= " & params.sCustid
		sParams = sParams & " custName= " & params.sCustName
		sParams = sParams & " periodSeqList= " & params.sPeriodSeqList
		
		
		write_msg(sReportName, sParams)
		
	End Sub
	'To choose a printer to print
	Private Function find_printer() As Boolean
		'If there is not printers in the system
		'UPGRADE_ISSUE: Printers method Printers.Count was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'

        'solo para debug
        find_printer = True
        Exit Function

        If System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count <= 0 Then
            MsgBox("There are not printers defined in this computer." & vbCrLf & "Please set up a default printer before proceeding.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message")

            find_printer = False
            Exit Function
        End If
		
        'VB6.ShowForm(frmPrinter, VB6.FormShowConstants.Modal, Me)
        'If gbPrinter Then
        find_printer = True
        'Else
        'find_printer = False
        'End If
	End Function
	
	'Saves report parameters
	Private Sub set_params()
		Dim dump As gDumpUDT
		
		'Set Report Parameters
		params.sCustid = cbCustId.Text
		params.sPeriodSeqList = CStr(VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex))
		params.sCustName = cbCustName.Text
		params.nGroupSeq = VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex)
		'UPGRADE_WARNING: Couldn't resolve default property of object dump. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dump = getPeriodDates(VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex))
		params.sStartDate = dump.str1
		params.sEndDate = dump.str2
		
		If obRangePeriod.Checked = True Then
			params.sPeriodSeqList = getPeriodSeqList((cbCustId.Text), VB6.GetItemData(cbPeriodStart, cbPeriodStart.SelectedIndex), VB6.GetItemData(cbPeriodEnd, cbPeriodEnd.SelectedIndex))
			MsgBox(params.sPeriodSeqList)
			
		End If
		
		
	End Sub
	Private Sub frmRepRecycleTonGen_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		sLocalVersion = "DEFAULT"
		sLocalReport = gReport.name

		lbStartDate.Text = ""
		lbEndDate.Text = ""
		'UPGRADE_WARNING: TextBox property txtReportCaption.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtReportCaption.Maxlength = 30 'customer.cust_report_name CHAR(30)
		
		
		obSinglePeriod.Checked = False
		obRangePeriod.Checked = False
		obRange.Checked = False
		
		period_enable(True)
		period_range_enable(True)
		range_enable(True)
		
		
        dtStartDate.Value = Today
		dtEndDate.value = Today
		
		
		'Combo Customer
		sStmt = "SELECT cust_name, cust_id FROM customer  ORDER BY cust_name"
		load_cb_query2(cbCustName, sStmt, 1, True)
		
		sStmt = "SELECT cust_id FROM customer  ORDER BY cust_name"
		load_cb_query2(cbCustId, sStmt, 1, True)
		
		If cbCustName.Items.Count > 0 Then
			cbCustName.SelectedIndex = 0
		End If
		
		
		'Combo Report Template
		sStmt = "SELECT rep_template_name, col_order " & "FROM RepDef a, RepDefTemplate b " & " WHERE a.rep_no = b.rep_no " & " AND a.rep_caption ='" & sLocalReport & "' " & " ORDER BY col_order "
		load_cb_query2(cbReportTemplate, sStmt, 1, True)
		
		sStmt = "SELECT rep_template_desc, col_order " & "FROM RepDef a, RepDefTemplate b " & " WHERE a.rep_no = b.rep_no " & " AND a.rep_caption ='" & sLocalReport & "' " & " ORDER BY col_order "
		load_cb_query2(cbReportTemplateDesc, sStmt, 1, True)
		
		If cbReportTemplate.Items.Count > 0 Then
			cbReportTemplate.SelectedIndex = 0
		End If
		
		
		
		
	End Sub
	
	Private Function val_fields() As Boolean
		'Cust
		If cbCustName.SelectedIndex < 0 Then
			MsgBox("You must choose a customer", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
			cbCustName.Focus()
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
            If dtStartDate.Value > dtEndDate.Value Then
                MsgBox("Start Date must be less than End Date.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
                val_fields = False
                Exit Function
            End If
		End If
		
		
		val_fields = True
	End Function
	
	Private Function build_query() As Boolean
		Dim nRecords As Short
        Dim cmd As SqlCommand = cn.CreateCommand()
		'Obengo el identificador del reporte
		build_query = False
		
		nReport = 0
		nReport = get_seed("repdata")
		If nReport <= 0 Then
			MsgBox("Unable to get Report Number." & vbCrLf & "Report has not been generated.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Function
		End If
		
		'PENDIENTE 03.23.2014 -- Este INSERT debe ser hecho aqui----
		sStmt = "INSERT INTO RptRecycleTonGen ( " & " report_id, cust_id,  cust_name,  state_id, state_name, store_id," & " eqpt_id, load_id, eqpt_desc, eqpt_qty, " & " eqpt_size_capacity, invoice_no, period_seq,  vinvoice_date," & " vend_seq, content_desc, content_type, pound_factor, " & " eqpt_seq, serv_id, serv_desc, freq_period," & " freq_times, week_factor, serv_usage, frequency_mask, " & " report_start, report_end ) "
		
		sStmt = sStmt & "SELECT " & Str(nReport) & ",Customer.cust_id, " & "Customer.cust_name, Store.state_id, State.state_name, " & "Store.store_id," & "StoreEqpt.eqpt_id, StoreEqpt.load_id," & "StoreEqpt.eqpt_desc, StoreEqpt.eqpt_qty," & "StoreEqpt.eqpt_size_capacity," & "vInvoice.invoice_no, vInvoice.period_seq," & "vInvoice.vinvoice_date," & "vInvoice.vend_seq," & "Content.content_desc, Content.content_type, Content.pound_factor," & "vInvoiceDet.eqpt_seq, vInvoiceDet.serv_id, Service.serv_desc," & "vContract.freq_period, vContract.freq_times," & "Frequency.week_factor," & "vInvoiceDet.serv_usage," & "CAST(dbo.format_freq2 (Frequency.freq_sched_flag," & "Frequency.freq_times_flag, VContract.freq_times," & "ISNULL(VContract.freq_period,''), ISNULL(VContract.freq_day1,'')," & "ISNULL(VContract.freq_day2,''), ISNULL(VContract.freq_day3,'')," & "ISNULL(VContract.freq_day4,''), ISNULL(VContract.freq_day5,'')," & "ISNULL(VContract.freq_day6,''), ISNULL(VContract.freq_day7,''))  AS CHAR(60))AS frequency_mask," & "CONVERT(CHAR(10),getdate(),101) as report_start," & "CONVERT(Char(10), getdate(), 101) As report_end"
		
		sStmt = sStmt & " FROM vInvoice , vInvoiceDet , Customer , Store , StoreEqpt ," & " Content , vContract, Service, Frequency, State "
		
		sStmt = sStmt & " WHERE vInvoice.invoice_no = vInvoiceDet.invoice_no " & "AND vInvoice.cust_id = vInvoiceDet.cust_id " & "AND vInvoice.store_id = vInvoiceDet.store_id " & "AND vInvoice.account_no = vInvoiceDet.account_no " & "AND vInvoice.vend_seq = vInvoiceDet.vend_seq " & "AND vInvoice.cust_id = Customer.cust_id " & "AND vInvoice.cust_id = Store.cust_id " & "AND vInvoice.store_id = Store.store_id " & "AND Store.cust_id = StoreEqpt.cust_id " & "AND Store.store_id = StoreEqpt.store_Id " & "AND StoreEqpt.content_id = Content.content_id " & "AND StoreEqpt.eqpt_seq = vInvoiceDet.eqpt_seq  " & "AND vInvoiceDet.cust_id = VContract.cust_id " & "AND vInvoiceDet.vend_seq = vContract.vend_seq " & "AND vInvoiceDet.store_id = vContract.store_id " & "AND vInvoiceDet.eqpt_seq = vContract.eqpt_seq " & "AND vInvoiceDet.serv_id = vContract.serv_id " & "AND Service.serv_id = vInvoiceDet.serv_id " & "AND vContract.freq_id = Frequency.freq_id " & "AND Store.state_id = State.state_id " & "AND vContract.default_service ='T'  " & "AND Content.content_type = 'RECYCLE' " & "AND StoreEqpt.eqpt_status = 'A' "
		
		sStmt = sStmt & sWhere & " ORDER BY store_name"
		
		
        cmd.CommandText = sStmt
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
End Class