Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmGrpDefBrowse
	Inherits System.Windows.Forms.Form
    Dim rsLocal As SqlDataReader
    Dim cmLocal As SqlCommand
    Private ImageList2 As New ImageList()
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		cbCustId.SelectedIndex = cbCustName.SelectedIndex
		load_dgGrpDef(cbCustId.Text, cbTypeId.Text)
	End Sub
	
	'UPGRADE_WARNING: Event cbTypeId.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbTypeId_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbTypeId.SelectedIndexChanged
		load_dgGrpDef(cbCustId.Text, cbTypeId.Text)
		
	End Sub
	
	Private Sub frmGrpDefBrowse_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	Private Sub init_vars()
        cmLocal = cn.CreateCommand()

        cbCustId.Visible = False

        'Combo Type
        cbTypeId.Items.Insert(0, "All")

        sStmt = "SELECT type_id FROM GrpType " & "ORDER BY sort_id "
        load_cb_query2(cbTypeId, sStmt, 1, False)

        cbTypeId.SelectedIndex = 0

        'Combo Customer
        sStmt = "SELECT cust_name, cust_id FROM customer " & " WHERE cust_id IN (SELECT DISTINCT cust_id " & "   FROM suser_data " & "   WHERE suser_name='" & Trim(gsUser) & "')" & " ORDER BY cust_name "
        load_cb_query2(cbCustName, sStmt, 1, True)

        sStmt = "SELECT cust_id, cust_name FROM customer " & " WHERE cust_id IN (SELECT DISTINCT cust_id " & "   FROM suser_data " & "   WHERE suser_name='" & Trim(gsUser) & "')" & " ORDER BY cust_name "
        load_cb_query2(cbCustId, sStmt, 1, True)

        If cbCustName.Items.Count > 0 Then
            cbCustName.SelectedIndex = 0
        End If

        If cbCustId.Items.Count > 0 Then
            cbCustId.SelectedIndex = 0
            load_dgGrpDef(cbCustId.Text, cbTypeId.Text)
        End If


    End Sub
	Private Sub load_dgGrpDef(ByRef sCustId As String, ByRef sTypeId As String)
        Dim sWhere As String = ""
        Dim cmd As SqlCommand = cn.CreateCommand()
        'On Error GoTo ErrorHandler
		
		sStmt = "SELECT grpdef_id 'Name', type_id 'Type' " & " FROM GrpDef " & " WHERE cust_id = '" & Trim(sCustId) & "'"
		
		If sTypeId = "All" Then
			'No condition required
		Else
			sWhere = " AND type_id = '" & cbTypeId.Text & "' "
		End If
		
        sStmt = sStmt & sWhere & " ORDER BY type_id, grpdef_id "
        cmd.CommandText = sStmt

        Try
            rsLocal = cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            dgGrpDef.DataSource = rsLocal
            'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            dgGrpDef.Refresh()
            If rsLocal.HasRows() Then

            End If

        Catch e As Exception
            'UPGRADE_NOTE: Object dgGrpDef.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            dgGrpDef.DataSource = Nothing
            Exit Sub
        End Try



        'Formatting datagrid
        dgGrpDef.Columns("Name").Width = VB6.TwipsToPixelsX(3000)
        Exit Sub
ErrorHandler:
        save_error(Me.Name, "load_dgGrpDef")
        MsgBox("Error during Groups loading. Check logfile for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
    End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "new"
                If set_grpdef_info((General.modo.NewRecord)) Then
                    VB6.ShowForm(frmGrpDefEntry, VB6.FormShowConstants.Modal, Me)
                    If gGrpdef.bModo = General.modo.SavedRecord Then
                        load_dgGrpDef(cbCustId.Text, cbTypeId.Text)
                    End If
                End If

            Case "save"
                If set_grpdef_info((General.modo.UpdateRecord)) Then
                    VB6.ShowForm(frmGrpDefEntry, VB6.FormShowConstants.Modal, Me)
                    If gGrpdef.bModo = General.modo.SavedRecord Then
                        load_dgGrpDef(cbCustId.Text, cbTypeId.Text)
                    End If
                End If

            Case "delete"
                If dgGrpDef.Row >= 0 Then
                    If MsgBox("Do you want to delete the selected record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "GLM Message") = MsgBoxResult.Yes Then
                        delete_record(gGrpdef)
                    End If
                End If
                load_dgGrpDef(cbCustId.Text, cbTypeId.Text)
            Case "exit"
                Me.Close()
        End Select


    End Sub
	
	Private Function set_grpdef_info(ByRef nOption As General.modo) As Boolean
		
		set_grpdef_info = False
		
		gGrpdef.bModo = nOption
		gGrpdef.sCustId = cbCustId.Text
		gGrpdef.sCustName = cbCustName.Text
		
		Select Case nOption
			Case General.modo.NewRecord
				set_grpdef_info = True
			Case General.modo.UpdateRecord
				If dgGrpDef.SelBookmarks.Count = 0 Then
					MsgBox("Please select a record before attempting this action.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Warning")
					Exit Function
				Else
					gGrpdef.sGrpDefId = dgGrpDef.Columns("Name").Text
					gGrpdef.sTypeId = dgGrpDef.Columns("Type").Text
					set_grpdef_info = True
				End If
		End Select
		
	End Function
	Private Sub delete_record(ByRef lgrpdef As gGrpDefUDT)
		Dim nRecords As Short
        Dim cmd As SqlCommand = cn.CreateCommand()
		sStmt = "DELETE FROM GrpDef " & " WHERE grpdef_id = '" & quotation_mask(lgrpdef.sGrpDefId) & "' " & " AND cust_id = '" & lgrpdef.sCustId & "' " & " AND type_id = " & lgrpdef.sTypeId & "'"
        cmd.CommandText = sStmt

        nRecords = cm.ExecuteNonQuery()
		If nRecords > 0 Then
			'ok
		Else
			MsgBox("Failed to remove Group Access")
		End If
	End Sub
End Class