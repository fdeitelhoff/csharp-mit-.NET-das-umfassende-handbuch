using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace BindingGroupValidation_Sample
{
    class PersonValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            BindingGroup bindingGroup = value as BindingGroup;
            if (bindingGroup.Items.Count == 1)
            {
                Person pers = bindingGroup.Items[0] as Person;
                string vorname = bindingGroup.GetValue(pers, "Vorname") as string;
                string zuname = bindingGroup.GetValue(pers, "Zuname") as string;
                if (string.IsNullOrWhiteSpace(vorname) || string.IsNullOrWhiteSpace(zuname))
                    return new ValidationResult(false, "Geben Sie Vorname und Nachname an");
            }
            return ValidationResult.ValidResult;
        }
    }
}