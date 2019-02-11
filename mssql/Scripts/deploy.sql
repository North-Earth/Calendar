USE <<DBName>>
GO

DROP SCHEMA IF EXISTS Calendar
GO

CREATE SCHEMA Calendar
GO

/* Источники с данными о персонале */

DROP TABLE IF EXISTS Calendar.Staff
GO

CREATE TABLE Calendar.Staff
(
     Id            INTEGER IDENTITY(1,1) NOT NULL
    ,Name          NVARCHAR(256)         NOT NULL
    ,ColorHexCode  VARCHAR(7)            NOT NULL
    ,CONSTRAINT PkStaff PRIMARY KEY CLUSTERED 
    (
        Id ASC
    )
)
GO

DROP VIEW IF EXISTS Calendar.StaffView
GO

CREATE VIEW Calendar.StaffView
AS
SELECT
     stf.Id
    ,stf.Name
    ,stf.ColorHexCode
FROM Calendar.Staff AS stf
GO

/* Источники с данными об отпусках */

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

DROP VIEW IF EXISTS Calendar.VacationView
GO

CREATE VIEW Calendar.VacationView
AS
SELECT
     vct.UserId
    ,vct.StartDate
    ,vct.CountDays
    ,vct.EndDate
FROM Calendar.Vacation AS vct
GO