namespace NumbersToWordsConverter.Core.Services
{
    using Interfaces;
    using Models;
    using System;

    /// <summary>
    /// SplitNumberParts
    /// Splits the passed double value to integer and fraction part
    /// Input: 24.35
    /// Outout: 24 and 35
    /// Returns: SplitResponse
    /// </summary>
    /// <seealso cref="NumbersToWordsConverter.Core.Interfaces.ISplitNumberParts" />
    public class SplitNumberParts : ISplitNumberParts
    {
        #region "ISplitNumberParts Implementation"        
        /// <summary>
        /// Splits the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        /// SplitResponse
        /// </returns>
        public SplitResponse Split(double number)
        {
            var response = new SplitResponse();
            response.NumberPart = this.GetNumberPart(number);
            response.FractionPart = this.GetFractionPart(number);
            return response;
        }
        #endregion

        #region "Private Methods"
        /// <summary>
        /// Gets the number part.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private int GetNumberPart(double number)
        {
            var result = 0;

            if (number > 0)
            {
                result = (int)Math.Floor(number);
            }
            else
            {
                result = (int)Math.Ceiling(number);
            }

            return result;
        }

        /// <summary>
        /// Gets the fraction part.
        /// </summary>
        /// <param name="fraction">The fraction.</param>
        /// <returns></returns>
        public int GetFractionPart(double fraction)
        {
            //Ignore the -ve values for the fraction part.
            //11.45 should return 45
            //-11.45 should return 45

            fraction = Math.Abs(fraction);

            var number = GetNumberPart(fraction);
            fraction = fraction - number;

            //Convert to number
            fraction = Math.Round(fraction * 100, 2);

            //Take the integer part
            var result = (int)fraction;

            return result;
        }
        #endregion
    }
}
