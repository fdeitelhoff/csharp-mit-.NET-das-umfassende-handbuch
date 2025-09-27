using PersonLibrary;
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

namespace CLRObjectBinding
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person pers = new Person { FirstName = "Franz", LastName = "Fischer" };

        public MainWindow()
        {
            InitializeComponent();
            DataContext = pers;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            pers.FirstName = "Peter";
            pers.LastName = "Müller";
        }
    }
}
