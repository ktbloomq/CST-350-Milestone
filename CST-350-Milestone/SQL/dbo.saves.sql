CREATE TABLE [dbo].[saves] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [userID]     INT            NOT NULL,
    [game]       NVARCHAR (MAX) NOT NULL,
    [date_saved] DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.saves_dbo.users] FOREIGN KEY ([userID]) REFERENCES [dbo].[users] ([Id])
);

