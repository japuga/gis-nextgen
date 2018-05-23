Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmStoreEqptEntry
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private rsAccountEqpt As DataTable
    Private cmLocal As SqlCommand
	
	
	
	'UPGRADE_WARNING: Event cbEqptDesc.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbEqptDesc_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbEqptDesc.SelectedIndexChanged
		
		get_EqptSize(VB6.GetItemData(cbEqptDesc, cbEqptDesc.SelectedIndex))
		If gStoreEqptRecord.nEqptId = VB6.GetItemData(cbEqptDesc, cbEqptDesc.SelectedIndex) Then
			txtEqptDesc.Text = Trim(gStoreEqptRecord.sEqptDesc)
			txtEqptSizeCapacity.Text = CStr(gStoreEqptRecord.nEqptSizeCapacity)
		Else
			txtEqptDesc.Text = Trim(cbEqptDesc.Text)
			txtEqptSizeCapacity.Text = txtEqptSize.Text
		End If
	End Sub
	'Obtiene la Capacidad
	Private Sub get_EqptSize(ByRef nEqptId As Short)
		Dim nEqptSize As Double
		
		sStmt = "SELECT eqpt_size FROM equipment " & " WHERE eqpt_id =" & Str(nEqptId)
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count > 0 Then
            nEqptSize = rsLocal.Rows(0).Item("eqpt_size")
            txtEqptSize.Text = CStr(nEqptSize)

        End If

		
	End Sub
	'UPGRADE_WARNING: Event cbEqptTempDesc.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbEqptTempDesc_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbEqptTempDesc.SelectedIndexChanged
		cbEqptTemp.SelectedIndex = cbEqptTempDesc.SelectedIndex
	End Sub
	
	'UPGRADE_WARNING: Event cbLoadDesc.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbLoadDesc_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbLoadDesc.SelectedIndexChanged
		cbLoadId.SelectedIndex = cbLoadDesc.SelectedIndex
	End Sub
	
	'UPGRADE_WARNING: Event ckbAccount.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub ckbAccount_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ckbAccount.CheckStateChanged
		Select Case ckbAccount.CheckState
			Case System.Windows.Forms.CheckState.Checked
                set_dgAccountEqptData(General.gbStoreEqptMode, General.EqptStatus.Inactive)
			Case System.Windows.Forms.CheckState.Unchecked
                set_dgAccountEqptData(General.gbStoreEqptMode, General.EqptStatus.Active)
				
		End Select
	End Sub
	
	
	Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click
		General.gbAccountEqptMode = General.modo.NewRecord
		set_accountEqpt((General.modo.NewRecord))
		VB6.ShowForm(frmAccount, VB6.FormShowConstants.Modal, Me)
		
		Select Case ckbAccount.CheckState
			Case System.Windows.Forms.CheckState.Checked
                set_dgAccountEqptData((General.modo.SavedRecord), General.EqptStatus.Inactive)
			Case System.Windows.Forms.CheckState.Unchecked
                set_dgAccountEqptData((General.modo.SavedRecord), General.EqptStatus.Active)
			Case Else
                set_dgAccountEqptData((General.modo.SavedRecord), General.EqptStatus.Inactive)
		End Select
	End Sub
	'Esto se debe asignar tanto para Insert como para Update de Account
	Private Sub set_accountEqpt(ByRef bFlag As General.modo)
		gAccountEqptRecord.sCustId = gStoreEqptRecord.sCustId
		gAccountEqptRecord.nStoreId = gStoreEqptRecord.nStoreId
		gAccountEqptRecord.nEqptSeq = gStoreEqptRecord.nEqptSeq
		
		If bFlag = General.modo.UpdateRecord Then
            gAccountEqptRecord.sAccountNo = rsAccountEqpt.Rows(0).Item("Account")
            gAccountEqptRecord.sAccountMask = rsAccountEqpt.Rows(0).Item("Account No")
            gAccountEqptRecord.sAccountStatus = rsAccountEqpt.Rows(0).Item("Status")
            gAccountEqptRecord.nVendSeq = rsAccountEqpt.Rows(0).Item("vend_seq")
            gAccountEqptRecord.sVendor = rsAccountEqpt.Rows(0).Item("Vendor")
		End If
	End Sub
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		Dim nCount As Short
		If Not val_fields(General.gbStoreEqptMode) Then
			Exit Sub
		End If
		
		Select Case General.gbStoreEqptMode
			Case General.modo.NewRecord
				gStoreEqptRecord.nEqptSeq = get_eqptSeq
				If gStoreEqptRecord.nEqptSeq = -1 Then
					Exit Sub
				End If
				
				Select Case cbStatus.Text
					Case "Active"
						gStoreEqptRecord.sEqptStatus = "A"
					Case "Inactive"
						gStoreEqptRecord.sEqptStatus = "I"
				End Select
				
				sStmt = "INSERT INTO storeEqpt (cust_id, " & "store_id, eqpt_seq, eqpt_id," & "load_id, eqpt_status, eqpt_desc, " & "content_id, eqpt_qty, eqpt_temp," & "eqpt_size_capacity, eqpt_actual_qty) " & " VALUES ('" & Trim(gStoreEqptRecord.sCustId) & "'," & Str(gStoreEqptRecord.nStoreId) & "," & Str(gStoreEqptRecord.nEqptSeq) & "," & Str(VB6.GetItemData(cbEqptDesc, cbEqptDesc.SelectedIndex)) & "," & "'" & Trim(cbLoadId.Text) & "', " & "'" & gStoreEqptRecord.sEqptStatus & "', " & "'" & quotation_mask(Trim(txtEqptDesc.Text)) & "'," & Str(VB6.GetItemData(cbContentDesc, cbContentDesc.SelectedIndex)) & "," & txtEqptQty.Text & ", '" & Trim(cbEqptTemp.Text) & "', " & txtEqptSizeCapacity.Text & ", " & txtEqptActualQty.Text & ")"
				
                'MsgBox sStmt
                cmLocal = cn.CreateCommand
                cmLocal.CommandText = sStmt
                nCount = cmLocal.ExecuteNonQuery
				
				If nCount = 1 Then
					'Registro salvado en BD.
					'Refrescar datagrid con nuevos datos
					General.gbStoreEqptMode = General.modo.SavedRecord
				End If
				MsgBox("Equipment was successfully assigned!", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
			Case General.modo.UpdateRecord
				
				Select Case cbStatus.Text
					Case "Active"
						gStoreEqptRecord.sEqptStatus = "A"
					Case "Inactive"
						gStoreEqptRecord.sEqptStatus = "I"
				End Select
				
				sStmt = "UPDATE storeEqpt SET " & " eqpt_id = " & Str(VB6.GetItemData(cbEqptDesc, cbEqptDesc.SelectedIndex)) & "," & " load_id ='" & Trim(cbLoadId.Text) & "'," & " eqpt_status ='" & gStoreEqptRecord.sEqptStatus & "', " & " eqpt_desc ='" & quotation_mask(Trim(txtEqptDesc.Text)) & "'," & " content_id =" & Str(VB6.GetItemData(cbContentDesc, cbContentDesc.SelectedIndex)) & "," & " eqpt_qty = " & txtEqptQty.Text & "," & " eqpt_temp = '" & Trim(cbEqptTemp.Text) & "', " & " eqpt_size_capacity = " & txtEqptSizeCapacity.Text & ", " & " eqpt_actual_qty = " & txtEqptActualQty.Text & " WHERE cust_id ='" & gStoreEqptRecord.sCustId & "' " & " AND store_id =" & Str(gStoreEqptRecord.nStoreId) & " " & " AND eqpt_seq =" & Str(gStoreEqptRecord.nEqptSeq)
				
				'MsgBox sStmt
				With cmLocal
					.CommandText = sStmt
                    nCount = .ExecuteNonQuery()
				End With
				If nCount >= 1 Then
					'Registro salvado en BD.
					'Refrescar datagrid con nuevos datos
					General.gbStoreEqptMode = General.modo.SavedRecord
					
				End If
				MsgBox("Equipment info was successfully updated!", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
		End Select
		Me.Close()
	End Sub
	
	Private Function val_fields(ByRef bFlag As General.modo) As Boolean
		
		val_fields = True
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtEqptQty.Text) Or Len(txtEqptQty.Text) = 0 Then
			MsgBox("Qty should be greater than zero.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Message")
			val_fields = False
			Exit Function
		Else
			If CDbl(txtEqptQty.Text) <= 0 Then
				MsgBox("Qty should be greater than zero.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Message")
				val_fields = False
				Exit Function
			End If
		End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtEqptActualQty.Text) Or Len(txtEqptActualQty.Text) = 0 Then
			MsgBox("Actual Qty should be greater than zero.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Message")
			val_fields = False
			Exit Function
		Else
			
			If CDbl(txtEqptActualQty.Text) <= 0 Then
				MsgBox("Actual Qty should be greater than zero.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Message")
				val_fields = False
				Exit Function
			Else
				If CShort(txtEqptActualQty.Text) > CShort(txtEqptQty.Text) Then
					MsgBox("Actual Qty cannot be greater than Qty", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Message")
					val_fields = False
					Exit Function
					
				End If
			End If
		End If
		
		
		If cbEqptTemp.SelectedIndex < 0 Then
			MsgBox("Please indicate if equipment is Temporary or Permament.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
			cbEqptTempDesc.Focus()
			val_fields = False
			Exit Function
		End If
	End Function
	'Retorna un nuevo EqptSeq para Insert en StoreEqpt
	Private Function get_eqptSeq() As Short
		
		sStmt = "SELECT MAX(eqpt_seq) FROM storeEqpt " & " WHERE cust_id ='" & gStoreEqptRecord.sCustId & "' " & " AND store_id =" & Str(gStoreEqptRecord.nStoreId)
        Try
            rsLocal = getDataTable(sStmt)
            '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rsLocal.Rows.Count > 0 Then
                If IsDBNull(rsLocal.Rows(0).Item(0)) Then
                    get_eqptSeq = 1
                Else
                    get_eqptSeq = rsLocal.Rows(0).Item(0) + 1
                End If
            Else
                MsgBox("Unable to get Equipment Sequence.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                get_eqptSeq = -1
            End If
        Catch ex As Exception
            MsgBox("Error while getting Equipment Sequence.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
            get_eqptSeq = -1
        End Try
		
	End Function
	
	
	Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
		update_accountEqpt()
	End Sub
	
    Private Sub dgAccountEqpt_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        update_accountEqpt()
    End Sub
	Private Sub update_accountEqpt()
		
        If dgAccountEqpt.SelectedRows.Count < 1 Then
            MsgBox("Please select an Account to Update.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
            Exit Sub
        End If
		General.gbAccountEqptMode = General.modo.UpdateRecord
		
		set_accountEqpt((General.modo.UpdateRecord))
		VB6.ShowForm(frmAccount, VB6.FormShowConstants.Modal, Me)
		
		Select Case ckbAccount.CheckState
			Case System.Windows.Forms.CheckState.Checked
                set_dgAccountEqptData((General.modo.SavedRecord), General.EqptStatus.Inactive)
			Case System.Windows.Forms.CheckState.Unchecked
                set_dgAccountEqptData((General.modo.SavedRecord), General.EqptStatus.Active)
			Case Else
                set_dgAccountEqptData((General.modo.SavedRecord), General.EqptStatus.Inactive)
		End Select
		
	End Sub
	Private Sub frmStoreEqptEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars(General.gbStoreEqptMode)
	End Sub
	
	Private Sub init_vars(ByRef bFlag As General.modo)
		
        rsLocal = Nothing
        rsAccountEqpt = Nothing
        cmLocal = cn.CreateCommand
        cmLocal.CommandType = CommandType.Text
		
		'UPGRADE_WARNING: TextBox property txtEqptDesc.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtEqptDesc.Maxlength = 40 'StoreEqpt.eqpt_desc
		
		txtCustName.Text = gStoreEqptRecord.sCustName
		txtStoreNumber.Text = gStoreEqptRecord.sStoreNumber
		'Combo de Equipos
		sStmt = "SELECT eqpt_desc, eqpt_id " & " FROM equipment  ORDER BY eqpt_desc"
		
		load_cb_query(cbEqptDesc, sStmt, 2)
		
		'Combo de Contenido
		sStmt = "SELECT content_desc, content_id " & " FROM content ORDER BY content_desc"
		load_cb_query(cbContentDesc, sStmt, 2)
		
		'Combo de LoadDesc
		sStmt = "SELECT load_desc FROM loadtype"
		load_cb_query(cbLoadDesc, sStmt, 1)
		
		'Combo de LoadID
		sStmt = " SELECT load_id FROM loadtype "
		load_cb_query(cbLoadId, sStmt, 1)
		
		'Combo Status
		cbStatus.Items.Insert(0, "Active")
		cbStatus.Items.Insert(1, "Inactive")
		
		'Combo Eqpt Temporary
		sStmt = "SELECT eqpt_temp_desc, eqpt_temp FROM EqptTemp ORDER BY eqpt_temp"
		load_cb_query(cbEqptTempDesc, sStmt, 1)
		
		sStmt = "SELECT eqpt_temp FROM EqptTemp ORDER BY eqpt_temp"
		load_cb_query(cbEqptTemp, sStmt, 1)
		
		Select Case bFlag
			Case General.modo.NewRecord
				cbEqptDesc.SelectedIndex = 0
				cbContentDesc.SelectedIndex = 0
				If cbLoadDesc.Items.Count > 0 Then
					cbLoadDesc.SelectedIndex = 0
				End If
				
				cbStatus.SelectedIndex = 0
				
				If cbEqptTemp.Items.Count > 0 Then
					cbEqptTempDesc.SelectedIndex = 0
				End If
				txtEqptQty.Text = "1"
				
				'Cambio Tamanio de la forma y Escondo dgAccount
				Me.Text = "New Equipment"
				Frame1.Height = VB6.TwipsToPixelsY(4295)
				cmdOk.Top = VB6.TwipsToPixelsY(5000)
				cmdCancel.Top = VB6.TwipsToPixelsY(5000)
				Me.Height = VB6.TwipsToPixelsY(6000)
				
			Case General.modo.UpdateRecord
				Me.Text = "Equipment Info"
				set_storeEqptInfo()
				
		End Select
		
		
        set_dgAccountEqptData(General.gbStoreEqptMode, General.EqptStatus.Active)
	End Sub
	'Carga los componentes de la forma con
	'datos del registro gStoreEqptRecord
	Private Sub set_storeEqptInfo()
		
		set_cb_ItemData(cbEqptDesc, gStoreEqptRecord.nEqptId)
		set_cb_ItemData(cbContentDesc, gStoreEqptRecord.nContentId)
		set_cb(cbLoadId, gStoreEqptRecord.sLoadId)
		If cbLoadId.SelectedIndex >= 0 Then
			cbLoadDesc.SelectedIndex = cbLoadId.SelectedIndex
		End If
		
		set_cb(cbEqptTemp, gStoreEqptRecord.sEqptTemp)
		If cbEqptTemp.SelectedIndex >= 0 Then
			cbEqptTempDesc.SelectedIndex = cbEqptTemp.SelectedIndex
		End If
		
		txtEqptQty.Text = CStr(gStoreEqptRecord.nEqptQty)
		txtEqptActualQty.Text = CStr(gStoreEqptRecord.nEqptActualQty)
		
		Select Case gStoreEqptRecord.sEqptStatus
			Case "A" 'Active
				set_cb(cbStatus, "Active")
			Case "I" 'Inactive
				set_cb(cbStatus, "Inactive")
		End Select
		
	End Sub
    Private Sub set_dgAccountEqptData(ByRef bFlag As General.modo, ByRef nAccountStatus As General.EqptStatus)

        Select Case bFlag
            Case General.modo.NewRecord
                sStmt = "SELECT  VAccount.account_mask AS 'Account No'," & _
                "RTRIM(Vendor.vend_name) + ' - ' + RTRIM(VBranch.vend_area) AS Vendor," & _
                " VAccountEqpt.account_status  AS Status, " & _
                " VAccountEqpt.vend_seq, VAccountEqpt.account_no as Account " & _
                " FROM VAccountEqpt, VBranch, Vendor, VAccount " & " WHERE Vendor.vend_id = VBranch.vend_id " & _
                " AND VBranch.vend_seq = -1"
            Case General.modo.UpdateRecord
                sStmt = "SELECT  VAccount.account_mask AS 'Account No'," & "RTRIM(Vendor.vend_name) + ' - ' + RTRIM(VBranch.vend_area) AS Vendor," & " VAccountEqpt.account_status  AS Status, " & " VAccountEqpt.vend_seq, VAccountEqpt.account_no as Account " & " FROM VAccountEqpt, VBranch, Vendor, VAccount " & " WHERE Vendor.vend_id = VBranch.vend_id " & " AND VBranch.vend_seq = VAccountEqpt.vend_seq " & " AND VAccountEqpt.cust_id = '" & gStoreEqptRecord.sCustId & "' " & " AND VAccountEqpt.store_id = " & Str(gStoreEqptRecord.nStoreId) & " " & " AND VAccountEqpt.eqpt_seq = " & Str(gStoreEqptRecord.nEqptSeq) & " AND VAccountEqpt.cust_id = VAccount.cust_id  " & " AND VAccountEqpt.store_id = VAccount.store_id " & " AND VAccountEqpt.account_no = VAccount.account_no " & " AND VAccountEqpt.vend_seq = VAccount.vend_seq "

                'Si combo Inactive no selecciono solo se muestran
                'cuentas activas. Caso contrario todas (Act, Inact)
                If nAccountStatus = General.EqptStatus.Active Then
                    sStmt = sStmt & " AND VAccountEqpt.account_status= 'A' "
                End If

                sStmt = sStmt & " ORDER BY Vendor"

            Case General.modo.SavedRecord
                sStmt = "SELECT  VAccount.account_mask AS 'Account No'," & "RTRIM(Vendor.vend_name) + ' - ' + RTRIM(VBranch.vend_area) AS Vendor," & " VAccountEqpt.account_status  AS Status, " & " VAccountEqpt.vend_seq, VAccountEqpt.account_no AS Account " & " FROM VAccountEqpt, VBranch, Vendor, VAccount " & " WHERE Vendor.vend_id = VBranch.vend_id " & " AND VBranch.vend_seq = VAccountEqpt.vend_seq " & " AND VAccountEqpt.cust_id = '" & gStoreEqptRecord.sCustId & "' " & " AND VAccountEqpt.store_id = " & Str(gStoreEqptRecord.nStoreId) & " " & " AND VAccountEqpt.eqpt_seq = " & Str(gStoreEqptRecord.nEqptSeq) & " AND VAccountEqpt.cust_id = VAccount.cust_id  " & " AND VAccountEqpt.store_id = VAccount.store_id " & " AND VAccountEqpt.account_no = VAccount.account_no " & " AND VAccountEqpt.vend_seq = VAccount.vend_seq "

                'Si combo Inactive no selecciono solo se muestran
                'cuentas activas. Caso contrario todas (Act, Inact)
                If nAccountStatus = General.EqptStatus.Active Then
                    sStmt = sStmt & " AND VAccountEqpt.account_status= 'A' "
                End If

                sStmt = sStmt & " ORDER BY Vendor"
        End Select
        'MsgBox sStmt
        dgAccountEqpt.DataSource = Nothing

        rsAccountEqpt = getDataTable(sStmt) '
        '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        dgAccountEqpt.DataSource = rsAccountEqpt

        'MsgBox("Error while accesing Account Equipment table.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")

        dgAccountEqpt.Refresh()
        'Formato de Datagrid
        dgAccountEqpt.Columns("vend_seq").Visible = False
        dgAccountEqpt.Columns("Account").Visible = False
        dgAccountEqpt.Columns("Vendor").Width = VB6.TwipsToPixelsX(2500)
        dgAccountEqpt.Columns("Account No").Width = VB6.TwipsToPixelsX(1500)
        dgAccountEqpt.Columns("Status").Width = VB6.TwipsToPixelsX(500)

        'Si es un nuevo StoreEqpt, no se puede insertar AccountEqpt en este momento
        'porque eqpt_seq no existe hasta que usuario presione OK en esta frm
        If bFlag = General.modo.NewRecord Then
            dgAccountEqpt.Enabled = False
            dgAccountEqpt.ForeColor = System.Drawing.Color.White
        End If
    End Sub
	
	Private Sub frmStoreEqptEntry_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'Limpio memoria
		'UPGRADE_NOTE: Object rsLocal may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rsLocal = Nothing
		'UPGRADE_NOTE: Object rsAccountEqpt may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rsAccountEqpt = Nothing
	End Sub
	
	Private Sub txtEqptActualQty_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtEqptActualQty.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Then
			'Es numero
			'Solo tres digitos
			If Len(txtEqptActualQty.Text) > 2 And KeyAscii <> 8 Then
				If txtEqptActualQty.SelectionLength = Len(txtEqptActualQty.Text) Then
					'
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
	
	Private Sub txtEqptQty_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtEqptQty.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Then
			'Es numero
			'Solo tres digitos
			If Len(txtEqptQty.Text) > 2 And KeyAscii <> 8 Then
				If txtEqptQty.SelectionLength = Len(txtEqptQty.Text) Then
					'
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
	
	Private Sub txtEqptSizeCapacity_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtEqptSizeCapacity.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros, Backspace, Punto
		Dim nPos As Short
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			'Es numero
			'No permitir ingresar mas de 2 decimales
			'If (KeyAscii >= 48 And KeyAscii <= 57) _
			''And max_fraction(txtUnitsDet) _
			''And txtUnitsDet.SelLength = 0 Then
			'    KeyAscii = 0
			'End If
		Else
			nPos = InStr(1, txtEqptSizeCapacity.Text, ".", CompareMethod.Text)
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If KeyAscii = 46 And (nPos = 0 Or IsDbNull(nPos)) Then
				'continue
			Else
				KeyAscii = 0
			End If
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class