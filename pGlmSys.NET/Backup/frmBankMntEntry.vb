Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmBankMntEntry
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If val_fields(gBank.bFlag) Then
			If save_bank(gBank.bFlag) Then
				Me.Close()
			End If
		End If
	End Sub
	Private Function val_fields(ByRef bOption As General.modo) As Boolean
		val_fields = True
		On Error GoTo ErrorHandler
		
		'Bank Name
		If Len(Trim(txtBankName.Text)) = 0 Then
			MsgBox("Bank Name must be entered.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
			txtBankName.Focus()
			val_fields = False
			Exit Function
		End If
		
		'Bank ABA/ Routing
		If Len(Trim(txtBankAba.Text)) = 0 Then
			MsgBox("Bank Routing number must be entered.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
			txtBankAba.Focus()
			val_fields = False
			Exit Function
		End If
		
		'Bank Chek Info settings
		If Len(Trim(txtCheckInfo1.Text)) = 0 And Len(Trim(txtCheckInfo2.Text)) = 0 And Len(Trim(txtCheckInfo3.Text)) = 0 And Len(Trim(txtCheckInfo4.Text)) = 0 Then
			MsgBox("You must enter at least one bank address line.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
			txtCheckInfo1.Focus()
			val_fields = False
			Exit Function
		End If
		
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "val_fields")
		MsgBox("Unexpected error while validating Bank data", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Error")
	End Function
	Private Function save_bank(ByRef bOption As General.modo) As Boolean
		Dim nBankId As Short
		Dim nRecords As Short
		Dim sBankCheckInfo1 As String
		Dim sBankCheckInfo2 As String
		Dim sBankCheckInfo3 As String
		Dim sBankCheckInfo4 As String
		
		save_bank = True
		nBankId = 0
		
		
		If Len(Trim(txtCheckInfo1.Text)) = 0 Then
			sBankCheckInfo1 = ""
		Else
			sBankCheckInfo1 = quotation_mask(txtCheckInfo1.Text)
		End If
		
		If Len(Trim(txtCheckInfo2.Text)) = 0 Then
			sBankCheckInfo2 = ""
		Else
			sBankCheckInfo2 = quotation_mask(txtCheckInfo2.Text)
		End If
		
		If Len(Trim(txtCheckInfo3.Text)) = 0 Then
			sBankCheckInfo3 = ""
		Else
			sBankCheckInfo3 = quotation_mask(txtCheckInfo3.Text)
		End If
		
		If Len(Trim(txtCheckInfo4.Text)) = 0 Then
			sBankCheckInfo4 = ""
		Else
			sBankCheckInfo4 = quotation_mask(txtCheckInfo4.Text)
		End If
		
		
		
		Select Case bOption
			Case General.modo.NewRecord
				'Check for duplicates before inserting
				sStmt = "SELECT COUNT(*) FROM Bank " & " WHERE bank_name='" & quotation_mask(Trim(txtBankName.Text)) & "'"
				
                rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rs.Rows.Count > 0 Then
                    If rs.Rows(0).Item(0) > 0 Then
                        save_bank = False
                        MsgBox("Duplicate Bank. Please use another name")
                        Exit Function
                    End If
                End If
				
				'Get Next BankId
				sStmt = "SELECT MAX(bank_id) FROM Bank"
				
                rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                If rs.Rows.Count > 0 Then
                    'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    If IsDBNull(rs.Rows(0).Item(0)) Then
                        nBankId = 1
                    Else
                        nBankId = rs.Rows(0).Item(0) + 1
                    End If
                Else
                    nBankId = 1
                End If


                'Insert into Bank
                sStmt = " INSERT INTO Bank(bank_id, bank_name, bank_aba, " & " check_info1, check_info2, " & " check_info3, check_info4, bank_status) " & " VALUES(" & Str(nBankId) & "," & "'" & quotation_mask(Trim(txtBankName.Text)) & "'," & "'" & Trim(txtBankAba.Text) & "'," & "'" & sBankCheckInfo1 & "'," & "'" & sBankCheckInfo2 & "'," & "'" & sBankCheckInfo3 & "'," & "'" & sBankCheckInfo4 & "'," & "'" & cbBankStatus.Text & "')"

                cm = cn.CreateCommand '.let_ActiveConnection(cn)
                cm.CommandType = CommandType.Text
                cm.CommandText = sStmt
                nRecords = cm.ExecuteNonQuery()
                If nRecords > 0 Then
                    'ok
                    gBank.bFlag = General.modo.SavedRecord
                    MsgBox("Record was successfully inserted.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                Else
                    MsgBox("Failed to insert into Bank table.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    save_bank = False
                    Exit Function
                End If

            Case General.modo.UpdateRecord
                'Check that another bankId does not have same Name
                sStmt = "SELECT bank_id FROM Bank " & " WHERE bank_name='" & quotation_mask(Trim(txtBankName.Text)) & "'"

                rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                If rs.Rows.Count > 0 Then
                    If rs.Rows(0).Item(0) <> gBank.nBankId Then
                        save_bank = False
                        MsgBox("Duplicate Bank Name. Please use another name")
                        Exit Function
                    End If
                End If


                'Update
                sStmt = "UPDATE Bank " & " SET bank_name='" & Trim(txtBankName.Text) & "', " & " bank_aba ='" & Trim(txtBankAba.Text) & "', " & " check_info1 = '" & sBankCheckInfo1 & "'," & " check_info2 = '" & sBankCheckInfo2 & "'," & " check_info3 = '" & sBankCheckInfo3 & "'," & " check_info4 = '" & sBankCheckInfo4 & "'," & " bank_status = '" & cbBankStatus.Text & "' " & " WHERE bank_id =" & Str(gBank.nBankId)

                cm = cn.CreateCommand '.let_ActiveConnection(cn)
                cm.CommandType = CommandType.Text
                cm.CommandText = sStmt
                nRecords = cm.ExecuteNonQuery()
                If nRecords > 0 Then
                    'ok
                    gBank.bFlag = General.modo.SavedRecord
                    MsgBox("Record was successfully updated.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                Else
                    MsgBox("Unexpected error while updating Bank information.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    save_bank = False
                    Exit Function
                End If

        End Select
		
	End Function
	Private Sub frmBankMntEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		
		'UPGRADE_WARNING: TextBox property txtBankName.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtBankName.Maxlength = 20
		'UPGRADE_WARNING: TextBox property txtBankAba.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtBankAba.Maxlength = 9
		'UPGRADE_WARNING: TextBox property txtCheckInfo1.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtCheckInfo1.Maxlength = 50
		'UPGRADE_WARNING: TextBox property txtCheckInfo2.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtCheckInfo2.Maxlength = 50
		'UPGRADE_WARNING: TextBox property txtCheckInfo3.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtCheckInfo3.Maxlength = 50
		'UPGRADE_WARNING: TextBox property txtCheckInfo4.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtCheckInfo4.Maxlength = 50
		
		sStmt = " SELECT field_option, option_order FROM sdomain " & " WHERE domain_field = 'bank_status' " & " ORDER BY option_order"
		load_cb_query2(cbBankStatus, sStmt, 1, True)
		
		Select Case gBank.bFlag
			Case General.modo.NewRecord
				If cbBankStatus.Items.Count > 0 Then
					cbBankStatus.SelectedIndex = 0
                End If

                txtBankName.Enabled = True
                txtBankName.ReadOnly = False

                txtBankName.Text = ""

                txtBankAba.Text = ""
                txtCheckInfo1.Text = ""
                txtCheckInfo2.Text = ""
                txtCheckInfo3.Text = ""
                txtCheckInfo4.Text = ""

			Case General.modo.UpdateRecord
				txtBankName.Enabled = False
				txtBankName.ReadOnly = True
				
				txtBankName.Text = Trim(gBank.sBankName)
				
				set_cb(cbBankStatus, gBank.sBankStatus)
				
				txtBankAba.Text = Trim(gBank.sBankAba)
				txtCheckInfo1.Text = Trim(gBank.sCheckInfo1)
				txtCheckInfo2.Text = Trim(gBank.sCheckInfo2)
				txtCheckInfo3.Text = Trim(gBank.sCheckInfo3)
				txtCheckInfo4.Text = Trim(gBank.sCheckInfo4)
		End Select
		
	End Sub
	
	Private Sub txtBankAba_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtBankAba.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numbers, Backspace, Dot
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Then
			'Is numeric
		Else
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class