create database fp

-----------------LOGIN---------------- 

CREATE TABLE login(
    email varchar(50) NOT NULL,
    password varchar(10) NOT NULL,
	id int foreign key references sign_up_infos(userId)
);

--drop table login
select * from login
GO
create proc sp_insert
@email varchar( 50),@password varchar(10),@id int
as
begin
insert into login values( @email, @password,@id)
end
GO
---------------SIGNUP------------------
CREATE TABLE sign_up_infos(
userId INT PRIMARY KEY IDENTITY,
firstName varchar(25) NOT NULL,
lastName varchar(25) NOT NULL,
email varchar(100),
contactInfo varchar(15),
password varchar(10)
);
select * from sign_up_infos

--drop table sign_up_infos;
insert into sign_up_infos values('abebe', 'kebede','abie@gmail.com','0977654321','1234')
insert into sign_up_infos values('bekele', 'kebede1','abebe@gmail.com','0987854321','1234')
insert into sign_up_infos values('debeb', 'k','abe@gmail.com','0987654321','1234')
insert into sign_up_infos values('bekele', 'kebede1','abebe@gmail.com','0987854321','1234')

select * from sign_up_infos
delete from sign_up_infos where userId = 1;

GO
create PROC sp_ins
@fn varchar(25),
@ln varchar(25),
@email varchar(50),
@ci varchar(15),
@password varchar(10),
@id int output

AS
BEGIN
    insert into sign_up_infos values(@fn,@ln,@email,@ci,@password)
	select @id=(select SCOPE_IDENTITY())
end
GO

------------------------trigger that fires when same email and phone is inserted for creating acc---------------------------------------------------

create trigger trig_sameEmail
on sign_up_infos
after insert
as begin
if exists(select s.email from sign_up_infos s inner join inserted i on i.email=s.email and i.userId<>s.userId)
begin
raiserror('EMAIL ALREADY TAKEN CANNNOT CREATE ACCOUNT',16,1)
ROLLBACK
end
END

drop trigger trig_sameEmail;

go
CREATE TRIGGER trigsamePhone
on sign_up_infos
after insert
as begin
if exists (select s.contactInfo from sign_up_infos s inner join inserted i on i.contactInfo=s.contactInfo and i.userId<>s.userId)
begin
raiserror('USER WITH THIS PHONE NUMBER ALREADY EXISTS!!!',16,1)
ROLLBACK
end
end
go


----------EMPLOYEE--------------------

CREATE TABLE employee(
    employeeId int PRIMARY KEY identity,
    firstName varchar(25),
    lastName varchar(25),
    contactInfo varchar(15),
    DOB varchar(50),
    email varchar(50),
    Occupation varchar(25),
    gender varchar(6),
	salary money
);
alter table employee add constraint df_sal default '0' for salary


select *from employee
DELETE employee where employeeId=13
GO
create PROCEDURE ADDEMP

@fn varchar(25),
@ln varchar(25),
@continfo varchar(15),
@DOB varchar(50),
@email varchar(50),
@Occupation varchar(25),
@gender varchar(6)
AS
BEGIN
    insert into employee (firstName,lastName,contactInfo,DOB,email,Occupation,gender)values(@fn,@ln, @continfo, @DOB, @email, @Occupation, @gender)
end
GO

create PROCEDURE UPDATEEMP
@fn varchar(25),
@ln varchar(25),
@continfo varchar(15),
@DOB varchar(50),
@email varchar(50),
@Occupation varchar(50),
@gender varchar(6),
@id int
AS
BEGIN
    update employee set firstName = @fn, lastName = @ln, contactInfo = @continfo, DOB = @DOB, email = @email, 
    Occupation = @Occupation, gender = @gender where employeeid = @id
end
GO

CREATE PROCEDURE DELETEEMP
@id int
AS
BEGIN
    delete from employee where employeeid = @id
END
GO

GO
create function calcSalary
(@id int)
returns money
As BEGIN
DECLARE @occ VARCHAR(50)=(SELECT Occupation from employee where employeeId=@id)
declare @sal money=(SELECT salary from employee where employeeId=@id)
if (@occ='Event Photographer') set @sal=8000
else if @occ='Catering Manager' set @sal=8500
else if @occ='Chef' set @sal=6000
else if @occ='Venue Manager' set @sal=8500
else if @occ='Cleaning Staff' set @sal=3000
else if @occ='Decorator' set @sal=5000
else if @occ='DJ' set @sal=5500
else if @occ='Hair Removal Specialist' set @sal=3500
else if @occ='Hair stylist' set @sal=3000
else if @occ='Head Waiter' set @sal=3100
else if @occ='Makeup Artist' set @sal=6500
else if @occ='Patisserie' set @sal=4000
else if @occ='Personal Stylist' set @sal=4500
else if @occ='Photo Editor' set @sal=7000
else if @occ='Staff Coordinator' set @sal=5600
else if @occ='Truck Driver' set @sal=3500
else if @occ='Videographer' set @sal=8500
else if @occ='Waiter' set @sal=2500
else
set @sal=0
return @sal
END
GO

