USE [AirlineDB]
GO
Create Procedure InsertSchedule
			@FlightNumber nvarchar(6)
           ,@StartPeriodOfOperation nvarchar(7)
           ,@EndPeriodOfOperation nvarchar(7)
           ,@DaysOfOperation nvarchar(15)
           ,@DepartureTime nvarchar(4)
           ,@OriginStation nvarchar(3)
           ,@DestinationStation nvarchar(3)
           ,@Aircraft nvarchar(3)

AS
INSERT INTO [dbo].[AirlineSchedule]
           ([FlightNumber]
           ,[StartPeriodOfOperation]
           ,[EndPeriodOfOperation]
           ,[DaysOfOperation]
           ,[DepartureTime]
           ,[OriginStation]
           ,[DestinationStation]
           ,[Aircraft])
     VALUES
           (@FlightNumber
           ,@StartPeriodOfOperation
           ,@EndPeriodOfOperation
           ,@DaysOfOperation
           ,@DepartureTime
           ,@OriginStation
           ,@DestinationStation
           ,@Aircraft)

GO


