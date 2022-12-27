using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ContactManager.Validations
{
    public class PhoneValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string phone = Convert.ToString(value);

            return phone.IndexOf("_") < 0 ? ValidationResult.ValidResult : new ValidationResult(false, "Fill up your phone number");
        }
    }
}
