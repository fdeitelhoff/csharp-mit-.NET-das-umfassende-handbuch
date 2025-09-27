using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckedSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Zahleneingabe anfordern
            Console.Write("Geben Sie eine Zahl im Bereich von ");
            Console.Write($"0...{Int16.MaxValue} ein: ");
            // Eingabe einem short-Typ zuweisen
            short value1 = Convert.ToInt16(Console.ReadLine());
            // Überlaufprüfung einschalten
            byte value2 = checked((byte)value1);
            Console.WriteLine(value2);
            Console.ReadLine();
        }
    }
}
