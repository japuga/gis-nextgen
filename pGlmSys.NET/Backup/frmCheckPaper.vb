Option Strict Off
Option Explicit On
Friend Class frmCheckPaper
	Inherits System.Windows.Forms.Form
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		Me.Close()
	End Sub
	
	Private Sub frmCheckPaper_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		Select Case gGlobSettings.eCheckPaperSource
			Case General.CheckPaper.Imprinted
				obImprinted.Checked = True
			Case General.CheckPaper.Blank
				obBlank.Checked = True
		End Select
	End Sub
	
	'UPGRADE_WARNING: Event obBlank.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub obBlank_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles obBlank.CheckedChanged
		If eventSender.Checked Then
			General.gCheckPaperSource = General.CheckPaper.Blank
		End If
	End Sub
	
	'UPGRADE_WARNING: Event obImprinted.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub obImprinted_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles obImprinted.CheckedChanged
		If eventSender.Checked Then
			General.gCheckPaperSource = General.CheckPaper.Imprinted
		End If
	End Sub
End Class