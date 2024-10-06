using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitConversion.API.Controllers;


namespace UnitConversion.Test
{
    [TestClass]
    public class ConversionControllerTest
    {
        List<Models.DTO.ConversionHistoryDTO> conversions = new List<Models.DTO.ConversionHistoryDTO>();       

        [TestMethod]
        public void GetReturnUnits()
        {
            // Arrange
            conversions.Add(new Models.DTO.ConversionHistoryDTO() { Id = 1, Input = "1",Output= "3.28084", Source="Meter",Target="Foot",Type="Length" });


            var mock = new Mock<ILogger<ConversionController>>();
            ILogger<ConversionController> logger = mock.Object;

            var mockRepository = new Mock<Services.Interfaces.IConversionService>();
          
            mockRepository.Setup(x => x.GetConversionHistory())
                .Returns(conversions);

            var controller = new ConversionController(logger,mockRepository.Object);

            // Act
            ActionResult actionResult = controller.Get();
            var contentResult = actionResult as OkObjectResult;

            // Assert
        
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.StatusCode,200);
            Assert.IsNotNull(contentResult.Value);
        }

        [TestMethod]
        public void GetReturnUnitsNotFound()
        {
            var mock = new Mock<ILogger<ConversionController>>();
            ILogger<ConversionController> logger = mock.Object;

            var mockRepository = new Mock<Services.Interfaces.IConversionService>();

            mockRepository.Setup(x => x.GetConversionHistory())
                .Returns(conversions);

            var controller = new ConversionController(logger, mockRepository.Object);

            // Act
            ActionResult actionResult = controller.Get();
            var contentResult = actionResult as OkObjectResult;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.StatusCode, 200);
        }
    }
}