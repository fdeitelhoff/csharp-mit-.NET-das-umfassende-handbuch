using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticastDelegateSample2
{
    public delegate void MyDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate del = new MyDelegate(DoSomething);
            del += new MyDelegate(DoSomethingMore);
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
