using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_For_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = { 10000, 100000, 500000, 1000000, 10000000 };
            for (int index = 0; index < 5; index++)
            {
                Console.WriteLine("Schleifen: {0}\n{1}", values[index], new string('-', 30));
                Stopwatch watch = new Stopwatch();
                watch.Start();
                ParallelTest(values[index]);
                watch.Stop();
                Console.WriteLine($"Parallel: {watch.ElapsedMilliseconds} ms");
                watch.Reset();
                watch.Start();
                SynchronTest(values[index]);
                watch.Stop();
                Console.WriteLine($"Synchron: {watch.ElapsedMilliseconds}ms\n");
            }
            Console.ReadLine();
        }

        static void SynchronTest(int loops)
        {
            double[] arr = new double[loops];
            for (int i = 0; i < loops; i++)
                arr[i] = Math.Pow(i, 0.333) * Math.Sqrt(Math.Sin(i));
        }

        static void ParallelTest(int loops)
        {
            double[] arr = new double[loops];
            Parallel.For(0, loops, i =>
            {
                arr[i] = Math.Pow(i, 0.333) * Math.Sqrt(Math.Sin(i));
            });
        }
    }

}
