create database Project;

use Project;



create table Items(
Item_ID int primary key,
Quantity int,
Sale_Price int
);

create table Store(
Store_ID int primary key,
Store_Name varchar(100),
Location varchar(100)
);

create table In_Store(
Item_ID int references Items(Item_ID),
Store_ID int references Store(Store_ID),
Quantity int
);

create table Customer(
ID int primary key,
Name varchar(100)
);

create table Sold(
Sold_ID int primary key,
Sold_Date date,
Bill_amount int,
Profit int,
Store_ID int references Store(Store_ID),
Cust_ID int references Customer(ID)
);

create table Customer_Items(
Sold_ID int references Sold(Sold_ID),
Item_ID int references Items(Item_ID),
Quantity int
);

create table Employee(
CNIC bigint primary key,
Starting_date date,
F_name varchar(100),
L_name varchar(100),
E_shift varchar(100),
Salary int,
Store_ID int references Store(Store_ID),
Manager_ID bigint references Employee(CNIC)
);


create table Purchase(
Purchase_ID int primary key,
Purchase_date date,
Total_cost int,
Store_ID int references Store(Store_ID)
);

create table Warehouse(
Warehouse_ID int primary key,
Location varchar(100)
);

create table "Phone Number (Warehouse)"(
Warehouse_ID int references Warehouse(Warehouse_ID),
Phone_no varchar(100)
);

create table Stock(
Stock_ID int,
Quantity int,
Warehouse_ID int references Warehouse(Warehouse_ID),
primary key (Stock_ID, Warehouse_ID)
);

create table Carton(
Item_ID int primary key,
Stock_ID int ,
Item varchar(100),
Quantity int,
Price int,
perPrice int
);


create table Purchased_Items(
Stock_ID int ,
Purchase_ID int references Purchase(Purchase_ID),
primary key(Stock_ID, Purchase_ID),
Quantity int,
Purchase_Price int);

CREATE TABLE Login
(
	userName varchar(20) NOT NULL PRIMARY KEY,
	password varchar(50) NOT NULL
)

insert into Items values(1, 5, 300),
(2, 10, 700),
(3, 15, 300),
(4, 5,  250),
(5, 5,  300),
(6, 15, 150),
(7, 10,300),
(8, 15, 300),
(9, 10, 250),
(10, 24, 850),
(11, 5, 300),
(12, 15, 350),
(13, 10, 300),
(14, 5, 300),
(15, 5, 300);


insert into Store values(1450, 'ABC Mart', 'Islamabad');

insert into In_Store values(1, 1450, 5),
(4, 1450, 2),
(5, 1450, 1),
(6, 1450, 11),
(9, 1450, 9),
(14, 1450, 5);

insert into Customer values(01, 'Talha Tanveer'),
(02, 'Bahadur Ali'),
(03, 'Muhamamd Armughan'),
(04, 'Osaid Ameer'),
(05, 'Sahil Raja'),
(06, 'Zakariya Shahid'),
(07, 'Haider Asif'),
(08, 'Sohaib Kiyani');

insert into Sold values(111, CONVERT(date, '08-May-2022'), 450, 200, 1450, 01),
(112, CONVERT(date, '05-May-2022'), 350, 100, 1450, 02),
(113, CONVERT(date, '05-May-2022'), 250, 50, 1450, 03),
(114, CONVERT(date, '29-April-2022'), 700, 150, 1450, 04),
(115, CONVERT(date, '29-April-2022'), 350, 100, 1450, 05),
(116, CONVERT(date, '27-April-2022'), 850, 250, 1450, 06),
(117, CONVERT(date, '23-April-2022'), 300, 50, 1450, 07),
(118, CONVERT(date, '19-April-2022'), 350, 100, 1450, 08);

insert into Customer_Items values(111, 11, 5),
(111, 6, 15),
(112, 8, 15),
(112, 1, 1),
(113, 4, 5),
(114, 3, 15),
(114, 4, 5),
(114, 6, 15),
(115, 12, 15),
(116, 2, 10),
(116, 6, 15),
(117, 14, 5),
(118, 10, 12);

