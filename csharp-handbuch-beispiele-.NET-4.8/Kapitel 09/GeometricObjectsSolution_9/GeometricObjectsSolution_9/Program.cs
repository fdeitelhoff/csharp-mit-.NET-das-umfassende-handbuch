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
            List<GeometricObject> list = new List<GeometricObject>();
            list.Add(new Circle(28));
            list.Add(new Circle(45));
            list.Add(new Rectangle(120, 56));
            list.Add(new Rectangle(303, 17));
            list.Sort(new GeometricObjectComparer());

            foreach (var item in list)
                Console.WriteLine($"{item.GetArea()}");

            Console.ReadLine();
        }

    }

}
