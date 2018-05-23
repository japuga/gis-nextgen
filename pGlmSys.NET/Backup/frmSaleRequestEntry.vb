Option Strict Off
Option Explicit On

Friend Class frmSaleRequestEntry
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private rsTicket As DataTable
    Private prevFlag As General.modo
    Private ImageList2 As New ImageList()
	
	
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		customerChangeActions()
		
	End Sub
	'Actions that take effect when user choses a customer
	Private Sub customerChangeActions()
		
		'cust_id
		cbCustId.SelectedIndex = cbCustName.SelectedIndex
		
		'store
		sStmt = " SELECT store_number, store_id FROM store " & " WHERE cust_id = '" & cbCustId.Text & "'" & " ORDER BY store_number "
		
		load_cb_query2(cbStoreNo, sStmt, 2, True)
		If cbStoreNo.Items.Count > 0 Then
			cbStoreNo.SelectedIndex = 0
		End If
		
	End Sub
	
	'UPGRADE_WARNING: Event cbStoreNo.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbStoreNo_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbStoreNo.SelectedIndexChanged
		
		If cbStoreNo.SelectedIndex >= 0 Then
			storeChangeActions((cbCustId.Text), VB6.GetItemData(cbStoreNo, cbStoreNo.SelectedIndex))
		Else
			'Clear since no store was selected
			storeChangeActions("--", 0)
		End If
		
	End Sub
	
	Private Sub storeChangeActions(ByRef sCustId As String, ByRef storeId As Short)
		txtStoreName.Text = getStoreName(sCustId, storeId)
		
		'Clear the datagrid
		load_dgRequestItems(0)
		
	End Sub
	
	Private Sub dgRequestItems_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dgRequestItems.DblClick
		update_item()
	End Sub
	
	Private Sub frmSaleRequestEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		
        rsTicket = Nothing
        rsLocal = Nothing
		
		sStmt = "SELECT cust_id, cust_name FROM customer ORDER BY cust_name"
		load_cb_query2(cbCustId, sStmt, 1, True)
		
		sStmt = "SELECT cust_name FROM customer ORDER BY cust_name"
		load_cb_query2(cbCustName, sStmt, 1, True)
		
		If cbCustName.Items.Count > 0 Then
			cbCustName.SelectedIndex = 0
		End If
		
		
		set_cb(cbCustName, gSaleRequest.sCustName)
		set_cb_ItemData2(cbStoreNo, gSaleRequest.nStoreId)
		
		txtStoreName.Enabled = False
		txtStoreName.ReadOnly = True
		
		Select Case gSaleRequest.bFlag
			Case General.modo.NewRecord
				dtRequestDate._Value = Today
				dtResponseDate._Value = Today
				
				
			Case General.modo.UpdateRecord
				
				enable_pk_controls(False)
				
				txtSaleRequest.Text = gSaleRequest.sRequestNo
				dtRequestDate._Value = gSaleRequest.dtRequestDate
				dtResponseDate._Value = gSaleRequest.dtResponseDate
				txtNotes.Text = gSaleRequest.sNotes
				txtTrackingNo.Text = gSaleRequest.sTrackingNo
				
				load_dgRequestItems(gSaleRequest.nRequestSeq)
				load_dgTickets(gSaleRequest.nRequestSeq)
				
				
		End Select
		
		
	End Sub
	
	Private Sub load_dgRequestItems(ByRef nRequestSeq As Short)
		
		
		
		sStmt = " SELECT a.item_seq, a.item_desc Item, " & " a.item_qty Qty, a.available_qty Available, " & " a.account_no Account, b.field_option_desc Status, " & " a.request_item_status , a.notes Notes " & " FROM saleRequestItem a, sDomain b " & " WHERE a.request_seq =  " & Str(nRequestSeq) & " AND a.request_item_status = b.field_option " & " AND b.domain_field = '" & DOMAIN_REQUEST_ITEM_STATUS & "' " & " ORDER BY a.item_desc "
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn)
        If rsLocal.Rows.Count > 0 Then
            dgRequestItems.DataSource = rsLocal
        Else
            Exit Sub
        End If
		
		'Formato
		dgRequestItems.Columns("item_seq").Visible = False
		
		dgRequestItems.Columns("request_item_status").Visible = False
		
		
		'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        dgRequestItems.Refresh()
		
	End Sub
	
	
	Private Sub load_dgTickets(ByRef nRequestSeq As Short)
		sStmt = "SELECT a.ticket_seq, a.request_seq, a.item_seq," & "b.item_desc Item, a.qty Qty, a.sale_amount 'Sale Amount', " & " a.sale_date 'Date', a.notes Notes, a.buyer Buyer" & " FROM SaleTicket a, SaleRequestItem b " & " WHERE a.request_seq = " & Str(nRequestSeq) & " AND a.request_seq = b.request_seq " & " AND a.item_seq = b.item_seq " & " ORDER BY b.item_desc "
		
		
        rsTicket = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsTicket.Rows.Count > 0 Then
            dgSaleTickets.DataSource = rsTicket
        Else
            Exit Sub
        End If
		
		'Hide fields
		dgSaleTickets.Columns("ticket_seq").Visible = False
		dgSaleTickets.Columns("request_seq").Visible = False
		dgSaleTickets.Columns("item_seq").Visible = False
		dgSaleTickets.Columns("Notes").Visible = False
		
		'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        dgSaleTickets.Refresh()
		
	End Sub
    Private Sub tbSaleItem_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)


        'Verify header Request before adding Items
        Select Case gSaleRequest.bFlag
            Case General.modo.NewRecord
                If gSaleRequest.nRequestSeq <= 0 Then
                    MsgBox("You must save the Request before adding Items.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                    Exit Sub
                End If
            Case General.modo.UpdateRecord
                If gSaleRequest.nRequestSeq <= 0 Then
                    MsgBox("There is not current Request to assign Items.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                    Exit Sub
                End If
        End Select


        'Item Insert/Update
        Select Case Button.Name
            Case "new"
                gSaleItem.bFlag = General.modo.NewRecord
                gSaleItem.nRequestSeq = gSaleRequest.nRequestSeq

                'New Item
                VB6.ShowForm(frmSaleRequestItem, VB6.FormShowConstants.Modal, Me)

                'Refresh
                If gSaleItem.bFlag = General.modo.SavedRecord Then
                    load_dgRequestItems(gSaleRequest.nRequestSeq)
                End If

            Case "save"
                update_item()

            Case "delete"
                delete_item(gSaleRequest.nRequestSeq)

        End Select

    End Sub
	Private Sub update_item()
		
		If dgRequestItems.SelBookmarks.Count <= 0 Then
			MsgBox("You must select an Item before attempting this action.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			Exit Sub
		End If
		
		'data
		gSaleItem.bFlag = General.modo.UpdateRecord
		gSaleItem.nRequestSeq = gSaleRequest.nRequestSeq
		gSaleItem.sItemDesc = dgRequestItems.Columns("Item").Text
		gSaleItem.nItemSeq = CShort(dgRequestItems.Columns("item_seq").Text)
		gSaleItem.nItemQty = CDbl(dgRequestItems.Columns("Qty").Text)
		gSaleItem.nAvailableQty = CDbl(dgRequestItems.Columns("Available").Text)
		gSaleItem.sAccountNo = dgRequestItems.Columns("Account").Text
		gSaleItem.sRequetItemStatus = dgRequestItems.Columns("request_item_status").Text
		gSaleItem.sNotes = dgRequestItems.Columns("Notes").Text
		
		'Show Item screen
		VB6.ShowForm(frmSaleRequestItem, VB6.FormShowConstants.Modal, Me)
		
		'Refresh
		If gSaleItem.bFlag = General.modo.SavedRecord Then
			load_dgRequestItems(gSaleRequest.nRequestSeq)
		End If
		
	End Sub
	Private Sub delete_item(ByRef nRequestSeq As Short)
		
		Dim cmLocal As New ADODB.Command
		Dim nItemSeq As Short
		Dim nRecords As Short
		
		If dgRequestItems.SelBookmarks.Count <= 0 Then
			MsgBox("You must select an Item before attempting this action.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			Exit Sub
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object dgRequestItems.SelBookmarks.Item(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			nItemSeq = dgRequestItems.SelBookmarks.Item(0)
			MsgBox("deleting Item seq:" & Str(nItemSeq))
		End If
		
		sStmt = "DELETE FROM SaleRequestItem " & " WHERE request_seq = ? AND item_seq = ?"
		
		
		cmLocal.CommandType = ADODB.CommandTypeEnum.adCmdText
		cmLocal.CommandText = sStmt
		
        cmLocal.Parameters.Append(cmLocal.CreateParameter("request_seq", DbType.Int32, ParameterDirection.Input, 4, nRequestSeq))
        cmLocal.Parameters.Append(cmLocal.CreateParameter("item_seq", DbType.Int32, ParameterDirection.Input, 4, nItemSeq))
		
		
		cmLocal.let_ActiveConnection(cn)
		cmLocal.Execute(nRecords)
		
		If nRecords > 0 Then
			MsgBox("Item was successfully deleted.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
			load_dgRequestItems(nRequestSeq)
		Else
			MsgBox("Failed to remove Item. Check log file for details ", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		End If
		
		
		'UPGRADE_NOTE: Object cmLocal may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		cmLocal = Nothing
		
		
	End Sub
	
	Private Sub update_ticket()
		
		If dgSaleTickets.SelBookmarks.Count <= 0 Then
			MsgBox("You must select a Ticket before attempting this action.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			Exit Sub
		End If
		
		'data
		gSaleTicket.bFlag = General.modo.UpdateRecord
		gSaleTicket.nRequestSeq = gSaleRequest.nRequestSeq
		gSaleTicket.nItemSeq = CShort(dgSaleTickets.Columns("item_seq").Text)
		gSaleTicket.nTicketSeq = CShort(dgSaleTickets.Columns("ticket_seq").Text)
		gSaleTicket.dtSaleDate = CDate(dgSaleTickets.Columns("Date").Text)
		gSaleTicket.nQty = CDbl(dgSaleTickets.Columns("Qty").Text)
		gSaleTicket.nSaleAmount = CDbl(dgSaleTickets.Columns("Sale Amount").Text)
		gSaleTicket.sBuyer = dgSaleTickets.Columns("Buyer").Text
		gSaleTicket.sItemDesc = dgSaleTickets.Columns("Item").Text
		gSaleTicket.sNotes = dgSaleTickets.Columns("Notes").Text
		
		'Show Item screen
		VB6.ShowForm(frmSaleRequestTicket, VB6.FormShowConstants.Modal, Me)
		
		
		'Refresh
		If gSaleTicket.bFlag = General.modo.SavedRecord Then
			load_dgTickets(gSaleRequest.nRequestSeq)
			load_dgRequestItems(gSaleRequest.nRequestSeq)
		End If
		
	End Sub
    Private Sub tbSaleTicket_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)


        Select Case Button.Name
            Case "new"
                gSaleTicket.bFlag = General.modo.NewRecord
                gSaleTicket.nRequestSeq = gSaleRequest.nRequestSeq

                VB6.ShowForm(frmSaleRequestTicket, VB6.FormShowConstants.Modal, Me)

                load_dgTickets(gSaleRequest.nRequestSeq)

            Case "save"
                update_ticket()

        End Select
    End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)

        'Update Request
        Select Case Button.Name
            Case "save"
                If val_fields() Then
                    If save_record() Then
                        'Since Request was inserted, it can be updateable
                        enable_pk_controls(False)
                        gSaleRequest.bFlag = General.modo.UpdateRecord
                    End If
                End If
            Case "exit"

                Me.Close()
        End Select

    End Sub
	
	Private Function val_fields() As Boolean
		val_fields = False
		
		If cbCustId.SelectedIndex < 0 Then
			MsgBox("Please select a Customer before continuing", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
			cbCustId.Focus()
			Exit Function
		End If
		
		If cbStoreNo.SelectedIndex < 0 Then
			MsgBox("Please select a Store before continuing", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
			cbStoreNo.Focus()
			Exit Function
		End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtSaleRequest.Text) Or Trim(txtSaleRequest.Text) = "" Then
			MsgBox("Please enter Request Number")
			txtSaleRequest.Focus()
			Exit Function
		Else
			txtSaleRequest.Text = quotation_mask(Trim(txtSaleRequest.Text))
		End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtTrackingNo.Text) Then
			txtTrackingNo.Text = ""
		Else
			txtTrackingNo.Text = quotation_mask(Trim(txtTrackingNo.Text))
		End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtNotes.Text) Then
			txtNotes.Text = ""
		Else
			txtNotes.Text = quotation_mask(Trim(txtNotes.Text))
		End If
		
		'Unique validation
		If gSaleRequest.bFlag = General.modo.NewRecord Then
			If existsRequest((cbCustId.Text), VB6.GetItemData(cbStoreNo, cbStoreNo.SelectedIndex), (txtSaleRequest.Text)) Then
				MsgBox("Request code already exists in database", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
				Exit Function
			End If
		End If
		
		val_fields = True
	End Function
	Private Function existsRequest(ByRef sCustId As String, ByRef nStoreId As Short, ByRef sSaleRequest As String) As Boolean
		
		existsRequest = False
		
		sStmt = "SELECT DISTINCT 1 FROM SaleRequest " & " WHERE cust_id = '" & sCustId & "'" & " AND store_id = " & Str(nStoreId) & " AND request_no = '" & sSaleRequest & "' "
		
		
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.Rows.Count > 0 Then
            existsRequest = True
        End If

		
	End Function
	Private Function save_record() As Boolean
		Dim nRecords As Short
		Dim nRequestSeq As Short
		Dim cmLocal As New ADODB.Command
		nRecords = 0
		
		save_record = False
		
		Select Case gSaleRequest.bFlag
			Case General.modo.NewRecord
				nRequestSeq = get_table_sequence("SaleRequest", "request_seq")
				
				sStmt = " INSERT INTO SaleRequest (request_seq, cust_id, store_id, " & " request_no, request_date, response_date, tracking_no, notes) " & " VALUES (?, ?, ?, ?, ?, ?, ?, ?)"
				
				cmLocal.CommandType = ADODB.CommandTypeEnum.adCmdText
				cmLocal.CommandText = sStmt
				
				
                cmLocal.Parameters.Append(cmLocal.CreateParameter("request_seq", DbType.Int32, ParameterDirection.Input, 4, nRequestSeq))
                cmLocal.Parameters.Append(cmLocal.CreateParameter("cust_id", SqlDbType.VarChar, ParameterDirection.Input, 2, cbCustId.Text))
                cmLocal.Parameters.Append(cmLocal.CreateParameter("store_id", DbType.Int32, ParameterDirection.Input, 4, VB6.GetItemData(cbStoreNo, cbStoreNo.SelectedIndex)))
                cmLocal.Parameters.Append(cmLocal.CreateParameter("request_no", DbType.String, ParameterDirection.Input, 50, quotation_mask((txtSaleRequest.Text))))
                cmLocal.Parameters.Append(cmLocal.CreateParameter("request_date", ADODB.DataTypeEnum.adDate, ParameterDirection.Input, 10, dtRequestDate.Value))
                cmLocal.Parameters.Append(cmLocal.CreateParameter("response_date", ADODB.DataTypeEnum.adDate, ParameterDirection.Input, 10, dtResponseDate.Value))
                cmLocal.Parameters.Append(cmLocal.CreateParameter("tracking_no", DbType.String, ParameterDirection.Input, 80, quotation_mask((txtTrackingNo.Text))))
                cmLocal.Parameters.Append(cmLocal.CreateParameter("notes", DbType.String, ParameterDirection.Input, 500, quotation_mask((txtNotes.Text))))

                cmLocal.let_ActiveConnection(cn)
                cmLocal.Execute(nRecords)
                If nRecords > 0 Then
                    'gSaleRequest.bFlag = modo.SavedRecord
                    gSaleRequest.nRequestSeq = nRequestSeq
                    MsgBox("Sale Request was saved successfully", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
                Else
                    MsgBox("Record was not inserted. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")

                End If

            Case General.modo.UpdateRecord
                sStmt = " UPDATE SaleRequest " & " SET request_date = ? , " & "     response_date =  ?, " & "     tracking_no = ?, " & "     notes = ? " & " WHERE request_seq = ? "

                cmLocal.CommandType = ADODB.CommandTypeEnum.adCmdText
                cmLocal.CommandText = sStmt

                cmLocal.Parameters.Append(cmLocal.CreateParameter("request_date", ADODB.DataTypeEnum.adDate, ParameterDirection.Input, 10, dtRequestDate.Value))
                cmLocal.Parameters.Append(cmLocal.CreateParameter("response_date", ADODB.DataTypeEnum.adDate, ParameterDirection.Input, 10, dtResponseDate.Value))
                cmLocal.Parameters.Append(cmLocal.CreateParameter("tracking_no", DbType.String, ParameterDirection.Input, 80, quotation_mask((txtTrackingNo.Text))))
                cmLocal.Parameters.Append(cmLocal.CreateParameter("notes", DbType.String, ParameterDirection.Input, 500, quotation_mask((txtNotes.Text))))
                cmLocal.Parameters.Append(cmLocal.CreateParameter("request_seq", DbType.Int32, ParameterDirection.Input, 4, gSaleRequest.nRequestSeq))

                cmLocal.let_ActiveConnection(cn)
                cmLocal.Execute(nRecords)
                'MsgBox "Request:" + Str(gSaleRequest.nRequestSeq)

                If nRecords > 0 Then
                    'gSaleRequest.bFlag = modo.SavedRecord
                    MsgBox("Sale Request was updated successfully", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
                Else
                    MsgBox("Record was not updated. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")

                End If


        End Select
		
		'UPGRADE_NOTE: Object cmLocal may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		cmLocal = Nothing
		save_record = True
	End Function
	
	
	Private Function getStoreName(ByRef sCustId As String, ByRef nStoreId As Short) As String
		
		getStoreName = ""
		
		sStmt = "SELECT store_name FROM store WHERE cust_id = '" & sCustId & "' " & " AND store_id = " & Str(nStoreId)
		
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.Rows.Count > 0 Then
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If Not IsDBNull(rs.Rows(0).Item("store_name").Value) Then
                getStoreName = rs.Rows(0).Item("store_name").Value
            End If
        End If
		
		
		
		
	End Function
	
	Private Sub enable_pk_controls(ByRef bOption As Boolean)
		
		cbCustName.Enabled = bOption
		'UPGRADE_ISSUE: ComboBox property cbCustName.Locked was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'cbCustName.Locked = Not bOption
		
		cbStoreNo.Enabled = bOption
		'UPGRADE_ISSUE: ComboBox property cbStoreNo.Locked was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'cbStoreNo.Locked = Not bOption
		
		txtSaleRequest.Enabled = bOption
		txtSaleRequest.ReadOnly = Not bOption
		
	End Sub
End Class