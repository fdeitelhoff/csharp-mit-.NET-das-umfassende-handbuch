using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleThread
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart del = new ThreadStart(DoSomething);
            Thread thread = new Thread(del);
            // den zweiten Thread starten
            thread.Start();
            for (int i = 0; i <= 100; i++)
            {
                for (int k = 1; k <= 20; k++)
                    Console.Write(".");
                Console.WriteLine($"Primär-Thread {i}");
            }
            Console.ReadLine();
        }

        // diese Methode wird in einem eigenen Thread ausgeführt
        public static void DoSomething()
        {
            for (int i = 0; i <= 100; i++)
            {
                for (int k = 1; k <= 20; k++)
                    Console.Write("X");
                Console.WriteLine($"Sekundär-Thread {i}");
            }
        }
    }

}
