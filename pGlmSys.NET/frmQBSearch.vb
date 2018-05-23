Option Strict Off
Option Explicit On
Friend Class frmQBSearch
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		gQBSearch.qb_name = ""
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		get_data()
	End Sub
	
    Private Sub dgQB_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        get_data()
    End Sub
	Private Sub get_data()
		gQBSearch.qb_name = ""
        If dgQB.CurrentRow.Index >= 0 Then
            gQBSearch.qb_name = dgQB.CurrentRow.Cells("Name").Value
        End If
		Me.Close()
		
	End Sub
	Private Sub frmQBSearch_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		load_comp()
	End Sub
	
	Private Sub init_vars()
        rsLocal = Nothing
		
		gQBSearch.bFlag = False
		gQBSearch.qb_name = ""
	End Sub
	
	Private Sub load_comp()
		sStmt = "SELECT qb_vendor.name AS Name, " & " rtrim(addr1) as Addr1 ," & " rtrim(addr2) AS Addr2, rtrim(addr3) AS City, " & " rtrim(companyname) Company " & " FROM qb_vendor " & " WHERE qb_group_id = '" & Trim(gQBSearch.sParam) & "'" & " ORDER BY qb_vendor.name"
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count <= 0 Then
            Exit Sub
        End If

        dgQB.Text = "Quick Books Vendor"
        dgQB.DataSource = rsLocal
        'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        dgQB.Refresh()

        dgQB.Columns("Name").Width = VB6.TwipsToPixelsX(4000)
        dgQB.Columns("Addr2").Width = VB6.TwipsToPixelsX(2000)
        dgQB.Columns("City").Width = VB6.TwipsToPixelsX(2000)
	End Sub

    Private Sub dgQB_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgQB.CellDoubleClick
        get_data()
    End Sub
End Class