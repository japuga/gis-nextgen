Option Strict Off
Option Explicit On
Friend Class frmInvoiceBookingDetWgtEntry
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		
		If val_fields Then
			If save_record Then
				Me.Close()
			End If
		End If
		
	End Sub
	
	Private Function val_fields() As Boolean
		val_fields = False
		
		'Qty
		If Len(Trim(txtQty.Text)) <= 0 Then
			MsgBox("Please enter Qty", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtQty.Focus()
			Exit Function
		Else
			If (CDbl(txtQty.Text) <= 0) Then
				MsgBox("Qty must be greater than zero", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
				txtQty.Focus()
				Exit Function
			End If
		End If
		
		
		
		'Weight
		If Len(Trim(txtWeight.Text)) <= 0 Then
			MsgBox("Please enter Weight", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtWeight.Focus()
			Exit Function
		End If
		
		
		'Ticket and TicketDate are optional
		
		val_fields = True
		
	End Function
	
	Private Function save_record() As Boolean
		Dim nSequenceId As Short
		Dim nRecords As Short
		
		save_record = False
		
		'Get ID
		sStmt = "SELECT MAX(sequence_id) FROM vInvoiceDetWgt " & " WHERE cust_id = '" & Trim(gInvHeaderRecord.sCustId) & "' " & " AND invoice_no = '" & gInvHeaderRecord.sInvoiceNo & "'" & " AND store_id = " & Str(gInvHeaderRecord.nStoreId) & " AND account_no = '" & gInvHeaderRecord.sAccountNo & "' " & " AND vend_seq = " & Str(gInvHeaderRecord.nVendSeq) & " AND invoice_det_no = " & Str(gInvDetRecord.nInvoiceDetNo)
		
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(rs.Rows(0).Item(0).Value) Then
            nSequenceId = 1
        ElseIf rs.Rows(0).Item(0).Value <= 0 Then
            nSequenceId = 1
        Else
            nSequenceId = rs.Rows(0).Item(0).Value + 1
        End If



        'Insert

        Select Case gInvDetWgt.bFlag
            Case General.modo.NewRecord
                sStmt = "INSERT INTO vInvoiceDetWgt (invoice_no, cust_id, " & "store_id, account_no, vend_seq, invoice_det_no," & "sequence_id, weight, ticket, ticket_date, qty, weight_unit_type) " & " VALUES ('" & Trim(quotation_mask(gInvHeaderRecord.sInvoiceNo)) & "', " & "'" & gInvHeaderRecord.sCustId & "'," & Str(gInvHeaderRecord.nStoreId) & "," & "'" & gInvHeaderRecord.sAccountNo & "'," & Str(gInvHeaderRecord.nVendSeq) & "," & Str(gInvDetRecord.nInvoiceDetNo) & "," & Str(nSequenceId) & "," & Trim(txtWeight.Text) & "," & "'" & Trim(quotation_mask(txtTicket.Text)) & "'," & "'" & Str(dtTicketDate._Value) & "'," & txtQty.Text & ",'" & cbWeightUnitType.Text & "')"

                cm = cn.CreateCommand '.let_ActiveConnection(cn)
                cm.CommandType = CommandType.Text
                cm.CommandText = sStmt
                nRecords = cm.ExecuteNonQuery()

                If nRecords > 0 Then
                    gInvDetWgt.bFlag = General.modo.SavedRecord
                Else
                    MsgBox("Failed to save Weights. Check log file for details", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Function
                End If
            Case General.modo.UpdateRecord
                sStmt = "UPDATE vInvoiceDetWgt " & " SET weight = " & Trim(txtWeight.Text) & "," & " ticket = '" & Trim(quotation_mask(txtTicket.Text)) & "'," & " ticket_date = '" & Str(dtTicketDate._Value) & "', " & " qty = " & txtQty.Text & "," & " weight_unit_type = '" & cbWeightUnitType.Text & "' " & " WHERE cust_id = '" & Trim(gInvHeaderRecord.sCustId) & "' " & " AND invoice_no = '" & gInvHeaderRecord.sInvoiceNo & "'" & " AND store_id = " & Str(gInvHeaderRecord.nStoreId) & " AND account_no = '" & gInvHeaderRecord.sAccountNo & "' " & " AND vend_seq = " & Str(gInvHeaderRecord.nVendSeq) & " AND invoice_det_no = " & Str(gInvDetRecord.nInvoiceDetNo) & " AND sequence_id = " & Str(gInvDetWgt.nSequenceId)

                cm = cn.CreateCommand '.let_ActiveConnection(cn)
                cm.CommandType = CommandType.Text
                cm.CommandText = sStmt
                nRecords = cm.ExecuteNonQuery()
                If nRecords > 0 Then
                    gInvDetWgt.bFlag = General.modo.SavedRecord
                Else
                    MsgBox("Failed to update Weights. Check log file for details", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Function
                End If

        End Select



        save_record = True
        Exit Function

ErrorHandler:
        save_error(Me.Name, "save_record")
        MsgBox("Unexpected error found while saving Weights.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
	End Function
	
	Private Sub frmInvoiceBookingDetWgtEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		
		
	End Sub
	Private Sub init_vars()
		'txtQty
		'UPGRADE_WARNING: TextBox property txtQty.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtQty.Maxlength = 8
		'UPGRADE_WARNING: TextBox property txtWeight.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtWeight.Maxlength = 12
		
		'cbWeightUnitType
		sStmt = "SELECT field_option FROM SDomain " & " WHERE domain_field='weight_unit_type' " & " ORDER BY option_order "
		load_cb_query2(cbWeightUnitType, sStmt, 1, True)
		
		If cbWeightUnitType.Items.Count > 0 Then
			cbWeightUnitType.SelectedIndex = 0
		End If
		
		Select Case gInvDetWgt.bFlag
			Case General.modo.NewRecord
				txtQty.Text = CStr(1)
				dtTicketDate.Value = Today
			Case General.modo.UpdateRecord
				txtQty.Text = CStr(gInvDetWgt.nQty)
				txtWeight.Text = CStr(gInvDetWgt.nWeight)
				txtTicket.Text = gInvDetWgt.sTicket
				dtTicketDate._Value = gInvDetWgt.dtTicketDate
				set_cb(cbWeightUnitType, gInvDetWgt.sWeightUnitType)
				
				
		End Select
		
	End Sub
	
	Private Sub txtQty_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
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
			nPos = InStr(1, txtQty.Text, ".", CompareMethod.Text)
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
	
	Private Sub txtWeight_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtWeight.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros, Backspace, Punto
		Dim nPos As Short
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			'Es numero
			'No permitir ingresar mas de 4 decimales
			If (KeyAscii >= 48 And KeyAscii <= 57) And max_fraction2(txtWeight.Text, 4) And txtWeight.SelectionLength = 0 Then
				KeyAscii = 0
			End If
		Else
			nPos = InStr(1, txtWeight.Text, ".", CompareMethod.Text)
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