Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Friend Class frmRepCostContSearch
	Inherits System.Windows.Forms.Form
	Private sLocalVersion As String
	Private sLocalReport As String
	
	'Variables de Cost Containment Report
	Private Structure rptCostContParamUDT
		Dim sCustId As String
		Dim sStateId As String
		Dim nGroupSeq As Short
		Dim nPeriodSeq As Short
		Dim bPeriodSeq As Boolean
		Dim sStartDate As String
		Dim sEndDate As String
		Dim sReportCaption As String
		Dim bDetailedCharges As Boolean
		Dim bContractRange As Boolean
		Dim bSavingsPercentTotal As Boolean
		Dim bUseGlmRate As Boolean
		Dim bGlmAsVendor As Boolean
		Dim nError As Short
	End Structure
	Private rptCostContParam As rptCostContParamUDT
    Private rsLocal As DataTable
    Private cmdLocal As SqlCommand
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
		
		
		sStmt = "SELECT period_name, period_seq, period_start_date FROM period " & " WHERE cust_id ='" & Trim(cbCustId.Text) & "'" & " ORDER BY period_start_date DESC"
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
		If cbReportTemplate.Text = SYS_CCR_GLMRATE_AUDIT Then
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
	
	'UPGRADE_WARNING: Event ckPublish.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub ckPublish_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ckPublish.CheckStateChanged
		If ckPublish.CheckState = System.Windows.Forms.CheckState.Checked Then
			txtReportName.ReadOnly = False
			txtReportName.Enabled = True
		Else
			txtReportName.ReadOnly = True
			txtReportName.Enabled = False
		End If
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		
		Dim sReportTemplate As String
		Dim nReportFinal As Integer
        'Dim nRepNo As Short
		
		If val_fields = False Then
			Exit Sub
		End If

        'MessageBox.Show(cbPeriodName.Items(cbPeriodName.SelectedIndex).ToString())
        'MessageBox.Show(VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex))

		
		With rptCostContParam
			.sCustId = cbCustId.Text '"OB"
			.sStateId = cbStateId.Text '"TX"
			.nPeriodSeq = VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex) '16
			.nGroupSeq = VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex) '3
			.bPeriodSeq = obPeriod.Checked 'True
            'UPGRADE_WARNING: Couldn't resolve default property of object dtStartDate.Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .sStartDate = dtStartDate.Value '"01/01/2003"
            'UPGRADE_WARNING: Couldn't resolve default property of object dtEndDate.Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            .sEndDate = dtEndDate.Value ' "01/31/2003"
			
		End With
		If cbStateId.Text = "<All>" Then
			rptCostContParam.sStateId = "All"
		End If
		If Len(txtReportCaption.Text) = 0 Then
			rptCostContParam.sReportCaption = ""
		Else
			rptCostContParam.sReportCaption = txtReportCaption.Text
		End If
		
		If ckPublish.CheckState = System.Windows.Forms.CheckState.Checked Then
			sReportTemplate = cbReportTemplate.Text
			If Not publish_report(cbCustId.Text, txtReportName.Text, sReportTemplate, Me.Name, sLocalReport) Then
				MsgBox("Cancelling report job.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
				Exit Sub
			End If
		End If
		
		ReportHandler()
		
		If ckPublish.CheckState = System.Windows.Forms.CheckState.Checked Then
			update_publish_report(cbCustId.Text, txtReportName.Text, nReport)
		End If
		
		If ckPrintFinal.CheckState = System.Windows.Forms.CheckState.Checked Then
			nReportFinal = getCCRFinalVersion((cbCustId.Text), VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex), VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex))
			
			'save_costcont_report_criteria
			'exec_copy_repcostcont nReportFinal
			
			If nReportFinal = 0 Then
				save_costcont_report_criteria()
				exec_copy_repcostcont(nReportFinal)
			Else
				MsgBox("A final version report was found for this Customer and Period," & vbCrLf & "Contact GIS Administrator to clear out the flag.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "Warning")
				
			End If
		Else
			save_costcont_report_criteria()
		End If
		
	End Sub
	'Executes stored procedure that performs copy of records from RptCostCont to GlmCostCont table
	Private Sub exec_copy_repcostcont(ByRef nReportFinal As Integer)
		
        cmReport = cn.CreateCommand() '.let_ActiveConnection(cn)
        cmReport.CommandType = CommandType.StoredProcedure
		'cmReport.Parameters.Refresh

        cmReport.CommandText = "usp_copy_repCostCont"
        SqlCommandBuilder.DeriveParameters(cmReport)

		cmReport.Parameters("@nReportId").Value = nReport
		cmReport.Parameters("@sCustId").Value = rptCostContParam.sCustId
		cmReport.Parameters("@sStateId").Value = rptCostContParam.sStateId
		cmReport.Parameters("@nGroupSeq").Value = rptCostContParam.nGroupSeq
		cmReport.Parameters("@nPeriodSeq").Value = rptCostContParam.nPeriodSeq
		If rptCostContParam.bPeriodSeq Then
			cmReport.Parameters("@sPeriodSeq").Value = "T"
			cmReport.Parameters("@sStartDate").Value = Today
			cmReport.Parameters("@sEndDate").Value = Today
		Else
			cmReport.Parameters("@sPeriodSeq").Value = "F"
			cmReport.Parameters("@sStartDate").Value = rptCostContParam.sStartDate
			cmReport.Parameters("@sEndDate").Value = rptCostContParam.sEndDate
		End If
		cmReport.Parameters("@sReportCaption").Value = rptCostContParam.sReportCaption
		If rptCostContParam.bDetailedCharges Then
			cmReport.Parameters("@sDetailedCharges").Value = "T"
		Else
			cmReport.Parameters("@sDetailedCharges").Value = "F"
		End If
		If rptCostContParam.bContractRange Then
			cmReport.Parameters("@sShowContractRange").Value = "T"
		Else
			cmReport.Parameters("@sShowContractRange").Value = "F"
		End If
		
		If rptCostContParam.bSavingsPercentTotal Then
			cmReport.Parameters("@sShowSavingsPercentTotal").Value = "T"
		Else
			cmReport.Parameters("@sShowSavingsPercentTotal").Value = "F"
		End If
		
		If rptCostContParam.bUseGlmRate Then
			cmReport.Parameters("@sUseGlmRate").Value = "T"
		Else
			cmReport.Parameters("@sUseGlmRate").Value = "F"
		End If
		
		If rptCostContParam.bGlmAsVendor Then
			cmReport.Parameters("@sGlmAsVendor").Value = "T"
		Else
			cmReport.Parameters("@sGlmAsVendor").Value = "F"
		End If
		
		
		cmReport.Parameters("@sReportTemplate").Value = cbReportTemplate.Text
		
		cmReport.Parameters("@nReportIdCurr").Value = nReportFinal
		
		
		
        'Ejecuto el procedure y verifico por error
        cmReport.Parameters("@nError").Direction = ParameterDirection.Output
        cmReport.ExecuteNonQuery()
		
		rptCostContParam.nError = cmReport.Parameters("@nError").Value
		If rptCostContParam.nError <> 0 Then
			MsgBox("An error ocurred while copying report data.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Sub
		End If
		
	End Sub
	'Translates flags into propper values to insert into RptCriteriaCostCont table
	Private Sub save_costcont_report_criteria()
		
		Dim nRepNo As Short
		Dim sIsPeriodSeq As String
		Dim sPrintEquipmentStatus As String
		Dim sDetailedCharges As String
		Dim sContractRange As String
		Dim sUseGlmRate As String
		Dim sGlmVendor As String
		Dim sSavingsPercent As String
		Dim sPrintFinal As String
		Dim sPublish As String
		
		
		nRepNo = CShort(getRepNo(sLocalReport))
		
		If obPeriod.Checked = True Then
			sIsPeriodSeq = "TRUE"
		Else
			sIsPeriodSeq = "FALSE"
		End If
		
		If Me.ckPrintStatus.CheckState = System.Windows.Forms.CheckState.Checked Then
			sPrintEquipmentStatus = "TRUE"
		Else
			sPrintEquipmentStatus = "FALSE"
		End If
		
		If Me.ckDetailedCharges.CheckState = System.Windows.Forms.CheckState.Checked Then
			sDetailedCharges = "TRUE"
		Else
			sDetailedCharges = "FALSE"
		End If
		
		If Me.ckContractRange.CheckState = System.Windows.Forms.CheckState.Checked Then
			sContractRange = "TRUE"
		Else
			sContractRange = "FALSE"
		End If
		
		If Me.ckUseGlmRate.CheckState = System.Windows.Forms.CheckState.Checked Then
			sUseGlmRate = "TRUE"
		Else
			sUseGlmRate = "FALSE"
		End If
		
		If Me.ckGlmVendor.CheckState = System.Windows.Forms.CheckState.Checked Then
			sGlmVendor = "TRUE"
		Else
			sGlmVendor = "FALSE"
		End If
		
		If Me.ckShowSavingsPercent.CheckState = System.Windows.Forms.CheckState.Checked Then
			sSavingsPercent = "TRUE"
		Else
			sSavingsPercent = "FALSE"
		End If
		
		If Me.ckPrintFinal.CheckState = System.Windows.Forms.CheckState.Checked Then
			sPrintFinal = "TRUE"
		Else
			sPrintFinal = "FALSE"
		End If
		
		If Me.ckPublish.CheckState = System.Windows.Forms.CheckState.Checked Then
			sPublish = "TRUE"
		Else
			sPublish = "FALSE"
		End If
		
		
        insert_costcont_report_criteria((cbCustId.Text), nRepNo, nReport, rptCostContParam.sStateId, VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex), (Me.cbReportTemplate).Text, (Me.txtReportCaption).Text, sIsPeriodSeq, VB6.GetItemData(Me.cbPeriodName, cbPeriodName.SelectedIndex), (Me.dtStartDate).Value, (Me.dtEndDate).Value, sPrintEquipmentStatus, sDetailedCharges, sContractRange, sSavingsPercent, sPublish, (Me.txtReportCaption.Text), sUseGlmRate, sGlmVendor, sPrintFinal)
		
	End Sub
	'Verifies data entered is correct
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
		
		'Report Caption
		
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
            'UPGRADE_WARNING: Couldn't resolve default property of object dtEndDate.Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object dtStartDate.Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If dtStartDate.Value > dtEndDate.Value Then
                MsgBox("Start Date must be less than End Date.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
                val_fields = False
                Exit Function
            End If
		End If
		
		If ckDetailedCharges.CheckState = System.Windows.Forms.CheckState.Checked Then
			rptCostContParam.bDetailedCharges = True
		Else
			rptCostContParam.bDetailedCharges = False
		End If
		
		If ckContractRange.CheckState = System.Windows.Forms.CheckState.Checked Then
			rptCostContParam.bContractRange = True
		Else
			rptCostContParam.bContractRange = False
		End If
		
		If ckShowSavingsPercent.CheckState = System.Windows.Forms.CheckState.Checked Then
			rptCostContParam.bSavingsPercentTotal = True
		Else
			rptCostContParam.bSavingsPercentTotal = False
		End If
		
		'GLM Rate
		If ckUseGlmRate.CheckState = System.Windows.Forms.CheckState.Checked Then
			rptCostContParam.bUseGlmRate = True
		Else
			rptCostContParam.bUseGlmRate = False
		End If
		
		'Glm As Vendor
		If ckGlmVendor.CheckState = System.Windows.Forms.CheckState.Checked Then
			rptCostContParam.bGlmAsVendor = True
		Else
			rptCostContParam.bGlmAsVendor = False
		End If
		
		If ckPublish.CheckState = System.Windows.Forms.CheckState.Checked Then
			If Trim(txtReportName.Text) = "" Then
				MsgBox("Please enter Report Name to publish on the web.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
				val_fields = False
				txtReportName.Focus()
				Exit Function
			End If
		End If
		val_fields = True
	End Function
	Private Sub ReportHandler()
		Dim bPrinter As Boolean
		
		'If bOk Then '--Parametros correctos
		'Chequea que exista impresora por defecto
		'UPGRADE_ISSUE: Printers method Printers.Count was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count = 0 Then
            bPrinter = False
        Else
            bPrinter = True
            'printer_options True
        End If
		
		'Shows report and prints it
		If bPrinter Then
			'Seleccionar impresora
            If find_printer() Then
                printer_options(True)
                'Version para soporte a Crystal Reports
                show_report2()
                'MAYO-14/2002 Activar este reporte cuando se genere salida a Excel
                'show_report_excel
            End If
		Else
			MsgBox("There is not default printer specified.Aborting", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Sub
		End If
		
		'Se restauran defaults
		If bPrinter Then
			printer_options(False)
		End If
		'End If
		
	End Sub
	Private Sub printer_options(ByRef bOption As Boolean)
        'Dim i As Short
		
        'Static nDefault As String
		'Agregar forma para seleccionar otra impresora que no
		'sea la impresora default
		If bOption Then
			
			'For i = 0 To Printers.Count - 1
			'   If Printer.DeviceName = Printers(i).DeviceName Then
			'     nDefault = i
			'Selecciono la impresora por defecto
			'     Set Printer = Printers(i)
			'     Exit For
			'   End If
			'Next
			'Printer.Width = 16560
			'Printer.PaperSize = vbPRPSLegal
			'UPGRADE_ISSUE: Constant vbPRPSLetter was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
			'UPGRADE_ISSUE: Printer property Printer.PaperSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.PaperSize = vbPRPSLetter
			'UPGRADE_ISSUE: Constant vbPRORLandscape was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
			'UPGRADE_ISSUE: Printer property Printer.Orientation was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.Orientation = vbPRORLandscape
			
		Else
			'Codigo para cambiar de impresora y opciones de impresion
		End If
	End Sub
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
	'2.-Ejecuta el store procedure para cargar RptCostCont
	'3.-Verifica que se haya ejecutado, que hayan datos en RptCostCont
	'4.-Mapea campos de RepData con los definidos en RepCust
	'5.-Muestra el reporte
	Private Sub show_report2()

        'On Error GoTo ErrorHandler

        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rsFields = Nothing

        cmReport.CommandTimeout = gnTimeout

        cmReport = cn.CreateCommand() '.let_ActiveConnection(cn)
        cmReport.CommandType = CommandType.StoredProcedure

        'Obengo el identificador del reporte
        'nReport = 0
        'nReport = get_seed("repdata")
        'If nReport <= 0 Then
        '    MsgBox "Unable to get Report Number." + vbCrLf + _
        ''           "Report has not been generated.", vbCritical + vbOKOnly, "GLM Error"
        '    Exit Sub
        'End If

        nReport = get_report_id()

        If nReport <= 0 Then
            Exit Sub
        End If

        'Se cargan los parametros dependiendo del tipo de reporte

        'get get refresh sqlcommand stored procedure parameters
        cmReport.CommandText = "usp_rep_cost_cont"
        SqlCommandBuilder.DeriveParameters(cmReport)

        cmReport.Parameters("@nReportId").Value = nReport

        Dim prmName As String = cmReport.Parameters("@nReportId").ParameterName
        Dim prmVal As String = cmReport.Parameters("@nReportId").Value



        cmReport.Parameters("@sCustId").Value = rptCostContParam.sCustId
        cmReport.Parameters("@sStateId").Value = rptCostContParam.sStateId
        cmReport.Parameters("@nGroupSeq").Value = rptCostContParam.nGroupSeq
        cmReport.Parameters("@nPeriodSeq").Value = rptCostContParam.nPeriodSeq
        If rptCostContParam.bPeriodSeq Then
            cmReport.Parameters("@sPeriodSeq").Value = "T"
            cmReport.Parameters("@sStartDate").Value = Today
            cmReport.Parameters("@sEndDate").Value = Today
        Else
            cmReport.Parameters("@sPeriodSeq").Value = "F"
            cmReport.Parameters("@sStartDate").Value = rptCostContParam.sStartDate
            cmReport.Parameters("@sEndDate").Value = rptCostContParam.sEndDate
        End If
        cmReport.Parameters("@sReportCaption").Value = rptCostContParam.sReportCaption
        If rptCostContParam.bDetailedCharges Then
            cmReport.Parameters("@sDetailedCharges").Value = "T"
        Else
            cmReport.Parameters("@sDetailedCharges").Value = "F"
        End If
        If rptCostContParam.bContractRange Then
            cmReport.Parameters("@sShowContractRange").Value = "T"
        Else
            cmReport.Parameters("@sShowContractRange").Value = "F"
        End If

        If rptCostContParam.bSavingsPercentTotal Then
            cmReport.Parameters("@sShowSavingsPercentTotal").Value = "T"
        Else
            cmReport.Parameters("@sShowSavingsPercentTotal").Value = "F"
        End If

        If rptCostContParam.bUseGlmRate Then
            cmReport.Parameters("@sUseGlmRate").Value = "T"
        Else
            cmReport.Parameters("@sUseGlmRate").Value = "F"
        End If

        If rptCostContParam.bGlmAsVendor Then
            cmReport.Parameters("@sGlmAsVendor").Value = "T"
        Else
            cmReport.Parameters("@sGlmAsVendor").Value = "F"
        End If

        cmReport.Parameters("@sReportTemplate").Value = cbReportTemplate.Text


        log_report_parameters(sLocalReport, cmReport)

        'Ejecuto el procedure y verifico por error
        cmReport.Parameters("@nError").Direction = ParameterDirection.Output
        cmReport.CommandTimeout = 300
        cmReport.ExecuteNonQuery()

        rptCostContParam.nError = cmReport.Parameters("@nError").Value
        If rptCostContParam.nError <> 0 Then
            MsgBox("An error ocurred while generating report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Sub
        End If

        'Verifico que se hayan cargado datos en RepData para este reporte
        'sStmt = "SELECT count(*) FROM RepData WHERE col0 = " + Str(nReport)
        sStmt = "SELECT count(*) FROM RptCostCont WHERE report_id = " & Str(nReport)
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Try
            If rsLocal.Rows(0).Item(0) > 0 Then
                'Encontro registros
            Else
                MsgBox("No data was generated for :" & gReport.name & " report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("There was an error while verifying report data for:" & gReport.name, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End Try

        'Mapping
        'Build query for RepData
        'If map_fields_data(rptCostContParam.sCustId, sLocalReport, sLocalVersion, nReport) = False Then
        '    'Screen.MousePointer = vbDefault
        '    Exit Sub
        'End If

        If Not map_fields_data2(nReport) Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If

        Dim dtSource As DataTable = getDataTable(sStmt)
        'Dim dsSource As DataSet = getDataSet(sStmt)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        'Cargo la plantilla de Crystal Reports con los datos
        load_report(dtSource)
        'load_report(dsSource)
        Exit Sub

ErrorHandler:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        save_error("frmReportInv", "show_report2")

        'MsgBox(e.Description)

    End Sub
	'Asocia los campos de RepData con los campos del Reporte.
	'Retorna un recordset con los datos
	Private Function map_fields_data(ByRef sCustId As String, ByRef sLocalReport As String, ByRef sLocalVersion As String, ByRef nReportId As Integer) As Boolean
		
        Dim rsMap As DataTable
		
		sStmt = "SELECT RepField.crystal_ttx_name, RepCust.rep_field, " & "RepCust.col_order, RepCust.col_map " & "FROM RepField, RepCust " & "WHERE RepField.rep_field = RepCust.rep_field " & "AND RepCust.cust_id ='" & Trim(sCustId) & "' " & "AND RepCust.format_name='" & Trim(sLocalVersion) & "' " & "AND RepCust.rep_no = " & "(SELECT rep_no FROM RepDef WHERE rep_caption='" & Trim(sLocalReport) & "') " & "ORDER BY RepCust.col_order"
        Try
            rsMap = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            'Construyo sentencia SELECT con campos mapeados
            If rsMap.Rows.Count > 0 Then

                sStmt = "SELECT "
                For row As Integer = 0 To rsMap.Rows.Count - 1
                    sStmt = Trim(sStmt) & " " & "RTRIM(" & Trim(rsMap.Rows(row).Item("col_map")) & ") AS " & Trim(rsMap.Rows(row).Item("crystal_ttx_name")) & ", "
                Next row
                

                'Elimina la ultima coma
                sStmt = VB.Left(sStmt, Len(sStmt) - 2)
                sStmt = Trim(sStmt) & " FROM RepData " & " WHERE col0 = " & Trim(Str(nReport))
                '" order by store_no, account, invoice, eqpt_mask"



                'Cargo el recordset con los datos de RepData
                rsReport = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                map_fields_data = True
                Exit Function

            Else
                map_fields_data = False
                MsgBox("No Mapping data was found.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                Exit Function
            End If
        Catch ex As Exception
            map_fields_data = False
            MsgBox("An error has ocurred while maping report data.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Function
        End Try

        Exit Function

        'Seleccionar registros a mostrar
        'Retornar recordset
ErrorHandler:
        map_fields_data = False
        save_error(Me.Name, "map_fields_data")
        MsgBox("An unexpected error has occurred. Check log file for details.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Error")
		
	End Function
	Public Function map_fields_data2(ByRef nReportId As Integer) As Boolean
		
		map_fields_data2 = False
        'este sStmt esta comentado en el codigo legacy
        'sStmt = _
        '"SELECT account, account_no, content_desc, cust_id, " + _
        '"cust_name, eqpt_mask, eqpt_seq, frequency_mask, " + _
        '"invoice, invoice_no, location, old_rate, " + _
        '"rate, rate_status, report_end, report_start, " + _
        '"savings, comment,serv_desc," + _
        '"serv_desc1, serv_sum1, serv_desc2, serv_sum2, " + _
        '"serv_desc3, serv_sum3, serv_desc4, serv_sum4, " + _
        '"serv_desc5, serv_sum5, serv_desc6, serv_sum6, " + _
        '"serv_desc7, serv_sum7, serv_desc8, serv_sum8, " + _
        '"serv_desc9, serv_sum9, serv_desc10, serv_sum10, " + _
        '"serv_desc11, serv_sum11, serv_desc12, serv_sum12, " + _
        '"serv_desc13, serv_sum13, serv_desc14, serv_sum14, " + _
        '"serv_desc101, serv_sum101, " + _
        '"serv_desc102, serv_sum102, " + _
        '"serv_desc103, serv_sum103, " + _
        '"serv_desc104, serv_sum104, " + _
        '"serv_desc105, serv_sum105, " + _
        '"serv_desc106, serv_sum106, " + _
        '"serv_desc107, serv_sum107, " + _
        '"serv_id, "

        '' sStmt = sStmt + _
        '"units, serv_usage, store_id, store_no," + _
        '"total_charges, total_savings, " + _
        '" total_serv, total_units," + _
        '"unit_type, vend_name, vend_seq, " + _
        '"vinvoice_date, eqpt_temp, units, " + _
        '"serv_usage , total_nonbillsavings, contract_range,  " + _
        '"total_savingsPercent, label_savingsPercent, store_savings, store_name, " + _
        '"account_mask, glm_savings, contract_opening_date, contract_expiration_date, " + _
        '"store_address, store_city, state_id, store_number, glm_rate, current_rate, " + _
        '"current_glmrate_savings, total_current_glmrate_savings, store_current_glmrate_savings, " + _
        '"total_glmrate_serv, total_glmrate_charges, store_total " + _
        '" FROM RptCostCont " + _
        '" WHERE report_id = " + Str(nReportId)
		
		'Get CCR string to map fields
		get_ccr_map_fields()
		
		sStmt = sStmt & Str(nReportId)
		
        rsReport = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		map_fields_data2 = True
		Exit Function
		
	End Function
	'Usa el recordset rsReport que fue previamente cargado
    'con los datos de Repdata y lo paso al reporte de Crystal Reports
    'Private Function load_report(ByVal dstReport As DataTable) As Boolean
    Private Function load_report(ByVal dstReport As DataTable) As Boolean

        'Dim sFile As String 'Path de la plantilla del reporte
        ' sReportTemplate As String 'Nombre de plantilla de reporte
        Dim fileTmp As Scripting.FileSystemObject
        fileTmp = New Scripting.FileSystemObject
        Dim sFile As String
        'MsgBox("About to load report: " & vbCrLf & strReportsSysPath & vbCrLf & "Report name: " & "rptCostCont.rpt", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Info")
        Dim rptDoc As ReportDocument = New ReportDocument()
        Try
            sFile = get_template(sLocalReport, cbReportTemplate.Text)
            rptDoc.Load(sFile)
        Catch ex As Exception
            MsgBox("Err: " & ex.Message & vbCrLf & "Please install: " & "rptCostCont.rpt", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
        End Try
        'MsgBox("Report loaded OK so far after try.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Info")
        rptDoc.SetDataSource(dstReport)

        frmRepCostContSearchViewer.CrystalReportViewer1.ReportSource = rptDoc
        frmRepCostContSearchViewer.CrystalReportViewer1.Visible = True
        frmRepCostContSearchViewer.CrystalReportViewer1.Show()
        frmRepCostContSearchViewer.Show()
        Exit Function
        'On Error GoTo ErrorHandler

        'ADO
        'Set cn = New ADODB.Connection
        'Set AdoRs = New SqlDataReader
        'Set rsReport = New SqlDataReader
        'cn.Provider = "SQLOLEDB"
        'cn.ConnectionString = "User Id=sa;Password=sa;" + _
        ''    "Initial Catalog=glm;Data Source=jpuentelap1;"
        'cn.Open
        'AdoRs.Open "select store_id as id, state_id as store, " + _
        ''    "store_address as address , store_city as city  " + _
        ''    "from store", cn

        'AdoRs.Open "select store_id, store_name,store_address," + _
        '"store_city from store", cn
        'MsgBox AdoRs(2)


        'Abro el archivo con el reporte
        'crysApp = CreateObject("Crystal.CRPE.Application")


        'Select Case Trim(cbVersion)
        'Case "BRANCH"
        '   sFile = "c:\glm\Reports\rptInvoice5.rpt"
        'Set report = app1.OpenReport("c:\glm\Reports\rptInvoice5.rpt")
        'Set report = app1.OpenReport("d:\glm\tmp\rptPrueba2.rpt")
        'Case "LIST"
        'Set report = app1.OpenReport("c:\glm\Visual Basic\GLM-System\Reports\rptInvList.rpt")

        '  sReportTemplate = "rptInvList.rpt"
        '  sFile = Trim(App.Path) + "\" + sReportTemplate
        '  sFile = "c:\glm\rptInvList.rpt"
        'MsgBox "Looking for file:" + sFile
        'End Select

        'sFile = "c:\glm\Visual Basic\Glm-System\Reports\rptCostCont.rpt"
        'sFile = get_template(sLocalReport, cbReportTemplate.Text)
        'If fileTmp.FileExists(sFile) Then
        '    crysRepCostCont = crysApp.OpenReport(sFile)
        'Else
        '    sFile = get_local_template(sLocalReport)
        '    If fileTmp.FileExists(sFile) Then
        '        crysRepCostCont = crysApp.OpenReport(sFile)
        '    Else
        '        MsgBox("Report template not found." & vbCrLf & "Please install: " & sFile, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
        '        Exit Function
        '    End If
        'End If

        'Asignar impresora seleccionada por usuario.
        'report.SelectPrinter "HP DeskJet 550C","remota", "LPT1"
        'crysRepCostCont.SelectPrinter(Printer.DriverName, Printer.DeviceName, Printer.Port)

        'reportDb = crysRepCostCont.Database
        'reportTables = reportDb.Tables
        'reportTable = reportTables.Item(1)
        'reportPage = crysRepCostCont.PageSetup


        'Set DataGrid1.DataSource = rsReport
        'reportTable.SetPrivateData(3, rsReport)
        'reportTable.SetPrivateData 3, AdoRs

        'cd.CancelError = True
        'cd.ShowPrinter

        ' crysRepCostCont.ProgressDialogEnabled = True
        'crysRepCostCont.Preview()

        'ErrorHandler:
        'If Err.Number = cdlCancel Then
        '    MsgBox "usuario aborto"
        'End If
    End Function
	
	
	Private Sub frmRepCostContSearch_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	Private Sub init_vars()
		sLocalVersion = "DEFAULT"
		sLocalReport = "Cost Containment Report"
		
		
        cmdLocal = cn.CreateCommand()
		
		lbStartDate.Text = ""
		lbEndDate.Text = ""
		'UPGRADE_WARNING: TextBox property txtReportCaption.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtReportCaption.Maxlength = 30 'customer.cust_report_name CHAR(30)
		'UPGRADE_WARNING: TextBox property txtReportName.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtReportName.Maxlength = 60
		txtReportName.ReadOnly = True
		txtReportName.Enabled = False
		
		obPeriod.Checked = False
		obRange.Checked = False
		period_enable(False)
		range_enable(False)
		
        dtStartDate.Value = Today
		dtEndDate.value = Today
		
		ckPrintStatus.CheckState = System.Windows.Forms.CheckState.Checked
		ckPublish.CheckState = System.Windows.Forms.CheckState.Unchecked
		ckDetailedCharges.CheckState = System.Windows.Forms.CheckState.Checked
		ckContractRange.CheckState = System.Windows.Forms.CheckState.Unchecked
		ckShowSavingsPercent.CheckState = System.Windows.Forms.CheckState.Checked
		ckUseGlmRate.CheckState = System.Windows.Forms.CheckState.Unchecked
		ckPrintFinal.CheckState = System.Windows.Forms.CheckState.Unchecked
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
	
	Private Sub period_enable(ByRef bOption As Boolean)
		
		cbPeriodName.Enabled = bOption
		
	End Sub
	Private Sub range_enable(ByRef bOption As Boolean)
		dtStartDate.Enabled = bOption
		dtEndDate.Enabled = bOption
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