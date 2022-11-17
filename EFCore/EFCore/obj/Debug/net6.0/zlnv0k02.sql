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

CREATE TABLE [Employees] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221103104051_InitalCreate', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

insert into Employees Values('Ali Ahmed')
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221103115947_SeedingData', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Blogs] (
    [Id] int NOT NULL IDENTITY,
    [Url] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Blogs] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221103122724_AddBlogsTable', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Blogs]') AND [c].[name] = N'Url');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Blogs] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Blogs] ALTER COLUMN [Url] nvarchar(50) NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221103151005_modifyBlogTable', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Post] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Content] nvarchar(max) NOT NULL,
    [BlogId] int NOT NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Post_Blogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [Blogs] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Post_BlogId] ON [Post] ([BlogId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221103152732_AddPostTable', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Blogs]') AND [c].[name] = N'Url');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Blogs] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Blogs] ALTER COLUMN [Url] nvarchar(max) NOT NULL;
GO

ALTER TABLE [Blogs] ADD [CreateTime] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

CREATE TABLE [Books] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(44) NOT NULL,
    [Author] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221105160303_AddBookTable', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Blogs] ADD [Rating] int NOT NULL DEFAULT 2;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221105174835_AddRatingColInBlogTable', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Blogs]') AND [c].[name] = N'CreateTime');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Blogs] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Blogs] ADD DEFAULT '2022-11-05T19:57:56.4962059+02:00' FOR [CreateTime];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221105175756_AdddefaultValue', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Blogs]') AND [c].[name] = N'Rating');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Blogs] DROP CONSTRAINT [' + @var3 + '];');
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Blogs]') AND [c].[name] = N'CreateTime');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Blogs] DROP CONSTRAINT [' + @var4 + '];');
GO

CREATE TABLE [Authors] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221105181245_AdddAuthorTable', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Authors].[Name]', N'LName', N'COLUMN';
GO

ALTER TABLE [Authors] ADD [FName] nvarchar(50) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221105181515_AdddAuthorTableEdit', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Authors] ADD [DisplayName] AS [FName] + [LName];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221105183735_ComputeCol', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categories] (
    [Id] tinyint NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221105194205_AddCategoriesTable', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [BlogImage] (
    [Id] int NOT NULL IDENTITY,
    [Image] varbinary(max) NOT NULL,
    [Caption] nvarchar(max) NOT NULL,
    [BlogForeignKey] int NOT NULL,
    CONSTRAINT [PK_BlogImage] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BlogImage_Blogs_BlogForeignKey] FOREIGN KEY ([BlogForeignKey]) REFERENCES [Blogs] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Tags] (
    [TagId] int NOT NULL IDENTITY,
    CONSTRAINT [PK_Tags] PRIMARY KEY ([TagId])
);
GO

CREATE TABLE [PostTag] (
    [PostsId] int NOT NULL,
    [TagsTagId] int NOT NULL,
    CONSTRAINT [PK_PostTag] PRIMARY KEY ([PostsId], [TagsTagId]),
    CONSTRAINT [FK_PostTag_Post_PostsId] FOREIGN KEY ([PostsId]) REFERENCES [Post] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PostTag_Tags_TagsTagId] FOREIGN KEY ([TagsTagId]) REFERENCES [Tags] ([TagId]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_BlogImage_BlogForeignKey] ON [BlogImage] ([BlogForeignKey]);
GO

CREATE INDEX [IX_PostTag_TagsTagId] ON [PostTag] ([TagsTagId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221116083410_final', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateTime', N'Rating', N'Url') AND [object_id] = OBJECT_ID(N'[Blogs]'))
    SET IDENTITY_INSERT [Blogs] ON;
INSERT INTO [Blogs] ([Id], [CreateTime], [Rating], [Url])
VALUES (8, '2021-06-23T07:21:11.0000000', 7, N'www.google.com');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateTime', N'Rating', N'Url') AND [object_id] = OBJECT_ID(N'[Blogs]'))
    SET IDENTITY_INSERT [Blogs] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221116085412_seedingBlogData', N'6.0.10');
GO

COMMIT;
GO

