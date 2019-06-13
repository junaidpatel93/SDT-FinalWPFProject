using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BookMyShow
{
    /// <summary>
    /// 
    /// ==================================================================
    ///                             CREATED BY
    /// ------------------------------------------------------------------
    ///                             GAURAV BABBAR,
    ///                             JUNAID PATEL,
    ///                             PRIYANKA MONDAL,
    ///                             RUTAV KOTHARI.
    /// ==================================================================
    /// ==================================================================
    /// Description:
    ///     Number rule, implements ValidateionRule. Validates the data based on Regex.
    /// 
    /// </summary>
    /// 
    public class NameRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string nameRule = value.ToString();
            Regex regex = new Regex(@"^[a-zA-Z-,]+(\s{0,1}[a-zA-Z-, ])*$");
            Match match = regex.Match(nameRule);
            if (!match.Success)
            {
                return new ValidationResult(false,
                    string.Format("Invalid data. Name contains only characters"));
            }            
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
