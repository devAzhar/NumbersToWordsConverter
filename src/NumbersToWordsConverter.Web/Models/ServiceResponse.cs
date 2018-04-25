using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumbersToWordsConverter.Web.Models
{
    public sealed class ServiceResponse
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public string Result { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }
    }
}