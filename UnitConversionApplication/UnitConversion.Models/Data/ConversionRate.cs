using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConversion.Models.Data
{
    public class ConversionRate
    {
        public int Id { get; set; }
        
        [Required]
        public int SourceUnitId { get; set; }
       
        [Required]
        public int TargetUnitId { get; set; }
       
        [Required]
        public string Formula { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        [NotMapped]
        public Unit SourceUnit { get; set; }

        [NotMapped]
        public Unit TargetUnit { get; set; }
    }
}
