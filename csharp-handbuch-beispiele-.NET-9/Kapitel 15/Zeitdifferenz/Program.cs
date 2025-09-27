using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeitdifferenz
{
    class Program
    {
        static void Main(string[] args)
        {
            // aktuelle Systemzeit ermitteln
            DateTime actDate = DateTime.Now;
            // das zu vergleichende Datum eingeben
            Console.Write("Geben Sie das Vergleichsdatum ");
            Console.Write("im Format tt.mm.jjjj ein:  ");
            string strDate = Convert.ToString(Console.ReadLine());
            // die Eingabe passend formatieren
            strDate = strDate.Replace('.', '/');
            DateTime newDate = Convert.ToDateTime(strDate);
            // Ausgabe der Differenz in Stunden
            Console.Write("Die Differenz in Stunden: ");
            Console.WriteLine(DiffHours(actDate, newDate));
            // Ausgabe der Differenz in Sekunden
            Console.Write("Die Differenz in Sekunden: ");
            Console.WriteLine(DiffSeconds(actDate, newDate));
            Console.ReadLine();
        }

        public static long DiffHours(DateTime d1, DateTime d2)
        {
            long x = d2.Ticks - d1.Ticks;
            return Convert.ToInt64(x / TimeSpan.TicksPerHour);
        }

        public static long DiffSeconds(DateTime d1, DateTime d2)
        {
            long x = d2.Ticks - d1.Ticks;
            return Convert.ToInt64(x / TimeSpan.TicksPerSecond);
        }
    }

}
