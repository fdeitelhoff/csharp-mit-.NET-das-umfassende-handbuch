using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Months months = new Months();
            foreach (string temp in months)
                Console.WriteLine(temp);
            Console.ReadLine();
        }
    }

    public class Months : IEnumerable
    {
        string[] months =
        {
            "Januar", "Februar", "März", "April", "Mai", "Juni", "Juli", "August",
            "September", "Oktober", "November", "Dezember"
        };

        // Methode der Schnittstelle IEnumerable
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < months.Length; i++)
                yield return months[i];
        }
    }

}
