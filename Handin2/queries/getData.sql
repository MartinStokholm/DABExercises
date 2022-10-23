-- Get all available facilities names and closest/"nærmeste" address
USE RFM_system_au632826
SELECT Name, StreetName, StreetNumber, ZipCode 
FROM Facility

-- Get all facilities as a table of names and address grouped by their kind
USE RFM_system_au632826_v2
SELECT Name, StreetName, StreetNumber, ZipCode, Kind, IsAvailable
FROM Facilities
ORDER BY Kind

-- Get a list of booked facilities (name, location), with the booking user 
--(and possible business) and the timeslot it is booked in.
USE RFM_system_au632826_v2
SELECT 
    Citizens.FirstName, Citizens.LastName, Citizens.CVR, 
    Bookings.BookingStartTime, Bookings.BookingEndTime, Bookings.ID, 
    Facilities.Name, Facilities.Kind, Facilities.StreetName, Facilities.StreetNumber, Facilities.ZipCode
FROM Reservations
    INNER JOIN Citizens ON Reservations.CitizenID=Citizens.ID
    INNER JOIN Bookings ON Reservations.BookingID=Bookings.ID
    INNER JOIN Facilities ON Bookings.FacilityID=Facilities.ID

 

