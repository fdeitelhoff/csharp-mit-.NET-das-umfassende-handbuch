using System;
using System.Collections.Generic;
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

namespace ExceptionValidationRule_Sample
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

    public class Person
    {
        private int _Age;
        public int Age
        {
            get => _Age;
            set
            {
                if (value >= 0)
                    _Age = value;
                else
                    throw new ArgumentException("Das Alter kann nicht negativ sein.");
            }
        }
    }
}
