Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmStoreAddress
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private ImageList2 As New ImageList()
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		
		load_dgAddress("", 0)
		
		If cbCustName.SelectedIndex >= 0 Then
			cbCustId.SelectedIndex = cbCustName.SelectedIndex
		End If
		
		
		
		load_cbStoreNo((cbCustId.Text))
	End Sub
	
	Private Sub load_cbStoreNo(ByRef sCustId As String)
		sStmt = "SELECT store_number, store_id FROM store " & "WHERE cust_id = '" & sCustId & "'" & " ORDER BY store_number"
		
		load_cb_query2(cbStoreNo, sStmt, 2, True)
		If cbStoreNo.Items.Count > 0 Then
			cbStoreNo.SelectedIndex = 0
		End If
		
		
	End Sub
	
	'UPGRADE_WARNING: Event cbStoreNo.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbStoreNo_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbStoreNo.SelectedIndexChanged
		
		load_dgAddress((cbCustId.Text), VB6.GetItemData(cbStoreNo, cbStoreNo.SelectedIndex))
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
        If dgAddress.SelectedRows.Count <= 0 Then
            MsgBox("Select a record before continuing or Press Exit for no selection", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Sub
        Else
            populate_address_var()
            Me.Close()
        End If
		
		
	End Sub
	
	
	Private Sub clear_store_address_record()
		
		'gStoreAddress.nStoreAddressSeq = 0
		gStoreAddress.nStoreAddressSeq = 0
		gStoreAddress.nStoreId = 0
		gStoreAddress.sAddress = ""
		gStoreAddress.sCity = ""
		gStoreAddress.sState = ""
		gStoreAddress.sZip = ""
		
		
	End Sub
	Private Sub populate_address_var()
		
		gStoreAddress.bAddressFlag = General.addressMode.RecordSelected
		'gStoreAddress.bFlag = addressMode.RecordSelected
		
        gStoreAddress.nStoreAddressSeq = CShort(dgAddress.SelectedRows(0).Cells("store_address_seq").Value)
        gStoreAddress.nAddressSeq = CShort(dgAddress.SelectedRows(0).Cells("address_seq").Value)
        gStoreAddress.sAddress = dgAddress.SelectedRows(0).Cells("Address").Value
        gStoreAddress.sCity = dgAddress.SelectedRows(0).Cells("City").Value
        gStoreAddress.sState = dgAddress.SelectedRows(0).Cells("State").Value
        gStoreAddress.sZip = dgAddress.SelectedRows(0).Cells("Zip").Value
		
		
		'MsgBox rs("address")
		
		
		
	End Sub
	
    Private Sub dgAddress_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        Select Case gStoreAddress.bAddressFlag
            Case General.addressMode.LookupMode
                cmdOk_Click(cmdOk, New System.EventArgs())
            Case General.addressMode.InsertUpdateMode
                edit_address()
        End Select

    End Sub
	
	Private Sub frmStoreAddress_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	
	Private Sub init_vars()
		
        rsLocal = Nothing
		
		cbCustId.Visible = False
		
		sStmt = "SELECT cust_name FROM customer ORDER BY cust_name"
		load_cb_query2(cbCustName, sStmt, 1, True)
		
		sStmt = "SELECT cust_id, cust_name FROM customer ORDER BY cust_name"
		load_cb_query2(cbCustId, sStmt, 1, True)
		
		
		
		Select Case gStoreAddress.bAddressFlag
			Case General.addressMode.LookupMode
				set_cb(cbCustName, gStoreAddress.sCustName)
				set_cb_ItemData(cbStoreNo, gStoreAddress.nStoreId)
				
				cbCustName.Enabled = False
                'cbCustName.Locked = True
				cbStoreNo.Enabled = False
                'cbStoreNo.Locked = True
				
                Toolbar1.Items.Item("btSave").Visible = True
                'Toolbar1.Items.Item("btSearch").Visible = False
				
				load_dgAddress(gStoreAddress.sCustId, gStoreAddress.nStoreId)
			Case General.addressMode.InsertUpdateMode
				
				cmdOk.Visible = False
				
				If cbCustName.Items.Count > 0 Then
					cbCustName.SelectedIndex = 0
				End If
				
				If cbCustName.SelectedIndex >= 0 And cbStoreNo.SelectedIndex >= 0 Then
					load_dgAddress((cbCustId.Text), VB6.GetItemData(cbStoreNo, cbStoreNo.SelectedIndex))
				Else
					load_dgAddress("", 0)
				End If
				
		End Select
		
		
	End Sub
	
	
	Private Sub load_dgAddress(ByRef sCustId As String, ByRef nStoreId As Short)
		
        sStmt = " SELECT b.store_address_seq, a.address_seq, a.address Address, a.city City, a.state_id State, a.zip Zip " _
                & " FROM address_catalog a, store_address b" _
                & " WHERE a.address_seq = b.address_seq " _
                    & " AND a.context_table = '" & ADDRESS_CATALOG_CONTEXT_STORE & "' " _
                    & " AND b.cust_id = '" & sCustId & "' " _
                    & " AND b.store_id = " & Str(nStoreId) _
                & " ORDER BY Address, City, State"
		
        dgAddress.DataSource = Nothing
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		
		
		
        If rsLocal.Rows.Count > 0 Then
            Toolbar1.Items.Item("btSave").Visible = True
            dgAddress.DataSource = rsLocal
            dgAddress.Columns("address_seq").Visible = False
            dgAddress.Columns("store_address_seq").Visible = False
        Else
            Toolbar1.Items.Item("btSave").Visible = True
        End If

		
		
		
		
		
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button4.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "new"
                add_address()
            Case "save"
                edit_address()
            Case "exit"
                Me.Close()
        End Select

    End Sub
	Private Sub add_address()
		If cbCustId.SelectedIndex < 0 Or cbCustName.SelectedIndex < 0 Or cbStoreNo.SelectedIndex < 0 Then
			MsgBox("Please select a Customer and Store before attempting this command", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			Exit Sub
		End If
		
		set_address_record((General.modo.NewRecord))
		VB6.ShowForm(frmStoreAddressEntry, VB6.FormShowConstants.Modal, Me)
		'If gStoreAddressRecord.bFlag = modo.SavedRecord Then
		If gStoreAddress.bFlag = General.modo.SavedRecord Then
			load_dgAddress((cbCustId.Text), VB6.GetItemData(cbStoreNo, cbStoreNo.SelectedIndex))
		End If
		
	End Sub
	Private Sub edit_address()

		If cbCustId.SelectedIndex < 0 Or cbCustName.SelectedIndex < 0 Or cbStoreNo.SelectedIndex < 0 Then
			MsgBox("Please select a Customer and Store before attempting this command", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			Exit Sub
		End If

        If dgAddress.SelectedRows.Count < 1 Then
            If dgAddress.SelectedCells.Count > 0 Then
                dgAddress.Rows(dgAddress.SelectedCells(0).RowIndex).Selected = True

            End If
        End If
        If dgAddress.SelectedRows.Count <= 0 Then
            MsgBox("Select a record before attempting this command", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Sub
        End If



        set_address_record((General.modo.UpdateRecord))
        VB6.ShowForm(frmStoreAddressEntry, VB6.FormShowConstants.Modal, Me)
        'If gStoreAddressRecord.bFlag = modo.SavedRecord Then
        If gStoreAddress.bFlag = General.modo.SavedRecord Then
            load_dgAddress((cbCustId.Text), VB6.GetItemData(cbStoreNo, cbStoreNo.SelectedIndex))
        End If

    End Sub
	Private Sub set_address_record(ByRef nOption As General.modo)
		
		Select Case nOption
			Case General.modo.NewRecord
				'gStoreAddressRecord.bFlag = modo.NewRecord
				'gStoreAddressRecord.sCustId = cbCustId.Text
				'gStoreAddressRecord.sCustName = cbCustName.Text
				'gStoreAddressRecord.nStoreId = cbStoreNo.ItemData(cbStoreNo.ListIndex)
				'gStoreAddressRecord.sStoreNumber = cbStoreNo.Text
				
				gStoreAddress.bFlag = General.modo.NewRecord
				'Just load Customer and Store when Insert/Update mode since these are
				'already populated when used in LookupMode at frmStoreEntry form
				'If gStoreAddress.bAddressFlag = addressMode.InsertUpdateMode Then
				gStoreAddress.sCustId = cbCustId.Text
				gStoreAddress.sCustName = cbCustName.Text
				gStoreAddress.nStoreId = VB6.GetItemData(cbStoreNo, cbStoreNo.SelectedIndex)
				gStoreAddress.sStoreNumber = cbStoreNo.Text
				'End If
				
			Case General.modo.UpdateRecord
				'gStoreAddressRecord.bFlag = modo.UpdateRecord
				'gStoreAddressRecord.sCustId = cbCustId
				'gStoreAddressRecord.sCustName = cbCustName
				'gStoreAddressRecord.nStoreId = cbStoreNo.ItemData(cbStoreNo.ListIndex)
				'gStoreAddressRecord.sStoreNumber = cbStoreNo.Text
				
				gStoreAddress.bFlag = General.modo.UpdateRecord
				gStoreAddress.sCustId = cbCustId.Text
				gStoreAddress.sCustName = cbCustName.Text
				gStoreAddress.nStoreId = VB6.GetItemData(cbStoreNo, cbStoreNo.SelectedIndex)
				gStoreAddress.sStoreNumber = cbStoreNo.Text
				
				
				'Details
                gStoreAddress.nAddressSeq = CShort(dgAddress.SelectedRows(0).Cells("address_seq").Value)
                gStoreAddress.sAddress = dgAddress.SelectedRows(0).Cells("Address").Value
                gStoreAddress.sCity = dgAddress.SelectedRows(0).Cells("City").Value
                gStoreAddress.sState = dgAddress.SelectedRows(0).Cells("State").Value
                gStoreAddress.sZip = dgAddress.SelectedRows(0).Cells("Zip").Value
				
		End Select
		
		
	End Sub

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        add_address()
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        edit_address()
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub dgAddress_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAddress.CellDoubleClick
        edit_address()
    End Sub
End Class