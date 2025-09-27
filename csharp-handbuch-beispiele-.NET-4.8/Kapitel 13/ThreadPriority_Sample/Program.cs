using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPriority_Sample
{
    class Program
    {
        private static int[] count = new int[5];
        public static void Main()
        {
            Thread[] threads = new Thread[5];
            threads[0] = new Thread(new ThreadStart(DoSomething1));
            threads[1] = new Thread(new ThreadStart(DoSomething2));
            threads[2] = new Thread(new ThreadStart(DoSomething3));
            threads[3] = new Thread(new ThreadStart(DoSomething4));
            threads[4] = new Thread(new ThreadStart(DoSomething5));
            threads[0].Priority = ThreadPriority.Highest;
            threads[1].Priority = ThreadPriority.AboveNormal;
            threads[2].Priority = ThreadPriority.Normal;
            threads[3].Priority = ThreadPriority.BelowNormal;
            threads[4].Priority = ThreadPriority.Lowest;

            for (int i = 0; i < 5; i++)
                threads[i].Start();

            for (int k = 0; k < 5; k++)
            {
                Thread.Sleep(3000);
                lock (count)
                {
                    for (int i = 0; i < 5; i++)
                        Console.WriteLine("{0,-12}: {1,10}", threads[i].Priority, count[i]);
                    Console.WriteLine();
                }
            }
        }
        private static void DoSomething1()
        {
            while (true) Interlocked.Increment(ref count[0]);
        }

        private static void DoSomething2()
        {
            while (true) Interlocked.Increment(ref count[1]);
        }

        private static void DoSomething3()
        {
            while (true) Interlocked.Increment(ref count[2]);
        }

        private static void DoSomething4()
        {
            while (true) Interlocked.Increment(ref count[3]);
        }

        private static void DoSomething5()
        {
            while (true) Interlocked.Increment(ref count[4]);
        }
    }

}
