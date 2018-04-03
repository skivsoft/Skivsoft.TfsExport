using System;
using Dapper.Contrib.Extensions;
using Skivsoft.Processor;
using Skivsoft.TfsExport.Context;
using Skivsoft.TfsExport.Entities;

namespace Skivsoft.TfsExport.Processors
{
    internal class LoadTag : IProcessor<ProcessorContext>
    {
        public void Execute(ProcessorContext context)
        {
            if (context.Target.TagUnique.Count == 0)
                return;

            Console.WriteLine("Loading tags...");

            foreach (string tagName in context.Target.TagUnique)
            {
                var existingTag = context.Connection.Get<Tag>(tagName);
                context.Statistics.NumberSqlQueries++;
                if (existingTag != null)
                    continue;

                context.Connection.Insert(new Tag { Name = tagName });
                context.Statistics.NumberSqlQueries++;
            }
        }
    }
}