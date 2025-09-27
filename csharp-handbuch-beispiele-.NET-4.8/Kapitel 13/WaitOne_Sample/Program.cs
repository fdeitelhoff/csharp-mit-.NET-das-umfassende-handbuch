using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaitOne_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Benachrichtigungsereignis – nicht signalisiert
            AutoResetEvent ready = new AutoResetEvent(false);
            // Anfordern eines Threads aus dem Pool
            ThreadPool.QueueUserWorkItem(Calculate, ready);
            Console.WriteLine("Der Hauptthread wartet ...");
            // Aktuellen Thread in den Wartezustand versetzen
            ready.WaitOne();
            Console.WriteLine("Arbeitsthread ist fertig.");
            Console.ReadLine();
        }

        public static void Calculate(object obj)
        {
            Console.WriteLine("Im Sekundärthread");
            Thread.Sleep(5000);
            // Ereigniszustand auf signalisieren setzen
            (obj as AutoResetEvent).Set();
        }
    }

}
