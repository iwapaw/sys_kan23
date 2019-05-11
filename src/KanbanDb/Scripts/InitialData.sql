declare 
	@statusId int,
	@taskId int,
	@userId int

-- User table --
if not exists(select * from [User] where Login = 'TestLogin1')
	insert into [dbo].[User] ([Login], [Password], [Firstname], [Lastname], [Email])
		values (N'TestLogin1', N'Password', N'Test1', N'User1', N'test1@user1.com')

if not exists(select * from [User] where Login = 'TestLogin2')
	insert into [dbo].[User] ([Login], [Password], [Firstname], [Lastname], [Email])
		values (N'TestLogin2', N'Password', N'Test2', N'User2', N'test2@user2.com')


-- Task table --
if not exists(select * from dbo.Task where Subject = 'First Task')
begin
	select top 1 @statusId = StatusId from Status order by StatusId;
	select top 1 @userId = UserId from [User] order by UserId;

	insert into dbo.Task(Subject, StartDate, StatusId, CreatedDate, CreatedUserId)
		values('First Task', getdate(), @statusId, getdate(), @userId);

	set @taskId = SCOPE_IDENTITY();

	insert [dbo].[TaskUser] ([TaskId], [UserId])
		values(@taskId, @userId)
end

if not exists(select * from dbo.Task where Subject = 'Second Task')
begin
	select top 1 @statusId = StatusId from Status order by StatusId;
	select top 1 @userId = UserId from [User] order by UserId;

	insert into dbo.Task(Subject, StartDate, StatusId, CreatedDate, CreatedUserId)
		values('Second Task', getdate(), @statusId, getdate(), @userId);

	set @taskId = SCOPE_IDENTITY();

	insert [dbo].[TaskUser] ([TaskId], [UserId])
		values(@taskId, @userId)
end