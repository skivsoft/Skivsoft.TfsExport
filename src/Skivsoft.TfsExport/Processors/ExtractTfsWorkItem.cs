using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skivsoft.Processor;
using Skivsoft.TfsExport.Common;
using Skivsoft.TfsExport.Context;

namespace Skivsoft.TfsExport.Processors
{
    internal class ExtractTfsWorkItem : IProcessor<ProcessorContext>
    {
        public void Execute(ProcessorContext context)
        {
            if (context.Source.WorkItemsUnique.Count == 0)
                return;

            Console.WriteLine("Extracting work items...");
            foreach (int workItemId in context.Source.WorkItemsUnique)
            {
                Uri url = TfsUrlTemplates.WorkItemUri(workItemId);
                string content = context.TfsRepository.DownloadString(url);
                context.Statistics.NumberHttpRequests++;

                JToken response = JsonConvert.DeserializeObject<JObject>(content);
                context.Source.WorkItemArray.Add(response);
            }
        }
    }
}