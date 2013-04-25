
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/26/2013 17:27:22
-- Generated from EDMX file: D:\Documents\Programming\DB_Practicum\DBPracticum\EDM_model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EDM_model_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BirthDateUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_BirthDateUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FirstNameUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_FirstNameUser];
GO
IF OBJECT_ID(N'[dbo].[FK_RelationUser11]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RelationSet] DROP CONSTRAINT [FK_RelationUser11];
GO
IF OBJECT_ID(N'[dbo].[FK_RelationUser2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RelationSet] DROP CONSTRAINT [FK_RelationUser2];
GO
IF OBJECT_ID(N'[dbo].[FK_LastNameUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_LastNameUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[BirthDateSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BirthDateSet];
GO
IF OBJECT_ID(N'[dbo].[FirstNameSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FirstNameSet];
GO
IF OBJECT_ID(N'[dbo].[LastNameSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LastNameSet];
GO
IF OBJECT_ID(N'[dbo].[RelationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RelationSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Photo] varbinary(max)  NULL,
    [BirthDateBDate] datetime  NOT NULL,
    [FirstNameFName] nvarchar(15)  NOT NULL,
    [LastNameLName] nvarchar(15)  NOT NULL
);
GO

-- Creating table 'BirthDateSet'
CREATE TABLE [dbo].[BirthDateSet] (
    [BDate] datetime  NOT NULL
);
GO

-- Creating table 'FirstNameSet'
CREATE TABLE [dbo].[FirstNameSet] (
    [FName] nvarchar(15)  NOT NULL
);
GO

-- Creating table 'LastNameSet'
CREATE TABLE [dbo].[LastNameSet] (
    [LName] nvarchar(15)  NOT NULL
);
GO

-- Creating table 'RelationSet'
CREATE TABLE [dbo].[RelationSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Type] nvarchar(15)  NOT NULL,
    [UserId1] uniqueidentifier  NOT NULL,
    [UserId2] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [BDate] in table 'BirthDateSet'
ALTER TABLE [dbo].[BirthDateSet]
ADD CONSTRAINT [PK_BirthDateSet]
    PRIMARY KEY CLUSTERED ([BDate] ASC);
GO

-- Creating primary key on [FName] in table 'FirstNameSet'
ALTER TABLE [dbo].[FirstNameSet]
ADD CONSTRAINT [PK_FirstNameSet]
    PRIMARY KEY CLUSTERED ([FName] ASC);
GO

-- Creating primary key on [LName] in table 'LastNameSet'
ALTER TABLE [dbo].[LastNameSet]
ADD CONSTRAINT [PK_LastNameSet]
    PRIMARY KEY CLUSTERED ([LName] ASC);
GO

-- Creating primary key on [Id] in table 'RelationSet'
ALTER TABLE [dbo].[RelationSet]
ADD CONSTRAINT [PK_RelationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BirthDateBDate] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_BirthDateUser]
    FOREIGN KEY ([BirthDateBDate])
    REFERENCES [dbo].[BirthDateSet]
        ([BDate])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BirthDateUser'
CREATE INDEX [IX_FK_BirthDateUser]
ON [dbo].[UserSet]
    ([BirthDateBDate]);
GO

-- Creating foreign key on [FirstNameFName] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_FirstNameUser]
    FOREIGN KEY ([FirstNameFName])
    REFERENCES [dbo].[FirstNameSet]
        ([FName])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FirstNameUser'
CREATE INDEX [IX_FK_FirstNameUser]
ON [dbo].[UserSet]
    ([FirstNameFName]);
GO

-- Creating foreign key on [UserId1] in table 'RelationSet'
ALTER TABLE [dbo].[RelationSet]
ADD CONSTRAINT [FK_RelationUser11]
    FOREIGN KEY ([UserId1])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RelationUser11'
CREATE INDEX [IX_FK_RelationUser11]
ON [dbo].[RelationSet]
    ([UserId1]);
GO

-- Creating foreign key on [UserId2] in table 'RelationSet'
ALTER TABLE [dbo].[RelationSet]
ADD CONSTRAINT [FK_RelationUser2]
    FOREIGN KEY ([UserId2])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RelationUser2'
CREATE INDEX [IX_FK_RelationUser2]
ON [dbo].[RelationSet]
    ([UserId2]);
GO

-- Creating foreign key on [LastNameLName] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_LastNameUser]
    FOREIGN KEY ([LastNameLName])
    REFERENCES [dbo].[LastNameSet]
        ([LName])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LastNameUser'
CREATE INDEX [IX_FK_LastNameUser]
ON [dbo].[UserSet]
    ([LastNameLName]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------