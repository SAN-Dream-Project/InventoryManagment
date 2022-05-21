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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220308141516_Added_UserRole_Table')
BEGIN
    CREATE TABLE [Roles] (
        [Id] uniqueidentifier NOT NULL,
        [RoleName] nvarchar(max) NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [CreatedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NULL,
        [ModifiedDate] datetime2 NULL,
        [DeletedBy] nvarchar(max) NULL,
        [DeleteDate] datetime2 NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220308141516_Added_UserRole_Table')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'DeleteDate', N'DeletedBy', N'ModifiedBy', N'ModifiedDate', N'RoleName') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] ON;
    EXEC(N'INSERT INTO [Roles] ([Id], [CreatedBy], [CreatedDate], [DeleteDate], [DeletedBy], [ModifiedBy], [ModifiedDate], [RoleName])
    VALUES (''11f90d44-423d-47b5-a0b1-51f79c627030'', NULL, NULL, NULL, NULL, NULL, NULL, N''Admin'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'DeleteDate', N'DeletedBy', N'ModifiedBy', N'ModifiedDate', N'RoleName') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220308141516_Added_UserRole_Table')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220308141516_Added_UserRole_Table', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220308143927_Added_User_Table')
BEGIN
    EXEC(N'DELETE FROM [Roles]
    WHERE [Id] = ''11f90d44-423d-47b5-a0b1-51f79c627030'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220308143927_Added_User_Table')
BEGIN
    CREATE TABLE [Users] (
        [Id] uniqueidentifier NOT NULL,
        [UserName] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [Status] bit NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [PrimaryMobNo] nvarchar(max) NOT NULL,
        [SecondaryMobNo] nvarchar(max) NOT NULL,
        [TelephoneNo] nvarchar(max) NOT NULL,
        [Gender] int NULL,
        [CreatedBy] nvarchar(max) NULL,
        [CreatedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NULL,
        [ModifiedDate] datetime2 NULL,
        [DeletedBy] nvarchar(max) NULL,
        [DeleteDate] datetime2 NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220308143927_Added_User_Table')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'DeleteDate', N'DeletedBy', N'ModifiedBy', N'ModifiedDate', N'RoleName') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] ON;
    EXEC(N'INSERT INTO [Roles] ([Id], [CreatedBy], [CreatedDate], [DeleteDate], [DeletedBy], [ModifiedBy], [ModifiedDate], [RoleName])
    VALUES (''84099e6d-40b2-460b-b17b-7287a91dbc93'', NULL, NULL, NULL, NULL, NULL, NULL, N''Admin'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'DeleteDate', N'DeletedBy', N'ModifiedBy', N'ModifiedDate', N'RoleName') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220308143927_Added_User_Table')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220308143927_Added_User_Table', N'6.0.0');
END;
GO

COMMIT;
GO

