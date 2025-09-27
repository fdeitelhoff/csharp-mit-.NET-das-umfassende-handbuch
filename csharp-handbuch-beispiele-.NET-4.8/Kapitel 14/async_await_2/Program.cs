using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace async_await_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Starten();
            Console.WriteLine("Ende Main ...");
            Console.ReadLine();
        }

        static async void Starten()
        {
            long result = await CalculateAsync(12, 88);
            Console.WriteLine($"Das Ergebnis liegt vor: {result}");

            Task<long> task = CalculateAsync(111, 11);
            Console.WriteLine($"Das Ergebnis liegt vor: {task.Result}");
        }

        static Task<long> CalculateAsync(int x, int y)
        {
            Task<long> task = Task.Run<long>(() =>
            {
                Thread.Sleep(2500);
                return x + y;
            });
            return task;
        }
    }
}