create trigger trigg_emp
on employee
after insert,update
as begin
declare @id int=(select employeeId from inserted)
declare @s money= (select dbo.calcSalary(@id))
select e.salary from employee e join inserted i on e.employeeId=i.employeeId
update employee set salary=@s WHERE employeeId=@id
end
go


alter trigger underAge
on employee
after insert
as begin
declare @a varchar(50)=(select DOB from inserted)
if DATEDIFF(year,@a,getdate())<18
begin
raiserror('under aged employee!!!',16,1)
rollback
end
end




--------------------------------------booking-------------------------------------------------------------------
create table booked
(
id int,
groomName varchar(20),
brideName varchar(20),
WeddingDate datetime,
guests int,
payment varchar (20) default ' ',
foreign key (id) references sign_up_infos(userId)
);
 
select * from booked


go
create PROC spInserted
@gn varchar(25),
@bn varchar(25),
@wedding datetime,
@g int,
@pay varchar(20)

AS
BEGIn
declare @lastid int;
set @lastid = SCOPE_IDENTITY()

    insert into booked values(@lastid,@gn,@bn,@wedding,@g,@pay)
end
GO

create table weddingInfos
(

groomName varchar(100),
brideName varchar(100),
packageName varchar(50),
price int,
guests int,
Weddingdate DATETIME,
userId int foreign key references sign_up_infos (userId)

);
DELETE FROM weddingInfos
select * from weddingInfos
--drop table weddingInfos
go
alter trigger no2Acc
on weddingInfos
after insert
as begin
declare @id int=(select userId from inserted)
if exists(select i.userId from inserted i join weddingInfos w on i.userId=w.userId)
begin
raiserror('This account has already booked',16,1)
rollback
end
end

GO
create PROCEDURE spInsert

@gn varchar(100),
@bn varchar(100),
@packageName varchar(50),
@price decimal(10,2),
@guests int,
@wd dateTime,
@id int
AS
BEGIN
    insert weddingInfos values(@gn, @bn, @packageName, @price, @guests,@wd,@id)
end
GO

create proc delBook
as begin
declare @wd datetime=(select weddingDate from weddingInfos)
declare @d datetime=(select DATEDIFF(day,@wd,Getdate()))
if @d>0
delete from weddingInfos 
end
go
--------------------------------trigger inserts records on booked table after there is an insert in weddingInfo----------------
create trigger trigins
on weddingInfos
after insert
as begin 
insert booked(id,groomName,brideName,weddingDate,guests)
select i.userId,i.groomName,i.brideName,i.weddingDate,i.guests from inserted i
end
------------------------------------------------------------------------------
go

go
create PROCEDURE spPopulate
@id int
AS
	BEGIN
		SELECT * FROM weddingInfos WHERE userId = @ID;
		end

go
create proc bookDisplay
@id int
as
begin
select userId,brideName,groomName,guests,Weddingdate from weddingInfos where userId=@id

end

exec bookDisplay 1
go
create PROCEDURE UPDATEBOOK
@gn varchar(100),
@bn varchar(100),
@wd datetime,
@payment varchar(20),
@guests varchar(6),
@id int
AS
BEGIN
    update booked set    
             groomName=@gn,brideName=@bn, guests = @guests ,payment = @payment , WeddingDate = @wd where id = @id
end

GO
create PROCEDURE DB
@id int
AS
BEGIN
    delete from booked where id = @id
END
GO

alter trigger updwedd
on booked
after update
as begin
update weddingInfos set groomName=i.groomName,brideName=i.brideName,guests=i.guests,Weddingdate=i.WeddingDate from inserted i join weddingInfos w on i.id=w.userId
end
go

create trigger delwed
on booked 
after delete
as begin
delete from weddingInfos where deleted.id=weddingInfos.userId
end
---------------------custom---------------------------


drop table packageDetail

select * from packageDetail


create table selected(
id int ,
BeautyService bit,
PhotographyService bit,
Catering bit,
DJ bit,
Decor bit,
VenueBooking bit,
foreign key (id) references sign_Up_infos(userId),
);
select * from selected
--drop table selected;
GO

go
create PROCEDURE PRICE
@id int
AS
BEGIN
	SELECT DBO.priceCalc (@id);
END
select * from selected
go



---------------------------trigger that fires if the inserted wedding date is near-----------------------------
go
create trigger trig_nearDate
on weddingInfos
after insert 
as begin
declare @wd date
set @wd=(select cast(weddingDate AS datetime)from inserted )
if datediff(day,getdate(),@wd)<15
begin
raiserror('Cannot book!!! Wedding date is near.',16,1)
rollback
end
end
go

