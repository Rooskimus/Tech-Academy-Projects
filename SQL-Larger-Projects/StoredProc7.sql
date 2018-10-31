USE db_library
GO

CREATE PROC [dbo].[CentralStephenKing_Get]
AS

BEGIN

SELECT Title, a1.Number_Of_Copies AS 'Copies at Central'
FROM book_copies a1
	INNER JOIN books a2 ON a2.BookID = a1.BookID
	INNER JOIN book_authors a3 ON a3.BookID = a2.BookID
	INNER JOIN library_branch a4 ON a1.BranchID = a4.BranchID
WHERE a3.AuthorName = 'Stephen King'
AND a4.BranchName = 'Central'

END

/* EXEC [dbo].[CentralStephenKing_Get] */