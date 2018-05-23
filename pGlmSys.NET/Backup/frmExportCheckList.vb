Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmExportCheckList
	Inherits System.Windows.Forms.Form
    Private rsDetail As DataTable
    Private rsLocal As DataTable
    Private cmLocal As SqlCommand
	
	Private Sub init_vars()
        rsDetail = Nothing
		
	End Sub
	'Funcion que genera informacion para los controles de la forma
	Private Sub load_controls()
        txtNumChecks.Text = CStr(frmExportCheck.rsCheckList.Rows.Count)
        Dim theAmount As Double = 0
        theAmount = total_amount()
		txtTotalAmount.Text = VB6.Format(total_amount, "###,###,##0.00")
		
        If frmExportCheck.rsCustCheck.Rows.Count > 1 Then
            cbCustName.Items.Insert(0, "<All>")
            cbCustId.Items.Insert(0, "<All>")

            load_cb3(cbCustName, (frmExportCheck.rsCustCheck), 0, False)
            load_cb3(cbCustId, (frmExportCheck.rsCustCheck), 1, False)

            If cbCustName.Items.Count > 0 Then
                cbCustName.SelectedIndex = 0
            End If

            dgCustCheck.DataSource = frmExportCheck.rsCustCheck
            dgCustCheck.Columns("cust_id").Visible = False

            cbCustName.Visible = True
            dgCustCheck.Visible = True
            lblCustomer.Visible = True
        Else
            'One customer, then move datagrid a little bit up
            Frame1.Top = VB6.TwipsToPixelsY(1920)
            dgCustCheck.Visible = False

        End If
		
		dgCheckList.DataSource = frmExportCheck.rsCheckList
		dgCheckList.Columns("qb_bank_name").Visible = False
		dgCheckList.Columns("qb_check_date").Width = VB6.TwipsToPixelsX(1000)
        dgCheckList.Columns("qb_check_date").HeaderText = "Date"
		'dgCheckList.Columns("qb_vendor_name").Caption = "Vendor"
        dgCheckList.Columns("qb_vendor_name").HeaderText = "QB Vendor"
		dgCheckList.Columns("vend_name").Width = VB6.TwipsToPixelsX(1800)
        dgCheckList.Columns("vend_name").HeaderText = "Vendor"
        dgCheckList.Columns("qb_check_amount").HeaderText = "Amount"
        dgCheckList.Columns("qb_doc_num").HeaderText = "Check No"
		dgCheckList.Columns("Void").Width = VB6.TwipsToPixelsX(500)
		
		dgCheckList.Columns("qb_clear").Visible = False
		dgCheckList.Columns("qb_to_print").Visible = False
		dgCheckList.Columns("qb_addr1").Visible = False
		dgCheckList.Columns("qb_addr2").Visible = False
		dgCheckList.Columns("qb_addr3_1").Visible = False
		dgCheckList.Columns("qb_addr3_2").Visible = False
		dgCheckList.Columns("qb_addr4").Visible = False
		dgCheckList.Columns("qb_check_memo").Visible = False
		dgCheckList.Columns("bank_cust_seq").Visible = False
		'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        dgCheckList.Refresh()
		
		
	End Sub
	Private Function total_amount() As Double
		Dim vbOKony As Object
		Dim dTotal As Double
		
		On Error GoTo ErrorHandler
		
		dTotal = 0
		

        If frmExportCheck.rsCheckList.Rows.Count > 0 Then
            For row As Integer = 0 To frmExportCheck.rsCheckList.Rows.Count - 1
                If Not IsDBNull(frmExportCheck.rsCheckList.Rows(row).Item("qb_check_amount")) Then
                    dTotal = dTotal + frmExportCheck.rsCheckList.Rows(row).Item("qb_check_amount")
                End If
            Next
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'


        End If

        total_amount = dTotal
        Exit Function

