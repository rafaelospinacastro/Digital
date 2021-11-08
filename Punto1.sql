USE [master]
GO
/****** Object:  Database [Facturacion]    Script Date: 8/11/2021 4:44:35 p. m. ******/
CREATE DATABASE [Facturacion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Facturacion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Facturacion.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Facturacion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Facturacion_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Facturacion] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Facturacion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Facturacion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Facturacion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Facturacion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Facturacion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Facturacion] SET ARITHABORT OFF 
GO
ALTER DATABASE [Facturacion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Facturacion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Facturacion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Facturacion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Facturacion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Facturacion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Facturacion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Facturacion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Facturacion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Facturacion] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Facturacion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Facturacion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Facturacion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Facturacion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Facturacion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Facturacion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Facturacion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Facturacion] SET RECOVERY FULL 
GO
ALTER DATABASE [Facturacion] SET  MULTI_USER 
GO
ALTER DATABASE [Facturacion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Facturacion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Facturacion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Facturacion] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Facturacion] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Facturacion] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Facturacion', N'ON'
GO
ALTER DATABASE [Facturacion] SET QUERY_STORE = OFF
GO
USE [Facturacion]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 8/11/2021 4:44:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombres] [varchar](150) NULL,
	[Apellidos] [varchar](150) NULL,
	[Identificacion] [varchar](30) NULL,
	[Celular] [varchar](50) NULL,
	[Email] [varchar](150) NULL,
	[Edad] [int] NULL,
	[FechaNacimiento] [datetime] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 8/11/2021 4:44:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[Id] [uniqueidentifier] NOT NULL,
	[IdCliente] [uniqueidentifier] NULL,
	[ValorTotal] [money] NULL,
	[Fecha] [datetime] NULL,
	[Usuario] [varchar](50) NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleCompra]    Script Date: 8/11/2021 4:44:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCompra](
	[Id] [uniqueidentifier] NULL,
	[IdCompra] [uniqueidentifier] NULL,
	[IdProducto] [uniqueidentifier] NULL,
	[Cantidad] [int] NULL,
	[ValorProducto] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 8/11/2021 4:44:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Sigla] [varchar](50) NULL,
	[Codigo] [varchar](50) NULL,
	[Descripcion] [varchar](500) NULL,
	[Cantidad] [int] NULL,
	[PrecioActual] [money] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cliente] ([Id], [Nombres], [Apellidos], [Identificacion], [Celular], [Email], [Edad], [FechaNacimiento]) VALUES (N'5b2d4fad-37a7-44c4-bbad-4ecd65613c15', N'Carolina', N'Franco', N'2222222', N'3001111111', N'c@c.com', 33, CAST(N'1988-02-26T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Cliente] ([Id], [Nombres], [Apellidos], [Identificacion], [Celular], [Email], [Edad], [FechaNacimiento]) VALUES (N'96d84926-0773-4bd9-8426-990b9db2a7e8', N'Rafael', N'Ospina', N'1111111', N'3009999999', N'ralafuturo@gmail.com', 33, CAST(N'1988-06-11T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Cliente] ([Id], [Nombres], [Apellidos], [Identificacion], [Celular], [Email], [Edad], [FechaNacimiento]) VALUES (N'1c735465-812a-41b9-b63c-bceb0d983517', N'Cesar', N'Franco', N'3333333', N'3002222222', N'cc@cc.com', 59, CAST(N'1962-10-29T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Cliente] ([Id], [Nombres], [Apellidos], [Identificacion], [Celular], [Email], [Edad], [FechaNacimiento]) VALUES (N'64d5b686-13f7-4d10-80ee-e88e2ceabfe4', N'Pepito', N'Perez', N'4444444', N'3003333333', N'p@p.com', 41, CAST(N'1980-11-06T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Compra] ([Id], [IdCliente], [ValorTotal], [Fecha], [Usuario]) VALUES (N'5767bf6b-f1a1-4c6b-8732-1b92ff81862c', N'5b2d4fad-37a7-44c4-bbad-4ecd65613c15', 10.0000, CAST(N'2000-03-05T00:00:00.000' AS DateTime), N'prueba')
GO
INSERT [dbo].[Compra] ([Id], [IdCliente], [ValorTotal], [Fecha], [Usuario]) VALUES (N'cf76e819-5ff4-4a75-885b-2ee5de871221', N'96d84926-0773-4bd9-8426-990b9db2a7e8', 5.0000, CAST(N'2000-11-05T00:00:00.000' AS DateTime), N'prueba')
GO
INSERT [dbo].[Compra] ([Id], [IdCliente], [ValorTotal], [Fecha], [Usuario]) VALUES (N'2a85adab-6884-42fb-89b5-459b0a789f26', N'1c735465-812a-41b9-b63c-bceb0d983517', 2.0000, CAST(N'2000-10-05T00:00:00.000' AS DateTime), N'prueba')
GO
INSERT [dbo].[Compra] ([Id], [IdCliente], [ValorTotal], [Fecha], [Usuario]) VALUES (N'e896d4c8-2b64-43cc-88ab-da76e25bcb8c', N'64d5b686-13f7-4d10-80ee-e88e2ceabfe4', 1.0000, CAST(N'2000-12-05T00:00:00.000' AS DateTime), N'prueba')
GO
INSERT [dbo].[DetalleCompra] ([Id], [IdCompra], [IdProducto], [Cantidad], [ValorProducto]) VALUES (N'ad5c9bfb-7cb2-4467-90e2-ac6b61deb655', N'5767bf6b-f1a1-4c6b-8732-1b92ff81862c', N'415896dc-6d0a-45a4-b49e-1e66afdf2a35', 5, 2.0000)
GO
INSERT [dbo].[DetalleCompra] ([Id], [IdCompra], [IdProducto], [Cantidad], [ValorProducto]) VALUES (N'7f4b0cd6-0922-4585-a7b8-4a1e3224595e', N'cf76e819-5ff4-4a75-885b-2ee5de871221', N'415896dc-6d0a-45a4-b49e-1e66afdf2a35', 1, 2.0000)
GO
INSERT [dbo].[DetalleCompra] ([Id], [IdCompra], [IdProducto], [Cantidad], [ValorProducto]) VALUES (N'c7f55987-96b6-436d-bc31-6800cb067d14', N'cf76e819-5ff4-4a75-885b-2ee5de871221', N'95591d08-ac52-49c5-8d41-e7f7ce2cb9e1', 1, 3.0000)
GO
INSERT [dbo].[DetalleCompra] ([Id], [IdCompra], [IdProducto], [Cantidad], [ValorProducto]) VALUES (N'f6110897-af37-4506-b9b9-27c754a1fae4', N'2a85adab-6884-42fb-89b5-459b0a789f26', N'415896dc-6d0a-45a4-b49e-1e66afdf2a35', 1, 2.0000)
GO
INSERT [dbo].[DetalleCompra] ([Id], [IdCompra], [IdProducto], [Cantidad], [ValorProducto]) VALUES (N'94c88855-1034-4551-93c1-1e0fa63c3a47', N'e896d4c8-2b64-43cc-88ab-da76e25bcb8c', N'52d88d29-d916-4135-8815-dfea1a1ff651', 1, 1.0000)
GO
INSERT [dbo].[Producto] ([Id], [Nombre], [Sigla], [Codigo], [Descripcion], [Cantidad], [PrecioActual]) VALUES (N'415896dc-6d0a-45a4-b49e-1e66afdf2a35', N'Gaseosa', N'G', N'G0001', N'Gaseosa', 3, 2.0000)
GO
INSERT [dbo].[Producto] ([Id], [Nombre], [Sigla], [Codigo], [Descripcion], [Cantidad], [PrecioActual]) VALUES (N'92fd2ea8-3b38-46b3-8659-24bb48c54a33', N'Pasta', N'P', N'P0001', N'Pasta Normal', 10, 5.0000)
GO
INSERT [dbo].[Producto] ([Id], [Nombre], [Sigla], [Codigo], [Descripcion], [Cantidad], [PrecioActual]) VALUES (N'52d88d29-d916-4135-8815-dfea1a1ff651', N'Pan', N'PAN', N'PAN0001', N'Pan normal', 20, 1.0000)
GO
INSERT [dbo].[Producto] ([Id], [Nombre], [Sigla], [Codigo], [Descripcion], [Cantidad], [PrecioActual]) VALUES (N'95591d08-ac52-49c5-8d41-e7f7ce2cb9e1', N'Milo', N'M', N'M00001', N'Milo ', 4, 3.0000)
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Compra] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[DetalleCompra] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT (newid()) FOR [Id]
GO

