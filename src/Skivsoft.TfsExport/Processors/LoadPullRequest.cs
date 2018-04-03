using System;
using Dapper.Contrib.Extensions;
using Skivsoft.Processor;
using Skivsoft.TfsExport.Context;
using Skivsoft.TfsExport.Entities;

namespace Skivsoft.TfsExport.Processors
{
    internal class LoadPullRequest : IProcessor<ProcessorContext>
    {
        public void Execute(ProcessorContext context)
        {
            if (context.Target.PullRequestList.Count == 0)
                return;

            Console.WriteLine("Loading pull requests...");
            foreach (PullRequest pullRequest in context.Target.PullRequestList)
            {
                var data = context.Connection.Get<PullRequest>(pullRequest.PullRequestId);
                context.Statistics.NumberSqlQueries++;
                if (data == null)
                {
                    context.Connection.Insert(pullRequest);
                    context.Statistics.NumberSqlQueries++;
                }
            }
        }
    }
}