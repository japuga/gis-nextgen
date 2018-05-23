Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmInvoiceBillSummary
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
	Private XLApp As Microsoft.Office.Interop.Excel.Application
	
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		If cbCustName.SelectedIndex >= 0 Then
			cbCustId.SelectedIndex = cbCustName.SelectedIndex
		End If
		load_cbGroupName(cbCustId.Text)
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOpen_Click()
		Dim sDir As String
		Dim fs As Scripting.FileSystemObject
		Dim sFilename As String
		
		On Error GoTo ErrorHandler
		
		fs = New Scripting.FileSystemObject
		
		sDir = My.Application.Info.DirectoryPath
		If Not fs.FolderExists(sDir) Then
			sDir = "c:\"
		End If
		
		
		cdFileSave.InitialDirectory = sDir 'Directorio para guardar archivo IIF
        cdFileSave.DefaultExt = ".xlsx"
		'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        cdFileSave.Filter = "Excel Files (*.xlsx)|*.xlsx"
		cdFileSave.FilterIndex = 1
		'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'

        ' no entiendo esta linea, preguntar a javier.
        'cdFile.CancelError = True 'Genera un error 32755 si el usuario escoge Cancel al guardar Save

        If cdFileSave.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            If Trim(cdFileSave.FileName) = "" Then
                sFilename = ""
                MsgBox("Unable to Load Info, Please provide a Data FIle.", MsgBoxStyle.OkOnly, "GLM Warning")
            Else
                If fs.FileExists(cdFileSave.FileName) Then
                    sFilename = cdFileSave.FileName
                    txtExcelFile.Text = cdFileSave.FileName
                Else
                    sFilename = ""
                    MsgBox("Such  files does not exist.")
                End If
            End If
        End If
		
		
		
		
		
		Exit Sub
		
