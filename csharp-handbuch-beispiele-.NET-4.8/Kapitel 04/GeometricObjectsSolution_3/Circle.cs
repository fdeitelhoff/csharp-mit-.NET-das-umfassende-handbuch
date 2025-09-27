using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GeometricObjectsSolution
{
    public class Circle : GeometricObject
    {
        #region Konstruktoren
        public Circle() : this(0, 0, 0) { }

        public Circle(int radius) : this(radius, 0, 0) { }

        public Circle(int radius, double x, double y)
        {
            Radius = radius;
            XCoordinate = x;
            YCoordinate = y;
            Circle.CountCircles++;
        }
        #endregion

        #region Eigenschaften
        private int _Radius;
        public int Radius
        {
            get { return _Radius; }
            set
            {
                if (value >= 0)
                    _Radius = value;
                else
                    Console.WriteLine("Unzulässiger negativer Radius.");
            }
        }
        #endregion

        #region Methoden
        public override double GetArea()
        {
            return Math.Pow(Radius, 2) * Math.PI;
        }

        public override double GetPerimeter()
        {
            return 2 * Radius * Math.PI;
        }

        public virtual void Move(double dx, double dy, int dRadius)
        {
            XCoordinate += dx;
            YCoordinate += dy;
            Radius += dRadius;
        }

        public override string ToString()
        {
            return "Circle, R=" + Radius + ",Fläche=" + GetArea();
        }

        #endregion

        #region Klasseneigenschaften
        public static int CountCircles { get; private set; }
        #endregion

        #region Klassenmethoden
        public static double GetArea(int radius)
        {
            return Math.Pow(radius, 2) * Math.PI;
        }

        public static double GetPerimeter(int radius)
        {
            return 2 * radius * Math.PI;
        }
        #endregion
    }
}