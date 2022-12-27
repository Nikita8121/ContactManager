using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ContactManager.Validations
{
    public class NameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string name = Convert.ToString(value);

            return name.Length > 2 ? new ValidationResult(true,null)  : new ValidationResult(false, "Name length should consist from at least two characters");
        }
    }
}
