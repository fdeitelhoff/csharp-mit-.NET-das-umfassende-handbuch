using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hash = GetFilledHashtable();

            // Liste der Schlüssel ausgeben  
            Console.WriteLine("===== Schlüsselliste =====");
            GetKeyList(hash);

            // Liste der Werte ausgeben  
            Console.WriteLine();
            Console.WriteLine("===== Werteliste =====");
            GetValueList(hash);

            // Liste der Schlüssel und Werte ausgeben
            Console.WriteLine();
            Console.WriteLine("===== Schlüssel-/Wertepaare =====");
            GetCompleteList(hash);

            // Suche nach einem bestimmten Schlüssel  
            SearchForKey(hash);

            // Suche nach einem bestimmten Wert
            SearchForValue(hash, new Artikel(45, "Käse", 2.98));
            Console.ReadLine();
        }

        // Prüfen, ob ein bestimmter Wert enthalten ist
        public static void SearchForValue(Hashtable hash, Artikel artikel)
        {
            if (hash.ContainsValue(artikel))
                Console.WriteLine("Das Objekt '{0}' ist enthalten.", artikel.Artikelnummer);
            else
                Console.WriteLine("Das Objekt '{0}' ist nicht enthalten.", artikel.Artikelnummer);
        }

        // Prüfen, ob ein bestimmter Schlüssel enthalten ist
        public static void SearchForKey(Hashtable hash)
        {
            string text = "\n\nGeben Sie das auszuwertende Element an: ";
            string input;
            do
            {
                Console.Write(text);
                input = Console.ReadLine();
                if (hash.Contains(input))
                    Console.WriteLine("ArtikelNr.: {0,-4} Preis: {1}", ((Artikel)hash[input]).Artikelnummer, ((Artikel)hash[input]).Preis);
                else
                    Console.WriteLine("Nicht Element der Hashtable");
                Console.WriteLine("Zum Beenden F12 drücken ...");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.F12);
        }

        // Schlüssel-Wert-Paar über ein DictionaryEntry-Objekt ausgeben
        public static void GetCompleteList(Hashtable hash)
        {
            foreach (DictionaryEntry item in hash)
            {
                Console.Write(item.Key);
                Console.WriteLine(" - {0}", item.Value);
            }
        }

        // Ausgabe der Wertliste
        public static void GetValueList(Hashtable hash)
        {
            foreach (Artikel item in hash.Values)
                Console.WriteLine($"{item.Artikelnummer,-4}{item.Bezeichner,-12}{item.Preis}");
        }

        // Ausgabe der Schlüsselliste
        public static void GetKeyList(Hashtable hash)
        {
            foreach (string item in hash.Keys)
                Console.WriteLine(item);
        }

        // Objekte der Hashtable hinzufügen
        public static Hashtable GetFilledHashtable()
        {
            Hashtable hash = new Hashtable();
            Artikel artikel1 = new Artikel(101, "Wurst", 1.98);
            Artikel artikel2 = new Artikel(45, "Käse", 2.98);
            Artikel artikel3 = new Artikel(126, "Kuchen", 3.50);
            Artikel artikel4 = new Artikel(6, "Fleisch", 7.48);
            Artikel artikel5 = new Artikel(22, "Milch", 0.98);
            Artikel artikel6 = new Artikel(87, "Schololade", 1.29);
            hash.Add(artikel1.Bezeichner, artikel1);
            hash.Add(artikel2.Bezeichner, artikel2);
            hash.Add(artikel3.Bezeichner, artikel3);
            hash.Add(artikel4.Bezeichner, artikel4);
            hash.Add(artikel5.Bezeichner, artikel5);
            hash.Add(artikel6.Bezeichner, artikel6);
            return hash;
        }
    }

    class Artikel
    {
        public int Artikelnummer { get; set; }
        public string Bezeichner { get; set; }
        public double Preis { get; set; }

        public Artikel(int artNummer, string bezeichner, double preis)
        {
            Artikelnummer = artNummer;
            Bezeichner = bezeichner;
            Preis = preis;
        }
    }
}
