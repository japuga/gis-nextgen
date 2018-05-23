Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
'Imports Microsoft.Office.Interop.Excel




Module Functions
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    Private Declare Function GetIpAddrTable_API Lib "IpHlpApi" Alias "GetIpAddrTable" (ByRef pIPAddrTable As Object, ByRef pdwSize As Integer, ByVal bOrder As Integer) As Integer
	
	Public basic(19) As String
	'UPGRADE_WARNING: Lower bound of array dozen was changed from 2 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Public dozen(9) As String
	'UPGRADE_WARNING: Lower bound of array measure was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Public measure(3) As String
	'UPGRADE_WARNING: Lower bound of array gParse was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Public gParse(10) As String
	Public Function num2str(ByRef nInt As Double) As String
		Dim sInt As String
		Dim sFloat As String
		Dim sNum As String
		Dim sTrans As String
		Dim nPos As Short
		
		sNum = CStr(nInt)
		
		nPos = InStr(sNum, ".")
		
		If nPos > 0 Then
			sFloat = Right(sNum, Len(sNum) - nPos)
			If Len(sFloat) = 1 Then
				sFloat = sFloat & "0"
			End If
			sInt = Left(sNum, nPos - 1)
		Else
			sFloat = "00"
			sInt = sNum
		End If
		init_arrays() 'Arreglos de la funcion para convertir numeros a letras
		
		sTrans = int2str(CDbl(sInt)) & " and " & Trim(sFloat) & "/100"
		num2str = sTrans
	End Function
	
	'Convierte un numero en un cadena de caracteres
	
	Public Function int2str(ByRef n As Double) As String
		
		
		Dim sNumber As String
		Dim nLen As Short
		Dim nGroups As Short
		Dim nMod As Short
		Dim i As Short
		Dim sTemp As String
		Dim nTemp As Short
		Dim sTranslated As String
		
		
		sTranslated = ""
		sNumber = CStr(n)
		
		nLen = Len(sNumber)
		nMod = nLen Mod 3
		'Numero de grupos a procesar
		nGroups = Int(nLen / 3)
		If nGroups = 0 Then
			nGroups = 1
		Else
			If nMod > 0 Then
				nGroups = nGroups + 1
			End If
		End If
		For i = nGroups To 1 Step -1
			
			If i = nGroups Then
				If nMod > 0 Then
					sTemp = Mid(sNumber, 1, nMod)
				Else
					sTemp = Mid(sNumber, 1, 3)
					nMod = nMod + 3
				End If
			Else
				sTemp = Mid(sNumber, nMod + 1, 3)
				nMod = nMod + 3
			End If
			
			nTemp = Int(CDbl(sTemp))
			
			
			Select Case Len(CStr(nTemp))
				Case 1
					sTranslated = sTranslated & " " & basic(CShort(sTemp))
					
				Case 2
					If CShort(sTemp) < 20 Then
						sTranslated = sTranslated & " " & basic(CShort(sTemp))
					Else
						sTranslated = sTranslated & " " & dozen(Int(nTemp / 10)) & " " & basic(Int(nTemp Mod 10))
					End If
					
				Case 3
					sTranslated = sTranslated & " " & basic(Int(nTemp / 100)) & " " & measure(1) & " " & int2str(Int(nTemp Mod 100))
					
					
			End Select
			If i > 1 Then
				sTranslated = sTranslated & " " & measure(i)
			End If
		Next i
		
		int2str = sTranslated
	End Function
	
	
	Public Sub init_arrays()
		basic(0) = ""
		basic(1) = "One"
		basic(2) = "Two"
		basic(3) = "Three"
		basic(4) = "Four"
		basic(5) = "Five"
		basic(6) = "Six"
		basic(7) = "Seven"
		basic(8) = "Eigth"
		basic(9) = "Nine"
		basic(10) = "Ten"
		basic(11) = "Eleven"
		basic(12) = "Twelve"
		basic(13) = "Thirteen"
		basic(14) = "Fourteen"
		basic(15) = "Fifteen"
		basic(16) = "Sixteen"
		basic(17) = "Seventeen"
		basic(18) = "Eighteen"
		basic(19) = "Nineteen"
		
		dozen(2) = "Twenty"
		dozen(3) = "Thirty"
		dozen(4) = "Forty"
		dozen(5) = "Fifty"
		dozen(6) = "Sixty"
		dozen(7) = "Seventy"
		dozen(8) = "Eigthy"
		dozen(9) = "Ninety"
		
		
		measure(1) = "Hundred"
		measure(2) = "Thousand"
		measure(3) = "Million"
	End Sub
	'Cuenta el numero de decimales en un string
	'Se asume que el string es un numerico
	Public Function max_fraction(ByRef sNumero As String) As Boolean
		Dim nDot As Short
		nDot = 0
		nDot = InStr(1, sNumero, ".", CompareMethod.Text)
		If nDot > 0 And Len(sNumero) >= nDot + 2 Then
			max_fraction = True
		Else
			max_fraction = False
		End If
		
	End Function
	Public Function max_fraction2(ByRef sNumero As String, ByRef nMaxDecimals As Short) As Boolean
		Dim nDot As Short
		nDot = 0
		nDot = InStr(1, sNumero, ".", CompareMethod.Text)
		If nDot > 0 And Len(sNumero) >= nDot + nMaxDecimals Then
			max_fraction2 = True
		Else
			max_fraction2 = False
		End If
		
	End Function
	
    Public Function format_qty(ByRef sSource As String, Optional ByRef nMaxLen As Short = 0) As String
        format_qty = ""
        Dim n As Short
        Dim i As Short
        Dim sStr As String = ""
        Dim nSpaces As Short

        'Form1.CurrentX = 100
        'Form1.CurrentY = 100
        'Form1.FontName = "Times New Roman"
        'Form1.FontSize = 12
        'Form1.Print Tab(5); "hola"
        'Form1.FontName = "Courier"
        'Form1.FontSize = 9
        'Form1.Print Tab(5); format_qty("13.56");
        'Form1.Print Tab(5); format_qty("3.40")
        'Form1.Print Tab(5); format_qty("0.00")
        'Form1.Print Tab(5); format_qty("134.21")

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(nMaxLen) Or nMaxLen = 0 Then
            nMaxLen = 12
        End If

        n = Len(sSource)

        If n < nMaxLen Then
            nSpaces = nMaxLen - n
            For i = 1 To nSpaces
                sStr = " " & sStr
            Next i
            format_qty = sStr & sSource
        End If


    End Function
	'Divide una cadena de caracteres en varias de lineas
	'de longitud maxima nMaxLine. Cada linea es un registro en
	'el arreglo gParse. Funcion retorna el numero de lineas
	Public Function parse_string(ByRef sSource As String, ByRef nMaxLine As Short) As Short
		Dim i As Short
		Dim nIdx As Short
		Dim nIdx2 As Short
		Dim nCounter As Short
		Dim nStart As Short
		Dim sTmp As String
		
		nCounter = 0
		'Limpiar variable global
        For i = 0 To 9
            gParse(i) = ""
        Next i
		
		sTmp = Trim(sSource)
		'No requiere parcelamiento
		If Len(sTmp) <= nMaxLine Or InStr(1, sTmp, " ", CompareMethod.Text) = 0 Then
			parse_string = 0
			Exit Function
		End If
		
		
        nStart = 0
		'Do While Len(sTmp) > nMaxLine
		Do While True

			nIdx = InStr(1, sTmp, " ", CompareMethod.Text)
			If nIdx = 0 Or Len(sTmp) <= nMaxLine Then
				gParse(nCounter) = sTmp
				Exit Do
			End If
			
			If nIdx > 0 Then
				'Buscar siguiente espacio
				nIdx2 = InStr(nIdx + 1, sTmp, " ", CompareMethod.Text)
				
				
				If nIdx2 > 0 And nIdx2 <= nMaxLine Then
					gParse(nCounter) = Left(sTmp, nIdx2)
					sTmp = Right(sTmp, Len(sTmp) - nIdx2)
				Else
					gParse(nCounter) = Left(sTmp, nIdx)
					sTmp = Right(sTmp, Len(sTmp) - nIdx)
				End If
				
				'gParse(nCounter) = Left(sTmp, nIdx)
				'sTmp = Right(sTmp, Len(sTmp) - nIdx)
				'Else
				'   gParse(nCounter) = sTmp
				'  Exit Do
            End If
            nCounter = nCounter + 1
		Loop 
		parse_string = nCounter
		
	End Function
	
	'Busca por un elemento en recordset
	'el elemento es de la forma
	'sItem="state='TX'"
	
    Public Function record_exist(ByRef rsTmp As sqldatareader, ByRef sItem As String) As Boolean

        'Dim sCriteria As String
        'sCriteria = "state='" + Trim(sStateId) + "'"
        If Not rsTmp.HasRows Then
            record_exist = False
            Exit Function
        End If

        'rsTmp.Find(sItem, , ADODB.SearchDirectionEnum.adSearchForward, 0)

        If Not rsTmp.HasRows Then
            record_exist = False
            Exit Function
        End If
        record_exist = True

    End Function
    Public Function record_exist(ByRef rsTmp As DataTable, ByRef sItem As String) As Boolean

        'Dim sCriteria As String
        'sCriteria = "state='" + Trim(sStateId) + "'"
        If rsTmp.Rows.Count < 1 Then
            record_exist = False
            Exit Function
        End If
        Try
            'rsTmp.Find(sItem, , ADODB.SearchDirectionEnum.adSearchForward, 0)
            'Dim colName As String = rsTmp.Columns(0).ColumnName
            'Dim drFoundRow As DataRow = rsTmp.Rows.Find(sItem)

            'Dim dr As DataRow = rsTmp.Rows(0)
            'Dim rowVal As String = dr.Item(0).ToString
            'Dim strSearch As String = "eqpt_id=" & rowVal
            'Dim rowsArr() As DataRow = rsTmp.Select(strSearch)


            Dim foundRows() As DataRow
            foundRows = rsTmp.Select(sItem)

            If foundRows.Length < 1 Then
                record_exist = False
                Exit Function
            End If
            record_exist = True
        Catch ex As Exception
            Dim errMsg As String = ex.Message
        End Try
    End Function
	
	Public Function build_datetime(ByRef dtDate As Date, ByRef bExtendDay As Boolean) As String
		Dim sMonth As String
		Dim sDay As String
		
        sStmt = Trim(Str(Year(dtDate))) & "-"
        sMonth = Trim(Str(Month(dtDate)))
		If Len(Trim(sMonth)) = 1 Then
			sMonth = "0" & Trim(sMonth)
		End If
		
        sDay = Trim(Str(VB.Day(dtDate)))
		If Len(Trim(sDay)) = 1 Then
			sDay = "0" & Trim(sDay)
		End If
		
		
		sStmt = sStmt & sMonth & "-" & sDay
		
		If bExtendDay Then
			sStmt = sStmt & " 23:59:59"
		Else
			sStmt = sStmt & " 00:00:00"
		End If
		build_datetime = sStmt
		
	End Function
	
	
	
	Public Function GetIpAddrTable() As Object
		Dim Buf(511) As Byte
		Dim BufSize As Integer : BufSize = UBound(Buf) + 1
		Dim rc As Integer
		rc = GetIpAddrTable_API(Buf(0), BufSize, 1)
		
		
		
		If rc <> 0 Then Err.Raise(vbObjectError,  , "GetIpAddrTable failed with return value " & rc)
		Dim NrOfEntries As Short : NrOfEntries = Buf(1) * 256 + Buf(0)
		
		
		If NrOfEntries = 0 Then
			'UPGRADE_WARNING: Array has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			GetIpAddrTable = New Object(){} : Exit Function
		End If
		Dim IpAddrs(NrOfEntries - 1) As String
		Dim i As Short
		Dim j As Short
		Dim s As String
		For i = 0 To NrOfEntries - 1 : s = ""
			For j = 0 To 3 : s = s & IIf(j > 0, ".", "") & Buf(4 + i * 24 + j) : Next 
			IpAddrs(i) = s
		Next 
		'UPGRADE_WARNING: Couldn't resolve default property of object GetIpAddrTable. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		GetIpAddrTable = VB6.CopyArray(IpAddrs)
	End Function
	Public Function getIpAddr() As String
        Dim IpAddrs As String = ""
        getIpAddr = "111.111.111.111"

        Dim addresses As System.Net.IPAddress() = System.Net.Dns.GetHostEntry(My.Computer.Name).AddressList
        Dim result As String = String.Empty
        For Each address As System.Net.IPAddress In addresses
            Dim thisAddr As String = address.ToString
            If thisAddr.Split(".").Length = 4 Then
                result = thisAddr.ToString
                Exit For
            End If
        Next

		'UPGRADE_WARNING: Couldn't resolve default property of object GetIpAddrTable. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object IpAddrs. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'IpAddrs = GetIpAddrTable
        'Dim i As Short
        'For i = LBound(IpAddrs) To UBound(IpAddrs)

        'UPGRADE_WARNING: Couldn't resolve default property of object IpAddrs(i). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If IpAddrs(i) <> "0.0.0.0" And IpAddrs(i) <> "127.0.0.1" Then
        'UPGRADE_WARNING: Couldn't resolve default property of object IpAddrs(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'getIpAddr = IpAddrs(i)
        'Exit For
        'End If
        'Next 
		
	End Function
	
	Public Function validateAndAuditLogin(ByRef username As String) As Boolean
		
        Dim workstation As String = ""
		Dim spid As String
		Dim ipAddr As String
		Dim loginId As Integer
		Dim nRecords As Short
		
		nRecords = 0
		ipAddr = getIpAddr
		
        'workstation = cn.Properties("Workstation ID").Value
		'UPGRADE_WARNING: Couldn't resolve default property of object gDump. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		gDump = exec_sql_single("SELECT @@spid ")
		spid = gDump.str1
		
		loginId = get_next_seq("slogin_audit", "login_id")
		
		killSessions(username, ipAddr, workstation)
		
		sStmt = "INSERT INTO slogin_audit(login_id, suser_name, ip_address," & "work_station, spid, active) " & " VALUES " & "( " & Str(loginId) & ",'" & username & "', '" & ipAddr & "', " & "'" & workstation & "'," & spid & ",1)"
		
        cm = cn.CreateCommand '.let_ActiveConnection(cn)
        cm.CommandType = CommandType.Text
		cm.CommandText = sStmt
        nRecords = cm.ExecuteNonQuery()
		
		'Save loginId
		If nRecords > 0 Then
			gnLoginId = loginId
		Else
			gnLoginId = 0
		End If
		
		validateAndAuditLogin = True
		
		
	End Function
	'This function kills sessions under username that do not belog to ipaddress/workstation
	Public Function killSessions(ByRef username As String, ByRef ipaddress As String, ByRef workstation As String) As Boolean
		Dim spid As String
        Try
            sStmt = "SELECT spid FROM slogin_audit " & " WHERE suser_name ='" & username & "' " & " AND ip_address != '" & ipaddress & "' " & " AND work_station != '" & workstation & "' "

            rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rs.Rows.Count > 0 Then
                For row As Integer = 0 To rs.Rows.Count - 1
                    spid = rs.Rows(row).Item("spid")
                    sStmt = " KILL " & spid
                    cm.CommandText = sStmt
                    sStmt = cm.ExecuteNonQuery()
                Next row
            End If
        Catch ex As Exception
            Dim errMsg As String = ex.Message
        End Try

	End Function
	
	Public Sub sessionLogout()
		
		If gnLoginId > 0 And Not cn Is Nothing Then
			sStmt = "UPDATE slogin_audit " & " SET logout_time = getdate(), " & "    active = 0 " & " WHERE login_id = " & Str(gnLoginId)
            cm.CommandText = sStmt
            cm.CommandType = CommandType.Text
            cm.ExecuteScalar()
        End If
		
	End Sub
	Public Function fractionLen(ByRef source As Double) As Short
		Dim sourceStr As String
		Dim fractionStr As String
		Dim dot As Short
		
		sourceStr = CStr(source)
		'Get dot position
		dot = InStr(1, sourceStr, ".", CompareMethod.Text)
		
		If dot <= 0 Or dot = Len(sourceStr) Then
			fractionLen = 0
			Exit Function
		Else
			fractionStr = Right(sourceStr, Len(sourceStr) - dot)
			fractionLen = Len(fractionStr)
			Exit Function
		End If
		
		
	End Function
	Public Function roundUpOne(ByRef source As Double) As Double
		
		Dim digit As String
		Dim fractionLenNum As Short
		Dim sourceStr As String
		Dim fractionStr As String
		
		fractionLenNum = fractionLen(source)
		
		If fractionLenNum > 2 Then
			sourceStr = CStr(CDbl(source))
			fractionStr = Right(sourceStr, fractionLenNum)
			digit = CStr(CShort(Right(fractionStr, 1)))
			If CDbl(digit) >= 5 Then
				source = CDbl(Left(CStr(source), Len(sourceStr) - 1)) + increment(Len(fractionStr) - 1)
			Else
				source = CDbl(Left(CStr(source), Len(sourceStr) - 1))
			End If
			
			roundUpOne(source)
		End If
		
		roundUpOne = source
		
	End Function
	
	
	Public Function increment(ByRef precision As Short) As Double
		
		Dim incrementStr As String
		Dim idx As Short
		
		incrementStr = "0."
		
		For idx = 1 To precision - 1
			incrementStr = incrementStr & "0"
		Next 
		
		incrementStr = incrementStr & "1"
		
		increment = CDbl(incrementStr)
	End Function
	'--------------------------------------------------------
	'Description:
	'   This function opens a common dialog box
	'   to let the user select an Excel file to open
	'   and returns the full file path name
	'Parameters:
	'   cdFile: This is the Common Dialog component in the invoking form
	'Returns:
	'   filename: A string name of the full path name
	'--------------------------------------------------------
	'UPGRADE_NOTE: Argument type has been changed to Object. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="D0BD8832-D1AC-487C-8AA5-B36F9284E51E"'
	Public Function getFilenameFromCommonDialog(ByRef cdFile As Object, ByRef sFormName As String) As String
		
		Dim sDir As String
		Dim fs As Scripting.FileSystemObject
		Dim sFilename As String
		
		On Error GoTo ErrorHandler
		
		fs = New Scripting.FileSystemObject
		
		sDir = "c:\glm"
		If Not fs.FolderExists(sDir) Then
			sDir = "c:\"
		End If
		
		
		'UPGRADE_WARNING: Couldn't resolve default property of object cdFile.InitDir. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		cdFile.InitDir = sDir 'Directorio para guardar archivo IIF
		'UPGRADE_WARNING: Couldn't resolve default property of object cdFile.DefaultExt. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		cdFile.DefaultExt = ".xls"
		'UPGRADE_WARNING: Couldn't resolve default property of object cdFile.Filter. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		cdFile.Filter = "Excel Files (*.xls)|*.xls|*.xlsx"
		'UPGRADE_WARNING: Couldn't resolve default property of object cdFile.FilterIndex. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		cdFile.FilterIndex = 1
		'UPGRADE_WARNING: Couldn't resolve default property of object cdFile.CancelError. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		cdFile.CancelError = True 'Genera un error 32755 si el usuario escoge Cancel al guardar Save
		'UPGRADE_WARNING: Couldn't resolve default property of object cdFile.ShowOpen. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		cdFile.ShowOpen()
		
		
		
		'UPGRADE_WARNING: Couldn't resolve default property of object cdFile.FileName. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Trim(cdFile.FileName) = "" Then
			sFilename = ""
			MsgBox("Unable to Load Info, Please provide an Excel File.", MsgBoxStyle.OKOnly, "GLM Warning")
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object cdFile.FileName. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If fs.FileExists(cdFile.FileName) Then
				'UPGRADE_WARNING: Couldn't resolve default property of object cdFile.FileName. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sFilename = cdFile.FileName
				'txtFile = cdFile.FileName
			Else
				sFilename = ""
				MsgBox("Such  files does not exist.")
			End If
		End If
		
		getFilenameFromCommonDialog = sFilename
		
		Exit Function
		
ErrorHandler: 
		
		'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
		If Err.Number = DialogResult.Cancel Then
			'User selected cancel in OpenDialog
			MsgBox("Operation was cancelled by user.", MsgBoxStyle.OKOnly, "GLM Warning")
			Exit Function
		Else
			save_error(sFormName, "getFilenameFromCommonDialog")
			MsgBox("An error occurred while opening file. Try again.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			
		End If
		
		
	End Function
	Public Function openExcelFile(ByRef sFilename As String, ByRef XLApp As Microsoft.Office.Interop.Excel.Application, ByRef XL_wbook As Microsoft.Office.Interop.Excel.Workbook) As Object
		On Error GoTo ErrorHandler
		
        openExcelFile = False
		
        XLApp = CreateObject("Excel.Application") 'GetObject( , "excel.application")
		XL_wbook = XLApp.Workbooks.Open(sFilename)
		XLApp.Visible = False
        openExcelFile = True
		
ErrorEnd: 
		Exit Function
		
ErrorHandler: 
		If Err.Number = XL_NOTRUNNING Then
			'Comentado para eliminar referencia a Excel Lib
			XLApp = New Microsoft.Office.Interop.Excel.Application
			
			Resume Next
		End If
		Resume ErrorEnd
		
	End Function
	
	
	Public Sub closeExcelFile(ByRef XLApp As Microsoft.Office.Interop.Excel.Application, ByRef XL_wbook As Microsoft.Office.Interop.Excel.Workbook)
		
		XL_wbook.Saved = True
		XL_wbook.Close()
		'UPGRADE_NOTE: Object XLApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		XLApp = Nothing
		
	End Sub
    Public Function getPhoneNumberLen(ByRef sPhoneNumber As String) As Integer
        'phone number has ( ) - symbols in them, take them out.
        Dim iLen As Integer
        sPhoneNumber = Replace(sPhoneNumber, "(", "")
        sPhoneNumber = Replace(sPhoneNumber, ")", "")
        sPhoneNumber = Replace(sPhoneNumber, "-", "")
        sPhoneNumber = Replace(sPhoneNumber, " ", "")
        iLen = Len(sPhoneNumber)
        Return iLen
    End Function
	'This function Opens an Excel file and
	'returns the worksheet, also assumes that a status bar
	'named sbLoad exists in the form.
	
	Public Function getExcelWorksheet(ByRef sSheetName As String, ByRef XL_wbook As Microsoft.Office.Interop.Excel.Workbook) As Microsoft.Office.Interop.Excel.Worksheet
		
		Dim sheetTmp As Microsoft.Office.Interop.Excel.Worksheet
		Dim bFound As Boolean
		Dim nRows As Short
		Dim nNumCols As Short
		Dim XL_wsheet As Microsoft.Office.Interop.Excel.Worksheet
		
		
		
		'UPGRADE_NOTE: Object getExcelWorksheet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		getExcelWorksheet = Nothing
		
		On Error GoTo ErrorHandler
		
		
		'Buscar Hoja con Datos
		bFound = False
		For	Each sheetTmp In XL_wbook.Worksheets
			'Set XL_wsheet = XL_wbook.Sheets("tiendas")
			If LCase(sheetTmp.name) = LCase(sSheetName) Then
				getExcelWorksheet = sheetTmp
				bFound = True
				Exit For
			End If
		Next sheetTmp
		If Not bFound Then
			MsgBox("Excel File does not include expected WorkSheet: '" & sSheetName & "'" & vbCrLf & "Please select another file and try again.")
			
			
			Exit Function
		End If
		
		
		Exit Function
		
ErrorHandler: 
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		save_error("Functions.bas", "getExcelWorksheet")
		MsgBox("Unexpected error found when loading Excel Data. " & vbCrLf & "Check log file for details.")
		
	End Function
End Module