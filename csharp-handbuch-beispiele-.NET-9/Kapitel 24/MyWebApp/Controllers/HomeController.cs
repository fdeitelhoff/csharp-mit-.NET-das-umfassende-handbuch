using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TelemetryClient _telemetryClient;

        public HomeController(TelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
        }
        public IActionResult Index()
        {
            // ein benutzerdefiniertes Ereignis verfolgen
            _telemetryClient.TrackEvent("HomePageViewed");
            // eine benutzerdefinierte Metrik verfolgen
            _telemetryClient.TrackMetric("PageLoadTime", 1.23);
            return View();
        }

        public IActionResult Privacy()
        {
            // eine Ausnahme verfolgen
            try
            {
                throw new System.Exception("Ein Beispielfehler");
            }
            catch (System.Exception ex)
            {
                _telemetryClient.TrackException(ex);
            }
            return View();
        }
    }
}