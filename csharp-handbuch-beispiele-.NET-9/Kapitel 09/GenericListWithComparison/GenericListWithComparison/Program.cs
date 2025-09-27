using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListWithComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> arrList = new List<Person>();
            // ArrayList füllen
            Person pers1 = new Person { Name = "Meier", City = "Berlin" };
            arrList.Add(pers1);
            Person pers2 = new Person { Name = "Arnhold", City = "Köln" };
            arrList.Add(pers2);
            Person pers3 = new Person { Name = "Graubär", City = "Aachen" };
            arrList.Add(pers3);

            // nach City sortieren
            arrList.Sort(CompareByCity);
            Console.WriteLine("Liste nach Wohnorten sortiert");
            ShowSortedList(arrList);
            // nach Namen sortieren
            arrList.Sort(CompareByName);
            Console.WriteLine("Liste nach Namen sortiert");
            ShowSortedList(arrList);
            Console.ReadLine();
        }

        public static int CompareByName(Person x, Person y)
        {
            // prüfen auf null-Übergabe
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            // Vergleich
            return x.Name.CompareTo(y.Name);
        }


        public static int CompareByCity(Person x, Person y)
        {
            // prüfen auf null-Übergabe
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            // Vergleich
            return x.City.CompareTo(y.City);
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

    class Person
    {
        public string Name { get; set; }
        public string City { get; set; }
    }

}
