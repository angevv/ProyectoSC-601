/****** Object:  Database [ImportadoraMoyaUlate]    Script Date: 11/11/2023 8:32:27 PM ******/
CREATE DATABASE [ImportadoraMoyaUlate]
 CONTAINMENT = NONE
 ON  PRIMARY 
 /*******IMPORTANTE*******/ /*******IMPORTANTE*******/ /*******IMPORTANTE*******/ /*******IMPORTANTE*******/ /*******IMPORTANTE*******/ /*******IMPORTANTE*******/ /*******IMPORTANTE*******/
 /*En caso de la version de SQL sea la express cambiar "MSSQLSERVER" a "MSSQLEXPRESS"*/
( NAME = N'ImportadoraMoyaUlate', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ImportadoraMoyaUlate.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ImportadoraMoyaUlate_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ImportadoraMoyaUlate_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ImportadoraMoyaUlate].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET ARITHABORT OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET  MULTI_USER 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET QUERY_STORE = ON
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ImportadoraMoyaUlate]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 11/6/2023 9:10:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ID_Cliente] [bigint] IDENTITY(1,1) NOT NULL,
	[Ced_Cliente] [varchar](25) NOT NULL,
	[Nombre_Cliente] [varchar](60) NOT NULL,
	[Apellido_Cliente] [varchar](70) NOT NULL,
	[Correo_Cliente] [varchar](100) NOT NULL,
	[Contrasenna_Cliente] [varchar](50) NOT NULL,
	[Direccion_Cliente] [varchar](500) NULL,
	[Tel_Cliente] [varchar](20) NULL,
	[Est_Cliente] [int] NOT NULL,
	[Rol_Cliente] [int] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ID_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_Ced_Cliente] UNIQUE NONCLUSTERED 
(
	[Ced_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 11/6/2023 9:10:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[ID_Estado] [int] NOT NULL,
	[Tipo_Estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[ID_Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/6/2023 9:10:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID_Rol] [int] NOT NULL,
	[Nombre_Rol] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Tbl_Rol] PRIMARY KEY CLUSTERED 
(
	[ID_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Llaves Foráneas ******/
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Estado] FOREIGN KEY([Est_Cliente])
REFERENCES [dbo].[Estado] ([ID_Estado])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Estado]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Roles] FOREIGN KEY([Rol_Cliente])
REFERENCES [dbo].[Roles] ([ID_Rol])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Roles]
GO


/****** Registros Tabla Rol ******/
INSERT [dbo].Roles ([ID_Rol], Nombre_Rol) VALUES (1, N'Administrador')
GO
INSERT [dbo].Roles ([ID_Rol], Nombre_Rol) VALUES (2, N'Usuario')
GO

/****** Registros Tabla Estado ******/
INSERT [dbo].Estado([ID_Estado], Tipo_Estado) VALUES (0, N'Inactivo')
GO
INSERT [dbo].Estado([ID_Estado], Tipo_Estado) VALUES (1, N'Activo')
GO


/****** PARTE CLIENTES ******/

/****** Procedimiento Almacenado para Iniciar Sesión Usuarios ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IniciarSesionSP]
	@Correo         varchar(100),
    @Contrasenna    varchar(50)
AS
BEGIN
	
	SELECT *
	From Clientes
	  WHERE Correo_Cliente = @Correo
	  AND   Contrasenna_Cliente = @Contrasenna
	  AND	Est_Cliente = 1
END
GO

/****** Procedimiento Almacenado para Recuperar Cuenta Usuarios ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarCuentaClienteSP]
	@Identificacion varchar(25)
AS
BEGIN
	
	SELECT Nombre_Cliente,
			Apellido_Cliente,
		   Correo_Cliente,
		   Contrasenna_Cliente
	  FROM dbo.Clientes
	  WHERE Ced_Cliente = @Identificacion
	  AND	Est_Cliente = 1

END
GO

/****** Procedimiento Almacenado para Registrar Cuenta Usuarios ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[RegistrarClienteSP]
	@Identificacion varchar(25),
    @Nombre         varchar(60),
	@Apellido         varchar(70),
    @Correo         varchar(100),
    @Contrasenna    varchar(50),
	@Direccion   varchar(500),
	@Telefono    varchar(20)
AS
BEGIN

	INSERT INTO dbo.Clientes (Ced_Cliente,Nombre_Cliente,Apellido_Cliente,Correo_Cliente,Contrasenna_Cliente,Direccion_Cliente,Tel_Cliente,Est_Cliente,Rol_Cliente)
    VALUES (@Identificacion,@Nombre,@Apellido,@Correo,@Contrasenna,@Direccion,@Telefono,1,2)

END
GO

/****** Procedimiento Almacenado para Actualizar Datos de la Cuenta Usuarios ******/
CREATE PROCEDURE [dbo].[ActualizarCuentaClienteSP]
	@Identificacion varchar(25),
    @Nombre         varchar(60),
	@Apellido         varchar(70),
    @Correo         varchar(100),
	@Direccion   varchar(500),
	@Telefono    varchar(20),
	@CodigoCliente	BIGINT
AS
BEGIN
	
	UPDATE	dbo.Clientes
	SET		Ced_Cliente = @Identificacion,
			Nombre_Cliente = @Nombre,
			Apellido_Cliente = @Apellido,
			Correo_Cliente = @Correo,
			Direccion_Cliente=@Direccion,
			Tel_Cliente=@Telefono
	WHERE	ID_Cliente = @CodigoCliente

END
GO

