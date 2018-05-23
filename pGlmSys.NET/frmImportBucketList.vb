Option Strict Off
Option Explicit On
Friend Class frmImportBucketList
	Inherits System.Windows.Forms.Form
	Private XLApp As Microsoft.Office.Interop.Excel.Application
	Private XL_wbook As Microsoft.Office.Interop.Excel.Workbook
	Private XL_bucketlist_wsheet As Microsoft.Office.Interop.Excel.Worksheet
	
	Private Const BUCKETLIST_SHEET As String = "bucketlist"
	Private Const RAW_BUCKETLIST As String = "tmp_bucketlist"
	
	'UPGRADE_WARNING: Lower bound of array a was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Private a(100) As String
    Private rsLocal As DataTable
    Private rsLocal2 As DataTable
	
	Private Sub initHeaderArray()
		
		a(1) = "Property #"
		a(2) = "Benchmark Date"
		
	End Sub
	
	
	Private Sub cmdImport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImport.Click
		
        Dim jobid As Integer = 0

        'funcion no terminada (Javier)
        MsgBox("Funcion not implemented yet")
        Exit Sub

        '1.Load Exce file into raw_bucketlist table
        jobid = load_xls_to_bucketlist()
        '2.Read from raw_bucketlist table and update VContract info
        If jobid = 0 Then
            Exit Sub
        End If

        If upload_bucketlist(jobid) = False Then
            cleanup(jobid)
        End If


    End Sub
    Private Function load_xls_to_bucketlist() As Integer
        Dim sFilename As String

        sFilename = txtFile.Text

        'PENDIENTE
        'Modificar el resto de la funcion para leer hoja BUCKETLIST ,
        'validar cabecera y guardar en tabla RAW_BUCKETLIST


        On Error GoTo ErrorHandler

        If Len(sFilename) > 0 Then
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            sbLoad.Text = "Opening Excel File...."
            'UPGRADE_WARNING: Couldn't resolve default property of object openExcelFile(sFilename, XLApp, XL_wbook). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If openExcelFile(sFilename, XLApp, XL_wbook) = True Then
                sbLoad.Text = "Searching Excel Sheet..."
                '1.Read spreadsheets
                XL_bucketlist_wsheet = getExcelWorksheet(BUCKETLIST_SHEET, XL_wbook)

                If XL_bucketlist_wsheet Is Nothing Then
                    closeExcelFile(XLApp, XL_wbook)
                Else
                    sbLoad.Text = "Found " & BUCKETLIST_SHEET & " Worksheet"
                End If


                '2.Validate
                validate_header()


            End If
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Else
            MsgBox("Please select an Excel file before attempting this command", MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Function
        End If




        'Verificar Columnas
        sbLoad.Text = "Checking column headers..."
        'nNumCols = check_header(sSheetName)
        'If nNumCols <= 0 Then
        '    close_excel_file
        '    Exit Function
        'End If

        'nRows = count_sheet_rows

        'Cargar Datos
        'sbLoad.SimpleText = "Verifying data...."
        'load_sheet sSheetName, nNumCols, nRows


        'close_excel_file
        sbLoad.Text = "Done"


        Exit Function

ErrorHandler:
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default







        load_xls_to_bucketlist = 1
    End Function

    Private Function validate_header() As Boolean

        Dim colName As String
        Dim i As Short
        Dim numCols As Short

        'Validate column names in row 1
        For i = 1 To XL_bucketlist_wsheet.Columns.Count
            numCols = numCols + 1
            'UPGRADE_WARNING: Couldn't resolve default property of object XL_bucketlist_wsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            colName = XL_bucketlist_wsheet.Cells._Default(1, i)
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(colName) Or Len(colName) = 0 Then
                Exit For
            End If
        Next i

        MsgBox(numCols)

    End Function
    'Deletes all records from raw_bucketlist
    Private Sub cleanup(ByRef jobid As Integer)
        Dim nRecords As Short

        sStmt = "DELETE FROM tmp_bucketlist WHERE jobid=" & Str(jobid)

        cm = cn.CreateCommand '.let_ActiveConnection(cn)
        cm.CommandText = sStmt
        nRecords = cm.ExecuteNonQuery()
        If nRecords > 0 Then
            'ok
        Else
            MsgBox(CDbl("Failed removing records for job:") + jobid, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
        End If

    End Sub
    'Loops thru all records in the Excel file and check which ones have
    'enough data to update a contract
    Private Function upload_bucketlist(ByRef jobid As Integer) As Boolean
        Dim stmt As String

        upload_bucketlist = True

        stmt = "SELECT jobid, xls_rowid, cust_id, store_number, [Property #], [Benchmark Date], [Managed By GLM], " & "[Franchised Status], [Disposition List], [Location Type]," & "[Property Name], [Property Address], [City], [State], " & "[Vendor], vbranch, vend_seq, account_no, [Recycling at Location], [Company Type], " & "[MRF], [Fully Executed], [Contract Status], " & "[GLM Negotiation Status], [Signatures Needed], " & "[Effective Start Date], [Expiration_Date], [Contract Under Review], " & "[Does Contract Need Addendum], [Contract Variance], [Notes], " & "[Contract in LF?], [Contract Entry ID], [Addendum? Y/N], " & "[Addendum in LF?], [Addendum Entry ID], [Equipment], " & "[F31], [F32], [F33], [Contents], [Frequency], eqpt_qty, build, equip, load_type, content, " & "[F36], [F37], " & "[Service Changes], [Current Act Info], [Does Act Need Update Y/N], " & "[Was Acted Update Y/N], [Rates], [F43], [F44], [F45], " & "[F46], [F47], [Contract Notes], [Fuel Surcharge Cap]," & "[Environmental Fee Cap], [CPI Year 1], [CPI Year 2]," & "[CPI Year 3], [Certificate of Insurance (COI)], " & "[COI in LF? Y/N], [COI Entry ID], [Insurance Company]," & "[COI Start Date] , [COI End Date], [Insurance Terms] " & "From [glm].[dbo].[tmp_bucketlist] " & " WHERE jobid=" & Str(jobid)

        stmt = "SELECT jobid, xls_rowid, cust_id, store_number,  " & " vbranch, vend_seq, account_no," & " eqpt_qty, build, equip, load_type, content " & "From [glm].[dbo].[tmp_bucketlist] " & " WHERE jobid=" & Str(jobid)

        rsLocal = getDataTable(stmt) '.Open(stmt, cn, ADODB.CursorTypeEnum.adOpenStatic)


        For row As Integer = 0 To rsLocal.Rows.Count - 1
            'UPGRADE_WARNING: Couldn't resolve default property of object gDump. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gDump = valid_parameters()
            If gDump.str1 = "TRUE" Then

                stmt = "SELECT a.cust_id, a.store_id, a.vend_seq, a.eqpt_seq " & " FROM vaccountEqpt a , storeEqpt c " & " WHERE a.cust_id = '" + rsLocal.Rows(row).Item("cust_id").value + "' " + " AND a.store_id = (select b.store_id from store b " + "       where b.cust_id = a.cust_id " + "       and b.store_number ='" + rsLocal.Rows(row).Item("store_number").value + "') " + " AND a.account_no ='" + rsLocal.Rows(row).Item("account_no").Value + "' " + " AND a.vend_seq = " + Str(rsLocal.Rows(row).Item("vend_seq").value) + " AND a.cust_id = c.cust_id " + " AND a.store_id = c.store_id  " + " AND a.eqpt_seq = c.eqpt_seq " + " AND c.eqpt_desc = '" + rsLocal.Rows(row).Item("equip").value + "'"

                rsLocal2 = getDataTable(stmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic)

                If rsLocal2.Rows.Count > 0 Then
                    update_contract(jobid, (rsLocal.Rows(row).Item("xls_rowid").value), (rsLocal2.Rows(0).Item("cust_id").value), (rsLocal2.Rows(0).Item("store_id").value), (rsLocal2.Rows(0).Item("vend_seq").value), (rsLocal2.Rows(0).Item("eqpt_seq").value), (rsLocal.Rows(row).Item("servId").value), (rsLocal.Rows(row).Item("Rate2").value), (rsLocal.Rows(row).Item("Effective Start Date").value), (rsLocal.Rows(row).Item("Expiration_date").value))
                Else
                    updateRecordStatus(jobid, (rsLocal.Rows(row).Item("xls_rowid").value), UPLOAD_STATUS_FAILED, "Could not find contract associated with this row")
                End If

            Else
                'upload_bucketlist = False
                'MsgBox gDump.str2 + vbCrLf + " Process was aborted", _
                ''        vbCritical + vbOKOnly, "GLM Error"
                'Exit Do
                updateRecordStatus(jobid, (rsLocal.Rows(row).Item("xls_rowid").value), UPLOAD_STATUS_FAILED, gDump.str2)
            End If


        Next row





    End Function
    Private Sub updateRecordStatus(ByRef jobid As Integer, ByRef rowid As Integer, ByRef status As String, Optional ByRef errorMessage As String = "")
        Dim updateStmt As String = ""

        If status = UPLOAD_STATUS_FAILED Then

            updateStmt = "UPDATE tmp_bucketlist " & " SET upload_status = '" & UPLOAD_STATUS_FAILED & "'," & " error_message='" & errorMessage & "' " & " WHERE jobid =" & Str(jobid) & " AND xls_rowid = " + rsLocal.Rows(0).Item("xls_rowid").value


        ElseIf status = UPLOAD_STATUS_VALID Then
            updateStmt = "UPDATE tmp_bucketlist " & " SET upload_status = '" & UPLOAD_STATUS_VALID & "'," & " WHERE jobid =" & Str(jobid) & " AND xls_rowid = " + rsLocal.Rows(0).Item("xls_rowid").value

        ElseIf status = UPLOAD_STATUS_COMPLETE Then
            updateStmt = "UPDATE tmp_bucketlist " & " SET upload_status = '" & UPLOAD_STATUS_COMPLETE & "'," & " WHERE jobid =" & Str(jobid) & " AND xls_rowid = " + rsLocal.Rows(0).Item("xls_rowid").value
        End If

        cm = cn.CreateCommand '.let_ActiveConnection(cn)
        cm.CommandType = CommandType.Text
        cm.CommandText = updateStmt
        cm.ExecuteNonQuery()

    End Sub

    Private Sub update_contract(ByRef jobid As Integer, ByRef xls_rowid As Integer, ByRef sCustId As String, ByRef storeId As Short, ByRef vendSeq As Short, ByRef eqptSeq As Short, ByRef servId As Short, ByRef newRate As Double, ByRef newOpeningDate As Date, ByRef newExpirationDate As Date)

        Dim rsContract As DataTable
        Dim nRecords As Short
        Dim stmt As String

        stmt = "SELECT curr_rate, opening_date, expiration_date " & " FROM VContract a " & " WHERE a.cust_id ='" & sCustId & "' " & " AND a.store_id = " & Str(storeId) & " AND a.vend_seq = " & Str(vendSeq) & " AND a.eqpt_seq = " & Str(eqptSeq) & " AND a.serv_id = " & Str(servId)

        rsContract = getDataTable(stmt) '.Open(stmt, cn, ADODB.CursorTypeEnum.adOpenStatic)

        If rsContract.Rows.Count > 0 Then

            stmt = CStr(System.DateTime.FromOADate(CDate("UPDATE VContract " & " SET   opening_date = ").ToOADate + newOpeningDate.ToOADate + CDate(",").ToOADate + CDate("    expiration_date = ").ToOADate + newExpirationDate.ToOADate + CDate(" WHERE cust_id ='").ToOADate + CDate(sCustId).ToOADate + CDate("' ").ToOADate + CDate(" AND store_id = ").ToOADate + CDate(Str(storeId)).ToOADate + CDate(" AND vend_seq = ").ToOADate + CDate(Str(vendSeq)).ToOADate + CDate(" AND eqpt_seq = ").ToOADate + CDate(Str(eqptSeq)).ToOADate + CDate(" AND serv_id = ").ToOADate + CDate(Str(servId)).ToOADate + CDate("").ToOADate))

            nRecords = 0
            cm = cn.CreateCommand '.let_ActiveConnection(cn)
            cm.CommandType = CommandType.Text
            cm.CommandText = stmt
            nRecords = cm.ExecuteNonQuery()
            If nRecords > 0 Then
                updateRecordStatus(jobid, xls_rowid, UPLOAD_STATUS_COMPLETE)
            Else
                updateRecordStatus(jobid, xls_rowid, UPLOAD_STATUS_FAILED, "Failed to update contract info")
            End If

        Else
            updateRecordStatus(jobid, xls_rowid, UPLOAD_STATUS_FAILED, "Could not find a Contract for the combination:" & vbCrLf & "CustId:" & sCustId & vbCrLf & "StoreId:" & Str(storeId) & "VendSeq:" & Str(vendSeq) & "EqptSeq:" & Str(eqptSeq) & "ServId:" & Str(servId))
        End If



    End Sub

    Private Sub cmdOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOpen.Click
        Dim sFilename As String = ""
        Dim fs As Scripting.FileSystemObject
        Dim sDir As String

        fs = New Scripting.FileSystemObject

        sDir = My.Application.Info.DirectoryPath
        sDir = OSdriveLetter + "glm"
        If Not fs.FolderExists(sDir) Then
            sDir = "c:\"
        End If

        txtFile.Text = ""

        cdFileOpen.InitialDirectory = sDir 'Directorio para guardar archivo IIF
        cdFileOpen.DefaultExt = ".xlsx"
        'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        cdFileOpen.Filter = "Excel Files (*.xlsx)|*.xlsx"
        cdFileOpen.FilterIndex = 1

        If cdFileOpen.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        txtFile.Text = cdFileOpen.FileName

    End Sub

    Private Sub frmImportBucketList_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        init_vars()
    End Sub

    Private Sub init_vars()
        rsLocal = Nothing
        rsLocal2 = Nothing

        txtFile.Text = ""
        txtFile.ReadOnly = False
        txtFile.Enabled = False
    End Sub

    Private Function valid_parameters() As gDumpUDT

        'Dim rowid As String
        Dim sCustId As String
        Dim sStoreNumber As String
        Dim xls_rowid As Integer
        Dim stmt As String
        valid_parameters = New gDumpUDT

        xls_rowid = CInt(Str(rsLocal.Rows(0).Item("xls_rowid").value))
        sCustId = rsLocal.Rows(0).Item("cust_id").value
        sStoreNumber = rsLocal.Rows(0).Item("store_number").value

        valid_parameters.str1 = "FALSE"

        'CustId
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(sCustId) Then
            valid_parameters.str2 = CStr(CDbl("Row:") + xls_rowid + CDbl("Missing customer Id"))
            Exit Function
        Else
            If Len(Trim(sCustId)) = 0 Then
                valid_parameters.str2 = CStr(CDbl("Row:") + xls_rowid + CDbl("Customer Id cannot be blank"))
                Exit Function
            End If
        End If


        'StoreNumber
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(sStoreNumber) Then
            valid_parameters.str2 = CStr(CDbl("Row:") + xls_rowid + CDbl("Missing Store Number"))
            Exit Function
        Else
            If Len(Trim(sStoreNumber)) = 0 Then
                valid_parameters.str2 = CStr(CDbl("Row:") + xls_rowid + CDbl("Store Number cannot be blank"))
                Exit Function
            End If
        End If

        stmt = "SELECT store_id FROM store " & " WHERE cust_id='" & sCustId & "' " & " AND store_number ='" & sStoreNumber & "'"

        rs = getDataTable(stmt) '.Open(stmt, cn, ADODB.CursorTypeEnum.adOpenStatic)

        If rs.Rows.Count = 0 Then
            valid_parameters.str2 = "Could not find Store for the combination: Cust:" & sCustId & " StoreNumber:" & sStoreNumber
        End If


        'account_no
        'vend_seq
        'eqpt_desc

        valid_parameters.str1 = "TRUE"

    End Function
End Class