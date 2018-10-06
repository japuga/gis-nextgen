USE [glm]
GO

/****** Object:  StoredProcedure [dbo].[usp_rep_cost_cont]    Script Date: 10/06/2018 13:07:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_rep_cost_cont]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_rep_cost_cont]
GO

USE [glm]
GO

/****** Object:  StoredProcedure [dbo].[usp_rep_cost_cont]    Script Date: 10/06/2018 13:07:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE   PROC [dbo].[usp_rep_cost_cont] 
	@nReportId INT, --Identificador del reporte
	@sCustId CHAR(2), @sStateId CHAR(3),
	@nGroupSeq INT, @nPeriodSeq INT,
	@sPeriodSeq CHAR(1),   --T : TRUE si la busqueda es por periodo
	@sStartDate SMALLDATETIME,
	@sEndDate SMALLDATETIME,
	@sReportCaption CHAR(30),
	@sDetailedCharges CHAR(1), --T: TRUE if detailed charges are shown per line jp 2.9.0
	@sShowContractRange CHAR(1), --T: TRUE if contract start/end dates must be shown jp 2.9.0
	@sShowSavingsPercentTotal CHAR(1), --T: TRUE if Savings Percent total must be shown in the last page
	@sUseGlmRate CHAR(1), --T: TRUE if Glm Rate must be used instead of Current Rate
	@sGlmAsVendor CHAR(1),  --T: TRUE if vendors must be shown as GLM DFW Inc
	@sReportTemplate CHAR(50),
	@nError INT OUTPUT
AS
--CHANGES
--08.30.12	Added invoice total per location
--04.01.11	Savings do not show when savings are too high
--06.24.10	CR-105 - Changes due to Glm Rate auditing
--04.03.10 	Added option to compute with Glm Rate instead of Current Rate
--08/03/07      Added Savings Percent total
--10.19.06	Replaced RepData with RptCostCont table to void data report mapping
--		and facilitate transfers to web site application
--05.14.05	Do not show negative savings when customer.negative_savings_flag='NO'
--05.12.05 	Added bill_saving_flag for VZ FBR
--06.14.04 	Report Caption
DECLARE @sGroupName CHAR (20)
DECLARE @sPeriodStartDate CHAR(10)
DECLARE @sPeriodEndDate CHAR(10)
DECLARE @sStmt1 NVARCHAR(2000)
DECLARE @sStmt2 NVARCHAR(200)  

DECLARE @sTmpCustId CHAR(2)
DECLARE @nTmpStoreId INT
DECLARE @nTmpVendSeq INT
DECLARE @sTmpAccountNo CHAR(30)
DECLARE @sTmpInvoiceNo CHAR(30)
DECLARE @nTmpEqptSeq INT
DECLARE @nTmpServId INT
DECLARE @nTmpOldRate DECIMAL(7,2)
DECLARE @nTmpRate DECIMAL(7,2)
DECLARE @nTmpGlmRate DECIMAL(7,2)
--02.15.09 DECIMAL(7,2) -> DECIMAL(14,4)
DECLARE @nDetServUsage DECIMAL(14,4)
--11.11.08 DECIMAL(8,2)  -> DEC(14,4) 
DECLARE @nDetUnits DECIMAL (14,4)   
DECLARE @sDetComments CHAR(30)
--07.28.03  @nDetOldRate, @nDetRate  DECIMAL (5,2) -> DECIMAL (7,2)
DECLARE @nDetOldRate DECIMAL(7,2)
DECLARE @nDetRate DECIMAL(7,2)
DECLARE @nDetGlmRate DECIMAL(7,2)
DECLARE @sDetServRateContract CHAR(1)
DECLARE @sDetServCredit CHAR(1)
DECLARE @sDetBillSavingFlag CHAR(3)   --05.12.05
DECLARE @nCountServUsage DECIMAL(10,4)  --02.15.09 decimal(8,2) -> DECIMAL(10,4)
DECLARE @nCountServUsage2 DECIMAL(10,4) --04.27.08 decimal(8,2) -> DECIMAL(10,4)
DECLARE @nCountServUsage3 DECIMAL(10,4) --04.27.08 decimal(8,2) -> DECIMAL(10,4)
DECLARE @sCountUnits CHAR(100)
DECLARE @sCountComments CHAR(80)
--11.11.08 DEC(8,2) -> DEC(14,4)
DECLARE @nTotalUnits DECIMAL(14,4)     
--07.28.03 @nTotalServ DECIMAL(5,2)  -> DECIMAL (7,2)
DECLARE @nTotalServ DECIMAL (7,2)   
DECLARE @nTotalGlmrateServ DECIMAL (7,2)   --CR-105

DECLARE @nSavings DECIMAL (8,2)    --jp.20110401    (6,2)
	
DECLARE @nCurrGlmRateSavings DECIMAL (6,2) --CR-105
DECLARE @nTotalCurrentGlmrateSavings DECIMAL(12,2)  --CR-105
DECLARE @nNonBillSavings DECIMAL (6,2)		
DECLARE @nCountServices INT
DECLARE @sUnitType CHAR(3)
DECLARE @nUnitTypeTotal DECIMAL(14,4) --DECIMAL(7,2) to (14,4)
--12.22.03 Changed @nTotalCharges, Savings and Taxes 
--from (7,2) -> (12,2)
DECLARE @nTotalCharges DECIMAL(12,2)
DECLARE @nTotalGlmCharges DECIMAL(12,2)  --CR-105
DECLARE @nTotalSavings DECIMAL(12,2)
DECLARE @nTotalStore DECIMAL(12,2)
--06.18.05 NonBillSavings
DECLARE @nTotalNonBillSavings DECIMAL(12,2)
DECLARE @nTotalTaxes DECIMAL(12,2)
DECLARE @nTotalServCurrency DECIMAL(7,2)
DECLARE @sEqCustId CHAR(2)
DECLARE @nEqStoreId INT
DECLARE @nEqVendSeq INT
DECLARE @sEqAccountNo CHAR(30)
DECLARE @sEqInvoiceNo CHAR(30)
DECLARE @nEqEqptSeq INT
DECLARE @nEqServId INT
DECLARE @sEqEqptMask CHAR(30)
DECLARE @sEqFrequencyMask CHAR(60)
DECLARE @sEqContentDesc CHAR(60)
DECLARE @sEqEqptTemp CHAR(1)
DECLARE @nPrevEqptSeq INT
DECLARE @sPrevEqptMask CHAR(30)
DECLARE @sPrevFrequencyMask CHAR(60)
DECLARE @sPrevContentDesc CHAR(60)
DECLARE @sPrevEqptTemp CHAR(1)
DECLARE @sPrevCustId CHAR(2)
DECLARE @nPrevStoreId INT
DECLARE @nPrevVendSeq INT
DECLARE @sPrevAccountNo CHAR(30)
DECLARE @sPrevInvoiceNo CHAR(30)
--12.18.03
DECLARE @nDefaultServId INT
DECLARE @sDefaultFrequency CHAR(30)
DECLARE @nCount INT
DECLARE @sNegativeSavingsFlag CHAR(3)

DECLARE @sContractRange CHAR(50)
DECLARE @sOpeningDate CHAR(10)
DECLARE @sExpirationDate CHAR(10)
DECLARE @nFeeValue DECIMAL(10,2)
DECLARE @nFlatFeeValue DECIMAL(10,2)
DECLARE @nTotalStoreFlatFee DECIMAL(10,2)

--CR-103.begin
DECLARE @nFeeRowCount INT
DECLARE @nGlmSavings DECIMAL(7,2)
--CR-103.end
DECLARE @nTotalSavingsPercent DECIMAL(10,2)
DECLARE @sSavingsPercentLabel CHAR(30)

DECLARE @sStoreName VARCHAR(80)
DECLARE @GLM_VENDOR VARCHAR(50)
--DECLARE @sReportTemplate CHAR(50) --CR-105
DECLARE @SYS_CCR_GLMRATE_AUDIT CHAR(50) --CR-105
--Genera una linea por cada servicio en VinvoiceDet
--Paso 1.-Selecciona todos los detalles con servicios asociados a equipo
--    y no asociados a equipo
--Paso 2.-Luego se aplican los filtros para eliminar registros adicionales
--		State, Store Group, Period, 
--Paso 3.-Se calculan Units y Usage. Se cuentan las unidades y se calcula el subtotal
--   por servicio en cada factura. Se hacen negativos aquellos servicios que son
--   creditos.
--Paso 4.-Se calculan totales: Se cuentan el uso de cada servicio si el tipo
--   es No Currency, en caso contrario se suman los sutotales de ese servicio
--Paso 5.-Se guardan registros en repData
--1.- Servicios con Join a Equipos
print '1.-Loading...tmpInvoice '+convert(char(30),getdate(),13)

SET @GLM_VENDOR = 'GLM DFW, Inc'
SET @SYS_CCR_GLMRATE_AUDIT = 'SYS_CCR_GLMRATE_AUDIT'

 SELECT DISTINCT VInvoice.cust_id, Customer.cust_report_name, 
    Store.store_number, Store.store_id, Store.store_address, Store.store_city, 
    Store.state_id, Store.store_co_code, Store.store_name, 
    VBranch.vend_name, VBranch.vend_seq, 
    VInvoice.account_no,
    VInvoice.invoice_no, VInvoice.vinvoice_date, VInvoice.period_seq,
    VInvoiceDet.old_rate, VInvoiceDet.rate, VInvoiceDet.glm_rate, 
    VInvoiceDet.rate AS current_rate,
    VInvoiceDet.eqpt_seq, VInvoiceDet.serv_id, VInvoiceDet.unit_type, 
    StoreEqpt.eqpt_qty, StoreEqpt.eqpt_desc, 
    StoreEqpt.load_id,StoreEqpt.eqpt_temp,
    Content.content_desc, Service.serv_desc, 
    VContract.rate_status, 
    dbo.format_eqpt (StoreEqpt.eqpt_qty, StoreEqpt.eqpt_desc, StoreEqpt.load_id) AS eqpt_mask,
    CAST(dbo.format_freq2 (Frequency.freq_sched_flag,  
       Frequency.freq_times_flag, VContract.freq_times,
       ISNULL(VContract.freq_period,''), ISNULL(VContract.freq_day1,''),
       ISNULL(VContract.freq_day2,''), ISNULL(VContract.freq_day3,''), 
       ISNULL(VContract.freq_day4,''), ISNULL(VContract.freq_day5,''), 
       ISNULL(VContract.freq_day6,''), ISNULL(VContract.freq_day7,''))  AS CHAR(60))AS frequency_mask ,
    CAST(' ' AS CHAR(50)) AS contract_range,  --jp 2.9.0    
    --02.15.09 DECIMAL(5,2) -> DECIMAL(10,4)
    CAST(0.00 AS DECIMAL(10,4)) AS serv_usage, 
    CAST(' 'AS CHAR(100)) AS units, 
    CAST(' ' AS CHAR(80)) AS comment, 
    --11.11.08 DECIMAL(8,2) -> DECIMAL (14,4)
    CAST(0.00 AS DECIMAL(14,4)) AS total_units, 

    --07.28.03 total_serv DECIMAL(5,2) -> DECIMAL (7,2)
    CAST(0.00 AS DECIMAL(7,2)) AS total_serv, 
    --07.28.03 total_serv DECIMAL(6,2) -> DECIMAL (7,2)
    CAST(0.00 AS DECIMAL(7,2)) AS total_glmrate_serv, --CR-105
    CAST(0.00 AS DECIMAL(7,2)) AS savings,
    CAST(0.00 AS DECIMAL(7,2)) AS non_bill_savings,
    CAST(0.00 AS DECIMAL(7,2)) AS current_glmrate_savings, --CR-105
    CAST(0.00 AS DECIMAL(7,2)) AS glm_savings,  --CR-103
    CAST(' ' AS CHAR(10)) AS contract_opening_date, --CR-103
    CAST(' ' AS CHAR(10)) AS contract_expiration_date, --CR-103
    --12.22.03 total_savings changed from (7,2) -> (12,2)
    CAST(0.00 AS DECIMAL(12,2)) AS total_charges, 
     CAST(0.00 AS DECIMAL(12,2)) AS total_glmrate_charges, --CR-105
    CAST(0.00 AS DECIMAL(12,2)) AS total_savings, 
    CAST(0.00 AS DECIMAL(12,2)) AS total_nonbillsavings,
    CAST(0.00 AS DECIMAL(12,2)) AS total_current_glmrate_savings,  --CR-105
    CAST(0.00 AS DECIMAL(12,2)) AS total_savingsPercent,
    CAST(0.00 AS DECIMAL(12,2)) AS total_taxes,
    CAST(0.00 AS DECIMAL(12,2)) AS total_store_flat_fee, -- StoreFlatFee
    
    CAST(0.00 AS DECIMAL(12,2)) AS store_savings,
    CAST(0.00 AS DECIMAL(12,2)) AS store_total,
    CAST(0.00 AS DECIMAL(10,2)) AS store_fee,
    CAST(0.00 AS DECIMAL(12,2)) AS store_current_glmrate_savings,  --CR-105
    CAST(' ' AS CHAR(80)) AS account,
    CAST(' ' AS CHAR(80)) AS invoice,
    CAST(' ' AS CHAR(10)) AS report_start, CAST (' ' AS CHAR(10)) AS report_end,
    CAST(' ' AS CHAR(30)) AS label_savingsPercent,
    CAST(' ' AS CHAR(40)) AS account_mask,
					--DECIMAL(7,2) to DECIMAL(14,4)
    CAST(' ' AS CHAR(30)) AS serv_desc1, CAST(0.00 AS decimal(14,4)) AS serv_sum1,
    CAST(' ' AS CHAR(30)) AS serv_desc2, CAST(0.00 AS decimal(14,4)) AS serv_sum2,
    CAST(' ' AS CHAR(30)) AS serv_desc3, CAST(0.00 AS decimal(14,4)) AS serv_sum3,
    CAST(' ' AS CHAR(30)) AS serv_desc4, CAST(0.00 AS decimal(14,4)) AS serv_sum4,
    CAST(' ' AS CHAR(30)) AS serv_desc5, CAST(0.00 AS decimal(14,4)) AS serv_sum5,
    CAST(' ' AS CHAR(30)) AS serv_desc6, CAST(0.00 AS decimal(14,4)) AS serv_sum6,
    CAST(' ' AS CHAR(30)) AS serv_desc7, CAST(0.00 AS decimal(14,4)) AS serv_sum7,
    CAST(' ' AS CHAR(30)) AS serv_desc8, CAST(0.00 AS decimal(14,4)) AS serv_sum8,
    CAST(' ' AS CHAR(30)) AS serv_desc9, CAST(0.00 AS decimal(14,4)) AS serv_sum9,
    CAST(' ' AS CHAR(30)) AS serv_desc10, CAST(0.00 AS decimal(14,4)) AS serv_sum10,
    CAST(' ' AS CHAR(30)) AS serv_desc11, CAST(0.00 AS decimal(14,4)) AS serv_sum11,
    CAST(' ' AS CHAR(30)) AS serv_desc12, CAST(0.00 AS decimal(14,4)) AS serv_sum12,
    CAST(' ' AS CHAR(30)) AS serv_desc13, CAST(0.00 AS decimal(14,4)) AS serv_sum13,
    CAST(' ' AS CHAR(30)) AS serv_desc14, CAST(0.00 AS decimal(14,4)) AS serv_sum14,
					--DECIMAL(7,2) to DECIMAL(14,2)
    CAST(' ' AS CHAR(30)) AS serv_desc101, CAST(0.00 AS decimal(14,2)) AS serv_sum101,
    CAST(' ' AS CHAR(30)) AS serv_desc102, CAST(0.00 AS decimal(14,2)) AS serv_sum102,
    CAST(' ' AS CHAR(30)) AS serv_desc103, CAST(0.00 AS decimal(14,2)) AS serv_sum103,
    CAST(' ' AS CHAR(30)) AS serv_desc104, CAST(0.00 AS decimal(14,2)) AS serv_sum104,
    CAST(' ' AS CHAR(30)) AS serv_desc105, CAST(0.00 AS decimal(14,2)) AS serv_sum105,
    CAST(' ' AS CHAR(30)) AS serv_desc106, CAST(0.00 AS decimal(14,2)) AS serv_sum106,
    CAST(' ' AS CHAR(30)) AS serv_desc107, CAST(0.00 AS decimal(14,2)) AS serv_sum107
    INTO #tmpInvoice 
    FROM VInvoice,  Customer, Store, VBranch, 
	StoreEqpt, Content, Service, Frequency,
	VInvoiceDet, VContract 	   
    WHERE VInvoice.cust_id = Customer.cust_id 
    AND VInvoice.store_id = Store.store_id 
    AND VInvoice.cust_id = Store.cust_id 
    AND VInvoice.vend_seq = VBranch.vend_seq 
    AND StoreEqpt.content_id = Content.content_id 
    AND VInvoice.cust_id = StoreEqpt.cust_id 
    AND VInvoice.store_id = StoreEqpt.store_id
    AND VInvoiceDet.eqpt_seq = StoreEqpt.eqpt_seq 
    AND VInvoice.invoice_no = VInvoiceDet.invoice_no
    AND VInvoice.cust_id = VInvoiceDet.cust_id
    AND VInvoice.store_id = VInvoiceDet.store_id
    AND VInvoice.account_no = VInvoiceDet.account_no
    AND VInvoice.vend_seq = VInvoiceDet.vend_seq
    AND VInvoiceDet.cust_id = Vcontract.cust_id
    AND VInvoiceDet.store_id = Vcontract.store_id
    AND VInvoiceDet.vend_seq = Vcontract.vend_seq
    AND VInvoiceDet.eqpt_seq = Vcontract.eqpt_seq
    AND VInvoiceDet.serv_id = Vcontract.serv_id
    AND VContract.freq_id = Frequency.freq_id
    AND VInvoiceDet.serv_id = Service.serv_id
    --AND VInvoice.vinvoice_status = 'CRE'
    AND VInvoice.cust_id = @sCustId 
    AND Store.store_status = 'A'
UNION
--2.- Servicios sin Equipo (taxes, etc)
   SELECT DISTINCT VInvoice.cust_id,  Customer.cust_report_name, 
    Store.store_number, Store.store_id, Store.store_address, Store.store_city, 
    Store.state_id, Store.store_co_code, Store.store_name,
    VBranch.vend_name, VBranch.vend_seq, 
    VInvoice.account_no,
    VInvoice.invoice_no, VInvoice.vinvoice_date, VInvoice.period_seq,
    VInvoiceDet.old_rate, VInvoiceDet.rate, VInvoiceDet.glm_rate,
    VInvoiceDet.rate AS current_rate,
    VInvoiceDet.eqpt_seq, VInvoiceDet.serv_id, VInvoiceDet.unit_type, 
    CAST(0  AS INT) eqpt_qty, NULL as  eqpt_desc, 
    NULL load_id, NULL eqpt_temp,
    NULL content_desc, Service.serv_desc, 
    NULL rate_status, 
    dbo.format_eqpt (0, NULL, NULL) AS eqpt_mask,
    NULL  AS frequency_mask ,
    CAST(' ' AS CHAR(50)) AS contract_range,  --jp 2.9.0        
    --02.15.09 DECIMAL(5,2) -> DECIMAL(10,4)
    CAST(0.00 AS DECIMAL(10,4)) AS serv_usage, 
    CAST(' 'AS CHAR(100)) AS units, 
    CAST(' ' AS CHAR(80)) AS comment, 
    --11.11.08 DECIMAL(8,2) -> DECIMAL (14,4)
    CAST(0.00 AS DECIMAL(14,4)) AS total_units, 
    --07.28.03 total_serv DECIMAL(5,2) -> DECIMAL (7,2)
    CAST(0.00 AS DECIMAL(7,2)) AS total_serv, 
    --07.28.03 total_serv DECIMAL(6,2) -> DECIMAL (7,2)
    CAST(0.00 AS DECIMAL(7,2)) AS total_glmrate_serv, --CR-105
    CAST(0.00 AS DECIMAL(7,2)) AS savings,
    CAST(0.00 AS DECIMAL(7,2)) AS non_bill_savings,
    CAST(0.00 AS DECIMAL(7,2)) AS current_glmrate_savings, --CR-105
    CAST(0.00 AS DECIMAL(7,2)) AS glm_savings,  --CR-103
    CAST(' ' AS CHAR(10)) AS contract_opening_date, --CR-103
    CAST(' ' AS CHAR(10)) AS contract_expiration_date, --CR-103

    --12.22.03 total_savings changed from (7,2) -> (12,2)
    CAST(0.00 AS DECIMAL(12,2)) AS total_charges, 
    CAST(0.00 AS DECIMAL(12,2)) AS total_glmrate_charges, --CR-105
    CAST(0.00 AS DECIMAL(12,2)) AS total_savings, 
    CAST(0.00 AS DECIMAL(12,2)) AS total_nonbillsavings,
    CAST(0.00 AS DECIMAL(12,2)) AS total_current_glmrate_savings,  --CR-105
    CAST(0.00 AS DECIMAL(12,2)) AS total_savingsPercent,
    CAST(0.00 AS DECIMAL(12,2)) AS total_taxes,
    CAST(0.00 AS DECIMAL(12,2)) AS total_store_flat_fee, -- StoreFlatFee
    
    CAST(0.00 AS DECIMAL(12,2)) AS store_savings,
    CAST(0.00 AS DECIMAL(12,2)) AS store_total,
     CAST(0.00 AS DECIMAL(10,2)) AS store_fee, -- StoreFlatFee
    CAST(0.00 AS DECIMAL(12,2)) AS store_current_glmrate_savings,  --CR-105
    CAST(' ' AS CHAR(80)) AS account,
    CAST(' ' AS CHAR(80)) AS invoice,
    CAST(' ' AS CHAR(10)) AS report_start, CAST (' ' AS CHAR(10)) AS report_end,
    CAST(' ' AS CHAR(30)) AS label_savingsPercent,
    CAST(' ' AS CHAR(40)) AS account_mask,
					--DECIMAL(7,2) to DECIMAL(14,4)
    CAST(' ' AS CHAR(30)) AS serv_desc1, CAST(0.00 AS decimal(14,4)) AS serv_sum1,
    CAST(' ' AS CHAR(30)) AS serv_desc2, CAST(0.00 AS decimal(14,4)) AS serv_sum2,
    CAST(' ' AS CHAR(30)) AS serv_desc3, CAST(0.00 AS decimal(14,4)) AS serv_sum3,
    CAST(' ' AS CHAR(30)) AS serv_desc4, CAST(0.00 AS decimal(14,4)) AS serv_sum4,
    CAST(' ' AS CHAR(30)) AS serv_desc5, CAST(0.00 AS decimal(14,4)) AS serv_sum5,
    CAST(' ' AS CHAR(30)) AS serv_desc6, CAST(0.00 AS decimal(14,4)) AS serv_sum6,
    CAST(' ' AS CHAR(30)) AS serv_desc7, CAST(0.00 AS decimal(14,4)) AS serv_sum7,
    CAST(' ' AS CHAR(30)) AS serv_desc8, CAST(0.00 AS decimal(14,4)) AS serv_sum8,
    CAST(' ' AS CHAR(30)) AS serv_desc9, CAST(0.00 AS decimal(14,4)) AS serv_sum9,
    CAST(' ' AS CHAR(30)) AS serv_desc10, CAST(0.00 AS decimal(14,4)) AS serv_sum10,
    CAST(' ' AS CHAR(30)) AS serv_desc11, CAST(0.00 AS decimal(14,4)) AS serv_sum11,
    CAST(' ' AS CHAR(30)) AS serv_desc12, CAST(0.00 AS decimal(14,4)) AS serv_sum12,
    CAST(' ' AS CHAR(30)) AS serv_desc13, CAST(0.00 AS decimal(14,4)) AS serv_sum13,
    CAST(' ' AS CHAR(30)) AS serv_desc14, CAST(0.00 AS decimal(14,4)) AS serv_sum14,
				--DECIMAL(7,2) to DECIMAL(14,2)
    CAST(' ' AS CHAR(30)) AS serv_desc101, CAST(0.00 AS decimal(14,2)) AS serv_sum101,
    CAST(' ' AS CHAR(30)) AS serv_desc102, CAST(0.00 AS decimal(14,2)) AS serv_sum102,
    CAST(' ' AS CHAR(30)) AS serv_desc103, CAST(0.00 AS decimal(14,2)) AS serv_sum103,
    CAST(' ' AS CHAR(30)) AS serv_desc104, CAST(0.00 AS decimal(14,2)) AS serv_sum104,
    CAST(' ' AS CHAR(30)) AS serv_desc105, CAST(0.00 AS decimal(14,2)) AS serv_sum105,
    CAST(' ' AS CHAR(30)) AS serv_desc106, CAST(0.00 AS decimal(14,2)) AS serv_sum106,
    CAST(' ' AS CHAR(30)) AS serv_desc107, CAST(0.00 AS decimal(14,2)) AS serv_sum107
    FROM VInvoice, VInvoiceDet, Customer, Store, VBranch, 
	Service
    WHERE VInvoice.cust_id = Customer.cust_id 
    AND VInvoice.store_id = Store.store_id 
    AND VInvoice.cust_id = Store.cust_id 
    AND VInvoice.vend_seq = VBranch.vend_seq 
    AND VInvoice.invoice_no = VInvoiceDet.invoice_no
    AND VInvoice.cust_id = VInvoiceDet.cust_id
    AND VInvoice.store_id = VInvoiceDet.store_id
    AND VInvoice.account_no = VInvoiceDet.account_no
    AND VInvoice.vend_seq = VInvoiceDet.vend_seq
    AND VInvoiceDet.serv_id = Service.serv_id
    --AND VInvoice.vinvoice_status = 'CRE'
    AND VInvoice.cust_id = @sCustId
    and VInvoicedet.eqpt_seq=0
    AND Store.store_status = 'A'
ORDER BY VInvoice.cust_id, Store.store_id, VBranch.vend_seq, 
	VInvoice.account_no, VInvoice.invoice_no, VInvoiceDet.eqpt_seq desc, 
	VInvoiceDet.serv_id

print '2.Loaded. Starting Filters :'+convert(char(30),getdate(),13)

--Paso 2: FILTROS
--State
IF @sStateId <> 'All'
BEGIN  
  --SET @sStmt2 = 'AND Store.state_id = ''' + RTRIM (@sStateId)+''' '
  --SET @sStmt1 = RTRIM(@sStmt1) + ' '+ RTRIM(@sStmt2)
  DELETE FROM #tmpInvoice 
    WHERE state_id <> @sStateId
END
--GROUP
SET @sGroupName = (SELECT group_name FROM groups WHERE group_seq = @nGroupSeq)
--1.8.3 Siempre verificar Store que pertenecen al grupo inclusive grupo All
DELETE FROM #tmpInvoice
WHERE store_id NOT IN (SELECT store_id FROM GroupStore
   WHERE cust_id = @sCustId
   AND group_seq = @nGroupSeq)
/*
IF RTRIM(@sGroupName) <> 'All'
BEGIN
   DELETE FROM #tmpInvoice
   WHERE store_id NOT IN (SELECT store_id FROM GroupStore
	WHERE cust_id = @sCustId
	AND group_seq = @nGroupSeq)
END
*/
--Period
IF @sPeriodSeq = 'T' -- TRUE
BEGIN 	
	/*
	SET @sStmt2 = ' AND VInvoice.period_seq ='+ STR(@nPeriodSeq)+' '
	SET @sStmt1 = RTRIM(@sStmt1) + ' '+CHAR(13)+ RTRIM(@sStmt2)
	*/
   DELETE FROM #tmpInvoice 
     WHERE period_seq <> @nPeriodSeq
   --Obtengo fechas del periodo
   SELECT @sPeriodStartDate = CONVERT(CHAR(10),period_start_date ,101), 
	  @sPeriodEndDate = CONVERT (CHAR(10),period_end_date,101)
   FROM period
   WHERE period_seq = @nPeriodSeq
   UPDATE #tmpInvoice
     SET report_start = @sPeriodStartDate,
	 report_end = @sPeriodEndDate
