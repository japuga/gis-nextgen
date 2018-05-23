Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Friend Class frmCheck
	Inherits System.Windows.Forms.Form
    Private rsForm As DataTable
    Private rsPending As DataTable
    Private rsSelected As DataTable
    Private rsClone As DataTable
	Private sdfTotal As StdFormat.StdDataFormat
	Private sBankCustSeq As String
	Private bBankInfo As Boolean
	
	
	'UPGRADE_WARNING: Event cbBankAccount.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbBankAccount_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbBankAccount.SelectedIndexChanged
		sBankCustSeq = CStr(VB6.GetItemData(cbBankAccount, cbBankAccount.SelectedIndex))
		'load_check_no
		txtCheckNo.Text = CStr(get_check_no(VB6.GetItemData(cbBankAccount, cbBankAccount.SelectedIndex)))
		If txtCheckNo.Text = "0" Then
			txtCheckNo.Text = ""
		End If
	End Sub
	'UPGRADE_WARNING: Event cbBankName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbBankName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbBankName.SelectedIndexChanged
		load_bank_account(cbBankAccount, cbCustomer.Text, VB6.GetItemData(cbBankName, cbBankName.SelectedIndex))
		
	End Sub
	
	'UPGRADE_WARNING: Event cbCardBankName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCardBankName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCardBankName.SelectedIndexChanged
		load_card_number(cbCardNumber, VB6.GetItemData(cbCardBankName, cbCardBankName.SelectedIndex))
		
	End Sub
	
	'UPGRADE_WARNING: Event cbCustomer.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustomer_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustomer.SelectedIndexChanged
		cbCustomerName.SelectedIndex = cbCustomer.SelectedIndex
		load_vendor()
		init_dg()
		load_bank_info2()
	End Sub
	
	'UPGRADE_WARNING: Event cbState.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbState_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbState.SelectedIndexChanged
		'Rel1.3.2
		init_dg()
		
	End Sub
	
	'UPGRADE_WARNING: Event cbVendor.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbVendor_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbVendor.SelectedIndexChanged
		load_vend_pay_address(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex))
		init_dg()
		
	End Sub
	Private Sub load_vend_pay_address(ByRef nVendId As Short)
		
		On Error GoTo ErrorHandler
		'1.8.4 Agregado vend_pay_city y vend_pay_zip
		sStmt = "SELECT DISTINCT RTRIM(vend_pay_address) +' '+" & " RTRIM(vend_pay_city) + ' '+ RTRIM(vend_pay_zip) AS FullAddress," & " vend_pay_address, vend_pay_city, vend_pay_zip " & " FROM VBranch" & " WHERE vend_id = " & Str(nVendId) & " ORDER BY FullAddress "
		load_cb_query2(cbVendPayment, sStmt, 1, True)
		
		
		sStmt = "SELECT DISTINCT vend_pay_address, RTRIM(vend_pay_address) +' '+" & " RTRIM(vend_pay_city) + ' '+ RTRIM(vend_pay_zip) AS FullAddress," & " vend_pay_city, vend_pay_zip " & " FROM VBranch" & " WHERE vend_id = " & Str(nVendId) & " ORDER BY FullAddress "
		load_cb_query2(cbVendPayAddress, sStmt, 1, True)
		
		sStmt = "SELECT DISTINCT vend_pay_city, RTRIM(vend_pay_address) +' '+" & " RTRIM(vend_pay_city) + ' '+ RTRIM(vend_pay_zip) AS FullAddress," & " vend_pay_address, vend_pay_zip " & " FROM VBranch" & " WHERE vend_id = " & Str(nVendId) & " ORDER BY FullAddress "
		load_cb_query2(cbVendPayCity, sStmt, 1, True)
		
		sStmt = "SELECT DISTINCT vend_pay_zip, RTRIM(vend_pay_address) +' '+" & " RTRIM(vend_pay_city) + ' '+ RTRIM(vend_pay_zip) AS FullAddress," & " vend_pay_address, vend_pay_city " & " FROM VBranch" & " WHERE vend_id = " & Str(nVendId) & " ORDER BY FullAddress "
		load_cb_query2(cbVendPayZip, sStmt, 1, True)
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "Load_vend_pay_address")
		MsgBox("Failed to load Vendor Payment Address." & "Review log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
	End Sub
	
	'UPGRADE_WARNING: Event cbVendPayment.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbVendPayment_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbVendPayment.SelectedIndexChanged
		cbVendPayAddress.SelectedIndex = cbVendPayment.SelectedIndex
		cbVendPayCity.SelectedIndex = cbVendPayment.SelectedIndex
		cbVendPayZip.SelectedIndex = cbVendPayment.SelectedIndex
		init_dg()
	End Sub
	
	Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click
		dgPending_DblClick(dgPending, New System.EventArgs())
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	
	Private Sub cmdDrop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDrop.Click
		dgSelected_DblClick(dgSelected, New System.EventArgs())
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If obCheck.Checked Then
			'Check
			If valid_check_data Then
				gbCheck = True
				Me.Close()
			End If
		Else
			'Credit Card
			If valid_card_data Then
				gbCheck = False
				save_card_payment()
				Me.Close()
			End If
		End If
		
	End Sub
	'Determina si existen facturas para generar el cheque
	Private Function valid_card_data() As Boolean
		
		On Error GoTo ErrorHandler
		
		valid_card_data = False
		
		
        If rsSelected.Rows.Count <= 0 Then
            MsgBox("There is not enough information for Payment." & vbCrLf & "Please select one or more invoices.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Warning")
            Exit Function
        End If
		
		If CDbl(txtAmount.Text) <= 0 Then
			MsgBox("There is not enough information to complete Payment.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			Exit Function
		End If
		
		
		If cbCardNumber.SelectedIndex < 0 Then
			MsgBox("There is not Credit Card information for this selection.", MsgBoxStyle.Information + MsgBoxStyle.OKCancel, " Warning")
			cbCardNumber.Focus()
			Exit Function
		End If
		
		
		If txtAuthorizationCode.Text = "" Then
			MsgBox("Please enter the Transaction Authorization Code", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "Warning")
			txtAuthorizationCode.Focus()
			Exit Function
        Else
            '2015.02.23.begin
            'Removed authorization code check
            'If tran_dup(VB6.GetItemData(cbCardNumber, cbCardNumber.SelectedIndex), txtAuthorizationCode.Text) Then

            '        MsgBox("Authorization code is duplicate. Please verify and try again")
            '       txtAuthorizationCode.Focus()
            '      Exit Function
            ' End If
            '2015.02.23.end
		End If
		
		
		valid_card_data = True
		Exit Function
		
ErrorHandler: 
		save_error("frmCheck", "valid_card_data")
		
	End Function
	
	Private Sub cmdVBranch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVBranch.Click
		show_vbranch()
	End Sub
	Private Sub show_vbranch()
		
		If cbVendor.SelectedIndex >= 0 And cbVendPayAddress.SelectedIndex >= 0 Then
			gVendor.sVendName = cbVendor.Text
			gVendor.nVendId = VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)
			gVendor.sVendPayAddress = cbVendPayAddress.Text
			
			VB6.ShowForm(frmVBranchBrowse, VB6.FormShowConstants.Modal, Me)
		Else
			MsgBox("You must first select a Vendor and Address before attempting this command.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
		End If
		
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Text1.Text = "Selected:" & Str(rsSelected.Rows.Count)
        Text1.Text = Text1.Text & " Pending:" & Str(rsPending.Rows.Count)
	End Sub
	
	
	
    Private Sub dgPending_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        add_dgSelected()

    End Sub
    Private Sub dgPending_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPending.CellDoubleClick
        add_dgSelected()
    End Sub
	
    Private Sub dgSelected_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        del_dgSelected()
    End Sub


    Private Sub dgSelected_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelected.CellDoubleClick
        del_dgSelected()
    End Sub

    
	
	Private Sub frmCheck_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		load_comp()
	End Sub
	Private Sub init_vars()
		
		sdfTotal = New StdFormat.StdDataFormat
		
		gbCheck = False
		txtAmount.Text = CStr(0)
		txtAuthorizationCode.Text = ""
		
		obCheck.Checked = True
        obCreditCard.Checked = False
        dtTranDate.Value = Today
		
		gVendor.nVendId = -1
		gVendor.sVendName = ""
		gVendor.sVendPayAddress = ""
		
		
	End Sub
	'Carga los componentes de la forma con datos apropiados
	Private Sub load_comp()
		
		On Error GoTo ErrorHandler
		'Loading Customer Combo
		sStmt = "SELECT DISTINCT suser_data.cust_id, customer.cust_name " & "FROM suser_data, customer " & "WHERE suser_data.cust_id = customer.cust_id " & "AND suser_data.suser_name ='" & gsUser & "' " & " AND customer.invoice_pay_flag = 'T'" & "ORDER BY 1"
		
        rsForm = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsForm.Rows.Count < 1 Then
            Exit Sub
        End If
		load_cb2(cbCustomer, rsForm, 0)
		load_cb2(cbCustomerName, rsForm, 1)

        'Loading State information
        cbState.Items.Clear()
		cbState.Items.Insert(0, "<All>")
		sStmt = "SELECT state_id FROM state"
		load_cb_query2(cbState, sStmt, 1, False)
		
        cbState.SelectedIndex = 0
        cbCustomer.SelectedIndex = 0
        cbVendPayment.Items.Clear()
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_comp")
	End Sub
	'DEPRECATED by BankFunctions.load_vendor2
	'Loading Vendor combo
	Private Sub load_vendor()
		On Error GoTo ErrorHandler
		
		sStmt = "SELECT DISTINCT VBranch.vend_name," & "VBranch.vend_id " & "FROM VAccount, VBranch " & "WHERE VAccount.vend_seq = VBranch.vend_seq " & "AND VAccount.cust_id ='" & Trim(cbCustomer.Text) & "' " & " ORDER BY VBranch.vend_name "
		
		load_cb_query2(cbVendor, sStmt, 2, True)
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_vendor")
		MsgBox("Unable to load Vendor info. Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Error")
		
	End Sub
	'Funcion que inicializa los datagrids con datos de acuerdo a
	'Vendor, Customer y State
	Private Sub init_dg()
		load_dgPending()
		init_dgSelected()
		
		
	End Sub
	
	'Pending Invoices
	Public Sub load_dgPending()
		Dim sVendSeq As String
		
		On Error GoTo ErrorHandler
		
		'Rel1.3.2 Se elimino el estado (cbState)
		'If cbCustomer.ListIndex <> -1 _
		''    And cbVendor.ListIndex <> -1 _
		''    And cbState.ListIndex <> -1 _
		''Then
		If cbCustomer.SelectedIndex >= 0 And cbVendor.SelectedIndex >= 0 And cbVendPayAddress.SelectedIndex >= 0 Then
			'Listado de Vendedores cuya direccion de pago es cbVendPayAddress
			sVendSeq = get_vend_seq(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex), cbVendPayAddress.Text, cbVendPayCity.Text, cbVendPayZip.Text)
			'Selecciona facturas de las tiendas que pertenecen a un cliente
			'en un estado determinado.
			'sStmt = "SELECT Store.store_id, Store.store_number AS 'Store'," + _
			'"VInvoice.account_no AS 'Account', " + _
			'"VInvoice.invoice_no AS 'Invoice', " + _
			'"VInvoice.total AS Total " + _
			'"FROM VInvoice, Store " + _
			'"WHERE VInvoice.store_id = Store.store_id " + _
			'"AND VInvoice.cust_id =Store.cust_id " + _
			'"AND VInvoice.vinvoice_status = 'CRE' " + _
			'"AND VInvoice.cust_id ='" + Trim(cbCustomer) + "' " + _
			'"AND VInvoice.vend_seq =" + Str(cbVendor.ItemData(cbVendor.ListIndex)) + " "
			sStmt = "SELECT Store.store_id, Store.store_number AS 'Store'," & "VInvoice.account_no AS 'Account', " & "VInvoice.invoice_no AS 'Invoice', " & "VInvoice.total AS Total, VAccount.account_mask, " & " VInvoice.vend_seq " & "FROM VInvoice, Store, VAccount " & "WHERE VInvoice.store_id = Store.store_id " & "AND VInvoice.cust_id =Store.cust_id " & " AND VAccount.account_no = VInvoice.account_no " & " AND VAccount.cust_id = VInvoice.cust_id " & " AND VAccount.store_id = VInvoice.store_id " & " AND VAccount.vend_seq = VInvoice.vend_seq " & "AND VInvoice.vinvoice_status = 'CRE' " & "AND VInvoice.cust_id ='" & Trim(cbCustomer.Text) & "' " & "AND VInvoice.vend_seq IN (" & sVendSeq & ") "
			
			
			'Estado
			If cbState.SelectedIndex = 0 Then
				'Usuario selecciono todos los estados
			Else
				sStmt = Trim(sStmt) & " AND Store.state_id = '" & Trim(cbState.Text) & "'"
			End If
			
			
			'Order By
			sStmt = sStmt & " ORDER BY Store.store_number, VInvoice.account_no, " & " VInvoice.invoice_no"
		Else
			'Condicion para encerar el DataGrid
			sStmt = "SELECT Store.store_id, Store.store_number AS 'Store'," & "VInvoice.account_no AS 'Account', " & "VInvoice.invoice_no AS 'Invoice', " & "VInvoice.total AS Total, VAccount.account_mask, " & " VInvoice.vend_seq " & "FROM VInvoice, Store, VAccount " & "WHERE VInvoice.store_id = Store.store_id " & "AND VInvoice.cust_id =Store.cust_id " & " AND VAccount.account_no = VInvoice.account_no " & " AND VAccount.cust_id = VInvoice.cust_id " & " AND VAccount.store_id = VInvoice.store_id " & " AND VAccount.vend_seq = VInvoice.vend_seq " & "AND Store.cust_id ='NULL'"
			
		End If
		
        rsPending = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)
        dgPending.DataSource = Nothing
        dgPending.Refresh()
        'dgPending.Rows.Clear()
		dgPending.DataSource = rsPending
		set_fonts(dgPending) 'Establecer el ancho de las columnas
		'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        dgPending.Refresh()
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_dgPending")
		MsgBox("An error ccurred while loading Pending Invoices info." & vbCrLf & "Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM error")
	End Sub
    Private Sub set_fonts(ByRef dg As DataGridView)
        On Error GoTo ErrorHandler

        dg.Columns("store_id").Visible = False
        dg.Columns("account_mask").Visible = False
        dg.Columns("vend_seq").Visible = False
        dg.Columns("Store").Width = VB6.TwipsToPixelsX(800)
        dg.Columns("Account").Width = VB6.TwipsToPixelsX(1000)
        dg.Columns("Invoice").Width = VB6.TwipsToPixelsX(700)
        dg.Columns("Total").Width = VB6.TwipsToPixelsX(700)
        dg.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight ' = MSDataGridLib.AlignmentConstants.dbgRight
        sdfTotal.Format = "#,###,###.00"
        dg.Columns("Total").DefaultCellStyle.Format = "#,###,###.00" ' sdfTotal
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "set_fonts")
    End Sub
	'Limpia el datagrid de facturas seleccionadas y reinicia el recordset
	Private Sub init_dgSelected()
		'Set dgSelected.DataSource = Nothing
		'dgSelected.Refresh
		
		On Error GoTo ErrorHandler
		
        sStmt = "SELECT Store.store_id, Store.store_number AS 'Store'," & "VInvoice.account_no AS 'Account', " & "VInvoice.invoice_no AS 'Invoice', " & "VInvoice.total AS Total, VAccount.account_mask, " & " VInvoice.vend_seq " & "FROM VInvoice, Store, VAccount " & "WHERE VInvoice.store_id = Store.store_id " & "AND VInvoice.cust_id =Store.cust_id " & " AND VAccount.account_no = VInvoice.account_no " & " AND VAccount.cust_id = VInvoice.cust_id " & " AND VAccount.store_id = VInvoice.store_id " & " AND VAccount.vend_seq = VInvoice.vend_seq " & "AND Store.cust_id ='NULL'"
		
        rsSelected = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)

        dgSelected.DataSource = Nothing
        dgSelected.Refresh()
        'dgSelected.Rows.Clear() 'ClearFields()
		dgSelected.DataSource = rsSelected

        dgSelected.Refresh()
		set_fonts(dgSelected)
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "init_dgSelected :Failed to initialize")
	End Sub
	'Procedimiento que agrega los registros seleccionados
	'de dgPending al dgSelected
	Private Sub add_dgSelected()
		Dim nRecSelected As Short
        Dim vRow As Integer
        Dim rowCount As Integer
        'Dim X As Object
		
		
        nRecSelected = dgPending.SelectedRows.Count 'rsSelected.Rows.Count

        If nRecSelected = 0 Then
            If dgPending.SelectedCells.Count > 0 Then
                dgPending.Rows(dgPending.CurrentCell.RowIndex).Selected = True
            End If
        End If



        For rowCount = 0 To dgPending.SelectedRows.Count - 1
            vRow = dgPending.SelectedRows(0).Index
            If nRecSelected > MAX_CHECK_INVOICE Then
                Exit For
            Else
                'rsPending.Bookmark = vRow
                nRecSelected = nRecSelected + 1

                If Not verify_vendor(cbCustomer.Text, rsPending.Rows(vRow).Item("vend_seq"), rsPending.Rows(vRow).Item("Invoice")) Then
                    Exit Sub
                End If
                Dim drow As DataRow = rsSelected.NewRow

                drow.Item("store_id") = dgPending.Rows(vRow).Cells("store_id").Value
                drow.Item("Store") = dgPending.Rows(vRow).Cells("Store").Value
                drow.Item("Account") = dgPending.Rows(vRow).Cells("Account").Value
                drow.Item("Invoice") = dgPending.Rows(vRow).Cells("Invoice").Value
                drow.Item("Total") = dgPending.Rows(vRow).Cells("Total").Value
                drow.Item("account_mask") = dgPending.Rows(vRow).Cells("account_mask").Value
                drow.Item("vend_seq") = dgPending.Rows(vRow).Cells("vend_seq").Value

                'rsSelected.item("store_id").Value = rsPending.item("store_id").Value
                'rsSelected.item("Store").Value = rsPending.item("Store").Value
                'rsSelected.item("Account").Value = rsPending.item("Account").Value
                'rsSelected.item("Invoice").Value = rsPending.item("Invoice").Value
                'rsSelected("Invoice") = dgPending.Columns("Invoice").Value
                'rsSelected.item("Total").Value = rsPending.item("Total").Value
                'rsSelected.item("account_mask").Value = rsPending.item("account_mask").Value
                'rsSelected.item("vend_seq").Value = rsPending.item("vend_seq").Value

                If dgPending.Rows(vRow).Cells("Total").Value.ToString = "" Then
                    drow.Item("Total") = 0
                Else
                    drow.Item("Total") = dgPending.Rows(vRow).Cells("Total").Value
                End If
                'If (dgPending.Columns("Total").Text = "") Then
                '    rsSelected("Total") = 0
                'Else
                '    rsSelected("Total") = dgPending.Columns("Total").Text
                'End If

                'rsSelected.Update()
                rsSelected.Rows.Add(drow)
                'Bug #1
                'UPGRADE_WARNING: Couldn't resolve default property of object rsSelected.Bookmark. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'dgSelected.Bookmark = rsSelected.Bookmark
                calc_amount()
                Dim remRows As DataRow() = rsPending.Select("store_id = " + drow.Item("store_id").ToString)
                If remRows.Length > 0 Then
                    rsPending.Rows.Remove(remRows(0))
                End If

                End If
        Next rowCount

        dgPending.Sort(dgPending.Columns("Store"), System.ComponentModel.ListSortDirection.Ascending)
        dgSelected.Sort(dgSelected.Columns("Store"), System.ComponentModel.ListSortDirection.Ascending)
		
	End Sub
	'Antes de agregar una factura al dgSelected se verifica
	'que no genere cheques duplicados si el QB Vendor es diferente
	Private Function verify_vendor(ByRef sCustId As String, ByRef nVendSeq As Short, ByRef sInvoiceNo As String) As Boolean
		Dim sVendSeq As String
		
		'UPGRADE_NOTE: Object rsClone may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rsClone = Nothing
        rsClone = rsSelected.Copy
		
		On Error GoTo ErrorHandler
		
		verify_vendor = True
		
		'Verificar que el registro seleccionado tenga un vendor en qb_vendor_vbranch
		If Not verify_qb_vendor(sCustId, nVendSeq) Then
			MsgBox("Invoice's vendor missing QuickBooks setting.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			verify_vendor = False
			Exit Function
		End If
		
		'Verificar que no hayas mas de un Vendor al mismo tiempo
		sVendSeq = Str(nVendSeq) & ","
        For row As Integer = 0 To rsClone.Rows.Count - 1
            sVendSeq = sVendSeq & Str(rsClone.Rows(row).Item("vend_seq")) & ","

        Next row
		
		
		'Nada que verificar
		If Len(sVendSeq) = 0 Then
			Exit Function
		End If
		
		'Elimina ultima coma
		sVendSeq = VB.Left(sVendSeq, Len(sVendSeq) - 1)
		
		'Todos las agencias del vendor deben tener el mismo QB vendor
		sStmt = "SELECT DISTINCT name FROM qb_vendor_vbranch " & " WHERE qb_vendor_vbranch.qb_group_id =" & "   (SELECT qb_group_id FROM customer " & "   WHERE cust_id='" & sCustId & "')" & " AND vend_seq IN (" & sVendSeq & ")"
		'MsgBox sStmt

        rsClone = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsClone.Rows.Count > 1 Then
            verify_vendor = False
            sStmt = ""
            For row As Integer = 0 To rsClone.Rows.Count - 1
                sStmt = sStmt + rsClone.Rows(row).Item("name") + vbCrLf
            Next

            sStmt = "This invoice " & Trim(sInvoiceNo) & " " & "can not be paid in this Check " & vbCrLf & "because a QuickBooks Vendor inconsistency was found." & vbCrLf & "Vendor: " & Trim(cbVendor.Text) & vbCrLf & "is associated to the following QB Vendors:" & vbCrLf & sStmt & vbCrLf & vbCrLf & "This will generate duplicate checks" & vbCrLf & "Action Required: Be sure that all Vendor Branches are " & "related to the same QB Vendor"
            MsgBox(sStmt, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
        End If

        Exit Function

ErrorHandler:
        verify_vendor = False
        save_error(Me.Name, "verify_vendor")
        MsgBox("Unexpected error while verifying vendor data." & vbCrLf & "Review log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
		
	End Function
	'Verifica que exista un vendor en QB_Vendor_Vbranch
	'TRUE       ok
	'FALSE      No hay qb_vendor_vbranch
	Private Function verify_qb_vendor(ByRef sCustId As String, ByRef nVendSeq As Short) As Boolean
		
		On Error GoTo ErrorHandler
		
		verify_qb_vendor = True
		sStmt = "SELECT COUNT(*) FROM qb_vendor_vbranch " & " WHERE vend_seq =" & Str(nVendSeq) & " " & " AND qb_group_id = (SELECT qb_group_id FROM customer " & "   WHERE cust_id ='" & sCustId & "')"
		
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.Rows.Count > 0 Then
            If rs.Rows(0).Item(0) = 0 Then
                verify_qb_vendor = False
            End If
        End If
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "verify_qb_vendor")
		MsgBox("Unexpected found while Verifying QuickBooks data." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Function
	
	
	'Elimina registros de dgSelected
	Private Sub del_dgSelected()
        Dim vRow As Integer
		
        For vRow = 0 To dgSelected.SelectedRows.Count - 1
            'UPGRADE_WARNING: Couldn't resolve default property of object vRow. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'rsSelected.Bookmark = vRow 'Muevo el recordset a la fila seleccionada
            Dim drow As DataRow = rsPending.NewRow
            Dim rowIndex As Integer = dgSelected.SelectedRows(0).Index
            drow.Item("store_id") = dgSelected.Rows(rowIndex).Cells("store_id").Value
            drow.Item("Store") = dgSelected.Rows(rowIndex).Cells("Store").Value
            drow.Item("Account") = dgSelected.Rows(rowIndex).Cells("Account").Value
            drow.Item("Invoice") = dgSelected.Rows(rowIndex).Cells("Invoice").Value
            drow.Item("Total") = dgSelected.Rows(rowIndex).Cells("Total").Value
            drow.Item("account_mask") = dgSelected.Rows(rowIndex).Cells("account_mask").Value
            drow.Item("vend_seq") = dgSelected.Rows(rowIndex).Cells("vend_seq").Value


            'rsPending.item("store_id").Value = rsSelected.item("store_id").Value
            'rsPending.item("Store").Value = rsSelected.item("Store").Value
            'rsPending.item("Account").Value = rsSelected.item("Account").Value
            'rsPending.item("Invoice").Value = rsSelected.item("Invoice").Value
            'rsPending.item("Total").Value = rsSelected.item("Total").Value
            'rsPending.item("account_mask").Value = rsSelected.item("account_mask").Value
            'rsPending.item("vend_seq").Value = rsSelected.item("vend_seq").Value
            rsPending.Rows.Add(drow)
            rsPending.Select("", "store, account, invoice")
            dgPending.Sort(dgPending.Columns("Store"), System.ComponentModel.ListSortDirection.Ascending)

            'rsSelected.Bookmark = vRow
            Dim remDataRow As DataRow() = rsSelected.Select("store_id = " + drow.Item("store_id").ToString)
            If remDataRow.Length > 0 Then
                rsSelected.Rows.Remove(remDataRow(0)) '(ADODB.AffectEnum.adAffectCurrent)
            End If
            dgSelected.Sort(dgSelected.Columns("Store"), System.ComponentModel.ListSortDirection.Ascending)


        Next vRow
		calc_amount()
	End Sub
	Private Sub calc_amount()
		
		On Error GoTo ErrorHandler
		
        If rsSelected.Rows.Count < 0 Then
            txtAmount.Text = CStr(0)
            Exit Sub
        End If
        If rsSelected.Rows.Count = 0 Then
            txtAmount.Text = CStr(0)
            Exit Sub
        End If
		
        txtAmount.Text = CStr(0)
        For row As Integer = 0 To rsSelected.Rows.Count - 1
            If Not IsDBNull(rsSelected.Rows(row).Item("Total")) And rsSelected.Rows(row).Item("Total").ToString() <> "" Then
                txtAmount.Text = txtAmount.Text + rsSelected.Rows(row).Item("Total")
            End If
        Next row
		
		Exit Sub
		
ErrorHandler: 
		txtAmount.Text = CStr(0)
		save_error("frmCheck", "calc_amount")
	End Sub
	'Gets information about the bank and Account and Check Number
	Private Sub load_bank_info()
		Dim e As ADODB.Error
		
		On Error GoTo ErrorHandler
		
		txtCheckNo.Text = ""
		txtAmount.Text = ""
		
		bBankInfo = False
		sStmt = "SELECT BankAccount.bank_account, Bank.bank_name, " & "BankAccount.bank_cust_seq " & "FROM BankAccount, Bank " & "WHERE BankAccount.bank_id = Bank.bank_id " & "AND BankAccount.cust_id ='" & Trim(cbCustomer.Text) & "' "
		
        rsForm = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsForm.Rows.Count < 1 Then
            Exit Sub
        End If
        If rsForm.Rows.Count = 0 Then
            Exit Sub
        End If
		
		bBankInfo = True
        sBankCustSeq = rsForm.Rows(0).Item("bank_cust_seq")
		
		
		'Check Info
		sStmt = "SELECT MAX(check_no) FROM BCheck " & "WHERE bank_cust_seq = " & sBankCustSeq
		
        rsForm = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		'Error al ejecutar query
        If Not rsForm.Rows.Count > 0 Then
            Exit Sub
        End If
		
		'Query no retorno datos
        If rsForm.Rows.Count = 0 Then
            txtCheckNo.Text = CStr(1)
        Else
            If rsForm.Rows(0).Item(0) <> "" Then
                txtCheckNo.Text = rsForm.Rows(0).Item(0) + 1
            End If
        End If
		
		Exit Sub
		
ErrorHandler: 
		bBankInfo = False
		save_error("frmCheck", "load_bank_info")
		MsgBox("An unexpected error ocurred while loading account info." & vbCrLf & "Check log file for details", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Sub
	'Rel 1.7.2
	'Including Bank and Account Combo Box
	Private Sub load_bank_info2()
		
		On Error GoTo ErrorHandler
		
		txtCheckNo.Text = ""
		txtAmount.Text = ""
		
		If cbCustomer.SelectedIndex < 0 Then
			Exit Sub
		End If
		
		load_bank(cbBankName, cbCustomer.Text)
		load_card_bank(cbCardBankName)
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_bank_info2")
		MsgBox("An unexpected error was found while loading Bank Info." & "Review log file for details", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
		
	End Sub
	Private Sub load_check_no()
		On Error GoTo ErrorHandler
		
		'Check Info
		sStmt = "SELECT MAX(check_no) FROM BCheck " & "WHERE bank_cust_seq = " & Str(VB6.GetItemData(cbBankAccount, cbBankAccount.SelectedIndex))
		
        rsForm = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		'Error al ejecutar query
        If Not rsForm.Rows.Count > 0 Then
            Exit Sub
        End If
		
		'Query no retorno datos
        If rsForm.Rows.Count = 0 Or IsDBNull(rsForm.Rows(0).Item(0)) Then
            txtCheckNo.Text = CStr(1)
        Else
            If rsForm.Rows(0).Item(0) <> "" Then
                txtCheckNo.Text = rsForm.Rows(0).Item(0) + 1
            End If
        End If
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_check_no")
		MsgBox("Unable to get check number.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
	End Sub
	'Determina si existen facturas para generar el cheque
	Private Function valid_check_data() As Boolean
		
		On Error GoTo ErrorHandler
		
		valid_check_data = False
		
		'Verificar que solo se impriman 16 detalles
        If rsSelected.Rows.Count > 16 Then
            MsgBox("You can choose up to 16 invoices for this Check." & vbCrLf & "Remove some of them to continue.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
            Exit Function
        End If
		
        If rsSelected.Rows.Count <= 0 Then
            MsgBox("There is not enough information to create Check.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Warning")
            Exit Function
        End If
		
		If CDbl(txtAmount.Text) <= 0 Then
			MsgBox("There is not enough information to create Check.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			Exit Function
		End If
		
		'If bBankInfo = False Then
		If cbBankAccount.SelectedIndex < 0 Then
			MsgBox("There is not Bank Information for this selection.", MsgBoxStyle.Information + MsgBoxStyle.OKCancel, " Warning")
			Exit Function
		End If
		
		If txtCheckNo.Text = "" Then
			MsgBox("Please enter Check No.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Warning")
			Exit Function
		Else
			'Verifica que cheque no exista en Bcheck
			If check_dup(txtCheckNo.Text) Then
				MsgBox("Check No. was already printed. Try another Number.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
				Exit Function
			End If
		End If
		
		'Guardo los datos para el preview
		gCheck.reprint = False 'Se imprime por primera vez
		gCheck.bSameCheck = False 'Se imprime por primera vez
		gCheck.CheckNo = CInt(txtCheckNo.Text)
		gCheck.BankCustSeq = sBankCustSeq
		'gCheck.VendorSeq = cbVendor.ItemData(cbVendor.ListIndex)

        gCheck.VendorSeq = rsSelected.Rows(0).Item("vend_seq")
		'Rel1.3.2 Se selecciona el nombre del vendor en el string del cbVendor
		'gCheck.VendorName = Left(cbVendor, InStr(cbVendor, "-") - 1)
		gCheck.VendorName = cbVendor.Text
		gCheck.CustId = cbCustomer.Text
		gCheck.Amount = CDbl(txtAmount.Text)
		gCheck.Date_Renamed = Today
		gCheck.CustName = cbCustomerName.Text
        gCheck.rsStore = rsSelected.Copy()
		
		valid_check_data = True
		Exit Function
		
ErrorHandler: 
		save_error("frmCheck", "valid_check_data")
		
	End Function
	'Verifica que el numero de cheque no se haya repetido
	Private Function check_dup(ByRef sCheckNo As String) As Boolean
		
		On Error GoTo ErrorHandler
		
		check_dup = False
		sStmt = "SELECT check_no FROM BCheck " & " WHERE bank_cust_seq =" & Str(VB6.GetItemData(cbBankAccount, cbBankAccount.SelectedIndex)) & " AND check_no =" & sCheckNo
		
        rsForm = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsForm.Rows.Count > 0 Then
            check_dup = True
        Else
            check_dup = False
        End If

        Exit Function

ErrorHandler:
        save_error(Me.Name, "check_dup")
        MsgBox("Failed to verify Check Dups. Review log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
	End Function
	
	'UPGRADE_WARNING: Event obCheck.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub obCheck_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles obCheck.CheckedChanged
		If eventSender.Checked Then
			frCheck.Visible = obCheck.Checked
			frCreditCard.Visible = Not obCheck.Checked
		End If
	End Sub
	
	'UPGRADE_WARNING: Event obCreditCard.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub obCreditCard_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles obCreditCard.CheckedChanged
		If eventSender.Checked Then
			frCheck.Visible = Not obCreditCard.Checked
			frCreditCard.Visible = obCreditCard.Checked
		End If
	End Sub
	
	Private Sub save_card_payment()
		Dim nTranSeq As Short
		Dim nTranDetNo As Short
        Dim nDbTran As SqlTransaction
		Dim nRecords As Short
		
        sStmt = "SELECT MAX(tran_seq) " & " FROM BTransaction "

        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If IsDBNull(rs.Rows(0).Item(0)) Then
            nTranSeq = 1
        Else
            nTranSeq = rs.Rows(0).Item(0) + 1
        End If



        'Credit Card Transaction Header
        nDbTran = cn.BeginTransaction()

        sStmt = "INSERT INTO BTransaction (tran_seq, cust_id, vend_id, " & _
                "card_seq, authorization_code, tran_date, tran_amount) " & _
                " VALUES (" & Str(nTranSeq) & "," & "'" & cbCustomer.Text & "'," & _
                Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & "," & _
                Str(VB6.GetItemData(cbCardNumber, cbCardNumber.SelectedIndex)) & ",'" & Trim(txtAuthorizationCode.Text) & "'," & "'" & CStr(dtTranDate.Value) & "'," & Str(CDbl(txtAmount.Text)) & ")"

        cm = cn.CreateCommand '.let_ActiveConnection(cn)
        cm.CommandType = CommandType.Text
        cm.CommandText = sStmt
        cm.Transaction = nDbTran
        nRecords = cm.ExecuteNonQuery()
        If nRecords > 0 Then
            'Update Credit Card Balance
            sStmt = "UPDATE CreditCard " & " SET card_balance=card_balance +" & txtAmount.Text & " WHERE card_seq =" & Str(VB6.GetItemData(cbCardNumber, cbCardNumber.SelectedIndex))
            cm.CommandText = sStmt
            nRecords = cm.ExecuteNonQuery()
            If nRecords > 0 Then
                'ok
            Else
                nDbTran.Rollback()
                MsgBox("Failed to update Credit Card Balance." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        Else
            nDbTran.Rollback()
            MsgBox("Failed to insert in Transaction table. " & vbCrLf & "Review logfile for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Sub
        End If


        'Credit Card Transaction Details
        For row As Integer = 0 To rsSelected.Rows.Count - 1
            nTranDetNo = get_tran_det_no(nTranSeq, nDbTran)

            sStmt = "INSERT INTO BTransactionDet (tran_seq, " & "tran_det_no, cust_id, store_id, " & "invoice_no, account_no, vend_seq, invoice_total)" & " VALUES (" & Str(nTranSeq) & "," & Str(nTranDetNo) & "," & "'" & cbCustomer.Text & "'," & Str(rsSelected.Rows(row).Item("store_id")) & "," & "'" + rsSelected.Rows(row).Item("Invoice") + "'," + "'" + rsSelected.Rows(row).Item("Account") + "'," + Str(rsSelected.Rows(row).Item("vend_seq")) + "," + Str(rsSelected.Rows(row).Item("Total")) + ")"

            cm.CommandText = sStmt
            cm.Transaction = nDbTran
            nRecords = cm.ExecuteNonQuery()
            If nRecords > 0 Then
                'ok
            Else
                MsgBox("Failed to insert in Transaction Detail table. " & vbCrLf & "Review logfile for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                nDbTran.Rollback()
                Exit For
            End If

            sStmt = "UPDATE vInvoice  " & " SET vinvoice_status = 'PRT', " & " change_time = getdate () , " & _
                    " change_user = '" & gsUser & "' " & " WHERE invoice_no = '" + rsSelected.Rows(row).Item("Invoice") + "' " + _
                    " AND cust_id = '" + cbCustomer.Text + "' " + " AND store_id = " + Str(rsSelected.Rows(row).Item("store_id")) + _
                    " AND account_no = '" + rsSelected.Rows(row).Item("Account") + "' " + _
                    " AND vend_seq = " + Str(rsSelected.Rows(row).Item("vend_seq"))
            cm.CommandText = sStmt
            cm.Transaction = nDbTran
            nRecords = cm.ExecuteNonQuery()
            If nRecords > 0 Then
                'ok
            Else
                MsgBox("Failed to update invoice status table. " & vbCrLf & "Invoice:" + rsSelected.Rows(row).Item("Invoice") + "Review logfile for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                nDbTran.Rollback()

                Exit For
            End If
        Next row
        


        nDbTran.Commit()
        MsgBox("Transaction was saved successfully.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")

        Exit Sub

ErrorHandler:
        save_error(Me.Name, "save_card_payment")

        nDbTran.Rollback()

        MsgBox("Unexpected error found while saving Credit Card information." & vbCrLf & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
	End Sub
	
	Private Function tran_dup(ByRef nCardSeq As Short, ByRef sAuthorizationCode As String) As Boolean
		
		tran_dup = False
		
		sStmt = "SELECT card_seq, authorization_code " & " FROM BTransaction " & " WHERE card_seq =" & Str(nCardSeq) & " AND authorization_code ='" & Trim(txtAuthorizationCode.Text) & "'"
		
        rs = getDataTable(sStmt) 'Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.Rows.Count > 0 Then
            tran_dup = True
        End If

        Exit Function

ErrorHandler:
        save_error(Me.Name, "tran_dup")
		
	End Function
	
	
    Private Function get_tran_det_no(ByRef nTranSeq As Short, Optional ByRef sqlTrans As SqlTransaction = Nothing) As Short
        Dim nTranDetNo As Short

        sStmt = "SELECT MAX(tran_det_no) " & " FROM BTransactionDet " & " WHERE tran_seq=" & Str(nTranSeq)

        If IsNothing(sqlTrans) Then
            rs = getDataTable(sStmt)
        Else
            rs = getDataTable(sStmt, sqlTrans)
        End If

        If IsDBNull(rs.Rows(0).Item(0)) Then
            nTranDetNo = 1
        Else
            nTranDetNo = rs.Rows(0).Item(0) + 1
        End If


        get_tran_det_no = nTranDetNo
        Exit Function

ErrorHandler:
        save_error(Me.Name, "get_tran_det_no")
        MsgBox("Failed to obtain Transaction Detail Number." & vbCrLf & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
    End Function

  
    
    Private Sub frCreditCard_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frCreditCard.Enter

    End Sub
End Class