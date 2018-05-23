Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Friend Class frmQBImport
	Inherits System.Windows.Forms.Form
	
    Private rsTmp As DataTable
	Private sFilename As String
	Private Structure QBVendorRecordUDT
		Dim qb_group_id As String
		'UPGRADE_NOTE: name was upgraded to name_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim name_Renamed As String
		Dim refnum As Double
		Dim TimeStamp As Double
		Dim PRINTAS As String
		Dim ADDR1 As String
		Dim ADDR2 As String
		Dim ADDR3 As String
		Dim ADDR4 As String
		Dim ADDR5 As String
		Dim VTYPE As String
		Dim CONT1 As String
		Dim CONT2 As String
		Dim PHONE1 As String
		Dim PHONE2 As String
		Dim FAXNUM As String
		Dim NOTE As String
		Dim TAXID As String
		Dim LIMIT As String
		Dim TERMS As String
		Dim NOTEPAD As String
		Dim SALUTATION As String
		'UPGRADE_NOTE: CompanyName was upgraded to CompanyName_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim CompanyName_Renamed As String
		Dim FIRSTNAME As String
		Dim MIDINIT As String
		Dim LASTNAME As String
		Dim CUSTFLD1 As String
		Dim CUSTFLD2 As String
		Dim CUSTFLD3 As String
		Dim CUSTFLD4 As String
		Dim CUSTFLD5 As String
		Dim CUSTFLD6 As String
		Dim CUSTFLD7 As String
		Dim CUSTFLD8 As String
		Dim CUSTFLD9 As String
		Dim CUSTFLD10 As String
		Dim CUSTFLD11 As String
		Dim CUSTFLD12 As String
		Dim CUSTFLD13 As String
		Dim CUSTFLD14 As String
		Dim CUSTFLD15 As String
		Dim F41 As String
		Dim Hidden As String
		Dim DELCOUNT As Double
	End Structure
	
	
	
	Private Structure QBCustomerRecordUDT
		Dim qb_group_id As String
		'UPGRADE_NOTE: name was upgraded to name_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim name_Renamed As String
		Dim refnum As Double
		Dim TimeStamp As Double
		Dim BADDR1 As String
		Dim BADDR2 As String
		Dim BADDR3 As String
		Dim BADDR4 As String
		Dim BADDR5 As String
		Dim sAddr1 As String
		Dim sAddr2 As String
		Dim sAddr3 As String
		Dim sAddr4 As String
		Dim sAddr5 As String
		Dim PHONE1 As String
		Dim PHONE2 As String
		Dim FAXNUM As String
		Dim NOTE As String
		Dim CONT1 As String
		Dim CONT2 As String
		'UPGRADE_NOTE: CTYPE was upgraded to CTYPE_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim CTYPE_Renamed As String
		Dim TERMS As String
		Dim TAXABLE As String
		Dim LIMIT As String
		Dim RESALENUM As String
		Dim REP As String
		Dim TAXITEM As String
		Dim NOTEPAD As String
		Dim SALUTATION As String
		'UPGRADE_NOTE: CompanyName was upgraded to CompanyName_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim CompanyName_Renamed As String
		Dim FIRSTNAME As String
		Dim MIDINIT As String
		Dim LASTNAME As String
		Dim CUSTFLD1 As String
		Dim CUSTFLD2 As String
		Dim CUSTFLD3 As String
		Dim CUSTFLD4 As String
		Dim CUSTFLD5 As String
		Dim CUSTFLD6 As String
		Dim CUSTFLD7 As String
		Dim CUSTFLD8 As String
		Dim CUSTFLD9 As String
		Dim CUSTFLD10 As String
		Dim CUSTFLD11 As String
		Dim CUSTFLD12 As String
		Dim CUSTFLD13 As String
		Dim CUSTFLD14 As String
		Dim CUSTFLD15 As String
		Dim JOBDESC As String
		Dim JOBTYPE As String
		Dim JOBSTATUS As Double
		Dim JOBSTART As String
		Dim JOBPROJEND As String
		Dim JOBEND As String
		Dim Hidden As String
		Dim DELCOUNT As Double
	End Structure
	
	Private QBVendorRecord As QBVendorRecordUDT
	Private QBCustomerRecord As QBCustomerRecordUDT
	
	
	
	'UPGRADE_WARNING: Event cbQBGroupDesc.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbQBGroupDesc_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbQBGroupDesc.SelectedIndexChanged
		cbQBGroupId.SelectedIndex = cbQBGroupDesc.SelectedIndex
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub cmdImport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdImport.Click
        Dim result As gDumpUDT = New gDumpUDT()
		
		'MsgBox sFilename
		If Len(sFilename) > 0 Then
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
			Select Case General.gQbFileType
				Case General.QbFileType.QbAccount
				Case General.QbFileType.QbCustomer
					'UPGRADE_WARNING: Couldn't resolve default property of object result. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					result = read_qb_customer(cbQBGroupId.Text, sFilename)
				Case General.QbFileType.QbVendor
					'UPGRADE_WARNING: Couldn't resolve default property of object result. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					result = read_qb_vendors(cbQBGroupId.Text, sFilename)
			End Select
			
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			MsgBox("Process Complete." & vbCrLf & "Total records Processed:" & result.str1, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
		Else
			MsgBox("Please select a Quick Books File to process.")
		End If
		
	End Sub
	
	Private Sub cmdOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOpen.Click
		Dim sDir As String
		Dim fs As Scripting.FileSystemObject
		
		On Error GoTo ErrorHandler
		
		fs = New Scripting.FileSystemObject
		
		sDir = "c:\glm"
		If Not fs.FolderExists(sDir) Then
			sDir = "c:\"
		End If
		
		
		cdFileOpen.InitialDirectory = sDir 'Directorio para guardar archivo IIF
		cdFileOpen.DefaultExt = ".iif"
		'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		cdFileOpen.Filter = "QuickBooks Files (*.iif)|*.iif"
		cdFileOpen.FilterIndex = 1
		'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
        'cdFile.CancelError = True 'Genera un error 32755 si el usuario escoge Cancel al guardar Save
        If DialogResult.Cancel = cdFileOpen.ShowDialog() Then
            Exit Sub
        End If



        If Trim(cdFileOpen.FileName) = "" Then
            sFilename = ""
            MsgBox("Unable to Load Info, Please provide a Data FIle.", MsgBoxStyle.OkOnly, "GLM Warning")
        Else
            If fs.FileExists(cdFileOpen.FileName) Then
                sFilename = cdFileOpen.FileName
                txtFile.Text = cdFileOpen.FileName
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
            MsgBox("Operation was cancelled by user.", MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Sub
        Else
            save_error(Me.Name, "cmdOk")
            MsgBox("An error occurred while opening file. Try again.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")

        End If
    End Sub
	
	Private Sub frmQBImport_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		sFilename = ""
		init_vars()
		
	End Sub
	Private Sub init_vars()
		
		If gbDebug Then
			Me.Width = VB6.TwipsToPixelsX(9885)
			Me.Height = VB6.TwipsToPixelsY(7605)
        End If

        txtFile.Text = ""
		
		sStmt = "SELECT qb_group_desc, qb_group_id " & " FROM qb_group  ORDER BY qb_group_desc "
		load_cb_query2(cbQBGroupDesc, sStmt, 1, True)
		
		sStmt = "SELECT qb_group_id, qb_group_desc " & " FROM qb_group  ORDER BY qb_group_desc "
		load_cb_query2(cbQBGroupId, sStmt, 1, True)
		
        cm = cn.CreateCommand '.let_ActiveConnection(cn)
        cm.CommandType = CommandType.Text
		
		If cbQBGroupDesc.Items.Count > 0 Then
			cbQBGroupDesc.SelectedIndex = 0
		End If
	End Sub
	'07.23.03
	Private Function read_qb_customer(ByRef sQBGroupId As String, ByRef sFilename As String) As gDumpUDT
		Dim fso As Scripting.FileSystemObject
		Dim ts As Scripting.TextStream
		Dim sLine As String
		Dim nLineNum As Short
        Dim bContinue As Boolean
        read_qb_customer = New gDumpUDT
		
		Dim sWord As String
		Dim bHeader As Boolean
		
		Dim nRecords As Short
		
		
		On Error GoTo ErrorHandler
		
		read_qb_customer.str1 = "0" 'Numero de registros procesados
		
		bContinue = True
        rsTmp = Nothing
		fso = New Scripting.FileSystemObject
		ts = fso.OpenTextFile(sFilename, Scripting.IOMode.ForReading, False)
		'Debug
		If gbDebug Then
			'UPGRADE_NOTE: Object dgImport.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			dgImport.DataSource = Nothing

			sStmt = "SELECT * FROM qb_customer "
			
            rsTmp = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)
			
		End If
		
		bHeader = False
		nLineNum = 0
		nRecords = 0
		
		Do While Not ts.AtEndOfStream
			If bContinue = False Then
				Exit Do
			End If
			
			nLineNum = nLineNum + 1
			sLine = ts.ReadLine
			If Len(sLine) > 0 Then
				If InStr(1, sLine, "!CUST", CompareMethod.Text) Then
					If InStr(1, sLine, "!CUSTNAME", CompareMethod.Text) Then
						'Ignorar si la linea es CUSTNAME
					Else
						bHeader = True
					End If
				Else
					If InStr(1, sLine, "CUST", CompareMethod.Text) And bHeader Then
						'Nueva Linea
						nRecords = nRecords + 1
						If nRecords > 5000 Then
							Exit Do
						End If
						
						'Separo las columnas
						bContinue = parse_customer_record(sQBGroupId, sLine)
					End If 'Vendor record
				End If 'Line>0
			End If
		Loop 
		ts.Close()
		
		read_qb_customer.str1 = Str(nRecords)
		If gbDebug Then
			dgImport.DataSource = rsTmp
		End If
		Exit Function
		
ErrorHandler: 
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		'UPGRADE_WARNING: frmQBImport property VB.Global.Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		If System.Windows.Forms.Cursor.Current.equals(System.Windows.Forms.Cursors.WaitCursor) Then
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		End If
		save_error(Me.Name, "read_qb_customer: QB File" & sFilename)
		MsgBox("Failed to read QuickBooks File." & vbCrLf & "Check log file for details", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
		
	End Function
	'Separa campos del registro de cliente
	Private Function parse_customer_record(ByRef sQBGroupId As String, ByRef sLine As String) As Boolean
		Dim sWord As String
		Dim nCol As Short
		Dim nPrevPos As Object
		Dim nPos As Short
		Dim nStart As Short
		Static n As Short
		
		On Error GoTo ErrorHandler
		
		parse_customer_record = True
		n = n + 1
		nStart = 1
		nCol = 0
		If gbDebug Then
            'rsTmp.AddNew()
		End If
		'clear_vendor_record
		Do While True
			'UPGRADE_WARNING: Couldn't resolve default property of object nPrevPos. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			nPrevPos = nPos
			'Campos estan separados por Tabs
			nPos = InStr(nStart, sLine, vbTab, CompareMethod.Text)
			
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If nPos <= 0 Or IsDbNull(nPos) Then
				'sWord = Mid(sLine, nStart, nPrevPos)
                'rsTmp.item(nCol) = sWord
				Exit Do
			Else
				sWord = Mid(sLine, nStart, nPos - nStart)
				
				If gbDebug Then
					If nCol > 0 Then
                        'rsTmp.item(nCol).Value = sWord
					Else
                        'rsTmp.item(0).Value = VB.Left(Trim(Str(n)), 2)
					End If
				End If
				
				Select Case nCol
					Case 0
						QBCustomerRecord.qb_group_id = sQBGroupId
					Case 1
						QBCustomerRecord.name_Renamed = sWord
					Case 2
						QBCustomerRecord.refnum = CDbl(sWord)
					Case 3
						QBCustomerRecord.TimeStamp = CDbl(sWord)
					Case 4
						'PENDIENTE cargar datos 08.19.03
					Case 5
					Case 6
					Case 7
					Case 8
					Case 9
					Case 10
					Case 11
					Case 12
					Case 13
					Case 14
					Case 15
					Case 16
					Case 17
					Case 18
					Case 19
					Case 20
					Case 21
					Case 22
					Case 23
					Case 24
					Case 25
					Case 26
					Case 27
					Case 28
					Case 29
					Case 30
					Case 31
					Case 32
					Case 33
					Case 34
					Case 35
					Case 36
					Case 37
					Case 38
					Case 39
					Case 40
					Case 41
					Case 42
					Case 43
					Case 44
					Case 45
					Case 46
					Case 47
					Case 48
					Case 49
					Case 50
					Case 51
					Case 52
					Case 53
					Case 54
					Case 55
					Case 56
				End Select
			End If
		Loop 
		Exit Function
		
ErrorHandler: 
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		'UPGRADE_WARNING: frmQBImport property VB.Global.Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		If System.Windows.Forms.Cursor.Current.equals(System.Windows.Forms.Cursors.WaitCursor) Then
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		End If
		parse_customer_record = False
		save_error(Me.Name, "parse_customer_record")
		MsgBox("Failed parsing Customer record." & vbCrLf & "Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
		
	End Function
    Private Function save_customer_record() As Boolean
        save_customer_record = False
    End Function
	Private Function read_qb_vendors(ByRef sQBGroupId As String, ByRef sFilename As String) As gDumpUDT
		Dim fso As Scripting.FileSystemObject
		Dim ts As Scripting.TextStream
		Dim sLine As String
		Dim nLineNum As Short
        Dim bContinue As Boolean
        read_qb_vendors = New gDumpUDT
		
		Dim sWord As String
		Dim bHeader As Boolean
		
		Dim nRecords As Short
		
		
		On Error GoTo ErrorHandler
		
		read_qb_vendors.str1 = "0" 'Numero de registros procesados
		
		bContinue = True
        rsTmp = Nothing
		fso = New Scripting.FileSystemObject
		ts = fso.OpenTextFile(sFilename, Scripting.IOMode.ForReading, False)
		'Debug
		If gbDebug Then
			'UPGRADE_NOTE: Object dgImport.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			dgImport.DataSource = Nothing

			sStmt = "SELECT * FROM qb_vendor "
			
            rsTmp = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)
		End If
		
		bHeader = False
		nLineNum = 0
		nRecords = 0
		
		Do While Not ts.AtEndOfStream
			If bContinue = False Then
				Exit Do
			End If
			
			nLineNum = nLineNum + 1
			sLine = ts.ReadLine
			If Len(sLine) > 0 Then
				If InStr(1, sLine, "!VEND", CompareMethod.Text) Then
					bHeader = True
				Else
					If InStr(1, sLine, "VEND", CompareMethod.Text) And bHeader Then
						'Nueva Linea
						nRecords = nRecords + 1
						If nRecords > 5000 Then
							Exit Do
						End If
						
						'Separo las columnas
						bContinue = parse_vendor_record(sQBGroupId, sLine)
					End If 'Vendor record
				End If 'Line>0
			End If
		Loop 
		ts.Close()
		
		read_qb_vendors.str1 = Str(nRecords)
		If gbDebug Then
			dgImport.DataSource = rsTmp
		End If
		Exit Function
		
ErrorHandler: 
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		'UPGRADE_WARNING: frmQBImport property VB.Global.Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		If System.Windows.Forms.Cursor.Current.equals(System.Windows.Forms.Cursors.WaitCursor) Then
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		End If
		save_error(Me.Name, "read_qb_vendors: QB File" & sFilename)
		MsgBox("Failed to read QuickBooks File." & vbCrLf & "Check log file for details", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
	End Function
	
	'Separa cada campo del registro de Vendedores y lo almacena en QBVendorRecord
	Private Function parse_vendor_record(ByRef sQBGroupId As String, ByRef sLine As String) As Boolean
		'Dim sQBGroupId As String
		Dim sWord As String
		Dim nCol As Short
		Dim nPrevPos As Object
		Dim nPos As Short
		Dim nStart As Short
		Static n As Short
		
		On Error GoTo ErrorHandler
		
		parse_vendor_record = True
		n = n + 1
		nStart = 1
		nCol = 0
		If gbDebug Then
            'rsTmp.AddNew()
		End If
		'clear_vendor_record
		Do While True
			'UPGRADE_WARNING: Couldn't resolve default property of object nPrevPos. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			nPrevPos = nPos
			'Campos estan separados por Tabs
			nPos = InStr(nStart, sLine, vbTab, CompareMethod.Text)
			
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If nPos <= 0 Or IsDbNull(nPos) Then
				'sWord = Mid(sLine, nStart, nPrevPos)
                'rsTmp.item(nCol) = sWord
				Exit Do
			Else
				sWord = Mid(sLine, nStart, nPos - nStart)
				
				If gbDebug Then
					If nCol > 0 Then
                        ' rsTmp.item(nCol).Value = sWord
					Else
                        'rsTmp.item(0).Value = VB.Left(Trim(Str(n)), 2)
					End If
				End If
				
				Select Case nCol
					Case 0
						QBVendorRecord.qb_group_id = sQBGroupId
					Case 1
						QBVendorRecord.name_Renamed = sWord
					Case 2
						QBVendorRecord.refnum = CDbl(sWord)
					Case 3
						QBVendorRecord.TimeStamp = CDbl(sWord)
					Case 4
						QBVendorRecord.PRINTAS = sWord
					Case 5
						QBVendorRecord.ADDR1 = sWord
					Case 6
						QBVendorRecord.ADDR2 = sWord
					Case 7
						QBVendorRecord.ADDR3 = sWord
					Case 8
						QBVendorRecord.ADDR4 = sWord
					Case 9
						QBVendorRecord.ADDR5 = sWord
					Case 10
						QBVendorRecord.VTYPE = sWord
					Case 11
						QBVendorRecord.CONT1 = sWord
					Case 12
						QBVendorRecord.CONT2 = sWord
					Case 13
						QBVendorRecord.PHONE1 = sWord
					Case 14
						QBVendorRecord.PHONE2 = sWord
					Case 15
						QBVendorRecord.FAXNUM = sWord
					Case 16
						QBVendorRecord.NOTE = sWord
					Case 17
						QBVendorRecord.TAXID = sWord
					Case 18
						QBVendorRecord.LIMIT = sWord
					Case 19
						QBVendorRecord.TERMS = sWord
					Case 20
						QBVendorRecord.NOTEPAD = sWord
					Case 21
						QBVendorRecord.SALUTATION = sWord
					Case 22
						QBVendorRecord.CompanyName_Renamed = sWord
					Case 23
						QBVendorRecord.FIRSTNAME = sWord
					Case 24
						QBVendorRecord.MIDINIT = sWord
					Case 25
						QBVendorRecord.LASTNAME = sWord
					Case 26
						QBVendorRecord.CUSTFLD1 = sWord
					Case 27
						QBVendorRecord.CUSTFLD2 = sWord
					Case 28
						QBVendorRecord.CUSTFLD3 = sWord
					Case 29
						QBVendorRecord.CUSTFLD4 = sWord
					Case 30
						QBVendorRecord.CUSTFLD5 = sWord
					Case 31
						QBVendorRecord.CUSTFLD6 = sWord
					Case 32
						QBVendorRecord.CUSTFLD7 = sWord
					Case 33
						QBVendorRecord.CUSTFLD8 = sWord
					Case 34
						QBVendorRecord.CUSTFLD9 = sWord
					Case 35
						QBVendorRecord.CUSTFLD10 = sWord
					Case 36
						QBVendorRecord.CUSTFLD11 = sWord
					Case 37
						QBVendorRecord.CUSTFLD12 = sWord
					Case 38
						QBVendorRecord.CUSTFLD13 = sWord
					Case 39
						QBVendorRecord.CUSTFLD14 = sWord
					Case 40
						QBVendorRecord.CUSTFLD15 = sWord
					Case 41
						QBVendorRecord.F41 = sWord
					Case 42
						QBVendorRecord.Hidden = sWord
					Case 43
						'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
						If Not IsDbNull(sWord) Then
							QBVendorRecord.DELCOUNT = CDbl(sWord)
						End If
				End Select
				
				nCol = nCol + 1
				nStart = nPos + 1
			End If
		Loop 
		
		If save_vendor_record() = False Then
			parse_vendor_record = False
		End If
		Exit Function
		
ErrorHandler: 
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		'UPGRADE_WARNING: frmQBImport property VB.Global.Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		If System.Windows.Forms.Cursor.Current.equals(System.Windows.Forms.Cursors.WaitCursor) Then
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		End If
		parse_vendor_record = False
		save_error(Me.Name, "parse_vendor_record")
		MsgBox("Failed parsing Vendor record." & vbCrLf & "Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
	End Function
	'Registro se inserta o actualiza en qb_vendor
	'Retorna TRUE en caso de error
	Private Function save_vendor_record() As Boolean
		Dim nRecords As Short
		
		
		On Error GoTo ErrorHandler
		
		'Si el segundo campo (NAME) existe en qb_vendor
		'actualizo el registro
		save_vendor_record = True
		sStmt = "SELECT name FROM qb_vendor " & " WHERE qb_group_id ='" & Trim(cbQBGroupId.Text) & "' " & " AND LTRIM(RTRIM(name))='" & Trim(quotation_mask(QBVendorRecord.name_Renamed)) & "'"
		
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.Rows.Count = 1 Then
            'Registro ya existe, actualizar
            sStmt = "UPDATE qb_vendor " & " SET refnum =" & Str(QBVendorRecord.refnum) & "," & " TIMESTAMP=" & Str(QBVendorRecord.TimeStamp) & "," & " PRINTAS ='" & Trim(quotation_mask(QBVendorRecord.PRINTAS)) & "'," & " ADDR1 = '" & Trim(quotation_mask(QBVendorRecord.ADDR1)) & "'," & " ADDR2 = '" & Trim(quotation_mask(QBVendorRecord.ADDR2)) & "'," & " ADDR3 = '" & Trim(quotation_mask(QBVendorRecord.ADDR3)) & "'," & " ADDR4 = '" & Trim(quotation_mask(QBVendorRecord.ADDR4)) & "'," & " ADDR5 = '" & Trim(quotation_mask(QBVendorRecord.ADDR5)) & "'," & " VTYPE = '" & Trim(quotation_mask(QBVendorRecord.VTYPE)) & "'," & " CONT1 = '" & Trim(quotation_mask(QBVendorRecord.CONT1)) & "'," & " CONT2 = '" & Trim(quotation_mask(QBVendorRecord.CONT2)) & "'," & " PHONE1 = '" & Trim(quotation_mask(QBVendorRecord.PHONE1)) & "'," & " PHONE2 = '" & Trim(quotation_mask(QBVendorRecord.PHONE2)) & "'," & " FAXNUM = '" & Trim(quotation_mask(QBVendorRecord.FAXNUM)) & "'," & " NOTE = '" & Trim(quotation_mask(QBVendorRecord.NOTE)) & "'," & " TAXID = '" & Trim(quotation_mask(QBVendorRecord.TAXID)) & "'," & " LIMIT = '" & Trim(quotation_mask(QBVendorRecord.LIMIT)) & "'," & " TERMS = '" & Trim(quotation_mask(QBVendorRecord.TERMS)) & "'," & " NOTEPAD = '" & Trim(quotation_mask(QBVendorRecord.NOTEPAD)) & "'," & " SALUTATION = '" & Trim(quotation_mask(QBVendorRecord.SALUTATION)) & "'," & " CompanyName = '" & Trim(quotation_mask(QBVendorRecord.CompanyName_Renamed)) & "'," & " FIRSTNAME = '" & Trim(quotation_mask(QBVendorRecord.FIRSTNAME)) & "'," & " MIDINIT = '" & Trim(quotation_mask(QBVendorRecord.MIDINIT)) & "',"
            sStmt = sStmt & " LASTNAME = '" & Trim(quotation_mask(QBVendorRecord.LASTNAME)) & "'," & " CUSTFLD1 = '" & Trim(quotation_mask(QBVendorRecord.CUSTFLD1)) & "'," & " CUSTFLD2 = '" & Trim(quotation_mask(QBVendorRecord.CUSTFLD2)) & "'," & " CUSTFLD3 = '" & Trim(quotation_mask(QBVendorRecord.CUSTFLD3)) & "'," & " CUSTFLD4 = '" & Trim(quotation_mask(QBVendorRecord.CUSTFLD4)) & "'," & " CUSTFLD5 = '" & Trim(quotation_mask(QBVendorRecord.CUSTFLD5)) & "'," & " CUSTFLD6 = '" & Trim(quotation_mask(QBVendorRecord.CUSTFLD6)) & "'," & " CUSTFLD7 = '" & Trim(quotation_mask(QBVendorRecord.CUSTFLD7)) & "'," & " CUSTFLD8 = '" & Trim(quotation_mask(QBVendorRecord.CUSTFLD8)) & "'," & " CUSTFLD9 = '" & Trim(quotation_mask(QBVendorRecord.CUSTFLD9)) & "'," & " CUSTFLD10 = '" & Trim(quotation_mask(QBVendorRecord.CUSTFLD10)) & "'," & " CUSTFLD11 = '" & Trim(quotation_mask(QBVendorRecord.CUSTFLD11)) & "'," & " CUSTFLD12 = '" & Trim(quotation_mask(QBVendorRecord.CUSTFLD12)) & "'," & " CUSTFLD13 = '" & Trim(quotation_mask(QBVendorRecord.CUSTFLD13)) & "'," & " CUSTFLD14 = '" & Trim(quotation_mask(QBVendorRecord.CUSTFLD14)) & "'," & " CUSTFLD15 = '" & Trim(quotation_mask(QBVendorRecord.CUSTFLD15)) & "'," & " F41 = '" & Trim(quotation_mask(QBVendorRecord.F41)) & "'," & " Hidden = '" & Trim(quotation_mask(QBVendorRecord.Hidden)) & "'," & " DELCOUNT = " & Str(QBVendorRecord.DELCOUNT)
            sStmt = sStmt & "WHERE qb_group_id ='" & Trim(quotation_mask(QBVendorRecord.qb_group_id)) & "' " & " AND name = '" & Trim(quotation_mask(QBVendorRecord.name_Renamed)) & "' "

            'MsgBox sStmt
            cm.CommandText = sStmt
            nRecords = cm.ExecuteNonQuery()
            If nRecords > 0 Then
                'ok
            Else
                'error
                If MsgBox("Failed to update vendor:" & QBVendorRecord.name_Renamed & vbCrLf & "Do you want to continue processing?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "GLM Error") = MsgBoxResult.No Then
                    'Abort Process
                    save_vendor_record = False
                    Exit Function
                End If
                save_vendor_record = True
                Exit Function
            End If
        Else
            If rs.Rows.Count <= 0 Then
                'Registro nuevo, insertar
                sStmt = "INSERT INTO qb_vendor  " & " (qb_group_id, NAME, refnum, TimeStamp, PRINTAS, " & " ADDR1, ADDR2, ADDR3, ADDR4, ADDR5, " & " VTYPE, CONT1, CONT2, PHONE1, PHONE2, " & " FAXNUM, NOTE, TAXID, LIMIT, TERMS, " & " NOTEPAD, SALUTATION, CompanyName, FIRSTNAME, " & " MIDINIT, LASTNAME, CUSTFLD1, CUSTFLD2, " & " CUSTFLD3, CUSTFLD4, CUSTFLD5, CUSTFLD6, " & " CUSTFLD7, CUSTFLD8, CUSTFLD9, CUSTFLD10, " & " CUSTFLD11, CUSTFLD12, CUSTFLD13, CUSTFLD14, " & " CUSTFLD15, F41, Hidden, DELCOUNT )" & " VALUES "
                sStmt = sStmt & "('" & QBVendorRecord.qb_group_id & "'," & "'" & Trim(quotation_mask(QBVendorRecord.name_Renamed)) & "'," & "" & Str(QBVendorRecord.refnum) & "," & "" & Str(QBVendorRecord.TimeStamp) & "," & "'" & Trim(quotation_mask(QBVendorRecord.PRINTAS)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.ADDR1)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.ADDR2)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.ADDR3)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.ADDR4)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.ADDR5)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.VTYPE)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CONT1)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CONT2)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.PHONE1)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.PHONE2)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.FAXNUM)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.NOTE)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.TAXID)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.LIMIT)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.TERMS)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.NOTEPAD)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.SALUTATION)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CompanyName_Renamed)) & "',"
                sStmt = sStmt & "'" & Trim(quotation_mask(QBVendorRecord.FIRSTNAME)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.MIDINIT)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.LASTNAME)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CUSTFLD1)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CUSTFLD2)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CUSTFLD3)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CUSTFLD4)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CUSTFLD5)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CUSTFLD6)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CUSTFLD7)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CUSTFLD8)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CUSTFLD9)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CUSTFLD10)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CUSTFLD11)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CUSTFLD12)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CUSTFLD13)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CUSTFLD14)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.CUSTFLD15)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.F41)) & "'," & "'" & Trim(quotation_mask(QBVendorRecord.Hidden)) & "'," & "'" & Str(QBVendorRecord.DELCOUNT) & "')"
                'MsgBox sStmt
                cm.CommandText = sStmt
                nRecords = cm.ExecuteNonQuery()
                If nRecords > 0 Then
                    'ok
                Else
                    'error
                    If MsgBox("Failed to insert vendor:" & QBVendorRecord.name_Renamed & vbCrLf & "Do you want to continue processing?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "GLM Error") = MsgBoxResult.Yes Then
                        'Abortar?
                        save_vendor_record = False
                    End If
                    save_vendor_record = True
                    Exit Function
                End If
                'rsTmp(0) = "New"
            Else
                'Registro repetido en base de datos
            End If
        End If


        Exit Function

ErrorHandler:
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        'UPGRADE_WARNING: frmQBImport property VB.Global.Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        If System.Windows.Forms.Cursor.Current.Equals(System.Windows.Forms.Cursors.WaitCursor) Then
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End If

        save_error(Me.Name, "save_vendor_record")
        MsgBox("Failed to save Vendor Record." & vbCrLf & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
	End Function
End Class