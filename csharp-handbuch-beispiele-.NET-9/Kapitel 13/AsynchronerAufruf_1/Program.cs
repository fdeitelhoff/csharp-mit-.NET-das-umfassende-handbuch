using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronerAufruf_1
{
    public delegate void MyDelegate();

    class Program
    {
        private static MyDelegate del;
        static void Main(string[] args)
        {
            Demo obj = new Demo();
            del = new MyDelegate(obj.DoSomething);
            var callback = new AsyncCallback(CallbackMethod);
            // DoSomething asynchron aufrufen
            del.BeginInvoke(callback, null);
            for (int i = 0; i < 100; i++)
            {
                Console.Write(".");
                Thread.Sleep(10);
            }
            Console.ReadLine();
        }
        // Callback-Methode
        public static void CallbackMethod(IAsyncResult ar)
        {
            Console.Write("Ich habe fertig.");
        }
    }
    class Demo
    {
        public void DoSomething()
        {
            for (int i = 0; i <= 30; i++)
            {
                Console.Write("X");
                Thread.Sleep(10);
            }
        }
    }

}