insert into Employee values(1234567890987, CONVERT(date, '20-June-2021'), 'Ali', 'Raza', 'Morning', 15000, 1450, 1234567890987),
(1234567890913, CONVERT(date, '30-June-2021'), 'Ahmed', 'Hassan', 'Morning', 10000, 1450, 1234567890987),
(1234567890426, CONVERT(date, '15-July-2021'), 'Hassan', 'Ali', 'Morning', 10000, 1450, 1234567890987),
(1234567890263, CONVERT(date, '10-July-2021'), 'Khalid', 'Muhammad', 'Afternoon', 15000, 1450, 1234567890263),
(1234567890842, CONVERT(date, '17-January-2022'), 'Umer', 'Touseef', 'Afternoon', 10000, 1450, 1234567890263),
(5424567890843, CONVERT(date, '2-January-2022'), 'Mirza', 'Imran', 'Afternoon', 10000, 1450, 1234567890263),
(8324567890015, CONVERT(date, '10-January-2022'), 'Faris', 'Shafi', 'Night', 17000, 1450, 8324567890015),
(9324567890013, CONVERT(date, '7-February-2022'), 'Hasan', 'Raheem', 'Night', 12000, 1450, 8324567890015),
(0454567890017, CONVERT(date, '9-February-2022'), 'Ali', 'Zafar', 'Night', 12000, 1450, 8324567890015);


insert into Warehouse values
	(1, 'Islamabad'),
	(2, 'Karachi'),
	(3, 'Lahore'),
	(4, 'Faislabad'),
	(5, 'Sialkot'),
	(6, 'Quetta'),
	(7, 'Peshawar'),
	(8, 'Mardan'),
	(9, 'Rawalpindi');


insert into "Phone Number (Warehouse)" values
	(1, '0333-3333331'),
	(2, '0333-3333332'),
	(3, '0333-3333333'),
	(4, '0333-3333334'),
	(5, '0333-3333335'),
	(6, '0333-3333336'),
	(7, '0333-3333337'),
	(8, '0333-3333338'),
	(9, '0333-3333339');


insert into Stock values
	(1, 100, 1),
	(1, 200, 2),
	(1, 600, 3),
	(2, 20, 3),
	(2, 100, 1),
	(3, 600, 1),
	(1, 800, 4),
	(1, 100, 5),
	(1, 500, 6),
	(1, 400, 7),
	(1, 900, 8),
	(1, 800, 9),
	(4, 600, 2),
	(4, 500, 5),
	(5, 100, 1),
	(6, 100, 2),
	(7, 500, 3),
	(8, 900, 4),
	(9, 100, 5),
	(10, 100, 6),
	(9, 1000, 7);


insert into Carton values
	(1, 1, 'CocoMo', 12, 50, 5),
	(2, 2, 'Sprite', 6, 500, 100),
	(3, 3, 'Lays', 50, 800, 20),
	(4, 4, 'Nimko', 12, 50, 5),
	(5, 5, 'Chat Masala', 12, 100, 10),
	(6, 6, 'Shan Achar', 6, 500, 100),
	(7, 7, 'Juice', 30, 600, 30),
	(8, 8, 'Lux', 12, 500, 50),
	(9, 9, 'Detol', 12, 500, 50),
	(10, 10, 'Colgate', 12, 1000, 100);


insert into Purchase values
	(1, CONVERT(date, '1-July-2021'), 5500, 1450),
	(2, CONVERT(date, '1-September-2021'), 4750, 1450),
	(3, CONVERT(date, '1-November-2021'), 8500, 1450);


insert into Purchased_Items values
	(1, 1, 10, 50),
	(2, 1, 10, 500),
	(1, 2, 5, 50),
	(3, 2, 5, 800),
	(4, 2, 10, 50),
	(3, 3, 10, 800),
	(4, 3, 10, 50);
	

Insert into Login VALUES ('admin', '0644503CBFC425ADABD72095739CB720F5BB7026');
