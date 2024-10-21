using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pim_Web.Services;

namespace Pim_Web.Controllers
{
    [Authorize]
    
    public class WeatherApiController : Controller
    {
        private readonly WeatherApi _weatherService;

        public WeatherApiController(WeatherApi weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IActionResult> Index(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                city = "São Paulo"; // Cidade padrão
            }

            var weatherData = await _weatherService.GetWeatherData(city);
            ViewBag.WeatherData = weatherData;
            return View();
        }
    }
}
