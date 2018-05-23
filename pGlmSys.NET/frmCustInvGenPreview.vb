Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Friend Class frmCustInvGenPreview
	Inherits System.Windows.Forms.Form
	Private Declare Function GetTempPath Lib "kernel32"  Alias "GetTempPathA"(ByVal nBufferLength As Integer, ByVal lpBuffer As String) As Integer
	
	Private Declare Function GetTempFileName Lib "kernel32"  Alias "GetTempFileNameA"(ByVal lpszPath As String, ByVal lpPrefixString As String, ByVal wUnique As Integer, ByVal lpTempFileName As String) As Integer
	
	
	Private oWord As Object 'Word Application
	Private iCust_invoice_seq As Integer
	Public stre As ADODB.Stream
	Public stmt As String
	Private nFile As String
	Private sFileSaved As Boolean
	
	Public Property Cust_invoice_seq() As Integer
		Get
			Cust_invoice_seq = iCust_invoice_seq
		End Get
		Set(ByVal Value As Integer)
			iCust_invoice_seq = Value
		End Set
	End Property
	
	
	'First version of word doc content generation
	Private Sub create_document_word_original()
		Dim nPorc As Object
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
		
		'jpdebug.begin. Commente to not open an empty doc
		'oWord.Documents.Add "Normal", False, 0
		'jpdebug.end
		
		'oWord.Application.Load App.Path & "\GLM_Watermark_Template.doc"
		'oWord.Documents.Open App.Path & "\GLM_Watermark_Template.doc"
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Documents. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Documents.Open(My.Application.Info.DirectoryPath & "\" & MSWORD_CUSTOMER_INVOICE_TEMPLATE)
		
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
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText(frmCustInvGen.txtInvoiceDate.Text)
		
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
		oWord.Selection.TypeText(Text_Renamed:="INVOICE")
		
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
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText(frmCustInvGen.txtAddress.Text)
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
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText("For the month of " & Trim(frmCustInvGen.txBillingPeriod.Text))
		'Format(period_start_date, "MMMM yyyy")
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText("ACCOUNT NO:" & Trim(frmCustInvGen.txtAccountNo.Text))
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText("INVOICE NO:" & Trim(frmCustInvGen.txtInvoiceNo.Text))
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText(frmCustInvGen.txtDescription.Text)
		
		
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
		
		
		
		
		'jp.121409.begin
		'oWord.Selection.TypeText vbTab & "Bill Payment: " & vbTab & frmCustInvGen.txtInvoiceTotal.Text
		'UPGRADE_WARNING: FormattedText has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText(vbTab & "Bill Payment: " & vbTab & frmCustInvGen.txtInvoiceTotal.Text)
		'jp.121409.end
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'jp.121409.begin
		'oWord.Selection.TypeText vbTab & "Savings: " & vbTab & frmCustInvGen.txtSavings.Text
		'UPGRADE_WARNING: FormattedText has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText(vbTab & "Total Savings: " & vbTab & frmCustInvGen.txtSavings.Text)
		'jp.121409.end
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		
		'oWord.Selection.TypeText vbTab & "GLM charges at " & frmCustInvGen.txtSavingsPercent.Text & "%: " & vbTab & Format((frmCustInvGen.txtSavings.Text * frmCustInvGen.txtSavingsPercent.Text / 100), "#######0.00")
		
		'UPGRADE_WARNING: Couldn't resolve default property of object nPorc. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		nPorc = get_percent((frmCustInvGen.cbCustId.Text), (frmCustInvGen.sReport_Id))
		'jp.121409.begin
		'oWord.Selection.TypeText vbTab & "GLM charges at " & nPorc & " %: " & vbTab & Format((frmCustInvGen.txtSavings.Text * nPorc / 100), "#######0.00")
		'UPGRADE_WARNING: Couldn't resolve default property of object nPorc. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText(vbTab & "GLM " & nPorc & " % of Savings: " & vbTab & VB6.Format(CDbl(frmCustInvGen.txtSavings.Text) * nPorc / 100, "$#,###,##0.00"))
		'jp.121409.end
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'jp.121409.begin
		'oWord.Selection.TypeText vbTab & "Store Flat Fee: " & vbTab & frmCustInvGen.txtStoreFlatFee.Text
		'UPGRADE_WARNING: FormattedText has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText(vbTab & "GLM Location Fee: " & vbTab & frmCustInvGen.txtStoreFlatFee.Text)
		'jp.121409.end
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		
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
		
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'jp.121409.begin
		'oWord.Selection.TypeText vbTab & "Grand Total: " & vbTab
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText(vbTab & "Total Amount Due: " & vbTab)
		'jp.121409.end
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object wdUnderlineDouble. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.Font.Underline = wdUnderlineDouble
		'jp.121409.begin
		'oWord.Selection.TypeText frmCustInvGen.txtGrandTotal.Text
		'UPGRADE_WARNING: FormattedText has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText(frmCustInvGen.txtGrandTotal.Text)
		'jp.121409.end
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object wdUnderlineNone. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.Font.Underline = wdUnderlineNone
		
		
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
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText(frmCustInvGen.txtGreeting.Text & vbCrLf)
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeParagraph()
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.Font.name = MSWORD_FONT_NAME
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.Font.size = MSWORD_FONT_SIZE
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Selection. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Selection.TypeText(Text_Renamed:=MSWORD_REMIT_ADDRESS)
		
		'oWord.Application.Save
		nFile = pFreeFile ' App.Path & "\tmp" & Trim(Cust_invoice_seq) '"C:\archivos\test2.doc"
		
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
		oWord.Documents.Close(False)
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Quit. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Quit(False)
		
		'oWord.Application.Close
		'oWord.ActiveDocument.SaveAs FileName:=.FileName, FileFormat:=wdFormatDocument, LockComments:=False, Password:="", AddToRecentFiles:=True, WritePassword:="", ReadOnlyRecommended:=False, EmbedTrueTypeFonts:=False, SaveNativePictureFormat:=False, SaveFormsData:=False, SaveAsAOCELetter:=False
		'OLEInvoice.CreateLink Nothing
		'UPGRADE_ISSUE: Ole method OLEInvoice.CreateLink was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'OLEInvoice.CreateLink(nFile) 'oWord.Application.ActiveDocument
		
		OLEInvoice.Refresh()
		
	End Sub
	'Refactored version to generate word doc content
	Public Sub create_document_word()
		Dim sTemplateFile As String
		Dim flags As gWordDocFlagUDT
		
		
		'Doc Variables
        Dim wordDoc As gWordDocUDT = New gWordDocUDT()
		wordDoc.sInvoiceDate = frmCustInvGen.txtInvoiceDate.Text
		wordDoc.sAddress = frmCustInvGen.txtAddress.Text
		wordDoc.sBillingPeriod = frmCustInvGen.txBillingPeriod.Text
		wordDoc.sAccountNo = frmCustInvGen.txtAccountNo.Text
		wordDoc.sInvoiceNo = frmCustInvGen.txtInvoiceNo.Text
		wordDoc.sDescription = frmCustInvGen.txtDescription.Text
		'UPGRADE_WARNING: FormattedText has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		wordDoc.sInvoiceTotalFormatted = frmCustInvGen.txtInvoiceTotal.Text
		'UPGRADE_WARNING: FormattedText has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		wordDoc.sSavingsFormatted = frmCustInvGen.txtSavings.Text
		wordDoc.sSavings = frmCustInvGen.txtSavings.Text
		wordDoc.sPercent = get_percent((frmCustInvGen.cbCustId.Text), (frmCustInvGen.sReport_Id))
		'UPGRADE_WARNING: FormattedText has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		wordDoc.sStoreFlatFeeFormatted = frmCustInvGen.txtStoreFlatFee.Text
		'UPGRADE_WARNING: FormattedText has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		wordDoc.sGrandTotalFormatted = frmCustInvGen.txtGrandTotal.Text
		wordDoc.sLocation = frmCustInvGen.txtLocation.Text
		
		wordDoc.rsStoreGroup = frmCustInvGen.rsStoreGroup
		
		
		
		
		
		'Get Tmp file
		nFile = pFreeFile
		
		'Get Word doc template filename
		sTemplateFile = get_msword_template((frmCustInvGen.cbTemplate.Text))
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(sTemplateFile) Or sTemplateFile = "" Then
			sTemplateFile = gGlobSettings.sMswordTemplateFile
		End If
		
		'jp.20110102.begin
		'Added Flags
		If frmCustInvGen.ckSavingsPercent.CheckState = System.Windows.Forms.CheckState.Checked Then
			flags.bSavingsPercent = True
		Else
			flags.bSavingsPercent = False
		End If
		
		If frmCustInvGen.ckStoreFlatFee.CheckState = System.Windows.Forms.CheckState.Checked Then
			flags.bStoreFlatFee = True
		Else
			flags.bStoreFlatFee = False
		End If
		
		If frmCustInvGen.ckInvoiceFee.CheckState = System.Windows.Forms.CheckState.Checked Then
			flags.bInvoiceFee = True
		Else
			flags.bInvoiceFee = False
		End If
		
		If frmCustInvGen.ckTax.CheckState = System.Windows.Forms.CheckState.Checked Then
			flags.bTax = True
		Else
			flags.bTax = False
		End If
		
		If frmCustInvGen.ckGrandTotal.CheckState = System.Windows.Forms.CheckState.Checked Then
			flags.bTotal = True
		Else
			flags.bTotal = False
		End If
		'jp.20110102.end
		
		
		If frmCustInvGen.ckLocation.CheckState = System.Windows.Forms.CheckState.Checked Then
			flags.bLocation = True
		Else
			flags.bLocation = False
		End If
		
		If frmCustInvGen.ckTotalByStoreGroup.CheckState = System.Windows.Forms.CheckState.Checked Then
			flags.bTotalByStoreGroup = True
		Else
			flags.bTotalByStoreGroup = False
		End If
		
		'Populate content
		'jp.20110102.begin
		create_document_word_content(oWord, wordDoc, nFile, sTemplateFile, flags)
		'create_document_word_content oWord, wordDoc, nFile, sTemplateFile
        'jp.20110102.end
        frmCustInvGenBrowser.WebBrowser1.Navigate(nFile)
		'Link Tmp file onto OLE container
		'UPGRADE_ISSUE: Ole method OLEInvoice.CreateLink was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'OLEInvoice.CreateLink(nFile) 'oWord.Application.ActiveDocument
		OLEInvoice.Refresh()
	End Sub
	
	
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub cmdEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEdit.Click
		oleOpenForEdition()
	End Sub
	
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
		Dim j As Object
		Dim i As Object
		Dim oWord As Object
		oWord = CreateObject("Word.Application")
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Visible. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Visible = False
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Documents. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Documents.Add("Normal", False, 0)
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Documents. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Documents.Open(nFile) ' App.Path & "\template\Customer Invoice Generation.doc"
		
		'Clipboard.Clear
		'Clipboard.SetText txText.TextRTF, vbCFRTF
		'oWord.Selection.Paste
		'Clipboard.Clear
		
		' Imprime el documento activo con Printout
		For i = 1 To 10000
			For j = 1 To 1000
			Next 
		Next 
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.ActiveDocument. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.ActiveDocument.PrintOut()
		For i = 1 To 10000
			For j = 1 To 1000
			Next 
		Next 
		
		' Cierra el documento
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Documents. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Documents.Close(False)
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Quit. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Quit(False)
		
		
		' Elimina la referencia
		'UPGRADE_NOTE: Object oWord may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oWord = Nothing
		
		'OLEInvoice.object.ActiveDocument.PrintOut 'Copies:=1, collate:=True
		'UPGRADE_ISSUE: Ole property OLEInvoice.AppIsRunning was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'OLEInvoice.AppIsRunning = False
		'Printer.PaintPicture OLEInvoice.Picture, 0, 0, 2000, 2000
		'OLEInvoice.AppIsRunning = False
	End Sub
	
	Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click
		'UPGRADE_ISSUE: Ole property OLEInvoice.AppIsRunning was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'If OLEInvoice.AppIsRunning Then
        MsgBox("Please close Word Application before attempting this command", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GLM Warning")
        'Else
        saveDocToDB()
        'End If
		
	End Sub
	
	Public Sub saveDocToDB()
        Dim rs As New DataTable
		''''''
		''''''
		''''''    wdAlignParagraphJustify = 3
		''''''    wdAlignParagraphCenter = 1
		''''''    wdAlignTabDecimal = 3
		''''''    wdTabLeaderSpaces = 0
		''''''    wdAlignTabLeft = 0
		''''''    wdFormatDocument = 0
		''''''
		''''''    wdUnderlineSingle = 1
		''''''    wdUnderlineDouble = 3
		''''''    wdUnderlineNone = 0
		''''''
		''''''    wdToggle = 9999998
		''''''
		''''''    With CommonDialog1
		''''''
		''''''         .DialogTitle = " Guardar documento como..."
		''''''         .Filter = "Archivos de Word|*.doc|"
		''''''
		''''''         .ShowSave
		''''''
		''''''         If .FileName = vbNullString Then
		''''''            Exit Sub
		''''''         End If
		''''''
		''''''         Me.Caption = .FileName
		''''''
		''''''
		''''''        On Local Error Resume Next
		''''''        oWord.ActiveDocument.SaveAs FileName:=.FileName, FileFormat:=wdFormatDocument, _
		'''''''            LockComments:=False, Password:="", AddToRecentFiles:=True, WritePassword:="", _
		'''''''            ReadOnlyRecommended:=False, EmbedTrueTypeFonts:=False, _
		'''''''            SaveNativePictureFormat:=False, SaveFormsData:=False, SaveAsAOCELetter:=False
		''''''        If Err.Number <> 0 Then
		''''''            MsgBox Err.Description & vbCrLf, vbCritical, ""
		''''''        Else
		''''''            MsgBox "Document saved...!"
		''''''        End If
		''''''        On Local Error GoTo 0
		''''''
		''''''
		''''''
		''''''
		''''''
		''''''        insert_document .FileName
		''''''
		''''''
		''''''
		''''''
		''''''        ' ***********************************************************
		''''''        Unload Me
		''''''
		''''''     End With
		
		
		If iCust_invoice_seq = 0 Then
			MsgBox("Failed to update in Transaction table. " & vbCrLf & "Review logfile for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
			Exit Sub
		End If
		
		
		'Dim nFile As Integer
		'Dim sFile As String
		
		
		'sFile = "C:\archivos\test.doc"
		'sFile = App.Path & "\tmp" & Trim(Cust_invoice_seq)
		'sFile = saveOleAsFile
		
		stre = New ADODB.Stream
		stre.Open()
		stre.Type = ADODB.StreamTypeEnum.adTypeBinary
		
		'OLEInvoice.SourceDoc = Nothing
		'OLEInvoice.SaveToFile
		'OLEInvoice.CreateLink ""  'nFile 'oWord.Application.ActiveDocument
		'OLEInvoice.Refresh
		
		
		Close()
		
		
		'oWord.Application.Close
		'nFile2 = Mid$(nFile, 1, Len(nFile) - 3) & "doc"
		'OLEInvoice.SaveToFile 1
		
		stre.LoadFromFile(nFile)
		
		stmt = "SELECT * FROM customerInvoice WHERE Cust_invoice_seq = " & Cust_invoice_seq
		
        rs = getDataTable(stmt) '.Open(stmt, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        rs.Rows(0).Item("filecontent").value = stre.Read

        stre.Close()
		
		'cn.Close
		
		'UPGRADE_ISSUE: Ole method OLEInvoice.CreateLink was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'OLEInvoice.CreateLink(nFile)
		
		sFileSaved = True
		
		MsgBox("File was saved", MsgBoxStyle.OKOnly, "GLM Message")
		
	End Sub
	
	Public Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
		loadDocFromDbToOle()
	End Sub
	'This method Loads a document to a OLE container:
	'1. Reads the contents of a Word document from customerInvoice table onto a Stream
	'2. The Stream saves the binary content to a temporary file
	'3. The temporary file is use as source of an OLE container for edition
	Public Sub loadDocFromDbToOle()
		'Dim nFile As Integer
		
		'Dim sFile As String
		'sFile = App.Path & "\tmp" & Trim(Cust_invoice_seq) '"C:\archivos\test2.doc"
        Dim rs As New DataTable
		stmt = "SELECT * FROM customerInvoice WHERE cust_invoice_seq= " & Cust_invoice_seq
		
		'rs.Close
		
		
        rs = getDataTable(stmt) '.Open(stmt, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(rs.Rows(0).Item("filecontent").value) Then
            Exit Sub
        Else
            stre = New ADODB.Stream
            stre.Open()
            stre.Type = ADODB.StreamTypeEnum.adTypeBinary
            stre.Write(rs.Rows(0).Item("filecontent").value)

            nFile = pFreeFile()
            stre.SaveToFile(nFile, ADODB.SaveOptionsEnum.adSaveCreateOverWrite)




            'Open sFile For Input As #nFile

            'UPGRADE_ISSUE: Ole property OLEInvoice.SourceDoc was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'OLEInvoice.SourceDoc = nFile
            'UPGRADE_ISSUE: Ole method OLEInvoice.CreateLink was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'OLEInvoice.CreateLink(nFile) 'oWord.Application.ActiveDocument
            OLEInvoice.Refresh()

            sFileSaved = True

            'OLE2.ReadFromFile nFile
        End If
		
	End Sub
	'Private Function pFreeFile() As String
	'    pFreeFile = App.Path & "\tmp" & Right(Year(Date), 1) & Right("00" & Trim(Month(Date)), 2)
	'End Function
	
	
	'Private Function pFreeFile2() As String
	'        Dim sTmpPath As String * 512
	'        Dim sTmpName As String * 576
	'        Dim nRet As Long
	'
	'        sPrefix = "VBT"
	
	'        nRet = GetTempPath(512, sTmpPath)
	'        If (nRet > 0 And nRet < 512) Then
	'           nRet = GetTempFileName(sTmpPath, sPrefix, 0, sTmpName)
	
	'           If nRet <> 0 Then
	'               pFreeFile = Left$(sTmpName, _
	''                 InStr(sTmpName, vbNullChar) - 1)
	'          End If
	'        End If
	'End Function
	
	Private Sub frmCustInvGenPreview_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		OLEInvoice.SetBounds(VB6.TwipsToPixelsX(10), 0, VB6.TwipsToPixelsX(1.4 * VB6.PixelsToTwipsX(ClientRectangle.Width)), VB6.TwipsToPixelsY(1.2 * VB6.PixelsToTwipsY(ClientRectangle.Height)))
		iCust_invoice_seq = 0
		sFileSaved = False
	End Sub
	
	'UPGRADE_WARNING: Event frmCustInvGenPreview.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmCustInvGenPreview_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		Dim NewLargeChange As Short
		' Posicionar las barras de desplazamiento (scroll bars):
		On Error Resume Next
		HScroll1.Left = 0
		VScroll1.Top = 0
		
		If VB6.PixelsToTwipsX(OLEInvoice.Width) > VB6.PixelsToTwipsX(ClientRectangle.Width) Then
			
			HScroll1.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(ClientRectangle.Height) - VB6.PixelsToTwipsY(HScroll1.Height) - 800)
			
		Else
			
			HScroll1.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(ClientRectangle.Height) - 800)
			
		End If
		
		If VB6.PixelsToTwipsY(OLEInvoice.Height) > VB6.PixelsToTwipsY(HScroll1.Top) Then
			
			VScroll1.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(ClientRectangle.Width) - VB6.PixelsToTwipsX(VScroll1.Width))
			
			If VB6.PixelsToTwipsX(OLEInvoice.Width) > VB6.PixelsToTwipsX(VScroll1.Left) Then
				
				HScroll1.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(ClientRectangle.Height) - VB6.PixelsToTwipsY(HScroll1.Height) - 800)
				
			End If
			
		Else
			
			VScroll1.Left = ClientRectangle.Width
			
		End If
		
		
		Me.Frame1.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(HScroll1.Top) + 180)
		Me.Frame1.Width = Me.Width
		
		HScroll1.Width = ClientRectangle.Width
		VScroll1.Height = HScroll1.Top
		
		' Establecer los rangos de las barras de desplazamiento
		HScroll1.Maximum = (VB6.PixelsToTwipsX(OLEInvoice.Width) - VB6.PixelsToTwipsX(VScroll1.Left) + HScroll1.LargeChange - 1)
		VScroll1.Maximum = (VB6.PixelsToTwipsY(OLEInvoice.Height) - VB6.PixelsToTwipsY(HScroll1.Top) + VScroll1.LargeChange - 1)
		HScroll1.SmallChange = System.Math.Abs((HScroll1.Maximum - HScroll1.LargeChange + 1) \ 16) + 1
		NewLargeChange = System.Math.Abs((HScroll1.Maximum - HScroll1.LargeChange + 1) \ 4) + 1
		HScroll1.Maximum = HScroll1.Maximum + NewLargeChange - HScroll1.LargeChange
		HScroll1.LargeChange = NewLargeChange
		VScroll1.SmallChange = System.Math.Abs((VScroll1.Maximum - VScroll1.LargeChange + 1) \ 16) + 1
		NewLargeChange = System.Math.Abs((VScroll1.Maximum - VScroll1.LargeChange + 1) \ 4) + 1
		VScroll1.Maximum = VScroll1.Maximum + NewLargeChange - VScroll1.LargeChange
		VScroll1.LargeChange = NewLargeChange
		HScroll1.BringToFront()
		VScroll1.BringToFront()
		On Error GoTo 0
	End Sub
	
	'UPGRADE_NOTE: HScroll1.Change was changed from an event to a procedure. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"'
	'UPGRADE_WARNING: HScrollBar event HScroll1.Change has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Sub HScroll1_Change(ByVal newScrollValue As Integer)
		
		OLEInvoice.Left = VB6.TwipsToPixelsX(-newScrollValue)
		
	End Sub
	
	
	'UPGRADE_NOTE: VScroll1.Change was changed from an event to a procedure. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"'
	'UPGRADE_WARNING: VScrollBar event VScroll1.Change has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Sub VScroll1_Change(ByVal newScrollValue As Integer)
		
		OLEInvoice.Top = VB6.TwipsToPixelsY(-newScrollValue)
		
	End Sub
	
	Private Sub delete_record()
		Dim nDbTran As Object
        Dim nRecords As Integer = 0
		sStmt = "DELETE FROM CustomerInvoice WHERE cust_invoice_seq=" & Trim(CStr(Cust_invoice_seq))
		
        cm = cn.CreateCommand
		
        cm.CommandType = CommandType.Text
		cm.CommandText = sStmt
		
        nRecords = cm.ExecuteNonQuery()
		'UPGRADE_WARNING: Couldn't resolve default property of object nRecords. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If nRecords > 0 Then
			'ok
			'insert_document = True
		Else
			'cn.RollbackTrans
			'UPGRADE_WARNING: Couldn't resolve default property of object nDbTran. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			nDbTran = 0
			MsgBox("Failed to delete in Transaction table. " & vbCrLf & "Review logfile for details.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
			'Unload Me
		End If
	End Sub
	
	Private Sub frmCustInvGenPreview_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'jpdebug.begin
		'UPGRADE_ISSUE: Ole property OLEInvoice.AppIsRunning was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'If OLEInvoice.AppIsRunning Then
        '	MsgBox("Please close Word document before continuing", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "GLM Warning")
        '	'UPGRADE_ISSUE: Event parameter Cancel was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
        '	Cancel = True
        '	Exit Sub

        'End If
		'jpdebug.end
		
		On Error Resume Next
		'UPGRADE_WARNING: Couldn't resolve default property of object oWord.Quit. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oWord.Quit(False)
		'UPGRADE_NOTE: Object oWord may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oWord = Nothing
		On Error GoTo 0
		
		If sFileSaved = False Then
			delete_record()
		End If
		
		sFileSaved = False
		'OLEInvoice.Action = 7
		
		'UPGRADE_ISSUE: Ole property OLEInvoice.AppIsRunning was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'OLEInvoice.AppIsRunning = True
		'OLEInvoice.object.Documents.Close ':=False
		'OLEInvoice.object.ActiveDocuments.Quit False
        'Close()
		'UPGRADE_ISSUE: Ole method OLEInvoice.Delete was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'OLEInvoice.Delete()
		
		
		
		'OLEInvoice.object.Application.wordbasic.vLine 1
		'    If OLEInvoice.AppIsRunning Then
		'        'Set OLEInvoice.LpOleObject = Nothing
		'        Set OLEInvoice.object = Nothing
		'    End If
		'Set OLEInvoice = Nothing
		'oleinvoice.close
		
		'On Local Error GoTo 0
	End Sub
	'2012.01.17 Changed from Sub to Function to find out if whole method completes sucessfully
	'Saves header information about invoice in CustomerInvoice table
	Public Function build_document() As Boolean
        Dim nDbTran As SqlTransaction
        Dim nRecords As Integer = 0
        Dim rsLocal As DataTable
		
		build_document = False

		'***********************************************************************
		'
		'     Get last sequence number...
		'
		'***********************************************************************
		sStmt = "SELECT max(cust_invoice_seq) as iSeq " & " FROM CustomerInvoice "

        Try
            rsLocal = exec_sql(sStmt)
        Catch e As sqlException
            MsgBox("Your Account does not have access to such Information." & vbCrLf & "Contact your System Administrator to get proper access.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
            'insert_document = False
            Me.Close()
            Exit Function

        End Try

        'UPGRADE_WARNING: Couldn't resolve default property of object rsLocal.RecordCount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If rsLocal.rows.count <= 0 Then
            MsgBox("No GIR report was found for selected combination: " & vbCrLf & "Customer, Period", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
            'insert_document = False
            Me.Close()
            Exit Function
        End If


        'UPGRADE_WARNING: Couldn't resolve default property of object rsLocal.Fields. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        Cust_invoice_seq = IIf(IsDBNull(rsLocal.Rows(0).Item("iSeq")), 0, rsLocal.Rows(0).Item("iSeq")) + 1

        '01.17.2012.begin
        'Check for duplicates
        'ByRef sCustId As String, ByRef nPeriodSeq As Short, ByRef nGroupSeq As Short, ByRef nTemplateId As Short, ByRef nSelectedId As Short

        Dim sCustId As String = VB6.GetItemData(frmCustInvGen.cbCustId, frmCustInvGen.cbCustId.SelectedIndex) 'frmCustInvGen.cbCustId.SelectedValue.ToString
        Dim nPeriodSeq As Short = VB6.GetItemData(frmCustInvGen.cbPeriod, frmCustInvGen.cbPeriod.SelectedIndex)
        Dim nGroupSeq As Short = VB6.GetItemData(frmCustInvGen.cbGroupStore, frmCustInvGen.cbGroupStore.SelectedIndex)

        Dim tmpltId As Integer = frmCustInvGen.cbTemplate.SelectedIndex
        'Dim nTemplateId As Short
        If tmpltId < 0 Then
            tmpltId = -1
        Else
            tmpltId = VB6.GetItemData(frmCustInvGen.cbTemplate, frmCustInvGen.cbTemplate.SelectedIndex)
        End If

        Dim nSelectedId As Short = VB6.GetItemData(frmCustInvGen.cbCustName, frmCustInvGen.cbCustName.SelectedIndex)

        'If hasDuplicateInvoice((frmCustInvGen.cbCustId.Text), VB6.GetItemData(frmCustInvGen.cbPeriod, frmCustInvGen.cbPeriod.SelectedIndex), VB6.GetItemData(frmCustInvGen.cbGroupStore, frmCustInvGen.cbGroupStore.SelectedIndex), VB6.GetItemData(frmCustInvGen.cbTemplate, frmCustInvGen.cbTemplate.SelectedIndex), iCustInvGenSelId) Then
        If hasDuplicateInvoice(sCustId, nPeriodSeq, nGroupSeq, tmpltId, nSelectedId) Then
            MsgBox("Document was aborted. Found a duplicate Customer Invoice for this combination of Customer, Period and Group", MsgBoxStyle.OkOnly, "GLM Warning")

            Exit Function
        End If
        '01.17.2012.end


        '***********************************************************************
        '
        '    Inserting data...
        '
        '***********************************************************************

        sStmt = "INSERT INTO CustomerInvoice (cust_invoice_seq, cust_id , invoice_date, invoice_date_desc, " & _
                " Address, period_seq, billing_period, account_no, " & _
                "invoice_no, body_desc, invoice_total, savings, savings_percent, store_flag_fee," & _
                "invoice_fee , tax, grand_total, greeting_desc, fileName, group_seq, template_id, id) " & _
                " VALUES (@cust_invoice_seq, @cust_id , @invoice_date, @invoice_date_desc," & _
                         "@Address, @period_seq, @billing_period, @account_no," & _
                         "@invoice_no, @body_desc, @invoice_total, @savings, @savings_percent, @store_flag_fee," & _
                         "@invoice_fee , @tax, @grand_total, @greeting_desc, @fileName, @group_seq, @template_id, @id) " ' & _?,?,?,?,?,?,?,?,?,?,?,?,?, ?)"

        nDbTran = cn.BeginTransaction("trans")
        cm = cn.CreateCommand
        cm.Transaction = nDbTran


        With frmCustInvGen

            create_param_rs("cust_invoice_seq", SqlDbType.VarChar, ParameterDirection.Input, Trim(CStr(Cust_invoice_seq)), cm, 6)
            create_param_rs("cust_id", SqlDbType.VarChar, ParameterDirection.Input, Trim(.cbCustId.Text), cm, 2)
            create_param_rs("invoice_date", SqlDbType.VarChar, ParameterDirection.Input, VB.Left(.dtInvoiceDate.Value, 10), cm, 10)
            create_param_rs("invoice_date_desc", SqlDbType.VarChar, ParameterDirection.Input, VB.Left(.txtInvoiceDate.Text, 50), cm, 50)
            create_param_rs("address", SqlDbType.VarChar, ParameterDirection.Input, VB.Left(.txtAddress.Text, 200), cm, 200)
            create_param_rs("period_seq", SqlDbType.Int, ParameterDirection.Input, VB6.GetItemData(.cbPeriod, .cbPeriod.SelectedIndex), cm, 10)
            create_param_rs("billing_period", SqlDbType.VarChar, ParameterDirection.Input, VB.Left(.txBillingPeriod.Text, 50), cm, 50)
            create_param_rs("account_no", SqlDbType.VarChar, ParameterDirection.Input, VB.Left(.txtAccountNo.Text, 50), cm, 50)
            create_param_rs("invoice_no", SqlDbType.VarChar, ParameterDirection.Input, VB.Left(.txtInvoiceNo.Text, 50), cm, 50)
            create_param_rs("body_desc", SqlDbType.VarChar, ParameterDirection.Input, VB.Left(.txtDescription.Text, 500), cm, 500)

            create_param_rs("invoice_total", SqlDbType.Float, ParameterDirection.Input, (.txtInvoiceTotal.Text), cm, 16)


            create_param_rs("savings", SqlDbType.Float, ParameterDirection.Input, (.txtSavings.Text), cm, 16)
            create_param_rs("savings_percent", SqlDbType.Float, ParameterDirection.Input, (.txtSavingsPercent.Text), cm, 16)
            create_param_rs("store_flag_fee", SqlDbType.Float, ParameterDirection.Input, (.txtStoreFlatFee.Text), cm, 16)
            create_param_rs("invoice_fee", SqlDbType.Float, ParameterDirection.Input, (.txtInvoiceFee.Text), cm, 16)
            create_param_rs("tax", SqlDbType.Float, ParameterDirection.Input, (.txtTax.Text), cm, 16)
            create_param_rs("grand_total", SqlDbType.Float, ParameterDirection.Input, (.txtGrandTotal.Text), cm, 16)

            create_param_rs("greeting_desc", SqlDbType.VarChar, ParameterDirection.Input, (.txtGreeting.Text), cm, 500)
            create_param_rs("fileName", SqlDbType.VarChar, ParameterDirection.Input, "", cm, 200)

            If VB6.GetItemData(.cbGroupStore, .cbGroupStore.SelectedIndex) = 0 Then
                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                create_param_rs("group_seq", SqlDbType.Int, ParameterDirection.Input, System.DBNull.Value, cm, 6)
            Else
                create_param_rs("group_seq", SqlDbType.Int, ParameterDirection.Input, VB6.GetItemData(.cbGroupStore, .cbGroupStore.SelectedIndex), cm, 6)
            End If

            create_param_rs("template_id", SqlDbType.Int, ParameterDirection.Input, tmpltId, cm, 6)

            create_param_rs("id", SqlDbType.Int, ParameterDirection.Input, .nSelectedId, cm, 6)
        End With

        'cm = cn.CreateCommand '.let_ActiveConnection(cn)
        cm.CommandType = CommandType.Text
        cm.CommandText = sStmt

        '    cm.Execute

        'cm.Parameters("template_id")
        Try
            nRecords = cm.ExecuteNonQuery()
            'UPGRADE_WARNING: Couldn't resolve default property of object nRecords. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If nRecords > 0 Then
                nDbTran.Commit()
                'ok
                'insert_document = True
            End If
        Catch e As Exception

            'cn.RollbackTrans
            'UPGRADE_WARNING: Couldn't resolve default property of object nDbTran. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            nDbTran.Rollback()
            MsgBox("Failed to insert in Transaction table. " & vbCrLf & "Review logfile for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            Me.Close()
            'insert_document = False
            'Exit Function
        End Try

        'Dim nFile As Integer
        'Dim sFile As String
        'sFile = App.Path & "\tmp" & Trim(Cust_invoice_seq) '"C:\archivos\test2.doc"


        'jpdebug.begin.013010
        create_document_word()
        oleOpenForEdition()
        'jpdebug.end

        '2012.01.17.begin
        'If this point was reach then everything run smoothly
        build_document = True
        '2012.01.17.end

        'stre.Open
        'stre.Type = adTypeBinary
        'stre.Write rs("filecontent").value

        'stre.SaveToFile sFile, adSaveCreateOverWrite


        'nFile = FreeFile()

        'Open sFile For Input As #nFile

        '''''OLEInvoice.SourceDoc = sFile
        'OLE2.ReadFromFile sFile

    End Function

    Private Sub insert_document(ByRef nFile As String)
        Dim nDbTran As SqlTransaction
        Dim nRecords As Integer = 0
        Dim iSeq As Object
        Dim rsLocal As DataTable

        'cust_id CHAR(2) NOT NULL,
        '  invoice_date SMALLDATETIME,
        '  invoice_date_desc VARCHAR(50),
        '  address VARCHAR(200),
        '  period_seq INT,
        '  billing_period VARCHAR(50),
        '  account_no VARCHAR(50),
        '  invoice_no VARCHAR(50),
        '  body_desc VARCHAR(500),
        '  invoice_total DECIMAL(16,2),
        '  savings DECIMAL(16,2),
        '  savings_percent DECIMAL(16,2),
        '  store_flag_fee DECIMAL(16,2),
        '  invoice_fee DECIMAL(16,2),
        '  tax DECIMAL(16,2),
        '  grand_total DECIMAL (16,2),
        '  greeting_desc VarChar(500)
        '

        '***********************************************************************
        '
        '     Obtener último secuencial...!!!
        '
        '***********************************************************************
        sStmt = "SELECT max(cust_invoice_seq) as iSeq " & " FROM CustomerInvoice "

        Try
            rsLocal = exec_sql(sStmt)

            'UPGRADE_WARNING: Couldn't resolve default property of object rsLocal.State. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Catch
            MsgBox("Your Account does not have access to such Information." & vbCrLf & "Contact your System Administrator to get proper access.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
            'insert_document = False
            Exit Sub
        End Try
        'UPGRADE_WARNING: Couldn't resolve default property of object rsLocal.RecordCount. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If rsLocal.Rows.Count <= 0 Then
            MsgBox("No GIR report was found for selected combination: " & vbCrLf & "Customer, Period", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Warning")
            'insert_document = False
            Exit Sub
        End If


        'UPGRADE_WARNING: Couldn't resolve default property of object rsLocal.Fields. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'UPGRADE_WARNING: Couldn't resolve default property of object iSeq. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        iSeq = IIf(IsDBNull(rsLocal.Rows(0).Item("iSeq")), 0, rsLocal.Rows(0).Item("iSeq")) + 1


        '***********************************************************************
        '
        '    Inertando datos...!!!!
        '
        '***********************************************************************

        sStmt = "INSERT INTO CustomerInvoice (cust_invoice_seq, cust_id , invoice_date, invoice_date_desc, " & " Address, period_seq, billing_period, account_no, " & "invoice_no, body_desc, invoice_total, savings, savings_percent, store_flag_fee," & "invoice_fee , tax, grand_total, greeting_desc, fileName, group_seq) " & " VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

        cm = cn.CreateCommand
        nDbTran = cn.BeginTransaction
        cm.Transaction = nDbTran

        With frmCustInvGen

            'UPGRADE_WARNING: Couldn't resolve default property of object iSeq. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            create_param_rs("cust_invoice_seq", DbType.Int32, ParameterDirection.Input, Trim(iSeq), cm, 6)
            create_param_rs("cust_id", SqlDbType.VarChar, ParameterDirection.Input, Trim(.cbCustId.Text), cm, 2)
            create_param_rs("invoice_date", DbType.String, ParameterDirection.Input, VB.Left(.dtInvoiceDate.Value, 10), cm, 10)
            create_param_rs("invoice_date_desc", DbType.String, ParameterDirection.Input, VB.Left(.txtInvoiceDate.Text, 50), cm, 50)
            create_param_rs("address", DbType.String, ParameterDirection.Input, VB.Left(.txtAddress.Text, 200), cm, 200)
            create_param_rs("period_seq", DbType.Int32, ParameterDirection.Input, VB6.GetItemData(.cbPeriod, .cbPeriod.SelectedIndex), cm, 10)
            create_param_rs("billing_period", DbType.String, ParameterDirection.Input, VB.Left(.txBillingPeriod.Text, 50), cm, 50)
            create_param_rs("account_no", DbType.String, ParameterDirection.Input, VB.Left(.txtAccountNo.Text, 50), cm, 50)
            create_param_rs("invoice_no", DbType.String, ParameterDirection.Input, VB.Left(.txtInvoiceNo.Text, 50), cm, 50)
            create_param_rs("body_desc", DbType.String, ParameterDirection.Input, VB.Left(.txtDescription.Text, 500), cm, 500)

            create_param_rs("invoice_total", ADODB.DataTypeEnum.adDouble, ParameterDirection.Input, (.txtInvoiceTotal.Text), cm, 16)
            create_param_rs("savings", ADODB.DataTypeEnum.adDouble, ParameterDirection.Input, (.txtSavings.Text), cm, 16)
            create_param_rs("savings_percent", ADODB.DataTypeEnum.adDouble, ParameterDirection.Input, (.txtSavingsPercent.Text), cm, 16)
            create_param_rs("store_flag_fee", ADODB.DataTypeEnum.adDouble, ParameterDirection.Input, (.txtStoreFlatFee.Text), cm, 16)
            create_param_rs("invoice_fee", ADODB.DataTypeEnum.adDouble, ParameterDirection.Input, (.txtInvoiceFee.Text), cm, 16)
            create_param_rs("tax", ADODB.DataTypeEnum.adDouble, ParameterDirection.Input, (.txtTax.Text), cm, 16)
            create_param_rs("grand_total", ADODB.DataTypeEnum.adDouble, ParameterDirection.Input, (.txtGrandTotal.Text), cm, 16)

            create_param_rs("greeting_desc", DbType.String, ParameterDirection.Input, (.txtGreeting.Text), cm, 500)
            create_param_rs("fileName", DbType.String, ParameterDirection.Input, VB.Left(nFile, 200), cm, 200)
            create_param_rs("group_seq", DbType.Int32, ParameterDirection.Input, VB6.GetItemData(.cbGroupStore, .cbGroupStore.SelectedIndex), cm, 6)
        End With

        cm = cn.CreateCommand '.let_ActiveConnection(cn)
        cm.CommandType = CommandType.Text
        cm.CommandText = sStmt
        '    cm.Execute
        nRecords = cm.ExecuteNonQuery()
        'UPGRADE_WARNING: Couldn't resolve default property of object nRecords. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If nRecords > 0 Then
            nDbTran.Commit()
            'ok
            'insert_document = True
        Else
            nDbTran.Rollback()
            'cn.RollbackTrans
            'UPGRADE_WARNING: Couldn't resolve default property of object nDbTran. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'

            MsgBox("Failed to insert in Transaction table. " & vbCrLf & "Review logfile for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            'insert_document = False
            'Exit Function
        End If

    End Sub
	
	
	Public Sub oleOpenForEdition()
		'UPGRADE_ISSUE: Ole property OLEInvoice.OLETypeAllowed was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'OLEInvoice.OLETypeAllowed = 1
		'jpdebug.begin
		'OLEInvoice.Verb = 2 'Open Application to edit document
		'Me.OLEInvoice.Action = 7
		'UPGRADE_ISSUE: Constant vbOLEOpen was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'UPGRADE_ISSUE: Ole method OLEInvoice.DoVerb was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'OLEInvoice.DoVerb(vbOLEOpen)
		'jpdebug.end
	End Sub
	
	'Check that Customer invoice exists
	Public Function hasDuplicateInvoice(ByRef sCustId As String, ByRef nPeriodSeq As Short, ByRef nGroupSeq As Short, ByRef nTemplateId As Short, ByRef nSelectedId As Short) As Boolean
		
		Dim sql As String
        Dim rsDup As DataTable
		
		hasDuplicateInvoice = False
		
		If nGroupSeq = 0 Then
			sql = "SELECT cust_invoice_seq FROM CustomerInvoice " & " WHERE cust_id = '" & sCustId & "' " & " AND period_seq = " & Str(nPeriodSeq) & " AND group_seq IS NULL " & " AND template_id =" & Str(nTemplateId)
		Else
			sql = "SELECT cust_invoice_seq FROM CustomerInvoice " & " WHERE cust_id = '" & sCustId & "' " & " AND period_seq = " & Str(nPeriodSeq) & " AND group_seq = " & Str(nGroupSeq) & " AND template_id =" & Str(nTemplateId)
		End If
		
		
        rsDup = getDataTable(sql) '.Open(sql, cn, ADODB.CursorTypeEnum.adOpenStatic)

        If rsDup.Rows.Count > 0 Then
            hasDuplicateInvoice = True
        End If
		
	End Function
	Private Sub HScroll1_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles HScroll1.Scroll
		Select Case eventArgs.type
			Case System.Windows.Forms.ScrollEventType.EndScroll
				HScroll1_Change(eventArgs.newValue)
		End Select
	End Sub
	Private Sub VScroll1_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles VScroll1.Scroll
		Select Case eventArgs.type
			Case System.Windows.Forms.ScrollEventType.EndScroll
				VScroll1_Change(eventArgs.newValue)
		End Select
	End Sub
End Class