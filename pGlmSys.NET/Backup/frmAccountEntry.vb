Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmAccountEntry
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private cmLocal As SqlCommand
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		save_account()
	End Sub
	Private Sub save_account()
		Dim nCount As Short
		Dim sAccountNo As String
		
		
		sAccountNo = txtAccountNo.Text
		sAccountNo = clear_quotes2(sAccountNo, "-", "")
		sAccountNo = clear_quotes2(sAccountNo, " ", "")
		
		'Account no fue ingresado
		If Len(txtAccountNo.Text) = 0 Then
			MsgBox("Please enter Account Number", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Message")
			Exit Sub
		End If
		
		'Verifico que la cuenta no este previamente asignada
		'a este Vendor
		If account_assigned(sAccountNo) Then
			Exit Sub
		End If
		
		
		sStmt = "INSERT INTO VAccount (cust_id , store_id, " & "account_no, account_mask, vend_seq ) VALUES (" & "'" & gAccountRecord.sCustId & "', " & Str(gAccountRecord.nStoreId) & "," & "'" & Trim(sAccountNo) & "'," & "'" & Trim(txtAccountNo.Text) & "'," & Str(gAccountRecord.nVendSeq) & ")"
		
		'MsgBox sStmt
		cmLocal.CommandText = sStmt
        nCount = cmLocal.ExecuteNonQuery()
		If nCount > 0 Then
			gAccountRecord.bFlag = General.modo.SavedRecord
			gAccountRecord.sAccountNo = sAccountNo 'Esto retorna
			gAccountRecord.sAccountMask = txtAccountNo.Text
			MsgBox("Account was successfully assigned to this Vendor.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
			
		Else
			MsgBox("Unable to insert Account Number")
		End If
		
		Me.Close()
	End Sub
	
	'Verifico que la cuenta no este previamente asignada
	'a este Vendor
	Private Function account_assigned(ByRef sAccountNo As String) As Boolean
		
        'On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand()
		
		sStmt = ""
		
		sStmt = "SELECT count(*) FROM VAccount " & " WHERE cust_id = '" & gAccountRecord.sCustId & "' " & " AND store_id = " & Str(gAccountRecord.nStoreId) & " " & " AND account_no = '" & Trim(sAccountNo) & "' " & " AND vend_seq = " & Str(gAccountRecord.nVendSeq)
        cmd.CommandText = sStmt
        'MsgBox sStmt
        Try
            rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rsLocal.Rows.Count > 0 Then
                If rsLocal.Rows(0).Item(0) = 0 Then
                    account_assigned = False
                    Exit Function
                Else
                    MsgBox("This Account is already assigned to this Vendor.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
                    account_assigned = True
                    Exit Function
                End If
            Else
                account_assigned = False
                Exit Function
            End If

        Catch e As Exception
            MsgBox("There was an error when accesing Account table.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
            account_assigned = False

            Exit Function
        End Try

        Exit Function

ErrorHandler:
        save_error(Me.Text, "account_assigned")
        'Resume Next
    End Function
	Private Sub frmAccountEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		load_comp()
	End Sub
	
	Private Sub init_vars()

        cmLocal = cn.CreateCommand()
		
	End Sub
	Private Sub load_comp()
		txtCustId.Text = gAccountRecord.sCustId
		txtStoreNumber.Text = gAccountRecord.sStoreNumber
		txtVendName.Text = gAccountRecord.sVendName
	End Sub
	
	Private Sub txtAccountNo_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountNo.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Mayusculas, Numeros, Minusculas, -,blanco, backspcae
		If (KeyAscii >= 65 And KeyAscii <= 90) Or (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 45 Or KeyAscii = 32 Or KeyAscii = 8 Then
			'Aceptado
		Else
			'Cambio de minusculas a mayusculas
			If (KeyAscii >= 95 And KeyAscii <= 122) Then
				KeyAscii = Asc(UCase(Chr(KeyAscii)))
			Else
				KeyAscii = 0
			End If
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class