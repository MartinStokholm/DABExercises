-- Get all available facilities names and closest/"nærmeste" address
USE RFM_system_au632826
SELECT Name, StreetName, StreetNumber, ZipCode 
FROM Facility

-- Get all facilities as a table of names and address grouped by their kind
USE RFM_system_au632826
SELECT Name, StreetName, StreetNumber, ZipCode, Kind
FROM Facility
ORDER BY Kind

-- Get a list of booked facilities (name, location), with the booking user 
--(and possible business) and the timeslot it is booked in.
USE RFM_system_au632826
SELECT 
    Citizen.FirstName, Citizen.LastName, 
    Booking.BookingStartTime, Booking.BookingEndTime, Booking.BookingID, 
    Facility.Name, Facility.Kind, Facility.StreetName, Facility.StreetNumber, Facility.ZipCode
FROM Reservation
    INNER JOIN Citizen ON Reservation.ReservedByID=Citizen.CitizenID
    INNER JOIN Booking ON Reservation.BookingID=Booking.BookingID
    INNER JOIN Facility ON Booking.FacilityID=Facility.FacilityID

 

