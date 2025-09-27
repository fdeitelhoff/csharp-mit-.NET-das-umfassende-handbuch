using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Semaphore_Sample
{
    public class Program
    {
        private static Semaphore semPool;
        public static void Main()
        {
            semPool = new Semaphore(3, 3);
            for (int i = 1; i <= 5; i++)
            {
                Thread thread = new Thread(DoSomething);
                thread.Start();
            }
            Thread.Sleep(5000);
            Console.WriteLine("Main - Aufruf von Release(3).");
            Console.WriteLine("Main beendet.");
            Console.ReadLine();
        }
        private static void DoSomething()
        {
            Console.WriteLine("Thread #{0} wartet auf Semaphor ...", Thread.CurrentThread.ManagedThreadId);
            semPool.WaitOne();
            Console.WriteLine("Thread #{0} in der Semaphor", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("Thread #{0} gibt Semaphor frei", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Anzahl bedienbarer Anforderungen = {0}", semPool.Release() + 1);
        }
    }

}
