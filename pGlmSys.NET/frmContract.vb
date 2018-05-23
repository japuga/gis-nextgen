Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmContract
	Inherits System.Windows.Forms.Form

    Private rsLocal As DataTable
    Private rsLocalDet As DataTable
    Private rsStore As DataTable
    Private rsEquipment As DataTable
    Private rsContract As DataTable
    Private cmLocal As SqlCommand
    Private ignore_dgStore_RowEnter As Boolean = False

	
    Private Sub cbCustId_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustId.SelectedIndexChanged
        If cbCustId.SelectedIndex >= 0 Then
            load_state(cbCustId.Text)
        End If
    End Sub
	'Refresca combo de State
	Private Sub load_state(ByRef sCustId As String)
		
		cbStateId.Items.Clear()
		
		sStmt = "SELECT state_id FROM state " & " WHERE state_id IN (SELECT state_id FROM suser_data " & " WHERE suser_data.cust_id ='" & Trim(sCustId) & "' " & " AND suser_data.suser_name='" & Trim(gsUser) & "') "
        cbStateId.Items.Clear()
        cbStateId.Items.Insert(0, "<All>")
		load_cb_query2(cbStateId, sStmt, 1, False)
		cbStateId.SelectedIndex = 0
		
	End Sub
	Private Sub cmdSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSearch.Click
		get_dg_defaults(False)
	End Sub
	
	Private Sub cmdVendorSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVendorSearch.Click
		
		gVendorSearch.bFlag = False
		VB6.ShowForm(frmVendorBrowse, VB6.FormShowConstants.Modal, Me)
		If gVendorSearch.bFlag Then
			txtVendName.Text = gVendorSearch.sVendName
			txtVendName.Tag = gVendorSearch.nVendSeq
		Else
			txtVendName.Text = "<All>"
			txtVendName.Tag = 0
		End If
	End Sub
	
    Private Sub dgContract_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        data_entry((General.modo.UpdateRecord))
    End Sub
	'Calls frmContractEntry to insert or update contracts
	Private Sub data_entry(ByRef bFlag As General.modo)
		'Verify that user has selected store and equipment
		Select Case bFlag
			Case General.modo.NewRecord
                If dgStore.SelectedRows.Count > 0 Then
                    'Se escogio una tienda. OK
                    If IsNothing(dgEquipment.Rows(0).Cells("eqpt_seq").Value) Then
                        MsgBox("Please choose an Equipment before Entering Contract Info.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                        Exit Sub
                    End If
                    Dim eqpt_id As String = dgEquipment.Rows(0).Cells("eqpt_seq").Value.ToString()
                    If dgEquipment.SelectedRows.Count > 0 And (Not eqpt_id = "") Then
                        'OK Equipment
                    Else
                        MsgBox("Please choose an Equipment before Entering Contract Info.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                        Exit Sub
                    End If
                Else
                    MsgBox("Please choose an Store before entering Contract Info.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                    Exit Sub
                End If
            Case General.modo.UpdateRecord
                If dgContract.SelectedRows.Count = 0 Then
                    If dgContract.SelectedCells.Count > 0 Then
                        dgContract.Rows(dgContract.SelectedCells(0).RowIndex).Selected = True
                    End If
                End If
                If dgStore.SelectedRows.Count > 0 Then
                    'OK Store
                    If dgEquipment.SelectedRows.Count > 0 Then
                        'OK Equipment

                        If dgContract.SelectedRows.Count > 0 Then
                            'OK Contract
                        Else
                            MsgBox("Please choose a Contract to Update.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                            Exit Sub
                        End If
                    Else
                        MsgBox("Please choose an Equipment before Entering Contract Info.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                        Exit Sub
                    End If

                Else
                    MsgBox("Please choose an Store before entering Contract Info.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                    Exit Sub
                End If

            Case Else
                Exit Sub
        End Select
		
		gContractRecord.bFlag = bFlag
		set_contract_data(bFlag)
		VB6.ShowForm(frmContractEntry, VB6.FormShowConstants.Modal, Me)
		If gContractRecord.bFlag = General.modo.SavedRecord Then
			'Se refresca datagrid para el mismo vendor de txtVendName
            get_dgContractData(False, gContractRecord.sCustId, gContractRecord.nStoreId, CShort(txtVendName.Tag), gContractRecord.nEqptSeq)
		End If
		
	End Sub
	
	'Loads data in global variable gContractRecord
	Private Sub set_contract_data(ByRef bFlag As General.modo)
		
		On Error GoTo ErrorHandler
		
        gContractRecord.sCustId = dgStore.Rows(dgStore.SelectedRows(0).Index).Cells("cust_id").Value
        gContractRecord.nStoreId = dgStore.Rows(dgStore.SelectedRows(0).Index).Cells("store_id").Value
        gContractRecord.sStoreNumber = dgStore.Rows(dgStore.SelectedRows(0).Index).Cells("Store").Value
        If IsNothing(dgEquipment.SelectedRows(0).Cells("eqpt_seq").Value) Then
            gContractRecord.nEqptSeq = -1
        Else
            gContractRecord.nEqptSeq = rsEquipment.Rows(dgEquipment.CurrentRow.Index).Item("eqpt_seq")
        End If

        gContractRecord.nServId = -1

        If bFlag = General.modo.UpdateRecord Then
            gContractRecord.nVendSeq = rsContract.Rows(dgContract.CurrentRow.Index).Item("vend_seq")
            'gContractRecord.nEqptSeq = rsContract.item("eqpt_seq")
            gContractRecord.nServId = rsContract.Rows(dgContract.CurrentRow.Index).Item("serv_id")

            gContractRecord.nFreqId = rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_id")

            gContractRecord.sFreqComments = IIf(IsDBNull(rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_comments")), "", rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_comments"))

            gContractRecord.sContractComments = IIf(IsDBNull(rsContract.Rows(dgContract.CurrentRow.Index).Item("contract_comments")), "", rsContract.Rows(dgContract.CurrentRow.Index).Item("contract_comments"))

            gContractRecord.sFreqTimes = IIf(IsDBNull(rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_times")), "", rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_times"))

            gContractRecord.sFreqPeriod = IIf(IsDBNull(rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_period")), "", rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_period"))

            gContractRecord.nGlmRate = IIf(IsDBNull(rsContract.Rows(dgContract.CurrentRow.Index).Item("GLM Rate")), 0, rsContract.Rows(dgContract.CurrentRow.Index).Item("GLM Rate"))

            gContractRecord.nOldRate = rsContract.Rows(dgContract.CurrentRow.Index).Item("Prev Rate")
            gContractRecord.nCurrRate = rsContract.Rows(dgContract.CurrentRow.Index).Item("Rate")
            gContractRecord.sOpeningDate = rsContract.Rows(dgContract.CurrentRow.Index).Item("Started")

            gContractRecord.sExpirationDate = IIf(IsDBNull(rsContract.Rows(dgContract.CurrentRow.Index).Item("Until")), "", rsContract.Rows(dgContract.CurrentRow.Index).Item("Until"))

            gContractRecord.sFreqDay1 = IIf(IsDBNull(rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_day1")), "", rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_day1"))

            gContractRecord.sFreqDay2 = IIf(IsDBNull(rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_day2")), "", rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_day2"))

            gContractRecord.sFreqDay3 = IIf(IsDBNull(rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_day3")), "", rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_day3"))

            gContractRecord.sFreqDay4 = IIf(IsDBNull(rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_day4")), "", rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_day4"))

            gContractRecord.sFreqDay5 = IIf(IsDBNull(rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_day5")), "", rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_day5"))

            gContractRecord.sFreqDay6 = IIf(IsDBNull(rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_day6")), "", rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_day6"))

            gContractRecord.sFreqDay7 = IIf(IsDBNull(rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_day7")), "", rsContract.Rows(dgContract.CurrentRow.Index).Item("freq_day7"))

            gContractRecord.sVendor = rsContract.Rows(dgContract.CurrentRow.Index).Item("Vendor")

            gContractRecord.sRateStatus = IIf(IsDBNull(rsContract.Rows(dgContract.CurrentRow.Index).Item("rate_status")), "", rsContract.Rows(dgContract.CurrentRow.Index).Item("rate_status"))

            gContractRecord.sOverrideExpFlag = IIf(IsDBNull(rsContract.Rows(dgContract.CurrentRow.Index).Item("override_exp_flag")), "", rsContract.Rows(dgContract.CurrentRow.Index).Item("override_exp_flag"))
        End If
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "set_contract_data")
        MsgBox("An unexpected has occurred, please check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Glm Error")

    End Sub
    'Private Sub dgEquipment_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    'jp BEG 01.29.03
    '    'If dgEquipment.Row >= 0 Then
    '    'dgEquipment.SelBookmarks.Add rsEquipment.Bookmark
    '    If dgEquipment.SelectedRows.Count > 0 Then
    '        set_dgContractData()
    '    End If
    'End Sub
	
    Private Sub dgStore_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        '01/29/03
        'If dgStore.Row >= 0 Then
        'dgStore.SelBookmarks.Add rsStore.Bookmark
        'If dgStore.SelectedRows.Count > 0 Then
        '    'Busco los equipos para esta tienda
        '    'no se como implementar el bookmark.
        '    'get_dgEquipmentData(False, rsStore.Rows(dgSTore.Rows).Item("store_id").Value)
        '    get_dgEquipmentData(False, dgStore.SelectedRows(0).Cells("store_id").Value)
        '    If dgEquipment.SelectedRows(0).Index >= 0 Then
        '        'rsEquipment.Bookmark()
        '        'dgEquipment.SelBookmarks.Add()
        '        set_dgContractData()
        '    Else
        '        get_dgContractData(True)
        '    End If

        'End If
    End Sub
	'Carga el datagrid Contract
    Private Sub get_dgContractData(ByRef bInit As Boolean, Optional ByRef sCustId As String = "", Optional ByRef nStoreId As Short = 0, Optional ByRef nVendSeq As Short = 0, Optional ByRef nEqptSeq As Short = 0)

        On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand()
        sStmt = "SELECT " & " RTRIM(VBranch.vend_name)+ ' - ' +RTRIM (VBranch.vend_area)  AS Vendor, " & " StoreEqpt.eqpt_desc AS Equipment, " & " Content.content_desc AS Content , " & " Service.serv_desc AS Service, " & " dbo.format_freq2 (Frequency.freq_sched_flag, " & " Frequency.freq_times_flag, " & " VContract.freq_times, " & " ISNULL(VContract.freq_period,''), " & " ISNULL(VContract.freq_day1,''), " & " ISNULL(VContract.freq_day2,''), " & " ISNULL(VContract.freq_day3,''), " & " ISNULL(VContract.freq_day4,''), " & _
                " ISNULL(VContract.freq_day5,''), " & _
                " ISNULL(VContract.freq_day6,''), " & _
                " ISNULL(VContract.freq_day7,'')) " & _
                " AS Frequency," & _
                " VContract.glm_rate AS 'GLM Rate', " & _
                " VContract.curr_rate AS Rate, " & _
                " VContract.old_rate AS 'Prev Rate', " & _
                " VContract.opening_date AS Started, " & _
                " VContract.expiration_date AS Until, "
        sStmt = sStmt & " VContract.cust_id, VContract.store_id, " & _
                " VContract.vend_seq, VContract.eqpt_seq , " & _
                " VContract.serv_id , VContract.freq_times, " & _
                " VContract.freq_period, VContract.freq_day1, " & _
                " VContract.freq_day2, VContract.freq_day3, " & _
                " VContract.freq_day4, VContract.freq_day5, " & _
                " VContract.freq_day6, VContract.freq_day7, " & _
                " VContract.freq_id, VContract.freq_comments, " & _
                " VContract.contract_comments, VContract.rate_status,  " & _
                " VContract.override_exp_flag, " & _
                " CASE " & _
                "    WHEN (VContract.default_service='F') THEN 'No' " & _
                "    WHEN (VContract.default_service='T') THEN 'Yes' " & _
                " END AS 'Default Freq' "

        sStmt = sStmt & " FROM StoreEqpt, VContract, Content, Service, VBranch, Frequency " & _
            " WHERE vContract.cust_id = StoreEqpt.cust_id " & " AND VContract.store_id = StoreEqpt.store_id " & _
            " AND VContract.eqpt_seq = StoreEqpt.eqpt_seq " & " AND StoreEqpt.content_id = Content.content_id " & " AND VContract.serv_id = Service.serv_id " & _
            " AND VContract.vend_seq = VBranch.vend_seq " & " AND VContract.cust_id = '" & Trim(sCustId) & "' " & " AND VContract.store_id = " & Str(nStoreId) & _
            " " & " AND VContract.freq_id = Frequency.freq_id "

        'Solo se incluye si usuario selecciono un Vendor
        If nVendSeq > 0 Then
            sStmt = sStmt & " AND VContract.vend_seq = " & Str(nVendSeq)
        End If

        'Se agrega si ha seleccionado un equipo.
        If nEqptSeq > 0 Then
            sStmt = sStmt & " AND VContract.eqpt_seq = " & Str(nEqptSeq)
        End If

        'MsgBox sStmt

        If bInit Then
            sStmt = sStmt & " AND VContract.eqpt_seq = -1"
        End If

        dgContract.DataSource = Nothing

        cmd.CommandText = sStmt
        rsContract = getDataTable(sStmt) ' cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        dgContract.DataSource = rsContract
        Dim rowCount As Short = rsContract.Rows.Count
        dgContract.Refresh()


        'Formato
        dgContract.Columns("cust_id").Visible = False
        dgContract.Columns("store_id").Visible = False
        dgContract.Columns("vend_seq").Visible = False
        dgContract.Columns("eqpt_seq").Visible = False
        dgContract.Columns("serv_id").Visible = False
        dgContract.Columns("freq_times").Visible = False
        dgContract.Columns("freq_period").Visible = False
        dgContract.Columns("freq_day1").Visible = False
        dgContract.Columns("freq_day2").Visible = False
        dgContract.Columns("freq_day3").Visible = False
        dgContract.Columns("freq_day4").Visible = False
        dgContract.Columns("freq_day5").Visible = False
        dgContract.Columns("freq_day6").Visible = False
        dgContract.Columns("freq_day7").Visible = False
        dgContract.Columns("freq_id").Visible = False
        dgContract.Columns("freq_comments").Visible = False
        dgContract.Columns("contract_comments").Visible = False
        dgContract.Columns("rate_status").Visible = False
        dgContract.Columns("override_exp_flag").Visible = False

        dgContract.Columns("Vendor").Width = VB6.TwipsToPixelsX(2000)
        dgContract.Columns("Equipment").Width = VB6.TwipsToPixelsX(1000)
        dgContract.Columns("Content").Width = VB6.TwipsToPixelsX(800)
        dgContract.Columns("Service").Width = VB6.TwipsToPixelsX(1300)
        dgContract.Columns("GLM Rate").Width = VB6.TwipsToPixelsX(850)
        dgContract.Columns("Rate").Width = VB6.TwipsToPixelsX(850)
        dgContract.Columns("Prev Rate").Width = VB6.TwipsToPixelsX(850)
        dgContract.Columns("Started").Width = VB6.TwipsToPixelsX(1000)
        dgContract.Columns("Until").Width = VB6.TwipsToPixelsX(1000)
        dgContract.Columns("Default Freq").Width = VB6.TwipsToPixelsX(1200)

        dgContract.Refresh()
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "get_dgContract")
        MsgBox("An error occurred while accessing contract table," & "check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, " GLM Error")
    End Sub
	Private Sub frmContract_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
        Dim nCounter As Integer = 0
        Dim cmd As SqlCommand = cn.CreateCommand()
		'Combo CustId
		sStmt = "SELECT DISTINCT suser_data.cust_id, customer.cust_name " & "FROM customer, suser_data " & "WHERE customer.cust_id = suser_data.cust_id " & "AND suser_data.suser_name='" & Trim(gsUser) & "' ORDER BY suser_data.cust_id "
        cmd.CommandText = sStmt
		
        'dt = exec_sql(sStmt)
        rsLocal = getDataTable(sStmt)
		
        If Not rsLocal.Rows.Count > 0 Then
            MsgBox("Your Account does not have access to such Information." & vbCrLf & "Contact your System Administrator to get proper access.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
            Exit Sub
        End If
		
		
		'En caso de haber datos
		cbCustId.Items.Clear()

        'While rsLocal.Read()
        For Each aRow As DataRow In rsLocal.Rows()
            cbCustId.Items.Insert(nCounter, aRow.Item("cust_id"))
            nCounter = nCounter + 1
        Next aRow

        cbCustId.SelectedIndex = 0

        'Vendor
        txtVendName.Text = "<All>"
        txtVendName.Tag = 0 'VendSeq por defecto

        'Cargo Datagrids
        'get_dg_defaults True
        get_dgStoreData(True)
        get_dgEquipmentData(True)
        get_dgContractData(True)

    End Sub
	
	Private Sub get_dg_defaults(ByRef bInit As Boolean)
		
        get_dgStoreData(bInit)
        If dgStore.SelectedRows.Count > 0 Then
            'no se como implementar el bookmark
            'dgStore.SelBookmarks.Add(rsStore.Bookmark)
            'get_dgEquipmentData(False, rsStore.Item("store_id").Value)
            get_dgEquipmentData(False, dgStore.SelectedRows(0).Cells("store_id").Value)
            If dgEquipment.SelectedRows.Count > 0 Then
                If dgEquipment.SelectedRows(0).Index >= 0 Then
                    'dgEquipment.SelBookmarks.Add(rsEquipment.Bookmark)
                    set_dgContractData()
                Else
                    get_dgContractData(True)
                End If
            Else
                get_dgContractData(True)
            End If

        Else
            get_dgEquipmentData(True)
            get_dgContractData(True)
        End If

    End Sub
	'Busca y carga dgStore
    Private Sub get_dgStoreData(ByRef bInit As Boolean)
        Dim cmd As SqlCommand = cn.CreateCommand()
        On Error GoTo ErrorHandler

        sStmt = "SELECT store_number AS Store, " & " state_id as State, " & " store_address AS Address, " & " store_city AS City, " & " cust_id, store_id " & " FROM store " & " WHERE cust_id = '" & cbCustId.Text & "' "

        If bInit Then
            sStmt = sStmt & " AND store_id =-1"
        End If


        If Trim(cbStateId.Text) = "<All>" Then
            '1.8.8 Condicion para permitit usuario acceso exclusivo a
            ' estados permitidos
            sStmt = sStmt & " AND state_id IN (SELECT state_id FROM suser_data " & " WHERE suser_data.cust_id ='" & Trim(cbCustId.Text) & "' " & " AND suser_data.suser_name='" & Trim(gsUser) & "') "
        Else
            sStmt = sStmt & " AND state_id = '" & cbStateId.Text & "' "
        End If

        sStmt = sStmt & " ORDER BY store_number"
        'MsgBox sStmt
        cmd.CommandText = sStmt
        rsStore = getDataTable(sStmt) ' cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        dgStore.DataSource = rsStore

        'Formato de dgStore
        dgStore.Columns("cust_id").Visible = False
        dgStore.Columns("store_id").Visible = False

        dgStore.Columns("Store").Width = VB6.TwipsToPixelsX(1300)
        dgStore.Columns("State").Width = VB6.TwipsToPixelsX(500)
        dgStore.Columns("Address").Width = VB6.TwipsToPixelsX(1700)
        dgStore.Columns("City").Width = VB6.TwipsToPixelsX(800)

        Exit Sub

ErrorHandler:
        save_error(Me.Name, "get_store")
        Resume Next
    End Sub
    Private Sub set_dgEquipmentData()
        'get_dgEquipmentData(False, rsStore.Item("store_id").Value)
        get_dgEquipmentData(False, rsStore.Rows(dgStore.SelectedRows(0).Index).Item("store_id"))
        If dgEquipment.CurrentRow.Index >= 0 Then
            'dgEquipment.SelBookmarks.Add(rsEquipment.Bookmark)
            set_dgContractData()
        End If
    End Sub
    Private Sub set_dgContractData()
        Dim nVendSeq As Short

        If CDbl(txtVendName.Tag) > 0 Then
            nVendSeq = CShort(txtVendName.Tag)
        Else
            nVendSeq = 0
        End If

        Dim cust_id As String = dgEquipment.CurrentRow.Cells("cust_id").Value.ToString()
        If Not cust_id = "" Then
            get_dgContractData(False, rsEquipment.Rows(dgEquipment.CurrentRow.Index).Item("cust_id"), rsEquipment.Rows(dgEquipment.CurrentRow.Index).Item("store_id"), _
                                nVendSeq, rsEquipment.Rows(dgEquipment.CurrentRow.Index).Item("eqpt_seq"))
        End If
        'no se como implementar el bookmark
        'If dgContract.CurrentRow.Index >= 0 Then
        'dgContract.SelBookmarks.Add(rsContract.Bookmark)
        'End If
    End Sub
	'Obtiene datos para datagrid dbEquipment
    Private Sub get_dgEquipmentData(ByRef bInit As Boolean, Optional ByRef nStoreId As Short = 0)

        Dim cmd As SqlCommand = cn.CreateCommand()
        Dim nVendSeq As Short

        On Error GoTo ErrorHandler

        'If IsNull(rsStore.item("store_id")) Then
        '    Exit Sub
        'End If


        'If gVendorSearch.bFlag Then
        '    nVendSeq = gVendorSearch.nVendSeq
        'Else
        '    nVendSeq = 0
        'End If

        nVendSeq = CShort(txtVendName.Tag)


        sStmt = ""
        sStmt = "SELECT StoreEqpt.eqpt_desc AS Eqpt, " & " Content.content_desc AS Content , " & " StoreEqpt.load_id AS Loading, " & " StoreEqpt.eqpt_status AS Status, " & " RTRIM(VBranch.vend_name) + ' - ' +RTRIM(VBranch.vend_area) AS Vendor, " & " StoreEqpt.cust_id, StoreEqpt.store_id, " & " StoreEqpt.eqpt_seq, " & " VAccountEqpt.vend_seq " & " FROM StoreEqpt, VAccountEqpt, VBranch, Content " & " WHERE StoreEqpt.cust_id = VAccountEqpt.cust_id " & " AND StoreEqpt.store_id = VAccountEqpt.store_id  " & " AND StoreEqpt.eqpt_seq = VAccountEqpt.eqpt_seq " & " AND VAccountEqpt.vend_seq = VBranch.vend_seq " & " AND StoreEqpt.content_id = Content.content_id " & " AND StoreEqpt.cust_id = '" & cbCustId.Text & "' " & " AND StoreEqpt.store_id = " & Str(nStoreId) & " AND StoreEqpt.eqpt_status = 'A' " & " AND VAccountEqpt.account_status = 'A' "

        sStmt = "SELECT StoreEqpt.eqpt_desc AS Eqpt, " & " Content.content_desc AS Content , " & " StoreEqpt.load_id AS Loading, " & " StoreEqpt.eqpt_status AS Status, " & " StoreEqpt.cust_id, StoreEqpt.store_id, " & " StoreEqpt.eqpt_seq " & " FROM StoreEqpt, Content " & " WHERE StoreEqpt.content_id = Content.content_id " & " AND StoreEqpt.cust_id = '" & cbCustId.Text & "' " & " AND StoreEqpt.store_id = " & Str(nStoreId) & " AND StoreEqpt.eqpt_status = 'A' "


        'If nVendSeq > 0 Then  'nVendSeq=0   -> <ALL> Vendors
        '    sStmt = sStmt + " AND VAccountEqpt.vend_seq = " + Str(nVendSeq)
        'End If

        'Inicializacion
        If bInit Then
            sStmt = sStmt & " AND StoreEqpt.eqpt_seq = -1"
        End If

        sStmt = sStmt & " ORDER BY Eqpt "
        'MsgBox sStmt
        dgEquipment.DataSource = Nothing

        cmd.CommandText = sStmt
        rsEquipment = getDataTable(sStmt) ' cmd.ExecuteReader '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        dgEquipment.DataSource = rsEquipment



        'Formato
        dgEquipment.Columns("cust_id").Visible = False
        dgEquipment.Columns("store_id").Visible = False
        dgEquipment.Columns("eqpt_seq").Visible = False

        'Columnas
        dgEquipment.Columns("eqpt").Width = VB6.TwipsToPixelsX(1100)
        dgEquipment.Columns("Content").Width = VB6.TwipsToPixelsX(800)

        dgEquipment.Refresh()
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "get_dgEquipmentData")
        MsgBox("Unexpected Error when loading equipment info." & vbCrLf & " Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")

    End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)

        Select Case Button.Name
            Case "new"
                data_entry((General.modo.NewRecord))
            Case "save"
                data_entry((General.modo.UpdateRecord))
            Case "search"
                get_dg_defaults(False)
            Case "delete"
                delete_contract()
            Case "exit"
                Me.Close()
        End Select

    End Sub
	
	Private Sub delete_contract()
		Dim sInvoiceNo As String
		Dim sAccountNo As String
		Dim sInvoiceStatus As String
        Dim nRecords As Short
        Dim cmd As SqlCommand = cn.CreateCommand()
        cmLocal = cn.CreateCommand
        cmLocal.CommandType = CommandType.Text

        If IsNothing(dgStore.CurrentRow) Then
            MsgBox("Please select a Store to delete.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
            Exit Sub
        End If

        If dgStore.Rows.Count < 1 Or dgStore.SelectedRows.Count < 1 Then
            MsgBox("Please choose a Store.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
            Exit Sub
        End If



        If dgStore.SelectedRows(0).Index >= 0 Then
            'Se escogio una tienda. OK
            If dgEquipment.SelectedRows.Count > 0 Then
                'OK Equipment
                If dgContract.SelectedRows.Count > 0 Then
                    'OK. Escogio contrato
                Else
                    MsgBox("Please select a Contract to Delete.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                    Exit Sub
                End If
            Else
                MsgBox("Please choose an Equipment.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                Exit Sub
            End If
        Else
            MsgBox("Please choose a Store.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
            Exit Sub
        End If
		
		
		If (MsgBox("Do you want to delete the selected contract?", MsgBoxStyle.YesNo, "GLM Message") = MsgBoxResult.No) Then
			Exit Sub
		End If

        'rsStore.Rows(dgStore.CurrentRow.Index).Item("cust_id") + "' " + " AND VInvoiceDet.store_id = " + _
        '                Str(rsStore.Rows(dgStore.CurrentRow.Index).Item("store_id")) + " AND VInvoiceDet.vend_seq = " + _
        '                Str(rsContract.Rows(dgStore.CurrentRow.Index).Item("vend_seq")) + " AND VInvoiceDet.eqpt_seq = " + _
        '                Str(rsEquipment.Rows(dgStore.CurrentRow.Index).Item("eqpt_seq")) + " AND VInvoiceDet.serv_id =" + _
        '                Str(rsContract.Rows(dgStore.CurrentRow.Index).Item("serv_id"))


		'Solo se puede borrar contratos sin facturas asociadas.
		'Las facturas deben ser impresas en cheques invoice_status=PRT
		'y dichos cheques debieron ser transferidos a Quick Books.
        sStmt = "SELECT DISTINCT VInvoiceDet.invoice_no, " & "VInvoiceDet.account_no, VInvoice.vinvoice_status " & " FROM VInvoice, VInvoiceDet " & " WHERE VInvoice.invoice_no = VInvoiceDet.invoice_no " & " AND VInvoice.cust_id = VInvoiceDet.cust_id " & " AND VInvoice.store_id = VInvoiceDet.store_id " & " AND VInvoice.vend_seq = VInvoiceDet.vend_seq " & " AND VInvoice.account_no = VInvoiceDet.account_no " & _
                " AND VInvoiceDet.cust_id = '" + dgStore.SelectedRows(0).Cells("cust_id").Value.ToString() + "' " + _
                " AND VInvoiceDet.store_id = " + dgStore.SelectedRows(0).Cells("store_id").Value.ToString() + _
                " AND VInvoiceDet.vend_seq = " + dgContract.CurrentRow.Cells("vend_seq").Value.ToString() + _
                " AND VInvoiceDet.eqpt_seq = " + dgEquipment.CurrentRow.Cells("eqpt_seq").Value.ToString() + _
                " AND VInvoiceDet.serv_id = " + dgContract.CurrentRow.Cells("serv_id").Value.ToString
        cmd.CommandText = sStmt
		
        rsLocal = getDataTable(sStmt) ' cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsLocal.Rows.Count > 0 Then
            'While rsLocal.Read()
            For Each aRow As DataRow In rsLocal.Rows
                sInvoiceNo = aRow.Item("invoice_no")
                sAccountNo = aRow.Item("account_no")
                sInvoiceStatus = aRow.Item("vinvoice_status")
                If sInvoiceStatus = "CRE" Then
                    'No se puede eliminar contrato. Ordenes sin pagar y sin transferir
                    MsgBox("Found some open invoices associated to this contract." & vbCrLf & "All invoices using this contract info " & "must be completed," & vbCrLf & "before attempting to delete contract.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                    Exit Sub
                Else

                    sStmt = "SELECT COUNT(*) " & " FROM VInvoice ,Bcheck " & " WHERE VInvoice.invoice_no = Bcheck.invoice_no " & " AND VInvoice.cust_id = Bcheck.cust_id " & " AND VInvoice.store_id = Bcheck.store_id " & " AND VInvoice.vend_seq = Bcheck.vend_seq " & " AND VInvoice.account_no = Bcheck.account_no " & " AND VInvoice.invoice_no = '" & Trim(sInvoiceNo) & "' " & " AND VInvoice.cust_id = '" + _
                            dgStore.SelectedRows(0).Cells("cust_id").Value + "' " + _
                            " AND VInvoice.store_id = " + Str(dgStore.SelectedRows(0).Cells("store_id").Value) + _
                            " AND VInvoice.vend_seq = " + Str(dgContract.CurrentRow.Cells("vend_seq").Value) + _
                            " AND VInvoice.account_no = '" + Trim(sAccountNo) + "' " + _
                            " AND Bcheck.qb_exported_flag IS NULL "
                    cmd.CommandText = sStmt
                    'qb_exported_flag puede ser : NULL o Y

                    'MsgBox sStmt
                    rsLocalDet = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    'MsgBox Str(rsLocalDet.item(0))
                    If rsLocalDet.Rows.Count > 0 Then
                        If rsLocalDet.Rows(0).Item(0).Value = 0 Then
                            'Siguiente factura
                        Else
                            MsgBox("Found some open invoices associated to this contract." & vbCrLf & "All invoices using this contract info " & "must be completed," & vbCrLf & "before attempting to delete contract.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                            Exit Sub
                        End If
                    Else
                        MsgBox("Error found while checking contract info.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
                        Exit Sub
                    End If
                End If
                'End While
            Next aRow
        End If
		
		'Eliminar contrato
        sStmt = "DELETE FROM VContract " & " WHERE cust_id = '" + dgStore.SelectedRows(0).Cells("cust_id").Value + "' " + _
        " AND store_id = " + Str(dgStore.SelectedRows(0).Cells("store_id").Value) + _
        " AND vend_seq = " + Str(dgContract.CurrentRow.Cells("vend_seq").Value) + _
        " AND eqpt_seq = " + Str(dgEquipment.CurrentRow.Cells("eqpt_seq").Value) + _
        " AND serv_id = " + Str(dgContract.CurrentRow.Cells("serv_id").Value)
		'MsgBox sStmt
		
		cmLocal.CommandText = sStmt
        nRecords = cmLocal.ExecuteNonQuery()
		If nRecords > 0 Then
			MsgBox("Contract info successfully deleted.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "GLM Message")
			'Refresco datagrid de Contratos
            get_dgContractData(False, dgStore.SelectedRows(0).Cells("cust_id").Value, _
                                dgStore.SelectedRows(0).Cells("store_id").Value, _
                                CShort(txtVendName.Tag), dgEquipment.CurrentRow.Cells("eqpt_seq").Value)
			
		End If
		
    End Sub

    Private Sub dgEquipment_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgEquipment.CellClick
        'dgEquipment_CellContentClick(sender, e)
    End Sub

    'Private Sub dgEquipment_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgEquipment.CellClick
    '    'jp BEG 01.29.03
    '    'If dgEquipment.Row >= 0 Then
    '    'dgEquipment.SelBookmarks.Add rsEquipment.Bookmark
    '    If dgEquipment.SelectedRows.Count > 0 Then
    '        'set_dgContractData()
    '    End If
    'End Sub
    Private Sub dgEquipment_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgEquipment.CellContentClick
        'jp BEG 01.29.03
        'If dgEquipment.SelectedRows.Count = 0 Then
        '    For Each aCell As DataGridViewCell In dgEquipment.SelectedCells
        '        dgEquipment.Rows(aCell.RowIndex).Selected = True
        '    Next aCell
        'End If
        ''If dgEquipment.Row >= 0 Then
        ''dgEquipment.SelBookmarks.Add rsEquipment.Bookmark
        'If dgEquipment.SelectedRows.Count > 0 Then
        '    set_dgContractData()
        'End If
    End Sub


    Private Sub dgStore_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgStore.CellClick
        'dgStore_CellContentClick(sender, e)
    End Sub

    Private Sub dgStore_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgStore.CellContentClick
        '01/29/03
        'If dgStore.SelectedRows.Count = 0 Then
        '    For Each aCell As DataGridViewCell In dgStore.SelectedCells()
        '        dgStore.Rows(aCell.RowIndex).Selected = True
        '    Next aCell
        'End If
        ''If dgStore.Row >= 0 Then
        ''dgStore.SelBookmarks.Add rsStore.Bookmark
        'If dgStore.SelectedRows.Count > 0 Then
        '    'Busco los equipos para esta tienda
        '    'no se como implementar el bookmark.
        '    'get_dgEquipmentData(False, rsStore.Rows(dgSTore.Rows).Item("store_id").Value)
        '    get_dgEquipmentData(False, dgStore.SelectedRows(0).Cells("store_id").Value)
        '    If dgEquipment.Rows.Count > 0 Then
        '        dgEquipment.Rows(0).Selected = True
        '    End If

        '    If dgEquipment.SelectedRows.Count = 0 Then
        '        If dgEquipment.SelectedCells.Count > 0 Then
        '            dgEquipment.Rows(dgEquipment.SelectedCells(0).RowIndex).Selected = True
        '        End If
        '    End If
        '    If rsEquipment.Rows.Count > 0 Then
        '        'rsEquipment.Bookmark()
        '        'dgEquipment.SelBookmarks.Add()
        '        set_dgContractData()
        '    Else
        '        get_dgContractData(True)
        '    End If

        'End If
    End Sub

   
    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        data_entry((General.modo.NewRecord))
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        data_entry((General.modo.UpdateRecord))
    End Sub

    Private Sub btSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSearch.Click
        get_dg_defaults(False)
    End Sub

    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        delete_contract()
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub dgContract_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgContract.CellDoubleClick
        data_entry((General.modo.UpdateRecord))
    End Sub

    Private Sub dgEquipment_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgEquipment.CellEndEdit

    End Sub

    Private Sub dgEquipment_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgEquipment.CellMouseClick
        'dgEquipment_CellContentClick(sender, Nothing)
    End Sub

    Private Sub dgStore_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgStore.RowEnter
        If Not ignore_dgStore_RowEnter Then
            If dgStore.SelectedRows.Count > 1 Then
                ignore_dgStore_RowEnter = True
                Dim store_id As String = dgStore.SelectedRows(0).Cells("Store").Value
                store_id = dgStore.SelectedRows(1).Cells("Store").Value
                dgStore.SelectedRows(0).Selected = False
                ignore_dgStore_RowEnter = False
                'dgStore.CurrentCell = Nothing
            End If
            If dgStore.SelectedRows.Count > 0 Then
                'Busco los equipos para esta tienda
                'no se como implementar el bookmark.
                'get_dgEquipmentData(False, rsStore.Rows(dgSTore.Rows).Item("store_id").Value)
                get_dgEquipmentData(False, dgStore.SelectedRows(0).Cells("store_id").Value)
                If dgEquipment.SelectedRows.Count > 0 Then
                    If dgEquipment.SelectedRows(0).Index >= 0 Then
                        'rsEquipment.Bookmark()
                        'dgEquipment.SelBookmarks.Add()
                        set_dgContractData()
                    Else
                        get_dgContractData(True)
                    End If
                Else
                    get_dgContractData(True)
                End If
            End If
        End If
    End Sub

    Private Sub dgStore_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgStore.RowHeaderMouseClick
        ''dgStore_CellContentClick(sender, Nothing)
        If dgStore.SelectedRows.Count > 0 Then
            'Busco los equipos para esta tienda
            'no se como implementar el bookmark.
            'get_dgEquipmentData(False, rsStore.Rows(dgSTore.Rows).Item("store_id").Value)
            get_dgEquipmentData(False, dgStore.SelectedRows(0).Cells("store_id").Value)
            If dgEquipment.SelectedRows.Count > 0 Then
                If dgEquipment.SelectedRows(0).Index >= 0 Then
                    'rsEquipment.Bookmark()
                    'dgEquipment.SelBookmarks.Add()
                    set_dgContractData()
                Else
                    get_dgContractData(True)
                End If
            Else
                get_dgContractData(True)
            End If
        End If
    End Sub

    Private Sub dgStore_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgStore.SelectionChanged
        'Dim ignoreThisEvent As Boolean = False
        'If dgStore.SelectedRows.Count > 1 Then
        '    ignoreThisEvent = True
        '    Dim store_id As String = dgStore.SelectedRows(0).Cells("Store").Value
        '    store_id = dgStore.SelectedRows(1).Cells("Store").Value
        '    dgStore.CurrentCell = dgStore.SelectedRows(1).Cells(0)
        '    dgStore.SelectedRows(0).Selected = False
        'End If
        'If dgStore.SelectedRows.Count > 0 And Not ignoreThisEvent Then
        '    'Busco los equipos para esta tienda
        '    'no se como implementar el bookmark.
        '    'get_dgEquipmentData(False, rsStore.Rows(dgSTore.Rows).Item("store_id").Value)
        '    get_dgEquipmentData(False, dgStore.SelectedRows(0).Cells("store_id").Value)
        '    If dgEquipment.SelectedRows.Count > 0 Then
        '        If dgEquipment.SelectedRows(0).Index >= 0 Then
        '            'rsEquipment.Bookmark()
        '            'dgEquipment.SelBookmarks.Add()
        '            set_dgContractData()
        '        Else
        '            get_dgContractData(True)
        '        End If
        '    Else
        '        get_dgContractData(True)
        '    End If
        'End If


        'dgStore_RowHeaderMouseClick(sender, Nothing)
    End Sub

    Private Sub dgEquipment_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgEquipment.RowEnter
        If dgEquipment.SelectedRows.Count > 1 Then
            Dim store_id As String = dgEquipment.SelectedRows(0).Cells(0).Value
            store_id = dgEquipment.SelectedRows(1).Cells(0).Value
            dgEquipment.SelectedRows(0).Selected = False
        End If

        'If dgEquipment.SelectedRows.Count = 0 Then
        '    For Each aCell As DataGridViewCell In dgEquipment.SelectedCells
        '        dgEquipment.Rows(aCell.RowIndex).Selected = True
        '    Next aCell
        'End If
        'If dgEquipment.Row >= 0 Then
        'dgEquipment.SelBookmarks.Add rsEquipment.Bookmark
        If dgEquipment.SelectedRows.Count > 0 Then
            set_dgContractData()
        End If
    End Sub

    Private Sub dgEquipment_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgEquipment.RowHeaderMouseClick
        'jp BEG 01.29.03
        'If dgEquipment.SelectedRows.Count = 0 Then
        '    For Each aCell As DataGridViewCell In dgEquipment.SelectedCells
        '        dgEquipment.Rows(aCell.RowIndex).Selected = True
        '    Next aCell
        'End If
        'If dgEquipment.Row >= 0 Then
        'dgEquipment.SelBookmarks.Add rsEquipment.Bookmark
        If dgEquipment.SelectedRows.Count > 0 Then
            set_dgContractData()
        End If
    End Sub


    Private Sub dgStore_RowPrePaint(ByVal sender As Object, ByVal e As DataGridViewRowPrePaintEventArgs) _
Handles dgStore.RowPrePaint
        e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All)

        e.PaintHeader(DataGridViewPaintParts.Background Or _
        DataGridViewPaintParts.Border Or _
        DataGridViewPaintParts.Focus Or _
        DataGridViewPaintParts.SelectionBackground)

        e.Handled = True
    End Sub
    Private Sub dgEquipment_RowPrePaint(ByVal sender As Object, ByVal e As DataGridViewRowPrePaintEventArgs) _
Handles dgEquipment.RowPrePaint
        e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All)

        e.PaintHeader(DataGridViewPaintParts.Background Or _
        DataGridViewPaintParts.Border Or _
        DataGridViewPaintParts.Focus Or _
        DataGridViewPaintParts.SelectionBackground)

        e.Handled = True
    End Sub
    Private Sub moveToRow()
        dgEquipment.CurrentCell = dgEquipment.Rows(dgEquipment.SelectedCells(0).RowIndex - 1).Cells(0)
    End Sub
End Class