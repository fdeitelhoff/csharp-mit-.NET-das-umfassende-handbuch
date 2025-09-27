using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Leistungstest
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            string text = "";
            watch.Start();
            for (int i = 0; i < 50000; i++)
                text += "x";
            watch.Stop();
            Console.WriteLine($"Zeit: {watch.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
    }
}
