using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kovarianz
{
    class GeometricObject { }
    class Circle : GeometricObject { }
        delegate GeometricObject CovarianceHandler();

    class Program
    {
        static void Main(string[] args)
        {
            CovarianceHandler handler = DoSomething;
            GeometricObject geo = handler();
            Console.WriteLine(geo.GetType());
            Console.ReadLine();
        }

        public static Circle DoSomething()
        {
            return new Circle();
        }
    }
}
