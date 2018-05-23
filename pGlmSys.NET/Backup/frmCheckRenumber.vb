Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmCheckRenumber
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If val_fields = True Then
			If save_new_number = True Then
				gCheckRenumber.bOk = True
				gCheckRenumber.nNewCheckNo = CInt(txtNewCheck.Text)
			Else
				Exit Sub
			End If
		Else
			Exit Sub
		End If
		
		
		Me.Close()
	End Sub
	Private Function val_fields() As Boolean
        Dim cmd As SqlCommand = cn.CreateCommand
        Dim ds As DataSet = New DataSet()
        Dim da As SqlDataAdapter = New SqlDataAdapter()

		If Len(txtNewCheck.Text) = 0 Then
			MsgBox("You must enter a Check No.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
			val_fields = False
			Exit Function
		Else
			If IsNumeric(txtNewCheck.Text) Then
				'ok
			Else
				MsgBox("Incorrect New Check No.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
				val_fields = False
				Exit Function
			End If
		End If
		'Verifico que Cheque no este repetido
		sStmt = "SELECT DISTINCT check_no FROM Bcheck " & " WHERE bank_cust_seq = " & Str(gCheckRenumber.nBankCustSeq) & " AND check_no = " & txtNewCheck.Text
        cmd.CommandText = sStmt
        da.SelectCommand = cmd
        da.Fill(ds)
        'rsLocal = cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If ds.Tables(0).Rows.Count = 0 Then
            'ok
        Else
            'Repetido
            MsgBox("Check no:" & Trim(txtNewCheck.Text) & " has " & "already been used.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
            val_fields = False
            Exit Function
        End If


        val_fields = True
        Exit Function

ErrorHandler:
        save_error(Me.Name, "val_fields")
        MsgBox("An unexpected error was found verifying check no." & vbCrLf & "Review log file for details.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
	End Function
	'Renumbers check
	'True if check was successfully renumbered
	Private Function save_new_number() As Boolean
		Dim nRecords As Short
		Dim nCheckDetails As Short
        Dim nTran As SqlTransaction = Nothing
        Dim cmd As SqlCommand = cn.CreateCommand

		save_new_number = False
		'Guardar datos de cheque original
        sStmt = "SELECT * FROM Bcheck " & _
                " WHERE check_no =" & Str(gCheckRenumber.nVoidCheckNo) & " " & _
                " AND bank_cust_seq=" & Str(gCheckRenumber.nBankCustSeq)
        cmd.CommandText = sStmt

        Try
            
            rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rsLocal.Rows.Count > 0 Then
                nCheckDetails = rsLocal.Rows.Count
                'Insert Check detail record into Bcheck with new Number
                nTran = cn.BeginTransaction()

                sStmt = "INSERT INTO BCheck (check_no, bank_cust_seq,  " & " check_detail_no, vend_seq, " & " cust_id, store_id, " & " invoice_no, account_no, " & _
                                            " check_date, check_amount, " & " check_memo, invoice_total, " & _
                                            " detail_memo, qb_detail_name, voided_flag, " & _
                                            " create_user, create_dtim) " & _
                        " SELECT " & txtNewCheck.Text & ", bank_cust_seq,  " & " check_detail_no, vend_seq, " & " cust_id, store_id, " & _
                                    " invoice_no, account_no, " & " check_date, check_amount, " & " check_memo, invoice_total, " & _
                                    " detail_memo, qb_detail_name, voided_flag, " & "'" & Trim(gsUser) & "', getdate()" & _
                        " FROM Bcheck " & _
                        " WHERE check_no=" & Str(gCheckRenumber.nVoidCheckNo) & " AND bank_cust_seq=" & Str(gCheckRenumber.nBankCustSeq)
                cmd.CommandText = sStmt
                cmd.Transaction = nTran
                nRecords = cmd.ExecuteNonQuery()
                If nRecords = nCheckDetails Then
                    'ok, continue
                    'Delete previous Check
                    sStmt = "DELETE FROM Bcheck " & _
                            " WHERE check_no =" & Str(gCheckRenumber.nVoidCheckNo) & " " & _
                            " AND bank_cust_seq=" & Str(gCheckRenumber.nBankCustSeq)
                    cmd.CommandText = sStmt
                    nRecords = cmd.ExecuteNonQuery()
                    If nRecords = nCheckDetails Then
                        nTran.Commit()

                        MsgBox("Check renumbering was successful.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Warning")
                        save_new_number = True
                    Else
                        nTran.Rollback()
                        MsgBox("Unable to delete one or more Check details." & vbCrLf & "Operation was rolled back.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Warning")
                    End If
                Else
                    nTran.Rollback()
                    MsgBox("Unable to update one or more Check details." & vbCrLf & "Operation was rolled back.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Warning")
                End If

            Else
                'Check details where not found
                MsgBox("Such Check was not found in Database.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Message")
            End If
        Catch e As Exception
            save_new_number = False

            nTran.Rollback()

            save_error(Me.Name, "Save_new_number")
            MsgBox("Unexpected error occurred while updating Check number." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            'DB error
            MsgBox("There was an error accessing Check table in Database.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
        End Try

        Exit Function

ErrorHandler:
        
    End Function
	Private Sub frmCheckRenumber_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	Private Sub init_vars()
		
		set_limits()
		
		txtCurrentCheck.Enabled = False
		txtCurrentCheck.ReadOnly = True
        txtCurrentCheck.Text = CStr(gCheckRenumber.nVoidCheckNo)
        txtNewCheck.Text = ""
	End Sub
	
	Private Sub set_limits()
        txtCurrentCheck.MaxLength = 8
        txtNewCheck.MaxLength = 8
		
	End Sub
	Private Sub txtNewCheck_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtNewCheck.KeyPress
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