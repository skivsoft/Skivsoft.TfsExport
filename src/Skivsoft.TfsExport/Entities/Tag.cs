using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace Skivsoft.TfsExport.Entities
{
    [Table("Tag")]
    public class Tag
    {
        [ExplicitKey]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}