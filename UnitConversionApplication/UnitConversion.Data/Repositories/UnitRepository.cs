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
    /// Unit Repositery
    /// </summary>
    public class UnitRepository : IUnitRepository
    {
        private readonly UnitConversionContext _context;

        /// <summary>
        /// Constricture
        /// </summary>
        /// <param name="appDbContext"></param>
        public UnitRepository(UnitConversionContext appDbContext)
        {
            this._context = appDbContext;
        }

        /// <inheritdoc/>
        public Unit GetUnit(int unitId)
        {
            return _context.Units.FirstOrDefault(e => e.Id == unitId);
        }

        /// <inheritdoc/>
        public IEnumerable<Unit> GetUnits()
        {
            return _context.Units.ToList();
        }

        /// <inheritdoc/>
        public IEnumerable<Unit> GetUnitsByType(Catergory catergory)
        {
            return _context.Units.Where(e=>e.Type==catergory).ToList();
        }
    }
}
