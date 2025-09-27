using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectsSolution
{
    public delegate void InvalidMeasureEventHandler(Object sender, InvalidMeasureEventArgs e);
    public delegate void MovingEventHandler(Object sender, MovingEventArgs e);
    public delegate void MovedEventHandler(Object sender, EventArgs e);

    public class InvalidMeasureEventArgs : EventArgs
    {
        #region Felder
        private int _InvalidMeasure;
        private string _PropertyName;
        #endregion

        #region Eigenschaften
        public int InvalidMeasure
        {
            get => _InvalidMeasure; 
        }

        public string PropertyName
        {
            get => _PropertyName; 
        }
        #endregion

        #region Konstruktor
        public InvalidMeasureEventArgs(int invalidMeasure, string propertyName)
        {
            _InvalidMeasure = invalidMeasure;
            if (propertyName == "" || propertyName == null)
                _PropertyName = "[unknown]";
            else
                _PropertyName = propertyName;
        }
        #endregion
    }

    public class MovingEventArgs : EventArgs
    {
        public bool Cancel { get; set; }
    }

}
