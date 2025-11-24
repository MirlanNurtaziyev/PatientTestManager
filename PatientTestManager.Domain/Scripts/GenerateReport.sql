IF OBJECT_ID('dbo.GenerateReport', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.GenerateReport;
END
GO

CREATE PROCEDURE dbo.GenerateReport
    @FromDate DATE,
    @ToDate   DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.Id AS PatientId,
        p.[Name] AS PatientName,
        COUNT(t.Id) AS TotalTests,
         CAST(
                CASE 
                    WHEN COUNT(t.Id) = 0 THEN 0
                    ELSE CAST(
                        (100.0 * SUM(CASE WHEN t.IsWithinThreshold = 1 THEN 1 ELSE 0 END) / COUNT(t.Id))
                        AS INT 
                    )
                END
                AS VARCHAR(20)
            ) + '%' AS Percentage
    FROM Patients p
    LEFT JOIN Tests t 
        ON p.Id = t.PatientId
       AND t.TestDate BETWEEN @FromDate AND @ToDate
    GROUP BY 
        p.Id,
        p.[Name]
    ORDER BY 
        p.[Name];
END
GO
