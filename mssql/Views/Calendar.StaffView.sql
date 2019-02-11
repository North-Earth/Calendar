USE <<DBName>>
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