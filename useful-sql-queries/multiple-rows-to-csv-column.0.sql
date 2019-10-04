-- https://medium.com/@pztrinity/mssql-%E0%B8%A3%E0%B8%A7%E0%B8%A1%E0%B8%82%E0%B9%89%E0%B8%AD%E0%B8%A1%E0%B8%B9%E0%B8%A5%E0%B8%AB%E0%B8%A5%E0%B8%B2%E0%B8%A2%E0%B9%86-rows-%E0%B9%83%E0%B8%AB%E0%B9%89%E0%B8%AD%E0%B8%A2%E0%B8%B9%E0%B9%88%E0%B9%83%E0%B8%99-1-column-%E0%B8%94%E0%B9%89%E0%B8%A7%E0%B8%A2-sql-for-xml-path-fb2b3456668f
-- https://stackoverflow.com/a/31212160/1872200
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
),
UniqueCategory AS (
    SELECT
        DISTINCT CategoryId
    FROM
        TestData
)
SELECT
    c.CategoryId,
    STUFF(
        (
            SELECT
                ', ' + d.Name
            FROM
                TestData AS d
            WHERE
                d.CategoryId = c.CategoryId
            ORDER BY
                c.CategoryId FOR XML PATH('')
        ),
        1,
        1,
        ''
    ) AS Names
FROM
    UniqueCategory AS c
