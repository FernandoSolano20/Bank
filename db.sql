USE [master]
GO
/****** Object:  Database [Bank]    Script Date: 2/20/2020 4:00:01 AM ******/
CREATE DATABASE [Bank]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bank', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Bank.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Bank_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Bank_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Bank] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bank] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bank] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bank] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bank] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bank] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bank] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bank] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bank] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bank] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bank] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bank] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bank] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bank] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bank] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bank] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Bank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bank] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bank] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bank] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bank] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bank] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bank] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bank] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Bank] SET  MULTI_USER 
GO
ALTER DATABASE [Bank] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bank] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bank] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Bank] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Bank] SET QUERY_STORE = OFF
GO
USE [Bank]
GO
/****** Object:  Table [dbo].[TBL_COUNTRY]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_COUNTRY](
	[NAME] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TBL_COUNTRY] PRIMARY KEY CLUSTERED 
(
	[NAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_EXCHANGE_RATE]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_EXCHANGE_RATE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ORIGIN_COUNTRY] [varchar](50) NOT NULL,
	[DESTINATION_COUNTRY] [varchar](50) NOT NULL,
	[DATERATE] [datetime] NOT NULL,
	[EXCHANGERATE] [float] NOT NULL,
 CONSTRAINT [PK_TBL_EXCHANGE_RATE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_HOLIDAY]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_HOLIDAY](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DAY] [int] NOT NULL,
	[MONTH] [int] NOT NULL,
 CONSTRAINT [PK_TBL_HOLIDAY] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_MESSAGE]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_MESSAGE](
	[ID] [int] NOT NULL,
	[MESSAGE] [varchar](50) NOT NULL,
 CONSTRAINT [PK__TBL_MESS__3214EC27F13979D0] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TBL_EXCHANGE_RATE]  WITH CHECK ADD  CONSTRAINT [FK_TBL_EXCHANGE_RATE_TBL_COUNTRY] FOREIGN KEY([ORIGIN_COUNTRY])
REFERENCES [dbo].[TBL_COUNTRY] ([NAME])
GO
ALTER TABLE [dbo].[TBL_EXCHANGE_RATE] CHECK CONSTRAINT [FK_TBL_EXCHANGE_RATE_TBL_COUNTRY]
GO
ALTER TABLE [dbo].[TBL_EXCHANGE_RATE]  WITH CHECK ADD  CONSTRAINT [FK_TBL_EXCHANGE_RATE_TBL_COUNTRY1] FOREIGN KEY([DESTINATION_COUNTRY])
REFERENCES [dbo].[TBL_COUNTRY] ([NAME])
GO
ALTER TABLE [dbo].[TBL_EXCHANGE_RATE] CHECK CONSTRAINT [FK_TBL_EXCHANGE_RATE_TBL_COUNTRY1]
GO
/****** Object:  StoredProcedure [dbo].[CRE_COUNTRY_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CRE_COUNTRY_PR]
	@P_NAME VARCHAR(50)
AS
	INSERT INTO [dbo].[TBL_COUNTRY] (NAME) 
	VALUES(@P_NAME);
GO
/****** Object:  StoredProcedure [dbo].[CRE_EXCHANGE_RATE_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--INSERT EN  EXCHANGE_RATE
CREATE PROCEDURE [dbo].[CRE_EXCHANGE_RATE_PR]
	@P_DateRate DATETIME,
	@P_ExchangeRate FLOAT,
	@P_Origin_Country VARCHAR(50),
	@P_Destination_Country VARCHAR(50)
AS
	INSERT INTO [dbo].[TBL_EXCHANGE_RATE] (DATERATE,EXCHANGERATE,ORIGIN_COUNTRY,DESTINATION_COUNTRY) 
	VALUES(@P_DateRate,@P_ExchangeRate,@P_Origin_Country,@P_Destination_Country);
GO
/****** Object:  StoredProcedure [dbo].[CRE_HOLIDAY_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CRE_HOLIDAY_PR]
	@P_DAY INT,
	@P_MONTH INT
AS
	INSERT INTO [dbo].[TBL_HOLIDAY] (DAY,MONTH) 
	VALUES(@P_DAY,@P_MONTH);
GO
/****** Object:  StoredProcedure [dbo].[CRE_MESSAGE_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--INSERT EN  MESSAGE
CREATE PROCEDURE [dbo].[CRE_MESSAGE_PR]
	@P_Id INT,
	@P_Message VARCHAR(50)
AS
	INSERT INTO [dbo].[TBL_MESSAGE] (ID,MESSAGE) 
	VALUES(@P_Id,@P_Message);
GO
/****** Object:  StoredProcedure [dbo].[DEL_COUNTRY_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DEL_COUNTRY_PR]
	@P_NAME VARCHAR(50)
AS
	DELETE FROM [dbo].[TBL_COUNTRY]
	where @P_NAME = NAME;
GO
/****** Object:  StoredProcedure [dbo].[DEL_EXCHANGE_RATE_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--DELETE CUSTOMER
CREATE PROCEDURE [dbo].[DEL_EXCHANGE_RATE_PR]
	@P_DateRate DATETIME,
	@P_Origin_Country VARCHAR(MAX),
	@P_Destination_Country VARCHAR(MAX)
AS
	DELETE FROM TBL_EXCHANGE_RATE
	WHERE DATERATE = @P_DateRate AND
	ORIGIN_COUNTRY = @P_Origin_Country AND
	DESTINATION_COUNTRY = @P_Destination_Country;
GO
/****** Object:  StoredProcedure [dbo].[DEL_HOLIDAY_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DEL_HOLIDAY_PR]
	@P_ID INT
AS
	DELETE FROM [dbo].[TBL_HOLIDAY]
	where @P_ID = ID;
GO
/****** Object:  StoredProcedure [dbo].[DEL_MESSAGE_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--DELETE CUSTOMER
CREATE PROCEDURE [dbo].[DEL_MESSAGE_PR]
	@P_Id INT
AS
	DELETE FROM TBL_MESSAGE
	WHERE ID = @P_Id
GO
/****** Object:  StoredProcedure [dbo].[RET_ALL_COUNTRY_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RET_ALL_COUNTRY_PR]
AS
	SELECT * FROM [dbo].[TBL_COUNTRY];
GO
/****** Object:  StoredProcedure [dbo].[RET_ALL_EXCHANGE_RATE_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--RETRIEVE ALL CUSTOMER
CREATE PROCEDURE [dbo].[RET_ALL_EXCHANGE_RATE_PR]
AS
	SELECT * FROM TBL_EXCHANGE_RATE;
GO
/****** Object:  StoredProcedure [dbo].[RET_ALL_HOLIDAY_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RET_ALL_HOLIDAY_PR]
AS
	SELECT * FROM [dbo].[TBL_HOLIDAY];
GO
/****** Object:  StoredProcedure [dbo].[RET_ALL_MESSAGE_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--RETRIEVE ALL CUSTOMER
CREATE PROCEDURE [dbo].[RET_ALL_MESSAGE_PR]
AS
	SELECT * FROM TBL_MESSAGE;
GO
/****** Object:  StoredProcedure [dbo].[RET_COUNTRY_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[RET_COUNTRY_PR]
	@P_NAME VARCHAR(50)
AS
	SELECT * FROM [dbo].[TBL_COUNTRY]
	WHERE @P_NAME = NAME;
GO
/****** Object:  StoredProcedure [dbo].[RET_DATES_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RET_DATES_PR]
	@P_Origin_Country VARCHAR(MAX),
	@P_Destination_Country VARCHAR(MAX)
AS
	SELECT * FROM TBL_EXCHANGE_RATE
	WHERE ORIGIN_COUNTRY = @P_Origin_Country AND
	DESTINATION_COUNTRY = @P_Destination_Country;
GO
/****** Object:  StoredProcedure [dbo].[RET_DESTINATIONCOUNTRY_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RET_DESTINATIONCOUNTRY_PR]
	@P_Origin_Country VARCHAR(MAX)
AS
	SELECT * FROM TBL_EXCHANGE_RATE
	WHERE ORIGIN_COUNTRY = @P_Origin_Country;
GO
/****** Object:  StoredProcedure [dbo].[RET_EXCHANGE_RATE_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--RET CUSTOMER BY ID
CREATE PROCEDURE [dbo].[RET_EXCHANGE_RATE_PR]
	@P_DateRate DATETIME,
	@P_Origin_Country VARCHAR(50),
	@P_Destination_Country VARCHAR(50)
AS
	SELECT * FROM TBL_EXCHANGE_RATE
	WHERE DATERATE = @P_DateRate AND
	ORIGIN_COUNTRY = @P_Origin_Country AND
	DESTINATION_COUNTRY = @P_Destination_Country;
GO
/****** Object:  StoredProcedure [dbo].[RET_HOLIDAY_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RET_HOLIDAY_PR]
	@P_DAY INT,
	@P_MONTH INT
AS
	SELECT * FROM [dbo].[TBL_HOLIDAY]
	WHERE @P_DAY = DAY AND
	@P_MONTH = MONTH;
GO
/****** Object:  StoredProcedure [dbo].[RET_MESSAGE_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--RET CUSTOMER BY ID
CREATE PROCEDURE [dbo].[RET_MESSAGE_PR]
	@P_Id INT
AS
	SELECT * FROM TBL_MESSAGE
	WHERE ID = @P_Id;
GO
/****** Object:  StoredProcedure [dbo].[UPD_COUNTRY_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPD_COUNTRY_PR]
	@P_NAME VARCHAR(50)
AS
	UPDATE [dbo].[TBL_COUNTRY] SET NAME = @P_NAME
	WHERE @P_NAME = NAME;
GO
/****** Object:  StoredProcedure [dbo].[UPD_EXCHANGE_RATE_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--UPDATE CUSTOMER
CREATE PROCEDURE [dbo].[UPD_EXCHANGE_RATE_PR]
	@P_DateRate DATETIME,
	@P_ExchangeRate FLOAT,
	@P_Origin_Country VARCHAR(50),
	@P_Destination_Country VARCHAR(50)
AS
	UPDATE [dbo].[TBL_EXCHANGE_RATE] SET EXCHANGERATE=@P_ExchangeRate
	WHERE DATERATE = @P_DateRate AND
	ORIGIN_COUNTRY = @P_Origin_Country AND
	DESTINATION_COUNTRY = @P_Destination_Country;
GO
/****** Object:  StoredProcedure [dbo].[UPD_HOLIDAY_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPD_HOLIDAY_PR]
	@P_ID INT,
	@P_DAY INT,
	@P_MONTH INT
AS
	UPDATE [dbo].[TBL_HOLIDAY] SET DAY = @P_DAY,
	MONTH = @P_MONTH
	WHERE @P_ID = ID;
GO
/****** Object:  StoredProcedure [dbo].[UPD_MESSAGE_PR]    Script Date: 2/20/2020 4:00:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--UPDATE CUSTOMER
CREATE PROCEDURE [dbo].[UPD_MESSAGE_PR]
	@P_Id INT,
	@P_Message VARCHAR(50)
AS
	UPDATE [dbo].[TBL_MESSAGE] SET MESSAGE=@P_Message
	WHERE ID = @P_Id;
GO
USE [master]
GO
ALTER DATABASE [Bank] SET  READ_WRITE 
GO
