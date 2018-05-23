Option Strict Off
Option Explicit On
Friend Class frmInvoicingGroupsEntry
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If val_fields Then
			If save_group Then
				Me.Close()
			End If
		End If
	End Sub
	
	Private Function save_group() As Boolean
        Dim nRecords As Integer = 0
		
		Dim nGroupSeq As Short
		
		save_group = True
		
		Select Case gInvoicingGroup.bModo
			Case General.modo.NewRecord
				
				sStmt = "SELECT MAX(group_seq) FROM VInvoiceGroup "
				
                rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                If IsDBNull(rs.Rows(0).Item(0)) Then
                    nGroupSeq = 1
                Else
                    nGroupSeq = rs.Rows(0).Item(0) + 1
                End If

                sStmt = "INSERT INTO VInvoiceGroup " & " (group_seq, cust_id, group_name, group_status) " & " VALUES (" & Str(nGroupSeq) & "," & "'" & gInvoicingGroup.sCustId & "'," & "'" & Trim(quotation_mask(txtGroupName.Text)) & "'," & "'" & cbGroupStatus.Text & "')"

                cm = cn.CreateCommand '.let_ActiveConnection(cn)
                cm.CommandType = CommandType.Text
                cm.CommandText = sStmt
                nRecords = cm.ExecuteNonQuery()

                If nRecords > 0 Then
                    gInvoicingGroup.bModo = General.modo.SavedRecord
                    MsgBox("Data was successfully saved.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                Else
                    MsgBox("Error while inserting data into database.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                End If
                Exit Function

            Case General.modo.UpdateRecord

                sStmt = "UPDATE VInvoiceGroup " & " SET   group_name='" & Trim(quotation_mask(txtGroupName.Text)) & "'," & " group_status= '" & cbGroupStatus.Text & "' " & " WHERE  group_seq =" & Str(gInvoicingGroup.nGroupSeq)

                cm = cn.CreateCommand '.let_ActiveConnection(cn)
                cm.CommandType = CommandType.Text
                cm.CommandText = sStmt
                nRecords = cm.ExecuteNonQuery()

                'UPGRADE_WARNING: Couldn't resolve default property of object nRecords. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If nRecords > 0 Then
                    gInvoicingGroup.bModo = General.modo.SavedRecord
                    MsgBox("Data was successfully saved.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                Else
                    MsgBox("Error while inserting data into database.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                End If
                Exit Function

        End Select
		
		
		
	End Function
	Private Function val_fields() As Boolean
		
		val_fields = False
		
		If Trim(txtGroupName.Text) = "" Then
			MsgBox("Please enter group name.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtGroupName.Focus()
			Exit Function
		End If
		
		If cbGroupStatus.SelectedIndex < 0 Then
			MsgBox("Please select a valid status for the group.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			cbGroupStatus.Focus()
			Exit Function
		End If
		
		'Check for duplicates
		Select Case gInvoicingGroup.bModo
			Case General.modo.NewRecord
				sStmt = "SELECT group_seq FROM VInvoiceGroup " & " WHERE cust_id='" & gInvoicingGroup.sCustId & "'" & " AND group_name ='" & Trim(quotation_mask(txtGroupName.Text)) & "'"
				
                rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                If rs.Rows.Count > 0 Then
                    'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    If Not IsDBNull(rs.Rows(0).Item("group_seq")) Then
                        If rs.Rows(0).Item("group_seq") > 0 Then
                            MsgBox("Group already exists. Please change name.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                            txtGroupName.Focus()
                            Exit Function
                        End If
                    End If
                End If

        End Select
		
		val_fields = True
	End Function
	Private Sub frmInvoicingGroupsEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		'txtGroupName.MaxLength = 80
		
		
		
		sStmt = " SELECT field_option FROM SDomain " & " WHERE domain_field='group_status' "
		load_cb_query2(cbGroupStatus, sStmt, 1, True)
		
		If cbGroupStatus.Items.Count > 0 Then
			cbGroupStatus.SelectedIndex = 0
		End If
		
		Select Case gInvoicingGroup.bModo
			Case General.modo.NewRecord
				txtGroupName.Text = ""
			Case General.modo.UpdateRecord
				txtGroupName.Text = gInvoicingGroup.sGroupName
				txtGroupName.Enabled = False
				txtGroupName.ReadOnly = True
				set_cb(cbGroupStatus, gInvoicingGroup.sGroupStatus)
		End Select
	End Sub
End Class