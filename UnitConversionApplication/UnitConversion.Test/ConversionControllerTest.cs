using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitConversion.API.Controllers;
using UnitConversion.Models.DTO;


namespace UnitConversion.Test
{
    [TestClass]
    public class ConversionControllerTest
    {
        List<Models.DTO.ConversionHistoryDTO> conversions = new List<Models.DTO.ConversionHistoryDTO>();       

        [TestMethod]
        public void GetReturnConversionHistory()
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
        public void GetReturnConversionHistoryNotFound()
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

        [TestMethod]
        public void GetReturnConversion()
        {
            // Arrange
            
            ConversionDTO cnversionDTO = new ConversionDTO()
            {
                Input = "1",
                SourceUnitId = 1,
                TargetUnitId = 1,
                Type = 1,
                Output = "2",
            };


            var mock = new Mock<ILogger<ConversionController>>();
            ILogger<ConversionController> logger = mock.Object;

            var mockRepository = new Mock<Services.Interfaces.IConversionService>();

            mockRepository.Setup(x => x.Conversion(cnversionDTO))
                .Returns(cnversionDTO);

            var controller = new ConversionController(logger, mockRepository.Object);

            // Act
            ActionResult<ConversionDTO> actionResult = controller.Post(cnversionDTO);
            var contentResult = actionResult.Result as OkObjectResult;

            // Assert

            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.StatusCode, 200);
            Assert.IsNotNull(contentResult.Value);
        }

        [TestMethod]
        public void GetReturnConversionNotFound()
        {
            // Arrange

            ConversionDTO cnversionDTO = new ConversionDTO() { };


            var mock = new Mock<ILogger<ConversionController>>();
            ILogger<ConversionController> logger = mock.Object;

            var mockRepository = new Mock<Services.Interfaces.IConversionService>();

            mockRepository.Setup(x => x.Conversion(cnversionDTO))
                .Returns(cnversionDTO);

            var controller = new ConversionController(logger, mockRepository.Object);

            // Act
            ActionResult<ConversionDTO> actionResult = controller.Post(cnversionDTO);
            var contentResult = actionResult.Result as OkObjectResult;

            // Assert
            Assert.IsNull(contentResult);
           
        }
    }
}