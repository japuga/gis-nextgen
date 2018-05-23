Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
'Imports CrystalDecisions.CrystalReports.Engine

Friend Class frmCheckBatch
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private rsVendor As DataTable
    Private rsVendorPayment As DataTable
    Private rsInvoice As DataTable
    Private rsCheckDetail As DataTable
    Private rsCheckHeader As DataTable
	Private sMsg As String
	'UPGRADE_WARNING: Lower bound of array sStore was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Private sStore(16) As String 'Lista de Tiendas
	Private bFirst As Boolean
	Private nBatchId As Short
	Private bBatch As Boolean
	'El batch calcula el numero de facturas por cheque y el numero de cheques
	'a imprimir por Vendor Payment Address
	Private Structure BatchDetailUDT
		Dim count_check As Short
		Dim count_invoice As Short
		Dim count_zero_invoice As Short
		Dim success As Boolean
	End Structure
	Private BatchDetail As BatchDetailUDT
	
	'Reporte
	Private sLocalReport As String
	Private sLocalVersion As String
	
	Private Structure rptBatchCheckSummaryParamUDT
		Dim nBatchId As String
		Dim nError As Short
	End Structure
	Private rptBatchCheckSummaryParam As rptBatchCheckSummaryParamUDT
	'--------Crystal Reports-----------------
    Private rsReport As DataTable
	
	
	
	'UPGRADE_WARNING: Event cbBankAccount.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbBankAccount_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbBankAccount.SelectedIndexChanged
		txtCheckNo.Text = CStr(get_check_no(VB6.GetItemData(cbBankAccount, cbBankAccount.SelectedIndex)))
		If txtCheckNo.Text = "0" Then
			txtCheckNo.Text = ""
		End If
	End Sub
	
	'UPGRADE_WARNING: Event cbBankName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbBankName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbBankName.SelectedIndexChanged
		load_bank_account(cbBankAccount, cbCustId.Text, VB6.GetItemData(cbBankName, cbBankName.SelectedIndex))
	End Sub
	
	'UPGRADE_WARNING: Event cbCustId.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustId_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustId.SelectedIndexChanged
		If cbCustId.SelectedIndex >= 0 Then
			load_vendor(cbCustId.Text)
		End If
		
	End Sub
	Private Sub load_vendor(ByRef sCustId As String)
		
		On Error GoTo ErrorHandler
		
		
		
        cbVendor.Items.Clear()
		sStmt = "SELECT DISTINCT VBranch.vend_name," & " VBranch.vend_id " & " FROM VAccount, VBranch " & " WHERE VAccount.vend_seq = VBranch.vend_seq " & " AND VAccount.cust_id ='" & Trim(sCustId) & "' " & " ORDER BY VBranch.vend_name "
		
        load_cb_query2(cbVendor, sStmt, 2, True)

		cbVendor.Items.Insert(0, "<All>")
		cbVendor.SelectedIndex = 0
		
		'Default to all branches
		obAllBranches.Checked = True
		
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_vendor")
		MsgBox("Unexpected error found while loading Vendor Information." & vbCrLf & "Review log file for details.", MsgBoxStyle.OKOnly, "GLM Error")
	End Sub
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		If cbCustName.SelectedIndex >= 0 Then
			cbCustId.SelectedIndex = cbCustName.SelectedIndex
			load_bank(cbBankName, cbCustId.Text)
			load_period2(cbPeriodStart, cbCustId.Text)
			load_period2(cbPeriodEnd, cbCustId.Text)
			
		End If
	End Sub
	
	'UPGRADE_WARNING: Event cbPeriodEnd.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbPeriodEnd_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriodEnd.SelectedIndexChanged
		On Error GoTo ErrorHandler
		lbPeriodEndDate.Text = ""
		
		sStmt = "SELECT period_end_date " & " FROM period " & " WHERE cust_id ='" & Trim(cbCustId.Text) & "'" & " AND period_seq =" & Str(VB6.GetItemData(cbPeriodEnd, cbPeriodEnd.SelectedIndex))
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count > 0 Then
            lbPeriodEndDate.Text = rsLocal.Rows(0).Item("period_end_date")
        End If


        Exit Sub

