Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmSaleRequestTicket
	Inherits System.Windows.Forms.Form
    Private avlQty As Double
    Private ImageList2 As New ImageList()
	
	'UPGRADE_WARNING: Event cbItemDesc.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbItemDesc_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbItemDesc.SelectedIndexChanged
		avlQty = get_available_qty(gSaleTicket.nRequestSeq, VB6.GetItemData(cbItemDesc, cbItemDesc.SelectedIndex))
		
		txtQty.Text = CStr(avlQty)
	End Sub
	
	Private Sub frmSaleRequestTicket_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	
	Private Sub init_vars()
		
		
		avlQty = 0
		
		'Item Desc
		sStmt = "SELECT item_desc, item_seq FROM saleRequestItem " & " WHERE request_seq = " & Str(gSaleTicket.nRequestSeq) & " ORDER BY item_desc "
		
		load_cb_query2(cbItemDesc, sStmt, 2, True)
		
		
		Select Case gSaleTicket.bFlag
			Case General.modo.NewRecord
				If cbItemDesc.Items.Count >= 0 Then
					cbItemDesc.SelectedIndex = 0
				End If
				
				'Sale Date
				dtSaleDate.value = Today
				
			Case General.modo.UpdateRecord
				
		End Select
		
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)

        Select Case Button.Name
            Case "save"
                If val_fields() Then
                    save_ticket()
                End If
            Case "exit"
                Me.Close()
        End Select

    End Sub
	
	Private Function val_fields() As Boolean
		
		val_fields = False
		
		'Item
		If cbItemDesc.SelectedIndex < 0 Then
			MsgBox("Please select the Item sold.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			cbItemDesc.Focus()
			Exit Function
		End If
		
		'Qty
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtQty.Text) Or Len(Trim(txtQty.Text)) = 0 Then
			MsgBox("Please enter Quantity Sold", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtQty.Focus()
			Exit Function
		Else
			If IsNumeric(txtQty.Text) Then
				If CDbl(txtQty.Text) <= 0 Then
					MsgBox("Please enter a Quantity greater than zero.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
					txtQty.Focus()
					Exit Function
				Else
					'Check that quantity is not greater than Available
					If CDbl(txtQty.Text) > avlQty Then
						MsgBox("Quantity sold may not exceed Available Quantity.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
						txtQty.Focus()
						Exit Function
					End If
				End If
			Else
				MsgBox("Please enter a valid Quantity.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
				txtQty.Focus()
				Exit Function
			End If
			
		End If
		
		'Sale Amount
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtSaleAmount.Text) Or Len(Trim(txtSaleAmount.Text)) = 0 Then
			MsgBox("Please enter the Sale Amount.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtSaleAmount.Focus()
			Exit Function
		Else
			If CDbl(txtSaleAmount.Text) < 0 Then
				MsgBox("Sale Amount must be greater or equal than zero.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
				txtSaleAmount.Focus()
				Exit Function
			End If
		End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtNotes.Text) Then
			txtNotes.Text = ""
		End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtBuyer.Text) Then
			txtBuyer.Text = ""
		End If
		
		val_fields = True
		
	End Function
	Private Function save_ticket() As Boolean
		Dim cmLocal As New ADODB.Command
		Dim paramQty As ADODB.Parameter
		Dim paramAmount As ADODB.Parameter
		Dim paramNewQty As ADODB.Parameter
		Dim nTicketSeq As Short
		Dim nRecords As Short
		Dim newQty As Double
        Dim nTrans As sqltransaction
		
		
		nTicketSeq = get_table_sequence("SaleTicket", "ticket_seq")
		
        nTrans = cn.BeginTransaction()
		
		sStmt = "INSERT INTO SaleTicket (ticket_seq, request_seq, " & " item_seq, qty, sale_amount, " & " sale_date, notes, buyer)" & " VALUES ( ?, ?, ?, ?, ?, ?, ?, ?)"
		
		'sStmt = "INSERT INTO SaleTicket (ticket_seq, request_seq, " + _
		''        " item_seq, qty, sale_amount, " + _
		''        " sale_date, notes, buyer)" + _
		''        " VALUES ( ?, ?, ?, 40, 1.2, ?, ?, ?)"
		
		
		cmLocal.CommandType = ADODB.CommandTypeEnum.adCmdText
		cmLocal.CommandText = sStmt
		
		'Parameters
        cmLocal.Parameters.Append(cmLocal.CreateParameter("ticket_seq", DbType.Int32, ParameterDirection.Input, 4, nTicketSeq))
		
        cmLocal.Parameters.Append(cmLocal.CreateParameter("request_seq", DbType.Int32, ParameterDirection.Input, 4, gSaleTicket.nRequestSeq))
		
        cmLocal.Parameters.Append(cmLocal.CreateParameter("item_seq", DbType.Int32, ParameterDirection.Input, 4, VB6.GetItemData(cbItemDesc, cbItemDesc.SelectedIndex)))
		
		
		'Qty
        paramQty = cmLocal.CreateParameter("qty", ADODB.DataTypeEnum.adDouble, ParameterDirection.Input, 16)
		'paramQty.NumericScale = 2
		'paramQty.Precision = 2
		paramQty.value = CDbl(txtQty.Text)
		'MsgBox paramQty.value
		cmLocal.Parameters.Append(paramQty)
		
		'Amount
        paramAmount = cmLocal.CreateParameter("sale_amount", ADODB.DataTypeEnum.adDouble, ParameterDirection.Input, 16, txtSaleAmount.Text)
		'paramAmount.NumericScale = 2
		'paramAmount.Precision = 2
		cmLocal.Parameters.Append(paramAmount)
		
		'SaleDate
        cmLocal.Parameters.Append(cmLocal.CreateParameter("sale_date", ADODB.DataTypeEnum.adDate, ParameterDirection.Input, 10, dtSaleDate.Value))
		
		
		'notes
        cmLocal.Parameters.Append(cmLocal.CreateParameter("notes", DbType.String, ParameterDirection.Input, 500, quotation_mask(Trim(txtNotes.Text))))

        'Buyer
        cmLocal.Parameters.Append(cmLocal.CreateParameter("buyer", DbType.String, ParameterDirection.Input, 50, quotation_mask(Trim(txtBuyer.Text))))
		
		cmLocal.let_ActiveConnection(cn)
		cmLocal.Execute(nRecords)
		
		If nRecords > 0 Then
			gSaleTicket.bFlag = General.modo.SavedRecord
			gSaleTicket.nTicketSeq = nTicketSeq
			
			'Update Item's Available Qty
			'UPGRADE_NOTE: Object cmLocal may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			cmLocal = Nothing
			
			sStmt = "UPDATE SaleRequestItem " & " SET available_qty = ? " & " WHERE request_seq = ? " & " AND item_seq = ? "
			
			cmLocal.CommandType = ADODB.CommandTypeEnum.adCmdText
			cmLocal.CommandText = sStmt
			
			'Parameters
			newQty = avlQty - CDbl(txtQty.Text)
			
            paramNewQty = cmLocal.CreateParameter("avl_qty", ADODB.DataTypeEnum.adDecimal, ParameterDirection.Input, 9, newQty)
			paramNewQty.Precision = 2
			cmLocal.Parameters.Append(paramNewQty)
			
            cmLocal.Parameters.Append(cmLocal.CreateParameter("request_seq", DbType.Int32, ParameterDirection.Input, 4, gSaleTicket.nRequestSeq))
            cmLocal.Parameters.Append(cmLocal.CreateParameter("item_seq", DbType.Int32, ParameterDirection.Input, 4, VB6.GetItemData(cbItemDesc, cbItemDesc.SelectedIndex)))
			
			cmLocal.let_ActiveConnection(cn)
			cmLocal.Execute(nRecords)
			
			If nRecords > 0 Then
                nTrans.Commit()
				MsgBox("Ticket was saved successfully.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
			Else

                nTrans.Rollback()
				MsgBox("Failed to update Item's Available Qty. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
				
			End If
		Else
            nTrans.Rollback()
            MsgBox("Record was not saved. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
		End If
		
	End Function
	Private Function get_available_qty(ByRef nRequestSeq As Short, ByRef nItemSeq As Short) As Double
		
		get_available_qty = 0
		
		sStmt = "SELECT available_qty FROM saleRequestItem " & " WHERE request_seq = " & Str(nRequestSeq) & " AND item_seq = " & Str(nItemSeq)
		
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		

        If rs.Rows.Count > 0 Then
            If Not IsDBNull(rs.Rows(0).Item("available_qty").Value) And rs.Rows(0).Item("available_qty").Value > 0 Then
                get_available_qty = rs.Rows(0).Item("available_qty").Value
            End If
        End If

		
	End Function
End Class