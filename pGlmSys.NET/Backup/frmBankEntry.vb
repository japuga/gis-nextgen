Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Friend Class frmBankEntry
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
	
	'UPGRADE_WARNING: Event cbBankName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbBankName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbBankName.SelectedIndexChanged
		'User chose <New>
		If cbBankName.SelectedIndex = 0 Then
			gBank.bFlag = General.modo.NewRecord
			
			VB6.ShowForm(frmBankDesc, VB6.FormShowConstants.Modal, Me)
			If gBank.bFlag = General.modo.SavedRecord Then
				'Agrega nuveo registro a combo
				load_bank_name()
				set_cb_ItemData(cbBankName, gBank.nBankId)
				'cbBankName.AddItem gBank.sBankName, cbBankName.ListCount
				'cbBankName.ListIndex = cbBankName.ListCount
			Else
				'Usuario no inserto banco
				cbBankName.SelectedIndex = 1
			End If
		End If
	End Sub
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		
		If cbCustName.SelectedIndex >= 0 Then
			cbCustId.SelectedIndex = cbCustName.SelectedIndex
			set_qbGroupDesc(cbCustId.Text)
		End If
		
	End Sub
	
	'UPGRADE_WARNING: Event cbQBGroupId.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbQBGroupId_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbQBGroupId.SelectedIndexChanged
		set_qbBankName(cbQBGroupId.Text)
		
	End Sub
	Private Sub set_qbBankName(ByRef sGroupId As String)
		
		On Error GoTo ErrorHandler
		
		'QBBankName
		sStmt = "SELECT name FROM qb_account  " & " WHERE  qb_group_id='" & sGroupId & "' " & " AND  AccntType='BANK' "
		load_cb_query2(cbQBBankName, sStmt, 1, True)
		
		If cbQBBankName.Items.Count > 0 Then
			cbQBBankName.SelectedIndex = 0
		End If
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "set_qbBankName")
		MsgBox("Unexpected error occurred while loading QB Account." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
	End Sub
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If val_fields(gBankAccount.bFlag) Then
			If save_bankAccount(gBankAccount.bFlag) Then
				Me.Close()
			End If
		End If
		
	End Sub
	Private Function save_bankAccount(ByRef nOption As General.modo) As Boolean
        Dim nRecords As Integer = 0
        Dim nTran As SqlTransaction
        Dim nBankCustSeq As Short = -1
        Dim bQbBankAccountExist As Boolean = False
        Dim sMessage As String = ""
        Dim sName As String = ""
        Dim cmd As SqlCommand = cn.CreateCommand()
		
		save_bankAccount = False

		
		On Error GoTo ErrorHandler
		
		Select Case nOption
			Case General.modo.NewRecord
                nTran = cn.BeginTransaction()

                sStmt = "SELECT MAX(bank_cust_seq) FROM bankAccount "
                cmd.CommandText = sStmt
                rsLocal = getDataTable(sStmt, nTran) 'cmd.ExecuteReader()


                If rsLocal.Rows.Count > 0 Then
                    If rsLocal.Rows(0).Item(0) > 0 Then
                        nBankCustSeq = rsLocal.Rows(0).Item(0) + 1
                    Else
                        nBankCustSeq = 1
                    End If
                Else
                    nBankCustSeq = 1
                End If

                sStmt = "INSERT INTO BankAccount(bank_cust_seq, " & "bank_account, bank_id, cust_id, " & "bank_account_balance, last_check_no )" & " VALUES " & "(" & Str(nBankCustSeq) & "," & "'" & Trim(txtBankAccount.Text) & "'," & Str(VB6.GetItemData(cbBankName, cbBankName.SelectedIndex)) & "," & "'" & cbCustId.Text & "'," & Str(CDbl(txtBankAccountBalance.Text)) & "," & Str(CDbl(txtLastCheckNo.Text)) & ")"
                'MsgBox sStmt
                cmd.CommandText = sStmt
                cmd.Transaction = nTran
                nRecords = cmd.ExecuteNonQuery()

                If nRecords = 1 Then
                    'ok
                Else
                    nTran.Rollback()
                    MsgBox("Failed to insert Bank Account.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Function
                End If


                'Qb_BankAccount
                sStmt = "INSERT INTO Qb_BankAccount (bank_cust_seq," & "name, qb_group_id) VALUES" & "(" & Str(nBankCustSeq) & "," & "'" & quotation_mask(cbQBBankName.Text) & "'," & "'" & cbQBGroupId.Text & "')"
                'MsgBox sStmt
                cmd.CommandText = sStmt
                nRecords = cmd.ExecuteNonQuery()

                If nRecords = 1 Then
                    'ok
                    nTran.Commit()
                    gBankAccount.bFlag = General.modo.SavedRecord
                    save_bankAccount = True
                    MsgBox("Bank Account was successfully inserted.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                Else
                    nTran.Rollback()
                    MsgBox("Failed to save Quick Books Bank Account.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                End If


            Case General.modo.UpdateRecord
                nTran = cn.BeginTransaction()

                '1.Update BankAccount
                sStmt = "UPDATE BankAccount " & "SET bank_account = '" & Trim(txtBankAccount.Text) & "', " & " bank_account_balance =" & txtBankAccountBalance.Text & " WHERE bank_cust_seq =" & Str(gBankAccount.nBankCustSeq)
                cmd.CommandText = sStmt
                cmd.Transaction = nTran
                nRecords = cmd.ExecuteNonQuery()

                If nRecords > 0 Then
                    'ok
                Else
                    nTran.Rollback()
                    MsgBox("Failed to update BankAccount", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Message")
                    Exit Function
                End If

                '2.QB_BankAccount
                sStmt = "SELECT name FROM qb_bankAccount " & " WHERE bank_cust_seq =" & Str(gBankAccount.nBankCustSeq) & " " & " AND qb_group_id ='" & cbQBGroupId.Text & "'"
                cmd.CommandText = sStmt
                rs = getDataTable(sStmt, nTran) 'cmd.ExecuteReader()

                If rs.Rows.Count > 0 Then
                    If IsDBNull(rs.Rows(0).Item("name")) Then
                        sName = ""
                    Else
                        sName = rs.Rows(0).Item("name")
                    End If
                    bQbBankAccountExist = True
                Else

                    bQbBankAccountExist = False
                End If


                If bQbBankAccountExist Then
                    If quotation_mask(cbQBBankName.Text) = quotation_mask(sName) Then
                        'No changes were made to QB Bank account
                    Else
                        'Delete any Bank name related to this GroupID and BankCustSeq
                        'We expect to remove just one record
                        sStmt = "DELETE FROM qb_bankAccount " & " WHERE bank_cust_seq =" & Str(gBankAccount.nBankCustSeq) & " " & " AND qb_group_id ='" & cbQBGroupId.Text & "'"
                        cmd.CommandText = sStmt
                        nRecords = cmd.ExecuteNonQuery()

                        If nRecords > 0 Then
                            'continue
                        Else
                            nTran.Rollback()
                            MsgBox("Failed to update QbBankAccount", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Message")
                            Exit Function
                        End If

                        'We insert new BankName to comply with user changes
                        sStmt = "INSERT INTO Qb_BankAccount (bank_cust_seq," & "name, qb_group_id) VALUES" & "(" & Str(gBankAccount.nBankCustSeq) & "," & "'" & quotation_mask(cbQBBankName.Text) & "'," & "'" & cbQBGroupId.Text & "')"
                        cmd.CommandText = sStmt
                        nRecords = cmd.ExecuteNonQuery()

                        'UPGRADE_WARNING: Couldn't resolve default property of object nRecords. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        If nRecords > 0 Then
                            'ok
                        Else
                            nTran.Rollback()
                            MsgBox("Failed to update QbBankAccount", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Message")
                            Exit Function
                        End If
                    End If


                Else 'bBankAccountExists is false
                    write_error("*****************", sLogfile, False)

                    sMessage = "Warning: could not update (delete-insert) qb_bankAccount" & " since record does not exist for the combination: " & " name:" & cbQBBankName.Text & " bank_cust_seq:" & Str(gBankAccount.nBankCustSeq) & " " & " qb_group_id:" & cbQBGroupId.Text

                    write_error(sMessage, sLogfile, False)
                    write_error("Inserting it anyway.", sLogfile, False)
                    write_error("*****************", sLogfile, False)

                    'We insert BankName that was supposedly in qb_bankAccount
                    sStmt = "INSERT INTO Qb_BankAccount (bank_cust_seq," & "name, qb_group_id) VALUES" & "(" & Str(gBankAccount.nBankCustSeq) & "," & "'" & quotation_mask(cbQBBankName.Text) & "'," & "'" & cbQBGroupId.Text & "')"
                    cmd.CommandText = sStmt
                    nRecords = cmd.ExecuteNonQuery()

                    'UPGRADE_WARNING: Couldn't resolve default property of object nRecords. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If nRecords > 0 Then
                        'ok
                    Else
                        nTran.Rollback()
                        MsgBox("Failed to update QbBankAccount", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Message")
                        Exit Function
                    End If
                End If

                nTran.Commit()
                save_bankAccount = True
                gBankAccount.bFlag = General.modo.SavedRecord
                MsgBox("Bank Information was successfully updated.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")

        End Select
		Exit Function
		
ErrorHandler: 
		save_bankAccount = False

        nTran.Rollback()

        save_error(Me.Name, "save_bankAccount")
        MsgBox("Unexpected error found while updating Bank table." & vbCrLf & "Please check log file.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
	End Function
	Private Function val_fields(ByRef nOption As General.modo) As Boolean
        Dim cmd As SqlCommand = cn.CreateCommand
		val_fields = True
		On Error GoTo ErrorHandler
		
		'Bank Account
		If Len(txtBankAccount.Text) = 0 Then
			MsgBox("Bank Account must be entered.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
			txtBankAccount.Focus()
			val_fields = False
			Exit Function
		End If
		
		Select Case nOption
			Case General.modo.NewRecord
				sStmt = "SELECT bank_cust_seq FROM bankAccount " & " WHERE cust_id = '" & cbCustId.Text & "' " & " AND bank_id = " & Str(VB6.GetItemData(cbBankName, cbBankName.SelectedIndex)) & " AND bank_account ='" & Trim(txtBankAccount.Text) & "'"
                cmd.CommandText = sStmt
                rsLocal = getDataTable(sStmt) ' cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                If rsLocal.Rows.Count > 0 Then
                    MsgBox("This is a duplicate Bank Account. Try again.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                    val_fields = False
                    Exit Function
                Else
                    'ok
                End If


            Case General.modo.UpdateRecord
                If Trim(txtBankAccount.Text) <> Trim(gBankAccount.sBankAccount) Then
                    sStmt = "SELECT bank_cust_seq FROM bankAccount " & " WHERE cust_id = '" & gBankAccount.sCustId & "' " & " AND bank_id = " & Str(gBankAccount.nBankId) & " AND bank_account ='" & Trim(txtBankAccount.Text) & "'"
                    cmd.CommandText = sStmt
                    rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                    If rsLocal.Rows.Count > 0 Then
                        MsgBox("This is a duplicate Bank Account. Try again.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                        val_fields = False
                        Exit Function
                    Else
                        'ok
                    End If
                End If

        End Select
		
		'Balance
		If Len(txtBankAccountBalance.Text) = 0 Then
			MsgBox("Please enter the Account Balance", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
			txtBankAccountBalance.Focus()
			val_fields = False
			Exit Function
		Else
			If Not IsNumeric(txtBankAccountBalance.Text) Then
				MsgBox("Balance must be numeric.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
				txtBankAccountBalance.Focus()
				val_fields = False
				Exit Function
			End If
			
		End If
		
		'Last Check No
		Select Case nOption
			Case General.modo.NewRecord
				If Len(txtLastCheckNo.Text) = 0 Then
					MsgBox("Please enter First Check No", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
					val_fields = False
					txtLastCheckNo.Focus()
					Exit Function
				Else
					If IsNumeric(txtLastCheckNo.Text) Then
						If CInt(txtLastCheckNo.Text) <= 0 Then
							MsgBox("Last Check No must be greater than zero.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Message")
							val_fields = False
							Exit Function
						End If
					Else
						MsgBox("Last Check No must be numeric.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
						val_fields = False
						txtLastCheckNo.Focus()
						Exit Function
					End If
				End If
				
			Case General.modo.UpdateRecord
				'This is just read only, no validation required
		End Select
		
		'QBGroupDesc
		If cbQBGroupDesc.SelectedIndex < 0 Or cbQBGroupId.SelectedIndex < 0 Then
			val_fields = False
			cbQBGroupDesc.Focus()
			MsgBox("Missing QuickBooks Company Group", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Function
		End If
		
		'QBBankName
		If cbQBBankName.SelectedIndex < 0 Then
			val_fields = False
			cbQBBankName.Focus()
			MsgBox("Missing QuickBooks Bank Name", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Function
		End If
		
		Exit Function
		
ErrorHandler: 
		val_fields = False
		save_error(Me.Name, "val_fields")
		MsgBox("Unexpected error found while verifying Bank information." & vbCrLf & "Please check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Function
	Private Sub frmBankEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	Private Sub init_vars()

        'Set Limits

        txtBankAccount.MaxLength = 20
        txtBankAccountBalance.MaxLength = 12
        txtLastCheckNo.MaxLength = 7

        'CustId
        sStmt = "SELECT cust_id, cust_name " & " FROM customer " & " ORDER BY cust_name"
        load_cb_query2(cbCustId, sStmt, 1, True)

        'CustName
        sStmt = "SELECT cust_name, cust_id " & " FROM customer " & " ORDER BY cust_name"
        load_cb_query2(cbCustName, sStmt, 1, True)

        load_bank_name()

        'QBGroupDesc
        sStmt = "SELECT qb_group_desc, qb_group_id " & " FROM qb_group  ORDER BY qb_group_desc"
        load_cb_query2(cbQBGroupDesc, sStmt, 1, True)


        'QBGroupId
        sStmt = "SELECT qb_group_id, qb_group_desc " & " FROM qb_group  ORDER BY qb_group_desc"
        load_cb_query2(cbQBGroupId, sStmt, 1, True)



        Select Case gBankAccount.bFlag
            Case General.modo.NewRecord
                'Choose First customer by default
                If cbCustName.Items.Count > 0 Then
                    cbCustName.SelectedIndex = 1
                End If

                'Choose first bank by default
                If cbBankName.Items.Count > 0 Then
                    cbBankName.SelectedIndex = 1
                End If

                txtBankAccount.Text = gBankAccount.sBankAccount
                txtBankAccountBalance.Text = CStr(gBankAccount.nBankAccountBalance)
                txtLastCheckNo.Text = CStr(gBankAccount.nLastCheckNo)

            Case General.modo.UpdateRecord
                set_cb(cbCustId, gBankAccount.sCustId)
                If cbCustId.SelectedIndex >= 0 Then
                    cbCustName.SelectedIndex = cbCustId.SelectedIndex
                End If
                cbCustName.Enabled = False

                'cbCustName.

                set_cb_ItemData(cbBankName, gBankAccount.nBankId)
                cbBankName.Enabled = False
                'UPGRADE_ISSUE: ComboBox property cbBankName.Locked was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                'cbBankName.Locked = True

                txtBankAccount.Text = gBankAccount.sBankAccount
                txtBankAccountBalance.Text = CStr(gBankAccount.nBankAccountBalance)
                'If gBankAccount.sBankAccountBalanceMask = "" Then
                '    txtBankAccountBalance.Text = "$_,___,___.__"
                'Else
                '    mtxtBankAccountBalance = gBankAccount.sBankAccountBalanceMask
                'End If


                txtLastCheckNo.Text = CStr(gBankAccount.nLastCheckNo)
                txtLastCheckNo.Enabled = False
                txtLastCheckNo.ReadOnly = True
        End Select



    End Sub
	Private Sub set_qbGroupDesc(ByRef sCustId As String)
        Dim cmd As SqlCommand = cn.CreateCommand()
		On Error GoTo ErrorHandler
		
		'QBGroupId
		sStmt = "SELECT qb_group_id FROM customer " & " WHERE cust_id ='" & Trim(sCustId) & "'"
        cmd.CommandText = sStmt
		
        rs = getDataTable(sStmt) ' cmd.ExecuteReader()

        If rs.Rows.Count > 0 Then
            gBankAccount.sQBGroupId = rs.Rows(0).Item("qb_group_id")
            set_cb(cbQBGroupId, gBankAccount.sQBGroupId)
            cbQBGroupDesc.SelectedIndex = cbQBGroupId.SelectedIndex
        Else
            MsgBox("Failed loading Quick Books Information " & " for customer:", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
        End If

        Exit Sub

ErrorHandler:
        save_error(Me.Name, "set_qbGroupDesc")
        MsgBox("Unexpected error occurred while loading QB Group." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
	End Sub
	
	Private Sub load_bank_name()
		'BankName
		cbBankName.Items.Clear()
		cbBankName.Items.Insert(0, "<New>")
		sStmt = "SELECT bank_name, bank_id FROM Bank " & " ORDER BY bank_name"
		load_cb_query2(cbBankName, sStmt, 2, False)
		
	End Sub
	
	
	Private Sub txtBankAccount_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtBankAccount.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros:0-9 y Backspace
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Then
			'Es numero
		Else
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	
	Private Sub txtBankAccountBalance_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtBankAccountBalance.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros, Backspace, Punto
		Dim nPos As Short
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			'Es numero
		Else
			'Punto
			nPos = InStr(1, txtBankAccountBalance.Text, ".", CompareMethod.Text)
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If KeyAscii = 46 And (nPos = 0 Or IsDbNull(nPos)) Then
				'ok
				GoTo EventExitSub
			End If
			
			'Signo Negativo en primera posicion
			If (KeyAscii = 45 And Len(txtBankAccountBalance.Text) = 0) Then
				'ok
				GoTo EventExitSub
			End If
			
			'Caracter invalido
			KeyAscii = 0
		End If
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtBankAccountBalance_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBankAccountBalance.Leave
		If max_fraction(txtBankAccountBalance.Text) Then
			txtBankAccountBalance.Text = VB.Left(txtBankAccountBalance.Text, InStr(1, txtBankAccountBalance.Text, ".", CompareMethod.Text) + 2)
		End If
		
	End Sub
	
	Private Sub txtLastCheckNo_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtLastCheckNo.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros:0-9 y Backspace
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Then
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