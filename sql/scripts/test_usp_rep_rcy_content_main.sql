declare @nReportId as int; 
declare @sCustId as CHAR(2)
declare @sStateId as CHAR(3)
declare @nGroupSeq as int
declare @nPeriodSeq as int
declare @sPeriodSeq as char(1)
declare @sStartDate as char(10)
declare @sEndDate as char(10)
declare @sReportCaption as char(100)
declare @nPeriodSeqFrom as int
declare @nPeriodSeqTo as int
declare @nError as int
set @nReportId= 218378;
set @sCustId='AM'
SET @sStateId='All'
set @nGroupSeq = 710
set @nPeriodSeq= 4767
set @sPeriodSeq ='P'
set @sStartDate='6/24/2018'
set @sEndDate='6/24/2018'
set @sReportCaption='Content Report'
set @nPeriodSeqFrom=4767
set @nPeriodSeqTo = 4767
exec usp_rep_rcy_content_main @nReportId, @sCustId, @sStateId, @nGroupSeq,
 @nPeriodSeq, @sPeriodSeq, @sStartDate, @sEndDate, @sReportCaption,
 @nPeriodSeqFrom, @nPeriodSeqTo, @nError