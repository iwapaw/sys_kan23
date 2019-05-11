-- Status table --
if not exists(select * from dbo.Status where Name = 'To Do')
	insert into dbo.Status(Name, Ordinal) values(N'To Do', 0);

if not exists(select * from dbo.Status where Name = 'In Progress')
	insert into dbo.Status(Name, Ordinal) values(N'In Progress', 1);

if not exists(select * from dbo.Status where Name = 'Done')
	insert into dbo.Status(Name, Ordinal) values(N'Done', 2);