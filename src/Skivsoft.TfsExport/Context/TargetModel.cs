using System;
using System.Collections.Generic;
using Skivsoft.TfsExport.Entities;

namespace Skivsoft.TfsExport.Context
{
    public class TargetModel
    {
        public ICollection<PullRequest> PullRequestList { get; set; } = new List<PullRequest>();

        public ICollection<Link> LinkList { get; set; } = new List<Link>();

        public ICollection<WorkItem> WorkItemList { get; set; } = new List<WorkItem>();

        public ISet<string> TagUnique { get; set; } = new HashSet<string>(StringComparer.InvariantCulture);
    }
}