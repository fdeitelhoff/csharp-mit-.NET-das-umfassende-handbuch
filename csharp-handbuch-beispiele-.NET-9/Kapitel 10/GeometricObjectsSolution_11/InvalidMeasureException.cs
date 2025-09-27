using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable enable

namespace GeometricObjectsSolution
{

    [Serializable]
    public class InvalidMeasureException : Exception
    {
        public InvalidMeasureException() { }
        public InvalidMeasureException(string message) : base(message) { }
        public InvalidMeasureException(string message, Exception inner) : base(message, inner) { }
    }
}
