Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Threading
Friend Class frmRepUniversal
	Inherits System.Windows.Forms.Form
	Private nReport As Integer
	Private nFrameIndex As Short
	
    Private rsReportTemplate As DataTable
	
    Private rsEquipment As DataTable
    Private rsSelEquipment As DataTable
    Private rsContent As DataTable
    Private rsSelContent As DataTable
    Private rsLoad As DataTable
    Private rsSelLoad As DataTable
    Private rsService As DataTable
    Private rsSelService As DataTable
    Private rsVendor As DataTable
    Private rsSelVendor As DataTable
	
	Private bAllEquipmentSelected As Boolean
	Private bAllContentSelected As Boolean
	Private bAllLoadSelected As Boolean
	Private bAllServiceSelected As Boolean
	Private bAllVendorSelected As Boolean
	
	Private sWhere, sWhere1 As Object
	Private sWhere2 As String
	Private sWherePeriod As String
	Private sWhereEquipment As String
	Private sWhereEqptTemp As String
	Private sWhereContent As String
	Private sWhereLoad As String
	Private sWhereService As String
	Private sWhereVendor As String
	Private sServiceList As String
	
	Private sSort As String
	Private sField As String
	Private sEqptTemp As String
    Private rsLocal As DataTable
    Private rsReport As DataTable
	
	Private sLocalReport As String
	Private sLocalVersion As String
	
	Private sPrevCustId As String
	Private sPrevStateId As String
	
	Private Structure rptUniversalParamUDT
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
		Dim sPeriodName As String
		Dim sReportTitle As String
		Dim nError As Short
	End Structure
	Private rptUniversalParam As rptUniversalParamUDT
	'--------Crystal Reports-----------------
	
    Private Sub cbWithoutEqpt_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbWithoutEqpt.CheckStateChanged
        If cbWithoutEqpt.CheckState = System.Windows.Forms.CheckState.Checked Then
            cbInvoiceEqpt.Enabled = True
        Else
            cbInvoiceEqpt.Enabled = False
        End If
    End Sub
	
	Private Sub cmdAllLeftContent_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAllLeftContent.Click
		'sSort = "content_type, content_desc"
		sSort = "Type, Description"
		move_all_member(rsSelContent, rsContent, sSort)
	End Sub
	
	Private Sub cmdAllLeftEquipment_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAllLeftEquipment.Click
		sSort = "eqpt_type_desc, eqpt_size"
		'del_all_member_equipment
		move_all_member(rsSelEquipment, rsEquipment, sSort)
		
	End Sub
	
	Private Sub cmdAllLeftLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAllLeftLoad.Click
		sSort = "load_desc"
		move_all_member(rsSelLoad, rsLoad, sSort)
		
	End Sub
	
	Private Sub cmdAllLeftServ_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAllLeftServ.Click
		sSort = "serv_desc"
		move_all_member(rsSelService, rsService, sSort)
	End Sub
	
	Private Sub cmdAllLeftVendor_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAllLeftVendor.Click
		sSort = "vend_name"
		move_all_member(rsSelVendor, rsVendor, sSort)
	End Sub
	
	Private Sub cmdAllRightContent_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAllRightContent.Click
		'sSort = "content_type, content_desc"
		sSort = "Type, Description"
		move_all_member(rsContent, rsSelContent, sSort)
	End Sub
	
	Private Sub cmdAllRightEquipment_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAllRightEquipment.Click
		sSort = "eqpt_type_desc, eqpt_size"
		'add_all_member_equipment
		move_all_member(rsEquipment, rsSelEquipment, sSort)
		
	End Sub
	
	Private Sub cmdAllRightLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAllRightLoad.Click
		sSort = "load_desc"
		move_all_member(rsLoad, rsSelLoad, sSort)
	End Sub
	
	Private Sub cmdAllRightServ_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAllRightServ.Click
		sSort = "serv_desc"
		move_all_member(rsService, rsSelService, sSort)
		
	End Sub
	
	Private Sub cmdAllRightVendor_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAllRightVendor.Click
		sSort = "vend_name"
		move_all_member(rsVendor, rsSelVendor, sSort)
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		
		
		Me.Close()
	End Sub
	
	Private Sub cmdFinish_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFinish.Click
		Dim bFlagWithoutEqpt As Boolean
		Dim bFlagInvoiceEqpt As Boolean
		
		On Error GoTo ErrorHandler
		
		
        sb.Items(0).Text = "Validating Criteria"

        Thread.Sleep(1000)


		If val_fields Then
			If get_criteria Then
				
				'Se asigna parametros del reporte
				With rptUniversalParam
					.sCustId = cbCustId.Text
					.sStateId = cbStateId.Text '"TX"
					.nPeriodSeq = VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex) '16
					.nGroupSeq = VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex) '3
					.nPeriodStartSeq = VB6.GetItemData(cbPeriodStart, cbPeriodStart.SelectedIndex)
					.nPeriodEndSeq = VB6.GetItemData(cbPeriodEnd, cbPeriodEnd.SelectedIndex)
					.sReportTitle = "Report Test"
				End With
				If cbStateId.Text = "<All>" Then
					rptUniversalParam.sStateId = "All"
				End If
				
				'Period/Date Flag
				If obSinglePeriod.Checked = True Then
					rptUniversalParam.sPeriodSeq = "P"
					rptUniversalParam.nPeriodSeqFrom = 0
					rptUniversalParam.nPeriodSeqTo = 0
					rptUniversalParam.sStartDate = lbStartDate.Text
					rptUniversalParam.sEndDate = lbEndDate.Text
					
					If obPeriodNameSingle.Checked = True Then
						rptUniversalParam.sPeriodName = "T"
					Else
						rptUniversalParam.sPeriodName = "F"
					End If
				End If
				
				If obRangePeriod.Checked = True Then
					rptUniversalParam.sPeriodSeq = "R"
					rptUniversalParam.nPeriodSeqFrom = VB6.GetItemData(cbPeriodStart, cbPeriodStart.SelectedIndex)
					rptUniversalParam.nPeriodSeqTo = VB6.GetItemData(cbPeriodEnd, cbPeriodEnd.SelectedIndex)
					rptUniversalParam.sStartDate = lbPeriodStartDate.Text
					rptUniversalParam.sEndDate = lbPeriodEndDate.Text
					
					If obPeriodNameRange.Checked = True Then
						rptUniversalParam.sPeriodName = "T"
					Else
						rptUniversalParam.sPeriodName = "F"
					End If
					
				End If
				
				If obRange.Checked = True Then
					rptUniversalParam.sPeriodSeq = "D"
					rptUniversalParam.nPeriodSeqFrom = 0
					rptUniversalParam.nPeriodSeqTo = 0
                    rptUniversalParam.sStartDate = dtStartDate.Value
                    rptUniversalParam.sEndDate = dtEndDate.Value
                    rptUniversalParam.sPeriodName = ""
				End If
				
				'Caption
				If Len(txtReportCaption.Text) = 0 Then
					rptUniversalParam.sReportCaption = ""
				Else
					rptUniversalParam.sReportCaption = Trim(quotation_mask(txtReportCaption.Text))
				End If
				
				'Report Title
				rptUniversalParam.sReportTitle = Trim(quotation_mask(txtReportTitle.Text))
				
				'Obtiened ReportId y Carga RptCostContTmp usando criterios de seleccion
				If cbWithoutEqpt.CheckState = System.Windows.Forms.CheckState.Checked Then
					bFlagWithoutEqpt = True
				Else
					bFlagWithoutEqpt = False
				End If
				
				If cbInvoiceEqpt.CheckState = System.Windows.Forms.CheckState.Checked Then
					bFlagInvoiceEqpt = True
				Else
					bFlagInvoiceEqpt = False
				End If
				
                sb.Items(0).Text = "Building query...."

				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
				
				If build_query(bFlagWithoutEqpt, bFlagInvoiceEqpt) Then
					
					If Not insert_service_list(nReport) Then
						MsgBox("Failed to insert services. Aborting report", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
						Exit Sub
					End If
					
					
					log_report(nReport, "Universal Report", "sCustId", rptUniversalParam.sCustId)
					log_report(nReport, "Universal Report", "sStateId", rptUniversalParam.sStateId)
					log_report(nReport, "Universal Report", "nPeriodSeq", Str(rptUniversalParam.nPeriodSeq))
					log_report(nReport, "Universal Report", "nGroupSeq", Str(rptUniversalParam.nGroupSeq))
					log_report(nReport, "Universal Report", "sPeriodSeq", rptUniversalParam.sPeriodSeq)
					log_report(nReport, "Universal Report", "sStartDate", rptUniversalParam.sStartDate)
					log_report(nReport, "Universal Report", "sEndDate", rptUniversalParam.sEndDate)
					log_report(nReport, "Universal Report", "sReportCaption", rptUniversalParam.sReportCaption)
					log_report(nReport, "Universal Report", "nPeriodSeqFrom", Str(rptUniversalParam.nPeriodSeqFrom))
					log_report(nReport, "Universal Report", "nPeriodSeqTo", Str(rptUniversalParam.nPeriodSeqTo))
					log_report(nReport, "Universal Report", "sPeriodName", rptUniversalParam.sPeriodName)
					log_report(nReport, "Universal Report", "sReportTitle", rptUniversalParam.sReportTitle)
					'log_report nReport, "Universal Report", "sWhereService", rptUniversalParam.sServiceList
					
					
					
					
                    sb.Items(0).Text = "Processing Report..."
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
					
					ReportHandler2()
				End If
				
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
				
			End If
		End If
		
        sb.Items(0).Text = "Done"
		Exit Sub
		
ErrorHandler: 
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		save_error(Me.Name, "cmd_finish.click")
		MsgBox("Unexpected error found during report generation. Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
		
	End Sub
	
	Private Function insert_service_list(ByRef nReportId As Integer) As Boolean
		
		Dim nRecords As Short
        Dim sInsert As String
        Dim cmd As SqlCommand = cn.CreateCommand()
		
		On Error GoTo ErrorHandler
		
		insert_service_list = False
		
		sInsert = "INSERT INTO RptUniversalServiceTmp(report_id, serv_id) VALUES (" & Str(nReportId) & ","
        cmd.CommandText = sInsert
        cmd.CommandType = CommandType.Text

        For row As Integer = 0 To rsSelService.Rows.Count - 1
            sStmt = Trim(sInsert) & Str(rsSelService.Rows(row).Item("serv_id")) & ")"
            cmd.CommandText = sStmt
            nRecords = cmd.ExecuteNonQuery()
        Next

        'While rsSelService.   .Read()
        '    sStmt = Trim(sInsert) & Str(rsSelService.Item("serv_id")) & ")"
        '    cm.CommandText = sStmt
        '    nRecords = cm.ExecuteNonQuery()
        'End While
        insert_service_list = True
        Exit Function

ErrorHandler:
        save_error(Me.Name, "insert_service_list")



    End Function
	'Guarda parametros de reporte en RepLog
	Private Sub log_report(ByRef nReportId As Integer, ByRef sReportName As String, ByRef sParamName As String, ByRef sParamValue As String)
        Dim cmd As SqlCommand = cn.CreateCommand
        Dim nRecords As Object = New Object()
        'Dim i As Shor
		
		sStmt = "INSERT INTO RepLog (report_id, report_name, " & "param_name, param_value, create_user) " & " VALUES (" & Str(nReportId) & ",'" & sReportName & "'," & "'" & sParamName & "'," & "'" & sParamValue & "'," & "'" & gsUser & "')"
		
        cmd.CommandText = sStmt
        nRecords = cmd.ExecuteNonQuery()
		'UPGRADE_WARNING: Couldn't resolve default property of object nRecords. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If nRecords <= 0 Then
			write_error("*********Warning*************", sLogfile)
			write_error("FAILED TO LOG Report Parameters:" & sReportName, sLogfile)
			write_error("Report Id:" & Str(nReportId), sLogfile)
			write_error("*****************************", sLogfile)
		End If
		
		
		
	End Sub
	
	Private Function val_fields() As Boolean
		
		If Not val_fields_general Then
			val_fields = False
			Exit Function
		End If
		
		If Not val_fields_period Then
			val_fields = False
			Exit Function
		End If
		
		If Not val_fields_equipment Then
			val_fields = False
			Exit Function
		End If
		
		If Not val_fields_content Then
			val_fields = False
			Exit Function
		End If
		
		If Not val_fields_load Then
			val_fields = False
			Exit Function
		End If
		
		If Not val_fields_service Then
			val_fields = False
			Exit Function
		End If
		
		If Not val_fields_vendor Then
			Exit Function
		End If
		
		val_fields = True
		
	End Function
	Private Function val_fields_general() As Boolean
		
		On Error GoTo ErrorHandler
		
		'Cust
		If cbCustName.SelectedIndex < 0 Then
			MsgBox("You must choose a customer", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
			cbCustName.Focus()
			val_fields_general = False
			Exit Function
		End If
		
		'State
		If cbStateId.SelectedIndex < 0 Then
			MsgBox("You must select an State or All States option.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
			cbStateId.Focus()
			val_fields_general = False
			Exit Function
		End If
		
		'Store Group Name
		If cbGroupName.SelectedIndex < 0 Then
			MsgBox("You must select an store group.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
			cbGroupName.Focus()
			val_fields_general = False
			Exit Function
		Else
			'group_seq
			If VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex) > 0 Then
				'Ok
			Else
				MsgBox("Unable to get Store Group info", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
				cbGroupName.Focus()
				val_fields_general = False
				Exit Function
			End If
		End If
		
		'Report Template
		If cbReportTemplate.SelectedIndex < 0 Then
			val_fields_general = False
			MsgBox("Please select Report Template", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
			Exit Function
		End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(cbReportTemplate.Text) Then
			val_fields_general = False
			MsgBox("Please select Report Template", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
			Exit Function
		End If
		
		'ReportTitle
		If Len(txtReportTitle.Text) <= 0 Then
			val_fields_general = False
			MsgBox("Please Enter Report Title", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
			Exit Function
		End If
		
		val_fields_general = True
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "val_fields_general")
		MsgBox("Unable to validate data. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Function
	Private Function val_fields_period() As Boolean
		
		
		On Error GoTo ErrorHandler
		
		'obSinglePeriod
		If obSinglePeriod.Checked = False And obRange.Checked = False And obRangePeriod.Checked = False Then
			MsgBox(" You must select and Invoicing Period or Date Range")
			val_fields_period = False
			Exit Function
		End If
		
		If obSinglePeriod.Checked = True Then
			If cbPeriodName.SelectedIndex < 0 Then
				MsgBox("You must select an Invoicing period.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
				cbPeriodName.Focus()
				val_fields_period = False
				Exit Function
			Else
				If IsDate(lbStartDate.Text) And IsDate(lbEndDate.Text) Then
					'fechas ok
				Else
					MsgBox("Invoicing period must be corrected, you can change this" & vbCrLf & "on Inputs- Invoicing Period menu option", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
					val_fields_period = False
					Exit Function
				End If
			End If
			
			If obPeriodNameSingle.Checked = False And obPeriodDateSingle.Checked = False Then
				val_fields_period = False
				MsgBox("You must select Period Name or Period Date", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
				Exit Function
			End If
		End If
		
		'obRangePeriod
		If obRangePeriod.Checked = True Then
			If cbPeriodStart.SelectedIndex < 0 Or cbPeriodEnd.SelectedIndex < 0 Then
				MsgBox("You must select an Invoicing Start and End period.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
				cbPeriodStart.Focus()
				val_fields_period = False
				Exit Function
			Else
				If IsDate(lbPeriodStartDate.Text) And IsDate(lbPeriodEndDate.Text) Then
					If CDate(lbPeriodStartDate.Text) > CDate(lbPeriodEndDate.Text) Then
						MsgBox("Invoicing Start Period must be less than End Period Date", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
						cbPeriodStart.Focus()
						val_fields_period = False
						Exit Function
					End If
				Else
					MsgBox("Start-End Invoicing periods must be corrected, you can change this" & vbCrLf & "on Inputs- Invoicing Period menu option", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
					val_fields_period = False
					Exit Function
				End If
			End If
			
			If obPeriodNameRange.Checked = False And obPeriodDateRange.Checked = False Then
				val_fields_period = False
				MsgBox("You must select Period Name or Period Date", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
				Exit Function
			End If
			
		End If
		
		'obRange
		If obRange.Checked = True Then
            If dtStartDate.Value > dtEndDate.Value Then
                MsgBox("Start Date must be less than End Date.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
                val_fields_period = False
                Exit Function
            End If
		End If
		val_fields_period = True
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "val_fields_period")
		MsgBox("Unable to validate data. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
	End Function
	Private Function get_criteria() As Boolean
        Dim sPeriod As String = ""
        Dim cmd As SqlCommand = cn.CreateCommand()
		'Periods
		'*****Customer
		sWherePeriod = " AND vInvoice.cust_id ='" & cbCustId.Text & "'"
		
		'*****State
		If cbStateId.SelectedIndex = 0 Then
			'All
		Else
			sWherePeriod = sWherePeriod & " AND Store.state_id = '" & cbStateId.Text & "'"
		End If
		
		'*****StoreGroup
		
		If cbGroupName.Text = "All" Then
			'All
		Else
			sWherePeriod = sWherePeriod & " AND Store.store_id IN ( SELECT store_id FROM groupStore " & " WHERE groupStore.cust_id = Store.cust_id  " & " AND groupStore.group_seq =" & Str(VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex)) & ")"
			
		End If
		
		If obSinglePeriod.Checked = True Then
			sWherePeriod = sWherePeriod & " AND vInvoice.period_seq =" & Str(VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex))
			
		ElseIf obRangePeriod.Checked Then 
			
			sStmt = "SELECT period_seq FROM period a " & " WHERE cust_id='" & Trim(cbCustId.Text) & "' " & " AND period_start_date >=(SELECT period_start_date FROM period b " & " WHERE b.cust_id = a.cust_id " & " AND b.period_seq=" & Str(VB6.GetItemData(cbPeriodStart, cbPeriodStart.SelectedIndex)) & ")" & " AND period_end_date <=(SELECT period_end_date FROM period c " & " WHERE c.cust_id = a.cust_id " & " AND c.period_seq=" & Str(VB6.GetItemData(cbPeriodEnd, cbPeriodEnd.SelectedIndex)) & ")"
            cmd.CommandText = sStmt
			
            rs = getDataTable(sStmt) ' cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rs.Rows.Count > 0 Then
                For row As Integer = 0 To rs.Rows.Count - 1
                    sPeriod = sPeriod & Str(rs.Rows(0).Item("period_seq")) & ","
                Next

                'While Not rs.Read()
                '    sPeriod = sPeriod & Str(rs.Item("period_seq")) & ","
                'End While
                sPeriod = VB.Left(sPeriod, Len(sPeriod) - 1)
            End If


            sWherePeriod = sWherePeriod & " AND vInvoice.period_seq IN (" & sPeriod & ")"
        ElseIf obRange.Checked Then
            sWherePeriod = sWherePeriod & "AND vInvoice.vinvoice_date BETWEEN " & _
                "'" & dtStartDate.Value.ToString() & "' " & _
                " AND '" & dtEndDate.Value.ToString() & "'"
        End If

        'MsgBox sWherePeriod
        'Exit Function

        'Equipment
        If bAllEquipmentSelected Then
            'ok
            sWhereEquipment = ""
        Else
            sWhereEquipment = "AND StoreEqpt.eqpt_id IN ("

            For row As Integer = 0 To rsSelEquipment.Rows.Count - 1
                sWhereEquipment = sWhereEquipment & Str(rsSelEquipment.Rows(row).Item("eqpt_id")) & ","
            Next

            'While rsSelEquipment.Read()
            '    sWhereEquipment = sWhereEquipment & Str(rsSelEquipment.Item("eqpt_id")) & ","
            'End While
            sWhereEquipment = VB.Left(sWhereEquipment, Len(sWhereEquipment) - 1) & ")"
        End If

        If sEqptTemp = "" Then
            'ok
            sWhereEqptTemp = ""
        Else
            sWhereEqptTemp = "AND StoreEqpt.eqpt_temp ='" & sEqptTemp & "' "
        End If

        'Contents
        If bAllContentSelected Then
            sWhereContent = ""
        Else

            sWhereContent = "AND StoreEqpt.content_id IN ("

            For row As Integer = 0 To rsSelContent.Rows.Count - 1
                sWhereContent = sWhereContent & Str(rsSelContent.Rows(row).Item("content_id")) & ","
            Next

            'While rsSelContent.Read()
            '    sWhereContent = sWhereContent & Str(rsSelContent.Item("content_id")) & ","
            'End While
            sWhereContent = VB.Left(sWhereContent, Len(sWhereContent) - 1) & ")"
        End If


        'Load
        If bAllLoadSelected Then
            sWhereLoad = ""
        Else
            sWhereLoad = "AND StoreEqpt.load_id IN ("
            For row As Integer = 0 To rsSelLoad.Rows.Count - 1
                sWhereLoad = sWhereLoad & "'" + rsSelLoad.Rows(row).Item("load_id") + "',"
            Next
            'While rsSelLoad.Read()
            '    sWhereLoad = sWhereLoad & "'" + rsSelLoad.Item("load_id") + "',"
            'End While
            sWhereLoad = VB.Left(sWhereLoad, Len(sWhereLoad) - 1) & ")"
        End If

        'Service
        If bAllServiceSelected Then
            sWhereService = ""
            sServiceList = ""
        Else
            sWhereService = "AND vInvoiceDet.serv_id IN ("

            For row As Integer = 0 To rsSelService.Rows.Count - 1
                sWhereService = sWhereService & Str(rsSelService.Rows(row).Item("serv_id")) & ","
                sServiceList = sServiceList & Str(rsSelService.Rows(row).Item("serv_id")) & ","
            Next

            'While rsSelService.Read()
            '    sWhereService = sWhereService & Str(rsSelService.Item("serv_id")) & ","
            '    sServiceList = sServiceList & Str(rsSelService.Item("serv_id")) & ","
            'End While
            sWhereService = VB.Left(sWhereService, Len(sWhereService) - 1) & ")"
            sServiceList = VB.Left(sServiceList, Len(sServiceList) - 1)
        End If

        'Vendor
        If bAllVendorSelected Then
            sWhereVendor = ""
        Else
            sWhereVendor = " AND vBranch.vend_id IN ("
            For row As Integer = 0 To rsSelVendor.Rows.Count - 1
                sWhereVendor = sWhereVendor & Str(rsSelVendor.Rows(row).Item("vend_id")) & ","
            Next
            'While rsSelVendor.Read()
            '    sWhereVendor = sWhereVendor & Str(rsSelVendor.Item("vend_id")) & ","
            'End While
            sWhereVendor = VB.Left(sWhereVendor, Len(sWhereVendor) - 1) & ")"
        End If

        sWhere = sWherePeriod & vbCrLf & sWhereEquipment & vbCrLf & sWhereEqptTemp & vbCrLf & sWhereContent & vbCrLf & sWhereLoad & vbCrLf & sWhereService & vbCrLf & sWhereVendor

        sWhere1 = sWherePeriod & vbCrLf & sWhereEquipment & vbCrLf & sWhereEqptTemp & vbCrLf & sWhereContent & vbCrLf & sWhereLoad & vbCrLf & sWhereService & vbCrLf & sWhereVendor

        sWhere2 = sWherePeriod & vbCrLf & sWhereService & vbCrLf & sWhereVendor


        'MsgBox sWhere
        get_criteria = True
        Exit Function

ErrorHandler:
        get_criteria = False
        save_error(Me.Name, "get_criteria")
        MsgBox("Failed to Build Query conditions." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
	End Function
	
	Private Sub cmdLeftContent_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLeftContent.Click
		
		sField = "content_id"
		'sSort = "content_type, content_desc"
		sSort = "Type, Description"
		move_member(dgSelContent, dgContent, rsSelContent, rsContent, sField, sSort)
		
	End Sub
	
	Private Sub cmdLeftEquipment_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLeftEquipment.Click
		'del_member_equipment
		
		sField = "eqpt_id"
		sSort = "eqpt_type_desc, eqpt_size"
		
		move_member(dgSelEquipment, dgEquipment, rsSelEquipment, rsEquipment, sField, sSort)
		
	End Sub
	
	
	
	Private Sub cmdLeftLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLeftLoad.Click
		sField = "load_id"
		sSort = "load_desc"
		move_member(dgSelLoad, dgLoad, rsSelLoad, rsLoad, sField, sSort, False)
		
	End Sub
	
	Private Sub cmdLeftServ_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLeftServ.Click
		sField = "serv_id"
		sSort = "serv_desc"
        move_member(dgSelService, dgService, rsSelService, rsService, sField, sSort, True)
		
		
	End Sub
	
	Private Sub cmdLeftVendor_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLeftVendor.Click
		sField = "vend_id"
		sSort = "vend_name"
		move_member(dgSelVendor, dgVendor, rsSelVendor, rsVendor, sField, sSort, True)
		
	End Sub
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
		
		'Verifica si usuario seleciono datos antes de continuar
		Select Case frCriteria(nFrameIndex).Text
			Case "General"
				If Not val_fields_general Then
					Exit Sub
				End If
			Case "Period"
				If Not val_fields_period Then
					Exit Sub
				End If
			Case "Equipment"
				If Not val_fields_equipment Then
					Exit Sub
				End If
			Case "Content"
				If Not val_fields_content Then
					Exit Sub
				End If
			Case "Load"
				If Not val_fields_load Then
					Exit Sub
				End If
			Case "Service"
				If Not val_fields_service Then
					Exit Sub
				End If
			Case "Vendor"
				If Not val_fields_vendor Then
					Exit Sub
				End If
		End Select
		
		
		'Activa el siguiente frame
		If nFrameIndex <= frCriteria.Count - 1 Then
			frCriteria(nFrameIndex).Visible = False
			nFrameIndex = nFrameIndex + 1
			
			frCriteria(nFrameIndex).Visible = True
			cmdPrev.Enabled = True
			
			If nFrameIndex = frCriteria.Count - 1 Then
				cmdNext.Enabled = False
				cmdFinish.Enabled = True
			End If
		End If
		
		If frCriteria(nFrameIndex).Text = "Vendor" Then
			load_vendor()
		End If
		
	End Sub
	
	
	
	Private Sub cmdPrev_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrev.Click
		'Select Case frCriteria(nFrameIndex).Caption
		'Case "General"
		'    If Not val_fields_general Then
		'        Exit Sub
		'    End If
		'Case "Period"
		'    If Not val_fields_period Then
		'        Exit Sub
		'    End If
		'Case "Equipment"
		'    If Not val_fields_equipment Then
		'        Exit Sub
		'    End If
		'Case "Content"
		'    If Not val_fields_content Then
		'        Exit Sub
		'    End If
		'Case "Load"
		'    If Not val_fields_load Then
		'        Exit Sub
		'    End If
		'Case "Service"
		'    If Not val_fields_service Then
		'        Exit Sub
		'    End If
		'Case "Vendor"
		'    If Not val_fields_vendor Then
		'        Exit Sub
		'    End If
		'End Select
		
		If nFrameIndex >= 0 Then
			frCriteria(nFrameIndex).Visible = False
			If nFrameIndex = frCriteria.Count - 1 Then
				cmdFinish.Enabled = False
			End If
			
			nFrameIndex = nFrameIndex - 1
			frCriteria(nFrameIndex).Visible = True
			cmdNext.Enabled = True
			
			If nFrameIndex = 0 Then
				cmdPrev.Enabled = False
			End If
		End If
		
		If frCriteria(nFrameIndex).Text = "Vendor" Then
			load_vendor()
		End If
		
	End Sub
	
	Private Sub cmdRightContent_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRightContent.Click
		
		sField = "content_id"
		'sSort = "content_type, content_desc"
		sSort = "Type, Description"
		move_member(dgContent, dgSelContent, rsContent, rsSelContent, sField, sSort)
		
	End Sub
	
	Private Sub cmdRightEquipment_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRightEquipment.Click
		'add_member_equipment
		
		sField = "eqpt_id"
		sSort = "eqpt_type_desc, eqpt_size"
		
		move_member(dgEquipment, dgSelEquipment, rsEquipment, rsSelEquipment, sField, sSort)
		
		
		
	End Sub
	
	Private Sub cmdRightLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRightLoad.Click
		sField = "load_id"
		sSort = "load_desc"
		move_member(dgLoad, dgSelLoad, rsLoad, rsSelLoad, sField, sSort, False)
		
	End Sub
	
	Private Sub cmdRightServ_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRightServ.Click
		sField = "serv_id"
		sSort = "serv_desc"
		move_member(dgService, dgSelService, rsService, rsSelService, sField, sSort, True)
		
	End Sub
	
	Private Sub cmdRightVendor_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRightVendor.Click
		sField = "vend_id"
		sSort = "vend_name"
		move_member(dgVendor, dgSelVendor, rsVendor, rsSelVendor, sField, sSort, True)
		
	End Sub
	
    Private Sub dgContent_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        sField = "content_id"
        'sSort = "content_type, content_desc"
        sSort = "Type, Description"
        move_member(dgContent, dgSelContent, rsContent, rsSelContent, sField, sSort)
    End Sub
	
    Private Sub dgEquipment_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'add_member_equipment
        sField = "eqpt_id"
        sSort = "eqpt_type_desc, eqpt_size"

        move_member(dgEquipment, dgSelEquipment, rsEquipment, rsSelEquipment, sField, sSort)

    End Sub
	
    Private Sub dgLoad_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        sField = "load_id"
        sSort = "load_desc"
        move_member(dgLoad, dgSelLoad, rsLoad, rsSelLoad, sField, sSort, False)

    End Sub
	
    Private Sub dgSelContent_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        sField = "content_id"
        'sSort = "content_type, content_desc"
        sSort = "Type, Description"
        move_member(dgSelContent, dgContent, rsSelContent, rsContent, sField, sSort)
    End Sub
	
    Private Sub dgSelEquipment_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'del_member_equipment
        sField = "eqpt_id"
        sSort = "eqpt_type_desc, eqpt_size"

        move_member(dgSelEquipment, dgEquipment, rsSelEquipment, rsEquipment, sField, sSort)

    End Sub
	
    Private Sub dgSelLoad_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        sField = "load_id"
        sSort = "load_desc"
        move_member(dgSelLoad, dgLoad, rsSelLoad, rsLoad, sField, sSort, False)

    End Sub
	
    Private Sub dgSelService_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        sField = "serv_id"
        sSort = "serv_desc"
        move_member(dgSelService, dgService, rsSelService, rsService, sField, sSort, True)

    End Sub
	
    Private Sub dgSelVendor_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        sField = "vend_id"
        sSort = "vend_name"
        move_member(dgSelVendor, dgVendor, rsSelVendor, rsVendor, sField, sSort, True)

    End Sub
	
    Private Sub dgService_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        sField = "serv_id"
        sSort = "serv_desc"
        move_member(dgService, dgSelService, rsService, rsSelService, sField, sSort, True)

    End Sub
	
    Private Sub dgVendor_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        sField = "vend_id"
        sSort = "vend_name"
        move_member(dgVendor, dgSelVendor, rsVendor, rsSelVendor, sField, sSort, True)

    End Sub
	
	'UPGRADE_WARNING: Form event frmRepUniversal.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub frmRepUniversal_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		If nFrameIndex = 0 Then
			cbCustName.Focus()
		End If
		
	End Sub
	
	Private Sub frmRepUniversal_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	Private Sub init_vars()
		Dim fr As System.Windows.Forms.GroupBox
		Dim i As Short
		
		Me.Width = VB6.TwipsToPixelsX(7320)
        Me.Height = VB6.TwipsToPixelsY(9550) '9450
		For i = 0 To frCriteria.Count - 1
			frCriteria(i).Top = VB6.TwipsToPixelsY(480)
			frCriteria(i).Left = VB6.TwipsToPixelsX(240)
		Next i
		
		sLocalVersion = "DEFAULT"
		sLocalReport = gReport.name
		'Inicializo variables
        'rsLocal = New SqlDataReader
        'rsReport = New SqlDataReader
        'rsEquipment = New SqlDataReader
        'rsSelEquipment = New SqlDataReader
        'rsContent = New SqlDataReader
        'rsSelContent = New SqlDataReader
        'rsLoad = New SqlDataReader
        'rsSelLoad = New SqlDataReader
        'rsService = New SqlDataReader
        'rsSelService = New SqlDataReader
        'rsVendor = New SqlDataReader
        'rsSelVendor = New SqlDataReader
        'rsReportTemplate = New SqlDataReader
		
        dgEquipment.ColumnHeadersVisible = False
        dgSelEquipment.ColumnHeadersVisible = False
        dgContent.ColumnHeadersVisible = True
        dgSelContent.ColumnHeadersVisible = True
        dgLoad.ColumnHeadersVisible = False
        dgSelLoad.ColumnHeadersVisible = False
        dgService.ColumnHeadersVisible = False
        dgSelService.ColumnHeadersVisible = False
        dgVendor.ColumnHeadersVisible = False
        dgSelVendor.ColumnHeadersVisible = False

        dgSelEquipment.DefaultCellStyle.ForeColor = Color.Black
		
        'rsEquipment.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rsSelEquipment.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rsContent.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rsSelContent.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rsLoad.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rsSelLoad.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rsService.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rsSelService.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rsVendor.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rsSelVendor.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		
		cmdNext.Enabled = True
		cmdFinish.Enabled = False
		cmdPrev.Enabled = False
		
		sPrevCustId = ""
		sPrevStateId = ""
		
		'**********************General**********************
		
		bAllEquipmentSelected = False
		lbStartDate.Text = ""
		lbEndDate.Text = ""
        txtReportCaption.MaxLength = 30 'customer.cust_report_name CHAR(30)
        txtReportTitle.MaxLength = 50
		
		txtReportTitle.Text = "Universal Report"
		cbWithoutEqpt.CheckState = System.Windows.Forms.CheckState.Checked
		
		'**********************Periods and Dates**********************
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
		
        'Combo State
        cbStateId.Items.Clear()
		cbStateId.Items.Insert(0, "<All>")
		
		sStmt = "SELECT state_id FROM state"
		load_cb_query2(cbStateId, sStmt, 1, False)
		
		If cbStateId.Items.Count > 0 Then
			cbStateId.SelectedIndex = 0
		End If
		
		'Combo Report Template
		sStmt = "SELECT rep_template_name, col_order " & "FROM RepDef a, RepDefTemplate b " & " WHERE a.rep_no = b.rep_no " & " AND a.rep_caption ='" & sLocalReport & "' " & " ORDER BY col_order "
		load_cb_query2(cbReportTemplate, sStmt, 1, True)
		
		If cbReportTemplate.Items.Count > 0 Then
			cbReportTemplate.SelectedIndex = 0
		End If
		
		'Esconder todos los frames
		i = 0
		For	Each fr In frCriteria
			fr.Visible = False
            'fr.BorderStyle = 0
			frCriteria(nFrameIndex).Top = VB6.TwipsToPixelsY(480)
			frCriteria(nFrameIndex).Left = VB6.TwipsToPixelsX(240)
			
			
			lbTitle(i).Top = 0
			lbTitle(i).Left = 0
			lbTitle(i).Width = frCriteria(nFrameIndex).Width
			lbTitle(i).Height = VB6.TwipsToPixelsY(270)
			i = i + 1
		Next fr
		
		nFrameIndex = 0
		frCriteria(nFrameIndex).Visible = True
		
		
		'******************** Equipment *********************
		
		obEquipment(0).Text = "Permanent"
		obEquipment(0).Checked = False
		
		obEquipment(1).Text = "Temporary"
		obEquipment(1).Checked = False
		
		obEquipment(2).Text = "All"
		obEquipment(2).Checked = True

        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.5)
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        'DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        'DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.White

        DataGridView2.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.5)
        DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        'DataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        'DataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.White

		load_equipment()
		load_SelEquipment()
		
        '******************* Content ************************
        DataGridView3.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.5)
        DataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

        DataGridView4.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.5)
        DataGridView4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

        load_content()
		load_SelContent()
		
		
        '******************* Load ************************
        DataGridView5.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.5)
        DataGridView5.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

        DataGridView6.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.5)
        DataGridView6.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

		load_load()
		load_SelLoad()
		
        '******************* Service *********************
        DataGridView6.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.5)
        DataGridView6.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

        DataGridView7.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.5)
        DataGridView7.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

		load_service()
		load_SelService()
		
        '******************* Vendor **********************
        DataGridView8.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.5)
        DataGridView8.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

        DataGridView9.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.5)
        DataGridView9.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

        sb.Enabled = True
        sb.ForeColor = Color.Black
        sb.Items(0).Text = "Universal Report"
        sb.Visible = True
		
	End Sub
	Private Sub period_enable(ByRef bOption As Boolean)
		cbPeriodName.Enabled = bOption
		obPeriodNameSingle.Enabled = bOption
		obPeriodDateSingle.Enabled = bOption
	End Sub
	Private Sub period_range_enable(ByRef bOption As Boolean)
		cbPeriodStart.Enabled = bOption
		cbPeriodEnd.Enabled = bOption
		obPeriodNameRange.Enabled = bOption
		obPeriodDateRange.Enabled = bOption
	End Sub
	Private Sub range_enable(ByRef bOption As Boolean)
		dtStartDate.Enabled = bOption
		dtEndDate.Enabled = bOption
	End Sub
	
	
	
	
	
    Private Sub frmRepUniversal_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'UPGRADE_NOTE: Object rsVendor may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rsVendor = Nothing
        If MsgBox("Close Universal Report Wizard?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "GLM Message") = MsgBoxResult.No Then
            'UPGRADE_ISSUE: Event parameter Cancel was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
            eventArgs.Cancel = True
        End If
        'sPrevCustId = ""
        'sPrevStateId = ""
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
	
	
	
	Private Sub load_equipment()
        Dim cmd As SqlCommand = cn.CreateCommand
        Dim da As SqlDataAdapter = New SqlDataAdapter
        Dim ds As DataSet = New DataSet("dset")

		On Error GoTo ErrorHandler
		
		sStmt = "SELECT eqpt_id, eqpt_desc, eqpt_type_desc, eqpt_size  " & "FROM equipment " & " ORDER BY eqpt_type_desc, eqpt_size "
        cmd.CommandText = sStmt
        da.SelectCommand = cmd
        da.Fill(ds)
        rsEquipment = ds.Tables(0) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)
        dgEquipment.DataSource = rsEquipment
        addPrimaryKey(rsEquipment, "eqpt_id")

        'dgEquipment.ColumnHeadersVisible = True

        'dgEquipment.Columns("eqpt_desc").HeaderText = "Equipment Types"
		dgEquipment.Columns("eqpt_id").Visible = False
		dgEquipment.Columns("eqpt_type_desc").Visible = False
		dgEquipment.Columns("eqpt_size").Visible = False
        dgEquipment.Columns("eqpt_id").Width = VB6.TwipsToPixelsX(2400)
        dgEquipment.DefaultCellStyle.Font = New Font("Arial", 8)
        dgEquipment.DefaultCellStyle.ForeColor = Color.Black
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_equipment")
		MsgBox("Failed to load Equipment data. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Sub
	
	Public Sub load_SelEquipment()
        Dim cmd As SqlCommand = cn.CreateCommand()
        Dim daEquipment As SqlDataAdapter = New SqlDataAdapter
        Dim ds As DataSet = New DataSet("ds")
        sStmt = "SELECT eqpt_id, eqpt_desc, eqpt_type_desc, eqpt_size " & "FROM equipment " & " WHERE eqpt_id=-1"
        cmd.CommandText = sStmt
        daEquipment.SelectCommand = cmd
        daEquipment.Fill(ds)

        'rsSelEquipment = cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)
        rsSelEquipment = ds.Tables(0)
        addPrimaryKey(rsSelEquipment, "eqpt_id")
        dgSelEquipment.DataSource = rsSelEquipment

		
        'dgSelEquipment.ColumnHeadersVisible = True
        'dgSelEquipment.Columns("eqpt_desc").HeaderText = "Selected Equipment"

		dgSelEquipment.Columns("eqpt_id").Visible = False
		dgSelEquipment.Columns("eqpt_type_desc").Visible = False
		dgSelEquipment.Columns("eqpt_size").Visible = False
        dgSelEquipment.Columns("eqpt_id").Width = VB6.TwipsToPixelsX(2400)
        dgSelEquipment.DefaultCellStyle.Font = New Font("Arial", 8)
        dgSelEquipment.DefaultCellStyle.ForeColor = Color.Black
		
	End Sub
	Private Sub add_all_member_equipment()
        Dim dtTmp As DataTable = New DataTable()
        Dim nRecords As Integer = 0
		Dim i As Short

        If rsEquipment.Rows.Count > 0 Then

            'drTmp = rsEquipment
            For i = 0 To rsEquipment.Rows.Count - 1
                dtTmp.Columns.Add(rsEquipment.Columns(i).ColumnName, System.Type.GetType("System.String"))
            Next i

            'While drTmp.Read()
            '    nRecords += 1
            'End While

            For row As Integer = 0 To rsEquipment.Rows.Count - 1
                Dim drowTmp As DataRow = dtTmp.NewRow()
                For column As Integer = 0 To nRecords - 1
                    rsSelEquipment.Rows(row).Item(column) = rsEquipment.Rows(row).Item(column)
                    'drowTmp.Item(i) = rsEquipment.Item(i)
                    '.Item(i) = rsEquipment.Item(i)
                Next column
                'dtTmp.Rows.Add(drowTmp)
            Next row

            'While rsEquipment.Read()

            '    'rsSelEquipment.AddNew()
            '    Dim drowTmp As DataRow = dtTmp.NewRow()
            '    For i = 0 To nRecords - 1
            '        'rsSelEquipment.Item(i) = rsEquipment.Item(i)
            '        drowTmp.Item(i) = rsEquipment.Item(i)
            '        '.Item(i) = rsEquipment.Item(i)
            '    Next i
            '    dtTmp.Rows.Add(drowTmp)
            '    'rsSelEquipment.Update()

            '    'rsEquipment.Delete(ADODB.AffectEnum.adAffectCurrent)
            '    'rsEquipment.MoveNext()
            'End While


            'rsSelEquipment.Sort = "eqpt_desc"
            'rsSelEquipment.Sort = "eqpt_type_desc, eqpt_size"
        End If
		
		
	End Sub
	
	'Agrega equipos a dgSelEquipment desde dgEquipment
	Private Sub add_member_equipment()
        Dim vRow As DataGridViewRow
		Dim sCriteria As String
		Dim i As Short
		
		On Error GoTo ErrorHandler
		
		'Label12.Caption = dgEquipment.SelBookmarks.Count
        For Each vRow In dgEquipment.SelectedRows
            'rsEquipment.Bookmark = vRow 'Muevo el recordset a la fila seleccionada

            'Verifico si tienda ya existe en recordset
            sCriteria = "eqpt_id=" & Str(rsEquipment.Rows(vRow.Index).Item("eqpt_id"))
            If record_exist(rsSelEquipment, sCriteria) = False Then
                'rsSelEquipment.AddNew()
                Dim drowTmp As DataRow = rsSelEquipment.NewRow()
                For column As Integer = 0 To rsEquipment.Columns.Count - 1
                    drowTmp.Item(column) = rsEquipment.Rows(vRow.Index).Item(column)
                    'rsSelEquipment.Rows(vRow).Item(i) = rsEquipment.Rows(vRow).Item(i)
                Next column
                rsSelEquipment.Rows.Add(drowTmp)
                'rsSelEquipment("eqpt_id") = rsEquipment("eqpt_id")
                'rsSelEquipment("eqpt_desc") = rsEquipment("eqpt_desc")

                'rsSelEquipment.Sort = "eqpt_desc"

                'rsSelEquipment.Sort = "eqpt_type_desc, eqpt_size"
            End If

            'rsEquipment.Delete(ADODB.AffectEnum.adAffectCurrent)
        Next vRow
		
		
        'Do While dgEquipment.SelectedRows.Count
        dgEquipment.ClearSelection()
        'dgEquipment.SelBookmarks.Remove(0)
        'Loop


        Exit Sub

ErrorHandler:
        save_error(Me.Name, "add_member_equipment")
        MsgBox("Unexpected error found. Check log for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
		
	End Sub
	
	Private Sub del_all_member_equipment()
		Dim i As Short
		
        If rsSelEquipment.Rows.Count > 0 Then

            For row As Integer = 0 To rsSelEquipment.Rows.Count - 1
                Dim drowTmp As DataRow = rsSelEquipment.NewRow()
                For i = 0 To rsSelEquipment.Rows.Count - 1
                    'rsEquipment.Rows(row).Item(i) = rsSelEquipment.Rows(row).Item(i)
                    drowTmp.Item(i) = rsSelEquipment.Rows(row).Item(i)
                Next i
                rsEquipment.Rows.Add(drowTmp)
                'rsEquipment.Update()

                'rsSelEquipment.Delete(ADODB.AffectEnum.adAffectCurrent)
                'rsSelEquipment.MoveNext()
            Next

            'While Not rsSelEquipment.EOF
            '    rsEquipment.AddNew()
            '    For i = 0 To rsSelEquipment.Fields.Count - 1
            '        rsEquipment.item(i) = rsSelEquipment.item(i)
            '    Next i
            '    rsEquipment.Update()

            '    rsSelEquipment.Delete(ADODB.AffectEnum.adAffectCurrent)
            '    rsSelEquipment.MoveNext()
            'End While


            'rsEquipment.Sort = "eqpt_desc"
            'rsEquipment.Sort = "eqpt_type_desc, eqpt_size"
        End If
		
		
	End Sub
	Private Sub del_member_equipment()
        Dim vRow As DataGridViewRow
		Dim sCriteria As String

        For Each vRow In dgSelEquipment.SelectedRows
            'rsSelEquipment.Bookmark = vRow 'Muevo el recordset a la fila seleccionada
            'Verifico si tienda ya existe en recordset

            sCriteria = "eqpt_id=" & Str(rsSelEquipment.Rows(vRow.Index).Item("eqpt_id"))
            Dim drow As DataRow = rsSelEquipment.NewRow()
            If record_exist(rsEquipment, sCriteria) = False Then
                'rsEquipment.AddNew()
                For column As Integer = 0 To rsSelEquipment.Columns.Count - 1
                    drow.Item(column) = rsSelEquipment.Rows(vRow.Index).Item(column)
                    'rsEquipment.item(column) = rsSelEquipment.Rows(vRow).Item(column)
                Next column
                rsEquipment.Rows.Add(drow)
                'rsEquipment("eqpt_id") = rsSelEquipment("eqpt_id")
                'rsEquipment("eqpt_desc") = rsSelEquipment("eqpt_desc")

                'rsEquipment.Update()

                rsEquipment.Select("eqpt_type_desc, eqpt_size") '   .Sort = "eqpt_type_desc, eqpt_size"
            End If
            'rsSelEquipment.Delete(ADODB.AffectEnum.adAffectCurrent)

        Next vRow
        dgSelEquipment.ClearSelection()
        'Do While dgSelEquipment.SelBookmarks.Count
        '	dgSelEquipment.SelBookmarks.Remove(0)
        'Loop 
		
	End Sub
	
	
	Private Function val_fields_equipment() As Boolean
		Dim i As Short
		
		On Error GoTo ErrorHandler
		
		sEqptTemp = ""
		For i = 0 To obEquipment.Count - 1
			If obEquipment(i).Checked Then
				sEqptTemp = obEquipment(i).Text
			End If
			
		Next i
		
		If sEqptTemp = "" Then
			val_fields_equipment = False
			MsgBox("Please select Equipment Availability.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			Exit Function
		Else
			Select Case sEqptTemp
				Case "Permanent"
					sEqptTemp = "P"
				Case "Temporary"
					sEqptTemp = "T"
				Case "All"
					sEqptTemp = ""
			End Select
		End If
		
        If rsEquipment.Rows.Count = 0 Then
            bAllEquipmentSelected = True
        Else
            bAllEquipmentSelected = False
        End If
		
        If rsSelEquipment.Rows.Count = 0 Then
            val_fields_equipment = False
            MsgBox("Please select at least one equipment type.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Function
        End If
		
		val_fields_equipment = True
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "val_fields_equipment")
		MsgBox("Unexpected error found while checking equipment data." & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
		
	End Function
	Private Function val_fields_content() As Boolean
		
		On Error GoTo ErrorHandler
		
        If rsContent.Rows.Count = 0 Then
            bAllContentSelected = True
        Else
            bAllContentSelected = False
        End If
		
        If rsSelContent.Rows.Count = 0 Then
            val_fields_content = False
            MsgBox("Please select at least one record.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Warning")
            Exit Function
        End If
		
		val_fields_content = True
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "val_fields_content")
		MsgBox("Unexpected error found while checking content data." & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
	End Function
	Private Function val_fields_load() As Boolean
		
		On Error GoTo ErrorHandler
		
        If rsLoad.Rows.Count = 0 Then
            bAllLoadSelected = True
        Else
            bAllLoadSelected = False
        End If
		
        If rsSelLoad.Rows.Count = 0 Then
            val_fields_load = False
            MsgBox("Please select at least one record.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Warning")
            Exit Function
        End If
		
		val_fields_load = True
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "val_fields_load")
		MsgBox("Unexpected error found while checking load data." & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
	End Function
	
	
	Private Sub load_content()
        Dim cmd As SqlCommand = cn.CreateCommand()
        Dim da As SqlDataAdapter = New SqlDataAdapter
        Dim ds As DataSet = New DataSet("tmpDS")
		On Error GoTo ErrorHandler
		
		sStmt = "SELECT content_id, content_desc AS 'Description', content_type Type " & " FROM content" & " ORDER BY  'Description', Type "
        cmd.CommandText = sStmt
        da.SelectCommand = cmd
        da.Fill(ds)
        rsContent = ds.Tables(0) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)
        addPrimaryKey(rsContent, "content_id")
		dgContent.DataSource = rsContent
		
        dgContent.Columns("Description").Width = VB6.TwipsToPixelsX(2000)
        dgContent.ColumnHeadersDefaultCellStyle = dgContent.DefaultCellStyle
        dgContent.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgContent.Columns("content_id").Visible = False
        dgContent.DefaultCellStyle.Font = New Font("Arial", 8)
        dgContent.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8)
        dgContent.DefaultCellStyle.ForeColor = Color.Black

		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_content")
		MsgBox("Failed to load Content data. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
	End Sub
	Private Sub load_SelContent()
		
		On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand
        Dim da As SqlDataAdapter = New SqlDataAdapter
        Dim ds As DataSet = New DataSet("ds")
		sStmt = "SELECT content_id, content_desc as 'Description', content_type AS Type " & " FROM content" & " WHERE content_id=-1"
        cmd.CommandText = sStmt
        da.SelectCommand = cmd
        da.Fill(ds)
        rsSelContent = ds.Tables(0) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)
        addPrimaryKey(rsSelContent, "content_id")
		dgSelContent.DataSource = rsSelContent
		
		dgSelContent.Columns("Description").Width = VB6.TwipsToPixelsX(2400)
        dgSelContent.Columns("content_id").Visible = False
        dgSelContent.DefaultCellStyle.Font = New Font("Arial", 8)
        dgSelContent.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8)
        dgSelContent.DefaultCellStyle.ForeColor = Color.Black

		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_SelContent")
		MsgBox("Failed to load Content data. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
		
	End Sub
	'Mueve un registro desde dgSource a dgDestino
	'parametros
	'dgSource
	'dgDest
	'sField: Campo usado para busqueda y evitar duplicados en dgDestino
	'sSort: Campo(s) para ordenar recordset
	'bNumeric: Esta bandera se activa si sField es numerico,Falso si es string
    Private Sub move_member(ByRef dgSource As DataGridView, ByRef dgDest As DataGridView, ByRef rsSource As DataTable, ByRef rsDest As DataTable, ByRef sField As String, ByRef sSort As String, Optional ByRef bNumeric As Boolean = True)

        Dim vRow As DataGridViewRow
        Dim sCriteria As String
        Dim i As Short

        On Error GoTo ErrorHandler

        If dgSource.SelectedRows.Count = 0 Then
            If dgSource.SelectedCells.Count > 0 Then
                dgSource.Rows(dgSource.SelectedCells(0).RowIndex).Selected = True
            End If
        End If
        For Each vRow In dgSource.SelectedRows
            'rsSource.Bookmark = vRow 'Muevo el recordset a la fila seleccionada
            'Verifico si tienda ya existe en recordset

            'sCriteria = "eqpt_id=" + Str(rsSelEquipment.Rows(vRow.Index).Item("eqpt_id"))
            'sCriteria = "eqpt_id=" + Str(rsSource.Rows(vRow.Index).Item("eqpt_id"))
            If bNumeric Then
                sCriteria = sField & "=" & Str(rsSource.Rows(vRow.Index).Item(sField))
            Else
                sCriteria = sField & "='" + (rsSource.Rows(vRow.Index).Item(sField)) + "'"
            End If

            If record_exist(rsDest, sCriteria) = False Then
                'Dim drow As DataRow = rsSource.NewRow()
                'rsDest.AddNew()
                'For column As Integer = 0 To rsSource.Columns.Count - 1
                '    rsDest.ImportRow(rsSource.Rows(
                '    drow.Item(column) = rsSource.Rows(vRow.Index).Item(i)
                '    'rsDest.Item(i) = rsSource.Fields(i)
                'Next column
                rsDest.ImportRow(rsSource.Rows(vRow.Index))
                'rsDest.Rows.Add(drow)
                'rsDest.Update()
                rsDest.Select(Nothing, sSort)

            End If
            rsSource.Rows.RemoveAt(vRow.Index)
            'rsSource.Delete(ADODB.AffectEnum.adAffectCurrent)
        Next vRow

        dgSource.ClearSelection()
        'Do While dgSource.SelBookmarks.Count
        '    dgSource.SelBookmarks.Remove(0)
        'Loop
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "move_member")
        MsgBox("Unexpected error found. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")

    End Sub
	
    Private Sub move_all_member(ByRef rsSource As DataTable, ByRef rsDest As DataTable, ByRef sSort As String)
        Dim rowIndx As Integer
        Dim i As Short

        On Error GoTo ErrorHandler

        'copy rows
        For Each dRow As DataRow In rsSource.Rows
            rsDest.ImportRow(dRow)
        Next dRow
        'remove rows
        For rowIndx = 0 To rsSource.Rows.Count - 1
            rsSource.Rows.RemoveAt(0)
        Next rowIndx

        rsDest.Select(Nothing, sSort)

        Exit Sub

ErrorHandler:
        save_error(Me.Name, "move_all_member")
        MsgBox("Unexpected error found. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")


    End Sub
	
	
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
		load_cb_query2(cbPeriodStart, sStmt, 2, True)
		load_cb_query2(cbPeriodEnd, sStmt, 2, True)
		
		If cbPeriodName.Items.Count > 0 Then
			cbPeriodName.SelectedIndex = 0
		End If
		
		If cbPeriodStart.Items.Count > 0 Then
			cbPeriodStart.SelectedIndex = 0
		End If
		
		If cbPeriodEnd.Items.Count > 0 Then
			cbPeriodEnd.SelectedIndex = 0
		End If
		
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_period")
		
	End Sub
	
	
	'UPGRADE_WARNING: Event cbPeriodEnd.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbPeriodEnd_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriodEnd.SelectedIndexChanged
		On Error GoTo ErrorHandler
		lbPeriodEndDate.Text = ""
        Dim cmd As SqlCommand = cn.CreateCommand
		sStmt = "SELECT period_end_date " & " FROM period " & " WHERE cust_id ='" & Trim(cbCustId.Text) & "'" & " AND period_seq =" & Str(VB6.GetItemData(cbPeriodEnd, cbPeriodEnd.SelectedIndex))
        cmd.CommandText = sStmt
        
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsLocal.Rows.Count > 0 Then
            'If rsLocal.RecordCount > 0 Then

            lbPeriodEndDate.Text = rsLocal.Rows(0).Item("period_end_date")
            'End If
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
        Dim cmd As SqlCommand = cn.CreateCommand
		sStmt = "SELECT period_start_date, period_end_date " & " FROM period " & " WHERE cust_id ='" & Trim(cbCustId.Text) & "'" & " AND period_seq =" & Str(VB6.GetItemData(cbPeriodName, cbPeriodName.SelectedIndex))
        cmd.CommandText = sStmt
		
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'if rsLocal.State = ADODB.ObjectStateEnum.adStateOpen Then
        If rsLocal.Rows.Count > 0 Then
            lbStartDate.Text = rsLocal.Rows(0).Item("period_start_date")
            lbEndDate.Text = rsLocal.Rows(0).Item("period_end_date")
        End If
        'End If
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "cbPeriodName.click")
        MsgBox("An error occurred while loading  Period Info. Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
		
	End Sub
	
	'UPGRADE_WARNING: Event cbPeriodStart.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbPeriodStart_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriodStart.SelectedIndexChanged
		On Error GoTo ErrorHandler
		lbPeriodStartDate.Text = ""
        Dim cmd As SqlCommand = cn.CreateCommand
		sStmt = "SELECT period_start_date " & " FROM period " & " WHERE cust_id ='" & Trim(cbCustId.Text) & "'" & " AND period_seq =" & Str(VB6.GetItemData(cbPeriodStart, cbPeriodStart.SelectedIndex))
        cmd.CommandText = sStmt
		
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count > 0 Then
            lbPeriodStartDate.Text = rsLocal.Rows(0).Item("period_start_date")
        End If



        Exit Sub

ErrorHandler:
        save_error(Me.Name, "cbPeriodStart.click")
        MsgBox("An error occurred while loading  Period Info. Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
		
		
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
	'2.-Ejecuta el store procedure para cargar RepData
	'3.-Verifica que se haya ejecutado, que hayan datos en RepData
	'4.-Mapea campos de RepData con los definidos en RepCust
	'5.-Muestra el reporte
	Private Sub show_report2()
		Dim sMsg As String
        Dim cmd As SqlCommand = cn.CreateCommand()
		
        'On Error GoTo ErrorHandler
		
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
        cmReport = cn.CreateCommand() '.let_ActiveConnection(cn)
        cmReport.CommandType = CommandType.StoredProcedure
        'cmReport.Parameters.Refresh()
		
		
		
		'Se cargan los parametros dependiendo del tipo de reporte
		cmReport.CommandText = "usp_rep_universal"
        SqlCommandBuilder.DeriveParameters(cmReport)
        'cmReport.Parameters '.Refresh()
		cmReport.Parameters("@nReportId").Value = nReport
		cmReport.Parameters("@sCustId").Value = rptUniversalParam.sCustId
		cmReport.Parameters("@sStateId").Value = rptUniversalParam.sStateId
		cmReport.Parameters("@nGroupSeq").Value = rptUniversalParam.nGroupSeq
		cmReport.Parameters("@nPeriodSeq").Value = rptUniversalParam.nPeriodSeq
		cmReport.Parameters("@sPeriodSeq").Value = rptUniversalParam.sPeriodSeq
		cmReport.Parameters("@sStartDate").Value = rptUniversalParam.sStartDate
		cmReport.Parameters("@sEndDate").Value = rptUniversalParam.sEndDate
		cmReport.Parameters("@sReportCaption").Value = rptUniversalParam.sReportCaption
		cmReport.Parameters("@nPeriodSeqFrom").Value = rptUniversalParam.nPeriodSeqFrom
		cmReport.Parameters("@nPeriodSeqTo").Value = rptUniversalParam.nPeriodSeqTo
		cmReport.Parameters("@sPeriodName").Value = rptUniversalParam.sPeriodName
        cmReport.Parameters("@sReportTitle").Value = rptUniversalParam.sReportTitle
        cmReport.Parameters("@nError").Direction = ParameterDirection.Output
		
		
        sb.Items(0).Text = "Executing Procedure..."
		
		log_report_parameters(sLocalReport, cmReport)
		
		
		'Ejecuto el procedure y verifico por errores
        cmReport.ExecuteNonQuery()
		
		
		rptUniversalParam.nError = cmReport.Parameters("@nError").Value
		If rptUniversalParam.nError <> 0 Then
			MsgBox(CDbl("An error ocurred while generating report. Error #") + rptUniversalParam.nError, MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Sub
		End If
		
		sMsg = "REPID:" & Str(nReport) & ". Executed Stored Procedure."
		log_event(sMsg, 99, "usp_rep_universal")
		
		'Verifico que se hayan cargado datos en RptUniversal para este reporte
		sStmt = "SELECT count(*) FROM rptUniversal WHERE report_id = " & Str(nReport)
        cmd.CommandText = sStmt
        Try
            rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rsLocal.Rows(0).Item(0) > 0 Then
                'Encontro registros
            Else
                MsgBox("No data was generated for :" & gReport.name & " report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If
        Catch
            MsgBox("There was an error while verifying report data for:" & gReport.name, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End Try


        sStmt = " SELECT report_title, LTRIM(RTRIM(date_range)) AS date_range, LTRIM(RTRIM(account)) AS account," & "account_no, content_desc, cust_id, LTRIM(RTRIM(cust_report_name)) as cust_name," & "eqpt_mask, eqpt_seq, frequency_mask, " & "LTRIM(RTRIM(invoice)) AS invoice, invoice_no, location," & "old_rate, rate, rate_status," & "report_end, report_start, savings," & "comment, serv_desc," & "serv_desc1, serv_sum1, serv_desc2, serv_sum2, " & "serv_desc3 , serv_sum3, serv_desc4, serv_sum4, " & "serv_desc5 , serv_sum5, serv_desc6, serv_sum6, " & "serv_desc7 , serv_sum7, serv_desc8, serv_sum8, " & "serv_desc9 , serv_sum9, serv_desc10, serv_sum10," & "serv_desc11 , serv_sum11, serv_desc12, serv_sum12," & "serv_desc13 , serv_sum13, serv_desc14, serv_sum14, +" & "serv_desc101 , serv_sum101, serv_desc102, serv_sum102," & "serv_desc103 , serv_sum103, serv_desc104, serv_sum104," & "serv_desc105 , serv_sum105, serv_desc106, serv_sum106, " & "serv_desc107, serv_sum107, " & "serv_id, serv_usage, units, " & "store_id, store_no, total_charges , " & "total_savings, total_serv, total_units," & "unit_type, vend_name, vend_seq, " & "vinvoice_date, eqpt_temp, "

        sStmt = sStmt & "serv_desc201_count, serv_sum201_count, " & "serv_desc201_ytd, serv_sum201_ytd, " & "serv_desc202_count, serv_sum202_count, " & "serv_desc202_ytd, serv_sum202_ytd, " & "serv_desc203_count, serv_sum203_count, " & "serv_desc203_ytd, serv_sum203_ytd, " & "serv_desc204_count, serv_sum204_count, " & "serv_desc204_ytd, serv_sum204_ytd, " & "serv_desc205_count, serv_sum205_count, " & "serv_desc205_ytd, serv_sum205_ytd, " & "serv_desc206_count, serv_sum206_count, " & "serv_desc206_ytd, serv_sum206_ytd, " & "serv_desc207_count, serv_sum207_count, " & "serv_desc207_ytd, serv_sum207_ytd " & "FROM rptUniversal " & "WHERE report_id = " & Str(nReport)

        sStmt = sStmt & "ORDER BY store_no, account, invoice, eqpt_seq"


        cmd.CommandText = sStmt
        
        rsReport = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        'Set dgDebug.DataSource = rsReport


        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        'Cargo la plantilla de Crystal Reports con los datos
        sb.Items(0).Text = "Loading Report..."

        load_report(rsReport)

        Exit Sub

ErrorHandler:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        save_error(Me.Name, "show_report2")

    End Sub
	
    Private Function load_report(ByRef dstReport As DataTable) As Boolean
       
        Dim sFile As String 'Path de la plantilla del reporte
        'Dim sReportTemplate As String 'Nombre de plantilla de reporte
        Dim fileTmp As Scripting.FileSystemObject
        fileTmp = New Scripting.FileSystemObject

        'On Error GoTo ErrorHandler

        'Abro el archivo con el reporte
        'Dim sReportTemplate As String 'Nombre de plantilla de reporte
        fileTmp = New Scripting.FileSystemObject

        'On Error GoTo ErrorHandler
        Dim rptDoc As ReportDocument = New ReportDocument()
        Try
            'sFile = "c:\glm\Visual Basic\Glm-System\Reports\rptUniversal.rpt"
            sFile = get_template(sLocalReport, cbReportTemplate.Text)
            'rptDoc.Load(strReportsSysPath & "rptUniversal.rpt")
            rptDoc.Load(sFile)
        Catch ex As Exception
            MsgBox("Report template not found." & vbCrLf & "Please install: " & "rptGlmInvoice.rpt", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
        End Try

        rptDoc.SetDataSource(dstReport)

        frmRepUniversalViewer.CrystalReportViewer1.ReportSource = rptDoc
        frmRepUniversalViewer.CrystalReportViewer1.Visible = True
        frmRepUniversalViewer.CrystalReportViewer1.Show()
        frmRepUniversalViewer.Show()

        'sFile = "c:\glm\Visual Basic\Glm-System\Reports\rptUniversal.rpt"
        'sFile = get_template(sLocalReport, cbReportTemplate.Text)
        'If fileTmp.FileExists(sFile) Then
        '    'crysRepUniversal = crysApp.OpenReport(sFile)
        'Else
        '    sFile = get_local_template(sLocalReport)
        '    If fileTmp.FileExists(sFile) Then
        '        'crysRepUniversal = crysApp.OpenReport(sFile)
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
        'crysRepUniversal.SelectPrinter(Printer.DriverName, Printer.DeviceName, Printer.Port)

        'cd.CancelError = True
        'cd.ShowPrinter
        '
        'crysRepUniversal.ProgressDialogEnabled = True
        'crysRepUniversal.Preview()

        'ErrorHandler:
        'If Err.Number = cdlCancel Then
        '    MsgBox "usuario aborto"
        'End If
    End Function
	
	
	Private Sub load_load()
		On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand
        'Dim ds As DataSet = New DataSet("")

        'Dim da As SqlDataAdapter = New SqlDataAdapter()

        sStmt = "SELECT load_id, load_desc FROM LoadType " & " ORDER BY load_desc "
        'cmd.CommandText = sStmt
        'da.SelectCommand = cmd
        'da.Fill(ds)
		
        rsLoad = getDataTable(sStmt) 'ds.Tables(0) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)
        addPrimaryKey(rsLoad, "load_id")
		dgLoad.DataSource = rsLoad
		
		dgLoad.Columns("load_desc").Width = VB6.TwipsToPixelsX(2400)
        dgLoad.Columns("load_id").Visible = False
        dgLoad.DefaultCellStyle.Font = New Font("Arial", 8)
        dgLoad.DefaultCellStyle.ForeColor = Color.Black
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_load")
		MsgBox("Failed to load Load Type data. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
		
	End Sub
	
	Private Sub load_SelLoad()
		On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand()
        'Dim ds As DataSet = New DataSet("")
        'Dim da As SqlDataAdapter = New SqlDataAdapter()

		sStmt = "SELECT load_id, load_desc FROM LoadType " & " WHERE load_id='--' " & " ORDER BY load_desc "
        'cmd.CommandText = sStmt
        'da.Fill(ds)
        rsSelLoad = getDataTable(sStmt) 'ds.Tables(0) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)
        addPrimaryKey(rsSelLoad, "load_id")
		dgSelLoad.DataSource = rsSelLoad
		
		dgSelLoad.Columns("load_desc").Width = VB6.TwipsToPixelsX(2400)
        dgSelLoad.Columns("load_id").Visible = False
        dgSelLoad.DefaultCellStyle.Font = New Font("Arial", 8)
        dgSelLoad.DefaultCellStyle.ForeColor = Color.Black
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_SelLoad")
		MsgBox("Failed to load Load Type data. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
		
	End Sub
	
	Private Sub load_service()
		On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand
        Dim ds As DataSet = New DataSet("ds")
        Dim da As SqlDataAdapter = New SqlDataAdapter
		sStmt = "SELECT serv_id, serv_desc " & " FROM service" & " ORDER BY serv_desc"
        cmd.CommandText = sStmt
        da.SelectCommand = cmd
        da.Fill(ds)
		
        rsService = ds.Tables(0) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)
        addPrimaryKey(rsService, "serv_id")
		dgService.DataSource = rsService
		
		
		dgService.Columns("serv_desc").Width = VB6.TwipsToPixelsX(2000)
        dgService.Columns("serv_id").Visible = False
        dgService.DefaultCellStyle.Font = New Font("Arial", 8)
        dgService.DefaultCellStyle.ForeColor = Color.Black
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_service")
		MsgBox("Failed to load Service data. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
		
	End Sub
	
	Private Sub load_SelService()
        On Error GoTo ErrorHandler
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim ds As DataSet = New DataSet("ds")
        Dim cmd As SqlCommand = cn.CreateCommand
		sStmt = "SELECT serv_id, serv_desc " & " FROM service" & " WHERE serv_id =-1 " & " ORDER BY serv_desc"
        cmd.CommandText = sStmt
        da.SelectCommand = cmd
        da.Fill(ds)
        rsSelService = ds.Tables(0) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)
        addPrimaryKey(rsSelService, "serv_id")

		dgSelService.DataSource = rsSelService
		
		
		dgSelService.Columns("serv_desc").Width = VB6.TwipsToPixelsX(2000)
        dgSelService.Columns("serv_id").Visible = False
        dgSelService.DefaultCellStyle.Font = New Font("Arial", 8)
        dgSelService.DefaultCellStyle.ForeColor = Color.Black
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_SelService")
		MsgBox("Failed to load Service data. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
		
	End Sub
	
	Private Function val_fields_service() As Boolean
		Dim i As Short
		
		On Error GoTo ErrorHandler
		
        If rsService.Rows.Count = 0 Then
            bAllServiceSelected = True
        Else
            bAllServiceSelected = False
        End If
		
        If rsSelService.Rows.Count = 0 Then
            val_fields_service = False
            MsgBox("Please select at least one service charge.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Function
        End If
		val_fields_service = True
		
		Exit Function
		
		
ErrorHandler: 
		save_error(Me.Name, "val_fields_service")
		MsgBox("Unexpected error found while checking service data." & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
	End Function
	Private Function val_fields_vendor() As Boolean
		
		On Error GoTo ErrorHandler
		
        If rsVendor.Rows.Count = 0 Then
            bAllVendorSelected = True
        Else
            bAllVendorSelected = False
        End If
		
        If rsSelVendor.Rows.Count = 0 Then
            val_fields_vendor = False
            MsgBox("Please select at least one vendor charge.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Function
        End If
		val_fields_vendor = True
		
		Exit Function
		
		
ErrorHandler: 
		save_error(Me.Name, "val_fields_vendor")
		MsgBox("Unexpected error found while checking Vendor data." & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
		
	End Function
	Private Sub load_vendor()
		
        Dim cmd As SqlCommand = cn.CreateCommand()
        Dim ds As DataSet = New DataSet("ds")
        Dim da As SqlDataAdapter = New SqlDataAdapter()
		On Error GoTo ErrorHandler
		
        If IsDBNull(cbCustId.Text) Or IsDBNull(cbStateId.Text) Then
            MsgBox("Customer or State has not been selected." & vbCrLf & "Unable to retrieve Vendor information.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Sub
        End If
		
		If sPrevCustId <> cbCustId.Text Or sPrevStateId <> cbStateId.Text Then
			'UPGRADE_NOTE: Object dgVendor.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			dgVendor.DataSource = Nothing
			sPrevCustId = cbCustId.Text
			sPrevStateId = cbStateId.Text
			
			load_SelVendor()
		Else
            'If rsVendor.State = ADODB.ObjectStateEnum.adStateOpen Then
            'If rsVendor.Rows.Count > 0 Then
            Exit Sub 'Do not requery if same Customer and State
            'End If
        End If

        If cbStateId.SelectedIndex = 0 Then
            'All
            sStmt = "SELECT DISTINCT  vend_id, vend_name FROM vbranch " & " WHERE vend_seq IN (SELECT DISTINCT a.vend_seq " & " FROM vaccount a, store b " & " WHERE a.cust_id='" & cbCustId.Text & "' " & " AND a.cust_id = b.cust_id " & " AND a.store_id = b.store_id )" & " ORDER BY vend_name "
        Else
            sStmt = "SELECT DISTINCT  vend_id, vend_name FROM vbranch " & " WHERE vend_seq IN (SELECT DISTINCT a.vend_seq " & " FROM vaccount a, store b " & " WHERE a.cust_id='" & cbCustId.Text & "' " & " AND a.cust_id = b.cust_id " & " AND a.store_id = b.store_id " & " AND b.state_id='" & cbStateId.Text & "' )" & " ORDER BY vend_name "
        End If

        cmd.CommandText = sStmt
        da.SelectCommand = cmd
        da.Fill(ds)
        rsVendor = ds.Tables(0) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)
        addPrimaryKey(rsVendor, "vend_id")

        Dim numRecs As Integer = rsVendor.Rows.Count()

        dgVendor.DataSource = rsVendor
        dgVendor.Refresh()



        If rsVendor.Rows.Count = 0 Then
            MsgBox("Vendors have not been found for this Customer " & vbCrLf & "in the selected State", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Sub
        End If

        dgVendor.Columns("vend_name").Width = VB6.TwipsToPixelsX(2000)
        dgVendor.Columns("vend_id").Visible = False
        dgVendor.DefaultCellStyle.Font = New Font("Arial", 8)
        dgVendor.DefaultCellStyle.ForeColor = Color.Black
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "load_vendor")
        MsgBox("Failed to load Vendor data. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")

    End Sub
	
	Private Sub load_SelVendor()
		On Error GoTo ErrorHandler
		
		sStmt = "SELECT DISTINCT  vend_id, vend_name FROM vbranch " & " WHERE vend_seq IN (SELECT DISTINCT a.vend_seq " & " FROM vaccount a, store b " & " WHERE a.cust_id='--' " & " AND a.cust_id = b.cust_id " & " AND a.store_id = b.store_id )"
		
		
        rsSelVendor = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)
        addPrimaryKey(rsSelVendor, "vend_id")
		dgSelVendor.DataSource = rsSelVendor
		
		dgSelVendor.Columns("vend_name").Width = VB6.TwipsToPixelsX(2000)
        dgSelVendor.Columns("vend_id").Visible = False
        dgSelVendor.DefaultCellStyle.Font = New Font("Arial", 8)
        dgSelVendor.DefaultCellStyle.ForeColor = Color.Black
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_SelVendor")
		MsgBox("Failed to load Vendor data. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
	End Sub
	'Genera query usando criterios de selecciona y guarda resultados en RptUniversalTmp
	'que luego seran procesados por Stored Procedure
	Private Function build_query(ByRef bFlagWithoutEqpt As Boolean, ByRef bFlagInvoiceEqpt As Boolean) As Boolean
		
        Dim nRecords1 As Short = 0
        Dim nRecords2 As Short = 0
		Dim sMsg As String
		Dim sInsert As String
		Dim sFrom1 As String
		Dim sQuery1 As String
		
		On Error GoTo ErrorHandler
		
		build_query = False
		
		sStmt = ""
		
		'Obengo el identificador del reporte
		nReport = 0
		nReport = get_seed("repdata")
		If nReport <= 0 Then
			MsgBox("Unable to get Report Number." & vbCrLf & "Report has not been generated.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
			
			Exit Function
		End If
		
		sInsert = "INSERT INTO RptUniversalTmp (" & "report_id, cust_id, cust_report_name,store_number," & "store_id, store_address, store_city," & "state_id, store_co_code, store_name," & "vend_name, vend_seq, account_no," & "invoice_no, vinvoice_date, period_seq," & "old_rate, rate, eqpt_seq," & "serv_id, unit_type, eqpt_qty, " & "eqpt_desc, load_id, eqpt_temp," & "content_desc, serv_desc, rate_status," & "eqpt_mask, frequency_mask, serv_usage," & "units, comment, total_units," & "total_serv, savings, total_charges," & " total_savings, total_taxes, account," & "invoice, report_start, report_end,"
		
		sInsert = sInsert & "serv_desc1, serv_sum1, serv_desc2, serv_sum2," & "serv_desc3, serv_sum3, serv_desc4, serv_sum4," & "serv_desc5, serv_sum5, serv_desc6, serv_sum6," & "serv_desc7, serv_sum7, serv_desc8, serv_sum8," & "serv_desc9, serv_sum9, serv_desc10, serv_sum10," & "serv_desc11, serv_sum11, serv_desc12, serv_sum12," & "serv_desc13, serv_sum13, serv_desc14, serv_sum14," & "serv_desc101, serv_sum101, serv_desc102, serv_sum102," & "serv_desc103, serv_sum103, serv_desc104, serv_sum104," & "serv_desc105, serv_sum105, serv_desc106, serv_sum106," & "serv_desc107, serv_sum107)" & vbCrLf
		
		sStmt = sStmt & " SELECT DISTINCT " & Str(nReport) & ", " & "VInvoice.cust_id, Customer.cust_report_name, " & "Store.store_number, Store.store_id, " & " Store.store_address, Store.store_city, " & "Store.state_id, Store.store_co_code, " & "Store.store_name,     VBranch.vend_name, " & "VBranch.vend_seq,     VInvoice.account_no, " & "VInvoice.invoice_no, VInvoice.vinvoice_date, " & "VInvoice.period_seq,    VInvoiceDet.old_rate, " & "VInvoiceDet.rate,    VInvoiceDet.eqpt_seq, " & "VInvoiceDet.serv_id, VInvoiceDet.unit_type, " & "StoreEqpt.eqpt_qty, StoreEqpt.eqpt_desc, " & "StoreEqpt.load_id,StoreEqpt.eqpt_temp, " & "Content.content_desc, Service.serv_desc," & "VContract.rate_status," & "dbo.format_eqpt (StoreEqpt.eqpt_qty, StoreEqpt.eqpt_desc, StoreEqpt.load_id) AS eqpt_mask,"
		
		sStmt = sStmt & "CAST(dbo.format_freq2 (Frequency.freq_sched_flag, " & "Frequency.freq_times_flag, VContract.freq_times," & "ISNULL(VContract.freq_period,''), ISNULL(VContract.freq_day1,'')," & "ISNULL(VContract.freq_day2,''), ISNULL(VContract.freq_day3,''), " & "ISNULL(VContract.freq_day4,''), ISNULL(VContract.freq_day5,'')," & "ISNULL(VContract.freq_day6,''), ISNULL(VContract.freq_day7,''))  AS CHAR(60))AS frequency_mask ," & " CAST(0.00 AS DECIMAL(5,2)) AS serv_usage, CAST(' 'AS CHAR(40)) AS units," & "CAST(' ' AS CHAR(80)) AS comment, CAST(0.00 AS DECIMAL(5,2)) AS total_units," & "CAST(0.00 AS DECIMAL(7,2)) AS total_serv," & "CAST(0.00 AS DECIMAL(7,2)) AS savings," & "CAST(0.00 AS DECIMAL(12,2)) AS total_charges," & "CAST(0.00 AS DECIMAL(12,2)) AS total_savings," & "CAST(0.00 AS DECIMAL(12,2)) AS total_taxes, " & "CAST(' ' AS CHAR(80)) AS account, " & "CAST(' ' AS CHAR(80)) AS invoice, " & "CAST(' ' AS CHAR(10)) AS report_start, CAST (' ' AS CHAR(10)) AS report_end, "
		
		sStmt = sStmt & "CAST(' ' AS CHAR(30)) AS serv_desc1, CAST(0.00 AS decimal(7,2)) AS serv_sum1, " & "CAST(' ' AS CHAR(30)) AS serv_desc2, CAST(0.00 AS decimal(7,2)) AS serv_sum2," & "CAST(' ' AS CHAR(30)) AS serv_desc3, CAST(0.00 AS decimal(7,2)) AS serv_sum3," & "CAST(' ' AS CHAR(30)) AS serv_desc4, CAST(0.00 AS decimal(7,2)) AS serv_sum4, " & "CAST(' ' AS CHAR(30)) AS serv_desc5, CAST(0.00 AS decimal(7,2)) AS serv_sum5," & "CAST(' ' AS CHAR(30)) AS serv_desc6, CAST(0.00 AS decimal(7,2)) AS serv_sum6, " & "CAST(' ' AS CHAR(30)) AS serv_desc7, CAST(0.00 AS decimal(7,2)) AS serv_sum7, " & "CAST(' ' AS CHAR(30)) AS serv_desc8, CAST(0.00 AS decimal(7,2)) AS serv_sum8," & "CAST(' ' AS CHAR(30)) AS serv_desc9, CAST(0.00 AS decimal(7,2)) AS serv_sum9," & "CAST(' ' AS CHAR(30)) AS serv_desc10, CAST(0.00 AS decimal(7,2)) AS serv_sum10, " & "CAST(' ' AS CHAR(30)) AS serv_desc11, CAST(0.00 AS decimal(7,2)) AS serv_sum11," & "CAST(' ' AS CHAR(30)) AS serv_desc12, CAST(0.00 AS decimal(7,2)) AS serv_sum12," & "CAST(' ' AS CHAR(30)) AS serv_desc13, CAST(0.00 AS decimal(7,2)) AS serv_sum13," & "CAST(' ' AS CHAR(30)) AS serv_desc14, CAST(0.00 AS decimal(7,2)) AS serv_sum14," & "CAST(' ' AS CHAR(30)) AS serv_desc101, CAST(0.00 AS decimal(7,2)) AS serv_sum101," & "CAST(' ' AS CHAR(30)) AS serv_desc102, CAST(0.00 AS decimal(7,2)) AS serv_sum102," & "CAST(' ' AS CHAR(30)) AS serv_desc103, CAST(0.00 AS decimal(7,2)) AS serv_sum103," & "CAST(' ' AS CHAR(30)) AS serv_desc104, CAST(0.00 AS decimal(7,2)) AS serv_sum104," & "CAST(' ' AS CHAR(30)) AS serv_desc105, CAST(0.00 AS decimal(7,2)) AS serv_sum105," & "CAST(' ' AS CHAR(30)) AS serv_desc106, CAST(0.00 AS decimal(7,2)) AS serv_sum106," & "CAST(' ' AS CHAR(30)) AS serv_desc107, CAST(0.00 AS decimal(7,2)) AS serv_sum107 " & vbCrLf
		
		sFrom1 = " FROM VInvoice,  Customer, Store, VBranch, " & " StoreEqpt, Content, Service, Frequency, " & " VInvoiceDet , VContract " & vbCrLf
		
		
		sQuery1 = " WHERE VInvoice.cust_id = Customer.cust_id " & vbCrLf & " AND VInvoice.store_id = Store.store_id " & vbCrLf & " AND VInvoice.cust_id = Store.cust_id " & vbCrLf & " AND VInvoice.vend_seq = VBranch.vend_seq " & vbCrLf & " AND StoreEqpt.content_id = Content.content_id " & vbCrLf & " AND VInvoice.cust_id = StoreEqpt.cust_id " & vbCrLf & " AND VInvoice.store_id = StoreEqpt.store_id " & vbCrLf & " AND VInvoiceDet.eqpt_seq = StoreEqpt.eqpt_seq" & vbCrLf & " AND VInvoice.invoice_no = VInvoiceDet.invoice_no " & vbCrLf & " AND VInvoice.cust_id = VInvoiceDet.cust_id " & vbCrLf & " AND VInvoice.store_id = VInvoiceDet.store_id " & vbCrLf & " AND VInvoice.account_no = VInvoiceDet.account_no " & vbCrLf & " AND VInvoice.vend_seq = VInvoiceDet.vend_seq " & vbCrLf & " AND VInvoiceDet.cust_id = Vcontract.cust_id " & vbCrLf & " AND VInvoiceDet.store_id = Vcontract.store_id " & vbCrLf & " AND VInvoiceDet.vend_seq = Vcontract.vend_seq " & vbCrLf & " AND VInvoiceDet.eqpt_seq = Vcontract.eqpt_seq " & vbCrLf & " AND VInvoiceDet.serv_id = Vcontract.serv_id " & vbCrLf & " AND VContract.freq_id = Frequency.freq_id " & vbCrLf & " AND VInvoiceDet.serv_id = Service.serv_id " & vbCrLf & " AND Store.store_status = 'A' " & vbCrLf
		
		'UPGRADE_WARNING: Couldn't resolve default property of object sWhere1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sStmt = sInsert & sStmt & sFrom1 & sQuery1 + sWhere1 + vbCrLf
		
		write_error("*****************************************************", sLogfile, False)
		write_error("Date:     " & CStr(Now), sLogfile, False)
		write_error("REPORT ID:" & Str(nReport), sLogfile, False)
		write_error("QUERY1:", sLogfile, False)
		write_error(sStmt, sLogfile, False)
		
		cm.CommandTimeout = gnTimeout
        cm = cn.CreateCommand()
        cm.CommandType = CommandType.Text
		cm.CommandText = sStmt
        nRecords1 = cm.ExecuteNonQuery()
		
		'11.02.05 - rev 2.8.2
		'Comentado para permitir que reporte
		'muestre servicios sin contrato, ejemplo: Fuel Surcharge.
		'En este caso el equipo se muestra en blanco pues este servicio
		'Fuel Surcharge no esta asociado a ningun equipo de factura.
		'Se mantiene comportamiento de CCR.
		
		'If nRecords1 <= 0 Then
		'    MsgBox "No data was generated for :" + gReport.name + " report in temporary tables.", _
		''           vbExclamation + vbOKOnly, "GLM Warning"
		'    Exit Function
		'End If
		
		
		'Si usuario decidio solo ver servicios en Contratos, no se
		'agrega el segundo query
		If bFlagWithoutEqpt Then
			
			sStmt = " SELECT DISTINCT " & Str(nReport) & " , " & "VInvoice.cust_id,  Customer.cust_report_name," & "Store.store_number, Store.store_id, Store.store_address, Store.store_city," & "Store.state_id, Store.store_co_code, Store.store_name," & "VBranch.vend_name, VBranch.vend_seq," & "VInvoice.account_no," & "VInvoice.invoice_no, VInvoice.vinvoice_date, VInvoice.period_seq," & "VInvoiceDet.old_rate, VInvoiceDet.rate," & "VInvoiceDet.eqpt_seq, VInvoiceDet.serv_id, VInvoiceDet.unit_type," & "CAST(0  AS INT) eqpt_qty, NULL as  eqpt_desc," & "NULL load_id, NULL eqpt_temp," & "NULL content_desc, Service.serv_desc," & "NULL rate_status," & "dbo.format_eqpt (0, NULL, NULL) AS eqpt_mask," & "NULL  AS frequency_mask ,"
			
			sStmt = sStmt & "CAST(0.00 AS DECIMAL(5,2)) AS serv_usage, CAST(' 'AS CHAR(40)) AS units," & "CAST(' ' AS CHAR(80)) AS comment, CAST(0.00 AS DECIMAL(5,2)) AS total_units," & "CAST(0.00 AS DECIMAL(7,2)) AS total_serv," & "CAST(0.00 AS DECIMAL(7,2)) AS savings," & "CAST(0.00 AS DECIMAL(12,2)) AS total_charges," & "CAST(0.00 AS DECIMAL(12,2)) AS total_savings," & "CAST(0.00 AS DECIMAL(12,2)) AS total_taxes," & "CAST(' ' AS CHAR(80)) AS account," & "CAST(' ' AS CHAR(80)) AS invoice," & "CAST(' ' AS CHAR(10)) AS report_start, CAST (' ' AS CHAR(10)) AS report_end," & "CAST(' ' AS CHAR(30)) AS serv_desc1, CAST(0.00 AS decimal(7,2)) AS serv_sum1," & "CAST(' ' AS CHAR(30)) AS serv_desc2, CAST(0.00 AS decimal(7,2)) AS serv_sum2," & "CAST(' ' AS CHAR(30)) AS serv_desc3, CAST(0.00 AS decimal(7,2)) AS serv_sum3," & "CAST(' ' AS CHAR(30)) AS serv_desc4, CAST(0.00 AS decimal(7,2)) AS serv_sum4," & "CAST(' ' AS CHAR(30)) AS serv_desc5, CAST(0.00 AS decimal(7,2)) AS serv_sum5," & "CAST(' ' AS CHAR(30)) AS serv_desc6, CAST(0.00 AS decimal(7,2)) AS serv_sum6," & "CAST(' ' AS CHAR(30)) AS serv_desc7, CAST(0.00 AS decimal(7,2)) AS serv_sum7," & "CAST(' ' AS CHAR(30)) AS serv_desc8, CAST(0.00 AS decimal(7,2)) AS serv_sum8," & "CAST(' ' AS CHAR(30)) AS serv_desc9, CAST(0.00 AS decimal(7,2)) AS serv_sum9,"
			
			sStmt = sStmt & "CAST(' ' AS CHAR(30)) AS serv_desc10, CAST(0.00 AS decimal(7,2)) AS serv_sum10," & "CAST(' ' AS CHAR(30)) AS serv_desc11, CAST(0.00 AS decimal(7,2)) AS serv_sum11," & "CAST(' ' AS CHAR(30)) AS serv_desc12, CAST(0.00 AS decimal(7,2)) AS serv_sum12," & "CAST(' ' AS CHAR(30)) AS serv_desc13, CAST(0.00 AS decimal(7,2)) AS serv_sum13," & "CAST(' ' AS CHAR(30)) AS serv_desc14, CAST(0.00 AS decimal(7,2)) AS serv_sum14," & "CAST(' ' AS CHAR(30)) AS serv_desc101, CAST(0.00 AS decimal(7,2)) AS serv_sum101," & "CAST(' ' AS CHAR(30)) AS serv_desc102, CAST(0.00 AS decimal(7,2)) AS serv_sum102," & "CAST(' ' AS CHAR(30)) AS serv_desc103, CAST(0.00 AS decimal(7,2)) AS serv_sum103," & "CAST(' ' AS CHAR(30)) AS serv_desc104, CAST(0.00 AS decimal(7,2)) AS serv_sum104," & "CAST(' ' AS CHAR(30)) AS serv_desc105, CAST(0.00 AS decimal(7,2)) AS serv_sum105," & "CAST(' ' AS CHAR(30)) AS serv_desc106, CAST(0.00 AS decimal(7,2)) AS serv_sum106," & "CAST(' ' AS CHAR(30)) AS serv_desc107, CAST(0.00 AS decimal(7,2)) AS serv_sum107" & vbCrLf
			
			sStmt = sStmt & " FROM VInvoice, VInvoiceDet, Customer, Store, VBranch," & " Service " & vbCrLf
			
			sStmt = sStmt & " WHERE VInvoice.cust_id = Customer.cust_id " & vbCrLf & " AND VInvoice.store_id = Store.store_id " & vbCrLf & " AND VInvoice.cust_id = Store.cust_id" & vbCrLf & " AND VInvoice.vend_seq = VBranch.vend_seq " & vbCrLf & " AND VInvoice.invoice_no = VInvoiceDet.invoice_no " & vbCrLf & " AND VInvoice.cust_id = VInvoiceDet.cust_id " & vbCrLf & " AND VInvoice.store_id = VInvoiceDet.store_id " & vbCrLf & " AND VInvoice.account_no = VInvoiceDet.account_no " & vbCrLf & " AND VInvoice.vend_seq = VInvoiceDet.vend_seq " & vbCrLf & " AND VInvoiceDet.serv_id = Service.serv_id " & vbCrLf & " AND VInvoicedet.eqpt_seq=0 " & vbCrLf & " AND Store.store_status = 'A' " & vbCrLf
			
			
			If bFlagInvoiceEqpt Then
				'UPGRADE_WARNING: Couldn't resolve default property of object sWhere1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sStmt = sInsert & sStmt & sWhere2 & vbCrLf & "AND vInvoice.invoice_no IN (SELECT vInvoice.invoice_no " & sFrom1 & sQuery1 + sWhere1 + ")" + vbCrLf
			Else 'bFlagInvoiceEqpt
				sStmt = sInsert & sStmt & sWhere2 & vbCrLf
			End If
			
			
			sStmt = sStmt & " ORDER BY VInvoice.cust_id, Store.store_id, VBranch.vend_seq," & " VInvoice.account_no, VInvoice.invoice_no, VInvoiceDet.eqpt_seq desc, " & " VInvoiceDet.serv_id "
			
			'Saving query in logfile
			write_error("**********QUERY2**********", sLogfile, False)
			write_error(sStmt, sLogfile, False)
						
            cm = cn.CreateCommand
            cm.CommandType = CommandType.Text
			cm.CommandText = sStmt
            nRecords2 = cm.ExecuteNonQuery()
			
			
		End If 'bFlagWithoutEqpt
		
		write_error("****************************************************", sLogfile, False)
		
		build_query = True
		
		'UPGRADE_WARNING: Couldn't resolve default property of object nRecords1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sMsg = "REPID:" & Str(nReport) & " build_query inserted " & Str(nRecords1 + nRecords2) & " records in RepUniversalTmp"
		write_error(sMsg, sLogfile, False)
		log_event(sMsg, 1, "usp_rep_universal")
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "build_query")
		MsgBox("Unexpected error while building query. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Function

    Private Sub dgLoad1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLoad.CellContentClick

    End Sub

    Private Sub dgSelVendor_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelVendor.CellContentClick

    End Sub
    Private Sub addPrimaryKey(ByRef dt As DataTable, ByVal strColName As String)
        Try
            dt.PrimaryKey = New DataColumn() {dt.Columns(strColName)}
        Catch ex As Exception
            Dim errMsg As String = ex.Message
        End Try
    End Sub

    Private Sub dgEquipment_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgEquipment.CellDoubleClick
        cmdRightEquipment_Click(sender, e)
    End Sub

    Private Sub dgSelEquipment_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelEquipment.CellDoubleClick
        cmdLeftEquipment_Click(sender, e)
    End Sub

    Private Sub dgSelContent_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelContent.CellDoubleClick
        cmdLeftContent_Click(sender, e)
    End Sub

    Private Sub dgContent_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgContent.CellDoubleClick
        cmdRightContent_Click(sender, e)
    End Sub

    Private Sub dgLoad_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLoad.CellDoubleClick
        cmdRightLoad_Click(sender, e)
    End Sub

    Private Sub dgSelLoad_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelLoad.CellDoubleClick
        cmdLeftLoad_Click(sender, e)
    End Sub

    Private Sub dgService_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgService.CellDoubleClick
        cmdRightServ_Click(sender, e)
    End Sub

    Private Sub dgSelService_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelService.CellDoubleClick
        cmdLeftServ_Click(sender, e)
    End Sub

    Private Sub dgVendor_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgVendor.CellDoubleClick
        cmdRightVendor_Click(sender, e)
    End Sub

    Private Sub dgSelVendor_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelVendor.CellDoubleClick
        cmdLeftVendor_Click(sender, e)
    End Sub
End Class