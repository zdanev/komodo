using System;
using System.Threading.Tasks;

namespace Stocks
{
    class Program
    {
        static string[] symbols = new[] { "MSFT", "AAPL", "GOOG" };

        static void Main(string[] args)
        {
            var service = new StocksService();
            var task = service.Execute(symbols);
            task.Wait();
        }
    }
}