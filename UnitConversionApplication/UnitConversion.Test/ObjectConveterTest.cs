using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConversion.API.Controllers;
using UnitConversion.Models.Converter;
using UnitConversion.Models.Data;
using UnitConversion.Models.DTO;

namespace UnitConversion.Test
{
    [TestClass]
    public class ObjectConveterTest
    {
        [TestMethod]
        public void ConvertUnitDataListToUnitDtoList()
        {
            // Arrange
            List<Unit> unitList = new List<Unit>() { new Unit() { Id = 1, Name = "Meter", Type = Catergory.Length, CreatedDate = DateTime.Now } };

            // Act
            IEnumerable<UnitDTO> result = unitList.AsEnumerable<Unit>().ConvertToDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public void ConvertConversionHistoryDataListToConversionHistoryDtoList()
        {
            // Arrange
            List<ConversionHistory> conversionHistoryList = new List<ConversionHistory>() { new ConversionHistory() { Id = 1, Input = 1, Output = 10, SourceUnitId = 1, TargetUnitId = 2, CreatedDate = DateTime.Now } };
            List<Unit> unitList = new List<Unit>() { new Unit() { Id = 1, Name = "Meter", Type = Catergory.Length, CreatedDate = DateTime.Now }, new Unit() { Id = 2, Name = "Centimeter", Type = Catergory.Length, CreatedDate = DateTime.Now } };


            // Act
            IEnumerable<ConversionHistoryDTO> result = conversionHistoryList.AsEnumerable<ConversionHistory>().ConvertToDto(unitList);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public void ConvertConversionHistoryDataToConversionHistoryDto()
        {
            // Arrange
            ConversionDTO conversionDTO = new ConversionDTO() { Input = "10", SourceUnitId = 1, TargetUnitId = 2, Type = 1 };

            // Act
            ConversionHistory conversionData = conversionDTO.ConvertToConversionHistoryData();

            // Assert
            Assert.IsNotNull(conversionData);
            Assert.AreEqual(conversionData.Input.ToString(), conversionDTO.Input);
            
        }
    }
}
