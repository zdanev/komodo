using System;
using System.Threading.Tasks;
using Komodo.Common;

using static Komodo.Common.ConsoleHelper;

namespace Komodo.Weather
{
    public class WeatherApp : ConsoleApp
    {
        public override string Title => "Komodo Weather";

        public override async Task ExecuteAsync(string[] args)
        {
            var param = "92656";
            var service = new WeatherService();

            WriteLine($"Getting weather for {param}...", Style.Subtle);
            
            var model = await service.GetWeather(param);
            
            ClearPrevConsoleLine();
            WriteLine($"{model.Name}: {model.Weather[0].Description}", Style.Highlight);
            WriteLine($"Temp: {model.Main.Temp.KtoF()}F (min: {model.Main.Temp_Min.KtoF()}F, max: {model.Main.Temp_Max.KtoF()}F)");
        }
    }
}