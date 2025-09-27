using MVVM_Sample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Sample.ViewModel
{
    public class PDateTime : ViewModelBase
    {
        private DateTime? _currentValue;
        private DateTime? _originalValue;
        private bool _hasChanged;
        private bool _hasError;
        private string _errorValue;

        public PDateTime(DateTime? date)
        {
            _currentValue = date;
            _originalValue = date;
        }

        public DateTime? CurrentValue
        {
            get { return _currentValue; }
        }

        public string Value
        {
            get 
            {
                if (HasError) return _errorValue;
                if (!_currentValue.HasValue) return null; 
                return _currentValue.Value.ToShortDateString();
            }

            set
            {
                DateTime newValue;
                HasError = false;
                if (value == string.Empty)
                    SetProperty(ref _currentValue, null);
                else if (DateTime.TryParse(value, out newValue))
                    SetProperty(ref _currentValue, newValue);
                else
                {
                    _errorValue = value;
                    HasError = true;
                }
                HasChanged = _currentValue != _originalValue;
            }
        }

        public bool HasChanged
        {
            get { return _hasChanged; }
            set
            {
                SetProperty<bool>(ref _hasChanged, value);
            }
        }

        public bool HasError
        {
            get { return _hasError; }
            set
            {
                SetProperty<bool>(ref _hasError, value);
            }
        }
    }
}
