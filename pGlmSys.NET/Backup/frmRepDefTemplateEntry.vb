Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmRepDefTemplateEntry
    Inherits System.Windows.Forms.Form
    Private ImageList2 As New ImageList()
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
        'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        cdFileOpen.Filter = "Reports (*.rpt)|*.rpt"
        cdFileOpen.FilterIndex = 1
        'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'

        'no se para que es esta linea
        'cdFile.CancelError = True 'Genera un error 32755 si el usuario escoge Cancel al guardar Save
        If Not cdFileOpen.ShowDialog() = Windows.Forms.DialogResult.Cancel Then



            If Trim(cdFileOpen.FileName) = "" Then
                txtRepTemplateFile.Text = ""
            Else
                If fs.FileExists(cdFileOpen.FileName) Then
                    txtRepTemplateFile.Text = cdFileOpen.FileName
                Else
                    txtRepTemplateFile.Text = ""
                    MsgBox("Such  file does not exist.")
                End If
            End If
        End If

        Exit Sub

ErrorHandler:

        'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
        If Err.Number = DialogResult.Cancel Then
            'Usuario selecciono cancel en OpenDialog
            MsgBox("Operation was cancelled by user.", MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Sub
        Else
            save_error(Me.Name, "cmdBrowse")
            MsgBox("An error occurred while opening file. Try again.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")

        End If

    End Sub

    Private Sub frmRepDefTemplateEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        init_vars()
    End Sub

    Private Sub init_vars()

        txtRepTemplateName.Text = gRepDefTemplate.sRepTemplateName
        txtRepTemplateDesc.Text = gRepDefTemplate.sRepTemplateDesc
        txtRepTemplateFile.Text = gRepDefTemplate.sRepTemplateFile
        txtColOrder.Text = CStr(gRepDefTemplate.nColOrder)

        If gRepDefTemplate.bFlag = General.modo.UpdateRecord Then
            txtRepTemplateName.Enabled = False
            txtRepTemplateName.ReadOnly = True
        Else 'if new record
            txtRepTemplateName.Enabled = True
            txtRepTemplateName.ReadOnly = False
        End If

    End Sub

    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "save"
                If val_fields() Then
                    save_template(gRepDefTemplate.bFlag)
                End If
            Case "exit"

                Me.Close()
        End Select
    End Sub

    Private Sub save_template(ByRef nOption As General.modo)
        Dim nRecords As Integer = 0
        Dim nTran As SqlTransaction
        Dim cmd As SqlCommand = cn.CreateCommand()

        Select Case nOption
            Case General.modo.NewRecord
                sStmt = "INSERT INTO RepDefTemplate (rep_no, " & "rep_template_name, rep_template_desc," & "rep_template_file, col_order) " & " VALUES (" & Str(gRepDefTemplate.nRepNo) & ", " & "'" & txtRepTemplateName.Text & "'," & "'" & txtRepTemplateDesc.Text & "'," & "'" & txtRepTemplateFile.Text & "'," & txtColOrder.Text & ")"

            Case General.modo.UpdateRecord
                sStmt = "UPDATE RepDefTemplate " & " SET " & " rep_template_desc ='" & Trim(quotation_mask(txtRepTemplateDesc.Text)) & "'," & " rep_template_file ='" & Trim(quotation_mask(txtRepTemplateFile.Text)) & "'," & " col_order =" & txtColOrder.Text & " WHERE rep_no =" & Str(gRepDefTemplate.nRepNo) & " AND rep_template_name ='" & Trim(quotation_mask(gRepDefTemplate.sRepTemplateName)) & "'"


            Case Else
                MsgBox("Template was previously saved.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Error")
                Exit Sub
        End Select

        nTran = cn.BeginTransaction()
        cmd.CommandText = sStmt
        cmd.Transaction = nTran
        nRecords = cmd.ExecuteNonQuery()

        If nRecords > 0 Then
            gRepDefTemplate.bFlag = General.modo.SavedRecord
            nTran.Commit()
            MsgBox("Template was successfully updated.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
            Me.Close()
            Exit Sub
        Else
            nTran.Rollback()
            MsgBox("Failed to save report template.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Sub
        End If

        Exit Sub

ErrorHandler:
        save_error(Me.Name, "save_template")
        MsgBox("Unexpected error was found. Check log file for details", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
    End Sub

    Private Function val_fields() As Boolean

        On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand()
        val_fields = True

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(txtRepTemplateName.Text) Then
            MsgBox("You must enter Template Name.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
            txtRepTemplateName.Focus()
            val_fields = False
            Exit Function
        ElseIf Len(Trim(txtRepTemplateName.Text)) <= 0 Then
            MsgBox("You must enter Template Name.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
            txtRepTemplateName.Focus()
            val_fields = False
            Exit Function
        Else
            'Check for duplicates
            sStmt = "SELECT rep_no, rep_template_name FROM RepDefTemplate " & "WHERE rep_template_name='" & Trim(quotation_mask(txtRepTemplateName.Text)) & "'"
            cmd.CommandText = sStmt
            
            rs = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rs.Rows.Count > 0 Then
                If (gRepDefTemplate.bFlag = General.modo.NewRecord And rs.Rows(0).Item(0) = gRepDefTemplate.nRepNo) Or (gRepDefTemplate.bFlag = General.modo.UpdateRecord And rs.Rows(0).Item("rep_no") = gRepDefTemplate.nRepNo And UCase(Trim(rs.Rows(0).Item("rep_template_name"))) <> UCase(Trim(gRepDefTemplate.sRepTemplateName))) Then
                    val_fields = False
                    MsgBox("Duplicate Template Name, try another.", MsgBoxStyle.Critical + MsgBoxStyle.Exclamation, "GLM Warning")
                    txtRepTemplateName.Focus()
                    Exit Function
                End If
            End If

        End If

        'Template Desc
        If IsDBNull(txtRepTemplateDesc.Text) Then
            MsgBox("You must enter Template Description.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
            txtRepTemplateDesc.Focus()
            val_fields = False
            Exit Function
        ElseIf Len(Trim(txtRepTemplateDesc.Text)) <= 0 Then
            MsgBox("You must enter Template Description.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
            txtRepTemplateDesc.Focus()
            val_fields = False
            Exit Function
        End If

        'Template File
        If IsDBNull(txtRepTemplateFile.Text) Then
            MsgBox("You must enter Template File.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
            txtRepTemplateFile.Focus()
            val_fields = False
            Exit Function
        ElseIf Len(Trim(txtRepTemplateFile.Text)) <= 0 Then
            MsgBox("You must enter Template File.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
            txtRepTemplateFile.Focus()
            val_fields = False
            Exit Function
        End If

        Exit Function

ErrorHandler:
        save_error(Me.Name, "val_fields")
        MsgBox("Unexpected error was found. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
        Return False
    End Function

    'UPGRADE_WARNING: Event txtRepTemplateDesc.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub txtRepTemplateDesc_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtRepTemplateDesc.TextChanged
        If gRepDefTemplate.bFlag = General.modo.SavedRecord Then
            gRepDefTemplate.bFlag = General.modo.UpdateRecord
        End If

    End Sub

    'UPGRADE_WARNING: Event txtRepTemplateFile.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub txtRepTemplateFile_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtRepTemplateFile.TextChanged
        If gRepDefTemplate.bFlag = General.modo.SavedRecord Then
            gRepDefTemplate.bFlag = General.modo.UpdateRecord
        End If

    End Sub

    'UPGRADE_WARNING: Event txtRepTemplateName.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub txtRepTemplateName_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtRepTemplateName.TextChanged
        If gRepDefTemplate.bFlag = General.modo.SavedRecord Then
            gRepDefTemplate.bFlag = General.modo.UpdateRecord
        End If

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        If val_fields() Then
            save_template(gRepDefTemplate.bFlag)

        End If
    End Sub
End Class