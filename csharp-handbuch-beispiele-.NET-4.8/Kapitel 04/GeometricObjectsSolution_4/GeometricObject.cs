using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectsSolution
{
    public abstract class GeometricObject : IComparable
    {
        #region Konstruktor
        public GeometricObject()
        {
            CountGeometricObjects++;
        }
        #endregion

        #region Eigenschaften
        public virtual double XCoordinate { get; set; }
        public virtual double YCoordinate { get; set; }
        #endregion

        #region Instanzmethoden
        public virtual int CompareTo(Object obj)
        {
            GeometricObject geoObject = obj as GeometricObject;
            if (geoObject != null)
            {
                if (GetArea() < geoObject.GetArea()) return -1;
                if (GetArea() == geoObject.GetArea()) return 0;
                return 1;
            }
            // Auslösen einer Ausnahme
            throw new ArgumentException("Es wird der Typ 'GeometricObject' erwartet.");
        }


        public virtual void Move(double dx, double dy)
        {
            XCoordinate += dx;
            YCoordinate += dy;
        }
        #endregion

        #region Abstrakte Methoden
        public abstract double GetArea();
        public abstract double GetPerimeter();
        #endregion

        #region Klasseneigenschaft
        public static int CountGeometricObjects { get; private set; }
        #endregion

        #region Klassenmethode
        public static int Bigger(GeometricObject geo1, GeometricObject geo2)
        {
            if (geo1 == null && geo2 == null) return 0;
            if (geo1 == null) return -1;
            if (geo1 == null) return 1;
            if (geo1.GetArea() > geo2.GetArea()) return 1;
            if (geo1.GetArea() < geo2.GetArea()) return -1;
            return 0;
        }
        #endregion
    }
}
