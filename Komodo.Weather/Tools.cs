namespace Komodo.Weather
{
    public static class Tools
    {
        public static double KtoF(this double k)
        {
            return k * 9 / 5 - 459.67;
        }
    }
}