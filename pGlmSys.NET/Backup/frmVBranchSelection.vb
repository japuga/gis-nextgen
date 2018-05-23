Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmVBranchSelection
	Inherits System.Windows.Forms.Form
    Private rsVBranch As DataTable
    Private rsSelVBranch As DataTable
	Private sVendSeq As String
	
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		
		Me.Close()
	End Sub
	
	Private Sub cmdLeft_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLeft.Click
		del_member()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
        'Dim vRow As Object
        Dim sVendSeq As String = ""
        'Dim i As Short
		
        'rsSelVBranch.Resync(ADODB.AffectEnum.adAffectAllChapters)
        If rsSelVBranch.Rows.Count > 0 Then
            For row As Integer = 0 To rsSelVBranch.Rows.Count - 1
                If Len(sVendSeq) = 0 Then
                    sVendSeq = Str(rsSelVBranch.Rows(row).Item("vend_seq"))
                Else
                    sVendSeq = sVendSeq & "," & Str(rsSelVBranch.Rows(row).Item("vend_seq"))
                End If
            Next row
            
        End If
		
		gVendor.sVendSeq = sVendSeq
		
		Me.Close()
	End Sub
	
	Private Sub cmdRight_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRight.Click
		add_member()
	End Sub
	
    Private Sub dgSelVBranch_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        del_member()
    End Sub
	
    Private Sub dgVBranch_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        add_member()
    End Sub
	
	Private Sub frmVBranchSelection_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
        rsVBranch = Nothing
        rsSelVBranch = Nothing
		
        'investigar locktype
        'rsVBranch.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
		

        'rsSelVBranch.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
		
		gVendor.sVendSeq = ""
		
		txtVendName.Enabled = False
		txtVendName.ReadOnly = True
		txtVendName.Text = gVendor.sVendName
		
		load_dgVBranch(gVendor.nVendId)
		load_dgSelVBranch(0)
		
	End Sub
	
	Private Sub load_dgVBranch(ByRef nVendId As Short)
		
		On Error GoTo ErrorHandler
		'UPGRADE_NOTE: Object dgVBranch.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		dgVBranch.DataSource = Nothing
		
		sStmt = "SELECT vend_seq, vend_name, " & " state_id 'State', vend_area 'Area' " & " FROM  VBranch " & " WHERE vend_id= " & Str(nVendId) & " ORDER BY  state_id, vend_name"
		
        rsVBranch = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic)
        If rsVBranch.Rows.Count > 0 Then
            dgVBranch.DataSource = rsVBranch
        End If
		
		dgVBranch.Columns("vend_seq").Visible = False
		dgVBranch.Columns("vend_name").Visible = False
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_dgVBranch")
		MsgBox("Unexpected error when loading Vendor Branch info." & vbCrLf & "Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
		
	End Sub
	Private Sub load_dgSelVBranch(ByRef nVendId As Short)
		
		'On Error GoTo ErrorHandler:
		'UPGRADE_NOTE: Object dgSelVBranch.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		dgSelVBranch.DataSource = Nothing
		
		sStmt = "SELECT vend_seq, vend_name, " & " state_id 'State', vend_area 'Area' " & " FROM  VBranch " & " WHERE vend_id= " & Str(nVendId) & " ORDER BY  state_id, vend_name"
		
        rsSelVBranch = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic)

        dgSelVBranch.DataSource = rsSelVBranch


        dgSelVBranch.Columns("vend_seq").Visible = False
        dgSelVBranch.Columns("vend_name").Visible = False
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "load_dgselVBranch")
        MsgBox("Unexpected error when loading Vendor Branch info." & vbCrLf & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
		
	End Sub
	'Agrega estados a dgAssgState desde dgState
	Private Sub add_member()
        Dim vRow As Integer
        Dim iRowCntr As Integer = 0
		On Error GoTo ErrorHandler

        If dgVBranch.SelectedRows.Count < 1 Then
            If dgVBranch.SelectedCells.Count > 0 Then
                dgVBranch.Rows(dgVBranch.SelectedCells(0).RowIndex).Selected = True
            End If
        End If

        For iRowCntr = 0 To dgVBranch.SelectedRows.Count - 1
            vRow = dgVBranch.SelectedRows(0).Index

            'Verifico si branch ya existe en recordset

            If record_exist(rsSelVBranch, dgVBranch.Rows(vRow).Cells("vend_seq").Value) = False Then

                Dim drow As DataRow = rsSelVBranch.NewRow()
                'rsSelVBranch.Item("vend_seq").Value = rsVBranch.Item("vend_seq").Value
                drow.Item("vend_seq") = dgVBranch.Rows(vRow).Cells("vend_seq").Value
                drow.Item("state") = dgVBranch.Rows(vRow).Cells("state").Value
                drow.Item("vend_name") = dgVBranch.Rows(vRow).Cells("vend_name").Value
                drow.Item("area") = dgVBranch.Rows(vRow).Cells("area").Value
                rsSelVBranch.Rows.Add(drow)

                'rsSelVBranch.Select("state")

                dgSelVBranch.Sort(dgSelVBranch.Columns("state"), System.ComponentModel.ListSortDirection.Ascending)

            End If
            Dim drDelRow As DataRow() = rsVBranch.Select("vend_seq = " + dgVBranch.Rows(vRow).Cells("vend_seq").Value.ToString())
            If drDelRow.Length > 0 Then
                rsVBranch.Rows.Remove(drDelRow(0))
            End If
        Next iRowCntr

        dgSelVBranch.Refresh()
        dgVBranch.Refresh()

		Exit Sub
		
ErrorHandler: 
		If Err.Number = 3021 Then
			MsgBox("Error found.")
		End If
        save_error(Me.Name, "add_member")
		MsgBox("Unexpected error found. Check log for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
	End Sub
	
	'Busca una branch en Datagrid
    Private Function record_exist(ByRef rsTmp As DataTable, ByRef nVendSeq As Short) As Boolean
        Dim sCriteria As String
        sCriteria = "vend_seq=" & Str(nVendSeq)
        If rsTmp.Rows.Count < 1 Then
            record_exist = False
            Exit Function
        End If

        'rsTmp.Find(sCriteria, , ADODB.SearchDirectionEnum.adSearchForward)

        Dim drTmp As DataRow() = rsTmp.Select(sCriteria)

        If drTmp.Length < 1 Then
            record_exist = False
            Exit Function
        End If
        record_exist = True

    End Function
	
	'Agrega branches a dgSelVbranch desde dgVBranch
	Private Sub del_member()
        Dim vRow As Integer
        Dim iRowCntr As Integer = 0
		On Error GoTo ErrorHandler

        If dgSelVBranch.SelectedRows.Count < 1 Then
            If dgSelVBranch.SelectedCells.Count > 0 Then
                dgSelVBranch.Rows(dgSelVBranch.SelectedCells(0).RowIndex).Selected = True
            End If
        End If

        For iRowCntr = 0 To dgSelVBranch.SelectedRows.Count - 1
            vRow = dgSelVBranch.SelectedRows(0).Index
            'Verifico si tienda ya existe en recordset
            If record_exist(rsVBranch, dgSelVBranch.Rows(vRow).Cells("vend_seq").Value) = False Then
                Dim drow As DataRow = rsVBranch.NewRow()
                drow.Item("vend_seq") = dgSelVBranch.Rows(vRow).Cells("vend_seq").Value
                drow.Item("state") = dgSelVBranch.Rows(vRow).Cells("state").Value
                drow.Item("vend_name") = dgSelVBranch.Rows(vRow).Cells("vend_name").Value
                drow.Item("area") = dgSelVBranch.Rows(vRow).Cells("area").Value
                rsVBranch.Rows.Add(drow)

                'rsVBranch.Select("state")
                dgVBranch.Sort(dgVBranch.Columns("state"), System.ComponentModel.ListSortDirection.Ascending)
            End If

            Dim drDelRows As DataRow() = rsSelVBranch.Select("vend_seq = " + dgSelVBranch.Rows(vRow).Cells("vend_seq").Value.ToString())
            If drDelRows.Length > 0 Then
                rsSelVBranch.Rows.Remove(drDelRows(0))
            End If
        Next iRowCntr

        dgVBranch.Refresh()
        dgSelVBranch.Refresh()
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "del_member")
		MsgBox("Unexpected error found on Vendor Branch selection." & vbCrLf & "Please check log file for details.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Error")
		
	End Sub

    Private Sub dgSelVBranch_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSelVBranch.CellDoubleClick
        del_member()
    End Sub

    Private Sub dgVBranch_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgVBranch.CellDoubleClick
        add_member()
    End Sub
End Class