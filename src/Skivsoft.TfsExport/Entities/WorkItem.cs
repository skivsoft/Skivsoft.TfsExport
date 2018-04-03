using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace Skivsoft.TfsExport.Entities
{
    [Table("WorkItem")]
    public class WorkItem
    {
        [ExplicitKey]
        public int WorkItemId { get; set; }

        [MaxLength(100)]
        public string AreaPath { get; set; }

        [MaxLength(100)]
        public string IterationPath { get; set; }

        [MaxLength(20)]
        public string WorkItemType { get; set; }

        [MaxLength(20)]
        public string State { get; set; }

        [MaxLength(100)]
        public string AssignedTo { get; set; }

        public DateTime CreatedDate { get; set; }

        [MaxLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? ChangedDate { get; set; }

        [MaxLength(100)]
        public string ChangedBy { get; set; }

        [MaxLength(300)]
        public string Title { get; set; }

        public int? Priority { get; set; }

        public DateTime? ClosedDate { get; set; }

        [MaxLength(20)]
        public string Severity { get; set; }

        public decimal? Effort { get; set; }

        [MaxLength(500)]
        public string Tags { get; set; }

        [MaxLength(100)]
        public string FoundIn { get; set; }

        [MaxLength(50)]
        public string TestPhase { get; set; }

        [MaxLength(20)]
        public string FixVersion { get; set; }
    }
}