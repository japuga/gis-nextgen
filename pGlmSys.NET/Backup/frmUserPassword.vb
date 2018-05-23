Option Strict Off
Option Explicit On
Friend Class frmUserPassword
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If val_fields Then
			update_password()
			Me.Close()
		End If
	End Sub
	Private Function val_fields() As Boolean
		val_fields = True
		'Len
		If Len(txtPassword.Text) > 0 Then
			'ok
		Else
			MsgBox("Please enter new password")
			txtPassword.Focus()
			val_fields = False
			Exit Function
		End If
		
		'Same
		If txtPassword.Text = txtConfirm.Text Then
			'ok
		Else
			MsgBox("Password entries did not match.", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Warning")
			val_fields = False
			txtPassword.Focus()
			Exit Function
		End If
	End Function
	Private Sub update_password()
        Try

            cm = cn.CreateCommand
            cm.CommandType = CommandType.StoredProcedure
            cm.CommandText = "usp_sys_change_password"

            'cm.Parameters("@sUserName").Value = Trim(gUserRecord.sUserName)
            cm.Parameters.AddWithValue("@sUserName", Trim(gUserRecord.sUserName))

            'cm.Parameters("@sPassword").Value = Trim(txtPassword.Text)
            cm.Parameters.AddWithValue("@sPassword", Trim(txtPassword.Text))

            cm.Parameters.Add("@nResult", SqlDbType.Int)
            cm.Parameters("@nResult").Direction = ParameterDirection.Output

            cm.ExecuteNonQuery()
            If cm.Parameters("@nResult").Value = 0 Then
                MsgBox("Password was successfully updated.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
            Else
                MsgBox("Failed to update password.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            End If
            Exit Sub


        Catch e As Exception

            MsgBox("Failed to update Password." & vbCrLf & "Just SqlServer Administrators are allowed to update passwords." & vbCrLf & "SqlServer message:" & e.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            save_error(Me.Name, "update_password")
            Exit Sub

            save_error(Me.Name, "update_password")
            MsgBox("An unexpected error ocurred when updating SqlServer password." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
        End Try
    End Sub
	Private Sub frmUserPassword_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		'UPGRADE_WARNING: TextBox property txtPassword.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtPassword.Maxlength = 10
		'UPGRADE_WARNING: TextBox property txtConfirm.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtConfirm.Maxlength = 10
	End Sub
End Class