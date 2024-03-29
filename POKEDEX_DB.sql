USE [master]
GO
/****** Object:  Database [POKEDEX_DB]    Script Date: 16/3/2024 19:35:56 ******/
CREATE DATABASE [POKEDEX_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'POKEDEX_DB', FILENAME = N'C:\cositas mias\MSSQL16.SQLEXPRESS\MSSQL\DATA\POKEDEX_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'POKEDEX_DB_log', FILENAME = N'C:\cositas mias\MSSQL16.SQLEXPRESS\MSSQL\DATA\POKEDEX_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [POKEDEX_DB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [POKEDEX_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [POKEDEX_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [POKEDEX_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [POKEDEX_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [POKEDEX_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [POKEDEX_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [POKEDEX_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [POKEDEX_DB] SET  MULTI_USER 
GO
ALTER DATABASE [POKEDEX_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [POKEDEX_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [POKEDEX_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [POKEDEX_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [POKEDEX_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [POKEDEX_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [POKEDEX_DB] SET QUERY_STORE = ON
GO
ALTER DATABASE [POKEDEX_DB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [POKEDEX_DB]
GO
/****** Object:  Table [dbo].[ELEMENTOS]    Script Date: 16/3/2024 19:35:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ELEMENTOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_ELEMENTOS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[POKEMONS]    Script Date: 16/3/2024 19:36:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POKEMONS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [int] NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
	[UrlImagen] [varchar](300) NULL,
	[IdTipo] [int] NULL,
	[IdDebilidad] [int] NULL,
	[IdEvolucion] [int] NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_POKEMONS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ELEMENTOS] ON 

INSERT [dbo].[ELEMENTOS] ([Id], [Descripcion]) VALUES (1, N'Planta')
INSERT [dbo].[ELEMENTOS] ([Id], [Descripcion]) VALUES (2, N'Fuego')
INSERT [dbo].[ELEMENTOS] ([Id], [Descripcion]) VALUES (3, N'Agua')
SET IDENTITY_INSERT [dbo].[ELEMENTOS] OFF
GO
SET IDENTITY_INSERT [dbo].[POKEMONS] ON 

INSERT [dbo].[POKEMONS] ([Id], [Numero], [Nombre], [Descripcion], [UrlImagen], [IdTipo], [IdDebilidad], [IdEvolucion], [Activo]) VALUES (1, 1, N'Bulbasaur', N'Este Pokémon nace con una semilla en el lomo.', N'https://assets.pokemon.com/assets/cms2/img/pokedex/full/001.png', 1, 2, NULL, 1)
INSERT [dbo].[POKEMONS] ([Id], [Numero], [Nombre], [Descripcion], [UrlImagen], [IdTipo], [IdDebilidad], [IdEvolucion], [Activo]) VALUES (2, 4, N'Charmander', N'Pokemon de fuego', N'https://assets.pokemon.com/assets/cms2/img/pokedex/full/004.png', 2, 3, NULL, 1)
INSERT [dbo].[POKEMONS] ([Id], [Numero], [Nombre], [Descripcion], [UrlImagen], [IdTipo], [IdDebilidad], [IdEvolucion], [Activo]) VALUES (3, 11, N'Butterfree', N'mariposa', N'https://assets.pokemon.com/assets/cms2/img/pokedex/full/012.png', 1, 1, NULL, 1)
INSERT [dbo].[POKEMONS] ([Id], [Numero], [Nombre], [Descripcion], [UrlImagen], [IdTipo], [IdDebilidad], [IdEvolucion], [Activo]) VALUES (4, 15, N'Pidgey', N'Voladorrrrr', N'https://assets.pokemon.com/assets/cms2/img/pokedex/full/016.png', 2, 1, NULL, 1)
INSERT [dbo].[POKEMONS] ([Id], [Numero], [Nombre], [Descripcion], [UrlImagen], [IdTipo], [IdDebilidad], [IdEvolucion], [Activo]) VALUES (10, 25, N'Pikachu', N'Rata amarilla', N'https://assets.pokemon.com/assets/cms2/img/pokedex/full/025.png', 2, 2, NULL, 1)
INSERT [dbo].[POKEMONS] ([Id], [Numero], [Nombre], [Descripcion], [UrlImagen], [IdTipo], [IdDebilidad], [IdEvolucion], [Activo]) VALUES (11, 120, N'Staryu', N'estrella de mar', N'https://assets.pokemon.com/assets/cms2/img/pokedex/full/120.png', 3, 1, NULL, 1)
SET IDENTITY_INSERT [dbo].[POKEMONS] OFF
GO
ALTER TABLE [dbo].[POKEMONS]  WITH CHECK ADD  CONSTRAINT [FK_POKEMONS_ELEMENTOS] FOREIGN KEY([IdTipo])
REFERENCES [dbo].[ELEMENTOS] ([Id])
GO
ALTER TABLE [dbo].[POKEMONS] CHECK CONSTRAINT [FK_POKEMONS_ELEMENTOS]
GO
ALTER TABLE [dbo].[POKEMONS]  WITH CHECK ADD  CONSTRAINT [FK_POKEMONS_ELEMENTOS1] FOREIGN KEY([IdDebilidad])
REFERENCES [dbo].[ELEMENTOS] ([Id])
GO
ALTER TABLE [dbo].[POKEMONS] CHECK CONSTRAINT [FK_POKEMONS_ELEMENTOS1]
GO
ALTER TABLE [dbo].[POKEMONS]  WITH CHECK ADD  CONSTRAINT [FK_POKEMONS_POKEMONS] FOREIGN KEY([IdEvolucion])
REFERENCES [dbo].[POKEMONS] ([Id])
GO
ALTER TABLE [dbo].[POKEMONS] CHECK CONSTRAINT [FK_POKEMONS_POKEMONS]
GO
USE [master]
GO
ALTER DATABASE [POKEDEX_DB] SET  READ_WRITE 
GO
