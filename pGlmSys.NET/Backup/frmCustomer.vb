Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmCustomer
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    'Private ImageList2 As New ImageList()
	
    Private Sub dgCustomer_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)


        If dgCustomer.SelectedRows.Count() > 0 Then
            update_customer(dgCustomer.CurrentRow.Cells("id").Value)
        Else
            MsgBox("You must select a customer before attempting this command.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
            Exit Sub
        End If

    End Sub
    Private Sub update_customer(ByRef sCustId As String)

        gCustomerRecord.bFlag = General.modo.UpdateRecord
        'UPGRADE_WARNING: Couldn't resolve default property of object sCustId. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        gCustomerRecord.sCustId = sCustId
        VB6.ShowForm(frmCustomerEntry, VB6.FormShowConstants.Modal, Me)

        If gCustomerRecord.bFlag = General.modo.SavedRecord Then
            load_dgCustomer()
        End If

    End Sub
	Private Sub frmCustomer_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
        rsLocal = Nothing

		load_dgCustomer()
	End Sub
	
	Private Sub load_dgCustomer()
		
		'On Error GoTo ErrorHandler

		sStmt = "SELECT cust_id AS 'ID', state_id AS 'State'," & " cust_name AS Name," & "cust_contact AS Contact, cust_address AS Address, " & "cust_city AS City" & " FROM customer "
		
		'UPGRADE_NOTE: Object dgCustomer.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		dgCustomer.DataSource = Nothing
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'Dim ds As DataSet = New DataSet("dsTmp")
        'ds = getDataSet(sStmt)
        If rsLocal.Rows.Count > 0 Then
            dgCustomer.DataSource = rsLocal
            'dgCustomer.DataSource = ds
        Else
            Exit Sub
        End If
        Try
            'Formato
            Dim aNum As Integer = VB6.TwipsToPixelsX(400)
            'dgCustomer.Columns("").Width = 
            dgCustomer.Columns("ID").Width = aNum 'VB6.TwipsToPixelsX(400)
            dgCustomer.Columns("State").Width = VB6.TwipsToPixelsX(400)
            dgCustomer.Columns("Name").Width = VB6.TwipsToPixelsX(1200)
            dgCustomer.Columns("Contact").Width = VB6.TwipsToPixelsX(1200)
            dgCustomer.Columns("Address").Width = VB6.TwipsToPixelsX(1200)
            dgCustomer.Columns("City").Width = VB6.TwipsToPixelsX(1000)
        Catch ex As Exception
            save_error(Me.Name, "load_dgCustomer")
            MsgBox("Failed to access Customer table. " & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
        End Try
		
		
		Exit Sub
		
    End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button5.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "new"
                add_customer()
            Case "save"
                If dgCustomer.SelectedRows.Count() > 0 Then
                    update_customer(dgCustomer.CurrentRow.Cells("id").Value)
                Else
                    MsgBox("You must select a customer before attempting this command.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                End If
            Case "exit"
                Me.Close()
        End Select

    End Sub
	
	Private Sub add_customer()
		
		gCustomerRecord.bFlag = General.modo.NewRecord
		VB6.ShowForm(frmCustomerEntry, VB6.FormShowConstants.Modal, Me)
		
		If gCustomerRecord.bFlag = General.modo.SavedRecord Then
			load_dgCustomer()
		End If
		
	End Sub

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        add_customer()
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        If dgCustomer.SelectedCells.Count() > 0 Then
            Dim str As String = dgCustomer.CurrentRow.Cells("id").Value
            update_customer(dgCustomer.CurrentRow.Cells("id").Value)
        Else
            MsgBox("You must select a customer before attempting this command.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
            Exit Sub
        End If
    End Sub

    Private Sub dgCustomer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCustomer.CellDoubleClick
        If dgCustomer.SelectedCells.Count() > 0 Then
            Dim str As String = dgCustomer.CurrentRow.Cells("id").Value
            update_customer(dgCustomer.CurrentRow.Cells("id").Value)
        Else
            MsgBox("You must select a customer before attempting this command.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
            Exit Sub
        End If
    End Sub
End Class