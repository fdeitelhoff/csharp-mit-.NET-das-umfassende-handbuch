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

namespace BindingGroupValidation_Sample
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person pers = new Person();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = pers;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Vorname: {pers.Vorname}, Zuname: {pers.Zuname}", "Vor CommitEdit");
            if (BindingGroup.CommitEdit())
                MessageBox.Show($"Vorname: {pers.Vorname}, Zuname: {pers.Zuname}", "Nach CommitEdit");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.BindingGroup.CancelEdit();
        }
    }

    class Person
    {
        public string Vorname { get; set; }
        public string Zuname { get; set; }
    }
}
