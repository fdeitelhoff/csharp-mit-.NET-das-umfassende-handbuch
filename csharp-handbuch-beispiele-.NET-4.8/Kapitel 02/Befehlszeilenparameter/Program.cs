using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Befehlszeilenparameter
{
    class Program
    {
        static void Main(string[] args)
        {
            // prüfen, ob beim Programmaufruf eine oder mehere Strings übergeben worden sind
            if (args.Length > 0)
            {
                // die Zeichenfolgen in der Konsole anzeigen
                for (int i = 0; i < args.Length; i++)
                    Console.WriteLine(args[i]);
            }
            else
                Console.WriteLine("Kein Übergabestring");
            Console.ReadLine();
        }
    }

}
