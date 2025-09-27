using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDefinedFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = { "Peter", "Uwe", "Willi", "Udo" };
            IEnumerable<string> query = arr.Where(name => name.Length < 4);
            foreach (string item in query)
                Console.WriteLine(item);
            Console.ReadLine();
        }
    }

    static class Extensionmethod
    {
        // Erweiterungsmethode
        public static IEnumerable<T> Where<T>(this IEnumerable<T> liste, Func<T, bool> filter)
        {
            List<T> result = new List<T>();
            foreach (T name in liste)
                if (filter(name))
                    result.Add(name);
            return result;
        }
    }

}
