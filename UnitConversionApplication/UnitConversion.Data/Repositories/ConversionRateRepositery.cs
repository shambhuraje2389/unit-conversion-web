using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConversion.Data.Interfaces;
using UnitConversion.Models.Data;

namespace UnitConversion.Data.Repositories
{
    /// <summary>
    /// Conversion Rate Repositery
    /// </summary>
    public class ConversionRateRepositery : IConversionRateRepositery
    {
        private readonly UnitConversionContext _context;

        /// <summary>
        /// Constricture
        /// </summary>
        /// <param name="appDbContext"></param>
        public ConversionRateRepositery(UnitConversionContext appDbContext)
        {
            this._context = appDbContext;
        }

        /// <inheritdoc/>
        public ConversionRate GetConversionRate(int sourceUnitId, int targetUnitId)
        {
            return _context.ConversionRates.FirstOrDefault(e => e.SourceUnitId == sourceUnitId && e.TargetUnitId==targetUnitId);
        }

        /// <inheritdoc/>
        public IEnumerable<ConversionRate> GetConversionRates()
        {
            return _context.ConversionRates.ToList();
        }
    }
}
