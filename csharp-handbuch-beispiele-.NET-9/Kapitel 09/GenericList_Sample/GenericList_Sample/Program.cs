using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> liste = new List<Person>();

            // generische Liste füllen
            liste.Add(new Person { Name = "Meier", City = "Berlin" });
            liste.Add(new Person { Name = "Arnold", City = "Köln" });
            liste.Add(new Person { Name = "Fischer", City = "Aachen" });

            // nach Wohnort sortieren
            liste.Sort(new CityComparer());
            Console.WriteLine("Liste nach Wohnorten sortiert");
            ShowSortedList(liste);

            // nach Namen sortieren
            liste.Sort(new NameComparer());
            Console.WriteLine("\nListe nach Namen sortiert");
            ShowSortedList(liste);
            Console.ReadLine();
        }
        static void ShowSortedList(IList<Person> liste)
        {
            foreach (Person temp in liste)
            {
                Console.Write($"Name = {temp.Name,-12}");
                Console.WriteLine($"Wohnort = {temp.City}");
            }
            Console.WriteLine();
        }
    }


    // Vergleichsklasse – Kriterium Name
    class NameComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Name.CompareTo(y.Name);
        }
    }


    // Vergleichsklasse – Kriterium City
    class CityComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.City.CompareTo(y.City);
        }
    }


    class Person
    {
        public string Name { get; set; }
        public string City { get; set; }
    }
}
