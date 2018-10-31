CREATE PROC [dbo].[inactiveBorrowers_Get]
AS

BEGIN
SELECT Name AS 'Inactive Borrowers:'
FROM borrower
WHERE NOT EXISTS (
	SELECT CardNo
	FROM book_loans
	WHERE borrower.CardNo = book_loans.CardNo)
END

/* EXEC [dbo].[inactiveBorrowers_Get] */