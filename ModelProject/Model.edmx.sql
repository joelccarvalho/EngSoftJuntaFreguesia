
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/18/2018 21:14:53
-- Generated from EDMX file: D:\Aulas\Ano (2018-2019)\Engenharia de Software\Avaliação\EngSoftJuntaFreguesia\EngSoftJuntaFreguesia\ModelProject\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProjectDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FKInformacoe356796]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InformacoesUteis] DROP CONSTRAINT [FK_FKInformacoe356796];
GO
IF OBJECT_ID(N'[dbo].[FK_FKInformacoe619905]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InformacoesUteis] DROP CONSTRAINT [FK_FKInformacoe619905];
GO
IF OBJECT_ID(N'[dbo].[FK_FKOcorrencia213251]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ocorrencias] DROP CONSTRAINT [FK_FKOcorrencia213251];
GO
IF OBJECT_ID(N'[dbo].[FK_FKOcorrencia933020]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ocorrencias] DROP CONSTRAINT [FK_FKOcorrencia933020];
GO
IF OBJECT_ID(N'[dbo].[FK_FKTipoOcorre404229]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TipoOcorrencias] DROP CONSTRAINT [FK_FKTipoOcorre404229];
GO
IF OBJECT_ID(N'[dbo].[FK_FKUtilizador424118]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Utilizadores] DROP CONSTRAINT [FK_FKUtilizador424118];
GO
IF OBJECT_ID(N'[dbo].[FK_FKUtilizador949029]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Utilizadores] DROP CONSTRAINT [FK_FKUtilizador949029];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CodigoPostal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CodigoPostal];
GO
IF OBJECT_ID(N'[dbo].[InformacoesUteis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InformacoesUteis];
GO
IF OBJECT_ID(N'[dbo].[Ocorrencias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ocorrencias];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TipoOcorrencias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoOcorrencias];
GO
IF OBJECT_ID(N'[dbo].[TipoUtilizador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoUtilizador];
GO
IF OBJECT_ID(N'[dbo].[Utilizadores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Utilizadores];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CodigoPostal'
CREATE TABLE [dbo].[CodigoPostal] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Codigo] varchar(255)  NOT NULL,
    [Localidade] varchar(255)  NOT NULL
);
GO

-- Creating table 'InformacoesUteis'
CREATE TABLE [dbo].[InformacoesUteis] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Assunto] varchar(255)  NOT NULL,
    [Descricao] varchar(255)  NOT NULL,
    [Destinatario] int  NULL,
    [IdCodigoPostal] int  NULL
);
GO

-- Creating table 'Ocorrencias'
CREATE TABLE [dbo].[Ocorrencias] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IdUtilizador] int  NOT NULL,
    [IdOcorrencias] int  NOT NULL,
    [Descricao] varchar(255)  NOT NULL,
    [Anexos] varchar(255)  NULL
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

-- Creating table 'TipoOcorrencias'
CREATE TABLE [dbo].[TipoOcorrencias] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Designacao] varchar(255)  NOT NULL,
    [PermissoesUtilizador] int  NULL
);
GO

-- Creating table 'TipoUtilizador'
CREATE TABLE [dbo].[TipoUtilizador] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Tipo] varchar(255)  NOT NULL,
    [RoleID] varchar(255)  NOT NULL
);
GO

-- Creating table 'Utilizadores'
CREATE TABLE [dbo].[Utilizadores] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(255)  NOT NULL,
    [NumCC] int  NOT NULL,
    [NumEleitor] int  NULL,
    [Morada] varchar(255)  NOT NULL,
    [IdCodigoPostal] int  NULL,
    [Email] varchar(255)  NOT NULL,
    [NomeUtilizador] varchar(255)  NOT NULL,
    [Password] varchar(255)  NULL,
    [Estado] tinyint  NOT NULL,
    [Tipo] int  NULL,
    [UserID] varchar(255)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'CodigoPostal'
ALTER TABLE [dbo].[CodigoPostal]
ADD CONSTRAINT [PK_CodigoPostal]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'InformacoesUteis'
ALTER TABLE [dbo].[InformacoesUteis]
ADD CONSTRAINT [PK_InformacoesUteis]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Ocorrencias'
ALTER TABLE [dbo].[Ocorrencias]
ADD CONSTRAINT [PK_Ocorrencias]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID] in table 'TipoOcorrencias'
ALTER TABLE [dbo].[TipoOcorrencias]
ADD CONSTRAINT [PK_TipoOcorrencias]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TipoUtilizador'
ALTER TABLE [dbo].[TipoUtilizador]
ADD CONSTRAINT [PK_TipoUtilizador]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Utilizadores'
ALTER TABLE [dbo].[Utilizadores]
ADD CONSTRAINT [PK_Utilizadores]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdCodigoPostal] in table 'InformacoesUteis'
ALTER TABLE [dbo].[InformacoesUteis]
ADD CONSTRAINT [FK_FKInformacoe356796]
    FOREIGN KEY ([IdCodigoPostal])
    REFERENCES [dbo].[CodigoPostal]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKInformacoe356796'
