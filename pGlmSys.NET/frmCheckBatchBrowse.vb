Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmCheckBatchBrowse
	Inherits System.Windows.Forms.Form
    Private rsLocal As sqldatareader
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		cbCustId.SelectedIndex = cbCustName.SelectedIndex
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		If val_fields Then
			set_fields()
			Me.Close()
		End If
		
	End Sub
	Private Function val_fields() As Boolean
		val_fields = False
		On Error GoTo ErrorHandler
		
		'Customer
		If cbCustName.SelectedIndex < 0 Then
            MsgBox("Please select a Customer.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Message")
			cbCustName.Focus()
			
			Exit Function
		End If
		
		'BatchId, puede ser nulo
        If Not IsDBNull(txtBatchId.Text) Then
            If Not IsNumeric(txtBatchId.Text) And Len(Trim(txtBatchId.Text)) > 0 Then
                MsgBox("Batch Id must be a number.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                txtBatchId.Focus()
                Exit Function
            End If
        End If
		
		'Dates
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If Not IsDBNull(dtBatchFrom.Value) And Not IsDBNull(dtBatchTo.Value) Then
            If dtBatchFrom.Value > dtBatchTo.Value Then
                MsgBox("Batch Date From must be lower than To date.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Message")
                dtBatchFrom.Focus()
                val_fields = False
                Exit Function
            End If
        End If
		val_fields = True
		Exit Function
		
ErrorHandler: 
		save_error(Me.Name, "val_fields")
		MsgBox("Unexpected error found while validating data.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Function
	Private Sub set_fields()
		gCheckBatchSearch.bFlag = True
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtBatchId.Text) Then
			gCheckBatchSearch.nBatchId = 0
		ElseIf Len(Trim(txtBatchId.Text)) = 0 Then 
			gCheckBatchSearch.nBatchId = 0
		Else
			gCheckBatchSearch.nBatchId = CShort(txtBatchId.Text)
		End If
		
		gCheckBatchSearch.sCustId = cbCustId.Text
        gCheckBatchSearch.sDateFrom = build_datetime(dtBatchFrom.Value, False)
        gCheckBatchSearch.sDateTo = build_datetime(dtBatchTo.Value, True)
		
	End Sub
	Private Sub frmCheckBatchBrowse_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		'UPGRADE_WARNING: TextBox property txtBatchId.MaxLength has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		txtBatchId.Maxlength = 10
		
		sStmt = "SELECT cust_name, cust_id FROM customer " & " WHERE cust_id IN (SELECT DISTINCT cust_id " & "   FROM suser_data " & "   WHERE suser_name='" & Trim(gsUser) & "')" & " ORDER BY cust_name "
		load_cb_query2(cbCustName, sStmt, 1, True)
		
		sStmt = "SELECT cust_id, cust_name FROM customer " & " WHERE cust_id IN (SELECT DISTINCT cust_id " & "   FROM suser_data " & "   WHERE suser_name='" & Trim(gsUser) & "')" & " ORDER BY cust_name "
		load_cb_query2(cbCustId, sStmt, 1, True)
		
		If cbCustName.Items.Count > 0 Then
			cbCustName.SelectedIndex = 0
		End If
		
		dtBatchFrom.Value = Today
		dtBatchTo.Value = Today
		
		gCheckBatchSearch.bFlag = False
	End Sub
	
	
	
	Private Sub txtBatchId_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtBatchId.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Then
			'Es numero
			'No permitir ingresar mas de 2 decimales
		Else
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class