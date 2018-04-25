namespace NumbersToWordsConverter.Core.Services
{
    using Interfaces;
    using System;

    /// <summary>
    /// CurrencyToWordsConverter
    /// </summary>
    /// <seealso cref="NumbersToWordsConverter.Core.Interfaces.ICurrencyToWordsConverter" />
    public class CurrencyToWordsConverter : ICurrencyToWordsConverter
    {
        #region "Private Properties"
        private INumberToWordsConverter NumberToWordsConverter { get; set; }
        #endregion

        #region "Constructor"
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyToWordsConverter"/> class.
        /// </summary>
        /// <param name="numberToWordsConverter">The number to words converter.</param>
        /// <param name="currencyName">Name of the currency.</param>
        /// <param name="currencyCentsName">Name of the currency cents.</param>
        public CurrencyToWordsConverter(INumberToWordsConverter numberToWordsConverter)
        {
            this.NumberToWordsConverter = numberToWordsConverter;
        }
        #endregion

        #region "ICurrencyToWordsConverter Implementation"
        /// <summary>
        /// Converts the specified currency.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="currencyName">Name of the currency.</param>
        /// <param name="currencyCentsName">Name of the currency cents.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public virtual string Convert(double amount, string currencyName = "", string currencyCentsName = "")
        {
            if (amount < 0)
            {
                throw new ArgumentException("Negative number cannot be converted to words.");
            }

            currencyName = string.IsNullOrEmpty(currencyName) ? "dollar" : currencyName;
            currencyCentsName = string.IsNullOrEmpty(currencyCentsName) ? "cent" : currencyCentsName;

            var pluralSymbol = "s";

            //Convert the currency amount to words
            var convertResult = this.NumberToWordsConverter.Convert(amount);

            var result = string.Empty;
            var separator = "and";

            //Handle the case when the return values are 0
            if (convertResult.SplitResponse.NumberPart == 0 && convertResult.SplitResponse.FractionPart == 0)
            {
                result = convertResult.NumberPartWord;
            }
            else
            {
                //Check the number part
                if (convertResult.SplitResponse.NumberPart > 0)
                {
                    currencyName = (convertResult.SplitResponse.NumberPart > 1) ? (currencyName + pluralSymbol) : currencyName;
                    result = string.Format("{0} {1}", convertResult.NumberPartWord, currencyName);
                }

                //Check the fraction part
                if (convertResult.SplitResponse.FractionPart > 0)
                {
                    currencyCentsName = (convertResult.SplitResponse.FractionPart > 1) ? (currencyCentsName + pluralSymbol) : currencyCentsName;
                    result = string.IsNullOrEmpty(result) ? string.Empty : result + string.Format(" {0} ", separator);

                    result = string.Format("{0} {1} {2}", result, convertResult.FractionPartWord, currencyCentsName);
                }
            }

            //Remove extra spaces
            result = result.Replace("  ", " ").Trim();
            //Convert to upper case string as per the requirements
            result = result.ToUpperInvariant();

            return result;
        }
        #endregion
    }
}
