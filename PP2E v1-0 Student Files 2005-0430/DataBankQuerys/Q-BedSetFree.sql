CREATE PROCEDURE usp_BedsSetFree
@BedNumber nvarchar(5)
AS
BEGIN TRANSACTION
UPDATE Beds 
SET Occupied = 0
WHERE BedNumber = @BedNumber
COMMIT