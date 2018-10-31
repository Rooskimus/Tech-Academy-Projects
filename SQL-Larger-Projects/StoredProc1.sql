CREATE PROC [dbo].[SharpstownLostTribeCopies_Get]
AS

BEGIN

SELECT
a2.BranchName AS 'Branch Name', a3.Title, a1.Number_Of_Copies AS 'Number of Copies'
FROM book_copies a1
	inner JOIN library_branch a2 ON a1.BranchID = a2.BranchID
	INNER JOIN books a3 ON a1.BookID = a3.BookID
	WHERE a2.BranchName = 'Sharpstown'
	AND a3.Title = 'The Lost Tribe'
END

EXEC [dbo].[SharpstownLostTribeCopies_Get]