Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmUserPriv
	Inherits System.Windows.Forms.Form
    Private rsAssgState As DataTable
    Private rsState As DataTable
    Private ImageList2 As New ImageList()
	
    Private Sub cbCustId_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustId.SelectedIndexChanged

        cbCustName.SelectedIndex = cbCustId.SelectedIndex

        If cbUserName.SelectedIndex >= 0 And cbCustId.SelectedIndex >= 0 Then
            load_dgAssgState(cbUserName.Text, cbCustId.Text)
            load_dgState(cbUserName.Text, cbCustId.Text)
        Else
            'Inicializar datagrid
            load_dgAssgState("", "")
            load_dgState("", "")
        End If
    End Sub
	Private Sub load_dgAssgState(ByRef sUserName As String, ByRef sCustId As String)
		
		On Error GoTo ErrorHandler
		
		sStmt = "SELECT suser_data.state_id 'State', " & " state.state_name 'Name' " & " FROM suser_data, state " & " WHERE suser_data.suser_name = '" & Trim(sUserName) & "' " & " AND suser_data.cust_id ='" & Trim(sCustId) & "' " & " AND state.state_id = suser_data.state_id " & " ORDER BY suser_data.state_id "
		
        dgAssgState.DataSource = Nothing
		
		
        rsAssgState = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)

        dgAssgState.DataSource = rsAssgState

        'Formato
        dgAssgState.Columns("State").Width = VB6.TwipsToPixelsX(500)
        dgAssgState.Columns("Name").Width = VB6.TwipsToPixelsX(2000)
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "load_dgAssgState")
        MsgBox("Unexpected error when loading Assg State info." & vbCrLf & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
		
	End Sub
	Private Sub load_dgState(ByRef sUserName As String, ByRef sCustId As String)
		
		On Error GoTo ErrorHandler
		
		'State
		sStmt = "SELECT state_id 'State', state_name 'Name'" & " FROM state " & " WHERE state_id NOT IN " & " ( SELECT state_id FROM suser_data " & " WHERE suser_data.suser_name = '" & Trim(sUserName) & "' " & " AND suser_data.cust_id ='" & Trim(sCustId) & "' )" & " ORDER BY state_id "

		dgState.DataSource = Nothing
		
        rsState = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)

        dgState.DataSource = rsState

        'Formato
        dgState.Columns("State").Width = VB6.TwipsToPixelsX(500)
        dgState.Columns("Name").Width = VB6.TwipsToPixelsX(2000)
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "load_dgState")
        MsgBox("Unexpected error when loading State info." & vbCrLf & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
		
	End Sub
	
	
    Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
        If cbUserName.SelectedIndex >= 0 And cbCustId.SelectedIndex >= 0 Then
            load_dgAssgState(cbUserName.Text, cbCustId.Text)
            load_dgState(cbUserName.Text, cbCustId.Text)
        Else
            'Inicializar datagrid
            load_dgAssgState("", "")
            load_dgState("", "")
        End If

    End Sub
	
    Private Sub cbUserName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbUserName.SelectedIndexChanged
        cbUserDesc.SelectedIndex = cbUserName.SelectedIndex

        If cbUserName.SelectedIndex >= 0 And cbCustId.SelectedIndex >= 0 Then
            load_dgAssgState(cbUserName.Text, cbCustId.Text)
            load_dgState(cbUserName.Text, cbCustId.Text)
        Else
            'Inicializar datagrid
            load_dgAssgState("", "")
            load_dgState("", "")
        End If

    End Sub
	
	Private Sub cmdAddMember_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAddMember.Click
		
		add_member()
	End Sub
	'Agrega estados a dgAssgState desde dgState
	Private Sub add_member()
        Dim vRow As DataGridViewRow
		
		On Error GoTo ErrorHandler

        If dgState.SelectedRows.Count < 1 Then
            If dgState.SelectedCells.Count > 0 Then
                dgState.Rows(dgState.SelectedCells(0).RowIndex).Selected = True
            End If
        End If
        For Each vRow In dgState.SelectedRows
            'rsState.Bookmark = vRow 'Muevo el recordset a la fila seleccionada
            'Verifico si tienda ya existe en recordset

            If record_exist(rsAssgState, rsState.Rows(vRow.Index).Item("state")) = False Then
                'Dim drow As DataRow = rsAssgState.NewRow()

                Dim stateName As String = dgState.SelectedRows(0).Cells("state").Value
                Dim aDataRow() As DataRow = rsState.Select("state like '" + stateName + "'")
                rsAssgState.ImportRow(aDataRow(0))
                stateName = aDataRow(0).Item("state")


                'rsAssgState.Item("state") = rsState.Item("state")
                'drow.Item("state") = rsState.Rows(vRow.Index).Item("state")

                'rsAssgState.Item("name") = rsState.Item("name")
                'drow.Item("name") = rsState.Rows(vRow.Index).Item("name")

                'rsAssgState.Rows.Add(drow)
                dgAssgState.Sort(dgAssgState.Columns("state"), System.ComponentModel.ListSortDirection.Ascending)
                dgAssgState.Refresh()
                'rsAssgState.Select("state")
                rsState.Rows.Remove(aDataRow(0))
                dgState.Refresh()
            End If
            
        Next vRow
		Exit Sub
		
ErrorHandler: 
		If Err.Number = 3021 Then
			MsgBox("Error found.")
		End If
        save_error(Me.Name, "add_member")
		MsgBox("Unexpected error found. Check log for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
	End Sub
	'Busca una estado en Datagrid
    Private Function record_exist(ByRef rsTmp As DataTable, ByRef sStateId As String) As Boolean
        Dim sCriteria As String
        Dim tmpDr() As DataRow
        sCriteria = "state='" & Trim(sStateId) & "'"
        Dim a As Integer = rsTmp.Select(sCriteria).Length
        tmpDr = rsTmp.Select(sCriteria)
        If tmpDr.Length < 1 Then
            record_exist = False
            Exit Function
        End If

        'no se como hacer "find"
        'rsTmp.Find(sCriteria, , ADODB.SearchDirectionEnum.adSearchForward)

        If rsTmp.Rows.Count > 0 Then
            record_exist = False
            Exit Function
        End If
        record_exist = True

    End Function
	
	Private Sub cmdRemoveMember_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRemoveMember.Click
		del_member()
	End Sub
	'Agrega estados a dgAssgState desde dgState
	Private Sub del_member()
        Dim vRow As DataGridViewRow
        If dgAssgState.SelectedRows.Count < 1 Then
            If dgAssgState.SelectedCells.Count > 0 Then
                dgAssgState.CurrentRow.Selected = True
            End If
        End If
        For Each vRow In dgAssgState.SelectedRows
            'rsAssgState.Bookmark = vRow 'Muevo el recordset a la fila seleccionada
            'Verifico si tienda ya existe en recordset

            If record_exist(rsState, rsAssgState.Rows(vRow.Index).Item("state")) = False Then

                Dim assgStateName As String = dgAssgState.SelectedRows(0).Cells("state").Value
                Dim aDataRow() As DataRow = rsAssgState.Select("state like '" + assgStateName + "'")
                rsState.ImportRow(aDataRow(0))
                assgStateName = aDataRow(0).Item("state")

                'assgStateName = rsAssgState.Rows(vRow.Index).Item("state")
                'assgStateName = rsAssgState.Rows(0).Item("state")
                'assgStateName = rsAssgState.Rows(1).Item("state")
                'assgStateName = rsAssgState.Rows(2).Item("state")
                'assgStateName = rsAssgState.Rows(3).Item("state")

                'rsState.ImportRow(rsAssgState.Rows(vRow.Index))

                'Dim drow As DataRow = rsState.NewRow()
                'rsState.NewRow()
                'drow = rsState.NewRow()
                'rsState.AddNew()
                'rsState.Item("state") = rsAssgState.Item("state")
                'drow("state") = rsAssgState.Rows(vRow.Index).Item("state")
                'rsState.Item("name") = rsAssgState.Item("name")
                'drow("name") = rsAssgState.Rows(vRow.Index).Item("name")
                'rsState.Rows.Add(drow)
                'dgState.DataSource = Nothing
                dgState.Refresh()
                'dgState.DataSource = rsState

                dgState.Sort(dgState.Columns("state"), System.ComponentModel.ListSortDirection.Ascending)
                rsAssgState.Rows.Remove(aDataRow(0)) '.Delete(ADODB.AffectEnum.adAffectCurrent)
                dgAssgState.Refresh()
            End If

        Next vRow

        'dgAssgState.DataSource = rsAssgState
        dgAssgState.Refresh()
        dgState.Refresh()

	End Sub
	
	
    Private Sub dgAssgState_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        del_member()
    End Sub
	
    Private Sub dgState_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        add_member()
    End Sub
	
	Private Sub frmUserPriv_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		
        rsAssgState = Nothing
        rsState = Nothing
		
		'Limites
		'rsState.MaxRecords = MAX_RECORDS
        On Error GoTo ErrorHandler
		
		'User
		sStmt = "SELECT suser_name, suser_desc " & " FROM suser ORDER BY suser_name"
		load_cb_query2(cbUserName, sStmt, 1, True)
		
		sStmt = "SELECT suser_desc, suser_name " & " FROM suser ORDER BY suser_name "
		load_cb_query2(cbUserDesc, sStmt, 1, True)
		
		If cbUserName.Items.Count > 0 Then
            cbUserName.SelectedIndex = 0
		End If
		
		'Customer
		sStmt = "SELECT cust_id, cust_name " & "FROM customer  ORDER BY cust_id"
		load_cb_query2(cbCustId, sStmt, 1, True)
		
		sStmt = "SELECT cust_name, cust_id " & "FROM customer  ORDER BY cust_id"
		load_cb_query2(cbCustName, sStmt, 1, True)
		
		If cbCustId.Items.Count > 0 Then
			cbCustId.SelectedIndex = 0
		End If
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "init_vars")
		MsgBox("Unexpected when loading defaults." & vbCrLf & "Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
		
		
	End Sub
	
	'UPGRADE_WARNING: Event frmUserPriv.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmUserPriv_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		Me.Width = VB6.TwipsToPixelsX(9165)
		Me.Height = VB6.TwipsToPixelsY(5850)
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button2.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "save"
                save_user_data()
            Case "exit"
                Me.Close()
        End Select
    End Sub
	'Guarda datos en la base
	Private Sub save_user_data()
        Dim nTran As SqlTransaction
		Dim nDataSeq As Short
		Dim sTypeId As String
		Dim nRecords As Short
		
		On Error GoTo ErrorHandler
		
		nDataSeq = 0
		'Tipo de usuario
		sTypeId = "C"
		
		If cbUserName.SelectedIndex < 0 Or cbCustId.SelectedIndex < 0 Then
			'Nada que actualizar
			MsgBox("You must select a User and Customer before attempting this command.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
			
			Exit Sub
		End If
		
        cm = cn.CreateCommand() '.let_ActiveConnection()
        cm.CommandType = CommandType.Text
		
        nTran = cn.BeginTransaction()
		sStmt = "DELETE FROM suser_data " & " WHERE suser_name ='" & Trim(cbUserName.Text) & "'" & " AND cust_id ='" & Trim(cbCustId.Text) & "'"
        cm.CommandText = sStmt
        cm.Transaction = nTran
        nRecords = cm.ExecuteNonQuery()
		'Insertar nuevos registros

        If rsAssgState.Rows.Count > 0 Then
            'Numero de secuencia

            sStmt = "SELECT ISNULL(MAX(data_seq),0) " & " FROM suser_data " & " WHERE cust_id='" & Trim(cbCustId.Text) & "' " & " AND suser_name='" & Trim(cbUserName.Text) & "' "
            
            rs = getDataTable(sStmt, nTran) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rs.Rows.Count > 0 Then
                'MsgBox Str(rs.item(0))
                nDataSeq = rs.Rows(0).Item(0) + 1
            Else
                nDataSeq = 1
            End If


            'nDataSeq = nDataSeq + 1

            For row As Integer = 0 To rsAssgState.Rows.Count - 1
                'sStmt = "INSERT INTO suser_data (type_id, " + _
                '"suser_name, data_seq, state_id, cust_id) " + _
                '" VALUES (" + _
                '"'" + sTypeId + "','" + Trim(cbUserName) + "'," + _
                'Str(nDataSeq) + "," + _
                '"'" + Trim(rsAssgState.item("state")) + "'," + _
                '"'" + Trim(cbCustId) + "')"
                sStmt = "INSERT INTO suser_data (" & "suser_name, data_seq, state_id, cust_id) " & " VALUES (" & "'" & Trim(cbUserName.Text) & "'," & Str(nDataSeq) & "," & "'" & Trim(rsAssgState.Rows(row).Item("state")) & "'," & "'" & Trim(cbCustId.Text) & "')"
                cm.CommandText = sStmt
                cm.Transaction = nTran
                nRecords = cm.ExecuteNonQuery()
                If nRecords > 0 Then
                    'ok
                Else
                    nTran.Rollback()
                    MsgBox("Failed to update user privileges.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                    Exit Sub
                End If

            Next row


            

        End If

        nTran.Commit()

        'cerrar y carga combo
        'rsAssgState.CancelBatch adAffectGroup
        MsgBox("User Privileges were successfully assigned.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
        Exit Sub

ErrorHandler:

        nTran.Rollback()

        save_error(Me.Name, "save_user_data")
        MsgBox("Unexpected error when saving user privileges info." & vbCrLf & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
	End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        save_user_data()
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub dgState_DblClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgState.CellDoubleClick
        add_member()
    End Sub


    Private Sub dgAssgState_DblClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAssgState.CellContentDoubleClick
        del_member()
    End Sub


    Private Sub dgAssgState_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAssgState.CellDoubleClick
        del_member()
    End Sub

    
End Class