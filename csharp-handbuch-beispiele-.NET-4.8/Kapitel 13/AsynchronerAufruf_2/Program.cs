using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronerAufruf_2
{
    public delegate string MyDelegate(int x, ref long y);

    class Program
    {
        private static MyDelegate del;
        private static int intVar = 4711;
        private static long lngVar;

        static void Main(string[] args)
        {
            Demo obj = new Demo();
            del = new MyDelegate(obj.DoSomething);
            var callback = new AsyncCallback(CallbackMethod);
            // DoSomething asynchron aufrufen
            del.BeginInvoke(intVar, ref lngVar, callback, null);
            for (int i = 0; i <= 100; i++)
            {
                Console.Write(".");
                Thread.Sleep(10);
            }
            Console.ReadLine();
        }


        public static void CallbackMethod(IAsyncResult ar)
        {
            Console.Write(del.EndInvoke(ref lngVar, ar));
            Console.Write("..Wert y = {0}", lngVar);
        }
    }

    class Demo
    {
        public string DoSomething(int x, ref long y)
        {
            for (int i = 0; i <= 30; i++)
            {
                Console.Write("x");
                Thread.Sleep(10);
            }
            y = 12345;
            return "Ich habe fertig.";
        }
    }

}
