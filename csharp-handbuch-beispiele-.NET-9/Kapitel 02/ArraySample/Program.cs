using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySample
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] lngVar = new long[4];
            string[] strArr = new String[2];
            // Wertzuweisungem
            lngVar[0] = 230;
            lngVar[1] = 4711;
            lngVar[3] = 77;
            strArr[0] = "C# ";
            strArr[1] = "macht Spaß!";
            // Konsolenausgaben
            Console.WriteLine("lngVar[0] = {0}", lngVar[0]);
            Console.WriteLine("lngVar[1] = {0}", lngVar[1]);
            Console.WriteLine("lngVar[2] = {0}", lngVar[2]);
            Console.WriteLine("lngVar[3] = {0}", lngVar[3]);
            Console.Write(strArr[0]);
            Console.WriteLine(strArr[1]);
            Console.ReadLine();
        }
    }
}
