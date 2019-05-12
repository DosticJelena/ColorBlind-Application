﻿using System;
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
