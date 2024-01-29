CREATE DATABASE DB_SALES;

USE DB_SALES;

CREATE TABLE ROL(
idRol int primary key identity(1,1),
name varchar(50),
date_register datetime default getdate()
);

CREATE TABLE MENU(
idMenu int primary key identity(1,1),
name varchar(50),
icon varchar(50),
url varchar(50)

);

CREATE TABLE menuRol(
idMenuRol int primary key identity(1,1),
idMenu int references MENU(idMenu),
idRol int references ROL(idRol)
);

CREATE TABLE Users(
idUser int primary key identity(1,1),
nameCompleted varchar(100),
email varchar(40),
idRol int references ROL(idRol),
password varchar(40),
isActive bit default 1,
dateRegister datetime default getdate()
);

CREATE TABLE CATEGORY(
idCategory int primary key identity(1,1),
name varchar(40),
isActive bit default 1,
dateRegister datetime default getdate()
);

CREATE TABLE PRODUCT(
idPProduct int primary key identity(1,1),
name varchar(100),
idCategory int references CATEGORY(idCategory),
stock int,
price decimal(10,2),
isActive bit default 1,
dateRegister datetime default getdate()
);

CREATE TABLE DOCUMENTSALES(
idDocument int primary key identity(1,1),
lastDocument int not null,
dateRegister datetime default getdate()
);

CREATE TABLE SALES(
idSale int primary key identity(1,1),
typePay varchar(50),
total decimal(10,2),
dateRegister datetime default getdate()
);

CREATE TABLE SALEDETAIL(
idSaleDetail int primary key identity(1,1),
idSale int references SALES(idSale),
idProduct int references PRODUCT(idPProduct),
amount int,
price decimal(10,2),
total decimal(10,2)
);

-- Insert 5 records into ROL table
INSERT INTO ROL (name) VALUES
('Admin'),
('Manager'),
('Employee'),
('Customer'),
('Guest');

select *from ROL;

-- Insert 5 records into MENU table

insert into Menu(name,icon,url) values
('DashBoard','dashboard','/pages/dashboard'),
('Users','group','/pages/users'),
('Products','collections_bookmark','/pages/products'),
('Sale','currency_exchange','/pages/sale'),
('Hist Ventas','edit_note','/pages/histSale'),
('Reports','receipt','/pages/reports');

SELECT *FROM MENU;

-- Insert 5 records into menuRol table
INSERT INTO menuRol (idMenu, idRol) VALUES
(1, 1),
(2, 1),
(3, 1),
(4, 1),
(5, 1),
(5, 2),
(3, 2),
(4, 3),
(5, 3),
(6, 3),
(5, 4);
select * from menuRol;

-- Insert 5 records into Users table
INSERT INTO Users (nameCompleted, email, idRol, password) VALUES
('John Doe', 'john@example.com', 1, 'password123'),
('Jane Smith', 'jane@example.com', 2, 'securepassword'),
('Bob Johnson', 'bob@example.com', 3, 'pass123'),
('Alice Brown', 'alice@example.com', 4, 'strongpassword'),
('Guest User', 'guest@example.com', 5, 'guestpass');

SELECT *FROM Users;

-- Insert 5 records into CATEGORY table
INSERT INTO CATEGORY (name) VALUES
('Electronics'),
('Clothing'),
('Home Appliances'),
('Books'),
('Toys');

SELECT *FROM CATEGORY;

-- Insert 5 records into PRODUCT table
INSERT INTO PRODUCT (name, idCategory, stock, price) VALUES
('Laptop', 1, 50, 1200.00),
('T-shirt', 2, 100, 20.99),
('Microwave', 3, 30, 150.50),
('Programming Book', 4, 20, 35.00),
('Action Figure', 5, 50, 12.99);

SELECT *FROM PRODUCT;

-- Insert 5 records into DOCUMENTSALES table
INSERT INTO DOCUMENTSALES (lastDocument) VALUES
(0);

select *from DOCUMENTSALES;

-- Insert 5 records into SALES table
INSERT INTO SALES (typePay, total) VALUES
('Credit Card', 500.25),
('Cash', 250.75),
('PayPal', 120.50),
('Debit Card', 300.00),
('Cash', 150.20);

select * from SALES;

-- Insert 5 records into SALEDETAIL table
INSERT INTO SALEDETAIL (idSale, idProduct, amount, price, total) VALUES
(1, 1, 2, 600.00, 1200.00),
(2, 3, 1, 150.50, 150.50),
(3, 4, 3, 35.00, 105.00),
(4, 2, 5, 20.99, 104.95),
(5, 5, 2, 12.99, 25.98);

select *from SALEDETAIL;
