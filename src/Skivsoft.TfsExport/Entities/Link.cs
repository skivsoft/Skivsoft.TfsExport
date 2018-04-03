using Dapper.Contrib.Extensions;

namespace Skivsoft.TfsExport.Entities
{
    [Table("Link")]
    public class Link
    {
        public int PullRequestId { get; set; }

        public int WorkItemId { get; set; }
    }
}