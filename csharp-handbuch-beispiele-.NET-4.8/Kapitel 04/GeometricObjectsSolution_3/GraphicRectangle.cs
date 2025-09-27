using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectsSolution
{
    public sealed class GraphicRectangle : Rectangle
    {
        #region Konstruktoren
        public GraphicRectangle() : base(0, 0, 0, 0) { }
        public GraphicRectangle(int length, int width) : base(length, width, 0, 0) { }
        public GraphicRectangle(int length, int width, double x, double y) : base(length, width, x, y) { }
        #endregion

        #region Instanzmethode
        public void Draw()
        {
            Console.WriteLine("Das Rechteck wird gezeichnet");
        }
        #endregion
    }
}
