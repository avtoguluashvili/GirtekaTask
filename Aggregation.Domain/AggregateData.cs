using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aggregation.Domain
{
    public class AggregateData
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string OBT { get; set; }
        public string Type { get; set; }
        public int? ObjectNumber { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? PPlus { get; set; }
        public DateTime PLTime { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? PMinus { get; set; }

    }
}