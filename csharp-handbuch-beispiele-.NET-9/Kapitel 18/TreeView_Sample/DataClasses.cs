using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeView_Sample
{
    public class Product : PropertyObservable
    {
        private int productID;
        public int ProductID { get => productID; set => SetProperty(ref productID, value); }

        private string productName;
        public string ProductName { get => productName; set => SetProperty(ref productName, value); }

        private decimal unitPrice;
        public decimal UnitPrice { get => unitPrice; set => SetProperty(ref unitPrice, value); }

        private short unitsInStock;
        public short UnitsInStock { get => unitsInStock; set => SetProperty(ref unitsInStock, value); }

        private short unitsOnOrder;
        public short UnitsOnOrder { get => unitsOnOrder; set => SetProperty(ref unitsOnOrder, value); }

        private ObservableCollection<OrderDetail> orderDetails;
        public ObservableCollection<OrderDetail> OrderDetails
        {
            get => orderDetails;
            set => SetProperty(ref orderDetails, value);
        }
    }


    public class OrderDetail : PropertyObservable
    {
        private int productID;
        public int ProductID { get => productID; set => SetProperty(ref productID, value); }

        private int orderID;
        public int OrderID { get => orderID; set => SetProperty(ref orderID, value); }

        private decimal unitPrice;
        public decimal UnitPrice { get => unitPrice; set => SetProperty(ref unitPrice, value); }

        private short quantity;
        public short Quantity { get => quantity; set => SetProperty(ref quantity, value); }

        private float discount;
        public float Discount { get => discount; set => SetProperty(ref discount, value); }
    }


    public class Category : PropertyObservable
    {
        private int categoryID;
        public int CategoryID { get => categoryID; set => SetProperty(ref categoryID, value); }

        private string categoryName;
        public string CategoryName { get => categoryName; set => SetProperty(ref categoryName, value); }

        private string description;
        public string Description { get => description; set => SetProperty(ref description, value); }

        private byte[] image;
        public byte[] Image { get => image; set => SetProperty(ref image, value); }

        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get => products;
            set => SetProperty(ref products, value);
        }
    }
}
