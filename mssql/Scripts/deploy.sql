USE <<DBName>>
GO

DROP SCHEMA IF EXISTS Calendar
GO

CREATE SCHEMA Calendar
GO

/* ��������� � ������� � ��������� */

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

/* ��������� � ������� �� �������� */

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

/* ��������� � ������� */

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
     '�����'
    ,'0000ff'
)
,(
     '�������'
    ,'ff0000'
)
,(
     '������'
    ,'008000'
)
,(
     'Ƹ����'
    ,'ffff00'
)
,(
     '����������'
    ,'8b00ff'
)
,(
     '���������'
    ,'ffa500'
)
GO