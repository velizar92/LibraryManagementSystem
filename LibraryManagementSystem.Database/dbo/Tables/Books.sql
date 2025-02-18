﻿CREATE TABLE [dbo].[Books]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Title] NVARCHAR(100) NOT NULL,
	[Author] NVARCHAR(100) NOT NULL,
	[Genre] NVARCHAR(50),
	[PublishedYear] CHAR(4),
	[IsDeleted] BIT,
	[DeletedOn] DATETIME,
)
