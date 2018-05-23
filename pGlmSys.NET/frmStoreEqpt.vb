Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmStoreEqpt
	Inherits System.Windows.Forms.Form
    Private rsLocal As SqlDataReader
    Private rsStore As DataTable
    Private rsStoreEqpt As DataTable
    Private ImageList2 As New ImageList()
	
    Private Sub dgStore_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Solo si hay datos en el datagrid dgStore buscamos para dgStoreEqpt
        If dgStore.SelectedRows.Count = 0 Then
            If dgStore.SelectedCells.Count > 0 Then
                dgStore.Rows(dgStore.SelectedCells(0).RowIndex).Selected = True
            End If
        End If
        'If dgStore.Row >= 0 Then
        If dgStore.SelectedRows.Count > 0 Then
            set_dgStoreEqptData(True, CShort(dgStore.SelectedRows(0).Cells("store_id").Value), dgStore.SelectedRows(0).Cells("Store").Value)
        End If
    End Sub
	
    Private Sub dgStoreEqpt_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        update_storeEqpt()
        If General.gbStoreEqptMode = General.modo.SavedRecord Then
            set_dgStoreData(True)
        End If
    End Sub
	'Actualiza Equipo
	Private Sub update_storeEqpt()
        If dgStoreEqpt.SelectedRows(0).Index >= 0 Then
            Dim ds As DataSet = New DataSet()

            'no se como funciona bookmark
            'dgStoreEqpt.SelBookmarks.Add(rsStoreEqpt.Bookmark)
            General.gbStoreEqptMode = General.modo.UpdateRecord
            If get_storeEqpt(General.gbStoreEqptMode) = True Then
                VB6.ShowForm(frmStoreEqptEntry, VB6.FormShowConstants.Modal, Me)
            End If
        End If
	End Sub
	'Guarda los datos del equipo para Actualizarlos en frmStoreEqptEntry
	Private Function get_storeEqpt(ByRef bFlag As General.modo) As Boolean
        'gStoreEqptRecord.sCustId = Trim(rsStoreEqpt.item("cust_id"))
        'gStoreEqptRecord.nStoreId = rsStoreEqpt.item("store_id")
		'gStoreEqptRecord.sCustName = gbStoreSearch.sCustName
        'gStoreEqptRecord.sStoreNumber = rsLocal.item("Store")
		
		On Error GoTo ErrorHandler
		
		get_storeEqpt = True 'Ok por defecto
        'gStoreEqptRecord.sCustId = Trim(rsStore.Rows(0).Item("cust_id"))
        gStoreEqptRecord.sCustId = Trim(dgStore.SelectedRows(0).Cells("cust_id").Value) 'rsStore.Rows(0).Item("cust_id"))
        gStoreEqptRecord.nStoreId = dgStore.SelectedRows(0).Cells("store_id").Value
		gStoreEqptRecord.sCustName = gbStoreSearch.sCustName
        gStoreEqptRecord.sStoreNumber = dgStore.SelectedRows(0).Cells("Store").Value
		
		If bFlag = General.modo.UpdateRecord Then
            gStoreEqptRecord.nEqptSeq = dgStoreEqpt.SelectedRows(0).Cells("eqpt_seq").Value
            gStoreEqptRecord.nEqptId = dgStoreEqpt.SelectedRows(0).Cells("eqpt_id").Value
            gStoreEqptRecord.sLoadId = dgStoreEqpt.SelectedRows(0).Cells("load_id").Value
			
            gStoreEqptRecord.sEqptStatus = dgStoreEqpt.SelectedRows(0).Cells("Status").Value
            gStoreEqptRecord.sEqptDesc = dgStoreEqpt.SelectedRows(0).Cells("Equip").Value
            gStoreEqptRecord.nContentId = dgStoreEqpt.SelectedRows(0).Cells("content_id").Value
            gStoreEqptRecord.nEqptQty = dgStoreEqpt.SelectedRows(0).Cells("Qty").Value
            gStoreEqptRecord.nEqptSizeCapacity = dgStoreEqpt.SelectedRows(0).Cells("eqpt_size_capacity").Value
            gStoreEqptRecord.nEqptActualQty = dgStoreEqpt.SelectedRows(0).Cells("eqpt_actual_qty").Value
			
            If IsDBNull(dgStoreEqpt.SelectedRows(0).Cells("eqpt_temp").Value) Then
                gStoreEqptRecord.sEqptTemp = ""
            Else
                gStoreEqptRecord.sEqptTemp = dgStoreEqpt.SelectedRows(0).Cells("eqpt_temp").Value
            End If
		End If
		Exit Function
		
