namespace NumbersToWordsConverter.Tests.Core.Services
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NumbersToWordsConverter.Core.Interfaces;
    using NumbersToWordsConverter.Core.Services;
    using System;

    [TestClass]
    public class CurrencyToWordsConverterTest
    {
        #region "Private Properties"
        private ISplitNumberParts SplitNumberParts { get; set; }
        private INumberToWordsConverter NumberToWordsConverter { get; set; }
        private ICurrencyToWordsConverter CurrencyToWordsConverter { get; set; }
        #endregion

        #region "Constructor"
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyToWordsConverterTest"/> class.
        /// </summary>
        public CurrencyToWordsConverterTest()
        {
            this.SplitNumberParts = new SplitNumberParts();
            this.NumberToWordsConverter = new NumberToWordsConverter(this.SplitNumberParts);
            this.CurrencyToWordsConverter = new CurrencyToWordsConverter(this.NumberToWordsConverter);
        }
        #endregion

        #region "Test Currency Name Params"
        [TestMethod]
        public void TestCurrencyNameParameters()
        {
            // Arrange
            var input = 25.50;
            var currencyName = "testdollar";
            var currencyCentName = "testcent";

            // Act
            var result = this.CurrencyToWordsConverter.Convert(input, currencyName, currencyCentName);

            // Assert
            Assert.IsTrue(result.Equals("TWENTY-FIVE " + currencyName + "s AND FIFTY " + currencyCentName + "s", StringComparison.OrdinalIgnoreCase));
        }
        public void TestCurrencyNameEmptyParameters()
        {
            // Arrange
            var input = 25.50;
            var currencyName = "";
            var currencyCentName = "";

            // Act
            var result = this.CurrencyToWordsConverter.Convert(input, currencyName, currencyCentName);

            // Assert
            Assert.IsTrue(result.Equals("TWENTY-FIVE DOLLARS AND FIFTY CENTS", StringComparison.OrdinalIgnoreCase));
        }
        #endregion

        #region "Test Error Cases"
        [TestMethod]
        public void TestCurrencyExceptionOnNegativeAmount()
        {
            // Arrange
            var input = -10;
            var errorMessage = string.Empty;

            // Act
            try
            {
                var result = this.CurrencyToWordsConverter.Convert(input);
            }
            catch (Exception exp)
            {
                errorMessage = exp.Message;
            }

            // Assert
            Assert.IsTrue(!string.IsNullOrEmpty(errorMessage));
        }
        #endregion

        #region "Test Result Formatting"
        [TestMethod]
        public void TestCurrencyResultFormatPositive()
        {
            // Arrange
            var input = 10;

            // Act
            var result = this.CurrencyToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("TEN DOLLARS", StringComparison.Ordinal));
        }
        [TestMethod]
        public void TestCurrencyResultFormatNegative()
        {
            // Arrange
            var input = 10;

            // Act
            var result = this.CurrencyToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(!result.Equals("ten dollars", StringComparison.Ordinal));
        }
        #endregion

        #region "Test Single Digit Currency"
        /// <summary>
        /// Tests the currency to word.
        /// </summary>
        [TestMethod]
        public void TestCurrencyZeroToWord()
        {
            // Arrange
            var input = 0;

            // Act
            var result = this.CurrencyToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("ZERO", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tests the currency to word.
        /// </summary>
        [TestMethod]
        public void TestCurrencySingleDigitOneToWord()
        {
            // Arrange
            var input = 1;

            // Act
            var result = this.CurrencyToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("ONE DOLLAR", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tests the currency to word.
        /// </summary>
        [TestMethod]
        public void TestCurrencySingleDigitNineToWord()
        {
            // Arrange
            var input = 9;

            // Act
            var result = this.CurrencyToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("NINE DOLLARS", StringComparison.OrdinalIgnoreCase));
        }
        #endregion

        #region "Test Double Digit Currency"
        /// <summary>
        /// Tests the currency to word.
        /// </summary>
        [TestMethod]
        public void TestCurrencyDoubleDigitTenToWord()
        {
            // Arrange
            var input = 10;

            // Act
            var result = this.CurrencyToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("TEN DOLLARS", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tests the currency to word.
        /// </summary>
        [TestMethod]
        public void TestCurrencyDoubleDigitNineteenToWord()
        {
            // Arrange
            var input = 19;

            // Act
            var result = this.CurrencyToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("nineteen dollars", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestCurrencyDoubleDigitLessThanThirtyToWord()
        {
            // Arrange
            var input = 23;

            // Act
            var result = this.CurrencyToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("twenty-three dollars", StringComparison.OrdinalIgnoreCase));
        }
        #endregion

        #region "Test Cents Only"
        [TestMethod]
        public void TestCurrencyOneCentOnly()
        {
            // Arrange
            var input = 0.01;

            // Act
            var result = this.CurrencyToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("ONE CENT", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestCurrencySignleDigitCentsOnly()
        {
            // Arrange
            var input = 0.1;

            // Act
            var result = this.CurrencyToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("TEN CENTS", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestCurrencyDoubleDigitCentsOnly()
        {
            // Arrange
            var input = 0.53;

            // Act
            var result = this.CurrencyToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("FIFTY-THREE CENTS", StringComparison.OrdinalIgnoreCase));
        }
        #endregion

        #region "Test Dollars and Cents"
        [TestMethod]
        public void TestCurrencySingleDollarSingleCent()
        {
            // Arrange
            var input = 1.01;

            // Act
            var result = this.CurrencyToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("ONE DOLLAR AND ONE CENT", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestCurrencyMultipleDollarsSingleCent()
        {
            // Arrange
            var input = 4.01;

            // Act
            var result = this.CurrencyToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("FOUR DOLLARS AND ONE CENT", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestCurrencySingleDollarMultipleCents()
        {
            // Arrange
            var input = 1.39;

            // Act
            var result = this.CurrencyToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("ONE DOLLAR AND THIRTY-NINE CENTS", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestCurrencyMultipleDollarsMultipleCents()
        {
            // Arrange
            var input = 99.36;

            // Act
            var result = this.CurrencyToWordsConverter.Convert(input);

            // Assert
            Assert.IsTrue(result.Equals("NINETY-NINE DOLLARS AND THIRTY-SIX CENTS", StringComparison.OrdinalIgnoreCase));
        }
        #endregion
    }
}
