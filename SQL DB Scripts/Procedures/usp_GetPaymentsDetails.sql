IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetPaymentsDetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_GetPaymentsDetails]
GO


--EXEC  usp_GetPaymentsDetails 1, 10, NULL, 'Amount', 'DESC'

CREATE PROCEDURE [dbo].[usp_GetPaymentsDetails]
@pageNumber INT = 1,
@pageSize INT = 10,
@accountSearch VARCHAR(200) = NULL,
@sortColumn NVARCHAR(20) = 'AccountNumber',
@sortOrder NVARCHAR(4) = 'ASC'

AS BEGIN
SET NOCOUNT ON;

SELECT 
	A.[AccountNumber],
	P.[TaxYear],
	A.[Type],
	V.[VendorNumber],
	P.[Amount],
	P.[Status],
	P.[PaidDate],
	COUNT(1) over () AS TotalCount
FROM dbo.[Payments] P JOIN dbo.[Accounts] A ON P.[AccountNumber] = A.[AccountNumber]
						JOIN dbo.[Vendors] V ON A.[VendorNumber] = V.[VendorNumber]
WHERE @accountSearch IS NULL OR A.[AccountNumber] IN (@accountSearch)
ORDER BY
		CASE WHEN (@sortColumn = 'AccountNumber' AND @sortOrder = 'ASC')
				THEN A.[AccountNumber]
		END ASC,
		CASE WHEN (@sortColumn = 'AccountNumber' AND @sortOrder = 'DESC')
				THEN A.[AccountNumber]
		END DESC,
		CASE WHEN (@sortColumn = 'TaxYear' AND @sortOrder = 'ASC')
				THEN P.[TaxYear]
		END ASC,
		CASE WHEN (@sortColumn = 'TaxYear' AND @sortOrder = 'DESC')
				THEN P.[TaxYear]
		END DESC,
		CASE WHEN (@sortColumn = 'Type' AND @sortOrder = 'ASC')
				THEN A.[Type]
		END ASC,
		CASE WHEN (@sortColumn = 'Type' AND @sortOrder = 'DESC')
				THEN A.[Type]
		END DESC,
		CASE WHEN (@sortColumn = 'VendorNumber' AND @sortOrder = 'ASC')
				THEN V.[VendorNumber]
		END ASC,
		CASE WHEN (@sortColumn = 'VendorNumber' AND @sortOrder = 'DESC')
				THEN V.[VendorNumber]
		END DESC,
		CASE WHEN (@sortColumn = 'Amount' AND @sortOrder = 'ASC')
				THEN P.[Amount]
		END ASC,
		CASE WHEN (@sortColumn = 'Amount' AND @sortOrder = 'DESC')
				THEN P.[Amount]
		END DESC,
		CASE WHEN (@sortColumn = 'Status' AND @sortOrder = 'ASC')
				THEN P.[Status]
		END ASC,
		CASE WHEN (@sortColumn = 'Status' AND @sortOrder = 'DESC')
				THEN P.[Status]
		END DESC,
		CASE WHEN (@sortColumn = 'PaidDate' AND @sortOrder = 'ASC')
				THEN P.[PaidDate]
		END ASC,
		CASE WHEN (@sortColumn = 'PaidDate' AND @sortOrder = 'DESC')
				THEN P.[PaidDate]
		END DESC		
		OFFSET @pageSize * (@pageNumber - 1) ROWS
		FETCH NEXT @PageSize ROWS ONLY;
  
SET NOCOUNT OFF;
END
GO


