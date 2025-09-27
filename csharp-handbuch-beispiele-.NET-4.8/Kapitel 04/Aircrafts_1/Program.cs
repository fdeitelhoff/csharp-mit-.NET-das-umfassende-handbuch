using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aircrafts_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Flugzeug flg = new Flugzeug();
            flg.Starten();
            Hubschrauber hubi = new Hubschrauber();
            hubi.Starten();
            Console.ReadLine();
        }
    }

    public class Luftfahrzeug
    {
        public string Hersteller { get; set; }
        public int Baujahr { get; set; }

        public void Starten()
        {
            Console.WriteLine("Das Luftfahrzeug startet.");
        }
    }

    public class Flugzeug : Luftfahrzeug
    {
        public double Spannweite { get; set; }

        public new void Starten()
        {
            Console.WriteLine("Das Flugzeug startet.");
        }
    }

    public class Hubschrauber : Luftfahrzeug
    { 
        public double Rotor { get; set; }
    
        public new void Starten()
        {
            Console.WriteLine("Der Hubschrauber startet.");
        }
    }
}
