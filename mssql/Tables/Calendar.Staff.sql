USE <<DBName>>
GO

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