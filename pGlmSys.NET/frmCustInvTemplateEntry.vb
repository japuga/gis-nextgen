Option Strict Off
Option Explicit On
Friend Class frmCustInvTemplateEntry
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
		cdFileOpen.DefaultExt = ".doc"
		'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		cdFileOpen.Filter = "Templates (*.doc)|*.doc"
		cdFileOpen.FilterIndex = 1
		'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
        'cdFile.CancelError = True 'Genera un error 32755 si el usuario escoge Cancel al guardar Save
        If Not cdFileOpen.ShowDialog() = Windows.Forms.DialogResult.Cancel Then



            If Trim(cdFileOpen.FileName) = "" Then
                txtFilename.Text = ""
            Else
                If fs.FileExists(cdFileOpen.FileName) Then
                    txtFilename.Text = cdFileOpen.FileName
                Else
                    txtFilename.Text = ""
                    MsgBox("Such  file does not exist.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
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
            save_error(Me.Name, "cmdOk")
            MsgBox("An error occurred while opening file. Try again.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")

        End If


    End Sub
	
	Private Sub frmCustInvTemplateEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		
		'UPGRADE_WARNING: TextBox property txtTemplateName.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtTemplateName.Maxlength = 100
		'UPGRADE_WARNING: TextBox property txtDescription.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtDescription.Maxlength = 200
		'UPGRADE_WARNING: TextBox property txtFilename.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtFilename.Maxlength = 250
		
		Select Case gCustInvTemplate.bFlag
            Case General.modo.NewRecord
                txtTemplateName.Text = ""
                txtDescription.Text = ""
                txtFilename.Text = ""

                txtTemplateName.Enabled = True
                txtTemplateName.ReadOnly = False

            Case General.modo.UpdateRecord

                txtTemplateName.Text = gCustInvTemplate.sTemplateName
                txtDescription.Text = gCustInvTemplate.sDescription
                txtFilename.Text = gCustInvTemplate.sFilename

                txtTemplateName.Enabled = False
                txtTemplateName.ReadOnly = True

        End Select
	End Sub
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "save"
                If val_fields() Then
                    If save_template(gCustInvTemplate.bFlag) Then
                        gCustInvTemplate.bFlag = General.modo.SavedRecord
                        Me.Close()
                    End If
                End If
            Case "exit"
                Me.Close()
        End Select

    End Sub
	
	Private Function val_fields() As Boolean
		val_fields = False
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(Me.txtDescription.Text) Or Len(txtDescription.Text) <= 0 Then
			MsgBox("Please enter a Description", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtDescription.Focus()
			Exit Function
		End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(Me.txtTemplateName.Text) Or Len(txtTemplateName.Text) <= 0 Then
			MsgBox("Please enter a name for this template.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtTemplateName.Focus()
			Exit Function
		End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(Me.txtFilename.Text) Or Len(txtFilename.Text) <= 0 Then
			MsgBox("Please enter a Word doc to use as Template", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtFilename.Focus()
			Exit Function
		End If
		
		val_fields = True
	End Function
	Private Function save_template(ByRef bOption As General.modo) As Boolean
        Dim nRecords As Object = New Object()
        Dim nRecord As Short = -1
		Dim nTemplateId As Short
		
		save_template = False
		
		Select Case bOption
			Case General.modo.NewRecord
				
				nTemplateId = get_next_seq("CustomerInvoiceTemplate", "template_id")
				
                sStmt = "INSERT INTO CustomerInvoiceTemplate (template_id, template_name," & "    description, filename) " & _
                        " VALUES (@template_id, @templateName, @description, @filename)"
				
                cm = cn.CreateCommand
				
                create_param_rs("@template_id", SqlDbType.Int, ParameterDirection.Input, nTemplateId, cm, 6)
                create_param_rs("@templateName", SqlDbType.VarChar, ParameterDirection.Input, quotation_mask(Trim(txtTemplateName.Text)), cm, 100)
                create_param_rs("@description", SqlDbType.VarChar, ParameterDirection.Input, quotation_mask(Trim(txtDescription.Text)), cm, 200)
                create_param_rs("@filename", SqlDbType.VarChar, ParameterDirection.Input, quotation_mask(Trim(txtFilename.Text)), cm, 250)



                cm.CommandType = CommandType.Text
                cm.CommandText = sStmt

                nRecords = cm.ExecuteNonQuery()
                'UPGRADE_WARNING: Couldn't resolve default property of object nRecords. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If nRecords > 0 Then
                    'ok
                    gCustInvTemplate.nTemplateId = nTemplateId
                    save_template = True
                    MsgBox("Template was inserted successfully.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
                Else
                    save_template = False
                    MsgBox("Failed to insert in Template table. " & vbCrLf & "Review logfile for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
                    Me.Close()
                End If

            Case General.modo.UpdateRecord
                sStmt = "UPDATE CustomerInvoiceTemplate " & _
                        " SET template_name = @templateName, description = @description, filename = @filename " & _
                        " WHERE template_id  = @template_id "

                cm = cn.CreateCommand

                create_param_rs("@templateName", SqlDbType.VarChar, ParameterDirection.Input, quotation_mask(Trim(txtTemplateName.Text)), cm, 100)
                create_param_rs("@description", SqlDbType.VarChar, ParameterDirection.Input, quotation_mask(Trim(txtDescription.Text)), cm, 200)
                create_param_rs("@filename", SqlDbType.VarChar, ParameterDirection.Input, quotation_mask(Trim(txtFilename.Text)), cm, 250)
                create_param_rs("@template_id", SqlDbType.Int, ParameterDirection.Input, gCustInvTemplate.nTemplateId, cm, 6)

                'cm = cn.CreateCommand '.let_ActiveConnection(cn)
                cm.CommandType = CommandType.Text
                cm.CommandText = sStmt

                nRecords = cm.ExecuteNonQuery()
                'UPGRADE_WARNING: Couldn't resolve default property of object nRecords. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If nRecords > 0 Then
                    'ok

                    save_template = True
                    MsgBox("Template was updated successfully.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
                Else
                    save_template = False
                    MsgBox("Failed to insert in Template table. " & vbCrLf & "Review logfile for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
                    Me.Close()
                End If

        End Select
	End Function

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        If val_fields() Then
            If save_template(gCustInvTemplate.bFlag) Then
                gCustInvTemplate.bFlag = General.modo.SavedRecord
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub
End Class