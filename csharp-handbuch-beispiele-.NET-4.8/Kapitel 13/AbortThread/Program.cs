using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AbortThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(DoSomething);
            Console.WriteLine("Thread wird jetzt gestartet");

            // Sekundärthread starten
            thread.Start();
            Console.WriteLine("Thread ist gestartet");
            Thread.Sleep(200);

            // der Sekundärthread wird nun beendet 
            thread.Abort();
            Thread.Sleep(100);

            if (thread.IsAlive)
                Console.WriteLine("Der Sek.-Thread lebt noch");
            else
                Console.WriteLine("Der Sek.-Thread ist aufgegeben");

            Console.ReadLine();
        }

        public static void DoSomething()
        {
            try
            {
                Console.WriteLine("Sek.-Thread gestartet.");
                for (int i = 0; i <= 100; i++)
                {
                    Console.WriteLine("Sek.-Thread-Zähler = {0}", i);
                    Thread.Sleep(50);
                }
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine("Sek.-Thread/im Catch-Block");
            }
            Console.WriteLine("Sek.-Thread/nach Finally");
            for (int i = 0; i <= 20; i++)
            {
                Console.Write(".");
                Thread.Sleep(50);
            }
        }
    }

}
