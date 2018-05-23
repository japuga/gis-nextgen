Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Friend Class frmRepGlmInvoice
	Inherits System.Windows.Forms.Form
	Private sLocalVersion As String
	Private sLocalReport As String
	Private Structure rptGlmInvoiceParamUDT
		Dim sCustId As String
		Dim sStateId As String
		Dim nGroupSeq As Short
		Dim sGroupSeqList As String
		Dim nPeriodSeq As Short
		Dim bPeriodSeq As Boolean
		Dim sStartDate As String
		Dim sEndDate As String
		Dim sReportCaption As String
		Dim nError As Short
	End Structure
	Private rptGlmInvoiceParam As rptGlmInvoiceParamUDT
    Private rsLocal As DataTable
	Private PARAM_GROUP_SEQ As String
	Private nInstanceNo As Integer
	
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
		
		cbGroupName.Items.Clear()
		cbGroupName.Items.Insert(0, UI_SELECTED_VALUES)
		
		load_cb_query2(cbGroupName, sStmt, 2, False)
		
		
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
	
	'UPGRADE_WARNING: Event cbGroupName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbGroupName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbGroupName.SelectedIndexChanged
		'<Selected Values>
		If cbGroupName.SelectedIndex = 0 Then
			cmdSelectValues.Enabled = True
			set_grid_selector()
		Else
			cmdSelectValues.Enabled = False
			
		End If
		
	End Sub
	
	Private Sub set_grid_selector()
		
		clear_gItplGridSelector()
		
		gItplGridSelector.sInvokeFromForm = Me.Name
		
		'Init
		'gItplGridSelector.sQueryInit = build_query_init
		'Left
		gItplGridSelector.sQuerySource = build_query_left
		
		'Right
		gItplGridSelector.sQuerySelected = build_query_right
		
		gItplGridSelector.sOrderBy = "Group"
		
		
		'Formato
		'gItplGridSelector.aFields(0).sFieldName = "id"
		'gItplGridSelector.aFields(0).bVisible = True
		'gItplGridSelector.aFields(0).nWidth = 500
		
		
		gItplGridSelector.aFields(0).sFieldName = "group_seq"
		gItplGridSelector.aFields(0).bVisible = False
		gItplGridSelector.aFields(0).nWidth = 500
		
		gItplGridSelector.aFields(1).sFieldName = "Group"
		gItplGridSelector.aFields(1).bVisible = True
		gItplGridSelector.aFields(1).nWidth = 2000
		
		
		gItplGridSelector.sLeftCaption = "Available Groups"
		gItplGridSelector.sRightCaption = "Selected Groups"
		
		
	End Sub
	
	Private Function build_query_init() As String
		build_query_init = " SELECT group_seq, " & " group_name AS Group " & " FROM Groups  " & " WHERE cust_id = '' " & " AND type_id = 'LOCAL' " & " ORDER BY group_name DESC "
		
		
		
	End Function
	Private Function build_query_left() As String
		
		'build_query_left = _
		'" SELECT " + Str(nInstanceNo) + " AS id, group_seq, " + _
		'" group_name AS 'Group' " + _
		'" FROM Groups  " + _
		'" WHERE cust_id = '" + cbCustId.Text + "' " + _
		'" AND type_id = 'LOCAL' " + _
		'" AND group_seq NOT IN (SELECT param_seq FROM rptCriteriaDet WHERE param_name='" + PARAM_GROUP_SEQ + "' AND id =" + Str(nInstanceNo) + ")" + _
		'" ORDER BY group_name DESC "
		build_query_left = " SELECT group_seq, " & " group_name AS 'Group' " & " FROM Groups  " & " WHERE cust_id = '" & cbCustId.Text & "' " & " AND type_id = 'LOCAL' " & " AND group_seq NOT IN (SELECT param_seq FROM rptCriteriaDet WHERE param_name='" & PARAM_GROUP_SEQ & "' AND id =" & Str(nInstanceNo) & ")" & " ORDER BY group_name DESC "
		
		
		
	End Function
	
	Private Function build_query_right() As String
		'build_query_right = _
		'"SELECT  id, param_seq as 'group_seq', param_value AS 'Group' FROM RptCriteriaDet " + _
		'" WHERE id = " + Str(nInstanceNo) + _
		'" AND param_name = '" + PARAM_GROUP_SEQ + "' "
		build_query_right = "SELECT  param_seq as 'group_seq', param_value AS 'Group' FROM RptCriteriaDet " & " WHERE id = " & Str(nInstanceNo) & " AND param_name = '" & PARAM_GROUP_SEQ & "' "
		
		
		
	End Function
    Private Sub cbPeriodName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriodName.SelectedIndexChanged

        On Error GoTo ErrorHandler
        lbStartDate.Text = ""
        lbEndDate.Text = ""

        sStmt = "SELECT period_start_date, period_end_date " & " FROM period " & " WHERE cust_id ='" & Trim(cbCustId.Text) & "'" & " AND period_seq =" & Str(VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex))

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
	
	'UPGRADE_WARNING: Event cbReportTemplate.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbReportTemplate_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbReportTemplate.SelectedIndexChanged
		If cbReportTemplate.Text = SYS_GIR_GLMRATE_AUDIT Then
			ckUseGlmRate.CheckState = System.Windows.Forms.CheckState.Unchecked
			ckUseGlmRate.Enabled = False
		Else
			ckUseGlmRate.Enabled = True
		End If
		
	End Sub
	
	'UPGRADE_WARNING: Event cbReportTemplateDesc.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbReportTemplateDesc_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbReportTemplateDesc.SelectedIndexChanged
		If cbReportTemplateDesc.SelectedIndex >= 0 Then
			cbReportTemplate.SelectedIndex = cbReportTemplateDesc.SelectedIndex
		End If
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		Dim sReportTemplate As String
		
		If val_fields = False Then
			Exit Sub
		End If
		
		'Se asigna parametros del reporte
		With rptGlmInvoiceParam
			.sCustId = cbCustId.Text
			.sStateId = cbStateId.Text '"TX"
			.nPeriodSeq = VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex) '16
			.nGroupSeq = VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex)
			.bPeriodSeq = obPeriod.Checked 'True
            .sStartDate = dtStartDate.Value '"01/01/2003"
            .sEndDate = dtEndDate.Value ' "01/31/2003"
		End With
		
		Dim sGroupSeq As String
		If cbGroupName.SelectedIndex = 0 And countOfDetails > 0 Then
			sGroupSeq = ""

            For row As Integer = 0 To gItplGridSelector.rsResult.Rows.Count - 1
                sGroupSeq = sGroupSeq & Str(gItplGridSelector.rsResult.Rows(row).Item("group_seq")) & ","
            Next row
            
            rptGlmInvoiceParam.sGroupSeqList = VB.Left(sGroupSeq, Len(sGroupSeq) - 1)
            'MsgBox rptGlmInvoiceParam.sGroupSeqList

        End If
		
		If cbStateId.Text = "<All>" Then
			rptGlmInvoiceParam.sStateId = "All"
		End If
		
		If Len(txtReportCaption.Text) = 0 Then
			rptGlmInvoiceParam.sReportCaption = ""
		Else
			rptGlmInvoiceParam.sReportCaption = Trim(txtReportCaption.Text)
		End If
		
		'ReportHandler2
		If ckPublish.CheckState = System.Windows.Forms.CheckState.Checked Then
			sReportTemplate = cbReportTemplate.Text
			If Not publish_report(cbCustId.Text, txtReportName.Text, sReportTemplate, Me.Name, sLocalReport) Then
				MsgBox("Cancelling report job.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
				Exit Sub
			End If
		End If
		
		
		ReportHandler2()
		
		If ckPublish.CheckState = System.Windows.Forms.CheckState.Checked Then
			update_publish_report(cbCustId.Text, txtReportName.Text, nReport)
		End If
		
		
		'If ckUseForBilling = vbChecked Then
		
		save_glminvoice_report_criteria_wrapper()
		
		'End If
		
		
		
		
	End Sub
	'Gathers all report parameters and saves them in rptCriteriaGlmInvoice  table
	Private Sub save_glminvoice_report_criteria_wrapper()
		
		Dim nRepNo As Short
		Dim sIsPeriodSeq As String
		Dim sDisplayStoreWithInvoices As String
		Dim sPublishToWeb As String
		Dim sUseForCustomerBilling As String
		Dim nReportFinal As Integer
		Dim sIsFinalVersion As String
		
		nRepNo = CShort(getRepNo(sLocalReport))
		
		If obPeriod.Checked = True Then
			sIsPeriodSeq = "TRUE"
		Else
			sIsPeriodSeq = "FALSE"
		End If
		
		
		If ckJustInvoice.CheckState = System.Windows.Forms.CheckState.Checked Then
			sDisplayStoreWithInvoices = "TRUE"
		Else
			sDisplayStoreWithInvoices = "FALSE"
		End If
		
		If ckPublish.CheckState = System.Windows.Forms.CheckState.Checked Then
			sPublishToWeb = "TRUE"
		Else
			sPublishToWeb = "FALSE"
		End If
		
		If ckUseForBilling.CheckState = System.Windows.Forms.CheckState.Checked Then
			sUseForCustomerBilling = "TRUE"
		Else
			sUseForCustomerBilling = "FALSE"
		End If
		
		If ckPrintFinal.CheckState = System.Windows.Forms.CheckState.Checked Then
			sIsFinalVersion = "TRUE"
		Else
			sIsFinalVersion = "FALSE"
		End If
		
		If ckUseForBilling.CheckState = System.Windows.Forms.CheckState.Checked Then
            save_glminvoice_report_criteria((cbCustId.Text), nRepNo, nReport, rptGlmInvoiceParam.sStateId, VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex), (cbReportTemplate.Text), txtReportCaption.Text, sIsPeriodSeq, VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex), dtStartDate.Value, dtEndDate.Value, sDisplayStoreWithInvoices, sPublishToWeb, (txtReportName.Text), sUseForCustomerBilling, nInstanceNo, sIsFinalVersion)
		Else
			'Find existing report
			nReportFinal = getGIRFinalVersion((cbCustId.Text), VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex), VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex))
			
            insert_glminvoice_report_criteria((cbCustId.Text), nRepNo, nReport, rptGlmInvoiceParam.sStateId, VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex), (cbReportTemplate.Text), (txtReportCaption.Text), sIsPeriodSeq, VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex), dtStartDate.Value, dtEndDate.Value, sDisplayStoreWithInvoices, sPublishToWeb, (txtReportName.Text), sUseForCustomerBilling, nInstanceNo, sIsFinalVersion)
			
			
			If Me.ckPrintFinal.CheckState = System.Windows.Forms.CheckState.Checked Then
				
				exec_copy_repGlmInvoice(nReportFinal)
				
			End If
			
			'Generate a new ID since current was yet consumed
			nInstanceNo = get_seed("rptCriteriaGlmInvoice")
		End If
		
		
	End Sub
	'Verify that parameters are correct
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
				'ok
			Else
				If cbGroupName.SelectedIndex = 0 And countOfDetails > 0 Then
					'ok
				Else
					
					MsgBox("Unable to get Store Group info", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
					cbGroupName.Focus()
					val_fields = False
					Exit Function
					
				End If
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
		
		If ckPublish.CheckState = System.Windows.Forms.CheckState.Checked Then
			If Trim(txtReportName.Text) = "" Then
				MsgBox("Please enter Report Name to publish on the web.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
				val_fields = False
				txtReportName.Focus()
				Exit Function
			End If
		End If
		
		'UseForBilling and PrintFinalVersion cannot be checked at the same time
		'this is to minimize checks on one report for both responsabilities: Billing and LF web printing
		'This specially a problem when the report marked for Billing has
		'already been used to generate the Customer Invoice
		If Me.ckUseForBilling.CheckState = System.Windows.Forms.CheckState.Checked And Me.ckPrintFinal.CheckState = System.Windows.Forms.CheckState.Checked Then
			MsgBox("Cannot mark the report for both: Use For Customer Billing and Final Version. " & vbCrLf & "Uncheck one of the options to continue", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Error")
			val_fields = False
			ckUseForBilling.Focus()
			Exit Function
		End If
		
		
		val_fields = True
		
		
		
	End Function
	
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
	
	Private Function get_instance_no() As Integer
		
		nInstanceNo = 0
		nInstanceNo = get_seed("RptCriteriaGlmInvoice")
		
		get_instance_no = nInstanceNo
		
		If nInstanceNo <= 0 Then
			MsgBox("Unable to get Instance Number." & vbCrLf, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
			
			Exit Function
		End If
		
	End Function
	
	
	'Rel1.3.2 Extended from show_report to handle reports in Crystal Reports.
	'1.-Get report seed (get_seed)
	'2.-Execute stored procedure to load RepData
	'3.-Verify execution  and data in RepData
	'4.-Map fields between RepData and RepCust
	'5.-Show report
	Private Sub show_report2()

        'Dim c, sec As Object
        Dim sOrder As String = ""
		
		'On Error GoTo ErrorHandler
		
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		cmReport.CommandTimeout = gnTimeout
		
        cmReport = cn.CreateCommand '.let_ActiveConnection(cn)
        cmReport.CommandType = CommandType.StoredProcedure
        'cmReport.Parameters.Refresh()
		
		'Obengo el identificador del reporte
		'nReport = 0
		'nReport = get_seed("repdata")
		'If nReport <= 0 Then
		'    MsgBox "Unable to get Report Number." + vbCrLf + _
		''           "Report has not been generated.", vbCritical + vbOKOnly, "GLM Error"
		'    Exit Sub
		'End If
		'nReport = get_report_no
		nReport = get_report_id
		
		If nReport <= 0 Then
			Exit Sub
		End If
		
		
		'Se cargan los parametros dependiendo del tipo de reporte
		If ckJustInvoice.CheckState = System.Windows.Forms.CheckState.Checked Then
			cmReport.CommandText = "usp_rep_glm_invoice"
		Else
			cmReport.CommandText = "usp_rep_glm_invoice_outer"
		End If
		
		
		
        SqlCommandBuilder.DeriveParameters(cmReport)
		cmReport.Parameters("@nReportId").Value = nReport
		cmReport.Parameters("@sCustId").Value = rptGlmInvoiceParam.sCustId
		cmReport.Parameters("@sStateId").Value = rptGlmInvoiceParam.sStateId
		cmReport.Parameters("@nGroupSeq").Value = rptGlmInvoiceParam.nGroupSeq
		
		cmReport.Parameters("@nPeriodSeq").Value = rptGlmInvoiceParam.nPeriodSeq
		If rptGlmInvoiceParam.bPeriodSeq Then
			cmReport.Parameters("@sPeriodSeq").Value = "T"
			cmReport.Parameters("@sStartDate").Value = Today
			cmReport.Parameters("@sEndDate").Value = Today
		Else
			cmReport.Parameters("@sPeriodSeq").Value = "F"
			cmReport.Parameters("@sStartDate").Value = rptGlmInvoiceParam.sStartDate
			cmReport.Parameters("@sEndDate").Value = rptGlmInvoiceParam.sEndDate
		End If
		
		cmReport.Parameters("@sReportCaption").Value = rptGlmInvoiceParam.sReportCaption
		
		If ckUseGlmRate.CheckState = System.Windows.Forms.CheckState.Checked Then
			cmReport.Parameters("@sUseGlmRate").Value = "T"
		Else
			cmReport.Parameters("@sUseGlmRate").Value = "F"
		End If
		
		If ckGlmVendor.CheckState = System.Windows.Forms.CheckState.Checked Then
			cmReport.Parameters("@sGlmAsVendor").Value = "T"
		Else
			cmReport.Parameters("@sGlmAsVendor").Value = "F"
		End If
		
		cmReport.Parameters("@sReportTemplate").value = cbReportTemplate.Text

        If Not IsNothing(rptGlmInvoiceParam.sGroupSeqList) Then
            cmReport.Parameters("@sGroupSeqList").Value = rptGlmInvoiceParam.sGroupSeqList
        Else
            cmReport.Parameters("@sGroupSeqList").Value = "NULL"
        End If
        cmReport.Parameters("@nError").Direction = ParameterDirection.Output

        log_report_parameters(sLocalReport, cmReport)

        'SqlCommandBuilder.DeriveParameters(cmReport)
        'Ejecuto el procedure y verifico por errores
        cmReport.ExecuteNonQuery()

        rptGlmInvoiceParam.nError = cmReport.Parameters("@nError").Value
        If rptGlmInvoiceParam.nError <> 0 Then
            MsgBox("An error ocurred while generating report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Sub
        End If

        'Verifico que se hayan cargado datos en RepData para este reporte
        sStmt = "SELECT count(*) FROM rptGlmInvoice WHERE report_id = " & Str(nReport)

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

        sStmt = "SELECT * " & "FROM rptGlmInvoice " & "WHERE report_id = " & Str(nReport)

        sStmt = "SELECT report_id, cust_id, LTRIM(RTRIM(cust_name)), " & "report_start, report_end, store_no, location,  " & "invoice," & "savings, savings_percent, " & "savings_flat_fee, savings_invoice_fee," & "invoice_total ,amount_due, " & "sum_savings, sum_amount_due, " & "percent_value, store_name, store_city, state_id, store_number, " & "group_name, period_name, store_address, store_invoice_total, store_savings_invoice_fee, " & "store_savings_flat_fee, store_savings_percent, store_savings, store_amount_due, " & "glmrate_savings, sum_glmrate_savings, glm_total, sc, extc " & "FROM rptGlmInvoice " & "WHERE report_id = " & Str(nReport) & " ORDER BY store_no "



        sStmt = sStmt & sOrder

        rsReport = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        'Cargo la plantilla de Crystal Reports con los datos
        'CrystalDecisions.CrystalReports.Engine

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
        Dim rptDoc As ReportDocument = New ReportDocument()

        'On Error GoTo ErrorHandler

        'Abro el archivo con el reporte


        'sFile = "c:\glm\Visual Basic\Glm-System\Reports\rptGlmInvoice.rpt"
        sFile = "C:\glm\gis-vb2013\gis-master\reports\rptGlmInvoice.rpt"
        'sFile = get_template(sLocalReport, cbReportTemplate.Text)
        Try
            'rptDoc.Load(strReportsSysPath & "rptGlmInvoice.rpt")
            rptDoc.Load(sFile)
        Catch ex As Exception
            MsgBox("Err: " & ex.Message & vbCrLf & "Please install: " & "rptGlmInvoice.rpt", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
            Exit Function
        End Try
        'MsgBox("Report loaded OK so far after try.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Info")
        rptDoc.SetDataSource(rsReport)

        frmRepGlmInvoiceViewer.CrystalReportViewer1.ReportSource = rptDoc
        frmRepGlmInvoiceViewer.CrystalReportViewer1.Visible = True
        frmRepGlmInvoiceViewer.CrystalReportViewer1.Show()
        frmRepGlmInvoiceViewer.Show()
        Exit Function

        'Asignar impresora seleccionada por usuario.
        'report.SelectPrinter "HP DeskJet 550C","remota", "LPT1"
        'UPGRADE_ISSUE: Printer property Printer.Port was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'UPGRADE_ISSUE: Printer property Printer.DeviceName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'UPGRADE_ISSUE: Printer property Printer.DriverName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'crysRepGlmInvoice.SelectPrinter(Printer.DriverName, Printer.DeviceName, Printer.Port)



        'reportTable.SetPrivateData 3, AdoRs
        'reportTable.SetPrivateData(3, rsReport)

        'cd.CancelError = True
        'cd.ShowPrinter

        'ErrorHandler:
        'If Err.Number = cdlCancel Then
        '    MsgBox "usuario aborto"
        'End If
    End Function
	
	
	Private Sub cmdSelectValues_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelectValues.Click
		
		Dim nRecords As Short
        Dim nTran As SqlTransaction
		
		On Error GoTo ErrorHandler
		
		VB6.ShowForm(tplGridSelector, VB6.FormShowConstants.Modal, Me)
		
		If gItplGridSelector.bFlag = True Then
			
			
			
            nTran = cn.BeginTransaction()
            cm = cn.CreateCommand '.let_ActiveConnection(cn)
            cm.CommandType = CommandType.Text

			sStmt = "DELETE FROM rptCriteriaDet WHERE id = " & Str(nInstanceNo)
			
            cm.CommandText = sStmt
            cm.Transaction = nTran
            nRecords = cm.ExecuteNonQuery()
            For row As Integer = 0 To gItplGridSelector.rsResult.Rows.Count - 1
                sStmt = "INSERT INTO rptCriteriaDet (id, param_name, param_value, param_seq)" & _
                        " VALUES(" & Str(nInstanceNo) & "," & "'" & PARAM_GROUP_SEQ & "'," & "'" & Trim(gItplGridSelector.rsResult.Rows(row).Item("Group")) & "', " & _
                        Str(gItplGridSelector.rsResult.Rows(row).Item("group_seq")) & ")"

                cm.CommandText = sStmt
                nRecords = cm.ExecuteNonQuery()

            Next row
            nTran.Commit()

        End If
		
		Exit Sub
		
ErrorHandler: 
        If Not IsNothing(nTran) Then
            nTran.Rollback()
        End If

        save_error(Me.Name, "cmdSelectValues")
        MsgBox("An unexpected error occurred when saving report Criteria." & vbCrLf & "Check logfile for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")


    End Sub
	
	Private Sub frmRepGlmInvoice_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	Private Sub init_vars()
		sLocalVersion = "DEFAULT"
		'sLocalReport = "GLM Invoice Report"
		sLocalReport = RPT_GLM_INVOICE_REPORT
		
        rsLocal = Nothing
        rsReport = Nothing
		
		ckJustInvoice.CheckState = System.Windows.Forms.CheckState.Unchecked
		ckUseForBilling.CheckState = System.Windows.Forms.CheckState.Unchecked
		
		
		lbStartDate.Text = ""
		lbEndDate.Text = ""
        txtReportCaption.MaxLength = 30 'customer.cust_report_name CHAR(30)
		
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
		
		sStmt = "SELECT rep_template_desc, col_order " & "FROM RepDef a, RepDefTemplate b " & " WHERE a.rep_no = b.rep_no " & " AND a.rep_caption ='" & sLocalReport & "' " & " ORDER BY col_order "
		load_cb_query2(cbReportTemplateDesc, sStmt, 1, True)
		
		If cbReportTemplateDesc.Items.Count > 0 Then
			cbReportTemplateDesc.SelectedIndex = 0
		End If
		
		'Get screen instance number
		nInstanceNo = get_instance_no
		cmdSelectValues.Enabled = False
		
		
		PARAM_GROUP_SEQ = "group_seq"
		
	End Sub
	
	Private Sub period_enable(ByRef bOption As Boolean)
		cbPeriodName.Enabled = bOption
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
	'1. Look for an existing GIR set for Cust Billing Report
	'   for the combination Customer, Period and Store Group (single or range)
	'1.1 If found
	'1.1.1   If entered single storegroup
	'1.1.1.1     replace GIR report
	'1.1.2   If entered range of storegroups
	'1.1.2.1     loop thru all ranges in db
	'1.1.2.1.1     if entered range matches db range then replace GIR
	'1.1.2.1.2     if entered range partially matches db range then advise user that this is an error
	'1.1.2.2     We had loop thru all ranges and none matches ours, then insert GIR
	'1.2 If notfound
	'1.2.1     insert GIR report
	'TEST Cases
	' Create a GIR with Store Group1: AM001
	' create another with Store Group2: AM001
	' Second test: create a GIR with Store GRoup: AM001, AM002
	' create another with Store group: AM002
	'Third test: create a GIR with Store group: AM002
	'create another with Store group: AM004
	Public Function save_glminvoice_report_criteria(ByRef custId As String, ByRef repNo As Short, ByRef reportId As Integer, ByRef stateId As String, ByRef groupSeq As Short, ByRef repTemplateName As String, ByRef reportCaption As String, ByRef isPeriodSeq As String, ByRef periodSeq As Short, ByRef startDate As Date, ByRef endDate As Date, ByRef displayStoreWithInvoices As String, ByRef publishToWeb As String, ByRef webReportName As String, ByRef useForCustomerBilling As String, ByRef instanceNo As Integer, ByRef isFinalVersion As String) As Boolean
		
        'Dim oldInstanceNo As Integer
		
		Dim oldReportId As Integer
        'Dim sUseForCustomerBilling As String
		
		'On Error GoTo ErrorHandler:
		
		
		save_glminvoice_report_criteria = False
		
		
		
		sStmt = " SELECT report_id, use_for_customer_billing, id, group_seq " & " FROM RptCriteriaGlmInvoice " & " WHERE cust_id ='" & custId & "' " & " AND period_seq = " & Str(periodSeq) & " AND group_seq = " & Str(VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex)) & " AND use_for_customer_billing='TRUE' "
		
		
		rs = exec_sql(sStmt)
		
		Dim bFound As Boolean
		Dim nCountGroupSeq As Short
		Dim result As gDumpUDT
		Dim sGroupList As String

        If rs.Rows.Count > 0 Then
            'sUseForCustomerBilling = rs("use_for_customer_billing")

            'If Trim(sUseForCustomerBilling) = "TRUE" Then
            'If rs("group_seq") > 0 Then 'Single Store Group
            If groupSeq > 0 Then 'Single Store Group

                If MsgBox("Another report was marked for Billing Customer, it will be replaced." & vbCrLf & "Do you want to proceed?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "GLM Warning") = MsgBoxResult.Yes Then

                    oldReportId = rs.Rows(0).Item("report_id")

                    save_glminvoice_report_criteria = update_glminvoice_report_criteria(custId, repNo, reportId, stateId, groupSeq, repTemplateName, reportCaption, isPeriodSeq, periodSeq, startDate, endDate, displayStoreWithInvoices, publishToWeb, webReportName, useForCustomerBilling, oldReportId, instanceNo, isFinalVersion)
                Else
                    save_glminvoice_report_criteria = True
                End If


            Else 'Store Group range

                'Count number of group seq in rptCriteriaDet for current entry
                sStmt = "SELECT * FROM rptCriteriaDet a " & " WHERE id = " & Str(instanceNo)

                rsLocal = exec_sql(sStmt)

                nCountGroupSeq = rsLocal.Rows.Count
                bFound = False

                For row As Integer = 0 To rs.Rows.Count - 1
                    'Get param details for this each instance found and check if
                    'list of group seq found matches current entry
                    sStmt = " SELECT * FROM rptCriteriaDet a " & " WHERE a.param_name = 'group_seq' " & " AND id = " & Str(instanceNo) & " AND EXISTS ( SELECT * FROM rptCriteriaDet b " & "              WHERE id = " & Str(rs.Rows(row).Item("id")) & "              AND b.param_name = a.param_name " & "              AND b.param_seq = a.param_seq ) "

                    rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic)



                    If rsLocal.Rows.Count > 0 Then
                        If rsLocal.Rows.Count = nCountGroupSeq Then 'Same details

                            If MsgBox("Another report was Marked for Billing Customer, it will be replaced." & vbCrLf & "Do you want to proceed?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "GLM Warning") = MsgBoxResult.Yes Then
                                'UPGRADE_WARNING: Couldn't resolve default property of object result. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                result = hasCustomerInvoice(custId, rs.Rows(row).Item("id"))
                                If result.str1 = "TRUE" Then
                                    MsgBox("Action aborted, existing report is bound to a Customer Invoice that must " & vbCrLf & "be removed before overriding this report." & vbCrLf & "Customer Invoice details:" & vbCrLf & result.str2, MsgBoxStyle.OkOnly, "GLM Warning")

                                Else
                                    oldReportId = rs.Rows(row).Item("report_id")

                                    save_glminvoice_report_criteria = update_glminvoice_report_criteria(custId, repNo, reportId, stateId, groupSeq, repTemplateName, reportCaption, isPeriodSeq, periodSeq, startDate, endDate, displayStoreWithInvoices, publishToWeb, webReportName, useForCustomerBilling, oldReportId, instanceNo, isFinalVersion)
                                End If
                            Else
                                save_glminvoice_report_criteria = True
                            End If

                            '2011.11.07.begin
                            bFound = True
                            Exit For
                            'Exit Function
                            '2011.11.07.end
                        Else 'Intersection between two

                            sGroupList = ""
                            For arow As Integer = 0 To rsLocal.Rows.Count - 1
                                sGroupList = sGroupList + rsLocal.Rows(arow).Item("param_value")
                            Next arow

                            MsgBox("The following Store Group(s): " & vbCrLf & sGroupList & vbCrLf & "Were already billed with another report." & vbCrLf & "You have to remove them from your list.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")

                            '2011.11.07.begin
                            'Exit Function
                            bFound = True
                            Exit For
                            '2011.11.07.end
                        End If
                    Else 'Ok these are exclusive

                        'Continue comparing with other storegroup ranges

                        'insert_glminvoice_report_criteria _
                        'cbCustId.Text, repNo, reportId, stateId, _
                        'groupSeq, repTemplateName, _
                        'reportCaption, isPeriodSeq, periodSeq, _
                        'startDate, endDate, displayStoreWithInvoices, publishToWeb, _
                        'webReportName, useForCustomerBilling, instanceNo

                        '   save_glminvoice_report_criteria = True
                        '   Exit Function

                    End If
                Next row
                'rs.MoveFirst




                'oldReportId = rs("report_id")

                'save_glminvoice_report_criteria = _
                'update_glminvoice_report_criteria( _
                'custId, repNo, reportId, stateId, _
                'groupSeq, repTemplateName, _
                'reportCaption, isPeriodSeq, periodSeq, _
                'startDate, endDate, displayStoreWithInvoices, publishToWeb, _
                'webReportName, useForCustomerBilling, oldReportId, instanceNo)

                'Ok we had loop thru all storegroup ranges and none of them matches our store groups
                If Not bFound Then
                    save_glminvoice_report_criteria = insert_glminvoice_report_criteria((cbCustId.Text), repNo, reportId, stateId, groupSeq, repTemplateName, reportCaption, isPeriodSeq, periodSeq, startDate, endDate, displayStoreWithInvoices, publishToWeb, webReportName, useForCustomerBilling, instanceNo, isFinalVersion)
                End If


            End If


            'Exit Function

        Else
            save_glminvoice_report_criteria = insert_glminvoice_report_criteria((cbCustId.Text), repNo, reportId, stateId, groupSeq, repTemplateName, reportCaption, isPeriodSeq, periodSeq, startDate, endDate, displayStoreWithInvoices, publishToWeb, webReportName, useForCustomerBilling, instanceNo, isFinalVersion)


            'Exit Function

        End If



        If save_glminvoice_report_criteria = True Then
            nInstanceNo = get_seed("rptCriteriaGlmInvoice")
            set_grid_selector()
        End If

        Exit Function

ErrorHandler:
        save_error(Me.Name, "save_glminvoice_report_criteria")
        MsgBox("An unexpected error occurred when saving report Criteria." & vbCrLf & "Check logfile for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
		
		
		
	End Function
	
	
	'Validates that stores in groups selected do not overlap stores among them
    Function validateStoreGroupList(ByRef rsResult As DataTable) As Boolean

        Dim bFound As Boolean
        Dim i As Short
        Dim j As Short

        Dim size_Renamed As Short


        size_Renamed = rsResult.Rows.Count

        Dim aGroups(size_Renamed) As Short
        Dim aGroupNames(size_Renamed) As String

        validateStoreGroupList = True

        i = 0
        For row As Integer = 0 To rsResult.Rows.Count - 1
            aGroups(i) = rsResult.Rows(row).Item("group_seq")
            aGroupNames(i) = rsResult.Rows(row).Item("Group")
            i = i + 1
        Next row
        

        'For all the combinations check for store intersection between two groups
        Dim msg As String
        If i > 0 Then
            For i = 0 To size_Renamed - 1
                bFound = False

                For j = i + 1 To size_Renamed - 1

                    sStmt = "SELECT s.* FROM groupStore a, store s " & " WHERE  group_seq = " & Str(aGroups(i)) & " AND a.cust_id = s.cust_id " & " AND a.store_id = s.store_id " & " AND EXISTS (SELECT * FROM groupStore b" & "   WHERE b.group_seq = " & Str(aGroups(j)) & "   AND a.store_id = b.store_id " & "   AND a.cust_id = b.cust_id)"

                    rs = getDataTable(sStmt) 'Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic)

                    If rs.Rows.Count > 0 Then
                        msg = "Duplicate store found " & Trim(rs.Rows(0).Item("store_number")) & " defined in Groups:" & Trim(aGroupNames(i)) & " and " & Trim(aGroupNames(j)) & vbCrLf & "Remove one of these groups."
                        MsgBox(msg, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
                        bFound = True
                        validateStoreGroupList = False

                        Exit For
                    End If

                Next j

                If bFound Then
                    Exit For
                End If
            Next i
        End If

    End Function
	
	'Returns the number of records found in rptCriteriaDet table for the given instanceNo
	Private Function countOfDetails() As Integer
		
		countOfDetails = 0
		
		sStmt = "SELECT COUNT(*) FROM rptCriteriaDet WHERE id =" & Str(nInstanceNo)
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If Not IsDBNull(rsLocal.Rows(0).Item(0)) Then
            countOfDetails = rsLocal.Rows(0).Item(0)
        End If

		
		
		
	End Function
	
	Private Sub exec_copy_repGlmInvoice(ByRef nReportFinal As Integer)
		
        cmReport = cn.CreateCommand '.let_ActiveConnection(cn)
        cmReport.CommandType = CommandType.StoredProcedure
		cmReport.CommandText = "usp_copy_repGlmInvoice"

        SqlCommandBuilder.DeriveParameters(cmReport)
		cmReport.Parameters("@nReportId").Value = nReport
		cmReport.Parameters("@sCustId").Value = rptGlmInvoiceParam.sCustId
		cmReport.Parameters("@sStateId").Value = rptGlmInvoiceParam.sStateId
		cmReport.Parameters("@nGroupSeq").Value = rptGlmInvoiceParam.nGroupSeq
		
		cmReport.Parameters("@nPeriodSeq").Value = rptGlmInvoiceParam.nPeriodSeq
		If rptGlmInvoiceParam.bPeriodSeq Then
			cmReport.Parameters("@sPeriodSeq").Value = "T"
			cmReport.Parameters("@sStartDate").Value = Today
			cmReport.Parameters("@sEndDate").Value = Today
		Else
			cmReport.Parameters("@sPeriodSeq").Value = "F"
			cmReport.Parameters("@sStartDate").Value = rptGlmInvoiceParam.sStartDate
			cmReport.Parameters("@sEndDate").Value = rptGlmInvoiceParam.sEndDate
		End If
		
		cmReport.Parameters("@sReportCaption").Value = rptGlmInvoiceParam.sReportCaption
		
		If ckUseGlmRate.CheckState = System.Windows.Forms.CheckState.Checked Then
			cmReport.Parameters("@sUseGlmRate").Value = "T"
		Else
			cmReport.Parameters("@sUseGlmRate").Value = "F"
		End If
		
		If ckGlmVendor.CheckState = System.Windows.Forms.CheckState.Checked Then
			cmReport.Parameters("@sGlmAsVendor").Value = "T"
		Else
			cmReport.Parameters("@sGlmAsVendor").Value = "F"
		End If
		
		cmReport.Parameters("@sReportTemplate").value = cbReportTemplate.Text

        If Not IsNothing(rptGlmInvoiceParam.sGroupSeqList) Then
            cmReport.Parameters("@sGroupSeqList").Value = rptGlmInvoiceParam.sGroupSeqList
        Else
            cmReport.Parameters("@sGroupSeqList").Value = "NULL"
        End If
        'cmReport.Parameters("@sGroupSeqList").Value = rptGlmInvoiceParam.sGroupSeqList

        cmReport.Parameters("@nReportIdCurr").Value = nReportFinal
        cmReport.Parameters("@nError").Direction = ParameterDirection.Output
        'Ejecuto el procedure y verifico por errores
        cmReport.ExecuteNonQuery()

        rptGlmInvoiceParam.nError = cmReport.Parameters("@nError").Value
        If rptGlmInvoiceParam.nError <> 0 Then
            MsgBox("An error ocurred while backing up report data.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Sub
        End If

    End Sub
End Class