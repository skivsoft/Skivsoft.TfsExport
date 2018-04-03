using System;
using Newtonsoft.Json.Linq;
using Skivsoft.Processor;
using Skivsoft.TfsExport.Context;
using Skivsoft.TfsExport.Entities;

namespace Skivsoft.TfsExport.Processors
{
    internal class TransformPullRequest : IProcessor<ProcessorContext>
    {
        public void Execute(ProcessorContext context)
        {
            foreach (JToken data in context.Source.PullRequestArray)
            {
                var createdByDisplayName = (string)data["createdBy"]["displayName"];
                var createdByUniqueName = (string)data["createdBy"]["uniqueName"];
                var pullRequest = new PullRequest
                {
                    RepositoryName = (string)data["repository"]["name"],
                    PullRequestId = (int)data["pullRequestId"],
                    CodeReviewId = (int)data["codeReviewId"],
                    Status = (string)data["status"],
                    CreatedById = new Guid((string)data["createdBy"]["id"]),
                    CreatedBy = $"{createdByDisplayName} <{createdByUniqueName}>",
                    CreationDate = (DateTime)data["creationDate"],
                    ClosedDate = (DateTime?)data["closedDate"],
                    Title = (string)data["title"],
                    Description = (string)data["description"],
                    SourceRefName = (string)data["sourceRefName"],
                    TargetRefName = (string)data["targetRefName"]
                };
                context.Target.PullRequestList.Add(pullRequest);
            }
        }
    }
}