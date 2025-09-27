using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Informationsanzeige
            Console.Write("W - Programm fortsetzen\n");
            Console.Write("E - Programm beenden\n");
            Console.Write("-----------------------\n");
            // Schleife wird so oft durchlaufen, bis der Anwender eine gültige Eingabe macht
            do
            {
                Console.Write("Ihre Wahl: ");
                string eingabe = Console.ReadLine();
                if (eingabe == "W")
                    // das Programm nach dem Schleifenende fortsetzen
                    break;
                else if (eingabe == "E")
                    // das Programm beenden
                    return;
                else
                {
                    // Fehleingabe
                    Console.Write("Falsche Eingabe - ");
                    Console.Write("Neueingabe erforderlich\n");
                    Console.Write("-----------------------\n");
                }
            } while (true);
            Console.WriteLine("...es geht weiter.");
            Console.ReadLine();
        }
    }

}
