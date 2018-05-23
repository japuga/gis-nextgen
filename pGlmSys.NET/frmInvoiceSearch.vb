Option Strict Off
Option Explicit On
Friend Class frmInvoiceSearch
	Inherits System.Windows.Forms.Form
	'06.07.06   Fixed bug in load_vendor, combo was loading incorrect index
	Private sStr As String
	Private nCounter As Short
	
	'UPGRADE_WARNING: Event cbCustomer.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustomer_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustomer.SelectedIndexChanged
		
		load_state(cbCustomer.Text)
		load_vendor(cbCustomer)
		
	End Sub
	Private Sub load_state(ByRef sCustId As String)
		'Cargar combo State
		cbState.Items.Clear()
		cbState.Items.Insert(0, "<All>")
		
		If cbCustomer.SelectedIndex = 0 Then
			sStmt = "SELECT DISTINCT state_id FROM suser_data " & "WHERE suser_data.suser_name ='" & gsUser & "' "
		Else
			sStmt = "SELECT state_id FROM suser_data " & "WHERE suser_data.suser_name ='" & gsUser & "' " & "AND suser_data.cust_id ='" & sCustId & "' " & "ORDER BY 1"
		End If
		
		load_cb_query2(cbState, sStmt, 1, False)
		
		If cbState.Items.Count > 0 Then
			cbState.SelectedIndex = 0
		End If
	End Sub
	
    Private Sub ckDates_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ckDates.CheckStateChanged

        dtStart.Enabled = Not frDates.Enabled
        dtEnd.Enabled = Not frDates.Enabled
        frDates.Enabled = ckDates.Checked 'Not frDates.Enabled
    End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	'06.07.06 Added ORDER BY clause
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		Dim sWhere As String
		Dim e As ADODB.Error
		
		On Error GoTo ErrorHandler
		
		sWhere = " "
		
		'1.8.8 Added restriction to access data
		If Len(cbState.Text) = 2 Then
			sWhere = sWhere & "AND Store.state_id ='" & Trim(cbState.Text) & "' "
		Else
			'<All>
			If cbCustomer.SelectedIndex = 0 Then
				'All states of all customers for this User.
				sWhere = sWhere & " AND Store.state_id IN " & "(SELECT DISTINCT state_Id FROM suser_data " & " WHERE  suser_name='" & Trim(gsUser) & "')"
			Else
				If cbCustomer.SelectedIndex > 0 Then
					sWhere = sWhere & " AND Store.state_id IN " & "(SELECT state_id  FROM suser_data " & " WHERE cust_id='" & Trim(cbCustomer.Text) & "' " & " AND suser_name='" & Trim(gsUser) & "')"
				End If
			End If
		End If
		
		If Len(cbCustomer.Text) = 2 Then
			sWhere = sWhere & "AND VInvoice.cust_id ='" & Trim(cbCustomer.Text) & "' "
		Else
			'<All>
			sWhere = sWhere & " AND VInvoice.cust_id IN " & "(SELECT DISTINCT cust_id FROM suser_data " & " WHERE suser_name ='" & Trim(gsUser) & "') "
		End If
		
		If Len(txtStore.Text) > 0 Then
			sWhere = sWhere & "AND Store.store_number LIKE '" & Trim(txtStore.Text) & "%' "
		End If
		
		'If cbVendor.Text <> "ALL" And Len(cbVendor) > 0 Then
		If cbVendor.SelectedIndex > 0 Then
			sWhere = sWhere & "AND VInvoice.vend_seq=" & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & " "
		End If
		
		If Len(txtInvoice.Text) > 0 Then
			sWhere = sWhere & "AND VInvoice.invoice_no LIKE '" & quotation_mask(Trim(txtInvoice.Text)) & "%' "
		End If
		
		If frDates.Enabled Then
            If (IsDate(dtStart.Value) And IsDate(dtEnd.Value)) Then
                sWhere = sWhere & "AND VInvoice.vinvoice_date  BETWEEN '" & CStr(dtStart.Value) & "' AND '" & CStr(dtEnd.Value) & "'  "
            End If
		End If
		
		sStr = "SELECT Customer.cust_name as Customer, " & "Store.state_id as State," & "Store.store_number as Store, " & "Store.store_address as Address," & "VInvoice.invoice_no as Invoice, " & "VInvoice.vinvoice_date as Date, " & "VBranch.vend_name as Vendor, " & "VInvoice.account_no as Account, " & "VInvoice.cust_id, VInvoice.store_id, VInvoice.vend_seq, " & "VInvoice.month_period , VInvoice.year_period, VInvoice.period_seq, " & " Period.period_name Period, " & " VInvoice.group_seq, VInvoice.work_order, VInvoice.sc, VInvoice.extc " & "FROM VInvoice, Customer, Store, VBranch, Period " & "WHERE VInvoice.cust_id = Customer.cust_id " & "AND VInvoice.store_id = Store.store_id " & "AND VInvoice.cust_id = Store.cust_id " & "AND VInvoice.vend_seq = VBranch.vend_seq " & "AND vInvoice.period_seq = Period.period_seq " & Trim(sWhere)
		
		'MsgBox sStr
		gInvoiceHelp.sSql = sStr
		
		sStmt = "ORDER BY 'Customer', State, Store, Vendor "
		gInvoiceHelp.sOrderBy = sStmt
		
		frmHelpCustomer.nMode = frmHelpCustomer.options.adInvoiceHelp
		VB6.ShowForm(frmHelpCustomer, VB6.FormShowConstants.Modal, Me)
		
		'Unload Me
		Exit Sub
		
