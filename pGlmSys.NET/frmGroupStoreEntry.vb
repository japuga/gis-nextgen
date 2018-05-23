Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmGroupStoreEntry
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private rsStore As DataTable
    Private rsMember As DataTable
    Private cmLocal As SqlCommand
    Private bNewRecord As Boolean
	
	
	
	Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click
		add_dgGroupStore(gGroupsRecord.sTypeId)
	End Sub
	
	Private Sub cmdFilter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFilter.Click
		VB6.ShowForm(frmStoreSearchCriteria, VB6.FormShowConstants.Modal, Me)
		load_dgStore(GROUP_LOCAL, gDump.str1)
	End Sub
	
	Private Sub cmdRemove_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRemove.Click
		del_dgGroupStore(gGroupsRecord.sTypeId)
		
	End Sub
	
	Private Sub cmdShowAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdShowAll.Click
		load_dgStore(GROUP_LOCAL, "")
		
	End Sub
	
    Private Sub dgGroupStore_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'dgGroupStore.SelBookmarks.Add rsMember.Bookmark

    End Sub
	
    Private Sub dgGroupStore_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        del_dgGroupStore(gGroupsRecord.sTypeId)
    End Sub
	
    Private Sub dgStores_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        add_dgGroupStore(gGroupsRecord.sTypeId)
    End Sub
	
	Private Sub frmGroupStoreEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        init_vars()
	End Sub
	
	Private Sub init_vars()
		
        cmLocal = cn.CreateCommand()

        'init fields
        txtAttention.Text = ""
        txtContractNo.Text = ""
        txtText.Text = ""
		
		'Restrictions
		'UPGRADE_WARNING: TextBox property txtGroupName.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtGroupName.Maxlength = 30
        'rsStore.maxRecords = MAX_RECORDS
        'rsStore.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rsMember.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		'UPGRADE_WARNING: TextBox property txtAttention.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtAttention.Maxlength = 100
		'UPGRADE_WARNING: TextBox property txtContractNo.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtContractNo.Maxlength = 50
		'UPGRADE_WARNING: TextBox property txtText.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtText.Maxlength = 512
		
        DataGridView1.Font = New Font("Arial", 8)
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        DataGridView2.Font = New Font("Arial", 8)
        DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
		
		
		
		'Group Types
		sStmt = "SELECT type_id, sort_id FROM GrpType ORDER BY sort_id"
		load_cb_query2(cbTypeId, sStmt, 1, True)
		
		
		'Load rsStore
		Select Case gGroupsRecord.sTypeId
			Case GROUP_LOCAL
				cmdFilter.Enabled = True
				cmdShowAll.Enabled = True
				
				load_dgStore(GROUP_LOCAL, "")
				
			Case GROUP_AREA
				cmdFilter.Enabled = False
				cmdShowAll.Enabled = False
				
				load_dgStore(GROUP_AREA, "")
			Case GROUP_DISTRICT
				cmdFilter.Enabled = False
				cmdShowAll.Enabled = False
				
				load_dgStore(GROUP_DISTRICT, "")
			Case GROUP_REGION
				cmdFilter.Enabled = False
				cmdShowAll.Enabled = False
				
				load_dgStore(GROUP_REGION, "")
				
		End Select
		
		
		
		txtCustName.Enabled = False
		txtCustName.Text = gGroupsRecord.sCustName
		
		cbTypeId.Enabled = False
		set_cb(cbTypeId, gGroupsRecord.sTypeId)
		
		Select Case gGroupsRecord.bFlag
			Case General.modo.NewRecord
				
				load_dgGroupStore(gGroupsRecord.sTypeId, gGroupsRecord.sCustId, -1)
                txtGroupName.Enabled = True
                txtGroupName.Text = ""
				bNewRecord = True
			Case General.modo.UpdateRecord
				txtGroupName.Enabled = False
				txtGroupName.Text = gGroupsRecord.sGroupName
				txtAttention.Text = gGroupsRecord.sAttention
				txtContractNo.Text = gGroupsRecord.sContractNo
				txtText.Text = gGroupsRecord.sText
				
				
				load_dgGroupStore(gGroupsRecord.sTypeId, gGroupsRecord.sCustId, gGroupsRecord.nGroupSeq)
				bNewRecord = False
		End Select
	End Sub
	'Loads dgStores with list of candidate Group members
	Private Sub load_dgStore(ByRef sType As String, ByRef sCriteria As String)
		
		On Error GoTo ErrorHandler
		
		'1.Build query of candidates
		Select Case sType
			Case GROUP_LOCAL
				sStmt = "SELECT store.store_id, store.store_number 'Store', " & "store.store_name AS 'Name', store.state_id AS State, " & " store.store_address AS 'Address' " & " FROM store " & " WHERE cust_id ='" & gGroupsRecord.sCustId & "' "
				
				If Len(sCriteria) > 0 Then
					sStmt = sStmt & sCriteria
					'MsgBox sStmt
				End If
				
				sStmt = sStmt & " ORDER BY store.store_number "
				
			Case GROUP_AREA
				sStmt = "SELECT a.group_seq AS group_seq, group_name AS Name " & " FROM groups a, grpType b " & " WHERE a.type_id = b.child_type_id " & " AND a.cust_id = '" & gGroupsRecord.sCustId & "' " & " AND b.type_id = '" & sType & "' "
				
				
			Case GROUP_DISTRICT
				sStmt = "SELECT a.group_seq AS area_seq, group_name AS Name " & " FROM groups a, grpType b " & " WHERE a.type_id = b.child_type_id " & " AND a.cust_id = '" & gGroupsRecord.sCustId & "' " & " AND b.type_id = '" & sType & "' "
				
			Case GROUP_REGION
				sStmt = "SELECT a.group_seq AS district_seq, group_name AS Name " & " FROM groups a, grpType b " & " WHERE a.type_id = b.child_type_id " & " AND a.cust_id = '" & gGroupsRecord.sCustId & "' " & " AND b.type_id = '" & sType & "' "
				
			Case Else
				Exit Sub
		End Select
		
		'2.Execute query and load rsStores
        rsStore = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)
        If rsStore.Rows.Count > 0 Then
            dgStores.DataSource = rsStore
            If rsStore.Rows.Count >= MAX_RECORDS Then
                lbMessage.Text = "Just the first " & Str(MAX_RECORDS) & " Candidates were returned."
            Else
                lbMessage.Text = ""
            End If
        End If
		
		
		'3.Format
		Select Case sType
			Case GROUP_LOCAL
				
				dgStores.Columns("store_id").Visible = False
				dgStores.Columns("name").Width = VB6.TwipsToPixelsX(800)
				dgStores.Columns("store").Width = VB6.TwipsToPixelsX(800)
				dgStores.Columns("address").Width = VB6.TwipsToPixelsX(1400)
				dgStores.Columns("state").Width = VB6.TwipsToPixelsX(500)
				
			Case GROUP_AREA
				
				dgStores.Columns("group_seq").Visible = False
				dgStores.Columns("Name").Width = VB6.TwipsToPixelsX(1200)
				
			Case GROUP_DISTRICT
				dgStores.Columns("area_seq").Visible = False
				dgStores.Columns("Name").Width = VB6.TwipsToPixelsX(1200)
				
			Case GROUP_REGION
				dgStores.Columns("district_seq").Visible = False
				dgStores.Columns("Name").Width = VB6.TwipsToPixelsX(1200)
				
		End Select
		
		Exit Sub
		
		
		
		