END
ELSE
BEGIN
   	/*
   	SET @sStmt2 = ' AND VInvoice.vinvoice_date '+
	      ' BETWEEN '''+RTRIM(CAST(@sStartDate AS CHAR(19))) +''' '+
	      ' AND '''+ RTRIM(CAST(@sEndDate AS CHAR(19))) +''' '
	SET @sStmt1 = RTRIM(@sStmt1) + ' '+CHAR(13)+ RTRIM(@sStmt2)
   	*/ --120
   DELETE FROM #tmpInvoice
     WHERE vinvoice_date < @sStartDate
     OR vinvoice_date >@sEndDate
   UPDATE #tmpInvoice
   SET report_start = CONVERT(CHAR(10),@sStartDate, 101),
       report_end = CONVERT(CHAR(10), @sEndDate, 101)
END
-- FIN DE FILTROS



print '3.End Filters. Counting usage, units. :'+convert(char(30),getdate(),13)

--Customer Settings for saving calcs

SELECT @sNegativeSavingsFlag = ISNULL(negative_savings_flag,'YES') 
FROM customer
WHERE cust_id = @sCustId


--CR-103.begin - Getting FeeValue for Savings Percent
EXEC usp_fee_savingspercent @sCustId, 
			    @nFeeValue = @nFeeValue OUTPUT, 
			    @nFeeRowCount = @nFeeRowCount OUTPUT
