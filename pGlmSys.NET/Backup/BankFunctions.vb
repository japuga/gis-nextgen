Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Module BankFunctions
    Private nTran As SqlTransaction = Nothing

    Public Function getDataTable(ByVal query As String, Optional ByRef aTrans As SqlTransaction = Nothing) As DataTable
        Dim ds As DataSet = New DataSet("tmpDS")
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim cmd As SqlCommand = cn.CreateCommand()
        Dim dt As DataTable

        If Not IsNothing(aTrans) Then
            cmd.Transaction = aTrans
        End If

        cmd.CommandText = query
        da.SelectCommand = cmd
        da.Fill(ds)
        dt = ds.Tables(0)
        Return dt

    End Function
    Public Function getDataSet(ByVal query As String) As DataSet
        Dim ds As DataSet = New DataSet("tmpDS")
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim cmd As SqlCommand = cn.CreateCommand()

        cmd.CommandText = query
        da.SelectCommand = cmd
        da.Fill(ds)
        '        dt = ds.Tables(0)
        Return ds
    End Function
    'Lista de funciones usadas en cheques y bancos
    'Carga cb con Lista de Bancos del cliente
    Public Sub load_bank(ByRef cb As System.Windows.Forms.ComboBox, ByRef sCustId As String)

        sStmt = "SELECT DISTINCT Bank.bank_name, Bank.bank_id " & "FROM BankAccount, Bank " & "WHERE BankAccount.bank_id = Bank.bank_id " & "AND BankAccount.cust_id ='" & Trim(sCustId) & "' " & "AND Bank.bank_status = 'ACTIVE' "

        load_cb_query2(cb, sStmt, 2, True)

        If cb.Items.Count > 0 Then
            cb.SelectedIndex = 0
        End If

        Exit Sub

