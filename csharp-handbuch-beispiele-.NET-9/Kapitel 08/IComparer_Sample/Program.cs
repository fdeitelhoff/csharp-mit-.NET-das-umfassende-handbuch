using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparer_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrList = new ArrayList();
            // ArrayList füllen
            arrList.Add(new Person() { Name = "Meier", City = "Berlin" });
            arrList.Add(new Person() { Name = "Schulz", City = "Stuttgart" });
            arrList.Add(new Person() { Name = "Gerhards", City = "Hamburg" });
            arrList.Add(new Person() { Name = "Müller", City = "Bremen" });
            // nach Cities sortieren
            arrList.Sort(new CityComparer());
            Console.WriteLine("Liste nach Wohnorten sortiert");
            ShowSortedList(arrList);
            // nach Namen sortieren
            arrList.Sort(new NameComparer());
            Console.WriteLine("Liste nach Namen sortiert");
            ShowSortedList(arrList);
            Console.ReadLine();
        }

        static void ShowSortedList(IList liste)
        {
            foreach (Person temp in liste)
            {
                if (temp != null)
                {
                    Console.Write($"Name = {temp.Name,-12}");
                    Console.WriteLine($"Wohnort = {temp.City}", temp.City);
                }
            }
            Console.WriteLine();
        }
    }

    // Vergleichsklasse – Kriterium City
    class CityComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null) return 0;
            Person x1 = x as Person;
            Person y1 = y as Person;
            if (x1 == null && y1 != null) return -1;
            if (x1 != null && y1 == null) return 1;
            if (x1 == null || y1 == null)
                throw new InvalidCastException("Ungültiger Typ");
            return x1.City.CompareTo(y1.City);
        }
    }

    // Vergleichsklasse – Kriterium Name
    class NameComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null) return 0;
            Person x1 = x as Person;
            Person y1 = y as Person;
            if (x1 == null && y1 != null) return -1;
            if (x1 != null && y1 == null) return 1;
            if (x1 == null || y1 == null)
                throw new InvalidCastException("Ungültiger Typ");
            return x1.Name.CompareTo(y1.Name);
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string City { get; set; }
    }
}
