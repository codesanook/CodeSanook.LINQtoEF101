USE master 
GO

CREATE DATABASE CodesanookAdventure
GO

USE CodesanookAdventure
GO

-- Create Employees table 
CREATE TABLE [dbo].[Employees] (
    [Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Salary] [Money] NOT NULL,
    CONSTRAINT [PK_Employees_Id] PRIMARY KEY CLUSTERED ([Id])
)
GO

-- Create a unique index
CREATE UNIQUE NONCLUSTERED INDEX [UX_Employees_Email] ON Employees([Email])
GO

INSERT INTO Employees VALUES 
('brad.gibson@example.com', 'Brad', 'Gibson', '1993-07-20', 9000),
('james.smith@example.com', 'James', 'Smith', '1999-06-21', 6500),
('byron.nichols@example.com', 'Byron', 'Nichols', '1986-04-01', 12000),
('renee.rogers@example.com', 'Renee', 'Rogers', '1990-07-09', 8000)
GO
