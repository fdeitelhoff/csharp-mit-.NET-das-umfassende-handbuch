using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackTrace_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DoSomething1();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            Console.ReadLine();
        }

        static void DoSomething1()
        {
            DoSomething2();
        }

        static void DoSomething2()
        {
            // hier wird die Exception ausgelöst
            throw new ArgumentNullException();
        }

    }
}
