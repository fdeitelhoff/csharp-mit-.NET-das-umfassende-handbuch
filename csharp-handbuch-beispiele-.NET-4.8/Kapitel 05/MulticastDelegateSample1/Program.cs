using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticastDelegateSample1
{
    public delegate void MyDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate del = (MyDelegate)Delegate.Combine(new MyDelegate(DoSomething), new MyDelegate(DoSomethingMore));
            // Multicast-delegaten ausführen
            del();
            Console.ReadLine();
        }

        public static void DoSomething()
        {
            Console.WriteLine("In der Methode 'DoSomething'");
        }

        public static void DoSomethingMore()
        {
            Console.WriteLine("In der Methode 'DoSomethingMore'");
        }
    }
}
