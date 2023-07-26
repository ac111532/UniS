SELECT
  CustomerFirstName,
  CustomerEmail,
  COUNT(OrderID) AS number_of_orders
FROM
  dbo."Order"
INNER JOIN
  dbo.Customer
ON
  dbo.Customer.CustomerID = dbo."Order".CustomerID
WHERE
  CustomerEmail LIKE '%@gmail.com'
  AND CustomerFirstName NOT LIKE 'A%'
GROUP BY
  CustomerFirstName,
  CustomerEmail
ORDER BY
  number_of_orders DESC
