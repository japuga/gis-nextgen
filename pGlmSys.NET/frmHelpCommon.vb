Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmHelpCommon
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		cbCustId.SelectedIndex = cbCustName.SelectedIndex
		
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdFilter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFilter.Click
		Dim sFilter As String
		If Not validate_Renamed() Then
			Exit Sub
		End If
		
		sFilter = build_store_filter
		If Len(sFilter) = 0 Then
			MsgBox("Enter any criteria before applying filters.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
		Else
			load_dg(sFilter)
		End If
		
	End Sub
	
	Private Function build_store_filter() As String
		Dim sFilter As String
		
		sFilter = ""
		
		If Len(txtStoreNumber.Text) > 0 Then
			sFilter = sFilter & " AND store_number LIKE '%" & quotation_mask(Trim(txtStoreNumber.Text)) & "%'"
		End If
		
		If Len(txtStoreName.Text) > 0 Then
			sFilter = sFilter & " AND store_name LIKE '%" & quotation_mask(Trim(txtStoreName.Text)) & "%'"
		End If
		
		If Len(txtStoreAddress.Text) > 0 Then
			sFilter = sFilter & " AND store_address LIKE '%" & quotation_mask(Trim(txtStoreAddress.Text)) & "%'"
		End If
		
		If Len(txtStoreCity.Text) > 0 Then
			sFilter = sFilter & " AND store_city LIKE '%" & quotation_mask(Trim(txtStoreCity.Text)) & "%'"
		End If
		
		If Len(txtAccountMask.Text) > 0 Then
			sFilter = sFilter & " AND account_mask LIKE '%" & quotation_mask(Trim(txtAccountMask.Text)) & "%'"
		End If
		
		If Len(txtVendName.Text) > 0 Then
			sFilter = sFilter & " AND vend_name LIKE '%" & quotation_mask(Trim(txtVendName.Text)) & "%'"
		End If
		
		If cbState.SelectedIndex > 0 Then
			sFilter = sFilter & " AND s.state_id = '" & cbState.Text & "'"
		End If
		
		If Len(txtStoreZip.Text) > 0 Then
			sFilter = sFilter & " AND store_zip LIKE '%" & txtStoreZip.Text & "%'"
		End If
		
		build_store_filter = sFilter
	End Function
	
	
	Private Sub load_dg(ByRef sFilter As String)
		
		Dim sStr As String
		Dim sOrderBy As String
		
		
		sStr = "SELECT s.cust_id AS Customer," & "s.state_id AS State," & "RTRIM(s.store_number)  AS 'Store Number'," & "RTRIM(s.store_name) AS 'Store Name'," & "RTRIM(s.store_co_code) AS Code," & "a.account_mask AS 'Account', " & "v.vend_name AS 'Vendor', " & "s.store_address AS 'Store Address', " & "s.store_city AS City," & "s.store_zip AS Zip ," & "s.store_id  AS StoreID " & "FROM Store s, VAccount a, VBranch v " & " WHERE s.cust_id = a.cust_id " & " AND s.store_id = a.store_id " & " AND a.vend_seq = v.vend_seq " & " AND s.cust_id ='" & cbCustId.Text & "' "
		
		
		
		sOrderBy = "ORDER BY 'Store Number'"
		
		sStmt = sStr & sFilter & sOrderBy
		
        rsHelp = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		
		dgStore.DataSource = rsHelp
		
		dgStore.Text = " Store Information"
        dgStore.Columns("Store Number").HeaderText = "Store#"
        dgStore.Columns("Store Name").HeaderText = "Name"
		dgStore.Columns("Customer").Width = VB6.TwipsToPixelsX(500)
		dgStore.Columns("Code").Width = VB6.TwipsToPixelsX(900)
		dgStore.Columns("Store Address").Width = VB6.TwipsToPixelsX(4000)

        dgStore.Refresh()
		dgStore.Columns("StoreId").Visible = False
		
		

        If rsHelp.Rows.Count > 0 Then
            lRecords.Text = "Total Records:" & Str(rsHelp.Rows.Count)
        Else
            lRecords.Text = ""
        End If


        Exit Sub

ErrorHandler:
        save_error(Me.Name, "load_dg")
        MsgBox("An unexpected error has ocurred, check log file for details", MsgBoxStyle.Critical, "GLM Error")
	End Sub
	
	
	Public Sub init_vars()
		'Customer
		sStmt = "SELECT cust_id,cust_name FROM customer" & " WHERE cust_id IN (SELECT DISTINCT cust_id " & "   FROM suser_data  " & "   WHERE suser_name='" & Trim(gsUser) & "') " & " ORDER BY cust_name "
		load_cb_query(cbCustId, sStmt, 1)
		
		sStmt = "SELECT cust_name,cust_id FROM customer" & " WHERE cust_id IN (SELECT DISTINCT cust_id " & "   FROM suser_data  " & "   WHERE suser_name='" & Trim(gsUser) & "') " & " ORDER BY cust_name"
		load_cb_query(cbCustName, sStmt, 1)
		
		If cbCustName.Items.Count > 0 Then
			cbCustName.SelectedIndex = 0
		End If
		
        'State
        cbState.Items.Clear()
		cbState.Items.Insert(0, UI_ALL)
		sStmt = "SELECT state_id, state_name FROM state "
		load_cb_query2(cbState, sStmt, 1, False)
		
		
		If cbState.Items.Count > 0 Then
			cbState.SelectedIndex = 0
		End If
		
	End Sub
	
	
	Private Sub cmdShowAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdShowAll.Click
		load_dg("")
	End Sub
	'UPGRADE_WARNING: Form event frmHelpCommon.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub frmHelpCommon_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		set_defaults()
	End Sub
	Private Sub frmHelpCommon_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	Private Sub set_defaults()
		txtStoreNumber.Focus()
	End Sub
	'UPGRADE_NOTE: validate was upgraded to validate_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Function validate_Renamed() As Boolean
		validate_Renamed = False
		
		If Me.cbCustName.SelectedIndex < 0 Then
			MsgBox("A Customer must be selected", MsgBoxStyle.OKOnly, "GLM Warning")
			Exit Function
		End If
		
		validate_Renamed = True
		
	End Function
End Class