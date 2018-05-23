Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmRepDefEntry
	Inherits System.Windows.Forms.Form
    Private rsRepDefTemplate As DataTable

	
	Private Sub cmdBrowse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBrowse.Click
		Dim sDir As String
		Dim fs As Scripting.FileSystemObject
		
		On Error GoTo ErrorHandler
		
		fs = New Scripting.FileSystemObject
		
		sDir = gGlobSettings.sReportDir
		If Not fs.FolderExists(sDir) Then
			sDir = "f:\"
		End If
		
		
		cdFileOpen.InitialDirectory = sDir 'Directorio donde resigen reportes
		cdFileOpen.DefaultExt = ".rpt"

		cdFileOpen.Filter = "Reports (*.rpt)|*.rpt"
		cdFileOpen.FilterIndex = 1


        'no se para que es esta linea
        'cdFile.CancelError = True 'Genera un error 32755 si el usuario escoge Cancel al guardar Save
        If (DialogResult.Cancel = cdFileOpen.ShowDialog()) Then
            Exit Sub
        End If
		
		
		
		If Trim(cdFileOpen.FileName) = "" Then
			txtRepTemplateFile.Text = ""
		Else
			If fs.FileExists(cdFileOpen.FileName) Then
				txtRepTemplateFile.Text = cdFileOpen.FileName
			Else
				txtRepTemplateFile.Text = ""
				MsgBox("Such  files does not exist.")
			End If
		End If
		
		Exit Sub
		
