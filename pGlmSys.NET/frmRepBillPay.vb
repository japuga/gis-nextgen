Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Friend Class frmRepBillPay
	Inherits System.Windows.Forms.Form
	Private sLocalVersion As String
	Private sLocalReport As String
	Private Structure rptBillPayParamUDT
		Dim sCustId As String
		Dim sStateId As String
		Dim nGroupSeq As Short
		Dim nPeriodSeq As Short
		Dim bPeriodSeq As Boolean
		Dim sStartDate As String
		Dim sEndDate As String
		Dim sReportCaption As String
		Dim bFinalFlag As Boolean
		Dim nError As Short
	End Structure
	Private rptBillPayParam As rptBillPayParamUDT
    Private rsLocal As DataTable
	'--------Crystal Reports-----------------
    Private rsReport As DataTable
	
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
	
	'UPGRADE_WARNING: Event cbPeriodName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbPeriodName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriodName.SelectedIndexChanged
		
		On Error GoTo ErrorHandler
		lbStartDate.Text = ""
		lbEndDate.Text = ""
		
		sStmt = "SELECT period_start_date, period_end_date " & " FROM period " & " WHERE cust_id ='" & Trim(cbCustId.Text) & "'" & " AND period_seq =" & Str(VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex))
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.rows.count > 0 Then
            lbStartDate.Text = rsLocal.Rows(0).Item("period_start_date")
            lbEndDate.Text = rsLocal.Rows(0).Item("period_end_date")
        End If

        Exit Sub

