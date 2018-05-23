Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmVBranchBrowse
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
	
	Private Sub frmVBranchBrowse_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()

		
		txtVendName.Text = gVendor.sVendName
		txtVendPayAddress.Text = gVendor.sVendPayAddress
		
		load_dgVBranch(gVendor.nVendId, gVendor.sVendPayAddress)
		
	End Sub
	
	Private Sub load_dgVBranch(ByRef nVendId As Short, ByRef sVendPayAddress As String)
		
		On Error GoTo ErrorHandler
		
		sStmt = " SELECT vend_seq, vend_name, " & " vend_area AS 'Area', " & " vend_address as 'Address', " & " vend_city AS 'City', " & " state_id AS 'State', vend_zip AS 'Zip' " & " FROM VBranch " & " WHERE vend_id = " & Str(nVendId) & " AND vend_pay_address ='" & Trim(sVendPayAddress) & "'"
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		
		'UPGRADE_NOTE: Object dgVBranch.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		dgVBranch.DataSource = Nothing

        dgVBranch.DataSource = rsLocal

        'Formato
		dgVBranch.Columns("vend_seq").Visible = False
		dgVBranch.Columns("vend_name").Visible = False
		dgVBranch.Columns("Area").Width = VB6.TwipsToPixelsX(1200)
		dgVBranch.Columns("Address").Width = VB6.TwipsToPixelsX(2000)
		dgVBranch.Columns("State").Width = VB6.TwipsToPixelsX(450)
		dgVBranch.Columns("City").Width = VB6.TwipsToPixelsX(1000)
		dgVBranch.Columns("Zip").Width = VB6.TwipsToPixelsX(900)
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_dgVBranch")
		MsgBox("Failed to retrieve Vendor Info. Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
	End Sub
	
	Private Sub frmVBranchBrowse_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_NOTE: Object rsLocal may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rsLocal = Nothing
	End Sub
End Class