using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConversion.Models.Data
{
   
    public class Unit
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Catergory Type { get; set; } 

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
      
    }

    public enum Catergory
    {
        Length=1,
        Weight=2,
        Temperature=3
    }
}
