Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Friend Class frmReportReprint
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private nTran As SqlTransaction = Nothing
	'--------Crystal Reports-----------------
    Private rsReport As DataTable

    Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
        If cbCustName.SelectedIndex >= 0 Then
            cbCustId.SelectedIndex = cbCustName.SelectedIndex
        End If

        load_dgReport()

    End Sub
	
	Private Sub load_dgReport()
        
		If Trim(cbRepCaption.Text) = COST_CONTAINMENT_REPORT Then
			sStmt = "SELECT a.cust_id 'Cust', a.report_id 'Report', a.state_id 'State', b.group_name 'Group', " & "c.period_name 'Period' , a.start_date 'Period Start', a.end_date 'Period End', " & " a.is_final_version 'Final Version', a.is_period_seq, a.rep_template_name " & " FROM rptCriteriaCostCont a " & " LEFT OUTER JOIN Groups b " & " ON  a.group_seq = b.group_seq " & " AND a.cust_id = b.cust_id " & " LEFT OUTER JOIN Period c " & " ON a.cust_id = c.cust_id " & " AND a.period_seq = c.period_seq " & " WHERE a.cust_id IS NOT NULL "
			
		ElseIf Trim(cbRepCaption.Text) = GLM_INVOICE_REPORT Then 
			sStmt = "SELECT a.cust_id 'Cust', a.report_id 'Report', a.state_id 'State', b.group_name 'Group', " & "c.period_name 'Period' , a.start_date 'Period Start', a.end_date 'Period End', " & " a.is_period_seq,  a.rep_template_name " & " FROM rptCriteriaGlmInvoice a " & " LEFT OUTER JOIN Groups b " & " ON  a.group_seq = b.group_seq " & " AND a.cust_id = b.cust_id " & " LEFT OUTER JOIN Period c " & " ON a.cust_id = c.cust_id " & " AND a.period_seq = c.period_seq " & " WHERE a.cust_id IS NOT NULL "
		Else
			Exit Sub
		End If
		
		If cbCustName.SelectedIndex > 0 Then
			sStmt = sStmt & " AND a.cust_id  = '" & cbCustId.Text & "' "
		End If
		
		sStmt = sStmt & " ORDER BY a.cust_id, a.report_id "
		
        rsReport = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic)

        dgReport.DataSource = rsReport
        dgReport.Columns("is_period_seq").Visible = False
        dgReport.Columns("Group").Width = VB6.TwipsToPixelsX(800)
        dgReport.Columns("Period Start").Width = VB6.TwipsToPixelsX(900)
        dgReport.Columns("Period End").Width = VB6.TwipsToPixelsX(900)

		
		
	End Sub
	
	'UPGRADE_WARNING: Event cbRepCaption.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbRepCaption_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbRepCaption.SelectedIndexChanged
		load_dgReport()
		
	End Sub
	
	Private Sub frmReportReprint_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		
        rsLocal = Nothing
		
		
		
        cbCustId.Items.Clear()
		cbCustId.Items.Insert(0, "All")
		sStmt = "SELECT cust_id, cust_name FROM customer ORDER BY cust_name "
		load_cb_query2(cbCustId, sStmt, 1, False)
		
        cbCustName.Items.Clear()
		cbCustName.Items.Insert(0, "<All>")
		sStmt = "SELECT cust_name FROM customer ORDER BY cust_name "
		load_cb_query2(cbCustName, sStmt, 1, False)
		
		sStmt = "SELECT rep_caption, rep_no " & " FROM repdef " & " WHERE rep_caption IN ('Cost Containment Report', 'GLM Invoice Report')"
		load_cb_query2(cbRepCaption, sStmt, 2, True)
		
		If cbCustName.Items.Count > 0 Then
			cbCustName.SelectedIndex = 0
		End If
		
		If cbRepCaption.Items.Count > 0 Then
			cbRepCaption.SelectedIndex = 0
		End If
		
		
		'init_dgReport
		
		
	End Sub
	
	'Initializes dgReport
	Private Sub init_dgReport()
        Dim dt As DataTable
		sStmt = "SELECT a.cust_id 'Cust', a.report_id 'Report', a.state_id 'State', b.group_name 'Group', " & "c.period_name 'Period' , a.start_date 'Period Start', a.end_date 'Period End', " & " a.is_final_version 'Final Version', a.is_period_seq " & " FROM rptCriteriaCostCont a " & " LEFT OUTER JOIN Groups b " & " ON  a.group_seq = b.group_seq " & " AND a.cust_id = b.cust_id " & " LEFT OUTER JOIN Period c " & " ON a.cust_id = c.cust_id " & " AND a.period_seq = c.period_seq " & " WHERE a.cust_id IS NOT NULL " & " AND a.cust_id  = '00' "
		
        dt = getDataTable(sStmt)
        'rsLocal.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic)
        If dt.Rows.Count > 0 Then
            dgReport.DataSource = rsLocal
            dgReport.Columns("is_period_seq").Visible = False
            dgReport.Columns("Group").Width = VB6.TwipsToPixelsX(800)
            dgReport.Columns("Period Start").Width = VB6.TwipsToPixelsX(900)
            dgReport.Columns("Period End").Width = VB6.TwipsToPixelsX(900)
        End If
		
	End Sub
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Dim bm As DataGridViewRow
        Dim nRecords As Short
        Dim nTran As SqlTransaction
        'dim rsLocal as DataTable

        On Error GoTo ErrorHandler

        Dim nId As Integer
        Select Case Button.Name
            Case "preview"
                If Me.dgReport.SelectedRows.Count = 0 Then
                    MsgBox("Please select a record before attempting this action", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Warning")
                    Exit Sub
                Else
                    'Bookmark first record in the selected datagrid
                    'UPGRADE_WARNING: Couldn't resolve default property of object dgReport.SelBookmarks(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object bm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    bm = dgReport.SelectedRows(0)
                    'UPGRADE_WARNING: Couldn't resolve default property of object bm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'rsLocal.Bookmark = bm
                    If Trim(cbRepCaption.Text) = COST_CONTAINMENT_REPORT Then

                        ReportHandler((rsLocal.Rows(0).Item("Report")), COST_CONTAINMENT_REPORT, (rsLocal.Rows(0).Item("rep_template_name")))

                    Else
                        MsgBox("This function is not yet implement for:" & cbRepCaption.Text, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Glm Warning")
                        Exit Sub
                    End If
                End If
            Case "delete"
                MsgBox("This function s not yet implemented", MsgBoxStyle.OkOnly, "Message")
            Case "flag"
                If Me.dgReport.SelectedRows.Count = 0 Then
                    MsgBox("Please select a record before attempting this action", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Warning")
                    Exit Sub
                Else
                    'Bookmark first record in the selected datagrid
                    bm = dgReport.SelectedRows(0)
                    'rsLocal.Bookmark = bm
                    If Trim(cbRepCaption.Text) = COST_CONTAINMENT_REPORT Then
                        If Trim(rsLocal.Rows(0).Item("Final Version")) = "TRUE" Then
                            If MsgBox("Do you want to turn off Final Version flag?. The Web Report records will be removed as well", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Message") = MsgBoxResult.Yes Then


                                nTran = cn.BeginTransaction()
                                sStmt = "UPDATE rptCriteriaCostCont " & " SET is_final_version = 'FALSE' " & _
                                        " WHERE cust_id = '" & Trim(rsLocal.Rows(0).Item("Cust")) & "' " & _
                                        " AND rep_no = " & Str(VB6.GetItemData(cbRepCaption, cbRepCaption.SelectedIndex)) & _
                                        " AND report_id = " & Str(rsLocal.Rows(0).Item("Report"))

                                cm = cn.CreateCommand() '.let_ActiveConnection(cn)
                                cm.CommandType = CommandType.Text
                                cm.CommandText = sStmt


                                nRecords = cm.ExecuteNonQuery()
                                If nRecords > 0 Then
                                    'Delete from GlmCostCont
                                    sStmt = "DELETE FROM GlmCostCont " & " WHERE report_id =" & Str(rsLocal.Rows(0).Item("Report"))

                                    cm.CommandText = sStmt
                                    nRecords = cm.ExecuteNonQuery()
                                End If

                                'Insert deleted record in glmCostContDeleted table for QlikView

                                nId = get_next_seq("glmCostContDeleted", "id")

                                sStmt = "INSERT INTO glmCostContDeleted (id, cust_id, report_id) " & " VALUES (" & Str(nId) & ",'" & Trim(rsLocal.Rows(0).Item("Cust")) & "'," & Str(rsLocal.Rows(0).Item("Report")) & ")"

                                cm.CommandText = sStmt
                                nRecords = cm.ExecuteNonQuery()
                                If nRecords = 0 Then
                                    MsgBox("An error occurred when removing report flag. Please check log file for details", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                                    nTran.Rollback()
                                    Exit Sub
                                End If

                                nTran.Commit()

                                load_dgReport()
                                MsgBox("Report was successfully updated", MsgBoxStyle.OkOnly, "Message")

                            End If
                        Else
                            MsgBox("No action is required since selected report is not Final Version", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message")

                        End If
                    End If
                End If

            Case "exit"
                Me.Close()
        End Select
        Exit Sub

ErrorHandler:

        nTran.Rollback()

        save_error(Me.Name, "toolbar1_click")
        MsgBox("Unexpected error ocurred while updating report. Review log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")

    End Sub
	Private Sub ReportHandler(ByRef nReportId As Integer, ByRef sLocalReport As String, ByRef sReportTemplate As String)
		Dim bPrinter As Boolean
		
		'Checks for a default printer
		'UPGRADE_ISSUE: Printers method Printers.Count was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count = 0 Then
            bPrinter = False
        Else
            bPrinter = True
        End If
		
		'Shows report and prints it
        Dim rsReport As DataTable
		If bPrinter Then
			'Choose printer
			If find_printer(Me) Then
				printer_options2(True)
				'show_report2
				rsReport = ccr_map_fields_data(nReportId)
                If rsReport.rows.count > 0 Then
                    load_report(COST_CONTAINMENT_REPORT, sReportTemplate, rsReport)
                Else
                    MsgBox("Report details were not found in the database.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Message")

                End If
				
			End If
		Else
			MsgBox("There is not default printer specified.Aborting", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Sub
		End If
		
		'Restoring defaults
		If bPrinter Then
			printer_options2(False)
		End If
		
		
	End Sub
	
	
	'Uses the rsReport recordset that was previously loaded
	'with data and it is forwarded to Crystal Reports
    Private Function load_report(ByRef sLocalReport As String, ByRef sReportTemplate As String, ByRef rsReport As SqlDataReader) As Boolean

        Dim sFile As String 'Path de la plantilla del reporte
        'Dim sReportTemplate As String 'Nombre de plantilla de reporte
        Dim fileTmp As Scripting.FileSystemObject
        fileTmp = New Scripting.FileSystemObject

        On Error GoTo ErrorHandler


        ''Open Crystal Reports app
        'crysApp = CreateObject("Crystal.CRPE.Application")

        'sFile = get_template(sLocalReport, sReportTemplate)
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


        ''Assign printer selected by user
        ''report.SelectPrinter "HP DeskJet 550C","remota", "LPT1"
        ''UPGRADE_ISSUE: Printer property Printer.Port was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_ISSUE: Printer property Printer.DeviceName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_ISSUE: Printer property Printer.DriverName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''crysRepCostCont.SelectPrinter(Printer.DriverName, Printer.DeviceName, Printer.Port)

        'reportDb = crysRepCostCont.Database
        'reportTables = reportDb.Tables
        'reportTable = reportTables.Item(1)
        'reportPage = crysRepCostCont.PageSetup


        'reportTable.SetPrivateData(3, rsReport)

        'crysRepCostCont.ProgressDialogEnabled = True
        'crysRepCostCont.Preview()

        Exit Function

ErrorHandler:
        MsgBox(Err.Description)

    End Function
    'Uses the rsReport recordset that was previously loaded
    'with data and it is forwarded to Crystal Reports
    Private Function load_report(ByRef sLocalReport As String, ByRef sReportTemplate As String, ByRef rsReport As DataTable) As Boolean

        Dim sFile As String 'Path de la plantilla del reporte
        'Dim sReportTemplate As String 'Nombre de plantilla de reporte
        Dim fileTmp As Scripting.FileSystemObject
        fileTmp = New Scripting.FileSystemObject


        'Open Crystal Reports app
        'crysApp = CreateObject("Crystal.CRPE.Application")

        sFile = get_template(sLocalReport, sReportTemplate)
        Dim rptDoc As ReportDocument = New ReportDocument()
        Try
            If fileTmp.FileExists(sFile) Then
                rptDoc.Load(sFile)
            Else
                
                MsgBox("Report template not found." & vbCrLf & "Please install: " & sFile, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                Exit Function
            End If
        Catch e As Exception
            MsgBox(Err.Description)
        End Try

        rptDoc.SetDataSource(rsReport)
        frmReportReprintViewer.CrystalReportViewer1.ReportSource = rptDoc
        frmReportReprintViewer.CrystalReportViewer1.Visible = True
        frmReportReprintViewer.CrystalReportViewer1.Show()
        frmReportReprintViewer.Show()

        'Assign printer selected by user
        'report.SelectPrinter "HP DeskJet 550C","remota", "LPT1"
        'UPGRADE_ISSUE: Printer property Printer.Port was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'UPGRADE_ISSUE: Printer property Printer.DeviceName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'UPGRADE_ISSUE: Printer property Printer.DriverName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'crysRepCostCont.SelectPrinter(Printer.DriverName, Printer.DeviceName, Printer.Port)

        'reportDb = crysRepCostCont.Database
        'reportTables = reportDb.Tables
        'reportTable = reportTables.Item(1)
        'reportPage = crysRepCostCont.PageSetup


        'reportTable.SetPrivateData(3, rsReport)

        'crysRepCostCont.ProgressDialogEnabled = True
        'crysRepCostCont.Preview()

        Exit Function

    End Function
	
	
	'Private Sub printer_options(bOption As Boolean)
	'Dim i As Integer
	
	'Static nDefault As String
	
	'--Loads form to select another printer other than default
	'If bOption Then
	
	'   Printer.PaperSize = vbPRPSLetter
	'   Printer.Orientation = vbPRORLandscape
	
	'Else
	'Code to change printer and printer options
	'End If
	
	'End Sub

    Private Sub btPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPreview.Click

        If Me.dgReport.SelectedRows.Count = 0 Then
            If dgReport.SelectedCells.Count < 1 Then
                MsgBox("Please select a record before attempting this action", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Warning")
                Exit Sub
            Else
                dgReport.CurrentRow.Selected = True
            End If

        End If
        If Me.dgReport.SelectedRows.Count > 0 Then
            'Bookmark first record in the selected datagrid
            'UPGRADE_WARNING: Couldn't resolve default property of object dgReport.SelBookmarks(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object bm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'bm = dgReport.SelectedRows(0)
            'rsLocal.ImportRow(bm.DataBoundItem)

            'UPGRADE_WARNING: Couldn't resolve default property of object bm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'rsLocal.Bookmark = bm
            If Trim(cbRepCaption.Text) = COST_CONTAINMENT_REPORT Then
                ReportHandler((dgReport.SelectedRows(0).Cells("Report").Value), COST_CONTAINMENT_REPORT, (dgReport.SelectedRows(0).Cells("rep_template_name").Value))
            Else
                MsgBox("This function is not yet implement for:" & cbRepCaption.Text, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Glm Warning")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        MsgBox("This function s not yet implemented", MsgBoxStyle.OkOnly, "Message")
    End Sub

    Private Sub btFlag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFlag.Click
        Dim bm As DataGridViewRow
        Dim nRecords As Short

        Dim nId As Integer

        If Me.dgReport.SelectedRows.Count < 1 Then
            MsgBox("Please select a record before attempting this action", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Warning")
            Exit Sub
        Else
            'Bookmark first record in the selected datagrid
            bm = dgReport.SelectedRows(0)
            'rsLocal.Bookmark = bm
            If Trim(cbRepCaption.Text) = COST_CONTAINMENT_REPORT Then
                If Trim(bm.Cells("Final Version").Value) = "TRUE" Then
                    If MsgBox("Do you want to turn off Final Version flag?. The Web Report records will be removed as well", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Message") = MsgBoxResult.Yes Then
                        nTran = cn.BeginTransaction()
                        sStmt = "UPDATE rptCriteriaCostCont " & " SET is_final_version = 'FALSE' " & _
                                " WHERE cust_id = '" & Trim(bm.Cells("Cust").Value) & "' " & _
                                " AND rep_no = " & Str(VB6.GetItemData(cbRepCaption, cbRepCaption.SelectedIndex)) & _
                                " AND report_id = " & Str(bm.Cells("Report").Value)

                        cm = cn.CreateCommand() '.let_ActiveConnection(cn)
                        cm.CommandType = CommandType.Text
                        cm.CommandText = sStmt
                        cm.Transaction = nTran

                        nRecords = cm.ExecuteNonQuery()
                        If nRecords > 0 Then
                            'Delete from GlmCostCont
                            sStmt = "DELETE FROM GlmCostCont " & " WHERE report_id =" & Str(bm.Cells("Report").Value)

                            cm.CommandText = sStmt
                            nRecords = cm.ExecuteNonQuery()
                        End If

                        'Insert deleted record in glmCostContDeleted table for QlikView

                        nId = get_next_seq("glmCostContDeleted", "id", nTran)

                        sStmt = "INSERT INTO glmCostContDeleted (id, cust_id, report_id) " & _
                                " VALUES (" & _
                                    Str(nId) & ",'" & _
                                    Trim(bm.Cells("Cust").Value) & "'," & _
                                    Str(bm.Cells("Report").Value) & ")"

                        cm.CommandText = sStmt
                        nRecords = cm.ExecuteNonQuery()
                        If nRecords = 0 Then
                            MsgBox("An error occurred when removing report flag. Please check log file for details", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                            nTran.Rollback()
                            Exit Sub
                        End If

                        nTran.Commit()

                        load_dgReport()
                        MsgBox("Report was successfully updated", MsgBoxStyle.OkOnly, "Message")

                    End If
                Else
                    MsgBox("No action is required since selected report is not Final Version", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message")

                End If
            End If
        End If
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub
End Class