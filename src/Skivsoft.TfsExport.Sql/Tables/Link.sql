CREATE TABLE [dbo].[Link]
(
    [PullRequestId] INT NOT NULL,
	[WorkItemId] INT NOT NULL
)

GO

CREATE UNIQUE INDEX [IX_Link_Column] ON [dbo].[Link] ([PullRequestId], [WorkItemId])