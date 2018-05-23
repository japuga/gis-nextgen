Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmCustFee
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private rsFee As DataTable
    Private cmLocal As SqlCommand

    Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
        cbCustId.SelectedIndex = cbCustName.SelectedIndex
        load_dgFee()


    End Sub
	Private Sub load_dgFee()
		On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand()
		sStmt = "SELECT FeeType.fee_desc AS 'Desc', " & " fee.fee_value AS 'Value', " & " dbo.CONVERT_BOOL(fee.active_flag) AS Active, " & " fee.fee_id, fee.cust_id , FeeType.fee_type_id " & " FROM fee, feeType " & " WHERE fee.fee_type_id = FeeType.fee_type_id " & " AND cust_id ='" & Trim(cbCustId.Text) & "'"
        cmd.CommandText = sStmt
		
        rsFee = getDataTable(sStmt) 'md.ExecuteReader()
        'If rsFee.Rows.Count > 0 Then
        dgFee.DataSource = rsFee
        'End If

        'Formato
        dgFee.Columns("fee_id").Visible = False
        dgFee.Columns("cust_id").Visible = False
        dgFee.Columns("fee_type_id").Visible = False
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "load_dgFee")
        MsgBox("An error found while loading fee info." & "Check log file for details.")
		
	End Sub
	
    Private Sub dgFee_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        update_fee()
    End Sub
	
	Private Sub frmCustFee_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
    Private Function init_vars() As Boolean

        clear_record()

        'rsLocal = New SqlDataReader(
        'rsFee = New SqlDataReader
        'cmLocal = cn.CreateCommand()


        'Customer
        '1.8.8 Solo mostrar clientes donde usuario
        'tiene permisos(estados)
        'sStmt = "SELECT cust_name, cust_id FROM customer " + _
        '" ORDER BY cust_id"
        sStmt = "SELECT cust_name, cust_id FROM customer " & " WHERE cust_id IN (SELECT DISTINCT cust_id " & "   FROM suser_data " & "   WHERE suser_name='" & Trim(gsUser) & "')" & " ORDER BY cust_id"
        load_cb_query2(cbCustName, sStmt, 1, True)

        sStmt = "SELECT cust_id FROM customer " & " WHERE cust_id IN (SELECT DISTINCT cust_id " & "   FROM suser_data " & "   WHERE suser_name='" & Trim(gsUser) & "')" & " ORDER BY cust_id"
        load_cb_query2(cbCustId, sStmt, 1, True)

        'Defaults
        If cbCustName.Items.Count > 0 Then
            cbCustName.SelectedIndex = 0

        End If

        Return False
    End Function
	
	Private Sub clear_record()
		gCustFeeRecord.nFeeTypeId = -1
		gCustFeeRecord.nFeeValue = -1
		gCustFeeRecord.sCustId = ""
		gCustFeeRecord.sFeeDesc = ""
	End Sub
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button4.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)

        Select Case Button.Name
            Case "new"
                If count_to_insert() > 0 Then
                    gCustFeeRecord.bFlag = General.modo.NewRecord
                    set_fee_record((General.modo.NewRecord))

                    VB6.ShowForm(frmCustFeeEntry, VB6.FormShowConstants.Modal, Me)
                    If gCustFeeRecord.bFlag = General.modo.SavedRecord Then
                        'refrescar
                        load_dgFee()
                    End If
                Else
                    MsgBox("All the available Fees are yet assigned " & " to this customer.", MsgBoxStyle.OkOnly, "GLM Message")
                End If
            Case "save"
                update_fee()

            Case "delete"
                If delete_fee() Then
                    load_dgFee()
                End If
            Case "exit"
                Me.Close()
        End Select

    End Sub
	Private Function count_to_insert() As Short
		On Error GoTo ErrorHandler
		
		sStmt = "SELECT fee_desc, fee_type_id " & " FROM FeeType " & " WHERE fee_type_id NOT IN (SELECT fee_type_id " & "    FROM fee " & "    WHERE cust_id = '" & cbCustId.Text & "')"
        Dim cmd As SqlCommand = cn.CreateCommand()

        count_to_insert = 0
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader()
        If rsLocal.Rows.Count > 0 Then
            For i As Integer = 0 To rsLocal.Rows.Count
                'While (rsLocal.Read())
                count_to_insert += 1
                'End While
            Next i
        Else
            count_to_insert = 0
        End If
		Exit Function
		
