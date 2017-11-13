namespace Komodo.Weather
{
    public class WeatherResponse
    {
        public GeoCoordinates Coord { get; set; }

        public string Base { get; set; }

        public CurrentWeather[] Weather { get; set; }

        public Main Main { get; set; }

        public double Visibility { get; set; }

        public Wind Wind { get; set; }

        public Clouds Clouds { get; set; }

        public int DT { get; set; } // ?

        public Sys Sys { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Cod { get; set; }
    }

    public class GeoCoordinates
    {
        public double Lon { get; set; }

        public double Lat { get; set; }
    }

    public class CurrentWeather
    {
        public int Id { get; set; }

        public string Main { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
    }

    public class Main 
    {
        public double Temp { get; set; }

        public double Pressure { get; set; }

        public double Humidity { get; set; }

        public double Temp_Min { get; set; }

        public double Temp_Max { get; set; }
    }

    public class Wind 
    {
        public double Speed { get; set; }

        public double Degree { get; set; }
    }

    public class Clouds
    {
        public double All { get; set; }
    }

    public class Sys
    {
        public int Type { get; set; }

        public int Id { get; set; }

        public double Message { get; set; }

        public string Country { get; set; }

        public int Sunrise { get; set; }

        public int Sunset { get; set; }
    }
}