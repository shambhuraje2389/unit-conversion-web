using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConversion.Data.Interfaces;
using UnitConversion.Data.Repositories;
using UnitConversion.Models.Data;
using UnitConversion.Models.DTO;
using UnitConversion.Services.Interfaces;
using UnitConversion.Models.Converter;

namespace UnitConversion.Services.Services
{
    /// <summary>
    /// Unit Service class. 
    /// </summary>
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitRepository"></param>
        public UnitService(IUnitRepository unitRepository)
        {
            this._unitRepository = unitRepository;
        }

        /// <inheritdoc/>
        public UnitDTO[] GetUnitsByType(int type)
        {
            Catergory catergory = (Catergory)type;

            var dataList = _unitRepository.GetUnitsByType(catergory);

            if(!dataList.IsNullOrEmpty())
            {
                return dataList.ConvertToDto().ToArray();
            }

            return new UnitDTO[0];
        }
    }
}
