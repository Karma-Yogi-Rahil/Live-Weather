using Microsoft.AspNetCore.Mvc;

namespace Live_Weather_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        [HttpGet("getWeather/{location}")]
        public string GetWeather(string location)
        {
            return "ok";
        }
    }
}
