Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmAlertEntry
	Inherits System.Windows.Forms.Form
	Private i_secAlert As Short
	Private i_cust_id As String
	Private i_store_id As String
	Private i_alert_message_rtf As String
    Private i_alert_date As String

	
	
	Public Property alert_message_rtf() As String
		Get
			alert_message_rtf = i_alert_message_rtf
		End Get
		Set(ByVal Value As String)
			i_alert_message_rtf = Value
		End Set
	End Property
	
	
	
	Public Property alert_date() As String
		Get
			alert_date = i_alert_date
		End Get
		Set(ByVal Value As String)
			i_alert_date = Value
		End Set
	End Property
	
	
	
	'Public Property Get secAlert() As Integer
	'    secAlert = i_secAlert
	'End Property
	'
	'Public Property Let secAlert(value As Integer)
	'    i_secAlert = value
	'End Property
	
	
	
	Public Property secAlert() As Short
		Get
			secAlert = i_secAlert
		End Get
		Set(ByVal Value As Short)
			i_secAlert = Value
		End Set
	End Property
	
	
	Public Property cust_id() As String
		Get
			cust_id = i_cust_id
		End Get
		Set(ByVal Value As String)
			i_cust_id = Value
		End Set
	End Property
	
	
	Public Property store_id() As String
		Get
			store_id = i_store_id
		End Get
		Set(ByVal Value As String)
			i_store_id = Value
		End Set
	End Property
	
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click
        Dim atert_message_rtF As Object = New Object()
        Dim iAlert_seq As Integer
		Dim stmt As Object
		
		
        Dim oCmd As SqlCommand = cn.CreateCommand()
        Dim oPrm As SqlParameter
		
        If i_secAlert = 0 Then

            'UPGRADE_WARNING: Couldn't resolve default property of object stmt. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            stmt = "SELECT max(alert_seq) as iMax FROM alert "
            oCmd.CommandText = stmt
            

            rs = getDataTable(stmt) ' = oCmd.ExecuteReader()
            If Not (rs.Rows.Count > 0) Then
                'UPGRADE_WARNING: Couldn't resolve default property of object iAlert_seq. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                iAlert_seq = 1
            Else
                iAlert_seq = IIf(IsDBNull(rs.Rows(0).Item("iMax").value), 1, rs.Rows(0).Item("iMax").value + 1)
            End If


            stmt = "INSERT INTO alert (cust_id, store_id, alert_seq, alert_date, alert_message_rtf) " & " VALUES ( ?, ?, ?, ?, ?)"
            oCmd.CommandText = stmt

            'oCmd.CreateParameter()"cust_id", DbType.String, ParameterDirection.Input, 2)
            oPrm = New SqlParameter("cust_id", SqlDbType.VarChar, 2, ParameterDirection.Input)
            oPrm.Value = cust_id
            oCmd.Parameters.Add(oPrm)

            'oCmd.CreateParameter("store_id", SqlDbType.VarChar, ParameterDirection.Input, 10)
            oPrm = New SqlParameter("store_id", SqlDbType.VarChar, 10, ParameterDirection.Input)
            oPrm.Value = store_id
            oCmd.Parameters.Add(oPrm)

            'oCmd.CreateParameter("alert_seQ", SqlDbType.VarChar, ParameterDirection.Input, 10)
            oPrm = New SqlParameter("alert_seQ", SqlDbType.VarChar, 10, ParameterDirection.Input)        
            oPrm.Value = iAlert_seq
            oCmd.Parameters.Add(oPrm)

            'oCmd.CreateParameter("alert_date", SqlDbType.VarChar, ParameterDirection.Input, 10)
            oPrm = New SqlParameter("alert_date", SqlDbType.VarChar, 10, ParameterDirection.Input)
            oPrm.Value = Today
            oCmd.Parameters.Add(oPrm)

            'oCmd.CreateParameter("atert_message_rtF", SqlDbType.VarChar, ParameterDirection.Input, Len(Me.rtbAlertMessage.Rtf))
            oPrm = New SqlParameter("atert_message_rtF", SqlDbType.VarChar, Len(Me.rtbAlertMessage.Rtf), ParameterDirection.Input)
            oPrm.Value = Me.rtbAlertMessage.Rtf
            oCmd.Parameters.Add(oPrm)

        Else            
            iAlert_seq = i_secAlert
            stmt = "UPDATE alert SET alert_message_rtf=? " & " WHERE alert_seq=" & iAlert_seq            
            oCmd.CommandText = stmt

            'oCmd.CreateParameter(atert_message_rtF, SqlDbType.VarChar, ParameterDirection.Input, Len(Me.rtbAlertMessage.Rtf))
            oPrm = New SqlParameter(atert_message_rtF, SqlDbType.VarChar, Len(Me.rtbAlertMessage.Rtf), ParameterDirection.Input)
            oPrm.Value = Me.rtbAlertMessage.Rtf
            oCmd.Parameters.Add(oPrm)

        End If
		
        oCmd.ExecuteNonQuery()
		'cm.ActiveConnection = cn
		'cm.CommandType = adCmdText
		'cm.CommandText = stmt
		'cm.Execute
		
		'stmt = "SELECT cust_id, store_id, alert_seq, alert_message_rtf FROM alert where alert_seq = ?"
		'
		'If rs.State = adStateOpen Then
		'    rs.Close
		'End If
		'
		'rs.CursorLocation = adUseServer
		'
		'
		'rs.Open stmt, cn, adOpenDynamic, adLockOptimistic
		'
        'rs.item("alert_message") = rtbAlertMessage.TextRTF
		'
		'
		'
		'rs.Update
		
		'UPGRADE_WARNING: Couldn't resolve default property of object iAlert_seq. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		i_secAlert = iAlert_seq
		
		MsgBox("Note was successfully saved", MsgBoxStyle.Information, "GLM")
		Me.Close()
		
		
		
	End Sub
	
	Private Sub frmAlertEntry_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		init_vars()
	End Sub
	
	Public Sub init_vars()
		'    If gAlertRecord.bFlag = modo.UpdateRecord Then
		'        stmt = "SELECT alert_message_rtf " _
		''            & " FROM alert " _
		''            & " where cust_id='" & cust_id & "' AND store_id='" & store_id & "' AND alert_seq = " & i_secAlert
		'
		'        If rs.State = adStateOpen Then
		'            rs.Close
		'        End If
		'
		'        rs.CursorLocation = adUseServer
		'
		'
		'        rs.Open stmt, cn, adOpenDynamic, adLockOptimistic
		'
		'
		'
        '        rtbAlertMessage.TextRTF = rs.item("alert_message_rtf")
		'    End If
		Me.lblDate.Text = i_alert_date
		'UPGRADE_WARNING: TextRTF was upgraded to Text and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		Me.rtbAlertMessage.Text = i_alert_message_rtf
	End Sub
End Class