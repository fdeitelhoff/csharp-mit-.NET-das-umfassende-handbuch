using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiBeispiele
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _benutzername;
        public string Benutzername
        {
            get => _benutzername;
            set
            {
                if (_benutzername != value)
                {
                    _benutzername = value;
                    OnPropertyChanged(nameof(Benutzername));
                }
            }
        }

        private string _begrüßung;
        public string Begrüßung
        {
            get => _begrüßung;
            set
            {
                if (_begrüßung != value)
                {
                    _begrüßung = value;
                    OnPropertyChanged(nameof(Begrüßung));
                }
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(() =>
            {
                if (!string.IsNullOrWhiteSpace(Benutzername))
                {
                    Begrüßung = $"Willkommen, {Benutzername}!";
                    VibrateDevice();
                }
                else
                    Begrüßung = "Bitte gib deinen Namen ein.";
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void VibrateDevice()
        {
            //Vibration.Vibrate(500);
            // Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(500));
        }
    }
}
