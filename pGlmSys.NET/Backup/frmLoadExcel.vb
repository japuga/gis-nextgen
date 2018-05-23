Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports ExcelMOI = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Friend Class frmLoadExcel
    Inherits System.Windows.Forms.Form

    'Public XLApp As Microsoft.Office.Interop.Excel.Application
    Public XLApp As ExcelMOI.Application = Nothing

    Public xlWorkBooks As ExcelMOI.Workbooks = Nothing
    'Public XL_wbook As Microsoft.Office.Interop.Excel.Workbook
    Public XL_wbook As ExcelMOI.Workbook = Nothing

    'Public XL_wsheet As Microsoft.Office.Interop.Excel.Worksheet
    Public XL_wsheet As ExcelMOI.Worksheet = Nothing
    Dim oRng As Excel.Range

    Private sFilename As String
    Private rsLocal As DataTable
    Private rsTable As DataTable
	Private sWhere As String
	Private sExcelData As String
	Private aStoreEqpt(4) As String
	Private Structure StoreEqptKeyUDT
		Dim store_id As Short
		Dim eqpt_seq As Short
	End Structure
	Private aStoreEqptKey(10000) As StoreEqptKeyUDT
	
	
	
	
	
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		cbCustId.SelectedIndex = cbCustName.SelectedIndex
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub cmdLoadData_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoadData.Click
        Dim sSheetName As String = ""
		
		If obStore.Checked = True Then
			sSheetName = "store"
		End If
		
		If obEquipment.Checked = True Then
			sSheetName = "storeeqpt"
		End If
		
		load_excel_data(sFilename, sSheetName)
	End Sub
	
	
	Private Sub load_excel_data(ByRef sFilename As String, ByRef sSheetName As String)
        Dim sheetTmp As ExcelMOI.Worksheet
		Dim bFound As Boolean
		Dim nRows As Short
		Dim nNumCols As Short
		
		On Error GoTo ErrorHandler
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        sbLoad.Items(0).Text = "Opening Excel File...."
        If IO.File.Exists(sFilename) Then
            If open_excel_file(sFilename) = True Then
                'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                'Buscar Hoja con Datos
                bFound = False
                sbLoad.Items(0).Text = "Searching Excel Sheet..."
                For Each sheetTmp In XL_wbook.Worksheets
                    'Set XL_wsheet = XL_wbook.Sheets("tiendas")
                    If LCase(sheetTmp.Name) = LCase(sSheetName) Then
                        XL_wsheet = sheetTmp
                        bFound = True
                        Exit For
                    End If
                Next sheetTmp
                If Not bFound Then
                    MsgBox("Excel File does not include expected WorkSheet: '" & sSheetName & "'" & vbCrLf & "Please select another file and try again.")

                    close_excel_file()
                    Exit Sub
                Else
                    sbLoad.Items(0).Text = "Found Excel Worksheet"
                    'MsgBox "Found"
                End If
            End If
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default


            'Verificar Columnas
            sbLoad.Items(0).Text = "Checking column headers..."
            nNumCols = check_header(sSheetName)
            If nNumCols <= 0 Then
                close_excel_file()
                Exit Sub
            End If

            nRows = count_sheet_rows()

            'Cargar Datos
            sbLoad.Items(0).Text = "Verifying data...."
            load_sheet(sSheetName, nNumCols, nRows)


            close_excel_file()
            sbLoad.Items(0).Text = "Done"
            Exit Sub
        Else
            MsgBox("File not found")
        End If

ErrorHandler:
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        save_error(Me.Name, "load_excel_data")
        MsgBox("Unexpected error found when loading Excel Data. " & vbCrLf & "Check log file for details.")
    End Sub
	
	Private Function open_excel_file(ByRef sFilename As String) As Boolean
		
		On Error GoTo ErrorHandler
		
        open_excel_file = False
        'Dim XLApp As ExcelMOI.Application = Nothing
        'Dim XL_wbook As ExcelMOI.Workbook = Nothing
        'Dim xlWorkSheet As ExcelMOI.Worksheet = Nothing
        'Dim xlWorkSheets As ExcelMOI.Sheets = Nothing


        XLApp = New ExcelMOI.Application()
        XLApp.DisplayAlerts = False
        xlWorkBooks = XLApp.Workbooks
        XL_wbook = xlWorkBooks.Open(sFilename)
        XLApp.Visible = False
        'xlWorkSheets = xlWorkBook.Sheets
		
        'XLApp = CreateObject("Excel.Application") 'GetObject( , "excel.application")
        'XL_wbook = XLApp.Workbooks.Open(sFilename)
        'XLApp.Visible = False
		open_excel_file = True
		
ErrorEnd: 
		Exit Function
		
