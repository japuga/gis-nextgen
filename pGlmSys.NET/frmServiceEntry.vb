Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmServiceEntry
	Inherits System.Windows.Forms.Form
	
	'UPGRADE_WARNING: Event cbServEqpt.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbServEqpt_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbServEqpt.SelectedIndexChanged
		cbServRateContract.SelectedIndex = cbServEqpt.SelectedIndex
	End Sub
	
	'UPGRADE_WARNING: Event cbServUnitDesc.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbServUnitDesc_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbServUnitDesc.SelectedIndexChanged
		cbServMeasureUnit.SelectedIndex = cbServUnitDesc.SelectedIndex
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If val_fields Then
			If save_service(gServiceRecord.bFlag) Then
				Me.Close()
			End If
		End If
		
	End Sub
	'Validar datos
	Private Function val_fields() As Boolean
		
		On Error GoTo ErrorHandler
		
		val_fields = True
		
		If Len(txtServDesc.Text) = 0 Then
			MsgBox("Please enter the Service Name.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
			val_fields = False
			txtServDesc.Focus()
			Exit Function
		Else
			'Verifica que el servicio no este repetido
			sStmt = "SELECT serv_id FROM service " & " WHERE LTRIM(RTRIM(serv_desc)) ='" & Trim(txtServDesc.Text) & "'"
			
            rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rs.Rows.Count > 0 Then
                Select Case gServiceRecord.bFlag
                    Case General.modo.NewRecord
                        MsgBox("There is another service " & "with the same name.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Message")
                        txtServDesc.Focus()
                        val_fields = False
                        Exit Function
                    Case General.modo.UpdateRecord
                        If rs.Rows(0).Item("serv_id") = gServiceRecord.serv_id Then
                            'ok
                        Else
                            MsgBox("There is another service " & "with the same name.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Message")
                            txtServDesc.Focus()
                            val_fields = False
                            Exit Function
                        End If
                End Select
            End If
        End If

		
		'Credit
		If cbServCredit.SelectedIndex < 0 Then
			MsgBox("Please choose the Service Invoice Behavior.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "Glm Message")
			cbServCredit.Focus()
			val_fields = False
			Exit Function
		End If
		
		'Measure Unit
		If cbServMeasureUnit.SelectedIndex < 0 Then
			MsgBox("Please choose the Service Measure Unit.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "Glm Message")
			cbServMeasureUnit.Focus()
			val_fields = False
			Exit Function
		End If
		
		'Class
		If cbServClass.SelectedIndex < 0 Then
			MsgBox("Please choose the Service Class.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "Glm Message")
			cbServClass.Focus()
			val_fields = False
			Exit Function
		End If
		
		'Frequency
		If cbServFrequency.SelectedIndex < 0 Then
			MsgBox("Please choose the Service Frequency.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "Glm Message")
			cbServFrequency.Focus()
			val_fields = False
			Exit Function
		End If
		
		'Equipment
		If cbServEqpt.SelectedIndex < 0 Then
			MsgBox("Equipment required flag must be set.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "Glm Message")
			cbServEqpt.Focus()
			val_fields = False
			Exit Function
		End If
		
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "val_fields")
		MsgBox("Failed to check service info. Review log file for details.", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "GLM Error")
		
	End Function
	
	'Guarda registro en tabla service
	Private Function save_service(ByRef sOption As General.modo) As Boolean
        Dim nServId As Short = -1
        Dim sServCredit As String = ""
        Dim nRecords As Short = -1
		
		save_service = False
		nServId = -1
		
		Select Case cbServCredit.Text
			Case "Debit"
				sServCredit = "F"
			Case "Credit"
				sServCredit = "T"
		End Select
		
		
        cm = cn.CreateCommand() '.let_ActiveConnection()
        cm.CommandType = CommandType.Text
		
		Select Case sOption
			Case General.modo.NewRecord
				'Obtiene el numero del servicio
				sStmt = "SELECT MAX(serv_id) FROM service"
				
                rs = getDataTable(sStmt) ' .Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                If rs.Rows.Count > 0 Then
                    'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    If IsDBNull(rs.Rows(0).Item(0)) Then
                        nServId = 1
                    Else
                        nServId = rs.Rows(0).Item(0) + 1
                    End If
                Else
                    nServId = 1
                End If


                sStmt = "INSERT INTO service (serv_id, " & "serv_desc, serv_eqpt, serv_credit, " & "serv_rate_contract, " & "unit_desc, serv_measure_unit, " & "serv_class, serv_class_id, " & "serv_frequency, serv_id_conversion) " & "VALUES (" & Str(nServId) & "," & "'" & Trim(quotation_mask(txtServDesc.Text)) & "'," & "dbo.convert_yn_2_bool('" & cbServEqpt.Text & "')," & "'" & sServCredit & "'," & "dbo.convert_yn_2_bool('" & cbServRateContract.Text & "')," & "'" & Trim(cbServUnitDesc.Text) & "'," & "'" & Trim(cbServMeasureUnit.Text) & "'," & "'" & Trim(cbServClass.Text) & "'," & "'" & VB.Left(cbServClass.Text, 1) & "'," & "'" & UCase(VB.Left(cbServFrequency.Text, 1)) & "'," & Str(VB6.GetItemData(cbServDescConversion, cbServDescConversion.SelectedIndex)) & ")"

                'MsgBox sStmt
                cm.CommandText = sStmt
                nRecords = cm.ExecuteNonQuery()
                If nRecords > 0 Then
                    'ok
                    gServiceRecord.serv_id = nServId
                    gServiceRecord.bFlag = General.modo.SavedRecord
                    save_service = True
                Else
                    save_service = False
                    MsgBox("Failed to insert into Service table." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Function
                End If
            Case General.modo.UpdateRecord

                sStmt = "UPDATE service SET " & " serv_desc ='" & Trim(quotation_mask(txtServDesc.Text)) & "'," & " serv_eqpt = " & "dbo.convert_yn_2_bool('" & cbServEqpt.Text & "')," & " serv_credit ='" & sServCredit & "'," & " serv_rate_contract = " & "dbo.convert_yn_2_bool('" & cbServRateContract.Text & "')," & " unit_desc ='" & Trim(cbServUnitDesc.Text) & "'," & " serv_measure_unit ='" & Trim(cbServMeasureUnit.Text) & "'," & " serv_class ='" & Trim(cbServClass.Text) & "'," & " serv_class_id ='" & VB.Left(cbServClass.Text, 1) & "'," & " serv_frequency =" & "'" & UCase(VB.Left(cbServFrequency.Text, 1)) & "'," & " serv_id_conversion = " & Str(VB6.GetItemData(cbServDescConversion, cbServDescConversion.SelectedIndex)) & " WHERE serv_id =" & Str(gServiceRecord.serv_id)

                'MsgBox sStmt

                cm.CommandText = sStmt
                nRecords = cm.ExecuteNonQuery()
                If nRecords > 0 Then
                    'ok
                    gServiceRecord.bFlag = General.modo.SavedRecord
                    save_service = True
                Else
                    save_service = False
                    MsgBox("Failed to update Service table." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Function
                End If

        End Select
		Exit Function
		
ErrorHandler: 
		save_service = False
		save_error(Me.Name, "save_service")
		MsgBox("An unexpected error occurred while saving Service data." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Function
	Private Sub frmServiceEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		set_limits()
		init_vars()
	End Sub
	Private Sub set_limits()
		'UPGRADE_WARNING: TextBox property txtServDesc.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtServDesc.Maxlength = 40
	End Sub
	Private Sub init_vars()
		cb_init(cbServEqpt)
		cb_init(cbServRateContract)
		cb_init(cbServFrequency)
        'Credit
        cbServCredit.Items.Clear()
		cbServCredit.Items.Insert(0, "Debit")
		cbServCredit.Items.Insert(1, "Credit")
		'Measure Units
		sStmt = "SELECT ServUnit.serv_unit_desc, " & "ServUnit.serv_measure_unit " & " FROM ServUnit " & " ORDER BY serv_unit_desc"
		load_cb_query2(cbServUnitDesc, sStmt, 1, True)
		
		sStmt = "SELECT ServUnit.serv_measure_unit, " & "ServUnit.serv_unit_desc " & " FROM ServUnit " & " ORDER BY serv_unit_desc"
		load_cb_query2(cbServMeasureUnit, sStmt, 1, True)
		'Class
		'cbServClass.AddItem "REGULAR", 0
		'cbServClass.AddItem "EXCEPTION", 1
		sStmt = "SELECT serv_class FROM ServClass " & " ORDER BY serv_class"
		load_cb_query2(cbServClass, sStmt, 1, True)


        cbServDescConversion.Items.Clear()
		cbServDescConversion.Items.Insert(0, "<None>")
		VB6.SetItemData(cbServDescConversion, 0, 0)
		sStmt = " SELECT serv_desc, serv_id FROM service " & " ORDER BY serv_desc "
		load_cb_query2(cbServDescConversion, sStmt, 2, False)
		'Defaults
		
		Select Case gServiceRecord.bFlag
			Case General.modo.NewRecord
				cbServEqpt.SelectedIndex = 1
				cbServCredit.SelectedIndex = 0
				cbServFrequency.SelectedIndex = 1
				cbServClass.SelectedIndex = 0
				cbServDescConversion.SelectedIndex = 0
				
				If cbServUnitDesc.Items.Count > 0 Then
					cbServUnitDesc.SelectedIndex = 0
				End If
				
			Case General.modo.UpdateRecord
				txtServDesc.Text = gServiceRecord.serv_desc
				
				If gServiceRecord.serv_eqpt = "Yes" Then
					cbServEqpt.SelectedIndex = 0
				Else
					cbServEqpt.SelectedIndex = 1
				End If
				
				If gServiceRecord.serv_credit = "Yes" Then
					cbServCredit.SelectedIndex = 1
				Else
					cbServCredit.SelectedIndex = 0
				End If
				
				If gServiceRecord.serv_frequency = "Yes" Then
					cbServFrequency.SelectedIndex = 0
				Else
					cbServFrequency.SelectedIndex = 1
				End If
				
				set_cb(cbServClass, gServiceRecord.serv_class)
				set_cb(cbServMeasureUnit, gServiceRecord.serv_measure_unit)
				set_cb(cbServUnitDesc, Trim(gServiceRecord.unit_desc))
				set_cb_ItemData(cbServDescConversion, gServiceRecord.serv_id_conversion)
		End Select
		
		
		
	End Sub
	
	Private Sub cb_init(ByRef cb As System.Windows.Forms.ComboBox)
        cb.Items.Clear()
        cb.Items.Insert(0, "Yes")
		cb.Items.Insert(1, "No")
		
		
	End Sub
End Class