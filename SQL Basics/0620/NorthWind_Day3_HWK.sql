-- All scenarios are based on Database NORTHWIND.

USE Northwind
GO

-- 1.      List all cities that have both Employees and Customers.
SELECT DISTINCT e.City
FROM Employees e
WHERE e.City IN (Select DISTINCT c.City from Customers c where c.City = e.City);

-- 2.      List all cities that have Customers but no Employee.

-- a.      Use sub-query
SELECT DISTINCT c.City
FROM Customers c
WHERE c.City NOT IN (Select DISTINCT e.City from Employees e where e.City = c.City);

-- b.      Do not use sub-query
SELECT DISTINCT c.city
FROM Customers c
LEFT JOIN Employees e ON c.city = e.city
WHERE e.city IS NULL;

-- 3.      List all products and their total order quantities throughout all orders.
SELECT p.ProductName, SUM(od.Quantity) AS TotalOrderQuantities
FROM [Order Details] od INNER JOIN Products p ON od.ProductID = p.ProductID
GROUP BY p.ProductName

-- 4.      List all Customer Cities and total products ordered by that city.

SELECT co.City, SUM(po.Quantity) AS TotalProductsOrder
FROM (SELECT od.OrderID, od.Quantity
FROM [Order Details] od) po
INNER JOIN (SELECT c.City, o.OrderID 
FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID) co
ON po.OrderID = co.OrderID
GROUP BY co.City

-- 5.      List all Customer Cities that have at least two customers.

-- a.      Use union
SELECT c1.city
FROM (
    SELECT city, COUNT(*) AS customer_count
    FROM Customers
    GROUP BY city
    HAVING COUNT(*) >= 2
) c1
UNION
SELECT c2.city
FROM (
    SELECT city, COUNT(*) AS customer_count
    FROM Customers
    GROUP BY city
    HAVING COUNT(*) >= 2
) c2

-- b.      Use sub-query and no union

SELECT DISTINCT c.City
FROM Customers c
WHERE c.City IN (
    SELECT city
    FROM Customers
    GROUP BY city
    HAVING COUNT(*) >= 2
)

-- 6.      List all Customer Cities that have ordered at least two different kinds of products.

SELECT co.City
FROM (SELECT od.OrderID, od.ProductID
FROM [Order Details] od) po
INNER JOIN (SELECT c.City, o.OrderID 
FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID) co
ON po.OrderID = co.OrderID
GROUP BY co.City
HAVING COUNT(po.ProductID) >= 2

-- 7.      List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.

SELECT DISTINCT co.ContactName
FROM (SELECT c.City, o.OrderID, c.ContactName
FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID) co
LEFT JOIN (SELECT od.OrderID, o.ShipCity
FROM [Order Details] od INNER JOIN Orders o
ON od.OrderID = o.OrderID) po
ON po.OrderID = co.OrderID
WHERE po.ShipCity != co.City

-- 8.      List 5 most popular products, their average price, and the customer city that ordered most quantity of it.

USE Northwind
GO

WITH ProductsAndCities AS (
    SELECT 
        p.ProductName, 
        co.City, 
        od.Quantity, 
        od.UnitPrice
    FROM 
        [Order Details] od 
        INNER JOIN Products p ON p.ProductID = od.ProductID
        INNER JOIN (
            SELECT 
                c.City, 
                o.OrderID
            FROM 
                Customers c 
                INNER JOIN Orders o ON c.CustomerID = o.CustomerID
        ) co ON od.OrderID = co.OrderID
),
AggregatedProducts AS (
    SELECT
        pc.ProductName,
        pc.City,
        SUM(pc.Quantity) AS TotalQuantity,
        AVG(pc.UnitPrice) AS AvgPrice
    FROM 
        ProductsAndCities pc
    GROUP BY 
        pc.ProductName, pc.City
),
MaxCityPerProduct AS (
    SELECT
        ap.ProductName,
        ap.City,
        ap.AvgPrice,
        RANK() OVER (PARTITION BY ap.ProductName ORDER BY ap.TotalQuantity DESC) AS CityRank
    FROM 
        AggregatedProducts ap
)
SELECT
    mpp.ProductName,
    mpp.AvgPrice,
    mpp.City
FROM 
    MaxCityPerProduct mpp
WHERE 
    mpp.CityRank = 1
ORDER BY 
    mpp.AvgPrice DESC
OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY

-- 9.      List all cities that have never ordered something but we have employees there.

-- a.      Use sub-query

SELECT c.City 
FROM Customers c
WHERE c.City NOT IN (
    SELECT o.ShipCity 
    FROM Orders o
) AND c.City IN (
    SELECT e.City
    FROM Employees e
)

-- b.      Do not use sub-query

SELECT c.City 
FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID WHERE o.CustomerID IS NULL
INTERSECT
SELECT c.City 
FROM Customers c LEFT JOIN Employees e ON c.City = e.City WHERE e.City IS NOT NULL

-- 10.  List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)

SELECT TOP 1 City FROM (
    SELECT e.City, COUNT(*) AS TotalOrders
    FROM Employees e
    JOIN Orders o ON e.EmployeeID = o.EmployeeID
    GROUP BY e.City
    ORDER BY TotalOrders DESC
) AS MostOrders
INTERSECT
(
    SELECT o.ShipCity AS City, SUM(od.Quantity) AS TotalQuantity
    FROM Orders o
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    GROUP BY o.ShipCity
    ORDER BY TotalQuantity DESC
) AS MostProducts

-- 11. How do you remove the duplicates record of a table?
-- Using the DISTINCT keyword