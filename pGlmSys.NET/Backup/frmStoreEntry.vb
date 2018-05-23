Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Friend Class frmStoreEntry
	Inherits System.Windows.Forms.Form
    Private rsTmp As DataTable
    Private cmLocal As SqlCommand
    Private rsLocal As DataTable

    Private Sub ckSame_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ckSame.CheckStateChanged
        If ckSame.CheckState = System.Windows.Forms.CheckState.Checked Then
            cmdAddress.Enabled = False
            If Not setBillingAsPhysicalAddress() Then
                ckSame.CheckState = System.Windows.Forms.CheckState.Unchecked
            End If
        Else
            cmdAddress.Enabled = True

            gStoreRecord.nStoreAddressSeq = 0

            Me.txtStoreBillAddress.Text = ""
            Me.txtStoreBillCity.Text = ""
            Me.txtStoreBillState.Text = ""
            Me.txtStoreBillZip.Text = ""
        End If


    End Sub
	
	Private Sub cmdAddress_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAddress.Click
		
		Select Case General.gbMode
			Case General.modo.NewRecord
				MsgBox("Please save current record before attempting this command.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
				Exit Sub
			Case General.modo.UpdateRecord
				gStoreAddress.bAddressFlag = General.addressMode.LookupMode
				gStoreAddress.sCustId = txtCustId.Text
				gStoreAddress.sCustName = txtCustName.Text
				gStoreAddress.nStoreId = gStoreRecord.nStoreId
				
				VB6.ShowForm(frmStoreAddress, VB6.FormShowConstants.Modal, Me)
				
				If gStoreAddress.bAddressFlag = General.addressMode.RecordSelected Then
					gStoreRecord.nStoreAddressSeq = gStoreAddress.nStoreAddressSeq
					txtStoreBillAddress.Text = gStoreAddress.sAddress
					txtStoreBillCity.Text = gStoreAddress.sCity
					txtStoreBillState.Text = gStoreAddress.sState
					txtStoreBillZip.Text = gStoreAddress.sZip
				End If
				
				
		End Select
		
		
		
		
		
		
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		Dim nCount As Short
        'Dim sStoreZip As String
		Dim sStorePhone1 As String
		Dim sStorePhone2 As String
		Dim sStoreFax1 As String
		Dim sStoreFax2 As String
		Dim nOccupants As Short
		Dim sWhere As String
		
		'MsgBox Str(Asc(" "))
		
		If Not val_fields(General.gbMode) Then
			Exit Sub 'Uno o mas campos necesitan datos
		End If
		
		'If Len(mtxtStoreZip.ClipText) > 5 Then
		'    sStoreZip = Left(mtxtStoreZip.ClipText, 5) + "-" + _
		''                    Mid(mtxtStoreZip.ClipText, 6, 10 - Len(mtxtStoreZip.ClipText))
		'Else
		'    If Len(mtxtStoreZip.ClipText) = 5 Then
		'        sStoreZip = mtxtStoreZip.ClipText + "-"
		'    Else
		'Deberia ser cero en este caso
		'        sStoreZip = ""
		'    End If
		'End If
		
        If getPhoneNumberLen(mtxtStorePhone1.Text) = 0 Then
            sStorePhone1 = ""
        Else
            sStorePhone1 = mtxtStorePhone1.Text
        End If
		
        If getPhoneNumberLen(mtxtStorePhone2.Text) = 0 Then
            sStorePhone2 = ""
        Else
            sStorePhone2 = mtxtStorePhone2.Text
        End If
		
        If getPhoneNumberLen(mtxtStoreFax1.Text) = 0 Then
            sStoreFax1 = ""
        Else
            sStoreFax1 = mtxtStoreFax1.Text
        End If
		
        If getPhoneNumberLen(mtxtStoreFax2.Text) = 0 Then
            sStoreFax2 = ""
        Else
            sStoreFax2 = mtxtStoreFax2.Text
        End If
		
		If Len(txtOccupants.Text) = 0 Then
			nOccupants = 0
		Else
            'nOccupants = Int(CDbl(txtOccupants.Text))
            nOccupants = Int(Convert.ToDouble(txtOccupants.Text))
		End If
		
		Select Case General.gbMode
			Case General.modo.NewRecord
				'Tienda Nueva
				gStoreRecord.nStoreId = get_Store_id(Trim(txtCustId.Text))
				
				
				sStmt = "INSERT INTO store (cust_id, store_id, " & "store_number, store_name, " & "store_address, store_city, store_zip, " & "state_id, store_phone1, store_phone2, " & "store_fax1, store_fax2, store_contact," & "store_status, store_folder, store_co_code, " & " store_occupants, store_billing_contact, store_billing_account, " & " lf_group, store_market, store_sold, store_sold_date ) "
				
				'MsgBox dtStoreSoldDate.value
				sStmt = sStmt & "VALUES ('" & Trim(txtCustId.Text) & "'," & Str(gStoreRecord.nStoreId) & "," & "'" & Trim(txtStoreNumber.Text) & "'," & "'" & Trim(txtStoreName.Text) & "'," & "'" & Trim(txtStoreAddress.Text) & "'," & "'" & Trim(txtStoreCity.Text) & "', " & "'" & Trim(txtStoreZip.Text) & "','" & cbState.Text & "'," & "'" & Trim(sStorePhone1) & "','" & Trim(sStorePhone2) & "'," & "'" & Trim(sStoreFax1) & "','" & Trim(sStoreFax2) & "'," & "'" & Trim(txtStoreContact.Text) & "'," & "'" & VB.Left(cbStoreStatus.Text, 1) & "'," & "'" & Trim(txtStoreFolder.Text) & "'," & "'" & Trim(txtStoreCoCode.Text) & "', " & Str(nOccupants) & "," & "'" & Trim(quotation_mask((txtBillingContact.Text))) & "', " & "'" & Trim(quotation_mask((txtBillingAccount.Text))) & "', " & "'" & Trim(quotation_mask((txtLfGroup.Text))) & "', " & "'" & Trim(quotation_mask((txtStoreMarket.Text))) & "', " & "'" & Trim(quotation_mask((txtStoreSold.Text))) & "', " & "'" & CStr(dtStoreSoldDate.value) & "' )"
				
				
				
				
                'msgBox sStmt
                cmLocal = cn.CreateCommand
                cmLocal.CommandType = CommandType.Text
                cmLocal.CommandText = sStmt
                nCount = cmLocal.ExecuteNonQuery()
				
				If nCount = 1 Then
					'Registro salvado en BD.
					'Refrescar datagrid con nuevos datos
					General.gbMode = General.modo.SavedRecord
				End If
				
				If insert_store_group(txtCustId.Text, gStoreRecord.nStoreId) Then
					'ok
				Else
					MsgBox("Failed to include store in Group: All", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
				End If
				
				MsgBox("Store was successfully created!", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
				
			Case General.modo.UpdateRecord
				
				
				sStmt = "UPDATE store SET " & "store_name = '" & Trim(txtStoreName.Text) & "'," & "store_address = '" & Trim(txtStoreAddress.Text) & "', " & "store_city = '" & Trim(txtStoreCity.Text) & "', " & "state_id = '" & cbState.Text & "', " & "store_zip = '" & Trim(txtStoreZip.Text) & " ', " & "store_phone1 = '" & Trim(sStorePhone1) & "', " & "store_phone2 = '" & Trim(sStorePhone2) & "', " & "store_fax1 = '" & Trim(sStoreFax1) & "', " & "store_fax2 ='" & Trim(sStoreFax2) & "', " & "store_contact = '" & Trim(txtStoreContact.Text) & "', " & "store_status = '" & VB.Left(cbStoreStatus.Text, 1) & "', " & "store_folder = '" & Trim(txtStoreFolder.Text) & "', " & "store_co_code = '" & Trim(txtStoreCoCode.Text) & "', " & "store_occupants = " & Str(nOccupants) & ", " & "store_billing_contact = '" & Trim(quotation_mask((txtBillingContact.Text))) & "', " & "store_billing_account = '" & Trim(quotation_mask((txtBillingAccount.Text))) & "', " & "lf_group = '" & txtLfGroup.Text & "', " & "store_market = '" & txtStoreMarket.Text & "', " & "store_sold = '" & txtStoreSold.Text & "' "

                'If dtStoreSoldDate.Value Like System.DBNull.Value Then
                sStmt = sStmt & ", store_sold_date = '" & CStr(dtStoreSoldDate.Value) & "'"

                If gStoreRecord.nStoreAddressSeq > 0 Then
                    sStmt = sStmt & "," & "store_address_seq = " & Str(gStoreRecord.nStoreAddressSeq)
                Else
                    sStmt = sStmt & "," & "store_address_seq = null "
                End If

                sWhere = " WHERE store_id =" & Str(gStoreRecord.nStoreId) & " AND cust_id ='" & Trim(txtCustId.Text) & "'"

                sStmt = sStmt & sWhere
                cmLocal.CommandType = CommandType.Text
                cmLocal.CommandText = sStmt
                nCount = cmLocal.ExecuteNonQuery()

                If nCount >= 1 Then
                    'Registro salvado en BD.
                    'Refrescar datagrid con nuevos datos
                    General.gbMode = General.modo.SavedRecord
                End If
                MsgBox("Store was successfully updated!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")

        End Select
		Me.Close()
	End Sub
	
	Private Sub frmStoreEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		set_limit()
		init_vars(General.gbMode)
	End Sub
	'Valores maximos en textfields
	Private Sub set_limit()
		Dim nLength As Short
		
		'Store Number
		nLength = get_column("store", "store_number")
		If nLength > 0 Then
            txtStoreNumber.MaxLength = nLength
		Else
            txtStoreNumber.MaxLength = 20
		End If
		
		'Store Name
		nLength = get_column("store", "store_name")
		If nLength > 0 Then
            txtStoreName.MaxLength = nLength
		Else
            txtStoreName.MaxLength = 30
		End If
		
		'Store Address
		nLength = get_column("store", "store_address")
		If nLength > 0 Then
            txtStoreAddress.MaxLength = nLength
		Else
            txtStoreAddress.MaxLength = 80
		End If
		
		'Store City
		nLength = get_column("store", "store_city")
		If nLength > 0 Then
            txtStoreCity.MaxLength = nLength
		Else
            txtStoreCity.MaxLength = 30
		End If
		
		'Store Folder
		nLength = get_column("store", "store_folder")
		If nLength > 0 Then
            txtStoreFolder.MaxLength = nLength
		Else
            txtStoreFolder.MaxLength = 20
		End If
		
		'Store Company Code
		nLength = get_column("store", "store_co_code")
		If nLength > 0 Then
            txtStoreCoCode.MaxLength = nLength
		Else
            txtStoreCoCode.MaxLength = 20
		End If
		
		
	End Sub
	Private Sub init_vars(ByRef sOption As General.modo)

        cmLocal = cn.CreateCommand
		
		On Error GoTo ErrorHandler
		
		txtCustName.Text = gbStoreSearch.sCustName
		txtCustId.Text = gbStoreSearch.sCustId
		
		ckSame.CheckState = System.Windows.Forms.CheckState.Unchecked
		
		'Combo cbState
		sStmt = "SELECT DISTINCT state_id FROM suser_data " & "WHERE suser_name='" & Trim(gsUser) & "' " & "AND cust_id='" & Trim(txtCustId.Text) & "' " & "ORDER BY state_id"
		load_cb_query(cbState, sStmt, 1)
		
		If cbState.Items.Count > 0 Then
			cbState.SelectedIndex = 0
		End If
		'Combo cbStoreStatus
		cbStoreStatus.Items.Insert(0, "Active")
		cbStoreStatus.Items.Insert(1, "Inactive")
		
		
		'jp.E011.begin - disable Billing Address
		txtStoreBillAddress.Enabled = False
		txtStoreBillAddress.ReadOnly = True
		txtStoreBillCity.Enabled = False
		txtStoreBillCity.ReadOnly = True
		txtStoreBillZip.Enabled = False
		txtStoreBillZip.ReadOnly = True
		txtStoreBillState.Enabled = False
		txtStoreBillState.ReadOnly = True
		'jp.E011.end
		
        dtStoreSoldDate.ShowCheckBox = True
		
		
		Select Case sOption
			Case General.modo.NewRecord
				'Defaults
				cbState.SelectedIndex = 0
				cbStoreStatus.SelectedIndex = 0
				
                dtStoreSoldDate.Enabled = False
                txtStoreNumber.Enabled = True
                set_store_info()
				
				
			Case General.modo.UpdateRecord
				
				set_combo(cbState, gStoreRecord.sStateId)
				set_store_info()
				'Este campo no se puede Actualizar
                txtStoreNumber.Enabled = False
                dtStoreSoldDate.Enabled = True
		End Select
		Exit Sub
		
ErrorHandler: 
		'Deshabilito boton por seguridad
		cmdOk.Enabled = False
		save_error(Me.Name, "init_vars")
		MsgBox("Unexpected error occurred while loading defaults." & vbCrLf & "Please check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Sub
	
	'Carga los componentes a partir de la Tienda
	'selecciona por el usuario para Actualizacion
	Private Sub set_store_info()
        'Dim n As Short
        'Dim nLength As Short
		
		txtStoreNumber.Text = gStoreRecord.sStoreNumber
		txtStoreName.Text = gStoreRecord.sStoreName
		txtStoreAddress.Text = gStoreRecord.sStoreAddress
		txtStoreCity.Text = gStoreRecord.sStoreCity
		txtStoreZip.Text = gStoreRecord.sStoreZip
		txtOccupants.Text = CStr(gStoreRecord.nStoreOccupants)
		
		'If Len(gStoreRecord.sStoreZip) = 0 Then
		'Nothing
		'Else
		'Completar el formato con espacios
		'    nLength = Len(gStoreRecord.sStoreZip)
		'    If nLength < 10 Then
		'        For n = 1 To 11 - nLength
		'           gStoreRecord.sStoreZip = gStoreRecord.sStoreZip + " "
		'        Next n
		'    End If
		'    mtxtStoreZip = gStoreRecord.sStoreZip
		'End If
		
		If Len(gStoreRecord.sStorePhone1) = 0 Then
            'Nothing
            mtxtStorePhone1.Text = ""
		Else
			mtxtStorePhone1.Text = gStoreRecord.sStorePhone1
		End If
		
		If Len(gStoreRecord.sStorePhone2) = 0 Then
            'Nothing
            mtxtStorePhone2.Text = ""
		Else
			mtxtStorePhone2.Text = gStoreRecord.sStorePhone2
		End If
		
		If Len(gStoreRecord.sStoreFax1) = 0 Then
            'Nothing
            mtxtStoreFax1.Text = ""
		Else
			mtxtStoreFax1.Text = gStoreRecord.sStoreFax1
		End If
		
		If Len(gStoreRecord.sStoreFax2) = 0 Then
            'Nothing
            mtxtStoreFax2.Text = ""
		Else
			mtxtStoreFax2.Text = gStoreRecord.sStoreFax2
		End If
		
		'txtStoreFax1 = gStoreRecord.sStoreFax1
		'txtStoreFax2 = gStoreRecord.sStoreFax2
		txtStoreContact.Text = gStoreRecord.sStoreContact
		txtStoreFolder.Text = gStoreRecord.sStoreFolder
		txtStoreCoCode.Text = gStoreRecord.sStoreCoCode
		
		If gStoreRecord.sStoreStatus = "A" Then
			cbStoreStatus.SelectedIndex = 0
		Else
			cbStoreStatus.SelectedIndex = 1
		End If
		'txtStorestatus = gStoreRecord.sStoreStatus
		
		txtBillingContact.Text = gStoreRecord.sStoreBillingContact
		
		txtBillingAccount.Text = gStoreRecord.sStoreBillingAccount
		
		txtLfGroup.Text = gStoreRecord.sLfGroup
		
		txtStoreMarket.Text = gStoreRecord.sStoreMarket
		
		txtStoreSold.Text = gStoreRecord.sStoreSold

        Try
            If Not (String.IsNullOrEmpty(gStoreRecord.dtStoreSoldDate.ToString)) Then
                dtStoreSoldDate.Value = gStoreRecord.dtStoreSoldDate
            End If
        Catch e As Exception

        End Try
        set_store_address_info(gStoreRecord.nStoreAddressSeq)



    End Sub
	Private Sub set_store_address_info(ByRef nStoreAddressSeq As Short)
        Dim cmd As SqlCommand = cn.CreateCommand()
		sStmt = "SELECT a.address, a.city, a.state_id, a.zip" & " FROM address_catalog a, store_address b " & " WHERE b.store_address_seq = " & Str(nStoreAddressSeq) & " AND b.address_seq = a.address_seq"
        cmd.CommandText = sStmt
        rs = getDataTable(sStmt) ' cmd.ExecuteReader()

        If rs.Rows.Count > 0 Then
            txtStoreBillAddress.Text = rs.Rows(0).Item("address")
            txtStoreBillCity.Text = rs.Rows(0).Item("city")
            txtStoreBillState.Text = rs.Rows(0).Item("state_id")
            txtStoreBillZip.Text = rs.Rows(0).Item("zip")
        Else
            txtStoreBillAddress.Text = ""
            txtStoreBillCity.Text = ""
            txtStoreBillState.Text = ""
            txtStoreBillZip.Text = ""
        End If

	End Sub
	
	Private Sub txtOccupants_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtOccupants.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		If (KeyAscii >= 65 And KeyAscii <= 90) Or (KeyAscii >= 97 And KeyAscii <= 122) Then
			KeyAscii = 0
		Else
			'Numeros, Backspace, Guion
			If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Then
				'Es numero
			Else
				KeyAscii = 0
			End If
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtStoreAddress_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtStoreAddress.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Se evitan las comillas doble y simple
		If KeyAscii = 34 Or KeyAscii = 39 Then
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtStoreCity_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtStoreCity.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Se evitan las comillas doble y simple
		If KeyAscii = 34 Or KeyAscii = 39 Then
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	
	
	Private Sub txtStoreCoCode_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtStoreCoCode.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Se evitan las comillas doble y simple
		If KeyAscii = 34 Or KeyAscii = 39 Then
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtStoreContact_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtStoreContact.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Se evitan las comillas doble y simple
		If KeyAscii = 34 Or KeyAscii = 39 Then
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtStoreFax1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtStoreFax1.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros:0-9 y Guion (-)
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 45 Then
			'Es numero
		Else
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	
	
	
	Private Sub txtStoreFax2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtStoreFax2.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros:0-9 y Guion (-)
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 45 Then
			'Es numero
		Else
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtStoreFolder_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtStoreFolder.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Se evitan las comillas doble y simple
		If KeyAscii = 34 Or KeyAscii = 39 Then
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtStoreName_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtStoreName.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If (KeyAscii >= 65 And KeyAscii <= 90) Or (KeyAscii >= 97 And KeyAscii <= 122) Then
			'OK. Mayusculas o Minusculas
		Else
			'Numeros, Backspace, Space, Guion
			If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 32 Or KeyAscii = 45 Then
				'Es numero
			Else
				KeyAscii = 0
			End If
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtStoreNumber_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtStoreNumber.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Permite ingresar caracteres  pero los hace mayusculas
		If (KeyAscii >= 65 And KeyAscii <= 90) Or (KeyAscii >= 97 And KeyAscii <= 122) Then
			'OK. Mayusculas o Minusculas
			KeyAscii = Asc(UCase(Chr(KeyAscii)))
		Else
			'Numeros, Backspace, Guion
			If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 45 Then
				'Es numero
			Else
				KeyAscii = 0
			End If
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtStorePhone1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtStorePhone1.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros:0-9 y Guion (-)
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 45 Then
			'Es numero
		Else
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtStorePhone2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtStorePhone2.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros:0-9 y Guion (-)
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 45 Then
			'Es numero
		Else
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	
	
	'TRUE if all fields have valid data
	Private Function val_fields(ByRef sOption As General.modo) As Boolean

		'Store Number
		If Len(Trim(txtStoreNumber.Text)) = 0 Or txtStoreNumber.Text = "" Then
			MsgBox("Store Number should not be null.", MsgBoxStyle.OKOnly, "GLM Warning")
			txtStoreNumber.Focus()
			val_fields = False
			Exit Function
		Else
			If (sOption = General.modo.NewRecord) And get_store Then
				MsgBox("This store already exists in Database.", MsgBoxStyle.Question + MsgBoxStyle.OKOnly, "GLM Message")
				txtStoreNumber.Focus()
				val_fields = False
				Exit Function
			End If
		End If
		
		'Address
		If Len(Trim(txtStoreAddress.Text)) = 0 Or txtStoreAddress.Text = "" Then
			MsgBox("Store Address should not be null.", MsgBoxStyle.OKOnly, "GLM Warning")
			txtStoreAddress.Focus()
			val_fields = False
			Exit Function
		End If
		
		'City
		If Len(Trim(txtStoreCity.Text)) = 0 Or txtStoreCity.Text = "" Then
			MsgBox("Store City should not be null.", MsgBoxStyle.OKOnly, "GLM Warning")
			txtStoreCity.Focus()
			val_fields = False
			Exit Function
		End If
		
		'Zip
		If Len(txtStoreZip.Text) = 0 Or txtStoreZip.Text = "" Then
			MsgBox("Store Zip Code should not be null.", MsgBoxStyle.OKOnly, "GLM Warning")
			txtStoreZip.Focus()
			val_fields = False
			Exit Function
		End If
		If Len(txtStoreZip.Text) > 0 And Len(txtStoreZip.Text) < 5 Then
			MsgBox("Zip code should be at least 5 digits.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			val_fields = False
			Exit Function
		End If
		'If Len(mtxtStoreZip.ClipText) > 5 Then
		'    For n = 1 To (Len(mtxtStoreZip.ClipText) - 5)
		'        If Asc(Mid(mtxtStoreZip.ClipText, n + 5, 1)) >= 48 _
		''        And Asc(Mid(mtxtStoreZip.ClipText, n + 5, 1)) <= 57 _
		''        Then
		'No problema
		'        Else
		'            MsgBox "Zip code should include just numbers.", _
		''                    vbExclamation + vbOKOnly, "GLM Warning"
		'            val_fields = False
		'            Exit Function
		'        End If
		'    Next n
		'End If
		
		'Phone
        'If getPhoneNumberLen(mtxtStorePhone1.Text) = 0 And getPhoneNumberLen(mtxtStorePhone2.Text) = 0 Then
        'MsgBox("At least one Phone Number should be entered.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
        'val_fields = False
        'Exit Function
        'End If

        If getPhoneNumberLen(mtxtStorePhone1.Text) >= 0 And getPhoneNumberLen(mtxtStorePhone1.Text) < 10 Then
            MsgBox("Phone1: Please enter 10 digit number including Area Code", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            mtxtStorePhone1.Focus()
            val_fields = False
            Exit Function
        End If

        'If getPhoneNumberLen(mtxtStorePhone2.Text) >= 0 And getPhoneNumberLen(mtxtStorePhone2.Text) < 10 Then
        ' MsgBox("Phone2: Please enter 10 digit number including Area Code", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
        'mtxtStorePhone2.Focus()
        'val_fields = False
        'Exit Function
        'End If

        'If getPhoneNumberLen(mtxtStoreFax1.Text) >= 0 And getPhoneNumberLen(mtxtStoreFax1.Text) < 10 Then
        ' MsgBox("Fax1: Please enter 10 digit number including Area Code", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
        'mtxtStoreFax1.Focus()
        'val_fields = False
        'Exit Function
        'End If

        'If getPhoneNumberLen(mtxtStoreFax2.Text) >= 0 And getPhoneNumberLen(mtxtStoreFax2.Text) < 10 Then
        ' MsgBox("Fax2: Please enter 10 digit number including Area Code", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
        'mtxtStoreFax2.Focus()
        'val_fields = False
        'Exit Function
        'End If



        'Occupants
        Try

            Dim nOccupants As Short
            If Not IsDBNull(txtOccupants.Text) And Len(txtOccupants.Text) > 0 Then
                nOccupants = Int(CDbl(txtOccupants.Text))
                If nOccupants < 0 Or nOccupants > 10000 Then
                    MsgBox("Invalid number, the number is either negative or too big.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                    txtOccupants.Focus()
                    val_fields = False
                    Exit Function
                End If

            End If

            'Billing info
            If Len(txtBillingContact.Text) > 60 Then
                MsgBox("Billing Contact length exceeded (> 60)", MsgBoxStyle.OkOnly, "GLM Warning")
                txtBillingContact.Focus()
                val_fields = False
                Exit Function
            End If

            If Len(txtBillingAccount.Text) > 30 Then
                MsgBox("Billing Account length exceeded (> 30)", MsgBoxStyle.OkOnly, "GLM Warning")
                txtBillingAccount.Focus()
                val_fields = False
                Exit Function
            End If


            val_fields = True 'Exito
            Exit Function

        Catch ex As Exception

            If Err.Number = 13 Then
                MsgBox("Invalid number.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                txtOccupants.Focus()
            Else

                MsgBox("Unexpected Error:" & ex.Message)
                write_msg(Me.Name, "val_fields")
            End If

            val_fields = False
            Exit Function

        End Try


    End Function
	'Ubica el combo apuntando al State
	Private Sub set_combo(ByRef cb As System.Windows.Forms.ComboBox, ByRef sState As String)
		Dim bOk As Boolean
		Dim i As Short
		
		bOk = False
		For i = 0 To cb.Items.Count - 1
			cb.SelectedIndex = i
			If cb.Text = sState Then
				bOk = True
				Exit For
			End If
		Next i
		
		If Not bOk Then
			cb.SelectedIndex = 0
		End If
		
	End Sub
	'Busca el nuevo numero de store Id
	Private Function get_Store_id(ByRef sCustId As String) As Short
		Dim nStoreId As Short
        Dim dt As DataTable
		On Error GoTo ErrorHandler
		
		sStmt = "SELECT MAX(store_id) FROM store " & " WHERE cust_id ='" & Trim(sCustId) & "'"
		
        dt = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows(0).Item(0)) Then
                nStoreId = 1
            Else
                nStoreId = dt.Rows(0).Item(0) + 1
            End If
        Else
            MsgBox("There was an error when accesing Store Table.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
        End If
		
		get_Store_id = nStoreId
		Exit Function
		
ErrorHandler: 
		get_Store_id = 0
		save_error("frmStoreEntry", "get_store_id")
		MsgBox("An error occurred while getting Store Id. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Function
	
	Private Sub txtStoreZip_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtStoreZip.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros:0-9 y Guion (-)
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 45 Then
			'Es numero
			If KeyAscii = 45 Then
				If InStr(1, txtStoreZip.Text, "-", CompareMethod.Text) = 0 Then
					'OK. Solo un guion se permite
				Else
					KeyAscii = 0
				End If
			End If
		Else
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	'Determina si una tienda existe o no
	Private Function get_store() As Boolean
		
		On Error GoTo ErrorHandler
        Dim dt As DataTable
		get_store = False
		
		sStmt = "SELECT * FROM store" & " WHERE cust_id ='" & Trim(txtCustId.Text) & "' " & " AND store_number='" & Trim(txtStoreNumber.Text) & "' "
        dt = getDataTable(sStmt)


        If dt.Rows.Count > 0 Then
            get_store = True
        End If


        Exit Function

ErrorHandler:
        get_store = False
        save_error("frmStoreEntry", "get_store")
        MsgBox("Failed to retrieve Store info." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
		
	End Function
	'Toda tienda nueva se incluye por defecto en el grupo ALL
	Private Function insert_store_group(ByRef sCustId As String, ByRef nStoreId As Short) As Boolean
		
		Dim nGroupSeq As Short
		Dim nCount As Short
        Dim cmd As SqlCommand = cn.CreateCommand
        Dim dt As DataTable
		On Error GoTo ErrorHandler
		'Obtengo el GroupSeq del grupo ALL
        sStmt = "SELECT group_seq FROM Groups " & " WHERE group_name = 'All' " & " AND cust_id = '" & Trim(sCustId) & "' "
        dt = getDataTable(sStmt)
        'cmd.CommandText = sStmt
        'rsLocal = cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If dt.Rows.Count > 0 Then
            nGroupSeq = dt.Rows(0).Item("group_seq")
        Else
            save_error(Me.Name, "insert_store_group: Group ALL not found in Groups , cust:" & sCustId)
            insert_store_group = False
            Exit Function
        End If



        'Chequeo si tienda esta en GroupStore
        sStmt = "SELECT group_seq FROM GroupStore " & " WHERE group_seq = " & Str(nGroupSeq) & " AND cust_id ='" & Trim(sCustId) & "' " & " AND store_id =" & Str(nStoreId)
        dt = getDataTable(sStmt)



        If dt.Rows.Count > 0 Then
            'Do nothing store is already part of GroupStore ALL
        Else
            sStmt = "INSERT INTO GroupStore (group_seq, " & "cust_id, store_id) VALUES " & "(" & Str(nGroupSeq) & "," & "'" & Trim(sCustId) & "'," & Str(nStoreId) & ")"
            cmLocal.CommandType = CommandType.Text
            cmLocal.CommandText = sStmt
            nCount = cmLocal.ExecuteNonQuery()
            
            If nCount > 0 Then
                'ok
            Else
                save_error(Me.Name, "insert_store_gooup:insert GroupStore failed")
                insert_store_group = False
                Exit Function
            End If
        End If

        insert_store_group = True
        Exit Function

ErrorHandler:
        save_error(Me.Name, "insert_store_group")
        MsgBox("An unexpected error has occurred, check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
	End Function
	'Copies the Physical Address fields onto Billing Address fields
	Private Function setBillingAsPhysicalAddress() As Boolean
        Dim cmd As SqlCommand = cn.CreateCommand()
		Dim nStoreAddressSeq As Short
		
		setBillingAsPhysicalAddress = False
		
		'Validation
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtStoreAddress.Text) Or Len(txtStoreAddress.Text) = 0 Then
			MsgBox("Missing Store Address", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Error")
			txtStoreAddress.Focus()
			Exit Function
		End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtStoreCity.Text) Or Len(txtStoreCity.Text) = 0 Then
			MsgBox("Missing Store City", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Error")
			txtStoreCity.Focus()
			Exit Function
		End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtStoreZip.Text) Or Len(txtStoreZip.Text) = 0 Then
			MsgBox("Missing Store Zip", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Error")
			txtStoreZip.Focus()
			Exit Function
		End If
		
		
		'Check that address exists in address catalog
		sStmt = "SELECT a.store_address_seq , a.address_seq," & "    b.Address , b.city, b.state_id, b.zip" & " FROM store_address a, address_catalog b " & " WHERE b.context_table = '" & ADDRESS_CATALOG_CONTEXT_STORE & "' " & " AND a.cust_id = '" & Me.txtCustId.Text & "'" & " AND a.store_id = " & Str(gStoreRecord.nStoreId) & " AND b.address = '" & Trim(quotation_mask((txtStoreAddress.Text))) & "' " & " AND b.city = '" & Trim(quotation_mask((txtStoreCity.Text))) & "' " & " AND b.state_id = '" & Trim(quotation_mask((Me.cbState.Text))) & "' " & " AND b.zip = '" & Trim(quotation_mask((txtStoreZip.Text))) & "' "
        'cmd.CommandText = sStmt
		
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.Rows.Count > 0 Then
            txtStoreBillAddress.Text = txtStoreAddress.Text
            txtStoreBillCity.Text = txtStoreCity.Text
            txtStoreBillState.Text = cbState.Text
            txtStoreBillZip.Text = txtStoreZip.Text

            gStoreRecord.nStoreAddressSeq = rs.Rows(0).Item("store_address_seq")

            setBillingAsPhysicalAddress = True
            Exit Function
        Else
            'If not found insert Address in Catalog
            Select Case General.gbMode
                Case General.modo.NewRecord

                    MsgBox("Please save current record before attempting this command.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                    Exit Function

                Case General.modo.UpdateRecord
                    nStoreAddressSeq = insertAddressCatalog((txtCustId.Text), gStoreRecord.nStoreId, (txtStoreAddress.Text), (txtStoreCity.Text), (Me.cbState.Text), (txtStoreZip.Text))

                    If nStoreAddressSeq > 0 Then
                        txtStoreBillAddress.Text = txtStoreAddress.Text
                        txtStoreBillCity.Text = txtStoreCity.Text
                        txtStoreBillState.Text = cbState.Text
                        txtStoreBillZip.Text = txtStoreZip.Text

                        gStoreRecord.nStoreAddressSeq = nStoreAddressSeq

                        setBillingAsPhysicalAddress = True
                        Exit Function
                    End If
            End Select
        End If
        'Else
        '      MsgBox("Failed to access Address Catalog table, check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
        '      Exit Function


	End Function
End Class