CREATE INDEX [IX_FK_FKInformacoe356796]
ON [dbo].[InformacoesUteis]
    ([IdCodigoPostal]);
GO

-- Creating foreign key on [IdCodigoPostal] in table 'Utilizadores'
ALTER TABLE [dbo].[Utilizadores]
ADD CONSTRAINT [FK_FKUtilizador949029]
    FOREIGN KEY ([IdCodigoPostal])
    REFERENCES [dbo].[CodigoPostal]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKUtilizador949029'
CREATE INDEX [IX_FK_FKUtilizador949029]
ON [dbo].[Utilizadores]
    ([IdCodigoPostal]);
GO

-- Creating foreign key on [Destinatario] in table 'InformacoesUteis'
ALTER TABLE [dbo].[InformacoesUteis]
ADD CONSTRAINT [FK_FKInformacoe619905]
    FOREIGN KEY ([Destinatario])
    REFERENCES [dbo].[Utilizadores]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKInformacoe619905'
CREATE INDEX [IX_FK_FKInformacoe619905]
ON [dbo].[InformacoesUteis]
    ([Destinatario]);
GO

-- Creating foreign key on [IdOcorrencias] in table 'Ocorrencias'
ALTER TABLE [dbo].[Ocorrencias]
ADD CONSTRAINT [FK_FKOcorrencia213251]
    FOREIGN KEY ([IdOcorrencias])
    REFERENCES [dbo].[TipoOcorrencias]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKOcorrencia213251'
CREATE INDEX [IX_FK_FKOcorrencia213251]
ON [dbo].[Ocorrencias]
    ([IdOcorrencias]);
GO

-- Creating foreign key on [IdUtilizador] in table 'Ocorrencias'
ALTER TABLE [dbo].[Ocorrencias]
ADD CONSTRAINT [FK_FKOcorrencia933020]
    FOREIGN KEY ([IdUtilizador])
    REFERENCES [dbo].[Utilizadores]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKOcorrencia933020'
CREATE INDEX [IX_FK_FKOcorrencia933020]
ON [dbo].[Ocorrencias]
    ([IdUtilizador]);
GO

-- Creating foreign key on [PermissoesUtilizador] in table 'TipoOcorrencias'
ALTER TABLE [dbo].[TipoOcorrencias]
ADD CONSTRAINT [FK_FKTipoOcorre404229]
    FOREIGN KEY ([PermissoesUtilizador])
    REFERENCES [dbo].[TipoUtilizador]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKTipoOcorre404229'
CREATE INDEX [IX_FK_FKTipoOcorre404229]
ON [dbo].[TipoOcorrencias]
    ([PermissoesUtilizador]);
GO

-- Creating foreign key on [Tipo] in table 'Utilizadores'
ALTER TABLE [dbo].[Utilizadores]
ADD CONSTRAINT [FK_FKUtilizador424118]
    FOREIGN KEY ([Tipo])
    REFERENCES [dbo].[TipoUtilizador]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKUtilizador424118'
CREATE INDEX [IX_FK_FKUtilizador424118]
ON [dbo].[Utilizadores]
    ([Tipo]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------