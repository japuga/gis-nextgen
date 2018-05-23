Option Strict Off
Option Explicit On
Friend Class frmSaleRequestItem
    Inherits System.Windows.Forms.Form
    Private ImageList2 As New ImageList()
	'UPGRADE_WARNING: Event cbStatus.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbStatus_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbStatus.SelectedIndexChanged
		
		If cbStatus.SelectedIndex >= 0 Then
			cbRequestItemStatus.SelectedIndex = cbStatus.SelectedIndex
		End If
		
	End Sub
	
	Private Sub frmSaleRequestItem_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		Dim nStatusIndex As Short
		
		txtAvailableQty.Enabled = False
		txtAvailableQty.ReadOnly = True
		
		sStmt = "SELECT field_option_desc FROM sdomain " & " WHERE domain_field ='" & DOMAIN_REQUEST_ITEM_STATUS & "' " & " ORDER BY field_option_desc "
		load_cb_query2(cbStatus, sStmt, 1, True)
		
		sStmt = "SELECT field_option FROM sdomain " & " WHERE domain_field ='" & DOMAIN_REQUEST_ITEM_STATUS & "' " & " ORDER BY field_option_desc "
		load_cb_query2(cbRequestItemStatus, sStmt, 1, True)
		
		
		
		Select Case gSaleItem.bFlag
			Case General.modo.NewRecord
				nStatusIndex = get_index_in_cb(cbRequestItemStatus, "FORSALE")
				If nStatusIndex >= 0 Then
					cbStatus.SelectedIndex = nStatusIndex
				End If
				cbStatus.Enabled = False
				'UPGRADE_ISSUE: ComboBox property cbStatus.Locked was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                'cbStatus.Locked = True
				
			Case General.modo.UpdateRecord
				nStatusIndex = get_index_in_cb(cbRequestItemStatus, gSaleItem.sRequetItemStatus)
				If nStatusIndex >= 0 Then
					cbStatus.SelectedIndex = nStatusIndex
				End If
				
				txtItemDesc.Text = gSaleItem.sItemDesc
				txtAccountNo.Text = gSaleItem.sAccountNo
				txtQty.Text = CStr(gSaleItem.nItemQty)
				txtAvailableQty.Text = CStr(gSaleItem.nAvailableQty)
				txtNotes.Text = gSaleItem.sNotes
				
		End Select
		
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button4.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)


        Select Case Button.Name
            Case "save"
                If val_fields() Then
                    If save_request_item() Then
                        Me.Close()
                    End If
                End If

            Case "exit"
                Me.Close()
        End Select

    End Sub
	
	Private Function val_fields() As Boolean
		val_fields = False
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtItemDesc.Text) Or Len(Trim(txtItemDesc.Text)) = 0 Then
			MsgBox("Please enter a description for this Item.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtItemDesc.Focus()
			Exit Function
		End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtAccountNo.Text) Or Len(Trim(txtAccountNo.Text)) = 0 Then
			MsgBox("Please enter an Account Number.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtAccountNo.Focus()
			Exit Function
		End If
		
		If cbStatus.SelectedIndex < 0 Then
			MsgBox("Please choose a status before continuing.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			cbStatus.Focus()
			Exit Function
		End If
		
		val_fields = True
	End Function
	
	Private Sub txtQty_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim nPos As Object
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			'Es numero
			'No permitir ingresar mas de 2 decimales
			'If (KeyAscii >= 48 And KeyAscii <= 57) _
			''And max_fraction(txtUnitsDet) _
			''And txtUnitsDet.SelLength = 0 Then
			'    KeyAscii = 0
			'End If
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object nPos. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			nPos = InStr(1, txtQty.Text, ".", CompareMethod.Text)
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'UPGRADE_WARNING: Couldn't resolve default property of object nPos. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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
	
	Private Function save_request_item() As Boolean
		Dim nItemSeq As Short
		Dim cmLocal As New ADODB.Command
		Dim nRecords As Short
		Dim paramAvlQty As ADODB.Parameter
		Dim paramQty As ADODB.Parameter
		
		save_request_item = False
		
		Select Case gSaleItem.bFlag
			Case General.modo.NewRecord
				nItemSeq = get_table_sequence("SaleRequestItem", "item_seq")
				
				sStmt = "INSERT INTO saleRequestItem (request_seq, item_seq, item_desc," & " item_qty, account_no, request_item_status, notes, available_qty) " & " VALUES (?, ?, ?, ?, ?, ?, ?, ?)"
				
				cmLocal.CommandType = ADODB.CommandTypeEnum.adCmdText
				cmLocal.CommandText = sStmt
				
				'Parameters
                cmLocal.Parameters.Append(cmLocal.CreateParameter("request_seq", DbType.Int32, ParameterDirection.Input, 4, gSaleRequest.nRequestSeq))
				
                cmLocal.Parameters.Append(cmLocal.CreateParameter("item_seq", DbType.Int32, ParameterDirection.Input, 4, nItemSeq))
				
                cmLocal.Parameters.Append(cmLocal.CreateParameter("item_desc", DbType.String, ParameterDirection.Input, 300, quotation_mask((txtItemDesc.Text))))


                paramQty = cmLocal.CreateParameter("item_qty", ADODB.DataTypeEnum.adDouble, ParameterDirection.Input, 16, txtQty.Text)
                'paramQty.NumericScale = 2
                'paramQty.Precision = 2
                cmLocal.Parameters.Append(paramQty)

                cmLocal.Parameters.Append(cmLocal.CreateParameter("account_no", DbType.String, ParameterDirection.Input, 80, quotation_mask((txtAccountNo.Text))))

                cmLocal.Parameters.Append(cmLocal.CreateParameter("request_item_status", DbType.String, ParameterDirection.Input, 100, cbRequestItemStatus.Text))

                cmLocal.Parameters.Append(cmLocal.CreateParameter("notes", DbType.String, ParameterDirection.Input, 500, quotation_mask((txtNotes.Text))))


                paramAvlQty = cmLocal.CreateParameter("available_qty", ADODB.DataTypeEnum.adDouble, ParameterDirection.Input, 16, txtQty.Text)
                'paramAvlQty.NumericScale = 2
                'paramAvlQty.Precision = 2
                cmLocal.Parameters.Append(paramAvlQty)

                cmLocal.let_ActiveConnection(cn)
                cmLocal.Execute(nRecords)
                If nRecords > 0 Then
                    gSaleItem.bFlag = General.modo.SavedRecord
                    gSaleItem.nItemSeq = nItemSeq
                    MsgBox("Item was successfully saved.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
                Else
                    MsgBox("Item was not saved. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Message")

                End If


            Case General.modo.UpdateRecord
                sStmt = "UPDATE saleRequestItem " & " SET item_desc = ?, " & "     item_qty = ?, " & "     account_no = ?, " & "     request_item_status = ?," & "     notes = ?," & "     available_qty = ?" & " WHERE request_seq = ?" & " AND item_seq = ? "

                cmLocal.CommandType = ADODB.CommandTypeEnum.adCmdText
                cmLocal.CommandText = sStmt

                'Parameters
                cmLocal.Parameters.Append(cmLocal.CreateParameter("item_desc", DbType.String, ParameterDirection.Input, 300, quotation_mask((txtItemDesc.Text))))


                paramQty = cmLocal.CreateParameter("item_qty", ADODB.DataTypeEnum.adDecimal, ParameterDirection.Input, 8, txtQty.Text)
                paramQty.Precision = 2
                cmLocal.Parameters.Append(paramQty)

                cmLocal.Parameters.Append(cmLocal.CreateParameter("account_no", DbType.String, ParameterDirection.Input, 80, quotation_mask((txtAccountNo.Text))))

                cmLocal.Parameters.Append(cmLocal.CreateParameter("request_item_status", DbType.String, ParameterDirection.Input, 100, cbRequestItemStatus.Text))

                cmLocal.Parameters.Append(cmLocal.CreateParameter("notes", DbType.String, ParameterDirection.Input, 500, quotation_mask((txtNotes.Text))))


                paramAvlQty = cmLocal.CreateParameter("available_qty", ADODB.DataTypeEnum.adDecimal, ParameterDirection.Input, 8, txtQty.Text)
                paramAvlQty.Precision = 2
                cmLocal.Parameters.Append(paramAvlQty)

                cmLocal.Parameters.Append(cmLocal.CreateParameter("request_seq", DbType.Int32, ParameterDirection.Input, 4, gSaleRequest.nRequestSeq))

                cmLocal.Parameters.Append(cmLocal.CreateParameter("item_seq", DbType.Int32, ParameterDirection.Input, 4, gSaleItem.nItemSeq))

                cmLocal.let_ActiveConnection(cn)
                cmLocal.Execute(nRecords)
                If nRecords > 0 Then
                    gSaleItem.bFlag = General.modo.SavedRecord
                    MsgBox("Item was successfully saved.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
                Else
                    MsgBox("Item was not saved. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Message")

                End If

        End Select
		
		'UPGRADE_NOTE: Object cmLocal may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		cmLocal = Nothing
		save_request_item = True
	End Function
End Class