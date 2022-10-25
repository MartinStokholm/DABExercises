USE RFM_system_au632826_v2
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
(Name, Kind, StreetName, StreetNumber, ZipCode, CanBeReserved, IsAvailable, AvailableItems, UsageRules)
VALUES
('Facility1', 'Gym', 'StreetName1', 1, 8200, 0, 1, 'Benchpress, squatrack, dumbells', 'No crossfit'),
('Facility2', 'Gym', 'StreetName2', 2, 8200, 0, 1,'Treadmill, boxingbag, jumpingropes', 'No crossfit'),
('Facility3', 'Swimming pool', 'StreetName3', 3, 8200, 1, 1, 'Sunbeds, chairs, bar', 'No smoking'),
('Facility4', 'Sports hall', 'StreetName4', 4, 8200, 1, 1,'Weights, machines, benches', 'No smoking, no alcohol'),
('Facility5', 'Tennis court', 'StreetName5', 5, 8200, 1, 1, 'Tennisracket, tennisballs', 'No smoking, no alcohol'),
('Facility6', 'Fireplace', 'StreetName6', 6, 8200, 1, 1, 'Axe, wood, lighters', 'No smoking, no alcohol'),
('Facility7', 'Forest', 'StreetName7', 7, 8200, 1, 1, 'Trees', 'What happens in the forest, stays in the forest')

INSERT INTO [Bookings]
(BookingStartTime, BookingEndTime, NumberOfPeople, Notes, FacilityID)
VALUES
('2022-01-01 00:00:00', '2022-01-02 00:00:00', 24, 'We are partying', 7),
('2022-01-02 00:00:00', '2022-01-03 00:00:00', 4, 'We are playing tennis', 5),
('2022-01-03 00:00:00', '2022-01-04 00:00:00', 12, 'We are making fire', 6)

INSERT INTO [BookingCitizen]
(BookingsId, CitizensId)
VALUES
(1, 1),
(1, 2),
(1, 3),
(2, 4),
(2, 5)

INSERT INTO [Reservations]
(CitizenId, BookingID)
VALUES
(1, 1),
(2, 2),
(4, 3)

INSERT INTO [Maintenances]
(Describtion, Date, FacilityId)
VALUES
('Fixed all the broken stuff','2022-01-03 00:00:00', 7),
('Extingished all the fire','2022-01-04 00:17:42', 6)

UPDATE [Facilities]
SET IsAvailable = 0
WHERE Facilities.Id = 5;

UPDATE [Facilities]
SET IsAvailable = 0
WHERE Facilities.Id = 6;

UPDATE [Facilities]
SET IsAvailable = 0
WHERE Facilities.Id = 7;

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