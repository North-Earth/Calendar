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
     Id       INTEGER IDENTITY(1,1) NOT NULL
    ,Name     NVARCHAR(256)         NOT NULL
    ,ColorId  INTEGER               NOT NULL
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
    ,stf.ColorId
FROM Calendar.Staff AS stf
GO

/* Источники с данными об отпусках */

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

/* Источники с цветами */

DROP TABLE IF EXISTS Calendar.Color
GO

CREATE TABLE Calendar.Color
(
     Id       INTEGER IDENTITY(1,1) NOT NULL
    ,Name     NVARCHAR(256)         NOT NULL
    ,HexCode  VARCHAR(7)            NOT NULL
    ,CONSTRAINT PkColor PRIMARY KEY CLUSTERED
    (
        Id ASC
    )
)
GO

DROP VIEW IF EXISTS Calendar.ColorView
GO

CREATE VIEW Calendar.ColorView 
AS
SELECT
     clr.Id
    ,clr.Name
    ,clr.HexCode
FROM Calendar.Color AS clr
GO

INSERT INTO Calendar.ColorView
(
     Name
    ,HexCode
)
VALUES
(
     'Синий'
    ,'0000ff'
)
,(
     'Красный'
    ,'ff0000'
)
,(
     'Зелёный'
    ,'008000'
)
,(
     'Жёлтый'
    ,'ffff00'
)
,(
     'Фиолетовый'
    ,'8b00ff'
)
,(
     'Оранжевый'
    ,'ffa500'
)
GO