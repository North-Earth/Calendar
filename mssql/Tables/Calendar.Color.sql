USE <<DBName>>
GO

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