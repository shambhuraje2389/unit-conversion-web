using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConversion.Models.DTO
{
    public class ConversionDTO
    {
        public string Input { get; set; }

        public int  Type { get; set; }

        public int SourceUnitId { get; set; }      

        public int TargetUnitId { get; set; }     

        public string Output { get; set; }
    }
}
