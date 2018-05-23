Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmInvoiceBooking
	Inherits System.Windows.Forms.Form
    Public gsStoreNumber As String
    Public parentCaller As String
    Private rsDetailWgt As SqlDataReader
    Private rsDetail As DataTable
    Private rsDetailClone As DataTable
    Private cmDetail As SqlCommand
	Private sTmp As String
    Private rsTmp As DataTable
    Private cnTmp As SqlConnection
    Private cmTmp As SqlCommand
    Private rsLocal As DataTable
	Private bClearAll As Boolean
	Private bInvoiceSaved As Boolean
    Private WithEvents sdfService As DataGridViewCellStyle 'StdFormat.StdDataFormat
    Private WithEvents sdfEquipment As DataGridViewCellStyle 'StdFormat.StdDataFormat
    Private WithEvents sdfDate As DataGridViewCellStyle 'StdFormat.StdDataFormat
    Private WithEvents sdfTons As DataGridViewCellStyle 'StdFormat.StdDataFormat
    Private WithEvents sdfUnits As DataGridViewCellStyle 'StdFormat.StdDataFormat
    Private WithEvents sdfTimes As DataGridViewCellStyle 'StdFormat.StdDataFormat
	Private bRates As Boolean 'TRUE si la informacion de tarifas se cargo exitosa..
	Private nClicks As Short
	Private nClicksVendor As Short
	Private nClicksAccount As Short
	Private sPrevState As String
	Private sCurrState As String
	Private sPrevVendor As String
	Private sCurrVendor As String
	Private sPrevAccount As String
    Private sCurrAccount As String
    Private bindingSource1 As New BindingSource()
    Private daDetail As SqlDataAdapter
    Private scbDetail As SqlCommandBuilder



	Public Enum mode
		adInsert = 0
		adUpdate = 1
	End Enum
	Public nMode As mode
	'Tipo de dato para manejar rates
	Private Structure rateUDT
		Dim old_rate As Double
		'UPGRADE_NOTE: Rate was upgraded to Rate_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim Rate_Renamed As Double
	End Structure
	Private bReaction As Boolean
	Private nUpdateRate As Short
	Private bCbSet As Boolean 'Determina si el combo (equipment/service)
	'ha sido modificado por usuario
	Public sNotes As String 'Guarda los comentarios de usuario con relacion
	'a la factura
	Private del_dg_rows(10) As Object
	Private vBookmark As Object
	Private bRequiresUpdate As Boolean
	Private bLastDeleted As Boolean
	Private vMark As Object
    Public bImportedFromLF As Boolean
    Private ignoreStateValidation As Boolean = False
	
	
	
	'UPGRADE_WARNING: Event cbAccount.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbAccount_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbAccount.SelectedIndexChanged
		If nClicksAccount = 0 Then
			sCurrAccount = cbAccount.Text
		Else
			sPrevAccount = sCurrAccount
			sCurrAccount = cbAccount.Text
			If sPrevAccount <> cbAccount.Text Then
				If MsgBox("This change will clear all detail records, do you to proceed?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "GLM Warning") = MsgBoxResult.Yes Then
					clear_form("DETAIL")
				Else
					sCurrAccount = sPrevAccount
					cbAccount.Text = sPrevAccount
					Exit Sub
				End If
			End If
		End If
		nClicksAccount = nClicksAccount + 1
		
	End Sub
	

	Private Sub cbCustomer_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustomer.SelectedIndexChanged
        Dim cmd As SqlCommand = cn.CreateCommand()
		On Error GoTo ErrorHandler
		
		If cbCustomer.SelectedIndex < 0 Then
			cbPeriod.Items.Clear()
			cbState.Items.Clear()
			Exit Sub
		End If
		
		'STATE
		sStmt = "SELECT DISTINCT state_id FROM suser_data " & "WHERE suser_data.suser_name ='" & gsUser & "' " & "AND suser_data.cust_id = '" & Trim(cbCustomer.Text) & "' " & "ORDER BY 1"
		
		load_cb_query2(cbState, sStmt, 1, True)
		If cbState.Items.Count > 0 Then
			cbState.SelectedIndex = 0
		End If
		
		'PERIODOS
		'Limpiar descripcion de fechas
		lbStartDate.Text = ""
		lbEndDate.Text = ""
		
		'Sincronizar lista de Periodos para este cliente
		sStmt = "SELECT period_name, period_seq, period_start_date, period_end_date " & " FROM period  " & " WHERE cust_id ='" & Trim(cbCustomer.Text) & "' " & " AND period_status_id ='O' " & " ORDER BY period_start_date DESC "
		
		load_cb_query2(cbPeriod, sStmt, 2, True)
		If cbPeriod.Items.Count > 0 Then
			
			sStmt = "SELECT period_name, period_seq, period_start_date  " & " FROM period  WHERE cust_id ='" & Trim(cbCustomer.Text) & "' " & " AND period_status_id ='O' " & " AND period_start_date <= getdate() " & " ORDER BY period_start_date DESC "

			'MsgBox sStmt
            cmd.CommandText = sStmt
            rs = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rs.Rows.Count > 0 Then
                set_cb_ItemData(cbPeriod, rs.Rows(0).Item("period_seq"))
            Else
                cbPeriod.SelectedIndex = 0
            End If


        Else
            If cbPeriod.Items.Count = 0 Then
                MsgBox("No Invoicing Period was found for customer:" & cbCustomer.Text & vbCrLf & "This information could be entered in the Invoicing Period Menu.", MsgBoxStyle.Question + MsgBoxStyle.OkOnly, "GLM Message")
            End If
        End If

        load_cbGroupName(cbCustomer.Text)
        If cbGroupName.Items.Count > 0 Then
            cbGroupName.SelectedIndex = 0
        End If
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "cbCustomer.click")
        Exit Sub
	End Sub
	Private Sub load_cbGroupName(ByRef sCustId As String)
		
		sStmt = "SELECT group_name, group_seq FROM vInvoiceGroup " & " WHERE cust_id='" & sCustId & "' " & " AND group_status= 'OPEN'"
		load_cb_query2(cbGroupName, sStmt, 2, True)
	End Sub
	Private Sub cbCustomer_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles cbCustomer.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		Dim sText As String
		Dim bFound As Boolean
		Dim i As Short
		
		On Error GoTo ErrorHandler
		
		bFound = False
		sText = UCase(cbCustomer.Text)
		For i = 0 To cbCustomer.Items.Count - 1
			If sText = VB6.GetItemString(cbCustomer, i) Then
				bFound = True
				cbCustomer.SelectedIndex = i
				Exit For
			End If
		Next i
		
		If bFound = False Then
			MsgBox("Please select a customer from the list.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Warning")
			If cbCustomer.Items.Count > 0 Then
				cbCustomer.SelectedIndex = 0
			End If
			Cancel = True
		End If
		GoTo EventExitSub
		
