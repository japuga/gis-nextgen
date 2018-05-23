Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmCustomerEntry
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
	Private Const MAXBILLINGACCOUNTNO As Short = 30
	
	
	
	Private Sub load_qb_account(ByRef sGroupId As String)
		
		On Error GoTo ErrorHandler
		
		'QB Account
		sStmt = "SELECT name FROM qb_account " & " WHERE qb_group_id ='" & Trim(sGroupId) & "'" & " AND Accnttype='OCLIAB'"
		
		load_cb_query2(cbQBAccountName, sStmt, 1, True)
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_qb_account")
		MsgBox("Failed to access QBooks Account table." & "Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
		
		
	End Sub
	'UPGRADE_WARNING: Event cbQBGroupDesc.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbQBGroupDesc_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbQBGroupDesc.SelectedIndexChanged
		cbQBGroupId.SelectedIndex = cbQBGroupDesc.SelectedIndex
		load_qb_customer(cbQBGroupId.Text)
		load_qb_account(cbQBGroupId.Text)
	End Sub
	Private Sub load_qb_customer(ByRef sGroupId As String)
		On Error GoTo ErrorHandler
		
		'QB Customer
		sStmt = "SELECT name FROM qb_customer " & " WHERE qb_group_id ='" & Trim(sGroupId) & "'"
		load_cb_query2(cbQBCustName, sStmt, 1, True)
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "load_qb_customer")
		MsgBox("Failed to access QBooks Customer table." & "Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
		
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If val_fields Then
			If save_customer Then
				Me.Close()
			End If
		End If
		
	End Sub
	Private Function val_fields() As Boolean
		On Error GoTo ErrorHandler
		
		val_fields = True
		If Len(Trim(txtCustId.Text)) = 0 Then
			MsgBox("Please enter Customer Id.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
			txtCustId.Focus()
			val_fields = False
			Exit Function
		End If
		
		
		If Len(Trim(txtCustName.Text)) = 0 Then
			MsgBox("Please enter Customer Name.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
			txtCustName.Focus()
			val_fields = False
			Exit Function
		End If
		
		If Len(Trim(txtCustReportName.Text)) = 0 Then
			MsgBox("Please enter Report Caption.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
			txtCustReportName.Focus()
			val_fields = False
			Exit Function
		End If
		
		
        If Len(mtxtCustPhone1.Text) > 0 And Len(mtxtCustPhone1.Text) < 10 Then
            MsgBox("Phone1: Please enter 10 digit number including Area Code", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            mtxtCustPhone1.Focus()
            val_fields = False
            Exit Function
        End If
		
        If Len(mtxtCustPhone2.Text) > 0 And Len(mtxtCustPhone2.Text) < 10 Then
            MsgBox("Phone2: Please enter 10 digit number including Area Code", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            mtxtCustPhone2.Focus()
            val_fields = False
            Exit Function
        End If
		
        If Len(mtxtCustPhone3.Text) > 0 And Len(mtxtCustPhone3.Text) < 10 Then
            MsgBox("Phone3: Please enter 10 digit number including Area Code", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            mtxtCustPhone3.Focus()
            val_fields = False
            Exit Function
        End If
		
        If Not IsDBNull(txtBillingAccountNo.Text) Then
            If Len(txtBillingAccountNo.Text) > MAXBILLINGACCOUNTNO Then
                MsgBox("Billing Account exceeds max length. Operation was cancelled.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Warning")
                val_fields = False
            End If
        End If
		
		If cbQBGroupId.SelectedIndex < 0 Then
			MsgBox("A company Group must be assigned to this customer.")
			
			cbQBGroupId.Focus()
			val_fields = False
			Exit Function
		End If
		
		If cbQBCustName.SelectedIndex < 0 Then
			MsgBox("A Quick Books Customer Name must be assigned to this customer.")
			If cbQBCustName.Enabled Then
				cbQBCustName.Focus()
			End If
			val_fields = False
			Exit Function
		End If
		
		If cbQBAccountName.SelectedIndex < 0 Then
			MsgBox("A Quick Books Account must be assigned to this customer.")
			If cbQBAccountName.Enabled Then
				cbQBAccountName.Focus()
			End If
			val_fields = False
			Exit Function
		End If
		
		
		Exit Function
		
ErrorHandler: 
		val_fields = False
		save_error(Me.Name, "val_fields")
		MsgBox("Failed to verify data input. Check log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Error")
	End Function
	
	Private Function save_customer() As Boolean
		Dim nGroupSeq As Short
		Dim nRecords As Short
        Dim nLevel As SqlTransaction
		Dim sCustPhone1 As String
		Dim sCustPhone2 As String
		Dim sCustPhone3 As String
        Dim sInvoicePayFlag As String
        'Dim nTrans As SqlTransaction
        Dim cmd As SqlCommand = cn.CreateCommand()

        nLevel = Nothing

        Try
            save_customer = True

            cm = cn.CreateCommand()
            cm.CommandType = CommandType.Text

            If mtxtCustPhone1.Text(1) <> " " Then
                sCustPhone1 = mtxtCustPhone1.Text
            Else
                sCustPhone1 = ""
            End If

            If mtxtCustPhone2.Text(1) <> " " Then
                sCustPhone2 = mtxtCustPhone2.Text 'mtxtCustPhone2.Text
            Else
                sCustPhone2 = ""
            End If

            If mtxtCustPhone3.Text(1) <> " " Then
                sCustPhone3 = mtxtCustPhone3.Text
            Else
                sCustPhone3 = ""
            End If

            If chkPayInvoices.CheckState = System.Windows.Forms.CheckState.Checked Then
                sInvoicePayFlag = "F"
            Else
                sInvoicePayFlag = "T"
            End If

            Select Case gCustomerRecord.bFlag
                Case General.modo.NewRecord
                    'Verificar que no se repita Cliente
                    sStmt = "SELECT cust_id FROM customer " & "WHERE cust_id ='" & txtCustId.Text & "'"
                    cm.CommandText = sStmt

                    rsLocal = getDataTable(sStmt) 'cm.ExecuteReader()

                    If rsLocal.Rows.Count > 0 Then
                        MsgBox("Customer Code already exists in database.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                        txtCustId.Focus()
                        save_customer = False
                        Exit Function
                    End If


                    sStmt = "SELECT cust_name FROM customer " & "WHERE cust_name ='" & Trim(txtCustName.Text) & "'"
                    cm.CommandText = sStmt

                    rsLocal = getDataTable(sStmt) 'cm.ExecuteReader()

                    If rsLocal.Rows.Count > 0 Then
                        MsgBox("Customer Name already exists in database.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                        txtCustName.Focus()
                        save_customer = False
                        Exit Function
                    End If

                    nLevel = cn.BeginTransaction()
                    cm.Transaction = nLevel
                    Try
                        'Insertar en tabla Customer
                        'MsgBox "Nesting level:" + Str(nLevel)
                        sStmt = "INSERT INTO customer(cust_id, state_id, " & "cust_name, cust_contact, cust_phone1," & "cust_phone2, cust_phone3, cust_address, " & "cust_city, cust_zip, cust_contact_title, " & "cust_email, qb_group_id, qb_cust_name, " & "qb_account_name, cust_report_name, " & "invoice_pay_flag, negative_savings_flag, contract_number, billing_account_no )" & " VALUES ('" & Trim(txtCustId.Text) & "'," & "'" & cbState.Text & "','" & quotation_mask(Trim(txtCustName.Text)) & "'," & "'" & quotation_mask(Trim(txtCustContact.Text)) & "'," & "'" & Trim(sCustPhone1) & "'," & "'" & Trim(sCustPhone2) & "'," & "'" & Trim(sCustPhone3) & "'," & "'" & quotation_mask(Trim(txtCustAddress.Text)) & "'," & "'" & quotation_mask(Trim(txtCustCity.Text)) & "'," & "'" & Trim(txtCustZip.Text) & "'," & "'" & quotation_mask(Trim(txtContactTitle.Text)) & "'," & "'" & quotation_mask(Trim(txtCustEmail.Text)) & "'," & "'" & cbQBGroupId.Text & "','" & quotation_mask(cbQBCustName.Text) & "'," & "'" & quotation_mask(cbQBAccountName.Text) & "'," & "'" & quotation_mask(Trim(txtCustReportName.Text)) & "', " & "'" & sInvoicePayFlag & "', " & "'" & cbNegativeSavingsFlag.Text & "', " & "'" & quotation_mask((txtContractNumber.Text)) & "'," & "'" & quotation_mask((txtBillingAccountNo.Text)) & "')"
                        cm.CommandText = sStmt
                        nRecords = cm.ExecuteNonQuery()

                        If nRecords > 0 Then
                            'ok
                        Else
                            nLevel.Rollback()
                            MsgBox("Failed to insert into Customer table, " & vbCrLf & "Check log file for details", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                            save_customer = False
                            Exit Function
                        End If

                    Catch ex As Exception
                        save_customer = False

                        nLevel.Rollback()

                        save_error(Me.Name, "save_Customer")
                        MsgBox("Failed to save Customer info. Review log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
                    End Try
                    'Crear grupo ALL por defecto
                    sStmt = "SELECT MAX(group_seq) FROM Groups"
                    cm.CommandText = sStmt
                    rsLocal = getDataTable(sStmt, nLevel) 'cm.ExecuteReader()

                    If rsLocal.Rows.Count > 0 Then
                        nGroupSeq = rsLocal.Rows(0).Item(0) + 1
                    Else
                        nGroupSeq = 1
                    End If


                    'Grupo por defecto al que pertenecen todas las tiendas.
                    sStmt = "INSERT INTO Groups (cust_id, group_seq, group_name)" & "VALUES ('" & txtCustId.Text & "'," & Str(nGroupSeq) & ",'All')"
                    cm.CommandText = sStmt
                    nRecords = cm.ExecuteNonQuery()

                    If nRecords > 0 Then
                        'ok
                        nLevel.Commit()
                        gCustomerRecord.bFlag = General.modo.SavedRecord

                        MsgBox("Customer was successfully created.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                    Else
                        nLevel.Rollback()
                        save_customer = False
                        MsgBox("Failed to create default Group. " & vbCrLf & "Check log file for details", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                    End If

                    'Agregar Informacion en RepCust para RepCostContainment Report
                    'Esto es opcional, si falla no se hace RollBack
                    If gCustomerRecord.bFlag = General.modo.SavedRecord Then
                        Try

                            nLevel = Nothing
                            cm.CommandType = CommandType.StoredProcedure
                            cm.CommandText = "usp_insert_rep_cust"
                            SqlCommandBuilder.DeriveParameters(cm)

                            'cm.Parameters.Refresh()
                            cm.Parameters("@sCustId").Value = Trim(txtCustId.Text)
                            cm.Parameters("@nResult").Direction = ParameterDirection.Output
                            
                            'cm.Parameters("@nReportId").Value = 
                            'Dim str As String = cm.Parameters("@sCustId").ParameterName
                            cm.ExecuteNonQuery()

                            If cm.Parameters("@nResult").Value = 0 Then
                                'ok
                            Else
                                MsgBox("Failed to add Report Defaults.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                            End If

                        Catch ex As Exception
                            'no importa si algo malo pasa.
                        End Try
                    End If
                Case General.modo.UpdateRecord
                    'Verificar que no se repita
                    sStmt = "SELECT cust_name FROM customer " & "WHERE cust_name ='" & Trim(txtCustName.Text) & "'" & " AND cust_id <>'" & txtCustId.Text & "'"
                    cmd.CommandText = sStmt
                    rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader

                    If rsLocal.Rows.Count > 0 Then
                        MsgBox("Customer Name already exists in database.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                        txtCustName.Focus()
                        save_customer = False
                        Exit Function
                    End If

                    Try
                        'Actualizar registro
                        nLevel = cn.BeginTransaction()
                        sStmt = "UPDATE customer SET " & "cust_name ='" & quotation_mask(Trim(txtCustName.Text)) & "'," & "state_id = '" & cbState.Text & "'," & "cust_contact = '" & quotation_mask(Trim(txtCustContact.Text)) & "'," & "cust_phone1= '" & Trim(sCustPhone1) & "'," & "cust_phone2= '" & Trim(sCustPhone2) & "'," & "cust_phone3= '" & Trim(sCustPhone3) & "'," & "cust_address= '" & quotation_mask(Trim(txtCustAddress.Text)) & "'," & "cust_city = '" & quotation_mask(Trim(txtCustCity.Text)) & "'," & "cust_zip ='" & Trim(txtCustZip.Text) & "'," & "cust_contact_title ='" & quotation_mask(Trim(txtContactTitle.Text)) & "'," & "cust_email ='" & quotation_mask(Trim(txtCustEmail.Text)) & "'," & "qb_group_id ='" & cbQBGroupId.Text & "'," & "qb_cust_name = '" & quotation_mask(cbQBCustName.Text) & "'," & "qb_account_name = '" & quotation_mask(cbQBAccountName.Text) & "'," & "cust_report_name ='" & quotation_mask(Trim(txtCustReportName.Text)) & "', " & "invoice_pay_flag ='" & sInvoicePayFlag & "'," & "negative_savings_flag ='" & cbNegativeSavingsFlag.Text & "', " & "contract_number = '" & quotation_mask((txtContractNumber.Text)) & "', " & "billing_account_no = '" & quotation_mask((txtBillingAccountNo.Text)) & "' " & " WHERE cust_id = '" & txtCustId.Text & "'"
                        cmd = cn.CreateCommand
                        cmd.Transaction = nLevel
                        cmd.CommandText = sStmt
                        nRecords = cmd.ExecuteNonQuery()

                        If nRecords > 0 Then
                            'ok
                            nLevel.Commit()
                            gCustomerRecord.bFlag = General.modo.SavedRecord
                            MsgBox("Customer was successfully updated.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                        Else
                            nLevel.Rollback()
                            MsgBox("Failed to update Customer table, " & vbCrLf & "Check log file for details", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                            save_customer = False
                            Exit Function
                        End If
                    Catch exc As Exception
                        MsgBox("Failed to save Customer info. Review log file for details: " & exc.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
                    End Try
            End Select
            Exit Function

        Catch ex As Exception
            Dim err As String = ex.Message
            save_customer = False
            If Not IsNothing(nLevel) Then
                nLevel.Rollback()
            End If


            save_error(Me.Name, "save_Customer")
            MsgBox("Failed to save Customer info. Review log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
        End Try
    End Function
	Private Sub frmCustomerEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		set_limits()
		init_vars()
	End Sub
	Private Sub set_limits()
		

		txtCustId.Maxlength = 2

		txtCustName.Maxlength = 20

		txtCustContact.Maxlength = 20

		txtCustAddress.Maxlength = 30

		txtCustCity.Maxlength = 15

		txtCustZip.Maxlength = 15

		txtContactTitle.Maxlength = 20

		txtCustEmail.Maxlength = 40

		txtCustReportName.Maxlength = 30
		
	End Sub
	Private Sub init_vars()

        chkPayInvoices.CheckState = System.Windows.Forms.CheckState.Unchecked


        'State
        sStmt = "SELECT state_id FROM state "
        load_cb_query2(cbState, sStmt, 1, True)

        'Negative Savings Flag
        sStmt = "SELECT field_option FROM SDomain " & " WHERE domain_field='negative_savings_flag' " & " ORDER BY option_order "
        load_cb_query2(cbNegativeSavingsFlag, sStmt, 1, True)

        'Quick Books
        'Group
        sStmt = "SELECT qb_group_desc, qb_group_id " & "FROM qb_group ORDER BY qb_group_id"
        load_cb_query2(cbQBGroupDesc, sStmt, 1, True)

        sStmt = "SELECT qb_group_id " & "FROM qb_group ORDER BY qb_group_id"
        load_cb_query2(cbQBGroupId, sStmt, 1, True)

        enable_QB(False)

        Select Case gCustomerRecord.bFlag
            Case General.modo.NewRecord
                If cbState.Items.Count > 0 Then
                    cbState.SelectedIndex = 0
                End If

                If cbNegativeSavingsFlag.Items.Count > 0 Then
                    cbNegativeSavingsFlag.SelectedIndex = 0
                End If

                If cbQBGroupDesc.Items.Count > 0 Then
                    cbQBGroupDesc.SelectedIndex = 0
                End If

                clearFields()
                txtCustId.Enabled = True
                enable_QB(True)
            Case General.modo.UpdateRecord
                txtCustId.Text = gCustomerRecord.sCustId
                load_customer(gCustomerRecord.sCustId)
                txtCustId.Enabled = False
                'Solo Administradores pueden actualizar Qb.
                If gsUserType = CStr(General.UserType.Administrator) Then
                    enable_QB(True)
                End If
        End Select

    End Sub
	Private Sub enable_QB(ByRef bOption As Boolean)
		frQuickBooks.Enabled = bOption
		cbQBGroupDesc.Enabled = bOption
		cbQBCustName.Enabled = bOption
		cbQBAccountName.Enabled = bOption
		
	End Sub
	Private Function load_customer(ByRef sCustId As String) As Boolean
		Dim sCustPhone As String
		
		On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand()
		load_customer = True
		
		
		sStmt = "SELECT cust_id, cust_name, cust_contact, " & "state_id, cust_phone1, cust_phone2, " & "cust_phone3, cust_address, cust_city, " & "cust_zip, cust_contact_title, cust_email," & "qb_group_id, qb_cust_name, qb_account_name, " & "cust_report_name, invoice_pay_flag, " & "negative_savings_flag, billing_account_no " & " FROM customer WHERE cust_id ='" & sCustId & "'"
        cmd.CommandText = sStmt
		
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader()

        If rsLocal.Rows.Count > 0 Then
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item("cust_id")) Then
                txtCustId.Text = ""
                load_customer = False
                MsgBox("Error loading Customer Code.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                load_customer = False
                Exit Function
            Else
                txtCustId.Text = rsLocal.Rows(0).Item("cust_id")
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item("cust_name")) Then
                txtCustName.Text = ""
            Else
                If Len(Trim(rsLocal.Rows(0).Item("cust_name"))) = 0 Then
                    txtCustName.Text = ""
                Else
                    txtCustName.Text = rsLocal.Rows(0).Item("cust_name")
                End If
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item("cust_contact")) Then
                txtCustContact.Text = ""
            Else
                If Len(Trim(rsLocal.Rows(0).Item("cust_contact"))) = 0 Then
                    txtCustContact.Text = ""
                Else
                    txtCustContact.Text = rsLocal.Rows(0).Item("cust_contact")
                End If
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item("cust_contact_title")) Then
                txtContactTitle.Text = ""
            Else
                If Len(Trim(rsLocal.Rows(0).Item("cust_contact_title"))) = 0 Then
                    txtContactTitle.Text = ""
                Else
                    txtContactTitle.Text = rsLocal.Rows(0).Item("cust_contact_title")
                End If
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item("cust_report_name")) Then
                txtCustReportName.Text = ""
            Else
                If Len(Trim(rsLocal.Rows(0).Item("cust_report_name"))) = 0 Then
                    txtCustReportName.Text = ""
                Else
                    txtCustReportName.Text = rsLocal.Rows(0).Item("cust_report_name")
                End If
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item("cust_address")) Then
                txtCustAddress.Text = ""
            Else
                If Len(Trim(rsLocal.Rows(0).Item("cust_address"))) = 0 Then
                    txtCustAddress.Text = ""
                Else
                    txtCustAddress.Text = rsLocal.Rows(0).Item("cust_address")
                End If
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item("cust_city")) Then
                txtCustCity.Text = ""
            Else
                If Len(Trim(rsLocal.Rows(0).Item("cust_city"))) = 0 Then
                    txtCustCity.Text = ""
                Else
                    txtCustCity.Text = rsLocal.Rows(0).Item("cust_city")
                End If
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item("cust_zip")) Then
                txtCustZip.Text = ""
            Else
                txtCustZip.Text = rsLocal.Rows(0).Item("cust_zip")
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item("cust_email")) Then
                txtCustEmail.Text = ""
            Else
                If Len(Trim(rsLocal.Rows(0).Item("cust_email"))) = 0 Then
                    txtCustEmail.Text = ""
                Else
                    txtCustEmail.Text = rsLocal.Rows(0).Item("cust_email")
                End If
            End If

            'State
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item("state_id")) Then
                cbState.SelectedIndex = 0
            Else
                set_cb(cbState, rsLocal.Rows(0).Item("state_id"))
            End If

            'Phone1
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item("cust_phone1")) Then
                'Nothing
            Else
                If Len(Trim(rsLocal.Rows(0).Item("cust_phone1"))) = 0 Then
                    'Nothing
                Else
                    sCustPhone = Trim(rsLocal.Rows(0).Item("cust_phone1"))
                    mtxtCustPhone1.Text = sCustPhone
                End If
            End If
            'Phone2
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item("cust_phone2")) Then
                'Nothing
            Else
                If Len(Trim(rsLocal.Rows(0).Item("cust_phone2"))) = 0 Then
                    'Nothing
                Else
                    sCustPhone = Trim(rsLocal.Rows(0).Item("cust_phone2"))
                    mtxtCustPhone2.Text = sCustPhone
                End If
            End If

            'Phone3
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item("cust_phone3")) Then
                'Nothing
            Else
                If Len(Trim(rsLocal.Rows(0).Item("cust_phone3"))) = 0 Then
                    'Nothing
                Else
                    sCustPhone = Trim(rsLocal.Rows(0).Item("cust_phone3"))
                    mtxtCustPhone3.Text = sCustPhone
                End If
            End If

            'Invoice Flag
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item("invoice_pay_flag")) Then
                chkPayInvoices.CheckState = System.Windows.Forms.CheckState.Unchecked
            Else
                If rsLocal.Rows(0).Item("invoice_pay_flag") = "T" Then
                    chkPayInvoices.CheckState = System.Windows.Forms.CheckState.Unchecked
                Else
                    chkPayInvoices.CheckState = System.Windows.Forms.CheckState.Checked
                End If
            End If

            'Negative Savings Flag
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item("negative_savings_flag")) Then
                cbNegativeSavingsFlag.SelectedIndex = 0
            Else
                set_cb(cbNegativeSavingsFlag, rsLocal.Rows(0).Item("negative_savings_flag"))
            End If

            'Billing Account
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            txtBillingAccountNo.Text = IIf(IsDBNull(rsLocal.Rows(0).Item("billing_account_no")), "", rsLocal.Rows(0).Item("billing_account_no"))


            'Quick Books
            set_cb(cbQBGroupId, Trim(rsLocal.Rows(0).Item("qb_group_id")))
            If cbQBGroupId.SelectedIndex >= 0 Then
                cbQBGroupDesc.SelectedIndex = cbQBGroupId.SelectedIndex
            End If

            set_cb(cbQBCustName, Trim(rsLocal.Rows(0).Item("qb_cust_name")))

            set_cb(cbQBAccountName, Trim(rsLocal.Rows(0).Item("qb_account_name")))

        End If

        Exit Function

ErrorHandler:
        save_error(Me.Name, "load_customer")
        MsgBox("Failed to access Customer table." & vbCrLf & "Check log file for details.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
	End Function
	Private Sub frmCustomerEntry_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'Set rsLocal = Nothing
	End Sub
	
	Private Sub txtCustCity_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCustCity.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If (KeyAscii >= 65 And KeyAscii <= 90) Or (KeyAscii >= 97 And KeyAscii <= 122) Then
			'OK. Mayusculas o Minusculas
		Else
			'Numeros, Backspace and Space
			If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 32 Then
				'Es numero
			Else
				KeyAscii = 0
			End If
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtCustEmail_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCustEmail.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'If (KeyAscii >= 65 And KeyAscii <= 90) _
		''Or (KeyAscii >= 97 And KeyAscii <= 122) _
		''Then
		'OK. Mayusculas o Minusculas
		'Else
		'Numeros, Backspace, Space , @ y punto
		'    If (KeyAscii >= 48 And KeyAscii <= 57) _
		''    Or KeyAscii = 8 Or KeyAscii = 32 _
		''    Or KeyAscii = 64 Or KeyAscii = 46 _
		''    Then
		'Es numero
		'    Else
		'        KeyAscii = 0
		'    End If
		'End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtCustId_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCustId.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Mayusculas o Minusculas
		If (KeyAscii >= 65 And KeyAscii <= 90) Or (KeyAscii >= 97 And KeyAscii <= 122) Then
			KeyAscii = Asc(UCase(Chr(KeyAscii)))
		Else
			'Numeros, Backspace and Space
			If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Then
				'Es numero
			Else
				KeyAscii = 0
			End If
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtCustName_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCustName.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If (KeyAscii >= 65 And KeyAscii <= 90) Or (KeyAscii >= 97 And KeyAscii <= 122) Then
			'OK. Mayusculas o Minusculas
		Else
			'Numeros, Backspace and Space
			If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 32 Then
				'Es numero
			Else
				KeyAscii = 0
			End If
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtCustZip_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCustZip.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros:0-9 , Backspace y Guion (-)
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 45 Then
			'Es numero
			If KeyAscii = 45 Then
				If InStr(1, txtCustZip.Text, "-", CompareMethod.Text) = 0 Then
					'OK. Solo un guion se permite
				Else
					KeyAscii = 0
				End If
			End If
		Else
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
    End Sub

    Private Sub clearFields()

        txtCustId.Text = ""
        txtCustName.Text = ""
        txtCustContact.Text = ""
        txtContactTitle.Text = ""
        txtCustReportName.Text = ""
        txtCustAddress.Text = ""
        txtCustCity.Text = ""
        txtCustZip.Text = ""
        txtCustEmail.Text = ""

        cbState.SelectedIndex = 0
        mtxtCustPhone1.Text = ""
        mtxtCustPhone2.Text = ""
        mtxtCustPhone3.Text = ""

        chkPayInvoices.CheckState = System.Windows.Forms.CheckState.Unchecked

        cbNegativeSavingsFlag.SelectedIndex = 0
        
        txtBillingAccountNo.Text = ""

    End Sub

End Class