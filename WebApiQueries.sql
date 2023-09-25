create database WebApiEg

create table student
(
	Id int identity(1,1),
	First_Name varchar(50),
    Last_Name varchar(50),

)
-----------------------------------------------------
create or alter proc usp_student_save
(@FName varchar(50),@LName varchar(50))
as 
begin
	insert into student([First_Name],[Last_Name]) values(@FName,@LName);
end
go

exec usp_student_save @FName='Shyam',@LName='Karki'

--select* from student
---------------------------------------------------
create or alter proc usp_student_display
(@Id int)
as 
begin
	select * from student where id=@Id;
end
go

exec usp_student_display @Id=2;
---------------------------------------------------
create or alter proc usp_student_delete
(@Id int)
as 
begin
	delete from student where id=@Id;
end
go

exec usp_student_delete @Id=5;
-------------------------------------------
create or alter proc usp_student_displayAll
as 
begin
	select * from student;
end
go

exec usp_student_displayAll;

