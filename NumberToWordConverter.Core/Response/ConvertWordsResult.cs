using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConverter.Core.Response
{
    /// <summary>
    /// Convert Words Result Response Class
    /// </summary>
    public class ConvertWordsResult
    {
        /// <summary>
        /// Check response is success
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Error Message
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Currency Words in Result
        /// </summary>
        public string CurrencyWords { get; set; }
        /// <summary>
        /// Name response
        /// </summary>
        public string Name { get; set; }
    }
}