ErrorHandler: 
		count_to_insert = 0
		save_error(Me.Name, "count_to_insert")
		MsgBox("Failed to count Fee Type available to insert." & vbCrLf & "Check log file for details.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
	End Function
	Private Sub set_fee_record(ByRef bFlag As General.modo)
		gCustFeeRecord.sCustId = cbCustId.Text
		Select Case bFlag
			Case General.modo.NewRecord
				gCustFeeRecord.nFeeValue = 0
			Case General.modo.UpdateRecord
                If dgFee.SelectedRows.Count > 0 Then
                    gCustFeeRecord.nFeeValue = CDbl(dgFee.CurrentRow.Cells("Value").Value)
                    gCustFeeRecord.sFeeDesc = dgFee.CurrentRow.Cells("Desc").Value
                    gCustFeeRecord.nFeeTypeId = CShort(dgFee.CurrentRow.Cells("fee_type_id").Value)
                    gCustFeeRecord.nFeeId = CShort(dgFee.CurrentRow.Cells("fee_id").Value)
                    gCustFeeRecord.sFeeActive = dgFee.CurrentRow.Cells("Active").Value

                Else
                    MsgBox(" You must select a record to update.")
                    Exit Sub
                End If
		End Select
		
	End Sub
	Private Sub update_fee()
		gCustFeeRecord.bFlag = General.modo.UpdateRecord
        set_fee_record((General.modo.UpdateRecord))
        If dgFee.SelectedRows.Count > 0 Then
            VB6.ShowForm(frmCustFeeEntry, VB6.FormShowConstants.Modal, Me)
            If gCustFeeRecord.bFlag = General.modo.SavedRecord Then
                load_dgFee()
            End If
        Else
            MsgBox(" You must select a record to update.")
            Exit Sub
        End If
    End Sub
	Private Function delete_fee() As Boolean
		Dim nRecords As Short
        Dim nTran As SqlTransaction
		Dim nDetailCount As Short
        Dim cmd As SqlCommand = cn.CreateCommand()
        Dim nNumFeeServices As Integer = 0
		delete_fee = False
		nRecords = 0

        nTran = cn.BeginTransaction()
        Try
            If dgFee.SelectedRows.Count = 0 Then
                MsgBox("You must select a row before atempting this command.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Warning")
                delete_fee = False
                Exit Function
            End If

            If MsgBox("Do you want to delete this record.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "GLM Message") = MsgBoxResult.Yes Then


                'Borrar detalles primero
                sStmt = "SELECT fee_id FROM FeeService " & " WHERE fee_id =" & Str(CDbl(dgFee.CurrentRow.Cells("fee_id").Value))
                cmd.CommandText = sStmt
                rsLocal = getDataTable(sStmt, nTran) 'cmd.ExecuteReader()
                nNumFeeServices = rsLocal.Rows.Count

                sStmt = "DELETE FROM FeeService " & " WHERE fee_id =" & Str(CDbl(dgFee.CurrentRow.Cells("fee_id").Value))
                cmLocal = cn.CreateCommand
                cmLocal.CommandText = sStmt
                cmLocal.Transaction = nTran
                nRecords = cmLocal.ExecuteNonQuery()

                If nRecords <> nDetailCount Then
                    nTran.Rollback()
                    MsgBox("Failed to delete Fee Details." & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                    Exit Function
                End If

                'Header
                sStmt = "DELETE FROM Fee " & "WHERE fee_id =" & Str(CDbl(dgFee.CurrentRow.Cells("fee_id").Value))
                cmLocal = cn.CreateCommand
                cmLocal.Transaction = nTran
                cmLocal.CommandText = sStmt
                nRecords = cmLocal.ExecuteNonQuery()
                If (nRecords > 0) Or (nNumFeeServices = 0 And nRecords = 0) Then
                    'ok
                    nTran.Commit()
                    delete_fee = True
                Else
                    nTran.Rollback()

                    MsgBox("Failed to delete record." & vbCrLf & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                    delete_fee = False
                    Exit Function
                End If
            End If
            Exit Function

        Catch ex As Exception

            nTran.Rollback()

            save_error(Me.Name, "delete_fee")
            MsgBox("Unexpected error while deleting from Fee table." & vbCrLf & "Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
        End Try
    End Function

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        If count_to_insert() > 0 Then
            gCustFeeRecord.bFlag = General.modo.NewRecord
            set_fee_record((General.modo.NewRecord))

            VB6.ShowForm(frmCustFeeEntry, VB6.FormShowConstants.Modal, Me)
            If gCustFeeRecord.bFlag = General.modo.SavedRecord Then
                'refrescar
                load_dgFee()
            End If
        End If
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        update_fee()
    End Sub

    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        If delete_fee() Then
            load_dgFee()
        End If
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub
End Class