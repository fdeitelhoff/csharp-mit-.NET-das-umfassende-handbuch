using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace SortDescription_Sample
{
    public partial class MainWindow : Window
    {
        SortDescription sortProductID = new SortDescription("ProductID", ListSortDirection.Ascending);
        SortDescription sortProductName = new SortDescription("ProductName", ListSortDirection.Ascending);
        SortDescription sortUnitPrice = new SortDescription("UnitPrice", ListSortDirection.Ascending);
        private ListCollectionView view;

        public MainWindow()
        {
            InitializeComponent();
            using (var context = new NorthwindEntities())
            {
                var query = context.Products.ToList();
                view = (ListCollectionView)CollectionViewSource.GetDefaultView(query);
                DataContext = view;
                view.CurrentChanged += view_CurrentChanged;
                
                cboSort.Items.Add("ProductID");
                cboSort.Items.Add("ProductName");
                cboSort.Items.Add("UnitPrice");

                view.SortDescriptions.Add(sortProductID);
                lstProducts.SelectedIndex = 0;
                cboSort.SelectedIndex = 0;
            }
        }

        void view_CurrentChanged(object sender, EventArgs e)
        {
            txtPosition.Text = "Datensatz " + (view.CurrentPosition + 1).ToString() + " von " + view.Count.ToString();
            btnPrevious.IsEnabled = view.CurrentPosition > 0;
            btnNext.IsEnabled = view.CurrentPosition < view.Count - 1;
            lstProducts.SelectedIndex = view.CurrentPosition;
        }

        private void lstProducts_SelectionChanged(object sender, SelectionChangedEventArgs e) => view.MoveCurrentTo(lstProducts.SelectedItem);

        private void btnNext_Click(object sender, RoutedEventArgs e) => view.MoveCurrentToNext();

        private void btnPrevious_Click(object sender, RoutedEventArgs e) => view.MoveCurrentToPrevious();

        private void cboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            view.SortDescriptions.Clear();
           string choice = cboSort.SelectedItem.ToString();
            switch (choice)
            {
                case "ProductID":
                    view.SortDescriptions.Add(sortProductID);
                    break;
                case "ProductName":
                    view.SortDescriptions.Add(sortProductName);
                    break;
                case "UnitPrice":
                    view.SortDescriptions.Add(sortUnitPrice);
                    break;
            }
        }
    }
}
