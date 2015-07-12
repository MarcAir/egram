
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/03/2015 16:44:57
-- Generated from EDMX file: C:\Users\mpozz_000\Documents\Visual Studio 2013\Projects\egr.am\egr.am\Models\ProductOfferingModels.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-SampleIdentity-20150629124248];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ContractPrice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prices] DROP CONSTRAINT [FK_ContractPrice];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductPrice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prices] DROP CONSTRAINT [FK_ProductPrice];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductOfferingProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_ProductOfferingProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductOfferingMarketingProductOfferingMarketingPage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductOfferingMarketingPages] DROP CONSTRAINT [FK_ProductOfferingMarketingProductOfferingMarketingPage];
GO
IF OBJECT_ID(N'[dbo].[FK_MediaProductOfferingMarketingPage_Media]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaProductOfferingMarketingPage] DROP CONSTRAINT [FK_MediaProductOfferingMarketingPage_Media];
GO
IF OBJECT_ID(N'[dbo].[FK_MediaProductOfferingMarketingPage_ProductOfferingMarketingPage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MediaProductOfferingMarketingPage] DROP CONSTRAINT [FK_MediaProductOfferingMarketingPage_ProductOfferingMarketingPage];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductOfferingProductOfferingMarketing]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductOfferingMarketings] DROP CONSTRAINT [FK_ProductOfferingProductOfferingMarketing];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ProductOfferings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductOfferings];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[Prices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Prices];
GO
IF OBJECT_ID(N'[dbo].[Contracts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contracts];
GO
IF OBJECT_ID(N'[dbo].[ProductOfferingMarketings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductOfferingMarketings];
GO
IF OBJECT_ID(N'[dbo].[ProductOfferingMarketingPages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductOfferingMarketingPages];
GO
IF OBJECT_ID(N'[dbo].[Media]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Media];
GO
IF OBJECT_ID(N'[dbo].[MediaProductOfferingMarketingPage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaProductOfferingMarketingPage];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProductOfferings'
CREATE TABLE [dbo].[ProductOfferings] (
    [Id] uniqueidentifier  NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL,
    [DateAdded] datetime  NOT NULL,
    [DateLastModified] datetime  NOT NULL,
    [Status] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] uniqueidentifier  NOT NULL,
    [NiceName] nvarchar(max)  NOT NULL,
    [ManufacturerPartNumber] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [SKU] nvarchar(max)  NOT NULL,
    [ProductOfferingId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Prices'
CREATE TABLE [dbo].[Prices] (
    [Id] uniqueidentifier  NOT NULL,
    [Version] nvarchar(max)  NOT NULL,
    [DateProduction] nvarchar(max)  NOT NULL,
    [DateAdded] nvarchar(max)  NOT NULL,
    [DateDiscontinued] nvarchar(max)  NOT NULL,
    [MSRP] nvarchar(max)  NOT NULL,
    [MSRPDiscount] float  NOT NULL,
    [ProductBaseCost_Id] uniqueidentifier  NOT NULL,
    [ProductBaseCost_PriceMethod] nvarchar(max)  NOT NULL,
    [ContractId] uniqueidentifier  NOT NULL,
    [ProductId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Contracts'
CREATE TABLE [dbo].[Contracts] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ProductOfferingMarketings'
CREATE TABLE [dbo].[ProductOfferingMarketings] (
    [Id] uniqueidentifier  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Version] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [DateAdded] datetime  NOT NULL,
    [DateDiscontinued] datetime  NOT NULL,
    [DateLastModified] datetime  NOT NULL,
    [ProductOfferingId] uniqueidentifier  NOT NULL,
    [ProcessOrder] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductOfferingMarketingPages'
CREATE TABLE [dbo].[ProductOfferingMarketingPages] (
    [Id] uniqueidentifier  NOT NULL,
    [Page_HTML] nvarchar(max)  NOT NULL,
    [Page_PageName] nvarchar(max)  NOT NULL,
    [ProductOfferingMarketingId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Media'
CREATE TABLE [dbo].[Media] (
    [Id] uniqueidentifier  NOT NULL,
    [NiceName] nvarchar(max)  NOT NULL,
    [URL] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MediaProductOfferingMarketingPage'
CREATE TABLE [dbo].[MediaProductOfferingMarketingPage] (
    [Media_Id] uniqueidentifier  NOT NULL,
    [ProductOfferingMarketingPages_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ProductOfferings'
ALTER TABLE [dbo].[ProductOfferings]
ADD CONSTRAINT [PK_ProductOfferings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [PK_Prices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [PK_Contracts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductOfferingMarketings'
ALTER TABLE [dbo].[ProductOfferingMarketings]
ADD CONSTRAINT [PK_ProductOfferingMarketings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductOfferingMarketingPages'
ALTER TABLE [dbo].[ProductOfferingMarketingPages]
ADD CONSTRAINT [PK_ProductOfferingMarketingPages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Media'
ALTER TABLE [dbo].[Media]
ADD CONSTRAINT [PK_Media]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Media_Id], [ProductOfferingMarketingPages_Id] in table 'MediaProductOfferingMarketingPage'
ALTER TABLE [dbo].[MediaProductOfferingMarketingPage]
ADD CONSTRAINT [PK_MediaProductOfferingMarketingPage]
    PRIMARY KEY CLUSTERED ([Media_Id], [ProductOfferingMarketingPages_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ContractId] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [FK_ContractPrice]
    FOREIGN KEY ([ContractId])
    REFERENCES [dbo].[Contracts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractPrice'
CREATE INDEX [IX_FK_ContractPrice]
ON [dbo].[Prices]
    ([ContractId]);
GO

-- Creating foreign key on [ProductId] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [FK_ProductPrice]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductPrice'
CREATE INDEX [IX_FK_ProductPrice]
ON [dbo].[Prices]
    ([ProductId]);
GO

-- Creating foreign key on [ProductOfferingId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_ProductOfferingProduct]
    FOREIGN KEY ([ProductOfferingId])
    REFERENCES [dbo].[ProductOfferings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductOfferingProduct'
CREATE INDEX [IX_FK_ProductOfferingProduct]
ON [dbo].[Products]
    ([ProductOfferingId]);
GO

-- Creating foreign key on [ProductOfferingMarketingId] in table 'ProductOfferingMarketingPages'
ALTER TABLE [dbo].[ProductOfferingMarketingPages]
ADD CONSTRAINT [FK_ProductOfferingMarketingProductOfferingMarketingPage]
    FOREIGN KEY ([ProductOfferingMarketingId])
    REFERENCES [dbo].[ProductOfferingMarketings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductOfferingMarketingProductOfferingMarketingPage'
CREATE INDEX [IX_FK_ProductOfferingMarketingProductOfferingMarketingPage]
ON [dbo].[ProductOfferingMarketingPages]
    ([ProductOfferingMarketingId]);
GO

-- Creating foreign key on [Media_Id] in table 'MediaProductOfferingMarketingPage'
ALTER TABLE [dbo].[MediaProductOfferingMarketingPage]
ADD CONSTRAINT [FK_MediaProductOfferingMarketingPage_Media]
    FOREIGN KEY ([Media_Id])
    REFERENCES [dbo].[Media]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductOfferingMarketingPages_Id] in table 'MediaProductOfferingMarketingPage'
ALTER TABLE [dbo].[MediaProductOfferingMarketingPage]
ADD CONSTRAINT [FK_MediaProductOfferingMarketingPage_ProductOfferingMarketingPage]
    FOREIGN KEY ([ProductOfferingMarketingPages_Id])
    REFERENCES [dbo].[ProductOfferingMarketingPages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MediaProductOfferingMarketingPage_ProductOfferingMarketingPage'
CREATE INDEX [IX_FK_MediaProductOfferingMarketingPage_ProductOfferingMarketingPage]
ON [dbo].[MediaProductOfferingMarketingPage]
    ([ProductOfferingMarketingPages_Id]);
GO

-- Creating foreign key on [ProductOfferingId] in table 'ProductOfferingMarketings'
ALTER TABLE [dbo].[ProductOfferingMarketings]
ADD CONSTRAINT [FK_ProductOfferingProductOfferingMarketing]
    FOREIGN KEY ([ProductOfferingId])
    REFERENCES [dbo].[ProductOfferings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductOfferingProductOfferingMarketing'
CREATE INDEX [IX_FK_ProductOfferingProductOfferingMarketing]
ON [dbo].[ProductOfferingMarketings]
    ([ProductOfferingId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------