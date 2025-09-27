using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatorüberladung_True_False
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo obj = new Demo { Value = 12 };
            obj.Value = 8;
            if (obj)
                Console.Write("Wert ungleich 0");
            else
                Console.Write("Wert gleich 0");
            Console.ReadLine();
        }
    }

    // Klasse Demo
    class Demo
    {
        public int Value { get; set; }

        // Überladung des true-Operators
        public static bool operator true(Demo obj) =>obj.Value != 0 ? true : false;        

        // Überladung des false-Operators
        public static bool operator false(Demo obj) => obj.Value != 0 ? false : true;        

        // Überladung des Negationsoperators
        public static bool operator !(Demo obj) => obj.Value != 0 ? false : true;
    }

}
