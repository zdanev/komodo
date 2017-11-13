using System;

namespace Komodo.Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new WeatherApp();
            
            app.Run(args);
        }
    }
}