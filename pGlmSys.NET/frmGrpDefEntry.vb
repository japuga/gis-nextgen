Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmGrpDefEntry
	Inherits System.Windows.Forms.Form
    Dim rsLocal As SqlDataReader
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdMembers_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMembers.Click
		'gItplGridSelector
		set_grid_selector()
		VB6.ShowForm(tplGridSelector, VB6.FormShowConstants.Modal, Me)
		
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If val_fields Then
			If save_record Then
				gGrpdef.bModo = General.modo.SavedRecord
				Me.Close()
			End If
		End If
	End Sub
	Private Function val_fields() As Boolean
		
		On Error GoTo ErrorHandler
		
		val_fields = False
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(gGrpdef.sCustId) Then
			MsgBox("Customer name can not be null.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Function
		Else
			If Len(Trim(gGrpdef.sCustId)) = 0 Then
				MsgBox("Customer name can not be null.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
				Exit Function
			End If
		End If
		
		If cbTypeId.SelectedIndex < 0 Then
			MsgBox("Please select a type from the list.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			cbTypeId.Focus()
			Exit Function
		End If
		
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtGrpDefId.Text) Then
			MsgBox("Group Access name can not be null.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
			txtGrpDefId.Focus()
			Exit Function
		Else
			If Len(Trim(txtGrpDefId.Text)) = 0 Then
				MsgBox("Group Access name can not be null.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
				txtGrpDefId.Focus()
				Exit Function
			End If
			
		End If
		
		val_fields = True
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "val_fields")
		MsgBox("An unexpected has occurred. Please check log files for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Function
	Private Function save_record() As Boolean

		Dim nRecords As Short
        Dim cmd As SqlCommand = cn.CreateCommand()
		On Error GoTo ErrorHandler
		
		save_record = False
		
		'Check for duplicates
		sStmt = " SELECT grpdef_id FROM GrpDef " & " WHERE grpdef_id = '" & quotation_mask(Trim(txtGrpDefId.Text)) & "' " & " AND cust_id = '" & gGrpdef.sCustId & "' " & " AND type_id = '" & cbTypeId.Text & "' "
        cmd.CommandText = sStmt
		
        rs = getDataTable(sStmt) ' cmd.ExecuteReader()

        If rs.Rows.Count > 0 Then
            MsgBox("Group Access name already exist, please try again.", MsgBoxStyle.Critical + MsgBoxStyle.Exclamation, "GLM Warning")
            txtGrpDefId.Focus()
            Exit Function
        End If


        sStmt = " INSERT INTO GrpDef(grpdef_id, cust_id, type_id) " & " VALUES('" & quotation_mask(Trim(txtGrpDefId.Text)) & "'," & " '" & gGrpdef.sCustId & "', " & " '" & quotation_mask(Trim(cbTypeId.Text)) & "') "
        cmd.CommandText = sStmt
        nRecords = cmd.ExecuteNonQuery()
        If nRecords > 0 Then
            save_record = True
            MsgBox("Group Access was created successfully.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
        Else
            MsgBox("Failed to insert Group Access record.Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
        End If

        Exit Function

ErrorHandler:
        save_error(Me.Name, "save_record")
        MsgBox("Unexpected error found when inserting into grpdef table.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Message")
		
	End Function
	Private Sub frmGrpDefEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		
        'rsLocal = SqlDataReader
		
		'UPGRADE_WARNING: TextBox property txtGrpDefId.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtGrpDefId.Maxlength = 50
		
		
		txtCustName.Text = gGrpdef.sCustName
		
		'Type Combo
		sStmt = "SELECT RTRIM(type_id) FROM GrpType " & "ORDER BY sort_id "
		load_cb_query2(cbTypeId, sStmt, 1, True)
		
		Select Case gGrpdef.bModo
			Case General.modo.NewRecord
				If cbTypeId.Items.Count > 0 Then
					cbTypeId.SelectedIndex = 0
				End If
			Case General.modo.UpdateRecord
				cbTypeId.Enabled = False
				txtGrpDefId.ReadOnly = True
				txtGrpDefId.Enabled = False
				
				txtGrpDefId.Text = gGrpdef.sGrpDefId
				set_cb(cbTypeId, Trim(gGrpdef.sTypeId))
				
		End Select
		
	End Sub
	
	Private Sub set_grid_selector()
		
		clear_gItplGridSelector()
		
		'Init
		gItplGridSelector.sQueryInit = build_query_init
		'Left
		gItplGridSelector.sQuerySource = build_query_left
		
		'Right
		gItplGridSelector.sQuerySelected = build_query_right
		
		gItplGridSelector.sOrderBy = "Member"
		
		
		'Formato
		gItplGridSelector.aFields(0).sFieldName = "Member"
		gItplGridSelector.aFields(0).bVisible = True
		gItplGridSelector.aFields(0).nWidth = 2000
		
		'gItplGridSelector.aFields(1).sFieldName = "Name"
		'gItplGridSelector.aFields(1).bVisible = True
		'gItplGridSelector.aFields(1).nWidth = 3000
		
		gItplGridSelector.sLeftCaption = "Available Members"
		gItplGridSelector.sRightCaption = "Selected Members"
		
		
	End Sub
	Private Function build_query_left() As String
		Dim sGrpDefId As String
        build_query_left = ""
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtGrpDefId.Text) Then
			sGrpDefId = ""
		Else
			sGrpDefId = txtGrpDefId.Text
		End If
		
		Select Case cbTypeId.Text
			Case "LOCAL"
				build_query_left = " SELECT store_number AS Member" & " FROM store " & " WHERE cust_id ='" & gGrpdef.sCustId & "' " & " AND store_number NOT IN " & " (SELECT store_number FROM locals " & "      WHERE locals.store_id = store.store_id " & "      AND locals.cust_id = store.cust_id)" & " ORDER BY store_number "
				
			Case "AREA"
				build_query_left = "SELECT grpdef_id AS Member " & " FROM GrpDef a " & " WHERE a.cust_id = '" & gGrpdef.sCustId & "' " & " AND a.type_id = 'LOCAL'" & " AND a.grpdef_id NOT IN ( " & "   SELECT child_id FROM GrpDefRef b " & "   WHERE b.cust_id = a.cust_id " & "   AND b.type_id = 'AREA' " & "   AND b.grpdef_id  ='" & sGrpDefId & "')"
				
			Case "DISTRICT"
				build_query_left = "SELECT grpdef_id AS Member" & " FROM GrpDef a  " & " WHERE a.cust_id = '" & gGrpdef.sCustId & "' " & " AND a.type_id = 'AREA'" & " AND a.grpdef_id NOT IN (" & "   SELECT child_id FROM GrpDefRef b " & "   WHERE b.cust_id = a.cust_id " & "   AND b.type_id = 'DISTRICT' " & "   AND b.grpdef_id  ='" & sGrpDefId & "')"
				
			Case "REGION"
				build_query_left = "SELECT grpdef_id AS Member" & " FROM GrpDef a  " & " WHERE a.cust_id = '" & gGrpdef.sCustId & "' " & " AND a.type_id = 'DISTRICT'" & " AND a.grpdef_id NOT IN (" & "   SELECT child_id FROM GrpDefRef b " & "   WHERE b.cust_id = a.cust_id " & "   AND b.type_id = 'REGION' " & "   AND b.grpdef_id  ='" & sGrpDefId & "')"
				
				
			Case "CORPORATE"
				build_query_left = "SELECT grpdef_id AS Member" & " FROM GrpDef a  " & " WHERE a.cust_id = '" & gGrpdef.sCustId & "' " & " AND a.type_id = 'REGION'" & " AND a.grpdef_id NOT IN (" & "   SELECT child_id FROM GrpDefRef b " & "   WHERE b.cust_id = a.cust_id " & "   AND b.type_id = 'CORPORATE' " & "   AND b.grpdef_id  ='" & sGrpDefId & "')"
				
				
		End Select
		
		
	End Function
	Private Function build_query_right() As String
        build_query_right = ""
        Select Case cbTypeId.Text
            Case "LOCAL"
                build_query_right = "SELECT a.store_number AS Member " & " FROM locals a " & " WHERE a.cust_id = '" & gGrpdef.sCustId & "' " & " AND a.parent_id ='" & quotation_mask(Trim(txtGrpDefId.Text)) & "' "

            Case "AREA"
                build_query_right = "SELECT child_id AS Member" & " FROM GrpDefRef a  " & " WHERE a.cust_id = '" & gGrpdef.sCustId & "' " & " AND a.grpdef_id ='" & quotation_mask(Trim(txtGrpDefId.Text)) & "' " & " AND a.type_id = 'AREA'"

            Case "DISTRICT"
                build_query_right = "SELECT child_id AS Member" & " FROM GrpDefRef a" & " WHERE a.cust_id = '" & gGrpdef.sCustId & "' " & " AND a.grpdef_id ='" & quotation_mask(Trim(txtGrpDefId.Text)) & "' " & " AND a.type_id = 'DISTRICT'"

            Case "REGION"
                build_query_right = "SELECT child_id AS Member" & " FROM GrpDefRef a" & " WHERE a.cust_id = '" & gGrpdef.sCustId & "' " & " AND a.grpdef_id ='" & quotation_mask(Trim(txtGrpDefId.Text)) & "' " & " AND a.type_id = 'REGION'"

            Case "CORPORATE"
                build_query_right = "SELECT child_id AS Member" & " FROM GrpDefRef a" & " WHERE a.cust_id = '" & gGrpdef.sCustId & "' " & " AND a.grpdef_id ='" & quotation_mask(Trim(txtGrpDefId.Text)) & "' " & " AND a.type_id = 'CORPORATE'"

        End Select
		
		
		
		
	End Function
    Private Function build_query_init() As String
        build_query_init = ""
        Select Case cbTypeId.Text
            Case "LOCAL"
                build_query_init = "SELECT a.store_number AS Member " & " FROM locals a " & " WHERE a.cust_id = '" & gGrpdef.sCustId & "' " & " AND a.parent_id ='' "

            Case "AREA"
                build_query_init = "SELECT grpdef_id AS Member " & " FROM GrpDefRef a  " & " WHERE a.cust_id = '" & gGrpdef.sCustId & "' " & " AND a.grpdef_id ='' " & " AND a.type_id = 'AREA'"

            Case "DISTRICT"
                build_query_init = "SELECT child_id AS Member" & " FROM GrpDefRef a" & " WHERE a.cust_id = '" & gGrpdef.sCustId & "' " & " AND a.grpdef_id ='' " & " AND a.type_id = 'DISTRICT'"

            Case "REGION"
                build_query_init = "SELECT child_id AS Member" & " FROM GrpDefRef a" & " WHERE a.cust_id = '" & gGrpdef.sCustId & "' " & " AND a.grpdef_id ='' " & " AND a.type_id = 'REGION'"

            Case "CORPORATE"
                build_query_init = "SELECT child_id AS Member" & " FROM GrpDefRef a" & " WHERE a.cust_id = '" & gGrpdef.sCustId & "' " & " AND a.grpdef_id ='' " & " AND a.type_id = 'CORPORATE'"


        End Select

    End Function
End Class