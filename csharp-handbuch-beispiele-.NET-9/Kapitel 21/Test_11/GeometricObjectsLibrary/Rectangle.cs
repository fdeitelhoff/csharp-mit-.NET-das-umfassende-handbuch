using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectsLibrary
{
    public class Rectangle
    {
        public int Length { get; set; }
        public int Width { get; set; }

        public long GetArea()
        {
            return Length * Width;
        }

        public long GetPerimeter()
        {
            return 2 * (Length + Width);
        }
    }
}
