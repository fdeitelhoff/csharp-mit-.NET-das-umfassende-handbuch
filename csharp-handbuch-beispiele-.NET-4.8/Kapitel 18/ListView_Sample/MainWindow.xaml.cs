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

namespace ListView_Sample
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lstView.ItemsSource = CreatePersonList();
        }

        private List<Person> CreatePersonList()
        {
            List<Person> liste = new List<Person>();
            liste.Add(new Person { Name = "Alexander Meier", City = "Celle", Age = 35 });
            liste.Add(new Person { Name = "Joachim Terborn", City = "München", Age = 51 });
            liste.Add(new Person { Name = "Gert Fröhlich", City = "Bremen", Age = 29 });
            liste.Add(new Person { Name = "Beate Fischer", City = "Chemnitz", Age = 63 });
            liste.Add(new Person { Name = "Helmut Peters", City = "Mannheim", Age = 40 });
            liste.Add(new Person { Name = "Ahmet Gundocan", City = "Hannover", Age = 33 });
            return liste;
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
}
