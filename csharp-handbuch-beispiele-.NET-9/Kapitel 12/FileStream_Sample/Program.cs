using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStream_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] arr = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            string path = @"D:\Testfile.txt";
            // Stream öffnen
            FileStream fs = new FileStream(path, FileMode.Create);
            // in den Stream schreiben
            fs.Write(arr, 0, arr.Length);
            byte[] arrRead = new byte[10];
            // Positionszeiger auf den Anfang des Streams setzen
            fs.Seek(0, SeekOrigin.Begin);
            // Stream lesen
            fs.Read(arrRead, 0, 10);
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arrRead[i]);
            Console.ReadLine();
            // FileStream schließen
            fs.Close();
        }
    }
}
