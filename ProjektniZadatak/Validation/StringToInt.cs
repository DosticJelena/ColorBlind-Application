using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjektniZadatak.Validation
{
    public class StringToInt : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                int r;
                if (int.TryParse(s, out r))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Please enter a valid integer value.");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }

    public class IdEtiketaValidationRule : ValidationRule
    {
        Species sWindow;
        public IdEtiketaValidationRule(Species s)
        {
            sWindow = s;
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                int r;
                int.TryParse(s, out r);
                
                //Ako postoji taj id

                return new ValidationResult(false, "Unesena id vrednost nije jedinstvena.");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }

    public class EValidationRule : ValidationRule
    {
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string content = value.ToString();

            if (string.Equals(content, ""))
            {
                return new ValidationResult(false, "Field can not be empty!");

            }
            else
                return new ValidationResult(true, null);
        }
    }
    
    
}
