using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegate
{
    public delegate double CalculateHandler(double value1, double value2);

    class Program
    {
        static void Main(string[] args)
        {
            // Variable vom Typ des Delegaten
            CalculateHandler calculate;
            do
            {
                // Eingabe der Operation
                Console.Clear();
                Console.Write("Geben Sie den ersten Operanden ein: ");
                double input1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Geben Sie den zweiten Operanden ein: ");
                double input2 = Convert.ToDouble(Console.ReadLine());
                // Wahl der Operation
                Console.Write("Operation: Addition - (A) oder Subtraktion - (S)? ");
                string wahl = Console.ReadLine().ToUpper();
                // In Abhängigkeit von der Wahl des Anwenders wird die Variable 'calculate'
                // mit einem Zeiger auf die auszuführende Methode initialisiert
                if (wahl == "A")
                    calculate = new CalculateHandler(Mathematics.Add);
                else if (wahl == "S")
                    calculate = new CalculateHandler(Mathematics.Subtract);
                else
                {
                    Console.Write("Ungültige Eingabe");
                    Console.ReadLine();
                    return;
                }
                // Aufruf der Operation 'Add' oder 'Subtract' über den Delegaten
                double result = calculate(input1, input2);
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Ergebnis = {result}\n\n");
                Console.WriteLine("Zum Beenden F12 drücken.");
            } while (Console.ReadKey(true).Key != ConsoleKey.F12);
        }
    }

    class Mathematics
    {
        public static double Add(double x, double y)
        {
            return x + y;
        }
        public static double Subtract(double x, double y)
        {
            return x - y;
        }
    }

}
