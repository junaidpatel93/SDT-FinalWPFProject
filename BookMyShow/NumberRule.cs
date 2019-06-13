using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
    ///     Number rule, implements ValidateionRule. Validates the data based on min and max values.
    ///     Property is bind with the control
    /// 
    /// </summary>
    class NumberRule : ValidationRule
    {
        private int min;
        private int max;

        public int Min { get => min; set => min = value; }
        public int Max { get => max; set => max = value; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int seatNumberInput = 1;
            if (!int.TryParse((string)value, out seatNumberInput))
            {
                return new ValidationResult(false,
                    string.Format("Invalid data. Number range must be ({0}-{1})", min, max));
            }
            if (seatNumberInput < min || seatNumberInput > max)
            {
                return new ValidationResult(false,
                    string.Format("Invalid data. Number range must be ({0}-{1})"
                    , min, max));
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
       
    }
}
