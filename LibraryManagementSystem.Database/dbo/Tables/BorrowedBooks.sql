CREATE TABLE [dbo].[BorrowedBooks]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[BorrowDate] DATE,
	[ReturnDate] DATE,
	[BookId] INT,
	FOREIGN KEY([BookId]) REFERENCES Books([Id]),
	[MemberId] INT,
	FOREIGN KEY([MemberId]) REFERENCES Members([Id]),
)
