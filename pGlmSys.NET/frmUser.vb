Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmUser
    Inherits System.Windows.Forms.Form
    Private rsUser As DataTable
    Private ImageList2 As New ImageList()
	
    Private Sub dgUser_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        update_user()
    End Sub
	
	Private Sub frmUser_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		
	End Sub
	
	
	Private Sub init_vars()

        init_user_record()
        load_dgUser()
    End Sub
	Private Sub init_user_record()
		gUserRecord.sUserDesc = ""
		gUserRecord.sUserName = ""
	End Sub
	Private Sub load_dgUser()
		Dim bFound As Boolean
        Dim dt As DataTable
		On Error GoTo ErrorHandler
		'Si un usuario tiene type_id nulo, se le asigna AccountManager por defecto
		sStmt = "SELECT suser_name 'ID', suser_desc 'Description', " & " ISNULL(suser_type.type_name,'')  'Type', " & " ISNULL(suser.type_id,'C')  type_id " & " FROM suser LEFT OUTER JOIN suser_type " & " ON suser.type_id = suser_type.type_id " & " ORDER BY suser_name "
		
        dgUser.DataSource = Nothing
		
		
        rsUser = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		
		bFound = False

        If rsUser.Rows.Count > 0 Then


            For row As Integer = 0 To rsUser.Rows.Count - 1
                If Trim(rsUser.Rows(row).Item("ID")) = Trim(gUserRecord.sUserName) Then
                    bFound = True
                    Exit For
                End If
            Next row
        End If



        dgUser.DataSource = rsUser
        If rsUser.Rows.Count > 0 Then
            If bFound = False Then
                'rsUser.MoveFirst()
            End If
            'dgUser.SelBookmarks.Add((rsUser.Bookmark))
        End If



        'Formato
        dgUser.Columns("ID").Width = VB6.TwipsToPixelsX(1200)
        dgUser.Columns("Description").Width = VB6.TwipsToPixelsX(2800)
        dgUser.Columns("Type").Width = VB6.TwipsToPixelsX(1200)

        dgUser.Columns("type_id").Visible = False
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "load_dgUser")
        MsgBox("Failed to load User data grid." & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
		
	End Sub
	
	Private Sub frmUser_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_NOTE: Object rsUser may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rsUser = Nothing
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "new"
                add_user()
            Case "save"
                update_user()
            Case "delete"
                delete_user()
            Case "exit"
                Me.Close()
        End Select

    End Sub
	
	Private Sub add_user()
		gUserRecord.bFlag = General.modo.NewRecord
		VB6.ShowForm(frmUserEntry, VB6.FormShowConstants.Modal, Me)
		If gUserRecord.bFlag = General.modo.SavedRecord Then
			load_dgUser()
		End If
	End Sub
    Private Sub update_user()

        If dgUser.SelectedRows.Count < 1 Then
            If dgUser.SelectedCells.Count > 0 Then
                dgUser.Rows(dgUser.SelectedCells(0).RowIndex).Selected = True
            End If
        End If
        If dgUser.SelectedRows.Count > 0 Then
            gUserRecord.bFlag = General.modo.UpdateRecord
            set_user()

            VB6.ShowForm(frmUserEntry, VB6.FormShowConstants.Modal, Me)
            If gUserRecord.bFlag = General.modo.SavedRecord Then
                load_dgUser()
            End If
        Else
            MsgBox("You must select a user before attempting this command.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
        End If
    End Sub
    Private Sub set_user()
        If dgUser.SelectedRows.Count <= 0 Then
            For Each aCell As DataGridViewCell In dgUser.SelectedCells
                dgUser.Rows(aCell.RowIndex).Selected = True
            Next
        End If
        If IsDBNull(rsUser.Rows(dgUser.SelectedRows(0).Index).Item("ID")) Then
            gUserRecord.sUserName = ""
        Else
            gUserRecord.sUserName = Trim(rsUser.Rows(dgUser.SelectedRows(0).Index).Item("ID"))
        End If

        If IsDBNull(rsUser.Rows(dgUser.SelectedRows(0).Index).Item("Description")) Then
            gUserRecord.sUserDesc = ""
        Else
            gUserRecord.sUserDesc = Trim(rsUser.Rows(dgUser.SelectedRows(0).Index).Item("Description"))
        End If

        If IsDBNull(rsUser.Rows(dgUser.SelectedRows(0).Index).Item("type_id")) Then
            gUserRecord.sTypeId = ""
        Else
            gUserRecord.sTypeId = Trim(rsUser.Rows(dgUser.SelectedRows(0).Index).Item("type_id"))
        End If


    End Sub
	Private Sub delete_user()
		Dim nRecords As Short
        Dim nTran As SqlTransaction = Nothing
		
		On Error GoTo ErrorHandler
		

        cm = cn.CreateCommand() '.let_ActiveConnection(cn)
        cm.CommandType = CommandType.Text
		
        If dgUser.SelectedRows.Count > 0 Then
            If MsgBox("Do you want to delete this record.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "GLM Warning") = MsgBoxResult.Yes Then
                nTran = cn.BeginTransaction()
                'Primero se eliminan privilegios en suser_data
                sStmt = "SELECT suser_name FROM suser_data " & " WHERE suser_name ='" & Trim(rsUser.Rows(dgUser.SelectedRows(0).Index).Item("ID")) & "'"

                rs = getDataTable(sStmt, nTran) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                If rs.Rows.Count > 0 Then
                    sStmt = "DELETE FROM suser_data " & " WHERE suser_name ='" & Trim(rsUser.Rows(dgUser.SelectedRows(0).Index).Item("ID")) & "'"

                    cm.CommandText = sStmt
                    cm.Transaction = nTran
                    nRecords = cm.ExecuteNonQuery()
                    If nRecords > 0 Then
                        'ok elminado suser_data
                    Else
                        nTran.Rollback()
                        MsgBox("Failed to delete User Data.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
                        Exit Sub
                    End If
                End If 'RecordCOunt


                'suser_options
                sStmt = "SELECT suser_name FROM suser_options " & " WHERE suser_name ='" & Trim(rsUser.Rows(dgUser.SelectedRows(0).Index).Item("ID")) & "'"


                rs = getDataTable(sStmt, nTran) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                If rs.Rows.Count > 0 Then
                    sStmt = "DELETE FROM suser_options " & " WHERE suser_name ='" & Trim(rsUser.Rows(dgUser.SelectedRows(0).Index).Item("ID")) & "'"
                    cm.CommandText = sStmt
                    cm.Transaction = nTran
                    nRecords = cm.ExecuteNonQuery()

                    If nRecords > 0 Then
                        'ok elminado suser_options
                    Else
                        nTran.Rollback()
                        MsgBox("Failed to delete User Options.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
                        Exit Sub
                    End If
                End If


                'suser
                sStmt = "DELETE FROM suser " & " WHERE suser_name ='" & Trim(rsUser.Rows(dgUser.SelectedRows(0).Index).Item("ID")) & "'"

                cm.CommandText = sStmt
                cm.Transaction = nTran
                nRecords = cm.ExecuteNonQuery()
                If nRecords > 0 Then
                    'ok
                    nTran.Commit()

                    'MsgBox "User was deleted.", vbOKOnly + vbInformation, "GLM Message"
                Else
                    'rollback
                    nTran.Rollback()
                    MsgBox("Failed to delete User record.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
                    Exit Sub
                End If

                del_sql_user()

                load_dgUser()
            End If 'Do you want to delete?
        End If
        Exit Sub

ErrorHandler:

        If Not IsNothing(nTran) Then
            nTran.Rollback()
        End If

        save_error(Me.Name, "delete_user")
        If Not show_db_error() Then
            MsgBox("Unexpected error occurred while deleting User info." & vbCrLf & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
        End If
    End Sub
	'Borrar usuario de SqlServer
	Private Sub del_sql_user()
        Dim rsTmp As DataTable
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim ds As DataSet = New DataSet("tmpds")

        Try

            'Verifico que el usuario exista en SqlServer
            cm.CommandType = CommandType.StoredProcedure
            cm.CommandText = "usp_sys_user_info"
            cm.Parameters.AddWithValue("@sUserName", Trim(rsUser.Rows(dgUser.SelectedRows(0).Index).Item("ID")))
            da.SelectCommand = cm
            da.Fill(ds)
            rsTmp = ds.Tables(0)

            cm = cn.CreateCommand
            cm.CommandType = CommandType.StoredProcedure
            cm.CommandText = "usp_sys_delete_user"
            cm.Parameters.AddWithValue("@sUserName", Trim(rsUser.Rows(dgUser.SelectedRows(0).Index).Item("ID")))
            cm.Parameters.Add("@nResult", SqlDbType.Int)
            cm.Parameters("@nResult").Direction = ParameterDirection.Output
            cm.ExecuteNonQuery()
            If cm.Parameters("@nResult").Value = 0 Then
                'ok
                'gUserRecord.bFlag = modo.SavedRecord

            Else
                MsgBox("Failed to remove SqlServer login." & vbCrLf & "You have to remove it manually.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            End If
            Exit Sub

        Catch e As Exception
            'If cn.Errors(0).NativeError = 15198 Then
            'User does not exist on SqlServer
            'End If
        End Try
    End Sub

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        add_user()
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        update_user()
    End Sub

    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        delete_user()
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub dgUser_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgUser.CellDoubleClick
        update_user()
    End Sub
End Class