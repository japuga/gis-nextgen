Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class frmMain
	Inherits System.Windows.Forms.Form
	'Public WithEvents cn As ADODB.Connection
	
	Private Sub cn_BeginTransComplete(ByVal TransactionLevel As Integer, ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pConnection As ADODB.Connection)
		General.bcnStatus = General.cnStatus.BeginTrans
	End Sub
	
	Private Sub cn_CommitTransComplete(ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pConnection As ADODB.Connection)
		General.bcnStatus = General.cnStatus.NoTrans
	End Sub
	
	Private Sub cn_RollbackTransComplete(ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pConnection As ADODB.Connection)
		General.bcnStatus = General.cnStatus.NoTrans
	End Sub
	
    Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim am_pm As String = "AM"
        Dim hour As String = TimeOfDay.Hour.ToString()
        If TimeOfDay.Hour > 12 Then
            am_pm = "PM"
            hour = Convert.ToString(Convert.ToInt16(hour) - 12)
        End If
        'Message in toolbar
        sbMain.Items(0).Text = "Login: " & Trim(get_user_name(gsUser))
        sbMain.Items(1).Text = hour + ":" + TimeOfDay.Minute.ToString() + ":" + TimeOfDay.Second.ToString() + _
                                " " + am_pm '.ToOADate)

        load_menu((gsUser))
    End Sub
	'1.8.8 Returns full user name
	Private Function get_user_name(ByRef sUserName As String) As String
		
		On Error GoTo ErrorHandler
        Dim cmd As SqlCommand = cn.CreateCommand()
		get_user_name = sUserName
		
		sStmt = "SELECT suser_desc FROM suser " & " WHERE suser_name ='" & sUserName & "'"
        cmd.CommandText = sStmt
        rs = getDataTable(sStmt) ' cmd.ExecuteReader()

        If rs.Rows.Count > 0 Then
            get_user_name = rs.Rows(0).Item("suser_desc").Value
        End If

        Exit Function