ErrorHandler:
        total_amount = 0
        save_error(Me.Name, "total_amount")
        'UPGRADE_WARNING: Couldn't resolve default property of object vbOKony. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        MsgBox("Internal error occurred while accesing Check info." & "Review log file for details.", MsgBoxStyle.Exclamation + vbOKony, "GLM Warning")
	End Function
	'Genera el archivo IIF de Cheques para QuickBooks
	Private Function write_iif(ByRef sFilename As Object) As Boolean
		Dim sTranAmount As Object
		Dim nTmp As Double
		Dim sBuffer As String
		'Cabecera
		Dim sDate As String
		Dim sTranAccount As String
		Dim sDocNum As String
		Dim sTranName As String
		Dim sClear As String
		Dim sTranToPrint As String
		Dim sTranMemo As String
		Dim sAddr1 As String
		Dim sAddr2 As String
		Dim sAddr3 As String
		Dim sAddr4 As String
		Dim sAddr5 As String
		Dim sBankCustSeq As String
		Dim sDetailReimbexp As String
		'Detalle
		Dim sDetailAccount As String
		Dim sDetailAmount As String
		Dim sDetailMemo As String
		Dim sDetailCustName As String
		Dim sCheckDetailNo As String
		Dim sCustId As String
		Dim e As ADODB.Error
		
		Dim sGroupId As String
		
		
		On Error GoTo ErrorHandler
		
		
		sDetailReimbexp = "NOTHING"
		'Abro el nuevo archivo
		'UPGRADE_WARNING: Couldn't resolve default property of object sFilename. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		FileOpen(1, sFilename, OpenMode.Output)
		'HEADERS: Esto es constante, CAMBIAR CON CUIDADO
		sBuffer = "!TRNS" & vbTab & "TRNSID" & vbTab & "TRNSTYPE" & vbTab & "DATE" & vbTab & "ACCNT" & vbTab & "NAME" & vbTab & "CLASS" & vbTab & "AMOUNT" & vbTab & "DOCNUM" & vbTab & "CLEAR" & vbTab & "TOPRINT" & vbTab & "MEMO" & vbTab & "ADDR1" & vbTab & "ADDR2" & vbTab & "ADDR3" & vbTab & "ADDR4" & vbTab & "ADDR5"
		PrintLine(1, sBuffer)
		
		sBuffer = "!SPL" & vbTab & "SPLID" & vbTab & "TRNSTYPE" & vbTab & "DATE" & vbTab & "ACCNT" & vbTab & "NAME" & vbTab & "CLASS" & vbTab & "AMOUNT" & vbTab & "DOCNUM" & vbTab & "CLEAR" & vbTab & "QNTY" & vbTab & "REIMBEXP" & vbTab & "MEMO"
		PrintLine(1, sBuffer)
		
		sBuffer = "!ENDTRNS"
		PrintLine(1, sBuffer)
		

        For chkLstRow As Integer = 0 To frmExportCheck.rsCheckList.Rows.Count - 1
            'DATOS PARA LA CABECERA
            Dim dt As DateTime
            sDate = frmExportCheck.rsCheckList.Rows(chkLstRow).Item("qb_check_date").ToString()
            dt = DateTime.Parse(sDate)
            sDate = dt.Month.ToString + "/" + dt.Day.ToString + "/" + dt.Year.ToString()
            sTranAccount = frmExportCheck.rsCheckList.Rows(chkLstRow).Item("qb_bank_name")
            sTranName = frmExportCheck.rsCheckList.Rows(chkLstRow).Item("qb_vendor_name")
            'UPGRADE_WARNING: Couldn't resolve default property of object sTranAmount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            sTranAmount = Str(frmExportCheck.rsCheckList.Rows(chkLstRow).Item("qb_check_amount") * -1) 'Hago negativa la cantidad
            sDocNum = Str(frmExportCheck.rsCheckList.Rows(chkLstRow).Item("qb_doc_num"))


            sTranToPrint = "N"

            If Trim(frmExportCheck.rsCheckList.Rows(chkLstRow).Item("void")) = "Y" Then
                sClear = "Y"
                sTranMemo = "VOID: " & Trim(frmExportCheck.rsCheckList.Rows(chkLstRow).Item("qb_check_memo"))
            Else
                sClear = "N"
                sTranMemo = frmExportCheck.rsCheckList.Rows(chkLstRow).Item("qb_check_memo")
            End If

            sAddr1 = frmExportCheck.rsCheckList.Rows(chkLstRow).Item("qb_addr1")
            sAddr2 = frmExportCheck.rsCheckList.Rows(chkLstRow).Item("qb_addr2")
            sAddr3 = Trim(frmExportCheck.rsCheckList.Rows(chkLstRow).Item("qb_addr3_1")) & " " & Trim(frmExportCheck.rsCheckList.Rows(chkLstRow).Item("qb_addr3_2"))
            sAddr4 = frmExportCheck.rsCheckList.Rows(chkLstRow).Item("qb_addr4")
            sAddr5 = ""
            sBankCustSeq = Str(frmExportCheck.rsCheckList.Rows(chkLstRow).Item("bank_cust_seq"))

            'Titulo de la transaccion:EJEMPLO
            'sBuffer = "TRNS" + vbTab + "" + vbTab + "CHECK" + vbTab + _
            '"02/28/2002" + vbTab + "First Union Bank" + vbTab + "Juan Puente" + vbTab + _
            '"" + vbTab + "-500" + vbTab + "2910" + vbTab + _
            '"N" + vbTab + "N" + "Stores:#100,#102"

            'UPGRADE_WARNING: Couldn't resolve default property of object sTranAmount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            sBuffer = "TRNS" & vbTab & "" & vbTab & "CHECK" & vbTab & sDate & vbTab & sTranAccount & vbTab & sTranName & vbTab & "" & vbTab + sTranAmount + vbTab + sDocNum + vbTab + sClear + vbTab + sTranToPrint + vbTab + Trim(sTranMemo) + vbTab + Trim(sAddr1) + vbTab + Trim(sAddr2) + vbTab + Trim(sAddr3) + vbTab + Trim(sAddr4) + vbTab + Trim(sAddr5) + vbTab
            PrintLine(1, sBuffer)

            '----------------- DETALLE DE CHEQUE -------------------------
            'SPL
            '"ACCNT" = customer.qb_account_name
            '"NAME" = customer.qb_cust_name

            'sStmt = "SELECT qb_account.name AS detail_account, " + _
            '" bcheck.invoice_total AS detail_amount, " + _
            '" bcheck.detail_memo AS detail_memo, " + _
            '" bcheck.check_detail_no, " + _
            '" customer.qb_cust_name, " + _
            '" bcheck.cust_id " + _
            '" FROM bcheck, qb_account, customer " + _
            '" WHERE qb_account.name = " + _
            '" bcheck.qb_detail_name_" + Trim(LCase(gsGroupId)) + _
            '" AND qb_account.qb_group_id ='" + Trim(UCase(gsGroupId)) + "' " + _
            '" AND bcheck.check_no = " + sDocNum + _
            '" AND bcheck.bank_cust_seq = " + sBankCustSeq + _
            '" AND qb_account.accnttype = 'OCLIAB' " + _
            '" AND customer.cust_id =bcheck.cust_id " + _
            '" ORDER BY bcheck.check_detail_no "


            sGroupId = frmExportCheck.rsCheckList.Rows(chkLstRow).Item("qb_group_id")


            'Es lo mismo : qb_account.name = customer.qb_account_name
            sStmt = "SELECT qb_account.name AS detail_account, " & " bcheck.invoice_total AS detail_amount, " & " bcheck.detail_memo AS detail_memo, " & " bcheck.check_detail_no, " & " customer.qb_cust_name AS qb_cust_name, " & " bcheck.cust_id " & _
                " FROM bcheck, qb_account, customer " & " WHERE qb_account.name = " & " bcheck.qb_detail_name " & " AND qb_account.qb_group_id ='" & Trim(UCase(sGroupId)) & "' " & " AND bcheck.check_no = " & sDocNum & " AND bcheck.bank_cust_seq = " & sBankCustSeq & " AND qb_account.accnttype = 'OCLIAB' " & " AND customer.cust_id =bcheck.cust_id " & " ORDER BY bcheck.check_detail_no "

            rsDetail = getDataTable(sStmt) ' .Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            'Verifico que haya detalles en el cheque.

            If rsDetail.Rows.Count = 0 Then
                MsgBox("Unable to generate info for Check No:" & sDocNum & "." & vbCrLf & "Aborting export.", MsgBoxStyle.OkOnly, "GLM Error")
                FileClose(1)
                save_error(Me.Name, "write_iif: rsDetail recordCount=0")
                Exit Function
            End If



            For rsDtlRow As Integer = 0 To rsDetail.Rows.Count - 1
                sDetailAccount = rsDetail.Rows(rsDtlRow).Item("detail_account")

                'detail_amount
                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                If IsDBNull(rsDetail.Rows(rsDtlRow).Item("detail_amount")) Then
                    sDetailAmount = CStr(0)
                Else
                    sDetailAmount = Str(rsDetail.Rows(rsDtlRow).Item("detail_amount"))
                End If

                'detail_memo
                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                If IsDBNull(rsDetail.Rows(rsDtlRow).Item("detail_memo")) Then
                    sDetailMemo = ""
                Else
                    sDetailMemo = rsDetail.Rows(rsDtlRow).Item("detail_memo")
                End If

                sCheckDetailNo = Str(rsDetail.Rows(rsDtlRow).Item("check_detail_no"))
                sCustId = rsDetail.Rows(rsDtlRow).Item("cust_id")

                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                If IsDBNull(rsDetail.Rows(rsDtlRow).Item("qb_cust_name")) Then
                    MsgBox("There is not QuickBooks customer name set up " & vbCrLf & "in Customer table for " & sCustId & ". Please review. Aborting export.", MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Function
                Else
                    sDetailCustName = rsDetail.Rows(rsDtlRow).Item("qb_cust_name")
                End If



                'EJEMPLO
                'sBuffer = "SPL" + vbTab + "" + vbTab + "CHECK" + vbTab + _
                '"02/28/2002" + vbTab + "Consulting:Computer" + vbTab + "" + vbTab + _
                '"" + vbTab + "500" + vbTab + "2910" + vbTab + _
                '"N" + vbTab + "" + vbTab + "NOTHING" + vbTab + "Instalacion de Servidor NT"

                sBuffer = "SPL" & vbTab & "" & vbTab & "CHECK" & vbTab & sDate & vbTab & sDetailAccount & vbTab & sDetailCustName & vbTab & "" & vbTab & sDetailAmount & vbTab & sDocNum & vbTab & sClear & vbTab & "" & vbTab & sDetailReimbexp & vbTab & sDetailMemo

                PrintLine(1, sBuffer)
            Next rsDtlRow

            sBuffer = "ENDTRNS"
            PrintLine(1, sBuffer)

            'Get Next Check

        Next chkLstRow


        'Cierro archivo
        'sFilename.close()
        FileClose(1)
        write_iif = True
        Exit Function


ErrorHandler:
        write_iif = False
        save_error("frmExportCheckList", "write_iif")
        MsgBox("Failed to generate Quick Books data. " & vbCrLf & "You must review log file for details.")
	End Function
	
	'UPGRADE_WARNING: Event cbCustId.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustId_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustId.SelectedIndexChanged
		
		If cbCustId.SelectedIndex > 0 Then
            frmExportCheck.rsCheckList.Select("cust_id = '" & cbCustId.Text & "'")
		Else
            frmExportCheck.rsCheckList.Select()
			
		End If
		
		dgCheckList.DataSource = frmExportCheck.rsCheckList
		'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        dgCheckList.Refresh()
		
	End Sub
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		
		If cbCustName.SelectedIndex >= 0 Then
			cbCustId.SelectedIndex = cbCustName.SelectedIndex
		End If
		
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		Dim sDir As String
		Dim fs As Scripting.FileSystemObject
		
		On Error GoTo ErrorHandler
		
		fs = New Scripting.FileSystemObject
		sDir = "c:\glm"
		If Not fs.FolderExists(sDir) Then
			sDir = "c:\"
		End If
		
		
		cdCheckSave.InitialDirectory = sDir 'Directorio para guardar archivo IIF
		cdCheckSave.DefaultExt = "iif"
		'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        cdCheckSave.Filter = "QuickBooks Files (*.iif)|*.iif"
		cdCheckSave.FileName = "Checks" 'Nombre por defecto de archivo
		'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'

        'cdCheck.CancelError = True 'Genera un error 32755 si el usuario escoge Cancel al guardar Save
        If Not cdCheckSave.ShowDialog() = Windows.Forms.DialogResult.Cancel Then



            If Trim(cdCheckSave.FileName) = "" Then
                MsgBox("Unable to Export Check Info, Please provide a file to save data.", MsgBoxStyle.OkOnly, "GLM Warning")
            Else
                'Creamos el archivo IIF para QuickBooksPro
                If write_iif((cdCheckSave.FileName)) = False Then
                    MsgBox("An error has ocurred. Unable to export data", MsgBoxStyle.OkOnly, "GLM Error")
                Else
                    If update_check_status() Then
                        MsgBox("Data exported successfully", MsgBoxStyle.OkOnly, "GLM Message")
                    Else
                        MsgBox("Unable to update Check Info. Please try again.", MsgBoxStyle.OkOnly, "GLM Error")
                    End If
                End If
                Me.Close()
            End If
            Exit Sub
        Else
            Exit Sub
        End If
ErrorHandler:

        'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
        If Err.Number = DialogResult.Cancel Then
            'Usuario selecciono cancel en SaveDialog
            MsgBox("Operation was cancelled by user.", MsgBoxStyle.OkOnly, "GLM Warning")
            Exit Sub
        Else
            save_error("frmExportCheckList", "cmdok")
            MsgBox("An error occurred when saving check. Try again.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")

        End If
    End Sub
	
    Private Sub dgCustCheck_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'Dim v As Variant
        'Dim sFilter As String
        'Dim nCount As Integer


        'If dgCustCheck.SelBookmarks.Count > 0 Then
        '    sFilter = ""
        '    nCount = 1
        '    For Each v In dgCustCheck.SelBookmarks
        '        frmExportCheck.rsCustCheck.Bookmark = v
        '        sFilter = sFilter + "cust_id = '" + frmExportCheck.rsCustCheck.item("cust_id") + "'"

        '        If dgCustCheck.SelBookmarks.Count > nCount Then
        '            sFilter = sFilter + " OR "
        '        End If

        '        nCount = nCount + 1
        '    Next v
        '    frmExportCheck.rsCheckList.Filter = sFilter
        'Else
        '    frmExportCheck.rsCheckList.Filter = adFilterNone
        'End If



    End Sub
	
	Private Sub frmExportCheckList_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		load_controls()
		'Set dgCheckList.DataSource = rs
		'dgCheckList.Refresh
	End Sub
	'Actualiza bandera de exportacion en BCheck
	Private Function update_check_status() As Boolean
		
		On Error GoTo ErrorHandler
		
		
		'RecordSet no esta disponible, cerrado o no tiene datos
        'If frmExportCheck.rsCheckList.State <> ADODB.ObjectStateEnum.adStateOpen Then
        '	update_check_status = False
        '	Exit Function
        'End If
		
        If frmExportCheck.rsCheckList.Rows.Count = 0 Then
            update_check_status = False
            Exit Function
        End If
		
        cmLocal = cn.CreateCommand()
        Dim numRows As Integer = frmExportCheck.rsCheckList.Rows.Count
        For row As Integer = 0 To frmExportCheck.rsCheckList.Rows.Count - 1
            sStmt = "UPDATE bcheck SET qb_exported_flag='Y' " & _
            " WHERE check_no=" & Str(frmExportCheck.rsCheckList.Rows(row).Item("qb_doc_num")) & _
            " AND bank_cust_seq =" & Str(frmExportCheck.rsCheckList.Rows(row).Item("bank_cust_seq"))

            'MsgBox sStmt

            cmLocal.CommandText = sStmt
            cmLocal.ExecuteNonQuery()

        Next row

        update_check_status = True
        Exit Function

ErrorHandler:
        update_check_status = False
        save_error("frmExportCheckList", "update_check_status")
        MsgBox("Failed to Update Check Status." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
		
		
	End Function
End Class