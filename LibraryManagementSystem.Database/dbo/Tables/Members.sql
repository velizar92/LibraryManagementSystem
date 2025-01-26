﻿CREATE TABLE [dbo].[Members]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] NVARCHAR(100) NOT NULL,
	[LastName] NVARCHAR(100),
	[Email] VARCHAR(70) NOT NULL UNIQUE,
	[PhoneNumber] VARCHAR(20),
	[IsDeleted] BIT,
	[DeletedOn] DATETIME,
)
