namespace NumbersToWordsConverter.Core.Services
{
    using System;
    using Interfaces;
    using Models;
    using System.Collections.Generic;

    public class NumberToWordsConverter : INumberToWordsConverter
    {
        #region "Private Static Members"
        private static readonly IDictionary<int, string> SingleDigitStrings = null;
        private static readonly IDictionary<int, string> DoubleDigitStrings = null;
        #endregion

        #region "Static Constructor"
        /// <summary>
        /// Initializes the <see cref="CommonFunctions"/> class.
        /// </summary>
        static NumberToWordsConverter()
        {
            SingleDigitStrings = new Dictionary<int, string>();
            DoubleDigitStrings = new Dictionary<int, string>();

            SingleDigitStrings.Add(0, "zero");
            SingleDigitStrings.Add(1, "one");
            SingleDigitStrings.Add(2, "two");
            SingleDigitStrings.Add(3, "three");
            SingleDigitStrings.Add(4, "four");
            SingleDigitStrings.Add(5, "five");
            SingleDigitStrings.Add(6, "six");
            SingleDigitStrings.Add(7, "seven");
            SingleDigitStrings.Add(8, "eight");
            SingleDigitStrings.Add(9, "nine");
            SingleDigitStrings.Add(10, "ten");
            SingleDigitStrings.Add(11, "eleven");
            SingleDigitStrings.Add(12, "twelve");
            SingleDigitStrings.Add(13, "thirteen");
            SingleDigitStrings.Add(14, "fourteen");
            SingleDigitStrings.Add(15, "fifteen");
            SingleDigitStrings.Add(16, "sixteen");
            SingleDigitStrings.Add(17, "seventeen");
            SingleDigitStrings.Add(18, "eighteen");
            SingleDigitStrings.Add(19, "nineteen");

            DoubleDigitStrings.Add(0, "zero");
            DoubleDigitStrings.Add(1, "ten");
            DoubleDigitStrings.Add(2, "twenty");
            DoubleDigitStrings.Add(3, "thirty");
            DoubleDigitStrings.Add(4, "forty");
            DoubleDigitStrings.Add(5, "fifty");
            DoubleDigitStrings.Add(6, "sixty");
            DoubleDigitStrings.Add(7, "seventy");
            DoubleDigitStrings.Add(8, "eighty");
            DoubleDigitStrings.Add(9, "ninety");
        }
        #endregion

        #region "Private Members"
        private ISplitNumberParts SplitNumberParts { get; set; }
        #endregion

        #region "Constructor"            
        /// <summary>
        /// Initializes a new instance of the <see cref="NumberToWordsConverter" /> class.
        /// </summary>
        /// <param name="splitNumberParts">The split number parts.</param>
        public NumberToWordsConverter(ISplitNumberParts splitNumberParts)
        {
            this.SplitNumberParts = splitNumberParts;
        }
        #endregion

        #region "INumberToWordsConverter Implementation"
        /// <summary>
        /// Converts the specified number.
        /// E.g. 123 to "ONE HUNDRED AND TWENTY-THREE"
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public virtual string Convert(int number)
        {
            var words = string.Empty;
            var negativeSign = "minus";
            var separator = "-";
            var wordSeparator = "and";
            var billion = 1000000000;
            var million = 1000000;
            var thousand = 1000;
            var hundred = 100;

            if (number == 0)
            {
                return SingleDigitStrings[0];
            }
            else if (number < 0)
            {
                return string.Format("{0} {1}", negativeSign, this.Convert(Math.Abs(number)));
            }

            //Convert the billion part
            if (number / billion > 0)
            {
                words = words + this.Convert(number / billion) + " billion ";
                number = number % billion; ;
            }

            //Convert the million part
            if (number / million > 0)
            {
                words = words + this.Convert(number / million) + " million ";
                number = number % million;
            }

            //Convert the thousand part
            if (number / thousand > 0)
            {
                words = words + this.Convert(number / thousand) + " thousand ";
                number = number % thousand;
            }

            //Convert the hundrad part
            if (number / hundred > 0)
            {
                words = words + this.Convert(number / hundred) + " hundred ";
                number = number % hundred;
            }

            //Put in the final separator id still left with some words there
            //Put in the final separator id still left with some words there
            if (number > 0)
            {
                if (!string.IsNullOrEmpty(words))
                {
                    words = words + wordSeparator + " ";
                }

                //number is less than 20, show the single digit with it
                if (number < 20)
                {
                    words = words + SingleDigitStrings[number];
                }
                else
                {
                    //get the double digit part
                    words = words + DoubleDigitStrings[number / 10];

                    //get the last single digit part
                    if ((number % 10) > 0)
                    {
                        words = words + separator + SingleDigitStrings[number % 10];
                    }
                }
            }

            return words.TrimEnd();
        }

        /// <summary>
        /// Converts the specified number into words
        /// E.g. 123.45 to "ONE HUNDRED AND TWENTY-THREE, FORTY-FIVE"
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>ConvertResponse</returns>
        public virtual ConvertResponse Convert(double number)
        {
            var response = new ConvertResponse();

            var splitResponse = this.SplitNumberParts.Split(number);
            response.SplitResponse = splitResponse;

            response.NumberPartWord = this.Convert(splitResponse.NumberPart);
            response.FractionPartWord = this.Convert(splitResponse.FractionPart);

            return response;
        }
        #endregion
    }
}
