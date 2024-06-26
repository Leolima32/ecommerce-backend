﻿IF OBJECT_ID(N'[catalog].[__EFMigrationsHistory]') IS NULL
BEGIN
    IF SCHEMA_ID(N'catalog') IS NULL EXEC(N'CREATE SCHEMA [catalog];');
    CREATE TABLE [catalog].[__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF SCHEMA_ID(N'catalog') IS NULL EXEC(N'CREATE SCHEMA [catalog];');
GO

CREATE TABLE [catalog].[Categories] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastUpdated] datetime2 NOT NULL,
    [Active] bit NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [catalog].[Products] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [CategoryId] uniqueidentifier NOT NULL,
    [Tags] nvarchar(max) NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastUpdated] datetime2 NOT NULL,
    [Active] bit NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [catalog].[Categories] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Products_CategoryId] ON [catalog].[Products] ([CategoryId]);
GO

INSERT INTO [catalog].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240614173253_InitDatabase', N'8.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [catalog].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240618154657_SeparateHistoryTableSchema', N'8.0.5');
GO

COMMIT;
GO