--CR-103.end

--Paso 3:
--Units, Usage, Comments, Old Rate, New Rate, Total Serv, Savings per Serv
BEGIN
   DECLARE c_invoice CURSOR FOR
   SELECT cust_id, store_id, vend_seq, account_no, invoice_no, eqpt_seq, serv_id,
	old_rate, rate, glm_rate
   FROM #tmpInvoice
   FOR UPDATE

   OPEN c_invoice
   FETCH NEXT FROM c_invoice 
   INTO @sTmpCustId, @nTmpStoreId, @nTmpVendSeq, @sTmpAccountNo, 
	@sTmpInvoiceNo, @nTmpEqptSeq, @nTmpServId,
	@nTmpOldRate, @nTmpRate, @nTmpGlmRate
   WHILE @@FETCH_STATUS = 0
   BEGIN
      SET @nCountServUsage = 0
      SET @nCountServUsage2 = 0
      SET @nCountServUsage3 = 0
      SET @sCountUnits = ''
      SET @sCountComments = ''  --150
      SET @nTotalUnits =0
      SET @nSavings =0
      SET @nNonBillSavings =0

print 'Store number' + cast(@nTmpStoreId as char(10))
print 'Vendor Seq:'+ cast(@nTmpVendSeq as char(10))
print 'Account:'+ @sTmpAccountNo
print 'Inv:'+@sTmpInvoiceNo +' Serv:'+cast(@nTmpServId as char(10))+
' Eqpt:'+cast (@nTmpEqptSeq as char(10))
print 'Old Rate:'+ cast(@nTmpOldRate as char(10))
print 'Rate:'+ cast(@nTmpRate as char(10))
      DECLARE c_invoice_det CURSOR FOR
	SELECT ISNULL(serv_usage,0.00), ISNULL(units,0.00), 
		old_rate, rate, glm_rate, ISNULL(comment,''), service.serv_rate_contract,
		service.serv_credit, VInvoiceDet.bill_saving_flag
 	FROM VInvoiceDet , Service
	WHERE cust_id = @sTmpCustId
	AND store_id = @nTmpStoreId
	AND vend_seq = @nTmpVendSeq
	AND account_no = @sTmpAccountNo
	AND invoice_no = @sTmpInvoiceno
	AND eqpt_seq = @nTmpEqptSeq
	AND VInvoiceDet.serv_id = @nTmpServId
	AND old_rate = @nTmpOldRate
	AND rate = @nTmpRate
	AND glm_rate = @nTmpGlmRate
        AND VInvoiceDet.serv_id = Service.serv_id
	
