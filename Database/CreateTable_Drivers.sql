USE [ValetDB]
GO

/****** Object:  Table [dbo].[Drivers]    Script Date: 4/18/2016 11:20:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Drivers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DriverName] [nvarchar](200) NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[DeviceID] [nvarchar](100) NOT NULL,
	[Notified] [bit],
	[Expires] [DateTime],
 CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


