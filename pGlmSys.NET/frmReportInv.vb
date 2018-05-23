Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmReportInv
	Inherits System.Windows.Forms.Form
	'-----Variables del reporte-------------
	Public sCustomer As String
	Public sState As String
	Public sReport As String
	Public sVersion As String
	Public sMonthPeriod As String
	Public sYearPeriod As String
	Public dStart As Date
	Public dEnd As Date
	Public bOk As Boolean
	'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
    'Public p As Printer
	Private bPrinter As Boolean 'Determina si hay impresoras definidas
	Public nReport As Short
	'Private rsFields As ADODB.Recordset
    Public rsFields As DataTable
	Private Structure ReportData
        Dim rs As DataTable
		Dim bOpen As Boolean
	End Structure
	Private rdData As ReportData
	Private nIndex As Short
	'--------Crystal Reports-----------------
    Private rsReport As DataTable
	
	'UPGRADE_WARNING: Event cbCustomer.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustomer_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustomer.SelectedIndexChanged
		If cbCustomer.SelectedIndex >= 0 Then
			sStmt = "SELECT DISTINCT format_name FROM RepCust " & "WHERE cust_id ='" & cbCustomer.Text & "'"
			load_cb_query(cbVersion, sStmt, 1)
			If cbVersion.Items.Count > 0 Then
				cbVersion.SelectedIndex = 0
			End If
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
		sMonthPeriod = cbMonthPeriod.Text
		sYearPeriod = cbYearPeriod.Text
		sState = cbState.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object dtStart._Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dStart = dtStart._Value
		'UPGRADE_WARNING: Couldn't resolve default property of object dtEnd._Value. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dEnd = dtEnd._Value
		
		bOk = True
		'NOTA IMPORTANTE PARA EVITAR CONFLICTOS
		'Este llamado es a la funcion local ReportHandler definida
		'en esta forma frmReportInv no a la libreria de reportes.
		ReportHandler()
		'Unload Me
	End Sub
	
	
	Private Sub frmReportInv_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		load_cb(cbState, grsState)
		load_cb(cbCustomer, grsCustomer)
		If cbCustomer.Items.Count > 0 Then
			cbCustomer.SelectedIndex = 0
		End If
		
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
		
		'Meses
		load_cb_query(cbMonthPeriod, "SELECT month_name, month_seq FROM smonth ", 2)
		cbMonthPeriod.SelectedIndex = Month(Today) - 1
		
		'Anios
		load_cb_query(cbYearPeriod, "SELECT DISTINCT year_period FROM vinvoice " & "WHERE year_period IS NOT NULL ORDER BY year_period", 1)
		
		If cbYearPeriod.Items.Count > 0 Then
			cbYearPeriod.SelectedIndex = cbYearPeriod.Items.Count - 1
		End If
		
	End Sub
	
	Private Sub init_vars()
        rsReport = Nothing
	End Sub
	Private Sub frmReportInv_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		gReport.static_Renamed = True
		'UPGRADE_NOTE: Object report_Renamed may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'report_Renamed = Nothing
		'UPGRADE_NOTE: Object app1 may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'app1 = Nothing
		
	End Sub
	
	Private Sub set_defaults()
		dtStart._Value = Today
		dtEnd._Value = Today
		
	End Sub
	'------------------------Funciones de Reporte
	
	'Funcion principal para manejar el reporte
	Public Sub ReportHandler()
		If bOk Then '--Parametros correctos
			'Chequea que exista impresora por defecto
			'UPGRADE_ISSUE: Printers method Printers.Count was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            If System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count = 0 Then
                bPrinter = False
            Else
                bPrinter = True
                printer_options(True)
            End If
			
			'Muestra reporte e imprime
			If bPrinter Then
				'Version para soporte a Crystal Reports
				show_report2()
				'MAYO-14/2002 Activar este reporte cuando se genere salida a Excel
				'show_report_excel
			Else
				MsgBox("There is not default printer specified.Aborting", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
				Exit Sub
			End If
			
			'Se restauran defaults
			If bPrinter Then
				printer_options(False)
			End If
		End If
		
	End Sub
	'Cambia parametros en impresora
	Public Sub printer_options(ByRef bOption As Boolean)
		Dim i As Object
        'Static nDefault As String
		'Agregar forma para seleccionar otra impresora que no
		'sea la impresora default
		If bOption Then
			'UPGRADE_ISSUE: Printers method Printers.Count was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            For i = 0 To System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count - 1
                'UPGRADE_ISSUE: Printer property Printers.DeviceName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'UPGRADE_ISSUE: Printer property Printer.DeviceName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'If Printer.DeviceName = Printers(i).DeviceName Then
                '    'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '    nDefault = i
                '    'Selecciono la impresora por defecto
                '    'UPGRADE_ISSUE: Printers object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
                '    'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
                '    Printer = Printers(i)
                '    Exit For
                'End If
            Next
			'UPGRADE_ISSUE: Constant vbPRPSLegal was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
			'UPGRADE_ISSUE: Printer property Printer.PaperSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.PaperSize = vbPRPSLegal
			'UPGRADE_ISSUE: Constant vbPRORLandscape was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
			'UPGRADE_ISSUE: Printer property Printer.Orientation was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.Orientation = vbPRORLandscape
			
		Else
			'Codigo para cambiar de impresora y opciones de impresion
		End If
	End Sub
	'Rel1.3.2 Extension de show_report para manejar reportes
	'en Crystal Reports.
	'1.-Obtiene la semilla para el reporte (get_seed)
	'2.-Ejecuta el store procedure para cargar RepData
	'3.-Verifica que se haya ejecutado, que hayan datos en RepData
	'4.-Mapea campos de RepData con los definidos en RepCust
	'5.-Muestra el reporte
    Private Sub show_report2()
        'Dim vbcritial As Object
        Dim nError As Object

        'Dim c, sec As Object

        'On Error GoTo ErrorHandler

        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rsFields = Nothing

        cmReport = cn.CreateCommand() '.let_ActiveConnection()
        cmReport.CommandType = CommandType.StoredProcedure

        'Obengo el identificador del reporte
        nReport = 0
        nReport = get_seed("repdata")
        If nReport <= 0 Then
            MsgBox("Unable to get Report Number." & vbCrLf & "Report has not been generated.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Sub
        End If

        'Se cargan los parametros dependiendo del tipo de reporte
        Select Case gReport.Index
            Case 41 'Invoice Report
                Select Case Trim(cbVersion.Text)
                    Case "BRANCH"
                        cmReport.CommandText = "usp_rep_inv2"

                        cmReport.Parameters("@sCustId").Value = sCustomer
                        cmReport.Parameters("@dStart").Value = dStart
                        cmReport.Parameters("@dEnd").Value = dEnd
                    Case "LIST"
                        cmReport.CommandText = "usp_rep_inv_list"

                        cmReport.Parameters("@sCustId").Value = sCustomer
                        cmReport.Parameters("@sMonthPeriod").Value = sMonthPeriod
                        cmReport.Parameters("@sYearPeriod").Value = sYearPeriod
                End Select
            Case Else
                MsgBox("Report does not exists", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Message")
                Exit Sub
        End Select
        cmReport.Parameters("@nError").Direction = ParameterDirection.Output
        'Ejecuto el procedure y verifico por errores
        cmReport.Parameters("@nReportId").Value = nReport
        cmReport.ExecuteNonQuery()

        'UPGRADE_WARNING: Couldn't resolve default property of object nError. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        nError = cmReport.Parameters("@nError").Value
        'UPGRADE_WARNING: Couldn't resolve default property of object nError. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If nError <> 0 Then
            MsgBox("An error ocurred while generating report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Sub
        End If

        'Verifico que se hayan cargado datos en RepData para este reporte
        sStmt = "SELECT count(*) FROM RepData WHERE col0 = " & Str(nReport)
        Try
            rsReport = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic)

            If rsReport.Rows(0).Item(0).Value > 0 Then
                'Encontro registros
            Else
                MsgBox("No data was generated for :" & gReport.name & " report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("There was an error while verifying report data for:" & gReport.name, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End Try

        'Mapeos
        'UPGRADE_WARNING: Couldn't resolve default property of object rdData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        rdData = map_fields() 'Retorna un recordset con los campos a seleccionar
        If rdData.bOpen Then
            rsFields = rdData.rs
        Else
            MsgBox("An error has ocurred while maping report data.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If

        If rsFields.Rows.Count = 0 Then
            MsgBox("An error has ocurred while maping report data.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If

        'Armar query a RepData
        If map_data() Then
            'Datos se cargaron  bien en rsReport
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object vbcritial. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MsgBox("There was an error while loading report data.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If

        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        'Cargo la plantilla de Crystal Reports con los datos
        load_report()
        Exit Sub

ErrorHandler:
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        save_error("frmReportInv", "show_report2")
        'For Each e In cn.Errors
        '    MsgBox(e.Description)
        'Next e
    End Sub
	'Extension de show_report2 para mostrar datos en Excel en lugar de Crystal Reports
	Private Sub show_report_excel()
        Dim nError As Object
        'Dim c, sec As Object
        Dim nCount As Short

        'On Error GoTo ErrorHandler

        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        rsFields = Nothing

        cmReport = cn.CreateCommand '.let_ActiveConnection(cn)
        cmReport.CommandType = CommandType.StoredProcedure


        'Obengo el identificador del reporte
        nReport = 0
        nReport = get_seed("repdata")
        If nReport <= 0 Then
            MsgBox("Unable to get Report Number." & vbCrLf & "Report has not been generated.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Sub
        End If

        'Se cargan los parametros dependiendo del tipo de reporte
        Select Case gReport.Index
            Case 41 'Invoice Report
                Select Case Trim(cbVersion.Text)
                    Case "BRANCH"
                        cmReport.CommandText = "usp_rep_inv2"

                        cmReport.Parameters("@sCustId").Value = sCustomer
                        cmReport.Parameters("@dStart").Value = dStart
                        cmReport.Parameters("@dEnd").Value = dEnd
                    Case "LIST"
                        cmReport.CommandText = "usp_rep_inv_list"

                        cmReport.Parameters("@sCustId").Value = sCustomer
                        cmReport.Parameters("@sMonthPeriod").Value = sMonthPeriod
                        cmReport.Parameters("@sYearPeriod").Value = sYearPeriod
                End Select
            Case Else
                MsgBox("Report does not exist.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Message")
                Exit Sub
        End Select

        'Ejecuto el procedure y verifico por errores
        cmReport.Parameters("@nError").Direction = ParameterDirection.Output
        cmReport.Parameters("@nReportId").Value = nReport
        cmReport.ExecuteNonQuery()


        nError = cmReport.Parameters("@nError").Value

        If nError <> 0 Then
            MsgBox("An error ocurred while generating report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Sub
        End If

        'Verifico que se hayan cargado datos en RepData para este reporte
        sStmt = "SELECT count(*) FROM RepData WHERE col0 = " & Str(nReport)

        rsReport = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic)

        If rsReport.Rows(0).Item(0).Value > 0 Then
            'Encontro registros
        Else
            MsgBox("No data was generated for :" & gReport.name & " report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If


        'Mapeos
        rdData = map_fields() 'Retorna un recordset con los campos a seleccionar
        If rdData.bOpen Then
            rsFields = rdData.rs
        Else
            MsgBox("An error has ocurred while maping report data.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If

        If rsFields.Rows.Count = 0 Then
            MsgBox("An error has ocurred while maping report data.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If

        'Armar query a RepData
        nCount = map_data2()
        If nCount > 0 Then
            'Datos se cargaron  bien en rsReport
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object vbcritial. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MsgBox("There was an error while loading report data.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If

        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        'Cargo la plantilla de Crystal Reports con los datos
        load_report_excel(nCount)
        Exit Sub

ErrorHandler:
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        save_error("frmReportInv", "show_report2")
        'For Each e In cn.Errors
        '    MsgBox(e.Description)
        'Next e

    End Sub
	'Asocia los campos de RepData con los campos del Reporte.
	'Retorna un recordset con los datos
	'Public Function map_fields() As ADODB.Recordset
	Private Function map_fields() As ReportData
		Dim rsMap As ADODB.Recordset
        map_fields = New ReportData()
		
		On Error GoTo ErrorHandler
		
        rsMap = Nothing
		
		If rsMap.State = ADODB.ObjectStateEnum.adStateOpen Then
			rsMap.Close()
		End If
		
		sStmt = "SELECT RepField.field_caption, RepField.short_caption , RepCust.rep_field, " & "RepCust.col_order, RepCust.col_map " & "FROM RepField, RepCust " & "WHERE RepField.rep_field = RepCust.rep_field " & "AND RepCust.cust_id ='" & Trim(sCustomer) & "' " & "AND RepCust.format_name='" & Trim(sVersion) & "' " & "AND RepCust.rep_no = " & "(SELECT rep_no FROM RepDef WHERE rep_caption='" & Trim(sReport) & "') " & "ORDER BY RepCust.col_order"
		
		rsMap.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		
		If rsMap.State = ADODB.ObjectStateEnum.adStateOpen Then
			map_fields.bOpen = True
			map_fields.rs = rsMap
		Else
			map_fields.bOpen = False
		End If
		'Set rsMap = Nothing
		Exit Function
		
		'Seleccionar registros a mostrar
		'Retornar recordset
ErrorHandler: 
		save_error("Report.bas", "map_fields")
		MsgBox("Failed to retrieve Report Mapping info." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
	End Function
	'Arma dinamicamente el query para seleccionar los campos  col0, col1,....
	'de la tabla RepData y lo ejecuta. Los datos se pueden accesar usando
	'el recordset rsReport
	Private Function map_data() As Boolean
		'On Error GoTo ErrorHandler
		
		'Este rs fue previamente cargado por map_fields
        If rsFields.Rows.Count > 0 Then

            sStmt = "SELECT "
            For row As Integer = 0 To rsFields.Rows.Count - 1
                sStmt = Trim(sStmt) & " " & Trim(rsFields.Rows(row).Item("col_map").Value) & _
                        " AS " & Trim(rsFields.Rows(row).Item("short_caption").Value) & ", "
            Next row
            
            'March 02/2002
            'Stored Procedure retorna esta informacion
            'If gReport.Index = 41 Then  'Invoice Report
            'PENDIENTE : cambiar para aceptar varios meses
            'gDump = exec_sql_single( _
            ''             "SELECT cust_name, 'SEPTEMBER - 2001' " + _
            ''             "FROM customer " + _
            ''             "WHERE cust_id = '" + Trim(sCustomer) + "'")
            '
            'sStmt = sStmt + " '" + UCase(Trim(gDump.str1)) + "' AS cust_name," + _
            ''                "'" + Trim(gDump.str2) + "' AS month_year, "
            'End If
            sStmt = VB.Left(sStmt, Len(sStmt) - 2) 'Elimina la ultima coma
            sStmt = Trim(sStmt) & " FROM RepData " & "WHERE col0 = " & Str(nReport)

            '12/04/01
            'Comentado solo para generar ejecutable
            'MsgBox sStmt


        Else
            map_data = False
            Exit Function
        End If
		
		'Cargo el recordset con los datos de RepData
        rsReport = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		dg.DataSource = rsReport
		'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        dg.Refresh()

        'Si hay datos
        map_data = True
        If rsReport.Rows.Count <= 0 Then
            map_data = False
        End If

        Exit Function

ErrorHandler:
        map_data = False
        save_error("Report.bas", "map_data")
        MsgBox("Failed to retrieve Report Mapping data." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
		
	End Function
	'Extension de map_data, incluye titulos de campos de RepField.field_caption
	'Retorna el numero de campos en tabla repcust para este reporte y version
	Private Function map_data2() As Short
		Dim nCount As Short
		
		nCount = 0
        If rsFields.Rows.Count > 0 Then
            sStmt = "SELECT "
            For row As Integer = 0 To rsFields.Rows.Count - 1
                nCount = nCount + 1
                sStmt = Trim(sStmt) & " " & Trim(rsFields.Rows(row).Item("col_map").Value) & " AS " & "'" & Trim(rsFields.Rows(row).Item("field_caption").Value) & "', "
            Next row

            sStmt = VB.Left(sStmt, Len(sStmt) - 2) 'Elimina la ultima coma
            sStmt = Trim(sStmt) & " FROM RepData " & "WHERE col0 = " & Str(nReport)

            'MsgBox sStmt
        Else
            map_data2 = nCount
            Exit Function
        End If
		
		'Cargo el recordset con los datos de RepData
        rsReport = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		dg.DataSource = rsReport
		'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        dg.Refresh()
        If rsReport.Rows.Count > 0 Then
            'Si hay datos
            map_data2 = nCount
            If rsReport.Rows.Count <= 0 Then
                'map_data2 = False
            End If
        Else
            map_data2 = nCount
        End If
		
		Exit Function
		
ErrorHandler: 
		map_data2 = nCount
		save_error("Report.bas", "map_data2")
		MsgBox("Failed to retrieve Report Mapping data." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
		
		'Resume Next
	End Function
	'Usa el recordset rsReport que fue previamente cargado
	'con los datos de Repdata y lo paso al reporte de Crystal Reports
	'Actualizado: Mar-30-2002
	Private Function load_report() As Boolean
        Dim sFile As String = "" 'Path de la plantilla del reporte
        Dim sReportTemplate As String = "" 'Nombre de plantilla de reporte
        Dim fileTmp As Scripting.FileSystemObject
        fileTmp = New Scripting.FileSystemObject


        'ADO
        'Set cn = New ADODB.Connection
        'Set AdoRs = nothing
        'Set rsReport = nothing
        'cn.Provider = "SQLOLEDB"
        'cn.ConnectionString = "User Id=sa;Password=sa;" + _
        ''    "Initial Catalog=glm;Data Source=jpuentelap1;"
        'cn.Open
        'AdoRs.Open "select store_id as id, state_id as store, " + _
        ''    "store_address as address , store_city as city  " + _
        ''    "from store", cn

        'AdoRs.Open "select store_id, store_name,store_address," + _
        '"store_city from store", cn
        'MsgBox AdoRs(2)


        'Abro el archivo con el reporte
        'app1 = CreateObject("Crystal.CRPE.Application")

        Select Case Trim(cbVersion.Text)
            Case "BRANCH"
                sFile = "c:\glm\Reports\rptInvoice5.rpt"
                'Set report = app1.OpenReport("c:\glm\Reports\rptInvoice5.rpt")
                'Set report = app1.OpenReport("d:\glm\tmp\rptPrueba2.rpt")
            Case "LIST"
                'Set report = app1.OpenReport("c:\glm\Visual Basic\GLM-System\Reports\rptInvList.rpt")

                sReportTemplate = "rptInvList.rpt"
                sFile = Trim(My.Application.Info.DirectoryPath) & "\" & sReportTemplate
                sFile = "c:\glm\rptInvList.rpt"
                'MsgBox "Looking for file:" + sFile
        End Select

        If fileTmp.FileExists(sFile) Then
            'report_Renamed = app1.OpenReport(sFile)
        Else
            MsgBox("Report template not found." & vbCrLf & "Please install: " & sFile, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
            Exit Function
        End If

        'reportTable.SetPrivateData(3, rsReport)
        ''report.SelectPrinter "HP DeskJet 550C","remota", "LPT1"

        'report_Renamed.Preview()
    End Function
	'Mayo-12/2002
	'Usa el recordset rsReport para cargar datos en hoja de Excel y
	'formatear para impresion
	Private Function load_report_excel(ByRef nFields As Short) As Boolean
        Dim XLApp As Object = New Object()
        Dim XL_wsheet As Object = New Object()
		Dim nRow As Short
		Dim nColumn As Short
		
		If call_excel("ND", "LIST", "Invoice Report") Then
			'Fila, Columna
			'UPGRADE_WARNING: Couldn't resolve default property of object XL_wsheet.Cells. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'cargar hoja de excel?
            'XL_wsheet.Cells(1, 4) = "Fila 1 COlumna4"
			'Titulos

            nColumn = 0
            For column As Integer = 0 To rsFields.Columns.Count - 1
                nColumn = nColumn + 1
                'UPGRADE_WARNING: Couldn't resolve default property of object XL_wsheet.Cells. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'no se cual es el este
                'XL_wsheet.Cells(1, nColumn) = rsFields.item("field_caption").Value
            Next column
			
			
			'Registros de datos
            nRow = 2
            For row As Integer = 0 To rsReport.Rows.Count - 1
                For nColumn = 0 To nFields - 1
                    'UPGRADE_WARNING: Couldn't resolve default property of object XL_wsheet.Cells. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'XL_wsheet.Cells(nRow, nColumn + 1) = rsReport.item(nColumn).Value
                Next nColumn
                nRow = nRow + 1
            Next row
			
			
			'UPGRADE_WARNING: Couldn't resolve default property of object XLApp.Visible. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'XLApp.Visible = True
			'UPGRADE_WARNING: Couldn't resolve default property of object XLApp.Run. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'XLApp.Run("formato")
		End If
		
	End Function
End Class