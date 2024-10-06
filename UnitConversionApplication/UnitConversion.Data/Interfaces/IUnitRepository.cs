using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConversion.Models.Data;

namespace UnitConversion.Data.Interfaces
{
    /// <summary>
    /// Unit Repository Interface
    /// </summary>
    public interface IUnitRepository
    {
        /// <summary>
        /// Get All Units
        /// </summary>
        /// <returns></returns>
        IEnumerable<Unit> GetUnits();

        /// <summary>
        /// Get Units by Category
        /// </summary>
        /// <param name="catergory"></param>
        /// <returns></returns>
        IEnumerable<Unit> GetUnitsByType(Catergory catergory);

        /// <summary>
        /// Get Unit by Id
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        Unit GetUnit(int unitId);
    }
}
