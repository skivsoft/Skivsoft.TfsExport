using System;
using Dapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skivsoft.Processor;
using Skivsoft.TfsExport.Common;
using Skivsoft.TfsExport.Context;
using Skivsoft.TfsExport.Entities;

namespace Skivsoft.TfsExport.Processors
{
    internal class ExtractTfsPullRequest : IProcessor<ProcessorContext>
    {
        public void Execute(ProcessorContext context)
        {
            Console.WriteLine("Extracting pull requests...");
            var maxPullRequestId = GetMaxPullRequestId(context);

            int processed;
            var skip = 0;
            do
            {
                Uri url = TfsUrlTemplates.PullRequestsUri(PullRequestStatus.All, skip);
                string content = context.TfsRepository.DownloadString(url);
                context.Statistics.NumberHttpRequests++;

                JObject response = JsonConvert.DeserializeObject<JObject>(content);
                JArray pullRequests = (JArray)response["value"];

                processed = 0;
                foreach (JToken pullRequest in pullRequests)
                {
                    var pullRequestId = (int)pullRequest["pullRequestId"];
                    if (pullRequestId <= maxPullRequestId)
                        break;

                    processed++;
                    context.Source.PullRequestArray.Insert(0, pullRequest);
                }

                skip += processed;
            }
            while (processed > 0);
        }

        private int GetMaxPullRequestId(ProcessorContext context)
        {
            int? result = context.Connection.QuerySingle<int?>("SELECT MAX(PullRequestId) FROM PullRequest");
            context.Statistics.NumberSqlQueries++;
            return result ?? 0;
        }
    }
}