using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConversion.Models.Data;

namespace UnitConversion.Data.Interfaces
{
    /// <summary>
    /// Conversion History Repositery
    /// </summary>
    public interface IConversionHistoryRepositery
    {
        /// <summary>
        /// Save conversion history
        /// </summary>
        /// <param name="conversion"></param>
        void SaveConversionHistory(ConversionHistory conversion);

        /// <summary>
        /// Get All Conversion History
        /// </summary>
        /// <returns></returns>
        IEnumerable<ConversionHistory> GetAllConversionHistory();
    }
}
