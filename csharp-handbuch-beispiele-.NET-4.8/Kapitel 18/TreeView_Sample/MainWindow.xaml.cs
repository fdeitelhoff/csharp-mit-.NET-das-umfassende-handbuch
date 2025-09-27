using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace TreeView_Sample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            treeView1.ItemsSource = GetData();
        }

        public IList<Category> GetData()
        {
            // Daten laden
            DataSet ds = new DataSet();
            ds.ReadXmlSchema(@"C:\TempData\ElementsSchema.xsd");
            ds.ReadXml(@"C:\TempData\Elements.xml");
            DataRelation relCatProd = ds.Relations["relCategoryProducts"];
            DataRelation relProdOrderdetail = ds.Relations["relProductOrderDetails"];

            ObservableCollection<Category> categories = new ObservableCollection<Category>();
            foreach (DataRow rowCat in ds.Tables["Categories"].Rows)
            {
                // enthält die Produkte jeder einzelnen Kategorie
                ObservableCollection<Product> products = new ObservableCollection<Product>();
                categories.Add(new Category
                {
                    CategoryID = (int)rowCat["CategoryID"],
                    CategoryName = rowCat["CategoryName"].ToString(),
                    Description = rowCat["Description"].ToString(),
                    Image = (byte[])rowCat["Picture"],
                    Products = products
                });

                foreach (DataRow rowProduct in rowCat.GetChildRows(relCatProd))
                {
                    ObservableCollection<OrderDetail> orders = new ObservableCollection<OrderDetail>();
                    products.Add(new Product
                    {
                        ProductID = (int)rowProduct["ProductID"],
                        ProductName = rowProduct["ProductName"].ToString(),
                        UnitPrice = (decimal)rowProduct["UnitPrice"],
                        UnitsInStock = (short)rowProduct["UnitsInStock"],
                        UnitsOnOrder = (short)rowProduct["UnitsOnOrder"],
                        OrderDetails = orders
                    });

                    // alle OrderDetails eines bestimmten Produkts
                    foreach (DataRow orderRow in rowProduct.GetChildRows(relProdOrderdetail))
                    {
                        orders.Add(new OrderDetail
                        {
                            OrderID = (int)orderRow["OrderID"],
                            ProductID = (int)orderRow["ProductID"],
                            Quantity = (short)orderRow["Quantity"],
                            Discount = (float)orderRow["Discount"],
                            UnitPrice = (decimal)rowProduct["UnitPrice"]
                        });
                    }
                }
            }
            return categories;
        }

        private void TreeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (treeView1.SelectedItem is Category)
            {
                gridCategories.Visibility = Visibility.Visible;
                gridProducts.Visibility = Visibility.Collapsed;
                gridOrderDetails.Visibility = Visibility.Collapsed;
            }
            else if (treeView1.SelectedItem is Product)
            {
                gridCategories.Visibility = Visibility.Collapsed;
                gridProducts.Visibility = Visibility.Visible;
                gridOrderDetails.Visibility = Visibility.Collapsed;
            }
            else if (treeView1.SelectedItem is OrderDetail)
            {
                gridCategories.Visibility = Visibility.Collapsed;
                gridProducts.Visibility = Visibility.Collapsed;
                gridOrderDetails.Visibility = Visibility.Visible;
            }
        }
    }
}
