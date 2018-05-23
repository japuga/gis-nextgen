Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Friend Class frmInvoiceBookingDet
	Inherits System.Windows.Forms.Form
	'Option Base 1
	Private bError As Boolean 'Error en el modulo
    Private rsLocal As DataTable
    Private rsLocalRate As DataTable
    Private rsLocalService As DataTable
    Private Rate_Renamed As gRateUDT
    Private aService As gTableUDT

	Const MAXDECIMALS As Short = 4
	
	
	'Carga combo de equipos
	Private Sub load_combo_eqpt()
        'Equipos disponibles para esta tienda y vendor
        Dim sExpirationDate As String = gInvHeaderRecord.dInvoiceDate.ToShortDateString
        sStmt = " SELECT DISTINCT e.eqpt_desc, e.eqpt_seq " & " FROM VContract c, StoreEqpt e" & _
                " WHERE e.cust_id = c.cust_id " & " AND e.store_id = c.store_id " & " AND e.eqpt_seq = c.eqpt_seq " & " AND e.eqpt_status = 'A' " & _
                        " AND (c.expiration_date >= '" & sExpirationDate & "' " & "    OR c.override_exp_flag ='YES') " & _
                        " AND c.cust_id = '" & gInvHeaderRecord.sCustId & "' " & " AND c.store_id = '" & Str(gInvHeaderRecord.nStoreId) & "' " & " AND c.vend_seq = " & Str(gInvHeaderRecord.nVendSeq) & " ORDER BY e.eqpt_desc "
        cbEquipDet.Items.Clear()
		cbEquipDet.Items.Insert(0, "<None>")
		load_cb_query2(cbEquipDet, sStmt, 2, False)
		
		cbEquipDet.SelectedIndex = 0
		
	End Sub
	
    Private Sub cbEquipDet_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbEquipDet.SelectedIndexChanged
        lookup_eqpt(gInvHeaderRecord.sCustId, gInvHeaderRecord.nStoreId, VB6.GetItemData(cbEquipDet, cbEquipDet.SelectedIndex))
        'Actualizo servicios para este equipo
        load_combo_service(cbServDet, VB6.GetItemData(cbEquipDet, cbEquipDet.SelectedIndex))
    End Sub
	'Busca informacion de equipo
	Private Sub lookup_eqpt(ByRef sCustId As String, ByRef nStoreId As Short, ByRef nEqptSeq As Short)
		
		On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand()
		lbContent.Text = ""
		sStmt = "SELECT content_desc FROM StoreEqpt,Content " & "WHERE StoreEqpt.content_id = Content.content_id " & " AND StoreEqpt.cust_id = '" & sCustId & "' " & " AND StoreEqpt.store_id = " & Str(nStoreId) & " " & " AND StoreEqpt.eqpt_seq = " & Str(nEqptSeq)
        cmd.CommandText = sStmt
		
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count > 0 Then
            lbContent.Text = rsLocal.Rows(0).Item("content_desc")
        End If

        Exit Sub

