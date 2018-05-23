Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmPeriodEntry
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable
    Private cmLocal As SqlCommand
	
	'UPGRADE_WARNING: Event cbPeriodStatusDesc.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbPeriodStatusDesc_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriodStatusDesc.SelectedIndexChanged
		If cbPeriodStatusDesc.SelectedIndex >= 0 Then
			cbPeriodStatusId.SelectedIndex = cbPeriodStatusDesc.SelectedIndex
		End If
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		If save_period Then
			Me.Close()
		End If
	End Sub
    Private Function save_period() As Boolean
        Dim nPeriodSeq As Short
        Dim sVisibleFlag As String
        Dim nRecords As Short
        Dim bAccountManager As Boolean
        Dim sTypeId As String


        On Error GoTo ErrorHandler

        nRecords = 0
        save_period = False

        If val_fields() = False Then
            Exit Function
        End If

        Select Case gPeriodRecord.bMode
            Case General.modo.NewRecord
                'Verificar que clave no se repita
                sStmt = "SELECT * FROM period " & " WHERE cust_id = '" & gPeriodRecord.sCustId & "'" & " AND UPPER(RTRIM(period_name))='" & UCase(Trim(txtPeriodName.Text)) & "'"

                rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                If rsLocal.Rows.Count > 0 Then
                    MsgBox("There is already a Period with that name.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                    Exit Function
                End If


                'Insertar registro
                nPeriodSeq = get_period_seq()
                sVisibleFlag = "Y"

                sStmt = "INSERT INTO period ( period_seq," & "cust_id, period_name, period_start_date, " & "period_end_date, visible_flag, period_status_id) " & "VALUES (" & Str(nPeriodSeq) & "," & "'" & Trim(gPeriodRecord.sCustId) & "'," & "'" & quotation_mask(Trim(txtPeriodName.Text)) & "'," & "'" & CStr(dtStartDate.Value) & "'," & "'" & CStr(dtEndDate.Value) & "','" & sVisibleFlag & "'," & "'" & cbPeriodStatusId.Text & "' )"
                cmLocal = cn.CreateCommand
                With cmLocal
                    .CommandType = CommandType.Text
                    .CommandText = sStmt
                    nRecords = .ExecuteNonQuery()
                End With
                If nRecords > 0 Then
                    gPeriodRecord.nPeriodSeq = nPeriodSeq
                    gPeriodRecord.bMode = General.modo.SavedRecord
                    save_period = True
                    MsgBox("Period was successfuly inserted.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                End If

            Case General.modo.UpdateRecord


                'Verificar si usuario actualizo estado del periodo
                If cbPeriodStatusId.Text <> gPeriodRecord.sPeriodStatusId Then
                    'Solo Administrador o Account Manager pueden modificar el estado
                    sTypeId = get_user_type(gsUser)
                    bAccountManager = has_customer_access(gsUser, gPeriodRecord.sCustId)

                    If sTypeId = "A" Or (sTypeId = "C" And bAccountManager) Then

                        'If cbPeriodStatusId = "O"
                        If gPeriodRecord.sPeriodStatusId = "C" Then
                            'Usuario esta cambiando de Closed a New , Open
                            If sTypeId <> "A" Then
                                MsgBox("Just an Administrator can reopen Period.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                                Exit Function
                            End If

                        End If
                    Else
                        MsgBox("You do not have enough privileges " & "to update Period Status.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Warning")
                        Exit Function
                    End If
                End If

                If invoice_assigned(gPeriodRecord.sCustId, gPeriodRecord.nPeriodSeq) > 0 Then
                    'Start-End Date no se pueden modificar cuando existen facturas
                    sStmt = "UPDATE period " & " SET period_status_id = '" & cbPeriodStatusId.Text & "'" & " WHERE period_seq=" & Str(gPeriodRecord.nPeriodSeq)
                Else
                    sStmt = "UPDATE period " & " SET period_start_date='" & CStr(dtStartDate.Value) & "'," & " period_end_date ='" & CStr(dtEndDate.Value) & "'," & " period_status_id = '" & cbPeriodStatusId.Text & "'" & " WHERE period_seq=" & Str(gPeriodRecord.nPeriodSeq)
                End If
                cmLocal = cn.CreateCommand
                With cmLocal
                    .CommandType = CommandType.Text
                    .CommandText = sStmt
                    nRecords = .ExecuteNonQuery()
                End With

                If nRecords > 0 Then
                    gPeriodRecord.bMode = General.modo.SavedRecord
                    save_period = True
                    MsgBox("Period was successfuly updated.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                End If
        End Select
        Exit Function

ErrorHandler:
        save_period = False
        save_error(Me.Name, "save_period")
        MsgBox("An error occurred while inserting/updating Period. Check log file for details.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
    End Function
	'Valida datos antes de insertar/actualizar
	Private Function val_fields() As Boolean
		gDump.str1 = ""
		gDump.str2 = ""
		
		On Error GoTo ErrorHandler
		val_fields = True
		
		'Period Name
		If Len(txtPeriodName.Text) = 0 Then
			MsgBox("Period Name should not be null.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
			txtPeriodName.Focus()
			val_fields = False
			Exit Function
		End If
		
        If dtStartDate.Value >= dtEndDate.Value Then
            MsgBox("Invalid Period was entered. Start date should be less than End date", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
            val_fields = False
            Exit Function
        End If
		
		'Dates: Solapamiento de fechas
        gDump = overlap_date(gPeriodRecord.sCustId, dtStartDate.Value, gPeriodRecord.bMode, gPeriodRecord.nPeriodSeq)
		If gDump.str1 = "TRUE" Then
			MsgBox("Found that Start Date overlaps period:" & gDump.str2, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
			dtStartDate.Focus()
			val_fields = False
			Exit Function
		End If
		
        gDump = overlap_date(gPeriodRecord.sCustId, dtEndDate.Value, gPeriodRecord.bMode, gPeriodRecord.nPeriodSeq)
		If gDump.str1 = "TRUE" Then
			MsgBox("Found that End Date overlaps period:" & gDump.str2, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "GLM Message")
			dtEndDate.Focus()
			val_fields = False
			Exit Function
		End If
		
        If overlap_period(gPeriodRecord.sCustId, dtStartDate.Value, dtEndDate.Value) Then
            MsgBox("Period entered overlaps one or more existing periods.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
            val_fields = False
            Exit Function
        End If
		
		Exit Function
		
ErrorHandler: 
		val_fields = False
		save_error(Me.Name, "val_fields")
		MsgBox("Error found while verifying Period record. Please check log file for details", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Function
	'Verifica que una fecha no se overlape con otro periodo
	'sCustId : Cliente cuyo period se esta chequeando
	'sDate : Fecha a verificar si no se solapa con otro periodo
	'Soption : UpdateRecord o NewRecord
	'nPeriodSeq: Opcional. Se usa cuando se invoca con modo.UpdateRecord
	'Valores de Retorno
	'gDump.str1 = TRUE  si solapa
	'gDump.str2 = "Period Name" nombre periodo que solapa
	Private Function overlap_date(ByRef sCustId As String, ByRef sDate As Date, ByRef sOption As General.modo, Optional ByRef nPeriodSeq As Short = 0) As gDumpUDT
        overlap_date = New gDumpUDT
		On Error GoTo ErrorHandler
		
		sStmt = "SELECT period_name FROM period " & " WHERE cust_id = '" & Trim(sCustId) & "'" & " AND period_start_date <= '" & CStr(sDate) & "'" & " AND period_end_date >= '" & CStr(sDate) & "'"
		
		If sOption = General.modo.UpdateRecord Then
            If IsDBNull(nPeriodSeq) Then
                overlap_date.str1 = "TRUE"
                Exit Function
            End If
			sStmt = sStmt & " AND period_seq <> " & Str(nPeriodSeq)
		End If
		
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count > 0 Then
            overlap_date.str1 = "TRUE"
            overlap_date.str2 = rsLocal.Rows(0).Item("period_name")
            Exit Function
        End If

        overlap_date.str1 = "FALSE"
        overlap_date.str2 = ""
        Exit Function

ErrorHandler:
        overlap_date.str1 = "FALSE"
        overlap_date.str2 = ""
        save_error(Me.Name, "overlap_date")
        MsgBox("Failed to check Date Overlapping. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
	End Function
	'Determina si el periodo ingresado solalpa uno o mas grupos de periodos
	Private Function overlap_period(ByRef sCustId As String, ByRef dStart As Date, ByRef dEnd As Date) As Boolean
		
		On Error GoTo ErrorHandler
		sStmt = "SELECT  MIN(period_start_date) minimus, " & "   MAX(period_end_date) maximus " & " FROM period " & " WHERE cust_id ='" & Trim(sCustId) & "'"
		
        rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsLocal.Rows.Count > 0 Then
            If dStart < rsLocal.Rows(0).Item("minimus") And dEnd > rsLocal.Rows(0).Item("maximus") Then
                overlap_period = True
                Exit Function
            End If
        End If

        overlap_period = False
        Exit Function

ErrorHandler:
        overlap_period = True
        save_error(Me.Name, "overlap_period")
        MsgBox("Failed to check Date Period Overlapping. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
		
	End Function
	'Obtiene la secuencia del periodo
	Private Function get_period_seq() As Short
		
		Dim nPeriodSeq As Short
		

		nPeriodSeq = -1
		sStmt = "SELECT MAX(period_seq) FROM period "
		
        Try
            rsLocal = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rsLocal.Rows(0).Item(0)) Then
                nPeriodSeq = 1
            Else
                nPeriodSeq = rsLocal.Rows(0).Item(0) + 1
            End If
            
            get_period_seq = nPeriodSeq
            Exit Function
        Catch ex As Exception
            MsgBox("There was an error when accesing Period Table.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
            MsgBox("An error occurred while getting Period Id. Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            save_error(Me.Name, "get_period_seq")
        End Try
        
		


		
	End Function
	Private Sub frmPeriodEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		set_limit()
		init_vars(gPeriodRecord.bMode)
	End Sub
	Private Sub set_limit()
		Dim nLen As Short
		
		nLen = get_column("period", "period_name")
		If nLen > 0 Then
            txtPeriodName.MaxLength = nLen
		Else
            txtPeriodName.MaxLength = 40
		End If
		
	End Sub
	
	Private Sub init_vars(ByRef nOption As General.modo)
        rsLocal = Nothing
        cmLocal = cn.CreateCommand
		
		cbPeriodStatusId.Visible = False
		
		'Customer
		txtCustName.Text = gPeriodRecord.sCustName
		txtCustName.Enabled = False
		
		'cbPeriodStatusId
		sStmt = "SELECT period_status_desc, period_status_id " & " FROM PeriodStatus " & " ORDER BY period_status_desc DESC"
		load_cb_query2(cbPeriodStatusDesc, sStmt, 1, True)
		
		sStmt = "SELECT period_status_id, period_status_desc " & " FROM PeriodStatus " & " ORDER BY period_status_desc DESC"
		load_cb_query2(cbPeriodStatusId, sStmt, 1, True)
		
		Select Case nOption
			Case General.modo.NewRecord
                'Defaults
                txtPeriodName.Text = ""
                txtPeriodName.Enabled = True

                dtStartDate.Value = Today
                dtEndDate.Value = Today

                dtStartDate.Enabled = True
                dtEndDate.Enabled = True

				If cbPeriodStatusDesc.Items.Count > 0 Then
					set_cb(cbPeriodStatusDesc, "New")
					'cbPeriodStatusDesc.ListIndex = 0
				End If
				
				
			Case General.modo.UpdateRecord
				txtPeriodName.Text = gPeriodRecord.sPeriodName
				txtPeriodName.Enabled = False
				
				dtStartDate.Value = gPeriodRecord.sPeriodStartDate
				dtEndDate.Value = gPeriodRecord.sPeriodEndDate
				
				set_cb(cbPeriodStatusDesc, gPeriodRecord.sPeriodStatusDesc)
				
				If invoice_assigned(gPeriodRecord.sCustId, gPeriodRecord.nPeriodSeq) > 0 Then
					'There are invoices using this period.
					'cmdOk.Enabled = False
					dtStartDate.Enabled = False
					dtEndDate.Enabled = False
				End If
				
		End Select
	End Sub
End Class