USE [master]
GO
/****** Object:  Database [TimeStampApp]    Script Date: 5/11/2023 12:26:01 PM ******/
CREATE DATABASE [TimeStampApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TimeStampApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TimeStampApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TimeStampApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TimeStampApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TimeStampApp] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TimeStampApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TimeStampApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TimeStampApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TimeStampApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TimeStampApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TimeStampApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [TimeStampApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TimeStampApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TimeStampApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TimeStampApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TimeStampApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TimeStampApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TimeStampApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TimeStampApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TimeStampApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TimeStampApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TimeStampApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TimeStampApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TimeStampApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TimeStampApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TimeStampApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TimeStampApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TimeStampApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TimeStampApp] SET RECOVERY FULL 
GO
ALTER DATABASE [TimeStampApp] SET  MULTI_USER 
GO
ALTER DATABASE [TimeStampApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TimeStampApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TimeStampApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TimeStampApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TimeStampApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TimeStampApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TimeStampApp', N'ON'
GO
ALTER DATABASE [TimeStampApp] SET QUERY_STORE = ON
GO
ALTER DATABASE [TimeStampApp] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TimeStampApp]
GO
/****** Object:  Table [dbo].[alj_person]    Script Date: 5/11/2023 12:26:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alj_person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[person_name] [varchar](25) NOT NULL,
 CONSTRAINT [alj_person_pkey] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[alj_project]    Script Date: 5/11/2023 12:26:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alj_project](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[project_name] [varchar](50) NOT NULL,
 CONSTRAINT [alj_project_pkey] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[alj_project_person]    Script Date: 5/11/2023 12:26:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alj_project_person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[project_id] [int] NOT NULL,
	[person_id] [int] NOT NULL,
	[hours] [int] NOT NULL,
 CONSTRAINT [alj_project_person_pkey] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[alj_person] ON 

INSERT [dbo].[alj_person] ([id], [person_name]) VALUES (0, N'Arvid')
INSERT [dbo].[alj_person] ([id], [person_name]) VALUES (1, N'Sparven')
INSERT [dbo].[alj_person] ([id], [person_name]) VALUES (2, N'Johan')
INSERT [dbo].[alj_person] ([id], [person_name]) VALUES (3, N'Niklas')
SET IDENTITY_INSERT [dbo].[alj_person] OFF
GO
SET IDENTITY_INSERT [dbo].[alj_project] ON 

INSERT [dbo].[alj_project] ([id], [project_name]) VALUES (1, N'MiniProject')
INSERT [dbo].[alj_project] ([id], [project_name]) VALUES (2, N'BankApp')
INSERT [dbo].[alj_project] ([id], [project_name]) VALUES (3, N'WoWDb')
SET IDENTITY_INSERT [dbo].[alj_project] OFF
GO
SET IDENTITY_INSERT [dbo].[alj_project_person] ON 

INSERT [dbo].[alj_project_person] ([id], [project_id], [person_id], [hours]) VALUES (3, 3, 3, 8)
SET IDENTITY_INSERT [dbo].[alj_project_person] OFF
GO
ALTER TABLE [dbo].[alj_project_person]  WITH CHECK ADD  CONSTRAINT [FK_alj_person_project_person_id] FOREIGN KEY([person_id])
REFERENCES [dbo].[alj_person] ([id])
GO
ALTER TABLE [dbo].[alj_project_person] CHECK CONSTRAINT [FK_alj_person_project_person_id]
GO
ALTER TABLE [dbo].[alj_project_person]  WITH CHECK ADD  CONSTRAINT [FK_alj_project_person_project_id] FOREIGN KEY([project_id])
REFERENCES [dbo].[alj_project] ([id])
GO
ALTER TABLE [dbo].[alj_project_person] CHECK CONSTRAINT [FK_alj_project_person_project_id]
GO
USE [master]
GO
ALTER DATABASE [TimeStampApp] SET  READ_WRITE 
GO
