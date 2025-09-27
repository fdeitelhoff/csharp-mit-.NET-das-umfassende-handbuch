using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaitAll_Sample
{
    public class Program
    {
        static WaitHandle[] waitHandles;
        static Random random = new Random();

        static void Main()
        {
            waitHandles = new WaitHandle[] { new AutoResetEvent(false), new AutoResetEvent(false) };
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoSomething), waitHandles[0]);
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoSomething), waitHandles[1]);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            WaitHandle.WaitAll(waitHandles);
            watch.Stop();
            Console.WriteLine("Beide Operationen sind beendet. Dauer: {0} ms", watch.ElapsedMilliseconds);
            Console.ReadLine();
        }

        static void DoSomething(Object state)
        {
            AutoResetEvent arevent = state as AutoResetEvent;
            int time = 1000 * random.Next(1, 10);
            Console.WriteLine($"Zeitspanne der Operation: {time} ms");
            Thread.Sleep(time);
            arevent.Set();
        }
    }

}