--print CAST(@nTmpRate as char(1))

      OPEN c_invoice_det
      FETCH NEXT FROM c_invoice_det 
      INTO @nDetServUsage, @nDetUnits, @nDetOldRate, @nDetRate, @nDetGlmRate, @sDetComments, 
	   @sDetServRateContract, @sDetServCredit, @sDetBillSavingFlag
      IF @@ERROR <>0
      BEGIN
	PRINT 'Ocurrio un error'
	SET @nError =99
	RETURN @nError
      END

      WHILE @@FETCH_STATUS = 0
      BEGIN	

      	   SET @nCountServUsage = @nCountServUsage  + @nDetServUsage 

           IF  @sDetBillSavingFlag = 'YES'
	      	   SET @nCountServUsage2 = @nCountServUsage2  + @nDetServUsage 
	   ELSE
		SET @nCountServUsage3 = @nCountServUsage3 + @nDetServUsage

	   SET @nTotalUnits = @nTotalUnits + @nDetUnits
	   --11.11.08  CHAR(9) -> CHAR(15)
	   SET @sCountUnits = LTRIM(RTRIM(@sCountUnits)) + ' ' + CAST(@nDetUnits AS VARCHAR(15))  
	   SET @sCountComments = RTRIM(@sCountComments) + ' '+ RTRIM(@sDetComments)

	   FETCH NEXT FROM c_invoice_det 
	   INTO @nDetServUsage, @nDetUnits, @nDetOldRate, @nDetRate, @nDetGlmRate, @sDetComments,
		   @sDetServRateContract, @sDetServCredit, @sDetBillSavingFlag
      END --end while
