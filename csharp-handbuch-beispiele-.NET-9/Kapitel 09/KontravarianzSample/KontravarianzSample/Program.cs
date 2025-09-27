using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontravarianzSample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Circle> liste = new List<Circle>();
            liste.Add(new Circle { Radius = 88 });
            liste.Add(new Circle { Radius = 22 });
            liste.Add(new Circle { Radius = 42 });
            liste.Add(new Circle { Radius = 76 });
            liste.Sort(new GeoComparer());

            // Ausgabe der sortierten Liste
            foreach (GeometricObject item in liste)
                Console.WriteLine(item.GetArea());

            Console.ReadLine();
        }
    }

    // Vergleichsklasse
    class GeoComparer : IComparer<GeometricObject>
    {
        public int Compare(GeometricObject x, GeometricObject y)
        {
            return x.GetArea().CompareTo(y.GetArea());
        }
    }

    // GeometricObject
    abstract class GeometricObject
    {
        public abstract double GetArea();
    }

    // Circle
    class Circle : GeometricObject
    {
        public int Radius { get; set; }

        public override double GetArea()
        {
            return Radius;
        }
    }

    // Rectangle
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
