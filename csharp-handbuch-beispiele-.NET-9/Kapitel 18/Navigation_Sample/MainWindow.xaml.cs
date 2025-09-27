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

namespace Navigation_Sample
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
                view = (ListCollectionView)CollectionViewSource.GetDefaultView(query);
                DataContext = view;

                view.CurrentChanged += view_CurrentChanged;
            }
        }

        void view_CurrentChanged(object sender, EventArgs e)
        {
            txtPosition.Text = "Datensatz " + (view.CurrentPosition + 1).ToString() + " von " + view.Count.ToString();
            btnPrevious.IsEnabled = view.CurrentPosition > 0;
            btnNext.IsEnabled = view.CurrentPosition < view.Count - 1;
            lstProducts.SelectedIndex = view.CurrentPosition;
            lstProducts.ScrollIntoView(lstProducts.SelectedItem);
        }

        private void lstProducts_SelectionChanged(object sender, SelectionChangedEventArgs e) => view.MoveCurrentTo(lstProducts.SelectedItem);        

        private void btnNext_Click(object sender, RoutedEventArgs e) => view.MoveCurrentToNext();

        private void btnPrevious_Click(object sender, RoutedEventArgs e) => view.MoveCurrentToPrevious();
    }
}
