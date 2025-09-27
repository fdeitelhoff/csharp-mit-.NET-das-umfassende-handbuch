namespace WebApiProjekt.Middlewares
{
    public class ZeitmessMiddleware
    {
        private readonly RequestDelegate _next;

        public ZeitmessMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var start = DateTime.UtcNow;
            await _next(context);
            var dauer = DateTime.UtcNow - start;
            Console.WriteLine($"Verarbeitungszeit: {dauer.TotalMilliseconds} ms");
        }
    }
}
