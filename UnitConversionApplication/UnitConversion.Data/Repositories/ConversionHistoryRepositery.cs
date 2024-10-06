using Microsoft.EntityFrameworkCore;
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
    /// COnversion History Repositery class
    /// </summary>
    public class ConversionHistoryRepositery : IConversionHistoryRepositery
    {
        private readonly UnitConversionContext _context;

        /// <summary>
        /// Constricture
        /// </summary>
        /// <param name="appDbContext"></param>
        public ConversionHistoryRepositery(UnitConversionContext appDbContext)
        {
            this._context = appDbContext;
        }

        /// <inheritdoc/>
        public IEnumerable<ConversionHistory> GetAllConversionHistory()
        {
            return _context.ConversionHistory.ToList();
        }

        /// <inheritdoc/>
        public void SaveConversionHistory(ConversionHistory conversion)
        {
            _context.Entry(conversion).State = EntityState.Added;
            _context.SaveChanges();
        }
    }
}
