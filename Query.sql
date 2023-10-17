-- LEARNING T-SQL --

-- Create Database --
Create Database TestDB;

-- Create Table --
Create Table Employee(
	EmpId int Primary Key Identity(1,1),
	Name varchar(50) Not Null,
	City varchar(20) Not Null,
);

-- Alter Table --
Alter Table Employee
Add Salary numeric(6,2) Default 3000.00,
    ManagerId int Foreign Key references Employee(EmpId);

-- Drop Table --
--Drop Table Employee;

-- Insert Values --
Insert into Employee(Name, City) Values('Steve Rogers', 'Brooklyn');
Insert into Employee(Name, City) Values('Tony Stark', 'New York');
Insert into Employee(Name, City) Values('Thor Odinson', 'Asgard');
Insert into Employee(Name, City) Values('Natasha Romanoff', 'California');
Insert into Employee(Name, City) Values('Clint Barton', 'California');
Insert into Employee(Name, City) Values('Nick Fury', 'Washington DC');
Insert into Employee(Name, City) Values('Peggy Carter', 'Washington DC');

-- Read Values --
Select * from Employee;

-- Update Values --
Update Employee Set ManagerId = 7 Where EmpId = 4;

-- Find the Manager of employee
Select emp.Name as Employee, mgr.Name as Manager from Employee as emp
inner join
Employee as mgr
on
emp.ManagerId = mgr.EmpId
order by Manager, Employee;

-- Transaction --
-- Commit --
Begin Transaction
Update Employee Set Salary = 8000.00;
Commit;
-- Rollback --
Begin Transaction
Update Employee Set Salary = 8000.00;
Rollback;
-- Savepoint --
Begin Transaction
Save Transaction sp1;
Update Employee Set Salary = 5000.00;
Save Transaction sp2;
Delete from Employee Where EmpId = 5;
Select @@TRANCOUNT;
Rollback Transaction sp2;
Commit;


-- Procedural Programming --
declare @num1 int;
set @num1 = -5;
print(@num1);

declare @num2 int = 15;
print(@num2);

print('Sum: '+ cast(@num1 + @num2 as varchar));

--if statement --
if @num1 > 0
begin
	print('Positive');
end
else
begin
	print('Negative');
end
-- while loop --
declare @i int = 1;
while @i<=10
begin
	print(@i);
	set @i = @i + 1;
end

-- Exception Handling --
begin try
	declare @name varchar = 'Jack';
	declare @age int = 10;

	print(@name + 'is ' + @age + ' years old');
end try
begin catch
	Select ERROR_LINE() as [ERROR_LINE],
		   ERROR_MESSAGE() as [ERROR_MESSAGE],
		   ERROR_PROCEDURE() as [ERROR_PROCEDURE],
		   ERROR_SEVERITY() as [ERROR_SEVERITY],
		   ERROR_STATE() as [ERROR_STATE];
end catch

-- Indexes --
Create index employee_name_idx on Employee(Name);

-- Views --
Create view [Employee From Washington] as
select Name from Employee where City = 'Washington DC';

Select * from [Employee From Washington];

-- Stored procedures (doesn't return any value) --
Create procedure spGetEmployeeSalary as
begin
	Select Name, Salary from Employee;
end

exec spGetEmployeeSalary;

-- Stored functions (returns a value) --
Create function TaxAmount(@amount numeric(6,2)) returns numeric(6,2) as
begin
	return @amount * 0.1;
end

Select Name, Salary, dbo.TaxAmount(Salary) as Tax from Employee;

-- Triggers --
Create trigger empSalaryCheck on Employee for update
as
begin
	declare @oldSal numeric(6,2);
	declare @newSal numeric(6,2);

	select @oldSal = Salary from deleted;
	select @newSal = Salary from inserted;

	if(@oldSal > @newSal)
	begin
		print('New Salary cannot be less than old salary');
		Rollback;
	end
end

Update Employee Set Salary = Salary+1;

-- Cursor --

Declare empCur cursor for Select Name From Employee;
open empCur;
Declare @name varchar(20);
Fetch next from empCur into @name;
while @@FETCH_STATUS = 0
begin
	print @name;
	Fetch next from empCur into @name;
end
close empCur;
deallocate empCur;