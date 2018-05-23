Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmBank
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private ImageList2 As New ImageList()
	
    Private Sub dgBankAccount_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        update_bankAccount()
    End Sub
	
	Private Sub frmBank_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()

        load_dgBankAccount()

    End Sub
	Private Sub load_dgBankAccount()
		
        Try
            Dim cmd As SqlCommand = cn.CreateCommand()
            sStmt = "SELECT BankAccount.cust_id, " & " Customer.cust_name AS Cust, " & " Bank.bank_id, Bank.bank_name AS 'Bank', " & " BankAccount.bank_account AS Account , " & " BankAccount.bank_account_balance AS Balance," & " BankAccount.last_check_no AS LastCheck, " & " BankAccount.bank_cust_seq " & "FROM Bank, BankAccount, Customer " & "WHERE Bank.bank_id = BankAccount.bank_id " & " AND BankAccount.cust_id = Customer.cust_id " & " ORDER BY Customer.cust_name, Bank.bank_name, BankAccount.bank_account"
            cmd.CommandText = sStmt

            dgBankAccount.DataSource = Nothing

            rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rsLocal.Rows.Count > 0 Then
                dgBankAccount.DataSource = rsLocal
            Else

                dgBankAccount.DataSource = Nothing
                Exit Sub
            End If

            'Format Datagrid
            dgBankAccount.Columns("cust_id").Visible = False
            dgBankAccount.Columns("bank_id").Visible = False
            dgBankAccount.Columns("bank_cust_seq").Visible = False
            'dgBankAccount.Columns("bank_account_balance_mask").Visible = False

            dgBankAccount.Columns("Cust").Width = VB6.TwipsToPixelsX(1800)
            dgBankAccount.Columns("Bank").Width = VB6.TwipsToPixelsX(1300)
            dgBankAccount.Columns("Account").Width = VB6.TwipsToPixelsX(1600)
            dgBankAccount.Columns("Balance").Width = VB6.TwipsToPixelsX(800)
            dgBankAccount.Columns("LastCheck").Width = VB6.TwipsToPixelsX(1100)

            dgBankAccount.Refresh()
            'dgBankAccount.Refresh()

            Exit Sub
        Catch ex As Exception
            save_error(Me.Name, "load_dgBankAccount")
            MsgBox("Unexpected error found while loading Bank Account Information." & vbCrLf & "Review lod file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
        End Try
       
    End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)

        Select Case Button.Name
            Case "new"
                add_bankAccount()
            Case "save"
                update_bankAccount()
            Case "delete"
                delete_bankAccount()
            Case "exit"
                Me.Close()
        End Select

    End Sub
	Private Sub add_bankAccount()
		gBankAccount.bFlag = General.modo.NewRecord
		If set_data Then
			VB6.ShowForm(frmBankEntry, VB6.FormShowConstants.Modal, Me)
			If gBankAccount.bFlag = General.modo.SavedRecord Then
				load_dgBankAccount()
			End If
		End If
		
	End Sub
    Private Sub update_bankAccount()

        If dgBankAccount.SelectedRows.Count < 1 Then
            If dgBankAccount.SelectedCells.Count > 0 Then
                dgBankAccount.Rows(dgBankAccount.SelectedCells(0).RowIndex).Selected = True
            End If
        End If

        'If dgBankAccount.SelBookmarks.Count > 0 Then
        If dgBankAccount.SelectedRows.Count > 0 Then
            'ok
            gBankAccount.bFlag = General.modo.UpdateRecord
            If set_data() Then
                VB6.ShowForm(frmBankEntry, VB6.FormShowConstants.Modal, Me)
                If gBankAccount.bFlag = General.modo.SavedRecord Then
                    load_dgBankAccount()
                End If
            End If
        Else
            MsgBox("Please select a record before attempting this command.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
            Exit Sub
        End If

    End Sub
	
	Private Function set_data() As Boolean
		
		set_data = True
		
		Select Case gBankAccount.bFlag
			Case General.modo.NewRecord
				gBankAccount.sBankAccount = ""
				gBankAccount.nBankAccountBalance = 0
				gBankAccount.sBankAccountBalanceMask = ""
				gBankAccount.nLastCheckNo = 1
				
				
				
			Case General.modo.UpdateRecord

                If Not IsDBNull(dgBankAccount.SelectedRows(0).Cells("bank_cust_seq").Value) Then
                    If CDbl(dgBankAccount.SelectedRows(0).Cells("bank_cust_seq").Value) > 0 Then
                        gBankAccount.nBankCustSeq = CShort(dgBankAccount.SelectedRows(0).Cells("bank_cust_seq").Value)
                    Else
                        MsgBox("Failed to load Bank Id", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                        set_data = False
                        Exit Function
                    End If
                Else
                    MsgBox("Failed to load Bank Id", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                    set_data = False
                    Exit Function
                End If
				
				'BankId
                If Not IsDBNull(dgBankAccount.SelectedRows(0).Cells("bank_id").Value) Then
                    gBankAccount.nBankId = CShort(dgBankAccount.SelectedRows(0).Cells("bank_id").Value)
                Else
                    MsgBox("Bank information was not properly loaded.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                    set_data = False
                    Exit Function
                End If
				
				'CustId
                If Not IsDBNull(dgBankAccount.SelectedRows(0).Cells("cust_id").Value) Then
                    gBankAccount.sCustId = dgBankAccount.SelectedRows(0).Cells("cust_id").Value
                End If
				
				'Bank Account
                If Not IsDBNull(dgBankAccount.SelectedRows(0).Cells("Account").Value) Then
                    gBankAccount.sBankAccount = dgBankAccount.SelectedRows(0).Cells("Account").Value
                Else
                    MsgBox("Failed to load Bank Account", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                    set_data = False
                    Exit Function
                End If
				
				'Balance
                If Not IsDBNull(dgBankAccount.SelectedRows(0).Cells("balance").Value) Then
                    gBankAccount.nBankAccountBalance = CDbl(dgBankAccount.SelectedRows(0).Cells("balance").Value)
                Else
                    gBankAccount.nBankAccountBalance = 0
                End If
				
				'Last Check No
                If Not IsDBNull(dgBankAccount.SelectedRows(0).Cells("LastCheck").Value) Then
                    gBankAccount.nLastCheckNo = CInt(dgBankAccount.SelectedRows(0).Cells("LastCheck").Value)
                Else
                    MsgBox("Failed to get Last printed Check.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                    set_data = False
                    Exit Function
                End If
				
		End Select
		
	End Function
	Private Sub delete_bankAccount()
		Dim nRecords As Short
        Dim cmd As SqlCommand = cn.CreateCommand()
		On Error GoTo ErrorHandler
        'dgBankAccount.SelectedRows.Count
        'If dgBankAccount.SelBookmarks.Count > 0 Then
        If dgBankAccount.SelectedRows.Count > 0 Then
            'Verify if there is no check associated to this Bank Account
            sStmt = "SELECT COUNT(*) FROM BCheck " & " WHERE bank_cust_seq=" & Str(CDbl(dgBankAccount.SelectedRows(0).Cells("bank_cust_seq").Value))
            cmd.CommandText = sStmt

            rs = getDataTable(sStmt) ' cmd.ExecuteReader()
            If rs.Rows.Count > 0 Then
                If rs.Rows(0).Item(0) > 0 Then
                    MsgBox("Failed to delete. Found some checks associated to this Bank Account.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                    Exit Sub
                End If
            End If

            sStmt = "DELETE FROM BankAccount " & "WHERE bank_cust_seq =" & Str(CDbl(dgBankAccount.SelectedRows(0).Cells("bank_cust_seq").Value))
            cmd.CommandText = sStmt
            nRecords = cmd.ExecuteNonQuery()
            If nRecords > 0 Then
                'ok
                MsgBox("Bank Account was successfully removed.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                load_dgBankAccount()
                Exit Sub
            Else
                MsgBox("Failed to delete Bank Account.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                Exit Sub
            End If

        Else
            MsgBox("You must select a record before attempting this command.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
            Exit Sub
        End If

        Exit Sub

ErrorHandler:
        save_error(Me.Name, "delete_bankAccount")
        MsgBox("Unexpected error found while deleting Bank Account." & vbCrLf & "Please review log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
		
	End Sub

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        add_bankAccount()
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        update_bankAccount()
    End Sub

    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        delete_bankAccount()
    End Sub
    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub dgBankAccount_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBankAccount.CellContentClick

    End Sub

    Private Sub dgBankAccount_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBankAccount.CellContentDoubleClick

    End Sub

    Private Sub dgBankAccount_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBankAccount.CellDoubleClick
        update_bankAccount()
    End Sub
End Class