USE [NLHospital_R01]
GO
/****** Object:  StoredProcedure [dbo].[usp_AddAdmissionRecord]    Script Date: 29/01/2017 11:12:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_AddAdmissionRecord]
(@PatientID nvarchar(20),@BedNumber nvarchar(5),@SurgeryScheduled bit,
@AdmitDate datetime,@SurgeryDate datetime, @DischargeDate datetime,
@DoctorID nvarchar(10), @tv bit, @phone bit) 
AS
BEGIN TRANSACTION
SET @AdmitDate = GETDATE();
INSERT INTO AdmissionRecords
(PatientID,BedNumber, SurgeryScheduled,AdmitDate,SurgeryDate,DischargeDate,DoctorID,TV,Phone)
VALUES
(@PatientID,@BedNumber, @SurgeryScheduled,@AdmitDate,@SurgeryDate,@DischargeDate,@DoctorID,@TV,@Phone)
COMMIT
SELECT @@IDENTITY AS 'New Admission ID'