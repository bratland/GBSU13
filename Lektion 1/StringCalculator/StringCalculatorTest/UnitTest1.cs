using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TryCreateCalculator()
        {
            var calc = new Calculator();
        }

        [TestMethod]
        public void TryAddEmptyString()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            var result = calc.Add("");

            // Assert
            Assert.AreEqual(0, result, "Empty string should return 0");
        }

        [TestMethod]
        public void TryAddNumber()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            var result = calc.Add("5");

            // Assert
            Assert.AreEqual(5, result, "Result should be 5");
        }

        [TestMethod]
        public void TryAddListOfNumbers()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            var result = calc.Add("1, 2, 3, 4, 5");

            // Assert
            Assert.AreEqual(15, result, "Result should be 15");
        }

        [TestMethod]
        public void TryAddNumbersWithNewLines()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            var result = calc.Add("1\n2,3");

            // Assert
            Assert.AreEqual(6, result, "Result should be 6");
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TryNotAllowedSyntaxOfNumbers()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            var result = calc.Add("1,\n");

            // Assert
            Assert.AreEqual(0, result, "Result should be 0");
        }

        [TestMethod]
        public void TryDelimeterSyntax()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            var result = calc.Add("//;\n1;2");

            // Assert
            Assert.AreEqual(3, result, "Result should be 3");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TrySubracting()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            var result = calc.Add("1, 2, -3, -4");

        }

        [TestMethod]
        public void TryIgnoringNumbersAboveThousand()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            var result = calc.Add("1, 2, 1001, 1002");

            // Assert
            Assert.AreEqual(3, result, "Result should be 3");
        }

        [TestMethod]
        public void AllowDelimitersWithMultipleChars()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            var result = calc.Add("//[***]\n1***2***3");

            // Assert
            Assert.AreEqual(6, result, "Result should be 6");
        }

        [TestMethod]
        public void TryIgnoringMultipleDelimeters()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            var result = calc.Add("//[*][%]\n1*2%3");

            // Assert
            Assert.AreEqual(6, result, "Result should be 6");
        }
    }
}
