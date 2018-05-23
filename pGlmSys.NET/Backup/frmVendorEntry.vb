Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmVendorEntry
	Inherits System.Windows.Forms.Form
	Private asQBName(101) As String
    Private rsLocal As DataTable
    Private cmLocal As SqlCommand
	
	'UPGRADE_WARNING: Event cbQBGroupDesc.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbQBGroupDesc_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbQBGroupDesc.SelectedIndexChanged
		cbQBGroupId.SelectedIndex = cbQBGroupDesc.SelectedIndex
		txtQBName.Text = asQBName(cbQBGroupDesc.SelectedIndex)
	End Sub
	
	Private Sub cbQBName_Change()
		'cbQBName.List(cbQBGroupDesc.ListIndex) = cbQBName.Text
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		If General.gbVendorMode <> General.modo.SavedRecord Then
			If (MsgBox("Data changes will be lost." & vbCrLf & "Do you want to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "GLM Message") = MsgBoxResult.Yes) Then
				'Guardo los datos
				Me.Close()
			End If
		Else
			'Registro ya fue guardado =SavedREcord
			Me.Close()
		End If
		
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		save_vendor()
		
	End Sub
	'Inserta/actualiza datos en Base
	Private Sub save_vendor()
		Dim i As Short
		Dim sName As String
		Dim nCount As Short
		Dim sVendPhone1 As Object
		Dim sVendPhone2 As String
		Dim sVendFax1 As Object
		Dim sVendFax2 As String
		Dim sVendPayPhone1 As String
		
        Try

            If Not val_fields() Then
                Exit Sub
            End If

            'Checking mask

            If Len(mtxtVendPhone1.Text) = 0 Then
                sVendPhone1 = ""
            Else
                sVendPhone1 = mtxtVendPhone1.Text
            End If


            If Len(mtxtVendPhone2.Text) = 0 Then
                sVendPhone2 = ""
            Else
                sVendPhone2 = mtxtVendPhone2.Text
            End If


            If Len(mtxtVendFax1.Text) = 0 Then
                sVendFax1 = ""
            Else
                sVendFax1 = mtxtVendFax1.Text
            End If

            If Len(mtxtVendFax2.Text) = 0 Then
                sVendFax2 = ""
            Else
                sVendFax2 = mtxtVendFax2.Text
            End If

            If Len(mtxtVendPayPhone1.Text) = 0 Then
                sVendPayPhone1 = ""
            Else
                sVendPayPhone1 = mtxtVendPayPhone1.Text
            End If

            'INSERT/UPDATE
            Select Case General.gbVendorMode
                Case General.modo.NewRecord
                    gVBranchRecord.nVendSeq = get_vend_seq()
                    For i = 0 To 100
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(asQBName(i)) Then
                            asQBName(i) = ""
                        End If
                    Next i

                    sStmt = "INSERT INTO vbranch (vend_id," & "vend_seq, state_id, vend_name, vend_repre, " & "vend_phone1, vend_phone2, vend_fax1, vend_fax2," & "vend_address, vend_city, vend_zip, vend_area," & "vend_pay_address, vend_pay_city," & "vend_pay_zip, vend_pay_phone1, vend_pay_state)" & " VALUES (" & Str(gVendorSearch.nVendId) & ", " & Str(gVBranchRecord.nVendSeq) & ", " & "'" & cbState.Text & "', " & "'" & Trim(gVendorSearch.sVendName) & "'," & "'" & quotation_mask(txtVendRepre.Text) & "'," & "'" & Trim(sVendPhone1) & "','" & Trim(sVendPhone2) & "'," & "'" & Trim(sVendFax1) & "','" & Trim(sVendFax2) & "'," & "'" & quotation_mask(txtVendAddress.Text) & "'," & "'" & quotation_mask(txtVendCity.Text) & "'," & "'" & Trim(txtVendZip.Text) & "','" & Trim(txtVendArea.Text) & "'," & "'" & quotation_mask(txtVendPayAddress.Text) & "'," & "'" & quotation_mask(txtVendPayCity.Text) & "'," & "'" & Trim(txtVendPayZip.Text) & "','" & Trim(sVendPayPhone1) & "'," & "'" & Trim(cbVendPayState.Text) & "')"

                    'MsgBox sStmt
                    cmLocal = cn.CreateCommand
                    With cmLocal

                        .CommandType = CommandType.Text
                        .CommandText = sStmt
                        nCount = .ExecuteNonQuery()
                    End With
                    If nCount = 1 Then
                        'Registro salvado en BD.
                        'Refrescar datagrid con nuevos datos
                        General.gbVendorMode = General.modo.SavedRecord
                    Else
                        MsgBox("Failed to insert Vendor Branch.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
                        Exit Sub
                    End If

                    'Insercion de QBooks
                    For i = 0 To cbQBGroupId.Items.Count - 1
                        cbQBGroupId.SelectedIndex = i
                        If Len(asQBName(i)) > 0 Then

                            sStmt = "INSERT INTO qb_vendor_vbranch " & "(qb_group_id, name, vend_seq) VALUES " & " ('" & Trim(cbQBGroupId.Text) & "'," & "'" & Trim(quotation_mask(asQBName(i))) & "'," & Str(gVBranchRecord.nVendSeq) & ")"

                            'MsgBox sStmt
                            cmLocal = cn.CreateCommand
                            With cmLocal
                                .CommandType = CommandType.Text
                                .CommandText = sStmt
                                nCount = .ExecuteNonQuery()
                            End With
                            If nCount = 1 Then
                                'OK
                            Else
                                MsgBox("Failed to insert QBooks Vendor.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
                                Exit Sub
                            End If
                        End If

                    Next i
                    MsgBox("Vendor was successfully created!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")


                Case General.modo.UpdateRecord

                    sStmt = "UPDATE vbranch SET " & "vend_area = '" & Trim(txtVendArea.Text) & "'," & "state_id = '" & cbState.Text & "'," & "vend_address = '" & quotation_mask(txtVendAddress.Text) & "'," & "vend_repre = '" & quotation_mask(txtVendRepre.Text) & "'," & "vend_city = '" & quotation_mask(txtVendCity.Text) & "'," & "vend_zip = '" & Trim(txtVendZip.Text) & "'," & "vend_phone1 = '" & Trim(sVendPhone1) & "'," & "vend_phone2 = '" & Trim(sVendPhone2) & "'," & "vend_fax1 ='" & Trim(sVendFax1) & "'," & "vend_fax2 ='" & Trim(sVendFax2) & "'," & "vend_pay_address='" & quotation_mask(txtVendPayAddress.Text) & "'," & "vend_pay_city ='" & quotation_mask(txtVendPayCity.Text) & "'," & "vend_pay_zip='" & Trim(txtVendPayZip.Text) & "'," & "vend_pay_phone1='" & Trim(sVendPayPhone1) & "'," & "vend_pay_state='" & Trim(cbVendPayState.Text) & "' " & " WHERE vend_id =" & Str(gVendorSearch.nVendId) & " AND vend_seq = " & Str(gVBranchRecord.nVendSeq)

                    'MsgBox sStmt
                    cmLocal = cn.CreateCommand
                    With cmLocal

                        .CommandType = CommandType.Text
                        .CommandText = sStmt
                        nCount = .ExecuteNonQuery()
                    End With

                    If nCount >= 1 Then
                        'Registro salvado en BD.
                        'Refrescar datagrid con nuevos datos
                        General.gbVendorMode = General.modo.SavedRecord
                    End If

                    'Actualizacion de QBooks
                    For i = 0 To cbQBGroupId.Items.Count - 1
                        sName = ""
                        cbQBGroupId.SelectedIndex = i
                        If Len(asQBName(i)) > 0 Then
                            'Verificar cambio
                            sName = get_qb_vendor(cbQBGroupId.Text, gVBranchRecord.nVendSeq)

                            If sName <> asQBName(i) Then
                                'DELETE
                                If Len(sName) > 0 Then
                                    sStmt = "DELETE FROM qb_vendor_vbranch " & "WHERE qb_group_id ='" & Trim(cbQBGroupId.Text) & "'" & " AND vend_seq =" & Str(gVBranchRecord.nVendSeq)
                                    cmLocal = cn.CreateCommand
                                    With cmLocal
                                        .CommandType = CommandType.Text
                                        .CommandText = sStmt
                                        nCount = .ExecuteNonQuery()
                                    End With
                                    If nCount = 1 Then
                                        'OK
                                    Else
                                        MsgBox("Failed to update QBooks Vendor.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
                                        Exit Sub
                                    End If
                                End If

                                'INSERT
                                sStmt = "INSERT INTO qb_vendor_vbranch " & "(qb_group_id, name, vend_seq) VALUES " & " ('" & Trim(cbQBGroupId.Text) & "'," & "'" & Trim(quotation_mask(asQBName(i))) & "'," & Str(gVBranchRecord.nVendSeq) & ")"

                                'MsgBox sStmt
                                cmLocal = cn.CreateCommand
                                With cmLocal
                                    .CommandType = CommandType.Text
                                    .CommandText = sStmt
                                    nCount = .ExecuteNonQuery()
                                End With
                                If nCount = 1 Then
                                    'OK
                                Else
                                    MsgBox("Failed to insert QBooks Vendor.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
                                    Exit Sub
                                End If
                            End If 'sName
                        End If 'len
                    Next i

                    MsgBox("Vendor data was successfully updated!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")

            End Select
            Me.Close()
            Exit Sub

        Catch ex As Exception
            save_error(Me.Name, "save_vendor")
            MsgBox("An unexpected error has occurred. Please check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
        End Try
    End Sub
	
	'Valida los datos en la forma
	Private Function val_fields() As Boolean
		Dim bQBname As Boolean
		Dim i As Short
		
		On Error GoTo ErrorHandler
		
		'Vendor Area
        If Len(txtVendArea.Text) = 0 Or IsDBNull(txtVendArea.Text) Then
            MsgBox("Vendor Area should not be null.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
            val_fields = False
            Exit Function
        Else
            If General.gbVendorMode = General.modo.NewRecord Then
                'Verificar que esta area no sea repetida
                sStmt = "SELECT count(*) FROM vbranch " & "WHERE vend_id=" & Str(gVendorSearch.nVendId) & " AND vend_area='" & Trim(txtVendArea.Text) & "' "

                rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                If rsLocal.Rows(0).Item(0) > 0 Then
                    MsgBox("There is a Vendor previously created," & "with that area.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
                    val_fields = False
                    Exit Function
                End If
            End If
        End If
		
		'Address
		If Len(txtVendAddress.Text) = 0 Then
			MsgBox("Vendor Address should not be null.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
			txtVendAddress.Focus()
			val_fields = False
			Exit Function
		End If
		
		'City
		If Len(txtVendCity.Text) = 0 Then
			MsgBox("Vendor City should not be null.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
			txtVendCity.Focus()
			val_fields = False
			Exit Function
		End If
		
		'Zip
		If Len(txtVendZip.Text) = 0 Or txtVendZip.Text = "" Then
			MsgBox("Vendor Zip should not be null.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
			txtVendZip.Focus()
			val_fields = False
			Exit Function
		End If
		If Len(txtVendZip.Text) > 0 And Len(txtVendZip.Text) < 5 Then
			MsgBox("Zip code should be at least 5 digits.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			val_fields = False
			Exit Function
		End If
		
		'Phone
        'getPhoneNumberLen()
        If getPhoneNumberLen(mtxtVendPhone1.Text) <> 10 Then
            MsgBox("At least one Phone Number should be entered.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            mtxtVendPhone1.Focus()
            val_fields = False
            Exit Function
        End If
		
		
        If getPhoneNumberLen(mtxtVendPhone1.Text) <> 10 Then
            MsgBox("Phone1: Please enter 10 digit number including Area Code", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            mtxtVendPhone1.Focus()
            val_fields = False
            Exit Function
        End If
        Dim alen As Integer = getPhoneNumberLen(mtxtVendPhone2.Text)
        alen = getPhoneNumberLen(mtxtVendPhone1.Text)
        If getPhoneNumberLen(mtxtVendPhone2.Text) <> 10 Then
            MsgBox("Phone2: Please enter 10 digit number including Area Code", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            mtxtVendPhone2.Focus()
            val_fields = False
            Exit Function
        End If
		
        If getPhoneNumberLen(mtxtVendFax1.Text) <> 10 Then
            MsgBox("Fax1: Please enter 10 digit number including Area Code", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            mtxtVendFax1.Focus()
            val_fields = False
            Exit Function
        End If
		
        If getPhoneNumberLen(mtxtVendFax2.Text) <> 10 Then
            MsgBox("Fax2: Please enter 10 digit number including Area Code", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            mtxtVendFax2.Focus()
            val_fields = False
            Exit Function
        End If
		
		'Payment Info
		If Len(txtVendPayAddress.Text) = 0 Then
			MsgBox("Payment Address should not be null.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
			txtVendPayAddress.Focus()
			val_fields = False
			Exit Function
		End If
		
		'Payment City
		If Len(txtVendPayCity.Text) = 0 Then
			MsgBox("Payment City should not be null.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
			txtVendPayCity.Focus()
			val_fields = False
			Exit Function
		End If
		
		'Payment Zip
		If Len(txtVendPayZip.Text) = 0 Or txtVendPayZip.Text = "" Then
			MsgBox("Payment Zip should not be null.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
			txtVendPayZip.Focus()
			val_fields = False
			Exit Function
		End If
		If Len(txtVendPayZip.Text) > 0 And Len(txtVendPayZip.Text) < 5 Then
			MsgBox("Payment Zip code should be at least 5 digits.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtVendPayZip.Focus()
			val_fields = False
			Exit Function
		End If
		
		'Payment Phone
        If getPhoneNumberLen(mtxtVendPayPhone1.Text) <> 10 Then
            MsgBox("Payment Phone: Please enter 10 digit number including Area Code", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            mtxtVendPayPhone1.Focus()
            val_fields = False
            Exit Function
        End If
		
		If cbVendPayState.SelectedIndex < 0 Then
			MsgBox("Please choose an State for Payment Info.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			cbVendPayState.Focus()
			val_fields = False
			Exit Function
		End If
		
		'QBName
		'If Len(asQBName(0)) = 0 And Len(asQBName(1)) = 0 Then
		bQBname = False
		For i = 0 To 100
			If Len(asQBName(i)) > 0 Then
				bQBname = True
			End If
		Next i
		If bQBname = False Then
			MsgBox("You must set the corresponding Vendor Name for QuickBooks," & vbCrLf & "in any group.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
			If txtQBName.Enabled Then
				txtQBName.Focus()
			End If
			val_fields = False
			Exit Function
		End If
		
		val_fields = True
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "val_fields")
		MsgBox("Unexpected error found while validating record.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Function
	'Obtiene un nuevo numero para Vendor Seq
	Private Function get_vend_seq() As Short
		Dim nVendSeq As Short
		
		sStmt = "SELECT MAX(vend_seq) FROM vbranch"
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsLocal.Rows.Count > 0 Then
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item(0)) Then
                nVendSeq = 1
            Else
                nVendSeq = rsLocal.Rows(0).Item(0) + 1
            End If
        Else
            MsgBox("Unable to get Sequence Number for New Branch.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
            nVendSeq = 0
        End If
		
		get_vend_seq = nVendSeq
	End Function
	
	Private Sub cmdSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSearch.Click
		'Cargo el parametro para mostrar ayuda: CS,TR,...
		If cbQBGroupId.SelectedIndex >= 0 Then
			gQBSearch.sParam = cbQBGroupId.Text
			VB6.ShowForm(frmQBSearch, VB6.FormShowConstants.Modal, Me)
			txtQBName.Text = gQBSearch.qb_name
			'cbQBName = gQBSearch.qb_name
		End If
		
	End Sub
	
	Private Sub frmVendorEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		set_limit()
		init_vars(General.gbVendorMode)
	End Sub
	'Valores maximos en textfields
	Private Sub set_limit()
		Dim nLength As Short
		
		On Error GoTo ErrorHandler
		
		'Vendor Area
		nLength = get_column("vbranch", "vend_area")
		If nLength > 0 Then
			'UPGRADE_WARNING: TextBox property txtVendArea.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			txtVendArea.Maxlength = nLength
		Else
			'UPGRADE_WARNING: TextBox property txtVendArea.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			txtVendArea.Maxlength = 40
		End If
		
		'Vendor Representative
		nLength = get_column("vbranch", "vend_repre")
		If nLength > 0 Then
			'UPGRADE_WARNING: TextBox property txtVendRepre.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			txtVendRepre.Maxlength = nLength
		Else
			'UPGRADE_WARNING: TextBox property txtVendRepre.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			txtVendRepre.Maxlength = 20
		End If
		
		'Vendor Address
		nLength = get_column("vbranch", "vend_address")
		If nLength > 0 Then
			'UPGRADE_WARNING: TextBox property txtVendAddress.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			txtVendAddress.Maxlength = nLength
		Else
			'UPGRADE_WARNING: TextBox property txtVendAddress.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			txtVendAddress.Maxlength = 80
		End If
		
		'Vendor City
		nLength = get_column("vbranch", "vend_city")
		If nLength > 0 Then
			'UPGRADE_WARNING: TextBox property txtVendCity.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			txtVendCity.Maxlength = nLength
		Else
			'UPGRADE_WARNING: TextBox property txtVendCity.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			txtVendCity.Maxlength = 30
		End If
		
		'Pay Address
		nLength = get_column("vbranch", "vend_pay_address")
		If nLength > 0 Then
			'UPGRADE_WARNING: TextBox property txtVendPayAddress.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			txtVendPayAddress.Maxlength = nLength
		Else
			'UPGRADE_WARNING: TextBox property txtVendPayAddress.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			txtVendPayAddress.Maxlength = 80
		End If
		
		'Pay City
		nLength = get_column("vbranch", "vend_pay_city")
		If nLength > 0 Then
			'UPGRADE_WARNING: TextBox property txtVendPayCity.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			txtVendPayCity.Maxlength = nLength
		Else
			'UPGRADE_WARNING: TextBox property txtVendPayCity.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			txtVendPayCity.Maxlength = 30
		End If
		
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "set_limit")
		MsgBox("An unexpected error has occurred. Please check log file for details", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
	End Sub
	
	Private Sub init_vars(ByRef bFlag As General.modo)
		Dim i As Short
		
		On Error GoTo ErrorHandler
		

        cmLocal = cn.CreateCommand()
		
		'cmdSearch.Picture = ImageList1.ListImages(1)
		txtVendName.Text = gVendorSearch.sVendName
		'Cargo combo de State
		sStmt = "SELECT state_id FROM state"
		load_cb_query(cbState, sStmt, 1)
		
		'Cargo combo de Companias de Quick Books Pro
		sStmt = "SELECT qb_group_desc, qb_group_id " & " FROM qb_group  ORDER BY qb_group_id"
		load_cb_query(cbQBGroupDesc, sStmt, 1)
		
		
		sStmt = "SELECT qb_group_id " & " FROM qb_group  ORDER BY qb_group_id"
		load_cb_query(cbQBGroupId, sStmt, 1)
		
		enable_QB(False)
		
		
		
		'Combo Payment State
		sStmt = "SELECT state_id FROM state"
		load_cb_query(cbVendPayState, sStmt, 1)
		
		'Defaults
		Select Case bFlag
            Case General.modo.NewRecord

                clearFields()
                For i = 0 To 100
                    asQBName(i) = ""
                Next i

                set_cb(cbState, gVendorSearch.sStateId)
                If cbState.SelectedIndex < 0 Then
                    cbState.SelectedIndex = 0
                End If

                cbVendPayState.SelectedIndex = cbState.SelectedIndex

                cbQBGroupDesc.SelectedIndex = 0
                'Allow ANY User to set initial QB Settings
                enable_QB(True)
            Case General.modo.UpdateRecord
				
				set_vendor_info()
				'Solo administradores pueden modificar
				If gsUserType = CStr(General.UserType.Administrator) Then
					enable_QB(True)
				End If
				
		End Select
		
		'Espero a que asQBname se haya cargado
		'cbQBGroupDesc.ListIndex = 0
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "init_vars")
		MsgBox("Error found while loading Vendor info.Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Sub
	Private Sub enable_QB(ByRef bOption As Boolean)
		frQuickBooks.Enabled = bOption
		cbQBGroupDesc.Enabled = bOption
		txtQBName.Enabled = bOption
		
	End Sub
    Private Sub clearFields()
        cbState.SelectedIndex = 0
        txtVendArea.Text = ""
        txtVendRepre.Text = ""
        txtVendAddress.Text = ""
        txtVendCity.Text = ""
        txtVendZip.Text = ""
        txtVendPayAddress.Text = ""
        txtVendPayCity.Text = ""
        txtVendPayZip.Text = ""
        'asQBName(0) = gVBranchRecord.sQBNameCS
        'asQBName(1) = gVBranchRecord.sQBNameTR

        'Esto es solo para actualizacion
        'cbQBGroupDesc.ListIndex = 0
        cbQBGroupId.SelectedIndex = 0
        
        cbQBGroupDesc.SelectedIndex = 0

        'Phone1

        mtxtVendPhone1.Text = ""

        mtxtVendPhone2.Text = ""

        mtxtVendFax1.Text = ""

        mtxtVendFax2.Text = ""

        mtxtVendPayPhone1.Text = ""
        cbVendPayState.SelectedIndex = 0
        'set_cb(cbVendPayState, gVBranchRecord.sVendPayState)
    End Sub
	Private Sub set_vendor_info()
		Dim i As Short
		Dim nFound As Short
		
		set_cb(cbState, gVBranchRecord.sStateId)
		txtVendArea.Text = gVBranchRecord.sVendArea
		txtVendRepre.Text = gVBranchRecord.sVendRepre
		txtVendAddress.Text = gVBranchRecord.sVendAddress
		txtVendCity.Text = gVBranchRecord.sVendCity
		txtVendZip.Text = gVBranchRecord.sVendZip
		txtVendPayAddress.Text = gVBranchRecord.sVendPayAddress
		txtVendPayCity.Text = gVBranchRecord.sVendPayCity
		txtVendPayZip.Text = gVBranchRecord.sVendPayZip
		'asQBName(0) = gVBranchRecord.sQBNameCS
		'asQBName(1) = gVBranchRecord.sQBNameTR
		
		'Esto es solo para actualizacion
		'cbQBGroupDesc.ListIndex = 0
		nFound = 0
		For i = 0 To cbQBGroupDesc.Items.Count - 1
			cbQBGroupId.SelectedIndex = i
			asQBName(i) = get_qb_vendor(cbQBGroupId.Text, gVBranchRecord.nVendSeq)
			If Len(asQBName(i)) > 0 And nFound = 0 Then
				nFound = i
			End If
		Next i
		cbQBGroupDesc.SelectedIndex = nFound
		
		'Phone1
		If Len(gVBranchRecord.sVendPhone1) = 0 Then
			'Nothing
		Else
			mtxtVendPhone1.Text = gVBranchRecord.sVendPhone1
		End If
		
		If Len(gVBranchRecord.sVendPhone2) = 0 Then
			'Nothing
		Else
			mtxtVendPhone2.Text = gVBranchRecord.sVendPhone2
		End If
		'Fax1
		If Len(gVBranchRecord.sVendFax1) = 0 Then
			'Nothing
		Else
			mtxtVendFax1.Text = gVBranchRecord.sVendFax1
		End If
		
		If Len(gVBranchRecord.sVendFax2) = 0 Then
			'Nothing
		Else
			mtxtVendFax2.Text = gVBranchRecord.sVendFax2
		End If
		
		If Len(gVBranchRecord.sVendPayPhone1) = 0 Then
			'Nothing
		Else
			mtxtVendPayPhone1.Text = gVBranchRecord.sVendPayPhone1
		End If
		
		set_cb(cbVendPayState, gVBranchRecord.sVendPayState)
	End Sub
	'Retorna el nombre del vendor en la table de QB (qb_vendor)
	Private Function get_qb_vendor(ByRef sGroupId As String, ByRef nVendSeq As Short) As String
		Dim sVendor As String
		
		On Error GoTo ErrorHandler
		
		sVendor = ""
		sStmt = "SELECT name FROM qb_vendor_vbranch " & " WHERE qb_group_id ='" & Trim(sGroupId) & "' " & " AND vend_seq =" & Str(nVendSeq)
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count > 0 Then
            sVendor = rsLocal.Rows(0).Item("name")
        End If

        get_qb_vendor = sVendor

        Exit Function

ErrorHandler:
        get_qb_vendor = ""
        save_error(Me.Name, "get_qb_vendor")
        MsgBox("An error occurred while returning QB Vendor info." & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
	End Function
	'UPGRADE_WARNING: Event txtQBName.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtQBName_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtQBName.TextChanged
		asQBName(cbQBGroupDesc.SelectedIndex) = txtQBName.Text
	End Sub
	
	Private Sub txtQBName_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtQBName.KeyPress
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
	
	
	Private Sub txtVendAddress_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtVendAddress.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Se evitan las comillas doble y simple
		'If KeyAscii = 34 Or KeyAscii = 39 Then
		'    KeyAscii = 0
		'End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtVendArea_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtVendArea.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Mayusculas, Minusculas, -,blanco, backspcae
		If KeyAscii >= 65 And KeyAscii <= 90 Or KeyAscii = 45 Or KeyAscii = 32 Or KeyAscii = 8 Then
			'Aceptado
		Else
			'Cambio de minusculas a mayusculas
			If (KeyAscii >= 95 And KeyAscii <= 122) Then
				KeyAscii = Asc(UCase(Chr(KeyAscii)))
			Else
				KeyAscii = 0
			End If
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtVendCity_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtVendCity.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Se evitan las comillas doble y simple
		'If KeyAscii = 34 Or KeyAscii = 39 Then
		'    KeyAscii = 0
		'End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtVendFax1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtVendFax1.KeyPress
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
	
	Private Sub txtVendFax2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtVendFax2.KeyPress
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
	
	
	Private Sub txtVendPayAddress_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtVendPayAddress.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Se evitan las comillas doble y simple
		'If KeyAscii = 34 Or KeyAscii = 39 Then
		'    KeyAscii = 0
		'End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	
	Private Sub txtVendPayCity_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtVendPayCity.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Se evitan las comillas doble y simple
		'If KeyAscii = 34 Or KeyAscii = 39 Then
		'    KeyAscii = 0
		'End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtVendPayZip_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtVendPayZip.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros:0-9 y Guion (-)
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 45 Then
			'Es numero
			If KeyAscii = 45 Then
				If InStr(1, txtVendPayZip.Text, "-", CompareMethod.Text) = 0 Then
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
	
	Private Sub txtVendPhone1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtVendPhone1.KeyPress
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
	
	Private Sub txtVendPhone2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtVendPhone2.KeyPress
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
	
	Private Sub txtVendRepre_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtVendRepre.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		'Se evitan las comillas doble y simple
		'If KeyAscii = 34 Or KeyAscii = 39 Then
		'    KeyAscii = 0
		'End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtVendZip_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtVendZip.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros:0-9 y Guion (-)
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 45 Then
			'Es numero
			If KeyAscii = 45 Then
				If InStr(1, txtVendZip.Text, "-", CompareMethod.Text) = 0 Then
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
End Class