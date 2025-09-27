using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhileSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geben Sie eine Zahl zwischen\n");
            Console.Write("0 und einschließlich 10 ein: ");
            int number = Convert.ToInt32(Console.ReadLine());
            int counter = 1;
            while (counter <= number)
            {
                Console.WriteLine($"{counter}.Schleifendurchlauf");
                counter++;
            }
            Console.ReadLine();
        }
    }

}
