CREATE TABLE [dbo].[BorrowedBooks]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[BorrowDate] DATE,
	[ReturnDate] DATE,
	[IsDeleted] BIT,
	[DeletedOn] DATETIME,
	[BookId] INT,
	FOREIGN KEY([BookId]) REFERENCES Books([Id]),
	[MemberId] INT,
	FOREIGN KEY([MemberId]) REFERENCES Members([Id]),
	CONSTRAINT UC_BookId_ReturnDate UNIQUE (BookId, ReturnDate)
)
