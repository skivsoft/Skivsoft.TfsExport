using System;
using Newtonsoft.Json.Linq;
using Skivsoft.Processor;
using Skivsoft.TfsExport.Context;
using Skivsoft.TfsExport.Entities;

namespace Skivsoft.TfsExport.Processors
{
    internal class TransformWorkItem : IProcessor<ProcessorContext>
    {
        public void Execute(ProcessorContext context)
        {
            foreach (JToken data in context.Source.WorkItemArray)
            {
                JToken fields = data["fields"];
                var workItemId = (int)data["id"];
                var workItemType = (string)fields["System.WorkItemType"];
                try
                {
                    var workItem = new WorkItem();
                    workItem.WorkItemId = workItemId;
                    workItem.AreaPath = (string)fields["System.AreaPath"];
                    workItem.IterationPath = (string)fields["System.IterationPath"];
                    workItem.WorkItemType = workItemType;
                    workItem.State = (string)fields["System.State"];
                    workItem.AssignedTo = (string)fields["System.AssignedTo"];
                    workItem.CreatedDate = (DateTime)fields["System.CreatedDate"];
                    workItem.CreatedBy = (string)fields["System.CreatedBy"];
                    workItem.ChangedDate = (DateTime?)fields["System.ChangedDate"];
                    workItem.ChangedBy = (string)fields["System.ChangedBy"];
                    workItem.Title = FixString((string)fields["System.Title"], 300);
                    workItem.Priority = (int?)fields["Microsoft.VSTS.Common.Priority"];
                    workItem.ClosedDate = (DateTime?)fields["Microsoft.VSTS.Common.ClosedDate"];
                    workItem.Severity = (string)fields["Microsoft.VSTS.Common.Severity"];
                    workItem.Effort = (decimal?)fields["Microsoft.VSTS.Scheduling.Effort"];
                    workItem.Tags = FixTags((string)fields["System.Tags"]);
                    workItem.FoundIn = FixString((string)fields["Microsoft.VSTS.Build.FoundIn"], 100);
                    workItem.TestPhase = (string)fields["SCF.TestPhase"];
                    workItem.FixVersion = (string)fields["Microsoft.VSTS.FixVersion"];
                    context.Target.WorkItemList.Add(workItem);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("{0}: {1}", GetType().Name, exception.Message);
                    Console.WriteLine("{0}: {1} {2}", GetType().Name, workItemType, workItemId);
                }
            }
        }

        private static string FixString(string data, int maxLength)
        {
            if (string.IsNullOrEmpty(data))
                return data;
            return data.Substring(0, Math.Min(data.Length, maxLength));
        }

        private static string FixTags(string tags)
        {
            if (string.IsNullOrEmpty(tags))
                return tags;
            return tags + ";";
        }
    }
}