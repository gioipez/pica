CREATE TABLE Items (
	ItemId UNIQUEIDENTIFIER PRIMARY KEY,
	ProdId INT ,
	ProductName VARCHAR(50),
	PartNum VARCHAR(20),
	Price DECIMAL,
	Quantity INT ,
	OrdId UNIQUEIDENTIFIER
)


CREATE TABLE Orders (
	OrdId UNIQUEIDENTIFIER PRIMARY KEY,
	CustId varchar(10),
	OrderDate DATETIME,
	Price DECIMAL,
	Status VARCHAR(10),
	Comments VARCHAR(4000)
)

CREATE TABLE Customer (
	CustId varchar(10) PRIMARY KEY,
	FName VARCHAR(40),
	LName VARCHAR(40),
	PhoneNumber VARCHAR(40),
	Email VARCHAR(50),
	Password VARCHAR(40),
	CreditCardType VARCHAR(40),
	CreditCardNumber VARCHAR(40),
	Status VARCHAR(10)
)


drop table Orders
drop table Items
drop table Customer

/*Datos */

INSERT into Customer
values ('1013605535','Yesid','Gutierrez', '301425784','sdfs@dfsd.com','123456','Visa','1231231', 'Activo')


/*
select * from Customer

*/