ErrorHandler: 
		MsgBox(Err.Description)
		save_error("frmInvoiceSearch", "cmdOk_click")
	End Sub
	
	Private Sub frmInvoiceSearch_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Inicializo componentes
        dtStart.Value = Today
        dtEnd.Value = Today
		
		init_vars()
		'load_vendor
	End Sub
	Private Sub init_vars()
		'Customer
		sStmt = "SELECT DISTINCT cust_id FROM suser_data " & "WHERE suser_data.suser_name ='" & gsUser & "' " & "ORDER BY 1"
		cbCustomer.Items.Insert(0, "<All>")
		load_cb_query2(cbCustomer, sStmt, 1, False)
		
		If cbCustomer.Items.Count > 0 Then
			cbCustomer.SelectedIndex = 0
		End If
		
	End Sub
	'Copia el combo de la forma InvoiceBooking. Esto un query a la base
	Private Sub copy_combo(ByRef cbTx As System.Windows.Forms.ComboBox, ByRef cbRx As System.Windows.Forms.ComboBox)
		Dim i As Short
		
		cbRx.Items.Clear()
		
		cbRx.Items.Insert(0, "ALL")
		For i = 0 To cbTx.Items.Count - 1
			cbRx.Items.Insert(i + 1, VB6.GetItemString(cbTx, i))
		Next i
		
	End Sub
	'Carga el combo con datos del vendor
	Private Sub load_vendor(ByRef sCustId As Object)
		cbVendor.Items.Clear()
		
		cbVendor.Items.Insert(0, "<All>")
		
		sStr = "SELECT DISTINCT VBranch.vend_seq, " & "RTRIM(VBranch.vend_name)+' - '+" & "RTRIM(VBranch.vend_area)AS vname " & "FROM VAccount, VBranch " & "WHERE VAccount.vend_seq = VBranch.vend_seq "
		

        If sCustId.ToString <> "<All>" Then
            sStr = sStr & "AND VAccount.cust_id ='" + sCustId.ToString + "' "
        End If
		
		sStr = sStr & " ORDER BY vname"
		

        rs = getDataTable(sStr) '.Open(sStr, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        nCounter = 1
        For row As Integer = 0 To rs.Rows.Count - 1
            cbVendor.Items.Add(rs.Rows(row).Item("vname"))
            VB6.SetItemData(cbVendor, nCounter, rs.Rows(row).Item("vend_seq"))
            nCounter = nCounter + 1
        Next row
		
		
		If cbVendor.Items.Count > 0 Then
			cbVendor.SelectedIndex = 0
		End If
	End Sub
	
	
	
	Private Sub opDates_Click()
		frDates.Enabled = Not frDates.Enabled
	End Sub
End Class