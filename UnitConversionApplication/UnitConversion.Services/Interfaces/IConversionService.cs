using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConversion.Models.DTO;

namespace UnitConversion.Services.Interfaces
{
    public interface IConversionService
    {
        ConversionDTO Conversion(ConversionDTO conversionDTO);

        List<ConversionHistoryDTO> GetConversionHistory();
    }
}