ErrorHandler: 
		
		'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
		If Err.Number = DialogResult.Cancel Then
			'Usuario selecciono cancel en OpenDialog
			MsgBox("Operation was cancelled by user.", MsgBoxStyle.OKOnly, "GLM Warning")
			Exit Sub
		Else
			save_error(Me.Name, "cmdOpen")
			MsgBox("An error occurred while opening file. Try again.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			
		End If
		
		
	End Sub
	
	Private Sub cmdUnloadData_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUnloadData.Click
		If val_fields Then
			save_data(cbCustId.Text, VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex), cbGroupName.Text)
			Me.Close()
		End If
	End Sub
	
	Private Function val_fields() As Boolean
		val_fields = True
        Dim groupName As String = cbGroupName.Text
        If Trim(groupName) = "" Then 'cbGroupName.SelectedIndex < 0 Then
            MsgBox("Please select a group before attempting this command.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            val_fields = False
            cbGroupName.Focus()
            Exit Function
        End If
		
	End Function
	
	
	Private Function unload_data(ByRef sCustId As String, ByRef nGroupSeq As Short, ByRef sGroupName As String, ByRef sFilename As String) As Boolean
		
		
		Dim wb As Microsoft.Office.Interop.Excel.Workbook
		Dim ws As Microsoft.Office.Interop.Excel.Worksheet
		Dim bError As Boolean
		Dim nCountInvoices As Short
		
		unload_data = False
		bError = False
		
		On Error GoTo ErrorHandler
		
		'Set wb = Excel.Application.Workbooks.Add
		open_excel_app()
		
		wb = XLApp.Workbooks.Add
		ws = wb.Worksheets.Add
		ws.name = "GLM Billing"
		
		nCountInvoices = count_invoices(sCustId, nGroupSeq)
		
		If nCountInvoices > 0 Then
			If add_header(ws) Then
				If add_detail(sCustId, nGroupSeq, sGroupName, ws, nCountInvoices) Then
					If add_footer(ws) Then
						'MsgBox "Download complete.", vbInformation + vbOKOnly, "GLM Message"
						'ok
					Else
						bError = True
					End If
				Else
					bError = True
				End If
			Else
				bError = True
			End If
		Else
			If nCountInvoices = 0 Then
				bError = True
				MsgBox("There are no invoices to process.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
			End If
		End If
		'ws.Cells(2, 1).Value = "12/26/06"
		'wb.SaveAs "c:\ejemplo.xls", xlExcel7
		
		If bError Then
			wb.Close(False)
		Else
			'Excel.Application.Visible = True
			wb.SaveAs(sFilename)
			wb.Close()
			'wb.Close True, Null
		End If
		
		close_excel_app()
		
		unload_data = Not bError
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "unload_data")
		wb.Close(False)
		close_excel_app()
		
	End Function
	Private Function save_data(ByRef sCustId As String, ByRef nGroupSeq As Short, ByRef sGroupName As String) As Boolean
		Dim sDir As String
		Dim fs As Scripting.FileSystemObject
		Dim dDate As Date
		
		On Error GoTo ErrorHandler
		
		fs = New Scripting.FileSystemObject
        sDir = OSdriveLetter + "glm"
		dDate = Today
		
		If Not fs.FolderExists(sDir) Then
			sDir = "c:\"
		End If
		
		
		cdFileSave.InitialDirectory = sDir 'Folder to save invoice data file
        cdFileSave.DefaultExt = "xlsx"
		'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        cdFileSave.Filter = "Excel Files (*.xlsx)|*.xlsx"
		
		
		cdFileSave.FileName = "Invoices-" & VB6.Format(dDate, "mmddyy") 'Default file name
		'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'

        'preguntar a javier
        'cdFile.CancelError = True 'Raises an error 32755 if user Cancels operation

        If Not cdFileSave.ShowDialog() = Windows.Forms.DialogResult.Cancel Then

            If Trim(cdFileSave.FileName) = "" Then
                MsgBox("Unable to Export Invoices. Please provide a file to save data.", MsgBoxStyle.OkOnly, "GLM Warning")
            Else
                'Build Excel file
                txtExcelFile.Text = cdFileSave.FileName
                If Not unload_data(sCustId, nGroupSeq, sGroupName, (cdFileSave.FileName)) Then
                    MsgBox("An error has ocurred. Unable to export data", MsgBoxStyle.OkOnly, "GLM Error")
                Else
                    If update_invoice_status() Then
                        MsgBox("Data exported successfully", MsgBoxStyle.OkOnly, "GLM Message")
                    Else
                        MsgBox("Unable to update Invoice Info. Please try again.", MsgBoxStyle.OkOnly, "GLM Error")
                    End If
                End If
                Me.Close()
            End If
        End If
        Exit Function

ErrorHandler:
        save_data = False
        MsgBox("Unexpected error while saving invoice data." & vbCrLf & "Please check log file for further details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")

    End Function
	Private Function count_invoices(ByRef sCustId As String, ByRef nGroupSeq As Short) As Short
        Dim cmd As SqlCommand = cn.CreateCommand()
		count_invoices = -1
		
		sStmt = "SELECT COUNT(DISTINCT a.invoice_no) " & "FROM vinvoice  a, vinvoiceDet b, store c " & "WHERE a.cust_id ='" & sCustId & "'" & "AND a.group_seq=" & Str(nGroupSeq) & "AND a.cust_id = b.cust_id " & "AND a.invoice_no = b.invoice_no " & "AND a.store_id = b.store_id " & "AND a.account_no = b.account_no " & "AND a.vend_seq = b.vend_seq " & "AND a.cust_id = c.cust_id " & "AND a.store_id = c.store_id "
        cmd.CommandText = sStmt
		
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader()

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If rsLocal.Rows.Count < 1 Then
            MsgBox("Could not determine number of invoices to process. " & "Please try again", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Function
        End If
        If IsDBNull(rsLocal.Rows(0).Item(0)) Then
            MsgBox("Could not determine number of invoices to process. " & "Please try again", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Function
        Else
            count_invoices = rsLocal.Rows(0).Item(0)
        End If


        MsgBox("Number of invoices to process:" & Str(rsLocal.Rows(0).Item(0)))
    End Function
	Private Function add_header(ByRef ws As Microsoft.Office.Interop.Excel.Worksheet) As Boolean
		
		On Error GoTo ErrorHandler
		
		'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ws.Cells._Default(1, 1).Value = "Invoice Number"
		'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ws.Cells._Default(1, 2).Value = "Invoice Date"
		'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ws.Cells._Default(1, 3).Value = "Work Order"
		'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ws.Cells._Default(1, 4).Value = "Subcontract"
		'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ws.Cells._Default(1, 5).Value = "Tax"
		'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ws.Cells._Default(1, 6).Value = "Subcontractor Total"
		'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ws.Cells._Default(1, 7).Value = "GLM Fee"
		'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ws.Cells._Default(1, 8).Value = "Total"
		'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ws.Cells._Default(1, 9).Value = "Description"
		'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ws.Cells._Default(1, 10).Value = "Site Id"
		'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ws.Cells._Default(1, 11).Value = "Past Due Status"
		'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ws.Cells._Default(1, 12).Value = "Past Due Amount"
		
		add_header = True
		Exit Function
ErrorHandler: 
		add_header = False
		MsgBox("An unexpected error occurred while writing " & "to Excel file." & vbCrLf & "Please check log file for further details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
		
		
	End Function
	Private Function add_detail(ByRef sCustId As String, ByRef nGroupSeq As Short, ByRef sGroupName As String, ByRef ws As Microsoft.Office.Interop.Excel.Worksheet, ByRef nCountInvoices As Short) As Boolean
		
		Dim nRow As Short
		Dim nCol As Short
		Dim nFee As Double
		Dim sDescription As String
        Dim nPercent As Short
        Dim cmd As SqlCommand = cn.CreateCommand()
		
		On Error GoTo ErrorHandler
		
		
		prbLoad.Value = 0
		prbLoad.Visible = True
		
		'1.Get a list of invoices and totals per invoice
		sStmt = "SELECT a.invoice_no, a.vinvoice_date," & " a.work_order, a.account_no, c.store_number,SUM(b.subtotal) tot " & "FROM vinvoice  a, vinvoiceDet b, store c " & "WHERE a.cust_id ='" & sCustId & "'" & "AND a.group_seq=" & Str(nGroupSeq) & "AND a.cust_id = b.cust_id " & "AND a.invoice_no = b.invoice_no " & "AND a.store_id = b.store_id " & "AND a.account_no = b.account_no " & "AND a.vend_seq = b.vend_seq " & "AND a.cust_id = c.cust_id " & "AND a.store_id = c.store_id " & "GROUP BY a.invoice_no, a.vinvoice_date," & " a.work_order, a.account_no, c.store_number"
        cmd.CommandText = sStmt
		
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        If rsLocal.Rows.Count > 0 Then
            'Details sent to Excel file
            nRow = 1

            For arow As Integer = 0 To rsLocal.Rows.Count - 1 'While rsLocal.Read()
                'nPercent = nRow * 100 / nCountInvoices
                'prbLoad.Value = nPercent

                If nRow > 327 Then
                    nPercent = CShort(nRow * 100 / nCountInvoices)
                    prbLoad.Value = nPercent

                End If

                nRow = nRow + 1
                nCol = 1

                'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells(nRow, 1).Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ws.Cells._Default(nRow, 1).Value = rsLocal.Rows(arow).Item("invoice_no")

                'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells(nRow, 2).Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ws.Cells._Default(nRow, 2).Value = CDate(rsLocal.Rows(arow).Item("vinvoice_date"))

                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                If IsDBNull(rsLocal.Rows(arow).Item("tot")) Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ws.Cells._Default(nRow, 3).Value = ""
                Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells(nRow, 3).Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ws.Cells._Default(nRow, 3).Value = rsLocal.Rows(arow).Item("work_order")
                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells(nRow, 4).Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ws.Cells._Default(nRow, 4).Value = rsLocal.Rows(arow).Item("tot")
                'Hard Coded
                'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ws.Cells._Default(nRow, 5).Value = 0 'Tax
                'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells(nRow, 6).Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells(nRow, 5).Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ws.Cells._Default(nRow, 6).Value = rsLocal.Rows(arow).Item("tot") + ws.Cells._Default(nRow, 5).Value

                nFee = get_fee(sCustId, rsLocal.Rows(arow).Item("tot"))
                If nFee <= 0 Then
                    MsgBox("Could not retrieve Fee information for invoice: " + rsLocal.Rows(arow).Item("invoice_no"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    add_detail = False
                    Exit Function
                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ws.Cells._Default(nRow, 7).Value = nFee
                'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells(nRow, 8).Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ws.Cells._Default(nRow, 8).Value = rsLocal.Rows(arow).Item("tot") + nFee
                sDescription = Trim(quotation_mask(sGroupName)) & " Waste - Acct." & Trim(quotation_mask(rsLocal.Rows(arow).Item("account_no")))
                'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ws.Cells._Default(nRow, 9).Value = sDescription
                'Hard Coded
                'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells(nRow, 10).Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ws.Cells._Default(nRow, 10).Value = rsLocal.Rows(arow).Item("store_number")
                'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ws.Cells._Default(nRow, 11).Value = "N/A"
                'UPGRADE_WARNING: Couldn't resolve default property of object ws.Cells().Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ws.Cells._Default(nRow, 12).Value = 0
            Next arow
        End If
		prbLoad.Visible = False
		add_detail = True
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "add_detail")
		
	End Function
	Private Function add_footer(ByRef ws As Microsoft.Office.Interop.Excel.Worksheet) As Boolean
		add_footer = True
	End Function
	Private Function get_fee(ByRef sCustId As String, ByRef nTotal As Double) As Double
		sStmt = "SELECT range_fee_value " & "FROM feeBillingRange " & "WHERE " & Str(nTotal) & " BETWEEN lower_bound AND upper_bound " & "AND fee_id IN(" & " SELECT fee_id FROM fee " & " WHERE cust_id='" & sCustId & "'" & " AND fee_type_id=(SELECT fee_type_id " & "    FROM feeType " & "    WHERE fee_desc='Billing Range Fee')) "
        Dim cmd As sqlcommand = cn.CreateCommand()
		
        rs = getDataTable(sStmt) 'cmd.ExecuteReader()

        If rs.Rows.Count > 0 Then
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item("range_fee_value")) Then
                get_fee = 0
            Else
                get_fee = rs.Rows(0).Item("range_fee_value")
            End If
        End If

		
	End Function
	Private Function open_excel_app() As Boolean
		On Error GoTo ErrorHandler
		
		open_excel_app = False
		
        XLApp = CreateObject("Excel.Application") 'GetObject( , "excel.application")
		XLApp.Visible = False
		open_excel_app = True
		
ErrorEnd: 
		Exit Function
		
ErrorHandler: 
		If Err.Number = XL_NOTRUNNING Then
			XLApp = New Microsoft.Office.Interop.Excel.Application
			
			Resume Next
		End If
		Resume ErrorEnd
		
	End Function
	Private Sub close_excel_app()
		'UPGRADE_NOTE: Object XLApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		XLApp = Nothing
		
	End Sub
	
	Private Sub frmInvoiceBillSummary_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		
        rsLocal = Nothing
        txtExcelFile.Text = ""
		
		'CustName
		sStmt = "SELECT DISTINCT c.cust_name, u.cust_id " & " FROM suser_data u, customer c " & " WHERE u.cust_id = c.cust_id " & " AND u.suser_name = '" & gsUser & "' " & " ORDER BY c.cust_name"
		load_cb_query2(cbCustName, sStmt, 1, True)
		
		'CustId
		sStmt = "SELECT DISTINCT u.cust_id, c.cust_name " & " FROM suser_data u, customer c " & " WHERE u.cust_id = c.cust_id " & " AND u.suser_name = '" & gsUser & "'" & " ORDER BY c.cust_name"
		load_cb_query2(cbCustId, sStmt, 1, True)
		
		If cbCustName.Items.Count > 0 Then
			cbCustName.SelectedIndex = 0
		End If
		
		prbLoad.Visible = False
		
	End Sub
	
	Private Sub load_cbGroupName(ByRef sCustId As String)
		sStmt = "SELECT group_name, group_seq " & " FROM VInvoiceGroup " & " WHERE cust_id ='" & sCustId & "'" & " AND group_status='OPEN'"
		load_cb_query2(cbGroupName, sStmt, 2, True)
		
		If cbGroupName.Items.Count > 0 Then
			cbGroupName.SelectedIndex = 0
		End If
		
	End Sub
	'Updates the invoice status after it has been downloaded
	Private Function update_invoice_status() As Boolean
		update_invoice_status = True
	End Function
End Class