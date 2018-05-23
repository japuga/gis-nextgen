Option Strict Off
Option Explicit On
Friend Class frmStoreSearchCriteria
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
	
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		
		Me.Close()
	End Sub
	
	Private Sub cmdSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSearch.Click
		gDump.str1 = get_criteria
		Me.Close()
	End Sub
	Private Function get_criteria() As String
        Dim sCriteria As String = ""
		
		If Len(txtStoreNo.Text) > 0 Then
			sCriteria = sCriteria & " AND store_number LIKE '%" & Trim(quotation_mask(txtStoreNo.Text)) & "%'"
		End If
		
		If Len(txtStoreName.Text) > 0 Then
			sCriteria = sCriteria & " AND store_name LIKE '%" & Trim(quotation_mask(txtStoreName.Text)) & "%'"
		End If
		
		If Len(txtStoreAddress.Text) > 0 Then
			sCriteria = sCriteria & " AND store_address LIKE '%" & Trim(quotation_mask(txtStoreAddress.Text)) & "%'"
		End If
		
		If Len(txtStoreCity.Text) > 0 Then
			sCriteria = sCriteria & " AND store_city LIKE '%" & Trim(quotation_mask(txtStoreCity.Text)) & "%'"
		End If
		
		If cbState.SelectedIndex > 0 Then
			sCriteria = sCriteria & " AND state_id ='" & cbState.Text & "'"
		End If
		
		get_criteria = sCriteria
	End Function
	Private Sub frmStoreSearchCriteria_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	Private Sub init_vars()
		
        rsLocal = Nothing
		gDump.str1 = ""
		
        sStmt = "SELECT state_id FROM state ORDER BY state_id "
        cbState.Items.Clear()
		cbState.Items.Insert(0, "<All>")
        load_cb_query2(cbState, sStmt, 1, False)
		If cbState.Items.Count > 0 Then
			cbState.SelectedIndex = 0
		End If
		
	End Sub
End Class