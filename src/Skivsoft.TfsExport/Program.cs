using System;
using Skivsoft.Processor;
using Skivsoft.TfsExport.Common;
using Skivsoft.TfsExport.Context;
using Skivsoft.TfsExport.Processors;
using Skivsoft.TfsExport.Properties;

namespace Skivsoft.TfsExport
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("TFS Export v0.1");
            Console.WriteLine("Source TFS       : {0}", Settings.Default.SourceTfsUrl);
            Console.WriteLine("Source repository: {0}", Settings.Default.SourceTfsRepositoryName);
            Console.WriteLine("Target connection: {0}", Settings.Default.TargetConnectionString);
            Console.WriteLine();

            new Bootstrap(GetProcessors()).Execute(new ProcessorContext());
        }

        private static IProcessor<ProcessorContext> GetProcessors()
        {
            return new ProcessorGroup<ProcessorContext>(new IProcessor<ProcessorContext>[]
            {
                new StopwatchProcessor(
                    new ProcessorGroup<ProcessorContext>(new[]
                    {
                        Extract(),
                        Transform(),
                        Load(),
                    })),
                new OutputStatistics()
            });
        }

        private static IProcessor<ProcessorContext> Extract()
        {
            return new ProcessorGroup<ProcessorContext>(new IProcessor<ProcessorContext>[]
                {
                    new ExtractTfsPullRequest(),
                    new ExtractTfsLink(),
                    new ExtractTfsWorkItem(),
                });
        }

        private static IProcessor<ProcessorContext> Transform()
        {
            return new ProcessorGroup<ProcessorContext>(new IProcessor<ProcessorContext>[]
            {
                new TransformPullRequest(),
                new TransformWorkItem(),
                new TransformTag(),
            });
        }

        private static IProcessor<ProcessorContext> Load()
        {
            return new ProcessorGroup<ProcessorContext>(new IProcessor<ProcessorContext>[]
            {
                new LoadPullRequest(),
                new LoadLink(),
                new LoadWorkItem(),
                new LoadTag(),
            });
        }
    }
}