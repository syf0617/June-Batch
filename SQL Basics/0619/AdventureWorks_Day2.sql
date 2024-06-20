USE AdventureWorks2019
GO

-- 1.      How many products can you find in the Production.Product table?

SELECT DISTINCT COUNT(pp.Name)
FROM Production.Product pp

-- 2.      Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.

SELECT DISTINCT COUNT(pp.Name)
FROM Production.Product pp
WHERE pp.ProductSubcategoryID IS NOT NULL

-- 3.      How many Products reside in each SubCategory? Write a query to display the results with the following titles.

-- ProductSubcategoryID CountedProducts

-- -------------------- ---------------

SELECT DISTINCT pp.ProductSubcategoryID, COUNT(pp.Name) AS CountedProducts
FROM Production.Product pp
WHERE pp.ProductSubcategoryID IS NOT NULL
GROUP BY pp.ProductSubcategoryID

-- 4.      How many products that do not have a product subcategory.

SELECT DISTINCT COUNT(pp.Name)
FROM Production.Product pp
WHERE pp.ProductSubcategoryID IS NULL

-- 5.      Write a query to list the sum of products quantity in the Production.ProductInventory table.

SELECT DISTINCT ppi.ProductID, SUM(ppi.Quantity)
FROM Production.ProductInventory ppi
GROUP BY ppi.ProductID

-- 6.    Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.

--               ProductID    TheSum

--               -----------        ----------

SELECT DISTINCT ppi.ProductID, SUM(ppi.Quantity) AS TheSum
FROM Production.ProductInventory ppi
WHERE ppi.LocationID = 40 AND ppi.Quantity < 100
GROUP BY ppi.ProductID

-- 7.    Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100

--     Shelf      ProductID    TheSum

--     ----------   -----------        -----------

SELECT DISTINCT ppi.ProductID, ppi.Shelf, SUM(ppi.Quantity) AS TheSum
FROM Production.ProductInventory ppi
WHERE ppi.LocationID = 40 AND ppi.Quantity < 100
GROUP BY ppi.ProductID, ppi.Shelf

-- 8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.

SELECT DISTINCT ppi.ProductID, AVG(ppi.Quantity)
FROM Production.ProductInventory ppi
WHERE ppi.LocationID = 10
GROUP BY ppi.ProductID


-- 9.    Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory

--     ProductID   Shelf      TheAvg

--     ----------- ---------- -----------

SELECT DISTINCT ppi.ProductID, ppi.Shelf, AVG(ppi.Quantity) AS TheAvg
FROM Production.ProductInventory ppi
WHERE ppi.LocationID = 10
GROUP BY ppi.ProductID, ppi.Shelf

-- 10.  Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory

--     ProductID   Shelf      TheAvg

--     ----------- ---------- -----------

SELECT DISTINCT ppi.ProductID, ppi.Shelf, AVG(ppi.Quantity) AS TheAvg
FROM Production.ProductInventory ppi
WHERE ppi.LocationID = 10 AND ppi.Shelf != 'N/A'
GROUP BY ppi.ProductID, ppi.Shelf

-- 11.  List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.

--     Color                        Class              TheCount          AvgPrice

--     -------------- - -----    -----------            ---------------------

SELECT DISTINCT pp.Color, pp.Class, Count(pp.ProductID) AS TheCount, AVG(pp.ListPrice) AS AvgPrice
FROM Production.Product pp
WHERE pp.Color IS NOT NULL AND pp.Class IS NOT NULL
GROUP BY pp.Color, pp.Class

-- Joins:

-- 12.   Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.

--     Country                        Province

--     ---------                          ----------------------

SELECT DISTINCT pc.Name AS Country, ps.Name AS Province 
FROM Person.CountryRegion pc INNER JOIN Person.StateProvince ps ON pc.CountryRegionCode = ps.CountryRegionCode


-- 13.  Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.

--     Country                        Province

--     ---------                          ----------------------

SELECT DISTINCT pc.Name AS Country, ps.Name AS Province
FROM Person.CountryRegion pc INNER JOIN Person.StateProvince ps ON pc.CountryRegionCode = ps.CountryRegionCode
WHERE pc.Name IN ('Germany', 'Canada')

--  Using Northwnd Database: (Use aliases for all the Joins)

USE Northwind
GO

-- 14.  List all Products that has been sold at least once in last 25 years.

WITH OrderDetails
AS(
    SELECT o.orderDate, od.ProductID
    FROM Orders o Inner JOIN [Order Details] od ON o.OrderID = od.OrderID
    WHERE o.orderDate >= CAST(DATEADD(year, -27, GETDATE()) AS DATETIME) 
)
SELECT DISTINCT p.ProductName
FROM Products p INNER JOIN OrderDetails od2 ON p.ProductID = od2.ProductID
GROUP BY p.ProductName

-- 15.  List top 5 locations (Zip Code) where the products sold most.

USE Northwind
GO

