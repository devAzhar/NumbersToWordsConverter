namespace NumbersToWordsConverter.Core.Models
{
    public class SplitResponse
    {
        #region "Constructor"
        public SplitResponse()
        {
            this.NumberPart = 0;
            this.FractionPart = 0;
        }
        #endregion

        #region "Public Properties"
        /// <summary>
        /// Gets or sets the number part.
        /// </summary>
        /// <value>
        /// The number part.
        /// </value>
        public int NumberPart { get; set; }

        /// <summary>
        /// Gets or sets the fraction part.
        /// </summary>
        /// <value>
        /// The fraction part.
        /// </value>
        public int FractionPart { get; set; }
        #endregion
    }
}