namespace BlazorWebApp.Services
{
    public class CounterService
    {
        public int Wert { get; set; }

        public void Increment() => Wert++;
    }
}
