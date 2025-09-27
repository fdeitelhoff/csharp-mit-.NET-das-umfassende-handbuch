using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPool_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(DoSomething, 235);
            for (int i = 0; i < 100; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
            Console.WriteLine("Ende Main ...");
            Console.ReadLine();
        }

        public static void DoSomething(object state)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("x");
                Thread.Sleep(50);
            }
            Console.WriteLine($"Übergabe: {state}");
        }
    }

}
