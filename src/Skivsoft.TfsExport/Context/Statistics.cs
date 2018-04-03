using System.Diagnostics;

namespace Skivsoft.TfsExport.Context
{
    public class Statistics
    {
        public int NumberHttpRequests { get; set; }

        public int NumberSqlQueries { get; set; }

        public Stopwatch Stopwatch { get; set; }
    }
}