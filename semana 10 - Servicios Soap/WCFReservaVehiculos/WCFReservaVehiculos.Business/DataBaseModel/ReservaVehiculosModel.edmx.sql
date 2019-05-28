
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/07/2016 03:57:05
-- Generated from EDMX file: C:\Users\Ruben\Google Drive\IAEW\IAEW_2016\Temp\TPIntegrador\WCFReservaVehiculos.Business\DataBaseModel\ReservaVehiculosModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ReservaVehiculosDataBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CiudadEntityVehiculoPorCiudadEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VehiculoPorCiudad] DROP CONSTRAINT [FK_CiudadEntityVehiculoPorCiudadEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_PaisEntityCiudadEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ciudad] DROP CONSTRAINT [FK_PaisEntityCiudadEntity];
GO
IF OBJECT_ID(N'[ReservaVehiculosDataBaseModelStoreContainer].[FK_TransaccionEntityUsuarioEntity]', 'F') IS NOT NULL
    ALTER TABLE [ReservaVehiculosDataBaseModelStoreContainer].[Transaccion] DROP CONSTRAINT [FK_TransaccionEntityUsuarioEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_VehiculoPorCiudadEntityReservaEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reserva] DROP CONSTRAINT [FK_VehiculoPorCiudadEntityReservaEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_VehiculoPorCiudadEntityVehiculoEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VehiculoPorCiudad] DROP CONSTRAINT [FK_VehiculoPorCiudadEntityVehiculoEntity];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Ciudad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ciudad];