print 'CountUnits:'+@sCountUnits+ ' @nDetRate:'+cast(@nDetRate as char(10)) + '@nDetGlmRate:'+cast(@nDetGlmRate as char(10))

      --GlmRate.begin
      --Use Glm Rate instead of Current Rate for all computations in this loop
      IF @sUseGlmRate = 'T' 
      BEGIN
         SET @nDetRate = @nDetGlmRate
      END
      --GlmRate.end

      SET @nTotalServ = @nCountServUsage * @nDetRate

      --CR-105.begin
      SET @nCurrGlmRateSavings = 0
      SET @nTotalGlmrateServ = @nCountServUsage * @nDetGlmRate
      --CR-105.end

      --CR-103.begin
      SET @nGlmSavings = 0
      SET @sOpeningDate = ''
      SET @sExpirationDate = ''
      --CR-103.end

      --05.06.03 Convierto a negativo los servicios que son Credito
      IF @sDetServCredit ='T'
	SET @nTotalServ = @nTotalServ* (-1)

      IF @sDetServRateContract ='T' 
      BEGIN

	--CR-105.begin
        IF @sReportTemplate = @SYS_CCR_GLMRATE_AUDIT
        BEGIN
	   SET @nSavings = @nCountServUsage2 * (@nDetGlmRate - @nDetRate)
           SET @nCurrGlmRateSavings = @nCountServUsage2 * (@nDetOldRate - @nDetGlmRate)
        END
	ELSE
        BEGIN
      	   SET @nSavings = @nCountServUsage2 * (@nDetOldRate - @nDetRate)   --05.12.05
	END
	--CR-105.end

	IF @nSavings < 0 AND @sNegativeSavingsFlag = 'NO' 
	   SET @nSavings = 0

	--CR-103.begin
	IF @nFeeRowCount > 0 AND @nFeeValue >  0 AND @nSavings > 0	
	BEGIN
	   SET @nGlmSavings = @nSavings * @nFeeValue /100
	END

   	SELECT 	@sOpeningDate = CONVERT(CHAR(10),opening_date ,101),
		@sExpirationDate = CONVERT(CHAR(10),expiration_date ,101)
	FROM VContract
		WHERE cust_id = @sTmpCustId
		AND vend_seq = @nTmpVendSeq
		AND store_id = @nTmpStoreId
		AND eqpt_seq = @nTmpEqptSeq
		AND serv_id = @nTmpServId
	--CR-103.end

      	--Sum non-bill-savings
	SET @nNonBillSavings = @nCountServUsage3 * (@nDetOldRate - @nDetRate)
      END
      ELSE
	SET @nSavings = 0


print 'CountServUsage:'+ cast(@nCountServUsage as char(10))+ 'Units:'+ cast(@nTotalUnits as char(16))+' savings:'+cast (@nSavings as char(10))
print 'CountServUsage2:'+ cast(@nCountServUsage2 as char(10))
print 'Total Serv:'+ cast (@nTotalServ as char(10))+ 'CountUnits:'+@sCountUnits
      UPDATE #tmpInvoice
     	SET serv_usage = @nCountServUsage, 
	    units = @sCountUnits, 
--	    old_rate = @nDetOldRate, 
--	    rate = @nDetRate, 
	    comment = @sCountComments,
	    total_units = @nTotalUnits,
	    total_serv = @nTotalServ,	
	    savings = @nSavings,
	    non_bill_savings = @nNonBillSavings,
	    --CR-103.begin
	    glm_savings = @nGlmSavings,
	    contract_opening_date = @sOpeningDate,
	    contract_expiration_date = @sExpirationDate,
	    --CR-103.end
	    --CR-105.begin
	    current_glmrate_savings = @nCurrGlmRateSavings,
	    total_glmrate_serv = @nTotalGlmrateServ
	    --CR-105.end
	WHERE CURRENT OF c_invoice
      CLOSE c_invoice_det
      DEALLOCATE c_invoice_det
      FETCH NEXT FROM c_invoice 
      INTO @sTmpCustId, @nTmpStoreId, @nTmpVendSeq, @sTmpAccountNo, 
	   @sTmpInvoiceNo, @nTmpEqptSeq, @nTmpServId,
	   @nTmpOldRate, @nTmpRate, @nTmpGlmRate
   END
   CLOSE c_invoice
   DEALLOCATE c_invoice
		
