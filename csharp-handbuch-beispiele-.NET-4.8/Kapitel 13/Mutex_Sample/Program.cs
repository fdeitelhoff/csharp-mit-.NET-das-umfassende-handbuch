using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mutex_Sample
{
    class Program
    {
        private static Mutex mutex = new Mutex();
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(DoSomething);
                thread.Start();
            }
            Console.Read();
        }

        private static void DoSomething()
        {
            mutex.WaitOne();
            Console.WriteLine("Thread #{0} wird ausgeführt", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("Thread #{0} wird beendet", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine();
            mutex.ReleaseMutex();
        }
    }

}
