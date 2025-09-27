using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataErrorInfo_Sample
{
    public class Person : IDataErrorInfo
    {
        public string Error
        {
            get => null; 
        }

        public string this[string propertyName]
        {
            get
            {
                if (propertyName == "Age" && _Age < 0)
                  return "Das Alter darf nicht negativ sein.";
                return null;
            }
        }

        private int _Age;
        public int Age
        {
            get => _Age; 
            set => _Age = value;
        }
    }
}
