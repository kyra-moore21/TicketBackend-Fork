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

SELECT * FROM Bookmark
Join Ticket ON Bookmark.TicketId = Ticket.Id;