USE RestaurantDB;

DROP TABLE IF EXISTS PurchaseOrderline;
DROP FUNCTION IF EXISTS getPriceInv;
DROP TABLE IF EXISTS PurchaseOrders;
DROP TABLE IF EXISTS Orderline;
DROP FUNCTION IF EXISTS getPrice;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Employees;
DROP TABLE IF EXISTS Inventory;
DROP TABLE IF EXISTS Suppliers;
DROP TABLE IF EXISTS Menu;

CREATE TABLE Menu(
	MenuID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	MenuType VARCHAR(20),
	MenuName VARCHAR(30),
	MenuDescr VARCHAR(100),
	Price DEC(5, 2)
);

INSERT INTO Menu(MenuType, MenuName, Price,MenuDescr) VALUES
	('Breakfast', 'Bagel', 1.99,'Enjoy a delicious bagel'),
	('Breakfast', 'Omelette', 2.49,'Award winning straight from the chicken'),
	('Breakfast', 'Toast', 0.99,'The yummiest toast on the planet'),
	('Breakfast', 'French Toast', 1.99,'Shipped straight from France'),
	('Breakfast', 'Bacon', 2.99,'No pigs were harmed in the making of this bacon'),
	('Lunch', 'Burger', 4.99,'Meaty burger for your cravings'),
	('Lunch', 'Chicken Burger', 4.99,'Our chicken is lab grown and no chicken was harmed'),
	('Lunch', 'Veggie Burger', 5.29,'All kinds of delicious vegetables'),
	('Lunch', 'Chicken Salad', 15.99,'Delicious'),
	('Lunch', 'Shawarma', 19.99,'The best shawrma in town'),
	('Dinner', 'Steak', 24.99,'Our steak is created using quantum technology'),
	('Dinner', 'Prime Rib', 34.99,'Best prime ribs'),
	('Dinner', 'Pasta', 19.99,'Pasta is good'),
	('Dinner', 'Salad', 9.99,'Yummy salad'),
	('Dinner', 'Garlic Bread', 4.99,'garlic bread');


CREATE TABLE Suppliers(
	SupplierID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	SupplierName VARCHAR(30)
);

INSERT INTO Suppliers(SupplierName) VALUES
	('WalMart'),
	('Pure Canadian Farm'),
	('Suspicious Meats');

CREATE TABLE Inventory(
	ProductID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	ProductName VARCHAR(30),
	Price DEC(5, 2),
	OnHand INT NOT NULL,
	SupplierID INT FOREIGN KEY REFERENCES Suppliers(SupplierID) NOT NULL
);

INSERT INTO Inventory(ProductName, Price, OnHand, SupplierID) VALUES
	('Lettuce', 0.29, 99, 1),
	('Tomato', 0.34, 59, 2),
	('Cow', 500.48, 5, 3),
	('Bread', 0.99, 78, 1),
	('Spaghetti', 1.99, 65, 1),
	('Chicken', 20.99, 30, 3);

CREATE TABLE Employees(
	EmployeeID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	EmployeeName VARCHAR(50),
	EmployeeUserName VARCHAR(50),
	EmployeePassword VARCHAR(50)
);

INSERT INTO Employees(EmployeeName, EmployeeUserName, EmployeePassword) VALUES
	('test', 'test', 'test'),
	('Abdul', 'Abdul', 'test');

CREATE TABLE Orders(
	OrderID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	OrderDate DATETIME,
	EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID) NOT NULL
);

INSERT INTO Orders(OrderDate, EmployeeID) VALUES
	('11/15/2018 13:42:53', 1);

GO
CREATE FUNCTION dbo.getPrice(@MenuID INT, @Quantity INT)
RETURNS DEC(10, 2)
AS BEGIN
	RETURN
		(SELECT CONVERT(DECIMAL(5,2), @Quantity) * Price
		FROM Menu
		WHERE MenuID = @MenuID)
END
GO

CREATE TABLE Orderline(
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID) NOT NULL,
	MenuID INT FOREIGN KEY REFERENCES Menu(MenuID) NOT NULL,
	Quantity INT,
	SalesPrice AS dbo.getPrice(MenuID, Quantity)
);

INSERT INTO Orderline(OrderID, MenuID, Quantity) VALUES
	(1, 11, 2); 

CREATE TABLE PurchaseOrders(
	PurchaseOrderID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	PurchaseOrderDate DATETIME,
	EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID)
);

GO
CREATE FUNCTION dbo.getPriceInv(@ProductID INT, @Quantity INT)
RETURNS DEC(10, 2)
AS BEGIN
	RETURN
		(SELECT CONVERT(DECIMAL(5,2), @Quantity) * Price
		FROM Inventory
		WHERE ProductID = @ProductID)
END
GO

CREATE TABLE PurchaseOrderline(
	PurchaseOrderID INT FOREIGN KEY REFERENCES PurchaseOrders(PurchaseOrderID),
	ProductID INT FOREIGN KEY REFERENCES Inventory(ProductID),
	Quantity INT,
	SalesPrice AS dbo.getPriceInv(ProductID, Quantity)
);
