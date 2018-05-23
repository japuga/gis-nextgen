Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmVendor
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private rsTmp As DataTable
    'Private ImageList2 As New ImageList()
	
	
    Private Sub dgVendor_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        update_vendor()
        If General.gbVendorMode = General.modo.SavedRecord Then
            set_dgVendorData(True)
        End If
    End Sub
	'LLama a forma frmVendorEntry para el ingreso de datos
	Private Sub update_vendor()
		
		
        'If dgVendor.Row >= 0 Then
        If Not IsNothing(dgVendor.CurrentRow) Then
            If dgVendor.CurrentRow.Index >= 0 Then
                'MsgBox "Fila:" + Str(dgVendor.Row)
                General.gbVendorMode = General.modo.UpdateRecord
                If get_vendor() Then
                    VB6.ShowForm(frmVendorEntry, VB6.FormShowConstants.Modal, Me)
                End If
            End If
        End If

    End Sub
	'Obtiene y guarda todo el registro con los datos del Vendor
	Private Function get_vendor() As Boolean
        Dim cmd As SqlCommand = cn.CreateCommand
		clear_vendor()
		get_vendor = False
        'gVBranchRecord.nVendId = CShort(dgVendor.Columns("vend_id").Text)

        gVBranchRecord.nVendId = CShort(dgVendor.CurrentRow.Cells("vend_id").Value)
        gVBranchRecord.nVendSeq = CShort(dgVendor.CurrentRow.Cells("vend_seq").Value)
		
		sStmt = "SELECT state_id, vend_area, vend_repre," & "vend_address, vend_city, vend_zip," & "vend_phone1, vend_phone2, " & "vend_fax1, vend_fax2," & "vend_pay_address, vend_pay_city, " & "vend_pay_zip, vend_pay_phone1, vend_pay_state " & "FROM vbranch " & "WHERE vend_seq=" & Str(gVBranchRecord.nVendSeq)

		
        rsTmp = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsTmp.Rows.Count > 0 Then
            If Not IsDBNull(rsTmp.Rows(0).Item("vend_area")) Then
                gVBranchRecord.sVendArea = Trim(rsTmp.Rows(0).Item("vend_area"))
            End If

            If Not IsDBNull(rsTmp.Rows(0).Item("state_id")) Then
                gVBranchRecord.sStateId = Trim(rsTmp.Rows(0).Item("state_id"))
            End If

            If Not IsDBNull(rsTmp.Rows(0).Item("vend_repre")) Then
                gVBranchRecord.sVendRepre = Trim(rsTmp.Rows(0).Item("vend_repre"))
            End If

            If Not IsDBNull(rsTmp.Rows(0).Item("vend_address")) Then
                gVBranchRecord.sVendAddress = Trim(rsTmp.Rows(0).Item("vend_address"))
            End If

            If Not IsDBNull(rsTmp.Rows(0).Item("vend_city")) Then
                gVBranchRecord.sVendCity = Trim(rsTmp.Rows(0).Item("vend_city"))
            End If

            If Not IsDBNull(rsTmp.Rows(0).Item("vend_zip")) Then
                gVBranchRecord.sVendZip = Trim(rsTmp.Rows(0).Item("vend_zip"))
            End If

            If Not IsDBNull(rsTmp.Rows(0).Item("vend_phone1")) Then
                gVBranchRecord.sVendPhone1 = Trim(rsTmp.Rows(0).Item("vend_phone1"))
            End If

            If Not IsDBNull(rsTmp.Rows(0).Item("vend_phone2")) Then
                gVBranchRecord.sVendPhone2 = Trim(rsTmp.Rows(0).Item("vend_phone2"))
            End If

            If Not IsDBNull(rsTmp.Rows(0).Item("vend_fax1")) Then
                gVBranchRecord.sVendFax1 = Trim(rsTmp.Rows(0).Item("vend_fax1"))
            End If

            If Not IsDBNull(rsTmp.Rows(0).Item("vend_fax2")) Then
                gVBranchRecord.sVendFax2 = Trim(rsTmp.Rows(0).Item("vend_fax2"))
            End If

            If Not IsDBNull(rsTmp.Rows(0).Item("vend_pay_address")) Then
                gVBranchRecord.sVendPayAddress = Trim(rsTmp.Rows(0).Item("vend_pay_address"))
            End If

            If Not IsDBNull(rsTmp.Rows(0).Item("vend_pay_city")) Then
                gVBranchRecord.sVendPayCity = Trim(rsTmp.Rows(0).Item("vend_pay_city"))
            End If

            If Not IsDBNull(rsTmp.Rows(0).Item("vend_pay_zip")) Then
                gVBranchRecord.sVendPayZip = Trim(rsTmp.Rows(0).Item("vend_pay_zip"))
            End If

            If Not IsDBNull(rsTmp.Rows(0).Item("vend_pay_phone1")) Then
                gVBranchRecord.sVendPayPhone1 = Trim(rsTmp.Rows(0).Item("vend_pay_phone1"))
            End If

            If Not IsDBNull(rsTmp.Rows(0).Item("vend_pay_state")) Then
                gVBranchRecord.sVendPayState = Trim(rsTmp.Rows(0).Item("vend_pay_state"))
            End If
            get_vendor = True
        Else
            MsgBox("Unable to get data for Vendor:" & Trim(gVendorSearch.sVendName), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
        End If
		

        Exit Function

ErrorHandler:
        get_vendor = False
        save_error("frmVendor", "get_vendor")
        MsgBox("An unexpected error has occurred. Please check log file for details", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
	End Function
	'Limpia todo el registro
	Private Sub clear_vendor()
		gVBranchRecord.nVendId = -1
		gVBranchRecord.nVendSeq = -1
		gVBranchRecord.sQBNameCS = ""
		gVBranchRecord.sQBNameTR = ""
		gVBranchRecord.sStateId = ""
		gVBranchRecord.sVendAddress = ""
		gVBranchRecord.sVendArea = ""
		gVBranchRecord.sVendCity = ""
		gVBranchRecord.sVendFax1 = ""
		gVBranchRecord.sVendFax2 = ""
		gVBranchRecord.sVendName = ""
		gVBranchRecord.sVendPhone1 = ""
		gVBranchRecord.sVendPhone2 = ""
		gVBranchRecord.sVendRepre = ""
		gVBranchRecord.sVendZip = ""
		gVBranchRecord.sVendPayAddress = ""
		gVBranchRecord.sVendPayCity = ""
		gVBranchRecord.sVendPayZip = ""
		gVBranchRecord.sVendPayPhone1 = ""
		
	End Sub
	
	Private Sub frmVendor_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		get_data()
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button4.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "new"
                General.gbVendorMode = General.modo.NewRecord
                VB6.ShowForm(frmVendorEntry, VB6.FormShowConstants.Modal, Me)
                If General.gbVendorMode = General.modo.SavedRecord Then
                    set_dgVendorData(True)
                End If
            Case "save"
                update_vendor()
                If General.gbVendorMode = General.modo.SavedRecord Then
                    set_dgVendorData(True)
                End If
            Case "search"
                get_data()
            Case "exit"
                Me.Close()
        End Select
    End Sub
	Private Sub init_vars()
        rsLocal = Nothing
        rsTmp = Nothing
	End Sub
	'Invoca a frmVendoSearch para obtener parametros
	'para mostrar datos en Datagrid
	Private Sub get_data()
		
        VB6.ShowForm(frmVendorSearch, VB6.FormShowConstants.Modal, Me)
        'frmVendorSearch.Show()
		If gVendorSearch.bFlag Then 'Usuario ingreso parametros para query
			'Habilito botones
            Toolbar1.Items.Item("btNew").Enabled = True
            Toolbar1.Items.Item("btSave").Enabled = True
			
		Else
            'Deshabilito botones
            'btNew, btSave, btSearch, btExit
            '            Dim aname As String = Toolbar1.Items.Item(0).Name

            Toolbar1.Items.Item("btNew").Enabled = False
            Toolbar1.Items.Item("btSave").Enabled = False
			
		End If
		'Corro query y cargo datos al Datagrid
        set_dgVendorData(gVendorSearch.bFlag)
		
	End Sub
	
    Private Sub set_dgVendorData(ByRef bFlag As Boolean)
        Dim bFound As Boolean
        Dim rsLocal As DataTable

        Try

            If bFlag Then
                lbVendor.Text = Trim(gVendorSearch.sVendName) & " - Branches"
                lbState.Text = "State - " & gVendorSearch.sStateId
                sStmt = "SELECT vbranch.vend_seq, vbranch.vend_id, " & "vbranch.vend_area AS Area, state_id AS State, " & _
                                "vbranch.vend_address AS Address, " & "vbranch.vend_city AS City, vbranch.vend_zip AS Zip " & _
                        "FROM vbranch " & "WHERE vend_id =" & Str(gVendorSearch.nVendId) & " "


                If gVendorSearch.sStateId = "<All>" Then
                    'No se agrega condicion para State
                Else
                    sStmt = Trim(sStmt) & " AND state_id ='" & gVendorSearch.sStateId & "' "
                End If

                sStmt = Trim(sStmt) & " ORDER BY vend_area, state_id, vend_city"

            Else
                'Este query es solo para mostrar los titulos de los campos en Datagrid
                lbVendor.Text = "Vendor Branches"
                lbState.Text = ""
                sStmt = "SELECT vbranch.vend_seq, vbranch.vend_id, " & "vbranch.vend_area AS Area, state_id AS State," & "vbranch.vend_address AS Address, " & "vbranch.vend_city AS City, vbranch.vend_zip AS Zip " & "FROM vbranch " & "WHERE vend_id =-1"
            End If

            'UPGRADE_NOTE: Object dgVendor.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            dgVendor.DataSource = Nothing

            rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            'search
            'If rsLocal.State = adStateOpen Then
            '    If rsLocal.RecordCount > 0 Then
            '        Do While Not rsLocal.EOF
            '            If rsLocal.item("vend_id") Then
            '               bFound = False

            If rsLocal.Rows.Count > 0 Then
                For row As Integer = 0 To rsLocal.Rows.Count - 1
                    Dim astr As String = rsLocal.Rows(row).Item("vend_id")
                    astr = gVBranchRecord.nVendId
                    If rsLocal.Rows(row).Item("vend_id") = gVBranchRecord.nVendId And rsLocal.Rows(row).Item("vend_seq") = gVBranchRecord.nVendSeq Then
                        bFound = True
                        Exit For
                    End If

                Next row

            End If



            dgVendor.DataSource = rsLocal

            If rsLocal.Rows.Count > 0 Then
                If bFound = False Then

                End If
                'dgVendor.SelBookmarks.Add((rsLocal.Bookmark))
            End If




            dgVendor.Columns("vend_seq").Visible = False
            dgVendor.Columns("vend_id").Visible = False
            'Formato de columnas en datagrid.
            dgVendor.Columns("Area").Width = VB6.TwipsToPixelsX(1200)
            dgVendor.Columns("Address").Width = VB6.TwipsToPixelsX(2500)
            dgVendor.Columns("City").Width = VB6.TwipsToPixelsX(900)
            dgVendor.Columns("Zip").Width = VB6.TwipsToPixelsX(1000)
            dgVendor.Columns("State").Width = VB6.TwipsToPixelsX(500)
            Exit Sub

        Catch ex As Exception
            save_error(Me.Name, "set_dgVendor")
            MsgBox("An unexpected has occurred:" & ex.Message & " Please check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
        End Try
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        General.gbVendorMode = General.modo.NewRecord
        VB6.ShowForm(frmVendorEntry, VB6.FormShowConstants.Modal, Me)
        If General.gbVendorMode = General.modo.SavedRecord Then
            set_dgVendorData(True)
        End If
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        update_vendor()
        If General.gbVendorMode = General.modo.SavedRecord Then
            set_dgVendorData(True)
        End If
    End Sub

    Private Sub btSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSearch.Click
        get_data()
    End Sub


    Private Sub dgVendor_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgVendor.CellDoubleClick
        update_vendor()
        If General.gbVendorMode = General.modo.SavedRecord Then
            set_dgVendorData(True)
        End If
    End Sub
End Class
