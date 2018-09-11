Option Strict Off
Option Explicit On
Imports System.Drawing.printing
Imports System.Data.SqlClient
Module Report

    Public sCustomer As String
    Public sState As String
    Public sReport As String
    Public sVersion As String
    Public dStart As Date
    Public dEnd As Date
    Public bOk As Boolean
    'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
    Public p As Printing.PrintDocument
    Private bPrinter As Boolean 'Determina si hay impresoras definidas
    Public nReport As Integer

    Public rsFields As DataTable
    Private Structure ReportData
        Dim rs As DataTable
        Dim bOpen As Boolean
    End Structure
    Private rdData As ReportData
    Private nIndex As Short
    'Stores collection indexes
    Dim CUST_IDX As Short
    Dim STORE_IDX As Short
    Dim STORE_NUMBER_IDX As Short
    Dim STORE_NAME_IDX As Short
    Dim BALERWGT_IDX As Short
    Dim PKRWGT_IDX As Short
    Dim DUMWGT_IDX As Short
    Dim TOTWGT_IDX As Short
    Dim DUMWGTCOMPOST_IDX As Short
    Dim TOTWGTCOMPOST_IDX As Short
    Dim OTWGTDCONDEMO_IDX As Short
    Dim DUMWGTTRASH_IDX As Short
    Dim PKRWGTTRASH_IDX As Short
    Dim TOTWGTTRASH_IDX As Short
    Dim VIPWGTTRASH_IDX As Short
    Dim OTWGTTRASH_IDX As Short
    Dim PKRWGTCONTAMINATED_IDX As Short
    Dim STORE_RECYCLE_IDX As Short
    Dim STORE_TRASH_IDX As Short
    Dim storesIdx As Short



    'Funcion principal para manejar el reporte
    Public Sub ReportHandler()

        'Muestra la forma para ingresar parametros del reporte
        'frmReport.Show vbModal, frmMain

        If bOk Then
            If check_param() Then 'Verifica que los parametros sean apropiados
                'Chequea que exista impresora por defecto
                'UPGRADE_ISSUE: Printers method Printers.Count was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                If PrinterSettings.InstalledPrinters.Count Then
                    bPrinter = False
                Else
                    bPrinter = True
                    printer_options(True)
                End If

                'Muestra reporte e imprime
                If bPrinter Then
                    'Version para soporte a Crystal Reports
                    show_report2()
                Else
                    MsgBox("There is not default printer specified.Aborting", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Sub
                End If

                'Se restauran defaults
                If bPrinter Then
                    printer_options(False)
                End If
            End If
        End If

    End Sub

    'Verifica que el usuario haya selecionado parametros
    'apropiados para el reporte
    Private Function check_param() As Boolean
        check_param = True
    End Function
    'Cambia parametros en impresora
    Public Sub printer_options(ByRef bOption As Boolean)
        Dim i As Object
        Static nDefault As String
        'Agregar forma para seleccionar otra impresora que no
        'sea la impresora default
        If bOption Then

            'UPGRADE_ISSUE: Printers method Printers.Count was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            For i = 0 To (PrinterSettings.InstalledPrinters.Count - 1)
                'UPGRADE_ISSUE: Printer property Printers.DeviceName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'UPGRADE_ISSUE: Printer property Printer.DeviceName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'If Printer.DeviceName = Printers(i).DeviceName Then
                'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                nDefault = i
                'Selecciono la impresora por defecto
                'UPGRADE_ISSUE: Printers object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
                'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
                'Printer = Printers(i)
                'Exit For
                'End If
            Next
            'UPGRADE_ISSUE: Constant vbPRPSLegal was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
            'UPGRADE_ISSUE: Printer property Printer.PaperSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.PaperSize = vbPRPSLegal
            'UPGRADE_ISSUE: Constant vbPRORLandscape was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
            'UPGRADE_ISSUE: Printer property Printer.Orientation was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.Orientation = vbPRORLandscape
            'Rel 1.3.2 Verificar si esta linea debe de borrarse?
            'drInvoiceRep.Orientation = rptOrientLandscape


        Else
            'Codigo para cambiar de impresora y opciones de impresion
        End If
    End Sub
    Public Sub util_printer_options(ByRef bOption As Boolean)
        Dim nDefault As Object
        Dim i As Short

        If bOption Then
            'UPGRADE_ISSUE: Printers method Printers.Count was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
                'UPGRADE_ISSUE: Printer property Printers.DeviceName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'UPGRADE_ISSUE: Printer property Printer.DeviceName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'If Printer.DeviceName = Printers(i).DeviceName Then
                'UPGRADE_WARNING: Couldn't resolve default property of object nDefault. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                nDefault = i
                'Selecciono la impresora por defecto
                'UPGRADE_ISSUE: Printers object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
                'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
                'Printer = Printers(i)
                Exit For
                'End If
            Next
            'Printer.Width = 16560
            'Printer.PaperSize = vbPRPSLegal
            'UPGRADE_ISSUE: Constant vbPRPSLetter was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
            'UPGRADE_ISSUE: Printer property Printer.PaperSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.PaperSize = vbPRPSLetter
            'UPGRADE_ISSUE: Constant vbPRORLandscape was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
            'UPGRADE_ISSUE: Printer property Printer.Orientation was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.Orientation = vbPRORLandscape
        Else
            'Codigo para cambiar de impresora y opciones de impresion
        End If
    End Sub

    'Ejecuta el store procedure para cargar RepData
    Private Sub show_report()

        Dim sCaption As String = ""
        Dim drInvoiceRep As DataTable
        Dim num_cols As Integer = 0
        'Dim rsReport As SqlDataReader

        Dim c As Object = New Object()
        Dim cmd As SqlCommand = cn.CreateCommand()
        'On Error GoTo ErrorHandler
        Try

            'cmReport.Parameters.refresh()

            'Obengo el identificador del reporte
            nReport = 0
            nReport = get_seed("repdata")
            If nReport <= 0 Then
                MsgBox("Unable to get Report Number." & vbCrLf & "Report has not been generated.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                Exit Sub
            End If

            cmReport = cn.CreateCommand()
            cmReport.CommandType = CommandType.StoredProcedure
            'Se cargan los parametros dependiendo del tipo de reporte
            Select Case gReport.Index
                Case 41 'Invoice Report
                    cmReport.CommandText = "usp_rep_inv"
                    cmReport.Parameters("@sCustId").Value = sCustomer
                    cmReport.Parameters("@dStart").Value = dStart
                    cmReport.Parameters("@dEnd").Value = dEnd

                Case Else
                    MsgBox("Report does not exists", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Message")
                    Exit Sub
            End Select

            'Ejecuto el procedure
            cmReport.Parameters("@nReportId").Value = nReport
            cmReport.ExecuteNonQuery()

            'Verifico que se hayan cargado datos en RepData para este reporte
            sStmt = "SELECT count(*) FROM RepData WHERE col0 = " & Str(nReport)
            cmd.CommandText = sStmt

            Try
                rs = getDataTable(sStmt) 'cmd.ExecuteReader()
                If rs.Rows.Count > 0 Then
                    'Encontro registros
                Else
                    MsgBox("No data was generated for :" & gReport.name & " report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("There was an error while verifying report data for:" & gReport.name, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                Exit Sub
            End Try

            'Mapeos
            'UPGRADE_WARNING: Couldn't resolve default property of object rdData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            rdData = map_fields()
            If rdData.bOpen Then
                rsFields = rdData.rs
            Else
                MsgBox("An error has ocurred while maping report data.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                Exit Sub
            End If

            If Not rsFields.Rows.Count > 0 Then
                MsgBox("An error has ocurred while maping report data.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                Exit Sub
            End If


            'UPGRADE_WARNING: Couldn't resolve default property of object num_cols. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            num_cols = 0
            'UPGRADE_WARNING: Couldn't resolve default property of object num_cols. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            num_cols = rsFields.Columns.Count
            'Mapeo los titulos de los campos con labels del DataReport. Section Page Header        
            'For Each c In drInvoiceRep.Sections(2).Controls
            For arow As Integer = 0 To rsFields.Rows.Count - 1
                'UPGRADE_WARNING: Couldn't resolve default property of object c.name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If InStr(rsFields.Rows(arow).Item(2), "Label") > 0 Then
                    If Not IsDBNull(rsFields.Rows(arow).Item(2)) Then
                        If IsDBNull(rsFields.Rows(arow).Item(0)) Then
                            sCaption = "NN"
                        Else
                            sCaption = rsFields.Rows(arow).Item(0)
                        End If

                        c.Caption = sCaption

                    Else 'Resto de labels sobrantes no aparecen
                        'UPGRADE_WARNING: Couldn't resolve default property of object c.Visible. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        c.Visible = False
                    End If
                End If
            Next arow


            'Armar query a RepData
            If map_data() Then
                'Datos se cargaron  bien en rsReport
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object vbcritial. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                MsgBox("There was an error while loading report data.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                Exit Sub
            End If

            nIndex = 0
            'UPGRADE_WARNING: Couldn't resolve default property of object drInvoiceRep.DataSource. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'drInvoiceRep = rsReport
            drInvoiceRep = rsFields
            'Mapeo los campos con el DataReport Section Detail
            'UPGRADE_WARNING: Couldn't resolve default property of object drInvoiceRep.Sections. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'While (drInvoiceRep.Read())
            For arow As Integer = 0 To drInvoiceRep.Rows.Count - 1
                'drInvoiceRep.Sections(3).Controls("txtCol1").DataField = rs("store_name").Name
                'Verifico que el control sea de tipo Txt
                'UPGRADE_WARNING: Couldn't resolve default property of object c.name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'If InStr(drInvoiceRep.GetName(3), "txt") > 0 Then
                If InStr(drInvoiceRep.Columns(3).ColumnName, "txt") > 0 Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object num_cols. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If nIndex < num_cols Then
                        'UPGRADE_WARNING: Couldn't resolve default property of object c.DataField. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object rsReport().name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'c.DataField = drInvoiceRep.GetName(3)
                        c.DataField = drInvoiceRep.Columns(3).ColumnName
                        nIndex = nIndex + 1
                    Else
                        'UPGRADE_WARNING: Couldn't resolve default property of object c.DataField. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object rsReport().name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'c.DataField = rsReport.GetName(nIndex - 1)
                        c.DataField = drInvoiceRep.Columns(nIndex - 1).ColumnName
                        'UPGRADE_WARNING: Couldn't resolve default property of object c.Visible. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        c.Visible = False
                    End If
                End If
            Next arow


            'UPGRADE_WARNING: Couldn't resolve default property of object drInvoiceRep.Show. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'drInvoiceRep.Show(VB6.FormShowConstants.Modal, frmMain)
            Exit Sub

        Catch err As Exception
            save_error("Report.bas", "show_report")
            MsgBox(err.Message)
        End Try

    End Sub
    'Rel1.3.2 Extension de show_report para manejar reportes
    'en Crystal Reports.
    '1.-Obtiene la semilla para el reporte (get_seed)
    '2.-Ejecuta el store procedure para cargar RepData
    '3.-Verifica que se haya ejecutado, que hayan datos en RepData
    '4.-Mapea campos de RepData con los definidos en RepCust
    '5.-Muestra el reporte
    Private Sub show_report2()

        Dim rsReport As DataTable
        Dim nError As Integer
        Dim cmd As SqlCommand = cn.CreateCommand()
        'Dim c, sec As Object

        Try
            cmReport = cn.CreateCommand()
            cmReport.CommandType = CommandType.StoredProcedure
            'cmReport.Parameters.()


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
                    cmReport.CommandText = "usp_rep_inv2"
                    cmReport.Parameters("@sCustId").Value = sCustomer
                    cmReport.Parameters("@dStart").Value = dStart
                    cmReport.Parameters("@dEnd").Value = dEnd
                    cmReport.Parameters("@nError").Direction = ParameterDirection.Output

                Case Else
                    MsgBox("Report does not exist.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Message")
                    Exit Sub
            End Select

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
            cmd.CommandText = sStmt
            rsReport = getDataTable(sStmt) 'cmd.ExecuteReader()

            If rsReport.Rows.Count > 0 Then
                'UPGRADE_WARNING: Couldn't resolve default property of object rsReport(0). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If rsReport.Rows.Count > 0 Then
                    'Encontro registros
                Else
                    MsgBox("No data was generated for :" & gReport.name & " report.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Sub
                End If
            Else
                MsgBox("There was an error while verifying report data for:" & gReport.name, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Error")
                Exit Sub
            End If

            'Mapeos
            rdData = map_fields() 'Retorna un recordset con los campos a seleccionar
            If rdData.bOpen Then
                rsFields = rdData.rs
            Else
                MsgBox("An error has ocurred while maping report data.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                Exit Sub
            End If

            If Not rsFields.Rows.Count > 0 Then
                MsgBox("An error has ocurred while maping report data.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                Exit Sub
            End If


            'num_cols = 0
            'num_cols = rsFields.RecordCount
            'Mapeo los titulos de los campos con labels del DataReport. Section Page Header
            'For Each c In drInvoiceRep.Sections(2).Controls
            '   If InStr(c.name, "Label") > 0 Then
            '      If Not rsFields.EOF Then
            '          If IsNull(rsFields(0)) Then
            '             sCaption = "NN"
            '          Else
            '             sCaption = rsFields(0)
            '          End If
            '
            '          c.Caption = sCaption
            '          rsFields.MoveNext
            '      Else 'Resto de labels sobrantes no aparecen
            '          c.Visible = False
            '      End If
            '   End If
            'Next c


            'Armar query a RepData
            If map_data() Then
                'Datos se cargaron  bien en rsReport
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object vbcritial. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                MsgBox("There was an error while loading report data.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                Exit Sub
            End If

            'nIndex = 0
            'Set drInvoiceRep.DataSource = rsReport
            'Mapeo los campos con el DataReport Section Detail
            'For Each c In drInvoiceRep.Sections(3).Controls
            'drInvoiceRep.Sections(3).Controls("txtCol1").DataField = rs("store_name").Name
            'Verifico que el control sea de tipo Txt
            '    If InStr(c.name, "txt") > 0 Then
            '        If nIndex < num_cols Then
            '           c.DataField = rsReport(nIndex).name
            '           nIndex = nIndex + 1
            '        Else
            '           c.DataField = rsReport(nIndex - 1).name
            '           c.Visible = False
            '        End If
            '    End If
            'Next c


            'drInvoiceRep.Show vbModal, frmMain
            load_report()
            Exit Sub

        Catch e As Exception
            save_error("Report.bas", "show_report")

            MsgBox(e.Message)
        End Try
    End Sub
    'Asocia los campos de RepData con los campos del Reporte.
    'Retorna un recordset con los datos
    'Public Function map_fields() As SqlDataReader
    Private Function map_fields() As ReportData

        Dim rsMap As DataTable
        Dim cmd As SqlCommand = cn.CreateCommand()
        map_fields = Nothing
        'On Error GoTo ErrorHandler

        sStmt = "SELECT RepField.short_caption , RepCust.rep_field, " & "RepCust.col_order, RepCust.col_map " & "FROM RepField, RepCust " & "WHERE RepField.rep_field = RepCust.rep_field " & "AND RepCust.cust_id ='" & Trim(sCustomer) & "' " & "AND RepCust.format_name='" & Trim(sVersion) & "' " & "AND RepCust.rep_no = " & "(SELECT rep_no FROM RepDef WHERE rep_caption='" & Trim(sReport) & "') " & "ORDER BY RepCust.col_order"
        cmd.CommandText = sStmt
        Try

            rsMap = getDataTable(sStmt) ' cmd.ExecuteReader()
            map_fields.bOpen = True
        Catch ex As Exception
            map_fields.bOpen = False
            rsMap = Nothing
            save_error("Report.bas", "map_fields")
            MsgBox("Failed to retrieve Report Mapping info." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
        End Try

        Return map_fields
        Exit Function

        'Seleccionar registros a mostrar
        'Retornar recordset


    End Function
    'Arma dinamicamente el query para seleccionar los campos  col0, col1,....
    'de la tabla RepData y lo ejecuta. Los datos se pueden accesar usando
    'el recordset rsReport
    Private Function map_data() As Boolean
        Dim rsReport As DataTable
        Dim cmd As SqlCommand = cn.CreateCommand()
        'On Error GoTo ErrorHandler

        'Este rs fue previamente cargado por map_fields
        If rsFields.Rows.Count > 0 Then

            sStmt = "SELECT 'ND' as cust_name,'SEPTEMBER' AS month_year, "

            'While (rsFields.HasRows())
            '    sStmt = Trim(sStmt) & " " & Trim(rsFields.Item("col_map").Value) & ", "
            'End While

            For drow As Integer = 0 To rsFields.Rows.Count - 1
                sStmt = Trim(sStmt) & " " & Trim(rsFields.Rows(drow).Item("col_map")) & ", "
            Next drow

            sStmt = Left(sStmt, Len(sStmt) - 2) 'Elimina la ultima coma
            sStmt = Trim(sStmt) & " FROM RepData " & "WHERE col0 = " & Str(nReport)
            MsgBox(sStmt)
        Else
            map_data = False
            Exit Function
        End If

        'Cargo el recordset con los datos de RepData
        Try
            cmd.CommandText = sStmt
            rsReport = getDataTable(sStmt) 'cmd.ExecuteReader()
            'UPGRADE_WARNING: Couldn't resolve default property of object rsReport.State. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'

            'Si hay datos
            map_data = True
            'UPGRADE_WARNING: Couldn't resolve default property of object rsReport.RecordCount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If Not rsReport.Rows.Count > 0 Then
                map_data = False
            End If
        Catch e As Exception
            map_data = False
        End Try


        Exit Function

ErrorHandler:
        map_data = False
        save_error("Report.bas", "map_data")
        MsgBox("Failed to retrieve Report Mapping data." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")

    End Function
    'Usa el recordset rsReport que fue previamente cargado
    'con los datos de Repdata y lo paso al reporte de Crystal Reports
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
        'app1 = CreateObject("Crystal.CRPE.Application")
        'report_Renamed = app1.OpenReport("d:\glm\Reports\rptInvoice.rpt")

        'reportDb = report_Renamed.Database
        'reportTables = reportDb.Tables
        'reportTable = reportTables.Item(1)
        ''reportTable.SetPrivateData 3, AdoRS
        'reportTable.SetPrivateData(3, rsReport)
        'report_Renamed.Preview()

    End Function
    'Parametros
    'sReport es el nombre del reporte
    'sTemplate es el nombre de la plantilla
    'Retorna la plantilla desde RepDefTemplate
    Public Function get_template(ByRef sReport As String, Optional ByRef sTemplate As String = "DEFAULT") As String

        Dim cmd As SqlCommand = cn.CreateCommand()
        On Error GoTo ErrorHandler

        get_template = ""


        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(sReport) Then
            MsgBox("A report name was not provided")
        End If
        If Len(sReport) = 0 Then
            MsgBox("A report name was not provided")
        End If

        sStmt = "SELECT t.rep_template_file FROM RepDef d, RepDefTemplate t " & " WHERE d.rep_no = t.rep_no " & " AND t.rep_template_name ='" & Trim(sTemplate) & "' " & " AND d.rep_caption = '" & Trim(sReport) & "'"
        cmd.CommandText = sStmt
        
        rs = getDataTable(sStmt) 'cmd.ExecuteReader()
        
        get_template = rs.Rows(0).Item("rep_template_file")
        Exit Function



ErrorHandler:
        save_error("Report.bas", "get_template")
    End Function
    'Searches report template from RepDef
    Public Function get_local_template(ByRef sReport As String) As String
        On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand()
        get_local_template = ""

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(sReport) Then
            MsgBox("A report name was not provided")
        End If
        If Len(sReport) = 0 Then
            MsgBox("A report name was not provided")
        End If

        sStmt = "SELECT rep_template_file FROM RepDef " & " WHERE rep_caption = '" & Trim(sReport) & "'"
        cmd.CommandText = sStmt
        
        rs = getDataTable(sStmt) ' cmd.ExecuteReader()

        get_local_template = rs.Rows(0).Item("rep_template_file")
        write_error("Warning: Using LOCAL report file instead.", sLogfile)
        Exit Function

ErrorHandler:
        save_error("Report.bas", "get_localtemplate")

    End Function


    'Inserts report description
    Public Function publish_report(ByRef sCustId As String, ByRef sReportDesc As String, ByRef sReportTemplate As String, ByRef sFormName As String, ByRef sLocalReport As String) As Boolean
        Dim txtReportName As Object = New Object()

        Dim cmdLocal As SqlCommand = cn.CreateCommand()
        Dim nRecords As Short = -1
        Dim bDeleteFlag As Boolean = False
        Dim nTrans As sqltransaction
        Dim sTableName As String = ""
        Dim nRepNo As Short = -1



        cmdLocal = New SqlCommand("", cn)
        publish_report = False
        bDeleteFlag = False
        sTableName = ""

        '1.Verify that report_desc is unique
        sStmt = "SELECT report_id FROM web_report " & " WHERE cust_id='" & sCustId & "' " & " AND report_desc = '" & quotation_mask(sReportDesc) & "'"
        cmdLocal.CommandText = sStmt
        rs = getDataTable(sStmt) 'cmdLocal.ExecuteReader()

        If rs.Rows.Count > 0 Then
            If MsgBox("Found a report with given name. " & vbCrLf & "Do you want to overwrite it? Otherwise enter a new report name.", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "GLM Warning") = MsgBoxResult.Yes Then
                bDeleteFlag = True
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object txtReportName.SetFocus. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'cual es txtReportName???
                txtReportName.SetFocus()
                Exit Function
            End If
        End If


        '2.Insert report, we will update the report_id when the report is generated.
        nTrans = cn.BeginTransaction()
        Try
            If bDeleteFlag Then
                sStmt = "DELETE FROM web_report " & " WHERE cust_id='" & sCustId & "' " & " AND report_desc='" & quotation_mask(sReportDesc) & "'"
                cmdLocal.CommandText = sStmt
                nRecords = cmdLocal.ExecuteNonQuery()
                If nRecords = 0 Then
                    nTrans.Rollback()
                    MsgBox("Failed to clean publishing information." & vbCrLf & "You must generate report again.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                    Exit Function
                End If
            End If

            'Get Table_name from repdef
            sStmt = "SELECT rep_no, table_name FROM RepDef " & " WHERE rep_caption = '" & Trim(sLocalReport) & "' "
            cmdLocal.CommandText = sStmt
            rs = getDataTable(sStmt) 'cmdLocal.ExecuteReader()

            If rs.Rows.Count > 0 Then
                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                If IsDBNull(rs.Rows(0).Item("table_name").Value) Or IsDBNull(rs.Rows(0).Item("rep_no").Value) Then
                    nTrans.Rollback()
                    write_msg(sFormName & ":publish_report()", "Could not read or missing RepDef.table_name or RepDef.repno value.")
                    MsgBox("Missing information in Report Definition table." & vbCrLf & "Check log file for further information.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                    Exit Function
                Else
                    sTableName = rs.Rows(0).Item("table_name").Value
                    nRepNo = rs.Rows(0).Item("rep_no").Value
                End If
            Else
                nTrans.Rollback()
                write_msg(sFormName & ":publish_report()", "No record found in Repdef for ReportName:" & sLocalReport)
                MsgBox("Missing information in Report Definition table." & vbCrLf & "Check log file for further information.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                Exit Function
            End If


            Dim nWebReportId As Short

            nWebReportId = get_next_seq("web_report", "web_report_id")

            sStmt = "INSERT INTO web_report (cust_id, rep_no, rep_template_name, " & " report_desc, table_name, report_type, enabled_flag, web_report_id)" & "VALUES('" & sCustId & "'," & Str(nRepNo) & ",'" & sReportTemplate & "', " & "'" & quotation_mask(sReportDesc) & "','" & Trim(sTableName) & "','DATA', 1, " & Str(nWebReportId) & " )"
            cmdLocal.CommandText = sStmt
            nRecords = cmdLocal.ExecuteNonQuery()
            If nRecords > 0 Then
                publish_report = True
                nTrans.Commit()

            Else
                nTrans.Rollback()
                MsgBox("Failed to publish report information.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                Exit Function
            End If
            Exit Function

        Catch e As Exception
            publish_report = False

            nTrans.Rollback()

            save_error(sFormName, "publish_report")
            MsgBox("Unexpected occurred while saving publishing information. " & vbCrLf & "Check log details for further information", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
        End Try

    End Function


    'Updates report with new seed after it got generated
    Public Function update_publish_report(ByRef sCustId As String, ByRef sReportDesc As String, ByRef nReportId As Integer) As Boolean
        Dim nRecords As Short
        Dim cmdLocal As ADODB.Command

        cmdLocal = New ADODB.Command

        update_publish_report = False

        sStmt = "UPDATE web_report SET report_id =" & Str(nReportId) & " WHERE cust_id ='" & sCustId & "' " & " AND report_desc ='" & quotation_mask(sReportDesc) & "'"

        With cmdLocal
            .let_ActiveConnection(cn)
            .CommandType = ADODB.CommandTypeEnum.adCmdText
            .CommandText = sStmt
        End With




        cmdLocal.Execute(nRecords)
        If nRecords > 0 Then
            'ok
        Else
            MsgBox("Failed to update publishing information." & vbCrLf & "You will have to generate this report again in order to publish it on the web", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Function
        End If



    End Function

    'Inserts record in RptCriteriaGlmInvoice
    Public Function insert_glminvoice_report_criteria(ByRef custId As String, ByRef repNo As Short, ByRef reportId As Integer, ByRef stateId As String, ByRef groupSeq As Short, ByRef repTemplateName As String, ByRef reportCaption As String, ByRef isPeriodSeq As String, ByRef periodSeq As Short, ByRef startDate As Date, ByRef endDate As Date, ByRef displayStoreWithInvoices As String, ByRef publishToWeb As String, ByRef webReportName As String, ByRef useForCustomerBilling As String, ByRef instanceNo As Integer, ByRef isFinalVersion As String, Optional ByRef sqlTran As SqlTransaction = Nothing) As Boolean

        Dim nRecords As Short

        nRecords = 0

        sStmt = "INSERT INTO RptCriteriaGlmInvoice (cust_id, rep_no, report_id," & "state_id, group_seq, rep_template_name, report_caption, " & "is_period_seq, period_seq, start_date, end_date, " & "display_store_with_invoices, publish_to_web, web_report_name, " & _
        "use_for_customer_billing, id, is_final_version)" & _
        " VALUES (@cust_id, @rep_no, @report_id, @state_id, @group_seq, @rep_template_name, @report_caption, @is_period_seq, @period_seq, @start_date, @end_date, @display_store_with_invoices, @publish_to_web, @web_report_name, @use_for_customer_billing , @id, @is_final_version)"

        '" VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ? , ?, ?)"
        cm = cn.CreateCommand()
        'cm.Parameters(0).Direction = ParameterDirection.Input
        'cm.Parameters(0).Direction = ParameterDirection.Output

        create_param("cust_id", SqlDbType.VarChar, ParameterDirection.Input, Trim(custId), cm, 2)
        create_param("rep_no", SqlDbType.Int, ParameterDirection.Input, repNo, cm)
        create_param("report_id", SqlDbType.Int, ParameterDirection.Input, reportId, cm)
        create_param("state_id", SqlDbType.VarChar, ParameterDirection.Input, Trim(stateId), cm, 3)
        create_param("group_seq", SqlDbType.Int, ParameterDirection.Input, groupSeq, cm)
        create_param("rep_template_name", SqlDbType.VarChar, ParameterDirection.Input, repTemplateName, cm, 50)
        create_param("report_caption", SqlDbType.VarChar, ParameterDirection.Input, reportCaption, cm, 30)
        create_param("is_period_seq", SqlDbType.VarChar, ParameterDirection.Input, isPeriodSeq, cm, 5)
        create_param("period_seq", SqlDbType.Int, ParameterDirection.Input, periodSeq, cm)
        create_param("start_date", SqlDbType.Date, ParameterDirection.Input, startDate, cm)
        create_param("end_date", SqlDbType.Date, ParameterDirection.Input, endDate, cm)
        create_param("display_store_with_invoices", SqlDbType.VarChar, ParameterDirection.Input, displayStoreWithInvoices, cm, 5)
        create_param("publish_to_web", SqlDbType.VarChar, ParameterDirection.Input, publishToWeb, cm, 5)
        create_param("web_report_name", SqlDbType.VarChar, ParameterDirection.Input, webReportName, cm, 60)
        create_param("use_for_customer_billing", SqlDbType.VarChar, ParameterDirection.Input, useForCustomerBilling, cm, 5)
        create_param("id", SqlDbType.Int, ParameterDirection.Input, instanceNo, cm)
        create_param("is_final_version", SqlDbType.VarChar, ParameterDirection.Input, isFinalVersion, cm, 5)


        cm.CommandType = CommandType.Text
        cm.CommandText = sStmt


        If Not IsNothing(sqlTran) Then
            cm.Transaction = sqlTran
        End If

        nRecords = cm.ExecuteNonQuery()

        If nRecords > 0 Then
            'ok
            insert_glminvoice_report_criteria = True
        Else
            'nDbTran = 0
            MsgBox("Failed to insert in RptCriteriaGlmInvoice table. " & vbCrLf & "Review logfile for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            insert_glminvoice_report_criteria = False
            Exit Function
        End If

    End Function
    'E014-PENDING
    'Inserts record in RptCriteriaCostCont
    Public Function insert_costcont_report_criteria(ByRef custId As String, ByRef repNo As Short, ByRef reportId As Integer, ByRef stateId As String, ByRef groupSeq As Short, ByRef repTemplateName As String, ByRef reportCaption As String, ByRef isPeriodSeq As String, ByRef periodSeq As Short, ByRef startDate As Date, ByRef endDate As Date, ByRef printEquipmentStatus As String, ByRef showDetailedCharges As String, ByRef showContractDate As String, ByRef showSavingsPercentTotal As String, ByRef publishToWeb As String, ByRef webReportName As String, ByRef useGlmRate As String, ByRef showGlmVendor As String, ByRef isFinalVersion As String, ByVal periodAsInvoice As String) As Boolean

        Dim nRecords As Short

        nRecords = 0

        sStmt = "INSERT INTO RptCriteriaCostCont (cust_id, rep_no, report_id," & " state_id, group_seq, rep_template_name, report_caption, " & " is_period_seq, period_seq, start_date, end_date, " & " print_equipment_status, show_detailed_charges, " & " show_contract_date, show_savings_percent_total, " & " publish_to_web, web_report_name, " & " use_glm_rate, show_glm_vendor, is_final_version) " & _
        " VALUES (" & _
        "@cust_id, @rep_no, @report_id, @state_id, @group_seq, @rep_template_name, @report_caption, @is_period_seq, @period_seq," & _
        "@start_date, @end_date, @print_equipment_status, @show_detailed_charges, @show_contract_date, @show_savings_percent_total," & _
        "@publish_to_web, @web_report_name, @use_glm_rate, @show_glm_vendor, @is_final_version )"
        '" VALUES (@cust_id, @rep_no, @report_id, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ? )"
        '        sStmt = sStmt & "'" & Trim(custId) & "'," &_
        '"'" & Trim(custId) & "'," &_
        '        "'" & Trim(custId) & "'," &_
        '        "'" & Trim(custId) & "'," &_
        cm = cn.CreateCommand()
        cm.CommandType = CommandType.Text
        cm.CommandText = sStmt

        Dim prm As SqlParameter = New SqlParameter()
        prm.SqlDbType = SqlDbType.Date
        prm.Direction = ParameterDirection.Input
        create_param("cust_id", SqlDbType.Char, ParameterDirection.Input, Trim(custId), cm, 2)
        'create_param("cust_id", SqlDbType.Int, ParameterDirection.Input, Trim(custId), cm, 2)
        create_param("rep_no", SqlDbType.Int, ParameterDirection.Input, repNo, cm)
        create_param("report_id", SqlDbType.Int, ParameterDirection.Input, reportId, cm)
        create_param("state_id", SqlDbType.VarChar, ParameterDirection.Input, Trim(stateId), cm, 3)
        create_param("group_seq", SqlDbType.Int, ParameterDirection.Input, groupSeq, cm)
        create_param("rep_template_name", SqlDbType.VarChar, ParameterDirection.Input, repTemplateName, cm, 50)
        create_param("report_caption", SqlDbType.VarChar, ParameterDirection.Input, reportCaption, cm, 30)
        create_param("is_period_seq", SqlDbType.VarChar, ParameterDirection.Input, isPeriodSeq, cm, 5)
        create_param("period_seq", SqlDbType.Int, ParameterDirection.Input, periodSeq, cm)
        create_param("start_date", SqlDbType.Date, ParameterDirection.Input, startDate, cm)
        create_param("end_date", SqlDbType.Date, ParameterDirection.Input, endDate, cm)
        create_param("print_equipment_status", SqlDbType.VarChar, ParameterDirection.Input, printEquipmentStatus, cm, 5)
        create_param("show_detailed_charges", SqlDbType.VarChar, ParameterDirection.Input, showDetailedCharges, cm, 5)
        create_param("show_contract_date", SqlDbType.VarChar, ParameterDirection.Input, showContractDate, cm, 5)
        create_param("show_savings_percent_total", SqlDbType.VarChar, ParameterDirection.Input, showSavingsPercentTotal, cm, 5)
        create_param("publish_to_web", SqlDbType.VarChar, ParameterDirection.Input, publishToWeb, cm, 5)
        create_param("web_report_name", SqlDbType.VarChar, ParameterDirection.Input, webReportName, cm, 60)
        create_param("use_glm_rate", SqlDbType.VarChar, ParameterDirection.Input, useGlmRate, cm, 5)
        create_param("show_glm_vendor", SqlDbType.VarChar, ParameterDirection.Input, showGlmVendor, cm, 5)
        create_param("is_final_version", SqlDbType.VarChar, ParameterDirection.Input, isFinalVersion, cm, 5)
        prm = cm.Parameters(0)

        Try
            'cm.ExecuteNonQuery()
            nRecords = cm.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox("Error: " & ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

        If nRecords > 0 Then
            'ok
            insert_costcont_report_criteria = True
        Else
            'nDbTran = 0
            MsgBox("Failed to insert in RptCriteriaGlmInvoice table. " & vbCrLf & "Review logfile for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            insert_costcont_report_criteria = False
            Exit Function
        End If




    End Function


    Private Sub create_param(ByRef nombreParametro As String, ByRef tipo As SqlDbType, _
                            ByRef destino As ParameterDirection, ByRef valor As Object, _
                            ByRef raCmd As SqlCommand, Optional ByRef tamanio As Integer = 0)

        Dim raPrm As SqlParameter

        If raCmd Is Nothing Then
            raCmd = New SqlCommand()
        End If

        raPrm = New SqlParameter(nombreParametro, tipo, tamanio, destino)
        raPrm.Value = valor
        raCmd.Parameters.Add(raPrm)

    End Sub



    Public Function update_glminvoice_report_criteria(ByRef custId As String, ByRef repNo As Short, ByRef reportId As Integer, ByRef stateId As String, ByRef groupSeq As Short, ByRef repTemplateName As String, ByRef reportCaption As String, ByRef isPeriodSeq As String, ByRef periodSeq As Short, ByRef startDate As Date, ByRef endDate As Date, ByRef displayStoreWithInvoices As String, ByRef publishToWeb As String, ByRef webReportName As String, ByRef useForCustomerBilling As String, ByRef oldReportId As Integer, ByRef nInstanceNo As Integer, ByRef sIsFinalVersion As String) As Boolean

        Dim nRecords As Short
        Dim cmd As SqlCommand = cn.CreateCommand()
        nRecords = 0
        Dim nTrans As SqlTransaction
        nTrans = cn.BeginTransaction()

        sStmt = "UPDATE rptCriteriaGlmInvoice " & " SET use_for_customer_billing='FALSE' " & " WHERE cust_id = '" & Trim(custId) & "' " & " AND rep_no = " & Str(repNo) & " AND report_id = " & Str(oldReportId)
        cmd.CommandText = sStmt


        cm.CommandType = CommandType.Text
        cm.CommandText = sStmt
        cm.Transaction = nTrans
        nRecords = cm.ExecuteNonQuery()
        If nRecords > 0 Then
            'ok
            If insert_glminvoice_report_criteria(custId, repNo, reportId, stateId, groupSeq, repTemplateName, reportCaption, isPeriodSeq, periodSeq, startDate, endDate, displayStoreWithInvoices, publishToWeb, webReportName, useForCustomerBilling, nInstanceNo, sIsFinalVersion, nTrans) = True Then

                nTrans.Commit()
                update_glminvoice_report_criteria = True
            Else
                nTrans.Rollback()
                MsgBox("Failed to insert GIR report with id:" & Str(reportId), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                update_glminvoice_report_criteria = False

            End If




        Else
            nTrans.Rollback()

            MsgBox("Failed to update existing GIR report with id:" & Str(oldReportId), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            update_glminvoice_report_criteria = False

        End If


    End Function
    Public Function getRepNo(ByRef sLocalReport As String) As String


        sStmt = "SELECT rep_no FROM repdef " & "WHERE rep_caption='" & Trim(sLocalReport) & "'"
        Dim dummy As gDumpUDT
        'UPGRADE_WARNING: Couldn't resolve default property of object dummy. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        dummy = exec_sql_single(sStmt)


        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(dummy.str1) Then
            getRepNo = ""
        Else
            getRepNo = dummy.str1
        End If

    End Function
    Public Function get_report_id() As Integer
        nReport = 0
        nReport = get_seed("repdata")

        get_report_id = nReport

        If nReport <= 0 Then
            MsgBox("Unable to get Report Number." & vbCrLf & "Report has not been generated.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Function
        End If

    End Function



    Public Sub log_report_parameters(ByRef sReportName As String, ByRef cm As SqlCommand)

        Dim sParams As String
        Dim p As SqlParameter
        Dim sValue As String

        p = New SqlParameter()

        sParams = "Report parameters:" & vbCrLf

        For Each p In cm.Parameters
            Try
                If IsNothing(p.Value) Or IsDBNull(p.Value) Then
                    sValue = "NULL"
                Else
                    sValue = p.Value
                End If
            Catch ex As Exception
                sValue = "NULL"
            End Try

            sParams = sParams & " SET " & p.ParameterName & " = " & sValue & vbCrLf
        Next p


        write_msg(sReportName, sParams)

    End Sub

    Public Function hasCustomerInvoice(ByRef sCustId As String, ByRef nId As Short) As gDumpUDT


        Dim rsCust As DataTable
        Dim cmd As SqlCommand = cn.CreateCommand()
        hasCustomerInvoice.str1 = "FALSE"
        hasCustomerInvoice.str2 = ""

        sStmt = "SELECT cust_id, invoice_date, billing_period, id  " & " FROM CustomerInvoice " & " WHERE cust_id = '" & sCustId & "' " & " AND id = " & Str(nId)
        cmd.CommandText = sStmt

        rsCust = getDataTable(sStmt) ' cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic)

        If rsCust.Rows.Count > 0 Then
            hasCustomerInvoice.str1 = "TRUE"
            hasCustomerInvoice.str2 = "CustId:" + rsCust.Rows(0).Item("cust_id") + " Invoice Date:" + CStr(rsCust.Rows(0).Item("invoice_date")) + " Billing Period:" + rsCust.Rows(0).Item("billing_period")
        End If



    End Function
    'Deletes one record from Customer Invoice table
    Public Function deleteSingleCustomerInvoice(ByRef nCustInvSeq As Short) As Boolean

        Dim nRecords As Short = -1
        Dim rsDeleteInvoice As DataTable
        Dim cmd As SqlCommand = cn.CreateCommand()

        deleteSingleCustomerInvoice = False

        sStmt = "SELECT suser_name " & "FROM suser " & "WHERE suser_name='" & Trim(gsUser) & "' and type_id = 'A'"
        cmd.CommandText = sStmt
        Try
            rsDeleteInvoice = exec_sql(sStmt)
            If Not rsDeleteInvoice.Rows.Count > 0 Then
                MsgBox("Your user account does not have privileges for the requested command." & vbCrLf & "Please contact your Administrator to perform this action.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
            End If
            Exit Function

        Catch e As Exception
            MsgBox("Your Account does not have access to such Information." & vbCrLf & "Contact your System Administrator to get proper access.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
            Exit Function
        End Try

        'rsDeleteInvoice.Close()

        sStmt = "DELETE FROM CustomerInvoice WHERE cust_invoice_seq=" & Str(nCustInvSeq)
        cmd.CommandText = sStmt
        Try
            nRecords = cmd.ExecuteNonQuery()
            If nRecords > 0 Then
                'ok
                deleteSingleCustomerInvoice = True
            Else
                MsgBox("Failed to delete in Transaction table. " & vbCrLf & "Review logfile for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            End If
            Exit Function

        Catch
            save_error("Report module", "deleteSingleCustomerInvoice")
            deleteSingleCustomerInvoice = False

        End Try

    End Function
    'Returns the report_id for the CCR report for the given customer,
    'period and store_group
    'Returns zero if not found.
    Public Function getCCRFinalVersion(ByRef sCustId As String, ByRef nPeriodSeq As Short, ByRef nGroupSeq As Short) As Integer

        getCCRFinalVersion = 0

        Dim rsCCR As DataTable
        Dim cmd As SqlCommand = cn.CreateCommand()
        Dim query As String
        query = "SELECT report_id FROM rptCriteriaCostCont " & " WHERE  cust_id = '" & sCustId & "' " & " AND period_seq = " & Str(nPeriodSeq) & " AND group_seq = " & Str(nGroupSeq) & " AND is_final_version = 'TRUE' "
        cmd.CommandText = query

        rsCCR = getDataTable(query) 'cmd.ExecuteReader()

        If rsCCR.Rows.Count > 0 Then
            getCCRFinalVersion = rsCCR.Rows(0).Item("report_id")
        End If



    End Function

    Public Function getGIRFinalVersion(ByRef sCustId As String, ByRef nPeriodSeq As Short, ByRef nGroupSeq As Short) As Integer

        getGIRFinalVersion = 0

        Dim rsGIR As DataTable
        Dim cmd As SqlCommand = cn.CreateCommand()

        Dim query As String
        query = "SELECT report_id FROM rptCriteriaGlmInvoice " & " WHERE  cust_id = '" & sCustId & "' " & " AND period_seq = " & Str(nPeriodSeq) & " AND group_seq = " & Str(nGroupSeq) & " AND is_final_version = 'TRUE' "
        cmd.CommandText = query
        
        rsGIR = getDataTable(query) ' cmd.ExecuteReader() '.Open(query, cn, ADODB.CursorTypeEnum.adOpenStatic)

        If rsGIR.Rows.Count > 0 Then
            getGIRFinalVersion = rsGIR.Rows(0).Item("report_id")
        End If



    End Function

    'This form let the user select the printer before displaying the report.
    Public Function find_printer(ByRef Form As System.Windows.Forms.Form) As Boolean

        'If no printers found send an error
        'UPGRADE_ISSUE: Printers method Printers.Count was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If PrinterSettings.InstalledPrinters.Count <= 0 Then
            MsgBox("There are not printers defined in this computer." & vbCrLf & "Please set up a default printer before proceeding.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message")

            find_printer = False
            Exit Function
        End If

        'VB6.ShowForm(frmPrinter, VB6.FormShowConstants.Modal, Form)
        find_printer = True
        'If gbPrinter Then
        '    find_printer = True
        'Else
        '    find_printer = False
        'End If
    End Function


    Public Sub printer_options2(ByRef bOption As Boolean)
        'Dim i As Short

        'Static nDefault As String
        'Agregar forma para seleccionar otra impresora que no
        'sea la impresora default
        If bOption Then

            'For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            '   If Printer.DeviceName = Printers(i).DeviceName Then
            '     nDefault = i
            'Selecciono la impresora por defecto
            '     Set Printer = Printers(i)
            '     Exit For
            '   End If
            'Next
            'Printer.Width = 16560
            'Printer.PaperSize = vbPRPSLegal
            'UPGRADE_ISSUE: Constant vbPRPSLetter was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
            'UPGRADE_ISSUE: Printer property Printer.PaperSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.PaperSize = vbPRPSLetter
            'UPGRADE_ISSUE: Constant vbPRORLandscape was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
            'UPGRADE_ISSUE: Printer property Printer.Orientation was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.Orientation = vbPRORLandscape

        Else
            'Codigo para cambiar de impresora y opciones de impresion
        End If
    End Sub

    'Returns CCR recordset with mapped fields
    Public Function ccr_map_fields_data(ByRef nReportId As Integer) As DataTable
        Dim cmd As SqlCommand = cn.CreateCommand()
        get_ccr_map_fields()

        sStmt = sStmt & Str(nReportId)

        'rsReport = cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        ccr_map_fields_data = getDataTable(sStmt) 'rsReport
        Exit Function

    End Function

    'Returns string to map CCR columns
    Public Sub get_ccr_map_fields()

        sStmt = "SELECT account, account_no, content_desc, cust_id, " & "cust_name, eqpt_mask, eqpt_seq, frequency_mask, " & _
        "invoice, invoice_no, location, old_rate, " & _
        "rate, rate_status,CONVERT(varchar, report_end, 101)  report_end, CONVERT(varchar, report_start, 101) report_start, " & "savings, comment,serv_desc," & _
        "serv_desc1, serv_sum1, serv_desc2, serv_sum2, " & "serv_desc3, serv_sum3, serv_desc4, serv_sum4, " & _
        "serv_desc5, serv_sum5, serv_desc6, serv_sum6, " & "serv_desc7, serv_sum7, serv_desc8, serv_sum8, " & _
        "serv_desc9, serv_sum9, serv_desc10, serv_sum10, " & "serv_desc11, serv_sum11, serv_desc12, serv_sum12, " & _
        "serv_desc13, serv_sum13, serv_desc14, serv_sum14, " & "serv_desc101, serv_sum101, " & "serv_desc102, serv_sum102, " & _
        "serv_desc103, serv_sum103, " & "serv_desc104, serv_sum104, " & "serv_desc105, serv_sum105, " & "serv_desc106, serv_sum106, " & _
        "serv_desc107, serv_sum107, " & "serv_id, "

        'unidades, usage, store_id, store_no,
        sStmt = sStmt & "units, serv_usage, store_id, store_no," & "total_charges, total_savings, " & " total_serv, total_units," & _
        "unit_type, vend_name, vend_seq, " & "vinvoice_date, eqpt_temp, units, " & "serv_usage , total_nonbillsavings, contract_range,  " & _
        "total_savingsPercent, label_savingsPercent, store_savings, store_name, " & _
        "account_mask, glm_savings, contract_opening_date, contract_expiration_date, " & _
        "store_address, store_city, state_id, store_number, glm_rate, current_rate, " & _
        "current_glmrate_savings, total_current_glmrate_savings, store_current_glmrate_savings, " & _
        "total_glmrate_serv, total_glmrate_charges, store_total, store_fee, total_store_flat_fee, invoice_mask " & _
        " FROM RptCostCont " & " WHERE report_id = "


    End Sub
    'Generates Recycle Tonnage report and saves it in Rpt
    Public Sub GenerateRepRecycleTonGeneral(ByRef params As gRptRecycleTonGenParamUDT)
        Dim sEqptType As Object
        Dim nDumpWgt As Double = 0
        Dim nDumpCompWgt As Object
        Dim cmd As SqlCommand = cn.CreateCommand()

        'Dim storeRec As gStoreRecordUDT

        'The following Collection has records of type:
        '   cust_id,
        '   store_id,
        '   baler_wgt,
        '   pkr_wgt,
        '   dump_wgt,
        '   tote_wgt,
        '   dump_composting_wgt,
        '   tote_composting_wgt,
        '   opentop_construction_wgt,
        '   dump_trash_wgt
        '   identified by cust_id-store_id
        Dim stores As New Collection
        Dim recycleStores As New Collection
        Dim trashStores As New Collection
        Dim allStores As New Collection

        Dim rsTonReport As New DataTable
        Dim store As Object
        Dim sContentDesc As String
        Dim sEqptDesc As String
        Dim sEqptTypeDesc As String

        Dim nPoundsPerBaler As Double
        Dim nPoundsPerYdInPKR As Double
        Dim nPoundsPerYdInDUM As Double
        Dim nPoundsPerYdInTOT As Double
        Dim nPoundsPerGalInTOT As Double
        Dim nPoundsPerYdInDUMCompost As Double
        Dim nPoundsPerYdInTOTCompost As Double
        Dim nPoundsPerYdInOTCondemo As Double
        Dim nPoundsPerYdInDUMTrash As Double
        Dim nPoundsPerYdInPKRTrash As Double
        Dim nPoundsPerGalInTotTrash As Double
        Dim nPoundsPerYdInVIPTrash As Double
        Dim nPoundsPerYdInOTTrash As Double
        Dim nPoundsPerYdInTotTrash As Double

        Dim nBalerWgt As Double
        Dim nEqptSeq As Short
        Dim nPkrWgt As Double
        Dim nDumWgt As Double
        Dim nDumCompWgt As Double
        Dim nTotWgt As Double
        Dim nTotCompWgt As Double
        Dim nOtCondemoWgt As Double
        Dim nDumTrashWgt As Double
        Dim nPkrTrashWgt As Double
        Dim nStoreRecycle As Double
        Dim nStoreTrash As Double
        Dim nTotTrashWgt As Double
        Dim nVipTrashWgt As Double
        Dim nOtTrashWgt As Double
        Dim nPkrWgtContaminated As Double


        Dim recycleStore As Object
        Dim recIdx As Short
        recIdx = 0

        'Stores collection indices
        CUST_IDX = 0
        STORE_IDX = 1
        STORE_NUMBER_IDX = 2
        STORE_NAME_IDX = 3
        BALERWGT_IDX = 4
        PKRWGT_IDX = 5
        DUMWGT_IDX = 6
        TOTWGT_IDX = 7
        DUMWGTCOMPOST_IDX = 8
        TOTWGTCOMPOST_IDX = 9
        OTWGTDCONDEMO_IDX = 10 'Open Top - Construction Demolition
        DUMWGTTRASH_IDX = 11
        PKRWGTTRASH_IDX = 12
        TOTWGTTRASH_IDX = 13
        VIPWGTTRASH_IDX = 14
        OTWGTTRASH_IDX = 15
        PKRWGTCONTAMINATED_IDX = 16
        STORE_RECYCLE_IDX = 17
        STORE_TRASH_IDX = 18


        storesIdx = 0

        nBalerWgt = 0
        nPkrWgt = 0
        nDumWgt = 0
        'UPGRADE_WARNING: Couldn't resolve default property of object nDumpCompWgt. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        nDumpCompWgt = 0
        nTotWgt = 0
        nTotCompWgt = 0
        nOtCondemoWgt = 0
        nDumTrashWgt = 0
        nStoreRecycle = 0
        nStoreTrash = 0
        nPkrTrashWgt = 0
        nTotTrashWgt = 0
        nVipTrashWgt = 0
        nOtTrashWgt = 0
        nPkrWgtContaminated = 0

        '1.Get list of Stores with invoices for given period(s) and saves them in stores array
        sStmt = "" & _
        "SELECT DISTINCT a.cust_id, a.store_id, a.store_number, a.store_address " & _
        " FROM Store a, VInvoice b " & _
        " WHERE a.cust_id = '" & params.sCustId & "' " & _
        " AND a.cust_id = b.cust_id " & _
        " AND a.store_id = b.store_id " & _
        " AND a.store_status = 'A' " & _
        " AND b.period_seq IN ( " & params.sPeriodSeqList & ")" & _
        " AND a.store_id IN ( SELECT store_id FROM groupStore gs " & _
        "                       WHERE gs.cust_id =  a.cust_id " & _
        "                       AND gs.group_seq = " & Str(params.nGroupSeq) & " ) "
        '" and a.store_number in ('ATTRDP03') "
        'ND242
        'ND621
        'ND628
        cmd.CommandText = sStmt
        rs = getDataTable(sStmt) ' cmd.ExecuteReader()

        For row As Integer = 0 To rs.Rows.Count - 1
            stores.Add(New Object() {rs.Rows(row).Item("cust_id"), _
                                    rs.Rows(row).Item("store_id"), _
                                    rs.Rows(row).Item("store_number"), _
                                    rs.Rows(row).Item("store_address"), _
                                    nBalerWgt, _
                                    nPkrWgt, _
                                    nDumpWgt, nTotWgt, _
                                    nDumCompWgt, nTotCompWgt, _
                                    nOtCondemoWgt, nDumTrashWgt, _
                                    nPkrTrashWgt, nTotTrashWgt, _
                                    nVipTrashWgt, nOtTrashWgt, nPkrWgtContaminated, _
                                    nStoreRecycle, nStoreTrash}, _
                                    rs.Rows(row).Item("cust_id") + Str(rs.Rows(row).Item("store_id")))

            'stores.Add Array(rs.item("cust_id").value, _
            'rs.item("store_id").value, _
            'rs.item("store_number").value, _
            'rs.item("store_address").value, _
            'nBalerWgt, _
            'nPkrWgt, _
            'nDumpWgt, nTotWgt, _
            'nDumCompWgt, nTotCompWgt, _
            'nOtCondemoWgt, nDumTrashWgt, _
            'nStoreRecycle, nStoreTrash), _
            'getStoresIdx
        Next

        'Look for conversion factors once
        If stores.Count() > 0 Then
            nPoundsPerBaler = getPoundsPerBaler()
            nPoundsPerYdInPKR = getPoundsPerYdInPKR()
            nPoundsPerYdInDUM = getPoundsPer(RPTRECYCLETONGEN_EQPT_DUMP, _
                RPTRECYCLETONGEN_RECYCLE, RPTRECYCLETONGEN_UOM_YARDS)

            nPoundsPerYdInTOT = getPoundsPer(RPTRECYCLETONGEN_EQPT_TOTE, _
                RPTRECYCLETONGEN_RECYCLE, RPTRECYCLETONGEN_UOM_YARDS)

            nPoundsPerGalInTOT = getPoundsPer(RPTRECYCLETONGEN_EQPT_TOTE, _
                RPTRECYCLETONGEN_RECYCLE, RPTRECYCLETONGEN_UOM_GAL)

            nPoundsPerYdInDUMCompost = getPoundsPer(RPTRECYCLETONGEN_EQPT_DUMP, _
                RPTRECYCLETONGEN_COMPOST, RPTRECYCLETONGEN_UOM_YARDS)

            nPoundsPerYdInTOTCompost = getPoundsPer(RPTRECYCLETONGEN_EQPT_TOTE, _
                RPTRECYCLETONGEN_COMPOST, RPTRECYCLETONGEN_UOM_GAL)

            nPoundsPerYdInOTCondemo = getPoundsPer(RPTRECYCLETONGEN_EQPT_OT, _
                RPTRECYCLETONGEN_CONDEMO, RPTRECYCLETONGEN_UOM_YARDS)

            nPoundsPerYdInDUMTrash = getPoundsPer(RPTRECYCLETONGEN_EQPT_DUMP, _
                RPTRECYCLETONGEN_TRASH, RPTRECYCLETONGEN_UOM_YARDS)

            nPoundsPerYdInPKRTrash = getPoundsPer(RPTRECYCLETONGEN_EQPT_PKR, _
                RPTRECYCLETONGEN_TRASH, RPTRECYCLETONGEN_UOM_YARDS)

            nPoundsPerGalInTotTrash = getPoundsPer(RPTRECYCLETONGEN_EQPT_TOTE, _
                RPTRECYCLETONGEN_TRASH, RPTRECYCLETONGEN_UOM_GAL)

            nPoundsPerYdInVIPTrash = getPoundsPer(RPTRECYCLETONGEN_EQPT_VIP, _
                RPTRECYCLETONGEN_TRASH, RPTRECYCLETONGEN_UOM_YARDS)

            nPoundsPerYdInOTTrash = getPoundsPer(RPTRECYCLETONGEN_EQPT_OT, _
                RPTRECYCLETONGEN_TRASH, RPTRECYCLETONGEN_UOM_YARDS)

            nPoundsPerYdInTotTrash = getPoundsPer(RPTRECYCLETONGEN_EQPT_TOTE, _
                RPTRECYCLETONGEN_TRASH, RPTRECYCLETONGEN_UOM_YARDS)

        End If


        Dim sCustId As String
        Dim nStoreId As Short
        Dim storesSize As Short
        Dim idx As Short
        idx = 1
        storesSize = stores.Count()

        '2.Get list of recycling equipment on each store
        For Each store In stores
            'Debug.Print store(0) + " " + store(1)


            sCustId = store(CUST_IDX)
            nStoreId = store(STORE_IDX)

            sStmt = "SELECT a.eqpt_seq , d.content_desc, a.eqpt_desc, a.store_id, e.eqpt_type " & _
                    " FROM StoreEqpt a, ContentGroup b, ContentGroupDet c, Content d, Equipment e " & _
                    " WHERE a.cust_id = '" & sCustId & "'" & _
                    " AND a.store_id= " & Str(nStoreId) & _
                    " AND a.content_id = c.content_id " & _
                    " AND b.content_group_id = c.content_group_id " & _
                    " AND b.content_group_name ='RPTRECYCLETONGEN_RECYCLE' " & _
                    " AND c.content_id = d.content_id " & _
                    " AND a.eqpt_id = e.eqpt_id " & _
                    " ORDER BY a.store_id "

            cmd.CommandText = sStmt
            Debug.Print("Storeid:" & Str(nStoreId))

            rsTonReport = getDataTable(sStmt) 'cmd.ExecuteReader()

            For row As Integer = 0 To rsTonReport.Rows.Count - 1
                sContentDesc = Trim(rsTonReport.Rows(row).Item("content_desc"))
                sEqptDesc = Trim(rsTonReport.Rows(row).Item("eqpt_desc"))
                nEqptSeq = rsTonReport.Rows(row).Item("eqpt_seq")
                sEqptType = Trim(rsTonReport.Rows(row).Item("eqpt_type"))


                Debug.Print("--EqptDesc:" & sEqptDesc & "   Content:" & sContentDesc)
                'Debug.Print "Content:" + sContentDesc

                'Recycle Balers
                If (sContentDesc = RPTRECYCLETONGEN_OCC_BALES Or _
                    sContentDesc = RPTRECYCLETONGEN_OCC) And _
                    sEqptType = RPTRECYCLETONGEN_EQPT_BALER Then

                    nBalerWgt = rrtg_process_bale(sCustId, nStoreId, nEqptSeq, _
                        params, nPoundsPerBaler)

                    store(BALERWGT_IDX) = store(BALERWGT_IDX) + System.Math.Round(nBalerWgt, 2)

                    Debug.Print("---Baler wgt Tons:" & Str(nBalerWgt))
                End If

                'Recycle Compactors PKR
                If (sContentDesc = RPTRECYCLETONGEN_RECYCLE Or _
                    sContentDesc = RPTRECYCLETONGEN_COMMINGLED_RECYCLE) _
                    And sEqptType = RPTRECYCLETONGEN_EQPT_PKR Then

                    nPkrWgtContaminated = rrtg_process_contaminated(sCustId, nStoreId, _
                        nEqptSeq, params, _
                        nPoundsPerYdInPKR, _
                        RPTRECYCLETONGEN_CONT_TON, _
                        RPTRECYCLETONGEN_CONT_PU, _
                        RPTRECYCLETONGEN_PU_FREQUENCY)

                    If (nPkrWgtContaminated > 0) Then
                        store(PKRWGTCONTAMINATED_IDX) = store(PKRWGTCONTAMINATED_IDX) + System.Math.Round(nPkrWgtContaminated, 2)

                        Debug.Print("---Recycle PKR Contaminated wgt Tons:" & Str(nPkrWgtContaminated))
                        nPkrWgtContaminated = 0
                    Else
                        nPkrWgt = rrtg_process(sCustId, nStoreId, _
                            nEqptSeq, params, _
                            nPoundsPerYdInPKR, _
                            nPoundsPerYdInPKR, _
                            "RPTRECYCLETONGEN_PKR_TON", _
                            "RPTRECYCLETONGEN_PKR_PU", _
                            RPTRECYCLETONGEN_PU_FREQUENCY)

                        store(PKRWGT_IDX) = store(PKRWGT_IDX) + System.Math.Round(nPkrWgt, 2)
                        Debug.Print("---Recycle PKR wgt Tons:" & Str(nPkrWgt))
                    End If



                End If


                'Recycle Dumpsters
                If (sContentDesc = RPTRECYCLETONGEN_RECYCLE Or _
                    sContentDesc = RPTRECYCLETONGEN_OCC Or _
                    sContentDesc = RPTRECYCLETONGEN_COMMINGLED_RECYCLE Or _
                    sContentDesc = RPTRECYCLETONGEN_BOOK_RECYCLING Or _
                    sContentDesc = RPTRECYCLETONGEN_MIXED_PAPER Or _
                    sContentDesc = RPTRECYCLETONGEN_MIXED_RECYCLE) And _
                    sEqptType = RPTRECYCLETONGEN_EQPT_DUMP _
                Then
                    nDumWgt = rrtg_process_recycle(sCustId, nStoreId, _
                        nEqptSeq, params, _
                        nPoundsPerYdInDUM, _
                        nPoundsPerYdInDUM, _
                        RPTRECYCLETONGEN_DUM_TON, _
                        RPTRECYCLETONGEN_DUM_PU, _
                        RPTRECYCLETONGEN_MONTHLY_FREQUENCY)

                    store(DUMWGT_IDX) = store(DUMWGT_IDX) + System.Math.Round(nDumWgt, 2)

                    Debug.Print("---DUM wgt Tons:" & Str(nDumWgt))
                End If


                'Recycle Tote
                If (sContentDesc = RPTRECYCLETONGEN_RECYCLE Or _
                    sContentDesc = RPTRECYCLETONGEN_PAPER) And _
                    sEqptType = RPTRECYCLETONGEN_EQPT_TOTE _
                Then
                    nTotWgt = rrtg_process_recycle(sCustId, nStoreId, _
                        nEqptSeq, params, _
                        nPoundsPerGalInTOT, _
                        nPoundsPerYdInTOT, _
                        RPTRECYCLETONGEN_TOTE_TON, _
                        RPTRECYCLETONGEN_TOTE_PU, _
                        RPTRECYCLETONGEN_MONTHLY_FREQUENCY)

                    store(TOTWGT_IDX) = store(TOTWGT_IDX) + System.Math.Round(nTotWgt, 2)

                    Debug.Print("---Recycle Tote wgt Tons:" & Str(nTotWgt))

                End If



                'Recycle Composting
                If (sContentDesc = RPTRECYCLETONGEN_COMPOST Or _
                    sContentDesc = RPTRECYCLETONGEN_FOODWASTE) And _
                    sEqptType = RPTRECYCLETONGEN_EQPT_DUMP _
                Then
                    nDumCompWgt = rrtg_process_recycle(sCustId, nStoreId, _
                        nEqptSeq, params, _
                        nPoundsPerYdInDUMCompost, _
                        nPoundsPerYdInDUMCompost, _
                        RPTRECYCLETONGEN_COMPOST_TON, _
                        RPTRECYCLETONGEN_COMPOST_PU, _
                        RPTRECYCLETONGEN_MONTHLY_FREQUENCY)

                    store(DUMWGTCOMPOST_IDX) = store(DUMWGTCOMPOST_IDX) + System.Math.Round(nDumCompWgt, 2)

                    Debug.Print("---DUM wgt Composting Tons:" & Str(nDumWgt))
                End If

                If (sContentDesc = RPTRECYCLETONGEN_COMPOST Or _
                    sContentDesc = RPTRECYCLETONGEN_FOODWASTE) And _
                    sEqptType = RPTRECYCLETONGEN_EQPT_TOTE _
                Then
                    nTotCompWgt = rrtg_process_recycle(sCustId, nStoreId, _
                        nEqptSeq, params, _
                        nPoundsPerYdInTOTCompost, _
                        nPoundsPerYdInTOTCompost, _
                        RPTRECYCLETONGEN_COMPOST_TON, _
                        RPTRECYCLETONGEN_COMPOST_PU, _
                        RPTRECYCLETONGEN_MONTHLY_FREQUENCY)

                    store(TOTWGTCOMPOST_IDX) = store(TOTWGTCOMPOST_IDX) + System.Math.Round(nTotCompWgt, 2)

                    Debug.Print("---TOT wgt Composting Tons:" & Str(nTotCompWgt))
                End If

                'Recycle Open Top
                If (sContentDesc = RPTRECYCLETONGEN_CONDEMO Or _
                    sContentDesc = RPTRECYCLETONGEN_CONCRETE Or _
                    sContentDesc = RPTRECYCLETONGEN_WOOD) And _
                    sEqptType = RPTRECYCLETONGEN_EQPT_OT _
                Then
                    nOtCondemoWgt = rrtg_process_recycle(sCustId, nStoreId, _
                        nEqptSeq, params, _
                        nPoundsPerYdInOTCondemo, _
                        nPoundsPerYdInOTCondemo, _
                        RPTRECYCLETONGEN_CONDEMO_TON, _
                        RPTRECYCLETONGEN_CONDEMO_PU, _
                        RPTRECYCLETONGEN_MONTHLY_FREQUENCY)

                    store(OTWGTDCONDEMO_IDX) = store(OTWGTDCONDEMO_IDX) + System.Math.Round(nOtCondemoWgt, 2)

                    Debug.Print("---OT wgt Const Demo Tons:" & Str(nOtCondemoWgt))
                End If


                'Total Store Recycle
                store(STORE_RECYCLE_IDX) = store(BALERWGT_IDX) + store(PKRWGT_IDX) + _
                                        store(DUMWGT_IDX) + store(TOTWGT_IDX) + _
                                        store(DUMWGTCOMPOST_IDX) + store(TOTWGTCOMPOST_IDX) + _
                                        store(OTWGTDCONDEMO_IDX)

            Next

            


            'stores.Remove idx
            'stores.Add store, store(CUST_IDX) + Str(store(STORE_IDX))
            recycleStores.Add(store, store(CUST_IDX) + Str(store(STORE_IDX)))

            idx = idx + 1
        Next store



        'Trash-----------
        '3.Get list of trash equipment on each store
        idx = 1

        For Each store In stores
            'Debug.Print store(0) + " " + store(1)


            sCustId = store(CUST_IDX)
            nStoreId = store(STORE_IDX)

            sStmt = "SELECT a.eqpt_seq , d.content_desc, a.eqpt_desc, a.store_id, e.eqpt_type " & _
                    " FROM StoreEqpt a, ContentGroup b, ContentGroupDet c, Content d, Equipment e " & _
                    " WHERE a.cust_id = '" & sCustId & "'" & _
                    " AND a.store_id= " & Str(nStoreId) & _
                    " AND a.content_id = c.content_id " & _
                    " AND b.content_group_id = c.content_group_id " & _
                    " AND b.content_group_name ='RPTRECYCLETONGEN_TRASH' " & _
                    " AND c.content_id = d.content_id " & _
                    " AND a.eqpt_id = e.eqpt_id " & _
                    " ORDER BY a.store_id "

            'cmd.CommandText = sStmt
            Debug.Print("TRASH Storeid:" & Str(nStoreId))


            rsTonReport = getDataTable(sStmt) 'cmd.ExecuteReader()

            For row As Integer = 0 To rsTonReport.Rows.Count - 1

                sContentDesc = Trim(rsTonReport.Rows(row).Item("content_desc"))
                sEqptDesc = Trim(rsTonReport.Rows(row).Item("eqpt_desc"))
                nEqptSeq = rsTonReport.Rows(row).Item("eqpt_seq")
                sEqptType = Trim(rsTonReport.Rows(row).Item("eqpt_type"))


                Debug.Print("--EqptDesc:" & sEqptDesc & "   Content:" & sContentDesc)


                'Trash Dumpster
                If sContentDesc = RPTRECYCLETONGEN_TRASH And _
                    sEqptType = RPTRECYCLETONGEN_EQPT_DUMP _
                Then
                    'Test Case 8D.begin
                    'nDumTrashWgt = rrtg_process_trash(sCustId, nStoreId, nEqptSeq,
                    'AFTERMIGRATION.2014.09.13.begin
                    '2015.03.08. As per TC-28 The "Service Rater Per Month" service was moved from "RPTRECYCLETONGEN_TRASH_TON" group to "RPTRECYCLETONGEN_TRASH_TON" group
                    'and the formula to compute Trash weight in Dumpster was changed from rrtg_process_trash to rrtg_process_recycle


                    nDumTrashWgt = rrtg_process_recycle(sCustId, nStoreId, _
                                nEqptSeq, params, _
                                nPoundsPerYdInDUMTrash, _
                                nPoundsPerYdInDUMTrash, _
                                RPTRECYCLETONGEN_TRASH_TON, _
                                RPTRECYCLETONGEN_TRASH_PU, _
                                RPTRECYCLETONGEN_MONTHLY_FREQUENCY)
                    'Test Case 8D.end

                    store(DUMWGTTRASH_IDX) = store(DUMWGTTRASH_IDX) + System.Math.Round(nDumTrashWgt, 2)

                    Debug.Print("---Dumpster Trash wgt Tons:" & Str(nDumTrashWgt))
                End If

                'Trash Compactor
                If sContentDesc = RPTRECYCLETONGEN_TRASH And _
                    sEqptType = RPTRECYCLETONGEN_EQPT_PKR _
                Then
                    nPkrTrashWgt = rrtg_process(sCustId, nStoreId, nEqptSeq, _
                                    params, _
                                    nPoundsPerYdInPKRTrash, _
                                    nPoundsPerYdInPKRTrash, _
                                    RPTRECYCLETONGEN_TRASH_PKR_TON, _
                                    RPTRECYCLETONGEN_TRASH_PKR_PU, _
                                    RPTRECYCLETONGEN_MONTHLY_FREQUENCY)

                    store(PKRWGTTRASH_IDX) = store(PKRWGTTRASH_IDX) + System.Math.Round(nPkrTrashWgt, 2)

                    Debug.Print("---Compactor Trash wgt Tons:" & Str(nPkrTrashWgt))
                End If


                'Trash Totes
                'UPGRADE_WARNING: Couldn't resolve default property of object sEqptType. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If sContentDesc = RPTRECYCLETONGEN_TRASH And _
                    sEqptType = RPTRECYCLETONGEN_EQPT_TOTE _
                Then
                    'AFTERMIGRATION.2014.09.13.begin
                    '2015.01.02. As per TC-21 changed from rrtg_process to rrpt_process_recycle to also count freq_times
                    nTotTrashWgt = rrtg_process_recycle(sCustId, nStoreId, nEqptSeq, _
                                    params, _
                                    nPoundsPerGalInTotTrash, _
                                    nPoundsPerYdInTotTrash, _
                                    RPTRECYCLETONGEN_TRASH_TOTE_TON, _
                                    RPTRECYCLETONGEN_TRASH_TOTE_PU, _
                                    RPTRECYCLETONGEN_MONTHLY_FREQUENCY)


                    'UPGRADE_WARNING: Couldn't resolve default property of object store(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    store(TOTWGTTRASH_IDX) = store(TOTWGTTRASH_IDX) + System.Math.Round(nTotTrashWgt, 2)

                    Debug.Print("---Tote Trash wgt Tons:" & Str(nTotTrashWgt))
                End If

                'Trash VIP
                'UPGRADE_WARNING: Couldn't resolve default property of object sEqptType. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If sContentDesc = RPTRECYCLETONGEN_TRASH And _
                    sEqptType = RPTRECYCLETONGEN_EQPT_VIP _
                Then
                    'AFTERMIGRATION.2014.09.13.begin
                    '2015.02.21 AS per TC-27  changed from rrtg_process to rrpt_process_recycle to consider pounts per Service
                    nVipTrashWgt = rrtg_process_recycle(sCustId, nStoreId, nEqptSeq, _
                                    params, _
                                    nPoundsPerYdInVIPTrash, _
                                    nPoundsPerYdInVIPTrash, _
                                    RPTRECYCLETONGEN_TRASH_VIP_TON, _
                                    RPTRECYCLETONGEN_TRASH_VIP_PU, _
                                    RPTRECYCLETONGEN_MONTHLY_FREQUENCY)


                    'UPGRADE_WARNING: Couldn't resolve default property of object store(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    store(VIPWGTTRASH_IDX) = store(VIPWGTTRASH_IDX) + System.Math.Round(nVipTrashWgt, 2)

                    Debug.Print("---VIP Trash wgt Tons:" & Str(nVipTrashWgt))
                End If

                'Trash O/T
                'UPGRADE_WARNING: Couldn't resolve default property of object sEqptType. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If sContentDesc = RPTRECYCLETONGEN_TRASH And _
                    sEqptType = RPTRECYCLETONGEN_EQPT_OT _
                Then
                    'AFTERMIGRATION.2014.09.13.begin
                    'nOtTrashWgt = rrtg_process(sCustId, nStoreId, nEqptSeq, _
                    '        params, nPoundsPerGalInTotTrash, _
                    '        RPTRECYCLETONGEN_TRASH_OT_TON, _
                    '        RPTRECYCLETONGEN_TRASH_OT_PU, _
                    '        RPTRECYCLETONGEN_MONTHLY_FREQUENCY)

                    nOtTrashWgt = rrtg_process(sCustId, nStoreId, nEqptSeq, _
                                    params, _
                                    nPoundsPerYdInTotTrash, _
                                    nPoundsPerYdInTotTrash, _
                                    RPTRECYCLETONGEN_TRASH_OT_TON, _
                                    RPTRECYCLETONGEN_TRASH_OT_PU, _
                                    RPTRECYCLETONGEN_MONTHLY_FREQUENCY)


                    'UPGRADE_WARNING: Couldn't resolve default property of object store(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    store(OTWGTTRASH_IDX) = store(OTWGTTRASH_IDX) + System.Math.Round(nOtTrashWgt, 2)

                    Debug.Print("---Open Top Trash wgt Tons:" & Str(nOtTrashWgt))
                End If

                store(STORE_TRASH_IDX) = store(DUMWGTTRASH_IDX) + store(PKRWGTTRASH_IDX) + _
                                    store(TOTWGTTRASH_IDX) + store(VIPWGTTRASH_IDX) + _
                                    store(OTWGTTRASH_IDX)


            Next

            'AFTERMIGRATION.2014.09.13.begin
            'Trash for Contaminated Compactor. Before adding store to trashStore collection
            'check if there is a recycling contaminated weight for it
            For recIdx = 1 To recycleStores.Count()
                recycleStore = recycleStores.Item(recIdx)

                If recycleStore(PKRWGTCONTAMINATED_IDX) > 0 Then
                    If recycleStore(CUST_IDX) = store(CUST_IDX) And recycleStore(STORE_IDX) = store(STORE_IDX) Then
                        store(STORE_TRASH_IDX) = store(STORE_TRASH_IDX) + recycleStore(PKRWGTCONTAMINATED_IDX)
                    End If
                End If
            Next

            'AFTERMIGRATION.2014.09.13.end

            'stores.Remove idx
            'stores.Add store, store(CUST_IDX) + Str(store(STORE_IDX))
            trashStores.Add(store, store(CUST_IDX) + Str(store(STORE_IDX)))
            idx = idx + 1

        Next store

        'Dim recycleStore As Object
        Dim trashStore As Object

        'showStoresContents
        For idx = 1 To stores.Count()
            recycleStore = recycleStores.Item(idx)
            trashStore = trashStores.Item(idx)

            allStores.Add(New Object() {recycleStore(CUST_IDX), recycleStore(STORE_IDX), _
                    recycleStore(STORE_NUMBER_IDX), recycleStore(STORE_NAME_IDX), _
                    recycleStore(BALERWGT_IDX), recycleStore(PKRWGT_IDX), _
                    recycleStore(DUMWGT_IDX), recycleStore(TOTWGT_IDX), _
                    recycleStore(DUMWGTCOMPOST_IDX), recycleStore(TOTWGTCOMPOST_IDX), _
                    recycleStore(OTWGTDCONDEMO_IDX), trashStore(DUMWGTTRASH_IDX), _
                    trashStore(PKRWGTTRASH_IDX), trashStore(TOTWGTTRASH_IDX), _
                    trashStore(VIPWGTTRASH_IDX), trashStore(OTWGTTRASH_IDX), _
                    recycleStore(PKRWGTCONTAMINATED_IDX), _
                    recycleStore(STORE_RECYCLE_IDX), trashStore(STORE_TRASH_IDX)}, _
                    recycleStore(CUST_IDX) + Str(recycleStore(STORE_IDX)))

        Next

        showStoresContents(allStores)
        'saveReportData stores, params
        saveReportData(allStores, params)
    End Sub
    Private Function getStoresIdx() As String

        storesIdx = storesIdx + 1

        getStoresIdx = Str(storesIdx)
    End Function

    Private Sub showStoresContents(ByVal stores As Collection)
        Dim store As Object

        For Each store In stores
            Debug.Print("CustId=" + store(CUST_IDX))
            Debug.Print("store=" & Str(store(STORE_IDX)))
            Debug.Print("Store Number=" + store(STORE_NUMBER_IDX))
            Debug.Print("Store Name=" + store(STORE_NAME_IDX))
            Debug.Print("Baler wgt=" & Str(store(BALERWGT_IDX)))
            Debug.Print("PKR wgt=" & Str(store(PKRWGT_IDX)))
            Debug.Print("Dumspter wgt=" & Str(store(DUMWGT_IDX)))
            Debug.Print("Tote wgt=" & Str(store(TOTWGT_IDX)))
            Debug.Print("Dumpster Comp wgt=" & Str(store(DUMWGTCOMPOST_IDX)))
            Debug.Print("Tote Comp wgt=" & Str(store(TOTWGTCOMPOST_IDX)))
            Debug.Print("Open Top wgt=" & Str(store(OTWGTDCONDEMO_IDX)))
            Debug.Print("Dumpster trash wgt=" & Str(store(DUMWGTTRASH_IDX)))
            Debug.Print("Pkr trash wgt=" & Str(store(PKRWGTTRASH_IDX)))
            Debug.Print("Tote trash wgt=" & Str(store(TOTWGTTRASH_IDX)))
            Debug.Print("Vip trash wgt=" & Str(store(VIPWGTTRASH_IDX)))
            Debug.Print("Open Top trash wgt=" & Str(store(OTWGTTRASH_IDX)))
            Debug.Print("Store Recycle=" & Str(store(STORE_RECYCLE_IDX)))
            Debug.Print("Store Trash=" & Str(store(STORE_TRASH_IDX)))
        Next store

    End Sub
    'Reads stores array and inserts data into report table
    Private Sub saveReportData(ByVal stores As Collection, ByRef params As gRptRecycleTonGenParamUDT)
        Dim store As Object
        Dim storeTotalTons As Double
        Dim storeCompostingTons As Double
        Dim landfillPercent As Double
        Dim recyclePercent As Double
        Dim nRecords As Short
        Dim cmd As SqlCommand = cn.CreateCommand


        For Each store In stores
            
            storeTotalTons = store(STORE_TRASH_IDX) + store(STORE_RECYCLE_IDX)
            storeCompostingTons = store(DUMWGTCOMPOST_IDX) + store(TOTWGTCOMPOST_IDX)
            If storeTotalTons = 0 Then
                landfillPercent = 0
                recyclePercent = 0
            Else
                landfillPercent = System.Math.Round((store(STORE_TRASH_IDX) / storeTotalTons) * 100, 2)
                recyclePercent = System.Math.Round((store(STORE_RECYCLE_IDX) / storeTotalTons) * 100, 2)
            End If


            sStmt = "INSERT INTO RptRecycleTonGen(report_id, cust_id, cust_name, " & " report_start, report_end, date_range, store_number, store_name, " & " trash_tons, recycle_tons, store_total_tons, " & " store_composting_tons, landfill_percent, recycle_percent) VALUES "
            sStmt = sStmt & "( " & Str(nReport) & ",'" & params.sCustId & "', '" & Trim(params.sCustName) & "', " & "'" & params.sStartDate & "','" & params.sEndDate & "','F','" + store(STORE_NUMBER_IDX) + "','" + store(STORE_NAME_IDX) + "'," + Str(store(STORE_TRASH_IDX)) + "," + Str(store(STORE_RECYCLE_IDX)) + "," + Str(storeTotalTons) + "," + Str(storeCompostingTons) + "," + Str(landfillPercent) + "," + Str(recyclePercent) + ")"
            cmd.CommandText = sStmt
            nRecords = cmd.ExecuteNonQuery()

        Next store

    End Sub
    'Bales use "Service Rate per Month"
    Public Function rrtg_process_bale(ByRef sCustId As String, ByRef nStoreId As Short, ByRef nEqptSeq As Short, ByRef params As gRptRecycleTonGenParamUDT, ByRef nPoundsPerBaler As Double) As Double


        Dim wgt As Double
        Dim rsBale As DataTable
        Dim numBales As Double
        'Dim cmd As SqlCommand = cn.CreateCommand()



        sStmt = " SELECT SUM(b.units) " & _
                " FROM vinvoice a , vinvoicedet b,  service c, storeEqpt d " & _
                " WHERE a.invoice_no = b.invoice_no " & _
                " AND a.cust_id = b.cust_id " & _
                " AND a.store_id = b.store_id " & _
                " AND a.account_no = b.account_no " & _
                " AND a.vend_seq = b.vend_seq " & _
                " AND a.cust_id = '" & sCustId & "' " & _
                " AND a.period_seq IN (" & params.sPeriodSeqList & ") " & _
                " AND a.store_id = " & Str(nStoreId) & _
                " AND b.serv_id = c.serv_id " & _
                " AND b.eqpt_seq = d.eqpt_seq " & _
                " AND d.cust_id = a.cust_id " & _
                " AND d.store_id = a.store_id " & _
                " AND b.eqpt_seq = " & Str(nEqptSeq) & _
                " AND b.serv_id IN (SELECT serv_id FROM serviceGroup e, serviceGroupDet f " & _
                "      WHERE e.serv_group_id = f.serv_group_id " & _
                "      AND e.serv_group_name = 'RPTRECYCLETONGEN_BALER' )"
        'cmd.CommandText = sStmt
        rsBale = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsBale.Rows.Count > 0 Then
            If IsDBNull(rsBale.Rows(0).Item(0)) Then
                numBales = 0
            Else
                numBales = rsBale.Rows(0).Item(0)
            End If
        Else
            numBales = 0
        End If

        wgt = numBales * nPoundsPerBaler / POUNDS_PER_TON


        rrtg_process_bale = wgt
    End Function
    'Compactors(PKR) use "Processing Fee per Ton"
    Public Function rrtg_process_pkr(ByRef sCustId As String, ByRef nStoreId As Short, ByRef nEqptSeq As Short, ByRef params As gRptRecycleTonGenParamUDT, ByVal nPoundsPerYdInPKR As Double) As Double


        Dim wgt As Double
        Dim rsPU As DataTable
        Dim numPU As Double
        Dim eqptQty As Short
        Dim eqptSizeCapacity As Double
        Dim tons As Double
        Dim cmd As SqlCommand = cn.CreateCommand()

        tons = 0

        '1. Look for "Processing Fee per Ton" tonnage,
        'if not found then look for "Service Rate per Haul"
        sStmt = " SELECT sum(b.units)  " & " FROM vinvoice a , vinvoicedet b,  service c, storeEqpt d " & " WHERE a.invoice_no = b.invoice_no " & " AND a.cust_id = b.cust_id " & " AND a.store_id = b.store_id " & " AND a.account_no = b.account_no " & " AND a.vend_seq = b.vend_seq " & " AND a.cust_id = '" & sCustId & "' " & " AND a.period_seq IN (" & params.sPeriodSeqList & ") " & " AND a.store_id = " & Str(nStoreId) & " AND b.serv_id = c.serv_id " & " AND b.eqpt_seq = d.eqpt_seq " & " AND d.cust_id = a.cust_id " & " AND d.store_id = a.store_id " & " AND b.eqpt_seq = " & Str(nEqptSeq) & " AND b.serv_id IN (SELECT serv_id FROM serviceGroup e, serviceGroupDet f " & "      WHERE e.serv_group_id = f.serv_group_id " & "      AND e.serv_group_name = 'RPTRECYCLETONGEN_PKR_TON' )"
        cmd.CommandText = sStmt
        rsPU = getDataTable(sStmt) ' cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If Not IsDBNull(rsPU.Rows(0).Item(0)) Then
            tons = rsPU.Rows(0).Item(0)
        End If




        If tons = 0 Then
            sStmt = " SELECT sum(b.units), d.eqpt_qty, d.eqpt_size_capacity  " & " FROM vinvoice a , vinvoicedet b,  service c, storeEqpt d " & " WHERE a.invoice_no = b.invoice_no " & " AND a.cust_id = b.cust_id " & " AND a.store_id = b.store_id " & " AND a.account_no = b.account_no " & " AND a.vend_seq = b.vend_seq " & " AND a.cust_id = '" & sCustId & "' " & " AND a.period_seq IN (" & params.sPeriodSeqList & ") " & " AND a.store_id = " & Str(nStoreId) & " AND b.serv_id = c.serv_id " & " AND b.eqpt_seq = d.eqpt_seq " & " AND d.cust_id = a.cust_id " & " AND d.store_id = a.store_id " & " AND b.eqpt_seq = " & Str(nEqptSeq) & " AND b.serv_id IN (SELECT serv_id FROM serviceGroup e, serviceGroupDet f " & "      WHERE e.serv_group_id = f.serv_group_id " & "      AND e.serv_group_name = 'RPTRECYCLETONGEN_PKR_PU' )" & " GROUP BY d.eqpt_qty, d.eqpt_size_capacity  "
            cmd.CommandText = sStmt

            rsPU = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)


            If rsPU.Rows.Count > 0 Then
                numPU = rsPU.Rows(0).Item(0)
                eqptQty = rsPU.Rows(0).Item(1)
                eqptSizeCapacity = rsPU.Rows(0).Item(2)
            End If


            wgt = eqptQty * eqptSizeCapacity * numPU * nPoundsPerYdInPKR / POUNDS_PER_TON
        Else

            wgt = tons
        End If




        rrtg_process_pkr = wgt

    End Function

    Public Function rrtg_process_contaminated(ByRef sCustId As String, ByRef nStoreId As Short, _
        ByRef nEqptSeq As Short, ByRef params As gRptRecycleTonGenParamUDT, _
        ByVal nPoundsPerUOMInContainer As Double, _
        ByRef sServGroupNameTon As String, ByRef sServGroupNamePu As String, _
        ByRef nMonthlyFrequency As Double) As Double

        Dim cmd As SqlCommand = cn.CreateCommand()
        Dim wgt As Double
        Dim rsPU As DataTable
        Dim numPU As Double
        Dim eqptQty As Short
        Dim eqptSizeCapacity As Double
        Dim eqptActualQty As Short
        Dim tons As Double
        Dim freqPeriod As String
        Dim servTon As String
        Dim sumPU As Double

        tons = 0
        wgt = 0


        '1. Look for "Processing Fee per Ton" tonnage,
        'if not found then look for "Service Rate per Haul"
        sStmt = " SELECT sum(b.units)  " & _
            " FROM vinvoice a , vinvoicedet b,  service c, storeEqpt d " & _
            " WHERE a.invoice_no = b.invoice_no " & _
            " AND a.cust_id = b.cust_id " & _
            " AND a.store_id = b.store_id " & _
            " AND a.account_no = b.account_no " & _
            " AND a.vend_seq = b.vend_seq " & _
            " AND a.cust_id = '" & sCustId & "' " & _
            " AND a.period_seq IN (" & params.sPeriodSeqList & ") " & _
            " AND a.store_id = " & Str(nStoreId) & _
            " AND b.serv_id = c.serv_id " & _
            " AND b.eqpt_seq = d.eqpt_seq " & _
            " AND d.cust_id = a.cust_id " & _
            " AND d.store_id = a.store_id " & _
            " AND b.eqpt_seq = " & Str(nEqptSeq) & _
            " AND b.serv_id IN (SELECT serv_id FROM serviceGroup e, serviceGroupDet f " & _
            "      WHERE e.serv_group_id = f.serv_group_id " & _
            "      AND e.serv_group_name = '" & sServGroupNameTon & "' )"

        cmd.CommandText = sStmt
        rsPU = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsPU.Rows.Count > 0 Then
            If Not IsDBNull(rsPU.Rows(0).Item(0)) Then
                tons = rsPU.Rows(0).Item(0)
            End If
        End If

        rrtg_process_contaminated = tons

    End Function


    Public Function rrtg_process(ByRef sCustId As String, ByRef nStoreId As Short, _
        ByRef nEqptSeq As Short, ByRef params As gRptRecycleTonGenParamUDT, _
        ByVal nPoundsPerUOMInContainer As Double, _
        ByVal nPoundsPerYdInContainer As Double, _
        ByRef sServGroupNameTon As String, ByRef sServGroupNamePu As String, _
        ByRef nMonthlyFrequency As Double) As Double

        'Dim cmd As SqlCommand = cn.CreateCommand()
        Dim wgt As Double
        Dim rsPU As DataTable
        Dim numPU As Double
        Dim eqptQty As Short
        Dim eqptSizeCapacity As Double
        Dim eqptActualQty As Short
        Dim tons As Double
        Dim freqPeriod As String
        Dim servTon As String
        Dim sumPU As Double
        Dim yardage As Double
        Dim overtons As Double


        tons = 0
        wgt = 0
        yardage = 0
        overtons = 0

        '1. Look for "Processing Fee per Ton" tonnage,
        'if not found then look for "Service Rate per Haul"
        'sStmt = " SELECT sum(b.units), sum(CAST(ISNULL(h.property_value, 0) AS DECIMAL ) )  " & _
        '    " FROM vinvoice a , vinvoicedet b,  service c, storeEqpt d " & " WHERE a.invoice_no = b.invoice_no " & " AND a.cust_id = b.cust_id " & " AND a.store_id = b.store_id " & " AND a.account_no = b.account_no " & " AND a.vend_seq = b.vend_seq " & " AND a.cust_id = '" & sCustId & "' " & " AND a.period_seq IN (" & params.sPeriodSeqList & ") " & " AND a.store_id = " & Str(nStoreId) & " AND b.serv_id = c.serv_id " & " AND b.eqpt_seq = d.eqpt_seq " & " AND d.cust_id = a.cust_id " & " AND d.store_id = a.store_id " & " AND b.eqpt_seq = " & Str(nEqptSeq) & " AND b.serv_id IN (SELECT serv_id FROM serviceGroup e, serviceGroupDet f " & "      WHERE e.serv_group_id = f.serv_group_id " & "      AND e.serv_group_name = '" & sServGroupNameTon & "' )"
        sStmt = " SELECT sum(b.units), sum(CAST(ISNULL(h.property_value, 0) AS DECIMAL ) )  " + _
            " FROM vinvoice a JOIN vinvoicedet b " + _
            " ON a.invoice_no = b.invoice_no " + _
            "    AND a.cust_id = b.cust_id " + _
            "    AND a.store_id = b.store_id " + _
            "    AND a.account_no = b.account_no " + _
            "    AND a.vend_seq = b.vend_seq " + _
            " JOIN service c ON b.serv_id = c.serv_id " + _
            " JOIN storeEqpt d ON d.cust_id = a.cust_id AND d.store_id = a.store_id AND b.eqpt_seq = d.eqpt_seq " + _
            " JOIN ServiceGroupDet h ON b.serv_id = h.serv_id " + _
            " JOIN ServiceGroup g ON  g.serv_group_id = h.serv_group_id " + _
            " LEFT OUTER JOIN ServiceGroupDetProperty i " + _
            "    ON h.property_seq = i.property_seq " + _
            "    AND i.property_desc ='" + SERVICE_GROUP_DET_PROPERTY_NUMTONS + "' " + _
            " WHERE a.cust_id = '" + sCustId + "' " + _
            " AND a.period_seq IN (" + params.sPeriodSeqList + ") " + _
            " AND a.store_id = " + Str(nStoreId) + _
            " AND b.eqpt_seq = " + Str(nEqptSeq) + _
            " AND g.serv_group_name='" + sServGroupNameTon + "' "


        'cmd.CommandText = sStmt
        rsPU = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsPU.Rows.Count > 0 Then
            If Not IsDBNull(rsPU.Rows(0).Item(0)) Then
                tons = rsPU.Rows(0).Item(0)
            End If
            If Not IsDBNull(rsPU.Rows(0).Item(1)) Then
                overtons = rsPU.Rows(0).Item(1)
            End If
            tons = tons + overtons
        End If




        If tons = 0 Then
            '    sStmt = " SELECT sum(b.units), d.eqpt_qty, d.eqpt_size_capacity, d.eqpt_actual_qty  "
            sStmt = " SELECT COUNT(b.units), SUM(b.units),d.eqpt_qty, d.eqpt_size_capacity, d.eqpt_actual_qty, e.freq_period,  " & _
                " c.serv_ton " & _
                " FROM vinvoice a , vinvoicedet b,  service c, storeEqpt d, vcontract e " & _
                " WHERE a.invoice_no = b.invoice_no " & _
                " AND a.cust_id = b.cust_id " & _
                " AND a.store_id = b.store_id " & _
                " AND a.account_no = b.account_no " & _
                " AND a.vend_seq = b.vend_seq " & _
                " AND a.cust_id = '" & sCustId & "' " & _
                " AND a.period_seq IN (" & params.sPeriodSeqList & ") " & _
                " AND a.store_id = " & Str(nStoreId) & _
                " AND b.serv_id = c.serv_id " & _
                " AND b.eqpt_seq = d.eqpt_seq " & _
                " AND d.cust_id = a.cust_id " & _
                " AND d.store_id = a.store_id " & _
                " AND b.eqpt_seq = " & Str(nEqptSeq) & _
                " AND b.serv_id IN (SELECT serv_id FROM serviceGroup e, serviceGroupDet f " & _
                "      WHERE e.serv_group_id = f.serv_group_id " & _
                "      AND e.serv_group_name = '" & sServGroupNamePu & "' )" & _
                " AND e.cust_id = a.cust_id " & _
                " AND e.store_id = a.store_id " & _
                " AND e.vend_seq = a.vend_seq " & _
                " AND e.serv_id = b.serv_id " & _
                " AND e.eqpt_seq = b.eqpt_seq " & _
                " GROUP BY d.eqpt_qty, d.eqpt_size_capacity, d.eqpt_actual_qty, e.freq_period, c.serv_ton  "

            'cmd.CommandText = sStmt

            rsPU = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rsPU.Rows.Count > 0 Then
                For Each row As DataRow In rsPU.Rows
                    'If rsPU.RecordCount > 0 Then

                    numPU = row.Item(0)
                    sumPU = row.Item(1)
                    eqptQty = row.Item(2)
                    eqptSizeCapacity = row.Item(3)

                    If IsDBNull(row.Item(4)) Then
                        'This only happens if ActualQty has not been updated
                        eqptActualQty = eqptQty
                    Else
                        eqptActualQty = row.Item(4)
                    End If

                    freqPeriod = Trim(row.Item(5))

                    'IF service has not set tonnage flag then default to no-tonnage
                    If IsDBNull(row.Item(6)) Then
                        servTon = "F"
                    Else
                        servTon = Trim(row.Item(6))
                    End If

                    nMonthlyFrequency = getFreqPeriodFactor(freqPeriod)

                    'When service handles tonnage use count of units otherwise sum of pick-ups
                    If servTon = "F" Then
                        wgt = wgt + eqptActualQty * eqptSizeCapacity * sumPU * nMonthlyFrequency * nPoundsPerUOMInContainer / POUNDS_PER_TON
                    Else
                        wgt = wgt + eqptActualQty * eqptSizeCapacity * numPU * nMonthlyFrequency * nPoundsPerUOMInContainer / POUNDS_PER_TON
                    End If

                    'End If

                Next row
            End If

        Else

            wgt = tons
        End If




        rrtg_process = wgt

    End Function
    Public Function rrtg_process_recycle(ByRef sCustId As String, ByRef nStoreId As Short, _
        ByRef nEqptSeq As Short, ByRef params As gRptRecycleTonGenParamUDT, _
        ByVal nPoundsPerUOMInContainer As Double, _
        ByVal nPoundsPerYdInContainer As Double, _
        ByRef sServGroupNameTon As String, ByRef sServGroupNamePu As String, _
        ByRef nMonthlyFrequency As Double) As Double

        Dim cmd As SqlCommand = cn.CreateCommand()
        Dim wgt As Double
        Dim rsPU As DataTable
        Dim numPU As Double
        Dim eqptQty As Short
        Dim eqptSizeCapacity As Double
        Dim eqptActualQty As Short
        Dim tons As Double
        Dim freqPeriod As String
        Dim servTon As String
        Dim sumPU As Double
        Dim yardage As Double
        Dim nPoundsPerUOMInContainerAndService As Double
        Dim servId As Short
        Dim eqptId As Short
        Dim freqTimes As String


        tons = 0
        wgt = 0
        yardage = 0
        nPoundsPerUOMInContainerAndService = 0

        Dim SERVICE_RATE_PER_MONTH As gDumpUDT
        SERVICE_RATE_PER_MONTH = exec_sql_single("SELECT serv_desc , STR(serv_id) FROM service WHERE serv_desc ='Service Rate per Month'")

        Dim SERVICE_RATE_PER_WEEK As gDumpUDT
        SERVICE_RATE_PER_WEEK = exec_sql_single("SELECT serv_desc , STR(serv_id) FROM service WHERE serv_desc ='Service Rate per Week'")

        '1. Look for "Processing Fee per Ton" tonnage,
        'if not found then look for "Service Rate per Haul"
        sStmt = " SELECT sum(b.units)  " & _
            " FROM vinvoice a , vinvoicedet b,  service c, storeEqpt d " & _
            " WHERE a.invoice_no = b.invoice_no " & _
            " AND a.cust_id = b.cust_id " & _
            " AND a.store_id = b.store_id " & _
            " AND a.account_no = b.account_no " & _
            " AND a.vend_seq = b.vend_seq " & _
            " AND a.cust_id = '" & sCustId & "' " & _
            " AND a.period_seq IN (" & params.sPeriodSeqList & ") " & _
            " AND a.store_id = " & Str(nStoreId) & _
            " AND b.serv_id = c.serv_id " & _
            " AND b.eqpt_seq = d.eqpt_seq " & _
            " AND d.cust_id = a.cust_id " & _
            " AND d.store_id = a.store_id " & _
            " AND b.eqpt_seq = " & Str(nEqptSeq) & _
            " AND b.serv_id IN (SELECT serv_id FROM serviceGroup e, serviceGroupDet f " & _
            "      WHERE e.serv_group_id = f.serv_group_id " & _
            "      AND e.serv_group_name = '" & sServGroupNameTon & "' )"
        
        cmd.CommandText = sStmt
        rsPU = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsPU.Rows.Count > 0 Then
            If Not IsDBNull(rsPU.Rows(0).Item(0)) Then
                tons = rsPU.Rows(0).Item(0)
            End If
        End If




        If tons = 0 Then
            sStmt = " SELECT COUNT(b.units), SUM(b.units),d.eqpt_qty, d.eqpt_size_capacity, d.eqpt_actual_qty, e.freq_period,  " & _
                " e.freq_times, c.serv_ton, b.serv_id, d.eqpt_id " & _
                " FROM vinvoice a , vinvoicedet b,  service c, storeEqpt d, vcontract e " & _
                " WHERE a.invoice_no = b.invoice_no " & _
                " AND a.cust_id = b.cust_id " & _
                " AND a.store_id = b.store_id " & _
                " AND a.account_no = b.account_no " & _
                " AND a.vend_seq = b.vend_seq " & _
                " AND a.cust_id = '" & sCustId & "' " & _
                " AND a.period_seq IN (" & params.sPeriodSeqList & ") " & _
                " AND a.store_id = " & Str(nStoreId) & _
                " AND b.serv_id = c.serv_id " & _
                " AND b.eqpt_seq = d.eqpt_seq " & _
                " AND d.cust_id = a.cust_id " & _
                " AND d.store_id = a.store_id " & _
                " AND b.eqpt_seq = " & Str(nEqptSeq) & _
                " AND b.serv_id IN (SELECT serv_id FROM serviceGroup e, serviceGroupDet f " & _
                "      WHERE e.serv_group_id = f.serv_group_id " & _
                "      AND e.serv_group_name = '" & sServGroupNamePu & "' )" & _
                " AND e.cust_id = a.cust_id " & _
                " AND e.store_id = a.store_id " & _
                " AND e.vend_seq = a.vend_seq " & _
                " AND e.serv_id = b.serv_id " & _
                " AND e.eqpt_seq = b.eqpt_seq " & _
                " GROUP BY d.eqpt_qty, d.eqpt_size_capacity, d.eqpt_actual_qty, e.freq_period, e.freq_times, c.serv_ton, b.serv_id, d.eqpt_id  "

            cmd.CommandText = sStmt

            rsPU = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rsPU.Rows.Count > 0 Then
                For Each row As DataRow In rsPU.Rows
                    'If rsPU.RecordCount > 0 Then

                    numPU = row.Item(0)
                    sumPU = row.Item(1)
                    eqptQty = row.Item(2)
                    eqptSizeCapacity = row.Item(3)
                    servId = row.Item(8)
                    eqptId = row.Item(9)


                    If IsDBNull(row.Item(4)) Then
                        'This only happens if ActualQty has not been updated
                        eqptActualQty = eqptQty
                    Else
                        eqptActualQty = row.Item(4)
                    End If

                    freqPeriod = Trim(row.Item(5))

                    freqtimes = row.Item(6)

                    'IF service has not set tonnage flag then default to no-tonnage
                    If IsDBNull(row.Item(7)) Then
                        servTon = "F"
                    Else
                        servTon = Trim(row.Item(7))
                    End If

                    nMonthlyFrequency = getFreqPeriodFactor(freqPeriod)
                    nPoundsPerUOMInContainerAndService = getPoundsPerUomInContainerAndService(nPoundsPerUOMInContainer, servId, eqptId)

                    '2015.02.20.begin
                    'Customization for NRG
                    If servId.ToString.Equals(SERVICE_RATE_PER_WEEK.str2) Then
                        nMonthlyFrequency = 1
                        freqPeriod = "O/C"
                    End If
                    '2015.02.20.end

                    If freqPeriod = "O/C" Then
                        wgt = wgt + eqptActualQty * eqptSizeCapacity * sumPU * nMonthlyFrequency * nPoundsPerUOMInContainer / POUNDS_PER_TON
                    Else
                        wgt = wgt + eqptActualQty * eqptSizeCapacity * freqTimes * nMonthlyFrequency * nPoundsPerUOMInContainer / POUNDS_PER_TON
                        'Count the number of invoices showing Service Rate per Month


                        If servId.ToString.Equals(SERVICE_RATE_PER_MONTH.str2) Then
                            wgt = wgt + numPU
                        End If
                    End If



                Next row
            End If

        Else

            wgt = tons
        End If


        'Always add extra yardage fee
        yardage = rrtg_process_yardage(sCustId, nStoreId, nEqptSeq, params, nPoundsPerYdInContainer, RPTRECYCLETONGEN_YARDAGE)

        rrtg_process_recycle = wgt + yardage

    End Function
    'AFTERMIGRATION.2014.09.13.end
    'AFTERMIGRATION.2014.09.14.begin
    'Computes extra yardage fees
    Public Function rrtg_process_yardage(ByVal sCustId As String, ByVal nStoreId As Integer, _
        ByVal nEqptSeq As Integer, ByVal params As gRptRecycleTonGenParamUDT, _
        ByVal nPoundsPerUOMInContainer As Double, _
        ByVal sServGroupNameTon As String) As Double


        Dim wgt As Double
        Dim rsPU As System.Data.DataTable
        'Dim numPU As Double
        'Dim eqptQty As Integer
        'Dim eqptSizeCapacity As Double
        'Dim eqptActualQty As Integer
        Dim yards As Double
        'Dim freqPeriod As String
        'Dim servTon As String
        'Dim sumPU As Double

        yards = 0
        wgt = 0
        'rsPU = New ADODB.Recordset

        '1. Look for "Extra Yardage Fee" tonnage

        sStmt = " SELECT sum(b.units)  " + _
            " FROM vinvoice a , vinvoicedet b,  service c, storeEqpt d " + _
            " WHERE a.invoice_no = b.invoice_no " + _
            " AND a.cust_id = b.cust_id " + _
            " AND a.store_id = b.store_id " + _
            " AND a.account_no = b.account_no " + _
            " AND a.vend_seq = b.vend_seq " + _
            " AND a.cust_id = '" + sCustId + "' " + _
            " AND a.period_seq IN (" + params.sPeriodSeqList + ") " + _
            " AND a.store_id = " + Str(nStoreId) + _
            " AND b.serv_id = c.serv_id " + _
            " AND b.eqpt_seq = d.eqpt_seq " + _
            " AND d.cust_id = a.cust_id " + _
            " AND d.store_id = a.store_id " + _
            " AND b.eqpt_seq = " + Str(nEqptSeq) + _
            " AND b.serv_id IN (SELECT serv_id FROM serviceGroup e, serviceGroupDet f " + _
            "      WHERE e.serv_group_id = f.serv_group_id " + _
            "      AND e.serv_group_name = '" + sServGroupNameTon + "' )"

        rsPU = getDataTable(sStmt)

        If Not IsDBNull(rsPU.Rows(0).Item(0)) Then
            yards = rsPU.Rows(0).Item(0)
            wgt = yards * nPoundsPerUOMInContainer / 2000
        End If

      

        rrtg_process_yardage = wgt

    End Function


    '--

    'Looks for monthly service in list of invoices for the given period, if not found
    'sums the number of p/u for this equipment in the period to compute weight
    Public Function rrtg_process_trash(ByRef sCustId As String, ByRef nStoreId As Short, ByRef nEqptSeq As Short, ByRef params As gRptRecycleTonGenParamUDT, ByVal nPoundsPerUOMInContainer As Double, ByRef sServGroupNameTon As String, ByRef sServGroupNamePu As String, ByRef nMonthlyFrequency As Double) As Double

        Dim cmd As SqlCommand = cn.CreateCommand()
        Dim wgt As Double
        Dim rsPU As DataTable
        Dim numPU As Double
        Dim eqptQty As Short
        Dim eqptSizeCapacity As Double
        Dim eqptActualQty As Short
        Dim tons As Double
        Dim nServiceCount As Short
        Dim freqPeriod As String
        Dim freqTimes As Short

        tons = 0
        wgt = 0
        nServiceCount = 0

        '1. Look for "Service Rate per Month" service in period
        'Test Case 8D.begin
        'sStmt = " SELECT count(b.units), d.eqpt_qty, d.eqpt_size_capacity, d.eqpt_actual_qty, "
        'Test Case 8D.end
        sStmt = " SELECT sum(b.units), d.eqpt_qty, d.eqpt_size_capacity, d.eqpt_actual_qty, " & " e.freq_times, e.freq_period " & " FROM vinvoice a , vinvoicedet b,  service c, storeEqpt d , vcontract e " & " WHERE a.invoice_no = b.invoice_no " & " AND a.cust_id = b.cust_id " & " AND a.store_id = b.store_id " & " AND a.account_no = b.account_no " & " AND a.vend_seq = b.vend_seq " & " AND a.cust_id = '" & sCustId & "' " & " AND a.period_seq IN (" & params.sPeriodSeqList & ") " & " AND a.store_id = " & Str(nStoreId) & " AND b.serv_id = c.serv_id " & " AND b.eqpt_seq = d.eqpt_seq " & " AND d.cust_id = a.cust_id " & " AND d.store_id = a.store_id " & " AND b.eqpt_seq = " & Str(nEqptSeq) & " AND b.serv_id IN (SELECT serv_id FROM serviceGroup e, serviceGroupDet f " & "      WHERE e.serv_group_id = f.serv_group_id " & "      AND e.serv_group_name = '" & sServGroupNameTon & "' )" & " AND e.cust_id = a.cust_id " & " AND e.store_id = a.store_id " & " AND e.vend_seq = a.vend_seq " & " AND e.serv_id = b.serv_id " & " AND e.eqpt_seq = b.eqpt_seq " & " GROUP BY  d.eqpt_qty, d.eqpt_size_capacity, d.eqpt_actual_qty, e.freq_times, e.freq_period"
        cmd.CommandText = sStmt
        rsPU = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsPU.Rows.Count > 0 Then
            numPU = rsPU.Rows(0).Item(0)
            eqptQty = rsPU.Rows(0).Item(1)
            eqptSizeCapacity = rsPU.Rows(0).Item(2)
            'eqptActualQty = rsPU.item(3)
            If IsDBNull(rsPU.Rows(0).Item(3)) Then
                'This only happens if ActualQty has not been updated
                eqptActualQty = eqptQty
            Else
                eqptActualQty = rsPU.Rows(0).Item(3)
            End If


            freqTimes = rsPU.Rows(0).Item(4)
            freqPeriod = rsPU.Rows(0).Item(5)

            nMonthlyFrequency = getFreqPeriodFactor(freqPeriod)
            'When service is O/C , freq_times is zero thus change it to 1
            If freqPeriod = "O/C" Then
                freqTimes = 1
            End If

            wgt = eqptActualQty * eqptSizeCapacity * numPU * nMonthlyFrequency * nPoundsPerUOMInContainer * freqTimes / POUNDS_PER_TON
            'wgt = eqptQty * eqptSizeCapacity * numPU * nMonthlyFrequency * nPoundsPerUOMInContainer * freqTimes / POUNDS_PER_TON
            'wgt = wgt + eqptActualQty * eqptSizeCapacity * numPU * nMonthlyFrequency * nPoundsPerUOMInContainer / POUNDS_PER_TON

        End If




        If wgt = 0 Then
            sStmt = " SELECT sum(b.units), d.eqpt_qty, d.eqpt_size_capacity, d.eqpt_actual_qty, e.freq_period,  " & " e.freq_times " & " FROM vinvoice a , vinvoicedet b,  service c, storeEqpt d, vcontract e " & " WHERE a.invoice_no = b.invoice_no " & " AND a.cust_id = b.cust_id " & " AND a.store_id = b.store_id " & " AND a.account_no = b.account_no " & " AND a.vend_seq = b.vend_seq " & " AND a.cust_id = '" & sCustId & "' " & " AND a.period_seq IN (" & params.sPeriodSeqList & ") " & " AND a.store_id = " & Str(nStoreId) & " AND b.serv_id = c.serv_id " & " AND b.eqpt_seq = d.eqpt_seq " & " AND d.cust_id = a.cust_id " & " AND d.store_id = a.store_id " & " AND b.eqpt_seq = " & Str(nEqptSeq) & " AND b.serv_id IN (SELECT serv_id FROM serviceGroup e, serviceGroupDet f " & "      WHERE e.serv_group_id = f.serv_group_id " & "      AND e.serv_group_name = '" & sServGroupNamePu & "' )" & " AND e.cust_id = a.cust_id " & " AND e.store_id = a.store_id " & " AND e.vend_seq = a.vend_seq " & " AND e.serv_id = b.serv_id " & " AND e.eqpt_seq = b.eqpt_seq " & " GROUP BY d.eqpt_qty, d.eqpt_size_capacity, d.eqpt_actual_qty, e.freq_period, e.freq_times  "
            cmd.CommandText = sStmt

            rsPU = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rsPU.Rows.Count > 0 Then
                For Each row As DataRow In rsPU.Rows


                    numPU = row.Item(0)
                    eqptQty = row.Item(1)
                    eqptSizeCapacity = row.Item(2)
                    If IsDBNull(row.Item(3)) Then
                        'This only happens if ActualQty has not been updated
                        eqptActualQty = eqptQty
                    Else
                        eqptActualQty = row.Item(3)
                    End If

                    'eqptActualQty = rsPU.item(3)
                    freqPeriod = row.Item(4)
                    freqTimes = row.Item(5)

                    nMonthlyFrequency = getFreqPeriodFactor(freqPeriod)
                    If freqPeriod = "O/C" Then
                        freqTimes = 1
                    End If



                    'wgt = wgt + eqptActualQty * eqptSizeCapacity * numPU * nMonthlyFrequency * nPoundsPerUOMInContainer / POUNDS_PER_TON
                    wgt = wgt + eqptActualQty * eqptSizeCapacity * numPU * nMonthlyFrequency * nPoundsPerUOMInContainer * freqTimes / POUNDS_PER_TON

                    'End If
                Next row
            End If

        End If




        rrtg_process_trash = wgt

    End Function

    'Totes use "Service Rate per Month"
    Public Function rrtg_process_tote(ByRef sCustId As String, ByRef nStoreId As Short, ByRef nEqptSeq As Short, ByRef params As gRptRecycleTonGenParamUDT, ByRef nPoundsPerTote As Double, ByRef sServGroupName As String, ByRef nMonthlyFrequency As Double) As Double

        'Dim cmd As SqlCommand = cn.CreateCommand
        Dim wgt As Double
        Dim rsTote As DataTable
        Dim numTotes As Double
        Dim eqptQty As Short
        Dim eqptSizeCapacity As Double
        Dim freqPeriod As String

        sStmt = " SELECT SUM(b.units), d.eqpt_qty, d.eqpt_size_capacity, e.freq_period  " & " FROM vinvoice a , vinvoicedet b,  service c, storeEqpt d, vcontract e " & " WHERE a.invoice_no = b.invoice_no " & " AND a.cust_id = b.cust_id " & " AND a.store_id = b.store_id " & " AND a.account_no = b.account_no " & " AND a.vend_seq = b.vend_seq " & " AND a.cust_id = '" & sCustId & "' " & " AND a.period_seq IN (" & params.sPeriodSeqList & ") " & " AND a.store_id = " & Str(nStoreId) & " AND b.serv_id = c.serv_id " & " AND b.eqpt_seq = d.eqpt_seq " & " AND d.cust_id = a.cust_id " & " AND d.store_id = a.store_id " & " AND b.eqpt_seq = " & Str(nEqptSeq) & " AND b.serv_id IN (SELECT serv_id FROM serviceGroup e, serviceGroupDet f " & "      WHERE e.serv_group_id = f.serv_group_id " & "      AND e.serv_group_name = '" & sServGroupName & "' )" & " AND e.cust_id = a.cust_id " & " AND e.store_id = a.store_id " & " AND e.vend_seq = a.vend_seq " & " AND e.serv_id = b.serv_id " & " AND e.eqpt_seq = b.eqpt_seq " & " GROUP BY d.eqpt_qty, d.eqpt_size_capacity, e.freq_period  "
        'cmd.CommandText = sStmt

        rsTote = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsTote.Rows.Count > 0 Then
            numTotes = rsTote.Rows(0).Item(0)
            eqptQty = rsTote.Rows(0).Item(1)
            eqptSizeCapacity = rsTote.Rows(0).Item(2)
            freqPeriod = rsTote.Rows(0).Item(3)

            nMonthlyFrequency = getFreqPeriodFactor(freqPeriod)

        End If


        wgt = eqptQty * eqptSizeCapacity * numTotes * nMonthlyFrequency * nPoundsPerTote / POUNDS_PER_TON


        rrtg_process_tote = wgt
    End Function


    Public Function getPoundsPerBaler() As Double
        getPoundsPerBaler = 0
        'Dim cmd As SqlCommand = cn.CreateCommand()
        sStmt = "SELECT pounds_per_ton FROM EqptContentConversionFactor " & " WHERE eqpt_type = '" & RPTRECYCLETONGEN_EQPT_BALER & "' " & " AND content_id = 0 "
        'cmd.CommandText = sStmt
        
        rs = getDataTable(sStmt) 'cmd.ExecuteReader()
        If rs.Rows.Count > 0 Then
            getPoundsPerBaler = rs.Rows(0).Item(0)
        End If


    End Function

    Public Function getPoundsPerYdInPKR() As Double
        getPoundsPerYdInPKR = 0
        Dim cmd As SqlCommand = cn.CreateCommand()
        sStmt = "SELECT pounds_per_ton FROM EqptContentConversionFactor " & " WHERE eqpt_type = '" & RPTRECYCLETONGEN_EQPT_PKR & "' " & " AND content_id = (SELECT content_id " & "                   FROM content WHERE content_desc ='" & RPTRECYCLETONGEN_RECYCLE & "') " & " AND uom = '" & RPTRECYCLETONGEN_UOM_YARDS & "' "
        cmd.CommandText = sStmt
        
        rs = getDataTable(sStmt) 'cmd.ExecuteReader()
        If rs.Rows.Count > 0 Then
            getPoundsPerYdInPKR = rs.Rows(0).Item(0)
        End If


    End Function

    Public Function getPoundsPer(ByRef sEqptType As String, ByRef sContentDesc As String, ByRef sFromUom As String) As Double
        getPoundsPer = 0
        Dim cmd As SqlCommand = cn.CreateCommand()
        sStmt = "SELECT pounds_per_ton FROM EqptContentConversionFactor " & " WHERE eqpt_type = '" & sEqptType & "' " & " AND content_id = (SELECT content_id " & "                   FROM content WHERE content_desc ='" & sContentDesc & "') " & " AND uom = '" & sFromUom & "' "
        cmd.CommandText = sStmt
        
        rs = getDataTable(sStmt) 'cmd.ExecuteReader()
        If rs.Rows.Count > 0 Then
            getPoundsPer = rs.Rows(0).Item(0)
        End If


    End Function


    Public Function getPeriodDates(ByRef sPeriodSeq As Short) As gDumpUDT
        Dim startDate As Date
        Dim endDate As Date
        'Dim cmd As SqlCommand = cn.CreateCommand()
        sStmt = "SELECT period_start_date, period_end_date FROM period WHERE period_seq = " & Str(sPeriodSeq)
        'cmd.CommandText = sStmt

        rs = getDataTable(sStmt) ' cmd.ExecuteReader()
        If rs.Rows.Count > 0 Then
            startDate = rs.Rows(0).Item(0)
            endDate = rs.Rows(0).Item(1)
        End If

        getPeriodDates.str1 = VB6.Format(startDate, "mm/dd/yyyy")
        getPeriodDates.str2 = VB6.Format(endDate, "mm/dd/yyyy")
    End Function

    Public Function getFreqPeriodFactor(ByRef freqPeriod As String) As Double
        Dim nMonthlyFrequency As Double

        freqPeriod = Trim(freqPeriod)

        If freqPeriod = "O/C" Then
            nMonthlyFrequency = 1
        ElseIf freqPeriod = "Wk" Then
            nMonthlyFrequency = 4.33
        ElseIf freqPeriod = "Mo" Then
            nMonthlyFrequency = 1
        ElseIf freqPeriod = "EOW" Then
            nMonthlyFrequency = System.Math.Round(4.33 / 2, 2)
        Else
            nMonthlyFrequency = 1
        End If

        getFreqPeriodFactor = nMonthlyFrequency

    End Function



    Public Function getPoundsPerUomInContainerAndService(ByVal nPoundsPerUOMInContainer As Double, _
        ByVal servId As Integer, ByVal eqptId As Integer) As Double

        Dim pounds As Double

        pounds = nPoundsPerUOMInContainer

        sStmt = "SELECT b.pounds_per_ton FROM  EqptContentConversionFactor a " + _
            " JOIN Equipment e " + _
            " ON a.eqpt_type = e.eqpt_type LEFT OUTER JOIN EqptContentConversionFactorService b " + _
            " ON a.eccf_seq = b.eccf_seq AND b.serv_id=" + Str(servId) + _
            " WHERE e.eqpt_id = " + Str(eqptId)

        rs = getDataTable(sStmt) ' cmd.ExecuteReader()
        If rs.Rows.Count > 0 Then
            If Not IsDBNull(rs.Rows(0).Item(0)) Then
                pounds = rs.Rows(0).Item(0)
            End If

        End If

        getPoundsPerUomInContainerAndService = pounds


    End Function
    'Calculates Over Tons
    Public Function rrtg_process_overtons(ByVal sCustId As String, ByVal nStoreId As Integer, _
    ByVal nEqptSeq As Integer, ByVal params As gRptRecycleTonGenParamUDT, _
    ByVal sServGroupNameTon As String, ByVal sPropertyName As String) As Double


        Dim wgt As Double
        Dim rsPU As DataTable
        Dim servTon As String


        wgt = 0
        'rsPU = New ADODB.Recordset

        '1. Look for "Extra Yardage Fee" tonnage

        sStmt = " SELECT sum(b.units), sum(cast(h.property_value as decimal) )  " + _
            " FROM vinvoice a , vinvoicedet b,  service c, storeEqpt d, ServiceGroup g, ServiceGroupDet h, ServiceGroupDetProperty i " + _
            " WHERE a.invoice_no = b.invoice_no " + _
            " AND a.cust_id = b.cust_id " + _
            " AND a.store_id = b.store_id " + _
            " AND a.account_no = b.account_no " + _
            " AND a.vend_seq = b.vend_seq " + _
            " AND a.cust_id = '" + sCustId + "' " + _
            " AND a.period_seq IN (" + params.sPeriodSeqList + ") " + _
            " AND a.store_id = " + Str(nStoreId) + _
            " AND b.serv_id = c.serv_id " + _
            " AND b.eqpt_seq = d.eqpt_seq " + _
            " AND d.cust_id = a.cust_id " + _
            " AND d.store_id = a.store_id " + _
            " AND b.eqpt_seq = " + Str(nEqptSeq) + _
            " AND g.serv_group_id = h.serv_group_id " + _
            " AND h.property_seq = i.property_seq " + _
            " AND g.serv_group_name='" + sServGroupNameTon + "' " + _
            " AND i.property_desc='" + sPropertyName + "' " + _
            " AND b.serv_id = h.serv_id "


        rsPU = getDataTable(sStmt)

        If rsPU.Rows.Count > 0 AndAlso Not IsDBNull(rsPU.Rows(0).Item(0)) Then
            wgt = rsPU.Rows(0).Item(0)
            servTon = rsPU.Rows(0).Item(1)
            'getServiceGroupDetProperty("FEE_PER_TON_OVER", "Number of Tons", servId)
            wgt = wgt + servTon
        End If



        rrtg_process_overtons = wgt

    End Function


    Public Function getServiceGroupDetProperty(ByVal sGroupName As String, ByVal sPropertyName As String, ByVal nServId As Integer) As Double
        Dim numTons As Double
        Dim rsSGDP As DataTable


        numTons = 0
        sStmt = "SELECT property_value FROM ServiceGroup a, ServiceGroupDet b, ServiceGroupDetProperty c" + _
                " WHERE a.serv_group_id = b.serv_group_id " + _
                " AND b.property_seq = c.property_seq " + _
                " AND a.serv_group_name='" + sGroupName + "' " + _
                " AND c.property_desc='" + sPropertyName + "' " + _
                " AND b.serv_id= " + Str(nServId)

        rsSGDP = getDataTable(sStmt)

        If (rsSGDP.Rows.Count > 0) Then
            numTons = rsSGDP.Rows(0).Item(0)
        End If


        getServiceGroupDetProperty = numTons


    End Function


End Module