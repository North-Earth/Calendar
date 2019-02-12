USE <<DBName>>
GO

DROP VIEW IF EXISTS Calendar.VacationView
GO

CREATE VIEW Calendar.VacationView
AS
SELECT
     vct.Id
    ,vct.UserId
    ,vct.StartDate
    ,vct.CountDays
    ,vct.EndDate
FROM Calendar.Vacation AS vct
GO