ErrorHandler: 
		
        If Err.Number = DialogResult.Cancel Then
            'Usuario selecciono cancel en OpenDialog
            MsgBox("Operation was cancelled by user.", MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Sub
        Else
            save_error(Me.Name, "cmdOk")
            MsgBox("An error occurred while opening file. Try again.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")

        End If
		
	End Sub
	
	Private Sub cmdDeleteTemplate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDeleteTemplate.Click
		Dim nRecords As Short
        Dim cmd As SqlCommand = cn.CreateCommand
		On Error GoTo ErrorHandler
		
        If dgRepDefTemplate.SelectedRows.Count <= 0 Then
            MsgBox("You must select a Template before attempting this command.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Sub
        End If
		
		If MsgBox("Do you want to delete this Template?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "GLM Message") = MsgBoxResult.No Then
			Exit Sub
		End If
		
		
        sStmt = "DELETE FROM RepDefTemplate " & " WHERE rep_no =" & Str(gRepDef.nRepNo) & " AND rep_template_name ='" & dgRepDefTemplate.CurrentRow.Cells("Template").Value & "'"

        cmd.CommandText = sStmt
        nRecords = cmd.ExecuteNonQuery()
		If nRecords > 0 Then
			MsgBox("Template was successfully removed.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
		Else
			MsgBox("Failed to delete template.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		End If
		load_dgRepDefTemplate()
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "cmdDeleteTEmplate")
		MsgBox("Unexpected error found while deleting record.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
		
	End Sub
	
	Private Sub cmdEditTemplate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEditTemplate.Click
		If gRepDef.bFlag = General.modo.SavedRecord Then
            'Header was saved

            If dgRepDefTemplate.SelectedRows.Count > 0 Or dgRepDefTemplate.SelectedCells.Count > 0 Then
                If Not Trim(dgRepDefTemplate.Rows(dgRepDefTemplate.SelectedCells(0).RowIndex).Cells("Template").Value) = "" Then
                    set_RepDefTemplate((General.modo.UpdateRecord))
                    VB6.ShowForm(frmRepDefTemplateEntry, VB6.FormShowConstants.Modal, Me)
                    load_dgRepDefTemplate()
                Else
                    MsgBox("No Templates selected. Please select a template.", MsgBoxStyle.Exclamation, "Report Settings")
                End If
            Else
                MsgBox("No Templates selected. Please select a template.", MsgBoxStyle.Exclamation, "Report Settings")
            End If
        Else
            If val_fields() Then
                save_repDef_record((gRepDef.bFlag)) 'Header just saved ok
                If gRepDef.bFlag = General.modo.SavedRecord Then
                    set_RepDefTemplate((General.modo.UpdateRecord))
                    VB6.ShowForm(frmRepDefTemplateEntry, VB6.FormShowConstants.Modal, Me)
                    load_dgRepDefTemplate()
                End If
            End If
        End If
		
	End Sub
	
	Private Sub cmdNewTemplate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNewTemplate.Click
		If gRepDef.bFlag = General.modo.SavedRecord Then
			'Header was saved
			set_RepDefTemplate((General.modo.NewRecord))
			VB6.ShowForm(frmRepDefTemplateEntry, VB6.FormShowConstants.Modal, Me)
			load_dgRepDefTemplate()
		Else
			If val_fields Then
				save_repDef_record((gRepDef.bFlag)) 'Header just saved ok
				If gRepDef.bFlag = General.modo.SavedRecord Then
					set_RepDefTemplate((General.modo.NewRecord))
					VB6.ShowForm(frmRepDefTemplateEntry, VB6.FormShowConstants.Modal, Me)
					load_dgRepDefTemplate()
				End If
			End If
		End If
		
	End Sub
	Private Sub set_RepDefTemplate(ByRef bModo As General.modo)
		gRepDefTemplate.bFlag = bModo
		
		Select Case bModo
			Case General.modo.NewRecord
				gRepDefTemplate.nRepNo = gRepDef.nRepNo
				gRepDefTemplate.sRepTemplateName = ""
				gRepDefTemplate.sRepTemplateDesc = ""
				gRepDefTemplate.sRepTemplateFile = ""
				gRepDefTemplate.nColOrder = 1
			Case General.modo.UpdateRecord
                gRepDefTemplate.nRepNo = gRepDef.nRepNo

                'gRepDefTemplate.sRepTemplateFile = rsRepDefTemplate.Rows(0).Item("File")
                'gRepDefTemplate.sRepTemplateName = rsRepDefTemplate.Rows(0).Item("Template")
                'gRepDefTemplate.sRepTemplateDesc = rsRepDefTemplate.Rows(0).Item("Description")
                'gRepDefTemplate.nColOrder = rsRepDefTemplate.Rows(0).Item("Order Seq")
                If dgRepDefTemplate.SelectedRows.Count = 0 Then
                    For Each aCell As DataGridViewCell In dgRepDefTemplate.SelectedCells
                        dgRepDefTemplate.Rows(aCell.RowIndex).Selected = True
                    Next
                End If

                If dgRepDefTemplate.SelectedRows.Count > 0 Then
                    gRepDefTemplate.sRepTemplateFile = dgRepDefTemplate.SelectedRows(0).Cells("File").Value
                    gRepDefTemplate.sRepTemplateName = dgRepDefTemplate.SelectedRows(0).Cells("Template").Value
                    gRepDefTemplate.sRepTemplateDesc = dgRepDefTemplate.SelectedRows(0).Cells("Description").Value
                    gRepDefTemplate.nColOrder = dgRepDefTemplate.SelectedRows(0).Cells("Order Seq").Value
                ElseIf dgRepDefTemplate.Rows.Count > 0 Then
                    gRepDefTemplate.sRepTemplateFile = dgRepDefTemplate.Rows(0).Cells("File").Value
                    gRepDefTemplate.sRepTemplateName = dgRepDefTemplate.Rows(0).Cells("Template").Value
                    gRepDefTemplate.sRepTemplateDesc = dgRepDefTemplate.Rows(0).Cells("Description").Value
                    gRepDefTemplate.nColOrder = dgRepDefTemplate.Rows(0).Cells("Order Seq").Value

                End If


        End Select
		
	End Sub
	
	Private Sub cmdOption_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOption.Click
		'frmRepDefService.Show vbModal, Me
		set_grid_selector()
		VB6.ShowForm(tplGridSelector2, VB6.FormShowConstants.Modal, Me)
		
	End Sub
	Private Sub set_grid_selector()
		
		clear_gItplGridSelector2()
		
		gItplGridSelector2.sFormCaption = "Service Groups"
		
		gItplGridSelector2.bModo = General.modo.UpdateRecord
		'Init
		gItplGridSelector2.sQueryInit = build_query_init
		'Left
		gItplGridSelector2.sQuerySource = build_query_left
		
		'Right
		gItplGridSelector2.sQuerySelected = build_query_right
		
		gItplGridSelector2.sQueryHeader = build_query_header
		
		gItplGridSelector2.sOrderBy = "Name"
		
		gItplGridSelector2.sQueryOrderBy = " ORDER BY serv_desc "
		
        gItplGridSelector2.sInsertStmt = build_insert()
		
		gItplGridSelector2.sDeleteStmt = build_delete
		
		gItplGridSelector2.sQueryCount = build_query_count
		
		gItplGridSelector2.header(1).itemHeader = "lbHeader"
		gItplGridSelector2.header(1).sCaption = "Group"
		gItplGridSelector2.header(1).bVisible = True
		gItplGridSelector2.header(1).PositionLeft = 600
		gItplGridSelector2.header(1).PositionTop = 840
		
		gItplGridSelector2.header(2).itemHeader = "cbHeader"
		gItplGridSelector2.header(2).bVisible = True
		gItplGridSelector2.header(2).PositionLeft = 1200
		gItplGridSelector2.header(2).PositionTop = 840
		
		gItplGridSelector2.header(3).itemHeader = "txtHeader"
		gItplGridSelector2.header(3).bVisible = True
		gItplGridSelector2.header(3).PositionLeft = 1200
		gItplGridSelector2.header(3).PositionTop = 840
		
		'Formato
		gItplGridSelector2.aFields(0).sFieldName = "serv_id"
		gItplGridSelector2.aFields(0).bVisible = False
		gItplGridSelector2.aFields(0).nWidth = 100
		
		gItplGridSelector2.aFields(1).sFieldName = "Name"
		gItplGridSelector2.aFields(1).bVisible = True
		gItplGridSelector2.aFields(1).nWidth = 3000
		
		gItplGridSelector2.sLeftCaption = "Services"
		gItplGridSelector2.sRightCaption = "Selected Services"
		
		
	End Sub
	Private Function build_query_left() As String
		build_query_left = " SELECT Service.serv_id, Service.serv_desc AS Name " & " FROM Service  " & " WHERE Service.serv_id NOT IN " & " (SELECT RepDefService.serv_id FROM RepDefService " & "  WHERE RepDefService.rep_no = " & Str(gRepDef.nRepNo) & "  AND RepDefService.group_id = "
		
		
	End Function
	Private Function build_query_right() As String
		build_query_right = " SELECT RepDefService.serv_id, " & " Service.serv_desc AS Name " & " FROM RepDefService, RepDef, Service  " & " WHERE RepDefService.rep_no = RepDef.rep_no " & " AND RepDef.rep_no = " & Str(gRepDef.nRepNo) & " AND Service.serv_id = RepDefService.serv_id " & " AND RepDefService.group_id = "
		
		
	End Function
	Private Function build_query_init() As String
		build_query_init = " SELECT RepDefService.serv_id, " & " Service.serv_desc AS Name " & " FROM RepDefService, RepDef, Service  " & " WHERE RepDefService.rep_no = RepDef.rep_no " & " AND RepDef.rep_no = 0 " & " AND Service.serv_id = RepDefService.serv_id "
		
		
		
	End Function
	
	Private Function build_query_header() As String
		build_query_header = "SELECT DISTINCT group_id " & " FROM RepDefService " & " WHERE RepDefService.rep_no = " & Str(gRepDef.nRepNo) & " ORDER BY group_id "
	End Function
	Private Function build_insert() As String
        build_insert = "INSERT INTO RepDefService (rep_no, group_id, serv_id )" & " VALUES ( " & Str(gRepDef.nRepNo) & ",@group_id ,@serv_id)"
		
		
	End Function
	Private Function build_delete() As String
        build_delete = "DELETE FROM RepDefService " & " WHERE rep_no = " & Str(gRepDef.nRepNo) & " AND group_id = @group_id"
	End Function
	Private Function build_query_count() As String
        build_query_count = "SELECT COUNT(*) FROM RepDefService " & " WHERE rep_no = " & Str(gRepDef.nRepNo) & " AND group_id = @group_id"
		
	End Function
	Private Sub frmRepDefEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
        'rsRepDefTemplate.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        txtRepNo.Text = CStr(gRepDef.nRepNo)
        txtRepCaption.Text = Trim(gRepDef.sRepCaption)
        txtRepSpName.Text = Trim(gRepDef.sRepSpName)
        txtRepTemplateFile.Text = Trim(gRepDef.sRepTemplateFile)
        txtTableName.Text = Trim(gRepDef.sTableName)

        'UPGRADE_WARNING: TextBox property txtRepCaption.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        txtRepCaption.MaxLength = 50
        'UPGRADE_WARNING: TextBox property txtRepSpName.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        txtRepSpName.MaxLength = 30
        'UPGRADE_WARNING: TextBox property txtRepTemplateFile.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        txtRepTemplateFile.MaxLength = 100
        'UPGRADE_WARNING: TextBox property txtTableName.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        txtTableName.MaxLength = 50

        load_dgRepDefTemplate()
    End Sub
	
    Private Sub load_dgRepDefTemplate()
        Dim cmd As SqlCommand = cn.CreateCommand()
        sStmt = "SELECT rep_template_name Template, " & " rep_template_desc 'Description', " & " rep_template_file 'File', col_order 'Order Seq'" & " FROM repDefTemplate " & " WHERE rep_no = " & Str(gRepDef.nRepNo)
        cmd.CommandText = sStmt
        
        rsRepDefTemplate = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsRepDefTemplate.Rows.Count > 0 Then
            dgRepDefTemplate.DataSource = rsRepDefTemplate
            'format
            dgRepDefTemplate.Columns("Template").Width = VB6.TwipsToPixelsX(1500)
            dgRepDefTemplate.Columns("Description").Width = VB6.TwipsToPixelsX(3000)
            dgRepDefTemplate.Columns("File").Width = VB6.TwipsToPixelsX(4000)
            dgRepDefTemplate.Columns("Order Seq").Width = VB6.TwipsToPixelsX(300)
        Else
            dgRepDefTemplate.DataSource = Nothing
        End If

    End Sub
	
    Private Sub frmRepDefEntry_FormClosed(ByVal eventSender As System.Object, _
                                          ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs, _

        If gRepDef.bFlag = General.modo.SavedRecord Then
            'ok
        Else
            If MsgBox("Do you want to save your changes?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "GLM Warning") = MsgBoxResult.Yes Then
                If val_fields() Then
                    save_repDef_record(gRepDef.bFlag)
                Else
                    'UPGRADE_ISSUE: Event parameter Cancel was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
                    e.Cancel = True
                End If
            End If
        End If
        frmRepDef.dgRepDef.ClearSelection()
        frmRepDef.dgRepDef.CurrentCell = Nothing
        frmRepDef.dgRepDef.Rows(0).Selected = True
    End Sub

    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "save"
                If val_fields() Then
                    save_repDef_record(gRepDef.bFlag)
                End If
            Case "exit"
                Me.Close()
        End Select

    End Sub
    Private Function val_fields() As Boolean
        val_fields = True
        Dim cmd As SqlCommand = cn.CreateCommand()
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(txtRepCaption.Text) Then
            MsgBox("You must enter Report Name.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
            txtRepCaption.Focus()
            val_fields = False
            Exit Function
        ElseIf Len(Trim(txtRepCaption.Text)) <= 0 Then
            MsgBox("You must enter Report Name.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
            txtRepCaption.Focus()
            val_fields = False
            Exit Function
        Else
            'Check for duplicates
            sStmt = "SELECT rep_no FROM RepDef " & "WHERE rep_caption='" & Trim(quotation_mask(txtRepCaption.Text)) & "'"
            cmd.CommandText = sStmt
            
            rs = getDataTable(sStmt) ' cmd.ExecuteReader() '[.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rs.Rows.Count > 0 Then
                If gRepDef.bFlag = General.modo.NewRecord Or (gRepDef.bFlag = General.modo.UpdateRecord And rs.Rows(0).Item(0) <> txtRepNo.Text) Then
                    val_fields = False
                    MsgBox("Duplicate Report Name, try another.", MsgBoxStyle.Critical + MsgBoxStyle.Exclamation, "GLM Warning")
                    txtRepCaption.Focus()
                    Exit Function
                End If
            End If


        End If

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(txtRepSpName.Text) Then
            MsgBox("You must enter Report Stored Procedure.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
            txtRepSpName.Focus()
            val_fields = False
            Exit Function
        ElseIf Len(txtRepSpName.Text) <= 0 Then
            MsgBox("You must enter Report Stored Procedure.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
            txtRepSpName.Focus()
            val_fields = False
            Exit Function
        End If

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(txtRepTemplateFile.Text) Then
            MsgBox("You must enter Report Template File.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
            txtRepTemplateFile.Focus()
            val_fields = False
            Exit Function
        ElseIf Len(txtRepTemplateFile.Text) <= 0 Then
            MsgBox("You must enter Report Template File.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
            txtRepTemplateFile.Focus()
            val_fields = False
            Exit Function
        End If

        Exit Function

ErrorHandler:
        save_error(Me.Name, "val_fields")
        MsgBox("Unexpected while verifying data. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")

    End Function
    Private Sub save_repDef_record(ByRef nOption As General.modo)
        Dim nRepNo As Short
        Dim nTran As SqlTransaction
        Dim nRecords As Short
        Dim cmd As SqlCommand = cn.CreateCommand()

        On Error GoTo ErrorHandler


        Select Case nOption
            Case General.modo.NewRecord
                nRepNo = get_table_sequence("RepDef", "rep_no")

                sStmt = "INSERT INTO RepDef (rep_no, rep_caption," & "rep_sp_name,rep_template_file, table_name) " & " VALUES (" & Str(nRepNo) & ", '" & quotation_mask(txtRepCaption.Text) & "'," & "'" & quotation_mask(txtRepSpName.Text) & "'," & "'" & quotation_mask(txtRepTemplateFile.Text) & "'," & "'" & quotation_mask(txtTableName.Text) & "')"
            Case General.modo.UpdateRecord
                If UCase(Trim(gRepDef.sRepCaption)) <> UCase(Trim(txtRepCaption.Text)) Then
                    If MsgBox("Changing Report Name may cause unexpected results in Report." & "Do you want to continue", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "GLM Message") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If

                sStmt = "UPDATE RepDef " & " SET rep_caption ='" & Trim(quotation_mask(txtRepCaption.Text)) & "'," & " rep_sp_name='" & Trim(quotation_mask(txtRepSpName.Text)) & "'," & " rep_template_file ='" & Trim(quotation_mask(txtRepTemplateFile.Text)) & "'," & " table_name ='" & Trim(quotation_mask(txtTableName.Text)) & "'" & " WHERE rep_no =" & Str(gRepDef.nRepNo)
            Case Else
                MsgBox("Record was previously saved.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                Exit Sub
        End Select


        nTran = cn.BeginTransaction()
        cmd.CommandText = sStmt
        cmd.Transaction = nTran
        Select Case nOption
            Case General.modo.NewRecord
                nRecords = cmd.ExecuteNonQuery()
                If nRecords <= 0 Then
                    nTran.Rollback()
                    MsgBox("Failed to insert report definition.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                Else
                    gRepDef.nRepNo = nRepNo
                    gRepDef.bFlag = General.modo.SavedRecord
                    nTran.Commit()

                    MsgBox("Record was saved.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                End If
                Exit Sub
            Case General.modo.UpdateRecord
                nRecords = cmd.ExecuteNonQuery()
                If nRecords <= 0 Then
                    nTran.Rollback()

                    MsgBox("Failed to update report definition.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                    Exit Sub
                Else
                    gRepDef.bFlag = General.modo.SavedRecord
                    nTran.Commit()
                    MsgBox("Record was saved.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                End If
                Exit Sub
        End Select


        Exit Sub

ErrorHandler:

        nTran.Rollback()

        save_error(Me.Name, "save_repDef_record")
        MsgBox("Unexpected error occurred when saving Report Definition. " & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
    End Sub

    'UPGRADE_WARNING: Event txtRepCaption.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub txtRepCaption_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtRepCaption.TextChanged
        If gRepDef.bFlag = General.modo.SavedRecord Then
            gRepDef.bFlag = General.modo.UpdateRecord
        End If
    End Sub

    'UPGRADE_WARNING: Event txtRepSpName.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub txtRepSpName_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtRepSpName.TextChanged
        If gRepDef.bFlag = General.modo.SavedRecord Then
            gRepDef.bFlag = General.modo.UpdateRecord
        End If

    End Sub

    'UPGRADE_WARNING: Event txtRepTemplateFile.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub txtRepTemplateFile_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtRepTemplateFile.TextChanged
        If gRepDef.bFlag = General.modo.SavedRecord Then
            gRepDef.bFlag = General.modo.UpdateRecord
        End If

    End Sub


    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        If val_fields() Then
            save_repDef_record(gRepDef.bFlag)
        End If
    End Sub
End Class