IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'InprocessGroup')
  BEGIN
    CREATE DATABASE [InprocessGroup];
  END
GO

USE [InprocessGroup];
GO
  


IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Movies] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [Genre] nvarchar(max) NULL,
    [ReleaseDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Genre', N'ReleaseDate', N'Title') AND [object_id] = OBJECT_ID(N'[Movies]'))
    SET IDENTITY_INSERT [Movies] ON;
INSERT INTO [Movies] ([Id], [Genre], [ReleaseDate], [Title])
VALUES (1, N'Ciencia Ficción', '2015-12-25T00:00:00.0000000', N'Dune: Parte 2'),
(2, N'Drama', '2014-11-26T00:00:00.0000000', N'El clan de hierro');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Genre', N'ReleaseDate', N'Title') AND [object_id] = OBJECT_ID(N'[Movies]'))
    SET IDENTITY_INSERT [Movies] OFF;
GO
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240319014556_InitialCreate', N'8.0.3');
GO

COMMIT;
GO