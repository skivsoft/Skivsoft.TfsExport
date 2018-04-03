using System;
using Dapper.Contrib.Extensions;
using Skivsoft.Processor;
using Skivsoft.TfsExport.Context;
using Skivsoft.TfsExport.Entities;

namespace Skivsoft.TfsExport.Processors
{
    internal class LoadWorkItem : IProcessor<ProcessorContext>
    {
        public void Execute(ProcessorContext context)
        {
            if (context.Target.WorkItemList.Count == 0)
                return;

            Console.WriteLine("Loading work items...");
            foreach (WorkItem workItem in context.Target.WorkItemList)
            {
                try
                {
                    ProcessWorkItem(context, workItem);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("{0}: {1}", GetType().Name, exception.Message);
                    Console.WriteLine("{0}: {1} {2}", GetType().Name, workItem.WorkItemType, workItem.WorkItemId);
                }
            }
        }

        private static void ProcessWorkItem(ProcessorContext context, WorkItem workItem)
        {
            var data = context.Connection.Get<WorkItem>(workItem.WorkItemId);
            context.Statistics.NumberSqlQueries++;

            if (data == null)
            {
                context.Connection.Insert(workItem);
                context.Statistics.NumberSqlQueries++;
            }
            else
            {
                if (workItem.ChangedDate != data.ChangedDate)
                {
                    context.Connection.Update(workItem);
                    context.Statistics.NumberSqlQueries++;
                }
            }
        }
    }
}