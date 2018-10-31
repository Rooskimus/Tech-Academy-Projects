CREATE PROC [dbo].[LostTribeCopies_Get] @title VARCHAR(50)
AS

BEGIN
SELECT
a2.BranchName AS 'Branch Name', a3.Title, a1.Number_Of_Copies AS 'Number of Copies'
FROM book_copies a1
	INNER JOIN library_branch a2 ON a1.BranchID = a2.BranchID
	INNER JOIN books a3 ON a1.BookID = a3.BookID
	WHERE a3.Title = @title

END
GO

/*EXEC [dbo].[LostTribeCopies_Get] 'The Lost Tribe'*/