ErrorHandler:
        save_error("BankFunctions", "load_bank")
        MsgBox("An unexpected error was found while loading Bank Info." & "Review log file for details", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")

    End Sub

    Public Sub load_card_bank(ByRef cb As System.Windows.Forms.ComboBox)
        sStmt = "SELECT DISTINCT Bank.bank_name, Bank.bank_id " & "FROM CreditCard, Bank " & "WHERE CreditCard.bank_id = Bank.bank_id "

        load_cb_query2(cb, sStmt, 2, True)

        If cb.Items.Count > 0 Then
            cb.SelectedIndex = 0
        End If

        Exit Sub

ErrorHandler:
        save_error("BankFunctions", "load_card_bank")
        MsgBox("An unexpected error was found while loading Bank Info." & "Review log file for details", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")

    End Sub

    'Carga cb con Cuentas de Banco
    Public Sub load_bank_account(ByRef cb As System.Windows.Forms.ComboBox, ByRef sCustId As String, ByRef nBankId As Short)

        On Error GoTo ErrorHandler

        sStmt = "SELECT BankAccount.bank_account, BankAccount.bank_cust_seq " & " FROM BankAccount " & " WHERE BankAccount.bank_id =  " & Str(nBankId) & " AND BankAccount.cust_id ='" & Trim(sCustId) & "' "
        load_cb_query2(cb, sStmt, 2, True)


        If cb.Items.Count > 0 Then
            mask_BankAccount(cb)
            cb.SelectedIndex = 0
        End If
        Exit Sub

ErrorHandler:
        save_error("BankFunctions", "load_bank_account")
        MsgBox("An unexpected error was found while loading Bank Accounts." & "Review log file for details", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")

    End Sub
    Public Sub load_card_number(ByRef cb As System.Windows.Forms.ComboBox, ByRef nBankId As Short)
        'On Error GoTo ErrorHandler

        sStmt = "SELECT CreditCard.card_number, CreditCard.card_seq " & " FROM CreditCard " & " WHERE CreditCard.bank_id =  " & Str(nBankId)

        load_cb_query2(cb, sStmt, 2, True)


        If cb.Items.Count > 0 Then
            mask_BankAccount(cb)
            cb.SelectedIndex = 0
        End If
        Exit Sub

ErrorHandler:
        save_error("BankFunctions", "load_bank_account")
        MsgBox("An unexpected error was found while loading Bank Accounts." & "Review log file for details", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")

    End Sub

    'Aplica Mascara a
    '1.todas las cuentas de cb
    '2.todas los numeros de tarjeta de credito de cb
    Public Sub mask_BankAccount(ByRef cb As System.Windows.Forms.ComboBox)
        Dim i, j As Object
        Dim nLen As Short
        Dim sBankAccount As String
        Dim nBankCustSeq As Short

        On Error GoTo ErrorHandler

        'Mascara de Cuentas
        For i = 0 To cb.Items.Count - 1
            sBankAccount = ""
            'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cb.SelectedIndex = i
            nLen = Len(Trim(cb.Text))
            If nLen > 4 Then
                For j = 1 To nLen - 4
                    sBankAccount = sBankAccount & "*"
                Next j
                sBankAccount = sBankAccount & Right(Trim(cb.Text), 4)
                nBankCustSeq = VB6.GetItemData(cb, cb.SelectedIndex)
                'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                cb.Items.RemoveAt(i)
                cb.Items.Insert(i, sBankAccount)
                VB6.SetItemData(cb, i, nBankCustSeq)
            End If
        Next i
        Exit Sub

ErrorHandler:
        save_error("BankFunctions", "mask_BankAccount")

    End Sub
    'Carga cb con lista de periodos
    Public Sub load_period2(ByRef cb As System.Windows.Forms.ComboBox, ByRef sCustId As String)

        On Error GoTo ErrorHandler
        If Len(sCustId) <= 0 Then
            Exit Sub
        End If


        sStmt = "SELECT period_name, period_seq, period_start_date FROM period " & " WHERE cust_id ='" & Trim(sCustId) & "'" & " ORDER BY period_start_date DESC"

        load_cb_query2(cb, sStmt, 2, True)

        If cb.Items.Count > 0 Then
            cb.SelectedIndex = 0
        End If

        Exit Sub

ErrorHandler:
        save_error("BankFunctions", "load_period2")

    End Sub

    'Funcion que retorna un string con todas las agencias
    'de este vendedor cuya direccion de pago es sVendPayAddress
    Public Function get_vend_seq(ByRef nVendId As Short, ByRef sVendPayAddress As String, ByRef sVendPayCity As String, ByRef sVendPayZip As String) As String

        Dim sVendSeq As String = ""

        Dim cmd As SqlCommand = cn.CreateCommand()
        On Error GoTo ErrorHandler
        'Dim da As SqlDataAdapter = New SqlDataAdapter()
        'Dim ds As DataSet = New DataSet("tmp")
        sStmt = "SELECT vend_seq FROM VBranch " & _
            " WHERE vend_id = " & Str(nVendId) & " AND vend_pay_address ='" & Trim(sVendPayAddress) & "' " & _
            " AND vend_pay_city ='" & Trim(sVendPayCity) & "' " & " AND vend_pay_zip ='" & Trim(sVendPayZip) & "' "
        cmd.CommandText = sStmt
        'If cn.State = ConnectionState.Open Then
        'cn.Close()
        'End If

        cmd.CommandText = sStmt
        rs = getDataTable(sStmt) 'cmd.ExecuteReader()

        'While (rs.Read())
        For row As Integer = 0 To rs.Rows.Count - 1
            If Len(sVendSeq) = 0 Then
                sVendSeq = Str(rs.Rows(row).Item("vend_seq"))
            Else
                sVendSeq = sVendSeq & "," & Str(rs.Rows(row).Item("vend_seq"))
            End If
        Next row


        get_vend_seq = sVendSeq
        Exit Function

ErrorHandler:
        save_error("BankFunctions", "get_vend_seq")
        MsgBox("An error ccurred while loading Vendor Seq info." & vbCrLf & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM error")
    End Function

    'Retorna lista de periodos en el rango
    Public Function get_period_seq(ByRef sCustId As String, ByRef nPeriodSeqStart As Object, ByRef nPeriodSeqEnd As Object) As String

        Dim sPeriodSeq As String
        Dim cmd As SqlCommand = cn.CreateCommand()
        On Error GoTo ErrorHandler

        sPeriodSeq = ""
        sStmt = "SELECT period_seq FROM period a " & _
                " WHERE cust_id='" & Trim(sCustId) & "' " & _
                    " AND period_start_date >=(SELECT period_start_date FROM period b " & _
                                    " WHERE b.cust_id = a.cust_id " & " AND b.period_seq=" & Str(nPeriodSeqStart) & ")" & _
                                    " AND period_end_date <=(SELECT period_end_date FROM period c " & _
                                    " WHERE c.cust_id = a.cust_id " & " AND c.period_seq=" & Str(nPeriodSeqEnd) & ")"
        cmd.CommandText = sStmt
        rs = getDataTable(sStmt) 'cmd.ExecuteReader()

        If rs.Rows.Count > 0 Then

            For row As Integer = 0 To rs.Rows.Count - 1
                sPeriodSeq = sPeriodSeq & Str(rs.Rows(row).Item("period_seq")) & ","
            Next row

            sPeriodSeq = Left(sPeriodSeq, Len(sPeriodSeq) - 1)
        Else
            sPeriodSeq = "-1"
        End If

        get_period_seq = sPeriodSeq
        Exit Function

ErrorHandler:
        save_error("BankFunctions", "get_period_seq")

    End Function
    'Version extendida de frmCheckRep:save_check
    'Guarda la lista de facturas pagadas en este cheque,
    'actualiza el estado de las facturas a PRT = PRINT impresas.
    'sCustId:
    'sStore: Arreglo con lista de tiendas cuyas facturas se pagan en este cheque
    'sCheckDate: Fecha de impresion del cheque
    Public Function save_check2(ByRef sCustId As String, ByRef sStore As Object, ByRef sCheckDate As String, ByRef nBatchId As Short, ByRef sFootNote1 As String, ByRef sFootNote2 As String) As Boolean

        Dim nCounter As Short
        Dim nRecords As Short
        Dim cmCheck As SqlCommand
        'Dim nTran As SqlTransaction
        Dim qb As gDumpUDT
        Dim sDetailMemo As String
        Dim nLastCheckNo As Short
        Dim nTotalInvoiceUpdated As Integer = 0
        nTran = Nothing
        Try


            save_check2 = True
            Try
                cmCheck = New SqlCommand("", cn)

                'NO actualizo/inserto en tablas  cuando se reimprime el mismo # de cheque
                If gCheck.reprint = True And gCheck.bSameCheck = True Then
                    nTran = cn.BeginTransaction()
                    'Actualizo fecha de reimpresion de cheque
                    sStmt = "UPDATE Bcheck " & " SET check_date='" & Str(CDbl(sCheckDate)) & "'" & " WHERE bank_cust_seq = " & gCheck.BankCustSeq & " AND check_no =" & Str(gCheck.VoidCheckNo)

                    'MsgBox sStmt
                    cmCheck.CommandText = sStmt
                    cmCheck.Transaction = nTran
                    cmCheck.ExecuteNonQuery()
                    nTran.Commit()
                End If

            Catch e As Exception
                save_check2 = False
                MsgBox("Failed to update date on Check:" & Str(gCheck.VoidCheckNo))
                'ROLLBACK
                nTran.Rollback()
                Exit Function
            End Try

            If Not gCheck.rsStore.Rows.Count > 0 Then
                MsgBox("Unable to save invoice information.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
                save_check2 = False
                Exit Function
            End If

            'Inicio la transaccion
            nTran = cn.BeginTransaction()
            nCounter = 0
            'Construye linea MEMO con  lista de tiendas pagadas en este cheque
            gCheck.Memo = get_check_memo2(sCustId, sStore, gGlobSettings.nMaxBatchCheckDetails)

            'UPGRADE_WARNING: Couldn't resolve default property of object qb. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            qb = get_qb_name2(sCustId)

            If qb.str1 = "ERROR" Then
                nTran.Rollback() 'Error en informacion para QuickBooksPro
                save_check2 = False
                Exit Function
            End If

            '            While gCheck.rsStore.Read()
            For row As Integer = 0 To gCheck.rsStore.Rows.Count - 1
                nCounter = nCounter + 1

                sDetailMemo = get_detail_memo2(sCustId, gCheck.rsStore.Rows(row).Item("Store"), gCheck.rsStore.Rows(row).Item("Account"), gCheck.rsStore.Rows(row).Item("Invoice"))

                sStmt = "INSERT INTO BCheck (check_no, bank_cust_seq,  " & " check_detail_no, vend_seq, " & " cust_id, store_id, " & " invoice_no, account_no, " & " check_date, check_amount, " & " check_memo, invoice_total, " & " detail_memo, qb_detail_name, voided_flag, " & " create_user, create_dtim, batch_id, " & " foot_note1, foot_note2) " & _
                " VALUES " & _
                "(" & Str(gCheck.CheckNo) & "," & gCheck.BankCustSeq & ", " & Str(nCounter) & ", " & Str(gCheck.rsStore.Rows(row).Item("vend_seq")) & _
                ", '" & gCheck.custId & "', " & Str(gCheck.rsStore.Rows(row).Item("store_id")) & ", '" & Trim(gCheck.rsStore.Rows(row).Item("Invoice")) & "', '" & _
                Trim(gCheck.rsStore.Rows(row).Item("Account")) & "', " & "'" & sCheckDate & "', " & Str(gCheck.Amount) & ", " & "'" & gCheck.Memo & "', " & _
                Str(gCheck.rsStore.Rows(row).Item("Total")) & ", " & "'" & Trim(sDetailMemo) & "', '" & Trim(qb.str1) & "', 'N', " & "'" & Trim(gsUser) & "', getdate()," & Str(nBatchId) & "," & "'" & Trim(sFootNote1) & "','" & Trim(sFootNote2) & "')"

                'MsgBox sStmt
                Try
                    cmCheck.CommandText = sStmt
                    cmCheck.Transaction = nTran
                    cmCheck.ExecuteNonQuery()
                Catch ex As Exception
                    save_check2 = False
                    nTran.Rollback()
                    MsgBox("Failed to insert Check:" & Str(gCheck.CheckNo), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit For
                End Try

                'Actualizo estado de la factura
                'sStmt = "UPDATE VInvoice " + _
                '"SET vinvoice_status = 'PRT' " + _
                '"WHERE vend_seq=" + Str(gCheck.rsStore.item("vend_seq")) + " " + _
                '"AND cust_id = '" + gCheck.CustId + "' " + _
                '"AND store_id = " + Str(gCheck.rsStore("store_id")) + " " + _
                '"AND invoice_no = '" + Trim(gCheck.rsStore("Invoice")) + "' " + _
                '"AND account_no = '" + Trim(gCheck.rsStore("Account")) + "' "
                'MsgBox sStmt
                'cmCheck.CommandText = sStmt
                'cmCheck.Execute nRecords
                Try
                    nRecords = update_invoice(gCheck.rsStore.Rows(row).Item("vend_seq"), gCheck.custId, gCheck.rsStore.Rows(row).Item("store_id"), gCheck.rsStore.Rows(row).Item("Invoice"), gCheck.rsStore.Rows(row).Item("Account"), "PRT")
                    If nRecords > 0 Then
                        nTotalInvoiceUpdated += nRecords
                        Dim stahp As String = ""
                    End If
                Catch ex As Exception
                    save_check2 = False
                    nTran.Rollback()
                    MsgBox("Failed to update Invoice information. Check:" & Str(gCheck.CheckNo), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit For
                End Try
            Next row

            'Termino la transaccion
            If gCheck.reprint Then
                'Void Check
                sStmt = "UPDATE Bcheck " & " SET " & _
                    "   check_amount=0 , " & "   invoice_total = 0, " & "   voided_flag ='Y' " & _
                    " WHERE bank_cust_seq = " & gCheck.BankCustSeq & " AND check_no =" & Str(gCheck.VoidCheckNo)

                'MsgBox sStmt
                cmCheck.CommandText = sStmt
                cmCheck.Transaction = nTran
                nRecords = cmCheck.ExecuteNonQuery()
                If nRecords > 0 Then
                    'ok
                    'cn.CommitTrans
                Else
                    save_check2 = False
                    'ROLLBACK
                    nTran.Rollback()
                    MsgBox("Failed to void Check:" & Str(gCheck.VoidCheckNo), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                End If

                '01.09.04 Actualizo ultimo cheque en Cuenta de Banco
                sStmt = "SELECT last_check_no FROM BankAccount " & " WHERE bank_cust_seq = " & Str(CDbl(gCheck.BankCustSeq))

                cmCheck.CommandText = sStmt
                rs = getDataTable(sStmt, nTran) ' cmCheck.ExecuteReader()

                If rs.Rows.Count > 0 Then
                    'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    If IsDBNull(rs.Rows(0).Item(0)) Then
                        nLastCheckNo = gCheck.CheckNo
                    Else
                        'Compare current LastCheck
                        If rs.Rows(0).Item(0) > gCheck.CheckNo Then
                            nLastCheckNo = rs.Rows(0).Item(0)
                        Else
                            nLastCheckNo = gCheck.CheckNo
                        End If
                    End If
                Else
                    'BankAccount notfound
                    save_check2 = False
                    nTran.Rollback()
                    MsgBox("Failed to update Bank Account last check field." & vbCrLf & "Verify that record exists in Bank Account table.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                    Exit Function
                End If


                sStmt = "UPDATE BankAccount " & " SET last_check_no=" & Str(nLastCheckNo) & " " & " WHERE bank_cust_seq =" & Str(CDbl(gCheck.BankCustSeq))

                Try
                    cmCheck.CommandText = sStmt
                    cmCheck.Transaction = nTran
                    cmCheck.ExecuteNonQuery()
                Catch e As Exception
                    save_check2 = False
                    nTran.Rollback()
                    MsgBox("Failed to update Bank Account information. Check:" & Str(gCheck.CheckNo), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Function
                End Try
                nTran.Commit()
            Else
                '01.09.04 Actualizo balance en Cuenta de Banco
                sStmt = "UPDATE BankAccount " & _
                    " SET last_check_no=" & Str(gCheck.CheckNo) & " ," & _
                        " bank_account_balance = bank_account_balance -" & Str(gCheck.Amount) & " " & _
                    " WHERE bank_cust_seq =" & Str(CDbl(gCheck.BankCustSeq))

                cmCheck.CommandText = sStmt
                cmCheck.Transaction = nTran
                nRecords = cmCheck.ExecuteNonQuery()

                If nRecords > 0 Then
                    'ok
                Else
                    save_check2 = False
                    nTran.Rollback()
                    MsgBox("Failed to update Bank Account information. Check:" & Str(gCheck.CheckNo), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Function
                End If

                'Termino la transaccion
                nTran.Commit()
            End If
            Exit Function

        Catch ex As Exception
            'Cierro cualquier transaccion abierta
            If Not IsNothing(nTran) Then
                Try
                    nTran.Rollback()
                Catch tranExc As Exception
                End Try
            End If

            save_check2 = False

            save_error("BankFunctions", "save_check2")
            MsgBox("An error ocurred while updating check info. Review log file for details", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
        End Try
    End Function
    'Actualiza el estado de la factura
    'Retorna el numero de registros que fueron actualizados
    Public Function update_invoice(ByRef nVendSeq As Short, ByRef sCustId As String, ByRef nStoreId As Short, ByRef sInvoiceNo As String, ByRef sAccountNo As String, ByRef sInvoiceStatus As String, Optional ByRef nBatchId As Short = 0) As Short

        Dim nRecords As Short

        nRecords = 0

        sStmt = "UPDATE VInvoice " & "SET vinvoice_status = '" & Trim(sInvoiceStatus) & "' "

        'Solo actualizar si el numero del Batch fue proporcionado
        If nBatchId <> 0 Then
            sStmt = sStmt & " , batch_id =" & Str(nBatchId)
        End If

        sStmt = sStmt & " WHERE vend_seq=" & Str(nVendSeq) & " " & _
            " AND cust_id = '" & sCustId & "' " & _
            " AND store_id = " & Str(nStoreId) & " " & _
            " AND invoice_no = '" & Trim(sInvoiceNo) & "' " & _
            " AND account_no = '" & Trim(sAccountNo) & "' "

        'MsgBox sStmt
        With cm
            .CommandText = sStmt
        End With

        If Not IsNothing(nTran) Then
            cm.Transaction = nTran
        End If

        nRecords = cm.ExecuteNonQuery()
        update_invoice = nRecords
        Exit Function

    End Function
    'Version extendida de frmCheckRep:get_check_memo
    'Crea el listado de tiendas cuyas facturas estan pagadas en este cheque
    'y que se imprime en la seccion MEMO del cheque
    'sCustId : Cliente
    'sStore : arreglo con lista de tiendas
    'nStoreMax: Longitud maxima de arreglo sStore
    'Public Function get_check_memo2(ByRef sCustId As String, ByRef sStore As Object, ByRef nStoreMax As Short, Optional ByRef nTran As SqlTransaction = Nothing) As String
    Public Function get_check_memo2(ByRef sCustId As String, ByRef sStore As Object, ByRef nStoreMax As Short) As String
        Dim i As Short = -1
        Dim sTmp As String = ""
        Dim sCustName As String = ""
        Dim cmd As SqlCommand = cn.CreateCommand()
        On Error GoTo ErrorHandler

        'Inicializo la variable con el nombre del cliente
        sTmp = ""

        sStmt = "SELECT cust_name FROM customer WHERE cust_id ='" & Trim(sCustId) & "'"
        cmd.CommandText = sStmt
        If Not IsNothing(nTran) Then
            cmd.Transaction = nTran
        End If
        rs = getDataTable(sStmt, nTran) ' cmd.ExecuteReader()
        If rs.Rows.Count > 0 Then
            sCustName = rs.Rows(0).Item("cust_name")
        End If

        sTmp = sCustName
        'Agrego la lista de tiendas
        If Len(sTmp) > 0 Then
            sTmp = Trim(sTmp) & " - Stores:"
        End If

        For i = 0 To nStoreMax - 1
            'UPGRADE_WARNING: Couldn't resolve default property of object sStore(i). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If sStore(i) <> "" Then
                'UPGRADE_WARNING: Couldn't resolve default property of object sStore(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                sTmp = sTmp & "#" & Trim(sStore(i)) & ", "
            End If
        Next i
        'Saco la ultima coma y agrego un punto al final
        sTmp = Left(sTmp, Len(sTmp) - 2) & "."

        get_check_memo2 = sTmp
        Exit Function

ErrorHandler:
        save_error("BankFunctions.bas", "get_check_memo2")
        MsgBox("An error occurred while formatting Check Info. Review log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
    End Function
    'Extended version of frmCheckRep: get_qb_name
    'Obtains the QuickBooks account name
    'Each customer is an account in Quickbooks, but the customer
    'just belongs to a single group: i.e. CS(Container Store), TR (Tony Roma), Nordstrom, etc
    'In case of error str1="ERROR" to be detected
    Public Function get_qb_name2(ByRef sCustId As String) As gDumpUDT
        Dim qb As gDumpUDT
        Dim sGroupId As String
        Dim sCustName As String
        Dim rsLocal As DataTable
        Dim rsLocal2 As DataTable
        Dim cmd As SqlCommand = cn.CreateCommand()

        qb.str1 = "" 'qb_name
        qb.str2 = ""


        Try

            sStmt = "SELECT qb_group_id, qb_account_name, cust_name " & " FROM customer " & " WHERE cust_id = '" & Trim(sCustId) & "'"
            cmd.CommandText = sStmt
            cmd.Transaction = nTran
            rsLocal = getDataTable(sStmt, nTran) 'cmd.ExecuteReader()
            If rsLocal.Rows.Count > 0 Then
                sCustName = rsLocal.Rows(0).Item("cust_name")
                'QB-Group
                If IsDBNull(rsLocal.Rows(0).Item("qb_group_id")) Then
                    MsgBox("Quick Books Group has not been defined " & "for this customer " & sCustId & "." & vbCrLf & "Please check customer info and try again.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
                    qb.str1 = "ERROR"
                    get_qb_name2 = qb
                    Exit Function
                Else
                    sGroupId = rsLocal.Rows(0).Item("qb_group_id")
                End If

                'QB-Customer Account

                If IsDBNull(rsLocal.Rows(0).Item("qb_account_name")) Then
                    MsgBox("Customer " & Trim(sCustName) & " does not have a Quick Books Account defined." & vbCrLf & "Please check customer info and try again later.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
                    qb.str1 = "ERROR"
                    get_qb_name2 = qb
                    Exit Function
                Else
                    qb.str1 = quotation_mask(rsLocal.Rows(0).Item("qb_account_name"))
                    If Len(Trim(qb.str1)) = 0 Then
                        MsgBox("Incorrect QuickBooks account for customer." & Trim(sCustName) & vbCrLf & "Please check customer info and try again later.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
                        qb.str1 = "ERROR"
                        get_qb_name2 = qb
                        Exit Function
                    Else
                        'OK. Verify that account exists in qb_account
                        sStmt = "SELECT COUNT(*) FROM qb_account " & " WHERE name ='" & Trim(qb.str1) & "' " & " AND qb_group_id ='" & Trim(sGroupId) & "'"
                        cmd.CommandText = sStmt
                        Try
                            rsLocal2 = getDataTable(sStmt, nTran) 'cmd.ExecuteReader()

                            If rsLocal2.Rows.Count > 0 Then
                                If rsLocal2.Rows(0).Item(0) > 0 Then
                                    If rsLocal2.Rows(0).Item(0) > 1 Then
                                        MsgBox("QBooks setup error found." & vbCrLf & "Customer account was found more than once " & "on Qbooks Account table.")
                                        qb.str1 = "ERROR"
                                        get_qb_name2 = qb
                                        Exit Function
                                    Else
                                        'OK
                                    End If
                                Else
                                    MsgBox("Quick Books setup error found." & vbCrLf & "Either customer " & Trim(sCustName) & " does not belong to QBooks file " & sGroupId & vbCrLf & " or QBooks Account data needs to be updated", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
                                    qb.str1 = "ERROR"
                                    get_qb_name2 = qb
                                    Exit Function
                                End If
                            Else
                                MsgBox("Quick Books setup error found." & vbCrLf & "Either customer does not belong to QBooks file " & sGroupId & vbCrLf & " or QBooks Account data needs to be updated", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
                                qb.str1 = "ERROR"
                                get_qb_name2 = qb
                                Exit Function
                            End If
                        Catch e As Exception

                            MsgBox("An unexpected error has occurred." & "Please check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")

                            qb.str1 = "ERROR"
                            get_qb_name2 = qb
                            Exit Function

                        End Try
                    End If
                End If

                'rsLocal.Close()
                'rsLocal2.Close()
            End If


            get_qb_name2 = qb
            Exit Function

        Catch e As Exception
            get_qb_name2 = New gDumpUDT()
            get_qb_name2.str1 = "ERROR"
            save_error("BankFunctions", "get_qb_name2")

        End Try
    End Function

    'Version extendida de frmCheckRep:get_detail_memo
    'Linea de detalle en cheque: Inlcuye Store, Account number,Invoice number ,
    Public Function get_detail_memo2(ByRef sCustId As String, ByRef sStore As String, ByRef sAccount As String, ByRef sInvoice As String) As String

        Dim sCustName As String = ""
        Dim sTmp As String
        Dim cmd As SqlCommand = cn.CreateCommand()

        On Error GoTo ErrorHandler
        'Busco nombre del cliente

        sStmt = "SELECT cust_name FROM customer " & " WHERE cust_id ='" & Trim(sCustId) & "'"
        cmd.CommandText = sStmt
        If IsNothing(nTran) Then
            rs = getDataTable(sStmt) ' cmd.ExecuteReader()
        Else
            rs = getDataTable(sStmt, nTran) ' cmd.ExecuteReader()
        End If

        sCustName = rs.Rows(0).Item("cust_name")

        sTmp = Trim(sCustName) & " #" & Trim(sStore) & "-Acct#" & Trim(sAccount) & "-Inv#" & Trim(sInvoice)
        get_detail_memo2 = sTmp
        Exit Function

ErrorHandler:
        save_error("BankFunctions", "get_detail_memo2")
        MsgBox("An error occurred while formatting Check Info. Review log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
    End Function
    'Returns next available check number
    Public Function get_check_no(ByRef nBankCustSeq As Object) As Integer
        Dim sQBGroupId As String
        Dim cmd As SqlCommand = cn.CreateCommand()
        On Error GoTo ErrorHandler

        get_check_no = 0

        'Obtengo el QB grupo al que pertenece el cliente

        sStmt = "SELECT qb_group_id FROM customer " & " WHERE cust_id = " & " (SELECT cust_id FROM BankAccount " & _
                "  WHERE bank_cust_seq = " & Str(nBankCustSeq) & ")"
        cmd.CommandText = sStmt

        rs = getDataTable(sStmt) ' = cmd.ExecuteReader()
        If rs.Rows.Count > 0 Then
            sQBGroupId = rs.Rows(0).Item("qb_group_id")
        Else
            MsgBox("Failed to obtain Customer's QuickBooks group.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Function
        End If

        'Lista de BankCustSeq del QB group

        'Check Info
        sStmt = "SELECT MAX(check_no) FROM BCheck " & "WHERE bank_cust_seq IN  " & _
                    " (SELECT bank_cust_seq FROM qb_BankAccount " & _
                        "  WHERE qb_group_id ='" & sQBGroupId & "')"
        cmd.CommandText = sStmt
        rs = getDataTable(sStmt) ' cmd.ExecuteReader()

        'Error al ejecutar query

        'Query no retorno datos
        If Not rs.Rows.Count > 0 Then
            get_check_no = 1
        Else
            If IsDBNull(rs.Rows(0).Item(0)) Then
                get_check_no = 1
            Else
                get_check_no = rs.Rows(0).Item(0) + 1
            End If
        End If

        Exit Function

ErrorHandler:
        save_error("BankFunctions", "get_check_no")
        MsgBox("Unable to get check number.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
    End Function


    'Extension de frmCheckRep:add_store
    'Guarda nueva tienda en arreglo Store a fin de construir linea MEMO de cheque
    'Retorna el numero de elementos en arreglo
    Public Function add_store2(ByRef sStore As Object, ByRef sData As String) As Short
        Dim i As Short

        On Error GoTo ErrorHandler


        For i = 0 To gGlobSettings.nMaxBatchCheckDetails - 1
            'Encontre espacio para ubicar tienda
            If sStore(i) = "" Then
                sStore(i) = Trim(sData)
                add_store2 = i
                Exit Function
            End If

            'Verifica que el store no haya sido ingresada previamente
            If Trim(sStore(i)) = Trim(sData) Then
                add_store2 = i
                Exit Function
            End If
        Next i

        Exit Function

ErrorHandler:
        save_error("BankFunctions.bas", "add_store2")
        MsgBox("An unexpected has occurred , check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
    End Function



    'Retorna el numero de Batch
    Public Function get_batch_id(ByRef sCustId As String) As Short

        Dim nBatchId As Short
        Dim cmd As SqlCommand = cn.CreateCommand()
        On Error GoTo ErrorHandler

        get_batch_id = -1

        sStmt = "SELECT MAX(batch_id) FROM BBatch"
        cmd.CommandText = sStmt
        rs = getDataTable(sStmt) ' cmd.ExecuteReader()

        If rs.Rows.Count > 0 Then
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item(0)) Then
                nBatchId = 1
            Else
                nBatchId = rs.Rows(0).Item(0) + 1
            End If
        Else
            nBatchId = 1
        End If


        If nBatchId > 0 Then
            sStmt = "INSERT INTO BBatch(batch_id, cust_id,create_user)" & " VALUES (" & Str(nBatchId) & "," & "'" & sCustId & "'," & "'" & gsUser & "')"
            cm.CommandText = sStmt
            cm.ExecuteNonQuery()
        End If
        get_batch_id = nBatchId
        Exit Function

ErrorHandler:
        save_error("BankFunction", "get_batch_id")
        MsgBox("Failed to obtain Batch Number", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")

    End Function

    'Extension de frmChekRep:list_store()
    'Agrega las tiendas en dos o tres lineas (nLines) de longitud maxima nLen
    'En caso de que existan mas tiendas que las que se puedan mostrar en nLines,
    'las tiendas sobrantes se agregan a la ultima linea
    Public Sub list_store2(ByRef sLinea As Object, ByRef sCustName As String, ByRef sStore As Object, ByRef nLines As Short, ByRef nLen As Short)


        Dim i As Object
        Dim j As Short
        'Dim sLinea(1 To 3) As String

        j = 0

        'UPGRADE_WARNING: Couldn't resolve default property of object sLinea(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        sLinea(j) = Trim(sCustName) & " - "
        For i = 0 To 15
            'UPGRADE_WARNING: Couldn't resolve default property of object sStore(i). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If sStore(i) <> "" Then
                'Verifica que linea no exceda nLen
                If Len(sLinea(j)) >= nLen And j < nLines + 1 Then
                    j = j + 1
                End If
                sLinea(j) = Trim(sLinea(j)) & "-" & Trim(sStore(i))
            Else
                Exit Sub
            End If
        Next i
        'MsgBox sLinea(1) + sLinea(2) + sLinea(3)
        'list_store2 = sLinea
    End Sub


    'Query usado para reimprimir cheques y BatchChecks
    Public Function get_check_query(ByRef nCheckNo As Integer, ByRef nBankCustSeq As Short) As String


        sStmt = "SELECT bcheck.invoice_no AS Invoice," & " store.store_number AS Store, " & _
                " vinvoice.account_no AS Account, " & " vinvoice.vinvoice_date AS Date, " & " bcheck.store_id, bcheck.invoice_total as Total, " & _
                " VAccount.account_mask, VInvoice.vend_seq  " & " FROM Bcheck, Vinvoice, Store, VAccount " & _
                " WHERE Vinvoice.store_id = Store.store_id " & " AND Vinvoice.cust_id = Store.cust_id " & " AND Bcheck.invoice_no = Vinvoice.invoice_no " & _
                " AND Bcheck.cust_id = Vinvoice.cust_id " & " AND Bcheck.store_id = Vinvoice.store_id " & " AND Bcheck.account_no = Vinvoice.account_no " & _
                " AND Bcheck.vend_seq = Vinvoice.vend_seq " & " AND VAccount.cust_id = VInvoice.cust_id " & _
                " AND VAccount.account_no = VInvoice.account_no " & " AND VAccount.store_id = VInvoice.store_id " & _
                " AND VAccount.vend_seq = VInvoice.vend_seq " & " AND Bcheck.check_no =" & Str(nCheckNo) & _
                " AND Bcheck.bank_cust_seq = " & Str(nBankCustSeq)

        get_check_query = sStmt
    End Function
    'Formatea numero de cheque para que tenga una longitud de seis digitos
    'anteponiendo ceros de ser necesario
    'Ex. si # es 1098, retorna 001098
    Public Function format_check_number(ByRef nCheckNo As Integer) As String
        Dim sCheckNo As String
        Dim nLen As Short
        Dim i As Short

        sCheckNo = Trim(Str(nCheckNo))
        nLen = Len(Trim(sCheckNo))

        If nLen >= 6 Then
            format_check_number = sCheckNo
            Exit Function
        End If

        For i = 0 To 5 - nLen
            sCheckNo = "0" & Trim(sCheckNo)
        Next i
        format_check_number = sCheckNo
        Exit Function


    End Function


    Public Function get_bank_account(ByRef nBankCustSeq As Short) As String
        Dim cmd As SqlCommand = cn.CreateCommand()
        get_bank_account = ""

        sStmt = "SELECT bank_account FROM BankAccount " & " WHERE bank_cust_seq = " & Str(nBankCustSeq)
        cmd.CommandText = sStmt

        rs = getDataTable(sStmt) ' cmd.ExecuteReader()

        If rs.Rows.Count > 0 Then
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item("bank_account")) Then
                get_bank_account = ""
            Else
                get_bank_account = rs.Rows(0).Item("bank_account")
            End If
            Exit Function
        End If

    End Function

    Public Function get_bank_aba(ByRef nBankCustSeq As Short) As String
        Dim cmd As SqlCommand = cn.CreateCommand()
        get_bank_aba = ""

        sStmt = "SELECT bank_aba FROM Bank, BankAccount " & " WHERE Bank.bank_id = BankAccount.bank_id " & " AND BankAccount.bank_cust_seq = " & Str(nBankCustSeq)
        cmd.CommandText = sStmt

        rs = getDataTable(sStmt) ' cmd.ExecuteReader()

        If rs.Rows.Count > 0 Then
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item("bank_aba")) Then
                get_bank_aba = ""
            Else
                get_bank_aba = rs.Rows(0).Item("bank_aba")
            End If
            Exit Function
        End If


    End Function
    Public Function get_bank_info(ByRef nBankCustSeq As Short, ByRef sFieldName As String) As String

        get_bank_info = ""
        Dim cmd As SqlCommand = cn.CreateCommand()

        sStmt = "SELECT " & sFieldName & " FROM Bank, BankAccount " & " WHERE Bank.bank_id = BankAccount.bank_id " & " AND BankAccount.bank_cust_seq = " & Str(nBankCustSeq)
        cmd.CommandText = sStmt

        rs = getDataTable(sStmt) ' cmd.ExecuteReader()

        If rs.Rows.Count > 0 Then
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item(sFieldName)) Then
                get_bank_info = ""
            Else
                get_bank_info = rs.Rows(0).Item(sFieldName)
            End If
            Exit Function
        End If


    End Function


    'sOption: NUM_CHECKS
    Public Sub update_batch(ByRef nBatchId As Short, ByRef sOption As String, Optional ByRef nNumInvoices As Short = 0, Optional ByRef nNumChecks As Short = 0, Optional ByRef nNumZeroInvoices As Short = 0, Optional ByRef nTotalChecks As Double = 0)

        Dim nRecords As Short
        Dim sMsg As String
        Dim cmd As SqlCommand = cn.CreateCommand()
        Select Case sOption
            Case "NUM_CHECKS"
                sStmt = "UPDATE BBatch " & " SET num_checks=" & Str(nNumChecks) & " WHERE batch_id =" & Str(nBatchId)
            Case "NUM_INVOICES"
                sStmt = "UPDATE BBatch " & " SET num_invoices=" & Str(nNumInvoices) & " WHERE batch_id =" & Str(nBatchId)
            Case "TOTAL_CHECKS"
                sStmt = "UPDATE BBatch " & " SET total_checks=" & Str(nTotalChecks) & " WHERE batch_id =" & Str(nBatchId)
            Case "ALL"
                sStmt = "UPDATE BBatch " & " SET num_checks=" & Str(nNumChecks) & "," & "   num_invoices=" & Str(nNumInvoices) & "," & _
                        "   num_zero_invoices = " & Str(nNumZeroInvoices) & "," & _
                        "   total_checks=" & Str(nTotalChecks) & " WHERE batch_id =" & Str(nBatchId)

        End Select
        cmd.CommandText = sStmt
        nRecords = cmd.ExecuteNonQuery()

        If nRecords > 0 Then
            'ok
        Else
            sMsg = "Warning: Failed to update BBatch table:" & sOption
            write_error(sMsg, sLogfile, False)
        End If

    End Sub


    'Verifica que el numero de cheque no se haya repetido
    Public Function check_dup2(ByRef sCheckNo As String, ByRef nBankCustSeq As Short) As Boolean
        Dim cmd As SqlCommand = cn.CreateCommand()
        On Error GoTo ErrorHandler

        check_dup2 = False
        sStmt = "SELECT check_no FROM BCheck " & " WHERE bank_cust_seq =" & Str(nBankCustSeq) & " AND check_no =" & sCheckNo
        cmd.CommandText = sStmt
        rs = getDataTable(sStmt) ' cmd.ExecuteReader()

        If rs.Rows.Count > 0 Then
            check_dup2 = True
        Else
            check_dup2 = False
        End If

        Exit Function

ErrorHandler:
        save_error("BankFunctions.bas", "check_dup2")
        MsgBox("Failed to verify Check Dups. Review log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
    End Function


    'Recorre la lista de cheques parte de este BatchId,
    'genera formato e imprime cheques(print_check_batch)
    Public Sub print_batch2(ByRef nBatchId As Short, ByRef uPaperSource As General.CheckPaper)


        Dim rsCheckHeader As DataTable

        Dim sCustName As String
        Dim nCheckNo As Integer
        Dim nBankCustSeq As Short
        Dim sCheckDate As String
        Dim nCheckAmount As Double
        Dim sAmountString As String
        Dim sVendName As String
        Dim sVendPayAddress As String
        Dim sVendPayCity As String
        Dim sVendPayState As String
        Dim sVendPayZip As String
        Dim sBankAba As String
        Dim sPrevBankAba As String
        Dim sBankAccount As String
        Dim sPrevBankAccount As String
        Dim sStoreArray(16) As String
        Dim sFootNote1 As String
        Dim sFootNote2 As String
        Dim sBankCheckInfo1 As String
        Dim sBankCheckInfo2 As String
        Dim sBankCheckInfo3 As String
        Dim sBankCheckInfo4 As String
        Dim cmd As SqlCommand = cn.CreateCommand()

        sBankAba = ""
        sBankAccount = ""

        sPrevBankAba = "0"
        sPrevBankAccount = "0"



        sStmt = "SELECT DISTINCT BCheck.check_no, BCheck.check_date, " & " BCheck.check_amount, BCheck.bank_cust_seq , " & " Vendor.vend_name, " & " VBranch.vend_pay_address, VBranch.vend_pay_city, " & " VBranch.vend_pay_state, VBranch.vend_pay_zip," & " Customer.cust_name, " & " BCheck.foot_note1, BCheck.foot_note2 " & " FROM BCheck, Vendor, VBranch, Customer " & " WHERE BCheck.cust_id = Customer.cust_id " & " AND BCheck.vend_seq = VBranch.vend_seq " & " AND Vendor.vend_id = VBranch.vend_id " & " AND BCheck.batch_id=" & Str(nBatchId)
        cmd.CommandText = sStmt


        rsCheckHeader = getDataTable(sStmt) 'cmd.ExecuteReader()

        If Not rsCheckHeader.Rows.Count > 0 Then
            MsgBox("No Checks were found for this Batch Id:" & Str(nBatchId), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
            Exit Sub
        Else
            'While rsCheckHeader.Read()
            For arow As Integer = 0 To rsCheckHeader.Rows.Count - 1
                If sPrevBankAccount <> sBankAccount Then
                    sPrevBankAccount = sBankAccount
                    sBankAccount = get_bank_account(rsCheckHeader.Rows(arow).Item("bank_cust_seq"))
                    If sBankAccount = "" Then
                        MsgBox("Failed to retrieve Bank Account number, batch id=" & Str(nBatchId), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                        Exit Sub
                    End If
                End If

                If sPrevBankAba <> sBankAba Then
                    sPrevBankAba = sBankAba
                    sBankAba = get_bank_aba(rsCheckHeader.Rows(arow).Item("bank_cust_seq"))
                    If sBankAba = "" Then
                        MsgBox("Failed to retrieve Bank ABA number, batch id=" & Str(nBatchId), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                        Exit Sub
                    End If
                End If

                If Not IsDBNull(rsCheckHeader.Rows(arow).Item("check_no")) Then
                    nCheckNo = rsCheckHeader.Rows(arow).Item("check_no")
                Else
                    MsgBox("Failed to retrieve Check Number, batch id=" & Str(nBatchId), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                    Exit Sub
                End If

                If Not IsDBNull(rsCheckHeader.Rows(arow).Item("check_date")) Then
                    sCheckDate = rsCheckHeader.Rows(arow).Item("check_date")
                Else
                    MsgBox("Failed to retrieve Check Date, batch id=" & Str(nBatchId), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                    Exit Sub
                End If

                'sbBatch.SimpleText = "Printing Check# " + Str(nCheckNo)

                sCustName = rsCheckHeader.Rows(arow).Item("cust_name")
                nCheckAmount = rsCheckHeader.Rows(arow).Item("check_amount")
                nBankCustSeq = rsCheckHeader.Rows(arow).Item("bank_cust_seq")
                sVendName = rsCheckHeader.Rows(arow).Item("vend_name")
                sVendPayAddress = rsCheckHeader.Rows(arow).Item("vend_pay_address")
                sVendPayCity = rsCheckHeader.Rows(arow).Item("vend_pay_city")
                sVendPayState = rsCheckHeader.Rows(arow).Item("vend_pay_state")
                sVendPayZip = rsCheckHeader.Rows(arow).Item("vend_pay_zip")
                sAmountString = num2str(nCheckAmount)

                sBankCheckInfo1 = get_bank_info(rsCheckHeader.Rows(arow).Item("bank_cust_seq"), "check_info1")
                sBankCheckInfo2 = get_bank_info(rsCheckHeader.Rows(arow).Item("bank_cust_seq"), "check_info2")
                sBankCheckInfo3 = get_bank_info(rsCheckHeader.Rows(arow).Item("bank_cust_seq"), "check_info3")
                sBankCheckInfo4 = get_bank_info(rsCheckHeader.Rows(arow).Item("bank_cust_seq"), "check_info4")

                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                If IsDBNull(rsCheckHeader.Rows(arow).Item("foot_note1")) Then
                    sFootNote1 = ""
                Else
                    sFootNote1 = rsCheckHeader.Rows(arow).Item("foot_note1")
                End If


                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                If IsDBNull(rsCheckHeader.Rows(arow).Item("foot_note2")) Then
                    sFootNote2 = ""
                Else
                    sFootNote2 = rsCheckHeader.Rows(arow).Item("foot_note2")
                End If

                'Carga gCheck.rsStore
                If get_check_detail2(nCheckNo, nBankCustSeq) = False Then
                    Exit Sub
                End If

                load_store_array2(nCheckNo, nBankCustSeq, sStoreArray)

                Select Case uPaperSource
                    Case General.CheckPaper.Blank
                        print_check_batch3(sCustName, nCheckNo, sCheckDate, sVendName, nCheckAmount, sAmountString, sVendPayAddress, sVendPayCity, sVendPayState, sVendPayZip, sFootNote1, sFootNote2, sBankAba, sBankAccount, sStoreArray, sBankCheckInfo1, sBankCheckInfo2, sBankCheckInfo3, sBankCheckInfo4)

                    Case General.CheckPaper.Imprinted
                        print_check5(sCustName, nCheckNo, sCheckDate, sVendName, nCheckAmount, sAmountString, sVendPayAddress, sVendPayCity, sVendPayState, sVendPayZip, sFootNote1, sFootNote2, sBankAba, sBankAccount, sStoreArray)
                End Select
            Next
            'End While
        End If




    End Sub

    Public Function get_check_detail2(ByRef nCheckNo As Integer, ByRef nBankCustSeq As Short) As Boolean

        On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand()
        get_check_detail2 = False

        sStmt = get_check_query(nCheckNo, nBankCustSeq)
        cmd.CommandText = sStmt
        gCheck.rsStore = getDataTable(sStmt) ' cmd.ExecuteReader()

        If gCheck.rsStore.Rows.Count > 0 Then
            'ok
            get_check_detail2 = True
        Else
            'gCheck.rsStore.Close()
            MsgBox("Could not retrieve check details from database. " & "Check#:" & Str(nCheckNo), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Function
        End If

        Exit Function

ErrorHandler:
        save_error("BankFunctions", "get_check_detail2")
        MsgBox("Unexpected error was found.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
    End Function



    Public Sub load_store_array2(ByRef nCheckNo As Integer, ByRef nBankCustSeq As Short, ByRef sStoreArray As Object)
        Dim cmd As SqlCommand = cn.CreateCommand()
        Dim i As Short
        init_store_array2(sStoreArray)

        sStmt = "SELECT DISTINCT store.store_number " & " FROM BCheck, Store " & " WHERE BCheck.cust_id = Store.cust_id " & " AND BCheck.store_id = Store.store_id " & " AND BCheck.check_no = " & Str(nCheckNo) & " AND BCheck.bank_cust_seq = " & Str(nBankCustSeq)
        cmd.CommandText = sStmt
        rs = getDataTable(sStmt) ' cmd.ExecuteReader()
        i = 0

        For row As Integer = 0 To rs.Rows.Count - 1
            sStoreArray(i) = rs.Rows(row).Item("store_number")
            i = i + 1
        Next row

    End Sub

    Public Sub init_store_array2(ByRef sArray As Object)
        Dim i As Short

        For i = 0 To gGlobSettings.nMaxBatchCheckDetails - 1
            'UPGRADE_WARNING: Couldn't resolve default property of object sArray(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            sArray(i) = ""
        Next i
    End Sub

    'Imprime cheque en papel PRE-IMPRESO
    Public Sub print_check5(ByRef sCustName As String, ByRef nCheckNo As Integer, ByRef sCheckDate As String, ByRef sVendName As String, ByRef nCheckAmount As Double, ByRef sAmountString As String, ByRef sVendPayAddress As String, ByRef sVendPayCity As String, ByRef sVendPayState As String, ByRef sVendPayZip As String, ByRef sDetail1 As String, ByRef sDetail2 As String, ByRef sBankAba As String, ByRef sBankAccount As String, ByRef sStoreArray As Object)

        Dim i As Short
        Dim nRate As Double
        Dim sAmount As Object
        Dim nLines As Short
        Dim nCounter As Short

        Dim sLinea(3) As String

        On Error GoTo ErrorHandler


        'Valores de impresion
        'UPGRADE_ISSUE: Constant vbPRPSLetter was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
        'UPGRADE_ISSUE: Printer property Printer.PaperSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.PaperSize = vbPRPSLetter
        'UPGRADE_ISSUE: Printer property Printer.FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontName = "Times New Roman"
        'UPGRADE_ISSUE: Printer property Printer.FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontSize = 12

        'Fecha
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6.82 * 1440
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 0.56 * 1440
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sCheckDate)

        'Vendor
        'UPGRADE_WARNING: Couldn't resolve default property of object sAmount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        sAmount = FormatCurrency(nCheckAmount)
        'UPGRADE_WARNING: Couldn't resolve default property of object sAmount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        sAmount = "**" & Right(sAmount, Len(sAmount) - 1)
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 1 * 1440
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 1.06 * 1440
        'Printer.Print txtVendor;
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sVendName)
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6.8 * 1440
        'UPGRADE_WARNING: Couldn't resolve default property of object sAmount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sAmount)

        'Amount String
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.22 * 1440
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 1.41 * 1440 '1.51
        'txtAmountString = Trim(txtAmountString) + "****************************"
        sAmountString = Trim(sAmountString) & "****************************"
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sAmountString)

        'Vendor Address
        'UPGRADE_ISSUE: Printer property Printer.FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontSize = 10
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.7 * 1440 '0.7
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 1.9 * 1440 '1.75
        'Printer.Print UCase(txtVendor)
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(UCase(sVendName))
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.7 * 1440 '0.7
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.05 * 1440 ' 1.9
        'Printer.Print UCase(sVendAddress)
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(UCase(sVendPayAddress))


        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.7 * 1440
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.2 * 1440 '2.05
        'sVendCity = Trim(sVendCity) + " - " + sVendZip
        'Printer.Print UCase(sVendCity)
        sVendPayCity = Trim(sVendPayCity) & " - " & sVendPayState & " - " & sVendPayZip

        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(UCase(sVendPayCity))

        'Printer.CurrentX = 0.7 * 1440
        'Printer.CurrentY = 2.2 * 1440  '2.1
        'Printer.Print sVendZip

        'Store list
        'list_store 3, 30
        list_store2(sLinea, sCustName, sStoreArray, 3, 30)
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.7 * 1440
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.5 * 1440
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(1))

        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.7 * 1440
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.65 * 1440
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(2))

        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.7 * 1440
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 2.8 * 1440
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(3))

        'Check Detail
        'DETALLE
        'UPGRADE_ISSUE: Printer property Printer.FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '.FontName = "Courier New" '01.09.04
        'UPGRADE_ISSUE: Printer property Printer.FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontSize = 9 '*************
        'UPGRADE_ISSUE: Printer property Printer.FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontBold = True

        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        '01.09.04
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 3.67 * 1440
        'nLines = parse_string(txtVendor, 18)
        nLines = parse_string(sVendName, 18)
        If nLines > 0 Then
            'Printer.Print gParse(1);
        Else
            'Printer.Print txtVendor;
            'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.Print(sVendName)
        End If

        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 3.94 * 1440 '3.67
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 7 * 1440 '7.28
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sCheckDate)

        'UPGRADE_ISSUE: Printer property Printer.FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontUnderline = True

        'TITULOS
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 3.67 * 1440 '3.87
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 2 * 1440 '3
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Store")
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440 '4
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Account")
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 4.5 * 1440 '5
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Invoice")
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6 * 1440 '6
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Amount")

        'Printer.FontBold = False
        'UPGRADE_ISSUE: Printer property Printer.FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontUnderline = False

        'DATOS
        nRate = 0.13 '0.15
        i = 0
        'namount = 1012.23

        nCounter = 0
        For row As Integer = 0 To gCheck.rsStore.Rows.Count - 1
            'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.CurrentY = (3.72 + (nRate * i)) * 1440 '3.92
            'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.CurrentX = 2 * 1440 '3
            'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.Print(gCheck.rsStore.item("Store"))
            'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.CurrentX = 3 * 1440 '4
            '05.15.03 Mascara de cuenta
            'Printer.Print gCheck.rsStore("Account");
            'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.Print(gCheck.rsStore.item("account_mask"))
            'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.CurrentX = 4.5 * 1440 '5
            'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.Print(gCheck.rsStore.item("Invoice"))
            'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.CurrentX = 5.7 * 1440 '6
            'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.Print(format_qty(FormatCurrency(gCheck.rsStore.item("Total"), 2, TriState.True)))

            i = i + 1
        Next row

        'Nombre de vendedor multilinea
        i = 0
        For nCounter = 0 To nLines - 1
            'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.CurrentY = (3.72 + (nRate * i)) * 1440 '3.92
            'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.CurrentX = 0.1 * 1440
            'Printer.FontBold = True
            'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.Print(gParse(nCounter))
            'Printer.FontBold = False
            i = i + 1
        Next nCounter

        'Listado de Tiendas
        'list_store 2, 60
        list_store2(sLinea, sCustName, sStoreArray, 2, 60)
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 6.2 * 1440 '6.52
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(1))
        '---
        'Total del cheque
        'Printer.FontBold = True
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6 * 1440
        'Printer.Print FormatCurrency(txtAmount, 2, vbTrue)
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(FormatCurrency(nCheckAmount, 2, TriState.True))
        'Printer.FontBold = False
        'Segunda linea de tiendas
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 6.35 * 1440
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(2))

        '05.15.03
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 6.35 * 1440
        'Printer.Print txtDetail1
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sDetail1)

        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 6.55 * 1440
        'Printer.Print txtDetail2
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sDetail2)

        'COPIA *************************************

        'UPGRADE_ISSUE: Printer property Printer.FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontBold = True

        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 7.2 * 1440
        'nLines = parse_string(txtVendor, 18)
        nLines = parse_string(sVendName, 18)
        If nLines > 0 Then
            'Printer.Print gParse(1);
        Else
            'Printer.Print txtVendor;
            'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.Print(sVendName)
        End If

        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 7.47 * 1440 '3.67
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 7 * 1440 '7.28
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sCheckDate)

        'UPGRADE_ISSUE: Printer property Printer.FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontUnderline = True

        'TITULOS
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 7.15 * 1440 '7.35
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '.CurrentX = 2 * 1440 '3
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Store")
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440 '4
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Account")
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '.CurrentX = 4.5 * 1440 '5
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Invoice")
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6 * 1440 '3.7
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print("Amount")

        'Printer.FontBold = False
        'UPGRADE_ISSUE: Printer property Printer.FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.FontUnderline = False


        i = 0


        For row As Integer = 0 To gCheck.rsStore.Rows.Count - 1
            'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.CurrentY = (7.2 + (nRate * i)) * 1440 '7.4
            'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.CurrentX = 2 * 1440 '3
            'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: Printer method 'Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.Print(gCheck.rsStore.item("Store"))
            'UPGRADE_ISSUE: Printer property 'Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.CurrentX = 3 * 1440 '4
            '05.15.03 Mascara de Cuenta
            ''Printer.Print gCheck.rsStore("Account");
            'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: Printer method 'Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.Print(gCheck.rsStore.item("account_mask"))
            'UPGRADE_ISSUE: Printer property 'Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.CurrentX = 4.5 * 1440 '5
            'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: Printer method 'Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.Print(gCheck.rsStore.item("Invoice"))
            'UPGRADE_ISSUE: Printer property 'Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.CurrentX = 5.7 * 1440 '6
            ''Printer.Print FormatCurrency(gCheck.rsStore("Total"), 2, vbTrue)
            'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: Printer method 'Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.Print(format_qty(FormatCurrency(gCheck.rsStore.item("Total"), 2, TriState.True)))
            i = i + 1
        Next row

        'Nombre de vendedor multilinea
        i = 0
        For nCounter = 0 To nLines - 1
            'UPGRADE_ISSUE: Printer property 'Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.CurrentY = (7.2 + (nRate * i)) * 1440 '7.4
            'UPGRADE_ISSUE: Printer property 'Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.CurrentX = 0.1 * 1440
            ''Printer.FontBold = True
            'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: Printer method 'Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer.Print(gParse(nCounter))
            'Printer.FontBold = False
            i = i + 1
        Next nCounter

        'Stores
        'list_store 2, 60
        list_store2(sLinea, sCustName, sStoreArray, 2, 60)
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 9.68 * 1440 '9.68
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(1))

        'Printer.FontBold = True
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 6 * 1440
        'Printer.Print FormatCurrency(txtAmount, 2, vbTrue)
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(FormatCurrency(nCheckAmount, 2, TriState.True))


        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 9.83 * 1440 '9.83
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sLinea(2))
        '05.15.03
        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 9.98 * 1440
        'Printer.Print txtDetail1
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sDetail1)

        'UPGRADE_ISSUE: Printer property Printer.CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentX = 3 * 1440
        'UPGRADE_ISSUE: Printer property Printer.CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.CurrentY = 10.18 * 1440
        'Printer.Print txtDetail2
        'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: Printer method Printer.Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Print(sDetail2)

        'UPGRADE_ISSUE: Printer method Printer.EndDoc was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.EndDoc()
        Exit Sub

ErrorHandler:
        save_error("BankFunctions", "print_check5")
        MsgBox("An unexpected error has ocurred while generating check." & vbCrLf & "Please review log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.Exclamation, "GLM Error")
    End Sub

    'Extended from print_check_batch2
    'Changes:
    '05.17.06   Font changes: Incremented check number size, GLM address and bank address
    'Prints Batch Checks
    Public Sub print_check_batch3(ByRef sCustName As String, ByRef nCheckNo As Integer, ByRef sCheckDate As String, ByRef sVendName As String, ByRef nCheckAmount As Double, ByRef sAmountString As String, ByRef sVendPayAddress As String, ByRef sVendPayCity As String, ByRef sVendPayState As String, ByRef sVendPayZip As String, ByRef sDetail1 As String, ByRef sDetail2 As String, ByRef sBankAba As String, ByRef sBankAccount As String, ByRef sStoreArray As Object, ByRef sBankCheckInfo1 As String, ByRef sBankCheckInfo2 As String, ByRef sBankCheckInfo3 As String, ByRef sBankCheckInfo4 As String)

        Dim i As Short
        Dim nRate As Double
        Dim sAmount As Object
        Dim nLines As Short
        Dim nCounter As Short
        Dim sCheckNo As String 'Formatted Check
        Dim sMicrocode As String
        Dim sLinea(3) As String
        Dim logofile As Scripting.FileSystemObject
        logofile = New Scripting.FileSystemObject

        'Dim picLogo As PictureBox
        'Dim LogoImage As Picture
        'Set LogoImage = LoadPicture(gGlobSettings.sCheckLogoFile)
        'Set picLogo.Picture = LoadPicture(gGlobSettings.sCheckLogoFile)


        On Error GoTo ErrorHandler
        'print_check = True

        sCheckNo = format_check_number(nCheckNo)
        'Bank Header
        'UPGRADE_ISSUE: Constant vbPRPSLetter was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
        'UPGRADE_ISSUE: 'Printer. property 'Printer..PaperSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..PaperSize = vbPRPSLetter
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontName = "Arial Narrow" '"Times New Roman"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontSize = 8.5 '7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontBold = False

        'Image
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 0.85 * 1440 '0.95
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 0.14 * 1440 '0.24
        ''Printer..PaintPicture picLogo.Picture, 'Printer..CurrentX, 'Printer..CurrentY

        If Not logofile.FileExists(gGlobSettings.sCheckLogoFile) Then
            MsgBox("Could not find image Logo file:" & gGlobSettings.sCheckLogoFile, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Sub
        End If

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..PaintPicture(System.Drawing.Image.FromFile(gGlobSettings.sCheckLogoFile), 'Printer..CurrentX, 'Printer..CurrentY)

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 4.15 * 1440 '3.95
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 0.24 * 1440 '0.14
        ''Printer..Print "JPMORGAN CHASE BANK, N.A."
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print(sBankCheckInfo1)

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 4.15 * 1440 '4.25
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 0.37 * 1440 '0.34
        ''Printer..Print "P.O. BOX 2558"
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print(sBankCheckInfo2)

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 4.15 * 1440 '3.95
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 0.5 * 1440 '0.44
        ''Printer..Print "HOUSTON, TEXAS 77252"
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print(sBankCheckInfo3)

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 4.15 * 1440 '4.25
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 0.67 * 1440 '0.64
        ''Printer..Print "32-115/1110"
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print(sBankCheckInfo4)

        'GLM Header
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontName = "Arial Narrow" '"Times New Roman"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontSize = 11.5 '10
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontBold = True

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 1.95 * 1440 '3.75
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 0.34 * 1440 '0.24
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print("GLM DFW, INC.")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontName = "Arial Narrow" '"Times New Roman"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontSize = 8.5 '7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontBold = False

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 1.55 * 1440 '1.95
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 0.5 * 1440 '0.54
        ''Printer..Print "7225 SAGE MEADOW  PH. 972-702-6451"
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print("3113 BROKEN BOW WAY PH. 972-702-6451")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 1.95 * 1440 '3.75
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 0.65 * 1440 '0.6
        ''Printer..Print "PLANO, TEXAS 75024"
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print("PLANO, TEXAS 75093")

        'Printing settings
        ''Printer..PaperSize = vbPRPSLetter
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontName = "Arial" '"Times New Roman"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontSize = 13 '12


        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 7.38 * 1440 '6.82
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 0 * 1440 '0.21
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print(sCheckNo)


        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontName = "Times New Roman"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontSize = 12

        'Date
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 6.21 * 1440 '6.15
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 0.56 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print("DATE ")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 6.82 * 1440 '6.82
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 0.56 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontUnderline = True
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print(sCheckDate)
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontUnderline = False


        'Vendor
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontName = "Times New Roman"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontSize = 10

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 0.22 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 1.02 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print("Pay To The")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 0.22 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 1.21 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print("Order Of")



        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 1 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 1.1 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print(" ____________________________________________________________________________ $ _______________")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontName = "Times New Roman"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontSize = 12

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 1 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 1.06 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print(sVendName)

        'Check Amount
        'UPGRADE_WARNING: Couldn't resolve default property of object sAmount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        sAmount = FormatCurrency(nCheckAmount)
        'UPGRADE_WARNING: Couldn't resolve default property of object sAmount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        sAmount = "**" & Right(sAmount, Len(sAmount) - 1)

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 6.8 * 1440
        'UPGRADE_WARNING: Couldn't resolve default property of object sAmount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print(sAmount)

        'Amount String
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 0.22 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 1.49 * 1440 '1.58
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print("______________________________________________________________________________DOLLARS")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 0.22 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 1.41 * 1440 '1.51
        sAmountString = Trim(sAmountString) & "****************************"
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print(sAmountString)


        'Vendor Address
        ''Printer..FontSize = 11
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..FontSize = 10
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 0.7 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 1.9 * 1440 '1.75
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print(UCase(sVendName))
        'rel1.4---'Printer..CurrentY = 1.9 * 1440 ' 1.8
        'UPGRADE_ISSUE: 'Printer. property ''Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 0.7 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property ''Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 2.05 * 1440 ' 1.9
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method ''Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print(UCase(sVendPayAddress))


        'UPGRADE_ISSUE: 'Printer. property ''Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentX = 0.7 * 1440
        'UPGRADE_ISSUE: 'Printer. property ''Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..CurrentY = 2.2 * 1440 '2.05
        'rel1.4---
        sVendPayCity = Trim(sVendPayCity) & " - " & sVendPayState & " -" & sVendPayZip
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method ''Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''Printer..Print(UCase(sVendPayCity))

        ''Printer..CurrentX = 0.7 * 1440
        ''Printer..CurrentY = 2.2 * 1440  '2.1
        ''Printer..Print sVendZip

        'Store list
        'list_store 3, 30
        list_store2(sLinea, sCustName, sStoreArray, 3, 30)
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.22 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 2.5 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("MEMO:" & sLinea(1))

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.7 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 2.65 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sLinea(2))

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.7 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 2.8 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sLinea(3))

        'Signature

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 4.95 * 1440 '5.75
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 2.31 * 1440 '2.41
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("________________________________________")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "Times New Roman"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 6

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 6.75 * 1440 '6.25
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 2.49 * 1440 '2.59
        ''Printer..Print "AUTHORIZED SIGNATURE"
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("VOID AFTER 90 DAYS")

        ''Printer..CurrentX = 5.93 * 1440 '5.89
        ''Printer..CurrentY = 2.69 * 1440 '2.59
        ''Printer..Print "VOID AFTER 90 DAYS"

        'Microcode
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "MRV MICR"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 12

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 1.45 * 1440 '1.95
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 2.94 * 1440 '2.95, 2.99, 3.08

        sMicrocode = "C" & Trim(sCheckNo) & "C A" & Trim(sBankAba) & "A C" & Trim(sBankAccount) & "C"
        sMicrocode = "C" & Trim(sCheckNo) & "C A" & Trim(sBankAba) & "A" & Left(Trim(sBankAccount), 3) & " " & Mid(Trim(sBankAccount), 4, 2) & " " & Right(Trim(sBankAccount), 5) & "C"

        'sMicrocode = "A111993776A 4882133021C 0867"
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sMicrocode)
        ''Printer..Print "C005290C A111001150A C12607078264C"


        'Check Detail
        'DETAIL
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "Courier New" '01.09.04
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 9 '*************
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontBold = True

        '03.03.05
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 3.54 * 1440 '3.57
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("GLM DFW, INC.")

        'CheckNo
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "Arial" '"Courier New"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 13 '9
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontBold = False

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 7.38 * 1440 '7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 3.54 * 1440 '3.83
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sCheckNo)

        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "Courier New" '01.09.04
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 9 '*************
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontBold = True


        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 3.67 * 1440
        nLines = parse_string(sVendName, 18)
        If nLines > 0 Then
            ''Printer..Print gParse(1);
        Else
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(sVendName)
        End If

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 3.94 * 1440 '3.67
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 7.28 * 1440 '7.25
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sCheckDate)

        'mark1


        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontUnderline = True

        'TITLES
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 3.67 * 1440 '3.87
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 2 * 1440 '3
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Store")
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 3 * 1440 '4
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Account")
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 4.5 * 1440 '5
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Invoice")
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 6 * 1440 '6
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Amount")

        ''Printer..FontBold = False
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontUnderline = False

        'DATA
        nRate = 0.13 '0.15
        i = 0
        'namount = 1012.23

        nCounter = 0

        For row As Integer = 0 To gCheck.rsStore.Rows.Count - 1
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentY = (3.72 + (nRate * i)) * 1440 '3.92
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 2 * 1440 '3
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(gCheck.rsStore.item("Store"))
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 3 * 1440 '4
            '05.15.03 Mascara de cuenta
            ''Printer..Print gCheck.rsStore("Account");
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(gCheck.rsStore.item("account_mask"))
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 4.5 * 1440 '5
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(gCheck.rsStore.item("Invoice"))
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 5.7 * 1440 '6
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(format_qty(FormatCurrency(gCheck.rsStore.item("Total"), 2, TriState.True)))
            i = i + 1
        Next row


        'Multiline Vendor name
        i = 0
        For nCounter = 0 To nLines - 1
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentY = (3.72 + (nRate * i)) * 1440 '3.92
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 0.1 * 1440
            ''Printer..FontBold = True
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(gParse(nCounter))
            ''Printer..FontBold = False
            i = i + 1
        Next nCounter

        'List of stores
        'list_store2 sCustName, 2, 60
        list_store2(sLinea, sCustName, sStoreArray, 2, 60)
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 6.2 * 1440 '6.52
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sLinea(1))
        '---
        'Check Total
        ''Printer..FontBold = True
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 6 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(FormatCurrency(nCheckAmount, 2, TriState.True))
        ''Printer..FontBold = False

        'Second line of stores
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 6.35 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sLinea(2))

        '05.15.03
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 3 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 6.35 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sDetail1)

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 3 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 6.55 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sDetail2)


        'COPY *************************************

        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontBold = True

        '03.03.05
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 7.07 * 1440 '7.16
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("GLM DFW, INC.")


        'CheckNo
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "Arial" '"Courier New"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 13 '9
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontBold = False

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 7.38 * 1440 '7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 7.07 * 1440 '7.36
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sCheckNo)

        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "Courier New" '01.09.04
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 9 '*************
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontBold = True


        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 7.2 * 1440
        nLines = parse_string(sVendName, 18)
        If nLines > 0 Then
            ''Printer..Print gParse(1);
        Else
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(sVendName)
        End If

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 7.47 * 1440 '3.67
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 7.28 * 1440 '7.26
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sCheckDate)
        'mark2


        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontUnderline = True


        'TITLES
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 7.15 * 1440 '7.35
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 2 * 1440 '3
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Store")
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 3 * 1440 '4
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Account")
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 4.5 * 1440 '5
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Invoice")
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 6 * 1440 '3.7
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Amount")

        ''Printer..FontBold = False
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontUnderline = False


        i = 0
        'While gCheck.rsStore.Read()
        For row As Integer = 0 To gCheck.rsStore.Rows.Count - 1
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentY = (7.2 + (nRate * i)) * 1440 '7.4
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 2 * 1440 '3
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(gCheck.rsStore.item("Store"))
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 3 * 1440 '4
            '05.15.03 Mascara de Cuenta
            ''Printer..Print gCheck.rsStore("Account");
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(gCheck.rsStore.item("account_mask"))
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 4.5 * 1440 '5
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(gCheck.rsStore.item("Invoice"))
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 5.7 * 1440 '6
            ''Printer..Print FormatCurrency(gCheck.rsStore("Total"), 2, vbTrue)
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(format_qty(FormatCurrency(gCheck.rsStore.item("Total"), 2, TriState.True)))

            i = i + 1
        Next row

        'Multiline vendor name
        i = 0
        For nCounter = 0 To nLines - 1
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentY = (7.2 + (nRate * i)) * 1440 '7.4
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 0.1 * 1440
            ''Printer..FontBold = True
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(gParse(nCounter))
            ''Printer..FontBold = False
            i = i + 1
        Next nCounter

        'Stores
        'list_store 2, 60
        list_store2(sLinea, sCustName, sStoreArray, 2, 60)
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 9.68 * 1440 '9.68
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sLinea(1))

        ''Printer..FontBold = True
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 6 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(FormatCurrency(nCheckAmount, 2, TriState.True))
        ''Printer..FontBold = False

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 9.83 * 1440 '9.83
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sLinea(2))
        '05.15.03
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 3 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 9.98 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sDetail1)

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 3 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 10.18 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sDetail2)

        'UPGRADE_ISSUE: 'Printer. method 'Printer..EndDoc was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..EndDoc()
        Exit Sub

ErrorHandler:
        save_error("BankFunctions", "print_check_batch3")
        MsgBox("An unexpected error has ocurred while generating check." & vbCrLf & "Please review log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.Exclamation, "GLM Error")
    End Sub

    'Prints Batch Checks
    Public Sub print_check_batch2(ByRef sCustName As String, ByRef nCheckNo As Integer, ByRef sCheckDate As String, ByRef sVendName As String, ByRef nCheckAmount As Double, ByRef sAmountString As String, ByRef sVendPayAddress As String, ByRef sVendPayCity As String, ByRef sVendPayState As String, ByRef sVendPayZip As String, ByRef sDetail1 As String, ByRef sDetail2 As String, ByRef sBankAba As String, ByRef sBankAccount As String, ByRef sStoreArray As Object)

        Dim i As Short
        Dim nRate As Double
        Dim sAmount As Object
        Dim nLines As Short
        Dim nCounter As Short
        Dim sCheckNo As String 'Formatted Check
        Dim sMicrocode As String
        'UPGRADE_WARNING: Lower bound of array sLinea was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
        Dim sLinea(3) As String

        'Dim picLogo As PictureBox
        'Dim LogoImage As Picture
        'Set LogoImage = LoadPicture(gGlobSettings.sCheckLogoFile)
        'Set picLogo.Picture = LoadPicture(gGlobSettings.sCheckLogoFile)


        On Error GoTo ErrorHandler
        'print_check = True

        sCheckNo = format_check_number(nCheckNo)
        'Bank Header
        'UPGRADE_ISSUE: Constant vbPRPSLetter was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
        'UPGRADE_ISSUE: 'Printer. property 'Printer..PaperSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..PaperSize = vbPRPSLetter
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "Arial Narrow" '"Times New Roman"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 8.5 '7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontBold = False

        'Image
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.85 * 1440 '0.95
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 0.14 * 1440 '0.24
        ''Printer..PaintPicture picLogo.Picture, 'Printer..CurrentX, 'Printer..CurrentY
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..PaintPicture(System.Drawing.Image.FromFile(gGlobSettings.sCheckLogoFile), 'Printer..CurrentX, 'Printer..CurrentY)

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 4.15 * 1440 '3.95
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 0.24 * 1440 '0.14
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("JPMORGAN CHASE BANK, N.A.")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 4.45 * 1440 '4.25
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 0.37 * 1440 '0.34
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("P.O. BOX 2558")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 4.15 * 1440 '3.95
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 0.5 * 1440 '0.44
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("HOUSTON, TEXAS 77252")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 4.45 * 1440 '4.25
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 0.67 * 1440 '0.64
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("32-115/1110")

        'GLM Header
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "Arial Narrow" '"Times New Roman"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 11.5 '10
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontBold = True

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 1.95 * 1440 '3.75
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 0.34 * 1440 '0.24
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("GLM DFW, INC.")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "Arial Narrow" '"Times New Roman"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 8.5 '7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontBold = False

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 1.55 * 1440 '1.95
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 0.5 * 1440 '0.54
        ''Printer..Print "7225 SAGE MEADOW  PH. 972-702-6451"
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("3113 BROKEN BOW WAY PH. 972-702-6451")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 1.95 * 1440 '3.75
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 0.65 * 1440 '0.6
        ''Printer..Print "PLANO, TEXAS 75024"
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("PLANO, TEXAS 75093")

        'Printing settings
        ''Printer..PaperSize = vbPRPSLetter
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "Arial" '"Times New Roman"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 13 '12


        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 7.38 * 1440 '6.82
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 0 * 1440 '0.21
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sCheckNo)


        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "Times New Roman"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 12

        'Date
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 6.21 * 1440 '6.15
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 0.56 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("DATE ")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 6.82 * 1440 '6.82
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 0.56 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontUnderline = True
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sCheckDate)
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontUnderline = False


        'Vendor
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "Times New Roman"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 10

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.22 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 1.02 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Pay To The")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.22 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 1.21 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Order Of")



        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 1 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 1.1 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(" ____________________________________________________________________________ $ _______________")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "Times New Roman"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 12

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 1 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 1.06 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sVendName)

        'Check Amount
        'UPGRADE_WARNING: Couldn't resolve default property of object sAmount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        sAmount = FormatCurrency(nCheckAmount)
        'UPGRADE_WARNING: Couldn't resolve default property of object sAmount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        sAmount = "**" & Right(sAmount, Len(sAmount) - 1)

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 6.8 * 1440
        'UPGRADE_WARNING: Couldn't resolve default property of object sAmount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sAmount)

        'Amount String
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.22 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 1.49 * 1440 '1.58
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("______________________________________________________________________________DOLLARS")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.22 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 1.41 * 1440 '1.51
        sAmountString = Trim(sAmountString) & "****************************"
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sAmountString)


        'Vendor Address
        ''Printer..FontSize = 11
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 10
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.7 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 1.9 * 1440 '1.75
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(UCase(sVendName))
        'rel1.4---'Printer..CurrentY = 1.9 * 1440 ' 1.8
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.7 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 2.05 * 1440 ' 1.9
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(UCase(sVendPayAddress))


        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.7 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 2.2 * 1440 '2.05
        'rel1.4---
        sVendPayCity = Trim(sVendPayCity) & " - " & sVendPayState & " -" & sVendPayZip
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(UCase(sVendPayCity))

        ''Printer..CurrentX = 0.7 * 1440
        ''Printer..CurrentY = 2.2 * 1440  '2.1
        ''Printer..Print sVendZip

        'Store list
        'list_store 3, 30
        list_store2(sLinea, sCustName, sStoreArray, 3, 30)
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.22 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 2.5 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("MEMO:" & sLinea(1))

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.7 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 2.65 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sLinea(2))

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.7 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 2.8 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sLinea(3))

        'Signature

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 4.95 * 1440 '5.75
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 2.31 * 1440 '2.41
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("________________________________________")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "Times New Roman"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 6

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 5.85 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 2.49 * 1440 '2.59
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("AUTHORIZED SIGNATURE")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 5.93 * 1440 '5.89
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 2.69 * 1440 '2.59
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("VOID AFTER 90 DAYS")

        'Microcode
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "MRV MICR"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 12

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 1.45 * 1440 '1.95
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 2.94 * 1440 '2.95, 2.99, 3.08

        sMicrocode = "C" & Trim(sCheckNo) & "C A" & Trim(sBankAba) & "A C" & Trim(sBankAccount) & "C"
        'sMicrocode = "A111993776A 4882133021C 0867"
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sMicrocode)
        ''Printer..Print "C005290C A111001150A C12607078264C"


        'Check Detail
        'DETAIL
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "Courier New" '01.09.04
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 9 '*************
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontBold = True

        '03.03.05
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 3.54 * 1440 '3.57
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("GLM DFW, INC.")

        'CheckNo
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "Arial" '"Courier New"
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 13 '9
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontBold = False

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 7.38 * 1440 '7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 3.83 * 1440 '3.77
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sCheckNo)

        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontName = "Courier New" '01.09.04
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontSize was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontSize = 9 '*************
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontBold = True


        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 3.67 * 1440
        nLines = parse_string(sVendName, 18)
        If nLines > 0 Then
            ''Printer..Print gParse(1);
        Else
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(sVendName)
        End If

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 7 * 1440 '7
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sCheckDate)

        'mark1


        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontUnderline = True

        'TITLES
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 3.67 * 1440 '3.87
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 2 * 1440 '3
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Store")
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 3 * 1440 '4
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Account")
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 4.5 * 1440 '5
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Invoice")
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 6 * 1440 '6
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Amount")

        ''Printer..FontBold = False
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontUnderline = False

        'DATA
        nRate = 0.13 '0.15
        i = 0
        'namount = 1012.23

        nCounter = 0

        For row As Integer = 0 To gCheck.rsStore.Rows.Count - 1
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentY = (3.72 + (nRate * i)) * 1440 '3.92
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 2 * 1440 '3
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(gCheck.rsStore.item("Store"))
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 3 * 1440 '4
            '05.15.03 Mascara de cuenta
            ''Printer..Print gCheck.rsStore("Account");
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(gCheck.rsStore.item("account_mask"))
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 4.5 * 1440 '5
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(gCheck.rsStore.item("Invoice"))
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 5.7 * 1440 '6
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(format_qty(FormatCurrency(gCheck.rsStore.item("Total"), 2, TriState.True)))

            i = i + 1
        Next row


        'Multiline Vendor name
        i = 0
        For nCounter = 1 To nLines
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentY = (3.72 + (nRate * i)) * 1440 '3.92
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 0.1 * 1440
            ''Printer..FontBold = True
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(gParse(nCounter))
            ''Printer..FontBold = False
            i = i + 1
        Next nCounter

        'List of stores
        'list_store2 sCustName, 2, 60
        list_store2(sLinea, sCustName, sStoreArray, 2, 60)
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 6.2 * 1440 '6.52
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sLinea(1))
        '---
        'Check Total
        ''Printer..FontBold = True
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 6 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(FormatCurrency(nCheckAmount, 2, TriState.True))
        ''Printer..FontBold = False

        'Second line of stores
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 6.35 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sLinea(2))

        '05.15.03
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 3 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 6.35 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sDetail1)

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 3 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 6.55 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sDetail2)


        'COPY *************************************

        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontBold was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontBold = True

        '03.03.05
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 7.07 * 1440 '7.16
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("GLM DFW, INC.")

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 7.2 * 1440
        nLines = parse_string(sVendName, 18)
        If nLines > 0 Then
            ''Printer..Print gParse(1);
        Else
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(sVendName)
        End If
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 7 * 1440 '6
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sCheckDate)

        'CheckNo
        '03.03.05
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 7 * 1440 '7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 7.36 * 1440 '3.77
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sCheckNo)


        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontUnderline = True

        'TITLES
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 7.15 * 1440 '7.35
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 2 * 1440 '3
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Store")
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 3 * 1440 '4
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Account")
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 4.5 * 1440 '5
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Invoice")
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 6 * 1440 '3.7
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print("Amount")

        ''Printer..FontBold = False
        'UPGRADE_ISSUE: 'Printer. property 'Printer..FontUnderline was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..FontUnderline = False


        i = 0


        For row As Integer = 0 To gCheck.rsStore.Rows.Count - 1
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentY = (7.2 + (nRate * i)) * 1440 '7.4
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 2 * 1440 '3
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(gCheck.rsStore.item("Store"))
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 3 * 1440 '4
            '05.15.03 Mascara de Cuenta
            ''Printer..Print gCheck.rsStore("Account");
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(gCheck.rsStore.item("account_mask"))
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 4.5 * 1440 '5
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(gCheck.rsStore.item("Invoice"))
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 5.7 * 1440 '6
            ''Printer..Print FormatCurrency(gCheck.rsStore("Total"), 2, vbTrue)
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(format_qty(FormatCurrency(gCheck.rsStore.item("Total").Value, 2, TriState.True)))

            i = i + 1
        Next row

        'Multiline vendor name
        i = 0
        For nCounter = 1 To nLines
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentY = (7.2 + (nRate * i)) * 1440 '7.4
            'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..CurrentX = 0.1 * 1440
            ''Printer..FontBold = True
            'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Printer..Print(gParse(nCounter))
            ''Printer..FontBold = False
            i = i + 1
        Next nCounter

        'Stores
        'list_store 2, 60
        list_store2(sLinea, sCustName, sStoreArray, 2, 60)
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 9.68 * 1440 '9.68
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sLinea(1))

        ''Printer..FontBold = True
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 6 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(FormatCurrency(nCheckAmount, 2, TriState.True))
        ''Printer..FontBold = False

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 0.1 * 1440 '0.7
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 9.83 * 1440 '9.83
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sLinea(2))
        '05.15.03
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 3 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 9.98 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sDetail1)

        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentX was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentX = 3 * 1440
        'UPGRADE_ISSUE: 'Printer. property 'Printer..CurrentY was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..CurrentY = 10.18 * 1440
        'UPGRADE_ISSUE: 'Printer. object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'UPGRADE_ISSUE: 'Printer. method 'Printer..Print was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..Print(sDetail2)

        'UPGRADE_ISSUE: 'Printer. method 'Printer..EndDoc was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer..EndDoc()
        Exit Sub

