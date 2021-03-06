USE [NLHospital_R01]
GO
/****** Object:  StoredProcedure [dbo].[usp_openBill]    Script Date: 30/01/2017 1:41:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_openBill]
(@AdmissionID int, @StayLength int, @TV_DalyRate money, @Phone_DR money, @SemiPrivateRoom_DR money, @PrivateRoom_DR money, @TotalAmount money)
AS
BEGIN TRANSACTION
INSERT INTO Bills
(AdmissionID, StayLength, TV_DalyRate, Phone_DR, SemiPrivateRoom_DR, PrivateRoom_DR, TotalAmount)
VALUES
(@AdmissionID, @StayLength, @TV_DalyRate, @Phone_DR, @SemiPrivateRoom_DR, @PrivateRoom_DR, @TotalAmount)
COMMIT
SELECT @@IDENTITY AS 'New Bill ID'