using PersonLibrary1;
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

namespace ListBoxBinding_Sample7
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> list = new List<Person>();

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
    }

    public class ListBoxItemSelector : StyleSelector
    {
        public Style BlueStyle { get; set; }
        public Style GrayStyle { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            ItemsControl control = ItemsControl.ItemsControlFromItemContainer(container);
            int index = control.ItemContainerGenerator.IndexFromContainer(container);

            return index % 2 == 0 ? BlueStyle : GrayStyle;
        }
    }

    public class ListBoxDataSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate PensionTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Person pers = item as Person;
            return pers.Age >= 65 ? PensionTemplate : DefaultTemplate;
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
