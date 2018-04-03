using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skivsoft.Processor;
using Skivsoft.TfsExport.Common;
using Skivsoft.TfsExport.Context;
using Skivsoft.TfsExport.Entities;

namespace Skivsoft.TfsExport.Processors
{
    internal class ExtractTfsLink : IProcessor<ProcessorContext>
    {
        public void Execute(ProcessorContext context)
        {
            if (context.Source.PullRequestArray.Count == 0)
                return;

            Console.WriteLine("Extracting links to work items...");

            foreach (JToken pullRequest in context.Source.PullRequestArray)
            {
                var pullRequestId = (int)pullRequest["pullRequestId"];
                ProcessLinks(context, pullRequestId);
            }
        }

        private static void ProcessLinks(ProcessorContext context, int pullRequestId)
        {
            Uri url = TfsUrlTemplates.PullRequestWorkItemsUri(pullRequestId);
            string content = context.TfsRepository.DownloadString(url);
            context.Statistics.NumberHttpRequests++;

            JObject response = JsonConvert.DeserializeObject<JObject>(content);
            JArray workItems = (JArray)response["value"];

            foreach (JToken workItem in workItems)
            {
                var link = new Link
                {
                    PullRequestId = pullRequestId,
                    WorkItemId = (int)workItem["id"]
                };
                context.Target.LinkList.Add(link);
                context.Source.WorkItemsUnique.Add(link.WorkItemId);
            }
        }
    }
}