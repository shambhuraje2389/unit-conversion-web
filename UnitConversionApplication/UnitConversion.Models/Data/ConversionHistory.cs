using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConversion.Models.Data
{   
    public class ConversionHistory
    {

        public int Id { get; set; }
        [Required]
        public decimal Input { get; set; }
        [Required]
        public decimal Output { get; set; }
        [Required]       
        public int SourceUnitId { get; set; }
        [Required]        
        public int TargetUnitId { get; set; }             

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        [NotMapped]
        public Unit SourceUnit { get; set; }

        [NotMapped]
        public Unit TargetUnit { get; set; }
    }
}
