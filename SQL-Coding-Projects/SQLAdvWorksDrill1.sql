USE [AdventureWorks2014]
GO

CREATE PROC [dbo].[getNameAndAddress] @City nvarchar(30) = NULL, @State nvarchar(10) = NULL
AS

SELECT
		a4.[FirstName]
	  , a4.[LastName]
      , a1.[AddressLine1]
      , a1.[AddressLine2]
      , a1.[City]
      , a2.[StateProvinceCode]
      , a1.[PostalCode]
  FROM [Person].[Address] a1
	INNER JOIN [Person].[StateProvince] a2 ON a1.StateProvinceID = a2.StateProvinceID
	INNER JOIN [Person].[BusinessEntityAddress] a3 ON a1.AddressID = a3.AddressID
	INNER JOIN [Person].[Person] a4 ON a3.BusinessEntityID = a4.BusinessEntityID
  WHERE a1.City = ISNULL(@City, a1.City)
  AND a2.[StateProvinceCode] = ISNULL(@State, StateProvinceCode)
GO

EXEC [dbo].[getNameAndAddress] @City = Chicago, @State = IL