WITH TestData AS (
    SELECT
        *
    FROM
        (
            VALUES
                (N'กก', 1),
                (N'ขข', 1),
                (N'คค', 1),
                (N'aa', 2),
                (N'bb', 2),
                (N'ZZ', 3)
        ) AS TableValues (Name, CategoryId)
)
SELECT
    CategoryId,
    STRING_AGG(Name, ',') as CSV
FROM
    TestData
GROUP BY
    CategoryId
