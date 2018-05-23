Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmInvoicingGroups
	Inherits System.Windows.Forms.Form
    Private cmLocal As sqlcommand
    Private rsLocal As DataTable
    Private ImageList2 As New ImageList()
	
    Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
        cbCustId.SelectedIndex = cbCustName.SelectedIndex
        load_dgGroups(cbCustId.Text)
    End Sub
	
    Private Sub dgGroups_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        update_group()
    End Sub
	Private Sub update_group()
        If dgGroups.SelectedRows.Count > 0 Then

            gInvoicingGroup.bModo = General.modo.UpdateRecord
            gInvoicingGroup.sGroupName = dgGroups.CurrentRow.Cells("name").Value
            gInvoicingGroup.nGroupSeq = CShort(dgGroups.CurrentRow.Cells("group_seq").Value)
            gInvoicingGroup.sCustId = cbCustId.Text
            gInvoicingGroup.sGroupStatus = dgGroups.CurrentRow.Cells("status").Value

            VB6.ShowForm(frmInvoicingGroupsEntry, VB6.FormShowConstants.Modal, Me)

            If gInvoicingGroup.bModo = General.modo.SavedRecord Then
                load_dgGroups(cbCustId.Text)
            End If
        Else
            MsgBox("You must select a group to Update ," & vbCrLf & " before attempting this comand", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
            Exit Sub
        End If
		
	End Sub
	Private Sub frmInvoicingGroups_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
        rsLocal = Nothing
        cmLocal = cn.CreateCommand
		
        cmLocal.CommandType = CommandType.Text

		sStmt = "SELECT cust_name, cust_id FROM customer " & " WHERE cust_id IN (SELECT DISTINCT cust_id " & "   FROM suser_data " & "   WHERE suser_name='" & Trim(gsUser) & "')" & " ORDER BY cust_name "
		load_cb_query2(cbCustName, sStmt, 1, True)
		
		sStmt = "SELECT cust_id, cust_name FROM customer " & " WHERE cust_id IN (SELECT DISTINCT cust_id " & "   FROM suser_data " & "   WHERE suser_name='" & Trim(gsUser) & "')" & " ORDER BY cust_name "
		load_cb_query2(cbCustId, sStmt, 1, True)
		
		If cbCustName.Items.Count > 0 Then
			cbCustName.SelectedIndex = 0
		End If
		
		If cbCustId.Items.Count > 0 Then
			cbCustId.SelectedIndex = 0
			load_dgGroups(cbCustId.Text)
		End If
		
	End Sub
	'Carga Datagrid con Grupos disponibles
	Private Sub load_dgGroups(ByRef sCustId As String)
		
		'On Error GoTo ErrorHandler
		sStmt = "SELECT group_seq, group_name AS Name, cust_id, group_status Status" & " FROM VInvoiceGroup " & " WHERE cust_id = '" & Trim(sCustId) & "'" & " ORDER BY group_name"
        Try
            rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            dgGroups.DataSource = rsLocal

            If rsLocal.Rows.Count > 0 Then
            End If
        Catch ex As Exception
            dgGroups.DataSource = Nothing
            Exit Sub
        End Try

        dgGroups.Refresh()

        'Formato del datagrid
        dgGroups.Columns("cust_id").Visible = False
        dgGroups.Columns("group_seq").Visible = False
        dgGroups.Columns("Name").Width = VB6.TwipsToPixelsX(3000)
        Exit Sub
ErrorHandler:
        save_error(Me.Name, "load_dgGroups")
		MsgBox("Error during Groups loading. Check logfile for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
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
		
		gInvoicingGroup.bModo = General.modo.NewRecord
		gInvoicingGroup.sCustId = cbCustId.Text
		
		VB6.ShowForm(frmInvoicingGroupsEntry, VB6.FormShowConstants.Modal, Me)
		
		If gInvoicingGroup.bModo = General.modo.SavedRecord Then
			load_dgGroups(cbCustId.Text)
		End If
		
	End Sub
	
	Private Sub delete_group()
		Dim nRecords As Short
        Dim nTran As SqlTransaction
		
		On Error GoTo ErrorHandler
		
        If dgGroups.SelectedRows.Count > 0 Then
            If MsgBox("Do you want to delete Group: " & dgGroups.CurrentRow.Cells("Name").Value, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "GLM Warning") = MsgBoxResult.Yes Then
                nTran = cn.BeginTransaction()
                General.bcnStatus = General.cnStatus.BeginTrans
                sStmt = "DELETE FROM VInvoiceGroup" & " WHERE cust_id ='" & cbCustId.Text & "'" & " AND group_seq = " & Str(CDbl(dgGroups.CurrentRow.Cells("group_seq").Value))
                'MsgBox sStmt
                cmLocal.CommandText = sStmt
                cmLocal.Transaction = nTran
                nRecords = cmLocal.ExecuteNonQuery()

                If nRecords > 0 Then
                    nTran.Commit()
                    General.bcnStatus = General.cnStatus.NoTrans
                    MsgBox("Data was sucessfully deleted.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                    load_dgGroups(cbCustId.Text)
                Else
                    nTran.Rollback()
                    General.bcnStatus = General.cnStatus.NoTrans
                End If
            End If
        Else
            MsgBox("You must select a record to execute this command.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
            Exit Sub
        End If
		
		'load_dgGroups cbCustId
		Exit Sub
		
ErrorHandler: 
		If General.bcnStatus = General.cnStatus.BeginTrans Then
            nTran.Rollback()
			General.bcnStatus = General.cnStatus.NoTrans
		End If
		save_error(Me.Name, "delete_group")
		MsgBox("Unexpected error while deleting groups table." & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        add_group()
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        update_group()
    End Sub

    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        delete_group()
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub
End Class