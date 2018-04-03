using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Skivsoft.TfsExport.Context
{
    public class SourceModel
    {
        public JArray PullRequestArray { get; set; } = new JArray();

        public ISet<int> WorkItemsUnique { get; set; } = new HashSet<int>();

        public JArray WorkItemArray { get; set; } = new JArray();
    }
}