using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baumstruktur
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geben Sie die Anzahl der Stufen ein: ");
            int zeile = Convert.ToInt32(Console.ReadLine());
            // jede Stufe des Baums aufbauen         
            for (int i = 1; i <= zeile; i++)
            {
                // Leerzeichen schreiben
                for (int j = 0; j < zeile - i; j++)
                    Console.Write(" ");
                // Buchstaben schreiben
                for (int j = 0; j < i * 2 - 1; j++)
                    Console.Write("M");
                Console.WriteLine();
            }
            Console.ReadLine();
        }

    }
}


