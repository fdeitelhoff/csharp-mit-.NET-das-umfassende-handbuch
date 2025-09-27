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

namespace Filter_Sample
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ListCollectionView view;

        public MainWindow()
        {
            InitializeComponent();
            using (var context = new NorthwindEntities())
            {
                var query = context.Products.ToList();
                view = CollectionViewSource.GetDefaultView(query) as ListCollectionView;
                DataContext = view;

                cboFilter.Items.Add("[alle Artikel]");
                // ComboBox füllen
                cboFilter.Items.Add("UnitPrice > 50");
                cboFilter.Items.Add("UnitPrice < 50");
                cboFilter.Items.Add("UnitPrice > 100");
                cboFilter.SelectedIndex = 0;
            }
        }

        private void cboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            view.Filter = new Predicate<object>(SetFilter);
        }

        private bool SetFilter(object obj)
        {
            Product prod = obj as Product;
            if(cboFilter.SelectedItem.ToString() == "[alle Artikel]") return true;
            switch (cboFilter.SelectedItem)
            {
                case "UnitPrice > 50":
                    return prod.UnitPrice > 50;                  
                case "UnitPrice < 50":
                    return prod.UnitPrice < 50;;
                case "UnitPrice > 100":
                    return prod.UnitPrice > 100;
                default:
                    return false;
            }
        }
    }
}
