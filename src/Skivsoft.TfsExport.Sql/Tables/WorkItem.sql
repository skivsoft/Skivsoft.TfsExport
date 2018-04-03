CREATE TABLE [dbo].[WorkItem]
(
	[WorkItemId] INT NOT NULL PRIMARY KEY,
    [AreaPath] NVARCHAR(100) NOT NULL,
    [IterationPath] NVARCHAR(100) NOT NULL,
    [WorkItemType] NVARCHAR(20) NOT NULL,
    [State] NVARCHAR(20) NOT NULL,
    [AssignedTo] NVARCHAR(100) NULL,
    [CreatedDate] DATETIME2 NOT NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL,
    [ChangedDate] DATETIME2 NULL,
    [ChangedBy] NVARCHAR(100) NULL,
    [Title] NVARCHAR(300) NOT NULL,
    [Priority] INT NULL,
	[ClosedDate] DATETIME2 NULL,
	[Severity] NVARCHAR(20) NULL,
    [Effort] DECIMAL(4, 2) NULL,
    [Tags] NVARCHAR(500) NULL,
    [FoundIn] NVARCHAR(100) NULL,
	[TestPhase] NVARCHAR(50) NULL,
    [FixVersion] NVARCHAR(20) NULL
)
