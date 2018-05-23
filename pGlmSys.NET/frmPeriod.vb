Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmPeriod
	Inherits System.Windows.Forms.Form
	'rslocal se usa para cargar dgPeriod, no usarlo
    Private rsLocal As DataTable
    Private cmLocal As SqlCommand
    Private ImageList2 As New ImageList()
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		cbCustId.SelectedIndex = cbCustName.SelectedIndex
        set_dgPeriodData(cbCustId.Text)
	End Sub
	
	
    Private Sub dgPeriod_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Update
        If dgPeriod.SelectedRows.Count = 0 Then
            dgPeriod.Rows(dgPeriod.SelectedCells(0).RowIndex).Selected = True
        End If

        If dgPeriod.SelectedRows.Count > 0 Then
            gPeriodRecord.bMode = General.modo.UpdateRecord
            If get_period((General.modo.UpdateRecord)) = True Then
                VB6.ShowForm(frmPeriodEntry, VB6.FormShowConstants.Modal, Me)
                If gPeriodRecord.bMode = General.modo.SavedRecord Then
                    If cbCustId.SelectedIndex >= 0 Then
                        set_dgPeriodData(cbCustId.Text)
                    End If
                End If
            End If

        End If

    End Sub
	
	Private Sub frmPeriod_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		Dim sCustId As String
		
        rsLocal = Nothing
        cmLocal = cn.CreateCommand()
		
		'La opcion de Busqueda en este mantenimiento
		' no requiere de parametros de seleccion

		clear_record()
		
		'Customer
		sStmt = "SELECT cust_id,cust_name FROM customer" & " WHERE cust_id IN (SELECT DISTINCT cust_id " & "   FROM suser_data  " & "   WHERE suser_name='" & Trim(gsUser) & "') " & " ORDER BY cust_name "
		load_cb_query(cbCustId, sStmt, 1)
		
		sStmt = "SELECT cust_name,cust_id FROM customer" & " WHERE cust_id IN (SELECT DISTINCT cust_id " & "   FROM suser_data  " & "   WHERE suser_name='" & Trim(gsUser) & "') " & " ORDER BY cust_name"
		load_cb_query(cbCustName, sStmt, 1)
		
		If cbCustName.Items.Count > 0 Then
			cbCustName.SelectedIndex = 0
		End If
		
		If Len(cbCustId.Text) = 0 Then
			sCustId = ""
		Else
			sCustId = cbCustId.Text
		End If
		
        set_dgPeriodData(sCustId)
	End Sub
	Private Sub clear_record()
		gPeriodRecord.nPeriodSeq = 0
		gPeriodRecord.sCustId = ""
		gPeriodRecord.sCustName = ""
		gPeriodRecord.sPeriodEndDate = ""
		gPeriodRecord.sPeriodStartDate = ""
		
		
	End Sub
	'Carga datos en Datagrid
    Private Sub set_dgPeriodData(ByRef sCustId As String)
        Dim bFound As Boolean

        'On Error GoTo ErrorHandler

        sStmt = "SELECT p.period_seq , p.cust_id, " & "p.period_name 'Name', " & "p.period_start_date 'Start', p.period_end_date 'End', " & "s.period_status_desc 'Status', p.period_status_id " & "FROM period p, PeriodStatus s" & " WHERE p.period_status_id = s.period_status_id " & " AND cust_id ='" & Trim(sCustId) & "'" & " ORDER BY period_start_date"

        dgPeriod.DataSource = Nothing

        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        bFound = False

        If rsLocal.rows.count > 0 Then
            'search
            If gPeriodRecord.bMode = General.modo.SavedRecord Then
                For row As Integer = 0 To rsLocal.Rows.Count - 1
                    If rsLocal.Rows(row).Item("period_seq") = gPeriodRecord.nPeriodSeq Then
                        bFound = True
                        Exit For
                    End If
                Next row
            End If
        End If 'record Count


        dgPeriod.DataSource = rsLocal
        dgPeriod.Refresh()
        If bFound Then
            'no se como funciona los bookmarks
            '            dgPeriod.SelBookmarks.Add(rsLocal.Bookmark)
        End If

        'Formato de Datagrid
        dgPeriod.Columns("period_seq").Visible = False
        dgPeriod.Columns("cust_id").Visible = False
        dgPeriod.Columns("period_status_id").Visible = False
        dgPeriod.Columns("Name").Width = VB6.TwipsToPixelsX(2000)
        dgPeriod.Columns("Start").Width = VB6.TwipsToPixelsX(2000)
        dgPeriod.Columns("End").Width = VB6.TwipsToPixelsX(2000)
        dgPeriod.Columns("Status").Width = VB6.TwipsToPixelsX(800)

        Exit Sub

