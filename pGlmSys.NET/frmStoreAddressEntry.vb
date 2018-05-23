Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmStoreAddressEntry
    Inherits System.Windows.Forms.Form
    'Private ImageList2 As New ImageList()
	
	
	Private Sub frmStoreAddressEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		
		txtCustId.Enabled = False
		txtCustName.Enabled = False
		txtStoreNo.Enabled = False
		
		'txtCustName.Text = gStoreAddressRecord.sCustName
		'txtCustId.Text = gStoreAddressRecord.sCustId
		'txtStoreNo.Text = gStoreAddressRecord.sStoreNumber
		
		txtCustName.Text = gStoreAddress.sCustName
		txtCustId.Text = gStoreAddress.sCustId
		txtStoreNo.Text = gStoreAddress.sStoreNumber
		

        txtAddress.MaxLength = IIf(get_column(TABLE_ADDRESS_CATALOG, ADDRESS_CATALOG_ADDRESS) < 1, 0, get_column(TABLE_ADDRESS_CATALOG, ADDRESS_CATALOG_ADDRESS))
        If txtAddress.MaxLength = 0 Then
            txtAddress.MaxLength = 80
        End If
		
        txtCity.MaxLength = IIf(get_column(TABLE_ADDRESS_CATALOG, ADDRESS_CATALOG_CITY) < 1, 0, get_column(TABLE_ADDRESS_CATALOG, ADDRESS_CATALOG_CITY))
        If txtCity.MaxLength = 0 Then
            txtCity.MaxLength = 40
        End If
		
        txtZip.MaxLength = IIf(get_column(TABLE_ADDRESS_CATALOG, ADDRESS_CATALOG_ZIP) < 1, 0, get_column(TABLE_ADDRESS_CATALOG, ADDRESS_CATALOG_ZIP))
        If txtZip.MaxLength = 0 Then
            txtZip.MaxLength = 20
        End If

		'cbState
		sStmt = "SELECT state_id FROM state ORDER BY state_id"
		load_cb_query2(cbState, sStmt, 1, True)
		If cbState.Items.Count > 0 Then
			cbState.SelectedIndex = 0
		End If
		
		
		Select Case gStoreAddress.bFlag
			Case General.modo.UpdateRecord
				Me.txtAddress.Text = gStoreAddress.sAddress
				Me.txtCity.Text = gStoreAddress.sCity
				Me.txtZip.Text = gStoreAddress.sZip
				set_cb((Me.cbState), gStoreAddress.sState)
            Case modo.NewRecord
                Me.txtAddress.Text = ""
                Me.txtCity.Text = ""
                Me.txtZip.Text = ""
        End Select
		
	End Sub
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "save"
                If val_fields() Then
                    If save_record() Then
                        Me.Close()
                    End If

                End If
            Case "exit"
                Me.Close()
        End Select

    End Sub
	Private Function val_fields() As Boolean
		val_fields = False
		
		'CustId, CustName
		If Len(Trim(txtCustId.Text)) = 0 Or Len(Trim(txtCustName.Text)) = 0 Then
			MsgBox("Please select a customer before attempting this action.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtCustName.Focus()
			Exit Function
		End If
		
		
		'Store
		If Len(Trim(txtStoreNo.Text)) = 0 Then
			MsgBox("Please select a Store before attempting this action.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtStoreNo.Focus()
			Exit Function
		End If
		
		'Address
		If Len(Trim(txtAddress.Text)) = 0 Then
			MsgBox("Please enter an Address before attempting this action.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtAddress.Focus()
			Exit Function
		End If
		
		'City
		If Len(Trim(txtCity.Text)) = 0 Then
			MsgBox("Please enter a City before attempting this action.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtCity.Focus()
			Exit Function
		End If
		
		'State
		If cbState.SelectedIndex < 0 Then
			MsgBox("Please select a State before attempting this action.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			cbState.Focus()
			Exit Function
		End If
		
		'Zip
		If Len(Trim(txtZip.Text)) = 0 Then
			MsgBox("Please enter a Zip Code before attempting this action.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			txtZip.Focus()
			Exit Function
		End If
		
		
		val_fields = True
		Exit Function
		
	End Function
	
	Private Function save_record() As Boolean
		Dim nRecords As Short
        'Dim nDbTran As Short
        Dim cmLocal As sqlcommand
        'Dim nAddressSeq As Short
		Dim nStoreAddressSeq As Short
		
		save_record = False
		
		Select Case gStoreAddress.bFlag
            Case General.modo.NewRecord
                nStoreAddressSeq = insertAddressCatalog((txtCustId.Text), gStoreAddress.nStoreId, (txtAddress.Text), (txtCity.Text), (cbState.Text), (txtZip.Text))
                If nStoreAddressSeq > 0 Then
                    save_record = True

                    'load global record to return with new PK
                    set_address_record(nStoreAddressSeq)

                    MsgBox("Address was successfullty saved.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                    Exit Function

                Else
                    MsgBox("Failed to insert Store-Address reference.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                    Exit Function
                End If


                'nAddressSeq = get_table_sequence("address_catalog", "address_seq")

                'nStoreAddressSeq = get_table_sequence("store_address", "store_address_seq")

                'sStmt = "INSERT INTO address_catalog (address_seq, context_table, address, " + _
                ''    "   city, state_id, zip) " + _
                ''    " VALUES (?, ?, ?, ?, ?, ?) "

                'nDbTran = cn.BeginTransaction()

                'Set cmLocal = New ADODB.Command

                'create_param_rs "address_seq", adInteger, adParamInput, nAddressSeq, cmLocal, 4
                'create_param_rs "context_table", adVarChar, adParamInput, ADDRESS_CATALOG_CONTEXT_STORE, cmLocal, 100
                'create_param_rs "address", adVarChar, adParamInput, quotation_mask(Trim(txtAddress.Text)), cmLocal, 80
                'create_param_rs "city", adVarChar, adParamInput, quotation_mask(Trim(txtCity.Text)), cmLocal, 40
                'create_param_rs "state_id", adChar, adParamInput, cbState.Text, cmLocal, 2
                'create_param_rs "zip", adVarChar, adParamInput, txtZip.Text, cmLocal, 20



                'cmLocal.ActiveConnection = cn
                'cmLocal.CommandType = adCmdText
                'cmLocal.CommandText = sStmt

                'cmLocal.Execute nRecords
                'If nRecords > 0 Then

                '    sStmt = "INSERT INTO store_address(store_address_seq, cust_id, " + _
                ''        "store_id, address_seq) VALUES (?, ?, ?, ? )"

                '    Set cmLocal = Nothing
                '    Set cmLocal = New ADODB.Command

                '    create_param_rs "store_address_seq", adInteger, adParamInput, nStoreAddressSeq, cmLocal, 4
                '    create_param_rs "cust_id", adChar, adParamInput, txtCustId.Text, cmLocal, 2
                'jp.begin.2010.02.16 - Address maintenance
                '    create_param_rs "store_id", adInteger, adParamInput, gStoreAddress.nStoreId, cmLocal, 4
                'jp.end.2010.02.16
                '    create_param_rs "address_seq", adInteger, adParamInput, nAddressSeq, cmLocal, 4


                '    cmLocal.ActiveConnection = cn
                '    cmLocal.CommandType = adCmdText
                '    cmLocal.CommandText = sStmt
                '    cmLocal.Execute nRecords

                '    If nRecords > 0 Then
                '        nDbTran = 0

                '        cn.CommitTrans
                '        save_record = True

                'load global record to return with new PK
                '        set_address_record nStoreAddressSeq

                '        MsgBox "Address was successfullty saved.", vbOKOnly + vbInformation, "GLM Message"
                '        Exit Function
                '    Else
                '        If nDbTran > 0 Then
                '            nDbTran = 0
                '            cn.RollbackTrans
                '            MsgBox "Failed to insert Store-Address reference.", vbOKOnly + vbCritical, "GLM Message"
                '            Exit Function
                '        End If

                '    End If


                'Else
                '    If nDbTran > 0 Then
                '        nDbTran = 0
                '        cn.RollbackTrans
                '        MsgBox "Failed to insert Address in catalog.", vbOKOnly + vbCritical, "GLM Message"
                '        Exit Function
                '    End If
                'End If
				
			Case General.modo.UpdateRecord
                sStmt = "UPDATE address_catalog " & " SET address = @address , city = @city, state_id  = @state_id, zip = @zip " _
                     & " WHERE address_seq = @address_seq"
				
                cmLocal = cn.CreateCommand
                cmLocal.CommandType = CommandType.Text
                cmLocal.CommandText = sStmt

                create_param_rs("address", SqlDbType.VarChar, ParameterDirection.Input, quotation_mask(Trim(txtAddress.Text)), cmLocal, 80)
                create_param_rs("city", SqlDbType.VarChar, ParameterDirection.Input, quotation_mask(Trim(txtCity.Text)), cmLocal, 40)
                create_param_rs("state_id", SqlDbType.VarChar, ParameterDirection.Input, (cbState.Text), cmLocal, 2)
                create_param_rs("zip", SqlDbType.VarChar, ParameterDirection.Input, (txtZip.Text), cmLocal, 20)
				
                create_param_rs("address_seq", SqlDbType.Int, ParameterDirection.Input, gStoreAddress.nAddressSeq, cmLocal, 4)
				'create_param_rs "context_table", adVarChar, adParamInput, ADDRESS_CATALOG_CONTEXT_STORE, cmLocal, 100
                nRecords = cmLocal.ExecuteNonQuery()

				If nRecords > 0 Then
					gStoreAddress.bFlag = General.modo.SavedRecord
					save_record = True
					MsgBox("Address was updated successfully", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
				Else
					MsgBox("Failed to update Address information. Please review log file for details", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
					Exit Function
				End If
				
		End Select
		
	End Function
	
	Private Sub set_address_record(ByRef nStoreAddressSeq As Short)
		
		'gStoreAddressRecord.bFlag = modo.SavedRecord
		'gStoreAddressRecord.nStoreAddressSeq = nStoreAddressSeq
		
		gStoreAddress.bFlag = General.modo.SavedRecord
		gStoreAddress.nStoreAddressSeq = nStoreAddressSeq
		
	End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        If val_fields() Then
            If save_record() Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub
End Class