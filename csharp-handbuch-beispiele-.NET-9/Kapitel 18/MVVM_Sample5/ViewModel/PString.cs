using MVVM_Sample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Sample.ViewModel
{
    public class PString : ViewModelBase
    {
        private string _currentValue;
        private string _originalValue;
        private bool _hasChanged;

        public bool HasChanged
        {
            get { return _hasChanged; }
            set
            {
                SetProperty<bool>(ref _hasChanged, value);
            }
        }

        public PString(string value)
        {
            if (value == string.Empty) value = null;
            _currentValue = value;
            _originalValue = value;
        }

        public string Value
        {
            get { return _currentValue; }
            set
            {
                if (value == "") value = null;
                SetProperty<string>(ref _currentValue, value);
                HasChanged = _currentValue != _originalValue;
            }
        }
    }
}
