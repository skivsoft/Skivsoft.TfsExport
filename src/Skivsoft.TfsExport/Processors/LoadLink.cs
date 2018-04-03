using System;
using Dapper;
using Dapper.Contrib.Extensions;
using Skivsoft.Processor;
using Skivsoft.TfsExport.Context;
using Skivsoft.TfsExport.Entities;

namespace Skivsoft.TfsExport.Processors
{
    internal class LoadLink : IProcessor<ProcessorContext>
    {
        public void Execute(ProcessorContext context)
        {
            if (context.Target.LinkList.Count == 0)
                return;

            Console.WriteLine("Loading links to work items...");

            // remove old links
            foreach (PullRequest pullRequest in context.Target.PullRequestList)
            {
                context.Connection.Execute("DELETE FROM [Link] WHERE [PullRequestId] = @PullRequestId", new { pullRequest.PullRequestId });
                context.Statistics.NumberSqlQueries++;
            }

            // insert links
            foreach (Link link in context.Target.LinkList)
            {
                context.Connection.Insert(link);
                context.Statistics.NumberSqlQueries++;
            }
        }
    }
}