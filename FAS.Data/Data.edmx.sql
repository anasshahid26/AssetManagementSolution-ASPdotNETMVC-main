
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/17/2017 19:15:07
-- Generated from EDMX file: C:\Users\Shahraiz\Documents\GitHub\Fixed-Asset---Intelli\FixedAssetSolutions\FAS.Data\Data.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MatrixFAS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AssetCompany_Country]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssetCompanies] DROP CONSTRAINT [FK_AssetCompany_Country];
GO
IF OBJECT_ID(N'[dbo].[FK_AssetLocation_AssetCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssetLocations] DROP CONSTRAINT [FK_AssetLocation_AssetCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_AssetLocation_Country]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssetLocations] DROP CONSTRAINT [FK_AssetLocation_Country];
GO
IF OBJECT_ID(N'[dbo].[FK_AssetSection_AssetCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssetSections] DROP CONSTRAINT [FK_AssetSection_AssetCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_AssetSection_AssetLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssetSections] DROP CONSTRAINT [FK_AssetSection_AssetLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_UserCompany_AssetCompanies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserCompany] DROP CONSTRAINT [FK_UserCompany_AssetCompanies];
GO
IF OBJECT_ID(N'[dbo].[FK_UserCompany_AssetLocations]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserCompany] DROP CONSTRAINT [FK_UserCompany_AssetLocations];
GO
IF OBJECT_ID(N'[dbo].[FK_UserCompany_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserCompany] DROP CONSTRAINT [FK_UserCompany_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_AssetRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRole_AssetRole];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRole_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRoles_AssetPermissions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRoles_AssetPermissions];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Administrators]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Administrators];
GO
IF OBJECT_ID(N'[dbo].[AssetCompanies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AssetCompanies];
GO
IF OBJECT_ID(N'[dbo].[AssetLocations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AssetLocations];
GO
IF OBJECT_ID(N'[dbo].[AssetPermissions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AssetPermissions];
GO
IF OBJECT_ID(N'[dbo].[AssetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AssetRoles];
GO
IF OBJECT_ID(N'[dbo].[AssetSections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AssetSections];
GO
IF OBJECT_ID(N'[dbo].[Countries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Countries];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[UserCompany]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserCompany];
GO
IF OBJECT_ID(N'[dbo].[UserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRoles];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AssetCompanies'
CREATE TABLE [dbo].[AssetCompanies] (
    [CompanyID] int IDENTITY(1,1) NOT NULL,
    [CompanyCode] varchar(50)  NOT NULL,
    [CompanyName] varchar(50)  NOT NULL,
    [MultipleDivision] varchar(50)  NULL,
    [Address] varchar(50)  NULL,
    [Address2] varchar(50)  NULL,
    [Address3] varchar(50)  NULL,
    [City] varchar(50)  NULL,
    [State_Province] varchar(50)  NULL,
    [Zip_PostalCode] varchar(50)  NULL,
    [Country] varchar(50)  NULL,
    [ContactName] varchar(50)  NULL,
    [ContactPhone] varchar(50)  NULL,
    [ContactFax] varchar(50)  NULL,
    [ContactEmail] varchar(50)  NULL,
    [Logo] varchar(max)  NULL,
    [Active] bit  NOT NULL,
    [CreatedOn] datetime  NULL,
    [CreatedBy] varchar(50)  NULL,
    [ModifiedOn] datetime  NULL,
    [ModifiedBy] varchar(50)  NULL,
    [MachineCreated] varchar(50)  NULL,
    [AssetDisposal] varchar(50)  NULL,
    [AssetMovement] varchar(50)  NULL,
    [CountryID] int  NOT NULL
);
GO

-- Creating table 'AssetLocations'
CREATE TABLE [dbo].[AssetLocations] (
    [LocationID] int IDENTITY(1,1) NOT NULL,
    [CompanyID] int  NOT NULL,
    [LocationCode] varchar(50)  NOT NULL,
    [LocationName] varchar(50)  NOT NULL,
    [Address] varchar(50)  NULL,
    [Address2] varchar(50)  NULL,
    [Address3] varchar(50)  NULL,
    [City] varchar(50)  NOT NULL,
    [State_Province] varchar(50)  NULL,
    [Zip_PostalCode] varchar(50)  NULL,
    [Country] varchar(50)  NOT NULL,
    [ContactName] varchar(50)  NULL,
    [ContactPhone] varchar(50)  NULL,
    [ContactFax] varchar(50)  NULL,
    [ContactEmail] varchar(50)  NOT NULL,
    [Logo] varchar(max)  NULL,
    [Active] bit  NOT NULL,
    [CreatedOn] datetime  NULL,
    [CreatedBy] varchar(50)  NULL,
    [ModifiedOn] datetime  NULL,
    [ModifiedBy] varchar(50)  NULL,
    [MachineCreated] varchar(50)  NULL,
    [AssetDisposal] varchar(50)  NULL,
    [AssetMovement] varchar(50)  NULL,
    [CountryID] int  NOT NULL
);
GO

-- Creating table 'AssetPermissions'
CREATE TABLE [dbo].[AssetPermissions] (
    [PermissionID] int IDENTITY(1,1) NOT NULL,
    [PermissionName] varchar(50)  NOT NULL,
    [Active] bit  NOT NULL,
    [CreatedOn] varchar(50)  NULL,
    [CreatedBy] varchar(50)  NULL,
    [ModifiedOn] varchar(50)  NULL,
    [ModifiedBy] varchar(50)  NULL,
    [MachineCreated] varchar(50)  NULL
);
GO

-- Creating table 'AssetRoles'
CREATE TABLE [dbo].[AssetRoles] (
    [RoleID] int IDENTITY(1,1) NOT NULL,
    [RoleName] varchar(50)  NOT NULL,
    [Active] bit  NOT NULL,
    [CreatedOn] varchar(50)  NULL,
    [CreatedBy] varchar(50)  NULL,
    [ModifiedOn] varchar(50)  NULL,
    [ModifiedBy] varchar(50)  NULL,
    [MachineCreated] varchar(50)  NULL
);
GO

-- Creating table 'AssetSections'
CREATE TABLE [dbo].[AssetSections] (
    [SectionID] int IDENTITY(1,1) NOT NULL,
    [CompanyID] int  NOT NULL,
    [LocationID] int  NOT NULL,
    [SectionCode] varchar(50)  NOT NULL,
    [SectionName] varchar(50)  NOT NULL,
    [Address] varchar(50)  NULL,
    [Address2] varchar(50)  NULL,
    [Address3] varchar(50)  NULL,
    [City] varchar(50)  NULL,
    [State_Province] varchar(50)  NULL,
    [Zip_PostalCode] varchar(50)  NULL,
    [Country] varchar(50)  NULL,
    [ContactName] varchar(50)  NULL,
    [ContactPhone] varchar(50)  NULL,
    [ContactFax] varchar(50)  NULL,
    [ContactEmail] varchar(50)  NULL,
    [Active] bit  NOT NULL,
    [CreatedOn] datetime  NULL,
    [CreatedBy] varchar(50)  NULL,
    [ModifiedOn] datetime  NULL,
    [ModifiedBy] varchar(50)  NULL,
    [MachineCreated] varchar(50)  NULL,
    [AssetDisposal] varchar(50)  NULL,
    [AssetMovement] varchar(50)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(50)  NOT NULL,
    [Password] varchar(50)  NOT NULL,
    [FirstName] varchar(50)  NULL,
    [LastName] varchar(50)  NULL,
    [Email] varchar(50)  NULL,
    [Language] varchar(50)  NULL,
    [Note] varchar(max)  NULL,
    [Active] bit  NOT NULL,
    [CreatedOn] datetime  NULL,
    [CreatedBy] varchar(50)  NULL,
    [ModifiedOn] datetime  NULL,
    [ModifiedBy] varchar(50)  NULL,
    [MachineCreated] varchar(50)  NULL,
    [AssetDisposal] varchar(50)  NULL,
    [AssetMovement] varchar(50)  NULL,
    [Description] varchar(50)  NULL,
    [Asset_Category] bit  NOT NULL,
    [Asset_Description] bit  NOT NULL,
    [Asset_Group] bit  NOT NULL,
    [BarcodeID] bit  NOT NULL,
    [Company_Name] bit  NOT NULL,
    [Floor] bit  NOT NULL,
    [Room_No] bit  NOT NULL,
    [Room_Type] bit  NOT NULL,
    [Section_Name] bit  NOT NULL,
    [Site_Name] bit  NOT NULL
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [UserRoleID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [RoleID] int  NOT NULL,
    [PermissionID] int  NOT NULL,
    [IsEdit] bit  NOT NULL,
    [IsView] bit  NOT NULL
);
GO

-- Creating table 'Countries'
CREATE TABLE [dbo].[Countries] (
    [CountryID] int IDENTITY(1,1) NOT NULL,
    [SortName] varchar(50)  NOT NULL,
    [Name] varchar(50)  NOT NULL
);
GO

-- Creating table 'Administrators'
CREATE TABLE [dbo].[Administrators] (
    [AdminID] int  NOT NULL,
    [UserName] varchar(50)  NOT NULL,
    [Password] varchar(50)  NOT NULL,
    [Email] varchar(50)  NULL,
    [Active] bit  NOT NULL,
    [CreatedOn] datetime  NULL,
    [CreatedBy] varchar(50)  NULL,
    [ModifiedOn] datetime  NULL,
    [ModifiedBy] varchar(50)  NULL,
    [MachineCreated] varchar(50)  NULL,
    [AssetDisposal] varchar(50)  NULL,
    [AssetMovement] varchar(50)  NULL
);
GO

-- Creating table 'UserCompanies'
CREATE TABLE [dbo].[UserCompanies] (
    [UserCompanyID] int  NOT NULL,
    [CompanyID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [LocationID] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CompanyID] in table 'AssetCompanies'
ALTER TABLE [dbo].[AssetCompanies]
ADD CONSTRAINT [PK_AssetCompanies]
    PRIMARY KEY CLUSTERED ([CompanyID] ASC);
GO

-- Creating primary key on [LocationID] in table 'AssetLocations'
ALTER TABLE [dbo].[AssetLocations]
ADD CONSTRAINT [PK_AssetLocations]
    PRIMARY KEY CLUSTERED ([LocationID] ASC);
GO

-- Creating primary key on [PermissionID] in table 'AssetPermissions'
ALTER TABLE [dbo].[AssetPermissions]
ADD CONSTRAINT [PK_AssetPermissions]
    PRIMARY KEY CLUSTERED ([PermissionID] ASC);
GO

-- Creating primary key on [RoleID] in table 'AssetRoles'
ALTER TABLE [dbo].[AssetRoles]
ADD CONSTRAINT [PK_AssetRoles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [SectionID] in table 'AssetSections'
ALTER TABLE [dbo].[AssetSections]
ADD CONSTRAINT [PK_AssetSections]
    PRIMARY KEY CLUSTERED ([SectionID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [UserRoleID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([UserRoleID] ASC);
GO

-- Creating primary key on [CountryID] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [PK_Countries]
    PRIMARY KEY CLUSTERED ([CountryID] ASC);
GO

-- Creating primary key on [AdminID] in table 'Administrators'
ALTER TABLE [dbo].[Administrators]
ADD CONSTRAINT [PK_Administrators]
    PRIMARY KEY CLUSTERED ([AdminID] ASC);
GO

-- Creating primary key on [UserCompanyID] in table 'UserCompanies'
ALTER TABLE [dbo].[UserCompanies]
ADD CONSTRAINT [PK_UserCompanies]
    PRIMARY KEY CLUSTERED ([UserCompanyID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CompanyID] in table 'AssetLocations'
ALTER TABLE [dbo].[AssetLocations]
ADD CONSTRAINT [FK_AssetLocation_AssetCompany]
    FOREIGN KEY ([CompanyID])
    REFERENCES [dbo].[AssetCompanies]
        ([CompanyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AssetLocation_AssetCompany'
CREATE INDEX [IX_FK_AssetLocation_AssetCompany]
ON [dbo].[AssetLocations]
    ([CompanyID]);
GO

-- Creating foreign key on [CompanyID] in table 'AssetSections'
ALTER TABLE [dbo].[AssetSections]
ADD CONSTRAINT [FK_AssetSection_AssetCompany]
    FOREIGN KEY ([CompanyID])
    REFERENCES [dbo].[AssetCompanies]
        ([CompanyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AssetSection_AssetCompany'
CREATE INDEX [IX_FK_AssetSection_AssetCompany]
ON [dbo].[AssetSections]
    ([CompanyID]);
GO

-- Creating foreign key on [LocationID] in table 'AssetSections'
ALTER TABLE [dbo].[AssetSections]
ADD CONSTRAINT [FK_AssetSection_AssetLocation]
    FOREIGN KEY ([LocationID])
    REFERENCES [dbo].[AssetLocations]
        ([LocationID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AssetSection_AssetLocation'
CREATE INDEX [IX_FK_AssetSection_AssetLocation]
ON [dbo].[AssetSections]
    ([LocationID]);
GO

-- Creating foreign key on [RoleID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRole_AssetRole]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[AssetRoles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_AssetRole'
CREATE INDEX [IX_FK_UserRole_AssetRole]
ON [dbo].[UserRoles]
    ([RoleID]);
GO

-- Creating foreign key on [UserID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRole_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_User'
CREATE INDEX [IX_FK_UserRole_User]
ON [dbo].[UserRoles]
    ([UserID]);
GO

-- Creating foreign key on [CountryID] in table 'AssetCompanies'
ALTER TABLE [dbo].[AssetCompanies]
ADD CONSTRAINT [FK_AssetCompany_Country]
    FOREIGN KEY ([CountryID])
    REFERENCES [dbo].[Countries]
        ([CountryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AssetCompany_Country'
CREATE INDEX [IX_FK_AssetCompany_Country]
ON [dbo].[AssetCompanies]
    ([CountryID]);
GO

-- Creating foreign key on [CountryID] in table 'AssetLocations'
ALTER TABLE [dbo].[AssetLocations]
ADD CONSTRAINT [FK_AssetLocation_Country]
    FOREIGN KEY ([CountryID])
    REFERENCES [dbo].[Countries]
        ([CountryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AssetLocation_Country'
CREATE INDEX [IX_FK_AssetLocation_Country]
ON [dbo].[AssetLocations]
    ([CountryID]);
GO

-- Creating foreign key on [PermissionID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRoles_AssetPermissions]
    FOREIGN KEY ([PermissionID])
    REFERENCES [dbo].[AssetPermissions]
        ([PermissionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRoles_AssetPermissions'
CREATE INDEX [IX_FK_UserRoles_AssetPermissions]
ON [dbo].[UserRoles]
    ([PermissionID]);
GO

-- Creating foreign key on [CompanyID] in table 'UserCompanies'
ALTER TABLE [dbo].[UserCompanies]
ADD CONSTRAINT [FK_UserCompany_AssetCompanies]
    FOREIGN KEY ([CompanyID])
    REFERENCES [dbo].[AssetCompanies]
        ([CompanyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCompany_AssetCompanies'
CREATE INDEX [IX_FK_UserCompany_AssetCompanies]
ON [dbo].[UserCompanies]
    ([CompanyID]);
GO

-- Creating foreign key on [UserID] in table 'UserCompanies'
ALTER TABLE [dbo].[UserCompanies]
ADD CONSTRAINT [FK_UserCompany_Users]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCompany_Users'
CREATE INDEX [IX_FK_UserCompany_Users]
ON [dbo].[UserCompanies]
    ([UserID]);
GO

-- Creating foreign key on [LocationID] in table 'UserCompanies'
ALTER TABLE [dbo].[UserCompanies]
ADD CONSTRAINT [FK_UserCompany_AssetLocations]
    FOREIGN KEY ([LocationID])
    REFERENCES [dbo].[AssetLocations]
        ([LocationID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCompany_AssetLocations'
CREATE INDEX [IX_FK_UserCompany_AssetLocations]
ON [dbo].[UserCompanies]
    ([LocationID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------