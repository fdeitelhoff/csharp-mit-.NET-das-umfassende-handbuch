using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectsSolution
{
    public class Rectangle : GeometricObject, IDisposable
    {
        #region Objektzerstörung
        private bool disposed;

        public void Dispose()
        {
            if (!disposed)
            {
                CountRectangles--;
                CountGeometricObjects--;
                GC.SuppressFinalize(this);
                disposed = true;
            }
        }
        ~Rectangle()
        {
            Dispose();
        }
        #endregion

        #region Konstruktoren
        public Rectangle() : this(0, 0, 0, 0) { }

        public Rectangle(int length, int width) : this(length, width, 0, 0) { }

        public Rectangle(int length, int width, double x, double y)
        {
            Length = length;
            Width = width;
            XCoordinate = x;
            YCoordinate = y;
            Rectangle.CountRectangles++;
        }
        #endregion

        #region Instanzeigenschaften
        private int _Length;
        public int Length
        {
            get { return _Length; }
            set
            {
                if (value >= 0)
                    _Length = value;
                else
                    Console.WriteLine("Unzulässige negative Länge.");
            }
        }

        private int _Width;
        public int Width
        {
            get { return _Width; }
            set
            {
                if (value >= 0)
                    _Width = value;
                else
                    Console.WriteLine("Unzulässige negative Breite.");
            }
        }
        #endregion

        #region Instanzmethoden
        public override double GetArea()
        {
            return Length * Width;
        }

        public override double GetPerimeter()
        {
            return 2 * (Length + Width);
        }

        public virtual void Move(double dx, double dy, int dWidth, int dLength)
        {
            XCoordinate += dx;
            YCoordinate += dy;
            Width += dWidth;
            Length += dLength;
        }

        public override string ToString()
        {
            return "Rectangle, L=" + Length + ",B=" + Width + ",Fläche=" + GetArea();
        }
        #endregion

        #region Klasseneigenschaft
        public static int CountRectangles { get; private set; }
        #endregion

        #region Klassenmethoden
        public static double GetArea(int length, int width)
        {
            return length * width;
        }

        public static double GetPerimeter(int length, int width)
        {
            return 2 * (length + width);
        }
        #endregion
    }
}
