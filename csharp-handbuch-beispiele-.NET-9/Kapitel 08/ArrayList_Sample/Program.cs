using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList_Sample
{

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList liste = new ArrayList {"Peter", "Andreas", "Conie", "Michael",
                                     "Gerd", "Freddy"};
            PrintListe(liste);
            liste.Remove("Andreas");
            Console.WriteLine("--- Element gelöscht ---");
            PrintListe(liste);
            Console.ReadLine();
        }

        // Ausgabe der Liste
        static void PrintListe(IList liste)
        {
            foreach (string item in liste)
                Console.WriteLine("Index: {0,-3}{1}", liste.IndexOf(item), item);
        }
    }

}
