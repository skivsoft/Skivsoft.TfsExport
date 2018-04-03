using Skivsoft.Processor;
using Skivsoft.TfsExport.Context;
using Skivsoft.TfsExport.Entities;

namespace Skivsoft.TfsExport.Processors
{
    internal class TransformTag : IProcessor<ProcessorContext>
    {
        public void Execute(ProcessorContext context)
        {
            foreach (WorkItem workItem in context.Target.WorkItemList)
            {
                if (string.IsNullOrEmpty(workItem.Tags))
                    continue;

                var tags = workItem.Tags.Split(';');
                foreach (string tag in tags)
                {
                    var tagName = tag.Trim();
                    if (string.IsNullOrEmpty(tagName))
                        continue;
                    context.Target.TagUnique.Add(tagName);
                }
            }
        }
    }
}