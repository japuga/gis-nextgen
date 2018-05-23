Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmSaleRequest
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private cmLocal As SqlCommand
    Private ImageList2 As New ImageList()
	
	
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		
		
		customerChangeActions()
		
	End Sub
	'Actions that take effect when user choses a customer
	Private Sub customerChangeActions()
		
		'cust_id
		cbCustId.SelectedIndex = cbCustName.SelectedIndex
		
		'store
		sStmt = " SELECT store_number, store_id FROM store " & " WHERE cust_id = '" & cbCustId.Text & "'" & " ORDER BY store_number "
		
		load_cb_query2(cbStoreNo, sStmt, 2, True)
		If cbStoreNo.Items.Count > 0 Then
			cbStoreNo.SelectedIndex = 0
		End If
		
	End Sub
	
	'UPGRADE_WARNING: Event cbStoreNo.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbStoreNo_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbStoreNo.SelectedIndexChanged
		
		If cbStoreNo.SelectedIndex >= 0 Then
			storeChangeActions((cbCustId.Text), VB6.GetItemData(cbStoreNo, cbStoreNo.SelectedIndex))
		Else
			'Clear since no store was selected
			storeChangeActions("--", 0)
		End If
		
	End Sub
	
	Private Sub storeChangeActions(ByRef custId As String, ByRef storeId As Short)
		
		load_dgRequest(custId, storeId)
		
	End Sub
	
	Private Sub dgRequest_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dgRequest.DblClick
		update_request()
		
	End Sub
	
	Private Sub frmSaleRequest_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
        cmLocal = cn.CreateCommand
        rsLocal = Nothing
		
		
        sStmt = "SELECT cust_id, cust_name FROM customer ORDER BY cust_name"
		load_cb_query2(cbCustId, sStmt, 1, True)
		
		sStmt = "SELECT cust_name FROM customer ORDER BY cust_name"
		load_cb_query2(cbCustName, sStmt, 1, True)
		
		If cbCustName.Items.Count > 0 Then
			cbCustName.SelectedIndex = 0
		End If
		
		
		cbCustId.Visible = False
		
		'load_dgRequest "--", 0
	End Sub
	
	Private Sub load_dgRequest(ByRef sCustId As String, ByRef nStoreId As Short)
		
		sStmt = " SELECT a.request_seq, a.cust_id, a.store_id,  b.store_number Store, " & " a.request_no Request, a.request_date Received , " & " a.response_date Response, a.tracking_no Tracking, a.notes " & " FROM saleRequest a, Store b " & " WHERE a.cust_id =  '" & sCustId & "' " & " AND a.store_id =  " & Str(nStoreId) & " AND a.cust_id = b.cust_id " & " AND a.store_id = b.store_id "
		
		
		'UPGRADE_NOTE: Object dgRequest.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		dgRequest.DataSource = Nothing
		
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn)
        If rsLocal.Rows.Count > 0 Then
            dgRequest.DataSource = rsLocal
        Else
            Exit Sub
        End If
		
		'Formato
		dgRequest.Columns("Store").Width = VB6.TwipsToPixelsX(1500)
		
		dgRequest.Columns("request_seq").Visible = False
		dgRequest.Columns("cust_id").Visible = False
		dgRequest.Columns("store_id").Visible = False
		dgRequest.Columns("notes").Visible = False
		
		'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        dgRequest.Refresh()
		
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)

        'Clear record
        clear_gSaleRequest()

        Select Case Button.Name
            Case "new"
                gSaleRequest.bFlag = General.modo.NewRecord
                gSaleRequest.sCustId = cbCustId.Text
                gSaleRequest.sCustName = cbCustName.Text

                gSaleRequest.nStoreId = VB6.GetItemData(cbStoreNo, cbStoreNo.SelectedIndex)
                gSaleRequest.sStoreNo = cbStoreNo.Text

                VB6.ShowForm(frmSaleRequestEntry, VB6.FormShowConstants.Modal, Me)

                'If gSaleRequest.bFlag = modo.SavedRecord Then
                load_dgRequest((cbCustId.Text), VB6.GetItemData(cbStoreNo, cbStoreNo.SelectedIndex))
                'End If

            Case "save"
                update_request()
            Case "exit"
                Me.Close()
        End Select

    End Sub
	
	Private Sub update_request()
		
		
		If dgRequest.SelBookmarks.Count <= 0 Then
			MsgBox("Please select a record before attempting this action", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Message")
			Exit Sub
		End If
		
		
		gSaleRequest.bFlag = General.modo.UpdateRecord
		gSaleRequest.sCustId = cbCustId.Text
		gSaleRequest.sCustName = cbCustName.Text
		
		gSaleRequest.nStoreId = VB6.GetItemData(cbStoreNo, cbStoreNo.SelectedIndex)
		gSaleRequest.sStoreNo = cbStoreNo.Text
		
		
		gSaleRequest.nRequestSeq = CShort(dgRequest.Columns("request_seq").Text)
		gSaleRequest.sRequestNo = dgRequest.Columns("Request").Text
		gSaleRequest.dtRequestDate = CDate(dgRequest.Columns("Received").Text)
		gSaleRequest.dtResponseDate = CDate(dgRequest.Columns("Response").Text)
		gSaleRequest.sNotes = dgRequest.Columns("notes").Text
		
		VB6.ShowForm(frmSaleRequestEntry, VB6.FormShowConstants.Modal, Me)
		
		'If gSaleRequest.bFlag = modo.SavedRecord Then
		load_dgRequest((cbCustId.Text), VB6.GetItemData(cbStoreNo, cbStoreNo.SelectedIndex))
		'End If
		
	End Sub
End Class