ErrorHandler:
        save_error(Me.Name, "cbPeriodEnd.click")
        MsgBox("An error occurred while loading  Period Info. Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
		
		
	End Sub
	
	'UPGRADE_WARNING: Event cbPeriodStart.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbPeriodStart_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriodStart.SelectedIndexChanged
		On Error GoTo ErrorHandler
		lbPeriodStartDate.Text = ""
		
		sStmt = "SELECT period_start_date " & " FROM period " & " WHERE cust_id ='" & Trim(cbCustId.Text) & "'" & " AND period_seq =" & Str(VB6.GetItemData(cbPeriodStart, cbPeriodStart.SelectedIndex))
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count > 0 Then
            lbPeriodStartDate.Text = rsLocal.Rows(0).Item("period_start_date")
        End If



        Exit Sub

ErrorHandler:
        save_error(Me.Name, "cbPeriodStart.click")
        MsgBox("An error occurred while loading  Period Info. Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
		
		
	End Sub
	
	
	
	'UPGRADE_WARNING: Event cbVendor.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbVendor_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbVendor.SelectedIndexChanged
		obAllBranches.Checked = True
		
	End Sub
	
	'UPGRADE_WARNING: Event ckPeriod.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub ckPeriod_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ckPeriod.CheckStateChanged
		cbPeriodStart.Enabled = ckPeriod.CheckState
		cbPeriodEnd.Enabled = ckPeriod.CheckState
		
	End Sub
	
	Private Sub cmdAbort_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAbort.Click
		enable_batch_options(False)
        sbBatch.Items(0).Text = "Rolling back Batch changes..."
		If rollback_batch(nBatchId) Then
			MsgBox("Batch Checks were removed and invoices were restored to original status.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
		End If
        sbBatch.Items(0).Text = ""
		
	End Sub
	
	Private Sub cmdBatch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBatch.Click
		'Dim nBatchId As Integer
		Dim nFirstCheckNo As Integer
		Dim uBatchDetail As BatchDetailUDT
		Dim bUpdateZeroInvoice As Boolean
		
		If val_fields Then
			nFirstCheckNo = CInt(txtCheckNo.Text)
			bFirst = True
			
			nBatchId = get_batch_id(cbCustId.Text)
			
			If nBatchId < 0 Then
				MsgBox("Aborting process in Batch Step.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
				Exit Sub
			Else
				MsgBox("Processing Batch:" & Str(nBatchId), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
			End If
			
			
			'UPGRADE_WARNING: Str has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			sMsg = "Starting Batch Job..." & Str(nBatchId) & " at:" & Str(Today.ToOADate)
			write_error(sMsg, sLogfile, False)
			
            sbBatch.Items(0).Text = sMsg
			
			If ckZeroedInvoice.CheckState = System.Windows.Forms.CheckState.Checked Then
				bUpdateZeroInvoice = True
			Else
				bUpdateZeroInvoice = False
			End If
			

			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			'Ejecuto Batch

			uBatchDetail = run_batch(cbCustId.Text, VB6.GetItemData(cbPeriodStart, cbPeriodStart.SelectedIndex), VB6.GetItemData(cbPeriodEnd, cbPeriodEnd.SelectedIndex), VB6.GetItemData(cbBankAccount, cbBankAccount.SelectedIndex), nBatchId, nFirstCheckNo, bUpdateZeroInvoice)

            System.Windows.Forms.Cursor.Current = Cursors.Default
			
            sbBatch.Items(0).Text = "Process Complete"
			'Muestro resumen de Batch
			If uBatchDetail.success Then
				If uBatchDetail.count_check > 0 Then
					ReportHandler2()
					enable_batch_options(True)
				Else
					MsgBox("No Invoices were found for such criteria.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
				End If
			End If
			
			'MsgBox "Process Complete.", vbInformation + vbOKOnly, "GLM Message"
			
		End If
	End Sub
	Private Function val_fields() As Boolean
		
		
		On Error GoTo ErrorHandler
		
		'Beginning CheckNo
		val_fields = False
		
		If Len(Trim(txtCheckNo.Text)) = 0 Then
			MsgBox("Please enter the Check Number to start sequence.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtCheckNo.Focus()
			Exit Function
		Else
			'Verifica que cheque no exista en Bcheck
			If check_dup2(txtCheckNo.Text, VB6.GetItemData(cbBankAccount, cbBankAccount.SelectedIndex)) Then
				MsgBox("Check No. was already printed. Try another Number.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
				Exit Function
			End If
		End If
		
		If ckPeriod.CheckState = System.Windows.Forms.CheckState.Unchecked Then
			If MsgBox("Service Period was not selected." & vbCrLf & "Do you want to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "GLM Warning") = MsgBoxResult.No Then
				Exit Function
			End If
		End If
		
		
		val_fields = True
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "val_fields")
		MsgBox("Unexpected error found while validating data.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Function
	'Genera cheques en lotes
	'1. Obtiene lista de vendedores
	'1.2. Por cada vendedor obtiene lista de direcciones de pago
	'1.2.1. Por cada direccion de pago guardar facturas en bcheck
	'2. Por cada cheque en la lista de batch: Imprimir cheque
	Private Function run_batch(ByRef sCustId As String, ByRef nPeriodSeqStart As Short, ByRef nPeriodSeqEnd As Short, ByRef nBankCustSeq As Short, ByRef nBatchId As Short, ByRef nFirstCheckNo As Integer, ByRef bUpdateZeroInvoice As Boolean) As BatchDetailUDT
		
		
		Dim uBatchDetail As BatchDetailUDT
		Dim nCountCheck As Short
		Dim nCountInvoice As Short
		Dim nCountZeroInvoice As Short
		Dim sSelect As String
		Dim sWhere As String
		Dim sOrder As String
		
		'On Error GoTo ErrorHandler
		run_batch.count_check = 0
		run_batch.count_invoice = 0
		run_batch.count_zero_invoice = 0
		run_batch.success = False
		
		sWhere = ""
		
        sSelect = "SELECT DISTINCT VBranch.vend_name," & " VBranch.vend_id " & " FROM VAccount, VBranch " & _
                    " WHERE VAccount.vend_seq = VBranch.vend_seq " & " AND VAccount.cust_id ='" & Trim(sCustId) & "' "
		
		'Usuario selecciono un vendor
		If cbVendor.SelectedIndex > 0 Then
			sWhere = sWhere & " AND VBranch.vend_id =" & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex))
		End If
		
		sOrder = " ORDER BY VBranch.vend_name "
		
		
		sStmt = sSelect & sWhere & sOrder
		
		'MsgBox sStmt
		
		'rsVendor.CursorLocation = adUseClient
        rsVendor = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsVendor.Rows.Count = 0 Then
            MsgBox("There are not vendors assigned to this customer.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Message")
            Exit Function
        Else
            'LOOP
            For row As Integer = 0 To rsVendor.Rows.Count - 1
                sbBatch.Items(0).Text = "Searching invoices for Vendor:" + rsVendor.Rows(row).Item("vend_name")

                'Vendor Payment
                uBatchDetail = get_vendor_pay_address(sCustId, rsVendor.Rows(row).Item("vend_id"), rsVendor.Rows(row).Item("vend_name"), nPeriodSeqStart, nPeriodSeqEnd, nBankCustSeq, nBatchId, nFirstCheckNo, bUpdateZeroInvoice)

                If uBatchDetail.success Then
                    nCountCheck = nCountCheck + uBatchDetail.count_check
                    nCountInvoice = nCountInvoice + uBatchDetail.count_invoice
                    If uBatchDetail.count_invoice > 0 Then
                        Dim invoiceVal As Double = uBatchDetail.count_invoice
                    End If
                    nCountZeroInvoice = nCountZeroInvoice + uBatchDetail.count_zero_invoice
                Else
                    sStmt = "Call to get_vendor_pay_address failed"
                    write_error(sStmt, sLogfile, False)
                    Exit Function
                End If

                'If uBatchDetail.count_invoice > 0 Then
                '    MsgBox rsVendor("vend_name") + ":" + Str(uBatchDetail.count_invoice)
                'End If
            Next row

            
        End If

        If uBatchDetail.count_invoice > 0 Then
            Dim invoiceVal As Double = nCountCheck
        End If
        update_batch(nBatchId, "ALL", nCountInvoice, nCountCheck, nCountZeroInvoice, 0)

        run_batch.count_check = nCountCheck
        run_batch.count_invoice = nCountInvoice
        run_batch.count_zero_invoice = nCountZeroInvoice
        run_batch.success = True

        Exit Function

ErrorHandler:
        save_error(Me.Name, "run_batch")
        MsgBox("Unexpected error found while running Batch job.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
	End Function
	'Obtiene lista de lugares de pago para un vendedor
	Private Function get_vendor_pay_address(ByRef sCustId As String, ByRef nVendId As Short, ByRef sVendName As String, ByRef nPeriodSeqStart As Short, ByRef nPeriodSeqEnd As Short, ByRef nBankCustSeq As Short, ByRef nBatchId As Short, ByRef nFirstCheckNo As Integer, ByRef bUpdateZeroInvoice As Boolean) As BatchDetailUDT
		
		
		Dim sVendSeq As String
		Dim sPeriodSeq As String
		Dim nInvoices As Short
        'Dim nTotalInvoices As Short
		Dim uBatchDetail As BatchDetailUDT
		Dim nCountInvoice As Short
		Dim nCountCheck As Short
		Dim nCountZeroInvoice As Short
		Dim sSelect As String
		Dim sWhere As String
		Dim sOrder As String
		
		
		'On Error GoTo ErrorHandler
		
		get_vendor_pay_address.count_check = 0
		get_vendor_pay_address.count_invoice = 0
		get_vendor_pay_address.count_zero_invoice = 0
		
		nInvoices = 0
		sWhere = ""
		
        sSelect = "SELECT DISTINCT RTRIM(vend_pay_address) +' '+" & " RTRIM(vend_pay_city) + ' '+ RTRIM(vend_pay_zip) AS FullAddress," & _
                    " vend_pay_address, vend_pay_city, vend_pay_zip " & " FROM VBranch" & " WHERE vend_id = " & Str(nVendId)
		
		If cbVendor.SelectedIndex > 0 Then
			If obSelectedBranches.Checked = True Then
				If Len(gVendor.sVendSeq) > 0 Then
					sWhere = " AND VBranch.vend_seq IN (" & gVendor.sVendSeq & ") "
				End If
			End If
		End If
		
		sOrder = " ORDER BY FullAddress "
		
		sStmt = sSelect & sWhere & sOrder
		
		'MsgBox sStmt
		
		
		'rsVendorPayment.CursorLocation = adUseClient
        rsVendorPayment = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsVendorPayment.Rows.Count = 0 Then
            MsgBox("Could not find branches for vendor:" & sVendName & ". Process terminated.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Message")
            Exit Function
        Else
            If gbDebug Then
                sStmt = "DEBUG: frmCheckBatch: Vendor:" & sVendName & vbCrLf & " Num Pay Locs:" & Str(rsVendorPayment.Rows.Count)
                write_error(sStmt, sLogfile, False)
            End If

            sPeriodSeq = get_period_seq(sCustId, nPeriodSeqStart, nPeriodSeqEnd)
            For row As Integer = 0 To rsVendorPayment.Rows.Count - 1
                sVendSeq = get_vend_seq(nVendId, rsVendorPayment.Rows(row).Item("vend_pay_address"), rsVendorPayment.Rows(row).Item("vend_pay_city"), rsVendorPayment.Rows(row).Item("vend_pay_zip"))


                'Process Invoices
                uBatchDetail = process_invoices(sCustId, sVendName, sVendSeq, sPeriodSeq, nBankCustSeq, nBatchId, nFirstCheckNo, bUpdateZeroInvoice)
                If Not (uBatchDetail.count_invoice = 0) Or Not (uBatchDetail.count_check = 0) Then
                    Dim s As String = ""
                End If
                If uBatchDetail.success = False Then
                    get_vendor_pay_address.success = False

                    sStmt = "Call to process_invoices failed," & vbCrLf & "PARAMETERS:" & "CustId:" & sCustId & "VendName:" & sVendName & "VendSeqString:" & sVendSeq & "PeriodSeq:" & sPeriodSeq & "BankCustSeq:" & Str(nBankCustSeq) & "BatchId:" & Str(nBatchId) & "FirstCheckNo:" & Str(nFirstCheckNo)
                    write_error(sStmt, sLogfile, False)

                    Exit Function
                End If

                If uBatchDetail.count_invoice >= 0 Then
                    nCountInvoice = nCountInvoice + uBatchDetail.count_invoice

                    If gbDebug Then
                        If uBatchDetail.count_invoice > 0 Then
                            sStmt = "Address:" + rsVendorPayment.Rows(row).Item("vend_pay_address") + "City:" + rsVendorPayment.Rows(row).Item("vend_pay_city") + "Num invoices:" + Str(uBatchDetail.count_invoice)
                            write_error(sStmt, sLogfile, False)
                        End If
                    End If
                End If

                If uBatchDetail.count_zero_invoice >= 0 Then
                    nCountZeroInvoice = nCountZeroInvoice + uBatchDetail.count_zero_invoice
                End If

                If uBatchDetail.count_check > 0 Then
                    nCountCheck = nCountCheck + uBatchDetail.count_check
                End If
            Next row


        End If


        get_vendor_pay_address.count_check = nCountCheck
        get_vendor_pay_address.count_invoice = nCountInvoice
        get_vendor_pay_address.count_zero_invoice = nCountZeroInvoice
        get_vendor_pay_address.success = True
        Exit Function

ErrorHandler:
        get_vendor_pay_address.success = False
        save_error(Me.Name, "get_vendor_pay_address")
        MsgBox("Batch fail obtaining Vendor Payment Address." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
	End Function
	'Agrupa las facturas de cada lugar de pago de un vendor
	'que estan pendientes de pagar para un periodo de pago
	'El unico quiebre es por numero de facturas pagadas en cheque,
	' que no puede exceder nMaxBatchCheckDetails
	'Retorna el numero de facturas procesadas para este vendor
	Private Function process_invoices(ByRef sCustId As String, ByRef sVendName As String, ByRef sVendSeq As String, ByRef sPeriodSeq As String, ByRef nBankCustSeq As Short, ByRef nBatchId As Short, ByRef nFirstCheckNo As Integer, ByRef bUpdateZeroInvoice As Boolean) As BatchDetailUDT
		
        Dim nCheckDetail As Short
		Dim nCountInvoice As Short
		Dim nCountCheck As Short
		Dim sFootNote1 As String
		Dim sFootNote2 As String
		Dim nCountZeroInvoice As Short
		Dim nUpdateZeroInvoice As Short
		
		'On Error GoTo ErrorHandler
		
		nCountInvoice = 0
		nCountCheck = 0
		nCountZeroInvoice = 0
		'process_invoices = -1
		process_invoices.count_check = 0
		process_invoices.count_invoice = 0
		process_invoices.count_zero_invoice = 0
		process_invoices.success = False
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtDetail1.Text) Then
			sFootNote1 = ""
		Else
			sFootNote1 = Trim(txtDetail1.Text)
		End If
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtDetail2.Text) Then
			sFootNote2 = ""
		Else
			sFootNote2 = Trim(txtDetail2.Text)
		End If
		
		
        sStmt = "SELECT Store.store_id, Store.store_number AS 'Store'," & _
        " VInvoice.account_no AS 'Account', " & _
        " VInvoice.invoice_no AS 'Invoice', " & _
        " VInvoice.total AS Total, VAccount.account_mask, " & " VInvoice.vend_seq " & _
        " FROM VInvoice, Store, VAccount " & _
        " WHERE VInvoice.store_id = Store.store_id " & _
            " AND VInvoice.cust_id =Store.cust_id " & _
            " AND VAccount.account_no = VInvoice.account_no " & _
            " AND VAccount.cust_id = VInvoice.cust_id " & _
            " AND VAccount.store_id = VInvoice.store_id " & _
            " AND VAccount.vend_seq = VInvoice.vend_seq " & _
            " AND VInvoice.vinvoice_status = 'CRE' " & _
            " AND VInvoice.cust_id ='" & Trim(sCustId) & "' " & _
            " AND VInvoice.vend_seq IN (" & sVendSeq & ") " & _
            " AND VInvoice.period_seq IN ( " & sPeriodSeq & ") "
		
		sStmt = sStmt & " ORDER BY Store.store_number, VInvoice.account_no, " & " VInvoice.invoice_no"
		
		'Determino el numero de cheques a generar basado en el numero de
		'tiendas y facturas a imprimir
		'Cada factura a pagar se guarda en rsInvoice,cuando el numero es
		'igual  nMaxBatchCheckDetails se guarda el cheque
		
		'Guardo los datos para imprimir
		'gCheck.CheckNo = txtCheckNo
		gCheck.BankCustSeq = CStr(nBankCustSeq)
		init_check_header(sCustId)
		
		
        rsInvoice = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsInvoice.Rows.Count > 0 Then
            If gbDebug Then
                sMsg = "DEBUG:" & Me.Name & " Found:" & Str(rsInvoice.Rows.Count) & " invoices for this period/vendor-address to process."
            End If

            nCheckDetail = 0
            init_check_detail()
            init_store_array()
            For row As Integer = 0 To rsInvoice.Rows.Count - 1
                'Factura con balance zero
                If rsInvoice.Rows(row).Item("total") = 0 Then

                    nCountZeroInvoice = nCountZeroInvoice + 1

                    If bUpdateZeroInvoice Then
                        nUpdateZeroInvoice = update_invoice(rsInvoice.Rows(row).Item("vend_seq"), sCustId, rsInvoice.Rows(row).Item("store_id"), rsInvoice.Rows(row).Item("invoice"), rsInvoice.Rows(row).Item("account"), "PRT", nBatchId)
                        If nUpdateZeroInvoice < 1 Then
                            process_invoices.success = False
                            MsgBox("Aborting process in process_invoices." & vbCrLf & "Failed to update invoice " + rsInvoice.Rows(row).Item("invoice") + "with zero balance.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                            Exit Function
                        End If
                    End If

                    GoTo Continue_Renamed

                End If


                nCheckDetail = nCheckDetail + 1
                nCountInvoice = nCountInvoice + 1

                add_check_detail(rsInvoice.Rows(row).Item("store_id"), rsInvoice.Rows(row).Item("store"), rsInvoice.Rows(row).Item("account"), rsInvoice.Rows(row).Item("invoice"), rsInvoice.Rows(row).Item("vend_seq"), rsInvoice.Rows(row).Item("total"))
                'Agrega tienda (sin dups) en arrelgo sStore
                add_store2(sStore, rsInvoice.Rows(row).Item("Store"))


                'Numero de facturas no debe exceder limite en cheque
                If nCheckDetail >= gGlobSettings.nMaxBatchCheckDetails Then
                    If bFirst Then
                        gCheck.CheckNo = nFirstCheckNo
                        bFirst = False
                    Else
                        gCheck.CheckNo = get_check_no(nBankCustSeq)
                    End If

                    If gCheck.CheckNo < 0 Then
                        process_invoices.success = False
                        MsgBox("Aborting process in check_no.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                        Exit Function
                    End If


                    If Not save_check2(sCustId, sStore, CStr(Today), nBatchId, sFootNote1, sFootNote2) Then
                        process_invoices.success = False
                        MsgBox("Aborting process in Insert step.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                        Exit Function
                    Else
                        nCountCheck = nCountCheck + 1
                    End If


                    nCheckDetail = 0
                    init_check_detail()
                    init_store_array()
                End If

                'Debug
                If gbDebug Then
                    write_error("DEBUG: frmCheckBatch: Invoice:" + rsInvoice.Rows(row).Item("invoice"), sLogfile, False)
                End If

Continue_Renamed:
            Next row


            'Debug
            If gbDebug Then
                sMsg = "DEBUG: " & Me.Name & " #CheckDetails:" & Str(nCheckDetail)
                write_error(sMsg, sLogfile, False)
            End If

            'Guardar las facturas restantes
            If nCheckDetail > 0 Then
                If bFirst Then
                    gCheck.CheckNo = nFirstCheckNo
                    bFirst = False
                Else
                    gCheck.CheckNo = get_check_no(nBankCustSeq)
                End If

                If gCheck.CheckNo < 0 Then
                    process_invoices.success = False
                    MsgBox("Aborting process in Check_no step.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Function
                End If


                If Not save_check2(sCustId, sStore, CStr(Today), nBatchId, sFootNote1, sFootNote2) Then
                    process_invoices.success = False
                    MsgBox("Aborting process in Insert step.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Function
                Else
                    nCountCheck = nCountCheck + 1
                End If
            End If
        End If


        process_invoices.count_check = nCountCheck
        process_invoices.count_invoice = nCountInvoice
        process_invoices.count_zero_invoice = nCountZeroInvoice
        process_invoices.success = True
        Exit Function

ErrorHandler:
        process_invoices.success = False
        save_error(Me.Name, "process_invoices")
	End Function
	'Inicializa a nulo ResultSet con detalles de cheque
	Private Sub init_check_header(ByRef sCustId As String)
		
		gCheck.custId = sCustId
		gCheck.reprint = False 'Se imprime por primera vez
		gCheck.bSameCheck = False 'Se imprime por primera vez
		gCheck.VoidCheckNo = 0
		
		
	End Sub
	Private Sub init_check_detail()
		'Monto del cheque
		gCheck.Amount = 0
		
        sStmt = "SELECT Store.store_id, Store.store_number AS 'Store'," & _
            " VInvoice.account_no AS 'Account', " & _
            " VInvoice.invoice_no AS 'Invoice', " & _
            " VInvoice.total AS Total, VAccount.account_mask, " & _
            " VInvoice.vend_seq " & _
            " FROM Store, vAccount, vInvoice " & _
            " WHERE VInvoice.store_id = Store.store_id " & _
            " AND VInvoice.cust_id =Store.cust_id " & " AND VAccount.account_no = VInvoice.account_no " & _
            " AND VAccount.cust_id = VInvoice.cust_id " & " AND VAccount.store_id = VInvoice.store_id " & _
            " AND VAccount.vend_seq = VInvoice.vend_seq " & " AND vInvoice.cust_id = '--'"
		
        gCheck.rsStore = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockBatchOptimistic)
		
		
	End Sub
	Private Sub add_check_detail(ByRef nStoreId As Short, ByRef sStoreNumber As String, ByRef sAccountNo As String, ByRef sInvoiceNo As String, ByRef nVendSeq As Short, ByRef nTotal As Double)
		

        Dim drow As DataRow = gCheck.rsStore.NewRow()


        drow.Item("store_id") = nStoreId
        drow.Item("Store") = sStoreNumber
        drow.Item("Account") = sAccountNo
        drow.Item("Invoice") = sInvoiceNo
        drow.Item("vend_seq") = nVendSeq
        drow.Item("total") = nTotal

        gCheck.rsStore.Rows.Add(drow)

        '      gCheck.rsStore.Item("store_id").Value = nStoreId
        '      gCheck.rsStore.Item("Store").Value = sStoreNumber
        '      gCheck.rsStore.Item("Account").Value = sAccountNo
        '      gCheck.rsStore.Item("Invoice").Value = sInvoiceNo
        '      gCheck.rsStore.Item("vend_seq").Value = nVendSeq
        '      gCheck.rsStore.Item("total").Value = nTotal
        'gCheck.rsStore.Update()
		
		gCheck.Amount = gCheck.Amount + nTotal
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	
	
	Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click
		enable_batch_options(False)
		'Batch saved
		MsgBox("Batch changes were saved. You can print Batch Checks later.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
		
	End Sub
	
	Private Sub cmdSavePrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSavePrint.Click
		
        sbBatch.Items(0).Text = "Printing Checks for Batch:" & Str(nBatchId)
		If find_printer(True) Then
			VB6.ShowForm(frmCheckPaper, VB6.FormShowConstants.Modal, Me)
			print_batch(nBatchId, General.gCheckPaperSource)
		End If
		
		enable_batch_options(False)
		
        sbBatch.Items(0).Text = ""
		
		MsgBox("Batch changes were saved and print jobs submitted.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
		
	End Sub
	
	Private Sub cmdShowVBranch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdShowVBranch.Click
		gVendor.nVendId = VB6.GetItemData(cbVendor, cbVendor.SelectedIndex)
		gVendor.sVendName = cbVendor.Text
		VB6.ShowForm(frmVBranchSelection, VB6.FormShowConstants.Modal, Me)
		
	End Sub
	
	Private Sub frmCheckBatch_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Me.Picture = Nothing
		init_vars()
		
	End Sub
	
	Private Sub init_vars()
		Dim fso As Scripting.FileSystemObject
		
        rsLocal = Nothing
        rsVendor = Nothing
        rsVendorPayment = Nothing
        rsInvoice = Nothing
        rsCheckDetail = Nothing
        rsCheckHeader = Nothing
        rsReport = Nothing
		fso = New Scripting.FileSystemObject
		
		'Picture1.Picture = LoadPicture("c:\glm\visual basic\glm-system\icons\logo_check3.bmp")
		sLocalVersion = "DEFAULT"
		sLocalReport = "Batch Checks Summary"
		gReport.name = sLocalReport
		
		bBatch = False
		If fso.FileExists(gGlobSettings.sCheckLogoFile) Then
			picLogo.Image = System.Drawing.Image.FromFile(gGlobSettings.sCheckLogoFile)
		Else
			MsgBox("Logo picture was not found. File:" & gGlobSettings.sCheckLogoFile, MsgBoxStyle.Critical + MsgBoxStyle.Exclamation, "GLM Warning")
		End If
		
		ckZeroedInvoice.CheckState = System.Windows.Forms.CheckState.Checked
		ckPeriod.CheckState = System.Windows.Forms.CheckState.Unchecked
		cmdShowVBranch.Enabled = False
		enable_batch_options(False)
		
        txtDetail1.MaxLength = 100
        txtDetail2.MaxLength = 100
		
		txtDetail1.Text = "PLEASE CREDIT ALL ACCOUNTS"
		
		'CustName
		sStmt = "SELECT cust_name, cust_id " & " FROM customer " & " ORDER BY cust_name"
		load_cb_query2(cbCustName, sStmt, 1, True)
		
		'CustId
		sStmt = "SELECT cust_id, cust_name " & " FROM customer " & " ORDER BY cust_name"
		load_cb_query2(cbCustId, sStmt, 1, True)
		
		If cbCustName.Items.Count > 0 Then
			cbCustName.SelectedIndex = 0
		End If
		
		
		picLogo.Visible = False
		
	End Sub
	'Runs thru the list of checks part of this BatchId,
	'generates the format and print checks (print_check_batch)
	Private Sub print_batch(ByRef nBatchId As Short, ByRef uPaperSource As General.CheckPaper)
		
		Dim sCustName As String
		Dim nCheckNo As Integer
		Dim nBankCustSeq As Short
		Dim sCheckDate As String
		Dim nCheckAmount As Double
		Dim sAmountString As String
		Dim sVendName As String
		Dim sVendPayAddress As String
		Dim sVendPayCity As String
		Dim sVendPayState As String
		Dim sVendPayZip As String
		Dim sBankAba As String
		Dim sPrevBankAba As String
		Dim sBankAccount As String
		Dim sPrevBankAccount As String
		Dim sBankCheckInfo1 As String
		Dim sBankCheckInfo2 As String
		Dim sBankCheckInfo3 As String
		Dim sBankCheckInfo4 As String
		
		sBankAba = ""
		sBankAccount = ""
		
		sPrevBankAba = "0"
		sPrevBankAccount = "0"
		
		
        sStmt = "SELECT DISTINCT BCheck.check_no, BCheck.check_date, " & " BCheck.check_amount, BCheck.bank_cust_seq , " & _
                                " Vendor.vend_name, " & " VBranch.vend_pay_address, VBranch.vend_pay_city, " & _
                                " VBranch.vend_pay_state, VBranch.vend_pay_zip," & " Customer.cust_name " & _
                      " FROM BCheck, Vendor, VBranch, Customer " & _
                      " WHERE BCheck.cust_id = Customer.cust_id " & _
                          " AND BCheck.vend_seq = VBranch.vend_seq " & _
                          " AND Vendor.vend_id = VBranch.vend_id " & _
                          " AND BCheck.batch_id=" & Str(nBatchId)
		
        rsCheckHeader = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsCheckHeader.Rows.Count = 0 Then
            MsgBox("No Checks were found for this Batch Id:" & Str(nBatchId), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
            Exit Sub
        Else

            For row As Integer = 0 To rsCheckHeader.Rows.Count - 1
                If sPrevBankAccount <> sBankAccount Then
                    sPrevBankAccount = sBankAccount
                    sBankAccount = get_bank_account(rsCheckHeader.Rows(row).Item("bank_cust_seq"))
                    If sBankAccount = "" Then
                        MsgBox("Failed to retrieve Bank Account number, batch id=" & Str(nBatchId), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                        Exit Sub
                    End If
                End If

                If sPrevBankAba <> sBankAba Then
                    sPrevBankAba = sBankAba
                    sBankAba = get_bank_aba(rsCheckHeader.Rows(row).Item("bank_cust_seq"))
                    If sBankAba = "" Then
                        MsgBox("Failed to retrieve Bank ABA number, batch id=" & Str(nBatchId), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                        Exit Sub
                    End If
                End If

                If Not IsDBNull(rsCheckHeader.Rows(row).Item("check_no")) Then
                    nCheckNo = rsCheckHeader.Rows(row).Item("check_no")
                Else
                    MsgBox("Failed to retrieve Check Number, batch id=" & Str(nBatchId), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                    Exit Sub
                End If

                If Not IsDBNull(rsCheckHeader.Rows(row).Item("check_date")) Then
                    sCheckDate = rsCheckHeader.Rows(row).Item("check_date")
                Else
                    MsgBox("Failed to retrieve Check Date, batch id=" & Str(nBatchId), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                    Exit Sub
                End If

                sbBatch.Items(0).Text = "Printing Check# " & Str(nCheckNo)

                'sLinea = list_store2(rsCheckHeader("cust_name"), sStore, 3, 30)
                sCustName = rsCheckHeader.Rows(row).Item("cust_name")
                nCheckAmount = rsCheckHeader.Rows(row).Item("check_amount")
                nBankCustSeq = rsCheckHeader.Rows(row).Item("bank_cust_seq")
                sVendName = rsCheckHeader.Rows(row).Item("vend_name")
                sVendPayAddress = rsCheckHeader.Rows(row).Item("vend_pay_address")
                sVendPayCity = rsCheckHeader.Rows(row).Item("vend_pay_city")
                sVendPayState = rsCheckHeader.Rows(row).Item("vend_pay_state")
                sVendPayZip = rsCheckHeader.Rows(row).Item("vend_pay_zip")
                sAmountString = num2str(nCheckAmount)

                sBankCheckInfo1 = get_bank_info(rsCheckHeader.Rows(row).Item("bank_cust_seq"), "check_info1")
                sBankCheckInfo2 = get_bank_info(rsCheckHeader.Rows(row).Item("bank_cust_seq"), "check_info2")
                sBankCheckInfo3 = get_bank_info(rsCheckHeader.Rows(row).Item("bank_cust_seq"), "check_info3")
                sBankCheckInfo4 = get_bank_info(rsCheckHeader.Rows(row).Item("bank_cust_seq"), "check_info4")


                'Carga gCheck.rsStore
                If get_check_detail(nCheckNo, nBankCustSeq) = False Then
                    Exit Sub
                End If

                load_store_array(nCheckNo, nBankCustSeq)

                Select Case uPaperSource
                    Case General.CheckPaper.Blank

                        print_check_batch3(sCustName, nCheckNo, sCheckDate, sVendName, nCheckAmount, sAmountString, sVendPayAddress, sVendPayCity, sVendPayState, sVendPayZip, txtDetail1.Text, txtDetail2.Text, sBankAba, sBankAccount, sStore, sBankCheckInfo1, sBankCheckInfo2, sBankCheckInfo3, sBankCheckInfo4)

                    Case General.CheckPaper.Imprinted
                        'print_check4 sCustName, nCheckNo, sCheckDate, _
                        'sVendName, nCheckAmount, _
                        'sAmountString, sVendPayAddress, _
                        'sVendPayCity, sVendPayState, _
                        'sVendPayZip, txtDetail1, txtDetail2, _
                        'sBankAba, sBankAccount, sStore
                        print_check5(sCustName, nCheckNo, sCheckDate, sVendName, nCheckAmount, sAmountString, sVendPayAddress, sVendPayCity, sVendPayState, sVendPayZip, txtDetail1.Text, txtDetail2.Text, sBankAba, sBankAccount, sStore)

                End Select
            Next row

           
        End If

		
		
		
	End Sub
	'DEPRECATED this is done in BankFunctions.print_check_batch2
	'Imprime cheque del Batch
	Private Sub print_check_batch(ByRef sCustName As String, ByRef nCheckNo As Integer, ByRef sCheckDate As String, ByRef sVendName As String, ByRef nCheckAmount As Double, ByRef sAmountString As String, ByRef sVendPayAddress As String, ByRef sVendPayCity As String, ByRef sVendPayState As String, ByRef sVendPayZip As String, ByRef sDetail1 As String, ByRef sDetail2 As String, ByRef sBankAba As String, ByRef sBankAccount As String)
		
        'Dim i As Short
        'Dim nRate As Double
        'Dim sAmount As Object
        'Dim nLines As Short
        'Dim nCounter As Short
        Dim sCheckNo As String 'Check formateado
        'Dim sMicrocode As String
		'UPGRADE_WARNING: Lower bound of array sLinea was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		Dim sLinea(3) As String
		
		'On Error GoTo ErrorHandler
		'print_check = True
		
		sCheckNo = format_check_number(nCheckNo)
		'Cabecera Banco
		'UPGRADE_ISSUE: Constant vbPRPSLetter was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'UPGRADE_ISSUE: Printer property Printer.PaperSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.PaperSize = vbPRPSLetter
        ''UPGRADE_ISSUE: Printer property Printer.FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontName = "Times New Roman"
        ''UPGRADE_ISSUE: Printer property Printer.FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontSize = 7
        ''UPGRADE_ISSUE: Printer property Printer.FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontBold = False

        ''Imagen
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.85 * 1440 '0.95
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 0.24 * 1440 '0.44
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_ISSUE: Printer method Printer.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.PaintPicture(picLogo.Image, Printer.CurrentX, Printer.CurrentY)

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 4.15 * 1440 '3.95
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 0.24 * 1440 '0.14
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("JPMORGAN CHASE BANK, N.A.")

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 4.45 * 1440 '4.25
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 0.34 * 1440 '0.24
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("P.O. BOX 2558")

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 4.15 * 1440 '3.95
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 0.44 * 1440 '0.34
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("HOUSTON, TEXAS 77252")

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 4.45 * 1440 '4.25
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 0.64 * 1440 '0.54
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("32-115/1110")

        ''Cabecera GLM
        ''UPGRADE_ISSUE: Printer property Printer.FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontName = "Times New Roman"
        ''UPGRADE_ISSUE: Printer property Printer.FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontSize = 10

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 1.95 * 1440 '3.75
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 0.34 * 1440 '0.24
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("GLM DFW, INC.")

        ''UPGRADE_ISSUE: Printer property Printer.FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontName = "Times New Roman"
        ''UPGRADE_ISSUE: Printer property Printer.FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontSize = 7

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 1.55 * 1440 '1.95
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 0.5 * 1440 '0.54
        ''Printer.Print "7225 SAGE MEADOW PH. 972-702-6451"
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("3113 BROKEN BOW WAY PH. 972-702-6451")

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 1.95 * 1440 '3.75
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 0.6 * 1440 '0.64
        ''Printer.Print "PLANO, TEXAS 75024"
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("PLANO, TEXAS 75093")

        ''Valores de impresion
        ''Printer.PaperSize = vbPRPSLetter
        ''UPGRADE_ISSUE: Printer property Printer.FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontName = "Times New Roman"
        ''UPGRADE_ISSUE: Printer property Printer.FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontSize = 12


        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6.82 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 0.21 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sCheckNo)


        ''Fecha
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6.21 * 1440 '6.15
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 0.56 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("DATE ")

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6.82 * 1440 '6.82
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 0.56 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontUnderline = True
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sCheckDate)
        ''UPGRADE_ISSUE: Printer property Printer.FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontUnderline = False


        ''Vendor
        ''UPGRADE_ISSUE: Printer property Printer.FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontName = "Times New Roman"
        ''UPGRADE_ISSUE: Printer property Printer.FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontSize = 10

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.22 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 1.02 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Pay To The")

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.22 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 1.21 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Order Of")



        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 1 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 1.1 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(" ____________________________________________________________________________ $ _______________")

        ''UPGRADE_ISSUE: Printer property Printer.FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontName = "Times New Roman"
        ''UPGRADE_ISSUE: Printer property Printer.FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontSize = 12

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 1 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 1.06 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sVendName)

        ''Cantidad
        ''UPGRADE_WARNING: Couldn't resolve default property of object sAmount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sAmount = FormatCurrency(nCheckAmount)
        ''UPGRADE_WARNING: Couldn't resolve default property of object sAmount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sAmount = "**" & VB.Right(sAmount, Len(sAmount) - 1)

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6.8 * 1440
        ''UPGRADE_WARNING: Couldn't resolve default property of object sAmount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sAmount)

        ''Amount String
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.22 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 1.49 * 1440 '1.58
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("______________________________________________________________________________DOLLARS")

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.22 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 1.41 * 1440 '1.51
        'sAmountString = Trim(sAmountString) & "****************************"
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sAmountString)


        ''Vendor Address
        ''Printer.FontSize = 11
        ''UPGRADE_ISSUE: Printer property Printer.FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontSize = 10
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.7 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 1.9 * 1440 '1.75
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(UCase(sVendName))
        ''rel1.4---Printer.CurrentY = 1.9 * 1440 ' 1.8
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.7 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.05 * 1440 ' 1.9
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(UCase(sVendPayAddress))


        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.7 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.2 * 1440 '2.05
        ''rel1.4---
        'sVendPayCity = Trim(sVendPayCity) & " - " & sVendPayState & " -" & sVendPayZip
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(UCase(sVendPayCity))

        ''Printer.CurrentX = 0.7 * 1440
        ''Printer.CurrentY = 2.2 * 1440  '2.1
        ''Printer.Print sVendZip

        ''Store list
        ''list_store 3, 30
        'list_store2(sLinea, sCustName, sStore, 3, 30)
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.22 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.5 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("MEMO:" & sLinea(1))

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.7 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.65 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(2))

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.7 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.8 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(3))

        ''Firma

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 4.95 * 1440 '5.75
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.31 * 1440 '2.41
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("________________________________________")

        ''UPGRADE_ISSUE: Printer property Printer.FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontName = "Times New Roman"
        ''UPGRADE_ISSUE: Printer property Printer.FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontSize = 6

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 5.85 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.49 * 1440 '2.59
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("AUTHORIZED SIGNATURE")


        ''Microcode
        ''UPGRADE_ISSUE: Printer property Printer.FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontName = "MRV MICR"
        ''UPGRADE_ISSUE: Printer property Printer.FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontSize = 12

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 1.45 * 1440 '1.95
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.94 * 1440 '2.95, 2.99, 3.08

        'sMicrocode = "C" & Trim(sCheckNo) & "C A" & Trim(sBankAba) & "A C" & Trim(sBankAccount) & "C"
        ''sMicrocode = "A111993776A 4882133021C 0867"
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sMicrocode)
        ''Printer.Print "C005290C A111001150A C12607078264C"


        ''Check Detail
        ''DETALLE
        ''UPGRADE_ISSUE: Printer property Printer.FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontName = "Courier New" '01.09.04
        ''UPGRADE_ISSUE: Printer property Printer.FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontSize = 9 '*************
        ''UPGRADE_ISSUE: Printer property Printer.FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontBold = True

        ''03.03.05
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 3.54 * 1440 '3.57
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("GLM DFW, INC.")

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 3.67 * 1440
        'nLines = parse_string(sVendName, 18)
        'If nLines > 0 Then
        '	'Printer.Print gParse(1);
        'Else
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(sVendName)
        'End If

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 7 * 1440 '7
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sCheckDate)

        ''CheckNo
        ''03.03.05
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 7 * 1440 '7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 3.83 * 1440 '3.77
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sCheckNo)

        ''UPGRADE_ISSUE: Printer property Printer.FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontUnderline = True

        ''TITULOS
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 3.67 * 1440 '3.87
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 2 * 1440 '3
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Store")
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440 '4
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Account")
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 4.5 * 1440 '5
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Invoice")
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6 * 1440 '6
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Amount")

        ''Printer.FontBold = False
        ''UPGRADE_ISSUE: Printer property Printer.FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontUnderline = False

        ''DATOS
        'nRate = 0.13 '0.15
        'i = 1
        ''namount = 1012.23
        'gCheck.rsStore.MoveFirst()
        'nCounter = 0
        'Do While Not gCheck.rsStore.EOF
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentY = (3.72 + (nRate * i)) * 1440 '3.92
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 2 * 1440 '3
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(gCheck.rsStore.item("Store"))
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 3 * 1440 '4
        '	'05.15.03 Mascara de cuenta
        '	'Printer.Print gCheck.rsStore("Account");
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(gCheck.rsStore.item("account_mask"))
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 4.5 * 1440 '5
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(gCheck.rsStore.item("Invoice"))
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 5.7 * 1440 '6
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(format_qty(FormatCurrency(gCheck.rsStore.item("Total"), 2, TriState.True)))
        '	gCheck.rsStore.MoveNext()
        '	i = i + 1
        'Loop 

        ''Nombre de vendedor multilinea
        'i = 1
        'For nCounter = 1 To nLines
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentY = (3.72 + (nRate * i)) * 1440 '3.92
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 0.1 * 1440
        '	'Printer.FontBold = True
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(gParse(nCounter))
        '	'Printer.FontBold = False
        '	i = i + 1
        'Next nCounter

        ''Listado de Tiendas
        ''list_store2 sCustName, 2, 60
        'list_store2(sLinea, sCustName, sStore, 2, 60)
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 6.2 * 1440 '6.52
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(1))
        ''---
        ''Total del cheque
        ''Printer.FontBold = True
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(FormatCurrency(nCheckAmount, 2, TriState.True))
        ''Printer.FontBold = False
        ''Segunda linea de tiendas
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 6.35 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(2))

        ''05.15.03
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 6.35 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sDetail1)

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 6.55 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sDetail2)


        ''COPIA *************************************

        ''UPGRADE_ISSUE: Printer property Printer.FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontBold = True

        ''03.03.05
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 7.07 * 1440 '7.16
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("GLM DFW, INC.")

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 7.2 * 1440
        'nLines = parse_string(sVendName, 18)
        'If nLines > 0 Then
        '	'Printer.Print gParse(1);
        'Else
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(sVendName)
        'End If
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 7 * 1440 '6
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sCheckDate)

        ''CheckNo
        ''03.03.05
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 7 * 1440 '7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 7.36 * 1440 '3.77
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sCheckNo)


        ''UPGRADE_ISSUE: Printer property Printer.FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontUnderline = True

        ''TITULOS
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 7.15 * 1440 '7.35
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 2 * 1440 '3
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Store")
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440 '4
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Account")
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 4.5 * 1440 '5
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Invoice")
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6 * 1440 '3.7
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Amount")

        ''Printer.FontBold = False
        ''UPGRADE_ISSUE: Printer property Printer.FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontUnderline = False


        'i = 1
        'gCheck.rsStore.MoveFirst()
        'Do While Not gCheck.rsStore.EOF
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentY = (7.2 + (nRate * i)) * 1440 '7.4
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 2 * 1440 '3
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(gCheck.rsStore.item("Store"))
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 3 * 1440 '4
        '	'05.15.03 Mascara de Cuenta
        '	'Printer.Print gCheck.rsStore("Account");
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(gCheck.rsStore.item("account_mask"))
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 4.5 * 1440 '5
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(gCheck.rsStore.item("Invoice"))
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 5.7 * 1440 '6
        '	'Printer.Print FormatCurrency(gCheck.rsStore("Total"), 2, vbTrue)
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(format_qty(FormatCurrency(gCheck.rsStore.item("Total"), 2, TriState.True)))
        '	gCheck.rsStore.MoveNext()
        '	i = i + 1
        'Loop 

        ''Nombre de vendedor multilinea
        'i = 1
        'For nCounter = 1 To nLines
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentY = (7.2 + (nRate * i)) * 1440 '7.4
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 0.1 * 1440
        '	'Printer.FontBold = True
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(gParse(nCounter))
        '	'Printer.FontBold = False
        '	i = i + 1
        'Next nCounter

        ''Stores
        ''list_store 2, 60
        'list_store2(sLinea, sCustName, sStore, 2, 60)
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 9.68 * 1440 '9.68
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(1))

        ''Printer.FontBold = True
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(FormatCurrency(nCheckAmount, 2, TriState.True))
        ''Printer.FontBold = False

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 9.83 * 1440 '9.83
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(2))
        ''05.15.03
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 9.98 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sDetail1)

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 10.18 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sDetail2)
		
		'UPGRADE_ISSUE: Printer method Printer.EndDoc was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.EndDoc()
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "print_check_batch")
		MsgBox("An unexpected error has ocurred while generating check." & vbCrLf & "Please review log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.Exclamation, "GLM Error")
	End Sub
	
	
	Private Function get_check_detail(ByRef nCheckNo As Integer, ByRef nBankCustSeq As Short) As Boolean
		
		On Error GoTo ErrorHandler
		
		get_check_detail = False
		
		sStmt = get_check_query(nCheckNo, nBankCustSeq)
		
        gCheck.rsStore = getDataTable(sStmt) '.Open(sStmt, cn)

        If gCheck.rsStore.Rows.Count > 0 Then
            'ok
            get_check_detail = True
        Else
            MsgBox("Could not retrieve check details from database. " & "Check#:" & Str(nCheckNo), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Function
        End If

        Exit Function

ErrorHandler:
        save_error(Me.Name, "get_check_detail")
        MsgBox("Unexpected error was found.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
	End Function
	
	'Load sStore array with store numbers referred in this Check
	Private Sub load_store_array(ByRef nCheckNo As Integer, ByRef nBankCustSeq As Short)
		
		Dim i As Short
		init_store_array()
		
		sStmt = "SELECT DISTINCT store.store_number " & " FROM BCheck, Store " & " WHERE BCheck.cust_id = Store.cust_id " & " AND BCheck.store_id = Store.store_id " & " AND BCheck.check_no = " & Str(nCheckNo) & " AND BCheck.bank_cust_seq = " & Str(nBankCustSeq)
		
		
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.Rows.Count > 0 Then
            i = 0
            For row As Integer = 0 To rs.Rows.Count - 1
                sStore(i) = rs.Rows(row).Item("store_number")
                i = i + 1

            Next row
            
        End If
	End Sub
	
	Public Sub init_store_array()
		Dim i As Short
		
        For i = 0 To gGlobSettings.nMaxBatchCheckDetails - 1
            sStore(i) = ""
        Next i
	End Sub
	
    Private Function ReportHandler2() As Boolean
        ReportHandler2 = False
        'Seleccionar impresora
        If find_printer(False) Then
            'Version para soporte a Crystal Reports
            show_report2()
        End If

    End Function
	
	'Permite seleccionar una impresora para imprimir
	Private Function find_printer(ByRef bSelectPrinter As Boolean) As Boolean
		'No existen impresora definidas en esta maquina
		find_printer = True
		'UPGRADE_ISSUE: Printers method Printers.Count was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count <= 0 Then
            MsgBox("There are not printers defined in this computer." & vbCrLf & "Please set up a default printer before proceeding.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message")

            find_printer = False
            Exit Function
        End If
		
		If bSelectPrinter Then
            'VB6.ShowForm(frmPrinter, VB6.FormShowConstants.Modal, Me)
            find_printer = True
            'If gbPrinter Then
            '	find_printer = True
            'Else
            '	find_printer = False
            'End If
		End If
	End Function
	'Rel1.3.2 Extension de show_report para manejar reportes
	'en Crystal Reports.
	'1.-Obtiene la semilla para el reporte (get_seed)
	'2.-Ejecuta el store procedure para cargar RepData
	'3.-Verifica que se haya ejecutado, que hayan datos en RepData
	'4.-Mapea campos de RepData con los definidos en RepCust
	'5.-Muestra el reporte
	Private Sub show_report2()

		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
        cmReport = cn.CreateCommand '.let_ActiveConnection(cn)
        cmReport.CommandType = CommandType.StoredProcedure

		
		'Obengo el identificador del reporte
		nReport = 0
		nReport = get_seed("repdata")
		If nReport <= 0 Then
			MsgBox("Unable to get Report Number." & vbCrLf & "Report has not been generated.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Sub
		End If
		
		cmReport.CommandText = "usp_rep_check_batch_summary"
		
        SqlCommandBuilder.DeriveParameters(cmReport)
		cmReport.Parameters("@nReportId").Value = nReport
        cmReport.Parameters("@nBatchId").Value = nBatchId
        cmReport.Parameters("@nError").Direction = ParameterDirection.Output
		
		'Ejecuto el procedure y verifico por errores
        cmReport.ExecuteNonQuery()
		
		rptBatchCheckSummaryParam.nError = cmReport.Parameters("@nError").Value
		If rptBatchCheckSummaryParam.nError <> 0 Then
			MsgBox("An error ocurred while generating report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Sub
		End If
		
		'Verifico que se hayan cargado datos en RepBatchCheckSummary para este reporte
		sStmt = "SELECT count(*) FROM rptBatchCheckSummary WHERE report_id = " & Str(nReport)
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsLocal.Rows.Count > 0 Then
            If rsLocal.Rows(0).Item(0) > 0 Then
                'Encontro registros
            Else
                MsgBox("No data was generated for :" & sLocalReport & " report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If
        Else
            MsgBox("There was an error while verifying report data for:" & sLocalReport, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
		
		
        sStmt = "SELECT report_id, batch_id, batch_date, cust_id, " & " LTRIM(RTRIM(cust_name))AS cust_name, " & _
                "vend_name, count_check, count_vendor, total_check_amount, " & _
                "check_no, check_amount, num_invoices, num_zero_invoices, num_process_invoices " & _
                " FROM rptBatchCheckSummary " & " WHERE report_id = " & Str(nReport)
		
        rsReport = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		'Cargo la plantilla de Crystal Reports con los datos
		load_report()
		Exit Sub
		
ErrorHandler: 
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		save_error(Me.Name, "show_report2")
        'For	Each e In cn.Errors
        '	MsgBox(e.Description)
        'Next e
	End Sub
	
	Private Function load_report() As Boolean

		Dim sFile As String 'Path de la plantilla del reporte
        'Dim sReportTemplate As String 'Nombre de plantilla de reporte
		Dim fileTmp As Scripting.FileSystemObject
		fileTmp = New Scripting.FileSystemObject
		
		'On Error GoTo ErrorHandler
		
		'Abro el archivo con el reporte

		'sFile = "c:\glm\Visual Basic\Glm-System\Reports\rptGlmInvoice.rpt"
		sFile = get_template(sLocalReport, sLocalVersion)
        If fileTmp.FileExists(sFile) Then
            Try
                Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                rptDoc.Load(sFile)
                rptDoc.SetDataSource(rsReport)

                frmCheckBatchRepViewer.CrystalReportViewer1.ReportSource = rptDoc
                frmCheckBatchRepViewer.CrystalReportViewer1.Visible = True
                frmCheckBatchRepViewer.CrystalReportViewer1.Show()
                frmCheckBatchRepViewer.Show()
            Catch ex As Exception
            End Try
        Else

            MsgBox("Report template not found." & vbCrLf & "Please install: " & sFile, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
            Exit Function
        End If

        'Asignar impresora seleccionada por usuario.
        'report.SelectPrinter "HP DeskJet 550C","remota", "LPT1"

        'crysRep.SelectPrinter(Printer.DriverName, Printer.DeviceName, Printer.Port)

        'reportTable.SetPrivateData 3, AdoRs
        'reportTable.SetPrivateData(3, rsReport)

        'cd.CancelError = True
        'cd.ShowPrinter

        'crysRep.ProgressDialogEnabled = True
        'crysRep.Preview()

        'ErrorHandler:
        'If Err.Number = cdlCancel Then
        '    MsgBox "usuario aborto"
        'End If
	End Function
	
	
	Private Sub enable_batch_options(ByRef bOption As Boolean)
		
		cmdSave.Enabled = bOption
		cmdSavePrint.Enabled = bOption
		cmdAbort.Enabled = bOption
		
		cmdBatch.Enabled = Not bOption
		cmdClose.Enabled = Not bOption
		frBatch.Enabled = Not bOption
		
		bBatch = bOption
		
	End Sub
	
	'Elimina registros de BCheck y Actualiza facturas a estado CRE
	'1.- Elimina de BCheck
	'2.- Actualiza VInvoice
	Private Function rollback_batch(ByRef nBatchId As Short) As Boolean
		Dim nRecords As Short
        Dim nTran As SqlTransaction
		Dim nNumInvoices As Short
		Dim nNumZeroInvoices As Short
		Dim sMsg As String
		
		nNumInvoices = -1
		nNumZeroInvoices = -1
		rollback_batch = False
		
		On Error GoTo ErrorHandler
		
		'Cuento numero de facturas en batch
		sStmt = "SELECT COUNT(*) FROM BCheck WHERE batch_id =" & Str(nBatchId)
		
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.Rows.Count > 0 Then
            If Not IsDBNull(rs.Rows(0).Item(0)) Then
                nNumInvoices = rs.Rows(0).Item(0)
            End If
        End If
		
		'1. Actualizar Facturas
        sStmt = "UPDATE vInvoice  " & " SET vInvoice.vinvoice_status='CRE' " & " WHERE EXISTS " & _
            "   (SELECT * FROM BCheck " & _
                "    WHERE BCheck.invoice_no = vInvoice.invoice_no " & _
                "    AND BCheck.cust_id = vInvoice.cust_id " & _
                "    AND BCheck.store_id = vInvoice.store_id " & _
                "    AND BCheck.vend_seq = vInvoice.vend_seq " & _
                "    AND BCheck.account_no = vInvoice.account_no " & _
                "    AND BCheck.batch_id = " & Str(nBatchId) & ")"
		
		
		
		
        nTran = cn.BeginTransaction()
        cm = cn.CreateCommand '.let_ActiveConnection(cn)
        cm.CommandType = CommandType.Text
        cm.CommandText = sStmt
        cm.Transaction = nTran
        nRecords = cm.ExecuteNonQuery()
		If nRecords > 0 Then
			'ok
			'Incorrect number of invoices updated.
			If nRecords <> nNumInvoices Then
                nTran.Rollback()
				sMsg = "Found a discrepancy between number of invoices in batch " & vbCrLf & "and number of invoices rolled back." & vbCrLf & "Unable to remove Batch:" & Str(nBatchId) & " you must verify invoices " & "and checks before removing it manually."
				write_msg("frmCheckBatch:rollback_batch", sMsg)
				
				MsgBox(sMsg, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
				Exit Function
			End If
			
			'Borrar Cheques
			sStmt = "DELETE FROM Bcheck " & " WHERE batch_id = " & Str(nBatchId)
			
			cm.CommandText = sStmt
            nRecords = cm.ExecuteNonQuery()
			
			If nRecords > 0 Then
                nTran.Commit()
				rollback_batch = True
			Else
                nTran.Rollback()
				
				MsgBox("Failed to remove Checks for Batch:" & Str(nBatchId) & vbCrLf & "You must have to remove them manually", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
			End If
		Else
            nTran.Rollback()
			MsgBox("Failed to remove Checks for Batch:" & Str(nBatchId) & vbCrLf & "You must have to remove them manually", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		End If
		
		'2. Actualizar STATUS de facturas cuyo balance fue zero
		'Cuento numero de facturas en VInvoice
		sStmt = "SELECT COUNT(*) FROM VInvoice WHERE batch_id =" & Str(nBatchId)
		
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(rs.Rows(0).Item(0)) Then
            'Nada que actualizar
            rollback_batch = True
            Exit Function
        Else
            nNumZeroInvoices = rs.Rows(0).Item(0)

        End If


        sStmt = "UPDATE vInvoice  " & " SET vInvoice.vinvoice_status='CRE' " & " WHERE batch_id = " & Str(nBatchId)

        cm.CommandText = sStmt
        nRecords = cm.ExecuteNonQuery()
        If nRecords > 0 Then
            If nNumZeroInvoices <> nRecords Then
                sMsg = "Found a discrepancy between number of ZERO invoices in batch " & vbCrLf & "and number of invoices rolled back." & vbCrLf & "Unable to remove Batch:" & Str(nBatchId) & " you must verify invoices " & "before removing it manually."
                write_msg("frmCheckBatch:rollback_batch", sMsg)

                MsgBox(sMsg, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                Exit Function
            End If
        End If
        Exit Function

ErrorHandler:
        rollback_batch = False
        'If nTran > 0 Then
        '    cn.RollbackTrans()
        'End If
        save_error(Me.Name, "rollback_batch")
        MsgBox("Unexpected error found while removing Checks." & vbCrLf & "Review log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
		
	End Function
	
    Private Sub frmCheckBatch_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If bBatch Then
            MsgBox("You must select complete or abort this Batch.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Message")
            eventArgs.Cancel = True
        End If
        'If rollback_batch(nBatchId) Then
        '    MsgBox "Batch Checks were removed and invoices were restored to original status.", _
        ''        vbInformation + vbOKOnly, "GLM Message"
        'End If

    End Sub
	'Prints using Imprinted-check paper
	Private Sub print_check4(ByRef sCustName As String, ByRef nCheckNo As Integer, ByRef sCheckDate As String, ByRef sVendName As String, ByRef nCheckAmount As Double, ByRef sAmountString As String, ByRef sVendPayAddress As String, ByRef sVendPayCity As String, ByRef sVendPayState As String, ByRef sVendPayZip As String, ByRef sDetail1 As String, ByRef sDetail2 As String, ByRef sBankAba As String, ByRef sBankAccount As String, ByRef sStoreArray As Object)
		
		Dim i As Short
		Dim nRate As Double
		Dim sAmount As Object
		Dim nLines As Short
		Dim nCounter As Short
		
		Dim sLinea(3) As String
		
		On Error GoTo ErrorHandler
		
		
		'Valores de impresion
		'UPGRADE_ISSUE: Constant vbPRPSLetter was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'UPGRADE_ISSUE: Printer property Printer.PaperSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.PaperSize = vbPRPSLetter
        ''UPGRADE_ISSUE: Printer property Printer.FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontName = "Times New Roman"
        ''UPGRADE_ISSUE: Printer property Printer.FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontSize = 12

        ''Fecha
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6.82 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 0.56 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sCheckDate)

        ''Vendor
        ''UPGRADE_WARNING: Couldn't resolve default property of object sAmount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sAmount = FormatCurrency(nCheckAmount)
        ''UPGRADE_WARNING: Couldn't resolve default property of object sAmount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sAmount = "**" & VB.Right(sAmount, Len(sAmount) - 1)
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 1 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 1.06 * 1440
        ''Printer.Print txtVendor;
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sVendName)
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6.8 * 1440
        ''UPGRADE_WARNING: Couldn't resolve default property of object sAmount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sAmount)

        ''Amount String
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.22 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 1.41 * 1440 '1.51
        ''txtAmountString = Trim(txtAmountString) + "****************************"
        'sAmountString = Trim(sAmountString) & "****************************"
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sAmountString)

        ''Vendor Address
        ''UPGRADE_ISSUE: Printer property Printer.FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontSize = 10
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.7 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 1.9 * 1440 '1.75
        ''Printer.Print UCase(txtVendor)
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(UCase(sVendName))
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.7 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.05 * 1440 ' 1.9
        ''Printer.Print UCase(sVendAddress)
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(UCase(sVendPayAddress))


        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.7 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.2 * 1440 '2.05
        ''sVendCity = Trim(sVendCity) + " - " + sVendZip
        ''Printer.Print UCase(sVendCity)
        'sVendPayCity = Trim(sVendPayCity) & " - " & sVendPayState & " - " & sVendPayZip
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(UCase(sVendPayCity))

        ''Printer.CurrentX = 0.7 * 1440
        ''Printer.CurrentY = 2.2 * 1440  '2.1
        ''Printer.Print sVendZip

        ''Store list
        ''list_store 3, 30
        'list_store2(sLinea, sCustName, sStoreArray, 3, 30)
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.7 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.5 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(1))

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.7 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.65 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(2))

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.7 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.8 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(3))

        ''Check Detail
        ''DETALLE
        ''UPGRADE_ISSUE: Printer property Printer.FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontName = "Courier New" '01.09.04
        ''UPGRADE_ISSUE: Printer property Printer.FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontSize = 9 '*************
        ''UPGRADE_ISSUE: Printer property Printer.FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontBold = True

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        ''01.09.04
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 3.67 * 1440
        ''nLines = parse_string(txtVendor, 18)
        'nLines = parse_string(sVendName, 18)
        'If nLines > 0 Then
        '	'Printer.Print gParse(1);
        'Else
        '	'Printer.Print txtVendor;
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(sVendName)
        'End If

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 7 * 1440 '7
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sCheckDate)

        ''UPGRADE_ISSUE: Printer property Printer.FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontUnderline = True

        ''TITULOS
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 3.67 * 1440 '3.87
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 2 * 1440 '3
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Store")
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440 '4
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Account")
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 4.5 * 1440 '5
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Invoice")
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6 * 1440 '6
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Amount")

        ''Printer.FontBold = False
        ''UPGRADE_ISSUE: Printer property Printer.FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontUnderline = False

        ''DATOS
        'nRate = 0.13 '0.15
        'i = 1
        ''namount = 1012.23
        'gCheck.rsStore.MoveFirst()
        'nCounter = 0
        'Do While Not gCheck.rsStore.EOF
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentY = (3.72 + (nRate * i)) * 1440 '3.92
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 2 * 1440 '3
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(gCheck.rsStore.item("Store"))
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 3 * 1440 '4
        '	'05.15.03 Mascara de cuenta
        '	'Printer.Print gCheck.rsStore("Account");
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(gCheck.rsStore.item("account_mask"))
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 4.5 * 1440 '5
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(gCheck.rsStore.item("Invoice"))
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 5.7 * 1440 '6
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(format_qty(FormatCurrency(gCheck.rsStore.item("Total"), 2, TriState.True)))
        '	gCheck.rsStore.MoveNext()
        '	i = i + 1
        'Loop 

        ''Nombre de vendedor multilinea
        'i = 1
        'For nCounter = 1 To nLines
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentY = (3.72 + (nRate * i)) * 1440 '3.92
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 0.1 * 1440
        '	'Printer.FontBold = True
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(gParse(nCounter))
        '	'Printer.FontBold = False
        '	i = i + 1
        'Next nCounter

        ''Listado de Tiendas
        ''list_store 2, 60
        'list_store2(sLinea, sCustName, sStoreArray, 2, 60)
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 6.2 * 1440 '6.52
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(1))
        ''---
        ''Total del cheque
        ''Printer.FontBold = True
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6 * 1440
        ''Printer.Print FormatCurrency(txtAmount, 2, vbTrue)
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(FormatCurrency(nCheckAmount, 2, TriState.True))
        ''Printer.FontBold = False
        ''Segunda linea de tiendas
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 6.35 * 1440
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(2))

        ''05.15.03
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 6.35 * 1440
        ''Printer.Print txtDetail1
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sDetail1)

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 6.55 * 1440
        ''Printer.Print txtDetail2
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sDetail2)

        ''COPIA *************************************

        ''UPGRADE_ISSUE: Printer property Printer.FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontBold = True

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 7.2 * 1440
        ''nLines = parse_string(txtVendor, 18)
        'nLines = parse_string(sVendName, 18)
        'If nLines > 0 Then
        '	'Printer.Print gParse(1);
        'Else
        '	'Printer.Print txtVendor;
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(sVendName)
        'End If
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 7 * 1440 '6
        ''Printer.Print dtCheckDate
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sCheckDate)

        ''UPGRADE_ISSUE: Printer property Printer.FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontUnderline = True

        ''TITULOS
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 7.15 * 1440 '7.35
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 2 * 1440 '3
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Store")
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440 '4
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Account")
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 4.5 * 1440 '5
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Invoice")
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6 * 1440 '3.7
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Amount")

        ''Printer.FontBold = False
        ''UPGRADE_ISSUE: Printer property Printer.FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontUnderline = False


        'i = 1
        'gCheck.rsStore.MoveFirst()
        'Do While Not gCheck.rsStore.EOF
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentY = (7.2 + (nRate * i)) * 1440 '7.4
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 2 * 1440 '3
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(gCheck.rsStore.item("Store"))
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 3 * 1440 '4
        '	'05.15.03 Mascara de Cuenta
        '	'Printer.Print gCheck.rsStore("Account");
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(gCheck.rsStore.item("account_mask"))
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 4.5 * 1440 '5
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(gCheck.rsStore.item("Invoice"))
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 5.7 * 1440 '6
        '	'Printer.Print FormatCurrency(gCheck.rsStore("Total"), 2, vbTrue)
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(format_qty(FormatCurrency(gCheck.rsStore.item("Total"), 2, TriState.True)))
        '	gCheck.rsStore.MoveNext()
        '	i = i + 1
        'Loop 

        ''Nombre de vendedor multilinea
        'i = 1
        'For nCounter = 1 To nLines
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentY = (7.2 + (nRate * i)) * 1440 '7.4
        '	'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.CurrentX = 0.1 * 1440
        '	'Printer.FontBold = True
        '	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        '	'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Printer.Print(gParse(nCounter))
        '	'Printer.FontBold = False
        '	i = i + 1
        'Next nCounter

        ''Stores
        ''list_store 2, 60
        'list_store2(sLinea, sCustName, sStoreArray, 2, 60)
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 9.68 * 1440 '9.68
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(1))

        ''Printer.FontBold = True
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6 * 1440
        ''Printer.Print FormatCurrency(txtAmount, 2, vbTrue)
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(FormatCurrency(nCheckAmount, 2, TriState.True))


        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 9.83 * 1440 '9.83
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(2))
        ''05.15.03
        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 9.98 * 1440
        ''Printer.Print txtDetail1
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sDetail1)

        ''UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440
        ''UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 10.18 * 1440
        ''Printer.Print txtDetail2
        ''UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        ''UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sDetail2)

        ''UPGRADE_ISSUE: Printer method Printer.EndDoc was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.EndDoc()
		Exit Sub
		
ErrorHandler: 
		save_error("frmCheckRep", "print_check4")
		MsgBox("An unexpected error has ocurred while generating check." & vbCrLf & "Please review log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.Exclamation, "GLM Error")
	End Sub
	
	
	'UPGRADE_WARNING: Event obSelectedBranches.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub obSelectedBranches_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles obSelectedBranches.CheckedChanged
		If eventSender.Checked Then
			If cbVendor.SelectedIndex <= 0 Then
				MsgBox("Please select a Vendor before attempting this option.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
				obAllBranches.Checked = True
				cbVendor.Focus()
				Exit Sub
			End If
			
			cmdShowVBranch.Enabled = obSelectedBranches.Checked
			
			
			
		End If
	End Sub
End Class