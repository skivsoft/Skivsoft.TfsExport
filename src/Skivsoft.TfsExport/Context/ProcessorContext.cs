using System.Data;
using System.Net;

namespace Skivsoft.TfsExport.Context
{
    public class ProcessorContext
    {
        public WebClient TfsRepository { get; set; }

        public IDbConnection Connection { get; set; }

        public SourceModel Source { get; set; } = new SourceModel();

        public TargetModel Target { get; set; } = new TargetModel();

        public Statistics Statistics { get; set; } = new Statistics();
    }
}