using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Treffen Sie eine Wahl:\n\n";
            message += "(N) - Neues Spiel\n";
            message += "(A) - Altes Spiel fortsetzen\n";
            message += "(E) - Beenden\n";
            Console.WriteLine(message);
            Console.Write("Ihre Wahl lautet: ");
            string choice = Console.ReadLine().ToUpper();

            switch (choice)
            {
                case "N":
                    Console.Write("Neues Spiel...");
                    // Anweisungen, die ein neues Spiel starten
                    break;
                case "A":
                    Console.Write("Altes Spiel laden...");
                    // Anweisungen, die einen alten Spielstand laden
                    break;
                case "E":
                    Console.Write("Spiel beenden...");
                    // Anweisungen, um das Spiel zu beenden
                    break;
                default:
                    Console.Write("Ungültige Eingabe...");
                    // weitere Anweisungen
                    break;
            }
            Console.ReadLine();
        }
    }
}
