select* from #tmp_course

-------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------
--Day 5


--procedure eg

create table product
(
	id int identity(1,1) primary key,
	pname varchar(50) not null,
	price bigint,
	quantity bigint
)

drop table product
insert into product values('Iphone14',195000,10),
	('PocoX9Pro',60000,40),
	('HpLaptop',500000,20),
	('LG Refrigerator',950000,30)

create or alter procedure pc_product (@pname varchar(100),@price bigint)
as
	begin try
	begin transaction 
		if not exists(select * from product where pname=@pname)
		begin
			--;throw 50001,'tet',1;
			raiserror('mistake bho',16,1);
			return
		end
		select * from product
		update product set price=@price where pname=@pname
		commit transaction
	end try
	begin catch
	   if @@TRANCOUNT>0
		begin
			rollback transaction
		end
	   declare @message varchar(1000)=error_message()+'ok';
	   throw 50001,@message,1;
	end catch

go
exec pc_product @pname='Lg Refrigerator',@price=999911



--Function eg

create or alter function getprice(@pname varchar(100))
returns bigint
as
begin
	return(select top 1 price from product where pname like @pname+'%')
end

go 
select dbo.getprice('po')

--view eg

-------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------
--Day 6


--to get the recent value of identity variable

declare @maxid int
insert into product values('Macbookpro',170000,31)
set @maxid = scope_identity();

select* from product

--Creating type

create table productseller
(
	sid int identity(1,1) primary key,
	sname varchar(100),
	saddress varchar(100),
	phone bigint,
	id int foreign key references product(id)
)

insert into productseller values('Rishi','Kalimati',9867543456,1)

create type tbl_typ as table
(
	sname varchar(100),
	saddress varchar(100),
	phone bigint
)

--master and detail table insertion eg

create or alter procedure pc2_product (@pname varchar(100), @price bigint, @seller tbl_typ readonly)
as
	begin try
	begin transaction 
		if not exists(select * from product where pname=@pname)
		begin
			--;throw 50001,'tet',1;
			raiserror('mistake bho',16,1);
			return
		end

		declare @maxid int
		insert into product values('MtechSpeaker',20000,3)
		set @maxid = scope_identity();

		insert into productseller
		(
			sname,
			saddress,
			phone,
			id
		)select sname,saddress ,phone,@maxid from @seller 
		commit transaction
	end try
	begin catch
	   if @@TRANCOUNT>0
		begin
			rollback transaction
		end
	   declare @message varchar(1000)=error_message()+'ok';
	   throw 50001,@message,1;
	end catch

go
declare @t tbl_typ 
	insert into @t (sname,saddress,phone)values ('Ritu','Kalinchowk',9867544556),('Ramdev','Kuleshwor',9867543456)
		exec pc2_product @pname='Lg Refrigerator',@price=999911,@seller=@t

select*from product
select* from productseller