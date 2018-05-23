Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmCardEntry
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If val_fields Then
			If save_card(gCreditCard.bFlag) Then
				gCreditCard.bFlag = General.modo.SavedRecord
				Me.Close()
			End If
		End If
		
	End Sub
	Private Function val_fields() As Boolean
		
		val_fields = False
		
		
		If cbBankName.SelectedIndex < 0 Then
			MsgBox("Please select a Bank Name.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Warning")
			cbBankName.Focus()
			Exit Function
		End If
		
		If cbCardtype.SelectedIndex < 0 Then
			MsgBox("Please select a Card Type", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Warning")
			cbCardtype.Focus()
			Exit Function
		End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtCardBalance.Text) Then
			MsgBox("Please enter Credit Card Balance.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
			txtCardBalance.Focus()
			Exit Function
		Else
			If Len(txtCardBalance.Text) = 0 Then
				MsgBox("Please enter Credit Card Balance.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
				txtCardBalance.Focus()
				Exit Function
			End If
		End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtCardNumber.Text) Then
			MsgBox("Please enter Credit Card Number.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
			txtCardNumber.Focus()
			Exit Function
		Else
			If Len(txtCardNumber.Text) = 0 Then
				MsgBox("Please enter Credit Card Number.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
				txtCardNumber.Focus()
				Exit Function
			End If
		End If
		
		
		
		val_fields = True
		
	End Function
	Private Function dup_card() As Boolean

		dup_card = True
        Dim cmd As SqlCommand = cn.CreateCommand()
		On Error GoTo ErrorHandler
		
		sStmt = "SELECT COUNT(*) FROM CreditCard" & " WHERE bank_id =" & Str(VB6.GetItemData(cbBankName, cbBankName.SelectedIndex)) & " AND card_number ='" & Trim(txtCardNumber.Text) & "'"
        cmd.CommandText = sStmt
		
        rs = getDataTable(sStmt) ' cmd.ExecuteReader()

        If rs.Rows.Count > 0 Then
            If rs.Rows(0).Item(0) = 0 Then
                'no dup
                dup_card = False
            Else

            End If
        End If

        Exit Function

ErrorHandler:
        save_error(Me.Name, "dup_card")
        MsgBox("Failed to verify duplicates." & vbCrLf & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Error")
	End Function
	Private Function save_card(ByRef nOption As General.modo) As Boolean
		Dim nCardSeq As Short
		Dim nRecords As Short
        Dim cmd As SqlCommand = cn.CreateCommand()
		save_card = False
		
		On Error GoTo ErrorHandler
		
		Select Case nOption
			Case General.modo.NewRecord
				If dup_card Then
					MsgBox("This card number already exists.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Message")
					Exit Function
				End If
				
				nCardSeq = get_next_seq("CreditCard", "card_seq")
				If nCardSeq <= 0 Then
					MsgBox("Failed to obtain next sequence. " & "Check log file for additional information", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
					Exit Function
				End If
				
				sStmt = "INSERT INTO CreditCard(card_seq, " & " bank_id, card_number, " & " card_balance, card_type) " & " VALUES (" & Str(nCardSeq) & "," & Str(VB6.GetItemData(cbBankName, cbBankName.SelectedIndex)) & "," & "'" & Trim(txtCardNumber.Text) & "'," & txtCardBalance.Text & "," & "'" & cbCardtype.Text & "')"
                cmd.CommandText = sStmt
                nRecords = cmd.ExecuteNonQuery()
				If nRecords >= 1 Then
					'ok
					save_card = True
					MsgBox("Credit Card was successfully inserted.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
					Exit Function
				Else
					MsgBox("Failed to insert Credit Card." & vbCrLf & "Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Error")
					Exit Function
				End If
				
			Case General.modo.UpdateRecord
				sStmt = " UPDATE CreditCard " & " SET card_balance =" & Str(CDbl(txtCardBalance.Text)) & "," & " card_type ='" & cbCardtype.Text & "'" & " WHERE card_seq =" & Str(gCreditCard.nCardSeq)
                cmd.CommandText = sStmt
                nRecords = cmd.ExecuteNonQuery()
				If nRecords > 0 Then
					'ok
					save_card = True
					MsgBox("Credit Card was successfully updated.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
					Exit Function
				Else
					MsgBox("Failed to update Credit Card." & vbCrLf & "Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Error")
					Exit Function
				End If
		End Select
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "save_card")
		MsgBox("Unexpected error while updating Credit Card information." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Function
	
	Private Sub frmCardEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		
		'UPGRADE_WARNING: TextBox property txtCardNumber.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtCardNumber.Maxlength = 16
		'UPGRADE_WARNING: TextBox property txtCardBalance.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtCardBalance.Maxlength = 10
		
		
		sStmt = "SELECT bank_name, bank_id FROM Bank "
		load_cb_query2(cbBankName, sStmt, 2, True)
		
		sStmt = "SELECT field_option FROM SDomain " & " WHERE domain_field ='card_type' " & " ORDER BY option_order "
		load_cb_query2(cbCardtype, sStmt, 1, True)
		
		
		Select Case gCreditCard.bFlag
            Case General.modo.NewRecord
                txtCardNumber.Enabled = True
                txtCardNumber.ReadOnly = False
                txtCardNumber.Text = ""
                If cbBankName.Items.Count > 0 Then
                    If gCreditCard.nBankId > -1 Then
                        set_cb_ItemData(cbBankName, gCreditCard.nBankId)
                    Else
                        cbBankName.SelectedIndex = 0
                    End If
                End If
                    If cbCardtype.Items.Count > 0 Then
                        cbCardtype.SelectedIndex = 0
                    End If
                    txtCardBalance.Text = CStr(0)
                    txtCardNumber.Text = ""
			Case General.modo.UpdateRecord
                    set_cb_ItemData(cbBankName, gCreditCard.nBankId)
                    set_cb(cbCardtype, gCreditCard.sCardType)
                    txtCardBalance.Text = CStr(gCreditCard.nCardBalance)
                    txtCardNumber.Text = gCreditCard.sCardNumber
                    txtCardNumber.Enabled = False
                    txtCardNumber.ReadOnly = True
                    cbBankName.Enabled = False
		End Select
		
	End Sub
	
	Private Sub txtCardBalance_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCardBalance.KeyPress
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
			nPos = InStr(1, txtCardBalance.Text, ".", CompareMethod.Text)
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If KeyAscii = 46 And (nPos = 0 Or IsDbNull(nPos)) Then
				'ok
				GoTo EventExitSub
			End If
			
			'Signo Negativo en primera posicion
			If (KeyAscii = 45 And Len(txtCardBalance.Text) = 0) Then
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
	
	Private Sub txtCardNumber_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCardNumber.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		'Numeros, Backspace, Punto
        'Dim nPos As Short
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			'Es numero
		Else
			'Caracter invalido
			KeyAscii = 0
		End If
		
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class