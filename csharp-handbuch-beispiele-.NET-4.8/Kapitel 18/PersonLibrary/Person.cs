using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class Person
    {
        private string _FirstName;
        public string FirstName
        {
            get => _FirstName;
            set => _FirstName = value;
        }

        private string _LastName;
        public string LastName
        {
            get => _LastName;
            set => _LastName = value;
        }

        private int _Age;
        public int Age
        {
            get => _Age;
            set => _Age = value;
        }

        private string _City;
        public string City
        {
            get => _City;
            set => _City = value;
        }
    }

}
