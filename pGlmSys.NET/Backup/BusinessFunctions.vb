Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Module BusinessFunctions
	Public Declare Function GetTempPath Lib "kernel32"  Alias "GetTempPathA"(ByVal nBufferLength As Integer, ByVal lpBuffer As String) As Integer
	
	Public Declare Function GetTempFileName Lib "kernel32"  Alias "GetTempFileNameA"(ByVal lpszPath As String, ByVal lpPrefixString As String, ByVal wUnique As Integer, ByVal lpTempFileName As String) As Integer
	
	
	'Closes the current period
	Public Function close_period(ByRef sCustId As String, ByRef nPeriodSeq As Short) As Boolean
        Dim nRecords As Integer = 0
        Dim cmd As SqlCommand = cn.CreateCommand()
		On Error GoTo ErrorHandler
		close_period = False
		
		'Check if period exists and still open
		sStmt = " SELECT period_status_id FROM period " & " WHERE cust_id ='" & sCustId & "' " & " AND period_seq =" & Str(nPeriodSeq)
        cmd.CommandText = sStmt
		
        rs = getDataTable(sStmt) ' cmd.ExecuteReader()

        If rs.Rows.Count > 0 Then
            If Trim(rs.Rows(0).Item("period_status_id")) = "O" Then
                sStmt = "UPDATE period " & " SET period_status_id = 'C' " & " WHERE cust_id ='" & sCustId & "' " & " AND period_seq = " & Str(nPeriodSeq)
                cm.CommandText = sStmt
                nRecords = cm.ExecuteNonQuery()

                If nRecords > 0 Then
                    close_period = True
                    MsgBox("Billing period has been closed.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Message")
                End If

            End If
        End If

        Exit Function


