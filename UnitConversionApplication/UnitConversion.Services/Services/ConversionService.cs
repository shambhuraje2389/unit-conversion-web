using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitConversion.Data.Interfaces;
using UnitConversion.Data.Repositories;
using UnitConversion.Models.DTO;
using UnitConversion.Services.Interfaces;
using UnitConversion.Models.Converter;
using UnitConversion.Models.Data;
using UnitConversion.Models.Extensions;

namespace UnitConversion.Services.Services
{
    public class ConversionService : IConversionService
    {
        private readonly IConversionRateRepositery _conversionRateRepositery;

        private readonly IConversionHistoryRepositery _conversionHistoryRepositery;

        private readonly IUnitRepository _unitRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitRepository"></param>
        public ConversionService(IConversionRateRepositery conversionRateRepositery, IConversionHistoryRepositery conversionHistoryRepositery, IUnitRepository unitRepository)
        {
            this._conversionRateRepositery = conversionRateRepositery;
            this._conversionHistoryRepositery = conversionHistoryRepositery;
            this._unitRepository = unitRepository;
        }

        public ConversionDTO Conversion(ConversionDTO conversionDTO)
        {
            ConversionRate conversionRate = new ConversionRate();
            if (conversionDTO.SourceUnitId == conversionDTO.TargetUnitId)
            {
                conversionDTO.Output = conversionDTO.Input;
            }
            else
            {
                conversionRate = this._conversionRateRepositery.GetConversionRate(conversionDTO.SourceUnitId, conversionDTO.TargetUnitId);
                if (conversionRate != null)
                {
                    string formula = conversionRate.Formula;
                    formula = formula.Replace("inputVal", conversionDTO.Input);
                    conversionDTO.Output = formula.Evaluate().ToString();
                }
            }

            ConversionHistory conversionHistory = conversionDTO.ConvertToConversionHistoryData();
           
            this._conversionHistoryRepositery.SaveConversionHistory(conversionHistory);
            return conversionDTO;
        }

        public List<ConversionHistoryDTO> GetConversionHistory()
        {
            var dataList = this._conversionHistoryRepositery.GetAllConversionHistory();
            var units = this._unitRepository.GetUnits();
            List<ConversionHistoryDTO> dtos = dataList.ConvertToDto(units);
            return dtos;

        }
    }
}
