
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/09/2023 17:01:48
-- Generated from EDMX file: C:\Users\DashNinja\Desktop\Temp\Final_Angular_App\DAL\AlohaTraining.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AlohaTraining];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StateId] int  NOT NULL,
    [CityId] int  NOT NULL,
    [AreaId] int  NOT NULL,
    [ZipCode] varchar(20)  NOT NULL,
    [CustomerId] int  NOT NULL
);
GO

-- Creating table 'Areas'
CREATE TABLE [dbo].[Areas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] char(3)  NULL,
    [Name] varchar(100)  NULL,
    [CityId] int  NOT NULL
);
GO

-- Creating table 'Branches'
CREATE TABLE [dbo].[Branches] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] varchar(10)  NULL,
    [Name] varchar(100)  NULL
);
GO

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] char(3)  NULL,
    [Name] varchar(100)  NULL,
    [StateId] int  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Type] int  NOT NULL,
    [Gender] int  NOT NULL,
    [Department] int  NOT NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] varchar(10)  NULL,
    [Name] varchar(100)  NULL
);
GO

-- Creating table 'Genders'
CREATE TABLE [dbo].[Genders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] char(2)  NULL,
    [Name] varchar(100)  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderDate] varchar(200)  NULL,
    [Quantity] int  NOT NULL,
    [Price] int  NOT NULL,
    [Total] int  NOT NULL,
    [ProductId] int  NOT NULL,
    [CustomerId] int  NOT NULL
);
GO

-- Creating table 'products'
CREATE TABLE [dbo].[products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(200)  NULL,
    [price] int  NULL
);
GO

-- Creating table 'States'
CREATE TABLE [dbo].[States] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] char(2)  NULL,
    [Name] varchar(100)  NULL
);
GO

-- Creating table 'Types'
CREATE TABLE [dbo].[Types] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] char(3)  NULL,
    [Name] varchar(100)  NULL
);
GO

-- Creating table 'users'
CREATE TABLE [dbo].[users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(200)  NULL,
    [Password] varchar(200)  NULL,
    [Email] varchar(200)  NULL,
    [PhoneNumber] varchar(200)  NULL
);
GO

-- Creating table 'Order1'
CREATE TABLE [dbo].[Order1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderDate] varchar(200)  NULL,
    [Quantity] int  NOT NULL,
    [Price] int  NOT NULL,
    [Total] int  NOT NULL,
    [ProductId] int  NOT NULL,
    [CustomerId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Areas'
ALTER TABLE [dbo].[Areas]
ADD CONSTRAINT [PK_Areas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Branches'
ALTER TABLE [dbo].[Branches]
ADD CONSTRAINT [PK_Branches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Genders'
ALTER TABLE [dbo].[Genders]
ADD CONSTRAINT [PK_Genders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [PK_products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'States'
ALTER TABLE [dbo].[States]
ADD CONSTRAINT [PK_States]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Types'
ALTER TABLE [dbo].[Types]
ADD CONSTRAINT [PK_Types]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [PK_users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Order1'
ALTER TABLE [dbo].[Order1]
ADD CONSTRAINT [PK_Order1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK__Address__Custome__4BAC3F29]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Address__Custome__4BAC3F29'
CREATE INDEX [IX_FK__Address__Custome__4BAC3F29]
ON [dbo].[Addresses]
    ([CustomerId]);
GO

-- Creating foreign key on [CityId] in table 'Areas'
ALTER TABLE [dbo].[Areas]
ADD CONSTRAINT [FK__Area__CityId__3C69FB99]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[Cities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Area__CityId__3C69FB99'
CREATE INDEX [IX_FK__Area__CityId__3C69FB99]
ON [dbo].[Areas]
    ([CityId]);
GO

-- Creating foreign key on [StateId] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [FK__City__StateId__398D8EEE]
    FOREIGN KEY ([StateId])
    REFERENCES [dbo].[States]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__City__StateId__398D8EEE'
CREATE INDEX [IX_FK__City__StateId__398D8EEE]
ON [dbo].[Cities]
    ([StateId]);
GO

-- Creating foreign key on [ProductId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK__Orders__ProductI__5EBF139D]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Orders__ProductI__5EBF139D'
CREATE INDEX [IX_FK__Orders__ProductI__5EBF139D]
ON [dbo].[Orders]
    ([ProductId]);
GO

-- Creating foreign key on [CustomerId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_CustomerOrder]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerOrder'
CREATE INDEX [IX_FK_CustomerOrder]
ON [dbo].[Orders]
    ([CustomerId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------