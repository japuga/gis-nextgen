Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Friend Class frmVendorSearch
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private cmLocal As SqlCommand
	
	
	'UPGRADE_WARNING: Event cbVendor.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbVendor_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbVendor.SelectedIndexChanged
		Dim sVendorName As String
		
		If cbVendor.Text = "<New>" Then
			sVendorName = InputBox("Vendor Name", "Vendor")
			sVendorName = clear_quotes(UCase(sVendorName))
			
			If save_vendor_name(sVendorName) Then
				load_vendor()
				set_vendor_name(sVendorName)
			Else
				'Si INSERT falla apuntamos al primer registro otra vez
				set_vendor_name(("NINGUNO"))
			End If
		End If
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        gVendorSearch.bFlag = False
		Me.Close()
	End Sub
	
	Private Sub cmOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmOk.Click
		gVendorSearch.bFlag = True
		gVendorSearch.nVendId = VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)
		gVendorSearch.sVendName = cbVendor.Text
		gVendorSearch.sStateId = cbState.Text
		Me.Close()
	End Sub
	
	Private Sub frmVendorSearch_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		load_comp()
	End Sub
	Private Sub init_vars()

        cmLocal = cn.CreateCommand
        cmLocal.CommandType = CommandType.Text

        '**** Inicializo gVendorSearch
        If (gVendorSearch.bFlag <> True) Then
            gVendorSearch.bFlag = False
            gVendorSearch.nVendId = -1
            gVendorSearch.sStateId = ""
            gVendorSearch.sVendName = ""
        End If
    End Sub
	Private Sub load_comp()
		load_vendor()
		
		'Cargo el combo cbState
		cbState.Items.Clear()
		cbState.Items.Insert(0, "<All>")
		sStmt = "SELECT state_id FROM state ORDER BY state_id"
		load_cb_query2(cbState, sStmt, 1, False)
		If cbState.Items.Count > 0 Then
			cbState.SelectedIndex = 0
		End If
	End Sub
	
	Private Sub load_vendor()
		'Cargo combo de Vendors
		cbVendor.Items.Clear()
		cbVendor.Items.Insert(0, "<New>")
		sStmt = "SELECT vend_name, vend_id FROM vendor ORDER BY vend_name"
		load_cb_query2(cbVendor, sStmt, 2, False)
		'Apunto por defecto al segundo registro
		If cbVendor.Items.Count > 1 Then
			cbVendor.SelectedIndex = 1
		End If
	End Sub
	'Guarda un nuevo Vendor
	Private Function save_vendor_name(ByRef sVendorName As String) As Boolean
		Dim nVendId As Short
		Dim bNew As Boolean
		Dim nCount As Short
        Dim nMaxLen As Short
        Dim cmd As SqlCommand = cn.CreateCommand
		
		On Error GoTo ErrorHandler
		
		save_vendor_name = False
		bNew = False
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(sVendorName) Then
			Exit Function
		End If
		If Trim(sVendorName) = "" Then
			Exit Function
		End If
		
		nMaxLen = get_column("vendor", "vend_name")
		If nMaxLen <= 0 Then
			nMaxLen = 60 'Default de Vendor Name
		End If
		
		If Len(sVendorName) > nMaxLen Then
			If MsgBox("The Vendor you entered is too long, data will be truncated?" & vbCrLf & "Do you want to continue", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "GLM Warning") = MsgBoxResult.Yes Then
				sVendorName = VB.Left(sVendorName, nMaxLen)
			Else
				'Usuario prefiere no guardar.
				Exit Function
			End If
		End If
		
		sStmt = "SELECT vend_id FROM vendor " & "WHERE vend_name='" & Trim(sVendorName) & "'"
        cmd.CommandText = sStmt
        rsLocal = getDataTable(sStmt) ' cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count < 1 Then
            bNew = True
        Else
            MsgBox("Vendor already exists in database.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")

            Exit Function
        End If



        If bNew Then
            sStmt = "SELECT MAX(vend_id) FROM vendor"
            cmd.CommandText = sStmt
            rsLocal = getDataTable(sStmt) ' cmd.ExecuteReader '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rsLocal.Rows.Count < 1 Then
                nVendId = 1
            Else
                nVendId = rsLocal.Rows(0).Item(0) + 1
            End If


        End If

        sStmt = "INSERT INTO vendor (vend_id, vend_name)" & " VALUES (" & Str(nVendId) & ",'" & Trim(sVendorName) & "')"
        cmLocal.CommandText = sStmt
        nCount = cmLocal.ExecuteNonQuery 'cmLocal.Execute(nCount)
        If nCount = 1 Then
            'Se inserto
            save_vendor_name = True
        Else
            MsgBox("An error has ocurred when inserting New Vendor", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
            Exit Function

        End If

        Exit Function
ErrorHandler:
        save_vendor_name = False
        save_error(Me.Name, "save_vendor_name")
        Resume Next
	End Function
	
	'Busca un vendor en el combo
	Private Sub set_vendor_name(ByRef sVendorName As String)
		Dim i As Short
		Dim bFound As Boolean
		
		bFound = False
		For i = 0 To cbVendor.Items.Count - 1
			If Trim(VB6.GetItemString(cbVendor, i)) = Trim(sVendorName) Then
				cbVendor.SelectedIndex = i
				bFound = True
				Exit For
			End If
		Next i
		
		If Not bFound Then
			If cbVendor.Items.Count > 1 Then
				cbVendor.SelectedIndex = 1
			End If
		End If
	End Sub
	Private Sub frmVendorSearch_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_NOTE: Object rsLocal may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rsLocal = Nothing
		'UPGRADE_NOTE: Object cmLocal may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		cmLocal = Nothing
	End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
End Class