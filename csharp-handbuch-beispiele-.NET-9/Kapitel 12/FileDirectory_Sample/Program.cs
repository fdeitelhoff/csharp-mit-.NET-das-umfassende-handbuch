using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDirectory_Sample
{
    class Program
    {
        public static void Main()
        {
            Program dirTest = new Program();
            FileInfo myFile;
            // Benutzereingabe anfordern
            string path = dirTest.PathInput();
            int len = path.Length;
            // alle Ordner und Dateien holen
            string[] str = Directory.GetFileSystemEntries(path);
            Console.WriteLine();
            Console.WriteLine("Ordner und Dateien im Verzeichnis {0}", path);
            Console.WriteLine(new string('-', 80));
            for (int i = 0; i <= str.GetUpperBound(0); i++)
            {
                // prüfen, ob der Eintrag ein Verzeichnis oder eine Datei ist
                if (0 == (File.GetAttributes(str[i]) & FileAttributes.Directory))
                {
                    // str(i) ist kein Verzeichnis
                    myFile = new FileInfo(str[i]);
                    string fileAttr = dirTest.GetFileAttributes(myFile);
                    Console.WriteLine("{0,-30}{1,25} kB {2,-10} ", str[i].Substring(len - 1), myFile.Length / 1024, fileAttr);
                }
                else
                    Console.WriteLine("{0,-30}{1,-15}", str[i].Substring(len), "Dateiordner");
            }
            Console.ReadLine();
        }

        // Benutzer zur Pfadeingabe auffordern
        string PathInput()
        {
            Console.Write("Geben Sie den zu durchsuchenden Ordner an: ");
            string searchPath = Console.ReadLine();
            // Benutzereingabe muss mit "\\" enden, sonst anhängen
            if (searchPath.Substring(searchPath.Length - 1) != "\\")
                searchPath += "\\";
            return searchPath;
        }

        // Prüfen der gesetzten Dateiattribute
        // Rückgabe enthält die Dateiattribute
        string GetFileAttributes(FileInfo strFile)
        {
            string strAttr;
            // Prüfen, ob Archive-Attribut gesetzt ist
            if (0 != (strFile.Attributes & FileAttributes.Archive))
                strAttr = "A ";
            else
                strAttr = "  ";
            // Prüfen, ob Hidden-Attribut gesetzt ist
            if (0 != (strFile.Attributes & FileAttributes.Hidden))
                strAttr += "H ";
            else
                strAttr += "  ";
            // Prüfen, ob ReadOnly-Attribut gesetzt ist
            if (0 != (strFile.Attributes & FileAttributes.ReadOnly))
                strAttr += "R ";
            else
                strAttr += "  ";
            // Prüfen, ob System-Attribut gesetzt ist
            if (0 != (strFile.Attributes & FileAttributes.System))
                strAttr += "S ";
            else
                strAttr += "  ";
            return strAttr;
        }
    }

}
