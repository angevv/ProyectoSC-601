USE [master]
GO
/****** Object:  Database [ImportadoraMoyaUlate]    Script Date: 10/29/2023 2:53:52 PM ******/
CREATE DATABASE [ImportadoraMoyaUlate]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ImportadoraMoyaUlate', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ImportadoraMoyaUlate.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ImportadoraMoyaUlate_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ImportadoraMoyaUlate_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[Clientes]    Script Date: 10/29/2023 2:53:52 PM ******/
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
/****** Object:  Table [dbo].[Estado]    Script Date: 10/29/2023 2:53:52 PM ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 10/29/2023 2:53:52 PM ******/
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
/****** Object:  Table [dbo].[Ubicaciones]    Script Date: 10/29/2023 2:53:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ubicaciones](
	[ID_Ubicacion] [bigint] IDENTITY(1,1) NOT NULL,
	[Tipo_Ubicacion] [varchar](20) NOT NULL,
	[Ubicacion] [varchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Ubicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
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
/****** Object:  StoredProcedure [dbo].[IniciarSesionSP]    Script Date: 10/29/2023 2:53:52 PM ******/
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
/****** Object:  StoredProcedure [dbo].[RecuperarCuentaClienteSP]    Script Date: 10/29/2023 2:53:52 PM ******/
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

END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarClienteSP]    Script Date: 10/29/2023 2:53:52 PM ******/
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
USE [master]
GO
ALTER DATABASE [ImportadoraMoyaUlate] SET  READ_WRITE 
GO