ErrorHandler: 
		
		save_error(Me.Name, "get_storeEqpt")
		get_storeEqpt = False
		MsgBox("Unexpected error when loading Store Eqpt Form." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Function
	Private Sub frmStoreEqpt_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		get_data()
	End Sub
	
	Private Sub init_vars()
        General.gbStoreEqptMode = General.modo.NewRecord
	End Sub
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button4.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "new"
                General.gbStoreEqptMode = General.modo.NewRecord
                'If dgStoreEqpt.Row >= 0 Then
                If get_storeEqpt(General.gbStoreEqptMode) = True Then

                    VB6.ShowForm(frmStoreEqptEntry, VB6.FormShowConstants.Modal, Me)
                    If General.gbStoreEqptMode = General.modo.SavedRecord Then
                        set_dgStoreData(True)
                    End If
                End If

                'End If

            Case "save"
                update_storeEqpt()
                If General.gbStoreEqptMode = General.modo.SavedRecord Then
                    set_dgStoreData(True)
                End If
            Case "search"
                get_data()
            Case "exit"
                Me.Close()
        End Select
    End Sub
	
	'Invoca a frmVendorSearch para obtener parametros
	'para mostrar datos en Datagrid
	Private Sub get_data()
		
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
	
	'Ejecuta query usando parametros de StoreSearch
	'para cargar a Datagrid
    Private Sub set_dgStoreData(ByRef bFlag As Boolean)

        On Error GoTo ErrorHandler

        If bFlag Then
            lbCustomer.Text = Trim(gbStoreSearch.sCustName) & " - Stores"
            lbState.Text = "State - " & gbStoreSearch.sStateId
            sStmt = "SELECT store.cust_id, store.store_id, " & "store.store_number AS Store, store_name AS Name," & "store_address AS Address, store_city AS City, " & "store_zip AS Zip " & "FROM store " & "WHERE cust_id ='" & gbStoreSearch.sCustId & "' "

            If gbStoreSearch.sStateId = "<All>" Then
                'No se agrega condicion para State
                '1.8.8 Solo estados con permiso
                sStmt = Trim(sStmt) & " AND state_id IN (SELECT state_id " & " FROM suser_data " & " WHERE suser_name ='" & Trim(gsUser) & "' " & " AND cust_id ='" & gbStoreSearch.sCustId & "') "
            Else
                sStmt = Trim(sStmt) & "AND state_id = '" & gbStoreSearch.sStateId & "' "
            End If

            sStmt = Trim(sStmt) & " ORDER BY store_number"

        Else
            'Este query es solo para mostrar los titulos de los campos en Datagrid
            lbCustomer.Text = "Stores"
            lbState.Text = ""
            sStmt = "SELECT store.cust_id, store.store_id, " & "store.store_number AS Store, store_name AS Name," & "store_address AS Address, store_city AS City, " & "store_zip AS Zip " & "FROM store " & "WHERE cust_id ='00' "


        End If
        'dgStore.DataSource = Nothing

        rsStore = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


        dgStore.DataSource = rsStore
        dgStore.Columns("store_id").Visible = False
        dgStore.Columns("cust_id").Visible = False

        'Formato de columnas en datagrid.
        dgStore.Columns("Store").Width = VB6.TwipsToPixelsX(800)
        dgStore.Columns("Address").Width = VB6.TwipsToPixelsX(2500)
        dgStore.Columns("City").Width = VB6.TwipsToPixelsX(900)
        dgStore.Columns("Zip").Width = VB6.TwipsToPixelsX(1000)

        'search
        If rsStore.Rows.Count > 0 Then
            'StoreEqpt se actualizo sin problema
            If General.gbStoreEqptMode = General.modo.SavedRecord Then
                For row As Integer = 0 To rsStore.Rows.Count - 1
                    If rsStore.Rows(row).Item("store_id") = gStoreEqptRecord.nStoreId Then
                        'bookmark como funciona
                        'dgStore.SelBookmarks.Add(rsStore.Rows.Bookmark)
                        If dgStore.SelectedRows.Count > 0 Then
                            dgStore.SelectedRows(0).Selected = False
                        End If
                        dgStore.Rows(row).Selected = True
                        set_dgStoreEqptData(True, CShort(dgStore.Rows(row).Cells("store_id").Value), _
                                                  dgStore.Rows(row).Cells("Store").Value)
                        Exit For
                    End If
                Next row
                
            Else
                'If Not IsNull(dgStore.Columns("store_id")) Then
                'dgStore.SelBookmarks.Add(rsStore.Bookmark)
                set_dgStoreEqptData(True, CShort(dgStore.Rows(0).Cells("store_id").Value), _
                                                 dgStore.Rows(0).Cells("Store").Value)
                'End If
                dgStore.Rows(0).Selected = True
            End If
        Else
            set_dgStoreEqptData(False)
        End If
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "set_dgStoreEqpt")
        MsgBox("An unexpected error has occurred, check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")

    End Sub
	
	'Carga datos en el Datagrid de Equipos
    Private Sub set_dgStoreEqptData(ByRef bFlag As Boolean, Optional ByRef nStoreId As Short = 0, Optional ByRef sStoreNumber As String = "")
        Dim bFound As Boolean

        On Error GoTo ErrorHandler

        If bFlag Then
            lbEquipment.Text = "Equipment Assigned - Store " & Trim(sStoreNumber)

            sStmt = "SELECT se.cust_id AS cust_id, se.store_id, " & "se.eqpt_seq, se.eqpt_id, se.load_id, " & "eqpt_desc AS Equip, se.eqpt_status AS Status, " & "se.content_id, content.content_desc AS Content,  " & "se.load_id AS 'Load Type', se.eqpt_qty AS Qty, se.eqpt_temp, " & "se.eqpt_size_capacity, se.eqpt_actual_qty " & "FROM storeEqpt se, content " & " WHERE se.content_id  = content.content_id " & " AND se.cust_id = '" & gbStoreSearch.sCustId & "'" & " AND se.store_id = " & Str(nStoreId) & " " & " ORDER BY Equip "


        Else
            'Inicializar el Datagrid
            lbEquipment.Text = "Equipment Assigned "
            sStmt = "SELECT se.cust_id, se.store_id, " & "se.eqpt_seq, se.eqpt_id, se.load_id, " & "eqpt_desc AS Equip, se.eqpt_status AS Status, " & "se.content_id, content.content_desc AS Content, " & "se.load_id AS 'Load Type', se.eqpt_qty AS Qty, se.eqpt_temp, " & "se.eqpt_size_capacity, se.eqpt_actual_qty " & "FROM storeEqpt se, content " & "WHERE se.content_id  = content.content_id " & "AND se.cust_id = '00' " & "ORDER BY Equip "


        End If

        'UPGRADE_NOTE: Object dgStoreEqpt.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'dgStoreEqpt.DataSource = Nothing
        dgStoreEqpt.Text = "Equipment"

        rsStoreEqpt = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        dgStoreEqpt.DataSource = rsStoreEqpt

        'search
        bFound = False

        If rsStoreEqpt.Rows.Count > 0 Then
            If General.gbStoreEqptMode = General.modo.SavedRecord Then
                For row As Integer = 0 To rsStoreEqpt.Rows.Count - 1
                    If rsStoreEqpt.Rows(row).Item("store_id") = gStoreEqptRecord.nStoreId And rsStoreEqpt.Rows(row).Item("cust_id") = gStoreEqptRecord.sCustId And rsStoreEqpt.Rows(row).Item("eqpt_seq") = gStoreEqptRecord.nEqptSeq Then
                        'no se como hacer bookmark
                        'dgStoreEqpt.SelBookmarks.Add((rsStoreEqpt.Rows(row).Bookmark))
                        dgStoreEqpt.Rows(row).Selected = True
                        dgStoreEqpt.CurrentCell = dgStoreEqpt.Rows(row).Cells("Equip")
                        bFound = True
                        Exit For
                    End If
                Next row
                
                'Store-Eqpt no se encontro
                If bFound = False Then
                    dgStoreEqpt.Rows(0).Selected = True '.SelBookmarks.Add((rsStoreEqpt.Bookmark))
                End If
            Else
                dgStoreEqpt.Rows(0).Selected = True
                'dgStoreEqpt.SelBookmarks.Add((rsStoreEqpt.Bookmark))
            End If
        End If


        'Escondo Columnas
        dgStoreEqpt.Columns("cust_id").Visible = False
        dgStoreEqpt.Columns("store_id").Visible = False
        dgStoreEqpt.Columns("eqpt_seq").Visible = False
        dgStoreEqpt.Columns("eqpt_id").Visible = False
        dgStoreEqpt.Columns("load_id").Visible = False
        dgStoreEqpt.Columns("content_id").Visible = False
        dgStoreEqpt.Columns("eqpt_temp").Visible = False
        dgStoreEqpt.Columns("eqpt_size_capacity").Visible = False
        dgStoreEqpt.Columns("eqpt_actual_qty").Visible = False

        'Fomato de Columnas
        dgStoreEqpt.Columns("Equip").Width = VB6.TwipsToPixelsX(2500)
        dgStoreEqpt.Columns("Status").Width = VB6.TwipsToPixelsX(650)
        dgStoreEqpt.Columns("Content").Width = VB6.TwipsToPixelsX(1500)
        dgStoreEqpt.Columns("Qty").Width = VB6.TwipsToPixelsX(1000)


        Exit Sub

