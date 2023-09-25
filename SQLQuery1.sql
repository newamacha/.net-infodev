--Day1

create database infodevTraining;

use infodevTraining;

create table college
(
 id int identity(1,1) primary key,
 college_name varchar(50)
)

INSERT INTO college VALUES('EVEREST')

ALTER TABLE college ADD [ADDRESS] VARCHAR(100)

INSERT INTO college (college_name,[address]) VALUES ('PRIME','NAYABAJAR')
INSERT INTO college (college_name,[address]) VALUES ('NCIT','Balkumari')

SELECT * FROM college

select distinct college_name from college







create table studentdetails
(
 id int identity(1,1) primary key,
 name varchar(50),
 address varchar(50),
 phone bigint,
 gender varchar(50)
)

create table library
(
 id int foreign key references studentdetails(id),
 lid int identity(1,1) primary key,
 bissued varchar(50),
 fineamt int
)

create table stdfees
(
 fid varchar(50) not null,
 id int foreign key references studentdetails(id),
 fees int not null,
 sem varchar(50)
)


insert into studentdetails values('Mansij','Kalanki',9840253456,'Male')
insert into studentdetails values('Krishna','Kalimati',9843454566,'Male')
insert into studentdetails values('Ram','Kuleshwor',9843454578,'Male')

insert into library (id,bissued,fineamt) values(1,'Supermansij the unsung hero',0)
insert into library (id,bissued,fineamt) values(3,'Mahabharat behind the imaginations',0)
insert into library (id,bissued,fineamt) values(4,'Raavan 2.0',0)

insert into stdfees(fid,id,fees,sem) values(9,1,90000,'7thsem')
insert into stdfees(fid,id,fees,sem) values(1,3,90000,'8thsem')
insert into stdfees(fid,id,fees,sem) values(1,3,80000,'4thsem')

select * from studentdetails
select * from library
select * from stdfees

drop table studentdetails
drop table library
drop table stdfees

delete from studentdetails
delete from library
delete from stdfees
-------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------

--Day 2

create table marks
(
 sid int identity(1,1)primary key,
 sname varchar(50) not null,
 class int not null,
 science float(2),
 math float,
 social decimal(18,2)
)
drop table marks

insert into marks values('Ram',7,80.5,77.5,85),('Shyam',8,88.5,67.5,95),('Hari',9,77.5,88.5,95),('Sita',7,90.5,67.5,75),('Rita',8,50.5,67.5,85),('Sakuntala',9,70.5,77.5,85)
insert into marks(sname,class,science,math) values('Kranti',9,70.5,77.5)

select* from marks

select avg(science) as Science_Average ,avg(math) as Math_Average ,avg(social) as Social_Average from marks
select class,convert(decimal(18,2) ,avg(science) )  as Average_Science from marks group by class

select count(sid) as TotalStudents from marks
select class,count(sid) as NoOfStudents from marks group by class

select min(science) as Lowest_ScienceMarks,max(science) as Highest_ScienceMarks from marks
select class,min(science) as Lowest_ScienceMarks,max(science) as Highest_ScienceMarks from marks group by class

select class,sum(science)as Total_MathMarksInClass,sum(math) as Total_MathMarksInClass,sum(social) as Total_MathMarksInClass from marks group by class

select sname,social from marks
select sname,isnull(social,10) as social from marks group by sname,social

--To convert datatype or limit values of field while displaying
select cast(science as decimal(18,2)) from marks
select convert(decimal(18,2) ,avg(science) ) from marks
select avg(science) from marks
select cast(science as varchar(20)) from marks
select convert(varchar(20) ,avg(science) ) from marks

--To add first name and Last name:
     --select concat(Fname,' ',Lname) as FullName from student

--To add space or special symbol in column name use big bracket[] or ''
     --select age as [student age] from student

-------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------
--Day 3

create table course
(
  id int identity(1,1) primary key,
  course_code varchar(50),
  course_name varchar(100),
  course_name_nep nvarchar(200),  --nvarchar size is double than varchar and accepts any characters like नेपाली
  credit_hour int,
  college_id int,

  foreign key(college_id) references college(id)
)

drop table course
select* from course
select* from college

insert into course(course_code,course_name,course_name_nep,credit_hour,college_id) values ('D320','dbms',Null,30,1),('m220','maths',Null,30,2)
insert into course(course_code,course_name,course_name_nep,credit_hour,college_id) values ('c310','C++',N'नेपाली',34,1)
insert into course(course_code,course_name,course_name_nep,credit_hour) values ('c110','C',N'नेपाली',20)


select* from college c inner join course cr on cr.college_id=c.id

select* from college c left outer join course cr on cr.college_id=c.id

select* from college c right outer join course cr on cr.college_id=c.id

select* from college c full outer join course cr on cr.college_id=c.id

select* from college  cross join course 


--Set operation example::

create table prim_teachers
(
	id int primary key,
	name varchar(20)
)

create table sec_teachers
(
	id int primary key,
	name varchar(20)
)

insert into prim_teachers values (1,'Ram'),(2,'Shyam'),(3,'Hari'),(4,'bhim'),(5,'kunti')
insert into sec_teachers values (1,'Laxman'),(2,'Dhalak'),(3,'Hari'),(4,'Duryodhan'),(5,'Sita')

select* from prim_teachers
select * from sec_teachers

select* from prim_teachers union select * from sec_teachers
select* from prim_teachers union all select * from sec_teachers

select* from prim_teachers intersect select * from sec_teachers

select* from prim_teachers except select * from sec_teachers


-------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------
--Day 4


--Having Clause (To use aggegrate function in condition we use having clause)::
select college_name from college  group by college_name having count(college_name)>0
select college_name from college c inner join course cr on cr.college_id=c.id group by college_name having count(college_name)>1

-- if exists::
if exists (select college_name from college  group by college_name having count(college_name)>0 )
   select 9
 --OR
if exists (select college_name from college  group by college_name having count(college_name)>0 )
begin
   select 9
end

--Temporary table:
select* into #tmp_course from course

select* from #tmp_course
select* from course

drop table #tmp_course


--Transactions:

begin try
begin transaction tr1
  select college_name from college
  select* from course
  delete from prim_teachers where name='kunti'
  update college set college_name='Advanced' where id =3
  select 999999999999
  commit transaction tr1 --completion of transaction and change is permanent
end try
begin catch
   if @@TRANCOUNT>0  --begin transaction statement increments @@trancount by 1 and rollback transaction statement sets @@trancount to 0
	 rollback transaction tr1 --goes back to original value
end catch


--error generating in Transaction

begin try
begin transaction tr2
	if not exists(select college_name from college)or not exists(select* from cou) 
	begin
		;throw 50001,'tet',1;
	end
	select college_name from college
	select* from cou
	commit transaction tr2
end try
begin catch
   if @@TRANCOUNT>0
	begin
		rollback transaction tr2
	end
   declare @message varchar(1000)=error_message();
   throw 50001,@message,1
end catch

--Procedure
create or alter procedure et_school (@cl varchar(50),@address varchar(50))
as 
	update college set address='Sanepa' where id =1
	select* from college where college_name like @cl and ADDRESS like @address
	select top 2 * from college

exec et_school @cl='everest',@address='Sanepa'

drop procedure et_school


select*from product