using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWordsConverter.Core.Models
{
    public class SplitResponse
    {
        public SplitResponse()
        {
            this.NumberPart = 0;
            this.FractionPart = 0;
        }

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
    }
}
