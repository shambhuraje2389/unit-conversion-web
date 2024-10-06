using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConversion.Models.Data;
using UnitConversion.Models.DTO;

namespace UnitConversion.Models.Converter
{
    public static class ObjectConveter
    {
        /// <summary>
        /// Convert Unit Data Model tp DTO
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public static IEnumerable<UnitDTO> ConvertToDto(this IEnumerable<Unit> units)
        {
            var baseProductCustomReturn = (from baseProduct in units
                                           select new UnitDTO
                                           {
                                               Id = baseProduct.Id,
                                               Name = baseProduct.Name,
                                               Type = baseProduct.Type.ToString(),
                                           });

            return baseProductCustomReturn.ToList();
        }

       

        /// <summary>
        /// Convert Conversion History Data model to DTO
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="units"></param>
        /// <returns></returns>
        public static List<ConversionHistoryDTO> ConvertToDto(this IEnumerable<ConversionHistory> dataList, IEnumerable<Unit> units)
        {
            List<ConversionHistoryDTO> dtos = new List<ConversionHistoryDTO>();
            foreach (var item in dataList)
            {
                ConversionHistoryDTO conversionHistoryDTO = new ConversionHistoryDTO();

                conversionHistoryDTO.Id = item.Id;
                Catergory catergory = units.FirstOrDefault(e => e.Id == item.SourceUnitId).Type;

                conversionHistoryDTO.Type = Enum.GetName(typeof(Catergory), catergory);
                conversionHistoryDTO.Input = item.Input.ToString();
                conversionHistoryDTO.Output = item.Output.ToString();
                conversionHistoryDTO.Source = units.FirstOrDefault(e => e.Id == item.SourceUnitId).Name;
                conversionHistoryDTO.Target = units.FirstOrDefault(e => e.Id == item.TargetUnitId).Name;


                dtos.Add(conversionHistoryDTO);
            }
            return dtos;
        }

        /// <summary>
        /// Convert converison DTO to converison history data model
        /// </summary>
        /// <param name="conversionDTO"></param>
        /// <returns></returns>
        public static ConversionHistory ConvertToConversionHistoryData(this ConversionDTO conversionDTO)
        {
            ConversionHistory conversionHistory = new ConversionHistory();
            conversionHistory.Input = Convert.ToDecimal(conversionDTO.Input);
            conversionHistory.Output = Convert.ToDecimal(conversionDTO.Output);
            conversionHistory.SourceUnitId = conversionDTO.SourceUnitId;
            conversionHistory.TargetUnitId = conversionDTO.TargetUnitId;
            conversionHistory.CreatedDate = DateTime.Now;

            return conversionHistory;
        }
    }
}
