using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatch_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader stream = null;
            Console.Write("Welche Datei soll geöffnet werden? ... ");
            string path = Console.ReadLine();
            try
            {
                stream = new StreamReader(path);
                Console.WriteLine("--- Dateianfang ---");
                Console.WriteLine(stream.ReadToEnd());
                Console.WriteLine("--- Dateiende -----");
                stream.Close();
            }
            // Datei nicht gefunden
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Verzeichnis existiert nicht
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Pfadangabe war 'null'
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Pfadangabe war leer ("")
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // allgemeine Exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Nach der Exception-Behandlung");
            Console.ReadLine();
        }
    }

}
