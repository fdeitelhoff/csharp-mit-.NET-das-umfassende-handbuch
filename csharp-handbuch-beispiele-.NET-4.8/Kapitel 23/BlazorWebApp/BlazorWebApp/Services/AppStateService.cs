namespace BlazorWebApp.Services
{
    public class AppStateService
    {
        public string Benutzername { get; private set; } = "";

        public event Action? OnChange;

        public void SetzeBenutzer(string name)
        {
            Benutzername = name;
            OnChange?.Invoke();
        }
    }

}
