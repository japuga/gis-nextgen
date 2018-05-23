Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmBankMnt
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private ImageList2 As New ImageList()
	
    Private Sub dgBank_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        update_bank()
    End Sub
	
	Private Sub frmBankMnt_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
        'rsLocal = SqlDataReader
		
		load_dgBank()
		
	End Sub
	Private Sub load_dgBank()
		
		On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand
		sStmt = "SELECT  " & " Bank.bank_id, Bank.bank_name AS 'Bank', " & " Bank.bank_aba 'Routing'," & " Bank.check_info1, Bank.check_info2, " & " Bank.check_info3, Bank.check_info4, " & " Bank.bank_status 'Status' " & "FROM Bank " & " ORDER BY Bank.bank_name "
        cmd.CommandText = sStmt

		dgBank.DataSource = Nothing
		
		
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsLocal.Rows.Count > 0 Then
            dgBank.DataSource = rsLocal
        Else
            dgBank.DataSource = Nothing
            Exit Sub
        End If
		
		'Format Datagrid
		dgBank.Columns("bank_id").Visible = False
		dgBank.Columns("check_info1").Visible = False
		dgBank.Columns("check_info2").Visible = False
		dgBank.Columns("check_info3").Visible = False
		dgBank.Columns("check_info4").Visible = False
		
		dgBank.Columns("Bank").Width = VB6.TwipsToPixelsX(1500)
		dgBank.Columns("Routing").Width = VB6.TwipsToPixelsX(1600)
		dgBank.Columns("Status").Width = VB6.TwipsToPixelsX(900)

        dgBank.Refresh()
		
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_dgBank")
		MsgBox("Unexpected error found while loading Bank Information." & vbCrLf & "Review lod file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Sub
	
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "new"
                add_bank()
            Case "save"
                update_bank()
            Case "delete"
                delete_bank()
            Case "exit"
                Me.Close()
        End Select
    End Sub
	
	Private Sub add_bank()
		gBank.bFlag = General.modo.NewRecord
		
		VB6.ShowForm(frmBankMntEntry, VB6.FormShowConstants.Modal, Me)
		If gBank.bFlag = General.modo.SavedRecord Then
			load_dgBank()
		End If
	End Sub
	
    Private Sub update_bank()

        If dgBank.SelectedRows.Count < 1 Then
            If dgBank.SelectedCells.Count > 0 Then
                dgBank.Rows(dgBank.SelectedCells(0).RowIndex).Selected = True
            End If
        End If
        If dgBank.SelectedRows.Count < 1 Then
            MsgBox("Please select a Bank before attempting this command.", MsgBoxStyle.Exclamation, "GLM Warning")
        End If

        gBank.bFlag = General.modo.UpdateRecord
        gBank.nBankId = CShort(dgBank.SelectedRows(0).Cells("bank_id").Value)
        gBank.sBankName = dgBank.SelectedRows(0).Cells("Bank").Value
        gBank.sBankAba = dgBank.SelectedRows(0).Cells("Routing").Value.ToString()


        gBank.sBankStatus = ""
        gBank.sCheckInfo1 = ""
        gBank.sCheckInfo2 = ""
        gBank.sCheckInfo3 = ""
        gBank.sCheckInfo4 = ""


        If Not IsDBNull(dgBank.SelectedRows(0).Cells("Status").Value) Then
            gBank.sBankStatus = dgBank.SelectedRows(0).Cells("Status").Value
        End If


        If Not IsDBNull(dgBank.SelectedRows(0).Cells("check_info1").Value) Then
            gBank.sCheckInfo1 = dgBank.SelectedRows(0).Cells("check_info1").Value
        End If


        If Not IsDBNull(dgBank.SelectedRows(0).Cells("check_info2").Value) Then
            gBank.sCheckInfo2 = dgBank.SelectedRows(0).Cells("check_info2").Value
        End If


        If Not IsDBNull(dgBank.SelectedRows(0).Cells("check_info3").Value) Then
            gBank.sCheckInfo3 = dgBank.SelectedRows(0).Cells("check_info3").Value
        End If


        If Not IsDBNull(dgBank.SelectedRows(0).Cells("check_info4").Value) Then
            gBank.sCheckInfo4 = dgBank.SelectedRows(0).Cells("check_info4").Value
        End If


        VB6.ShowForm(frmBankMntEntry, VB6.FormShowConstants.Modal, Me)
        If gBank.bFlag = General.modo.SavedRecord Then
            load_dgBank()
        End If

    End Sub
	
	Private Sub delete_bank()
		Dim nRecords As Short
		nRecords = 0
        Dim cmd As sqlcommand = cn.CreateCommand()
        If dgBank.SelectedRows.Count > 0 Then
            If MsgBox("Do you want to delete this Bank", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "GLM Warning") = MsgBoxResult.No Then
                Exit Sub
            Else
                'Verify that no Account or Check exist
                'for this Bank before deleting it
                sStmt = "SELECT COUNT(*) FROM BankAccount " & "WHERE bank_id =" & Str(CDbl(dgBank.SelectedRows(0).Cells("bank_id").Value))
                cmd.CommandText = sStmt
                rs = getDataTable(sStmt) 'cmd.ExecuteReader()

                If rs.Rows(0).Item(0) > 0 Then
                    MsgBox("Can not delete Bank. Found one or more accounts related to this Bank." & vbCrLf & "Remove accounts before attempting this action.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                    Exit Sub
                End If

                'Delete
                sStmt = "DELETE FROM Bank" & " WHERE bank_id =" & Str(CDbl(dgBank.SelectedRows(0).Cells("bank_id").Value))

                cmd.CommandText = sStmt
                nRecords = cmd.ExecuteNonQuery()
                If nRecords > 0 Then
                    MsgBox("Bank was successfully removed.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                Else
                    MsgBox("Failed to delete record.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Sub
                End If
            End If
        Else
            MsgBox("You must select a record before attempting this command.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Sub
        End If
		
		load_dgBank()
	End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        add_bank()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        update_bank()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        delete_bank()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub dgBank_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBank.CellDoubleClick
        update_bank()
    End Sub
End Class