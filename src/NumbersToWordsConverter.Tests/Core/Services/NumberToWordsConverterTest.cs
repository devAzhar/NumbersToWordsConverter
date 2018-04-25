namespace NumbersToWordsConverter.Tests.Core.Services
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NumbersToWordsConverter.Core.Interfaces;
    using NumbersToWordsConverter.Core.Services;
    using System;

    [TestClass]
    public class NumberToWordsConverterTest
    {
        #region "Private Properties"
        private INumberToWordsConverter NumberToWordsConverter { get; set; }
        private ISplitNumberParts SplitNumberParts { get; set; }
        #endregion

        #region "Constructor"
        /// <summary>
        /// Initializes a new instance of the <see cref="NumberToWordsConverterTest"/> class.
        /// </summary>
        public NumberToWordsConverterTest()
        {
            this.SplitNumberParts = new SplitNumberParts();
            this.NumberToWordsConverter = new NumberToWordsConverter(this.SplitNumberParts);
        }
        #endregion

        #region "Tests for Convert(int)"        
        /// <summary>
        /// Tests the convert integer to word.
        /// </summary>
        [TestMethod]
        public void TestConvertPositiveSmallIntegerToWord()
        {
            // Arrange
            var input = 1;

            // Act
            var result = NumberToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("ONE", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tests the negative single digit to word.
        /// </summary>
        [TestMethod]
        public void TestConvertIntNegative()
        {
            // Arrange
            var input = -9;

            // Act
            var result = this.NumberToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("minus nine", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tests the negative single digit to word.
        /// </summary>
        [TestMethod]
        public void TestConvertIntLessThan10()
        {
            // Arrange
            var input = 9;

            // Act
            var result = this.NumberToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("nine", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tests the negative single digit to word.
        /// </summary>
        [TestMethod]
        public void TestConvertIntLessThan20()
        {
            // Arrange
            var input = 17;

            // Act
            var result = this.NumberToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("seventeen", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tests the negative single digit to word.
        /// </summary>
        [TestMethod]
        public void TestConvertIntLessThan30()
        {
            // Arrange
            var input = 27;

            // Act
            var result = this.NumberToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("twenty-seven", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tests the negative single digit to word.
        /// </summary>
        [TestMethod]
        public void TestConvertIntLessThan100()
        {
            // Arrange
            var input = 90;

            // Act
            var result = this.NumberToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("ninety", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tests the negative single digit to word.
        /// </summary>
        [TestMethod]
        public void TestConvertIntLessThan1000()
        {
            // Arrange
            var input = 567;

            // Act
            var result = this.NumberToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("five hundred and sixty-seven", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tests the negative single digit to word.
        /// </summary>
        [TestMethod]
        public void TestConvertIntLessThan10000()
        {
            // Arrange
            var input = 9841;

            // Act
            var result = this.NumberToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("nine thousand eight hundred and forty-one", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestConvertIntMillion()
        {
            // Arrange
            var input = 3000000;

            // Act
            var result = this.NumberToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("three million", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestConvertIntBillion()
        {
            // Arrange
            var input = 2000000000;

            // Act
            var result = this.NumberToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("two billion", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tests the negative single digit to word.
        /// </summary>
        [TestMethod]
        public void TestConvertIntZero()
        {
            // Arrange
            var input = 0;

            // Act
            var result = this.NumberToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("zero", StringComparison.OrdinalIgnoreCase));
        }
        #endregion

        #region "Tests for Convert(double)"        
        /// <summary>
        /// Tests the convert number to word.
        /// </summary>
        [TestMethod]
        public void TestConvertNumberToWord()
        {
            // Arrange
            var input = 12.55;

            // Act
            var result = NumberToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.NumberPartWord.Equals("TWELVE", StringComparison.OrdinalIgnoreCase) && result.FractionPartWord.Equals("FIFTY-FIVE", StringComparison.OrdinalIgnoreCase));
        }
        #endregion
    }
}