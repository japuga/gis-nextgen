Option Strict Off
Option Explicit On
Friend Class frmServiceGroupEntry
	Inherits System.Windows.Forms.Form
    Dim rsLocal As DataTable
    Dim nServGroupId As Short
    Private ImageList2 As New ImageList()
	
	
	
	Private Sub cmdDetails_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDetails.Click
		set_grid_selector()
		VB6.ShowForm(tplGridSelector2, VB6.FormShowConstants.Modal, Me)
		
		
	End Sub
	
	Private Sub set_grid_selector()
		
		clear_gItplGridSelector()
		
		'Init
		gItplGridSelector.sQueryInit = build_query_init
		'Left
		gItplGridSelector.sQuerySource = build_query_left
		
		'Right
		gItplGridSelector.sQuerySelected = build_query_right
		
		gItplGridSelector.sOrderBy = "Name"
		
		
		'Formato
		gItplGridSelector.aFields(0).sFieldName = "serv_id"
		gItplGridSelector.aFields(0).bVisible = False
		gItplGridSelector.aFields(0).nWidth = 100
		
		gItplGridSelector.aFields(1).sFieldName = "Name"
		gItplGridSelector.aFields(1).bVisible = True
		gItplGridSelector.aFields(1).nWidth = 3000
		
		gItplGridSelector.sLeftCaption = "Services"
		gItplGridSelector.sRightCaption = "Selected Services"
		
		
	End Sub
	Private Function build_query_left() As String
		build_query_left = " SELECT serv_id, serv_desc AS Name " & " FROM service " & " WHERE serv_id NOT IN " & " (SELECT a.serv_id " & " FROM ServiceGroupDet a" & " WHERE a.serv_group_id = " & Str(nServGroupId) & ")" & " ORDER BY serv_desc "
		
	End Function
	Private Function build_query_right() As String
		build_query_right = " SELECT a.serv_id, " & " b.serv_desc AS Name " & " FROM ServiceGroupDet a, Service  b " & " WHERE a.serv_id  = b.serv_id " & " AND a.serv_group_id = " & Str(nServGroupId) & " ORDER BY serv_desc "
		
	End Function
	Private Function build_query_init() As String
		build_query_init = " SELECT a.serv_id, " & " b.serv_desc AS Name " & " FROM ServiceGroupDet a, Service  b " & " WHERE a.serv_id  = b.serv_id " & " AND a.serv_group_id = -1" & " ORDER BY serv_desc "
		
		
	End Function
	
	Private Sub frmServiceGroupEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		
		Dim domain_field As String
		
		
        rsLocal = Nothing
		
		
		
		
		domain_field = "serv_group_system_generated"
		
		
		sStmt = "SELECT field_option FROM sdomain " & " WHERE domain_field ='" & domain_field & "'"
		
		load_cb_query2(cbSystemGenerated, sStmt, 1, True)
		
		If cbSystemGenerated.Items.Count > 0 Then
			cbSystemGenerated.SelectedIndex = 0
		End If
		
		Select Case gServiceGroupRecord.bFlag
			Case General.modo.NewRecord
				nServGroupId = 0
				cmdDetails.Enabled = False
			Case General.modo.UpdateRecord
				nServGroupId = gServiceGroupRecord.nServGroupId
				txtServGroupName.Text = gServiceGroupRecord.sServGroupName
				txtServGroupDesc.Text = gServiceGroupRecord.sServGroupDesc
				set_cb(cbSystemGenerated, gServiceGroupRecord.sSystemGenerated)
		End Select
		
		
		
		load_dgServices()
		
	End Sub
	
	'Loads datagrid with available Group services
	Private Sub load_dgServices()
		'On Error GoTo ErrorHandler
		
		sStmt = " SELECT a.serv_id, " & " b.serv_desc AS Name " & " FROM ServiceGroupDet a, Service  b " & " WHERE a.serv_id  = b.serv_id " & " AND a.serv_group_id = " & Str(nServGroupId) & " ORDER BY serv_desc "
		
		MsgBox(sStmt)

        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsLocal.Rows.Count > 0 Then
            dgServices.DataSource = rsLocal
            'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            dgServices.Refresh()
            If rsLocal.Rows.Count > 0 Then

            End If
        Else
            'UPGRADE_NOTE: Object dgServices.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            dgServices.DataSource = Nothing
            Exit Sub
        End If



        'Formatting datagrid
        dgServices.Columns("serv_id").Visible = False
        dgServices.Columns("Name").Width = VB6.TwipsToPixelsX(3000)

        Exit Sub
ErrorHandler:
        save_error(Me.Name, "load_dgServices")
        MsgBox("Error during Group services loading. Check logfile for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
    End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)

        Select Case Button.Name
            Case "save"
                If val_fields() Then
                    If save_record() Then
                        If Not cmdDetails.Enabled Then
                            cmdDetails.Enabled = True
                        End If
                    End If
                End If
            Case "exit"
                Me.Close()
        End Select
    End Sub
	Private Function val_fields() As Boolean
		
		val_fields = False
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtServGroupName.Text) Then
			MsgBox("Please enter Group Name", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtServGroupName.Focus()
			Exit Function
		ElseIf Len(txtServGroupName.Text) <= 0 Then 
			MsgBox("Please enter Group Name", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtServGroupName.Focus()
			Exit Function
			
		End If
		
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtServGroupDesc.Text) Then
			MsgBox("Please enter Group Description", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtServGroupDesc.Focus()
			Exit Function
		ElseIf Len(txtServGroupDesc.Text) <= 0 Then 
			MsgBox("Please enter Group Description", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtServGroupDesc.Focus()
			Exit Function
			
		End If
		
		
		
		If cbSystemGenerated.SelectedIndex < 0 Then
			MsgBox("Please select if flag is System Generated or Not.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
			Exit Function
		End If
		
		val_fields = True
		Exit Function
		
		
		
		
		
	End Function
	Private Function save_record() As Boolean
		
		
		save_record = False
		
		sStmt = "SELECT MAX(serv_group_id) FROM ServiceGroup "
		
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count <= 0 Then
            nServGroupId = 1
        Else
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item(0).Value) Then
                nServGroupId = 1
            Else
                nServGroupId = rsLocal.Rows(0).Item(0).Value + 1
            End If

        End If


        sStmt = "INSERT INTO ServiceGroup(serv_group_id, serv_group_name," & " serv_group_desc, system_generated) " & " VALUES(" & Str(nServGroupId) & ",'" & txtServGroupName.Text & "'," & "'" & txtServGroupDesc.Text & "','" & cbSystemGenerated.Text & "')"


        cm = cn.CreateCommand
        cm.CommandType = CommandType.Text
        cm.CommandText = sStmt
        
        Dim nRecords As Short

        nRecords = cm.ExecuteNonQuery()
        If nRecords > 0 Then
            MsgBox("Service Group was created successfully", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
            save_record = True
            Exit Function
        Else
            MsgBox("Failed to insert Service Group info. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")

        End If
		
		
		
	End Function
End Class