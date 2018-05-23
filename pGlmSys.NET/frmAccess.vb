Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Friend Class frmAccess
    Inherits System.Windows.Forms.Form

    Dim nTimes As Short
    Private Sub displayKey()
        Dim nResult As Short
        nTimes = nTimes + 1
        nResult = nTimes Mod 4
        'txtUser.Text = nresult
        Select Case nResult
            Case 1
                imgKey(1).Visible = True
                imgKey(2).Visible = False
                imgKey(3).Visible = False

            Case 2
                imgKey(1).Visible = False
                imgKey(2).Visible = True
                imgKey(3).Visible = False
            Case 3
                imgKey(1).Visible = False
                imgKey(2).Visible = False
                imgKey(3).Visible = True
                imgLock.Visible = False
                imgUnlock.Visible = True
            Case Else
                nTimes = 0
                imgLock.Visible = True
                imgUnlock.Visible = False
        End Select


    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
        Dim sStr As String
        'im nRec As Short
        Dim nFrom As Short
        Dim nTo As Short
        Dim cmd As SqlCommand

        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            'cn.CommandTimeout = 300

            'cn.ConnectionString = "User id=" + Trim(txtUser) + ";" + _
            '"Password=" + Trim(txtPassword) + ";" + _
            '"Data source=" + Trim(cbServername) + ",1433;" + _
            '"Initial catalog=" + Trim(gsDatabase) + ";"

            'Added port parameter
            ' "," & gGlobSettings.sDbPort & ";" & _
            sStr = "User id=" & Trim(txtUser.Text) & ";" & "Password=" & Trim(txtPassword.Text) & ";" & _
                          "Server=" & Trim(cbServername.Text) & _
                          "Persist Security Info=True;" & _
                          "Connection Timeout = 30"

            'Usar valor del combo-box
            'si esta es la compu de christian (drive E) utiliza esta base de datos
            'If ((OSdriveLetter(0) = "E") Or (OSdriveLetter(0) = "e")) Then
            'sStr = "Data Source=" & cbServername.Text CC_DESKTOP2\CCDESKTOP  ;" & _
            'sStr = "Data Source=" & My.Settings.dbChris & ";" & _
            '                "Initial Catalog=GLM;" & _
            '               "Persist Security Info=True;" & _
            '              "MultipleActiveResultSets=True;" & _
            '             "User ID=" & Trim(txtUser.Text) & ";" & _
            '            "Password=" & Trim(txtPassword.Text) & ";" & "Connection Timeout = 300"
            'Else 'si esta es la compu de javier
            'sStr = "Data Source="& rpt1\rpt1sql  ;" & _
            'sStr = "Data Source=" & My.Settings.dbChris & ";" & _
            '                 "Initial Catalog=GLM;" & _
            '                 "Persist Security Info=True;" & _
            '                "User ID=" & Trim(txtUser.Text) & ";" & _
            '                "Password=" & Trim(txtPassword.Text) & ";" & "Connection Timeout = 300"
            'End If
            sStr = "Data Source=" & cbServername.SelectedItem & ";" & _
                 "Initial Catalog=GLM;" & _
                 "Persist Security Info=True;" & _
                 "User ID=" & Trim(txtUser.Text) & ";" & _
                 "Password=" & Trim(txtPassword.Text) & ";" & "Connection Timeout = 300"

            cn.ConnectionString = sStr
            'cn.ConnectionTimeout = 300

            'Save Connection string without password
            nFrom = InStr(sStr, "Password=")
            nTo = InStr(sStr, "Data source=")

            nFrom = nFrom + Len("Password=")

            'sStr = Replace(sStr, Mid(sStr, nFrom, nTo - nFrom), "***")
            'MsgBox(sStr)
            write_msg("frmAccess.cmdOk", sStr)


            cn.Open()
            cmd = cn.CreateCommand()
            validateAndAuditLogin(txtUser.Text)

            'sStr = "SELECT count(*) FROM suser " + _
            '" WHERE suser_name = '" + txtUser + "'" + _
            '" AND suser_password = '" + txtPassword + "' "

            sStr = "SELECT count(*) FROM suser " & " WHERE suser_name = '" & txtUser.Text & "'"
            cmd.CommandText = sStr

            rs = getDataTable(sStr) ' cmd.ExecuteReader()
            If Not (rs.Rows.Count > 0) Then
                Me.Cursor = System.Windows.Forms.Cursors.Default
                MsgBox("User was not found on Database.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "GLM Message")
            Else
                gbAccess = True 'Connection exitosa
                gsUser = txtUser.Text
                set_settings()

                Me.Cursor = System.Windows.Forms.Cursors.Default
                Me.Close()
            End If


            Exit Sub
        Catch ex As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Default

            gbAccess = False
            save_error("frmAcess", "cmdOk_click")
            If Not show_db_error() Then
                MsgBox("An error has ocurred while conecting to the database.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            End If
        End Try
    End Sub
    Private Sub set_settings()

        On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand()
        sStmt = "SELECT type_id FROM suser WHERE suser_name ='" & gsUser & "'"
        cmd.CommandText = sStmt

        rs = getDataTable(sStmt) 'cmd.ExecuteReader()
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(rs.Rows(0).Item("type_id")) Then
            gsUserType = CStr(General.UserType.AccountManager) 'Default Account Manager
        Else
            Select Case rs.Rows(0).Item("type_id").ToString
                Case "A"
                    gsUserType = CStr(General.UserType.Administrator)
                Case "C"
                    gsUserType = CStr(General.UserType.AccountManager)
                Case Else
                    gsUserType = CStr(General.UserType.AccountManager)
            End Select
        End If
        Exit Sub

ErrorHandler:
        save_error(Me.Name, "set_settings")
        MsgBox("Failed to load settings.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "GLM Error")
    End Sub


    Private Sub cmdOptions_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOptions.Click
        'Dim nLeft As Short
        'Dim nTop As Short
        'Static nDir As Integer
        'nDir = Not nDir
        'nLeft = cmdOptions.Left
        'nTop = cmdOptions.Top
        'cmdOptions.Move nLeft, nTop - (300 * nDir)
    End Sub

    Private Sub frmAccess_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        SetVersion()

        SetDbServer2()

        SetDefaults()

        nTimes = 0
        imgKey(1).Visible = False
        imgKey(2).Visible = False
        imgKey(3).Visible = False

        imgLock.Visible = True
        imgUnlock.Visible = False


    End Sub
    'Servidor de base de datos por defecto
    Private Sub SetDBServer()
        For i As Integer = 0 To My.Settings.dbServers.Count - 1
            cbServername.Items.Insert(i, My.Settings.dbServers.Item(i))

        Next
        'cbServername.Items.Add("CC_DESKTOP2\CCDESKTOP")
        'cbServername.Items.Insert(0, "sql01")
        'cbServername.Items.Insert(1, "glmsql")
        'cbServername.Items.Insert(2, "fs1")


        'cbServername.SelectedIndex = 0

    End Sub
    'Lee archivo de configuracion para cargar SqlServer
    Private Sub SetDbServer2()
        Dim fso As Scripting.FileSystemObject
        Dim ts As Scripting.TextStream
        Dim sLine As String
        Dim sFile As String
        Dim nServer As Short
        Dim sServer As String
        Dim sSection As String = ""
        Dim sPort As String

        On Error GoTo ErrorHandler

        gGlobSettings.sDbPort = Str(DEFAULT_DB_PORT)

        sFile = My.Application.Info.DirectoryPath & "/" & Trim(gsConfigFile)
        cbServername.Items.Clear()

        fso = New Scripting.FileSystemObject
        If fso.FileExists(sFile) Then
            ts = fso.OpenTextFile(sFile, Scripting.IOMode.ForReading, False)
            nServer = 0

            Do While Not ts.AtEndOfStream
                sLine = ts.ReadLine
                sLine = Trim(sLine)
                If VB.Left(sLine, 1) = "[" And VB.Right(sLine, 1) = "]" Then
                    'Seccion
                    If InStr(1, sLine, "[sqlserver]", CompareMethod.Text) Then
                        sSection = "sqlserver"
                    ElseIf InStr(1, sLine, "[dbport]", CompareMethod.Text) Then
                        sSection = "dbport"
                    Else
                        'Otra seccion
                        sSection = ""
                    End If
                Else
                    'Linea con Dato
                    Select Case sSection
                        Case "sqlserver"
                            sServer = Trim(sLine)

                            If Len(sServer) > 0 Then
                                sServer = VB.Left(sServer, Len(sServer) - 1)
                                cbServername.Items.Insert(nServer, sServer)
                            End If
                            nServer = nServer + 1
                            sServer = ""

                        Case "dbport"
                            sPort = Trim(sLine)
                            If IsNumeric(sPort) Then
                                gGlobSettings.sDbPort = sPort
                            Else
                                write_msg("frmAccess.SetDbServer2", "Invalid db port in config.ini file. Using default:1433")
                            End If
                            'Agregar aqui otras secciones
                            'case "host"
                    End Select

                End If


            Loop
            ts.Close()
        Else
            'Si archivo de configuracion no fue encontrado
            SetDBServer()
        End If

        If cbServername.Items.Count > 0 Then
            cbServername.SelectedIndex = 0
        End If
        Exit Sub

ErrorHandler:
        If cbServername.Items.Count = 0 Then
            SetDBServer()
        End If
        save_error(Me.Name, "SetDbServer2:Failed to load config ini file")

    End Sub
    'Version del software
    Private Sub SetVersion()

        lVersion.Text = "Rel " & Str(My.Application.Info.Version.Major) & "." & Str(My.Application.Info.Version.Minor) & "." & Str(My.Application.Info.Version.Revision)

    End Sub
    'Colores por defecto para interfase
    Private Sub SetDefaults()
        Frame1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(51, 102, 153))
        Label1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(51, 102, 153))
        Label2.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(51, 102, 153))
        Label3.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(51, 102, 153))
        'Frame1.BackColor = RGB(255, 0, 0)
    End Sub

    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        displayKey()
    End Sub

    Private Sub txtUser_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtUser.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        'MsgBox Str(KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub cbServername_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbServername.SelectedIndexChanged

    End Sub
End Class