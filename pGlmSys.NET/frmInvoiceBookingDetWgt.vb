Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmInvoiceBookingDetWgt
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private ImageList2 As New ImageList()
	
	Private Sub dgWeight_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dgWeight.DblClick
		update_entry()
		
	End Sub
	
	Private Sub frmInvoiceBookingDetWgt_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
        rsLocal = Nothing
		
		load_dgWeight()
		
	End Sub
	
	Private Sub load_dgWeight()
		
		
		sStmt = "SELECT sequence_id, Qty, weight as 'Weight', " & " ticket as 'Ticket', ticket_date as 'Date', weight_unit_type " & " FROM vInvoiceDetWgt " & " WHERE cust_id = '" & Trim(gInvHeaderRecord.sCustId) & "' " & " AND invoice_no = '" & gInvHeaderRecord.sInvoiceNo & "'" & " AND store_id = " & Str(gInvHeaderRecord.nStoreId) & " AND account_no = '" & gInvHeaderRecord.sAccountNo & "' " & " AND vend_seq = " & Str(gInvHeaderRecord.nVendSeq) & " AND invoice_det_no = " & Str(gInvDetRecord.nInvoiceDetNo) & " ORDER BY sequence_id "
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn)
        If rsLocal.Rows.Count > 0 Then
            dgWeight.DataSource = rsLocal
        End If
		
		dgWeight.Columns("sequence_id").Visible = False
		dgWeight.Columns("weight_unit_type").Visible = False
		dgWeight.Columns("qty").Width = VB6.TwipsToPixelsX(800)
		dgWeight.Columns("weight").Width = VB6.TwipsToPixelsX(800)
		dgWeight.Columns("ticket").Width = VB6.TwipsToPixelsX(1200)
		dgWeight.Columns("Date").Width = VB6.TwipsToPixelsX(1200)
		'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        dgWeight.Refresh()
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "new"

                gInvDetWgt.bFlag = General.modo.NewRecord

                VB6.ShowForm(frmInvoiceBookingDetWgtEntry, VB6.FormShowConstants.Modal, Me)
                If gInvDetWgt.bFlag = General.modo.SavedRecord Then
                    load_dgWeight()
                End If

            Case "save"
                update_entry()
            Case "delete"
                If dgWeight.SelBookmarks.Count = 0 Then
                    MsgBox("Please select a record before attempting this command.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Warning")
                    Exit Sub
                Else
                    If MsgBox("Do you want to delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "GLM Message") = MsgBoxResult.Yes Then
                        delete_record(dgWeight.Columns("sequence_id").Text)
                        load_dgWeight()
                    Else
                        Exit Sub
                    End If
                End If

            Case "exit"
                Me.Close()
        End Select

    End Sub
	Private Sub update_entry()
		If dgWeight.SelBookmarks.Count = 0 Then
			MsgBox("Please select a record before attempting this command.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Warning")
			Exit Sub
		End If
		
		gInvDetWgt.sWeightUnitType = dgWeight.Columns("weight_unit_type").Text
		gInvDetWgt.nQty = CDbl(dgWeight.Columns("Qty").Text)
		gInvDetWgt.nWeight = CDbl(dgWeight.Columns("Weight").Text)
		gInvDetWgt.sTicket = dgWeight.Columns("Ticket").Text
		gInvDetWgt.dtTicketDate = CDate(dgWeight.Columns("Date").Text)
		gInvDetWgt.nSequenceId = CShort(dgWeight.Columns("sequence_id").Text)
		
		gInvDetWgt.bFlag = General.modo.UpdateRecord
		VB6.ShowForm(frmInvoiceBookingDetWgtEntry, VB6.FormShowConstants.Modal, Me)
		
		If gInvDetWgt.bFlag = General.modo.SavedRecord Then
			load_dgWeight()
		End If
		
	End Sub
	Private Sub delete_record(ByRef sSequenceId As String)
		Dim nRecords As Short
		
		sStmt = "DELETE FROM vInvoiceDetWgt " & " WHERE cust_id = '" & Trim(gInvHeaderRecord.sCustId) & "' " & " AND invoice_no = '" & gInvHeaderRecord.sInvoiceNo & "'" & " AND store_id = " & Str(gInvHeaderRecord.nStoreId) & " AND account_no = '" & gInvHeaderRecord.sAccountNo & "' " & " AND vend_seq = " & Str(gInvHeaderRecord.nVendSeq) & " AND invoice_det_no = " & Str(gInvDetRecord.nInvoiceDetNo) & " AND sequence_id = " & sSequenceId
		
        cm = cn.CreateCommand() '.let_ActiveConnection(cn)
        cm.CommandType = CommandType.Text
		cm.CommandText = sStmt
        nRecords = cm.ExecuteNonQuery()
		If nRecords > 0 Then
			MsgBox("Record was successfully deleted.", MsgBoxStyle.OKOnly, "GLM Message")
		Else
			MsgBox("Failed to delete record.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Message")
		End If
	End Sub
End Class