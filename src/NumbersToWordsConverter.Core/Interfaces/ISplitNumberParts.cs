namespace NumbersToWordsConverter.Core.Interfaces
{
    using Models;

    /// <summary>
    /// ISplitNumberParts
    /// </summary>
    public interface ISplitNumberParts
    {
        /// <summary>
        /// Splits the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>SplitResponse</returns>
        SplitResponse Split(double number);
    }
}
