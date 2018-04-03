using System;
using Skivsoft.TfsExport.Entities;
using Skivsoft.TfsExport.Properties;

namespace Skivsoft.TfsExport.Common
{
    public static class TfsUrlTemplates
    {
        private const string WorkItem = "_apis/wit/workItems/{0}";
        private const string PullRequests = "{0}/_apis/git/repositories/{0}/pullRequests?status={1}&$skip={2}";
        private const string PullRequest = "{0}/_apis/git/repositories/{0}/pullRequests/{1}";
        private const string PullRequestWorkItems = "{0}/_apis/git/repositories/{0}/pullRequests/{1}/workitems";
        private const string PullRequestIterations = "{0}/_apis/git/repositories/{0}/pullRequests/{1}/iterations";
        private const string PullRequestIteration = "{0}/_apis/git/repositories/{0}/pullRequests/{1}/iterations/{2}";
        private const string PullRequestCommits = "{0}/_apis/git/repositories/{0}/pullRequests/{1}/iterations/{2}/commits";

        public static Uri WorkItemUri(int workItemId)
        {
            return MakeUri(WorkItem, workItemId);
        }

        public static Uri PullRequestsUri(PullRequestStatus status, int skip)
        {
            return MakeUri(PullRequests, Settings.Default.SourceTfsRepositoryName, status.ToString(), skip);
        }

        public static Uri PullRequestUri(int pullRequestId)
        {
            return MakeUri(PullRequest, Settings.Default.SourceTfsRepositoryName, pullRequestId);
        }

        public static Uri PullRequestWorkItemsUri(int pullRequestId)
        {
            return MakeUri(PullRequestWorkItems, Settings.Default.SourceTfsRepositoryName, pullRequestId);
        }

        public static Uri PullRequestIterationsUri(int pullRequestId)
        {
            return MakeUri(PullRequestIterations, Settings.Default.SourceTfsRepositoryName, pullRequestId);
        }

        public static Uri PullRequestIterationUrl(int pullRequestId, int iterationId)
        {
            return MakeUri(PullRequestIteration, Settings.Default.SourceTfsRepositoryName, pullRequestId, iterationId);
        }

        public static Uri PullRequestCommitsUri(int pullRequestId, int iterationId)
        {
            return MakeUri(PullRequestCommits, Settings.Default.SourceTfsRepositoryName, pullRequestId, iterationId);
        }

        private static Uri MakeUri(string format, params object[] args)
        {
            return new Uri(new Uri(Settings.Default.SourceTfsUrl), string.Format(format, args));
        }
    }
}