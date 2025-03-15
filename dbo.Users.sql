CREATE TABLE [dbo].[Users] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (MAX) NOT NULL,
    [Password] NVARCHAR (MAX) NOT NULL,
    [Balance]  NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

select id from dbo.Users;