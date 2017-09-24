using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NumberToWordConverter.Core.ViewModel
{
    /// <summary>
    /// Convert Words View Model
    /// </summary>
    public class ConvertWordsModel
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the currency
        /// </summary>
        [Required]
        [Range(0, 9999999999.99,ErrorMessage ="Please type the value upto Billions")]
        public decimal Currency { get; set; }
    }
}