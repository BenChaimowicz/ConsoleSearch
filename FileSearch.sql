USE [master]
GO
/****** Object:  Database [FileSearch]    Script Date: 4/5/2019 12:31:41 PM ******/
CREATE DATABASE [FileSearch]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FileSearch', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\FileSearch.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FileSearch_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\FileSearch_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [FileSearch] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FileSearch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FileSearch] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FileSearch] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FileSearch] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FileSearch] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FileSearch] SET ARITHABORT OFF 
GO
ALTER DATABASE [FileSearch] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FileSearch] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FileSearch] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FileSearch] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FileSearch] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FileSearch] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FileSearch] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FileSearch] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FileSearch] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FileSearch] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FileSearch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FileSearch] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FileSearch] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FileSearch] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FileSearch] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FileSearch] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FileSearch] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FileSearch] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FileSearch] SET  MULTI_USER 
GO
ALTER DATABASE [FileSearch] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FileSearch] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FileSearch] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FileSearch] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FileSearch] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FileSearch] SET QUERY_STORE = OFF
GO
USE [FileSearch]
GO
/****** Object:  Table [dbo].[Searches]    Script Date: 4/5/2019 12:31:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Searches](
	[ID] [int] NOT NULL,
	[File] [nvarchar](250) NOT NULL,
	[Directory] [nvarchar](250) NULL,
	[Results] [nvarchar](1000) NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Searches] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [FileSearch] SET  READ_WRITE 
GO
