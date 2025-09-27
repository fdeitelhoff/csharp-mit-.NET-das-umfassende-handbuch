using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInitialisierung
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liste;
            // Eingabe der Arraygröße
            Console.Write("Geben Sie die Anzahl der Elemente ein: ");
            int number = Convert.ToInt32(Console.ReadLine());
            // Initialisierung des Arrays
            liste = new int[number];
            // jedes Element des Arrays in einer Schleife durchlaufen
            // und jedem Array-Element einen Wert zuweisen und danach
            // an der Konsole ausgeben
            for (int i = 0; i < number; i++)
            {
                liste[i] = i * i;
                Console.WriteLine("liste[{0}] = {1}", i, liste[i]);
            }
            Console.ReadLine();
        }
    }

}
