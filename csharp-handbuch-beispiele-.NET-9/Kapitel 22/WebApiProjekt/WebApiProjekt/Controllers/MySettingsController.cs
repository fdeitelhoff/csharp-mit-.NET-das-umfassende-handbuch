using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebApiProjekt.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class MySettingsController : ControllerBase
    {
        private readonly MySettings _settings;

        public MySettingsController(IOptions<MySettings> options)
        {
            _settings = options.Value;
        }

        public IActionResult GetConfig()
        {
            return Ok(_settings);
        }
    }
}
