Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmExportVendor
	Inherits System.Windows.Forms.Form
    Dim rsLocal As DataTable
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		cbCustId.SelectedIndex = cbCustName.SelectedIndex
		set_qb_group_desc(cbCustId.Text)
	End Sub
	Private Sub set_qb_group_desc(ByRef sCustId As String)
		
		On Error GoTo ErrorHandler
		
		If sCustId = "--" Then
			txtQBGroupDesc.Text = "ALL"
		Else
			sStmt = "SELECT qb_group.qb_group_desc " & " FROM qb_group, customer " & " WHERE qb_group.qb_group_id =customer.qb_group_id " & " AND customer.cust_id ='" & sCustId & "'"
			
            rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rs.Rows.Count > 0 Then
                txtQBGroupDesc.Text = rs.Rows(0).Item("qb_group_desc")
            End If
        End If
        Exit Sub

ErrorHandler:
        txtQBGroupDesc.Text = ""
        save_error(Me.Name, "set_qb_group_desc")
        MsgBox("An unexpected error has occurred. Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdExport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExport.Click
		Dim nRecords As Short
		
		nRecords = check_data
		If nRecords > 0 Then
			export_vendor(nRecords)
		End If
		
	End Sub
	'Ejecuta query y verifica que haya vendors para procesar
	Private Function check_data() As Short
		
		
		check_data = -1
		If obSql.Checked Then
			'Usar query del usuario
			sStmt = txtSql.Text
		Else
			'Armar query
			sStmt = build_query
		End If
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsLocal.Rows.Count > 0 Then
            check_data = rsLocal.Rows.Count
        Else
            MsgBox("No records were found", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
        End If
		
		Exit Function
		
ErrorHandler: 
		If obSql.Checked Then
			MsgBox("Your query is not correct. Review it and try again.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Error")
		Else
			MsgBox("Unexpected error found while obtaining vendor information." & vbCrLf & "Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
		End If
	End Function
	'Construye query segun parametros
	Private Function build_query() As String
        Dim sWhere As String = ""
		
		sStmt = "SELECT NAME, NULL AS REFNUM, NULL AS TIMESTAMP," & "PRINTAS, ADDR1, ADDR2, ADDR3, ADDR4, ADDR5," & "VTYPE, CONT1, CONT2, PHONE1, PHONE2, FAXNUM," & "NOTE, TAXID, LIMIT, TERMS, NOTEPAD, SALUTATION," & "COMPANYNAME, FIRSTNAME,   MIDINIT, LASTNAME," & "CUSTFLD1, CUSTFLD2, CUSTFLD3, CUSTFLD4, CUSTFLD5," & "CUSTFLD6, CUSTFLD7, CUSTFLD8, CUSTFLD9, CUSTFLD10," & "CUSTFLD11, CUSTFLD12, CUSTFLD13, CUSTFLD14, CUSTFLD15," & "F41, HIDDEN, DELCOUNT " & " FROM qb_vendor"
		
		If cbCustName.SelectedIndex > 0 Then
			sWhere = " WHERE qb_group_id = " & "(SELECT qb_group_id FROM customer " & " WHERE cust_id='" & cbCustId.Text & "')"
		End If
		
		sStmt = sStmt & sWhere
		build_query = sStmt
	End Function
	'Usa recordset rsLocal para descargara datos en archivo IIF
	Private Sub export_vendor(ByRef nRecords As Short)
		Dim sDir As String
		Dim fs As Scripting.FileSystemObject
		
		On Error GoTo ErrorHandler
		
		
		fs = New Scripting.FileSystemObject
		sDir = "c:\glm"
		If Not fs.FolderExists(sDir) Then
			sDir = "c:\"
		End If
		
		
		cdFileSave.InitialDirectory = sDir 'Directorio para guardar archivo IIF
		cdFileSave.DefaultExt = "iif"
		'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        cdFileSave.Filter = "QuickBooks Files (*.iif)|*.iif"
		cdFileSave.FileName = "Vendors" 'Nombre por defecto de archivo
		'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
        'cdFile.CancelError = True 'Genera un error 32755 si el usuario escoge Cancel al guardar Save
        If DialogResult.Cancel = cdFileSave.ShowDialog() Then
            Exit Sub
        End If
		
		
		
		If Trim(cdFileSave.FileName) = "" Then
			MsgBox("Unable to Export Vendor list, Please provide a file to save data.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
		Else
			'Creamos el archivo IIF para QuickBooksPro
			If write_vendor_iif((cdFileSave.FileName)) = False Then
				MsgBox("An error has ocurred. Unable to export data", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
			Else
				MsgBox("Data exported successfully." & vbCrLf & Str(nRecords) & " records were downloaded.", MsgBoxStyle.OKOnly, "GLM Message")
			End If
			'Unload Me
		End If
		Exit Sub
		
ErrorHandler: 
		
		'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
		If Err.Number = DialogResult.Cancel Then
			'Usuario selecciono cancel en SaveDialog
			MsgBox("Operation was cancelled by user.", MsgBoxStyle.OKOnly, "GLM Warning")
			Exit Sub
		Else
			save_error(Me.Name, "export_vendor")
			MsgBox("An error occurred when unloading vendors. Try again.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			
		End If
		
	End Sub
	
	Private Function write_vendor_iif(ByRef sFilename As String) As Boolean
		Dim nFields As Short
		Dim sBuffer As String
		Dim nRecords As Short
		Dim i As Short
		
		On Error GoTo ErrorHandler
		
		write_vendor_iif = True
		'Abro el nuevo archivo
		FileOpen(1, sFilename, OpenMode.Output)
		
		'HEADERS: Esto es constante, CAMBIAR CON CUIDADO
		'!VEND   NAME    REFNUM  TIMESTAMP   PRINTAS ADDR1   ADDR2   ADDR3   ADDR4   ADDR5   VTYPE   CONT1   CONT2   PHONE1  PHONE2  FAXNUM  NOTE    TAXID   LIMIT   TERMS   NOTEPAD SALUTATION  COMPANYNAME FIRSTNAME   MIDINIT LASTNAME    CUSTFLD1    CUSTFLD2    CUSTFLD3    CUSTFLD4    CUSTFLD5    CUSTFLD6    CUSTFLD7    CUSTFLD8    CUSTFLD9    CUSTFLD10   CUSTFLD11   CUSTFLD12   CUSTFLD13   CUSTFLD14   CUSTFLD15   1099    HIDDEN  DELCOUNT
		sBuffer = "!VEND" & vbTab & "NAME" & vbTab & "REFNUM" & vbTab & "TIMESTAMP" & vbTab & "PRINTAS" & vbTab & "ADDR1" & vbTab & "ADDR2" & vbTab & "ADDR3" & vbTab & "ADDR4" & vbTab & "ADDR5" & vbTab & "VTYPE" & vbTab & "CONT1" & vbTab & "CONT2" & vbTab & "PHONE1" & vbTab & "PHONE2" & vbTab & "FAXNUM" & vbTab & "NOTE" & vbTab & "TAXID" & vbTab & "LIMIT" & vbTab & "TERMS" & vbTab & "NOTEPAD" & vbTab & "SALUTATION" & vbTab & "COMPANYNAME" & vbTab & "FIRSTNAME" & vbTab & "MIDINIT" & vbTab & "LASTNAME" & vbTab & "CUSTFLD1" & vbTab & "CUSTFLD2" & vbTab & "CUSTFLD3" & vbTab & "CUSTFLD4" & vbTab & "CUSTFLD5" & vbTab & "CUSTFLD6" & vbTab & "CUSTFLD7" & vbTab & "CUSTFLD8" & vbTab & "CUSTFLD9" & vbTab & "CUSTFLD10" & vbTab & "CUSTFLD11" & vbTab & "CUSTFLD12" & vbTab & "CUSTFLD13" & vbTab & "CUSTFLD14" & vbTab & "CUSTFLD15" & vbTab & "1099" & vbTab & "HIDDEN" & vbTab & "DELCOUNT"
		
		PrintLine(1, sBuffer)
		
		'Details
        prbLoad.Maximum = rsLocal.Rows.Count
		prbLoad.Visible = True
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		nRecords = 0
        nFields = rsLocal.Columns.Count
        If rsLocal.Rows.Count <= 0 Then
            MsgBox("Failed to open cursor.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
        End If
		
        For row As Integer = 0 To rsLocal.Rows.Count - 1
            sBuffer = "VEND" & vbTab
            nRecords = nRecords + 1
            'Cada campo
            For i = 0 To nFields - 1
                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                If IsDBNull(rsLocal.Rows(row).Item(i)) Then
                    sBuffer = sBuffer & vbTab
                Else
                    If Len(Trim(rsLocal.Rows(row).Item(i))) = 0 Then
                        sBuffer = sBuffer & vbTab
                    Else
                        sBuffer = sBuffer & Trim(rsLocal.Rows(row).Item(i)) & vbTab
                    End If
                End If
            Next i

            PrintLine(1, sBuffer)
            prbLoad.Value = nRecords
        Next row


        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        prbLoad.Visible = False

        FileClose(1)
        write_vendor_iif = True
        Exit Function

ErrorHandler:
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        prbLoad.Visible = False
        save_error(Me.Name, "write_vendor_iif")
        MsgBox("Unexpected error while writing to " & sFilename, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
	End Function
	Private Sub frmExportVendor_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
        rsLocal = Nothing
		
        sStmt = "SELECT cust_name, cust_id FROM customer " & " ORDER BY cust_name"
        cbCustName.Items.Clear()
		cbCustName.Items.Insert(0, "<All>")
        load_cb_query2(cbCustName, sStmt, 1, False)
		
        sStmt = "SELECT cust_id, cust_id FROM customer " & " ORDER BY cust_name"
        cbCustId.Items.Clear()
		cbCustId.Items.Insert(0, "--")
        load_cb_query2(cbCustId, sStmt, 1, False)
		
		If cbCustName.Items.Count > 0 Then
			cbCustName.SelectedIndex = 0
		End If
		
		obSql.Checked = True
		obCriteria.Checked = False
		cbCustName.Enabled = False
		
		txtQBGroupDesc.Enabled = False
		txtQBGroupDesc.ReadOnly = True
		
		prbLoad.Visible = False
		
		txtSql.Text = "SELECT  RTRIM(v.vend_name)+' - '+RTRIM(v.vend_zip) AS NAME, " & "NULL AS REFNUM, NULL AS TIMESTAMP, " & "RTRIM(v.vend_name) AS PRINTAS, RTRIM(v.vend_address) AS ADDR1," & "RTRIM(vend_city) AS ADDR2, vend_zip AS ADDR3, NULL AS ADDR4, " & "NULL AS ADDR5, NULL AS VTYPE," & "NULL AS CONT1, NULL AS CONT2, v.vend_phone1 AS PHONE1, " & "v.vend_phone2 AS PHONE2, v.vend_fax1 AS FAXNUM," & "NULL AS NOTE, NULL AS TAXID, NULL AS LIMIT, NULL AS TERMS," & "NULL AS NOTEPAD, NULL AS SALUTATION,  NULL AS COMPANYNAME," & "NULL AS FIRSTNAME, NULL AS MIDINIT, NULL AS LASTNAME," & "NULL AS CUSTFLD1, NULL AS CUSTFLD2, NULL AS CUSTFLD3," & "NULL AS CUSTFLD4, NULL AS CUSTFLD5, NULL AS CUSTFLD6," & "NULL AS CUSTFLD7, NULL AS CUSTFLD8, NULL AS CUSTFLD9," & "NULL AS CUSTFLD10, NULL AS CUSTFLD11, NULL AS CUSTFLD12," & "NULL AS CUSTFLD13, NULL AS CUSTFLD14, NULL AS CUSTFLD15," & "NULL AS F41, NULL AS HIDDEN, NULL AS DELCOUNT" & " FROM  qb_vendor_vbranch q , vbranch v " & " WHERE q.vend_seq = v.vend_seq " & " AND q.qb_group_id=''"
		
	End Sub
	
	'UPGRADE_WARNING: Event obCriteria.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub obCriteria_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles obCriteria.CheckedChanged
		If eventSender.Checked Then
			cbCustName.Enabled = obCriteria.Checked
		End If
	End Sub
End Class