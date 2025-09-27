using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaitAll_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("Task #1: fertig ...");
            });
            Task task2 = Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("Task #2: fertig ...");
            });
            Task task3 = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Task #3: fertig ...");
            });
            Task.WaitAll(new Task[] { task1, task2, task3 });
            Console.WriteLine("Alle Tasks sind beendet");
            Console.ReadLine();
        }
    }

}
