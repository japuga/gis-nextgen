Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmStore
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private rsTmp As DataTable

	Private Sub search_store(ByRef nStoreId As Short)
		
	End Sub
	Private Sub update_store()
        If dgStore.SelectedRows.Count > 0 Then
            General.gbMode = General.modo.UpdateRecord
            If get_store() Then
                VB6.ShowForm(frmStoreEntry, VB6.FormShowConstants.Modal, Me)
            End If
        End If
		
	End Sub
	
    Private Sub dgStore_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        update_store()
        If General.gbMode = General.modo.SavedRecord Then
            'Refresca query
            set_dgStoreData(True)
        End If
    End Sub
	
	Private Sub frmStore_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		load_comp()
	End Sub
	Private Sub init_vars()

    End Sub
	
	Private Sub load_comp()
		
		VB6.ShowForm(frmStoreSearch, VB6.FormShowConstants.Modal, Me)
		If gbStoreSearch.bFlag Then 'Usuario ingreso parametros para query
			'Habilito botones
            Toolbar1.Items.Item("btNew").Enabled = True
            Toolbar1.Items.Item("btSave").Enabled = True
			
		Else
			'Deshabilito botones
            Toolbar1.Items.Item("btNew").Enabled = False
            Toolbar1.Items.Item("btSave").Enabled = False
			
		End If
		'Corro query y cargo datos al Datagrid
        set_dgStoreData(gbStoreSearch.bFlag)
	End Sub
    Private Sub set_dgStoreData(ByRef bFlag As Boolean)
        Dim bFound As Boolean
        Dim cmd As SqlCommand = cn.CreateCommand
        On Error GoTo ErrorHandler

        If bFlag Then
            Label1.Text = Trim(gbStoreSearch.sCustName) & " - Stores"
            lbState.Text = "State - " & gbStoreSearch.sStateId
            sStmt = "SELECT store.store_id, " & _
                "store.store_number AS Store, store_name AS Name," & _
                "store_address AS Address, store_city AS City, " & _
                "store_zip AS Zip, store_contact AS Contact, store_address_seq, lf_group AS LF_Group " & _
                "FROM store " & "WHERE cust_id ='" & gbStoreSearch.sCustId & "' "

            If gbStoreSearch.sStateId = "<All>" Then
                '1.8.8 Solo estados con permiso
                sStmt = Trim(sStmt) & " AND state_id IN (SELECT state_id " & " FROM suser_data " & " WHERE suser_name ='" & Trim(gsUser) & "' " & " AND cust_id ='" & gbStoreSearch.sCustId & "') "
            Else
                sStmt = Trim(sStmt) & "AND state_id = '" & gbStoreSearch.sStateId & "' "
            End If

            sStmt = Trim(sStmt) & " ORDER BY store_number"

        Else
            'Este query es solo para mostrar los titulos de los campos en Datagrid
            Label1.Text = "Stores"
            lbState.Text = ""
            sStmt = "SELECT store.store_id, " & _
            "store.store_number AS Store, store_name AS Name," & _
            "store_address AS Address, store_city AS City, " & _
            "store_zip AS Zip, store_contact AS Contact, store_address_seq, lf_group AS LF_Group " & "FROM store " & "WHERE cust_id ='00' "


        End If

        dgStore.DataSource = Nothing
        cmd.CommandText = sStmt
        rsLocal = getDataTable(sStmt) ' cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


        'search
        bFound = False

        If rsLocal.Rows.Count > 0 Then
            For row As Integer = 0 To rsLocal.Rows.Count - 1
                If rsLocal.Rows(row).Item("store_id") = gStoreRecord.nStoreId Then
                    'dgStore.SelBookmarks.Add (rsLocal.Bookmark)
                    bFound = True
                    Exit For
                End If
            Next row

            
        End If



        dgStore.DataSource = rsLocal

        If rsLocal.Rows.Count > 0 Then
            If bFound = False Then

            End If
            'no se como funcionan los bookmarks
            'dgStore.SelBookmarks.Add((rsLocal.Bookmark))
        End If


        dgStore.Columns("store_id").Visible = False
        dgStore.Columns("store_address_seq").Visible = False
        dgStore.Columns("Contact").Visible = False

        'Formato de columnas en datagrid.
        dgStore.Columns("Store").Width = VB6.TwipsToPixelsX(1200)
        dgStore.Columns("Address").Width = VB6.TwipsToPixelsX(2800)
        dgStore.Columns("City").Width = VB6.TwipsToPixelsX(1000)
        dgStore.Columns("Zip").Width = VB6.TwipsToPixelsX(1000)
        dgStore.Columns("LF_Group").Width = VB6.TwipsToPixelsX(1000)
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "set_dgStoreData")
        MsgBox("An unexpected error has occurred.Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")

    End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button4.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "new"
                General.gbMode = General.modo.NewRecord
                VB6.ShowForm(frmStoreEntry, VB6.FormShowConstants.Modal, Me)
                If General.gbMode = General.modo.SavedRecord Then
                    'Refresca query
                    set_dgStoreData(True)
                End If
            Case "save"
                update_store()
                If General.gbMode = General.modo.SavedRecord Then
                    'Refresca query
                    set_dgStoreData(True)
                End If

            Case "search"
                load_comp()
            Case "exit"
                Me.Close()
        End Select


    End Sub
	
	'Saves Store info in gStoreRecord
	Private Function get_store() As Boolean
		
        Dim dt As DataTable
		get_store = False
        gStoreRecord.sStoreNumber = dgStore.CurrentRow.Cells("Store").Value
        gStoreRecord.nStoreId = CShort(dgStore.CurrentRow.Cells("store_id").Value)
		
        sStmt = "SELECT  store_name, " & "store_address, store_city, store_zip, " _
                                       & "state_id, store_phone1, store_phone2, " _
                                       & "store_fax1, store_fax2, store_contact," _
                                       & "store_status, store_folder, store_co_code, store_occupants, " _
                                       & "store_address_seq, store_billing_contact, store_billing_account, " _
                                       & "lf_group, store_market, store_sold, store_sold_date " _
                                       & " FROM store " _
                                       & " WHERE cust_id ='" & Trim(gbStoreSearch.sCustId) & "' " & " AND store_id=" & Str(gStoreRecord.nStoreId)
        Try
            dt = getDataTable(sStmt)
            'rsTmp.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If dt.Rows.Count > 0 Then

                gStoreRecord.sStoreName = IIf(IsDBNull(dt.Rows(0).Item("store_name")), "", Trim(dt.Rows(0).Item("store_name")))

                gStoreRecord.sStoreAddress = IIf(IsDBNull(dt.Rows(0).Item("store_address")), "", Trim(dt.Rows(0).Item("store_address")))

                gStoreRecord.sStoreCity = IIf(IsDBNull(dt.Rows(0).Item("store_city")), "", Trim(dt.Rows(0).Item("store_city")))

                gStoreRecord.sStoreZip = IIf(IsDBNull(dt.Rows(0).Item("store_zip")), "", Trim(dt.Rows(0).Item("store_zip")))

                gStoreRecord.sStateId = IIf(IsDBNull(dt.Rows(0).Item("state_id")), "", Trim(dt.Rows(0).Item("state_id")))

                gStoreRecord.sStorePhone1 = IIf(IsDBNull(dt.Rows(0).Item("store_phone1")), "", Trim(dt.Rows(0).Item("store_phone1")))

                gStoreRecord.sStorePhone2 = IIf(IsDBNull(dt.Rows(0).Item("store_phone2")), "", Trim(dt.Rows(0).Item("store_phone2")))

                gStoreRecord.sStoreFax1 = IIf(IsDBNull(dt.Rows(0).Item("store_fax1")), "", Trim(dt.Rows(0).Item("store_fax1")))

                gStoreRecord.sStoreFax2 = IIf(IsDBNull(dt.Rows(0).Item("store_fax2")), "", Trim(dt.Rows(0).Item("store_fax2")))

                gStoreRecord.sStoreContact = IIf(IsDBNull(dt.Rows(0).Item("store_contact")), "", Trim(dt.Rows(0).Item("store_contact")))

                gStoreRecord.sStoreStatus = IIf(IsDBNull(dt.Rows(0).Item("store_status")), "", Trim(dt.Rows(0).Item("store_status")))

                gStoreRecord.sStoreFolder = IIf(IsDBNull(dt.Rows(0).Item("store_folder")), "", Trim(dt.Rows(0).Item("store_folder")))

                gStoreRecord.sStoreCoCode = IIf(IsDBNull(dt.Rows(0).Item("store_co_code")), "", Trim(dt.Rows(0).Item("store_co_code")))

                'Bug 35.begin
                gStoreRecord.nStoreOccupants = IIf(IsDBNull(dt.Rows(0).Item("store_occupants")), 0, dt.Rows(0).Item("store_occupants"))
                'Bug 35.end

                Dim expr As Boolean = IsDBNull(dt.Rows(0).Item("store_address_seq"))

                If IsDBNull(dt.Rows(0).Item("store_address_seq")) Then
                    gStoreRecord.nStoreAddressSeq = 0
                Else
                    gStoreRecord.nStoreAddressSeq = dt.Rows(0).Item("store_address_seq")
                    Dim aValue As Short = dt.Rows(0).Item("store_address_seq")
                End If
                
                'gStoreRecord.nStoreAddressSeq = IIf(IsDBNull(dt.Rows(0).Item("store_address_seq")), _
                '                                        0, _
                '                                        Convert.ToInt16( _
                '                                            Trim(dt.Rows(0).Item("store_address_seq")) _
                '                                        ) _
                '                                    )
                If IsDBNull(dt.Rows(0).Item("store_billing_contact")) Then
                    gStoreRecord.sStoreBillingContact = 0
                Else
                    gStoreRecord.sStoreBillingContact = Trim(dt.Rows(0).Item("store_billing_contact"))
                End If

                If IsDBNull(dt.Rows(0).Item("store_billing_account")) Then
                    gStoreRecord.sStoreBillingAccount = ""
                Else
                    gStoreRecord.sStoreBillingAccount = IIf(IsDBNull(dt.Rows(0).Item("store_billing_account")), "", Trim(dt.Rows(0).Item("store_billing_account")))
                End If

                If IsDBNull(dt.Rows(0).Item("lf_group")) Then
                    gStoreRecord.sLfGroup = ""
                Else
                    gStoreRecord.sLfGroup = Trim(dt.Rows(0).Item("lf_group"))
                End If

                If IsDBNull(dt.Rows(0).Item("store_market")) Then
                    gStoreRecord.sStoreMarket = ""
                Else
                    gStoreRecord.sStoreMarket = Trim(dt.Rows(0).Item("store_market"))
                End If

                If IsDBNull(dt.Rows(0).Item("store_sold")) Then
                    gStoreRecord.sStoreSold = ""
                Else
                    gStoreRecord.sStoreSold = Trim(dt.Rows(0).Item("store_sold"))
                End If


                If Not IsDBNull(dt.Rows(0).Item("store_sold_date")) Then
                    gStoreRecord.dtStoreSoldDate = dt.Rows(0).Item("store_sold_date")
                Else

                End If


                'lf_group, store_market, store_sold, store_sold_date

                get_store = True
            Else
                MsgBox("Unable to get data for customer:" & Trim(gbStoreSearch.sCustId) & " store:" & gStoreRecord.sStoreNumber, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")


            End If

        Catch e As Exception
            MsgBox("Error accesing database.", MsgBoxStyle.OkOnly, "GLM Error")
        End Try

        Exit Function

ErrorHandler:
        get_store = False
        save_error("frmStore", "get_store")
        MsgBox("Failed to retrieve Store info." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
    End Function

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click

        'clear the variable gStoreRecord from any value
        clear_gStoreRecord()

        General.gbMode = General.modo.NewRecord
        VB6.ShowForm(frmStoreEntry, VB6.FormShowConstants.Modal, Me)
        If General.gbMode = General.modo.SavedRecord Then
            'Refresca query
            set_dgStoreData(True)
        End If
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        update_store()
        If General.gbMode = General.modo.SavedRecord Then
            'Refresca query
            set_dgStoreData(True)
        End If
    End Sub

    Private Sub btSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSearch.Click
        load_comp()
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub dgStore_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgStore.CellContentDoubleClick
        dgStore.CurrentRow.Selected = True
        update_store()
        If General.gbMode = General.modo.SavedRecord Then
            'Refresca query
            set_dgStoreData(True)
        End If
    End Sub

    Private Sub dgStore_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgStore.CellDoubleClick

    End Sub
    Private Sub clear_gStoreRecord()
        gStoreRecord = New gStoreRecordUDT()
       
    End Sub
End Class