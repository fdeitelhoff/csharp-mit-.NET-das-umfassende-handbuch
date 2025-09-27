using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Join_Sample
{
    class Program
    {
        static int sum = 0;

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Sample1);
            Thread thread2 = new Thread(Sample2);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine($"Ergebnis: {sum}");
            Console.ReadLine();
        }

        private static void Sample1()
        {
            Thread.Sleep(1000);
            sum = sum + 15;
        }

        private static void Sample2()
        {
            Thread.Sleep(2000);
            sum = sum + 100;
        }
    }
}
