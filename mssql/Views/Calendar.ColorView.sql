USE <<DBName>>
GO

DROP VIEW Calendar.ColorView
GO

CREATE VIEW Calendar.ColorView 
AS
SELECT
     clr.Id
    ,clr.Name
    ,clr.HexCode
FROM Calendar.Color AS clr
GO