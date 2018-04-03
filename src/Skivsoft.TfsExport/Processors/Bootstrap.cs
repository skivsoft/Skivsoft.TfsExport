using System;
using System.Data.SqlClient;
using System.Net;
using Skivsoft.Processor;
using Skivsoft.TfsExport.Context;
using Skivsoft.TfsExport.Properties;

namespace Skivsoft.TfsExport.Processors
{
    public class Bootstrap : IProcessor<ProcessorContext>
    {
        private readonly IProcessor<ProcessorContext> processor;

        public Bootstrap(IProcessor<ProcessorContext> processor)
        {
            this.processor = processor;
        }

        public void Execute(ProcessorContext context)
        {
            using (WebClient client = new WebClient())
            {
                using (var connection = new SqlConnection(Settings.Default.TargetConnectionString))
                {
                    // initialize
                    client.Credentials = GetCredentials();
                    connection.Open();

                    // run
                    context.TfsRepository = client;
                    context.Connection = connection;
                    processor.Execute(context);

                    // done
                    connection.Close();
                }
            }
        }

        private static ICredentials GetCredentials()
        {
            if (string.IsNullOrEmpty(Settings.Default.SourceTfsUsername))
            {
                return CredentialCache.DefaultCredentials;
            }

            return new NetworkCredential(Settings.Default.SourceTfsUsername, Settings.Default.SourceTfsPassword);
        }
    }
}