using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectsSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle kreis1 = new Circle(2);
            Circle kreis2 = new Circle(1);
            kreis1 = null;
            if (kreis1 == kreis2)
                Console.WriteLine("k1 == k2");
            else
                Console.WriteLine("k1 != k2");
            Console.ReadLine();

        }
    }
}
