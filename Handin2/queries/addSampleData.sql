CREATE DATABASE RFMS_au632826_new 
USE RFMS_au632826_new
INSERT INTO [Citizens] 
(FirstName, LastName, Email, PhoneNumber, Category)
VALUES
('John', 'Doe', 'johndoe@mail.com', 12345678, 'Student'),
('Ann', 'Doe', 'anndoe@mail.com', 22345678, 'Private'),
('Jane', 'Doe', 'janedoe@mail.com', 32345678, 'Student')

INSERT INTO [Citizens] 
(FirstName, LastName, Email, PhoneNumber, Category, CVR)
VALUES
('Super', 'Man', 'superman@mail.com', 69696969, 'Business', 123123),
('Super', 'Woman', 'superwoman@mail.com', 42042069, 'Business', 321321)

INSERT INTO [Facilities]
(Name, Kind, StreetName, StreetNumber, ZipCode, CanBeReserved, UsageRules, Items)
VALUES
('Facility1', 'Gym', 'StreetName1', 1, 8200, 0, 'No crossfit', 'Benchpress, squatrack, dumbells'),
('Facility2', 'Gym', 'StreetName2', 2, 8200, 0, 'No crossfit','Treadmill, boxingbag, jumpingropes'),
('Facility3', 'Swimming pool', 'StreetName3', 3, 8200, 1, 'No smoking', 'Sunbeds, chairs, bar'),
('Facility4', 'Sports hall', 'StreetName4', 4, 8200, 1, 'No smoking, no alcohol', 'Weights, machines, benches'),
('Facility5', 'Tennis court', 'StreetName5', 5, 8200, 1, 'No smoking, no alcohol', 'Tennisracket, tennisballs'),
('Facility6', 'Fireplace', 'StreetName6', 6, 8200, 1, 'No smoking, no alcohol', 'Axe, wood, lighters'),
('Facility7', 'Forest', 'StreetName7', 7, 8200, 1, 'What happens in the forest, stays in the forest', 'Trees')

INSERT INTO [Bookings]
(BookingStartTime, BookingEndTime, NumberOfPeople, Notes, FacilityID)
VALUES
('2022-01-01 00:00:00', '2022-01-02 00:00:00', 4, 'We are partying', 21),
('2022-01-02 00:00:00', '2022-01-03 00:00:00', 4, 'We are playing tennis', 19),
('2022-01-03 00:00:00', '2022-01-04 00:00:00', 12, 'We are making fire', 20)


INSERT INTO [Reservations]
(CitizenId, BookingID)
VALUES
(7, 7)

INSERT INTO [MaintenanceInterventions]
(Describtion, Date, FacilityId)
VALUES
('Fixed all the broken stuff','2022-01-03 00:00:00', 21),
('Extingished all the fire','2022-01-04 00:17:42', 20)


INSERT INTO [BookingCitizen]
(BookingsId, CitizensId)
VALUES
(7, 7),
(7, 8),
(7, 9),
(7, 10)

UPDATE [Citizens]
SET CPR = 1122331232
WHERE Citizens.Id = 1;

UPDATE [Citizens]
SET CPR = 2233111111
WHERE Citizens.Id = 2;

UPDATE [Citizens]
SET CPR = 1212212122
WHERE Citizens.Id = 4;

UPDATE [Citizens]
SET CPR = 1211111122
WHERE Citizens.Id = 5;

UPDATE [Facilities]
SET Latitude = 5.420;
SET Longitude = 2.420;