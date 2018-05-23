Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmCheckBrowse
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private rsLocalInv As DataTable
    Private rsNull As DataTable
	'UPGRADE_WARNING: Event cbBank.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbBank_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbBank.SelectedIndexChanged
		If cbBank.SelectedIndex >= 0 Then
			load_bankAccount((VB6.GetItemData(cbBank, cbBank.SelectedIndex)))
		End If
	End Sub
	'Load combo with data from bank
	Private Sub load_bankAccount(ByRef nBankId As Short)
		
		On Error GoTo ErrorHandler
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Not IsDbNull(cbCustId.Text) Then
			If Len(cbCustId.Text) > 0 Then
				sStmt = "SELECT bank_account,bank_cust_seq FROM bankAccount " & " WHERE bank_id = " & Str(nBankId) & " AND cust_id='" & cbCustId.Text & "'"
			End If
		Else
			sStmt = "SELECT bank_account,bank_cust_seq FROM bankAccount " & " WHERE bank_id = " & Str(nBankId)
		End If
		
		load_cb_query2(cbBankAccount, sStmt, 2, True)
		
		If cbBankAccount.Items.Count > 0 Then
			cbBankAccount.SelectedIndex = 0
		End If
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_bankAccount")
		MsgBox("Failed to load BankAccount info. Review log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
		
	End Sub
	
	'UPGRADE_WARNING: Event cbCustId.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustId_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustId.SelectedIndexChanged
		cbCustName.SelectedIndex = cbCustId.SelectedIndex
		If cbBank.SelectedIndex >= 0 Then
			load_bankAccount((VB6.GetItemData(cbBank, cbBank.SelectedIndex)))
		End If
		
	End Sub
	
	'UPGRADE_WARNING: Event chCheckRange.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chCheckRange_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chCheckRange.CheckStateChanged
		txtFromCheck.Enabled = Not frChecks.Enabled
		txtToCheck.Enabled = Not frChecks.Enabled
		frChecks.Enabled = Not frChecks.Enabled
		
		If frChecks.Enabled Then
			txtFromCheck.BackColor = System.Drawing.SystemColors.Window
			txtToCheck.BackColor = System.Drawing.SystemColors.Window
		Else
			txtFromCheck.BackColor = System.Drawing.SystemColors.ScrollBar
			txtToCheck.BackColor = System.Drawing.SystemColors.ScrollBar
		End If
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
		'Rangos de Cheques
		If chCheckRange.CheckState = System.Windows.Forms.CheckState.Checked Then
			If Len(txtFromCheck.Text) > 0 Then
				If IsNumeric(txtFromCheck.Text) Then
					'ok
				Else
					MsgBox("Incorrect value was entered on Check From.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
					val_criteria = False
					Exit Function
				End If
			Else
				MsgBox("Check From must be entered.")
				val_criteria = False
				Exit Function
			End If
			
			If Len(txtToCheck.Text) > 0 Then
				If IsNumeric(txtToCheck.Text) Then
					'ok
				Else
					MsgBox("Incorrect value was entered on Check To.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
					val_criteria = False
					Exit Function
				End If
			Else
				MsgBox("Check To must be entered.")
				val_criteria = False
				Exit Function
			End If
			
			If Int(CDbl(txtFromCheck.Text)) > Int(CDbl(txtToCheck.Text)) Then
				MsgBox("From Check must be less than To Check.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
				val_criteria = False
				Exit Function
			End If
		End If
		
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
	
	Private Sub frmCheckBrowse_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		load_controls()
		set_defaults()
	End Sub
	
	Private Sub init_vars()
        rsLocal = Nothing
        rsLocalInv = Nothing
		
		'UPGRADE_WARNING: TextBox property txtFromCheck.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtFromCheck.Maxlength = 8
		'UPGRADE_WARNING: TextBox property txtToCheck.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtToCheck.Maxlength = 8
		
		chCheckRange.CheckState = System.Windows.Forms.CheckState.Unchecked
		txtFromCheck.BackColor = System.Drawing.SystemColors.ScrollBar
		txtToCheck.BackColor = System.Drawing.SystemColors.ScrollBar
		frChecks.Enabled = False
		
		chDates.CheckState = System.Windows.Forms.CheckState.Unchecked
		dtStart.Value = Today
		dtEnd.Value = Today
		frDates.Enabled = False
		
		'Limpia Variable global gCheck
		clear_gCheck()
	End Sub
	Private Sub load_controls()
		
		On Error GoTo ErrorHandler
		'Combo Customer
		sStmt = "SELECT cust_name, cust_id FROM customer ORDER BY cust_id"
		load_cb_query2(cbCustName, sStmt, 1, True)
		
		sStmt = "SELECT cust_id FROM customer ORDER BY cust_id"
		load_cb_query2(cbCustId, sStmt, 1, True)
		
		'Combo Vendors, solo vendors que aparecen en facturas
		'sStmt = "SELECT RTRIM(vend_name) +' - '+RTRIM( vend_area)," + _
		'" vend_seq " + _
		'" FROM vbranch " + _
		'" WHERE vend_seq IN (SELECT DISTINCT vend_seq FROM vinvoice )" + _
		'" ORDER BY vend_name"
        sStmt = "SELECT DISTINCT vend_name, vend_id  FROM VBranch " & " ORDER BY vend_name"
        cbVendor.Items.Clear()
		cbVendor.Items.Insert(0, "<All>")
		VB6.SetItemData(cbVendor, 0, 0)
		load_cb_query2(cbVendor, sStmt, 2, False)
		
		'Combo Bancos
		sStmt = "SELECT DISTINCT RTRIM(bank.bank_name), " & " bank.bank_id " & " FROM  bank " & " WHERE Bank.bank_status ='ACTIVE'"
		
        load_cb_query2(cbBank, sStmt, 2, True)

        txtFromCheck.Text = ""
        txtToCheck.Text = ""
		Exit Sub
		
ErrorHandler: 
		save_error("frmCheckBrowse", "load_controls")
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
		
		If cbBank.Items.Count > 0 Then
			cbBank.SelectedIndex = 0
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
		
		'cbVendor.ListIndex=0 entonces ALL Vendors
		If cbVendor.SelectedIndex > 0 Then
			'sWhere = Trim(sWhere) + _
			'" AND Bcheck.vend_seq =" + Str(cbVendor.ItemData(cbVendor.ListIndex))
			sWhere = Trim(sWhere) & " AND Bcheck.vend_seq IN ( " & " SELECT vend_seq FROM VBranch " & " WHERE vend_id =" & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & ")"
		End If
		
		'1.7.2
		'sWhere = " AND bcheck.cust_id ='" + Trim(cbCustId) + "' " + _
		'" AND vinvoice.vend_seq =" + Str(cbVendor.ItemData(cbVendor.ListIndex)) + _
		'" AND vinvoice.month_period ='" + Trim(cbMonthPeriod) + "' " + _
		'" AND vinvoice.year_period=" + cbYearPeriod
		
		'Bancos
		If cbBank.SelectedIndex >= 0 And cbBankAccount.SelectedIndex >= 0 Then
			sWhere = Trim(sWhere) & "AND Bcheck.bank_cust_seq =" & Str(VB6.GetItemData(cbBankAccount, cbBankAccount.SelectedIndex))
		End If
		
		'Rango de Cheques
		If chCheckRange.CheckState = System.Windows.Forms.CheckState.Checked Then
			sWhere = Trim(sWhere) & " AND Bcheck.check_no >= " & txtFromCheck.Text & " AND Bcheck.check_no <= " & txtToCheck.Text
		End If
		
		'Rango de fechas
		If chDates.CheckState = System.Windows.Forms.CheckState.Checked Then
            sWhere = Trim(sWhere) & " AND Bcheck.check_date BETWEEN '" & CStr(dtStart.Value) & "' " & " AND '" & CStr(dtEnd.Value) & "'"
			
		End If
		get_criteria = sWhere
	End Function
	'Completa el query  usando los criterios de seleccion
	Private Sub search_data(ByRef sWhere As String)
		Dim nIndex As Short
        Dim cmd As SqlCommand = cn.CreateCommand()
		On Error GoTo ErrorHandler
		
        sStmt = "SELECT DISTINCT RTRIM(vbranch.vend_name) AS Vendor, " & " Bcheck.check_no AS 'Check No',  Bcheck.check_date AS 'Check Date', " & _
                    " Bcheck.check_amount AS Amount ,  " & " Bcheck.bank_cust_seq,Bcheck.check_no, " & _
                    " Bcheck.cust_id, Customer.cust_name, VBranch.vend_name " & _
                " FROM Bcheck, Vbranch, Customer " & _
                " WHERE Bcheck.vend_seq = VBranch.vend_seq " & _
                " AND Customer.cust_id = Bcheck.cust_id " & _
                " AND Bcheck.voided_flag = 'N' " & Trim(sWhere)
        cmd.CommandText = sStmt
		'MsgBox sStmt
		'Set dgChecks.DataSource = Nothing

        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count < 1 Then
            MsgBox("There is no data for such criteria, please try again.", MsgBoxStyle.OkOnly, "GLM Message")
            Exit Sub
        Else
            'Set dgChecks.DataSource = rsLocal
            grsCheck = rsLocal
            gCheckReQuery = sStmt
        End If
		

        'Mostrar resultados
        General.gCheckBrowseDetMode = General.CheckBrowseDetMode.CheckReprint
        VB6.ShowForm(frmCheckBrowseDet, VB6.FormShowConstants.Modal, Me)
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "search_data")
        MsgBox("Failed to retrieve Checks List., Review log file for details.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
	End Sub
	
	
	Private Sub txtFromCheck_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFromCheck.KeyPress
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
	
	Private Sub txtToCheck_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtToCheck.KeyPress
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
End Class