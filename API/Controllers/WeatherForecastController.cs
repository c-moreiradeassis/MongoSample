using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IProductApplication _productApplication;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IProductApplication productApplication)
        {
            _logger = logger;
            _productApplication = productApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productApplication.GetAllAsync("Test");

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct()
        {
            await _productApplication.CreateProductAsync();

            return Ok();
        }
    }
}
