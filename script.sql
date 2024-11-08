USE [master]
GO
/****** Object:  Database [DB_TEST]    Script Date: 11/4/2024 00.25.16 ******/
CREATE DATABASE [DB_TEST]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_TEST', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DB_TEST.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_TEST_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DB_TEST_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DB_TEST] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_TEST].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_TEST] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_TEST] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_TEST] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_TEST] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_TEST] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_TEST] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_TEST] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_TEST] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_TEST] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_TEST] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_TEST] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_TEST] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_TEST] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_TEST] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_TEST] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_TEST] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_TEST] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_TEST] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_TEST] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_TEST] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_TEST] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_TEST] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_TEST] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_TEST] SET  MULTI_USER 
GO
ALTER DATABASE [DB_TEST] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_TEST] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_TEST] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_TEST] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_TEST] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_TEST] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DB_TEST] SET QUERY_STORE = OFF
GO
USE [DB_TEST]
GO
/****** Object:  Table [dbo].[TBL_KARY]    Script Date: 11/4/2024 00.25.17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_KARY](
	[nrp] [varchar](6) NOT NULL,
	[nama] [varchar](max) NULL,
	[dept] [varchar](20) NULL,
	[gender] [varchar](1) NULL,
	[alamat] [varchar](50) NULL,
 CONSTRAINT [PK_TBL_KARY] PRIMARY KEY CLUSTERED 
(
	[nrp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_SEAT]    Script Date: 11/4/2024 00.25.17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_SEAT](
	[seat_no] [varchar](3) NOT NULL,
	[is_avail] [varchar](1) NULL,
	[seat_type] [varchar](2) NULL,
 CONSTRAINT [PK_TBL_SEAT] PRIMARY KEY CLUSTERED 
(
	[seat_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_BOOKING]    Script Date: 11/4/2024 00.25.17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_BOOKING](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[seat_no] [varchar](3) NULL,
	[nrp] [varchar](6) NULL,
	[tanggal] [date] NULL,
 CONSTRAINT [PK_TBL_BOOKING] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VW_BOOKED]    Script Date: 11/4/2024 00.25.17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_BOOKED]
AS
SELECT dbo.TBL_BOOKING.id, dbo.TBL_BOOKING.seat_no, dbo.TBL_BOOKING.nrp, dbo.TBL_SEAT.is_avail, dbo.TBL_KARY.nama, dbo.TBL_KARY.dept, dbo.TBL_KARY.gender, dbo.TBL_KARY.alamat, dbo.TBL_BOOKING.tanggal
FROM     dbo.TBL_BOOKING INNER JOIN
                  dbo.TBL_KARY ON dbo.TBL_BOOKING.nrp = dbo.TBL_KARY.nrp INNER JOIN
                  dbo.TBL_SEAT ON dbo.TBL_BOOKING.seat_no = dbo.TBL_SEAT.seat_no
GO
/****** Object:  Table [dbo].[TBL_USER]    Script Date: 11/4/2024 00.25.17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_USER](
	[nrp] [varchar](6) NOT NULL,
	[password] [nvarchar](32) NULL,
 CONSTRAINT [PK_TBL_USER] PRIMARY KEY CLUSTERED 
(
	[nrp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TBL_BOOKING"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 148
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "TBL_KARY"
            Begin Extent = 
               Top = 149
               Left = 407
               Bottom = 312
               Right = 601
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "TBL_SEAT"
            Begin Extent = 
               Top = 7
               Left = 532
               Bottom = 126
               Right = 726
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_BOOKED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_BOOKED'
GO
USE [master]
GO
ALTER DATABASE [DB_TEST] SET  READ_WRITE 
GO