END
--Debug
print '4.Services:'+convert(char(30),getdate(),13)
--Paso 4
--Totales: Suma de servicios, Taxes, Charges,Savings
--Hasta 7 tipos de unidades de servicio que representan dinero $$ en reporte
IF @sDetailedCharges = 'T'    	--jp 2.9.0
BEGIN 				--jp 2.9.0
   SELECT @nCountServices= COUNT( DISTINCT unit_type) 
   FROM #tmpInvoice a, ServUnit b
   WHERE  a.unit_type = b.serv_measure_unit
   AND b.serv_currency = 'T'
   IF @nCountServices > 7
   BEGIN
      --Numero de servicios en reporte excede el numero de campos en plantilla de rpt.
      SET @nError = -1
      RETURN @nError
   END
   --select distinct unit_type from #tmpInvoice
   DECLARE c_services CURSOR FOR
   --   SELECT unit_type, ISNULL(SUM(total_units),0.00)
      SELECT unit_type, ISNULL(SUM(total_serv),0.00)
      FROM #tmpInvoice a, ServUnit b
      WHERE  a.unit_type = b.serv_measure_unit
      AND b.serv_currency = 'T'
      GROUP BY unit_type
   SET @nCountServices = 100   --@@@@@@@@@@@
   SET @nTotalServCurrency=0
   OPEN c_services
   FETCH NEXT FROM c_services INTO @sUnitType, @nUnitTypeTotal
   WHILE @@FETCH_STATUS = 0
   BEGIN
       SET @nCountServices = @nCountServices + 1
       SET @nTotalServCurrency = @nTotalServCurrency + @nUnitTypeTotal
	--UPDATE #tmpInvoice 
	--SET serv_desc1 = @sUnitType,
	--    serv_sum1 = @nUnitTypeTotal

   --print CAST(@nCountServices AS NVARCHAR(3))
      SET @sStmt1= 'UPDATE #tmpInvoice  '+
	   	   'set serv_desc' +
		   RTRIM(CAST(@nCountServices AS NVARCHAR(3)))  +' = '''+@sUnitType+''',' +
		   ' serv_sum'+
		   RTRIM(CAST(@nCountServices AS NVARCHAR(3)))  +' = '+
		   CAST(@nUnitTypeTotal AS NVARCHAR(10))
      PRINT @sStmt1
      exec sp_executesql @sStmt1
      FETCH NEXT FROM c_services INTO @sUnitType, @nUnitTypeTotal
   END
   CLOSE c_services
   DEALLOCATE c_services
END --jp 2.9.0


--Unit Type con Currency false
SET @nCountServices = 0
SELECT @nCountServices= COUNT( DISTINCT unit_type) 
FROM #tmpInvoice a, ServUnit b
WHERE  a.unit_type = b.serv_measure_unit
AND b.serv_currency = 'F'
IF @nCountServices > 14
BEGIN
   --Numero de servicios en reporte excede el numero de campos en plantilla de rpt.
   SET @nError = -2
   RETURN @nError
END
DECLARE c_services2 CURSOR FOR
   SELECT unit_type, ISNULL(SUM(total_units),0.0000)
   FROM #tmpInvoice a, ServUnit b
   WHERE  a.unit_type = b.serv_measure_unit
   AND b.serv_currency = 'F'
   GROUP BY unit_type
SET @nCountServices = 0
OPEN c_services2

FETCH NEXT FROM c_services2 INTO @sUnitType, @nUnitTypeTotal
WHILE @@FETCH_STATUS = 0
BEGIN

print 'jpdebug:nUnitTypeTotal:'+CAST(@nUnitTypeTotal AS NVARCHAR(15))

   SET @nCountServices = @nCountServices + 1
   SET @sStmt1= 'UPDATE #tmpInvoice  '+
		'set serv_desc' +
		RTRIM(CAST(@nCountServices AS NVARCHAR(2)))  +' = '''+@sUnitType+''','+
		' serv_sum'+
		RTRIM(CAST(@nCountServices AS NVARCHAR(2)))  +' = '+
		CAST(@nUnitTypeTotal AS NVARCHAR(15))  --nvarchar(10) to (15)
  --PRINT @sStmt1
   exec sp_executesql @sStmt1
   FETCH NEXT FROM c_services2 INTO @sUnitType, @nUnitTypeTotal
END
CLOSE c_services2
DEALLOCATE c_services2

print '5.Total charges:'+convert(char(30),getdate(),13)
--Total Charges
print 'Service Currency='+str(@ntotalservcurrency)
SELECT @nTotalCharges= SUM(total_serv),
       @nTotalSavings = SUM (savings),
       @nTotalNonBillSavings = SUM(non_bill_savings),
       @nTotalCurrentGlmrateSavings = SUM(current_glmrate_savings), --CR-105
       @nTotalGlmCharges = SUM(total_glmrate_serv)
FROM #tmpInvoice

--Total Savings Percent 08.03.07
IF @sShowSavingsPercentTotal='T'
BEGIN

   SET @sSavingsPercentLabel = 'Savings Percent'

   --CR-103.begin
   /* 
   SELECT @nFeeValue = a.fee_value 
   FROM fee a, feeType b
   WHERE a.cust_id = @sCustId
   AND a.fee_type_id = b.fee_type_id
   AND RTRIM(b.fee_desc) = 'Savings Percent'
   */
   
   --IF @@ROWCOUNT=0
   IF @nFeeRowCount=0
   --CR-103.end
   BEGIN
      --Customer does not have Savings Percent fee set up
      SET @nTotalSavingsPercent = 0
   END
   ELSE
   BEGIN
      IF @nFeeValue > 0
      BEGIN
	-----ANCHOR
	--CR-105.begin
        IF @sReportTemplate = @SYS_CCR_GLMRATE_AUDIT
        BEGIN
           SET @sSavingsPercentLabel = RTRIM(STR(@nFeeValue)) +'% Current Savings'
	   SET @nTotalSavingsPercent = @nTotalCurrentGlmrateSavings * @nFeeValue /100
	END
	ELSE
	BEGIN
           SET @sSavingsPercentLabel = RTRIM(STR(@nFeeValue)) +'% Savings Percent'
	   SET @nTotalSavingsPercent = @nTotalSavings * @nFeeValue /100
	END
      END
      ELSE
        SET @nTotalSavingsPercent = 0
   END

   UPDATE #tmpInvoice SET 
	total_savingsPercent = @nTotalSavingsPercent,
	label_savingsPercent = @sSavingsPercentLabel
END

ELSE

BEGIN 
   UPDATE #tmpInvoice SET 
	total_savingsPercent = NULL,
	label_savingsPercent = NULL
END
--jp.3.0.15.begin
--Update account_mask  in #tmpInvoice
UPDATE #tmpInvoice 
SET account_mask = (
   SELECT account_mask FROM VAccount a
   WHERE a.cust_id = #tmpInvoice.cust_id
   AND a.store_id = #tmpInvoice.store_id
   AND a.account_no = #tmpInvoice.account_no
   AND a.vend_seq = #tmpInvoice.vend_seq)
--jp.3.0.15.end

--jp.GlmVendor.begin
IF @sGlmAsVendor = 'T'
BEGIN
   UPDATE #tmpInvoice 
   SET vend_name = @GLM_VENDOR
END
--jp.GlmVendor.end


--jp 11.20.06  2.9.0 Begin 
IF @sDetailedCharges = 'T'
BEGIN
   UPDATE #tmpInvoice
   SET total_charges = @nTotalCharges-@nTotalServCurrency, --05.06.03
       total_savings = @nTotalSavings,
       total_nonbillsavings = @nTotalNonBillSavings,
       total_current_glmrate_savings = @nTotalCurrentGlmrateSavings, --CR-105
       total_glmrate_charges = @nTotalGlmCharges,  --CR-105
       account= RTRIM(CAST(RTRIM(vend_name)  AS CHAR(30)))+ ' / '+
	        RTRIM(CAST('Acc#'+RTRIM(ISNULL(account_mask,'')) AS CHAR(30)) ) ,
       invoice =RTRIM(CAST('Invoice #'+invoice_no AS CHAR(60)))+' '+
	   'Date:' + CONVERT(CHAR(10),vinvoice_date,101)
END 
ELSE
BEGIN
   --jp.3.0.15.begin
   UPDATE #tmpInvoice
   SET total_charges = @nTotalCharges,
       total_savings = @nTotalSavings,
       total_nonbillsavings = @nTotalNonBillSavings,
       total_current_glmrate_savings = @nTotalCurrentGlmrateSavings,    --CR-105
       total_glmrate_charges = @nTotalGlmCharges,  --CR-105
       account= RTRIM(CAST(RTRIM(vend_name)  AS CHAR(30)))+ ' / '+
	        RTRIM(CAST('Acc#'+RTRIM(ISNULL(account_mask,'')) AS CHAR(30)) ) ,
       invoice =RTRIM(CAST('Invoice #'+invoice_no AS CHAR(60)))+' '+
	   'Date:' + CONVERT(CHAR(10),vinvoice_date,101)

END
--end jp 2.9.0

--select * from #tmpInvoice
--Servicios no asociados a equipos se asocian al ultimo equipo de la factura
SET @nPrevEqptSeq = -1
DECLARE c_eqpt CURSOR FOR
   SELECT cust_id, store_id, vend_seq, 
	  account_no, invoice_no, eqpt_seq, serv_id, eqpt_mask,
	  frequency_mask, ISNULL(content_desc,''), eqpt_temp
   FROM #tmpInvoice
   WHERE eqpt_seq>0
   ORDER BY cust_id, store_id, vend_seq, account_no, invoice_no, eqpt_seq --eqpt_mask 
OPEN c_eqpt
FETCH c_eqpt 
INTO @sEqCustId, @nEqStoreId, @nEqVendSeq, @sEqAccountNo, @sEqInvoiceNo,
     @nEqEqptSeq, @nEqServId, @sEqEqptMask,
     @sEqFrequencyMask, @sEqContentDesc, @sEqEqptTemp
	
WHILE @@FETCH_STATUS = 0
BEGIN
/*
   IF @nEqEqptSeq = 0 
   AND @nPrevEqptSeq > 0
   BEGIN
        UPDATE #tmpInvoice 
        SET eqpt_seq = @nPrevEqptSeq,
	    eqpt_mask = @sPrevEqptMask,
	    eqpt_temp = @sPrevEqptTemp,
	    frequency_mask= RTRIM(CAST(@sPrevFrequencyMask AS CHAR(30)))+ ' - '+CAST(@sPrevContentDesc AS CHAR(30)) 
	WHERE CURRENT OF c_eqpt
   END
   ELSE
   BEGIN
	UPDATE #tmpInvoice 
        SET frequency_mask=RTRIM(CAST(@sEqFrequencyMask AS CHAR(30)))+ ' - '+CAST(@sEqContentDesc AS CHAR(30)) 
	WHERE CURRENT OF c_eqpt
   END
*/
UPDATE #tmpInvoice 
SET frequency_mask=RTRIM(CAST(@sEqFrequencyMask AS CHAR(30)))+ ' - '+CAST(@sEqContentDesc AS CHAR(29)) 
WHERE cust_id = @sEqCustId
AND store_id = @nEqStoreId
AND vend_seq = @nEqVendSeq
AND account_no = @sEqAccountNo
AND invoice_no = @sEqInvoiceNo
AND eqpt_seq = @nEqEqptSeq
AND serv_id =@nEqServId
   --Asigno los servicios sin equipo (ejem Taxes and Fees) al ultimo equipo de factura
   IF @sEqCustId <> @sPrevCustId
   OR @nEqStoreId <> @nPrevStoreId
   OR @nEqVendSeq <> @nPrevVendSeq
   OR @sEqAccountNo <> @sPrevAccountNo
   OR @sEqInvoiceNo <> @sPrevInvoiceNo   --ojo QUE CAMBIO INVOICE
   BEGIN
	UPDATE #tmpInvoice
	    SET eqpt_seq = @nPrevEqptSeq,
		eqpt_mask = @sPrevEqptMask,
		eqpt_temp = @sPrevEqptTemp,
		frequency_mask= RTRIM(CAST(@sPrevFrequencyMask AS CHAR(30)))+ ' - '+CAST(@sPrevContentDesc AS CHAR(30)) 
	   WHERE eqpt_seq=0
	   AND cust_id =@sPrevCustId
	   AND store_id = @nPrevStoreId
	   AND vend_seq = @nPrevVendSeq
	   AND account_no = @sPrevAccountNo
	   AND invoice_no = @sPrevInvoiceNo
   END
   SET @nPrevEqptSeq = @nEqEqptSeq
   SET @sPrevEqptMask = @sEqEqptMask
   SET @sPrevFrequencyMask = @sEqFrequencyMask
   SET @sPrevContentDesc = @sEqContentDesc
   SET @sPrevEqptTemp = @sEqEqptTemp
   SET @sPrevCustid = @sEqCustId
   SET @nPrevStoreId = @nEqStoreId
   SET @nPrevVendSeq = @nEqVendSeq
   SET @sPrevAccountNo = @sEqAccountNo
   SET @sPrevInvoiceNo = @sEqInvoiceNo
   FETCH c_eqpt 
   INTO @sEqCustId, @nEqStoreId, @nEqVendSeq, @sEqAccountNo, @sEqInvoiceNo,
     @nEqEqptSeq, @nEqServId, @sEqEqptMask,
     @sEqFrequencyMask, @sEqContentDesc, @sEqEqptTemp
END
CLOSE c_eqpt
DEALLOCATE c_eqpt
--Actualizo la ultima factura
UPDATE #tmpInvoice
    SET eqpt_seq = @nPrevEqptSeq,
	eqpt_mask = @sPrevEqptMask,
	eqpt_temp = @sPrevEqptTemp,
	frequency_mask= RTRIM(CAST(@sPrevFrequencyMask AS CHAR(30)))+ ' - '+CAST(@sPrevContentDesc AS CHAR(30)) 
   WHERE eqpt_seq=0
   AND cust_id =@sPrevCustId
   AND store_id = @nPrevStoreId
   AND vend_seq = @nPrevVendSeq
   AND account_no = @sPrevAccountNo
   AND invoice_no = @sPrevInvoiceNo
--2016.11.13 Store Flat Fee
EXEC usp_fee_value @sCustId, 'Store Flat Fee',
			    @nFeeValue = @nFlatFeeValue OUTPUT, 
			    @nFeeRowCount = @nFeeRowCount OUTPUT
			    
--09.02.12 Added STORE TOTAL
--08.08.07 STORE SAVINGS
SET @nTotalStoreFlatFee=0

DECLARE c_store_savings CURSOR FOR
   SELECT cust_id, store_id, SUM(savings),
	sum(current_glmrate_savings), sum(total_serv) --CR-105
   FROM #tmpInvoice
   WHERE savings IS NOT NULL
   GROUP BY cust_id, store_id

OPEN c_store_savings
FETCH c_store_savings 
      INTO @sTmpCustId, @nTmpStoreId, @nTotalSavings,
	   @nTotalCurrentGlmrateSavings, @nTotalStore   --CR-105
WHILE @@FETCH_STATUS = 0
BEGIN
   SET @nTotalStoreFlatFee = @nTotalStoreFlatFee + @nFlatFeeValue
   
   UPDATE #tmpInvoice 
   SET store_savings = @nTotalSavings,
       store_current_glmrate_savings = @nTotalCurrentGlmrateSavings, --CR-105
       store_total = @nTotalStore,
       store_fee = @nFlatFeeValue   --Store Flat Fee
   WHERE cust_id = @sTmpCustId
   AND store_id = @nTmpStoreId

   FETCH c_store_savings 
      INTO @sTmpCustId, @nTmpStoreId, @nTotalSavings,
	   @nTotalCurrentGlmrateSavings, @nTotalStore   --CR-105
END
CLOSE c_store_savings
DEALLOCATE c_store_savings

/**
UPDATE #tmp_invoice
SET store_savings = (SELECT SUM(savings)
   FROM #tmp_invoice a
   GROUP BY cust_id, store_id)
WHERE 
***/
print '6.Frequency:'+convert(char(30),getdate(),13)
--12.18.03 
--Sobreescribir frecuencia de equipo para que reporte siempre muestre
--frecuencia del servicio Service o cualquier otro servicio definido 
--por defecto(default_service) en la tabla VContract
------------
DECLARE c_default_frequency CURSOR FOR
   SELECT DISTINCT cust_id, store_id, vend_seq, 
	  account_no, invoice_no, eqpt_seq
   FROM #tmpInvoice
OPEN c_default_frequency
FETCH c_default_frequency
INTO @sEqCustId, @nEqStoreId, @nEqVendSeq, @sEqAccountNo, @sEqInvoiceNo,
     @nEqEqptSeq
SET @nCount=0
WHILE @@FETCH_STATUS = 0
BEGIN
   SET @nCount = @nCount + 1


   SET @nDefaultServId = -1
   SET @sDefaultFrequency ='-'
   
   --Buscar Default Service
   SET @sContractRange = ''  --jp 2.9.0
   IF @sShowContractRange = 'T' -- jp 2.9.0 Begin
   BEGIN 			-- jp 2.9.0
	   SELECT @nDefaultServId = serv_id ,
		@sOpeningDate = CONVERT(CHAR(10),opening_date ,101),
		@sExpirationDate = CONVERT(CHAR(10),expiration_date ,101)
		FROM VContract
		WHERE cust_id = @sEqCustId
		AND vend_seq = @nEqVendSeq
		AND store_id = @nEqStoreId
		AND eqpt_seq = @nEqEqptSeq
		AND default_service='T'
	
	SET @sContractRange = 'Start-End : ' + @sOpeningDate + ' - '+ @sExpirationDate  --jp 2.9.0
   END
   ELSE
   BEGIN
	   SELECT @nDefaultServId = serv_id FROM VContract
		WHERE cust_id = @sEqCustId
		AND vend_seq = @nEqVendSeq
		AND store_id = @nEqStoreId
		AND eqpt_seq = @nEqEqptSeq
		AND default_service='T'
   END --jp 2.9.0 end
	
   --If Found update
   IF @nDefaultServId > 0
   BEGIN
	SELECT DISTINCT @sDefaultFrequency = frequency_mask FROM #tmpInvoice
	  WHERE cust_id = @sEqCustId
	  AND store_id = @nEqStoreId
	  AND vend_seq = @nEqVendSeq
	  AND account_no = @sEqAccountNo 
	  AND invoice_no = @sEqInvoiceNo
	  AND eqpt_seq = @nEqEqptSeq
	  AND serv_id = @nDefaultServId

	IF @sDefaultFrequency<>'-'
	BEGIN
   	     UPDATE #tmpInvoice
	     	SET frequency_mask = @sDefaultFrequency,
		    contract_range = @sContractRange --jp 2.9.0
	  	WHERE cust_id = @sEqCustId
	  	AND store_id = @nEqStoreId
	  	AND vend_seq = @nEqVendSeq
	  	AND account_no = @sEqAccountNo 
	  	AND invoice_no = @sEqInvoiceNo
	  	AND eqpt_seq = @nEqEqptSeq
	END 
   END 
	
   PRINT 'Loop:'+ CAST (@nCount AS CHAR(2))+ 'DefServId:'+CAST(@nDefaultServId as char(2))

   FETCH c_default_frequency
   INTO @sEqCustId, @nEqStoreId, @nEqVendSeq, @sEqAccountNo, @sEqInvoiceNo,
        @nEqEqptSeq
END
CLOSE c_default_frequency
DEALLOCATE c_default_frequency
--------------
--06.12.04
--Actualizar Report Caption en lugar de customer.cust_report_name
print '7.ReportCaption:'+convert(char(30),getdate(),13)

IF LEN(@sReportCaption)>0 
BEGIN
   UPDATE #tmpInvoice
   SET cust_report_name=@sReportCaption
END
--Begin change
DECLARE c_store CURSOR FOR
   SELECT RTRIM(ISNULL(store_name,'N/A')) FROM #tmpInvoice

OPEN c_store
FETCH c_store INTO @sStoreName

WHILE @@FETCH_STATUS=0
BEGIN
   IF LEN(@sStoreName)=0
	UPDATE #tmpInvoice
	   SET store_name = 'N/A'
	   WHERE CURRENT OF c_store
      
   FETCH c_store INTO @sStoreName
END

CLOSE c_store
DEALLOCATE c_store
---------------------------


--GLM Rate.begin
--Back up rate in current_rate and change rate as glm_rate
IF @sUseGlmRate = 'T'
BEGIN
   UPDATE #tmpInvoice SET current_rate = rate, rate = glm_rate

END
--GLM Rate.end
--2016.11.13.StoreFlatFee.begin
UPDATE #tmpInvoice SET total_store_flat_fee = @nTotalStoreFlatFee
--StoreFlatFee.end
----------------------------
print '8.Insert RepData:'+convert(char(30),getdate(),13)
select * from #tmpInvoice
--Guardo los datos en RepData
INSERT INTO RptCostCont (report_id, cust_name, report_start, report_end,
store_no,
location,
vend_name,account,
invoice,
vinvoice_date,eqpt_temp,
eqpt_mask,
frequency_mask,
content_desc,
serv_desc, serv_usage, 
units, total_units, unit_type, 
old_rate, rate, 
glm_rate, current_rate,
total_serv, savings, rate_status, comment,
--units, serv_usage,
serv_desc1, serv_sum1, serv_desc2, serv_sum2,  --25,26,27,28
serv_desc3, serv_sum3, serv_desc4, serv_sum4,  --29,30,31,32
serv_desc5, serv_sum5, serv_desc6, serv_sum6,  --33,34,35,36
serv_desc7, serv_sum7, serv_desc8, serv_sum8,  --37,38,39,40
serv_desc9, serv_sum9, serv_desc10, serv_sum10, --41,42,43,44
serv_desc11, serv_sum11, serv_desc12, serv_sum12, --45,46,47,48
serv_desc13, serv_sum13, serv_desc14, serv_sum14,  --49,50,51,52
serv_desc101, serv_sum101, serv_desc102, serv_sum102, --53,54,55,56
serv_desc103, serv_sum103, serv_desc104, serv_sum104, --57,58,59,60
serv_desc105, serv_sum105, serv_desc106, serv_sum106, --61,62,63,64
serv_desc107, serv_sum107,  --65,66
total_charges, total_savings, --67,68
cust_id, store_id, vend_seq, account_no, invoice_no, eqpt_seq, serv_id,  --69,70,71,72,73,74,75
total_nonbillsavings, contract_range, total_savingsPercent,
label_savingsPercent, store_savings, store_name, account_mask,  --76,77, 78,79
glm_savings, contract_opening_date, contract_expiration_date,
store_address, store_city, state_id, store_number,
current_glmrate_savings, store_current_glmrate_savings, total_current_glmrate_savings,  --CR-105
total_glmrate_serv, total_glmrate_charges,  --CR-105
store_total, store_fee, total_store_flat_fee
)
SELECT 	
@nReportId, RTRIM(cust_report_name), CONVERT(CHAR(10),report_start), CONVERT(CHAR(10),report_end),  --0,1,2,3
LTRIM(CAST(RTRIM(ISNULL(store_co_code,''))+ ' '+RTRIM(store_number) AS CHAR(30))) AS store_no,  --4
CAST(RTRIM(store_address) + ' '+ RTRIM(store_city)+','+state_id  AS CHAR(60)) AS location,   --str1
CAST(RTRIM(vend_name)  AS CHAR(30)), account, --6, str4
--CAST('Acc#'+RTRIM(ISNULL(account_no,'')) AS CHAR(30)) AS account, --6,7
RTRIM(invoice), --str2
--CAST('Invoice #'+RTRIM(invoice_no) AS CHAR(60)) AS invoice,  --str2
'Date:' + CONVERT(CHAR(10),vinvoice_date,101), eqpt_temp,  --8
CAST(eqpt_mask AS CHAR(30)) , --10
--RTRIM(CAST(frequency_mask AS CHAR(30)))+ ' - '+CAST(content_desc AS CHAR(30)) AS frequency_mask ,--str5
frequency_mask , --str5
	content_desc , --12
	CAST(serv_desc AS CHAR(30)), serv_usage, --14,15
	CAST(units AS CHAR(100)) , total_units, unit_type,   --16,17,18
	old_rate, rate, 
	glm_rate, current_rate,
	total_serv, savings, rate_status, CAST(comment AS CHAR(60)), --19,20,21,22,23, str3
	--CAST(units AS CHAR(20)),serv_usage, --24,5   --Release 2.8.9
	serv_desc1, serv_sum1, serv_desc2, serv_sum2,  --25,26,27,28
	serv_desc3, serv_sum3, serv_desc4, serv_sum4,  --29,30,31,32
	serv_desc5, serv_sum5, serv_desc6, serv_sum6,  --33,34,35,36
	serv_desc7, serv_sum7, serv_desc8, serv_sum8,  --37,38,39,40
	serv_desc9, serv_sum9, serv_desc10, serv_sum10, --41,42,43,44
	serv_desc11, serv_sum11, serv_desc12, serv_sum12, --45,46,47,48
	serv_desc13, serv_sum13, serv_desc14, serv_sum14,  --49,50,51,52
	serv_desc101, serv_sum101, serv_desc102, serv_sum102, --53,54,55,56
	serv_desc103, serv_sum103, serv_desc104, serv_sum104, --57,58,59,60
	serv_desc105, serv_sum105, serv_desc106, serv_sum106, --61,62,63,64
	serv_desc107, serv_sum107,  --65,66
	total_charges, total_savings, --67,68
	cust_id, store_id, vend_seq, account_no, invoice_no, eqpt_seq, serv_id,  --69,70,71,72,73,74,75
	total_nonbillsavings,contract_range, total_savingsPercent, --76,77, 78
	LTRIM(RTRIM(label_savingsPercent)), store_savings,
	store_name, account_mask, glm_savings, contract_opening_date, contract_expiration_date,
	store_address, store_city, state_id, store_number,
	current_glmrate_savings, store_current_glmrate_savings, total_current_glmrate_savings,  --CR-105
        total_glmrate_serv, total_glmrate_charges,  --CR-105
        store_total, store_fee, total_store_flat_fee
FROM #tmpInvoice	
/*
ORDER BY cust_id, store_id, vend_seq,
	account_no, invoice_no, eqpt_seq desc, 
	serv_id
*/
print '9.End:'+convert(char(30),getdate(),13)
--Verifico que la informacion se inserte correctamente en la tabla temporal.
SET @nError = @@ERROR
IF @nError <> 0
BEGIN
   RETURN @nError
END
RETURN 0






GO


