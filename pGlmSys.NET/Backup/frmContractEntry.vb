Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmContractEntry
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private cmLocal As SqlCommand
	'UPGRADE_WARNING: Arrays in structure aFrequency may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Private aFrequency As gTableUDT
	
	'UPGRADE_WARNING: Event cbFreqPeriod.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbFreqPeriod_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbFreqPeriod.SelectedIndexChanged
		'Select Case cbFreqPeriod
		'Case "On Call"
		'    enable_service True, False
		'Case "Weekly"
		'    enable_service True, True
		'Case "Monthly"
		'    enable_service True, True
		'End Select
		
		
		'Mapping
		'FreqDesc =str_field2
		'FreqSchedFlag = str_field3
		'FreqTimesFlag = str_field4
		If aFrequency.aRecord(cbFreqPeriod.SelectedIndex).str_field3 = "T" Then
			If aFrequency.aRecord(cbFreqPeriod.SelectedIndex).str_field4 = "T" Then
				enable_service(True, True)
			Else
				enable_service(True, False)
			End If
		Else
			If aFrequency.aRecord(cbFreqPeriod.SelectedIndex).str_field4 = "T" Then
				enable_service(False, True)
			Else
				enable_service(False, False)
			End If
		End If
		
		If aFrequency.aRecord(cbFreqPeriod.SelectedIndex).str_field4 = "T" Then
			lbTimes.Text = "Times per " & aFrequency.aRecord(cbFreqPeriod.SelectedIndex).str_field2
		Else
			lbTimes.Text = "Times"
		End If
		
	End Sub
	
	'UPGRADE_WARNING: Event cbRateDesc.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbRateDesc_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbRateDesc.SelectedIndexChanged
		cbRateStatus.SelectedIndex = cbRateDesc.SelectedIndex
	End Sub
	
	'UPGRADE_WARNING: Event cbVendName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbVendName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbVendName.SelectedIndexChanged
		
		'addNewVendor
		
	End Sub
	Private Sub addNewVendor()
		'<New> fue seleccionado
		If cbVendName.SelectedIndex = 0 Then
			gVendorSearch.bFlag = False
			VB6.ShowForm(frmVendorBrowse, VB6.FormShowConstants.Modal, Me)
			If gVendorSearch.bFlag Then
				If Not set_cb_ItemData2(cbVendName, gVendorSearch.nVendSeq) Then
					'Agregar nuevo vendor al combo
					cbVendName.Items.Insert(cbVendName.Items.Count, gVendorSearch.sVendName)
					VB6.SetItemData(cbVendName, cbVendName.Items.Count - 1, gVendorSearch.nVendSeq)
					'Apunto al nuevo vendor
					cbVendName.SelectedIndex = cbVendName.Items.Count - 1
				End If
			End If
		End If
		
	End Sub
	
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
        Dim sFreqTimes As String = ""
        Dim sFreqPeriod As String = ""
        Dim nRecords As Short = 0
        Dim i As Short = 0
        Dim nCount As Short = 0
        Dim sDays As String = ""
		Dim sDefaultService As String
		Dim sOverrideExpFlag As String
		
		
		If Not val_fields Then
			Exit Sub
		End If
		
		'FreqTimes
		sFreqTimes = ""
		sFreqPeriod = ""
		'If cbFreqPeriod = "On Call" Then
		'    sFreqTimes = "O/C"
		'    sFreqPeriod = ""
		'Else
		'    sFreqTimes = count_days
		'    Select Case cbFreqPeriod
		'    Case "Weekly"
		'        sFreqPeriod = "WK"
		'    Case "Monthly"
		'        sFreqPeriod = "MO"
		'    End Select
		'End If
		
		'Mapping:
		'   FreqSchedFlag = str_field3
		'   FreqTimesFlag = str_field4
		'   FreqAcronym = str_field5
		sFreqPeriod = aFrequency.aRecord(cbFreqPeriod.SelectedIndex).str_field5
		sFreqTimes = txtFreqTimes.Text
		
		If ckbDefaultService.CheckState = System.Windows.Forms.CheckState.Checked Then
			sDefaultService = "T"
		Else
			sDefaultService = "F"
		End If
		
		If ckbOverrideExpFlag.CheckState = System.Windows.Forms.CheckState.Checked Then
			sOverrideExpFlag = "YES"
		Else
			sOverrideExpFlag = "NO"
		End If
		
		'MsgBox sFreqTimes
		Select Case gContractRecord.bFlag
			Case General.modo.NewRecord
				
				If duplicated_eqpt_serv(gContractRecord.sCustId, gContractRecord.nStoreId, VB6.GetItemData(cbEqptDesc, cbEqptDesc.SelectedIndex), VB6.GetItemData(cbServDesc, cbServDesc.SelectedIndex), VB6.GetItemData(cbVendName, cbVendName.SelectedIndex)) Then
					'Usuario decide no continuar
					Exit Sub
				End If
				
				If duplicated_PK(gContractRecord.sCustId, gContractRecord.nStoreId, VB6.GetItemData(cbEqptDesc, cbEqptDesc.SelectedIndex), VB6.GetItemData(cbServDesc, cbServDesc.SelectedIndex), VB6.GetItemData(cbVendName, cbVendName.SelectedIndex)) Then
					'LLave primaria repetida
					Exit Sub
				End If
				sStmt = "INSERT INTO VContract (" & " cust_id, vend_seq, store_id, " & " eqpt_seq, serv_id, freq_id, freq_times, " & " freq_period, freq_day1, freq_day2, " & " freq_day3, freq_day4, freq_day5, " & " freq_day6, freq_day7, curr_rate, " & " old_rate, opening_date, expiration_date, " & " freq_comments, contract_comments, rate_status, " & " default_service, override_exp_flag, glm_rate) " & " VALUES (" & "'" & gContractRecord.sCustId & "'," & " " & Str(VB6.GetItemData(cbVendName, cbVendName.SelectedIndex)) & " ," & " " & Str(gContractRecord.nStoreId) & "," & " " & Str(VB6.GetItemData(cbEqptDesc, cbEqptDesc.SelectedIndex)) & "," & " " & Str(VB6.GetItemData(cbServDesc, cbServDesc.SelectedIndex)) & "," & " " & Str(VB6.GetItemData(cbFreqPeriod, cbFreqPeriod.SelectedIndex)) & "," & "'" & Trim(sFreqTimes) & "',"
				
				'Period
				'If sFreqPeriod = "" Then
				'Mapping: FreqSchedFlag = str_field3
				If aFrequency.aRecord(cbFreqPeriod.SelectedIndex).str_field3 = "F" Then
					sStmt = sStmt & "'" & Trim(sFreqPeriod) & "', " & "NULL, NULL, NULL, " & "NULL, NULL, NULL, NULL,"
				Else
					sStmt = sStmt & "'" & Trim(sFreqPeriod) & "', "
					
					nCount = 0
					For i = 0 To 6
						If ckbFreqDay(i).CheckState = System.Windows.Forms.CheckState.Checked Then
							nCount = nCount + 1
							sDays = sDays & "'" & ckbFreqDay(i).Tag & "',"
						End If
					Next i
					For i = nCount + 1 To 7
						sDays = sDays & "NULL ,"
					Next i
					'MsgBox sDays
					
					sStmt = sStmt & sDays
				End If

                sStmt = sStmt & txtCurrRate.Text & "," & " " & txtOldRate.Text & "," & "'" & dtOpening.Value & "'," & _
                    "'" & dtExpiration.Value & "', " & "'" & quotation_mask(txtFreqComments.Text) & "', " & _
                    "'" & quotation_mask(txtContractComments.Text) & "', " & "'" & Trim(cbRateStatus.Text) & "', " & _
                    "'" & Trim(sDefaultService) & "', " & "'" & Trim(sOverrideExpFlag) & "'," & " " & txtGlmRate.Text & ")"
				'MsgBox sStmt
				cmLocal.CommandText = sStmt
                nRecords = cmLocal.ExecuteNonQuery()
				If nRecords > 0 Then
					MsgBox("Contract was successfully created!", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
					
					gContractRecord.bFlag = General.modo.SavedRecord
				Else
					MsgBox("Unable to insert info in Contract table.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Error")
					
				End If
				
			Case General.modo.UpdateRecord
                'cn.BeginTransaction()
				'Guardo contrato original antes de guardar cambios
				sStmt = "INSERT INTO VContracthistory (" & " cust_id, vend_seq, store_id, " & " eqpt_seq, serv_id, freq_times, " & " freq_period, freq_day1, freq_day2, " & " freq_day3, freq_day4, freq_day5, " & " freq_day6, freq_day7, curr_rate, " & " old_rate, opening_date, expiration_date, " & " rebate_ton_price, rate_status, suser_name, " & " change_dtim, freq_id, freq_comments, contract_comments, default_service, override_exp_flag, glm_rate ) " & " SELECT " & " cust_id, vend_seq, store_id, " & " eqpt_seq, serv_id, freq_times, " & " freq_period, freq_day1, freq_day2, " & " freq_day3, freq_day4, freq_day5, " & " freq_day6, freq_day7, curr_rate, " & " old_rate, opening_date, expiration_date, " & " rebate_ton_price, rate_status, '" & gsUser & "', " & " getdate(), freq_id, freq_comments, contract_comments," & " default_service, override_exp_flag, glm_rate " & " FROM VContract " & " WHERE cust_id = '" & gContractRecord.sCustId & "' " & " AND vend_seq = " & Str(gContractRecord.nVendSeq) & " " & " AND store_id = " & Str(gContractRecord.nStoreId) & " " & " AND eqpt_seq = " & Str(gContractRecord.nEqptSeq) & " " & " AND serv_id = " & Str(gContractRecord.nServId)
				
				'MsgBox sStmt
				cmLocal.CommandText = sStmt
                nRecords = cmLocal.ExecuteNonQuery()
				If nRecords >= 1 Then
					'Inserto informacion historica.Continua
				Else
					MsgBox("There was a problem while saving History information.", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
					Exit Sub
				End If
				
				'VContract
				sStmt = "UPDATE VContract SET " & " freq_times = '" & Trim(sFreqTimes) & "', "
				'Period
				'If sFreqPeriod = "" Then
				'Mapping: FreqSchedFlag = str_field3
				If aFrequency.aRecord(cbFreqPeriod.SelectedIndex).str_field3 = "F" Then
					'sStmt = sStmt + " freq_period = NULL, " +
					sStmt = sStmt & " freq_period = '" & Trim(sFreqPeriod) & "'," & " freq_day1 = NULL, " & " freq_day2 = NULL, " & " freq_day3 = NULL, " & " freq_day4 = NULL, " & " freq_day5 = NULL, " & " freq_day6 = NULL, " & " freq_day7 = NULL, "
				Else
					sStmt = sStmt & " freq_period = '" & Trim(sFreqPeriod) & "', "
					
					nCount = 0
					For i = 0 To 6
						If ckbFreqDay(i).CheckState = System.Windows.Forms.CheckState.Checked Then
							nCount = nCount + 1
							sDays = sDays & " freq_day" & Trim(Str(nCount)) & " ='" & ckbFreqDay(i).Tag & "',"
						End If
					Next i
					For i = nCount + 1 To 7
						sDays = sDays & " freq_day" & Trim(Str(i)) & " = NULL ,"
					Next i
					
					'MsgBox sDays
					
					sStmt = sStmt & sDays
				End If
				
                sStmt = sStmt & "curr_rate = " & txtCurrRate.Text & ", " & " old_rate = " & txtOldRate.Text & ", " & _
                    " opening_date = '" & dtOpening.Value & "', " & " expiration_date = '" & dtExpiration.Value & "', " & " contract_comments = '" & _
                    quotation_mask(txtContractComments.Text) & "', " & _
                    " freq_comments ='" & quotation_mask(txtFreqComments.Text) & "', " & _
                    " freq_id =" & Str(VB6.GetItemData(cbFreqPeriod, cbFreqPeriod.SelectedIndex)) & "," & _
                    " rate_status = '" & Trim(cbRateStatus.Text) & "'," & " default_service ='" & Trim(sDefaultService) & "'," & _
                    " override_exp_flag ='" & Trim(sOverrideExpFlag) & "'," & " glm_rate = " & txtGlmRate.Text & _
                    " WHERE cust_id = '" & gContractRecord.sCustId & "' " & " AND vend_seq = " & Str(gContractRecord.nVendSeq) & " " & _
                    " AND store_id = " & Str(gContractRecord.nStoreId) & " " & " AND eqpt_seq = " & Str(gContractRecord.nEqptSeq) & " " & _
                    " AND serv_id = " & Str(gContractRecord.nServId)
				'MsgBox sStmt
				cmLocal.CommandText = sStmt
                nRecords = cmLocal.ExecuteNonQuery()
				If nRecords >= 1 Then
					MsgBox("Contract info was successfully updated!.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
					gContractRecord.bFlag = General.modo.SavedRecord
				End If
				
				'cn.CommitTrans
		End Select
		
		Me.Close()
		Exit Sub
		
	End Sub
	'Determina si la llave primaria existe previamente en la tabla
	Private Function duplicated_PK(ByRef sCustId As String, ByRef nStoreId As Short, ByRef nEqptSeq As Short, ByRef nServId As Short, ByRef nVendSeq As Short) As Boolean
		
		Dim bFlag As Boolean
		bFlag = False
        Dim cmd As SqlCommand = cn.CreateCommand
		On Error GoTo ErrorHandler
		
		sStmt = "SELECT cust_id FROM VContract " & " WHERE cust_id = '" & sCustId & "' " & " AND store_id =" & Str(nStoreId) & " AND eqpt_seq = " & Str(nEqptSeq) & " AND serv_id = " & Str(nServId) & " AND vend_seq = " & Str(nVendSeq)
        cmd.CommandText = sStmt
		'MsgBox sStmt
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsLocal.Rows.Count > 0 Then
            'PK repetida
            MsgBox("Insert failed. Another contract for such " & vbCrLf & "vendor/service/equipment already exists.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Error")

            duplicated_PK = True

            Exit Function
        End If
	
        duplicated_PK = bFlag
        Exit Function

ErrorHandler:
        duplicated_PK = False
        save_error(Me.Name, "duplicated_PK")
        MsgBox("An unexpected error has occurred. Check log file for details.")
	End Function
	'Verifica si ya existe un equipo-servicio definido para otro vendor
	Private Function duplicated_eqpt_serv(ByRef sCustId As String, ByRef nStoreId As Short, ByRef nEqptSeq As Short, ByRef nServId As Short, ByRef nVendSeq As Short) As Boolean
		
		duplicated_eqpt_serv = False
		
		On Error GoTo ErrorHandler
		
		sStmt = "SELECT vend_seq FROM VContract " & " WHERE cust_id = '" & sCustId & "' " & " AND store_id =" & Str(nStoreId) & " AND eqpt_seq = " & Str(nEqptSeq) & " AND serv_id = " & Str(nServId)
		
		'MsgBox sStmt
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count > 0 Then
            If rsLocal.Rows(0).Item("vend_seq") <> nVendSeq Then
                'Otro vendor ya provee este servicio
                If (MsgBox("Another Vendor was found for this " & vbCrLf & "service and equipment." & vbCrLf & "Do you still want to create this contract?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "GLM Warning") = MsgBoxResult.No) Then
                    'Usuario decidio no crear otro vendor para este serv-eqpt
                    duplicated_eqpt_serv = True
                    Exit Function
                End If
            End If
        End If


        duplicated_eqpt_serv = False
        Exit Function

ErrorHandler:
        duplicated_eqpt_serv = False
        save_error(Me.Name, "duplicated_eqpt_serv")
        MsgBox("An unexpected error has occurred. Check log file for details.")
	End Function
	'Cuenta cuantos dias estan seleccionados
	Private Function count_days() As Short
		Dim i As Short
		Dim nCount As Short
		
		nCount = 0
		For i = 0 To 6
			If ckbFreqDay(i).CheckState = System.Windows.Forms.CheckState.Checked Then
				nCount = nCount + 1
			End If
		Next i
		count_days = nCount
	End Function
	'Verifica los datos
	Private Function val_fields() As Boolean
		Dim nInactive As Short
		
		On Error GoTo ErrorHandler
		
        If dtOpening.Value > dtExpiration.Value Then
            MsgBox("Expiration date should be greater than Opening date.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Message")
            val_fields = False
            Exit Function
        End If
		
		'Expiration Date
        If dtExpiration.Value = Today Then
            If MsgBox("Expiration date for this contract is today, " & vbCrLf & " Do you still want to continue ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "GLM Warning") = MsgBoxResult.No Then
                val_fields = False
                Exit Function
            End If
        End If
		
		'OldRate
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If Len(txtOldRate.Text) = 0 Or IsDbNull(txtOldRate.Text) Then
			MsgBox("Previous Rate is required.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
			val_fields = False
			Exit Function
		End If
		If CDbl(txtOldRate.Text) = 0 Then
			If (MsgBox("Old Rate is zero, do you still want to continue?. ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "GLM Message") = MsgBoxResult.No) Then
				txtOldRate.Focus()
				val_fields = False
				Exit Function
			End If
		End If
		
		'CurrRate
        If Len(txtCurrRate.Text) = 0 Or IsDBNull(txtCurrRate.Text) Then
            MsgBox("Rate is required.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
            val_fields = False
            Exit Function
        End If
		If CDbl(txtCurrRate.Text) = 0 Then
			If (MsgBox("Rate is zero, do you still want to continue?. ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "GLM Message") = MsgBoxResult.No) Then
				txtCurrRate.Focus()
				val_fields = False
				Exit Function
			End If
		End If
		
		'Glm Rate
		If CDbl(txtGlmRate.Text) = 0 Then
			If (MsgBox("Glm Rate is zero, do you still want to continue?. ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "GLM Message") = MsgBoxResult.No) Then
				txtGlmRate.Focus()
				val_fields = False
				Exit Function
			End If
		End If
		
		'SERVICE
		'If cbFreqPeriod = "Weekly" Or cbFreqPeriod = "Monthly" Then
		'Mapping : FreqSchedFlag= str_field3
		If aFrequency.aRecord(cbFreqPeriod.SelectedIndex).str_field3 = "T" Then
			If count_days = 0 Then
				MsgBox("Please pick service days.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
				val_fields = False
				Exit Function
			End If
		End If
		
		'Mapping : FreqTimesFlag= str_field4
		If aFrequency.aRecord(cbFreqPeriod.SelectedIndex).str_field4 = "T" Then
			If Len(txtFreqTimes.Text) = 0 Then
				MsgBox("Please enter frequency times for this service.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
				val_fields = False
				Exit Function
			End If
			
			If CShort(txtFreqTimes.Text) = 0 Then
				MsgBox("Frequency times should be greater than zero, for this service.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
				val_fields = False
				Exit Function
			End If
		End If
		
		'Rate Status
		If cbRateDesc.SelectedIndex >= 0 Then
			'ok
		Else
			MsgBox("You must Choose Rate Status.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
			val_fields = False
			Exit Function
		End If
		
		'Vendor
		If gContractRecord.bFlag = General.modo.NewRecord Then
			'If txtVendName.Tag > 0 Then
			If cbVendName.SelectedIndex >= 0 Then
				sStmt = "SELECT account_no, account_status" & " FROM VAccountEqpt " & " WHERE cust_id = '" & gContractRecord.sCustId & "' " & " AND store_id = " & Str(gContractRecord.nStoreId) & " " & " AND eqpt_seq = " & Str(VB6.GetItemData(cbEqptDesc, cbEqptDesc.SelectedIndex)) & " " & " AND vend_seq = " & Str(VB6.GetItemData(cbVendName, cbVendName.SelectedIndex)) & " "
				'" AND vend_seq = " + txtVendName.Tag + " "
				
                rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rsLocal.Rows.Count > 0 Then
                    If rsLocal.Rows.Count > 0 Then
                        'OK. Por lo menos una cuenta esta asociada
                        'a este eqpt-vendor. Verifico el estado
                        nInactive = 0
                        For row As Integer = 0 To rsLocal.Rows.Count - 1
                            If rsLocal.Rows(row).Item("account_status") = "A" Then
                                nInactive = -1
                                Exit For
                            End If
                            If rsLocal.Rows(row).Item("account_status") = "I" Then
                                nInactive = nInactive + 1
                            End If
                        Next row
                        

                        Select Case nInactive
                            Case -1
                                'ok
                            Case 0
                                MsgBox("Failed to verify Vendor Account, " & "an unrecognized value was found in Account Status.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                                val_fields = False
                                Exit Function
                            Case Is > 0 'Solo cuentas inactivas se encontraron
                                MsgBox("An Account for such store and vendor was found," & vbCrLf & "but it is currently Inactive. " & vbCrLf & "You can update its status in the Equipment Assignment Menu", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                                val_fields = False
                                Exit Function
                        End Select
                    Else
                        If (MsgBox("There is not Account assigned to this " & "Vendor and Equipment." & vbCrLf & "Do you want to assign a default account N/A?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "GLM Warning") = MsgBoxResult.Yes) Then
                            If insert_AccountEqpt() Then
                                'OK. Se inserto cuenta Default N/A
                            Else
                                MsgBox("Unable to create default account.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                                val_fields = False
                                Exit Function
                            End If
                        Else
                            'No hay cuentas y usuario no quiso crear default
                            val_fields = False
                            Exit Function
                        End If
                    End If ' RecordCount
                Else
                    MsgBox("There was an error while checking Account Info." & vbCrLf & "Try again later.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
                    val_fields = False
                    Exit Function
                End If 'adStateOpen
			Else
				MsgBox("Please select a Vendor to create contract.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Message")
				val_fields = False
				Exit Function
			End If 'txtVendName.tag
		End If
		
		val_fields = True
		Exit Function
		
ErrorHandler: 
		val_fields = False
		save_error(Me.Name, "val_fields")
		MsgBox("An error has ocurred, please check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Function
	'Crea una cuenta por defecto para este vendor-equipment
	Private Function insert_AccountEqpt() As Boolean
		Dim nRecords As Short
		Dim bReturn As Boolean
		Dim bInsertAccount As Boolean
		
		bReturn = False
		
		'VAccount       ********************
		sStmt = "SELECT account_no FROM VAccount " & " WHERE cust_id = '" & gContractRecord.sCustId & "'" & " AND store_id = " & Str(gContractRecord.nStoreId) & " " & " AND vend_seq =" & Str(VB6.GetItemData(cbVendName, cbVendName.SelectedIndex)) & " AND account_no = 'N/A' "
		'" AND vend_seq = " + txtVendName.Tag
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Try
            If rsLocal.Rows.Count = 0 Then
                bInsertAccount = True 'Se requiere insertar en VAccount
            Else
                bInsertAccount = False
            End If
        Catch ex As Exception
            MsgBox("Error while accesing Account Table." & vbCrLf & "Try again later.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
            insert_AccountEqpt = bReturn
            Exit Function
        End Try

        sStmt = "INSERT INTO VAccount " & "(cust_id, store_id, vend_seq, account_no, account_mask )" & " VALUES (" & "'" & gContractRecord.sCustId & "'," & " " & Str(gContractRecord.nStoreId) & " ," & Str(VB6.GetItemData(cbVendName, cbVendName.SelectedIndex)) & ",'N/A','N/A')"
        'txtVendName.Tag + ",'N/A','N/A')"

        If bInsertAccount Then
            'MsgBox sStmt

            cmLocal.CommandText = sStmt
            nRecords = cmLocal.ExecuteNonQuery()
            If nRecords > 0 Then
                'Continue
            Else
                MsgBox("Unable to insert into VAccount table.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                insert_AccountEqpt = bReturn
                Exit Function
            End If
        End If

        'VAccountEqpt    ***************
        sStmt = "INSERT INTO VAccountEqpt " & "(cust_id, store_id," & " account_no, vend_seq, eqpt_seq, account_status) " & " VALUES (" & "'" & gContractRecord.sCustId & "'," & " " & Str(gContractRecord.nStoreId) & ", " & "'N/A'," & Str(VB6.GetItemData(cbVendName, cbVendName.SelectedIndex)) & "," & Str(gContractRecord.nEqptSeq) & ",'A')"
        '"'N/A'," + txtVendName.Tag + "," + _
        ''MsgBox sStmt
        cmLocal.CommandText = sStmt
        nRecords = cmLocal.ExecuteNonQuery()
        If nRecords > 0 Then
            insert_AccountEqpt = True
            Exit Function
        End If

        insert_AccountEqpt = bReturn
        Exit Function

ErrorHandler:
        insert_AccountEqpt = bReturn
        save_error(Me.Name, "insert_AccountEqpt")
    End Function
	Private Sub cmdVendorSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVendorSearch.Click
		gVendorSearch.bFlag = False
		VB6.ShowForm(frmVendorBrowse, VB6.FormShowConstants.Modal, Me)
		If gVendorSearch.bFlag Then
			txtVendName.Text = gVendorSearch.sVendName
			txtVendName.Tag = gVendorSearch.nVendSeq
		End If
	End Sub
	
	Private Sub frmContractEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars(gContractRecord.bFlag)
	End Sub
	
	Private Sub init_vars(ByRef bFlag As General.modo)
		
		On Error GoTo ErrorHandler
		
        rsLocal = Nothing
        cmLocal = cn.CreateCommand
        cmLocal.CommandType = CommandType.Text
		ckbOverrideExpFlag.CheckState = System.Windows.Forms.CheckState.Unchecked
		
		
        'Combo Vendor
        If General.modo.NewRecord = bFlag Then
            sStmt = "SELECT RTRIM(vendor.vend_name)+' - '+vbranch.vend_area , " & " vbranch.vend_seq " & " FROM vbranch,vendor " & " WHERE vbranch.vend_id = vendor.vend_id " & " AND vbranch.vend_seq IN ( " & "   SELECT DISTINCT vend_seq  " & "   FROM VAccountEqpt   " & "   WHERE  VAccountEqpt.cust_id ='" & gContractRecord.sCustId & "' " & "   AND VAccountEqpt.store_id =" & Str(gContractRecord.nStoreId) & "   AND VAccountEqpt.eqpt_seq =" & Str(gContractRecord.nEqptSeq) & "   AND VAccountEqpt.account_status ='A')"
        Else
            sStmt = "SELECT RTRIM(vendor.vend_name)+' - '+vbranch.vend_area , " & " vbranch.vend_seq " & " FROM vbranch,vendor " & " WHERE vbranch.vend_id = vendor.vend_id " & " AND vbranch.vend_seq IN ( " & "   SELECT DISTINCT vend_seq  " & "   FROM VAccountEqpt   " & "   WHERE  VAccountEqpt.cust_id ='" & gContractRecord.sCustId & "' " & "   AND VAccountEqpt.store_id =" & Str(gContractRecord.nStoreId) & "   AND VAccountEqpt.eqpt_seq =" & Str(gContractRecord.nEqptSeq) & " )"
        End If
        'cbVendName.AddItem "<New>", 0
        'cbVendName.ItemData(0) = 0

        load_cb_query2(cbVendName, sStmt, 2, True)


        'Combo Equipment
        sStmt = "SELECT eqpt_desc, eqpt_seq " & " FROM StoreEqpt " & " WHERE cust_id = '" & gContractRecord.sCustId & "' " & " AND store_id = " & Str(gContractRecord.nStoreId) & " "

        load_cb_query(cbEqptDesc, sStmt, 2)

        'Combo Service
        sStmt = "SELECT serv_desc, serv_id " & " FROM service " & " WHERE serv_rate_contract = 'T' " & " ORDER BY serv_desc "

        load_cb_query(cbServDesc, sStmt, 2)


        'Combo Frequency Periods BEGIN
        sStmt = "SELECT freq_name, freq_id " & " FROM frequency " & " ORDER BY freq_name "

        load_cb_query2(cbFreqPeriod, sStmt, 2, True)

        'Mapping
        '   freq_id = int_field1
        '   freq_name = str_field2
        '   freq_sched_flag = str_field3
        '   freq_times_flag =str_field4
        '   freq_acronym = str_field5
        sStmt = "SELECT freq_id, freq_name, freq_desc, " & " freq_sched_flag, freq_times_flag, freq_acronym" & " FROM frequency " & " ORDER BY freq_name "


        load_array_query(aFrequency, sStmt, 1, 5, 0, True)
        '---------------------------END

        'Combo Rate Status
        sStmt = "SELECT rate_desc FROM RateStatus  ORDER BY rate_desc "
        load_cb_query2(cbRateDesc, sStmt, 1, True)

        sStmt = "SELECT rate_status, rate_desc FROM RateStatus  ORDER BY rate_desc "
        load_cb_query2(cbRateStatus, sStmt, 1, True)

        'Default Frequency
        ckbDefaultService.CheckState = System.Windows.Forms.CheckState.Unchecked
        'If a default service was found
        gDump = set_ckb_service(gContractRecord.bFlag, gContractRecord.nServId)
        If gDump.str1 = "T" Then
            'If such service is current contract record
            If gDump.str2 = "T" Then
                ckbDefaultService.CheckState = System.Windows.Forms.CheckState.Checked
                ckbDefaultService.Enabled = True
            Else
                ckbDefaultService.Enabled = False
            End If

        End If

        'Defaults para Insert y Update
        txtCustId.Text = gContractRecord.sCustId
        txtStoreNumber.Text = gContractRecord.sStoreNumber
        txtStoreNumber.Tag = gContractRecord.nStoreId

        Select Case bFlag
            Case General.modo.NewRecord
                If cbServDesc.Items.Count > 0 Then
                    cbServDesc.SelectedIndex = 0
                End If
                If cbEqptDesc.Items.Count > 0 Then
                    cbEqptDesc.SelectedIndex = 0
                End If
                If cbRateDesc.Items.Count > 0 Then
                    cbRateDesc.SelectedIndex = 0
                End If

                If cbVendName.Items.Count > 0 Then
                    cbVendName.SelectedIndex = 0
                End If
                cbEqptDesc.Enabled = True
                cbServDesc.Enabled = True
                cbVendName.Enabled = True


                set_cb_ItemData(cbEqptDesc, gContractRecord.nEqptSeq)

                'load_cb_service_local True     '--jp
                cbFreqPeriod.SelectedIndex = 0

                'dtOpening, dtExpiration
                dtOpening.Value = Today
                dtExpiration.Value = Today

                txtOldRate.Text = CStr(0)
                txtCurrRate.Text = CStr(0)
                txtGlmRate.Text = CStr(0)
                txtVendName.Tag = 0
                txtFreqTimes.Text = CStr(0)
                txtContractComments.Text = ""
                txtFreqComments.Text = ""

            Case General.modo.UpdateRecord
                txtVendName.Text = gContractRecord.sVendor
                txtVendName.Tag = gContractRecord.nVendSeq
                txtVendName.Enabled = False

                cmdVendorSearch.Enabled = False
                cbVendName.Enabled = False
                cbEqptDesc.Enabled = False
                cbServDesc.Enabled = False

                set_cb_ItemData(cbVendName, gContractRecord.nVendSeq)

                set_cb_ItemData(cbEqptDesc, gContractRecord.nEqptSeq)

                set_cb_ItemData(cbServDesc, gContractRecord.nServId)

                set_cb_ItemData(cbFreqPeriod, gContractRecord.nFreqId)

                set_cb(cbRateStatus, gContractRecord.sRateStatus)
                cbRateDesc.SelectedIndex = cbRateStatus.SelectedIndex
                'ancla
                'If Trim(gContractRecord.sFreqTimes) = "O/C" Then
                'Si servicio es Service per Haul solo
                'cargo un elemento en cbFreqPeriod
                '    sStmt = "SELECT serv_period FROM service " + _
                ''        " WHERE serv_id = " + Str(gContractRecord.nServId)

                '    Set rsLocal = exec_sql(sStmt)
                '    If rsLocal.State = adStateOpen Then
                '        If IsNull(rsLocal.item("serv_period")) Then
                '            load_cb_service_local True
                '            enable_service True, False

                '        End If
                '        If Trim(rsLocal.item("serv_period")) = "O/C" Then
                '            load_cb_service_local False
                '            enable_service False, False
                '        End If
                '    End If
                '    cbFreqPeriod.ListIndex = 0
                'Else
                '    load_cb_service_local True
                '    Select Case Trim(gContractRecord.sFreqPeriod)
                '    Case "WK"
                '        cbFreqPeriod.ListIndex = 1
                '    Case "MO"
                '        cbFreqPeriod.ListIndex = 2
                '    End Select
                'End If

                set_service(gContractRecord.sFreqDay1)
                set_service(gContractRecord.sFreqDay2)
                set_service(gContractRecord.sFreqDay3)
                set_service(gContractRecord.sFreqDay4)
                set_service(gContractRecord.sFreqDay5)
                set_service(gContractRecord.sFreqDay6)
                set_service(gContractRecord.sFreqDay7)

                'Opening , Expiration Dates
                dtOpening.Value = gContractRecord.sOpeningDate

                If Len(gContractRecord.sExpirationDate) = 0 Then
                    dtExpiration.Value = Today
                Else
                    dtExpiration.Value = gContractRecord.sExpirationDate
                End If

                txtOldRate.Text = CStr(gContractRecord.nOldRate)
                txtCurrRate.Text = CStr(gContractRecord.nCurrRate)
                txtGlmRate.Text = CStr(gContractRecord.nGlmRate)

                If dtExpiration.Value < Today Then
                    lbExpiration.Font = VB6.FontChangeBold(lbExpiration.Font, True)
                    lbExpiration.ForeColor = System.Drawing.Color.Red
                End If

                txtFreqTimes.Text = gContractRecord.sFreqTimes
                txtContractComments.Text = gContractRecord.sContractComments
                txtFreqComments.Text = gContractRecord.sFreqComments

                If gContractRecord.sDefaultService = "T" Then
                    ckbDefaultService.CheckState = System.Windows.Forms.CheckState.Checked
                End If

                If gContractRecord.sOverrideExpFlag = "YES" Then
                    ckbOverrideExpFlag.CheckState = System.Windows.Forms.CheckState.Checked
                End If

        End Select
        Exit Sub


ErrorHandler:
        save_error(Me.Name, "init_vars")
        MsgBox("An unexpected error has occurred, check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Glm Error")
    End Sub
	'Searches for a default service
	'Return values
	'str1  TRUE    If a record was found as default service
	'str2  TRUE    If current record is the defaultservice
	Private Function set_ckb_service(ByRef bFlag As General.modo, ByRef nServId As Short) As gDumpUDT
		
		set_ckb_service.str1 = "F"
		set_ckb_service.str2 = "F"
		
		If bFlag = General.modo.NewRecord Then
			set_ckb_service.str2 = "F" 'This will never be when record is new
			'Exit Function
		End If
		
		On Error GoTo ErrorHandler
		
		'Find if there is another service set as default
		sStmt = "SELECT serv_id FROM vcontract " & " WHERE cust_id='" & gContractRecord.sCustId & "' " & " AND vend_seq =" & Str(gContractRecord.nVendSeq) & " " & " AND store_id =" & Str(gContractRecord.nStoreId) & " " & " AND eqpt_seq =" & Str(gContractRecord.nEqptSeq) & " " & " AND default_service='T'"
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count > 0 Then
            set_ckb_service.str1 = "T"
            If rsLocal.Rows(0).Item("serv_id") = nServId Then
                set_ckb_service.str2 = "T"
            End If
        End If

        Exit Function

ErrorHandler:
        save_error(Me.Name, "set_ckb_service")
	End Function
	'Carga el combo de service Period
	Private Sub load_cb_service_local(ByRef bFrequency As Boolean)
		
		If bFrequency Then
			cbFreqPeriod.Items.Insert(0, "On Call")
			cbFreqPeriod.Items.Insert(1, "Weekly")
			cbFreqPeriod.Items.Insert(2, "Monthly")
		Else
			'No hay frecuencia definida.
			cbFreqPeriod.Items.Insert(0, "On Call")
		End If
		
	End Sub
	'Habilita/Deshabilita los Checkbox de los dias
	Private Sub enable_service(ByRef bFreqSchedFlag As Boolean, ByRef bFreqTimesFlag As Boolean)
		Dim i As Short
		
		
		'cbFreqPeriod.Enabled = bFreqPeriod
		If bFreqTimesFlag = False Then
			txtFreqTimes.Text = CStr(0)
		End If
		
		txtFreqTimes.Enabled = bFreqTimesFlag
        'udFreqTimes.Enabled = bFreqTimesFlag
		
		For i = 0 To 6
			ckbFreqDay(i).Enabled = bFreqSchedFlag
			
			ckbFreqDay(i).CheckState = System.Windows.Forms.CheckState.Unchecked
		Next i
		
	End Sub
	
	Private Sub set_service(ByRef sFreqDay As String)
		
		Select Case sFreqDay
			Case "M"
				ckbFreqDay(0).CheckState = System.Windows.Forms.CheckState.Checked
			Case "T"
				ckbFreqDay(1).CheckState = System.Windows.Forms.CheckState.Checked
			Case "W"
				ckbFreqDay(2).CheckState = System.Windows.Forms.CheckState.Checked
			Case "R"
				ckbFreqDay(3).CheckState = System.Windows.Forms.CheckState.Checked
			Case "F"
				ckbFreqDay(4).CheckState = System.Windows.Forms.CheckState.Checked
			Case "S"
				ckbFreqDay(5).CheckState = System.Windows.Forms.CheckState.Checked
			Case "D"
				ckbFreqDay(6).CheckState = System.Windows.Forms.CheckState.Checked
		End Select
		
	End Sub
	
	Private Sub txtCurrRate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCurrRate.KeyPress
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
			''And max_fraction(txtcurrRate) _
			''And txtcurrRate.SelLength = 0 Then
			'    KeyAscii = 0
			'End If
		Else
			nPos = InStr(1, txtCurrRate.Text, ".", CompareMethod.Text)
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
	
    Private Sub txtFreqTimes_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Then
            'Es numero
        Else
            KeyAscii = 0
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
	Private Sub txtOldRate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtOldRate.KeyPress
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
			''And max_fraction(txtoldrate) _
			''And txtoldrate.SelLength = 0 Then
			'    KeyAscii = 0
			'End If
		Else
			nPos = InStr(1, txtOldRate.Text, ".", CompareMethod.Text)
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

    Private Sub fmService_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fmService.Enter

    End Sub
End Class