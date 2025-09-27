using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserDefinedValidationRule_Sample
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Person { Age = 34 };
        }
    }


    public class AgeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string wert = value as string;
            if (wert != null)
            {
                if (int.TryParse(wert, out int val))
                {
                    if (val < 0)
                        return new ValidationResult(false, "Alter negativ");
                    else
                        return ValidationResult.ValidResult;
                }
                else
                    return new ValidationResult(false, "Keine Zahlen");
            }
            else
                return new ValidationResult(false, "Allgemeiner Fehler");
        }
    }

    public class Person
    {
        public int Age { get; set; }
    }
}
