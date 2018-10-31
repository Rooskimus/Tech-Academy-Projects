USE db_library
GO

CREATE PROC [dbo].[BranchesBooksLoaned_Get]
AS

BEGIN

SELECT a1.BranchName, COUNT(*) AS 'Total Books Loaned'
FROM library_branch a1
	INNER JOIN book_loans a2 ON a1.BranchID = a2.BranchID
GROUP BY a1.BranchName

END

/* EXEC [dbo].[BranchesBooksLoaned_Get] */