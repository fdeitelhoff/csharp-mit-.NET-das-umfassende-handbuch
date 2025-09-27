using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable enable

namespace GeometricObjectsSolution
{
    public class GraphicRectangle : Rectangle, IDraw
    {
        #region Konstruktoren
        public GraphicRectangle() : base(0, 0, 0, 0) { }
        public GraphicRectangle(int length, int width) : base(length, width, 0, 0) { }
        public GraphicRectangle(int length, int width, double x, double y) : base(length, width, x, y) { }
        #endregion

        #region Instanzmethode
        public virtual void Draw()
        {
            Console.WriteLine("Das Rechteck wird gezeichnet");
        }
        #endregion
    }
}
