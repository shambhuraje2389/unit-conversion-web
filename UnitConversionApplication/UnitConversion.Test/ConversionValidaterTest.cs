using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConversion.Models.DTO;
using UnitConversion.Models.Validation;

namespace UnitConversion.Test
{
    [TestClass]
    public class ConversionValidaterTest
    {
        [TestMethod]
        public void IsValidate_True_Test()
        {
            // Arrange
            ConversionDTO conversionDTO = new ConversionDTO() { Input = "10", SourceUnitId = 1, TargetUnitId = 2, Type = 1 };

            // Act
            bool result = conversionDTO.IsValidate();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void IsValidate_False_Test()
        {
            // Arrange
            ConversionDTO conversionDTO = new ConversionDTO() { Input = "", SourceUnitId = 1, TargetUnitId = 2, Type = 1 };

            // Act
            bool result = conversionDTO.IsValidate();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, false);
        }
    }

}
