USE [AirlineDB]
GO

/****** Object:  Table [dbo].[AirlineSchedule]    Script Date: 03-09-2021 19:24:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AirlineSchedule](
	[FlightNumber] [nvarchar](6) NOT NULL,
	[StartPeriodOfOperation] [nvarchar](7) NULL,
	[EndPeriodOfOperation] [nvarchar](7) NULL,
	[DaysOfOperation] [nvarchar](15) NULL,
	[DepartureTime] [nvarchar](4) NULL,
	[OriginStation] [nvarchar](3) NULL,
	[DestinationStation] [nvarchar](3) NULL,
	[Aircraft] [nvarchar](3) NULL,
 CONSTRAINT [PK_AirlineSchedule] PRIMARY KEY CLUSTERED 
(
	[FlightNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


