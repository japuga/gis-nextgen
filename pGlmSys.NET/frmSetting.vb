Option Strict Off
Option Explicit On
Friend Class frmSetting
    Inherits System.Windows.Forms.Form
    Private ImageList2 As New ImageList()
	
	
	Private Sub frmSetting_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		
		'UPGRADE_WARNING: TextBox property txtReportDir.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtReportDir.Maxlength = 100
		'UPGRADE_WARNING: TextBox property txtCheckLogoFile.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtCheckLogoFile.Maxlength = 100
		'UPGRADE_WARNING: TextBox property txtMaxBatchCheckDetails.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtMaxBatchCheckDetails.Maxlength = 2
		
		
		sStmt = "SELECT field_option FROM SDomain " & " WHERE domain_field='fields_from_db' " & " ORDER BY option_order "
		load_cb_query2(cbFieldsFromDb, sStmt, 1, True)
		
		sStmt = "SELECT field_option FROM SDomain " & " WHERE domain_field='check_paper_source' " & " ORDER BY option_order "
		load_cb_query2(cbCheckPaperSource, sStmt, 1, True)
		
		'Debug Flag
		sStmt = "SELECT field_option FROM SDomain " & " WHERE domain_field='debug_flag' " & " ORDER BY option_order "
		load_cb_query2(cbDebugFlag, sStmt, 1, True)
		
		load_fields()
		
		txtWordTemplate.Enabled = False
		txtWordTemplate.ReadOnly = True
		
	End Sub
	
	Private Sub load_fields()
		On Error GoTo ErrorHandler
		
		sStmt = "SELECT fields_from_db, report_dir, " & "check_logo_file, max_batch_check_details, " & "check_paper_source, debug_flag, web_report_build_url  " & " FROM SSetting "
		
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.Rows.Count > 0 Then
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item("fields_from_db")) Then
                If cbFieldsFromDb.Items.Count > 0 Then
                    cbFieldsFromDb.SelectedIndex = 0
                End If
            Else
                set_cb(cbFieldsFromDb, Trim(rs.Rows(0).Item("fields_from_db")))
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item("report_dir")) Then
                txtReportDir.Text = ""
            Else
                txtReportDir.Text = rs.Rows(0).Item("report_dir")
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item("check_logo_file")) Then
                txtCheckLogoFile.Text = ""
            Else
                txtCheckLogoFile.Text = rs.Rows(0).Item("check_logo_file")
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item("max_batch_check_details")) Then
                txtMaxBatchCheckDetails.Text = ""
            Else
                txtMaxBatchCheckDetails.Text = rs.Rows(0).Item("max_batch_check_details")
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item("check_paper_source")) Then
                If cbCheckPaperSource.Items.Count > 0 Then
                    cbCheckPaperSource.SelectedIndex = 0
                End If
            Else
                set_cb(cbCheckPaperSource, rs.Rows(0).Item("check_paper_source"))
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item("debug_flag")) Then
                If cbDebugFlag.Items.Count > 0 Then
                    cbDebugFlag.SelectedIndex = 0
                End If
            Else
                set_cb(cbDebugFlag, Trim(rs.Rows(0).Item("debug_flag")))
            End If

            txtWordTemplate.Text = gGlobSettings.sMswordTemplateFile

        End If

        Exit Sub

ErrorHandler:
        save_error(Me.Name, "load_fields")
        MsgBox("Unexpected error occurred while loading Settings.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "save"
                If val_fields() Then
                    save_setting()
                End If
            Case "exit"
                Me.Close()
        End Select
    End Sub
	
	Private Function val_fields() As Boolean
		
		On Error GoTo ErrorHandler
		
		val_fields = False
		'FieldsFromDb
		If cbFieldsFromDb.SelectedIndex < 0 Then
			MsgBox("Please select an option for Fields From DB.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			cbFieldsFromDb.Focus()
			Exit Function
		End If
		
		'Report Dir
		If Len(Trim(txtReportDir.Text)) = 0 Then
			MsgBox("Please enter the Default Report Directory.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtReportDir.Focus()
			Exit Function
		Else
			'Pendiente Validar que el directorio exista
		End If
		
		'CheckLogFile
		If Len(Trim(txtCheckLogoFile.Text)) = 0 Then
			MsgBox("Please enter the Logo filename.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtCheckLogoFile.Focus()
			Exit Function
		Else
			'Pendiente Validar que el archivo exista y sea bmp
		End If
		
		'CheckPaperSource
		If cbCheckPaperSource.SelectedIndex < 0 Then
			MsgBox("Please select an option for Check Paper Source.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			cbCheckPaperSource.Focus()
			Exit Function
		End If
		
		'MaxBatchCheckDetails
		If Len(Trim(txtMaxBatchCheckDetails.Text)) = 0 Then
			MsgBox("Please enter the maximum number of details per Batch Check.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtMaxBatchCheckDetails.Focus()
			Exit Function
		Else
			If Not IsNumeric(txtMaxBatchCheckDetails.Text) Then
				MsgBox("Incorrect value for maximum number " & vbCrLf & "of details per Batch Check", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
				Exit Function
			End If
		End If
		
		'DebugFlag
		If cbDebugFlag.SelectedIndex < 0 Then
			MsgBox("Please select an option for Debug Application.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			cbDebugFlag.Focus()
			Exit Function
		End If
		
		
		val_fields = True
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "val_fields")
		MsgBox("Unexpected error while validating data." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
		
	End Function
	Private Function save_setting() As Boolean
		Dim nRecords As Short
		
		save_setting = False
		
		On Error GoTo ErrorHandler
		
		sStmt = "UPDATE SSetting " & " SET fields_from_db ='" & cbFieldsFromDb.Text & "'," & " report_dir ='" & Trim(txtReportDir.Text) & "'," & " check_logo_file = '" & Trim(txtCheckLogoFile.Text) & "'," & " check_paper_source='" & cbCheckPaperSource.Text & "'," & " max_batch_check_details =" & txtMaxBatchCheckDetails.Text & " , " & " debug_flag ='" & cbDebugFlag.Text & "'"
		
		'MsgBox sStmt
		
        cm = cn.CreateCommand '.let_ActiveConnection(cn)
        cm.CommandType = CommandType.Text
		cm.CommandText = sStmt
        nRecords = cm.ExecuteNonQuery()
		If nRecords > 0 Then
			save_setting = True
			MsgBox("Record was successfully updated." & "You must log off and log in again for your changes to take affect.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
		Else
			MsgBox("Failed to save changes. Try again.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Function
		End If
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "save_setting")
		MsgBox("Unexpected error while saving data." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
	End Function
	
	
	Private Sub txtMaxBatchCheckDetails_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtMaxBatchCheckDetails.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			'Es numero
			'No permitir ingresar mas de 2 decimales
			'If (KeyAscii >= 48 And KeyAscii <= 57) _
			''And max_fraction(txtUnitsDet) _
			''And txtUnitsDet.SelLength = 0 Then
			'    KeyAscii = 0
			'End If
		Else
			KeyAscii = 0
			
		End If
		
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtWebReportURL_KeyPress(ByRef KeyAscii As Short)
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			'Es numero
			'No permitir ingresar mas de 2 decimales
			'If (KeyAscii >= 48 And KeyAscii <= 57) _
			''And max_fraction(txtUnitsDet) _
			''And txtUnitsDet.SelLength = 0 Then
			'    KeyAscii = 0
			'End If
		Else
			KeyAscii = 0
			
		End If
		
		
	End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        If val_fields() Then
            save_setting()
        End If
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub
End Class