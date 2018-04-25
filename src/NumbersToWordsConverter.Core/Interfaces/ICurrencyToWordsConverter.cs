using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWordsConverter.Core.Interfaces
{
    /// <summary>
    /// ICurrencyToWordsConverter
    /// </summary>
    public interface ICurrencyToWordsConverter
    {
        /// <summary>
        /// Converts the specified currency.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="currencyName">Name of the currency.</param>
        /// <param name="currencyCentsName">Name of the currency cents.</param>
        /// <returns></returns>
        string Convert(double amount, string currencyName="dollar", string currencyCentsName="cent");
    }
}
