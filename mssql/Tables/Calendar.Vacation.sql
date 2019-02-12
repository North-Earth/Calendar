USE <<DBName>>
GO

DROP TABLE IF EXISTS Calendar.Vacation
GO

CREATE TABLE Calendar.Vacation
(
     Id         INTEGER IDENTITY(1,1) NOT NULL
    ,UserId     INTEGER               NOT NULL
    ,StartDate  DATE                  NOT NULL
    ,EndDate    DATE                  NOT NULL
    ,CountDays  TINYINT               NOT NULL
)
GO