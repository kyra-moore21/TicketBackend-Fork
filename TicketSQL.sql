--CREATE DATABASE TicketDB;
--USE TicketDB;

--CREATE TABLE Ticket (
--	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
--	Title NVARCHAR(255),
--	Body NVARCHAR(255),

--	UserOpened NVARCHAR(255),
--	UserCloser NVARCHAR(255),
--	IsOpen Bit
--);

--ALTER TABLE Ticket
--ADD Resolution NVARCHAR(255);

--EXEC sp_RENAME 'Ticket.UserCloser', 'UserClosed', 'COLUMN';

--INSERT INTO Ticket (Title, Body, UserOpened, UserClosed, IsOpen, Resolution)
--VALUES ('Mouse not working', 'My mouse is not working', 'Steve', 'Deborah', 0, 'Plugged out and back in'),
--('Weird error', 'I am getting a weird error', 'Molly', 'Tom', 0, 'Restarted Computer'),
--('Software no good', 'My software is not working', 'Tim', NULL, 1, NULL);

--SELECT * FROM Ticket;

--CREATE TABLE Bookmark (
--	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
--	TicketId INT FOREIGN KEY REFERENCES Ticket(Id),
--	UserBookmarked NVARCHAR(255)
--);



--INSERT INTO Bookmark (TicketId, UserBookmarked)
--VALUES ('1', 'Samantha'), ('3', 'Paulie');

--SELECT * FROM Bookmark
--Join Ticket ON Bookmark.TicketId = Ticket.Id;

--CREATE TABLE [User] (Id INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
--FirstName NVARCHAR (255), 
--LastName NVARCHAR(255),
--PhotoURL NVARCHAR(255),
--Email NVARCHAR (255)
--);

--CREATE TABLE Comment ( Id INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
--UserId INT FOREIGN KEY REFERENCES [User](Id), Body NVARCHAR(255)
--);

--ALTER TABLE Ticket
--DROP COLUMN UserClosed;

--ALTER TABLE Ticket
--DROP COLUMN UserOpened;

--ALTER TABLE Ticket
--ADD UserOpenId INT FOREIGN KEY REFERENCES [User](Id);

--ALTER TABLE Ticket
--ADD UserClosedId INT FOREIGN KEY REFERENCES [User](Id);

--SELECT * FROM Ticket;

--ALTER TABLE Bookmark
--DROP COLUMN UserBookmarked;

--ALTER TABLE Bookmark
--ADD UserBookmarked INT FOREIGN KEY REFERENCES [User](Id);

--INSERT INTO [User] (FirstName, LastName, PhotoURL, Email)
--VALUES ('Ben', 'Jones', 'https://people.com/thmb/Bo8MTMyoT2JvQNg8fULYjTBEpow=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(511x0:513x2)/lala-1024-589f1474607b4defb07769b3da4bbbb5.jpg', 'benjones1864@gmail.com'),
--('Kyra', 'Moore', 'https://i.pinimg.com/474x/06/61/b4/0661b4eb6dedae522d372869b0e39281.jpg', 'kyramoore444@gmail.com'),
--('Ramsey', 'Louder', 'https://static.wikia.nocookie.net/telletubbies/images/e/e2/Tinky_Winky_intro.PNG', 'RamseyLouder@gmail.com');


--INSERT INTO Comment (UserId, Body)
--VALUES (1, 'Angular is neat!'), (2, 'SQL is cool!'), (3, 'C# is rad!');



--INSERT INTO Ticket (Title, Body, IsOpen, Resolution, UserOpenId, UserClosedId)
--VALUES ('Broken stuff', 'Stuff is broken', 0, 'Fixed', 1, 2),
--('Stuff no good', 'The stuff is no good', 1, NULL, 2, NULL),
--('Everything is terrible', 'Please make it better', 1, NULL, 3, NULL);

--INSERT INTO Bookmark (TicketId, UserBookmarked)
--VALUES (1, 1), (2, 2), (3, 3)

--USE TicketDB;

--CREATE TABLE [User] (Id INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
--FirstName NVARCHAR (255), 
--LastName NVARCHAR(255),
--PhotoURL NVARCHAR(255),
--Email NVARCHAR (255)
--);

--CREATE TABLE Ticket (
--	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
--	Title NVARCHAR(255),
--	Body NVARCHAR(255),
--	UserOpened INT FOREIGN KEY REFERENCES [User](Id),
--	UserClosed INT FOREIGN KEY REFERENCES [User](Id),
--	IsOpen Bit
--);

--ALTER TABLE Ticket
--ADD Resolution NVARCHAR(255)

--CREATE TABLE Bookmark (
--	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
--	TicketId INT FOREIGN KEY REFERENCES Ticket(Id),
--	UserBookmarked INT FOREIGN KEY REFERENCES [User](Id)
--);

--CREATE TABLE Comment ( Id INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
--UserId INT FOREIGN KEY REFERENCES [User](Id), Body NVARCHAR(255),
--TicketId INT FOREIGN KEY REFERENCES [Ticket](Id)
--);

--INSERT INTO [User] (FirstName, LastName, PhotoURL, Email)
--VALUES ('Ben', 'Jones', 'https://people.com/thmb/Bo8MTMyoT2JvQNg8fULYjTBEpow=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(511x0:513x2)/lala-1024-589f1474607b4defb07769b3da4bbbb5.jpg', 'benjones1864@gmail.com'),
--('Kyra', 'Moore', 'https://i.pinimg.com/474x/06/61/b4/0661b4eb6dedae522d372869b0e39281.jpg', 'kyramoore444@gmail.com'),
--('Ramsey', 'Louder', 'https://static.wikia.nocookie.net/telletubbies/images/e/e2/Tinky_Winky_intro.PNG', 'RamseyLouder@gmail.com');

--INSERT INTO Ticket (Title, Body, IsOpen, Resolution, UserOpened, UserClosed)
--VALUES ('Broken stuff', 'Stuff is broken', 0, 'Fixed', 1, 2),
--('Stuff no good', 'The stuff is no good', 1, NULL, 2, NULL),
--('Everything is terrible', 'Please make it better', 1, NULL, 3, NULL);

--INSERT INTO Comment (UserId, Body, TicketId)
--VALUES (1, 'Angular is neat!', 1), (2, 'SQL is cool!', 2), (3, 'C# is rad!', 3);

--INSERT INTO Bookmark (TicketId, UserBookmarked)
--VALUES (1, 1), (2, 2), (3, 3);

