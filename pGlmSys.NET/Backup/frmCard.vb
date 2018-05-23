Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmCard
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private ImageList2 As New ImageList()
	
	'UPGRADE_WARNING: Event cbBankName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbBankName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbBankName.SelectedIndexChanged
		load_dgCard()
	End Sub
	Private Sub load_dgCard()
        sStmt = "SELECT card_seq, card_type as 'Type', " & " card_number AS  Card, card_balance AS Balance " & " FROM CreditCard " & _
                " WHERE bank_id =" & Str(VB6.GetItemData(cbBankName, cbBankName.SelectedIndex))
        Dim cmd As SqlCommand = cn.CreateCommand
        dgCard.DataSource = Nothing
		
        cmd.CommandText = sStmt
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsLocal.Rows.Count > 0 Then
            dgCard.DataSource = rsLocal
            dgCard.Columns("card_seq").Visible = False
            dgCard.Columns("Type").Width = VB6.TwipsToPixelsX(2000)
            dgCard.Columns("Card").Width = VB6.TwipsToPixelsX(2000)
            dgCard.Columns("Balance").Width = VB6.TwipsToPixelsX(1500)

        End If
        gCreditCard.nBankId = VB6.GetItemData(cbBankName, cbBankName.SelectedIndex)
		
		
		
	End Sub
	
    Private Sub dgCard_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        modify_card()
    End Sub
	
	Private Sub frmCard_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()

        sStmt = "SELECT bank_name, bank_id " & "FROM bank"
        load_cb_query2(cbBankName, sStmt, 2, True)


        If cbBankName.Items.Count > 0 Then
            cbBankName.SelectedIndex = 0
        End If

    End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "new"
                gCreditCard.bFlag = General.modo.NewRecord
                VB6.ShowForm(frmCardEntry, VB6.FormShowConstants.Modal, Me)
                If gCreditCard.bFlag = General.modo.SavedRecord Then
                    load_dgCard()
                End If

            Case "save"
                modify_card()
            Case "delete"
                If dgCard.SelectedRows.Count > 0 Then
                    If MsgBox("Do you want to delete selected Credit Card?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "GLM Message") = MsgBoxResult.Yes Then

                        If delete_card(CShort(dgCard.SelectedRows(0).Cells("card_seq").Value)) Then
                            load_dgCard()
                        End If
                    End If
                Else
                    MsgBox("Please select a record before attempting this action.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Message")
                End If
            Case "exit"
                Me.Close()
        End Select
    End Sub
	
	Private Function delete_card(ByRef nCardSeq As Short) As Boolean
		Dim nRecords As Short
        Dim cmd As sqlcommand = cn.CreateCommand()
		delete_card = False
		
        Try
            nRecords = 0
            sStmt = "SELECT COUNT(*) FROM BTransaction " & " WHERE card_seq =" & Str(nCardSeq)
            cmd.CommandText = sStmt
            rs = getDataTable(sStmt) ' cmd.ExecuteReader()
            If rs.Rows.Count > 0 Then
                If IsDBNull(rs.Rows(0).Item(0)) Or rs.Rows(0).Item(0) = 0 Then
                    sStmt = "DELETE FROM CreditCard " & " WHERE card_seq = " & Str(nCardSeq)
                    cmd.CommandText = sStmt
                    nRecords = cmd.ExecuteNonQuery()
                    If nRecords > 0 Then
                        MsgBox("Credit Card was successfully removed.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                        delete_card = True
                        Exit Function
                    Else
                        MsgBox("Failed to delete Credit Card information." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                        write_msg("delete_card", "card_seq:" & Str(nCardSeq))
                        Exit Function
                    End If
                Else
                    MsgBox("Can not delete this Credit Card." & vbCrLf & "It has been used in one or more invoice payments.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Function
                End If
            End If
            Exit Function

        Catch e As Exception
            save_error(Me.Name, "delete_card")
            MsgBox("Unexpected error was found while deleting Credit Card." & vbCrLf & "Check log files for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
        End Try
    End Function
    Private Sub modify_card()

        If dgCard.SelectedRows.Count < 1 Then
            If dgCard.SelectedCells.Count > 0 Then
                dgCard.Rows(dgCard.SelectedCells(0).RowIndex).Selected = True
            End If
        End If

        If set_data() Then
            gCreditCard.bFlag = General.modo.UpdateRecord
            VB6.ShowForm(frmCardEntry, VB6.FormShowConstants.Modal, Me)
            If gCreditCard.bFlag = General.modo.SavedRecord Then
                load_dgCard()
            End If

        End If

    End Sub
	Private Function set_data() As Boolean
		
		set_data = False
		
		If cbBankName.SelectedIndex >= 0 Then
			gCreditCard.nBankId = VB6.GetItemData(cbBankName, cbBankName.SelectedIndex)
		Else
			Exit Function
		End If
		
		
        If dgCard.SelectedRows.Count > 0 Then
            If Not IsDBNull(dgCard.SelectedRows(0).Cells("Card").Value) Then
                gCreditCard.sCardNumber = dgCard.SelectedRows(0).Cells("Card").Value
            Else
                Exit Function
            End If

            If Not IsDBNull(dgCard.SelectedRows(0).Cells("card_seq").Value) Then
                gCreditCard.nCardSeq = CShort(dgCard.SelectedRows(0).Cells("card_seq").Value)
            Else
                Exit Function
            End If

            If Not IsDBNull(dgCard.SelectedRows(0).Cells("Type").Value) Then
                gCreditCard.sCardType = dgCard.SelectedRows(0).Cells("Type").Value
            Else
                Exit Function
            End If

            If Not IsDBNull(dgCard.SelectedRows(0).Cells("Balance").Value) Then
                gCreditCard.nCardBalance = CDbl(dgCard.SelectedRows(0).Cells("Balance").Value)
            Else
                gCreditCard.nCardBalance = 0
            End If

            set_data = True
        Else
            MsgBox("Please select a record before attempting this action.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Message")
            Exit Function
        End If
		
	End Function

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        gCreditCard.bFlag = General.modo.NewRecord
        VB6.ShowForm(frmCardEntry, VB6.FormShowConstants.Modal, Me)
        If gCreditCard.bFlag = General.modo.SavedRecord Then
            load_dgCard()
        End If
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        modify_card()
    End Sub

    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        If dgCard.SelectedRows.Count > 0 Then
            If MsgBox("Do you want to delete selected Credit Card?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "GLM Message") = MsgBoxResult.Yes Then

                If delete_card(CShort(dgCard.SelectedRows(0).Cells("card_seq").Value)) Then
                    load_dgCard()
                End If
            End If
        Else
            MsgBox("Please select a record before attempting this action.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Message")
        End If
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub dgCard_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCard.CellDoubleClick
        modify_card()
    End Sub
End Class