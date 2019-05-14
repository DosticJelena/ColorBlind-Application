using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjektniZadatak.Validation
{
    public class EmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                value = "";
            }
            string content = value.ToString();

            if (string.Equals(content, ""))
            {
                return new ValidationResult(false, "Polje nije popunjeno. ");

            }
            else
            {
                return new ValidationResult(true, null);

            }
        }
    }

    public class EmptyValidationRuleShort : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                value = "";
            }
            string content = value.ToString();

            if (string.Equals(content, ""))
            {
                return new ValidationResult(false, "!  ");

            }
            else
            {
                return new ValidationResult(true, null);

            }
        }
    }

}
