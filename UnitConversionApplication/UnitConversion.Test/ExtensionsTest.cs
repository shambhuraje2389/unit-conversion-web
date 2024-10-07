using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConversion.Models.Data;
using UnitConversion.Models.DTO;
using UnitConversion.Models.Extensions;

namespace UnitConversion.Test
{
    [TestClass]
    public class ExtensionsTest
    {
        [TestMethod]
        public void EvaluateTest()
        {
            // Arrange
            string expression = "(10*1000)";

            // Act
            double result = expression.Evaluate();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, 10000);
        }
    }
}
