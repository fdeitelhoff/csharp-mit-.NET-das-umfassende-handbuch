using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryReader_Sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            // eine Datei erzeugen und einen Integer-Wert in die Datei schreiben
            FileStream fileStr = new FileStream(@"D:\Binfile.mic", FileMode.Create);
            BinaryWriter binWriter = new BinaryWriter(fileStr);
            int intArr = 500;
            binWriter.Write(intArr);
            binWriter.Close();
            // Datei öffnen und den Inhalt byteweise auslesen
            FileInfo fi = new FileInfo(@"D:\Binfile.mic");
            FileStream fs = new FileStream(@"D:\Binfile.mic", FileMode.Open);
            byte[] byteArr = new byte[fi.Length];

            // Datenstrom in ein Byte-Array einlesen
            fs.Read(byteArr, 0, (int)fi.Length);
            // Konsolenausgabe
            Console.Write("Interpretation als Byte-Array: ");
            for (int i = 0; i < fi.Length; i++)
                Console.Write(byteArr[i] + " ");
            Console.Write("\n\n");
            fs.Close();
            // Dateiinhalt textuell auswerten
            StreamReader strReader = new StreamReader(@"D:\Binfile.mic");
            Console.Write("Interpretation als Text: ");
            Console.WriteLine(strReader.ReadToEnd());
            strReader.Close();
            Console.ReadLine();
        }
    }

}
