using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConversion.Models.DTO;

namespace UnitConversion.Services.Interfaces
{
    public interface IUnitService
    {
        /// <summary>
        /// Get Unit by type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        UnitDTO[] GetUnitsByType(int type);

    }
}
