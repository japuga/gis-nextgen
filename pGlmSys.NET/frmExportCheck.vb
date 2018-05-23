Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmExportCheck
	Inherits System.Windows.Forms.Form
	'Variables locales del modulo
    Private rsLocal As DataTable
	Private sStmt As String
	Private sRadioFlag As String 'Bandera que indica cual radio esta seleccionado
    Public rsCustCheck As DataTable
    Public rsCheckList As DataTable
	
	
	'Inicializa variables del modulo/forma
	Private Sub init_vars()
        'rsLocal = SqlDataReader
        'rsCustCheck = SqlDataReader
        'rsCheckList = SqlDataReader
		
		sStmt = ""
        dtFrom.Value = Today
        dtTo.Value = Today
		
		set_limits()
	End Sub
	Private Sub set_limits()
		'UPGRADE_WARNING: TextBox property txtCheckFrom.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtCheckFrom.Maxlength = 8
		'UPGRADE_WARNING: TextBox property txtCheckTo.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtCheckTo.Maxlength = 8
	End Sub
	'Carga los controles de la forma como: combos,listas, etc
	Private Sub load_controls()
        On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand()
		'Informacion del Customer
		
        'jp.pending.begin
        cbCustName.Items.Clear()
        cbCustId.Items.Clear()
		cbCustName.Items.Insert(0, "<All>")
		cbCustId.Items.Insert(0, "<All>")
		'jp.pending.end
		
        sStmt = "SELECT cust_name, cust_id FROM customer ORDER BY cust_name"
        cmd.CommandText = sStmt
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader()
		load_cb3(cbCustName, rsLocal, 0, False)
		load_cb3(cbCustId, rsLocal, 1, False) 'Segundo campo del query
		
		'Mostramos por defecto el primer elemento de la lista
		cbCustName.SelectedIndex = 0
		
		
		'Informacion de Vendors
		sStmt = "SELECT vend_name, vend_id FROM vendor ORDER BY vend_name"
		load_cb_query(cbVendor, sStmt, 2)
		cbVendor.SelectedIndex = 0 'Apunto al primer vendor
        'rsLocal.Close()
		
