using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemonstration
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo demo = new Demo();
            demo.OutOfCoffee += new EventHandler(demo_OutOfCoffee);
            demo.DoSomething();
            Console.ReadLine();
        }

        // Ereignishandler
        static void demo_OutOfCoffee(object sender, EventArgs e)
        {
            Console.WriteLine("Wo bleibt der Kaffee?");
        }
    }

    class Demo
    {
        // gekapselter Delegat
        private EventHandler _OutOfCoffee;

        // Definition des Events
        public event EventHandler OutOfCoffee
        {
            add { _OutOfCoffee += value; }
            remove { _OutOfCoffee -= value; }
        }

        // Ereignisauslösende Methode
        public void DoSomething()
        {
            _OutOfCoffee?.Invoke(this, new EventArgs());
        }
    }
}
