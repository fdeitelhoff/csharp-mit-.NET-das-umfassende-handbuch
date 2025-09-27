using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymeMethoden
{
    public delegate double CalculateHandler(double value1, double value2);

    class Program
    {
        static void Main(string[] args)
        {
            CalculateHandler calculate;
            do
            {
                // Eingabe der Operanden
                Console.Clear();
                Console.Write("Geben Sie den ersten Operanden ein: ");
                double input1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Geben Sie den zweiten Operanden ein: ");
                double input2 = Convert.ToDouble(Console.ReadLine());
                // Wahl der Operation
                Console.Write("Operation: Addition - (A) oder Subtraktion - (S)? ");
                string wahl = Console.ReadLine().ToUpper();
                if (wahl == "A")
                    calculate = delegate (double x, double y)
                    {
                        return x + y;
                    };
                else if (wahl == "S")
                    calculate = delegate (double x, double y)
                    {
                        return x - y;
                    };
                else
                {
                    Console.Write("Ungültige Eingabe");
                    Console.ReadLine();
                    return;
                }
                double result = calculate(input1, input2);
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Ergebnis = {result}\n\n");
                Console.WriteLine("Zum Beenden F12 drücken.");
            } while (Console.ReadKey(true).Key != ConsoleKey.F12);
        }
    }

}