ErrorHandler: 
		save_error("frmExportCheck", "load_controls")
		
	End Sub
	'Funcion que muestra la lista de cheques seleccionados
	Private Sub export_check_list()
		Dim sTmp As String
		'Dim sGroup As String
		'Dim sVendName As String
		'Dim sQBVendName As String
		'Dim sQBaccount As String
		'Dim nBankCustSeq As Integer
		'Dim sBankName As String
		Dim sStmtLocal As String
		
        Dim aGroup() As gDumpUDT = {New gDumpUDT()}

		Dim sSelect As String
		Dim idx As Short
		Dim numCustomers As Short
		Dim sSubQuery As String
        Dim sSingleQuery As String
        Dim cmd As SqlCommand = cn.CreateCommand()
		Dim i As Short
		
		On Error GoTo ErrorHandler
		
		'Get list of Customer-QBGroup pairs
		
		If cbCustId.Text = "<All>" Then
			'Just customers with checks and matching user criteria
			sStmt = " SELECT customer.qb_group_id, customer.cust_id " & " FROM customer, qb_group " & " WHERE customer.qb_group_id = qb_group.qb_group_id " & " AND customer.cust_id IN "
			
			sSubQuery = "SELECT DISTINCT  bcheck.cust_id " & "   FROM bcheck, vbranch " & "   WHERE bcheck.vend_seq = vbranch.vend_seq  "
			
			If chExported.CheckState <> System.Windows.Forms.CheckState.Checked Then
				sSubQuery = Trim(sSubQuery) & " AND bcheck.qb_exported_flag IS NULL "
			End If
			sSubQuery = Trim(sSubQuery) & get_criteria()
			
			sStmt = Trim(sStmt) & " ( " & sSubQuery & " ) "
			
		Else
			'Single customer
			sStmt = " SELECT customer.qb_group_id, customer.cust_id " & " FROM customer, qb_group " & " WHERE customer.qb_group_id = qb_group.qb_group_id " & " AND customer.cust_id = '" & Trim(cbCustId.Text) & "'"
			
		End If
        cmd.CommandText = sStmt
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader()
        aGroup(0) = New gDumpUDT()
        If rsLocal.Rows.Count > 0 Then
            Dim recordCount As Integer = 0
            Dim tmpDR As DataTable

            If rsLocal.Rows.Count > 0 And Not IsDBNull(rsLocal.Rows(0).Item("qb_group_id")) Then
                recordCount = rsLocal.Rows.Count
                tmpDR = rsLocal

                'sGroup = rsLocal.Rows(0).Item("qb_group_id")
                'gsGroupId = sGroup 'Guardo para query del detalle del cheque en frmExportCheckList

                ReDim aGroup(recordCount)

                idx = 0

                For row As Integer = 0 To rsLocal.Rows.Count - 1
                    gDump.str1 = rsLocal.Rows(row).Item("cust_id")
                    gDump.str2 = rsLocal.Rows(row).Item("qb_group_id")

                    aGroup(idx) = gDump
                    idx = idx + 1
                Next row

                numCustomers = idx
            Else
                If cbCustId.Text = "<All>" Then
                    MsgBox("Could not find checks for such criteria.", MsgBoxStyle.OkOnly, "GLM Message")
                    Exit Sub
                Else
                    MsgBox("Settings Error: Unable to get QB-Group for this customer." & vbCrLf & "Not group was found for customer or such group does not exist.", MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Sub
                End If
            End If
        End If
		
		'Listado de cheques en la cuenta de banco para el qb-grupo
		'al que pertenece el cliente
		
		
		'1.7.2
		'sSelect = " SELECT DISTINCT ISNULL(bcheck.qb_exported_flag,'N') AS Exported, " + _
		'" qb_bankAccount.name AS qb_bank_name, " + _
		'" bcheck.check_no AS qb_doc_num, " + _
		'" bcheck.check_date AS qb_check_date , " + _
		'" qb_vendor_vbranch.name  as qb_vendor_name, " + _
		'" bcheck.check_amount AS qb_check_amount, " + _
		'" 'N' AS qb_clear, 'N' AS qb_to_print, " + _
		'" qb_vendor_vbranch.name AS qb_addr1, " + _
		'" vbranch.vend_pay_address AS qb_addr2, " + _
		'" vbranch.vend_pay_city AS qb_addr3_1, " + _
		'" vbranch.vend_pay_zip AS qb_addr3_2, " + _
		'" bcheck.check_memo AS qb_addr4, " + _
		'" bcheck.check_memo AS qb_check_memo, " + _
		'" bcheck.bank_cust_seq, vbranch.vend_name , " + _
		'" bcheck.voided_flag AS Void "
		
		'sStmtLocal = " FROM bcheck, vbranch, qb_bankAccount, qb_vendor_vbranch " + _
		'" WHERE bcheck.cust_id ='" + Trim(cbCustId) + "' " + _
		'" AND bcheck.vend_seq = vbranch.vend_seq " + _
		'" AND bcheck.bank_cust_seq = qb_bankaccount.bank_cust_seq " + _
		'" AND qb_bankAccount.qb_group_id='" + Trim(sGroup) + "' " + _
		'" AND qb_vendor_vbranch.qb_group_id = '" + Trim(sGroup) + "' " + _
		'" AND qb_vendor_vbranch.vend_seq = bcheck.vend_seq"
		
		'3.1.15
		
		sTmp = get_criteria
		
        sSingleQuery = ""
        sStmtLocal = ""
        'aGroup(0) = New gDumpUDT()
		For i = 0 To numCustomers - 1
			
			sSelect = " SELECT DISTINCT ISNULL(bcheck.qb_exported_flag,'N') AS Exported, " & " qb_bankAccount.name AS qb_bank_name, " & " bcheck.check_no AS qb_doc_num, " & " bcheck.check_date AS qb_check_date , " & " qb_vendor_vbranch.name  as qb_vendor_name, " & " bcheck.check_amount AS qb_check_amount, " & " 'N' AS qb_clear, 'N' AS qb_to_print, " & " qb_vendor_vbranch.name AS qb_addr1, " & " vbranch.vend_pay_address AS qb_addr2, " & " vbranch.vend_pay_city AS qb_addr3_1, " & " vbranch.vend_pay_zip AS qb_addr3_2, " & " bcheck.check_memo AS qb_addr4, " & " bcheck.check_memo AS qb_check_memo, " & " bcheck.bank_cust_seq, vbranch.vend_name , " & " bcheck.voided_flag AS Void, bcheck.cust_id, qb_bankAccount.qb_group_id "

            Dim str As String = aGroup(i).str1
            sStmtLocal = " FROM bcheck, vbranch, qb_bankAccount, qb_vendor_vbranch " & " WHERE bcheck.cust_id ='" & Trim(str) & "' " & " AND bcheck.vend_seq = vbranch.vend_seq " & " AND bcheck.bank_cust_seq = qb_bankaccount.bank_cust_seq " & " AND qb_bankAccount.qb_group_id='" & Trim(aGroup(i).str2) & "' " & " AND qb_vendor_vbranch.qb_group_id = '" & Trim(aGroup(i).str2) & "' " & " AND qb_vendor_vbranch.vend_seq = bcheck.vend_seq"

			
			'MsgBox sStmt
			If chExported.CheckState = System.Windows.Forms.CheckState.Checked Then
				'Show all: exported and not exported
				
			Else
				'Just pending to export: Default
				sStmtLocal = Trim(sStmtLocal) & " AND qb_exported_flag IS NULL "
			End If
			
			
			sSingleQuery = Trim(sSingleQuery) & sSelect & sStmtLocal
			
			
			'Query Criteria
            'sTmp = get_criteria()
			If Len(sTmp) = 0 Then
				Exit Sub
			End If
			
			sSingleQuery = Trim(sSingleQuery) & sTmp
			
			If (i < numCustomers - 1) Then
				sSingleQuery = Trim(sSingleQuery) & vbCrLf & " UNION " & vbCrLf
			End If
		Next i
		
		sStmt = sSingleQuery
		sStmt = sStmt & vbCrLf & " ORDER BY qb_doc_num, qb_check_date "
        cmd.CommandText = sStmt


        'rsCheckList.Filter = ADODB.FilterGroupEnum.adFilterNone

        If (numCustomers < 1) Then
            MsgBox("There are not checks for such criteria.", MsgBoxStyle.OkOnly, "GLM Message")
            Exit Sub
        End If
        'rsCheckList.CursorLocation = adUseClient		
        rsCheckList = getDataTable(sStmt) 'cm.ExecuteReader()

        If rsCheckList.Rows.Count < 1 Then
            MsgBox("There are not checks for such criteria.", MsgBoxStyle.OkOnly, "GLM Message")
            Exit Sub
        Else
            build_rs_customer(aGroup, numCustomers)
        End If



        'Verify duplicate checks due to configuration errors in QB
        If dup_check() = True Then
            Exit Sub
        End If


        'Verify data consistency before exporting checks
        If Not verify_check_consistency() Then
            Exit Sub
        End If

        VB6.ShowForm(frmExportCheckList, VB6.FormShowConstants.Modal, Me)
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "export_check_list")
        MsgBox("An error occurred while accessing Quick Books info." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")

    End Sub
	'Se asume que recordset rs esta abierto
	'TRUE  Se encontraron cheques duplicados
	'FALSE No hay problema
	Private Function dup_check() As Boolean
		Dim nRecords As Short
        Dim rsClone As DataTable
		Dim i As Short
        Dim bCharFlag As Boolean
        Dim cmd As SqlCommand = cn.CreateCommand()
		
        rsClone = rsCheckList.Copy()
		
		dup_check = False
		
		On Error GoTo ErrorHandler
		
		'Borrar cualquier cheque previo
		sStmt = "DELETE FROM CheckException "

        cmd.CommandText = sStmt
        nRecords = cmd.ExecuteNonQuery()
		
            For cloneRow As Integer = 0 To rsClone.Rows.Count - 1
            nRecords = 0
            For rsRow As Integer = 0 To rsCheckList.Rows.Count - 1

                If rsClone.Rows(cloneRow).Item("qb_doc_num") = rsCheckList.Rows(rsRow).Item("qb_doc_num") Then
                    nRecords = nRecords + 1
                    If nRecords > 1 Then

                        dup_check = True

                        'Verificar todos los campos

                        For i = 0 To rsCheckList.Columns.Count - 1
                            If rsCheckList.Rows(rsRow).Item(i) <> rsClone.Rows(cloneRow).Item(i) Then
                                Dim sTypeCompare As String = ""
                                bCharFlag = False

                                If Object.ReferenceEquals(rsCheckList.Rows(rsRow).Item(i).GetType(), sTypeCompare.GetType()) = True Then
                                    bCharFlag = True
                                    sStmt = sStmt + rsCheckList.Rows(rsRow).Item(i)
                                Else
                                    sStmt = sStmt & Str(rsCheckList.Rows(rsRow).Item(i))
                                End If

                                'Dim itemType As String = rsCheckList.Rows(rsRow).Item(i).ToString
                                'If rsCheckList.Rows(rsRow).Item(i).Type = SqlDbType.VarChar Or _
                                '    rsCheckList.Rows(rsRow).Item(i).Type = SqlDbType.NChar Or _
                                '    rsCheckList.Rows(rsRow).Item(i).Type = SqlDbType.Char Or _
                                '    rsCheckList.Rows(rsRow).Item(i).Type = SqlDbType.NVarChar Or _
                                '    rsCheckList.Rows(rsRow).Item(i).Type = SqlDbType.Text Then

                                '    bCharFlag = True
                                '    sStmt = sStmt + rsCheckList.Rows(rsRow).Item(i)
                                'Else
                                '    sStmt = sStmt & Str(rsCheckList.Rows(rsRow).Item(i))
                                'End If
                                Exit For
                            End If
                        Next i

                        'Descomentar si se desea que programa emita mensaje por cada cheque dup

                        'sStmt = "Found duplicate check:" + Str(rsCheckList.item("qb_doc_num")) + vbCrLf + _
                        '"Field: " + rsCheckList.item(i).name + vbCrLf + _
                        '"Values:" + vbCrLf

                        'If bCharFlag Then
                        '    sStmt = sStmt + rsCheckList.item(i) + vbCrLf + rsClone.item(i)
                        'Else
                        '    sStmt = sStmt + Str(rsCheckList.item(i)) + vbCrLf + Str(rsClone.item(i))
                        'End If

                        'MsgBox sStmt
                        If Not i = rsCheckList.Columns.Count Then
                            sStmt = "INSERT INTO CheckException(cust_id,check_no, field_name, " & _
                                                                "conflict_value1, conflict_value2)" & _
                                                                " VALUES " & _
                                                                "('" & cbCustId.Text & "'," & _
                                                                Str(rsCheckList.Rows(rsRow).Item("qb_doc_num")) & "," & _
                                                                "'" & rsCheckList.Columns(i).ColumnName & "',"
                            '"'" & rsCheckList.Rows(rsRow).Item(i).name & "',"
                            If bCharFlag Then
                                sStmt = sStmt & "'" + Trim(rsCheckList.Rows(rsRow).Item(i)) + "','" + Trim(rsClone.Rows(cloneRow).Item(i)) + "')"
                            Else
                                sStmt = sStmt & Str(rsCheckList.Rows(rsRow).Item(i)) & "," & Str(rsClone.Rows(cloneRow).Item(i)) & ")"
                            End If

                            cmd.CommandText = sStmt
                            nRecords = cmd.ExecuteNonQuery()
                            If nRecords = 1 Then
                                'ok
                            Else
                                MsgBox("Failed to log Error Exception", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                                Exit Function
                            End If
                        End If
                    End If
                Else
                    'Exit For
                End If

            Next rsRow
                
            Next cloneRow
            
            If dup_check Then
                VB6.ShowForm(frmExportCheckExcp, VB6.FormShowConstants.Modal, Me)
            End If
            Exit Function

ErrorHandler:
            save_error(Me.Name, "dup_check")
            MsgBox("Failed to log Duplicate Check. Review logfile for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
		
	End Function
	'Genera la condicion para agregar al query de busqueda
	'de acuerdo con las selecciones del usuario
	'En caso de error, se retorna ""
	Private Function get_criteria() As String
		
		Dim sWhere As String
        sWhere = ""
        get_criteria = ""
		Select Case sRadioFlag
			Case "date"
                sWhere = " AND bcheck.check_date between '" & dtFrom.Value.ToShortDateString() & "'  AND '" & dtTo.Value.ToShortDateString() & "' "
			Case "check"
				If Len(txtCheckFrom.Text) = 0 Then
					MsgBox("You must enter an Starting Check Number.", MsgBoxStyle.OKOnly, "Warning")
					txtCheckFrom.Focus()
					sWhere = ""
					Exit Function
				End If
				
				If Len(txtCheckTo.Text) = 0 Then
					MsgBox("You must enter an Ending Check Number.", MsgBoxStyle.OKOnly, "Warning")
					txtCheckTo.Focus()
					sWhere = ""
					Exit Function
				End If
				
				
				If CInt(txtCheckFrom.Text) > CInt(txtCheckTo.Text) Then
					MsgBox("Starting Check No should be less than Ending Check No.", MsgBoxStyle.OKOnly, "Warning")
					txtCheckFrom.Focus()
					sWhere = ""
					Exit Function
				End If
				
				If cbBankAccount.SelectedIndex >= 0 Then
					sWhere = Trim(sWhere) & " AND bcheck.bank_cust_seq = " & Str(VB6.GetItemData(cbBankAccount, cbBankAccount.SelectedIndex))
				End If
				
				If Len(txtCheckFrom.Text) > 0 Then
					sWhere = sWhere & " AND bcheck.check_no >= " & Trim(txtCheckFrom.Text)
				End If
				If Len(txtCheckTo.Text) > 0 Then
					sWhere = sWhere & " AND bcheck.check_no <= " & Trim(txtCheckTo.Text)
				End If
				
				
			Case "vendor"
				sWhere = " AND vbranch.vend_id =" & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex))
		End Select
		get_criteria = sWhere
	End Function
	
	'UPGRADE_WARNING: Event cbBankName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbBankName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbBankName.SelectedIndexChanged
		If cbCustId.SelectedIndex = 0 Then
			sStmt = "SELECT bank_account, bank_cust_seq FROM BankAccount " & " WHERE bank_id = (SELECT bank_id FROM bank WHERE bank_status='ACTIVE') "
			load_cb_query2(cbBankAccount, sStmt, 2, True)
			If cbBankAccount.Items.Count > 0 Then
				cbBankAccount.SelectedIndex = 0
			End If
			
		Else
			sStmt = "SELECT bank_account, bank_cust_seq FROM BankAccount " & " WHERE BankAccount.cust_id= '" & Trim(cbCustId.Text) & "'" & " AND bank_id =" & Str(VB6.GetItemData(cbBankName, cbBankName.SelectedIndex))
			
			load_cb_query2(cbBankAccount, sStmt, 2, True)
			If cbBankAccount.Items.Count > 0 Then
				cbBankAccount.SelectedIndex = 0
			End If
			
		End If
	End Sub
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		Dim nNumActiveAccounts As Short
		Dim nNumActiveBanks As Short
        Dim nNumAccounts As Short
        Dim cmd As SqlCommand = cn.CreateCommand()

		
		cbCustId.SelectedIndex = cbCustName.SelectedIndex
		sStmt = ""
		
		'Bank
		If cbCustId.SelectedIndex > 0 Then
			sStmt = "SELECT DISTINCT Bank.bank_name, BankAccount.bank_id " & " FROM BankAccount, Bank " & " WHERE BankAccount.bank_id = Bank.bank_id " & " AND BankAccount.cust_id= '" & Trim(cbCustId.Text) & "'"
			
			load_cb_query2(cbBankName, sStmt, 2, True)
			If cbBankName.Items.Count > 0 Then
				cbBankName.SelectedIndex = 0
			Else
				'No records found in BankAccount table
				cbBankAccount.Items.Clear()
			End If
			
			
		ElseIf cbCustId.SelectedIndex = 0 Then 
			'All customers
			'Count number of active accounts
			sStmt = "SELECT  count(*) " & " FROM bank WHERE  bank_status = 'ACTIVE' "
            cmd.CommandText = sStmt
            Dim tmpDR As DataTable
            Dim recordCount As Integer = 0
            Dim hasRows As Boolean = False

            rs = getDataTable(sStmt) ' cmd.ExecuteReader()
            hasRows = (rs.Rows.Count > 0) 'HasRows()
            tmpDR = rs

            recordCount = tmpDR.Rows.Count


            If (hasRows) Then
                nNumActiveBanks = recordCount
            End If

            'Check that just one BankAccount per customer is active
            sStmt = "SELECT count(bank_account), cust_id FROM BankAccount " & " WHERE bank_id IN " & _
                    "(SELECT  bank_id " & " FROM bank WHERE  bank_status = 'ACTIVE') " & _
                    " GROUP BY cust_id " & " HAVING count(bank_account) > 1 "

            cmd.CommandText = sStmt
            rs = getDataTable(sStmt) ' cmd.ExecuteReader()
            nNumActiveAccounts = 0
            If rs.Rows.Count > 0 Then
                nNumActiveAccounts = rs.Rows.Count
                
            End If

            If nNumActiveBanks > 1 Or nNumActiveAccounts > 0 Then
                'One or more Banks active
                radioCheckRange.Enabled = False
            ElseIf nNumActiveBanks = 1 And nNumActiveAccounts = 0 Then
                'Verify that all customers use the same Account
                sStmt = "SELECT count(*) FROM bankAccount " & " WHERE bank_id = (SELECT  bank_id " & " FROM bank WHERE  bank_status = 'ACTIVE') "
                cmd.CommandText = sStmt
                rs = getDataTable(sStmt) ' cmd.ExecuteReader()
                nNumAccounts = rs.Rows.Count

                If nNumAccounts = 1 Then
                    sStmt = " SELECT bank_name, bank_id " & " FROM bank WHERE  bank_status = 'ACTIVE' "
                    load_cb_query2(cbBankName, sStmt, 2, True)
                    If cbBankName.Items.Count > 0 Then
                        cbBankName.SelectedIndex = 0
                    Else
                        'No records found in BankAccount table
                        cbBankAccount.Items.Clear()
                    End If

                Else
                    radioCheckRange.Enabled = False
                End If

            Else
                radioCheckRange.Enabled = False
            End If


            End If


    End Sub
	
	'UPGRADE_WARNING: Event cbVendor.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbVendor_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbVendor.SelectedIndexChanged
		'MsgBox Str(cbVendor.ItemData(cbVendor.ListIndex))
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		export_check_list()
	End Sub
	
	Private Sub frmExportCheck_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		load_controls()
	End Sub
	
	
	'UPGRADE_WARNING: Event radioCheckRange.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub radioCheckRange_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles radioCheckRange.CheckedChanged
		If eventSender.Checked Then
			radio_enable((radioCheckRange.Name))
		End If
	End Sub
	
	'UPGRADE_WARNING: Event radioDateRange.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub radioDateRange_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles radioDateRange.CheckedChanged
		If eventSender.Checked Then
			radio_enable((radioDateRange.Name))
		End If
	End Sub
	'Esta funcion habilita el radio
	'seleccionado por el usuario y desahibilita
	'los demas
	Private Sub radio_enable(ByRef sNombre As String)
		Select Case sNombre
			Case "radioDateRange"
				frDateRange.Enabled = True
				frCheckRange.Enabled = False
				frVendor.Enabled = False
				
				dtFrom.Enabled = True
				dtTo.Enabled = True
				txtCheckFrom.BackColor = System.Drawing.SystemColors.InactiveBorder
				txtCheckTo.BackColor = System.Drawing.SystemColors.InactiveBorder
				cbBankName.BackColor = System.Drawing.SystemColors.InactiveBorder
				cbBankAccount.BackColor = System.Drawing.SystemColors.InactiveBorder
				cbVendor.BackColor = System.Drawing.SystemColors.InactiveBorder
				
				sRadioFlag = "date"
			Case "radioCheckRange"
				frDateRange.Enabled = False
				frCheckRange.Enabled = True
				frVendor.Enabled = False
				
				dtFrom.Enabled = False
				dtTo.Enabled = False
				txtCheckFrom.BackColor = System.Drawing.SystemColors.Window
				txtCheckTo.BackColor = System.Drawing.SystemColors.Window
				cbBankName.BackColor = System.Drawing.SystemColors.Window
				cbBankAccount.BackColor = System.Drawing.SystemColors.Window
				cbVendor.BackColor = System.Drawing.SystemColors.InactiveBorder
				
				sRadioFlag = "check"
			Case "radioVendor"
				frDateRange.Enabled = False
				frCheckRange.Enabled = False
				frVendor.Enabled = True
				
				dtFrom.Enabled = False
				dtTo.Enabled = False
				txtCheckFrom.BackColor = System.Drawing.SystemColors.InactiveBorder
				txtCheckTo.BackColor = System.Drawing.SystemColors.InactiveBorder
				cbBankName.BackColor = System.Drawing.SystemColors.InactiveBorder
				cbBankAccount.BackColor = System.Drawing.SystemColors.InactiveBorder
				cbVendor.BackColor = System.Drawing.SystemColors.Window
				
				sRadioFlag = "vendor"
		End Select
		
		
		
	End Sub
	
	'UPGRADE_WARNING: Event radioVendor.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub radioVendor_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles radioVendor.CheckedChanged
		If eventSender.Checked Then
			radio_enable((radioVendor.Name))
		End If
	End Sub
	
	Private Sub txtCheckFrom_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCheckFrom.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Solo numeros y Backspace
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Then
			'Otro caracter no numerico
		Else
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtCheckTo_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCheckTo.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Solo numeros y Backspace
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Then
			'Otro caracter no numerico
		Else
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Function verify_check_consistency() As Boolean
		
		Dim sGroup As String
		Dim sVendName As String
		Dim sQBVendName As String
		Dim sQBaccount As String
		Dim nBankCustSeq As Short
        Dim sBankName As String
        Dim cmd As SqlCommand = cn.CreateCommand()
		
		verify_check_consistency = True
		
		
        'rsCheckList.MoveFirst()
		

        For row As Integer = 0 To rsCheckList.Rows.Count - 1
            Dim tmpDR As DataTable
            Dim recordCount As Integer = 0
            'Verify that qb_vendor_vbranch exists in qb_vendor
            sQBVendName = rsCheckList.Rows(row).Item("qb_vendor_name")
            sVendName = rsCheckList.Rows(row).Item("vend_name")
            sGroup = rsCheckList.Rows(row).Item("qb_group_id")
            sStmt = "SELECT name FROM qb_vendor " & " WHERE qb_group_id ='" & Trim(sGroup) & "' " & " AND name ='" & quotation_mask(Trim(sQBVendName)) & "'"

            rsLocal = getDataTable(sStmt) ' cmd.ExecuteReader()
            tmpDR = rsLocal
            If rsLocal.Rows.Count > 0 Then
                recordCount = rsLocal.Rows.Count
                If recordCount > 0 Then
                    'OK, can not be greater than 1 due to PK in qb_vendor
                Else
                    MsgBox("QB Inconsistency." & vbCrLf & "Vendor:" & Trim(sVendName) & " associated to " & vbCrLf & "QBVendor:" & Trim(sQBVendName) & " was not found on QB Vendor table." & vbCrLf & "Check Group assigned to this Vendor on Vendor screen.")
                    verify_check_consistency = False
                    Exit Function
                    'Exit Sub
                End If
            End If


            'Verify that qb_bankAccount exists in qb_account
            sQBaccount = rsCheckList.Rows(0).Item("qb_bank_name")
            nBankCustSeq = rsCheckList.Rows(0).Item("bank_cust_seq")
            sStmt = "SELECT name FROM qb_account " & " WHERE qb_group_id ='" & Trim(sGroup) & "' " & " AND accnttype ='BANK' " & " AND name ='" & quotation_mask(Trim(sQBaccount)) & "'"
            cmd.CommandText = sStmt
            rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader()

            If rsLocal.Rows.Count > 0 Then
                'OK, no puede ser mayor a 1 debido a la PK en qb_account
            Else
                'Banco para mostrar en mensaje
                sBankName = ""
                sStmt = "SELECT bank_name FROM Bank, bankAccount " & " WHERE BankAccount.bank_cust_seq =" & Str(nBankCustSeq) & " AND BankAccount.bank_id = Bank.bank_id "
                cmd.CommandText = sStmt
                rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader()
                If rsLocal.Rows.Count > 0 Then
                    sBankName = rsLocal.Rows(0).Item("bank_name")
                End If

                MsgBox("QB Inconsistency." & vbCrLf & "Bank:" & Trim(sBankName) & " associated to " & vbCrLf & "QBBank Account:" & Trim(sQBaccount) & " was not found on QB Account table.")
                verify_check_consistency = False
                Exit Function
                'Exit Sub
            End If

        Next
		
	End Function
	'List of customer that have checks
	Private Sub build_rs_customer(ByRef aGroup() As gDumpUDT, ByRef numCustomers As Short)
        'Dim aCustomer() As String
        Dim sCustList As String
        Dim cmd As SqlCommand = cn.CreateCommand()
		Dim i As Short
		
		sStmt = "SELECT customer.cust_name Customer, bcheck.cust_id, " & " COUNT(distinct check_no) 'Check Count', SUM(bcheck.invoice_total) 'Total Checks'   " & " FROM bcheck, vbranch, qb_bankAccount, qb_vendor_vbranch, customer" & " WHERE bcheck.cust_id = customer.cust_id " & " AND bcheck.vend_seq = vbranch.vend_seq " & " AND bcheck.bank_cust_seq = qb_bankaccount.bank_cust_seq " & " AND qb_vendor_vbranch.qb_group_id = qb_bankAccount.qb_group_id " & " AND qb_vendor_vbranch.vend_seq = bcheck.vend_seq "
		
		
		sCustList = " AND customer.cust_id IN("
		
		For i = 0 To numCustomers - 1
			sCustList = sCustList & "'" & aGroup(i).str1 & "'"
			If i < numCustomers - 1 Then
				sCustList = sCustList & ","
			End If
		Next i
		
		sCustList = sCustList & ") "
		
		sStmt = Trim(sStmt) & sCustList
		
		If chExported.CheckState <> System.Windows.Forms.CheckState.Checked Then
			sStmt = Trim(sStmt) & " AND bcheck.qb_exported_flag IS NULL "
		End If
		
		sStmt = Trim(sStmt) & get_criteria() & " GROUP BY customer.cust_name, bcheck.cust_id "

        cmd.CommandText = sStmt
        rsCustCheck = getDataTable(sStmt) ' cmd.ExecuteReader()
		
	End Sub
End Class