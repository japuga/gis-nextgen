Option Strict Off
Option Explicit On
Friend Class frmCustFeeBillRangeDet
	Inherits System.Windows.Forms.Form
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
		gFeeBillingRangeDet.nLowerBound = CDbl(txtLowerBound.Text)
		gFeeBillingRangeDet.nUpperBound = CDbl(txtUpperBound.Text)
		gFeeBillingRangeDet.nRangeFeeValue = CDbl(txtRangeFeeValue.Text)
		gFeeBillingRangeDet.bFlag = General.modo.SavedRecord
		Me.Close()
	End Sub
	
	Private Sub frmCustFeeBillRangeDet_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Private Sub init_vars()
		Select Case gFeeBillingRangeDet.bFlag
			Case General.modo.NewRecord
				txtLowerBound.Text = CStr(0)
				txtUpperBound.Text = CStr(0)
				txtRangeFeeValue.Text = CStr(0)
			Case General.modo.UpdateRecord
				txtLowerBound.Text = CStr(gFeeBillingRangeDet.nLowerBound)
				txtUpperBound.Text = CStr(gFeeBillingRangeDet.nUpperBound)
				txtRangeFeeValue.Text = CStr(gFeeBillingRangeDet.nRangeFeeValue)
		End Select
		
	End Sub
	Private Sub txtLowerBound_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtLowerBound.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim nPos As Short
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			'Es numero
			'No permitir ingresar mas de 2 decimales
			
			'If (KeyAscii >= 48 And KeyAscii <= 57) _
			''And max_fraction(txtUsageDet) _
			''And txtUsageDet.SelLength = 0 Then
			'    KeyAscii = 0
			'End If
		Else
			nPos = InStr(1, txtLowerBound.Text, ".", CompareMethod.Text)
            If KeyAscii = 46 And (nPos = 0 Or IsDBNull(nPos)) Then
                'continue
            Else
                KeyAscii = 0
            End If
		End If
		
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtRangeFeeValue_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtRangeFeeValue.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim nPos As Short
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			'Es numero
			'No permitir ingresar mas de 2 decimales
			
			'If (KeyAscii >= 48 And KeyAscii <= 57) _
			''And max_fraction(txtUsageDet) _
			''And txtUsageDet.SelLength = 0 Then
			'    KeyAscii = 0
			'End If
		Else
			nPos = InStr(1, txtRangeFeeValue.Text, ".", CompareMethod.Text)
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If KeyAscii = 46 And (nPos = 0 Or IsDbNull(nPos)) Then
				'continue
			Else
				KeyAscii = 0
			End If
		End If
		
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtUpperBound_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtUpperBound.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim nPos As Short
		'Numeros, Backspace, Punto
		'MsgBox Str(KeyAscii)
		'8 = Backspace
		'9 = Dot
		If (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Or KeyAscii = 9 Then
			'Es numero
			'No permitir ingresar mas de 2 decimales
			
			'If (KeyAscii >= 48 And KeyAscii <= 57) _
			''And max_fraction(txtUsageDet) _
			''And txtUsageDet.SelLength = 0 Then
			'    KeyAscii = 0
			'End If
		Else
			nPos = InStr(1, txtUpperBound.Text, ".", CompareMethod.Text)
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If KeyAscii = 46 And (nPos = 0 Or IsDbNull(nPos)) Then
				'continue
			Else
				KeyAscii = 0
			End If
		End If
		
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class