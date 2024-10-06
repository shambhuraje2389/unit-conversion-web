using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConversion.Models.DTO
{
    public class ConversionHistoryDTO
    {
        public int Id { get; set; }

        public string Input { get; set; }

        public string Type { get; set; }

        public string Source { get; set; }

        public string Target { get; set; }

        public string Output { get; set; }
    }
}