ErrorHandler:
        lbContent.Text = ""
        save_error(Me.Name, "Lookup_eqpt")
        MsgBox("Minor internal failure. Check log file for details.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Warning")
	End Sub
	
	'This combo loads each time that an equipment is selected
	Public Sub load_combo_service(ByRef cb As System.Windows.Forms.ComboBox, ByRef nEqptSeq As Short)
		Dim sStmtService As String
		
		On Error GoTo ErrorHandler
		
		If nEqptSeq <= 0 Then 'Equipo <None>
            sStmt = " SELECT serv_desc, serv_id , " & " serv_measure_unit, serv_rate_contract " & " FROM service " & " WHERE serv_eqpt ='F' " & _
                    " ORDER BY serv_desc "
			
            sStmtService = " SELECT  serv_id , serv_desc," & " serv_measure_unit, serv_rate_contract " & _
                " FROM service " & " WHERE serv_eqpt ='F' " & " ORDER BY serv_desc"
		Else
            Dim sExpDate As String = gInvHeaderRecord.dInvoiceDate.ToShortDateString
			'Just services for this equipment
            sStmt = " SELECT DISTINCT s.serv_desc, s.serv_id, " & " s.serv_measure_unit, s.serv_rate_contract " & _
                " FROM VContract c, StoreEqpt e, Service s" & _
                " WHERE e.cust_id = c.cust_id " & " AND e.store_id = c.store_id " & " AND e.eqpt_seq = c.eqpt_seq " & " AND c.serv_id = s.serv_id " & " AND e.eqpt_status = 'A' " & _
                    " AND (c.expiration_date >= '" & sExpDate & "' " & "    OR c.override_exp_flag ='YES') " & _
                    " AND c.cust_id = '" & gInvHeaderRecord.sCustId & "' " & " AND c.store_id = '" & Str(gInvHeaderRecord.nStoreId) & "' " & _
                    " AND c.vend_seq = " & Str(gInvHeaderRecord.nVendSeq) & " AND c.eqpt_seq = " & Str(nEqptSeq) & _
                " ORDER BY s.serv_desc"
			
            sStmtService = " SELECT DISTINCT  s.serv_id, s.serv_desc," & " s.serv_measure_unit, s.serv_rate_contract " & _
                            " FROM VContract c, StoreEqpt e, Service s" & _
                            " WHERE e.cust_id = c.cust_id " & " AND e.store_id = c.store_id " & " AND e.eqpt_seq = c.eqpt_seq " & _
                                " AND c.serv_id = s.serv_id " & " AND e.eqpt_status = 'A' " & _
                                " AND (c.expiration_date >= '" & sExpDate & "' " & _
                                    "    OR c.override_exp_flag ='YES') " & _
                                " AND c.cust_id = '" & gInvHeaderRecord.sCustId & "' " & " AND c.store_id = '" & Str(gInvHeaderRecord.nStoreId) & "' " & _
                                " AND c.vend_seq = " & Str(gInvHeaderRecord.nVendSeq) & " AND c.eqpt_seq = " & Str(nEqptSeq) & _
                            " ORDER BY s.serv_desc"
			
		End If
		
		load_cb_query2(cb, sStmt, 2, True)
		load_array_query(aService, sStmtService, 1, 3, 0, True)
		
		cb.SelectedIndex = 0 'Default to first service
		
		If gInvDetRecord.bMode = General.detmode.UpdateRecord Then
			'Point to selected service
			set_cb_ItemData(cb, gInvDetRecord.nService)
		End If
		
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "Load_combo_service")
		
	End Sub
	
	'UPGRADE_WARNING: Event cbServDet.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbServDet_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbServDet.SelectedIndexChanged
		
        'lbServTypeDet = aService.aRecord(cbServDet.ListIndex).str_field2
        lbServTypeDet.Text = aService.aRecord(cbServDet.SelectedIndex).str_field2
		'Mapping : serv_measure_unit= str_field2
		If cbServDet.SelectedIndex > MAX_MEM_RECORD Then
			MsgBox("Attempt to access element not existing in array. MAX_MEM_RECORD exceeded.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Sub
		End If
        'aService.Initialize()
        If IsDBNull(aService.aRecord(cbServDet.SelectedIndex).str_field2) Or aService.aRecord(cbServDet.SelectedIndex).str_field2 = "" Then
            lbServTypeDet.Text = "N/A"
        Else
            lbServTypeDet.Text = aService.aRecord(cbServDet.SelectedIndex).str_field2
        End If
		
		'Enable Benchmark and Current Rate
		'Mapping : serv_rate_contract = str_field3
		If aService.aRecord(cbServDet.SelectedIndex).str_field3 = "T" Then
			txtRateDet.Enabled = False
			txtGlmRateDet.Enabled = False
		Else
			txtRateDet.Enabled = True
			txtGlmRateDet.Enabled = True
		End If
		
		'-----------------------------
		'Service Unit Type
		'If rsLocalService.State <> adStateClosed Then
		'    rsLocalService.Close
		'End If
		'rsLocalService.Open sStmtService, cn, adOpenStatic, adLockReadOnly
		'If rsLocalService.State <> adStateOpen Then
		'Do nothing
		'Else
        '    If IsNull(rsLocalService.item("serv_measure_unit")) Then
		'        lbServTypeDet = "N/A"
		'    Else
        '        lbServTypeDet = rsLocalService.item("serv_measure_unit")
		'    End If
		
		'Habilitar campos Benchmark y Current Rate
        '    If rsLocalService.item("serv_rate_contract") = "T" Then
		'        txtRateDet.Enabled = False
		'    Else
		'        txtRateDet.Enabled = True
		'    End If
		'End If
		
		'-----------------------------
		getRate(VB6.GetItemData(cbServDet, cbServDet.SelectedIndex), VB6.GetItemData(cbEquipDet, cbEquipDet.SelectedIndex))
		txtOldRateDet.Text = CStr(Rate_Renamed.old_rate)
		txtRateDet.Text = CStr(Rate_Renamed.Rate_Renamed)
		txtGlmRateDet.Text = CStr(Rate_Renamed.GlmRate)
	End Sub
	
	'Displays rates for the service/equipment
	Private Function getRate(ByRef nService As Short, ByRef nEquipment As Short) As gRateUDT
		
		On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand()
		Rate_Renamed.old_rate = 0#
		Rate_Renamed.Rate_Renamed = 0#
		Rate_Renamed.GlmRate = 0#
		
		'Verify parameters
		'nEquipment is zero when equipment is <NONE>
		If nService = 0 Or nEquipment = 0 Then
			Exit Function
		End If
		
        'Search

        'rsLocalRate.Filter = "eqpt_seq = " & Str(nEquipment)
        'rsLocalRate.
        For row As Integer = 0 To rsLocalRate.Rows.Count - 1
            If (rsLocalRate.Rows(row).Item("serv_id") = nService) And (rsLocalRate.Rows(row).Item("eqpt_seq") = nEquipment) Then
                If Not IsDBNull(rsLocalRate.Rows(row).Item("old_rate")) Then
                    Rate_Renamed.old_rate = rsLocalRate.Rows(row).Item("old_rate")
                End If

                If Not IsDBNull(rsLocalRate.Rows(row).Item("curr_rate")) Then
                    Rate_Renamed.Rate_Renamed = rsLocalRate.Rows(row).Item("curr_rate")
                End If

                If Not IsDBNull(rsLocalRate.Rows(row).Item("glm_rate")) Then
                    Rate_Renamed.GlmRate = rsLocalRate.Rows(row).Item("glm_rate")
                End If

                Exit For
            End If
        Next row

        'rsLocalRate.Filter = ADODB.FilterGroupEnum.adFilterNone

        Exit Function

ErrorHandler:
        save_error("frmInvoiceBooking", "getRate")
        MsgBox("An error has ocurred while retrieving rate info.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
        Resume Next
    End Function
	
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub cmdDetail_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDetail.Click
		
		If cbServDet.SelectedIndex >= 0 Then
			If isWeightService(VB6.GetItemData(cbServDet, cbServDet.SelectedIndex)) Then
				
				If invoiceSaved(gInvHeaderRecord.sInvoiceNo, gInvHeaderRecord.sCustId, gInvHeaderRecord.nStoreId, gInvHeaderRecord.sAccountNo, gInvHeaderRecord.nVendSeq, gInvDetRecord.nInvoiceDetNo) Then
					VB6.ShowForm(frmInvoiceBookingDetWgt, VB6.FormShowConstants.Modal, Me)
				Else
					MsgBox("Please save Invoice before entering Weights.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Warning")
				End If
			Else
				MsgBox("This service has not been defined for Weight data entry.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Warning")
			End If
		Else
			MsgBox("Please select a service before attempting this command.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Warning")
		End If
		
		
	End Sub
	Private Function invoiceSaved(ByRef sInvoiceNo As String, ByRef sCustId As String, ByRef nStoreId As Short, ByRef sAccountNo As String, ByRef nVendSeq As Short, ByRef nInvoiceDetNo As Short) As Boolean
		
        Dim cmd As SqlCommand = cn.CreateCommand()
		invoiceSaved = False
		
		sStmt = "SELECT 1 FROM vInvoiceDet " & " WHERE cust_id = '" & Trim(sCustId) & "' " & " AND invoice_no = '" & sInvoiceNo & "'" & " AND store_id = " & Str(nStoreId) & " AND account_no = '" & sAccountNo & "' " & " AND vend_seq = " & Str(nVendSeq) & " AND invoice_det_no = " & Str(nInvoiceDetNo)
        cmd.CommandText = sStmt
		
        rs = getDataTable(sStmt) ' = cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.Rows.Count > 0 Then
            invoiceSaved = True
        End If

		
	End Function
	
	Private Sub set_rsDetailWgt(ByRef sInvoiceNo As String, ByRef sCustId As String, ByRef nStoreId As Short, ByRef sAccountNo As String, ByRef nVendSeq As Short, ByRef nInvoiceDetNo As Short)
		
		sStmt = "SELECT sequence_id, weight as 'Weight', " & " ticket as 'Ticket', ticket_date as 'Date' " & " FROM vInvoiceDetWgt " & " WHERE cust_id = '" & Trim(sCustId) & "' " & " AND invoice_no = '" & sInvoiceNo & "'" & " AND store_id = " & Str(nStoreId) & " AND account_no = '" & sAccountNo & "' " & " AND vend_seq = " & Str(nVendSeq) & " AND invoice_det_no = " & Str(nInvoiceDetNo) & " ORDER BY sequence_id "
		
		'If gInvDetRecord.rsDetailWgt.State = adStateOpen Then
		'    gInvDetRecord.rsDetailWgt.Close
		'End If
		'gInvDetRecord.rsDetailWgt.Open sStmt, cn, adOpenStatic, adLockBatchOptimistic
		'If gInvDetRecord.rsDetailWgt.State = adStateOpen Then
		'End If
		
		
		
		
	End Sub
	Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click
		If check_info Then
			If save_info Then
				'Nice, no errors
				gInvDetRecord.bMode = General.detmode.SavedRecord
			Else
				gInvDetRecord.bMode = General.detmode.FailedRecord
			End If
			Me.Close()
		End If
		
	End Sub
	
	'All data is verified when pressing Save button
	Private Function check_info() As Boolean
		check_info = True
		'Usage
        If IsDBNull(txtUsageDet.Text) Or txtUsageDet.Text = "" Then
            MsgBox("Usage should be greater than zero.", MsgBoxStyle.Information, "GLM Warning")
            check_info = False
            Exit Function
        Else
            If CDbl(txtUsageDet.Text) <= 0.0# Then
                MsgBox("Usage should be greater than zero.", MsgBoxStyle.Information, "GLM Warning")
                check_info = False
                Exit Function
            End If
        End If
		If max_fraction2(txtUsageDet.Text, MAXDECIMALS) Then
			txtUsageDet.Text = VB.Left(txtUsageDet.Text, InStr(1, txtUsageDet.Text, ".", CompareMethod.Text) + MAXDECIMALS)
		End If
		
		'Units
        If IsDBNull(txtUnitsDet.Text) Or txtUnitsDet.Text = "" Then
            MsgBox("Units should be greater than zero.", MsgBoxStyle.Information, "GLM Warning")
            check_info = False
            Exit Function
        Else
            If CDbl(txtUnitsDet.Text) <= 0.0# Then
                MsgBox("Units should be greater than zero.", MsgBoxStyle.Information, "GLM Warning")
                check_info = False
                Exit Function
            End If
        End If
		If max_fraction2(txtUnitsDet.Text, MAXDECIMALS) Then
			txtUnitsDet.Text = VB.Left(txtUnitsDet.Text, InStr(1, txtUnitsDet.Text, ".", CompareMethod.Text) + MAXDECIMALS)
		End If
		
		If cbBillSavingFlag.SelectedIndex < 0 Then
			MsgBox("Please select a Billable Saving Option")
			cbBillSavingFlag.Focus()
			check_info = False
			Exit Function
		End If
		
	End Function
	
	'Save data in memory and returns to Invoice header
	Private Function save_info() As Boolean
		
		On Error GoTo ErrorHandler
		
        gInvDetRecord.dServDate = dtServDate.Value
		
        save_info = True
        Dim output As Double = 0
        'PENDIENTE: Verificar datos antes de asignar a cada campo
        If Double.TryParse(txtOldRateDet.Text, output) Then
            gInvDetRecord.nOldRate = Convert.ToDouble(txtOldRateDet.Text)
        Else
            gInvDetRecord.nOldRate = 0
        End If
        'gInvDetRecord.nUnits = CDbl(txtUnitsDet.Text)
        If Double.TryParse(txtUnitsDet.Text, output) Then
            gInvDetRecord.nUnits = Convert.ToDouble(txtUnitsDet.Text)
        Else
            gInvDetRecord.nUnits = 0
        End If
        'gInvDetRecord.nUsage = CDbl(txtUsageDet.Text)
        If Double.TryParse(txtUsageDet.Text, output) Then
            gInvDetRecord.nUsage = Convert.ToDouble(txtUsageDet.Text)
        Else
            gInvDetRecord.nUsage = 0
        End If
        'gInvDetRecord.nRate = CDbl(txtRateDet.Text)
        If Double.TryParse(txtRateDet.Text, output) Then
            gInvDetRecord.nRate = Convert.ToDouble(txtRateDet.Text)
        Else
            gInvDetRecord.nRate = 0
        End If
        'gInvDetRecord.nGlmRate = CDbl(txtGlmRateDet.Text)
        If Double.TryParse(txtGlmRateDet.Text, output) Then
            gInvDetRecord.nGlmRate = Convert.ToDouble(txtGlmRateDet.Text)
        Else
            gInvDetRecord.nGlmRate = 0
        End If

		
		If cbServDet.SelectedIndex >= 0 Then
			gInvDetRecord.nService = CShort(VB6.GetItemData(cbServDet, cbServDet.SelectedIndex))
		Else
			MsgBox("Found an error while loading Service data in Grid.", MsgBoxStyle.Exclamation, "GLM Error")
			save_info = False
			Exit Function
		End If
		
		If cbEquipDet.SelectedIndex >= 0 Then
			gInvDetRecord.nEquipment = VB6.GetItemData(cbEquipDet, cbEquipDet.SelectedIndex)
			gInvDetRecord.sEquipment = cbEquipDet.Text
		Else
			MsgBox("Found an error while loading Equipment data in Grid.", MsgBoxStyle.Exclamation, "GLM Error")
			save_info = False
			Exit Function
		End If
		
		gInvDetRecord.sType = lbServTypeDet.Text 'N/A is ServType was null in DB
		gInvDetRecord.sService = cbServDet.Text
		gInvDetRecord.sComments = txtCommentsDet.Text
		gInvDetRecord.sBillSavingFlag = cbBillSavingFlag.Text
		
		
		Exit Function
		
ErrorHandler: 
		save_info = False
		save_error(Me.Name, "save_info")
		Exit Function
	End Function
	
	Private Sub frmInvoiceBookingDet_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		load_fields(gInvDetRecord.bMode)
	End Sub
	
	'Initialize variables
	Private Sub init_vars()
		'Init Variables
		bError = False
        aService.Initialize()
		txtUnitsDet.Text = VB6.Format(0#, "##,##0.0000")
		txtUsageDet.Text = VB6.Format(0#, "##,##0.0000")

		txtOldRateDet.Enabled = False
		txtRateDet.Enabled = False
		txtGlmRateDet.Enabled = False
		lbContent.Text = ""
		
		'Load controls
		load_combo_eqpt()
		load_contract_info()
		
		sStmt = "SELECT field_option FROM SDomain " & " WHERE domain_field='bill_saving_flag' " & " ORDER BY option_order "
		load_cb_query2(cbBillSavingFlag, sStmt, 1, True)
		If cbBillSavingFlag.Items.Count > 0 Then
			cbBillSavingFlag.SelectedIndex = 0
		End If
		
		If gInvDetRecord.bMode = General.detmode.UpdateRecord And gInvDetRecord.nInvoiceDetNo > 0 Then
			cmdDetail.Enabled = True
		End If
		
	End Sub
	Private Function isWeightService(ByRef nServId As Short) As Boolean
		
		isWeightService = False
        Dim cmd As SqlCommand = cn.CreateCommand()
		sStmt = "SELECT 1 FROM ServiceGroup a, ServiceGroupDet b " & " WHERE a.serv_group_name = 'WEIGHT' " & " AND a.serv_group_id = b.serv_group_id " & " AND b.serv_id = " & Str(nServId)
        cmd.CommandText = sStmt
		
        rs = getDataTable(sStmt) ' cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic)

        If rs.Rows.Count > 0 Then
            isWeightService = True
        End If

		
	End Function
	'Carga datos a partir de la informacion provista por frmInvoiceBooking
	Private Sub load_fields(ByRef nOption As General.detmode)
		
		Select Case nOption
			Case General.detmode.NewRecord
                dtServDate.Value = gInvHeaderRecord.dInvoiceDate
			Case General.detmode.UpdateRecord
                dtServDate.Value = gInvDetRecord.dServDate
				set_cb_ItemData(cbEquipDet, gInvDetRecord.nEquipment)
				txtUsageDet.Text = CStr(gInvDetRecord.nUsage)
				txtUnitsDet.Text = CStr(gInvDetRecord.nUnits)
				'lbServTypeDet = gInvDetRecord.sType
				txtOldRateDet.Text = CStr(gInvDetRecord.nOldRate)
				txtRateDet.Text = CStr(gInvDetRecord.nRate)
				txtGlmRateDet.Text = CStr(gInvDetRecord.nGlmRate)
				txtCommentsDet.Text = gInvDetRecord.sComments
				set_cb(cbBillSavingFlag, gInvDetRecord.sBillSavingFlag)
		End Select
		
	End Sub
	'Carga rsTmp con informacion de tarifas por equipo/servicio del store
	Public Function load_contract_info() As Boolean
		Dim bRates As Boolean
        Dim cmd As SqlCommand = cn.CreateCommand()
		On Error GoTo ErrorHandler
		
		bRates = True
		
		sStmt = "SELECT * FROM vcontract " & "WHERE cust_id ='" & gInvHeaderRecord.sCustId & "' " & "AND store_id =" & Str(gInvHeaderRecord.nStoreId) & " " & "AND vend_seq =" & Str(gInvHeaderRecord.nVendSeq)
        cmd.CommandText = sStmt
        rsLocalRate = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rsLocalRate.Rows.Count > 0 Then
            bRates = False
        End If
		
		Exit Function
		
ErrorHandler: 
		bRates = False
		save_error("frmInvoiceBooking", "load_contract_info")
		MsgBox(gErrDescription, MsgBoxStyle.OKOnly, "GLM Error")
	End Function
	
	
	Private Sub txtGlmRateDet_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtGlmRateDet.Enter
		txtGlmRateDet.SelectionStart = 0
		txtGlmRateDet.SelectionLength = Len(txtGlmRateDet.Text)
		
	End Sub
	
	Private Sub txtOldRateDet_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtOldRateDet.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros, Backspace, Punto
		Dim nPos As Short
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			'Es numero
			'No permitir ingresar mas de 2 decimales
			If (KeyAscii >= 48 And KeyAscii <= 57) And max_fraction(txtOldRateDet.Text) And txtOldRateDet.SelectionLength = 0 Then
				KeyAscii = 0
			End If
		Else
			nPos = InStr(1, txtOldRateDet.Text, ".", CompareMethod.Text)
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If KeyAscii = 46 And (nPos = 0 Or IsDbNull(nPos)) Then
				'continue
			Else
				KeyAscii = 0
			End If
		End If
		
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtRateDet_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtRateDet.Enter
		txtRateDet.SelectionStart = 0
		txtRateDet.SelectionLength = Len(txtRateDet.Text)
		
	End Sub
	
	Private Sub txtRateDet_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtRateDet.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros, Backspace, Punto
		Dim nPos As Short
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			'Es numero
			'No permitir ingresar mas de 2 decimales
			If (KeyAscii >= 48 And KeyAscii <= 57) And max_fraction(txtRateDet.Text) And txtRateDet.SelectionLength = 0 Then
				KeyAscii = 0
			End If
		Else
			nPos = InStr(1, txtRateDet.Text, ".", CompareMethod.Text)
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If KeyAscii = 46 And (nPos = 0 Or IsDbNull(nPos)) Then
				'continue
			Else
				KeyAscii = 0
			End If
		End If
		
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtUnitsDet_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtUnitsDet.Enter
		txtUnitsDet.SelectionStart = 0
		txtUnitsDet.SelectionLength = Len(txtUnitsDet.Text)
	End Sub
	
	Private Sub txtUnitsDet_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtUnitsDet.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros, Backspace, Punto
		Dim nPos As Short
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
			nPos = InStr(1, txtUnitsDet.Text, ".", CompareMethod.Text)
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If KeyAscii = 46 And (nPos = 0 Or IsDbNull(nPos)) Then
				'continue
			Else
				KeyAscii = 0
			End If
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtUnitsDet_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtUnitsDet.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'Format txtUnitsDet, "###.##"
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub txtUsageDet_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtUsageDet.Enter
		txtUsageDet.SelectionStart = 0
		txtUsageDet.SelectionLength = Len(txtUsageDet.Text)
		
	End Sub
	
	Private Sub txtUsageDet_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtUsageDet.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim nPos As Short
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			'Es numero
			'No permitir ingresar mas de 2 decimales
			
			'If (KeyAscii >= 48 And KeyAscii <= 57) _
			''And max_fraction(txtUsageDet) _
			''And txtUsageDet.SelLength = 0 Then
			'    KeyAscii = 0
			'End If
		Else
			nPos = InStr(1, txtUsageDet.Text, ".", CompareMethod.Text)
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If KeyAscii = 46 And (nPos = 0 Or IsDbNull(nPos)) Then
				'continue
			Else
				KeyAscii = 0
			End If
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class