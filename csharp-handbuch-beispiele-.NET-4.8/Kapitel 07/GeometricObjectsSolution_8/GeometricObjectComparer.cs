using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectsSolution
{
    public class GeometricObjectComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            GeometricObject geo1 = x as GeometricObject;
            GeometricObject geo2 = y as GeometricObject;
            if (geo1 != null && geo2 != null)
                return geo1.CompareTo(geo2);
            else
                throw new InvalidCastException();
        }
    }
}
