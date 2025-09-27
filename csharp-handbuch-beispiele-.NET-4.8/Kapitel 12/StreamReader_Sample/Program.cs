using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamReader_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Datei erzeugen und mit Text füllen
            StreamWriter sw = new StreamWriter(@"D:\MyTest.kkl");
            sw.WriteLine("Visual C#");
            sw.WriteLine("macht viel Spass.");
            sw.Write("Richtig??");
            sw.Close();
            // die Datei an der Konsole einlesen
            StreamReader sr = new StreamReader(@"D:\MyTest.kkl");
            while (sr.Peek() != -1)
                Console.WriteLine(sr.ReadLine());
            sr.Close();
            Console.ReadLine();
        }
    }

}
