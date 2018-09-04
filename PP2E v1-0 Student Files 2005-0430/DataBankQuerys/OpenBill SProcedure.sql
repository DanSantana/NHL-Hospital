CREATE PROCEDURE usp_openBill
(@AdmissionID int, @StayLength int, @TV_DalyRate bit, @Phone_DR bit, @SemiPrivateRoom_DR bit, @PrivateRoom_DR bit, @TotalAmount money)
AS
BEGIN TRANSACTION
INSERT INTO Bills
(AdmissionID, StayLength, TV_DalyRate, Phone_DR, SemiPrivateRoom_DR, PrivateRoom_DR, TotalAmount)
VALUES
(@AdmissionID, @StayLength, @TV_DalyRate, @Phone_DR, @SemiPrivateRoom_DR, @PrivateRoom_DR, @TotalAmount)
COMMIT
SELECT @@IDENTITY AS 'New Bill ID'