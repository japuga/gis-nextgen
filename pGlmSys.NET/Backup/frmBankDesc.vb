Option Strict Off
Option Explicit On
Friend Class frmBankDesc
	Inherits System.Windows.Forms.Form
	
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If val_fields Then
			If save_bank Then
				Me.Close()
			End If
		End If
		
	End Sub
	Private Function val_fields() As Boolean
		val_fields = True
		If Len(Trim(txtBankName.Text)) = 0 Then
			MsgBox("Please enter Bank Name", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Message")
			val_fields = False
			Exit Function
		End If
		
	End Function
	Private Function save_bank() As Boolean
		Dim nBankId As Short
		Dim nRecords As Short
		
		save_bank = False
		
		On Error GoTo ErrorHandler
		
		'Verify for duplicates
		sStmt = "SELECT COUNT(*) FROM Bank " & " WHERE RTRIM(bank_name) = '" & quotation_mask(Trim(txtBankName.Text)) & "'"
		
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.Rows.Count > 0 Then
            If rs.Rows(0).Item(0) > 0 Then
                MsgBox("Duplicate Bank Name. Try Again.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                Exit Function
            End If
        End If
		


        'Get New BankId
        sStmt = "SELECT MAX(bank_id) FROM Bank"
        
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.Rows.Count > 0 Then

            If IsDBNull(rs.Rows(0).Item(0)) Then
                nBankId = 1
            Else
                nBankId = rs.Rows(0).Item(0)
                nBankId = nBankId + 1
            End If
        Else
            nBankId = 1
        End If


        'Insert Record
        sStmt = "INSERT INTO Bank(bank_id, bank_name) VALUES " & "(" & Str(nBankId) & "," & "'" & quotation_mask(Trim(txtBankName.Text)) & "')"

        cm = cn.CreateCommand '.let_ActiveConnection(cn)
        cm.CommandText = sStmt
        nRecords = cm.ExecuteNonQuery()
        If nRecords > 0 Then
            'ok
            gBank.nBankId = nBankId
            gBank.bFlag = General.modo.SavedRecord
            MsgBox("Record was successfully created.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
            save_bank = True
        Else
            MsgBox("Failed to insert record.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            'save_bank = False
        End If
        Exit Function

ErrorHandler:
        save_bank = False
        save_error(Me.Name, "Save_bank")
        MsgBox("Unexpected error found while inserting New Bank." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
		
	End Function
	Private Sub frmBankDesc_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		
	End Sub
	
	Private Sub init_vars()
		txtBankName.Text = ""
		'UPGRADE_WARNING: TextBox property txtBankName.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtBankName.Maxlength = 20
		
		gBank.nBankId = 0
		gBank.sBankName = ""
	End Sub
End Class