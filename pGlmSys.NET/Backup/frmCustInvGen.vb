Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmCustInvGen
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
	Private period_start_date() As Date
	Public sReport_Id As String
	Public nSelectedId As Short
    Public rsStoreGroup As DataTable
	
	
	'UPGRADE_WARNING: Event cbGroupStore.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbGroupStore_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbGroupStore.SelectedIndexChanged
		If cbGroupStore.SelectedIndex = 0 Then
			cmdSelectedValues.Enabled = True
			'ckTotalByStoreGroup.Enabled = True
		Else
			cmdSelectedValues.Enabled = False
			txtLocation.Text = cbGroupStore.Text
			'ckTotalByStoreGroup.Enabled = False
		End If
	End Sub
	
	'UPGRADE_WARNING: Event cbPeriod.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbPeriod_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriod.SelectedIndexChanged
		txtInvoiceNo.Text = "NV-" & Trim(cbCustId.Text)
		txBillingPeriod.Text = ""
		If cbPeriod.Items.Count > 0 Then
			txtInvoiceNo.Text = txtInvoiceNo.Text & "-" & VB6.Format(period_start_date(cbPeriod.SelectedIndex + 1), "MM") & VB6.Format(period_start_date(cbPeriod.SelectedIndex + 1), "yy")
			txBillingPeriod.Text = VB6.Format(period_start_date(cbPeriod.SelectedIndex + 1), "MMMM yyyy")
		End If
	End Sub
	
	'Private Sub create_param_rs(nombreParametro As String, tipo As DataTypeEnum, destino As ParameterDirectionEnum, valor As Variant, raCmd As ADODB.Command, Optional tamanio As Long)
	'    Dim raPrm As ADODB.Parameter
	'
	'    If raCmd Is Nothing Then
	'        Set raCmd = New ADODB.Command
	'    End If
	'
	'    Set raPrm = raCmd.CreateParameter(nombreParametro, tipo, destino, tamanio)
	'    raCmd.Parameters.Append raPrm
	'    raPrm.Value = valor
	'End Sub
	
	
	
    Private Sub cmdBuildDoc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBuildDoc.Click

        Dim anObj As Object = cbTemplate.SelectedValue
        'if 
        '= VB6.GetItemData(cbTemplate, cbTemplate.SelectedIndex)
        'If existInvoice((cbCustId.Text), VB6.GetItemData(cbPeriod, cbPeriod.SelectedIndex), VB6.GetItemData(cbGroupStore, cbGroupStore.SelectedIndex), VB6.GetItemData(cbTemplate, cbTemplate.SelectedIndex)) Then
        If existInvoice((cbCustId.Text), VB6.GetItemData(cbPeriod, cbPeriod.SelectedIndex), VB6.GetItemData(cbGroupStore, cbGroupStore.SelectedIndex), anObj) Then
            MsgBox("Operation was cancelled, since there is another" & " invoice for the selected criteria. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
            Exit Sub
        Else

            'UPGRADE_ISSUE: Load statement is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"'
            frmCustInvGenPreview.Show()
            frmCustInvGenBrowser.Show()
            If frmCustInvGenPreview.build_document Then
                'frmCustInvGenPreview.ShowDialog()
            End If

        End If

    End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	'Populates the invoice amounts on the left using a GIR report
	'for the given combination of Customer, Period and Store Group
	Private Sub cmdDisplayAmounts_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDisplayAmounts.Click
		
		
		
		txtInvoiceTotal.Text = "0.00"
		'jp.121409.begin
		txtInvoiceTotal.Text = VB6.Format(txtInvoiceTotal.Text, "$#,###,###0.00")
		'MsgBox txtInvoiceTotal.Text
		
		'jp.121409.end
		txtSavings.Text = "0.00"
		txtSavingsPercent.Text = "0.00"
		txtStoreFlatFee.Text = "0.00"
		txtInvoiceFee.Text = "0.00"
		txtTax.Text = "0.00"
		txtGrandTotal.Text = "0.00"
		
		
		If cbGroupStore.SelectedIndex = 0 Then
			If nSelectedId = 0 Then
				MsgBox("Please select a Store Group and try again.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
				Exit Sub
			Else
				sStmt = "SELECT report_id " & " FROM rptCriteriaGlmInvoice " & " WHERE rptCriteriaGlmInvoice.cust_id = '" & Trim(cbCustId.Text) & "'" & " AND rep_no = (SELECT rep_no FROM repDef " & "               WHERE rep_caption = '" & RPT_GLM_INVOICE_REPORT & "')" & " AND use_for_customer_billing = 'TRUE' " & " AND is_period_seq = 'TRUE' " & " AND period_seq = " & VB6.GetItemData(cbPeriod, cbPeriod.SelectedIndex) & " AND group_seq = 0 " & " AND id = " & Str(nSelectedId)
				
			End If
		Else
			sStmt = "SELECT report_id " & " FROM rptCriteriaGlmInvoice " & " WHERE rptCriteriaGlmInvoice.cust_id = '" & Trim(cbCustId.Text) & "'" & " AND rep_no = (SELECT rep_no FROM repDef WHERE rep_caption = 'GLM Invoice Report')" & " AND use_for_customer_billing = 'TRUE' " & " AND is_period_seq = 'TRUE' " & " AND period_seq = " & VB6.GetItemData(cbPeriod, cbPeriod.SelectedIndex) & " AND group_seq = " & Str(VB6.GetItemData(cbGroupStore, cbGroupStore.SelectedIndex))
		End If
		
		
        rsLocal = getDataTable(sStmt) ' exec_sql(sStmt)
		
		
        If rsLocal.Rows.Count <= 0 Then
            MsgBox("No GIR report was found for selected combination: " & vbCrLf & "Customer, Period and Group ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
            Exit Sub
        End If


        sReport_Id = rsLocal.Rows(0).Item("report_id")

        '***************************************************
        ' Found data
        '***************************************************
        sStmt = "SELECT SUM (invoice_total) bill_payment," & " SUM(savings) savings," & " SUM(savings_percent) savings_percent," & " SUM(savings_flat_fee) store_flat_fee," & " SUM(savings_invoice_fee) invoice_fee" & " FROM rptGlmInvoice " & " WHERE cust_id = '" & Trim(cbCustId.Text) & "'" & " AND report_id = " & sReport_Id

        rsLocal = getDataTable(sStmt) 'exec_sql(sStmt)

        
        If rsLocal.Rows.Count <= 0 Then
            MsgBox("No GIR report was found for selected combination: " & vbCrLf & "Customer, Period and Group", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
            Exit Sub
        End If



        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        txtInvoiceTotal.Text = IIf(IsDBNull(rsLocal.Rows(0).Item("bill_payment")), "0.00", rsLocal.Rows(0).Item("bill_payment"))
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        txtSavings.Text = IIf(IsDBNull(rsLocal.Rows(0).Item("savings")), "0.00", rsLocal.Rows(0).Item("savings"))
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        txtSavingsPercent.Text = IIf(IsDBNull(rsLocal.Rows(0).Item("savings_percent")), "0.00", rsLocal.Rows(0).Item("savings_percent"))
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        txtStoreFlatFee.Text = IIf(IsDBNull(rsLocal.Rows(0).Item("store_flat_fee")), "0.00", rsLocal.Rows(0).Item("store_flat_fee"))
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        txtInvoiceFee.Text = IIf(IsDBNull(rsLocal.Rows(0).Item("invoice_fee")), "0.00", rsLocal.Rows(0).Item("invoice_fee"))
        txtTax.Text = "0.00"
        txtGrandTotal.Text = "0.00"

        'jp.20111218.begin
        'Totals by Store Group
        'Open cursor with totals per group, this is assigned in build_document
        sStmt = "SELECT DISTINCT store_group_name, group_invoice_total, group_amount_due " & " FROM rptGlmInvoice " & " WHERE cust_id = '" & Trim(cbCustId.Text) & "'" & " AND report_id = " & sReport_Id & " ORDER BY store_group_name "

        
        rsStoreGroup = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'jp.20111218.end

        compute_total()
		
	End Sub
	
	Private Sub cmdSelectedValues_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelectedValues.Click
		
		If cbCustId.SelectedIndex < 0 Then
			MsgBox("Please select a Customer before attempting this action.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			Exit Sub
		End If
		
		
		If cbPeriod.SelectedIndex < 0 Then
			MsgBox("Please select a Period before attempting this action.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			Exit Sub
		End If
		
		frmListStoreGroup.sCustId = cbCustId.Text
		frmListStoreGroup.sRepCaption = RPT_GLM_INVOICE_REPORT
		frmListStoreGroup.nPeriodSeq = VB6.GetItemData(cbPeriod, cbPeriod.SelectedIndex)
		VB6.ShowForm(frmListStoreGroup, VB6.FormShowConstants.Modal, Me)
		
		
		nSelectedId = frmListStoreGroup.nSelectedId
		If nSelectedId = 0 Then
			ckTotalByStoreGroup.Enabled = False
		Else
			ckTotalByStoreGroup.Enabled = True
		End If
		
		
		
	End Sub
	
    Private Sub dtInvoiceDate_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        txtInvoiceDate.Text = VB6.Format(dtInvoiceDate.Value, "MMMM dd, yyyy")
    End Sub
	
	Private Sub frmCustInvGen_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		load_comp()
	End Sub
	Private Sub init_vars()
		Dim NewLargeChange As Short
        rsLocal = Nothing
		
        rsStoreGroup = Nothing
		
		'Initialize return values
		Me.dtInvoiceDate.value = Today
		dtInvoiceDate_Change(dtInvoiceDate, New System.EventArgs())
		
		gbStoreSearch.bFlag = False
		gbStoreSearch.sCustId = ""
		gbStoreSearch.sCustName = ""
		gbStoreSearch.sStateId = ""
		
		txtInvoiceTotal.Text = "0.00"
		txtSavings.Text = "0.00"
		txtSavingsPercent.Text = "0.00"
		txtStoreFlatFee.Text = "0.00"
		txtInvoiceFee.Text = "0.00"
		txtTax.Text = "0.00"
		txtGrandTotal.Text = "0.00"
		
		'Flags
		ckSavingsPercent.CheckState = System.Windows.Forms.CheckState.Checked
		ckStoreFlatFee.CheckState = System.Windows.Forms.CheckState.Checked
		ckInvoiceFee.CheckState = System.Windows.Forms.CheckState.Checked
		ckTax.CheckState = System.Windows.Forms.CheckState.Checked
		ckGrandTotal.CheckState = System.Windows.Forms.CheckState.Checked
		
		ckTotalByStoreGroup.Enabled = False
		ckTotalByStoreGroup.CheckState = System.Windows.Forms.CheckState.Unchecked
		
		Me.txtGreeting.Text = MSWORD_FOOTER
		
		'Scroll bars
		VScroll1.Value = VScroll1.Minimum
		VScroll1.Maximum = (VB6.PixelsToTwipsY(Me.Frame1.Height) + VScroll1.LargeChange - 1)
		VScroll1.SmallChange = System.Math.Abs((VScroll1.Maximum - VScroll1.LargeChange + 1) \ 16) + 1
		NewLargeChange = System.Math.Abs((VScroll1.Maximum - VScroll1.LargeChange + 1) \ 4) + 1
		VScroll1.Maximum = VScroll1.Maximum + NewLargeChange - VScroll1.LargeChange
		VScroll1.LargeChange = NewLargeChange
		VScroll1.BringToFront()
		
		nSelectedId = 0
	End Sub
	Private Sub load_comp()
		Dim nCounter As Short
		nCounter = 0
		
		'Combos cbCustId, cbCustName
		sStmt = " SELECT DISTINCT suser_data.cust_id, customer.cust_name " & " FROM customer, suser_data " & " WHERE customer.cust_id = suser_data.cust_id " & " AND suser_data.suser_name='" & Trim(gsUser) & "'" & " AND (SELECT COUNT(*) FROM period WHERE period.cust_id = customer.cust_id " & "      AND period.period_status_id = 'O') > 0 " & " ORDER BY customer.cust_name "

		rsLocal = exec_sql(sStmt)
				
        If rsLocal.Rows.Count <= 0 Then
            MsgBox("Your Account does not have access to such Information." & vbCrLf & "Contact your System Administrator to get proper access.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
            Exit Sub
        End If



        'Cleaning in case there is data
        cbCustId.Items.Clear()
        cbCustName.Items.Clear()


        For row As Integer = 0 To rsLocal.Rows.Count - 1
            cbCustId.Items.Insert(nCounter, rsLocal.Rows(row).Item("cust_id"))
            cbCustName.Items.Insert(nCounter, rsLocal.Rows(row).Item("cust_name"))
            nCounter = nCounter + 1
        Next row

        cbCustName.SelectedIndex = 0

        'Template
        load_cb_word_template(cbTemplate)
        If cbTemplate.Items.Count > 0 Then
            cbTemplate.SelectedIndex = 0
        End If
		
		
	End Sub
	
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		cbCustId.SelectedIndex = cbCustName.SelectedIndex
		
		
		sStmt = "SELECT cust_name, cust_address, " & " cust_city, state_id, cust_city, " & " state_id, cust_zip, cust_contact, billing_account_no " & " FROM customer " & " WHERE customer.cust_id =  '" & Trim(cbCustId.Text) & "'"
		'" AND suser_data.suser_name='" + Trim(gsUser) + "'"
		
		rsLocal = exec_sql(sStmt)
		
        If rsLocal.Rows.Count <= 0 Then
            MsgBox("Your Account does not have access to such Information." & vbCrLf & "Contact your System Administrator to get proper access.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
            Exit Sub
        End If



        'If there is data
        txtAddress.Text = CStr(Nothing)
        txtAccountNo.Text = CStr(Nothing)

        If rsLocal.Rows.Count > 0 Then

            txtAddress.Text = txtAddress.Text & IIf(IsDBNull(rsLocal.Rows(0).Item("cust_name")), "", Trim(rsLocal.Rows(0).Item("cust_name")) & vbCrLf)

            txtAddress.Text = txtAddress.Text & IIf(IsDBNull(rsLocal.Rows(0).Item("cust_contact")), "", "Attn: " & Trim(rsLocal.Rows(0).Item("cust_contact")) & vbCrLf)


            txtAddress.Text = txtAddress.Text & IIf(IsDBNull(rsLocal.Rows(0).Item("cust_address")), "", Trim(rsLocal.Rows(0).Item("cust_address")) & vbCrLf)
            txtAddress.Text = txtAddress.Text & IIf(IsDBNull(rsLocal.Rows(0).Item("cust_city")), "", Trim(rsLocal.Rows(0).Item("cust_city")) & " ")
            txtAddress.Text = txtAddress.Text & IIf(IsDBNull(rsLocal.Rows(0).Item("state_id")), "", Trim(rsLocal.Rows(0).Item("state_id")) & " ")
            txtAddress.Text = txtAddress.Text & IIf(IsDBNull(rsLocal.Rows(0).Item("cust_zip")), "", Trim(rsLocal.Rows(0).Item("cust_zip")) & " ") & vbCrLf


            'txtAccountNo.Text = IIf(IsNull(rsLocal.item("billing_account_no")), "", Trim(rsLocal.item("billing_account_no")) & vbCrLf)
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            txtAccountNo.Text = IIf(IsDBNull(rsLocal.Rows(0).Item("billing_account_no")), "", Trim(rsLocal.Rows(0).Item("billing_account_no")))
            'customer.billing_account_no
        End If


        'jp.121409.begin
        txtDescription.Text = MSWORD_BODY_LINE1 & Trim(cbCustName.Text) & MSWORD_BODY_LINE2
        'jp.121409.end



        '********************************************
        '
        'Load period...!!!
        '
        '********************************************
        'loadPeriod
        loadPeriodAndArray((Me.cbPeriod), period_start_date, (Me.cbCustId.Text), False)
        If cbPeriod.Items.Count > 0 Then
            cbPeriod.SelectedIndex = 0
        End If




        'loadGroups
        cbGroupStore.Items.Clear()
        cbGroupStore.Items.Insert(0, UI_SELECTED_VALUES)

        load_cb_groups((Me.cbGroupStore), (cbCustId.Text), True, False)
        'load_cb_groups Me.cbGroupStore, cbCustId.Text, False
        If cbGroupStore.Items.Count > 0 Then
            cbGroupStore.SelectedIndex = 0

        End If
		
	End Sub
	Private Sub loadPeriod2()
		Dim nCounter As Object
		cbPeriod.Items.Clear()
		
		
		sStmt = "SELECT period_seq, period_name, period_start_date " & " FROM period " & " WHERE cust_id =  '" & Trim(cbCustId.Text) & "'" & " ORDER BY period.period_start_date DESC "
		
		'" AND period_status_id='O' " & _
		'
		'UPGRADE_WARNING: Lower bound of array period_start_date was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		ReDim period_start_date(1)
		
		rsLocal = exec_sql(sStmt)
		
        If rsLocal.Rows.Count <= 0 Then
            MsgBox("Your Account does not have access to such Information." & vbCrLf & "Contact your System Administrator to get proper access.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
            Exit Sub
        End If

        'En caso de haber datos
        nCounter = 0

        For row As Integer = 0 To rsLocal.Rows.Count - 1
            ReDim Preserve period_start_date(nCounter + 1)
            cbPeriod.Items.Insert(nCounter, New VB6.ListBoxItem(Trim(rsLocal.Rows(row).Item("period_name")), rsLocal.Rows(row).Item("period_seq")))
            period_start_date(nCounter + 1) = rsLocal.Rows(row).Item("period_start_date")
            nCounter = nCounter + 1
        Next row

        cbPeriod.SelectedIndex = 0
		
	End Sub
	Private Sub loadGroups2()
		'GroupStore
		sStmt = "SELECT a.group_name, a.group_seq " & " FROM groups a " & " WHERE cust_id = '" & cbCustId.Text & "'"
		
		load_cb_query2(cbGroupStore, sStmt, 2, True)
		If cbGroupStore.Items.Count > 0 Then
			cbGroupStore.SelectedIndex = 0
		End If
		
	End Sub
	
	Private Sub txtGrandTotal_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtGrandTotal.Enter
		select_text(txtGrandTotal)
	End Sub
	
	Private Sub txtGrandTotal_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtGrandTotal.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim nPos As Short
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		'36 = Dollar sign
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			
		Else
			
			nPos = InStr(1, txtGrandTotal.Text, ".", CompareMethod.Text)
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
	
	Private Sub txtInvoiceFee_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtInvoiceFee.TextChanged
		compute_total()
	End Sub
	
	Private Sub txtInvoiceFee_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtInvoiceFee.Enter
		select_text(txtInvoiceFee)
	End Sub
	
	Private Sub txtInvoiceFee_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtInvoiceFee.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim nPos As Short
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		'36 = Dollar sign
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			
		Else
			
			nPos = InStr(1, txtInvoiceFee.Text, ".", CompareMethod.Text)
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
	
	Private Sub txtInvoiceTotal_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtInvoiceTotal.TextChanged
		If IsNumeric(txtInvoiceTotal.Text) Then
			compute_total()
		Else
			MsgBox("Syntax error: Invalid Amount, please reenter.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
			txtInvoiceTotal.Focus()
		End If
	End Sub
	Private Sub compute_total()
		'jp.121409.begin
		'txtInvoiceTotal.Text = IIf(Not IsNumeric(txtInvoiceTotal.Text), "0.00", txtInvoiceTotal.Text)
		'txtSavingsPercent.Text = IIf(Not IsNumeric(txtSavingsPercent.Text), "0.00", txtSavingsPercent.Text)
		'txtStoreFlatFee.Text = IIf(Not IsNumeric(txtStoreFlatFee.Text), "0.00", txtStoreFlatFee.Text)
		'txtInvoiceFee.Text = IIf(Not IsNumeric(txtInvoiceFee.Text), "0.00", txtInvoiceFee.Text)
		'txtTax.Text = IIf(Not IsNumeric(txtTax.Text), "0.00", txtTax.Text)
		'jp.121409.end
		
		If IsNumeric(txtInvoiceTotal.Text) And IsNumeric(txtSavingsPercent.Text) And IsNumeric(txtStoreFlatFee.Text) And IsNumeric(txtInvoiceFee.Text) And IsNumeric(txtTax.Text) Then
			
			Me.txtGrandTotal.Text = CStr(CDbl(txtInvoiceTotal.Text) + CDbl(txtSavingsPercent.Text) + IIf(CDbl(txtStoreFlatFee.Text) > 0, CDbl(txtStoreFlatFee.Text), 0) + IIf(CDbl(txtInvoiceFee.Text) > 0, CDbl(txtInvoiceFee.Text), 0) + CDbl(txtTax.Text))
			
		End If
	End Sub
	
	Private Sub txtInvoiceTotal_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtInvoiceTotal.Enter
		select_text(txtInvoiceTotal)
	End Sub
	
	Private Sub txtInvoiceTotal_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtInvoiceTotal.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim nPos As Short
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		'36 = Dollar sign
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			
		Else
			
			nPos = InStr(1, txtInvoiceTotal.Text, ".", CompareMethod.Text)
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
	
	
	Private Sub txtSavings_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSavings.Enter
		select_text(txtSavings)
	End Sub
	
	Private Sub txtSavings_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSavings.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim nPos As Short
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		'36 = Dollar sign
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			
		Else
			
			nPos = InStr(1, txtSavings.Text, ".", CompareMethod.Text)
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
	
	Private Sub txtSavingsPercent_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSavingsPercent.TextChanged
		compute_total()
	End Sub
	
	Private Sub txtSavingsPercent_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSavingsPercent.Enter
		select_text(txtSavingsPercent)
	End Sub
	
	Private Sub txtSavingsPercent_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSavingsPercent.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim nPos As Short
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		'36 = Dollar sign
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			
		Else
			
			nPos = InStr(1, txtSavingsPercent.Text, ".", CompareMethod.Text)
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
	
	Private Sub txtStoreFlatFee_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtStoreFlatFee.TextChanged
		compute_total()
	End Sub
	
	Private Sub txtStoreFlatFee_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtStoreFlatFee.Enter
		select_text(txtStoreFlatFee)
	End Sub
	
	Private Sub txtStoreFlatFee_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtStoreFlatFee.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim nPos As Short
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		'36 = Dollar sign
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			
		Else
			
			nPos = InStr(1, txtStoreFlatFee.Text, ".", CompareMethod.Text)
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
	
	Private Sub txtTax_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTax.TextChanged
		'compute_total
	End Sub
	
	Private Sub select_text(ByRef oText As System.Windows.Forms.MaskedTextBox)
		oText.SelectionStart = 0
		oText.SelectionLength = Len(oText.Text)
	End Sub
	
	Private Sub txtTax_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTax.Enter
		select_text(txtTax)
	End Sub
	
	Private Sub txtTax_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtTax.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim nPos As Short
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		'36 = Dollar sign
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			
		Else
			
			nPos = InStr(1, txtTax.Text, ".", CompareMethod.Text)
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
	
	
	
	'UPGRADE_NOTE: VScroll1.Change was changed from an event to a procedure. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"'
	'UPGRADE_WARNING: VScrollBar event VScroll1.Change has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub VScroll1_Change(ByVal newScrollValue As Integer)
		
		moveFrame()
		
	End Sub
	
	Private Sub moveFrame()
		
		Me.Frame1.SetBounds(Me.Frame1.Left, VB6.TwipsToPixelsY(-VScroll1.Value), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
		
	End Sub
	
	'UPGRADE_NOTE: VScroll1.Scroll was changed from an event to a procedure. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"'
	Private Sub VScroll1_Scroll_Renamed(ByVal newScrollValue As Integer)
		
		'moveFrame
		
	End Sub
	Private Sub VScroll1_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles VScroll1.Scroll
		Select Case eventArgs.type
			Case System.Windows.Forms.ScrollEventType.ThumbTrack
				VScroll1_Scroll_Renamed(eventArgs.newValue)
			Case System.Windows.Forms.ScrollEventType.EndScroll
				VScroll1_Change(eventArgs.newValue)
		End Select
	End Sub
End Class