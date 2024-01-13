use AlohaTraining2

create table Customer
(
Id int identity(1,1) primary key not null,
Name varchar(50) not null,
Type int not null,
Gender int not null,
Department int not null
)

create table Address
(
Id int identity(1,1) primary key not null,
StateId int not null,
CityId int not null,
AreaId int not null,
ZipCode varchar(20) not null,
CustomerId int not null FOREIGN KEY REFERENCES Customer(Id)
)

--select * from State
--select * from City
--select * from area
--select * from Gender
--select * from Type
--select * from Department


select * from city where StateId = 1
select * from area where CityId = 9




insert into Customer values ( 'John Miller' , 1 , 1 , 1);
select * from Customer;


insert into Address values ( 1 , 9 , 4 , '123456' , 1);
delete from address where id = 2
select * from Address;


select Cust.Name , ty.Name , gen.Name , dept.Name , St.Name , cty.Name , ar.Name , Addr.ZipCode from customer Cust 
join Address Addr on Cust.Id = Addr.CustomerId 
join Type ty on ty.Id = Cust.Type
join Gender gen on gen.Id = Cust.Gender
join Department dept on dept.Id = Cust.Department
join State St on Addr.StateId = st.Id
join City cty on addr.CityId = cty.Id
join Area ar on addr.AreaId = ar.Id


create table product
(
Id int identity(1,1) primary key not null,
Name varchar(200),
price int
)

create table Orders 
(
Id int identity(1,1) primary key not null,
OrderDate varchar(200),
Quantity int not null,
Price int not null,
Total int not null,
ProductId int not null FOREIGN KEY REFERENCES product(Id),
CustomerId int not null FOREIGN KEY REFERENCES Customer(Id)
)

select * from customer
insert into Orders values('2023-10-20',1,500,500,3,1)

create table users
(
Id int identity(1,1) primary key not null,
UserName varchar(200),
Password varchar(200),
Email varchar(200),
PhoneNumber varchar(200)
)

insert into product values('Computer',40000)
insert into product values('Laptop',50000)
insert into product values('Mouse',500)

select * from product

select * from Customer
select * from product
select * from Address
select * from users
select * from Orders


select o.Id,c.Name,p.Name,o.OrderDate , o.Quantity,p.price,o.Total from orders O 
join Customer C on c.Id = o.CustomerId 
join product P on p.Id = O.ProductId


create PROCEDURE USP_OrdersReport(@startDate varchar(200),@endDate varchar(200))
AS
BEGIN
select o.Id as OrderId,c.Name as CustomerName,p.Name as ProductName,o.OrderDate as OrderDate, o.Quantity,p.price as Price,o.Total from orders O 
join Customer C on c.Id = o.CustomerId 
join product P on p.Id = O.ProductId
where O.OrderDate between @startDate and @endDate
END

exec USP_OrdersReport '2023-10-01','2023-10-20'

select * from users

