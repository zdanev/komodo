using System;
using System.Threading.Tasks;
using Komodo.Common;

namespace Komodo.Weather
{
    public class WeatherApp : ConsoleApp
    {
        public override string Title => "Komodo Weather";

        public override async Task ExecuteAsync(string[] args)
        {
            var param = "92656";
            var service = new WeatherService();
            
            var model = await service.GetWeather(param);
            
            Console.WriteLine($"{model.Name}: {model.Weather[0].Description}");
            Console.WriteLine($"Temp: {model.Main.Temp.KtoF()}F (min: {model.Main.Temp_Min.KtoF()}F, max: {model.Main.Temp_Max.KtoF()}F)");
        }
    }
}