CREATE PROCEDURE usp_AddAdmissionRecord
(@PatientID nvarchar(20),@BedNumber nvarchar(5),@SurgeryScheduled bit,
@AdmitDate datetime,@SurgeryDate datetime, @DischargeDate datetime,
@DoctorID nvarchar(10)) 
AS
BEGIN TRANSACTION
SET @AdmitDate = GETDATE();
INSERT INTO AdmissionRecords
(PatientID,BedNumber, SurgeryScheduled,AdmitDate,SurgeryDate,DischargeDate,DoctorID)
VALUES
(@PatientID,@BedNumber, @SurgeryScheduled,@AdmitDate,@SurgeryDate,@DischargeDate,@DoctorID)
COMMIT
SELECT @@IDENTITY AS 'New Admission ID'