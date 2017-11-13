using System;

namespace Komodo.Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            var param = "92656";

            var service = new WeatherService();
            var task = service.GetWeather(param);
            
            task.Wait();

            var model = task.Result;

            Console.WriteLine($"{model.Name}: {model.Weather[0].Description}");
            Console.WriteLine($"Temp: {model.Main.Temp.KtoF()}F (min: {model.Main.Temp_Min.KtoF()}F, max: {model.Main.Temp_Max.KtoF()}F)");
        }
    }
}