ErrorHandler: 
		If Err.Number = XL_NOTRUNNING Then
			'Comentado para eliminar referencia a Excel Lib
            'XLApp = New Microsoft.Office.Interop.Excel.Application
			
			Resume Next
		End If
		Resume ErrorEnd
		
	End Function
	Private Sub close_excel_file()
		XL_wbook.Saved = True
        XL_wbook.Close()
		'UPGRADE_NOTE: Object XLApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		XLApp = Nothing
		
	End Sub
	'Verificar que todas las columnas de tabla existan,
	'Retorna el numero de columnas
	Private Function check_header(ByRef sTableName As Object) As Short
		Dim nCount As Short
		Dim sCell As String
		Dim bOk As Boolean
		Dim nNumCols As Short
		
		'MsgBox XL_wsheet.Range("a1")
		'MsgBox Str(Asc("A"))
		bOk = True
		nNumCols = 0
		sStmt = "SELECT name FROM syscolumns WHERE id = " & " (SELECT id FROM sysobjects " & " WHERE name ='" & Trim(sTableName) & "')" & " ORDER BY colid"
		

        Try
            rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rsLocal.Rows.Count > 0 Then

                nCount = 64
                For row As Integer = 0 To rsLocal.Rows.Count - 1
                    nCount = nCount + 1

                    sCell = Chr(nCount) & "1"
                    If rsLocal.Rows(row).Item("name") = XL_wsheet.Range(sCell)._Default Then
                        'ok
                        nNumCols = nNumCols + 1
                    Else
                        'error
                        bOk = False
                        Exit For
                    End If
                Next
                

                If Not bOk Then
                    MsgBox("One or more columns were not found " & "on Excel Sheet or columns order was incorrect.", MsgBoxStyle.Exclamation, "GLM Warning")
                    check_header = nNumCols
                    Exit Function
                End If
            Else
                'No se encontraron las columnas de la tabla
                MsgBox("Unable to check columns " & "of table:" + sTableName + ". Aborting,data was not loaded.", MsgBoxStyle.Exclamation, "GLM Warning")
                check_header = nNumCols
                Exit Function
            End If
        Catch ex As Exception
            MsgBox("Unexpected error when Checking header data", MsgBoxStyle.Exclamation, "GLM Warning")
            check_header = nNumCols
            Exit Function
        End Try
		
		check_header = nNumCols
		Exit Function
		

		save_error(Me.Name, "check_header")
		MsgBox("Unexpected error occurred when Checking header data", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
	End Function
	Private Function count_sheet_rows() As Short
		Dim bOk As Boolean
		Dim nCount As Short
		Dim nRow As Short
		Dim sCell As String
		
        Try
            bOk = True
            nCount = 0
            nRow = 1

            Do While bOk
                nRow = nRow + 1
                sCell = "A" & Trim(Str(nRow))
                If IsNothing(XL_wsheet.Range(sCell).Value) Or XL_wsheet.Range(sCell).Value.ToString() = "" Or nRow >= 10000 Then
                    bOk = False
                Else
                    nCount = nCount + 1
                End If
            Loop
            count_sheet_rows = nCount
            Exit Function

        Catch e As Exception
            count_sheet_rows = nCount
            'save_error(Me.Name, "count_sheet_rows")
            'MsgBox("Unexpected error when counting records.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
        End Try
    End Function
	Private Sub load_sheet(ByRef sTableName As String, ByRef nNumCols As Short, ByRef nExcelRows As Short)
		Dim bOk As Boolean
		Dim nCount As Short
		Dim nRow As Short
        Dim sCell As String = ""
		Dim nCol As Short
		Dim i As Short
        Dim sTableField As String = ""
        Dim sTmp As String = ""
		Dim nRecords As Short
		Dim nPercent As Short
		
        Try
            prbLoad.Value = 0
            prbLoad.Visible = True
            bOk = True
            nCount = 0
            nRow = 1
            nRecords = 0


            Select Case sTableName
                Case "store"
                    sTmp = "SELECT cust_id, store_id, store_number, store_name, store_phone1, " & _
                            " store_phone2, store_fax1, store_fax2, store_address," & _
                            " store_city, state_id, store_zip, store_contact, store_status," & " store_folder, store_co_code " & _
                            " FROM store WHERE store_id = -1"
                Case "storeeqpt"
                    'sTmp = "SELECT a.cust_id, a.store_id, a.eqpt_seq, a.eqpt_id, a.load_id," + _
                    ''    " a.eqpt_status, a.eqpt_desc, a.content_id, a.eqpt_qty, a.eqpt_temp, " + _
                    ''    " b.store_number  FROM storeeqpt a, Store b " + _
                    ''    " WHERE a.cust_id= b.cust_id " + _
                    ''    " AND a.store_id = a.store_id " + _
                    ''    " AND b.store_id =-1"

                    sTmp = "SELECT a.cust_id, a.store_id, a.eqpt_seq, a.eqpt_id, a.load_id," & _
                           " a.eqpt_status, a.eqpt_desc, a.content_id, a.eqpt_qty, a.eqpt_temp, " & _
                           " a.eqpt_size_capacity, a.eqpt_actual_qty, b.store_number  FROM storeeqpt a, Store b " & _
                           " WHERE a.cust_id= b.cust_id " & " AND a.store_id = a.store_id " & " AND b.store_id =-1"
            End Select

            rsTable = getDataTable(sTmp) '.Open(sTmp, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)
            nNumCols = rsTable.Columns.Count
            If gbDebug Then
                dg1.DataSource = rsTable
            End If

            Do While bOk
                Dim row As DataRow = rsTable.NewRow
                nRow = nRow + 1
                nCol = 64
                rsTable.Rows.Add(row)
                For i = 0 To nNumCols - 1
                    nCol = nCol + 1
                    sCell = Chr(nCol) & Trim(Str(nRow))
                    If nCol = 65 Then 'Col A
                        'Si la primera columna Cliente esta vacia se detiene
                        Try
                            If IsNothing(XL_wsheet.Range(sCell).Value) Or XL_wsheet.Range(sCell).Value = "" Or nRow >= 10000 Then
                                bOk = False
                                rsTable.Rows.RemoveAt(rsTable.Rows.Count - 1)
                                'rsTable.Delete(ADODB.AffectEnum.adAffectCurrent)
                                Exit For
                            End If
                        Catch e As Exception
                            bOk = False
                            rsTable.Rows.RemoveAt(rsTable.Rows.Count - 1)
                            'rsTable.Delete(ADODB.AffectEnum.adAffectCurrent)
                            Exit For
                        End Try
                    End If
                    'Guardar registro

                    If IsDBNull(XL_wsheet.Range(sCell)._Default) Or IsNothing(XL_wsheet.Range(sCell)._Default) Then
                        sExcelData = ""
                    Else
                        sExcelData = XL_wsheet.Range(sCell)._Default
                    End If
                    sTableField = rsTable.Columns(i).ColumnName 'rsTable.Rows(0).Item(i)

                    If val_field(sTableName, sTableField, sCell, nRow) Then
                        'ok
                        rsTable.Rows(rsTable.Rows.Count - 1).Item(i) = Trim(sExcelData)
                    Else
                        prbLoad.Visible = False
                        MsgBox("An error was found at line " & Str(nRow) & " in the Excel file. Correct it and try again. " & vbCrLf & " No record was loaded.", MsgBoxStyle.Exclamation, "GLM Warning")
                        Exit Sub
                    End If

                Next i
                If nExcelRows > 0 Then
                    If bOk Then
                        nPercent = nRow * 100 / nExcelRows
                        If nPercent <= prbLoad.Maximum Then
                            prbLoad.Value = nPercent
                        End If
                    End If
                End If
            Loop
            'rsTable.UpdateBatch adAffectAll
            sbLoad.Items(0).Text = "Loading to database..."
            nRecords = save_table(sTableName)
            MsgBox("Number of Records loaded:" & Str(nRecords))

            If gbDebug Then
                'No cerrar recordset
            Else
                'rsTable.Close()
            End If

            prbLoad.Visible = False
            Exit Sub

        Catch e As Exception
            prbLoad.Visible = False
            sStmt = "load_sheet: Table:" & sTableName & " Field:" & sTableField & " Excel Data:" & sExcelData & " Excel Cell:" & sCell

            save_error(Me.Name, sStmt)
            MsgBox("Error loading data from Excel. " & "Check log file for details.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
        End Try
    End Sub
	'Validar Campos antes de insertar
	Private Function val_field(ByRef sTableName As String, ByRef sTableField As String, ByRef sCell As String, ByRef nRow As Short) As Boolean
		
		Dim sTmp As String
		
		On Error GoTo ErrorHandler
		
		Select Case sTableName
			Case "store"
				Select Case sTableField
					Case "cust_id"
						If UCase(Trim(sExcelData)) = cbCustId.Text Then
							'ok
							sExcelData = UCase(Trim(sExcelData))
						Else
							MsgBox("Found record related to " & "a different Customer." & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
							val_field = False
							Exit Function
						End If
						
					Case "store_id"
						'Este valor se genera
						sExcelData = "-1"
						val_field = True
						Exit Function
						
					Case "store_number"
						'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If IsDbNull(sExcelData) Or Trim(sExcelData) = "" Or Len(sExcelData) = 0 Then
							MsgBox("Found a Null Store Number." & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
							val_field = False
							Exit Function
						End If
						
						sStmt = "SELECT store_id FROM store " & " WHERE cust_id ='" & cbCustId.Text & "' " & " AND RTRIM(store_number) = '" & Trim(sExcelData) & "'"
						
                        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                        If rsLocal.Rows.Count > 0 Then
                            MsgBox("Store number " & sExcelData & " already exists " & " on database. Aborting." & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                            val_field = False
                            Exit Function
                        End If


                    Case "store_name"
                        'Campo es opcional, no se valida
                        val_field = True
                        Exit Function

                    Case "store_phone1"
                        If Len(Trim(sExcelData)) = 0 Then
                            'No se proporciono telefono
                        Else
                            If Len(Trim(sExcelData)) = 10 And IsNumeric(sExcelData) Then
                                sTmp = Trim(sExcelData)
                                sExcelData = "(" & Mid(sTmp, 1, 3) & ")-" & Mid(sTmp, 4, 3) & "-" & Mid(sTmp, 7, 4)
                            Else
                                MsgBox("Incorrect Phone1 Format:" & sExcelData & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                                val_field = False
                                Exit Function
                            End If
                        End If

                    Case "store_phone2"
                        If Len(Trim(sExcelData)) = 0 Then
                            'No se proporciono telefono
                        Else
                            If Len(Trim(sExcelData)) = 10 And IsNumeric(sExcelData) Then
                                sTmp = Trim(sExcelData)
                                sExcelData = "(" & Mid(sTmp, 1, 3) & ")-" & Mid(sTmp, 4, 3) & "-" & Mid(sTmp, 7, 4)
                            Else
                                MsgBox("Incorrect Phone2 Format:" & sExcelData & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                                val_field = False
                                Exit Function
                            End If
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If (IsDBNull(rsTable.Rows(0).Item("store_phone1")) Or Trim(rsTable.Rows(0).Item("store_phone1")) = "") And (IsDBNull(sExcelData) Or Trim(sExcelData) = "") Then
                            MsgBox("At least one phone number should be provided" & "for Store:" + rsTable.Rows(0).Item("store_number") + vbCrLf + "Excel Row:" + Str(nRow) + " Cell:" + sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                            val_field = False
                            Exit Function
                        End If

                    Case "store_fax1"
                        If Len(Trim(sExcelData)) = 0 Then
                            'No se proporciono fax
                        Else
                            If Len(Trim(sExcelData)) = 10 And IsNumeric(sExcelData) Then
                                sTmp = Trim(sExcelData)
                                sExcelData = "(" & Mid(sTmp, 1, 3) & ")-" & Mid(sTmp, 4, 3) & "-" & Mid(sTmp, 7, 4)
                            Else
                                MsgBox("Incorrect Fax1 Format:" & sExcelData & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                                val_field = False
                                Exit Function
                            End If
                        End If

                    Case "store_fax2"
                        If Len(Trim(sExcelData)) = 0 Then
                            'No se proporciono fax
                        Else
                            If Len(Trim(sExcelData)) = 10 And IsNumeric(sExcelData) Then
                                sTmp = Trim(sExcelData)
                                sExcelData = "(" & Mid(sTmp, 1, 3) & ")-" & Mid(sTmp, 4, 3) & "-" & Mid(sTmp, 7, 4)
                            Else
                                MsgBox("Incorrect Fax2 Format:" & sExcelData & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                                val_field = False
                                Exit Function
                            End If
                        End If

                    Case "store_address"
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(sExcelData) Or Trim(sExcelData) = "" Or Len(sExcelData) = 0 Then
                            MsgBox("Found a Null Store Address." & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                            val_field = False
                            Exit Function
                        Else
                            sExcelData = Trim(sExcelData)
                        End If

                    Case "store_city"
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(sExcelData) Or Trim(sExcelData) = "" Or Len(sExcelData) = 0 Then
                            MsgBox("Found a Null Store City." & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                            val_field = False
                            Exit Function
                        Else
                            sExcelData = Trim(sExcelData)
                        End If

                    Case "state_id"
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(sExcelData) Or Trim(sExcelData) = "" Or Len(sExcelData) = 0 Then
                            MsgBox("Found a Null State." & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                            val_field = False
                            Exit Function
                        Else
                            sExcelData = UCase(Trim(sExcelData))
                        End If

                        sStmt = "SELECT state_id FROM state " & "WHERE state_id='" & sExcelData & "'"
                        
                        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                        If rsLocal.Rows.Count > 0 Then
                            'ok
                        Else
                            'notfound
                            MsgBox("State:" & sExcelData & " was not found on State table" & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                            val_field = False
                            Exit Function
                        End If


                    Case "store_zip"
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(sExcelData) Or Trim(sExcelData) = "" Or Len(sExcelData) = 0 Then
                            MsgBox("Zip:" & sExcelData & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                            val_field = False
                            Exit Function
                        Else
                            sExcelData = Trim(sExcelData)
                        End If

                        If Len(sExcelData) < 5 Then
                            MsgBox("Zip code:" & sExcelData & " should be at least of 5 digits." & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                            val_field = False
                            Exit Function
                        Else
                            If check_zip(sExcelData) Then
                                'ok
                            Else
                                MsgBox("Incorrect Zip code format:" & sExcelData & vbCrLf & "Just numbers and '-' are allowed." & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                                val_field = False
                                Exit Function
                            End If
                        End If

                    Case "store_contact"
                        val_field = True
                        Exit Function

                    Case "store_status"
                        If (UCase(Trim(sExcelData)) = "A") Or (UCase(Trim(sExcelData)) = "I") Then
                            'ok
                            sExcelData = UCase(Trim(sExcelData))
                        Else
                            MsgBox("Incorrect value assigned to Store Status:" & sExcelData & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                            val_field = False
                            Exit Function
                        End If

                    Case "store_folder"
                        val_field = True
                        Exit Function

                    Case "store_co_code"
                        val_field = True
                        Exit Function



                End Select
				
				val_field = True
				Exit Function
				
				
			Case "storeeqpt"
				Select Case sTableField
					Case "cust_id"
						If UCase(Trim(sExcelData)) = cbCustId.Text Then
							'ok
							sExcelData = UCase(Trim(sExcelData))
						Else
							MsgBox("Found record related to " & "a different Customer." & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
							val_field = False
							Exit Function
						End If
						
					Case "store_id"
						sExcelData = "-1"
						val_field = True
						Exit Function
						
						If IsNumeric(sExcelData) Then
							sStmt = "SELECT store_id FROM store " & " WHERE cust_id ='" & cbCustId.Text & "' " & " AND store_id =" & Str(CDbl(sExcelData))
							
                            rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                            If rsLocal.Rows.Count > 0 Then
                                'Store existe
                            Else
                                MsgBox("Store does not exist." & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                                val_field = False
                                Exit Function
                            End If

                        Else
                        MsgBox("Store id should be numeric." & "Aborting." & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                        val_field = False
                        Exit Function
                        End If
						
					Case "eqpt_seq"
						sExcelData = "-1"
						val_field = True
						Exit Function
						
						'Verificar llave primaria
						If IsNumeric(sExcelData) Then
                            sStmt = "SELECT eqpt_seq FROM storeEqpt " & " WHERE cust_id = '" & cbCustId.Text & "' " & " AND store_id = " & Str(rsTable.Rows(0).Item("store_id")) & " AND eqpt_seq = " & Str(CDbl(sExcelData))

                            rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                            If rsLocal.Rows.Count > 0 Then
                                MsgBox("Primary Key violation." & "Cust:" & cbCustId.Text & " StoreId:" & Str(rsTable.Rows(0).Item("store_id")) & " EqptSeq:" & sExcelData)
                                val_field = False
                                Exit Function
                            End If
						End If
						
					Case "eqpt_id"
						
						If IsNumeric(sExcelData) Then
							sStmt = "SELECT eqpt_id FROM equipment " & " WHERE eqpt_id = " & Str(CDbl(sExcelData))
							
                            rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                            If rsLocal.Rows.Count > 0 Then
                                'Equipo existe
                            Else
                                MsgBox("Equipment id does not exist in equipment table." & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                                val_field = False
                                Exit Function
                            End If

						Else
                        MsgBox("Column Eqpt id should be numeric." & "Aborting." & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                        val_field = False
                        Exit Function
						End If
						
					Case "load_id"
						sStmt = "SELECT load_id FROM LoadType " & " WHERE load_id ='" & Trim(sExcelData) & "' "
						
                        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                        If rsLocal.Rows.Count > 0 Then
                            'Tipo de carga existe
                            sExcelData = rsLocal.Rows(0).Item("load_id")
                        Else
                            MsgBox("Load id does not exist in LoadType table." & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                            val_field = False
                            Exit Function
                        End If


                    Case "eqpt_status"
                        If (UCase(Trim(sExcelData)) = "A") Or (UCase(Trim(sExcelData)) = "I") Then
                            'ok
                            sExcelData = UCase(Trim(sExcelData))
                        Else
                            MsgBox("Incorrect value assigned to Eqpt Status" & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                            val_field = False
                            Exit Function
                        End If

                    Case "eqpt_desc"
                        'Este campo no necesita validacion, se toma de Equipment
                        sStmt = "SELECT eqpt_desc FROM equipment " & " WHERE eqpt_id =" & Str(rsTable.Rows(0).Item("eqpt_id"))
                        
                        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                        If rsLocal.Rows.Count > 0 Then
                            sExcelData = rsLocal.Rows(0).Item("eqpt_desc")
                        Else
                            MsgBox("Load id does not exist in LoadType table." & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                            val_field = False
                            Exit Function
                        End If



                    Case "content_id"
                        If IsNumeric(sExcelData) Then
                            sStmt = "SELECT content_id FROM Content " & " WHERE content_id = " & Str(CDbl(sExcelData))
                            
                            rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                            If rsLocal.Rows.Count > 0 Then
                                'Tipo de Contenido existe
                            Else
                                MsgBox("Content id does not exist in Content table." & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                                val_field = False
                                Exit Function
                            End If

                        Else
                        MsgBox("Content id should be numeric." & "Aborting." & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                        val_field = False
                        Exit Function
                        End If

                    Case "eqpt_qty"
                        If IsNumeric(sExcelData) Then
                            'ok
                        Else
                            MsgBox("Eqpt Qty should be numeric." & "Aborting." & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                            val_field = False
                            Exit Function
                        End If

                    Case "eqpt_temp"
                        sStmt = "SELECT eqpt_temp FROM EqptTemp " & " WHERE eqpt_temp ='" & Trim(sExcelData) & "' "
                        
                        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                        If rsLocal.Rows.Count > 0 Then
                            'Codigo de Equipo temporal existe
                            sExcelData = rsLocal.Rows(0).Item("eqpt_temp")
                        Else
                            MsgBox("Incorrect Eqpt Temp Flag." & vbCrLf & "Excel Row:" & Str(nRow) & " Cell:" & sCell, MsgBoxStyle.Exclamation, "GLM Warning")
                            val_field = False
                            Exit Function
                        End If


                    Case "store_number"
                        sStmt = "SELECT store_id FROM store " & " WHERE cust_id='" & cbCustId.Text & "'" & " AND store_number ='" & Trim(sExcelData) & "'"
                        
                        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                        If rsLocal.Rows.Count > 0 Then
                            rsTable.Rows(0).Item("store_id") = rsLocal.Rows(0).Item("store_id")
                        Else
                            MsgBox("Store " & sExcelData & " does not exists.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                            val_field = False
                            Exit Function
                        End If



                    Case "eqpt_size_capacity"
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(sExcelData) Then
                            MsgBox("Cell:" & sCell & " - Size capacity is blank or null")
                            val_field = False
                            Exit Function
                        ElseIf Not IsNumeric(sExcelData) Then
                            MsgBox("Cell:" & sCell & " - Size capacity is not a number:")
                            val_field = False
                            Exit Function
                        Else
                            If CDbl(sExcelData) <= 0 Then
                                MsgBox("Cell:" & sCell & " - Size capacity must be greater than zero")
                                val_field = False
                                Exit Function
                            End If
                        End If

                End Select
				
				val_field = True
				Exit Function
				
			Case Else
				MsgBox("Table not found ")
				val_field = False
				Exit Function
		End Select
		
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "val_field")
		MsgBox("Failed to validate data. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
	End Function
	Private Function check_zip(ByRef sZip As String) As Boolean
		Dim sTmp As String
		Dim i As Short
		
		On Error GoTo ErrorHandler
		
		check_zip = False
		
		If Len(sZip) <= 0 Then
			Exit Function
		End If
		
		For i = 1 To Len(sZip)
			sTmp = Mid(sZip, i, 1)
			If sTmp = "-" Or (IsNumeric(sTmp)) Then
				'ok
				
			Else
				Exit Function
			End If
		Next i
		check_zip = True
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "check_zip")
		MsgBox("Unexpected error while verifying Zip Code:" & sExcelData, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
	End Function
	Private Sub cmdOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOpen.Click
		Dim sDir As String
		Dim fs As Scripting.FileSystemObject
		
		
		On Error GoTo ErrorHandler
		
		fs = New Scripting.FileSystemObject
		
		sDir = My.Application.Info.DirectoryPath
		If Not fs.FolderExists(sDir) Then
			sDir = "c:\"
		End If
		
		
		cdFileOpen.InitialDirectory = sDir 'Directorio para guardar archivo IIF
		cdFileOpen.DefaultExt = ".xls"
		'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		cdFileOpen.Filter = "Excel Files (*.xls)|*.xls"
		cdFileOpen.FilterIndex = 1
		'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
        'cdFile.CancelError = True 'Genera un error 32755 si el usuario escoge Cancel al guardar Save
		cdFileOpen.ShowDialog()
		
		
		
		If Trim(cdFileOpen.FileName) = "" Then
			sFilename = ""
			MsgBox("Unable to Load Info, Please provide a Data FIle.", MsgBoxStyle.OKOnly, "GLM Warning")
		Else
			If fs.FileExists(cdFileOpen.FileName) Then
				sFilename = cdFileOpen.FileName
				txtExcelFile.Text = cdFileOpen.FileName
			Else
				sFilename = ""
				MsgBox("Such  files does not exist.")
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
	
	Private Sub frmLoadExcel_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		
        rsLocal = Nothing
        rsTable = Nothing
		
		If gbDebug Then
			Me.Width = VB6.TwipsToPixelsX(8550)
			Me.Height = VB6.TwipsToPixelsY(7545)
		End If
		
		prbLoad.Visible = False
		
		sStmt = "SELECT cust_id, cust_name FROM customer " & " ORDER BY cust_name "
		load_cb_query2(cbCustId, sStmt, 1, True)
		
		sStmt = "SELECT cust_name, cust_id FROM customer " & " ORDER BY cust_name "
		load_cb_query2(cbCustName, sStmt, 1, True)
		
		If cbCustName.Items.Count > 0 Then
			cbCustName.SelectedIndex = 0
		End If
		
		
	End Sub
	'Guarda tabla en base de datos
	Private Function save_table(ByRef sTableName As String) As Short
		Dim nResult As Short
        Dim nTran As SqlTransaction
		Dim nRecords As Short
		Dim nGroupSeq As Short
		Dim bFirstTime As Boolean
		
		On Error GoTo ErrorHandler

		nRecords = 0
		
		Select Case sTableName
			Case "store"
				'Recorrer todo el recordset

                nTran = cn.BeginTransaction()
                For row As Integer = 0 To rsTable.Rows.Count - 1
                    If Not IsDBNull(rsTable.Rows(row).Item("store_number")) Then
                        'Check dups Store_number
                        sStmt = "SELECT store_id FROM store " & " WHERE cust_id = '" & cbCustId.Text & "'" & _
                                " AND store_number ='" & Trim(rsTable.Rows(row).Item("store_number")) & "'"

                        rsLocal = getDataTable(sStmt, nTran) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                        If rsLocal.Rows.Count > 0 Then
                            MsgBox("Duplicate store:" + rsTable.Rows(row).Item("store_number"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                            nTran.Rollback()

                            save_table = 0
                            Exit Function
                        End If


                        'Obtener siguiente store_id
                        sStmt = "SELECT MAX(store_id) FROM Store " & " WHERE cust_id='" & cbCustId.Text & "' "

                        rsLocal = getDataTable(sStmt, nTran) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                        If rsLocal.Rows.Count > 0 Then
                            If IsDBNull(rsLocal.Rows(0).Item(0)) Then
                                rsTable.Rows(row).Item("store_id") = 1
                            Else
                                rsTable.Rows(row).Item("store_id") = rsLocal.Rows(0).Item(0) + 1
                            End If
                        End If


                        'insertar en store
                        sStmt = "INSERT INTO Store (cust_id, store_id, store_number," & _
                            "store_name, store_phone1, store_phone2, store_fax1, " & _
                            "store_fax2, store_address, store_city, state_id," & _
                            "store_zip, store_contact, store_status, store_folder, " & _
                            "store_co_code) VALUES ('" & _cbCustId.Text & "'," & _
                                Str(rsTable.Rows(row).Item("store_id")) & "," & _
                                "'" & UCase(Trim(rsTable.Rows(row).Item("store_number"))) & "'," & _
                                "'" & Trim(rsTable.Rows(row).Item("store_name")) & "'," & _
                                "'" & Trim(rsTable.Rows(row).Item("store_phone1")) & "'," & _
                                "'" & Trim(rsTable.Rows(row).Item("store_phone2")) & "'," & _
                                "'" & Trim(rsTable.Rows(row).Item("store_fax1")) & "'," & _
                                "'" & Trim(rsTable.Rows(row).Item("store_fax2")) & "'," & _
                                "'" & Trim(rsTable.Rows(row).Item("store_address")) & "'," & _
                                "'" & Trim(rsTable.Rows(row).Item("store_city")) & "'," & _
                                "'" & Trim(rsTable.Rows(row).Item("state_id")) & "'," & _
                                "'" & Trim(rsTable.Rows(row).Item("store_zip")) & "'," & _
                                "'" & Trim(rsTable.Rows(row).Item("store_contact")) & "'," & _
                                "'" & Trim(rsTable.Rows(row).Item("store_status")) & "'," & _
                                "'" & Trim(rsTable.Rows(row).Item("store_folder")) & "'," & _
                                "'" & Trim(rsTable.Rows(row).Item("store_co_code")) & "')"

                        'MsgBox sStmt
                        cm.CommandType = CommandType.Text
                        cm.CommandText = sStmt
                        cm.Transaction = nTran
                        nResult = cm.ExecuteNonQuery()
                        If nResult = 1 Then
                            'ok
                            'Insertar tienda a grupo All
                            If bFirstTime = False Then
                                sStmt = "SELECT group_seq FROM groups " & " WHERE cust_id = '" & Trim(cbCustId.Text) & "'" & " AND group_name = 'All' "

                                rsLocal = getDataTable(sStmt, nTran) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                                If rsLocal.Rows.Count > 0 Then
                                    'ok
                                    nGroupSeq = rsLocal.Rows(0).Item("group_seq")
                                Else
                                    If MsgBox("Group Store ALL was not found. " & vbCrLf & "Do you want to continue?", MsgBoxStyle.YesNo, "GLM Warning") = MsgBoxResult.No Then
                                        nTran.Rollback()
                                        save_table = 0
                                        Exit Function

                                    End If
                                    nGroupSeq = -1
                                End If

                            End If 'bFirstTime

                            If nGroupSeq > 0 Then
                                sStmt = "INSERT INTO GroupStore (group_seq, cust_id, " & " store_id) VALUES (" & Str(nGroupSeq) & "," & "'" & cbCustId.Text & "'," & Str(rsTable.Rows(row).Item("store_id")) & ")"

                                'MsgBox sStmt
                                cm.CommandType = CommandType.Text
                                cm.CommandText = sStmt
                                cm.Transaction = nTran
                                nResult = cm.ExecuteNonQuery()
                                If nResult = 1 Then
                                    'ok
                                Else
                                    If MsgBox("Failed to add Store " + rsTable.Rows(row).Item("store_number") + " to Group ALL." + vbCrLf + "If you continue will have to add it using " + "Store Group program." + vbCrLf + "Do you want to continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "GLM Warning") = MsgBoxResult.No Then
                                        nTran.Rollback()
                                        save_table = 0
                                        Exit Function
                                    End If
                                End If
                            End If


                            nRecords = nRecords + 1
                        Else
                            nTran.Rollback()
                            save_table = 0
                            Exit Function
                        End If
                    End If ' END IF del if dbnull()
                Next row
                
                nTran.Commit()

            Case "storeeqpt"
                'Recorrer todo el recordset

                nTran = cn.BeginTransaction()
                For row As Integer = 0 To rsTable.Rows.Count - 1
                    If Not IsDBNull(rsTable.Rows(row).Item("store_id")) Then
                        sStmt = "SELECT MAX(eqpt_seq) FROM storeEqpt " & " WHERE cust_id='" & cbCustId.Text & "' " & " AND store_id =" & Str(rsTable.Rows(row).Item("store_id"))

                        rsLocal = getDataTable(sStmt, nTran) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        If rsLocal.Rows.Count > 0 Then
                            If IsDBNull(rsLocal.Rows(0).Item(0)) Then
                                rsTable.Rows(0).Item("eqpt_seq") = 1
                            Else
                                rsTable.Rows(0).Item("eqpt_seq") = rsLocal.Rows(0).Item(0) + 1
                            End If
                        End If


                        'sStmt = "INSERT INTO storeEqpt (cust_id, store_id, eqpt_seq, " + _
                        ''    "eqpt_id, load_id, eqpt_status, eqpt_desc, content_id, " + _
                        ''    "eqpt_qty, eqpt_temp)  VALUES " + _
                        ''    "('" + cbCustId + "'," + _
                        ''    Str(rsTable.item("store_id")) + "," + _
                        ''    Str(rsTable.item("eqpt_seq")) + "," + _
                        ''    Str(rsTable.item("eqpt_id")) + "," + _
                        ''    "'" + rsTable.item("load_id") + "'," + _
                        ''    "'" + rsTable.item("eqpt_status") + "','" + _
                        ''    Trim(rsTable.item("eqpt_desc")) + "'," + _
                        ''    Str(rsTable.item("content_id")) + "," + _
                        ''    Str(rsTable.item("eqpt_qty")) + "," + _
                        ''    "'" + rsTable.item("eqpt_temp") + "')"

                        sStmt = "INSERT INTO storeEqpt (cust_id, store_id, eqpt_seq, " & "eqpt_id, load_id, eqpt_status, eqpt_desc, content_id, " & "eqpt_qty, eqpt_temp, eqpt_size_capacity)  VALUES " & _
                            "('" & cbCustId.Text & "'," & Str(rsTable.Rows(row).Item("store_id")) & "," & Str(rsTable.Rows(row).Item("eqpt_seq")) & "," & _
                             Str(rsTable.Rows(row).Item("eqpt_id")) & "," & "'" + rsTable.Rows(row).Item("load_id") + "'," + "'" + rsTable.Rows(row).Item("eqpt_status") + "','" + Trim(rsTable.Rows(row).Item("eqpt_desc")) + _
                             "'," + Str(rsTable.Rows(row).Item("content_id")) + "," + Str(rsTable.Rows(row).Item("eqpt_qty")) + "," + "'" + rsTable.Rows(row).Item("eqpt_temp") + "'," + Str(rsTable.Rows(0).Item("eqpt_size_capacity")) + ")"


                        'MsgBox sStmt
                        cm.CommandText = sStmt
                        cm.CommandType = CommandType.Text
                        cm.Transaction = nTran
                        nResult = cm.ExecuteNonQuery()

                        If nResult = 1 Then
                            'ok
                            nRecords = nRecords + 1
                        Else
                            nTran.Rollback()
                            save_table = 0
                            Exit Function
                        End If
                    End If
                Next row


                nTran.Commit()

        End Select
		save_table = nRecords
		
		Exit Function
		
ErrorHandler: 
		save_table = 0

        nTran.Rollback()

        save_error(Me.Name, "save_table:" & sStmt)
        MsgBox("Failed to save data. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
	End Function
End Class