/****** Procedimiento Almacenado para Inactivar al Cliente ******/
CREATE PROCEDURE [dbo].InactivarClienteSP
	@CodigoCliente	BIGINT
AS
BEGIN
	
	UPDATE	dbo.Clientes
	SET		Est_Cliente=0
	WHERE	ID_Cliente = @CodigoCliente

END
GO

/****** Procedimiento Almacenado para Cambiar Estado al Cliente ******/
CREATE PROCEDURE [dbo].[ActualizarEstadoClienteSP]
    @ID_Cliente BIGINT
AS
BEGIN
    UPDATE Clientes
    SET Est_Cliente = (CASE WHEN Est_Cliente = 1 THEN 0 ELSE 1 END)
    WHERE ID_Cliente = @ID_Cliente;
END;
GO

/****** TABLAS EMPRESA Y PROVEEDORES ******/
/*Creacion de la tabla Empresa*/

USE [ImportadoraMoyaUlate]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Empresa](
	[ID_Empresa] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre_empresa] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[ID_Empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/*Insertar empresas de ejemplo*/

INSERT INTO [dbo].[Empresa] ([Nombre_empresa])
VALUES 
    ('Escoja una opcion'),
    ('Empresa 1.'),
    ('Empresa 2');



/*Creacionde la tabla Proveedores*/
USE [ImportadoraMoyaUlate]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Proveedores](
	[ID_Proveedor] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre_Proveedor] [varchar](255) NOT NULL,
	[Apellido_Proveedor] [varchar](255) NOT NULL,
	[Cedula_Proveedor] [varchar](15) NOT NULL,
	[Direccion_Exacta] [varchar](255) NOT NULL,
	[Estado_Proveedor] [int] NOT NULL,
	[Empresa] [bigint] NOT NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[ID_Proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD  CONSTRAINT [FK_Proveedores_Empresa] FOREIGN KEY([Empresa])
REFERENCES [dbo].[Empresa] ([ID_Empresa])
GO

ALTER TABLE [dbo].[Proveedores] CHECK CONSTRAINT [FK_Proveedores_Empresa]
GO

ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD  CONSTRAINT [FK_Proveedores_Estado] FOREIGN KEY([Estado_Proveedor])
REFERENCES [dbo].[Estado] ([ID_Estado])
GO

ALTER TABLE [dbo].[Proveedores] CHECK CONSTRAINT [FK_Proveedores_Estado]
GO

/*Procedimiento almacenado para registrar proveedores*/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegistrarProveedorSP]
    @Nombre_Proveedor varchar(60),
    @Apellido_Proveedor varchar(70),
    @Cedula_Proveedor varchar(25),
    @Direccion_Exacta varchar(255),
    @Estado_Proveedor int,
    @Empresa bigint
AS
BEGIN
    INSERT INTO [dbo].[Proveedores] (
        [Nombre_Proveedor],
        [Apellido_Proveedor],
        [Cedula_Proveedor],
        [Direccion_Exacta],
        [Estado_Proveedor],
        [Empresa]
    )
    VALUES (
		@Nombre_Proveedor,
        @Apellido_Proveedor,
        @Cedula_Proveedor,
        @Direccion_Exacta,
        1,
        @Empresa
    );
END;
GO


/*Procedimiento almacenado para actualizar el estado de proveedor de activo a inactivo o viceversa*/

USE [ImportadoraMoyaUlate]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActualizarEstadoProveedorSP]
    @ID_Proveedor BIGINT
AS
BEGIN
    UPDATE Proveedores
    SET Estado_Proveedor = (CASE WHEN Estado_Proveedor = 1 THEN 0 ELSE 1 END)
    WHERE ID_Proveedor = @ID_Proveedor;
END;
GO


/*Procedimiento almacenado para actualizar la informcion del proveedor que se haya modificado/actualizado*/

USE [ImportadoraMoyaUlate]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActualizarProveedorSP]
    @ID_Proveedor BIGINT,
    @Nombre_Proveedor VARCHAR(255),
    @Apellido_Proveedor VARCHAR(255),
    @Cedula_Proveedor VARCHAR(15),
    @Direccion_Exacta VARCHAR(255),
    @Empresa BIGINT
AS
BEGIN
    UPDATE dbo.Proveedores
    SET
        Nombre_Proveedor = @Nombre_Proveedor,
        Apellido_Proveedor = @Apellido_Proveedor,
        Cedula_Proveedor = @Cedula_Proveedor,
        Direccion_Exacta = @Direccion_Exacta,
        Empresa = @Empresa
    WHERE ID_Proveedor = @ID_Proveedor;
END;
GO


/*Procedimiento almacenado para eliminar permanentemente un proveedor del sistema*/

USE [ImportadoraMoyaUlate]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarProveedorSP]
    @ID_Proveedor bigint
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.Proveedores WHERE ID_Proveedor = @ID_Proveedor;
END
GO

/************* INVENTARIO *************/

CREATE TABLE [dbo].[Categorias](
	[ID_Categoria] [int] NOT NULL,
	[Nombre] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Tbl_Categoria] PRIMARY KEY CLUSTERED 
(
	[ID_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[Categorias] ([ID_Categoria], [Nombre])
VALUES 
    (1,'Hombre'),
    (2,'Mujer'),
    (3,'Niños');

CREATE TABLE [dbo].[Producto](
	[ID_Producto] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_Categoria] [int] NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Imagen] [varchar](250) NOT NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ID_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([ID_Categoria])
REFERENCES [dbo].[Categorias] ([ID_Categoria])
GO

ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Estado] FOREIGN KEY([Estado])
REFERENCES [dbo].[Estado] ([ID_Estado])
GO

