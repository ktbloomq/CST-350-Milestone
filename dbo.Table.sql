CREATE TABLE [dbo].[users]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [firstName] NVARCHAR(50) NOT NULL, 
    [lastName] NVARCHAR(50) NOT NULL, 
    [sex] NVARCHAR(50) NOT NULL, 
    [age] INT NOT NULL, 
    [state] NVARCHAR(50) NOT NULL, 
    [email] NVARCHAR(50) NOT NULL, 
    [username] NVARCHAR(50) NOT NULL, 
    [password] NVARCHAR(50) NOT NULL
)
