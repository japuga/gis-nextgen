Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmCustInvTemplate
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable

	
	
    Private Sub dgTemplate_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        update_template()
    End Sub
	
	Private Sub frmCustInvTemplate_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		
		load_template()
	End Sub
	
	Private Sub load_template()
		
		'UPGRADE_NOTE: Object dgTemplate.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		dgTemplate.DataSource = Nothing
		
        sStmt = "SELECT template_id, template_name 'Template', " & " Description , filename 'File Name' " & _
                " FROM CustomerInvoiceTemplate " & " WHERE 1 = 1 "
		

		If Not IsDbNull(txtTemplateName.Text) And Len(Trim(txtTemplateName.Text)) > 0 Then
			sStmt = sStmt & " AND template_name LIKE '%" & txtTemplateName.Text & "%' "
		End If
		

		If Not IsDbNull(txtDescription.Text) And Len(Trim(txtDescription.Text)) > 0 Then
			sStmt = sStmt & " AND description LIKE '%" & txtDescription.Text & "%' "
		End If
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'If rsLocal.Rows.Count > 0 Then
        dgTemplate.DataSource = rsLocal
        'End If

        dgTemplate.Columns("template_id").Visible = False

        dgTemplate.Columns("File Name").Width = VB6.TwipsToPixelsX(2000)
		
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)

        Select Case Button.Name
            Case "new"
                gCustInvTemplate.bFlag = General.modo.NewRecord

                VB6.ShowForm(frmCustInvTemplateEntry, VB6.FormShowConstants.Modal, Me)

                If gCustInvTemplate.bFlag = General.modo.SavedRecord Then
                    load_template()
                End If

            Case "save"
                update_template()

            Case "search"
                load_template()

            Case "exit"
                Me.Close()
        End Select

    End Sub
	
	
	Private Sub update_template()
        If dgTemplate.SelectedRows.Count <= 0 Then
            If dgTemplate.SelectedCells.Count > 0 Then
                dgTemplate.Rows(dgTemplate.SelectedCells(0).RowIndex).Selected = True
            Else
                MsgBox("Please select a record before attempting this command.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                Exit Sub
            End If
        End If
		
		gCustInvTemplate.bFlag = General.modo.UpdateRecord
        gCustInvTemplate.nTemplateId = dgTemplate.SelectedRows(0).Cells("template_id").Value
        gCustInvTemplate.sDescription = dgTemplate.SelectedRows(0).Cells("Description").Value
        gCustInvTemplate.sTemplateName = dgTemplate.SelectedRows(0).Cells("Template").Value
        gCustInvTemplate.sFilename = dgTemplate.SelectedRows(0).Cells("File Name").Value
		
		VB6.ShowForm(frmCustInvTemplateEntry, VB6.FormShowConstants.Modal, Me)
		
		If gCustInvTemplate.bFlag = General.modo.SavedRecord Then
			load_template()
		End If
		
	End Sub

    Private Sub dgTemplate_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTemplate.CellDoubleClick
        update_template()
    End Sub

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        gCustInvTemplate.bFlag = General.modo.NewRecord

        VB6.ShowForm(frmCustInvTemplateEntry, VB6.FormShowConstants.Modal, Me)

        If gCustInvTemplate.bFlag = General.modo.SavedRecord Then
            load_template()
        End If
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        update_template()
    End Sub

    Private Sub btSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSearch.Click
        load_template()
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub
End Class