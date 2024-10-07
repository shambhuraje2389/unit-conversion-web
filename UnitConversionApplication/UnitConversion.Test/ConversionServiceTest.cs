using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitConversion.API.Controllers;
using UnitConversion.Data.Interfaces;
using UnitConversion.Models.Data;
using UnitConversion.Services.Services;


namespace UnitConversion.Test
{
    [TestClass]
    public class ConversionServiceTest
    {
        List<Models.Data.ConversionHistory> conversionHistories = new List<Models.Data.ConversionHistory>();
        List<Models.Data.Unit> units = new List<Models.Data.Unit>();

        [TestMethod]
        public void GetConversionHistory_Success()
        {
            // Arrange
            conversionHistories.Add(new Models.Data.ConversionHistory() { Id = 1, Input=1,Output=10,SourceUnitId=1,TargetUnitId=1});
            units.Add(new Unit() { Id = 1, Name = "Meter", Type = Catergory.Length, CreatedDate = DateTime.Now });

            var mockRepository = new Mock<IConversionHistoryRepositery>();
            var mockUnitRepository = new Mock<IUnitRepository>();
            var mockConversionRateRepository = new Mock<IConversionRateRepositery>();

            mockRepository.Setup(x => x.GetAllConversionHistory())
                .Returns(conversionHistories);

            mockUnitRepository.Setup(x => x.GetUnits())
              .Returns(units);         

            var service = new ConversionService(mockConversionRateRepository.Object,mockRepository.Object, mockUnitRepository.Object);

            // Act
            var result = service.GetConversionHistory();
         
            // Assert
        
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count,1);           
        }

        [TestMethod]
        public void GetConversionHistory_EmptyArray()
        {
            // Arrange          

            var mockRepository = new Mock<IConversionHistoryRepositery>();
            var mockUnitRepository = new Mock<IUnitRepository>();
            var mockConversionRateRepository = new Mock<IConversionRateRepositery>();

            mockRepository.Setup(x => x.GetAllConversionHistory())
                .Returns(conversionHistories);

            mockUnitRepository.Setup(x => x.GetUnits())
              .Returns(units);

            var service = new ConversionService(mockConversionRateRepository.Object, mockRepository.Object, mockUnitRepository.Object);

            // Act
            var result = service.GetConversionHistory();

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 0);
        }
    }
}