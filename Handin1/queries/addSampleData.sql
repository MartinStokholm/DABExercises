USE RFM_system_au632826
INSERT INTO [Citizen] 
(CitizenID, Category, FirstName, LastName, EmailAddress, PhoneNumber) 
VALUES 
(1, 'Student', 'John', 'Doe', 'johndoe@mail.com', 12345678),
(2, 'Student', 'Bob', 'Doe', 'bobdoe@mail.com', 22345678),
(3, 'Student', 'Ann', 'Doe', 'anndoe@mail.com', 32345678),
(4, 'Student', 'Lea', 'Doe', 'leadoe@mail.com', 42345678)

INSERT INTO [Citizen] 
(CitizenID, Category, FirstName, LastName, EmailAddress, PhoneNumber, CVR) 
VALUES 
(5, 'Teacher', 'Hugo', 'Doe', 'hugodoe@mail.com', 99887766, 6942069),
(6, 'Teacher', 'Martin', 'Doe', 'martindoe@mail.com', 99887755, 4242424),
(7, 'Businessman', 'Poul', 'Doe', 'pouldoe@mail.com', 99887744, 6969699),
(8, 'Businessman', 'Oliver', 'Doe', 'oliverdoe@mail.com', 99887733, 4204202)

INSERT INTO [Facility]
(FacilityID, Name, Kind, StreetName, StreetNumber, ZipCode, CanBeReserved, Items, UsageRules)
VALUES
(1, 'Aula', 'Aula', 'Aula Street', 1, 4000, 1, 'Chairs, tables, projector', 'No smoking, no alcohol'),
(2, 'PrettyPark', 'Park', 'Cafeteria Street', 2, 4000, 1, 'Tables, chairs, coffee machine', 'No smoking, no alcohol'),
(3, 'Library', 'Library', 'Library Street', 3, 4000, 1, 'Books, computers, chairs', 'No smoking, no alcohol'),
(4, 'Gym', 'Gym', 'Gym Street', 4, 4000, 1, 'Weights, machines, benches', 'No smoking, no alcohol'),
(5, 'Classroom1', 'Classroom', 'Classroom Street', 5, 4000, 1, 'Chairs, tables, projector', 'No smoking, no alcohol'),
(6, 'Classroom2', 'Classroom', 'Classroom Street', 5, 4000, 1, 'Chairs, big tables, projector', 'No smoking, no alcohol'),
(7, 'Classroom3', 'Classroom', 'Classroom Street', 5, 4000, 1, 'Chairs, small tables, projector', 'No smoking, no alcohol')


INSERT INTO [Booking]
(BookingID, HourStart, HourEnd, NumberOfPeople, Notes, FacilityID)
VALUES
(1, 1100, 1200, 24, 'We are partying', 1),
(2, 1200, 1400, 12, 'We are in a park', 2),
(3, 1400, 1600, 4, 'We are working out', 4),
(4, 1600, 1800, 8, 'We are learning', 5)

INSERT INTO [Reservation]
(ReservationID, ReservedByID, BookingID)
VALUES
(1, 5, 1),
(2, 1, 2),
(3, 2, 3)