ErrorHandler:
        save_error(Me.Name, "set_dgStoreEqpt")
        MsgBox("An unexpected error has occurred, check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
    End Sub

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click

        General.gbStoreEqptMode = General.modo.NewRecord
        'If dgStoreEqpt.Row >= 0 Then
        If get_storeEqpt(General.gbStoreEqptMode) = True Then

            VB6.ShowForm(frmStoreEqptEntry, VB6.FormShowConstants.Modal, Me)
            If General.gbStoreEqptMode = General.modo.SavedRecord Then
                set_dgStoreData(True)
            End If
        End If

    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        If dgStore.SelectedRows.Count < 1 Then
            MsgBox("Please select a store before continuing.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Sub
        End If
        If dgStoreEqpt.SelectedRows.Count > 0 And dgStore.Rows.Count > 0 Then
            update_storeEqpt()
            If General.gbStoreEqptMode = General.modo.SavedRecord Then
                set_dgStoreData(True)
            End If
        End If
    End Sub

    Private Sub btSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSearch.Click
        get_data()
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub dgStore_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgStore.CellClick
        'Solo si hay datos en el datagrid dgStore buscamos para dgStoreEqpt
        If dgStore.SelectedRows.Count = 0 Then
            If dgStore.SelectedCells.Count > 0 Then
                dgStore.Rows(dgStore.SelectedCells(0).RowIndex).Selected = True
            End If
        End If
        'If dgStore.Row >= 0 Then
        If dgStore.SelectedRows.Count > 0 Then
            set_dgStoreEqptData(True, CShort(dgStore.SelectedRows(0).Cells("store_id").Value), dgStore.SelectedRows(0).Cells("Store").Value)
        End If
    End Sub

    Private Sub dgStore_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgStore.CellContentClick
        'Solo si hay datos en el datagrid dgStore buscamos para dgStoreEqpt
        If dgStore.SelectedRows.Count = 0 Then
            If dgStore.SelectedCells.Count > 0 Then
                dgStore.Rows(dgStore.SelectedCells(0).RowIndex).Selected = True
            End If
        End If
        'If dgStore.Row >= 0 Then
        If dgStore.SelectedRows.Count > 0 Then
            set_dgStoreEqptData(True, CShort(dgStore.SelectedRows(0).Cells("store_id").Value), dgStore.SelectedRows(0).Cells("Store").Value)
        End If
    End Sub

    Private Sub dgStoreEqpt_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgStoreEqpt.CellDoubleClick
        If dgStoreEqpt.SelectedRows.Count = 0 Then
            If dgStoreEqpt.SelectedCells.Count > 0 Then
                dgStoreEqpt.Rows(dgStoreEqpt.SelectedCells(0).RowIndex).Selected = True
            End If
        End If
        update_storeEqpt()
        If General.gbStoreEqptMode = General.modo.SavedRecord Then
            set_dgStoreData(True)
        End If
    End Sub

    Private Sub dgStore_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgStore.RowEnter
        'Solo si hay datos en el datagrid dgStore buscamos para dgStoreEqpt
        If dgStore.SelectedRows.Count = 0 Then
            If dgStore.SelectedCells.Count > 0 Then
                dgStore.Rows(dgStore.SelectedCells(0).RowIndex).Selected = True
            End If
        End If
        'If dgStore.Row >= 0 Then
        If dgStore.SelectedRows.Count > 0 Then
            set_dgStoreEqptData(True, CShort(dgStore.SelectedRows(0).Cells("store_id").Value), dgStore.SelectedRows(0).Cells("Store").Value)
        End If
    End Sub
End Class