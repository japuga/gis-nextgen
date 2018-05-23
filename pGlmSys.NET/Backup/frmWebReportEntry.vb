Option Strict Off
Option Explicit On
Friend Class frmWebReportEntry
    Inherits System.Windows.Forms.Form
    Private ImageList2 As New ImageList()
	
	Private Sub frmWebReportEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		
		sStmt = "SELECT field_option FROM sdomain " & "WHERE domain_field ='web_report_enabled_flag' ORDER BY option_order "
		load_cb_query2(cbEnabledFlag, sStmt, 1, True)
		
		
		Select Case gWebReport.bFlag
			Case General.modo.NewRecord
			Case General.modo.UpdateRecord
				txtTableName.Enabled = False
				txtReportDesc.Enabled = False
				txtTableName.Text = gWebReport.tableName
				txtReportDesc.Text = gWebReport.reportDesc
				
				set_cb(cbEnabledFlag, gWebReport.enabledFlag)
				
				
		End Select
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button4.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)

        Select Case Button.Name
            Case "save"
                If saveWebReport() Then
                    Me.Close()
                End If

            Case "exit"
                Me.Close()
        End Select
    End Sub
	
	Private Function saveWebReport() As Boolean
		
		Dim sEnabled As String
		Dim nResult As Short
		
		saveWebReport = False
		
		If cbEnabledFlag.Text = "TRUE" Then
			sEnabled = "1"
		Else
			sEnabled = "0"
		End If
		
		sStmt = "UPDATE web_report SET enabled_flag = " & sEnabled & " WHERE web_report_id = " & Str(gWebReport.webReportId)
		
        cm = cn.CreateCommand '.let_ActiveConnection(cn)
        cm.CommandType = CommandType.Text
		cm.CommandText = sStmt
        nResult = cm.ExecuteNonQuery()
		If nResult > 0 Then
			gWebReport.bFlag = General.modo.SavedRecord
			MsgBox("Record was successfully updated.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
			saveWebReport = True
		Else
			MsgBox("Unable to update record. Check log file for details", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Error")
		End If
	End Function

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        If saveWebReport() Then
            Me.Close()
        End If
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub
End Class