ErrorHandler:
        save_error(Me.Name, "set_dgPeriodData")
        MsgBox("An error was found while loading Period data. Please check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
    End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "new"
                gPeriodRecord.bMode = General.modo.NewRecord
                If get_period((General.modo.NewRecord)) = True Then
                    VB6.ShowForm(frmPeriodEntry, VB6.FormShowConstants.Modal, Me)
                    If gPeriodRecord.bMode = General.modo.SavedRecord Then
                        If cbCustId.SelectedIndex >= 0 Then
                            set_dgPeriodData(cbCustId.Text)
                        End If
                    End If

                End If
            Case "save"
                dgPeriod_DblClick(dgPeriod, New System.EventArgs())
            Case "delete"
                remove_period()
                set_dgPeriodData(cbCustId.Text)
            Case "exit"
                Me.Close()
        End Select

    End Sub
	'Guarda informacion en variable global para frmPeriodEntry
	Private Function get_period(ByRef nOption As General.modo) As Boolean
		
		On Error GoTo ErrorHandler
		get_period = True
		If cbCustId.SelectedIndex >= 0 Then
			gPeriodRecord.sCustId = cbCustId.Text
			gPeriodRecord.sCustName = cbCustName.Text
		Else
			get_period = False
		End If
		
		Select Case nOption
			Case General.modo.NewRecord
				gPeriodRecord.nPeriodSeq = 0
			Case General.modo.UpdateRecord
                gPeriodRecord.nPeriodSeq = rsLocal.Rows(dgPeriod.SelectedRows(0).Index).Item("period_seq")
                gPeriodRecord.sPeriodStartDate = rsLocal.Rows(dgPeriod.SelectedRows(0).Index).Item("Start")
                gPeriodRecord.sPeriodEndDate = rsLocal.Rows(dgPeriod.SelectedRows(0).Index).Item("End")
                gPeriodRecord.sPeriodName = rsLocal.Rows(dgPeriod.SelectedRows(0).Index).Item("Name")
                gPeriodRecord.sPeriodStatusId = rsLocal.Rows(dgPeriod.SelectedRows(0).Index).Item("period_status_id")
                gPeriodRecord.sPeriodStatusDesc = rsLocal.Rows(dgPeriod.SelectedRows(0).Index).Item("Status")
		End Select
		Exit Function
		
ErrorHandler: 
		get_period = False
		save_error(Me.Name, "get_period")
		MsgBox("An unexpected error has occurred.Please check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Function
	'Elimina un periodo
	Private Sub remove_period()
		Dim nRecords As Short
		
		On Error GoTo ErrorHandler
		nRecords = 0
        If dgPeriod.SelectedRows.Count > 0 Then
            If MsgBox("Do you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "GLM Warning") = MsgBoxResult.Yes Then
                'Verificar que no exista factura usando periodo.
                If invoice_assigned(cbCustId.Text, CShort(dgPeriod.CurrentRow.Cells("period_seq").Value)) > 0 Then
                    MsgBox("Unable to delete Period, one or more invoices " & vbCrLf & "are still assigned to it.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Warning")
                    Exit Sub
                Else
                    sStmt = "DELETE FROM period " & "WHERE cust_id ='" & Trim(cbCustId.Text) & "' " & " AND period_seq =" & dgPeriod.CurrentRow.Cells("period_seq").Value
                    cm = cn.CreateCommand
                    With cmLocal
                        .CommandType = CommandType.Text
                        .CommandText = sStmt
                        nRecords = .ExecuteNonQuery()
                    End With
                    If nRecords = 0 Then
                        MsgBox("There was an error while deleting Period.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                    End If
                End If
            End If
        End If
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "remove_period")
		MsgBox("There was an error while deleting Period.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
	End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        gPeriodRecord.bMode = General.modo.NewRecord
        If get_period((General.modo.NewRecord)) = True Then
            VB6.ShowForm(frmPeriodEntry, VB6.FormShowConstants.Modal, Me)
            If gPeriodRecord.bMode = General.modo.SavedRecord Then
                If cbCustId.SelectedIndex >= 0 Then
                    set_dgPeriodData(cbCustId.Text)
                End If
            End If
        End If
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        dgPeriod_DblClick(dgPeriod, New System.EventArgs())
    End Sub

    Private Sub btSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        remove_period()
        set_dgPeriodData(cbCustId.Text)
    End Sub

    Private Sub dgPeriod_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPeriod.CellDoubleClick
        dgPeriod_DblClick(dgPeriod, New System.EventArgs())
    End Sub
End Class