-----------------------trigger that fires if there is booking on occupied wedding date------------------------
go
create trigger trig_full
on weddingInfos
after insert 
as begin
declare @wd date,@s int
set @wd=(select cast(weddingDate AS datetime)from inserted )
set @s=(select count(w.weddingDate)from weddingInfos w join inserted i on w.weddingDate=i.weddingDate)
if @s>2
begin
raiserror('CANNOT BOOK!! Inserted Wedding date is fully booked ',16,1)
rollback
end
end

-----------------------------triggger to stop booking morethan one wedding with the same email-----------

go
create trigger trig_noupdate
on booked
after update
as begin
declare @wd date
declare @id int
set @wd=(select WeddingDate from booked where id=@id)
if DATEDIFF(day,getdate(),@wd)<15
begin
raiserror('Cannot update any info the wedding is near!!!',16,1)
rollback
end
end
go
---------------------------------------------------------------------------
CREATE TABLE revenue(

total money,
vat money
);
--drop table revenue
select * from revenue

----------------------------Functions---------------------------------
go

create FUNCTION tot()
returns int
as begin
declare @tot int
set @tot=(select sum(price) from weddingInfos)
return @tot
end
go
select dbo.tot()

go
create function vat()
returns money
as begin
declare @v money,@t int
set @t=(select sum(price) from weddingInfos)
set @v=(@t*15)/100
return @v
end
go
select dbo.vat()
go
create trigger updateRev
on weddingInfos
after insert,update
as begin
declare @t money=(select dbo.tot())
declare @v money=(select dbo.vat())
if (select count(*) from revenue)=0
insert revenue(total,vat) select @t,@v 
else
update revenue set total=@t ,vat=@v
end
go 
create function totCust()
returns int
as begin
declare @c int
set @c=(select count(userId) from sign_up_infos)
return @c
end
go
select dbo.totCust()
go
create function totEmp()
returns int
as begin
declare @c int
set @c=(select count(employeeId) from employee)
return @c
end
go 

go
create function totalWedd()
returns int
as begin
declare @c int
set @c=(select count(userId)from weddingInfos)
return @c
end
go

create function calcProfit()
returns money
as begin
declare @s int=(select sum(salary) from employee)
declare @t int=(select total from revenue)
declare @v int=(select vat from revenue)
declare @p money
set @p=(@t-@v-@s)
return @p
end
go

-----------------------------------------------------custom--------------------------
create table packageDetail(
PD int identity primary key,
serviceName varchar(100),
price int

);
select * from packageDetail

insert into packageDetail values ('Beauty Service',6000)
insert into packageDetail values ('Photography Service',7000)
insert into packageDetail values ('Catering',10000)
insert into packageDetail values ('DJ',5000)
insert into packageDetail values ('Decor',12000)
insert into packageDetail values ('Venue Booking',60000)

go

create procedure sp_loadbooked
as
begin
	select * from weddingInfos;
end
go
CREATE proc loadsinglebooked
@id int
as
begin
	select * from weddingInfos where userId = @id;
end
go
create table custompack(
cuid int foreign key references sign_up_infos(userId),
BeautyService bit,
PhotographyService bit,
Catering bit,
DJ bit,
Decor bit,
VenueBooking bit);
--drop table custompack
select * from custompack

go
create proc sp_cust
@id int,
@BeautyService bit,
@PhotographyService bit,
@Catering bit,
@DJ bit,
@Decor bit,
@VenueBooking bit
as begin
insert into custompack values(@id,@BeautyService,@PhotographyService,@Catering,@DJ,@Decor,@VenueBooking)
end

GO
ALTER FUNCTION priceCalc
(@id int)
returns int
as
begin
  declare @price int = 0
--  DECLARE @id int=0
  if exists(select * from custompack where BeautyService = 1 and cuid = @id)
    select @price += price from packageDetail where serviceName = 'Beauty Service';
        
  if exists(select * from custompack where PhotographyService = 1 and cuid = @id)
    select @price += price from packageDetail where serviceName = 'Photography Service';
        
  if exists(select * from custompack where Catering = 1 and cuid = @id)
    select @price += price from packageDetail where serviceName = 'Catering';
        
  if exists(select * from custompack where DJ = 1 and cuid = @id)
    select @price += price from packageDetail where serviceName = 'DJ';
        
  if exists(select * from custompack where Decor = 1 and cuid = @id)
    select @price += price from packageDetail where serviceName = 'Decor';
        
  if exists(select * from custompack where VenueBooking = 1 and cuid = @id)
    select @price += price from packageDetail where serviceName = 'Venue Booking';
  
  return @price
end
go
select dbo.priceCalc(3)

go
alter function selectwedd
(@id int)
returns int
as begin
declare @c int=0
SET @c=(select count(*) from weddingInfos where userId = @id)
return @c
end
