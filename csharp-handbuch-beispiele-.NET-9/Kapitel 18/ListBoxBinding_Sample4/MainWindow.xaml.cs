using PersonLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ListBoxBinding_Sample4
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Person> list = new ObservableCollection<Person>();

        public MainWindow()
        {
            InitializeComponent();
            createPersons();
            listbox1.ItemsSource = list;
            listbox1.SelectedIndex = 0;
            listbox1.Focus();
        }

        private void createPersons()
        {
            list.Add(new Person { FirstName = "Udo", LastName = "Meier", Age = 55, City = "Bonn" });
            list.Add(new Person { FirstName = "Tom", LastName = "Fischer", Age = 32, City = "Bonn" });
            list.Add(new Person { FirstName = "Knut", LastName = "Schneider", Age = 59, City = "Ulm" });
            list.Add(new Person { FirstName = "Peter", LastName = "Schmitz", Age = 21, City = "Kiel" });
            list.Add(new Person { FirstName = "Michael", LastName = "Krause", Age = 76, City = "Worms" });
            list.Add(new Person { FirstName = "Franz", LastName = "Müller", Age = 36, City = "Aachen" });
            list.Add(new Person { FirstName = "Heiner", LastName = "Schulz", Age = 69, City = "Bremen" });
            list.Add(new Person { FirstName = "Kurt", LastName = "Schulte", Age = 30, City = "Hamburg" });
            list.Add(new Person { FirstName = "Willi", LastName = "Wegener", Age = 18, City = "Köln" });
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            list.Add(new Person());
            listbox1.SelectedIndex = listbox1.Items.Count - 1;
            txtFirstName.Focus();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = listbox1.SelectedIndex;
            if (list.Count > 0)
            {
                list.RemoveAt(index);
                if (index > 0)
                    listbox1.SelectedIndex = index - 1;
                else
                    listbox1.SelectedIndex = 0;
            }
            else
                MessageBox.Show("Löschen nicht möglich. Die Liste ist leer.");
        }
    }

    public class PersonConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)values[0] + ", " + (string)values[1];
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

}
