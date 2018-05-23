Option Strict Off
Option Explicit On
Friend Class frmInvoiceNotes
	Inherits System.Windows.Forms.Form
	Private sNotesBkup As String
    Private rsLocal As DataTable
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		SaveNotes((False))
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		SaveNotes((True))
		Me.Close()
	End Sub
	
	Private Sub frmInvoiceNotes_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		InitVars()
		getNotes()
	End Sub
	'Inicializacion de Variables
	Private Sub InitVars()
		sNotesBkup = ""
		txtNotes.Text = ""

	End Sub
	
	'Busca el campo notes en la base de datos
	
	Private Sub getNotes()
		Dim sCustId As String
		Dim sStoreId As String
		Dim sAccountNo As String
		Dim nVendSeq As Short
		Dim sInvoiceNo As String
		
		'On Error GoTo ErrorHandler
		
		'SI la factura todavia no se guarda y
		'permite al usuario cambiar sus notas
		If frmInvoiceBooking.nMode = frmInvoiceBooking.mode.adInsert Then
			sNotesBkup = frmInvoiceBooking.sNotes
			txtNotes.Text = frmInvoiceBooking.sNotes
			Exit Sub
		End If
		
		sCustId = frmInvoiceBooking.cbCustomer.Text
		sStoreId = frmInvoiceBooking.txtStoreId.Text
		sAccountNo = frmInvoiceBooking.cbAccount.Text
		If frmInvoiceBooking.cbVendor.SelectedIndex >= 0 Then
			nVendSeq = VB6.GetItemData(frmInvoiceBooking.cbVendor, frmInvoiceBooking.cbVendor.SelectedIndex)
		Else
			'Error no hay datos para busqueda
		End If
		sInvoiceNo = frmInvoiceBooking.txtInvoice.Text
		
		sStmt = "SELECT notes FROM VInvoice " & "WHERE cust_id ='" & Trim(sCustId) & "' " & "AND store_id =" & Trim(sStoreId) & " " & "AND account_no ='" & Trim(sAccountNo) & "' " & "AND vend_seq =" & CStr(nVendSeq) & " " & "AND invoice_no ='" & Trim(sInvoiceNo) & "' "

		rsLocal = exec_sql(sStmt)
        If rsLocal.Rows.Count > 0 Then
            If rsLocal.Rows.Count > 0 Then
                If frmInvoiceBooking.sNotes = "" Then
                    txtNotes.Text = Trim(rsLocal.Rows(0).Item("notes"))
                Else
                    txtNotes.Text = frmInvoiceBooking.sNotes
                End If
                sNotesBkup = Trim(txtNotes.Text)
            End If
        Else
            'campo esta vacio
        End If
		Exit Sub
		
ErrorHandler: 
		save_error("frmInvoiceNotes", "getNotes")
		MsgBox("Failed to retrieve Invoice Notes." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Sub
	'Guarda las notas en la base
	Private Sub SaveNotes(ByRef bOption As Boolean)
		If bOption Then
			frmInvoiceBooking.sNotes = txtNotes.Text
		Else
			frmInvoiceBooking.sNotes = sNotesBkup
		End If
	End Sub
End Class