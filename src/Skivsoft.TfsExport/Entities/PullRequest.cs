using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace Skivsoft.TfsExport.Entities
{
    [Table("PullRequest")]
    public class PullRequest
    {
        [MaxLength(50)]
        public string RepositoryName { get; set; }

        [ExplicitKey]
        public int PullRequestId { get; set; }

        public int CodeReviewId { get; set; }

        [MaxLength(10)]
        public string Status { get; set; }

        public Guid CreatedById { get; set; }

        [MaxLength(100)]
        public string CreatedBy { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ClosedDate { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(200)]
        public string SourceRefName { get; set; }

        [MaxLength(200)]
        public string TargetRefName { get; set; }
    }
}