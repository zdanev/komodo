using System;
using System.Threading.Tasks;
using Komodo.Common;

namespace Komodo.Weather
{
    public class WeatherService
    {
        // http://api.openweathermap.org/data/2.5/weather?q={city name}
        // http://api.openweathermap.org/data/2.5/weather?zip=94040,us

        string endpoint = "https://api.openweathermap.org/data/2.5/";

        public async Task<WeatherResponse> GetWeather(string param)
        {
            using (var api = new RestApi(endpoint))
            {
                var model = await api.Get<WeatherResponse>("weather",
                    new QueryParam("zip", param),
                    new QueryParam("APPID", ApiKey.OpenWeatherMapApiKey)
                );

                return model;
            }
        }
    }
}