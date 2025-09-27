using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Musterdaten;

namespace Listings
{
    class Program
    {
        static void Main(string[] args)
        {
            // Listing_11_9();
            // Listing_11_14();
            //Listing_11_15();
            //Listing_11_18();
            //Listing_11_20();
            //Listing_11_23();
            //Listing_11_26();
            //Listing_11_27();
            Listing_11_29();
            //Listing_11_30();
            //Listing_11_31();
            //Listing_11_32();
            //Listing_11_33();
            //Listing_11_34();
            //Listing_11_35();
            //Listing_11_37();
            //Listing_11_38();
            //Listing_11_39();
            //Listing_11_40();
            //Listing_11_41();
            //Listing_11_42();
            //Listing_11_43();
            //Listing_11_44();
            //Listing_11_45();
            //Listing_11_46();
            //Listing_11_47();
            Console.ReadLine();
        }

        static void Listing_11_9()
        {
            Customer[] customers = Service.GetCustomers();
            var cust = from customer in customers
                       where customer.Name.Length < 6
                       select new { customer.Name, customer.City };
            foreach (var item in cust)
                Console.WriteLine($"Name: {item.Name}, Ort: {item.City}");
        }

        static void Listing_11_14()
        {
            Customer[] customers = Service.GetCustomers();
            var query = customers
                         .Where(c => c.Name == "Hans")
                         .SelectMany(c => c.Orders)
                         .Where(order => order.Quantity > 6)
                         .Select(order => new { order.OrderID, order.ProductID });

            foreach (var item in query)
                Console.WriteLine($"OrderID: {item.OrderID} - ProductID: {item.ProductID}");
        }

        static void Listing_11_15()
        {
            Customer[] customers = Service.GetCustomers();
            var result = from cust in customers
                         where cust.City == Cities.Aachen
                         select cust.Name;
            foreach (var item in result)
                Console.WriteLine(item);
        }

        static void Listing_11_18()
        {
            Order[] orders = Service.GetOrders();
            var result = orders
                         .Where((order, index) => order.Quantity > 3 && index < 10)
                         .Select(ord => new { ord.OrderID, ord.ProductID, ord.Quantity });
            foreach (var item in result)
                Console.WriteLine($"{item.OrderID,-5}{item.ProductID,-5}{item.Quantity}");
        }

        static void Listing_11_20()
        {
            Order[] orders = Service.GetOrders();
            var result = from order in orders
                         orderby order.Quantity
                         select new { order.OrderID, order.Quantity };
            foreach (var item in result)
                Console.WriteLine($"ID: {item.OrderID,-3}{item.Quantity}");
        }

        static void Listing_11_23()
        {
            Order[] orders = Service.GetOrders();
            var result = orders
                         .OrderBy(order => order.Quantity)
                         .ThenBy(order => order.Shipped)
                         .Select(order => new
                         {
                             order.OrderID,
                             order.Quantity,
                             order.Shipped
                         });
            foreach (var item in result)
                Console.WriteLine("ProductID: {0,-3}Menge:{1,-4} Geliefert:{2}", item.OrderID, item.Quantity, item.Shipped);
        }

        static void Listing_11_26()
        {
            Customer[] customers = Service.GetCustomers();
            var result = customers
                         .GroupBy(cust => cust.City);
            foreach (IGrouping<Cities, Customer> temp in result)
            {
                Console.WriteLine(new string('=', 40));
                Console.WriteLine($"Stadt: {temp.Key}");
                Console.WriteLine(new string('-', 40));
                foreach (var item in temp)
                    Console.WriteLine($"       {item.Name}");

            }
        }

        static void Listing_11_27()
        {
            Order[] orders = Service.GetOrders();
            Product[] products = Service.GetProducts();
            var liste = orders
                        .Join(products,
                              ord => ord.ProductID,
                              prod => prod.ProductID, (a, b) => new
                              {
                                  a.OrderID,
                                  a.ProductID,
                                  b.Price,
                                  a.Quantity
                              });
            foreach (var m in liste)
                Console.WriteLine("Order: {0,-3} Product: {1} Menge: {2} Preis: {3}",
                 m.OrderID, m.ProductID, m.Quantity, m.Price);
        }

        static void Listing_11_29()
        {
            Product[] products = Service.GetProducts();
            Customer[] customers = Service.GetCustomers();
            var liste = products
                        .GroupJoin(customers.SelectMany(cust => cust.Orders),
                         prod => prod.ProductID,
                         ord => ord.ProductID,
                               (a, b) => new { a.ProductID, Orders = b });
            foreach (var t in liste)
            {
                Console.WriteLine("ProductID: {0}", t.ProductID);
                foreach (var order in t.Orders)
                    Console.WriteLine("   OrderID: {0}", order.OrderID);
            }
        }
        
            
        static void Listing_11_30()
        {
            Product[] products = Service.GetProducts();
            Order[] orders = Service.GetOrders();

            var liste = from prod in products
                        join ord in orders
                        on prod.ProductID equals ord.ProductID into allOrders
                        select new { prod.ProductID, Orders = allOrders };

            foreach (var t in liste)
            {
                Console.WriteLine("ProductID: {0}", t.ProductID, t.Orders);
                foreach (var order in t.Orders)
                    Console.WriteLine("   OrderID: {0}", order.OrderID);
            }
        }


        static void Listing_11_31()
        {
            string[] cities = { "Aachen", "Köln", "Bonn", "Aachen", "Bonn", "Hof" };
            var liste = (from p in cities select p).Distinct();
            foreach (string city in liste)
                Console.WriteLine(city);

        }

