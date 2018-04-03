using System.Diagnostics;
using Skivsoft.Processor;
using Skivsoft.TfsExport.Context;

namespace Skivsoft.TfsExport.Common
{
    internal class StopwatchProcessor : ProcessorDecoratorBase<ProcessorContext>
    {
        public StopwatchProcessor(IProcessor<ProcessorContext> processor)
            : base(processor)
        {
        }

        public override void BeforeExecute(ProcessorContext context)
        {
            context.Statistics.Stopwatch = Stopwatch.StartNew();
        }

        public override void AfterExecute(ProcessorContext context)
        {
            context.Statistics.Stopwatch.Stop();
        }
    }
}