ErrorHandler: 
		save_error(Me.Name, "cbCUstomer.Validate")
		MsgBox("Unexpected error. Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	
	
	'UPGRADE_WARNING: Event cbEquipment.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbEquipment_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbEquipment.SelectedIndexChanged
		If cbEquipment.SelectedIndex >= 0 Then
			'Text1 = Text1 + vbCrLf + "cbequipment.click"
			'09/03/2002 ancla
			load_combo2(cbService, VB6.GetItemData(cbEquipment, cbEquipment.SelectedIndex))
			'Rel 1.3 - Begin
			'dgDetail.Columns("Equipment").Value = cbEquipment.ItemData(cbEquipment.ListIndex)
            dgDetail.Columns("Equipment").HeaderText = VB6.GetItemData(cbEquipment, cbEquipment.SelectedIndex)
            dgDetail.Columns("Equip").HeaderText = cbEquipment.Text
			'Rel 1.3 - End
			
			
			If bCbSet Then
				'NO fue el usuario
			Else
				getRateVal()
				enable_col(("Rate"))
			End If
			bCbSet = False
			getSubtotal()
			calc_total()
		End If
		
		
	End Sub
	
	Private Sub cbEquipment_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cbEquipment.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Deshabilito el teclado
		'KeyAscii = 0
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
    Private Sub cbPeriod_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriod.SelectedIndexChanged
        On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand

        sStmt = "SELECT period_name, period_seq, period_start_date, period_end_date " & " FROM period  WHERE cust_id ='" & Trim(cbCustomer.Text) & "' " & " AND period_seq =" & Str(VB6.GetItemData(cbPeriod, cbPeriod.SelectedIndex))
        cmd.CommandText = sStmt
        rsLocal = getDataTable(sStmt) ' cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)


        If rsLocal.Rows.Count > 0 Then
            lbStartDate.Text = rsLocal.Rows(0).Item("period_start_date")
            lbEndDate.Text = rsLocal.Rows(0).Item("period_end_date")
        End If

        Exit Sub

ErrorHandler:
        save_error(Me.Name, "cbPeriod.click")
        Exit Sub
    End Sub
	
    Private Sub cbService_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbService.SelectedIndexChanged
        If cbService.SelectedIndex >= 0 Then
            'Rel 1.3 - Begin ********************
            'dgDetail.Columns("Service").Value = cbService.ItemData(cbService.ListIndex)
            dgDetail.Columns("Service").HeaderText = VB6.GetItemData(cbService, cbService.SelectedIndex)
            dgDetail.Columns("Serv").HeaderText = cbService.Text
            'Rel 1.3 - End **********************
            If bCbSet Then
                'No fue Usuario
            Else
                getRateVal()
                enable_col(("Rate"))
            End If
            bCbSet = False
            getSubtotal()
            'Rel 1.3
            calc_total()
        End If
    End Sub
	'Valida los datos antes de llamar a la funcion getRate
    Private Function getRateVal() As Boolean
        'Dim nRate As Double
        Dim rates As rateUDT
        Dim sService As String
        Dim sEquipment As String

        'Listindex = -1 si el combo no esta seleccionando
        'If cbService.ListIndex >= 0 Then
        If dgDetail.CurrentRow.Cells("Service").Value <> "" Then
            sService = dgDetail.CurrentRow.Cells("Service").Value
        Else
            getRateVal = False
            Exit Function
        End If

        'If cbEquipment.ListIndex >= 0 Then
        If dgDetail.CurrentRow.Cells("Equipment").Value <> "" Then
            sEquipment = dgDetail.CurrentRow.Cells("Equipment").Value
        Else
            getRateVal = False
            Exit Function
        End If


        If sService <> "" And sEquipment <> "" Then
            'nRate = getRate(CInt(sService), CInt(sEquipment))
            'Verifico si el servicio esta relacionado con un equipo para obtener su
            'tarifa. Ex: Taxes
            'If Not serv_4_eqpt(CInt(sService)) Then
            '    Exit Function
            'End If

            'Verifico si la tarifa de servicio-equipo requiere obtenerse de
            'VContract, Ex: Wash
            'If Not serv_4_rate_contract(CInt(sService)) Then
            '    Exit Function
            'End If

            'UPGRADE_WARNING: Couldn't resolve default property of object rates. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            rates = getRate(CShort(sService), CShort(sEquipment))

            'dgDetail.Columns("Old Rate") = Str(rates.old_rate)
            'Ambas columnas se inicializan con el mismo valor.
            dgDetail.CurrentRow.Cells("Old Rate").Value = Str(rates.old_rate)
            dgDetail.CurrentRow.Cells("Rate").Value = Str(rates.Rate_Renamed)
            getRateVal = True
        End If

    End Function
	'Habilita una columna del datagrid
	Private Sub enable_col(ByRef sCol As String)
		Select Case sCol
			Case "Rate"
                If Trim(dgDetail.Columns("Equip").HeaderText) = "<None>" Then
                    dgDetail.Columns("Rate").ReadOnly = False
                Else
                    dgDetail.Columns("Rate").ReadOnly = True
                End If
		End Select
	End Sub
	'Muestra un valor por defecto en columna Subtotal
	'si el servicio no esta relacionado con tonelaje.
	Private Sub getSubtotal()
		Dim sService As String
		Dim sEquipment As String
		
		
		'On Error GoTo ErrorHandler
		
        If dgDetail.Columns("Service").HeaderText <> "" Then
            sService = dgDetail.CurrentRow.Cells("Service").Value
        Else
            Exit Sub
        End If
		
        If dgDetail.Columns("Equipment").HeaderText <> "" Then
            sEquipment = dgDetail.CurrentRow.Cells("Equipment").Value
        Else
            Exit Sub
        End If
		
		
		If sService <> "" And sEquipment <> "" Then
			'Rel 1.3 ***********************************
			'Se multiplica siempre.
			'sStmt = "SELECT serv_ton FROM service " + _
			''        "WHERE serv_id = " + sService
			'If rsLocal.State = adStateOpen Then
			'    rsLocal.Close
			'End If
			'rsLocal.Open sStmt, cn, adOpenStatic, adLockReadOnly
			'If rsLocal("serv_ton") = "F" Then
			
            If dgDetail.CurrentRow.Cells("Rate").Value <> "" And dgDetail.CurrentRow.Cells("Usage").Value <> "" Then
                'jp.bug58.begin - Round up
                'dgDetail.Columns("Subtotal") = _
                'Round(dgDetail.Columns("Rate") * dgDetail.Columns("Usage"), 2)

                dgDetail.CurrentRow.Cells("Subtotal").Value = CStr(roundUpOne(CDbl(dgDetail.CurrentRow.Cells("Rate").Value) * CDbl(dgDetail.CurrentRow.Cells("Usage").Value)))
                'jp.bug58.end

            End If
			'Else
			'    dgDetail.Columns("Subtotal") = 0
			'End If
		End If
		Exit Sub
		
ErrorHandler: 
		save_error("frmInvoiceBooking", "getSubtotal")
		MsgBox("Failed to calculate Invoice Subtotal." & vbCrLf & "CHeck log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
	End Sub
	Private Sub cbService_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cbService.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = 0
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub cbState_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles cbState.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim sText As String
		Dim bFound As Boolean
		Dim i As Short

        If ignoreStateValidation Then
            ignoreStateValidation = False
            Exit Sub
        End If

        bFound = False
        sText = UCase(cbState.Text)
        For i = 0 To cbState.Items.Count - 1
            If sText = VB6.GetItemString(cbState, i) Then
                bFound = True
                cbState.SelectedIndex = i

                'Limpiar campos relacionados cuando se selecciona un estado

                Exit For
            End If
        Next i

        If bFound = False Then
            MsgBox("Please select a state from the list.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Warning")
            cbState.SelectedIndex = 0
            Cancel = True
        Else
            If sCurrState = "" Then
                sCurrState = cbState.Text
                GoTo EventExitSub
            End If
            If sCurrState <> "" And sCurrState <> cbState.Text Then
                'Guardo el state_id para verificar cuando se cambia
                sPrevState = sCurrState
                sCurrState = cbState.Text
                If (MsgBox("This change will clear some fields," & vbCrLf & " do you want to proceed?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Warning") = MsgBoxResult.Yes) Then
                    'Limipio campos relacionados
                    txtStore.Text = "Store#"
                    txtStore.Tag = ""
                    txtStoreId.Text = ""
                    cbVendor.Items.Clear()
                    cbAccount.Items.Clear()
                    txtStore.Focus()
                Else
                    cbState.Text = sPrevState
                End If
            End If 'currState=PrevState
        End If
EventExitSub:
        eventArgs.Cancel = Cancel
    End Sub
	
	'UPGRADE_WARNING: Event cbVendor.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbVendor_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbVendor.SelectedIndexChanged
		
		If nClicksVendor = 0 Then
			sCurrVendor = cbVendor.Text
		Else
			sPrevVendor = sCurrVendor
			sCurrVendor = cbVendor.Text
			If sPrevVendor <> cbVendor.Text Then
				cbAccount.Items.Clear()
				clear_form("DETAIL")
				'load_detail "OLD"
				
			End If
		End If
		nClicksVendor = nClicksVendor + 1
		
		
	End Sub
	
	Private Sub cbVendor_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles cbVendor.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		cbAccount.Items.Clear()
		load_combo(cbAccount)
		eventArgs.Cancel = Cancel
	End Sub
	Private Function verify_qb_vendor(ByRef sCustId As String, ByRef nVendSeq As Short) As Boolean
		
		On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand
		verify_qb_vendor = True
		sStmt = "SELECT COUNT(*) FROM qb_vendor_vbranch " & " WHERE vend_seq =" & Str(nVendSeq) & " " & " AND qb_group_id = (SELECT qb_group_id FROM customer " & "   WHERE cust_id ='" & sCustId & "')"
		'MsgBox sStmt
        cmd.CommandText = sStmt
		
        rs = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.Rows(0).Item(0) = 0 Then
            verify_qb_vendor = False
        End If

        Exit Function

ErrorHandler:
        save_error(Me.Name, "verify_qb_vendor")
        MsgBox("Unexpected found while Verifying QuickBooks data." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
	End Function
	Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click
		detail((General.detmode.NewRecord))
	End Sub
	
	'Calls Detail form for insert or update
	Private Sub detail(ByRef sOption As General.detmode)
		bRequiresUpdate = True
		Select Case sOption
			Case General.detmode.NewRecord
				gInvDetRecord.bMode = General.detmode.NewRecord
				gInvDetRecord.nInvoiceDetNo = 0
				
				If get_header Then
					VB6.ShowForm(frmInvoiceBookingDet, VB6.FormShowConstants.Modal, Me)
					If gInvDetRecord.bMode = General.detmode.SavedRecord Then
						set_detail((General.detmode.NewRecord))
					End If
				End If
				
			Case General.detmode.UpdateRecord
				gInvDetRecord.bMode = General.detmode.UpdateRecord
				edit_detail() 'Save header and detail before showing frmDet
				VB6.ShowForm(frmInvoiceBookingDet, VB6.FormShowConstants.Modal, Me)
				If gInvDetRecord.bMode = General.detmode.SavedRecord Then
					set_detail((General.detmode.UpdateRecord))
				End If
				
		End Select
		
		calc_total2()
	End Sub
	'Load data from Detail form to Grid
	Private Sub set_detail(ByRef nOption As General.detmode)
        Dim vMarkTmp As Data.DataRow = rsDetail.NewRow()
		Dim nSign As Short
		
		On Error GoTo ErrorHandler
		
        Select Case nOption
            'no se como trabaja el bookmark
            Case General.detmode.NewRecord
                vMarkTmp = rsDetail.NewRow()
                'rsDetail.Rows.InsertAt(vMarkTmp, 0)
                ''Artifice to solve recordset bug when deleting last record
                'vMarkTmp = rsDetail.Bookmark
                If bLastDeleted Then
                    'rsDetail.Bookmark = vMark
                    'rsDetail.Rows(0).RemoveAt(vMark.rowindex) '.Delete()
                    'dgDetail.Rows(0).Selected = True
                    'rsDetail.Bookmark = vMarkTmp
                    bLastDeleted = False
                End If

            Case General.detmode.UpdateRecord
                'Search row to replace in grid
        End Select
		
		
		
		If Trim(gInvDetRecord.sType) <> "" Then
            vMarkTmp.Item("Type") = Trim(gInvDetRecord.sType)
		End If
		
		If Trim(gInvDetRecord.sEquipment) <> "" Then
            vMarkTmp.Item("Equip") = Trim(gInvDetRecord.sEquipment)
		End If
		
		If Trim(gInvDetRecord.sService) <> "" Then
            vMarkTmp.Item("Serv") = Trim(gInvDetRecord.sService)
		End If
		
        vMarkTmp.Item("equipment") = gInvDetRecord.nEquipment
        vMarkTmp.Item("Date") = gInvDetRecord.dServDate
        vMarkTmp.Item("Service") = gInvDetRecord.nService
        vMarkTmp.Item("Usage") = gInvDetRecord.nUsage
        vMarkTmp.Item("Units") = gInvDetRecord.nUnits
        vMarkTmp.Item("Old Rate") = gInvDetRecord.nOldRate
        vMarkTmp.Item("Rate") = gInvDetRecord.nRate
        vMarkTmp.Item("GLM Rate") = gInvDetRecord.nGlmRate
		
		'Service Rate
		sStmt = "SELECT serv_credit FROM service WHERE serv_id =" & Str(gInvDetRecord.nService)
        gDump = exec_sql_single(sStmt)
        If IsDBNull(gDump.str1) And gDump.str1 = "" Then
            'No hay informacion en base para este servicio
            nSign = 1
        Else
            If gDump.str1 = "T" Then
                nSign = -1
            Else
                nSign = 1
            End If
        End If
		
		'jp.bug56.begin
		'jp.bug58.begin - Round up
        'rsDetail.item("Subtotal") = gInvDetRecord.nUsage * gInvDetRecord.nRate * nSign
        'rsDetail.item("Subtotal") = Round(gInvDetRecord.nUsage * gInvDetRecord.nRate * nSign, 2)
        vMarkTmp.Item("Subtotal") = roundUpOne(gInvDetRecord.nUsage * gInvDetRecord.nRate) * nSign
        'rsDetail.item("GLM Subtotal") = gInvDetRecord.nUsage * gInvDetRecord.nGlmRate * nSign
        'rsDetail.item("GLM Subtotal") = Round(gInvDetRecord.nUsage * gInvDetRecord.nGlmRate * nSign, 2)
        vMarkTmp.Item("GLM Subtotal") = roundUpOne(gInvDetRecord.nUsage * gInvDetRecord.nGlmRate) * nSign
		'jp.bug58.end
		'jp.bug56.end
        vMarkTmp.Item("Comments") = gInvDetRecord.sComments
        vMarkTmp.Item("Billable") = gInvDetRecord.sBillSavingFlag
        vMarkTmp.Item("cust_id") = cbCustomer.SelectedItem
        vMarkTmp.Item("store_id") = txtStoreId.Text
        vMarkTmp.Item("vend_seq") = cbVendor.SelectedItem.itemdata.ToString
        vMarkTmp.Item("account_no") = cbAccount.SelectedItem
        vMarkTmp.Item("invoice_no") = txtInvoice.Text
        vMarkTmp.Item("invoice_det_no") = rsDetail.Rows.Count + 1

        'falta agregar otros campos
        rsDetail.Rows.InsertAt(vMarkTmp, 0)
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "set_detail")
		MsgBox("An error has ocurred, please check log file for details.", MsgBoxStyle.Critical, "GLM Error")
		Resume Next
	End Sub
	'Sumariza los subotales
	Private Sub calc_total()
        Dim rsClone As DataTable
		Dim dSub As Double
		Dim dTotal As Double
		Dim dSubTmp As Double
		Dim dGlmTotal As Double
		
		dSub = 0
		dSubTmp = 0
		dTotal = 0
		dGlmTotal = 0
		
        rsClone = rsDetail.Copy 'rsDetail.copy(ADODB.LockTypeEnum.adLockReadOnly)
        'While rsClone.Read()
        For row As Integer = 0 To rsClone.Rows.Count - 1
            If Not IsDBNull(rsClone.Rows(row).Item("Subtotal")) Then
                dSub = rsClone.Rows(row).Item("Subtotal")
                'Verifico que el subtotal este correcto
                'es decir sub =  qty * rate
                If Not IsDBNull(rsClone.Rows(row).Item("Qty")) And Not IsDBNull(rsClone.Rows(row).Item("Rate")) Then
                    dSubTmp = rsClone.Rows(row).Item("Qty") * rsClone.Rows(row).Item("Rate")
                    If dSubTmp <> dSub Then
                        dSub = dSubTmp
                        'Actualizo el datagrid
                        'rsDetail("Subtotal") = dSub
                    End If
                End If

                dTotal = dTotal + dSub
            End If

            If Not IsDBNull(rsClone.Rows(row).Item("GLM Subtotal")) Then
                dSub = rsClone.Rows(row).Item("GLM Subtotal")
                'Verifico que el subtotal este correcto
                'es decir sub =  qty * rate
                If Not IsDBNull(rsClone.Rows(row).Item("Qty")) And Not IsDBNull(rsClone.Rows(row).Item("GLM Rate")) Then
                    dSubTmp = rsClone.Rows(row).Item("Qty") * rsClone.Rows(row).Item("GLM Rate")
                    If dSubTmp <> dSub Then
                        dSub = dSubTmp
                        'Actualizo el datagrid
                        'rsDetail("Subtotal") = dSub
                    End If
                End If

                dGlmTotal = dGlmTotal + dSub
            End If
            'rsDetail.MoveNext
        Next row

        txtTotal.Text = CStr(dTotal)
        txtGlmTotal.Text = CStr(dGlmTotal)
    End Sub
	'Sumariza los subtotales Rel 1.7.0
	Private Sub calc_total2()
        Dim rsClone As DataTable
		Dim dSub As Double
		Dim dTotal As Double
		Dim dSubTmp As Double
        Dim dGlmTotal As Double
        'Dim da As SqlDataAdapter
        'Dim ds As DataSet
		
        If rsDetail.Rows.Count <= 0 Then
            txtTotal.Text = CStr(0)
            Exit Sub
        End If
		
		dSub = 0
		dSubTmp = 0
		dTotal = 0
		dGlmTotal = 0

        rsClone = rsDetail.Copy '.copy(ADODB.LockTypeEnum.adLockReadOnly)

        'Do While Not rsClone.EOF
        For row As Integer = 0 To rsDetail.Rows.Count - 1
            If Not IsDBNull(rsDetail.Rows(row).Item("Subtotal")) Then
                dSub = rsDetail.Rows(row).Item("Subtotal")
                'Verifico que el subtotal este correcto
                'es decir sub =  qty * rate
                'If Not IsNull(rsDetail("Qty")) _
                ''And Not IsNull(rsDetail("Rate")) _
                ''Then
                '   dSubTmp = rsDetail("Qty") * rsDetail("Rate")
                '   If dSubTmp <> dSub Then
                '      dSub = dSubTmp
                'Actualizo el datagrid
                '      rsDetail("Subtotal") = dSub
                '   End If
                'End If

                dTotal = dTotal + dSub
            End If

            If Not IsDBNull(rsDetail.Rows(row).Item("GLM Subtotal")) Then
                dSub = rsDetail.Rows(row).Item("GLM Subtotal")
                'Verifico que el subtotal este correcto
                'es decir sub =  qty * rate
                'If Not IsNull(rsDetail("Qty")) _
                ''And Not IsNull(rsDetail("Rate")) _
                ''Then
                '   dSubTmp = rsDetail("Qty") * rsDetail("Rate")
                '   If dSubTmp <> dSub Then
                '      dSub = dSubTmp
                'Actualizo el datagrid
                '      rsDetail("Subtotal") = dSub
                '   End If
                'End If

                dGlmTotal = dGlmTotal + dSub
            End If
            'rsDetail.MoveNext
        Next row

        txtTotal.Text = CStr(dTotal)
        txtGlmTotal.Text = CStr(dGlmTotal)

    End Sub
	
	Private Sub cmdDrop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDrop.Click
        Dim vRow As DataGridViewRow
		Dim i As Short

        If dgDetail.SelectedRows.Count < 1 Then
            MsgBox("Select a Record to delete.", MsgBoxStyle.Information, "GLM Message")
            Exit Sub
        End If

        If dgDetail.SelectedRows.Count > 0 Then
            If MsgBox("Do you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "GLM Message") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If


        On Error GoTo ErrorHandler

        bRequiresUpdate = True

        'vRow = 0
        i = 0
        For Each vRow In dgDetail.SelectedRows
            del_dg_rows(i) = vRow 'Guardo el bookmark del datagrid del registro eliminado
            Dim drow As DataRow = rsDetail.NewRow()
            'Artificio para resolver bug en recorset al eliminar ultimo registro
            If rsDetail.Rows.Count = 1 Then
                'rsDetail.AddNew()                
                'vMark = rsDetail.Bookmark
                bLastDeleted = True
            End If

            'rsDetail.Bookmark = vRow
            'rsDetail.Delete(ADODB.AffectEnum.adAffectCurrent)
            rsDetail.Rows(vRow.Index).Delete()
            If bLastDeleted Then
                'rsDetail.Bookmark = vMark
            End If
            i = i + 1
        Next vRow

        'Remueve los bookmarks de los registros eliminados (los que usuario sombreo)
        For Each aRow As DataGridViewRow In dgDetail.SelectedRows
            dgDetail.Rows(aRow.Index).Selected = False
        Next aRow
        daDetail.Update(rsDetail)
        calc_total2()
        'cbService.Move -10000
        'cbEquipment.Move -10000
        Exit Sub
ErrorHandler:
        save_error(Me.Name, "cmdDrop.click")

        Resume Next
		
	End Sub
	'Edita detalles de un servicio en la factura
    Private Sub cmdEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEdit.Click
        If dgDetail.SelectedRows.Count < 1 Then
            MsgBox("Please select a record to edit.", MsgBoxStyle.Information, "GLM Message")
            Exit Sub
        End If
        If dgDetail.SelectedRows(0).Index < 0 Then
            MsgBox("Please select a record to edit.", MsgBoxStyle.Information, "GLM Message")
            Exit Sub
        End If

        'edit_detail
        detail((General.detmode.UpdateRecord))
    End Sub
	'Carga la form frmInvoiceDet con los datos del servicio a actualizar
	Private Sub edit_detail()
		
        'vBookmark = rsDetail.Bookmark 'Guardo Posicion de registro en recordset
		'Guardo la cabecera
		If Not get_header Then
			Exit Sub
		End If
		
		'Guardo los detalles en el arreglo global
		'gInvDetRecord.bMode = detmode.UpdateRecord
        gInvDetRecord.dServDate = CDate(dgDetail.SelectedRows(0).Cells("Date").Value)
        gInvDetRecord.sEquipment = dgDetail.SelectedRows(0).Cells("Equip").Value
        gInvDetRecord.nEquipment = CShort(dgDetail.SelectedRows(0).Cells("Equipment").Value)
        gInvDetRecord.sService = dgDetail.SelectedRows(0).Cells("Serv").Value
        gInvDetRecord.nService = CShort(dgDetail.SelectedRows(0).Cells("Service").Value)
		
        If IsDBNull(dgDetail.SelectedRows(0).Cells("Usage").Value) Then
            gInvDetRecord.nUsage = 0
        Else
            gInvDetRecord.nUsage = CDbl(dgDetail.SelectedRows(0).Cells("Usage").Value)
        End If
		
        If IsDBNull(dgDetail.SelectedRows(0).Cells("Units").Value) Then
            gInvDetRecord.nUnits = 0
        Else
            gInvDetRecord.nUnits = CDbl(dgDetail.SelectedRows(0).Cells("Units").Value)
        End If
		
		
        gInvDetRecord.sType = dgDetail.SelectedRows(0).Cells("Type").Value
        gInvDetRecord.nOldRate = CDbl(dgDetail.SelectedRows(0).Cells("Old Rate").Value)
        gInvDetRecord.nRate = CDbl(dgDetail.SelectedRows(0).Cells("Rate").Value)
        gInvDetRecord.nGlmRate = CDbl(dgDetail.SelectedRows(0).Cells("GLM Rate").Value)
        gInvDetRecord.sComments = dgDetail.SelectedRows(0).Cells("Comments").Value
        gInvDetRecord.sBillSavingFlag = dgDetail.SelectedRows(0).Cells("Billable").Value
		
        If IsDBNull(dgDetail.SelectedRows(0).Cells("invoice_det_no").Value) Or Len(Trim(dgDetail.SelectedRows(0).Cells("invoice_det_no").Value)) = 0 Then
            gInvDetRecord.nInvoiceDetNo = 0
        Else
            gInvDetRecord.nInvoiceDetNo = CShort(dgDetail.SelectedRows(0).Cells("invoice_det_no").Value)
        End If
		
		
		
	End Sub
	'Guarda datos de la cabecera antes de invocar a forma de detalle de factura
	Private Function get_header() As Boolean
		
		get_header = True
		If cbCustomer.Text <> "" Then
			gInvHeaderRecord.sCustId = cbCustomer.Text
		Else
			MsgBox("A customer must be entered.")
			get_header = False
			Exit Function
		End If
		
		If txtStoreId.Text <> "" Then
			gInvHeaderRecord.nStoreId = CShort(txtStoreId.Text)
		Else
			MsgBox("An Store must be selected.")
			get_header = False
			Exit Function
		End If
		
		If cbVendor.SelectedIndex >= 0 Then
			gInvHeaderRecord.nVendSeq = VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)
		Else
			MsgBox("A Vendor must be selected.")
			get_header = False
			Exit Function
		End If
		
        If dtDate.Value.ToString <> "" Then
            gInvHeaderRecord.dInvoiceDate = dtDate.Value
        Else
            MsgBox("An Invoice Date must be entered.")
            get_header = False
            Exit Function
        End If
		
		If Len(Trim(txtInvoice.Text)) > 0 Then
			gInvHeaderRecord.sInvoiceNo = Trim(txtInvoice.Text)
		Else
			MsgBox("An Invoice Number must be entered.")
			get_header = False
			Exit Function
		End If
		
		If cbAccount.SelectedIndex >= 0 Then
			gInvHeaderRecord.sAccountNo = cbAccount.Text
		Else
			MsgBox("Please select an account before attemting this action.")
			get_header = False
			Exit Function
		End If
		
		
	End Function
	'Muestra listado de tiendas por Customer-State
	Private Sub cmdHelpCustomer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdHelpCustomer.Click
		
        Try

            sStmt = "SELECT s.cust_id AS Customer," & "s.state_id AS State," & "RTRIM(s.store_number)  AS 'Store Number'," & "RTRIM(s.store_name) AS 'Store Name'," & "RTRIM(s.store_co_code) AS Code," & "a.account_mask AS 'Account', " & "v.vend_name AS 'Vendor', " & "s.store_address AS 'Store Address', " & "s.store_city AS City," & "s.store_zip AS Zip ," & "s.store_id  AS StoreID " & "FROM Store s, VAccount a, VBranch v " & " WHERE s.cust_id = a.cust_id " & " AND s.store_id = a.store_id " & " AND a.vend_seq = v.vend_seq " & " AND s.cust_id ='" & cbCustomer.Text & "' " & " AND s.state_id ='" & cbState.Text & "' "
            gInvoiceHelp.sSql = sStmt

            sStmt = "ORDER BY 'Store Number'"
            gInvoiceHelp.sOrderBy = sStmt

            frmHelpCustomer.nMode = frmHelpCustomer.options.adStoreHelp
            'VB6.ShowForm(frmHelpCustomer, VB6.FormShowConstants.Modal, Me)
            frmHelpCustomer.ShowDialog()
            frmHelpCustomer.Dispose()
            txtStore.Focus()
            cbVendor.Focus()

            Exit Sub

        Catch e As Exception
            save_error("frmInvoiceBooking", "cmdHelpCustomer_Click")
            MsgBox("An unexpected error has ocurred, check log file for details", MsgBoxStyle.Critical, "GLM Error")
        End Try
    End Sub
	
	
	
	Private Sub cmdNotes_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNotes.Click
		'MsgBox rsDetail.RecordCount
		If check_header Then
			VB6.ShowForm(frmInvoiceNotes, VB6.FormShowConstants.Modal, Me)
		End If
	End Sub
	
	'Desactivado 09/07/02 Usuario tendra que actualizar todas las tarifas en
	'mantenimiento de contratos
	'Verifica que el equipo-servicio esten definidos en la tabla Vcontract
	'y determina si el usuario tiene permisos necesarios para proceder con
	'la actualizacion. Los resultados se guardan en la variable nUpdateRate
	'nUpdateRate
	'0 No permitir cambios
	'1 Actualizar VContract
	'2 Permitir actualizar el Datagrid pero no acutalizar VContract
	Private Sub check_rate()
		nUpdateRate = 0
		'If serv_4_rate_contract(dgDetail.Columns("Service")) Then
		'And serv_4_eqpt(dgDetail.Columns("Service"))
        If serv_4_eqpt(CShort(dgDetail.CurrentRow.Cells("Service").Value)) Then
            'Verifica que el equipo-servicio existan en VContract
            If check_contract_item(CShort(dgDetail.CurrentRow.Cells("Equipment").Value), CShort(dgDetail.CurrentRow.Cells("Service").Value)) Then

                'Verifica que el usuario disponga de privilegios para esta tarea
                If check_permission() Then
                    'Permite actualizar
                    nUpdateRate = 1
                Else
                    nUpdateRate = 0
                    MsgBox("Your Account does not have privileges," & vbCrLf & "to update the Contract Rate Info", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Warning")
                End If
            Else
                nUpdateRate = 2
            End If


        Else
            If CDbl(dgDetail.CurrentRow.Cells("equipment").Value) = 0 Then
                nUpdateRate = 2
            Else
                nUpdateRate = 0
                MsgBox("Unable to set new rate for such Service and Equipment." & vbCrLf & "They have not been found in the contract.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Warning")
            End If
        End If
		'Else
		'    nUpdateRate = 2
		'End If 'serv_4_rate_contract
		
	End Sub
	
	Private Sub cnTmp_InfoMessage(ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pConnection As ADODB.Connection)
		
	End Sub
	
    Private Sub dgDetail_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        cmdEdit_Click(cmdEdit, New System.EventArgs())
    End Sub
	
	'Solo numeros
    Private Sub dgDetail_KeyPressEvent(ByVal eventSender As System.Object, ByVal eventArgs As AxMSDataGridLib.DDataGridEvents_KeyPressEvent)
    End Sub
	'Muestra las tarifa para el servicio/equipo
	Private Function getRate(Optional ByRef nService As Short = 0, Optional ByRef nEquipment As Short = 0) As rateUDT
		
		Dim e As ADODB.Error
		
		'Text1.Visible = True
		'Text1 = Text1 + "GetRateVal" + vbCrLf
		On Error GoTo ErrorHandler
		
		
		getRate.old_rate = 0#
		getRate.Rate_Renamed = 0#
		
		'Verifica parametros
		If nService = 0 Or nEquipment = 0 Then
			getRate.old_rate = 0#
			getRate.Rate_Renamed = 0#
			Exit Function
		End If
		
		'Busca
        rsTmp.Select("eqpt_seq = " & Str(nEquipment))
		DataGrid1.DataSource = rsTmp
        DataGrid1.Refresh()
		
        'Do While Not rsTmp.EOF
        For row As Integer = 0 To rsTmp.Rows.Count - 1
            If rsTmp.Rows(row).Item("serv_id") = nService Then
                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                If Not IsDBNull(rsTmp.Rows(row).Item("old_rate")) Then
                    'getRate = rsTmp("old_rate")
                    getRate.old_rate = rsTmp.Rows(row).Item("old_rate")
                End If
                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                If Not IsDBNull(rsTmp.Rows(row).Item("curr_rate")) Then
                    getRate.Rate_Renamed = rsTmp.Rows(row).Item("curr_rate")
                End If
                Exit For
            End If

        Next row
        'rsTmp.Filter = ADODB.FilterGroupEnum.adFilterNone
        DataGrid1.DataSource = rsTmp
        'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        DataGrid1.Refresh()

        Exit Function

ErrorHandler:
        save_error("frmInvoiceBooking", "getRate")
        MsgBox("Failed to calculate Rate." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error ")
    End Function
	
	
    Private Sub frmInvoiceBooking_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        'Variables Initialization
        init_vars()
        bClearAll = False
        bInvoiceSaved = False

        clear_form("HEADER")
        clear_form("VARS") 'Inicia contadores y banderas

        nMode = mode.adInsert


        sdfService = New DataGridViewCellStyle() 'StdFormat.StdDataFormat
        sdfEquipment = New DataGridViewCellStyle() 'New StdFormat.StdDataFormat
        sdfDate = New DataGridViewCellStyle() 'New StdFormat.StdDataFormat
        sdfTons = New DataGridViewCellStyle() 'New StdFormat.StdDataFormat
        sdfUnits = New DataGridViewCellStyle() 'New StdFormat.StdDataFormat
        sdfTimes = New DataGridViewCellStyle() 'New StdFormat.StdDataFormat

        cmTmp = cn.CreateCommand
        'cmDetail = New ADODB.Command
        'cmDetail.let_ActiveConnection(cn)

        'Carga combos, solo se requiere hacer una vez.
        sStmt = "SELECT DISTINCT cust_id FROM suser_data " & "WHERE suser_data.suser_name ='" & gsUser & "' " & "ORDER BY 1"
        load_cb_query(cbCustomer, sStmt, 1)
        If cbCustomer.Items.Count > 0 Then
            cbCustomer.SelectedIndex = 0
        End If
        'load_combo cbCustomer
        'load_combo cbState

        daDetail = New SqlDataAdapter()
        dgDetail.DataSource = bindingSource1
        load_detail("NEW")

        'verificar quien esta llamando la forma
        Try
            Dim sCustId As String = ""
            Dim sStoreId As String = ""
            Dim sStoreNumber As String = ""
            Dim sStateId As String = ""
            Dim sVendSeq As String = ""
            Dim sAccountNo As String = ""
            Dim sInvoiceNo As String = ""
            Dim parentName As String
            parentName = ""
            Try
                parentName = Me.parentCaller
                If Me.parentCaller = "" Then
                    parentName = Me.Owner.Name.ToString
                End If
            Catch e As Exception
            End Try
            If parentName = "frmInvoiceImport" Then
                With frmInvoiceImport
                    sCustId = Trim(.dgPendingInvoices.SelectedRows(0).Cells("Cust").Value)
                    sStoreId = Trim(.dgPendingInvoices.SelectedRows(0).Cells("store_id").Value)
                    sStoreNumber = Trim(.dgPendingInvoices.SelectedRows(0).Cells("Store No").Value)
                    sStateId = Trim(.dgPendingInvoices.SelectedRows(0).Cells("state_id").Value)
                    sVendSeq = Trim(.dgPendingInvoices.SelectedRows(0).Cells("vend_seq").Value)
                    sAccountNo = Trim(.dgPendingInvoices.SelectedRows(0).Cells("Account").Value)
                    sInvoiceNo = Trim(.dgPendingInvoices.SelectedRows(0).Cells("Invoice").Value)
                End With
                populateHeader(sCustId, sStoreId, sStoreNumber, sStateId, CShort(sVendSeq), sAccountNo, sInvoiceNo)
                bImportedFromLF = True
                btNew.Enabled = False
                btSave.Enabled = True
                btSearch.Enabled = False
                btDelete.Enabled = True
            End If

            'populateHeader(.sCustId, .sStoreId, .sStoreNumber, .sStateId, CShort(.sVendSeq), .sAccountNo, .sInvoiceNo)

        Catch e As Exception
        End Try
    End Sub
	'Inicializa variables
	Private Sub init_vars()
		'DEBUG
		'Text1.Visible = True
		
		bLastDeleted = False
		bReaction = True
		bUserCancel = False

		load_cb_month()
		
		txtTotal.Enabled = False
		txtGlmTotal.Enabled = False
		lbStartDate.Text = ""
		lbEndDate.Text = ""
		
        bImportedFromLF = False
        txtSc.Text = ""
        txtExtc.Text = ""
        cbCustomer.Enabled = True
        cbState.Enabled = True
        txtStore.ReadOnly = False




		
	End Sub
	'Carga datos en el Datagrid de servicios
	Public Sub load_detail(ByRef sOpcion As String)
		Dim sStr As String
        Dim nVendId As Short
        Dim ds As DataSet = New DataSet("tmpDS")
        Dim dt As New DataTable()
        rsDetail = New DataTable()
		
		If cbVendor.Items.Count = 0 Then
			nVendId = 0
		Else
			'Verifica si esta seleccionado algun vendedor
			If cbVendor.SelectedIndex >= 0 Then
				nVendId = VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)
			Else
				nVendId = 0
			End If
		End If
		
		If sOpcion = "NEW" Then
            'rsDetail.CursorLocation = ADODB.CursorLocationEnum.adUseClient
			
			'Busco los detalles de la factura
			
			'Rel 1.3 - Begin
            sStr = "SELECT serv_date as Date," & "eqpt_desc as Equip, " & "serv_desc as Serv, " & "times as Qty, " & "serv_usage as Usage ," & "units as Units ," & "unit_type as 'Type', " & "tons as Tons," & "old_rate as 'Old Rate'," & "rate as Rate, " & "comment as Comments ," & "cust_id, store_id, vend_seq, account_no," & "invoice_no, invoice_det_no, " & "eqpt_seq as Equipment, " & "serv_id as Service, glm_rate as 'GLM Rate', subtotal as Subtotal, " & " bill_saving_flag as Billable, glm_subtotal 'GLM Subtotal'  " & _
                   " FROM VInvoiceDet " & _
                   " WHERE cust_id = @customer " & " AND invoice_no= @invoice " & " AND vend_seq = @vendor " & " AND account_no =@account " & " AND store_id=" & _
                                                        "(SELECT store_id FROM store " & " WHERE store.cust_id = VInvoiceDet.cust_id " & " AND store_number= @store ) "
			
			'Rel 1.3 - End
            cmDetail = cn.CreateCommand
            cmDetail.CommandText = sStr
           
            'da = New SqlDataAdapter(sStr, cn)
            daDetail.MissingSchemaAction = MissingSchemaAction.AddWithKey
            ' Create a command builder to generate SQL update, insert, and
            ' delete commands based on selectCommand. These are used to
            ' update the database.
            'daDetail.SelectCommand = New SqlCommand(sStr, cn)
            'Dim commandBuilder As New SqlCommandBuilder(daDetail)

            Dim sqlparam As SqlParameter ' = New SqlParameter("customer", SqlDbType.VarChar, 10, ParameterDirection.Input)
            'With cmDetail.Parameters
            Try
                sqlparam = New SqlParameter("@customer", SqlDbType.VarChar, 10, ParameterDirection.Input)
                With cmDetail.Parameters
                    '.Append(cmDetail.CreateParameter("customer", SqlDbType.VarChar, ParameterDirection.Input, 10))
                    sqlparam = New SqlParameter("@customer", SqlDbType.VarChar, 10, ParameterDirection.Input)
                    .Add(sqlparam)
                    '.Append(cmDetail.CreateParameter("invoice", SqlDbType.VarChar, ParameterDirection.Input, 30))
                    sqlparam = New SqlParameter("@invoice", SqlDbType.VarChar, 30, ParameterDirection.Input)
                    .Add(sqlparam)
                    '.Append(cmDetail.CreateParameter("vendor", DbType.Int32, ParameterDirection.Input))
                    sqlparam = New SqlParameter("@vendor", SqlDbType.Int, 30, ParameterDirection.Input)
                    .Add(sqlparam)
                    '.Append(cmDetail.CreateParameter("account", SqlDbType.VarChar, ParameterDirection.Input, 30))
                    sqlparam = New SqlParameter("@account", SqlDbType.VarChar, 30, ParameterDirection.Input)
                    .Add(sqlparam)
                    '.Append(cmDetail.CreateParameter("store", SqlDbType.VarChar, ParameterDirection.Input, 20))
                    sqlparam = New SqlParameter("@store", SqlDbType.VarChar, 30, ParameterDirection.Input)
                    .Add(sqlparam)
                End With
            Catch ex As Exception
                Dim errMsg As String = ex.Message
            End Try
        End If
        Try
            'Cargo parametros
            cmDetail.Parameters(0).Value = cbCustomer.SelectedItem.ToString
            cmDetail.Parameters(1).Value = txtInvoice.Text
            cmDetail.Parameters(2).Value = nVendId 'cbVendor.ItemData(cbVendor.ListIndex)
            cmDetail.Parameters(3).Value = cbAccount.Text
            cmDetail.Parameters(4).Value = txtStore.Text

            'daDetail.SelectCommand.Parameters(0).Value = cbCustomer.SelectedItem.ToString
            'daDetail.SelectCommand.Parameters(1).Value = txtInvoice.Text
            'daDetail.SelectCommand.Parameters(2).Value = nVendId 'cbVendor.ItemData(cbVendor.ListIndex)
            'daDetail.SelectCommand.Parameters(3).Value = cbAccount.Text
            'daDetail.SelectCommand.Parameters(4).Value = txtStore.Text


            'rsDetail.Open sStr, cn, adOpenStatic, adLockBatchOptimistic
            'da.SelectCommand = cmDetail
            daDetail = New SqlDataAdapter(cmDetail)
            scbDetail = New SqlCommandBuilder(daDetail)
            daDetail.Fill(rsDetail)
            dgDetail.DataSource = rsDetail
            bindingSource1.DataSource = rsDetail
            'rsDetail = dt
            'dgDetail.DataSource = 
            'rsDetail = ds.Tables(0) '.Open(cmDetail, , ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockBatchOptimistic)

            'dgDetail.ClearFields()
            'dgDetail.Rows.Clear()


            'Escondo los campos de la llave primaria PK
            dgDetail.Columns("Tons").Visible = False
            dgDetail.Columns("cust_id").Visible = False
            dgDetail.Columns("vend_seq").Visible = False
            dgDetail.Columns("invoice_no").Visible = False
            dgDetail.Columns("store_id").Visible = False
            dgDetail.Columns("account_no").Visible = False
            dgDetail.Columns("invoice_det_no").Visible = False
            dgDetail.Columns("Service").Visible = False
            dgDetail.Columns("Equipment").Visible = False
            dgDetail.Columns("Qty").Visible = False
            dgDetail.Columns("Comments").Visible = False
            dgDetail.Columns("GLM Subtotal").Visible = False

            'Rel 1.3 - Begin
            'Set dgDetail.Columns("Service").DataFormat = sdfService
            'Set dgDetail.Columns("Equipment").DataFormat = sdfEquipment
            'Rel 1.3 - End



            'Columns Format ***************************
            dgDetail.Columns("Date").Width = VB6.TwipsToPixelsX(1000)
            'dgDetail.Columns("Qty").Width = 600
            dgDetail.Columns("Usage").Width = VB6.TwipsToPixelsX(600)
            dgDetail.Columns("Units").Width = VB6.TwipsToPixelsX(600)
            dgDetail.Columns("Type").Width = VB6.TwipsToPixelsX(600)
            'dgDetail.Columns("Comments").Width = 1200

            'Rel 1.3 - Begin
            'dgDetail.Columns("Tons").Width = 1000
            dgDetail.Columns("Service").Width = VB6.TwipsToPixelsX(250)
            dgDetail.Columns("Equipment").Width = VB6.TwipsToPixelsX(250)
            dgDetail.Columns("Serv").Width = VB6.TwipsToPixelsX(1900)
            dgDetail.Columns("Equip").Width = VB6.TwipsToPixelsX(1200)

            'Rel 1.3 End

            dgDetail.Columns("Old Rate").Width = VB6.TwipsToPixelsX(900)
            dgDetail.Columns("Rate").Width = VB6.TwipsToPixelsX(900)
            dgDetail.Columns("GLM Rate").Width = VB6.TwipsToPixelsX(900)
            dgDetail.Columns("Subtotal").Width = VB6.TwipsToPixelsX(1000)


            '*******************************************
            'Alignment
            dgDetail.Columns("Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft '.Alignment = MSDataGridLib.AlignmentConstants.dbgLeft
            dgDetail.Columns("Old Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' MSDataGridLib.AlignmentConstants.dbgRight
            dgDetail.Columns("Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight '= MSDataGridLib.AlignmentConstants.dbgRight
            dgDetail.Columns("GLM Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'MSDataGridLib.AlignmentConstants.dbgRight
            dgDetail.Columns("Subtotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'MSDataGridLib.AlignmentConstants.dbgRight
            dgDetail.Columns("Usage").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'MSDataGridLib.AlignmentConstants.dbgRight
            dgDetail.Columns("Units").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'MSDataGridLib.AlignmentConstants.dbgRight

            sdfDate.Format = "mm/dd/yyyy"
            sdfTons.Format = "###0.0000"
            'jp DecimalIncrease Begin
            sdfUnits.Format = "###0.0000"
            'jp DecimalIncrease End
            'Rel 1.3
            'Set dgDetail.Columns("Tons").DataFormat = sdfTons

            Dim sdfText As StdFormat.StdDataFormat
            sdfText = New StdFormat.StdDataFormat
            sdfText.Type = StdFormat.FormatType.fmtGeneral

            dgDetail.Columns("Date").DefaultCellStyle.Format = sdfDate.Format.ToString '.DataFormat = sdfDate
            dgDetail.Columns("Usage").DefaultCellStyle.Format = sdfTons.Format.ToString
            dgDetail.Columns("Units").DefaultCellStyle.Format = sdfUnits.Format.ToString
            dgDetail.Columns("Old Rate").DefaultCellStyle.Format = sdfTons.Format.ToString
            dgDetail.Columns("Rate").DefaultCellStyle.Format = sdfTons.Format.ToString
            dgDetail.Columns("GLM Rate").DefaultCellStyle.Format = sdfTons.Format.ToString
            dgDetail.Columns("Subtotal").DefaultCellStyle.Format = sdfTons.Format.ToString
            dgDetail.Columns("Comments").DefaultCellStyle.Format = Nothing 'sdfText

            dgDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            'dgDetail.AutoSizeRowsMode =DataGridViewAutoSizeRowsMode.AllCells' DataGridViewAutoSizeRowsMode.AllCells
            dgDetail.Columns("Comments").DefaultCellStyle.WrapMode = DataGridViewTriState.True '.WrapText = True
            dgDetail.Columns("Old Rate").ReadOnly = True
            dgDetail.Columns("Rate").ReadOnly = True
            dgDetail.Columns("GLM Rate").ReadOnly = True
            dgDetail.Columns("Type").ReadOnly = True

            'sdfTimes.Format = "####.##"


            dgDetail.Columns("Subtotal").ReadOnly = True

            calc_total()
            'Inicializo esta variable cada vez que se cargan detalles para
            'recargar el recordset con informacion de equipos y tarifas (vcontract)
            nClicks = 0
            'dgDetail.AutoSizeColumnsMode.AllCells = .Columns.a.AllowRowSizing = False
            dgDetail.AllowUserToResizeColumns = False
            'dgDetail.Height = VB6.PixelsToTwipsY(cbService.Height)
            'dgDetail.TabAction = MSDataGridLib.TabActionConstants.dbgColumnNavigation
            dgDetail.StandardTab = False


            'dgDetail.Columns("Service").Visible = True
            'dgDetail.Columns("Equipment").Visible = True
            'dgDetail.ScrollBars = dbgAutomatic
            dgDetail.Refresh()
        Catch ex As Exception
            Dim errMsg As String = ex.Message
        End Try


    End Sub
	'Carga rsTmp con informacion de tarifas por equipo/servicio del store
	Public Sub load_rs()
		
		On Error GoTo ErrorHandler
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim ds As DataSet = New DataSet("tmpDS")
        Dim cmd As SqlCommand = cn.CreateCommand()
		bRates = False
		'Este query asume que el vendor reside en el mismo estado (state_id)
		'que el cliente y que cada cliente tiene un solo vendor branch que lo
		'atienda (vend_seq=1). Esto se debe modificar en el futuro para
		'soportar varios vendor branchs del cliente
		
        sTmp = "SELECT * FROM vcontract " & "WHERE cust_id ='" & cbCustomer.SelectedItem.ToString() & "' " & "AND store_id =" & txtStoreId.Text & " " & _
                                                "AND vend_seq =" & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex))
        cmd.CommandText = sTmp
        da.SelectCommand = cmd
        da.Fill(ds)
		
        rsTmp = ds.Tables(0) '.Open(sTmp, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If rsTmp.Rows.Count <= 0 Then
            bRates = False
        End If
		
		DataGrid1.DataSource = rsTmp
        DataGrid1.Refresh()
		'DataGrid1.Visible = True
		Exit Sub
		
ErrorHandler: 
		save_error("frmInvoiceBooking", "load_rs")
		MsgBox(Err.Description, MsgBoxStyle.OKOnly)
	End Sub
	'Carga los combos: Customer, State, Vendor, Account, Service, Equipment
	Public Sub load_combo(ByRef cb As System.Windows.Forms.ComboBox)
		
        Dim nRec As Short = 0
        Dim sStr As String = ""
        Dim nCounter As Short = 0
        Dim sItem As String = ""
		
		On Error GoTo ErrorHandler
		
		Select Case cb.Name
			Case "cbCustomer"
				sStr = "SELECT DISTINCT cust_id FROM suser_data " & "WHERE suser_data.suser_name ='" & gsUser & "' " & "ORDER BY 1"
			Case "cbState"
				sStr = "SELECT DISTINCT state_id FROM suser_data " & "WHERE suser_data.suser_name ='" & gsUser & "' " & "ORDER BY 1"
			Case "cbVendor"
				'sStr = "SELECT DISTINCT vend_name,vendor.vend_id FROM vendor,vaccount " + _
				''        "WHERE vendor.vend_id = vaccount.vend_id " + _
				''        "AND vaccount.cust_id ='" + cbCustomer + "' " + _
				''        "AND vaccount.store_id =" + _
				''        "(SELECT store_id FROM store " + _
				''        " WHERE store_number='" + txtStore + "') " + _
				''        "ORDER BY 1"
                sStr = "SELECT DISTINCT VBranch.vend_name, VBranch.vend_seq, VBranch.vend_area " & _
                "FROM VBranch, VAccount " & _
                "WHERE VBranch.vend_seq = VAccount.vend_seq " & "AND VAccount.cust_id ='" & cbCustomer.SelectedItem.ToString() & "' " & "AND VAccount.store_id =" & _
                "(SELECT store_id FROM store " & " WHERE cust_id = '" & Trim(cbCustomer.SelectedItem.ToString()) & "' " & " AND store_number='" & Trim(txtStore.Text) & "') " & "ORDER BY 1"
                'cbCustomer.SelectedItem.ToString()
            Case "cbAccount"
                If cbCustomer.Text = "" Or cbCustomer.SelectedIndex = -1 Or cbVendor.Text = "" Or cbVendor.SelectedIndex = -1 Then
                    cbAccount.Items.Clear()
                    Exit Sub
                End If

                'sStr = "SELECT account_no FROM vbranch,vaccount " + _
                '"WHERE vbranch.vend_seq = vaccount.vend_seq " + _
                '"AND vaccount.cust_id ='" + cbCustomer + "' " + _
                '"AND vbranch.vend_seq=" + _
                'Str(cbVendor.ItemData(cbVendor.ListIndex)) + " " + _
                '"AND vaccount.store_id =" + _
                '"(SELECT store_id FROM store " + _
                '" WHERE store_number='" + txtStore + "') " + _
                '"ORDER BY 1"

                '05/06/2002
                'Solo se muestran Cuentas que esten Activas
                sStr = "SELECT DISTINCT account_no FROM VBranch,VAccountEqpt " & _
                "WHERE vbranch.vend_seq = VAccountEqpt.vend_seq " & "AND VAccountEqpt.cust_id ='" & Trim(cbCustomer.SelectedItem.ToString()) & "' " & _
                        "AND vbranch.vend_seq=" & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & " " & "AND VAccountEqpt.store_id =" & _
                                "(SELECT store_id FROM store " & " WHERE cust_id = '" & Trim(cbCustomer.SelectedItem.ToString()) & "' " & " AND store_number='" & txtStore.Text & "') " & _
                                " AND VAccountEqpt.account_status = 'A' " & "ORDER BY 1"
				
			Case "cbService"
				sStr = "SELECT serv_desc, serv_id FROM service"
				'09/03/2002
				'Lista de servicios disponibles para los equipos ACTIVOS
				'con este Hauler. y servicios que no necesitan de un equipo
				'para ser definidos
				'Esto no esta activo, solo load_combo2 carga cbService
                sStr = " SELECT serv_desc, serv_id FROM service " & " WHERE serv_eqpt ='F' " & " UNION" & " SELECT DISTINCT s.serv_desc, s.serv_id " & _
                    " FROM VContract c, StoreEqpt e, Service s" & _
                    " WHERE e.cust_id = c.cust_id " & " AND e.store_id = c.store_id " & " AND e.eqpt_seq = c.eqpt_seq " & " AND c.serv_id = s.serv_id " & " AND e.eqpt_status = 'A' " & " AND c.expiration_date >= '" & Str(dtDate.Value) & "' " & " AND c.cust_id = '" & cbCustomer.Text & "' " & " AND c.store_id = '" & txtStoreId.Text & "' " & " AND c.vend_seq = " & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex))
			Case "cbEquipment"
				cb.Items.Clear()
				'sStr = "SELECT eqpt_desc,eqpt_seq FROM StoreEqpt " + _
				'"WHERE cust_id = '" + cbCustomer + "' " + _
				'"AND store_id = '" + txtStoreId + "' "
				
				'09/01/2002
				'Listado de equipos de esta TIENDA que tienen
				'uno o mas contratos NO EXPIRADOS con este hauler
                'y cuyos equipos estan ACTIVOS.
                sStr = " SELECT DISTINCT e.eqpt_desc, e.eqpt_seq " & " FROM VContract c, StoreEqpt e" & _
                " WHERE e.cust_id = c.cust_id " & " AND e.store_id = c.store_id " & " AND e.eqpt_seq = c.eqpt_seq " & " AND e.eqpt_status = 'A' " '& _
                sStr = sStr & _
                    " AND c.expiration_date >= '" & dtDate.Value.Date.ToShortDateString() & "' " & " AND c.cust_id = '" & cbCustomer.SelectedItem.ToString() & "' " '& _
                sStr = sStr & " AND c.store_id = '" & txtStoreId.Text & "' " & " AND c.vend_seq = " & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex))
				'MsgBox sStr
		End Select
		
        rs = getDataTable(sStr)
        If rs.Rows.Count = 0 Then
            Exit Sub
        End If
		
		nCounter = 0
		'Rel 1.3 *****************************
		'Para no seleccionar equipo
		If cb.Name = "cbEquipment" Then
			cb.Items.Insert(0, "<None>")
			VB6.SetItemData(cb, 0, 0)
			nCounter = 1
		End If
		'*************************************
		

        For row As Integer = 0 To rs.Rows.Count - 1
            sItem = rs.Rows(row).Item(0)
            cb.Items.Insert(nCounter, Trim(sItem))
            Select Case cb.Name
                Case "cbVendor"
                    VB6.SetItemString(cb, nCounter, Trim(rs.Rows(row).Item(0)) & " - " & Trim(rs.Rows(row).Item(2)))
                    VB6.SetItemData(cb, nCounter, rs.Rows(row).Item(1)) 'vend_seq
                    'cb.Items(nCounter)
                Case "cbService"
                    VB6.SetItemData(cb, nCounter, rs.Rows(row).Item(1)) 'serv_id
                Case "cbEquipment"
                    VB6.SetItemData(cb, nCounter, rs.Rows(row).Item(1)) 'eqpt_seq
            End Select
            'If cb.Name = "cbVendor" Or cb.Name = "cbService" _
            ''    Or cb.Name = "cbEquipment" Then
            '    cb.ItemData(nCounter) = rs.item(1) 'vend_id, serv_id, eqpt_seq
            'End If
            nCounter = nCounter + 1

        Next


        Exit Sub

ErrorHandler:
        save_error(Me.Name, "load_combo")
        MsgBox("Unexpected error when loading invoice defaults." & vbCrLf & "Check log file for details", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
	End Sub
	'Carga datos en el combo cbService
	Public Sub load_combo2(ByRef cb As System.Windows.Forms.ComboBox, ByRef nEqptSeq As Short)
		
		Dim nCounter As Short
		Dim sItem As String
		
		On Error GoTo ErrorHandler
		
		
		
		Select Case cb.Name
			Case "cbService"
				If nEqptSeq <= 0 Then 'Equipo <None>
					sStmt = " SELECT serv_desc, serv_id FROM service " & " WHERE serv_eqpt ='F' "
				Else
					'Solo los servicios de este equipo
                    sStmt = " SELECT DISTINCT s.serv_desc, s.serv_id " & " FROM VContract c, StoreEqpt e, Service s" & " WHERE e.cust_id = c.cust_id " & " AND e.store_id = c.store_id " & " AND e.eqpt_seq = c.eqpt_seq " & " AND c.serv_id = s.serv_id " & " AND e.eqpt_status = 'A' " & " AND c.expiration_date >= '" & Str(dtDate.Value) & "' " & " AND c.cust_id = '" & cbCustomer.Text & "' " & " AND c.store_id = '" & txtStoreId.Text & "' " & " AND c.vend_seq = " & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & " AND c.eqpt_seq = " & Str(nEqptSeq)
				End If
		End Select
		
		
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.Rows.Count = 0 Then
            Exit Sub
        End If
		
		cb.Items.Clear()
		nCounter = 0
		

        For row As Integer = 0 To rs.Rows.Count - 1
            sItem = rs.Rows(row).Item(0)
            cb.Items.Insert(nCounter, Trim(sItem))
            Select Case cb.Name
                Case "cbService"
                    VB6.SetItemData(cb, nCounter, rs.Rows(row).Item(1)) 'serv_id
            End Select
            nCounter = nCounter + 1
        Next row

        'Text1 = Text1 + vbCrLf + dgDetail.Columns("Serv")
        'Se muestra por defecto el primer elemento de la lista

        If cb.Items.Count > 0 Then
            If (dgDetail.CurrentRow.Cells("Serv").Value = "" Or IsDBNull(dgDetail.CurrentRow.Cells("Serv").Value)) Then
                cb.SelectedIndex = 0
            Else
                'Si la fila del datagrid tiene un servicio,Buscar servicio en el combo
                cb_set(cbService, dgDetail.CurrentRow.Cells("Serv").Value)
            End If
        End If
        Exit Sub


ErrorHandler:
        save_error(Me.Name, "load_combo")
        MsgBox("Unexpected error when loading Service info." & vbCrLf & "Check log file for details", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
		
		
	End Sub
	
    Private Sub frmInvoiceBooking_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'UPGRADE_ISSUE: Event parameter Cancel was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
        eventArgs.Cancel = requires_update()
    End Sub
	'TRUE Invoice was not saved and required update
	'FALSE Invoice did not required or user decided to not save data changes
	Private Function requires_update() As Boolean
		
		requires_update = False
		
		If bRequiresUpdate = True Then
			If (MsgBox("Do you want to save your changes?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "GLM Message") = MsgBoxResult.Yes) Then
				save_invoice2(MsgBoxResult.Yes)
				If bRequiresUpdate Then
					requires_update = True
					Exit Function
				End If
			End If
		End If
		
		
	End Function
    'StdFormat.StdDataValue
    Private Sub sdfService_Format(ByVal DataValue As System.Windows.Forms.DataGridViewCellStyle)
        Dim i As Short

        'DataValue es el codigo del servicio
        For i = 0 To cbService.Items.Count - 1
            If VB6.GetItemData(cbService, i) = DataValue.Format.ToString Then
                'DataValue.Value = VB6.GetItemString(cbService, i)
                Exit For
            End If
        Next
    End Sub
	'Rel 1.3
	'Nueva version de move_combo para mover ambos combos simultaneamente
	Private Sub move_combo_to()
		Dim gcol As MSDataGridLib.Column
		
		'No ejecutar esta funcion si no se han agregado
		'todas las columnas
		If dgDetail.Columns.Count <= 2 Then
			Exit Sub
		End If
		
        If dgDetail.SelectedColumns(0).Index < 0 Then
            Exit Sub
        End If
		
		'El recordset apunta una fila sin datos
        If dgDetail.SelectedRows(0).Index < 0 Then
            Exit Sub
        End If
		
		'Equipment
		gcol = dgDetail.Columns("Equip")
		
        'If gcol.Caption = "Equip" And dgDetail.CurrentCell.Visible.CurrentCellVisible Then
        If gcol.Caption = "Equip" And dgDetail.CurrentCell.Visible Then
            'VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(dgDetail.Top) + dgDetail.RowTop(dgDetail.Row)), _
            cbEquipment.SetBounds(VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(dgDetail.Left) + gcol.Left), _
                                  VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(dgDetail.Top)), _
                                  VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(gcol.Width)), 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y Or Windows.Forms.BoundsSpecified.Width)
            cbEquipment.BringToFront()
            cbEquipment.Focus()
            'Rel 1.3
            'cb_set cbEquipment, gcol.Text
            cb_set(cbEquipment, (dgDetail.CurrentRow.Cells("Equip").Value))
        End If

        'Service
        gcol = dgDetail.Columns("Serv")

        If gcol.Caption = "Serv" And dgDetail.CurrentCell.Visible Then
            'VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(dgDetail.Top) + dgDetail.RowTop(dgDetail.Row)), _
            cbService.SetBounds(VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(dgDetail.Left) + gcol.Left), _
                                VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(dgDetail.Top)), _
                                VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(gcol.Width)), 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y Or Windows.Forms.BoundsSpecified.Width)
            cbService.BringToFront()
            cbService.Focus()
            'Rel 1.3
            'cb_set cbService, gcol.Text
            cb_set(cbService, dgDetail.CurrentRow.Cells("Serv").Value)
        End If

        Exit Sub
