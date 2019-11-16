USE master 
GO

CREATE DATABASE CodesanookAdventure
GO


USE CodesanookAdventure
GO

ALTER DATABASE CodesanookAdventure
SET ALLOW_SNAPSHOT_ISOLATION on
GO


/*
The Snapshot Transaction Isolation Level can only be used after a switch allowing it has been set in the database. 
Turning on this switch tells the database to set up the versioning environment. 
It is important to understand this point, because once versioning is turned on, 
the database has the overhead of maintaining the versioning overhead 
regardless of whether any transactions are using the Snapshot Isolation Level.
ALTER DATABASE statement (note that all database user connections will be killed when doing this).
virtual snapshot environment in TempDB
*/
USE master
GO

ALTER DATABASE CodesanookAdventure
SET READ_COMMITTED_SNAPSHOT ON
GO

exec sp_who2
/*
The Read Committed Snapshot Isolation Level is also turned on by means of a database switch. 
Then, any transactions that use the Read Committed Isolation Level will work with versioning.
*/


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
