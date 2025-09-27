using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnsynchronisierteThreads
{
    class Program
    {       
        static void Main(string[] args)
        {
            Demo demo = new Demo();
            Thread thread1 = new Thread(demo.DoSomething);
            Thread thread2 = new Thread(demo.DoSomething);
            thread1.Start();
            thread2.Start();
            Console.ReadLine();
        }
    }

    class Demo
    {
        private int value;

        public void DoSomething()
        {
            while (true)
            {
                Monitor.Enter(this);
                value++;
                if (value > 100) break;
                Console.WriteLine(value);
                Monitor.Exit(this);
            }
        }
    }
}