ErrorHandler:
        cbService.SetBounds(VB6.TwipsToPixelsX(-10000), 0, 0, 0, Windows.Forms.BoundsSpecified.X)
        cbEquipment.SetBounds(VB6.TwipsToPixelsX(-10000), 0, 0, 0, Windows.Forms.BoundsSpecified.X)
        If dgDetail.Visible Then dgDetail.Focus()

    End Sub
	
	'Busca el texto en el combo
	Private Sub cb_set(ByRef cb As System.Windows.Forms.ComboBox, ByRef sValue As String)
		Dim i As Short
		Dim bFound As Boolean
		
		bFound = False
		bCbSet = True
		For i = 0 To cb.Items.Count - 1
			'Rel 1.3
			'If cb.List(i) = sValue Then
			If Trim(VB6.GetItemString(cb, i)) = Trim(sValue) Then
				cb.SelectedIndex = i
				bFound = True
				Exit For
			End If
		Next i
		If Not bFound And cb.Items.Count > 0 Then
			'Rel 1.3
			'cb.ListIndex = -1 'Que no apunte a ningun registro en especial 09/03/02
			cb.SelectedIndex = 0 'Que apunte por defecto al primer registro de la lista
		End If
	End Sub
	
	
	
    Private Sub sdfTimes_Format(ByVal DataValue As StdFormat.StdDataValue) 'Handles sdfTimes.Format

        'If Not IsNumeric(DataValue) Then
        '    DataValue = 1
        '    dgDetail.Columns("Qty") = 1
        'End If

        If DataValue.Value <= 0 Then
            DataValue.Value = 1.0#
            dgDetail.CurrentRow.Cells("Usage").Value = CStr(1.0#)

            'Else
            '    If IsNumeric(DataValue) Then
            '        getRateVal
            'getSubtotal
            'calc_total
            '    End If
        End If

    End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        '        Dim nResult As Short
        Select Case Button.Name
            Case "new"
                new_invoice()
            Case "save"
                save_invoice2()
            Case "search"
                search_invoice()
            Case "delete"
                delete_invoice()
            Case "exit"
                Me.Close()
        End Select

    End Sub
	'Limpia campos
	Private Sub new_invoice()
        'Dim nResult As Short
		'Agregar aqui validacion si se desea mantener la cabecera
		'de la factura despues de ingresar los datos.
		
		'Actualizar en caso de ser necesario antes de limpiar forma
		requires_update()
		
		nMode = mode.adInsert
		enable_pk(True)
        bClearAll = True
        ignoreStateValidation = True
		clear_form("ALL")
	End Sub
	'Limpia la forma
	Public Sub clear_form(ByRef sOpcion As String)
		'If bClearAll Then
		bRequiresUpdate = False
		Select Case sOpcion
			Case "HEADER"
				cbCustomer.Text = "Customer"
				cbState.Text = "State"
                txtStore.Text = "Store#"
                txtStore.Enabled = True
                txtStore.ReadOnly = False
				txtStore.Tag = ""
				txtStoreId.Text = ""
                cbVendor.Items.Clear()
                cbVendor.Enabled = True
                cbAccount.Items.Clear()
                cbAccount.Enabled = True
				txtInvoice.Text = ""
				dtDate.value = Today
                'dtDate.Value.Day = 1 ' Defaulting Day to first day of current month
				
				'dtStartPeriod.Value = Date
				'dtEndPeriod.Value = Date
				'Rel 1.3
				InitMonth()
				InitYear()
				sNotes = ""
				
				lVendorAddress.Text = ""
				lVendorName.Text = ""
				
                txtWorkOrderNo.Text = ""

                cmdHelpCustomer.Enabled = True
			Case "DETAIL"
				'cbEquipment.Move -10000
				'cbService.Move -10000
				load_detail("OLD")
			Case "VARS"
				nClicks = 0
				nClicksVendor = 0
				nClicksAccount = 0
				sCurrState = ""
				sPrevState = ""
				
			Case "ALL"
				nClicks = 0
				nClicksVendor = 0
				nClicksAccount = 0
				sCurrState = ""
				sPrevState = ""
				
				clear_form("HEADER")
				clear_form("DETAIL")
			Case Else
				MsgBox("Invalid Opcion")
		End Select
	End Sub
	'1.7.3
	'Borra factura solo si estado es CRE
	Private Sub delete_invoice()
        Dim nTran As SqlTransaction = Nothing
        Dim nRecords As Short
        Dim dt As DataTable
		
		On Error GoTo ErrorHandler
		
		
		nRecords = 0
		'Verificar que llave primaria exista
		If cbCustomer.SelectedIndex >= 0 And Len(txtStoreId.Text) > 0 And cbAccount.SelectedIndex >= 0 And cbVendor.SelectedIndex >= 0 And Len(txtInvoice.Text) > 0 Then
			'Confirmar eliminacion
			If MsgBox("Do you want to delete this Invoice?", MsgBoxStyle.YesNo, "GLM Message") = MsgBoxResult.No Then
				Exit Sub
			End If
			
			sStmt = "SELECT  vinvoice_status " & " FROM vinvoice " & " WHERE cust_id ='" & Trim(cbCustomer.Text) & "' " & " AND store_id =" & txtStoreId.Text & " " & " AND account_no = '" & Trim(cbAccount.Text) & "' " & " AND vend_seq = " & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & " " & " AND invoice_no = '" & Trim(txtInvoice.Text) & "' "
			
            'rsLocal.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            rsLocal = getDataTable(sStmt)

            If rsLocal.Rows.Count > 0 Then
                If rsLocal.Rows(0).Item("vinvoice_status") = "CRE" Then
                    'ok
                    nTran = cn.BeginTransaction()
                    'Detail
                    sStmt = "DELETE FROM VInvoiceDet " & " WHERE cust_id ='" & Trim(cbCustomer.Text) & "' " & " AND store_id =" & txtStoreId.Text & " " & " AND account_no = '" & Trim(cbAccount.Text) & "' " & " AND vend_seq = " & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & " " & " AND invoice_no = '" & Trim(txtInvoice.Text) & "' "
                    cmTmp = cn.CreateCommand()
                    cmTmp.Transaction = nTran
                    cmTmp.CommandText = sStmt
                    nRecords = cmTmp.ExecuteNonQuery()
                    If nRecords > 0 Then
                        'Invoice Detail was deleted
                    Else
                        MsgBox("Unable to delete Invoice detail records." & vbCrLf & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                        nTran.Rollback()
                        Exit Sub
                    End If

                    'Header
                    sStmt = "DELETE FROM VInvoice " & " WHERE cust_id ='" & Trim(cbCustomer.Text) & "' " & " AND store_id =" & txtStoreId.Text & " " & " AND account_no = '" & Trim(cbAccount.Text) & "' " & " AND vend_seq = " & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & " " & " AND invoice_no = '" & Trim(txtInvoice.Text) & "' "

                    cmTmp.CommandText = sStmt

                    nRecords = cmTmp.ExecuteNonQuery()
                    If nRecords > 0 Then
                        'Invoice Header was deleted
                        nTran.Commit()
                        'LIMPIAR FORMA
                        clear_form("ALL")
                        MsgBox("Invoice was successfully Deleted.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                        Exit Sub
                    Else
                        MsgBox("Unable to delete Invoice header." & vbCrLf & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                        nTran.Rollback()
                        Exit Sub
                    End If



                Else
                    MsgBox("Invoice can not be deleted because of " & "its Current Status.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                    Exit Sub
                End If

            Else
                MsgBox("Failed to check Invoice Status. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                Exit Sub
            End If
        Else
            MsgBox("You must select an invoice before attempting this command.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
            Exit Sub
        End If
        Exit Sub

ErrorHandler:
        If Not IsNothing(nTran) Then
            nTran.Rollback()
        End If

        save_error(Me.Name, "delete_invoice")
        MsgBox("Failed to delete Invoice. Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
    End Sub
    'Guarda la factura en la base de datos
    Private Sub save_invoice()
        Dim e As ADODB.Error
        Dim nResult As Short
        Dim nFlag As Short
        Dim nInvoiceDetSeq As Short
        Dim bDetail As Boolean
        Dim sStr As String = ""
        Dim nCounter As Short
        Dim nTran As SqlTransaction

        On Error GoTo ErrorHandler

        'bInvoiceSaved = False
        calc_total2()
        nResult = MsgBox("Do you want to save this invoice?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Message")
        bDetail = False
        If nResult = MsgBoxResult.Yes Then

            'rsDetailClone = rsDetail.copy

            If check_header Then
                'Verifica que hayan detalles
                If rsDetail.Rows.Count = 0 Then
                    MsgBox("You must enter Invoice Details", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Warning")
                    Exit Sub
                End If

                'Recorro el recordset para verificar datos
                nInvoiceDetSeq = 1
                nCounter = 1
                'Do While Not rsDetailClone.EOF

                For row As Integer = 0 To rsDetail.Rows.Count - 1
                    'If gbDebug Then
                    '    Text1.Visible = True
                    '    Text1 = Text1 + vbCrLf + CStr(nCounter)
                    '    If MsgBox("Continuar?") = vbNo Then
                    '        Exit Do
                    '    End If
                    'End If

                    nFlag = -1
                    'Rel 1.3
                    'Este release permite que la fecha sea opcional.
                    'If IsNull(rsDetailClone("Date")) Then
                    '    MsgBox "One or more rows have a missing Date.", _
                    ''        vbInformation + vbOKOnly, "Warning"
                    '    Exit Sub
                    'End If

                    'If IsNull(rsDetailClone("Equipment")) _
                    ''Or rsDetailClone("Equipment") = 0 Then

                    If (IsDBNull(rsDetail.Rows(row).Item("Equipment")) Or rsDetail.Rows(row).Item("Equipment") = 0) Then
                        'Equipment = NULL/0   Service=NULL
                        'If IsNull(rsDetailClone("Service")) Then

                        If IsDBNull(rsDetail.Rows(row).Item("Service")) Then
                            MsgBox("Both Equipment/Service information can not be null.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Warning")
                            Exit Sub
                        End If

                        'Equipment = NULL/0   Service= NOT NULL
                        'No hay problema si el servicio
                        'pertence al grupo de los servicios que
                        'no se relacionan a un equipo
                        'If rsDetail("Service") = "Taxes" Then
                        'If Not serv_4_eqpt(rsDetailClone("Service")) Then
                        If Not serv_4_eqpt(rsDetail.Rows(row).Item("Service")) Then
                            nFlag = 0
                        Else
                            MsgBox("Equipment must be defined for this Service.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Warning")
                            Exit Sub
                        End If
                    Else
                        'Equipment = NOT NULL   Service = NULL
                        'If IsNull(rsDetailClone("Service")) Then
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rsDetail.Rows(row).Item("Service")) Then
                            MsgBox("Service information is required", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Warning")
                            Exit Sub
                        Else
                            'Equipment = NOT NULL   Service =NOT NULL
                            'Si el equipo-servicio no require tarifa de VContract
                            'y el servicio no depende de un equipo
                            'If serv_4_rate_contract(rsDetailClone("Service")) = False Then
                            If serv_4_rate_contract(rsDetail.Rows(row).Item("Service")) = False Then
                                'If serv_4_eqpt(rsDetailClone("Service")) = True Then
                                If serv_4_eqpt(rsDetail.Rows(row).Item("Service")) = True Then
                                    nFlag = 0 'Tarifa no debe ser verifcada en VContract
                                End If
                            End If
                        End If
                    End If

                    If nFlag = -1 Then
                        'nFlag = check_detail(rsDetailClone("Equipment"), _
                        ''              rsDetailClone("Service"))
                        nFlag = check_detail(rsDetail.Rows(row).Item("Equipment"), rsDetail.Rows(row).Item("Service"))
                    End If

                    Select Case nFlag
                        Case 0 ' Ok
                            'rsDetailClone("cust_id") = cbCustomer
                            'rsDetailClone("vend_seq") = cbVendor.ItemData(cbVendor.ListIndex)
                            'rsDetailClone("store_id") = txtStoreId
                            'rsDetailClone("invoice_no") = txtInvoice
                            'rsDetailClone("account_no") = cbAccount
                            'rsDetailClone("invoice_det_no") = nInvoiceDetSeq

                            rsDetail.Rows(row).Item("cust_id") = cbCustomer.Text
                            rsDetail.Rows(row).Item("vend_seq") = VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)
                            rsDetail.Rows(row).Item("store_id") = txtStoreId.Text
                            rsDetail.Rows(row).Item("invoice_no") = txtInvoice.Text
                            rsDetail.Rows(row).Item("account_no") = cbAccount.Text
                            If nMode = mode.adInsert Then
                                rsDetail.Rows(row).Item("invoice_det_no") = nInvoiceDetSeq
                            End If

                            'If rsDetail("Equipment") = 0 Then
                            '    rsDetail("Equipment") = ""
                            'End If
                            nInvoiceDetSeq = nInvoiceDetSeq + 1
                        Case 1 'Uno o mas registros sin datos
                            'Rel 1.3
                            'rsDetail.Bookmark = rsDetailClone.Bookmark
                            'dgDetail.SelBookmarks.Add(rsDetail.Bookmark)
                            bDetail = True
                        Case Else
                            MsgBox("Program was not able to verify service/equipment " & "information.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                            Exit Sub
                    End Select 'Correct equipment and service
                    'rsDetailClone.MoveNext
                    MsgBox("DEBUG:" & Str(rsDetail.Rows(row).Item("invoice_det_no")))


                    nCounter = nCounter + 1
                Next row



                'Muevo el puntero del rs a un registro con datos
                '                rsDetail.MoveLast()

                'Guardo en la base y verifico que se hayan ingresado correctamente
                If bDetail Then
                    MsgBox("These Equipments/Services are either not defined " & vbCrLf & "in the database or are incorrectly assigned." & vbCrLf & "Please check or ask your Supervisor.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Sub
                Else

                    'If bInvoiceSaved = False Then
                    'Inserto en la base


                    nTran = cn.BeginTransaction()
                    cmTmp = cn.CreateCommand()

                    If nMode = mode.adInsert Then
                        sStr = "INSERT INTO VInvoice " & "(cust_id, store_id, vend_seq, account_no, " & "invoice_no, vinvoice_date, " & "month_period, year_period, " & "total, vinvoice_status,notes)  VALUES " & _
                                                         "('" & Trim(cbCustomer.Text) & "'," & txtStoreId.Text & ", " & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & ", " & "'" & Trim(cbAccount.Text) & "', '" & Trim(txtInvoice.Text) & "', " & "'" & CStr(dtDate.Value) & "', '" & CStr(cbMonthPeriod.Text) & "', '" & CStr(txtYearPeriod.Text) & "', " & txtTotal.Text & " ,'CRE'," & "'" & Trim(sNotes) & "')"
                    End If

                    If nMode = mode.adUpdate Then
                        sStr = "UPDATE VInvoice SET  " & "vinvoice_date = '" & CStr(dtDate.Value) & "', " & "month_period = '" & CStr(cbMonthPeriod.Text) & "'," & "year_period = '" & CStr(txtYearPeriod.Text) & "', " & "notes = '" & Trim(sNotes) & "' " & "WHERE cust_id ='" & Trim(cbCustomer.Text) & "' " & "AND store_id=" & txtStoreId.Text & " " & "AND vend_seq=" & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & " " & "AND account_no='" & Trim(cbAccount.Text) & "' " & "AND invoice_no='" & Trim(txtInvoice.Text) & "' "
                    End If

                    cmTmp.CommandText = sStr

                    If nMode = mode.adInsert Then
                        'Verifico que la factura no haya sido ingresada.
                        sStr = "SELECT * FROM VInvoice " & "WHERE cust_id = '" & Trim(cbCustomer.Text) & "' " & "AND store_id = '" & txtStoreId.Text & "' " & "AND vend_seq =" & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & " " & "AND account_no = '" & Trim(cbAccount.Text) & "' " & "AND invoice_no = '" & Trim(txtInvoice.Text) & "' "

                        rs = getDataTable(sStr) '.Open(sStr, cn)

                        If rs.Rows.Count > 0 Then
                            MsgBox("This invoice was " & Chr(13) & "already inserted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                            nTran.Rollback()
                            Exit Sub
                        End If

                    End If

                    nResult = cmTmp.ExecuteNonQuery() 'INSERT / UPDATE VINVOICE

                    'rsDetail.UpdateBatch()

                    nTran.Commit()
                    'Como la factura se guardo en la base cambio el modo
                    'de la forma a actualizacion
                    nMode = mode.adUpdate
                    MsgBox("Invoice was saved", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Message")
                    enable_pk(False)
                    cmDetail.Parameters(0).Value = cbCustomer.Text
                    cmDetail.Parameters(1).Value = txtInvoice.Text
                    cmDetail.Parameters(2).Value = VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)
                    cmDetail.Parameters(3).Value = cbAccount.Text
                    cmDetail.Parameters(4).Value = txtStore.Text
                    'rsDetail.Requery
                    'rsDetail.Resync()
                    'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
                    dgDetail.Refresh()


                    'Else 'Actualizo informacion
                    '     rsDetail.UpdateBatch
                    'End If
                End If 'bDetail

            Else
                Exit Sub
            End If 'check_header
        Else
            '    rsDetail.CancelBatch adAffectAllChapters
            Exit Sub
        End If
        bInvoiceSaved = True
        Exit Sub

ErrorHandler:
        bInvoiceSaved = False
        MsgBox("An error has ocurred while saving data!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error ")
        MsgBox(Err.Description)
        'MsgBox "numero=" + Str(Err.Number)


        MsgBox(e.Description)
        '   MsgBox "otro numero" + Str(e.NativeError)

        'rsDetail.MoveFirst
        'While Not rsDetail.EOF
        '   save_error "invoice", rsDetail.Fields("invoice_no") + " " + rsDetail.item("invoice_det_no")
        'save_error "invoice_det", rsDetail.item("invoice_det_no")
        'save_error "cust_id", rsDetail.item("cust_id")
        'save_error "store_id", rsDetail.item("store_id")
        'save_error "vend_seq", rsDetail.item("vend_seq")
        'save_error "account_no", rsDetail.item("account_no")
        '    rsDetail.MoveNext
        'Wend
        Resume Next
    End Sub
    'InsertarActualizar Factura en DB
    'nOption: Bandera para indicar si se pregunta confirmacion de
    'guardado a usuario o no
    Private Sub save_invoice2(Optional ByRef nOption As Short = 0)
        Dim e As ADODB.Error
        Dim nResult As Short
        Dim nFlag As Short
        Dim nInvoiceDetSeq As Short
        Dim bDetail As Boolean
        Dim sStr As String = ""
        Dim nCounter As Short
        Dim sGroupName As String

        On Error GoTo ErrorHandler

        'bInvoiceSaved = False
        calc_total2()

        'Verificar si invoice se puede actualizar
        If nMode = mode.adUpdate Then
            sStmt = "SELECT vinvoice_status FROM vinvoice " & " WHERE cust_id ='" & Trim(cbCustomer.Text) & "' " & " AND vend_seq = " & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & " AND store_id =" & txtStoreId.Text & " AND invoice_no ='" & Trim(txtInvoice.Text) & "' " & " AND account_no ='" & Trim(cbAccount.Text) & "'"
            gDump = exec_sql_single(sStmt)
            If gDump.str1 <> "CRE" Then
                MsgBox("Invoice can not be updated in its current status.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
                Exit Sub
            End If
        End If

        'Confirmar
        If nOption = MsgBoxResult.Yes Then
            nResult = MsgBoxResult.Yes
        Else
            nResult = MsgBox("Do you want to save this invoice?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Message")
        End If


        bDetail = False
        Dim nTran As SqlTransaction
        If nResult = MsgBoxResult.Yes Then

            'rsDetailClone = rsDetail.copy

            If check_header Then
                'Verifica que hayan detalles
                If rsDetail.Rows.Count = 0 Or bLastDeleted Then
                    MsgBox("You must enter Invoice Details", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Warning")
                    Exit Sub
                End If

                'Recorro el recordset para verificar datos
                nCounter = 1
                Select Case nMode
                    Case mode.adInsert
                        nInvoiceDetSeq = 1
                    Case mode.adUpdate
                        sStmt = "SELECT MAX(invoice_det_no) FROM VInvoiceDet " & " WHERE cust_id ='" & Trim(cbCustomer.Text) & "' " & " AND vend_seq = " & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & " AND store_id =" & txtStoreId.Text & " AND invoice_no ='" & Trim(txtInvoice.Text) & "' " & " AND account_no ='" & Trim(cbAccount.Text) & "'"
                        'UPGRADE_WARNING: Couldn't resolve default property of object gDump. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        gDump = exec_sql_single(sStmt)
                        nInvoiceDetSeq = Int(CDbl(gDump.str1))
                End Select

                'Do While Not rsDetailClone.EOF

                For row As Integer = 0 To rsDetail.Rows.Count - 1
                    nFlag = -1
                    'Rel 1.3 .Este release permite que la fecha sea opcional.
                    'If IsNull(rsDetailClone("Equipment")) _
                    ''Or rsDetailClone("Equipment") = 0 Then

                    If (IsDBNull(rsDetail.Rows(row).Item("Equipment")) Or rsDetail.Rows(row).Item("Equipment") = 0) Then
                        'Equipment = NULL/0   Service=NULL
                        'If IsNull(rsDetailClone("Service")) Then

                        If IsDBNull(rsDetail.Rows(row).Item("Service")) Then
                            MsgBox("Both Equipment/Service information can not be null.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Warning")
                            Exit Sub
                        End If

                        'Equipment = NULL/0   Service= NOT NULL
                        'No hay problema si el servicio
                        'pertence al grupo de los servicios que
                        'no se relacionan a un equipo
                        nFlag = 0
                        'If Not serv_4_eqpt(rsDetail("Service")) Then
                        '    nFlag = 0
                        'Else
                        '    MsgBox "Equipment must be defined for this Service.", _
                        ''        vbInformation + vbOKOnly, "Warning"
                        '    Exit Sub
                        'End If
                    Else
                        'Equipment = NOT NULL   Service = NULL

                        If IsDBNull(rsDetail.Rows(row).Item("Service")) Then
                            MsgBox("Service information is required", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Warning")
                            Exit Sub
                        Else
                            'Equipment = NOT NULL   Service =NOT NULL
                            nFlag = 0
                            'Si el equipo-servicio no require tarifa de VContract
                            'y el servicio no depende de un equipo
                            'If serv_4_rate_contract(rsDetail("Service")) = False Then
                            '    If serv_4_eqpt(rsDetail("Service")) = True Then
                            '        nFlag = 0   'Tarifa no debe ser verifcada en VContract
                            '    End If
                            'End If
                        End If
                    End If

                    'If nFlag = -1 Then
                    '    nFlag = check_detail(rsDetail("Equipment"), _
                    ''                  rsDetail("Service"))
                    'End If

                    Select Case nFlag
                        Case 0 ' Ok
                            rsDetail.Rows(row).Item("cust_id") = cbCustomer.Text
                            rsDetail.Rows(row).Item("vend_seq") = VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)
                            rsDetail.Rows(row).Item("store_id") = txtStoreId.Text
                            rsDetail.Rows(row).Item("invoice_no") = txtInvoice.Text
                            rsDetail.Rows(row).Item("account_no") = cbAccount.Text
                            'If nMode = adInsert Then

                            If IsDBNull(rsDetail.Rows(row).Item("invoice_det_no").ToString) Then
                                rsDetail.Rows(row).Item("invoice_det_no") = nInvoiceDetSeq
                            Else
                                If rsDetail.Rows(row).Item("invoice_det_no").ToString = "" Then
                                    rsDetail.Rows(row).Item("invoice_det_no") = nInvoiceDetSeq
                                End If
                            End If
                            
                            nInvoiceDetSeq = nInvoiceDetSeq + 1
                        Case 1 'Uno o mas registros sin datos
                            'Rel 1.3
                            'rsDetail.Bookmark = rsDetailClone.Bookmark
                            'dgDetail.SelBookmarks.Add(rsDetail.Bookmark)
                            bDetail = True
                        Case Else
                            MsgBox("Program was not able to verify service/equipment " & "information.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                            Exit Sub
                    End Select 'Correct equipment and service


                    nCounter = nCounter + 1
                Next


                'Muevo el puntero del rs a un registro con datos
                '                rsDetail.MoveLast()

                'Guardo en la base y verifico que se hayan ingresado correctamente
                If bDetail Then
                    MsgBox("These Equipments/Services are either not defined " & vbCrLf & "in the database or are incorrectly assigned." & vbCrLf & "Please check or ask your Supervisor.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Sub
                Else
                    'Inserto en la base

                    nTran = cn.BeginTransaction()
                    cmTmp = cn.CreateCommand()
                    cmTmp.Transaction = nTran
                    'Cabecera
                    If cbGroupName.SelectedIndex < 0 Then
                        sGroupName = "NULL"
                    Else
                        sGroupName = CStr(VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex))
                    End If

                    If nMode = mode.adInsert Then
                        sStr = "INSERT INTO VInvoice " & _
                                    "(cust_id, store_id, vend_seq, account_no, " & _
                                    "invoice_no, vinvoice_date, " & _
                                    "period_seq,  " & _
                                    "total, vinvoice_status,notes, " & _
                                    "create_user, group_seq, work_order, glm_total, sc, extc) " & _
                                " VALUES " & _
                                    "('" & Trim(cbCustomer.Text) & "'," & _
                                        txtStoreId.Text & ", " & _
                                        Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & ", " _
                                        & "'" & Trim(cbAccount.Text) & "', '" & Trim(txtInvoice.Text) & _
                                        "', " & "'" & CStr(dtDate.Value) & "', " & _
                                        CStr(VB6.GetItemData(cbPeriod, cbPeriod.SelectedIndex)) & _
                                        ", " & txtTotal.Text & " ,'CRE'," & _
                                        "'" & Trim(sNotes) & "', " & _
                                        "'" & Trim(gsUser) & "'," & _
                                        sGroupName & "," & _
                                        "'" & Trim(quotation_mask(txtWorkOrderNo.Text)) & "'," & _
                                        txtGlmTotal.Text & ", " & _
                                        "'" & Trim(quotation_mask((txtSc.Text))) & "'," & _
                                        "'" & Trim(quotation_mask((txtExtc.Text))) & "')"
                    End If

                    If nMode = mode.adUpdate Then
                        sStr = "UPDATE VInvoice SET  " & "vinvoice_date = '" & CStr(dtDate.Value) & "', " & "period_seq = '" & CStr(VB6.GetItemData(cbPeriod, cbPeriod.SelectedIndex)) & "'," & "notes = '" & Trim(sNotes) & "', " & "change_user ='" & Trim(gsUser) & "', " & "change_time = getdate() , " & "total = " & txtTotal.Text & ", " & "group_seq = " & sGroupName & ", " & "work_order ='" & Trim(quotation_mask(txtWorkOrderNo.Text)) & "'," & "glm_total = " & txtGlmTotal.Text & ", " & "sc = '" & Trim(quotation_mask((txtSc.Text))) & "'," & "extc = '" & Trim(quotation_mask((txtExtc.Text))) & "' " & "WHERE cust_id ='" & Trim(cbCustomer.Text) & "' " & "AND store_id=" & txtStoreId.Text & " " & "AND vend_seq=" & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & " " & "AND account_no='" & Trim(cbAccount.Text) & "' " & "AND invoice_no='" & Trim(txtInvoice.Text) & "' "
                    End If

                    cmTmp.CommandText = sStr

                    If nMode = mode.adInsert Then
                        'Verifico que la factura no haya sido ingresada.
                        sStr = "SELECT * FROM VInvoice " & "WHERE cust_id = '" & Trim(cbCustomer.Text) & "' " & "AND store_id = '" & txtStoreId.Text & "' " & "AND vend_seq =" & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & " " & "AND account_no = '" & Trim(cbAccount.Text) & "' " & "AND invoice_no = '" & Trim(txtInvoice.Text) & "' "

                        
                        rs = getDataTable(sStr, nTran) '.Open(sStr, cn)

                        If rs.Rows.Count > 0 Then
                            MsgBox("This invoice was " & Chr(13) & "already inserted.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
                            nTran.Rollback()
                            Exit Sub
                        End If

                    End If

                    'poner los detalles en la base de datos aqui!!!!!!!
                    'rsDetail.UpdateBatch() 'DETALLE
                    'pendiente actualizar pesos

                    'gInvDetRecord.rsDetailWgt.UpdateBatch 'WEIGHTS
                    'daDetail.

                    'If invoice was imported from LF, update status in lf2gis_vinvoice table
                    If nMode = mode.adInsert And bImportedFromLF Then
                        update_lf2gis_vinvoice((cbCustomer.Text), CShort(txtStoreId.Text), (cbAccount.Text), VB6.GetItemData(cbVendor, cbVendor.SelectedIndex), txtInvoice.Text, "IMPORTED", "Invoice was successfully imported to GIS", nTran)
                    End If

                    nResult = cmTmp.ExecuteNonQuery() 'INSERT / UPDATE VINVOICE
                    nTran.Commit()
                    daDetail.Update(rsDetail)


                    'Invoice was saved in db, I change invoice mode to Update
                    nMode = mode.adUpdate
                    bRequiresUpdate = False

                    If bImportedFromLF Then
                        If MsgBox("Invoice was saved." & vbCrLf & "Do you want close this screen?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Message") = MsgBoxResult.Yes Then

                            Me.Close()
                            Exit Sub
                        End If
                    Else
                        MsgBox("Invoice was saved", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Message")
                    End If

                    enable_pk(False)
                    cmDetail.Parameters(0).Value = cbCustomer.Text
                    cmDetail.Parameters(1).Value = txtInvoice.Text
                    cmDetail.Parameters(2).Value = VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)
                    cmDetail.Parameters(3).Value = cbAccount.Text
                    cmDetail.Parameters(4).Value = txtStore.Text
                    'rsDetail.Requery
                    'rsDetail.Resync
                    'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
                    dgDetail.Refresh()
                End If 'bDetail

            Else
                Exit Sub
            End If 'check_header
        Else
            '    rsDetail.CancelBatch adAffectAllChapters
            Exit Sub
        End If
        bInvoiceSaved = True
        Exit Sub

ErrorHandler:
        If Not IsNothing(nTran) Then
            'nTran.Dispose()
            nTran.Rollback()
        End If
        bInvoiceSaved = False
        save_error(Me.Name, "save_invoice2")
        MsgBox("An error has ocurred while saving data!. Check log file for details", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error ")
    End Sub
	'Determina si un servicio requiere relacionarse o no
	'con un equipo
	Private Function serv_4_eqpt(ByRef nService As Short) As Boolean
		
		'On Error GoTo ErrorHandler
		
		
		sStmt = "SELECT count(*) FROM service WHERE serv_eqpt='F'" & "AND serv_id =" & Str(nService)
		
        rsLocal = getDataTable(sStmt) ' .Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsLocal.Rows(0).Item(0) >= 1 Then
            serv_4_eqpt = False 'Servicio no asociado a equipo
        Else
            serv_4_eqpt = True 'Servicio asociado a equipo
        End If

		Exit Function
		
ErrorHandler: 
		serv_4_eqpt = False
		
		save_error("frmInvoiceBooking", "serv_4_equip")
		MsgBox("Failed to retrieve Equipment's service info." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Function
	'Determina si la tarifa de un servicio-equipo  se lo
	'debe tomar de la tabla VContract, caso contrario debe ser proporcionada
	'por usuario.
	Private Function serv_4_rate_contract(ByRef nService As Short) As Boolean
		
		'On Error GoTo ErrorHandler

		sStmt = "SELECT serv_rate_contract FROM Service " & "WHERE serv_id =" & CStr(nService)
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If Trim(rsLocal.Rows(0).Item("serv_rate_contract")) = "F" Then
            serv_4_rate_contract = False 'Servicio es independiente de tabla VContract
        Else
            serv_4_rate_contract = True 'Servicio esta definido en tabla VContract
        End If

		Exit Function
		
ErrorHandler: 
		serv_4_rate_contract = True
		
	End Function
	'Ayuda para seleccionar una factura
	Private Sub search_invoice()
		VB6.ShowForm(frmInvoiceSearch, VB6.FormShowConstants.Modal, Me)
	End Sub
	'Valida los controles de la cabecera de la factura
	Private Function check_header() As Boolean
		Dim sStr As String
		
		On Error GoTo ErrorHandler
		
		If cbCustomer.SelectedIndex = -1 Then
			MsgBox("You must select a customer", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Message")
			check_header = False
			Exit Function
		End If
		
		If cbState.SelectedIndex = -1 Then
			MsgBox("You must select a State", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Message")
			check_header = False
			Exit Function
		End If
		
		If txtStoreId.Text <> "" Then
			sStr = "SELECT store_id  " & "FROM store " & "WHERE cust_id ='" & Me.cbCustomer.Text & "' " & "AND state_id ='" & Me.cbState.Text & "' " & "AND store_number ='" & txtStore.Text & "' "
			
            rs = getDataTable(sStr) '.Open(sStr, cn)
            If rs.Rows.Count = 0 Then
                MsgBox("Please insert a Store or pick one from Help Screen", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message")
                check_header = False
                Exit Function
            Else
                txtStore.Tag = rs.Rows(0).Item("store_id")
                txtStoreId.Text = rs.Rows(0).Item("store_id")
            End If
			
		End If
		
		If cbVendor.SelectedIndex = -1 Then
			MsgBox("You must select a Vendor", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Message")
			check_header = False
			Exit Function
		Else
			'Verificar vendedor en QuickBooks
			If Not verify_qb_vendor(cbCustomer.Text, VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) Then
				MsgBox("Missing QuickBooks Setting. You must assign a QB Vendor before using this Vendor", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
				cbVendor.Focus()
				check_header = False
				Exit Function
			End If
		End If
		
		
		If cbAccount.SelectedIndex = -1 Then
			MsgBox("You must select an Account ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Message")
			check_header = False
			Exit Function
		End If
		
		If txtInvoice.Text = "" Then
			MsgBox("You must enter the Invoice Number ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Message")
			check_header = False
			Exit Function
		End If
		
		If cbPeriod.SelectedIndex = -1 Then
			MsgBox("You must select an Invoicing Period", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
			check_header = False
			Exit Function
		End If
		
        'If dtStartPeriod > dtEndPeriod Then
		'    MsgBox "Start date should not be higher than End date period", vbInformation + vbOKOnly, "Message"
		'    check_header = False
		'    Exit Function
		'End If
		
		'Validacion no requerida por usuario
		'If dtDate < dtStartPeriod Or dtDate > dtEndPeriod Then
		'    MsgBox "Invoice Date does not belong to the period", vbInformation + vbOKOnly, "Message"
		'    check_header = False
		'    Exit Function
		'End If
		
		check_header = True
		Exit Function
		
ErrorHandler: 
		check_header = False
		save_error(Me.Name, "Check_header:An error while validating data has ocurred")
		Resume Next
	End Function
	'Valida informacion del equipo y servicio en cada detalle de la factura
	Private Function check_detail(ByRef nEquipment As Short, ByRef nService As Short) As Short
        'Dim e As ADODB.Error
		
		
		'On Error GoTo ErrorHandler
		
		
		'Verificar que el equipo/servicio existan en la base de datos
		check_detail = 1 'Not valid equipment/service
		
        If Not rsTmp.Rows.Count > 0 Then
            load_rs()
        End If
		
        If rsTmp.Rows.Count > 0 Then
            rsTmp.Select() '= ADODB.FilterGroupEnum.adFilterNone


            For row As Integer = 0 To rsTmp.Rows.Count - 1
                If rsTmp.Rows(row).Item("eqpt_seq") = nEquipment And rsTmp.Rows(row).Item("serv_id") = nService Then
                    check_detail = 0
                    Exit For
                End If

            Next


        End If 'Recordcount
		
		
		Exit Function
		
ErrorHandler: 
		check_detail = -1
		
		save_error("frmInvoiceBooking", "check_detail")
	End Function
	
	
	
	Private Sub txtInvoice_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtInvoice.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Rel 1.3 Sin restricciones
		'Permite ingresar caracteres en la factura pero los hace mayusculas
		If KeyAscii >= 97 And KeyAscii <= 122 Then
			KeyAscii = Asc(UCase(Chr(KeyAscii)))
		End If
		'If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Then
		'Else
		'    KeyAscii = 0
		'End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtStore_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtStore.Enter
		txtStore.SelectionStart = 0
		txtStore.SelectionLength = Len(txtStore.Text)
	End Sub
	
	Private Sub txtStore_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtStore.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		
		On Error GoTo ErrorHandler
		
		'Do not react when text Enabled property changes
		If Not bReaction Then
			GoTo EventExitSub
		End If
		
		populateStoreAddressAndVendorCombo()
		
		GoTo EventExitSub
		
ErrorHandler: 
		save_error("frmInvoiceBooking", "txtStore_validate")
		MsgBox("An unexpected error has ocurred, check log file for details", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Error")
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	Public Sub populateStoreAddressAndVendorCombo()
		Dim sStr As String
		
		
		
        sStr = "SELECT store_id, store_number ," & "store_address , " & "store_city ," & "store_zip  " & "FROM store " & _
                "WHERE cust_id ='" & Me.cbCustomer.Text & "' " & "AND state_id ='" & Me.cbState.Text & "' " & "AND store_number='" & txtStore.Text & "'"
		
        rs = getDataTable(sStr) '.Open(sStr, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		
        If rs.Rows.Count = 1 Then
            txtStore.Tag = rs.Rows(0).Item("store_id")
            txtStoreId.Text = rs.Rows(0).Item("store_id")
            lVendorAddress.Text = Trim(rs.Rows(0).Item("store_address")) & _
                                " " & vbCrLf & Trim(rs.Rows(0).Item("store_city")) & _
                                " " & vbCrLf & Trim(rs.Rows(0).Item("store_zip"))
        Else
            If rs.Rows.Count = 0 And bUserCancel = False Then
                MsgBox("Could not find Store. Please check Customer, State or Store Number" & vbCrLf & "Click Help button for further assistance.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Warning")
                txtStore.Tag = ""
                txtStoreId.Text = ""
                lVendorAddress.Text = ""
                Exit Sub
            End If
        End If
		
		'Load Vendor combo because Customer, Store and State info is correct
		cbVendor.SelectedIndex = -1
		cbVendor.Items.Clear()
		
		load_combo(cbVendor)
		
		
		
	End Sub
	
	'Funcion para cargar la direccion del store
	'Es una extension de lo que hace el evento txtstore_validate
	Public Sub load_address(ByRef sCustomer As String, ByRef sStore As String, ByRef sState As String)
		Dim sStr As String
		
		On Error GoTo ErrorHandler
		
		
		
		sStr = "SELECT store_id, store_number ," & "store_address , " & "store_city ," & "store_zip  " & "FROM store " & "WHERE cust_id ='" & Trim(sCustomer) & "' " & "AND state_id ='" & Trim(sState) & "' " & "AND store_number='" & Trim(sStore) & "'"
		
        rs = getDataTable(sStr) '.Open(sStr, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		
        If rs.Rows.Count = 1 Then
            lVendorAddress.Text = Trim(rs.Rows(0).Item("store_address")) & " " & vbCrLf & Trim(rs.Rows(0).Item("store_city")) & " " & vbCrLf & Trim(rs.Rows(0).Item("store_zip"))
        End If
		Exit Sub
		
ErrorHandler: 
		save_error("frmInvoiceBooking", "load_address")
	End Sub
	
	'Habilita / Deshabilita la llave primaria de la factura
	Public Sub enable_pk(ByRef bActive As Boolean)
		
		bReaction = False
		
		cbCustomer.Enabled = bActive
		cbState.Enabled = bActive
		txtStore.Enabled = bActive
		cbVendor.Enabled = bActive
		cbAccount.Enabled = bActive
		txtInvoice.Enabled = bActive
		cmdHelpCustomer.Enabled = bActive
		
		bReaction = True
	End Sub
	'Rel 1.3
	'Carga el Combo de Meses de Periodo
	Private Sub load_cb_month()
        'Dim i As Short
		
		cbMonthPeriod.Items.Clear()
		
		cbMonthPeriod.Items.Insert(0, "January")
		cbMonthPeriod.Items.Insert(1, "February")
		cbMonthPeriod.Items.Insert(2, "March")
		cbMonthPeriod.Items.Insert(3, "April")
		cbMonthPeriod.Items.Insert(4, "May")
		cbMonthPeriod.Items.Insert(5, "June")
		cbMonthPeriod.Items.Insert(6, "July")
		cbMonthPeriod.Items.Insert(7, "August")
		cbMonthPeriod.Items.Insert(8, "September")
		cbMonthPeriod.Items.Insert(9, "October")
		cbMonthPeriod.Items.Insert(10, "November")
		cbMonthPeriod.Items.Insert(11, "December")
		
		
		cbMonthPeriod.SelectedIndex = CShort(Month(Today)) - 1
		'jp.20110103.begin
        'UpDown1 = Year(Date)
		'jp.20110103.end
	End Sub
	Private Sub InitMonth()
		cbMonthPeriod.SelectedIndex = CShort(Month(Today)) - 1
	End Sub
	Private Sub InitYear()
		'jp.20110103.begin
		'UpDown1.value = Year(Date)
		'jp.20110103.end
	End Sub
	'Rel 1.3
	'Actualiza la tarifa de un equipo-servicio en la table VContract
	Private Function update_rate(Optional ByRef nRate As Double = 0, Optional ByRef sCustId As String = "", Optional ByRef nVendSeq As Short = 0, Optional ByRef sStoreId As String = "", Optional ByRef nEqptSeq As Short = 0, Optional ByRef nServId As Short = 0) As Boolean
		
		Dim nResult As Short
		
		'On Error GoTo ErrorHandler
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(nRate) Or nRate = 0 Or sCustId = "" Or nVendSeq = 0 Or sStoreId = "" Or nEqptSeq = 0 Or nServId = 0 Then
			update_rate = False
			Exit Function
		End If
		
        cmTmp = cn.CreateCommand
		'Inserto una copia del contrato antes de actualizarla
		sStmt = "INSERT INTO VContractHistory " & "(cust_id, vend_seq, store_id, eqpt_seq, serv_id, " & "freq_times, freq_period, freq_day1, freq_day2, " & "freq_day3, freq_day4, freq_day5, freq_day6, " & "freq_day7, curr_rate, old_rate, opening_date," & "expiration_date, rebate_ton_price, rate_status, " & "suser_name) " & "SELECT cust_id, vend_seq, store_id, eqpt_seq, serv_id, " & "freq_times, freq_period, freq_day1, freq_day2, " & "freq_day3, freq_day4, freq_day5, freq_day6, " & "freq_day7, curr_rate, old_rate, opening_date," & "expiration_date, rebate_ton_price, rate_status, " & "'" & Trim(gsUser) & "'" & "FROM VContract " & "WHERE cust_id ='" & Trim(sCustId) & "' " & "AND store_id =" & Trim(sStoreId) & " " & "AND vend_seq =" & CStr(nVendSeq) & " " & "AND eqpt_seq= " & CStr(nEqptSeq) & " " & "AND serv_id =" & CStr(nServId) & " "
		cmTmp.CommandText = sStmt
        nResult = cmTmp.ExecuteNonQuery()
		'If rsLocal.State = adStateOpen Then
		'    rsLocal.Close
		'End If
		'rsLocal.Open sStmt, cn, adOpenStatic, adLockReadOnly
		
		sStmt = "UPDATE VContract " & "SET curr_rate =" & CStr(nRate) & " " & "WHERE cust_id ='" & Trim(sCustId) & "' " & "AND store_id =" & Trim(sStoreId) & " " & "AND vend_seq =" & CStr(nVendSeq) & " " & "AND eqpt_seq= " & CStr(nEqptSeq) & " " & "AND serv_id =" & CStr(nServId) & " "
		
		cmTmp.CommandText = sStmt
		
		nResult = 0
        nResult = cmTmp.ExecuteNonQuery()
		'MsgBox nResult
		If nResult > 0 Then
			update_rate = True
		Else
			update_rate = False
		End If
		Exit Function
		
ErrorHandler: 
		update_rate = False
		save_error("frmInvoiceBooking", "update_rate")
		MsgBox("Failed to Update Service Rate." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Function
	'Rel 1.3
	'Verifica que el usuario disponga de permiso para
	'actualizar las tarifas en la tabla VContract
	Private Function check_permission() As Boolean
		
		On Error GoTo ErrorHandler
		
		sStmt = "SELECT type_id, suser_name FROM suser_data " & "WHERE suser_name ='" & Trim(gsUser) & "' " & "AND cust_id ='" & Trim(cbCustomer.Text) & "' " & "AND state_id ='" & Trim(cbState.Text) & "' "
		
        rsLocal = getDataTable(sStmt) ' exec_sql(sStmt)

        If rsLocal.Rows.Count > 0 Then
            If rsLocal.Rows(0).Item("type_id") = "A" Or rsLocal.Rows(0).Item("type_id") = "C" Then
                'You can do it
                check_permission = True
            Else
                'No way
                check_permission = False
            End If

        Else
            check_permission = False
        End If

        Exit Function

ErrorHandler:
        check_permission = False
        save_error("frmInvoiceBooking", "check_permission")
        MsgBox("Failed to check user privileges on Contract table." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
		
		
	End Function
	
	'Verifica que la pareja equipo-servicio existan en la tabla de contratos
	Private Function check_contract_item(Optional ByRef nEqptSeq As Short = 0, Optional ByRef nServId As Short = 0) As Boolean
		
		On Error GoTo ErrorHandler
		
		sStmt = "SELECT count(*) FROM VContract " & "WHERE cust_id ='" & Trim(cbCustomer.Text) & "' " & "AND vend_seq =" & CStr(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)) & " " & "AND store_id =" & CStr(txtStoreId.Text) & "AND eqpt_seq = " & CStr(nEqptSeq) & " " & "AND serv_id =" & CStr(nServId)
		
		
		
        rsLocal = getDataTable(sStmt) ' exec_sql(sStmt)

        If rsLocal.Rows(0).Item(0) > 0 Then
            check_contract_item = True
        Else
            check_contract_item = False
        End If


        Exit Function

ErrorHandler:
        check_contract_item = False
        save_error("frmInvoiceBooking", "check_contract_item")
        MsgBox("Failed to Check Contract Info." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
		
		
	End Function
	'This method populates header fields
	Public Sub populateHeader(ByRef sCustId As String, ByRef sStoreId As String, ByRef sStoreNumber As String, ByRef sStateId As String, ByRef nVendSeq As Short, ByRef sAccountNo As String, ByRef sInvoiceNo As String)
		
		populateCustomer(sCustId)
		populateState(sStateId)
		populateStore(sStoreId, sStoreNumber)
		populateStoreAddressAndVendorCombo()
		populateVendor(nVendSeq)
		populateAccount(sAccountNo)
		populateInvoice(sInvoiceNo)
		
		enableHeaderFields(False)
		
	End Sub
	
	Public Sub populateCustomer(ByRef sCustId As String)
		Dim i As Short
		
		For i = 0 To Me.cbCustomer.Items.Count - 1
			If sCustId = VB6.GetItemString(Me.cbCustomer, i) Then
				Me.cbCustomer.SelectedIndex = i
				Exit For
			End If
		Next i
		
	End Sub
	Public Sub populateState(ByRef sStateId As String)
		Dim i As Short
		
		For i = 0 To Me.cbState.Items.Count - 1
			If sStateId = VB6.GetItemString(Me.cbState, i) Then
				Me.cbState.SelectedIndex = i
				Exit For
			End If
		Next i
		
	End Sub
	Public Sub populateStore(ByRef sStoreId As String, ByRef sStoreNumber As String)
		
		Me.txtStore.Text = sStoreNumber
		Me.txtStore.Tag = sStoreId
		Me.txtStoreId.Text = sStoreId
		
		
	End Sub
	
	Public Sub populateVendor(ByRef nVendSeq As Short)
		Dim i As Short
		
        For i = 0 To cbVendor.Items.Count - 1
            Dim vendSeq As Integer = VB6.GetItemData(cbVendor, i)
            If VB6.GetItemData(cbVendor, i) = nVendSeq Then
                cbVendor.SelectedIndex = i
                Exit For
            End If
        Next i
		
		
	End Sub
	
	Public Sub populateAccount(ByRef sAccountNo As String)
		Dim i As Short
		
		cbAccount.Items.Clear()
		load_combo(cbAccount)
		
		For i = 0 To cbAccount.Items.Count - 1
			If Trim(VB6.GetItemString(cbAccount, i)) = Trim(sAccountNo) Then
				cbAccount.SelectedIndex = i
				Exit For
			End If
		Next i
		
	End Sub
	
	Public Sub populateInvoice(ByRef sInvoiceNo As String)
		
		Me.txtInvoice.Text = sInvoiceNo
		
	End Sub
	
	Public Sub enableHeaderFields(ByRef bFlag As Boolean)
		
		'New button
		'UPGRADE_WARNING: Lower bound of collection Toolbar1.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		Toolbar1.Items.Item(1).Enabled = bFlag
		'Search button
		'UPGRADE_WARNING: Lower bound of collection Toolbar1.Buttons has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		Toolbar1.Items.Item(3).Enabled = bFlag
		
		cbCustomer.Enabled = bFlag
		cbState.Enabled = bFlag
		txtStore.Enabled = bFlag
		cmdHelpCustomer.Enabled = bFlag
		cbVendor.Enabled = bFlag
		cbAccount.Enabled = bFlag
		txtInvoice.Enabled = bFlag
		
		
		
	End Sub

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        new_invoice()
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        save_invoice2()
    End Sub

    Private Sub btSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSearch.Click
        search_invoice()
    End Sub

    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        delete_invoice()
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub
End Class


            