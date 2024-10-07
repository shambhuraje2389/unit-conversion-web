using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConversion.Models.DTO;

namespace UnitConversion.Models.Validation
{
    public static class ConversionValidater
    {
        /// <summary>
        /// Validate the model
        /// </summary>
        /// <param name="conversion"></param>
        /// <returns></returns>
        public static bool IsValidate(this ConversionDTO conversion)
        {
            if (string.IsNullOrEmpty(conversion.Input) || conversion.Input.Length == 0 || conversion.SourceUnitId == 0 || conversion.TargetUnitId == 0 || conversion.Type == 0)
            {
                return false;
            }

            return true;
        }
    }
}
