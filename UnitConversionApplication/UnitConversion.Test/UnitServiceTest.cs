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
    public class UnitServiceTest
    {
        List<Models.Data.Unit> units = new List<Models.Data.Unit>();       

        [TestMethod]
        public void GetUnitsByType_Success()
        {
            // Arrange
            units.Add(new Models.Data.Unit() { Id = 1, Name = "Meter" });

            var mockRepository = new Mock<IUnitRepository>();
          
            mockRepository.Setup(x => x.GetUnitsByType(Catergory.Length))
                .Returns(units.ToArray());

            var service = new UnitService(mockRepository.Object);

            // Act
            var result = service.GetUnitsByType(1);
         
            // Assert
        
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Length,1);           
        }

        [TestMethod]
        public void GetUnitsByType_EmptyArray()
        {
            // Arrange          

            var mockRepository = new Mock<IUnitRepository>();

            mockRepository.Setup(x => x.GetUnitsByType(Catergory.Length))
                .Returns(units.ToArray());

            var service = new UnitService(mockRepository.Object);

            // Act
            var result = service.GetUnitsByType(1);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Length, 0);
        }
    }
}