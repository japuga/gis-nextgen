Option Strict Off
Option Explicit On
Imports System.Drawing.Printing
Friend Class frmPrinter
	Inherits System.Windows.Forms.Form
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		gbPrinter = False
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		On Error GoTo ErrorHandler
		'UPGRADE_ISSUE: Printers object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'Printer = Printers(cbPrinter.SelectedIndex)
		'UPGRADE_ISSUE: Printer property Printer.Copies was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Printer.Copies = txtCopies.Text
		
		'MsgBox Printer.DeviceName
		gbPrinter = True
		Me.Close()
		Exit Sub
		
ErrorHandler: 
		save_error(Me.Name, "cmdOK")
		Me.Close()
	End Sub
	
	Private Sub frmPrinter_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'UPGRADE_ISSUE: VBControlExtender method UpDown1.Value was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        txtCopies.Text = 0 'CStr(UpDown1.Value)
		load_cb_printer()
	End Sub
	
	Private Sub load_cb_printer()
		'UPGRADE_ISSUE: Printer object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'Dim p As Printer
		Dim nDefault As Object
		Dim nCounter As Short
		
		'UPGRADE_WARNING: Couldn't resolve default property of object nDefault. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		nDefault = -1
		nCounter = 0
		cbPrinter.Items.Clear()
		'UPGRADE_ISSUE: Printers object was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
        'For	Each p In Printers
        '	'UPGRADE_ISSUE: Printer property p.DeviceName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	cbPrinter.Items.Insert(nCounter, p.DeviceName)
        '	'UPGRADE_ISSUE: Printer property Printers.DeviceName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_ISSUE: Printer property Printer.DeviceName was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	If Printer.DeviceName = Printers(nCounter).DeviceName Then
        '		'UPGRADE_WARNING: Couldn't resolve default property of object nDefault. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		nDefault = nCounter
        '	End If
        '	nCounter = nCounter + 1
        'Next p
		
		'Seleccionar impresora default.
		'UPGRADE_WARNING: Couldn't resolve default property of object nDefault. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If nDefault >= 0 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object nDefault. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			cbPrinter.SelectedIndex = nDefault
		End If
		
		
	End Sub
End Class