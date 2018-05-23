Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmStoreSearch
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
	
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		cbCustId.SelectedIndex = cbCustName.SelectedIndex
		
		'Cargo el combo cbState
		cbState.Items.Clear()
		cbState.Items.Insert(0, "<All>")
		
		sStmt = "SELECT DISTINCT state_id FROM suser_data " & "WHERE suser_name='" & Trim(gsUser) & "' " & "AND cust_id='" & Trim(cbCustId.Text) & "' "
		load_cb_query2(cbState, sStmt, 1, False)
		
		cbState.SelectedIndex = 0
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        If gbStoreSearch.bFlag <> True Then
            gbStoreSearch.bFlag = False
        End If
		Me.Close()
	End Sub
	
	Private Sub cmOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmOk.Click
		gbStoreSearch.bFlag = True
		gbStoreSearch.sCustId = cbCustId.Text
		gbStoreSearch.sStateId = cbState.Text
		gbStoreSearch.sCustName = cbCustName.Text
		Me.Close()
	End Sub
	
	Private Sub frmStoreSearch_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		load_comp()
	End Sub
	Private Sub init_vars()

        'Inicializo parametros de retorno
        If gbStoreSearch.bFlag <> True Then
            gbStoreSearch.bFlag = False
            gbStoreSearch.sCustId = ""
            gbStoreSearch.sCustName = ""
            gbStoreSearch.sStateId = ""
        End If
    End Sub
	Private Sub load_comp()
		Dim nCounter As Short
		nCounter = 0
		
		'Combos cbCustId, cbCustName
		sStmt = "SELECT DISTINCT suser_data.cust_id, customer.cust_name " & "FROM customer, suser_data " & "WHERE customer.cust_id = suser_data.cust_id " & "AND suser_data.suser_name='" & Trim(gsUser) & "'" & " ORDER BY customer.cust_name "
		
        Try
            rsLocal = exec_sql(sStmt)
            If rsLocal.Rows.Count <= 0 Then
                MsgBox("Your Account does not have access to such Information." & vbCrLf & "Contact your System Administrator to get proper access.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Your Account does not have access to such Information." & vbCrLf & "Contact your System Administrator to get proper access.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
            Exit Sub
        End Try
		
		'En caso de haber datos
		cbCustId.Items.Clear()
		cbCustName.Items.Clear()
        For row As Integer = 0 To rsLocal.Rows.Count - 1
            cbCustId.Items.Insert(nCounter, rsLocal.Rows(row).Item("cust_id"))
            cbCustName.Items.Insert(nCounter, rsLocal.Rows(row).Item("cust_name"))
            nCounter = nCounter + 1
        Next row
		
		
		cbCustName.SelectedIndex = 0
		
	End Sub
End Class