Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports System.IO
Module General

    Public OSdriveLetter As String = "C:\DESARROLLO\JAPUGA" ' Path.GetPathRoot(My.Application.Info.DirectoryPath).ToString
    Public cn As SqlClient.SqlConnection
    Public bcnStatus As cnStatus
    Public Enum cnStatus
        BeginTrans = 1
        NoTrans = 0
    End Enum

    Public Enum QbFileType
        QbVendor = 0
        QbAccount = 1
        QbCustomer = 2
    End Enum

    Public Enum CheckBrowseDetMode
        CheckReprint = 0
        CheckBrowse = 1
    End Enum

    'Maps suser_type
    Public Enum UserType
        Administrator = 0
        AccountManager = 1
    End Enum



    Public Enum CheckPaper
        Imprinted = 0
        Blank = 1
    End Enum

    Public cm As SqlCommand
    Public cmSeed As SqlCommand
    Public cmReport As SqlCommand
    Public rs As DataTable
    Public rsHelp As DataTable
    'Public rsReport As sqldatareader
    Public grsState As DataTable
    Public grsCustomer As DataTable
    'Global Variables
    Public gbAccess As Boolean
    Public gsUser As String 'User
    Public gsUserType As String
    Public gsDatabase As String
    Public gsConfigFile As String 'Application start-up configuration file
    Public gQbFileType As QbFileType 'frmQBImport
    Public gCheckBrowseDetMode As CheckBrowseDetMode 'frmCheckBrowseDet
    Public sStmt As String
    Public sLogfile As String
    Public sError As String
    Public gbDebug As Boolean
    Public gbError As Boolean
    Public gnLoginId As Integer

    'OSdriveLetter es de la forma "E:\", o "C:\"
    'Public strReportsSysPath As String = OSdriveLetter & "glm\vbnet\reports\"

    Public Structure gReportUDT
        Dim name As String 'Report Name
        Dim Index As Short 'Menu Report Index
        'UPGRADE_NOTE: static was upgraded to static_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim static_Renamed As Boolean 'True=cbReport is static
    End Structure
    Public Structure gReportDataUDT
        Dim bOpen As Boolean
        Dim rs As DataSet
    End Structure

    Public Structure gBankUDT
        Dim bFlag As modo
        Dim nBankId As Short
        Dim sBankName As String
        Dim sBankAba As String
        Dim sCheckInfo1 As String
        Dim sCheckInfo2 As String
        Dim sCheckInfo3 As String
        Dim sCheckInfo4 As String
        Dim sBankStatus As String
    End Structure

    Public Structure gBankAccountUDT
        Dim bFlag As modo
        Dim nBankId As Short
        Dim sCustId As String
        Dim nBankCustSeq As Short
        Dim sBankAccount As String
        Dim nBankAccountBalance As Double
        Dim nLastCheckNo As Integer
        Dim sBankAccountBalanceMask As String
        Dim sQBGroupId As String
    End Structure

    Public Structure gCreditCardUDT
        Dim bFlag As modo
        Dim nCardSeq As Short
        Dim nBankId As Short
        Dim sCardNumber As String
        Dim nCardBalance As Double
        Dim sCardType As String
    End Structure

    Public Structure gCheckUDT
        Dim CheckNo As Integer
        Dim BankCustSeq As String
        'UPGRADE_NOTE: Date was upgraded to Date_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim Date_Renamed As Date
        Dim VendorName As String
        Dim VendorSeq As Short
        Dim VendorAddress As String
        Dim custId As String
        Dim Amount As Double
        Dim Memo As String 'List of invoices paid with this check.
        Dim rsStore As DataTable
        Dim reprint As Boolean 'TRUE if check was yet printed
        Dim CustName As String
        Dim VoidCheckNo As Integer
        Dim bSameCheck As Boolean
    End Structure

    Public Structure gCheckVoidUDT
        Dim bOk As Boolean
        Dim nVoidCheckNo As Integer
        Dim nNewCheckNo As Integer
        Dim nBankCustSeq As Short
        Dim bSameCheck As Boolean
    End Structure

    Public Structure gCheckBatchUDT
        Dim sCheckDate As String
        Dim sVendName As String
        Dim nCheckAmount As Double
        Dim sVendAddress As String
        Dim sVendCity As String
        Dim sVendZip As String
    End Structure


    'Multipurpose data type that returns 2 string values
    'Used firstly on function exec_sql_single
    Public Structure gDumpUDT
        Dim str1 As String
        Dim str2 As String
    End Structure

    'Used in frmStoreSearch to communicate with frmStore
    Public Structure gStoreSearchUDT
        Dim bFlag As Boolean
        Dim sCustId As String
        Dim sCustName As String
        Dim sStateId As String
    End Structure


    'Used in frmStore to communicate with frmStoreEntry
    Public Structure gStoreRecordUDT
        Dim nStoreId As Short
        Dim sStoreNumber As String
        Dim sStoreName As String
        Dim sStoreAddress As String
        Dim sStoreCity As String
        Dim sStateId As String
        Dim sStoreZip As String
        Dim sStorePhone1 As String
        Dim sStorePhone2 As String
        Dim sStoreFax1 As String
        Dim sStoreFax2 As String
        Dim sStoreContact As String
        Dim sStoreStatus As String
        Dim sStoreFranchise As String
        Dim sStoreFolder As String
        Dim sStoreCoCode As String
        Dim nStoreOccupants As Short
        Dim nStoreAddressSeq As Short
        Dim sStoreBillingContact As String
        Dim sStoreBillingAccount As String
        Dim sLfGroup As String
        Dim sStoreMarket As String
        Dim sStoreSold As String
        Dim dtStoreSoldDate As Date
    End Structure
    'Used in frmCheckBatchBrowseDeta to communicate with frmCheckBatchBrowse
    Public Structure gCheckBatchSearchUDT
        Dim bFlag As Boolean
        Dim sCustId As String
        Dim nBatchId As Short
        Dim sDateFrom As String
        Dim sDateTo As String
    End Structure
    'Used in frmVBranchBrowse to communicate with frmCheck
    'Used in frmVBranchSelection to communicate with frmCheckBatch
    Public Structure gVendorUDT
        Dim nVendId As Short
        Dim sVendName As String
        Dim sVendPayAddress As String
        Dim sVendSeq As String 'List of vend_seq selected in frmVBranchSelection
    End Structure

    'Used in frmVendorSearch to communicate with frmVendor
    Public Structure gVendorSearchUDT
        Dim bFlag As Boolean
        Dim sVendName As String
        Dim nVendId As Short
        Dim sStateId As String
        Dim nVendSeq As Short 'Just to be used by frmVendorBrowse
    End Structure
    'Used in frmVendor to communicate with frmVendorEntry
    Public Structure gVBranchRecordUDT
        Dim nVendId As Short
        Dim nVendSeq As Short
        Dim sStateId As String
        Dim sVendName As String
        Dim sVendRepre As String
        Dim sVendPhone1 As String
        Dim sVendPhone2 As String
        Dim sVendFax1 As String
        Dim sVendFax2 As String
        Dim sVendAddress As String
        Dim sVendCity As String
        Dim sVendZip As String
        Dim sVendArea As String
        Dim sQBNameCS As String 'QuickBooks Container Store
        Dim sQBNameTR As String 'QuickBooks Tony Roma
        Dim sVendPayAddress As String
        Dim sVendPayCity As String
        Dim sVendPayZip As String
        Dim sVendPayPhone1 As String
        Dim sVendPayState As String
    End Structure
    'Used in frmQBSearch to show help info from Vendor Name in QuickBooks
    Public Structure gQBSearchUDT
        Dim sParam As String 'Argument to show data in Datagrid
        Dim bFlag As Boolean 'TRUE in case something is returned
        Dim qb_name As String
    End Structure
    'Used in frmStoreEqpt to communicate with frmStoreEqptEntry
    Public Structure gStoreEqptRecordUDT
        Dim sCustId As String
        Dim sCustName As String
        Dim nStoreId As Short
        Dim sStoreNumber As String
        Dim nEqptSeq As Short
        Dim nEqptId As Short
        Dim sLoadId As String
        Dim sEqptStatus As String
        Dim sEqptDesc As String
        Dim nContentId As Short
        Dim nEqptQty As Short
        Dim sEqptTemp As String
        Dim nEqptSizeCapacity As Double
        Dim nEqptActualQty As Short
    End Structure
    'Used in frmStoreEqptEntry to communicate with frmAccount
    Public Structure gAccountEqptUDT
        Dim sCustId As String
        Dim nStoreId As Short
        Dim sAccountNo As String
        Dim sAccountMask As String
        Dim nVendSeq As Short
        Dim nEqptSeq As Short
        Dim sAccountStatus As String
        Dim sVendor As String 'VendName + VendArea
    End Structure
    'Used in frmAccountEntry to communicate with frmAccount
    Public Structure gAccountRecordUDT
        Dim bFlag As modo
        Dim sCustId As String
        Dim nStoreId As Short
        Dim sAccountNo As String
        Dim sAccountMask As String
        Dim nVendSeq As Short
        Dim sCustName As String
        Dim sStoreNumber As String
        Dim sVendName As String
    End Structure
    'Used in frmContractEntry to communicate with frmContract
    Public Structure gContractRecordUDT
        Dim bFlag As modo
        Dim sCustId As String
        Dim nStoreId As Short
        Dim nEqptSeq As Short
        Dim nVendSeq As Short
        Dim nServId As Short
        Dim sFreqTimes As String
        Dim sFreqPeriod As String
        Dim sFreqDay1 As String
        Dim sFreqDay2 As String
        Dim sFreqDay3 As String
        Dim sFreqDay4 As String
        Dim sFreqDay5 As String
        Dim sFreqDay6 As String
        Dim sFreqDay7 As String
        Dim nGlmRate As Double
        Dim nCurrRate As Double
        Dim nOldRate As Double
        Dim sOpeningDate As String
        Dim sExpirationDate As String
        Dim sFreqDesc As String
        Dim sStoreNumber As String
        Dim sVendor As String
        Dim nFreqId As Short
        Dim sFreqComments As String
        Dim sContractComments As String
        Dim sRateStatus As String
        Dim sDefaultService As String
        Dim sOverrideExpFlag As String
    End Structure

    Public Structure gInvHeaderRecordUDT
        Dim sInvoiceNo As String
        Dim sAccountNo As String
        Dim sCustId As String
        Dim nStoreId As Short
        Dim nVendSeq As Short
        Dim dInvoiceDate As Date
    End Structure


    Public Structure gPeriodRecordUDT
        Dim bMode As modo
        Dim sCustId As String
        Dim sCustName As String
        Dim nPeriodSeq As Short
        Dim sPeriodName As String
        Dim sPeriodStartDate As String
        Dim sPeriodEndDate As String
        Dim sPeriodStatusId As String
        Dim sPeriodStatusDesc As String
    End Structure

    'Used in frmCustFeeEntry to communicate with frmCustFee
    Public Structure gCustFeeRecordUDT
        Dim bFlag As modo
        Dim sCustId As String
        Dim nFeeValue As Double
        Dim sFeeDesc As String
        Dim nFeeTypeId As Short
        Dim nFeeId As Short
        Dim sFeeActive As String
    End Structure

    Public Structure gFeeBillingRangeUDT
        Dim sCustId As String
        Dim nFeeId As Short
    End Structure

    Public Structure gFeeBillingRangeDetUDT
        Dim bFlag As modo
        Dim nFeeId As Short
        Dim nRangeSeq As Short
        Dim nLowerBound As Double
        Dim nUpperBound As Double
        Dim nRangeFeeValue As Double
    End Structure

    Public Structure gGroupsRecordUDT
        Dim bFlag As modo
        Dim sCustId As String
        Dim sCustName As String
        Dim nGroupSeq As Short
        Dim sGroupName As String
        Dim sTypeId As String
        Dim sAttention As String
        Dim sContractNo As String
        Dim sText As String
    End Structure

    Public Structure gCustomerRecordUDT
        Dim bFlag As modo
        Dim sCustId As String
    End Structure

    Public Structure gServiceRecordUDT
        Dim bFlag As modo
        Dim serv_id As Short
        Dim serv_desc As String
        Dim serv_eqpt As String
        Dim serv_credit As String
        Dim serv_rate_contract As String
        Dim unit_desc As String
        Dim serv_measure_unit As String
        Dim serv_class As String
        Dim serv_class_id As String
        Dim serv_frequency As String
        Dim serv_id_conversion As Short
    End Structure

    Public Structure gUserRecordUDT
        Dim bFlag As modo
        Dim sUserName As String
        Dim sUserDesc As String
        Dim sTypeId As String
    End Structure

    Public Structure gRepDefUDT
        Dim bFlag As modo
        Dim nRepNo As Short
        Dim sRepCaption As String
        Dim sRepSpName As String
        Dim sRepTemplateFile As String
        Dim sTableName As String
    End Structure


    Public Structure gRepDefTemplateUDT
        Dim bFlag As modo
        Dim nRepNo As Short
        Dim sRepTemplateName As String
        Dim sRepTemplateDesc As String
        Dim sRepTemplateFile As String
        Dim nColOrder As Short
    End Structure

    Public Structure gExportCheckExcpUDT
        Dim rs As SqlDataReader
    End Structure

    'Used in frmInvoiceBooking and frmInvoiceSearch to
    'communicate with frmHelpCustomer
    Public Structure gInvoiceHelpUDT
        Dim sSql As String
        Dim sOrderBy As String
    End Structure

    'Interface with template tplGridSelector
    Public Structure gItplGridSelectorFieldUDT
        Dim sFieldName As String
        Dim bVisible As Boolean
        Dim nWidth As Short
    End Structure


    Public Structure gItplGridSelectorUDT
        Dim bFlag As Boolean
        Dim sQuerySource As String
        Dim sQuerySelected As String
        Dim sQueryInit As String
        Dim sOrderBy As String
        Dim sLeftCaption As String
        Dim sRightCaption As String
        <VBFixedArray(10)> Dim aFields() As gItplGridSelectorFieldUDT
        Dim rsResult As DataTable
        Dim sInvokeFromForm As String

        'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            ReDim aFields(10)
        End Sub
    End Structure

    Public Structure gItplGridSelectorHeaderUDT
        Dim itemHeader As String 'Values: lbHeader, txtHeader or cbHeader
        Dim sCaption As String
        Dim PositionLeft As Integer
        Dim PositionTop As Integer
        Dim bVisible As Boolean
    End Structure

    Public Structure gItplGridSelector2UDT
        Dim bFlag As Boolean
        Dim bModo As modo
        Dim sQuerySource As String
        Dim sQuerySelected As String
        Dim sQueryInit As String
        Dim sOrderBy As String
        Dim sLeftCaption As String
        Dim sRightCaption As String
        <VBFixedArray(10)> Dim aFields() As gItplGridSelectorFieldUDT
        Dim rsResult As DataTable
        <VBFixedArray(3)> Dim header() As gItplGridSelectorHeaderUDT
        Dim sQueryHeader As String
        Dim sQueryOrderBy As String
        Dim sInsertStmt As String
        Dim sDeleteStmt As String
        Dim sQueryCount As String
        Dim sFormCaption As String

        'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            ReDim aFields(10)
            ReDim header(3)
        End Sub
    End Structure

    Public Structure gInvoicingGroupUDT
        Dim bModo As modo
        Dim nGroupSeq As Short
        Dim sCustId As String
        Dim sGroupName As String
        Dim sGroupStatus As String
    End Structure

    'Used to handle data transfer between frmGrpDefBrowser and frmGrpDefEntry
    Public Structure gGrpDefUDT
        Dim bModo As modo
        Dim sGrpDefId As String
        Dim sTypeId As String
        Dim sCustId As String
        Dim sCustName As String
    End Structure

    Public Structure gInvDetWgtUDT
        Dim bFlag As modo
        'sInvoiceNo As String
        'sCustId As String
        'nStoreId As Integer
        'sAccountNo As String
        'nVendSeq As Integer
        'nInvoiceDetNo As Integer
        Dim nSequenceId As Short
        Dim nWeight As Double
        Dim sTicket As String
        Dim dtTicketDate As Date
        Dim nQty As Double
        Dim sWeightUnitType As String
    End Structure

    Public Structure gServiceGroupRecordUDT
        Dim bFlag As modo
        Dim nServGroupId As Short
        Dim sServGroupName As String
        Dim sServGroupDesc As String
        Dim sSystemGenerated As String
    End Structure

    Public Structure gAlertRecordUDT
        Dim bFlag As modo
        Dim nAlertSeq As Short
    End Structure

    'jp.E013.begin
    Public Structure gSaleRequestRecordUDT
        Dim bFlag As modo
        Dim nRequestSeq As Short
        Dim sCustId As String
        Dim sCustName As String
        Dim nStoreId As Short
        Dim sStoreNo As String
        Dim sRequestNo As String
        Dim dtRequestDate As Date
        Dim dtResponseDate As Date
        Dim sTrackingNo As String
        Dim sNotes As String
    End Structure

    Public Structure gSaleItemRecordUDT
        Dim bFlag As modo
        Dim nRequestSeq As Short
        Dim nItemSeq As Short
        Dim sItemDesc As String
        Dim nItemQty As Double
        Dim nAvailableQty As Double
        Dim sAccountNo As String
        Dim sStatus As String
        Dim sRequetItemStatus As String
        Dim sNotes As String
    End Structure

    Public Structure gSaleTicketRecordUDT
        Dim bFlag As modo
        Dim nRequestSeq As Short
        Dim nItemSeq As Short
        Dim nTicketSeq As Short
        Dim sItemDesc As String
        Dim nQty As Double
        Dim nAvailableQty As Double
        Dim nSaleAmount As Double
        Dim dtSaleDate As Date
        Dim sBuyer As String
        Dim sNotes As String
    End Structure

    'jp.E013.end
    Public Structure gWordDocUDT
        Dim sInvoiceDate As String
        Dim sAddress As String
        Dim sBillingPeriod As String
        Dim sAccountNo As String
        Dim sInvoiceNo As String
        Dim sDescription As String
        Dim sInvoiceTotalFormatted As String
        Dim sSavings As String
        Dim sSavingsFormatted As String
        Dim sPercent As String
        Dim sStoreFlatFeeFormatted As String
        Dim sGrandTotalFormatted As String
        Dim sGreeting As String
        Dim sLocation As String
        Dim rsStoreGroup As DataTable
    End Structure

    Public Structure gWordDocFlagUDT
        Dim bSavingsPercent As Boolean
        Dim bStoreFlatFee As Boolean
        Dim bInvoiceFee As Boolean
        Dim bTax As Boolean
        Dim bTotal As Boolean
        Dim bLocation As Boolean
        Dim bTotalByStoreGroup As Boolean
    End Structure

    Public Structure gWebReportUDT
        Dim bFlag As modo
        Dim webReportId As Short
        Dim tableName As String
        Dim reportDesc As String
        Dim enabledFlag As String
    End Structure


    Public gExportCheckExcp As gExportCheckExcpUDT
    Public gGroupsRecord As gGroupsRecordUDT
    Public gCustomerRecord As gCustomerRecordUDT
    Public gServiceRecord As gServiceRecordUDT
    Public gUserRecord As gUserRecordUDT
    Public gCheck As gCheckUDT
    Public gCheckVoid As gCheckVoidUDT
    Public gCheckRenumber As gCheckVoidUDT
    Public gCheckReQuery As String
    Public gVendor As gVendorUDT
    Public gReport As gReportUDT
    Public gBank As gBankUDT
    Public gBankAccount As gBankAccountUDT
    Public gCheckBatchSearch As gCheckBatchSearchUDT
    Public gCreditCard As gCreditCardUDT
    Public gbCheck As Boolean
    Public gbPrinter As Boolean
    Public gDump As gDumpUDT
    'Public gsGroupId As String 'To export check, group that customer belongs to
    Public gErrNumber As Integer
    Public gErrSource As String
    Public gErrDescription As String
    Public gGrpdef As gGrpDefUDT
    Public gServiceGroupRecord As gServiceGroupRecordUDT

    'jp.100309.E015
    Public gAlertRecord As gAlertRecordUDT

    'jp.110609.E013
    Public gSaleRequest As gSaleRequestRecordUDT
    Public gSaleItem As gSaleItemRecordUDT
    Public gSaleTicket As gSaleTicketRecordUDT

    'Data type to handle rates
    Public Structure gRateUDT
        Dim old_rate As Double
        'UPGRADE_NOTE: Rate was upgraded to Rate_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim Rate_Renamed As Double
        Dim GlmRate As Double
    End Structure

    'Global Parameters
    Public Structure gGlobSettingsUDT
        Dim bFieldsFromDB As Boolean
        Dim sReportDir As String 'Reports folder
        Dim nMaxBatchCheckDetails As Short 'Max number of details in Batch check
        Dim sCheckLogoFile As String 'bmp, gif file that holds the logo to be printed in checks
        Dim eCheckPaperSource As CheckPaper
        Dim bDebugFlag As Boolean
        Dim sMswordTemplateFile As String
        Dim sDbPort As String 'SqlServer Db Port to connect to
    End Structure

    'jp.111609.E011.begin
    'Address_Catalog - STORE
    Public Structure gStoreAddressUDT
        Dim bAddressFlag As addressMode
        Dim bFlag As modo
        Dim nStoreAddressSeq As Short
        Dim nAddressSeq As Short
        Dim sCustId As String
        Dim sCustName As String
        Dim nStoreId As Short
        Dim sStoreNumber As String
        Dim sAddress As String
        Dim sCity As String
        Dim sState As String
        Dim sZip As String
    End Structure

    'Store_Address
    Public Structure gStoreAddressRecordUDT
        Dim bFlag As modo
        Dim nStoreAddressSeq As Short
        Dim sCustId As String
        Dim sCustName As String
        Dim nStoreId As Short
        Dim sStoreNumber As String
        Dim sAddress As String
        Dim sCity As String
        Dim sState As String
        Dim sZip As String
    End Structure

    Public Structure gRptRecycleTonGenParamUDT
        Dim sCustId As String
        Dim sCustName As String
        'sStateId As String
        Dim nGroupSeq As Short
        'nPeriodSeq As Integer
        'sPeriodSeq As String
        Dim sPeriodSeqList As String
        'nPeriodStartSeq As Integer
        'nPeriodEndSeq As Integer
        Dim sStartDate As String
        Dim sEndDate As String
        'sReportCaption As String
        'nPeriodSeqFrom As Integer
        'nPeriodSeqTo As Integer
        'nError As Integer
    End Structure



    Public gGlobSettings As gGlobSettingsUDT
    Public Enum modo
        NewRecord = 1
        UpdateRecord = 2
        SavedRecord = 3 'Record succesfully saved in database
    End Enum

    Public Enum detmode
        NewRecord = 1
        UpdateRecord = 2
        DeleteRecord = 3
        FailedRecord = 4
        SavedRecord = 5
    End Enum

    Public Enum EqptStatus
        Active = 0
        Inactive = 1
    End Enum

    Public Enum addressMode
        LookupMode = 1
        InsertUpdateMode = 2
        RecordSelected = 3
    End Enum

    'Store
    Public gbStoreSearch As gStoreSearchUDT
    Public gbMode As modo 'To determine if modo is new or update
    Public gStoreRecord As gStoreRecordUDT
    'Vendor
    Public gbVendorMode As modo
    Public gVendorSearch As gVendorSearchUDT
    Public gVBranchRecord As gVBranchRecordUDT

    Public gQBSearch As gQBSearchUDT 'TRUE if some value returned
    'StoreEqpt
    Public gbStoreEqptMode As modo
    Public gStoreEqptRecord As gStoreEqptRecordUDT
    'AccountEqpt
    Public gbAccountEqptMode As modo
    Public gAccountEqptRecord As gAccountEqptUDT
    'Account
    Public gAccountRecord As gAccountRecordUDT
    'Contract
    Public gContractRecord As gContractRecordUDT
    'Invoice Det
    Public gInvDetRecord As gInvDetRecordUDT
    Public gInvHeaderRecord As gInvHeaderRecordUDT
    'Periods
    Public gPeriodRecord As gPeriodRecordUDT
    'Fees
    Public gCustFeeRecord As gCustFeeRecordUDT
    Public gFeeBillingRange As gFeeBillingRangeUDT
    Public gFeeBillingRangeDet As gFeeBillingRangeDetUDT
    Public gInvoicingGroup As gInvoicingGroupUDT
    'Invoice Help
    Public gInvoiceHelp As gInvoiceHelpUDT

    'RepDef
    Public gRepDef As gRepDefUDT
    Public gRepDefTemplate As gRepDefTemplateUDT

    'UPGRADE_WARNING: Arrays in structure gItplGridSelector may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Public gItplGridSelector As gItplGridSelectorUDT
    'UPGRADE_WARNING: Arrays in structure gItplGridSelector2 may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Public gItplGridSelector2 As gItplGridSelector2UDT

    Public gStoreAddress As gStoreAddressUDT
    Public gStoreAddressRecord As gStoreAddressRecordUDT

    Public gWebReport As gWebReportUDT
    'Constants
    Public Const UI_ALL As String = "<All>"
    Public Const UI_SELECTED_VALUES As String = "<Selected Values>"
    Public Const MAX_CHECK_INVOICE As Short = 16 'Max number of invoices to be printed
    'Default DB Port
    Public Const DEFAULT_DB_PORT As Short = 1433

    'Excel
    Public Const XL_NOTRUNNING As Integer = 429
    Public Const MAX_MEM_RECORD As Short = 500
    'Word
    Public Const MSWORD_CUSTOMER_INVOICE_TEMPLATE As String = "GLM_Watermark_Template.doc"
    Public Const MSWORD_DEFAULT_TEMPLATE As String = "DEFAULT"

    Public Const MSWORD_FONT_NAME As String = "Arial"
    Public Const MSWORD_FONT_SIZE As String = "10"
    Public Const MSWORD_FONT_SIZE_TITLE As String = "16"
    Public Const MSWORD_BODY_LINE1 As String = "TRASH AND RECYCLING COST CONTAINMENT CHARGES for Management Consultant Services performed for "
    Public Const MSWORD_BODY_LINE2 As String = " locations."
    Public Const MSWORD_REMIT_ADDRESS As String = "REMIT TO:" & vbCrLf & vbCrLf & "GLM DFW,Inc." & vbCrLf & "17300 Preston Road, Suite 300" & vbCrLf & "Dallas, Texas 75252"
    Public Const MSWORD_FOOTER As String = "Thank you for your business. Please remit payment upon receipt."
    'Table Names
    Public Const TABLE_ADDRESS_CATALOG As String = "address_catalog"
    Public Const ADDRESS_CATALOG_ADDRESS As String = "address"
    Public Const ADDRESS_CATALOG_CITY As String = "city"
    Public Const ADDRESS_CATALOG_STATE_ID As String = "state_id"
    Public Const ADDRESS_CATALOG_ZIP As String = "zip"

    'Report Names
    Public Const RPT_GLM_INVOICE_REPORT As String = "GLM Invoice Report"
    'Default Date Format
    Public Const DATEFORMAT As String = "MM-dd-yyyy"


    'Address_Catalog constants for Context field
    Public Const ADDRESS_CATALOG_CONTEXT_STORE As String = "STORE"

    'Domain Fields
    Public Const DOMAIN_REQUEST_ITEM_STATUS As String = "request_item_status"

    'Commented to eliminate reference to Excel library
    'Public XLApp As Excel.Application
    'Public XL_wbook As Excel.Workbook
    'Public XL_wsheet As Excel.Worksheet

    'Max number of records in recordset
    Public Const MAX_RECORDS As Short = 500

    'Group Types
    Public Const GROUP_LOCAL As String = "LOCAL"
    Public Const GROUP_AREA As String = "AREA"
    Public Const GROUP_DISTRICT As String = "DISTRICT"
    Public Const GROUP_REGION As String = "REGION"

    'Report Templates
    Public Const SYS_GIR_GLMRATE_AUDIT As String = "SYS_GIR_GLMRATE_AUDIT"
    Public Const SYS_CCR_GLMRATE_AUDIT As String = "SYS_CCR_GLMRATE_AUDIT"
    'Report Names
    Public Const COST_CONTAINMENT_REPORT As String = "Cost Containment Report"
    Public Const GLM_INVOICE_REPORT As String = "GLM Invoice Report"

    'Raw_bucketlist.upload_status values
    Public Const UPLOAD_STATUS_NEW As String = "NEW"
    Public Const UPLOAD_STATUS_FAILED As String = "FAILED"
    Public Const UPLOAD_STATUS_VALID As String = "VALID"
    Public Const UPLOAD_STATUS_COMPLETE As String = "COMPLETE"

    'Tonnage Recycling Report Constants.begin
    Public Const POUNDS_PER_TON As Short = 2000
    Public Const RPTRECYCLETONGEN_MONTHLY_FREQUENCY As Double = 4.33
    Public Const RPTRECYCLETONGEN_PU_FREQUENCY As Short = 1
    'Content.content_desc
    Public Const RPTRECYCLETONGEN_OCC_BALES As String = "OCC-BALES"
    Public Const RPTRECYCLETONGEN_OCC As String = "OCC"
    Public Const RPTRECYCLETONGEN_PAPER As String = "PAPER"
    Public Const RPTRECYCLETONGEN_RECYCLE As String = "RECYCLE"
    Public Const RPTRECYCLETONGEN_COMPOST As String = "COMPOST"
    Public Const RPTRECYCLETONGEN_FOODWASTE As String = "FOOD WASTE"
    Public Const RPTRECYCLETONGEN_CONDEMO As String = "CON./DEMO."
    Public Const RPTRECYCLETONGEN_CONCRETE As String = "CONCRETE"
    Public Const RPTRECYCLETONGEN_TRASH As String = "TRASH"
    Public Const RPTRECYCLETONGEN_COMMINGLED_RECYCLE As String = "COMMINGLED RECYCLE"
    Public Const RPTRECYCLETONGEN_BOOK_RECYCLING As String = "BOOK RECYCLING"
    Public Const RPTRECYCLETONGEN_MIXED_PAPER As String = "MIXED PAPER"
    Public Const RPTRECYCLETONGEN_MIXED_RECYCLE As String = "MIXED_RECYCLE"
    Public Const RPTRECYCLETONGEN_WOOD As String = "WOOD"


    'Equipment.eqpt_type_desc
    Public Const RPTRECYCLETONGEN_EQPT_BALER As String = "BAL"
    Public Const RPTRECYCLETONGEN_EQPT_PKR As String = "PKR"
    Public Const RPTRECYCLETONGEN_EQPT_DUMP As String = "DUM"
    Public Const RPTRECYCLETONGEN_EQPT_TOTE As String = "TOT"
    Public Const RPTRECYCLETONGEN_EQPT_OT As String = "O/T"
    Public Const RPTRECYCLETONGEN_EQPT_VIP As String = "VIP"
    'Units of measure
    Public Const RPTRECYCLETONGEN_UOM_YARDS As String = "YD"
    Public Const RPTRECYCLETONGEN_UOM_GAL As String = "GAL"
    'ServiceGroup.serv_group_name
    Public Const RPTRECYCLETONGEN_SERV_BALER As String = "RPTRECYCLETONGEN_BALER"
    Public Const RPTRECYCLETONGEN_SERV_PKR_TON As String = "RPTRECYCLETONGEN_PKR_TON"
    Public Const RPTRECYCLETONGEN_SERV_PKR_PU As String = "RPTRECYCLETONGEN_PKR_PU"
    Public Const RPTRECYCLETONGEN_TOTE_TON As String = "RPTRECYCLETONGEN_TOTE_TON"
    Public Const RPTRECYCLETONGEN_TOTE_PU As String = "RPTRECYCLETONGEN_TOTE_PU"
    Public Const RPTRECYCLETONGEN_SERV_TOTE As String = "RPTRECYCLETONGEN_TOTE"
    Public Const RPTRECYCLETONGEN_COMPOST_PU As String = "RPTRECYCLETONGEN_COMPOST_PU"
    Public Const RPTRECYCLETONGEN_COMPOST_TON As String = "RPTRECYCLETONGEN_COMPOST_TON"
    Public Const RPTRECYCLETONGEN_CONDEMO_PU As String = "RPTRECYCLETONGEN_CONDEMO_PU"
    Public Const RPTRECYCLETONGEN_CONDEMO_TON As String = "RPTRECYCLETONGEN_CONDEMO_TON"
    Public Const RPTRECYCLETONGEN_TRASH_PU As String = "RPTRECYCLETONGEN_TRASH_PU"
    Public Const RPTRECYCLETONGEN_TRASH_TON As String = "RPTRECYCLETONGEN_TRASH_TON"
    Public Const RPTRECYCLETONGEN_TRASH_PKR_PU As String = "RPTRECYCLETONGEN_TRASH_PKR_PU"
    Public Const RPTRECYCLETONGEN_TRASH_PKR_TON As String = "RPTRECYCLETONGEN_TRASH_PKR_TON"
    Public Const RPTRECYCLETONGEN_TRASH_TOTE_PU As String = "RPTRECYCLETONGEN_TRASH_TOTE_PU"
    Public Const RPTRECYCLETONGEN_TRASH_TOTE_TON As String = "RPTRECYCLETONGEN_TRASH_TOTE_TON"
    Public Const RPTRECYCLETONGEN_TRASH_VIP_PU As String = "RPTRECYCLETONGEN_TRASH_VIP_PU"
    Public Const RPTRECYCLETONGEN_TRASH_VIP_TON As String = "RPTRECYCLETONGEN_TRASH_VIP_TON"
    Public Const RPTRECYCLETONGEN_TRASH_OT_PU As String = "RPTRECYCLETONGEN_TRASH_OT_PU"
    Public Const RPTRECYCLETONGEN_TRASH_OT_TON As String = "RPTRECYCLETONGEN_TRASH_OT_TON"
    Public Const RPTRECYCLETONGEN_DUM_TON As String = "RPTRECYCLETONGEN_DUM_TON"
    Public Const RPTRECYCLETONGEN_DUM_PU As String = "RPTRECYCLETONGEN_DUM_PU"
    Public Const RPTRECYCLETONGEN_YARDAGE As String = "RPTRECYCLETONGEN_YARDAGE"
    Public Const RPTRECYCLETONGEN_CONT_TON As String = "RPTRECYCLETONGEN_CONT_TON"
    Public Const RPTRECYCLETONGEN_CONT_PU As String = "RPTRECYCLETONGEN_CONT_PU"
    Public Const FEE_PER_TON_OVER As String = "FEE_PER_TON_OVER"
    Public Const SERVICE_GROUP_DET_PROPERTY_NUMTONS As String = "Number of Tons"


    'Tonnage Recycling Report Constants.end

    'Max number of Weigths to be entered per detail in an invoice
    'Public Const MAX_DET_WGT_RECORD As Integer = 100
    Public bUserCancel As Boolean

    'Used to transfer data between frmCheckBrowse and frmCheckBrowseDet
    Public grsCheck As DataTable

    'For general use data in load_array
    Public Structure gRecordUDT
        Dim Index As Short
        'Integer Fields
        Dim int_field1 As Short
        Dim int_field2 As Short
        Dim int_field3 As Short
        Dim int_field4 As Short
        Dim int_field5 As Short
        'String Fields
        Dim str_field1 As String
        Dim str_field2 As String
        Dim str_field3 As String
        Dim str_field4 As String
        Dim str_field5 As String
    End Structure

    Public Structure gTableUDT
        <VBFixedArray(MAX_MEM_RECORD)> Dim aRecord() As gRecordUDT

        'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            ReDim aRecord(MAX_MEM_RECORD)
        End Sub
    End Structure
    'UPGRADE_WARNING: Arrays in structure gTable may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Public gTable As gTableUDT
    'Used in frmCheckPaper to choose paper
    Public gCheckPaperSource As CheckPaper

    Public gnTimeout As Short
    Public Structure gInvDetRecordUDT
        Dim bMode As detmode
        Dim dServDate As Date
        Dim sEquipment As String
        Dim nEquipment As Short
        Dim sService As String
        Dim nService As Short
        Dim nUsage As Double
        Dim nUnits As Double
        Dim sType As String
        Dim nOldRate As Double
        Dim nRate As Double
        Dim nGlmRate As Double
        Dim sComments As String
        Dim sBillSavingFlag As String
        'rsDetailWgt As sqldatareader
        Dim nInvoiceDetNo As Short
    End Structure
    Public gInvDetWgt As gInvDetWgtUDT

    'MS-Word Template
    Public Structure gCustInvTemplateUDT
        Dim bFlag As modo
        Dim nTemplateId As Short
        Dim sTemplateName As String
        Dim sDescription As String
        Dim sFilename As String
    End Structure

    Public gCustInvTemplate As gCustInvTemplateUDT
    Private statusBarMessage As String




    'MAIN PROGRAM
    'UPGRADE_WARNING: Application will terminate when Sub Main() finishes. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E08DDC71-66BA-424F-A612-80AF11498FF8"'
    Public Sub Main()

        'Initialization variables
        InitVars()
        Dim validAccess As Boolean = False
        'Database Connection
        If Not dbCon() Then
            MsgBox("Error : Unable to connect to database", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Application Error")
            Exit Sub
        End If
        cm = New SqlCommand()
        cmSeed = New SqlCommand()
        cmReport = New SqlCommand()
        'Form Access
        validAccess = frmAccess.ShowDialog()

        'Load Main Form
        If gbAccess Then
            get_global_settings()
            load_objects()
            frmMain.Show()
            System.Windows.Forms.Application.Run()
        End If
    End Sub
    Sub InitVars()
        Dim rsReport As Object
        Dim Vendor As QbFileType
        gbAccess = False
        gbError = False
        'Debug Option gbDebug is set in get_global_settings()

        'get_global_settings
        'Parametrize file name
        'sLogfile = "e:\Logfile.txt"
        'OS drive letter es de la forma "C:\" o "E:\"
        sLogfile = OSdriveLetter & "\" + Environment.UserName & "\Logfile.txt"
        gReport.Index = 0
        gReport.name = ""
        gReport.static_Renamed = True
        bcnStatus = cnStatus.NoTrans
        gsDatabase = "glm"
        gsConfigFile = "config.txt"
        'UPGRADE_WARNING: Couldn't resolve default property of object Vendor. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        gQbFileType = Vendor
        gnTimeout = 300 '5 minutes

        'Initializing recordsets
        rsHelp = Nothing
        rsReport = Nothing
        grsState = Nothing
        grsCheck = Nothing
        grsCustomer = Nothing
        
        gExportCheckExcp.rs = Nothing

        gCheck.rsStore = Nothing
        gItplGridSelector.rsResult = Nothing
    End Sub
    'Obtain global parameters
    Public Sub get_global_settings()
        Dim cmd As SqlCommand = cn.CreateCommand
        sStmt = "SELECT fields_from_db, report_dir, " & "check_logo_file, max_batch_check_details, " & "check_paper_source, debug_flag " & " FROM SSetting "
        cmd.CommandText = sStmt
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.Rows.Count > 0 Then
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item("fields_from_db")) Then
                gGlobSettings.bFieldsFromDB = False
            Else
                If rs.Rows(0).Item("fields_from_db") = "YES" Then
                    gGlobSettings.bFieldsFromDB = True
                Else
                    gGlobSettings.bFieldsFromDB = False
                End If
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item("report_dir")) Then
                gGlobSettings.sReportDir = "f:\jp\Reports"
            Else
                gGlobSettings.sReportDir = rs.Rows(0).Item("report_dir")
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item("check_logo_file")) Then
                gGlobSettings.sCheckLogoFile = "c:\glm\visual basic\glm-system\icons\logo_check3.bmp"
            Else
                gGlobSettings.sCheckLogoFile = rs.Rows(0).Item("check_logo_file")
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item("max_batch_check_details")) Then
                gGlobSettings.nMaxBatchCheckDetails = 6 '12
            Else
                gGlobSettings.nMaxBatchCheckDetails = rs.Rows(0).Item("max_batch_check_details")
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item("check_paper_source")) Then
                gGlobSettings.eCheckPaperSource = CheckPaper.Imprinted
            Else
                If Trim(rs.Rows(0).Item("check_paper_source")) = "Imprinted" Then
                    gGlobSettings.eCheckPaperSource = CheckPaper.Imprinted
                Else
                    gGlobSettings.eCheckPaperSource = CheckPaper.Blank
                End If
            End If

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item("debug_flag")) Then
                gGlobSettings.bDebugFlag = False
            Else
                If rs.Rows(0).Item("debug_flag") = "YES" Then
                    gGlobSettings.bDebugFlag = True
                Else
                    gGlobSettings.bDebugFlag = False
                End If
            End If

            gGlobSettings.sMswordTemplateFile = get_default_msword_template(MSWORD_DEFAULT_TEMPLATE)

            gbDebug = gGlobSettings.bDebugFlag


        End If



    End Sub
    Public Function dbCon() As Boolean

        cn = New SqlConnection()
        rs = Nothing

        'Test
        dbCon = True
        Exit Function


        'SA connection deactivated
        '***************************************

        On Error GoTo ErrorHandler
        '      Dim txtServername As String = ""
        'With cn
        '          .Provider = "SQLOLEDB"
        '          'UPGRADE_WARNING: Couldn't resolve default property of object txtServername. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '          .ConnectionString = "user id=sa;password=;" & "Data Source=" & Trim(txtServername) & ";" & "Initial catalog=glm, Network Library=DBMSSOCN"
        '          .Open()
        '      End With

        'Set rs = cn.Execute("select suser_name from suser")

        dbCon = True
        Exit Function

