
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/31/2021 15:14:00
-- Generated from EDMX file: C:\Users\ISKUR\source\repos\Tv_Kanal_ModelFirst\Tv_Kanal_ModelFirst\TvKanalModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TvKanal];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'KanalSet'
CREATE TABLE [dbo].[KanalSet] (
    [KanalID] int IDENTITY(1,1) NOT NULL,
    [KanalAdi] nvarchar(max)  NOT NULL,
    [Ciro] decimal(18,0)  NOT NULL,
    [Adres] nvarchar(max)  NOT NULL,
    [Reyting] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'YayinSet'
CREATE TABLE [dbo].[YayinSet] (
    [YayinID] int IDENTITY(1,1) NOT NULL,
    [YayinAdi] nvarchar(max)  NOT NULL,
    [YayinTarih] nvarchar(max)  NOT NULL,
    [Reyting] decimal(18,0)  NOT NULL,
    [KanalID] int  NOT NULL
);
GO

-- Creating table 'SorumluSet'
CREATE TABLE [dbo].[SorumluSet] (
    [SorumluID] int IDENTITY(1,1) NOT NULL,
    [AdSoyad] nvarchar(max)  NOT NULL,
    [Görevli] nvarchar(max)  NOT NULL,
    [Maas] decimal(18,0)  NOT NULL,
    [GörevSayisi] int  NOT NULL,
    [YayinID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [KanalID] in table 'KanalSet'
ALTER TABLE [dbo].[KanalSet]
ADD CONSTRAINT [PK_KanalSet]
    PRIMARY KEY CLUSTERED ([KanalID] ASC);
GO

-- Creating primary key on [YayinID] in table 'YayinSet'
ALTER TABLE [dbo].[YayinSet]
ADD CONSTRAINT [PK_YayinSet]
    PRIMARY KEY CLUSTERED ([YayinID] ASC);
GO

-- Creating primary key on [SorumluID] in table 'SorumluSet'
ALTER TABLE [dbo].[SorumluSet]
ADD CONSTRAINT [PK_SorumluSet]
    PRIMARY KEY CLUSTERED ([SorumluID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [KanalID] in table 'YayinSet'
ALTER TABLE [dbo].[YayinSet]
ADD CONSTRAINT [FK_KanalYayin]
    FOREIGN KEY ([KanalID])
    REFERENCES [dbo].[KanalSet]
        ([KanalID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KanalYayin'
CREATE INDEX [IX_FK_KanalYayin]
ON [dbo].[YayinSet]
    ([KanalID]);
GO

-- Creating foreign key on [YayinID] in table 'SorumluSet'
ALTER TABLE [dbo].[SorumluSet]
ADD CONSTRAINT [FK_YayinSorumlu]
    FOREIGN KEY ([YayinID])
    REFERENCES [dbo].[YayinSet]
        ([YayinID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_YayinSorumlu'
CREATE INDEX [IX_FK_YayinSorumlu]
ON [dbo].[SorumluSet]
    ([YayinID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------