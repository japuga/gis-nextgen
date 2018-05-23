Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Friend Class frmRepScrapMetal3
	Inherits System.Windows.Forms.Form
	Private sLocalVersion As String
	Private sLocalReport As String
	Private Structure rptScrapMetalParamUDT
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
		Dim sFilter As String
		Dim nError As Short
	End Structure
	Private rptScrapMetalParam As rptScrapMetalParamUDT
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
	
	

	Private Sub cbPeriodEnd_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriodEnd.SelectedIndexChanged
		On Error GoTo ErrorHandler
		lbPeriodEndDate.Text = ""
		
		sStmt = "SELECT period_end_date " & " FROM period " & " WHERE cust_id ='" & Trim(cbCustId.Text) & "'" & " AND period_seq =" & Str(VB6.GetItemData(cbPeriodEnd, cbPeriodEnd.SelectedIndex))
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count > 0 Then
            lbPeriodEndDate.Text = rsLocal.Rows(0).Item("period_end_date")
        End If


        Exit Sub

ErrorHandler:
        save_error(Me.Name, "cbPeriodEnd.click")
        MsgBox("An error occurred while loading  Period Info. Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
		
	End Sub
	

	Private Sub cbPeriodName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriodName.SelectedIndexChanged
        lbStartDate.Text = ""
		lbEndDate.Text = ""
		
		sStmt = "SELECT period_start_date, period_end_date " & " FROM period " & " WHERE cust_id ='" & Trim(cbCustId.Text) & "'" & " AND period_seq =" & Str(VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex))

        Try
            rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rsLocal.Rows.Count > 0 Then

                lbStartDate.Text = rsLocal.Rows(0).Item("period_start_date")
                lbEndDate.Text = rsLocal.Rows(0).Item("period_end_date")
            End If

            Exit Sub

        Catch ex As Exception
            save_error(Me.Name, "cbPeriodName.click")
            MsgBox("An error occurred while loading  Period Info. Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
        End Try
    End Sub
	

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
		With rptScrapMetalParam
			.sCustId = cbCustId.Text
			.sStateId = cbStateId.Text '"TX"
			.nPeriodSeq = VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex) '16
			.nGroupSeq = VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex) '3
			.nPeriodStartSeq = VB6.GetItemData(cbPeriodStart, cbPeriodStart.SelectedIndex)
			.nPeriodEndSeq = VB6.GetItemData(cbPeriodEnd, cbPeriodEnd.SelectedIndex)
			.sFilter = sWhere
		End With
		If cbStateId.Text = "<All>" Then
			rptScrapMetalParam.sStateId = "All"
		End If
		
		'Period/Date Flag
		If obSinglePeriod.Checked = True Then
			rptScrapMetalParam.sPeriodSeq = "P"
			rptScrapMetalParam.nPeriodSeqFrom = 0
			rptScrapMetalParam.nPeriodSeqTo = 0
			rptScrapMetalParam.sStartDate = lbStartDate.Text
			rptScrapMetalParam.sEndDate = lbEndDate.Text
		End If
		If obRangePeriod.Checked = True Then
			rptScrapMetalParam.sPeriodSeq = "R"
			rptScrapMetalParam.nPeriodSeqFrom = VB6.GetItemData(cbPeriodStart, cbPeriodStart.SelectedIndex)
			rptScrapMetalParam.nPeriodSeqTo = VB6.GetItemData(cbPeriodEnd, cbPeriodEnd.SelectedIndex)
			rptScrapMetalParam.sStartDate = lbPeriodStartDate.Text
			rptScrapMetalParam.sEndDate = lbPeriodEndDate.Text
		End If
		If obRange.Checked = True Then
			rptScrapMetalParam.sPeriodSeq = "D"
			rptScrapMetalParam.nPeriodSeqFrom = 0
			rptScrapMetalParam.nPeriodSeqTo = 0
            rptScrapMetalParam.sStartDate = dtStartDate.Value
            rptScrapMetalParam.sEndDate = dtEndDate.Value
		End If
		
		'Caption
		If Len(txtReportCaption.Text) = 0 Then
			rptScrapMetalParam.sReportCaption = ""
		Else
			rptScrapMetalParam.sReportCaption = Trim(txtReportCaption.Text)
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
            If dtStartDate.Value > dtEndDate.Value Then
                MsgBox("Start Date must be less than End Date.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
                val_fields = False
                Exit Function
            End If
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
		
		On Error GoTo ErrorHandler
		
		'Obengo el identificador del reporte
		build_query = False
		
		nReport = 0
		nReport = get_seed("repdata")
		If nReport <= 0 Then
			MsgBox("Unable to get Report Number." & vbCrLf & "Report has not been generated.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
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

		Dim c, sec As Object
		
		On Error GoTo ErrorHandler
		
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        cmReport = cn.CreateCommand '.let_ActiveConnection(cn)
        cmReport.CommandTimeout = 1000 'gnTimeout
        cmReport.CommandType = CommandType.StoredProcedure
		'cmReport.Parameters.Refresh
		
		'get_seed se cambio a build_query
		
		
		'Se cargan los parametros dependiendo del tipo de reporte
		cmReport.CommandText = "usp_rep_scrap_metal3"

        SqlCommandBuilder.DeriveParameters(cmReport)

		cmReport.Parameters("@nReportId").Value = nReport
		cmReport.Parameters("@sCustId").Value = rptScrapMetalParam.sCustId
		cmReport.Parameters("@sStateId").Value = rptScrapMetalParam.sStateId
		cmReport.Parameters("@nGroupSeq").Value = rptScrapMetalParam.nGroupSeq
		cmReport.Parameters("@nPeriodSeq").Value = rptScrapMetalParam.nPeriodSeq
		cmReport.Parameters("@sPeriodSeq").Value = rptScrapMetalParam.sPeriodSeq
		cmReport.Parameters("@sStartDate").Value = rptScrapMetalParam.sStartDate
		cmReport.Parameters("@sEndDate").Value = rptScrapMetalParam.sEndDate
		cmReport.Parameters("@sReportCaption").Value = rptScrapMetalParam.sReportCaption
		cmReport.Parameters("@nPeriodSeqFrom").Value = rptScrapMetalParam.nPeriodSeqFrom
		cmReport.Parameters("@nPeriodSeqTo").Value = rptScrapMetalParam.nPeriodSeqTo
		cmReport.Parameters("@sFilter").Value = rptScrapMetalParam.sFilter
		cmReport.Parameters("@bInsertTonLineFlag").Value = 0
        cmReport.Parameters("@nError").Direction = ParameterDirection.Output
		
		log_report_parameters(sLocalReport, cmReport)
		
		'Ejecuto el procedure y verifico por errores
        cmReport.ExecuteNonQuery()
		
		rptScrapMetalParam.nError = cmReport.Parameters("@nError").Value
		If rptScrapMetalParam.nError <> 0 Then
			MsgBox("An error ocurred while generating report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Sub
		End If
		
		'Verifico que se hayan cargado datos en RptRecyleTon para este reporte
		sStmt = "SELECT count(*) FROM RptScrapMetal3 WHERE report_id = " & Str(nReport)
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsLocal.Rows.Count > 0 Then
            If rsLocal.Rows(0).Item(0) > 0 Then
                'Encontro registros
            Else
                MsgBox("No data was generated for :" & gReport.name & " report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If
        Else
            MsgBox("There was an error while verifying report data for:" & gReport.name, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
		
        sStmt = " SELECT * " & " FROM RptScrapMetal3 " & " WHERE report_id = " & Str(nReport) & _
                " ORDER BY store_no, store_address, vendor_name, " & " account_desc, invoice_desc, eqpt_mask, " & " content_desc DESC, eqpt_freq, serv_desc "
		
        rsReport = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		
		If gbDebug Then
			'DataGrid1.Visible = True
			DataGrid1.DataSource = rsReport
		End If
		
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		'Cargo la plantilla de Crystal Reports con los datos
		load_report()
		
		Exit Sub
		
ErrorHandler: 
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        MsgBox("Unexpected Error while trying to load report.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
		save_error(Me.Name, "show_report2")
		
	End Sub
	
	Private Function load_report() As Boolean
        Dim sFile As String 'Path de la plantilla del reporte
        'Dim sReportTemplate As String 'Nombre de plantilla de reporte
        Dim fileTmp As Scripting.FileSystemObject
        fileTmp = New Scripting.FileSystemObject

        'On Error GoTo ErrorHandler

        'Abro el archivo con el reporte


        'sFile = "c:\glm\Visual Basic\Glm-System\Reports\rptScrapMetal.rpt"
        sFile = get_template(sLocalReport, cbReportTemplate.Text)

        Dim rptDoc As ReportDocument = New ReportDocument()
        If fileTmp.FileExists(sFile) Then
            rptDoc.Load(sFile)
        Else
            MsgBox("Report template not found." & vbCrLf & "Please install: " & sFile, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
            Exit Function
        End If

        rptDoc.SetDataSource(rsReport)

        frmRepScrapMetal3Viewer.CrystalReportViewer1.ReportSource = rptDoc
        frmRepScrapMetal3Viewer.CrystalReportViewer1.Visible = True
        frmRepScrapMetal3Viewer.CrystalReportViewer1.Show()
        frmRepScrapMetal3Viewer.Show()

        'Asignar impresora seleccionada por usuario.
        'report.SelectPrinter "HP DeskJet 550C","remota", "LPT1"
        'crysRepRecycleTon.SelectPrinter(Printer.DriverName, Printer.DeviceName, Printer.Port)

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
	
	
	Private Sub frmRepScrapMetal3_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	Private Sub init_vars()
		sLocalVersion = "DEFAULT"
		sLocalReport = gReport.name
		
        rsLocal = Nothing
        rsReport = Nothing
		
		lbStartDate.Text = ""
		lbEndDate.Text = ""

		txtReportCaption.Maxlength = 30 'customer.cust_report_name CHAR(30)
		DataGrid1.Visible = False
		
		obSinglePeriod.Checked = False
		obRangePeriod.Checked = False
		obRange.Checked = False
		
		period_enable(True)
		period_range_enable(True)
		range_enable(True)
		
		
		dtStartDate.value = Today
		dtEndDate.value = Today
		
		'Combo Customer
		sStmt = "SELECT cust_name, cust_id FROM customer  ORDER BY cust_name"
		load_cb_query2(cbCustName, sStmt, 1, True)
		
		sStmt = "SELECT cust_id FROM customer  ORDER BY cust_name"
		load_cb_query2(cbCustId, sStmt, 1, True)
		
		If cbCustName.Items.Count > 0 Then
            cbCustName.SelectedIndex = 0
		End If
		
        'Combo State
        cbStateId.Items.Clear()
		cbStateId.Items.Insert(0, "<All>")
		
		sStmt = "SELECT state_id FROM state"
		load_cb_query2(cbStateId, sStmt, 1, False)
		
		If cbStateId.SelectedIndex Then
			cbStateId.SelectedIndex = 0
		End If
		
		load_template(cbReportTemplate, sLocalReport)
		
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
End Class