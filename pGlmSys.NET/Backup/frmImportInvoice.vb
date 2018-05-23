Option Strict Off
Option Explicit On
Friend Class frmImportInvoice
	Inherits System.Windows.Forms.Form
	
	Private XLApp As Microsoft.Office.Interop.Excel.Application
	Private XL_wbook As Microsoft.Office.Interop.Excel.Workbook
	Private XL_header_wsheet As Microsoft.Office.Interop.Excel.Worksheet
	Private XL_detail_wsheet As Microsoft.Office.Interop.Excel.Worksheet
	Private sFilename As String
	
	Private Sub cmdImport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImport.Click
		
		On Error GoTo ErrorHandler
		
        If Len(sFilename) > 0 Then

            'funcion no desarrollado todavia (Javier)
            MsgBox("Import Invoices not implemented yet")
            Exit Sub

            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            sbLoad.Items(0).Text = "Opening Excel File...."
            'UPGRADE_WARNING: Couldn't resolve default property of object openExcelFile(sFilename, XLApp, XL_wbook). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If openExcelFile(sFilename, XLApp, XL_wbook) = True Then
                sbLoad.Items(0).Text = "Searching Excel Sheet..."
                '1.Read spreadsheets
                XL_header_wsheet = getExcelWorksheet("header", XL_wbook)

                If XL_header_wsheet Is Nothing Then
                    closeExcelFile(XLApp, XL_wbook)
                Else
                    sbLoad.Items(0).Text = "Found Header Worksheet"
                End If

                XL_detail_wsheet = getExcelWorksheet("detail", XL_wbook)

                If XL_detail_wsheet Is Nothing Then
                    closeExcelFile(XLApp, XL_wbook)
                Else
                    sbLoad.Items(0).Text = "Found Detail Worksheet"
                End If

                '2.Validate Invoice Header records
                validate_header()
                '3.Validate Invoice Detail records

            End If
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Else
            MsgBox("Please select an Excel file before attempting this command", MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Sub
        End If
		
		
		
		
		'Verificar Columnas
        sbLoad.Items(0).Text = "Checking column headers..."
		'nNumCols = check_header(sSheetName)
		'If nNumCols <= 0 Then
		'    close_excel_file
		'    Exit Function
		'End If
		
		'nRows = count_sheet_rows
		
		'Cargar Datos
        'sbLoad.Items(0).SimpleText = "Verifying data...."
		'load_sheet sSheetName, nNumCols, nRows
		
		
		'close_excel_file
        sbLoad.Items(0).Text = "Done"
		
		
		Exit Sub
		
ErrorHandler: 
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		
		
	End Sub
	Private Sub validate_header()
		
		Dim colName As String
		Dim i As Short
		Dim numCols As Short
		
		'Validate column names in row 1
		For i = 1 To XL_header_wsheet.Columns.Count
			numCols = numCols + 1
			'UPGRADE_WARNING: Couldn't resolve default property of object XL_header_wsheet.Cells(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			colName = XL_header_wsheet.Cells._Default(1, i)
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDbNull(colName) Or Len(colName) = 0 Then
				Exit For
			End If
		Next i
		
		Debug.Print(numCols)
		
		
		
		'Validate data in rows 2 an on
		
	End Sub
	Private Sub cmdOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOpen.Click
		Dim sDir As String
		Dim fs As Scripting.FileSystemObject
		
		On Error GoTo ErrorHandler
		
		fs = New Scripting.FileSystemObject
		
        sDir = OSdriveLetter + "glm"
		If Not fs.FolderExists(sDir) Then
			sDir = "c:\"
		End If
		
		
		cdFileOpen.InitialDirectory = sDir 'Directorio para guardar archivo IIF
		cdFileOpen.DefaultExt = ".xls"
		'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        cdFileOpen.Filter = "Excel Files (*.xls;*xlsx)|*.xls;*.xlsx"
		cdFileOpen.FilterIndex = 1
		'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
        'cdFile.CancelError = True 'Genera un error 32755 si el usuario escoge Cancel al guardar Save
        If cdFileOpen.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else

            If Trim(cdFileOpen.FileName) = "" Then
                sFilename = ""
                MsgBox("Unable to Load Info, Please provide an Excel File.", MsgBoxStyle.OkOnly, "GLM Warning")
            Else
                If fs.FileExists(cdFileOpen.FileName) Then
                    sFilename = cdFileOpen.FileName
                    txtFile.Text = cdFileOpen.FileName
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
            MsgBox("Operation was cancelled by user.", MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Sub
        Else
            save_error(Me.Name, "cmdOk")
            MsgBox("An error occurred while opening file. Try again.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")

        End If

    End Sub

    Private Sub frmImportInvoice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtFile.Text = ""
    End Sub
End Class