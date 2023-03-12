-- Challenge 1
--
SELECT COUNT(*)FROM Invoice
WHERE cast(strftime('%Y', InvoiceDate) as INT) = 2011 OR cast(strftime('%Y', InvoiceDate) as INT) = 2012

--
SELECT SUM(Total) FROM Invoice
WHERE cast(strftime('%Y', InvoiceDate) as INT) = 2011 OR cast(strftime('%Y', InvoiceDate) as INT) = 2012

-- Challenge 2
--
SELECT 
  c.FirstName, 
  c.LastName, 
  c.CustomerId,
  i.total
FROM Customer as c
INNER JOIN Invoice AS i 
ON c.CustomerId = i.CustomerId
WHERE cast(strftime('%Y', InvoiceDate) as INT) = 2011 OR cast(strftime('%Y', InvoiceDate) as INT) = 2012

--
SELECT 
  c.FirstName, 
  c.LastName, 
  c.SupportRepId,
  i.total
FROM Customer as c
INNER JOIN Invoice as i ON c.CustomerId = i.CustomerId
INNER JOIN Employee as e ON e.EmployeeId = c.SupportRepId
WHERE cast(strftime('%Y', i.InvoiceDate) as INT) = 2011 OR cast(strftime('%Y', i.InvoiceDate) as INT) = 2012
ORDER BY i.total DESC

--
SELECT count(total) FROM Invoice 
WHERE 
	total > 
		(
			SELECT 
				AVG(total)
			FROM 
				Invoice 
			WHERE 
			(cast(strftime('%Y', InvoiceDate) as INT) = 2011 OR cast(strftime('%Y', InvoiceDate) as INT) = 2012)) AND (cast(strftime('%Y', InvoiceDate) as INT) = 2011 OR cast(strftime('%Y', InvoiceDate) as INT) = 2012
		)
    
--
SELECT 
  ROUND(AVG(Total),2) AS [Average Total],
  cast(strftime('%Y', InvoiceDate) AS INT) AS [Year]
FROM Invoice
GROUP BY Year

-- Challenge 3
--
SELECT 
  e.FirstName, 
  e.LastName,
  e.EmployeeId,
  SUM(i.Total)AS [TOT_SALES]
FROM Customer c
INNER JOIN Invoice i ON i.CustomerId = c.CustomerId
INNER JOIN Employee e ON e.EmployeeId = c.SupportRepId
WHERE 
  (cast(strftime('%Y', InvoiceDate) as INT) = 2011 OR cast(strftime('%Y', InvoiceDate) as INT) = 2012) 
AND 
  i.Total > 11.66
GROUP BY e.EmployeeId

--
SELECT 
  e.FirstName, 
  e.LastName, 
  e.EmployeeId,
  ROUND(SUM(i.Total), 2) AS [TOT_SALES], 
  ROUND(SUM(i.Total) * .15, 2) AS [Commission] 
FROM Employee e 
INNER JOIN Customer c ON c.SupportRepId = e.EmployeeId
INNER JOIN Invoice i on i.CustomerId = c.CustomerId
WHERE (cast(strftime('%Y', i.InvoiceDate) as INT) = 2011 OR cast(strftime('%Y', i.InvoiceDate) as INT) = 2012)
GROUP BY e.EmployeeId
ORDER BY e.LastName

--
SELECT 
  e.FirstName, 
  e.LastName, 
  e.EmployeeId,
  ROUND(SUM(i.Total), 2) AS [TOT_SALES], 
  ROUND(SUM(i.Total) * .15, 2) AS [Commission]
FROM Employee e 
INNER JOIN Customer c ON c.SupportRepId = e.EmployeeId
INNER JOIN Invoice i on i.CustomerId = c.CustomerId
WHERE 
  (cast(strftime('%Y', i.InvoiceDate) as INT) = 2011 OR cast(strftime('%Y', i.InvoiceDate) as INT) = 2012)
GROUP BY e.EmployeeId

--
SELECT DISTINCT
  e.FirstName, 
  e.LastName, 
  e.EmployeeId,
  c.FirstName, 
  c.LastName
FROM Employee e 
INNER JOIN Customer c ON c.SupportRepId = e.EmployeeId
INNER JOIN Invoice i on i.CustomerId = c.CustomerId
WHERE 
  (cast(strftime('%Y', i.InvoiceDate) as INT) = 2011 OR cast(strftime('%Y', i.InvoiceDate) as INT) = 2012)
AND 
  e.EmployeeId = 3

--
SELECT DISTINCT
  e.FirstName, 
  e.LastName, 
  e.EmployeeId,
  c.FirstName, 
  c.LastName, 
  i.Total
FROM Employee e 
INNER JOIN Customer c ON c.SupportRepId = e.EmployeeId
INNER JOIN Invoice i on i.CustomerId = c.CustomerId
WHERE 
  (cast(strftime('%Y', i.InvoiceDate) as INT) = 2011 OR cast(strftime('%Y', i.InvoiceDate) as INT) = 2012)
AND 
  e.EmployeeId = 3
ORDER BY i.Total DESC -- John Doeein