WITH ProductsSold
AS(
    SELECT TOP 5 o.shipPostalCode, SUM(od.Quantity) AS productsSold
    FROM Orders o Inner JOIN [Order Details] od ON o.OrderID = od.OrderID
    WHERE o.shipPostalCode IS NOT NULL
    GROUP BY o.shipPostalCode
    ORDER BY productsSold DESC
)
SELECT ps.shipPostalCode
FROM ProductsSold ps

-- 16.  List top 5 locations (Zip Code) where the products sold most in last 25 years.

USE Northwind
GO

WITH ProductsSold
AS(
    SELECT TOP 5 o.shipPostalCode, SUM(od.Quantity) AS productsSold
    FROM Orders o Inner JOIN [Order Details] od ON o.OrderID = od.OrderID
    WHERE o.shipPostalCode IS NOT NULL AND o.orderDate >= CAST(DATEADD(year, -27, GETDATE()) AS DATETIME) 
    GROUP BY o.shipPostalCode
    ORDER BY productsSold DESC
)
SELECT ps.shipPostalCode
FROM ProductsSold ps

-- 17.   List all city names and number of customers in that city.    

SELECT c. City, COUNT(c.CustomerID) AS NumberOfCustomers
FROM Customers c
GROUP BY c.city

-- 18.  List city names which have more than 2 customers, and number of customers in that city

SELECT dt.City, dt. NumberOfCustomers
FROM (SELECT c. City, COUNT(c.CustomerID) AS NumberOfCustomers
FROM Customers c
GROUP BY c.city) dt
WHERE dt.NumberOfCustomers > 2

-- 19.  List the names of customers who placed orders after 1/1/98 with order date.

SELECT c.ContactName
FROM (SELECT DISTINCT o.CustomerID
FROM Orders o
WHERE o.orderDate >= '1998-1-1') dt LEFT JOIN Customers c ON dt.CustomerID = c.CustomerID 

-- 20.  List the names of all customers with most recent order dates

SELECT c.ContactName, dt.MostRecentOrderDates
FROM (SELECT o.CustomerID, MAX(o.OrderDate) AS MostRecentOrderDates
FROM Orders o
GROUP BY o.CustomerID) dt LEFT JOIN Customers c ON dt.CustomerID = c.CustomerID 

-- 21.  Display the names of all customers  along with the  count of products they bought 

SELECT c.ContactName, dt.CountOfProductsBought
FROM (SELECT o.CustomerID, COUNT(od.ProductID) AS CountOfProductsBought
FROM Orders o Inner JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.CustomerID) dt LEFT JOIN Customers c ON dt.CustomerID = c.CustomerID 

-- 22.  Display the customer ids who bought more than 100 Products with count of products.

SELECT dt.CustomerID, dt.CountOfProductsBought
FROM (SELECT o.CustomerID, COUNT(od.ProductID) AS CountOfProductsBought
FROM Orders o Inner JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.CustomerID) dt
WHERE dt.CountOfProductsBought > 100

-- 23.  List all of the possible ways that suppliers can ship their products. Display the results as below

--     Supplier Company Name                Shipping Company Name

--     ---------------------------------            ----------------------------------

SELECT su.CompanyName AS [Supplier Company Name], sh.CompanyName AS [Shipping Company Name]
FROM Suppliers su CROSS JOIN Shippers sh

-- 24.  Display the products order each day. Show Order date and Product Name.

SELECT o.OrderDate, p.ProductName
FROM Orders o
INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
LEFT JOIN Products p ON od.ProductID = p.ProductID
ORDER BY o.OrderDate

-- 25.  Displays pairs of employees who have the same job title.

SELECT (e1.FirstName + ' ' + e1.LastName) AS Employee1, (e2.FirstName + ' ' + e2.LastName) AS Employee2
FROM Employees e1, Employees e2
WHERE e1.EmployeeID < e2.EmployeeID AND e1.Title = e2.Title

-- 26.  Display all the Managers who have more than 2 employees reporting to them.

USE Northwind
GO

WITH Managers
AS(
    SELECT e.ReportsTo AS ManagerID, COUNT(e.ReportsTo) AS NumOfEmployeesReporting
    FROM Employees e
    WHERE ReportsTo IS NOT NULL
    GROUP BY e.ReportsTo
    HAVING COUNT(*) > 2
)
SELECT (e.FirstName + ' ' + e.LastName) AS ManagerName, m.NumOfEmployeesReporting
FROM Managers m LEFT JOIN Employees e ON m.ManagerID = e.EmployeeID

-- 27.  Display the customers and suppliers by city. The results should have the following columns

-- City

-- Name

-- Contact Name,

-- Type (Customer or Supplier)

SELECT c.City, c.CompanyName AS Name, c.ContactName, 'Customer' AS Type
FROM Customers c
UNION ALL
SELECT s.City, s.CompanyName AS Name, s.ContactName, 'Supplier' AS Type
FROM Suppliers s
ORDER BY City, Type, Name