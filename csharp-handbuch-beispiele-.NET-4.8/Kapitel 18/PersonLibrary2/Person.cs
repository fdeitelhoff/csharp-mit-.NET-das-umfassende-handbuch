using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary2
{
    public class Person : PropertyObservable
    {
        private bool _Pension;
        public bool Pension
        {
            get => _Pension;
            private set => SetProperty(ref _Pension, value);
        }

        private string _FirstName;
        public string FirstName
        {
            get => _FirstName;
            set => SetProperty(ref _FirstName, value);
        }

        private string _LastName;
        public string LastName
        {
            get => _LastName;
            set => SetProperty(ref _LastName, value);
        }

        private int _Age;
        public int Age
        {
            get => _Age;
            set
            {
                SetProperty(ref _Age, value);
                Pension = Age >= 65;
            }
        }

        private string _City;
        public string City
        {
            get => _City;
            set => SetProperty(ref _City, value);
        }
    }
}
