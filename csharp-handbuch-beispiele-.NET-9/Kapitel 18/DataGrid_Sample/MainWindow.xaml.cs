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

namespace DataGrid_Sample
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var context = new NorthwindEntities())
            {
                var result = context.Orders.ToList();
                datagrid1.ItemsSource = result;

                var custResult = context.Customers
                    .Select( c => new { c.CustomerID, c.CompanyName})                    
                    .ToList();
                customerColumn.ItemsSource = custResult;
            }
        }
    }
}
