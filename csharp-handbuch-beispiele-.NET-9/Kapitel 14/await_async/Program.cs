using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace await_async
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
            Console.WriteLine("Ende Main ...");
            Console.ReadLine();
        }

        static async void Start()
        {
            await DoSomethingAsync(1);
            Console.WriteLine("nach Aufruf von DoSomethingAsync(1) ...");
        }

        static Task DoSomethingAsync(int id)
        {
            Task task = Task.Run(() =>
            {
                Console.WriteLine($"Operation {id} startet ...");
                Thread.Sleep(2500);
                Console.WriteLine($"Operation {id} ist beendet.");
            });
            return task;
        }
    }
}
