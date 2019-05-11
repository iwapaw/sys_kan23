CREATE TABLE [dbo].[TaskUser]
(
	[TaskId] BIGINT NOT NULL, 
    [UserId] BIGINT NOT NULL, 
    [ts] ROWVERSION NOT NULL,
	PRIMARY KEY (TaskId, UserId),
	FOREIGN KEY (UserId) REFERENCES dbo.[User] (UserId),
	FOREIGN KEY (TaskId) REFERENCES dbo.Task (TaskId)
)
GO
CREATE INDEX ix_TaskUser_UserId on TaskUser(UserId)
GO