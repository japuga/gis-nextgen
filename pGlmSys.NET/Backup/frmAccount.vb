Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmAccount
	Inherits System.Windows.Forms.Form
    Private rsLocal As DataTable

	
    Private Sub cbAccount_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbAccount.SelectedIndexChanged
        Dim cmd As SqlCommand = cn.CreateCommand()
        If cbAccount.SelectedIndex >= 0 Then
            cbAccountNo.SelectedIndex = cbAccount.SelectedIndex
        End If
        'Determino el status para la cuenta seleccionada
        sStmt = "SELECT account_status FROM VAccountEqpt " & "WHERE cust_id='" & gStoreEqptRecord.sCustId & "' " & "AND store_id =" & Str(gStoreEqptRecord.nStoreId) & " " & "AND account_no='" & Trim(cbAccount.Text) & "' " & "AND vend_seq =" & Str(gVendorSearch.nVendSeq) & " " & "AND eqpt_seq =" & Str(gStoreEqptRecord.nEqptSeq) & " "
        cmd.CommandText = sStmt

        Try
            rsLocal = getDataTable(sStmt) ' cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If rsLocal.Rows.Count > 0 Then
                If Trim(rsLocal.Rows(0).Item("account_status")) = "A" Then
                    cbStatus.SelectedIndex = 0
                Else
                    cbStatus.SelectedIndex = 1
                End If
            End If
        Catch e As Exception
            MsgBox("Error while accesing Account info.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
            Exit Sub
        End Try

        'NEW ACCOUNT
        'Si selecciona <New> llamo a frmAccountEntry
        If cbAccount.Text = "<New>" Then
            gAccountRecord.bFlag = General.modo.NewRecord
            set_account()
            VB6.ShowForm(frmAccountEntry, VB6.FormShowConstants.Modal, Me)
            If gAccountRecord.bFlag = General.modo.SavedRecord Then
                set_cb_account(gVendorSearch.nVendSeq)
                set_cb(cbAccount, gAccountRecord.sAccountMask)
            End If
        End If
    End Sub
	'Para insertar nueva cuenta
	Private Sub set_account()
		
		gAccountRecord.sCustId = gAccountEqptRecord.sCustId
		gAccountRecord.nStoreId = gAccountEqptRecord.nStoreId
		gAccountRecord.sStoreNumber = gStoreEqptRecord.sStoreNumber
		gAccountRecord.nVendSeq = gVendorSearch.nVendSeq
		gAccountRecord.sVendName = gVendorSearch.sVendName
	End Sub
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		save_accountEqpt()
	End Sub
	'Inserta en AccountEqpt
	Private Sub save_accountEqpt()
		Dim nCount As Short
		Dim sStatus As String
		Dim sEqptDesc As String
        Dim cmLocal As SqlCommand = cn.CreateCommand()
		If Not val_fields Then
			Exit Sub
		End If
		
		If cbStatus.Text = "Active" Then
			sStatus = "A"
		Else
			sStatus = "I"
		End If
		
		Select Case General.gbAccountEqptMode
			Case General.modo.NewRecord
				
				
				'Verifico si cuenta fue asignada anteriormente a esta tienda/eqpt
				If prev_assigned Then
					MsgBox("This account has already been assigned " & "to this equipment. " & vbCrLf & "Please choose or create other account.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
					
					Exit Sub
				End If
				
				'Verifico si mas de una cuenta del mismo Vendor esta asignada
				' y Activa para este equipo-tienda
				If cbStatus.Text = "Active" And num_active_account > 1 Then
					MsgBox("Just one Active account per Vendor " & vbCrLf & "must be assigned to this equipment.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
					Exit Sub
				End If
				
				'Alerto al usuario que esta cuenta sera Inactiva
				If cbStatus.Text = "Inactive" Then
					If (MsgBox("Do you want to assign this account as Inactive?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "GLM Message") = MsgBoxResult.Yes) Then
						'Continua con insercion
					Else
						Exit Sub
					End If
				End If
				
				'Verifico si cuenta ha sido asignada a otro equipo en esta tienda
				sEqptDesc = ""
				sEqptDesc = eqpt_assigned
				If Len(sEqptDesc) > 0 Then
					If (MsgBox("Found that equipment " & Trim(sEqptDesc) & " has this account assigned to it." & vbCrLf & "Do you still want to continue ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "GLM Warning") = MsgBoxResult.No) Then
						Exit Sub
					End If
				End If
				
				
				sStmt = "INSERT INTO VAccountEqpt (cust_id , " & " store_id, account_no, vend_seq, " & " eqpt_seq, account_status) " & " VALUES ('" & gAccountEqptRecord.sCustId & "'," & Str(gAccountEqptRecord.nStoreId) & "," & "'" & Trim(cbAccountNo.Text) & "'," & Str(gVendorSearch.nVendSeq) & "," & Str(gAccountEqptRecord.nEqptSeq) & "," & "'" & sStatus & "')"
				
				'MsgBox sStmt
				cmLocal.CommandText = sStmt
                nCount = cmLocal.ExecuteNonQuery()
				If nCount > 0 Then
					MsgBox("Account  " & Trim(cbAccount.Text) & " has successfully " & vbCrLf & "been assigned to equipment " & Trim(gStoreEqptRecord.sEqptDesc) & " at Store" & Trim(gStoreEqptRecord.sStoreNumber))
				End If
				
				
			Case General.modo.UpdateRecord
				If cbStatus.Text = "Active" And num_active_account >= 1 Then
					MsgBox("Just one Active account per Vendor " & vbCrLf & "must be assigned to this equipment.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
					Exit Sub
				End If
				sStmt = "UPDATE VaccountEqpt SET " & " account_status = '" & sStatus & "' " & " WHERE cust_id= '" & gAccountEqptRecord.sCustId & "' " & " AND store_id = " & Str(gAccountEqptRecord.nStoreId) & " AND vend_seq = " & Str(gAccountEqptRecord.nVendSeq) & " AND eqpt_seq = " & Str(gAccountEqptRecord.nEqptSeq) & " AND account_no = '" & Trim(cbAccountNo.Text) & "' "
				'MsgBox sStmt
				cmLocal.CommandText = sStmt
                nCount = cmLocal.ExecuteNonQuery()
				If nCount > 0 Then
					MsgBox("Account  " & Trim(cbAccount.Text) & " was succesfully " & vbCrLf & "updated. ")
				End If
		End Select
		
		Me.Close()
	End Sub
	'Verifica que existan datos para insertar
	Private Function val_fields() As Boolean
		'Vendor
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(txtVendName.Text) Or Len(txtVendName.Text) = 0 Then
			MsgBox("Please choose a Vendor.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
			cmdSearch.Focus()
			val_fields = False
			Exit Function
		End If
		
		'Account
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(cbAccount.Text) Or Len(cbAccount.Text) = 0 Then
			MsgBox("Please choose or create an Account to assign.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
			cbAccount.Focus()
			val_fields = False
			Exit Function
		End If
		
		If cbStatus.SelectedIndex < 0 Then
			MsgBox("Please set this account as Active or Inactive.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "GLM Warning")
			cbStatus.Focus()
			val_fields = False
			Exit Function
		End If
		val_fields = True
	End Function
	'Chequea que una cuenta no este en la tabla accountEqpt
	'antes de insertarla
	Private Function prev_assigned() As Boolean
		
        'On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand()
		sStmt = "SELECT count(*) FROM VAccountEqpt " & " WHERE cust_id ='" & gAccountEqptRecord.sCustId & "' " & " AND store_id = " & Str(gAccountEqptRecord.nStoreId) & " AND account_no = '" & Trim(cbAccountNo.Text) & "' " & " AND vend_seq = " & Str(gVendorSearch.nVendSeq) & " AND eqpt_seq = " & Str(gAccountEqptRecord.nEqptSeq)
        cmd.CommandText = sStmt
		
		'MsgBox sStmt
		
        rsLocal = getDataTable(sStmt) ' cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        Try
            If rsLocal.Rows.Count > 0 Then
                If rsLocal.Rows(0).Item(0) > 0 Then
                    prev_assigned = True
                Else
                    prev_assigned = False
                End If
            Else
                prev_assigned = False
            End If
        Catch e As Exception
            MsgBox("Unable to verify if account was previously assigned?", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Warning")
            Exit Function
        End Try
        Exit Function
ErrorHandler:
        save_error("frmAccount", "prev_assigned")
        MsgBox("Failed to verify Account Assignments." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")


    End Function
	
	'Cuenta el numero de cuentas asignadas a este equipo-tienda  con este vendor
	Private Function num_active_account() As Short
		Dim nVendSeq As Short
        Dim cmd As SqlCommand = cn.CreateCommand()
		On Error GoTo ErrorHandler
		
		Select Case General.gbAccountEqptMode
			Case General.modo.NewRecord
				nVendSeq = gVendorSearch.nVendSeq
			Case General.modo.UpdateRecord
				nVendSeq = gAccountEqptRecord.nVendSeq
			Case Else
				num_active_account = -1
				Exit Function
		End Select
		
		
		sStmt = "SELECT count(*) FROM VAccountEqpt " & " WHERE VAccountEqpt.cust_id = '" & gAccountEqptRecord.sCustId & "' " & " AND VAccountEqpt.store_id = " & Str(gAccountEqptRecord.nStoreId) & " AND VAccountEqpt.eqpt_seq = " & Str(gAccountEqptRecord.nEqptSeq) & " " & " AND VAccountEqpt.vend_seq = " & Str(nVendSeq) & " AND VAccountEqpt.account_status = 'A' "
        cmd.CommandText = sStmt
		'MsgBox sStmt
        rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rsLocal.Rows.Count > 0 Then
            num_active_account = rsLocal.Rows(0).Item(0)
            Exit Function
        End If
		
		Exit Function
		
ErrorHandler: 
		num_active_account = 1
		save_error(Me.Name, "num_active_account")
		Resume Next
		
	End Function
	'Busca por otros equipos en esta misma tienda
	'que tengan asignada esta cuenta
	Private Function eqpt_assigned() As String
        Dim cmd As SqlCommand = cn.CreateCommand()

		sStmt = "SELECT storeEqpt.eqpt_desc " & "FROM storeEqpt, VAccountEqpt " & " WHERE storeEqpt.cust_id = VAccountEqpt.cust_id " & " AND storeEqpt.store_id = VAccountEqpt.store_id " & " AND storeEqpt.eqpt_seq = VAccountEqpt.eqpt_seq " & " AND VAccountEqpt.cust_id = '" & gAccountEqptRecord.sCustId & "' " & " AND VAccountEqpt.store_id = " & Str(gAccountEqptRecord.nStoreId) & " AND VAccountEqpt.account_no = '" & Trim(cbAccountNo.Text) & "' " & " AND VAccountEqpt.vend_seq =" & Str(gVendorSearch.nVendSeq)
        cmd.CommandText = sStmt
		
        Try
            rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rsLocal.Rows.Count > 0 Then
                eqpt_assigned = rsLocal.Rows(0).Item("eqpt_desc")
                Exit Function
            Else
                eqpt_assigned = ""
            End If
        Catch e As Exception
            MsgBox("Unable to check for account in other equipments.", MsgBoxStyle.OkOnly, "GLM Warning")
            eqpt_assigned = ""
            Exit Function
        End Try
        Exit Function

ErrorHandler:
        eqpt_assigned = ""
        save_error(Me.Name, "eqpt_assigned")

    End Function
	
	Private Sub cmdSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSearch.Click
		
		
		VB6.ShowForm(frmVendorBrowse, VB6.FormShowConstants.Modal, Me)
		If gVendorSearch.bFlag Then
			txtVendName.Text = gVendorSearch.sVendName
		End If
	End Sub
	
	'UPGRADE_WARNING: Form event frmAccount.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub frmAccount_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		If General.gbAccountEqptMode = General.modo.NewRecord Then
			cmdSearch.Focus()
		End If
	End Sub
	
	Private Sub frmAccount_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars(General.gbAccountEqptMode)
	End Sub
	Private Sub init_vars(ByRef bFlag As General.modo)
        'Dim cmd As SqlCommand = cn.CreateCommand()


		
        'With cmLocal
        '	.let_ActiveConnection(cn)
        '	.CommandType = ADODB.CommandTypeEnum.adCmdText
        'End With
		
		gVendorSearch.bFlag = False
		
		'Combo Status
		cbStatus.Items.Insert(0, "Active")
		cbStatus.Items.Insert(1, "Inactive")
		
		
		
		Select Case bFlag
			Case General.modo.NewRecord
				cbStatus.SelectedIndex = 0 'Active
			Case General.modo.UpdateRecord
				'Cargo componentes con datos del datagrid
				txtVendName.Text = gAccountEqptRecord.sVendor
				cbAccount.Items.Insert(0, Trim(gAccountEqptRecord.sAccountMask))
				cbAccountNo.Items.Insert(0, Trim(gAccountEqptRecord.sAccountNo))
				cbAccount.SelectedIndex = 0
				If Trim(gAccountEqptRecord.sAccountStatus) = "A" Then
					cbStatus.SelectedIndex = 0 'Active
				Else
					cbStatus.SelectedIndex = 1 'Inactive
				End If
				
				cmdSearch.Enabled = False
		End Select
		
	End Sub
	
	'UPGRADE_WARNING: Event txtVendName.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtVendName_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtVendName.TextChanged
		If gVendorSearch.bFlag Then
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(txtVendName.Text) Then
				set_cb_account(gVendorSearch.nVendSeq)
			End If
		End If
	End Sub
	'Muestra el listado de Accounts para este vendor
    Private Sub set_cb_account(ByRef nVendSeq As Short)
        Dim dt As DataTable
        Dim cmd As SqlCommand = cn.CreateCommand()
        'Los parametros de CustId y StoreId se toman de la forma
        'frmStoreEqpt , si se esta invocando esta funcion
        'sin llamar previamente frmStoreEqpt se deben proporcionar dichos val
        sStmt = "SELECT account_no, account_mask FROM VAccount " & "WHERE cust_id='" & gStoreEqptRecord.sCustId & "'" & "AND store_id =" & Str(gStoreEqptRecord.nStoreId) & " " & "AND vend_seq =" & Str(nVendSeq)
        cmd.CommandText = sStmt
        'MsgBox sStmt

        'rsLocal = cmd.ExecuteReader()
        dt = getDataTable(sStmt)

        cbAccount.Items.Clear()
        cbAccountNo.Items.Clear()
        cbAccount.Items.Insert(0, "<New>")
        cbAccountNo.Items.Insert(0, "<New>")


        If dt.Rows.Count > 0 Then
            'cbAccount.Clear
            'cbAccount.AddItem "<New>", 0
            'load_cb_query2 cbAccount, sStmt, 1, False
            load_cb3(cbAccount, dt, 1, False)
            load_cb3(cbAccountNo, dt, 0, False)
        Else
            Exit Sub
        End If


    End Sub
End Class