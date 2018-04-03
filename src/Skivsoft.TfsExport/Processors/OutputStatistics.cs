using System;
using Skivsoft.Processor;
using Skivsoft.TfsExport.Context;

namespace Skivsoft.TfsExport.Processors
{
    public class OutputStatistics : IProcessor<ProcessorContext>
    {
        public void Execute(ProcessorContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Http requests          : {0}", context.Statistics.NumberHttpRequests);
            Console.WriteLine("Sql queries            : {0}", context.Statistics.NumberSqlQueries);
            Console.WriteLine("Pull requests processed: {0}", context.Target.PullRequestList.Count);
            Console.WriteLine("Work items processed   : {0}", context.Target.WorkItemList.Count);
            Console.WriteLine("Tags processed         : {0}", context.Target.TagUnique.Count);
            Console.WriteLine("Processing time        : {0}", context.Statistics.Stopwatch.Elapsed);
        }
    }
}