Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text

Friend Class frmCustInvGenSearch
	Inherits System.Windows.Forms.Form

	Private Declare Function GetTempPath Lib "kernel32"  Alias "GetTempPathA"(ByVal nBufferLength As Integer, ByVal lpBuffer As String) As Integer
	
	Private Declare Function GetTempFileName Lib "kernel32"  Alias "GetTempFileNameA"(ByVal lpszPath As String, ByVal lpPrefixString As String, ByVal wUnique As Integer, ByVal lpTempFileName As String) As Integer
	
	
    Private rsLocal As DataTable
    Private rsLocal2 As DataTable
    Private period_start_date() As DateTime
	
	
    Public stre As IO.StreamWriter
    Public rsBatch As DataTable
	
	Public stmt As String
	Public idBatch As String
	Private nFile As String
	Public nSelectedId As Short
	
	
	
	'UPGRADE_WARNING: Event cbCustName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbCustName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbCustName.SelectedIndexChanged
		
		cbCustId.SelectedIndex = cbCustName.SelectedIndex
		
		'Load Period
		loadPeriodAndArray(cbPeriod, period_start_date, (cbCustId.Text), True)
		If cbPeriod.Items.Count > 0 Then
			cbPeriod.SelectedIndex = 0
		End If
		
		'Load Groups
		'jp.2011.11.20.begin
		'load_cb_groups cbGroupName, cbCustId.Text, True
		cbGroupName.Items.Clear()
		cbGroupName.Items.Insert(0, UI_SELECTED_VALUES)
		'If Not cbCustName.Text = UI_ALL And Not Me.cbPeriod.Text = UI_ALL Then
		
		
		'End If
		
		'load_cb_groups Me.cbGroupName, cbCustId.Text, True, False
		load_cb_groups(cbGroupName, (cbCustId.Text), True, False)
		'jp.2011.11.20.end
		If cbGroupName.Items.Count > 0 Then
			cbGroupName.SelectedIndex = 0
		End If
		
		load_Data(True)
	End Sub
	
	
	Private Sub cbFill_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbFill.Click
		load_Data(False)
		
	End Sub
	'Loads dgData
	Private Sub load_Data(ByRef bInit As Boolean)
		
        Dim sWhere As String = ""
        Dim sOrder As String = ""
        Dim bFlag As Boolean = False
        Dim sCriteria As String = ""
        Dim nCount As Short = -1
        Dim nHeaderCount As Short = -1
        Dim sGroup As String = ""
        Dim sGroupSeq As String = ""
        Dim tmpDR As DataTable
        Dim cmd As SqlCommand = cn.CreateCommand()
		
		bFlag = False
		
		On Error GoTo ErrorHandler
		
		sStmt = "SELECT a.cust_id 'Cust', a.cust_invoice_seq, a.invoice_date, " & " a.invoice_date_desc ""Invoice Date"", a.billing_period Period," & " b.group_seq, b.group_name 'Group', " & " a.account_no Account, a.invoice_no Invoice, a.grand_total Total, " & " c.template_name 'Template' " & " FROM CustomerInvoice a, Groups b, CustomerInvoiceTemplate c " & " WHERE a.group_seq = b.group_seq " & " AND a.cust_id = b.cust_id " & " AND a.template_id = c.template_id "

		
		'" WHERE cust_id ='" + Trim(Me.cbCustId.Text) + "' " + _
		''" AND period_seq =" + CStr(cbPeriod.ItemData(cbPeriod.ListIndex)) + _
		''" ORDER BY billing_period DESC, invoice_date DESC, cust_invoice_seq DESC"
		If bInit Then
			sWhere = " AND a.cust_id='--'"
			
			sStmt = sStmt & sWhere
		Else
			If cbCustId.Text <> UI_ALL Then
				sWhere = sWhere & " AND a.cust_id ='" & Trim(Me.cbCustId.Text) & "' "
			End If
			
			If cbGroupName.Text <> UI_ALL Then
				If cbGroupName.Text = UI_SELECTED_VALUES Then
					If cbCustName.Text <> UI_ALL Then
						
						bFlag = True
						
						'sStmt = "SELECT a.cust_id 'Cust', a.cust_invoice_seq, a.invoice_date, " + _
						'" a.invoice_date_desc 'Invoice Date', a.billing_period Period, " + _
						'" b.param_seq group_seq, b.param_value 'Group', " + _
						'" a.account_no Account, a.invoice_no Invoice, a.grand_total Total, " + _
						'" c.template_name 'Template'" + _
						'" FROM CustomerInvoice a, rptCriteriaDet b, CustomerInvoiceTemplate c " + _
						'" WHERE a.template_id = c.template_id " + _
						'" AND a.id = b.id " + _
						'" AND b.param_name='group_seq' " + _
						'" AND a.id IS NOT NULL "
						sStmt = "SELECT  DISTINCT a.cust_id 'Cust', a.cust_invoice_seq, a.invoice_date, " & " a.invoice_date_desc 'Invoice Date', a.billing_period Period, " & " a.account_no Account, a.invoice_no Invoice, a.grand_total Total, " & " c.template_name 'Template'" & " FROM CustomerInvoice a, CustomerInvoiceTemplate c " & " WHERE a.template_id = c.template_id " & " AND a.id = " & Str(nSelectedId)
						
					End If
					
				Else
					sWhere = sWhere & " AND a.group_seq = " & Str(VB6.GetItemData(cbGroupName, cbGroupName.SelectedIndex)) & " "
				End If
			End If
			
			
			'If cbPeriod.ListIndex > 0 And cbPeriod.Text <> UI_ALL Then
			If cbPeriod.Text <> UI_ALL Then
				sWhere = sWhere & " AND a.period_seq =" & CStr(VB6.GetItemData(cbPeriod, cbPeriod.SelectedIndex))
			End If
			
			If ckInvoiceDates.CheckState = System.Windows.Forms.CheckState.Checked Then
                sWhere = sWhere & " AND a.invoice_date BETWEEN '" & CStr(dtFrom.Value) & "' AND '" & CStr(dtTo.Value) & "' "
			End If
			
			sOrder = " ORDER BY a.cust_id DESC, a.billing_period DESC, a.invoice_date DESC, a.cust_invoice_seq DESC"
			
			sStmt = sStmt & sWhere & sOrder
		End If
		
		
		'"'' billing_period='" & Trim(Format(period_start_date(cbPeriod.ListIndex + 1), "MMMM yyyy")) & "'" & _
		'
		'Set dgBillingRange.DataSource = Nothing
		
		If bFlag Then
			sCriteria = "SELECT param_seq, param_value" & " FROM rptCriteriaDet a" & " WHERE a.id = " & Str(nSelectedId)
            cmd.CommandText = sCriteria
			
            rs = getDataTable(sCriteria) ' cmd.ExecuteReader()
            If rs.Rows.Count > 0 Then
                sGroupSeq = ""
                sGroup = ""
                nCount = 0
                tmpDR = rs
                Dim recordCount As Integer = tmpDR.Rows.Count

                For row As Integer = 0 To rs.Rows.Count - 1
                    nCount = nCount + 1
                    sGroupSeq = sGroupSeq & Str(rs.Rows(row).Item("param_seq"))
                    sGroup = sGroup + rs.Rows(row).Item("param_value")
                    If recordCount > nCount Then
                        sGroupSeq = sGroupSeq & ","
                        sGroup = sGroup & ","
                    End If

                Next row
            End If
			
			sStmt = "SELECT a.cust_id 'Cust', a.cust_invoice_seq, a.invoice_date, " & " a.invoice_date_desc 'Invoice Date', a.billing_period Period, " & "'" & sGroupSeq & "' group_seq, '" & sGroup & "'" & """Group"" ," & " a.account_no Account, a.invoice_no Invoice, a.grand_total Total, " & " c.template_name 'Template'" & " FROM CustomerInvoice a, CustomerInvoiceTemplate c " & " WHERE a.template_id = c.template_id " & " AND a.id =" & Str(nSelectedId)
			sStmt = sStmt & sWhere
            cmd.CommandText = sStmt
			
            rsLocal2 = getDataTable(sStmt) 'cmd.ExecuteReader()
            dgData.DataSource = rsLocal2


        Else
            rsLocal = getDataTable(sStmt) 'cmd.ExecuteReader()
            dgData.DataSource = rsLocal

            'UPGRADE_NOTE: Object dgData.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'dgData.DataSource = Nothing
            Exit Sub
        End If


        'Format Datagrid
        'Cust_invoice_seq , invoice_date, billing_period


        'dgData.Columns("range_seq").Visible = False
        dgData.Columns("Cust").Width = VB6.TwipsToPixelsX(1000)
        dgData.Columns("Invoice Date").Width = VB6.TwipsToPixelsX(1800)
        dgData.Columns("Account").Width = VB6.TwipsToPixelsX(2000)
        dgData.Columns("Period").Width = VB6.TwipsToPixelsX(1800)
        dgData.Columns("Invoice").Width = VB6.TwipsToPixelsX(1800)
        dgData.Columns("Total").Width = VB6.TwipsToPixelsX(1500)

        dgData.Columns("cust_invoice_seq").Visible = False
        dgData.Columns("invoice_date").Visible = False
        dgData.Columns("group_seq").Visible = False
        dgData.Columns("Account").Visible = False
        dgData.Columns("Invoice").Visible = False
        dgData.Columns("Total").Visible = False


        'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        dgData.Refresh()

        Exit Sub

ErrorHandler:
        save_error(Me.Name, "load_Data")
        MsgBox("Unexpected error found while loading Invoice list." & vbCrLf & "Review log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
	End Sub
	
	'UPGRADE_WARNING: Event cbGroupName.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbGroupName_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbGroupName.SelectedIndexChanged
		
		
		If cbGroupName.Text = UI_SELECTED_VALUES Then
			cmdSelectedValues.Enabled = True
		Else
			cmdSelectedValues.Enabled = False
		End If
		
	End Sub
	
	'UPGRADE_WARNING: Event cbPeriod.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cbPeriod_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriod.SelectedIndexChanged
		load_Data(True)
	End Sub
	
	'UPGRADE_WARNING: Event ckInvoiceDates.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub ckInvoiceDates_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ckInvoiceDates.CheckStateChanged
		enable_dates()
	End Sub
	
	Private Sub cmdSelectedValues_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelectedValues.Click
		
		If cbCustId.SelectedIndex <= 0 Then
			MsgBox("Please select a Customer before attempting this action.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			Exit Sub
		End If
		
		
		If cbPeriod.SelectedIndex <= 0 Then
			MsgBox("Please select a Period before attempting this action.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
			Exit Sub
		End If
		
		frmListStoreGroup.sCustId = cbCustId.Text
		frmListStoreGroup.sRepCaption = RPT_GLM_INVOICE_REPORT
		frmListStoreGroup.nPeriodSeq = VB6.GetItemData(cbPeriod, cbPeriod.SelectedIndex)
		VB6.ShowForm(frmListStoreGroup, VB6.FormShowConstants.Modal, Me)
		
		
		nSelectedId = frmListStoreGroup.nSelectedId
		
		
	End Sub
	
    Private Sub dgData_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        updateInvoiceDoc()
    End Sub
	
	Public Sub updateInvoiceDoc()
		Dim iFila As Object
        'Dim vRow As Object
		'vRow = Me.dgData.SelBookmarks
        If dgData.SelectedRows.Count() < 1 Then
            Exit Sub
        End If
		'UPGRADE_WARNING: Couldn't resolve default property of object iFila. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'iFila = dgData.CurrentRow.Cells.Columns("Cust_invoice_seq").Text
        iFila = dgData.CurrentRow.Cells("Cust_invoice_seq").Value
		
        'UPGRADE_ISSUE: Load statement is no() supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"'
        frmCustInvGenPreview.Show()
		'UPGRADE_WARNING: Couldn't resolve default property of object iFila. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		frmCustInvGenPreview.Cust_invoice_seq = iFila
		'frmCustInvGenPreview.build_document ' .create_document_word
		
		
		'jpdebug.begin
		'frmCustInvGenPreview.cmdLoad_Click
		frmCustInvGenPreview.loadDocFromDbToOle()
		
		frmCustInvGenPreview.oleOpenForEdition()
		'jpdebug.end
		frmCustInvGenPreview.ShowDialog()
		
	End Sub
	
	Private Sub frmCustInvGenSearch_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
		
		'load_customer
		load_cb_customer(cbCustName, cbCustId, True)
		If cbCustName.Items.Count > 0 Then
			cbCustName.SelectedIndex = 0
		End If

        period_start_date(1) = Today.Date
        period_start_date(0) = Today.Date
		'load_Data True
		
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button4.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "new"
                add_letter()
            Case "save"
                If dgData.SelectedRows.Count > 0 Then
                    updateInvoiceDoc()
                Else
                    MsgBox("You must select a record before attempting this command.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                End If
            Case "delete"
                If Me.dgData.SelectedRows.Count < 1 Then
                    MsgBox("Please select one or more records before attempting this action." & vbCrLf, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
                    Exit Sub
                End If

                If deleteSingleCustomerInvoice(CShort(dgData.SelectedRows(0).Cells("cust_invoice_seq").Value)) Then
                    cbFill_Click(cbFill, New System.EventArgs())
                    MsgBox("Customer Invoice was successfully removed.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
                End If

            Case "print"
                print_document()

            Case "exit"
                Me.Close()
        End Select

    End Sub
	
	Private Sub add_letter()
		
		VB6.ShowForm(frmCustInvGen, VB6.FormShowConstants.Modal, Me)
		
	End Sub
	
	
	Private Sub enable_dates()
		If ckInvoiceDates.CheckState = System.Windows.Forms.CheckState.Checked Then
			frInvoiceDates.Enabled = True
			dtFrom.Enabled = True
			dtTo.Enabled = True
		Else
			frInvoiceDates.Enabled = False
			dtFrom.Enabled = False
			dtTo.Enabled = False
		End If
	End Sub
	
	Private Sub init_vars()
		dtFrom.value = Today
		dtTo.value = Today
        'dtFrom.Day = 1
		
		
        'rsLocal
        'rsLocal2 = SqlDataReader
        'rsLocal2.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		
		ckInvoiceDates.CheckState = System.Windows.Forms.CheckState.Unchecked
		enable_dates()
		
		cmdSelectedValues.Enabled = False
		
	End Sub
	
	Private Sub printingDocument()
		Dim j As Object
		Dim i As Object
		Dim oWord As Object
		oWord = CreateObject("Word.Application")
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Visible. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Visible = False
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Documents. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Documents.Add("Normal", False, 0)
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Visible. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Visible = False
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Documents. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Documents.Open(nFile) ' App.Path & "\template\Customer Invoice Generation.doc"
		
		' Imprime el documento activo con Printout
		For i = 1 To 10000
			For j = 1 To 1000
			Next 
		Next 
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Visible. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Visible = False
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.ActiveDocument. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.ActiveDocument.PrintOut()
		
		For i = 1 To 10000
			For j = 1 To 1000
			Next 
		Next 
		
		' Cierra el documento
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Visible. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Visible = False
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Documents. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Documents.Close(False)
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Visible. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Visible = False
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Quit. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Quit(False)
		
		
		' Elimina la referencia
		'UPGRADE_NOTE: Object oWord may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oWord = Nothing
		
		'OLEInvoice.AppIsRunning = False
	End Sub
	
	
	
	
	Private Function pFreeFile() As String
        Dim sPrefix As Object
        pFreeFile = ""
		Dim sTmpPath As New VB6.FixedLengthString(512)
		Dim sTmpName As New VB6.FixedLengthString(576)
		Dim nRet As Integer
		
		'UPGRADE_WARNING: Couldn't resolve default property of object sPrefix. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sPrefix = "VBT"
		
		nRet = GetTempPath(512, sTmpPath.Value)
		If (nRet > 0 And nRet < 512) Then
			'UPGRADE_WARNING: Couldn't resolve default property of object sPrefix. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			nRet = GetTempFileName(sTmpPath.Value, sPrefix, 0, sTmpName.Value)
			If nRet <> 0 Then
				pFreeFile = VB.Left(sTmpName.Value, InStr(sTmpName.Value, vbNullChar) - 1)
			End If
		End If
	End Function
	
	
	Public Sub loadDocument(ByRef Cust_invoice_seq As String)
		Dim sFileSaved As Object
        Dim rs As DataTable
        Dim cmd As SqlCommand = cn.CreateCommand()
		stmt = "SELECT * FROM customerInvoice where cust_invoice_seq= " & Cust_invoice_seq
        cmd.CommandText = stmt
        rs = getDataTable(stmt) 'cmd.ExecuteReader() '.Open(stmt, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(rs.Rows(0).Item("filecontent")) Then
            '        create_document_word rs
            MsgBox("Document not exists", MsgBoxStyle.Critical, "GLM")
        Else
            nFile = pFreeFile()
            stre = New IO.StreamWriter(nFile)
            stre.Write(rs.Rows(0).Item("filecontent"))
            stre.Close()
            'stre.SaveToFile(nFile, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)
            'rs.Close()

            'OLEInvoice.SourceDoc = nFile
            'OLEInvoice.CreateLink nFile 'oWord.Application.ActiveDocument
            'OLEInvoice.Refresh

            'OLEInvoice.Action
            'UPGRADE_WARNING: Couldn't resolve default property of object sFileSaved. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            sFileSaved = True
        End If
	End Sub
	Private Sub print_document()

        Dim oWord As Object = New Object()
        Dim vRow As DataGridViewRow
		
        Dim nSelected As String = ""
		
        If dgData.SelectedRows.Count < 1 Then
            MsgBox("Please select a record before attempting this command", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            Exit Sub
        End If
		
		
        For Each vRow In dgData.SelectedRows
            If Not (rsBatch Is Nothing) Then
                'no se como funciona esto
                'rsBatch.Bookmark = vRow 'dgData.SelBookmarks.Item(vRow - 1)
                nSelected = rsBatch.Rows(vRow.Index).Item("Cust_invoice_seq")
            Else
                'no se como funciona esto
                'rsLocal.Bookmark = vRow 'dgData.SelBookmarks.Item(vRow - 1)
                nSelected = rsLocal.Rows(vRow.Index).Item("Cust_invoice_seq")
            End If


            loadDocument(nSelected)
            printingDocument()

        Next vRow
		
		On Error Resume Next
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Quit. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Quit(False)
		'UPGRADE_NOTE: Object oWord may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oWord = Nothing
		On Error GoTo 0
		
		
		MsgBox("Process completed !", MsgBoxStyle.Information, "GLM Message")
		
	End Sub
	Public Sub showBatch()
		On Error GoTo ErrorHandler2
        Dim cmd As SqlCommand = cn.CreateCommand()
		sStmt = "SELECT tb1.cust_invoice_seq, tb1.invoice_date 'Invoice Date', " & " tb1.billing_period 'Period', tb3.group_name 'Group Name', tb4.template_name 'Template' " & " FROM CustomerInvoice tb1 INNER JOIN CustomerInvoiceBatchDet tb2 on (tb1.cust_invoice_seq = tb2.cust_invoice_seq) " & " INNER JOIN Groups tb3 ON (tb3.cust_id = tb1.cust_id AND tb3.group_seq = tb1.group_seq) " & " INNER JOIN CustomerInvoiceTemplate tb4 ON (tb4.template_id = tb1.template_id) " & " WHERE tb2.cust_inv_batch_seq = " & idBatch & " ORDER BY tb1.billing_period DESC, tb1.invoice_date DESC, tb1.cust_invoice_seq DESC"
        cmd.CommandText = sStmt
		
        rsBatch = getDataTable(sStmt) 'cmd.ExecuteReader()
		
        If rsBatch.Rows.Count > 0 Then
            dgData.DataSource = rsBatch
        Else
            'UPGRADE_NOTE: Object dgData.DataSource may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            dgData.DataSource = Nothing
            Exit Sub
        End If
		
		'Format Datagrid
		'Cust_invoice_seq , invoice_date, billing_period
		
		'dgData.Columns("range_seq").Visible = False
		dgData.Columns("cust_invoice_seq").Width = VB6.TwipsToPixelsX(1800)
		dgData.Columns("Invoice Date").Width = VB6.TwipsToPixelsX(1800)
		dgData.Columns("Period").Width = VB6.TwipsToPixelsX(1800)
		
		dgData.Columns("cust_invoice_seq").Visible = False
		'UPGRADE_NOTE: Refresh was upgraded to CtlRefresh. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        dgData.Refresh()
		
		Exit Sub
		
ErrorHandler2: 
		save_error(Me.Name, "showBatch")
		MsgBox("Unexpected error found while loading Batch details." & vbCrLf & "Review log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
	End Sub

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        add_letter()
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        If dgData.SelectedRows.Count > 0 Then
            updateInvoiceDoc()
        Else
            MsgBox("You must select a record before attempting this command.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
        End If
    End Sub

    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        If Me.dgData.SelectedRows.Count < 1 Then
            MsgBox("Please select one or more records before attempting this action." & vbCrLf, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
            Exit Sub
        End If

        'If deleteSingleCustomerInvoice(CShort(dgData.Columns("cust_invoice_seq").Text)) Then
        If deleteSingleCustomerInvoice(CShort(dgData.SelectedRows(0).Cells("cust_invoice_seq").Value)) Then
            cbFill_Click(cbFill, New System.EventArgs())
            MsgBox("Customer Invoice was successfully removed.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "GLM Message")
        End If
    End Sub

    Private Sub btPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrint.Click
        print_document()
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub btDunno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDunno.Click

    End Sub
End Class