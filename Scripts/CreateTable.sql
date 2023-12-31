--User
CREATE TABLE [User]
(
UserId INT  PRIMARY kEY IDENTITY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
UserName VARCHAR(50) NOT NULL,
Password VARCHAR(50) NOT NULL
);
--Customer
CREATE TABLE [Customer]
(
CustomerId INT  PRIMARY kEY IDENTITY,
FullName VARCHAR(50) NOT NULL,
DocumentNumber  VARCHAR(10) NOT NULL
);

CREATE TABLE [Booking]
(
BookingId INT  PRIMARY kEY IDENTITY,
RegisterDate DATETIME NOT NULL,
Code  VARCHAR(50) NOT NULL,
Type  VARCHAR(50) NOT NULL,
UserId INT NOT NULL,
CustomerId INT NOT NULL,
FOREIGN KEY (UserId) REFERENCES [User] (UserId),
FOREIGN KEY (CustomerId) REFERENCES [Customer] (CustomerId)
);