GO
IF OBJECT_ID(N'[dbo].[Pais]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pais];
GO
IF OBJECT_ID(N'[dbo].[Reserva]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reserva];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO
IF OBJECT_ID(N'[dbo].[Vehiculo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehiculo];
GO
IF OBJECT_ID(N'[dbo].[VehiculoPorCiudad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VehiculoPorCiudad];
GO
IF OBJECT_ID(N'[ReservaVehiculosDataBaseModelStoreContainer].[Transaccion]', 'U') IS NOT NULL
    DROP TABLE [ReservaVehiculosDataBaseModelStoreContainer].[Transaccion];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Vehiculo'
CREATE TABLE [dbo].[Vehiculo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Modelo] nvarchar(max)  NOT NULL,
    [Marca] nvarchar(max)  NOT NULL,
    [Puntaje] nvarchar(max)  NOT NULL,
    [PrecioPorDia] decimal(18,0)  NOT NULL,
    [TieneDireccion] bit  NOT NULL,
    [TieneAireAcon] bit  NOT NULL,
    [CantidadPuertas] int  NOT NULL,
    [TipoCambio] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Reserva'
CREATE TABLE [dbo].[Reserva] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CodigoReserva] nvarchar(max)  NOT NULL,
    [FechaReserva] datetime  NOT NULL,
    [UsuarioReserva] nvarchar(max)  NOT NULL,
    [TotalReserva] decimal(18,0)  NOT NULL,
    [ApellidoNombreCliente] nvarchar(max)  NOT NULL,
    [NroDocumentoCliente] nvarchar(max)  NOT NULL,
    [LugarRetiro] nvarchar(max)  NOT NULL,
    [LugarDevolucion] nvarchar(max)  NOT NULL,
    [FechaHoraRetiro] datetime  NOT NULL,
    [FechaHoraDevolucion] datetime  NOT NULL,
    [Estado] int  NOT NULL,
    [FechaCancelacion] datetime  NULL,
    [UsuarioCancelacion] nvarchar(max)  NULL,
    [VehiculoPorCiudadId] int  NOT NULL
);
GO

-- Creating table 'Ciudad'
CREATE TABLE [dbo].[Ciudad] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [PaisId] int  NOT NULL
);
GO

-- Creating table 'Pais'
CREATE TABLE [dbo].[Pais] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Transaccion'
CREATE TABLE [dbo].[Transaccion] (
    [Id] nvarchar(max)  NOT NULL,
    [Request] nvarchar(max)  NOT NULL,
    [Response] nvarchar(max)  NOT NULL,
    [UsuarioId] int  NOT NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'VehiculoPorCiudad'
CREATE TABLE [dbo].[VehiculoPorCiudad] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CantidadDisponible] int  NOT NULL,
    [VehiculoId] int  NOT NULL,
    [CiudadId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Vehiculo'
ALTER TABLE [dbo].[Vehiculo]
ADD CONSTRAINT [PK_Vehiculo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reserva'
ALTER TABLE [dbo].[Reserva]
ADD CONSTRAINT [PK_Reserva]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ciudad'
ALTER TABLE [dbo].[Ciudad]
ADD CONSTRAINT [PK_Ciudad]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pais'
ALTER TABLE [dbo].[Pais]
ADD CONSTRAINT [PK_Pais]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Transaccion'
ALTER TABLE [dbo].[Transaccion]
ADD CONSTRAINT [PK_Transaccion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VehiculoPorCiudad'
ALTER TABLE [dbo].[VehiculoPorCiudad]
ADD CONSTRAINT [PK_VehiculoPorCiudad]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PaisId] in table 'Ciudad'
ALTER TABLE [dbo].[Ciudad]
ADD CONSTRAINT [FK_PaisEntityCiudadEntity]
    FOREIGN KEY ([PaisId])
    REFERENCES [dbo].[Pais]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaisEntityCiudadEntity'
CREATE INDEX [IX_FK_PaisEntityCiudadEntity]
ON [dbo].[Ciudad]
    ([PaisId]);
GO

-- Creating foreign key on [UsuarioId] in table 'Transaccion'
ALTER TABLE [dbo].[Transaccion]
ADD CONSTRAINT [FK_TransaccionEntityUsuarioEntity]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[Usuario]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransaccionEntityUsuarioEntity'
CREATE INDEX [IX_FK_TransaccionEntityUsuarioEntity]
ON [dbo].[Transaccion]
    ([UsuarioId]);
GO

-- Creating foreign key on [CiudadId] in table 'VehiculoPorCiudad'
ALTER TABLE [dbo].[VehiculoPorCiudad]
ADD CONSTRAINT [FK_CiudadEntityVehiculoPorCiudadEntity]
    FOREIGN KEY ([CiudadId])
    REFERENCES [dbo].[Ciudad]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CiudadEntityVehiculoPorCiudadEntity'
CREATE INDEX [IX_FK_CiudadEntityVehiculoPorCiudadEntity]
ON [dbo].[VehiculoPorCiudad]
    ([CiudadId]);
GO

-- Creating foreign key on [VehiculoId] in table 'VehiculoPorCiudad'
ALTER TABLE [dbo].[VehiculoPorCiudad]
ADD CONSTRAINT [FK_VehiculoPorCiudadEntityVehiculoEntity]
    FOREIGN KEY ([VehiculoId])
    REFERENCES [dbo].[Vehiculo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehiculoPorCiudadEntityVehiculoEntity'
CREATE INDEX [IX_FK_VehiculoPorCiudadEntityVehiculoEntity]
ON [dbo].[VehiculoPorCiudad]
    ([VehiculoId]);
GO

-- Creating foreign key on [VehiculoPorCiudadId] in table 'Reserva'
ALTER TABLE [dbo].[Reserva]
ADD CONSTRAINT [FK_VehiculoPorCiudadEntityReservaEntity]
    FOREIGN KEY ([VehiculoPorCiudadId])
    REFERENCES [dbo].[VehiculoPorCiudad]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehiculoPorCiudadEntityReservaEntity'
CREATE INDEX [IX_FK_VehiculoPorCiudadEntityReservaEntity]
ON [dbo].[Reserva]
    ([VehiculoPorCiudadId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------