ErrorHandler: 
		save_error(Me.Name, "load_dgStore")
		MsgBox("Failed to return Store info. Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
		
		
	End Sub
	Private Sub load_dgGroupStore(ByRef sType As String, ByRef sCustId As String, ByRef nGroupSeq As Short)
		
		On Error GoTo ErrorHandler
		
		Select Case sType
			Case GROUP_LOCAL
				sStmt = "SELECT store.store_id, store.store_number 'Store', " & "store.store_name AS 'Name', store.state_id AS State, " & " store.store_address AS 'Address' " & " FROM store, groupStore " & " WHERE groupStore.cust_id = store.cust_id " & " AND groupStore.store_id = store.store_id " & " AND groupStore.cust_id ='" & sCustId & "' " & " AND groupStore.group_seq =" & Str(nGroupSeq)
				'" ORDER BY store.store_number "
				
				
				
			Case GROUP_AREA
				'sStmt = "SELECT a.group_seq, a.group_name AS 'Name' " + _
				'" FROM groups a, grpType b " + _
				'" WHERE a.type_id = b.child_type_id " + _
				'" AND b.type_id = '" + sType + "' " + _
				'" AND a.cust_id = '" + sCustId + "' " + _
				'" ORDER BY a.group_name "
				sStmt = "SELECT b.group_seq AS group_seq, c.group_name AS 'Name' " & " FROM Groups AS Area, AreaDet b, Groups c " & " WHERE Area.cust_id = '" & sCustId & "' " & " AND Area.group_seq = " & Str(nGroupSeq) & " AND Area.type_id = '" & sType & "' " & " AND Area.group_seq = b.area_seq " & " AND b.group_seq = c.group_seq " & " AND c.cust_id = Area.cust_id "
				
				
				
			Case GROUP_DISTRICT
				sStmt = "SELECT b.area_seq AS area_seq, c.group_name AS 'Name' " & " FROM Groups AS District, DistrictDet b, Groups c " & " WHERE District.cust_id = '" & sCustId & "' " & " AND District.group_seq = " & Str(nGroupSeq) & " AND District.type_id = '" & sType & "' " & " AND District.group_seq = b.district_seq " & " AND b.area_seq = c.group_seq " & " AND c.cust_id = District.cust_id "
				
			Case GROUP_REGION
				sStmt = "SELECT b.district_seq AS district_seq, c.group_name AS 'Name' " & " FROM Groups AS Region, RegionDet b, Groups c " & " WHERE Region.cust_id = '" & sCustId & "' " & " AND Region.group_seq = " & Str(nGroupSeq) & " AND Region.type_id = '" & sType & "' " & " AND Region.group_seq = b.region_seq " & " AND b.district_seq = c.group_seq " & " AND c.cust_id = Region.cust_id "
				
			Case Else
				write_msg("load_dgGroupStore", "Invalid parameter sType:" & sType)
				Exit Sub
		End Select
		
		
		'2.Execute query
        rsMember = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)
        dgGroupStore.DataSource = rsMember
        'If rsMember.rows.count > 0 Then
        '    dgGroupStore.DataSource = rsMember
        'End If
		
		
		
		'3.Format
		Select Case sType
			Case GROUP_LOCAL
				'Formato
				dgGroupStore.Columns("store_id").Visible = False
				dgGroupStore.Columns("name").Width = VB6.TwipsToPixelsX(800)
				dgGroupStore.Columns("store").Width = VB6.TwipsToPixelsX(800)
				dgGroupStore.Columns("address").Width = VB6.TwipsToPixelsX(1400)
				dgGroupStore.Columns("state").Width = VB6.TwipsToPixelsX(500)
				
			Case GROUP_AREA
				'Formato
				dgGroupStore.Columns("group_seq").Visible = False
				dgGroupStore.Columns("Name").Width = VB6.TwipsToPixelsX(1200)
				
			Case GROUP_DISTRICT
				dgGroupStore.Columns("area_seq").Visible = False
				dgGroupStore.Columns("Name").Width = VB6.TwipsToPixelsX(1200)
				
			Case GROUP_REGION
				dgGroupStore.Columns("district_seq").Visible = False
				dgGroupStore.Columns("Name").Width = VB6.TwipsToPixelsX(1200)
				
		End Select
		
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_dgGroupStore")
		MsgBox("Failed to return Group Details. Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Warning")
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button2.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "save"
                If val_fields() Then
                    save_group_store()
                    Me.Close()
                End If

            Case "exit"
                If gGroupsRecord.bFlag <> General.modo.SavedRecord And bNewRecord = False Then
                    If (MsgBox("Do you want to save your changes?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "GLM Message") = MsgBoxResult.Yes) Then
                        If val_fields() Then
                            save_group_store()
                        End If
                    End If
                End If
                Me.Close()
        End Select
    End Sub
	Private Function val_fields() As Boolean
		On Error GoTo ErrorHandler
		
		val_fields = False
		
		'GroupName
		If Len(txtGroupName.Text) <= 0 Then
			MsgBox("Please enter a group name.")
			txtGroupName.Focus()
			Exit Function
		End If
		
		
		'Verify that group is not duplicate
		
		sStmt = "SELECT group_seq FROM Groups " & " WHERE cust_id ='" & Trim(gGroupsRecord.sCustId) & "' " & " AND group_name ='" & Trim(quotation_mask((txtGroupName.Text))) & "'"
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count > 0 And gGroupsRecord.bFlag = General.modo.NewRecord Then
            'val_fields = False
            MsgBox("Group Name already used.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
            txtGroupName.Focus()
            Exit Function

        End If



        val_fields = True
        Exit Function

ErrorHandler:
        val_fields = False
        save_error(Me.Name, "val_fields")
        MsgBox("Unexpected error. Review log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
		
	End Function
	
	Private Sub save_group_store()
		Dim nRecords As Short
		Dim nGroupSeq As Short
        Dim nTran As SqlTransaction
		On Error GoTo ErrorHandler
		
		If Len(txtGroupName.Text) <= 0 Then
			MsgBox("Please enter a group name.")
			txtGroupName.Focus()
			Exit Sub
		End If
		
        'Recordset vacio
        cmLocal = cn.CreateCommand
        cmLocal.CommandType = CommandType.Text

        General.bcnStatus = General.cnStatus.NoTrans
		
		Select Case gGroupsRecord.bFlag
			Case General.modo.NewRecord
				'Nuevo numero de secuencia GroupSeq
				sStmt = "SELECT MAX(group_seq) FROM Groups "
				
                rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rsLocal.Rows.Count > 0 Then
                    If IsDBNull(rsLocal.Rows(0).Item(0)) Then
                        nGroupSeq = 1
                    End If
                    If rsLocal.Rows(0).Item(0) = 0 Then
                        nGroupSeq = 1
                    End If
                    If rsLocal.Rows(0).Item(0) > 0 Then
                        nGroupSeq = rsLocal.Rows(0).Item(0) + 1
                    End If
                Else
                    MsgBox("Unable to find next group sequence number." & "Check log file for details.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Sub
                End If
				
				'Header
                nTran = cn.BeginTransaction()
                General.bcnStatus = General.cnStatus.BeginTrans

                sStmt = "INSERT INTO groups(cust_id, group_seq, group_name, type_id," & " cinvoice_attention, cinvoice_contract_no, cinvoice_text) " & " VALUES ('" & Trim(gGroupsRecord.sCustId) & "'," & " " & Str(nGroupSeq) & " ," & "'" & quotation_mask((txtGroupName.Text)) & "', " & "'" & gGroupsRecord.sTypeId & "'," & "'" & quotation_mask(Trim(txtAttention.Text)) & "'," & "'" & quotation_mask(Trim(txtContractNo.Text)) & "'," & "'" & quotation_mask(Trim(txtText.Text)) & "')"


                cmLocal.CommandText = sStmt
                cmLocal.Transaction = nTran
                nRecords = cmLocal.ExecuteNonQuery()
                If nRecords > 0 Then
                    'ok
                    gGroupsRecord.nGroupSeq = nGroupSeq
                Else
                    nTran.Rollback()
                    MsgBox("Failed to insert Group Header." & "Check log file for details", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Error")
                    Exit Sub
                End If

                'Detail
                If rsMember.Rows.Count = 0 Then
                    'cn.CommitTrans
                    'bcnStatus = NoTrans
                    'gGroupsRecord.bFlag = modo.SavedRecord
                    'MsgBox "Data was successfully inserted.", vbInformation + vbOKOnly, "GLM Message"
                    'Exit Sub
                Else
                    For row As Integer = 0 To rsMember.Rows.Count - 1
                        Select Case gGroupsRecord.sTypeId
                            Case GROUP_LOCAL
                                sStmt = "INSERT INTO GroupStore (group_seq, cust_id," & "store_id) VALUES " & "(" & Str(gGroupsRecord.nGroupSeq) & "," & "'" & gGroupsRecord.sCustId & "'," & Str(rsMember.Rows(row).Item("store_id")) & ")"

                            Case GROUP_AREA
                                sStmt = "INSERT INTO AreaDet ( area_seq, group_seq) " & " VALUES " & "(" & Str(gGroupsRecord.nGroupSeq) & "," & Str(rsMember.Rows(row).Item("group_seq")) & ")"

                            Case GROUP_DISTRICT
                                sStmt = "INSERT INTO DistrictDet ( district_seq, area_seq) " & " VALUES " & "(" & Str(gGroupsRecord.nGroupSeq) & "," & Str(rsMember.Rows(row).Item("area_seq")) & ")"

                            Case GROUP_REGION
                                sStmt = "INSERT INTO RegionDet ( region_seq, district_seq) " & " VALUES " & "(" & Str(gGroupsRecord.nGroupSeq) & "," & Str(rsMember.Rows(row).Item("district_seq")) & ")"

                        End Select

                        cmLocal.CommandText = sStmt
                        nRecords = cmLocal.ExecuteNonQuery()

                        If nRecords > 0 Then
                            'ok
                        Else
                            nTran.Rollback()
                            General.bcnStatus = General.cnStatus.NoTrans
                            MsgBox("Failed to save changes. Check log file for details.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                            Exit Sub
                        End If


                    Next row


                End If
                nTran.Commit()
                General.bcnStatus = General.cnStatus.NoTrans
                gGroupsRecord.bFlag = General.modo.SavedRecord
                txtGroupName.Enabled = False
                MsgBox("Data was successfully inserted.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")

            Case General.modo.UpdateRecord

                nTran = cn.BeginTransaction()
                General.bcnStatus = General.cnStatus.BeginTrans
                'Header
                sStmt = "UPDATE groups " & " SET cinvoice_attention = '" & quotation_mask(Trim(txtAttention.Text)) & "', " & "  cinvoice_contract_no = '" & quotation_mask(Trim(txtContractNo.Text)) & "'," & "  cinvoice_text = '" & quotation_mask(Trim(txtText.Text)) & "' " & " WHERE group_seq = " & Str(gGroupsRecord.nGroupSeq)



                cmLocal.CommandText = sStmt
                cmLocal.Transaction = nTran
                nRecords = cmLocal.ExecuteNonQuery()
                If nRecords > 0 Then
                    'ok
                Else
                    nTran.Rollback()
                    MsgBox("Failed to update Group Header." & "Check log file for details", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Error")
                    Exit Sub
                End If

                'Detail

                Select Case gGroupsRecord.sTypeId
                    Case GROUP_LOCAL
                        sStmt = "DELETE FROM GroupStore " & " WHERE cust_id='" & gGroupsRecord.sCustId & "'" & " AND group_seq =" & Str(gGroupsRecord.nGroupSeq)

                    Case GROUP_AREA
                        sStmt = "DELETE FROM AreaDet " & " WHERE area_seq = " & Str(gGroupsRecord.nGroupSeq)

                    Case GROUP_DISTRICT
                        sStmt = "DELETE FROM DistrictDet " & " WHERE district_seq = " & Str(gGroupsRecord.nGroupSeq)

                    Case GROUP_REGION
                        sStmt = "DELETE FROM RegionDet " & " WHERE region_seq = " & Str(gGroupsRecord.nGroupSeq)

                End Select


                cmLocal.CommandText = sStmt
                nRecords = cmLocal.ExecuteNonQuery()


                If rsMember.Rows.Count = 0 Then
                    nTran.Commit()
                    General.bcnStatus = General.cnStatus.NoTrans
                    gGroupsRecord.bFlag = General.modo.SavedRecord
                    Exit Sub
                End If

                For row As Integer = 0 To rsMember.Rows.Count - 1
                    Select Case gGroupsRecord.sTypeId
                        Case GROUP_LOCAL
                            sStmt = "INSERT INTO GroupStore (group_seq, cust_id," & "store_id) VALUES " & "(" & Str(gGroupsRecord.nGroupSeq) & "," & "'" & gGroupsRecord.sCustId & "'," & Str(rsMember.Rows(row).Item("store_id")) & ")"

                        Case GROUP_AREA
                            sStmt = "INSERT INTO AreaDet ( area_seq, group_seq) " & " VALUES " & "(" & Str(gGroupsRecord.nGroupSeq) & "," & Str(rsMember.Rows(row).Item("group_seq")) & ")"

                        Case GROUP_DISTRICT
                            sStmt = "INSERT INTO DistrictDet ( district_seq, area_seq) " & " VALUES " & "(" & Str(gGroupsRecord.nGroupSeq) & "," & Str(rsMember.Rows(row).Item("area_seq")) & ")"

                        Case GROUP_REGION
                            sStmt = "INSERT INTO RegionDet ( region_seq, district_seq) " & " VALUES " & "(" & Str(gGroupsRecord.nGroupSeq) & "," & Str(rsMember.Rows(row).Item("district_seq")) & ")"

                    End Select


                    cmLocal.CommandText = sStmt
                    nRecords = cmLocal.ExecuteNonQuery()

                    If nRecords > 0 Then
                        'ok
                    Else
                        nTran.Rollback()
                        General.bcnStatus = General.cnStatus.NoTrans
                        MsgBox("Failed to save changes. Check log file for details.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                        Exit Sub
                    End If

                Next row

                
                nTran.Commit()
                General.bcnStatus = General.cnStatus.NoTrans
                gGroupsRecord.bFlag = General.modo.SavedRecord
                MsgBox("Data was successfully updated.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
                'Exit Sub
        End Select
		Exit Sub
		
ErrorHandler: 
		If General.bcnStatus = General.cnStatus.BeginTrans Then
            nTran.Rollback()
		End If
		save_error(Me.Name, "save_group_store")
		MsgBox("Unexpected error while saving records. Review log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
	End Sub
	
	
	'Add records to dgGroupStore
	Private Sub add_dgGroupStore(ByRef sType As String)
        Dim vRow As DataGridViewRow
        Dim sCriteria As String = ""
		
        Dim nCandidate As Short

        If dgStores.SelectedRows.Count < 1 Then
            If dgStores.SelectedCells.Count > 0 Then
                dgStores.Rows(dgStores.SelectedCells(0).RowIndex).Selected = True
            End If
        End If

        If dgStores.SelectedRows.Count < 1 Then
            MsgBox("No available stores selected. Please select an available store to add.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Message")
            Exit Sub
        End If
        Select Case sType
            Case GROUP_LOCAL
                sCriteria = "store_id"

            Case GROUP_AREA
                sCriteria = "group_seq"

            Case GROUP_DISTRICT
                sCriteria = "area_seq"

            Case GROUP_REGION
                sCriteria = "district_seq"

            Case Else
                write_msg("add_dgGroupStore", "Invalid parameter sType:" & sType)
                Exit Sub
        End Select

        For Each vRow In dgStores.SelectedRows
            'UPGRADE_WARNING: Couldn't resolve default property of object vRow. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'rsStore.Bookmark = vRow 'Muevo el recordset a la fila seleccionada
            'Verifico si tienda ya existe en recordset
            'sCriteria = "store_id=" + Str(rsStore.item("store_id")) '04.17.2010



            'If rsMember.RecordCount > 0 Then
            '   rsMember.MoveFirst
            '    rsMember.Find sCriteria, , adSearchForward, 0
            'End If

            Select Case sType

                Case GROUP_LOCAL
                    nCandidate = vRow.Cells("store_id").Value

                Case GROUP_AREA
                    nCandidate = vRow.Cells("group_seq").Value

                Case GROUP_DISTRICT
                    nCandidate = vRow.Cells("area_seq").Value

                Case GROUP_REGION
                    nCandidate = vRow.Cells("district_seq").Value

                Case Else
                    write_msg("add_dgGroupStore", "Invalid parameter sType:" & sType)
                    Exit Sub
            End Select



            'If record_exist(rsMember, rsStore.item("store_id")) = False Then
            If record_exist(rsMember, nCandidate, sType) = False Then

                'rsMember.AddNew()
                Dim drow As DataRow = rsMember.NewRow
                Select Case sType
                    Case GROUP_LOCAL
                        drow.Item("store_id") = vRow.Cells("store_id").Value
                        drow.Item("store") = vRow.Cells("store").Value
                        drow.Item("name") = vRow.Cells("name").Value
                        drow.Item("state") = vRow.Cells("state").Value
                        drow.Item("Address") = vRow.Cells("Address").Value

                    Case GROUP_AREA
                        drow.Item("group_seq") = vRow.Cells("group_seq").Value
                        drow.Item("name") = vRow.Cells("name").Value

                    Case GROUP_DISTRICT
                        drow.Item("area_seq") = vRow.Cells("area_seq").Value
                        drow.Item("name") = vRow.Cells("name").Value

                    Case GROUP_REGION
                        drow.Item("district_seq") = vRow.Cells("district_seq").Value
                        drow.Item("name") = vRow.Cells("name").Value

                End Select
                rsMember.Rows.Add(drow)

                'rsMember.Update()


                Select Case sType
                    Case GROUP_LOCAL
                        'rsMember.Sort = "state, store"
                        rsMember.Select("", "state, store")

                    Case GROUP_AREA
                        rsMember.Select("", "name")

                    Case GROUP_DISTRICT
                        rsMember.Select("", "name")

                    Case GROUP_REGION
                        rsMember.Select("", "name")
                End Select

            End If
            Dim sSelectQuery As String = sCriteria + " = '" + nCandidate.ToString() + "'"
            Dim remRow As DataRow() = rsStore.Select(sSelectQuery)
            If remRow.Length > 0 Then
                rsStore.Rows.Remove(remRow(0)) '(vRow.Index) 'Delete(ADODB.AffectEnum.adAffectCurrent)
            End If
        Next vRow

        dgGroupStore.DataSource = Nothing
        dgGroupStore.Refresh()
        dgGroupStore.DataSource = rsMember
        dgGroupStore.Refresh()

        dgStores.DataSource = Nothing
        dgStores.DataSource = rsStore

        dgStores.Sort(dgStores.Columns(sCriteria), System.ComponentModel.ListSortDirection.Ascending)
        dgGroupStore.Sort(dgGroupStore.Columns(sCriteria), System.ComponentModel.ListSortDirection.Ascending)

        dgStores.Columns(sCriteria).Visible = False
        dgGroupStore.Columns(sCriteria).Visible = False

        dgStores.Refresh()

	End Sub
	
	
	'Elimina registros de dgStores
	Private Sub del_dgGroupStore(ByRef sType As String)
        Dim vRow As Integer
        Dim sCriteria As String = ""
		
        Dim nCandidate As Short

        If dgGroupStore.SelectedRows.Count < 1 Then
            If dgGroupStore.SelectedCells.Count > 0 Then
                Dim rowIndx As Integer = dgGroupStore.SelectedCells(0).RowIndex
                Dim str As String = dgGroupStore.Rows(rowIndx).Cells(0).Value
                If dgGroupStore.SelectedCells.Count > 0 And Not str = "" Then
                    dgGroupStore.Rows(rowIndx).Selected = True
                End If
            End If
        End If

        'For Each vRow In dgGroupStore.SelectedRows
        For rowIndex As Integer = 0 To dgGroupStore.SelectedRows.Count - 1
            vRow = dgGroupStore.SelectedRows(rowIndex).Index
            'UPGRADE_WARNING: Couldn't resolve default property of object vRow. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'rsMember.Bookmark = vRow 'Muevo el recordset a la fila seleccionada
            'Verifico si tienda ya existe en recordset
            'sCriteria = "store_id=" + Str(rsMember.item("store_id")) '04.17.2010


            'If rsStore.RecordCount > 0 Then
            '    rsStore.MoveFirst
            'rsStore.Find sCriteria, , adSearchForward, 0
            'End If

            Select Case sType
                Case GROUP_LOCAL
                    nCandidate = dgGroupStore.Rows(vRow).Cells("store_id").Value
                    sCriteria = "store_id"

                Case GROUP_AREA
                    nCandidate = dgGroupStore.Rows(vRow).Cells("group_seq").Value
                    sCriteria = "group_seq"

                Case GROUP_DISTRICT
                    nCandidate = dgGroupStore.Rows(vRow).Cells("area_seq").Value
                    sCriteria = "area_seq"

                Case GROUP_REGION
                    nCandidate = dgGroupStore.Rows(vRow).Cells("district_seq").Value
                    sCriteria = "district_seq"

                Case Else
                    write_msg("add_dgGroupStore", "Invalid parameter sType:" & sType)
                    Exit Sub
            End Select




            'If record_exist(rsStore, dgGroupStore.item("store_id")) = False Then
            If record_exist(rsStore, nCandidate, sType) = False Then

                'rsStore.AddNew()
                Dim drow As DataRow = rsStore.NewRow
                Select Case sType
                    Case GROUP_LOCAL
                        drow.Item("store_id") = dgGroupStore.Rows(vRow).Cells("store_id").Value
                        drow.Item("store") = dgGroupStore.Rows(vRow).Cells("store").Value
                        drow.Item("name") = dgGroupStore.Rows(vRow).Cells("name").Value
                        drow.Item("state") = dgGroupStore.Rows(vRow).Cells("state").Value
                        drow.Item("Address") = dgGroupStore.Rows(vRow).Cells("Address").Value

                    Case GROUP_AREA
                        drow.Item("group_seq") = dgGroupStore.Rows(vRow).Cells("group_seq").Value
                        drow.Item("name") = dgGroupStore.Rows(vRow).Cells("name").Value

                    Case GROUP_DISTRICT
                        drow.Item("area_seq") = dgGroupStore.Rows(vRow).Cells("area_seq").Value
                        drow.Item("name") = dgGroupStore.Rows(vRow).Cells("name").Value

                    Case GROUP_REGION
                        drow.Item("district_seq") = dgGroupStore.Rows(vRow).Cells("district_seq").Value
                        drow.Item("name") = dgGroupStore.Rows(vRow).Cells("name").Value
                End Select

                rsStore.Rows.Add(drow)
                'rsStore.Update()

                Select Case sType
                    Case GROUP_LOCAL
                        rsStore.Select("", "state, store")

                    Case GROUP_AREA
                        rsStore.Select("", "name")

                    Case GROUP_DISTRICT
                        rsStore.Select("", "name")

                    Case GROUP_REGION
                        rsStore.Select("", "name")
                End Select

            End If

            Dim remDataRow As DataRow = rsMember.Select("name = '" + dgGroupStore.Rows(vRow).Cells("name").Value.ToString() + "'")(0)
            rsMember.Rows.Remove(remDataRow) '(vRow)
        Next rowIndex

        dgStores.Refresh()
        dgGroupStore.Refresh()

        If Not Trim(sCriteria) = "" Then
            dgStores.Sort(dgStores.Columns(sCriteria), System.ComponentModel.ListSortDirection.Ascending)
            dgGroupStore.Sort(dgGroupStore.Columns(sCriteria), System.ComponentModel.ListSortDirection.Ascending)
            dgStores.Columns(sCriteria).Visible = False
            dgGroupStore.Columns(sCriteria).Visible = False
        End If
  

    End Sub
	
	'Looks for Candidate in Datagrid
    Private Function record_exist(ByRef rsTmp As SqlDataReader, ByRef nStoreId As Short, ByRef sType As String) As Boolean

        Dim sCriteria As String

        Select Case sType
            Case GROUP_LOCAL
                sCriteria = "store_id=" & Str(nStoreId)

            Case GROUP_AREA
                sCriteria = "group_seq=" & Str(nStoreId)

            Case GROUP_DISTRICT
                sCriteria = "area_seq=" & Str(nStoreId)

            Case GROUP_REGION
                sCriteria = "district_seq=" & Str(nStoreId)
            Case Else
                Exit Function
        End Select

        If Not rsTmp.HasRows Then
            record_exist = False
            Exit Function
        End If

        'rsTmp.Find(sCriteria, , ADODB.SearchDirectionEnum.adSearchForward)

        'If rsTmp.EOF Or rsTmp.BOF Then
        '    record_exist = False
        '    Exit Function
        'End If
        record_exist = True

    End Function
    'Looks for Candidate in Datagrid
    Private Function record_exist(ByRef rsTmp As DataTable, ByRef nStoreId As Short, ByRef sType As String) As Boolean
        record_exist = False
        Dim sCriteria As String

        Select Case sType
            Case GROUP_LOCAL
                sCriteria = String.Format("store_id={0}", nStoreId.ToString())

            Case GROUP_AREA
                sCriteria = String.Format("group_seq={0}", nStoreId.ToString())

            Case GROUP_DISTRICT
                sCriteria = String.Format("area_seq={0}", nStoreId.ToString())

            Case GROUP_REGION
                sCriteria = String.Format("district_seq={0}", nStoreId.ToString())
            Case Else
                Exit Function
        End Select




        If rsTmp.Rows.Count < 1 Then
            record_exist = False
            Exit Function
        End If

        Try
            Dim tmprow() As DataRow = rsTmp.Select(sCriteria) '.Rows.Find(sCriteria) ', , ADODB.SearchDirectionEnum.adSearchForward)
            If tmprow.Length > 0 Then
                record_exist = True
            End If

        Catch ex As Exception
            record_exist = False
            Exit Function
        End Try
        

    End Function

    Private Sub dgGroupStore_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgGroupStore.CellDoubleClick
        cmdRemove_Click(sender, e)
    End Sub

    Private Sub dgStores_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgStores.CellDoubleClick
        cmdAdd_Click(sender, e)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        If val_fields() Then
            save_group_store()
            Me.Close()
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        If gGroupsRecord.bFlag <> General.modo.SavedRecord And bNewRecord = False Then
            If (MsgBox("Do you want to save your changes?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "GLM Message") = MsgBoxResult.Yes) Then
                If val_fields() Then
                    save_group_store()
                End If
            End If
        End If
        Me.Close()
    End Sub
End Class