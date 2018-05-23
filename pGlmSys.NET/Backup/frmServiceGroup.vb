Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmServiceGroup
	Inherits System.Windows.Forms.Form
    Private cmLocal As SqlCommand
    Private rsLocal As DataTable
    Private ImageList2 As New ImageList()
	
	Private Sub dgGroups_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dgGroups.ClickEvent
		update_group()
	End Sub
	Private Sub update_group()
		If dgGroups.SelBookmarks.Count > 0 Then
			gServiceGroupRecord.bFlag = General.modo.UpdateRecord
			gServiceGroupRecord.nServGroupId = CShort(dgGroups.Columns("serv_group_id").Text)
			gServiceGroupRecord.sServGroupName = dgGroups.Columns("Name").Text
			gServiceGroupRecord.sServGroupDesc = dgGroups.Columns("Description").Text
			gServiceGroupRecord.sSystemGenerated = dgGroups.Columns("System").Text
			VB6.ShowForm(frmServiceGroupEntry, VB6.FormShowConstants.Modal, Me)
		Else
			MsgBox("You must select a group to Update ," & vbCrLf & " before attempting this comand", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
			Exit Sub
		End If
		
	End Sub
	
	Private Sub frmServiceGroup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
        rsLocal = Nothing
        cmLocal.CommandType = CommandType.Text
        cmLocal = cn.CreateCommand
		
		load_dgGroups()
		
	End Sub
	
	'Loads datagrid with available Groups
	Private Sub load_dgGroups()

		sStmt = "SELECT serv_group_id, serv_group_name AS Name, " & " serv_group_desc AS Description, system_generated System " & " FROM serviceGroup " & " ORDER BY serv_group_name"

        Try
            rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rsLocal.Rows.Count > 0 Then
                dgGroups.DataSource = rsLocal
                'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
                dgGroups.Refresh()
                If rsLocal.Rows.Count > 0 Then
                    '
                End If
            Else
                'UPGRADE_NOTE: Object dgGroups.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                dgGroups.DataSource = Nothing
                Exit Sub
            End If
        Catch ex As Exception
            save_error(Me.Name, "load_dgGroups")
            MsgBox("Error during Groups loading. Check logfile for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
        End Try
        'Formatting datagrid
        dgGroups.Columns("serv_group_id").Visible = False
        dgGroups.Columns("Name").Width = VB6.TwipsToPixelsX(3000)
        dgGroups.Columns("Description").Width = VB6.TwipsToPixelsX(3000)
        dgGroups.Columns("System").Width = VB6.TwipsToPixelsX(100)
        Exit Sub
		
	End Sub
	
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "new"
                add_group()
            Case "save"
                update_group()
            Case "delete"
                delete_group()
            Case "exit"
                Me.Close()
        End Select

    End Sub
	
	
	
	Private Sub add_group()
		gServiceGroupRecord.bFlag = General.modo.NewRecord
		
		VB6.ShowForm(frmServiceGroupEntry, VB6.FormShowConstants.Modal, Me)
		
		If gServiceGroupRecord.bFlag = General.modo.SavedRecord Then
			load_dgGroups()
		End If
		
	End Sub
	
	
	
	Private Sub delete_group()
		
	End Sub
End Class