ErrorHandler:
        save_error("BusinessFunctions", "close_period")
        MsgBox("An unexpected error occurred while updating Billing Period status." & vbCrLf & "Check log file for addtional details", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")

        'Update period flag to close
	End Function
	
    Public Function isFeeRange(ByRef feeDesc As String) As Boolean
        Dim cmd As SqlCommand = cn.CreateCommand()
        sStmt = "SELECT range_flag FROM FeeType WHERE fee_desc ='" & Trim(feeDesc) & "' "
        cmd.CommandText = sStmt
        isFeeRange = False

        rs = getDataTable(sStmt) 'cmd.ExecuteReader()

        If rs.Rows.Count > 0 Then
            If Not IsDBNull(rs.Rows(0).Item(0)) Then
                If rs.Rows(0).Item(0) = "T" Then
                    isFeeRange = True
                End If
            End If
        End If


    End Function
	'Builds Word Document
	'Sets the content of the Customer Invoice file and saves it in a
	'Windows temporary file
	Public Sub create_document_word_content(ByRef oWord As Object, ByRef wordDoc As gWordDocUDT, ByRef nFile As String, ByRef sTemplateFile As String, ByRef flags As gWordDocFlagUDT)
		Dim wdToggle As Object
		Dim wdUnderlineNone As Object
		Dim wdUnderlineDouble As Object
		Dim wdUnderlineSingle As Object
		Dim wdFormatDocument As Object
		Dim wdAlignTabLeft As Object
		Dim wdTabLeaderSpaces As Object
		Dim wdAlignTabDecimal As Object
		Dim wdAlignParagraphCenter As Object
		Dim wdAlignParagraphJustify As Object
		
		'UPGRADE_WARNING: Couldn't resolve default property of object wdAlignParagraphJustify. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		wdAlignParagraphJustify = 3
		'UPGRADE_WARNING: Couldn't resolve default property of object wdAlignParagraphCenter. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		wdAlignParagraphCenter = 1
		'UPGRADE_WARNING: Couldn't resolve default property of object wdAlignTabDecimal. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		wdAlignTabDecimal = 3
		'UPGRADE_WARNING: Couldn't resolve default property of object wdTabLeaderSpaces. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		wdTabLeaderSpaces = 0
		'UPGRADE_WARNING: Couldn't resolve default property of object wdAlignTabLeft. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		wdAlignTabLeft = 0
		'UPGRADE_WARNING: Couldn't resolve default property of object wdFormatDocument. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		wdFormatDocument = 0
		
		'UPGRADE_WARNING: Couldn't resolve default property of object wdUnderlineSingle. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		wdUnderlineSingle = 1
		'UPGRADE_WARNING: Couldn't resolve default property of object wdUnderlineDouble. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		wdUnderlineDouble = 3
		'UPGRADE_WARNING: Couldn't resolve default property of object wdUnderlineNone. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		wdUnderlineNone = 0
		
		'UPGRADE_WARNING: Couldn't resolve default property of object wdToggle. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		wdToggle = 9999998
		
		'Dim oWord As Object
		oWord = CreateObject("Word.Application")
		
		
		'jpdebug.begin. Commented to not open an empty doc
		'oWord.Documents.Add "Normal", False, 0
		'jpdebug.end
		
		'oWord.Application.Load App.Path & "\GLM_Watermark_Template.doc"
		'oWord.Documents.Open App.Path & "\GLM_Watermark_Template.doc"
		'oWord.Documents.Open App.Path & "\" & MSWORD_CUSTOMER_INVOICE_TEMPLATE
		'oWord.Documents.Open gGlobSettings.sMswordTemplateFile
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Documents. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Documents.Open(sTemplateFile)
		
		'jp.121309.begin
		'oWord.Selection.Font.name = "Tahoma"
		'oWord.Selection.Font.Size = 10
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.Font.name = MSWORD_FONT_NAME
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.Font.size = MSWORD_FONT_SIZE
		'jp.121309.end
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object wdAlignParagraphJustify. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.ParagraphFormat.Alignment = wdAlignParagraphJustify
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'oWord.Selection.Style = oWord.ActiveDocument.Styles("Sin espaciado")
		
		'jp.121309.begin
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		
		'jp.121309.end
		
		'oWord.Selection.TypeText frmCustInvGen.txtInvoiceDate.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText(wordDoc.sInvoiceDate)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object wdToggle. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.Font.Bold = wdToggle
		'jp.121309.begin
		'oWord.Selection.Font.Size = 20
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.Font.size = MSWORD_FONT_SIZE_TITLE
		'jp.121309.end
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object wdAlignParagraphCenter. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.ParagraphFormat.Alignment = wdAlignParagraphCenter
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText(Text:="INVOICE")
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object wdToggle. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.Font.Bold = wdToggle
		
		'jp.121309.begin
		'oWord.Selection.Font.name = "Tahoma"
		'oWord.Selection.Font.Size = 14
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.Font.name = MSWORD_FONT_NAME
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.Font.size = MSWORD_FONT_SIZE
		'jp.121309.end
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object wdAlignParagraphJustify. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.ParagraphFormat.Alignment = wdAlignParagraphJustify
		
		'oWord.Selection.TypeText frmCustInvGen.txtAddress.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText(wordDoc.sAddress)
		
		'jp.121309.begin
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.Font.name = MSWORD_FONT_NAME
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.Font.size = MSWORD_FONT_SIZE
		'jp.121309.end
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		
		'oWord.Selection.TypeText "For the month of " & Trim(frmCustInvGen.txBillingPeriod.Text)
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText("For the month of " & Trim(wordDoc.sBillingPeriod))
		
		'Format(period_start_date, "MMMM yyyy")
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'oWord.Selection.TypeText "ACCOUNT NO:" & Trim(frmCustInvGen.txtAccountNo.Text)
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText("ACCOUNT NO:" & Trim(wordDoc.sAccountNo))
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'oWord.Selection.TypeText "INVOICE NO:" & Trim(frmCustInvGen.txtInvoiceNo.Text)
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText("INVOICE NO:" & Trim(wordDoc.sInvoiceNo))
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		
		If flags.bLocation Then
			'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			oWord.Selection.TypeText("Location:" & wordDoc.sLocation)
			'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			oWord.Selection.TypeParagraph()
			'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			oWord.Selection.TypeParagraph()
		End If
		
		'oWord.Selection.TypeText frmCustInvGen.txtDescription.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText(wordDoc.sDescription)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.ParagraphFormat.TabStops(56.69291).Clear()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.ParagraphFormat.TabStops.Add(Position:=56.69291, Alignment:=wdAlignTabLeft, Leader:=wdTabLeaderSpaces)
		'Selection.TypeText Text:=vbTab
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.ParagraphFormat.TabStops.Add(Position:=269.2914, Alignment:=wdAlignTabDecimal, Leader:=wdTabLeaderSpaces)
		
		
		'jp.121711.begin
		If flags.bTotalByStoreGroup Then


            'wordDoc.rsStoreGroup.MoveNext
            For row As Integer = 0 To wordDoc.rsStoreGroup.Rows.Count - 1
                oWord.Selection.TypeText(vbTab & wordDoc.rsStoreGroup.Rows(row).Item("store_group_name").value & ":" & vbTab & wordDoc.rsStoreGroup.Rows(row).Item("group_amount_due").value)

                oWord.Selection.TypeParagraph()
                oWord.Selection.TypeParagraph()
            Next
            




        Else

            'jp.121409.begin
            'oWord.Selection.TypeText vbTab & "Bill Payment: " & vbTab & frmCustInvGen.txtInvoiceTotal.Text
            'oWord.Selection.TypeText vbTab & "Bill Payment: " & vbTab & frmCustInvGen.txtInvoiceTotal.FormattedText
            oWord.Selection.TypeText(vbTab & "Bill Payment: " & vbTab & wordDoc.sInvoiceTotalFormatted)
            'jp.121409.end


            oWord.Selection.TypeParagraph()
            oWord.Selection.TypeParagraph()
            'jp.121409.begin
            'oWord.Selection.TypeText vbTab & "Savings: " & vbTab & frmCustInvGen.txtSavings.Text
            'oWord.Selection.TypeText vbTab & "Total Savings: " & vbTab & frmCustInvGen.txtSavings.FormattedText
            oWord.Selection.TypeText(vbTab & "Total Savings: " & vbTab & wordDoc.sSavingsFormatted)
            'jp.121409.end

            oWord.Selection.TypeParagraph()
            oWord.Selection.TypeParagraph()

            'oWord.Selection.TypeText vbTab & "GLM charges at " & frmCustInvGen.txtSavingsPercent.Text & "%: " & vbTab & Format((frmCustInvGen.txtSavings.Text * frmCustInvGen.txtSavingsPercent.Text / 100), "#######0.00")

            'nPorc = get_percent




            'jp.121409.begin
            'oWord.Selection.TypeText vbTab & "GLM charges at " & nPorc & " %: " & vbTab & Format((frmCustInvGen.txtSavings.Text * nPorc / 100), "#######0.00")
            'oWord.Selection.TypeText vbTab & "GLM " & nPorc & " % of Savings: " & vbTab & Format((frmCustInvGen.txtSavings.Text * nPorc / 100), "$#,###,##0.00")
            'jp.20110102.begin
            '=========== Display only if flag was turned on ==============
            If flags.bSavingsPercent Then
                'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                oWord.Selection.TypeText(vbTab & "GLM " & wordDoc.sPercent & " % of Savings: " & vbTab & VB6.Format(CDbl(wordDoc.sSavings) * CDbl(wordDoc.sPercent) / 100, "$#,###,##0.00"))
                'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                oWord.Selection.TypeParagraph()
                'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                oWord.Selection.TypeParagraph()
            End If
            'jp.20110102.end
            'jp.121409.end

            'jp.121409.begin
            'oWord.Selection.TypeText vbTab & "Store Flat Fee: " & vbTab & frmCustInvGen.txtStoreFlatFee.Text
            'oWord.Selection.TypeText vbTab & "GLM Location Fee: " & vbTab & frmCustInvGen.txtStoreFlatFee.FormattedText
            'jp.20110102.begin
            '=========== Display only if flag was turned on ==============
            If flags.bStoreFlatFee Then
                'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                oWord.Selection.TypeText(vbTab & "GLM Location Fee: " & vbTab & wordDoc.sStoreFlatFeeFormatted)
                'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                oWord.Selection.TypeParagraph()
                'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                oWord.Selection.TypeParagraph()
                'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                oWord.Selection.TypeParagraph()
            End If
            'jp.20110102.end
            'jp.121409.end

            'jp.121711.end
        End If 'End of bTotalByStoreGroup check

        'jp.121409.begin
        '============  Per customer request, removed Invoice and Tax lines   ===============
        'oWord.Selection.TypeText vbTab & "Invoice Fee: " & vbTab & frmCustInvGen.txtInvoiceFee.Text
        'oWord.Selection.TypeParagraph
        'oWord.Selection.TypeParagraph
        'oWord.Selection.TypeText vbTab & "Tax: " & vbTab
        'oWord.Selection.Font.Underline = wdUnderlineSingle
        'oWord.Selection.TypeText frmCustInvGen.txtTax.Text
        'oWord.Selection.Font.Underline = wdUnderlineNone
        'jp.121409.end


        'jp.121409.begin
        'oWord.Selection.TypeText vbTab & "Grand Total: " & vbTab
        'jp.20110103.begin
        '=========== Display only if flag was turned on ==============
        If flags.bTotal Then
            'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            oWord.Selection.TypeText(vbTab & "Total Amount Due: " & vbTab)
            'jp.121409.end
            'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object wdUnderlineDouble. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            oWord.Selection.Font.Underline = wdUnderlineDouble
            'jp.121409.begin
            'oWord.Selection.TypeText frmCustInvGen.txtGrandTotal.Text
            'oWord.Selection.TypeText frmCustInvGen.txtGrandTotal.FormattedText
            'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            oWord.Selection.TypeText(wordDoc.sGrandTotalFormatted)
            'jp.121409.end
            'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object wdUnderlineNone. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            oWord.Selection.Font.Underline = wdUnderlineNone
        End If
        'jp.20110103.end

        'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        oWord.Selection.TypeParagraph()
        'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        oWord.Selection.TypeParagraph()
        'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        oWord.Selection.TypeParagraph()
        'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        oWord.Selection.TypeParagraph()
        'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object wdAlignParagraphCenter. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        oWord.Selection.ParagraphFormat.Alignment = wdAlignParagraphCenter
        'oWord.Selection.TypeText frmCustInvGen.txtGreeting.Text & vbCrLf
        'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        oWord.Selection.TypeText(wordDoc.sGreeting & vbCrLf)
        'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        oWord.Selection.TypeParagraph()
        'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        oWord.Selection.Font.name = MSWORD_FONT_NAME
        'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        oWord.Selection.Font.size = MSWORD_FONT_SIZE
        'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        oWord.Selection.TypeText(Text:=MSWORD_REMIT_ADDRESS)





        'oWord.Application.Save
        'nFile = pFreeFile ' App.Path & "\tmp" & Trim(Cust_invoice_seq) '"C:\archivos\test2.doc"

        On Error Resume Next
        'UPGRADE_WARNING: Couldn't resolve default property of object oWord.ActiveDocument. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        oWord.ActiveDocument.SaveAs(FileName:=nFile, FileFormat:=wdFormatDocument, LockComments:=False, Password:="", AddToRecentFiles:=True, WritePassword:="", ReadOnlyRecommended:=False, EmbedTrueTypeFonts:=False, SaveNativePictureFormat:=False, SaveFormsData:=False, SaveAsAOCELetter:=False)

        If Err.Number <> 0 Then
            MsgBox(Err.Description & vbCrLf, MsgBoxStyle.Critical, "")
        Else
            'MsgBox "Document saved...!"
        End If

        On Error GoTo 0
        'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Documents. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'JP.DEBUG
        'oWord.Documents.Close(False)
        'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Quit. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        oWord.Quit(False)
		
		
	End Sub
	
	Public Function pFreeFile() As String
		Dim sPrefix As Object
		Dim sTmpPath As New VB6.FixedLengthString(512)
		Dim sTmpName As New VB6.FixedLengthString(576)
        Dim nRet As Integer
        pFreeFile = ""
		
		'UPGRADE_WARNING: Couldn't resolve default property of object sPrefix. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sPrefix = "VBT"
		
		nRet = GetTempPath(512, sTmpPath.Value)
		If (nRet > 0 And nRet < 512) Then
			'UPGRADE_WARNING: Couldn't resolve default property of object sPrefix. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			nRet = GetTempFileName(sTmpPath.Value, sPrefix, 0, sTmpName.Value)
			
			If nRet <> 0 Then
				pFreeFile = Left(sTmpName.Value, InStr(sTmpName.Value, vbNullChar) - 1)
			End If
		End If
		
	End Function
	'Checks for uniqueness of Word doc invoice
	Public Function existInvoice(ByRef sCustId As String, ByRef nPeriodSeq As Short, ByRef nGroupSeq As Short, ByRef nTemplateId As Short) As Boolean
		
        Dim rsInvoice As DataTable
        Dim stmt As String
        Dim cmd As SqlCommand = cn.CreateCommand()
		
		existInvoice = False
		
		stmt = " SELECT cust_invoice_seq FROM CustomerInvoice " & " WHERE cust_id ='" & Trim(sCustId) & "' " & " AND period_seq =" & Str(nPeriodSeq) & " AND group_seq =" & Str(nGroupSeq) & " AND template_id =" & Str(nTemplateId)
        cmd.CommandText = stmt
        Try
            rsInvoice = getDataTable(stmt) 'cmd.ExecuteReader() '.Open(stmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rsInvoice.Rows.Count > 0 Then
                existInvoice = True
                Exit Function
                'Else
                '   MsgBox("Can not verify customer invoice uniqueness for: Cust:" & sCustId & ",period_seq =" & Str(nPeriodSeq) & ",group_seq =" & Str(nGroupSeq) & ",template_id =" & Str(nTemplateId), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
                '  existInvoice = True
                ' Exit Function
            End If

        Catch e As Exception
            MsgBox("Can not verify customer invoice uniqueness for: Cust:" & sCustId & ",period_seq =" & Str(nPeriodSeq) & ",group_seq =" & Str(nGroupSeq) & ",template_id =" & Str(nTemplateId), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            existInvoice = True
            Exit Function
        End Try

    End Function
	
	'Returns GIR percent value for the given ReportId
	Public Function get_percent(ByRef sCustId As String, ByRef sReportId As String) As String
		
        Dim rsLocal As DataTable
		
		'sStmt = "select distinct percent_value from rptglminvoice" _
		'& " where cust_id = '" & Trim(frmCustInvGen.cbCustId.Text) & "'" _
		'& " and report_id = " & IIf(Trim(frmCustInvGen.sReport_Id) = "", "0", frmCustInvGen.sReport_Id) _
		'& " and percent_value >0 "
		
		sStmt = "select distinct percent_value from rptglminvoice" & " where cust_id = '" & sCustId & "'" & " and report_id = " & IIf(Trim(sReportId) = "", "0", sReportId) & " and percent_value >0 "
		
		'cm.Execute nRecords
		rsLocal = exec_sql(sStmt)
		
        If rsLocal.Rows.Count > 0 Then
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            get_percent = IIf(IsDBNull(rsLocal.Rows(0).Item("percent_value")), 0, rsLocal.Rows(0).Item("percent_value"))
        Else
            get_percent = CStr(0)
        End If
		
		
	End Function
	
	
	'This method reads all new imported records from lf2gis_vinvoice
	'table and validates that references are correct, otherwise
	'records are marked as INVALID and not shown to the account manager
	'Parameters:
	'   custStr: is a comma seperated list of customer ids
	Public Sub validate_invoiceImport(ByRef custStr As String)
		Dim stmt As String
		Dim sCustId As String
		Dim nStoreId As Short
		Dim nVendSeq As Short
		Dim sAccountNo As String
		Dim sValidationComments As String
        Dim sInvoiceNo As String
        Dim bValid As Boolean
        Dim cmd As SqlCommand = cn.CreateCommand()
		
		stmt = "SELECT a.cust_id, a.store_id, a.vend_seq, " & " a.account_no, a.invoice_no, a.creation_date " & " FROM lf2gis_vinvoice a " & " WHERE a.cust_id IN (" & custStr & ")" & " AND a.status_flag ='NEW'"
        cmd.CommandText = stmt
		
        rs = getDataTable(stmt) ' cmd.ExecuteReader()


        For row As Integer = 0 To rs.Rows.Count - 1
            bValid = True
            sValidationComments = ""

            sCustId = rs.Rows(row).Item("cust_id")
            nStoreId = rs.Rows(row).Item("store_id")
            nVendSeq = rs.Rows(row).Item("vend_seq")
            sAccountNo = rs.Rows(row).Item("account_no")
            sInvoiceNo = rs.Rows(row).Item("invoice_no")

            'Store
            If Not valid_store(sCustId, nStoreId) Then
                bValid = False
                sValidationComments = sValidationComments & "Invalid StoreId"
            End If

            'Vendor
            If Not valid_vendor(nVendSeq) Then
                bValid = False
                sValidationComments = sValidationComments & " Invalid Vendor Seq"
            End If

            'Account
            If Not bValid Then
                update_lf2gis_vinvoice(sCustId, nStoreId, sAccountNo, nVendSeq, sInvoiceNo, "INVALID", sValidationComments)
            End If

        Next row

	End Sub
	
	Public Function valid_store(ByRef sCustId As String, ByRef nStoreId As Short) As Boolean
		Dim stmt As Object
		valid_store = True
        Dim cmd As SqlCommand = cn.CreateCommand()
        Dim rsStore As DataTable
		
		'UPGRADE_WARNING: Couldn't resolve default property of object stmt. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        stmt = "SELECT count(*) FROM store WHERE cust_id = '" & sCustId & "'" & " AND store_id = " & Str(nStoreId)
        cmd.CommandText = stmt
        rsStore = getDataTable(stmt) ' cmd.ExecuteReader() '.Open(stmt, cn, ADODB.CursorTypeEnum.adOpenStatic)
		
        If rsStore.Rows.Count > 0 Then
            If rsStore.Rows(0).Item(0) = 0 Then
                valid_store = False
            End If
        End If
		
	End Function
	Public Function valid_vendor(ByRef nVendSeq As Short) As Boolean
		Dim stmt As Object
        Dim cmd As SqlCommand = cn.CreateCommand()
        Dim rsVendor As DataTable
		
		valid_vendor = True
		
		'UPGRADE_WARNING: Couldn't resolve default property of object stmt. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        stmt = "SELECT count(*) FROM vbranch WHERE vend_seq =" & Str(nVendSeq)
        cmd.CommandText = stmt
        rsVendor = getDataTable(stmt) ' cmd.ExecuteReader()

        If rsVendor.Rows.Count > 0 Then
            If rsVendor.Rows(0).Item(0) = 0 Then
                valid_vendor = False
            End If
        End If
		
        'rsVendor.Close()
		
	End Function
	
    Public Sub update_lf2gis_vinvoice(ByRef sCustId As String, ByRef nStoreId As Short, ByRef sAccountNo As String, ByRef nVendSeq As Short, ByRef sInvoiceNo As String, ByRef sStatusFlag As String, ByRef sValidationComments As String, Optional ByRef nTran As SqlTransaction = Nothing)
        Dim stmt As String
        Dim cmInvoice As New SqlCommand

        stmt = "UPDATE lf2gis_vinvoice SET status_flag ='" & sStatusFlag & "', " & " validation_comments ='" & sValidationComments & "' " & " WHERE cust_id = '" & sCustId & "'" & " AND store_id = " & Str(nStoreId) & " AND account_no ='" & sAccountNo & "' " & " AND vend_seq = " & Str(nVendSeq) & " AND invoice_no = '" & sInvoiceNo & "' "

        cmInvoice = cn.CreateCommand '.let_ActiveConnection(cn)
        cmInvoice.CommandType = CommandType.Text

        If Not IsNothing(nTran) Then
            cmInvoice.Transaction = nTran
        End If

        cmInvoice.CommandText = stmt
        cmInvoice.ExecuteNonQuery()

    End Sub
	
	Public Sub insertInvoiceHeader(ByRef sCustId As String, ByRef sStoreId As String, ByRef sAccountNo As String, ByRef sVendSeq As String, ByRef sInvoiceNo As String)
        Dim stmt As String = ""
        Dim sNotes As String = ""
        Dim txtTotal As String = ""
        Dim txtYearPeriod As String = ""
        Dim cbMonthPeriod As String = ""
        Dim dtDate As String = ""
        Dim svendeq As String = ""
		
		'UPGRADE_WARNING: Couldn't resolve default property of object sNotes. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object txtTotal. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object txtYearPeriod. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object cbMonthPeriod. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object dtDate. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object svendeq. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object stmt. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		stmt = "INSERT INTO VInvoice " & "(cust_id, store_id, vend_seq, account_no, " & "invoice_no, vinvoice_date, " & "month_period, year_period, " & "total, vinvoice_status,notes)  VALUES " & "('" & Trim(sCustId) & "'," & sStoreId & ", " + svendeq + ", " + "'" + Trim(sAccountNo) + "', '" + Trim(sInvoiceNo) + "', " + "'" + CStr(dtDate) + "', '" + CStr(cbMonthPeriod) + "', '" + CStr(txtYearPeriod) + "', " + txtTotal + " ,'CRE'," + "'" + Trim(sNotes) + "')"
		
	End Sub
End Module