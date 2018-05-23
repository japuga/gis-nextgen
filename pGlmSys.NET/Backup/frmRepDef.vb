Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmRepDef
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable

	
    Private Sub dgRepDef_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        save_repDef((General.modo.UpdateRecord))
    End Sub
	
	Private Sub frmRepDef_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
        rsLocal = Nothing

		load_dgRepDef()
	End Sub
	Private Sub load_dgRepDef()
        Dim cmd As SqlCommand = cn.CreateCommand()

		dgRepDef.DataSource = Nothing
		'Cargar Lista de Reports
		sStmt = "SELECT rep_no, rep_caption 'Name', " & "rep_sp_name 'Stored Procedure', " & "rep_template_file 'Default Template'," & "table_name " & " FROM repDef " & " ORDER BY rep_caption "
        cmd.CommandText = sStmt
		
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsLocal.Rows.Count > 0 Then
            dgRepDef.DataSource = rsLocal
            dgRepDef.Refresh()
        Else
            Exit Sub
        End If
		
		'Formato
		dgRepDef.Columns("rep_no").Visible = False
		dgRepDef.Columns("Name").Width = VB6.TwipsToPixelsX(2000)
		dgRepDef.Columns("Stored Procedure").Width = VB6.TwipsToPixelsX(2000)
		dgRepDef.Columns("Default Template").Width = VB6.TwipsToPixelsX(3000)
		dgRepDef.Columns("table_name").Visible = False
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "new"
                save_repDef((General.modo.NewRecord))
            Case "save"
                save_repDef((General.modo.UpdateRecord))

            Case "delete"
                delete_repDef()
            Case "exit"
                Me.Close()
        End Select

    End Sub
    Private Sub save_repDef(ByRef nOption As General.modo)
        If dgRepDef.SelectedCells.Count > 0 Then
            Dim rowIndx As Integer = dgRepDef.SelectedCells(0).RowIndex
            dgRepDef.Rows(rowIndx).Selected = True
        End If
        If nOption = modo.UpdateRecord Then
            If dgRepDef.SelectedRows.Count < 1 Then

                MsgBox("No rows selected. Please select a row.", MsgBoxStyle.Information, "Report Definition Error")
                Exit Sub
            End If
        End If

        If set_RepDef(nOption) Then
            VB6.ShowForm(frmRepDefEntry, VB6.FormShowConstants.Modal, Me)
            load_dgRepDef()
        End If


    End Sub
	'Alimenta gRepDef con los datos del datagrid
	Private Function set_RepDef(ByRef bFlag As General.modo) As Boolean
		
		
		On Error GoTo ErrorHandler
		
		set_RepDef = False
		
		Select Case bFlag
			Case General.modo.NewRecord
				gRepDef.bFlag = General.modo.NewRecord
				gRepDef.nRepNo = 0
				gRepDef.sRepCaption = ""
				gRepDef.sRepSpName = ""
				gRepDef.sRepTemplateFile = ""
				gRepDef.sTableName = ""
				
            Case General.modo.UpdateRecord
                If Not dgRepDef.SelectedRows.Count > 0 Then
                    Return False
                End If
                Dim localIndex As Integer = dgRepDef.SelectedRows(0).Index

                'rsLocal.LoadDataRow(dgRepDef.CurrentRow., True)
                If dgRepDef.SelectedRows.Count < 0 Then
                    MsgBox("You must select a row before attempting this action.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Function
                End If

                gRepDef.bFlag = General.modo.UpdateRecord

                If Not IsDBNull(rsLocal.Rows(localIndex).Item("rep_no")) Then
                    gRepDef.nRepNo = rsLocal.Rows(localIndex).Item("rep_no")
                Else
                    MsgBox("Could not find report number.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
                    Exit Function
                End If

                If Not IsDBNull(rsLocal.Rows(localIndex).Item("Name")) Then
                    gRepDef.sRepCaption = rsLocal.Rows(localIndex).Item("Name")
                Else
                    MsgBox("Could not find report name.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
                    Exit Function
                End If

                If Not IsDBNull(rsLocal.Rows(localIndex).Item("Stored Procedure")) Then
                    gRepDef.sRepSpName = dgRepDef.Rows(localIndex).Cells("Stored Procedure").Value
                Else
                    MsgBox("Could not find report stored procedure.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
                    Exit Function
                End If

                If Not IsDBNull(rsLocal.Rows(localIndex).Item("Default Template")) Then
                    gRepDef.sRepTemplateFile = dgRepDef.Rows(localIndex).Cells("Default Template").Value
                Else
                    MsgBox("Could not find template file.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
                    Exit Function
                End If

                If Not IsDBNull(rsLocal.Rows(localIndex).Item("table_name")) Then
                    gRepDef.sTableName = dgRepDef.Rows(localIndex).Cells("table_name").Value
                Else
                    MsgBox("Could not find data table name.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
                    Exit Function
                End If

        End Select
        set_RepDef = True
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "set_RepDef")
		MsgBox("Unexpected error was found. Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
		
	End Function
	'Deletes record from RepDef table
	Private Sub delete_repDef()
        Dim nRecords As Short
        Dim cmd As SqlCommand = cn.CreateCommand()
        If dgRepDef.SelectedRows.Count <= 0 Then
            MsgBox("You must select a row before attempting this action.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Sub
        End If
		
        If count_report_template(CShort(dgRepDef.CurrentRow.Cells("rep_no").Value)) > 0 Then
            MsgBox("Found templates for this report, you must delete them " & vbCrLf & "before attempting to delete this record.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Sub

        End If
		
        sStmt = "DELETE FROM RepDef WHERE rep_no=" & dgRepDef.CurrentRow.Cells("rep_no").Value
        cmd.CommandText = sStmt
        nRecords = cmd.ExecuteNonQuery()
		If nRecords > 0 Then
			MsgBox("Record was successfully removed.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
			load_dgRepDef()
		Else
			MsgBox("Failed to remove record or record was removed by another user.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Message")
		End If
		
	End Sub
	
	Private Function count_report_template(ByRef nRepNo As Short) As Short
		Dim nRecords As Short
        Dim cmd As sqlcommand = cn.CreateCommand()
		sStmt = "SELECT COUNT(*) FROM RepDefTemplate " & " WHERE rep_no =" & Str(nRepNo)
        cmd.CommandText = sStmt
        rs = getDataTable(sStmt) ' cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.Rows.Count > 0 Then
            If IsDBNull(rs.Rows(0).Item(0)) Then
                nRecords = 0
            Else
                nRecords = rs.Rows(0).Item(0)
            End If
        End If

        count_report_template = nRecords
	End Function

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        save_repDef((General.modo.NewRecord))
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        save_repDef((General.modo.UpdateRecord))
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub dgRepDef_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRepDef.CellContentDoubleClick
        save_repDef((General.modo.UpdateRecord))
    End Sub

    Private Sub dgRepDef_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRepDef.CellDoubleClick
        save_repDef((General.modo.UpdateRecord))
    End Sub
End Class