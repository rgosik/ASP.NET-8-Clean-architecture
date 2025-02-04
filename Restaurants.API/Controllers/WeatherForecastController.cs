using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
        IWeatherForecastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet]
    [Route("example")]
    public IEnumerable<WeatherForecast> Get()
    {
        var result = _weatherForecastService.Get();
        return result;
    }

    [HttpGet("{take}/currentDay")]
    public IActionResult GetCurrentDateForecast([FromRoute] int take, [FromQuery] int min, [FromQuery] int max)
    {
        var result = _weatherForecastService.Get().First();

        //Response.StatusCode = 404;
        //return StatusCode(404, result);
        return NotFound(result);
    }

    [HttpPost("generate")]
    public IActionResult Generate([FromQuery] int count, [FromBody] TemperatureRequest request)
    {
        if (count < 0 || request.Min > request.Max)
        {
            return BadRequest("Count must be possitive value and Max must be greater than Min");
        }

        var result = _weatherForecastService.Get(count, request.Min, request.Max);
        return Ok(result);
    }

    [HttpPost]
    public string Hello([FromBody] string name)
    {
        return $"Hello {name}";
    }
}

public class TemperatureRequest
{
    public int Min { get; init; }
    public int Max { get; init; }
}