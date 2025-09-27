using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GeometricObjectsSolution
{
    public class Circle : GeometricObject, IDisposable
    {
        #region Objektzerstörung
        private bool disposed;

        public void Dispose()
        {
            if (!disposed)
            {
                CountCircles--;
                CountGeometricObjects--;
                GC.SuppressFinalize(this);
                disposed = true;
            }
        }
        ~Circle() => Dispose();

        #endregion

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
            get => _Radius;
            set
            {
                if (value >= 0)
                {
                    _Radius = value;
                    OnPropertyChanged("Radius");
                }
                else
                    OnInvalidMeasure(new InvalidMeasureEventArgs(value, "Radius"));
            }
        }
        #endregion

        #region Methoden
        public override double GetArea() => Math.Pow(Radius, 2) * Math.PI;        

        public override double GetPerimeter() => 2 * Radius * Math.PI;        

        public virtual void Move(double dx, double dy, int dRadius)
        {
            MovingEventArgs e = new MovingEventArgs();
            OnMoving(e);
            if (e.Cancel == true) return;

            XCoordinate += dx;
            YCoordinate += dy;
            Radius += dRadius;

            OnMoved(new EventArgs());
        }

        public override string ToString() => "Circle, R=" + Radius + ",Fläche=" + GetArea();        
        #endregion

        #region Klasseneigenschaften
        public static int CountCircles { get; private set; }
        #endregion

        #region Klassenmethoden
        public static double GetArea(int radius) => Math.Pow(radius, 2) * Math.PI;        

        public static double GetPerimeter(int radius) => 2 * radius * Math.PI;        
        #endregion
    }
}