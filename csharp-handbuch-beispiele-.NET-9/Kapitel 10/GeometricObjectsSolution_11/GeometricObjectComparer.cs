using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable enable

namespace GeometricObjectsSolution
{
    public class GeometricObjectComparer : IComparer, IComparer<GeometricObject>
    {
        public int Compare(object? x, object? y)
        {
            if(x is GeometricObject && y is GeometricObject)
                return ((GeometricObject)x).CompareTo((GeometricObject)y);
            else
                throw new InvalidCastException();
        }

        public int Compare(GeometricObject? x, GeometricObject? y) => GeometricObject.Bigger(x, y);
    }
}
