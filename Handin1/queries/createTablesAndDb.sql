CREATE DATABASE RFM_system_au632826
USE RFM_system_au632826

CREATE TABLE [Citizen]
(
    CitizenID INT PRIMARY KEY,
    FirstName CHAR(100),
    LastName CHAR(100),
    EmailAddress CHAR(100),
    PhoneNumber CHAR(8),
    Category CHAR(100) CHECK
    (
        Category='Private' OR
        Category='Business' OR
        Category='Student'
    ),
    CVR INT DEFAULT NULL,
)

CREATE TABLE [Facility]
(
    FacilityID INT PRIMARY KEY,
    Name CHAR(100), 
    Kind CHAR(100) CHECK
    (
        Kind='Gym' OR
        Kind='Swimming pool' OR
        Kind='Sports hall' OR
        Kind='Tennis court' OR
        Kind='Fireplace' OR
        Kind='Forest' 
    ),
    StreetName CHAR(100),
    StreetNumber INT,
    ZipCode INT,
    CanBeReserved BIT,
    Items CHAR(150),
    UsageRules CHAR(150)
)

CREATE TABLE [Booking]
(
    BookingID INT PRIMARY KEY,
    BookingStartTime DATETIME,
    BookingEndTime DATETIME,
    NumberOfPeople INT,
    Notes CHAR(150),
    FacilityID INT FOREIGN KEY REFERENCES Facility(FacilityID)
)

CREATE TABLE [Reservation]
(
    ReservationID INT PRIMARY KEY,
    ReservedByID INT FOREIGN KEY REFERENCES Citizen(CitizenID),
    BookingID INT FOREIGN KEY REFERENCES Booking(BookingID)
)

CREATE TABLE [MaintanceIntervention]
(
    MaintanceID INT PRIMARY KEY,
    MaintanceDescription CHAR(150),
    MaintanceDate DATETIME,
    MaintanceOnFacilityID INT FOREIGN KEY REFERENCES Facility(FacilityID)
)