USE db_library
GO

CREATE PROC [dbo].[SharpstownDueToday_Get]
AS

BEGIN
DECLARE @date DATE     /* Inserting GETDATE() directly into AND gave an error, so I set */
SET @date = GETDATE()  /* a variable to carry the info  in the correct format. */
SELECT a2.Title, a3.Name, a3.[Address], a1.DateDue
FROM book_loans a1
	INNER JOIN books a2 ON a1.BookID = a2.BookID
	INNER JOIN borrower a3 ON a1.CardNo = a3.CardNo
	WHERE a1.BranchID = 4 AND a1.DateDue = @date
END

/* EXEC [dbo].SharpstownDueToday_Get */