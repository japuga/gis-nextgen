Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmService
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private ImageList2 As New ImageList()
	
    Private Sub dgService_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        update_service()
    End Sub
	
	Private Sub frmService_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		
	End Sub
	
	Private Sub init_vars()

        init_service_record()
        load_dgService()

    End Sub
	'Inicializa el registro de servicios
	Private Sub init_service_record()
		
		gServiceRecord.serv_id = -1
		gServiceRecord.serv_class = ""
		gServiceRecord.serv_class_id = ""
		gServiceRecord.serv_credit = ""
		gServiceRecord.serv_desc = ""
		gServiceRecord.serv_eqpt = ""
		gServiceRecord.serv_frequency = ""
		gServiceRecord.serv_measure_unit = ""
		gServiceRecord.serv_rate_contract = ""
		gServiceRecord.unit_desc = ""
		gServiceRecord.serv_id_conversion = 0
		
		
	End Sub
	Private Sub load_dgService()
		Dim bFound As Boolean
		
		On Error GoTo ErrorHandler
		
		sStmt = "SELECT serv_id, serv_desc AS 'Name', " & "dbo.convert_bool(serv_eqpt)AS 'Eqpt'," & "dbo.convert_bool(serv_credit)AS 'Cred'," & "dbo.convert_bool(serv_rate_contract) AS 'Contract', " & "RTRIM(unit_desc)AS 'Unit'," & "RTRIM(serv_class) AS 'Class'," & "dbo.convert_yn(serv_frequency) AS 'Freq'," & "serv_measure_unit, serv_class_id, serv_id_conversion " & " FROM service " & " ORDER BY serv_desc"
		
        dgService.DataSource = Nothing

        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		'search
		bFound = False

        If rsLocal.Rows.Count > 0 Then
            For row As Integer = 0 To rsLocal.Rows.Count - 1
                If rsLocal.Rows(row).Item("serv_id") = gServiceRecord.serv_id Then
                    bFound = True
                    Exit For
                End If
            Next row
            
        End If



        dgService.DataSource = rsLocal
        'dgService.Rows(0).Selected = True
        If rsLocal.Rows.Count > 0 Then
            If bFound = False Then
            End If
            'dgService.SelBookmarks.Add((rsLocal.Bookmark))
        End If



        'Formato
        dgService.Columns("serv_id").Visible = False
        dgService.Columns("contract").Visible = False
        dgService.Columns("serv_measure_unit").Visible = False
        dgService.Columns("serv_class_id").Visible = False
        dgService.Columns("serv_id_conversion").Visible = False

        dgService.Columns("Name").Width = VB6.TwipsToPixelsX(2500)
        dgService.Columns("Eqpt").Width = VB6.TwipsToPixelsX(500)
        dgService.Columns("Cred").Width = VB6.TwipsToPixelsX(500)
        dgService.Columns("Contract").Width = VB6.TwipsToPixelsX(800)
        dgService.Columns("Unit").Width = VB6.TwipsToPixelsX(2000)
        dgService.Columns("Class").Width = VB6.TwipsToPixelsX(1500)
        dgService.Columns("Freq").Width = VB6.TwipsToPixelsX(500)
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "load_dgService")
        MsgBox("Failed to format data grid. Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
		
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)

        Select Case Button.Name
            Case "new"
                add_service()
            Case "save"
                update_service()
            Case "exit"
                Me.Close()
        End Select

    End Sub
	
	Private Sub add_service()
		gServiceRecord.bFlag = General.modo.NewRecord
        VB6.ShowForm(frmServiceEntry, VB6.FormShowConstants.Modal, Me)
        frmServiceEntry.Dispose()
		If gServiceRecord.bFlag = General.modo.SavedRecord Then
			load_dgService()
		End If
	End Sub
	
	Private Sub update_service()
        If dgService.SelectedRows.Count < 1 Then
            If dgService.SelectedCells.Count > 0 Then
                dgService.Rows(dgService.SelectedCells(0).RowIndex).Selected = True
            End If
        End If
        If dgService.SelectedRows.Count > 0 Then
            gServiceRecord.bFlag = General.modo.UpdateRecord
            set_service()
            VB6.ShowForm(frmServiceEntry, VB6.FormShowConstants.Modal, Me)
            frmServiceEntry.Dispose()
            If gServiceRecord.bFlag = General.modo.SavedRecord Then
                load_dgService()
            End If
        Else
            MsgBox("You must select a record before attempting this command.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
        End If

    End Sub
	
	Private Sub set_service()
		
        gServiceRecord.serv_id = dgService.SelectedRows(0).Cells("serv_id").Value
		'Desc
        If IsDBNull(dgService.SelectedRows(0).Cells("Name").Value) Then
            gServiceRecord.serv_desc = ""
        Else
            gServiceRecord.serv_desc = Trim(dgService.SelectedRows(0).Cells("Name").Value)
        End If
		'serv_eqpt
        If IsDBNull(dgService.SelectedRows(0).Cells("Eqpt").Value) Then
            gServiceRecord.serv_eqpt = "F"
        Else
            gServiceRecord.serv_eqpt = dgService.SelectedRows(0).Cells("Eqpt").Value
        End If
		'Credit
        If IsDBNull(dgService.SelectedRows(0).Cells("Cred")) Then
            gServiceRecord.serv_credit = "F"
        Else
            gServiceRecord.serv_credit = dgService.SelectedRows(0).Cells("Cred").Value
        End If
		'serv_rate_contract
        If IsDBNull(dgService.SelectedRows(0).Cells("Contract")) Then
            gServiceRecord.serv_rate_contract = "F"
        Else
            gServiceRecord.serv_rate_contract = dgService.SelectedRows(0).Cells("Contract").Value
        End If
		'serv_measure_unit
        If IsDBNull(dgService.SelectedRows(0).Cells("serv_measure_unit")) Then
            gServiceRecord.serv_measure_unit = ""
        Else
            gServiceRecord.serv_measure_unit = Trim(dgService.SelectedRows(0).Cells("serv_measure_unit").Value)
        End If
		'unit_desc
        If IsDBNull(dgService.selectedrows(0).Cells("Unit")) Then
            gServiceRecord.unit_desc = ""
        Else
            gServiceRecord.unit_desc = Trim(dgService.SelectedRows(0).Cells("Unit").Value)
        End If
		'Class
        If IsDBNull(dgService.SelectedRows(0).Cells("Class")) Then
            gServiceRecord.serv_class = ""
        Else
            gServiceRecord.serv_class = dgService.SelectedRows(0).Cells("Class").Value
        End If
		'Class Id
        If IsDBNull(dgService.SelectedRows(0).Cells("serv_class_id")) Then
            gServiceRecord.serv_class_id = ""
        Else
            gServiceRecord.serv_class_id = dgService.SelectedRows(0).Cells("serv_class_id").Value
        End If
		
		'Frequency
        If IsDBNull(dgService.selectedrows(0).Cells("Freq")) Then
            gServiceRecord.serv_frequency = ""
        Else
            gServiceRecord.serv_frequency = dgService.SelectedRows(0).Cells("Freq").Value
        End If
		
		'ServIdConversion
        If IsDBNull(dgService.selectedrows(0).Cells("serv_id_conversion")) Then
            gServiceRecord.serv_id_conversion = 0
        Else
            gServiceRecord.serv_id_conversion = dgService.SelectedRows(0).Cells("serv_id_conversion").Value
        End If
	End Sub

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        add_service()
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        update_service()
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub dgService_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgService.CellDoubleClick
        update_service()
    End Sub
End Class