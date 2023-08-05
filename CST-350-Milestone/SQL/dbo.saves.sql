CREATE TABLE [dbo].[saves]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [userID] INT NOT NULL, 
    [game] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_dbo.saves_dbo.users] FOREIGN KEY ([userID]) REFERENCES [users]([Id]),
	
)
