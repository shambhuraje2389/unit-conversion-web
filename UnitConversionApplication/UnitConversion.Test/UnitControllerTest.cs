using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitConversion.API.Controllers;


namespace UnitConversion.Test
{
    [TestClass]
    public class UnitControllerTest
    {
        List<Models.DTO.UnitDTO> units = new List<Models.DTO.UnitDTO>();       

        [TestMethod]
        public void GetReturnUnits()
        {
            // Arrange
            units.Add(new Models.DTO.UnitDTO() { Id = 1, Name = "Meter" });


            var mock = new Mock<ILogger<UnitController>>();
            ILogger<UnitController> logger = mock.Object;

            var mockRepository = new Mock<Services.Interfaces.IUnitService>();
          
            mockRepository.Setup(x => x.GetUnitsByType(1))
                .Returns(units.ToArray());

            var controller = new UnitController(logger,mockRepository.Object);

            // Act
            ActionResult actionResult = controller.Get(1);
            var contentResult = actionResult as OkObjectResult;

            // Assert
        
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.StatusCode,200);
            Assert.IsNotNull(contentResult.Value);
        }

        [TestMethod]
        public void GetReturnUnitsNotFound()
        {
            var mock = new Mock<ILogger<UnitController>>();
            ILogger<UnitController> logger = mock.Object;

            var mockRepository = new Mock<Services.Interfaces.IUnitService>();

            mockRepository.Setup(x => x.GetUnitsByType(1))
                .Returns(units.ToArray());

            var controller = new UnitController(logger, mockRepository.Object);

            // Act
            ActionResult actionResult = controller.Get(1);
            var contentResult = actionResult as OkObjectResult;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.StatusCode, 200);
        }
    }
}