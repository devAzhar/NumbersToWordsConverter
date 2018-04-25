namespace NumbersToWordsConverter.Core.Interfaces
{
    using Models;

    /// <summary>
    /// INumberToWordsConverter
    /// </summary>
    public interface INumberToWordsConverter
    {
        /// <summary>
        /// Converts the specified number into words
        /// E.g. 123.45 to "ONE HUNDRED AND TWENTY-THREE, FORTY-FIVE"
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        ConvertResponse Convert(double number);

        /// <summary>
        /// Converts the specified number.
        /// E.g. 123 to "ONE HUNDRED AND TWENTY-THREE"
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        string Convert(int number);
    }
}