ErrorHandler:
        save_error("BankFunctions", "print_check_batch2")
        MsgBox("An unexpected error has ocurred while generating check." & vbCrLf & "Please review log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.Exclamation, "GLM Error")
    End Sub


    'Permite seleccionar una impresora para imprimir
    Public Function find_printer2(ByRef bSelectPrinter As Boolean) As Boolean
        'No existen impresora definidas en esta maquina
        find_printer2 = True
        'UPGRADE_ISSUE: Printers method Printers.Count was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        If System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count <= 0 Then
            MsgBox("There are not printers defined in this computer." & vbCrLf & "Please set up a default printer before proceeding.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message")

            find_printer2 = False
            Exit Function
        End If

        If bSelectPrinter Then
            frmPrinter.ShowDialog()
            If gbPrinter Then
                find_printer2 = True
            Else
                find_printer2 = False
            End If
        End If
    End Function
    'Loads Vendor combo
    Public Sub load_vendor2(ByRef cb As System.Windows.Forms.ComboBox, ByRef sCustId As String)
        On Error GoTo ErrorHandler

        sStmt = " SELECT DISTINCT VBranch.vend_name," & " VBranch.vend_id " & " FROM VAccount, VBranch " & " WHERE VAccount.vend_seq = VBranch.vend_seq " & " AND VAccount.cust_id ='" & Trim(sCustId) & "' " & " ORDER BY VBranch.vend_name "

        load_cb_query2(cb, sStmt, 2, True)
        Exit Sub

ErrorHandler:
        save_error("BankFunctions", "load_vendor")
        MsgBox("Unable to load Vendor info. Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")

    End Sub
End Module