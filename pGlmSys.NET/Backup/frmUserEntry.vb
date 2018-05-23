Option Strict Off
Option Explicit On
Friend Class frmUserEntry
	Inherits System.Windows.Forms.Form
	
	'UPGRADE_WARNING: Event cbTypeName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbTypeName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbTypeName.SelectedIndexChanged
		cbTypeId.SelectedIndex = cbTypeName.SelectedIndex
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If val_fields Then
			If save_user Then
				Me.Close()
			End If
		End If
	End Sub
	Private Function val_fields() As Boolean
		
		On Error GoTo ErrorHandler
		
		val_fields = True
		
		If Len(txtUserName.Text) = 0 Then
			MsgBox("User ID is required.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
			txtUserName.Focus()
			val_fields = False
			Exit Function
		Else
			'Verificar que no se repita
			If gUserRecord.bFlag = General.modo.NewRecord Then
				sStmt = "SELECT suser_name FROM suser " & "WHERE suser_name = '" & Trim(txtUserName.Text) & "'"
				
                rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                If rs.Rows.Count > 0 Then
                    'Repetido
                    val_fields = False
                    MsgBox("User ID already in use. Choose another.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                    Exit Function
                Else
                    'ok
                End If
            End If
        End If
			


            If Len(txtUserDesc.Text) = 0 Then
                MsgBox("User Description is required.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                txtUserDesc.Focus()
                val_fields = False
                Exit Function
            End If
            Exit Function

            If CDbl(cbTypeId.Text) >= 0 Then
                'ok
            Else
                MsgBox("Please select User Type.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                cbTypeId.Focus()
                val_fields = False
                Exit Function
            End If

ErrorHandler:
            save_error(Me.Name, "val_fields")
            MsgBox("Failed to validate User info. Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
		
	End Function
	Private Function save_user() As Boolean
		Dim nRecords As Short
		Dim bInserted As Boolean
		
		On Error GoTo ErrorHandler
		
		bInserted = False
        cm = cn.CreateCommand '.let_ActiveConnection(cn)
        cm.CommandType = CommandType.Text
		save_user = False
		Select Case gUserRecord.bFlag
			Case General.modo.NewRecord
				
				sStmt = "INSERT INTO suser (suser_name, " & "suser_desc, type_id ) VALUES (" & "'" & Trim(quotation_mask(txtUserName.Text)) & "'," & "'" & Trim(quotation_mask(txtUserDesc.Text)) & "'," & "'" & cbTypeId.Text & "')"
				cm.CommandText = sStmt
                nRecords = cm.ExecuteNonQuery()
				If nRecords > 0 Then
					'ok
					bInserted = True
					'Agregar usuario a SqlServer
                    cm.CommandType = CommandType.StoredProcedure
					cm.CommandText = "usp_sys_create_user"

                    'agregar parametros

                    'cm.Parameters("@sUserName").Value = Trim(txtUserName.Text)
                    cm.Parameters.AddWithValue("@sUserName", Trim(txtUserName.Text))
                    'cm.Parameters("@sPassword").Value = Trim(txtUserName.Text)
                    cm.Parameters.AddWithValue("@sPassword", Trim(txtUserName.Text))
					
                    'cm.Parameters("@sDatabase").Value = gsDatabase
                    cm.Parameters.AddWithValue("@sDatabase", gsDatabase)

                    cm.Parameters.Add("@nResult", SqlDbType.Int, 10)
                    cm.Parameters("@nResult").Direction = ParameterDirection.Output

                    cm.ExecuteNonQuery()
					If cm.Parameters("@nResult").Value = 0 Then
						'ok
						gUserRecord.bFlag = General.modo.SavedRecord
						save_user = True
						MsgBox("User was succesfully inserted", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
					Else
						'Rollback
						If bInserted = True Then
							
							sStmt = "DELETE FROM suser " & "WHERE suser_name='" & Trim(txtUserName.Text) & "'"
                            cm.CommandType = CommandType.Text
							cm.CommandText = sStmt
                            nRecords = cm.ExecuteNonQuery()
							If nRecords > 0 Then
								'removed ok
							Else
								MsgBox("Failed to rollback work." & vbCrLf & "User " & Trim(txtUserName.Text) & "must be removed manually.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
							End If
						End If
						'error
						MsgBox("Failed to create SqlServer login." & vbCrLf & "Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Error")
					End If
				Else
					MsgBox("Failed to insert User record." & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Message")
					Exit Function
				End If
			Case General.modo.UpdateRecord
				sStmt = "UPDATE suser " & "SET suser_desc='" & Trim(quotation_mask(txtUserDesc.Text)) & "', " & " type_id = '" & cbTypeId.Text & "' " & " WHERE suser_name ='" & Trim(txtUserName.Text) & "'"
				cm.CommandText = sStmt
                nRecords = cm.ExecuteNonQuery()
				If nRecords > 0 Then
					'ok
					gUserRecord.bFlag = General.modo.SavedRecord
					save_user = True
					MsgBox("User was succesfully updated")
				Else
					MsgBox("Failed to update User record." & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Message")
					Exit Function
				End If
		End Select
		
		Exit Function
		
ErrorHandler: 
		save_user = False
		save_error(Me.Name, "save_user")
		
		If Not show_db_error Then
			MsgBox("Unexpected when inserting User info. Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
		End If
		
		'Rollback para insercion
		If bInserted = True Then
			sStmt = "DELETE FROM suser " & "WHERE suser_name='" & Trim(txtUserName.Text) & "'"
            cm.CommandType = CommandType.Text
			cm.CommandText = sStmt
            nRecords = cm.ExecuteNonQuery()
			If nRecords > 0 Then
				'removed ok
			Else
				MsgBox("Failed to rollback work." & vbCrLf & "User " & Trim(txtUserName.Text) & "must be removed manually.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
			End If
		End If
		
		
	End Function
	
	Private Sub cmdPassword_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPassword.Click
		VB6.ShowForm(frmUserPassword, VB6.FormShowConstants.Modal, Me)
		
	End Sub
	
	Private Sub frmUserEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		set_limits()
		init_vars()
	End Sub
	Private Sub init_vars()
		'User Type Class
		sStmt = "SELECT type_id, type_name FROM suser_type " & " ORDER BY type_name "
		load_cb_query2(cbTypeId, sStmt, 1, True)
		
		sStmt = "SELECT type_name, type_id FROM suser_type " & " ORDER BY type_name "
		load_cb_query2(cbTypeName, sStmt, 1, True)
		
		If cbTypeName.Items.Count > 0 Then
			cbTypeName.SelectedIndex = 0
		End If
		
		Select Case gUserRecord.bFlag
			Case General.modo.NewRecord
			Case General.modo.UpdateRecord
				txtUserName.Enabled = False
				txtUserName.Text = gUserRecord.sUserName
				txtUserDesc.Text = gUserRecord.sUserDesc
				
				set_cb(cbTypeId, gUserRecord.sTypeId)
				cbTypeName.SelectedIndex = cbTypeId.SelectedIndex
		End Select
	End Sub
	
	Private Sub set_limits()
        txtUserName.MaxLength = 10
        txtUserDesc.MaxLength = 50
	End Sub
End Class