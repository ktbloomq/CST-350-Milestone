CREATE TABLE [dbo].[users]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [firstName] NVARCHAR(50) NOT NULL, 
    [lastName] NVARCHAR(50) NOT NULL, 
    [sex] INT NOT NULL, 
    [age] INT NOT NULL, 
    [state] INT NOT NULL, 
    [email] NVARCHAR(50) NOT NULL, 
    [username] NVARCHAR(50) NOT NULL, 
    [password] NVARCHAR(50) NOT NULL
)
