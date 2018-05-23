Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmVendorBrowse
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		gVendorSearch.bFlag = False
		Me.Close()
	End Sub
	
	Private Sub cmdSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSearch.Click
        set_dgVendorData(True)
	End Sub
    Private Sub set_dgVendorData(ByRef bParamProvided As Boolean)

        sStmt = "SELECT vend_id, vend_seq, " & "vend_name AS Vendor, vend_area AS Area, " & _
        "state_id AS State, vend_address AS Address," & "vend_city AS City, vend_zip AS Zip " & " FROM vbranch "

        If bParamProvided Then
            'Condicion Vendor
            If cbVendor.SelectedIndex >= 0 Then
                sStmt = sStmt & " WHERE vend_id = " & Str(VB6.GetItemData(cbVendor, cbVendor.SelectedIndex))
            Else
                'UPGRADE_NOTE: Object dgVendor.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                dgVendor.DataSource = Nothing
                Exit Sub
            End If

            'Condicion State
            If cbState.SelectedIndex = 0 Then 'ALL
                'Todos los estados
            Else
                sStmt = sStmt & " AND state_id ='" & cbState.Text & "'"
            End If

            'ORDER BY
            sStmt = sStmt & " ORDER BY state_id, vend_area"
        Else
            'Para inicializar Datagrid
            sStmt = sStmt & " WHERE vend_id = -1 "
        End If

        
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsLocal.rows.count > 0 Then
            dgVendor.DataSource = rsLocal
        Else
            If bParamProvided Then
                MsgBox("Error while accesing Vendor Info.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                Exit Sub
            End If
            dgVendor.DataSource = rsLocal
        End If


        dgVendor.Columns("vend_id").Visible = False
        dgVendor.Columns("vend_seq").Visible = False
        'Formato de dgVendor
        dgVendor.Columns("Vendor").Width = VB6.TwipsToPixelsX(1300)
        dgVendor.Columns("Area").Width = VB6.TwipsToPixelsX(1700)
        dgVendor.Columns("State").Width = VB6.TwipsToPixelsX(700)
        dgVendor.Columns("Address").Width = VB6.TwipsToPixelsX(2200)
        dgVendor.Columns("City").Width = VB6.TwipsToPixelsX(1200)
        dgVendor.Columns("Zip").Width = VB6.TwipsToPixelsX(900)
    End Sub
	
	Private Sub cmOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmOk.Click
		save_selected()
	End Sub
	'Guarda los valores escogidos del datagrid en variables glob
	Private Sub save_selected()
        If dgVendor.CurrentRow.Index >= 0 Then

            gVendorSearch.bFlag = True
            gVendorSearch.nVendId = rsLocal.Rows(dgVendor.CurrentRow.Index).Item("vend_id")
            gVendorSearch.sStateId = rsLocal.Rows(dgVendor.CurrentRow.Index).Item("State")
            gVendorSearch.sVendName = Trim(rsLocal.Rows(dgVendor.CurrentRow.Index).Item("Vendor")) & " - " & Trim(rsLocal.Rows(dgVendor.CurrentRow.Index).Item("Area"))
            gVendorSearch.nVendSeq = rsLocal.Rows(dgVendor.CurrentRow.Index).Item("vend_seq")
            'dgVendor.SelBookmarks.Add rsLocal.Bookmark
            'Solo cerramos forma si selecciono algo
            Me.Close()
        End If
		
	End Sub
	
    Private Sub dgVendor_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        save_selected()
    End Sub
	
	Private Sub frmVendorBrowse_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	Private Sub init_vars()
        rsLocal = Nothing
		
		'Inicializo variables globales
		gVendorSearch.bFlag = False
		gVendorSearch.nVendId = -1
		gVendorSearch.sStateId = ""
		gVendorSearch.sVendName = ""
		gVendorSearch.nVendSeq = -1
		
		
		'Combo Vendor
		sStmt = "SELECT vend_name, vend_id FROM vendor ORDER BY vend_name"
		load_cb_query(cbVendor, sStmt, 2)
		
        'Combo State
        cbState.Items.Clear()
		cbState.Items.Insert(0, "<All>")
		sStmt = "SELECT state_id FROM state"
		load_cb_query2(cbState, sStmt, 1, False)
		
		'Defaults
		If cbVendor.Items.Count > 0 Then
			cbVendor.SelectedIndex = 0
		End If
		If cbState.Items.Count > 0 Then
			cbState.SelectedIndex = 0
		End If
		
		'Inicializo Datagrid
        set_dgVendorData(False)
		
    End Sub

    Private Sub dgVendor_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgVendor.CellContentDoubleClick
        save_selected()
    End Sub
End Class