ErrorHandler:
        save_error(Me.Name, "cbPeriodName.click")
        MsgBox("An error occurred while loading  Period Info. Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
		
	End Sub
	
	'UPGRADE_WARNING: Event ckFinal.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub ckFinal_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ckFinal.CheckStateChanged
		
		If ckFinal.CheckState = System.Windows.Forms.CheckState.Checked Then
			MsgBox("This option will close the Billing Period", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Warning")
		End If
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If val_fields = False Then
			Exit Sub
		End If
		
		'Se asigna parametros del reporte
		With rptBillPayParam
			.sCustId = cbCustId.Text
			.sStateId = cbStateId.Text '"TX"
			.nPeriodSeq = VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex) '16
			.nGroupSeq = VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex) '3
			.bPeriodSeq = obPeriod.Checked 'True
            .sStartDate = dtStartDate.Value '"01/01/2003"
            .sEndDate = dtEndDate.Value ' "01/31/2003"
		End With
		If cbStateId.Text = "<All>" Then
			rptBillPayParam.sStateId = "All"
		End If
		
		If Len(txtReportCaption.Text) = 0 Then
			rptBillPayParam.sReportCaption = ""
		Else
			rptBillPayParam.sReportCaption = txtReportCaption.Text
		End If
		
		
		ReportHandler2()
		
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
		
		'obPeriod
		If obPeriod.Checked = False And obRange.Checked = False Then
			MsgBox(" You must select and Invoicing Period or Date Range")
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
		
		'obRange
		If obRange.Checked = True Then
            If dtStartDate.Value > dtEndDate.Value Then
                MsgBox("Start Date must be less than End Date.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
                val_fields = False
                Exit Function
            End If
		End If
		
		If ckFinal.CheckState = System.Windows.Forms.CheckState.Checked Then
			rptBillPayParam.bFinalFlag = True
		Else
			rptBillPayParam.bFinalFlag = False
		End If
		
		val_fields = True
	End Function
	
	Private Sub ReportHandler()
		Dim bPrinter As Boolean
		
		'Chequea que exista impresora por defecto
		'UPGRADE_ISSUE: Printers method Printers.Count was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count = 0 Then
            bPrinter = False
        Else
            bPrinter = True
            util_printer_options(True)
        End If
		
		If bPrinter Then
			'Seleccionar impresora
			If find_printer Then
				'Version para soporte a Crystal Reports
				show_report2()
			End If
		Else
			MsgBox("There is not default printer specified.Aborting", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Sub
		End If
		
		'Se restauran defaults
		If bPrinter Then
			util_printer_options(False)
		End If
		
	End Sub
    Private Function ReportHandler2() As Boolean
        ReportHandler2 = False

        'Seleccionar impresora
        'If find_printer() Then
        'Version para soporte a Crystal Reports
        show_report2()
        'End If

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
	'2.-Ejecuta el store procedure para cargar RepData o rptBillPayment
	'3.-Verifica que se haya ejecutado, que hayan datos en RepData
	'4.-Mapea campos de RepData con los definidos en RepCust
	'5.-Muestra el reporte
	Private Sub show_report2()

        ' Dim sec As Object
		
		'On Error GoTo ErrorHandler
		
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
		
		
		'Se cargan los parametros dependiendo del tipo de reporte
        cmReport.CommandText = "usp_rep_bill_pay"
        SqlCommandBuilder.DeriveParameters(cmReport)
		cmReport.Parameters("@nReportId").Value = nReport
		cmReport.Parameters("@sCustId").Value = rptBillPayParam.sCustId
		cmReport.Parameters("@sStateId").Value = rptBillPayParam.sStateId
		cmReport.Parameters("@nGroupSeq").Value = rptBillPayParam.nGroupSeq
		cmReport.Parameters("@nPeriodSeq").Value = rptBillPayParam.nPeriodSeq
		If rptBillPayParam.bPeriodSeq Then
			cmReport.Parameters("@sPeriodSeq").Value = "T"
			cmReport.Parameters("@sStartDate").Value = Today
			cmReport.Parameters("@sEndDate").Value = Today
		Else
			cmReport.Parameters("@sPeriodSeq").Value = "F"
			cmReport.Parameters("@sStartDate").Value = rptBillPayParam.sStartDate
			cmReport.Parameters("@sEndDate").Value = rptBillPayParam.sEndDate
		End If
		cmReport.Parameters("@sReportCaption").Value = rptBillPayParam.sReportCaption
		
		
		If rptBillPayParam.bFinalFlag Then
			cmReport.Parameters("@sFinalFlag").Value = "TRUE"
		Else
			cmReport.Parameters("@sFinalFlag").Value = "FALSE"
		End If
		
		
		log_report_parameters(sLocalReport, cmReport)
		
        'Ejecuto el procedure y verifico por errores
        cmReport.Parameters("@nError").Direction = ParameterDirection.Output
        cmReport.CommandTimeout = 300

        cmReport.ExecuteNonQuery()
		
		rptBillPayParam.nError = cmReport.Parameters("@nError").Value
		If rptBillPayParam.nError <> 0 Then
			MsgBox("An error ocurred while generating report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Sub
		End If
		
		'Verifico que se hayan cargado datos en RepData para este reporte
		sStmt = "SELECT count(*) FROM rptBillPayment WHERE report_no = " & Str(nReport)
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows(0).Item(0) > 0 Then
            'Encontro registros
        Else
            MsgBox("No data was generated for :" & gReport.name & " report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
        'Else
        '      MsgBox("There was an error while verifying report data for:" & gReport.name, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
        '      'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '      System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '      Exit Sub

        sStmt = "SELECT report_no, cust_id, cust_name, " & _
            "CONVERT(varchar, report_start, 101) report_start, CONVERT(varchar, report_end, 101) report_end, store_no, location,  " & _
            "RTRIM(vendor) vendor, account_no , invoice_no," & "invoice_date, amount, " & _
            "taxes, total_amount, comment, sum_amount, sum_taxes," & _
            " sum_total_amount, check_amount, check_no, check_date, status, store_name, card_auth  " & _
            "FROM rptBillPayment " & "WHERE report_no = " & Str(nReport) & " " & _
            "ORDER BY cust_id, store_no, location, vendor, account_no, invoice_no "

        rsReport = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        'Cargo la plantilla de Crystal Reports con los datos
        load_report(rsReport)

        'Close the period
        If ckFinal.CheckState = System.Windows.Forms.CheckState.Checked And obPeriod.Checked = True Then
            close_period(cbCustId.Text, VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex))
        End If

        Exit Sub

ErrorHandler:
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        save_error(Me.Name, "show_report2")

        'MsgBox(e.Description)

	End Sub
	
    Private Function load_report(ByVal dstReport As DataTable) As Boolean
        
        Dim sFile As String 'Path de la plantilla del reporte
        'Dim sReportTemplate As String 'Nombre de plantilla de reporte
        Dim fileTmp As Scripting.FileSystemObject
        fileTmp = New Scripting.FileSystemObject

        sFile = Nothing
        'On Error GoTo ErrorHandler

        Dim rptDoc As ReportDocument = New ReportDocument()
        Try
            'sFile = "c:\glm\Visual Basic\Glm-System\Reports\rptBillPay.rpt"
            sFile = get_template(sLocalReport, cbReportTemplate.Text)
            'rptDoc.Load(strReportsSysPath & "rptBillPay.rpt")
            rptDoc.Load(sFile)
        Catch ex As Exception
            MsgBox("Report template not found." & vbCrLf & "Please install: " & sFile, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
            Exit Function
        End Try

        rptDoc.SetDataSource(dstReport)

        frmRepBillPayViewer.CrystalReportViewer1.ReportSource = rptDoc
        frmRepBillPayViewer.CrystalReportViewer1.Visible = True
        frmRepBillPayViewer.CrystalReportViewer1.Show()
        frmRepBillPayViewer.Show()

        'frmRepRecycleTonGenViewer.CrystalReportViewer1.ReportSource = rptDoc
        'frmRepRecycleTonGenViewer.CrystalReportViewer1.Visible = True
        'frmRepRecycleTonGenViewer.CrystalReportViewer1.Show()
        'frmRepRecycleTonGenViewer.Show()
        Exit Function

        'Asignar impresora seleccionada por usuario.
        'report.SelectPrinter "HP DeskJet 550C","remota", "LPT1"

        'crysRepBillPay.SelectPrinter(Printer.DriverName, Printer.DeviceName, Printer.Port)

       
    End Function
	
	
	Private Sub frmRepBillPay_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	Private Sub init_vars()
		sLocalVersion = "DEFAULT"
		sLocalReport = "Bill Payment Report"
		
		lbStartDate.Text = ""
		lbEndDate.Text = ""
		'UPGRADE_WARNING: TextBox property txtReportCaption.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtReportCaption.Maxlength = 30 'customer.cust_report_name CHAR(30)
		
		obPeriod.Checked = False
		obRange.Checked = False
		period_enable(False)
		range_enable(False)
		
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
		
        'Combo State
        cbStateId.Items.Clear()
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
		
		ckFinal.CheckState = System.Windows.Forms.CheckState.Unchecked
		
	End Sub
	
	Private Sub period_enable(ByRef bOption As Boolean)
		cbPeriodName.Enabled = bOption
		ckFinal.Enabled = bOption
	End Sub
	Private Sub range_enable(ByRef bOption As Boolean)
		dtStartDate.Enabled = bOption
		dtEndDate.Enabled = bOption
	End Sub
	
	'UPGRADE_WARNING: Event obPeriod.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub obPeriod_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles obPeriod.CheckedChanged
		If eventSender.Checked Then
			If obPeriod.Checked = True Then
				range_enable(False)
				period_enable(True)
			End If
		End If
	End Sub
	
	'UPGRADE_WARNING: Event obRange.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub obRange_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles obRange.CheckedChanged
		If eventSender.Checked Then
			If obRange.Checked = True Then
				range_enable(True)
				period_enable(False)
			End If
			
		End If
	End Sub
End Class