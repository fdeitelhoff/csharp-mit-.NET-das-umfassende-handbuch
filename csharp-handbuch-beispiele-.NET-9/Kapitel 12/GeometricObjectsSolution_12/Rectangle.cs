using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectsSolution
{
    [Serializable]
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

        ~Rectangle() => Dispose();        
        #endregion

        #region Konstruktoren
        public Rectangle() : this(0, 0, 0, 0) { }

        public Rectangle(int length, int width) : this(length, width, 0, 0) { }

        public Rectangle(int length, int width, double x, double y)
        {
            Length = length;
            Width = width;
            _Center.X = x;
            _Center.Y = y;
            Rectangle.CountRectangles++;
        }

        public Rectangle(int length, int width, Point center)
        {
            Length = length;
            Width = width;
            _Center = center;
            Rectangle.CountRectangles++;
        }

        #endregion

        #region Instanzeigenschaften
        private int _Length;
        public int Length
        {
            get => _Length;
            set
            {
                if (value >= 0)
                {
                    _Length = value;
                    OnPropertyChanged("Length");
                }
                else
                {
                    InvalidMeasureException ex = new InvalidMeasureException("Eine Länge von " + value + " ist nicht zulässig.");
                    ex.Data.Add("Time", DateTime.Now);
                    OnInvalidMeasure(new InvalidMeasureEventArgs(value, "Length", ex));
                }
            }
        }

        private int _Width;
        public int Width
        {
            get => _Width;
            set
            {
                if (value >= 0)
                {
                    _Width = value;
                    OnPropertyChanged("Width");
                }
                else
                {
                    InvalidMeasureException ex = new InvalidMeasureException("Eine Breite von " + value + " ist nicht zulässig.");
                    ex.Data.Add("Time", DateTime.Now);
                    OnInvalidMeasure(new InvalidMeasureEventArgs(value, "Width", ex));
                }
            }
        }
        #endregion

        #region Instanzmethoden
        public override double GetArea() => Length * Width;        

        public override double GetPerimeter() => 2 * (Length + Width);        

        public virtual void Move(double dx, double dy, int dWidth, int dLength)
        {
            MovingEventArgs e = new MovingEventArgs();
            OnMoving(e);
            if (e.Cancel == true) return;

            XCoordinate += dx;
            YCoordinate += dy;
            Width += dWidth;
            Length += dLength;

            OnMoved(new EventArgs());
        }

        public override string ToString() => "Rectangle, L=" + Length + ",B=" + Width + ",Fläche=" + GetArea();        
        #endregion

        #region Klasseneigenschaft
        public static int CountRectangles { get; private set; }
        #endregion

        #region Klassenmethoden
        public static double GetArea(int length, int width) => length * width;        

        public static double GetPerimter(int length, int width) => 2 * (length + width);
        #endregion

        #region Benutzerdefinierte Konvertierung
        public static explicit operator Circle(Rectangle rect)
        {
            int radius = (int)Math.Sqrt(rect.GetArea() / Math.PI);
            return new Circle(radius, rect.Length / 2, rect.Width / 2);
        }
        #endregion
    }
}
