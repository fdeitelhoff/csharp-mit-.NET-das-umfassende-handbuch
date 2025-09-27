using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable enable

namespace GeometricObjectsSolution
{
    public struct Point
    {
        #region Eigenschaften
        private double _X;
        private double _Y;

        public double X
        {
            get => _X;
            set => _X = value; 
        }
        public double Y
        {
            get => _Y; 
            set => _Y = value; 
        }
        #endregion

        #region Konstruktor
        public Point(double x, double y)
        {
            _X = x;
            _Y = y;
        }
        #endregion
    }

}
