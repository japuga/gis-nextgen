Option Strict Off
Option Explicit On
Friend Class frmInvoiceImport
	Inherits System.Windows.Forms.Form
    Public rsLocal As DataTable
    Dim custList As String

	
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		cbCustId.SelectedIndex = cbCustName.SelectedIndex
		
		load_vendors((cbCustId.Text))
		'validateAndLoadInvoices
	End Sub
	Private Sub load_vendors(ByRef sCustId As String)
		sStmt = "SELECT DISTINCT RTRIM(a.vend_name) + ' - ' + a.vend_area AS vend_name, a.vend_seq" & " FROM vbranch a, VInvoice  b " & " Where a.vend_seq = b.vend_seq " & " AND cust_id='" & sCustId & "'" & " ORDER BY vend_name "
		
		cbVendor.Items.Clear()
		cbVendor.Items.Insert(0, "<All>")
		load_cb_query4(cbVendor, sStmt, 2, False, 2000)
		
		cbVendor.SelectedIndex = 0
	End Sub
	
	Private Sub validateAndLoadInvoices()
		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
		
		If cbStatusFlag.Text = "NEW" Then
			validate_invoiceImport("'" & cbCustId.Text & "'")
		End If
		
		Me.Cursor = System.Windows.Forms.Cursors.Default
		
		load_dgInvoiceImport(False)
		
	End Sub
	'UPGRADE_WARNING: Event cbStatusDesc.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbStatusDesc_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbStatusDesc.SelectedIndexChanged
		
		cbStatusFlag.SelectedIndex = cbStatusDesc.SelectedIndex
		
	End Sub
	
	Private Sub frmInvoiceImport_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		Dim i As Short
        rsLocal = Nothing
		
        sStmt = "SELECT state_id FROM state ORDER BY state_id"
        cbState.Items.Clear()
		cbState.Items.Insert(0, "<All>")
		load_cb_query2(cbState, sStmt, 1, False)
		
		cbState.SelectedIndex = 0
		
		
		load_cb_customer(cbCustName, cbCustId, True)
		If cbCustId.Items.Count > 1 Then
			custList = ""
			
			
			'setMainStatusBarMessage ("Loading Laserfiche Invoices to Import")
			
			'frmMain.pbMain.Min = 0
			'frmMain.pbMain.Max = cbCustId.ListCount
			'frmMain.pbMain.Visible = True
			
			For i = 1 To cbCustId.Items.Count - 1
				cbCustId.SelectedIndex = i
				custList = custList & "'" & cbCustId.Text & "'"
				
                'frmMain.pbMain = i
				'validate_invoiceImport "'" + cbCustId.Text + "'"
				
				If i + 1 < cbCustId.Items.Count Then
					custList = custList & ","
				End If
			Next i
			
			'frmMain.pbMain.Visible = False
			'frmMain.pbMain.Min = 0
			
			'restoreMainStatusBarMessage
			
			If cbCustName.Items.Count > 1 Then
				cbCustName.SelectedIndex = 1
			Else
				cbCustName.SelectedIndex = 0
			End If
		End If
		
		sStmt = "SELECT field_option_desc, field_option FROM sdomain " & " WHERE domain_field ='lf2gis_status_flag' ORDER BY option_order"
		
		load_cb_query5(cbStatusDesc, sStmt, 0, True)
		
		load_cb_query5(cbStatusFlag, sStmt, 1, True)
		
		
		If gsUserType = CStr(General.UserType.Administrator) Then
			lbStatusFlag.Visible = True
			cbStatusDesc.Visible = True
		End If
		
		set_cb(cbStatusDesc, "New")
		
		load_dgInvoiceImport(True)
		
	End Sub
	
	Private Sub load_dgInvoiceImport(ByRef bInitFlag As Boolean)
		Dim stmt As String
		Dim sCustomer As String
		Dim sOrder As String
		
		If cbCustId.SelectedIndex > 0 Then
			sCustomer = "'" & cbCustId.Text & "'"
		Else
			'All
			sCustomer = custList
		End If
		
		If bInitFlag Then
			stmt = "SELECT a.cust_id 'Cust', b.state_id 'State', b.store_number 'Store No', c.vend_name 'Vendor', " & " a.account_no 'Account' , a.invoice_no 'Invoice', a.creation_date 'Creation Date', " & " a.store_id, a.vend_seq, b.state_id, a.status_flag 'Status' " & " FROM lf2gis_vinvoice a, store b, vbranch c " & " WHERE a.cust_id IN ('')" & " AND a.cust_id = b.cust_id " & " AND a.store_id = b.store_id " & " AND a.status_flag ='" & cbStatusFlag.Text & "' " & " AND a.vend_seq = c.vend_seq " & " ORDER BY 'Cust', 'Creation Date' desc"
		Else
			stmt = "SELECT a.cust_id 'Cust', b.state_id 'State',  b.store_number 'Store No', " & " RTRIM(c.vend_name) + ' - ' + c.vend_area  'Vendor', " & " a.account_no 'Account' , a.invoice_no 'Invoice', a.creation_date 'Creation Date', " & " a.store_id, a.vend_seq, b.state_id, a.status_flag 'Status' " & " FROM lf2gis_vinvoice a, store b, vbranch c " & " WHERE a.cust_id IN (" & sCustomer & ")" & " AND a.cust_id = b.cust_id " & " AND a.store_id = b.store_id " & " AND a.status_flag ='" & cbStatusFlag.Text & "' " & " AND a.vend_seq = c.vend_seq "
			
			'Vendor
			If cbVendor.SelectedIndex > 0 Then
				stmt = stmt & " AND a.vend_seq = " & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex))
			End If
			
			'Store
			If Len(Trim(txtStoreNumber.Text)) > 0 Then
				stmt = stmt & " AND b.store_number = '" & quotation_mask((txtStoreNumber.Text)) & "'"
			End If
			
			'State
			If cbState.SelectedIndex > 0 Then
				stmt = stmt & " AND b.state_id = '" & cbState.Text & "' "
			End If
			
			'Invoice
			If Len(Trim(txtInvoiceNo.Text)) > 0 Then
				stmt = stmt & " AND a.invoice_no =  '" & quotation_mask((txtInvoiceNo.Text)) & "' "
			End If
			
			'Account
			If Len(Trim(txtAccount.Text)) > 0 Then
				stmt = stmt & " AND a.account_no LIKE '%" & quotation_mask((txtAccount.Text)) & "%' "
			End If
			
			sOrder = " ORDER BY 'Cust', 'Creation Date' desc"
			
			stmt = stmt & sOrder
		End If
		
		
		
        rsLocal = getDataTable(stmt) '.Open(stmt, cn, ADODB.CursorTypeEnum.adOpenStatic)
		
        'If rsLocal.Rows.Count > 0 Then
        lbRecordCount.Text = "Total Records:" & Str(rsLocal.Rows.Count)

        dgPendingInvoices.DataSource = rsLocal
        dgPendingInvoices.Columns("store_id").Visible = False
        dgPendingInvoices.Columns("vend_seq").Visible = False
        dgPendingInvoices.Columns("state_id").Visible = False
        dgPendingInvoices.Columns("Vendor").Width = VB6.TwipsToPixelsX(3000)
        dgPendingInvoices.Columns("State").Width = VB6.TwipsToPixelsX(300)
        dgPendingInvoices.Columns("Store No").Width = VB6.TwipsToPixelsX(1200)
        dgPendingInvoices.Columns("Status").Visible = True
        If gsUserType <> CStr(General.UserType.Administrator) Then
            dgPendingInvoices.Columns("Status").Visible = False
        End If
        'End If
		
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)

        Select Case Button.Name
            Case "upload"
                If dgPendingInvoices.SelectedRows.Count = 0 Then
                    MsgBox("Please select at least one record to perform this action", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                    Exit Sub
                End If

                uploadToGis((dgPendingInvoices.SelectedRows(0).Cells("Cust").Value), _
                            (dgPendingInvoices.SelectedRows(0).Cells("store_id").Value), (dgPendingInvoices.SelectedRows(0).Cells("Store No").Value), _
                            (dgPendingInvoices.SelectedRows(0).Cells("vend_seq").Value), (dgPendingInvoices.SelectedRows(0).Cells("Account").Value), _
                            (dgPendingInvoices.SelectedRows(0).Cells("Invoice").Value), (dgPendingInvoices.SelectedRows(0).Cells("state_id").Value))


            Case "search"
                validateAndLoadInvoices()
            Case "exit"
                Me.Close()
        End Select


    End Sub
	
	
	Public Sub uploadToGis(ByRef sCustId As String, ByRef sStoreId As String, ByRef sStoreNumber As String, ByRef sVendSeq As String, ByRef sAccountNo As String, ByRef sInvoiceNo As String, ByRef sStateId As String)
		
		'Check if invoice is duplicate
		If isInvoiceDuplicate(sCustId, sStoreId, sVendSeq, sAccountNo, sInvoiceNo) Then
			
			update_lf2gis_vinvoice(sCustId, CShort(sStoreId), sAccountNo, CShort(sVendSeq), sInvoiceNo, "DUPLICATE", "Invoice already exists in DB")
			
			MsgBox("The selected invoice already exists in the database, it was marked as Duplicate." & vbCrLf & "Please try another.")
			
			load_dgInvoiceImport(False)
			
			Exit Sub
		End If
		
		'Populate Invoice form with header info
        frmInvoiceBooking.parentCaller = "frmInvoiceImport"
        frmInvoiceBooking.ShowDialog()
        frmInvoiceBooking.parentCaller = ""
        'VB6.ShowForm(frmInvoiceBooking, VB6.FormShowConstants.Modal, Me)
        'frmInvoiceBooking.Show()

        'frmInvoiceBooking.populateHeader(sCustId, sStoreId, sStoreNumber, sStateId, CShort(sVendSeq), sAccountNo, sInvoiceNo)
		
        'frmInvoiceBooking.bImportedFromLF = True
        'frmInvoiceBooking.btNew.Enabled = False
        'frmInvoiceBooking.btSave.Enabled = True
        'frmInvoiceBooking.btSearch.Enabled = False
        'frmInvoiceBooking.btDelete.Enabled = True


        'frmInvoiceBooking.Visible = False
        'VB6.ShowForm(frmInvoiceBooking, VB6.FormShowConstants.Modal, Me)
		
		load_dgInvoiceImport(False)
		
	End Sub
	
	Public Function isInvoiceDuplicate(ByRef sCustId As String, ByRef sStoreId As String, ByRef sVendSeq As String, ByRef sAccountNo As String, ByRef sInvoiceNo As String) As Boolean
		
		
		isInvoiceDuplicate = False
		
        sStmt = "SELECT count(*) FROM vInvoice WHERE cust_Id = '" & sCustId & "'" & _
                " AND store_id = " & sStoreId & " AND vend_seq = " & sVendSeq & " AND account_no = '" & sAccountNo & "' " & _
                " AND invoice_no = '" & sInvoiceNo & "' "
		
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic)
        If rs.Rows.Count Then
            If rs.Rows(0).Item(0) > 0 Then
                isInvoiceDuplicate = True
            End If
        End If
		
	End Function

    Private Sub btUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUpload.Click

        If dgPendingInvoices.SelectedRows.Count < 1 Then
            Try
                If Not Trim(dgPendingInvoices.Rows(dgPendingInvoices.SelectedCells(0).RowIndex).Cells("Cust").Value) = "" Then
                    dgPendingInvoices.Rows(dgPendingInvoices.SelectedCells(0).RowIndex).Selected = True
                End If
            Catch ex As Exception

            End Try
        End If

        If dgPendingInvoices.SelectedRows.Count = 0 Then
            MsgBox("Please select at least one record to perform this action", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Sub
        End If

        uploadToGis((dgPendingInvoices.SelectedRows(0).Cells("Cust").Value), _
                    (dgPendingInvoices.SelectedRows(0).Cells("store_id").Value), (dgPendingInvoices.SelectedRows(0).Cells("Store No").Value), _
                    (dgPendingInvoices.SelectedRows(0).Cells("vend_seq").Value), (dgPendingInvoices.SelectedRows(0).Cells("Account").Value), _
                    (dgPendingInvoices.SelectedRows(0).Cells("Invoice").Value), (dgPendingInvoices.SelectedRows(0).Cells("state_id").Value))


    End Sub

    Private Sub btSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSearch.Click
        validateAndLoadInvoices()
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub
    Public Function getCustId() As String
        Return "ggg"
    End Function
End Class