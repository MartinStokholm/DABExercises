USE RFM_system_au632826
INSERT INTO Citizen 
(CitizenID, FirstName, LastName, EmailAddress, PhoneNumber, Category)
VALUES
(1, 'John', 'Doe', 'johndoe@mail.com', 12345678, 'Student'),
(2, 'Ann', 'Doe', 'anndoe@mail.com', 22345678, 'Private'),
(3, 'Jane', 'Doe', 'janedoe@mail.com', 32345678, 'Student')

INSERT INTO Citizen 
(CitizenID, FirstName, LastName, EmailAddress, PhoneNumber, Category, CVR)
VALUES
(4, 'Super', 'Man', 'superman@mail.com', 69696969, 'Business', 123123)
(5, 'Super', 'Woman', 'superwoman@mail.com', 42042069, 'Business', 321321)

INSERT INTO Facility
(FacilityID, Name, Kind, StreetName, StreetNumber, ZipCode, CanBeReserved, Items, UsageRules)
VALUES
(1, 'Facility1', 'Gym', 'StreetName1', 1, 8200, 0, 'Benchpress, squatrack, dumbells', 'No crossfit'),
(2, 'Facility2', 'Gym', 'StreetName2', 2, 8200, 0, 'Treadmill, boxingbag, jumpingropes', 'No crossfit'),
(3, 'Facility3', 'Swimming pool', 'StreetName3', 3, 8200, 1, 'Sunbeds, chairs, bar', 'No smoking'),
(4, 'Facility4', 'Sports hall', 'StreetName4', 4, 8200, 1, 'Weights, machines, benches', 'No smoking, no alcohol'),
(5, 'Facility5', 'Tennis court', 'StreetName5', 5, 8200, 1, 'Tennisracket, tennisballs', 'No smoking, no alcohol'),
(6, 'Facility6', 'Fireplace', 'StreetName6', 6, 8200, 1, 'Axe, wood, lighters', 'No smoking, no alcohol'),
(7, 'Facility7', 'Forest', 'StreetName7', 7, 8200, 1, 'Trees', 'What happens in the forest, stays in the forest')

INSERT INTO [Booking]
(BookingID, BookingStartTime, BookingEndTime, NumberOfPeople, Notes, FacilityID)
VALUES
(1, '2022-01-01 00:00:00', '2022-01-02 00:00:00', 24, 'We are partying', 7),
(2, '2022-01-02 00:00:00', '2022-01-03 00:00:00', 4, 'We are playing tennis', 5),
(3, '2022-01-03 00:00:00', '2022-01-04 00:00:00', 12, 'We are making fire', 6),

INSERT INTO [Reservation]
(ReservationID, ReservedByID, BookingID)
VALUES
(1, 1, 1),
(2, 2, 2),
(3, 3, 3)