ErrorHandler:
        save_error(Me.Name, "get_user_name: Failed to return User Description")
	End Function
	
	
	Private Sub frmMain_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		sessionLogout()
		
		'cn.Close
	End Sub
	
	Private Sub mniBudgetPlan_Click(ByRef Index As Short)
		
	End Sub
	
	
	Public Sub mniAbout_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniAbout.Click
		VB6.ShowForm(frmAbout, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	
	
	Public Sub mniAutomatedInvoice_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniAutomatedInvoice.Click
		VB6.ShowForm(frmInvoiceAutomated, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniBank_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniBank.Click
		Dim Index As Short = mniBank.GetIndex(eventSender)
		VB6.ShowForm(frmBankMnt, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniBankAccount_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniBankAccount.Click
		Dim Index As Short = mniBankAccount.GetIndex(eventSender)
		VB6.ShowForm(frmBank, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniBatchBrowser_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniBatchBrowser.Click
		Dim Index As Short = mniBatchBrowser.GetIndex(eventSender)
		'Batch Checks
		VB6.ShowForm(frmCheckBatchBrowseDet, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniBucketList_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniBucketList.Click
		Dim Index As Short = mniBucketList.GetIndex(eventSender)
		
		VB6.ShowForm(frmImportBucketList, VB6.FormShowConstants.Modal, Me)
		
	End Sub
	
	Public Sub mniCallings_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniCallings.Click
		Dim Index As Short = mniCallings.GetIndex(eventSender)
		VB6.ShowForm(frmAlert, VB6.FormShowConstants.Modal, Me)
		
	End Sub
	
	Public Sub mniCheck_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniCheck.Click
		Dim Index As Short = mniCheck.GetIndex(eventSender)

		Select Case Index
			Case 0
				'Check Generation
				gbCheck = False
				VB6.ShowForm(frmCheck, VB6.FormShowConstants.Modal, Me)
				If gbCheck Then
					VB6.ShowForm(frmCheckRep, VB6.FormShowConstants.Modal, Me)
				End If
			Case 1
				'Check Reprint
				VB6.ShowForm(frmCheckBrowse, VB6.FormShowConstants.Modal, Me)
			Case 2
				'Check Browse
				VB6.ShowForm(frmCheckSearch, VB6.FormShowConstants.Modal, Me)
			Case 3
				'Batch Checks
				'frmCheckBatch.Show vbModal, Me
			Case 4
				'Credit Card Payment
				'UPGRADE_WARNING: Couldn't resolve default property of object frmCardPayment.Show. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Dim a As String = "no se que hacer, no existe el frm"
                'frmCardPayment.Show(VB6.FormShowConstants.Modal, Me)
				
		End Select
		
	End Sub
	
	
	Public Sub mniCheckBatch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniCheckBatch.Click
		Dim Index As Short = mniCheckBatch.GetIndex(eventSender)
		'Batch Checks
		VB6.ShowForm(frmCheckBatch, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniContract_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniContract.Click
		Dim Index As Short = mniContract.GetIndex(eventSender)
		VB6.ShowForm(frmContract, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniCreditCard_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniCreditCard.Click
		Dim Index As Short = mniCreditCard.GetIndex(eventSender)
		VB6.ShowForm(frmCard, VB6.FormShowConstants.Modal, Me)
		
	End Sub
	
	Public Sub mniCustInvoiceGeneration_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniCustInvoiceGeneration.Click
		
		VB6.ShowForm(frmCustInvGenSearch,  , Me)
		
	End Sub
	
	Public Sub mniCustInvoiceStoreGeneration_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniCustInvoiceStoreGeneration.Click
		VB6.ShowForm(frmCustInvBatch, VB6.FormShowConstants.Modal, Me)
		
	End Sub
	
	Public Sub mniCustStoreSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniCustStoreSearch.Click
		VB6.ShowForm(frmHelpCommon, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniEquipment_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniEquipment.Click
		Dim Index As Short = mniEquipment.GetIndex(eventSender)
		VB6.ShowForm(frmStoreEqpt, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniExit.Click
		Dim Index As Short = mniExit.GetIndex(eventSender)
		Me.Close()
	End Sub
	
	
	
	Public Sub mniExportCheck_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniExportCheck.Click
		Dim Index As Short = mniExportCheck.GetIndex(eventSender)
		VB6.ShowForm(frmExportCheck, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniExportVendor_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniExportVendor.Click
		Dim Index As Short = mniExportVendor.GetIndex(eventSender)
		VB6.ShowForm(frmExportVendor, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniFees_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniFees.Click
		Dim Index As Short = mniFees.GetIndex(eventSender)
		VB6.ShowForm(frmCustFee, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniGeneralInfo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniGeneralInfo.Click
		Dim Index As Short = mniGeneralInfo.GetIndex(eventSender)
		VB6.ShowForm(frmCustomer, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniImpCustomer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniImpCustomer.Click
		Dim Index As Short = mniImpCustomer.GetIndex(eventSender)
		General.gQbFileType = General.QbFileType.QbCustomer
		'frmQBImport.Show vbModal, Me
		
	End Sub
	
	Public Sub mniImpVendor_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniImpVendor.Click
		Dim Index As Short = mniImpVendor.GetIndex(eventSender)
		General.gQbFileType = General.QbFileType.QbVendor
		VB6.ShowForm(frmQBImport, VB6.FormShowConstants.Modal, Me)
		'read_qb_vendors "c:\glm\vendor.iif"
	End Sub
	Private Sub read_vendors()
		
	End Sub
	
	Public Sub mniInvoiceBillSummary_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniInvoiceBillSummary.Click
		Dim Index As Short = mniInvoiceBillSummary.GetIndex(eventSender)
		VB6.ShowForm(frmInvoiceBillSummary, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniInvoiceBooking_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniInvoiceBooking.Click
		VB6.ShowForm(frmInvoiceBooking, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniInvoiceImport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniInvoiceImport.Click
		VB6.ShowForm(frmInvoiceImport, VB6.FormShowConstants.Modal, Me)
		
	End Sub
	
	Public Sub mniInvoices_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniInvoices.Click
		Dim Index As Short = mniInvoices.GetIndex(eventSender)
		VB6.ShowForm(frmImportInvoice, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniInvoicingGroups_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniInvoicingGroups.Click
		Dim Index As Short = mniInvoicingGroups.GetIndex(eventSender)
		VB6.ShowForm(frmInvoicingGroups, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniLocals_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniLocals.Click
		Dim Index As Short = mniLocals.GetIndex(eventSender)
		VB6.ShowForm(frmGrpDefBrowse, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniMigTools_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniMigTools.Click
		Dim Index As Short = mniMigTools.GetIndex(eventSender)
		VB6.ShowForm(frmLoadExcel, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniPeriods_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniPeriods.Click
		Dim Index As Short = mniPeriods.GetIndex(eventSender)
		VB6.ShowForm(frmPeriod, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniRate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniRate.Click
		VB6.ShowForm(frmRateSearch, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniReport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniReport.Click
		Dim Index As Short = mniReport.GetIndex(eventSender)
		gReport.Index = Index
		
		
		Select Case Index
			Case 41
				gReport.name = "GLM Invoice Report"
				VB6.ShowForm(frmRepGlmInvoice, VB6.FormShowConstants.Modal, Me)
			Case 42
				gReport.name = "Cost Containment Report"
				VB6.ShowForm(frmRepCostContSearch, VB6.FormShowConstants.Modal, Me)
			Case 43
				gReport.name = "Bill Payment Report"
				VB6.ShowForm(frmRepBillPay, VB6.FormShowConstants.Modal, Me)
			Case 44
				gReport.name = "Invoice Tracking Report"
				VB6.ShowForm(frmRepInvoiceTracking, VB6.FormShowConstants.Modal, Me)
			Case 45
				'Scrap Metal Rebate Report
				gReport.name = mniReport(Index).Text
				VB6.ShowForm(frmRepScrapMetal3, VB6.FormShowConstants.Modal, Me)
			Case 46
				'Recycle Tonnage Report
				gReport.name = mniReport(Index).Text
				VB6.ShowForm(frmRepRecycleTon, VB6.FormShowConstants.Modal, Me)
			Case 47
				'Recycle Content Report
				gReport.name = mniReport(Index).Text
				VB6.ShowForm(frmRepRecycleContent, VB6.FormShowConstants.Modal, Me)
				
			Case 50
				gReport.name = "Universal Report"
				VB6.ShowForm(frmRepUniversal, VB6.FormShowConstants.Modal, Me)
			Case 51
				gReport.name = "Environmental Report"
				VB6.ShowForm(frmRepEnv, VB6.FormShowConstants.Modal, Me)
			Case 52
				gReport.name = "Recycle Tonnage Report General"
				VB6.ShowForm(frmRepRecycleTonGen, VB6.FormShowConstants.Modal, Me)
		End Select
		
		'ReportHandler '***************
	End Sub
	
	Public Sub mniReportDefinition_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniReportDefinition.Click
		Dim Index As Short = mniReportDefinition.GetIndex(eventSender)
		VB6.ShowForm(frmRepDef, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniReprint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniReprint.Click
		
		
		If gsUserType <> CStr(General.UserType.Administrator) Then
			MsgBox("You do not have permissions to access this option", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Warning")
			Exit Sub
		End If
		
		VB6.ShowForm(frmReportReprint, VB6.FormShowConstants.Modal, Me)
		
	End Sub
	
	Public Sub mniSaleRequest_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniSaleRequest.Click
		VB6.ShowForm(frmSaleRequest, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	
	Public Sub mniServiceCatalog_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniServiceCatalog.Click
		Dim Index As Short = mniServiceCatalog.GetIndex(eventSender)
		VB6.ShowForm(frmService, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniServiceGroups_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniServiceGroups.Click
		Dim Index As Short = mniServiceGroups.GetIndex(eventSender)
		VB6.ShowForm(frmServiceGroup, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniStoreAddress_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniStoreAddress.Click
		Dim Index As Short = mniStoreAddress.GetIndex(eventSender)
		gStoreAddress.bAddressFlag = General.addressMode.InsertUpdateMode
		
		VB6.ShowForm(frmStoreAddress, VB6.FormShowConstants.Modal, Me)
		
	End Sub
	
	Public Sub mniStoreGroups_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniStoreGroups.Click
		Dim Index As Short = mniStoreGroups.GetIndex(eventSender)
		VB6.ShowForm(frmGroupStore, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniStoresMaint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniStoresMaint.Click
		Dim Index As Short = mniStoresMaint.GetIndex(eventSender)
		VB6.ShowForm(frmStore, VB6.FormShowConstants.Modal, Me)
		
	End Sub
	
	Public Sub mniSystemSetings_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniSystemSetings.Click
		Dim Index As Short = mniSystemSetings.GetIndex(eventSender)
		VB6.ShowForm(frmSetting, VB6.FormShowConstants.Modal, Me)
		
	End Sub
	
	Public Sub mniUserMaintenance_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniUserMaintenance.Click
		Dim Index As Short = mniUserMaintenance.GetIndex(eventSender)
		Select Case Index
			Case 0
				VB6.ShowForm(frmUser, VB6.FormShowConstants.Modal, Me)
			Case 1
				VB6.ShowForm(frmUserPriv, VB6.FormShowConstants.Modal, Me)
		End Select
	End Sub
	
	Private Sub mniUserPrivileges_Click(ByRef Index As Short)
		VB6.ShowForm(frmUserPriv, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniVendors_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniVendors.Click
		Dim Index As Short = mniVendors.GetIndex(eventSender)
		VB6.ShowForm(frmVendor, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniWebReports_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniWebReports.Click
        'VB6.ShowForm(frmWebReport, VB6.FormShowConstants.Modal, Me)
        gReport.name = "Checks Report"
        VB6.ShowForm(frmRepCheck, VB6.FormShowConstants.Modal, Me)
	End Sub
	
	Public Sub mniWordTemplate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mniWordTemplate.Click
		Dim Index As Short = mniWordTemplate.GetIndex(eventSender)
		VB6.ShowForm(frmCustInvTemplate, VB6.FormShowConstants.Modal, Me)
	End Sub
	
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Toolbar1_Button4.Click, _Toolbar1_Button6.Click, _Toolbar1_Button10.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        If Button.Name = "phone" Then

        End If
        If Button.Name = "Exit" Then
            sessionLogout()
            clear_objects()
            Me.Close()
        End If
        If Button.Name = "Invoice" Then
            mniInvoiceBooking_Click(mniInvoiceBooking, New System.EventArgs())
            'frmInvoiceBooking.Show vbModal, Me
        End If
        If Button.Name = "Checking" Then
            mniCheck_Click(mniCheck.Item(0), New System.EventArgs())

        End If
        If Button.Name = "Receivables" Then

        End If
        If Button.Name = "Reports" Then
            gReport.static_Renamed = False
            gReport.Index = 41
            gReport.name = "Invoice Report" 'This is the report by default
            mniReport_Click(mniReport.Item(gReport.Index), New System.EventArgs())
        End If
    End Sub
	
    Private Sub load_menu(ByRef sUser As String)
        Dim cmd As SqlCommand = cn.CreateCommand()
        'Validates menu options based on user info from tables:
        'suser,suser_options, suser_type
        ToolStripButton1.ImageScaling = ToolStripItemImageScaling.None
        ToolStripButton1.AutoSize = False
        ToolStripButton1.Size = New System.Drawing.Size(80, 90)


        mniUserMaintenance(0).Visible = False
        mniUserMaintenance(1).Visible = False
        mniQB(0).Visible = False 'QBImport
        mniQB(1).Visible = False 'QBExport
        '07.31.03 Added Check Browse for acces to everyone
        'mnuVendorPayments(0).Enabled = False
        mniCheck(0).Visible = False
        mniCheck(1).Visible = False
        mniCheck(3).Visible = False
        '01.03.04 Bank Account
        mniBankAccount(0).Visible = False
        mniContract(0).Visible = False

        sStmt = "SELECT type_id FROM suser " & "WHERE suser_name='" & Trim(sUser) & "'"
        cmd.CommandText = sStmt
        rs = getDataTable(sStmt) ' cmd.ExecuteReader() '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.Rows.Count > 0 Then
            If rs.Rows(0).Item("type_id") = "A" Then
                'Administrator
                mniUserMaintenance(0).Visible = True
                mniUserMaintenance(1).Visible = True
                mniQB(0).Visible = True
                mniQB(1).Visible = True
                'mnuVendorPayments(0).Enabled = True
                mniCheck(0).Visible = True
                mniCheck(1).Visible = True
                mniCheck(3).Visible = True
                mniBankAccount(0).Visible = True
                mniContract(0).Visible = True
                mnuSettings(0).Visible = True
                mniGeneralInfo(0).Visible = True
                mniCreditCard(0).Visible = True
                mniBank(0).Visible = True

            End If
        End If

    End Sub

    Private Sub _mniVendors_24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _mniVendors_24.Click
        Dim Index As Short = mniVendors.GetIndex(sender)
        VB6.ShowForm(frmVendor, VB6.FormShowConstants.Modal, Me)
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()

    End Sub

    Private Sub btInvoiceBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInvoiceBooking.Click
        VB6.ShowForm(frmInvoiceBooking, VB6.FormShowConstants.Modal, Me)
    End Sub

    Private Sub _mniReport_52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _mniReport_52.Click

    End Sub
End Class