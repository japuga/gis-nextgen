Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmCustFeeEntry
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private cmLocal As SqlCommand
	Private bPercentFlag As Boolean
	Private nLocalFeeId As Short
	Private bPreviousFlag As General.modo
	

	Private Sub cbFeeDesc_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbFeeDesc.SelectedIndexChanged
		'Options button just available for Savings Service Fee
		'or Billing range Fee
		'If Trim(cbFeeDesc) = "Savings Service Fee" Or _
		''   Trim(cbFeeDesc) = "Billing Range Fee"
        Dim cmd As SqlCommand = cn.CreateCommand()
		If Trim(cbFeeDesc.Text) = "Savings Service Fee" Or isFeeRange(Trim(cbFeeDesc.Text)) Then
			cmdOptions.Enabled = True
		Else
			cmdOptions.Enabled = False
		End If
		
		sStmt = "SELECT percent_flag FROM FeeType " & "WHERE fee_type_id = " & Str(VB6.GetItemData(cbFeeDesc, cbFeeDesc.SelectedIndex))
        cmd.CommandText = sStmt
		
        rsLocal = getDataTable(sStmt) ' cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count > 0 Then
            If rsLocal.Rows(0).Item("percent_flag") = "T" Then
                bPercentFlag = True
            Else
                bPercentFlag = False
            End If
        End If

		
    End Sub

    Private Sub setOptionsButton()
        If Trim(cbFeeDesc.Text) = "Savings Service Fee" Or isFeeRange(Trim(cbFeeDesc.Text)) Then
            cmdOptions.Enabled = True
        Else
            cmdOptions.Enabled = False
        End If
    End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Dim nRecords As Short
        Dim cmd As SqlCommand = cn.CreateCommand()
        Dim tmpDt As DataTable
		'User cancelled action, so we remove this Fee
		If bPreviousFlag = General.modo.NewRecord And Trim(cbFeeDesc.Text) = "Billing Range Fee" Then
			'Delete from Fee and FeeBillingRange
            'check if it exists first
            sStmt = "SELECT * FROM FeeBillingRange " & " WHERE fee_id=" & Str(nLocalFeeId)
            tmpDt = getDataTable(sStmt)
            If tmpDt.Rows.Count > 0 Then
                sStmt = "DELETE FROM FeeBillingRange " & " WHERE fee_id=" & Str(nLocalFeeId)
                cmd.CommandText = sStmt
                nRecords = cm.ExecuteNonQuery()

                'Delete from Fee
                sStmt = "DELETE FROM Fee " & " WHERE fee_id=" & Str(nLocalFeeId)
                cmd.CommandText = sStmt
                nRecords = cmd.ExecuteNonQuery()

                If nRecords > 0 Then
                    'ok
                Else
                    MsgBox("Error occurred while removing temporary Fee data." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                End If
            End If
        End If

		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If val_fields = False Then
			Exit Sub
		End If
		
		If save_fee = True Then
			Me.Close()
		End If
		
	End Sub
	Private Function val_fields() As Boolean
		'Fee
		If cbFeeDesc.SelectedIndex < 0 Then
			MsgBox("Pick which Fee do you want to add.", MsgBoxStyle.OKOnly, "GLM Message")
			val_fields = False
			Exit Function
		End If
		
		'Value
		If Not IsNumeric(txtFeeValue.Text) Then
			MsgBox("Incorrect value was entered", MsgBoxStyle.OKOnly, "GLM Message")
			txtFeeValue.Focus()
			val_fields = False
			Exit Function
		Else
			If bPercentFlag Then
				If CDbl(txtFeeValue.Text) > 100 Then
					MsgBox("This is a percent field, it can not be" & vbCrLf & " greater than 100.")
					txtFeeValue.Focus()
					Exit Function
				End If
			End If
		End If
		
		'Details. Esto se debe cambiar a FeeType.allow_details_flag
		'si otras tarifas ademas de Savings Service Fee
		' se definen para uno o mas servicios, tiendas, etc.
		If Trim(cbFeeDesc.Text) = "Savings Service Fee" Then
			If gItplGridSelector.bFlag Then
                If gItplGridSelector.rsResult.Rows.Count > 0 Then
                    Dim dr As DataTable = gItplGridSelector.rsResult
                    Dim rcrdCount As Integer = dr.Rows.Count

                    If rcrdCount <= 0 Then
                        MsgBox("Select one or more Services by clicking Options button.")
                        cmdOptions.Focus()
                        Exit Function
                    Else
                        'ok
                    End If
                Else
                    cmdOptions.Focus()
                    MsgBox("Please select one or more Services by clicking Options button.")
                    Exit Function
                End If
			Else
				'Carga el recordset cuando al actualizar el usuarion
				'no presiono el boton Options
				If gCustFeeRecord.bFlag = General.modo.UpdateRecord Then
					If Not load_rsResult Then
						Exit Function
					End If
				Else
					cmdOptions.Focus()
					MsgBox("Please select one or more Services by clicking Options button.")
					Exit Function
				End If
			End If
		End If
		
		val_fields = True
	End Function
	Private Function load_rsResult() As Boolean
		
		load_rsResult = False
		sStmt = build_query_right
        Dim cmd As SqlCommand = cn.CreateCommand()
        cmd.CommandText = sStmt
        gItplGridSelector.rsResult = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If gItplGridSelector.rsResult.Rows.Count > 0 Then
            'ok
            load_rsResult = True
        Else
            MsgBox("Failed to load Fee Details. " & vbCrLf & "Check log file for details", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Function
        End If
		Exit Function
		
		
		
	End Function
	Private Function save_fee() As Boolean
		Dim nFeeId As Short
		Dim sActiveFlag As String
		Dim nRecords As Short
        Dim nTran As SqlTransaction
		Dim nServId As Short
        Dim ds As DataSet = New DataSet("tmpDataSet")
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim cmd As SqlCommand = cn.CreateCommand()
        Dim dt As DataTable

		
		'FeeID
		nFeeId = 0
		nServId = 0
		'ActiveFlag
		If ckActive.CheckState = System.Windows.Forms.CheckState.Checked Then
			sActiveFlag = "T"
		Else
			sActiveFlag = "F"
		End If
		
        nTran = cn.BeginTransaction()
		
		Select Case gCustFeeRecord.bFlag
			Case General.modo.NewRecord
                sStmt = "SELECT MAX(fee_id) FROM fee "
                dt = getDataTable(sStmt, nTran)
                'cmd.CommandText = sStmt
                'cmd.Transaction = nTran
                'da.SelectCommand = cmd
                Try
                    'da.Fill(ds)
                    'rsLocal.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                    'If rsLocal.RecordCount = 0 Or IsDBNull(rsLocal.Fields(0)) Then
                    If dt.Rows.Count = 0 Or IsDBNull(dt.Rows(0).Item(0)) Then
                        nFeeId = 1
                    Else
                        nFeeId = dt.Rows(0).Item(0) + 1
                    End If
                Catch e As Exception
                    nTran.Rollback()

                    save_error(Me.Name, "save_fee")
                    MsgBox("Unable to get Fee Identifier, try again.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Message")
                    save_fee = False
                    Exit Function
                End Try


                sStmt = "INSERT INTO fee (fee_id, cust_id, " & " active_flag, fee_value, fee_type_id) " & " VALUES (" & Str(nFeeId) & ",'" & Trim(gCustFeeRecord.sCustId) & "'," & "'" & sActiveFlag & "'," & txtFeeValue.Text & "," & Str(VB6.GetItemData(cbFeeDesc, cbFeeDesc.SelectedIndex)) & ")"

                cmLocal.CommandText = sStmt
                cmLocal.Transaction = nTran
                nRecords = cmLocal.ExecuteNonQuery()
                If nRecords > 0 Then
                    'ok
                    nLocalFeeId = nFeeId
                Else
                    nTran.Rollback()

                    MsgBox("Failed to insert into Fee table." & vbCrLf & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
                    save_fee = False
                    Exit Function
                End If


            Case General.modo.UpdateRecord
                nFeeId = gCustFeeRecord.nFeeId

                sStmt = "UPDATE Fee " & " SET fee_value = " & txtFeeValue.Text & "," & "  active_flag ='" & Trim(sActiveFlag) & "'" & " WHERE fee_id =" & Str(gCustFeeRecord.nFeeId)

                cmLocal.CommandText = sStmt
                cmLocal.Transaction = nTran
                nRecords = cmLocal.ExecuteNonQuery()
                If nRecords > 0 Then
                    'ok

                Else
                    nTran.Rollback()
                    MsgBox("Failed to update into Fee table." & vbCrLf & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
                    save_fee = False
                    Exit Function
                End If
        End Select
		
		
		If Trim(cbFeeDesc.Text) = "Savings Service Fee" Then
			'Check for details
            sStmt = "DELETE FROM FeeService " & " WHERE fee_id =" & Str(nFeeId)
            cmd.CommandText = sStmt
            cmd.Transaction = nTran
            nRecords = cmd.ExecuteNonQuery()
            For row As Integer = 0 To gItplGridSelector.rsResult.Rows.Count - 1
                nServId = gItplGridSelector.rsResult.Rows(row).Item("serv_id")

                sStmt = " INSERT INTO FeeService (fee_id, serv_id) " & " VALUES (" & Str(nFeeId) & "," & Str(nServId) & ")"
                cmd.CommandText = sStmt
                cmd.Transaction = nTran
                nRecords = cmd.ExecuteNonQuery()
                If nRecords <= 0 Then
                    nTran.Rollback()
                    save_fee = False
                    Exit Function
                End If
            Next
            
        End If
		
        nTran.Commit()
		
		gCustFeeRecord.bFlag = General.modo.SavedRecord
		save_fee = True
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "save_fee")

        nTran.Rollback()


        MsgBox("Unexpected error occurred while saving Fee information.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
	End Function
	
	
	Private Sub cmdOptions_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOptions.Click
		If Trim(cbFeeDesc.Text) = "Savings Service Fee" Then
			set_grid_selector()
			VB6.ShowForm(tplGridSelector, VB6.FormShowConstants.Modal, Me)
		End If
		
		'If Trim(cbFeeDesc) = "Billing Range Fee"  Then
		If isFeeRange(Trim(cbFeeDesc.Text)) Then
			Select Case gCustFeeRecord.bFlag
				Case General.modo.NewRecord
					'Save record to obtain fee_id
					If save_fee Then
						gFeeBillingRange.nFeeId = nLocalFeeId
					Else
						Exit Sub
					End If
				Case General.modo.UpdateRecord
					gFeeBillingRange.nFeeId = gCustFeeRecord.nFeeId
			End Select
			gFeeBillingRange.sCustId = Trim(gCustFeeRecord.sCustId)
			VB6.ShowForm(frmCustFeeBillRange, VB6.FormShowConstants.Modal, Me)
		End If
	End Sub
	
	
	Private Sub set_grid_selector()
		
		clear_gItplGridSelector()
		
		'Init
		gItplGridSelector.sQueryInit = build_query_init
		'Left
		gItplGridSelector.sQuerySource = build_query_left
		
		'Right
		gItplGridSelector.sQuerySelected = build_query_right
		
		gItplGridSelector.sOrderBy = "Name"
		
		
		'Formato
		gItplGridSelector.aFields(0).sFieldName = "serv_id"
		gItplGridSelector.aFields(0).bVisible = False
		gItplGridSelector.aFields(0).nWidth = 100
		
		gItplGridSelector.aFields(1).sFieldName = "Name"
		gItplGridSelector.aFields(1).bVisible = True
		gItplGridSelector.aFields(1).nWidth = 3000
		
		gItplGridSelector.sLeftCaption = "Services"
		gItplGridSelector.sRightCaption = "Selected Services"
		
		
	End Sub
	Private Function build_query_left() As String
		build_query_left = " SELECT serv_id, serv_desc AS Name " & " FROM service " & " WHERE serv_rate_contract ='T' " & " AND serv_id NOT IN " & " (SELECT serv_id FROM FeeService, Fee  " & "  WHERE Fee.fee_id = FeeService.fee_id " & "  AND Fee.cust_id = '" & gCustFeeRecord.sCustId & "'" & "  AND Fee.fee_type_id= " & Str(VB6.GetItemData(cbFeeDesc, cbFeeDesc.SelectedIndex)) & ")" & " ORDER BY serv_desc "
		
	End Function
	Private Function build_query_right() As String
		build_query_right = " SELECT FeeService.serv_id, " & " Service.serv_desc AS Name " & " FROM FeeService, Fee, Service  " & " WHERE Fee.fee_id = FeeService.fee_id " & " AND Fee.cust_id = '" & gCustFeeRecord.sCustId & "'" & " AND Service.serv_id = FeeService.serv_id " & " AND Fee.fee_type_id= " & Str(VB6.GetItemData(cbFeeDesc, cbFeeDesc.SelectedIndex)) & " ORDER BY serv_desc "
		
	End Function
	Private Function build_query_init() As String
		build_query_init = " SELECT FeeService.serv_id, " & " Service.serv_desc AS Name " & " FROM FeeService, Fee, Service  " & " WHERE Fee.fee_id = FeeService.fee_id " & " AND Fee.cust_id = ''" & " AND Service.serv_id = FeeService.serv_id " & " AND Fee.fee_type_id= " & Str(VB6.GetItemData(cbFeeDesc, cbFeeDesc.SelectedIndex))
		
		
	End Function
	Private Sub frmCustFeeEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		
        cmLocal = cn.CreateCommand
		
		cmdOptions.Enabled = False
		clear_gItplGridSelector()
		
		bPercentFlag = False
		With cmLocal
            .CommandType = CommandType.Text
		End With
		
        txtFeeValue.MaxLength = 5
		nLocalFeeId = 0
		bPreviousFlag = gCustFeeRecord.bFlag
		
		Select Case gCustFeeRecord.bFlag
			Case General.modo.NewRecord
				
				sStmt = "SELECT fee_desc, fee_type_id " & " FROM FeeType " & " WHERE fee_type_id NOT IN (SELECT fee_type_id " & "    FROM fee " & "    WHERE cust_id = '" & Trim(gCustFeeRecord.sCustId) & "')" & " ORDER BY fee_desc "
				
				load_cb_query2(cbFeeDesc, sStmt, 2, True)
				If cbFeeDesc.Items.Count > 0 Then
					cbFeeDesc.SelectedIndex = 0
				End If
                cbFeeDesc.Enabled = True

				ckActive.CheckState = System.Windows.Forms.CheckState.Checked
				txtFeeValue.Text = CStr(0)
			Case General.modo.UpdateRecord
				cbFeeDesc.Items.Insert(0, gCustFeeRecord.sFeeDesc)
                VB6.SetItemData(cbFeeDesc, 0, gCustFeeRecord.nFeeTypeId)
                setOptionsButton()
				cbFeeDesc.SelectedIndex = 0
				cbFeeDesc.Enabled = False
				
				txtFeeValue.Text = CStr(gCustFeeRecord.nFeeValue)
				
				If gCustFeeRecord.sFeeActive = "Yes" Then
					ckActive.CheckState = System.Windows.Forms.CheckState.Checked
				Else
					ckActive.CheckState = System.Windows.Forms.CheckState.Unchecked
				End If
				
		End Select
	End Sub
	
	Private Sub txtFeeValue_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFeeValue.KeyPress
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
			nPos = InStr(1, txtFeeValue.Text, ".", CompareMethod.Text)
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