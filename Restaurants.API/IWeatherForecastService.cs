namespace Restaurants.API
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}