using ProjektniZadatak.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                return new ValidationResult(false, "Unesite celobrojnu vrednost. ");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured. ");
            }
        }
    }

    public class StringToDouble : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                double r;
                if (double.TryParse(s, out r))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Unesite broj. ");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured. ");
            }
        }
    }

    public class Z_IdValidationRule : ValidationRule
    {
        Species window;
        ObservableCollection<Animal> Zivotinje = new ObservableCollection<Animal>();

        public Z_IdValidationRule()
        {
            Zivotinje = (ObservableCollection<Animal>)window.zivotinje.SelectedItems[0];
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                int r;
                int.TryParse(s, out r);
                
                if (Zivotinje.Any(x => x.Id == window.IdZivotinje.Text))
                {
                    return new ValidationResult(false, "Unesena id vrednost nije jedinstvena.");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
                
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
    
}
