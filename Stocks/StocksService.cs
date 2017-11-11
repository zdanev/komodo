using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Stocks
{
    public class StocksService
    {
        // https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=MSFT&interval=1min&apikey=demo 

        string endpoint = "https://www.alphavantage.co/query";

        public async Task Execute(string[] symbols)
        {
            using (var api = new RestApi(endpoint))
            {
                Console.WriteLine();
                Console.WriteLine("           |       Open |       High |        Low |      Close |     Volume ");
                Console.WriteLine("-----------+------------+------------+------------+------------+------------");

                foreach (var symbol in symbols)
                {
                    var q = await api.Get<dynamic>("query",
                        new QueryParam("function", "TIME_SERIES_INTRADAY"),
                        new QueryParam("symbol", symbol),
                        new QueryParam("interval", "1min"),
                        new QueryParam("apikey", ApiKey.AlphavantageApiKey));

                    var meta = q["Meta Data"];
                    var series = (JToken)q["Time Series (1min)"];
                    var first = (dynamic)series.First;

                    var time =  first.Name;
                    var open = first.Value["1. open"];
                    var high = first.Value["2. high"];
                    var low = first.Value["3. low"];
                    var close = first.Value["4. close"];
                    var volume = first.Value["5. volume"];

                    Console.WriteLine($"{symbol.ToString().PadRight(10)} | {open.ToString().PadLeft(10)} | {high.ToString().PadLeft(10)} | {low.ToString().PadLeft(10)} | {close.ToString().PadLeft(10)} | {volume.ToString().PadLeft(10)} ");
                }
            }           
        }
    }
}