USE [ValetDB]
GO

/****** Object:  Table [dbo].[Dealers]    Script Date: 4/18/2016 11:20:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Operators](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OperatorName] [nvarchar](200) NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[Address1] [nvarchar](200) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[StateID] [char](2) NOT NULL,
	[Zip] [char](12) NULL,
	[Phone] [char](12) NULL,
	[WebsiteUrl] [nvarchar](200) NULL,
	[NumberOfSpaces] [int] NULL,
	[InitialFee] decimal(8,2) NOT NULL,
	[InitialHours] [int] NOT NULL,
	[HourlyFee] decimal(8,2) NOT NULL,
	[AcceptsCash] bit NOT NULL,
	[AcceptsCredit] bit NOT NULL,
	[CoveredParking] bit NOT NULL,
	[Open24Hours] bit NOT NULL,
	[HourOpen] int NOT NULL,
	[HourClosed] int NOT NULL,
	[EventParking] bit NOT NULL,
	[ParkingGarage] bit NOT NULL,
 CONSTRAINT [PK_Operators] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


