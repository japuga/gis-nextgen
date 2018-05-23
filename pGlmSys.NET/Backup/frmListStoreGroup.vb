Option Strict Off
Option Explicit On
Friend Class frmListStoreGroup
	Inherits System.Windows.Forms.Form
    Dim rsLocal As DataTable
	Dim listId() As Short
	Public sCustId As String
	Public sRepCaption As String
	Public nPeriodSeq As Short
	Public nSelectedId As Short
	
	
	Private Sub init_vars()
		'lGroups.MultiSelect = vbMultiSelectSimple

		nSelectedId = 0
		load_groups(sCustId, sRepCaption, nPeriodSeq)
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		nSelectedId = 0
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If lGroups.SelectedItems.Count <= 0 Then
			MsgBox("Please select a Group from the list", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Warning")
		Else
			nSelectedId = VB6.GetItemData(lGroups, lGroups.SelectedIndex)
			Me.Close()
		End If
		
		
		
		
	End Sub
	
	Private Sub frmListStoreGroup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		init_vars()
	End Sub
	
	Private Sub load_groups(ByRef sCustId As String, ByRef sRepCaption As String, ByRef nPeriodSeq As Short)
		'sStmt = "SELECT id, param_value, param_seq"
		sStmt = "SELECT DISTINCT id " & "FROM rptCriteriaGlmInvoice " & " WHERE group_seq = 0 " & " AND cust_id='" & sCustId & "' " & " AND use_for_customer_billing = 'TRUE' " & " AND rep_no = (SELECT rep_no FROM repDef WHERE rep_caption ='" & sRepCaption & "')" & " AND period_seq = " & Str(nPeriodSeq)
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic)
		Dim idx As Short

        If rsLocal.Rows.Count > 0 Then
            ReDim listId(rsLocal.Rows.Count)

            idx = 0
            lGroups.Items.Clear()
            For row As Integer = 0 To rsLocal.Rows.Count - 1
                listId(idx) = rsLocal.Rows(row).Item("id").Value
                lGroups.Items.Add(getGroupList(rsLocal.Rows(row).Item("id").Value))
                VB6.SetItemData(lGroups, idx, rsLocal.Rows(row).Item("id").Value)
                idx = idx + 1
            Next row
            
        End If


		
		
	End Sub
	
	Private Function getGroupList(ByRef nId As Short) As String
		Dim list As String
		
		list = ""
		
		
		sStmt = "SELECT param_value, param_seq " & " FROM rptCriteriaDet " & " WHERE id = " & Str(nId) & " AND param_name='group_seq' " & " ORDER BY param_value"
		
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic)

        For row As Integer = 0 To rs.Rows.Count - 1
            list = list + rs.Rows(row).Item("param_value").Value
        Next row
        list = list & ", "

        getGroupList = list
		
	End Function
	
	'UPGRADE_WARNING: Event lGroups.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub lGroups_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lGroups.SelectedIndexChanged
		
		showMembers(VB6.GetItemData(lGroups, lGroups.SelectedIndex))
	End Sub
	
	Private Sub showMembers(ByRef nId As Short)
		
		sStmt = "SELECT param_value AS 'Group Name' FROM rptCriteriaDet " & " WHERE id = " & Str(nId)
		
		
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic)
        If rs.Rows.Count > 0 Then
            dgMembers.DataSource = rs
        Else
            'UPGRADE_NOTE: Object dgMembers.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            dgMembers.DataSource = Nothing
        End If
		
		dgMembers.Columns("Group Name").Width = VB6.TwipsToPixelsX(2000)
		
	End Sub
End Class