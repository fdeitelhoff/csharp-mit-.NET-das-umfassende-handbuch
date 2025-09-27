using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NamedMutex_Sample
{
    class Program
    {
        public static void Main()
        {
            Mutex mutex = new Mutex(false, "MyMutex");
            Console.WriteLine("Auf den Mutex warten ...");
            mutex.WaitOne();
            Console.Write("Gesperrter Bereich. ");
            Console.Write("ENTER drücken, um Mutex feizugeben");
            Console.ReadLine();
            mutex.ReleaseMutex();
            Console.WriteLine("Freigegeben ...");
            Console.ReadLine();
        }
    }

}
