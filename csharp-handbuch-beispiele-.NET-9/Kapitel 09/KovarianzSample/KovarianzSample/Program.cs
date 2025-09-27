using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovarianzSample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Circle> listCircles = new List<Circle>();
            listCircles.Add(new Circle { Radius = 77 });
            listCircles.Add(new Circle { Radius = 23 });
            List<Rectangle> listRectangles = new List<Rectangle>();
            listRectangles.Add(new Rectangle { Length = 120, Width = 10 });
            listRectangles.Add(new Rectangle { Length = 80, Width = 20 });
            DoSomething(listCircles);
            DoSomething(listRectangles);
            Console.ReadLine();
        }

        static void DoSomething(IEnumerable<GeometricObject> param)
        {
            foreach (GeometricObject item in param)
                Console.WriteLine(item.GetArea());
        }
    }


    abstract class GeometricObject
    {
        public abstract double GetArea();
    }

    class Circle : GeometricObject
    {
        public int Radius { get; set; }

        public override double GetArea()
        {
            return Radius;
        }
    }

    class Rectangle : GeometricObject
    {
        public int Length { get; set; }
        public int Width { get; set; }

        public override double GetArea()
        {
            return Length * Width;
        }
    }

}
