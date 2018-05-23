Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmReport
	Inherits System.Windows.Forms.Form
	
	'UPGRADE_WARNING: Event cbCustomer.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustomer_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustomer.SelectedIndexChanged
		If cbCustomer.SelectedIndex >= 0 Then
			sStmt = "SELECT DISTINCT format_name FROM RepCust " & "WHERE cust_id ='" & cbCustomer.Text & "'"
			load_cb_query(cbVersion, sStmt, 1)
		Else
			cbVersion.Text = ""
			cbVersion.Items.Clear()
			cbVersion.Refresh()
		End If
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		bOk = False
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		'Validaciones
		'Verifico que se haya seleccionado un cliente
		If cbCustomer.SelectedIndex < 0 Then
			MsgBox("You must choose a customer for the report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "Warning")
			Exit Sub
		End If
		
		'Verifico que se haya seleccionado la version del reporte
		If cbVersion.SelectedIndex < 0 Then
			MsgBox("You must choose a report version.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "Warning")
			Exit Sub
		End If
		
		'Guardo los valores de los parametros
		sCustomer = cbCustomer.Text
		sReport = cbReport.Text
		sVersion = cbVersion.Text
		sState = cbState.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object dtStart._Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dStart = dtStart._Value
		'UPGRADE_WARNING: Couldn't resolve default property of object dtEnd._Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dEnd = dtEnd._Value
		
		bOk = True
		'CAMBIAR
		'Unload Me
	End Sub
	
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		map_data()
		load_report()
	End Sub
	
	Private Sub frmReport_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		load_cb(cbState, grsState)
		load_cb(cbCustomer, grsCustomer)
		load_cb_query(cbReport, "SELECT rep_caption, rep_no FROM RepDef", 2)
		set_cb(cbReport, gReport.name)
		set_defaults()
		If gReport.static_Renamed Then
			cbReport.Visible = False
			txtReport.Visible = True
			txtReport.Text = gReport.name
			txtReport.SetBounds(cbReport.Left, cbReport.Top, 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
		Else
			cbReport.Visible = True
			txtReport.Visible = False
		End If
		
		
	End Sub
	
	Private Sub frmReport_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		gReport.static_Renamed = True
	End Sub
	
	Private Sub set_defaults()
		dtStart._Value = Today
		dtEnd._Value = Today
		
	End Sub
	'BORRAR
	Private Function load_report() As Boolean
        Dim rsReport As Object = New Object()

		'UPGRADE_NOTE: report was upgraded to report_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        MsgBox("load_report")
		'ADO
		'Set cn = New ADODB.Connection
        'Set AdoRs = New SqlDataReader
		
		'cn.Provider = "SQLOLEDB"
		'cn.ConnectionString = "User Id=sa;Password=sa;" + _
		''    "Initial Catalog=glm;Data Source=jpuentelap1;"
		'cn.Open
		
		
		'AdoRs.Open "select store_id, store_name,store_address," + _
		'"store_city from store", cn
		'MsgBox AdoRs(2)
		
		'Abro el archivo con el reporte
		
		'reportTable.SetPrivateData 3, AdoRS
		
	End Function
	
	Private Function map_data() As Boolean
        'rsFields = New SqlDataReader
		'On Error GoTo ErrorHandler
		
		'Este rs fue previamente cargado por map_fields
        If rsFields.Rows.Count > 0 Then

            sStmt = "SELECT 'ND' as cust_name,'SEPTEMBER' AS month_year, "
            'While rsFields.Read()
            '    sStmt = Trim(sStmt) & " " & Trim(rsFields.Item("col_map").Value) & ", "
            'End While

            For arow As Integer = 0 To rsFields.Rows.Count - 1
                sStmt = Trim(sStmt) & " " & Trim(rsFields.Rows(arow).Item("col_map")) & ", "
            Next arow
            sStmt = VB.Left(sStmt, Len(sStmt) - 2) 'Elimina la ultima coma
            sStmt = Trim(sStmt) & " FROM RepData " & "WHERE col0 = " & Str(nReport)
            MsgBox(sStmt)
        Else
            map_data = False
            Exit Function
        End If
		
	End Function
End Class