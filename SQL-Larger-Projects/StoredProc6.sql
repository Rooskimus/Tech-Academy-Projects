USE db_library
GO

CREATE PROC [dbo].[BorrowerTotalBorrowed_Get]
AS

BEGIN

SELECT a1.Name, a1.[Address], COUNT(*) AS 'Total Books Borrowed'
FROM borrower a1
	INNER JOIN book_loans a2 ON a1.CardNo = a2.CardNo
GROUP BY a1.Name, a1.[Address]
HAVING COUNT(*) > 5

END

/* EXEC [dbo].[BorrowerTotalBorrowed_Get] */