ErrorHandler:
        'For Each adoErr In cn.Errors
        '    MsgBox(adoErr.Description)
        'Next adoErr
        dbCon = False
    End Function

    Sub msg()

    End Sub

    Public Sub load_objects()
        load_state()
        load_customer()
    End Sub
    'Loads recordset with data from State table
    Public Sub load_state()
        Dim dt As DataTable
        On Error GoTo ErrorHandler

        sStmt = "SELECT DISTINCT state_id FROM suser_data " & "WHERE suser_data.suser_name='" & gsUser & "' " & "ORDER BY 1"
        grsState = getDataTable(sStmt)

        'grsState.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If grsState.Rows.Count > 0 Then
            '?????????
            'grsState.MoveLast()
        End If
        Exit Sub

ErrorHandler:
        save_error("General.bas Module", "load_state")
        MsgBox("Unexpected error when loading state info.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
    End Sub
    'Carga un combo a partir de un recordset
    Public Sub load_cb(ByRef cb As System.Windows.Forms.ComboBox, ByRef rsSource As SqlDataReader)
        Dim nCounter As Short

        On Error GoTo ErrorHandler

        nCounter = 0
        

        cb.Items.Clear()
        If Not rsSource.HasRows() Then
            Exit Sub
        End If

        While rsSource.Read
            cb.Items.Insert(nCounter, rsSource.Item(0))
            nCounter = nCounter + 1
        End While
        
        Exit Sub

ErrorHandler:

        save_error("General.bas", "load_cb")
        Err.Raise(gErrNumber, gErrSource, gErrDescription)

    End Sub
    Public Sub load_cb(ByRef cb As System.Windows.Forms.ComboBox, ByRef rsSource As DataTable)
        Dim nCounter As Short

        On Error GoTo ErrorHandler

        nCounter = 0
        If Not rsSource.Rows.Count > 0 Then
            Exit Sub
        End If

        cb.Items.Clear()
        If rsSource.Rows.Count = 0 Then
            Exit Sub
        End If

        For row As Integer = 0 To rsSource.Rows.Count - 1
            cb.Items.Insert(nCounter, rsSource.Rows(0).Item(0))
            nCounter = nCounter + 1
        Next row
        
        Exit Sub

ErrorHandler:

        save_error("General.bas", "load_cb")
        Err.Raise(gErrNumber, gErrSource, gErrDescription)

    End Sub
    'Version extendida de load_cb.
    'Carga un combo a partir de un recordset
    'cb         Combo a cargar
    'rsSoruce   Recordset con datos
    'nPosicion  Campo que se usa para cargar combo. Posiciones empiezan en 0.
    Public Sub load_cb2(ByRef cb As System.Windows.Forms.ComboBox, ByRef rsSource As DataTable, ByRef nPosition As Short)
        Dim nCounter As Short

        On Error GoTo ErrorHandler

        nCounter = 0

        cb.Items.Clear()
        If Not rsSource.Rows.Count > 0 Then
            Exit Sub
        End If

        'Verifico que no se referencia a un campo que no existe
        'If nPosition < rsSource.Item().Count Then
        If nPosition < rsSource.Columns.Count Then
            'No problema
        Else
            Exit Sub 'Este campo no existe en recordset
        End If

        For row As Integer = 0 To rsSource.Rows.Count - 1
            cb.Items.Insert(nCounter, rsSource.Rows(row).Item(nPosition))
            nCounter = nCounter + 1
        Next row
        
        Exit Sub

ErrorHandler:

        save_error("General.bas", "load_cb2")
        Err.Raise(gErrNumber, gErrSource, gErrDescription)

    End Sub
    'Version extendida de load_cb2
    Public Sub load_cb3(ByRef cb As System.Windows.Forms.ComboBox, ByRef rsSource As DataTable, ByRef nPosition As Short, ByRef bClear As Boolean)
        Dim nCounter As Short
        Dim tmpDR As DataTable = rsSource

        On Error GoTo ErrorHandler

        nCounter = 0
        If Not rsSource.Rows.Count > 0 Then
            Exit Sub
        Else
            tmpDR = rsSource
            nCounter = rsSource.Columns.Count
        End If


        If bClear Then
            cb.Items.Clear()
        End If
        If nCounter = 0 Then
            Exit Sub
        End If

        'Verifico que no se referencia a un campo que no existe
        If nPosition < nCounter Then
            'No problema
        Else
            Exit Sub 'Este campo no existe en recordset
        End If

        If bClear Then
            nCounter = 0
        Else
            nCounter = cb.Items.Count
        End If

        For row As Integer = 0 To rsSource.Rows.Count - 1
            cb.Items.Insert(nCounter, rsSource.Rows(row).Item(nPosition))
            nCounter = nCounter + 1
        Next
        
        Exit Sub

ErrorHandler:

        save_error("General.bas", "load_cb3")
        Err.Raise(gErrNumber, gErrSource, gErrDescription)

    End Sub
    Private Sub load_cb4(ByRef cb As System.Windows.Forms.ComboBox, ByRef rsSource As DataTable, ByRef nPosNum As Short, ByRef nPosDesc As Short)
        Dim rssoirce As Object
        Dim nCounter As Short

        On Error GoTo ErrorHandler

        nCounter = 0
        

        cb.Items.Clear()
        If rsSource.rows.Count = 0 Then
            Exit Sub
        End If

        'Verifico que no se referencia a un campo que no existe
        'UPGRADE_WARNING: Couldn't resolve default property of object rssoirce.Fields. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If nPosNum < rsSource.Columns.Count And nPosDesc < rsSource.Columns.Count Then
            'No problema
        Else
            Exit Sub 'Este campo no existe en recordset
        End If

        For row As Integer = 0 To rsSource.Rows.Count - 1
            cb.Items.Insert(nCounter, rsSource.Rows(row).Item(nPosNum))
            VB6.SetItemData(cb, cb.SelectedIndex, rsSource.Rows(row).Item(nPosDesc))
            nCounter = nCounter + 1
        Next row
        
        Exit Sub

ErrorHandler:

        save_error("General.bas", "load_cb2")
        Err.Raise(gErrNumber, gErrSource, gErrDescription)

    End Sub

    'Carga los clientes permitidos para este usuario
    Public Sub load_customer()

        On Error GoTo ErrorHandler

        sStmt = "SELECT DISTINCT cust_id FROM suser_data " & "WHERE suser_data.suser_name ='" & gsUser & "' " & "ORDER BY 1"

        grsCustomer = getDataTable(sStmt) '.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'grsCustomer.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If grsCustomer.Rows.Count > 0 Then
            '            grsCustomer.MoveLast()
        End If

        Exit Sub

ErrorHandler:
        save_error("General.bas Module", "load_customer")
        MsgBox("Unexpected error when loading Customer info.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")

    End Sub
    'Busca la frase en el combo y lo selecciona
    Public Sub set_cb(ByRef cb As System.Windows.Forms.ComboBox, ByRef sWord As String)
        Dim i As Short
        If cb.Items.Count = 0 Then
            Exit Sub
        End If

        For i = 0 To cb.Items.Count - 1
            If Trim(VB6.GetItemString(cb, i)) = Trim(sWord) Then
                cb.SelectedIndex = i
                Exit For
            End If
        Next i

    End Sub
    'Selecciona del combo aquel valor cuya propiedad ItemData
    'es igual al parametro nItemdata
    Public Sub set_cb_ItemData(ByRef cb As System.Windows.Forms.ComboBox, ByRef nItemData As Short)
        Dim i As Short
        If cb.Items.Count = 0 Then
            Exit Sub
        End If
        Dim cbVal As String = VB6.GetItemData(cb, i).ToString
        For i = 0 To cb.Items.Count - 1
            If VB6.GetItemData(cb, i) = nItemData Then
                cb.SelectedIndex = i
                Exit For
            End If
        Next i
    End Sub
    'Extended from set_cb_itemdata
    'Returns:
    'TRUE Record was found
    'FALSE Record was not found
    Public Function set_cb_ItemData2(ByRef cb As System.Windows.Forms.ComboBox, ByRef nItemData As Short) As Boolean
        Dim i As Short

        set_cb_ItemData2 = False
        If cb.Items.Count = 0 Then
            Exit Function
        End If

        For i = 0 To cb.Items.Count - 1
            If VB6.GetItemData(cb, i) = nItemData Then
                cb.SelectedIndex = i
                set_cb_ItemData2 = True
                Exit For
            End If
        Next i

    End Function
    'Carga un combo a partir de los datos de un query
    'cb: es el combo a cargar
    'sQuery: es la sentencia SELECT  a ejecutar
    'nFields: es el numero de campos en query, pero
    '         solo tiene efecto cuando es =2, en ese caso
    '         guarda el 2do campo que es numerico en ItemData
    Public Sub load_cb_query(ByRef cb As System.Windows.Forms.ComboBox, ByRef sQuery As String, ByRef nFields As Short)
        Dim nCounter As Short

        On Error GoTo ErrorHandler

        cb.Items.Clear()


        rs = getDataTable(sQuery) '.Open(sQuery, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        nCounter = 0
        If rs.Rows.Count > 0 Then

            For row As Integer = 0 To rs.Rows.Count - 1
                'El primer campo es la descripcion
                cb.Items.Insert(nCounter, rs.Rows(row).Item(0))
                Select Case nFields
                    Case 2
                        'El segundo campo es el codigo
                        VB6.SetItemData(cb, nCounter, rs.Rows(row).Item(1))
                End Select
                nCounter = nCounter + 1

            Next row

           
        Else
            Exit Sub
        End If
        Exit Sub

ErrorHandler:
        save_error("General.bas", "load_cb_query")
        'Err.Raise gErrNumber, gErrSource, gErrDescription

        kill_app()




    End Sub
    'Version extendida de load_cb.
    'Carga un combo a partir de los datos de un query
    'Se asume que el segundo campo del SELECT es de tipo
    'numerico y se lo almacena en la propiedad ItemData del comboBox
    'como en el caso de la tabla de vendor. donde se necesita
    'vend_seq y vend_name.
    'cb         Combo
    'sQuery     Query a Ejecutar
    'nFields    Numero de campos incluidos en la sentencia SELECT
    'bClear     Bandera para determinar si se inicializa o no el combo
    Public Sub load_cb_query2(ByRef cb As System.Windows.Forms.ComboBox, ByRef sQuery As String, ByRef nFields As Short, ByRef bClear As Boolean)


        Dim nCounter As Short
        gbError = False

        On Error GoTo ErrorHandler
        If bClear Then
            cb.Items.Clear()
        End If

        rs = getDataTable(sQuery) '.Open(sQuery, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        'Inicializa el indice del combo
        If bClear Then
            nCounter = 0
        Else
            nCounter = cb.Items.Count
        End If

        If rs.Rows.Count > 0 Then

            For row As Integer = 0 To rs.Rows.Count - 1
                cb.Items.Insert(nCounter, rs.Rows(row).Item(0))
                Select Case nFields
                    Case 2
                        VB6.SetItemData(cb, nCounter, rs.Rows(row).Item(1))
                        'VB6.SetItemData(cb, nCounter, rs.Rows(0).Item(1))
                End Select
                nCounter = nCounter + 1
            Next row
        Else
            Exit Sub
        End If
        Exit Sub

ErrorHandler:
        gbError = True
        save_error("General.bas", "load_cb_query2")
        'error_msg
    End Sub

    'Version extendida de load_cb_query2
    'Carga un combo a partir de los datos de un query
    'Se asume que el segundo campo del SELECT es de tipo
    'numerico y se lo almacena en la propiedad ItemData del comboBox
    'como en el caso de la tabla de vendor. donde se necesita
    'vend_seq y vend_name.
    'cb         Combo
    'sQuery     Query a Ejecutar
    'nFields    Numero de campos incluidos en la sentencia SELECT
    'bClear     Bandera para determinar si se inicializa o no el combo
    'maxRecords Numero de registros maximo a cargar en CB
    Public Sub load_cb_query4(ByRef cb As System.Windows.Forms.ComboBox, ByRef sQuery As String, ByRef nFields As Short, ByRef bClear As Boolean, ByRef maxRecords As Short)
        Dim nCounter As Short
        gbError = False

        On Error GoTo ErrorHandler
        If bClear Then
            cb.Items.Clear()
        End If

        rs = getDataTable(sQuery) '.Open(sQuery, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        'Inicializa el indice del combo
        If bClear Then
            nCounter = 0
        Else
            nCounter = cb.Items.Count
        End If

        If rs.Rows.Count > 0 Then
            For row As Integer = 0 To rs.Rows.Count - 1
                cb.Items.Insert(nCounter, rs.Rows(row).Item(0))
                Select Case nFields
                    Case 2
                        VB6.SetItemData(cb, nCounter, rs.Rows(row).Item(1))
                End Select
                nCounter = nCounter + 1
                If nCounter > maxRecords Then
                    Exit Sub
                End If
            Next row
        Else
            Exit Sub
        End If
        Exit Sub

ErrorHandler:
        gbError = True
        save_error("General.bas", "load_cb_query4")
        'error_msg
    End Sub
    'Loads combo with contents of field at position nFieldPosition in sQuery
    Public Sub load_cb_query5(ByRef cb As System.Windows.Forms.ComboBox, ByRef sQuery As String, ByRef nFieldPosition As Short, ByRef bClear As Boolean)
        Dim nCounter As Short
        gbError = False

        On Error GoTo ErrorHandler
        If bClear Then
            cb.Items.Clear()
        End If

        rs = getDataTable(sQuery) '.Open(sQuery, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        'Inicializa el indice del combo
        If bClear Then
            nCounter = 0
        Else
            nCounter = cb.Items.Count
        End If

        If rs.Rows.Count > 0 Then
            For row As Integer = 0 To rs.Rows.Count - 1
                cb.Items.Insert(nCounter, rs.Rows(row).Item(nFieldPosition))
                nCounter = nCounter + 1
            Next row
        Else
            Exit Sub
        End If
        Exit Sub

ErrorHandler:
        gbError = True
        save_error("General.bas", "load_cb_query5")
        'error_msg
    End Sub

    'Version extendida de load_cb2
    'Carga un arreglo a partir de los datos de un query
    'Se asume que el segundo campo del SELECT es de tipo
    'numerico y se lo almacena en la propiedad ItemData del comboBox
    'como en el caso de la tabla de vendor. donde se necesita
    'vend_seq y vend_name.
    'aTable     Arreglo donde se cargaran datos
    'sQuery     Query a Ejecutar
    'nFields    Numero de campos incluidos en la sentencia SELECT
    'nLastRecord Este argumento se usa cuando bCLear es DFALSE e indica el
    '           el indice del ultimo  registro en el arreglo
    'bClear     Bandera para determinar si se inicializa o no el arreglo
    Public Sub load_array_query(ByRef aTable As gTableUDT, ByRef sQuery As String, ByRef nIntFields As Short, ByRef nStrFields As Short, ByRef nLastRecord As Short, ByRef bClear As Boolean)


        Dim nCounter As Short
        Dim i As Short
        gbError = False

        On Error GoTo ErrorHandler
        'Limpia Arreglo
        If bClear Then
            aTable.Initialize()
            For i = 0 To MAX_MEM_RECORD
                aTable.aRecord(i).Index = -1
                aTable.aRecord(i).int_field1 = -1
                aTable.aRecord(i).int_field2 = -1
                aTable.aRecord(i).int_field3 = -1
                aTable.aRecord(i).int_field4 = -1
                aTable.aRecord(i).int_field5 = -1
                aTable.aRecord(i).str_field1 = ""
                aTable.aRecord(i).str_field2 = ""
                aTable.aRecord(i).str_field3 = ""
                aTable.aRecord(i).str_field4 = ""
                aTable.aRecord(i).str_field5 = ""
            Next i
        End If

        'rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs = getDataTable(sQuery) '.Open(sQuery, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        'Inicializa el indice del combo
        If bClear Then
            nCounter = 0
        Else
            nCounter = nLastRecord
        End If

        If rs.Rows.Count > 0 Then
            For row As Integer = 0 To rs.Rows.Count - 1
                If nCounter >= 100 Then
                    Exit For
                End If

                aTable.aRecord(nCounter).Index = nCounter
                'Integer Fields
                Select Case nIntFields
                    Case 1
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(0)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).int_field1 = rs.Rows(row).Item(0)
                        End If
                    Case 2
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(0)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).int_field1 = rs.Rows(row).Item(0)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(1)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).int_field2 = rs.Rows(row).Item(1)
                        End If
                    Case 3
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(0)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).int_field1 = rs.Rows(row).Item(0)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(1)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).int_field2 = rs.Rows(row).Item(1)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(2)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).int_field3 = rs.Rows(row).Item(2)
                        End If
                    Case 4
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(0)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).int_field1 = rs.Rows(row).Item(0)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(1)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).int_field2 = rs.Rows(row).Item(1)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(2)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).int_field3 = rs.Rows(row).Item(2)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(3)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).int_field4 = rs.Rows(row).Item(3)
                        End If
                    Case 5
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(0)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).int_field1 = rs.Rows(row).Item(0)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(1)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).int_field2 = rs.Rows(row).Item(1)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(2)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).int_field3 = rs.Rows(row).Item(2)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(3)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).int_field4 = rs.Rows(row).Item(3)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(4)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).int_field5 = rs.Rows(row).Item(4)
                        End If
                End Select

                'Sting Fields
                'nIntFields es el desplazamiento entre los campos int y string
                Select Case nStrFields
                    Case 1
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(nIntFields)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).str_field1 = rs.Rows(row).Item(nIntFields)
                        End If
                    Case 2
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(nIntFields)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).str_field1 = rs.Rows(row).Item(nIntFields)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(nIntFields + 1)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).str_field2 = rs.Rows(row).Item(nIntFields + 1)
                        End If
                    Case 3
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(nIntFields)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).str_field1 = rs.Rows(row).Item(nIntFields)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(nIntFields + 1)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).str_field2 = rs.Rows(row).Item(nIntFields + 1)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(nIntFields + 2)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).str_field3 = rs.Rows(row).Item(nIntFields + 2)
                        End If
                    Case 4
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(nIntFields)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).str_field1 = rs.Rows(row).Item(nIntFields)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(nIntFields + 1)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).str_field2 = rs.Rows(row).Item(nIntFields + 1)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(nIntFields + 2)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).str_field3 = rs.Rows(row).Item(nIntFields + 2)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(nIntFields + 3)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).str_field4 = rs.Rows(row).Item(nIntFields + 3)
                        End If
                    Case 5
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(nIntFields)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).str_field1 = rs.Rows(row).Item(nIntFields)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(nIntFields + 1)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).str_field2 = rs.Rows(row).Item(nIntFields + 1)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(nIntFields + 2)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).str_field3 = rs.Rows(row).Item(nIntFields + 2)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(nIntFields + 3)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).str_field4 = rs.Rows(row).Item(nIntFields + 3)
                        End If

                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If IsDBNull(rs.Rows(row).Item(nIntFields + 4)) Then
                            'Nothing
                        Else
                            aTable.aRecord(nCounter).str_field5 = rs.Rows(row).Item(nIntFields + 4)
                        End If
                End Select

                nCounter = nCounter + 1
            Next row
        Else
            Exit Sub
        End If
        Exit Sub

