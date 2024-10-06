using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConversion.Models.Data;

namespace UnitConversion.Data.Interfaces
{
    /// <summary>
    /// Conversion Rate Repository Interface
    /// </summary>
    public interface IConversionRateRepositery
    {
        /// <summary>
        /// Get All Units
        /// </summary>
        /// <returns></returns>
        IEnumerable<ConversionRate> GetConversionRates();

        ConversionRate GetConversionRate(int sourceUnitId,int targetUnitId);
    }
}
