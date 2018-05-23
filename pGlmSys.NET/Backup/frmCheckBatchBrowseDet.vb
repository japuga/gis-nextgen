Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmCheckBatchBrowseDet
    Inherits System.Windows.Forms.Form
    Public ImageList2 As New ImageList()
    Private rsLocal As DataTable
	
	Private Sub frmCheckBatchBrowseDet_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		load_comp()
	End Sub
	
	Private Sub init_vars()

	End Sub
	
	Private Sub load_comp()
		VB6.ShowForm(frmCheckBatchBrowse, VB6.FormShowConstants.Modal, Me)
        'Dim ss As Date
		
		If gCheckBatchSearch.bFlag Then
			load_dgBatch(False, gCheckBatchSearch.sCustId, gCheckBatchSearch.nBatchId, gCheckBatchSearch.sDateFrom, gCheckBatchSearch.sDateTo)
			
		End If
		
	End Sub
	
	Private Sub load_dgBatch(ByRef bInitialize As Boolean, ByRef sCustId As String, ByRef nBatchId As Short, ByRef sBatchFrom As String, ByRef sBatchTo As String)
		
        sStmt = "SELECT BBatch.batch_id 'Batch', " & " Customer.cust_name AS 'Customer', " & _
                    " BBatch.create_dtim AS 'Created'," & _
                    " BBatch.num_checks  AS 'Num Checks', " & _
                    " BBatch.num_invoices AS 'Num Inv', " & _
                    " SUM(BCheck.check_amount) AS 'Total' " & _
                " FROM  BBatch, BCheck, Customer " & _
                " WHERE  BBatch.cust_id = Customer.cust_id " & _
                    " AND BBatch.batch_id = BCheck.batch_id " & _
                    " AND BBatch.cust_id = '" & sCustId & "' " & _
                    " AND BBatch.create_dtim BETWEEN '" & sBatchFrom & "' " & " AND '" & sBatchTo & "' "
		
		If nBatchId > 0 Then
			sStmt = sStmt & " AND BBatch.batch_id =" & Str(nBatchId)
		End If
		
		If bInitialize Then
			sStmt = sStmt & " AND BBatch.batch_id =-1"
		End If
		
        sStmt = sStmt & " GROUP BY BBatch.batch_id, Customer.cust_name, " & _
            "   BBatch.create_dtim,BBatch.num_checks , " & _
            "   BBatch.num_invoices " & " ORDER BY BBatch.batch_id DESC"
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        dgBatch.DataSource = rsLocal


        'If rsLocal.RecordCount > 0 Then
        'rsLocal.MoveFirst
        'End If
		
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button3.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)

        Select Case Button.Name
            Case "search"
                load_comp()
            Case "print"
                If dgBatch.SelectedRows.Count > 0 Then
                    If find_printer2(True) Then
                        VB6.ShowForm(frmCheckPaper, VB6.FormShowConstants.Modal, Me)
                        print_batch2(CShort(dgBatch.SelectedRows(0).Cells("Batch").Value), General.gCheckPaperSource)
                        MsgBox("Print jobs were submitted.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                    End If
                Else
                    MsgBox("You must select a row before performing this action.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Warning")
                End If

            Case "exit"
                Me.Close()
        End Select

    End Sub

    Private Sub btPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrint.Click
        If dgBatch.SelectedRows.Count > 0 Then
            If find_printer2(True) Then
                VB6.ShowForm(frmCheckPaper, VB6.FormShowConstants.Modal, Me)
                print_batch2(CShort(dgBatch.SelectedRows(0).Cells("Batch").Value), General.gCheckPaperSource)
                MsgBox("Print jobs were submitted.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
            End If
        Else
            MsgBox("You must select a row before performing this action.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Warning")
        End If
    End Sub

    Private Sub btSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSearch.Click
        load_comp()
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub
End Class