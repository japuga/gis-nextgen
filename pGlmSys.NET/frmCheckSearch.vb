Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmCheckSearch
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private rsLocalInv As DataTable
    Private rsNull As DataTable
	
	
	'UPGRADE_WARNING: Event cbAccount.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbAccount_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbAccount.SelectedIndexChanged
		cbAccountNo.SelectedIndex = cbAccount.SelectedIndex
		
	End Sub
	
	'UPGRADE_WARNING: Event cbCustId.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustId_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustId.SelectedIndexChanged
		cbCustName.SelectedIndex = cbCustId.SelectedIndex
        cbAccount.Items.Clear()
        cbInvoiceNo.Items.Clear()

		If cbCustId.SelectedIndex >= 0 And cbVendor.SelectedIndex >= 0 Then
			load_account(cbCustId.Text, VB6.GetItemData(cbVendor, cbVendor.SelectedIndex))
		End If
		
	End Sub
	
	'UPGRADE_WARNING: Event cbVendor.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbVendor_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbVendor.SelectedIndexChanged
		If cbCustId.SelectedIndex >= 0 And cbVendor.SelectedIndex >= 0 Then
			load_account(cbCustId.Text, VB6.GetItemData(cbVendor, cbVendor.SelectedIndex))
			load_invoice(cbCustId.Text, VB6.GetItemData(cbVendor, cbVendor.SelectedIndex))
		End If
		
	End Sub
	'Carga Combo Account basado en los Proveedores disponibles
	Private Sub load_account(ByRef sCustId As String, ByRef nVendId As Short)
		
		On Error GoTo ErrorHandler
		sStmt = "SELECT DISTINCT VAccount.account_mask, VInvoice.account_no " & " FROM Vinvoice, VAccount " & " WHERE VInvoice.account_no = VAccount.account_no " & " AND VInvoice.cust_id = VAccount.cust_id " & " AND VInvoice.store_id = VAccount.store_id " & " AND VInvoice.vend_seq = VAccount.vend_seq " & " AND VInvoice.cust_id = '" & sCustId & "' " & " AND VInvoice.vend_seq IN (SELECT vend_seq FROM VBranch " & " WHERE vend_id =" & Str(nVendId) & ")" & " ORDER BY VInvoice.account_no "
		cbAccount.Items.Clear()
		cbAccount.Items.Insert(0, "<All>")
		load_cb_query2(cbAccount, sStmt, 1, False)
		
		sStmt = "SELECT DISTINCT VInvoice.account_no, VAccount.account_mask " & " FROM Vinvoice, VAccount " & " WHERE VInvoice.account_no = VAccount.account_no " & " AND VInvoice.cust_id = VAccount.cust_id " & " AND VInvoice.store_id = VAccount.store_id " & " AND VInvoice.vend_seq = VAccount.vend_seq " & " AND VInvoice.cust_id = '" & sCustId & "' " & " AND VInvoice.vend_seq IN (SELECT vend_seq FROM VBranch " & " WHERE vend_id =" & Str(nVendId) & ")" & " ORDER BY VInvoice.account_no "
		cbAccountNo.Items.Clear()
		cbAccountNo.Items.Insert(0, "0")
		load_cb_query2(cbAccountNo, sStmt, 1, False)
		
		If cbAccount.Items.Count > 1 Then
            cbAccount.SelectedIndex = 0
            load_invoice(sCustId, nVendId)
		Else
			'Esto elimina <All> cuando no se retornaron registros
			cbAccount.Items.Clear()
			cbAccountNo.Items.Clear()
		End If
		
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_account")
		MsgBox("Internal error occurred when loading account info. " & "Please check log file for details")
		
	End Sub
	Private Sub load_invoice(ByRef sCustId As String, ByRef nVendId As Short)
		
		On Error GoTo ErrorHandler
		sStmt = "SELECT DISTINCT VInvoice.invoice_no, VAccount.account_mask " & " FROM Vinvoice, VAccount " & " WHERE VInvoice.account_no = VAccount.account_no " & " AND VInvoice.cust_id = VAccount.cust_id " & " AND VInvoice.store_id = VAccount.store_id " & " AND VInvoice.vend_seq = VAccount.vend_seq " & " AND VInvoice.cust_id = '" & sCustId & "' " & " AND VInvoice.vend_seq IN (SELECT vend_seq FROM VBranch " & " WHERE vend_id =" & Str(nVendId) & ")" & " ORDER BY VInvoice.invoice_no "
		cbInvoiceNo.Items.Clear()
		cbInvoiceNo.Items.Insert(0, "<All>")
		load_cb_query2(cbInvoiceNo, sStmt, 1, False)
		
		If cbInvoiceNo.Items.Count > 1 Then
			cbInvoiceNo.SelectedIndex = 0
		Else
			cbInvoiceNo.Items.Clear()
		End If
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_account")
		MsgBox("Internal error occurred when loading account info. " & "Please check log file for details")
		
	End Sub
	'UPGRADE_WARNING: Event chDates.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chDates_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chDates.CheckStateChanged
		dtStart.Enabled = Not frDates.Enabled
		dtEnd.Enabled = Not frDates.Enabled
		frDates.Enabled = Not frDates.Enabled
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub cmdSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSearch.Click
		Dim sWhere As String
		
		If val_criteria = True Then
			sWhere = get_criteria
			search_data((sWhere))
		End If
	End Sub
	'Verifica que los criterios de seleccion esten correctos
	Private Function val_criteria() As Boolean
		
		val_criteria = False
		
		'Rangos de Fechas
		If chDates.CheckState = System.Windows.Forms.CheckState.Checked Then
            If dtStart.Value > dtEnd.Value Then
                MsgBox("To-Date must be greater than From-Date.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                val_criteria = False
                Exit Function
            End If
		End If
		
		val_criteria = True
		Exit Function
		
ErrorHandler: 
		val_criteria = False
		save_error(Me.Name, "val_criteria")
		
	End Function
	
	Private Sub frmCheckSearch_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		load_controls()
		set_defaults()
	End Sub
	
	Private Sub init_vars()
        rsLocal = Nothing
        rsLocalInv = Nothing
		
		'txtFromCheck.MaxLength = 8
		'txtToCheck.MaxLength = 8
		
		'chCheckRange.Value = vbUnchecked
		'txtFromCheck.BackColor = vbScrollBars
		'txtToCheck.BackColor = vbScrollBars
		'frChecks.Enabled = False
		
		chDates.CheckState = System.Windows.Forms.CheckState.Unchecked
		dtStart.Value = Today
		dtEnd.Value = Today
		frDates.Enabled = False
		
		'Limpia Variable global gCheck
		'clear_gCheck
	End Sub
	Private Sub load_controls()
		
		On Error GoTo ErrorHandler
		'Combo Customer
		sStmt = "SELECT DISTINCT customer.cust_name, suser_data.cust_id " & " FROM customer, suser_data " & " WHERE customer.cust_id= suser_data.cust_id " & " AND suser_data.suser_name = '" & Trim(gsUser) & "'" & " ORDER BY suser_data.cust_id"
		load_cb_query2(cbCustName, sStmt, 1, True)
		
		sStmt = "SELECT DISTINCT suser_data.cust_id, customer.cust_name " & " FROM customer, suser_data " & " WHERE customer.cust_id= suser_data.cust_id " & " AND suser_data.suser_name = '" & Trim(gsUser) & "'" & " ORDER BY suser_data.cust_id"
		load_cb_query2(cbCustId, sStmt, 1, True)
		
		'Combo Vendors, solo vendors que aparecen en facturas
		sStmt = "SELECT DISTINCT vend_name, vend_id  FROM VBranch " & " ORDER BY vend_name"
		'08.02.03 Removido <All> para evitar largos queries a base de datos
		'cbVendor.AddItem "<All>", 0
		'cbVendor.ItemData(0) = 0
		'load_cb_query2 cbVendor, sStmt, 2, False
		load_cb_query2(cbVendor, sStmt, 2, True)
		
		Exit Sub
		
ErrorHandler: 
		save_error("frmCheckSearch", "load_controls")
		MsgBox("Error found when loading data. Review log file for details.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
	End Sub
	
	Private Sub set_defaults()
		
		On Error GoTo ErrorHandler
		
		If cbCustId.Items.Count > 0 Then
			cbCustId.SelectedIndex = 0
		End If
		
		If cbVendor.Items.Count > 0 Then
			cbVendor.SelectedIndex = 0
		End If
		
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "set_defaults")
		MsgBox("Failed setting defaults. Check log file for details.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
	End Sub
	
	'Forma la clausula WHERE del query
	Private Function get_criteria() As String
        Dim sWhere As String = ""
		
		If cbCustId.SelectedIndex >= 0 Then
			sWhere = Trim(sWhere) & " AND Bcheck.cust_id ='" & Trim(cbCustId.Text) & "' "
		End If
		
		
		If cbVendor.SelectedIndex >= 0 Then
			sWhere = Trim(sWhere) & " AND Bcheck.vend_seq IN ( " & " SELECT vend_seq FROM VBranch " & " WHERE vend_id =" & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & ")"
		End If
		
		'1.9.2
		'Account, cuando ListIndex=0 (All)
		If cbAccountNo.SelectedIndex > 0 Then
			sWhere = Trim(sWhere) & " AND BCheck.account_no = '" & Trim(cbAccountNo.Text) & "' "
		End If
		
		'Invoice
		If cbInvoiceNo.SelectedIndex > 0 Then
			sWhere = Trim(sWhere) & " AND BCheck.invoice_no = '" & Trim(cbInvoiceNo.Text) & "' "
		End If
		
		'1.7.2
		'Bancos
		'If cbBank.ListIndex >= 0 And cbBankAccount.ListIndex >= 0 Then
		'    sWhere = Trim(sWhere) + _
		''     "AND Bcheck.bank_cust_seq =" + Str(cbBankAccount.ItemData(cbBankAccount.ListIndex))
		'End If
		
		'Rango de Cheques
		'If chCheckRange.Value = vbChecked Then
		'    sWhere = Trim(sWhere) + _
		''        " AND Bcheck.check_no >= " + txtFromCheck + _
		''        " AND Bcheck.check_no <= " + txtToCheck
		'End If
		
		'Rango de fechas
		If chDates.CheckState = System.Windows.Forms.CheckState.Checked Then
            sWhere = Trim(sWhere) & " AND Bcheck.check_date BETWEEN '" & CStr(dtStart.Value) & "' " & " AND '" & CStr(dtEnd.Value) & "'"
			
		End If
		get_criteria = sWhere
	End Function
	'Completa el query  usando los criterios de seleccion
	Private Sub search_data(ByRef sWhere As String)
        'Dim nIndex As Short
		
        'On Error GoTo ErrorHandler
		
        sStmt = "SELECT DISTINCT RTRIM(vbranch.vend_name) AS Vendor, " & " Bcheck.check_no AS 'Check No',  Bcheck.check_date AS 'Check Date', " & _
                        " Bcheck.check_amount AS Amount ,  " & " Bcheck.bank_cust_seq,Bcheck.check_no, " & _
                        " Bcheck.cust_id, Customer.cust_name, VBranch.vend_name " & _
                " FROM Bcheck, Vbranch, Customer " & _
                " WHERE Bcheck.vend_seq = VBranch.vend_seq " & _
                    " AND Customer.cust_id = Bcheck.cust_id " & _
                    " AND Bcheck.voided_flag = 'N' " & Trim(sWhere)
		
		'MsgBox sStmt
		'Set dgChecks.DataSource = Nothing
        Try
            rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rsLocal.Rows.Count <= 0 Then
                MsgBox("There is no data for such criteria, please try again.", MsgBoxStyle.OkOnly, "GLM Message")
                Exit Sub
            Else
                'Set dgChecks.DataSource = rsLocal
                grsCheck = rsLocal
            End If
        Catch ex As Exception
            MsgBox("There was an error when retrieving data from database")
            Exit Sub
        End Try

		
		
		'Mostrar resultados
		General.gCheckBrowseDetMode = General.CheckBrowseDetMode.CheckBrowse
		VB6.ShowForm(frmCheckBrowseDet, VB6.FormShowConstants.Modal, Me)

		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "search_data")
		MsgBox("Failed to retrieve Checks List. Review log file for details.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
	End Sub
	
	
	Private Sub txtFromCheck_KeyPress(ByRef KeyAscii As Short)
		'Numeros:0-9 y Guion (-)
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 45 Then
			'Es numero
		Else
			KeyAscii = 0
		End If
		
	End Sub
	
	Private Sub txtToCheck_KeyPress(ByRef KeyAscii As Short)
		'Numeros:0-9 y Guion (-)
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 45 Then
			'Es numero
		Else
			KeyAscii = 0
		End If
		
	End Sub
End Class