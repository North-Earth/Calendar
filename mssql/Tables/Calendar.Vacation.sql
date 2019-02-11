USE <<DBName>>
GO

DROP TABLE IF EXISTS Calendar.Vacation
GO

CREATE TABLE Calendar.Vacation
(
     UserId     INTEGER NOT NULL
    ,StartDate  DATE    NOT NULL
    ,EndDate    DATE    NOT NULL
    ,CountDays  TINYINT NOT NULL
)
GO