ErrorHandler:
        gbError = True
        save_error("General.bas", "load_array_query")
    End Sub

    'Version Extendida de load_cb_query
    'Carga un combo a partir de los datos de un query
    'Standard: El campo 2 del SELECT  (rs.item(1)) es el campo numerico
    'los demas campos se concatenan. El caracter "-" se usa para concatenar
    'los campos
    Public Sub load_cb_query3(ByRef cb As System.Windows.Forms.ComboBox, ByRef sQuery As String, ByRef nFields As Short)
        Dim nCounter As Short
        Dim i As Short
        Dim sDesc As String

        On Error GoTo ErrorHandler
        cb.Items.Clear()

        'rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs = getDataTable(sQuery) '.Open(sQuery, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        nCounter = 0
        If rs.Rows.Count > 0 Then

            For row As Integer = 0 To rs.Rows.Count - 1
                sDesc = ""
                For i = 0 To rs.Columns.Count - 1
                    If i = 1 Then
                        'Campo con indice
                    Else
                        If Trim(sDesc) = "" Then
                            sDesc = rs.Rows(row).Item(i)
                        Else
                            sDesc = Trim(sDesc) & " - " + rs.Rows(row).Item(i)
                        End If
                    End If
                Next i
                cb.Items.Insert(nCounter, sDesc)
                Select Case nFields
                    Case 2
                        VB6.SetItemData(cb, nCounter, rs.Rows(row).Item(1))
                End Select
                nCounter = nCounter + 1
            Next row

        Else
            Exit Sub
        End If
        Exit Sub

ErrorHandler:
        save_error("General.bas", "load_cb_query")
        Err.Raise(gErrNumber, gErrSource, gErrDescription)

    End Sub

    'Version extendida de load_cb_query
    'SE DESCARTAN los datos con descripcion NULO
    Public Sub load_cb_query_sec(ByRef cb As System.Windows.Forms.ComboBox, ByRef sQuery As String, ByRef nFields As Short)
        Dim nCounter As Short

        On Error GoTo ErrorHandler

        cb.Items.Clear()
        rs = getDataTable(sQuery) '.Open(sQuery, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        nCounter = 0
        If rs.Rows.Count > 0 Then
            For row As Integer = 0 To rs.Rows.Count - 1
                'El primer campo es la descripcion
                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                If Not IsDBNull(rs.Rows(row).Item(0)) Then
                    cb.Items.Insert(nCounter, rs.Rows(row).Item(0))

                    Select Case nFields
                        Case 2
                            'El segundo campo es el codigo
                            VB6.SetItemData(cb, nCounter, rs.Rows(row).Item(1))
                    End Select
                    nCounter = nCounter + 1
                End If
            Next row
        Else
            Exit Sub
        End If
        Exit Sub

ErrorHandler:
        save_error("General.Bas", "load_cb_query_sec")
        Err.Raise(gErrNumber, gErrSource, gErrDescription)
    End Sub

    Public Sub clear_objects()
        'UPGRADE_NOTE: Object grsCustomer may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        grsCustomer = Nothing
        'UPGRADE_NOTE: Object grsState may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        grsState = Nothing
        'UPGRADE_NOTE: Object cn may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        cn = Nothing
    End Sub
    'Funcion para manejo de errores
    Public Sub write_error(ByRef sMsg As String, ByRef sFile As String, Optional ByRef bModeNew As Boolean = False)

        Dim nFile As Short
        Dim bOpen As Boolean

        On Error GoTo ErrorHandler


        nFile = FreeFile()
        If bModeNew Then
            FileOpen(nFile, sFile, OpenMode.Input)
        Else
            FileOpen(nFile, sFile, OpenMode.Append)
        End If

        bOpen = True
        PrintLine(nFile, sMsg)

ErrorHandler:
        If bOpen Then
            FileClose(nFile)
        End If

        If Err.Number Then Err.Raise(Err.Number, , Err.Description)

    End Sub

    Public Sub save_error(ByRef sForm As String, ByRef sFunction As String)

        'Guarda error en variables globales
        cache_error()
        sError = "*************************************" & vbCrLf & "Date:     " & CStr(Now) & vbCrLf & _
                "Form:     " & sForm & vbCrLf & "Function: " & sFunction & vbCrLf & "Error:    " & Str(Err.Number) & vbCrLf & _
                "Desc:     " & Err.Description & vbCrLf & "Source:   " & Err.Source & vbCrLf & "*************************************"
        write_error(sError, sLogfile, False)
    End Sub

    'carga la informacion de usuario en la variable gProfile
    Public Function exec_sql(ByRef sSql As String) As DataTable
        Return getDataTable(sSql)
        Try
            exec_sql = getDataTable(sSql)
            'exec_sql = rsGeneral
            Exit Function

        Catch e As Exception
            MsgBox("Failed to Execute SQL statement:" & e.Message & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            '            exec_sql = Nothing
            '            save_error("General", "exec_sql")

        End Try
    End Function
    'Ejecuta un query y retorna el primer registro del resultado
    'ASume que el query solo selecciona 2 Strings
    Public Function exec_sql_single(ByRef sSql As String) As gDumpUDT
        Dim rsGeneral As DataTable
        Dim a As gDumpUDT = New gDumpUDT()
        exec_sql_single = a
        'On Error GoTo ErrorHandler

        rsGeneral = Nothing

        rsGeneral = getDataTable(sSql) '.Open(sSql, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rsGeneral.Rows.Count > 0 Then
            exec_sql_single.str1 = rsGeneral.Rows(0).Item(0).ToString 'Campo1
            If rsGeneral.Columns.Count > 1 Then
                exec_sql_single.str2 = rsGeneral.Rows(0).Item(1).ToString 'Campo2
            End If
        End If

        '

        'rsGeneral.Close
        Exit Function

ErrorHandler:
        save_error("General", "exec_sql_single")
        MsgBox("Failed to Execute Single SQL Statement." & vbCrLf & "Check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")

    End Function

    'Guarda en memoria el error
    Public Sub cache_error()
        gErrNumber = Err.Number
        gErrSource = Err.Source
        gErrDescription = Err.Description
    End Sub
    'Reemplaza comillas simples y dobles del string por espacios
    Public Function clear_quotes(ByRef sString As String) As String
        Dim sSearch As String
        Dim sTmp As String

        If Len(sString) = 0 Then
            clear_quotes = ""
            Exit Function
        End If

        sSearch = Chr(34) 'Comilla Doble
        sTmp = Replace(sString, sSearch, " ", 1)
        sSearch = Chr(39) ' Comilla Simple
        clear_quotes = Replace(sTmp, sSearch, " ", 1)


    End Function
    'Extension de clear_quotes
    'sString :      String a reemplazar
    'sBusca  :      String a Buscar
    'sReemplaza:    String a usar para reemplazar sBusca, sino se provee se
    '               usa espacios
    Public Function clear_quotes2(ByRef sString As String, ByRef sSearch As String, Optional ByRef sReplace As String = " ") As String

        'Dim sTmp As String

        'Valido parametros
        If Len(sString) = 0 Then
            clear_quotes2 = ""
            Exit Function
        End If

        If Len(sSearch) = 0 Then
            clear_quotes2 = sString 'No se hacen cambios
            Exit Function
        End If

        clear_quotes2 = Replace(sString, sSearch, sReplace, 1)
    End Function
    'Antepone una comilla simple a cada comilla simple que se encuentre
    Public Function quotation_mask(ByRef sString As String) As String
        'Valido parametros
        If Len(sString) = 0 Then
            quotation_mask = ""
            Exit Function
        End If

        quotation_mask = Replace(sString, "'", "''", , , CompareMethod.Text)
    End Function

    'sFile : Nombre de la plantilla en Excel
    'sMacro: Macro a ejecutar grabada en plantilla
    Public Function call_excel(ByRef sCustId As String, ByRef sFormatName As String, ByRef sRepCaption As String) As Boolean
        Dim XL_wsheet As Object
        Dim XL_wbook As Object
        Dim XLApp As Object
        Dim sFile As String
        Dim sMacro As String
        Dim fso As Scripting.FileSystemObject

        'On Error GoTo ErrorHandler

        fso = New Scripting.FileSystemObject

        'Obtener Plantilla
        sStmt = "SELECT DISTINCT xl_template, xl_macro " & " FROM RepCust " & " WHERE cust_id = '" & Trim(sCustId) & "' " & " AND format_name = '" & Trim(sFormatName) & "' " & " AND rep_no = " & "(SELECT rep_no FROM repdef " & " WHERE rep_caption = '" & Trim(sRepCaption) & "' "

        Try
            rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.Rows.Count <= 0 Then
                MsgBox("Excel template has not been defined." & vbCrLf & "Unable to continue.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
                call_excel = False
                Exit Function
            End If
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If IsDBNull(rs.Rows(0).Item("xl_template")) Then
                MsgBox("Excel template has not been defined." & vbCrLf & "Unable to continue.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "GLM Error")
                call_excel = False
                Exit Function
            Else
                sFile = rs.Rows(0).Item("xl_template")
                sMacro = rs.Rows(0).Item("xl_macro")
            End If
        Catch ex As Exception
            MsgBox("Error found while accessing RepCust table.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
            call_excel = False
            Exit Function
        End Try

        Try
            'Verificar si plantilla existe
            If fso.FileExists(Trim(sFile)) Then
                'OK
                'fso.CopyFile
            Else
                MsgBox("Excel Template was not found. Unable to continue.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "GLM Error")
                call_excel = False
                Exit Function
            End If
        Catch ex As Exception
        End Try

        'Abrir Archivo de Excel
        XLApp = GetObject(, "excel.application")
        'Set wk = XLApp.Workbooks.Add
        'UPGRADE_WARNING: Couldn't resolve default property of object XLApp.Workbooks. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        XL_wbook = XLApp.Workbooks.Open(sFile)
        'UPGRADE_WARNING: Couldn't resolve default property of object XL_wbook.Sheets. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        XL_wsheet = XL_wbook.Sheets.Add

        'UPGRADE_WARNING: Couldn't resolve default property of object XL_wsheet.name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        XL_wsheet.name = "Invoice Report"

        'XLApp.Visible = True
        call_excel = True
        'XLApp.Workbooks (0)
        'XLApp.Run "macro3"

ErrorEnd:
        Exit Function

ErrorHandler:
        If Err.Number = XL_NOTRUNNING Then
            'Comentado para eliminar referencia a Excel Lib
            'Set XLApp = New Excel.Application

            'Resume Next
        End If


    End Function

    Public Sub error_msg()
        MsgBox("A non-critical error has ocurred, please check " & vbCrLf & "your log file for details.", MsgBoxStyle.Exclamation, "GLM Message")

    End Sub
    Public Function add_padding(ByRef sSource As String, ByRef nMaxLen As Short) As String
        Dim nLen As Short
        Dim i As Short
        Dim sTmp As String

        sTmp = sSource
        nLen = Len(sSource)
        If nLen <= 0 Or nMaxLen <= 0 Then
            add_padding = ""
            Exit Function
        End If

        'Longitud es mayor a zero
        For i = nLen To nMaxLen
            sTmp = sTmp & " "
        Next i
        add_padding = sTmp

    End Function
    'Cuenta numero de factura que estan usando el periodo proporcionado
    'Parametros:
    '   sCustId: Cliente
    '   nPeriodSeq : Secuencia de periodo
    'Retorna
    '   numero e facturas encontradas
    Public Function invoice_assigned(ByRef sCustId As String, ByRef nPeriodSeq As Short) As Short

        On Error GoTo ErrorHandler

        invoice_assigned = -1
        sStmt = "SELECT count(*) FROM VInvoice " & " WHERE cust_id ='" & Trim(sCustId) & "' " & " AND period_seq =" & Str(nPeriodSeq)
        
        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.Rows.Count > 0 Then
            invoice_assigned = rs.Rows(0).Item(0)
        End If

        Exit Function

ErrorHandler:
        save_error("Unknow source", "invoice_assigned")
        MsgBox("Found error when verifying invoices.Please check log file for details.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
    End Function

    Public Sub clear_gCheckVoid()
        gCheckVoid.bOk = False
        gCheckVoid.nVoidCheckNo = -1
        gCheckVoid.nNewCheckNo = -1
        gCheckVoid.nBankCustSeq = -1
        gCheckVoid.bSameCheck = False
    End Sub

    Public Sub clear_gCheckRenumber()
        gCheckRenumber.bOk = False
        gCheckRenumber.nVoidCheckNo = -1
        gCheckRenumber.nNewCheckNo = -1
        gCheckRenumber.nBankCustSeq = -1
        gCheckRenumber.bSameCheck = False
    End Sub
    Public Sub clear_gBankAccount()
        gBankAccount.nBankId = -1
        gBankAccount.nBankCustSeq = -1
        gBankAccount.sBankAccount = ""
        gBankAccount.nLastCheckNo = -1
        gBankAccount.nBankAccountBalance = -1
    End Sub
    Public Sub clear_gSaleRequest()

        gSaleRequest.nRequestSeq = -1
        gSaleRequest.nStoreId = -1
        gSaleRequest.sCustId = ""
        gSaleRequest.sCustName = ""
        gSaleRequest.sRequestNo = ""
        gSaleRequest.sStoreNo = ""
        gSaleRequest.sTrackingNo = ""

    End Sub
    Public Sub clear_gCheck()
        gCheck.bSameCheck = False
        gCheck.CheckNo = -1
        gCheck.reprint = False
        gCheck.VoidCheckNo = -1
    End Sub

    Public Sub write_msg(ByRef sSource As String, ByRef sMsg As String)


        sError = "*************************************" & vbCrLf & "Date:     " & CStr(Now) & vbCrLf & "Source    " & sSource & vbCrLf & "Message:  " & sMsg & vbCrLf & "*************************************"
        write_error(sError, sLogfile, False)
    End Sub


    Public Sub clear_gItplGridSelector()
        Dim i As Short
        gItplGridSelector.Initialize()
        gItplGridSelector.bFlag = False
        'Set gItplGridSelector.rsResult = Nothing
        gItplGridSelector.sLeftCaption = ""
        gItplGridSelector.sRightCaption = ""
        gItplGridSelector.sOrderBy = ""
        gItplGridSelector.sQuerySource = ""
        gItplGridSelector.sQuerySelected = ""
        gItplGridSelector.sQueryInit = ""

        gItplGridSelector.sInvokeFromForm = ""

        For i = 0 To 10
            gItplGridSelector.aFields(i).sFieldName = ""
            gItplGridSelector.aFields(i).bVisible = False
            gItplGridSelector.aFields(i).nWidth = 1000
        Next i

    End Sub

    Public Sub clear_gItplGridSelector2()
        Dim i As Short

        gItplGridSelector2.Initialize()
        gItplGridSelector2.bFlag = False
        'Set gItplGridSelector.rsResult = Nothing
        'If gItplGridSelector2.rsResult.State <> adStateClosed Then
        '    gItplGridSelector2.rsResult.Close
        'End If
        gItplGridSelector2.sLeftCaption = ""
        gItplGridSelector2.sRightCaption = ""
        gItplGridSelector2.sOrderBy = ""
        gItplGridSelector2.sQuerySource = ""
        gItplGridSelector2.sQuerySelected = ""
        gItplGridSelector2.sQueryInit = ""
        gItplGridSelector2.sQueryHeader = ""
        gItplGridSelector2.sQueryOrderBy = ""


        For i = 0 To 10
            Try
                gItplGridSelector2.aFields(i).sFieldName = ""
                gItplGridSelector2.aFields(i).bVisible = False
                gItplGridSelector2.aFields(i).nWidth = 1000
            Catch
            End Try
        Next i

    End Sub
    'Returns the index in the ComboBox for the given Text
    Public Function get_index_in_cb(ByRef cb As System.Windows.Forms.ComboBox, ByRef sText As String) As Short
        Dim i As Object

        For i = 0 To cb.Items.Count - 1
            'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            cb.SelectedIndex = i
            If cb.Text = sText Then
                get_index_in_cb = cb.SelectedIndex
                Exit Function

            End If
        Next

        get_index_in_cb = -1

    End Function

    Public Function get_default_msword_template(ByRef sTemplateName As String) As String

        sStmt = "SELECT filename FROM CustomerInvoiceTemplate " & " WHERE template_name = '" & sTemplateName & "' "

        get_default_msword_template = My.Application.Info.DirectoryPath & "\" & MSWORD_CUSTOMER_INVOICE_TEMPLATE

        rs = getDataTable(sStmt) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.Rows.Count > 0 Then
            get_default_msword_template = rs.Rows(0).Item("filename")
        End If


    End Function
    Public Function get_msword_template(ByRef sTemplateName As String, Optional ByRef ntran As SqlTransaction = Nothing) As String

        sStmt = "SELECT filename FROM CustomerInvoiceTemplate " & " WHERE template_name = '" & sTemplateName & "' "

        get_msword_template = ""

        rs = getDataTable(sStmt, ntran) '.Open(sStmt, cn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.Rows.Count > 0 Then
            get_msword_template = rs.Rows(0).Item("filename")
        End If


    End Function

    'Kill current application due to missing db connectivity
    Public Sub kill_app()
        Dim f As Object

        If gErrNumber = -2147467259 Then
            MsgBox("Your session has terminated since " & vbCrLf & "other session was initiated in another computer", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "GLM Error")
            For Each f In System.Windows.Forms.Application.OpenForms
                'UPGRADE_ISSUE: Unload f was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="875EBAD7-D704-4539-9969-BC7DBDAA62A2"'
                f.close()
                f.dispose()
            Next f
            End
        End If

    End Sub

    'Changes the message in the Status Bar in Main form
    Public Sub setMainStatusBarMessage(ByRef msg As String)

        statusBarMessage = frmMain.sbMain.Text

        frmMain.sbMain.Text = msg
    End Sub

    Public Sub restoreMainStatusBarMessage()
        frmMain.sbMain.Text = statusBarMessage
    End Sub

    'Loasd combo with Store Groups
    Public Sub load_cb_storeGroups(ByRef sCaller As String, ByRef sCustId As String, ByRef cbGroupName As System.Windows.Forms.ComboBox)

        On Error GoTo ErrorHandler
        If Len(sCustId) <= 0 Then
            cbGroupName.Items.Clear()
            Exit Sub
        End If


        sStmt = "SELECT group_name,group_seq FROM groups " & " WHERE cust_id ='" & Trim(sCustId) & "'" & " AND type_id = '" & GROUP_LOCAL & "' " & " ORDER BY group_name"
        load_cb_query2(cbGroupName, sStmt, 2, True)

        If cbGroupName.Items.Count > 0 Then
            cbGroupName.SelectedIndex = 0
        End If

        Exit Sub

ErrorHandler:
        save_error(sCaller, "load_cb_storeGroups")
    End Sub


    Public Sub load_cb_period(ByRef sCaller As String, ByRef sCustId As String, ByRef cbPeriodName As System.Windows.Forms.ComboBox)
        Try
            If Len(sCustId) <= 0 Then
                cbPeriodName.Items.Clear()
                Exit Sub
            End If


            sStmt = "SELECT period_name, period_seq, period_start_date FROM period " & " WHERE cust_id ='" & Trim(sCustId) & "'" & " ORDER BY period_start_date DESC"
            load_cb_query2(cbPeriodName, sStmt, 2, True)



            If cbPeriodName.Items.Count > 0 Then
                cbPeriodName.SelectedIndex = 0
            End If
        Catch ex As Exception
            save_error(sCaller, "load_cb_period")
        End Try
        If Len(sCustId) <= 0 Then
            cbPeriodName.Items.Clear()
            Exit Sub
        End If


        sStmt = "SELECT period_name, period_seq, period_start_date FROM period " & " WHERE cust_id ='" & Trim(sCustId) & "'" & " ORDER BY period_start_date DESC"
        load_cb_query2(cbPeriodName, sStmt, 2, True)



        If cbPeriodName.Items.Count > 0 Then
            cbPeriodName.SelectedIndex = 0
        End If

        Exit Sub


    End Sub
End Module