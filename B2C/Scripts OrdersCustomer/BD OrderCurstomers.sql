CREATE TABLE Items (
	ItemId UNIQUEIDENTIFIER PRIMARY KEY,
	ProdId INT ,
	ProductName VARCHAR(50),
	PartNum VARCHAR(20),
	Price DECIMAL,
	Quantity INT 
)


/*Datos */

INSERT INTO Items
values (NEWID(), 1, '?espectaculo 1','asd',5000,1)


/*
select * from Items

*/