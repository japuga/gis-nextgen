Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Friend Class frmAlert
	Inherits System.Windows.Forms.Form
    Private oRS As DataTable
	
	'UPGRADE_WARNING: Event cbCustId.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustId_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustId.SelectedIndexChanged
		cbCustName.SelectedIndex = cbCustId.SelectedIndex
	End Sub
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		cbCustId.SelectedIndex = cbCustName.SelectedIndex
		load_storeNo()
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		
        If Me.dgEquipment.SelectedRows.Count > 0 Then
            show_vendor((oRS.Rows(0).Item("cust_id").value), (oRS.Rows(0).Item("store_id").value), dgEquipment.SelectedRows(0).Cells("Seq").Value)
        End If
		'dgEquipment.Columns("eqpt_desc"), dgEquipment.Columns("load_id")
		
	End Sub
	
    Private Sub dgEquipment_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Command1_Click(Command1, New System.EventArgs())
    End Sub
	
    Private Sub dgNotes_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Not (dgNotes Is Nothing) Then
            update_alert()
        End If
    End Sub
	
    Private Sub dgVendor_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        get_dgContractData()
    End Sub
	
	
	
	Private Sub SSTab1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SSTab1.SelectedIndexChanged
		Static PreviousTab As Short = SSTab1.SelectedIndex()
		If SSTab1.SelectedIndex = 2 Then
			show_alert()
		End If
		PreviousTab = SSTab1.SelectedIndex()
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button3.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        On Error Resume Next
        Select Case Button.Name
            'no existe move next y back
            Case "Find"
                'ToDo: Add 'Find' button code.
                load_Data()
            Case "Forward"
                'ToDo: Add 'Forward' button code.
                'MsgBox "Add 'Forward' button code."
                'oRS.MoveNext()
                show_data()
            Case "Back"
                'oRS.MovePrevious()
                show_data()
            Case "First"
                'oRS.MoveFirst()
                show_data()
            Case "Clear"
                clear_data()
            Case "Last"
                'oRS.MoveLast()
                show_data()
                'ToDo: Add 'Back' button code.
                'MsgBox "Add 'Back' button code."
        End Select
    End Sub
	
	Private Sub clear_grid()
		
		
		'UPGRADE_NOTE: Object dgNotes.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		dgNotes.DataSource = Nothing
		
		
		
		struct_dgEquipment()
		struct_dgVendor()
		struct_dgServices()
		
		
		'    For iIndice = dgService.Columns.Count - 1 To 2 Step -1
		'        dgService.Columns.Remove iIndice
		'    Next
        dgNotes.Columns.Add("Date", "Date")
        dgNotes.Columns.Add("Regarding", "Regarding")
		
		dgNotes.Columns("Date").Width = VB6.TwipsToPixelsX(1000)
		dgNotes.Columns("Regarding").Width = VB6.TwipsToPixelsX(9000)
		
	End Sub
	Private Sub struct_dgEquipment()
		Dim iIndice As Short
		'UPGRADE_NOTE: Object dgEquipment.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		dgEquipment.DataSource = Nothing
		For iIndice = dgEquipment.Columns.Count - 1 To 2 Step -1
			dgEquipment.Columns.Remove(iIndice)
		Next 
        dgEquipment.Columns.Add("Equipment", "Equipment")
        dgEquipment.Columns.Add("Load Type", "Load Type")
        dgEquipment.Columns.Add("Content", "Content")
        dgEquipment.Columns.Add("Qty", "Qty")
        dgEquipment.Columns.Add("Permanent/Temporary", "Permanent/Temporary")
		
		dgEquipment.Columns("Equipment").Width = VB6.TwipsToPixelsX(1000)
		dgEquipment.Columns("Load Type").Width = VB6.TwipsToPixelsX(1200)
		dgEquipment.Columns("Content").Width = VB6.TwipsToPixelsX(3000)
		dgEquipment.Columns("Qty").Width = VB6.TwipsToPixelsX(1000)
		dgEquipment.Columns("Permanent/Temporary").Width = VB6.TwipsToPixelsX(2000)
	End Sub
	Private Sub struct_dgVendor()
		Dim iIndice As Short
		'UPGRADE_NOTE: Object dgVendor.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		dgVendor.DataSource = Nothing
		For iIndice = dgVendor.Columns.Count - 1 To 2 Step -1
			dgVendor.Columns.Remove(iIndice)
		Next 
        dgVendor.Columns.Add("Equipment", "Equipment")
        dgVendor.Columns.Add("Load Type", "Load Type")
        dgVendor.Columns.Add("Account No", "Account No")
        dgVendor.Columns.Add("Area", "Area")
        dgVendor.Columns.Add("Contact", "Contact")
        dgVendor.Columns.Add("Phone1", "Phone1")
        dgVendor.Columns.Add("Phone2", "Phone2")
        dgVendor.Columns.Add("Fax1", "Fax1")
        dgVendor.Columns.Add("Fax2", "Fax2")
		
		dgVendor.Columns("Equipment").Width = VB6.TwipsToPixelsX(1000)
		dgVendor.Columns("Load Type").Width = VB6.TwipsToPixelsX(1000)
		dgVendor.Columns("Account No").Width = VB6.TwipsToPixelsX(1000)
		dgVendor.Columns("Area").Width = VB6.TwipsToPixelsX(800)
		dgVendor.Columns("Contact").Width = VB6.TwipsToPixelsX(900)
		dgVendor.Columns("Phone1").Width = VB6.TwipsToPixelsX(1000)
		dgVendor.Columns("Phone2").Width = VB6.TwipsToPixelsX(1000)
		dgVendor.Columns("Fax1").Width = VB6.TwipsToPixelsX(1000)
		dgVendor.Columns("Fax2").Width = VB6.TwipsToPixelsX(1000)
	End Sub
	
	Private Sub struct_dgServices()
		Dim iIndice As Short
		'UPGRADE_NOTE: Object dgService.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		dgService.DataSource = Nothing
		For iIndice = dgService.Columns.Count - 1 To 2 Step -1
			dgService.Columns.Remove(iIndice)
		Next 
        dgService.Columns.Add("Vendor", "Vendor")
        dgService.Columns.Add("Equipment", "Equipment")
        dgService.Columns.Add("Content", "Content")
        dgService.Columns.Add("Service", "Service")
        dgService.Columns.Add("Rate", "Rate")
        dgService.Columns.Add("Prev Rate", "Prev Rate")
        dgService.Columns.Add("Started", "Started")
        dgService.Columns.Add("Until", "Until")
		
		dgService.Columns("Vendor").Width = VB6.TwipsToPixelsX(2000)
		dgService.Columns("Equipment").Width = VB6.TwipsToPixelsX(1000)
		dgService.Columns("Content").Width = VB6.TwipsToPixelsX(800)
		dgService.Columns("Service").Width = VB6.TwipsToPixelsX(1300)
		dgService.Columns("Rate").Width = VB6.TwipsToPixelsX(850)
		dgService.Columns("Prev Rate").Width = VB6.TwipsToPixelsX(850)
		dgService.Columns("Started").Width = VB6.TwipsToPixelsX(1000)
		dgService.Columns("Until").Width = VB6.TwipsToPixelsX(1000)
		
	End Sub
	
	Private Sub clear_data()
		
		Dim n As String
        'Dim iIndice As Short
		
		clear_grid()
		'dgVendor.Columns("vend_id").Width = 0
		'dgVendor.Columns("vend_name").Width = 0
		
		
		If cbCustName.Items.Count > 0 Then
			cbCustName.SelectedIndex = 0
		End If
		txtStoreName.Text = ""
		txtStoreCity.Text = ""
		txtStoreContact.Text = ""
		txtStoreFolder.Text = ""
		If cbStoreNo.Items.Count > 0 Then
			cbStoreNo.SelectedIndex = 0
		End If
		txtStoreAddress.Text = ""
		txtStoreZip.Text = ""
		If cbState.Items.Count > 0 Then
			cbState.SelectedIndex = 0
		End If
		If cbStoreStatus.Items.Count > 0 Then
			cbStoreStatus.SelectedIndex = 0
		End If
		txtStoreCoCode.Text = ""
		txtOccupants.Text = ""
		txtMessage.Text = ""
		
		n = mtxtStorePhone1.Mask
		mtxtStorePhone1.Mask = ""
		'mtxtStorePhone1.Format = ""
		mtxtStorePhone1.Text = ""
		mtxtStorePhone1.Mask = n
		
		n = mtxtStorePhone2.Mask
		mtxtStorePhone2.Mask = ""
		'mtxtStorePhone2.Format = ""
		mtxtStorePhone2.Text = ""
		mtxtStorePhone2.Mask = n
		
		n = mtxtStoreFax1.Mask
		mtxtStoreFax1.Mask = ""
		'mtxtStoreFax1.Format = ""
		mtxtStoreFax1.Text = ""
		mtxtStoreFax1.Mask = n
		
		n = mtxtStoreFax2.Mask
		mtxtStoreFax2.Mask = ""
		'mtxtStoreFax2.Format = ""
		mtxtStoreFax2.Text = ""
		mtxtStoreFax2.Mask = n
		
	End Sub
	
	Private Sub init_vars()
		
		load_storeNo()
		load_comp()
		load_state()
		
		'Combo cbStoreStatus
		cbStoreStatus.Items.Clear()
		cbStoreStatus.Items.Insert(0, "<All>")
		cbStoreStatus.Items.Insert(1, "Active")
		cbStoreStatus.Items.Insert(2, "Inactive")
		
		dtFrom.value = Today
		dtTo.value = Today
		
	End Sub
	
	
	Private Sub load_state() '(sCustId As String)
		
		cbState.Items.Clear()
		
		cbState.Items.Insert(0, "<All>")
		sStmt = "SELECT state_id FROM state"
		load_cb_query2(cbState, sStmt, 1, False)
		cbState.SelectedIndex = 0
		
	End Sub
	
	
	Private Sub load_Data()
		
		Dim sStmt_query As String
        oRS = Nothing
		
		'If Not (oRS Is Nothing) Then
		'    If oRS.State <> adStateOpen Then
		'       oRS.Close
		'    End If
		'End If
		
		
		
		
		'UPGRADE_NOTE: Object dgEquipment.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		dgEquipment.DataSource = Nothing
		'UPGRADE_NOTE: Object dgVendor.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		dgVendor.DataSource = Nothing
		'UPGRADE_NOTE: Object dgService.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		dgService.DataSource = Nothing
		'UPGRADE_NOTE: Object dgNotes.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		dgNotes.DataSource = Nothing
		
		
		
		
		
        oRS = Nothing
		
		sStmt_query = ""
		If cbCustId.SelectedIndex > 0 Then
			sStmt_query = " cust_id='" & Trim(cbCustId.Text) & "'"
		End If
		
		If Trim(txtStoreName.Text) <> "" Then
			sStmt_query = sStmt_query & IIf(Len(sStmt_query) > 0, " AND ", "") & " store_name LIKE '%" & Trim(txtStoreName.Text) & "%'"
		End If
		
		If Trim(Me.txtStoreCity.Text) <> "" Then
			sStmt_query = sStmt_query & IIf(Len(sStmt_query) > 0, " AND ", "") & " store_City LIKE '%" & Trim(txtStoreCity.Text) & "%'"
		End If
		
		If Trim(Me.mtxtStorePhone1.Text) <> "" And Trim(Me.mtxtStorePhone1.Text) <> "(___)-___-____" Then
			sStmt_query = sStmt_query & IIf(Len(sStmt_query) > 0, " AND ", "") & " store_phone1 LIKE '%" & Trim(mtxtStorePhone1.Text) & "%'"
		End If
		
		If Trim(Me.mtxtStorePhone2.Text) <> "" And Trim(Me.mtxtStorePhone2.Text) <> "(___)-___-____" Then
			sStmt_query = sStmt_query & IIf(Len(sStmt_query) > 0, " AND ", "") & " store_phone2 LIKE '%" & Trim(mtxtStorePhone2.Text) & "%'"
		End If
		
		If Trim(Me.txtStoreContact.Text) <> "" Then
			sStmt_query = sStmt_query & IIf(Len(sStmt_query) > 0, " AND ", "") & " store_contact LIKE '%" & Trim(txtStoreContact.Text) & "%'"
		End If
		
		If Trim(Me.txtStoreFolder.Text) <> "" Then
			sStmt_query = sStmt_query & IIf(Len(sStmt_query) > 0, " AND ", "") & " store_folder LIKE '%" & Trim(txtStoreFolder.Text) & "%'"
		End If
		
		'If Trim(Me.txtStoreId.Text) <> "" Then
		'    sStmt_query = IIf(Len(sStmt_query) > 0, " AND ", "") & " store_id='" & Trim(txtStoreId.Text) & "'"
		'End If
		
		If Trim(Me.cbStoreNo.Text) <> "" Then
			If cbStoreNo.SelectedIndex > -1 Then
				sStmt_query = sStmt_query & IIf(Len(sStmt_query) > 0, " AND ", "") & " store_id='" & Trim(CStr(VB6.GetItemData(cbStoreNo, cbStoreNo.SelectedIndex))) & "'"
			End If
			sStmt_query = sStmt_query & IIf(Len(sStmt_query) > 0, " AND ", "") & " store_number='" & Trim(cbStoreNo.Text) & "'"
		End If
		
		If Trim(Me.txtStoreAddress.Text) <> "" Then
			sStmt_query = sStmt_query & IIf(Len(sStmt_query) > 0, " AND ", "") & " store_address LIKE '%" & Trim(txtStoreAddress.Text) & "%'"
		End If
		
		If Trim(Me.txtStoreZip.Text) <> "" Then
			sStmt_query = sStmt_query & IIf(Len(sStmt_query) > 0, " AND ", "") & " store_zip = '" & Trim(txtStoreZip.Text) & "'"
		End If
		
		If Trim(Me.mtxtStoreFax1.Text) <> "" And Trim(Me.mtxtStoreFax1.Text) <> "(___)-___-____" Then
			sStmt_query = sStmt_query & IIf(Len(sStmt_query) > 0, " AND ", "") & " store_fax1 LIKE '%" & Trim(mtxtStoreFax1.Text) & "%'"
		End If
		
		If Trim(Me.mtxtStoreFax2.Text) <> "" And Trim(Me.mtxtStoreFax2.Text) <> "(___)-___-____" Then
			sStmt_query = sStmt_query & IIf(Len(sStmt_query) > 0, " AND ", "") & " store_fax2 LIKE '%" & Trim(mtxtStoreFax2.Text) & "%'"
		End If
		
		If Trim(Me.txtStoreCoCode.Text) <> "" Then
			sStmt_query = sStmt_query & IIf(Len(sStmt_query) > 0, " AND ", "") & " store_co_code='" & Trim(txtStoreCoCode.Text) & "'"
		End If
		
		If cbState.SelectedIndex > 0 Then
			sStmt_query = sStmt_query & IIf(Len(sStmt_query) > 0, " AND ", "") & " state_id='" & Trim(cbState.Text) & "'"
		End If
		
		If cbStoreStatus.SelectedIndex > 0 Then
			sStmt_query = sStmt_query & IIf(Len(sStmt_query) > 0, " AND ", "") & " store_status='" & VB.Left(cbStoreStatus.Text, 1) & "'"
		End If
		
		
		
		sStmt = CStr(CDbl("SELECT * " & "FROM store ") + IIf(Trim(sStmt_query) <> "", " WHERE " & sStmt_query, ""))
		
		
		oRS = exec_sql(sStmt)
		
        If Not oRS.Rows.Count > 0 Then
            MsgBox("Your Account does not have access to such Information." & vbCrLf & "Contact your System Administrator to get proper access.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
            Exit Sub
        Else
            'lblMessage.Caption = "No records were found for such criteria. Please try again"
            clear_grid()

            MsgBox("No records were found for such criteria. Please try again", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")


            Exit Sub
        End If
		
		'lblMessage.Caption = ""
		
		show_data()
		
		
	End Sub
	
	Private Sub show_data()
		
		Dim n As String
		Dim iIndice As Short

        'no entiendo como funciona
        '      If oRS.BOF Then
        '          Exit Sub
        '      End If

        'If oRS.EOF Then
        '	Exit Sub
        'End If
        '()
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        cbCustId.Text = IIf(IsDBNull(oRS.Rows(0).Item("cust_id")), "", oRS.Rows(0).Item("cust_id"))
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        txtStoreName.Text = IIf(IsDBNull(oRS.Rows(0).Item("store_name")), "", Trim(oRS.Rows(0).Item("store_name")))
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        txtStoreCity.Text = IIf(IsDBNull(oRS.Rows(0).Item("store_city")), "", Trim(oRS.Rows(0).Item("store_city")))
		
		n = mtxtStorePhone1.Mask
		mtxtStorePhone1.Mask = ""
		'UPGRADE_ISSUE: MSMask.MaskEdBox property mtxtStorePhone1.Format was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'mtxtStorePhone1.form = ""
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        mtxtStorePhone1.Text = IIf(IsDBNull(oRS.Rows(0).Item("store_phone1")), "", VB6.Format(Trim(oRS.Rows(0).Item("store_phone1")), "(###)-###-####"))
		mtxtStorePhone1.Mask = n
		
		n = mtxtStorePhone2.Mask
		mtxtStorePhone2.Mask = ""
		'UPGRADE_ISSUE: MSMask.MaskEdBox property mtxtStorePhone2.Format was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'mtxtStorePhone2.Format = ""
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        mtxtStorePhone2.Text = IIf(IsDBNull(oRS.Rows(0).Item("store_phone2")), "", VB6.Format(Trim(oRS.Rows(0).Item("store_phone2")), "(###)-###-####"))
		mtxtStorePhone2.Mask = n
		
		n = mtxtStoreFax1.Mask
		mtxtStoreFax1.Mask = ""
		'UPGRADE_ISSUE: MSMask.MaskEdBox property mtxtStoreFax1.Format was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'mtxtStoreFax1.Format = ""
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        mtxtStoreFax1.Text = IIf(IsDBNull(oRS.Rows(0).Item("store_fax1")), "", VB6.Format(Trim(oRS.Rows(0).Item("store_fax1")), "(###)-###-####"))
		mtxtStoreFax1.Mask = n
		
		n = mtxtStoreFax2.Mask
		mtxtStoreFax2.Mask = ""
		'UPGRADE_ISSUE: MSMask.MaskEdBox property mtxtStoreFax2.Format was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        'mtxtStoreFax2.Format = ""
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        mtxtStoreFax2.Text = IIf(IsDBNull(oRS.Rows(0).Item("store_fax2")), "", Trim(oRS.Rows(0).Item("store_fax2")))
		mtxtStoreFax2.Mask = n
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        txtStoreContact.Text = IIf(IsDBNull(oRS.Rows(0).Item("store_contact")), "", Trim(oRS.Rows(0).Item("store_contact")))
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        txtStoreFolder.Text = IIf(IsDBNull(oRS.Rows(0).Item("store_folder")), "", Trim(oRS.Rows(0).Item("store_folder")))
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        cbStoreNo.Text = IIf(IsDBNull(oRS.Rows(0).Item("store_number")), "", Trim(oRS.Rows(0).Item("store_number")))
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        txtStoreAddress.Text = IIf(IsDBNull(oRS.Rows(0).Item("store_address")), "", Trim(oRS.Rows(0).Item("store_address")))
		
		For iIndice = 0 To Me.cbState.Items.Count - 1
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If VB6.GetItemString(cbState, iIndice) = IIf(IsDBNull(oRS.Rows(0)("state_id")), "", Trim(oRS.Rows(0)("state_id"))) Then
                cbState.SelectedIndex = iIndice
                Exit For
            End If
		Next iIndice
		
        'cbState.Text = IIf(IsNull(oRS.Rows(0)("state_id")), "", Trim(oRS.Rows(0)("state_id")))
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        txtStoreZip.Text = IIf(IsDBNull(oRS.Rows(0)("store_zip")), "", Trim(oRS.Rows(0)("store_zip")))
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IIf(IsDBNull(oRS.Rows(0)("stORe_status")), "", oRS.Rows(0)("stORe_status")) = "A" Then
            cbStoreStatus.SelectedIndex = 1
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        ElseIf IIf(IsDBNull(oRS.Rows(0)("state_status")), "", oRS.Rows(0)("state_status")) = "I" Then
            cbStoreStatus.SelectedIndex = 2
        Else
            cbStoreStatus.SelectedIndex = 0
        End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        txtStoreCoCode.Text = IIf(IsDBNull(oRS.Rows(0)("store_co_code")), "", oRS.Rows(0)("store_co_code"))
		show_equipment()
		
	End Sub
	
	
	Private Sub show_equipment()
        Dim cmd As SqlCommand = cn.CreateCommand()
		'    On Error GoTo ErrorHandler
		SSTab1.SelectedIndex = 0
        Dim rsLocal As DataTable
		
        sStmt = "SELECT tb1.eqpt_desc as Equipment, tb1.load_id as [Load Type], " & " tb2.content_desc, tb1.eqpt_qty as Qty, " & " tb1.eqpt_temp as [Permanent/Temporary], tb1.eqpt_seq as Seq" & " FROM storeEqpt tb1 INNER JOIN content tb2" & " ON (tb1.content_id = tb2.content_id) " & " WHERE cust_id = '" & oRS.Rows(0)("cust_id") & "'" & " AND store_id = " & oRS.Rows(0)("store_id") & " " & " AND eqpt_status = 'A' " & " ORDER BY eqpt_seq"
        cmd.CommandText = sStmt
		'UPGRADE_NOTE: Object dgEquipment.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		dgEquipment.DataSource = Nothing
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader()
		
        If rsLocal.Rows.Count > 0 Then
            dgEquipment.DataSource = rsLocal
        Else
            'UPGRADE_NOTE: Object dgEquipment.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            dgEquipment.DataSource = rsLocal
            Exit Sub
        End If
		
		'Format Datagrid
		'    dgEquipment.Columns("eqpt_desc").Text = "Equipment"
		'    dgEquipment.Columns("load_id").Text = "Load Type"
		'    dgEquipment.Columns("content_desc").Text = "Content"
		'    dgEquipment.Columns("eqpt_qty").Text = "Qty"
		'    dgEquipment.Columns("eqpt_temp").Text = "Permanent/Temporary"
		'    dgEquipment.Columns("eqpt_seq").Text = "Seq."
		
		dgEquipment.Columns("Equipment").Width = VB6.TwipsToPixelsX(1000)
		dgEquipment.Columns("Load Type").Width = VB6.TwipsToPixelsX(1200)
		dgEquipment.Columns("Content").Width = VB6.TwipsToPixelsX(3000)
		dgEquipment.Columns("Qty").Width = VB6.TwipsToPixelsX(1000)
		dgEquipment.Columns("Permanent/Temporary").Width = VB6.TwipsToPixelsX(2000)
		dgEquipment.Columns("Seq").Width = 0
		
		'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        dgEquipment.Refresh()
		
		'rsLocal.Close
		
		'    Exit Sub
		'
		'ErrorHandler:
		'    save_error Me.name, "load_dgBank"
		'    MsgBox "Unexpected error found while loading Bank Information." + _
		''        vbCrLf + "Review lod file for details.", vbCritical + vbOKOnly, "GLM Error"
		
	End Sub
	
	
	Private Sub show_vendor(ByRef cust_id As String, ByRef store_id As String, ByRef eqpt_seq As String)
		
		SSTab1.SelectedIndex = 1
		
		'    On Error GoTo ErrorHandler
        Dim rsLocal As DataTable
        Dim cmd As SqlCommand = cn.CreateCommand()
        'sStmt = "SELECT '" & Trim(dgEquipment.Columns("Equipment").Text) & "' as Equipment, " & "'" & Trim(dgEquipment.Columns("Load Type").Text) & "' as [Load Type]," & " tb1.account_no as [Account No], tb2.vend_name, tb2.vend_area as Area, " & " tb2.vend_repre as Contact, tb2.vend_phone1 as Phone1, tb2.vend_phone2 as Phone2, " & " tb2.vend_fax1 as Fax1, tb2.vend_fax2 as Fax2, tb2.vend_id, TB2.vend_seq " & " FROM vAccountEqpt tb1 INNER JOIN vBranch tb2 " & " ON (tb1.vend_seq = tb2.vend_seq ) " & " WHERE tb1.cust_id = '" & Trim(cust_id) & "'" & " AND tb1.store_id = '" & Trim(store_id) & "'" & " AND tb1.eqpt_seq='" & Trim(eqpt_seq) & "' "
        sStmt = "SELECT '" & Trim(dgEquipment.Columns("Equipment").Name) & "' as Equipment, " & "'" & Trim(dgEquipment.Columns("Load Type").Name) & "' as [Load Type]," & " tb1.account_no as [Account No], tb2.vend_name, tb2.vend_area as Area, " & " tb2.vend_repre as Contact, tb2.vend_phone1 as Phone1, tb2.vend_phone2 as Phone2, " & " tb2.vend_fax1 as Fax1, tb2.vend_fax2 as Fax2, tb2.vend_id, TB2.vend_seq " & " FROM vAccountEqpt tb1 INNER JOIN vBranch tb2 " & " ON (tb1.vend_seq = tb2.vend_seq ) " & " WHERE tb1.cust_id = '" & Trim(cust_id) & "'" & " AND tb1.store_id = '" & Trim(store_id) & "'" & " AND tb1.eqpt_seq='" & Trim(eqpt_seq) & "' "
        cmd.CommandText = sStmt
        dgVendor.DataSource = Nothing
		
		
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader()
		
        If rsLocal.Rows.Count > 0 Then
            dgVendor.DataSource = rsLocal
        Else
            dgVendor.DataSource = rsLocal
            struct_dgVendor()
            struct_dgServices()
            Exit Sub
        End If
		
		'Format Datagrid
		'    dgVendor.Columns("eqpt_desc").Text = "Equipment"
		'    dgVendor.Columns("load_id").Text = "Load Type"
		'    dgVendor.Columns("account_no").Text = "Account No"
		'    dgVendor.Columns("vend_area").Text = "Area"
		'    dgVendor.Columns("vend_repre").Text = "Contact"
		'    dgVendor.Columns("vend_phone1").Text = "Phone1"
		'    dgVendor.Columns("vend_phone2").Text = "Phone2"
		'    dgVendor.Columns("vend_fax1").Text = "Fax1"
		'    dgVendor.Columns("vend_fax2").Text = "Fax"
		'    dgVendor.Columns("vend_id").Text = "Vend Id"
		
		dgVendor.Columns("Equipment").Width = VB6.TwipsToPixelsX(1000)
		dgVendor.Columns("Load Type").Width = VB6.TwipsToPixelsX(1000)
		dgVendor.Columns("Account No").Width = VB6.TwipsToPixelsX(1000)
		dgVendor.Columns("Area").Width = VB6.TwipsToPixelsX(800)
		dgVendor.Columns("Contact").Width = VB6.TwipsToPixelsX(900)
		dgVendor.Columns("Phone1").Width = VB6.TwipsToPixelsX(1000)
		dgVendor.Columns("Phone2").Width = VB6.TwipsToPixelsX(1000)
		dgVendor.Columns("Fax1").Width = VB6.TwipsToPixelsX(1000)
		dgVendor.Columns("Fax2").Width = VB6.TwipsToPixelsX(1000)
		dgVendor.Columns("vend_id").Width = 0
		dgVendor.Columns("vend_name").Width = 0
		dgVendor.Columns("vend_seq").Width = 0
		
		
		'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        dgVendor.Refresh()
		
		'rsLocal.Close
		
		struct_dgServices()
		
		'    Exit Sub
		'
		'ErrorHandler:
		'    save_error Me.name, "load_dgBank"
		'    MsgBox "Unexpected error found while loading Bank Information." + _
		''        vbCrLf + "Review lod file for details.", vbCritical + vbOKOnly, "GLM Error"
		
	End Sub
	
	
    Private Sub get_dgContractData() '(bInit As Boolean, |                        Optional sCustId As String = "", |                        Optional nStoreId As Integer = 0, |                        Optional nVendSeq As Integer = 0, |                        Optional nEqptSeq As Integer)

        On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand()

        If dgVendor.SelectedRows.Count < 1 Then
            'MsgBox "Please select an Store before attempting this command", vbCritical, "GLM Error"
            struct_dgServices()
            Exit Sub
        End If

        sStmt = "SELECT " & " RTRIM(VBranch.vend_name)+ ' - ' +RTRIM (VBranch.vend_area)  AS Vendor, " & " StoreEqpt.eqpt_desc AS Equipment, " & " Content.content_desc AS Content , " & " Service.serv_desc AS Service, " & " VContract.curr_rate AS Rate, " & " VContract.old_rate AS 'Prev Rate', " & " VContract.opening_date AS Started, " & " VContract.expiration_date AS Until "

        '" dbo.format_freq2 (Frequency.freq_sched_flag, " + _
        '" Frequency.freq_times_flag, " + _
        '" VContract.freq_times, " + _
        '" ISNULL(VContract.freq_period,''), " + _
        '" ISNULL(VContract.freq_day1,''), " + _
        '" ISNULL(VContract.freq_day2,''), " + _
        '" ISNULL(VContract.freq_day3,''), " + _
        '" ISNULL(VContract.freq_day4,''), " + _
        '" ISNULL(VContract.freq_day5,''), " + _
        '" ISNULL(VContract.freq_day6,''), " + _
        '" ISNULL(VContract.freq_day7,'')) " + _
        '" AS Frequency," +


        'sStmt = sStmt + _
        '" VContract.cust_id, VContract.store_id, " + _
        '" VContract.vend_seq, VContract.eqpt_seq , " + _
        '" VContract.serv_id , VContract.freq_times, " + _
        '" VContract.freq_period, VContract.freq_day1, " + _
        '" VContract.freq_day2, VContract.freq_day3, " + _
        '" VContract.freq_day4, VContract.freq_day5, " + _
        '" VContract.freq_day6, VContract.freq_day7, " + _
        '" VContract.freq_id, VContract.freq_comments, " + _
        '" VContract.contract_comments, VContract.rate_status,  " + _
        '" VContract.override_exp_flag "

        sStmt = sStmt & " FROM StoreEqpt, VContract, Content, Service, VBranch, Frequency " & " WHERE vContract.cust_id = StoreEqpt.cust_id " & " AND VContract.store_id = StoreEqpt.store_id " & " AND VContract.eqpt_seq = StoreEqpt.eqpt_seq " & " AND StoreEqpt.content_id = Content.content_id " & " AND VContract.serv_id = Service.serv_id " & " AND VContract.vend_seq = VBranch.vend_seq " & " AND VContract.cust_id = '" & Trim(oRS.Rows(0)("cust_id")) & "' " & " AND VContract.store_id = " & Str(oRS.Rows(0)("store_id")) & " " & " AND VContract.freq_id = Frequency.freq_id "

        'Solo se incluye si usuario selecciono un Vendor
        'If nVendSeq > 0 Then
        sStmt = sStmt & " AND VContract.vend_seq = " & Str(CDbl(dgVendor.SelectedRows(0).Cells("vend_seq").Value))
        'End If

        'Se agrega si ha seleccionado un equipo.
        'If nEqptSeq > 0 Then
        sStmt = sStmt & " AND VContract.eqpt_seq = " & Str(CDbl(dgEquipment.SelectedRows(0).Cells("seq").Value))
        'End If

        'MsgBox sStmt

        'If bInit Then
        '    sStmt = sStmt + " AND VContract.eqpt_seq = -1"
        'End If

        Dim rsContract As DataTable

        'UPGRADE_NOTE: Object Me.dgService.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        Me.dgService.DataSource = Nothing
        cmd.CommandText = sStmt
        rsContract = getDataTable(sStmt) 'cmd.ExecuteReader()

        'If rsContract.Rows.Count > 0 Then
        dgService.DataSource = rsContract
        'End If

        'Formato
        '    dgContract.Columns("cust_id").Visible = False
        '    dgContract.Columns("store_id").Visible = False
        '    dgContract.Columns("vend_seq").Visible = False
        '    dgContract.Columns("eqpt_seq").Visible = False
        '    dgContract.Columns("serv_id").Visible = False
        '    dgContract.Columns("freq_times").Visible = False
        '    dgContract.Columns("freq_period").Visible = False
        '    dgContract.Columns("freq_day1").Visible = False
        '    dgContract.Columns("freq_day2").Visible = False
        '    dgContract.Columns("freq_day3").Visible = False
        '    dgContract.Columns("freq_day4").Visible = False
        '    dgContract.Columns("freq_day5").Visible = False
        '    dgContract.Columns("freq_day6").Visible = False
        '    dgContract.Columns("freq_day7").Visible = False
        '    dgContract.Columns("freq_id").Visible = False
        '    dgContract.Columns("freq_comments").Visible = False
        '    dgContract.Columns("contract_comments").Visible = False
        '    dgContract.Columns("rate_status").Visible = False
        '    dgContract.Columns("override_exp_flag").Visible = False

        dgService.Columns("Vendor").Width = VB6.TwipsToPixelsX(2000)
        dgService.Columns("Equipment").Width = VB6.TwipsToPixelsX(1000)
        dgService.Columns("Content").Width = VB6.TwipsToPixelsX(800)
        dgService.Columns("Service").Width = VB6.TwipsToPixelsX(1300)
        dgService.Columns("Rate").Width = VB6.TwipsToPixelsX(850)
        dgService.Columns("Prev Rate").Width = VB6.TwipsToPixelsX(850)
        dgService.Columns("Started").Width = VB6.TwipsToPixelsX(1000)
        dgService.Columns("Until").Width = VB6.TwipsToPixelsX(1000)

        'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        dgService.Refresh()
        Exit Sub

ErrorHandler:
        'save_error Me.name, "get_dgContract"
        'MsgBox "An error occurred while accessing contract table," + _
        '"check log file for details.", vbCritical + vbOKOnly, " GLM Error"
    End Sub
	
	Private Sub load_comp()
		Dim nCounter As Short
        Dim rsLocal As DataTable
		
		nCounter = 0
		
		'Combos cbCustId, cbCustName
		sStmt = "SELECT DISTINCT suser_data.cust_id, customer.cust_name " & "FROM customer, suser_data " & "WHERE customer.cust_id = suser_data.cust_id " & "AND suser_data.suser_name='" & Trim(gsUser) & "'"
		
		rsLocal = exec_sql(sStmt)
		
        If Not rsLocal.Rows.Count > 0 Then
            MsgBox("Your Account does not have access to such Information." & vbCrLf & "Contact your System Administrator to get proper access.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
            Exit Sub
        End If
		
		
		'En caso de haber datos
		cbCustId.Items.Clear()
		cbCustName.Items.Clear()
		
		cbCustId.Items.Add("<All>")
		cbCustName.Items.Add("<All>")

        For row As Integer = 0 To rsLocal.Rows.Count - 1
            cbCustId.Items.Add(rsLocal.Rows(row).Item("cust_id")) ', nCounter
            cbCustName.Items.Add(rsLocal.Rows(row).Item("cust_name")) ', nCounter
            nCounter = nCounter + 1
        Next


        cbCustName.SelectedIndex = 0
		
	End Sub
	
	
	Private Sub load_storeNo()
		Dim sStmt As String
		
        If cbCustId.SelectedIndex > -1 Then

            sStmt = "SELECT store_number, store_id FROM store"
            If cbCustId.SelectedIndex > 0 Then
                sStmt = sStmt & " WHERE cust_id = '" & cbCustId.Text & "'"
            End If

            load_cb_query4(cbStoreNo, sStmt, 2, True, 100)

            If cbStoreNo.Items.Count > 0 Then
                cbStoreNo.SelectedIndex = 0
            End If

        Else

            Me.cbStoreNo.Items.Clear()

        End If
		
		
	End Sub
	Private Sub txtCustName_Change()
		
	End Sub
	
	Private Sub frmAlert_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		clear_data()
		test_sql()
	End Sub
	Private Sub test_sql()
		
        Dim rsTest As DataTable
        Dim cmTest As SqlCommand = cn.CreateCommand()
        Dim paramTest As SqlParameter

        cmTest.CommandText = "SELECT store_id, store_number FROM store WHERE cust_id = '" + "ND" + "'"


        '("custId", SqlDbType.VarChar, ParameterDirection.Input, 2, "ND")
        paramTest = New SqlParameter("custId", SqlDbType.VarChar, 2, ParameterDirection.Input)
        paramTest.Value = "ND"

        cmTest.Parameters.Add(paramTest)
        'cmTest.Parameters.Append cmTest.CreateParameter("store_id", adInteger, adParamInput, 4)


        'cmTest(0) = "OB"
        'cmTest("store_id") = 16
        'cmTest.Parameters.Refresh
        'MsgBox cmTest(0).value

        'Dim nrecords As Short

        rsTest = getDataTable(cmTest.CommandText) 'getDataTable() 'cmTest.ExecuteReader()
        'MsgBox(rsTest.RecordCount)
        MsgBox(rsTest.Rows(0).Item("store_number"))
		
		
	End Sub
    Private Sub Toolbar2_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "new"

                If oRS Is Nothing Then
                    MsgBox("Please select an Store before attempting this command", MsgBoxStyle.Critical, "GLM Error")
                    Exit Sub
                End If

                'If oRS.EOF Then
                '    MsgBox("Please select an Store before attempting this command", MsgBoxStyle.Critical, "GLM Error")
                '    Exit Sub
                'End If

                gAlertRecord.bFlag = General.modo.NewRecord
                frmAlertEntry.secAlert = 0
                frmAlertEntry.alert_date = CStr(Today)
                frmAlertEntry.alert_message_rtf = ""
                frmAlertEntry.cust_id = oRS.Rows(0)("cust_id").Value
                frmAlertEntry.store_id = oRS.Rows(0)("store_id").Value
                frmAlertEntry.init_vars()
                VB6.ShowForm(frmAlertEntry, VB6.FormShowConstants.Modal, Me)

                show_alert()

            Case "save"

                update_alert()


            Case "search"
                show_alert()

        End Select

    End Sub
	
	
	Private Sub update_alert()
		If oRS Is Nothing Then
			MsgBox("Please select an Store before attempting this command", MsgBoxStyle.Critical, "GLM Error")
			Exit Sub
		End If
		
        'If oRS.EOF Then
        '	MsgBox("Please select an Store before attempting this command", MsgBoxStyle.Critical, "GLM Error")
        '	Exit Sub
        'End If
		
        If dgNotes.SelectedRows.Count < 1 Then
            MsgBox("Please select an Store before attempting this command", MsgBoxStyle.Critical, "GLM Error")
            Exit Sub
        End If
		
		gAlertRecord.bFlag = General.modo.UpdateRecord
		
		
		gAlertRecord.nAlertSeq = 1
        frmAlertEntry.secAlert = CShort(dgNotes.SelectedRows(0).Cells("alert_seq").Value)
        frmAlertEntry.alert_date = dgNotes.SelectedRows(0).Cells("date").Value
        frmAlertEntry.cust_id = oRS.Rows(0)("cust_id").value
        frmAlertEntry.store_id = oRS.Rows(0)("store_id").value
        frmAlertEntry.alert_message_rtf = dgNotes.SelectedRows(0).Cells("Regarding_rtf").Value
		frmAlertEntry.init_vars()
		VB6.ShowForm(frmAlertEntry, VB6.FormShowConstants.Modal, Me)
		
		show_alert()
	End Sub
	
	Private Sub show_alert()
		
        Dim rsTemp As New DataTable("dt1")
        Dim cmd As SqlCommand = cn.CreateCommand
        Dim dCol As DataColumn
		If oRS Is Nothing Then
			MsgBox("Please select an Store before attempting this command", MsgBoxStyle.Critical, "GLM Error")
			Exit Sub
		End If
		
        'If oRS.EOF Then
        '	MsgBox("Please select an Store before attempting this command", MsgBoxStyle.Critical, "GLM Error")
        '	Exit Sub
        'End If
		
        Dim rsNotes As DataTable
		
		'UPGRADE_NOTE: Object dgNotes.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		dgNotes.DataSource = Nothing
		'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        dgNotes.Refresh()
		
        sStmt = "SELECT alert_date as Date, alert_message_rtf as Regarding, ' ' as Regarding_txt, alert_seq" & " FROM alert " & " WHERE " & "  cust_id = '" & Trim(oRS.Rows(0)("cust_id").value) & "' " & " AND store_id = " & Str(oRS.Rows(0)("store_id").value) & " " & " AND (alert_date between '" & dtFrom.Value & "' AND '" & dtTo.Value & CDbl("') ") + IIf(Trim(txtMessage.Text) <> "", " AND alert_message_rtf like '%" & txtMessage.Text & "%'", "") + CDbl(" ORDER BY alert_seq ")
        cmd.CommandText = sStmt
		
        rsNotes = getDataTable(sStmt) 'cmd.ExecuteReader()
		
        dCol = New DataColumn("Date")
        dCol.DataType = System.Type.GetType("System.String")

        dCol.ColumnName = "Date"

        rsTemp.Columns.Add(dCol) '.Append("Date", ADODB.DataTypeEnum.adBSTR)
        rsTemp.Columns.Add("Regarding", System.Type.GetType("System.String")) 'Item.Append("Regarding", ADODB.DataTypeEnum.adBSTR)
        rsTemp.Columns.Add("Alert_seq", System.Type.GetType("System.String"))
        rsTemp.Columns.Add("Regarding_rtf", System.Type.GetType("System.String"))
        'rsTemp.Open()
		
		'Dim lNotes As clNotes
		

        'While rsNotes.Read()
        For Each dr As DataRow In rsNotes.Rows
            Dim drowTmp As DataRow = rsTemp.NewRow()

            drowTmp("Date") = IIf(IsDBNull(dr.Item("date")), "", dr.Item("date"))
            drowTmp("Regarding_rtf") = IIf(IsDBNull(dr.Item("Regarding")), "", dr.Item("Regarding"))

            tmpRitchTxt.Text = IIf(IsDBNull(dr.Item("Regarding")), "", dr.Item("Regarding"))
            drowTmp("Regarding") = tmpRitchTxt.Text

            drowTmp("alert_Seq").value = IIf(IsDBNull(dr.Item("alert_seq")), "", dr.Item("alert_seq"))
            rsTemp.Rows.Add(drowTmp)
        Next dr

        'End While


        dgNotes.DataSource = rsTemp

        dgNotes.Columns("Date").Width = VB6.TwipsToPixelsX(1000)
        dgNotes.Columns("Regarding").Width = VB6.TwipsToPixelsX(9000)
        dgNotes.Columns("Regarding_rtf").Width = 0
        dgNotes.Columns("Regarding_rtf").Visible = False
        dgNotes.Columns("alert_seq").Width = 0
        dgNotes.Columns("alert_seq").Visible = False


        'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        dgNotes.Refresh()
        Exit Sub
		
	End Sub

    Private Sub btFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFind.Click

    End Sub

    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click

    End Sub

    Private Sub btFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFirst.Click

    End Sub

    Private Sub btBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBack.Click

    End Sub

    Private Sub btForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btForward.Click

    End Sub

    Private Sub btLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLast.Click

    End Sub

    Private Sub _SSTab1_TabPage0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _SSTab1_TabPage0.Click

    End Sub
End Class