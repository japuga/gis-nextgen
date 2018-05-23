Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmCheckVoid
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If val_fields = False Then
			Exit Sub
		End If
		
		gCheckVoid.bOk = True
		gCheckVoid.nNewCheckNo = CInt(txtNewCheck.Text)
		
		Me.Close()
	End Sub
	Private Function val_fields() As Boolean
		
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
		sStmt = "SELECT DISTINCT check_no FROM Bcheck " & " WHERE bank_cust_seq = " & Str(gCheckVoid.nBankCustSeq) & " AND check_no = " & txtNewCheck.Text
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count = 0 Then
            'ok
        Else
            'Repetido
            If txtNewCheck.Text = txtVoidCheck.Text Then
                'Reimprimir usando el mismo numero de cheque
                If MsgBox("Are you sure to use the same " & "Check number?", MsgBoxStyle.YesNo, "GLM Message") = MsgBoxResult.No Then
                    val_fields = False
                    Exit Function
                Else
                    gCheckVoid.bSameCheck = True
                End If

            Else
                MsgBox("Check no:" & Trim(txtNewCheck.Text) & " has " & "already been used.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                val_fields = False
                Exit Function
            End If
        End If

        val_fields = True
        Exit Function

ErrorHandler:
        save_error(Me.Name, "val_fields")
        MsgBox("An unexpected error was found verifying check no." & vbCrLf & "Review log file for details.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
	End Function
	Private Sub frmCheckVoid_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		
		set_limits()
		
		txtVoidCheck.Text = CStr(gCheckVoid.nVoidCheckNo)
		txtVoidCheck.ReadOnly = True
		txtVoidCheck.Enabled = False
		'jp.bug46.begin
		'txtNewCheck = get_check_no(gCheckVoid.nBankCustSeq)
		txtNewCheck.Text = CStr(BankFunctions.get_check_no(gCheckVoid.nBankCustSeq))
		'jp.bug46.end
		
	End Sub
	Private Sub set_limits()
		'UPGRADE_WARNING: TextBox property txtVoidCheck.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtVoidCheck.Maxlength = 8
		'UPGRADE_WARNING: TextBox property txtNewCheck.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtNewCheck.Maxlength = 8
		
	End Sub
	'Obtiene nuevo numero de cheque para imprimir
	Private Function get_check_no(ByRef nBankCustSeq As Short) As Integer
		Dim nCheckNo As Integer
		
		On Error GoTo ErrorHandler
		
		nCheckNo = 0
		
		sStmt = "SELECT MAX(check_no) FROM BCheck " & "WHERE bank_cust_seq = " & Str(nBankCustSeq)
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count = 0 Then
            nCheckNo = 1
        Else
            If rsLocal.Rows(0).Item(0).Value <> "" Then
                nCheckNo = rsLocal.Rows(0).Item(0).Value + 1
            End If
        End If

        get_check_no = nCheckNo
        Exit Function

ErrorHandler:
        get_check_no = 0
        save_error(Me.Name, "get_check_no")
        MsgBox("Failed to get check No." & vbCrLf & "Review log file for details", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLm Warning")
	End Function
	
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