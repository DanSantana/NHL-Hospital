CREATE PROCEDURE usp_ListSurgery
AS
BEGIN TRANSACTION
SELECT AdmissionRecords.PatientID ,(Patients.FirstName+' '+Patients.LastName) AS 'Patient Name',
Patients.Doctor AS 'Doctor ID', (Doctors.FirstName+''+Doctors.LastName) AS 'Doctor Name',
 Doctors.Specialty,Beds.WardName
FROM AdmissionRecords  INNER JOIN Patients
ON AdmissionRecords.PatientID = Patients.HealthNumber INNER JOIN Doctors
ON Patients.Doctor = Doctors.DoctorID INNER JOIN Beds
ON AdmissionRecords.BedNumber = Beds.BedNumber
WHERE AdmissionRecords.Discharged = 0 and AdmissionRecords.SurgeryScheduled = 1
COMMIT
