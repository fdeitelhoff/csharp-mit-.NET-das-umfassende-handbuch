using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListAdapter_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] pers = new Person[3];
            pers[0] = new Person { Name = "Peter", City = "Celle" };
            pers[1] = new Person { Name = "Alfred", City = "München" };
            pers[2] = new Person { Name = "Hugo", City = "Aachen" };
            ArrayList liste = ArrayList.Adapter(pers);

            // Sortierung nach Namen
            liste.Sort(new NameComparer());
            Console.WriteLine("Sortiert nach den Namen:");
            for (int index = 0; index < 3; index++)
                if (liste[index] != null)
                    Console.WriteLine((liste[index] as Person).Name);

            // Sortierung nach der City
            Console.WriteLine("\nSortiert nach dem Wohnort:");
            liste.Sort(new CityComparer());
            for (int index = 0; index < 3; index++)
                if (liste[index] != null)
                    Console.WriteLine((liste[index] as Person).City);
            Console.ReadLine();
        }
    }

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
