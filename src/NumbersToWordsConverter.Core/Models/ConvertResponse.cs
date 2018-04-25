namespace NumbersToWordsConverter.Core.Models
{
    public sealed class ConvertResponse
    {
        #region "Constructor"
        /// <summary>
        /// Initializes a new instance of the <see cref="ConvertResponse"/> class.
        /// </summary>
        public ConvertResponse()
        {
            this.NumberPartWord = string.Empty;
            this.FractionPartWord = string.Empty;
        }
        #endregion

        #region "Public Properties"
        public SplitResponse SplitResponse { get; set; }
        /// <summary>
        /// Gets or sets the number part word.
        /// </summary>
        /// <value>
        /// The number part word.
        /// </value>
        public string NumberPartWord { get; set; }

        /// <summary>
        /// Gets or sets the fraction part word.
        /// </summary>
        /// <value>
        /// The fraction part word.
        /// </value>
        public string FractionPartWord { get; set; }
        #endregion
    }
}
