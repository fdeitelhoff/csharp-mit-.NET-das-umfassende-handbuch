using System.Windows.Input;

namespace MauiBeispiele
{
    public class MainViewModel
    {
        private readonly INavigation _navigation;

        public ICommand ÖffneDetailsCommand { get; }

        public MainViewModel(INavigation navigation)
        {
            _navigation = navigation;
            ÖffneDetailsCommand = new Command(async () => await _navigation.PushAsync(new DetailPage()));
        }
    }

}