        static void Listing_11_32()
        {
            string[] cities = { "Aachen", "Bonn", "Aachen", "Frankfurt" };
            string[] namen = { "Peter", "Willi", "Hans" };
            var listeCities = from c in cities
                              select c;
            var listeNamen = from n in namen
                             select n;
            var listeComplete = listeCities.Union(listeNamen);
            foreach (var p in listeComplete)
                Console.WriteLine(p);

        }

        static void Listing_11_33()
        {
            string[] cities1 = { "Aachen", "Köln", "Bonn", "Aachen", "Frankfurt" };
            string[] cities2 = { "Düsseldorf", "Bonn", "Bremen", "Köln" };
            var listeCities1 = from c in cities1
                               select c;
            var listeCities2 = from n in cities2
                               select n;
            var listeComplete = listeCities1.Intersect(listeCities2);
            foreach (var p in listeComplete)
                Console.WriteLine(p);
        }

        static void Listing_11_34()
        {
            Order[] orders = Service.GetOrders();
            var anzahl = (from x in orders
                          select x).Count();
            Console.WriteLine("Anzahl der Bestellungen gesamt = {0}", anzahl);
        }

        static void Listing_11_35()
        {
            Customer[] customers = Service.GetCustomers();
            var orderCounts = from c in customers
                              select new { c.Name, OrderCount = c.Orders.Count() };
            foreach (var k in orderCounts)
                Console.WriteLine("{0} - {1}", k.Name, k.OrderCount);
        }

        static void Listing_11_37()
        {
            Customer[] customers = Service.GetCustomers();
            Product[] products = Service.GetProducts();
            var allOrders = from cust in customers
                            from ord in cust.Orders
                            join prod in products on ord.ProductID equals prod.ProductID
                            select new
                            {
                                cust.Name,
                                ord.ProductID,
                                OrderAmount = ord.Quantity * prod.Price
                            };
            var summe = from cust in customers
                        join ord in allOrders
                        on cust.Name equals ord.Name into custWithOrd
                        select new { cust.Name, TotalSumme = custWithOrd.Sum(s => s.OrderAmount) };

            foreach (var s in summe)
                Console.WriteLine("Name: {0,-7} Bestellsumme: {1}", s.Name, s.TotalSumme);
        }

        static void Listing_11_38()
        {
            Customer[] customers = Service.GetCustomers();
            bool result = (from cust in customers
                           from ord in cust.Orders
                           where cust.Name == "Willi"
                           select new { ord.ProductID })
                           .Any(ord => ord.ProductID == 7);
            if (result)
                Console.WriteLine("ProductID 3 ist enthalten");
            else
                Console.WriteLine("ProductID 3 ist nicht enthalten");
        }

        static void Listing_11_39()
        {
            Product[] prods = Service.GetProducts();
            var result = prods.Take(3);
            foreach (var prod in result)
                Console.WriteLine(prod.ProductName);
        }

        static void Listing_11_40()
        {
            Product[] prods = Service.GetProducts();
            var result = (from prod in prods
                          select new { prod.ProductName, prod.Price })
                          .TakeWhile(n => n.Price > 3);
            foreach (var prod in result)
                Console.WriteLine("{0,-7}{1}", prod.ProductName, prod.Price);
        }

        static void Listing_11_41()
        {
            Product[] prods = Service.GetProducts();
            var result = (from prod in prods
                          where prod.Price < 10
                          select new { prod.ProductName, prod.Price })
                          .First();
            Console.WriteLine("{0}", result.ProductName);
        }

        static void Listing_11_42()
        {
            Product[] prods = Service.GetProducts();
            var result = (from prod in prods
                          select new { prod.ProductName, prod.Price })
                          .First(item => item.Price < 10);
            Console.WriteLine("{0}", result.ProductName); 
        }

        static void Listing_11_43()
        {
            Product[] prods = Service.GetProducts();
            var result = (from prod in prods
                          select new { prod.ProductName, prod.Price })
                          .FirstOrDefault(item => item.Price < 1);
            if (result == null)
                Console.WriteLine("Kein Element entspricht der Bedingung.");
            else
                Console.WriteLine("{0}", result.ProductName);
        }

        static void Listing_11_44()
        {
            Product[] prods = Service.GetProducts();
            var result = (from prod in prods
                          select new { prod.ProductName, prod.Price })
                          .LastOrDefault(item => item.Price < 5);
            if (result == null)
                Console.WriteLine("Kein Element entspricht der Bedingung.");
            else
                Console.WriteLine("{0}", result.ProductName);
        }

        static void Listing_11_45()
        {
            Product[] prods = Service.GetProducts();
            var result = (from prod in prods
                          select new { prod.ProductID, prod.ProductName })
                         .Single(p => p.ProductID == 2);
            if (result == null)
                Console.WriteLine("Kein Element entspricht der Bedingung.");
            else
                Console.WriteLine("{0}", result.ProductName);
        }

        static void Listing_11_46()
        {
            Product[] prods = Service.GetProducts();
            var result = (from prod in prods
                          select new { prod.ProductID, prod.ProductName }).ElementAtOrDefault(3);
            if (result == null)
                Console.WriteLine("Kein Element entspricht der Bedingung.");
            else
                Console.WriteLine("{0}", result.ProductName);
        }

        static void Listing_11_47()
        {
            List<string> liste = new List<string>();
            liste.Add("Peter");
            liste.Add("Uwe");
            foreach (string tempStr in liste.DefaultIfEmpty("leer"))
            {
                Console.WriteLine(tempStr);
            }
        }
    }
}



