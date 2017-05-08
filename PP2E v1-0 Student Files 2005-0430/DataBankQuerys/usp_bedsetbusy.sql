CREATE PROCEDURE usp_BedsSetBusy
@BedNumber nvarchar(5)
AS
BEGIN TRANSACTION
UPDATE Beds 
SET Occupied = 1
WHERE BedNumber = @BedNumber
COMMIT
