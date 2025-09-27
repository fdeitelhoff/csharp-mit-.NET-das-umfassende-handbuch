using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronerAufruf_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Mathematics math = new Mathematics();
            int value = 23;
            AsyncCallback callback = new AsyncCallback(CallbackMethod);
            math.BeginCalculate(value, callback, math);
            for (int i = 0; i <= 100; i++)
            {
                Console.Write(".{0}.", i);
                Thread.Sleep(5);
            }
            Console.ReadLine();
        }

        public static void CallbackMethod(IAsyncResult ar)
        {
            Mathematics math = (Mathematics)ar.AsyncState;
            int result = math.EndCalculate(ar);
            Console.Write("---Resultat = {0} ", result);
            Console.Write("---FERTIG---");
        }

    }

    class Mathematics
    {
        private delegate int CalculateHandler(int x);
        CalculateHandler del;

        // Methode Calculate wird synchron ausgeführt
        public int Calculate(int x)
        {
            Console.Write("---Bearbeitung startet---");
            for (int i = 0; i <= 20; i++)
            {
                Console.Write("X");
                Thread.Sleep(10);
            }
            Console.Write("---Bearbeitung beendet---");
            return x * x;
        }

        // Start der asynchronen Ausführung
        public IAsyncResult BeginCalculate(int x, AsyncCallback callback, object state)
        {
            del = new CalculateHandler(Calculate);
            return del.BeginInvoke(x, callback, state);
        }

        // Beenden der asynchronen Ausführung
        public int EndCalculate(IAsyncResult ar)
        {
            return del.EndInvoke(ar);
        }
    }

}
