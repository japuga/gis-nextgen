Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmCustFeeBillRange
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Public ImageList2 As New ImageList()
	
	
	Private Sub frmCustFeeBillRange_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        init_vars()
    End Sub
	
	Private Sub init_vars()
		load_dgBillingRange()
	End Sub
	Private Sub load_dgBillingRange()
		On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand()
		sStmt = "SELECT range_seq, lower_bound 'From Amount', " & " upper_bound 'To Amount', range_fee_value 'Value' " & " FROM feeBillingRange " & " WHERE fee_id =" & Str(gFeeBillingRange.nFeeId)
		
		
		
		'Set dgBillingRange.DataSource = Nothing
        cmd.CommandText = sStmt
		
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        dgBillingRange.DataSource = rsLocal

        'Format Datagrid
        dgBillingRange.Columns("range_seq").Visible = False

        dgBillingRange.Columns("From Amount").Width = VB6.TwipsToPixelsX(1800)
        dgBillingRange.Columns("To Amount").Width = VB6.TwipsToPixelsX(1800)
        dgBillingRange.Columns("Value").Width = VB6.TwipsToPixelsX(1800)

        dgBillingRange.Refresh()

        Exit Sub

ErrorHandler:
        save_error(Me.Name, "load_dgBillingrange")
        MsgBox("Unexpected error found while loading Fee Billing Range Information." & vbCrLf & "Review lod file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)

        Select Case Button.Name
            Case "new"
                add_billingRange()
            Case "save"
                update_billingRange()
            Case "delete"
                delete_billingRange()
            Case "exit"
                Me.Close()
        End Select

    End Sub
	
	Private Sub add_billingRange()
		
		gFeeBillingRangeDet.bFlag = General.modo.NewRecord
		gFeeBillingRangeDet.nFeeId = gFeeBillingRange.nFeeId
		
		VB6.ShowForm(frmCustFeeBillRangeDet, VB6.FormShowConstants.Modal, Me)
		If gFeeBillingRangeDet.bFlag = General.modo.SavedRecord Then
			save_billingRange((General.modo.NewRecord))
			load_dgBillingRange()
		End If
		
	End Sub
	Private Sub update_billingRange()
		gFeeBillingRangeDet.bFlag = General.modo.UpdateRecord

        If dgBillingRange.SelectedRows.Count <= 0 Then
            For Each aCell As DataGridViewCell In dgBillingRange.SelectedCells
                dgBillingRange.Rows(aCell.RowIndex).Selected = True
            Next aCell
        End If

        If dgBillingRange.SelectedRows.Count > 0 Then
            gFeeBillingRangeDet.nFeeId = gFeeBillingRange.nFeeId
            gFeeBillingRangeDet.nRangeSeq = CShort(dgBillingRange.CurrentRow.Cells("range_seq").Value)
            gFeeBillingRangeDet.nLowerBound = CDbl(dgBillingRange.CurrentRow.Cells("From Amount").Value)
            gFeeBillingRangeDet.nUpperBound = CDbl(dgBillingRange.CurrentRow.Cells("To Amount").Value)
            gFeeBillingRangeDet.nRangeFeeValue = CDbl(dgBillingRange.CurrentRow.Cells("Value").Value)
        Else
            MsgBox("Please select a record before taking this option.", MsgBoxStyle.Information, "GLM Warning")
            Exit Sub
        End If
		
		VB6.ShowForm(frmCustFeeBillRangeDet, VB6.FormShowConstants.Modal, Me)
		If gFeeBillingRangeDet.bFlag = General.modo.SavedRecord Then
			save_billingRange((General.modo.UpdateRecord))
			load_dgBillingRange()
		End If
		
	End Sub
	Private Sub delete_billingRange()
		
		Dim nRecords As Short
        Dim cmd As sqlcommand = cn.CreateCommand()
        If dgBillingRange.SelectedRows.Count > 0 Then
            'Delete from FeeBillingRange
            sStmt = "DELETE FROM FeeBillingRange " & " WHERE fee_id=" & Str(gFeeBillingRange.nFeeId) & " AND range_seq =" & Str(CDbl(dgBillingRange.CurrentRow.Cells("range_seq").Value))
            cmd.CommandText = sStmt
            nRecords = cmd.ExecuteNonQuery()
            If nRecords > 0 Then
                MsgBox("Record was successfully removed.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
            End If
        Else
            MsgBox("Please select a record before attempting this command.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
        End If
		
		load_dgBillingRange()
	End Sub
	
	
	Private Sub save_billingRange(ByRef bOption As General.modo)
		Dim nRangeSeq As Short
		Dim nRecords As Short
        Dim cmd As SqlCommand = cn.CreateCommand()

		Select Case bOption
			Case General.modo.NewRecord
				'New range sequence
				sStmt = " SELECT MAX(range_seq) FROM FeeBillingRange " & " WHERE fee_id =" & Str(gFeeBillingRangeDet.nFeeId)
				nRangeSeq = 0
                cmd.CommandText = sStmt
                rs = getDataTable(sStmt) ' cmd.ExecuteReader()

                Dim thisVal As String
                For Each aRow As DataRow In rs.Rows
                    For Each aCol As DataColumn In rs.Columns
                        thisVal = aRow.Item(aCol).ToString
                    Next aCol
                Next aRow
                'Dim acount As Integer = rs.Rows(0).Count
                If Not IsDBNull(rs.Rows(0).Item(0)) Then
                    nRangeSeq = rs.Rows(0).Item(0)
                End If


                gFeeBillingRangeDet.nRangeSeq = nRangeSeq + 1
                'Insert
                sStmt = "INSERT INTO FeeBillingRange (fee_id, " & " range_seq, lower_bound, upper_bound, " & " range_fee_value) VALUES (" & Str(gFeeBillingRange.nFeeId) & "," & Str(gFeeBillingRangeDet.nRangeSeq) & "," & Str(gFeeBillingRangeDet.nLowerBound) & "," & Str(gFeeBillingRangeDet.nUpperBound) & "," & Str(gFeeBillingRangeDet.nRangeFeeValue) & ")"
                cmd.CommandText = sStmt
                nRecords = cmd.ExecuteNonQuery()

                If nRecords = 0 Then
                    MsgBox("Failed to insert into Fee Billing Range table.")
                End If

            Case General.modo.UpdateRecord
                sStmt = "UPDATE FeeBillingRange " & " SET lower_bound =" & Str(gFeeBillingRangeDet.nLowerBound) & "," & " upper_bound =" & Str(gFeeBillingRangeDet.nUpperBound) & "," & " range_fee_value = " & Str(gFeeBillingRangeDet.nRangeFeeValue) & " WHERE fee_id = " & Str(gFeeBillingRange.nFeeId) & " AND range_seq =" & Str(gFeeBillingRangeDet.nRangeSeq)
                cmd.CommandText = sStmt
                nRecords = cmd.ExecuteNonQuery()
                If nRecords > 0 Then
                    'ok
                Else
                    MsgBox("Failed to update FeeBillingRange table. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Sub
                End If
        End Select
		
		
		
	End Sub

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        add_billingRange()
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        update_billingRange()
    End Sub

    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        delete_billingRange()
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub
End Class