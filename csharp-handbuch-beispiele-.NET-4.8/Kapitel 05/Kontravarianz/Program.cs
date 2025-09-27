using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontravarianz
{
    class GeometricObject { }
    class Circle : GeometricObject { }
    delegate void ContravarianceHandler(Circle circle);

    class Program
    {
        static void Main(string[] args)
        {
            ContravarianceHandler handler = DoSomething;
            handler(new Circle());
            Console.ReadLine();
        }

        public static void DoSomething(GeometricObject geoObject)
        { }
    }

}
