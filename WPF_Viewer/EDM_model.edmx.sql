
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/04/2013 00:01:05
-- Generated from EDMX file: D:\Documents\Programming\DB_Practicum\WPF_Viewer\EDM_model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EDM_model_db_wpf];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RelationUser11]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RelationSet] DROP CONSTRAINT [FK_RelationUser11];
GO
IF OBJECT_ID(N'[dbo].[FK_RelationUser2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RelationSet] DROP CONSTRAINT [FK_RelationUser2];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
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
    [BirthDate] datetime  NOT NULL,
    [FirstName] nvarchar(15)  NOT NULL,
    [LastName] nvarchar(15)  NOT NULL
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

-- Creating primary key on [Id] in table 'RelationSet'
ALTER TABLE [dbo].[RelationSet]
ADD CONSTRAINT [PK_RelationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------