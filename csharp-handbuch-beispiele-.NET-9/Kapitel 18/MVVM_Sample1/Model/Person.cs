using MVVM_Sample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Sample.Model
{
    public class Person : ViewModelBase
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty<string>(ref _firstName, value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty<string>(ref _lastName, value); }
        }

        private DateTime? _birthDate;
        public DateTime? BirthDate
        {
            get { return _birthDate; }
            set { SetProperty<DateTime?>(ref _birthDate, value); }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { SetProperty<string>(ref _city, value); }
        }

        private string _details;
        public string Details
        {
            get { return _details; }
            set { SetProperty<string>(ref _details, value); }
        }
    }
}
