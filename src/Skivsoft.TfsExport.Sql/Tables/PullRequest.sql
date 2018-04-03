CREATE TABLE [dbo].[PullRequest]
(
	[RepositoryName] NVARCHAR(50) NOT NULL,
	[PullRequestId] INT NOT NULL PRIMARY KEY,
    [CodeReviewId] INT NOT NULL,
    [Status] VARCHAR(10) NOT NULL CHECK ([Status] IN ('active', 'abandoned', 'completed')),
	[CreatedById] UNIQUEIDENTIFIER NOT NULL,
	[CreatedBy] NVARCHAR(100) NOT NULL,
    [CreationDate] DATETIME2 NOT NULL,
    [ClosedDate] DATETIME2 NULL,
    [Title] NVARCHAR(200) NOT NULL,
    [Description] NVARCHAR(500) NULL,
    [SourceRefName] NVARCHAR(200) NOT NULL,
    [TargetRefName] NVARCHAR(200) NOT NULL
)
