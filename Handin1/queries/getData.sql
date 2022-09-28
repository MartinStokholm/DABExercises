USE RFM_system_au632826
-- Get all available facilities names and closest/"nærmeste" address
SELECT Name, StreetName, StreetNumber, ZipCode 
FROM Facility

-- Get all facilities as a table of names and address grouped by their kind
USE RFM_system_au632826
SELECT Kind 
FROM Facility
GROUP BY Kind

-- Get a list of booked facilities (name, location), with the booking user 
--(and possible business) and the timeslot it is booked in.